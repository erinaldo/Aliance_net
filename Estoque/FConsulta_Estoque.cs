using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using FormBusca;
using CamadaDados.Estoque;
using CamadaNegocio.Estoque;
using Utils;
using Financeiro;
using System.Collections.Generic;
using System.Linq;

namespace Estoque
{
    public partial class TFConsulta_Estoque : Form
    {
        private bool Altera_Relatorio = false;

        public TFConsulta_Estoque()
        {
            InitializeComponent();
            pnl_Estoque.set_FormatZero();
            pFiltro.set_FormatZero();
        }

        private void AcertarVlMedio()
        {
            using (TFLanAcertarVlMedio fVlMedio = new TFLanAcertarVlMedio())
            {
                if(fVlMedio.ShowDialog() == DialogResult.OK)
                    if(fVlMedio.rEstoque != null)
                        try
                        {
                            TCN_LanEstoque.AcertarVlMedio(fVlMedio.rEstoque, null);
                            MessageBox.Show("Valor Médio de estoque acertado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message.Trim());
                        }
            }
        }

        private void BB_Fechar_Click(object sender, EventArgs e)
        {
            Close();
        }
              
        private void bb_empresa_Click(object sender, EventArgs e)
        {
            string vColunas = "a.NM_Empresa|Empresa|350;" +
                              "a.CD_Empresa|Código|100";
            string vParamFixo = "|EXISTS|(select 1 from Tb_div_usuario_X_empresa  x where x.cd_empresa = A.cd_empresa " +
                                            "and ((x.login = '" + Parametros.pubLogin.Trim() + "') or " +
                                            "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                            "       where y.logingrp = x.login and y.loginusr = '" + Parametros.pubLogin.Trim() + "'))))";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_empresa },
                                    new CamadaDados.Diversos.TCD_CadEmpresa(), vParamFixo);
        }

        private void cd_empresa_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.CD_Empresa|=|'" + cd_empresa.Text.Trim() + "';" +
                              "|EXISTS|(select 1 from Tb_div_usuario_X_empresa  x where x.cd_empresa = A.cd_empresa " +
                                            "and ((x.login = '" + Parametros.pubLogin.Trim() + "') or " +
                                            "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                            "       where y.logingrp = x.login and y.loginusr = '" + Parametros.pubLogin.Trim() + "'))))";
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { cd_empresa },
                                    new CamadaDados.Diversos.TCD_CadEmpresa());
        }

        private void btn_produto_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BuscaProduto(new Componentes.EditDefault[] { CD_Produto}, "isnull(e.st_composto, 'N')|<>|'S'");
        }

        private void CD_Produto_Leave(object sender, EventArgs e)
        {
            string vColunas = "isnull(e.st_composto, 'N')|<>|'S';" +
                              "||(a.cd_produto = '" + CD_Produto.Text.Trim() + "') or " +
                              "(exists(select 1 from tb_est_codbarra x " +
                              "         where x.cd_produto = a.cd_produto " +
                              "         and x.cd_codbarra = '" + CD_Produto.Text.Trim() + "'))";
            UtilPesquisa.EDIT_LEAVEProduto(vColunas, new Componentes.EditDefault[] { CD_Produto},
                                    new CamadaDados.Estoque.Cadastros.TCD_CadProduto());
        }

        private void btn_local_Click(object sender, EventArgs e)
        {
            string vColunas = "a.DS_Local|Local|350;" +
                  "a.CD_Local|Código|100";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { CD_Local },
                                    new CamadaDados.Estoque.Cadastros.TCD_CadLocalArm(), "");
        }

        private void CD_Local_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.CD_Local|=|'" + CD_Local.Text.Trim() + "'";
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { CD_Local },
                                    new CamadaDados.Estoque.Cadastros.TCD_CadLocalArm());
        }

        private void BB_Buscar_Click(object sender, EventArgs e)
        {
            Busca();
        }

        private void Busca()
        {
            if(tcConsulta.SelectedTab.Equals(tpAnalitico))
            {
                string auxtpmov = string.Empty;
                string virg = string.Empty;
                if(st_entrada.Checked)
                {
                    auxtpmov = "'E'";
                    virg = ",";
                }
                if(st_saida.Checked)
                {
                    auxtpmov += virg = "'S'";
                    virg = ",";
                }
                string auxtplancto = string.Empty;
                virg = string.Empty;
                if(cck_Normal.Checked)
                {
                    auxtplancto = "'N'";
                    virg = ",";
                }
                if(cck_Provisao.Checked)
                {
                    auxtplancto += virg + "'P'";
                    virg = ",";
                }
                if(cck_Manual.Checked)
                {
                    auxtplancto += virg + "'M'";
                    virg = ",";
                }
                if(cck_Inventario.Checked)
                {
                    auxtplancto += virg + "'I'";
                    virg = ",";
                }
                if (cck_Transferencia.Checked)
                {
                    auxtplancto += virg + "'T'";
                    virg = ",";
                }
                if (cbCompDev.Checked)
                {
                    auxtplancto += virg + "'L'";
                    virg = ",";
                }
                string auxstatus = string.Empty;
                if (st_ativo.Checked)
                {
                    auxstatus = "'A'";
                    virg = ",";
                }
                if (st_cancelado.Checked)
                    auxstatus += virg + "'C'";
                TList_RegLanEstoque lista = TCN_LanEstoque.Busca(cd_empresa.Text, 
                                                                 CD_Produto.Text, 
                                                                 cd_grupo.Text,
                                                                 tp_produto.Text,
                                                                 cd_marca.Text,
                                                                 id_lanctoestoque.Text, 
                                                                 CD_Local.Text, 
                                                                 string.Empty, 
                                                                 auxtpmov, 
                                                                 auxtplancto, 
                                                                 DT_Inicial.Text, 
                                                                 DT_Final.Text, 
                                                                 auxstatus, 
                                                                 string.Empty, 
                                                                 string.Empty,
                                                                 id_variedade.Text,
                                                                 0, 
                                                                 string.Empty,
                                                                 null);
                if ((lista != null) && (lista.Count > 0))
                    BS_Estoque.DataSource = lista;
                else
                    BS_Estoque.Clear();
            }
            else if (tcConsulta.SelectedTab.Equals(tpSintetico))
            {
                TpBusca[] filtro = new TpBusca[0];
                if (cd_empresa.Text.Trim() != string.Empty)
                {
                    Array.Resize(ref filtro, filtro.Length + 1);
                    filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                    filtro[filtro.Length - 1].vOperador = "=";
                    filtro[filtro.Length - 1].vVL_Busca = "'" + cd_empresa.Text.Trim() + "'";
                }
                if (CD_Produto.Text.Trim() != string.Empty)
                {
                    Array.Resize(ref filtro, filtro.Length + 1);
                    filtro[filtro.Length - 1].vNM_Campo = "a.cd_produto";
                    filtro[filtro.Length - 1].vOperador = "=";
                    filtro[filtro.Length - 1].vVL_Busca = "'" + CD_Produto.Text.Trim() + "'";
                }
                if (cd_grupo.Text.Trim() != string.Empty)
                {
                    Array.Resize(ref filtro, filtro.Length + 1);
                    filtro[filtro.Length - 1].vNM_Campo = "b.cd_grupo";
                    filtro[filtro.Length - 1].vOperador = "like";
                    filtro[filtro.Length - 1].vVL_Busca = "'" + cd_grupo.Text.Trim() + "%'";
                }
                if (tp_produto.Text.Trim() != string.Empty)
                {
                    Array.Resize(ref filtro, filtro.Length + 1);
                    filtro[filtro.Length - 1].vNM_Campo = "b.tp_produto";
                    filtro[filtro.Length - 1].vOperador = "=";
                    filtro[filtro.Length - 1].vVL_Busca = "'" + tp_produto.Text.Trim() + "'";
                }
                if (cd_marca.Text.Trim() != string.Empty)
                {
                    Array.Resize(ref filtro, filtro.Length + 1);
                    filtro[filtro.Length - 1].vNM_Campo = "b.cd_marca";
                    filtro[filtro.Length - 1].vOperador = "=";
                    filtro[filtro.Length - 1].vVL_Busca = cd_marca.Text;
                }
                if (cbProdSaldoMinimo.Checked)
                {
                    Array.Resize(ref filtro, filtro.Length + 1);
                    filtro[filtro.Length - 1].vNM_Campo = string.Empty;
                    filtro[filtro.Length - 1].vOperador = "exists";
                    filtro[filtro.Length - 1].vVL_Busca = "(select 1 from TB_EST_Produto_QTDEstoque x " +
                                                          "where x.cd_produto = a.cd_produto " +
                                                          "and x.cd_empresa = a.cd_empresa " +
                                                          "and x.qt_min_estoque > a.tot_saldo) ";
                }
                if (cbItensSaldo.Checked)
                {
                    Array.Resize(ref filtro, filtro.Length + 1);
                    filtro[filtro.Length - 1].vNM_Campo = "a.Tot_Saldo";
                    filtro[filtro.Length - 1].vOperador = ">";
                    filtro[filtro.Length - 1].vVL_Busca = "0";
                }
                DataTable tb = new TCD_LanEstoque().BuscarEstoqueSintetico(filtro, string.Empty, "b.ds_produto");
                tb.Columns.Add(new DataColumn("saldo_futuro", typeof(decimal), "Tot_Saldo - Qtd_reservada"));
                bsSintetico.DataSource = tb;
                bsSintetico_PositionChanged(this, new EventArgs());
                //Buscar custo total do estoque
                tot_estoque.Text = TCN_LanEstoque.CustoTotalEstoque(string.IsNullOrEmpty(cd_empresa.Text) ? string.Empty : "'" + cd_empresa.Text.Trim() + "'", null).ToString("N2", new System.Globalization.CultureInfo("pt-BR", true));
            }
        }

        private void LimpaCampos()
        {
            DT_Inicial.Clear();
            DT_Final.Clear();
            id_lanctoestoque.Clear();
            cd_empresa.Clear();
            CD_Produto.Clear();
            CD_Local.Clear();
        }

        private void BB_Excluir_Click(object sender, EventArgs e)
        {
            if(BS_Estoque.Current != null)
                if ((BS_Estoque.Current as TRegistro_LanEstoque).St_registro_Bool != true)
                {
                    if (!(BS_Estoque.Current as TRegistro_LanEstoque).Tp_lancto.Trim().ToUpper().Equals("M"))
                    {
                        MessageBox.Show("Permitido cancelar somente lançamento de estoque MANUAL.\r\n" +
                                        "Os outros tipo de movimentação de estoque deve ser cancelado no processo que os gerou.",
                                        "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    if (MessageBox.Show("Deseja Cancelar o Estoque?", "Mensagem",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) ==
                        System.Windows.Forms.DialogResult.Yes)
                    {
                        TCN_LanEstoque.DeletarEstoque((BS_Estoque.Current as TRegistro_LanEstoque), null);
                        Busca();
                    }
                }
                else
                    MessageBox.Show("Este Registro já foi Cancelado!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
        }

        private void BB_Novo_Click(object sender, EventArgs e)
        {
            using (TFLanEstoque Lan_Estoque = new TFLanEstoque())
            {
                Lan_Estoque.BS_Lan_Estoque.AddNew();
                (Lan_Estoque.BS_Lan_Estoque.Current as TRegistro_LanEstoque).Tp_lancto = "M";
                if (Lan_Estoque.ShowDialog() == DialogResult.OK)
                {
                    if(new CamadaDados.Estoque.Cadastros.TCD_CadProduto().ProdutoRegAnvisa((Lan_Estoque.BS_Lan_Estoque.Current as TRegistro_LanEstoque).Cd_produto))
                        using (Proc_Commoditties.TFLoteAnvisa fLote = new Proc_Commoditties.TFLoteAnvisa())
                        {
                            fLote.pCd_empresa = (Lan_Estoque.BS_Lan_Estoque.Current as TRegistro_LanEstoque).Cd_empresa;
                            fLote.pNm_empresa = (Lan_Estoque.BS_Lan_Estoque.Current as TRegistro_LanEstoque).Nm_empresa;
                            fLote.pCd_produto = (Lan_Estoque.BS_Lan_Estoque.Current as TRegistro_LanEstoque).Cd_produto;
                            fLote.pDs_produto = (Lan_Estoque.BS_Lan_Estoque.Current as TRegistro_LanEstoque).Ds_produto;
                            fLote.pQtd_movimentar = (Lan_Estoque.BS_Lan_Estoque.Current as TRegistro_LanEstoque).Tp_movimento.Trim().ToUpper().Equals("E") ?
                                (Lan_Estoque.BS_Lan_Estoque.Current as TRegistro_LanEstoque).Qtd_entrada : (Lan_Estoque.BS_Lan_Estoque.Current as TRegistro_LanEstoque).Qtd_saida;
                            fLote.pTp_mov = (Lan_Estoque.BS_Lan_Estoque.Current as TRegistro_LanEstoque).Tp_movimento;
                            if (fLote.ShowDialog() == DialogResult.OK)
                                if (fLote.lMov != null)
                                    fLote.lMov.ForEach(p => (Lan_Estoque.BS_Lan_Estoque.Current as TRegistro_LanEstoque).lMovLoteAnvisa.Add(p));
                        }
                    try
                    {
                        if (!string.IsNullOrEmpty(TCN_LanEstoque.GravarEstoque((Lan_Estoque.BS_Lan_Estoque.Current as TRegistro_LanEstoque), null)))
                        {
                            MessageBox.Show("Lançamento estoque gravado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LimpaCampos();
                            id_lanctoestoque.Text = (Lan_Estoque.BS_Lan_Estoque.Current as TRegistro_LanEstoque).Id_lanctoestoque.ToString();
                            if (tcConsulta.SelectedTab.Equals(tpSintetico))
                                tcConsulta.SelectedTab = tpAnalitico;
                            Busca();
                        }
                        else MessageBox.Show("Lançamento de estoque não foi gravado.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
            }
            Busca();
        }

        private void TFConsulta_Estoque_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode.Equals(Keys.F2)) && (BB_Novo.Visible))
                BB_Novo_Click(sender, e);
            else if ((e.KeyCode.Equals(Keys.F5)) && (bb_excluir.Visible))
                BB_Excluir_Click(sender, e);
            else if ((e.KeyCode.Equals(Keys.F7)) && (BB_Buscar.Visible))
                Busca();
            else if (e.Control && e.KeyCode.Equals(Keys.P))
            {
                MessageBox.Show("Execute o Relatório que deseja alterar!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Altera_Relatorio = true;
            }
            else if (e.KeyCode.Equals(Keys.F9) && bb_acertarvlmedio.Visible)
                AcertarVlMedio();
        }

        private void gEstoque_DoubleClick(object sender, EventArgs e)
        {
            if (BS_Estoque.Current != null)
            {
                TFRastrearLancamentos fRastrear = new TFRastrearLancamentos();
                try
                {
                    fRastrear.BS_Estoque.Add(BS_Estoque.Current as TRegistro_LanEstoque);
                    fRastrear.TRastrear = TP_Rastrear.tm_estoque;
                    fRastrear.ShowDialog();
                }
                finally
                {
                    fRastrear.Dispose();
                }
            }
        }

        private void TFConsulta_Estoque_Load(object sender, EventArgs e)
        {
            ShapeGrid.RestoreShape(this, gEstoque);
            ShapeGrid.RestoreShape(this, dataGridDefault1);
            ShapeGrid.RestoreShape(this, gSintetico);
            Icon = ResourcesUtils.TecnoAliance_ICO;
            //Validar botao lancamento manual
            BB_Novo.Visible = (CamadaNegocio.Diversos.TCN_Usuario_RegraEspecial.ValidaRegra(Parametros.pubLogin.Trim(), "PERMITIR LANÇAMENTO MANUAL ESTOQUE", null));
            //Validar botao cancelar estoque
            bb_excluir.Visible = (CamadaNegocio.Diversos.TCN_Usuario_RegraEspecial.ValidaRegra(Parametros.pubLogin.Trim(), "PERMITIR CANCELAR LANÇAMENTO ESTOQUE", null));
            //Validar botao acertar valor medio de estoque
            bb_acertarvlmedio.Visible = (CamadaNegocio.Diversos.TCN_Usuario_RegraEspecial.ValidaRegra(Parametros.pubLogin.Trim(), "PERMITIR ACERTO VALOR MEDIO ESTOQUE", null));
            //Validar cadastro de série
            bb_serie.Visible = (CamadaNegocio.Diversos.TCN_Usuario_RegraEspecial.ValidaRegra(Parametros.pubLogin.Trim(), "PERMITIR CADASTRAR NUMERO DE SERIE", null));
        }

        private void gEstoque_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null)
                if (e.ColumnIndex == 0)
                {
                    if (e.Value.ToString().Trim().ToUpper().Equals("TRUE"))
                    {
                        DataGridViewRow linha = gEstoque.Rows[e.RowIndex];
                        linha.DefaultCellStyle.ForeColor = Color.Red;
                    }
                    else
                    {
                        DataGridViewRow linha = gEstoque.Rows[e.RowIndex];
                        linha.DefaultCellStyle.ForeColor = Color.Black;
                    }
                }
        }

        private void BB_Imprimir_Click(object sender, EventArgs e)
        {
            ImprimeRelatorio();
        }

        private void ImprimeRelatorio()
        {
            if ((tcConsulta.SelectedTab.Equals(tpAnalitico) && (BS_Estoque.Current != null)) ||
                 (tcConsulta.SelectedTab.Equals(tpSintetico) && (bsSintetico.Current != null)))
            {
                using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
                {
                    string CK_INVENTARIO = string.Empty;
                    string CK_MANUAL = string.Empty;
                    string CK_NORMAL = string.Empty;
                    string CK_PROVISAO = string.Empty;
                    string CK_TODOS = string.Empty;
                    string CK_TRANSFERENCIA = string.Empty;
                    string ST_REGISTRO = string.Empty;
                    string CD_LOCAL = string.Empty;
                    string DS_LOCAL = string.Empty;

                    if (cck_Inventario.Checked)
                    { CK_INVENTARIO = "SIM"; }
                    else { CK_INVENTARIO = "NÃO"; }
                    if (cck_Manual.Checked)
                    { CK_MANUAL = "SIM"; }
                    else { CK_MANUAL = "NÃO"; }
                    if (cck_Normal.Checked)
                    { CK_NORMAL = "SIM"; }
                    else { CK_NORMAL = "NÃO"; }
                    if (cck_Provisao.Checked)
                    { CK_PROVISAO = "SIM"; }
                    else { CK_PROVISAO = "NÃO"; }
                    if (cck_Transferencia.Checked)
                    { CK_TRANSFERENCIA = "SIM"; }
                    else { CK_TRANSFERENCIA = "NÃO"; }
                    if (!string.IsNullOrEmpty(CD_Local.Text))
                        CD_LOCAL = CD_Local.Text;

                    FormRelPadrao.Relatorio Relatorio = new FormRelPadrao.Relatorio();
                    Relatorio.Altera_Relatorio = Altera_Relatorio;
                    if (tcConsulta.SelectedTab.Equals(tpAnalitico))
                    {
                        Relatorio.Ident = "TFConsulta_Estoque_Analitico";
                        Relatorio.DTS_Relatorio = BS_Estoque;
                    }
                    if (tcConsulta.SelectedTab.Equals(tpSintetico))
                    {
                        Relatorio.Ident = "TFConsulta_Estoque";
                        Relatorio.DTS_Relatorio = bsSintetico;
                    }
                    Relatorio.Parametros_Relatorio.Add("DT_FINAL", DT_Final.Data);
                    Relatorio.Parametros_Relatorio.Add("DT_INICIO", DT_Inicial.Data);
                    Relatorio.Parametros_Relatorio.Add("INVENTARIO", CK_INVENTARIO);
                    Relatorio.Parametros_Relatorio.Add("MANUAL", CK_MANUAL);
                    Relatorio.Parametros_Relatorio.Add("NORMAL", CK_NORMAL);
                    Relatorio.Parametros_Relatorio.Add("PROVISAO", CK_PROVISAO);
                    Relatorio.Parametros_Relatorio.Add("TODOS", CK_TODOS);
                    Relatorio.Parametros_Relatorio.Add("TRANSFERENCIA", CK_TRANSFERENCIA);
                    Relatorio.Parametros_Relatorio.Add("STREGISTRO", ST_REGISTRO);
                    Relatorio.Parametros_Relatorio.Add("CD_LOCAL", CD_LOCAL);
                    Relatorio.Parametros_Relatorio.Add("DS_LOCAL", DS_LOCAL);
                    Relatorio.NM_Classe = Name;
                    Relatorio.Modulo = Tag.ToString().Substring(0, 3);
                    fImp.St_enabled_enviaremail = true;
                    fImp.pCd_clifor = string.Empty;
                    fImp.pMensagem = "RELATORIO " + Text.Trim();

                    if (Altera_Relatorio)
                    {
                        Relatorio.Gera_Relatorio(string.Empty,
                                                 fImp.pSt_imprimir,
                                                 fImp.pSt_visualizar,
                                                 fImp.pSt_enviaremail,
                                                 fImp.pSt_exportPdf,
                                                 fImp.Path_exportPdf,
                                                 fImp.pDestinatarios,
                                                 null,
                                                 "RELATORIO " + Text.Trim(),
                                                 fImp.pDs_mensagem);
                        Altera_Relatorio = false;
                    }
                    else
                        if ((fImp.ShowDialog() == DialogResult.OK) || (fImp.pSt_enviaremail))
                            Relatorio.Gera_Relatorio(string.Empty,
                                                     fImp.pSt_imprimir,
                                                     fImp.pSt_visualizar,
                                                     fImp.pSt_enviaremail,
                                                     fImp.pSt_exportPdf,
                                                     fImp.Path_exportPdf,
                                                     fImp.pDestinatarios,
                                                     null,
                                                     "RELATORIO " + Text.Trim(),
                                                     fImp.pDs_mensagem);
                }
            }
            else { MessageBox.Show("Não Existe Registro Para ser Impresso No Relatório!"); }            
        }

        private void tmRelEstoque_Click(object sender, EventArgs e)
        {
            ImprimeRelatorio();
        }

        private void cbProdSaldoMinimo_EnabledChanged(object sender, EventArgs e)
        {
            if (!cbProdSaldoMinimo.Enabled)
                cbProdSaldoMinimo.Checked = false;
        }

        private void bb_grupo_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_grupo|Grupo Produto|200;" +
                              "a.cd_grupo|Cd. Grupo|80";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_grupo },
                new CamadaDados.Estoque.Cadastros.TCD_CadGrupoProduto(), string.Empty);
        }

        private void cd_grupo_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_grupo|=|'" + cd_grupo.Text.Trim() + "'";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_grupo },
                new CamadaDados.Estoque.Cadastros.TCD_CadGrupoProduto());
        }

        private void bb_tpproduto_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_tpproduto|Tipo Produto|200;" +
                              "a.tp_produto|TP. Produto|80";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { tp_produto },
                new CamadaDados.Estoque.Cadastros.TCD_CadTpProduto(), "isnull(a.st_composto, 'N')|<>|'S'");
        }

        private void tp_produto_Leave(object sender, EventArgs e)
        {
            string vParam = "a.tp_produto|=|'" + tp_produto.Text.Trim() + "';" +
                            "isnull(a.st_composto, 'N')|<>|'S'";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { tp_produto },
                new CamadaDados.Estoque.Cadastros.TCD_CadTpProduto());
        }

        private void bb_marca_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_marca|Marca Produto|200;" +
                              "a.cd_marca|Cd. Marca|80";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_marca },
                new CamadaDados.Estoque.Cadastros.TCD_CadMarca(), string.Empty);
        }

        private void cd_marca_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_marca|=|" + cd_marca.Text;
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_marca },
                new CamadaDados.Estoque.Cadastros.TCD_CadMarca());
        }

        private void bb_acertarvlmedio_Click(object sender, EventArgs e)
        {
            AcertarVlMedio();
        }

        private void bsSintetico_PositionChanged(object sender, EventArgs e)
        {
            if (bsSintetico.Current != null)
            {
                //Buscar Saldo Local
                bsSaldoLocal.DataSource = TCN_ConsultaProdutos.buscaLocal(
                    (bsSintetico.Current as DataRowView)["cd_empresa"].ToString(),
                    (bsSintetico.Current as DataRowView)["cd_produto"].ToString());
                bsSaldoLocal.ResetBindings(true);
                //Buscar Saldo Variedade
                bsSaldoVariedade.DataSource = TCN_ConsultaProdutos.BuscarVariedade(
                    (bsSintetico.Current as DataRowView)["cd_empresa"].ToString(),
                    (bsSintetico.Current as DataRowView)["cd_produto"].ToString());
                bsSaldoVariedade.ResetBindings(true);
                //Saldo Grade
                bsGrade.DataSource = new TCD_GradeEstoque().Select((bsSintetico.Current as DataRowView)["cd_empresa"].ToString(),
                                                                   (bsSintetico.Current as DataRowView)["cd_produto"].ToString(),
                                                                   true);
                bsGrade.ResetBindings(true);
                tot_grade.Text = (bsGrade.List as List<TRegistro_SaldoGrade>).Sum(p => p.Saldo).ToString("N0", new System.Globalization.CultureInfo("pt-BR", true));
            }
            else
            {
                bsSaldoLocal.Clear();
                bsSaldoVariedade.Clear();
                bsGrade.Clear();
            }
        }

        private void TFConsulta_Estoque_FormClosing(object sender, FormClosingEventArgs e)
        {
            ShapeGrid.SaveShape(this, gEstoque);
            ShapeGrid.SaveShape(this, dataGridDefault1);
            ShapeGrid.SaveShape(this, gSintetico);
        }

        private void id_variedade_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(CD_Produto.Text))
            {
                string vParam = "a.id_variedade|=|" + id_variedade.Text + ";" +
                                "a.cd_produto|=|'" + CD_Produto.Text.Trim() + "'";
                UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { id_variedade },
                    new CamadaDados.Estoque.Cadastros.TCD_Variedade());
            }
        }

        private void bb_variedade_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(CD_Produto.Text))
            {
                string vColunas = "a.ds_variedade|Variedade|200;" +
                                  "a.id_variedade|Código|50";
                string vParam = "a.cd_produto|=|'" + CD_Produto.Text.Trim() + "'";
                UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[]{id_variedade}, 
                    new CamadaDados.Estoque.Cadastros.TCD_Variedade(), vParam);
            }
        }

        private void bbImpSaldoVar_Click(object sender, EventArgs e)
        {
            if(bsSaldoVariedade.Count > 0)
                using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
                {
                    FormRelPadrao.Relatorio Relatorio = new FormRelPadrao.Relatorio();
                    Relatorio.Altera_Relatorio = Altera_Relatorio;
                    Relatorio.Ident = "REL_EST_SALDOVARIEDADE";
                    Relatorio.DTS_Relatorio = bsSaldoVariedade;
                    Relatorio.NM_Classe = Name;
                    Relatorio.Modulo = Tag.ToString().Substring(0, 3);
                    fImp.St_enabled_enviaremail = true;
                    fImp.pCd_clifor = string.Empty;
                    fImp.pMensagem = "RELATORIO SALDO ESTOQUE POR VARIEDADE";

                    if (Altera_Relatorio)
                    {
                        Relatorio.Gera_Relatorio(string.Empty,
                                                 fImp.pSt_imprimir,
                                                 fImp.pSt_visualizar,
                                                 fImp.pSt_enviaremail,
                                                 fImp.pSt_exportPdf,
                                                 fImp.Path_exportPdf,
                                                 fImp.pDestinatarios,
                                                 null,
                                                 "RELATORIO SALDO ESTOQUE POR VARIEDADE",
                                                 fImp.pDs_mensagem);
                        Altera_Relatorio = false;
                    }
                    else
                        if ((fImp.ShowDialog() == DialogResult.OK) || (fImp.pSt_enviaremail))
                            Relatorio.Gera_Relatorio(string.Empty,
                                                     fImp.pSt_imprimir,
                                                     fImp.pSt_visualizar,
                                                     fImp.pSt_enviaremail,
                                                     fImp.pSt_exportPdf,
                                                     fImp.Path_exportPdf,
                                                     fImp.pDestinatarios,
                                                     null,
                                                     "RELATORIO SALDO ESTOQUE POR VARIEDADE",
                                                     fImp.pDs_mensagem);
                }
        }

        private void bbImpSaldoLocal_Click(object sender, EventArgs e)
        {
            if (bsSaldoLocal.Count > 0)
                using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
                {
                    FormRelPadrao.Relatorio Relatorio = new FormRelPadrao.Relatorio();
                    Relatorio.Altera_Relatorio = Altera_Relatorio;
                    Relatorio.Ident = "REL_EST_SALDOLOCAL";
                    Relatorio.DTS_Relatorio = bsSaldoLocal;
                    Relatorio.NM_Classe = Name;
                    Relatorio.Modulo = Tag.ToString().Substring(0, 3);
                    fImp.St_enabled_enviaremail = true;
                    fImp.pCd_clifor = string.Empty;
                    fImp.pMensagem = "RELATORIO SALDO ESTOQUE POR LOCAL ARMAZENAGEM";

                    if (Altera_Relatorio)
                    {
                        Relatorio.Gera_Relatorio(string.Empty,
                                                 fImp.pSt_imprimir,
                                                 fImp.pSt_visualizar,
                                                 fImp.pSt_enviaremail,
                                                 fImp.pSt_exportPdf,
                                                 fImp.Path_exportPdf,
                                                 fImp.pDestinatarios,
                                                 null,
                                                 "RELATORIO SALDO ESTOQUE POR LOCAL ARMAZENAGEM",
                                                 fImp.pDs_mensagem);
                        Altera_Relatorio = false;
                    }
                    else
                        if ((fImp.ShowDialog() == DialogResult.OK) || (fImp.pSt_enviaremail))
                            Relatorio.Gera_Relatorio(string.Empty,
                                                     fImp.pSt_imprimir,
                                                     fImp.pSt_visualizar,
                                                     fImp.pSt_enviaremail,
                                                     fImp.pSt_exportPdf,
                                                     fImp.Path_exportPdf,
                                                     fImp.pDestinatarios,
                                                     null,
                                                     "RELATORIO SALDO ESTOQUE POR LOCAL ARMAZENAGEM",
                                                     fImp.pDs_mensagem);
                }
        }

        private void bb_serie_Click(object sender, EventArgs e)
        {
            if (bsSintetico.Current != null)
                using (Producao.TFSerieProduto fSerie = new Producao.TFSerieProduto())
                {
                    fSerie.st_cadastroavulso = true;
                    fSerie.pCd_empresa = (bsSintetico.Current as DataRowView)["cd_empresa"].ToString();
                    fSerie.pCd_produto = (bsSintetico.Current as DataRowView)["cd_produto"].ToString();
                    fSerie.pDs_produto = (bsSintetico.Current as DataRowView)["ds_produto"].ToString();
                    if (fSerie.ShowDialog() == DialogResult.OK)
                    {
                        if (fSerie.lSerie != null)
                            if (fSerie.lSerie.Count > 0)
                                try
                                {
                                    fSerie.lSerie.FindAll(p => !string.IsNullOrEmpty(p.Nr_serie.Trim())).ForEach(p =>
                                     {
                                         p.St_registro = "P";
                                         CamadaNegocio.Producao.Producao.TCN_SerieProduto.Gravar(p, null);
                                     });
                                    MessageBox.Show("Nº Série gravados com sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    using (TFLanEstoque Lan_Estoque = new TFLanEstoque())
                                    {
                                        Lan_Estoque.BS_Lan_Estoque.AddNew();
                                        (Lan_Estoque.BS_Lan_Estoque.Current as TRegistro_LanEstoque).Tp_lancto = "M";
                                        (Lan_Estoque.BS_Lan_Estoque.Current as TRegistro_LanEstoque).Cd_empresa = (bsSintetico.Current as DataRowView)["cd_empresa"].ToString();
                                        (Lan_Estoque.BS_Lan_Estoque.Current as TRegistro_LanEstoque).Nm_empresa = (bsSintetico.Current as DataRowView)["nm_empresa"].ToString();
                                        (Lan_Estoque.BS_Lan_Estoque.Current as TRegistro_LanEstoque).Cd_produto = (bsSintetico.Current as DataRowView)["cd_produto"].ToString();
                                        (Lan_Estoque.BS_Lan_Estoque.Current as TRegistro_LanEstoque).Ds_produto = (bsSintetico.Current as DataRowView)["ds_produto"].ToString();
                                        (Lan_Estoque.BS_Lan_Estoque.Current as TRegistro_LanEstoque).Tp_movimento = "E";
                                        (Lan_Estoque.BS_Lan_Estoque.Current as TRegistro_LanEstoque).Qtd_entrada = fSerie.lSerie.Count;
                                        if (Lan_Estoque.ShowDialog() == DialogResult.OK)
                                        {
                                            try
                                            {
                                                TCN_LanEstoque.GravarEstoque((Lan_Estoque.BS_Lan_Estoque.Current as TRegistro_LanEstoque), null);
                                                MessageBox.Show("Lançamento estoque gravado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                Busca();
                                            }
                                            catch (Exception ex)
                                            { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                                        }
                                    }
                                }
                                catch (Exception ex)
                                { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    }
                    else
                    {
                        MessageBox.Show("Obrigatório informar Nº Série!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
            else MessageBox.Show("Obrigatório selecionar produto para cadastrar numero série.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void bbAjustarGrade_Click(object sender, EventArgs e)
        {
            if (bsSintetico.Current != null)
            {
                if (new CamadaDados.Estoque.Cadastros.TCD_CadProduto().BuscarEscalar(
                    new TpBusca[]
                    {
                        new TpBusca()
                        {
                            vNM_Campo = "a.cd_produto",
                            vOperador = "=",
                            vVL_Busca = "'" + (bsSintetico.Current as DataRowView)["cd_produto"].ToString().Trim() + "'"
                        },
                        new TpBusca()
                        {
                            vNM_Campo = "a.id_caracteristicaH",
                            vOperador = "is not",
                            vVL_Busca = "null"
                        }
                    }, "1") != null)
                {
                    //Buscar lançamentos de estoque que não estejam amarrados a grade
                    TList_RegLanEstoque lEst = new TCD_LanEstoque().Select(
                                                new TpBusca[]
                                                {
                                                    new TpBusca()
                                                    {
                                                        vNM_Campo = "isnull(a.st_registro, 'A')",
                                                        vOperador = "<>",
                                                        vVL_Busca = "'C'"
                                                    },
                                                    new TpBusca()
                                                    {
                                                        vNM_Campo = "a.cd_produto",
                                                        vOperador = "=",
                                                        vVL_Busca = "'" + (bsSintetico.Current as DataRowView)["cd_produto"].ToString().Trim() + "'"
                                                    },new TpBusca()
                                                    {
                                                        vOperador = " not Exists",
                                                        vVL_Busca = "( select 1 from TB_EST_GradeEstoque x where x.Id_LanctoEstoque = a.Id_LanctoEstoque   )"

                                                    }
                                                }, 0, string.Empty, string.Empty, string.Empty);
                    if (lEst.Count > 0)
                    {
                        lEst.ForEach(x =>
                        {
                            using (Proc_Commoditties.TFGradeProduto fGrade = new Proc_Commoditties.TFGradeProduto())
                            {
                                CamadaDados.Estoque.Cadastros.TRegistro_CadProduto prod = new CamadaDados.Estoque.Cadastros.TRegistro_CadProduto();
                                prod = CamadaNegocio.Estoque.Cadastros.TCN_CadProduto.Busca_Produto_Codigo((bsSintetico.Current as DataRowView)["cd_produto"].ToString(), null);

                                fGrade.pId_caracteristica = prod.Id_caracteristicaH.ToString();
                                fGrade.pCd_empresa = (bsSintetico.Current as DataRowView)["cd_empresa"].ToString();
                                fGrade.pCd_produto = (bsSintetico.Current as DataRowView)["cd_produto"].ToString();
                                fGrade.pDs_produto = (bsSintetico.Current as DataRowView)["ds_produto"].ToString();
                                fGrade.pTp_movimento = x.Tp_movimento;
                                fGrade.pQuantidade = x.Tp_movimento.ToString().Trim().ToUpper().Equals("E") ? x.Qtd_entrada : x.Qtd_saida;
                                if (fGrade.ShowDialog() == DialogResult.OK)
                                {
                                    fGrade.lGrade.ForEach(p =>
                                    {
                                        TCN_GradeEstoque.Gravar(new TRegistro_GradeEstoque()
                                        {
                                            Cd_empresa = (bsSintetico.Current as DataRowView)["cd_empresa"].ToString(),
                                            Cd_produto = (bsSintetico.Current as DataRowView)["cd_produto"].ToString(),
                                            Id_lanctoestoque = x.Id_lanctoestoque,
                                            Id_item = p.Id_item,
                                            Id_caracteristica = p.Id_caracteristica,
                                            quantidade = p.Vl_mov
                                        }, null);
                                    });
                                    bsSintetico_PositionChanged(this, new EventArgs());
                                }
                                else
                                {
                                    MessageBox.Show("Obrigatório informar grade.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    return;
                                }
                            }
                        });
                    }
                }
            }
        }
    }
}
