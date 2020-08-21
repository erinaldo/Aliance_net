using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Frota
{
    public partial class TFDocumentoCTe : Form
    {
        public bool St_nfe { get; set; }
        public string Tp_cte { get; set; }
        public CamadaDados.Faturamento.CTRC.TRegistro_CTRNotaFiscal rDoc
        { get { return bsDocTransp.Current as CamadaDados.Faturamento.CTRC.TRegistro_CTRNotaFiscal; } }

        public TFDocumentoCTe()
        {
            InitializeComponent();
            System.Collections.ArrayList cbx = new System.Collections.ArrayList();
            cbx.Add(new Utils.TDataCombo("DECLARAÇÃO", "00"));
            cbx.Add(new Utils.TDataCombo("DUTOVIARIO", "10"));
            cbx.Add(new Utils.TDataCombo("OUTROS", "99"));
            tp_documento.DataSource = cbx;
            tp_documento.DisplayMember = "Display";
            tp_documento.ValueMember = "Value";
        }

        private void afterGrava()
        {
            if (this.St_nfe)
            {
                if (string.IsNullOrEmpty(chave_acesso_nfe.Text))
                {
                    MessageBox.Show("Obrigatorio informar chave de acesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    chave_acesso_nfe.Focus();
                    return;
                }
                if (chave_acesso_nfe.Text.Trim().Length != 44)
                {
                    MessageBox.Show("Chave de acesso deve possuir 44 digitos.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    chave_acesso_nfe.Focus();
                    return;
                }
                if (Utils.Estruturas.Mod11(chave_acesso_nfe.Text.Trim().Substring(0, 43), 9, false, 0).ToString() != chave_acesso_nfe.Text.Trim().Substring(43, 1))
                {
                    MessageBox.Show("Chave acesso NFe invalida, verifique e informe novamente.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    chave_acesso_nfe.Focus();
                    return;
                }
                if ((Tp_cte.ToUpper().Trim().Equals("0")))
                {
                    //Verificar se chave de acesso ja foi transportada
                    //Verificar se chave de acesso ja possui CTe Emitido
                    object nr_cte = new CamadaDados.Faturamento.CTRC.TCD_ConhecimentoFrete().BuscarEscalar(
                                    new Utils.TpBusca[]
                                {
                                    new Utils.TpBusca()
                                    {
                                        vNM_Campo = "isnull(a.st_registro, 'A')",
                                        vOperador = "<>",
                                        vVL_Busca = "'C'"
                                    },
                                    new Utils.TpBusca()
                                    {
                                        vNM_Campo = string.Empty,
                                        vOperador = "exists",
                                        vVL_Busca = "(select 1 from tb_ctr_notafiscal x " +
                                                    "where x.cd_empresa = a.cd_empresa " +
                                                    "and x.nr_lanctoctr = a.nr_lanctoctr " +
                                                    "and x.chave_acesso_nfe = '" + chave_acesso_nfe.Text.Trim() + "')"
                                    }
                                }, "a.NR_CTRC");
                    if (nr_cte != null)
                    {
                        MessageBox.Show("NF-e ja transportada pelo CTe Nº" + nr_cte.ToString(), "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
            }
            else
            {
                if (tp_documento.SelectedValue == null)
                {
                    MessageBox.Show("Obrigatório selecionar tipo documento transportado.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    tp_documento.Focus();
                    return;
                }
            }
            this.DialogResult = DialogResult.OK;
        }

        private void TFDocumentoCTe_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            if (this.St_nfe)
                tcCentral.TabPages.Remove(tpOutrosDoc);
            else tcCentral.TabPages.Remove(tpNfe);
            bsDocTransp.AddNew();
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            this.afterGrava();
        }

        private void TFDocumentoCTe_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
        }
    }
}
