using System;
using System.Collections;
using System.Data;
using System.Windows.Forms;
using CamadaNegocio.Financeiro.Titulo;
using CamadaDados.Financeiro.Titulo;
using Utils;
using FormBusca;

namespace Financeiro
{
    public partial class TFLanTitulo : Form
    {
        private decimal vl_corrente = decimal.Zero;

        public TTpModo tpModo;

        public string Cd_empresa = string.Empty;
        public string Tp_titulo = string.Empty;
        public string Cd_portador = string.Empty;
        public string Ds_portador = string.Empty;
        public string Cd_contager = string.Empty;
        public string Ds_contager = string.Empty;
        public decimal Vl_titulo = decimal.Zero;
        public string Cd_clifor = string.Empty;
        public string Nomeclifor = string.Empty;
        public string Nr_cgccpf = string.Empty;
        public string pFone = string.Empty;
        public string pNm_clifor_nominal = string.Empty;
        public string Cd_historico = string.Empty;
        public string Ds_historico = string.Empty;
        public string Observacao = string.Empty;
        public string Cd_banco = string.Empty;
        public string Ds_banco = string.Empty;
        public string Nr_cheque = string.Empty;
        public DateTime? Dt_emissao = null;
        public DateTime? Dt_vencto = null;
        public decimal pVl_saldo = decimal.Zero;
        public decimal? Nr_chequeLista = null;
        public decimal pIndexCheque = decimal.Zero;

        public bool St_bloquearTroco
        { get; set; }

        public TFLanTitulo()
        {
            InitializeComponent();
            tpModo = TTpModo.tm_Standby;
            ArrayList cbx1 = new ArrayList();
            cbx1.Add(new TDataCombo("PAGAR", "P"));
            cbx1.Add(new TDataCombo("RECEBER", "R"));
            tp_titulo.DataSource = cbx1;
            tp_titulo.DisplayMember = "Display";
            tp_titulo.ValueMember = "Value";
        }

        private void afterGrava()
        {
            if (vl_titulo.Focused)
                vl_titulo_Leave(this, new EventArgs());
            if (pDados.validarCampoObrigatorio() &&
                pValores.validarCampoObrigatorio() &&
                this.ValidarValorTitulo())
                this.DialogResult = DialogResult.OK;
        }

