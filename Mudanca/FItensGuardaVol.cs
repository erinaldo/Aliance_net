using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Mudanca
{
    public partial class TFItensGuardaVol : Form
    {
        public List<CamadaDados.Mudanca.TRegistro_ItensGuardaVolume> lItens
        {
            get
            {
                if (bsItensGuardaVolume.Count > 0)
                    return (bsItensGuardaVolume.DataSource as CamadaDados.Mudanca.TList_ItensGuardaVolume).FindAll(p => p.St_processar);
                else
                    return null;
            }
        }
        public TFItensGuardaVol()
        {
            InitializeComponent();
        }

        private void afterGrava()
        {
            this.DialogResult = DialogResult.OK;
        }

        private void afterBusca()
        {
            CamadaDados.Mudanca.TList_ItensGuardaVolume lItensGuardaVol = new CamadaDados.Mudanca.TList_ItensGuardaVolume();
            CamadaDados.Mudanca.Cadastros.TList_CadItens lCadItens =
               CamadaNegocio.Mudanca.Cadastros.TCN_CadItens.Buscar(string.Empty, ds_itemBusca.Text, id_itempai.Text, "N", null);
            lCadItens.ForEach(p =>
            {
                lItensGuardaVol.Add(
                    new CamadaDados.Mudanca.TRegistro_ItensGuardaVolume()
                    {
                        Id_item = p.Id_item,
                        Ds_item = p.Ds_item
                    });
            });
            bsItensGuardaVolume.DataSource = lItensGuardaVol;
            bsItensGuardaVolume.ResetCurrentItem();
        }

        private void TFItensGuardaVol_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
        }

        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            this.afterGrava();
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void bb_buscar_Click(object sender, EventArgs e)
        {
            this.afterBusca();
        }

        private void id_itempai_Leave(object sender, EventArgs e)
        {
            string vParam = "a.id_item|=|'" + id_itempai.Text.Trim() + "';" +
                              "isnull(a.st_sintetico, 'N')|=|'S'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { id_itempai, ds_item },
                                            new CamadaDados.Mudanca.Cadastros.TCD_CadItens());
        }

        private void BB_Item_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_item|Item|200;" +
                             "a.id_item|Codigo|80";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { id_itempai, ds_item },
                new CamadaDados.Mudanca.Cadastros.TCD_CadItens(),
               "isnull(a.st_sintetico, 'N')|=|'S'");
        }

        private void TFItensGuardaVol_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
        }

        private void gItens_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                (bsItensGuardaVolume.Current as CamadaDados.Mudanca.TRegistro_ItensGuardaVolume).St_processar =
                         !(bsItensGuardaVolume.Current as CamadaDados.Mudanca.TRegistro_ItensGuardaVolume).St_processar;
                //Informar Quantidade
                if ((bsItensGuardaVolume.Current as CamadaDados.Mudanca.TRegistro_ItensGuardaVolume).St_processar)
                {
                    using (Componentes.TFQuantidade fValor = new Componentes.TFQuantidade())
                    {
                        fValor.Ds_label = "Quantidade";
                        if (fValor.ShowDialog() == DialogResult.OK)
                            if (fValor.Quantidade > decimal.Zero)
                                (bsItensGuardaVolume.Current as CamadaDados.Mudanca.TRegistro_ItensGuardaVolume).Quantidade = fValor.Quantidade;
                    }
                    if ((bsItensGuardaVolume.Current as CamadaDados.Mudanca.TRegistro_ItensGuardaVolume).Quantidade.Equals(decimal.Zero))
                        (bsItensGuardaVolume.Current as CamadaDados.Mudanca.TRegistro_ItensGuardaVolume).St_processar = false;
                    else
                    {
                        Utils.InputBox ibp = new Utils.InputBox();
                        ibp.Text = "Motivo";
                        string ds = ibp.ShowDialog();
                        (bsItensGuardaVolume.Current as CamadaDados.Mudanca.TRegistro_ItensGuardaVolume).Ds_observacao = ds;
                    }
                    bsItensGuardaVolume.ResetCurrentItem();
                }
            }
        }
    }
}
