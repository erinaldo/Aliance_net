using CamadaDados.Faturamento.PDV;
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
    public partial class TFFechaCaixaOperacional : Form
    {
        public string Id_caixa
        { get; set; }
        public string pLogin
        { get; set; }
        private bool st_ignorar = false;

        public List<CamadaDados.Financeiro.Cadastros.TRegistro_CadPortador> lPortador
        {
            get
            {
                if (bsPortador.Count > 0)
                    return (bsPortador.DataSource as CamadaDados.Financeiro.Cadastros.TList_CadPortador).FindAll(p => p.Vl_pagtoPDV > decimal.Zero);
                else
                    return null;
            }
        }

        public TFFechaCaixaOperacional()
        {
            InitializeComponent();
        }

        private void afterGrava()
        {
            //Verificar se existe sessao aberta para o usuario
            if (new TCD_Sessao().BuscarEscalar(
                            new Utils.TpBusca[]
                            {
                                            new Utils.TpBusca()
                                            {
                                                vNM_Campo = "a.login",
                                                vOperador = "=",
                                                vVL_Busca = "'" + pLogin.Trim() + "'"
                                            },
                                            new Utils.TpBusca()
                                            {
                                                vNM_Campo = "isnull(a.st_registro, 'A')",
                                                vOperador = "<>",
                                                vVL_Busca = "'F'"
                                            }
                            }, "1") == null)
            {
                if (bsPortador.Count > 0)
                {
                    if (vl_fechamento.Focused)
                        (bsPortador.Current as CamadaDados.Financeiro.Cadastros.TRegistro_CadPortador).Vl_pagtoPDV = vl_fechamento.Value;
                    if (!(bsPortador.List as CamadaDados.Financeiro.Cadastros.TList_CadPortador).Exists(p => p.Vl_pagtoPDV > decimal.Zero))
                        if ((new TCD_CaixaPDV().BuscarEscalarMovCaixa(
                                new Utils.TpBusca[]
                                {
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "a.id_caixa",
                                    vOperador = "=",
                                    vVL_Busca = Id_caixa
                                }
                                }, "1") != null) ||
                            (new TCD_CaixaPDV().BuscarEscalar(
                                new Utils.TpBusca[]
                                {
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "a.id_caixa",
                                    vOperador = "=",
                                    vVL_Busca = Id_caixa
                                },
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "a.vl_suprimento",
                                    vOperador = ">",
                                    vVL_Busca = "0"
                                }

                                }, "1") != null))
                        {
                            if (MessageBox.Show("Caixa possui movimentação. Deseja informar valor de fechamento para os portadores movimentados?",
                                "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                return;
                        }
                    //Buscar Portadores com Movimento
                    CamadaDados.Financeiro.Cadastros.TList_CadPortador lPort =
                        new CamadaDados.Financeiro.Cadastros.TCD_CadPortador().Select(
                            new Utils.TpBusca[]
                            {
                            new Utils.TpBusca()
                            {
                                vNM_Campo = string.Empty,
                                vOperador = "exists",
                                vVL_Busca = "(select 1 from vtb_pdv_movcaixa x " +
                                            "where x.cd_portador = a.cd_portador " +
                                            "and x.id_caixa = " + Id_caixa + ") "
                            }
                            }, 0, string.Empty, string.Empty);

                    List<string> lista = new List<string>();
                    (bsPortador.DataSource as CamadaDados.Financeiro.Cadastros.TList_CadPortador).ForEach(p =>
                    {
                        if (p.Vl_pagtoPDV.Equals(0))
                        {
                            if (lPort.Exists(x => x.Cd_portador.Equals(p.Cd_portador)))
                                lista.Add(lPort.Find(x => x.Cd_portador.Equals(p.Cd_portador)).Ds_portador);
                        }
                    });
                    if (lista.Count > decimal.Zero)
                    {
                        string msg = string.Empty;
                        if (lista.Count > 1)
                            for (int i = 0; lista.Count > i; i++)
                                msg += lista[i].Trim() + "\r\n";
                        if (MessageBox.Show((lista.Count == 1 ? "O portador " + lista[0].Trim() + " possui movimento!" :
                            "Os portadores possuem movimento:\r\n" + msg) + "\r\nDeseja informar valor de fechamento para os portadores movimentados? ", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                            == DialogResult.Yes)
                            return;
                    }

                    //Buscar crédito avulso
                    if (st_ignorar.Equals(false))
                    {
                        CamadaDados.Financeiro.Adiantamento.TList_LanAdiantamento lCredAvulso
                            = CamadaNegocio.Financeiro.Adiantamento.TCN_LanAdiantamento.Buscar(string.Empty,
                                                                                               string.Empty,
                                                                                               string.Empty,
                                                                                               string.Empty,
                                                                                               string.Empty,
                                                                                               string.Empty,
                                                                                               decimal.Zero,
                                                                                               string.Empty,
                                                                                               string.Empty,
                                                                                               decimal.Zero,
                                                                                               decimal.Zero,
                                                                                               false,
                                                                                               false,
                                                                                               false,
                                                                                               string.Empty,
                                                                                               false,
                                                                                               false,
                                                                                               Id_caixa,
                                                                                               string.Empty,
                                                                                               0,
                                                                                               string.Empty,
                                                                                               null);
                        if (lCredAvulso.Count > 0)
                        {
                            if (MessageBox.Show("Houve lançamento de crédito avulso para o caixa. \r\nDeseja informar o valor referente?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                                == DialogResult.Yes) { st_ignorar = true; return;  }
                        }
                    }


                }
                this.DialogResult = DialogResult.OK;
            }
            else
                MessageBox.Show("Existe sessão aberta para o Usuário." + pLogin.Trim() + "\r\n" +
                                "Para fazer o fechamento caixa, feche a tela de venda", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            this.afterGrava();
        }

        private void TFFechaCaixaOperacional_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, gPortador);
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
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
                                            vNM_Campo = "isnull(a.st_cartafrete, 'N')",
                                            vOperador = "<>",
                                            vVL_Busca = "'S'"
                                        },
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "isnull(a.st_entregafutura, 'N')",
                                            vOperador = "<>",
                                            vVL_Busca = "'S'"
                                        }
                                    }, 0, string.Empty, string.Empty);
        }

        private void bb_voltar_Click(object sender, EventArgs e)
        {
            bsPortador.MovePrevious();
            vl_fechamento.Focus();
        }

        private void bb_avancar_Click(object sender, EventArgs e)
        {
            bsPortador.MoveNext();
            vl_fechamento.Focus();
        }

        private void vl_fechamento_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                (bsPortador.Current as CamadaDados.Financeiro.Cadastros.TRegistro_CadPortador).Vl_pagtoPDV = vl_fechamento.Value;
                bb_avancar_Click(this, new EventArgs());
                vl_fechamento.Select(0, vl_fechamento.Value.ToString("N2").Length);
            }
        }

        private void TFFechaCaixaOperacional_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
        }

        private void gPortador_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (gPortador.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.NotSortable)
                return;
            if (bsPortador.Count < 1)
                return;
            PropertyDescriptorCollection lP = TypeDescriptor.GetProperties(new CamadaDados.Financeiro.Cadastros.TRegistro_CadPortador());
            CamadaDados.Financeiro.Cadastros.TList_CadPortador lComparer;
            SortOrder direcao = SortOrder.None;
            if ((gPortador.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None) ||
                (gPortador.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending))
            {
                lComparer = new CamadaDados.Financeiro.Cadastros.TList_CadPortador(lP.Find(gPortador.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Ascending);
                foreach (DataGridViewColumn c in gPortador.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Ascending;
            }
            else
            {
                lComparer = new CamadaDados.Financeiro.Cadastros.TList_CadPortador(lP.Find(gPortador.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Descending);
                foreach (DataGridViewColumn c in gPortador.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Descending;
            }
            (bsPortador.List as CamadaDados.Financeiro.Cadastros.TList_CadPortador).Sort(lComparer);
            bsPortador.ResetBindings(false);
            gPortador.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = direcao;
        }

        private void TFFechaCaixaOperacional_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, gPortador);
        }
    }
}
