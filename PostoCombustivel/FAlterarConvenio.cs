using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PostoCombustivel
{
    public partial class TFAlterarConvenio : Form
    {
        public CamadaDados.PostoCombustivel.TRegistro_Convenio rConvenio
        { get; set; }

        public TFAlterarConvenio()
        {
            InitializeComponent();

            System.Collections.ArrayList cbx = new System.Collections.ArrayList();
            cbx.Add(new Utils.TDataCombo("ATIVO", "A"));
            cbx.Add(new Utils.TDataCombo("ENCERRADO", "E"));

            st_registro.DataSource = cbx;
            st_registro.ValueMember = "Value";
            st_registro.DisplayMember = "Display";

            System.Collections.ArrayList cbx1 = new System.Collections.ArrayList();
            cbx1.Add(new Utils.TDataCombo("PERCENTUAL", "P"));
            cbx1.Add(new Utils.TDataCombo("VALOR", "V"));

            tp_desconto.DataSource = cbx1;
            tp_desconto.ValueMember = "Value";
            tp_desconto.DisplayMember = "Display";

            System.Collections.ArrayList cbx2 = new System.Collections.ArrayList(); 
            cbx2.Add(new Utils.TDataCombo("ACRESCIMO", "A"));
            cbx2.Add(new Utils.TDataCombo("DESCONTO", "D"));
            tp_acresdesc.DataSource = cbx2;
            tp_acresdesc.DisplayMember = "Display";
            tp_acresdesc.ValueMember = "Value";         

            System.Collections.ArrayList cbx4 = new System.Collections.ArrayList();
            cbx4.Add(new Utils.TDataCombo("<NENHUM>", string.Empty));
            cbx4.Add(new Utils.TDataCombo("SEMANAL", "S"));
            cbx4.Add(new Utils.TDataCombo("QUINZENAL", "Q"));
            cbx4.Add(new Utils.TDataCombo("MENSAL", "M"));
            periodofatura.DataSource = cbx4;
            periodofatura.DisplayMember = "Display";
            periodofatura.ValueMember = "Value";

            System.Collections.ArrayList cbx5 = new System.Collections.ArrayList();
            cbx5.Add(new Utils.TDataCombo("SEGUNDA-FEIRA", "0"));
            cbx5.Add(new Utils.TDataCombo("TERÇA-FEIRA", "1"));
            cbx5.Add(new Utils.TDataCombo("QUARTA-FEIRA", "2"));
            cbx5.Add(new Utils.TDataCombo("QUINTA-FEIRA", "3"));
            cbx5.Add(new Utils.TDataCombo("SEXTA-FEIRA", "4"));
            cbx5.Add(new Utils.TDataCombo("SABADO", "5"));
            cbx5.Add(new Utils.TDataCombo("DOMINGO", "6"));
            diasemana.DataSource = cbx5;
            diasemana.DisplayMember = "Display";
            diasemana.ValueMember = "Value";
        }

        private void afterGrava()
        {
            if (pDados.validarCampoObrigatorio())
            {
                if (!string.IsNullOrEmpty(cd_portador.Text))
                {
                    object obj = new CamadaDados.Financeiro.Cadastros.TCD_CadPortador().BuscarEscalar(
                                new Utils.TpBusca[]
                            {
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "a.cd_portador",
                                    vOperador = "=",
                                    vVL_Busca = "'" + cd_portador.Text.Trim() + "'"
                                }
                            }, "a.Tp_portadorpdv");
                    if (obj.Equals("P"))
                    {
                        if (string.IsNullOrEmpty(tp_duplicata.Text))
                        {
                            MessageBox.Show("Obrigatório informar Tipo de Duplicata!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            tp_duplicata.Focus();
                            return;
                        }
                        if (string.IsNullOrEmpty(cd_condpgto.Text))
                        {
                            MessageBox.Show("Obrigatório informar Condição de Pagamento!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            cd_condpgto.Focus();
                            return;
                        }
                    }
                }
            }
            this.DialogResult = DialogResult.OK;
        }

        private void bb_portador_Click(object sender, EventArgs e)
        {
            string vColunas = "ds_portador|Portador|200;" +
                              "cd_portador|Cd. Portador|80";
            string vParam = "TP_PortadorPDV|is not|null";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_portador, ds_portador },
                                            new CamadaDados.Financeiro.Cadastros.TCD_CadPortador(), vParam);
        }

        private void cd_portador_Leave(object sender, EventArgs e)
        {
            string vparam = "a.cd_portador|=|'" + cd_portador.Text.Trim() + "';" +
                            "TP_PortadorPDV|is not|null";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vparam, new Componentes.EditDefault[] { cd_portador, ds_portador },
                                                new CamadaDados.Financeiro.Cadastros.TCD_CadPortador());
        }

        private void bb_tpduplicata_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_tpduplicata|Tipo Duplicata|200;" +
                              "a.tp_duplicata|TP. Duplicata|80";
            string vParam = "a.tp_mov|=|'R'";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { tp_duplicata, ds_tpduplicata },
                                        new CamadaDados.Financeiro.Cadastros.TCD_CadTpDuplicata(), vParam);
        }

        private void tp_duplicata_Leave(object sender, EventArgs e)
        {
            string vParam = "a.tp_duplicata|=|'" + tp_duplicata.Text.Trim() + "';" +
                            "a.tp_mov|=|'R'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { tp_duplicata, ds_tpduplicata },
                                        new CamadaDados.Financeiro.Cadastros.TCD_CadTpDuplicata());
        }

        private void bb_tpdocto_Click(object sender, EventArgs e)
        {
            string vParam = "a.ds_tpdocto|Tipo Documento|200;" +
                            "a.tp_docto|TP. Docto|80";
            FormBusca.UtilPesquisa.BTN_BUSCA(vParam, new Componentes.EditDefault[] { tp_docto, ds_tpdocto },
                                            new CamadaDados.Financeiro.Cadastros.TCD_CadTpDoctoDup(), string.Empty);
        }

        private void tp_docto_Leave(object sender, EventArgs e)
        {
            string vParam = "a.tp_docto|=|" + tp_docto.Text;
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { tp_docto, ds_tpdocto },
                                            new CamadaDados.Financeiro.Cadastros.TCD_CadTpDoctoDup());
        }

        private void bb_condpgto_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_condpgto|Condição Pagamento|200;" +
                              "a.cd_condpgto|Cd. Condição|80";
            string vParam = "a.qt_parcelas|=|1";
            DataRowView linha = FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_condpgto, ds_condpgto },
                                                                    new CamadaDados.Financeiro.Cadastros.TCD_CadCondPgto(), vParam);
            if (linha != null)
            {
                qt_dias_desdobro.Value = decimal.Parse(linha["qt_diasdesdobro"].ToString());
                qt_parcelas.Value = decimal.Parse(linha["qt_parcelas"].ToString());
            }
            else
            {
                qt_dias_desdobro.Value = decimal.Zero;
                qt_parcelas.Value = decimal.Zero;
            }
        }

        private void cd_condpgto_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_condpgto|=|'" + cd_condpgto.Text.Trim() + "';" +
                            "a.qt_parcelas|=|1";
            DataRow linha = FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_condpgto, ds_condpgto },
                                                                new CamadaDados.Financeiro.Cadastros.TCD_CadCondPgto());
            if (linha != null)
            {
                qt_dias_desdobro.Value = decimal.Parse(linha["qt_diasdesdobro"].ToString());
                qt_parcelas.Value = decimal.Parse(linha["qt_parcelas"].ToString());
            }
            else
            {
                qt_dias_desdobro.Value = decimal.Zero;
                qt_parcelas.Value = decimal.Zero;
            }
        }

        private void FAlterarConvenio_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pDados.set_FormatZero();
            bsConvenio.DataSource = new CamadaDados.PostoCombustivel.TList_Convenio() { rConvenio };
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            this.afterGrava();
        }

        private void FAlterarConvenio_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
        }

        private void periodofatura_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblSemana.Visible = periodofatura.SelectedValue == null ? false : periodofatura.SelectedValue.ToString().Equals("S");
            diasemana.Visible = periodofatura.SelectedValue == null ? false : periodofatura.SelectedValue.ToString().Equals("S");
        }
    }
}
