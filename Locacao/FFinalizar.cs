using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Locacao
{
    public partial class TFFinalizar : Form
    {
        private CamadaDados.Locacao.TRegistro_Locacao rloc;
        public CamadaDados.Locacao.TRegistro_Locacao rLoc
        {
            get
            {
                if ((bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).lItens.Exists(p => p.St_processar))
                    return bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao;
                else
                    return null;
            }
            set { rloc = value; }
        }

        public TFFinalizar()
        {
            InitializeComponent();
            Height = Screen.PrimaryScreen.Bounds.Height - (Screen.PrimaryScreen.Bounds.Height / 10) * 1;
            Width = Screen.PrimaryScreen.Bounds.Width - (Screen.PrimaryScreen.Bounds.Width / 10) * 1;
        }

        private void afterGrava()
        {
            if (bsLocacao.Count > 0)
            {
                if ((bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).lItens.Exists(p => string.IsNullOrEmpty(p.Id_tabelastr) && p.St_processar))
                {
                    MessageBox.Show("Item selecionado não possui tabela preço!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if ((bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).lItens.Exists(p => p.St_processar))
                    DialogResult = DialogResult.OK;
                else
                    MessageBox.Show("Não existem itens para serem gravados!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Recalcular()
        {
            if (bsItens.Count > 0)
            {
                //Inserir QTD Horas Trabalhadas
                using (Componentes.TFQuantidade fQtde = new Componentes.TFQuantidade())
                {
                    TimeSpan total = CamadaDados.UtilData.Data_Servidor().Subtract((bsItens.Current as CamadaDados.Locacao.TRegistro_ItensLocacao).Dt_retirada.Value);
                    fQtde.Vl_default = (bsItens.Current as CamadaDados.Locacao.TRegistro_ItensLocacao).Tp_tabela.Equals("2") ?
                    Math.Round(decimal.Parse(total.TotalHours.ToString()), 2) : (bsItens.Current as CamadaDados.Locacao.TRegistro_ItensLocacao).Tp_tabela.Equals("3") ?
                    Math.Round(decimal.Parse(total.TotalDays.ToString()), 2) : (bsItens.Current as CamadaDados.Locacao.TRegistro_ItensLocacao).Tp_tabela.Equals("4") ?
                    Math.Round(decimal.Parse(total.TotalDays.ToString()), 2) / 30 : (bsItens.Current as CamadaDados.Locacao.TRegistro_ItensLocacao).Tp_tabela.Equals("5") ?
                    Math.Round(decimal.Parse(total.TotalDays.ToString()), 2) / 7 : (bsItens.Current as CamadaDados.Locacao.TRegistro_ItensLocacao).Tp_tabela.Equals("6") ?
                    Math.Round(decimal.Parse(total.TotalDays.ToString()), 2) / 15 : 0;
                    fQtde.Ds_label = (bsItens.Current as CamadaDados.Locacao.TRegistro_ItensLocacao).Tp_tabela.Equals("2") ?
                    "QTD Horas" : (bsItens.Current as CamadaDados.Locacao.TRegistro_ItensLocacao).Tp_tabela.Equals("3") ?
                    "QTD Dias" : (bsItens.Current as CamadaDados.Locacao.TRegistro_ItensLocacao).Tp_tabela.Equals("4") ?
                    "QTD Meses" : (bsItens.Current as CamadaDados.Locacao.TRegistro_ItensLocacao).Tp_tabela.Equals("5") ?
                    "QTD Semanas" : (bsItens.Current as CamadaDados.Locacao.TRegistro_ItensLocacao).Tp_tabela.Equals("6") ?
                    "QTD Quinzena" : string.Empty;
                    if (fQtde.ShowDialog() == DialogResult.OK)
                    {
                        if (fQtde.Quantidade > decimal.Zero)
                        {
                            (bsItens.Current as CamadaDados.Locacao.TRegistro_ItensLocacao).Quantidade = fQtde.Quantidade;
                            (bsItens.Current as CamadaDados.Locacao.TRegistro_ItensLocacao).BaseCalc = fQtde.Quantidade;
                        }
                        bsItens.ResetCurrentItem();
                    }
                }
            }
        }

        private void Calcular()
        {
            if (bsItens.Count > 0)
            {
                //Tabela UNIDADE e MILIMITRO
                if ((bsItens.Current as CamadaDados.Locacao.TRegistro_ItensLocacao).Tp_tabela.Equals("0") ||
                    (bsItens.Current as CamadaDados.Locacao.TRegistro_ItensLocacao).Tp_tabela.Equals("1"))
                {
                    //Inserir QTD 
                    using (Componentes.TFQuantidade fQtde = new Componentes.TFQuantidade())
                    {
                        fQtde.Vl_default = (bsItens.Current as CamadaDados.Locacao.TRegistro_ItensLocacao).Quantidade;
                        fQtde.Ds_label = "Quantidade";
                        if (fQtde.ShowDialog() == DialogResult.OK)
                        {
                            if (fQtde.Quantidade > decimal.Zero)
                            {
                                (bsItens.Current as CamadaDados.Locacao.TRegistro_ItensLocacao).Quantidade = fQtde.Quantidade;
                                (bsItens.Current as CamadaDados.Locacao.TRegistro_ItensLocacao).BaseCalc = fQtde.Quantidade;
                            }
                            bsItens.ResetCurrentItem();
                        }
                    }
                }
                else
                    MessageBox.Show("Tipo de tabela de preço não pode calcular desgaste do item!", "Mesagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void cbTodos_Click(object sender, EventArgs e)
        {
            if (bsItens.Count > 0)
            {
                (bsItens.DataSource as List<CamadaDados.Locacao.TRegistro_ItensLocacao>).ForEach(p => p.St_processar = cbTodos.Checked);
                bsItens.ResetBindings(true);
            }
        }

        private void TFFinalizar_Load(object sender, EventArgs e)
        {
            Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            //Buscar Itens disponiveis para devolucao
            bsLocacao.DataSource = new CamadaDados.Locacao.TList_Locacao() { rloc };
            (bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).lItens =
                new CamadaDados.Locacao.TCD_ItensLocacao().Select(
                    new Utils.TpBusca[]
                    {
                        new Utils.TpBusca()
                        {
                            vNM_Campo = "a.cd_empresa",
                            vOperador = "=",
                            vVL_Busca = "'" + (bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).Cd_empresa.Trim() + "'"
                        },
                        new Utils.TpBusca()
                        {
                            vNM_Campo = "a.id_locacao",
                            vOperador = "=",
                            vVL_Busca = (bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).Id_locacaostr
                        },
                        new Utils.TpBusca()
                        {
                            vNM_Campo = "a.dt_retirada",
                            vOperador = "is not",
                            vVL_Busca = "null"
                        },
                        new Utils.TpBusca()
                        {
                            vNM_Campo = "a.dt_fechamento",
                            vOperador = "is",
                            vVL_Busca = "null"
                        },
                        new Utils.TpBusca()
                        {
                            vNM_Campo = "isnull(a.st_registro, 'A')",
                            vOperador = "<>",
                            vVL_Busca = "'C'"
                        }
                    }, 0, string.Empty, false);
            if (bsItens.Current != null)
            {
                //Buscar Acessorios
                (bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).lItens.ForEach(p =>
                    p.lAcessorio = CamadaNegocio.Locacao.TCN_AcessoriosItem.buscar(p.Cd_empresa,
                                                                                   p.Id_locacaostr,
                                                                                   p.Id_itemlocstr,
                                                                                   string.Empty,
                                                                                   null));
            }
            bsLocacao.ResetCurrentItem();
        }

        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            afterGrava();
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void gItens_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                (bsItens.Current as CamadaDados.Locacao.TRegistro_ItensLocacao).St_processar =
                    !(bsItens.Current as CamadaDados.Locacao.TRegistro_ItensLocacao).St_processar;
                bsItens.ResetCurrentItem();
            }
        }

        private void TFFinalizar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                DialogResult = DialogResult.Cancel;
            else if (e.KeyCode.Equals(Keys.F10))
                bb_recalcular_Click(this, new EventArgs());
        }

        private void bb_recalcular_Click(object sender, EventArgs e)
        {
            if (!(bsItens.Current as CamadaDados.Locacao.TRegistro_ItensLocacao).Tp_tabela.Equals("4"))
            {
                if ((bsItens.Current as CamadaDados.Locacao.TRegistro_ItensLocacao).Tp_tabela.Equals("0") ||
                       (bsItens.Current as CamadaDados.Locacao.TRegistro_ItensLocacao).Tp_tabela.Equals("1"))
                    Calcular();
                else
                    Recalcular();
            }
            else
                MessageBox.Show("Não é possivel recalcular tempo de item com locação mensal!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void gAcessorios_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null)
                if (e.ColumnIndex.Equals(0))
                {
                    if (e.Value.ToString().Trim().ToUpper().Equals("BAIXADO"))
                        gAcessorios.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Blue;
                    else
                        gAcessorios.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
                }
        }
    }
}