        private void preencherCampos()
        {
            BS_Titulo.AddNew();
            (BS_Titulo.Current as TRegistro_LanTitulo).Cd_empresa = Cd_empresa;
            (BS_Titulo.Current as TRegistro_LanTitulo).Tp_titulo = Tp_titulo;
            (BS_Titulo.Current as TRegistro_LanTitulo).Cd_portador = Cd_portador;
            (BS_Titulo.Current as TRegistro_LanTitulo).Ds_portador = Ds_portador;

            (BS_Titulo.Current as TRegistro_LanTitulo).Cd_contager = Cd_contager;
            (BS_Titulo.Current as TRegistro_LanTitulo).Nm_contager = Ds_contager;
            (BS_Titulo.Current as TRegistro_LanTitulo).Nomeclifor = Nomeclifor;
            (BS_Titulo.Current as TRegistro_LanTitulo).Nr_cgccpf = Nr_cgccpf;
            (BS_Titulo.Current as TRegistro_LanTitulo).Fone = pFone;
            (BS_Titulo.Current as TRegistro_LanTitulo).Cd_historico = Cd_historico;
            (BS_Titulo.Current as TRegistro_LanTitulo).Ds_historico = Ds_historico;
            (BS_Titulo.Current as TRegistro_LanTitulo).Observacao = Observacao;
            (BS_Titulo.Current as TRegistro_LanTitulo).Cd_banco = Cd_banco;
            (BS_Titulo.Current as TRegistro_LanTitulo).Ds_banco = Ds_banco;
            (BS_Titulo.Current as TRegistro_LanTitulo).Nr_cheque = Nr_cheque;
            (BS_Titulo.Current as TRegistro_LanTitulo).Dt_emissao = Dt_emissao == null ? DateTime.Now.Date : Dt_emissao;
            (BS_Titulo.Current as TRegistro_LanTitulo).Dt_vencto = Dt_vencto == null ? DateTime.Now.Date : Dt_vencto;
            (BS_Titulo.Current as TRegistro_LanTitulo).Vl_titulo = Vl_titulo;
            (BS_Titulo.Current as TRegistro_LanTitulo).Nm_clifor_nominal = Tp_titulo.Trim().ToUpper().Equals("P") ? pNm_clifor_nominal : string.Empty;
            CD_Clifor.Text = Cd_clifor;
            CD_Clifor_Leave(this, new EventArgs());
            //Se existir contager, buscar codigo do banco
            if (Cd_contager.Trim() != string.Empty)
            {
                CamadaDados.Financeiro.Cadastros.TList_CadBanco lBanco = new CamadaDados.Financeiro.Cadastros.TCD_CadBanco().Select(new TpBusca[]
                {
                    new TpBusca()
                    {
                        vNM_Campo = string.Empty,
                        vOperador = "exists",
                        vVL_Busca = "(select 1 from tb_fin_contager x "+
                                    "where x.cd_banco = a.cd_banco "+
                                    "and x.cd_contager = '" + Cd_contager.Trim() + "')"
                    }
                }, 1, string.Empty);
                if (lBanco.Count > 0)
                {
                    cd_banco.Text = lBanco[0].Cd_banco;
                    ds_banco.Text = lBanco[0].Ds_banco;
                }
            }
            //Buscar portador
            if (string.IsNullOrEmpty(Cd_portador))
            {
                CamadaDados.Financeiro.Cadastros.TList_CadPortador lPortador =
                    CamadaNegocio.Financeiro.Cadastros.TCN_CadPortador.Buscar(string.Empty,
                                                                              string.Empty,
                                                                              0,
                                                                              0,
                                                                              true,
                                                                              false,
                                                                              string.Empty,
                                                                              1,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              null);
                if (lPortador.Count > 0)
                {
                    CD_Portador.Text = lPortador[0].Cd_portador;
                    DS_Portador.Text = lPortador[0].Ds_portador;
                }
            }
            BS_Titulo.ResetCurrentItem();
        }

        private void GerarNumeroCheque()
        {
            if(BS_Titulo.Current != null)
                if ((BS_Titulo.Current as TRegistro_LanTitulo).Tp_titulo.Trim().ToUpper().Equals("P") &&
                    (!string.IsNullOrEmpty((BS_Titulo.Current as TRegistro_LanTitulo).Cd_contager.Trim())))
                {
                    if (!this.Nr_chequeLista.HasValue)
                    {
                        object obj = new CamadaDados.Financeiro.Cadastros.TCD_CadContaGer().BuscarEscalar(
                            new TpBusca[]
                        {
                            new TpBusca()
                            {
                                vNM_Campo = "a.cd_contager",
                                vOperador = "=",
                                vVL_Busca = "'" + (BS_Titulo.Current as TRegistro_LanTitulo).Cd_contager.Trim() + "'"
                            }
                        }, "a.nr_cheque_seq");
                        if (obj != null)
                            try
                            {
                                nr_cheque.Text = (Convert.ToDecimal(obj.ToString()) + 1 + pIndexCheque).ToString();
                            }
                            catch
                            { }
                    }
                    else
                        nr_cheque.Text = (Nr_chequeLista.Value + 1).ToString();
                }
        }

        private bool ValidarValorTitulo()
        {
            bool retorno = true;
            if ((pVl_saldo > 0) &&
                (tp_titulo.SelectedValue.ToString().Trim().ToUpper().Equals("P") ||
                CamadaNegocio.ConfigGer.TCN_CadParamGer.BuscaVL_Bool("VL_CH_MAIORVLFINRECEBER", CD_Empresa.Text, null).Trim().ToUpper().Equals("N") ||
                this.St_bloquearTroco))
                if (pVl_saldo < vl_titulo.Value)
                {
                    MessageBox.Show("Valor do titulo não pode ser maior que o saldo para cheques emitidos.\r\nSaldo: " + pVl_saldo.ToString(new System.Globalization.CultureInfo("en-US", true)), "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    vl_titulo.Value = pVl_saldo;
                    vl_titulo.Focus();
                    retorno = false;
                }
            return retorno;
        }
       
        private void FLanTitulo_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            if (!string.IsNullOrEmpty(Utils.Parametros.pubCultura))
                Idioma.TIdioma.AjustaCultura(this);
            pDados.set_FormatZero();
            preencherCampos();
            CD_Conta.Enabled = string.IsNullOrEmpty(Cd_contager);
            BB_Conta.Enabled = string.IsNullOrEmpty(Cd_contager);
        }

