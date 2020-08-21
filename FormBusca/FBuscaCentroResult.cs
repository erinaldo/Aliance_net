using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FormBusca
{
    public partial class TFBuscaCentroResult : Form
    {
        public bool St_processar
        { get; set; }
        public string Cd_centro
        { get; set; }
        public string Ds_centro
        { get; set; }
        public string Tipo_registro
        { get; set; }
        public string Tp_registro
        { get; set; }
        public string St_deducao
        { get; set; }
        public bool St_sintetico
        { get; set; }
        private int index = 1;
        public TFBuscaCentroResult()
        {         
            InitializeComponent();
            this.Height = Screen.PrimaryScreen.Bounds.Height - (Screen.PrimaryScreen.Bounds.Height / 10) * 1;
            this.Width = Screen.PrimaryScreen.Bounds.Width - (Screen.PrimaryScreen.Bounds.Width / 10) * 2;
        }

        private void afterGrava()
        {
            if (bsCentroResult.Current != null)
            {
                if (!St_processar)
                {
                    if (!St_sintetico && (bsCentroResult.Current as CamadaDados.Financeiro.Cadastros.TRegistro_CentroResultado).St_sinteticobool)
                    {
                        MessageBox.Show("Não é permitido incluir item SINTÉTICO.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    if (St_sintetico && !(bsCentroResult.Current as CamadaDados.Financeiro.Cadastros.TRegistro_CentroResultado).St_sinteticobool)
                    {
                        MessageBox.Show("Não é permitido incluir item ANÁLITICO.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    Cd_centro = (bsCentroResult.Current as CamadaDados.Financeiro.Cadastros.TRegistro_CentroResultado).Cd_centroresult;
                    Ds_centro = (bsCentroResult.Current as CamadaDados.Financeiro.Cadastros.TRegistro_CentroResultado).Ds_centroresultado;
                    Tipo_registro = (bsCentroResult.Current as CamadaDados.Financeiro.Cadastros.TRegistro_CentroResultado).Tipo_registro;
                }
                else
                {
                    if ((bsCentroResult.DataSource as CamadaDados.Financeiro.Cadastros.TList_CentroResultado).Exists(p=> p.St_processar))
                    {
                        (bsCentroResult.DataSource as CamadaDados.Financeiro.Cadastros.TList_CentroResultado).FindAll(p => p.St_processar).ForEach(p =>
                        {
                            Cd_centro += p.Cd_centroresult.Trim() + ", ";
                        });
                        Cd_centro = Cd_centro.Trim().TrimEnd(',') ;
                    }
                }
                this.DialogResult = DialogResult.OK;
            }
        }

        private void BuscaCentro()
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (!string.IsNullOrEmpty(Tp_registro))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.tp_registro";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "" + Tp_registro.Trim() + "";
            }
            if (!string.IsNullOrEmpty(St_deducao))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "isnull(a.st_deducao, 'N')";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + St_deducao.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(ds_centro.Text) && cbFiltro.Checked)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.DS_CentroResultado";
                filtro[filtro.Length - 1].vOperador = "like";
                filtro[filtro.Length - 1].vVL_Busca = "'%" + ds_centro.Text.Trim() + "%'";
            }
            bsCentroResult.DataSource = new CamadaDados.Financeiro.Cadastros.TCD_CentroResultado().Select(filtro, 0, string.Empty);
        }

        private void BuscarIndexContaCtb()
        {
            try
            {
                if (bsCentroResult.Current != null)
                {
                    var linha = gBusca.Rows.Cast<DataGridViewRow>().Where(p => p.Cells["pDs_centroresultado"].Value.ToString().Contains(ds_centro.Text)).ToList();
                    if (linha != null)
                    {
                        if (index + 1 < linha.Count)
                            index++;
                        else
                            index = 0;
                        var p = linha[index];
                        gBusca.Rows[p.Index].Selected = true;
                        bsCentroResult.Position = p.Index;
                        lbSequencia.Text = (index + 1).ToString() + " de " + linha.Count;
                    }
                }
            }
            catch { }
        }

        private void TFBuscaCentroResult_Load(object sender, EventArgs e)
        {
            pSt_processar.Visible = St_processar;
            this.BuscaCentro();
            ds_centro.Focus();
        }

        private void ds_centro_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbFiltro.Checked)
                    BuscaCentro();
                else
                {
                    DataGridViewRow linha = gBusca.Rows.Cast<DataGridViewRow>().Where(p => p.Cells["pDs_centroresultado"].Value.ToString().Contains(ds_centro.Text)).First();
                    if (linha != null)
                    {
                        gBusca.Rows[linha.Index].Selected = true;
                        bsCentroResult.Position = linha.Index;
                        decimal result = gBusca.Rows.Cast<DataGridViewRow>().Where(p => p.Cells["pDs_centroresultado"].Value.ToString().Contains(ds_centro.Text)).Count();
                        if (result == 0)
                        {
                            lbResultado.Text = "NENHUM RESULTADO ENCONTRADO";
                            index = 0;
                        }
                        else if (result == 1)
                        {
                            lbResultado.Text = result.ToString() + " RESULTADO ENCONTRADO";
                            index = 0;
                        }
                        else if (result > 1)
                        {
                            lbResultado.Text = result.ToString() + " RESULTADOS ENCONTRADOS";
                            index = 0;
                        }
                        lbSequencia.Text = (index + 1).ToString() + " de " + result.ToString();
                    }
                }
            }
            catch { }
        }

        private void TFBuscaCentroResult_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
                this.afterGrava();
            else if (e.KeyCode.Equals(Keys.Down))
                this.BuscarIndexContaCtb();
        }

        private void gBusca_DoubleClick(object sender, EventArgs e)
        {
            this.afterGrava();
        }

        private void gBusca_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null)
            {
                if (e.ColumnIndex == 3)
                    if ((bsCentroResult[e.RowIndex] as CamadaDados.Financeiro.Cadastros.TRegistro_CentroResultado).St_sinteticobool)
                    {
                        gBusca.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Blue;
                        gBusca.Rows[e.RowIndex].DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
                    }
                    else
                    {
                        gBusca.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
                        gBusca.Rows[e.RowIndex].DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular);
                    }
            }
        }

        private void gBusca_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 && bsCentroResult.Current != null)
            {
                (bsCentroResult.Current as CamadaDados.Financeiro.Cadastros.TRegistro_CentroResultado).St_processar =
                    !(bsCentroResult.Current as CamadaDados.Financeiro.Cadastros.TRegistro_CentroResultado).St_processar;
                bsCentroResult.ResetCurrentItem();
            }
        }

        private void cbFiltro_CheckedChanged(object sender, EventArgs e)
        {
            pPathCentroresult.Visible = cbFiltro.Checked;
            BuscaCentro();
        }
    }
}
