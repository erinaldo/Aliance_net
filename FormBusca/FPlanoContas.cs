using CamadaNegocio.Contabil.Cadastro;
using System;
using System.Data;
using System.Windows.Forms;
using Utils;

namespace FormBusca
{
    public partial class TFPlanoContas : Form
    {
        public string pCd_contapai
        { get; set; }

        private CamadaDados.Contabil.Cadastro.TRegistro_CadPlanoContas rplano;
        public CamadaDados.Contabil.Cadastro.TRegistro_CadPlanoContas rPlano
        {
            get
            {
                if (bsConta.Current != null)
                    return bsConta.Current as CamadaDados.Contabil.Cadastro.TRegistro_CadPlanoContas;
                else return null;
            }
            set { rplano = value; }
        }

        public TFPlanoContas()
        {
            InitializeComponent();
            System.Collections.ArrayList CBox1 = new System.Collections.ArrayList();
            CBox1.Add(new Utils.TDataCombo("A - ANALÍTICO", "A"));
            CBox1.Add(new Utils.TDataCombo("S - SINTÉTICO", "S"));
            tp_conta.DataSource = CBox1;
            tp_conta.DisplayMember = "Display";
            tp_conta.ValueMember = "Value";
            tp_conta.SelectedValue = "S";

            System.Collections.ArrayList cbx1 = new System.Collections.ArrayList();
            cbx1.Add(new TDataCombo("DEVEDORA", "D"));
            cbx1.Add(new TDataCombo("CREDORA", "C"));
            natureza.DataSource = cbx1;
            natureza.DisplayMember = "Display";
            natureza.ValueMember = "Value";

            System.Collections.ArrayList cbx2 = new System.Collections.ArrayList();
            cbx2.Add(new TDataCombo("CONTAS ATIVO", "01"));
            cbx2.Add(new TDataCombo("CONTAS PASSIVO", "02"));
            cbx2.Add(new TDataCombo("PATRIMONIO LIQUIDO", "03"));
            cbx2.Add(new TDataCombo("CONTAS RESULTADO", "04"));
            cbx2.Add(new TDataCombo("CONTAS COMPENSAÇÃO", "05"));
            cbx2.Add(new TDataCombo("OUTRAS", "09"));
            tp_contasped.DataSource = cbx2;
            tp_contasped.DisplayMember = "Display";
            tp_contasped.ValueMember = "Value";
        }

        private void afterGrava()
        {
            if (pDados.validarCampoObrigatorio())
            {
                if(!cd_classificacao.Text.Trim().Contains(cd_classif_pai.Text.Trim()))
                {
                    MessageBox.Show("Classificação invalida.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cd_classificacao.Focus();
                    return;
                }
                if(rplano == null ? true : rplano.Cd_classificacao.Trim() != cd_classificacao.Text.Trim())
                    if(new CamadaDados.Contabil.Cadastro.TCD_CadPlanoContas().BuscarEscalar(
                        new TpBusca[] 
                        {
                            new TpBusca { vNM_Campo = "a.cd_classificacao", vOperador = "=", vVL_Busca = "'" + cd_classificacao.Text.Trim() + "'"},
                            new TpBusca { vNM_Campo = "isnull(a.st_registro, 'A')", vOperador = "<>", vVL_Busca = "'C'" }
                        }, "1") != null)
                    {
                        MessageBox.Show("Classificação ja esta sendo utilizada por outra conta.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cd_classificacao.Focus();
                        return;
                    }
                DialogResult = DialogResult.OK;
            }
        }

        private void TFPlanoContas_Load(object sender, EventArgs e)
        {
            Icon = ResourcesUtils.TecnoAliance_ICO;
            pDados.set_FormatZero();
            if (rplano != null)
            {
                bsConta.DataSource = new CamadaDados.Contabil.Cadastro.TList_CadPlanoContas() { rplano };
                cd_contactbpai.Enabled = rplano.Tp_conta.Trim().ToUpper().Equals("A");
                bb_contactbpai.Enabled = rplano.Tp_conta.Trim().ToUpper().Equals("A");
                tp_conta.Enabled = rplano.Tp_conta.Trim().ToUpper().Equals("A");
                st_contadeducao.Enabled = rplano.Tp_conta.Trim().ToUpper().Equals("A");
                natureza.Enabled = !rplano.Cd_conta_ctbpai.HasValue;
            }
            else
            {
                cd_conta.Enabled = !CamadaNegocio.Diversos.TCN_CadParamSys.St_AutoInc("CD_Conta_CTB");
                bsConta.AddNew();
                if (!string.IsNullOrEmpty(pCd_contapai))
                {
                    cd_contactbpai.Text = pCd_contapai;
                    cd_contactbpai_Leave(this, new EventArgs());
                    bsConta.ResetCurrentItem();
                }
                cd_classificacao.Text = TCN_PlanoContas.CalcularClassif(cd_contactbpai.Text, null);
            }
        }

        private void bb_contactbpai_Click(object sender, EventArgs e)
        {
            string vColunas = "a.DS_ContaCTB|Conta Contabil|350;" +
                              "a.CD_Conta_CTB|Cód. Conta|100;" +
                              "a.CD_Classificacao|Classificação|100;" +
                              "a.Natureza|Natureza|80;" +
                              "a.tp_contasped|Classif. Sped|60";
            string vParamFixo = "a.TP_Conta|=|'S'";
            DataRowView linha = UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_contactbpai, ds_conta_ctbpai, cd_classif_pai }, 
                                new CamadaDados.Contabil.Cadastro.TCD_CadPlanoContas(), vParamFixo);
            if (linha != null)
            {
                natureza.SelectedValue = linha["natureza"].ToString();
                natureza.Enabled = string.IsNullOrEmpty(linha["natureza"].ToString());
                tp_contasped.SelectedValue = linha["tp_contasped"].ToString();
                tp_contasped.Enabled = tp_contasped.SelectedValue == null;
                cd_classificacao.Text = TCN_PlanoContas.CalcularClassif(cd_contactbpai.Text, null);
            }
            else
            {
                natureza.Enabled = true;
                tp_contasped.Enabled = true;
            }
        }

