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
    public partial class TFRetGuardaVol : Form
    {
        public string Cd_empresa
        { get; set; }
        public string Id_guardaVol
        { get; set; }
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
        public TFRetGuardaVol()
        {
            InitializeComponent();
        }

        private void TFRetGuardaVol_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            //Buscar Itens à retirar do guarda volume
            bsItensGuardaVolume.DataSource = new CamadaDados.Mudanca.TCD_ItensGuardaVolume().Select(
                new Utils.TpBusca[]
                {
                    new Utils.TpBusca()
                    {
                        vNM_Campo = "a.cd_empresa",
                        vOperador = "=",
                        vVL_Busca = "'" + Cd_empresa.Trim() + "'"
                    },
                    new Utils.TpBusca()
                    {
                        vNM_Campo = "a.id_guardavol",
                        vOperador = "=",
                        vVL_Busca = "'" + Id_guardaVol.Trim() + "'"
                    },
                    new Utils.TpBusca()
                    {
                        vNM_Campo = "isnull(a.quantidade - a.QTD_RETIRADA, 0)",
                        vOperador = ">",
                        vVL_Busca = "0"
                    },
                    new Utils.TpBusca()
                    {
                        vNM_Campo = "isnull(a.st_registro, 'A')",
                        vOperador = "<>",
                        vVL_Busca = "'C'"
                    }
                }, 0, string.Empty);
            bsItensGuardaVolume.ResetCurrentItem();
        }

        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void gItensGuardaVol_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                (bsItensGuardaVolume.Current as CamadaDados.Mudanca.TRegistro_ItensGuardaVolume).St_processar =
                         !(bsItensGuardaVolume.Current as CamadaDados.Mudanca.TRegistro_ItensGuardaVolume).St_processar;
                //Informar Quantidade e Vl.Seguro
                if ((bsItensGuardaVolume.Current as CamadaDados.Mudanca.TRegistro_ItensGuardaVolume).St_processar)
                {
                    using (Componentes.TFQuantidade fValor = new Componentes.TFQuantidade())
                    {
                        fValor.Ds_label = "Quantidade";
                        if (fValor.ShowDialog() == DialogResult.OK)
                            if (fValor.Quantidade > decimal.Zero)
                            {
                                if (fValor.Quantidade > (bsItensGuardaVolume.Current as CamadaDados.Mudanca.TRegistro_ItensGuardaVolume).SaldoRetirar)
                                {
                                    MessageBox.Show("Saldo à retirar é menor que a quantidade informada!\r\n\"" +
                                                    "Por favor insira uma quantidade menor!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    (bsItensGuardaVolume.Current as CamadaDados.Mudanca.TRegistro_ItensGuardaVolume).St_processar = false;
                                    return;
                                }
                                (bsItensGuardaVolume.Current as CamadaDados.Mudanca.TRegistro_ItensGuardaVolume).Qtd_retirar = fValor.Quantidade;
                            }
                    }
                    if ((bsItensGuardaVolume.Current as CamadaDados.Mudanca.TRegistro_ItensGuardaVolume).Qtd_retirar.Equals(decimal.Zero))
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

        private void TFRetGuardaVol_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.DialogResult = DialogResult.OK;
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
        }

        private void cbTodos_Click(object sender, EventArgs e)
        {
            if (bsItensGuardaVolume.Count > 0)
            {
                (bsItensGuardaVolume.List as CamadaDados.Mudanca.TList_ItensGuardaVolume).ForEach(p =>
                    {
                        p.St_processar = true;
                        p.Qtd_retirar = p.Quantidade;
                    });
                bsItensGuardaVolume.ResetBindings(true);
            }
        }
    }
}
