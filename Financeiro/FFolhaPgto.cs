using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FormBusca;

namespace Financeiro
{
    public partial class TFFolhaPgto : Form
    {
        private CamadaDados.Financeiro.Folha_Pagamento.TRegistro_FolhaPagamento rfolha;
        public CamadaDados.Financeiro.Folha_Pagamento.TRegistro_FolhaPagamento rFolha
        {
            get
            {
                if (bsFolhaPgto.Current != null)
                    return bsFolhaPgto.Current as CamadaDados.Financeiro.Folha_Pagamento.TRegistro_FolhaPagamento;
                else
                    return null;
            }
            set { rfolha = value; }
        }

        public TFFolhaPgto()
        {
            InitializeComponent();
        }

        private void afterGrava()
        {
            if (pDados.validarCampoObrigatorio())
            {
                if ((bsFolhaPgto.Current as CamadaDados.Financeiro.Folha_Pagamento.TRegistro_FolhaPagamento).Id_folha == null)
                {
                    //Verificar se ja existe lote para o mes/ano
                    object obj = new CamadaDados.Financeiro.Folha_Pagamento.TCD_FolhaPagamento().BuscarEscalar(
                                    new Utils.TpBusca[]
                                {
                                    new Utils.TpBusca()
                                    {
                                        vNM_Campo = "a.cd_empresa",
                                        vOperador = "=",
                                        vVL_Busca = "'" + CD_Empresa.Text.Trim() + "'"
                                    },
                                    new Utils.TpBusca()
                                    {
                                        vNM_Campo = "a.mes_folha",
                                        vOperador = "=",
                                        vVL_Busca = mes_folha.Text
                                    },
                                    new Utils.TpBusca()
                                    {
                                        vNM_Campo = "a.ano_folha",
                                        vOperador = "=",
                                        vVL_Busca = ano_folha.Text
                                    }
                                }, "a.st_registro");
                    if (obj != null)
                    {
                        MessageBox.Show("Ja existe um lote para a empresa " + CD_Empresa.Text.Trim() + " referente ao mes/ano " + mes_folha.Text + "/" + ano_folha.Text + " com status " + (obj.ToString().Trim().ToUpper().Equals("A") ? "ABERTO" : "PROCESSADO"), "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        mes_folha.Focus();
                        return;
                    }
                }
                this.DialogResult = DialogResult.OK;
            }
        }

        private void InserirFunc()
        {
            if (!string.IsNullOrEmpty(CD_Empresa.Text))
                using (TFFolha fFolha = new TFFolha())
                {
                    fFolha.Cd_empresa = CD_Empresa.Text;
                    fFolha.Nm_empresa = NM_Empresa.Text;
                    if(fFolha.ShowDialog() == DialogResult.OK)
                        if (fFolha.lPagtoFolha != null)
                        {
                            fFolha.lPagtoFolha.ForEach(p =>
                                {
                                    //Verificar se ja existe salario configurado para o funcionario
                                    if (!(bsFolhaPgto.Current as CamadaDados.Financeiro.Folha_Pagamento.TRegistro_FolhaPagamento).lFolhaFunc.Exists(v => v.Cd_funcionario.Trim().Equals(p.Cd_funcionario.Trim())))
                                        (bsFolhaPgto.Current as CamadaDados.Financeiro.Folha_Pagamento.TRegistro_FolhaPagamento).lFolhaFunc.Add(
                                            new CamadaDados.Financeiro.Folha_Pagamento.TRegistro_Folha_X_Funcionarios()
                                            {
                                                Cd_funcionario = p.Cd_funcionario,
                                                Nm_funcionario = p.Nm_funcionario,
                                                Vl_pagamento = p.Vl_salario,
                                                Vl_adtodevolver = p.Vl_adtodevolver
                                            });
                                    else
                                        (bsFolhaPgto.Current as CamadaDados.Financeiro.Folha_Pagamento.TRegistro_FolhaPagamento).lFolhaFunc.Find(v => v.Cd_funcionario.Trim().Equals(p.Cd_funcionario.Trim())).Vl_pagamento = p.Vl_salario;
                                });
                            bsFolhaPgto.ResetCurrentItem();
                            tot_folha.Text = (bsFolhaPgto.Current as CamadaDados.Financeiro.Folha_Pagamento.TRegistro_FolhaPagamento).lFolhaFunc.Sum(v => v.Vl_pagamento).ToString("N2", new System.Globalization.CultureInfo("pt-BR"));
                            //Habilitar campo empresa
                            CD_Empresa.Enabled = bsFolhaFunc.Count.Equals(0);
                            BB_Empresa.Enabled = bsFolhaFunc.Count.Equals(0);
                        }
                }
            else
                MessageBox.Show("Obrigatorio informar empresa para inserir funcionarios.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void AlterarFunc()
        {
            if (bsFolhaFunc.Current != null)
            {
                using (TFAlterarPgto fAltPagto = new TFAlterarPgto())
                {
                    decimal valor = (bsFolhaFunc.Current as CamadaDados.Financeiro.Folha_Pagamento.TRegistro_Folha_X_Funcionarios).Vl_pagamento;
                    decimal vl_adto = (bsFolhaFunc.Current as CamadaDados.Financeiro.Folha_Pagamento.TRegistro_Folha_X_Funcionarios).Vl_adtodevolver;
                    fAltPagto.Cd_empresa = (bsFolhaPgto.Current as CamadaDados.Financeiro.Folha_Pagamento.TRegistro_FolhaPagamento).Cd_empresa;
                    fAltPagto.Cd_funcionario = (bsFolhaFunc.Current as CamadaDados.Financeiro.Folha_Pagamento.TRegistro_Folha_X_Funcionarios).Cd_funcionario;
                    fAltPagto.Nm_funcionario = (bsFolhaFunc.Current as CamadaDados.Financeiro.Folha_Pagamento.TRegistro_Folha_X_Funcionarios).Nm_funcionario;
                    fAltPagto.Vl_pagamento = (bsFolhaFunc.Current as CamadaDados.Financeiro.Folha_Pagamento.TRegistro_Folha_X_Funcionarios).Vl_pagamento;
                    fAltPagto.Vl_adiantamento = (bsFolhaFunc.Current as CamadaDados.Financeiro.Folha_Pagamento.TRegistro_Folha_X_Funcionarios).Vl_adtodevolver;
                    if (fAltPagto.ShowDialog() == DialogResult.OK)
                    {
                        (bsFolhaFunc.Current as CamadaDados.Financeiro.Folha_Pagamento.TRegistro_Folha_X_Funcionarios).Vl_pagamento = fAltPagto.Vl_pagamento;
                        (bsFolhaFunc.Current as CamadaDados.Financeiro.Folha_Pagamento.TRegistro_Folha_X_Funcionarios).Vl_adtodevolver = fAltPagto.Vl_adiantamento;
                    }
                    else
                    {
                        (bsFolhaFunc.Current as CamadaDados.Financeiro.Folha_Pagamento.TRegistro_Folha_X_Funcionarios).Vl_pagamento = valor;
                        (bsFolhaFunc.Current as CamadaDados.Financeiro.Folha_Pagamento.TRegistro_Folha_X_Funcionarios).Vl_adtodevolver = vl_adto;
                    }
                    bsFolhaFunc.ResetCurrentItem();
                    tot_folha.Text = (bsFolhaPgto.Current as CamadaDados.Financeiro.Folha_Pagamento.TRegistro_FolhaPagamento).lFolhaFunc.Sum(v => v.Vl_pagamento).ToString("N2", new System.Globalization.CultureInfo("pt-BR"));
                    CD_Empresa.Enabled = bsFolhaFunc.Count.Equals(0);
                    BB_Empresa.Enabled = bsFolhaFunc.Count.Equals(0);
                }
            }
        }

        private void ExcluirFunc()
        {
            if (bsFolhaFunc.Current != null)
                if (MessageBox.Show("Confirma exclusão do registro selecionado?", "Pergunta", MessageBoxButtons.YesNo,
                     MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    (bsFolhaPgto.Current as CamadaDados.Financeiro.Folha_Pagamento.TRegistro_FolhaPagamento).lFolhaFuncDel.Add(
                        bsFolhaFunc.Current as CamadaDados.Financeiro.Folha_Pagamento.TRegistro_Folha_X_Funcionarios);
                    bsFolhaFunc.RemoveCurrent();
                    tot_folha.Text = (bsFolhaPgto.Current as CamadaDados.Financeiro.Folha_Pagamento.TRegistro_FolhaPagamento).lFolhaFunc.Sum(v => v.Vl_pagamento).ToString("N2", new System.Globalization.CultureInfo("pt-BR"));
                    CD_Empresa.Enabled = bsFolhaFunc.Count.Equals(0);
                    BB_Empresa.Enabled = bsFolhaFunc.Count.Equals(0);
                }
        }

        private void TFFolhaPgto_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, dataGridDefault4);
            pDados.set_FormatZero();
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            if (rfolha == null)
            {
                bsFolhaPgto.AddNew();
                CD_Empresa.Focus();
            }
            else
            {
                bsFolhaPgto.DataSource = new CamadaDados.Financeiro.Folha_Pagamento.TList_FolhaPagamento() { rfolha };
                CD_Empresa.Enabled = false;
                BB_Empresa.Enabled = false;
                mes_folha.Focus();
            }
        }

        private void BB_Empresa_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BUSCA("a.NM_empresa|Nome Empresa|300;a.CD_Empresa|Cd.Empresa|80"
               , new Componentes.EditDefault[] { CD_Empresa, NM_Empresa }, new CamadaDados.Diversos.TCD_CadEmpresa(),
               "|EXISTS|(select 1 from Tb_div_usuario_X_empresa  x where x.cd_empresa = A.cd_empresa " +
               "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
               "(exists(select 1 from tb_div_usuario_x_grupos y " +
               "        where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))");
        }

        private void CD_Empresa_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.cd_empresa|=|'" + CD_Empresa.Text.Trim() + "';" +
                              "|exists|(select 1 from tb_div_usuario_x_empresa x " +
                              "where x.cd_empresa = a.cd_empresa " +
                              "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                              "(exists(select 1 from tb_div_usuario_x_grupos y " +
                              "         where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))";
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { CD_Empresa, NM_Empresa }, new CamadaDados.Diversos.TCD_CadEmpresa());
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            this.afterGrava();
        }

        private void btn_Inserir_Item_Click(object sender, EventArgs e)
        {
            this.InserirFunc();
        }

        private void BB_Alterar_Item_Click(object sender, EventArgs e)
        {
            this.AlterarFunc();
        }

        private void btn_Deleta_Item_Click(object sender, EventArgs e)
        {
            this.ExcluirFunc();
        }

        private void TFFolhaPgto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
            else if (e.Control && e.KeyCode.Equals(Keys.F10))
                this.InserirFunc();
            else if (e.Control && e.KeyCode.Equals(Keys.F11))
                this.AlterarFunc();
            else if (e.Control && e.KeyCode.Equals(Keys.F12))
                this.ExcluirFunc();
        }

