using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Utils;
using CamadaDados.Financeiro.Cadastros;
using CamadaNegocio.Financeiro.Cadastros;
using FormBusca;
using System.IO;


namespace Financeiro.Cadastros
{
    public partial class TFClifor : Form
    {
        private bool St_bloquear = false;
        private string CnpjOld = string.Empty;
        private TRegistro_CadClifor rclifor;
        public TRegistro_CadClifor rClifor
        {
            get
            {
                if (bsClifor.Current != null)
                    return bsClifor.Current as TRegistro_CadClifor;
                else
                    return null;
            }
            set { rclifor = value; }
        }

        public TFClifor()
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
            cbx1.Add(new TDataCombo("MASCULINO", "M"));
            cbx1.Add(new TDataCombo("FEMININO", "F"));
            tp_sexo.DataSource = cbx1;
            tp_sexo.DisplayMember = "Display";
            tp_sexo.ValueMember = "Value";

            System.Collections.ArrayList cbx2 = new System.Collections.ArrayList();
            cbx2.Add(new TDataCombo("SOLTEIRO", "0"));
            cbx2.Add(new TDataCombo("CASADO", "1"));
            cbx2.Add(new TDataCombo("SEPARADO", "2"));
            cbx2.Add(new TDataCombo("DIVORCIADO", "3"));
            cbx2.Add(new TDataCombo("VIUVO", "4"));
            estadocivil.DataSource = cbx2;
            estadocivil.DisplayMember = "Display";
            estadocivil.ValueMember = "Value";

            System.Collections.ArrayList cbx3 = new System.Collections.ArrayList();
            cbx3.Add(new TDataCombo("PROPRIA", "P"));
            cbx3.Add(new TDataCombo("ALUGADA", "A"));
            tp_residencia.DataSource = cbx3;
            tp_residencia.DisplayMember = "Display";
            tp_residencia.ValueMember = "Value";

            if (tcCentral.TabPages.Contains(tpPF))
                tcCentral.TabPages.Remove(tpPF);
        }

