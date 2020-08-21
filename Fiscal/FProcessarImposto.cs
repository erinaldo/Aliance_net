using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Fiscal
{
    public partial class TFProcessarImposto : Form
    {
        public string Cd_empresa
        { get; set; }
        public string Cd_imposto
        { get; set; }
        public string Dt_lote
        { get; set; }
        public decimal Vl_debito
        { get; set; }
        public decimal Vl_credito
        { get; set; }
        public bool St_lote
        { get; set; }

        public CamadaDados.Fiscal.TRegistro_LoteImposto rImp
        {
            get
            {
                if (bsLoteImposto.Current != null)
                    return bsLoteImposto.Current as CamadaDados.Fiscal.TRegistro_LoteImposto;
                else
                    return null;
            }
        }

        public TFProcessarImposto()
        {
            InitializeComponent();
            this.Cd_empresa = string.Empty;
            this.Cd_imposto = string.Empty;
            this.Dt_lote = string.Empty;
            this.Vl_debito = decimal.Zero;
            this.Vl_credito = decimal.Zero;
            this.St_lote = false;
        }

        private void afterBusca()
        {
            //Buscar fechamentos de caixa da conta gerencial
            bsLoteImposto.DataSource = new CamadaDados.Fiscal.TCD_LoteImposto().Select(
                                        new Utils.TpBusca[]
                                        {
                                            new Utils.TpBusca()
                                            {
                                                vNM_Campo = "a.cd_empresa",
                                                vOperador = "=",
                                                vVL_Busca = "'" + CD_Empresa.Text.Trim() + "'"
                                            },
                                            new Utils.TpBusca()
                                            {
                                                vNM_Campo = "a.cd_imposto",
                                                vOperador = "=",
                                                vVL_Busca = cd_imposto.Text
                                            }
                                        }, 0, string.Empty, "a.dt_lote desc");
        }

        private void afterGrava()
        {
            if (this.St_lote)
                this.DialogResult = DialogResult.Cancel;
            else
            {
                bsLoteImposto.AddNew();
                (bsLoteImposto.Current as CamadaDados.Fiscal.TRegistro_LoteImposto).Cd_empresa = CD_Empresa.Text;
                (bsLoteImposto.Current as CamadaDados.Fiscal.TRegistro_LoteImposto).Cd_impostostr = cd_imposto.Text;
                (bsLoteImposto.Current as CamadaDados.Fiscal.TRegistro_LoteImposto).Dt_lotestr = dt_lancto.Text;
                (bsLoteImposto.Current as CamadaDados.Fiscal.TRegistro_LoteImposto).Vl_credito = vl_credito.Value;
                (bsLoteImposto.Current as CamadaDados.Fiscal.TRegistro_LoteImposto).Vl_debito = vl_debito.Value;
                (bsLoteImposto.Current as CamadaDados.Fiscal.TRegistro_LoteImposto).Ds_observacao = ds_observacao.Text;
                this.DialogResult = DialogResult.OK;
            }
        }

        private void afterExclui()
        {
            if (bsLoteImposto.Current != null)
            {
                if (MessageBox.Show("Confirma estorno do lote fiscal selecionado?\r\n" +
                                    "Se existir lote fiscal com data posterior a data do lote a ser estornado,\r\n" +
                                    "os mesmos tambem serão estornados.",
                                    "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                    == DialogResult.Yes)
                {
                    CamadaNegocio.Fiscal.TCN_LoteImposto.Excluir(bsLoteImposto.Current as CamadaDados.Fiscal.TRegistro_LoteImposto, null);
                    MessageBox.Show("Lote Fiscal excluido com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.afterBusca();
                }
            }
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void TFProcessarImposto_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, dataGridDefault1);
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            CD_Empresa.Text = this.Cd_empresa;
            cd_imposto.Text = this.Cd_imposto;
            dt_lancto.Text = this.Dt_lote;
            vl_credito.Value = this.Vl_credito;
            vl_debito.Value = this.Vl_debito;
            this.afterBusca();
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            this.afterGrava();
        }

        private void TFProcessarImposto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.afterGrava();
            else if (e.KeyCode.Equals(Keys.F5))
                this.afterExclui();
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
        }

        private void BB_Excluir_Click(object sender, EventArgs e)
        {
            this.afterExclui();
        }

        private void TFProcessarImposto_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, dataGridDefault1);

        }
    }
}
