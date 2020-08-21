using System;
using System.ComponentModel;
using System.Windows.Forms;
using FormBusca;
using CamadaDados.Faturamento.Pedido;
using CamadaDados.Faturamento.Cadastros;
using CamadaDados.Diversos;
using CamadaDados.Financeiro.Cadastros;
using Utils;
using CamadaNegocio.Faturamento.Pedido;
using System.Collections;

namespace Faturamento
{
    public partial class TFLanExpedicao : Form
    {
        private bool st_alterarserie
        { get; set; }
        private bool Altera_Relatorio = false;
        public TFLanExpedicao()
        {
            InitializeComponent();
            //Buscar Grupo Produto
            CamadaDados.Estoque.Cadastros.TList_CadGrupoProduto lGrupo =
                new CamadaDados.Estoque.Cadastros.TCD_CadGrupoProduto().Select(
                    new TpBusca[]
                    {
                        new TpBusca()
                        {
                            vNM_Campo = "a.TP_Grupo",
                            vOperador = "=",
                            vVL_Busca = "'A'"
                        }
                    }, 0, string.Empty);

            ArrayList cbx = new ArrayList();
            cbx.Add(new Utils.TDataCombo("<<<TODOS>>>", string.Empty));
            for (int i = 0; lGrupo.Count > i; i++)
                cbx.Add(new Utils.TDataCombo(lGrupo[i].DS_Grupo, lGrupo[i].CD_Grupo));
            cbxGrupo.DataSource = cbx;
            cbxGrupo.DisplayMember = "Display";
            cbxGrupo.ValueMember = "Value";
        }

