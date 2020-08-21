using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Faturamento
{
    public partial class TFProgEspecialVenda : Form
    {
        private CamadaDados.Faturamento.ProgEspecialVenda.TRegistro_ProgEspecialVenda rprog;
        public CamadaDados.Faturamento.ProgEspecialVenda.TRegistro_ProgEspecialVenda rProg
        {
            get
            {
                if (bsProgEspecialVenda.Current != null)
                    return bsProgEspecialVenda.Current as CamadaDados.Faturamento.ProgEspecialVenda.TRegistro_ProgEspecialVenda;
                else
                    return null;
            }
            set { rprog = value; }
        }
        public List<CamadaDados.Estoque.Cadastros.TRegistro_CadGrupoProduto> lGrupo { get; set; }
        public TFProgEspecialVenda()
        {
            InitializeComponent();
            System.Collections.ArrayList cbx = new System.Collections.ArrayList();
            cbx.Add(new Utils.TDataCombo("NORMAL", "N"));
            cbx.Add(new Utils.TDataCombo("CUSTO", "C"));
            tp_preco.DataSource = cbx;
            tp_preco.DisplayMember = "Display";
            tp_preco.ValueMember = "Value";

            System.Collections.ArrayList cbx1 = new System.Collections.ArrayList();
            cbx1.Add(new Utils.TDataCombo("ACRESCIMO", "A"));
            cbx1.Add(new Utils.TDataCombo("DESCONTO", "D"));
            tp_acresdesc.DataSource = cbx1;
            tp_acresdesc.DisplayMember = "Display";
            tp_acresdesc.ValueMember = "Value";

            System.Collections.ArrayList cbx2 = new System.Collections.ArrayList();
            cbx2.Add(new Utils.TDataCombo("PERCENTUAL", "P"));
            cbx2.Add(new Utils.TDataCombo("VALOR", "V"));
            tp_valor.DataSource = cbx2;
            tp_valor.DisplayMember = "Display";
            tp_valor.ValueMember = "Value";
        }

        private void afterGrava()
        {
            if (pDados.validarCampoObrigatorio())
            {
                if (string.IsNullOrEmpty(id_categoriaclifor.Text) &&
                    string.IsNullOrEmpty(cd_clifor.Text))
                {
                    MessageBox.Show("Obrigatorio informar CATEGORIA CLIENTE ou CLIENTE para gravar programação venda.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    id_categoriaclifor.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(cd_grupo.Text) &&
                    string.IsNullOrEmpty(cd_produto.Text))
                {
                    if (rprog == null)
                    {
                        using (TFListaGrupoProd fLista = new TFListaGrupoProd())
                        {
                            fLista.ShowDialog();
                            if(fLista.lGrupo == null ? true : fLista.lGrupo.Count.Equals(0))
                            {
                                MessageBox.Show("Obrigatório informar GRUPO PRODUTO para gravar programação venda.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                cd_grupo.Focus();
                                return;
                            }
                            lGrupo = fLista.lGrupo;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Obrigatorio informar GRUPO PRODUTO ou PRODUTO para gravar programação venda.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cd_grupo.Focus();
                        return;
                    }
                }
                if (lGrupo == null ? false : lGrupo.Count > 0)
                {
                    lGrupo.ForEach(p=>
                    {
                        //Verificar se programação especial de venda ja existe
                        object id = new CamadaDados.Faturamento.ProgEspecialVenda.TCD_ProgEspecialVenda().BuscarEscalar(new Utils.TpBusca[]
                                                    {
                                                        new Utils.TpBusca()
                                                        {
                                                            vNM_Campo = "a.id_prog",
                                                            vOperador = rprog != null ? "<>" : "=",
                                                            vVL_Busca = rprog != null ? rprog.Id_progstr : "a.id_prog"
                                                        },
                                                        new Utils.TpBusca()
                                                        {
                                                            vNM_Campo = "a.cd_empresa",
                                                            vOperador = "=",
                                                            vVL_Busca = "'" + cd_empresa.Text.Trim() + "'"
                                                        },
                                                        new Utils.TpBusca()
                                                        {
                                                            vNM_Campo = "a.id_categoriaclifor",
                                                            vOperador = !string.IsNullOrWhiteSpace(id_categoriaclifor.Text) ? "=" : "is",
                                                            vVL_Busca = !string.IsNullOrWhiteSpace(id_categoriaclifor.Text) ? id_categoriaclifor.Text : "null"
                                                        },
                                                        new Utils.TpBusca()
                                                        {
                                                            vNM_Campo = "a.cd_clifor",
                                                            vOperador = string.IsNullOrEmpty(cd_clifor.Text) ? "is" : "=",
                                                            vVL_Busca = string.IsNullOrEmpty(cd_clifor.Text) ? "null" : "'" + cd_clifor.Text.Trim() + "'"
                                                        },
                                                        new Utils.TpBusca()
                                                        {
                                                            vNM_Campo = "a.cd_grupo",
                                                            vOperador = string.IsNullOrEmpty(p.CD_Grupo) ? "is" : "=",
                                                            vVL_Busca = string.IsNullOrEmpty(p.CD_Grupo) ? "null" : "'" + p.CD_Grupo.Trim() + "'"
                                                        },
                                                        new Utils.TpBusca()
                                                        {
                                                            vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.dt_finvigencia)))",
                                                            vOperador = ">=",
                                                            vVL_Busca = "'" + DateTime.Parse(dt_inivigencia.Text).ToString("yyyyMMdd") + "'"
                                                        }
                                                    }, "a.id_prog");
                        if (id != null)
                        {
                            MessageBox.Show("Existe programação especial de venda<" + id.ToString() + "> com data final de vigência maior que a data inicial do cadastro.",
                                "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    });
                }
                else
                {
                    //Verificar se existe programação especial de venda com vigencia dentro do periodo
                    object id = new CamadaDados.Faturamento.ProgEspecialVenda.TCD_ProgEspecialVenda().BuscarEscalar(new Utils.TpBusca[]
                                                        {
                                                            new Utils.TpBusca()
                                                            {
                                                                vNM_Campo = "a.id_prog",
                                                                vOperador = rprog != null ? "<>" : "=",
                                                                vVL_Busca = rprog != null ? rprog.Id_progstr : "a.id_prog"
                                                            },
                                                            new Utils.TpBusca()
                                                            {
                                                                vNM_Campo = "a.cd_empresa",
                                                                vOperador = "=",
                                                                vVL_Busca = "'" + cd_empresa.Text.Trim() + "'"
                                                            },
                                                            new Utils.TpBusca()
                                                            {
                                                                vNM_Campo = "a.id_categoriaclifor",
                                                                vOperador = !string.IsNullOrWhiteSpace(id_categoriaclifor.Text) ? "=" : "is",
                                                                vVL_Busca = !string.IsNullOrWhiteSpace(id_categoriaclifor.Text) ? id_categoriaclifor.Text : "null"
                                                            },
                                                            new Utils.TpBusca()
                                                            {
                                                                vNM_Campo = "a.cd_clifor",
                                                                vOperador = string.IsNullOrEmpty(cd_clifor.Text) ? "is" : "=",
                                                                vVL_Busca = string.IsNullOrEmpty(cd_clifor.Text) ? "null" : "'" + cd_clifor.Text.Trim() + "'"
                                                            },
                                                            new Utils.TpBusca()
                                                            {
                                                                vNM_Campo = "a.cd_grupo",
                                                                vOperador = string.IsNullOrEmpty(cd_grupo.Text) ? "is" : "=",
                                                                vVL_Busca = string.IsNullOrEmpty(cd_grupo.Text) ? "null" : "'" + cd_grupo.Text.Trim() + "'"
                                                            },
                                                            new Utils.TpBusca()
                                                            {
                                                                vNM_Campo = "a.cd_produto",
                                                                vOperador = string.IsNullOrEmpty(cd_produto.Text) ? "is" : "=",
                                                                vVL_Busca = string.IsNullOrEmpty(cd_produto.Text) ? "null" : "'" + cd_produto.Text.Trim() + "'"
                                                            },
                                                            new Utils.TpBusca()
                                                            {
                                                                vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.dt_finvigencia)))",
                                                                vOperador = ">=",
                                                                vVL_Busca = "'" + DateTime.Parse(dt_inivigencia.Text).ToString("yyyyMMdd") + "'"
                                                            }
                                                        }, "a.id_prog");
                    if (id != null)
                    {
                        MessageBox.Show("Existe programação especial de venda<" + id.ToString() + "> com data final de vigência maior que a data inicial do cadastro.",
                            "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
                DialogResult = DialogResult.OK;
            }
        }

        private string VerificarProgVenda()
        {
            if (!string.IsNullOrEmpty(cd_empresa.Text) &&
                (!string.IsNullOrEmpty(id_categoriaclifor.Text) ||
                !string.IsNullOrEmpty(cd_clifor.Text)) &&
                (!string.IsNullOrEmpty(cd_grupo.Text) ||
                !string.IsNullOrEmpty(cd_produto.Text)) &&
                (!string.IsNullOrEmpty(cd_tabelapreco.Text)) ||
                (!string.IsNullOrEmpty(id_tabelaprecoloc.Text)))
            {
                object id = new CamadaDados.Faturamento.ProgEspecialVenda.TCD_ProgEspecialVenda().BuscarEscalar(
                                new Utils.TpBusca[]
                                {
                                    new Utils.TpBusca()
                                    {
                                        vNM_Campo = "a.cd_empresa",
                                        vOperador = "=",
                                        vVL_Busca = "'" + cd_empresa.Text.Trim() + "'"
                                    },
                                    new Utils.TpBusca()
                                    {
                                        vNM_Campo = "a.id_categoriaclifor",
                                        vOperador = !string.IsNullOrEmpty(id_categoriaclifor.Text) ? "=" : "is",
                                        vVL_Busca = !string.IsNullOrEmpty(id_categoriaclifor.Text) ? id_categoriaclifor.Text : "null"
                                    },
                                    new Utils.TpBusca()
                                    {
                                        vNM_Campo = "a.cd_clifor",
                                        vOperador = string.IsNullOrEmpty(cd_clifor.Text) ? "is" : "=",
                                        vVL_Busca = string.IsNullOrEmpty(cd_clifor.Text) ? "null" : "'" + cd_clifor.Text.Trim() + "'"
                                    },
                                    new Utils.TpBusca()
                                    {
                                        vNM_Campo = "a.cd_grupo",
                                        vOperador = string.IsNullOrEmpty(cd_grupo.Text) ? "is" : "=",
                                        vVL_Busca = string.IsNullOrEmpty(cd_grupo.Text) ? "null" : "'" + cd_grupo.Text.Trim() + "'"
                                    },
                                    new Utils.TpBusca()
                                    {
                                        vNM_Campo = "a.cd_produto",
                                        vOperador = string.IsNullOrEmpty(cd_produto.Text) ? "is" : "=",
                                        vVL_Busca = string.IsNullOrEmpty(cd_produto.Text) ? "null" : "'" + cd_produto.Text.Trim() + "'"
                                    },
                                    new Utils.TpBusca()
                                    {
                                        vNM_Campo = cd_tabelapreco.Visible ? "a.cd_tabelapreco" : "a.id_tabelalocacao",
                                        vOperador = "=",
                                        vVL_Busca = "'" + (cd_tabelapreco.Visible ? cd_tabelapreco.Text.Trim() : id_tabelaprecoloc.Text.Trim()) + "'"
                                    }
                                }, "a.id_prog");
                return id == null ? string.Empty : id.ToString();
            }
            else return string.Empty;
        }

        private void TFProgEspecialVenda_Load(object sender, EventArgs e)
        {
            Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pDados.set_FormatZero();
            if (rprog != null)
            {
                bsProgEspecialVenda.DataSource = new CamadaDados.Faturamento.ProgEspecialVenda.TList_ProgEspecialVenda() { rprog };
                cd_empresa.Enabled = false;
                bb_empresa.Enabled = false;
                id_categoriaclifor.Enabled = false;
                bb_categoriaclifor.Enabled = false;
                cd_clifor.Enabled = false;
                bb_clifor.Enabled = false;
                cd_grupo.Enabled = false;
                bb_grupo.Enabled = false;
                cd_produto.Enabled = false;
                bb_produto.Enabled = false;
                cd_tabelapreco.Enabled = false;
                bb_tabelapreco.Enabled = false;
                id_tabelaprecoloc.Enabled = false;
                bb_tabelaprecoloc.Enabled = false;
                tp_preco.Focus();
            }
            else
            {
                bsProgEspecialVenda.AddNew();
                cd_empresa.Focus();
            }

            if (new CamadaDados.Locacao.Cadastros.TCD_CFGLocacao().BuscarEscalar(null, "1") != null)
            {
                lbTabelalocacao.Visible = true;
                id_tabelaprecoloc.Visible = true;
                bb_tabelaprecoloc.Visible = true;
                ds_tabelaprecoloc.Visible = true;
                lbTabela.Visible = false;
                cd_tabelapreco.Visible = false;
                bb_tabelapreco.Visible = false;
                ds_tabelapreco.Visible = false;
            }
        }

        private void bb_empresa_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaEmpresa(new Componentes.EditDefault[] { cd_empresa, nm_empresa }, string.Empty);
            if (!string.IsNullOrEmpty(VerificarProgVenda()))
                if (MessageBox.Show("Existe condição especial de venda para a condição informada. Deseja alterar a mesma?", "Pergunta",
                     MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) != DialogResult.Yes)
                {
                    cd_empresa.Clear();
                    cd_empresa.Focus();
                }
        }

        private void cd_empresa_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveEmpresa("a.cd_empresa|=|'" + cd_empresa.Text.Trim() + "'",
                                                        new Componentes.EditDefault[] { cd_empresa, nm_empresa });
            if (!string.IsNullOrEmpty(VerificarProgVenda()))
                if (MessageBox.Show("Existe condição especial de venda para a condição informada. Deseja alterar a mesma?", "Pergunta",
                     MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) != DialogResult.Yes)
                {
                    cd_empresa.Clear();
                    cd_empresa.Focus();
                }
        }

        private void bb_categoriaclifor_Click(object sender, EventArgs e)
        {
            string vColunas = "Ds_CategoriaCliFor|Categoria Cliente|200;" +
                              "Id_CategoriaCliFor|Id. Categoria|80";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { id_categoriaclifor, ds_categoriaclifor },
                                            new CamadaDados.Financeiro.Cadastros.TCD_CadCategoriaCliFor(), string.Empty);
            if (!string.IsNullOrEmpty(VerificarProgVenda()))
                if (MessageBox.Show("Existe condição especial de venda para a condição informada. Deseja alterar a mesma?", "Pergunta",
                     MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) != DialogResult.Yes)
                {
                    id_categoriaclifor.Clear();
                    id_categoriaclifor.Focus();
                }
            bb_clifor.Enabled = string.IsNullOrEmpty(id_categoriaclifor.Text);
            cd_clifor.Enabled = string.IsNullOrEmpty(id_categoriaclifor.Text);
        }

        private void id_categoriaclifor_Leave(object sender, EventArgs e)
        {
            string vParam = "a.Id_CategoriaCliFor|=|" + id_categoriaclifor.Text;
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { id_categoriaclifor, ds_categoriaclifor },
                                            new CamadaDados.Financeiro.Cadastros.TCD_CadCategoriaCliFor());
            if (!string.IsNullOrEmpty(VerificarProgVenda()))
                if (MessageBox.Show("Existe condição especial de venda para a condição informada. Deseja alterar a mesma?", "Pergunta",
                     MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) != DialogResult.Yes)
                {
                    id_categoriaclifor.Clear();
                    id_categoriaclifor.Focus();
                }
            bb_clifor.Enabled = string.IsNullOrEmpty(id_categoriaclifor.Text);
            cd_clifor.Enabled = string.IsNullOrEmpty(id_categoriaclifor.Text);
        }

        private void bb_grupo_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_grupo|Grupo Produto|200;" +
                              "a.cd_grupo|Cd. Grupo|80";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_grupo, ds_grupo },
                                            new CamadaDados.Estoque.Cadastros.TCD_CadGrupoProduto(), "a.tp_grupo|=|'A'");
            if (!string.IsNullOrEmpty(VerificarProgVenda()))
                if (MessageBox.Show("Existe condição especial de venda para a condição informada. Deseja alterar a mesma?", "Pergunta",
                     MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) != DialogResult.Yes)
                {
                    cd_grupo.Clear();
                    cd_grupo.Focus();
                }
            bb_produto.Enabled = string.IsNullOrEmpty(cd_grupo.Text);
            cd_produto.Enabled = string.IsNullOrEmpty(cd_grupo.Text);
        }

        private void cd_grupo_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LEAVE("a.cd_grupo|=|'" + cd_grupo.Text.Trim() + "';"+
                                              "a.tp_grupo|=|'A'",
                                              new Componentes.EditDefault[] { cd_grupo, ds_grupo },
                                              new CamadaDados.Estoque.Cadastros.TCD_CadGrupoProduto());
            if (!string.IsNullOrEmpty(VerificarProgVenda()))
                if (MessageBox.Show("Existe condição especial de venda para a condição informada. Deseja alterar a mesma?", "Pergunta",
                     MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) != DialogResult.Yes)
                {
                    cd_grupo.Clear();
                    cd_grupo.Focus();
                }
            bb_produto.Enabled = string.IsNullOrEmpty(cd_grupo.Text);
            cd_produto.Enabled = string.IsNullOrEmpty(cd_grupo.Text);
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            afterGrava();
        }

        private void TFProgEspecialVenda_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                DialogResult = DialogResult.Cancel;
        }

        private void bb_clifor_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { cd_clifor, nm_clifor }, string.Empty);
            if (!string.IsNullOrEmpty(VerificarProgVenda()))
                if (MessageBox.Show("Existe condição especial de venda para a condição informada. Deseja alterar a mesma?", "Pergunta",
                     MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) != DialogResult.Yes)
                {
                    cd_clifor.Clear();
                    cd_clifor.Focus();
                }
            bb_categoriaclifor.Enabled = string.IsNullOrEmpty(cd_clifor.Text);
            id_categoriaclifor.Enabled = string.IsNullOrEmpty(cd_clifor.Text);
        }

        private void cd_clifor_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveClifor("a.cd_clifor|=|'" + cd_clifor.Text.Trim() + "'",
                new Componentes.EditDefault[] { cd_clifor, nm_clifor }, new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
            if (!string.IsNullOrEmpty(VerificarProgVenda()))
                if (MessageBox.Show("Existe condição especial de venda para a condição informada. Deseja alterar a mesma?", "Pergunta",
                     MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) != DialogResult.Yes)
                {
                    cd_clifor.Clear();
                    cd_clifor.Focus();
                }
            bb_categoriaclifor.Enabled = string.IsNullOrEmpty(cd_clifor.Text);
            id_categoriaclifor.Enabled = string.IsNullOrEmpty(cd_clifor.Text);
        }

        private void bb_produto_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaProduto(new Componentes.EditDefault[] { cd_produto, ds_produto }, string.Empty);
            if (!string.IsNullOrEmpty(VerificarProgVenda()))
                if (MessageBox.Show("Existe condição especial de venda para a condição informada. Deseja alterar a mesma?", "Pergunta",
                     MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) != DialogResult.Yes)
                {
                    cd_produto.Clear();
                    cd_produto.Focus();
                }
            bb_grupo.Enabled = string.IsNullOrEmpty(cd_produto.Text);
            cd_grupo.Enabled = string.IsNullOrEmpty(cd_produto.Text);
        }

        private void cd_produto_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LEAVEProduto("a.cd_produto|=|'" + cd_produto.Text.Trim() + "'",
                new Componentes.EditDefault[] { cd_produto, ds_produto }, new CamadaDados.Estoque.Cadastros.TCD_CadProduto());
            if (!string.IsNullOrEmpty(VerificarProgVenda()))
                if (MessageBox.Show("Existe condição especial de venda para a condição informada. Deseja alterar a mesma?", "Pergunta",
                     MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) != DialogResult.Yes)
                {
                    cd_produto.Clear();
                    cd_produto.Focus();
                }
            bb_grupo.Enabled = string.IsNullOrEmpty(cd_produto.Text);
            cd_grupo.Enabled = string.IsNullOrEmpty(cd_produto.Text);
        }

        private void bb_tabelapreco_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_tabelapreco|Tabela Preço|200;" +
                              "a.cd_tabelapreco|Codigo|60";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_tabelapreco, ds_tabelapreco },
                new CamadaDados.Diversos.TCD_CadTbPreco(), string.Empty);
            if (!string.IsNullOrEmpty(VerificarProgVenda()))
                if (MessageBox.Show("Existe condição especial de venda para a condição informada. Deseja alterar a mesma?", "Pergunta",
                     MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) != DialogResult.Yes)
                {
                    cd_tabelapreco.Clear();
                    cd_tabelapreco.Focus();
                }
        }

        private void cd_tabelapreco_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_tabelapreco|=|'" + cd_tabelapreco.Text.Trim() + "'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_tabelapreco, ds_tabelapreco },
                new CamadaDados.Diversos.TCD_CadTbPreco());
            if (!string.IsNullOrEmpty(VerificarProgVenda()))
                if (MessageBox.Show("Existe condição especial de venda para a condição informada. Deseja alterar a mesma?", "Pergunta",
                     MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) != DialogResult.Yes)
                {
                    cd_tabelapreco.Clear();
                    cd_tabelapreco.Focus();
                }
        }

        private void id_tabelaprecoloc_Leave(object sender, EventArgs e)
        {
            string vParam = "a.ID_Tabela|=|'" + id_tabelaprecoloc.Text.Trim() + "'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { id_tabelaprecoloc, ds_tabelaprecoloc },
                new CamadaDados.Locacao.Cadastros.TCD_CadTabPreco());
            if (!string.IsNullOrEmpty(VerificarProgVenda()))
                if (MessageBox.Show("Existe condição especial de venda para a condição informada. Deseja alterar a mesma?", "Pergunta",
                     MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) != DialogResult.Yes)
                {
                    id_tabelaprecoloc.Clear();
                    id_tabelaprecoloc.Focus();
                }
        }

        private void bb_tabelaprecoloc_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_tabela|Tabela Preço|200;" +
                              "a.id_tabela|Codigo|60";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { id_tabelaprecoloc, ds_tabelaprecoloc },
                new CamadaDados.Locacao.Cadastros.TCD_CadTabPreco(), string.Empty);
            if (!string.IsNullOrEmpty(VerificarProgVenda()))
                if (MessageBox.Show("Existe condição especial de venda para a condição informada. Deseja alterar a mesma?", "Pergunta",
                     MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) != DialogResult.Yes)
                {
                    id_tabelaprecoloc.Clear();
                    id_tabelaprecoloc.Focus();
                }
        }
    }
}
