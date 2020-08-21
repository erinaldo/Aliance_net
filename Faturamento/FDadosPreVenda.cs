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
    public partial class TFDadosPreVenda : Form
    {
        public CamadaDados.Faturamento.Cadastros.TRegistro_CFGCupomFiscal rCfg
        { get; set; }
        public CamadaDados.Faturamento.PDV.TRegistro_PreVenda rVenda
        {
            get
            {
                if (bsPreVenda.Current != null)
                    return bsPreVenda.Current as CamadaDados.Faturamento.PDV.TRegistro_PreVenda;
                else return null;
            }
        }

        public TFDadosPreVenda()
        {
            InitializeComponent();
        }

        private void afterGrava()
        {
            if (string.IsNullOrEmpty(CD_Empresa.Text))
            {
                MessageBox.Show("Obrigatório informar empresa.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CD_Empresa.Focus();
                return;
            }
            if(string.IsNullOrEmpty(CD_CompVend.Text))
            {
                MessageBox.Show("Obrigatório informar vendedor.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CD_CompVend.Focus();
                return;
            }
            this.DialogResult = DialogResult.OK;
        }

        private void Busca_Endereco_Clifor()
        {
            //Busca Endereço 
            CamadaDados.Financeiro.Cadastros.TList_CadEndereco List_Endereco =
                new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco().Select(
                new TpBusca[]
                    {
                        new TpBusca()
                        {
                            vNM_Campo = "a.cd_clifor",
                            vOperador = "=",
                            vVL_Busca = "'" + (bsPreVenda.Current as CamadaDados.Faturamento.PDV.TRegistro_PreVenda).Cd_clifor.Trim() + "'"
                        }
                    }, 0, string.Empty);
            if (List_Endereco.Count > 0)
            {
                if (List_Endereco.Exists(p => p.St_enderecoentregabool))
                {
                    cd_endereco.Text = List_Endereco.Find(p => p.St_enderecoentregabool).Cd_endereco.Trim();
                    ds_endereco.Text = List_Endereco.Find(p => p.St_enderecoentregabool).Ds_endereco.Trim();
                    numero.Text = List_Endereco.Find(p => p.St_enderecoentregabool).Numero.Trim();
                    Bairro.Text = List_Endereco.Find(p => p.St_enderecoentregabool).Bairro.Trim();
                    fone.Text = List_Endereco.Find(p => p.St_enderecoentregabool).Fone.Trim();
                    proximo.Text = List_Endereco.Find(p => p.St_enderecoentregabool).Proximo.Trim();
                }
                else
                {
                    cd_endereco.Text = List_Endereco[0].Cd_endereco.Trim();
                    ds_endereco.Text = List_Endereco[0].Ds_endereco.Trim();
                    numero.Text = List_Endereco[0].Numero.Trim();
                    Bairro.Text = List_Endereco[0].Bairro.Trim();
                    fone.Text = List_Endereco[0].Fone.Trim();
                    proximo.Text = List_Endereco[0].Proximo.Trim();
                }
            }
        }

        private void bb_confirma_Click(object sender, EventArgs e)
        {
            this.afterGrava();
        }

        private void TFDadosPreVenda_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
                this.afterGrava();
            else if (e.KeyCode.Equals(Keys.Escape))
                this.DialogResult = DialogResult.Cancel;
        }

        private void TFDadosPreVenda_Load(object sender, EventArgs e)
        {
            pDados.set_FormatZero();
            bsPreVenda.AddNew();
            //Buscar vendedor Padrao
            object obj = new CamadaDados.Financeiro.Cadastros.TCD_CadClifor().BuscarEscalar(
                            new TpBusca[]
                            {
                                new TpBusca()
                                {
                                    vNM_Campo = "isnull(a.st_vendedor, 'N')",
                                    vOperador = "=",
                                    vVL_Busca = "'S'"
                                },
                                new TpBusca()
                                {
                                    vNM_Campo = "isnull(a.st_registro, 'A')",
                                    vOperador = "<>",
                                    vVL_Busca = "'C'"
                                },
                                new TpBusca()
                                {
                                    vNM_Campo = "isnull(a.st_funcativo, 'N')",
                                    vOperador = "=",
                                    vVL_Busca = "'S'"
                                },
                                new TpBusca()
                                {
                                    vNM_Campo = "a.loginvendedor",
                                    vOperador = "=",
                                    vVL_Busca = "'" + Utils.Parametros.pubLogin.Trim() + "'"
                                }
                            }, "a.cd_clifor");
            if (obj != null)
                CD_CompVend.Text = obj.ToString();
            //Buscar empresa padrao usuario
            obj = new CamadaDados.Diversos.TCD_CadUsuario_Empresa().BuscarEscalar(
                    new TpBusca[]
                        {
                            new TpBusca()
                            {
                                vNM_Campo = "a.login",
                                vOperador = "=",
                                vVL_Busca = "'" + Utils.Parametros.pubLogin.Trim() + "'"
                            }
                        }, "a.cd_empresa");
            if (obj != null)
            {
                CD_Empresa.Text = obj.ToString();
                CD_Empresa_Leave(this, new EventArgs());
            }
        }

        private void CD_Clifor_Leave(object sender, EventArgs e)
        {
            DataRow linha = FormBusca.UtilPesquisa.EDIT_LeaveClifor("a.cd_clifor|=|'" + CD_Clifor.Text.Trim() + "'", new Componentes.EditDefault[] { CD_Clifor, NM_Clifor },
                                                    new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
            this.Busca_Endereco_Clifor();
            //Verificar se Cliente é consumidor final
            if (!string.IsNullOrEmpty(CD_Clifor.Text))
                if (rCfg.Cd_clifor != CD_Clifor.Text)
                {
                    NM_Clifor.Enabled = false;
                    ds_endereco.Enabled = false;
                    numero.Visible = true;
                    Bairro.Visible = true;
                    proximo.Visible = true;
                    lbprox.Visible = true;
                    ds_endereco.Size = new Size(274, 20);
                }
                else
                {
                    NM_Clifor.Enabled = true;
                    ds_endereco.Enabled = true;
                    numero.Visible = false;
                    Bairro.Visible = false;
                    proximo.Visible = false;
                    lbprox.Visible = false;
                    ds_endereco.Size = new Size(782, 20);
                }
            if (linha != null)
                if (!string.IsNullOrEmpty(linha["id_regiao"].ToString()))
                {
                    //Verificar se Cliente pertence alguma Carteira
                    object obj = new CamadaDados.Faturamento.Cadastros.TCD_Vendedor_X_RegiaoVenda().BuscarEscalar(
                                    new TpBusca[]
                                    {
                                        new TpBusca()
                                        {
                                            vNM_Campo = "a.id_regiao",
                                            vOperador = "=",
                                            vVL_Busca = "'" + linha["id_regiao"].ToString().Trim() + "'"
                                        }

                                    }, "a.cd_vendedor");
                    if (obj != null)
                    {
                        CD_CompVend.Text = obj.ToString();
                        CD_CompVend_Leave(this, new EventArgs());
                    }
                }
                else
                {
                    CD_CompVend.Text = string.Empty;
                    NM_CompVend.Text = string.Empty;
                    CD_CompVend.Enabled = true;
                    NM_CompVend.Enabled = true;
                    BB_CompVend.Enabled = true;
                }
        }

        private void BB_Clifor_Click(object sender, EventArgs e)
        {
            DataRowView linha = FormBusca.UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { CD_Clifor, NM_Clifor }, string.Empty);
            this.Busca_Endereco_Clifor();
            //Verificar se Cliente é consumidor final
            if (!string.IsNullOrEmpty(CD_Clifor.Text))
                if (rCfg.Cd_clifor != CD_Clifor.Text)
                {
                    NM_Clifor.Enabled = false;
                    ds_endereco.Enabled = false;
                    numero.Visible = true;
                    Bairro.Visible = true;
                    proximo.Visible = true;
                    lbprox.Visible = true;
                    ds_endereco.Size = new Size(274, 20);
                }
                else
                {
                    NM_Clifor.Enabled = true;
                    ds_endereco.Enabled = true;
                    numero.Visible = false;
                    Bairro.Visible = false;
                    proximo.Visible = false;
                    lbprox.Visible = false;
                    ds_endereco.Size = new Size(782, 20);
                }
            //Verificar carteira do cliente se Usuario não tiver Vendedor padrão
            if (linha != null)
                if (!string.IsNullOrEmpty(linha["id_regiao"].ToString()))
                {
                    //Verificar se Cliente pertence alguma Carteira
                    object obj = new CamadaDados.Faturamento.Cadastros.TCD_Vendedor_X_RegiaoVenda().BuscarEscalar(
                                    new TpBusca[]
                                    {
                                        new TpBusca()
                                        {
                                            vNM_Campo = "a.id_regiao",
                                            vOperador = "=",
                                            vVL_Busca = "'" + linha["id_regiao"].ToString().Trim() + "'"
                                        }
                                    }, "a.cd_vendedor");
                    if (obj != null)
                    {
                        CD_CompVend.Text = obj.ToString();
                        CD_CompVend_Leave(this, new EventArgs());
                    }
                }
                else
                {
                    CD_CompVend.Text = string.Empty;
                    NM_CompVend.Text = string.Empty;
                    CD_CompVend.Enabled = true;
                    NM_CompVend.Enabled = true;
                    BB_CompVend.Enabled = true;
                }
        }

        private void bb_cadclifor_Click(object sender, EventArgs e)
        {
            using (Financeiro.Cadastros.TFCadCliforResumido fClifor = new Financeiro.Cadastros.TFCadCliforResumido())
            {
                if (!string.IsNullOrEmpty(CD_Clifor.Text))
                    if (!rCfg.Cd_clifor.Trim().Equals(CD_Clifor.Text.Trim()))
                    {
                        CamadaDados.Financeiro.Cadastros.TRegistro_CadClifor rClifor = CamadaNegocio.Financeiro.Cadastros.TCN_CadClifor.Busca_Clifor_Codigo(CD_Clifor.Text, null);
                        rClifor.lEndereco = CamadaNegocio.Financeiro.Cadastros.TCN_CadEndereco.Buscar(CD_Clifor.Text,
                                                                                                      cd_endereco.Text,
                                                                                                      string.Empty,
                                                                                                      string.Empty,
                                                                                                      string.Empty,
                                                                                                      string.Empty,
                                                                                                      string.Empty,
                                                                                                      string.Empty,
                                                                                                      string.Empty,
                                                                                                      string.Empty,
                                                                                                      string.Empty,
                                                                                                      string.Empty,
                                                                                                      string.Empty,
                                                                                                      string.Empty,
                                                                                                      string.Empty,
                                                                                                      0,
                                                                                                      null);
                        rClifor.lContato = CamadaNegocio.Financeiro.Cadastros.TCN_CadContatoCliFor.Buscar(string.Empty,
                                                                                                          CD_Clifor.Text,
                                                                                                          string.Empty,
                                                                                                          string.Empty,
                                                                                                          string.Empty,
                                                                                                          string.Empty,
                                                                                                          string.Empty,
                                                                                                          false,
                                                                                                          false,
                                                                                                          false,
                                                                                                          string.Empty,
                                                                                                          0,
                                                                                                          null);
                        fClifor.rClifor = rClifor;
                    }
                if (fClifor.ShowDialog() == DialogResult.OK)
                    try
                    {
                        CamadaNegocio.Financeiro.Cadastros.TCN_CadClifor.GravarClifor(fClifor.rClifor, null);
                        MessageBox.Show("Cliente gravado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CD_Clifor.Text = fClifor.rClifor.Cd_clifor;
                        NM_Clifor.Text = fClifor.rClifor.Nm_clifor;
                        cd_endereco.Text = fClifor.rClifor.lEndereco[0].Cd_endereco;
                        ds_endereco.Text = fClifor.rClifor.lEndereco[0].Ds_endereco;
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void CD_CompVend_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_clifor|=|'" + CD_CompVend.Text.Trim() + "';" +
                            "isnull(a.st_vendedor, 'N')|=|'S';" +
                            "isnull(a.st_funcativo, 'N')|=|'S';" +
                            "|exists|(select 1 from TB_FAT_Vendedor_X_Empresa x " +
                            "where a.CD_Clifor = x.CD_Vendedor " +
                            "and x.CD_Empresa = '" + CD_Empresa.Text.Trim() + "')";
            DataRow linha = FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { CD_CompVend, NM_CompVend },
                                                 new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
        }

        private void CD_Empresa_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveEmpresa("a.cd_empresa|=|'" + CD_Empresa.Text.Trim() + "'", new Componentes.EditDefault[] { CD_Empresa, NM_Empresa });
            if (!string.IsNullOrEmpty(CD_Empresa.Text))
            {
                //Buscar config pdv para a empresa
                CamadaDados.Faturamento.Cadastros.TList_CFGCupomFiscal lCfg = CamadaNegocio.Faturamento.Cadastros.TCN_CFGCupomFiscal.Buscar(CD_Empresa.Text, null);
                if (lCfg.Count > 0)
                {
                    rCfg = lCfg[0];
                    //cd_produto.ST_Int = lCfg[0].St_produtocodigobool;
                    CD_Clifor.Text = rCfg.Cd_clifor;
                    NM_Clifor.Text = rCfg.Nm_clifor;
                    cd_endereco.Text = rCfg.Cd_endereco;
                    ds_endereco.Text = rCfg.Ds_endereco;
                    CD_TabelaPreco.Text = rCfg.Cd_tabelapreco;
                }
                else
                {
                    MessageBox.Show("Não existe configuração frente caixa para a empresa.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CD_Empresa.Clear();
                    CD_Empresa.Focus();
                    return;
                }
            }
        }

        private void BB_Empresa_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaEmpresa(new Componentes.EditDefault[] { CD_Empresa, NM_Empresa }, string.Empty);
            if (!string.IsNullOrEmpty(CD_Empresa.Text))
            {
                //Buscar config pdv para a empresa
                CamadaDados.Faturamento.Cadastros.TList_CFGCupomFiscal lCfg = CamadaNegocio.Faturamento.Cadastros.TCN_CFGCupomFiscal.Buscar(CD_Empresa.Text, null);
                if (lCfg.Count > 0)
                {
                    rCfg = lCfg[0];
                    //cd_produto.ST_Int = lCfg[0].St_produtocodigobool;
                    CD_Clifor.Text = rCfg.Cd_clifor;
                    NM_Clifor.Text = rCfg.Nm_clifor;
                    cd_endereco.Text = rCfg.Cd_endereco;
                    ds_endereco.Text = rCfg.Ds_endereco;
                    CD_TabelaPreco.Text = rCfg.Cd_tabelapreco;
                }
                else
                {
                    MessageBox.Show("Não existe configuração frente caixa para a empresa.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CD_Empresa.Clear();
                    CD_Empresa.Focus();
                    return;
                }
            }
        }

        private void bb_tabelapreco_Click(object sender, EventArgs e)
        {
            string vParam = string.Empty;
            //Verificar se vendedor tem acesso a tabela preco
            if (!string.IsNullOrEmpty(CD_CompVend.Text))
            {
                if (new CamadaDados.Faturamento.Cadastros.TCD_Vendedor_X_TabelaPreco().BuscarEscalar(
                                    new TpBusca[]
                                    {
                                        new TpBusca()
                                        {
                                            vNM_Campo = string.Empty,
                                            vOperador = "exists",
                                            vVL_Busca = "(select 1 from tb_fat_vendedor_x_tabpreco x " +
                                                        "where x.cd_tabelapreco = a.cd_tabelapreco " +
                                                        "and x.cd_vendedor = '" + CD_CompVend.Text.Trim() + "')"
                                        }
                                    }, "1") != null)
                    vParam = "|exists|(select 1 from tb_fat_vendedor_x_tabpreco x " +
                             "          where x.cd_tabelapreco = a.cd_tabelapreco " +
                             "          and x.cd_vendedor = '" + CD_CompVend.Text.Trim() + "')";
            }
            FormBusca.UtilPesquisa.BTN_BUSCA("DS_TabelaPreco|Descrição da Tabela de Preço|300;CD_TabelaPreco|Cd. Tab.Preço|80"
                                             , new Componentes.EditDefault[] { CD_TabelaPreco, ds_tabelapreco },
                                             new CamadaDados.Diversos.TCD_CadTbPreco(),
                                             vParam);
        }

        private void CD_TabelaPreco_Leave(object sender, EventArgs e)
        {
            string vParam = "CD_TabelaPreco|=|'" + CD_TabelaPreco.Text.Trim() + "'";
            if (!string.IsNullOrEmpty(CD_CompVend.Text))
            {
                if (new CamadaDados.Faturamento.Cadastros.TCD_Vendedor_X_TabelaPreco().BuscarEscalar(
                                new TpBusca[]
                                {
                                    new TpBusca()
                                    {
                                        vNM_Campo = string.Empty,
                                        vOperador = "exists",
                                        vVL_Busca = "(select 1 from tb_fat_vendedor_x_tabpreco x " +
                                                    "where x.cd_tabelapreco = a.cd_tabelapreco " +
                                                    "and x.cd_vendedor = '" + CD_CompVend.Text.Trim() + "')"
                                    }
                                }, "1") != null)
                    vParam += ";|exists|(select 1 from tb_fat_vendedor_x_tabpreco x " +
                              "          where x.cd_tabelapreco = a.cd_tabelapreco " +
                              "          and x.cd_vendedor = '" + CD_CompVend.Text.Trim() + "')";
            }
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { CD_TabelaPreco, ds_tabelapreco },
             new CamadaDados.Diversos.TCD_CadTbPreco());
        }

        private void BB_CompVend_Click(object sender, EventArgs e)
        {
            string vColunas = "a.nm_clifor|Nome Vendedor|200;" +
                              "a.cd_clifor|Cd. Vendedor|80";
            string vParam = "isnull(a.st_vendedor, 'N')|=|'S';" +
                            "isnull(a.st_funcativo, 'N')|=|'S';" +
                            "|exists|(select 1 from TB_FAT_Vendedor_X_Empresa x " +
                            "where a.CD_Clifor = x.CD_Vendedor " +
                            "and x.CD_Empresa = '" + CD_Empresa.Text.Trim() + "')";
            DataRowView linha = FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { CD_CompVend, NM_CompVend },
                                               new CamadaDados.Financeiro.Cadastros.TCD_CadClifor(), vParam);
        }

        private void bb_cadEndereco_Click(object sender, EventArgs e)
        {
            if ((!string.IsNullOrEmpty(CD_Clifor.Text)) &&
                (!CD_Clifor.Text.Trim().Equals(rCfg.Cd_clifor.Trim())))
            {
                using (Financeiro.Cadastros.TFEndereco fEndereco = new Financeiro.Cadastros.TFEndereco())
                {
                    if (!string.IsNullOrEmpty(cd_endereco.Text))
                        fEndereco.rEnd = CamadaNegocio.Financeiro.Cadastros.TCN_CadEndereco.Buscar(CD_Clifor.Text,
                                                                                                   cd_endereco.Text,
                                                                                                   string.Empty,
                                                                                                   string.Empty,
                                                                                                   string.Empty,
                                                                                                   string.Empty,
                                                                                                   string.Empty,
                                                                                                   string.Empty,
                                                                                                   string.Empty,
                                                                                                   string.Empty,
                                                                                                   string.Empty,
                                                                                                   string.Empty,
                                                                                                   string.Empty,
                                                                                                   string.Empty,
                                                                                                   string.Empty,
                                                                                                   1,
                                                                                                   null)[0];
                    if (fEndereco.ShowDialog() == DialogResult.OK)
                        if (fEndereco.rEnd != null)
                            try
                            {
                                fEndereco.rEnd.Cd_clifor = (bsPreVenda.Current as CamadaDados.Faturamento.PDV.TRegistro_PreVenda).Cd_clifor;
                                CamadaNegocio.Financeiro.Cadastros.TCN_CadEndereco.Gravar(fEndereco.rEnd, null);
                                MessageBox.Show("Endereço cadastrado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                cd_endereco.Text = fEndereco.rEnd.Cd_endereco;
                                ds_endereco.Text = fEndereco.rEnd.Ds_endereco;
                                numero.Text = fEndereco.rEnd.Numero;
                                Bairro.Text = fEndereco.rEnd.Bairro;
                                fone.Text = fEndereco.rEnd.Fone;
                                proximo.Text = fEndereco.rEnd.Proximo;

                            }
                            catch (Exception ex)
                            { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
            }
        }

        private void bb_endereco_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(CD_Clifor.Text))
            {
                string vColunas = "a.ds_endereco|Endereço|200;" +
                                  "a.cd_endereco|Codigo|80";
                DataRowView linha = FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_endereco, ds_endereco },
                                        new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco(), "a.cd_clifor|=|'" + CD_Clifor.Text.Trim() + "'");
                if (linha != null)
                {
                    numero.Text = linha["numero"].ToString();
                    Bairro.Text = linha["bairro"].ToString();
                    fone.Text = linha["fone"].ToString();
                    proximo.Text = linha["proximo"].ToString();
                }
            }
        }

        private void cd_endereco_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(CD_Clifor.Text))
            {
                string vParam = "a.cd_clifor|=|'" + CD_Clifor.Text.Trim() + "';" +
                                "a.cd_endereco|=|'" + cd_endereco.Text.Trim() + "'";
                DataRow linha = FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_endereco, ds_endereco },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco());

                if (linha != null)
                {
                    numero.Text = linha["numero"].ToString();
                    Bairro.Text = linha["bairro"].ToString();
                    fone.Text = linha["fone"].ToString();
                    proximo.Text = linha["proximo"].ToString();
                }
            }
        }

        private void bb_cancela_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void CD_Clifor_TextChanged(object sender, EventArgs e)
        {
            NM_Clifor.Enabled = string.IsNullOrEmpty(CD_Clifor.Text);
        }

        private void cd_endereco_TextChanged(object sender, EventArgs e)
        {
            ds_endereco.Enabled = string.IsNullOrEmpty(cd_endereco.Text);
            numero.Enabled = string.IsNullOrEmpty(cd_endereco.Text);
            Bairro.Enabled = string.IsNullOrEmpty(cd_endereco.Text);
            proximo.Enabled = string.IsNullOrEmpty(cd_endereco.Text);
            fone.Enabled = string.IsNullOrEmpty(cd_endereco.Text);
        }

        private void fone_TextChanged(object sender, EventArgs e)
        {
            if (fone.Text.SoNumero().Length.Equals(10))
            {
                fone.Text = "(" + fone.Text.SoNumero().Substring(0, 2) + ")" + fone.Text.SoNumero().Substring(2, 4) + "-" + fone.Text.SoNumero().Substring(6, 4);
                fone.SelectionStart = fone.Text.Length;
            }
            else if (fone.Text.SoNumero().Length.Equals(11))
                if (fone.Text.SoNumero().Substring(0, 1).Equals("0"))
                {
                    fone.Text = "(" + fone.Text.SoNumero().Substring(0, 3) + ")" + fone.Text.SoNumero().Substring(3, 4) + "-" + fone.Text.SoNumero().Substring(7, 4);
                    fone.SelectionStart = fone.Text.Length;
                }
                else
                {
                    fone.Text = "(" + fone.Text.SoNumero().Substring(0, 2) + ")" + fone.Text.SoNumero().Substring(2, 5) + "-" + fone.Text.SoNumero().Substring(7, 4);
                    fone.SelectionStart = fone.Text.Length;
                }
            else if (fone.Text.SoNumero().Length.Equals(12))
            {
                fone.Text = "(" + fone.Text.SoNumero().Substring(0, 3) + ")" + fone.Text.SoNumero().Substring(3, 5) + "-" + fone.Text.SoNumero().Substring(8, 4);
                fone.SelectionStart = fone.Text.Length;
            }
        }
    }
}
