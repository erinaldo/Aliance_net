using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using FormBusca;

namespace Financeiro
{
    public partial class TFQuitarFaturaCartao : Form
    {
        public string pId_Bandeira { get; set; } = string.Empty;
        public string pCd_Empresa { get; set; } = string.Empty;
        public string pCd_Contager { get; set; } = string.Empty;
        public string pDt_Processa { get; set; } = string.Empty;


        public string Cd_empresa
        { get { return CD_Empresa.Text; } set { } }
        public string Cd_contager
        { get { return cd_contager.Text; } set { } }
        public DateTime Dt_quitar
        { get { return dt_quitacao.Data; } }
        public string Tp_movimento
        { get { return rbPagar.Checked ? "P" : "R"; } }
        public List<CamadaDados.Financeiro.Cartao.TRegistro_FaturaCartao> lFat
        {
            get
            {
                if (bsFatura.Count > 0)
                    return (bsFatura.List as CamadaDados.Financeiro.Cartao.TList_FaturaCartao).FindAll(p => p.St_processar);
                else
                    return null;
            }
        }

        public TFQuitarFaturaCartao()
        {
            InitializeComponent();
        }

        private void afterBusca()
        {
            if (string.IsNullOrEmpty(CD_Empresa.Text))
            {
                MessageBox.Show("Obrigatorio informar empresa.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CD_Empresa.Focus();
                return;
            }
            bsFatura.DataSource = CamadaNegocio.Financeiro.Cartao.TCN_FaturaCartao.Buscar(string.Empty,
                                                                                          CD_Empresa.Text,
                                                                                          nr_cartao.Text,
                                                                                          id_bandeira.Text,
                                                                                          id_maquina.Text,
                                                                                          string.Empty,
                                                                                          rbDebito.Checked ? "D" : rbCredito.Checked ? "C" : string.Empty,
                                                                                          rbPagar.Checked ? "P" : "R",
                                                                                          string.Empty,
                                                                                          string.Empty,
                                                                                          cd_domiciliobancario.Text,
                                                                                          rbFatura.Checked ? "F" : string.Empty,
                                                                                          DT_Inicial.Text,
                                                                                          DT_Final.Text,
                                                                                          decimal.Zero,
                                                                                          decimal.Zero,
                                                                                          true,
                                                                                          "A",
                                                                                          "a.dt_vencto",
                                                                                          null);
            sd_quitar.Text = (bsFatura.List as CamadaDados.Financeiro.Cartao.TList_FaturaCartao).Sum(p => p.Vl_Saldoquitar).ToString("N2", new System.Globalization.CultureInfo("pt-BR"));
            dt_quitacao.Focus();
        }

        private void afterGrava()
        {
            if (pTotais.validarCampoObrigatorio())
                if (!string.IsNullOrEmpty(pDt_Processa) ? Convert.ToDateTime(pDt_Processa) < Convert.ToDateTime(dt_quitacao.Text) : false)
                {
                    MessageBox.Show("Data Quitação não pode ser maior que a data do lote!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    DialogResult = DialogResult.OK;
        }

        private void TFQuitarFaturaCartao_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, gFatura);
            Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pFiltro.set_FormatZero();
            pTotais.set_FormatZero();



            if (!string.IsNullOrEmpty(pCd_Empresa))
            {
                CD_Empresa.Text = pCd_Empresa;
                CD_Empresa.Enabled = string.IsNullOrEmpty(pCd_Empresa);
                BB_Empresa.Enabled = string.IsNullOrEmpty(pCd_Empresa);
            }
            if (!string.IsNullOrEmpty(pId_Bandeira))
            {
                id_bandeira.Text = pId_Bandeira;
                id_bandeira.Enabled = string.IsNullOrEmpty(pId_Bandeira);
                bb_bandeira.Enabled = string.IsNullOrEmpty(pId_Bandeira);
            }
            if (!string.IsNullOrEmpty(pCd_Contager))
            {
                cd_contager.Text = pCd_Contager;
                cd_contager.Enabled = string.IsNullOrEmpty(pCd_Contager);
                bb_contager.Enabled = string.IsNullOrEmpty(pCd_Contager);
                cd_contager_Leave(this, new EventArgs());
            }
        }

        private void BB_Empresa_Click(object sender, EventArgs e)
        {
            string vColunas = "a.NM_Empresa|Empresa|350;" +
                                          "a.CD_Empresa|Código|100";
            string vParam = "|EXISTS|(select 1 from tb_div_usuario_x_empresa x " +
                            "where x.cd_empresa = a.cd_empresa " +
                            "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                            "(exists(select 1 from tb_div_usuario_x_grupos y " +
                            "       where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))";
            if (!string.IsNullOrEmpty(cd_domiciliobancario.Text))
                vParam += ";|exists|(select 1 from tb_fin_contager_x_empresa " +
                          "where x.cd_empresa = a.cd_empresa " +
                          "and x.cd_contager = '" + cd_domiciliobancario.Text.Trim() + "')";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { CD_Empresa },
                                    new CamadaDados.Diversos.TCD_CadEmpresa(), string.Empty);
        }

        private void CD_Empresa_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.CD_Empresa|=|'" + CD_Empresa.Text.Trim() + "';" +
                              "|EXISTS|(select 1 from tb_div_usuario_x_empresa x " +
                              "where x.cd_empresa = a.cd_empresa " +
                              "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                              "(exists(select 1 from tb_div_usuario_x_grupos y " +
                              "         where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))";
            if (!string.IsNullOrEmpty(cd_domiciliobancario.Text))
                vColunas += ";|exists|(select 1 from tb_fin_contager_x_empresa x " +
                            "where x.cd_empresa = a.cd_empresa " +
                            "and x.cd_contager = '" + cd_domiciliobancario.Text.Trim() + "')";
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { CD_Empresa },
                                    new CamadaDados.Diversos.TCD_CadEmpresa());
        }

        private void bb_bandeira_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_bandeira|Bandeira|200;" +
                              "a.id_bandeira|Id. Bandeira|80;" +
                              "a.tp_cartao|TP. Cartão|80";
            DataRowView linha = UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { id_bandeira },
                                                        new CamadaDados.Financeiro.Cadastros.TCD_Cad_BandeiraCartao(), string.Empty);
            if (linha != null)
            {
                rbDebito.Checked = linha["tp_cartao"].ToString().Trim().Equals("D");
                rbCredito.Checked = linha["tp_cartao"].ToString().Trim().Equals("C");
            }
        }

