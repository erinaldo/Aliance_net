using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Utils;
using FormBusca;
using CamadaDados.Estoque;
using CamadaNegocio.Estoque;
using CamadaDados.Estoque.Cadastros;

namespace Estoque
{
    public partial class TFLan_Inventario : FormCadPadrao.FFormCadPadrao
    {
        public bool Altera_Relatorio = false;

        public TFLan_Inventario()
        {
            InitializeComponent();
            bb_saldoInventario.Click += new EventHandler(bb_saldoInventario_Click);
        }

        void bb_saldoInventario_Click(object sender, EventArgs e)
        {
            if (bsInventario.Current != null)
            {
                TFLan_SaldoInventario fSaldo = new TFLan_SaldoInventario();
                try
                {
                    fSaldo.BB_ProcessarInv.Enabled = (bsInventario.Current as Tregistro_Inventario).St_inventario.Trim().ToUpper() != "P";
                    fSaldo.bsItem.DataSource = TCN_Inventario_Item_X_Saldo.Buscar((bsInventario.Current as Tregistro_Inventario).Id_inventario, "", "", 0, "", null);
                    fSaldo.ShowDialog();
                }
                finally
                {
                    fSaldo.Dispose();
                }
                buscarRegistros();
            }
        }
                
        private void MontarArvoreProdutos()
        {
            //Buscar a lista de produtos
            DataTable lProdutos = new CamadaDados.Estoque.Cadastros.TCD_CadProduto().Buscar(new TpBusca[]
            {
                new TpBusca()
                {
                    vNM_Campo = "isnull(e.st_composto, 'N')",
                    vOperador = "<>",
                    vVL_Busca = "'S'"
                }
            }, 0, string.Empty, string.Empty, "a.cd_grupo asc", null);
            tvProduto.BeginUpdate();
            tvProduto.Nodes.Clear();
            if (lProdutos != null)
            {
                string cd_grupo = "";
                TreeNode[] nGrupo = new TreeNode[0];
                TreeNode[] nProd = new TreeNode[0];
                for (int i = 0; i < lProdutos.Rows.Count; i++)
                {
                    //Criar no do grupo de produto
                    if (cd_grupo.Trim() != lProdutos.Rows[i]["CD_Grupo"].ToString().Trim())
                    {
                        Array.Resize(ref nGrupo, nGrupo.Length + 1);
                        nGrupo[nGrupo.Length - 1] = new TreeNode(lProdutos.Rows[i]["CD_Grupo"].ToString().Trim() + " - " + lProdutos.Rows[i]["DS_Grupo"].ToString().Trim());
                        nGrupo[nGrupo.Length - 1].Tag = "G|";
                        nGrupo[nGrupo.Length - 1].ForeColor = Color.Red;
                        tvProduto.Nodes.Add(nGrupo[nGrupo.Length - 1]);
                        cd_grupo = lProdutos.Rows[i]["CD_Grupo"].ToString().Trim();
                    }
                    //else
                    //if (cd_grupo.Trim() != "")
                    {
                        //Criar no do produto
                        Array.Resize(ref nProd, nProd.Length + 1);
                        nProd[nProd.Length - 1] = new TreeNode(lProdutos.Rows[i]["CD_Produto"].ToString().Trim() + " - " + lProdutos.Rows[i]["DS_Produto"].ToString().Trim());
                        nProd[nProd.Length - 1].Tag = "P" + "|" + lProdutos.Rows[i]["CD_Grupo"].ToString().Trim() + "|" + lProdutos.Rows[i]["DS_Grupo"].ToString().Trim();
                        nGrupo[nGrupo.Length - 1].Nodes.Add(nProd[nProd.Length - 1]);
                    }
                }
                
            }
            tvProduto.EndUpdate();
        }

