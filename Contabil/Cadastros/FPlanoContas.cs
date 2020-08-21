using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Contabil.Cadastros
{
    public partial class TFPlanoContas : Form
    {
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
            cbx1.Add(new Utils.TDataCombo("DEVEDORA", "D"));
            cbx1.Add(new Utils.TDataCombo("CREDORA", "C"));
            natureza.DataSource = cbx1;
            natureza.DisplayMember = "Display";
            natureza.ValueMember = "Value";
        }

        private void afterGrava()
        {
            if (pDados.validarCampoObrigatorio())
                this.DialogResult = DialogResult.OK;
        }

        private void TFPlanoContas_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            this.pDados.set_FormatZero();
            if (rplano != null)
            {
                bsConta.DataSource = new CamadaDados.Contabil.Cadastro.TList_CadPlanoContas() { rplano };
                cd_contactbpai.Enabled = rplano.Tp_conta.Trim().ToUpper().Equals("A");
                bb_contactbpai.Enabled = rplano.Tp_conta.Trim().ToUpper().Equals("A");
                tp_conta.Enabled = rplano.Tp_conta.Trim().ToUpper().Equals("A");
                st_contadeducao.Enabled = rplano.Tp_conta.Trim().ToUpper().Equals("A");
                natureza.Enabled = !rplano.Cd_conta_ctbpai.HasValue;
            }
            else bsConta.AddNew();
        }

        private void bb_contactbpai_Click(object sender, EventArgs e)
        {
            string vColunas = "a.DS_ContaCTB|Conta Contabil|350;" +
                              "a.CD_Conta_CTB|Cód. Conta|100;" +
                              "a.CD_Classificacao|Classificação|100;" +
                              "a.Natureza|Natureza|80";
            string vParamFixo = "a.TP_Conta|=|'S'";
            DataRowView linha = FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_contactbpai, ds_conta_ctbpai }, 
                                new CamadaDados.Contabil.Cadastro.TCD_CadPlanoContas(), vParamFixo);
            if (linha != null)
            {
                natureza.SelectedValue = linha["natureza"].ToString();
                natureza.Enabled = false;
            }
            else natureza.Enabled = true;
        }

        private void cd_contactbpai_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.CD_Conta_CTB|=|'" + cd_contactbpai.Text.Trim() + "';" +
                              "a.TP_Conta|=|'S'";
            DataRow linha = FormBusca.UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { cd_contactbpai, ds_conta_ctbpai },
                                                                new CamadaDados.Contabil.Cadastro.TCD_CadPlanoContas());
            if (linha != null)
            {
                natureza.SelectedValue = linha["natureza"].ToString();
                natureza.Enabled = false;
            }
            else natureza.Enabled = true;
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            this.afterGrava();
        }

        private void TFPlanoContas_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
        }
    }
}
