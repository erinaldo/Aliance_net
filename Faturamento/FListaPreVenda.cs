using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Utils;

namespace Faturamento
{
    public partial class TFListaPreVenda : Form
    {
        public String tabela = string.Empty;
        public String cliente = string.Empty;
        private string CodBarras
        { get; set; }
        public string LoginPDV { get; set; }

        public List<CamadaDados.Faturamento.PDV.TRegistro_PreVenda> lVenda
        {
            get
            {
                if (bsPreVenda.Count > 0 && 
                    (bsPreVenda.List as CamadaDados.Faturamento.PDV.TList_PreVenda).Exists(p => p.St_processar))
                {
                    //Buscar Pre-vendas selecionadas
                    string id = string.Empty;
                    string virg = string.Empty;
                    string empresa = string.Empty;
                    (bsPreVenda.List as CamadaDados.Faturamento.PDV.TList_PreVenda).FindAll(p => p.St_processar).ForEach(p =>
                        {                            
                            virg = ",";
                            id += p.Id_prevendastr + virg; ;
                            empresa = p.Cd_empresa;
                        });
                    return new CamadaDados.Faturamento.PDV.TCD_PreVenda().Select(
                            new Utils.TpBusca[]
                            {
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "a.cd_empresa",
                                    vOperador = "=",
                                    vVL_Busca = "'" + empresa.Trim() + "'"
                                },
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "a.id_prevenda",
                                    vOperador = "in",
                                    vVL_Busca = "(" + id.TrimEnd(',') + ")"
                                }
                            }, 0, string.Empty, string.Empty);
                }
                else
                    return null;
            }
        }

        public TFListaPreVenda()
        {
            InitializeComponent();
            this.Height = Screen.PrimaryScreen.Bounds.Height - (Screen.PrimaryScreen.Bounds.Height / 10) * 1;
            this.Width = Screen.PrimaryScreen.Bounds.Width - (Screen.PrimaryScreen.Bounds.Width / 10) * 1;
        }

        private void afterBusca()
        {
            if (empresa.SelectedValue != null)
            {
                    bsPreVenda.DataSource = new CamadaDados.Faturamento.PDV.TCD_PreVenda().Select(
                                                new Utils.TpBusca[]
                                                {
                                                    new Utils.TpBusca()
                                                    {
                                                        vNM_Campo = "a.cd_empresa",
                                                        vOperador = "=",
                                                        vVL_Busca = "'" + empresa.SelectedValue.ToString() + "'"
                                                    },
                                                    new Utils.TpBusca()
                                                    {
                                                        vNM_Campo = "isnull(a.st_registro, 'A')",
                                                        vOperador = "<>",
                                                        vVL_Busca = "'C'"
                                                    },
                                                    new Utils.TpBusca()
                                                    {
                                                        vNM_Campo = "a.st_faturada",
                                                        vOperador = "<>",
                                                        vVL_Busca = "'S'"
                                                    },
                                                    new Utils.TpBusca()
                                                    {
                                                        vNM_Campo = "isnull(a.st_orcamento, 'N')",
                                                        vOperador = "<>",
                                                        vVL_Busca = "'S'"
                                                    }
                                                }, 0, string.Empty, "a.dt_emissao desc");
                tot_venda.Value = (bsPreVenda.List as CamadaDados.Faturamento.PDV.TList_PreVenda).Sum(p => p.Vl_prevenda);
            }
        }

        private void afterGrava()
        {
            Utils.ShapeGrid.SaveShape(this, gPreVenda);
            this.DialogResult = DialogResult.OK;
        }

        private void TFListaPreVenda_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, gPreVenda);
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            //Preencher lista de empresas
            empresa.DataSource = new CamadaDados.Diversos.TCD_CadEmpresa().Select(
                                    new Utils.TpBusca[]
                                    {
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = string.Empty,
                                            vOperador = "exists",
                                            vVL_Busca = "(select 1 from tb_div_usuario_x_empresa x " +
                                                        "where x.cd_empresa = a.cd_empresa " +
                                                        "and ((x.login = '" + LoginPDV.Trim() + "') or " +
                                                        "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                                        "       where y.logingrp = x.login and y.loginusr = '" + LoginPDV.Trim() + "'))))"
                                        },
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = string.Empty,
                                            vOperador = "exists",
                                            vVL_Busca = "(select 1 from tb_pdv_cfgcupomfiscal x " +
                                                        "where x.cd_empresa = a.cd_empresa)"
                                        }
                                    }, 0, string.Empty);
            empresa.DisplayMember = "NM_Empresa";
            empresa.ValueMember = "CD_Empresa";
            this.afterBusca();
        }

        private void gPreVenda_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (gPreVenda.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.NotSortable)
                return;
            if (bsPreVenda.Count < 1)
                return;
            PropertyDescriptorCollection lP = TypeDescriptor.GetProperties(new CamadaDados.Faturamento.PDV.TRegistro_PreVenda());
            CamadaDados.Faturamento.PDV.TList_PreVenda lComparer;
            SortOrder direcao = SortOrder.None;
            if ((gPreVenda.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None) ||
                (gPreVenda.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending))
            {
                lComparer = new CamadaDados.Faturamento.PDV.TList_PreVenda(lP.Find(gPreVenda.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Ascending);
                foreach (DataGridViewColumn c in gPreVenda.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Ascending;
            }
            else
            {
                lComparer = new CamadaDados.Faturamento.PDV.TList_PreVenda(lP.Find(gPreVenda.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Descending);
                foreach (DataGridViewColumn c in gPreVenda.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Descending;
            }
            (bsPreVenda.List as CamadaDados.Faturamento.PDV.TList_PreVenda).Sort(lComparer);
            bsPreVenda.ResetBindings(false);
            gPreVenda.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = direcao;
        }

        private void gPreVenda_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                if ((bsPreVenda.DataSource as CamadaDados.Faturamento.PDV.TList_PreVenda).Where(p=> p.St_processar).Count().Equals(0))
                {
                    tabela = (bsPreVenda.Current as CamadaDados.Faturamento.PDV.TRegistro_PreVenda).Cd_tabelaPreco;
                    cliente = (bsPreVenda.Current as CamadaDados.Faturamento.PDV.TRegistro_PreVenda).Cd_clifor;
                    soma();
                }
                else if (!cliente.Equals((bsPreVenda.Current as CamadaDados.Faturamento.PDV.TRegistro_PreVenda).Cd_clifor))
                    MessageBox.Show("Não é possivel selecionar prevendas com clientes diferentes!");
                else if (!tabela.Equals((bsPreVenda.Current as CamadaDados.Faturamento.PDV.TRegistro_PreVenda).Cd_tabelaPreco))
                    MessageBox.Show("Não é possivel selecionar prevendas com tabelas de preços diferentes!");
                else if (tabela.Equals((bsPreVenda.Current as CamadaDados.Faturamento.PDV.TRegistro_PreVenda).Cd_tabelaPreco))
                    soma();
            }
        }

        public void soma()
        {
            (bsPreVenda.Current as CamadaDados.Faturamento.PDV.TRegistro_PreVenda).St_processar =
                    !(bsPreVenda.Current as CamadaDados.Faturamento.PDV.TRegistro_PreVenda).St_processar;
            tot_selecionado.Value = (bsPreVenda.List as CamadaDados.Faturamento.PDV.TList_PreVenda).Where(p => p.St_processar).Sum(p => p.Vl_prevenda);
            if (tot_selecionado.Value == 0) 
                tabela = string.Empty;
            bsPreVenda.ResetCurrentItem();
        }

        private void cbProcessar_Click(object sender, EventArgs e)
        {
            if (bsPreVenda.Count > 0)
            {
                (bsPreVenda.List as CamadaDados.Faturamento.PDV.TList_PreVenda).ForEach(p => p.St_processar = cbProcessar.Checked);
                tot_selecionado.Value = (bsPreVenda.List as CamadaDados.Faturamento.PDV.TList_PreVenda).Where(p => p.St_processar).Sum(p => p.Vl_prevenda);
                bsPreVenda.ResetBindings(true);
            }
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            this.afterGrava();
        }

        private void TFListaPreVenda_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
            else if (e.KeyCode.Equals(Keys.Enter))
            {
                if (CodBarras.SoNumero().Length.Equals(44))
                {
                    bsPreVenda.DataSource = new CamadaDados.Faturamento.PDV.TCD_PreVenda().Select(
                                                 new Utils.TpBusca[]
                                        {
                                            new Utils.TpBusca()
                                            {
                                                vNM_Campo = "a.cd_empresa",
                                                vOperador = "=",
                                                vVL_Busca = "'" + empresa.SelectedValue.ToString() + "'"
                                            },
                                            new Utils.TpBusca()
                                            {
                                                vNM_Campo = "isnull(a.st_registro, 'A')",
                                                vOperador = "<>",
                                                vVL_Busca = "'C'"
                                            },
                                            new Utils.TpBusca()
                                            {
                                                vNM_Campo = "a.st_faturada",
                                                vOperador = "<>",
                                                vVL_Busca = "'S'"
                                            },
                                            new Utils.TpBusca()
                                            {
                                                 vNM_Campo = "a.id_locacao",
                                                vOperador = "=",
                                                vVL_Busca = "'" + CodBarras.Trim() + "'"
                                            },
                                            new Utils.TpBusca()
                                            {
                                                vNM_Campo = "isnull(a.st_orcamento, 'N')",
                                                vOperador = "<>",
                                                vVL_Busca = "'S'"
                                            }
                                        }, 0, string.Empty, "a.dt_emissao desc");
                    tot_venda.Value = (bsPreVenda.List as CamadaDados.Faturamento.PDV.TList_PreVenda).Sum(p => p.Vl_prevenda);
                    if (bsPreVenda.Count.Equals(1))
                    {
                        (bsPreVenda.Current as CamadaDados.Faturamento.PDV.TRegistro_PreVenda).St_processar = true;
                        this.afterGrava();
                    }
                }
            }
        }

        private void TFListaPreVenda_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, gPreVenda);
        }

        private void empresa_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.afterBusca();
        }

        private void TFListaPreVenda_KeyPress(object sender, KeyPressEventArgs e)
        {
            CodBarras += e.KeyChar.ToString();
        }

        private void txtBuscaCliente_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtBuscaCliente.Text))
                {
                    (bsPreVenda.DataSource as CamadaDados.Faturamento.PDV.TList_PreVenda).ForEach(p => p.St_processar = false);
                    DataGridViewRow linha = gPreVenda.Rows.Cast<DataGridViewRow>().Where(p => p.Cells["pNm_clifor"].Value.ToString().Contains(txtBuscaCliente.Text)).First();
                    if (linha != null)
                    {
                        gPreVenda.Rows[linha.Index].Selected = true;
                        bsPreVenda.Position = linha.Index;
                        (bsPreVenda.Current as CamadaDados.Faturamento.PDV.TRegistro_PreVenda).St_processar = true;
                    }
                }
                else
                    (bsPreVenda.DataSource as CamadaDados.Faturamento.PDV.TList_PreVenda).ForEach(p => p.St_processar = false);
                bsPreVenda.ResetCurrentItem();
            }
            catch { }
        }
    }
}