        private void MontarArvoreItensInventario()
        {
            tvItensInventario.BeginUpdate();
            tvItensInventario.Nodes.Clear();
            if (bsInventario.Current != null)
            {
                if ((bsInventario.Current as Tregistro_Inventario).lItensInventario.Count > 0)
                {
                    string cd_grupo = "";
                    TreeNode[] nGrupo = new TreeNode[0];
                    TreeNode[] nProd = new TreeNode[0];
                   foreach (TRegistro_Inventario_Item reg in (bsInventario.Current as Tregistro_Inventario).lItensInventario)
                    {
                        //Criar no do grupo de produto
                        if (cd_grupo.Trim() != reg.Cd_grupo.Trim())
                        {
                            Array.Resize(ref nGrupo, nGrupo.Length + 1);
                            nGrupo[nGrupo.Length - 1] = new TreeNode(reg.Cd_grupo.Trim() + " - " + reg.Ds_grupo.Trim());
                            nGrupo[nGrupo.Length - 1].Tag = "G|";
                            nGrupo[nGrupo.Length - 1].ForeColor = Color.Red;
                            tvItensInventario.Nodes.Add(nGrupo[nGrupo.Length - 1]);
                            cd_grupo = reg.Cd_grupo.Trim();
                        }
                        //Criar no do produto
                        Array.Resize(ref nProd, nProd.Length + 1);
                        nProd[nProd.Length - 1] = new TreeNode(reg.Cd_produto.Trim() + " - " + reg.Ds_produto.Trim());
                        nProd[nProd.Length - 1].Tag = "P" + "|" + reg.Cd_grupo.Trim() + "|" + reg.Ds_grupo.Trim();
                        nGrupo[nGrupo.Length - 1].Nodes.Add(nProd[nProd.Length - 1]);
                    }
                    
                }
            }
            tvItensInventario.EndUpdate();
        }

        public override void formatZero()
        {
            panelDados1.set_FormatZero();
        }

        public override void habilitarControls(bool value)
        {
            panelDados1.HabilitarControls(value, vTP_Modo);
        }

        public override string gravarRegistro()
        {
            return TCN_LanInventario.GravarInventario((bsInventario.Current as Tregistro_Inventario), null);
        }

        public override void afterGrava()
        {
            if (panelDados1.validarCampoObrigatorio())
            {
                base.afterGrava();
                tvItensInventario.Enabled = false;
                tvProduto.Enabled = false;
            }
        }

        public override int buscarRegistros()
        {
            Tlist_Inventario lista = TCN_LanInventario.Busca(id_inventario.Value,
                                                            cd_empresa.Text,
                                                            "", 0, "", null);
            if (lista != null)
            {
                if (lista.Count > 0)
                {
                    this.Lista = lista;
                    bsInventario.DataSource = lista;
                    bsInventario_PositionChanged(this, new EventArgs());
                }
                else
                    if ((vTP_Modo == TTpModo.tm_Standby) || (vTP_Modo == TTpModo.tm_busca))
                        bsInventario.Clear();
                return lista.Count;
            }
            else
                return 0;
        }

        public override void afterNovo()
        {
            if ((vTP_Modo == TTpModo.tm_busca) || (vTP_Modo == TTpModo.tm_Standby))
            {
                cbIncluirItens.Enabled = true;
                this.vTP_Modo = TTpModo.tm_Insert;
                bsInventario.AddNew();
                base.afterNovo();
                id_inventario.Enabled = false;
                dt_inventario.Focus();
                tvProduto.Enabled = true;
                tvItensInventario.Enabled = true;
                tvItensInventario.Nodes.Clear();
                bb_saldoInventario.Visible = (((bsInventario.Current as Tregistro_Inventario).lItensInventario.Count > 0)
                                                        && ((vTP_Modo.Equals(TTpModo.tm_Standby) || (vTP_Modo.Equals(TTpModo.tm_busca)))));
            }
        }

        public override void afterCancela()
        {
            base.afterCancela();
            cbIncluirItens.Checked = false;
            cbIncluirItens.Enabled = false;
            tvProduto.Enabled = false;
            tvItensInventario.Enabled = false;
            if (vTP_Modo == TTpModo.tm_Insert)
                bsInventario.RemoveCurrent();
        }

        public override void afterAltera()
        {
            base.afterAltera();
            cbIncluirItens.Enabled = true;
            tvItensInventario.Enabled = true;
            tvProduto.Enabled = true;
            dt_inventario.Focus();
            bb_saldoInventario.Visible = (((bsInventario.Current as Tregistro_Inventario).lItensInventario.Count > 0)
                                                        && ((vTP_Modo.Equals(TTpModo.tm_Standby) || (vTP_Modo.Equals(TTpModo.tm_busca)))));
        }