        private void TFFolhaPgto_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, dataGridDefault4);
        }

        private void dataGridDefault4_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dataGridDefault4.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.NotSortable)
                return;
            if (bsFolhaFunc.Count < 1)
                return;
            PropertyDescriptorCollection lP = TypeDescriptor.GetProperties(new CamadaDados.Financeiro.Folha_Pagamento.TRegistro_Folha_X_Funcionarios());
            CamadaDados.Financeiro.Folha_Pagamento.TList_Folha_X_Funcionarios lComparer;
            SortOrder direcao = SortOrder.None;
            if ((dataGridDefault4.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None) ||
                (dataGridDefault4.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending))
            {
                lComparer = new CamadaDados.Financeiro.Folha_Pagamento.TList_Folha_X_Funcionarios(lP.Find(dataGridDefault4.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Ascending);
                foreach (DataGridViewColumn c in dataGridDefault4.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Ascending;
            }
            else
            {
                lComparer = new CamadaDados.Financeiro.Folha_Pagamento.TList_Folha_X_Funcionarios(lP.Find(dataGridDefault4.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Descending);
                foreach (DataGridViewColumn c in dataGridDefault4.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Descending;
            }
            (bsFolhaFunc.List as CamadaDados.Financeiro.Folha_Pagamento.TList_Folha_X_Funcionarios).Sort(lComparer);
            bsFolhaFunc.ResetBindings(false);
            dataGridDefault4.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = direcao;
        }
    }
}
