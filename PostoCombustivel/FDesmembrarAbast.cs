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
    public partial class TFDesmembrarAbast : Form
    {
        public List<CamadaDados.PostoCombustivel.TRegistro_VendaCombustivel> lVenda
        { get; set; }

        public CamadaDados.PostoCombustivel.TList_VendaCombustivel lDesdobro
        {
            get
            {
                if (bsDesdobro.Count > 0)
                    return bsDesdobro.List as CamadaDados.PostoCombustivel.TList_VendaCombustivel;
                else
                    return null;
            }
        }

        public TFDesmembrarAbast()
        {
            InitializeComponent();
        }

        private void afterGrava()
        {
            if (volume.Focused)
                volume_Leave(this, new EventArgs());
            if (Math.Round((bsDesdobro.List as CamadaDados.PostoCombustivel.TList_VendaCombustivel).Sum(p => p.Volumeabastecido), 3) !=
                Math.Round(lVenda.Sum(p=> p.Volumeabastecido), 3))
            {
                MessageBox.Show("A soma do volume abastecido dos desdobros não pode ser diferente do volume da venda de origem.",
                    "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            this.DialogResult = DialogResult.OK;
        }

        private void TFDesmembrarAbast_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, dataGridDefault1);
            Utils.ShapeGrid.RestoreShape(this, dataGridDefault2);
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;

            if (lVenda == null)
                using (TFBuscarAbastDesd fBusca = new TFBuscarAbastDesd())
                {
                    if (fBusca.ShowDialog() == DialogResult.OK)
                        if (fBusca.lVenda.Count > 0)
                            lVenda = fBusca.lVenda;
                        else
                            this.Close();
                    else
                        this.Close();
                }
            else
                this.Close();
            bsVendaCombustivel.DataSource = lVenda;
        }

        private void bb_avancar_Click(object sender, EventArgs e)
        {
            bsDesdobro.MoveNext();
        }

        private void bsDesdobro_PositionChanged(object sender, EventArgs e)
        {
            volume.Enabled = bsDesdobro.Position != bsDesdobro.Count - 1;
        }

        private void bb_desdobrar_Click(object sender, EventArgs e)
        {
            if (lVenda.Count > 0)
            {
                decimal vol = Math.Round(lVenda.Sum(p=> p.Volumeabastecido) / qtd_desdobro.Value, 3);
                CamadaDados.PostoCombustivel.TList_VendaCombustivel lDesd = new CamadaDados.PostoCombustivel.TList_VendaCombustivel();
                for (int i = 0; i < qtd_desdobro.Value; i++)
                    lDesd.Add(new CamadaDados.PostoCombustivel.TRegistro_VendaCombustivel()
                    {
                        Cd_empresa = lVenda[0].Cd_empresa,
                        Cd_local = lVenda[0].Cd_local,
                        Cd_produto = lVenda[0].Cd_produto,
                        Cd_unidade = lVenda[0].Cd_unidade,
                        Dt_abastecimento = CamadaDados.UtilData.Data_Servidor(),
                        Enderecofisicobico = lVenda[0].Enderecofisicobico,
                        Id_bico = lVenda[0].Id_bico,
                        Id_bomba = lVenda[0].Id_bomba,
                        Id_tanque = lVenda[0].Id_tanque,
                        Volumeabastecido = vol,
                        Vl_unitario = lVenda[0].Vl_unitario,
                        Vl_subtotal = vol * lVenda[0].Vl_unitario,
                        Tp_registro = "M",
                        St_registro = "A"
                    });
                bsDesdobro.DataSource = lDesd;
                (bsDesdobro[bsDesdobro.Count - 1] as CamadaDados.PostoCombustivel.TRegistro_VendaCombustivel).Volumeabastecido +=
                    lVenda.Sum(p=> p.Volumeabastecido) - (bsDesdobro.DataSource as CamadaDados.PostoCombustivel.TList_VendaCombustivel).Sum(p => p.Volumeabastecido);
            }
        }

        private void bb_voltar_Click(object sender, EventArgs e)
        {
            bsDesdobro.MovePrevious();
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            this.afterGrava();
        }

        private void volume_Leave(object sender, EventArgs e)
        {
            (bsDesdobro.Current as CamadaDados.PostoCombustivel.TRegistro_VendaCombustivel).Volumeabastecido = volume.Value;
            (bsDesdobro.Current as CamadaDados.PostoCombustivel.TRegistro_VendaCombustivel).Vl_subtotal =
                volume.Value * (bsDesdobro.Current as CamadaDados.PostoCombustivel.TRegistro_VendaCombustivel).Vl_unitario;

            //Recalcular valor do volume
            decimal soma = decimal.Zero;
            for (int i = 0; i < bsDesdobro.Position; i++)
                soma += (bsDesdobro[i] as CamadaDados.PostoCombustivel.TRegistro_VendaCombustivel).Volumeabastecido;
            if ((soma + (bsDesdobro.Current as CamadaDados.PostoCombustivel.TRegistro_VendaCombustivel).Volumeabastecido) > decimal.Subtract(lVenda.Sum(p=> p.Volumeabastecido), Convert.ToDecimal(0.1)))
            {
                (bsDesdobro.Current as CamadaDados.PostoCombustivel.TRegistro_VendaCombustivel).Volumeabastecido =
                    decimal.Subtract(lVenda.Sum(p=> p.Volumeabastecido), Convert.ToDecimal(0.1));
                (bsDesdobro.Current as CamadaDados.PostoCombustivel.TRegistro_VendaCombustivel).Vl_subtotal =
                    (bsDesdobro.Current as CamadaDados.PostoCombustivel.TRegistro_VendaCombustivel).Volumeabastecido *
                    (bsDesdobro.Current as CamadaDados.PostoCombustivel.TRegistro_VendaCombustivel).Vl_unitario;
                bsDesdobro.ResetCurrentItem();
            }
            soma = decimal.Zero;
            for (int i = 0; i <= bsDesdobro.Position; i++)
                soma += (bsDesdobro[i] as CamadaDados.PostoCombustivel.TRegistro_VendaCombustivel).Volumeabastecido;
            decimal vol = Math.Round((lVenda.Sum(p=> p.Volumeabastecido) - soma) / (qtd_desdobro.Value - (bsDesdobro.Position + 1)), 3);
            for (int i = bsDesdobro.Position + 1; i < bsDesdobro.Count; i++)
            {
                (bsDesdobro[i] as CamadaDados.PostoCombustivel.TRegistro_VendaCombustivel).Volumeabastecido = vol;
                (bsDesdobro[i] as CamadaDados.PostoCombustivel.TRegistro_VendaCombustivel).Vl_subtotal =
                    vol * (bsDesdobro[i] as CamadaDados.PostoCombustivel.TRegistro_VendaCombustivel).Vl_unitario;
            }
            (bsDesdobro[bsDesdobro.Count - 1] as CamadaDados.PostoCombustivel.TRegistro_VendaCombustivel).Volumeabastecido +=
                lVenda.Sum(p=> p.Volumeabastecido) - (bsDesdobro.DataSource as CamadaDados.PostoCombustivel.TList_VendaCombustivel).Sum(p => p.Volumeabastecido);

            bsDesdobro.ResetBindings(true);
        }

        private void TFDesmembrarAbast_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, dataGridDefault1);
            Utils.ShapeGrid.SaveShape(this, dataGridDefault2);
        }
    }
}