        public override void excluirRegistro()
        {
            if (bsInventario.Current != null)
            {
                if ((bsInventario.Current as Tregistro_Inventario).St_inventario.Trim().ToUpper().Equals("P"))
                {
                    MessageBox.Show("Não é permitido excluir inventario processado.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (MessageBox.Show("Confirma Exclusão do Inventario?", "Mensagem",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) ==
                        System.Windows.Forms.DialogResult.Yes)
                {
                    try
                    {
                        TCN_LanInventario.DeletarInventario((bsInventario.Current as Tregistro_Inventario), null);
                        panelDados1.LimparRegistro();
                    }
                    catch (Exception ex)
                    { MessageBox.Show("Erro: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
            }
        }

        public override void afterBusca()
        {
            base.afterBusca();
            tvProduto.Enabled = false;
            tvItensInventario.Enabled = false;
        }

        public override void afterExclui()
        {
            base.afterExclui();
            tvItensInventario.Enabled = false;
            tvProduto.Enabled = false;
        }

        public override void afterPrint()
        {
            DTS = new BindingSource();
            DTS.DataSource = TCN_LanInventario.Busca((bsInventario.Current as Tregistro_Inventario).Id_inventario);
            using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
            {
                FormRelPadrao.Relatorio Rel = new FormRelPadrao.Relatorio();
                Rel.Altera_Relatorio = Altera_Relatorio;
                Rel.DTS_Relatorio = DTS;
                Rel.Nome_Relatorio = "REST_ItensInventario";
                Rel.NM_Classe = "REST_ItensInventario";
                Rel.Modulo = string.Empty;
                fImp.St_enabled_enviaremail = true;
                fImp.pCd_clifor = string.Empty;
                fImp.pMensagem = "RELATORIO INVENTARIO DE ESTOQUE";

                if (Altera_Relatorio)
                {
                    Rel.Gera_Relatorio(string.Empty,
                                                fImp.pSt_imprimir,
                                                fImp.pSt_visualizar,
                                                fImp.pSt_enviaremail,
                                                fImp.pDestinatarios,
                                                fImp.pPrioridade,
                                                "RELATORIO INVENTARIO DE ESTOQUE",
                                                fImp.pDs_mensagem,
                                                fImp.pExportacao);
                    Altera_Relatorio = false;
                }
                else
                    if ((fImp.ShowDialog() == DialogResult.OK) || (fImp.pSt_enviaremail))
                        Rel.Gera_Relatorio(string.Empty,
                                                fImp.pSt_imprimir,
                                                fImp.pSt_visualizar,
                                                fImp.pSt_enviaremail,
                                                fImp.pDestinatarios,
                                                fImp.pPrioridade,
                                                "RELATORIO INVENTARIO DE ESTOQUE",
                                                fImp.pDs_mensagem,
                                                fImp.pExportacao);
            }
        }
        
        private void TFLan_Inventario_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Utils.Parametros.pubCultura))
                Idioma.TIdioma.AjustaCultura(this);
            lblProdutos.BackColor = Utils.SettingsUtils.Default.COLOR_1;
            lblItensInventario.BackColor = Utils.SettingsUtils.Default.COLOR_1;
            MontarArvoreProdutos();
        }

        private void bb_empresa_Click(object sender, EventArgs e)
        {
            string vColunas = "a.NM_Empresa|Empresa|350;" +
                              "a.CD_Empresa|Código|100";
            string vParamFixo = "|EXISTS|(select 1 from tb_div_usuario_x_empresa x " +
                                "where x.cd_empresa = a.cd_empresa " +
                                "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                                "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                "       where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_empresa, nm_empresa },
                                    new CamadaDados.Diversos.TCD_CadEmpresa(), vParamFixo);
        }

        private void cd_empresa_Leave(object sender, EventArgs e)
        {
            string vParam = "a.CD_Empresa|=|'" + cd_empresa.Text.Trim() + "';" +
                            "|EXISTS|(select 1 from tb_div_usuario_x_empresa x " +
                                "where x.cd_empresa = a.cd_empresa " +
                                "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                                "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                "       where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_empresa, nm_empresa }, new CamadaDados.Diversos.TCD_CadEmpresa());
        }
        