        private void CD_Empresa_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.cd_empresa|=|'" + CD_Empresa.Text.Trim() + "';" +
                              "|exists|(select 1 from tb_div_usuario_x_empresa x " +
                              "where x.cd_empresa = a.cd_empresa " +
                              "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                              "(exists(select 1 from tb_div_usuario_x_grupos y " +
                              "         where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))";
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { CD_Empresa } , new CamadaDados.Diversos.TCD_CadEmpresa());
        }

        private void BB_Empresa_Click(object sender, EventArgs e)
        {
            string vParam = "|exists|(select 1 from tb_div_usuario_x_empresa x " +
                            "where x.cd_empresa = a.cd_empresa " +
                            "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                            "(exists(select 1 from tb_div_usuario_x_grupos y " +
                            "       where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))";
            UtilPesquisa.BTN_BUSCA("a.NM_Empresa|Nome Empresa|150;a.CD_EMPRESA|Código|80"
                , new Componentes.EditDefault[] { CD_Empresa } , new CamadaDados.Diversos.TCD_CadEmpresa(), vParam);
        }

        private void cd_banco_Leave(object sender, EventArgs e)
        {
            string vParam = "cd_banco|=|'" + cd_banco.Text.Trim() + "'";
            if (tp_titulo.SelectedValue == null ? false : tp_titulo.SelectedValue.ToString().Trim().ToUpper().Equals("P"))
                vParam += ";|exists|(select 1 from tb_fin_contager x " +
                          "         where x.cd_banco = a.cd_banco " +
                          (string.IsNullOrEmpty(CD_Conta.Text) ? ")" : "         and x.cd_contager = '" + CD_Conta.Text.Trim() + "')");
            UtilPesquisa.EDIT_LEAVE(vParam
                , new Componentes.EditDefault[] { cd_banco, ds_banco } , new CamadaDados.Financeiro.Cadastros.TCD_CadBanco());
            if (tp_titulo.SelectedValue == null ? false : tp_titulo.SelectedValue.ToString().Trim().ToUpper().Equals("P"))
            {
                object obj = new CamadaDados.Financeiro.Cadastros.TCD_CadContaGer().BuscarEscalar(
                                new TpBusca[]
                                {
                                    new TpBusca()
                                    {
                                        vNM_Campo = string.Empty,
                                        vOperador = "exists",
                                        vVL_Busca = "(select 1 from TB_FIN_Contager_X_Empresa x " +
                                                  "where a.cd_contager = x.cd_contager " +
                                                  "and x.cd_empresa = '" + CD_Empresa.Text + "')"
                                    },
                                    new TpBusca()
                                    {
                                        vNM_Campo = string.Empty,
                                        vOperador = "exists",
                                        vVL_Busca = "(select 1 from TB_DIV_Usuario_X_Contager x " +
                                                    "where a.cd_contager = x.cd_contager " +
                                                    "and x.login = '" + Utils.Parametros.pubLogin.Trim() + "')"
                                    },
                                    new TpBusca()
                                    {
                                        vNM_Campo = "a.cd_banco",
                                        vOperador = "=",
                                        vVL_Busca = "'" + cd_banco.Text.Trim() + "'"
                                    },
                                    new TpBusca()
                                    {
                                        vNM_Campo = "isnull(a.st_contacompensacao, 'N')",
                                        vOperador = "=",
                                        vVL_Busca = "'S'"
                                    }
                                }, "a.cd_contager");
                if (obj != null)
                    CD_Conta.Text = obj.ToString();
            }
        }

        private void BB_Banco_Click(object sender, EventArgs e)
        {
            string vParam = string.Empty;
            if (tp_titulo.SelectedValue == null ? false : tp_titulo.SelectedValue.ToString().Trim().ToUpper().Equals("P"))
                vParam = "|exists|(select 1 from tb_fin_contager x " +
                         "          where x.cd_banco = a.cd_banco " +
                         (string.IsNullOrEmpty(CD_Conta.Text) ? ")" : "          and x.cd_contager = '" + CD_Conta.Text.Trim() + "')");
            UtilPesquisa.BTN_BUSCA("DS_BANCO|Descrição|150;CD_BANCO|Código|80"
                , new Componentes.EditDefault[] { cd_banco, ds_banco } , new CamadaDados.Financeiro.Cadastros.TCD_CadBanco(), vParam);
            if ((tp_titulo.SelectedValue == null ? false : tp_titulo.SelectedValue.ToString().Trim().ToUpper().Equals("P")) &&
                string.IsNullOrEmpty(CD_Conta.Text))
            {
                object obj = new CamadaDados.Financeiro.Cadastros.TCD_CadContaGer().BuscarEscalar(
                                new TpBusca[]
                                {
                                    new TpBusca()
                                    {
                                        vNM_Campo = string.Empty,
                                        vOperador = "exists",
                                        vVL_Busca = "(select 1 from TB_FIN_Contager_X_Empresa x " +
                                                  "where a.cd_contager = x.cd_contager " +
                                                  "and x.cd_empresa = '" + CD_Empresa.Text + "')"
                                    },
                                    new TpBusca()
                                    {
                                        vNM_Campo = string.Empty,
                                        vOperador = "exists",
                                        vVL_Busca = "(select 1 from TB_DIV_Usuario_X_Contager x " +
                                                    "where a.cd_contager = x.cd_contager " +
                                                    "and x.login = '" + Utils.Parametros.pubLogin.Trim() + "')"
                                    },
                                    new TpBusca()
                                    {
                                        vNM_Campo = "a.cd_banco",
                                        vOperador = "=",
                                        vVL_Busca = "'" + cd_banco.Text.Trim() + "'"
                                    },
                                    new TpBusca()
                                    {
                                        vNM_Campo = "isnull(a.st_contacompensacao, 'N')",
                                        vOperador = "=",
                                        vVL_Busca = "'S'"
                                    }
                                }, "a.cd_contager");
                if (obj != null)
                    CD_Conta.Text = obj.ToString();
            }
        }

        public void CD_Clifor_Leave(object sender, EventArgs e)
        {
            DataRow linha = UtilPesquisa.EDIT_LeaveClifor("a.cd_clifor|=|'" + CD_Clifor.Text.Trim() + "'",
                            new Componentes.EditDefault[] { CD_Clifor, NM_Clifor },
                            new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
            if (linha != null)
                NR_CGCCPF.Text = linha["NR_CGC"].ToString().Trim() != string.Empty ? linha["NR_CGC"].ToString().Trim() : linha["NR_CPF"].ToString().Trim();
            linha = UtilPesquisa.EDIT_LEAVE("a.CD_clifor|=|'" + CD_Clifor.Text.Trim() + "'"
               , new Componentes.EditDefault[] { nFONE} , new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco());
            if (linha != null)
            { Fone.Text = linha["Fone"].ToString(); }

        }

        private void BB_Clifor_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { CD_Clifor, NM_Clifor }, string.Empty);
            CD_Clifor_Leave(sender, e);
        }

        private void CD_Portador_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("CD_Portador|=|'" + CD_Portador.Text + "';isNull(ST_ControleTitulo,'N')|=|'S'"
                , new Componentes.EditDefault[] { CD_Portador, DS_Portador }, new CamadaDados.Financeiro.Cadastros.TCD_CadPortador());
        }

