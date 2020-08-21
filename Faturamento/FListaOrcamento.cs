using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Faturamento
{
    public partial class TFListaOrcamento : Form
    {
        public string Nr_orcamento
        { get; set; }

        public List<CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento_Item> lItens
        {
            get
            {
                return (bsItens.List as CamadaDados.Faturamento.Orcamento.TList_Orcamento_Item).FindAll(p => p.St_faturar);
            }
        }

        public TFListaOrcamento()
        {
            InitializeComponent();
        }

        private void cbProcessar_Click(object sender, EventArgs e)
        {
            if (bsItens.Count > 0)
            {
                (bsItens.List as CamadaDados.Faturamento.Orcamento.TList_Orcamento_Item).ForEach(p =>
                    {
                        p.St_faturar = cbProcessar.Checked;
                        p.Qtd_faturar = decimal.Zero;
                    });
                bsItens.ResetBindings(true);
            }
        }

        private void gItens_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                (bsItens.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento_Item).St_faturar =
                    !(bsItens.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento_Item).St_faturar;
                if (!(bsItens.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento_Item).St_faturar)
                    (bsItens.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento_Item).Qtd_faturar = decimal.Zero;
                else
                    (bsItens.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento_Item).Qtd_faturar =
                        (bsItens.Current as CamadaDados.Faturamento.Orcamento.TRegistro_Orcamento_Item).Sd_faturar;
                bsItens.ResetCurrentItem();
            }
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void TFListaOrcamento_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.DialogResult = DialogResult.OK;
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
        }

        private void TFListaOrcamento_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            //Buscar itens do orcamento
            bsItens.DataSource = CamadaNegocio.Faturamento.Orcamento.TCN_Orcamento_Item.Buscar(Nr_orcamento, true, false, null);
        }
    }
}
