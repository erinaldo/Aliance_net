using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Utils;

namespace PostoCombustivel
{
    public partial class TFLanVendaCombustivel : Form
    {
        private System.Net.Sockets.TcpClient tcpClient;
        private System.Net.Sockets.NetworkStream socketStream;
        private System.IO.BinaryWriter escreve;
        private System.IO.BinaryReader le;

        private static Timer tmpOnLine;
        private static Timer tmpAbastAtual;
        private static Timer tmpAtualizaTela;

        private string Cd_operador
        { get; set; }
        private CamadaDados.Faturamento.PDV.TRegistro_VendaRapida rVenda
        { get; set; }

        private CamadaDados.Faturamento.Cadastros.TList_PontoVenda lPdv
        { get; set; }
        private CamadaDados.Faturamento.PDV.TList_Sessao lSessao
        { get; set; }
        private CamadaDados.Faturamento.Cadastros.TList_CFGCupomFiscal lCfg
        { get; set; }
        private CamadaDados.Faturamento.Cadastros.TRegistro_CFGCupomFiscal rCfgConv
        { get; set; }
        private CamadaDados.PostoCombustivel.Cadastros.TRegistro_CfgPosto rCfgPosto
        { get; set; }
        private CamadaDados.Faturamento.ProgEspecialVenda.TRegistro_ProgEspecialVenda rProg;

        public string LoginPdv
        { get; set; }
        public CamadaDados.Faturamento.PDV.TRegistro_CaixaPDV rCaixa
        { get; set; }

        private bool St_placacadastrada = false;
        private bool Altera_Relatorio = false;
        //Tabela buscar dados dos semafaros
        private DataTable tb_semafaro;

        public TFLanVendaCombustivel()
        {
            InitializeComponent();
            rVenda = null;
            rProg = null;
            
            //Abastecimento OnLine
            tmpOnLine = new Timer();
            tmpOnLine.Tick += new EventHandler(tmpOnLine_Tick);
            //Abastecimento Atual
            tmpAbastAtual = new Timer();
            tmpAbastAtual.Tick += new EventHandler(tmpAbastAtual_Tick);
            //Atualizar tela
            tmpAtualizaTela = new Timer();
            tmpAtualizaTela.Tick += new EventHandler(tmpAtualizaTela_Tick);
        }

        void tmpAtualizaTela_Tick(object sender, EventArgs e)
        {
            afterBusca();
        }

        void tmpAbastAtual_Tick(object sender, EventArgs e)
        {
            try
            {
                tmpAbastAtual.Stop();
                string abast = string.Empty;
                //Ler status da porta COM
                if (tcpClient == null)
                {
                    int status = TAutomacao.StatusPorta(rCfgPosto.Tp_concentrador);
                    if (status == 1)
                        if (!TAutomacao.AbrirPorta(rCfgPosto.Tp_concentrador, rCfgPosto.Porta_comunicacao))
                            return;
                    if (status == 255)
                    {
                        TAutomacao.FecharPorta(rCfgPosto.Tp_concentrador);
                        return;
                    }
                    //Limpar buffer serial
                    //TAutomacao.LimparSerial(rCfgPosto.Tp_concentrador);
                    //Ler abastecimento memoria
                    TAutomacao.LerAbastecimentoAtual(rCfgPosto.Tp_concentrador, rCfgPosto.St_identfrentistabool, ref abast);
                }
                else
                    abast = SendLan(rCfgPosto.St_identfrentistabool ? "(&A67)" : "(&A)");
                TratarAbastecimento(rCfgPosto.Tp_concentrador, abast);
            }
            catch
            { }
            finally
            {
                tmpAbastAtual.Start();
                afterBusca(); 
            }
        }

        void tmpOnLine_Tick(object sender, EventArgs e)
        {
            try
            {
                tmpOnLine.Stop();
                if(tcpClient == null)
                    TAutomacao.LimparSerial(rCfgPosto.Tp_concentrador);
                string abast = string.Empty;
                string bico_ini = string.Empty;
                string bico_fin = string.Empty;
                if (rCfgPosto.Tp_concentrador.Trim().ToUpper().Equals("VW"))
                {
                    object obj = new CamadaDados.PostoCombustivel.Cadastros.TCD_BicoBomba().BuscarEscalar(
                                    new TpBusca[]
                                    {
                                        new TpBusca()
                                        {
                                            vNM_Campo = "a.cd_empresa",
                                            vOperador = "=",
                                            vVL_Busca = "'" + rCfgPosto.Cd_empresa.Trim() + "'"
                                        },
                                        new TpBusca()
                                        {
                                            vNM_Campo= "isnull(a.st_registro, 'A')",
                                            vOperador = "<>",
                                            vVL_Busca = "'C'"
                                        }
                                    }, "min(enderecofisicobico)");
                    if (obj != null)
                        bico_ini = obj.ToString();
                    obj = new CamadaDados.PostoCombustivel.Cadastros.TCD_BicoBomba().BuscarEscalar(
                                    new TpBusca[]
                                    {
                                        new TpBusca()
                                        {
                                            vNM_Campo = "a.cd_empresa",
                                            vOperador = "=",
                                            vVL_Busca = "'" + rCfgPosto.Cd_empresa.Trim() + "'"
                                        },
                                        new TpBusca()
                                        {
                                            vNM_Campo= "isnull(a.st_registro, 'A')",
                                            vOperador = "<>",
                                            vVL_Busca = "'C'"
                                        }
                                    }, "max(enderecofisicobico)");
                    if (obj != null)
                        bico_fin = obj.ToString();
                }
                if (tcpClient == null)
                    TAutomacao.LerAbastecimentoOnLine(rCfgPosto.Tp_concentrador, rCfgPosto.St_identfrentistabool, bico_ini, bico_fin, ref abast);
                else abast = SendLan("(&V)");
                if (!string.IsNullOrEmpty(abast))
                    TratarAbastOnLine(abast);
            }
            catch { }
            finally { tmpOnLine.Start(); }
        }

        #region Metodos Usuario

        public string SendLan(string comando)
        {
            string rta = string.Empty;
            if(tcpClient.Connected)
            {
                escreve.Write(comando);
                escreve.Flush();
                if(comando.Trim() != "(&I)")
                    rta = ReceiveLanData();
            }
            return rta;
        }

        private string ReceiveLanData()
        {
            byte[] buffer = new byte[tcpClient.ReceiveBufferSize];
            le.Read(buffer, 0, tcpClient.ReceiveBufferSize);
            return Encoding.ASCII.GetString(buffer);
        }
    
        private void MontarLayoutbico()
        {
            if (tlpStatus.Controls.Count > 0)
            {
                int index = 0;
                //Buscar lista de bicos
                CamadaNegocio.PostoCombustivel.Cadastros.TCN_BicoBomba.Buscar(string.Empty,
                                                                              string.Empty,
                                                                              rCfgPosto.Cd_empresa,
                                                                              string.Empty,
                                                                              "'A'",
                                                                              null).OrderBy(p => p.Ds_label).ToList().ForEach(p =>
                                                                              {
                                                                                  switch (index)
                                                                                  {
                                                                                      case 0:
                                                                                          {
                                                                                              bb01.Text = "BC-" + p.Ds_label;
                                                                                              bb01.Tag = p.Enderecofisicobico;
                                                                                              bb01.Visible = true;
                                                                                              index++;
                                                                                              break;
                                                                                          }
                                                                                      case 1:
                                                                                          {
                                                                                              bb02.Text = "BC-" + p.Ds_label;
                                                                                              bb02.Tag = p.Enderecofisicobico;
                                                                                              bb02.Visible = true;
                                                                                              index++;
                                                                                              break;
                                                                                          }
                                                                                      case 2:
                                                                                          {
                                                                                              bb03.Text = "BC-" + p.Ds_label;
                                                                                              bb03.Tag = p.Enderecofisicobico;
                                                                                              bb03.Visible = true;
                                                                                              index++;
                                                                                              break;
                                                                                          }
                                                                                      case 3:
                                                                                          {
                                                                                              bb04.Text = "BC-" + p.Ds_label;
                                                                                              bb04.Tag = p.Enderecofisicobico;
                                                                                              bb04.Visible = true;
                                                                                              index++;
                                                                                              break;
                                                                                          }
                                                                                      case 4:
                                                                                          {
                                                                                              bb05.Text = "BC-" + p.Ds_label;
                                                                                              bb05.Tag = p.Enderecofisicobico;
                                                                                              bb05.Visible = true;
                                                                                              index++;
                                                                                              break;
                                                                                          }
                                                                                      case 5:
                                                                                          {
                                                                                              bb06.Text = "BC-" + p.Ds_label;
                                                                                              bb06.Tag = p.Enderecofisicobico;
                                                                                              bb06.Visible = true;
                                                                                              index++;
                                                                                              break;
                                                                                          }
                                                                                      case 6:
                                                                                          {
                                                                                              bb07.Text = "BC-" + p.Ds_label;
                                                                                              bb07.Tag = p.Enderecofisicobico;
                                                                                              bb07.Visible = true;
                                                                                              index++;
                                                                                              break;
                                                                                          }
                                                                                      case 7:
                                                                                          {
                                                                                              bb08.Text = "BC-" + p.Ds_label;
                                                                                              bb08.Tag = p.Enderecofisicobico;
                                                                                              bb08.Visible = true;
                                                                                              index++;
                                                                                              break;
                                                                                          }
                                                                                      case 8:
                                                                                          {
                                                                                              bb09.Text = "BC-" + p.Ds_label;
                                                                                              bb09.Tag = p.Enderecofisicobico;
                                                                                              bb09.Visible = true;
                                                                                              index++;
                                                                                              break;
                                                                                          }
                                                                                      case 9:
                                                                                          {
                                                                                              bb10.Text = "BC-" + p.Ds_label;
                                                                                              bb10.Tag = p.Enderecofisicobico;
                                                                                              bb10.Visible = true;
                                                                                              index++;
                                                                                              break;
                                                                                          }
                                                                                      case 10:
                                                                                          {
                                                                                              bb11.Text = "BC-" + p.Ds_label;
                                                                                              bb11.Tag = p.Enderecofisicobico;
                                                                                              bb11.Visible = true;
                                                                                              index++;
                                                                                              break;
                                                                                          }
                                                                                      case 11:
                                                                                          {
                                                                                              bb12.Text = "BC-" + p.Ds_label;
                                                                                              bb12.Tag = p.Enderecofisicobico;
                                                                                              bb12.Visible = true;
                                                                                              index++;
                                                                                              break;
                                                                                          }
                                                                                      case 12:
                                                                                          {
                                                                                              bb13.Text = "BC-" + p.Ds_label;
                                                                                              bb13.Tag = p.Enderecofisicobico;
                                                                                              bb13.Visible = true;
                                                                                              index++;
                                                                                              break;
                                                                                          }
                                                                                      case 13:
                                                                                          {
                                                                                              bb14.Text = "BC-" + p.Ds_label;
                                                                                              bb14.Tag = p.Enderecofisicobico;
                                                                                              bb14.Visible = true;
                                                                                              index++;
                                                                                              break;
                                                                                          }
                                                                                      case 14:
                                                                                          {
                                                                                              bb15.Text = "BC-" + p.Ds_label;
                                                                                              bb15.Tag = p.Enderecofisicobico;
                                                                                              bb15.Visible = true;
                                                                                              index++;
                                                                                              break;
                                                                                          }
                                                                                      case 15:
                                                                                          {
                                                                                              bb16.Text = "BC-" + p.Ds_label;
                                                                                              bb16.Tag = p.Enderecofisicobico;
                                                                                              bb16.Visible = true;
                                                                                              index++;
                                                                                              break;
                                                                                          }
                                                                                      case 16:
                                                                                          {
                                                                                              bb17.Text = "BC-" + p.Ds_label;
                                                                                              bb17.Tag = p.Enderecofisicobico;
                                                                                              bb17.Visible = true;
                                                                                              index++;
                                                                                              break;
                                                                                          }
                                                                                      case 17:
                                                                                          {
                                                                                              bb18.Text = "BC-" + p.Ds_label;
                                                                                              bb18.Tag = p.Enderecofisicobico;
                                                                                              bb18.Visible = true;
                                                                                              index++;
                                                                                              break;
                                                                                          }
                                                                                      case 18:
                                                                                          {
                                                                                              bb19.Text = "BC-" + p.Ds_label;
                                                                                              bb19.Tag = p.Enderecofisicobico;
                                                                                              bb19.Visible = true;
                                                                                              index++;
                                                                                              break;
                                                                                          }
                                                                                      case 19:
                                                                                          {
                                                                                              bb20.Text = "BC-" + p.Ds_label;
                                                                                              bb20.Tag = p.Enderecofisicobico;
                                                                                              bb20.Visible = true;
                                                                                              index++;
                                                                                              break;
                                                                                          }
                                                                                      case 20:
                                                                                          {
                                                                                              bb21.Text = "BC-" + p.Ds_label;
                                                                                              bb21.Tag = p.Enderecofisicobico;
                                                                                              bb21.Visible = true;
                                                                                              index++;
                                                                                              break;
                                                                                          }
                                                                                      case 21:
                                                                                          {
                                                                                              bb22.Text = "BC-" + p.Ds_label;
                                                                                              bb22.Tag = p.Enderecofisicobico;
                                                                                              bb22.Visible = true;
                                                                                              index++;
                                                                                              break;
                                                                                          }
                                                                                      case 22:
                                                                                          {
                                                                                              bb23.Text = "BC-" + p.Ds_label;
                                                                                              bb23.Tag = p.Enderecofisicobico;
                                                                                              bb23.Visible = true;
                                                                                              index++;
                                                                                              break;
                                                                                          }
                                                                                      case 23:
                                                                                          {
                                                                                              bb24.Text = "BC-" + p.Ds_label;
                                                                                              bb24.Tag = p.Enderecofisicobico;
                                                                                              bb24.Visible = true;
                                                                                              index++;
                                                                                              break;
                                                                                          }
                                                                                  };
                                                                              });
            }
        }

        private void FaturarVenda(string TP_Portador)
        {
            if (Cd_clifor.Focused)
                cd_clifor_Leave(this, new EventArgs());
            if (rVenda == null)
                return;
            if (placa.Text.Trim() != "-")
                rVenda.Placa = placa.Text;
            if (!string.IsNullOrEmpty(cd_endereco.Text))
                rVenda.Cd_endereco = cd_endereco.Text;
            if (string.IsNullOrEmpty(Cd_clifor.Text) ||
                (!rVenda.lItem.Exists(p => p.rVendaCombustivel != null)))
                FinalizarVenda(false, TP_Portador);
            else
            {
                //Montar lista de combustiveis
                string virg = string.Empty;
                List<string> lProd = new List<string>();
                string condProd = string.Empty;
                rVenda.lItem.Where(p => p.rVendaCombustivel != null).ToList().ForEach(p =>
                {
                    if (!lProd.Exists(v => v.Trim().Equals(p.Cd_produto.Trim())))
                    {
                        lProd.Add(p.Cd_produto.Trim());
                        condProd += virg + "'" + p.Cd_produto.Trim() + "'";
                        virg = ",";
                    }
                });
                //Verificar se o cliente possui convenio
                CamadaDados.PostoCombustivel.TList_Convenio lConv =
                new CamadaDados.PostoCombustivel.TCD_Convenio().Select(rVenda.Cd_empresa, Cd_clifor.Text, cd_endereco.Text, false, lProd);
                if (lConv.Count > 0)
                {
                    if (rCfgPosto.St_vendaforaconvbool)
                        if (MessageBox.Show("Receber venda utilizando convenio?", "Pergunta", MessageBoxButtons.YesNo,
                             MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                            FecharVendaConvenio(lConv, condProd);
                        else
                            FinalizarVenda(false, TP_Portador);
                    else
                        FecharVendaConvenio(lConv, condProd);
                }
                else
                    FinalizarVenda(false, TP_Portador);
            }
        }

        private void FecharVendaConvenio(CamadaDados.PostoCombustivel.TList_Convenio lConv, string condProd)
        {
            bool st_vendagravada = false;
            using (TFReceberConvenio fRec = new TFReceberConvenio())
            {
                fRec.lItemVenda = rVenda.lItem.FindAll(p => p.rVendaCombustivel == null);
                List<CamadaDados.PostoCombustivel.TRegistro_VendaCombustivel> lVendaComb = new List<CamadaDados.PostoCombustivel.TRegistro_VendaCombustivel>();
                rVenda.lItem.FindAll(p => p.rVendaCombustivel != null).ForEach(p => lVendaComb.Add(p.rVendaCombustivel));
                fRec.lVenda = lVendaComb;
                fRec.Cd_clifor = Cd_clifor.Text;
                fRec.Nm_clifor = NM_Clifor.Text; 
                fRec.Cd_endereco = cd_endereco.Text;
                fRec.Placa = placa.Text;
                fRec.St_placacadastrada = St_placacadastrada;
                fRec.condProd = condProd;
                fRec.lConv = lConv;
                if (fRec.ShowDialog() == DialogResult.OK)
                    if ((fRec.rConvenio != null) && (fRec.rConvenio.lClifor.Count > 0))
                    {
                        //Venda com convenio
                        try
                        {
                            CamadaDados.Faturamento.PDV.TRegistro_VendaRapida rCupomConvenio =
                            Proc_Commoditties.TProcessaVendaCombustivel.ProcessarVendaCombustivel(lVendaComb,
                                                                                                  fRec.lItemVenda,
                                                                                                  lCfg[0],
                                                                                                  fRec.rConvenio,
                                                                                                  fRec.lCred,
                                                                                                  lPdv[0].Id_pdvstr,
                                                                                                  lSessao[0].Id_sessaostr,
                                                                                                  rCaixa.Id_caixastr,
                                                                                                  LoginPdv,
                                                                                                  Cd_operador);
                            rCupomConvenio.Nr_requisicao = fRec.Nr_requisicao;
                            lVendaComb.ForEach(p =>
                            {
                                p.Km_atual = fRec.Km_atual;
                                p.Placaveiculo = fRec.Placa;
                                p.Nm_motorista = fRec.Nm_motorista;
                                p.Cpf_motorista = fRec.Cpf_motorista;
                                p.Nr_frota = fRec.Nr_frota;
                                p.Cd_clifor = fRec.rConvenio.lClifor[0].Cd_clifor;
                                p.Cd_endereco = fRec.rConvenio.lClifor[0].Cd_endereco;
                                p.Id_convenio = fRec.rConvenio.lClifor[0].Id_convenio;
                                //Gerar pontos fidelizacao
                                CamadaNegocio.PostoCombustivel.TCN_Convenio_Clifor.ProcessarPontosFid(fRec.rConvenio.lClifor[0],
                                                                                                        p,
                                                                                                        fRec.Placa,
                                                                                                        fRec.Cpf_motorista,
                                                                                                        null);
                            });
                            //Calcular media
                            string media = string.Empty;
                            if ((!string.IsNullOrEmpty(fRec.Placa)) &&
                            (fRec.Placa.Trim() != "-") &&
                            (fRec.Km_atual > decimal.Zero))
                            {
                                //Buscar Ultimo Km da Placa
                                object obj_km = new CamadaDados.PostoCombustivel.TCD_VendaCombustivel().BuscarEscalar(
                                                    new TpBusca[]
                                            {
                                                new TpBusca()
                                                {
                                                    vNM_Campo = "replace(a.placaveiculo, '-', '')",
                                                    vOperador = "=",
                                                    vVL_Busca = "'" + fRec.Placa.Replace("-", "") + "'"
                                                }
                                            }, "a.KM_Atual", string.Empty, "a.dt_abastecimento desc", null);
                                if (obj_km != null)
                                    if (fRec.Km_maximo > decimal.Zero)
                                        media = ((fRec.Km_maximo - decimal.Parse(obj_km.ToString()) + fRec.Km_atual) / lVendaComb.Sum(p => p.Volumeabastecido)).ToString("N3", new System.Globalization.CultureInfo("en-US")) + "KM/LT";
                                    else
                                        media = ((fRec.Km_atual - decimal.Parse(obj_km.ToString())) / lVendaComb.Sum(p => p.Volumeabastecido)).ToString("N3", new System.Globalization.CultureInfo("en-US")) + "KM/LT";
                            }
                            CamadaNegocio.Faturamento.PDV.TCN_VendaRapida.GravarVendaRapida(rCupomConvenio,
                                                                                            lVendaComb,
                                                                                            null,
                                                                                            null);
                            rVenda = rCupomConvenio;
                            st_vendagravada = true;
                            //Faturar Direto
                            if (!string.IsNullOrEmpty(fRec.rConvenio.lClifor[0].Tp_faturamento))
                            {
                                //Nota Fiscal Direta
                                if (fRec.rConvenio.lClifor[0].Tp_faturamento.Trim().ToUpper().Equals("NF"))
                                {
                                    CamadaDados.Faturamento.Pedido.TRegistro_Pedido rPedProduto = null;
                                    CamadaDados.Faturamento.Pedido.TRegistro_Pedido rPedServico = null;
                                    try
                                    {
                                        Proc_Commoditties.TProcessarPedidoVendaRapida.ProcessarPedido(fRec.rConvenio.lClifor[0].Cd_clifor,
                                                                                                      fRec.rConvenio.lClifor[0].Cd_endereco,
                                                                                                      fRec.rConvenio.lClifor[0].Tp_preco.Trim().ToUpper().Equals("C"),
                                                                                                      rCupomConvenio.Placa,
                                                                                                      lCfg[0],
                                                                                                      rCupomConvenio.lItem,
                                                                                                      ref rPedProduto,
                                                                                                      ref rPedServico);
                                        CamadaNegocio.Faturamento.PDV.TCN_Pedido_X_VendaRapida.ProcessarPedido(rPedProduto, null);
                                        //Buscar pedido
                                        rPedProduto = CamadaNegocio.Faturamento.Pedido.TCN_Pedido.Busca_Registro_Pedido(rPedProduto.Nr_pedido.ToString(), null);
                                        //Buscar itens pedido
                                        CamadaNegocio.Faturamento.Pedido.TCN_Pedido.Busca_Pedido_Itens(rPedProduto, false, null);
                                        //Se o CMI do pedido gerar financeiro
                                        CamadaDados.Financeiro.Duplicata.TList_RegLanParcela lParcVinculado = new CamadaDados.Financeiro.Duplicata.TList_RegLanParcela();
                                        //Buscar parcelas em aberto dos cupons que estao sendo vinculados
                                        new CamadaDados.Financeiro.Duplicata.TCD_LanParcela().Select(
                                            new TpBusca[]
                                            {
                                                new TpBusca()
                                                {
                                                    vNM_Campo = "isnull(dup.st_registro, 'A')",
                                                    vOperador = "<>",
                                                    vVL_Busca = "'C'"
                                                },
                                                new TpBusca()
                                                {
                                                    vNM_Campo = "isnull(a.st_registro, 'A')",
                                                    vOperador = "in",
                                                    vVL_Busca = "('A', 'P')"
                                                },
                                                new TpBusca()
                                                {
                                                    vNM_Campo = string.Empty,
                                                    vOperador = "exists",
                                                    vVL_Busca = "(select 1 from tb_pdv_cupomfiscal_x_duplicata x " +
                                                                "where x.cd_empresa = a.cd_empresa " +
                                                                "and x.nr_lancto = a.nr_lancto " +
                                                                "and x.cd_empresa = '" + rCupomConvenio.Cd_empresa.Trim() + "' " +
                                                                "and x.id_cupom = " + rCupomConvenio.Id_vendarapidastr + ")"
                                                }
                                            }, 0, string.Empty, "a.dt_vencto, c.nm_clifor", string.Empty).ForEach(v => lParcVinculado.Add(v));
                                        //Gerar Nota Fiscal
                                        CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento rFat =
                                            Proc_Commoditties.TProcessaPedFaturar.ProcessaPedFaturar(rPedProduto, true, lParcVinculado.Sum(p => p.Vl_atual));
                                        //Vincular financeiro a Nota Fiscal
                                        rFat.lParcAgrupar = lParcVinculado;
                                        //Verificar se cliente possui pontos resgatar
                                        object obj_pontos = new CamadaDados.Faturamento.Fidelizacao.TCD_PontosFidelidade().BuscarEscalar(
                                            new TpBusca[]
                                            {
                                                new TpBusca { vNM_Campo = "a.cd_empresa", vOperador = "=", vVL_Busca = "'" + rCupomConvenio.Cd_empresa.Trim() + "'" },
                                                new TpBusca { vNM_Campo = "a.cd_clifor", vOperador = "=", vVL_Busca = "'" + fRec.rConvenio.lClifor[0].Cd_clifor.Trim() + "'" },
                                                new TpBusca { vNM_Campo = "isnull(a.ST_Registro, 'A')", vOperador = "<>", vVL_Busca = "'C'" }
                                            }, "isnull(sum(isnull(a.qt_pontos, 0) - isnull(a.pontos_res, 0)), 0)");
                                        rFat.Dadosadicionais = (!string.IsNullOrEmpty(rFat.Dadosadicionais) ? "\r\n" : string.Empty) + 
                                            "Placa: " + fRec.Placa.Trim() +
                                            " KM: " + fRec.Km_atual.ToString() + 
                                            " Media: " + media + 
                                            " Frota: " + fRec.Nr_frota.Trim() + 
                                            " Requisicao: " + fRec.Nr_requisicao.Trim() +
                                            " Motorista: "+ fRec.Nm_motorista.Trim() +
                                            " CPF: " + fRec.Cpf_motorista.Trim() +
                                            (obj_pontos == null ? string.Empty : " PONTOS RESGATAR: " + obj_pontos.ToString());

                                        //Gravar Nota Fiscal
                                        CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento.GravarFaturamento(rFat, null, null);
                                        //Enviar NFe
                                        using (srvNFE.TFGerenciarNFe fGerNfe = new srvNFE.TFGerenciarNFe())
                                        {
                                            fGerNfe.rNfe = CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento.BuscarNF(rFat.Cd_empresa,
                                                                                                                            rFat.Nr_lanctofiscalstr,
                                                                                                                            null);
                                            fGerNfe.ShowDialog();
                                        }
                                        //Verificar se tem boleto e imprimir o mesmo
                                        CamadaDados.Financeiro.Bloqueto.blListaTitulo lBloqueto = 
                                            new CamadaDados.Financeiro.Bloqueto.TCD_Titulo().Select(
                                                new TpBusca[]
                                                {
                                                    new TpBusca()
                                                    {
                                                        vNM_Campo = string.Empty,
                                                        vOperador = "exists",
                                                        vVL_Busca = "(select 1 from tb_fat_notafiscal_x_duplicata x "+
                                                                    "where x.cd_empresa = c.cd_empresa "+
                                                                    "and x.nr_lanctoduplicata = c.nr_lancto "+
                                                                    "and x.cd_empresa = '" + rFat.Cd_empresa.Trim() + "' "+
                                                                    "and x.nr_lanctofiscal = " + rFat.Nr_lanctofiscalstr + ")"
                                                    }
                                                }, 0, string.Empty);
                                        if (lBloqueto.Count > 0)
                                            //Chamar tela de impressao para o bloqueto
                                            using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
                                            {
                                                fImp.St_enabled_enviaremail = true;
                                                fImp.pCd_clifor = rFat.Cd_clifor;
                                                fImp.pMensagem = "BOLETOS DA NOTA FISCAL Nº" + rFat.Nr_notafiscal.ToString();
                                                if ((fImp.ShowDialog() == DialogResult.OK) || (fImp.pSt_enviaremail))
                                                    FormRelPadrao.TCN_LayoutBloqueto.Imprime_Bloqueto(false,
                                                                                                      lBloqueto,
                                                                                                      fImp.pSt_imprimir,
                                                                                                      fImp.pSt_visualizar,
                                                                                                      fImp.pSt_enviaremail,
                                                                                                      fImp.pSt_exportPdf,
                                                                                                      fImp.Path_exportPdf,
                                                                                                      fImp.pDestinatarios,
                                                                                                      "BOLETO(S) DO DOCUMENTO Nº " + rFat.Nr_notafiscal.ToString(),
                                                                                                      fImp.pDs_mensagem,
                                                                                                      false);
                                            }
                                    }
                                    catch (Exception ex)
                                    {
                                        if (rPedProduto != null)
                                            CamadaNegocio.Faturamento.Pedido.TCN_Pedido.Deleta_Pedido(rPedProduto, null);
                                        throw new Exception(ex.Message.Trim());
                                    }
                                }
                                else
                                    if (lCfg[0].Cd_modelonfce.Trim().Equals("65"))
                                    {
                                        try
                                        {
                                            //Processar cupom fiscal
                                            PDV.TDadosCupom dados = new PDV.TDadosCupom();
                                            dados.lItens = CamadaNegocio.Faturamento.PDV.TCN_VendaRapida_Item.Buscar(rCupomConvenio.Id_vendarapidastr,
                                                                                                                     rCupomConvenio.Cd_empresa,
                                                                                                                     false,
                                                                                                                     string.Empty,
                                                                                                                     null);
                                            dados.rSessao = lSessao[0];
                                            dados.Cd_clifor = fRec.rConvenio.lClifor[0].Cd_clifor;
                                            dados.Nm_clifor = fRec.rConvenio.lClifor[0].Nm_clifor;
                                            dados.CpfCgc = fRec.rConvenio.lClifor[0].Nr_cgc_cpf;
                                            dados.Endereco = string.Empty;
                                            dados.Placa = fRec.Placa;
                                            dados.Km = fRec.Km_atual;
                                            dados.Km_maximo = fRec.Km_maximo;
                                            dados.Nm_motorista = fRec.Nm_motorista;
                                            dados.Cpf_motorista = fRec.Cpf_motorista;
                                            dados.lPortador = rCupomConvenio.lPortador.FindAll(p => p.Vl_pagtoPDV > decimal.Zero);
                                            dados.St_vendacombustivel = true;
                                            dados.St_convenio = true;
                                            dados.St_pedirCliente = fRec.rConvenio.lClifor[0].Nr_cgc_cpf.SoNumero().Length != 11 &&
                                                                    fRec.rConvenio.lClifor[0].Nr_cgc_cpf.SoNumero().Length != 14;
                                            dados.St_faturardireto = fRec.rConvenio.lClifor[0].St_faturardiretobool;
                                            //Verificar se cliente possui pontos resgatar
                                            object obj_pontos = new CamadaDados.Faturamento.Fidelizacao.TCD_PontosFidelidade().BuscarEscalar(
                                                new TpBusca[]
                                                {
                                                    new TpBusca { vNM_Campo = "a.cd_empresa", vOperador = "=", vVL_Busca = "'" + rCupomConvenio.Cd_empresa.Trim() + "'" },
                                                    new TpBusca { vNM_Campo = "a.cd_clifor", vOperador = "=", vVL_Busca = "'" + fRec.rConvenio.lClifor[0].Cd_clifor.Trim() + "'" },
                                                    new TpBusca { vNM_Campo = "isnull(a.ST_Registro, 'A')", vOperador = "<>", vVL_Busca = "'C'" }
                                                }, "isnull(sum(isnull(a.qt_pontos, 0) - isnull(a.pontos_res, 0)), 0)");
                                            dados.Mensagem = "Placa: " + fRec.Placa.Trim() + " Frota: " + fRec.Nr_frota.Trim() + " Requisicao: " + fRec.Nr_requisicao.Trim() +
                                                             "\r\nKM: " + fRec.Km_atual.ToString("N0", new System.Globalization.CultureInfo("pt-BR")) + " " + media.Trim() +
                                                             "\r\nMedia: " + media + " KM/LT" +
                                                             "\r\nMotorista: " + fRec.Nm_motorista.Trim() +
                                                             "\r\nCPF: " + fRec.Cpf_motorista.Trim() +
                                                             (obj_pontos == null ? string.Empty : "\r\n\r\nPONTOS RESGATAR: " + obj_pontos.ToString());
                                            CamadaDados.Faturamento.PDV.TRegistro_NFCe rNFCe = new PDV.TGerenciarCupom().GerarNFCe(dados, true);
                                            if (rNFCe != null)
                                                if (!rNFCe.St_contingencia)
                                                {
                                                    using (NFCe.TFGerenciarNFCe fGerNfe = new NFCe.TFGerenciarNFCe())
                                                    {
                                                        rNFCe = CamadaNegocio.Faturamento.PDV.TCN_NFCe.BuscarNFCe(rNFCe.Cd_empresa,
                                                                                                                  rNFCe.Id_nfcestr,
                                                                                                                  null);
                                                        fGerNfe.rNFCe = rNFCe;
                                                        fGerNfe.ShowDialog();
                                                    }
                                                    if (dados.St_faturardireto)
                                                        if (new CamadaDados.Faturamento.NFCe.TCD_Lote_X_NFCe().BuscarEscalar(
                                                            new TpBusca[]
                                                            {
                                                                new TpBusca()
                                                                {
                                                                    vNM_Campo = "a.cd_empresa",
                                                                    vOperador = "=",
                                                                    vVL_Busca = "'" + rNFCe.Cd_empresa.Trim() + "'"
                                                                },
                                                                new TpBusca()
                                                                {
                                                                    vNM_Campo = "a.id_cupom",
                                                                    vOperador = "=",
                                                                    vVL_Busca = rNFCe.Id_nfcestr
                                                                },
                                                                new TpBusca()
                                                                {
                                                                    vNM_Campo = "a.status",
                                                                    vOperador = "=",
                                                                    vVL_Busca = "'100'"
                                                                }
                                                            }, "1") != null)
                                                            ProcessaCfVincular(new List<CamadaDados.Faturamento.PDV.TRegistro_NFCe> { rNFCe }, rNFCe.Cd_empresa, rNFCe.Cd_clifor);
                                                }
                                                else
                                                {
                                                    FormRelPadrao.Relatorio Rel = new FormRelPadrao.Relatorio();
                                                    BindingSource dts = new BindingSource();
                                                    dts.DataSource = new CamadaDados.Faturamento.PDV.TList_NFCe_Item();
                                                    Rel.DTS_Relatorio = dts;// bsItens;
                                                    //DTS Cupom
                                                    BindingSource bsNFCe = new BindingSource();
                                                    bsNFCe.DataSource = CamadaNegocio.Faturamento.PDV.TCN_NFCe.Buscar(rNFCe.Id_nfcestr,
                                                                                                                      string.Empty,
                                                                                                                      rNFCe.Cd_empresa,
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
                                                                                                                      false,
                                                                                                                      string.Empty,
                                                                                                                      string.Empty,
                                                                                                                      1,
                                                                                                                      null);
                                                    (bsNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).lItem =
                                                        CamadaNegocio.Faturamento.PDV.TCN_NFCe_Item.Buscar((bsNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).Id_nfcestr,
                                                                                                           (bsNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).Cd_empresa,
                                                                                                           string.Empty,
                                                                                                           null);
                                                    NFCe.TGerarQRCode.GerarQRCode2(bsNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe);
                                                    Rel.Adiciona_DataSource("DTS_NFCE", bsNFCe);
                                                    //Buscar Empresa
                                                    BindingSource bsEmpresa = new BindingSource();
                                                    bsEmpresa.DataSource = CamadaNegocio.Diversos.TCN_CadEmpresa.Busca(rNFCe.Cd_empresa,
                                                                                                                        string.Empty,
                                                                                                                        string.Empty,
                                                                                                                        null);
                                                    Rel.Adiciona_DataSource("DTS_EMP", bsEmpresa);
                                                    //Forma Pagamento
                                                    BindingSource bsPagto = new BindingSource();
                                                    CamadaDados.Financeiro.Duplicata.TList_RegLanDuplicata lDup =
                                                    new CamadaDados.Financeiro.Duplicata.TCD_LanDuplicata().Select(
                                                    new TpBusca[]
                                                    {
                                                        new TpBusca()
                                                        {
                                                            vNM_Campo = string.Empty,
                                                            vOperador = "exists",
                                                            vVL_Busca = "(select 1 from TB_PDV_CupomFiscal_X_Duplicata x " +
                                                                        "inner join TB_PDV_Cupom_X_VendaRapida y " +
                                                                        "on x.cd_empresa = y.cd_empresa " +
                                                                        "and x.id_cupom = y.id_vendarapida " +
                                                                        "where x.cd_empresa = a.cd_empresa " +
                                                                        "and x.Nr_Lancto = a.Nr_Lancto " +
                                                                        "and y.cd_empresa = '" + rNFCe.Cd_empresa.Trim() + "' " +
                                                                        "and y.id_cupom = " + rNFCe.Id_nfcestr + ")"
                                                        }
                                                    }, 1, string.Empty);
                                                    if (lDup.Count > 0)
                                                        bsPagto.DataSource = new List<CamadaDados.Faturamento.PDV.TRegistro_MovCaixa>()
                                                                                {
                                                                                    new CamadaDados.Faturamento.PDV.TRegistro_MovCaixa()
                                                                                    {
                                                                                        Tp_portador = "05",
                                                                                        Vl_recebido = lDup[0].Vl_documento
                                                                                    }
                                                                                };
                                                    else
                                                        bsPagto.DataSource = new CamadaDados.Faturamento.PDV.TCD_CaixaPDV().SelectMovCaixa(
                                                                                new TpBusca[]
                                                                                {
                                                                                    new TpBusca()
                                                                                    {
                                                                                        vNM_Campo = string.Empty,
                                                                                        vOperador = "exists",
                                                                                        vVL_Busca = "(select 1 from tb_pdv_cupom_x_vendarapida x " +
                                                                                                    "where x.cd_empresa = a.cd_empresa " +
                                                                                                    "and x.id_vendarapida = a.id_cupom " +
                                                                                                    "and x.cd_empresa = '" + rNFCe.Cd_empresa.Trim() + "' " +
                                                                                                    "and x.id_cupom = " + rNFCe.Id_nfcestr + ")"
                                                                                    }
                                                                                }, string.Empty).GroupBy(v => v.Tp_portador,
                                                                                                    (aux, venda) =>
                                                                                                        new
                                                                                                        {
                                                                                                            tp_portador = aux,
                                                                                                            Vl_recebido = venda.Sum(x => x.Vl_recebido),
                                                                                                            Vl_troco_ch = venda.Sum(x => x.Vl_troco_ch),
                                                                                                            Vl_troco_dh = venda.Sum(x => x.Vl_troco_dh)
                                                                                                        }).ToList();
                                                    Rel.Adiciona_DataSource("DTS_PAGTO", bsPagto);
                                                    //Parametros
                                                    Rel.Parametros_Relatorio.Add("TOT_IMP_APROX", (bsNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).lItem.Sum(p => p.Vl_imposto_Aprox));
                                                    Rel.Parametros_Relatorio.Add("QTD_ITENS", (bsNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).lItem.Count);
                                                    Rel.Parametros_Relatorio.Add("TOT_SUBTOTAL", (bsNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).lItem.Sum(p => p.Vl_subtotal));
                                                    Rel.Parametros_Relatorio.Add("TOT_ACRESCIMO", (bsNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).lItem.Sum(p => p.Vl_acrescimo));
                                                    Rel.Parametros_Relatorio.Add("TOT_DESCONTO", (bsNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).lItem.Sum(p => p.Vl_desconto));
                                                    Rel.Parametros_Relatorio.Add("ST_VIAEMPRESA", "N");
                                                    object obj = new CamadaDados.Faturamento.NFCe.TCD_LoteNFCe().BuscarEscalar(
                                                                    new TpBusca[]
                                                                    {
                                                                        new TpBusca()
                                                                        {
                                                                            vNM_Campo = string.Empty,
                                                                            vOperador = "exists",
                                                                            vVL_Busca = "(select 1 from TB_FAT_Lote_X_NFCe x " +
                                                                                        "where x.cd_empresa = a.cd_empresa " +
                                                                                        "and x.id_lote = a.id_lote " +
                                                                                        "and x.status = '100')"
                                                                        }
                                                                    }, "a.tp_ambiente");
                                                    Rel.Parametros_Relatorio.Add("TP_AMBIENTE", obj == null ? string.Empty : obj.ToString());
                                                    string dadoscf = CamadaNegocio.Faturamento.PDV.TCN_NFCe.BuscarPlacaKM((bsNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).Cd_empresa,
                                                                                                                          (bsNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).Id_nfcestr,
                                                                                                                          null);
                                                    if (!string.IsNullOrEmpty(dadoscf))
                                                    {
                                                        string[] linhas = dadoscf.Split(new char[] { ':' });
                                                        string placarel = string.Empty;
                                                        string km = string.Empty;
                                                        string frota = string.Empty;
                                                        string requisicao = string.Empty;
                                                        string nm_motorista = string.Empty;
                                                        string cpf_motorista = string.Empty;
                                                        media = string.Empty;
                                                        string virg = string.Empty;
                                                        foreach (string s in linhas)
                                                        {
                                                            string[] colunas = s.Split(new char[] { '/' });
                                                            placarel += virg + colunas[0];
                                                            km += virg + colunas[1];
                                                            frota += virg + colunas[2];
                                                            requisicao += virg + colunas[3];
                                                            nm_motorista += virg + colunas[4];
                                                            cpf_motorista += virg + colunas[5];
                                                            media += virg + colunas[6];
                                                            virg = ",";
                                                        }
                                                        if (!string.IsNullOrEmpty(placarel))
                                                            Rel.Parametros_Relatorio.Add("PLACA", placarel);
                                                        if (!string.IsNullOrEmpty(km))
                                                            Rel.Parametros_Relatorio.Add("KM", km);
                                                        if (!string.IsNullOrEmpty(media))
                                                            Rel.Parametros_Relatorio.Add("MEDIA", media + " KM/LT");
                                                        if (!string.IsNullOrEmpty(frota))
                                                            Rel.Parametros_Relatorio.Add("FROTA", frota);
                                                        //if (!string.IsNullOrEmpty(media))
                                                        //    Rel.Parametros_Relatorio.Add("MEDIA", media);
                                                        if (!string.IsNullOrEmpty(requisicao))
                                                            Rel.Parametros_Relatorio.Add("REQUISICAO", requisicao);
                                                        if (!string.IsNullOrEmpty(nm_motorista))
                                                            Rel.Parametros_Relatorio.Add("NM_MOTORISTA", nm_motorista);
                                                        if (!string.IsNullOrEmpty(cpf_motorista))
                                                            Rel.Parametros_Relatorio.Add("CPF_MOTORISTA", cpf_motorista);
                                                    }
                                                    Rel.Nome_Relatorio = "DANFE_NFCE";
                                                    Rel.NM_Classe = "TFConsultaFrenteCaixa";
                                                    Rel.Modulo = "FAT";
                                                    Rel.Ident = "DANFE_NFCE";
                                                    if (CamadaNegocio.ConfigGer.TCN_CadParamGer.BuscaVlBool("ST_IMP_DANFE_NFCE_DETALHADA", null))
                                                    {
                                                        BindingSource bsItens = new BindingSource();
                                                        bsItens.DataSource = (bsNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).lItem;
                                                        Rel.DTS_Relatorio = bsItens;
                                                    }
                                                    if (rNFCe.Id_contingencia.HasValue)
                                                        if (Rel.Parametros_Relatorio.ContainsKey("ST_VIAEMPRESA"))
                                                            Rel.Parametros_Relatorio["ST_VIAEMPRESA"] = "S";
                                                        else
                                                            Rel.Parametros_Relatorio.Add("ST_VIAEMPRESA", "S");
                                                    //Verificar se existe Impressora padrão para o PDV
                                                    obj = new CamadaDados.Faturamento.Cadastros.TCD_PontoVenda().BuscarEscalar(
                                                            new TpBusca[]
                                                            {
                                                                new TpBusca()
                                                                {
                                                                    vNM_Campo = "a.cd_terminal",
                                                                    vOperador = "=",
                                                                    vVL_Busca = "'" + Utils.Parametros.pubTerminal.Trim() + "'"
                                                                }
                                                            }, "a.impressorapadrao");
                                                    string print = obj == null ? string.Empty : obj.ToString();
                                                    if (string.IsNullOrEmpty(print))
                                                        using (Parametros.Diversos.TFListaImpressoras fLista = new Parametros.Diversos.TFListaImpressoras())
                                                        {
                                                            if (fLista.ShowDialog() == DialogResult.OK)
                                                                if (!string.IsNullOrEmpty(fLista.Impressora))
                                                                    print = fLista.Impressora;

                                                        }
                                                    //Imprimir
                                                    Rel.ImprimiGraficoReduzida(print,
                                                                               true,
                                                                               false,
                                                                               null,
                                                                               string.Empty,
                                                                               string.Empty,
                                                                               1);
                                                    if ((bsNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).Id_contingencia.HasValue && 
                                                        (bsNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).rCfgNFCe.Tp_ambiente_nfce.Equals(1))
                                                        Rel.ImprimiGraficoReduzida(print,
                                                                                   true,
                                                                                   false,
                                                                                   null,
                                                                                   string.Empty,
                                                                                   string.Empty,
                                                                                   1);
                                                }
                                        }
                                        catch (Exception ex)
                                        {
                                            MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        }
                                        finally
                                        {
                                            //Verificar se tem boleto e imprimir o mesmo
                                            CamadaDados.Financeiro.Bloqueto.blListaTitulo lBloqueto =
                                                new CamadaDados.Financeiro.Bloqueto.TCD_Titulo().Select(
                                                    new TpBusca[]
                                                {
                                                    new TpBusca()
                                                    {
                                                        vNM_Campo = string.Empty,
                                                        vOperador = "exists",
                                                        vVL_Busca = "(select 1 from tb_pdv_cupomfiscal_x_duplicata x "+
                                                                    "where x.cd_empresa = c.cd_empresa "+
                                                                    "and x.nr_lancto = c.nr_lancto "+
                                                                    "and x.cd_empresa = '" + rCupomConvenio.Cd_empresa.Trim() + "' "+
                                                                    "and x.id_cupom = " + rCupomConvenio.Id_vendarapidastr + ")"
                                                    }
                                                }, 0, string.Empty);
                                            if (lBloqueto.Count > 0)
                                                //Chamar tela de impressao para o bloqueto
                                                using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
                                                {
                                                    fImp.St_enabled_enviaremail = true;
                                                    fImp.pCd_clifor = rCupomConvenio.Cd_clifor;
                                                    fImp.pMensagem = "BOLETOS DO DOCUMENTO Nº" + rCupomConvenio.Id_vendarapidastr;
                                                    if ((fImp.ShowDialog() == DialogResult.OK) || (fImp.pSt_enviaremail))
                                                        FormRelPadrao.TCN_LayoutBloqueto.Imprime_Bloqueto(false,
                                                                                                          lBloqueto,
                                                                                                          fImp.pSt_imprimir,
                                                                                                          fImp.pSt_visualizar,
                                                                                                          fImp.pSt_enviaremail,
                                                                                                          fImp.pSt_exportPdf,
                                                                                                          fImp.Path_exportPdf,
                                                                                                          fImp.pDestinatarios,
                                                                                                          "BOLETO(S) DO DOCUMENTO Nº " + rCupomConvenio.Id_vendarapidastr,
                                                                                                          fImp.pDs_mensagem,
                                                                                                          false);
                                                }
                                        }
                                    }
                                    else
                                        MessageBox.Show("Não existe série modelo 65 configurada na CFG.Frente de Caixa!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                using (TFGerarDocFiscal fDoc = new TFGerarDocFiscal())
                                {
                                    if (fDoc.ShowDialog() == DialogResult.OK)
                                        if (fDoc.St_nfe)
                                        {
                                            CamadaDados.Faturamento.Pedido.TRegistro_Pedido rPed = null;
                                            CamadaDados.Faturamento.Pedido.TRegistro_Pedido rPedServico = null;
                                            try
                                            {
                                                Proc_Commoditties.TProcessarPedidoVendaRapida.ProcessarPedido(fRec.rConvenio.lClifor[0].Cd_clifor,
                                                                                                              fRec.rConvenio.lClifor[0].Cd_endereco,
                                                                                                              fRec.rConvenio.lClifor[0].Tp_preco.Trim().ToUpper().Equals("C"),
                                                                                                              rCupomConvenio.Placa,
                                                                                                              lCfg[0],
                                                                                                              rCupomConvenio.lItem,
                                                                                                              ref rPed,
                                                                                                              ref rPedServico);
                                                CamadaNegocio.Faturamento.PDV.TCN_Pedido_X_VendaRapida.ProcessarPedido(rPed, null);
                                                //Buscar pedido
                                                rPed = CamadaNegocio.Faturamento.Pedido.TCN_Pedido.Busca_Registro_Pedido(rPed.Nr_pedido.ToString(), null);
                                                //Buscar itens pedido
                                                CamadaNegocio.Faturamento.Pedido.TCN_Pedido.Busca_Pedido_Itens(rPed, false, null);
                                                //Se o CMI do pedido gerar financeiro
                                                CamadaDados.Financeiro.Duplicata.TList_RegLanParcela lParcVinculado = new CamadaDados.Financeiro.Duplicata.TList_RegLanParcela();
                                                //Buscar parcelas em aberto dos cupons que estao sendo vinculados
                                                new CamadaDados.Financeiro.Duplicata.TCD_LanParcela().Select(
                                                    new TpBusca[]
                                                    {
                                                        new TpBusca()
                                                        {
                                                            vNM_Campo = "isnull(dup.st_registro, 'A')",
                                                            vOperador = "<>",
                                                            vVL_Busca = "'C'"
                                                        },
                                                        new TpBusca()
                                                        {
                                                            vNM_Campo = "isnull(a.st_registro, 'A')",
                                                            vOperador = "in",
                                                            vVL_Busca = "('A', 'P')"
                                                        },
                                                        new TpBusca()
                                                        {
                                                            vNM_Campo = string.Empty,
                                                            vOperador = "exists",
                                                            vVL_Busca = "(select 1 from tb_pdv_cupomfiscal_x_duplicata x " +
                                                                        "where x.cd_empresa = a.cd_empresa " +
                                                                        "and x.nr_lancto = a.nr_lancto " +
                                                                        "and x.cd_empresa = '" + rCupomConvenio.Cd_empresa.Trim() + "' " +
                                                                        "and x.id_cupom = " + rCupomConvenio.Id_vendarapidastr + ")"
                                                        }
                                                    }, 0, string.Empty, "a.dt_vencto, c.nm_clifor", string.Empty).ForEach(v => lParcVinculado.Add(v));
                                                //Gerar Nota Fiscal
                                                CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento rFat =
                                                    Proc_Commoditties.TProcessaPedFaturar.ProcessaPedFaturar(rPed, true, lParcVinculado.Sum(p => p.Vl_atual));
                                                //Vincular financeiro a Nota Fiscal
                                                rFat.lParcAgrupar = lParcVinculado;
                                                //Verificar se cliente possui pontos resgatar
                                                object obj_pontos = new CamadaDados.Faturamento.Fidelizacao.TCD_PontosFidelidade().BuscarEscalar(
                                                    new TpBusca[]
                                                    {
                                                        new TpBusca { vNM_Campo = "a.cd_empresa", vOperador = "=", vVL_Busca = "'" + rCupomConvenio.Cd_empresa.Trim() + "'" },
                                                        new TpBusca { vNM_Campo = "a.cd_clifor", vOperador = "=", vVL_Busca = "'" + fRec.rConvenio.lClifor[0].Cd_clifor.Trim() + "'" },
                                                        new TpBusca { vNM_Campo = "isnull(a.ST_Registro, 'A')", vOperador = "<>", vVL_Busca = "'C'" }
                                                    }, "isnull(sum(isnull(a.qt_pontos, 0) - isnull(a.pontos_res, 0)), 0)");
                                                rFat.Dadosadicionais = (!string.IsNullOrEmpty(rFat.Dadosadicionais) ? "\r\n" : string.Empty) +
                                                    "Placa: " + fRec.Placa.Trim() +
                                                    " KM: " + fRec.Km_atual.ToString() +
                                                    " Media: " + media +
                                                    " Frota: " + fRec.Nr_frota.Trim() +
                                                    " Requisicao: " + fRec.Nr_requisicao.Trim() +
                                                    " Motorista: " + fRec.Nm_motorista.Trim() +
                                                    " CPF: " + fRec.Cpf_motorista.Trim() +
                                                    (obj_pontos == null ? string.Empty : " PONTOS RESGATAR: " + obj_pontos.ToString());

                                                //Gravar Nota Fiscal
                                                CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento.GravarFaturamento(rFat, null, null);
                                                using (srvNFE.TFGerenciarNFe fGerNfe = new srvNFE.TFGerenciarNFe())
                                                {
                                                    fGerNfe.rNfe = CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento.BuscarNF(rFat.Cd_empresa,
                                                                                                                                    rFat.Nr_lanctofiscalstr,
                                                                                                                                    null);
                                                    fGerNfe.ShowDialog();
                                                }
                                                //Verificar se tem boleto e imprimir o mesmo
                                                CamadaDados.Financeiro.Bloqueto.blListaTitulo lBloqueto =
                                                    new CamadaDados.Financeiro.Bloqueto.TCD_Titulo().Select(
                                                        new TpBusca[]
                                                {
                                                    new TpBusca()
                                                    {
                                                        vNM_Campo = string.Empty,
                                                        vOperador = "exists",
                                                        vVL_Busca = "(select 1 from tb_fat_notafiscal_x_duplicata x "+
                                                                    "where x.cd_empresa = c.cd_empresa "+
                                                                    "and x.nr_lanctoduplicata = c.nr_lancto "+
                                                                    "and x.cd_empresa = '" + rFat.Cd_empresa.Trim() + "' "+
                                                                    "and x.nr_lanctofiscal = " + rFat.Nr_lanctofiscalstr + ")"
                                                    }
                                                }, 0, string.Empty);
                                                if (lBloqueto.Count > 0)
                                                    //Chamar tela de impressao para o bloqueto
                                                    using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
                                                    {
                                                        fImp.St_enabled_enviaremail = true;
                                                        fImp.pCd_clifor = rFat.Cd_clifor;
                                                        fImp.pMensagem = "BOLETOS DA NOTA FISCAL Nº" + rFat.Nr_notafiscal.ToString();
                                                        if ((fImp.ShowDialog() == DialogResult.OK) || (fImp.pSt_enviaremail))
                                                            FormRelPadrao.TCN_LayoutBloqueto.Imprime_Bloqueto(false,
                                                                                                              lBloqueto,
                                                                                                              fImp.pSt_imprimir,
                                                                                                              fImp.pSt_visualizar,
                                                                                                              fImp.pSt_enviaremail,
                                                                                                              fImp.pSt_exportPdf,
                                                                                                              fImp.Path_exportPdf,
                                                                                                              fImp.pDestinatarios,
                                                                                                              "BOLETO(S) DO DOCUMENTO Nº " + rFat.Nr_notafiscal.ToString(),
                                                                                                              fImp.pDs_mensagem,
                                                                                                              false);
                                                    }
                                            }
                                            catch (Exception ex)
                                            {
                                                if (rPed != null)
                                                    CamadaNegocio.Faturamento.Pedido.TCN_Pedido.Deleta_Pedido(rPed, null);
                                                throw new Exception(ex.Message.Trim());
                                            }
                                        }
                                        else
                                        {
                                            if (lCfg[0].Cd_modelonfce.Trim().Equals("65"))
                                            {
                                                try
                                                {
                                                    //Buscar dados clifor
                                                    object cgc_pcf = new CamadaDados.Financeiro.Cadastros.TCD_CadClifor().BuscarEscalar(
                                                                        new TpBusca[]
                                                                    {
                                                                        new TpBusca()
                                                                        {
                                                                            vNM_Campo = "a.cd_clifor",
                                                                            vOperador = "=",
                                                                            vVL_Busca = "'" + fRec.rConvenio.lClifor[0].Cd_clifor.Trim() + "'"
                                                                        }
                                                                    }, "isnull(a.nr_cgc, a.nr_cpf)");
                                                    //Processar Cupom Fiscal
                                                    PDV.TDadosCupom dados = new PDV.TDadosCupom();
                                                    dados.lItens = CamadaNegocio.Faturamento.PDV.TCN_VendaRapida_Item.Buscar(rCupomConvenio.Id_vendarapidastr,
                                                                                                                             rCupomConvenio.Cd_empresa,
                                                                                                                             false,
                                                                                                                             string.Empty,
                                                                                                                             null);
                                                    dados.rSessao = lSessao[0];
                                                    dados.Cd_clifor = fRec.rConvenio.lClifor[0].Cd_clifor;
                                                    dados.Nm_clifor = fRec.rConvenio.lClifor[0].Nm_clifor;
                                                    dados.CpfCgc = cgc_pcf != null ? cgc_pcf.ToString().SoNumero() : string.Empty;
                                                    dados.Cd_endereco = fRec.rConvenio.lClifor[0].Cd_endereco;
                                                    dados.Endereco = fRec.rConvenio.lClifor[0].Ds_endereco;
                                                    dados.Placa = fRec.Placa;
                                                    dados.Km = fRec.Km_atual;
                                                    dados.Km_maximo = fRec.Km_maximo;
                                                    dados.Nm_motorista = fRec.Nm_motorista;
                                                    dados.Cpf_motorista = fRec.Cpf_motorista;
                                                    dados.lPortador = rCupomConvenio.lPortador.FindAll(p => p.Vl_pagtoPDV > decimal.Zero);
                                                    dados.St_vendacombustivel = true;
                                                    dados.St_convenio = true;
                                                    dados.St_pedirCliente = fRec.rConvenio.lClifor[0].Nr_cgc_cpf.SoNumero().Length != 11 &&
                                                                            fRec.rConvenio.lClifor[0].Nr_cgc_cpf.SoNumero().Length != 14;
                                                    dados.St_faturardireto = fRec.rConvenio.lClifor[0].St_faturardiretobool;
                                                    //Verificar se cliente possui pontos resgatar
                                                    object obj_pontos = new CamadaDados.Faturamento.Fidelizacao.TCD_PontosFidelidade().BuscarEscalar(
                                                        new TpBusca[]
                                                        {
                                                            new TpBusca { vNM_Campo = "a.cd_empresa", vOperador = "=", vVL_Busca = "'" + rCupomConvenio.Cd_empresa.Trim() + "'" },
                                                            new TpBusca { vNM_Campo = "a.cd_clifor", vOperador = "=", vVL_Busca = "'" + fRec.rConvenio.lClifor[0].Cd_clifor.Trim() + "'" },
                                                            new TpBusca { vNM_Campo = "isnull(a.ST_Registro, 'A')", vOperador = "<>", vVL_Busca = "'C'" }
                                                        }, "isnull(sum(isnull(a.qt_pontos, 0) - isnull(a.pontos_res, 0)), 0)");
                                                    dados.Mensagem = "Placa: " + fRec.Placa.Trim() + " Frota: " + fRec.Nr_frota.Trim() + " Requisicao: " + fRec.Nr_requisicao.Trim() +
                                                                     "\r\nKM: " + fRec.Km_atual.ToString("N0", new System.Globalization.CultureInfo("pt-BR")) + " " + media.Trim() +
                                                                     "\r\nMedia: " + media + " KM/LT" +
                                                                     "\r\nMotorista: " + fRec.Nm_motorista.Trim() +
                                                                     "\r\nCPF: " + fRec.Cpf_motorista.Trim() +
                                                                     (obj_pontos == null ? string.Empty : "\r\n\r\nPONTOS RESGATAR: " + obj_pontos.ToString());
                                                    CamadaDados.Faturamento.PDV.TRegistro_NFCe rNFCe = new PDV.TGerenciarCupom().GerarNFCe(dados, true);
                                                    //if (rNFCe != null)
                                                        if (!rNFCe.St_contingencia)
                                                        {
                                                            using (NFCe.TFGerenciarNFCe fGerNfe = new NFCe.TFGerenciarNFCe())
                                                            {
                                                                rNFCe = CamadaNegocio.Faturamento.PDV.TCN_NFCe.BuscarNFCe(rNFCe.Cd_empresa,
                                                                                                                          rNFCe.Id_nfcestr,
                                                                                                                          null);
                                                                fGerNfe.rNFCe = rNFCe;
                                                                fGerNfe.ShowDialog();
                                                            }
                                                            if (dados.St_faturardireto)
                                                                if (new CamadaDados.Faturamento.NFCe.TCD_Lote_X_NFCe().BuscarEscalar(
                                                                        new TpBusca[]
                                                                        {
                                                                            new TpBusca()
                                                                            {
                                                                                vNM_Campo = "a.cd_empresa",
                                                                                vOperador = "=",
                                                                                vVL_Busca = "'" + rNFCe.Cd_empresa.Trim() + "'"
                                                                            },
                                                                            new TpBusca()
                                                                            {
                                                                                vNM_Campo = "a.id_cupom",
                                                                                vOperador = "=",
                                                                                vVL_Busca = rNFCe.Id_nfcestr
                                                                            },
                                                                            new TpBusca()
                                                                            {
                                                                                vNM_Campo = "a.status",
                                                                                vOperador = "=",
                                                                                vVL_Busca = "'100'"
                                                                            }
                                                                        }, "1") != null)
                                                                    ProcessaCfVincular(new List<CamadaDados.Faturamento.PDV.TRegistro_NFCe> { rNFCe }, rNFCe.Cd_empresa, rNFCe.Cd_clifor);
                                                        }
                                                        else
                                                        {
                                                            FormRelPadrao.Relatorio Rel = new FormRelPadrao.Relatorio();
                                                            BindingSource dts = new BindingSource();
                                                            dts.DataSource = new CamadaDados.Faturamento.PDV.TList_NFCe_Item();
                                                            Rel.DTS_Relatorio = dts;// bsItens;
                                                            //DTS Cupom
                                                            BindingSource bsNFCe = new BindingSource();
                                                            bsNFCe.DataSource = CamadaNegocio.Faturamento.PDV.TCN_NFCe.BuscarNFCe(rNFCe.Cd_empresa,
                                                                                                                                  rNFCe.Id_nfcestr,
                                                                                                                                  null);
                                                            NFCe.TGerarQRCode.GerarQRCode2(bsNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe);
                                                            Rel.Adiciona_DataSource("DTS_NFCE", bsNFCe);
                                                            //Buscar Empresa
                                                            BindingSource bsEmpresa = new BindingSource();
                                                        bsEmpresa.DataSource = new CamadaDados.Diversos.TList_CadEmpresa { (bsNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).rEmpresa };
                                                            Rel.Adiciona_DataSource("DTS_EMP", bsEmpresa);
                                                            //Forma Pagamento
                                                            BindingSource bsPagto = new BindingSource();
                                                            CamadaDados.Financeiro.Duplicata.TList_RegLanDuplicata lDup =
                                                            new CamadaDados.Financeiro.Duplicata.TCD_LanDuplicata().Select(
                                                            new TpBusca[]
                                                            {
                                                                new TpBusca()
                                                                {
                                                                    vNM_Campo = string.Empty,
                                                                    vOperador = "exists",
                                                                    vVL_Busca = "(select 1 from TB_PDV_CupomFiscal_X_Duplicata x " +
                                                                                "inner join TB_PDV_Cupom_X_VendaRapida y " +
                                                                                "on x.cd_empresa = y.cd_empresa " +
                                                                                "and x.id_cupom = y.id_vendarapida " +
                                                                                "where x.cd_empresa = a.cd_empresa " +
                                                                                "and x.Nr_Lancto = a.Nr_Lancto " +
                                                                                "and y.cd_empresa = '" + rNFCe.Cd_empresa.Trim() + "' " +
                                                                                "and y.id_cupom = " + rNFCe.Id_nfcestr + ")"
                                                                }
                                                            }, 1, string.Empty);
                                                            if (lDup.Count > 0)
                                                                bsPagto.DataSource = new List<CamadaDados.Faturamento.PDV.TRegistro_MovCaixa>()
                                                                                        {
                                                                                            new CamadaDados.Faturamento.PDV.TRegistro_MovCaixa()
                                                                                            {
                                                                                                Tp_portador = "05",
                                                                                                Vl_recebido = lDup[0].Vl_documento
                                                                                            }
                                                                                        };
                                                            else
                                                                bsPagto.DataSource = new CamadaDados.Faturamento.PDV.TCD_CaixaPDV().SelectMovCaixa(
                                                                                        new TpBusca[]
                                                                                        {
                                                                                            new TpBusca()
                                                                                            {
                                                                                                vNM_Campo = string.Empty,
                                                                                                vOperador = "exists",
                                                                                                vVL_Busca = "(select 1 from tb_pdv_cupom_x_vendarapida x " +
                                                                                                            "where x.cd_empresa = a.cd_empresa " +
                                                                                                            "and x.id_vendarapida = a.id_cupom " +
                                                                                                            "and x.cd_empresa = '" + rNFCe.Cd_empresa.Trim() + "' " +
                                                                                                            "and x.id_cupom = " + rNFCe.Id_nfcestr + ")"
                                                                                            }
                                                                                        }, string.Empty).GroupBy(v => v.Tp_portador,
                                                                                                            (aux, venda) =>
                                                                                                                new
                                                                                                                {
                                                                                                                    tp_portador = aux,
                                                                                                                    Vl_recebido = venda.Sum(x => x.Vl_recebido),
                                                                                                                    Vl_troco_ch = venda.Sum(x => x.Vl_troco_ch),
                                                                                                                    Vl_troco_dh = venda.Sum(x => x.Vl_troco_dh)
                                                                                                                }).ToList();
                                                            Rel.Adiciona_DataSource("DTS_PAGTO", bsPagto);
                                                            //Parametros
                                                            Rel.Parametros_Relatorio.Add("TOT_IMP_APROX", (bsNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).lItem.Sum(p => p.Vl_imposto_Aprox));
                                                            Rel.Parametros_Relatorio.Add("QTD_ITENS", (bsNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).lItem.Count);
                                                            Rel.Parametros_Relatorio.Add("TOT_SUBTOTAL", (bsNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).lItem.Sum(p => p.Vl_subtotal));
                                                            Rel.Parametros_Relatorio.Add("TOT_ACRESCIMO", (bsNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).lItem.Sum(p => p.Vl_acrescimo));
                                                            Rel.Parametros_Relatorio.Add("TOT_DESCONTO", (bsNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).lItem.Sum(p => p.Vl_desconto));
                                                            Rel.Parametros_Relatorio.Add("ST_VIAEMPRESA", "N");
                                                            object obj = new CamadaDados.Faturamento.NFCe.TCD_LoteNFCe().BuscarEscalar(
                                                                            new TpBusca[]
                                                                            {
                                                                                new TpBusca()
                                                                                {
                                                                                    vNM_Campo = string.Empty,
                                                                                    vOperador = "exists",
                                                                                    vVL_Busca = "(select 1 from TB_FAT_Lote_X_NFCe x " +
                                                                                                "where x.cd_empresa = a.cd_empresa " +
                                                                                                "and x.id_lote = a.id_lote " +
                                                                                                "and x.status = '100')"
                                                                                }
                                                                            }, "a.tp_ambiente");
                                                            Rel.Parametros_Relatorio.Add("TP_AMBIENTE", obj == null ? string.Empty : obj.ToString());
                                                            string dadoscf = CamadaNegocio.Faturamento.PDV.TCN_NFCe.BuscarPlacaKM((bsNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).Cd_empresa,
                                                                                                                                 (bsNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).Id_nfcestr,
                                                                                                                                 null);
                                                            if (!string.IsNullOrEmpty(dadoscf))
                                                            {
                                                                string[] linhas = dadoscf.Split(new char[] { ':' });
                                                                string placarel = string.Empty;
                                                                string km = string.Empty;
                                                                string frota = string.Empty;
                                                                string requisicao = string.Empty;
                                                                string nm_motorista = string.Empty;
                                                                string cpf_motorista = string.Empty;
                                                                media = string.Empty;
                                                                string virg = string.Empty;
                                                                foreach (string s in linhas)
                                                                {
                                                                    string[] colunas = s.Split(new char[] { '/' });
                                                                    placarel += virg + colunas[0];
                                                                    km += virg + colunas[1];
                                                                    frota += virg + colunas[2];
                                                                    requisicao += virg + colunas[3];
                                                                    nm_motorista += virg + colunas[4];
                                                                    cpf_motorista += virg + colunas[5];
                                                                    media += virg + colunas[6]; 
                                                                    virg = ",";
                                                                }
                                                                if (!string.IsNullOrEmpty(placarel))
                                                                    Rel.Parametros_Relatorio.Add("PLACA", placarel);
                                                                if (!string.IsNullOrEmpty(km))
                                                                    Rel.Parametros_Relatorio.Add("KM", km);
                                                                if (!string.IsNullOrEmpty(media))
                                                                    Rel.Parametros_Relatorio.Add("MEDIA", media + " KM/LT");
                                                                if (!string.IsNullOrEmpty(frota))
                                                                    Rel.Parametros_Relatorio.Add("FROTA", frota);
                                                                if (!string.IsNullOrEmpty(requisicao))
                                                                    Rel.Parametros_Relatorio.Add("REQUISICAO", requisicao);
                                                                if (!string.IsNullOrEmpty(nm_motorista))
                                                                    Rel.Parametros_Relatorio.Add("NM_MOTORISTA", nm_motorista);
                                                                if (!string.IsNullOrEmpty(cpf_motorista))
                                                                    Rel.Parametros_Relatorio.Add("CPF_MOTORISTA", cpf_motorista);
                                                            }
                                                            Rel.Nome_Relatorio = "DANFE_NFCE";
                                                            Rel.NM_Classe = "TFConsultaFrenteCaixa";
                                                            Rel.Modulo = "FAT";
                                                            Rel.Ident = "DANFE_NFCE";
                                                            if (CamadaNegocio.ConfigGer.TCN_CadParamGer.BuscaVlBool("ST_IMP_DANFE_NFCE_DETALHADA", null))
                                                            {
                                                                BindingSource bsItens = new BindingSource();
                                                                bsItens.DataSource = (bsNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).lItem;
                                                                Rel.DTS_Relatorio = bsItens;
                                                            }
                                                            if (rNFCe.Id_contingencia.HasValue)
                                                                if (Rel.Parametros_Relatorio.ContainsKey("ST_VIAEMPRESA"))
                                                                    Rel.Parametros_Relatorio["ST_VIAEMPRESA"] = "S";
                                                                else
                                                                    Rel.Parametros_Relatorio.Add("ST_VIAEMPRESA", "S");
                                                            //Verificar se existe Impressora padrão para o PDV
                                                            obj = new CamadaDados.Faturamento.Cadastros.TCD_PontoVenda().BuscarEscalar(
                                                                    new TpBusca[]
                                                                    {
                                                                        new TpBusca()
                                                                        {
                                                                            vNM_Campo = "a.cd_terminal",
                                                                            vOperador = "=",
                                                                            vVL_Busca = "'" + Utils.Parametros.pubTerminal.Trim() + "'"
                                                                        }
                                                                    }, "a.impressorapadrao");
                                                            string print = obj == null ? string.Empty : obj.ToString();
                                                            if (string.IsNullOrEmpty(print))
                                                                using (Parametros.Diversos.TFListaImpressoras fLista = new Parametros.Diversos.TFListaImpressoras())
                                                                {
                                                                    if (fLista.ShowDialog() == DialogResult.OK)
                                                                        if (!string.IsNullOrEmpty(fLista.Impressora))
                                                                            print = fLista.Impressora;

                                                                }
                                                            //Imprimir
                                                            Rel.ImprimiGraficoReduzida(print,
                                                                                       true,
                                                                                       false,
                                                                                       null,
                                                                                       string.Empty,
                                                                                       string.Empty,
                                                                                       1);
                                                            if ((bsNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).Id_contingencia.HasValue && 
                                                                (bsNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).rCfgNFCe.Tp_ambiente_nfce.Equals(1))
                                                                Rel.ImprimiGraficoReduzida(print,
                                                                                           true,
                                                                                           false,
                                                                                           null,
                                                                                           string.Empty,
                                                                                           string.Empty,
                                                                                           1);
                                                        }
                                                }
                                                catch (Exception ex)
                                                { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                                                finally
                                                {
                                                    //Verificar se tem boleto e imprimir o mesmo
                                                    CamadaDados.Financeiro.Bloqueto.blListaTitulo lBloqueto =
                                                        new CamadaDados.Financeiro.Bloqueto.TCD_Titulo().Select(
                                                            new TpBusca[]
                                                            {
                                                                new TpBusca()
                                                                {
                                                                    vNM_Campo = string.Empty,
                                                                    vOperador = "exists",
                                                                    vVL_Busca = "(select 1 from tb_pdv_cupomfiscal_x_duplicata x "+
                                                                                "where x.cd_empresa = c.cd_empresa "+
                                                                                "and x.nr_lancto = c.nr_lancto "+
                                                                                "and x.cd_empresa = '" + rCupomConvenio.Cd_empresa.Trim() + "' "+
                                                                                "and x.id_cupom = " + rCupomConvenio.Id_vendarapidastr + ")"
                                                                }
                                                            }, 0, string.Empty);
                                                    if (lBloqueto.Count > 0)
                                                        //Chamar tela de impressao para o bloqueto
                                                        using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
                                                        {
                                                            fImp.St_enabled_enviaremail = true;
                                                            fImp.pCd_clifor = rCupomConvenio.Cd_clifor;
                                                            fImp.pMensagem = "BOLETOS DO DOCUMENTO Nº" + rCupomConvenio.Id_vendarapidastr;
                                                            if ((fImp.ShowDialog() == DialogResult.OK) || (fImp.pSt_enviaremail))
                                                                FormRelPadrao.TCN_LayoutBloqueto.Imprime_Bloqueto(false,
                                                                                                                  lBloqueto,
                                                                                                                  fImp.pSt_imprimir,
                                                                                                                  fImp.pSt_visualizar,
                                                                                                                  fImp.pSt_enviaremail,
                                                                                                                  fImp.pSt_exportPdf,
                                                                                                                  fImp.Path_exportPdf,
                                                                                                                  fImp.pDestinatarios,
                                                                                                                  "BOLETO(S) DO DOCUMENTO Nº " + rCupomConvenio.Id_vendarapidastr,
                                                                                                                  fImp.pDs_mensagem,
                                                                                                                  false);
                                                        }
                                                }
                                            }
                                            else
                                                MessageBox.Show("Não existe série modelo 65 configurada na CFG.Frente de Caixa!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        }
                                    else
                                    {
                                        //Verificar se tem boleto e imprimir o mesmo
                                        CamadaDados.Financeiro.Bloqueto.blListaTitulo lBloqueto =
                                            new CamadaDados.Financeiro.Bloqueto.TCD_Titulo().Select(
                                                new TpBusca[]
                                                {
                                                    new TpBusca()
                                                    {
                                                        vNM_Campo = string.Empty,
                                                        vOperador = "exists",
                                                        vVL_Busca = "(select 1 from tb_pdv_cupomfiscal_x_duplicata x "+
                                                                    "where x.cd_empresa = c.cd_empresa "+
                                                                    "and x.nr_lancto = c.nr_lancto "+
                                                                    "and x.cd_empresa = '" + rCupomConvenio.Cd_empresa.Trim() + "' "+
                                                                    "and x.id_cupom = " + rCupomConvenio.Id_vendarapidastr + ")"
                                                    }
                                                }, 0, string.Empty);
                                        if (lBloqueto.Count > 0)
                                            //Chamar tela de impressao para o bloqueto
                                            using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
                                            {
                                                fImp.St_enabled_enviaremail = true;
                                                fImp.pCd_clifor = rCupomConvenio.Cd_clifor;
                                                fImp.pMensagem = "BOLETOS DO DOCUMENTO Nº" + rCupomConvenio.Id_vendarapidastr;
                                                if ((fImp.ShowDialog() == DialogResult.OK) || (fImp.pSt_enviaremail))
                                                    FormRelPadrao.TCN_LayoutBloqueto.Imprime_Bloqueto(false,
                                                                                                      lBloqueto,
                                                                                                      fImp.pSt_imprimir,
                                                                                                      fImp.pSt_visualizar,
                                                                                                      fImp.pSt_enviaremail,
                                                                                                      fImp.pSt_exportPdf,
                                                                                                      fImp.Path_exportPdf,
                                                                                                      fImp.pDestinatarios,
                                                                                                      "BOLETO(S) DO DOCUMENTO Nº " + rCupomConvenio.Id_vendarapidastr,
                                                                                                      fImp.pDs_mensagem,
                                                                                                      false);
                                            }
                                    }
                                }
                            }
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                        //Limpar tela
                        if (st_vendagravada)
                        {
                            ImprimirConfissaoDivida();
                            rVenda = null;
                            Cd_clifor.Text = lCfg[0].Cd_clifor;
                            Cd_clifor.BackColor = Color.White;
                            cd_endereco.Text = lCfg[0].Cd_endereco;
                            Cd_clifor.Enabled = true;
                            bb_clifor.Enabled = true;
                            NM_Clifor.Enabled = false;
                            NM_Clifor.Text = lCfg[0].Nm_clifor;
                            lblCxLivre.Visible = true;
                            lblTotalItens.Text = string.Empty;
                            lblTotalDesconto.Text = string.Empty;
                            lblTotalCupom.Text = string.Empty;
                            placa.Clear();
                            St_placacadastrada = false;
                        }
                        afterBusca();
                    }
                    else
                        MessageBox.Show("Obrigatorio informar convenio para finalizar venda",
                    "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Obrigatorio informar convenio para finalizar venda",
                    "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void FinalizarVenda(bool St_conveniencia, string TP_Portador)
        {
            bool st_vendagravada = false;
            if (rVenda != null)
            {
                if (TP_Portador.Trim().ToUpper().Equals("R"))//dinheiro
                {
                    //Buscar portador dinheiro
                    CamadaDados.Financeiro.Cadastros.TList_CadPortador lDinheiro =
                        new CamadaDados.Financeiro.Cadastros.TCD_CadPortador().Select(
                            new TpBusca[]
                            {
                                new TpBusca()
                                {
                                    vNM_Campo = "isnull(a.tp_portadorPDV, '')",
                                    vOperador = "=",
                                    vVL_Busca = "'A'"
                                },
                                new TpBusca()
                                {
                                    vNM_Campo = "isnull(a.st_controletitulo, 'N')",
                                    vOperador = "<>",
                                    vVL_Busca = "'S'"
                                },
                                new TpBusca()
                                {
                                    vNM_Campo = "isnull(a.st_tituloterceiro, 'N')",
                                    vOperador = "<>",
                                    vVL_Busca = "'S'"
                                },
                                new TpBusca()
                                {
                                    vNM_Campo = "a.st_cartaocredito",
                                    vOperador = "=",
                                    vVL_Busca = "1"
                                },
                                new TpBusca()
                                {
                                    vNM_Campo = "isnull(a.st_devcredito, 'N')",
                                    vOperador = "<>",
                                    vVL_Busca = "'S'"
                                },
                                new TpBusca()
                                {
                                    vNM_Campo = "isnull(a.st_cartafrete, 'N')",
                                    vOperador = "<>",
                                    vVL_Busca = "'S'"
                                },
                                new TpBusca()
                                {
                                    vNM_Campo = "isnull(a.st_entregafutura, 'N')",
                                    vOperador = "<>",
                                    vVL_Busca = "'S'"
                                }
                            }, 1, string.Empty, string.Empty);
                    if (lDinheiro.Count.Equals(0))
                    {
                        MessageBox.Show("Não existe portador dinheiro configurado no sistema.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (St_conveniencia)
                            CancelarVenda();
                        return;
                    }
                    using (PDV.TFFecharVendaDinheiro fFechar = new PDV.TFFecharVendaDinheiro())
                    {
                        fFechar.pCd_empresa = rVenda.Cd_empresa;
                        fFechar.pCd_operador = Cd_operador;
                        fFechar.lPdv = lPdv;
                        fFechar.pLoginDesconto = LoginPdv;
                        fFechar.rCupom = rVenda;
                        fFechar.pVl_receber = rVenda.lItem.Sum(p => p.Vl_subtotalliquido);
                        if (fFechar.ShowDialog() == DialogResult.OK)
                        {
                            //Ratear desconto 
                            if (fFechar.pVl_desconto > decimal.Zero)
                                CamadaNegocio.Faturamento.PDV.TCN_VendaRapida.RatearDescontoVRapida(rVenda, fFechar.pVl_desconto, decimal.Zero);
                            lDinheiro[0].Vl_pagtoPDV = fFechar.pVl_dinheiro;
                            //Troco
                            if (fFechar.pVl_troco > decimal.Zero)
                            {
                                using (Financeiro.TFTrocoPDV fTroco = new Financeiro.TFTrocoPDV())
                                {
                                    fTroco.Cd_empresa = rVenda.Cd_empresa;
                                    fTroco.Id_caixaPDV = rCaixa.Id_caixastr;
                                    fTroco.Vl_troco = fFechar.pVl_troco;
                                    fTroco.Cd_historioTroco = lCfg[0].Cd_historico_troco;
                                    fTroco.Ds_historicoTroco = lCfg[0].Ds_historico_troco;
                                    fTroco.St_desativarCred = !CamadaNegocio.Diversos.TCN_Usuario_RegraEspecial.ValidaRegra(LoginPdv, "PERMITIR GERAR CREDITO NO TROCO", null);
                                    if (fTroco.ShowDialog() == DialogResult.OK)
                                    {
                                        if (fTroco.Vl_trocoCredito > decimal.Zero)
                                        {
                                            lDinheiro[0].Vl_credTroco = fTroco.Vl_trocoCredito;
                                            if (CamadaNegocio.ConfigGer.TCN_CadParamGer.BuscaVL_Bool("ST_IDENT_CLIFOR_CRED", rVenda.Cd_empresa, null).Trim().ToUpper().Equals("S"))
                                            {
                                                if (string.IsNullOrEmpty(rVenda.Cd_clifor))
                                                {
                                                    DataRowView linha = FormBusca.UtilPesquisa.BTN_BuscaClifor(null, string.Empty);
                                                    if (linha != null)
                                                    {
                                                        rVenda.Cd_clifor = linha["cd_clifor"].ToString();
                                                        rVenda.Nm_clifor = linha["nm_clifor"].ToString();
                                                        //buscar endereco clifor
                                                        object obj = new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco().BuscarEscalar(
                                                                        new TpBusca[]
                                                                {
                                                                    new TpBusca()
                                                                    {
                                                                        vNM_Campo = "a.cd_clifor",
                                                                        vOperador = "=",
                                                                        vVL_Busca = rVenda.Cd_clifor
                                                                    }
                                                                }, "a.cd_endereco");
                                                        if (obj != null)
                                                            rVenda.Cd_endereco = obj.ToString();
                                                        lDinheiro[0].St_gerarCredito = true;
                                                    }
                                                    else
                                                    {
                                                        MessageBox.Show("Obrigatorio informar cliente para gerar CREDITO.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                        if (St_conveniencia)
                                                            CancelarVenda();
                                                        return;
                                                    }
                                                }
                                            }
                                            else
                                                using (InputBox inp = new InputBox())
                                                {
                                                    //buscar endereco clifor
                                                    object obj = new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco().BuscarEscalar(
                                                                    new TpBusca[]
                                                            {
                                                                new TpBusca()
                                                                {
                                                                    vNM_Campo = "a.cd_clifor",
                                                                    vOperador = "=",
                                                                    vVL_Busca = rVenda.Cd_clifor
                                                                }
                                                            }, "a.cd_endereco");
                                                    if (obj != null)
                                                        rVenda.Cd_endereco = obj.ToString();
                                                    lDinheiro[0].Ds_mensagemCredito = inp.ShowDialog();
                                                    lDinheiro[0].St_gerarCredito = true;
                                                }
                                        }
                                        if (fTroco.lChRepasse != null)
                                        {
                                            fTroco.lChRepasse.ForEach(p => lDinheiro[0].lChTroco.Add(p));
                                            if (string.IsNullOrEmpty(rVenda.Cd_clifor))
                                            {
                                                if (string.IsNullOrEmpty(rVenda.Cd_clifor))
                                                {
                                                    DataRowView linha = FormBusca.UtilPesquisa.BTN_BuscaClifor(null, string.Empty);
                                                    if (linha != null)
                                                    {
                                                        rVenda.Cd_clifor = linha["cd_clifor"].ToString();
                                                        rVenda.Nm_clifor = linha["nm_clifor"].ToString();
                                                    }
                                                    else
                                                    {
                                                        MessageBox.Show("Obrigatorio informar cliente para repasse de cheque.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                        if (St_conveniencia)
                                                            CancelarVenda();
                                                        return;
                                                    }
                                                }
                                            }
                                        }
                                        if (fTroco.lChTroco != null)
                                            fTroco.lChTroco.ForEach(p => lDinheiro[0].lChTroco.Add(p));
                                        if (fTroco.Vl_trocoDinheiro > decimal.Zero)
                                            lDinheiro[0].Vl_trocoPDV = fTroco.Vl_trocoDinheiro;
                                        else lDinheiro[0].Vl_trocoPDV = decimal.Zero;
                                    }
                                    else
                                    {
                                        MessageBox.Show("Obrigatorio identificar tipo TROCO.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        if (St_conveniencia)
                                            CancelarVenda();
                                        return;
                                    }
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Obrigatorio informar financeiro para fechar venda.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            if (St_conveniencia)
                                CancelarVenda();
                            return;
                        }
                    }
                    rVenda.lPortador = lDinheiro;
                }
                else if (TP_Portador.Trim().ToUpper().Equals("C"))//Cartao Credito
                {
                    //Buscar portador cartao
                    CamadaDados.Financeiro.Cadastros.TList_CadPortador lCartao =
                        new CamadaDados.Financeiro.Cadastros.TCD_CadPortador().Select(
                        new TpBusca[]
                        {
                            new TpBusca()
                            {
                                vNM_Campo = "isnull(a.tp_portadorPDV, '')",
                                vOperador = "=",
                                vVL_Busca = "'A'"
                            },
                            new TpBusca()
                            {
                                vNM_Campo = "a.st_cartaocredito",
                                vOperador = "=",
                                vVL_Busca = "0"
                            }
                        }, 1, string.Empty, string.Empty);
                    if (lCartao.Count.Equals(0))
                    {
                        MessageBox.Show("Não existe portador cartão crédito/débito configurado no sistema.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (St_conveniencia)
                            CancelarVenda();
                        return;
                    }
                    using (Componentes.TFDebitoCredito fD_C = new Componentes.TFDebitoCredito())
                    {
                        if (fD_C.ShowDialog() == DialogResult.OK)
                        {
                            using (PDV.TFLanCartaoPDV fCartao = new PDV.TFLanCartaoPDV())
                            {
                                fCartao.D_C = fD_C.D_C;
                                fCartao.pCd_empresa = rVenda.Cd_empresa;
                                fCartao.Vl_saldofaturar = rVenda.lItem.Sum(p => p.Vl_subtotalliquido);
                                fCartao.St_validarSaldo = true;
                                if (fCartao.ShowDialog() == DialogResult.OK)
                                {
                                    fCartao.lFatura.ForEach(p => lCartao[0].lFatura.Add(p));
                                    lCartao[0].Vl_pagtoPDV = fCartao.lFatura.Sum(p => p.Vl_fatura);
                                    lCartao[0].Vl_trocoPDV = lCartao[0].Vl_pagtoPDV - fCartao.Vl_saldofaturar;
                                    //Troco
                                    if (lCartao[0].Vl_trocoPDV > decimal.Zero)
                                    {
                                        using (Financeiro.TFTrocoPDV fTroco = new Financeiro.TFTrocoPDV())
                                        {
                                            fTroco.Cd_empresa = rVenda.Cd_empresa;
                                            fTroco.Id_caixaPDV = rCaixa.Id_caixastr;
                                            fTroco.Vl_troco = lCartao[0].Vl_trocoPDV;
                                            fTroco.Cd_historioTroco = lCfg[0].Cd_historico_troco;
                                            fTroco.Ds_historicoTroco = lCfg[0].Ds_historico_troco;
                                            fTroco.St_desativarCred = !CamadaNegocio.Diversos.TCN_Usuario_RegraEspecial.ValidaRegra(LoginPdv, "PERMITIR GERAR CREDITO NO TROCO", null);
                                            if (fTroco.ShowDialog() == DialogResult.OK)
                                            {
                                                if (fTroco.Vl_trocoCredito > decimal.Zero)
                                                {
                                                    lCartao[0].Vl_credTroco = fTroco.Vl_trocoCredito;
                                                    if (CamadaNegocio.ConfigGer.TCN_CadParamGer.BuscaVL_Bool("ST_IDENT_CLIFOR_CRED", rVenda.Cd_empresa, null).Trim().ToUpper().Equals("S"))
                                                    {
                                                        if (string.IsNullOrEmpty(rVenda.Cd_clifor))
                                                        {
                                                            DataRowView linha = FormBusca.UtilPesquisa.BTN_BuscaClifor(null, string.Empty);
                                                            if (linha != null)
                                                            {
                                                                rVenda.Cd_clifor = linha["cd_clifor"].ToString();
                                                                rVenda.Nm_clifor = linha["nm_clifor"].ToString();
                                                                //buscar endereco clifor
                                                                object obj = new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco().BuscarEscalar(
                                                                                new TpBusca[]
                                                                {
                                                                    new TpBusca()
                                                                    {
                                                                        vNM_Campo = "a.cd_clifor",
                                                                        vOperador = "=",
                                                                        vVL_Busca = rVenda.Cd_clifor
                                                                    }
                                                                }, "a.cd_endereco");
                                                                if (obj != null)
                                                                    rVenda.Cd_endereco = obj.ToString();
                                                                lCartao[0].St_gerarCredito = true;
                                                            }
                                                            else
                                                            {
                                                                MessageBox.Show("Obrigatorio informar cliente para gerar CREDITO.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                                if (St_conveniencia)
                                                                    CancelarVenda();
                                                                return;
                                                            }
                                                        }
                                                    }
                                                    else
                                                        using (InputBox inp = new InputBox())
                                                        {
                                                            //buscar endereco clifor
                                                            object obj = new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco().BuscarEscalar(
                                                                            new TpBusca[]
                                                            {
                                                                new TpBusca()
                                                                {
                                                                    vNM_Campo = "a.cd_clifor",
                                                                    vOperador = "=",
                                                                    vVL_Busca = rVenda.Cd_clifor
                                                                }
                                                            }, "a.cd_endereco");
                                                            if (obj != null)
                                                                rVenda.Cd_endereco = obj.ToString();
                                                            lCartao[0].Ds_mensagemCredito = inp.ShowDialog();
                                                            lCartao[0].St_gerarCredito = true;
                                                        }
                                                }
                                                if (fTroco.lChRepasse != null)
                                                {
                                                    fTroco.lChRepasse.ForEach(p => lCartao[0].lChTroco.Add(p));
                                                    if (string.IsNullOrEmpty(rVenda.Cd_clifor))
                                                    {
                                                        if (string.IsNullOrEmpty(rVenda.Cd_clifor))
                                                        {
                                                            DataRowView linha = FormBusca.UtilPesquisa.BTN_BuscaClifor(null, string.Empty);
                                                            if (linha != null)
                                                            {
                                                                rVenda.Cd_clifor = linha["cd_clifor"].ToString();
                                                                rVenda.Nm_clifor = linha["nm_clifor"].ToString();
                                                            }
                                                            else
                                                            {
                                                                MessageBox.Show("Obrigatorio informar cliente para repasse de cheque.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                                if (St_conveniencia)
                                                                    CancelarVenda();
                                                                return;
                                                            }
                                                        }
                                                    }
                                                }
                                                if (fTroco.lChTroco != null)
                                                    fTroco.lChTroco.ForEach(p => lCartao[0].lChTroco.Add(p));
                                                if (fTroco.Vl_trocoDinheiro > decimal.Zero)
                                                    lCartao[0].Vl_trocoPDV = fTroco.Vl_trocoDinheiro;
                                                else lCartao[0].Vl_trocoPDV = decimal.Zero;
                                            }
                                            else
                                            {
                                                MessageBox.Show("Obrigatorio identificar tipo TROCO.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                if (St_conveniencia)
                                                    CancelarVenda();
                                                return;
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Obrigatorio informar financeiro para fechar venda.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    if (St_conveniencia)
                                        CancelarVenda();
                                    return;
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Obrigatorio informar financeiro para fechar venda.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            if (St_conveniencia)
                                CancelarVenda();
                            return;
                        }
                    }
                    rVenda.lPortador = lCartao;
                }
                else if (TP_Portador.Trim().ToUpper().Equals("H"))//Cheque
                {
                    //Buscar portador cheque
                    CamadaDados.Financeiro.Cadastros.TList_CadPortador lCheque =
                        new CamadaDados.Financeiro.Cadastros.TCD_CadPortador().Select(
                        new TpBusca[]
                        {
                            new TpBusca()
                            {
                                vNM_Campo = "isnull(a.tp_portadorPDV, '')",
                                vOperador = "=",
                                vVL_Busca = "'A'"
                            },
                            new TpBusca()
                            {
                                vNM_Campo = "isnull(a.st_controletitulo, 'N')",
                                vOperador = "=",
                                vVL_Busca = "'S'"
                            }
                        }, 1, string.Empty, string.Empty);
                    if (lCheque.Count.Equals(0))
                    {
                        MessageBox.Show("Não existe portador cheque configurado no sistema.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (St_conveniencia)
                            CancelarVenda();
                        return;
                    }
                    //Verificar credito
                    CamadaDados.Financeiro.Duplicata.TRegistro_DadosBloqueio rDados =
                        new CamadaDados.Financeiro.Duplicata.TRegistro_DadosBloqueio();
                    if (CamadaNegocio.Financeiro.Duplicata.TCN_DadosBloqueio.VerificarBloqueioCredito(rVenda.Cd_clifor,
                                                                                                      rVenda.lItem.Sum(p => p.Vl_subtotalliquido),
                                                                                                      false,
                                                                                                      ref rDados,
                                                                                                      null))
                        using (Financeiro.TFLan_BloqueioCredito fBloq = new Financeiro.TFLan_BloqueioCredito())
                        {
                            fBloq.rDados = rDados;
                            fBloq.Vl_fatura = rVenda.lItem.Sum(p => p.Vl_subtotalliquido);
                            fBloq.ShowDialog();
                            if (!fBloq.St_desbloqueado)
                            {
                                MessageBox.Show("Não é permitido realizar venda para cliente com restrição crédito.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                if (St_conveniencia)
                                    CancelarVenda();
                                return;
                            }
                        }
                    using (Financeiro.TFLanListaCheques fListaCheques = new Financeiro.TFLanListaCheques())
                    {
                        fListaCheques.Tp_mov = "R";
                        fListaCheques.Cd_empresa = rVenda.Cd_empresa;
                        //fListaCheques.St_pdv = true;
                        fListaCheques.Cd_contager = lCfg[0].Cd_contaoperacional;
                        fListaCheques.Ds_contager = lCfg[0].Ds_contaoperacional;
                        fListaCheques.Cd_clifor = rVenda.Cd_clifor.Trim().Equals(lCfg[0].Cd_clifor.Trim()) ? string.Empty : rVenda.Cd_clifor;
                        fListaCheques.Cd_historico = lCfg[0].Cd_historicocaixa;
                        fListaCheques.Ds_historico = lCfg[0].Ds_historicocaixa;
                        fListaCheques.Cd_portador = lCheque[0].Cd_portador;
                        fListaCheques.Ds_portador = lCheque[0].Ds_portador;
                        fListaCheques.Nm_clifor = rVenda.Cd_clifor.Trim().Equals(lCfg[0].Cd_clifor.Trim()) ? string.Empty : rVenda.Nm_clifor;
                        fListaCheques.Dt_emissao = CamadaDados.UtilData.Data_Servidor();
                        fListaCheques.Vl_totaltitulo = rVenda.lItem.Sum(p => p.Vl_subtotalliquido);
                        if (fListaCheques.ShowDialog() == DialogResult.OK)
                        {
                            lCheque[0].lCheque = fListaCheques.lCheques;
                            lCheque[0].Vl_pagtoPDV = fListaCheques.lCheques.Sum(p => p.Vl_titulo);
                            lCheque[0].Vl_trocoPDV = lCheque[0].Vl_pagtoPDV - fListaCheques.Vl_totaltitulo;
                            //Troco
                            if (lCheque[0].Vl_trocoPDV > decimal.Zero)
                            {
                                using (Financeiro.TFTrocoPDV fTroco = new Financeiro.TFTrocoPDV())
                                {
                                    fTroco.Cd_empresa = rVenda.Cd_empresa;
                                    fTroco.Id_caixaPDV = rCaixa.Id_caixastr;
                                    fTroco.Vl_troco = lCheque[0].Vl_trocoPDV;
                                    fTroco.Cd_historioTroco = lCfg[0].Cd_historico_troco;
                                    fTroco.Ds_historicoTroco = lCfg[0].Ds_historico_troco;
                                    fTroco.St_desativarCred = !CamadaNegocio.Diversos.TCN_Usuario_RegraEspecial.ValidaRegra(LoginPdv, "PERMITIR GERAR CREDITO NO TROCO", null);
                                    if (fTroco.ShowDialog() == DialogResult.OK)
                                    {
                                        if (fTroco.Vl_trocoCredito > decimal.Zero)
                                        {
                                            lCheque[0].Vl_credTroco = fTroco.Vl_trocoCredito;
                                            if (CamadaNegocio.ConfigGer.TCN_CadParamGer.BuscaVL_Bool("ST_IDENT_CLIFOR_CRED", rVenda.Cd_empresa, null).Trim().ToUpper().Equals("S"))
                                            {
                                                if (string.IsNullOrEmpty(rVenda.Cd_clifor))
                                                {
                                                    DataRowView linha = FormBusca.UtilPesquisa.BTN_BuscaClifor(null, string.Empty);
                                                    if (linha != null)
                                                    {
                                                        rVenda.Cd_clifor = linha["cd_clifor"].ToString();
                                                        rVenda.Nm_clifor = linha["nm_clifor"].ToString();
                                                        //buscar endereco clifor
                                                        object obj = new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco().BuscarEscalar(
                                                                        new TpBusca[]
                                                                        {
                                                                            new TpBusca()
                                                                            {
                                                                                vNM_Campo = "a.cd_clifor",
                                                                                vOperador = "=",
                                                                                vVL_Busca = rVenda.Cd_clifor
                                                                            }
                                                                        }, "a.cd_endereco");
                                                        if (obj != null)
                                                            rVenda.Cd_endereco = obj.ToString();
                                                        lCheque[0].St_gerarCredito = true;
                                                    }
                                                    else
                                                    {
                                                        MessageBox.Show("Obrigatorio informar cliente para gerar CREDITO.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                        if (St_conveniencia)
                                                            CancelarVenda();
                                                        return;
                                                    }
                                                }
                                            }
                                            else
                                                using (InputBox inp = new InputBox())
                                                {
                                                    //buscar endereco clifor
                                                    object obj = new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco().BuscarEscalar(
                                                                    new TpBusca[]
                                                            {
                                                                new TpBusca()
                                                                {
                                                                    vNM_Campo = "a.cd_clifor",
                                                                    vOperador = "=",
                                                                    vVL_Busca = rVenda.Cd_clifor
                                                                }
                                                            }, "a.cd_endereco");
                                                    if (obj != null)
                                                        rVenda.Cd_endereco = obj.ToString();
                                                    lCheque[0].Ds_mensagemCredito = inp.ShowDialog();
                                                    lCheque[0].St_gerarCredito = true;
                                                }
                                        }
                                        if (fTroco.lChRepasse != null)
                                        {
                                            fTroco.lChRepasse.ForEach(p => lCheque[0].lChTroco.Add(p));
                                            if (string.IsNullOrEmpty(rVenda.Cd_clifor))
                                            {
                                                if (string.IsNullOrEmpty(rVenda.Cd_clifor))
                                                {
                                                    DataRowView linha = FormBusca.UtilPesquisa.BTN_BuscaClifor(null, string.Empty);
                                                    if (linha != null)
                                                    {
                                                        rVenda.Cd_clifor = linha["cd_clifor"].ToString();
                                                        rVenda.Nm_clifor = linha["nm_clifor"].ToString();
                                                    }
                                                    else
                                                    {
                                                        MessageBox.Show("Obrigatorio informar cliente para repasse de cheque.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                        if (St_conveniencia)
                                                            CancelarVenda();
                                                        return;
                                                    }
                                                }
                                            }
                                        }
                                        if (fTroco.lChTroco != null)
                                            fTroco.lChTroco.ForEach(p => lCheque[0].lChTroco.Add(p));
                                        if (fTroco.Vl_trocoDinheiro > decimal.Zero)
                                            lCheque[0].Vl_trocoPDV = fTroco.Vl_trocoDinheiro;
                                        else lCheque[0].Vl_trocoPDV = decimal.Zero;
                                    }
                                    else
                                    {
                                        MessageBox.Show("Obrigatorio identificar tipo TROCO.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        if (St_conveniencia)
                                            CancelarVenda();
                                        return;
                                    }
                                }
                            }
                            rVenda.lPortador = lCheque;
                        }
                        else
                        {
                            MessageBox.Show("Cheque não foi lançado... Liquidação não será efetivada! ");
                            if (St_conveniencia)
                                CancelarVenda();
                            return;
                        }
                    }
                }
                else if (TP_Portador.Trim().ToUpper().Equals("N"))//Duplicata
                {
                    //Buscar portador duplicata
                    CamadaDados.Financeiro.Cadastros.TList_CadPortador lDup =
                        new CamadaDados.Financeiro.Cadastros.TCD_CadPortador().Select(
                        new TpBusca[]
                        {
                            new TpBusca()
                            {
                                vNM_Campo = "isnull(a.tp_portadorPDV, '')",
                                vOperador = "=",
                                vVL_Busca = "'P'"
                            }
                        }, 1, string.Empty, string.Empty);
                    if (lDup.Count.Equals(0))
                    {
                        MessageBox.Show("Não existe portador duplicata configurado no sistema.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (St_conveniencia)
                            CancelarVenda();
                        return;
                    }
                    if (string.IsNullOrEmpty(rVenda.Cd_clifor))
                    {
                        MessageBox.Show("Não é permitido venda a prazo sem identificar cliente.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (St_conveniencia)
                            CancelarVenda();
                        return;
                    }
                    //Abrir tela Duplicata
                    using (Financeiro.TFLanDuplicata fDuplicata = new Financeiro.TFLanDuplicata())
                    {
                        fDuplicata.vCd_empresa = rVenda.Cd_empresa;
                        fDuplicata.vNm_empresa = rVenda.Nm_empresa;
                        fDuplicata.vCd_clifor = rVenda.Cd_clifor;
                        fDuplicata.vNm_clifor = rVenda.Nm_clifor;
                        //Buscar condicao de pagamento
                        CamadaDados.Financeiro.Cadastros.TList_CadCondPgto lCond =
                        CamadaNegocio.Financeiro.Cadastros.TCN_CadCondPgto.Buscar(string.Empty,
                                                                                  string.Empty,
                                                                                  string.Empty,
                                                                                  string.Empty,
                                                                                  string.Empty,
                                                                                  string.Empty,
                                                                                  1,
                                                                                  decimal.Zero,
                                                                                  string.Empty,
                                                                                  string.Empty,
                                                                                  1,
                                                                                  string.Empty,
                                                                                  null);
                        if (lCond.Count > 0)
                            fDuplicata.vCd_condpgto = lCond[0].Cd_condpgto;

                        fDuplicata.vSt_ecf = true;
                        fDuplicata.vId_caixa = rCaixa != null ? rCaixa.Id_caixastr : string.Empty;
                        //Buscar endereco clifor
                        if (!string.IsNullOrEmpty(rVenda.Cd_clifor))
                        {
                            CamadaDados.Financeiro.Cadastros.TList_CadEndereco lEnd =
                                CamadaNegocio.Financeiro.Cadastros.TCN_CadEndereco.Buscar(rVenda.Cd_clifor,
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
                                                                                          null);
                            if (lEnd.Count > 0)
                            {
                                fDuplicata.vCd_endereco = lEnd[0].Cd_endereco;
                                fDuplicata.vDs_endereco = lEnd[0].Ds_endereco;
                            }
                        }
                        fDuplicata.vCd_historico = lCfg[0].Cd_historico;
                        fDuplicata.vDs_historico = lCfg[0].Ds_historico;
                        fDuplicata.vTp_duplicata = lCfg[0].Tp_duplicata;
                        fDuplicata.vDs_tpduplicata = lCfg[0].Ds_tpduplicata;
                        fDuplicata.vTp_mov = "R";
                        fDuplicata.vTp_docto = lCfg[0].Tp_doctostr;
                        fDuplicata.vDs_tpdocto = lCfg[0].Ds_tpdocto;
                        //Buscar Moeda Padrao
                        CamadaDados.Financeiro.Cadastros.TList_Moeda tabela =
                            CamadaNegocio.ConfigGer.TCN_CadParamGer_X_Empresa.BuscarMoedaPadrao(rVenda.Cd_empresa, null);
                        if (tabela != null)
                            if (tabela.Count > 0)
                            {
                                fDuplicata.vCd_moeda = tabela[0].Cd_moeda;
                                fDuplicata.vDs_moeda = tabela[0].Ds_moeda_singular;
                                fDuplicata.vSigla_moeda = tabela[0].Sigla;
                                fDuplicata.vCd_moeda_padrao = tabela[0].Cd_moeda;
                                fDuplicata.vDs_moeda_padrao = tabela[0].Ds_moeda_singular;
                                fDuplicata.vSigla_moeda_padrao = tabela[0].Sigla;
                            }

                        fDuplicata.vNr_docto = "PDC123";//pNr_cupom; //Numero Cupom
                        fDuplicata.vDt_emissao = CamadaDados.UtilData.Data_Servidor().ToString("dd/MM/yyyy");
                        fDuplicata.vVl_documento = rVenda.lItem.Sum(p => p.Vl_subtotalliquido);
                        if (fDuplicata.ShowDialog() == DialogResult.OK)
                            if (fDuplicata.dsDuplicata.Current != null)
                            {
                                lDup[0].lDup.Add((fDuplicata.dsDuplicata.Current as CamadaDados.Financeiro.Duplicata.TRegistro_LanDuplicata));
                                lDup[0].Vl_pagtoPDV = (fDuplicata.dsDuplicata.Current as CamadaDados.Financeiro.Duplicata.TRegistro_LanDuplicata).Vl_documento_padrao;
                            }
                            else
                            {
                                MessageBox.Show("Obrigatorio informar duplicata para finalizar venda. ");
                                if (St_conveniencia)
                                    CancelarVenda();
                                return;
                            }
                        else
                        {
                            MessageBox.Show("Obrigatorio informar duplicata para finalizar venda. ");
                            if (St_conveniencia)
                                CancelarVenda();
                            return;
                        }
                    }
                    rVenda.lPortador = lDup;
                }
                else if (TP_Portador.Trim().ToUpper().Equals("F"))//Carta Frete
                {
                    //Buscar portador duplicata
                    CamadaDados.Financeiro.Cadastros.TList_CadPortador lCarta =
                        new CamadaDados.Financeiro.Cadastros.TCD_CadPortador().Select(
                        new TpBusca[]
                        {
                            new TpBusca()
                            {
                                vNM_Campo = "isnull(a.tp_portadorPDV, '')",
                                vOperador = "=",
                                vVL_Busca = "'A'"
                            },
                            new TpBusca()
                            {
                                vNM_Campo = "isnull(a.st_cartafrete, 'N')",
                                vOperador = "=",
                                vVL_Busca = "'S'"
                            }
                        }, 1, string.Empty, string.Empty);
                    if (lCarta.Count.Equals(0))
                    {
                        MessageBox.Show("Não existe portador carta frete configurado no sistema.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (St_conveniencia)
                            CancelarVenda();
                        return;
                    }
                    using (PDV.TFLanListaCartaFrete fCf = new PDV.TFLanListaCartaFrete())
                    {
                        fCf.Cd_empresa = rVenda.Cd_empresa;
                        fCf.Nm_empresa = rVenda.Nm_empresa;
                        fCf.Vl_totaltitulo = rVenda.lItem.Sum(p => p.Vl_subtotalliquido);
                        if (fCf.ShowDialog() == DialogResult.OK)
                        {
                            lCarta[0].lCartaFrete = fCf.lCarta;
                            lCarta[0].Vl_pagtoPDV = fCf.lCarta.Sum(p => p.Vl_documento);
                            lCarta[0].Vl_trocoPDV = lCarta[0].Vl_pagtoPDV - fCf.Vl_totaltitulo;
                            //Troco
                            if (lCarta[0].Vl_trocoPDV > decimal.Zero)
                            {
                                using (Financeiro.TFTrocoPDV fTroco = new Financeiro.TFTrocoPDV())
                                {
                                    fTroco.Cd_empresa = rVenda.Cd_empresa;
                                    fTroco.Id_caixaPDV = rCaixa.Id_caixastr;
                                    fTroco.Vl_troco = lCarta[0].Vl_trocoPDV;
                                    fTroco.Cd_historioTroco = lCfg[0].Cd_historico_troco;
                                    fTroco.Ds_historicoTroco = lCfg[0].Ds_historico_troco;
                                    fTroco.St_desativarCred = !CamadaNegocio.Diversos.TCN_Usuario_RegraEspecial.ValidaRegra(LoginPdv, "PERMITIR GERAR CREDITO NO TROCO", null);
                                    if (fTroco.ShowDialog() == DialogResult.OK)
                                    {
                                        if (fTroco.Vl_trocoCredito > decimal.Zero)
                                        {
                                            lCarta[0].Vl_credTroco = fTroco.Vl_trocoCredito;
                                            if (CamadaNegocio.ConfigGer.TCN_CadParamGer.BuscaVL_Bool("ST_IDENT_CLIFOR_CRED", rVenda.Cd_empresa, null).Trim().ToUpper().Equals("S"))
                                            {
                                                if (string.IsNullOrEmpty(rVenda.Cd_clifor))
                                                {
                                                    DataRowView linha = FormBusca.UtilPesquisa.BTN_BuscaClifor(null, string.Empty);
                                                    if (linha != null)
                                                    {
                                                        rVenda.Cd_clifor = linha["cd_clifor"].ToString();
                                                        rVenda.Nm_clifor = linha["nm_clifor"].ToString();
                                                        //buscar endereco clifor
                                                        object obj = new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco().BuscarEscalar(
                                                                        new TpBusca[]
                                                                        {
                                                                            new TpBusca()
                                                                            {
                                                                                vNM_Campo = "a.cd_clifor",
                                                                                vOperador = "=",
                                                                                vVL_Busca = rVenda.Cd_clifor
                                                                            }
                                                                        }, "a.cd_endereco");
                                                        if (obj != null)
                                                            rVenda.Cd_endereco = obj.ToString();
                                                        lCarta[0].St_gerarCredito = true;
                                                    }
                                                    else
                                                    {
                                                        MessageBox.Show("Obrigatorio informar cliente para gerar CREDITO.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                        if (St_conveniencia)
                                                            CancelarVenda();
                                                        return;
                                                    }
                                                }
                                            }
                                            else
                                                using (InputBox inp = new InputBox())
                                                {
                                                    //buscar endereco clifor
                                                    object obj = new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco().BuscarEscalar(
                                                                    new TpBusca[]
                                                                    {
                                                                        new TpBusca()
                                                                        {
                                                                            vNM_Campo = "a.cd_clifor",
                                                                            vOperador = "=",
                                                                            vVL_Busca = rVenda.Cd_clifor
                                                                        }
                                                                    }, "a.cd_endereco");
                                                    if (obj != null)
                                                        rVenda.Cd_endereco = obj.ToString();
                                                    lCarta[0].Ds_mensagemCredito = inp.ShowDialog();
                                                    lCarta[0].St_gerarCredito = true;
                                                }
                                        }
                                        if (fTroco.lChRepasse != null)
                                        {
                                            fTroco.lChRepasse.ForEach(p => lCarta[0].lChTroco.Add(p));
                                            if (string.IsNullOrEmpty(rVenda.Cd_clifor))
                                            {
                                                if (string.IsNullOrEmpty(rVenda.Cd_clifor))
                                                {
                                                    DataRowView linha = FormBusca.UtilPesquisa.BTN_BuscaClifor(null, string.Empty);
                                                    if (linha != null)
                                                    {
                                                        rVenda.Cd_clifor = linha["cd_clifor"].ToString();
                                                        rVenda.Nm_clifor = linha["nm_clifor"].ToString();
                                                    }
                                                    else
                                                    {
                                                        MessageBox.Show("Obrigatorio informar cliente para repasse de cheque.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                        if (St_conveniencia)
                                                            CancelarVenda();
                                                        return;
                                                    }
                                                }
                                            }
                                        }
                                        if (fTroco.lChTroco != null)
                                            fTroco.lChTroco.ForEach(p => lCarta[0].lChTroco.Add(p));
                                        if (fTroco.Vl_trocoDinheiro > decimal.Zero)
                                            lCarta[0].Vl_trocoPDV = fTroco.Vl_trocoDinheiro;
                                        else lCarta[0].Vl_trocoPDV = decimal.Zero;
                                    }
                                    else
                                    {
                                        MessageBox.Show("Obrigatorio identificar tipo TROCO.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        if (St_conveniencia)
                                            CancelarVenda();
                                        return;
                                    }
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Obrigatorio informar carta frete para finalizar venda. ");
                            if (St_conveniencia)
                                CancelarVenda();
                            return;
                        }
                    }
                    rVenda.lPortador = lCarta;
                }
                else
                {
                    using (PDV.TFFecharCupom fFechar = new PDV.TFFecharCupom())
                    {
                        fFechar.Text = St_conveniencia ? "FINALIZAR VENDA CONVENIENCIA" : "FINALIZAR VENDA POSTO COMBUSTIVEL";
                        fFechar.Id_caixaPDV = rCaixa.Id_caixastr;
                        fFechar.rCupom = rVenda;
                        fFechar.pCd_empresa = rVenda.Cd_empresa;
                        fFechar.pCd_clifor = rVenda.Cd_clifor.Trim().Equals(lCfg[0].Cd_clifor.Trim()) ? string.Empty : rVenda.Cd_clifor;
                        fFechar.pNm_clifor = rVenda.Cd_clifor.Trim().Equals(lCfg[0].Cd_clifor.Trim()) ? string.Empty : rVenda.Nm_clifor;
                        fFechar.pCd_operador = Cd_operador;
                        fFechar.rCfg = St_conveniencia ? rCfgConv : lCfg[0];
                        fFechar.pVl_receber = rVenda.lItem.Sum(p => p.Vl_subtotalliquido);
                        fFechar.LoginPDV = LoginPdv;
                        fFechar.lPdv = lPdv;
                        if (fFechar.ShowDialog() == DialogResult.OK)
                            if (fFechar.lPortador != null)
                                rVenda.lPortador = fFechar.lPortador;
                            else
                            {
                                MessageBox.Show("Obrigatorio informar financeiro para fechar venda.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                if (St_conveniencia)
                                    CancelarVenda();
                                return;
                            }
                        else
                        {
                            MessageBox.Show("Obrigatorio informar financeiro para fechar venda.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            if (St_conveniencia)
                                CancelarVenda();
                            return;
                        }
                    }
                }
                try
                {
                    CamadaNegocio.Faturamento.PDV.TCN_VendaRapida.GravarVendaRapida(rVenda, null, null, null);
                    st_vendagravada = true;
                    //Verificar se venda gerou credito
                    List<string> Texto = new List<string>();
                    Texto.Add("                EXTRATO CREDITO                 ");
                    new CamadaDados.Financeiro.Adiantamento.TCD_LanAdiantamento().Select(
                    new TpBusca[]
                    {
                        new TpBusca()
                        {
                            vNM_Campo = string.Empty,
                            vOperador = "exists",
                            vVL_Busca = "(select 1 from tb_pdv_cupom_x_movcaixa x " +
                                        "where x.id_adto = a.id_adto " +
                                        "and x.cd_empresa = '" + rVenda.Cd_empresa.Trim() + "' " +
                                        "and x.id_cupom = " + rVenda.Id_vendarapidastr + ")"
                        }
                    }, 0, string.Empty).ForEach(p =>
                    {
                        Texto.Add("Nº Credito: ".FormatStringDireita(38, ' ') + p.Id_adto.ToString());
                        Texto.Add("Data: ".FormatStringDireita(38, ' ') + p.Dt_lanctostring);
                        Texto.Add("Valor: ".FormatStringDireita(38, ' ') + p.Vl_total_devolver.ToString("N2", new System.Globalization.CultureInfo("pt-BR")));
                    });
                    if (Texto.Count > 1)
                        ImprimirDevCredito(Texto);
                   
                    //Buscar total abastecimentos em espera
                    if (!St_conveniencia)
                        tslVendaEspera.Text = new CamadaDados.PostoCombustivel.TCD_VendaCombustivel().BuscarEscalar(
                                    new TpBusca[]
                                    {
                                        new TpBusca()
                                        {
                                            vNM_Campo = "a.cd_empresa",
                                            vOperador = "=",
                                            vVL_Busca = "'" + rCfgPosto.Cd_empresa.Trim() + "'"
                                        },
                                        new TpBusca()
                                        {
                                            vNM_Campo = "isnull(a.st_registro, 'A')",
                                            vOperador = "=",
                                            vVL_Busca = "'E'"
                                        },
                                        new TpBusca()
                                        {
                                            vNM_Campo = "a.loginespera",
                                            vOperador = "=",
                                            vVL_Busca = "'" + lSessao[0].Login.Trim() + "'"
                                        }
                                    }, "isnull(count(a.id_venda), 0)").ToString();
                    //buscar endereco uf clifor
                    object objUf = new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco().BuscarEscalar(
                                    new TpBusca[]
                                    {
                                         new TpBusca()
                                         {
                                             vNM_Campo = "a.cd_clifor",
                                             vOperador = "=",
                                             vVL_Busca = "'" + rVenda.Cd_clifor.Trim() + "'"
                                         }
                                    }, "a.cd_uf");
                    if (objUf != null)
                        rVenda.Cd_ufCliente = objUf.ToString();
                    //Verificar se CFG Posto exige Nf Direta para cliente fora doe estado
                    if ((rCfgPosto.St_NFDiretaForaUFbool && 
                        (new CamadaDados.Faturamento.PDV.TCD_VendaRapida().BuscarEscalar(
                            new TpBusca[]
                            {
                                new TpBusca()
                                {
                                    vNM_Campo = "a.cd_clifor",
                                    vOperador = "=",
                                    vVL_Busca = "'" + rVenda.Cd_clifor.Trim() + "'"
                                },
                                new TpBusca()
                                {
                                    vNM_Campo = "a.cd_endereco",
                                    vOperador = "=",
                                    vVL_Busca = "'" + rVenda.Cd_endereco.Trim() + "'"
                                },
                                new TpBusca()
                                {
                                    vNM_Campo = "endEmp.cd_uf",
                                    vOperador = "<>",
                                    vVL_Busca = "'" + rVenda.Cd_ufCliente.Trim() + "'"
                                }
                            }, "1") != null)) &&
                        rVenda.lItem.Exists(p => new CamadaDados.Estoque.Cadastros.TCD_CadProduto().ProdutoCombustivel(p.Cd_produto) ||
                                                new CamadaDados.Estoque.Cadastros.TCD_CadProduto().ProdutoLubrificante(p.Cd_produto)))
                        NfDiretaFinalizarVenda();
                    else
                    {
                        using (TFGerarDocFiscal fDoc = new TFGerarDocFiscal())
                        {
                            if (fDoc.ShowDialog() == DialogResult.OK)
                                if (fDoc.St_nfe)
                                    NfDiretaFinalizarVenda();
                                else
                                {
                                    if (lCfg[0].Cd_modelonfce.Trim().Equals("65"))
                                    {
                                        try
                                        {
                                            if (fDoc.St_nfvinculada &&
                                                (string.IsNullOrEmpty(rVenda.Cd_clifor) || rVenda.Cd_clifor.Trim().Equals(lCfg[0].Cd_clifor.Trim())))
                                            {
                                                DataRowView linha = FormBusca.UtilPesquisa.BTN_BuscaClifor(null, string.Empty);
                                                if (linha != null)
                                                {
                                                    rVenda.Cd_clifor = linha["cd_clifor"].ToString();
                                                    rVenda.Nm_clifor = linha["nm_clifor"].ToString();
                                                    rVenda.Nr_cgccpf = linha["NR_CGC_CPF"].ToString();
                                                    //Buscar endereco clifor
                                                    CamadaDados.Financeiro.Cadastros.TList_CadEndereco lEnd =
                                                    CamadaNegocio.Financeiro.Cadastros.TCN_CadEndereco.Buscar(rVenda.Cd_clifor,
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
                                                                                                                null);
                                                    if (lEnd.Count > 0)
                                                    {
                                                        rVenda.Cd_endereco = lEnd[0].Cd_endereco;
                                                        rVenda.Ds_endereco = lEnd[0].Ds_endereco;
                                                    }
                                                }
                                            }
                                            //Processar cupom fiscal
                                            PDV.TDadosCupom dados = new PDV.TDadosCupom();
                                            dados.lItens = CamadaNegocio.Faturamento.PDV.TCN_VendaRapida_Item.Buscar(rVenda.Id_vendarapidastr,
                                                                                                                     rVenda.Cd_empresa,
                                                                                                                     false,
                                                                                                                     string.Empty,
                                                                                                                     null);
                                            dados.rSessao = lSessao[0];
                                            dados.Cd_clifor = rVenda.Cd_clifor;
                                            dados.Nm_clifor = rVenda.Nm_clifor;
                                            dados.CpfCgc = rVenda.Nr_cgccpf;
                                            dados.Cd_endereco = rVenda.Cd_endereco;
                                            dados.Endereco = rVenda.Ds_endereco;
                                            dados.Mensagem = string.Empty;
                                            dados.lPortador = rVenda.lPortador.FindAll(p => p.Vl_pagtoPDV > decimal.Zero);
                                            dados.St_vendacombustivel = true;
                                            dados.St_convenio = false;
                                            dados.St_agruparProduto = false;
                                            dados.Placa = rVenda.Placa;
                                            PDV.TGerenciarCupom.ProcessarCupom(ref dados);
                                            CamadaDados.Faturamento.PDV.TRegistro_NFCe rNFCe = new PDV.TGerenciarCupom().GerarNFCe(dados, false);
                                            if (rNFCe != null)
                                                if (!rNFCe.St_contingencia)
                                                {
                                                    using (NFCe.TFGerenciarNFCe fGerNfe = new NFCe.TFGerenciarNFCe())
                                                    {
                                                        rNFCe = CamadaNegocio.Faturamento.PDV.TCN_NFCe.BuscarNFCe(rNFCe.Cd_empresa,
                                                                                                                  rNFCe.Id_nfcestr,
                                                                                                                  null);
                                                        fGerNfe.rNFCe = rNFCe;
                                                        fGerNfe.ShowDialog();
                                                    }
                                                    if (dados.St_faturardireto || fDoc.St_nfvinculada)
                                                        if (new CamadaDados.Faturamento.NFCe.TCD_Lote_X_NFCe().BuscarEscalar(
                                                            new TpBusca[]
                                                            {
                                                            new TpBusca()
                                                            {
                                                                vNM_Campo = "a.cd_empresa",
                                                                vOperador = "=",
                                                                vVL_Busca = "'" + rNFCe.Cd_empresa.Trim() + "'"
                                                            },
                                                            new TpBusca()
                                                            {
                                                                vNM_Campo = "a.id_cupom",
                                                                vOperador = "=",
                                                                vVL_Busca = rNFCe.Id_nfcestr
                                                            },
                                                            new TpBusca()
                                                            {
                                                                vNM_Campo = "a.status",
                                                                vOperador = "=",
                                                                vVL_Busca = "'100'"
                                                            }
                                                            }, "1") != null)
                                                            ProcessaCfVincular(new List<CamadaDados.Faturamento.PDV.TRegistro_NFCe> { rNFCe }, rNFCe.Cd_empresa, rNFCe.Cd_clifor);
                                                }
                                                else
                                                {
                                                    FormRelPadrao.Relatorio Rel = new FormRelPadrao.Relatorio();
                                                    BindingSource dts = new BindingSource();
                                                    dts.DataSource = new CamadaDados.Faturamento.PDV.TList_NFCe_Item();
                                                    Rel.DTS_Relatorio = dts;// bsItens;
                                                                            //DTS Cupom
                                                    BindingSource bsNFCe = new BindingSource();
                                                    bsNFCe.DataSource = CamadaNegocio.Faturamento.PDV.TCN_NFCe.BuscarNFCe(rNFCe.Cd_empresa,
                                                                                                                            rNFCe.Id_nfcestr,
                                                                                                                            null);
                                                    NFCe.TGerarQRCode.GerarQRCode2(bsNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe);
                                                    Rel.Adiciona_DataSource("DTS_NFCE", bsNFCe);
                                                    //Buscar Empresa
                                                    BindingSource bsEmpresa = new BindingSource();
                                                    bsEmpresa.DataSource = new CamadaDados.Diversos.TList_CadEmpresa { (bsNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).rEmpresa };
                                                    Rel.Adiciona_DataSource("DTS_EMP", bsEmpresa);
                                                    //Forma Pagamento
                                                    BindingSource bsPagto = new BindingSource();
                                                    CamadaDados.Financeiro.Duplicata.TList_RegLanDuplicata lDup =
                                                    new CamadaDados.Financeiro.Duplicata.TCD_LanDuplicata().Select(
                                                    new TpBusca[]
                                                    {
                                                        new TpBusca()
                                                        {
                                                            vNM_Campo = string.Empty,
                                                            vOperador = "exists",
                                                            vVL_Busca = "(select 1 from TB_PDV_CupomFiscal_X_Duplicata x " +
                                                                        "inner join TB_PDV_Cupom_X_VendaRapida y " +
                                                                        "on x.cd_empresa = y.cd_empresa " +
                                                                        "and x.id_cupom = y.id_vendarapida " +
                                                                        "where x.cd_empresa = a.cd_empresa " +
                                                                        "and x.Nr_Lancto = a.Nr_Lancto " +
                                                                        "and y.cd_empresa = '" + rNFCe.Cd_empresa.Trim() + "' " +
                                                                        "and y.id_cupom = " + rNFCe.Id_nfcestr + ")"
                                                        }
                                                    }, 1, string.Empty);
                                                    if (lDup.Count > 0)
                                                        bsPagto.DataSource = new List<CamadaDados.Faturamento.PDV.TRegistro_MovCaixa>()
                                                                            {
                                                                                new CamadaDados.Faturamento.PDV.TRegistro_MovCaixa()
                                                                                {
                                                                                    Tp_portador = "05",
                                                                                    Vl_recebido = lDup[0].Vl_documento
                                                                                }
                                                                            };
                                                    else
                                                        bsPagto.DataSource = new CamadaDados.Faturamento.PDV.TCD_CaixaPDV().SelectMovCaixa(
                                                                                new TpBusca[]
                                                                                {
                                                                                new TpBusca()
                                                                                {
                                                                                    vNM_Campo = string.Empty,
                                                                                    vOperador = "exists",
                                                                                    vVL_Busca = "(select 1 from tb_pdv_cupom_x_vendarapida x " +
                                                                                                "where x.cd_empresa = a.cd_empresa " +
                                                                                                "and x.id_vendarapida = a.id_cupom " +
                                                                                                "and x.cd_empresa = '" + rNFCe.Cd_empresa.Trim() + "' " +
                                                                                                "and x.id_cupom = " + rNFCe.Id_nfcestr + ")"
                                                                                }
                                                                                }, string.Empty).GroupBy(v => v.Tp_portador,
                                                                                                    (aux, venda) =>
                                                                                                        new
                                                                                                        {
                                                                                                            tp_portador = aux,
                                                                                                            Vl_recebido = venda.Sum(x => x.Vl_recebido),
                                                                                                            Vl_troco_ch = venda.Sum(x => x.Vl_troco_ch),
                                                                                                            Vl_troco_dh = venda.Sum(x => x.Vl_troco_dh)
                                                                                                        }).ToList();
                                                    Rel.Adiciona_DataSource("DTS_PAGTO", bsPagto);
                                                    //Parametros
                                                    Rel.Parametros_Relatorio.Add("TOT_IMP_APROX", (bsNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).lItem.Sum(p => p.Vl_imposto_Aprox));
                                                    Rel.Parametros_Relatorio.Add("QTD_ITENS", (bsNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).lItem.Count);
                                                    Rel.Parametros_Relatorio.Add("TOT_SUBTOTAL", (bsNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).lItem.Sum(p => p.Vl_subtotal));
                                                    Rel.Parametros_Relatorio.Add("TOT_ACRESCIMO", (bsNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).lItem.Sum(p => p.Vl_acrescimo));
                                                    Rel.Parametros_Relatorio.Add("TOT_DESCONTO", (bsNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).lItem.Sum(p => p.Vl_desconto));
                                                    Rel.Parametros_Relatorio.Add("ST_VIAEMPRESA", "N");
                                                    object obj = new CamadaDados.Faturamento.NFCe.TCD_LoteNFCe().BuscarEscalar(
                                                                    new TpBusca[]
                                                                    {
                                                                        new TpBusca()
                                                                        {
                                                                            vNM_Campo = string.Empty,
                                                                            vOperador = "exists",
                                                                            vVL_Busca = "(select 1 from TB_FAT_Lote_X_NFCe x " +
                                                                                        "where x.cd_empresa = a.cd_empresa " +
                                                                                        "and x.id_lote = a.id_lote " +
                                                                                        "and x.status = '100')"
                                                                        }
                                                                    }, "a.tp_ambiente");
                                                    Rel.Parametros_Relatorio.Add("TP_AMBIENTE", obj == null ? string.Empty : obj.ToString());
                                                    string dadoscf = CamadaNegocio.Faturamento.PDV.TCN_NFCe.BuscarPlacaKM((bsNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).Cd_empresa,
                                                                                                                          (bsNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).Id_nfcestr,
                                                                                                                          null);
                                                    if (!string.IsNullOrEmpty(dadoscf))
                                                    {
                                                        string[] linhas = dadoscf.Split(new char[] { ':' });
                                                        string placa = string.Empty;
                                                        string km = string.Empty;
                                                        string frota = string.Empty;
                                                        string requisicao = string.Empty;
                                                        string nm_motorista = string.Empty;
                                                        string cpf_motorista = string.Empty;
                                                        string media = string.Empty;
                                                        string virg = string.Empty;
                                                        foreach (string s in linhas)
                                                        {
                                                            string[] colunas = s.Split(new char[] { '/' });
                                                            placa += virg + colunas[0];
                                                            km += virg + colunas[1];
                                                            frota += virg + colunas[2];
                                                            requisicao += virg + colunas[3];
                                                            nm_motorista += virg + colunas[4];
                                                            cpf_motorista += virg + colunas[5];
                                                            media += virg + colunas[6];
                                                            virg = ",";
                                                        }
                                                        if (!string.IsNullOrEmpty(placa))
                                                            Rel.Parametros_Relatorio.Add("PLACA", placa);
                                                        if (!string.IsNullOrEmpty(km))
                                                            Rel.Parametros_Relatorio.Add("KM", km);
                                                        if (!string.IsNullOrEmpty(media))
                                                            Rel.Parametros_Relatorio.Add("MEDIA", media + " KM/LT");
                                                        if (!string.IsNullOrEmpty(frota))
                                                            Rel.Parametros_Relatorio.Add("FROTA", frota);
                                                        if (!string.IsNullOrEmpty(requisicao))
                                                            Rel.Parametros_Relatorio.Add("REQUISICAO", requisicao);
                                                        if (!string.IsNullOrEmpty(nm_motorista))
                                                            Rel.Parametros_Relatorio.Add("NM_MOTORISTA", nm_motorista);
                                                        if (!string.IsNullOrEmpty(cpf_motorista))
                                                            Rel.Parametros_Relatorio.Add("CPF_MOTORISTA", cpf_motorista);
                                                    }
                                                    Rel.Nome_Relatorio = "DANFE_NFCE";
                                                    Rel.NM_Classe = "TFConsultaFrenteCaixa";
                                                    Rel.Modulo = "FAT";
                                                    Rel.Ident = "DANFE_NFCE";
                                                    if (CamadaNegocio.ConfigGer.TCN_CadParamGer.BuscaVlBool("ST_IMP_DANFE_NFCE_DETALHADA", null))
                                                    {
                                                        BindingSource bsItens = new BindingSource();
                                                        bsItens.DataSource = (bsNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).lItem;
                                                        Rel.DTS_Relatorio = bsItens;
                                                    }
                                                    if (rNFCe.Id_contingencia.HasValue)
                                                        if (Rel.Parametros_Relatorio.ContainsKey("ST_VIAEMPRESA"))
                                                            Rel.Parametros_Relatorio["ST_VIAEMPRESA"] = "S";
                                                        else
                                                            Rel.Parametros_Relatorio.Add("ST_VIAEMPRESA", "S");
                                                    //Verificar se existe Impressora padrão para o PDV
                                                    obj = new CamadaDados.Faturamento.Cadastros.TCD_PontoVenda().BuscarEscalar(
                                                            new TpBusca[]
                                                            {
                                                            new TpBusca()
                                                            {
                                                                vNM_Campo = "a.cd_terminal",
                                                                vOperador = "=",
                                                                vVL_Busca = "'" + Utils.Parametros.pubTerminal.Trim() + "'"
                                                            }
                                                            }, "a.impressorapadrao");
                                                    string print = obj == null ? string.Empty : obj.ToString();
                                                    if (string.IsNullOrEmpty(print))
                                                        using (Parametros.Diversos.TFListaImpressoras fLista = new Parametros.Diversos.TFListaImpressoras())
                                                        {
                                                            if (fLista.ShowDialog() == DialogResult.OK)
                                                                if (!string.IsNullOrEmpty(fLista.Impressora))
                                                                    print = fLista.Impressora;

                                                        }
                                                    //Imprimir
                                                    Rel.ImprimiGraficoReduzida(print,
                                                                                true,
                                                                                false,
                                                                                null,
                                                                                string.Empty,
                                                                                string.Empty,
                                                                                1);
                                                    if ((bsNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).Id_contingencia.HasValue &&
                                                        (bsNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).rCfgNFCe.Tp_ambiente_nfce.Equals(1))
                                                        Rel.ImprimiGraficoReduzida(print,
                                                                                    true,
                                                                                    false,
                                                                                    null,
                                                                                    string.Empty,
                                                                                    string.Empty,
                                                                                    1);
                                                }
                                        }
                                        catch (Exception ex)
                                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                                    }
                                    else
                                        MessageBox.Show("Não existe série modelo 65 configurada na CFG.Frente de Caixa!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                        }
                }
                    //layout Tela
                    if (st_vendagravada)
                    {
                        ImprimirConfissaoDivida();
                        rVenda = null;
                        //rtCupom.Clear();
                        Cd_clifor.Text = lCfg[0].Cd_clifor;
                        NM_Clifor.Text = lCfg[0].Nm_clifor;
                        Cd_clifor.BackColor = Color.White;
                        cd_endereco.Text = lCfg[0].Cd_endereco;
                        lblCxLivre.Visible = true;
                        lblTotalItens.Text = string.Empty;
                        lblTotalDesconto.Text = string.Empty;
                        lblTotalCupom.Text = string.Empty;
                        placa.Clear();
                        St_placacadastrada = false;
                        //Buscar venda Mesa em Aberto
                        object aux = new CamadaDados.PostoCombustivel.TCD_VendaMesaConv().BuscarEscalar(
                                        new TpBusca[]
                                    {
                                        new TpBusca()
                                        {
                                            vNM_Campo = "a.cd_empresa",
                                            vOperador = "=",
                                            vVL_Busca = "'" + (string.IsNullOrEmpty(rCfgPosto.Cd_conveniencia) ? rCfgPosto.Cd_empresa : rCfgConv.Cd_empresa) + "'"
                                        },
                                        new TpBusca()
                                        {
                                            vNM_Campo = "isnull(a.st_registro, 'A')",
                                            vOperador = "=",
                                            vVL_Busca = "'A'"
                                        },
                                        new TpBusca()
                                        {
                                            vNM_Campo = "a.qtd_faturar",
                                            vOperador = ">",
                                            vVL_Busca = "0"
                                        }
                                    }, "count(*)");
                        lblConvEspera.Text = aux != null ? aux.ToString() : "0";
                    }
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                finally
                {
                    if (St_conveniencia)
                        CancelarVenda();
                }
            }
        }

        private void NfDiretaFinalizarVenda()
        {
            CamadaDados.Faturamento.Pedido.TRegistro_Pedido rPed = null;
            CamadaDados.Faturamento.Pedido.TRegistro_Pedido rPedServico = null;
            CamadaDados.Financeiro.Cadastros.TList_CadEndereco lEnd = null;
            string Placa_km = string.Empty;
            try
            {
                string pCd_clifor = rVenda.Cd_clifor;
                if (string.IsNullOrEmpty(pCd_clifor))
                {
                    DataRowView linha = FormBusca.UtilPesquisa.BTN_BuscaClifor(null, string.Empty);
                    if (linha != null)
                        pCd_clifor = linha["cd_clifor"].ToString();
                }

                if (!string.IsNullOrEmpty(pCd_clifor))
                {
                    //Buscar endereco
                    lEnd = CamadaNegocio.Financeiro.Cadastros.TCN_CadEndereco.Buscar(pCd_clifor,
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
                    string pCd_endereco = string.Empty;
                    if (lEnd.Count.Equals(1))
                        pCd_endereco = lEnd[0].Cd_endereco;
                    else
                    {
                        string vColunas = "a.ds_endereco|Endereço|200;" +
                                          "a.cd_endereco|Codigo|80;" +
                                          "a.bairro|Bairro|80;" +
                                          "a.insc_estadual|Insc. Estadual|80";
                        DataRowView linha = FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, null, new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco(), "a.cd_clifor|=|'" + pCd_clifor.Trim() + "'");
                        if (linha != null)
                            pCd_endereco = linha["cd_endereco"].ToString();
                    }
                    if (string.IsNullOrEmpty(pCd_endereco))
                    {
                        MessageBox.Show("Obrigatorio informar endereço cliente NFe.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    Proc_Commoditties.TProcessarPedidoVendaRapida.ProcessarPedido(pCd_clifor,
                                                                                  pCd_endereco,
                                                                                  false,
                                                                                  rVenda.Placa,
                                                                                  lCfg[0],
                                                                                  rVenda.lItem,
                                                                                  ref rPed,
                                                                                  ref rPedServico);
                    CamadaNegocio.Faturamento.PDV.TCN_Pedido_X_VendaRapida.ProcessarPedido(rPed, null);
                    //Buscar pedido
                    rPed = CamadaNegocio.Faturamento.Pedido.TCN_Pedido.Busca_Registro_Pedido(rPed.Nr_pedido.ToString(), null);
                    //Buscar itens pedido
                    CamadaNegocio.Faturamento.Pedido.TCN_Pedido.Busca_Pedido_Itens(rPed, false, null);
                    //Se o CMI do pedido gerar financeiro
                    CamadaDados.Financeiro.Duplicata.TList_RegLanParcela lParcVinculado = new CamadaDados.Financeiro.Duplicata.TList_RegLanParcela();
                    //Buscar parcelas em aberto dos cupons que estao sendo vinculados
                    new CamadaDados.Financeiro.Duplicata.TCD_LanParcela().Select(
                        new TpBusca[]
                        {
                            new TpBusca()
                            {
                                vNM_Campo = "isnull(dup.st_registro, 'A')",
                                vOperador = "<>",
                                vVL_Busca = "'C'"
                            },
                            new TpBusca()
                            {
                                vNM_Campo = "isnull(a.st_registro, 'A')",
                                vOperador = "in",
                                vVL_Busca = "('A', 'P')"
                            },
                            new TpBusca()
                            {
                                vNM_Campo = string.Empty,
                                vOperador = "exists",
                                vVL_Busca = "(select 1 from tb_pdv_cupomfiscal_x_duplicata x " +
                                            "where x.cd_empresa = a.cd_empresa " +
                                            "and x.nr_lancto = a.nr_lancto " +
                                            "and x.cd_empresa = '" + rVenda.Cd_empresa.Trim() + "' " +
                                            "and x.id_cupom = " + rVenda.Id_vendarapidastr + ")"
                            }
                        }, 0, string.Empty, "a.dt_vencto, c.nm_clifor", string.Empty).ForEach(v => lParcVinculado.Add(v));
                    //Gerar Nota Fiscal
                    CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento rFat =
                        Proc_Commoditties.TProcessaPedFaturar.ProcessaPedFaturar(rPed, true, lParcVinculado.Sum(p => p.Vl_atual));
                    //Vincular financeiro a Nota Fiscal
                    rFat.lParcAgrupar = lParcVinculado;
                    //Montar obs com placa-km
                    Placa_km = CamadaNegocio.Faturamento.PDV.TCN_VendaRapida.BuscarPlacaKM(rVenda.Cd_empresa, rVenda.Id_vendarapidastr, null);
                    if (!string.IsNullOrEmpty(Placa_km))
                        rFat.Dadosadicionais += (!string.IsNullOrEmpty(rFat.Dadosadicionais) ? "\r\n" : string.Empty) + "Placa/KM " + Placa_km;
                    //Gravar Nota Fiscal
                    CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento.GravarFaturamento(rFat, null, null);
                    using (srvNFE.TFGerenciarNFe fGerNfe = new srvNFE.TFGerenciarNFe())
                    {
                        rFat = CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento.BuscarNF(rFat.Cd_empresa,
                                                                                                rFat.Nr_lanctofiscalstr,
                                                                                                null);
                        fGerNfe.rNfe = rFat;
                        fGerNfe.ShowDialog();
                    }
                }
                else
                    MessageBox.Show("Obrigatorio informar cliente da NFe.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                if (rPed != null)
                    CamadaNegocio.Faturamento.Pedido.TCN_Pedido.Deleta_Pedido(rPed, null);
                MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GerarCF()
        {
            using (TFGerarCFCombustivel fGerar = new TFGerarCFCombustivel())
            {
                fGerar.Cd_empresa = rCfgPosto.Cd_empresa;
                if (fGerar.ShowDialog() == DialogResult.OK)
                    if (fGerar.lItens != null)
                        try
                        {
                            if (lCfg[0].Cd_modelonfce.Trim().Equals("65"))
                            {
                                //Processar cupom fiscal
                                PDV.TDadosCupom dados = new PDV.TDadosCupom();
                                dados.lItens = fGerar.lItens;
                                dados.rSessao = lSessao[0];
                                dados.Cd_clifor = string.Empty;
                                dados.Nm_clifor = string.Empty;
                                dados.CpfCgc = string.Empty;
                                dados.Endereco = string.Empty;
                                dados.Mensagem = string.Empty;
                                dados.lPortador = new List<CamadaDados.Financeiro.Cadastros.TRegistro_CadPortador>();
                                dados.St_vendacombustivel = true;
                                dados.St_convenio = false;
                                dados.St_cupomavulso = true;
                                dados.St_agruparProduto = false;
                                PDV.TGerenciarCupom.ProcessarCupom(ref dados);
                                CamadaDados.Faturamento.PDV.TRegistro_NFCe rNFCe = new PDV.TGerenciarCupom().GerarNFCe(dados, false);
                                if (rNFCe != null)
                                    if (!rNFCe.St_contingencia)
                                    {
                                        using (NFCe.TFGerenciarNFCe fGerNfe = new NFCe.TFGerenciarNFCe())
                                        {
                                            rNFCe = CamadaNegocio.Faturamento.PDV.TCN_NFCe.BuscarNFCe(rNFCe.Cd_empresa,
                                                                                                      rNFCe.Id_nfcestr,
                                                                                                      null);
                                            fGerNfe.rNFCe = rNFCe;
                                            fGerNfe.ShowDialog();
                                        }
                                        if (dados.St_faturardireto)
                                            if (new CamadaDados.Faturamento.NFCe.TCD_Lote_X_NFCe().BuscarEscalar(
                                                new TpBusca[]
                                                {
                                                    new TpBusca()
                                                    {
                                                        vNM_Campo = "a.cd_empresa",
                                                        vOperador = "=",
                                                        vVL_Busca = "'" + rNFCe.Cd_empresa.Trim() + "'"
                                                    },
                                                    new TpBusca()
                                                    {
                                                        vNM_Campo = "a.id_cupom",
                                                        vOperador = "=",
                                                        vVL_Busca = rNFCe.Id_nfcestr
                                                    },
                                                    new TpBusca()
                                                    {
                                                        vNM_Campo = "a.status",
                                                        vOperador = "=",
                                                        vVL_Busca = "'100'"
                                                    }
                                                }, "1") != null)
                                                ProcessaCfVincular(new List<CamadaDados.Faturamento.PDV.TRegistro_NFCe> { rNFCe }, rNFCe.Cd_empresa, rNFCe.Cd_clifor);
                                    }
                                    else
                                    {
                                        FormRelPadrao.Relatorio Rel = new FormRelPadrao.Relatorio();
                                        BindingSource dts = new BindingSource();
                                        dts.DataSource = new CamadaDados.Faturamento.PDV.TList_NFCe_Item();
                                        Rel.DTS_Relatorio = dts;// bsItens;
                                        //DTS Cupom
                                        BindingSource bsNFCe = new BindingSource();
                                        bsNFCe.DataSource = CamadaNegocio.Faturamento.PDV.TCN_NFCe.Buscar(rNFCe.Id_nfcestr,
                                                                                                          string.Empty,
                                                                                                          rNFCe.Cd_empresa,
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
                                                                                                          false,
                                                                                                          string.Empty,
                                                                                                          string.Empty,
                                                                                                          1,
                                                                                                          null);
                                        (bsNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).lItem =
                                            CamadaNegocio.Faturamento.PDV.TCN_NFCe_Item.Buscar((bsNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).Id_nfcestr,
                                                                                               (bsNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).Cd_empresa,
                                                                                               string.Empty,
                                                                                               null);
                                        NFCe.TGerarQRCode.GerarQRCode2(bsNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe);
                                        Rel.Adiciona_DataSource("DTS_NFCE", bsNFCe);
                                        //Buscar Empresa
                                        BindingSource bsEmpresa = new BindingSource();
                                        bsEmpresa.DataSource = CamadaNegocio.Diversos.TCN_CadEmpresa.Busca(rNFCe.Cd_empresa,
                                                                                                            string.Empty,
                                                                                                            string.Empty,
                                                                                                            null);
                                        Rel.Adiciona_DataSource("DTS_EMP", bsEmpresa);
                                        //Forma Pagamento
                                        BindingSource bsPagto = new BindingSource();
                                        CamadaDados.Financeiro.Duplicata.TList_RegLanDuplicata lDup =
                                        new CamadaDados.Financeiro.Duplicata.TCD_LanDuplicata().Select(
                                        new TpBusca[]
                                        {
                                            new TpBusca()
                                            {
                                                vNM_Campo = string.Empty,
                                                vOperador = "exists",
                                                vVL_Busca = "(select 1 from TB_PDV_CupomFiscal_X_Duplicata x " +
                                                            "inner join TB_PDV_Cupom_X_VendaRapida y " +
                                                            "on x.cd_empresa = y.cd_empresa " +
                                                            "and x.id_cupom = y.id_vendarapida " +
                                                            "where x.cd_empresa = a.cd_empresa " +
                                                            "and x.Nr_Lancto = a.Nr_Lancto " +
                                                            "and y.cd_empresa = '" + rNFCe.Cd_empresa.Trim() + "' " +
                                                            "and y.id_cupom = " + rNFCe.Id_nfcestr + ")"
                                            }
                                        }, 1, string.Empty);
                                        if (lDup.Count > 0)
                                            bsPagto.DataSource = new List<CamadaDados.Faturamento.PDV.TRegistro_MovCaixa>()
                                                                    {
                                                                        new CamadaDados.Faturamento.PDV.TRegistro_MovCaixa()
                                                                        {
                                                                            Tp_portador = "05",
                                                                            Vl_recebido = lDup[0].Vl_documento
                                                                        }
                                                                    };
                                        else
                                            bsPagto.DataSource = new CamadaDados.Faturamento.PDV.TCD_CaixaPDV().SelectMovCaixa(
                                                                    new TpBusca[]
                                                                    {
                                                                        new TpBusca()
                                                                        {
                                                                            vNM_Campo = string.Empty,
                                                                            vOperador = "exists",
                                                                            vVL_Busca = "(select 1 from tb_pdv_cupom_x_vendarapida x " +
                                                                                        "where x.cd_empresa = a.cd_empresa " +
                                                                                        "and x.id_vendarapida = a.id_cupom " +
                                                                                        "and x.cd_empresa = '" + rNFCe.Cd_empresa.Trim() + "' " +
                                                                                        "and x.id_cupom = " + rNFCe.Id_nfcestr + ")"
                                                                        }
                                                                    }, string.Empty).GroupBy(v => v.Tp_portador,
                                                                                        (aux, venda) =>
                                                                                            new
                                                                                            {
                                                                                                tp_portador = aux,
                                                                                                Vl_recebido = venda.Sum(x => x.Vl_recebido),
                                                                                                Vl_troco_ch = venda.Sum(x => x.Vl_troco_ch),
                                                                                                Vl_troco_dh = venda.Sum(x => x.Vl_troco_dh)
                                                                                            }).ToList();
                                        Rel.Adiciona_DataSource("DTS_PAGTO", bsPagto);
                                        //Parametros
                                        Rel.Parametros_Relatorio.Add("TOT_IMP_APROX", (bsNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).lItem.Sum(p => p.Vl_imposto_Aprox));
                                        Rel.Parametros_Relatorio.Add("QTD_ITENS", (bsNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).lItem.Count);
                                        Rel.Parametros_Relatorio.Add("TOT_SUBTOTAL", (bsNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).lItem.Sum(p => p.Vl_subtotal));
                                        Rel.Parametros_Relatorio.Add("TOT_ACRESCIMO", (bsNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).lItem.Sum(p => p.Vl_acrescimo));
                                        Rel.Parametros_Relatorio.Add("TOT_DESCONTO", (bsNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).lItem.Sum(p => p.Vl_desconto));
                                        Rel.Parametros_Relatorio.Add("ST_VIAEMPRESA", "N");
                                        object obj = new CamadaDados.Faturamento.NFCe.TCD_LoteNFCe().BuscarEscalar(
                                                        new TpBusca[]
                                                        {
                                                            new TpBusca()
                                                            {
                                                                vNM_Campo = string.Empty,
                                                                vOperador = "exists",
                                                                vVL_Busca = "(select 1 from TB_FAT_Lote_X_NFCe x " +
                                                                            "where x.cd_empresa = a.cd_empresa " +
                                                                            "and x.id_lote = a.id_lote " +
                                                                            "and x.status = '100')"
                                                            }
                                                        }, "a.tp_ambiente");
                                        Rel.Parametros_Relatorio.Add("TP_AMBIENTE", obj == null ? string.Empty : obj.ToString());
                                        string dadoscf = CamadaNegocio.Faturamento.PDV.TCN_NFCe.BuscarPlacaKM((bsNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).Cd_empresa,
                                                                                                              (bsNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).Id_nfcestr,
                                                                                                              null);
                                        if (!string.IsNullOrEmpty(dadoscf))
                                        {
                                            string[] linhas = dadoscf.Split(new char[] { ':' });
                                            string placa = string.Empty;
                                            string km = string.Empty;
                                            string frota = string.Empty;
                                            string requisicao = string.Empty;
                                            string nm_motorista = string.Empty;
                                            string cpf_motorista = string.Empty;
                                            string media = string.Empty;
                                            string virg = string.Empty;
                                            foreach (string s in linhas)
                                            {
                                                string[] colunas = s.Split(new char[] { '/' });
                                                placa += virg + colunas[0];
                                                km += virg + colunas[1];
                                                frota += virg + colunas[2];
                                                requisicao += virg + colunas[3];
                                                nm_motorista += virg + colunas[4];
                                                cpf_motorista += virg + colunas[5];
                                                media += virg + colunas[6];
                                                virg = ",";
                                            }
                                            if (!string.IsNullOrEmpty(placa))
                                                Rel.Parametros_Relatorio.Add("PLACA", placa);
                                            if (!string.IsNullOrEmpty(km))
                                                Rel.Parametros_Relatorio.Add("KM", km);
                                            if (!string.IsNullOrEmpty(media))
                                                Rel.Parametros_Relatorio.Add("MEDIA", media + " KM/LT");
                                            if (!string.IsNullOrEmpty(frota))
                                                Rel.Parametros_Relatorio.Add("FROTA", frota);
                                            if (!string.IsNullOrEmpty(requisicao))
                                                Rel.Parametros_Relatorio.Add("REQUISICAO", requisicao);
                                            if (!string.IsNullOrEmpty(nm_motorista))
                                                Rel.Parametros_Relatorio.Add("NM_MOTORISTA", nm_motorista);
                                            if (!string.IsNullOrEmpty(cpf_motorista))
                                                Rel.Parametros_Relatorio.Add("CPF_MOTORISTA", cpf_motorista);
                                        }
                                        Rel.Nome_Relatorio = "DANFE_NFCE";
                                        Rel.NM_Classe = "TFConsultaFrenteCaixa";
                                        Rel.Modulo = "FAT";
                                        Rel.Ident = "DANFE_NFCE";
                                        if (CamadaNegocio.ConfigGer.TCN_CadParamGer.BuscaVlBool("ST_IMP_DANFE_NFCE_DETALHADA", null))
                                        {
                                            BindingSource bsItens = new BindingSource();
                                            bsItens.DataSource = (bsNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).lItem;
                                            Rel.DTS_Relatorio = bsItens;
                                        }
                                        if ((bsNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).Id_contingencia.HasValue)
                                            if (Rel.Parametros_Relatorio.ContainsKey("ST_VIAEMPRESA"))
                                                Rel.Parametros_Relatorio["ST_VIAEMPRESA"] = "S";
                                            else
                                                Rel.Parametros_Relatorio.Add("ST_VIAEMPRESA", "S");
                                        //Verificar se existe Impressora padrão para o PDV
                                        obj = new CamadaDados.Faturamento.Cadastros.TCD_PontoVenda().BuscarEscalar(
                                                new TpBusca[]
                                                {
                                                    new TpBusca()
                                                    {
                                                        vNM_Campo = "a.cd_terminal",
                                                        vOperador = "=",
                                                        vVL_Busca = "'" + Utils.Parametros.pubTerminal.Trim() + "'"
                                                    }
                                                }, "a.impressorapadrao");
                                        string print = obj == null ? string.Empty : obj.ToString();
                                        if (string.IsNullOrEmpty(print))
                                            using (Parametros.Diversos.TFListaImpressoras fLista = new Parametros.Diversos.TFListaImpressoras())
                                            {
                                                if (fLista.ShowDialog() == DialogResult.OK)
                                                    if (!string.IsNullOrEmpty(fLista.Impressora))
                                                        print = fLista.Impressora;

                                            }
                                        //Imprimir
                                        Rel.ImprimiGraficoReduzida(print,
                                                                   true,
                                                                   false,
                                                                   null,
                                                                   string.Empty,
                                                                   string.Empty,
                                                                   1);
                                        if ((bsNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).Id_contingencia.HasValue && 
                                            (bsNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).rCfgNFCe.Tp_ambiente_nfce.Equals(1))
                                            Rel.ImprimiGraficoReduzida(print,
                                                                       true,
                                                                       false,
                                                                       null,
                                                                       string.Empty,
                                                                       string.Empty,
                                                                       1);
                                    }
                            }
                            else
                                MessageBox.Show("Não existe série modelo 65 configurada na CFG.Frente de Caixa!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    else
                        MessageBox.Show("Não existe venda selecionada para gerar cupom.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void GerarCFFinalizador()
        {
            using(TFGerarCFFinalizador fGerar = new TFGerarCFFinalizador())
            {
                fGerar.Cd_empresa = rCfgPosto.Cd_empresa;
                if(fGerar.ShowDialog() == DialogResult.OK)
                    if(fGerar.lItens != null)
                    {
                        try
                        {
                            if (lCfg[0].Cd_modelonfce.Trim().Equals("65"))
                            {
                                //Processar cupom fiscal
                                PDV.TDadosCupom dados = new PDV.TDadosCupom();
                                dados.lItens = fGerar.lItens;
                                dados.rSessao = lSessao[0];
                                dados.Cd_clifor = string.Empty;
                                dados.Nm_clifor = string.Empty;
                                dados.CpfCgc = string.Empty;
                                dados.Endereco = string.Empty;
                                dados.Mensagem = string.Empty;
                                dados.lPortador = new List<CamadaDados.Financeiro.Cadastros.TRegistro_CadPortador>();
                                dados.St_vendacombustivel = true;
                                dados.St_convenio = false;
                                dados.St_cupomavulso = true;
                                dados.St_agruparProduto = true;
                                PDV.TGerenciarCupom.ProcessarCupom(ref dados);
                                CamadaDados.Faturamento.PDV.TRegistro_NFCe rNFCe = new PDV.TGerenciarCupom().GerarNFCe(dados, false);
                                if (rNFCe != null)
                                    if (!rNFCe.St_contingencia)
                                    {
                                        using (NFCe.TFGerenciarNFCe fGerNfe = new NFCe.TFGerenciarNFCe())
                                        {
                                            rNFCe = CamadaNegocio.Faturamento.PDV.TCN_NFCe.BuscarNFCe(rNFCe.Cd_empresa,
                                                                                                      rNFCe.Id_nfcestr,
                                                                                                      null);
                                            fGerNfe.rNFCe = rNFCe;
                                            fGerNfe.ShowDialog();
                                        }
                                        if (dados.St_faturardireto)
                                            if (new CamadaDados.Faturamento.NFCe.TCD_Lote_X_NFCe().BuscarEscalar(
                                                    new TpBusca[]
                                                    {
                                                        new TpBusca()
                                                        {
                                                            vNM_Campo = "a.cd_empresa",
                                                            vOperador = "=",
                                                            vVL_Busca = "'" + rNFCe.Cd_empresa.Trim() + "'"
                                                        },
                                                        new TpBusca()
                                                        {
                                                            vNM_Campo = "a.id_cupom",
                                                            vOperador = "=",
                                                            vVL_Busca = rNFCe.Id_nfcestr
                                                        },
                                                        new TpBusca()
                                                        {
                                                            vNM_Campo = "a.status",
                                                            vOperador = "=",
                                                            vVL_Busca = "'100'"
                                                        }
                                                    }, "1") != null)
                                                ProcessaCfVincular(new List<CamadaDados.Faturamento.PDV.TRegistro_NFCe> { rNFCe }, rNFCe.Cd_empresa, rNFCe.Cd_clifor);
                                    }
                                    else
                                    {
                                        FormRelPadrao.Relatorio Rel = new FormRelPadrao.Relatorio();
                                        BindingSource dts = new BindingSource();
                                        dts.DataSource = new CamadaDados.Faturamento.PDV.TList_NFCe_Item();
                                        Rel.DTS_Relatorio = dts;// bsItens;
                                        //DTS Cupom
                                        BindingSource bsNFCe = new BindingSource();
                                        bsNFCe.DataSource = CamadaNegocio.Faturamento.PDV.TCN_NFCe.Buscar(rNFCe.Id_nfcestr,
                                                                                                          string.Empty,
                                                                                                          rNFCe.Cd_empresa,
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
                                                                                                          false,
                                                                                                          string.Empty,
                                                                                                          String.Empty,
                                                                                                          1,
                                                                                                          null);
                                        (bsNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).lItem =
                                            CamadaNegocio.Faturamento.PDV.TCN_NFCe_Item.Buscar((bsNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).Id_nfcestr,
                                                                                               (bsNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).Cd_empresa,
                                                                                               string.Empty,
                                                                                               null);
                                        NFCe.TGerarQRCode.GerarQRCode2(bsNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe);
                                        Rel.Adiciona_DataSource("DTS_NFCE", bsNFCe);
                                        //Buscar Empresa
                                        BindingSource bsEmpresa = new BindingSource();
                                        bsEmpresa.DataSource = CamadaNegocio.Diversos.TCN_CadEmpresa.Busca(rNFCe.Cd_empresa,
                                                                                                            string.Empty,
                                                                                                            string.Empty,
                                                                                                            null);
                                        Rel.Adiciona_DataSource("DTS_EMP", bsEmpresa);
                                        //Forma Pagamento
                                        BindingSource bsPagto = new BindingSource();
                                        CamadaDados.Financeiro.Duplicata.TList_RegLanDuplicata lDup =
                                        new CamadaDados.Financeiro.Duplicata.TCD_LanDuplicata().Select(
                                        new TpBusca[]
                                        {
                                            new TpBusca()
                                            {
                                                vNM_Campo = string.Empty,
                                                vOperador = "exists",
                                                vVL_Busca = "(select 1 from TB_PDV_CupomFiscal_X_Duplicata x " +
                                                            "inner join TB_PDV_Cupom_X_VendaRapida y " +
                                                            "on x.cd_empresa = y.cd_empresa " +
                                                            "and x.id_cupom = y.id_vendarapida " +
                                                            "where x.cd_empresa = a.cd_empresa " +
                                                            "and x.Nr_Lancto = a.Nr_Lancto " +
                                                            "and y.cd_empresa = '" + rNFCe.Cd_empresa.Trim() + "' " +
                                                            "and y.id_cupom = " + rNFCe.Id_nfcestr + ")"
                                            }
                                        }, 1, string.Empty);
                                        if (lDup.Count > 0)
                                            bsPagto.DataSource = new List<CamadaDados.Faturamento.PDV.TRegistro_MovCaixa>()
                                                                    {
                                                                        new CamadaDados.Faturamento.PDV.TRegistro_MovCaixa()
                                                                        {
                                                                            Tp_portador = "05",
                                                                            Vl_recebido = lDup[0].Vl_documento
                                                                        }
                                                                    };
                                        else
                                            bsPagto.DataSource = new CamadaDados.Faturamento.PDV.TCD_CaixaPDV().SelectMovCaixa(
                                                                    new TpBusca[]
                                                                    {
                                                                        new TpBusca()
                                                                        {
                                                                            vNM_Campo = string.Empty,
                                                                            vOperador = "exists",
                                                                            vVL_Busca = "(select 1 from tb_pdv_cupom_x_vendarapida x " +
                                                                                        "where x.cd_empresa = a.cd_empresa " +
                                                                                        "and x.id_vendarapida = a.id_cupom " +
                                                                                        "and x.cd_empresa = '" + rNFCe.Cd_empresa.Trim() + "' " +
                                                                                        "and x.id_cupom = " + rNFCe.Id_nfcestr + ")"
                                                                        }
                                                                    }, string.Empty).GroupBy(v => v.Tp_portador,
                                                                                        (aux, venda) =>
                                                                                            new
                                                                                            {
                                                                                                tp_portador = aux,
                                                                                                Vl_recebido = venda.Sum(x => x.Vl_recebido),
                                                                                                Vl_troco_ch = venda.Sum(x => x.Vl_troco_ch),
                                                                                                Vl_troco_dh = venda.Sum(x => x.Vl_troco_dh)
                                                                                            }).ToList();
                                        Rel.Adiciona_DataSource("DTS_PAGTO", bsPagto);
                                        //Parametros
                                        Rel.Parametros_Relatorio.Add("TOT_IMP_APROX", (bsNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).lItem.Sum(p => p.Vl_imposto_Aprox));
                                        Rel.Parametros_Relatorio.Add("QTD_ITENS", (bsNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).lItem.Count);
                                        Rel.Parametros_Relatorio.Add("TOT_SUBTOTAL", (bsNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).lItem.Sum(p => p.Vl_subtotal));
                                        Rel.Parametros_Relatorio.Add("TOT_ACRESCIMO", (bsNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).lItem.Sum(p => p.Vl_acrescimo));
                                        Rel.Parametros_Relatorio.Add("TOT_DESCONTO", (bsNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).lItem.Sum(p => p.Vl_desconto));
                                        Rel.Parametros_Relatorio.Add("ST_VIAEMPRESA", "N");
                                        object obj = new CamadaDados.Faturamento.NFCe.TCD_LoteNFCe().BuscarEscalar(
                                                        new TpBusca[]
                                                        {
                                                            new TpBusca()
                                                            {
                                                                vNM_Campo = string.Empty,
                                                                vOperador = "exists",
                                                                vVL_Busca = "(select 1 from TB_FAT_Lote_X_NFCe x " +
                                                                            "where x.cd_empresa = a.cd_empresa " +
                                                                            "and x.id_lote = a.id_lote " +
                                                                            "and x.status = '100')"
                                                            }
                                                        }, "a.tp_ambiente");
                                        Rel.Parametros_Relatorio.Add("TP_AMBIENTE", obj == null ? string.Empty : obj.ToString());
                                        string dadoscf = CamadaNegocio.Faturamento.PDV.TCN_NFCe.BuscarPlacaKM((bsNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).Cd_empresa,
                                                                                                              (bsNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).Id_nfcestr,
                                                                                                              null);
                                        if (!string.IsNullOrEmpty(dadoscf))
                                        {
                                            string[] linhas = dadoscf.Split(new char[] { ':' });
                                            string placa = string.Empty;
                                            string km = string.Empty;
                                            string frota = string.Empty;
                                            string requisicao = string.Empty;
                                            string nm_motorista = string.Empty;
                                            string cpf_motorista = string.Empty;
                                            string media = string.Empty;
                                            string virg = string.Empty;
                                            foreach (string s in linhas)
                                            {
                                                string[] colunas = s.Split(new char[] { '/' });
                                                placa += virg + colunas[0];
                                                km += virg + colunas[1];
                                                frota += virg + colunas[2];
                                                requisicao += virg + colunas[3];
                                                nm_motorista += virg + colunas[4];
                                                cpf_motorista += virg + colunas[5];
                                                media += virg + colunas[6];
                                                virg = ",";
                                            }
                                            if (!string.IsNullOrEmpty(placa))
                                                Rel.Parametros_Relatorio.Add("PLACA", placa);
                                            if (!string.IsNullOrEmpty(km))
                                                Rel.Parametros_Relatorio.Add("KM", km);
                                            if (!string.IsNullOrEmpty(media))
                                                Rel.Parametros_Relatorio.Add("MEDIA", media + " KM/LT");
                                            if (!string.IsNullOrEmpty(frota))
                                                Rel.Parametros_Relatorio.Add("FROTA", frota);
                                            if (!string.IsNullOrEmpty(requisicao))
                                                Rel.Parametros_Relatorio.Add("REQUISICAO", requisicao);
                                            if (!string.IsNullOrEmpty(nm_motorista))
                                                Rel.Parametros_Relatorio.Add("NM_MOTORISTA", nm_motorista);
                                            if (!string.IsNullOrEmpty(cpf_motorista))
                                                Rel.Parametros_Relatorio.Add("CPF_MOTORISTA", cpf_motorista);
                                        }
                                        Rel.Nome_Relatorio = "DANFE_NFCE";
                                        Rel.NM_Classe = "TFConsultaFrenteCaixa";
                                        Rel.Modulo = "FAT";
                                        Rel.Ident = "DANFE_NFCE";
                                        if (CamadaNegocio.ConfigGer.TCN_CadParamGer.BuscaVlBool("ST_IMP_DANFE_NFCE_DETALHADA", null))
                                        {
                                            BindingSource bsItens = new BindingSource();
                                            bsItens.DataSource = (bsNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).lItem;
                                            Rel.DTS_Relatorio = bsItens;
                                        }
                                        if (rNFCe.Id_contingencia.HasValue)
                                            if (Rel.Parametros_Relatorio.ContainsKey("ST_VIAEMPRESA"))
                                                Rel.Parametros_Relatorio["ST_VIAEMPRESA"] = "S";
                                            else
                                                Rel.Parametros_Relatorio.Add("ST_VIAEMPRESA", "S");
                                        //Verificar se existe Impressora padrão para o PDV
                                        obj = new CamadaDados.Faturamento.Cadastros.TCD_PontoVenda().BuscarEscalar(
                                                new TpBusca[]
                                                {
                                                    new TpBusca()
                                                    {
                                                        vNM_Campo = "a.cd_terminal",
                                                        vOperador = "=",
                                                        vVL_Busca = "'" + Utils.Parametros.pubTerminal.Trim() + "'"
                                                    }
                                                }, "a.impressorapadrao");
                                        string print = obj == null ? string.Empty : obj.ToString();
                                        if (string.IsNullOrEmpty(print))
                                            using (Parametros.Diversos.TFListaImpressoras fLista = new Parametros.Diversos.TFListaImpressoras())
                                            {
                                                if (fLista.ShowDialog() == DialogResult.OK)
                                                    if (!string.IsNullOrEmpty(fLista.Impressora))
                                                        print = fLista.Impressora;

                                            }
                                        //Imprimir
                                        Rel.ImprimiGraficoReduzida(print,
                                                                   true,
                                                                   false,
                                                                   null,
                                                                   string.Empty,
                                                                   string.Empty,
                                                                   1);
                                        if ((bsNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).Id_contingencia.HasValue && 
                                            (bsNFCe.Current as CamadaDados.Faturamento.PDV.TRegistro_NFCe).rCfgNFCe.Tp_ambiente_nfce.Equals(1))
                                            Rel.ImprimiGraficoReduzida(print,
                                                                       true,
                                                                       false,
                                                                       null,
                                                                       string.Empty,
                                                                       string.Empty,
                                                                       1);
                                    }
                            }
                            else
                                MessageBox.Show("Não existe série modelo 65 configurada na CFG.Frente de Caixa!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    }
                    else
                        MessageBox.Show("Não existe itens disponiveis <COMBUSTIVEL/LUBRIFICANTE> para gerar cupom fiscal finalizador.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void GerarNfe()
        {
            using (PDV.TFGerarCupomNFe fGerar = new PDV.TFGerarCupomNFe())
            {
                fGerar.St_habilitarNfConsumo = CamadaNegocio.Diversos.TCN_Usuario_RegraEspecial.ValidaRegra(LoginPdv, "PERMITIR EMITIR NF CONSUMO", null);
                if (fGerar.ShowDialog() == DialogResult.OK)
                    if (fGerar.lItens != null)
                    {
                        CamadaDados.Faturamento.Pedido.TRegistro_Pedido rPed = null;
                        CamadaDados.Faturamento.Pedido.TRegistro_Pedido rPedServico = null;
                        try
                        {
                            string pCd_clifor = fGerar.Cd_clifor;
                            if (string.IsNullOrEmpty(pCd_clifor))
                            {
                                DataRowView linha = FormBusca.UtilPesquisa.BTN_BuscaClifor(null, string.Empty);
                                if (linha != null)
                                    pCd_clifor = linha["cd_clifor"].ToString();
                            }
                            if (!string.IsNullOrEmpty(pCd_clifor))
                            {
                                //Buscar endereco
                                CamadaDados.Financeiro.Cadastros.TList_CadEndereco lEnd =
                                    CamadaNegocio.Financeiro.Cadastros.TCN_CadEndereco.Buscar(pCd_clifor,
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
                                string pCd_endereco = string.Empty;
                                if (lEnd.Count.Equals(1))
                                    pCd_endereco = lEnd[0].Cd_endereco;
                                else
                                {
                                    string vColunas = "a.ds_endereco|Endereço|200;"+
                                                      "a.cd_endereco|Codigo|80;"+
                                                      "a.bairro|Bairro|80;"+
                                                      "a.insc_estadual|Insc. Estadual|80";
                                    DataRowView linha = FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, null, new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco(), "a.cd_clifor|=|'" + pCd_clifor.Trim() + "'");
                                    if (linha != null)
                                        pCd_endereco = linha["cd_endereco"].ToString();
                                }
                                if (string.IsNullOrEmpty(pCd_endereco))
                                {
                                    MessageBox.Show("Obrigatorio informar endereço cliente NFe.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    return;
                                }
                                Proc_Commoditties.TProcessarPedidoVendaRapida.ProcessarPedido(pCd_clifor,
                                                                                              pCd_endereco,
                                                                                              fGerar.St_gerarNfConsumo,
                                                                                              string.Empty,
                                                                                              lCfg[0],
                                                                                              fGerar.lItens,
                                                                                              ref rPed,
                                                                                              ref rPedServico);
                                CamadaNegocio.Faturamento.PDV.TCN_Pedido_X_VendaRapida.ProcessarPedido(rPed, null);
                                //Buscar pedido
                                rPed = CamadaNegocio.Faturamento.Pedido.TCN_Pedido.Busca_Registro_Pedido(rPed.Nr_pedido.ToString(), null);
                                //Buscar itens pedido
                                CamadaNegocio.Faturamento.Pedido.TCN_Pedido.Busca_Pedido_Itens(rPed, false, null);
                                //Se o CMI do pedido gerar financeiro
                                CamadaDados.Financeiro.Duplicata.TList_RegLanParcela lParcVinculado = new CamadaDados.Financeiro.Duplicata.TList_RegLanParcela();
                                //Buscar parcelas em aberto dos cupons que estao sendo vinculados
                                string vId_venda = string.Empty;
                                string virg = string.Empty;
                                fGerar.lItens.GroupBy(p => p.Id_vendarapida,
                                    (aux, cupom) =>
                                        new
                                        {
                                            id_cupom = aux
                                        }).ToList().ForEach(p=> 
                                            {
                                                vId_venda += virg + p.id_cupom.Value.ToString();
                                                virg = ",";
                                            });
                                new CamadaDados.Financeiro.Duplicata.TCD_LanParcela().Select(
                                    new TpBusca[]
                                        {
                                            new TpBusca()
                                            {
                                                vNM_Campo = "isnull(dup.st_registro, 'A')",
                                                vOperador = "<>",
                                                vVL_Busca = "'C'"
                                            },
                                            new TpBusca()
                                            {
                                                vNM_Campo = "isnull(a.st_registro, 'A')",
                                                vOperador = "in",
                                                vVL_Busca = "('A', 'P')"
                                            },
                                            new TpBusca()
                                            {
                                                vNM_Campo = string.Empty,
                                                vOperador = "exists",
                                                vVL_Busca = "(select 1 from tb_pdv_cupomfiscal_x_duplicata x " +
                                                            "where x.cd_empresa = a.cd_empresa " +
                                                            "and x.nr_lancto = a.nr_lancto " +
                                                            "and x.cd_empresa = '" + fGerar.lItens[0].Cd_empresa.Trim() + "' " +
                                                            "and x.id_cupom in(" + vId_venda + "))"
                                            }
                                        }, 0, string.Empty, "a.dt_vencto, c.nm_clifor", string.Empty).ForEach(v => lParcVinculado.Add(v));
                                //Gerar Nota Fiscal
                                CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento rFat =
                                    Proc_Commoditties.TProcessaPedFaturar.ProcessaPedFaturar(rPed, true, lParcVinculado.Sum(p=> p.Vl_atual));
                                //Vincular financeiro a Nota Fiscal
                                rFat.lParcAgrupar = lParcVinculado;
                                //Montar obs com placa-km
                                string obs = string.Empty;
                                string virgula = string.Empty;
                                fGerar.lItens.ForEach(p => p.Placa_KM = CamadaNegocio.Faturamento.PDV.TCN_VendaRapida.BuscarPlacaKM(p.Cd_empresa, p.Id_vendarapida.Value.ToString(), null));
                                fGerar.lItens.GroupBy(p => p.Placa_KM,
                                    (aux, pl) =>
                                        new
                                            {
                                                placa = aux
                                            }).ToList().ForEach(p=> 
                                                {
                                                    obs += virgula + p.placa;
                                                    virgula = ",";
                                                });
                                if (!string.IsNullOrEmpty(obs))
                                    rFat.Dadosadicionais += (!string.IsNullOrEmpty(rFat.Dadosadicionais) ? "\r\n" : string.Empty) + "Placa/KM " + obs.Trim();
                                //Gravar Nota Fiscal
                                CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento.GravarFaturamento(rFat, null, null);
                                using (srvNFE.TFGerenciarNFe fGerNfe = new srvNFE.TFGerenciarNFe())
                                {
                                    fGerNfe.rNfe = CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento.BuscarNF(rFat.Cd_empresa,
                                                                                                                    rFat.Nr_lanctofiscalstr,
                                                                                                                    null);
                                    fGerNfe.ShowDialog();
                                }
                            }
                            else
                                MessageBox.Show("Obrigatorio informar cliente da NFe.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            if (rPed != null)
                                CamadaNegocio.Faturamento.Pedido.TCN_Pedido.Deleta_Pedido(rPed, null);
                            MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); 
                        }
                    }
                    else
                        MessageBox.Show("Não existe venda selecionada para gerar NFe.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ProcessaCfVincular(List<CamadaDados.Faturamento.PDV.TRegistro_NFCe> val,
                                        string Cd_empresa,
                                        string Cd_cliente)
        {
            CamadaDados.Faturamento.Pedido.TRegistro_Pedido rPed = null;
            try
            {
                rPed = Proc_Commoditties.TProcessaCFVinculadoNF.ProcessarPedido(val, Cd_empresa, Cd_cliente);
                //Gravar Pedido
                CamadaNegocio.Faturamento.Pedido.TCN_Pedido.Grava_Pedido(rPed, null);
                //Buscar pedido
                rPed = CamadaNegocio.Faturamento.Pedido.TCN_Pedido.Busca_Registro_Pedido(rPed.Nr_pedido.ToString(), null);
                //Buscar itens pedido
                CamadaNegocio.Faturamento.Pedido.TCN_Pedido.Busca_Pedido_Itens(rPed, false, null);
                //Se o CMI do pedido gerar financeiro
                CamadaDados.Financeiro.Duplicata.TList_RegLanParcela lParcVinculado = new CamadaDados.Financeiro.Duplicata.TList_RegLanParcela();
                //Buscar parcelas em aberto dos cupons que estao sendo vinculados
                val.ForEach(p =>
                {
                    new CamadaDados.Financeiro.Duplicata.TCD_LanParcela().Select(
                        new TpBusca[]
                        {
                            new TpBusca()
                            {
                                vNM_Campo = "isnull(dup.st_registro, 'A')",
                                vOperador = "<>",
                                vVL_Busca = "'C'"
                            },
                            new TpBusca()
                            {
                                vNM_Campo = "isnull(a.st_registro, 'A')",
                                vOperador = "in",
                                vVL_Busca = "('A', 'P')"
                            },
                            new TpBusca()
                            {
                                vNM_Campo = string.Empty,
                                vOperador = "exists",
                                vVL_Busca = "(select 1 from tb_pdv_cupom_x_vendarapida x " +
                                            "inner join tb_pdv_cupomfiscal_x_duplicata y " +
                                            "on x.cd_empresa = y.cd_empresa " +
                                            "and x.id_vendarapida = y.id_cupom " +
                                            "where y.cd_empresa = a.cd_empresa " +
                                            "and y.nr_lancto = a.nr_lancto " +
                                            "and x.cd_empresa = '" + p.Cd_empresa.Trim() + "' " +
                                            "and x.id_cupom = " + p.Id_nfcestr + ")"
                            }
                        }, 0, string.Empty, "a.dt_vencto, c.nm_clifor", string.Empty).ForEach(v => lParcVinculado.Add(v));
                });
                //Gerar Nota Fiscal
                CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento rFat =
                    Proc_Commoditties.TProcessaPedFaturar.ProcessaPedFaturar(rPed, true, lParcVinculado.Sum(p => p.Vl_atual));
                //Vincular Cupom a Nota Fiscal
                string Obs = string.Empty;
                string virg = string.Empty;
                val.ForEach(p =>
                {
                    rFat.lCupom.Add(p);
                    string Placa_km = CamadaNegocio.Faturamento.PDV.TCN_NFCe.BuscarPlacaKM(p.Cd_empresa, p.Id_nfcestr, null);
                    Obs += virg + p.NR_NFCestr.Trim() + "-" + (string.IsNullOrEmpty(Placa_km) ? p.Placa : Placa_km.Trim()) + (!string.IsNullOrEmpty(p.Nr_requisicao) ? "/" + p.Nr_requisicao.Trim() : string.Empty);
                    virg = ",";
                });
                //Vincular financeiro a Nota Fiscal
                rFat.lParcAgrupar = lParcVinculado;
                if (!string.IsNullOrEmpty(Obs))
                    rFat.Dadosadicionais = (!string.IsNullOrEmpty(rFat.Dadosadicionais) ? "\r\n" : string.Empty) + "Ref. CF-Placa/KM/Frota/Requisicao " + Obs.Trim();
                //Gravar Nota Fiscal
                CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento.GravarFaturamento(rFat, null, null);
                using (srvNFE.TFGerenciarNFe fGerNfe = new srvNFE.TFGerenciarNFe())
                {
                    fGerNfe.rNfe = CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento.BuscarNF(rFat.Cd_empresa,
                                                                                                    rFat.Nr_lanctofiscalstr,
                                                                                                    null);
                    fGerNfe.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                CamadaNegocio.Faturamento.Pedido.TCN_Pedido.Deleta_Pedido(rPed, null);
            }
        }

        private void VincularCfNFe()
        {
            using (Proc_Commoditties.TFVincularECFNF fVincular = new Proc_Commoditties.TFVincularECFNF())
            {
                fVincular.pCd_empresa = lCfg[0].Cd_empresa;
                if (fVincular.ShowDialog() == DialogResult.OK)
                    if (fVincular.lCupom != null)
                        if (fVincular.lCupom.Count > 0)
                            ProcessaCfVincular(fVincular.lCupom, fVincular.pCd_empresa, fVincular.pCd_cliente);
                        else
                            MessageBox.Show("Não existe cupom fiscal selecionado para vincular a Nota Fiscal.", "Mensagem",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void afterBusca()
        {
            List<CamadaDados.PostoCombustivel.TRegistro_VendaCombustivel> lista = null;
            if (bsVendaCombustivel.Count > 0)
                lista = (bsVendaCombustivel.DataSource as CamadaDados.PostoCombustivel.TList_VendaCombustivel).FindAll(p => p.St_processar);
            bsVendaCombustivel.DataSource = CamadaNegocio.PostoCombustivel.TCN_VendaCombustivel.Buscar(string.Empty,
                                                                                                       rCfgPosto.Cd_empresa,
                                                                                                       string.Empty,
                                                                                                       string.Empty,
                                                                                                       string.Empty,
                                                                                                       string.Empty,
                                                                                                       string.Empty,
                                                                                                       string.Empty,
                                                                                                       "'A'",
                                                                                                       "N",
                                                                                                       false,
                                                                                                       string.Empty,
                                                                                                       string.Empty,
                                                                                                       "a.dt_abastecimento desc",
                                                                                                       null);
            if ((lista != null) && (bsVendaCombustivel.Count > 0))
                if (lista.Count > 0)
                {
                    lista.ForEach(p =>
                    {
                        if ((bsVendaCombustivel.List as CamadaDados.PostoCombustivel.TList_VendaCombustivel).Find(v => v.Id_venda.Value.Equals(p.Id_venda.Value)) != null)
                            (bsVendaCombustivel.List as CamadaDados.PostoCombustivel.TList_VendaCombustivel).Find(v => v.Id_venda.Value.Equals(p.Id_venda.Value)).St_processar = true;
                    });
                    bsVendaCombustivel.ResetBindings(true);
                }
            if (bsVendaCombustivel.Count > 0)
            {
                //Totalizar Venda Faturar
                edtVolFaturar.Text = (bsVendaCombustivel.List as CamadaDados.PostoCombustivel.TList_VendaCombustivel).Where(p => p.St_processar).Sum(p => p.Volumeabastecido).ToString("N3", new System.Globalization.CultureInfo("pt-BR"));
                edtVlFaturar.Text = (bsVendaCombustivel.List as CamadaDados.PostoCombustivel.TList_VendaCombustivel).Where(p => p.St_processar).Sum(p => p.Vl_subtotal).ToString("N2", new System.Globalization.CultureInfo("pt-BR"));
            }
        }

        private decimal BuscarSaldoLocal(string Cd_produto)
        {
            if ((!string.IsNullOrEmpty(rCfgPosto.Cd_empresa)) &&
                (!string.IsNullOrEmpty(Cd_produto)) &&
                (!string.IsNullOrEmpty(lCfg[0].Cd_local)))
            {
                decimal saldo = decimal.Zero;
                CamadaNegocio.Estoque.TCN_LanEstoque.SaldoEstoqueLocal(rCfgPosto.Cd_empresa,
                                                                       Cd_produto,
                                                                       lCfg[0].Cd_local,
                                                                       ref saldo,
                                                                       null);
                return saldo;
            }
            else
                return decimal.Zero;
        }

        private void BuscarPromocao(CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item rItemCupom)
        {
            if (rItemCupom != null)
            {
                CamadaDados.Faturamento.Promocao.TRegistro_Promocao_X_Grupo rPro =
                    CamadaNegocio.Faturamento.Promocao.TCN_Promocao_X_Grupo.BuscarPromocaoGrupo(rCfgPosto.Cd_empresa,
                                                                                                rItemCupom.Cd_produto,
                                                                                                rItemCupom.Cd_grupo,
                                                                                                rProg,
                                                                                                rItemCupom.Vl_subtotal,
                                                                                                null);
                if (rPro != null)
                    if (rPro.Qtd_minimavenda > 1)
                    {
                        if (rVenda.lItem.Where(p => p.Cd_produto.Trim().Equals(rItemCupom.Cd_produto.Trim())).Sum(p => p.Quantidade) >= rPro.Qtd_minimavenda)
                        {
                            rVenda.lItem.Where(p => p.Cd_produto.Trim().Equals(rItemCupom.Cd_produto.Trim())).ToList().ForEach(p =>
                            {
                                if (rPro.Tp_promocao.Trim().ToUpper().Equals("P"))
                                {
                                    p.Pc_desconto = rPro.Vl_promocao;
                                    //Calcular desconto
                                    p.Vl_desconto = Utils.Parametros.pubTruncarSubTotal ? Estruturas.Truncar(p.Vl_subtotal * (rPro.Vl_promocao / 100), 2): Math.Round(p.Vl_subtotal * (rPro.Vl_promocao / 100), 2);
                                }
                                else
                                {
                                    p.Vl_desconto = Utils.Parametros.pubTruncarSubTotal ? Estruturas.Truncar(rPro.Vl_promocao * p.Quantidade, 2): Math.Round(rPro.Vl_promocao * p.Quantidade);
                                    //Calcular % Desconto
                                    p.Pc_desconto = p.Vl_desconto * 100 / p.Vl_subtotal;
                                }
                            });
                        }
                        else
                        {
                            rItemCupom.Vl_desconto = decimal.Zero;
                            rItemCupom.Pc_desconto = decimal.Zero;
                        }
                    }
                    else
                    {
                        if (rPro.Tp_promocao.Trim().ToUpper().Equals("P"))
                        {
                            rItemCupom.Pc_desconto = rPro.Vl_promocao;
                            //Calcular desconto
                            rItemCupom.Vl_desconto = Utils.Parametros.pubTruncarSubTotal ? 
                                Estruturas.Truncar(rItemCupom.Vl_subtotal * (rPro.Vl_promocao / 100), 2):
                                Math.Round(rItemCupom.Vl_subtotal * (rPro.Vl_promocao / 100), 2);
                        }
                        else
                        {
                            rItemCupom.Vl_desconto = Utils.Parametros.pubTruncarSubTotal ?
                                Estruturas.Truncar(rPro.Vl_promocao * rItemCupom.Quantidade, 2):
                                Math.Round(rPro.Vl_promocao * rItemCupom.Quantidade, 2);
                            //Calcular % Desconto
                            rItemCupom.Pc_desconto = rItemCupom.Vl_desconto * 100 / rItemCupom.Vl_subtotal;
                        }
                    }
            }
        }

        private decimal CalcularDescEspecial(decimal Qtde,
                                             decimal Vl_unit,
                                             string pCd_produto)
        {
            if (rProg != null)
            {
                if ((rProg.Valor > decimal.Zero) && rProg.Tp_acresdesc.Trim().ToUpper().Equals("D") && rProg.Qtd_minVenda > 1)
                {
                    if (rVenda.lItem.Where(p => p.Cd_produto.Equals(pCd_produto)).Sum(p => p.Quantidade) + quantidade.Value >= rProg.Qtd_minVenda)
                        return Utils.Parametros.pubTruncarSubTotal ?
                                Estruturas.Truncar(Qtde * rProg.Valor, 2) :
                                Math.Round(Qtde * rProg.Valor, 2);
                    else
                        return decimal.Zero;
                }
                else if ((rProg.Valor > decimal.Zero) && rProg.Tp_acresdesc.Trim().ToUpper().Equals("D"))
                {
                    if (rProg.Tp_valor.Trim().ToUpper().Equals("V"))
                        return Utils.Parametros.pubTruncarSubTotal ? 
                            Estruturas.Truncar(Qtde * rProg.Valor, 2) :
                            Math.Round(Qtde * rProg.Valor, 2);
                    else
                        return Utils.Parametros.pubTruncarSubTotal ?
                            Estruturas.Truncar((Qtde * Vl_unit) * rProg.Valor / 100, 2) :
                            Math.Round((Qtde * Vl_unit) * rProg.Valor / 100, 2);
                }
                else return decimal.Zero;
            }
            else return decimal.Zero;
        }

        private decimal CalcularAcresEspecial(decimal Qtde,
                                              decimal Vl_unit)
        {
            if (rProg != null)
                if ((rProg.Valor > decimal.Zero) && rProg.Tp_acresdesc.Trim().ToUpper().Equals("A"))
                {
                    if (rProg.Tp_valor.Trim().ToUpper().Equals("V"))
                        return Utils.Parametros.pubTruncarSubTotal ?
                            Estruturas.Truncar(Qtde * rProg.Valor, 2):
                            Math.Round(Qtde * rProg.Valor, 2);
                    else
                        return Utils.Parametros.pubTruncarSubTotal ?
                            Estruturas.Truncar((Qtde * Vl_unit) * rProg.Valor / 100, 2):
                            Math.Round((Qtde * Vl_unit) * rProg.Valor / 100, 2);
                }
                else return decimal.Zero;
            else return decimal.Zero;
        }

        private decimal ConsultaPreco(string pCd_produto)
        {
            rProg = null;
            if (lCfg.Count > 0)
            {
                if (!string.IsNullOrEmpty(Cd_clifor.Text))
                {
                    //Vefiricar se existe programacao especial de venda 
                    rProg = CamadaNegocio.Faturamento.ProgEspecialVenda.TCN_ProgEspecialVenda.BuscarProg(lCfg[0].Cd_empresa,
                                                                                                         Cd_clifor.Text,
                                                                                                         pCd_produto,
                                                                                                         lCfg[0].Cd_tabelapreco,
                                                                                                         null);
                    if (rProg != null)
                        if (rProg.Tp_preco.Trim().ToUpper().Equals("C"))//Preco de Custo
                            return CamadaNegocio.Estoque.TCN_LanEstoque.BuscarVlEstoqueUltimaCompra(lCfg[0].Cd_empresa, 
                                                                                                    pCd_produto, 
                                                                                                    null);
                }
                if ((!string.IsNullOrEmpty(pCd_produto)) &&
                    (!string.IsNullOrEmpty(lCfg[0].Cd_empresa)) &&
                    (!string.IsNullOrEmpty(lCfg[0].Cd_tabelapreco)))
                    return CamadaNegocio.Estoque.Cadastros.TCN_LanPrecoItem.Busca_ConsultaPreco(lCfg[0].Cd_empresa,
                                                                                                pCd_produto,
                                                                                                lCfg[0].Cd_tabelapreco,
                                                                                                null);
                else
                    return decimal.Zero;
            }
            else
                return decimal.Zero;
        }

        private void TotalizarVenda()
        {
            decimal tot_venda = decimal.Zero;
            if (rVenda != null)
            {
                lblTotalItens.Text = rVenda.lItem.Sum(p => p.Vl_subtotal).ToString("N2", new System.Globalization.CultureInfo("pt-BR"));
                lblTotalDesconto.Text = rVenda.lItem.Sum(p => p.Vl_desconto).ToString("N2", new System.Globalization.CultureInfo("pt-BR"));
                tot_venda = rVenda.lItem.Sum(p => p.Vl_subtotalliquido);
                lblTotalCupom.Text = tot_venda.ToString("N2", new System.Globalization.CultureInfo("pt-BR"));
            }
        }

        private void NovaVenda(CamadaDados.Estoque.Cadastros.TRegistro_CadProduto rProduto,
                               List<CamadaDados.PostoCombustivel.TRegistro_VendaCombustivel> lCombustivel,
                               List<CamadaDados.PostoCombustivel.TRegistro_ItensOrdemServico> lItemOS,
                               List<CamadaDados.PostoCombustivel.TRegistro_ItensVendaMesaConv> lItemVendaConv)
        {
            if ((rVenda == null) &&
                ((rProduto != null) ||
                (lCombustivel == null ? false : lCombustivel.Count > 0) ||
                (lItemOS == null ? false : lItemOS.Count > 0) ||
                (lItemVendaConv == null ? false : lItemVendaConv.Count > 0)))
            {
                lblCxLivre.Visible = false;

                //Gerar objeto venda rapida
                rVenda = new CamadaDados.Faturamento.PDV.TRegistro_VendaRapida();
                bsItensCupom.DataSource = rVenda.lItem;
                rVenda.Cd_clifor = Cd_clifor.Text;
                rVenda.Nm_clifor = NM_Clifor.Text;
                rVenda.Cd_empresa = rCfgPosto.Cd_empresa;
                rVenda.Cd_vend = string.Empty;
                rVenda.Dt_emissao = CamadaDados.UtilData.Data_Servidor();
                rVenda.Id_pdvstr = lPdv[0].Id_pdvstr;
                rVenda.Id_sessaostr = lSessao[0].Id_sessaostr;
                rVenda.St_registro = "A";
            }
            //Buscar preco venda produto
            if (rProduto != null)
            {
                decimal vl_unit = ConsultaPreco(rProduto.CD_Produto);
                if (vl_unit <= decimal.Zero)
                    using (Componentes.TFQuantidade fValor = new Componentes.TFQuantidade())
                    {
                        fValor.Casas_decimais = 2;
                        fValor.Ds_label = "Valor Unitario";
                        if (fValor.ShowDialog() == DialogResult.OK)
                            vl_unit = fValor.Quantidade;
                    }
                if (vl_unit > decimal.Zero)
                {
                    string Cd_vendedor = string.Empty;
                    //Verificar se o produto e comissionado
                    if (rProduto.Pc_Comissao > decimal.Zero)
                    {
                        //Buscar Vendedor
                        string vColunas = "a.nm_clifor|Nome Vendedor|200;" +
                                          "a.cd_clifor|Cd. Vendedor|80";
                        string vParam = "isnull(a.st_vendedor, 'N')|=|'S';" +
                                        "isnull(a.st_funcativo, 'N')|=|'S';" +
                                        "|exists|(select 1 from tb_fat_vendedor_x_empresa x " +
                                        "           where x.cd_vendedor = a.cd_clifor " +
                                        "           and x.cd_empresa = '" + rCfgPosto.Cd_empresa.Trim() + "' " +
                                        "           and x.tp_comissao = 'P')";
                        DataRowView linha = FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, null,
                            new CamadaDados.Financeiro.Cadastros.TCD_CadClifor(),
                           vParam);
                        if (linha != null)
                            Cd_vendedor = linha["cd_clifor"].ToString();
                    }
                    decimal vl_subtotal = Utils.Parametros.pubTruncarSubTotal ?
                                            Estruturas.Truncar(quantidade.Value * vl_unit, 2) :
                                            Math.Round(quantidade.Value * vl_unit, 2);
                    decimal vl_desconto = CalcularDescEspecial(quantidade.Value, vl_unit, rProduto.CD_Produto);
                    decimal vl_acrescimo = CalcularAcresEspecial(quantidade.Value, vl_unit);
                    if ((vl_desconto > decimal.Zero) || (vl_acrescimo > decimal.Zero))
                    {
                        vl_subtotal = vl_subtotal - vl_desconto + vl_acrescimo;
                        vl_unit = Math.Round(decimal.Divide(vl_subtotal, quantidade.Value), 2);
                    }
                    rVenda.lItem.Add(new CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item()
                    {

                        Cd_produto = rProduto.CD_Produto,
                        Ds_produto = rProduto.DS_Produto,
                        Cd_grupo = rProduto.CD_Grupo,
                        Cd_condfiscal_produto = rProduto.CD_CondFiscal_Produto,
                        Cd_unidade = rProduto.CD_Unidade,
                        Sigla_unidade = rProduto.Sigla_unidade,
                        Cd_local = lCfg[0].Cd_local,
                        Ds_local = lCfg[0].Ds_local,
                        Cd_vendedor = Cd_vendedor,
                        Quantidade = quantidade.Value,
                        Vl_unitario = vl_unit,
                        Vl_subtotal = vl_subtotal
                        
                    });
                    //Buscar promocao de venda
                    BuscarPromocao(rVenda.lItem[rVenda.lItem.Count - 1]);
                    bsItensCupom.ResetBindings(true);
                }
                quantidade.Value = 1;
            }
            else if (lCombustivel != null)
            {
                lCombustivel.ForEach(p =>
                {
                    try
                    {
                        //Setar venda como faturada
                        p.St_registro = "F";
                        CamadaNegocio.PostoCombustivel.TCN_VendaCombustivel.Gravar(p, null);
                        decimal vl_subtotal = p.Vl_subtotal;
                        decimal vl_unit = p.Vl_unitario;
                        decimal vl_desconto = CalcularDescEspecial(p.Volumeabastecido, vl_unit, p.Cd_produto);
                        decimal vl_acrescimo = CalcularAcresEspecial(p.Volumeabastecido, vl_unit);
                        if ((vl_desconto > decimal.Zero) || (vl_acrescimo > decimal.Zero))
                        {
                            vl_subtotal = vl_subtotal - vl_desconto + vl_acrescimo;
                            vl_unit = Math.Round(decimal.Divide(vl_subtotal, p.Volumeabastecido), 2);
                        }
                        rVenda.lItem.Add(new CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item()
                        {
                            //Criar item venda combustivel
                            Cd_local = p.Cd_local,
                            Cd_produto = p.Cd_produto,
                            Ds_produto = p.Ds_produto,
                            Sigla_unidade = p.Sigla_unidade,
                            Cd_grupo = p.Cd_grupo,
                            Cd_condfiscal_produto = p.Cd_condfiscal_produto,
                            Cd_unidade = p.Cd_unidade,
                            Quantidade = p.Volumeabastecido,
                            Vl_unitario = vl_unit,
                            Vl_subtotal = vl_subtotal,
                            St_registro = "A",
                            rVendaCombustivel = p
                        });
                        //Buscar promocao de venda
                        BuscarPromocao(rVenda.lItem[rVenda.lItem.Count - 1]);
                        bsItensCupom.ResetBindings(true);
                    }
                    catch
                    { }
                });
                //Atualizar Venda Combustivel Aberto
                afterBusca();
            }
            else if (lItemOS != null)
            {
                lItemOS.ForEach(p =>
                {
                    rVenda.lItem.Add(new CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item()
                    {
                        //Criar item venda OS
                        Cd_vendedor = p.Cd_vendedor,
                        Cd_local = p.Cd_local,
                        Cd_produto = p.Cd_produto,
                        Ds_produto = p.Ds_produto,
                        Cd_grupo = p.Cd_grupo,
                        Sigla_unidade = p.Sigla_unidade,
                        Cd_condfiscal_produto = p.Cd_condfiscal_produto,
                        Cd_unidade = p.Cd_unidade,
                        Quantidade = p.Quantidade,
                        Vl_unitario = p.Vl_unitario,
                        Vl_subtotal = p.Vl_subtotal,
                        Vl_desconto = p.Vl_desconto,
                        St_registro = "A",
                        rItemOS = p
                    });
                    bsItensCupom.ResetBindings(true);
                });
            }
            else if (lItemVendaConv != null)
            {
                lItemVendaConv.ForEach(p =>
                {
                    //Verificar saldo estoque
                    if (lCfg[0].St_movestoquebool)
                    {
                        if (!new CamadaDados.Estoque.Cadastros.TCD_CadProduto().ProdutoComposto(p.Cd_produto))
                        {
                            //Verificar se item possui saldo estoque
                            decimal saldo = BuscarSaldoLocal(p.Cd_produto);
                            if (saldo < p.Quantidade)
                                MessageBox.Show("Não existe saldo disponivel no estoque.\r\n" +
                                                                "Empresa.........: " + p.Cd_empresa.Trim() + "-" + rVenda.Nm_empresa.Trim() + "\r\n" +
                                                                "Produto.........: " + p.Cd_produto.Trim() + "-" + p.Ds_produto.Trim() + "\r\n" +
                                                                "Local Arm.......: " + p.Cd_local.Trim() + "-" + p.Ds_local + "\r\n" +
                                                                "Saldo Disponivel: " + saldo.ToString("N3", new System.Globalization.CultureInfo("pt-BR", true)) + "\r\n" +
                                                                "Item não sera faturado.",
                                                                "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            else
                            {
                                if (!rVenda.lItem.Exists(v => v.rItensVendaMesaConv == null ? false :
                                                            v.rItensVendaMesaConv.Cd_empresa.Equals(p.Cd_empresa) &&
                                                            v.rItensVendaMesaConv.Id_venda.Equals(p.Id_venda) &&
                                                            v.rItensVendaMesaConv.Id_item.Equals(p.Id_item)))
                                {
                                    rVenda.lItem.Add(new CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item()
                                    {
                                        //Criar item venda OS
                                        Cd_local = p.Cd_local,
                                        Cd_produto = p.Cd_produto,
                                        Ds_produto = p.Ds_produto,
                                        Cd_grupo = p.Cd_grupo,
                                        Sigla_unidade = p.Sigla_unidade,
                                        Cd_condfiscal_produto = p.Cd_condfiscal_produto,
                                        Cd_unidade = p.Cd_unidade,
                                        Quantidade = p.Qtd_faturar,
                                        Vl_unitario = p.Vl_unitario,
                                        Vl_subtotal = p.Vl_subtotal,
                                        Vl_desconto = p.Vl_desconto,
                                        St_registro = "A",
                                        rItensVendaMesaConv = p
                                    });
                                    bsItensCupom.ResetBindings(true);
                                }
                            }
                        }
                        else
                        {
                            //Buscar ficha tecnica produto composto
                            CamadaDados.Estoque.Cadastros.TList_FichaTecProduto lFicha =
                                CamadaNegocio.Estoque.Cadastros.TCN_FichaTecProduto.Buscar(p.Cd_produto, string.Empty, null);
                            lFicha.ForEach(v => v.Quantidade = v.Quantidade * p.Qtd_faturar);
                            CamadaNegocio.Estoque.Cadastros.TCN_FichaTecProduto.MontarFichaTec(string.Empty, string.Empty, lFicha, null);
                            //Buscar saldo itens da ficha tecnica
                            string msg = string.Empty;
                            lFicha.ForEach(v =>
                            {
                                //Buscar saldo estoque do item
                                decimal saldo = decimal.Zero;
                                CamadaNegocio.Estoque.TCN_LanEstoque.SaldoEstoqueLocal(rVenda.Cd_empresa,
                                                                                        v.Cd_item,
                                                                                        p.Cd_local,
                                                                                        ref saldo,
                                                                                        null);
                                if (saldo < v.Quantidade)
                                    msg += "Produto.........: " + v.Cd_item.Trim() + "-" + v.Ds_item.Trim() + "\r\n" +
                                           "Saldo Disponivel: " + saldo.ToString("N3", new System.Globalization.CultureInfo("pt-BR", true)) + "\r\n";
                            });
                            if (!string.IsNullOrEmpty(msg))
                            {
                                msg = "Produto Composto contem itens da ficha tecnica sem saldo em estoque para concretizar a venda.\r\n" + msg.Trim();
                                MessageBox.Show(msg, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                rVenda.lItem.Add(new CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item()
                                {
                                    //Criar item venda OS
                                    Cd_local = p.Cd_local,
                                    Cd_produto = p.Cd_produto,
                                    Ds_produto = p.Ds_produto,
                                    Cd_grupo = p.Cd_grupo,
                                    Sigla_unidade = p.Sigla_unidade,
                                    Cd_condfiscal_produto = p.Cd_condfiscal_produto,
                                    Cd_unidade = p.Cd_unidade,
                                    Quantidade = p.Quantidade,
                                    Vl_unitario = p.Vl_unitario,
                                    Vl_subtotal = p.Vl_subtotal,
                                    Vl_desconto = p.Vl_desconto,
                                    St_registro = "A",
                                    rItensVendaMesaConv = p
                                });
                                bsItensCupom.ResetBindings(true);
                            }
                        }
                    }
                    else
                    {
                        rVenda.lItem.Add(new CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item()
                        {
                            //Criar item venda OS
                            Cd_local = p.Cd_local,
                            Cd_produto = p.Cd_produto,
                            Ds_produto = p.Ds_produto,
                            Cd_grupo = p.Cd_grupo,
                            Sigla_unidade = p.Sigla_unidade,
                            Cd_condfiscal_produto = p.Cd_condfiscal_produto,
                            Cd_unidade = p.Cd_unidade,
                            Quantidade = p.Quantidade,
                            Vl_unitario = p.Vl_unitario,
                            Vl_subtotal = p.Vl_subtotal,
                            Vl_desconto = p.Vl_desconto,
                            St_registro = "A",
                            rItensVendaMesaConv = p
                        });
                        bsItensCupom.ResetBindings(true);
                    }
                });
            }   
            TotalizarVenda();
        }

        private void CancelarVenda()
        {
            if(rVenda != null)
                try
                {
                    //Verificar se existe algum produto combustivel na venda
                    rVenda.lItem.ForEach(p =>
                    {
                        if (p.rVendaCombustivel != null)
                            //Verificar se venda esta faturada
                            if (new CamadaDados.PostoCombustivel.TCD_VendaCombustivel().BuscarEscalar(
                                new TpBusca[]
                                {                   
                                    new TpBusca()
                                    {
                                        vNM_Campo = "a.cd_empresa",
                                        vOperador = "=",
                                        vVL_Busca = "'" + p.rVendaCombustivel.Cd_empresa.Trim() + "'"
                                    },
                                    new TpBusca()
                                    {
                                        vNM_Campo = "a.id_venda",
                                        vOperador = "=",
                                        vVL_Busca = p.rVendaCombustivel.Id_vendastr
                                    },
                                    new TpBusca()
                                    {
                                        vNM_Campo = "a.id_cupom",
                                        vOperador = "is not",
                                        vVL_Busca = "null"
                                    }
                                }, "1") == null)
                            {
                                p.rVendaCombustivel.St_registro = "A";
                                p.rVendaCombustivel.Id_cupom = null;
                                p.rVendaCombustivel.Id_lancto = null;
                                CamadaNegocio.PostoCombustivel.TCN_VendaCombustivel.Gravar(p.rVendaCombustivel, null);
                            }
                    });
                    rVenda = null;
                    NM_Clifor.Enabled = false;
                    Cd_clifor.Text = lCfg[0].Cd_clifor;
                    NM_Clifor.Text = lCfg[0].Nm_clifor;
                    Cd_clifor.BackColor = Color.White;
                    cd_endereco.Text = lCfg[0].Cd_endereco;
                    lblCxLivre.Visible = true;
                    lblTotalItens.Text = string.Empty;
                    lblTotalDesconto.Text = string.Empty;
                    lblTotalCupom.Text = string.Empty;
                    bsItensCupom.ResetBindings(true);
                    //Atualizar Venda Combustivel Aberto
                    afterBusca();
                }
                catch(Exception ex)
                { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void CancelarItem()
        {
            if (rVenda != null)
                if (rVenda.lItem.Count > 0)
                    using (TFItensVenda fItens = new TFItensVenda())
                    {
                        fItens.lItem = rVenda.lItem;
                        if (fItens.ShowDialog() == DialogResult.OK)
                        {
                            fItens.lItem.FindAll(p => p.St_processar).ForEach(p =>
                            {
                                if (p.rVendaCombustivel != null)
                                {
                                    if (p.rVendaCombustivel.St_registro.Trim().ToUpper().Equals("F"))
                                    {
                                        p.rVendaCombustivel.St_registro = "A";
                                        CamadaNegocio.PostoCombustivel.TCN_VendaCombustivel.Gravar(p.rVendaCombustivel, null);
                                        //Atualizar Grid
                                        afterBusca();
                                    }
                                    rVenda.lItem.Remove(p);
                                    bsItensCupom.ResetBindings(true);
                                }
                                else
                                {
                                    rVenda.lItem.Remove(p);
                                    bsItensCupom.ResetBindings(true);
                                }
                            });
                            if (rVenda.lItem.Count.Equals(0))
                                CancelarVenda();
                            TotalizarVenda();
                        }
                    }
        }

        private void BuscarItens()
        {
            if (!string.IsNullOrEmpty(cd_produto.Text))
            {
                quantidade.Value = Math.Round(quantidade.Value, 3);
                if (quantidade.Value.Equals(decimal.Zero))
                {
                    MessageBox.Show("Obrigatorio informar quantidade.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    quantidade.Focus();
                    return;
                }
                string pCd_codbarra = cd_produto.Text;
                //Buscar lengt cd_produto
                CamadaDados.Diversos.TList_CadParamSys lParam =
                    CamadaNegocio.Diversos.TCN_CadParamSys.Busca("CD_PRODUTO",
                                                                 string.Empty,
                                                                 decimal.Zero,
                                                                 null);
                if (lParam.Count > 0)
                    if (cd_produto.Text.Trim().Length < lParam[0].Tamanho)
                        cd_produto.Text = cd_produto.Text.Trim().PadLeft(Convert.ToInt32(lParam[0].Tamanho), '0');
                //Buscar produto
                List<CamadaDados.Estoque.Cadastros.TRegistro_CadProduto> lProduto =
                    CamadaNegocio.Estoque.Cadastros.TCN_CadProduto.BuscarProdutoVendaRapida(cd_produto.Text,
                                                                                            pCd_codbarra,
                                                                                            null);

                if (lProduto.Count > 0)
                {
                    quantidade.DecimalPlaces = Convert.ToInt32(lProduto[0].CasasDecimais);
                    //Verificar saldo estoque do produto
                    if (lCfg[0].St_movestoquebool)
                    {
                        if ((!new CamadaDados.Estoque.Cadastros.TCD_CadProduto().ItemServico(lProduto[0].CD_Produto)) &&
                            (!new CamadaDados.Estoque.Cadastros.TCD_CadProduto().ProdutoConsumoInterno(lProduto[0].CD_Produto)))
                        {
                            if (!new CamadaDados.Estoque.Cadastros.TCD_CadProduto().ProdutoComposto(lProduto[0].CD_Produto))
                            {
                                decimal saldo = BuscarSaldoLocal(lProduto[0].CD_Produto);
                                if (saldo < quantidade.Value)
                                {
                                    MessageBox.Show("Não existe saldo disponivel no estoque.\r\n" +
                                                    "Empresa.........: " + rCfgPosto.Cd_empresa.Trim() + "-" + rCfgPosto.Nm_empresa.Trim() + "\r\n" +
                                                    "Produto.........: " + lProduto[0].CD_Produto.Trim() + "-" + lProduto[0].DS_Produto.Trim() + "\r\n" +
                                                    "Local Arm.......: " + lCfg[0].Cd_local.Trim() + "-" + lCfg[0].Ds_local + "\r\n" +
                                                    "Saldo Disponivel: " + saldo.ToString("N3", new System.Globalization.CultureInfo("pt-BR", true)),
                                                    "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    return;
                                }
                            }
                            else
                            {
                                //Buscar ficha tecnica produto composto
                                CamadaDados.Estoque.Cadastros.TList_FichaTecProduto lFicha =
                                    CamadaNegocio.Estoque.Cadastros.TCN_FichaTecProduto.Buscar(lProduto[0].CD_Produto, string.Empty, null);
                                lFicha.ForEach(p => p.Quantidade = p.Quantidade * quantidade.Value);
                                CamadaNegocio.Estoque.Cadastros.TCN_FichaTecProduto.MontarFichaTec(string.Empty, string.Empty, lFicha, null);
                                //Buscar saldo itens da ficha tecnica
                                string msg = string.Empty;
                                lFicha.ForEach(p =>
                                    {
                                        //Buscar saldo estoque do item
                                        decimal saldo = decimal.Zero;
                                        CamadaNegocio.Estoque.TCN_LanEstoque.SaldoEstoqueLocal(rCfgPosto.Cd_empresa, p.Cd_item, lCfg[0].Cd_local, ref saldo, null);
                                        if (saldo < p.Quantidade)
                                            msg += "Produto.........: " + p.Cd_item.Trim() + "-" + p.Ds_item.Trim() + "\r\n" +
                                                   "Saldo Disponivel: " + saldo.ToString("N3", new System.Globalization.CultureInfo("pt-BR", true)) + "\r\n";
                                    });
                                if (!string.IsNullOrEmpty(msg))
                                {
                                    msg = "Produto Composto contem itens da ficha tecnica sem saldo em estoque para concretizar a venda.\r\n" + msg.Trim();
                                    MessageBox.Show(msg, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    return;
                                }
                            }
                        }
                    }
                    NovaVenda(lProduto[0], null, null, null);
                }
            }
        }

        private string[] TratarRetornoAbastOnLine(string comando)
        {
            if (!string.IsNullOrEmpty(comando))
            {
                string[] retorno = new string[0];
                comando = comando.SoNumero();
                while (true)
                {
                    try
                    {
                        if (rCfgPosto.St_identfrentistabool)
                        {
                            if (comando.Trim().Length >= 18)
                            {
                                Array.Resize(ref retorno, retorno.Length + 1);
                                retorno[retorno.Length - 1] = comando.Substring(0, 18);
                                comando = comando.Remove(0, 18);
                            }
                            else break;
                        }
                        else
                        {
                            if (comando.Trim().Length >= 8)
                            {
                                Array.Resize(ref retorno, retorno.Length + 1);
                                retorno[retorno.Length - 1] = comando.Substring(0, 8);
                                comando = comando.Remove(0, 8);
                            }
                            else break;
                        }
                    }
                    catch { break; }
                }
                return retorno;
            }
            else
                return null;
        }

        private void SetarValorAbast(string bico, double valor)
        {
            if (bb01.Tag == null ? false : bb01.Tag.ToString().Trim().Equals(bico.Trim()))
            {
                if (valor > 0)
                    bb01.BackColor = Color.LightGreen;
                else
                    bb01.BackColor = System.Drawing.SystemColors.Control;
            }
            else if (bb02.Tag == null ? false : bb02.Tag.ToString().Trim().Equals(bico.Trim()))
            {
                if (valor > 0)
                    bb02.BackColor = Color.LightGreen;
                else
                    bb02.BackColor = System.Drawing.SystemColors.Control;
            }
            else if (bb03.Tag == null ? false : bb03.Tag.ToString().Trim().Equals(bico.Trim()))
            {
                if (valor > 0)
                    bb03.BackColor = Color.LightGreen;
                else
                    bb03.BackColor = System.Drawing.SystemColors.Control;
            }
            else if (bb04.Tag == null ? false : bb04.Tag.ToString().Trim().Equals(bico.Trim()))
            {
                if (valor > 0)
                    bb04.BackColor = Color.LightGreen;
                else
                    bb04.BackColor = System.Drawing.SystemColors.Control;
            }
            else if (bb05.Tag == null ? false : bb05.Tag.ToString().Trim().Equals(bico.Trim()))
            {
                if (valor > 0)
                    bb05.BackColor = Color.LightGreen;
                else
                    bb05.BackColor = System.Drawing.SystemColors.Control;
            }
            else if (bb06.Tag == null ? false : bb06.Tag.ToString().Trim().Equals(bico.Trim()))
            {
                if (valor > 0)
                    bb06.BackColor = Color.LightGreen;
                else
                    bb06.BackColor = System.Drawing.SystemColors.Control;
            }
            else if (bb07.Tag == null ? false : bb07.Tag.ToString().Trim().Equals(bico.Trim()))
            {
                if (valor > 0)
                    bb07.BackColor = Color.LightGreen;
                else
                    bb07.BackColor = System.Drawing.SystemColors.Control;
            }
            else if (bb08.Tag == null ? false : bb08.Tag.ToString().Trim().Equals(bico.Trim()))
            {
                if (valor > 0)
                    bb08.BackColor = Color.LightGreen;
                else
                    bb08.BackColor = System.Drawing.SystemColors.Control;
            }
            else if (bb09.Tag == null ? false : bb09.Tag.ToString().Trim().Equals(bico.Trim()))
            {
                if (valor > 0)
                    bb09.BackColor = Color.LightGreen;
                else
                    bb09.BackColor = System.Drawing.SystemColors.Control;
            }
            else if (bb10.Tag == null ? false : bb10.Tag.ToString().Trim().Equals(bico.Trim()))
            {
                if (valor > 0)
                    bb10.BackColor = Color.LightGreen;
                else
                    bb10.BackColor = System.Drawing.SystemColors.Control;
            }
            else if (bb11.Tag == null ? false : bb11.Tag.ToString().Trim().Equals(bico.Trim()))
            {
                if (valor > 0)
                    bb11.BackColor = Color.LightGreen;
                else
                    bb11.BackColor = System.Drawing.SystemColors.Control;
            }
            else if (bb12.Tag == null ? false : bb12.Tag.ToString().Trim().Equals(bico.Trim()))
            {
                if (valor > 0)
                    bb12.BackColor = Color.LightGreen;
                else
                    bb12.BackColor = System.Drawing.SystemColors.Control;
            }
            else if (bb13.Tag == null ? false : bb13.Tag.ToString().Trim().Equals(bico.Trim()))
            {
                if (valor > 0)
                    bb13.BackColor = Color.LightGreen;
                else
                    bb13.BackColor = System.Drawing.SystemColors.Control;
            }
            else if (bb14.Tag == null ? false : bb14.Tag.ToString().Trim().Equals(bico.Trim()))
            {
                if (valor > 0)
                    bb14.BackColor = Color.LightGreen;
                else
                    bb14.BackColor = System.Drawing.SystemColors.Control;
            }
            else if (bb15.Tag == null ? false : bb15.Tag.ToString().Trim().Equals(bico.Trim()))
            {
                if (valor > 0)
                    bb15.BackColor = Color.LightGreen;
                else
                    bb15.BackColor = System.Drawing.SystemColors.Control;
            }
            else if (bb16.Tag == null ? false : bb16.Tag.ToString().Trim().Equals(bico.Trim()))
            {
                if (valor > 0)
                    bb16.BackColor = Color.LightGreen;
                else
                    bb16.BackColor = System.Drawing.SystemColors.Control;
            }
            else if (bb17.Tag == null ? false : bb17.Tag.ToString().Trim().Equals(bico.Trim()))
            {
                if (valor > 0)
                    bb17.BackColor = Color.LightGreen;
                else
                    bb17.BackColor = System.Drawing.SystemColors.Control;
            }
            else if (bb18.Tag == null ? false : bb18.Tag.ToString().Trim().Equals(bico.Trim()))
            {
                if (valor > 0)
                    bb18.BackColor = Color.LightGreen;
                else
                    bb18.BackColor = System.Drawing.SystemColors.Control;
            }
            else if (bb19.Tag == null ? false : bb19.Tag.ToString().Trim().Equals(bico.Trim()))
            {
                if (valor > 0)
                    bb19.BackColor = Color.LightGreen;
                else
                    bb19.BackColor = System.Drawing.SystemColors.Control;
            }
            else if (bb20.Tag == null ? false : bb20.Tag.ToString().Trim().Equals(bico.Trim()))
            {
                if (valor > 0)
                    bb20.BackColor = Color.LightGreen;
                else
                    bb20.BackColor = System.Drawing.SystemColors.Control;
            }
            else if (bb21.Tag == null ? false : bb21.Tag.ToString().Trim().Equals(bico.Trim()))
            {
                if (valor > 0)
                    bb21.BackColor = Color.LightGreen;
                else
                    bb21.BackColor = System.Drawing.SystemColors.Control;
            }
            else if (bb22.Tag == null ? false : bb22.Tag.ToString().Trim().Equals(bico.Trim()))
            {
                if (valor > 0)
                    bb22.BackColor = Color.LightGreen;
                else
                    bb22.BackColor = System.Drawing.SystemColors.Control;
            }
            else if (bb23.Tag == null ? false : bb23.Tag.ToString().Trim().Equals(bico.Trim()))
            {
                if (valor > 0)
                    bb23.BackColor = Color.LightGreen;
                else
                    bb23.BackColor = System.Drawing.SystemColors.Control;
            }
            else if (bb24.Tag == null ? false : bb24.Tag.ToString().Trim().Equals(bico.Trim()))
            {
                if (valor > 0)
                    bb24.BackColor = Color.LightGreen;
                else
                    bb24.BackColor = System.Drawing.SystemColors.Control;
            }
        }

        private void TratarAbastOnLine(string comando)
        {
            if (!string.IsNullOrEmpty(comando))
                if (comando.Trim() != "(0)")
                {
                    string[] abast = TratarRetornoAbastOnLine(comando);
                    if (abast != null)
                        foreach (string p in abast)
                            SetarValorAbast(p.Substring(0, 2),
                                            Convert.ToDouble(decimal.Divide(decimal.Parse(p.Trim().Substring(2, 6)), 1000)));
                }
        }

        private bool TratarAbastecimento(string Tp_concentrador, string abast)
        {
            bool retorno = false;
            string strAbast = abast;
            if (!string.IsNullOrEmpty(abast))
            {
                if (Tp_concentrador.Trim().ToUpper().Equals("CT") ||
                    Tp_concentrador.Trim().ToUpper().Equals("ZT"))
                {
                    abast = abast.Remove(0, abast.IndexOf("("));
                    if (abast.IndexOf(")") < abast.Trim().Length - 1)
                        abast = abast.Remove(abast.IndexOf(")") + 1, abast.Length - abast.IndexOf(")") - 1);
                    if ((!abast.Trim().Equals("(0)")) &&
                        (abast.Trim().Length.Equals(34) ||
                        abast.Trim().Length.Equals(52) ||
                        abast.Trim().Length.Equals(74) ||
                        abast.Trim().Length.Equals(75) ||
                        abast.Trim().Length.Equals(86) ||
                        abast.Trim().Length.Equals(87)))
                    {
                        if (abast.Trim().Substring(1, 1).Trim().ToUpper().Equals("A"))
                            abast = abast.Remove(1, 1);
                        try
                        {
                            CamadaDados.PostoCombustivel.TRegistro_VendaCombustivel rItem = new CamadaDados.PostoCombustivel.TRegistro_VendaCombustivel();
                            //Empresa
                            rItem.Cd_empresa = rCfgPosto.Cd_empresa;
                            //Preco Unitario Bomba
                            if (decimal.Parse(abast.Substring(13, 4)) > decimal.Zero)
                                rItem.Vl_unitario = decimal.Divide(decimal.Parse(abast.Substring(13, 4)),
                                    rCfgPosto.Fatorconvunit > decimal.Zero ? rCfgPosto.Fatorconvunit : 
                                    TAutomacao.TratarVirgula(rCfgPosto.Tp_concentrador, abast.Substring(17, 2), "U") != null ?
                                    Convert.ToInt32(Math.Pow(10, TAutomacao.TratarVirgula(rCfgPosto.Tp_concentrador, abast.Substring(17, 2), "U").Value)) : 1000);
                            else
                            {
                                object obj = new CamadaDados.PostoCombustivel.Cadastros.TCD_BicoBomba().BuscarEscalar(
                                                new TpBusca[]
                                            {
                                                new TpBusca()
                                                {
                                                    vNM_Campo = "a.enderecofisicobico",
                                                    vOperador = "=",
                                                    vVL_Busca = "'" + abast.Substring(23, 2) + "'"
                                                }
                                            }, "b.cd_produto");
                                if (obj != null)
                                    rItem.Vl_unitario = CamadaNegocio.Estoque.Cadastros.TCN_LanPrecoItem.Busca_ConsultaPreco(rCfgPosto.Cd_empresa,
                                                                                                                             obj.ToString(),
                                                                                                                             rCfgPosto.Cd_tabelapreco,
                                                                                                                             null);
                            }
                            //Volume Abastecido
                            rItem.Volumeabastecido = decimal.Divide(decimal.Parse(abast.Substring(7, 6)),
                                rCfgPosto.Fatorconvvolume > decimal.Zero ? rCfgPosto.Fatorconvvolume :
                                TAutomacao.TratarVirgula(rCfgPosto.Tp_concentrador, abast.Substring(17, 2), "L") != null ?
                                Convert.ToInt32(Math.Pow(10, TAutomacao.TratarVirgula(rCfgPosto.Tp_concentrador, abast.Substring(17, 2), "L").Value)) : 1000);
                            //Valor Pagar
                            if (decimal.Parse(abast.Substring(1, 6)) > decimal.Zero)
                                rItem.Vl_subtotal = rCfgPosto.St_calcvltotalbool ?
                                    (Utils.Parametros.pubTruncarSubTotal ?
                                        Estruturas.Truncar(rItem.Volumeabastecido * rItem.Vl_unitario, 2) :
                                        Math.Round(rItem.Volumeabastecido * rItem.Vl_unitario, 2)) :
                                        Utils.Parametros.pubTruncarSubTotal ?
                                        Estruturas.Truncar(decimal.Divide(decimal.Parse(abast.Substring(1, 6)),
                                        rCfgPosto.Fatorconvsubtotal > decimal.Zero ? rCfgPosto.Fatorconvsubtotal :
                                        TAutomacao.TratarVirgula(rCfgPosto.Tp_concentrador, abast.Substring(17, 2), "T") != null ?
                                    Convert.ToInt32(Math.Pow(10, TAutomacao.TratarVirgula(rCfgPosto.Tp_concentrador, abast.Substring(17, 2), "T").Value)) : 100), 2) :
                                    decimal.Divide(decimal.Parse(abast.Substring(1, 6)), rCfgPosto.Fatorconvsubtotal > decimal.Zero ? rCfgPosto.Fatorconvsubtotal : TAutomacao.TratarVirgula(rCfgPosto.Tp_concentrador, abast.Substring(17, 2), "T") != null ?
                                    Convert.ToInt32(Math.Pow(10, TAutomacao.TratarVirgula(rCfgPosto.Tp_concentrador, abast.Substring(17, 2), "T").Value)) : 100);
                            else
                                rItem.Vl_subtotal = rItem.Volumeabastecido * rItem.Vl_unitario;
                            //Tempo Abastecimento
                            rItem.Tempoabastecimento = Convert.ToDecimal(int.Parse(abast.Substring(19, 4), System.Globalization.NumberStyles.HexNumber));
                            //Codigo bico
                            rItem.Enderecofisicobico = abast.Substring(23, 2);
                            //Data Abastecimento
                            DateTime dt_atual = CamadaDados.UtilData.Data_Servidor();
                            try
                            {

                                rItem.Dt_abastecimento = new DateTime(dt_atual.Year,
                                                                      dt_atual.Month,
                                                                      int.Parse(abast.Substring(25, 2)),
                                                                      int.Parse(abast.Substring(27, 2)),
                                                                      int.Parse(abast.Substring(29, 2)),
                                                                      dt_atual.Second);
                                if (Math.Abs(rItem.Dt_abastecimento.Value.Subtract(dt_atual).Hours) > 1)
                                    rItem.Dt_abastecimento = dt_atual;
                            }
                            catch { rItem.Dt_abastecimento = dt_atual; }
                            if (abast.Trim().Length.Equals(52))
                            {
                                //Numero Abastecimento
                                rItem.Numeroabastecimento = decimal.Parse(abast.Substring(33, 4));
                                //Encerrante do Bico
                                rItem.Encerrantebico = decimal.Divide(decimal.Parse(abast.Substring(37, 10)), 100);
                            }
                            if (abast.Trim().Length.Equals(74) || abast.Trim().Length.Equals(75))
                            {
                                //Numero Abastecimento
                                rItem.Numeroabastecimento = decimal.Parse(abast.Substring(33, 4));
                                //Encerrante do Bico
                                rItem.Encerrantebico = decimal.Divide(decimal.Parse(abast.Substring(37, 10)), 100);
                                //Identificar frentista
                                object obj_frentista = new CamadaDados.Financeiro.Cadastros.TCD_CadClifor().BuscarEscalar(
                                                        new TpBusca[]
                                                    {
                                                        new TpBusca()
                                                        {
                                                            vNM_Campo = "a.Ident_Frentista",
                                                            vOperador = "=",
                                                            vVL_Busca = "'" + abast.Substring(49, 16) + "'"
                                                        }
                                                    }, "a.cd_clifor");
                                rItem.Cd_frentista = obj_frentista == null ? string.Empty : obj_frentista.ToString();
                            }
                            if (abast.Trim().Length.Equals(86) || abast.Trim().Length.Equals(87))
                            {
                                //Identificar frentista
                                object obj_frentista = new CamadaDados.Financeiro.Cadastros.TCD_CadClifor().BuscarEscalar(
                                                        new TpBusca[]
                                                    {
                                                        new TpBusca()
                                                        {
                                                            vNM_Campo = "a.Ident_Frentista",
                                                            vOperador = "=",
                                                            vVL_Busca = "'" + abast.Substring(50, 16) + "'"
                                                        }
                                                    }, "a.cd_clifor");
                                rItem.Cd_frentista = obj_frentista == null ? string.Empty : obj_frentista.ToString();
                            }
                            //Remover abastecimento da lista online
                            SetarValorAbast(rItem.Enderecofisicobico, 0);
                            //Gravar venda combustivel
                            if (rItem.Volumeabastecido.Equals(decimal.Zero) &&
                                rItem.Vl_subtotal.Equals(decimal.Zero))
                                rItem.St_registro = "I";//Inconsistente
                            //Log com a string do abastecimento
                            rItem.StringAbast = strAbast;
                            CamadaNegocio.PostoCombustivel.TCN_VendaCombustivel.Gravar(rItem, null);
                            if (rCfgPosto.Tp_concentrador.Trim().ToUpper().Equals("ZT"))
                                TAutomacao.AvancarAbastecimento(rCfgPosto.Tp_concentrador, 0);
                            else if (tcpClient != null)
                                SendLan("(&I)");
                            retorno = true;
                        }
                        catch (Exception ex)
                        {
                            //Gravar arquivo log com a string abastecida
                            try
                            {
                                string vPath = Utils.Parametros.pubPathConfig;
                                if (!System.IO.Directory.Exists(vPath))
                                    vPath = "C:";
                                if (System.IO.File.Exists(vPath.Trim() + System.IO.Path.DirectorySeparatorChar.ToString() + "logConcentrador" + DateTime.Now.Date.ToString("dd-MM-yyyy") + ".txt"))
                                    using (System.IO.StreamWriter sw = System.IO.File.AppendText(vPath.Trim() + System.IO.Path.DirectorySeparatorChar.ToString() + "logConcentrador" + DateTime.Now.Date.ToString("dd-MM-yyyy") + ".txt"))
                                    {
                                        sw.WriteLine(strAbast);
                                    }
                                else
                                    using (System.IO.FileStream fs = System.IO.File.Create(vPath.Trim() + System.IO.Path.DirectorySeparatorChar.ToString() + "logConcentrador" + DateTime.Now.Date.ToString("dd-MM-yyyy") + ".txt"))
                                    {
                                        using (System.IO.StreamWriter sw = new System.IO.StreamWriter(fs))
                                        {
                                            sw.WriteLine(strAbast);
                                        }
                                    }
                            }
                            catch { }
                            throw new Exception(ex.Message.Trim());
                        }
                    }
                }
                else if (Tp_concentrador.Trim().ToUpper().Equals("VW"))
                {
                    if (abast.Trim().Length.Equals(64))
                        if(abast.Trim().Substring(0, 1).Equals("o"))
                            if (abast.Trim().Substring(5, 1).Equals("a"))
                            {
                                try
                                {
                                    CamadaDados.PostoCombustivel.TRegistro_VendaCombustivel rItem = new CamadaDados.PostoCombustivel.TRegistro_VendaCombustivel();
                                    //Empresa
                                    rItem.Cd_empresa = rCfgPosto.Cd_empresa;
                                    //Preco Unitario Bomba
                                    if (decimal.Parse(abast.Substring(26, 4)) > decimal.Zero)
                                        rItem.Vl_unitario = decimal.Divide(decimal.Parse(abast.Substring(26, 4)), rCfgPosto.Fatorconvunit > decimal.Zero ? rCfgPosto.Fatorconvunit : Convert.ToDecimal(Math.Pow(10, Convert.ToDouble(abast.Substring(24, 1)))));
                                    else
                                    {
                                        object obj = new CamadaDados.PostoCombustivel.Cadastros.TCD_BicoBomba().BuscarEscalar(
                                                new TpBusca[]
                                            {
                                                new TpBusca()
                                                {
                                                    vNM_Campo = "a.enderecofisicobico",
                                                    vOperador = "=",
                                                    vVL_Busca = "'" + abast.Substring(10, 2) + "'"
                                                }
                                            }, "b.cd_produto");
                                        if (obj != null)
                                            rItem.Vl_unitario = CamadaNegocio.Estoque.Cadastros.TCN_LanPrecoItem.Busca_ConsultaPreco(rCfgPosto.Cd_empresa,
                                                                                                                                     obj.ToString(),
                                                                                                                                     rCfgPosto.Cd_tabelapreco,
                                                                                                                                     null);
                                    }
                                    //Volume Abastecido
                                    rItem.Volumeabastecido = decimal.Divide(decimal.Parse(abast.Substring(30, 8)), rCfgPosto.Fatorconvvolume > decimal.Zero ? rCfgPosto.Fatorconvvolume : Convert.ToDecimal(Math.Pow(10, Convert.ToDouble(abast.Substring(25, 1)))));
                                    //Valor Pagar
                                    if(decimal.Parse(abast.Substring(38,8)) > decimal.Zero)
                                        rItem.Vl_subtotal = rCfgPosto.St_calcvltotalbool ?
                                            (Utils.Parametros.pubTruncarSubTotal ?
                                                Estruturas.Truncar(rItem.Volumeabastecido * rItem.Vl_unitario, 2) :
                                                Math.Round(rItem.Volumeabastecido * rItem.Vl_unitario, 2)) :
                                                Utils.Parametros.pubTruncarSubTotal ?
                                                Estruturas.Truncar(decimal.Divide(decimal.Parse(abast.Substring(38, 8)), rCfgPosto.Fatorconvsubtotal > decimal.Zero ? rCfgPosto.Fatorconvsubtotal : 100), 2) :
                                                decimal.Divide(decimal.Parse(abast.Substring(38, 8)), rCfgPosto.Fatorconvsubtotal > decimal.Zero ? rCfgPosto.Fatorconvsubtotal : 100);
                                    else
                                        rItem.Vl_subtotal = rItem.Volumeabastecido * rItem.Vl_unitario;
                                    //Codigo bico
                                    rItem.Enderecofisicobico = abast.Substring(10, 2);
                                    //Data Abastecimento
                                    DateTime dt_atual = CamadaDados.UtilData.Data_Servidor();
                                    try
                                    {

                                        rItem.Dt_abastecimento = new DateTime(2000 + int.Parse(abast.Substring(22, 2)),
                                                                              int.Parse(abast.Substring(20, 2)),
                                                                              int.Parse(abast.Substring(18, 2)),
                                                                              int.Parse(abast.Substring(12, 2)),
                                                                              int.Parse(abast.Substring(14, 2)),
                                                                              int.Parse(abast.Substring(16, 2)));
                                        if ((Math.Abs(rItem.Dt_abastecimento.Value.Subtract(dt_atual).Hours) > 1) &&
                                            (!rCfgPosto.Tp_concentrador.Trim().ToUpper().Equals("ZT")))
                                            rItem.Dt_abastecimento = dt_atual;
                                    }
                                    catch { rItem.Dt_abastecimento = dt_atual; }
                                    //Numero Abastecimento
                                    rItem.Numeroabastecimento = decimal.Parse(abast.Substring(6, 4));
                                    //Encerrante do Bico
                                    rItem.Encerrantebico = decimal.Divide(decimal.Parse(abast.Substring(46, 8)), 100);
                                    
                                    //Remover abastecimento da lista online
                                    SetarValorAbast(rItem.Enderecofisicobico, 0);
                                    //Gravar venda combustivel
                                    if (rItem.Volumeabastecido.Equals(decimal.Zero) &&
                                        rItem.Vl_subtotal.Equals(decimal.Zero))
                                        rItem.St_registro = "I";//Inconsistente
                                    //Log com a string do abastecimento
                                    rItem.StringAbast = strAbast;
                                    CamadaNegocio.PostoCombustivel.TCN_VendaCombustivel.Gravar(rItem, null);
                                    //Avancar abastecida
                                    if (tcpClient == null)
                                        TAutomacao.AvancarAbastecimento(rCfgPosto.Tp_concentrador, Convert.ToInt32(rItem.Numeroabastecimento));
                                    else SendLan("(&I)");
                                    retorno = true;
                                }
                                catch (Exception ex)
                                {
                                    //Gravar arquivo log com a string abastecida
                                    try
                                    {
                                        string vPath = Utils.Parametros.pubPathConfig;
                                        if (!System.IO.Directory.Exists(vPath))
                                            vPath = "C:";
                                        if (System.IO.File.Exists(vPath.Trim() + System.IO.Path.DirectorySeparatorChar.ToString() + "logConcentrador" + DateTime.Now.Date.ToString("dd-MM-yyyy") + ".txt"))
                                            using (System.IO.StreamWriter sw = System.IO.File.AppendText(vPath.Trim() + System.IO.Path.DirectorySeparatorChar.ToString() + "logConcentrador" + DateTime.Now.Date.ToString("dd-MM-yyyy") + ".txt"))
                                            {
                                                sw.WriteLine(strAbast);
                                            }
                                        else
                                            using (System.IO.FileStream fs = System.IO.File.Create(vPath.Trim() + System.IO.Path.DirectorySeparatorChar.ToString() + "logConcentrador" + DateTime.Now.Date.ToString("dd-MM-yyyy") + ".txt"))
                                            {
                                                using (System.IO.StreamWriter sw = new System.IO.StreamWriter(fs))
                                                {
                                                    sw.WriteLine(strAbast);
                                                }
                                            }
                                    }
                                    catch { }
                                    throw new Exception(ex.Message.Trim());
                                }
                            }
                }
            }
            return retorno;
        }

        private void IntervencaoTecnica()
        {
            using (TFIntervencaoTecnica fIntervencao = new TFIntervencaoTecnica())
            {
                if (fIntervencao.ShowDialog() == DialogResult.OK)
                    if (fIntervencao.rIntervencao != null)
                        try
                        {
                            CamadaNegocio.PostoCombustivel.TCN_IntervencaoTecnica.Gravar(fIntervencao.rIntervencao, null);
                            MessageBox.Show("Interveção tecnica gravada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void AfericaoBomba()
        {
            if (bsVendaCombustivel.Count > 0)
            {
                List<CamadaDados.PostoCombustivel.TRegistro_VendaCombustivel> lVenda =
                    (bsVendaCombustivel.DataSource as CamadaDados.PostoCombustivel.TList_VendaCombustivel).FindAll(p => p.St_processar);
                cbTodos.Checked = false;
                if (lVenda.Count > 0)
                    using (Proc_Commoditties.TFLanSessaoPDV fSessao = new Proc_Commoditties.TFLanSessaoPDV())
                    {
                        if (fSessao.ShowDialog() == DialogResult.OK)
                            //Verificar se o usuario tem permissao para cancelar cupom
                            if (CamadaNegocio.Diversos.TCN_Usuario_RegraEspecial.ValidaRegra(fSessao.Usuario, "PERMITIR LANÇAR AFERIÇÃO", null))
                            {
                                if (MessageBox.Show("Confirma venda combustivel como aferição bomba?", "Pergunta", MessageBoxButtons.YesNo,
                                     MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                                {
                                    try
                                    {
                                        CamadaNegocio.PostoCombustivel.TCN_VendaCombustivel.AfericaoBomba(lVenda, rCaixa.Id_caixa, null);
                                        MessageBox.Show("Aferições gravadas com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        afterBusca();
                                    }
                                    catch (Exception ex)
                                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                                }
                            }
                    }
            }
        }

        private void ConsultaNfe(string Tp_documento)
        {
            using (Proc_Commoditties.TFLanConsultaNFe fNfe = new Proc_Commoditties.TFLanConsultaNFe())
            {
                fNfe.Tp_documento = Tp_documento;
                fNfe.ShowDialog();
            }
        }

        private void VendaConveniencia()
        {
            using (TFLanVendaConveniencia fConveniencia = new TFLanVendaConveniencia())
            {
                fConveniencia.Login = LoginPdv;
                fConveniencia.rSessao = lSessao[0];
                fConveniencia.lCfg = new CamadaDados.Faturamento.Cadastros.TList_CFGCupomFiscal() { rCfgConv };
                fConveniencia.ShowDialog();
            }
        }

        private void ReceberFinanceiro()
        {
            using (TFLanParcelas fParcelas = new TFLanParcelas())
            {
                fParcelas.Cd_moeda = CamadaNegocio.ConfigGer.TCN_CadParamGer.BuscaVL_String_Empresa("CD_MOEDA_PADRAO", lCfg[0].Cd_empresa, null);
                fParcelas.pId_caixaoperacional = rCaixa.Id_caixa;
                fParcelas.Loginpdv = LoginPdv;
                fParcelas.Cd_contaoperacional = lCfg[0].Cd_contaoperacional;
                fParcelas.Ds_contaoperacional = lCfg[0].Ds_contaoperacional;
                fParcelas.ShowDialog();
            }
        }

        private void NovoCliente()
        {
            using (Financeiro.Cadastros.TFCadClifor fClifor = new Financeiro.Cadastros.TFCadClifor())
            {
                fClifor.WindowState = FormWindowState.Normal;
                fClifor.StartPosition = FormStartPosition.CenterScreen;
                fClifor.St_permiteCadResumido = true;
                fClifor.ShowDialog();
            }
        }

        private void ProcessarVendaEspera()
        {
            using (TFVendaEspera fVenda = new TFVendaEspera())
            {
                fVenda.Cd_empresa = rCfgPosto.Cd_empresa;
                fVenda.Login = lSessao[0].Login;
                if (fVenda.ShowDialog() == DialogResult.OK)
                    if (fVenda.lVenda != null)
                        NovaVenda(null, fVenda.lVenda, null, null);
                tslVendaEspera.Text = new CamadaDados.PostoCombustivel.TCD_VendaCombustivel().BuscarEscalar(
                                            new TpBusca[]
                                            {
                                                new TpBusca()
                                                {
                                                    vNM_Campo = "a.cd_empresa",
                                                    vOperador = "=",
                                                    vVL_Busca = "'" + rCfgPosto.Cd_empresa.Trim() + "'"
                                                },
                                                new TpBusca()
                                                {
                                                    vNM_Campo = "isnull(a.st_registro, 'A')",
                                                    vOperador = "=",
                                                    vVL_Busca = "'E'"
                                                },
                                                new TpBusca()
                                                {
                                                    vNM_Campo = "a.loginespera",
                                                    vOperador = "=",
                                                    vVL_Busca = "'" + lSessao[0].Login.Trim() + "'"
                                                }
                                            }, "isnull(count(a.id_venda), 0)").ToString();
                afterBusca();
            }
        }
        
        private void MoverEspera()
        {
            if (bsVendaCombustivel.Count > 0)
            {
                if((rCfgPosto.Qt_maxabastespera > decimal.Zero) && (!string.IsNullOrEmpty(tslVendaEspera.Text.SoNumero())))
                    if ((decimal.Parse(tslVendaEspera.Text) + (bsVendaCombustivel.List as CamadaDados.PostoCombustivel.TList_VendaCombustivel).Count(p => p.St_processar)) > rCfgPosto.Qt_maxabastespera)
                    {
                        MessageBox.Show("Quantidade total de venda em espera excede limite maximo permitido para posto<" + rCfgPosto.Qt_maxabastespera.ToString() + ">.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                (bsVendaCombustivel.DataSource as CamadaDados.PostoCombustivel.TList_VendaCombustivel).FindAll(p => p.St_processar).ForEach(p =>
                {
                    try
                    {
                        p.St_registro = "E";
                        p.Login_espera = lSessao[0].Login;
                        CamadaNegocio.PostoCombustivel.TCN_VendaCombustivel.Gravar(p, null);
                        (bsVendaCombustivel.DataSource as CamadaDados.PostoCombustivel.TList_VendaCombustivel).Find(v => v.Id_venda.Value.Equals(p.Id_venda.Value) &&
                                                                                                                        v.Cd_empresa.Trim().Equals(p.Cd_empresa.Trim())).St_processar = false;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                });
                tslVendaEspera.Text = new CamadaDados.PostoCombustivel.TCD_VendaCombustivel().BuscarEscalar(
                                                    new TpBusca[]
                                            {
                                                new TpBusca()
                                                {
                                                    vNM_Campo = "a.cd_empresa",
                                                    vOperador = "=",
                                                    vVL_Busca = "'" + rCfgPosto.Cd_empresa.Trim() + "'"
                                                },
                                                new TpBusca()
                                                {
                                                    vNM_Campo = "isnull(a.st_registro, 'A')",
                                                    vOperador = "=",
                                                    vVL_Busca = "'E'"
                                                },
                                                new TpBusca()
                                                {
                                                    vNM_Campo = "a.loginespera",
                                                    vOperador = "=",
                                                    vVL_Busca = "'" + lSessao[0].Login.Trim() + "'"
                                                }
                                            }, "isnull(count(a.id_venda), 0)").ToString();
                afterBusca();
                cbTodos.Checked = false;
            }
        }

        private void DesdobrarAbastecida()
        {
            using (Proc_Commoditties.TFLanSessaoPDV fSessao = new Proc_Commoditties.TFLanSessaoPDV())
            {
                if (fSessao.ShowDialog() == DialogResult.OK)
                    //Verificar se o usuario tem permissao para desdobrar abastecida
                    if (CamadaNegocio.Diversos.TCN_Usuario_RegraEspecial.ValidaRegra(fSessao.Usuario, "PERMITIR DESDOBRAR ABASTECIDA", null))
                    {
                        using (TFDesmembrarAbast fDesd = new TFDesmembrarAbast())
                        {
                            if (fDesd.ShowDialog() == DialogResult.OK)
                                if (fDesd.lDesdobro != null)
                                    try
                                    {
                                        CamadaNegocio.PostoCombustivel.TCN_VendaCombustivel.DesdobrarAbastecidas(fDesd.lVenda, fDesd.lDesdobro, null);
                                        MessageBox.Show("Desdobros Gravados com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        afterBusca();
                                    }
                                    catch (Exception ex)
                                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                        }
                    }
            }
        }

        private void IncluirAbastManual()
        {
            using (TFVendaCombustivel fVenda = new TFVendaCombustivel())
            {
                fVenda.Cd_empresa = rCfgPosto.Cd_empresa;
                fVenda.Nm_empresa = rCfgPosto.Nm_empresa;
                fVenda.Cd_tabelapreco = rCfgPosto.Cd_tabelapreco;
                if (fVenda.ShowDialog() == DialogResult.OK)
                    if (fVenda.rVenda != null)
                        try
                        {
                            CamadaNegocio.PostoCombustivel.TCN_VendaCombustivel.Gravar(fVenda.rVenda, null);
                            afterBusca();
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void IncluirNovaOS()
        {
            using (TFOrdemServico fOs = new TFOrdemServico())
            {
                if (fOs.ShowDialog() == DialogResult.OK)
                    if (fOs.rOs != null)
                        try
                        {
                            CamadaNegocio.PostoCombustivel.TCN_OrdemServico.Gravar(fOs.rOs, null);
                            MessageBox.Show("Ordem Serviço gravada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void FaturarOS()
        {
            using (TFFaturarOS fFat = new TFFaturarOS())
            {
                fFat.pCd_empresa = rCfgPosto.Cd_empresa;
                if (fFat.ShowDialog() == DialogResult.OK)
                    if (fFat.lItem.Count > 0)
                    {
                        Cd_clifor.Text = fFat.lItem[0].Cd_clifor;
                        NM_Clifor.Text = fFat.lItem[0].Nm_clifor;
                        NovaVenda(null, null, fFat.lItem, null);
                    }
            }
        }

        private void NovaVendaMesaConv()
        {
            using (TFVendaMesaConv fNova = new TFVendaMesaConv())
            {
                if (fNova.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string Id_venda = CamadaNegocio.PostoCombustivel.TCN_VendaMesaConv.Gravar(
                                            new CamadaDados.PostoCombustivel.TRegistro_VendaMesaConv()
                                            {
                                                Cd_empresa = string.IsNullOrEmpty(rCfgPosto.Cd_conveniencia) ? rCfgPosto.Cd_empresa : rCfgConv.Cd_empresa,
                                                Dt_venda = CamadaDados.UtilData.Data_Servidor(),
                                                Nm_cliente = fNova.Nm_cliente,
                                                St_registro = "A"
                                            }, null);
                        using (TFLanVendaMesaConv fVenda = new TFLanVendaMesaConv())
                        {
                            fVenda.Cd_empresa = string.IsNullOrEmpty(rCfgPosto.Cd_conveniencia) ? lCfg[0].Cd_empresa : rCfgConv.Cd_empresa;
                            fVenda.Nm_empresa = string.IsNullOrEmpty(rCfgPosto.Nm_conveniencia) ? lCfg[0].Nm_empresa : rCfgConv.Nm_empresa;
                            fVenda.Cd_local = string.IsNullOrEmpty(rCfgPosto.Cd_conveniencia) ? lCfg[0].Cd_local : rCfgConv.Cd_local;
                            fVenda.Cd_tabelapreco = string.IsNullOrEmpty(rCfgPosto.Cd_conveniencia) ? lCfg[0].Cd_tabelapreco : rCfgConv.Cd_tabelapreco;
                            fVenda.Nm_cliente = fNova.Nm_cliente;
                            fVenda.Id_venda = Id_venda;
                            fVenda.ShowDialog();
                            if (fVenda.St_finalizar)
                            {
                                if (string.IsNullOrEmpty(rCfgPosto.Cd_conveniencia))
                                {
                                    NovaVenda(null, null, null, CamadaNegocio.PostoCombustivel.TCN_ItensVendaMesaConv.Buscar(fVenda.Id_venda,
                                                                                                                                  fVenda.Cd_empresa,
                                                                                                                                  string.Empty,
                                                                                                                                  string.Empty,
                                                                                                                                  true,
                                                                                                                                  null));
                                    FinalizarVenda(true, string.Empty);
                                }
                                else if (rVenda != null)
                                {
                                    MessageBox.Show("Para faturar venda conveniencia obrigatorio antes finalizar venda aberta.", "Mensagem",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    return;
                                }
                                else
                                {
                                    //Gerar objeto venda rapida
                                    rVenda = new CamadaDados.Faturamento.PDV.TRegistro_VendaRapida();
                                    rVenda.Nm_clifor = NM_Clifor.Text;
                                    rVenda.Cd_empresa = rCfgConv.Cd_empresa;
                                    rVenda.Cd_vend = string.Empty;
                                    rVenda.Dt_emissao = CamadaDados.UtilData.Data_Servidor();
                                    rVenda.Id_pdvstr = lPdv[0].Id_pdvstr;
                                    rVenda.Id_sessaostr = lSessao[0].Id_sessaostr;
                                    rVenda.St_registro = "A";
                                    //Gerar itens da venda
                                    CamadaNegocio.PostoCombustivel.TCN_ItensVendaMesaConv.Buscar(fVenda.Id_venda,
                                                                                                 fVenda.Cd_empresa,
                                                                                                 string.Empty,
                                                                                                 string.Empty,
                                                                                                 true,
                                                                                                null).ForEach(p =>
                                                                                                    {
                                                                                                        rVenda.lItem.Add(new CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item()
                                                                                                        {
                                                                                                            //Criar item venda OS
                                                                                                            Cd_local = p.Cd_local,
                                                                                                            Cd_produto = p.Cd_produto,
                                                                                                            Ds_produto = p.Ds_produto,
                                                                                                            Sigla_unidade = p.Sigla_unidade,
                                                                                                            Cd_condfiscal_produto = p.Cd_condfiscal_produto,
                                                                                                            Cd_unidade = p.Cd_unidade,
                                                                                                            Quantidade = p.Quantidade,
                                                                                                            Vl_unitario = p.Vl_unitario,
                                                                                                            Vl_subtotal = p.Vl_subtotal,
                                                                                                            Vl_desconto = p.Vl_desconto,
                                                                                                            St_registro = "A",
                                                                                                            rItensVendaMesaConv = p
                                                                                                        });
                                                                                                    });
                                    FinalizarVenda(true, string.Empty);
                                }
                            }
                        }
                        //Buscar venda Mesa em Aberto
                        object obj = new CamadaDados.PostoCombustivel.TCD_VendaMesaConv().BuscarEscalar(
                                        new TpBusca[]
                                        {
                                            new TpBusca()
                                            {
                                                vNM_Campo = "a.cd_empresa",
                                                vOperador = "=",
                                                vVL_Busca = "'" + (string.IsNullOrEmpty(rCfgPosto.Cd_conveniencia) ? rCfgPosto.Cd_empresa : rCfgConv.Cd_empresa) + "'"
                                            },
                                            new TpBusca()
                                            {
                                                vNM_Campo = "isnull(a.st_registro, 'A')",
                                                vOperador = "=",
                                                vVL_Busca = "'A'"
                                            },
                                            new TpBusca()
                                            {
                                                vNM_Campo = "a.qtd_faturar",
                                                vOperador = ">",
                                                vVL_Busca = "0"
                                            }
                                        }, "count(*)");
                        lblConvEspera.Text = obj != null ? obj.ToString() : "0";
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        DialogResult = DialogResult.Cancel;
                    }

                }
                else
                    MessageBox.Show("Obrigatorio informar cliente para abrir venda.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void FaturarVendaMesaConv()
        {
            if (!string.IsNullOrEmpty(lblConvEspera.Text))
                if (decimal.Parse(lblConvEspera.Text) > decimal.Zero)
                    using (TFListaVendaMesaConv fLista = new TFListaVendaMesaConv())
                    {
                        fLista.Cd_empresa = string.IsNullOrEmpty(rCfgPosto.Cd_conveniencia) ? lCfg[0].Cd_empresa : rCfgConv.Cd_empresa;
                        fLista.Cd_local = string.IsNullOrEmpty(rCfgPosto.Cd_conveniencia) ? lCfg[0].Cd_local : rCfgConv.Cd_local;
                        fLista.Cd_tabelapreco = string.IsNullOrEmpty(rCfgPosto.Cd_conveniencia) ? lCfg[0].Cd_tabelapreco : rCfgConv.Cd_tabelapreco;
                        if (fLista.ShowDialog() == DialogResult.OK)
                            if (fLista.lItens.Count > 0)
                            {
                                Cd_clifor.Text = !string.IsNullOrEmpty(fLista.lItens[0].Cd_clifor) ? fLista.lItens[0].Cd_clifor : Cd_clifor.Text;
                                NM_Clifor.Text = !string.IsNullOrEmpty(fLista.lItens[0].Cd_clifor) ? fLista.lItens[0].Nm_cliente : NM_Clifor.Text;
                                BuscarEndereco();
                                CamadaDados.PostoCombustivel.TList_Convenio lConv = new CamadaDados.PostoCombustivel.TList_Convenio();
                                string condProd = string.Empty;
                                if (rVenda == null ? false : rVenda.lItem.Count > 0)
                                {//Montar lista de combustiveis
                                    string virg = string.Empty;
                                    List<string> lProd = new List<string>();
                                    rVenda.lItem.Where(p => p.rVendaCombustivel != null).ToList().ForEach(p =>
                                    {
                                        if (!lProd.Exists(v => v.Trim().Equals(p.Cd_produto.Trim())))
                                        {
                                            lProd.Add(p.Cd_produto.Trim());
                                            condProd += virg + "'" + p.Cd_produto.Trim() + "'";
                                            virg = ",";
                                        }
                                    });
                                    if(lProd.Count > 0)
                                        //Verificar se o cliente possui convenio
                                        lConv = new CamadaDados.PostoCombustivel.TCD_Convenio().Select(rVenda.Cd_empresa, Cd_clifor.Text, cd_endereco.Text, false, lProd);
                                }
                                if (string.IsNullOrEmpty(rCfgPosto.Cd_conveniencia))
                                {
                                    NovaVenda(null, null, null, fLista.lItens);
                                    if (lConv.Count > 0)
                                        FecharVendaConvenio(lConv, condProd);
                                    else FinalizarVenda(true, string.Empty);
                                }
                                else if (rVenda != null)
                                {
                                    MessageBox.Show("Para faturar venda conveniencia obrigatorio antes finalizar venda aberta.", "Mensagem",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    return;
                                }
                                else
                                {
                                    //Gerar objeto venda rapida
                                    rVenda = new CamadaDados.Faturamento.PDV.TRegistro_VendaRapida();
                                    rVenda.Cd_clifor = Cd_clifor.Text;
                                    rVenda.Nm_clifor = NM_Clifor.Text;
                                    rVenda.Cd_empresa = rCfgConv.Cd_empresa;
                                    rVenda.Cd_vend = string.Empty;
                                    rVenda.Dt_emissao = CamadaDados.UtilData.Data_Servidor();
                                    rVenda.Id_pdvstr = lPdv[0].Id_pdvstr;
                                    rVenda.Id_sessaostr = lSessao[0].Id_sessaostr;
                                    rVenda.St_registro = "A";
                                    //Gerar itens da venda
                                    fLista.lItens.ForEach(p =>
                                    {
                                        if (!rVenda.lItem.Exists(v => v.rItensVendaMesaConv == null ? false :
                                                                     v.rItensVendaMesaConv.Cd_empresa.Equals(p.Cd_empresa) &&
                                                                     v.rItensVendaMesaConv.Id_venda.Equals(p.Id_venda) &&
                                                                     v.rItensVendaMesaConv.Id_item.Equals(p.Id_item)))
                                        {
                                            rVenda.lItem.Add(new CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item()
                                            {
                                                //Criar item venda OS
                                                Cd_local = p.Cd_local,
                                                Cd_produto = p.Cd_produto,
                                                Ds_produto = p.Ds_produto,
                                                Sigla_unidade = p.Sigla_unidade,
                                                Cd_condfiscal_produto = p.Cd_condfiscal_produto,
                                                Cd_unidade = p.Cd_unidade,
                                                Quantidade = p.Quantidade,
                                                Vl_unitario = p.Vl_unitario,
                                                Vl_subtotal = p.Vl_subtotal,
                                                Vl_desconto = p.Vl_desconto,
                                                St_registro = "A",
                                                rItensVendaMesaConv = p
                                            });
                                        }
                                    });
                                    if (lConv.Count > 0)
                                        FecharVendaConvenio(lConv, condProd);
                                    else FinalizarVenda(true, string.Empty);
                                }

                            }
                    }
        }

        private void BuscarEndereco()
        {
            if (!string.IsNullOrEmpty(Cd_clifor.Text))
            {
                //buscar endereco clifor
                object obj = 
                    new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco().BuscarEscalar(
                                new TpBusca[]
                                {
                                     new TpBusca()
                                     {
                                         vNM_Campo = "a.cd_clifor",
                                         vOperador = "=",
                                         vVL_Busca = "'" + Cd_clifor.Text.Trim() + "'"
                                     }
                                }, "a.cd_endereco");
                if (obj != null)
                {
                    cd_endereco.Text = obj.ToString();
                    if (rVenda != null)
                        rVenda.Cd_endereco = cd_endereco.Text;
                }
            }
        }

        private void ImprimirCredAvulsoReduzido(List<string> texto)
        {
            FormRelPadrao.Relatorio Relatorio = new FormRelPadrao.Relatorio();
            Relatorio.Nome_Relatorio = "TFLanVendaRapida_CredAvulso";
            Relatorio.NM_Classe = "TFLanVendaRapida_CredAvulso";
            Relatorio.Modulo = "FAT";
            Relatorio.Ident = "TFLanVendaRapida_CredAvulso";
            Relatorio.Altera_Relatorio = Altera_Relatorio;

            BindingSource BinEmpresa = new BindingSource();
            BinEmpresa.DataSource = CamadaNegocio.Diversos.TCN_CadEmpresa.Busca(rCaixa.Cd_empresa,
                                                                                string.Empty,
                                                                                string.Empty,
                                                                                null);
            Relatorio.Adiciona_DataSource("EMPRESA", BinEmpresa);

            string text = string.Join(Environment.NewLine, texto.ToArray());
            Relatorio.Parametros_Relatorio.Add("TEXTO", text);


            //Verificar se existe Impressora padrão para o PDV
            object obj = new CamadaDados.Faturamento.Cadastros.TCD_PontoVenda().BuscarEscalar(
                                                new TpBusca[]
                                                {
                                                    new TpBusca()
                                                    {
                                                        vNM_Campo = "a.cd_terminal",
                                                        vOperador = "=",
                                                        vVL_Busca = "'" + Utils.Parametros.pubTerminal.Trim() + "'"
                                                    }
                                                }, "a.impressorapadrao");
            string print = string.Empty;
            print = obj == null ? string.Empty : obj.ToString();
            if (string.IsNullOrEmpty(print))
                using (Parametros.Diversos.TFListaImpressoras fLista = new Parametros.Diversos.TFListaImpressoras())
                {
                    if (fLista.ShowDialog() == DialogResult.OK)
                        if (!string.IsNullOrEmpty(fLista.Impressora))
                            print = fLista.Impressora;

                }
            //Imprimir
            Relatorio.ImprimiGraficoReduzida(print,
                                             true,
                                             false,
                                             null,
                                             string.Empty,
                                             string.Empty,
                                             1);
            Altera_Relatorio = false;
        }

        private void ImprimirCreditoConcedido(List<string> texto)
        {
            FormRelPadrao.Relatorio Relatorio = new FormRelPadrao.Relatorio();
            Relatorio.Nome_Relatorio = "TFLanVendaCombustivel_EmpConcedido";
            Relatorio.NM_Classe = "TFLanVendaCombustivel_EmpConcedido";
            Relatorio.Modulo = "PDV";
            Relatorio.Ident = "TFLanVendaCombustivel_EmpConcedido";
            Relatorio.Altera_Relatorio = Altera_Relatorio;

            BindingSource BinEmpresa = new BindingSource();
            BinEmpresa.DataSource = CamadaNegocio.Diversos.TCN_CadEmpresa.Busca(rCaixa.Cd_empresa,
                                                                                string.Empty,
                                                                                string.Empty,
                                                                                null);
            Relatorio.Adiciona_DataSource("EMPRESA", BinEmpresa);

            string text = string.Join(Environment.NewLine, texto.ToArray());
            Relatorio.Parametros_Relatorio.Add("TEXTO", text);


            //Verificar se existe Impressora padrão para o PDV
            object obj = new CamadaDados.Faturamento.Cadastros.TCD_PontoVenda().BuscarEscalar(
                                                new TpBusca[]
                                                {
                                                    new TpBusca()
                                                    {
                                                        vNM_Campo = "a.cd_terminal",
                                                        vOperador = "=",
                                                        vVL_Busca = "'" + Utils.Parametros.pubTerminal.Trim() + "'"
                                                    }
                                                }, "a.impressorapadrao");
            string print = string.Empty;
            print = obj == null ? string.Empty : obj.ToString();
            if (string.IsNullOrEmpty(print))
                using (Parametros.Diversos.TFListaImpressoras fLista = new Parametros.Diversos.TFListaImpressoras())
                {
                    if (fLista.ShowDialog() == DialogResult.OK)
                        if (!string.IsNullOrEmpty(fLista.Impressora))
                            print = fLista.Impressora;

                }
            //Imprimir
            Relatorio.ImprimiGraficoReduzida(print,
                                             true,
                                             false,
                                             null,
                                             string.Empty,
                                             string.Empty,
                                             2);
            Altera_Relatorio = false;
        }

        private void ImprimirDevCredito(List<string> texto)
        {
            FormRelPadrao.Relatorio Relatorio = new FormRelPadrao.Relatorio();
            Relatorio.Nome_Relatorio = "TFLanVendaCombustivel_EmpConcedido";
            Relatorio.NM_Classe = "TFLanVendaCombustivel_EmpConcedido";
            Relatorio.Modulo = "PDV";
            Relatorio.Ident = "TFLanVendaCombustivel_EmpConcedido";
            Relatorio.Altera_Relatorio = Altera_Relatorio;

            BindingSource BinEmpresa = new BindingSource();
            BinEmpresa.DataSource = CamadaNegocio.Diversos.TCN_CadEmpresa.Busca(rCaixa.Cd_empresa,
                                                                                string.Empty,
                                                                                string.Empty,
                                                                                null);
            Relatorio.Adiciona_DataSource("EMPRESA", BinEmpresa);

            string text = string.Join(Environment.NewLine, texto.ToArray());
            Relatorio.Parametros_Relatorio.Add("TEXTO", text);


            //Verificar se existe Impressora padrão para o PDV
            object obj = new CamadaDados.Faturamento.Cadastros.TCD_PontoVenda().BuscarEscalar(
                                                new TpBusca[]
                                                {
                                                    new TpBusca()
                                                    {
                                                        vNM_Campo = "a.cd_terminal",
                                                        vOperador = "=",
                                                        vVL_Busca = "'" + Utils.Parametros.pubTerminal.Trim() + "'"
                                                    }
                                                }, "a.impressorapadrao");
            string print = string.Empty;
            print = obj == null ? string.Empty : obj.ToString();
            if (string.IsNullOrEmpty(print))
                using (Parametros.Diversos.TFListaImpressoras fLista = new Parametros.Diversos.TFListaImpressoras())
                {
                    if (fLista.ShowDialog() == DialogResult.OK)
                        if (!string.IsNullOrEmpty(fLista.Impressora))
                            print = fLista.Impressora;

                }
            //Imprimir
            Relatorio.ImprimiGraficoReduzida(print,
                                             true,
                                             false,
                                             null,
                                             string.Empty,
                                             string.Empty,
                                             1);
            Altera_Relatorio = false;
        }

        private void ImprimirTrocaEspecie(List<string> texto)
        {
            FormRelPadrao.Relatorio Relatorio = new FormRelPadrao.Relatorio();
            Relatorio.Nome_Relatorio = "TFLanVendaPostoCombustivel_TrocaEspecie";
            Relatorio.NM_Classe = "TFLanVendaPostoCombustivel_TrocaEspecie";
            Relatorio.Modulo = "PDV";
            Relatorio.Ident = "TFLanVendaPostoCombustivel_TrocaEspecie";
            Relatorio.Altera_Relatorio = Altera_Relatorio;

            BindingSource BinEmpresa = new BindingSource();
            BinEmpresa.DataSource = CamadaNegocio.Diversos.TCN_CadEmpresa.Busca(rCaixa.Cd_empresa,
                                                                                string.Empty,
                                                                                string.Empty,
                                                                                null);
            Relatorio.Adiciona_DataSource("EMPRESA", BinEmpresa);

            string text = string.Join(Environment.NewLine, texto.ToArray());
            Relatorio.Parametros_Relatorio.Add("TEXTO", text);

            //Verificar se existe Impressora padrão para o PDV
            object obj = new CamadaDados.Faturamento.Cadastros.TCD_PontoVenda().BuscarEscalar(
                                                new TpBusca[]
                                                {
                                                    new TpBusca()
                                                    {
                                                        vNM_Campo = "a.cd_terminal",
                                                        vOperador = "=",
                                                        vVL_Busca = "'" + Utils.Parametros.pubTerminal.Trim() + "'"
                                                    }
                                                }, "a.impressorapadrao");
            string print = string.Empty;
            print = obj == null ? string.Empty : obj.ToString();
            if (string.IsNullOrEmpty(print))
                using (Parametros.Diversos.TFListaImpressoras fLista = new Parametros.Diversos.TFListaImpressoras())
                {
                    if (fLista.ShowDialog() == DialogResult.OK)
                        if (!string.IsNullOrEmpty(fLista.Impressora))
                            print = fLista.Impressora;

                }
            //Imprimir
            Relatorio.ImprimiGraficoReduzida(print,
                                             true,
                                             false,
                                             null,
                                             string.Empty,
                                             string.Empty,
                                             1);
            Altera_Relatorio = false;
        }

        private void ImprimirConfissaoDivida()
        {
            CamadaDados.Financeiro.Duplicata.TList_RegLanParcela lParc =
            new CamadaDados.Financeiro.Duplicata.TCD_LanParcela().Select(
                new TpBusca[]
                {
                    new TpBusca { vNM_Campo = "isnull(dup.st_registro, 'A')", vOperador = "<>", vVL_Busca = "'C'" },
                    new TpBusca
                    {
                        vNM_Campo = string.Empty,
                        vOperador = "exists",
                        vVL_Busca = "(select 1 from tb_pdv_cupomfiscal_x_duplicata x " +
                                    "where x.cd_empresa = a.cd_empresa " +
                                    "and x.nr_lancto = a.nr_lancto " +
                                    "and x.cd_empresa = '" + rVenda.Cd_empresa.Trim() + "' " +
                                    "and x.id_cupom = " + rVenda.Id_vendarapidastr + ")"
                    }
                }, 0, string.Empty, string.Empty, string.Empty);
            if (lParc.Count > 0)
            {
                FormRelPadrao.Relatorio Rel = new FormRelPadrao.Relatorio();
                BindingSource bin = new BindingSource();
                bin.DataSource = rVenda;
                Rel.DTS_Relatorio = bin;
                //DTS Cupom
                BindingSource dts = new BindingSource();
                dts.DataSource = rVenda.lItem;
                Rel.Adiciona_DataSource("DTS_ITENS", dts);
                //Buscar Empresa
                BindingSource bsEmpresa = new BindingSource();
                bsEmpresa.DataSource = CamadaNegocio.Diversos.TCN_CadEmpresa.Busca(rVenda.Cd_empresa, string.Empty, string.Empty, null);
                Rel.Adiciona_DataSource("DTS_EMP", bsEmpresa);
                Rel.Parametros_Relatorio.Add("NM_CLIENTE", lParc[0].Nm_clifor);
                Rel.Parametros_Relatorio.Add("CPF_CLIENTE", lParc[0].Cnpj_cpf);
                BindingSource bsend = new BindingSource();
                bsend.DataSource =
                    CamadaNegocio.Financeiro.Cadastros.TCN_CadEndereco.Buscar(lParc[0].Cd_clifor,
                                                                                lParc[0].Cd_endereco,
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
                                                                                null);

                Rel.Adiciona_DataSource("END", bsend);
                Rel.Parametros_Relatorio.Add("ENDERECO", (bsend.Current as CamadaDados.Financeiro.Cadastros.TRegistro_CadEndereco).Ds_endereco.Trim() + ", " + 
                                                         (bsend.Current as CamadaDados.Financeiro.Cadastros.TRegistro_CadEndereco).Numero.Trim() + ", " + 
                                                         (bsend.Current as CamadaDados.Financeiro.Cadastros.TRegistro_CadEndereco).Bairro.Trim() + ", " +
                                                         (bsend.Current as CamadaDados.Financeiro.Cadastros.TRegistro_CadEndereco).DS_Cidade.Trim() + ", " +
                                                         (bsend.Current as CamadaDados.Financeiro.Cadastros.TRegistro_CadEndereco).UF.Trim());
                string dadosdi = CamadaNegocio.Faturamento.PDV.TCN_VendaRapida.BuscarPlacaKM(rVenda.Cd_empresa,
                                                                                             rVenda.Id_vendarapidastr,
                                                                                             null);
                if (!string.IsNullOrEmpty(dadosdi))
                {
                    string[] linhas = dadosdi.Split(new char[] { ':' });
                    string placa = string.Empty;
                    string km = string.Empty;
                    string frota = string.Empty;
                    string requisicao = string.Empty;
                    string nm_motorista = string.Empty;
                    string cpf_motorista = string.Empty;
                    string media = string.Empty;
                    string virg = string.Empty;
                    foreach (string s in linhas)
                    {
                        string[] colunas = s.Split(new char[] { '/' });
                        if (colunas.Length > 0)
                        {
                            placa += virg + colunas[0];
                            if (colunas.Length > 1)
                                km += virg + colunas[1];
                            if (colunas.Length > 2)
                                frota += virg + colunas[2];
                            if (colunas.Length > 3)
                                requisicao += virg + colunas[3];
                            if (colunas.Length > 4)
                                nm_motorista += virg + colunas[4];
                            if (colunas.Length > 5)
                                cpf_motorista += virg + colunas[5];
                            if (colunas.Length > 6)
                                media += virg + colunas[6];
                            virg = ",";
                        }
                    }
                    if (!string.IsNullOrEmpty(placa))
                        Rel.Parametros_Relatorio.Add("PLACA", placa);
                    if (!string.IsNullOrEmpty(km))
                        Rel.Parametros_Relatorio.Add("KM", km);
                    if (!string.IsNullOrEmpty(media))
                        Rel.Parametros_Relatorio.Add("MEDIA", media + " KM/LT");
                    if (!string.IsNullOrEmpty(frota))
                        Rel.Parametros_Relatorio.Add("FROTA", frota);
                    if (!string.IsNullOrEmpty(requisicao))
                        Rel.Parametros_Relatorio.Add("REQUISICAO", requisicao);
                    if (!string.IsNullOrEmpty(nm_motorista))
                        Rel.Parametros_Relatorio.Add("MOTORISTA", nm_motorista);
                    if (!string.IsNullOrEmpty(cpf_motorista))
                        Rel.Parametros_Relatorio.Add("CPF_MOTORISTA", cpf_motorista);
                }
                //Buscar Valor Pago
                decimal vl_pago = decimal.Zero;
                List<CamadaDados.Faturamento.PDV.TRegistro_MovCaixa> lPagto =
                    new CamadaDados.Faturamento.PDV.TCD_CaixaPDV().SelectMovCaixa(
                        new TpBusca[]
                        {
                            new TpBusca { vNM_Campo = "a.cd_empresa", vOperador = "=", vVL_Busca = "'" + rVenda.Cd_empresa.Trim() + "'"},
                            new TpBusca {vNM_Campo = "a.id_cupom", vOperador = "=", vVL_Busca = rVenda.Id_vendarapidastr }
                        }, string.Empty);

                if (lPagto.Count > 0)
                    vl_pago = lPagto.Sum(p => p.Vl_recebidoliq);
                vl_pago += lParc.Sum(p => p.Vl_liquidado);
                Rel.Parametros_Relatorio.Add("VL_PAGO", vl_pago);
                Rel.Parametros_Relatorio.Add("VL_PAGAR", lParc.Sum(p => p.Vl_atual));
                //Buscar documento fiscal
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("select a.nr_nfce, a.dt_emissao, a.chave_acesso, '0' as tp_docto ");
                sql.AppendLine("from tb_pdv_nfce a ");
                sql.AppendLine("where isnull(a.st_registro, 'A') <> 'C' ");
                sql.AppendLine("and exists(select 1 from tb_pdv_cupom_x_vendarapida x ");
                sql.AppendLine("            where x.cd_empresa = a.cd_empresa ");
                sql.AppendLine("            and x.id_cupom = a.id_nfce ");
                sql.AppendLine("            and x.cd_empresa = '" + rVenda.Cd_empresa.Trim() + "'");
                sql.AppendLine("            and x.id_vendarapida = " + rVenda.Id_vendarapidastr + ")");
                sql.AppendLine("union all ");
                sql.AppendLine("select a.nr_notafiscal, a.dt_emissao, a.chave_acesso_nfe, '1' as tp_docto ");
                sql.AppendLine("from tb_fat_notafiscal a ");
                sql.AppendLine("where isnull(a.st_registro, 'A') <> 'C' ");
                sql.AppendLine("and exists(select 1 from tb_pdv_pedido_x_vendarapida x ");
                sql.AppendLine("            inner join tb_fat_notafiscal_item y ");
                sql.AppendLine("            on x.nr_pedido = y.nr_pedido ");
                sql.AppendLine("            and x.cd_produto = y.cd_produto ");
                sql.AppendLine("            and x.id_pedidoitem = y.id_pedidoitem ");
                sql.AppendLine("            where y.cd_empresa = a.cd_empresa ");
                sql.AppendLine("            and y.nr_lanctofiscal = a.nr_lanctofiscal ");
                sql.AppendLine("            and x.cd_empresa = '" + rVenda.Cd_empresa.Trim() + "'");
                sql.AppendLine("            and x.id_vendarapida = " + rVenda.Id_vendarapidastr + ")");
                DataTable tb = new CamadaDados.TDataQuery().ExecutarBusca(sql.ToString(), null);
                if(tb.Rows.Count > 0)
                {
                    Rel.Parametros_Relatorio.Add("NR_DOCUMENTO", tb.Rows[0][0].ToString());
                    Rel.Parametros_Relatorio.Add("DT_EMISSAO", tb.Rows[0][1].ToString());
                    Rel.Parametros_Relatorio.Add("CHAVE_ACESSO", tb.Rows[0][2].ToString());
                    Rel.Parametros_Relatorio.Add("TP_DOCUMENTO", tb.Rows[0][3].ToString());//1-NF-e;0-NFC-e
                }
                else
                {
                    Rel.Parametros_Relatorio.Add("NR_DOCUMENTO", rVenda.Id_vendarapidastr);
                    Rel.Parametros_Relatorio.Add("DT_EMISSAO", rVenda.Dt_emissaostr);
                    Rel.Parametros_Relatorio.Add("CHAVE_ACESSO", string.Empty);
                    Rel.Parametros_Relatorio.Add("TP_DOCUMENTO", "2");//1-NF-e;0-NFC-e
                }
                Rel.Nome_Relatorio = "CONFISSAO_DIVIDA";
                Rel.NM_Classe = "TFConsultaFrenteCaixa";
                Rel.Modulo = "FAT";
                Rel.Ident = "CONFISSAO_DIVIDA";
                //Verificar se existe Impressora padrão para o PDV
                object obj = new CamadaDados.Faturamento.Cadastros.TCD_PontoVenda().BuscarEscalar(
                                new TpBusca[]
                                {
                                            new TpBusca()
                                            {
                                                vNM_Campo = "a.cd_terminal",
                                                vOperador = "=",
                                                vVL_Busca = "'" + Utils.Parametros.pubTerminal.Trim() + "'"
                                            }
                                }, "a.impressorapadrao");
                string print = obj == null ? string.Empty : obj.ToString();
                if (string.IsNullOrEmpty(print))
                    using (Parametros.Diversos.TFListaImpressoras fLista = new Parametros.Diversos.TFListaImpressoras())
                    {
                        if (fLista.ShowDialog() == DialogResult.OK)
                            if (!string.IsNullOrEmpty(fLista.Impressora))
                                print = fLista.Impressora;

                    }
                Rel.ImprimiGraficoReduzida(print,
                                           true,
                                           false,
                                           null,
                                           string.Empty,
                                           string.Empty,
                                           1);
            }
        }

        #endregion

        private void TFLanVendaCombustivel_Load(object sender, EventArgs e)
        {
            ShapeGrid.RestoreShape(this, gAbastecimento);
            Icon = ResourcesUtils.TecnoAliance_ICO;
            lblCxLivre.Height = gCupom.Height;
            lblCxLivre.Width = gCupom.Width;
            pCabecalho.set_FormatZero();
            gCupom.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            gCupom.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            gCupom.Dock = DockStyle.Fill;
            miNovoCliente.Enabled = LoginPdv.Trim().ToUpper().Equals("MASTER") ||
                                    LoginPdv.Trim().ToUpper().Equals("DESENV") ||
                                    new CamadaDados.Diversos.TCD_CadAcesso().BuscarEscalar(
                                        new TpBusca[]
                                        {
                                            new TpBusca()
                                            {
                                                vNM_Campo = "a.ID_Menu",
                                                vOperador = "=",
                                                vVL_Busca = "'055600'"
                                            },
                                            new TpBusca()
                                            {
                                                vNM_Campo = string.Empty,
                                                vOperador = string.Empty,
                                                vVL_Busca = "(a.login = '" + LoginPdv.Trim() + "' or " +
                                                            "exists(select 1 from TB_DIV_Usuario_X_Grupos x " +
                                                            "       where x.loginGrp = a.login " +
                                                            "       and x.loginUsr = '" + LoginPdv.Trim() + "'))"
                                            }
                                        }, "1") != null;
            //Buscar Codigo Vendedor amarrado ao login
            object obj_vendedor =
            new CamadaDados.Financeiro.Cadastros.TCD_CadClifor().BuscarEscalar(
                new TpBusca[]
                {
                    new TpBusca()
                    {
                        vNM_Campo = "a.loginvendedor",
                        vOperador = "=",
                        vVL_Busca = "'" + LoginPdv.Trim() + "'"
                    }
                }, "a.cd_clifor");
            if (obj_vendedor != null)
                Cd_operador = obj_vendedor.ToString();
            else
            {
                MessageBox.Show("Não existe Operador de Caixa cadastrado para o Usuário informado: " + LoginPdv.Trim(),
                                "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
                return;
            }
            //Mostrar botao NFe
            miConsultaNfe.Visible = CamadaNegocio.Diversos.TCN_Usuario_RegraEspecial.ValidaRegra(LoginPdv, "PERMITIR PROCESSAR NFE", null);
            miCreditoAvulso.Visible = CamadaNegocio.Diversos.TCN_Usuario_RegraEspecial.ValidaRegra(LoginPdv, "PERMITIR LANÇAR CREDITO AVULSO", null);
            //Buscar dados PDV
            lPdv = CamadaNegocio.Faturamento.Cadastros.TCN_PontoVenda.Buscar(string.Empty,
                                                                             string.Empty,
                                                                             Utils.Parametros.pubTerminal,
                                                                             string.Empty,
                                                                             null);
            if (lPdv.Count < 1)
            {
                MessageBox.Show("Não existe PDV cadastrado para o terminal " + Utils.Parametros.pubTerminal,
                                "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
                return;
            }
            //Verificar se PDV esta em contingencia NFC-e
            if (new CamadaDados.Faturamento.PDV.TCD_ContingenciaNFCeOFF().BuscarEscalar(
                new TpBusca[]
                {
                    new TpBusca()
                    {
                        vNM_Campo = "a.id_pdv",
                        vOperador = "=",
                        vVL_Busca = lPdv[0].Id_pdvstr
                    },
                    new TpBusca()
                    {
                        vNM_Campo = "a.cd_empresa",
                        vOperador = "=",
                        vVL_Busca = "'" + lPdv[0].Cd_empresa.Trim() + "'"
                    },
                    new TpBusca()
                    {
                        vNM_Campo = "isnull(a.st_registro, 'A')",
                        vOperador = "=",
                        vVL_Busca = "'A'"
                    }
                }, "1") != null)
                lblContingencia.ImageIndex = 3;
            //Buscar sessao aberta
            lSessao = CamadaNegocio.Faturamento.PDV.TCN_Sessao.Buscar(lPdv[0].Id_pdvstr,
                                                                      string.Empty,
                                                                      LoginPdv,
                                                                      string.Empty,
                                                                      string.Empty,
                                                                      string.Empty,
                                                                      "'A'",
                                                                      1,
                                                                      null);
            if (lSessao.Count < 1)
            {
                MessageBox.Show("Não existe sessão aberta para o PDV " + lPdv[0].Id_pdvstr + " Login " + LoginPdv,
                                "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
                return;
            }
            //Buscar Config Cupom
            lCfg = CamadaNegocio.Faturamento.Cadastros.TCN_CFGCupomFiscal.Buscar(lPdv[0].Cd_empresa, null);
            if (lCfg.Count < 1)
            {
                MessageBox.Show("Não existe configuração para emitir venda combustivel na empresa " + lPdv[0].Cd_empresa.Trim(),
                                "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
                return;
            }
            //Configurar busca produto somente por codigo interno ou de barras
            cd_produto.ST_Int = lCfg[0].St_produtocodigobool;
            //Buscar config posto
            CamadaDados.PostoCombustivel.Cadastros.TList_CfgPosto lCfgPosto =
                    CamadaNegocio.PostoCombustivel.Cadastros.TCN_CfgPosto.Buscar(lPdv[0].Cd_empresa, null);
            if (lCfgPosto.Count > 0)
            {
                rCfgPosto = lCfgPosto[0];
                vendaConveniênciaToolStripMenuItem.Enabled = !string.IsNullOrEmpty(rCfgPosto.Cd_conveniencia) &&
                    rCfgPosto.Cd_conveniencia != rCfgPosto.Cd_empresa;
            }
            else
            {
                MessageBox.Show("Não existe configuração posto combustivel para a empresa " + lPdv[0].Cd_empresa.Trim(),
                                "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
                return;
            }
            //Buscar config conveniencia
            if (!string.IsNullOrEmpty(rCfgPosto.Cd_conveniencia))
            {
                CamadaDados.Faturamento.Cadastros.TList_CFGCupomFiscal lCfgConv =
                    CamadaNegocio.Faturamento.Cadastros.TCN_CFGCupomFiscal.Buscar(rCfgPosto.Cd_conveniencia, null);
                if (lCfgConv.Count > 0)
                    rCfgConv = lCfgConv[0];
                else
                {
                    MessageBox.Show("Não existe configuração para emitir venda conveniencia para a empresa " + rCfgPosto.Cd_conveniencia.Trim() + ".",
                                    "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                    return;
                }
            }
            lblUsuario.Text = LoginPdv.Trim();
            lblPdv.Text = lPdv[0].Id_pdvstr + "-" + lPdv[0].Ds_pdv;
            lblEmpresa.Text = rCfgPosto.Cd_empresa.Trim() + "-" + rCfgPosto.Nm_empresa.Trim();
            Cd_clifor.Text = lCfg[0].Cd_clifor;
            NM_Clifor.Text = lCfg[0].Nm_clifor;
            Cd_clifor.BackColor = Color.White;
            cd_endereco.Text = lCfg[0].Cd_endereco;
            if ((!rCfgPosto.Tp_concentrador.Trim().ToUpper().Equals("SA")) &&
                (rCfgPosto.Cd_terminal.Trim().Equals(lPdv[0].Cd_terminal.Trim())))
            //Abrir porta concentrador
            {
                if (!string.IsNullOrEmpty(rCfgPosto.Host_ip))
                {
                    tcpClient = new System.Net.Sockets.TcpClient();                    
                    tcpClient.Connect(rCfgPosto.Host_ip, Convert.ToInt32(rCfgPosto.Porta_ip));
                    if (tcpClient.Connected)
                    {
                        tcpClient.ReceiveTimeout = 1000;
                        tcpClient.SendTimeout = 1000;
                        socketStream = tcpClient.GetStream();
                        escreve = new System.IO.BinaryWriter(socketStream);
                        le = new System.IO.BinaryReader(socketStream);
                        lblConcentrador.ImageIndex = 3;
                        tmpAbastAtual.Interval = rCfgPosto.Tmp_abastecimento > decimal.Zero ? Convert.ToInt32(rCfgPosto.Tmp_abastecimento) : 5000;
                        tmpOnLine.Interval = rCfgPosto.Tmp_abastonline > decimal.Zero ? Convert.ToInt32(rCfgPosto.Tmp_abastonline) : 3000;
                        //Ler Abastecimentos OnLine
                        if (rCfgPosto.Tp_concentrador.Trim().ToUpper() != "VW")
                            tmpOnLine.Start();
                        else tmpOnLine.Stop();
                        //Ler Abastecimento encerrados
                        tmpAbastAtual.Start();
                        //Montar layout bico
                        if (rCfgPosto.Tp_concentrador.Trim().ToUpper() != "VW")
                            MontarLayoutbico();
                    }
                    else
                    {
                        lblConcentrador.ImageIndex = 1;
                        tmpAtualizaTela.Interval = rCfgPosto.Tmp_abastecimento > decimal.Zero ? Convert.ToInt32(rCfgPosto.Tmp_abastecimento) : 5000;
                        tmpAtualizaTela.Start();
                        //Montar layout bico
                        MontarLayoutbico();
                    }
                }
                else if (TAutomacao.AbrirPorta(rCfgPosto.Tp_concentrador, rCfgPosto.Porta_comunicacao))
                {
                    lblConcentrador.ImageIndex = 3;
                    tmpAbastAtual.Interval = rCfgPosto.Tmp_abastecimento > decimal.Zero ? Convert.ToInt32(rCfgPosto.Tmp_abastecimento) : 5000;
                    tmpOnLine.Interval = rCfgPosto.Tmp_abastonline > decimal.Zero ? Convert.ToInt32(rCfgPosto.Tmp_abastonline) : 3000;
                    //Ler Abastecimentos OnLine
                    if (rCfgPosto.Tp_concentrador.Trim().ToUpper() != "VW")
                        tmpOnLine.Start();
                    //Ler Abastecimento encerrados
                    tmpAbastAtual.Start();
                    //Montar layout bico
                    if (rCfgPosto.Tp_concentrador.Trim().ToUpper() != "VW")
                        MontarLayoutbico();
                }
                else
                {
                    lblConcentrador.ImageIndex = 1;
                    tmpAtualizaTela.Interval = rCfgPosto.Tmp_abastecimento > decimal.Zero ? Convert.ToInt32(rCfgPosto.Tmp_abastecimento) : 5000;
                    tmpAtualizaTela.Start();
                    //Montar layout bico
                    MontarLayoutbico();
                }
            }
            else
            {
                lblConcentrador.ImageIndex = 0;
                tmpAtualizaTela.Interval = rCfgPosto.Tmp_abastecimento > decimal.Zero ? Convert.ToInt32(rCfgPosto.Tmp_abastecimento) : 5000; ;
                tmpAtualizaTela.Start();
            }
            miAlteraPreco.Enabled = (!rCfgPosto.Tp_concentrador.Trim().ToUpper().Equals("SA")) && rCfgPosto.Cd_terminal.Trim().Equals(lPdv[0].Cd_terminal.Trim());
            miLerEncerrante.Enabled = (!rCfgPosto.Tp_concentrador.Trim().ToUpper().Equals("SA")) && rCfgPosto.Cd_terminal.Trim().Equals(lPdv[0].Cd_terminal.Trim());
            bb_abastmanual.Visible = CamadaNegocio.Diversos.TCN_Usuario_RegraEspecial.ValidaRegra(LoginPdv, "PERMITIR INCLUIR ABASTECIMENTO MANUAL", null);
            //Buscar total abastecimentos em espera
            tslVendaEspera.Text = new CamadaDados.PostoCombustivel.TCD_VendaCombustivel().BuscarEscalar(
                                            new TpBusca[]
                                            {
                                                new TpBusca()
                                                {
                                                    vNM_Campo = "a.cd_empresa",
                                                    vOperador = "=",
                                                    vVL_Busca = "'" + rCfgPosto.Cd_empresa.Trim() + "'"
                                                },
                                                new TpBusca()
                                                {
                                                    vNM_Campo = "isnull(a.st_registro, 'A')",
                                                    vOperador = "=",
                                                    vVL_Busca = "'E'"
                                                },
                                                new TpBusca()
                                                {
                                                    vNM_Campo = "a.loginespera",
                                                    vOperador = "=",
                                                    vVL_Busca = "'" + lSessao[0].Login.Trim() + "'"
                                                }
                                            }, "isnull(count(a.id_venda), 0)").ToString();
            //Buscar total venda conveniencia em espera
            object obj = new CamadaDados.PostoCombustivel.TCD_VendaMesaConv().BuscarEscalar(
                                                new TpBusca[]
                                                {
                                                    new TpBusca()
                                                    {
                                                        vNM_Campo = "a.cd_empresa",
                                                        vOperador = "=",
                                                        vVL_Busca = "'" + (string.IsNullOrEmpty(rCfgPosto.Cd_conveniencia) ? rCfgPosto.Cd_empresa : rCfgConv.Cd_empresa) + "'"
                                                    },
                                                    new TpBusca()
                                                    {
                                                        vNM_Campo = "isnull(a.st_registro, 'A')",
                                                        vOperador = "=",
                                                        vVL_Busca = "'A'"
                                                    },
                                                    new TpBusca()
                                                    {
                                                        vNM_Campo = "a.qtd_faturar",
                                                        vOperador = ">",
                                                        vVL_Busca = "0"
                                                    }
                                                }, "count(*)");
            lblConvEspera.Text = obj != null ? obj.ToString() : "0";
            //Buscar abastecimento com status faturado e sem id_cupom
            new CamadaDados.PostoCombustivel.TCD_VendaCombustivel().Select(
                new TpBusca[]
                {
                    new TpBusca()
                    {
                        vNM_Campo = "a.cd_empresa",
                        vOperador = "=",
                        vVL_Busca = "'" + rCfgPosto.Cd_empresa.Trim() + "'"
                    },
                    new TpBusca()
                    {
                        vNM_Campo = "a.id_cupom",
                        vOperador = "is",
                        vVL_Busca = "null"
                    },
                    new TpBusca()
                    {
                        vNM_Campo = "isnull(a.st_registro, 'A')",
                        vOperador = "=",
                        vVL_Busca = "'F'"
                    },
                    new TpBusca()
                    {
                        vNM_Campo = "isnull(a.st_afericao, 'N')",
                        vOperador = "<>",
                        vVL_Busca = "'S'"
                    }
                }, 0, string.Empty, string.Empty).ForEach(p =>
                {
                    p.St_registro = "A";
                    CamadaNegocio.PostoCombustivel.TCN_VendaCombustivel.Gravar(p, null);
                });

            //Buscar abastecimentos em aberto
            afterBusca();
            //Ler encerrantes dos bicos
            if ((!rCfgPosto.Tp_concentrador.Trim().ToUpper().Equals("SA")) &&
                rCfgPosto.Cd_terminal.Trim().Equals(lPdv[0].Cd_terminal.Trim()) &&
                rCfgPosto.Tp_modoencerrante.Trim().ToUpper().Equals("C"))
            {
                //Verificar se tem configuracao de tipo de encerrante para a empresa
                obj = new CamadaDados.PostoCombustivel.Cadastros.TCD_CfgPosto().BuscarEscalar(
                                new TpBusca[]
                                {
                                    new TpBusca()
                                    {
                                        vNM_Campo = "a.cd_empresa",
                                        vOperador = "=",
                                        vVL_Busca = "'" + rCfgPosto.Cd_empresa.Trim() + "'"
                                    }
                                }, "isnull(a.tp_leituraencerrantebico, 'A')");
                string tp_encerrante = obj == null ? "A" : obj.ToString();
                //Funciona somente para abertura
                if (tp_encerrante.Trim().ToUpper().Equals("A"))
                {
                    #region Encerrante Bico
                    //Buscar lista de bicos da empresa que nao tem encerrante gravado
                    CamadaDados.PostoCombustivel.Cadastros.TList_BicoBomba lBico =
                        new CamadaDados.PostoCombustivel.Cadastros.TCD_BicoBomba().Select(
                        new TpBusca[]
                    {
                        new TpBusca()
                        {
                            vNM_Campo = "a.cd_empresa",
                            vOperador = "=",
                            vVL_Busca = "'" + rCfgPosto.Cd_empresa.Trim() + "'"
                        },
                        new TpBusca()
                        {
                            vNM_Campo = "isnull(a.st_registro, 'A')",
                            vOperador = "<>",
                            vVL_Busca = "'C'"
                        },
                        new TpBusca()
                        {
                            vNM_Campo = string.Empty,
                            vOperador = "not exists",
                            vVL_Busca = "(select 1 from tb_pdc_encerrantebico x "+
                                        "where x.id_bico = a.id_bico "+
                                        "and x.tp_encerrante = 'A' " +
                                        "and convert(datetime, floor(convert(decimal(30,10), x.dt_encerrante))) = '" + CamadaDados.UtilData.Data_Servidor().ToString("yyyyMMdd") + "')"
                        }
                    }, 0, string.Empty);
                    if (lBico.Count > 0)
                    {
                        try
                        {
                            //Ler Encerrante Bico
                            lBico.ForEach(p =>
                            {
                                if (tcpClient == null)
                                    p.Qtd_encerrante = TAutomacao.LerEncerranteBico(rCfgPosto.Tp_concentrador, p.Enderecofisicobico, "L");
                                else
                                {
                                    string comando = "&T" + p.Enderecofisicobico.Trim() + "L";
                                    comando = "(" + comando + TCompanytec.CalcularChecksum(comando) + ")";
                                    string ret = SendLan(comando);
                                    if (!string.IsNullOrEmpty(ret))
                                        if (ret.Trim().Length.Equals(16))
                                            p.Qtd_encerrante = decimal.Parse(comando.Substring(5, 8)) / 100;
                                }
                                //Buscar venda combustivel no dia
                                object obj_volume =
                                new CamadaDados.PostoCombustivel.TCD_VendaCombustivel().BuscarEscalar(
                                    new TpBusca[]
                                        {
                                            new TpBusca()
                                            {
                                                vNM_Campo = "a.cd_empresa",
                                                vOperador = "=",
                                                vVL_Busca = "'" + rCfgPosto.Cd_empresa.Trim() + "'"
                                            },
                                            new TpBusca()
                                            {
                                                vNM_Campo = "a.id_bico",
                                                vOperador = "=",
                                                vVL_Busca = p.Id_bicostr
                                            },
                                            new TpBusca()
                                            {
                                                vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.dt_abastecimento)))",
                                                vOperador = "=",
                                                vVL_Busca = "'" + CamadaDados.UtilData.Data_Servidor().ToString("yyyyMMdd") + "'"
                                            }
                                        }, "isnull(sum(isnull(a.volumeabastecido, 0)), 0)");

                                //Gravar Encerrante
                                CamadaNegocio.PostoCombustivel.TCN_EncerranteBico.Gravar(
                                    new CamadaDados.PostoCombustivel.TRegistro_EncerranteBico()
                                    {
                                        Id_bico = p.Id_bico,
                                        Dt_encerrante = CamadaDados.UtilData.Data_Servidor(),
                                        Tp_encerrante = tp_encerrante,
                                        Qtd_encerrante = p.Qtd_encerrante - decimal.Parse(obj_volume.ToString())
                                    }, null);
                            });
                        }
                        catch
                        {
                            MessageBox.Show("Erro gravar encerrantes do bicos.\r\n" +
                                            "Acesse a tela de leitura de encerrantes para gravar os valores.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    #endregion

                    #region Medicao Tanque
                    //Buscar lista de tanques que nao tem afericao
                    new CamadaDados.PostoCombustivel.Cadastros.TCD_TanqueCombustivel().Select(
                    new TpBusca[]
                    {
                        new TpBusca()
                        {
                            vNM_Campo = "a.cd_empresa",
                            vOperador = "=",
                            vVL_Busca = "'" + rCfgPosto.Cd_empresa.Trim() + "'"
                        },
                        new TpBusca()
                        {
                            vNM_Campo = "isnull(a.st_registro, 'A')",
                            vOperador = "<>",
                            vVL_Busca = "'C'"
                        },
                        new TpBusca()
                        {
                            vNM_Campo = string.Empty,
                            vOperador = "not exists",
                            vVL_Busca = "(select 1 from tb_pdc_medicaotanque x "+
                                        "where x.cd_empresa = a.cd_empresa "+
                                        "and x.id_tanque = a.id_tanque "+
                                        "and x.tp_medicao = 'A' " +
                                        "and convert(datetime, floor(convert(decimal(30,10), x.dt_medicao))) = '" +
                                        CamadaDados.UtilData.Data_Servidor().ToString("yyyyMMdd") + "')"
                        }
                    }, 0, string.Empty).ForEach(p =>
                    {
                        //Buscar Ultima medicao
                        object obj_medicao = new CamadaDados.PostoCombustivel.TCD_MedicaoTanque().BuscarEscalar(
                                                new TpBusca[]
                                                    {
                                                        new TpBusca()
                                                        {
                                                            vNM_Campo = "a.cd_empresa",
                                                            vOperador = "=",
                                                            vVL_Busca = "'" + p.Cd_empresa.Trim() + "'"
                                                        },
                                                        new TpBusca()
                                                        {
                                                            vNM_Campo = "a.id_tanque",
                                                            vOperador = "=",
                                                            vVL_Busca = p.Id_tanquestr
                                                        },
                                                        new TpBusca()
                                                        {
                                                            vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.dt_medicao)))",
                                                            vOperador = "=",
                                                            vVL_Busca = "'" + CamadaDados.UtilData.Data_Servidor().AddDays(-1).ToString("yyyyMMdd") + "'"
                                                        },
                                                        new TpBusca()
                                                        {
                                                            vNM_Campo = "a.tp_medicao",
                                                            vOperador = "=",
                                                            vVL_Busca = "'A'"
                                                        }
                                                    }, "a.qtd_combustivel", string.Empty, string.Empty, null);
                        if (obj_medicao != null)
                        {
                            //Buscar venda combustivel dia anterior
                            object obj_volume =
                            new CamadaDados.PostoCombustivel.TCD_VendaCombustivel().BuscarEscalar(
                                new TpBusca[]
                                        {
                                            new TpBusca()
                                            {
                                                vNM_Campo = "a.cd_empresa",
                                                vOperador = "=",
                                                vVL_Busca = "'" + rCfgPosto.Cd_empresa.Trim() + "'"
                                            },
                                            new TpBusca()
                                            {
                                                vNM_Campo = "isnull(a.st_afericao, 'N')",
                                                vOperador = "<>",
                                                vVL_Busca = "'S'"
                                            },
                                            new TpBusca()
                                            {
                                                vNM_Campo = string.Empty,
                                                vOperador = "exists",
                                                vVL_Busca = "(select 1 from tb_pdc_bicobomba x " +
                                                            "where a.id_bico = x.id_bico " +
                                                            "and x.cd_empresa = '" + p.Cd_empresa.Trim() + "' " +
                                                            "and x.id_tanque = " + p.Id_tanquestr + ")"
                                            },
                                            new TpBusca()
                                            {
                                                vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.dt_abastecimento)))",
                                                vOperador = "=",
                                                vVL_Busca = "'" + CamadaDados.UtilData.Data_Servidor().AddDays(-1).ToString("yyyyMMdd") + "'"
                                            }
                                        }, "isnull(sum(isnull(a.volumeabastecido, 0)), 0)");
                            //Gravar medicao tanque
                            CamadaNegocio.PostoCombustivel.TCN_MedicaoTanque.Gravar(
                                new CamadaDados.PostoCombustivel.TRegistro_MedicaoTanque()
                                {
                                    Id_tanque = p.Id_tanque,
                                    Cd_empresa = p.Cd_empresa,
                                    Dt_medicao = CamadaDados.UtilData.Data_Servidor(),
                                    Tp_medicao = tp_encerrante,
                                    Qtd_combustivel = decimal.Parse(obj_medicao.ToString()) -
                                                      decimal.Parse(obj_volume.ToString()) +
                                                      new CamadaDados.Fiscal.LMC.TCD_VolumeRecebido().Select(p.Cd_empresa,
                                                                                                             p.Cd_produto,
                                                                                                             p.Id_tanquestr,
                                                                                                             CamadaDados.UtilData.Data_Servidor().AddDays(-1)).Sum(v => v.Qtd_combustivel)
                                }, null);
                        }
                    });
                    #endregion
                }
            }
            else if (rCfgPosto.Tp_modoencerrante.Trim().ToUpper().Equals("L"))
            {
                //Verificar se tem configuracao de tipo de encerrante para a empresa
                obj = new CamadaDados.PostoCombustivel.Cadastros.TCD_CfgPosto().BuscarEscalar(
                                new TpBusca[]
                                {
                                    new TpBusca()
                                    {
                                        vNM_Campo = "a.cd_empresa",
                                        vOperador = "=",
                                        vVL_Busca = "'" + rCfgPosto.Cd_empresa.Trim() + "'"
                                    }
                                }, "isnull(a.tp_leituraencerrantebico, 'A')");
                string tp_encerrante = obj == null ? "A" : obj.ToString();
                if (tp_encerrante.Trim().ToUpper().Equals("A"))
                {
                    #region Encerrante Bico
                    //Buscar lista de bicos da empresa que nao tem encerrante gravado
                    CamadaDados.PostoCombustivel.Cadastros.TList_BicoBomba lBico =
                        new CamadaDados.PostoCombustivel.Cadastros.TCD_BicoBomba().Select(
                        new TpBusca[]
                        {
                            new TpBusca()
                            {
                                vNM_Campo = "a.cd_empresa",
                                vOperador = "=",
                                vVL_Busca = "'" + rCfgPosto.Cd_empresa.Trim() + "'"
                            },
                            new TpBusca()
                            {
                                vNM_Campo = "isnull(a.st_registro, 'A')",
                                vOperador = "<>",
                                vVL_Busca = "'C'"
                            },
                            new TpBusca()
                            {
                                vNM_Campo = string.Empty,
                                vOperador = "not exists",
                                vVL_Busca = "(select 1 from tb_pdc_encerrantebico x "+
                                            "where x.id_bico = a.id_bico "+
                                            "and x.tp_encerrante = 'A' " +
                                            "and convert(datetime, floor(convert(decimal(30,10), x.dt_encerrante))) = '" + CamadaDados.UtilData.Data_Servidor().ToString("yyyyMMdd") + "')"
                            }
                        }, 0, string.Empty);
                    if (lBico.Count > 0)
                    {
                        lBico.ForEach(p =>
                        {
                            //Buscar encerrante de abertura
                            object obj_encerrante =
                            new CamadaDados.PostoCombustivel.TCD_EncerranteBico().BuscarEscalar(
                                new TpBusca[]
                                    {
                                        new TpBusca()
                                        {
                                            vNM_Campo = "a.id_bico",
                                            vOperador = "=",
                                            vVL_Busca = p.Id_bicostr
                                        },
                                        new TpBusca()
                                        {
                                            vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.dt_encerrante)))",
                                            vOperador = "=",
                                            vVL_Busca = "'" + CamadaDados.UtilData.Data_Servidor().AddDays(-1).ToString("yyyyMMdd") + "'"
                                        }
                                    }, "a.qtd_encerrante", string.Empty, "a.qtd_encerrante desc", null);
                            if (obj_encerrante != null)
                            {
                                //Buscar venda combustivel dia anterior
                                object obj_volume =
                                new CamadaDados.PostoCombustivel.TCD_VendaCombustivel().BuscarEscalar(
                                    new TpBusca[]
                                        {
                                            new TpBusca()
                                            {
                                                vNM_Campo = "a.cd_empresa",
                                                vOperador = "=",
                                                vVL_Busca = "'" + rCfgPosto.Cd_empresa.Trim() + "'"
                                            },
                                            new TpBusca()
                                            {
                                                vNM_Campo = "a.id_bico",
                                                vOperador = "=",
                                                vVL_Busca = p.Id_bicostr
                                            },
                                            new TpBusca()
                                            {
                                                vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.dt_abastecimento)))",
                                                vOperador = "=",
                                                vVL_Busca = "'" + CamadaDados.UtilData.Data_Servidor().AddDays(-1).ToString("yyyyMMdd") + "'"
                                            }
                                        }, "isnull(sum(isnull(a.volumeabastecido, 0)), 0)");

                                //Gravar Encerrante
                                CamadaNegocio.PostoCombustivel.TCN_EncerranteBico.Gravar(
                                    new CamadaDados.PostoCombustivel.TRegistro_EncerranteBico()
                                    {
                                        Id_bico = p.Id_bico,
                                        Dt_encerrante = CamadaDados.UtilData.Data_Servidor(),
                                        Tp_encerrante = tp_encerrante,
                                        Qtd_encerrante = decimal.Parse(obj_encerrante.ToString()) + decimal.Parse(obj_volume.ToString())
                                    }, null);
                            }
                        });
                    }
                    #endregion

                    #region Medicao Tanque
                    //Buscar lista de tanques que nao tem afericao
                    new CamadaDados.PostoCombustivel.Cadastros.TCD_TanqueCombustivel().Select(
                    new TpBusca[]
                    {
                        new TpBusca()
                        {
                            vNM_Campo = "a.cd_empresa",
                            vOperador = "=",
                            vVL_Busca = "'" + rCfgPosto.Cd_empresa.Trim() + "'"
                        },
                        new TpBusca()
                        {
                            vNM_Campo = "isnull(a.st_registro, 'A')",
                            vOperador = "<>",
                            vVL_Busca = "'C'"
                        },
                        new TpBusca()
                        {
                            vNM_Campo = string.Empty,
                            vOperador = "not exists",
                            vVL_Busca = "(select 1 from tb_pdc_medicaotanque x "+
                                        "where x.cd_empresa = a.cd_empresa "+
                                        "and x.id_tanque = a.id_tanque "+
                                        "and x.tp_medicao = 'A' " +
                                        "and convert(datetime, floor(convert(decimal(30,10), x.dt_medicao))) = '" +
                                        CamadaDados.UtilData.Data_Servidor().ToString("yyyyMMdd") + "')"
                        }
                    }, 0, string.Empty).ForEach(p =>
                    {
                        //Buscar Ultima medicao
                        object obj_medicao = new CamadaDados.PostoCombustivel.TCD_MedicaoTanque().BuscarEscalar(
                                                new TpBusca[]
                                                    {
                                                        new TpBusca()
                                                        {
                                                            vNM_Campo = "a.cd_empresa",
                                                            vOperador = "=",
                                                            vVL_Busca = "'" + p.Cd_empresa.Trim() + "'"
                                                        },
                                                        new TpBusca()
                                                        {
                                                            vNM_Campo = "a.id_tanque",
                                                            vOperador = "=",
                                                            vVL_Busca = p.Id_tanquestr
                                                        },
                                                        new TpBusca()
                                                        {
                                                            vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.dt_medicao)))",
                                                            vOperador = "=",
                                                            vVL_Busca = "'" + CamadaDados.UtilData.Data_Servidor().AddDays(-1).ToString("yyyyMMdd") + "'"
                                                        },
                                                        new TpBusca()
                                                        {
                                                            vNM_Campo = "isnull(a.tp_medicao, 'A')",
                                                            vOperador = "=",
                                                            vVL_Busca = "'A'"
                                                        }
                                                    }, "a.qtd_combustivel", string.Empty, string.Empty, null);
                        if (obj_medicao != null)
                        {
                            //Buscar venda combustivel dia anterior
                            object obj_volume =
                            new CamadaDados.PostoCombustivel.TCD_VendaCombustivel().BuscarEscalar(
                                new TpBusca[]
                                        {
                                            new TpBusca()
                                            {
                                                vNM_Campo = "a.cd_empresa",
                                                vOperador = "=",
                                                vVL_Busca = "'" + rCfgPosto.Cd_empresa.Trim() + "'"
                                            },
                                            new TpBusca()
                                            {
                                                vNM_Campo = "isnull(a.st_afericao, 'N')",
                                                vOperador = "<>",
                                                vVL_Busca = "'S'"
                                            },
                                            new TpBusca()
                                            {
                                                vNM_Campo = string.Empty,
                                                vOperador = "exists",
                                                vVL_Busca = "(select 1 from tb_pdc_bicobomba x " +
                                                            "where a.id_bico = x.id_bico " +
                                                            "and x.cd_empresa = '" + p.Cd_empresa.Trim() + "' " +
                                                            "and x.id_tanque = " + p.Id_tanquestr + ")"
                                            },
                                            new TpBusca()
                                            {
                                                vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.dt_abastecimento)))",
                                                vOperador = "=",
                                                vVL_Busca = "'" + CamadaDados.UtilData.Data_Servidor().AddDays(-1).ToString("yyyyMMdd") + "'"
                                            }
                                        }, "isnull(sum(isnull(a.volumeabastecido, 0)), 0)");
                            //Gravar medicao tanque
                            CamadaNegocio.PostoCombustivel.TCN_MedicaoTanque.Gravar(
                                new CamadaDados.PostoCombustivel.TRegistro_MedicaoTanque()
                                {
                                    Id_tanque = p.Id_tanque,
                                    Cd_empresa = p.Cd_empresa,
                                    Dt_medicao = CamadaDados.UtilData.Data_Servidor(),
                                    Tp_medicao = tp_encerrante,
                                    Qtd_combustivel = decimal.Parse(obj_medicao.ToString()) -
                                                      decimal.Parse(obj_volume.ToString()) +
                                                      new CamadaDados.Fiscal.LMC.TCD_VolumeRecebido().Select(p.Cd_empresa,
                                                                                                             p.Cd_produto,
                                                                                                             p.Id_tanquestr,
                                                                                                             CamadaDados.UtilData.Data_Servidor().AddDays(-1)).Sum(v => v.Qtd_combustivel)
                                }, null);
                        }
                    });
                    #endregion
                }
            }
            tmpSemaforo_Tick(this, new EventArgs());
            tmpSemaforo.Start();
            cd_produto.Focus();
        }

        private void TFLanVendaCombustivel_FormClosing(object sender, FormClosingEventArgs e)
        {
            ShapeGrid.SaveShape(this, gAbastecimento);
            if (rVenda != null)
            {
                MessageBox.Show("Existe venda em aberto. Para fechar janela é necessario finalizar ou cancelar a venda", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Cancel = true;
            }
            //Encerrar Sessão
            try
            {
                lSessao.ForEach(p => CamadaNegocio.Faturamento.PDV.TCN_Sessao.EncerrarSessao(p, null));
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            if (rCfgPosto != null)
                if ((!rCfgPosto.Tp_concentrador.Trim().ToUpper().Equals("SA")) &&
                (rCfgPosto.Cd_terminal.Trim().Equals(lPdv[0].Cd_terminal.Trim()) || !string.IsNullOrEmpty(rCfgPosto.Host_ip)))
                    try
                    {
                        tmpOnLine.Stop();
                        tmpAbastAtual.Stop();
                        if (tcpClient != null)
                        {
                            tcpClient.Close();
                            tcpClient.Dispose();
                        }
                        else
                            TAutomacao.FecharPorta(rCfgPosto.Tp_concentrador);
                    }
                    catch
                    { }
            tmpAtualizaTela.Stop();
        }

        private void BB_Fechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cd_produto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                if (!lCfg[0].St_produtocodigobool)
                {
                    if (string.IsNullOrEmpty(cd_produto.Text))
                        FormBusca.UtilPesquisa.BuscarProduto(string.Empty,
                                                             lCfg.Count > 0 ? lCfg[0].Cd_empresa : string.Empty,
                                                             lCfg.Count > 0 ? lCfg[0].Nm_empresa : string.Empty,
                                                             lCfg.Count > 0 ? lCfg[0].Cd_tabelapreco : string.Empty,
                                                             new Componentes.EditDefault[] { cd_produto },
                                                             new TpBusca[]
                                                             {
                                                                 new TpBusca()
                                                                 {
                                                                     vNM_Campo = "isnull(e.st_combustivel, 'N')",
                                                                     vOperador = "<>",
                                                                     vVL_Busca = "'S'"
                                                                 }
                                                             });
                    else if (cd_produto.Text.SoNumero().Trim().Length != cd_produto.Text.Trim().Length)
                        FormBusca.UtilPesquisa.BuscarProduto(cd_produto.Text,
                                                             lCfg.Count > 0 ? lCfg[0].Cd_empresa : string.Empty,
                                                             lCfg.Count > 0 ? lCfg[0].Nm_empresa : string.Empty,
                                                             lCfg.Count > 0 ? lCfg[0].Cd_tabelapreco : string.Empty,
                                                             new Componentes.EditDefault[] { cd_produto },
                                                             new TpBusca[]
                                                             {
                                                                 new TpBusca()
                                                                 {
                                                                     vNM_Campo = "isnull(e.st_combustivel, 'N')",
                                                                     vOperador = "<>",
                                                                     vVL_Busca = "'S'"
                                                                 }
                                                             });
                }
                BuscarItens();
                cd_produto.Clear();
            }
        }

        private void bb_cancelarvenda_Click(object sender, EventArgs e)
        {
            CancelarVenda();
        }

        private void bb_adicionaCombustivel_Click(object sender, EventArgs e)
        {
            if (bsVendaCombustivel.Count > 0)
            {
                List<CamadaDados.PostoCombustivel.TRegistro_VendaCombustivel> lVenda =
                    (bsVendaCombustivel.DataSource as CamadaDados.PostoCombustivel.TList_VendaCombustivel).FindAll(p => p.St_processar);
                cbTodos.Checked = false;
                if (lVenda.Count > 0)
                {
                    string id_venda = string.Empty;
                    string virg = string.Empty;
                    lVenda.ForEach(p =>
                    {
                        id_venda += virg + p.Id_vendastr;
                        virg = ",";
                    });
                    if (new CamadaDados.PostoCombustivel.TCD_VendaCombustivel().BuscarEscalar(
                        new TpBusca[]
                        {
                            new TpBusca()
                            {
                                vNM_Campo = "a.cd_empresa",
                                vOperador = "=",
                                vVL_Busca = "'" + rCfgPosto.Cd_empresa.Trim() + "'"
                            },
                            new TpBusca()
                            {
                                vNM_Campo = "a.id_venda",
                                vOperador = "in",
                                vVL_Busca = "(" + id_venda + ")"
                            },
                            new TpBusca()
                            {
                                vNM_Campo = "isnull(a.st_registro, 'A')",
                                vOperador = "<>",
                                vVL_Busca = "'A'"
                            }
                        }, "1") != null)
                    {
                        MessageBox.Show("Existe venda combustivel faturada por outro terminal.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        afterBusca();
                        return;
                    }
                    NovaVenda(null, lVenda, null, null);
                }
            }
        }

        private void NM_Clifor_Leave(object sender, EventArgs e)
        {
            if ((!string.IsNullOrEmpty(NM_Clifor.Text)) && (rVenda != null))
                rVenda.Nm_clifor = NM_Clifor.Text;
        }

        private void bb_excluiritem_Click(object sender, EventArgs e)
        {
            CancelarItem();
        }

        private void lblProduto_Click(object sender, EventArgs e)
        {
            cd_produto.Focus();
        }

        private void lblQuantidade_Click(object sender, EventArgs e)
        {
            quantidade.Focus();
        }


        private void bb_finalizar_Click(object sender, EventArgs e)
        {
            FaturarVenda(string.Empty);
        }

        private void TFLanVendaCombustivel_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F2))
                FaturarVenda(string.Empty);
            else if (e.KeyCode.Equals(Keys.F6))
                ReceberFinanceiro();
            else if (e.KeyCode.Equals(Keys.F10))
                CancelarVenda();
            else if (e.KeyCode.Equals(Keys.F8))
                CancelarItem();
            else if (e.KeyCode.Equals(Keys.F12))
                bb_adicionaCombustivel_Click(this, new EventArgs());
            else if (e.KeyCode.Equals(Keys.F11))
                AfericaoBomba();
            else if (e.Control && e.KeyCode.Equals(Keys.E))
                ProcessarVendaEspera();
            else if (e.Control && e.KeyCode.Equals(Keys.P))
            {
                Altera_Relatorio = true;
                MessageBox.Show("Execute o relatorio que deseja alterar.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void bb_liquidacao_Click(object sender, EventArgs e)
        {
            ReceberFinanceiro();
        }

        private void miGerarCFVenda_Click(object sender, EventArgs e)
        {
            GerarCF();
        }

        private void miGerarCfVendas_Click(object sender, EventArgs e)
        {
            this.GerarCFFinalizador();
        }

        private void miVincularCFNFe_Click(object sender, EventArgs e)
        {
            VincularCfNFe();
        }

        private void miConsultaNfe_Click(object sender, EventArgs e)
        {
            ConsultaNfe("NFE");
        }

        private void miNovoCliente_Click(object sender, EventArgs e)
        {
            NovoCliente();
        }

        private void miIntervencao_Click(object sender, EventArgs e)
        {
            IntervencaoTecnica();
        }

        private void tslEspera_Click(object sender, EventArgs e)
        {
            ProcessarVendaEspera();
        }

        private void miRetiradaCaixa_Click(object sender, EventArgs e)
        {
            using (PDV.TFRetiradaCaixa fRetirar = new PDV.TFRetiradaCaixa())
            {
                fRetirar.pId_caixa = rCaixa.Id_caixastr;
                if (fRetirar.ShowDialog() == DialogResult.OK)
                    if (fRetirar.rRetirada != null)
                    {
                        try
                        {
                            fRetirar.rRetirada.Id_caixastr = rCaixa.Id_caixastr;
                            fRetirar.rRetirada.Dt_retirada = CamadaDados.UtilData.Data_Servidor();
                            CamadaNegocio.Faturamento.PDV.TCN_RetiradaCaixa.Gravar(fRetirar.rRetirada, null);
                            string title = fRetirar.rRetirada.Tp_registro.Trim().ToUpper().Equals("S") ? "SUPRIMENTO" : "RETIRADA";
                            FormRelPadrao.Relatorio Relatorio = new FormRelPadrao.Relatorio();
                            Relatorio.Nome_Relatorio = "TFLanVendaRapida_AberturaCaixa";
                            Relatorio.NM_Classe = "TFLanVendaRapida_AberturaCaixa";
                            Relatorio.Modulo = "FAT";
                            Relatorio.Ident = "TFLanVendaRapida_AberturaCaixa";
                            Relatorio.Altera_Relatorio = Altera_Relatorio;

                            BindingSource BinEmpresa = new BindingSource();
                            BinEmpresa.DataSource = CamadaNegocio.Diversos.TCN_CadEmpresa.Busca(fRetirar.rRetirada.Cd_empresa,
                                                                                                string.Empty,
                                                                                                string.Empty,
                                                                                                null);
                            Relatorio.Adiciona_DataSource("EMPRESA", BinEmpresa);

                            BindingSource meu_bind = new BindingSource();
                            meu_bind.DataSource = fRetirar.rRetirada;
                            Relatorio.DTS_Relatorio = meu_bind;


                            //Verificar se existe Impressora padrão para o PDV
                            object obj = new CamadaDados.Faturamento.Cadastros.TCD_PontoVenda().BuscarEscalar(
                                            new TpBusca[]
                                            {
                                                new TpBusca()
                                                {
                                                    vNM_Campo = "a.cd_terminal",
                                                    vOperador = "=",
                                                    vVL_Busca = "'" + Utils.Parametros.pubTerminal.Trim() + "'"
                                                }
                                            }, "a.impressorapadrao");
                            string print = string.Empty;
                            print = obj == null ? string.Empty : obj.ToString();
                            if (string.IsNullOrEmpty(print))
                                using (Parametros.Diversos.TFListaImpressoras fLista = new Parametros.Diversos.TFListaImpressoras())
                                {
                                    if (fLista.ShowDialog() == DialogResult.OK)
                                        if (!string.IsNullOrEmpty(fLista.Impressora))
                                            print = fLista.Impressora;

                                }
                            //Imprimir
                            Relatorio.ImprimiGraficoReduzida(print,
                                                                true,
                                                                false,
                                                                null,
                                                                string.Empty,
                                                                string.Empty,
                                                                1);
                            Altera_Relatorio = false;
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                    }
            }
        }

       
        private void miValorTransportar_Click(object sender, EventArgs e)
        {
            if (rCaixa.Vl_transportar.Equals(decimal.Zero) &&
                (lPdv[0].Vl_maxretcaixa > decimal.Zero))
            {
                using (Componentes.TFQuantidade fQtde = new Componentes.TFQuantidade())
                {
                    fQtde.Ds_label = "Vl. Retido Caixa";
                    fQtde.Vl_saldo = lPdv[0].Vl_maxretcaixa;
                    fQtde.Casas_decimais = 2;
                    if (fQtde.ShowDialog() == DialogResult.OK)
                        try
                        {
                            rCaixa.Vl_transportar = fQtde.Quantidade;
                            CamadaNegocio.Faturamento.PDV.TCN_CaixaPDV.Gravar(rCaixa, null);
                            MessageBox.Show("Caixa alterado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
            }
        }

        private void miGerarNFe_Click(object sender, EventArgs e)
        {
            GerarNfe();
        }

        private void cbTodos_Click(object sender, EventArgs e)
        {
            if (bsVendaCombustivel.Count > 0)
            {
                (bsVendaCombustivel.List as CamadaDados.PostoCombustivel.TList_VendaCombustivel).ForEach(p => p.St_processar = cbTodos.Checked);
                bsVendaCombustivel.ResetBindings(true);

                //Totalizar Venda Faturar
                edtVolFaturar.Text = (bsVendaCombustivel.List as CamadaDados.PostoCombustivel.TList_VendaCombustivel).Where(p => p.St_processar).Sum(p => p.Volumeabastecido).ToString("N3", new System.Globalization.CultureInfo("pt-BR"));
                edtVlFaturar.Text = (bsVendaCombustivel.List as CamadaDados.PostoCombustivel.TList_VendaCombustivel).Where(p => p.St_processar).Sum(p => p.Vl_subtotal).ToString("N2", new System.Globalization.CultureInfo("pt-BR"));
            }
        }

        private void gAbastecimento_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if ((e.ColumnIndex == 0) &&
                (bsVendaCombustivel.Current != null))
            {
                (bsVendaCombustivel.Current as CamadaDados.PostoCombustivel.TRegistro_VendaCombustivel).St_processar =
                    !(bsVendaCombustivel.Current as CamadaDados.PostoCombustivel.TRegistro_VendaCombustivel).St_processar;
                bsVendaCombustivel.ResetCurrentItem();

                //Totalizar Venda Faturar
                edtVolFaturar.Text = (bsVendaCombustivel.List as CamadaDados.PostoCombustivel.TList_VendaCombustivel).Where(p => p.St_processar).Sum(p => p.Volumeabastecido).ToString("N3", new System.Globalization.CultureInfo("pt-BR"));
                edtVlFaturar.Text = (bsVendaCombustivel.List as CamadaDados.PostoCombustivel.TList_VendaCombustivel).Where(p => p.St_processar).Sum(p => p.Vl_subtotal).ToString("N2", new System.Globalization.CultureInfo("pt-BR"));
            }
        }

        private void bb_espera_Click(object sender, EventArgs e)
        {
            MoverEspera();
        }

        private void miReceberFin_Click(object sender, EventArgs e)
        {
            ReceberFinanceiro();
        }

        private void miAcessoRemoto_Click(object sender, EventArgs e)
        {
            if (System.IO.File.Exists(Utils.Parametros.pubPathAliance.Trim() +
                                        System.IO.Path.DirectorySeparatorChar.ToString() +
                                        "EasyDesk.exe"))
                if (System.Diagnostics.Process.GetProcessesByName("EasyDeskAccess").Length == 0)
                    try
                    {
                        System.Diagnostics.Process.Start(Utils.Parametros.pubPathAliance.Trim() +
                                                         System.IO.Path.DirectorySeparatorChar.ToString() +
                                                         "EasyDesk.exe");
                    }
                    catch
                    { }
        }

        private void miSuporte_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://tawk.to/chat/5941999350fd5105d0c8110e/1bjsuk5jp/?$_tawk_popout=true");
        }

        private void miAlteraPreco_Click(object sender, EventArgs e)
        {
            if (rCfgPosto.St_alterarprecobool)
                //Verificar se o usuario tem permissao para alterar preco venda
                using (Parametros.Diversos.TFRegraUsuario fRegra = new Parametros.Diversos.TFRegraUsuario())
                {
                    fRegra.Ds_regraespecial = "PERMITIR ALTERAR PREÇO COMBUSTIVEL";
                    fRegra.Login = LoginPdv;
                    if (fRegra.ShowDialog() == DialogResult.OK)
                        using (TFAlterarPrecoBico fPreco = new TFAlterarPrecoBico())
                        {
                            fPreco.tcpClient = tcpClient;
                            fPreco.escreve = escreve;
                            fPreco.le = le;
                            fPreco.rCfgPosto = rCfgPosto;
                            fPreco.ShowDialog();
                        }
                }
            else
                MessageBox.Show("Concentrador não esta configurado para alterar preço.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void miLerEncerrante_Click(object sender, EventArgs e)
        {
            if (rCfgPosto.Tp_modoencerrante.Trim().ToUpper().Equals("C"))
                using (TFLerEncerrante fEncerrante = new TFLerEncerrante())
                {
                    fEncerrante.tcpClient = tcpClient;
                    fEncerrante.escreve = escreve;
                    fEncerrante.le = le;
                    fEncerrante.rCfgPosto = rCfgPosto;
                    fEncerrante.ShowDialog();
                }
            else
                MessageBox.Show("Concentrador configurado para não ler encerrante.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void bb_consultarapida_Click(object sender, EventArgs e)
        {
            using (TFConsultaCliente fConsulta = new TFConsultaCliente())
            {
                fConsulta.pCd_empresa = rCfgPosto.Cd_empresa;
                fConsulta.ShowDialog();
            }
        }

        private void miCancelaNFe_Click(object sender, EventArgs e)
        {
            using (TFCancelarNFe fCanc = new TFCancelarNFe())
            {
                fCanc.Cd_empresa = rCfgPosto.Cd_empresa;
                fCanc.Nm_empresa = rCfgPosto.Nm_empresa;
                fCanc.ShowDialog();
            }
        }

        private void bb_desdabastecida_Click(object sender, EventArgs e)
        {
            DesdobrarAbastecida();
        }

        private void bb_abastmanual_Click(object sender, EventArgs e)
        {
            IncluirAbastManual();
        }

        private void miAcertarDiaHoraConcentrador_Click(object sender, EventArgs e)
        {
            //Verificar se o usuario tem permissao para alterar preco venda
            using (Parametros.Diversos.TFRegraUsuario fRegra = new Parametros.Diversos.TFRegraUsuario())
            {
                fRegra.Ds_regraespecial = "PERMITIR AJUSTAR DIA/HORA CONCENTRADOR";
                fRegra.Login = LoginPdv;
                if (fRegra.ShowDialog() == DialogResult.OK)
                    try
                    {
                        if (tcpClient == null)
                        {
                            TAutomacao.LimparSerial(rCfgPosto.Tp_concentrador);
                            if (TAutomacao.AtualizaDiaHoraConcentrador(rCfgPosto.Tp_concentrador, CamadaDados.UtilData.Data_Servidor()))
                                MessageBox.Show("Dia/Hora do concentrador atualizado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            else
                                MessageBox.Show("Erro alterar Dia/Hora do concentrador.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            DateTime Data = CamadaDados.UtilData.Data_Servidor();
                            string st = "(&H" + Data.Day.ToString().PadLeft(2, '0') + Data.Hour.ToString().PadLeft(2, '0') + Data.Minute.ToString().PadLeft(2, '0') + ")";
                            string ret = SendLan(st);
                            if(ret.Trim().Equals("(&H)"))
                                MessageBox.Show("Dia/Hora do concentrador atualizado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            else
                                MessageBox.Show("Erro alterar Dia/Hora do concentrador.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch
                    { }
            }
        }

        private void bb_novaos_Click(object sender, EventArgs e)
        {
            IncluirNovaOS();
        }

        private void bb_faturaros_Click(object sender, EventArgs e)
        {
            FaturarOS();
        }

        private void bb_vendaconv_Click(object sender, EventArgs e)
        {
            NovaVendaMesaConv();
        }

        private void bb_clifor_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { Cd_clifor, NM_Clifor }, string.Empty);
            BuscarEndereco();
            if (string.IsNullOrEmpty(Cd_clifor.Text))
            {
                NM_Clifor.Clear();
                Cd_clifor.BackColor = Color.White;
            }
            else
            {
                CamadaDados.Financeiro.Duplicata.TRegistro_DadosBloqueio rDados = new CamadaDados.Financeiro.Duplicata.TRegistro_DadosBloqueio();
                if (CamadaNegocio.Financeiro.Duplicata.TCN_DadosBloqueio.VerificarBloqueioCredito(Cd_clifor.Text,
                                                                                                  decimal.Zero,
                                                                                                  true,
                                                                                                  ref rDados,
                                                                                                  null))
                    using (Financeiro.TFLan_BloqueioCredito fBloq = new Financeiro.TFLan_BloqueioCredito())
                    {
                        fBloq.rDados = rDados;
                        fBloq.Vl_fatura = decimal.Zero;
                        fBloq.St_consulta = true;
                        fBloq.ShowDialog();
                        Cd_clifor.BackColor = Color.Red;
                    }
                else Cd_clifor.BackColor = Color.White;
            }
            if (rVenda != null)
            {
                rVenda.Cd_clifor = Cd_clifor.Text;
                rVenda.Nm_clifor = NM_Clifor.Text;
                //Atualizar lista de produtos com programação especial de venda
                rVenda.lItem.Where(p => p.rVendaCombustivel == null).ToList().ForEach(p =>
                {
                    //Vefiricar se existe programacao especial de venda 
                    rProg = CamadaNegocio.Faturamento.ProgEspecialVenda.TCN_ProgEspecialVenda.BuscarProg(lCfg[0].Cd_empresa,
                                                                                                         Cd_clifor.Text,
                                                                                                         p.Cd_produto,
                                                                                                         lCfg[0].Cd_tabelapreco,
                                                                                                         null);
                    if (rProg != null)
                    {
                        if (rProg.Tp_preco.Trim().ToUpper().Equals("C"))//Preco de Custo
                        {
                            p.Vl_unitario = CamadaNegocio.Estoque.TCN_LanEstoque.BuscarVlEstoqueUltimaCompra(lCfg[0].Cd_empresa,
                                                                                                             p.Cd_produto,
                                                                                                             null);
                            p.Vl_subtotal = p.Quantidade * p.Vl_unitario;
                        }
                        else
                        {
                            p.Vl_desconto = CalcularDescEspecial(p.Quantidade, p.Vl_unitario, p.Cd_produto);
                            p.Vl_acrescimo = CalcularAcresEspecial(p.Quantidade, p.Vl_unitario);
                        }
                        TotalizarVenda();
                    }
                });
                bsItensCupom.ResetBindings(true);
            }
        }

        private void cd_clifor_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveClifor("a.cd_clifor|=|'" + Cd_clifor.Text.Trim() + "'",
                new Componentes.EditDefault[] { Cd_clifor, NM_Clifor },
                new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
            BuscarEndereco();
            if (string.IsNullOrEmpty(Cd_clifor.Text))
            {
                Cd_clifor.Text = lCfg[0].Cd_clifor;
                NM_Clifor.Text = lCfg[0].Nm_clifor;
                Cd_clifor.BackColor = Color.White;
            }
            else
            {
                CamadaDados.Financeiro.Duplicata.TRegistro_DadosBloqueio rDados = new CamadaDados.Financeiro.Duplicata.TRegistro_DadosBloqueio();
                if (CamadaNegocio.Financeiro.Duplicata.TCN_DadosBloqueio.VerificarBloqueioCredito(Cd_clifor.Text,
                                                                                                  decimal.Zero,
                                                                                                  true,
                                                                                                  ref rDados,
                                                                                                  null))
                    using (Financeiro.TFLan_BloqueioCredito fBloq = new Financeiro.TFLan_BloqueioCredito())
                    {
                        fBloq.rDados = rDados;
                        fBloq.Vl_fatura = decimal.Zero;
                        fBloq.St_consulta = true;
                        fBloq.ShowDialog();
                        Cd_clifor.BackColor = Color.Red;
                    }
                else Cd_clifor.BackColor = Color.White;
            }
            if (rVenda != null)
            {
                rVenda.Cd_clifor = Cd_clifor.Text;
                rVenda.Nm_clifor = NM_Clifor.Text;
                //Atualizar lista de produtos com programação especial de venda
                rVenda.lItem.Where(p => p.rVendaCombustivel == null).ToList().ForEach(p =>
                {
                    //Vefiricar se existe programacao especial de venda 
                    rProg = CamadaNegocio.Faturamento.ProgEspecialVenda.TCN_ProgEspecialVenda.BuscarProg(lCfg[0].Cd_empresa,
                                                                                                         Cd_clifor.Text,
                                                                                                         p.Cd_produto,
                                                                                                         lCfg[0].Cd_tabelapreco,
                                                                                                         null);
                    if (rProg != null)
                    {
                        if (rProg.Tp_preco.Trim().ToUpper().Equals("C"))//Preco de Custo
                        {
                            p.Vl_unitario = CamadaNegocio.Estoque.TCN_LanEstoque.BuscarVlEstoqueUltimaCompra(lCfg[0].Cd_empresa,
                                                                                                             p.Cd_produto,
                                                                                                             null);
                            p.Vl_subtotal = p.Quantidade * p.Vl_unitario;
                        }
                        else
                        {
                            p.Vl_desconto = CalcularDescEspecial(p.Quantidade, p.Vl_unitario, p.Cd_produto);
                            p.Vl_acrescimo = CalcularAcresEspecial(p.Quantidade, p.Vl_unitario);
                        }
                        TotalizarVenda();
                    }
                });
                bsItensCupom.ResetBindings(true);
            }
        }

        private void cancelarVendaRecebidaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (PDV.TFExcluirVendaRapida fGerar = new PDV.TFExcluirVendaRapida())
            {
                if (fGerar.ShowDialog() == DialogResult.OK)
                    if (fGerar.lVenda != null)
                        try
                        {
                            //Verificar se alguma venda possui pontos resgatados
                            if (fGerar.lVenda.Exists(p => p.PontosFidRes > decimal.Zero))
                            {
                                string loginCanc = string.Empty;
                                using (Parametros.Diversos.TFRegraUsuario fRegra = new Parametros.Diversos.TFRegraUsuario())
                                {
                                    fRegra.Ds_regraespecial = "PERMITIR CANCELAR VALE PONTOS FIDELIZAÇÃO";
                                    if (fRegra.ShowDialog() == DialogResult.OK)
                                        loginCanc = fRegra.Login;
                                    else
                                    {
                                        MessageBox.Show("Obrigatório informar LOGIN com permissão para CANCELAR venda com pontos resgatados.",
                                                        "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        return;
                                    }
                                }
                                fGerar.lVenda.Where(p => p.PontosFidRes > decimal.Zero).ToList().ForEach(p => p.LoginCancPontos = loginCanc);
                            }
                            CamadaNegocio.Faturamento.PDV.TCN_VendaRapida.ExcluirVendaRapida(fGerar.lVenda, null);
                            MessageBox.Show("Venda Rapida Excluida com Sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            afterBusca();
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    else
                        MessageBox.Show("Não existe venda selecionada excluir.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void miCreditoAvulso_Click(object sender, EventArgs e)
        {
            using (TFCreditoAvulso fCred = new TFCreditoAvulso())
            {
                fCred.Cd_empresa = rCfgPosto.Cd_empresa;
                fCred.Nm_empresa = rCfgPosto.Nm_empresa;
                if (fCred.ShowDialog() == DialogResult.OK)
                    try
                    {
                        CamadaDados.Financeiro.Adiantamento.TRegistro_LanAdiantamento rAdto = new CamadaDados.Financeiro.Adiantamento.TRegistro_LanAdiantamento();
                        rAdto.Cd_empresa = rCfgPosto.Cd_empresa;
                        rAdto.Cd_clifor = fCred.Cd_clifor;
                        rAdto.CD_Endereco = fCred.Cd_endereco;
                        rAdto.Ds_adto = string.IsNullOrEmpty(fCred.Observacao) ? "CREDITO AVULSO FRENTE CAIXA" : fCred.Observacao;
                        rAdto.Tp_movimento = "R";
                        rAdto.Dt_lancto = CamadaDados.UtilData.Data_Servidor();
                        rAdto.Vl_adto = fCred.Vl_credito;
                        rAdto.ST_ADTO = "A";
                        rAdto.TP_Lancto = "T";
                        rAdto.Id_caixaPDV = rCaixa.Id_caixa;
                        string Tp_portador = string.Empty;
                        using (TFPortadorCredAvulso fPort = new TFPortadorCredAvulso())
                        {
                            if (fPort.ShowDialog() == DialogResult.OK)
                                if (!string.IsNullOrEmpty(fPort.Tp_portador))
                                    Tp_portador = fPort.Tp_portador;
                                else
                                {
                                    MessageBox.Show("Não é possivel gerar crédito sem informar Portador!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    return;
                                }
                            else
                            {
                                MessageBox.Show("Não é possivel gerar crédito sem informar Portador!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                        }
                        if (Tp_portador.ToUpper().Equals("CH"))
                        {
                            using (Financeiro.TFLanListaCheques fCh = new Financeiro.TFLanListaCheques())
                            {
                                fCh.Cd_empresa = rAdto.Cd_empresa;
                                fCh.Tp_mov = "R";
                                fCh.Cd_contager = lCfg[0].Cd_contacaixa;
                                fCh.Ds_contager = lCfg[0].Ds_contacaixa;
                                fCh.Cd_clifor = rAdto.Cd_clifor;
                                fCh.Nm_clifor = rAdto.Nm_clifor;
                                fCh.Dt_emissao = rAdto.Dt_lancto;
                                fCh.Vl_totaltitulo = rAdto.Vl_adto;
                                fCh.St_bloquearTroco = true;
                                if (fCh.ShowDialog() == DialogResult.OK)
                                {
                                    rAdto.lCheques = fCh.lCheques;
                                    CamadaNegocio.Financeiro.Adiantamento.TCN_LanAdiantamento.Gravar(rAdto, null);
                                    MessageBox.Show("Credito gravado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    List<string> Texto = new List<string>();
                                    Texto.Add("                EXTRATO CREDITO                 ");
                                    Texto.Add("Nº Credito: ".FormatStringDireita(38, ' ') + rAdto.Id_adto.ToString());
                                    Texto.Add("Data: ".FormatStringDireita(38, ' ') + rAdto.Dt_lanctostring);
                                    Texto.Add("Valor: ".FormatStringDireita(38, ' ') + rAdto.Vl_adto.ToString("N2", new System.Globalization.CultureInfo("pt-BR")));
                                    if (Texto.Count > 1)
                                        ImprimirCredAvulsoReduzido(Texto);
                                }
                            }
                        }
                        else if (Tp_portador.ToUpper().Equals("DH"))
                        {
                            rAdto.Cd_contager_qt = lCfg[0].Cd_contacaixa;
                            CamadaNegocio.Financeiro.Adiantamento.TCN_LanAdiantamento.Gravar(rAdto, null);
                            MessageBox.Show("Credito gravado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            List<string> Texto = new List<string>();
                            Texto.Add("                EXTRATO CREDITO                 ");
                            Texto.Add("Nº Credito: ".FormatStringDireita(38, ' ') + rAdto.Id_adto.ToString());
                            Texto.Add("Data: ".FormatStringDireita(38, ' ') + rAdto.Dt_lanctostring);
                            Texto.Add("Valor: ".FormatStringDireita(38, ' ') + rAdto.Vl_adto.ToString("N2", new System.Globalization.CultureInfo("pt-BR")));
                            if (Texto.Count > 1)
                                ImprimirCredAvulsoReduzido(Texto);
                        }
                        else if (Tp_portador.ToUpper().Equals("CC") || Tp_portador.ToUpper().Equals("CD"))
                        {
                            using (Componentes.TFDebitoCredito fD_C = new Componentes.TFDebitoCredito())
                            {
                                using (PDV.TFLanCartaoPDV fCartao = new PDV.TFLanCartaoPDV())
                                {
                                    fCartao.pCd_empresa = rAdto.Cd_empresa;
                                    fCartao.D_C = Tp_portador.ToUpper().Equals("CC") ? "C" : "D";
                                    fCartao.Vl_saldofaturar = rAdto.Vl_adto;
                                    fCartao.St_validarSaldo = true;
                                    if (fCartao.ShowDialog() == DialogResult.OK)
                                        if (fCartao.lFatura != null)
                                        {
                                            rAdto.lFatura = fCartao.lFatura;
                                            rAdto.lFatura.ForEach(p =>
                                                {
                                                    p.Cd_contager = lCfg[0].Cd_contacaixa;
                                                    p.Cd_historico = lCfg[0].Cd_historicocaixa;
                                                });
                                            CamadaNegocio.Financeiro.Adiantamento.TCN_LanAdiantamento.Gravar(rAdto, null);
                                            MessageBox.Show("Credito gravado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            List<string> Texto = new List<string>();
                                            Texto.Add("                EXTRATO CREDITO                 ");
                                            Texto.Add("Nº Credito: ".FormatStringDireita(38, ' ') + rAdto.Id_adto.ToString());
                                            Texto.Add("Data: ".FormatStringDireita(38, ' ') + rAdto.Dt_lanctostring);
                                            Texto.Add("Valor: ".FormatStringDireita(38, ' ') + rAdto.Vl_adto.ToString("N2", new System.Globalization.CultureInfo("pt-BR")));
                                            if (Texto.Count > 1)
                                                ImprimirCredAvulsoReduzido(Texto);
                                        }
                                        else
                                        {
                                            MessageBox.Show("Fatura cartão não foi lançada.\r\nCrédito não sera efetivado.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            return;
                                        }
                                    else
                                    {
                                        MessageBox.Show("Fatura cartão não foi lançada.\r\nCrédito não sera efetivado.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        return;
                                    }
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void miEmpConcedido_Click(object sender, EventArgs e)
        {
            using (TFEmpConcedido fEmp = new TFEmpConcedido())
            {
                fEmp.pCd_empresa = rCfgPosto.Cd_empresa;
                fEmp.pNm_empresa = rCfgPosto.Nm_empresa;
                if(fEmp.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        Proc_Commoditties.TProcessaVendaCombustivel.ProcessarEmpConcedido(fEmp.rEmp, rCfgPosto);
                        using (Proc_Commoditties.TFProcessarRetiradaCaixa fProc = new Proc_Commoditties.TFProcessarRetiradaCaixa())
                        {
                            fProc.Vl_processar = fEmp.rEmp.Vl_emprestimo;
                            fProc.Id_caixa = rCaixa.Id_caixastr;
                            fProc.St_emprestimo = true;
                            if (fProc.ShowDialog() == DialogResult.OK)
                                if (fProc.lPortador != null)
                                    if (fProc.lPortador.Count > 0)
                                    {
                                        //Criar objeto retirada emprestimo
                                        CamadaDados.Faturamento.PDV.TRegistro_RetiradaCaixa rRetirada = new CamadaDados.Faturamento.PDV.TRegistro_RetiradaCaixa();
                                        rRetirada.Id_caixa = rCaixa.Id_caixa;
                                        rRetirada.Dt_retirada = fEmp.rEmp.rDup.Dt_emissao;
                                        rRetirada.Vl_retirada = fEmp.rEmp.Vl_emprestimo;
                                        rRetirada.Tp_registro = "E";//Emprestimo
                                        rRetirada.St_registro = "A";
                                        rRetirada.lPortador = fProc.lPortador;
                                        if (fEmp.rEmp.Placa.Trim() != "-")
                                            rRetirada.Ds_observacao = "Placa: " + fEmp.rEmp.Placa.Trim();
                                        if (!string.IsNullOrEmpty(fEmp.rEmp.Nm_motorista))
                                            rRetirada.Ds_observacao += " Motorista: " + fEmp.rEmp.Nm_motorista.Trim();
                                        fEmp.rEmp.rRetirada = rRetirada;
                                        CamadaNegocio.Faturamento.PDV.TCN_EmprestimoConcedido.Gravar(fEmp.rEmp, null);
                                        
                                        MessageBox.Show("Emprestimo concedido com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        //Buscar Clifor
                                        CamadaDados.Financeiro.Cadastros.TRegistro_CadClifor rClifor =
                                            CamadaNegocio.Financeiro.Cadastros.TCN_CadClifor.Busca_Clifor_Codigo(fEmp.rEmp.Cd_clifor, null);
                                        List<string> Texto = new List<string>();
                                        Texto.Add("              EMPRESTIMO CONCEDIDO              ");
                                        Texto.Add("Nº Caixa: ".FormatStringDireita(38, ' ') + rCaixa.Id_caixastr);
                                        Texto.Add(("Operador: " + rCaixa.Login.Trim()).FormatStringDireita(48, ' '));
                                        Texto.Add("Data: ".FormatStringDireita(38, ' ') + rRetirada.Dt_retirada.Value.ToString("dd/MM/yyyy"));
                                        Texto.Add("Valor: ".FormatStringDireita(38, ' ') + rRetirada.Vl_retirada.ToString("N2", new System.Globalization.CultureInfo("pt-BR")));
                                        Texto.Add(("Cliente: " + rClifor.Nm_clifor).FormatStringDireita(48, ' '));
                                        Texto.Add(("CNPJ/CPF: " + (string.IsNullOrEmpty(rClifor.Nr_cgc) ? rClifor.Nr_cpf.Trim() : rClifor.Nr_cgc.Trim())).PadRight(48, ' '));
                                        Texto.Add("".PadRight(48, '-'));
                                        Texto.Add("Duplicata a Receber".PadRight(48, ' '));
                                        Texto.Add("Duplicata     Vencimento    Valor".PadRight(48, ' '));
                                        fEmp.rEmp.rDup.Parcelas.ForEach(p =>
                                            Texto.Add((p.Nr_docto.Trim() + "/" + p.Cd_parcelastr).PadRight(14, ' ') +
                                                       p.Dt_venctostring.PadRight(14, ' ') +
                                                       p.Vl_parcela.ToString("N2", new System.Globalization.CultureInfo("pt-BR")).PadRight(20, ' ')));
                                        if (fEmp.rEmp.Placa.Trim() != "-")
                                            Texto.Add("Placa: " + fEmp.rEmp.Placa.Trim().FormatStringDireita(48, ' '));
                                        if (!string.IsNullOrEmpty(fEmp.rEmp.Nm_motorista))
                                            Texto.Add("Motorista: " + fEmp.rEmp.Nm_motorista.FormatStringDireita(48, ' '));
                                        Texto.Add("".PadRight(48, ' '));
                                        Texto.Add("Ass.: ".PadRight(48, '-'));
                                        if (Texto.Count > 1)
                                            ImprimirCreditoConcedido(Texto);
                                           
                                    }
                                    else
                                        MessageBox.Show("Obrigatorio informar portador retirada do caixa.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                else
                                    MessageBox.Show("Obrigatorio informar portador retirada do caixa.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
            }
        }

        private void cbTodos_CheckedChanged(object sender, EventArgs e)
        {
            if (!cbTodos.Checked)
            {
                edtVolFaturar.Text = decimal.Zero.ToString("N3", new System.Globalization.CultureInfo("pt-BR"));
                edtVlFaturar.Text = decimal.Zero.ToString("N2", new System.Globalization.CultureInfo("pt-BR"));
            }
        }
                
        private void bb_endereco_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_endereco|Endereço|200;" +
                              "a.cd_endereco|Codigo|80";
            string vParam = "a.cd_clifor|=|'" + Cd_clifor.Text.Trim() + "'";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_endereco },
                new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco(), vParam);
            if ((!string.IsNullOrEmpty(cd_endereco.Text)) && (rVenda != null))
                rVenda.Cd_endereco = cd_endereco.Text;
        }

        private void cd_endereco_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_endereco|=|'" + cd_endereco.Text.Trim() + "';" +
                            "a.cd_clifor|=|'" + Cd_clifor.Text.Trim() + "'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_endereco },
                new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco());
            if ((!string.IsNullOrEmpty(cd_endereco.Text)) && (rVenda != null))
                rVenda.Cd_endereco = cd_endereco.Text;
        }

        private void bb_dinheiro_Click(object sender, EventArgs e)
        {
            FaturarVenda("R");
        }

        private void bb_cheque_Click(object sender, EventArgs e)
        {
            FaturarVenda("H");
        }

        private void bb_notacobrar_Click(object sender, EventArgs e)
        {
            FaturarVenda("N");
        }

        private void bb_cartafrete_Click(object sender, EventArgs e)
        {
            FaturarVenda("F");
        }

        private void vendaConveniênciaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VendaConveniencia();
        }

        private void conveniênciaEsperaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NovaVendaMesaConv();
        }

        private void faturarConveniênciaEsperaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FaturarVendaMesaConv();
        }

        private void novaOSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IncluirNovaOS();
        }

        private void lblConvEspera_Click(object sender, EventArgs e)
        {
            FaturarVendaMesaConv();
        }

        private void bb_consultaProd_Click(object sender, EventArgs e)
        {
            using (Proc_Commoditties.TFConsultaProduto fConsulta = new Proc_Commoditties.TFConsultaProduto())
            {
                fConsulta.ShowDialog();
            }
        }

        private void miNfConsumo_Click(object sender, EventArgs e)
        {
            bool st_vendagravada = false;   
            if (bsVendaCombustivel.Count > 0)
            {
                if (string.IsNullOrEmpty(lCfg[0].Cfg_pedvendaconsumo))
                {
                    MessageBox.Show("Não existe configuração para emitir NFe de CONSUMO.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                DataRowView linha = FormBusca.UtilPesquisa.BTN_BuscaClifor(null, string.Empty);
                if (linha == null)
                {
                    MessageBox.Show("Obrigatório identificar cliente para emitir NFe de CONSUMO.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                //Buscar endereco do cliente
                object obj = new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco().BuscarEscalar(
                                new TpBusca[]
                                {
                                    new TpBusca()
                                    {
                                        vNM_Campo = "a.cd_clifor",
                                        vOperador = "=",
                                        vVL_Busca = linha["cd_clifor"].ToString()
                                    }
                                }, "a.cd_endereco");
                if (obj == null)
                {
                    MessageBox.Show("Cliente " + linha["nm_clifor"].ToString() + " não possui endereço cadastrado.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                List<CamadaDados.PostoCombustivel.TRegistro_VendaCombustivel> lVenda = new List<CamadaDados.PostoCombustivel.TRegistro_VendaCombustivel>();
                ThreadEspera tEspera = new ThreadEspera("Inicio processo gravar nota consumo...");
                try
                {
                    (bsVendaCombustivel.List as CamadaDados.PostoCombustivel.TList_VendaCombustivel).FindAll(p => p.St_processar).ForEach(p =>
                        {
                            //Verificar se venda ja nao esta faturada
                            if (new CamadaDados.PostoCombustivel.TCD_VendaCombustivel().BuscarEscalar(
                                new TpBusca[]
                                {
                                    new TpBusca()
                                    {
                                        vNM_Campo = "a.cd_empresa",
                                        vOperador = "=",
                                        vVL_Busca = "'" + rCfgPosto.Cd_empresa.Trim() + "'"
                                    },
                                    new TpBusca()
                                    {
                                        vNM_Campo = "a.id_venda",
                                        vOperador = "=",
                                        vVL_Busca = p.Id_vendastr
                                    },
                                    new TpBusca()
                                    {
                                        vNM_Campo = "isnull(a.st_registro, 'A')",
                                        vOperador = "<>",
                                        vVL_Busca = "'A'"
                                    }
                                }, "1") == null)
                            {
                                p.St_registro = "F";
                                CamadaNegocio.PostoCombustivel.TCN_VendaCombustivel.Gravar(p, null);
                                lVenda.Add(p);
                            }
                        });
                    if (lVenda.Count > 0)
                    {
                        //Gerar objeto venda rapida
                        CamadaDados.Faturamento.PDV.TRegistro_VendaRapida rVendaConsumo = new CamadaDados.Faturamento.PDV.TRegistro_VendaRapida();
                        rVendaConsumo.Cd_clifor = linha["cd_clifor"].ToString();
                        rVendaConsumo.Nm_clifor = linha["nm_clifor"].ToString();
                        rVendaConsumo.Cd_endereco = obj.ToString();
                        rVendaConsumo.Cd_empresa = rCfgPosto.Cd_empresa;
                        rVendaConsumo.Cd_vend = string.Empty;
                        rVendaConsumo.Dt_emissao = CamadaDados.UtilData.Data_Servidor();
                        rVendaConsumo.Id_pdvstr = lPdv[0].Id_pdvstr;
                        rVendaConsumo.Id_sessaostr = lSessao[0].Id_sessaostr;
                        rVendaConsumo.St_registro = "A";
                        //Item Venda
                        lVenda.ForEach(p =>
                            {
                                decimal vl_custo = CamadaNegocio.Estoque.TCN_LanEstoque.BuscarVlEstoqueUltimaCompra(rVendaConsumo.Cd_empresa, p.Cd_produto, null);
                                decimal vl_subtotal = vl_custo > decimal.Zero ? p.Volumeabastecido * vl_custo : p.Vl_subtotal;
                                decimal vl_unit = vl_custo > decimal.Zero ? vl_custo : p.Vl_unitario;
                                decimal vl_desconto = CalcularDescEspecial(p.Volumeabastecido, vl_custo > decimal.Zero ? vl_custo : p.Vl_unitario, p.Cd_produto);
                                decimal vl_acrescimo = CalcularAcresEspecial(p.Volumeabastecido, vl_custo > decimal.Zero ? vl_custo : p.Vl_unitario);
                                if ((vl_desconto > decimal.Zero) || (vl_acrescimo > decimal.Zero))
                                {
                                    vl_subtotal = vl_subtotal - vl_desconto + vl_acrescimo;
                                    vl_unit = Math.Round(decimal.Divide(vl_subtotal, p.Volumeabastecido), 2);
                                }
                                rVendaConsumo.lItem.Add(new CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item()
                                {
                                    //Criar item venda combustivel
                                    Cd_local = p.Cd_local,
                                    Cd_produto = p.Cd_produto,
                                    Ds_produto = p.Ds_produto,
                                    Sigla_unidade = p.Sigla_unidade,
                                    Cd_condfiscal_produto = p.Cd_condfiscal_produto,
                                    Cd_unidade = p.Cd_unidade,
                                    Quantidade = p.Volumeabastecido,
                                    Vl_unitario = vl_unit,
                                    Vl_subtotal = vl_subtotal,
                                    St_registro = "A",
                                    rVendaCombustivel = p
                                });
                            });
                        CamadaNegocio.Faturamento.PDV.TCN_VendaRapida.GravarVendaRapida(rVendaConsumo, null, null, null);
                        st_vendagravada = true;
                        //Gerar NF de consumo
                        CamadaDados.Faturamento.Pedido.TRegistro_Pedido rPed = null;
                        CamadaDados.Faturamento.Pedido.TRegistro_Pedido rPedServico = null;
                        try
                        {
                            Proc_Commoditties.TProcessarPedidoVendaRapida.ProcessarPedido(rVendaConsumo.Cd_clifor,
                                                                                      rVendaConsumo.Cd_endereco,
                                                                                      true,
                                                                                      rVendaConsumo.Placa,
                                                                                      lCfg[0],
                                                                                      rVendaConsumo.lItem.ToList(),
                                                                                      ref rPed,
                                                                                      ref rPedServico);
                            CamadaNegocio.Faturamento.PDV.TCN_Pedido_X_VendaRapida.ProcessarPedido(rPed, null);
                            //Buscar pedido
                            rPed = CamadaNegocio.Faturamento.Pedido.TCN_Pedido.Busca_Registro_Pedido(rPed.Nr_pedido.ToString(), null);
                            //Buscar itens pedido
                            CamadaNegocio.Faturamento.Pedido.TCN_Pedido.Busca_Pedido_Itens(rPed, false, null);
                            //Se o CMI do pedido gerar financeiro
                            CamadaDados.Financeiro.Duplicata.TList_RegLanParcela lParcVinculado = new CamadaDados.Financeiro.Duplicata.TList_RegLanParcela();
                            //Buscar parcelas em aberto dos cupons que estao sendo vinculados
                            new CamadaDados.Financeiro.Duplicata.TCD_LanParcela().Select(
                                new TpBusca[]
                                            {
                                                new TpBusca()
                                                {
                                                    vNM_Campo = "isnull(dup.st_registro, 'A')",
                                                    vOperador = "<>",
                                                    vVL_Busca = "'C'"
                                                },
                                                new TpBusca()
                                                {
                                                    vNM_Campo = "isnull(a.st_registro, 'A')",
                                                    vOperador = "in",
                                                    vVL_Busca = "('A', 'P')"
                                                },
                                                new TpBusca()
                                                {
                                                    vNM_Campo = string.Empty,
                                                    vOperador = "exists",
                                                    vVL_Busca = "(select 1 from tb_pdv_cupomfiscal_x_duplicata x " +
                                                                "where x.cd_empresa = a.cd_empresa " +
                                                                "and x.nr_lancto = a.nr_lancto " +
                                                                "and x.cd_empresa = '" + rVendaConsumo.Cd_empresa.Trim() + "' " +
                                                                "and x.id_cupom = " + rVendaConsumo.Id_vendarapidastr + ")"
                                                }
                                            }, 0, string.Empty, "a.dt_vencto, c.nm_clifor", string.Empty).ForEach(v => lParcVinculado.Add(v));
                            //Gerar Nota Fiscal
                            CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento rFat =
                                Proc_Commoditties.TProcessaPedFaturar.ProcessaPedFaturar(rPed, true, lParcVinculado.Sum(p => p.Vl_atual));
                            //Vincular financeiro a Nota Fiscal
                            rFat.lParcAgrupar = lParcVinculado;

                            //Gravar Nota Fiscal
                            CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento.GravarFaturamento(rFat, null, null);
                            //Verificar se venda gerou credito
                            List<string> Texto = new List<string>();
                            Texto.Add("                EXTRATO CREDITO                 ");
                            new CamadaDados.Financeiro.Adiantamento.TCD_LanAdiantamento().Select(
                            new TpBusca[]
                            {
                                new TpBusca()
                                {
                                    vNM_Campo = string.Empty,
                                    vOperador = "exists",
                                    vVL_Busca = "(select 1 from tb_pdv_cupom_x_movcaixa x " +
                                                "where x.id_adto = a.id_adto " +
                                                "and x.cd_empresa = '" + rVendaConsumo.Cd_empresa.Trim() + "' " +
                                                "and x.id_cupom = " + rVendaConsumo.Id_vendarapidastr + ")"
                                }
                            }, 0, string.Empty).ForEach(p =>
                            {
                                Texto.Add("Nº Credito: ".FormatStringDireita(38, ' ') + p.Id_adto.ToString());
                                Texto.Add("Data: ".FormatStringDireita(38, ' ') + p.Dt_lanctostring);
                                Texto.Add("Valor: ".FormatStringDireita(38, ' ') + p.Vl_total_devolver.ToString("N2", new System.Globalization.CultureInfo("pt-BR")));
                            });
                            if (Texto.Count > 1)
                                ImprimirDevCredito(Texto);
                            
                            //Buscar total abastecimentos em espera
                            tslVendaEspera.Text = new CamadaDados.PostoCombustivel.TCD_VendaCombustivel().BuscarEscalar(
                                        new TpBusca[]
                                    {
                                        new TpBusca()
                                        {
                                            vNM_Campo = "a.cd_empresa",
                                            vOperador = "=",
                                            vVL_Busca = "'" + rCfgPosto.Cd_empresa.Trim() + "'"
                                        },
                                        new TpBusca()
                                        {
                                            vNM_Campo = "isnull(a.st_registro, 'A')",
                                            vOperador = "=",
                                            vVL_Busca = "'E'"
                                        },
                                        new TpBusca()
                                        {
                                            vNM_Campo = "a.loginespera",
                                            vOperador = "=",
                                            vVL_Busca = "'" + lSessao[0].Login.Trim() + "'"
                                        }
                                    }, "isnull(count(a.id_venda), 0)").ToString();
                            using (srvNFE.TFGerenciarNFe fGerNfe = new srvNFE.TFGerenciarNFe())
                            {
                                fGerNfe.rNfe = CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento.BuscarNF(rFat.Cd_empresa,
                                                                                                                rFat.Nr_lanctofiscalstr,
                                                                                                                null);
                                fGerNfe.ShowDialog();
                            }
                        }
                        catch (Exception ex)
                        {
                            if (rPed != null)
                                CamadaNegocio.Faturamento.Pedido.TCN_Pedido.Deleta_Pedido(rPed, null);
                            throw new Exception(ex.Message.Trim());
                        }
                    }
                }
                catch (Exception ex)
                {
                    if(!st_vendagravada)
                        lVenda.ForEach(p =>
                            {
                                //Verificar se venda esta faturada
                                if (new CamadaDados.PostoCombustivel.TCD_VendaCombustivel().BuscarEscalar(
                                    new TpBusca[]
                                    {                   
                                        new TpBusca()
                                        {
                                            vNM_Campo = "a.cd_empresa",
                                            vOperador = "=",
                                            vVL_Busca = "'" + p.Cd_empresa.Trim() + "'"
                                        },
                                        new TpBusca()
                                        {
                                            vNM_Campo = "a.id_venda",
                                            vOperador = "=",
                                            vVL_Busca = p.Id_vendastr
                                        },
                                        new TpBusca()
                                        {
                                            vNM_Campo = "a.id_cupom",
                                            vOperador = "is not",
                                            vVL_Busca = "null"
                                        }
                                    }, "1") == null)
                                {
                                    p.St_registro = "A";
                                    p.Id_cupom = null;
                                    p.Id_lancto = null;
                                    CamadaNegocio.PostoCombustivel.TCN_VendaCombustivel.Gravar(p, null);
                                }
                            });
                    MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    tEspera.Fechar();
                    tEspera = null;
                    afterBusca();
                }
            }
        }

        private void miNfEntregaFutura_Click(object sender, EventArgs e)
        {
            bool st_vendagravada = false;
            if (bsVendaCombustivel.Count > 0)
            {
                int cont = (bsVendaCombustivel.List as CamadaDados.PostoCombustivel.TList_VendaCombustivel).Count(p => p.St_processar);
                if (cont.Equals(0))
                {
                    MessageBox.Show("Obrigatorio selecionar abastecida para faturar.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (cont > 1)
                {
                    MessageBox.Show("Não é permitido selecionar mais que uma abastecidade para faturar nota entrega futura.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                //Buscar portador entrega futura
                CamadaDados.Financeiro.Cadastros.TList_CadPortador lPortador =
                    new CamadaDados.Financeiro.Cadastros.TCD_CadPortador().Select(
                    new TpBusca[]
                    {
                        new TpBusca()
                        {
                            vNM_Campo = "a.tp_portadorPDV",
                            vOperador = "=",
                            vVL_Busca = "'A'"
                        },
                        new TpBusca()
                        {
                            vNM_Campo = "isnull(a.st_entregafutura, 'N')",
                            vOperador = "=",
                            vVL_Busca = "'S'"
                        }
                    }, 1, string.Empty, string.Empty);
                if (lPortador.Count.Equals(0))
                {
                    MessageBox.Show("Não existe portador ENTREGA FUTURA cadastrado no sistema.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                DataRowView linha = FormBusca.UtilPesquisa.BTN_BuscaClifor(null, string.Empty);
                if (linha == null)
                {
                    MessageBox.Show("Obrigatório identificar cliente para emitir NFe ENTREGA FUTURA.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                //Buscar endereco do cliente
                object obj = new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco().BuscarEscalar(
                                new TpBusca[]
                                {
                                    new TpBusca()
                                    {
                                        vNM_Campo = "a.cd_clifor",
                                        vOperador = "=",
                                        vVL_Busca = linha["cd_clifor"].ToString()
                                    }
                                }, "a.cd_endereco");
                if (obj == null)
                {
                    MessageBox.Show("Cliente " + linha["nm_clifor"].ToString() + " não possui endereço cadastrado.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                List<CamadaDados.PostoCombustivel.TRegistro_VendaCombustivel> lVenda = new List<CamadaDados.PostoCombustivel.TRegistro_VendaCombustivel>();
                ThreadEspera tEspera = new ThreadEspera("Inicio processo gravar nota fiscal.");
                try
                {
                    (bsVendaCombustivel.List as CamadaDados.PostoCombustivel.TList_VendaCombustivel).FindAll(p => p.St_processar).ForEach(p =>
                    {
                        //Verificar se venda ja nao esta faturada
                        if (new CamadaDados.PostoCombustivel.TCD_VendaCombustivel().BuscarEscalar(
                            new TpBusca[]
                                {
                                    new TpBusca()
                                    {
                                        vNM_Campo = "a.cd_empresa",
                                        vOperador = "=",
                                        vVL_Busca = "'" + rCfgPosto.Cd_empresa.Trim() + "'"
                                    },
                                    new TpBusca()
                                    {
                                        vNM_Campo = "a.id_venda",
                                        vOperador = "=",
                                        vVL_Busca = p.Id_vendastr
                                    },
                                    new TpBusca()
                                    {
                                        vNM_Campo = "isnull(a.st_registro, 'A')",
                                        vOperador = "<>",
                                        vVL_Busca = "'A'"
                                    }
                                }, "1") == null)
                        {
                            p.St_registro = "F";
                            CamadaNegocio.PostoCombustivel.TCN_VendaCombustivel.Gravar(p, null);
                            lVenda.Add(p);
                        }
                    });
                    if (lVenda.Count > 0)
                    {
                        //Buscar Nota Mestra
                        List<CamadaDados.Faturamento.NotaFiscal.TRegistro_NFCompDev> lNfMestra =
                            CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFat_ComplementoDevolucao.Buscar(rCfgPosto.Cd_empresa,
                                                                                                        string.Empty,
                                                                                                        lVenda[0].Cd_produto,
                                                                                                        linha["cd_clifor"].ToString(),
                                                                                                        "S",
                                                                                                        "E",
                                                                                                        false,
                                                                                                        0,
                                                                                                        string.Empty,
                                                                                                        null);
                        if (lNfMestra.Sum(p => p.Sd_qtentregafutura) < lVenda[0].Volumeabastecido)
                            throw new Exception("Não existe saldo suficiente de nota simples faturamento para gerar nota ENTREGA FUTURA.\r\n" +
                                                "Saldo Disponivel: " + lNfMestra.Sum(p => p.Sd_qtentregafutura).ToString("N3", new System.Globalization.CultureInfo("pt-BR")));
                        CamadaDados.Faturamento.NotaFiscal.TList_LanFat_ComplementoDevolucao lNfM = new CamadaDados.Faturamento.NotaFiscal.TList_LanFat_ComplementoDevolucao();
                        decimal saldo_abast = lVenda[0].Volumeabastecido;
                        foreach (CamadaDados.Faturamento.NotaFiscal.TRegistro_NFCompDev nfMestra in lNfMestra)
                        {
                            if (saldo_abast > decimal.Zero)
                            {
                                lNfM.Add(new CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFat_ComplementoDevolucao()
                                {
                                    Cd_empresa = nfMestra.Cd_empresa,
                                    Nr_notafiscal_origem = nfMestra.Nr_notafiscal,
                                    Nr_serie_origem = nfMestra.Nr_serie,
                                    Nr_lanctofiscal_origem = nfMestra.Nr_lanctofiscal,
                                    Id_nfitem_origem = nfMestra.Id_nfitem,
                                    Qtd_lancto = saldo_abast > nfMestra.Sd_qtentregafutura ? nfMestra.Sd_qtentregafutura : saldo_abast,
                                    Vl_lancto = saldo_abast > nfMestra.Sd_qtentregafutura ? nfMestra.Sd_qtentregafutura * nfMestra.Vl_unitario : saldo_abast * nfMestra.Vl_unitario,
                                    Tp_operacao = "E"
                                });
                                saldo_abast -= saldo_abast > nfMestra.Sd_qtentregafutura ? nfMestra.Sd_qtentregafutura : saldo_abast;
                            }
                            else break;
                        }
                        //Gerar objeto venda rapida
                        CamadaDados.Faturamento.PDV.TRegistro_VendaRapida rVendaConsumo = new CamadaDados.Faturamento.PDV.TRegistro_VendaRapida();
                        rVendaConsumo.Cd_clifor = linha["cd_clifor"].ToString();
                        rVendaConsumo.Nm_clifor = linha["nm_clifor"].ToString();
                        rVendaConsumo.Cd_endereco = obj.ToString();
                        rVendaConsumo.Cd_empresa = rCfgPosto.Cd_empresa;
                        rVendaConsumo.Cd_vend = string.Empty;
                        rVendaConsumo.Dt_emissao = CamadaDados.UtilData.Data_Servidor();
                        rVendaConsumo.Id_pdvstr = lPdv[0].Id_pdvstr;
                        rVendaConsumo.Id_sessaostr = lSessao[0].Id_sessaostr;
                        rVendaConsumo.St_registro = "A";
                        //Item Venda
                        lVenda.ForEach(p =>
                        {
                            rVendaConsumo.lItem.Add(new CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item()
                            {
                                //Criar item venda combustivel
                                Cd_local = p.Cd_local,
                                Cd_produto = p.Cd_produto,
                                Ds_produto = p.Ds_produto,
                                Sigla_unidade = p.Sigla_unidade,
                                Cd_condfiscal_produto = p.Cd_condfiscal_produto,
                                Cd_unidade = p.Cd_unidade,
                                Quantidade = p.Volumeabastecido,
                                Vl_unitario = lNfM.Sum(v=> v.Vl_lancto) / lNfM.Sum(v=> v.Qtd_lancto),
                                Vl_subtotal = p.Volumeabastecido * (lNfM.Sum(v => v.Vl_lancto) / lNfM.Sum(v => v.Qtd_lancto)),
                                St_registro = "A",
                                rVendaCombustivel = p
                            });
                        });
                        //Acrescentar portador entrega futura
                        lPortador[0].Vl_pagtoPDV = rVendaConsumo.lItem.Sum(p => p.Vl_subtotal);
                        rVendaConsumo.lPortador = lPortador;
                        CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento rFat =
                                Proc_Commoditties.TProcessaVRVendaFutura.ProcessaVRVendaFutura(rVendaConsumo, lNfM);
                        using (TFPlacaKM fPlaca = new TFPlacaKM())
                        {
                            if (fPlaca.ShowDialog() == DialogResult.OK)
                            {
                                rFat.Dadosadicionais = (!string.IsNullOrEmpty(rFat.Dadosadicionais) ? "\r\n" : string.Empty) +
                                                         "Placa: " + fPlaca.Placa.Trim() +
                                                         " KM: " + fPlaca.Km_atual.ToString() +
                                                         " Frota: " + fPlaca.Nr_frota.Trim() +
                                                         " Requisicao: " + fPlaca.Nr_requisicao.Trim() +
                                                         " Motorista: " + fPlaca.Nm_motorista.Trim() +
                                                         " CPF: " + fPlaca.Cpf_motorista.Trim();
                            }
                        }
                        CamadaNegocio.Faturamento.PDV.TCN_VendaRapida.GravarVendaRapida(rVendaConsumo, null, rFat, null);
                        st_vendagravada = true;
                        //Verificar se venda gerou credito
                        List<string> Texto = new List<string>();
                        Texto.Add("                EXTRATO CREDITO                 ");
                        new CamadaDados.Financeiro.Adiantamento.TCD_LanAdiantamento().Select(
                        new TpBusca[]
                            {
                                new TpBusca()
                                {
                                    vNM_Campo = string.Empty,
                                    vOperador = "exists",
                                    vVL_Busca = "(select 1 from tb_pdv_cupom_x_movcaixa x " +
                                                "where x.id_adto = a.id_adto " +
                                                "and x.cd_empresa = '" + rVendaConsumo.Cd_empresa.Trim() + "' " +
                                                "and x.id_cupom = " + rVendaConsumo.Id_vendarapidastr + ")"
                                }
                            }, 0, string.Empty).ForEach(p =>
                            {
                                Texto.Add("Nº Credito: ".FormatStringDireita(38, ' ') + p.Id_adto.ToString());
                                Texto.Add("Data: ".FormatStringDireita(38, ' ') + p.Dt_lanctostring);
                                Texto.Add("Valor: ".FormatStringDireita(38, ' ') + p.Vl_total_devolver.ToString("N2", new System.Globalization.CultureInfo("pt-BR")));
                            });
                        if (Texto.Count > 1)
                            ImprimirDevCredito(Texto);
                        
                        //Buscar total abastecimentos em espera
                        tslVendaEspera.Text = new CamadaDados.PostoCombustivel.TCD_VendaCombustivel().BuscarEscalar(
                                    new TpBusca[]
                                    {
                                        new TpBusca()
                                        {
                                            vNM_Campo = "a.cd_empresa",
                                            vOperador = "=",
                                            vVL_Busca = "'" + rCfgPosto.Cd_empresa.Trim() + "'"
                                        },
                                        new TpBusca()
                                        {
                                            vNM_Campo = "isnull(a.st_registro, 'A')",
                                            vOperador = "=",
                                            vVL_Busca = "'E'"
                                        },
                                        new TpBusca()
                                        {
                                            vNM_Campo = "a.loginespera",
                                            vOperador = "=",
                                            vVL_Busca = "'" + lSessao[0].Login.Trim() + "'"
                                        }
                                    }, "isnull(count(a.id_venda), 0)").ToString();
                        using (srvNFE.TFGerenciarNFe fGerNfe = new srvNFE.TFGerenciarNFe())
                        {
                            fGerNfe.rNfe = CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento.BuscarNF(rFat.Cd_empresa,
                                                                                                            rFat.Nr_lanctofiscalstr,
                                                                                                            null);
                            fGerNfe.ShowDialog();
                        }
                    }
                    else
                        throw new Exception("Não existe venda combustivel selecionada para faturar.");
                }
                catch (Exception ex)
                {
                    if (!st_vendagravada)
                        lVenda.ForEach(p =>
                        {
                            //Verificar se venda esta faturada
                            if (new CamadaDados.PostoCombustivel.TCD_VendaCombustivel().BuscarEscalar(
                                new TpBusca[]
                                    {                   
                                        new TpBusca()
                                        {
                                            vNM_Campo = "a.cd_empresa",
                                            vOperador = "=",
                                            vVL_Busca = "'" + p.Cd_empresa.Trim() + "'"
                                        },
                                        new TpBusca()
                                        {
                                            vNM_Campo = "a.id_venda",
                                            vOperador = "=",
                                            vVL_Busca = p.Id_vendastr
                                        },
                                        new TpBusca()
                                        {
                                            vNM_Campo = "a.id_cupom",
                                            vOperador = "is not",
                                            vVL_Busca = "null"
                                        }
                                    }, "1") == null)
                            {
                                p.St_registro = "A";
                                p.Id_cupom = null;
                                p.Id_lancto = null;
                                CamadaNegocio.PostoCombustivel.TCN_VendaCombustivel.Gravar(p, null);
                            }
                        });
                    MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    tEspera.Fechar();
                    tEspera = null;
                    afterBusca();
                }
            }
        }

        private void faturarOSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FaturarOS();
        }

        private void miTrocarEspecie_Click(object sender, EventArgs e)
        {
            using (PDV.TFTrocaEspecie fTrocar = new PDV.TFTrocaEspecie())
            {
                fTrocar.pCd_empresa = rCfgPosto.Cd_empresa;
                fTrocar.pNm_empresa = rCfgPosto.Nm_empresa;
                fTrocar.pId_caixa = rCaixa.Id_caixastr;
                fTrocar.pCd_contager = lCfg[0].Cd_contaoperacional;
                fTrocar.pDs_contager = lCfg[0].Ds_contaoperacional;
                fTrocar.pCd_historico = lCfg[0].Cd_historico;
                fTrocar.pDs_historico = lCfg[0].Ds_historico;
                if(fTrocar.ShowDialog() == DialogResult.OK)
                    if(fTrocar.rTroca != null)
                        try
                        {
                            CamadaNegocio.Faturamento.PDV.TCN_TrocaEspecie.Gravar(fTrocar.rTroca, null);
                            MessageBox.Show("Troca especie gravada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            try
                            {
                                //Imprimir comprovante troca
                                List<string> Texto = new List<string>();
                                Texto.Add("TROCA ESPECIE".PadLeft(14, ' ').PadRight(34, ' '));
                                Texto.Add("".FormatStringDireita(48, '-'));
                                Texto.Add(("Nº Operação: " + fTrocar.rTroca.Id_trocastr).FormatStringDireita(48, ' '));
                                Texto.Add(("Nº Caixa: " + rCaixa.Id_caixastr).FormatStringDireita(48, ' '));
                                Texto.Add(("Operador: " + LoginPdv).FormatStringDireita(48, ' '));
                                Texto.Add(("Data Operação: " + CamadaDados.UtilData.Data_Servidor().ToString("dd/MM/yyyy hh:MM")).FormatStringDireita(48, ' '));

                                if (fTrocar.rTroca.rCheque != null)
                                {
                                    Texto.Add(("Nº Cheque: " + fTrocar.rTroca.rCheque.Nr_cheque + " Banco: " + fTrocar.rTroca.rCheque.Cd_banco.Trim() + " Valor: " + fTrocar.rTroca.rCheque.Vl_titulo.ToString("C2", new System.Globalization.CultureInfo("pt-BR"))).FormatStringDireita(48, ' '));
                                }
                                else if (fTrocar.rTroca.rFatura != null)
                                {
                                    Texto.Add(("Nº Fatura: " + fTrocar.rTroca.rFatura.Id_fatura.Value.ToString() + "     Valor: " + fTrocar.rTroca.rFatura.Vl_fatura.ToString("C2", new System.Globalization.CultureInfo("pt-BR"))).FormatStringDireita(48, ' '));
                                    Texto.Add(("Bandeira: " + fTrocar.rTroca.rFatura.Ds_bandeira.Trim()).FormatStringDireita(48, ' '));
                                }
                                else
                                {
                                    Texto.Add(("Nº Carta: " + fTrocar.rTroca.rCartaFrete.Id_cartafretestr + "     Valor: " + fTrocar.rTroca.rCartaFrete.Vl_documento.ToString("C2", new System.Globalization.CultureInfo("pt-BR"))).FormatStringDireita(48, ' '));
                                    Texto.Add(("Cliente: " + (string.IsNullOrEmpty(fTrocar.rTroca.rCartaFrete.Nm_transportadora) ? fTrocar.rTroca.rCartaFrete.Nm_unidpagadora : fTrocar.rTroca.rCartaFrete.Nm_transportadora)).FormatStringDireita(48, ' '));
                                }
                                Texto.Add(("".FormatStringDireita(48, '-')));
                                if (fTrocar.rTroca.Vl_TaxaFin > decimal.Zero)
                                    Texto.Add(("Taxa Administrativa: " + fTrocar.rTroca.Vl_TaxaFin.ToString("C2", new System.Globalization.CultureInfo("pt-BR"))).FormatStringDireita(48, ' '));
                                if (fTrocar.rTroca.lTrocoCHP != null)
                                {
                                    Texto.Add("TROCO CHEQUE PRÓPRIO".PadLeft(14, ' ').PadRight(34, ' '));
                                    fTrocar.rTroca.lTrocoCHP.ForEach(p =>
                                    {
                                        Texto.Add(("Nº Cheque: " + p.Nr_cheque.Trim() + " Banco: " + p.Cd_banco.Trim() + " Valor: " + p.Vl_titulo.ToString("C2", new System.Globalization.CultureInfo("pt-BR"))).FormatStringDireita(48, ' '));
                                    });
                                }
                                if (fTrocar.rTroca.lTrocoCHT != null)
                                {
                                    Texto.Add("TROCO CHEQUE TERCEIRO".PadLeft(14, ' ').PadRight(34, ' '));
                                    fTrocar.rTroca.lTrocoCHP.ForEach(p =>
                                    {
                                        Texto.Add(("Nº Cheque: " + p.Nr_cheque.Trim() + " Banco: " + p.Cd_banco.Trim() + " Valor: " + p.Vl_titulo.ToString("C2", new System.Globalization.CultureInfo("pt-BR"))).FormatStringDireita(48, ' '));
                                    });
                                }
                                decimal tot_troco = decimal.Zero;
                                if (fTrocar.rTroca.Vl_trocoD > decimal.Zero)
                                {
                                    Texto.Add(("Troco Dinheiro........: " + fTrocar.rTroca.Vl_trocoD.ToString("C2", new System.Globalization.CultureInfo("pt-BR"))).FormatStringDireita(48, ' '));
                                    tot_troco += fTrocar.rTroca.Vl_trocoD;
                                }
                                if (fTrocar.rTroca.lTrocoCHP != null)
                                {
                                    Texto.Add(("Troco Ch. Proprio.....: " + fTrocar.rTroca.lTrocoCHP.Sum(p => p.Vl_titulo).ToString("C2", new System.Globalization.CultureInfo("pt-BR"))).FormatStringDireita(48, ' '));
                                    tot_troco += fTrocar.rTroca.lTrocoCHP.Sum(p => p.Vl_titulo);
                                }
                                if (fTrocar.rTroca.lTrocoCHT != null)
                                {
                                    Texto.Add(("Troco Ch. Terceiro..: " + fTrocar.rTroca.lTrocoCHT.Sum(p => p.Vl_titulo).ToString("C2", new System.Globalization.CultureInfo("pt-BR"))).FormatStringDireita(48, ' '));
                                    tot_troco += fTrocar.rTroca.lTrocoCHT.Sum(p => p.Vl_titulo);
                                }
                                Texto.Add(("Total Troco.............: " + tot_troco.ToString("C2", new System.Globalization.CultureInfo("pt-BR"))).FormatStringDireita(48, ' '));
                                ImprimirTrocaEspecie(Texto);
                            }
                            catch { MessageBox.Show("Erro imprimir comprovante.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void miCancelarEmprestimoConcedido_Click(object sender, EventArgs e)
        {
            //Buscar emprestimo concedido
            using (TFListaEmpCondedido fEmp = new TFListaEmpCondedido())
            {
                fEmp.Id_caixa = rCaixa.Id_caixastr;
                if(fEmp.ShowDialog() == DialogResult.OK)
                    if(fEmp.rEmp != null)
                        try
                        {
                            CamadaNegocio.Faturamento.PDV.TCN_EmprestimoConcedido.Excluir(fEmp.rEmp, null);
                            MessageBox.Show("Emprestimo estornado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void miEstornarTrocaEspecie_Click(object sender, EventArgs e)
        {
            using (TFListaTrocaEspecie fTroca = new TFListaTrocaEspecie())
            {
                fTroca.Id_caixa = rCaixa.Id_caixastr;
                if(fTroca.ShowDialog() == DialogResult.OK)
                    if(fTroca.rTroca != null)
                        try
                        {
                            CamadaNegocio.Faturamento.PDV.TCN_TrocaEspecie.Estornar(fTroca.rTroca, null);
                            MessageBox.Show("Troca especie estornada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            try
                            {
                                //Imprimir comprovante troca
                                List<string> Texto = new List<string>();
                                Texto.Add("ESTORNO TROCA ESPECIE".PadLeft(48, ' '));
                                Texto.Add("".FormatStringDireita(48, '-'));
                                Texto.Add(("Nº Operação: " + fTroca.rTroca.Id_trocastr).FormatStringDireita(48, ' '));
                                Texto.Add(("Nº Caixa: " + fTroca.rTroca.Id_caixastr).FormatStringDireita(48, ' '));
                                Texto.Add(("Operador: " + LoginPdv).FormatStringDireita(48, ' '));
                                Texto.Add(("Data Operação: " + CamadaDados.UtilData.Data_Servidor().ToString("dd/MM/yyyy")).FormatStringDireita(48, ' '));
                                Texto.Add(("Especie: " + fTroca.rTroca.Ds_portador.Trim() +" Valor: " + fTroca.rTroca.Vl_especie.ToString("C2", new System.Globalization.CultureInfo("pt-BR"))).FormatStringDireita(48, ' '));
                                if (fTroca.rTroca.Nr_lanctocheque.HasValue)
                                    Texto.Add(("Nº Cheque: " + fTroca.rTroca.Nr_lanctochequestr + "     Banco: " + fTroca.rTroca.Cd_banco.Trim()).FormatStringDireita(48, ' '));
                                if (fTroca.rTroca.Id_fatura.HasValue)
                                    Texto.Add(("Nº Fatura: " + fTroca.rTroca.Id_faturastr).FormatStringDireita(48, ' '));
                                if (fTroca.rTroca.Id_cartafrete.HasValue)
                                    Texto.Add(("Nº Carta Frete: " + fTroca.rTroca.Id_cartafretestr).FormatStringDireita(48, ' '));
                                Texto.Add(("Taxa Administrativa: ").FormatStringDireita(30, ' ') + fTroca.rTroca.Vl_TaxaFin.ToString("C2", new System.Globalization.CultureInfo("pt-BR")));
                                if (fTroca.rTroca.Vl_trocoD > decimal.Zero)
                                    Texto.Add(("Troco Dinheiro....: " + fTroca.rTroca.Vl_trocoD.ToString("C2", new System.Globalization.CultureInfo("pt-BR"))).FormatStringDireita(48, ' '));
                                if (fTroca.rTroca.Vl_trocoCHP > decimal.Zero)
                                    Texto.Add(("Troco Ch. Proprio.: " + fTroca.rTroca.Vl_trocoCHP.ToString("C2", new System.Globalization.CultureInfo("pt-BR"))).FormatStringDireita(48, ' '));
                                if (fTroca.rTroca.Vl_trocoCHT > decimal.Zero)
                                    Texto.Add(("Troco Ch. Terceiro: " + fTroca.rTroca.Vl_trocoCHT.ToString("C2", new System.Globalization.CultureInfo("pt-BR"))).FormatStringDireita(48, ' '));
                                ImprimirTrocaEspecie(Texto);
                            }
                            catch { MessageBox.Show("Erro imprimir comprovante de estorno.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }
        
        private void placa_Leave(object sender, EventArgs e)
        {
            if (placa.Text.Trim().Length != 8)
                placa.Clear();
        }

        private void placa_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = Convert.ToChar(e.KeyChar.ToString().ToUpper());
        }

        private void devolverCreditoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (Financeiro.TFSaldoCreditos fSaldo = new Financeiro.TFSaldoCreditos())
            {
                fSaldo.Cd_empresa = lCfg[0].Cd_empresa;
                fSaldo.Tp_mov = "'R'";
                fSaldo.St_adtoUnico = true;
                if (fSaldo.ShowDialog() == DialogResult.OK)
                    if (fSaldo.lSaldo != null)
                        using (Financeiro.TFTrocoPDV fTroco = new Financeiro.TFTrocoPDV())
                        {
                            fTroco.Cd_empresa = lCfg[0].Cd_empresa;
                            fTroco.Id_caixaPDV = rCaixa.Id_caixastr;
                            fTroco.Vl_troco = fSaldo.lSaldo.Sum(p => p.Vl_processar);
                            fTroco.St_desativarCred = true;
                            if (fTroco.ShowDialog() == DialogResult.OK)
                            {
                                CamadaNegocio.Faturamento.PDV.TCN_Caixa_X_DevCredAvulso.DevolverCredito(
                                    new CamadaDados.Faturamento.PDV.TRegistro_Caixa_X_DevCredAvulso()
                                    {
                                        Cd_empresa = lCfg[0].Cd_empresa,
                                        Id_caixa = rCaixa.Id_caixa,
                                        rAdto = fSaldo.lSaldo[0],
                                        lDevCHP = fTroco.lChTroco,
                                        lDevCHT = fTroco.lChRepasse
                                    }, null);
                                MessageBox.Show("Credito devolvido com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                                MessageBox.Show("Obrigatorio informar valor total troco para especie.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
            }
        }

        private void estornarDevoluçãoCréditoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (Proc_Commoditties.TFListaDevCredAvulso fLista = new Proc_Commoditties.TFListaDevCredAvulso())
            {
                fLista.Id_caixa = rCaixa.Id_caixastr;
                if (fLista.ShowDialog() == DialogResult.OK)
                    if (fLista.rDev != null)
                        try
                        {
                            CamadaNegocio.Faturamento.PDV.TCN_Caixa_X_DevCredAvulso.EstornarDevCredito(fLista.rDev, null);
                            MessageBox.Show("Devolução credito estornada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void devolverVendaCFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (Proc_Commoditties.TFDevolverECF fDev = new Proc_Commoditties.TFDevolverECF())
            {
                if (fDev.ShowDialog() == DialogResult.OK)
                    try
                    {
                        CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento rFat =
                        Proc_Commoditties.TProcessarNFDevVendaCF.ProcessarDevVendaCF(fDev.pCd_cliente, fDev.rCF);
                        CamadaNegocio.Faturamento.PDV.TCN_DevolucaoCF.ProcessarNFDevolucao(rFat, null);
                        using (srvNFE.TFGerenciarNFe fGerNfe = new srvNFE.TFGerenciarNFe())
                        {
                            fGerNfe.rNfe = CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento.BuscarNF(rFat.Cd_empresa,
                                                                                                            rFat.Nr_lanctofiscalstr,
                                                                                                            null);
                            fGerNfe.ShowDialog();
                        }
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void listaClientesNegativadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (Financeiro.TFListaCliforInadimplente fClifor = new Financeiro.TFListaCliforInadimplente())
            {
                fClifor.ShowDialog();
            }
        }

        private void consultarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (TFConsultaValeResgate fConsulta = new TFConsultaValeResgate())
            {
                fConsulta.rCfgPosto = rCfgPosto;
                fConsulta.LoginPDV = LoginPdv;
                fConsulta.ShowDialog();
            }
        }

        private void bb_cartao_Click(object sender, EventArgs e)
        {
            FaturarVenda("C");
        }

        private void cancelarNFCeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (TFCancelarNFe fCanc = new TFCancelarNFe())
            {
                fCanc.Cd_empresa = rCfgPosto.Cd_empresa;
                fCanc.Nm_empresa = rCfgPosto.Nm_empresa;
                fCanc.St_nfce = true;
                fCanc.ShowDialog();
            }
        }

        private void consultarNFCeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConsultaNfe("NFCE");
        }

        private void tmpSemaforo_Tick(object sender, EventArgs e)
        {
            tmpSemaforo.Enabled = false;
            if (!bgwSemafaro.IsBusy)
                bgwSemafaro.RunWorkerAsync();
        }

        private void lblNFe_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(lblNFe.Text))
                ConsultaNfe("NFE");
        }

        private void lblNFCe_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(lblNFCe.Text))
                ConsultaNfe("NFCE");
        }

        private void bb_afericao_Click(object sender, EventArgs e)
        {
            AfericaoBomba();
        }

        private void placa_TextChanged(object sender, EventArgs e)
        {
            if(placa.Text.Length.Equals(8))
            {
                //Verificar se placa cadastrada
                object obj = new CamadaDados.PostoCombustivel.TCD_Convenio_Placa().BuscarEscalar(
                                new TpBusca[]
                                {
                                new TpBusca()
                                {
                                    vNM_Campo = "a.cd_empresa",
                                    vOperador = "=",
                                    vVL_Busca = "'" + rCfgPosto.Cd_empresa.Trim() + "'"
                                },
                                new TpBusca()
                                {
                                    vNM_Campo = "isnull(c.st_registro, 'A')",
                                    vOperador = "=",
                                    vVL_Busca = "'A'"
                                },
                                new TpBusca()
                                {
                                    vNM_Campo = "CONVERT(datetime, floor(convert(decimal(30,10), case when c.DiasValidade = 0 then getdate() else DATEADD(DAY, c.DiasValidade, c.DT_Convenio) end)))",
                                    vOperador = ">=",
                                    vVL_Busca = "CONVERT(datetime, floor(convert(decimal(30,10), getdate())))"
                                },
                                new TpBusca()
                                {
                                    vNM_Campo = "isnull(b.st_registro, 'A')",
                                    vOperador = "<>",
                                    vVL_Busca = "'C'"
                                },
                                new TpBusca()
                                {
                                    vNM_Campo = "case when b.qtd_convenio > 0 then b.qtd_convenio - b.qtd_vendida else 1 end",
                                    vOperador = ">",
                                    vVL_Busca = "0"
                                },
                                new TpBusca()
                                {
                                    vNM_Campo = "a.placa",
                                    vOperador = "=",
                                    vVL_Busca = "'" + placa.Text.Trim() + "'"
                                }
                                }, "a.cd_clifor");
                if (obj != null)
                {
                    St_placacadastrada = true;
                    Cd_clifor.Text = obj.ToString();
                    cd_clifor_Leave(this, new EventArgs());
                    FaturarVenda(string.Empty);
                }
                else
                    St_placacadastrada = false;
            }
        }

        private void entrarContingenciaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(new CamadaDados.Faturamento.PDV.TCD_ContingenciaNFCeOFF().BuscarEscalar(
                new TpBusca[]
                {
                    new TpBusca()
                    {
                        vNM_Campo = "a.cd_empresa",
                        vOperador = "=",
                        vVL_Busca = "'" + rCfgPosto.Cd_empresa.Trim() + "'"
                    },
                    new TpBusca()
                    {
                        vNM_Campo = "a.id_pdv",
                        vOperador = "=",
                        vVL_Busca = lPdv[0].Id_pdvstr
                    },
                    new TpBusca()
                    {
                        vNM_Campo = "isnull(a.st_registro, 'A')",
                        vOperador = "=",
                        vVL_Busca = "'A'"
                    }
                }, "1") != null)
            {
                MessageBox.Show("PDV já esta com CONTINGÊNCIA.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            InputBox msg = new InputBox();
            msg.Text = "Informe justificativa para contingência";
            string str = msg.ShowDialog();
            if (string.IsNullOrEmpty(str) ||
                str.Trim().Length < 15)
            {
                MessageBox.Show("Obrigatorio informar pelo menos 15 caracteres como JUSTIFICATIVA.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            try
            {
                CamadaNegocio.Faturamento.PDV.TCN_ContingenciaNFCeOFF.Gravar(lPdv,
                                                                            rCfgPosto.Cd_empresa,
                                                                            str,
                                                                            null);
                MessageBox.Show("Contingência gravada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lblContingencia.ImageIndex = 3;
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void sairContingênciaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CamadaDados.Faturamento.PDV.TList_ContingenciaNFCeOFF lContingencia =
                CamadaNegocio.Faturamento.PDV.TCN_ContingenciaNFCeOFF.Buscar(rCfgPosto.Cd_empresa,
                                                                             lPdv[0].Id_pdvstr,
                                                                             "'A'",
                                                                             null);
            if (lContingencia.Count > 0)
            {
                try
                {
                    CamadaNegocio.Faturamento.PDV.TCN_ContingenciaNFCeOFF.SairContingencia(lContingencia, null);
                    MessageBox.Show("Contingência alterada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    lblContingencia.ImageIndex = 0;
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
            else MessageBox.Show("PDV não se encontra em contingência.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void bgwSemafaro_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            tb_semafaro = new CamadaDados.TDataQuery().ExecutarBusca(
                                    "select " +
                                    "qtd_nfe = (select count(*) " +
                                    "			from TB_FAT_NOTAFISCAL a " +
                                    "			inner join tb_fat_serienf b " +
                                    "			on a.nr_serie = b.nr_serie " +
                                    "			and a.cd_modelo = b.cd_modelo " +
                                    "			inner join tb_div_empresa c " +
                                    "			on a.cd_empresa = c.cd_empresa " +
                                    "           where a.cd_empresa = '" + rCfgPosto.Cd_empresa.Trim() + "' " +
                                    "			and a.CD_Modelo = '55' " +
                                    "			and (isnull(a.st_registro, 'A') <> 'C' ) " +
                                    "			and (a.tp_nota = 'P' ) " +
                                    "			and (b.tp_serie = 'P' or b.tp_serie = 'M') " +
                                    "			and isnull(c.st_registro, 'A') <> 'C' " +
                                    "           and not exists(select 1 from TB_FAT_LoteNFE_X_NotaFiscal x " +
                                    "                           where x.cd_empresa = a.cd_empresa " +
                                    "                           and x.nr_lanctofiscal = a.nr_lanctofiscal)), " +
                                    "qtd_nfeA = (select count(*) " +
                                                "from tb_fat_lotenfe_x_notafiscal a " +
                                                "where isnull(a.status, 0) <> 100 and isnull(a.status, 0) <> 302), " +
                                    "qtd_nfce = (select count(*) " +
                                    "			from tb_pdv_nfce a " +
                                    "			inner join tb_div_empresa b " +
                                    "			on a.cd_empresa = b.cd_empresa " +
                                    "           where a.cd_empresa = '" + rCfgPosto.Cd_empresa.Trim() + "' " +
                                    "			and isnull(b.ST_Registro, 'A') <> 'C' " +
                                    "           and isnull(a.st_registro, 'A') <> 'C' " +
                                    "			and a.CD_Modelo = '65' " +
                                    "			and not exists(select 1 from TB_FAT_Lote_X_NFCe x " +
                                    "							where x.cd_empresa = a.cd_empresa " +
                                    "							and x.id_cupom = a.id_nfce)), " +
                                    "qtd_nfceA = (select count(*) " +
                                                "from tb_fat_lote_x_nfce a " +
                                                "where isnull(a.status, 0) <> 100 and isnull(a.status, 0) <> 150 and isnull(a.status, 0) <> 302) ", null);
        }

        private void bgwSemafaro_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            if (tb_semafaro != null)
                if (tb_semafaro.Rows.Count > 0)
                {
                    //NFe
                    lblNFe.Text = tb_semafaro.Rows[0]["qtd_nfe"].ToString();
                    lblNFe.ImageIndex = tb_semafaro.Rows[0]["qtd_nfe"].ToString() != "0" ? 1 : 0;
                    lblNFeA.Text = tb_semafaro.Rows[0]["qtd_nfea"].ToString();
                    lblNFeA.ImageIndex = tb_semafaro.Rows[0]["qtd_nfea"].ToString() != "0" ? 1 : 0;
                    //NFCe
                    lblNFCe.Text = tb_semafaro.Rows[0]["qtd_nfce"].ToString();
                    lblNFCe.ImageIndex = tb_semafaro.Rows[0]["qtd_nfce"].ToString() != "0" ? 1 : 0;
                    lblNFCeA.Text = tb_semafaro.Rows[0]["qtd_nfcea"].ToString();
                    lblNFCeA.ImageIndex = tb_semafaro.Rows[0]["qtd_nfcea"].ToString() != "0" ? 1 : 0;
                }
            tmpSemaforo.Enabled = true;
        }

        private void cd_produto_Enter(object sender, EventArgs e)
        {
            quantidade.DecimalPlaces = 3;
        }
    }
}
