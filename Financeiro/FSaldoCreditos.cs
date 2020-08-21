using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using Utils;

namespace Financeiro
{
    public partial class TFSaldoCreditos : Form
    {
        public string Cd_empresa
        {get;set;}
        public string Cd_clifor
        { get; set; }
        public decimal Vl_financeiro
        { get; set; }
        public string Tp_mov
        { get; set; }
        public string Id_locacao
        { get; set; }
        public bool St_adtoUnico { get; set; }

        public List<CamadaDados.Financeiro.Adiantamento.TRegistro_LanAdiantamento> lSaldo
        {
            get
            {
                if (bsAdto.Count > 0)
                    return (bsAdto.List as List<CamadaDados.Financeiro.Adiantamento.TRegistro_LanAdiantamento>).FindAll(p => p.St_processar);
                else return null;
            }
        }

        public TFSaldoCreditos()
        {
            InitializeComponent();
            this.St_adtoUnico = false;
        }

        private void afterBusca()
        {
            TpBusca[] filtro = new TpBusca[2];
            //Buscar adiantamentos com saldo
            filtro[0].vNM_Campo = "case when a.tp_movimento = 'C' then a.vl_pagar - a.vl_receber else a.vl_receber - a.vl_pagar end";
            filtro[0].vOperador = ">";
            filtro[0].vVL_Busca = "0";
            //Excluir Adiantamentos originados pela locação
            filtro[1].vNM_Campo = string.Empty;
            filtro[1].vOperador = "not exists";
            filtro[1].vVL_Busca = "(select 1 from TB_LOC_AdtoLocacao x " +
                                   "where x.Id_Adto = a.Id_Adto) ";
            if (!string.IsNullOrEmpty(id_adto.Text))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.ID_Adto";
                filtro[filtro.Length - 1].vVL_Busca = id_adto.Text;
                filtro[filtro.Length - 1].vOperador = "=";
            }
            if (!string.IsNullOrEmpty(Cd_empresa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.CD_Empresa";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
                filtro[filtro.Length - 1].vOperador = "=";
            }
            else
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = string.Empty;
                filtro[filtro.Length - 1].vOperador = "EXISTS";
                filtro[filtro.Length - 1].vVL_Busca = "(select 1 from tb_div_usuario_x_empresa x " +
                                                      "where x.cd_empresa = a.cd_empresa " +
                                                      "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                                                      "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                                      "         where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))";
            }
            if (!string.IsNullOrEmpty(CD_Clifor.Text))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.CD_Clifor";
                filtro[filtro.Length - 1].vVL_Busca = "'" + CD_Clifor.Text.Trim() + "'";
                filtro[filtro.Length - 1].vOperador = "=";
            }
            if (!string.IsNullOrEmpty(Tp_mov))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.TP_Movimento";
                filtro[filtro.Length - 1].vVL_Busca = "(" + Tp_mov + ")";
                filtro[filtro.Length - 1].vOperador = "in";
            }

            if ((!string.IsNullOrEmpty(DT_Inicial.Text)) && (DT_Inicial.Text.Trim() != "/  /"))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.dt_lancto";
                filtro[filtro.Length - 1].vOperador = ">=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + DateTime.Parse(DT_Inicial.Text).ToString("yyyyMMdd") + "'";
            }
            if ((!string.IsNullOrEmpty(DT_Final.Text)) && (DT_Final.Text.Trim() != "/  /"))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.dt_lancto";
                filtro[filtro.Length - 1].vOperador = "<=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + DateTime.Parse(DT_Final.Text).ToString("yyyyMMdd") + " 23:59:59'";
            }

            bsAdto.DataSource = new CamadaDados.Financeiro.Adiantamento.TCD_LanAdiantamento().Select(filtro, 0, string.Empty);
        }

        private void TFSaldoCreditos_Load(object sender, EventArgs e)
        {
            ShapeGrid.RestoreShape(this, gSaldoAdto);
            this.Icon = ResourcesUtils.TecnoAliance_ICO;
            pFiltro.set_FormatZero();
            vl_financeiro.Value = Math.Round(Vl_financeiro, 2, MidpointRounding.AwayFromZero);
            saldo_financeiro.Value = Vl_financeiro;
            if (!string.IsNullOrEmpty(Cd_clifor))
                if (CamadaNegocio.ConfigGer.TCN_CadParamGer.BuscaVL_Bool("ST_IDENT_CLIFOR_CRED", Cd_empresa, null).Trim().ToUpper().Equals("S"))
                {
                    CD_Clifor.Text = Cd_clifor;
                    CD_Clifor.Enabled = true;
                    BB_Clifor.Enabled = true;
                    afterBusca();
                }
                else
                {
                    CD_Clifor.Text = Cd_clifor;
                    CD_Clifor.Enabled = false;
                    BB_Clifor.Enabled = false;
                    afterBusca();
                }
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void gSaldoAdto_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                if(!(bsAdto.Current as CamadaDados.Financeiro.Adiantamento.TRegistro_LanAdiantamento).St_processar)
                    if (this.St_adtoUnico)
                    {
                        (bsAdto.List as CamadaDados.Financeiro.Adiantamento.TList_LanAdiantamento).ForEach(p =>
                            {
                                p.Vl_processar = decimal.Zero;
                                p.St_processar = false;
                            });
                        bsAdto.ResetBindings(true);
                    }
                    else if (vl_financeiro.Value <= (bsAdto.List as List<CamadaDados.Financeiro.Adiantamento.TRegistro_LanAdiantamento>).Sum(p => p.Vl_processar))
                    {
                        MessageBox.Show("Não existe mais saldo para devolver.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                (bsAdto.Current as CamadaDados.Financeiro.Adiantamento.TRegistro_LanAdiantamento).St_processar =
                    !(bsAdto.Current as CamadaDados.Financeiro.Adiantamento.TRegistro_LanAdiantamento).St_processar;
                if ((bsAdto.Current as CamadaDados.Financeiro.Adiantamento.TRegistro_LanAdiantamento).St_processar)
                {
                    vl_devolver.Enabled = true;
                    vl_devolver.Value = vl_financeiro.Value > decimal.Zero ? (bsAdto.Current as CamadaDados.Financeiro.Adiantamento.TRegistro_LanAdiantamento).Vl_total_devolver > saldo_financeiro.Value ?
                        saldo_financeiro.Value : (bsAdto.Current as CamadaDados.Financeiro.Adiantamento.TRegistro_LanAdiantamento).Vl_total_devolver :
                        (bsAdto.Current as CamadaDados.Financeiro.Adiantamento.TRegistro_LanAdiantamento).Vl_total_devolver;
                }
                else
                {
                    vl_devolver.Enabled = false;
                    (bsAdto.Current as CamadaDados.Financeiro.Adiantamento.TRegistro_LanAdiantamento).Vl_processar = decimal.Zero;
                }
                if(vl_financeiro.Value > decimal.Zero)
                    saldo_financeiro.Value = vl_financeiro.Value > decimal.Zero ? vl_financeiro.Value - (bsAdto.List as List<CamadaDados.Financeiro.Adiantamento.TRegistro_LanAdiantamento>).Sum(p=> p.Vl_processar) : decimal.Zero;
                bsAdto.ResetCurrentItem();
            }
        }

        private void vl_devolver_Leave(object sender, EventArgs e)
        {
            if (vl_financeiro.Value > decimal.Zero)
            {
                if (vl_financeiro.Value - (bsAdto.List as List<CamadaDados.Financeiro.Adiantamento.TRegistro_LanAdiantamento>).Sum(p => p.Vl_processar) < 0)
                    vl_devolver.Value -= Math.Abs(vl_financeiro.Value - (bsAdto.List as List<CamadaDados.Financeiro.Adiantamento.TRegistro_LanAdiantamento>).Sum(p => p.Vl_processar));
                if (vl_devolver.Value > (bsAdto.Current as CamadaDados.Financeiro.Adiantamento.TRegistro_LanAdiantamento).Vl_total_devolver)
                    vl_devolver.Value = (bsAdto.Current as CamadaDados.Financeiro.Adiantamento.TRegistro_LanAdiantamento).Vl_total_devolver;
                saldo_financeiro.Value = vl_financeiro.Value - (bsAdto.List as List<CamadaDados.Financeiro.Adiantamento.TRegistro_LanAdiantamento>).Sum(p => p.Vl_processar);
            }
        }

        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            if (vl_devolver.Focused)
                vl_devolver_Leave(this, new EventArgs());
            this.DialogResult = DialogResult.OK;
        }

        private void TFSaldoCreditos_FormClosing(object sender, FormClosingEventArgs e)
        {
            ShapeGrid.SaveShape(this, gSaldoAdto);
        }

        private void CD_Clifor_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveClifor("a.cd_clifor|=|'" + CD_Clifor.Text.Trim() + "'",
                                                    new Componentes.EditDefault[] { CD_Clifor },
                                                    new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
        }

        private void BB_Clifor_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { CD_Clifor }, string.Empty);
        }

        private void bb_buscar_Click(object sender, EventArgs e)
        {
            this.afterBusca();
        }

        private void TFSaldoCreditos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F7))
                this.afterBusca();
            else if (e.KeyCode.Equals(Keys.F4))
                this.DialogResult = DialogResult.OK;
        }

        private void bb_confirmar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void gSaldoAdto_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (gSaldoAdto.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.NotSortable)
                return;
            if (bsAdto.Count < 1)
                return;
            PropertyDescriptorCollection lP = TypeDescriptor.GetProperties(new CamadaDados.Financeiro.Adiantamento.TRegistro_LanAdiantamento());
            CamadaDados.Financeiro.Adiantamento.TList_LanAdiantamento lComparer;
            SortOrder direcao = SortOrder.None;
            if ((gSaldoAdto.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None) ||
                (gSaldoAdto.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending))
            {
                lComparer = new CamadaDados.Financeiro.Adiantamento.TList_LanAdiantamento(lP.Find(gSaldoAdto.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Ascending);
                foreach (DataGridViewColumn c in gSaldoAdto.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Ascending;
            }
            else
            {
                lComparer = new CamadaDados.Financeiro.Adiantamento.TList_LanAdiantamento(lP.Find(gSaldoAdto.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Descending);
                foreach (DataGridViewColumn c in gSaldoAdto.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Descending;
            }
            (bsAdto.List as CamadaDados.Financeiro.Adiantamento.TList_LanAdiantamento).Sort(lComparer);
            bsAdto.ResetBindings(false);
            gSaldoAdto.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = direcao;
        }
    }
}
