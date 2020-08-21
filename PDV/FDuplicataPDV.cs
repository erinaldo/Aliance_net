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
    public partial class TFDuplicataPDV : Form
    {
        public CamadaDados.Financeiro.Duplicata.TRegistro_LanDuplicata rDup { get; set; }

        public TFDuplicataPDV()
        {
            InitializeComponent();
        }

        private void afterGrava()
        {
            if (cbCondPgto.SelectedValue == null)
                MessageBox.Show("Obrigatório selecionar condição pagamento.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else this.DialogResult = DialogResult.OK;
        }

        private void bb_avancar_Click(object sender, EventArgs e)
        {
            bsParcelas.MoveNext();
            dt_vencto.Focus();
        }

        private void bb_voltar_Click(object sender, EventArgs e)
        {
            bsParcelas.MovePrevious();
            dt_vencto.Focus();
        }

        private void TFDuplicataPDV_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            //Preencher Cond. Pagamento
            CamadaDados.Financeiro.Cadastros.TList_CadCondPgto lCond =
                new CamadaDados.Financeiro.Cadastros.TCD_CadCondPgto().Select(
                new Utils.TpBusca[]
                {
                    new Utils.TpBusca()
                    {
                        vNM_Campo = "a.qt_parcelas",
                        vOperador = ">",
                        vVL_Busca = "0"
                    }
                }, 0, string.Empty);
            cbCondPgto.DataSource = lCond.OrderBy(p => p.Qt_parcelas).ToList();
            cbCondPgto.DisplayMember = "ds_condpgto";
            cbCondPgto.ValueMember = "cd_condpgto";
            //Preencher Config. Boleto
            CamadaDados.Financeiro.Cadastros.TList_CadCFGBanco lCfgBoleto =
                CamadaNegocio.Financeiro.Cadastros.TCN_CadCFGBanco.Buscar(string.Empty,
                                                                          string.Empty,
                                                                          rDup.Cd_empresa,
                                                                          string.Empty,
                                                                          string.Empty,
                                                                          string.Empty,
                                                                          "A",
                                                                          string.Empty,
                                                                          0,
                                                                          null);
            cbBoleto.DataSource = lCfgBoleto;
            cbBoleto.DisplayMember = "ds_config";
            cbBoleto.ValueMember = "id_config";

            bsDuplicata.DataSource = new CamadaDados.Financeiro.Duplicata.TList_RegLanDuplicata() { rDup };
            bsDuplicata.ResetCurrentItem();
            cbBoleto.Enabled = !rDup.Id_configBoleto.HasValue;
        }

        private void cbCondPgto_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbCondPgto.SelectedItem != null && bsDuplicata.Current != null)
            {
                (bsDuplicata.Current as CamadaDados.Financeiro.Duplicata.TRegistro_LanDuplicata).Qt_dias_desdobro = (cbCondPgto.SelectedItem as CamadaDados.Financeiro.Cadastros.TRegistro_CadCondPgto).Qt_diasdesdobro;
                (bsDuplicata.Current as CamadaDados.Financeiro.Duplicata.TRegistro_LanDuplicata).Qt_parcelas = (cbCondPgto.SelectedItem as CamadaDados.Financeiro.Cadastros.TRegistro_CadCondPgto).Qt_parcelas;
                (bsDuplicata.Current as CamadaDados.Financeiro.Duplicata.TRegistro_LanDuplicata).Pc_jurodiario_atrazo = (cbCondPgto.SelectedItem as CamadaDados.Financeiro.Cadastros.TRegistro_CadCondPgto).Pc_jurodiario_atrazo;
                (bsDuplicata.Current as CamadaDados.Financeiro.Duplicata.TRegistro_LanDuplicata).St_comentrada = (cbCondPgto.SelectedItem as CamadaDados.Financeiro.Cadastros.TRegistro_CadCondPgto).St_comentrada;
                (bsDuplicata.Current as CamadaDados.Financeiro.Duplicata.TRegistro_LanDuplicata).St_venctoferiado = (cbCondPgto.SelectedItem as CamadaDados.Financeiro.Cadastros.TRegistro_CadCondPgto).St_venctoemferiado;
                (bsDuplicata.Current as CamadaDados.Financeiro.Duplicata.TRegistro_LanDuplicata).Parcelas.Clear();
                (bsDuplicata.Current as CamadaDados.Financeiro.Duplicata.TRegistro_LanDuplicata).Parcelas = CamadaNegocio.Financeiro.Duplicata.TCN_LanDuplicata.calcularParcelas(bsDuplicata.Current as CamadaDados.Financeiro.Duplicata.TRegistro_LanDuplicata, null);
                bsDuplicata.ResetCurrentItem();
                dt_vencto.Enabled = (cbCondPgto.SelectedItem as CamadaDados.Financeiro.Cadastros.TRegistro_CadCondPgto).St_solicitardtvenctobool;
            }
        }

        private void bsParcelas_PositionChanged(object sender, EventArgs e)
        {
            if(bsParcelas.Count > 0)
                vl_parcela_padrao.Enabled = bsParcelas.Position != bsParcelas.Count - 1;
        }

        private void dt_vencto_Enter(object sender, EventArgs e)
        {
            dt_vencto.Select(0, dt_vencto.Text.Length - 1);
        }

        private void dt_vencto_Leave(object sender, EventArgs e)
        {
            if (bsParcelas.Current != null)
            {
                CamadaNegocio.Financeiro.Duplicata.TCN_LanDuplicata.validaDataVencimento(bsParcelas.Current as CamadaDados.Financeiro.Duplicata.TRegistro_LanDuplicata, bsParcelas.Position);
                dt_vencto.Text = (bsParcelas.Current as CamadaDados.Financeiro.Duplicata.TRegistro_LanParcela).Dt_vencto.Value.ToString("dd/MM/yyyy");
                gParcelas.Refresh();
            }
        }

        private void vl_parcela_padrao_Leave(object sender, EventArgs e)
        {
            (bsParcelas.Current as CamadaDados.Financeiro.Duplicata.TRegistro_LanParcela).Vl_parcela_padrao = vl_parcela_padrao.Value;
            (bsParcelas.Current as CamadaDados.Financeiro.Duplicata.TRegistro_LanParcela).Vl_parcela = vl_parcela_padrao.Value;
            bsParcelas.EndEdit();
            CamadaNegocio.Financeiro.Duplicata.TCN_LanDuplicata.recalculaParcelas((bsDuplicata.Current as CamadaDados.Financeiro.Duplicata.TRegistro_LanDuplicata), bsParcelas.Position, true);
            CamadaNegocio.Financeiro.Duplicata.TCN_LanDuplicata.recalculaParcelas((bsDuplicata.Current as CamadaDados.Financeiro.Duplicata.TRegistro_LanDuplicata), bsParcelas.Position, false);
            gParcelas.Refresh();
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            this.afterGrava();
        }

        private void TFDuplicataPDV_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
        }
    }
}
