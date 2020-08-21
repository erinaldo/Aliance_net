using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Financeiro;

namespace Gerencia.Financeiro
{
    public partial class TFDetalhesCResultado : Form
    {
        public System.Collections.IList Lista
        { get; set; }

        public TFDetalhesCResultado()
        {
            InitializeComponent();
        }

        private void afterBusca()
        {
            if (Lista.Count > 0)
            {
                bsDetalhe.DataSource = new CamadaDados.Financeiro.CCustoLan.TCD_LanCCustoLancto().Select(
                                        new Utils.TpBusca[]
                                        {
                                            new Utils.TpBusca()
                                            {
                                                vNM_Campo = "a.cd_empresa",
                                                vOperador = "=",
                                                vVL_Busca = "'" + (Lista[0] as CamadaDados.Financeiro.ProvisaoDRG.TRegistro_LanProvisaoDRG).Cd_empresa.Trim() + "'"
                                            },
                                            new Utils.TpBusca()
                                            {
                                                vNM_Campo = "a.cd_centroresult",
                                                vOperador = "=",
                                                vVL_Busca = "'" + (Lista[0] as CamadaDados.Financeiro.ProvisaoDRG.TRegistro_LanProvisaoDRG).Cd_centroresult.Trim() + "'"
                                            },
                                            new Utils.TpBusca()
                                            {
                                                vNM_Campo = "month(a.dt_lancto)",
                                                vOperador = "=",
                                                vVL_Busca = (Lista[0] as CamadaDados.Financeiro.ProvisaoDRG.TRegistro_LanProvisaoDRG).Mes.ToString()
                                            },
                                            new Utils.TpBusca()
                                            {
                                                vNM_Campo = "year(a.dt_lancto)",
                                                vOperador = "=",
                                                vVL_Busca = (Lista[0] as CamadaDados.Financeiro.ProvisaoDRG.TRegistro_LanProvisaoDRG).Ano.ToString()
                                            }
                                        }, 0, string.Empty);
                tot_valor.Value = (bsDetalhe.List as CamadaDados.Financeiro.CCustoLan.TList_LanCCustoLancto).Sum(p => p.Vl_lancto);
            }
        }

        private void AlterarCResultado()
        {
            if (bsDetalhe.Current != null)
                using (TFAlterarCResultado fAlterarCCusto = new TFAlterarCResultado())
                {
                    fAlterarCCusto.rCusto = bsDetalhe.Current as CamadaDados.Financeiro.CCustoLan.TRegistro_LanCCustoLancto;
                    if (fAlterarCCusto.ShowDialog() == DialogResult.OK)
                        try
                        {
                            CamadaNegocio.Financeiro.CCustoLan.TCN_LanCCustoLancto.Gravar(fAlterarCCusto.rCusto, null);
                            MessageBox.Show("Lançamento Centro Resultado alterado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    this.afterBusca();
                }
            else
                MessageBox.Show("Obrigatorio selecionar lançamento centro resultado para alterar.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void TFDetalhesCResultado_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            this.afterBusca();
        }

        private void bb_alterarccusto_Click(object sender, EventArgs e)
        {
            this.AlterarCResultado();
        }

        private void gDetalhe_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (gDetalhe.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.NotSortable)
                return;
            if (bsDetalhe.Count < 1)
                return;
            PropertyDescriptorCollection lP = TypeDescriptor.GetProperties(new CamadaDados.Financeiro.CCustoLan.TRegistro_LanCCustoLancto());
            CamadaDados.Financeiro.CCustoLan.TList_LanCCustoLancto lComparer;
            SortOrder direcao = SortOrder.None;
            if ((gDetalhe.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None) ||
                (gDetalhe.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending))
            {
                lComparer = new CamadaDados.Financeiro.CCustoLan.TList_LanCCustoLancto(lP.Find(gDetalhe.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Ascending);
                foreach (DataGridViewColumn c in gDetalhe.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Ascending;
            }
            else
            {
                lComparer = new CamadaDados.Financeiro.CCustoLan.TList_LanCCustoLancto(lP.Find(gDetalhe.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Descending);
                foreach (DataGridViewColumn c in gDetalhe.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Descending;
            }
            (bsDetalhe.List as CamadaDados.Financeiro.CCustoLan.TList_LanCCustoLancto).Sort(lComparer);
            bsDetalhe.ResetBindings(false);
            gDetalhe.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = direcao;
        }
    }
}
