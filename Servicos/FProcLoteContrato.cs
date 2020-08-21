using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FormBusca;

namespace Servicos
{
    public partial class TFProcLoteContrato : Form
    {
        public bool St_gerarCarne { get; set; }
        public List<CamadaDados.Servicos.TRegistro_Contrato> lContratos
        {
            get
            {
                if (bsContrato.Count > 0)
                    return (bsContrato.List as CamadaDados.Servicos.TList_Contrato).FindAll(p => p.St_processar);
                else
                    return null;
            }
        }

        public DateTime Dt_referencia
        { get { return dtPeriodo.Value; } }

        public TFProcLoteContrato()
        {
            InitializeComponent();
        }

        private void afterBusca()
        {
            if (cbEmpresa.SelectedValue == null)
            {
                MessageBox.Show("Obrigatorio informar empresa.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbEmpresa.Focus();
                return;
            }
            Utils.TpBusca[] filtro = new Utils.TpBusca[4];
            //Empresa
            filtro[0].vNM_Campo = "a.cd_empresa";
            filtro[0].vOperador = "=";
            filtro[0].vVL_Busca = "'" + cbEmpresa.SelectedValue.ToString() + "'";
            //Status
            filtro[1].vNM_Campo = "isnull(a.st_registro, 'A')";
            filtro[1].vOperador = "<>";
            filtro[1].vVL_Busca = "'E'";
            //Periodo
            filtro[2].vNM_Campo = "CONVERT(DATETIME,FLOOR(CONVERT(NUMERIC(30,10), case when a.dt_encerramento is null then getdate() else a.dt_encerramento end)))";
            filtro[2].vOperador = ">=";
            filtro[2].vVL_Busca = "CONVERT(DATETIME,FLOOR(CONVERT(NUMERIC(30,10),getdate())))";
            //Contratos não suspensos
            filtro[3].vNM_Campo = string.Empty;
            filtro[3].vOperador = "not exists";
            filtro[3].vVL_Busca = "(select 1 from tb_ose_suspcontrato x " +
                                  "where x.cd_empresa = a.cd_empresa " +
                                  "and x.nr_contrato = a.nr_contrato " +
                                  "and convert(datetime, floor(convert(numeric(30,10), x.dt_inisuspenso))) <= " +
                                  "convert(datetime, floor(convert(numeric(30,10), getdate()))) " +
                                  "and (x.dt_finsuspenso is null or convert(datetime, floor(convert(numeric(30,10), isnull(x.dt_finsuspenso, getdate())))) >= " +
                                  "convert(datetime, floor(convert(numeric(30,10), getdate())))))";
            //Carne
            if(St_gerarCarne)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "isnull(a.cd_condpgtocarne, '')";
                filtro[filtro.Length - 1].vOperador = "<>";
                filtro[filtro.Length - 1].vVL_Busca = "''";
            }
            else
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = string.Empty;
                filtro[filtro.Length - 1].vOperador = "not exists";
                filtro[filtro.Length - 1].vVL_Busca = "(select 1 from tb_ose_contrato_x_nf x " +
                                                      "inner join tb_fat_notafiscal y " +
                                                      "on x.cd_empresa = y.cd_empresa " +
                                                      "and x.nr_lanctofiscal = y.nr_lanctofiscal " +
                                                      "and isnull(y.st_registro, 'A') <> 'C' " +
                                                      "where x.cd_empresa = a.cd_empresa " +
                                                      "and x.nr_contrato = a.nr_contrato " +
                                                      "and month(y.dt_emissao) = " + dtPeriodo.Value.Month.ToString() + " " +
                                                      "and year(y.dt_emissao) = " + dtPeriodo.Value.Year.ToString() + ")";
            }
            CamadaDados.Servicos.TList_Contrato lContrato = new CamadaDados.Servicos.TCD_Contrato().Select(filtro, 0, string.Empty);
            tot_contrato.Value = lContrato.Sum(p => p.Vl_contrato);
            tot_faturar.Value = tot_contrato.Value;
            bsContrato.DataSource = lContrato;
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void BB_Buscar_Click(object sender, EventArgs e)
        {
            afterBusca();
        }

        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void TFProcLoteContrato_Load(object sender, EventArgs e)
        {
            if (St_gerarCarne)
                Text = "Gerar Carnê Contratos";
            Utils.ShapeGrid.RestoreShape(this, gContrato);
            Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pFiltro.set_FormatZero();
            //Buscar Empresa
            cbEmpresa.DataSource = new CamadaDados.Diversos.TCD_CadEmpresa().Select(
                                    new Utils.TpBusca[]
                                    {
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = string.Empty,
                                            vOperador = "exists",
                                            vVL_Busca = "(select 1 from tb_div_usuario_x_empresa x " +
                                                        "where x.cd_empresa = a.cd_empresa " +
                                                        "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                                                        "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                                        "       where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))"
                                        }
                                    }, 0, string.Empty);
            cbEmpresa.DisplayMember = "nm_empresa";
            cbEmpresa.ValueMember = "cd_empresa";
        }
        
        private void TFProcLoteContrato_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                DialogResult = DialogResult.OK;
            else if (e.KeyCode.Equals(Keys.F6))
                DialogResult = DialogResult.Cancel;
            else if (e.KeyCode.Equals(Keys.F7))
                afterBusca();
        }

        private void TFProcLoteContrato_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, gContrato);
        }

        private void gContrato_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (gContrato.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.NotSortable)
                return;
            if (bsContrato.Count < 1)
                return;
            PropertyDescriptorCollection lP = TypeDescriptor.GetProperties(new CamadaDados.Servicos.TRegistro_Contrato());
            CamadaDados.Servicos.TList_Contrato lComparer;
            SortOrder direcao = SortOrder.None;
            if ((gContrato.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None) ||
                (gContrato.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending))
            {
                lComparer = new CamadaDados.Servicos.TList_Contrato(lP.Find(gContrato.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Ascending);
                foreach (DataGridViewColumn c in gContrato.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Ascending;
            }
            else
            {
                lComparer = new CamadaDados.Servicos.TList_Contrato(lP.Find(gContrato.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Descending);
                foreach (DataGridViewColumn c in gContrato.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Descending;
            }
            (bsContrato.List as CamadaDados.Servicos.TList_Contrato).Sort(lComparer);
            bsContrato.ResetBindings(false);
            gContrato.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = direcao;
        }

        private void gContrato_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                (bsContrato.Current as CamadaDados.Servicos.TRegistro_Contrato).St_processar =
                    !(bsContrato.Current as CamadaDados.Servicos.TRegistro_Contrato).St_processar;
                bsContrato.ResetCurrentItem();
                tot_faturar.Value = (bsContrato.List as CamadaDados.Servicos.TList_Contrato).Where(p => p.St_processar).Sum(p => p.Vl_contrato);
            }
        }

        private void cbTodos_Click(object sender, EventArgs e)
        {
            if (bsContrato.Count > 0)
            {
                (bsContrato.List as CamadaDados.Servicos.TList_Contrato).ForEach(p => p.St_processar = cbTodos.Checked);
                bsContrato.ResetBindings(true);
            }
        }
    }
}
