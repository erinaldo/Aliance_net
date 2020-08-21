using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Parametros.Diversos
{
    public partial class TFIntegraECommerce : Form
    {
        public TFIntegraECommerce()
        {
            InitializeComponent();
            ArrayList CBox1 = new ArrayList();
            CBox1.Add(new Utils.TDataCombo("SINCRONIZAR GRUPO PRODUTO", "SI_GRUPOPRODUTO"));
            CBox1.Add(new Utils.TDataCombo("SINCRONIZAR TIPO TRANSPORTE", "SI_TPTRANSPORTE"));
            CBox1.Add(new Utils.TDataCombo("SINCRONIZAR CLIENTE", "SI_CLIENTE"));
            CBox1.Add(new Utils.TDataCombo("SINCRONIZAR ENDEREÇOS", "SI_ENDERECO"));
            CBox1.Add(new Utils.TDataCombo("SINCRONIZAR TABELA DE PREÇO", "SI_TABPRECO"));
            CBox1.Add(new Utils.TDataCombo("SINCRONIZAR PREÇOS", "SI_PRECO"));
            CBox1.Add(new Utils.TDataCombo("SINCRONIZAR CONDIÇÃO PAGAMENTO", "SI_CONDPGTO"));
            CBox1.Add(new Utils.TDataCombo("SINCRONIZAR TIPO PRODUTO", "SI_TIPOPRODUTO"));
            CBox1.Add(new Utils.TDataCombo("SINCRONIZAR TIPO PRODUTO X CLIENTES", "SI_TPPRODUTO_X_CLIENTE"));
            CBox1.Add(new Utils.TDataCombo("SINCRONIZAR PRODUTOS", "SI_PRODUTO"));
            CBox1.Add(new Utils.TDataCombo("SINCRONIZAR IMAGENS", "SI_IMAGEM"));
            CBox1.Add(new Utils.TDataCombo("SINCRONIZAR PEDIDOS", "SI_PEDIDO"));
            cbItemSincronizar.DataSource = CBox1;
            cbItemSincronizar.DisplayMember = "Display";
            cbItemSincronizar.ValueMember = "Value";
        }

        private void afterGravaConfig()
        {
            if (cbItemSincronizar.SelectedValue != null)
            {
                string msg = string.Empty;
                CamadaDados.ConfigGer.TList_RegParamGer lParam =
                    CamadaNegocio.ConfigGer.TCN_CadParamGer.Busca(0,
                                                                  cbItemSincronizar.SelectedValue.ToString(),
                                                                  string.Empty,
                                                                  string.Empty,
                                                                  0,
                                                                  string.Empty);
                if (lParam.Count > 0)
                    lParam[0].VL_Bool_String = cb_sincronizarauto.Checked ? "S" : "N";
                else
                    lParam.Add(new CamadaDados.ConfigGer.TRegistro_ParamGer()
                    {
                        Id_parametro = 0,
                        Ds_finalidade = "SINCRONIZAR AUTOMATICAMENTE",
                        Ds_parametro = cbItemSincronizar.SelectedValue.ToString().Trim().ToUpper(),
                        Tp_dado = "B",
                        VL_Bool_String = cb_sincronizarauto.Checked ? "S" : "N"
                    });
                //Gravar parametro Sincronizar automaticamente
                try
                {
                    CamadaNegocio.ConfigGer.TCN_CadParamGer.GravaParamGer(lParam[0], null);
                    msg += "Parametro sincronizar automaticamente gravado com sucesso.\r\n";
                }
                catch (Exception ex)
                {
                    msg += "Erro gravar parametro sincronizar automaticamente: " + ex.Message.Trim() + "\r\n";
                }
                //Gravar prioridade do item sincronizar
                lParam = CamadaNegocio.ConfigGer.TCN_CadParamGer.Busca(0,
                                                                       "PI" + cbItemSincronizar.SelectedValue.ToString().Trim().Substring(2, cbItemSincronizar.SelectedValue.ToString().Trim().Length - 2),
                                                                       string.Empty,
                                                                       string.Empty,
                                                                       0,
                                                                       string.Empty);
                if (lParam.Count > 0)
                    lParam[0].Vl_numerico = Convert.ToDecimal(rgTempo.NM_Valor);
                else
                    lParam.Add(new CamadaDados.ConfigGer.TRegistro_ParamGer()
                    {
                        Id_parametro = 0,
                        Ds_finalidade = "PRIORIDADE SINCRONIZACAO",
                        Ds_parametro = "PI" + cbItemSincronizar.SelectedValue.ToString().Trim().Substring(2, cbItemSincronizar.SelectedValue.ToString().Trim().Length - 2),
                        Tp_dado = "N",
                        Vl_numerico = Convert.ToDecimal(rgTempo.NM_Valor)
                    });
                //Gravar parametro Prioridade sincronizacao
                try
                {
                    CamadaNegocio.ConfigGer.TCN_CadParamGer.GravaParamGer(lParam[0], null);
                    msg += "Parametro prioridade sincronizacao gravado com sucesso.\r\n";
                }
                catch (Exception ex)
                {
                    msg += "Erro gravar parametro prioridade sincronizacao: " + ex.Message.Trim() + "\r\n";
                }
                if ((dt_sincronizar.Text.Trim() != string.Empty) &&
                    (dt_sincronizar.Text.Trim() != "/  /       :  :"))
                {
                    CamadaDados.ConfigGer.TList_RegParamGer lData =
                        CamadaNegocio.ConfigGer.TCN_CadParamGer.Busca(0,
                                                                      "DT" + cbItemSincronizar.SelectedValue.ToString().Trim().Substring(2, cbItemSincronizar.SelectedValue.ToString().Trim().Length - 2),
                                                                      string.Empty,
                                                                      string.Empty,
                                                                      0,
                                                                      string.Empty);
                    if (lData.Count > 0)
                        lData[0].Vl_data = Convert.ToDateTime(dt_sincronizar.Text);
                    else
                    {
                        lData.Add(new CamadaDados.ConfigGer.TRegistro_ParamGer()
                        {
                            Id_parametro = 0,
                            Ds_finalidade = "DATA SINCRONIZACAO",
                            Ds_parametro = "DT" + cbItemSincronizar.SelectedValue.ToString().Trim().Substring(2, cbItemSincronizar.SelectedValue.ToString().Trim().Length - 2),
                            Tp_dado = "D",
                            Vl_data = Convert.ToDateTime(dt_sincronizar.Text)
                        });
                    }
                    //Gravar parametro data
                    try
                    {
                        CamadaNegocio.ConfigGer.TCN_CadParamGer.GravaParamGer(lData[0], null);
                        msg = "Parametro data sincronizacao gravado com sucesso.\r\n";
                    }
                    catch (Exception ex)
                    {
                        msg += "Erro gravar parametro data sincronizacao: " + ex.Message.Trim() + "\r\n";
                    }
                }
                //Parametro Tempo 1
                CamadaDados.ConfigGer.TList_RegParamGer lTempo =
                    CamadaNegocio.ConfigGer.TCN_CadParamGer.Busca(0,
                                                                  "TMP_SINCRONIZAR1",
                                                                  string.Empty,
                                                                  string.Empty,
                                                                  0,
                                                                  string.Empty);
                if (lTempo.Count > 0)
                    lTempo[0].Vl_numerico = tmp1.Value;
                else
                {
                    lTempo.Add(new CamadaDados.ConfigGer.TRegistro_ParamGer()
                    {
                        Id_parametro = 0,
                        Ds_finalidade = "TEMPO SINCRONIZACAO 1",
                        Ds_parametro = "TMP_SINCRONIZAR1",
                        Tp_dado = "N",
                        Vl_numerico = tmp1.Value
                    });
                }
                //Gravar parametro tempo atualizacao 1
                try
                {
                    CamadaNegocio.ConfigGer.TCN_CadParamGer.GravaParamGer(lTempo[0], null);
                    msg += "Parametro tempo sincronizacao 1 gravado com sucesso.\r\n";
                }
                catch (Exception ex)
                {
                    msg += "Erro gravar parametro tempo sincronizacao 1: " + ex.Message.Trim() + "\r\n";
                }
                //Parametro Tempo 2
                lTempo = CamadaNegocio.ConfigGer.TCN_CadParamGer.Busca(0,
                                                                       "TMP_SINCRONIZAR2",
                                                                       string.Empty,
                                                                       string.Empty,
                                                                       0,
                                                                       string.Empty);
                if (lTempo.Count > 0)
                    lTempo[0].Vl_numerico = tmp2.Value;
                else
                {
                    lTempo.Add(new CamadaDados.ConfigGer.TRegistro_ParamGer()
                    {
                        Id_parametro = 0,
                        Ds_finalidade = "TEMPO SINCRONIZACAO 2",
                        Ds_parametro = "TMP_SINCRONIZAR2",
                        Tp_dado = "N",
                        Vl_numerico = tmp2.Value
                    });
                }
                //Gravar parametro tempo atualizacao 2
                try
                {
                    CamadaNegocio.ConfigGer.TCN_CadParamGer.GravaParamGer(lTempo[0], null);
                    msg += "Parametro tempo sincronizacao 2 gravado com sucesso.\r\n";
                }
                catch (Exception ex)
                {
                    msg += "Erro gravar parametro tempo sincronizacao 2: " + ex.Message.Trim() + "\r\n";
                }
                //Parametro Tempo 3
                lTempo = CamadaNegocio.ConfigGer.TCN_CadParamGer.Busca(0,
                                                                       "TMP_SINCRONIZAR3",
                                                                       string.Empty,
                                                                       string.Empty,
                                                                       0,
                                                                       string.Empty);
                if (lTempo.Count > 0)
                    lTempo[0].Vl_numerico = tmp2.Value;
                else
                {
                    lTempo.Add(new CamadaDados.ConfigGer.TRegistro_ParamGer()
                    {
                        Id_parametro = 0,
                        Ds_finalidade = "TEMPO SINCRONIZACAO 3",
                        Ds_parametro = "TMP_SINCRONIZAR3",
                        Tp_dado = "N",
                        Vl_numerico = tmp3.Value
                    });
                }
                //Gravar parametro tempo atualizacao 3
                try
                {
                    CamadaNegocio.ConfigGer.TCN_CadParamGer.GravaParamGer(lTempo[0], null);
                    msg += "Parametro tempo sincronizacao 3 gravado com sucesso.\r\n";
                }
                catch (Exception ex)
                {
                    msg += "Erro gravar parametro tempo sincronizacao 3: " + ex.Message.Trim() + "\r\n";
                }
                //Parametro tempo sincronizar pedido
                lTempo = CamadaNegocio.ConfigGer.TCN_CadParamGer.Busca(0,
                                                                      "TMP_SINCPEDIDO",
                                                                      string.Empty,
                                                                      string.Empty,
                                                                      0,
                                                                      string.Empty);
                if (lTempo.Count > 0)
                    lTempo[0].Vl_numerico = tmp_atualizapedido.Value;
                else
                {
                    lTempo.Add(new CamadaDados.ConfigGer.TRegistro_ParamGer()
                    {
                        Id_parametro = 0,
                        Ds_finalidade = "TEMPO SINCRONIZACAO PEDIDOS",
                        Ds_parametro = "TMP_SINCPEDIDO",
                        Tp_dado = "N",
                        Vl_numerico = tmp_atualizapedido.Value
                    });
                }
                //Gravar parametro tempo atualizacao
                try
                {
                    CamadaNegocio.ConfigGer.TCN_CadParamGer.GravaParamGer(lTempo[0], null);
                    msg += "Parametro tempo sincronizacao pedido gravado com sucesso.\r\n";
                }
                catch (Exception ex)
                {
                    msg += "Erro gravar parametro tempo sincronizacao pedido: " + ex.Message.Trim() + "\r\n";
                }


                if (msg.Trim() != string.Empty)
                {
                    MessageBox.Show(msg, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.PararServico();
                    this.PararServicoPedido();
                    System.Threading.Thread.Sleep(500);
                    this.IniciarServico();
                    this.IniciarServicoPedido();
                }
            }
            else
            {
                MessageBox.Show("Obrigatorio selecionar item sincronizar.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbItemSincronizar.Focus();
            }
        }

        private void afterSincManual()
        {
            string msg = string.Empty;
            if (cbSincPedidos.Checked)
            {
                try
                {
                    UtilsECommerce.Sincronizar.SincronizarPedidos();
                    msg += "Pedidos sincronizados com sucesso.\r\n";
                }
                catch (Exception ex)
                {
                    msg += ex.Message.Trim() + "\r\n";
                }
            }
            else
            {
                DateTime dt_inicial;
                DateTime? dt_final = null;

                try
                {
                    dt_inicial = Convert.ToDateTime(DT_Inicial.Text);
                }
                catch
                {
                    MessageBox.Show("Obrigatorio informar data inicial.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DT_Inicial.Focus();
                    return;
                }
                try
                {
                    dt_final = Convert.ToDateTime(DT_Final.Text);
                }
                catch { }
                if (cbSincCategoriaProdutos.Checked)
                {
                    try
                    {
                        UtilsECommerce.Sincronizar.SincronizarGrupoProduto(dt_inicial.ToString("dd/MM/yyyy HH:mm:ss"),
                                                                          (dt_final == null ? string.Empty : dt_final.Value.ToString("dd/MM/yyyy HH:mm:ss")));
                        msg = "Categoria de Produto sincronizada com sucesso.\r\n";
                    }
                    catch (Exception ex)
                    {
                        msg = "Erro sincronizar categoria produto: " + ex.Message + "\r\n";
                    }
                }
                if (cbSincTpProduto.Checked)
                {
                    try
                    {
                        UtilsECommerce.Sincronizar.SincronizarTipoProduto(dt_inicial.ToString("dd/MM/yyyy HH:mm:ss"),
                                                                          (dt_final == null ? string.Empty : dt_final.Value.ToString("dd/MM/yyyy HH:mm:ss")));
                        msg += "Tipo de Produto sincronizado com sucesso.\r\n";
                    }
                    catch (Exception ex)
                    {
                        msg += "Erro sincronizar tipo produto: " + ex.Message + "\r\n";
                    }
                }
                if (cbSincProdutos.Checked)
                {
                    try
                    {
                        UtilsECommerce.Sincronizar.SincronizarProdutos(dt_inicial.ToString("dd/MM/yyyy HH:mm:ss"),
                                                                          (dt_final == null ? string.Empty : dt_final.Value.ToString("dd/MM/yyyy HH:mm:ss")));
                        msg += "Produtos sincronizados com sucesso.\r\n";
                    }
                    catch (Exception ex)
                    {
                        msg += "Erro sincronizar produtos: " + ex.Message + "\r\n";
                    }
                }
                if (cbSincImagens.Checked)
                {
                    try
                    {
                        UtilsECommerce.Sincronizar.SincronizarImagens(dt_inicial.ToString("dd/MM/yyyy HH:mm:ss"),
                                                                          (dt_final == null ? string.Empty : dt_final.Value.ToString("dd/MM/yyyy HH:mm:ss")));
                        msg += "Imagens sincronizadas com sucesso.\r\n";
                    }
                    catch (Exception ex)
                    {
                        msg += "Erro sincronizar imagens: " + ex.Message + "\r\n";
                    }
                }
                if (cbSincOpcoesEnvio.Checked)
                {
                    try
                    {
                        UtilsECommerce.Sincronizar.SincronizarTipoTransporte(dt_inicial.ToString("dd/MM/yyyy HH:mm:ss"),
                                                                          (dt_final == null ? string.Empty : dt_final.Value.ToString("dd/MM/yyyy HH:mm:ss")));
                        msg += "Opções de envio sincronizadas com sucesso.\r\n";
                    }
                    catch (Exception ex)
                    {
                        msg += "Erro sincronizar opções de envio: " + ex.Message + "\r\n";
                    }
                }
                if (cbSincTabPreco.Checked)
                {
                    try
                    {
                        UtilsECommerce.Sincronizar.SincronizarTabelaPreco(dt_inicial.ToString("dd/MM/yyyy HH:mm:ss"),
                                                                          (dt_final == null ? string.Empty : dt_final.Value.ToString("dd/MM/yyyy HH:mm:ss")));
                        msg += "Tabela preço sincronizada com sucesso.\r\n";
                    }
                    catch (Exception ex)
                    {
                        msg += "Erro sincronizar tabela preço: " + ex.Message + "\r\n";
                    }
                }
                if (cbSincPrecoProd.Checked)
                {
                    try
                    {
                        UtilsECommerce.Sincronizar.SincronizarPrecoProduto(dt_inicial.ToString("dd/MM/yyyy HH:mm:ss"),
                                                                          (dt_final == null ? string.Empty : dt_final.Value.ToString("dd/MM/yyyy HH:mm:ss")));
                        msg += "Preço itens sincronizados com sucesso.\r\n";
                    }
                    catch (Exception ex)
                    {
                        msg += "Erro sincronizar preço itens: " + ex.Message + "\r\n";
                    }
                }
                if (cbSincCondPgto.Checked)
                {
                    try
                    {
                        UtilsECommerce.Sincronizar.SincronizarCondPgto(dt_inicial.ToString("dd/MM/yyyy HH:mm:ss"),
                                                                          (dt_final == null ? string.Empty : dt_final.Value.ToString("dd/MM/yyyy HH:mm:ss")));
                        msg += "Condições de pagamento sincronizadas com sucesso.\r\n";
                    }
                    catch (Exception ex)
                    {
                        msg += "Erro sincronizar condições de pagamento: " + ex.Message + "\r\n";
                    }
                }
                if (cbSincClientes.Checked)
                {
                    try
                    {
                        UtilsECommerce.Sincronizar.SincronizarCliente(dt_inicial.ToString("dd/MM/yyyy HH:mm:ss"),
                                                                          (dt_final == null ? string.Empty : dt_final.Value.ToString("dd/MM/yyyy HH:mm:ss")));
                        msg += "Clientes sincronizados com sucesso.\r\n";
                    }
                    catch (Exception ex)
                    {
                        msg += "Erro sincronizar clientes: " + ex.Message + "\r\n";
                    }
                }
                if (cbSincEnderecos.Checked)
                {
                    try
                    {
                        UtilsECommerce.Sincronizar.SincronizarEnderecos(dt_inicial.ToString("dd/MM/yyyy HH:mm:ss"),
                                                                          (dt_final == null ? string.Empty : dt_final.Value.ToString("dd/MM/yyyy HH:mm:ss")));
                        msg += "Endereços sincronizados com sucesso.\r\n";
                    }
                    catch (Exception ex)
                    {
                        msg += "Erro sincronizar endereços: " + ex.Message.Trim() + "\r\n";
                    }
                }
                if (cbSincClienteXTpProduto.Checked)
                {
                    try
                    {
                        UtilsECommerce.Sincronizar.SincronizarTpProdutoXClifor(dt_inicial.ToString("dd/MM/yyyy HH:mm:ss"),
                                                                          (dt_final == null ? string.Empty : dt_final.Value.ToString("dd/MM/yyyy HH:mm:ss")));
                        msg += "Clientes X Tipo Produto sincronizado com sucesso.\r\n";
                    }
                    catch (Exception ex)
                    {
                        msg += "Erro sincronizar Cliente X Tipo Produto: " + ex.Message + "\r\n";
                    }
                }
            }
            if (msg.Trim() != string.Empty)
                MessageBox.Show(msg.Trim(), "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void IniciarServico()
        {
            if (MessageBox.Show("Esta operação somente podera ser realizada no servidor. Continuar?",
                                "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                == DialogResult.Yes)
            {
                try
                {
                    scIntegraEcommerce.Refresh();
                    if (!(scIntegraEcommerce.Status == System.ServiceProcess.ServiceControllerStatus.Running) &&
                        !(scIntegraEcommerce.Status == System.ServiceProcess.ServiceControllerStatus.StartPending))
                        scIntegraEcommerce.Start();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro: " + ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void IniciarServicoPedido()
        {
            if (MessageBox.Show("Esta operação somente podera ser realizada no servidor. Continuar?",
                                "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                == DialogResult.Yes)
            {
                try
                {
                    scIntegraPedido.Refresh();
                    if (!(scIntegraPedido.Status == System.ServiceProcess.ServiceControllerStatus.Running) &&
                        !(scIntegraPedido.Status == System.ServiceProcess.ServiceControllerStatus.StartPending))
                        scIntegraPedido.Start();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro: " + ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void PararServico()
        {
            if (MessageBox.Show("Esta operação somente podera ser realizada no servidor. Continuar?",
                                "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                == DialogResult.Yes)
            {
                try
                {
                    scIntegraEcommerce.Refresh();
                    if ((scIntegraEcommerce.Status == System.ServiceProcess.ServiceControllerStatus.Running) ||
                        (scIntegraEcommerce.Status == System.ServiceProcess.ServiceControllerStatus.StartPending))
                        scIntegraEcommerce.Stop();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro: " + ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void PararServicoPedido()
        {
            if (MessageBox.Show("Esta operação somente podera ser realizada no servidor. Continuar?",
                                "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                == DialogResult.Yes)
            {
                try
                {
                    scIntegraPedido.Refresh();
                    if ((scIntegraPedido.Status == System.ServiceProcess.ServiceControllerStatus.Running) ||
                        (scIntegraPedido.Status == System.ServiceProcess.ServiceControllerStatus.StartPending))
                        scIntegraPedido.Stop();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro: " + ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private string Status_Servico()
        {
            try
            {
                scIntegraEcommerce.Refresh();
                switch (scIntegraEcommerce.Status)
                {
                    case (System.ServiceProcess.ServiceControllerStatus.Running): return "INICIADO";
                    case (System.ServiceProcess.ServiceControllerStatus.StartPending): return "INICIAR PENDENTE";
                    case (System.ServiceProcess.ServiceControllerStatus.Stopped): return "PARADO";
                    case (System.ServiceProcess.ServiceControllerStatus.StopPending): return "PARAR PENDENTE";
                    case (System.ServiceProcess.ServiceControllerStatus.Paused): return "PAUSADO";
                    case (System.ServiceProcess.ServiceControllerStatus.PausePending): return "PAUSA PENDENTE";
                    default: return string.Empty;
                }
            }
            catch
            { return string.Empty; }
        }

        private string Status_ServicoPedido()
        {
            try
            {
                scIntegraPedido.Refresh();
                switch (scIntegraPedido.Status)
                {
                    case (System.ServiceProcess.ServiceControllerStatus.Running): return "INICIADO";
                    case (System.ServiceProcess.ServiceControllerStatus.StartPending): return "INICIAR PENDENTE";
                    case (System.ServiceProcess.ServiceControllerStatus.Stopped): return "PARADO";
                    case (System.ServiceProcess.ServiceControllerStatus.StopPending): return "PARAR PENDENTE";
                    case (System.ServiceProcess.ServiceControllerStatus.Paused): return "PAUSADO";
                    case (System.ServiceProcess.ServiceControllerStatus.PausePending): return "PAUSA PENDENTE";
                    default: return string.Empty;
                }
            }
            catch
            { return string.Empty; }
        }

        private void cbItemSincronizar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbItemSincronizar.SelectedValue != null)
            {
                if (cbItemSincronizar.SelectedValue.ToString().Trim().ToUpper().Equals("SI_PEDIDO"))
                {
                    dt_sincronizar.Clear();
                    dt_sincronizar.Enabled = false;
                }
                else
                    dt_sincronizar.Enabled = true;
                //Buscar parametro sincronizacao automatica
                cb_sincronizarauto.Checked = CamadaNegocio.ConfigGer.TCN_CadParamGer.BuscaVlBool(cbItemSincronizar.SelectedValue.ToString().Trim().ToUpper());
                //Buscar parametro data ultima sincronizacao
                DateTime? dt = CamadaNegocio.ConfigGer.TCN_CadParamGer.BuscaVlData("DT"+cbItemSincronizar.SelectedValue.ToString().Trim().Substring(2, cbItemSincronizar.SelectedValue.ToString().Trim().Length - 2));
                if (dt != null)
                    dt_sincronizar.Text = dt.Value.ToString("dd/MM/yyyy HH:mm:ss");
            }
        }

        private void TFIntegraECommerce_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            //Tempo 1
            decimal valor = CamadaNegocio.ConfigGer.TCN_CadParamGer.BuscaVlNumerico("TMP_SINCRONIZAR1");
            tmp1.Value = valor == 0 ? 5 : valor;
            //Tempo 2
            valor = CamadaNegocio.ConfigGer.TCN_CadParamGer.BuscaVlNumerico("TMP_SINCRONIZAR2");
            tmp2.Value = valor == 0 ? 720 : valor;
            //Tempo 3
            valor = CamadaNegocio.ConfigGer.TCN_CadParamGer.BuscaVlNumerico("TMP_SINCRONIZAR3");
            tmp3.Value = valor == 0 ? 1440 : valor;
            valor = CamadaNegocio.ConfigGer.TCN_CadParamGer.BuscaVlNumerico("TMP_SINCPEDIDO");
            tmp_atualizapedido.Value = valor == 0 ? 5 : valor;
            cbItemSincronizar_SelectedIndexChanged(this, new EventArgs());
        }

        private void tcCentral_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tcCentral.SelectedTab.Equals(tpCfgServico))
            {
                BB_Gravar.Visible = true;
                BB_Iniciar.Visible = true;
                BB_Parar.Visible = true;
                BB_Sincronizar.Visible = false;
                //Tempo 1
                decimal valor = CamadaNegocio.ConfigGer.TCN_CadParamGer.BuscaVlNumerico("TMP_SINCRONIZAR1");
                tmp1.Value = valor == 0 ? 5 : valor;
                //Tempo 2
                valor = CamadaNegocio.ConfigGer.TCN_CadParamGer.BuscaVlNumerico("TMP_SINCRONIZAR2");
                tmp2.Value = valor == 0 ? 720 : valor;
                //Tempo 3
                valor = CamadaNegocio.ConfigGer.TCN_CadParamGer.BuscaVlNumerico("TMP_SINCRONIZAR3");
                tmp3.Value = valor == 0 ? 1440 : valor;
                valor = CamadaNegocio.ConfigGer.TCN_CadParamGer.BuscaVlNumerico("TMP_SINCPEDIDO");
                tmp_atualizapedido.Value = valor == 0 ? 5 : valor;
            }
            else if (tcCentral.SelectedTab.Equals(tpSincManual))
            {
                BB_Gravar.Visible = false;
                BB_Iniciar.Visible = false;
                BB_Parar.Visible = false;
                BB_Sincronizar.Visible = true;
            }
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            this.afterGravaConfig();
        }

        private void BB_Fechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbSincClienteXTpProduto_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void cbSincProdutos_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void cbSincImagens_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void cbSincPrecoProd_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void BB_Sincronizar_Click(object sender, EventArgs e)
        {
            this.afterSincManual();
        }

        private void TFIntegraECommerce_KeyDown(object sender, KeyEventArgs e)
        {
            if((e.KeyCode.Equals(Keys.F4)) && (BB_Gravar.Visible))
                this.afterGravaConfig();
            else if((e.KeyCode.Equals(Keys.F5)) && (BB_Iniciar.Visible))
                this.IniciarServico();
            else if((e.KeyCode.Equals(Keys.F6)) && (BB_Parar.Visible))
                this.PararServico();
            else if((e.KeyCode.Equals(Keys.F9)) && (BB_Sincronizar.Visible))
                this.afterSincManual();
        }

        private void BB_Iniciar_Click(object sender, EventArgs e)
        {
            this.IniciarServico();
        }

        private void BB_Parar_Click(object sender, EventArgs e)
        {
            this.PararServico();
        }

        private void tempo_Tick(object sender, EventArgs e)
        {
            tempo.Enabled = false;
            st_cadastro.Text = this.Status_Servico();
            st_pedido.Text = this.Status_ServicoPedido();
            tempo.Enabled = true;
        }

        private void cbSincPedidos_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void cbSincEnderecos_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void iToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.IniciarServico();
        }

        private void sincronizarCadastrosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.PararServico();
        }

        private void sincronizarPedidosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.PararServicoPedido();
        }

        private void sincronizarPedidosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.IniciarServicoPedido();
        }
    }
}