        private void cd_contactbpai_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.CD_Conta_CTB|=|'" + cd_contactbpai.Text.Trim() + "';" +
                              "a.TP_Conta|=|'S'";
            DataRow linha = UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { cd_contactbpai, ds_conta_ctbpai, cd_classif_pai },
                                                                new CamadaDados.Contabil.Cadastro.TCD_CadPlanoContas());
            if (linha != null)
            {
                natureza.SelectedValue = linha["natureza"].ToString();
                natureza.Enabled = string.IsNullOrEmpty(linha["natureza"].ToString());
                tp_contasped.SelectedValue = linha["tp_contasped"].ToString();
                tp_contasped.Enabled = tp_contasped.SelectedValue == null;
                cd_classificacao.Text = TCN_PlanoContas.CalcularClassif(cd_contactbpai.Text, null);
            }
            else
            {
                natureza.Enabled = true;
                tp_contasped.Enabled = true;
            }
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            afterGrava();
        }

        private void TFPlanoContas_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                DialogResult = DialogResult.Cancel;
        }

        private void bb_referencia_Click(object sender, EventArgs e)
        {
            using (TFBuscarContasReferenciais fBusca = new TFBuscarContasReferenciais())
            {
                if(fBusca.ShowDialog() == DialogResult.OK)
                    if (fBusca.rConta != null)
                    {
                        cd_referencia.Text = fBusca.rConta.Cd_referencia;
                        ds_referencia.Text = fBusca.rConta.Nome;
                        tp_contasped.SelectedValue = fBusca.rConta.Natureza.FormatStringEsquerda(2, '0');
                    }
            }
        }

        private void cd_referencia_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_referencia|=|'" + cd_referencia.Text.Trim() + "';" +
                            "a.tp_conta|=|'A'";
            DataRow linha = UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_referencia, ds_referencia },
                            new CamadaDados.Contabil.Cadastro.TCD_PlanoReferencial());
            if (linha != null)
                tp_contasped.SelectedValue = linha["natureza"].ToString().FormatStringEsquerda(2, '0');
        }

        private void tp_conta_SelectedIndexChanged(object sender, EventArgs e)
        {
            cd_referencia.Enabled = !tp_conta.SelectedIndex.Equals(1);
            bb_referencia.Enabled = !tp_conta.SelectedIndex.Equals(1);
        }

        private void cd_referencia_EnabledChanged(object sender, EventArgs e)
        {
            if (!cd_referencia.Enabled)
            {
                cd_referencia.Clear();
                ds_referencia.Clear();
            }
        }

        private void cd_conta_Leave(object sender, EventArgs e)
        {
            string codigo = cd_conta.Text;
            if (!string.IsNullOrEmpty(cd_conta.Text))
            {
                bsConta.DataSource = TCN_PlanoContas.Buscar(cd_conta.Text,
                                                            string.Empty,
                                                            string.Empty,
                                                            string.Empty,
                                                            null);
                if (bsConta.Count > 0)
                {
                    cd_conta.Enabled = false;
                    tp_contasped.Enabled = false;
                    natureza.Enabled = false;
                }
                else
                {
                    bsConta.AddNew();
                    cd_conta.Text = codigo;
                }
            }
        }

        private void cd_classificacao_TextChanged(object sender, EventArgs e)
        {
            if (cd_classificacao.Text.Trim().Length.Equals(2))
                cd_classificacao.Text = cd_classificacao.Text.Insert(1, ".");
            else if (cd_classificacao.Text.Trim().Length.Equals(4))
                cd_classificacao.Text = cd_classificacao.Text.Insert(3, ".");
            else if (cd_classificacao.Text.Trim().Length.Equals(6))
                cd_classificacao.Text = cd_classificacao.Text.Insert(5, ".");
            else if (cd_classificacao.Text.Trim().Length.Equals(9))
                cd_classificacao.Text = cd_classificacao.Text.Insert(8, ".");
            cd_classificacao.Select(cd_classificacao.Text.Length, 0);
        }
        
        private void cd_classif_pai_TextChanged(object sender, EventArgs e)
        {
            string[] ret = cd_classif_pai.Text.Split(new char[] { '.' });
            switch (ret.Length)
            {
                case 1: cd_classificacao.MaxLength = 3; break;
                case 2: cd_classificacao.MaxLength = 5; break;
                case 3: cd_classificacao.MaxLength = 8; break;
                case 4: cd_classificacao.MaxLength = 12; break;
                default: cd_classificacao.MaxLength = 1; break;
            }
        }
    }
}
