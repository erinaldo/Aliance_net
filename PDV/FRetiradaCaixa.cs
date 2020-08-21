using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PDV
{
    public partial class TFRetiradaCaixa : Form
    {
        private string St_controletitulo { get; set; }

        public string pId_caixa
        { get; set; }

        public CamadaDados.Faturamento.PDV.TRegistro_RetiradaCaixa rRetirada
        {
            get
            {
                if (bsRetirada.Current != null)
                    return bsRetirada.Current as CamadaDados.Faturamento.PDV.TRegistro_RetiradaCaixa;
                else
                    return null;
            }
        }
        

        public TFRetiradaCaixa()
        {
            InitializeComponent();
            this.pId_caixa = string.Empty;
            this.St_controletitulo = string.Empty;
            System.Collections.ArrayList cbx = new System.Collections.ArrayList();
            cbx.Add(new Utils.TDataCombo("SUPRIMENTO", "S"));
            cbx.Add(new Utils.TDataCombo("RETIRADA", "R"));
            tp_registro.DataSource = cbx;
            tp_registro.ValueMember = "Value";
            tp_registro.DisplayMember = "Display";
        }

        private void afterGrava()
        {
            if (vl_retirada.Value.Equals(decimal.Zero))
            {
                MessageBox.Show("Obrigatorio informar valor retirada.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                vl_retirada.Focus();
                return;
            }
            if (tp_registro.SelectedValue == null)
            {
                MessageBox.Show("Obrigatorio informar tipo movimento.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tp_registro.Focus();
                return;
            }
            if (!string.IsNullOrEmpty(cd_portador.Text))
            {
                (bsRetirada.Current as CamadaDados.Faturamento.PDV.TRegistro_RetiradaCaixa).lPortador =
                    new List<CamadaDados.Financeiro.Cadastros.TRegistro_CadPortador>()
                    {
                        new CamadaDados.Financeiro.Cadastros.TRegistro_CadPortador()
                        {
                            Cd_portador = cd_portador.Text,
                            Ds_portador = ds_portador.Text,
                            Vl_pagtoPDV = vl_retirada.Value,
                            St_controletitulo = St_controletitulo
                        }
                    };
                if(St_controletitulo.Trim().ToUpper().Equals("S"))
                    using (TFChequePDV fCheque = new TFChequePDV())
                    {
                        fCheque.Id_caixa = pId_caixa;
                        if (fCheque.ShowDialog() == DialogResult.OK)
                            if (fCheque.lCheque != null)
                            {
                                if (fCheque.lCheque.Sum(p => p.Vl_titulo) != vl_retirada.Value)
                                    if (MessageBox.Show("A soma total do cheque é diferente do valor da retirada.\r\n" +
                                                       "Deseja corrigir o valor da retirada?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                                                       MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                                    {
                                        (bsRetirada.Current as CamadaDados.Faturamento.PDV.TRegistro_RetiradaCaixa).Vl_retirada = fCheque.lCheque.Sum(p => p.Vl_titulo);
                                        (bsRetirada.Current as CamadaDados.Faturamento.PDV.TRegistro_RetiradaCaixa).lPortador[0].Vl_pagtoPDV = fCheque.lCheque.Sum(p => p.Vl_titulo);
                                        bsRetirada.ResetCurrentItem();
                                    }
                                    else return;
                                fCheque.lCheque.ForEach(p => (bsRetirada.Current as CamadaDados.Faturamento.PDV.TRegistro_RetiradaCaixa).lPortador[0].lCheque.Add(p));
                            }
                    }
            }
            this.DialogResult = DialogResult.OK;
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            this.afterGrava();
        }

        private void TFRetiradaCaixa_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pDados.set_FormatZero();
            bsRetirada.AddNew();
            id_caixa.Text = pId_caixa;
        }

        private void TFRetiradaCaixa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
        }

        private void bb_portador_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_portador|Portador|200;" +
                              "a.cd_portador|Código|60;" +
                              "a.st_controletitulo|Cheque|30";
            string vParam = "a.tp_portadorPDV|=|'A';" +
                            "isnull(a.st_devcredito, 'N')|<>|'S';" +
                            "a.st_cartaocredito|=|1;" +
                            "isnull(a.st_EntregaFutura, 'N')|<>|'S';" +
                            "isnull(a.st_cartafrete, 'N')|<>|'S'";
            DataRowView linha = FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_portador, ds_portador },
                                new CamadaDados.Financeiro.Cadastros.TCD_CadPortador(), vParam);
            if (linha != null)
                St_controletitulo = linha["st_controletitulo"].ToString();
        }

        private void cd_portador_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_portador|=|'" + cd_portador.Text.Trim() + "';" +
                            "a.tp_portadorPDV|=|'A';" +
                            "isnull(a.st_devcredito, 'N')|<>|'S';" +
                            "a.st_cartaocredito|=|1;" +
                            "isnull(a.st_EntregaFutura, 'N')|<>|'S';" +
                            "isnull(a.st_cartafrete, 'N')|<>|'S'";
            DataRow linha = FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_portador, ds_portador },
                            new CamadaDados.Financeiro.Cadastros.TCD_CadPortador());
            if (linha != null)
                St_controletitulo = linha["st_controletitulo"].ToString();
        }
    }
}
