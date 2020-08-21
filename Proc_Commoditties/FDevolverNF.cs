using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CamadaDados.Faturamento.NotaFiscal;
using CamadaNegocio.Faturamento.NotaFiscal;
using Utils;

namespace Proc_Commoditties
{
    public partial class TFDevolverNF : Form
    {
        public TRegistro_LanFaturamento rNf
        { get; set; }
        public TFDevolverNF()
        {
            InitializeComponent();
            Height = Screen.PrimaryScreen.Bounds.Height - (Screen.PrimaryScreen.Bounds.Height / 10) * 1;
            Width = Screen.PrimaryScreen.Bounds.Width - (Screen.PrimaryScreen.Bounds.Width / 10) * 1;
        }

        private void afterGrava()
        {
            if ((bsNotaFiscal.Current as TRegistro_LanFaturamento).ItensNota.Exists(p => p.St_processar))
                DialogResult = DialogResult.OK;
            else
                MessageBox.Show("Selecione um item para devolução!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void TFDevolverNF_Load(object sender, EventArgs e)
        {
            Icon = ResourcesUtils.TecnoAliance_ICO;
            bsNotaFiscal.DataSource = new TList_RegLanFaturamento() { rNf };
            (bsNotaFiscal.Current as TRegistro_LanFaturamento).ItensNota =
               new TCD_LanFaturamento_Item().Select(
                   new TpBusca[]
                   {
                       new TpBusca()
                       {
                           vNM_Campo = "a.cd_empresa",
                           vOperador = "=",
                           vVL_Busca = "'" + (bsNotaFiscal.Current as TRegistro_LanFaturamento).Cd_empresa.Trim() + "'"
                       },
                       new TpBusca()
                       {
                           vNM_Campo = "a.Nr_lanctofiscal",
                           vOperador = "=",
                           vVL_Busca = (bsNotaFiscal.Current as TRegistro_LanFaturamento).Nr_lanctofiscal.ToString()
                       },
                       new TpBusca()
                       {
                           vNM_Campo = "a.Quantidade - a.Qtd_devolvida",
                           vOperador = ">",
                           vVL_Busca = "0"
                       }
                   }, 0, string.Empty, string.Empty, string.Empty);
            bsNotaFiscal.ResetCurrentItem();
        }

        private void bb_gravar_Click(object sender, EventArgs e)
        {
            afterGrava();
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void gItensNota_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                (bsItensNota.Current as TRegistro_LanFaturamento_Item).St_processar =
                    !(bsItensNota.Current as TRegistro_LanFaturamento_Item).St_processar;
                //Informar quantidade a devolver
                if ((bsItensNota.Current as TRegistro_LanFaturamento_Item).St_processar)
                    using (Componentes.TFQuantidade fQtd = new Componentes.TFQuantidade())
                    {
                        fQtd.Vl_saldo = (bsItensNota.Current as TRegistro_LanFaturamento_Item).SaldoDevolver;
                        fQtd.Vl_default = (bsItensNota.Current as TRegistro_LanFaturamento_Item).SaldoDevolver;
                        fQtd.Ds_label = "QTD.Devolver";
                        if (fQtd.ShowDialog() == DialogResult.OK)      
                            if (fQtd.Quantidade > 0)
                            {
                                (bsItensNota.Current as TRegistro_LanFaturamento_Item).Qtd_devolver =
                                    fQtd.Quantidade;
                            }
                            else
                            {
                                MessageBox.Show("Obrigatório informar Quantidade a Devolver!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                (bsItensNota.Current as TRegistro_LanFaturamento_Item).St_processar = false;
                                return;
                            }
                        else
                        {
                            MessageBox.Show("Obrigatório informar Quantidade a Devolver!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            (bsItensNota.Current as TRegistro_LanFaturamento_Item).St_processar = false;
                            return;
                        }                        
                   }
                else
                    (bsItensNota.Current as TRegistro_LanFaturamento_Item).Qtd_devolver = decimal.Zero;
                bsItensNota.ResetCurrentItem();
            }
        }

        private void TFDevolverNF_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                DialogResult = DialogResult.Cancel;
        }

        private void cbTodos_Click(object sender, EventArgs e)
        {
            if (bsItensNota.Count > 0)
            {
                (bsNotaFiscal.Current as TRegistro_LanFaturamento).ItensNota.ForEach(p =>
                {
                    p.St_processar = cbTodos.Checked;
                    p.Qtd_devolver = cbTodos.Checked ? p.Quantidade : decimal.Zero;
                });
                bsNotaFiscal.ResetBindings(true);
            }
        }
    }
}
