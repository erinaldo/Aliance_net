using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Utils;
using WebCamLibrary;
using FormBusca;
using CamadaDados.Financeiro.Cadastros;

namespace Financeiro.Cadastros
{
    public partial class TFCadCliforResumido : Form
    {
        private TRegistro_CadClifor rclifor;
        public TRegistro_CadClifor rClifor
        {
            get { return bsClifor.Current as TRegistro_CadClifor; }
            set { rclifor = value; }
        }
        public string pTp_pessoa = string.Empty;
        public string pNm_clifor = string.Empty;
        public string pNR_CPF = string.Empty;
        public string pNR_CNPJ = string.Empty;
        public string pNR_RG = string.Empty;
        public string pEmail = string.Empty;
        public string pFone_comercial = string.Empty;
        public string pFone_residencial = string.Empty;
        public string pCelular = string.Empty;
        public string pDs_endereco = string.Empty;
        public string pNumero = string.Empty;
        public string pBairro = string.Empty;
        public string pCd_cidade = string.Empty;
        public string pCidade = string.Empty;
        public string pUF = string.Empty;
        public string pCep = string.Empty;
        public string pDs_complemento = string.Empty;
        private bool St_bloquear = false;

        public TFCadCliforResumido()
        {
            InitializeComponent();

            System.Collections.ArrayList cbx = new System.Collections.ArrayList();
            cbx.Add(new TDataCombo("FISICA", "F"));
            cbx.Add(new TDataCombo("JURIDICA", "J"));
            cbx.Add(new TDataCombo("ESTRANGEIRO", "E"));
            tp_pessoa.DataSource = cbx;
            tp_pessoa.ValueMember = "Value";
            tp_pessoa.DisplayMember = "Display";

            System.Collections.ArrayList cbx1 = new System.Collections.ArrayList();
            cbx1.Add(new TDataCombo("FINANCEIRO", "F"));
            cbx1.Add(new TDataCombo("FATURAMENTO", "T"));
            cbx1.Add(new TDataCombo("COMERCIAL", "C"));
            cbx1.Add(new TDataCombo("OPERACIONAL", "P"));
            cbx1.Add(new TDataCombo("OUTROS", "O"));

            tipo_contato.DataSource = cbx1;
            tipo_contato.DisplayMember = "Display";
            tipo_contato.ValueMember = "Value";
        }

        private void PreencherCampos()
        {
            tp_pessoa.SelectedValue = pTp_pessoa;
            NM_Clifor.Text = pNm_clifor;
            NR_CPF.Text = pNR_CPF;
            NR_RG.Text = pNR_RG;
            NR_CGC.Text = pNR_CNPJ;
            email.Text = pEmail;
            Fone_comercial.Text = pFone_comercial;
            fone.Text = pFone_residencial;
            celular.Text = pCelular;
            DS_Endereco.Text = pDs_endereco;
            Numero.Text = pNumero;
            Bairro.Text = pBairro;
            CD_Cidade.Text = pCd_cidade;
            Ds_Cidade.Text = pCidade;
            UF.Text = pUF;
            Cep.Text = pCep;
            DS_Complemento.Text = pDs_complemento;
        }

