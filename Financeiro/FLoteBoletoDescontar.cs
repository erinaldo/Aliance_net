using CamadaDados.Financeiro.Bloqueto;
using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using Utils;

namespace Financeiro
{
    public partial class TFLoteBoletoDescontar : Form
    {
        public CamadaDados.Financeiro.Bloqueto.TRegistro_LoteBloqueto rLote
        {
            get
            {
                if (bsLote.Current != null)
                    return bsLote.Current as CamadaDados.Financeiro.Bloqueto.TRegistro_LoteBloqueto;
                else return null;
            }
        }

        private void localizarBloquetos()
        {
            using (TFLocalizarBloquetos fLocalizar = new TFLocalizarBloquetos())
            {
                if (cbEmpresa.SelectedItem == null)
                {
                    MessageBox.Show("Obrigatório informar empresa.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cbEmpresa.Focus();
                    return;
                }
                if (cbConfig.SelectedItem == null)
                {
                    MessageBox.Show("Obrigatório informar configuração boleto.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cbConfig.Focus();
                    return;
                }
                fLocalizar.pCd_empresa = (cbEmpresa.SelectedItem as CamadaDados.Diversos.TRegistro_CadEmpresa).Cd_empresa;
                fLocalizar.pNm_empresa = (cbEmpresa.SelectedItem as CamadaDados.Diversos.TRegistro_CadEmpresa).Nm_empresa;
                fLocalizar.pId_Config = (cbConfig.SelectedItem as CamadaDados.Financeiro.Cadastros.TRegistro_CadCFGBanco).Id_configstr;
                fLocalizar.pDs_config = (cbConfig.SelectedItem as CamadaDados.Financeiro.Cadastros.TRegistro_CadCFGBanco).Ds_config;
                if (fLocalizar.ShowDialog() == DialogResult.OK)
                {
                    foreach (var v in fLocalizar.lBloquetos)
                    {
                        if ((bsLote.Current as CamadaDados.Financeiro.Bloqueto.TRegistro_LoteBloqueto).ListaBloqueto.Exists(p => p.Cd_empresa.Trim().Equals(v.Cd_empresa)
                                                                                                                        && p.Nr_lancto.Equals(v.Nr_lancto)
                                                                                                                        && p.Cd_parcela.Equals(v.Cd_parcela)
                                                                                                                        && p.Id_cobranca.Equals(v.Id_cobranca)))
                            continue;
                        (bsLote.Current as CamadaDados.Financeiro.Bloqueto.TRegistro_LoteBloqueto).ListaBloqueto.Add(v);
                    }
                    bsLote.ResetBindings(true);
                    tot_titulo.Text = (bsLote.Current as CamadaDados.Financeiro.Bloqueto.TRegistro_LoteBloqueto).ListaBloqueto.Sum(p => p.Vl_atual).ToString("N2", new System.Globalization.CultureInfo("pt-BR", true));
                }
            }
        }

        private void afterGrava()
        {
            if (cbEmpresa.SelectedItem == null)
            {
                MessageBox.Show("Obrigatório informar empresa.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbEmpresa.Focus();
                return;
            }
            if (cbConfig.SelectedItem == null)
            {
                MessageBox.Show("Obrigatório informar configuração boleto.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbConfig.Focus();
                return;
            }
            if (string.IsNullOrEmpty(dt_processamento.Text.SoNumero()))
            {
                MessageBox.Show("Obrigatório informar data lote.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dt_processamento.Focus();
                return;
            }
            DialogResult = DialogResult.OK;
        }

        private void ExcluirBloquetos()
        {
            if(dsBloqueto.Current != null)
                if (MessageBox.Show("Confirma exclusão do titulo correnten?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                    == DialogResult.Yes)
                {
                    dsBloqueto.RemoveCurrent();
                    tot_titulo.Text = (bsLote.Current as CamadaDados.Financeiro.Bloqueto.TRegistro_LoteBloqueto).ListaBloqueto.Sum(p => p.Vl_atual).ToString("N2", new System.Globalization.CultureInfo("pt-BR", true));
                }
        }

        public TFLoteBoletoDescontar()
        {
            InitializeComponent();
        }

        private void TFLoteBoletoDescontar_Load(object sender, EventArgs e)
        {
            Icon = ResourcesUtils.TecnoAliance_ICO;
            pLote.set_FormatZero();
            bsLote.AddNew();
            //Buscar empresa
            cbEmpresa.DataSource = new CamadaDados.Diversos.TCD_CadEmpresa().Select(
                                    new TpBusca[]
                                    {
                                        new TpBusca()
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
            cbEmpresa.DisplayMember = "NM_Empresa";
            cbEmpresa.ValueMember = "CD_Empresa";
        }
        
        private void btn_Inserir_Item_Click(object sender, EventArgs e)
        {
            localizarBloquetos();
        }

        private void btn_Deleta_Item_Click(object sender, EventArgs e)
        {
            ExcluirBloquetos();
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            afterGrava();
        }

        private void TFLoteBoletoDescontar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                DialogResult = DialogResult.Cancel;
            else if (e.Control && e.KeyCode.Equals(Keys.F10))
                localizarBloquetos();
            else if (e.Control && e.KeyCode.Equals(Keys.F12))
                ExcluirBloquetos();
        }

        private void cbEmpresa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbEmpresa.SelectedItem != null)
            {
                cbConfig.DataSource = new CamadaDados.Financeiro.Cadastros.TCD_CadCFGBanco().Select(
                                    new TpBusca[]
                                    {
                                        new TpBusca()
                                        {
                                            vNM_Campo = "a.cd_empresa",
                                            vOperador = "=",
                                            vVL_Busca = "'" + (cbEmpresa.SelectedItem as CamadaDados.Diversos.TRegistro_CadEmpresa).Cd_empresa.Trim() + "'"
                                        },
                                        new TpBusca()
                                        {
                                            vNM_Campo = "isnull(a.st_registro, 'A')",
                                            vOperador = "<>",
                                            vVL_Busca = "'C'"
                                        },
                                        new TpBusca()
                                        {
                                            vNM_Campo = "a.tp_cobranca",
                                            vOperador = "=",
                                            vVL_Busca = "'CR'"
                                        },
                                        new TpBusca()
                                        {
                                            vNM_Campo = string.Empty,
                                            vOperador = "exists",
                                            vVL_Busca = "(select 1 from tb_div_usuario_x_contager x " +
                                                        "where x.cd_contager = a.cd_contager " +
                                                        "and x.login = '" + Utils.Parametros.pubLogin.Trim() + "')"
                                        }
                                    }, 0, string.Empty);
                cbConfig.DisplayMember = "ds_config";
                cbConfig.ValueMember = "id_config";
            }
        }

        private void gBloqueto_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (gBloqueto.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.NotSortable)
                return;
            if (dsBloqueto.Count < 1)
                return;
            PropertyDescriptorCollection lP = TypeDescriptor.GetProperties(new blTitulo());
            blListaTitulo lComparer;
            SortOrder direcao = SortOrder.None;
            if ((gBloqueto.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None) ||
                (gBloqueto.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending))
            {
                lComparer = new blListaTitulo(lP.Find(gBloqueto.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Ascending);
                foreach (DataGridViewColumn c in gBloqueto.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Ascending;
            }
            else
            {
                lComparer = new blListaTitulo(lP.Find(gBloqueto.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Descending);
                foreach (DataGridViewColumn c in gBloqueto.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Descending;
            }
            (dsBloqueto.List as blListaTitulo).Sort(lComparer);
            dsBloqueto.ResetBindings(false);
            gBloqueto.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = direcao;
        }
    }
}
