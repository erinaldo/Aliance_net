using System;
using System.Windows.Forms;
using Utils;
using CamadaDados.Restaurante.Cadastro;
using CamadaNegocio.Restaurante.Cadastro;
using CamadaDados.Restaurante;
using CamadaNegocio.Restaurante;
using System.Data;

namespace Restaurante
{
    public partial class TFAbrirCartao : Form
    {
        /// <summary>
        /// Para tpModo Standby, aplicação aguardando telefone
        /// Insert, aplicação em processo de abertura de cartão
        /// Busca, em processo de lançamento/abertura de cartão
        /// </summary>
        private Utils.TTpModo tpModo = TTpModo.tm_Standby;
        private string cd_clifor { get; set; } = string.Empty;
        private TList_CFG lcfg { get; set; } = new TList_CFG();

        public TFAbrirCartao()
        {
            InitializeComponent();
        }

        #region Métodos

        private void afternovo()
        {
            if (tpModo != TTpModo.tm_Standby) return;
            nr_cartao.Text = string.Empty;
            cbMenor.Checked = false;
            nome_clifor.Text = string.Empty;
            cd_clifor = string.Empty;
            tpModo = TTpModo.tm_busca;
            txtDados.Text = string.Empty;
            txtDados.Focus();
        }

        private void abrirCartao()
        {
            if (tpModo != TTpModo.tm_busca) return;
            if (!string.IsNullOrEmpty(nr_cartao.Text.ToString().Trim().SoNumero()) && !string.IsNullOrEmpty(txtDados.Text))
            {
                DataTable rClifor = new TCD_Clifor().Buscar(
                    new TpBusca[]
                    {
                            new TpBusca()
                            {
                                vNM_Campo = "a.cd_clifor",
                                vOperador = "=",
                                vVL_Busca = "'" + cd_clifor.ToString().Trim() + "'"
                            }
                    }, 1);
                if (rClifor.Rows.Count.Equals(0)) return;

                // busca cartao se estiver aberto
                TList_Cartao lCartao = new TCD_Cartao().Select(
                    new TpBusca[]
                    {
                            new TpBusca()
                            {
                                vNM_Campo = "a.nr_cartao",
                                vOperador = "=",
                                vVL_Busca = "'" + nr_cartao.Text.ToString().Trim().SoNumero() + "'"
                            },
                            new TpBusca()
                            {
                                vNM_Campo = "a.st_registro",
                                vOperador = "=",
                                vVL_Busca = "'A'"
                            }
                    }, 1, string.Empty, string.Empty);
                if (lCartao.Count > 0)
                {
                    MessageBox.Show("Erro: O número " + nr_cartao.Text.ToString().Trim().SoNumero() + " de cartão consta como aberto!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    nr_cartao.Text = "";
                    nr_cartao.Focus();
                    return;
                }
                else if (lcfg[0].bool_mesacartao || lcfg[0].Tp_cartao.Equals("0"))
                {
                    // abre um novo cartao rotativo
                    TRegistro_Cartao rcartao = new TRegistro_Cartao();
                    rcartao.nr_cartao = nr_cartao.Text.ToString().Trim().SoNumero();
                    rcartao.Dt_abertura = CamadaDados.UtilData.Data_Servidor();
                    rcartao.St_registro = "A";
                    rcartao.vl_limitecartao = decimal.Zero;
                    rcartao.st_menor = cbMenor.Checked;
                    rcartao.Cd_empresa = lcfg[0].cd_empresa;
                    rcartao.Cd_Clifor = rClifor.Rows[0].ItemArray[1].ToString().Trim();
                    rcartao.Nm_Clifor = nome_clifor.Text;
                    TRegistro_PreVenda pre = new TRegistro_PreVenda();
                    pre.Dt_venda = CamadaDados.UtilData.Data_Servidor();
                    rcartao.lPreVenda.Add(pre);
                    TCN_Cartao.Gravar(rcartao, null);
                    MessageBox.Show("O cartão de número: " + nr_cartao.Text.ToString().Trim().SoNumero() + "  foi aberto com sucesso!", "Mensagem", MessageBoxButtons.OK);
                }
                else if (lCartao.Count.Equals(0))
                {
                    TList_Cartao cartaonovo = new TCD_Cartao().Select(
                        new TpBusca[]
                        {
                                new TpBusca()
                                {
                                    vNM_Campo = "a.nr_cartao",
                                    vOperador = "=",
                                    vVL_Busca = nr_cartao.Text.ToString().Trim().SoNumero()
                                }
                        }, 1, string.Empty, string.Empty);
                    // abre um novo cartao
                    if (cartaonovo.Count > 0)
                    {
                        TRegistro_Cartao rcartao = new TRegistro_Cartao();
                        rcartao.nr_cartao = nr_cartao.Text.ToString().Trim().SoNumero();
                        rcartao.Dt_abertura = DateTime.Now;
                        rcartao.St_registro = "A";
                        rcartao.Cd_Clifor = cartaonovo[0].Cd_Clifor;
                        rcartao.vl_limitecartao = cartaonovo[0].vl_limitecartao;
                        rcartao.status_menor = cartaonovo[0].status_menor;
                        rcartao.Cd_empresa = lcfg[0].cd_empresa;
                        rcartao.Cd_Clifor = rClifor.Rows[0].ItemArray[1].ToString().Trim();
                        rcartao.Nm_Clifor = nome_clifor.Text;
                        TRegistro_PreVenda pre = new TRegistro_PreVenda();
                        rcartao.lPreVenda.Add(pre);
                        TCN_Cartao.Gravar(rcartao, null);
                    }
                }
            }
            else
                MessageBox.Show("Informe o número do cartão!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);

            tpModo = TTpModo.tm_Standby;
            afternovo();
        }

        private void validaCartao()
        {
            if (tpModo != TTpModo.tm_busca) return;

            if (!string.IsNullOrEmpty(nr_cartao.Text.ToString().Trim().SoNumero()))
            {
                if (lcfg[0].Tp_cartao.Equals("0") && lcfg[0].nr_cartaorotini > Convert.ToDecimal(nr_cartao.Text.ToString().Trim().SoNumero()))
                {
                    MessageBox.Show("N° Cartão (" + lcfg[0].nr_cartaorotini + ") é o mínimo da faixa de cartão rotativo!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    return;
                }
                else if (lcfg[0].Tp_cartao.Equals("0") && lcfg[0].nr_cartaorotfin < Convert.ToDecimal(nr_cartao.Text.ToString().Trim().SoNumero()))
                {
                    MessageBox.Show("N° Cartão (" + lcfg[0].nr_cartaorotfin + ") é o máximo da faixa de cartão rotativo!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    return;
                }
                else if ((lcfg[0].Tp_cartao.Equals("0") || lcfg[0].bool_mesacartao) && lcfg[0].nr_cartaorotini > Convert.ToDecimal(nr_cartao.Text.ToString().Trim().SoNumero()))
                {
                    MessageBox.Show("N° Cartão (" + lcfg[0].nr_cartaorotini + ") é o mínimo da faixa de cartão rotativo!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    return;
                }
                else if ((lcfg[0].Tp_cartao.Equals("0") || lcfg[0].bool_mesacartao) && lcfg[0].nr_cartaorotfin < Convert.ToDecimal(nr_cartao.Text.ToString().Trim().SoNumero()))
                {
                    MessageBox.Show("N° Cartão (" + lcfg[0].nr_cartaorotfin + ") é o máximo da faixa de cartão rotativo!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    return;
                }
                else if (!lcfg[0].Tp_cartao.Equals("0"))
                {
                    //verifica se existe cartao cadastrado
                    object cartao_nm = new TCD_Cartao().BuscarEscalar(
                        new TpBusca[]
                        {
                        new TpBusca()
                        {
                            vNM_Campo = "a.nr_cartao",
                            vOperador = "=",
                            vVL_Busca = nr_cartao.Text.ToString().Trim().SoNumero()
                        }
                        }, "a.nr_cartao");
                    if (cartao_nm == null)
                    {
                        MessageBox.Show("Não existe cartão N° " + nr_cartao.Text.ToString().Trim().SoNumero() + " cadastrado!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                        nr_cartao.Text = string.Empty;
                        return;
                    }
                }
                abrirCartao();
            }
        }

        private void cliforDetalhado()
        {
            using (Cadastro.TFCliforDetalhado fClifor = new Cadastro.TFCliforDetalhado())
            {
                if (!string.IsNullOrEmpty(cd_clifor))
                {
                    TpBusca[] tpBuscas = new TpBusca[0];
                    Estruturas.CriarParametro(ref tpBuscas, "a.cd_clifor", cd_clifor.ToString());
                    fClifor.rClifor = new TCD_Clifor().Select(tpBuscas, 1, string.Empty)[0];
                }

                if (fClifor.ShowDialog() == DialogResult.OK)
                {
                    txtDados.Text = fClifor.rClifor.celular;
                    nome_clifor.Text = fClifor.rClifor.Nm_clifor;
                    cd_clifor = fClifor.rClifor.Cd_clifor;
                    tpModo = TTpModo.tm_busca;
                    nr_cartao.Focus();
                }
            }
        }

        private void buscarClifor()
        {
            if (tpModo != TTpModo.tm_Insert) return;
            if (string.IsNullOrEmpty(txtDados.Text)) return;

            TpBusca[] tps = new TpBusca[0];
            Estruturas.CriarParametro(ref tps, "a.celular", "'%" + txtDados.Text.Trim().SoNumero() + "'", "like");
            TList_Clifor rClifor = new TCD_Clifor().Select(tps, 0, string.Empty);

            //Cliente não existe (método: novoClifor)
            if (rClifor.Count.Equals(0)) { nome_clifor.Focus(); return; }

            //Vários clientes com o mesmo número de telefone
            if (rClifor.Count > 1)
            {
                if (tpModo == TTpModo.tm_Insert)
                    using (TFConsultaClifor fconsulta = new TFConsultaClifor())
                    {
                        fconsulta.nome = txtDados.Text.Trim().SoNumero();
                        if (fconsulta.ShowDialog() == DialogResult.OK)
                        {
                            txtDados.Text = fconsulta.rClifor.celular;
                            nome_clifor.Text = fconsulta.rClifor.Nm_clifor;
                            cd_clifor = fconsulta.rClifor.Cd_clifor;
                            tpModo = TTpModo.tm_busca;
                        }
                        else
                        {
                            tpModo = TTpModo.tm_Standby;
                            afternovo();
                        }
                    }
            }
            else
            {
                nome_clifor.Text = rClifor[0].Nm_clifor;
                cd_clifor = rClifor[0].Cd_clifor;
                tpModo = TTpModo.tm_busca;
            }

            //Validar necessidade de atualizar o cadastro do clifor
            tps = new TpBusca[0];
            Estruturas.CriarParametro(ref tps, "a.ds_parametro", "'DIAS_RENOVACAO_CADASTRO_CLIFOR'");
            object vlNumerico = new CamadaDados.ConfigGer.TCD_ParamGer().BuscarEscalar(tps, "a.vl_numerico");
            if (vlNumerico != null && !string.IsNullOrEmpty(vlNumerico.ToString()))
            {
                //Buscar data de alteração do cadastro do clifor
                tps = new TpBusca[0];
                Estruturas.CriarParametro(ref tps, "a.cd_clifor", rClifor[0].Cd_clifor);
                object dtAlt = new CamadaDados.Financeiro.Cadastros.TCD_CadClifor().BuscarEscalar(tps, "a.dt_alt");
                if (dtAlt != null && !string.IsNullOrEmpty(vlNumerico.ToString()))
                {
                    try
                    {
                        //Validar diferenca das datas
                        double dif = CamadaDados.UtilData.Data_Servidor().Subtract(Convert.ToDateTime(dtAlt)).TotalDays;
                        if (dif > Convert.ToDouble(vlNumerico))
                            atualizarCadastroClifor(rClifor[0]);
                    }
                    catch { }
                }
            }
        }

        private void atualizarCadastroClifor(TRegistro_Clifor registro_Clifor)
        {
            using (Cadastro.TFCliforDetalhado cliforDetalhado = new Cadastro.TFCliforDetalhado())
            {
                cliforDetalhado.rClifor = registro_Clifor;
                if (cliforDetalhado.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        TCN_CliFor.Gravar(cliforDetalhado.rClifor, null);
                        MessageBox.Show("Cliente atualizado com sucesso.", "Informativo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
            }
        }

        private void novoClifor()
        {
            if (tpModo != TTpModo.tm_Insert) return;

            //Cliente não cadastrado
            if (!string.IsNullOrEmpty(txtDados.Text) && !string.IsNullOrEmpty(nome_clifor.Text))
            {
                cd_clifor = TCN_CliFor.Gravar(
                    new TRegistro_Clifor()
                    {
                        celular = txtDados.Text.Trim().SoNumero(),
                        Nm_clifor = nome_clifor.Text.Trim().ToUpper()
                    }, null);
                tpModo = TTpModo.tm_busca;
            }
            else if (!string.IsNullOrEmpty(nome_clifor.Text))
            {
                using (TFConsultaClifor fconsulta = new TFConsultaClifor())
                {
                    fconsulta.nome = nome_clifor.Text.Trim();
                    if (fconsulta.ShowDialog() == DialogResult.OK)
                    {
                        txtDados.Text = fconsulta.rClifor.celular;
                        nome_clifor.Text = fconsulta.rClifor.Nm_clifor;
                        cd_clifor = fconsulta.rClifor.Cd_clifor;
                        tpModo = TTpModo.tm_busca;
                    }
                    else
                    {
                        tpModo = TTpModo.tm_Standby;
                        afternovo();
                    }
                }
            }
        }

        private void statusCartao()
        {
            using (TFLanMovBoliche fMov = new TFLanMovBoliche())
            {
                fMov.lblTitul = "Status Cartão";
                fMov.formUniver = true;
                if (fMov.ShowDialog() == DialogResult.OK)
                    validaStatusCartao(fMov.Nr_cartao);
            }
        }

        private void validaStatusCartao(string ncartao)
        {
            if (lcfg[0].Tp_cartao.Equals("0") && lcfg[0].nr_cartaorotini > Convert.ToDecimal(ncartao))
            {
                MessageBox.Show("N° Cartão (" + lcfg[0].nr_cartaorotini + ") é o mínimo da faixa de cartão rotativo!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
            else if (lcfg[0].Tp_cartao.Equals("0") && lcfg[0].nr_cartaorotfin < Convert.ToDecimal(ncartao))
            {
                MessageBox.Show("N° Cartão (" + lcfg[0].nr_cartaorotfin + ") é o máximo da faixa de cartão rotativo!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
            else if ((lcfg[0].Tp_cartao.Equals("0") || lcfg[0].bool_mesacartao) && lcfg[0].nr_cartaorotini > Convert.ToDecimal(ncartao))
            {
                MessageBox.Show("N° Cartão (" + lcfg[0].nr_cartaorotini + ") é o mínimo da faixa de cartão rotativo!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
            else if ((lcfg[0].Tp_cartao.Equals("0") || lcfg[0].bool_mesacartao) && lcfg[0].nr_cartaorotfin < Convert.ToDecimal(ncartao))
            {
                MessageBox.Show("N° Cartão (" + lcfg[0].nr_cartaorotfin + ") é o máximo da faixa de cartão rotativo!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
            else if (!lcfg[0].Tp_cartao.Equals("0"))
            {
                //verifica se existe cartao cadastrado
                object cartao_nm = new TCD_Cartao().BuscarEscalar(
                    new TpBusca[]
                    {
                        new TpBusca()
                        {
                            vNM_Campo = "a.nr_cartao",
                            vOperador = "=",
                            vVL_Busca = ncartao
                        }
                    }, "a.nr_cartao");
                if (cartao_nm == null)
                {
                    MessageBox.Show("Não existe cartão N° " + ncartao + " cadastrado!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                }
            }
            else if (lcfg[0].Tp_cartao.Equals("0"))
            {
                DataTable rCartao = new TCD_Cartao().Buscar(
                    new TpBusca[]
                    {
                        new TpBusca()
                        {
                            vNM_Campo = "a.nr_cartao",
                            vOperador = "=",
                            vVL_Busca = "'" + ncartao + "'"
                        },
                        new TpBusca()
                        {
                            vNM_Campo = "a.st_registro",
                            vOperador = "=",
                            vVL_Busca = "'A'"
                        }
                    }, 1);
                if (rCartao != null && rCartao.Rows.Count > 0)
                {
                    //Buscar movimentação boliche em aberto
                    DataTable rMov = new TCD_MovBoliche().Buscar(
                        new TpBusca[]
                        {
                            new TpBusca()
                            {
                                vNM_Campo = "a.id_cartao",
                                vOperador = "=",
                                vVL_Busca = "'" + rCartao.Rows[0].ItemArray[3] + "'"
                            },
                            new TpBusca()
                            {
                                vNM_Campo = "a.DT_Fechamento",
                                vOperador = "",
                                vVL_Busca = "is null"
                            }
                        }, 1);
                    if (rMov.Rows.Count > 0)
                    {
                        MessageBox.Show("Cartão possui movimentação de serviços em aberto, favor dirigir-se ao caixa.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    };

                    //Buscar se cartão possui itens
                    if (rCartao.Rows[0].ItemArray[13] == null || string.IsNullOrEmpty(rCartao.Rows[0].ItemArray[13].ToString()) &&
                        (rCartao.Rows[0].ItemArray[10].Equals("A")))
                    {
                        if (MessageBox.Show("Cliente não consumiu nenhum item. Confirma o fechamento do cartão?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.No)
                            return;
                        TCN_Cartao.Gravar(new TRegistro_Cartao() {Cd_empresa = rCartao.Rows[0].ItemArray[1].ToString(), id_cartao = decimal.Parse(rCartao.Rows[0].ItemArray[3].ToString()), St_registro = "F" }, null);
                    }
                    else MessageBox.Show("O cartão de N° " + ncartao + " está ABERTO! Possui saldo em aberto, favor dirigir-se ao caixa.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else MessageBox.Show("O cartão de N° " + ncartao + " está LIBERADO!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        #endregion

        #region Eventos

        private void FAbrirCartao_Load(object sender, EventArgs e)
        {
            panelDados4.set_FormatZero();

            lcfg = TCN_CFG.Buscar(string.Empty, null);
            if (lcfg.Count.Equals(0)) { MessageBox.Show("Não existe configuração de restaurante.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
            Icon = Utils.ResourcesUtils.TecnoAliance_ICO;

            lblOperador.Text = Utils.Parametros.pubLogin;
            //Buscar dados PDV
            CamadaDados.Faturamento.Cadastros.TList_PontoVenda lPdv = CamadaNegocio.Faturamento.Cadastros.TCN_PontoVenda.Buscar(string.Empty,
                                                                             string.Empty,
                                                                             Utils.Parametros.pubTerminal,
                                                                             string.Empty,
                                                                             null);
            if (lPdv.Count > 0)
                lvlPdv.Text = lPdv[0].Ds_pdv;

            txtDados.Focus();
        }

        private void FAbrirCartao_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                validaCartao();
            else if (e.KeyCode.Equals(Keys.F8))
                cliforDetalhado();
            else if (e.KeyCode.Equals(Keys.Escape))
            {
                tpModo = TTpModo.tm_Standby;
                afternovo();
            }
            else if (e.KeyCode.Equals(Keys.F1))
                statusCartao();
        }

        private void txtDados_TextChanged(object sender, EventArgs e)
        {
            tpModo = TTpModo.tm_Standby;
            nome_clifor.Text = "";
            nr_cartao.Text = "";

            if (txtDados.Text.SoNumero().Length.Equals(10))
            {
                txtDados.Text = "(" + txtDados.Text.SoNumero().Substring(0, 2) + ")" + txtDados.Text.SoNumero().Substring(2, 4) + "-" + txtDados.Text.SoNumero().Substring(6, 4);
                txtDados.SelectionStart = txtDados.Text.Length;
            }
            else if (txtDados.Text.SoNumero().Length.Equals(11))
                if (txtDados.Text.SoNumero().Substring(0, 1).Equals("0"))
                {
                    txtDados.Text = "(" + txtDados.Text.SoNumero().Substring(0, 3) + ")" + txtDados.Text.SoNumero().Substring(3, 4) + "-" + txtDados.Text.SoNumero().Substring(7, 4);
                    txtDados.SelectionStart = txtDados.Text.Length;
                }
                else
                {
                    txtDados.Text = "(" + txtDados.Text.SoNumero().Substring(0, 2) + ")" + txtDados.Text.SoNumero().Substring(2, 5) + "-" + txtDados.Text.SoNumero().Substring(7, 4);
                    txtDados.SelectionStart = txtDados.Text.Length;
                }
            else if (txtDados.Text.SoNumero().Length.Equals(12))
            {
                txtDados.Text = "(" + txtDados.Text.SoNumero().Substring(0, 3) + ")" + txtDados.Text.SoNumero().Substring(3, 5) + "-" + txtDados.Text.SoNumero().Substring(8, 4);
                txtDados.SelectionStart = txtDados.Text.Length;
            }
        }

        private void lblCliforDetalhado_Click(object sender, EventArgs e)
        {
            cliforDetalhado();
        }

        private void lblAbrirCartao_Click(object sender, EventArgs e)
        {
            abrirCartao();
        }

        private void bb_sair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtDados_Leave(object sender, EventArgs e)
        {
            tpModo = TTpModo.tm_Insert;
            buscarClifor();
        }

        private void nome_clifor_Leave(object sender, EventArgs e)
        {
            novoClifor();
        }

        private void nr_cartao_Leave(object sender, EventArgs e)
        {
            validaCartao();
        }

        private void lblCancelar_Click(object sender, EventArgs e)
        {
            tpModo = TTpModo.tm_Standby;
            afternovo();
        }

        private void lblStatusCartao_Click(object sender, EventArgs e)
        {
            statusCartao();
        }

        #endregion

        private void txtDados_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
                SendKeys.Send("{TAB}");
        }

        private void nome_clifor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
                SendKeys.Send("{TAB}");

        }

        private void nr_cartao_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
                SendKeys.Send("{TAB}");
        }

        private void nr_cartao_TextChanged(object sender, EventArgs e)
        {
            nr_cartao.Text = nr_cartao.Text.SoNumero().Trim();
        }
    }
}