        private void VisibleCampos(string vTp_pessoa)
        {
            lblEstrangeiro.Visible = vTp_pessoa.Trim().ToUpper().Equals("E");
            id_estrangeiro.Visible = vTp_pessoa.Trim().ToUpper().Equals("E");
            NR_CGC.Visible = vTp_pessoa.Trim().ToUpper().Equals("J");
            LB_NR_CGC.Visible = vTp_pessoa.Trim().ToUpper().Equals("J");
            NM_Fantasia.Visible = vTp_pessoa.Trim().ToUpper().Equals("J");
            LB_NM_Fantasia.Visible = vTp_pessoa.Trim().ToUpper().Equals("J");
            NR_CPF.Visible = vTp_pessoa.Trim().ToUpper().Equals("F");
            LB_NR_CPF.Visible = vTp_pessoa.Trim().ToUpper().Equals("F");
            NR_RG.Visible = vTp_pessoa.Trim().ToUpper().Equals("F");
            LB_NR_RG.Visible = vTp_pessoa.Trim().ToUpper().Equals("F");
            LB_OrgaoEsp.Visible = vTp_pessoa.Trim().ToUpper().Equals("F");
            OrgaoEsp.Visible = vTp_pessoa.Trim().ToUpper().Equals("F");
            if (vTp_pessoa.Trim().ToUpper().Equals("E"))
            {
                //Buscar cidade
                TList_CadCidade lCidade =
                    CamadaNegocio.Financeiro.Cadastros.TCN_CadCidade.Buscar("9999999",
                                                                            string.Empty,
                                                                            string.Empty,
                                                                            string.Empty,
                                                                            1,
                                                                            null);
                if (lCidade.Count > 0)
                {
                    CD_Cidade.Text = lCidade[0].Cd_cidade;
                    Ds_Cidade.Text = lCidade[0].Ds_cidade;
                    UF.Text = lCidade[0].rUf.Uf;
                    CD_Cidade.Enabled = false;
                    BB_Cidade.Enabled = false;
                }
                else
                {
                    if (new TCD_CadUf().BuscarEscalar(
                        new TpBusca[]
                        {
                            new TpBusca()
                            {
                                vNM_Campo = "a.cd_uf",
                                vOperador = "=",
                                vVL_Busca = "'99'"
                            }
                        }, "1") == null)
                        CamadaNegocio.Financeiro.Cadastros.TCN_CadUf.GravarUf(
                            new TRegistro_CadUf()
                            {
                                Cd_uf = "99",
                                Ds_uf = "EXTERIOR",
                                Uf = "EX"
                            }, null);
                    CamadaNegocio.Financeiro.Cadastros.TCN_CadCidade.Gravar(
                        new TRegistro_CadCidade()
                        {
                            Cd_cidade = "9999999",
                            Ds_cidade = "EXTERIOR",
                            Cd_uf = "99"
                        }, null);
                    CD_Cidade.Text = "9999999";
                    Ds_Cidade.Text = "EXTERIOR";
                    UF.Text = "EX";
                    CD_Cidade.Enabled = false;
                    BB_Cidade.Enabled = false;
                }
            }
            else
            {
                CD_PAIS.Text = "1058";
                NM_Pais.Text = "BRASIL";
            }
        }