        private void bsInventario_PositionChanged(object sender, EventArgs e)
        {
            if((this.vTP_Modo != TTpModo.tm_Insert) && (this.vTP_Modo != TTpModo.tm_Edit))
                if (bsInventario.Current != null)
                {
                    (bsInventario.Current as Tregistro_Inventario).lItensInventario = TCN_Inventario_Item.Busca((bsInventario.Current as Tregistro_Inventario).Id_inventario,
                                                                                                                string.Empty,
                                                                                                                0,
                                                                                                                string.Empty,
                                                                                                                null);
                    MontarArvoreItensInventario();
                        bb_saldoInventario.Visible = (((bsInventario.Current as Tregistro_Inventario).lItensInventario.Count > 0)
                                                        && ((vTP_Modo.Equals(TTpModo.tm_Standby) || (vTP_Modo.Equals(TTpModo.tm_busca)))));
                }
        }

        private void TFLan_Inventario_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode.Equals(Keys.F9))
                bb_saldoInventario_Click(this, new EventArgs());
            else if (e.Control && e.KeyCode.Equals(Keys.P))
            {
                Altera_Relatorio = true;
                MessageBox.Show("Execute o relatório que deseja alterar!", "Mensagem");
            }
        }

        private void tlist_InventarioDataGridDefault_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null)
                if (e.ColumnIndex == 5)
                {
                    if (e.Value.ToString().Trim().ToUpper().Equals("PROCESSADO"))
                    {
                        DataGridViewRow linha = tlist_InventarioDataGridDefault.Rows[e.RowIndex];
                        linha.DefaultCellStyle.ForeColor = Color.Blue;
                    }
                    else
                    {
                        DataGridViewRow linha = tlist_InventarioDataGridDefault.Rows[e.RowIndex];
                        linha.DefaultCellStyle.ForeColor = Color.Black;
                    }
                }
        }

        private void tsmiIncluir_Click(object sender, EventArgs e)
        {
            if(tvProduto.SelectedNode != null)
                if (tvProduto.SelectedNode.Tag.ToString().Split(new char[] { '|' })[0].ToString().Trim().ToUpper().Equals("G"))
                {
                    //Incluir todos os produtos do grupo
                    foreach (TreeNode n in tvProduto.SelectedNode.Nodes)
                    {
                        TRegistro_Inventario_Item reg = new TRegistro_Inventario_Item()
                        {
                            Id_inventario = (bsInventario.Current as Tregistro_Inventario).Id_inventario,
                            Cd_produto = n.Text.Split(new char[] { '-' })[0],
                            Ds_produto = n.Text.Split(new char[] { '-' })[1],
                            Cd_grupo = n.Tag.ToString().Split(new char[] { '|' })[1].Trim(),
                            Ds_grupo = n.Tag.ToString().Split(new char[] { '|' })[2].Trim()
                        };
                        if (!(bsInventario.Current as Tregistro_Inventario).lItensInventario.Exists(p => p.Id_inventario.Equals(reg.Id_inventario)
                            && p.Cd_produto.Trim().Equals(reg.Cd_produto.Trim()) && p.Cd_grupo.Trim().Equals(reg.Cd_grupo.Trim())))
                            //Incluir o produto
                            (bsInventario.Current as Tregistro_Inventario).lItensInventario.Add(reg);
                    }
                    MontarArvoreItensInventario();
                }
                else if (tvProduto.SelectedNode.Tag.ToString().Split(new char[] { '|' })[0].ToString().Trim().ToUpper().Equals("P"))
                {
                    TRegistro_Inventario_Item reg = new TRegistro_Inventario_Item()
                    {
                        Id_inventario = (bsInventario.Current as Tregistro_Inventario).Id_inventario,
                        Cd_produto = tvProduto.SelectedNode.Text.Split(new char[] { '-' })[0],
                        Ds_produto = tvProduto.SelectedNode.Text.Split(new char[] { '-' })[1],
                        Cd_grupo = tvProduto.SelectedNode.Tag.ToString().Split(new char[] { '|' })[1].Trim(),
                        Ds_grupo = tvProduto.SelectedNode.Tag.ToString().Split(new char[] { '|' })[2].Trim()
                    };
                    if (!(bsInventario.Current as Tregistro_Inventario).lItensInventario.Exists(p => p.Id_inventario.Equals(reg.Id_inventario)
                        && p.Cd_produto.Trim().Equals(reg.Cd_produto.Trim()) && p.Cd_grupo.Trim().Equals(reg.Cd_grupo.Trim())))
                        //Incluir o produto
                        (bsInventario.Current as Tregistro_Inventario).lItensInventario.Add(reg);
                    MontarArvoreItensInventario();
                }
        }

        private void tsmiExcluir_Click(object sender, EventArgs e)
        {
            if(tvItensInventario.SelectedNode != null)
                if (tvItensInventario.SelectedNode.Tag.ToString().Split(new char[] { '|' })[0].ToString().Trim().ToUpper().Equals("G"))
                {
                    foreach (TreeNode n in tvItensInventario.SelectedNode.Nodes)
                    {
                        TRegistro_Inventario_Item reg = new TRegistro_Inventario_Item()
                        {
                            Id_inventario = (bsInventario.Current as Tregistro_Inventario).Id_inventario,
                            Cd_produto = n.Text.Split(new char[] { '-' })[0],
                            Ds_produto = n.Text.Split(new char[] { '-' })[1],
                            Cd_grupo = n.Tag.ToString().Split(new char[] { '|' })[1].Trim(),
                            Ds_grupo = n.Tag.ToString().Split(new char[] { '|' })[2].Trim()
                        };
                        //Verificar se o item possui movimentacao de saldo
                        if (vTP_Modo == TTpModo.tm_Insert)
                        {
                            (bsInventario.Current as Tregistro_Inventario).lItensInventario.Remove((bsInventario.Current as Tregistro_Inventario).lItensInventario.Find(delegate(TRegistro_Inventario_Item val)
                            { return (val.Id_inventario.Equals(reg.Id_inventario) && val.Cd_produto.Trim().Equals(reg.Cd_produto.Trim())); }));
                        }
                        else
                        {
                            if (new CamadaDados.Estoque.TCD_Inventario_Item_X_Saldo().BuscarSaldoEscalar(new TpBusca[]
                            {
                                new TpBusca()
                                {
                                    vNM_Campo = "a.ID_Inventario",
                                    vOperador = "=",
                                    vVL_Busca = reg.Id_inventario.ToString()
                                },
                                new TpBusca()
                                {
                                    vNM_Campo = "a.cd_produto",
                                    vOperador = "=",
                                    vVL_Busca = "'" + reg.Cd_produto.Trim() + "'"
                                }
                            }, "1, 0)") == null)
                            {
                                (bsInventario.Current as Tregistro_Inventario).lItensInventario.Remove((bsInventario.Current as Tregistro_Inventario).lItensInventario.Find(delegate(TRegistro_Inventario_Item val)
                                { return (val.Id_inventario.Equals(reg.Id_inventario) && val.Cd_produto.Trim().Equals(reg.Cd_produto.Trim())); }));
                            }
                            else
                                MessageBox.Show("Não é permitido excluir item com movimentação de saldo!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    MontarArvoreItensInventario();
                }
                else if (tvItensInventario.SelectedNode.Tag.ToString().Split(new char[] { '|' })[0].ToString().Trim().ToUpper().Equals("P"))
                {
                    //Excluir o produto
                    TRegistro_Inventario_Item reg = new TRegistro_Inventario_Item()
                    {
                        Id_inventario = (bsInventario.Current as Tregistro_Inventario).Id_inventario,
                        Cd_produto = tvItensInventario.SelectedNode.Text.Split(new char[] { '-' })[0],
                        Ds_produto = tvItensInventario.SelectedNode.Text.Split(new char[] { '-' })[1],
                        Cd_grupo = tvItensInventario.SelectedNode.Tag.ToString().Split(new char[] { '|' })[1].Trim(),
                        Ds_grupo = tvItensInventario.SelectedNode.Tag.ToString().Split(new char[] { '|' })[2].Trim()
                    };
                    if (vTP_Modo == TTpModo.tm_Insert)
                    {
                        if ((bsInventario.Current as Tregistro_Inventario).lItensInventario.Remove((bsInventario.Current as Tregistro_Inventario).lItensInventario.Find(delegate(TRegistro_Inventario_Item val)
                        { return (val.Id_inventario.Equals(reg.Id_inventario) && val.Cd_produto.Trim().Equals(reg.Cd_produto.Trim())); })))
                            MontarArvoreItensInventario();
                    }
                    else
                    {
                        if (new CamadaDados.Estoque.TCD_Inventario_Item_X_Saldo().BuscarSaldoEscalar(new TpBusca[]
                            {
                                new TpBusca()
                                {
                                    vNM_Campo = "a.ID_Inventario",
                                    vOperador = "=",
                                    vVL_Busca = reg.Id_inventario.ToString()
                                },
                                new TpBusca()
                                {
                                    vNM_Campo = "a.cd_produto",
                                    vOperador = "=",
                                    vVL_Busca = "'" + reg.Cd_produto.Trim() + "'"
                                }
                            }, "1, 0)") == null)
                        {
                            if ((bsInventario.Current as Tregistro_Inventario).lItensInventario.Remove((bsInventario.Current as Tregistro_Inventario).lItensInventario.Find(delegate(TRegistro_Inventario_Item val)
                            { return (val.Id_inventario.Equals(reg.Id_inventario) && val.Cd_produto.Trim().Equals(reg.Cd_produto.Trim())); })))
                                MontarArvoreItensInventario();
                        }
                        else
                            MessageBox.Show("Não é permitido excluir item com movimentação de saldo!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
        }

        private void cbIncluirItens_CheckedChanged(object sender, EventArgs e)
        {
            pPeriodo.Visible = cbIncluirItens.Checked;
        }

        private void bb_incluir_Click(object sender, EventArgs e)
        {
            if (cd_empresa.Text.Trim().Equals(string.Empty))
            {
                MessageBox.Show("Obrigatorio informar empresa.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cd_empresa.Focus();
                return;
            }
            if (dt_inicial.Text.Trim().Equals(string.Empty) ||
                dt_inicial.Text.Trim().Equals("/  /"))
            {
                MessageBox.Show("Obrigatorio informar data inicial.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dt_inicial.Focus();
                return;
            }
            if(dt_final.Text.Trim().Equals(string.Empty) ||
                dt_final.Text.Trim().Equals("/  /"))
            {
                MessageBox.Show("Obrigatorio informar data final.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dt_final.Focus();
                return;
            }
            //Buscar lista de itens movimentados dentro do periodo
            TList_RegLanEstoque lEstoque = TCN_LanEstoque.Busca(cd_empresa.Text,
                                                                string.Empty,
                                                                string.Empty,
                                                                string.Empty,
                                                                string.Empty,
                                                                string.Empty,
                                                                string.Empty,
                                                                string.Empty,
                                                                string.Empty,
                                                                string.Empty,
                                                                dt_inicial.Text,
                                                                dt_final.Text,
                                                                "A",
                                                                string.Empty,
                                                                string.Empty,
                                                                false,
                                                                false,
                                                                false,
                                                                false,
                                                                false,
                                                                false,
                                                                0,
                                                                string.Empty,
                                                                "c.cd_grupo, a.cd_produto");
            foreach (TRegistro_LanEstoque rEstoque in lEstoque)
            {
                TRegistro_Inventario_Item reg = new TRegistro_Inventario_Item()
                {
                    Id_inventario = (bsInventario.Current as Tregistro_Inventario).Id_inventario,
                    Cd_produto = rEstoque.Cd_produto,
                    Ds_produto = rEstoque.Ds_produto,
                    Cd_grupo = rEstoque.Cd_grupo,
                    Ds_grupo = rEstoque.Ds_grupo
                };
                if (!(bsInventario.Current as Tregistro_Inventario).lItensInventario.Exists(p => p.Id_inventario.Equals(reg.Id_inventario)
                    && p.Cd_produto.Trim().Equals(reg.Cd_produto.Trim()) && p.Cd_grupo.Trim().Equals(reg.Cd_grupo.Trim())))
                    //Incluir o produto
                    (bsInventario.Current as Tregistro_Inventario).lItensInventario.Add(reg);
            }
            MontarArvoreItensInventario();
        }
    }
}
