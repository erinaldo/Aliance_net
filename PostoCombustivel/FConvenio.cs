using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using FormBusca;

namespace PostoCombustivel
{
    public partial class TFConvenio : Form
    {
        private CamadaDados.PostoCombustivel.TRegistro_Convenio rconvenio;
        public CamadaDados.PostoCombustivel.TRegistro_Convenio rConvenio
        {
            get
            {
                if (bsConvenio.Current != null)
                    return bsConvenio.Current as CamadaDados.PostoCombustivel.TRegistro_Convenio;
                else
                    return null;
            }
            set { rconvenio = value; }
        }

        public TFConvenio()
        {
            InitializeComponent();
            System.Collections.ArrayList cbx = new System.Collections.ArrayList();
            cbx.Add(new Utils.TDataCombo("ATIVO", "A"));
            cbx.Add(new Utils.TDataCombo("ENCERRADO", "E"));

            st_registro.DataSource = cbx;
            st_registro.ValueMember = "Value";
            st_registro.DisplayMember = "Display";

            System.Collections.ArrayList cbx1 = new System.Collections.ArrayList();
            cbx1.Add(new Utils.TDataCombo("PERCENTUAL", "P"));
            cbx1.Add(new Utils.TDataCombo("VALOR", "V"));

            tp_desconto.DataSource = cbx1;
            tp_desconto.ValueMember = "Value";
            tp_desconto.DisplayMember = "Display";

            System.Collections.ArrayList cbx2 = new System.Collections.ArrayList();
            cbx2.Add(new Utils.TDataCombo("ACRESCIMO", "A"));
            cbx2.Add(new Utils.TDataCombo("DESCONTO", "D"));
            tp_acresdesc.DataSource = cbx2;
            tp_acresdesc.DisplayMember = "Display";
            tp_acresdesc.ValueMember = "Value";
                        
            System.Collections.ArrayList cbx4 = new System.Collections.ArrayList();
            cbx4.Add(new Utils.TDataCombo("<NENHUM>", string.Empty));
            cbx4.Add(new Utils.TDataCombo("SEMANAL", "S"));
            cbx4.Add(new Utils.TDataCombo("QUINZENAL", "Q"));
            cbx4.Add(new Utils.TDataCombo("MENSAL", "M"));
            periodofatura.DataSource = cbx4;
            periodofatura.DisplayMember = "Display";
            periodofatura.ValueMember = "Value";

            System.Collections.ArrayList cbx5 = new System.Collections.ArrayList();
            cbx5.Add(new Utils.TDataCombo("SEGUNDA-FEIRA", "0"));
            cbx5.Add(new Utils.TDataCombo("TERÇA-FEIRA", "1"));
            cbx5.Add(new Utils.TDataCombo("QUARTA-FEIRA", "2"));
            cbx5.Add(new Utils.TDataCombo("QUINTA-FEIRA", "3"));
            cbx5.Add(new Utils.TDataCombo("SEXTA-FEIRA", "4"));
            cbx5.Add(new Utils.TDataCombo("SABADO", "5"));
            cbx5.Add(new Utils.TDataCombo("DOMINGO", "6"));
            diasemana.DataSource = cbx5;
            diasemana.DisplayMember = "Display";
            diasemana.ValueMember = "Value";
        }
        
