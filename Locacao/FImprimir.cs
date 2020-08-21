using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using CamadaDados.Financeiro.Bloqueto;
using CamadaNegocio.Financeiro.Duplicata;
using CamadaDados.Financeiro.Duplicata;
using FormRelPadrao;

namespace Locacao
{
    public partial class TFImprimir : Form
    {
        public string pMes
        { get; set; }
        public string pAno
        { get; set; }
        public string pId_locacao
        { get; set; }
        public string pNm_cliente
        { get; set; }
        public bool Altera_Relatorio = false;
        private int month
        { get; set; }
        public TFImprimir()
        {
            InitializeComponent();
            for (int i = 2013; i < 2050; i++)
                cbxAno.Items.Add(i);
        }

        private void BuscarMes()
        {
            month = 0;
            if (cbxMes.Text.ToUpper().Equals("JANEIRO"))
                month = 01;
            else if (cbxMes.Text.ToUpper().Equals("FEVEREIRO"))
                month = 02;
            else if (cbxMes.Text.ToUpper().Equals("MARÇO"))
                month = 03;
            else if (cbxMes.Text.ToUpper().Equals("ABRIL"))
                month = 04;
            else if (cbxMes.Text.ToUpper().Equals("MAIO"))
                month = 05;
            else if (cbxMes.Text.ToUpper().Equals("JUNHO"))
                month = 06;
            else if (cbxMes.Text.ToUpper().Equals("JULHO"))
                month = 07;
            else if (cbxMes.Text.ToUpper().Equals("AGOSTO"))
                month = 08;
            else if (cbxMes.Text.ToUpper().Equals("SETEMBRO"))
                month = 09;
            else if (cbxMes.Text.ToUpper().Equals("OUTUBRO"))
                month = 10;
            else if (cbxMes.Text.ToUpper().Equals("NOVEMBRO"))
                month = 11;
            else if (cbxMes.Text.ToUpper().Equals("DEZEMBRO"))
                month = 12;
        }