        private void Alterar()
        {
            if (rclifor != null)
            {
                bsClifor.DataSource = new TList_CadClifor() { rclifor };
                st_registro.Visible = true;
                CD_Clifor.Enabled = false;
                tp_pessoa.Focus();
                ID_Regiao.Enabled = CamadaNegocio.Diversos.TCN_Usuario_RegraEspecial.ValidaRegra(Utils.Parametros.pubLogin, "PERMITIR ALTERAR REGIÃO VENDA", null);
                bb_regiaoVenda.Enabled = ID_Regiao.Enabled;
                object obj_foto = new TCD_CadClifor().executarEscalar("select foto from tb_fin_clifor where cd_clifor = '" + rclifor.Cd_clifor.Trim() + "'", null);
                if (obj_foto != null)
                    try
                    {
                        (bsClifor.Current as TRegistro_CadClifor).Img = (byte[])obj_foto;
                        bsClifor.ResetCurrentItem();
                    }
                    catch { }
                if (rclifor.Tp_pessoa.Trim().ToUpper().Equals("J"))
                    CnpjOld = rclifor.Nr_cgc;
            }
            else
            {
                dt_demissao.Visible = false;
                lblDtDemissao.Visible = false;
                st_registro.Visible = false;
                CD_Clifor.Enabled = !CamadaNegocio.Diversos.TCN_CadParamSys.St_AutoInc("CD_Clifor");
                CamadaDados.Faturamento.Cadastros.TList_CfgNfe lCfg =
                    new CamadaDados.Faturamento.Cadastros.TCD_CfgNfe().Select(
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
                                        "         where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))"
                        }
                    }, 1, string.Empty);
                if (lCfg.Count > 0)
                {
                    bool existe_cert = true;
                    //Verificar se existe certificado instalado na maquina
                    try
                    {
                        Utils.Assinatura.TAssinatura2.BuscaNroSerie(lCfg[0].Nr_certificado_nfe);
                    }
                    catch { existe_cert = false; }
                    if (existe_cert)
                        using (srvNFE.TFConsultaCadCliforNFe fConsulta = new srvNFE.TFConsultaCadCliforNFe())
                        {
                            fConsulta.rCfgNfe = lCfg[0];
                            if (fConsulta.ShowDialog() == DialogResult.OK)
                                if (fConsulta.rClifor != null)
                                {
                                    bsClifor.DataSource = new TList_CadClifor() { fConsulta.rClifor };
                                    if (!AlterarEndereco())
                                    {
                                        bsClifor.Clear();
                                        bsClifor.AddNew();
                                    }
                                }
                                else
                                    bsClifor.AddNew();
                            else
                                bsClifor.AddNew();
                        }
                    else
                        bsClifor.AddNew();
                }
                else
                    bsClifor.AddNew();
                if (!CD_Clifor.Focus())
                    tp_pessoa.Focus();
            }
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
            if (vTp_pessoa.Trim().ToUpper().Equals("E") || vTp_pessoa.Trim().ToUpper().Equals("J"))
            {
                if (tcCentral.TabPages.Contains(tpPF))
                    tcCentral.TabPages.Remove(tpPF);
                if (vTp_pessoa.Trim().ToUpper().Equals("E"))
                    if (tcCentral.TabPages.Contains(tpComp))
                        tcCentral.TabPages.Remove(tpComp);
            }
            else if (vTp_pessoa.Trim().ToUpper().Equals("F"))
                if (!tcCentral.TabPages.Contains(tpPF))
                    tcCentral.TabPages.Add(tpPF);
            //Colunas do Grid Contatos
            clTp_contato.Visible = vTp_pessoa.Trim().ToUpper().Equals("J");
            clTipo_relaciomento.Visible = vTp_pessoa.Trim().ToUpper().Equals("F") || vTp_pessoa.Trim().ToUpper().Equals("E");
            clDt_nascimento.Visible = vTp_pessoa.Trim().ToUpper().Equals("F") || vTp_pessoa.Trim().ToUpper().Equals("E");
            clSt_envemailaniversariobool.Visible = vTp_pessoa.Trim().ToUpper().Equals("F") || vTp_pessoa.Trim().ToUpper().Equals("E");
            clSt_receberOSbool.Visible = vTp_pessoa.Trim().ToUpper().Equals("J");
        }

        private void Valida_CNPJ()
        {
            if ((NR_CGC.Text.Trim() != string.Empty) && (NR_CGC.Text.Trim() != ".   .   /    -"))
            {
                CNPJ_Valido.nr_CNPJ = NR_CGC.Text;
                if (!string.IsNullOrEmpty(CNPJ_Valido.nr_CNPJ))
                {
                    if (!CamadaNegocio.ConfigGer.TCN_CadParamGer.BuscaVlBool("DUP_CNPJ", null))
                    {
                        bool st_validar = false;
                        if (rclifor == null)
                            st_validar = true;
                        else
                            st_validar = !CnpjOld.Trim().Equals(NR_CGC.Text.Trim());
                        if (st_validar)
                        {
                            //Verificar se o cnpj ja existe no sistema
                            object obj = new TCD_CadClifor().BuscarEscalar(
                                            new TpBusca[]
                                        {
                                    new TpBusca()
                                    {
                                        vNM_Campo = "a.cd_clifor",
                                        vOperador = "<>",
                                        vVL_Busca = "'" + (bsClifor.Current as TRegistro_CadClifor).Cd_clifor + "'"
                                    },
                                    new TpBusca()
                                    {
                                        vNM_Campo = "a.nr_cgc",
                                        vOperador = "=",
                                        vVL_Busca = "'" + NR_CGC.Text.Trim() + "'"
                                    },
                                    new TpBusca()
                                    {
                                        vNM_Campo = "isnull(a.st_registro, 'A')",
                                        vOperador = "<>",
                                        vVL_Busca = "'C'"
                                    }
                                        }, "a.cd_clifor + a.nm_clifor");
                            if (obj == null ? false : obj.ToString().Trim() != string.Empty)
                            {
                                St_bloquear = true;
                                if (MessageBox.Show("O número do CNPJ: " + NR_CGC.Text + " já está cadastrado no sistema, \r\n com o CLIFOR: " + obj.ToString().Trim() +
                                                    "\r\nDeseja atualizar o cadastro deste cliente?",
                                                    "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                                                    MessageBoxDefaultButton.Button1) != DialogResult.Yes)
                                {
                                    NR_CGC.Clear();
                                    NR_CGC.Focus();
                                    return;
                                }
                                else
                                {
                                    TList_CadClifor lClifor =
                                        new TCD_CadClifor().Select(
                                            new TpBusca[]
                                        {
                                    new TpBusca()
                                    {
                                        vNM_Campo = "a.nr_cgc",
                                        vOperador = "=",
                                        vVL_Busca = "'" + NR_CGC.Text.Trim() + "'"
                                    }
                                        }, 1, string.Empty);
                                    if (lClifor.Count > 0)
                                    {
                                        lClifor[0].lEndereco =
                                            TCN_CadEndereco.Buscar(lClifor[0].Cd_clifor,
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
                                        lClifor[0].lContato =
                                                TCN_CadContatoCliFor.Buscar(string.Empty,
                                                                                lClifor[0].Cd_clifor,
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
                                        lClifor[0].lDadosBanc =
                                            TCN_CadDados_Bancarios_Clifor.Busca(lClifor[0].Cd_clifor,
                                                                                string.Empty,
                                                                                string.Empty,
                                                                                string.Empty,
                                                                                null);
                                        lClifor[0].lReferencia =
                                            TCN_CadReferenciaClifor.Busca(lClifor[0].Cd_clifor,
                                                                            string.Empty,
                                                                            string.Empty,
                                                                            string.Empty,
                                                                            null);
                                        lClifor[0].lPessoas =
                                            TCN_PessoasAutorizadas.Buscar(lClifor[0].Cd_clifor,
                                                                            string.Empty,
                                                                            string.Empty,
                                                                            string.Empty,
                                                                            string.Empty,
                                                                            null);

                                        lClifor[0].lAnexo =
                                            TCN_AnexoClifor.Buscar(lClifor[0].Cd_clifor,
                                                                    string.Empty,
                                                                    null);
                                        lClifor[0].lTabPreco =
                                            TCN_Clifor_X_TabPreco.Buscar(lClifor[0].Cd_clifor,
                                                                            string.Empty,
                                                                            null);

                                        lClifor[0].lConfPagto =
                                            TCN_Clifor_X_CondPgto.Buscar(lClifor[0].Cd_clifor,
                                                                            string.Empty,
                                                                            null);
                                        rclifor = lClifor[0];
                                        Alterar();
                                        bsClifor.ResetCurrentItem();
                                    }
                                }
                            }
                            else
                                St_bloquear = false;
                        }
                        else St_bloquear = false;
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
                                    vVL_Busca = "'" + (bsClifor.Current as TRegistro_CadClifor).Cd_clifor + "'"
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
                                    vVL_Busca = "'" + (bsClifor.Current as TRegistro_CadClifor).Cd_clifor + "'"
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
                            if (MessageBox.Show("O número do CNPJ: " + NR_CGC.Text + " já está cadastrado no sistema, \r\n com o CLIFOR: " + obj.ToString().Trim() +
                                            "\r\nDeseja atualizar os dados deste cliente?",
                                            "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                                            MessageBoxDefaultButton.Button1) != DialogResult.Yes)
                            {
                                NR_CGC.Clear();
                                NR_CGC.Focus();
                            }
                            else
                            {

                            }
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
                                    vVL_Busca = "'" + (bsClifor.Current as TRegistro_CadClifor).Cd_clifor + "'"
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
                Valida_CNPJ();
                //Se o cnpj já existir e parar o processo de gravar para validação.
                if (St_bloquear)
                    return;
                if ((bsClifor.Current as TRegistro_CadClifor).lEndereco.Count < 1)
                {
                    MessageBox.Show("Não é permitido gravar clifor sem endereço.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                DialogResult = DialogResult.OK;
            }
        }

        private void InserirEndereco()
        {
            if (tp_pessoa.SelectedValue != null)
            {
                using (TFEndereco fEnd = new TFEndereco())
                {
                    fEnd.Tp_pessoa = tp_pessoa.SelectedValue.ToString();
                    if (fEnd.ShowDialog() == DialogResult.OK)
                        if (fEnd.rEnd != null)
                        {
                            (bsClifor.Current as TRegistro_CadClifor).lEndereco.Add(fEnd.rEnd);
                            bsClifor.ResetCurrentItem();
                        }
                }
            }
            else
            {
                MessageBox.Show("Obrigatório informar Pessoa!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tp_pessoa.Focus();
            }
        }

        private bool AlterarEndereco()
        {
            if (bsEndereco.Current != null)
            {
                using (TFEndereco fEnd = new TFEndereco())
                {
                    TRegistro_CadEndereco rAux = new TRegistro_CadEndereco();
                    rAux.Cep = (bsEndereco.Current as TRegistro_CadEndereco).Cep;
                    rAux.Ds_endereco = (bsEndereco.Current as TRegistro_CadEndereco).Ds_endereco;
                    rAux.Numero = (bsEndereco.Current as TRegistro_CadEndereco).Numero;
                    rAux.Cp = (bsEndereco.Current as TRegistro_CadEndereco).Cp;
                    rAux.Bairro = (bsEndereco.Current as TRegistro_CadEndereco).Bairro;
                    rAux.Proximo = (bsEndereco.Current as TRegistro_CadEndereco).Proximo;
                    rAux.Cd_cidade = (bsEndereco.Current as TRegistro_CadEndereco).Cd_cidade;
                    rAux.DS_Cidade = (bsEndereco.Current as TRegistro_CadEndereco).DS_Cidade;
                    rAux.UF = (bsEndereco.Current as TRegistro_CadEndereco).UF;
                    rAux.CD_Pais = (bsEndereco.Current as TRegistro_CadEndereco).CD_Pais;
                    rAux.NM_Pais = (bsEndereco.Current as TRegistro_CadEndereco).NM_Pais;
                    rAux.Ds_complemento = (bsEndereco.Current as TRegistro_CadEndereco).Ds_complemento;
                    rAux.Fone = (bsEndereco.Current as TRegistro_CadEndereco).Fone;
                    rAux.Fone_comercial = (bsEndereco.Current as TRegistro_CadEndereco).Fone_comercial;
                    rAux.Celular = (bsEndereco.Current as TRegistro_CadEndereco).Celular;
                    rAux.Insc_estadual = (bsEndereco.Current as TRegistro_CadEndereco).Insc_estadual;
                    rAux.St_enderecoentrega = (bsEndereco.Current as TRegistro_CadEndereco).St_enderecoentrega;
                    fEnd.rEnd = bsEndereco.Current as TRegistro_CadEndereco;
                    fEnd.Tp_pessoa = tp_pessoa.SelectedValue.ToString();
                    if (fEnd.ShowDialog() != DialogResult.OK)
                    {
                        (bsEndereco.Current as TRegistro_CadEndereco).Cep = rAux.Cep;
                        (bsEndereco.Current as TRegistro_CadEndereco).Ds_endereco = rAux.Ds_endereco;
                        (bsEndereco.Current as TRegistro_CadEndereco).Numero = rAux.Numero;
                        (bsEndereco.Current as TRegistro_CadEndereco).Cp = rAux.Cp;
                        (bsEndereco.Current as TRegistro_CadEndereco).Bairro = rAux.Bairro;
                        (bsEndereco.Current as TRegistro_CadEndereco).Proximo = rAux.Proximo;
                        (bsEndereco.Current as TRegistro_CadEndereco).Cd_cidade = rAux.Cd_cidade;
                        (bsEndereco.Current as TRegistro_CadEndereco).DS_Cidade = rAux.DS_Cidade;
                        (bsEndereco.Current as TRegistro_CadEndereco).UF = rAux.UF;
                        (bsEndereco.Current as TRegistro_CadEndereco).CD_Pais = rAux.CD_Pais;
                        (bsEndereco.Current as TRegistro_CadEndereco).NM_Pais = rAux.NM_Pais;
                        (bsEndereco.Current as TRegistro_CadEndereco).Ds_complemento = rAux.Ds_complemento;
                        (bsEndereco.Current as TRegistro_CadEndereco).Fone = rAux.Fone;
                        (bsEndereco.Current as TRegistro_CadEndereco).Fone_comercial = rAux.Fone_comercial;
                        (bsEndereco.Current as TRegistro_CadEndereco).Celular = rAux.Celular;
                        (bsEndereco.Current as TRegistro_CadEndereco).Insc_estadual = rAux.Insc_estadual;
                        (bsEndereco.Current as TRegistro_CadEndereco).St_enderecoentrega = rAux.St_enderecoentrega;
                        return false;
                    }
                    bsClifor.ResetCurrentItem();
                    return true;
                }
            }
            else
            {
                MessageBox.Show("Obrigatorio selecionar endereço para alterar.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }

        private void ExcluirEndereco()
        {
            if (bsEndereco.Current != null)
            {
                if (MessageBox.Show("Confirma exclusão do endereço selecionado?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                     MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    (bsClifor.Current as TRegistro_CadClifor).lEndDel.Add(bsEndereco.Current as TRegistro_CadEndereco);
                    bsEndereco.RemoveCurrent();
                }
            }
            else
                MessageBox.Show("Obrigatorio selecionar endereço para excluir.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void InserirContato()
        {
            if ((bsClifor.Current as TRegistro_CadClifor).Tp_pessoa.Trim().ToUpper().Equals("J"))
                using (TFContatos fContato = new TFContatos())
                {
                    if (fContato.ShowDialog() == DialogResult.OK)
                        if (fContato.rContato != null)
                        {
                            (bsClifor.Current as TRegistro_CadClifor).lContato.Add(fContato.rContato);
                            bsClifor.ResetCurrentItem();
                        }
                }
            else
                using (TFContatoPF fContatoPF = new TFContatoPF())
                {
                    if (fContatoPF.ShowDialog() == DialogResult.OK)
                        if (fContatoPF.rContato != null)
                        {
                            (bsClifor.Current as TRegistro_CadClifor).lContato.Add(fContatoPF.rContato);
                            bsClifor.ResetCurrentItem();
                        }
                }
        }

        private void AlterarContato()
        {
            if (bsContato.Current != null)
            {
                if ((bsClifor.Current as TRegistro_CadClifor).Tp_pessoa.Trim().ToUpper().Equals("J"))
                    using (TFContatos fContato = new TFContatos())
                    {
                        TRegistro_CadContatoCliFor rAux = new TRegistro_CadContatoCliFor();
                        rAux.Nm_Contato = (bsContato.Current as TRegistro_CadContatoCliFor).Nm_Contato;
                        rAux.Email = (bsContato.Current as TRegistro_CadContatoCliFor).Email;
                        rAux.Fone = (bsContato.Current as TRegistro_CadContatoCliFor).Fone;
                        rAux.FoneMovel = (bsContato.Current as TRegistro_CadContatoCliFor).FoneMovel;
                        rAux.Tp_Contato = (bsContato.Current as TRegistro_CadContatoCliFor).Tp_Contato;
                        rAux.DS_Observacao = (bsContato.Current as TRegistro_CadContatoCliFor).DS_Observacao;
                        fContato.rContato = bsContato.Current as TRegistro_CadContatoCliFor;
                        if (fContato.ShowDialog() != DialogResult.OK)
                        {
                            (bsContato.Current as TRegistro_CadContatoCliFor).Nm_Contato = rAux.Nm_Contato;
                            (bsContato.Current as TRegistro_CadContatoCliFor).Email = rAux.Email;
                            (bsContato.Current as TRegistro_CadContatoCliFor).Fone = rAux.Fone;
                            (bsContato.Current as TRegistro_CadContatoCliFor).FoneMovel = rAux.FoneMovel;
                            (bsContato.Current as TRegistro_CadContatoCliFor).Tp_Contato = rAux.Tp_Contato;
                            (bsContato.Current as TRegistro_CadContatoCliFor).DS_Observacao = rAux.DS_Observacao;
                        }
                        bsClifor.ResetCurrentItem();
                    }
                else
                    using (TFContatoPF fContatoPF = new TFContatoPF())
                    {
                        TRegistro_CadContatoCliFor rAux = new TRegistro_CadContatoCliFor();
                        rAux.Nm_Contato = (bsContato.Current as TRegistro_CadContatoCliFor).Nm_Contato;
                        rAux.Email = (bsContato.Current as TRegistro_CadContatoCliFor).Email;
                        rAux.Fone = (bsContato.Current as TRegistro_CadContatoCliFor).Fone;
                        rAux.FoneMovel = (bsContato.Current as TRegistro_CadContatoCliFor).FoneMovel;
                        rAux.Tp_relacionamento = (bsContato.Current as TRegistro_CadContatoCliFor).Tp_relacionamento;
                        rAux.Dt_nascimento = (bsContato.Current as TRegistro_CadContatoCliFor).Dt_nascimento;
                        rAux.St_envemailaniversario = (bsContato.Current as TRegistro_CadContatoCliFor).St_envemailaniversario;
                        rAux.DS_Observacao = (bsContato.Current as TRegistro_CadContatoCliFor).DS_Observacao;
                        fContatoPF.rContato = bsContato.Current as TRegistro_CadContatoCliFor;
                        if (fContatoPF.ShowDialog() != DialogResult.OK)
                        {
                            (bsContato.Current as TRegistro_CadContatoCliFor).Nm_Contato = rAux.Nm_Contato;
                            (bsContato.Current as TRegistro_CadContatoCliFor).Email = rAux.Email;
                            (bsContato.Current as TRegistro_CadContatoCliFor).Fone = rAux.Fone;
                            (bsContato.Current as TRegistro_CadContatoCliFor).FoneMovel = rAux.FoneMovel;
                            (bsContato.Current as TRegistro_CadContatoCliFor).Tp_relacionamento = rAux.Tp_relacionamento;
                            (bsContato.Current as TRegistro_CadContatoCliFor).Dt_nascimento = rAux.Dt_nascimento;
                            (bsContato.Current as TRegistro_CadContatoCliFor).St_envemailaniversario = rAux.St_envemailaniversario;
                            (bsContato.Current as TRegistro_CadContatoCliFor).DS_Observacao = rAux.DS_Observacao;
                        }
                        bsClifor.ResetCurrentItem();
                    }
            }
            else
                MessageBox.Show("Obrigatorio selecionar contato para alterar.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ExcluirContato()
        {
            if (bsContato.Current != null)
            {
                if (MessageBox.Show("Confirma exclusão do contato selecionado?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                     MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    (bsClifor.Current as TRegistro_CadClifor).lContatoDel.Add(bsContato.Current as TRegistro_CadContatoCliFor);
                    bsContato.RemoveCurrent();
                }
            }
            else
                MessageBox.Show("Obrigatorio selecionar contato para excluir.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void InserirDadosBanc()
        {
            using (TFDadosBanc fDados = new TFDadosBanc())
            {
                if (fDados.ShowDialog() == DialogResult.OK)
                    if (fDados.rDados != null)
                    {
                        (bsClifor.Current as TRegistro_CadClifor).lDadosBanc.Add(fDados.rDados);
                        bsClifor.ResetCurrentItem();
                    }
            }
        }

        private void ExcluirDadosBanc()
        {
            if (bsDados.Current != null)
            {
                if (MessageBox.Show("Confirma exclusão do registro selecionado?", "Pergunta", MessageBoxButtons.YesNo,
                     MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    (bsClifor.Current as TRegistro_CadClifor).lDadosBancDel.Add(bsDados.Current as TRegistro_CadDados_Bancarios_Clifor);
                    bsDados.RemoveCurrent();
                }
            }
            else
                MessageBox.Show("Obrigatorio selecionar dados bancarios para excluir.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void InserirReferencia()
        {
            using (TFReferencia fReferencia = new TFReferencia())
            {
                if (fReferencia.ShowDialog() == DialogResult.OK)
                    if (fReferencia.rReferencia != null)
                    {
                        (bsClifor.Current as TRegistro_CadClifor).lReferencia.Add(fReferencia.rReferencia);
                        bsClifor.ResetCurrentItem();
                    }
            }
        }

        private void AlterarReferencia()
        {
            if (bsReferencia.Current != null)
            {
                using (TFReferencia fReferencia = new TFReferencia())
                {
                    TRegistro_CadReferenciaCliFor rAux = new TRegistro_CadReferenciaCliFor();
                    rAux.Nm_referencia = (bsReferencia.Current as TRegistro_CadReferenciaCliFor).Nm_referencia;
                    rAux.Fone = (bsReferencia.Current as TRegistro_CadReferenciaCliFor).Fone;
                    rAux.Tp_Referencia = (bsReferencia.Current as TRegistro_CadReferenciaCliFor).Tp_Referencia;
                    rAux.Tp_parentesco = (bsReferencia.Current as TRegistro_CadReferenciaCliFor).Tp_parentesco;
                    fReferencia.rReferencia = bsReferencia.Current as TRegistro_CadReferenciaCliFor;
                    if (fReferencia.ShowDialog() != DialogResult.OK)
                    {
                        (bsReferencia.Current as TRegistro_CadReferenciaCliFor).Nm_referencia = rAux.Nm_referencia;
                        (bsReferencia.Current as TRegistro_CadReferenciaCliFor).Fone = rAux.Fone;
                        (bsReferencia.Current as TRegistro_CadReferenciaCliFor).Tp_Referencia = rAux.Tp_Referencia;
                        (bsReferencia.Current as TRegistro_CadReferenciaCliFor).Tp_parentesco = rAux.Tp_parentesco;
                    }
                    bsClifor.ResetCurrentItem();
                }
            }
            else
                MessageBox.Show("Obrigatorio selecionar Referência para alterar.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ExcluirReferencia()
        {
            if (bsReferencia.Current != null)
            {
                if (MessageBox.Show("Confirma exclusão do registro selecionado?", "Pergunta", MessageBoxButtons.YesNo,
                     MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    (bsClifor.Current as TRegistro_CadClifor).lReferenciaDel.Add(bsReferencia.Current as TRegistro_CadReferenciaCliFor);
                    bsReferencia.RemoveCurrent();
                }
            }
            else
                MessageBox.Show("Obrigatorio selecionar Referências para excluir.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void InserirPessoa()
        {
            using (TFPessoasAutorizadas fPessoa = new TFPessoasAutorizadas())
            {
                if (fPessoa.ShowDialog() == DialogResult.OK)
                    if (fPessoa.rPessoa != null)
                    {
                        (bsClifor.Current as TRegistro_CadClifor).lPessoas.Add(fPessoa.rPessoa);
                        bsClifor.ResetCurrentItem();
                    }
            }
        }

        private void AlterarPessoa()
        {
            if (bsPessoas.Current != null)
            {
                using (TFPessoasAutorizadas fPessoa = new TFPessoasAutorizadas())
                {
                    TRegistro_PessoasAutorizadas rAux = new TRegistro_PessoasAutorizadas();
                    rAux.Nm_pessoa = (bsPessoas.Current as TRegistro_PessoasAutorizadas).Nm_pessoa;
                    rAux.Nr_cpf = (bsPessoas.Current as TRegistro_PessoasAutorizadas).Nr_cpf;
                    rAux.Tp_relacionamento = (bsPessoas.Current as TRegistro_PessoasAutorizadas).Tp_relacionamento;
                    rAux.St_registro = (bsPessoas.Current as TRegistro_PessoasAutorizadas).St_registro;
                    (bsPessoas.Current as TRegistro_PessoasAutorizadas).St_registro = "A";
                    fPessoa.rPessoa = bsPessoas.Current as TRegistro_PessoasAutorizadas;
                    if (fPessoa.ShowDialog() != DialogResult.OK)
                    {
                        (bsPessoas.Current as TRegistro_PessoasAutorizadas).Nm_pessoa = rAux.Nm_pessoa;
                        (bsPessoas.Current as TRegistro_PessoasAutorizadas).Nr_cpf = rAux.Nr_cpf;
                        (bsPessoas.Current as TRegistro_PessoasAutorizadas).Tp_relacionamento = rAux.Tp_relacionamento;
                        (bsPessoas.Current as TRegistro_PessoasAutorizadas).St_registro = rAux.St_registro;
                    }
                    bsClifor.ResetCurrentItem();
                }
            }
            else
                MessageBox.Show("Obrigatorio selecionar Registro para alterar.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ExcluirPessoa()
        {
            if (bsPessoas.Current != null)
            {
                if (MessageBox.Show("Confirma exclusão do registro selecionado?", "Pergunta", MessageBoxButtons.YesNo,
                     MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    (bsPessoas.Current as TRegistro_PessoasAutorizadas).St_registro = "C";
                    bsClifor.ResetCurrentItem();
                }
            }
            else
                MessageBox.Show("Obrigatorio selecionar registro para excluir.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void InserirAnexo()
        {
            using (OpenFileDialog file = new OpenFileDialog())
            {
                if (file.ShowDialog() == DialogResult.OK)
                    if (System.IO.File.Exists(file.FileName))
                    {
                        TRegistro_AnexoClifor rAnexo = new TRegistro_AnexoClifor();
                        rAnexo.Imagem_anexo = System.IO.File.ReadAllBytes(file.FileName);
                        rAnexo.Ext_Anexo = System.IO.Path.GetExtension(file.FileName);
                        InputBox ibp = new InputBox();
                        ibp.Text = "Descrição Anexo";
                        string ds = ibp.ShowDialog();
                        if (string.IsNullOrEmpty(ds))
                        {
                            MessageBox.Show("Obrigatório informar Descrição do Anexo!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        rAnexo.Ds_anexo = ds;
                        (bsClifor.Current as TRegistro_CadClifor).lAnexo.Add(rAnexo);
                        bsClifor.ResetCurrentItem();
                    }
            }
        }

        private void ExcluirAnexo()
        {
            if (bsAnexoClifor.Current != null)
                if (MessageBox.Show("Deseja excluir esse Anexo?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    (bsClifor.Current as TRegistro_CadClifor).lAnexoDel.Add(bsAnexoClifor.Current as TRegistro_AnexoClifor);
                    bsAnexoClifor.RemoveCurrent();
                    bsClifor.ResetCurrentItem();
                }
        }

        private void InserirTabPreco()
        {
            DataRowView linha = UtilPesquisa.BTN_BUSCA("a.ds_tabelapreco|Tabela Preço|150;a.cd_tabelapreco|Código|60", null, new CamadaDados.Diversos.TCD_CadTbPreco(), string.Empty);
            if (linha != null)
            {
                if (!(bsClifor.Current as TRegistro_CadClifor).lTabPreco.Exists(p => p.Cd_tabelapreco.Trim().Equals(linha["cd_tabelapreco"].ToString().Trim())))
                {
                    (bsClifor.Current as TRegistro_CadClifor).lTabPreco.Add(
                        new TRegistro_Clifor_X_TabPreco() { Cd_tabelapreco = linha["cd_tabelapreco"].ToString(), Ds_tabelapreco = linha["ds_tabelapreco"].ToString() });
                    bsClifor.ResetCurrentItem();
                }
            }
        }

        private void ExcluirTabPreco()
        {
            if (bsTabPreco.Current != null)
                if (MessageBox.Show("Confirma exclusão registro?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    (bsClifor.Current as TRegistro_CadClifor).lTabPrecoDel.Add(bsTabPreco.Current as TRegistro_Clifor_X_TabPreco);
                    bsTabPreco.RemoveCurrent();
                }
        }
        private void capturarImagem()
        {

            using (WebCamLibrary.TFCapturaVideo fCap = new WebCamLibrary.TFCapturaVideo())
            {
                if (fCap.ShowDialog() == DialogResult.OK)
                {

                    pImagens.Image = fCap.Img;
                    pImagens.SizeMode = PictureBoxSizeMode.StretchImage;
                    (bsClifor.Current as TRegistro_CadClifor).Img = Convercao_imagem.imageToByteArray(fCap.Img);

                    bsClifor.ResetCurrentItem();
                }
            }
        }
        private void TFClifor_Load(object sender, EventArgs e)
        {
            ShapeGrid.RestoreShape(this, gEndereco);
            ShapeGrid.RestoreShape(this, gContato);
            ShapeGrid.RestoreShape(this, gDados);
            ShapeGrid.RestoreShape(this, gReferencia);
            Icon = ResourcesUtils.TecnoAliance_ICO;
            pClifor.set_FormatZero();
            pComp.set_FormatZero();
            pFunc.set_FormatZero();

            if (tcCentral.TabPages.Contains(tpFunc))
                tcCentral.TabPages.Remove(tpFunc);
            if (tbCargos.TabPages.Contains(tbMotorista))
                tbCargos.TabPages.Remove(tbMotorista);
            Alterar();
            //Verificar se o usuario tem permissao para visualizar salario
            if (!CamadaNegocio.Diversos.TCN_Usuario_RegraEspecial.ValidaRegra(Utils.Parametros.pubLogin, "PERMITIR VISUALIZAR SALARIO", null))
            {
                lblSalario.Visible = false;
                vl_salario.Visible = false;
            }
        }

        private void tp_pessoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            VisibleCampos(tp_pessoa.SelectedValue != null ? tp_pessoa.SelectedValue.ToString() : string.Empty);
        }

        private void NR_CGC_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(NR_CGC.Text.SoNumero()))
                if (Utils.Parametros.pubCultura.Trim() == "pt-BR")
                    Valida_CNPJ();
                else if (Utils.Parametros.pubCultura.Trim() == "es-ES")
                    Valida_RUC();
        }

        private void NR_CPF_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(NR_CPF.Text.SoNumero()))
                if (Utils.Parametros.pubCultura.Trim().ToUpper() != "pt-BR")
                    Valida_CPF();
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

        private void bb_FiscalClifor_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BUSCA("DS_CondFiscal|Descrição|200;CD_CondFiscal_Clifor|Cód. Fiscal|100"
              , new Componentes.EditDefault[] { Cd_CondFiscal_Clifor, DS_CondFiscal },
              new CamadaDados.Fiscal.TCD_CadConFiscalClifor(), string.Empty);
        }

        private void Cd_CondFiscal_Clifor_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("CD_CondFiscal_Clifor|=|'" + Cd_CondFiscal_Clifor.Text + "'"
                , new Componentes.EditDefault[] { Cd_CondFiscal_Clifor, DS_CondFiscal },
                new CamadaDados.Fiscal.TCD_CadConFiscalClifor());
        }

        private void bb_RamoAtividade_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BUSCA("a.DS_RamoAtividade|Ramo Atividade|200;a.ID_RamoAtividade|Cód. Ramo Atividade|100",
                              new Componentes.EditDefault[] { ID_RamoAtividade, DS_RamoAtividade }, new TCD_CadRamoAtividade(), string.Empty);
        }

        private void ID_RamoAtividade_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("a.ID_RamoAtividade|=|'" + ID_RamoAtividade.Text + "'",
                            new Componentes.EditDefault[] { ID_RamoAtividade, DS_RamoAtividade }, new TCD_CadRamoAtividade());
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void ts_btn_Inserir_Endereco_Click(object sender, EventArgs e)
        {
            InserirEndereco();
        }

        private void ts_btn_Alterar_Endereco_Click(object sender, EventArgs e)
        {
            AlterarEndereco();
        }

        private void ts_btn_Deletar_Endereco_Click(object sender, EventArgs e)
        {
            ExcluirEndereco();
        }

        private void ts_btn_Inserir_Contato_Click(object sender, EventArgs e)
        {
            InserirContato();
        }

        private void ts_btn_Alterar_Contato_Click(object sender, EventArgs e)
        {
            AlterarContato();
        }

        private void ts_btn_Deletar_Contato_Click(object sender, EventArgs e)
        {
            ExcluirContato();
        }

        private void ts_btn_Inserir_Dados_Bancarios_Click(object sender, EventArgs e)
        {
            InserirDadosBanc();
        }

        private void btn_inserirReferencia_Click(object sender, EventArgs e)
        {
            InserirReferencia();
        }

        private void btn_alterarReferencia_Click(object sender, EventArgs e)
        {
            AlterarReferencia();
        }

        private void btn_excluirReferencia_Click(object sender, EventArgs e)
        {
            ExcluirReferencia();
        }

        private void ts_btn_Deletar_Dados_Bancarios_Click(object sender, EventArgs e)
        {
            ExcluirDadosBanc();
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            afterGrava();
        }

        private void TFClifor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                DialogResult = DialogResult.Cancel;
            else if (e.Control && tcDetalhes.SelectedTab.Equals(tpEndereco) && e.KeyCode.Equals(Keys.F10))
                InserirEndereco();
            else if (e.Control && tcDetalhes.SelectedTab.Equals(tpContato) && e.KeyCode.Equals(Keys.F10))
                InserirContato();
            else if (e.Control && tcDetalhes.SelectedTab.Equals(tpDados) && e.KeyCode.Equals(Keys.F10))
                InserirDadosBanc();
            else if (e.Control && tcDetalhes.SelectedTab.Equals(tpReferencia) && e.KeyCode.Equals(Keys.F10))
                InserirReferencia();
            else if (e.Control && tcDetalhes.SelectedTab.Equals(tpEndereco) && e.KeyCode.Equals(Keys.F11))
                AlterarEndereco();
            else if (e.Control && tcDetalhes.SelectedTab.Equals(tpContato) && e.KeyCode.Equals(Keys.F11))
                AlterarContato();
            else if (e.Control && tcDetalhes.SelectedTab.Equals(tpReferencia) && e.KeyCode.Equals(Keys.F11))
                AlterarReferencia();
            else if (e.Control && tcDetalhes.SelectedTab.Equals(tpEndereco) && e.KeyCode.Equals(Keys.F12))
                ExcluirEndereco();
            else if (e.Control && tcDetalhes.SelectedTab.Equals(tpContato) && e.KeyCode.Equals(Keys.F12))
                ExcluirContato();
            else if (e.Control && tcDetalhes.SelectedTab.Equals(tpDados) && e.KeyCode.Equals(Keys.F12))
                ExcluirDadosBanc();
            else if (e.Control && tcDetalhes.SelectedTab.Equals(tpReferencia) && e.KeyCode.Equals(Keys.F12))
                ExcluirReferencia();
            else if (e.Control && tcDetalhes.SelectedTab.Equals(tpPessoasAut) && e.KeyCode.Equals(Keys.F10))
                InserirPessoa();
            else if (e.Control && tcDetalhes.SelectedTab.Equals(tpPessoasAut) && e.KeyCode.Equals(Keys.F11))
                AlterarPessoa();
            else if (e.Control && tcDetalhes.SelectedTab.Equals(tpPessoasAut) && e.KeyCode.Equals(Keys.F12))
                ExcluirPessoa();
            else if (e.Control && tcDetalhes.SelectedTab.Equals(tpAnexo) && e.KeyCode.Equals(Keys.F10))
                InserirAnexo();
            else if (e.Control && tcDetalhes.SelectedTab.Equals(tpAnexo) && e.KeyCode.Equals(Keys.F12))
                ExcluirAnexo();
            else if (e.Control && tcDetalhes.SelectedTab.Equals(tpTabPreco) && e.KeyCode.Equals(Keys.F10))
                InserirTabPreco();
            else if (e.Control && tcDetalhes.SelectedTab.Equals(tpTabPreco) && e.KeyCode.Equals(Keys.F12))
                ExcluirTabPreco();
        }

        private void bb_empresa_Click(object sender, EventArgs e)
        {
            string vColunas = "a.NM_Empresa|Nome Empresa|350;" +
                              "a.CD_Empresa|Cód. Empresa|100";
            string vParamFixo = "|EXISTS|(select 1 from Tb_div_usuario_X_empresa  x where x.cd_empresa = A.cd_empresa " +
                                "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                                "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                "       where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_empresa, nm_empresa }, new CamadaDados.Diversos.TCD_CadEmpresa(), vParamFixo);
        }

        private void cd_empresa_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.CD_Empresa|=|'" + cd_empresa.Text.Trim() + "';" +
                              "|EXISTS|(select 1 from Tb_div_usuario_X_empresa  x where x.cd_empresa = a.cd_empresa " +
                              "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                              "(exists(select 1 from tb_div_usuario_x_grupos y " +
                              "         where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))";
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { cd_empresa, nm_empresa }, new CamadaDados.Diversos.TCD_CadEmpresa());
        }

        private void bb_cargo_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_cargo|Descrição Cargo|200;" +
                              "a.id_cargo|Id. Cargo|80;" +
                              "a.st_vendedor|Vendedor|80;" +
                              "a.st_motorista|Motorista|80;" +
                              "a.st_frentista|Frentista|80";
            DataRowView linha = UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { id_cargo, ds_cargo },
                                                        new CamadaDados.Diversos.TCD_CargoFuncionario(), string.Empty);
            if (linha != null)
            {
                st_vendedor.Checked = linha["st_vendedor"].ToString().Trim().ToUpper().Equals("S");
                st_vendedorconsulta.Checked = linha["st_vendedor"].ToString().Trim().ToUpper().Equals("S");
                st_motorista.Checked = linha["st_motorista"].ToString().Trim().ToUpper().Equals("S");
                st_frentista.Checked = linha["st_frentista"].ToString().Trim().ToUpper().Equals("S");
                st_tecnico.Checked = linha["st_tecnico"].ToString().Trim().ToUpper().Equals("S");
                st_operadorcx.Checked = linha["st_operadorcx"].ToString().Trim().ToUpper().Equals("S");

            }
            else
            {
                st_vendedor.Checked = false;
                st_vendedorconsulta.Checked = false;
                st_motorista.Checked = false;
                st_frentista.Checked = false;
                st_tecnico.Checked = false;
                st_operadorcx.Checked = false;
            }
        }

        private void id_cargo_Leave(object sender, EventArgs e)
        {
            string vParam = "a.id_cargo|=|" + id_cargo.Text;
            DataRow linha = UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { id_cargo, ds_cargo },
                                                    new CamadaDados.Diversos.TCD_CargoFuncionario());
            if (linha != null)
            {
                st_vendedor.Checked = linha["st_vendedor"].ToString().Trim().ToUpper().Equals("S");
                st_vendedorconsulta.Checked = linha["st_vendedor"].ToString().Trim().ToUpper().Equals("S");
                st_motorista.Checked = linha["st_motorista"].ToString().Trim().ToUpper().Equals("S");
                st_frentista.Checked = linha["st_frentista"].ToString().Trim().ToUpper().Equals("S");
                st_tecnico.Checked = linha["st_tecnico"].ToString().Trim().ToUpper().Equals("S");
                st_operadorcx.Checked = linha["st_operadorcx"].ToString().Trim().ToUpper().Equals("S");
            }
            else
            {
                st_vendedor.Checked = false;
                st_vendedorconsulta.Checked = false;
                st_motorista.Checked = false;
                st_frentista.Checked = false;
                st_tecnico.Checked = false;
                st_operadorcx.Checked = false;
            }
        }

        private void st_motorista_CheckedChanged(object sender, EventArgs e)
        {
            if (!st_motorista.Checked)
            {
                if (tbCargos.TabPages.Contains(tbMotorista))
                    tbCargos.TabPages.Remove(tbMotorista);
            }
            else if (st_motorista.Checked)
            {
                tlpFunc.ColumnStyles[1] = new ColumnStyle(SizeType.Absolute, 460);
                if (!tbCargos.TabPages.Contains(tbMotorista))
                    tbCargos.TabPages.Add(tbMotorista);
            }
            else
                if (tbCargos.TabPages.Contains(tbMotorista))
                tbCargos.TabPages.Remove(tbMotorista);
            else
                tlpFunc.ColumnStyles[1] = new ColumnStyle(SizeType.Absolute, 0);
        }

        private void st_funcionario_CheckedChanged(object sender, EventArgs e)
        {
            if (st_funcionario.Checked)
            {
                if (!tcCentral.TabPages.Contains(tpFunc))
                    tcCentral.TabPages.Add(tpFunc);
            }
            else
                if (tcCentral.TabPages.Contains(tpFunc))
                tcCentral.TabPages.Remove(tpFunc);
        }

        private void St_ativomot_Click(object sender, EventArgs e)
        {
            if (bsClifor.Current != null)
                if (((bsClifor.Current as TRegistro_CadClifor).Dt_demissao != null) && St_ativomot.Checked)
                {
                    MessageBox.Show("Não é permitido ativar motorista com data de demissão.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    St_ativomot.Checked = false;
                }
        }

        private void bb_consultarCadNFe_Click(object sender, EventArgs e)
        {
            CamadaDados.Faturamento.Cadastros.TList_CfgNfe lCfg =
                    new CamadaDados.Faturamento.Cadastros.TCD_CfgNfe().Select(
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
                                        "         where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))"
                        }
                    }, 1, string.Empty);
            if (lCfg.Count > 0)
            {
                bool existe_cert = true;
                //Verificar se existe certificado instalado na maquina
                try
                {
                    Utils.Assinatura.TAssinatura2.BuscaNroSerie(lCfg[0].Nr_certificado_nfe);
                }
                catch { existe_cert = false; }
                if (existe_cert)
                    using (srvNFE.TFConsultaCadCliforNFe fConsulta = new srvNFE.TFConsultaCadCliforNFe())
                    {
                        fConsulta.nrCnpj = (bsClifor.Current as TRegistro_CadClifor).Nr_cgc;
                        fConsulta.nrCpf = (bsClifor.Current as TRegistro_CadClifor).Nr_cpf;
                        if ((bsClifor.Current as TRegistro_CadClifor).lEndereco.Count > 0)
                            fConsulta.sgUF = (bsClifor.Current as TRegistro_CadClifor).lEndereco[0].UF;
                        fConsulta.rCfgNfe = lCfg[0];
                        if (fConsulta.ShowDialog() == DialogResult.OK)
                            if (fConsulta.rClifor != null)
                            {
                                //Tipo pessoa
                                (bsClifor.Current as TRegistro_CadClifor).Tp_pessoa = fConsulta.rClifor.Tp_pessoa;
                                //CNPJ
                                (bsClifor.Current as TRegistro_CadClifor).Nr_cgc = fConsulta.rClifor.Nr_cgc;
                                //CPF
                                (bsClifor.Current as TRegistro_CadClifor).Nr_cpf = fConsulta.rClifor.Nr_cpf;
                                //Razao Social
                                (bsClifor.Current as TRegistro_CadClifor).Nm_clifor = fConsulta.rClifor.Nm_clifor;
                                //Nome Fantasia
                                (bsClifor.Current as TRegistro_CadClifor).Nm_fantasia = fConsulta.rClifor.Nm_fantasia;
                                if (fConsulta.rClifor.lEndereco.Count > 0)
                                {
                                    if ((bsClifor.Current as TRegistro_CadClifor).lEndereco.Count > 0)
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
                                    else
                                    {
                                        TRegistro_CadEndereco rEndereco = new TRegistro_CadEndereco();
                                        //Endereco
                                        rEndereco.Ds_endereco = fConsulta.rClifor.lEndereco[0].Ds_endereco;
                                        //Numero
                                        rEndereco.Numero = fConsulta.rClifor.lEndereco[0].Numero;
                                        //Complemento
                                        rEndereco.Ds_complemento = fConsulta.rClifor.lEndereco[0].Ds_complemento;
                                        //Bairro
                                        rEndereco.Bairro = fConsulta.rClifor.lEndereco[0].Bairro;
                                        //Codigo Cidade
                                        if (!string.IsNullOrEmpty(fConsulta.rClifor.lEndereco[0].Cd_cidade))
                                        {
                                            rEndereco.Cd_cidade = fConsulta.rClifor.lEndereco[0].Cd_cidade;
                                            rEndereco.DS_Cidade = fConsulta.rClifor.lEndereco[0].DS_Cidade;
                                        }
                                        //CEP
                                        rEndereco.Cep = fConsulta.rClifor.lEndereco[0].Cep;
                                        //Inscricao Estadual
                                        rEndereco.Insc_estadual = fConsulta.rClifor.lEndereco[0].Insc_estadual;
                                        (bsClifor.Current as TRegistro_CadClifor).lEndereco.Add(rEndereco);
                                    }
                                }
                                bsClifor.ResetCurrentItem();
                            }
                    }
                else
                    MessageBox.Show("Não existe certificado valido instalado no computador.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else MessageBox.Show("Obrigatório configuração NF-e para realizar consulta.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void cd_veiculo_Leave(object sender, EventArgs e)
        {
            string vParam = "a.id_veiculo|=|'" + id_veiculo.Text.Trim() + "';";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { id_veiculo, ds_veiculo },
                                    new CamadaDados.Frota.Cadastros.TCD_CadVeiculo());
        }

        private void bb_veiculo_Click(object sender, EventArgs e)
        {
            string vColunas = "a.id_veiculo|Codigo|80;" +
                              "a.placa|Placa|60;" +
                              "a.ds_veiculo|Veiculo|200";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { id_veiculo, ds_veiculo },
                                    new CamadaDados.Frota.Cadastros.TCD_CadVeiculo(), string.Empty);
        }

        private void TFClifor_FormClosing(object sender, FormClosingEventArgs e)
        {
            ShapeGrid.SaveShape(this, gEndereco);
            ShapeGrid.SaveShape(this, gContato);
            ShapeGrid.SaveShape(this, gDados);
            ShapeGrid.SaveShape(this, gReferencia);
        }

        private void loginvendedor_Leave(object sender, EventArgs e)
        {
            string vParam = "a.login|=|'" + loginvendedor.Text.Trim() + "';" +
                            "a.tp_registro|=|'U'";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { loginvendedor },
                new CamadaDados.Diversos.TCD_CadUsuario());
        }

        private void bb_loginvendedor_Click(object sender, EventArgs e)
        {
            string vColunas = "a.login|Login|100;" +
                              "a.nome_usuario|Nome Usuario|200";
            string vParam = "a.Tp_Registro|=|'U'";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { loginvendedor },
                new CamadaDados.Diversos.TCD_CadUsuario(), vParam);
        }

        private void st_vendedor_CheckedChanged(object sender, EventArgs e)
        {
            lblLoginVendedor.Visible = st_vendedor.Checked;
            loginvendedor.Visible = st_vendedor.Checked;
            bb_loginvendedor.Visible = st_vendedor.Checked;
            lblLoginVendedor.Text = "Login Vendedor";
        }

        private void st_frentista_CheckedChanged(object sender, EventArgs e)
        {
            lbIdent_frentista.Visible = st_frentista.Checked;
            ident_frentista.Visible = st_frentista.Checked;
        }

        private void st_tecnico_CheckedChanged(object sender, EventArgs e)
        {
            loginvendedor.Visible = st_tecnico.Checked;
            lblLoginVendedor.Visible = st_tecnico.Checked;
            bb_loginvendedor.Visible = st_tecnico.Checked;
            lblLoginVendedor.Text = "Login Técnico";
        }

        private void st_operadorcx_CheckedChanged(object sender, EventArgs e)
        {
            loginvendedor.Visible = st_operadorcx.Checked;
            lblLoginVendedor.Visible = st_operadorcx.Checked;
            bb_loginvendedor.Visible = st_operadorcx.Checked;
            lblLoginVendedor.Text = "Login Operador Caixa";
        }

        private void bb_data_Click(object sender, EventArgs e)
        {
            using (TFDataAdicionais fData = new TFDataAdicionais())
            {
                fData.Cd_clifor = (bsClifor.Current as TRegistro_CadClifor).Cd_clifor;
                if (fData.ShowDialog() == DialogResult.OK)
                {
                    if (fData.lDataClifor.Count > 0)
                    {
                        fData.lDataClifor.ForEach(p =>
                        (bsClifor.Current as TRegistro_CadClifor).lDataClifor.Add(
                            new TRegistro_DataClifor()
                            {
                                Id_TpData = p.Id_TpData,
                                Tp_clifor = p.Tp_clifor,
                                Data = p.Data
                            }));
                    }
                    if (fData.lDataCliforDel.Count > 0)
                    {
                        fData.lDataCliforDel.ForEach(p =>
                          (bsClifor.Current as TRegistro_CadClifor).lDataCliforDel.Add(
                              new TRegistro_DataClifor()
                              {
                                  Cd_clifor = p.Cd_clifor,
                                  Id_TpData = p.Id_TpData,
                                  Tp_clifor = p.Tp_clifor,
                                  Data = p.Data
                              }));
                    }
                    bsClifor.ResetCurrentItem();
                }
            }
        }

        private void bb_historicorec_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_historico|Histórico Recebimento|200;" +
                              "a.cd_historico|Código|60";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_historicorec, ds_historicorec },
                new TCD_CadHistorico(), "a.tp_mov|=|'R'");
        }

        private void cd_historicorec_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("a.cd_historico|=|'" + cd_historicorec.Text.Trim() + "';a.tp_mov|=|'R'",
                new Componentes.EditDefault[] { cd_historicorec, ds_historicorec }, new TCD_CadHistorico());
        }

        private void bb_historicopag_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_historico|Histórico Pagamento|200;" +
                              "a.cd_historico|Código|60";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_historicopag, ds_historicopag },
                new TCD_CadHistorico(), "a.tp_mov|=|'P'");
        }

        private void cd_historicopag_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("a.cd_historico|=|'" + cd_historicopag.Text.Trim() + "';a.tp_mov|=|'P'",
                new Componentes.EditDefault[] { cd_historicopag, ds_historicopag }, new TCD_CadHistorico());
        }

        private void bb_gerarhist_Click(object sender, EventArgs e)
        {
            if (bsClifor.Current != null)
            {
                if (string.IsNullOrEmpty(cd_historicorec.Text))
                    try
                    {
                        cd_historicorec.Text =
                            TCN_CadHistorico.Gravar(new TRegistro_CadHistorico()
                            {
                                Ds_historico = "RECTO " + NM_Clifor.Text.Trim(),
                                Tp_mov = "R"
                            }, null);
                        ds_historicorec.Text = "RECTO " + NM_Clifor.Text.Trim();
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                if (string.IsNullOrEmpty(cd_historicopag.Text))
                    try
                    {
                        cd_historicopag.Text =
                        TCN_CadHistorico.Gravar(new TRegistro_CadHistorico()
                        {
                            Ds_historico = "PAGTO " + NM_Clifor.Text.Trim(),
                            Tp_mov = "P"
                        }, null);
                        ds_historicopag.Text = "PAGTO " + NM_Clifor.Text.Trim();
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void bbAddPessoa_Click(object sender, EventArgs e)
        {
            InserirPessoa();
        }

        private void bbAltPessoa_Click(object sender, EventArgs e)
        {
            AlterarPessoa();
        }

        private void bbExcluiPessoa_Click(object sender, EventArgs e)
        {
            ExcluirPessoa();
        }

        private void bb_NovoAnexo_Click(object sender, EventArgs e)
        {
            InserirAnexo();
        }

        private void bb_ExcluirAnexo_Click(object sender, EventArgs e)
        {
            ExcluirAnexo();
        }

        private void gPessoas_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null)
                if (e.ColumnIndex == 0)
                {
                    if (e.Value.ToString().Trim().ToUpper().Equals("CANCELADO"))
                        gPessoas.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Red;
                    else
                        gPessoas.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
                }
        }

        private void fonetrab_TextChanged(object sender, EventArgs e)
        {
            if (fonetrab.Text.SoNumero().Length.Equals(10))
            {
                fonetrab.Text = "(" + fonetrab.Text.SoNumero().Substring(0, 2) + ")" + fonetrab.Text.SoNumero().Substring(2, 4) + "-" + fonetrab.Text.SoNumero().Substring(6, 4);
                fonetrab.SelectionStart = fonetrab.Text.Length;
            }
            else if (fonetrab.Text.SoNumero().Length.Equals(11))
                if (fonetrab.Text.SoNumero().Substring(0, 1).Equals("0"))
                {
                    fonetrab.Text = "(" + fonetrab.Text.SoNumero().Substring(0, 3) + ")" + fonetrab.Text.SoNumero().Substring(3, 4) + "-" + fonetrab.Text.SoNumero().Substring(7, 4);
                    fonetrab.SelectionStart = fonetrab.Text.Length;
                }
                else
                {
                    fonetrab.Text = "(" + fonetrab.Text.SoNumero().Substring(0, 2) + ")" + fonetrab.Text.SoNumero().Substring(2, 5) + "-" + fonetrab.Text.SoNumero().Substring(7, 4);
                    fonetrab.SelectionStart = fonetrab.Text.Length;
                }
            else if (fonetrab.Text.SoNumero().Length.Equals(12))
            {
                fonetrab.Text = "(" + fonetrab.Text.SoNumero().Substring(0, 3) + ")" + fonetrab.Text.SoNumero().Substring(3, 5) + "-" + fonetrab.Text.SoNumero().Substring(8, 4);
                fonetrab.SelectionStart = fonetrab.Text.Length;
            }
        }

        private void tp_residencia_SelectedIndexChanged(object sender, EventArgs e)
        {
            vl_aluguel.Enabled = tp_residencia.SelectedIndex.Equals(1);
        }

        private void vl_aluguel_EnabledChanged(object sender, EventArgs e)
        {
            if (!vl_aluguel.Enabled)
                vl_aluguel.Value = decimal.Zero;
        }

        private void estadocivil_SelectedIndexChanged(object sender, EventArgs e)
        {
            RG_Dados_Conjuge.Enabled = estadocivil.SelectedIndex.Equals(1);
        }

        private void RG_Dados_Conjuge_EnabledChanged(object sender, EventArgs e)
        {
            if (!RG_Dados_Conjuge.Enabled)
            {
                NM_CONJUGE.Clear();
                DT_NascConjuge.Clear();
                CPF_CONJUGE.Clear();
                editDefault1.Clear();
                OrgaoEspConj.Clear();
                Ds_localTrabConj.Clear();
                nm_cargoconj.Clear();
                emailconj.Clear();
                Vl_rendaConj.Value = decimal.Zero;
            }
        }

        private void gAnexo_DoubleClick(object sender, EventArgs e)
        {

        }

        private void bbAddTabPreco_Click(object sender, EventArgs e)
        {
            InserirTabPreco();
        }

        private void bbDelTabPreco_Click(object sender, EventArgs e)
        {
            ExcluirTabPreco();
        }



        private void bbCapturar_Click(object sender, EventArgs e)
        {
            capturarImagem();
        }

        private void bbBuscarImagem_Click(object sender, EventArgs e)
        {
            try
            {
                if (bsClifor.Current != null)
                {
                    OpenFileDialog ofd = new OpenFileDialog();
                    ofd.Filter = "IMAGENS|*.jpg";
                    if (ofd.ShowDialog() == DialogResult.OK)
                        if (System.IO.File.Exists(ofd.FileName))
                        {
                            (bsClifor.Current as TRegistro_CadClifor).Imagem = Image.FromFile(ofd.FileName);
                            bsClifor.ResetCurrentItem();
                        }
                }
            }
            catch (Exception ex)
            { MessageBox.Show("Erro localizar imagem: " + ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void bb_excluirImagem_Click(object sender, EventArgs e)
        {
            pImagens.Image = null;
            (bsClifor.Current as TRegistro_CadClifor).Imagem = null;
            (bsClifor.Current as TRegistro_CadClifor).Img = null;
            bsClifor.ResetCurrentItem();

        }

        private void cd_indicador_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_clifor|=|'" + cd_indicador.Text.Trim() + "';" +
                            "isnull(a.ST_Funcionarios, 'N')|=|'S'";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_indicador, nm_indicador },
                                    new TCD_CadClifor());
        }

        private void bb_indicador_Click(object sender, EventArgs e)
        {
            string vColunas = "a.nm_clifor|Indicador|200;" +
                              "a.cd_clifor|Código|80";
            string vParam = "isnull(a.ST_Funcionarios, 'N')|=|'S'";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_indicador, nm_indicador },
                new TCD_CadClifor(),
               vParam);
        }

        private void bbCidade_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_cidade|Cidade|200;" +
                              "a.cd_cidade|Código|60;" +
                              "b.uf|UF|30";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_cidadenasc, ds_cidadenasc, ufNasc },
                new TCD_CadCidade(), string.Empty);
        }

        private void cd_cidadenasc_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_cidade|=|'" + cd_cidadenasc.Text.Trim() + "'";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_cidadenasc, ds_cidadenasc, ufNasc }, new TCD_CadCidade());
        }
    }
}