        private void Valida_CNPJ()
        {
            if ((NR_CGC.Text.Trim() != string.Empty) && (NR_CGC.Text.Trim() != ".   .   /    -"))
            {
                CNPJ_Valido.nr_CNPJ = NR_CGC.Text;
                if (!string.IsNullOrEmpty(CNPJ_Valido.nr_CNPJ))
                {
                    if (Convert.ToDecimal(CNPJ_Valido.nr_CNPJ.SoNumero()) != 0)
                    {
                        //Verificar se o cnpj ja existe no sistema
                        object obj = new TCD_CadClifor().BuscarEscalar(
                                        new TpBusca[]
                                    {
                                        new TpBusca()
                                        {
                                            vNM_Campo = "a.cd_clifor",
                                            vOperador = "<>",
                                            vVL_Busca = "'" + cd_clifor.Text.Trim() + "'"
                                        },
                                        new TpBusca()
                                        {
                                            vNM_Campo = "a.nr_cgc",
                                            vOperador = "=",
                                            vVL_Busca = "'" + NR_CGC.Text.Trim() + "'"
                                        }
                                    }, "a.cd_clifor + a.nm_clifor");
                        if (obj == null ? false : obj.ToString().Trim() != string.Empty)
                        {
                            MessageBox.Show("O número do CNPJ: " + NR_CGC.Text + " já está cadastrado no sistema, \r\n com o CLIFOR: " + obj.ToString().Trim() + "!",
                                               "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            NR_CGC.Clear();
                            NR_CGC.Focus();
                            St_bloquear = true;
                        }
                        else
                            St_bloquear = false;
                    }
                }
                else
                {
                    MessageBox.Show("Por Favor! Entre com um CNPJ Válido!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    NR_CGC.Clear();
                    NR_CGC.Focus();
                }

            }
        }

        private void Valida_RUC()
        {
            object obj = new TCD_CadClifor().BuscarEscalar(
                            new TpBusca[]
                            {
                                new TpBusca()
                                {
                                    vNM_Campo = "a.cd_clifor",
                                    vOperador = "<>",
                                    vVL_Busca = "'" + cd_clifor.Text.Trim() + "'"
                                },
                                new TpBusca()
                                {
                                    vNM_Campo = "a.nr_cgc",
                                    vOperador = "=",
                                    vVL_Busca = "'" + NR_CGC.Text.Trim() + "'"
                                }
                            }, "a.cd_clifor + a.nm_clifor");
            if (obj == null ? false : obj.ToString().Trim() != string.Empty)
            {
                MessageBox.Show("El número de RUC: " + NR_CGC.Text + " es registrado en sistema, \r\n com o CLIFOR: " + obj.ToString().Trim() + "\r\n Búsqueda, !",
                        "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                NR_CGC.Clear();
                NR_CGC.Focus();
            }
        }

        private void Valida_CPF()
        {
            if ((NR_CPF.Text.Trim() != string.Empty) && (NR_CPF.Text.Trim() != ".   .   -"))
            {
                CPF_Valido.nr_CPF = NR_CPF.Text;
                if (CPF_Valido.nr_CPF.Trim() != string.Empty)
                {
                    if (Convert.ToDecimal(CPF_Valido.nr_CPF.SoNumero()) != 0)
                    {
                        object obj = new TCD_CadClifor().BuscarEscalar(
                                new TpBusca[]
                            {
                                new TpBusca()
                                {
                                    vNM_Campo = "a.cd_clifor",
                                    vOperador = "<>",
                                    vVL_Busca = "'" + cd_clifor.Text.Trim() + "'"
                                },
                                new TpBusca()
                                {
                                    vNM_Campo = "a.nr_cpf",
                                    vOperador = "=",
                                    vVL_Busca = "'" + NR_CPF.Text.Trim() + "'"
                                }
                            }, "a.cd_clifor + a.nm_clifor");
                        if (obj == null ? false : obj.ToString().Trim() != string.Empty)
                        {
                            MessageBox.Show("O número do CPF: " + NR_CPF.Text + " já está cadastrado no sistema, \r\n com o CLIFOR: " + obj.ToString().Trim() + "\r\n Por Favor, Verifique!",
                             "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                            NR_CPF.Clear();
                            NR_CPF.Focus();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Por Favor! Entre com um CPF Válido!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    NR_CPF.Clear();
                    NR_CPF.Focus();
                }
            }
        }

        private void Valida_RG()
        {
            if (NR_RG.Text.Trim() != string.Empty)
            {
                object obj = new TCD_CadClifor().BuscarEscalar(
                            new TpBusca[]
                            {
                                new TpBusca()
                                {
                                    vNM_Campo = "a.cd_clifor",
                                    vOperador = "<>",
                                    vVL_Busca = "'" + cd_clifor.Text.Trim() + "'"
                                },
                                new TpBusca()
                                {
                                    vNM_Campo = "a.nr_rg",
                                    vOperador = "=",
                                    vVL_Busca = "'" + NR_CGC.Text.Trim() + "'"
                                }
                            }, "a.cd_clifor + a.nm_clifor");
                if (obj == null ? false : obj.ToString().Trim() != string.Empty)
                {
                    MessageBox.Show("O número do RG: " + NR_RG.Text + " já está cadastrado no sistema, \r\n com o CLIFOR: " + obj.ToString().Trim() + "\r\n Por Favor, Verifique!",
                    "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    NR_RG.Clear();
                    NR_RG.Focus();
                }
            }
        }

        private void afterGrava()
        {
            if (pClifor.validarCampoObrigatorio())
            {
                this.Valida_CNPJ();
                if (St_bloquear)
                    return;
                if (!string.IsNullOrEmpty(NM_Contato.Text))
                {
                    if (tipo_contato.SelectedValue == null)
                    {
                        MessageBox.Show("Obrigatorio selecionar tipo contato.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        tipo_contato.Focus();
                        return;
                    }
                }
                else
                {
                    if ((bsContato.Current as TRegistro_CadContatoCliFor).Id_Contato != decimal.Zero)
                        (bsClifor.Current as TRegistro_CadClifor).lContatoDel.Add(
                            bsContato.Current as TRegistro_CadContatoCliFor);
                    bsContato.RemoveCurrent();
                }
                DialogResult = DialogResult.OK;
            }
        }

        private void TFCadCliforResumido_Load(object sender, EventArgs e)
        {
            Icon = ResourcesUtils.TecnoAliance_ICO;
            pClifor.set_FormatZero();
            cd_clifor.Enabled = !CamadaNegocio.Diversos.TCN_CadParamSys.St_AutoInc("CD_CLIFOR");
            if (rclifor != null)
            {
                bsClifor.DataSource = new TList_CadClifor() { rclifor };
                if (bsEndereco.Current == null)
                    bsEndereco.AddNew();
                if (bsContato.Current == null)
                    bsContato.AddNew();
                ID_Regiao.Enabled = CamadaNegocio.Diversos.TCN_Usuario_RegraEspecial.ValidaRegra(Utils.Parametros.pubLogin, "PERMITIR ALTERAR REGIÃO VENDA", null);
                bb_regiaoVenda.Enabled = ID_Regiao.Enabled;
                bsClifor.ResetCurrentItem();
            }
            else
            {
                bsClifor.AddNew();
                bsEndereco.AddNew();
                bsContato.AddNew();
                PreencherCampos();
            }
        }

        private void Insc_Estadual_Leave(object sender, EventArgs e)
        {
            if (Utils.Parametros.pubCultura.Trim().ToUpper() != "pt-BR")
            {
                string insc_estadual = Insc_Estadual.Text.SoNumero();
                if (insc_estadual.Trim().Equals(string.Empty))
                {
                    Insc_Estadual.Text = "ISENTO";
                    return;
                }
                if (UF.Text.Trim().Equals(string.Empty))
                {
                    MessageBox.Show("Obrigatório informar cidade para validar a inscrição estadual.", "Mensagem", MessageBoxButtons.OK);
                    CD_Cidade.Focus();
                    return;
                }
                try
                {
                    if (CamadaNegocio.Diversos.TValidaInscEstadual.ValidaInscEstadual(insc_estadual.Trim(), UF.Text.Trim()) == 1)
                    {
                        MessageBox.Show("Inscrição estadual incorreta para o estado.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Insc_Estadual.Clear();
                        Insc_Estadual.Focus();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro: " + ex.Message);
                }
            }
        }

        private void tp_pessoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            VisibleCampos(tp_pessoa.SelectedValue != null ? tp_pessoa.SelectedValue.ToString() : string.Empty);
        }

        private void NR_CGC_Leave(object sender, EventArgs e)
        {
            if (Utils.Parametros.pubCultura.Trim() == "pt-BR")
                Valida_CNPJ();
            else if (Utils.Parametros.pubCultura.Trim() == "es-ES")
                Valida_RUC();
        }

        private void NR_CPF_Leave(object sender, EventArgs e)
        {
            if (Utils.Parametros.pubCultura.Trim().ToUpper() != "pt-BR")
                Valida_CPF();
        }

        private void bb_consultarCadNFe_Click(object sender, EventArgs e)
        {
            using (srvNFE.TFConsultaCadCliforNFe fConsulta = new srvNFE.TFConsultaCadCliforNFe())
            {
                fConsulta.nrCnpj = (bsClifor.Current as TRegistro_CadClifor).Nr_cgc;
                fConsulta.nrCpf = (bsClifor.Current as TRegistro_CadClifor).Nr_cpf;
                if ((bsClifor.Current as TRegistro_CadClifor).lEndereco.Count > 0)
                    fConsulta.sgUF = (bsClifor.Current as TRegistro_CadClifor).lEndereco[0].UF;
                if (fConsulta.ShowDialog() == DialogResult.OK)
                    if (fConsulta.rClifor != null)
                    {
                        //Razao Social
                        (bsClifor.Current as TRegistro_CadClifor).Nm_clifor = fConsulta.rClifor.Nm_clifor;
                        //Nome Fantasia
                        (bsClifor.Current as TRegistro_CadClifor).Nm_fantasia = fConsulta.rClifor.Nm_fantasia;
                        if (fConsulta.rClifor.lEndereco.Count > 0)
                        {
                            //Endereco
                            (bsClifor.Current as TRegistro_CadClifor).lEndereco[0].Ds_endereco = fConsulta.rClifor.lEndereco[0].Ds_endereco;
                            //Numero
                            (bsClifor.Current as TRegistro_CadClifor).lEndereco[0].Numero = fConsulta.rClifor.lEndereco[0].Numero;
                            //Complemento
                            (bsClifor.Current as TRegistro_CadClifor).lEndereco[0].Ds_complemento = fConsulta.rClifor.lEndereco[0].Ds_complemento;
                            //Bairro
                            (bsClifor.Current as TRegistro_CadClifor).lEndereco[0].Bairro = fConsulta.rClifor.lEndereco[0].Bairro;
                            //Codigo Cidade
                            if (!string.IsNullOrEmpty(fConsulta.rClifor.lEndereco[0].Cd_cidade))
                            {
                                (bsClifor.Current as TRegistro_CadClifor).lEndereco[0].Cd_cidade = fConsulta.rClifor.lEndereco[0].Cd_cidade;
                                (bsClifor.Current as TRegistro_CadClifor).lEndereco[0].DS_Cidade = fConsulta.rClifor.lEndereco[0].DS_Cidade;
                            }
                            //CEP
                            (bsClifor.Current as TRegistro_CadClifor).lEndereco[0].Cep = fConsulta.rClifor.lEndereco[0].Cep;
                            //Inscricao Estadual
                            (bsClifor.Current as TRegistro_CadClifor).lEndereco[0].Insc_estadual = fConsulta.rClifor.lEndereco[0].Insc_estadual;
                        }
                        bsClifor.ResetCurrentItem();
                    }
            }
        }

        private void ID_CategoriaClifor_Leave(object sender, EventArgs e)
        {
            DataRow linha = UtilPesquisa.EDIT_LEAVE("a.ID_CategoriaClifor|=|'" + ID_CategoriaClifor.Text + "'",
              new Componentes.EditDefault[] { ID_CategoriaClifor, DS_CategoriaClifor }, new TCD_CadCategoriaCliFor());
            if (linha != null)
            {
                st_fornecedor.Checked = linha["st_fornecedor"].ToString().Trim().ToUpper().Equals("S");
                st_transportadora.Checked = linha["st_transportadora"].ToString().Trim().ToUpper().Equals("S");
                st_funcionario.Checked = linha["st_funcionarios"].ToString().Trim().ToUpper().Equals("S");
                st_representante.Checked = linha["st_representante"].ToString().Trim().ToUpper().Equals("S");
            }
            else
            {
                st_fornecedor.Checked = false;
                st_transportadora.Checked = false;
                st_funcionario.Checked = false;
                st_vendedorconsulta.Checked = false;
                st_representante.Checked = false;
            }
        }

        private void BB_CategoriaClifor_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_categoriaclifor|Categoria Clifor|200;" +
                              "a.id_categoriaclifor|Id. Categoria|80;" +
                              "a.st_transportadora|Transportadora|80;" +
                              "a.st_fornecedor|Fornecedor|80;" +
                              "a.st_funcionarios|Funcionarios|80";
            DataRowView linha = UtilPesquisa.BTN_BUSCA(vColunas,
                                                       new Componentes.EditDefault[] { ID_CategoriaClifor, DS_CategoriaClifor },
                                                       new TCD_CadCategoriaCliFor(), string.Empty);
            if (linha != null)
            {
                st_fornecedor.Checked = linha["st_fornecedor"].ToString().Trim().ToUpper().Equals("S");
                st_transportadora.Checked = linha["st_transportadora"].ToString().Trim().ToUpper().Equals("S");
                st_funcionario.Checked = linha["st_funcionarios"].ToString().Trim().ToUpper().Equals("S");
                st_representante.Checked = linha["st_representante"].ToString().Trim().ToUpper().Equals("S");
            }
            else
            {
                st_fornecedor.Checked = false;
                st_transportadora.Checked = false;
                st_funcionario.Checked = false;
                st_vendedorconsulta.Checked = false;
                st_representante.Checked = false;
            }
        }

        private void Cd_CondFiscal_Clifor_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("CD_CondFiscal_Clifor|=|'" + Cd_CondFiscal_Clifor.Text + "'"
                , new Componentes.EditDefault[] { Cd_CondFiscal_Clifor, DS_CondFiscal },
                new CamadaDados.Fiscal.TCD_CadConFiscalClifor());
        }

        private void bb_FiscalClifor_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BUSCA("DS_CondFiscal|Descrição|200;CD_CondFiscal_Clifor|Cód. Fiscal|100"
              , new Componentes.EditDefault[] { Cd_CondFiscal_Clifor, DS_CondFiscal },
              new CamadaDados.Fiscal.TCD_CadConFiscalClifor(), string.Empty);
        }

        private void bb_regiaoVenda_Click(object sender, EventArgs e)
        {
            string vColunas = "NM_Regiao| Região Venda|350;" +
                               "ID_Regiao|Cód. Região Venda |100";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { ID_Regiao, nM_Regiao },
                                    new CamadaDados.Diversos.TCD_CadRegiaoVenda(), string.Empty);
        }

        private void ID_Regiao_Leave(object sender, EventArgs e)
        {
            string vColunas = ID_Regiao.NM_CampoBusca + "|=|'" + ID_Regiao.Text + "'";
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { ID_Regiao, nM_Regiao },
                                    new CamadaDados.Diversos.TCD_CadRegiaoVenda());
        }

        private void CD_Cidade_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("CD_cidade|=|'" + CD_Cidade.Text + "'",
                    new Componentes.EditDefault[] { CD_Cidade, Ds_Cidade, UF }, new TCD_CadCidade());
        }

        private void BB_Cidade_Click(object sender, EventArgs e)
        {
            string vColunas = "DS_Cidade|Nome Cidade|250;" +
                              "CD_Cidade|Cód. Cidade|100;" +
                              "Distrito|Distrito|200;" +
                              "a.UF|Sigla|60;" +
                              "b.DS_UF|Estado|100";
            UtilPesquisa.BTN_BUSCA(vColunas,
                   new Componentes.EditDefault[] { CD_Cidade, Ds_Cidade, UF }, new TCD_CadCidade(), string.Empty);
        }

        private void CD_PAIS_Leave(object sender, EventArgs e)
        {
            string vParam = "cd_pais|=|'" + CD_PAIS.Text.Trim() + "'";
            if (tp_pessoa.SelectedValue == null ? false : tp_pessoa.SelectedValue.ToString().Trim().ToUpper().Equals("E"))
                vParam += ";cd_pais|<>|'1058'";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { CD_PAIS, NM_Pais }, new TCD_CadPais());
        }

        private void BB_Pais_Click(object sender, EventArgs e)
        {
            string vParam = string.Empty;
            if (tp_pessoa.SelectedValue == null ? false : tp_pessoa.SelectedValue.ToString().Trim().ToUpper().Equals("E"))
                vParam = "cd_pais|<>|'1058'";
            UtilPesquisa.BTN_BUSCA("NM_Pais|Nome do País|200;CD_Pais|Cód. País|100",
                              new Componentes.EditDefault[] { CD_PAIS, NM_Pais }, new TCD_CadPais(), string.Empty);
        }


        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            afterGrava();
        }

        private void TFCadCliforResumido_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                DialogResult = DialogResult.Cancel;
        }

