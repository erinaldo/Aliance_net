using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Proc_Commoditties
{
    public partial class TFProcessarRetiradaCaixa : Form
    {
        public bool St_emprestimo { get; set; }
        public decimal Vl_processar
        { get; set; }
        public string Id_caixa
        { get; set; }
        public List<CamadaDados.Financeiro.Cadastros.TRegistro_CadPortador> lPortador
        {
            get
            {
                if (bsPortador.Count > 0)
                    return (bsPortador.DataSource as CamadaDados.Financeiro.Cadastros.TList_CadPortador).FindAll(p=> p.Vl_pagtoPDV > 0);
                else
                    return null;
            }
        }

        public TFProcessarRetiradaCaixa()
        {
            InitializeComponent();
        }

        private void afterGrava()
        {
            if (saldo_informar.Value > decimal.Zero)
            {
                MessageBox.Show("Ainda existe saldo disponivel para processar retirada.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            this.DialogResult = DialogResult.OK;
        }

        private void RecalcularTotal()
        {
            if (bsPortador.Count > 0)
            {
                tot_informado.Value = (bsPortador.DataSource as CamadaDados.Financeiro.Cadastros.TList_CadPortador).Sum(p => p.Vl_pagtoPDV);
                //Testar se valor informar for maior que valor a processar
                if (tot_informado.Value <= vl_processar.Value)
                    saldo_informar.Value = vl_processar.Value - tot_informado.Value;
                else
                {
                    MessageBox.Show("Valor informado é maior que o valor PERMITIDO!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.ExcluirValor();
                }
            }
        }

        private void InformarValor()
        {
            if (bsPortador.Current != null)
                if (saldo_informar.Value > 0)
                {
                    if ((bsPortador.Current as CamadaDados.Financeiro.Cadastros.TRegistro_CadPortador).St_controletitulobool)
                    {
                        using (PDV.TFChequePDV fCheque = new PDV.TFChequePDV())
                        {
                            fCheque.Id_caixa = Id_caixa;
                            if (fCheque.ShowDialog() == DialogResult.OK)
                                if (fCheque.lCheque != null)
                                {
                                    (bsPortador.Current as CamadaDados.Financeiro.Cadastros.TRegistro_CadPortador).Vl_pagtoPDV = fCheque.lCheque.Sum(p => p.Vl_titulo);
                                    fCheque.lCheque.ForEach(p => (bsPortador.Current as CamadaDados.Financeiro.Cadastros.TRegistro_CadPortador).lCheque.Add(p));
                                    if ((bsPortador.Current as CamadaDados.Financeiro.Cadastros.TRegistro_CadPortador).lCheque.Sum(p => p.Vl_titulo) > vl_processar.Value)
                                    {
                                        MessageBox.Show("Valor informado é maior que o valor PERMITIDO!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        ExcluirValor();
                                    }
                                    bsPortador.ResetCurrentItem();
                                    RecalcularTotal();
                                }
                        }
                    }
                    else
                        using (Componentes.TFQuantidade fValor = new Componentes.TFQuantidade())
                        {
                            fValor.Casas_decimais = 2;
                            fValor.Vl_saldo = saldo_informar.Value;
                            fValor.Ds_label = "Vl. Retirada";
                            if (fValor.ShowDialog() == DialogResult.OK)
                            {
                                (bsPortador.Current as CamadaDados.Financeiro.Cadastros.TRegistro_CadPortador).Vl_pagtoPDV = fValor.Quantidade;
                                bsPortador.ResetCurrentItem();
                                this.RecalcularTotal();
                            }
                        }
                }
                else
                    MessageBox.Show("Não existe saldo informar.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ExcluirValor()
        {
            if (bsPortador.Current != null)
            {
                (bsPortador.Current as CamadaDados.Financeiro.Cadastros.TRegistro_CadPortador).Vl_pagtoPDV = decimal.Zero;
                (bsPortador.Current as CamadaDados.Financeiro.Cadastros.TRegistro_CadPortador).lCheque.RemoveAll(p=> p.Vl_titulo > decimal.Zero);
                bsPortador.ResetCurrentItem();
                this.RecalcularTotal();
            }
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btn_Inserir_Item_Click(object sender, EventArgs e)
        {
            this.InformarValor();
        }

        private void btn_Deleta_Item_Click(object sender, EventArgs e)
        {
            this.ExcluirValor();
        }

        private void TFProcessarRetiradaCaixa_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            vl_processar.Value = Vl_processar;
            saldo_informar.Value = Vl_processar;
            bsPortador.DataSource = new CamadaDados.Financeiro.Cadastros.TCD_CadPortador().Select(
                                    new Utils.TpBusca[]
                                    {
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "a.tp_portadorPDV",
                                            vOperador = "=",
                                            vVL_Busca = "'A'"
                                        },
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "isnull(a.st_devcredito, 'N')",
                                            vOperador = "<>",
                                            vVL_Busca = "'S'"
                                        },
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "a.st_cartaocredito",
                                            vOperador = "=",
                                            vVL_Busca = "1"
                                        },
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "isnull(a.st_EntregaFutura, 'N')",
                                            vOperador = "<>",
                                            vVL_Busca = "'S'"
                                        },
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "isnull(a.st_cartafrete, 'N')",
                                            vOperador = "<>",
                                            vVL_Busca = "'S'"
                                        }
                                    }, 0, string.Empty, string.Empty);
        }

        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            this.afterGrava();
        }

        private void TFProcessarRetiradaCaixa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
            else if (e.Control && e.KeyCode.Equals(Keys.F10))
                this.InformarValor();
            else if (e.Control && e.KeyCode.Equals(Keys.F12))
                this.ExcluirValor();
        }
    }
}