        private void id_bandeira_Leave(object sender, EventArgs e)
        {
            string vParam = "a.id_bandeira|=|" + id_bandeira.Text;
            DataRow linha = UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { id_bandeira },
                                                    new CamadaDados.Financeiro.Cadastros.TCD_Cad_BandeiraCartao());
            if (linha != null)
            {
                rbDebito.Checked = linha["tp_cartao"].ToString().Trim().Equals("D");
                rbCredito.Checked = linha["tp_cartao"].ToString().Trim().Equals("C");
            }
        }

        private void bb_cartao_Click(object sender, EventArgs e)
        {
            string vParam = "a.ds_cartao|Cartão|200;" +
                            "a.nr_cartao|Nº Cartão|100";
            UtilPesquisa.BTN_BUSCA(vParam, new Componentes.EditDefault[] { nr_cartao },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadCartaoCredito(), string.Empty);
        }

        private void BB_Buscar_Click(object sender, EventArgs e)
        {
            afterBusca();
        }

        private void bb_contager_Click(object sender, EventArgs e)
        {
            string vColunas = "a.DS_ContaGer|Conta|350;" +
                              "a.CD_ContaGer|Cód. Conta|100";
            string vParamFixo = "|exists|(select 1 from tb_div_usuario_x_contager x " +
                                "where x.cd_contager = a.cd_contager " +
                                "and x.login = '" + Utils.Parametros.pubLogin.Trim() + "');" +
                                "ISNULL(a.ST_ContaCompensacao,'N')|=|'N';" +
                                "a.st_contacartao|<>|0;" +
                                "a.st_contacf|<>|0";
            if (!string.IsNullOrEmpty(CD_Empresa.Text))
                vParamFixo += ";|exists|(select 1 from tb_fin_contager_x_empresa x " +
                              "where x.cd_contager = a.cd_contager " +
                              "and x.cd_empresa = '" + CD_Empresa.Text.Trim() + "')";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_contager, ds_contager },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadContaGer(), vParamFixo);
        }

        private void cd_contager_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_contager|=|'" + cd_contager.Text.Trim() + "'; " +
                            "|exists|(select 1 from tb_div_usuario_x_contager x " +
                                "where x.cd_contager = a.cd_contager " +
                                "and x.login = '" + Utils.Parametros.pubLogin.Trim() + "');" +
                                "ISNULL(a.ST_ContaCompensacao,'N')|=|'N';" +
                                "a.st_contacartao|<>|0;" +
                                "a.st_contacf|<>|0";
            if (!string.IsNullOrEmpty(CD_Empresa.Text))
                vParam += ";|exists|(select 1 from tb_fin_contager_x_empresa x " +
                          "where x.cd_contager = a.cd_contager " +
                          "and x.cd_empresa = '" + CD_Empresa.Text.Trim() + "')";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_contager, ds_contager },
                                new CamadaDados.Financeiro.Cadastros.TCD_CadContaGer());
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            afterGrava();
        }

        private void TFQuitarFaturaCartao_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                DialogResult = DialogResult.Cancel;
            else if (e.KeyCode.Equals(Keys.F7))
                afterBusca();
        }

        private void dt_quitacao_Leave(object sender, EventArgs e)
        {
            if ((!string.IsNullOrEmpty(cd_domiciliobancario.Text)) && (!string.IsNullOrEmpty(dt_quitacao.Text)) && (dt_quitacao.Text.Trim() != "/  /"))
            {
                //testar data de fechamento de caixa se esta aberto para esta data 
                if (!CamadaNegocio.Financeiro.Caixa.TCN_LanCaixa.DataCaixa(cd_domiciliobancario.Text, dt_quitacao.Data, null))
                {
                    MessageBox.Show("Caixa ja se encontra fechado.\r\n" + "Conta Gerencial: " + cd_domiciliobancario.Text + "\r\n Data: " + dt_quitacao.Text + ".", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dt_quitacao.Clear();
                    dt_quitacao.Focus();
                }
            }
        }

        private void gFatura_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (gFatura.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.NotSortable)
                return;
            if (bsFatura.Count < 1)
                return;
            PropertyDescriptorCollection lP = TypeDescriptor.GetProperties(new CamadaDados.Financeiro.Cartao.TRegistro_FaturaCartao());
            CamadaDados.Financeiro.Cartao.TList_FaturaCartao lComparer;
            SortOrder direcao = SortOrder.None;
            if ((gFatura.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None) ||
                (gFatura.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending))
            {
                lComparer = new CamadaDados.Financeiro.Cartao.TList_FaturaCartao(lP.Find(gFatura.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Ascending);
                foreach (DataGridViewColumn c in gFatura.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Ascending;
            }
            else
            {
                lComparer = new CamadaDados.Financeiro.Cartao.TList_FaturaCartao(lP.Find(gFatura.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Descending);
                foreach (DataGridViewColumn c in gFatura.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Descending;
            }
            (bsFatura.DataSource as CamadaDados.Financeiro.Cartao.TList_FaturaCartao).Sort(lComparer);
            bsFatura.ResetBindings(false);
            gFatura.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = direcao;
        }

        private void gFatura_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                if (!string.IsNullOrEmpty((bsFatura.Current as CamadaDados.Financeiro.Cartao.TRegistro_FaturaCartao).Cd_contager))
                {
                    (bsFatura.Current as CamadaDados.Financeiro.Cartao.TRegistro_FaturaCartao).St_processar =
                        !(bsFatura.Current as CamadaDados.Financeiro.Cartao.TRegistro_FaturaCartao).St_processar;
                    bsFatura.ResetCurrentItem();
                    vl_liqQuitar.Value = (bsFatura.List as CamadaDados.Financeiro.Cartao.TList_FaturaCartao).Where(p => p.St_processar).Sum(p => p.Vl_Saldoquitar);
                }
                else
                {
                    MessageBox.Show("Não pode quitar esta fatura, pois caixa não foi processado!",
                        "Mensagem",MessageBoxButtons.OK,MessageBoxIcon.Information,MessageBoxDefaultButton.Button1);
                }
            }
        }

        private void cbMarcar_Click(object sender, EventArgs e)
        {
            if (bsFatura.Count > 0)
            {
                (bsFatura.List as CamadaDados.Financeiro.Cartao.TList_FaturaCartao).ForEach(p =>
                {
                    if (!string.IsNullOrEmpty(p.Cd_contager))
                        p.St_processar = cbMarcar.Checked;
                });
                bsFatura.ResetBindings(true);

                vl_liqQuitar.Value = (bsFatura.List as CamadaDados.Financeiro.Cartao.TList_FaturaCartao).Where(p => p.St_processar).Sum(p => p.Vl_Saldoquitar);
            }
        }

        private void rbDebito_Click(object sender, EventArgs e)
        {
            id_bandeira.Clear();
        }

        private void rbCredito_Click(object sender, EventArgs e)
        {
            id_bandeira.Clear();
        }

        private void bb_domiciliobancario_Click(object sender, EventArgs e)
        {
            string vColunas = "a.DS_ContaGer|Conta|350;" +
                              "a.CD_ContaGer|Cód. Conta|100";
            string vParamFixo = "|exists|(select 1 from tb_div_usuario_x_contager x " +
                                "where x.cd_contager = a.cd_contager " +
                                "and x.login = '" + Utils.Parametros.pubLogin.Trim() + "');" +
                                "ISNULL(a.ST_ContaCompensacao,'N')|=|'N';" +
                                "a.st_contacartao|<>|0;" +
                                "a.st_contacf|<>|0";
            if (rbReceber.Checked)
                vParamFixo += ";isnull(a.cd_banco, '')|<>|''";
            if (!string.IsNullOrEmpty(CD_Empresa.Text))
                vParamFixo += ";|exists|(select 1 from tb_fin_contager_x_empresa x " +
                              "where x.cd_contager = a.cd_contager " +
                              "and x.cd_empresa = '" + CD_Empresa.Text.Trim() + "')";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_domiciliobancario, ds_domiciliobancario },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadContaGer(), vParamFixo);
            if (!string.IsNullOrEmpty(cd_domiciliobancario.Text))
            {
                cd_contager.Text = cd_domiciliobancario.Text;
                ds_contager.Text = ds_domiciliobancario.Text;
            }
        }

        private void cd_domiciliobancario_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_contager|=|'" + cd_domiciliobancario.Text.Trim() + "'; " +
                            "|exists|(select 1 from tb_div_usuario_x_contager x " +
                                "where x.cd_contager = a.cd_contager " +
                                "and x.login = '" + Utils.Parametros.pubLogin.Trim() + "');" +
                                "ISNULL(a.ST_ContaCompensacao,'N')|=|'N';" +
                                "a.st_contacartao|<>|0;" +
                                "a.st_contacf|<>|0";
            if (rbReceber.Checked)
                vParam += ";isnull(a.cd_banco, '')|<>|''";
            if (!string.IsNullOrEmpty(CD_Empresa.Text))
                vParam += ";|exists|(select 1 from tb_fin_contager_x_empresa x " +
                          "where x.cd_contager = a.cd_contager " +
                          "and x.cd_empresa = '" + CD_Empresa.Text.Trim() + "')";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_domiciliobancario, ds_domiciliobancario },
                                new CamadaDados.Financeiro.Cadastros.TCD_CadContaGer());
            if (!string.IsNullOrEmpty(cd_domiciliobancario.Text))
            {
                cd_contager.Text = cd_domiciliobancario.Text;
                ds_contager.Text = ds_domiciliobancario.Text;
            }
        }

        private void rbPagar_CheckedChanged(object sender, EventArgs e)
        {
            afterBusca();
        }

        private void rbDebito_CheckedChanged(object sender, EventArgs e)
        {
            afterBusca();
        }

        private void TFQuitarFaturaCartao_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, gFatura);
        }

        private void cbMarcar_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void bbMaquina_Click(object sender, EventArgs e)
        {
            string vColunas = "a.DS_Maquina|Maquina|200;" +
                              "a.ID_Maquina|Código|80";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { id_maquina },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadMaquinaCartao(), string.Empty);
        }

        private void id_maquina_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("a.id_maquina|=|" + id_maquina.Text, new Componentes.EditDefault[] { id_maquina },
                new CamadaDados.Financeiro.Cadastros.TCD_CadMaquinaCartao());
        }
    }
}