        private void NR_RG_Leave(object sender, EventArgs e)
        {
            if (Utils.Parametros.pubCultura.Trim().ToUpper() != "pt-BR")
                Valida_RG();
        }

        private void NR_RG_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (NR_RG.Text.Trim().Length)
            {
                case 1:
                    {
                        NR_RG.Text += ".";
                        NR_RG.SelectionStart = 3;
                        break;
                    }
                case 5:
                    {
                        NR_RG.Text += ".";
                        NR_RG.SelectionStart = 7;
                        break;
                    }
                case 9:
                    {
                        NR_RG.Text += "-";
                        NR_RG.SelectionStart = 11;
                        break;
                    }
            }
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

        private void Fone_contato_TextChanged(object sender, EventArgs e)
        {
            if (Fone_contato.Text.SoNumero().Length.Equals(10))
            {
                Fone_contato.Text = "(" + Fone_contato.Text.SoNumero().Substring(0, 2) + ")" + Fone_contato.Text.SoNumero().Substring(2, 4) + "-" + Fone_contato.Text.SoNumero().Substring(6, 4);
                Fone_contato.SelectionStart = Fone_contato.Text.Length;
            }
            else if (Fone_contato.Text.SoNumero().Length.Equals(11))
                if (Fone_contato.Text.SoNumero().Substring(0, 1).Equals("0"))
                {
                    Fone_contato.Text = "(" + Fone_contato.Text.SoNumero().Substring(0, 3) + ")" + Fone_contato.Text.SoNumero().Substring(3, 4) + "-" + Fone_contato.Text.SoNumero().Substring(7, 4);
                    Fone_contato.SelectionStart = Fone_contato.Text.Length;
                }
                else
                {
                    Fone_contato.Text = "(" + Fone_contato.Text.SoNumero().Substring(0, 2) + ")" + Fone_contato.Text.SoNumero().Substring(2, 5) + "-" + Fone_contato.Text.SoNumero().Substring(7, 4);
                    Fone_contato.SelectionStart = Fone_contato.Text.Length;
                }
            else if (Fone_contato.Text.SoNumero().Length.Equals(12))
            {
                Fone_contato.Text = "(" + Fone_contato.Text.SoNumero().Substring(0, 3) + ")" + Fone_contato.Text.SoNumero().Substring(3, 5) + "-" + Fone_contato.Text.SoNumero().Substring(8, 4);
                Fone_contato.SelectionStart = Fone_contato.Text.Length;
            }
        }

