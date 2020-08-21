using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Financeiro
{
    public partial class TFListaChTroco : Form
    {
        public string Cd_empresa
        { get; set; }
        public decimal Vl_troco
        { get; set; }

        public CamadaDados.Financeiro.Titulo.TList_RegLanTitulo lCh
        {
            get
            {
                if (bsTitulos.Count > 0)
                    return bsTitulos.List as CamadaDados.Financeiro.Titulo.TList_RegLanTitulo;
                else
                    return null;
            }
        }

        public TFListaChTroco()
        {
            InitializeComponent();
        }

        private void ExcluirCh()
        {
            if (bsTitulos.Current != null)
                if (MessageBox.Show("Confirma exclusão do cheque selecionado?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                     MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    vl_saldo.Value += (bsTitulos.Current as CamadaDados.Financeiro.Titulo.TRegistro_LanTitulo).Vl_titulo;
                    bsTitulos.RemoveCurrent();
                }
        }

        private void TFListaChTroco_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            this.cd_empresa.Text = Cd_empresa;
            this.vl_troco.Value = Vl_troco;
            this.vl_saldo.Value = Vl_troco;
            bsTitulos.DataSource = new CamadaDados.Financeiro.Titulo.TList_RegLanTitulo();
        }

        private void cmc7_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter) &&
                (!string.IsNullOrEmpty(cmc7.Text)))
            {
                string nr_cheque = cmc7.Text;
                if (cmc7.Text.Trim().Substring(0, 1).Equals("<"))
                    nr_cheque = cmc7.Text.Trim().Substring(13, 6);
                CamadaDados.Financeiro.Titulo.TList_RegLanTitulo lCh =
                    new CamadaDados.Financeiro.Titulo.TCD_LanTitulo().Select(
                    new Utils.TpBusca[]
                    {
                        new Utils.TpBusca()
                        {
                            vNM_Campo = "a.cd_empresa",
                            vOperador = "=",
                            vVL_Busca = "'"  + cd_empresa.Text.Trim() + "'"
                        },
                        new Utils.TpBusca()
                        {
                            vNM_Campo = "a.nr_cheque",
                            vOperador = "=",
                            vVL_Busca = "'" + nr_cheque.Trim() + "'"
                        },
                        new Utils.TpBusca()
                        {
                            vNM_Campo = "a.tp_titulo",
                            vOperador = "=",
                            vVL_Busca = "'P'"
                        },
                        new Utils.TpBusca()
                        {
                            vNM_Campo = "isnull(a.status_compensado, 'N')",
                            vOperador = "=",
                            vVL_Busca = "'T'"
                        },
                        new Utils.TpBusca()
                        {
                            vNM_Campo = string.Empty,
                            vOperador = "not exists",
                            vVL_Busca = "(select 1 from tb_pdv_trocoCH x " +
                                        "where x.cd_empresa = a.cd_empresa " +
                                        "and x.cd_banco = a.cd_banco " +
                                        "and x.nr_lanctocheque = a.nr_lanctocheque)"
                        }
                    }, 1, string.Empty, string.Empty);
                if (lCh.Count > 0)
                {
                    if (lCh[0].Vl_titulo <= vl_saldo.Value)
                    {
                        vl_saldo.Value -= lCh[0].Vl_titulo;
                        bsTitulos.Add(lCh[0]);
                        bsTitulos.ResetBindings(true);
                        cmc7.Clear();
                    }
                    else
                        MessageBox.Show("Valor do cheque maior que o saldo restante do troco.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btn_Deleta_Item_Click(object sender, EventArgs e)
        {
            this.ExcluirCh();
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void TFListaChTroco_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.DialogResult = DialogResult.OK;
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
            else if (e.Control && e.KeyCode.Equals(Keys.F12))
                this.ExcluirCh();
        }
    }
}