        private void afterGrava()
        {
            

            if (pDados.validarCampoObrigatorio())
            {
                if (!string.IsNullOrEmpty(cd_portador.Text))
                {
                    object obj = new CamadaDados.Financeiro.Cadastros.TCD_CadPortador().BuscarEscalar(
                                new Utils.TpBusca[]
                            {
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "a.cd_portador",
                                    vOperador = "=",
                                    vVL_Busca = "'" + cd_portador.Text.Trim() + "'"
                                }
                            }, "a.Tp_portadorpdv");
                    if (obj.Equals("P"))
                    {
                        if (string.IsNullOrEmpty(tp_duplicata.Text))
                        {
                            MessageBox.Show("Obrigatório informar Tipo de Duplicata!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            tp_duplicata.Focus();
                            return;
                        }
                        if (string.IsNullOrEmpty(cd_condpgto.Text))
                        {
                            MessageBox.Show("Obrigatório informar Condição de Pagamento!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            cd_condpgto.Focus();
                            return;
                        }
                    }
                }
            }
                DialogResult = DialogResult.OK;
        }

        private void InserirClifor()
        {
            if (bsConvenio.Current != null)
            {
                if (string.IsNullOrEmpty(CD_Empresa.Text))
                {
                    MessageBox.Show("Obrigatorio informar empresa.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CD_Empresa.Focus();
                    return;
                }
                using (TFCliforConvenio fClifor = new TFCliforConvenio())
                {
                    fClifor.pCd_empresa = CD_Empresa.Text;
                    fClifor.tipo_insercaounica = true;
                    if (fClifor.ShowDialog() == DialogResult.OK)
                    {
                        if ((fClifor.rClifor != null) && (fClifor.lCombustivel != null))
                        {
                            fClifor.lCombustivel.ForEach(p =>
                            {
                                if ((bsConvenio.Current as CamadaDados.PostoCombustivel.TRegistro_Convenio).lClifor.Exists(v =>
                                                                    v.Cd_produto.Trim().Equals(p.CD_Produto.Trim()) &&
                                                                    v.Cd_clifor.Trim().Equals(fClifor.rClifor.Cd_clifor.Trim()) &&
                                                                    v.Cd_endereco.Trim().Equals(fClifor.rClifor.Cd_endereco.Trim())))
                                    (bsConvenio.Current as CamadaDados.PostoCombustivel.TRegistro_Convenio).lClifor.Find(v =>
                                                                    v.Cd_produto.Trim().Equals(p.CD_Produto.Trim()) &&
                                                                    v.Cd_clifor.Trim().Equals(fClifor.rClifor.Cd_clifor.Trim()) &&
                                                                    v.Cd_endereco.Trim().Equals(fClifor.rClifor.Cd_endereco.Trim()))
                                    .lPlaca = fClifor.rClifor.lPlaca;

                                else
                                    (bsConvenio.Current as CamadaDados.PostoCombustivel.TRegistro_Convenio).lClifor.Add(
                                        new CamadaDados.PostoCombustivel.TRegistro_Convenio_Clifor()
                                        {
                                            Cd_clifor = fClifor.rClifor.Cd_clifor,
                                            Nm_clifor = fClifor.rClifor.Nm_clifor,
                                            Cd_empresa = fClifor.rClifor.Cd_empresa,
                                            Nm_empresa = fClifor.rClifor.Nm_empresa,
                                            Cd_endereco = fClifor.rClifor.Cd_endereco,
                                            Cd_produto = p.CD_Produto,
                                            Ds_produto = p.DS_Produto,
                                            Id_convenio = fClifor.rClifor.Id_convenio,
                                            lMotDel = fClifor.rClifor.lMotDel,
                                            lMotorista = fClifor.rClifor.lMotorista,
                                            lPlaca = fClifor.rClifor.lPlaca,
                                            lPlacaDel = fClifor.rClifor.lPlacaDel,
                                            St_faturardireto = fClifor.rClifor.St_faturardireto,
                                            St_motconveniado = fClifor.rClifor.St_motconveniado,
                                            St_placaconveniada = fClifor.rClifor.St_placaconveniada,
                                            St_registro = fClifor.rClifor.St_registro,
                                            Vl_unitario = fClifor.rClifor.Vl_unitario,
                                            CD_vendedor = fClifor.rClifor.CD_vendedor,
                                            Id_config = fClifor.rClifor.Id_config,
                                            Qtd_convenio = fClifor.rClifor.Qtd_convenio,
                                            Tp_preco = fClifor.rClifor.Tp_preco,
                                            Tp_faturamento = fClifor.rClifor.Tp_faturamento,
                                            St_exigirrequisicao = fClifor.rClifor.St_exigirrequisicao,
                                            St_exigirnomemot = fClifor.rClifor.St_exigirnomemot,
                                            Tp_qt_vl = fClifor.rClifor.Tp_qt_vl,
                                            Base_calc_fid = fClifor.rClifor.Base_calc_fid,
                                            Qt_pontos_fid = fClifor.rClifor.Qt_pontos_fid,
                                            Nr_diasvalidade_fid = fClifor.rClifor.Nr_diasvalidade_fid,
                                            Tp_pontos_fid = fClifor.rClifor.Tp_pontos_fid,
                                            Ds_msgVale = fClifor.rClifor.Ds_msgVale,
                                            Tp_acresdesc = fClifor.rClifor.Tp_acresdesc,
                                            Tp_desconto = fClifor.rClifor.Tp_desconto,
                                            Desconto = fClifor.rClifor.Desconto
                                        });
                            });
                            bsConvenio.ResetCurrentItem();
                        }
                    }
                }
            }
        }

        private void AlterarClifor()
        {
            if (bsConvenioClifor.Current != null)
                using (TFCliforConvenio fClifor = new TFCliforConvenio())
                {
                    fClifor.pCd_empresa = (bsConvenioClifor.Current as CamadaDados.PostoCombustivel.TRegistro_Convenio_Clifor).Cd_empresa;
                    fClifor.rClifor = bsConvenioClifor.Current as CamadaDados.PostoCombustivel.TRegistro_Convenio_Clifor;
                    fClifor.ShowDialog();
                    bsConvenioClifor.ResetCurrentItem();
                }
        }

        private void ExcluirClifor()
        {
            if(bsConvenioClifor.Current != null)
                if (MessageBox.Show("Confirma exclusão do registro?", "Pergunta", MessageBoxButtons.YesNo,
                     MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    (bsConvenio.Current as CamadaDados.PostoCombustivel.TRegistro_Convenio).lCliforDel.Add(
                        bsConvenioClifor.Current as CamadaDados.PostoCombustivel.TRegistro_Convenio_Clifor);
                    bsConvenioClifor.RemoveCurrent();
                }
        }

        private void BB_Empresa_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BUSCA("a.NM_empresa|Nome Empresa|300;a.CD_Empresa|Cód Empresa|100"
                          , new Componentes.EditDefault[] { CD_Empresa, NM_Empresa }
                          , new CamadaDados.Diversos.TCD_CadEmpresa(),
                          "|EXISTS|(select 1 from Tb_div_usuario_X_empresa  x where x.cd_empresa = A.cd_empresa " +
                          "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                          "(exists(select 1 from tb_div_usuario_x_grupos y " +
                          "         where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))");
        }

        private void CD_Empresa_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("a.cd_empresa|=|'" + CD_Empresa.Text.Trim() + "';" +
                                   "|EXISTS|(select 1 from Tb_div_usuario_X_empresa  x where x.cd_empresa = A.cd_empresa " +
                                   "and((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                                   "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                   "        where y.logingrp = x.login " +
                                   "        and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))"
               , new Componentes.EditDefault[] { CD_Empresa, NM_Empresa }, new CamadaDados.Diversos.TCD_CadEmpresa());
        }

        private void TFConvenio_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, gConvClifor);
            Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pDados.set_FormatZero();
            if (rconvenio != null)
            {
                bsConvenio.DataSource = new CamadaDados.PostoCombustivel.TList_Convenio() { rconvenio };
                CD_Empresa.Enabled = false;
                BB_Empresa.Enabled = false;
                st_registro.Enabled = true;
                dt_convenio.Focus();
            }
            else
            {
                bsConvenio.AddNew();
                CD_Empresa.Focus();
            }
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            afterGrava();
        }

        private void btn_Inserir_Item_Click(object sender, EventArgs e)
        {
            InserirClifor();
        }

        private void BB_Alterar_Item_Click(object sender, EventArgs e)
        {
            AlterarClifor();
        }

        private void btn_Deleta_Item_Click(object sender, EventArgs e)
        {
            ExcluirClifor();
        }

        private void TFConvenio_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                DialogResult = DialogResult.Cancel;
            else if (e.Control && e.KeyCode.Equals(Keys.F10))
                InserirClifor();
            else if (e.Control && e.KeyCode.Equals(Keys.F11))
                AlterarClifor();
            else if (e.Control && e.KeyCode.Equals(Keys.F12))
                ExcluirClifor();
        }

