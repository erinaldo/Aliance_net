using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Producao
{
    public partial class TFLanRastreabilidadeProduto : Form
    {
        private bool Altera_Relatorio = false;
        private bool St_alterar
        { get; set; }

        private void LimparCampos()
        {
            Nr_serie.Text = string.Empty;
            cd_empresa.Text = string.Empty;
            cd_produto.Text = string.Empty;
        }
        public TFLanRastreabilidadeProduto()
        {
            InitializeComponent();
        }

        private void afterBusca()
        {
            bsSerieProduto.DataSource =
                CamadaNegocio.Producao.Producao.TCN_SerieProduto.Buscar(Nr_serie.Text,
                                                                        cd_empresa.Text,
                                                                        cd_produto.Text,
                                                                        string.Empty,
                                                                        null);
            bsSerieProduto.ResetCurrentItem();
            bsSerieProduto_PositionChanged(this, new EventArgs());
        }

        private void afterExclui()
        {
            if (bsSerieProduto.Current != null)
            {
                if (!string.IsNullOrEmpty((bsSerieProduto.Current as CamadaDados.Producao.Producao.TRegistro_SerieProduto).Id_ordemstr))
                {
                    MessageBox.Show("Não é possível excluir Nº Série gerado pela Produção!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (new CamadaDados.Faturamento.Pedido.TCD_ItensExpedicao().BuscarEscalar(
                        new Utils.TpBusca[]
                        {
                            new Utils.TpBusca()
                            {
                                vNM_Campo = "a.id_serie",
                                vOperador = "=",
                                vVL_Busca = (bsSerieProduto.Current as CamadaDados.Producao.Producao.TRegistro_SerieProduto).Id_seriestr
                            }
                        }, "1") != null)
                {
                    MessageBox.Show("Não é possível excluir Nº Série alocado a uma expedição!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (MessageBox.Show("Confirma a exclusão do Nº Série:" + 
                    (bsSerieProduto.Current as CamadaDados.Producao.Producao.TRegistro_SerieProduto).Nr_serie + "?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                    == DialogResult.Yes)
                    try
                    {
                        CamadaNegocio.Producao.Producao.TCN_SerieProduto.Excluir(bsSerieProduto.Current as CamadaDados.Producao.Producao.TRegistro_SerieProduto, null);
                        this.LimparCampos();
                        this.afterBusca();

                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void afterPrint()
        {
            if (bsSerieProduto.Current != null)
            {
                using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
                {
                    FormRelPadrao.Relatorio Rel = new FormRelPadrao.Relatorio();
                    Rel.Altera_Relatorio = Altera_Relatorio;
                    BindingSource bs_valor = new BindingSource();
                    bs_valor.DataSource = new CamadaDados.Producao.Producao.TList_SerieProduto() { bsSerieProduto.Current as CamadaDados.Producao.Producao.TRegistro_SerieProduto };
                    Rel.DTS_Relatorio = bs_valor;
                    Rel.Ident = this.Name;
                    Rel.NM_Classe = this.Name;
                    Rel.Modulo = "PRD";
                    fImp.St_enabled_enviaremail = true;
                    fImp.pCd_clifor = string.Empty;
                    fImp.pMensagem = "RASTREABILIDADE PRODUTO";

                    //Buscar dados Empresa
                    CamadaDados.Diversos.TList_CadEmpresa lEmpresa =
                        CamadaNegocio.Diversos.TCN_CadEmpresa.Busca((bsSerieProduto.Current as CamadaDados.Producao.Producao.TRegistro_SerieProduto).Cd_empresa,
                                                                    string.Empty,
                                                                    string.Empty,
                                                                    null);
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
                                           "RASTREABILIDADE PRODUTO",
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
                                               "RASTREABILIDADE PRODUTO",
                                               fImp.pDs_mensagem);
                }
            }
        }


        private void TFLanRastreabilidadeProduto_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pConsulta.set_FormatZero();
            //Verificar se usuario tem disponibilidade para alterar Nº Série
            St_alterar = CamadaNegocio.Diversos.TCN_Usuario_RegraEspecial.ValidaRegra(Utils.Parametros.pubLogin.Trim(), "PERMITIR CADASTRAR NUMERO DE SERIE", null);
        }

        private void TFLanRastreabilidadeProduto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F5))
                this.afterExclui();
            else if (e.KeyCode.Equals(Keys.F7))
                this.afterBusca();
            else if (e.KeyCode.Equals(Keys.F8))
                this.afterPrint();
            else if (e.Control && e.KeyCode.Equals(Keys.P))
            {
                Altera_Relatorio = true;
                MessageBox.Show("Execute o relatorio que deseja alterar.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BB_Buscar_Click(object sender, EventArgs e)
        {
            this.afterBusca();
        }

        private void cd_empresa_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LEAVE("a.cd_empresa|=|'" + cd_empresa.Text.Trim() + "';" +
                                  "|EXISTS|(select 1 from Tb_div_usuario_X_empresa  x where x.cd_empresa = A.cd_empresa " +
                                  "and((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                                  "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                  "        where y.logingrp = x.login " +
                                  "        and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))"
              , new Componentes.EditDefault[] { cd_empresa }, new CamadaDados.Diversos.TCD_CadEmpresa());
        }

        private void bb_empresa_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BUSCA("a.NM_empresa|Nome Empresa|300;a.CD_Empresa|Cód Empresa|100"
                          , new Componentes.EditDefault[] { cd_empresa }
                          , new CamadaDados.Diversos.TCD_CadEmpresa(),
                          "|EXISTS|(select 1 from Tb_div_usuario_X_empresa  x where x.cd_empresa = A.cd_empresa " +
                          "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                          "(exists(select 1 from tb_div_usuario_x_grupos y " +
                          "         where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))");
        }

        private void cd_produto_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LEAVEProduto("a.cd_produto|=|'" + cd_produto.Text.Trim() + "'",
                                                   new Componentes.EditDefault[] { cd_produto },
                                                   new CamadaDados.Estoque.Cadastros.TCD_CadProduto());
        }

        private void bb_produto_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaProduto(new Componentes.EditDefault[] { cd_produto }, string.Empty);
        }

        private void bsSerieProduto_PositionChanged(object sender, EventArgs e)
        {
            if (bsSerieProduto.Current != null)
            {
                if (!string.IsNullOrEmpty((bsSerieProduto.Current as CamadaDados.Producao.Producao.TRegistro_SerieProduto).Id_ordemstr))
                    (bsSerieProduto.Current as CamadaDados.Producao.Producao.TRegistro_SerieProduto).lMovSaida =
                        CamadaNegocio.Producao.Producao.TCN_MovRastreabilidade.Buscar(string.Empty,
                                                                                      (bsSerieProduto.Current as CamadaDados.Producao.Producao.TRegistro_SerieProduto).Cd_empresa,
                                                                                      string.Empty,
                                                                                      string.Empty,
                                                                                      string.Empty,
                                                                                      "S",
                                                                                      (bsSerieProduto.Current as CamadaDados.Producao.Producao.TRegistro_SerieProduto).Id_ordemstr,
                                                                                      null);

                (bsSerieProduto.Current as CamadaDados.Producao.Producao.TRegistro_SerieProduto).lItensExp =
                    new CamadaDados.Faturamento.Pedido.TCD_ItensExpedicao().Select(
                        new Utils.TpBusca[]
                        {
                            new Utils.TpBusca()
                            {
                                vNM_Campo = "a.id_serie",
                                vOperador = "=",
                                vVL_Busca = (bsSerieProduto.Current as CamadaDados.Producao.Producao.TRegistro_SerieProduto).Id_seriestr
                            }
                        }, 0, string.Empty);
                bsSerieProduto.ResetCurrentItem();
                bsMovSaida_PositionChanged(this, new EventArgs());
            }
        }

        private void BB_Fechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bsMovSaida_PositionChanged(object sender, EventArgs e)
        {
            if (bsMovSaida.Current != null)
            {
                (bsMovSaida.Current as CamadaDados.Producao.Producao.TRegistro_MovRastreabilidade).lNfOrigem =
                    new CamadaDados.Faturamento.NotaFiscal.TCD_LanFaturamento().Select(
                        new Utils.TpBusca[]
                        {
                            new Utils.TpBusca()
                            {
                                vNM_Campo = string.Empty,
                                vOperador = "exists",
                                vVL_Busca = "(select 1 from TB_PRD_MovRastreabilidade x " +
                                            "where a.cd_empresa = x.cd_empresa " +
                                            "and a.Nr_lanctofiscal = x.Nr_lanctofiscal " +
                                            "and x.cd_empresa = '" + (bsMovSaida.Current as CamadaDados.Producao.Producao.TRegistro_MovRastreabilidade).Cd_empresa.Trim() + "'" +
                                            "and x.id_lote = " + (bsMovSaida.Current as CamadaDados.Producao.Producao.TRegistro_MovRastreabilidade).Id_lotestr + 
                                            "and x.tp_mov = 'E' )"
                            }
                        }, 0, string.Empty);
                bsMovSaida.ResetCurrentItem();
            }
        }

        private void BB_Imprimir_Click(object sender, EventArgs e)
        {
            afterPrint();
        }

        private void btn_alterarSerie_Click(object sender, EventArgs e)
        {
            if (bsSerieProduto.Current != null)
            {
                if (!St_alterar)
                    using (Parametros.Diversos.TFRegraUsuario fRegra = new Parametros.Diversos.TFRegraUsuario())
                    {
                        fRegra.Ds_regraespecial = "PERMITIR CADASTRAR NUMERO DE SERIE";
                        fRegra.Login = Utils.Parametros.pubLogin;
                        if (fRegra.ShowDialog() == DialogResult.OK)
                            St_alterar = true;
                    }
                if (St_alterar)
                {
                    //Verificar se Nº Série já existe faturamento
                    if (new CamadaDados.Faturamento.NotaFiscal.TCD_LanFaturamento().BuscarEscalar(
                            new Utils.TpBusca[]
                            {
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = string.Empty,
                                    vOperador = "exists",
                                    vVL_Busca = "(select 1 from TB_FAT_Ordem_X_Expedicao x " +
                                                "inner join TB_FAT_ItensExpedicao y " +
                                                "on x.cd_empresa = y.cd_empresa " +
                                                "and x.id_expedicao = y.id_expedicao " +
                                                "where a.cd_empresa = x.cd_empresa " +
                                                "and a.nr_lanctofiscal = x.nr_lanctofiscal " +
                                                "and isnull(a.st_registro, 'A') <> 'C' " +
                                                "and y.id_serie = " + (bsSerieProduto.Current as CamadaDados.Producao.Producao.TRegistro_SerieProduto).Id_seriestr + ") "
                                }
                            }, "1") != null)
                    {
                        MessageBox.Show("Não é possível alterar Nº Série que possui faturamento!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    //Alterar Nº Série
                    using (Utils.InputBox ibp = new Utils.InputBox())
                    {
                        ibp.Text = "ALTERAR Nº SÉRIE";
                        string serie = ibp.ShowDialog();
                        if (!string.IsNullOrEmpty(serie))
                            try
                            {
                                //Verificar se já existe Nº Série cadastrado
                                if (new CamadaDados.Producao.Producao.TCD_SerieProduto().BuscarEscalar(
                                        new Utils.TpBusca[]
                                        {
                                            new Utils.TpBusca()
                                            {
                                                vNM_Campo = "a.Nr_serie",
                                                vOperador = "=",
                                                vVL_Busca = "'" + serie.Trim() + "'"
                                            },
                                            new Utils.TpBusca()
                                            {
                                                vNM_Campo = "isnull(a.st_registro, 'A')",
                                                vOperador = "<>",
                                                vVL_Busca = "'C'"
                                            }
                                        }, "1") != null)
                                {
                                    MessageBox.Show("Já existe Nº Série cadastrado!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    return;
                                }
                                (bsSerieProduto.Current as CamadaDados.Producao.Producao.TRegistro_SerieProduto).Nr_serie = serie;
                                CamadaNegocio.Producao.Producao.TCN_SerieProduto.Gravar(bsSerieProduto.Current as CamadaDados.Producao.Producao.TRegistro_SerieProduto, null);
                                MessageBox.Show("Nº Série alterado com sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.afterBusca();
                            }
                            catch (Exception ex)
                            { MessageBox.Show(ex.Message.Trim(),"Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);}

                    }
                }
            }
        }

        private void BB_Excluir_Click(object sender, EventArgs e)
        {
            this.afterExclui();
        }
    }
}