        public void afterBusca()
        {
            TpBusca[] filtro = new TpBusca[4];
            //Pedidos Encerrados e fechados
            filtro[0].vNM_Campo = "a.ST_Pedido";
            filtro[0].vOperador = "in";
            filtro[0].vVL_Busca = "('F', 'P')";
            //Buscar somente pedidos de saida
            filtro[1].vNM_Campo = "a.TP_Movimento";
            filtro[1].vOperador = "=";
            filtro[1].vVL_Busca = "'S'";
            //Buscar pedido que estiverem com etapa liberar pedido finalizada
            filtro[2].vNM_Campo = string.Empty;
            filtro[2].vOperador = "exists";
            filtro[2].vVL_Busca = "(select 1 from TB_FAT_Pedido_Etapa x " +
                                   "inner join TB_FAT_EtapaPed y " +
                                   "on x.id_etapa = y.id_etapa " +
                                   "where x.nr_pedido = a.nr_pedido " +
                                   "and isnull(y.ST_LiberarExped, 'N') = 'S')";
            //Somente pedidos que não sejam origem numa troca de CNPJ
            filtro[3].vNM_Campo = string.Empty;
            filtro[3].vOperador = "not exists";
            filtro[3].vVL_Busca = "(select 1 from tb_fat_trocacliente x " +
                                  "where x.nr_pedidoorigem = a.nr_pedido)";
            if ((dt_inicio.Text.Trim() != string.Empty) && (dt_inicio.Text.Trim() != "/  /"))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = rbPedido.Checked ? "a.dt_pedido" : "a.DT_EntregaPedido";
                filtro[filtro.Length - 1].vOperador = ">=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + string.Format(new System.Globalization.CultureInfo("en-US", true), Convert.ToDateTime(dt_inicio.Text).ToString("yyyyMMdd")) + " 00:00:00'";
            }
            if ((dt_fin.Text.Trim() != string.Empty) && (dt_fin.Text.Trim() != "/  /"))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = rbPedido.Checked ? "a.dt_pedido" : "a.DT_EntregaPedido";
                filtro[filtro.Length - 1].vOperador = "<=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + string.Format(new System.Globalization.CultureInfo("en-US", true), Convert.ToDateTime(dt_fin.Text).ToString("yyyyMMdd")) + " 23:59:59'";
            }
            if (!string.IsNullOrEmpty(CD_Empresa_Busca.Text))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.CD_Empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + CD_Empresa_Busca.Text.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(NR_Pedido_Busca.Text))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.Nr_Pedido";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = NR_Pedido_Busca.Text;
            }
            if (!string.IsNullOrEmpty(Nr_orcamento.Text))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = string.Empty;
                filtro[filtro.Length - 1].vOperador = string.Empty;
                filtro[filtro.Length - 1].vVL_Busca = "(exists( select 1 from tb_fat_pedido_itens x" +
                                                        " where x.nr_pedido = a.nr_pedido" +
                                                        " and x.nr_orcamento = '" + Nr_orcamento.Text.Trim() + "'))";
            }
            if (!string.IsNullOrEmpty(CD_Clifor_Busca.Text))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.CD_Clifor";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + CD_Clifor_Busca.Text.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(CFG_Pedido_Busca.Text))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.CFG_Pedido";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + CFG_Pedido_Busca.Text.Trim() + "'";
            }
            else
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = string.Empty;
                filtro[filtro.Length - 1].vOperador = "EXISTS";
                filtro[filtro.Length - 1].vVL_Busca = "(select 1 from tb_div_usuario_x_cfgpedido x " +
                                                      "where x.cfg_pedido = a.cfg_pedido " +
                                                      "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                                                      "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                                      "         where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))";
            }
            if (!string.IsNullOrEmpty(Cd_produto.Text))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = string.Empty;
                filtro[filtro.Length - 1].vOperador = "exists";
                filtro[filtro.Length - 1].vVL_Busca = "(select 1 from TB_FAT_Pedido_Itens x " +
                                                      "where x.nr_pedido = a.nr_pedido " +
                                                      "and x.cd_produto = '" + Cd_produto.Text.Trim() + "')";
            }
            if (cbxGrupo.SelectedIndex != 0)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = string.Empty;
                filtro[filtro.Length - 1].vOperador = "exists";
                filtro[filtro.Length - 1].vVL_Busca = "(select 1 from TB_FAT_Pedido_Itens x " +
                                                      "inner join TB_EST_Produto y " +
                                                      "on x.cd_produto = y.cd_produto " +
                                                      "where x.nr_pedido = a.nr_pedido " +
                                                      "and y.cd_grupo " + (rbIgnorar.Checked.Equals(true) ? " <> '" : " = '") + cbxGrupo.SelectedValue.ToString() + "')";
            }
            if (st_carregar.Checked)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = string.Empty;
                filtro[filtro.Length - 1].vOperador = string.Empty;
                filtro[filtro.Length - 1].vVL_Busca = "exists(select 1 from VTB_FAT_Pedido_Itens x " +
                                                      "where x.nr_pedido = a.nr_pedido " +
                                                      "and (x.quantidade - x.qtd_expedida + x.qtd_devolvida) > 0) or " +
                                                      //Acessórios Pedido
                                                      "exists(select 1 from VTB_FAT_AcessoriosPed k " +
                                                      "where k.nr_pedido = a.Nr_pedido " +
                                                      "and (k.quantidade - k.qtd_expedida) > 0)";
            }
            if (st_itensExpedidos.Checked)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = string.Empty;
                filtro[filtro.Length - 1].vOperador = "exists";
                filtro[filtro.Length - 1].vVL_Busca = "(select 1 from TB_FAT_ItensExpedicao x  " +
                                                      "where a.nr_pedido = x.nr_pedido) ";
            }

            BS_Pedido.DataSource = new TCD_Pedido().Select(filtro, 0, string.Empty);
            BS_Pedido_PositionChanged(this, new EventArgs());
        }

        public void InserirExpedicao()
        {
            if (BS_Pedido.Current != null)
            {
                using (TFItensExpedicao fItens = new TFItensExpedicao())
                {
                    fItens.Nr_pedido = (BS_Pedido.Current as TRegistro_Pedido).Nr_pedido.ToString();
                    fItens.Ds_obs = (BS_Pedido.Current as TRegistro_Pedido).DS_Observacao;
                    if (fItens.ShowDialog() == DialogResult.OK)
                    {
                        if (fItens.rExpedicao != null)
                        {
                            try
                            {
                                fItens.rExpedicao.Cd_empresa = (BS_Pedido.Current as TRegistro_Pedido).CD_Empresa;
                                TCN_Expedicao.Gravar(fItens.rExpedicao, null);
                                afterBusca();
                            }
                            catch (Exception ex)
                            { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                        }
                    }
                }
            }
        }

        public void ExcluirExpedicao()
        {
            if (bsExpedicao.Current != null)
            {
                //Verificar se expedição está alocada a uma ordem de carregamento
                if (new TCD_Expedicao().BuscarEscalar(
                        new TpBusca[]
                        {
                            new TpBusca()
                            {
                                vNM_Campo = string.Empty,
                                vOperador = "exists",
                                vVL_Busca = "(select 1 from TB_FAT_Ordem_X_Expedicao x " +
                                            "where a.cd_empresa = x.cd_empresa " +
                                            "and a.id_expedicao = x.id_expedicao " +
                                            "and x.cd_empresa = '" + (bsExpedicao.Current as TRegistro_Expedicao).Cd_empresa.Trim() + "'" +
                                            "and x.id_expedicao = " + (bsExpedicao.Current as TRegistro_Expedicao).Id_expedicaostr + ") "
                            }
                        }, "1") != null)
                {
                    MessageBox.Show("Expedição está alocada em uma ordem de carregamento!\r\n" +
                                    "Por favor verifique com o responsável pela ordem de carregamento.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (MessageBox.Show("Confirma a exclusão da expedição?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                    == DialogResult.Yes)
                    try
                    {
                        TCN_Expedicao.Excluir(bsExpedicao.Current as TRegistro_Expedicao, null);
                        MessageBox.Show("Expedição excluída com sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        afterBusca();
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        public void afterPrint()
        {
            if (bsExpedicao.Current != null)
            {
                using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
                {
                    FormRelPadrao.Relatorio Rel = new FormRelPadrao.Relatorio();
                    Rel.Altera_Relatorio = Altera_Relatorio;
                    BindingSource bs_valor = new BindingSource();
                    bs_valor.DataSource = (BS_Pedido.Current as TRegistro_Pedido).lExpedicao;
                    Rel.DTS_Relatorio = bs_valor;
                    Rel.Ident = Name;
                    Rel.NM_Classe = Name;
                    Rel.Modulo = "FAT";
                    fImp.St_enabled_enviaremail = true;
                    fImp.pCd_clifor = string.Empty;
                    fImp.pMensagem = "ORDEM DE EXPEDIÇÃO";

                    //Buscar dados Empresa
                    CamadaDados.Diversos.TList_CadEmpresa lEmpresa =
                        CamadaNegocio.Diversos.TCN_CadEmpresa.Busca((bsExpedicao.Current as TRegistro_Expedicao).Cd_empresa,
                                                                    string.Empty,
                                                                    string.Empty,
                                                                    null);

                    //Buscar Endereço Destinatário
                    BindingSource bsEndDest = new BindingSource();
                    bsEndDest.DataSource =
                        CamadaNegocio.Financeiro.Cadastros.TCN_CadEndereco.Buscar((BS_Pedido.Current as TRegistro_Pedido).CD_Clifor,
                                                                                  (BS_Pedido.Current as TRegistro_Pedido).CD_Endereco,
                                                                                  string.Empty,
                                                                                  string.Empty,
                                                                                  string.Empty,
                                                                                  string.Empty,
                                                                                  string.Empty,
                                                                                  string.Empty,
                                                                                  string.Empty,
                                                                                  string.Empty,
                                                                                  string.Empty,
                                                                                  string.Empty,
                                                                                  string.Empty,
                                                                                  string.Empty,
                                                                                  0,
                                                                                  null);

                    Rel.Adiciona_DataSource("ENDERECODEST", bsEndDest);
                    if (lEmpresa.Count > 0)
                        if (lEmpresa[0].Img != null)
                            Rel.Parametros_Relatorio.Add("IMAGEM_RELATORIO", lEmpresa[0].Img);

                    if (Altera_Relatorio)
                    {
                        Rel.Gera_Relatorio(string.Empty,
                                           fImp.pSt_imprimir,
                                           fImp.pSt_visualizar,
                                           fImp.pSt_enviaremail,
                                           fImp.pSt_exportPdf,
                                           fImp.Path_exportPdf,
                                           fImp.pDestinatarios,
                                           null,
                                           "ORDEM DE EXPEDIÇÃO",
                                           fImp.pDs_mensagem);
                        Altera_Relatorio = false;
                    }
                    else
                        if ((fImp.ShowDialog() == DialogResult.OK) || (fImp.pSt_enviaremail))
                        Rel.Gera_Relatorio(string.Empty,
                                           fImp.pSt_imprimir,
                                           fImp.pSt_visualizar,
                                           fImp.pSt_enviaremail,
                                           fImp.pSt_exportPdf,
                                           fImp.Path_exportPdf,
                                           fImp.pDestinatarios,
                                           null,
                                           "ORDEM DE EXPEDIÇÃO",
                                           fImp.pDs_mensagem);
                }
            }
        }

        private void TFLanExpedicao_Load(object sender, EventArgs e)
        {
            Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pConsulta.set_FormatZero();
            st_alterarserie = CamadaNegocio.Diversos.TCN_Usuario_RegraEspecial.ValidaRegra(Utils.Parametros.pubLogin, "PERMITIR ALTERAR Nº SÉRIE", null);
            if (!string.IsNullOrEmpty(Faturamento.Properties.Settings.Default.CD_GRUPO))
                cbxGrupo.SelectedValue = Faturamento.Properties.Settings.Default.CD_GRUPO;
            if (!string.IsNullOrEmpty(Faturamento.Properties.Settings.Default.ST_GRUPO))
                if (Faturamento.Properties.Settings.Default.ST_GRUPO.Equals("I"))
                    rbIgnorar.Checked = true;
                else
                    rbBuscarGrupo.Checked = true;
        }

        private void BB_Buscar_Click(object sender, EventArgs e)
        {
            afterBusca();
        }

        private void BB_Fechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_Inserir_Item_Click(object sender, EventArgs e)
        {
            InserirExpedicao();
        }

        private void btn_Deleta_Item_Click(object sender, EventArgs e)
        {
            ExcluirExpedicao();
        }

        private void TFLanExpedicao_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F7))
                afterBusca();
            else if (e.Control && e.KeyCode.Equals(Keys.P))
            {
                Altera_Relatorio = true;
                MessageBox.Show("Execute o relatorio que deseja alterar.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void CFG_Pedido_Busca_Leave(object sender, EventArgs e)
        {
            string vParam = "a.CFG_Pedido|=|'" + CFG_Pedido_Busca.Text.Trim() + "';" +
                            "||((b.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                            "(EXISTS(select 1 from tb_div_usuario_x_grupos x   " +
                            "       where x.logingrp = b.login and x.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "')))";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { CFG_Pedido_Busca }, new TCD_CadCFGPedido("SqlCodeBuscaXUsuario"));
        }

        private void btn_CFG_Pedido_Busca_Click(object sender, EventArgs e)
        {
            string vParam = "||((b.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                           "(EXISTS(select 1 from tb_div_usuario_x_grupos x   " +
                           "       where x.logingrp = b.login and x.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "')))";
            UtilPesquisa.BTN_BUSCA("DS_TipoPedido|DS CFG Pedido|300;TP_Movimento|Movimento|50;a.CFG_Pedido|CD. CFG Pedido|80;ST_Servico|Servico|50"
                            , new Componentes.EditDefault[] { CFG_Pedido_Busca }, new TCD_CadCFGPedido("SqlCodeBuscaXUsuario"), vParam);
        }

        private void CD_Empresa_Busca_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("a.cd_empresa|=|'" + CD_Empresa_Busca.Text + "';" +
                                  "|EXISTS|(select 1 from Tb_div_usuario_X_empresa  x where x.cd_empresa = A.cd_empresa " +
                                  "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                                  "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                  "         where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))"
              , new Componentes.EditDefault[] { CD_Empresa_Busca }, new TCD_CadEmpresa());
        }

        private void btn_Empresa_Busca_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BUSCA("a.NM_empresa|Nome Empresa|300;a.CD_Empresa|Cód Empresa|100"
                         , new Componentes.EditDefault[] { CD_Empresa_Busca }
                         , new TCD_CadEmpresa(),
                         "|EXISTS|(select 1 from Tb_div_usuario_X_empresa  x where x.cd_empresa = A.cd_empresa " +
                         "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                         "(exists(select 1 from tb_div_usuario_x_grupos y " +
                         "         where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))");
        }

        private void CD_Clifor_Busca_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("a.cd_clifor|=|'" + CD_Clifor_Busca.Text + "';isnull(a.st_registro, 'A')|<>|'C'"
                , new Componentes.EditDefault[] { CD_Clifor_Busca }, new TCD_CadClifor());
        }

        private void btn_Clifor_Busca_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { CD_Clifor_Busca }, "isnull(a.st_registro, 'A')|<>|'C'");
        }

        private void Cd_produto_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVEProduto("a.cd_produto|=|'" + Cd_produto.Text.Trim() + "'",
                                                   new Componentes.EditDefault[] { Cd_produto },
                                                   new CamadaDados.Estoque.Cadastros.TCD_CadProduto());
        }

        private void bb_produto_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BuscaProduto(new Componentes.EditDefault[] { Cd_produto }, string.Empty);
        }

        private void BS_Pedido_PositionChanged(object sender, EventArgs e)
        {
            if (BS_Pedido.Current != null)
            {
                //Buscar Expedição
                (BS_Pedido.Current as TRegistro_Pedido).lExpedicao =
                    new TCD_Expedicao().Select(
                        new TpBusca[]
                        {
                            new TpBusca()
                            {
                                vNM_Campo = string.Empty,
                                vOperador = "exists",
                                vVL_Busca = "(select 1 from TB_FAT_ItensExpedicao x " +
                                            "where a.cd_empresa = x.cd_empresa " +
                                            "and a.id_expedicao = x.id_expedicao " +
                                            "and x.nr_pedido = " + (BS_Pedido.Current as TRegistro_Pedido).Nr_pedido + ") "
                            }
                        }, 0, string.Empty);

                //Buscar lista de itens
                (BS_Pedido.Current as TRegistro_Pedido).Pedido_Itens =
                    new TCD_LanPedido_Item().Select(new TpBusca[]
                    {
                        new TpBusca()
                        {
                            vNM_Campo = "a.nr_pedido",
                            vOperador = "=",
                            vVL_Busca = (BS_Pedido.Current as TRegistro_Pedido).Nr_pedido.ToString()
                        },
                        new TpBusca()
                        {
                            vNM_Campo = "a.quantidade - a.qtd_expedida",
                            vOperador = ">",
                            vVL_Busca = "0"
                        }
                    }, 0, string.Empty, string.Empty, string.Empty);
                //Buscar Acessórios
                (BS_Pedido.Current as TRegistro_Pedido).lAcessorios =
                    new TCD_AcessoriosPed().Select(
                        new TpBusca[]
                        {
                            new TpBusca()
                            {
                                vNM_Campo = "a.nr_pedido",
                                vOperador = "=",
                                vVL_Busca = (BS_Pedido.Current as TRegistro_Pedido).Nr_pedido.ToString()
                            },
                            new TpBusca()
                            {
                                vNM_Campo = "a.quantidade - a.qtd_expedida",
                                vOperador = ">",
                                vVL_Busca = "0"
                            }
                        }, 0, string.Empty);
                BS_Pedido.ResetCurrentItem();
                bsExpedicao_PositionChanged(this, new EventArgs());
                BS_Itens_PositionChanged(this, new EventArgs());
            }
        }

        private void bsExpedicao_PositionChanged(object sender, EventArgs e)
        {
            if (bsExpedicao.Current != null)
            {
                (bsExpedicao.Current as TRegistro_Expedicao).lItens =
                    TCN_ItensExpedicao.Busca((bsExpedicao.Current as TRegistro_Expedicao).Cd_empresa,
                                             (bsExpedicao.Current as TRegistro_Expedicao).Id_expedicaostr,
                                             string.Empty,
                                             null);
                bsExpedicao.ResetCurrentItem();
                bsItensExpedicao_PositionChanged(this, new EventArgs());
            }
        }

        private void btn_Imprimir_Item_Click(object sender, EventArgs e)
        {
            afterPrint();
        }

        private void g_Consulta_Pedido_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (g_Consulta_Pedido.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.NotSortable)
                return;
            if (BS_Pedido.Count < 1)
                return;
            PropertyDescriptorCollection lP = TypeDescriptor.GetProperties(new TRegistro_Pedido());
            TList_Pedido lComparer;
            SortOrder direcao = SortOrder.None;
            if ((g_Consulta_Pedido.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None) ||
                (g_Consulta_Pedido.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending))
            {
                lComparer = new TList_Pedido(lP.Find(g_Consulta_Pedido.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Ascending);
                foreach (DataGridViewColumn c in g_Consulta_Pedido.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Ascending;
            }
            else
            {
                lComparer = new TList_Pedido(lP.Find(g_Consulta_Pedido.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Descending);
                foreach (DataGridViewColumn c in g_Consulta_Pedido.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Descending;
            }
            (BS_Pedido.List as TList_Pedido).Sort(lComparer);
            BS_Pedido.ResetBindings(false);
            g_Consulta_Pedido.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = direcao;
        }

        private void cbxGrupo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxGrupo.SelectedIndex != 0)
            {
                Faturamento.Properties.Settings.Default.CD_GRUPO = cbxGrupo.SelectedValue.ToString();
                Faturamento.Properties.Settings.Default.Save();
            }
        }

        private void rbIgnorar_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxGrupo.SelectedIndex != 0)
            {
                Faturamento.Properties.Settings.Default.ST_GRUPO = rbIgnorar.Checked ? "I" : "B";
                Faturamento.Properties.Settings.Default.Save();
            }
        }

        private void rbBuscarGrupo_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxGrupo.SelectedIndex != 0)
            {
                Faturamento.Properties.Settings.Default.ST_GRUPO = rbBuscarGrupo.Checked ? "B" : "I";
                Faturamento.Properties.Settings.Default.Save();
            }
        }

        private void bb_alterar_Click(object sender, EventArgs e)
        {
            if (bsItensExpedicao.Current != null)
            {
                string pLogin = Utils.Parametros.pubLogin;
                if (!st_alterarserie)
                    using (Parametros.Diversos.TFRegraUsuario fRegra = new Parametros.Diversos.TFRegraUsuario())
                    {
                        fRegra.Ds_regraespecial = "PERMITIR ALTERAR Nº SÉRIE";
                        fRegra.Login = Utils.Parametros.pubLogin;
                        if (fRegra.ShowDialog() == DialogResult.OK)
                        {
                            st_alterarserie = true;
                            pLogin = fRegra.Login;
                        }
                    }
                if (st_alterarserie)
                {
                    if (string.IsNullOrEmpty((bsItensExpedicao.Current as TRegistro_ItensExpedicao).Nr_serie))
                    {
                        MessageBox.Show("Item não possui Nº Série para ser alterado!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    string vParam = "(|NOT EXISTS|(SELECT 1 FROM TB_FAT_ItensExpedicao x " +
                                      "where a.id_serie = x.id_serie ) " +
                                     "or exists (SELECT 1 FROM TB_FAT_ItensExpedicao x " +
                                     "inner join TB_FAT_Ordem_X_Expedicao y " +
                                     "on x.CD_Empresa = y.CD_Empresa " +
                                     "and x.ID_Expedicao = y.id_expedicao " +
                                     "inner join TB_FAT_CompDevol_NF w " +
                                     "on y.CD_Empresa = w.CD_Empresa " +
                                     "and y.Nr_lanctoFiscal = w.Nr_LanctoFiscal_Origem " +
                                     "inner join TB_PRD_Seriedevolvida z " +
                                     "on w.cd_empresa = z.cd_empresa " +
                                     "and w.nr_lanctofiscal_destino = z.nr_lanctofiscal " +
                                     "and w.id_nfitem_destino = z.ID_NFItem " +
                                     "where a.id_serie = x.id_serie )); " +
                                     "a.cd_empresa|=|'" + (bsItensExpedicao.Current as CamadaDados.Faturamento.Pedido.TRegistro_ItensExpedicao).Cd_empresa.Trim() + "';" +
                                     "a.cd_produto|=|'" + (bsItensExpedicao.Current as CamadaDados.Faturamento.Pedido.TRegistro_ItensExpedicao).Cd_produto.Trim() + "';" +
                                     "isnull(a.st_registro, 'P')|=|'P'";
                    Componentes.EditDefault id = new Componentes.EditDefault();
                    id.NM_CampoBusca = "ID_Serie";
                    Componentes.EditDefault ds = new Componentes.EditDefault();
                    ds.NM_CampoBusca = "Nr_serie";
                    FormBusca.UtilPesquisa.BTN_BUSCA("a.Nr_serie|Nº Série|200;" +
                                                     "a.Id_serie|ID|50",
                                                     new Componentes.EditDefault[] { id, ds },
                                                     new CamadaDados.Producao.Producao.TCD_SerieProduto(),
                                                     vParam);

                    if (!string.IsNullOrEmpty(id.Text))
                        try
                        {
                            InputBox ibp = new InputBox();
                            ibp.Text = "Motivo Cancelamento Locação";
                            string motivo = ibp.ShowDialog();
                            if (string.IsNullOrEmpty(motivo))
                            {
                                MessageBox.Show("Obrigatorio informar motivo de cancelamento da locação!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                            if (motivo.Trim().Length < 10)
                            {
                                MessageBox.Show("Motivo de cancelamento deve ter mais que 10 caracteres!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                            CamadaNegocio.Faturamento.Pedido.TCN_TrocaSerieExped.Gravar(
                                new TRegistro_TrocaSerieExped()
                                {
                                    Cd_empresa = (bsItensExpedicao.Current as CamadaDados.Faturamento.Pedido.TRegistro_ItensExpedicao).Cd_empresa,
                                    Id_expedicaostr = (bsItensExpedicao.Current as CamadaDados.Faturamento.Pedido.TRegistro_ItensExpedicao).Id_expedicaostr,
                                    Id_itemstr = (bsItensExpedicao.Current as CamadaDados.Faturamento.Pedido.TRegistro_ItensExpedicao).Id_itemstr,
                                    Id_SerieNewstr = id.Text,
                                    Id_SerieOldstr = (bsItensExpedicao.Current as CamadaDados.Faturamento.Pedido.TRegistro_ItensExpedicao).Id_seriestr,
                                    Login = pLogin,
                                    Motivo = motivo
                                }, null);
                            MessageBox.Show("Nº Série alterado com sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            bsExpedicao_PositionChanged(this, new EventArgs());
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                }
            }
        }

        private void bsItensExpedicao_PositionChanged(object sender, EventArgs e)
        {
            if (bsItensExpedicao.Current != null)
            {
                (bsItensExpedicao.Current as TRegistro_ItensExpedicao).lTroca =
                    CamadaNegocio.Faturamento.Pedido.TCN_TrocaSerieExped.Busca(string.Empty,
                                                                               (bsItensExpedicao.Current as TRegistro_ItensExpedicao).Cd_empresa,
                                                                               (bsItensExpedicao.Current as TRegistro_ItensExpedicao).Id_expedicaostr,
                                                                               (bsItensExpedicao.Current as TRegistro_ItensExpedicao).Id_itemstr,
                                                                               null);
                if (new CamadaDados.Estoque.Cadastros.TCD_CadProduto().ProdutoComposto((bsItensExpedicao.Current as TRegistro_ItensExpedicao).Cd_produto))
                {
                    (bsItensExpedicao.Current as TRegistro_ItensExpedicao).lFicha =
                        CamadaNegocio.Estoque.Cadastros.TCN_FichaTecProduto.Buscar((bsItensExpedicao.Current as TRegistro_ItensExpedicao).Cd_produto,
                                                                                   string.Empty,
                                                                                   null);
                    tpFichaExped.Text = "FICHA TÉCNICA" + ((bsItensExpedicao.Current as TRegistro_ItensExpedicao).lFicha.Count > 0 ?
                        "(" + (bsItensExpedicao.Current as TRegistro_ItensExpedicao).lFicha.Count + ")" : string.Empty);
                }

                bsItensExpedicao.ResetCurrentItem();
            }
            else
                tpFichaExped.Text = "FICHA TÉCNICA";
        }

        private void BS_Itens_PositionChanged(object sender, EventArgs e)
        {
            if (BS_Itens.Current != null &&
                new CamadaDados.Estoque.Cadastros.TCD_CadProduto().ProdutoComposto((BS_Itens.Current as TRegistro_LanPedido_Item).Cd_produto))
            {
                (BS_Itens.Current as TRegistro_LanPedido_Item).lFicha =
                    CamadaNegocio.Estoque.Cadastros.TCN_FichaTecProduto.Buscar((BS_Itens.Current as TRegistro_LanPedido_Item).Cd_produto,
                                                                               string.Empty,
                                                                               null);
                tpFicha.Text = "FICHA TÉCNICA" + ((BS_Itens.Current as TRegistro_LanPedido_Item).lFicha.Count > 0 ?
                    "(" + (BS_Itens.Current as TRegistro_LanPedido_Item).lFicha.Count + ")" : string.Empty);
                BS_Itens.ResetCurrentItem();
            }
            else
                tpFicha.Text = "FICHA TÉCNICA";
        }
    }
}