        private void FoneMovel_TextChanged(object sender, EventArgs e)
        {
            if (FoneMovel.Text.SoNumero().Length.Equals(10))
            {
                FoneMovel.Text = "(" + FoneMovel.Text.SoNumero().Substring(0, 2) + ")" + FoneMovel.Text.SoNumero().Substring(2, 4) + "-" + FoneMovel.Text.SoNumero().Substring(6, 4);
                FoneMovel.SelectionStart = FoneMovel.Text.Length;
            }
            else if (FoneMovel.Text.SoNumero().Length.Equals(11))
                if (FoneMovel.Text.SoNumero().Substring(0, 1).Equals("0"))
                {
                    FoneMovel.Text = "(" + FoneMovel.Text.SoNumero().Substring(0, 3) + ")" + FoneMovel.Text.SoNumero().Substring(3, 4) + "-" + FoneMovel.Text.SoNumero().Substring(7, 4);
                    FoneMovel.SelectionStart = FoneMovel.Text.Length;
                }
                else
                {
                    FoneMovel.Text = "(" + FoneMovel.Text.SoNumero().Substring(0, 2) + ")" + FoneMovel.Text.SoNumero().Substring(2, 5) + "-" + FoneMovel.Text.SoNumero().Substring(7, 4);
                    FoneMovel.SelectionStart = FoneMovel.Text.Length;
                }
            else if (FoneMovel.Text.SoNumero().Length.Equals(12))
            {
                FoneMovel.Text = "(" + FoneMovel.Text.SoNumero().Substring(0, 3) + ")" + FoneMovel.Text.SoNumero().Substring(3, 5) + "-" + FoneMovel.Text.SoNumero().Substring(8, 4);
                FoneMovel.SelectionStart = FoneMovel.Text.Length;
            }
        }