        private void BB_Portador_Click(object sender, EventArgs e)
        {
            string vParamFixo = "isNull(ST_ControleTitulo,'N')|=|'S'";
            UtilPesquisa.BTN_BUSCA("DS_Portador|Descrição|150;CD_Portador|Código|80"
                , new Componentes.EditDefault[] { CD_Portador, DS_Portador }, new CamadaDados.Financeiro.Cadastros.TCD_CadPortador(), vParamFixo);
        }

        private void CD_Historico_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.cd_historico|=|'"+CD_Historico.Text + "';"+
                              "a.TP_Mov|=|'" + tp_titulo.SelectedValue.ToString().Trim() + "'";
            UtilPesquisa.EDIT_LEAVE(vColunas
               , new Componentes.EditDefault[] { CD_Historico, DS_Historico }, new CamadaDados.Financeiro.Cadastros.TCD_CadHistorico());
        }

        private void BB_Historico_Click(object sender, EventArgs e)
        {
            string vParamFixo = "a.TP_Mov|=|'" + tp_titulo.SelectedValue.ToString().Trim() + "'";
            UtilPesquisa.BTN_BUSCA("a.DS_Historico|Descrição|150;a.CD_Historico|Código|80"
                , new Componentes.EditDefault[] { CD_Historico, DS_Historico }, new CamadaDados.Financeiro.Cadastros.TCD_CadHistorico(), vParamFixo);
        }

