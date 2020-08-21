using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Utils;

namespace Contabil
{
    public partial class TFAlterarLanctoCTB : Form
    {
        public CamadaDados.Contabil.TRegistro_LanctosCTB rLancto
        { get; set; }

        public TFAlterarLanctoCTB()
        {
            InitializeComponent();
        }

        private void afterGrava()
        {
            if (string.IsNullOrEmpty(dt_lancto.Text.SoNumero()))
            {
                MessageBox.Show("Obrigatório informar data lançamento.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dt_lancto.Focus();
                return;
            }
            try
            {
                CamadaNegocio.Contabil.TCN_LanContabil.AlterarLancto(rLancto.Id_lotectbstr,
                                                                     rLancto.Cd_empresa,
                                                                     DateTime.Parse(dt_lancto.Text),
                                                                     nr_docto.Text,
                                                                     ds_complemento.Text,
                                                                     valor.Value,
                                                                     null);
                MessageBox.Show("Lançamentos do lote alterados com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void TFAlterarLanctoCTB_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            ds_complemento.CharacterCasing = CharacterCasing.Normal;
            id_loteCTB.Text = rLancto.Id_lotectbstr;
            dt_lancto.Text = rLancto.Data.Value.ToString();
            nr_docto.Text = rLancto.Nr_docto;
            ds_complemento.Text = rLancto.Ds_compl_historico;
            if (rLancto.Tp_integracao.Trim().ToUpper().Equals("IS") ||
                Convert.ToInt32(new CamadaDados.Contabil.TCD_LanctosCTB().BuscarEscalar(
                                    new TpBusca[]
                                    {
                                        new TpBusca()
                                        {
                                            vNM_Campo = "a.id_lotectb",
                                            vOperador = "=",
                                            vVL_Busca = rLancto.Id_lotectbstr
                                        },
                                        new TpBusca()
                                        {
                                            vNM_Campo = "a.d_c",
                                            vOperador = "=",
                                            vVL_Busca = rLancto.D_c.Trim().ToUpper().Equals("D") ? "'C'" : "'D'"
                                        }
                                    }, "isnull(count(*), 0)")).Equals(1))
            {
                lblValor.Visible = true;
                valor.Visible = true;
                valor.Value = rLancto.Valor;
            }
            else
            {
                lblValor.Visible = false;
                valor.Visible = false;
            }
            dt_lancto.Focus();
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            this.afterGrava();
        }

        private void TFAlterarLanctoCTB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
        }
    }
}