        private void Cep_Leave(object sender, EventArgs e)
        {
            if ((!string.IsNullOrEmpty(Cep.Text.SoNumero()))
               && (bsEndereco.Current != null))
            {
                try
                {
                    TEndereco_CEPRest valida = ServiceRest.DataService.BuscarEndCEPRest(Cep.Text);
                    if (valida != null)
                    {
                        if (!string.IsNullOrEmpty(valida.logradouro.Trim()))
                            DS_Endereco.Text = valida.logradouro;
                        if (!string.IsNullOrEmpty(valida.ibge.Trim()))
                            CD_Cidade.Text = valida.ibge;
                        if (!string.IsNullOrEmpty(valida.bairro.Trim()))
                            Bairro.Text = valida.bairro;
                        CD_Cidade_Leave(this, new EventArgs());
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro: " + ex.Message);
                }
            }
        }

        private void Insc_Estadual_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) || //Letras
               char.IsSymbol(e.KeyChar) || //Símbolos
               char.IsWhiteSpace(e.KeyChar) || //Espaço
               char.IsPunctuation(e.KeyChar)) //Pontuação
                e.Handled = true;
        }

        private void celular_Leave(object sender, EventArgs e)
        {

        }

        private void Fone_comercial_TextChanged(object sender, EventArgs e)
        {
            if (Fone_comercial.Text.SoNumero().Length.Equals(10))
            {
                Fone_comercial.Text = "(" + Fone_comercial.Text.SoNumero().Substring(0, 2) + ")" + Fone_comercial.Text.SoNumero().Substring(2, 4) + "-" + Fone_comercial.Text.SoNumero().Substring(6, 4);
                Fone_comercial.SelectionStart = Fone_comercial.Text.Length;
            }
            else if (Fone_comercial.Text.SoNumero().Length.Equals(11))
                if (Fone_comercial.Text.SoNumero().Substring(0, 1).Equals("0"))
                {
                    Fone_comercial.Text = "(" + Fone_comercial.Text.SoNumero().Substring(0, 3) + ")" + Fone_comercial.Text.SoNumero().Substring(3, 4) + "-" + Fone_comercial.Text.SoNumero().Substring(7, 4);
                    Fone_comercial.SelectionStart = Fone_comercial.Text.Length;
                }
                else
                {
                    Fone_comercial.Text = "(" + Fone_comercial.Text.SoNumero().Substring(0, 2) + ")" + Fone_comercial.Text.SoNumero().Substring(2, 5) + "-" + Fone_comercial.Text.SoNumero().Substring(7, 4);
                    Fone_comercial.SelectionStart = Fone_comercial.Text.Length;
                }
            else if (Fone_comercial.Text.SoNumero().Length.Equals(12))
            {
                Fone_comercial.Text = "(" + Fone_comercial.Text.SoNumero().Substring(0, 3) + ")" + Fone_comercial.Text.SoNumero().Substring(3, 5) + "-" + Fone_comercial.Text.SoNumero().Substring(8, 4);
                Fone_comercial.SelectionStart = Fone_comercial.Text.Length;
            }
        }

        private void celular_TextChanged(object sender, EventArgs e)
        {
            if (celular.Text.SoNumero().Length.Equals(10))
            {
                celular.Text = "(" + celular.Text.SoNumero().Substring(0, 2) + ")" + celular.Text.SoNumero().Substring(2, 4) + "-" + celular.Text.SoNumero().Substring(6, 4);
                celular.SelectionStart = celular.Text.Length;
            }
            else if (celular.Text.SoNumero().Length.Equals(11))
                if (celular.Text.SoNumero().Substring(0, 1).Equals("0"))
                {
                    celular.Text = "(" + celular.Text.SoNumero().Substring(0, 3) + ")" + celular.Text.SoNumero().Substring(3, 4) + "-" + celular.Text.SoNumero().Substring(7, 4);
                    celular.SelectionStart = celular.Text.Length;
                }
                else
                {
                    celular.Text = "(" + celular.Text.SoNumero().Substring(0, 2) + ")" + celular.Text.SoNumero().Substring(2, 5) + "-" + celular.Text.SoNumero().Substring(7, 4);
                    celular.SelectionStart = celular.Text.Length;
                }
            else if (celular.Text.SoNumero().Length.Equals(12))
            {
                celular.Text = "(" + celular.Text.SoNumero().Substring(0, 3) + ")" + celular.Text.SoNumero().Substring(3, 5) + "-" + celular.Text.SoNumero().Substring(8, 4);
                celular.SelectionStart = celular.Text.Length;
            }
        }

        private void barraMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void bb_capturar_Click(object sender, EventArgs e)
        {
            using (TFVisualizarCaptura fClifor = new TFVisualizarCaptura())
            {
                fClifor.Img = (bsClifor.Current as TRegistro_CadClifor).Img;
                if (fClifor.ShowDialog() == DialogResult.OK)
                    if (fClifor.Img != null)
                        try
                        {
                            (bsClifor.Current as TRegistro_CadClifor).Img = fClifor.Img;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
            }
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