        public void nr_lanctocheque_Leave(object sender, EventArgs e)
        {
            BS_Titulo.CancelEdit();
            BS_Titulo.DataSource = TCN_LanTitulo.Busca(CD_Empresa.Text, 
                                                       decimal.Zero, 
                                                       cd_banco.Text, 
                                                       nr_lanctocheque.Text, 
                                                       string.Empty,
                                                       string.Empty, 
                                                       string.Empty, 
                                                       string.Empty, 
                                                       string.Empty, 
                                                       string.Empty, 
                                                       decimal.Zero, 
                                                       decimal.Zero, 
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
                                                       false,
                                                       false,
                                                       false,
                                                       false,
                                                       string.Empty, 
                                                       string.Empty, 
                                                       string.Empty, 
                                                       string.Empty, 
                                                       string.Empty,
                                                       0, 
                                                       string.Empty, 
                                                       null);
        }

        public void CD_Conta_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.cd_contager|=|'" + CD_Conta.Text.Trim() + "';" +
                               "a.st_contacf|<>|0;" +
                              "|exists|(select 1 from TB_Fin_ContaGer_X_Empresa k " +
                              "where k.CD_ContaGer = a.CD_ContaGer " +
                              "and k.cd_Empresa = '" + CD_Empresa.Text.Trim() + "' );" +
                              "|exists|(select 1 from tb_div_usuario_x_contager x " +
                              "where x.cd_contager = a.cd_contager " +
                              "and x.login = '" + Utils.Parametros.pubLogin.Trim() + "')";
            if(tp_titulo.SelectedValue != null)
                if(tp_titulo.SelectedValue.ToString().Trim().ToUpper().Equals("P"))
                    vColunas += ";a.st_contacompensacao|=|'S';" +
                                "a.cd_banco|=|'" + cd_banco.Text.Trim() + "'";
            UtilPesquisa.EDIT_LEAVE(vColunas
                , new Componentes.EditDefault[] {CD_Conta , DS_ContaGer}, new CamadaDados.Financeiro.Cadastros.TCD_CadContaGer());
        }

        private void BB_Conta_Click(object sender, EventArgs e)
        {
            string vParam = "a.st_contacf|<>|0;" +
                            "|exists|(select 1 from TB_Fin_ContaGer_X_Empresa k " +
                            "where k.CD_ContaGer = a.CD_ContaGer " +
                            "and k.cd_Empresa = '" + CD_Empresa.Text.Trim() + "' );" +
                            "|exists|(select 1 from tb_div_usuario_x_contager x " +
                            "where x.cd_contager = a.cd_contager " +
                            "and x.login = '" + Utils.Parametros.pubLogin.Trim() + "')";
            if(tp_titulo.SelectedValue != null)
                if(tp_titulo.SelectedValue.ToString().Trim().ToUpper().Equals("P"))
                    vParam += ";a.ST_ContaCompensacao|=|'S';" +
                             "a.cd_banco|=|'" + cd_banco.Text.Trim() + "'";
            UtilPesquisa.BTN_BUSCA("a.DS_ContaGer|Descrição|150;a.CD_ContaGer|Código|80"
                , new Componentes.EditDefault[] { CD_Conta, DS_ContaGer }, new CamadaDados.Financeiro.Cadastros.TCD_CadContaGer(), vParam);

        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            this.afterGrava();
        }

        private void TFLanTitulo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void BB_Fechar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void vl_titulo_Enter(object sender, EventArgs e)
        {
            vl_corrente = vl_titulo.Value;
            vl_titulo.Select(0, vl_titulo.Value.ToString().Length - 1);
        }

        private void DT_Pgto_Enter(object sender, EventArgs e)
        {
            DT_Pgto.Select(0, DT_Pgto.Text.Length - 1);
        }

        private void DT_Vencto_Enter(object sender, EventArgs e)
        {
            DT_Vencto.Select(0, DT_Vencto.Text.Length - 1);
        }

        private void tp_titulo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tp_titulo.SelectedIndex == 0) // pagar
                DEVCRE.Text = "CREDOR:";
            else
                DEVCRE.Text = "DEVEDOR:";
            
        }

        private void bb_clifor_nominal_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { cd_clifor_nominal, nm_clifor_nominal }, string.Empty);
        }

        private void cd_clifor_nominal_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LeaveClifor("a.cd_clifor|=|'" + cd_clifor_nominal.Text.Trim() + "'",
                                            new Componentes.EditDefault[] { cd_clifor_nominal, nm_clifor_nominal },
                                            new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
        }

        private void DT_Vencto_Leave(object sender, EventArgs e)
        {
            if ((DT_Pgto.Text.Trim() != string.Empty) && (DT_Pgto.Text.Trim() != "/  /") &&
                (DT_Vencto.Text.Trim() != string.Empty) && (DT_Vencto.Text.Trim() != "/  /"))
                if (DT_Vencto.Data.Date < DT_Pgto.Data.Date)
                {
                    MessageBox.Show("Data de vencimento do cheque não pode ser menor que a data de emissão.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DT_Vencto.Focus();
                }
        }

        private void DT_Pgto_Leave(object sender, EventArgs e)
        {
            if ((DT_Pgto.Text.Trim() != string.Empty) && (DT_Pgto.Text.Trim() != "/  /") &&
                (DT_Vencto.Text.Trim() != string.Empty) && (DT_Vencto.Text.Trim() != "/  /"))
                if (DT_Pgto.Data.Date > DT_Vencto.Data.Date)
                {
                    MessageBox.Show("Data de emissão do cheque não pode ser maior que a data de pagamento.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DT_Pgto.Focus();
                }
        }

        private void vl_titulo_Leave(object sender, EventArgs e)
        {
            this.ValidarValorTitulo();
        }

        private void nr_cheque_Enter(object sender, EventArgs e)
        {
            this.GerarNumeroCheque();
        }

        private void Fone_TextChanged(object sender, EventArgs e)
        {
            if (Fone.Text.SoNumero().Length.Equals(10))
            {
                Fone.Text = "(" + Fone.Text.SoNumero().Substring(0, 2) + ")" + Fone.Text.SoNumero().Substring(2, 4) + "-" + Fone.Text.SoNumero().Substring(6, 4);
                Fone.SelectionStart = Fone.Text.Length;
            }
            else if (Fone.Text.SoNumero().Length.Equals(11))
                if (Fone.Text.SoNumero().Substring(0, 1).Equals("0"))
                {
                    Fone.Text = "(" + Fone.Text.SoNumero().Substring(0, 3) + ")" + Fone.Text.SoNumero().Substring(3, 4) + "-" + Fone.Text.SoNumero().Substring(7, 4);
                    Fone.SelectionStart = Fone.Text.Length;
                }
                else
                {
                    Fone.Text = "(" + Fone.Text.SoNumero().Substring(0, 2) + ")" + Fone.Text.SoNumero().Substring(2, 5) + "-" + Fone.Text.SoNumero().Substring(7, 4);
                    Fone.SelectionStart = Fone.Text.Length;
                }
            else if (Fone.Text.SoNumero().Length.Equals(12))
            {
                Fone.Text = "(" + Fone.Text.SoNumero().Substring(0, 3) + ")" + Fone.Text.SoNumero().Substring(3, 5) + "-" + Fone.Text.SoNumero().Substring(8, 4);
                Fone.SelectionStart = Fone.Text.Length;
            }
        }
    }
}