        private void afterPrintBloqueto()
        {
            if (dsBloqueto.Current != null)
            {
                if ((dsBloqueto.Current as blTitulo).St_registro.Trim().ToUpper().Equals("C"))
                {
                    MessageBox.Show("Bloqueto encontra-se cancelado. Não sera possivel realizar a compensação do mesmo!", "Mensagem", MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                    return;
                }
                if ((dsBloqueto.Current as blTitulo).St_registro.Trim().ToUpper().Equals("P"))
                {
                    MessageBox.Show("Não é permitido reimprimir bloqueto COMPENSADO.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (!Altera_Relatorio)
                {
                    //Chamar tela de impressao para o bloqueto
                    using (TFGerenciadorImpressao fImp = new TFGerenciadorImpressao())
                    {
                        fImp.St_enabled_enviaremail = true;
                        fImp.pCd_clifor = (dsBloqueto.Current as blTitulo).Cd_sacado;
                        fImp.pMensagem = "BLOQUETO Nº" + (dsBloqueto.Current as blTitulo).Nosso_numero.Trim();
                        if ((fImp.ShowDialog() == DialogResult.OK) || (fImp.pSt_enviaremail))
                            TCN_LayoutBloqueto.Imprime_Bloqueto(Altera_Relatorio,
                                                                new blListaTitulo() { (dsBloqueto.Current as blTitulo) },
                                                                fImp.pSt_imprimir,
                                                                fImp.pSt_visualizar,
                                                                fImp.pSt_enviaremail,
                                                                fImp.pSt_exportPdf,
                                                                fImp.Path_exportPdf,
                                                                fImp.pDestinatarios,
                                                                "BLOQUETO Nº " + (dsBloqueto.Current as blTitulo).Nosso_numero.Trim(),
                                                                fImp.pDs_mensagem,
                                                                false);
                    }
                }
                else
                    TCN_LayoutBloqueto.Imprime_Bloqueto(Altera_Relatorio,
                                                        new blListaTitulo() { (dsBloqueto.Current as blTitulo) },
                                                        false,
                                                        false,
                                                        false,
                                                        false,
                                                        string.Empty,
                                                        null,
                                                        string.Empty,
                                                        string.Empty,
                                                        false);

                Altera_Relatorio = false;
            }
        }

        private void ImprimirDuplicata()
        {
            if (BS_Duplicata.Current != null)
            {
                //Buscar parcela
                TList_RegLanDuplicata lDup =
                    TCN_LanDuplicata.Busca((BS_Duplicata.Current as TRegistro_LanDuplicata).Cd_empresa,
                                           (BS_Duplicata.Current as TRegistro_LanDuplicata).Nr_lancto.ToString(),
                                           string.Empty,
                                           string.Empty,
                                           string.Empty,
                                           string.Empty,
                                           string.Empty,
                                           string.Empty,
                                           false,
                                           string.Empty,
                                           string.Empty,
                                           string.Empty,
                                           string.Empty,
                                           string.Empty,
                                           string.Empty,
                                           false,
                                           0,
                                           string.Empty,
                                           null);
                lDup[0].Parcelas =
                    new TCD_LanParcela().Select(
                        new Utils.TpBusca[]
                        {
                            new Utils.TpBusca()
                            {
                                vNM_Campo = "a.cd_empresa",
                                vOperador = "=",
                                vVL_Busca = "'" + lDup[0].Cd_empresa.Trim() + "'"
                            },
                            new Utils.TpBusca()
                            {
                                vNM_Campo = "a.nr_lancto",
                                vOperador = "=",
                                vVL_Busca = "" + lDup[0].Nr_lancto + ""
                            }
                        }, 0, string.Empty, string.Empty, string.Empty);
                if (lDup.Count > 0)
                    using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
                    {
                        //Buscar dados Empresa
                        CamadaDados.Diversos.TList_CadEmpresa lEmpresa =
                            CamadaNegocio.Diversos.TCN_CadEmpresa.Busca(lDup[0].Cd_empresa,
                                                                        string.Empty,
                                                                        string.Empty,
                                                                        null);
                        //Buscar dados do sacado
                        CamadaDados.Financeiro.Cadastros.TList_CadClifor lSacado =
                            CamadaNegocio.Financeiro.Cadastros.TCN_CadClifor.Busca_Clifor(lDup[0].Cd_clifor,
                                                                                          string.Empty,
                                                                                          string.Empty,
                                                                                          string.Empty,
                                                                                          string.Empty,
                                                                                          string.Empty,
                                                                                          string.Empty,
                                                                                          string.Empty,
                                                                                          string.Empty,
                                                                                          string.Empty,
                                                                                          false,
                                                                                          string.Empty,
                                                                                          string.Empty,
                                                                                          string.Empty,
                                                                                          string.Empty,
                                                                                          string.Empty,
                                                                                          string.Empty,
                                                                                          0,
                                                                                          null);
                        //Buscar endereco sacado
                        if (lSacado.Count > 0)
                            lSacado[0].lEndereco =
                                CamadaNegocio.Financeiro.Cadastros.TCN_CadEndereco.Buscar(lDup[0].Cd_clifor,
                                                                                          lDup[0].Cd_endereco,
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
                        fImp.St_enabled_enviaremail = true;
                        fImp.pCd_clifor = lDup[0].Cd_clifor;
                        fImp.pMensagem = "DUPLICATAS DO DOCUMENTO Nº" + lDup[0].Nr_docto;
                        if ((fImp.ShowDialog() == DialogResult.OK) || (fImp.pSt_enviaremail))
                        {
                            TCN_LayoutDuplicata.Imprime_Duplicata(Altera_Relatorio,
                                                                  lDup[0].Parcelas,
                                                                  lEmpresa,
                                                                  lSacado,
                                                                  fImp.pSt_imprimir,
                                                                  fImp.pSt_visualizar,
                                                                  fImp.pSt_exportPdf,
                                                                  fImp.Path_exportPdf,
                                                                  fImp.pSt_enviaremail,
                                                                  fImp.pDestinatarios,
                                                                  "DUPLICATAS(S) DO DOCUMENTO Nº " + lDup[0].Nr_docto,
                                                                  fImp.pDs_mensagem);
                            Altera_Relatorio = false;
                        }
                    }
            }
        }

        private void BuscarFinanceiro(DateTime data)
        {
            if (tcCentral.SelectedTab.Equals(tpBloquetos))
            {
                //Calcular ultimo dia do mes
                DateTime d = data.AddMonths(1);
                d = d.AddDays(-1);

                Utils.TpBusca[] filtro = new Utils.TpBusca[4];
                //Data
                filtro[0].vNM_Campo = "b.dt_vencto";
                filtro[0].vOperador = ">=";
                filtro[0].vVL_Busca = "'" + data.ToString("yyyyMMdd") + "'";
                //Data
                filtro[1].vNM_Campo = "b.dt_vencto";
                filtro[1].vOperador = "<=";
                filtro[1].vVL_Busca = "'" + d.ToString("yyyyMMdd") + "'";
                //Buscar somente parcelas geradas pelo modulo locação.
                filtro[2].vNM_Campo = string.Empty;
                filtro[2].vOperador = "exists";
                filtro[2].vVL_Busca = "(select 1 from TB_LOC_Locacao_X_Duplicata x " +
                                      "where a.cd_empresa = x.cd_empresa " +
                                      "and a.nr_lancto = x.nr_lancto " +
                                      "and x.id_locacao = " + (!string.IsNullOrEmpty(id_locacao.Text) ? id_locacao.Text : "x.id_locacao") +
                                      (!string.IsNullOrEmpty(nm_clifor.Text) ? " and sacado.nm_clifor like '%" + nm_clifor.Text.Trim() + "%')" :
                                      " and sacado.nm_clifor = sacado.nm_clifor)");
                filtro[3].vNM_Campo = "isnull(a.st_registro, 'A')";
                filtro[3].vOperador = "<>";
                filtro[3].vVL_Busca = "'C'";
                dsBloqueto.DataSource = new CamadaDados.Financeiro.Bloqueto.TCD_Titulo().Select(filtro, 0, string.Empty);
            }
            else if (tcCentral.SelectedTab.Equals(tpDup))
            {
                //Calcular ultimo dia do mes
                DateTime d = data.AddMonths(1);
                d = d.AddDays(-1);

                Utils.TpBusca[] filtro = new Utils.TpBusca[3];
                //Data
                filtro[0].vNM_Campo = "a.dt_emissao";
                filtro[0].vOperador = ">=";
                filtro[0].vVL_Busca = "'" + data.ToString("yyyyMMdd") + "'";
                //Data
                filtro[1].vNM_Campo = "a.dt_emissao";
                filtro[1].vOperador = "<=";
                filtro[1].vVL_Busca = "'" + d.ToString("yyyyMMdd") + "'";
                //Buscar somente parcelas geradas pelo modulo locação.
                filtro[2].vNM_Campo = string.Empty;
                filtro[2].vOperador = "exists";
                filtro[2].vVL_Busca = "(select 1 from TB_LOC_Locacao_X_Duplicata x " +
                                      "where a.cd_empresa = x.cd_empresa " +
                                      "and a.nr_lancto = x.nr_lancto " +
                                      "and x.id_locacao = " + (!string.IsNullOrEmpty(id_locacao.Text) ? id_locacao.Text : "x.id_locacao") +
                                      (!string.IsNullOrEmpty(nm_clifor.Text) ? " and d.nm_clifor like '%" + nm_clifor.Text.Trim() + "%')" :
                                      " and d.nm_clifor = d.nm_clifor)");

                BS_Duplicata.DataSource = new TCD_LanDuplicata().Select(filtro, 0, string.Empty);
            }
        }

        private void TFImprimir_Load(object sender, EventArgs e)
        {
            Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            try
            {
                id_locacao.Text = pId_locacao;
                nm_clifor.Text = pNm_cliente;
                cbxAno.Text = pAno;
                cbxMes.Text = pMes;
                BuscarMes();
            }
            catch
            {
                id_locacao.Text = pId_locacao;
                nm_clifor.Text = pNm_cliente;
                cbxAno.Text = pAno;
                cbxMes.Text = pMes;
                BuscarMes();
            }
            DateTime date;
            date = Convert.ToDateTime("01" + "/" + month.ToString() + "/" + cbxAno.Text);
            BuscarFinanceiro(date);
        }

        private void BB_Imprimir_Click(object sender, EventArgs e)
        {
            if (tcCentral.SelectedTab.Equals(tpDup))
                ImprimirDuplicata();
            else
                afterPrintBloqueto();
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void TFImprimir_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F6))
                DialogResult = DialogResult.Cancel;
            else if (e.KeyCode.Equals(Keys.F8))
            {
                if (tcCentral.SelectedTab.Equals(tpDup))
                    ImprimirDuplicata();
                else
                    afterPrintBloqueto();
            }
            else if (e.KeyCode.Equals(Keys.Enter))
                bb_buscar_Click(this, new EventArgs());
            else if (e.Control && (e.KeyCode == Keys.P))
            {
                Altera_Relatorio = true;
                MessageBox.Show("Execute o relatório que deseja alterar", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void bb_proximo_Click(object sender, EventArgs e)
        {
            month = month + 1;
            if (month.Equals(13))
            {
                cbxMes.Text = new DateTime(int.Parse(cbxAno.Text) + 1, 01, 01).ToString("MMMM", new System.Globalization.CultureInfo("pt-BR"));
                cbxAno.Text = (int.Parse(cbxAno.Text) + 1).ToString();
            }
            else
                cbxMes.Text = new DateTime(int.Parse(cbxAno.Text), month, 01).ToString("MMMM", new System.Globalization.CultureInfo("pt-BR"));
            BuscarMes();
            DateTime date;
            date = Convert.ToDateTime("01" + "/" + month.ToString() + "/" + cbxAno.Text);
            BuscarFinanceiro(date);
        }

        private void bb_anterior_Click(object sender, EventArgs e)
        {
            month = month - 1;
            if (month.Equals(0))
            {
                cbxMes.Text = new DateTime(int.Parse(cbxAno.Text) - 1, 12, 01).ToString("MMMM", new System.Globalization.CultureInfo("pt-BR"));
                cbxAno.Text = (int.Parse(cbxAno.Text) - 1).ToString();
            }
            else
                cbxMes.Text = new DateTime(int.Parse(cbxAno.Text), month, 01).ToString("MMMM", new System.Globalization.CultureInfo("pt-BR"));
            BuscarMes();
            DateTime date;
            date = Convert.ToDateTime("01" + "/" + month.ToString() + "/" + cbxAno.Text);
            BuscarFinanceiro(date);
        }

        private void tcCentral_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tcCentral.SelectedTab.Equals(tpCaixa))
            {
                if (dsBloqueto.Current != null)
                    bsLiquidacoes.DataSource = TCN_LanLiquidacao.Busca((dsBloqueto.Current as CamadaDados.Financeiro.Bloqueto.blTitulo).Cd_empresa,
                                                                        (dsBloqueto.Current as CamadaDados.Financeiro.Bloqueto.blTitulo).Nr_lancto.Value,
                                                                        (dsBloqueto.Current as CamadaDados.Financeiro.Bloqueto.blTitulo).Cd_parcela.Value,
                                                                        0,
                                                                        string.Empty,
                                                                        decimal.Zero,
                                                                        decimal.Zero,
                                                                        decimal.Zero,
                                                                        decimal.Zero,
                                                                        decimal.Zero,
                                                                        decimal.Zero,
                                                                        decimal.Zero,
                                                                        false,
                                                                        "A",
                                                                        0,
                                                                        string.Empty,
                                                                        null);
            }
            else if (tcCentral.SelectedTab.Equals(tpDup))
            {
                DateTime date;
                date = Convert.ToDateTime("01" + "/" + month.ToString() + "/" + cbxAno.Text);
                BuscarFinanceiro(date);
            }
        }

        private void gBloquetos_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (gBloquetos.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.NotSortable)
                return;
            if (dsBloqueto.Count < 1)
                return;
            PropertyDescriptorCollection lP = TypeDescriptor.GetProperties(new blTitulo());
            blListaTitulo lComparer;
            SortOrder direcao = SortOrder.None;
            if ((gBloquetos.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None) ||
                (gBloquetos.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending))
            {
                lComparer = new blListaTitulo(lP.Find(gBloquetos.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Ascending);
                foreach (DataGridViewColumn c in gBloquetos.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Ascending;
            }
            else
            {
                lComparer = new blListaTitulo(lP.Find(gBloquetos.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Descending);
                foreach (DataGridViewColumn c in gBloquetos.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Descending;
            }
            (dsBloqueto.List as blListaTitulo).Sort(lComparer);
            dsBloqueto.ResetBindings(false);
            gBloquetos.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = direcao;
        }

        private void gBloquetos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null)
                if (e.ColumnIndex == 0)
                {
                    if (e.Value.ToString().Trim().ToUpper().Equals("COMPENSADO"))
                    {
                        DataGridViewRow linha = gBloquetos.Rows[e.RowIndex];
                        linha.DefaultCellStyle.ForeColor = Color.Blue;
                    }
                    else if (e.Value.ToString().Trim().ToUpper().Equals("CANCELADO"))
                    {
                        DataGridViewRow linha = gBloquetos.Rows[e.RowIndex];
                        linha.DefaultCellStyle.ForeColor = Color.Red;
                    }
                    else
                    {
                        DataGridViewRow linha = gBloquetos.Rows[e.RowIndex];
                        linha.DefaultCellStyle.ForeColor = Color.Black;
                    }
                }
        }

        private void bb_buscar_Click(object sender, EventArgs e)
        {
            DateTime date;
            date = Convert.ToDateTime("01" + "/" + month.ToString() + "/" + cbxAno.Text);
            BuscarFinanceiro(date);
        }

        private void id_locacao_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) || //Letras
              char.IsSymbol(e.KeyChar) || //Símbolos
              char.IsWhiteSpace(e.KeyChar) || //Espaço
              char.IsPunctuation(e.KeyChar)) //Pontuação
                e.Handled = true;
        }
    }
}
