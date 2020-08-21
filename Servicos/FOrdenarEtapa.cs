using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Servicos
{
    public partial class TFOrdenarEtapa : Form
    {
        public List<CamadaDados.Servicos.Cadastros.TRegistro_TpOrdem> lTpOrdem
        {
            get
            {
                if (bsTpOrdem.Count > 0)
                {
                    CamadaDados.Servicos.Cadastros.TList_TpOrdem lRetorno = new CamadaDados.Servicos.Cadastros.TList_TpOrdem();
                    for (int i = 0; i < bsTpOrdem.Count; i++)
                        lRetorno.Add(bsTpOrdem[i] as CamadaDados.Servicos.Cadastros.TRegistro_TpOrdem);
                    return lRetorno;
                }
                else
                    return null;
            }
        }

        public TFOrdenarEtapa()
        {
            InitializeComponent();
        }

        private void afterGrava()
        {
            if (BS_CadOseEtapaOrdem.Count > bsEtapa.Count && bsEtapa.Count > decimal.Zero)
            {
                MessageBox.Show("Faltam Ordenar o Tipo de Ordem Atual!!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            for (int i = 0; i < bsTpOrdem.Count; i++)
            {
                if (gTpOrdem.Rows[i].DefaultCellStyle.ForeColor == Color.Red)
                {
                    MessageBox.Show("Faltam Ordenar as Etapas dos Tipos de Ordem em Vermelho!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            this.DialogResult = DialogResult.OK;
        }

        private void afterBuscaTpOrdem()
        {
            bsTpOrdem.DataSource = CamadaNegocio.Servicos.Cadastros.TCN_TpOrdem.Buscar(string.Empty,
                                                                                       string.Empty,
                                                                                       null);
                bsTpOrdem_PositionChanged(this, new EventArgs());
        }

        private void TFOrdenarEtapa_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            this.afterBuscaTpOrdem();
        }

        private void g_etapaOrdem_DoubleClick(object sender, EventArgs e)
        {
            if (BS_CadOseEtapaOrdem.Current != null)
            {
                if (bsEtapa == null)
                    (BS_CadOseEtapaOrdem.Current as CamadaDados.Servicos.Cadastros.TRegistro_EtapaOrdem).Ordem = 1;
                else
                    (BS_CadOseEtapaOrdem.Current as CamadaDados.Servicos.Cadastros.TRegistro_EtapaOrdem).Ordem = bsEtapa.Count + 1;
                bsEtapa.Add(BS_CadOseEtapaOrdem.Current as CamadaDados.Servicos.Cadastros.TRegistro_EtapaOrdem);
            }
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            this.afterGrava();
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void TFOrdenarEtapa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
        }

        private void gOrdem_DoubleClick(object sender, EventArgs e)
        {
            if (bsEtapa.Current != null)
                bsEtapa.RemoveCurrent();
        }

        private void bsTpOrdem_PositionChanged(object sender, EventArgs e)
        {
            if (bsTpOrdem.Current != null)
            {
                BS_CadOseEtapaOrdem.DataSource =
                    new CamadaDados.Servicos.Cadastros.TCD_EtapaOrdem().Select(
                        new Utils.TpBusca[]
                        {
                            new Utils.TpBusca()
                            {
                                vNM_Campo = string.Empty,
                                vOperador = "exists",
                                vVL_Busca = "(select 1 from TB_OSE_TpOrdem_X_Etapa x " +
                                            "where x.id_etapa = a.id_etapa " +
                                            "and x.tp_ordem = " + (bsTpOrdem.Current as CamadaDados.Servicos.Cadastros.TRegistro_TpOrdem).Tp_ordemstr + ")"
                            }
                        }, 0, string.Empty);
               
                bsTpOrdem.ResetCurrentItem();
            }
        }

        private void gTpOrdem_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (bsTpOrdem.Current != null)
            {
                if (BS_CadOseEtapaOrdem.Count > bsEtapa.Count && bsEtapa.Count > decimal.Zero)
                {
                    MessageBox.Show("Obrigatório Organizar todas as etapas!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    gTpOrdem.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Red;
                }
                else
                    gTpOrdem.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
            }
        }
    }
}