        private void bb_portador_Click(object sender, EventArgs e)
        {
            string vColunas = "ds_portador|Portador|200;" +
                              "cd_portador|Cd. Portador|80";
            string vParam = "TP_PortadorPDV|is not|null";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_portador, ds_portador },
                                            new CamadaDados.Financeiro.Cadastros.TCD_CadPortador(), vParam);
        }

        private void cd_portador_Leave(object sender, EventArgs e)
        {
            string vparam = "a.cd_portador|=|'" + cd_portador.Text.Trim() + "';" +
                            "TP_PortadorPDV|is not|null";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vparam, new Componentes.EditDefault[] { cd_portador, ds_portador },
                                                new CamadaDados.Financeiro.Cadastros.TCD_CadPortador());
        }

        private void bb_tpduplicata_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_tpduplicata|Tipo Duplicata|200;" +
                              "a.tp_duplicata|TP. Duplicata|80";
            string vParam = "a.tp_mov|=|'R'";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { tp_duplicata, ds_tpduplicata },
                                        new CamadaDados.Financeiro.Cadastros.TCD_CadTpDuplicata(), vParam);
        }

        private void tp_duplicata_Leave(object sender, EventArgs e)
        {
            string vParam = "a.tp_duplicata|=|'" + tp_duplicata.Text.Trim() + "';" +
                            "a.tp_mov|=|'R'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { tp_duplicata, ds_tpduplicata },
                                        new CamadaDados.Financeiro.Cadastros.TCD_CadTpDuplicata());
        }

        private void bb_tpdocto_Click(object sender, EventArgs e)
        {
            string vParam = "a.ds_tpdocto|Tipo Documento|200;" +
                            "a.tp_docto|TP. Docto|80";
            FormBusca.UtilPesquisa.BTN_BUSCA(vParam, new Componentes.EditDefault[] { tp_docto, ds_tpdocto },
                                            new CamadaDados.Financeiro.Cadastros.TCD_CadTpDoctoDup(), string.Empty);
        }

        private void tp_docto_Leave(object sender, EventArgs e)
        {
            string vParam = "a.tp_docto|=|" + tp_docto.Text;
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { tp_docto, ds_tpdocto },
                                            new CamadaDados.Financeiro.Cadastros.TCD_CadTpDoctoDup());
        }

        private void bb_condpgto_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_condpgto|Condição Pagamento|200;" +
                              "a.cd_condpgto|Cd. Condição|80";
            string vParam = "a.qt_parcelas|=|1";
            DataRowView linha = FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_condpgto, ds_condpgto },
                                                                    new CamadaDados.Financeiro.Cadastros.TCD_CadCondPgto(), vParam);
            if (linha != null)
            {
                qt_dias_desdobro.Value = decimal.Parse(linha["qt_diasdesdobro"].ToString());
                qt_parcelas.Value = decimal.Parse(linha["qt_parcelas"].ToString());
            }
            else
            {
                qt_dias_desdobro.Value = decimal.Zero;
                qt_parcelas.Value = decimal.Zero;
            }
        }

        private void cd_condpgto_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_condpgto|=|'" + cd_condpgto.Text.Trim() + "';" +
                            "a.qt_parcelas|=|1";
            DataRow linha = FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_condpgto, ds_condpgto },
                                                                new CamadaDados.Financeiro.Cadastros.TCD_CadCondPgto());
            if (linha != null)
            {
                qt_dias_desdobro.Value = decimal.Parse(linha["qt_diasdesdobro"].ToString());
                qt_parcelas.Value = decimal.Parse(linha["qt_parcelas"].ToString());
            }
            else
            {
                qt_dias_desdobro.Value = decimal.Zero;
                qt_parcelas.Value = decimal.Zero;
            }
        }

        private void gConvClifor_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (gConvClifor.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.NotSortable)
                return;
            if (bsConvenioClifor.Count < 1)
                return;
            PropertyDescriptorCollection lP = TypeDescriptor.GetProperties(new CamadaDados.PostoCombustivel.TRegistro_Convenio_Clifor());
            CamadaDados.PostoCombustivel.TList_Convenio_Clifor lComparer;
            SortOrder direcao = SortOrder.None;
            if ((gConvClifor.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None) ||
                (gConvClifor.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending))
            {
                lComparer = new CamadaDados.PostoCombustivel.TList_Convenio_Clifor(lP.Find(gConvClifor.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Ascending);
                foreach (DataGridViewColumn c in gConvClifor.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Ascending;
            }
            else
            {
                lComparer = new CamadaDados.PostoCombustivel.TList_Convenio_Clifor(lP.Find(gConvClifor.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Descending);
                foreach (DataGridViewColumn c in gConvClifor.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Descending;
            }
            (bsConvenioClifor.List as CamadaDados.PostoCombustivel.TList_Convenio_Clifor).Sort(lComparer);
            bsConvenioClifor.ResetBindings(false);
            gConvClifor.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = direcao;
        }

        private void TFConvenio_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, gConvClifor);
        }

        private void periodofatura_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblSemana.Visible = periodofatura.SelectedValue == null ? false : periodofatura.SelectedValue.ToString().Equals("S");
            diasemana.Visible = periodofatura.SelectedValue == null ? false : periodofatura.SelectedValue.ToString().Equals("S");
        }
    }
}
