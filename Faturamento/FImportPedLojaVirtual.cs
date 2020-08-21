using System;
using System.Linq;
using System.Windows.Forms;
using Utils;
using CamadaDados.Financeiro.Cadastros;
using CamadaDados.Faturamento.Pedido;
using CamadaDados.Diversos;
using CamadaNegocio.Financeiro.Cadastros;
using Faturamento.wslojayodog_v2;
using System.Threading.Tasks;
using System.Data;

namespace Faturamento
{
    public partial class TFImportPedLojaVirtual : Form
    {
        private TRegistro_CfgECommerce rCfg { get; set; }
        public TFImportPedLojaVirtual()
        {
            InitializeComponent();
            System.Collections.ArrayList cbx = new System.Collections.ArrayList();
            cbx.Add(new TDataCombo("TODOS", string.Empty));
            cbx.Add(new TDataCombo("FECHADO", "closed"));
            cbx.Add(new TDataCombo("PROCESSANDO", "processing"));
            cbx.Add(new TDataCombo("PAGAMENTO PENDENTE", "pending_payment"));
            cbx.Add(new TDataCombo("ANALISE DE PAGAMENTO", "payment_review"));
            cbx.Add(new TDataCombo("SUSPEITA DE FRAUDE", "fraud"));
            cbx.Add(new TDataCombo("PENDENTE", "pending"));
            cbx.Add(new TDataCombo("SEGURADO", "holded"));
            cbx.Add(new TDataCombo("COMPLETO", "complete"));
            cbx.Add(new TDataCombo("CANCELADO", "canceled"));
            cbx.Add(new TDataCombo("REVERSÃO CANCELADA DO PAYPAL", "paypal_canceled_reversal"));
            cbx.Add(new TDataCombo("PAYPAL PENDENTE", "pending_paypal"));
            cbx.Add(new TDataCombo("REVERSÃO DO PAYPAL", "paypal_reversed"));
            cbStatus.DataSource = cbx;
            cbStatus.DisplayMember = "Display";
            cbStatus.ValueMember = "Value";
            cbStatus.SelectedIndex = 0;
        }

        private void TFImportPedLojaVirtual_Load(object sender, EventArgs e)
        {
            Icon = ResourcesUtils.TecnoAliance_ICO;
            cbLoja.DataSource = new TCD_LojaVirtual().Select(
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
                                                    "       where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))"
                                    }
                                }, 0, string.Empty);
            cbLoja.DisplayMember = "NM_Loja";
            cbLoja.ValueMember = "ID_Loja";
            dt_ini.Text = DateTime.Now.ToString("dd/MM/yyyy");
            tlpPedido.ColumnStyles[1].Width = 0;
        }

        private void bbDownload_Click(object sender, EventArgs e)
        {
            if(cbLoja.SelectedItem == null)
            {
                MessageBox.Show("Obrigatório selecionar loja.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbLoja.Focus();
                return;
            }
            if (string.IsNullOrEmpty((cbLoja.SelectedItem as TRegistro_LojaVirtual).UserName))
            {
                MessageBox.Show("Não existe USERNAME cadastrado para loja.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (string.IsNullOrEmpty((cbLoja.SelectedItem as TRegistro_LojaVirtual).ApiKey))
            {
                MessageBox.Show("Não existe APIKEY cadastrado para loja.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            MagentoService api = new MagentoService();
            string sessao = string.Empty;
            try
            {
                sessao = api.login((cbLoja.SelectedItem as TRegistro_LojaVirtual).UserName, (cbLoja.SelectedItem as TRegistro_LojaVirtual).ApiKey);
                filters mf = new filters();
                complexFilter[] cpf = new complexFilter[0];
                if(cbStatus.SelectedIndex > 0)
                {
                    complexFilter mcpf = new complexFilter();
                    mcpf.key = "status";
                    associativeEntity mas = new associativeEntity();
                    mas.key = "=";
                    mas.value = cbStatus.SelectedValue.ToString();
                    mcpf.value = mas;
                    Array.Resize(ref cpf, cpf.Length + 1);
                    cpf[cpf.Length - 1] = mcpf;
                }
                if(!string.IsNullOrEmpty(dt_ini.Text.SoNumero()))
                {
                    complexFilter mcpf = new complexFilter();
                    mcpf.key = "created_at";
                    associativeEntity mas = new associativeEntity();
                    mas.key = "from";
                    mas.value = DateTime.Parse(dt_ini.Text).ToString("yyyy-MM-dd") + " 00:00:00";
                    mcpf.value = mas;
                    Array.Resize(ref cpf, cpf.Length + 1);
                    cpf[cpf.Length - 1] = mcpf;
                }
                mf.complex_filter = cpf;
                salesOrderListEntity[] lista = api.salesOrderList(sessao, mf);
                if (lista.Length > 0)
                {
                    TList_Pedido lPedido = new TList_Pedido();
                    lista.ToList().ForEach(p =>
                      {
                          object obj = new TCD_Pedido().BuscarEscalar(
                                        new TpBusca[]
                                        {
                                            new TpBusca()
                                            {
                                                vNM_Campo = "a.Nr_PedidoOrigem",
                                                vOperador = "=",
                                                vVL_Busca = "'" + p.increment_id.Trim() + "'"
                                            }
                                        }, "a.nr_pedido");
                          lPedido.Add(new TRegistro_Pedido()
                          {
                              Nr_PedidoOrigem = p.increment_id,
                              Vl_totalpedido = decimal.Divide(int.Parse(p.grand_total.SoNumero()), 10000),
                              StatusMagento = p.status,
                              NM_Clifor = p.firstname.Trim() + " " + p.lastname.Trim(),
                              Nr_pedido = obj == null ? 0 : decimal.Parse(obj.ToString()),
                              DT_Pedido = DateTime.Parse(p.created_at)
                          });
                      });
                    bsPedLoja.DataSource = lPedido;
                }
            }
            catch(Exception ex)
            { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally
            {
                if(!string.IsNullOrWhiteSpace(sessao))
                    api.endSession(sessao);
            }
        }
        
        private void bbCancelar_Click(object sender, EventArgs e)
        {
            bsPedido.Clear();
            gPedido.Enabled = true;
            bbImportar.Enabled = true;
            tlpPedido.ColumnStyles[1].Width = 0;
        }

        private void cbLoja_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbLoja.SelectedItem != null)
            {
                TList_CfgECommerce lCfg = CamadaNegocio.Diversos.TCN_CfgECommerce.Buscar((cbLoja.SelectedItem as TRegistro_LojaVirtual).Cd_empresa, null);
                if (lCfg.Count > 0)
                    rCfg = lCfg[0];
            }
        }

        private void bbConfirma_Click(object sender, EventArgs e)
        {
            if(bsPedido.Current != null)
            {
                if((bsPedido.Current as TRegistro_Pedido).Pedido_Itens.Exists(p=> string.IsNullOrEmpty(p.Cd_produto)))
                {
                    MessageBox.Show("Obrigatório informar produto para todos os itens do pedido.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                try
                {
                    (bsPedLoja.Current as TRegistro_Pedido).Nr_pedido =
                    decimal.Parse(CamadaNegocio.Faturamento.Pedido.TCN_Pedido.Grava_Pedido(bsPedido.Current as TRegistro_Pedido, null));
                    MessageBox.Show("Pedido IMPORTADO com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    bsPedLoja.ResetCurrentItem();
                    bbCancelar_Click(this,new EventArgs());
                }
                catch(Exception ex)
                { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void bbImportar_Click(object sender, EventArgs e)
        {
            //071.548.686-19
            if (bsPedLoja.Current != null)
            {
                if ((bsPedLoja.Current as TRegistro_Pedido).Nr_pedido.ToString().Trim() != "0")
                {
                    MessageBox.Show("Não é permitido IMPORTAR pedido novamente.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if ((bsPedLoja.Current as TRegistro_Pedido).StatusMagento.Trim().ToUpper().Equals("CANCELADO"))
                {
                    MessageBox.Show("Não é permitido IMPORTAR pedido CANCELADO.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (rCfg == null)
                {
                    MessageBox.Show("Não existe configuração E-commerce para loja selecionada.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                MagentoService api = new MagentoService();
                string sessao = string.Empty;
                try
                {
                    sessao = api.login((cbLoja.SelectedItem as TRegistro_LojaVirtual).UserName, (cbLoja.SelectedItem as TRegistro_LojaVirtual).ApiKey);
                    salesOrderEntity ePed = api.salesOrderInfo(sessao, (bsPedLoja.Current as TRegistro_Pedido).Nr_PedidoOrigem);
                    if (ePed != null)
                    {
                        TRegistro_Pedido rPedido = new TRegistro_Pedido();
                        //Buscar Cliente
                        customerCustomerEntity eCliente = api.customerCustomerInfo(sessao, int.Parse(ePed.customer_id), null);
                        //Verificar se cliente existe no Aliance
                        TList_CadClifor lCliente = new TCD_CadClifor().Select(
                                                    new TpBusca[]
                                                    {
                                                        new TpBusca()
                                                        {
                                                            vNM_Campo = string.Empty,
                                                            vOperador = string.Empty,
                                                            vVL_Busca = "dbo.FVALIDA_NUMEROS(a.nr_cgc) = '" + eCliente.taxvat.Trim() + "' " +
                                                                        "or dbo.FVALIDA_NUMEROS(a.nr_cpf) = '" + eCliente.taxvat.Trim() + "'"
                                                        }
                                                    }, 1, string.Empty);
                        if (lCliente.Count > 0)
                        {
                            rPedido.CD_Clifor = lCliente[0].Cd_clifor;
                            rPedido.NM_Clifor = lCliente[0].Nm_clifor;
                            //Buscar endereco cliente
                            TList_CadEndereco lEnd =
                                new TCD_CadEndereco().Select(
                                    new TpBusca[]
                                    {
                                        new TpBusca()
                                        {
                                            vNM_Campo = "a.cd_clifor",
                                            vOperador = "=",
                                            vVL_Busca = "'" + lCliente[0].Cd_clifor.Trim() + "'"
                                        }
                                    }, 1, string.Empty);
                            if (lEnd.Count > 0)
                            {
                                rPedido.CD_Endereco = lEnd[0].Cd_endereco;
                                rPedido.DS_Endereco = lEnd[0].Ds_endereco;
                                numero.Text = lEnd[0].Numero;
                                bairro.Text = lEnd[0].Bairro;
                                ds_cidade.Text = lEnd[0].DS_Cidade;
                                uf.Text = lEnd[0].UF;
                            }
                        }
                        else
                        {
                            TRegistro_CadClifor rClifor = new TRegistro_CadClifor();
                            rClifor.Nm_clifor = eCliente.firstname.Trim().ToUpper() + " " + eCliente.lastname.Trim().ToUpper();
                            rClifor.Email = eCliente.email.Trim();
                            rClifor.Tp_pessoa = eCliente.taxvat.Trim().Length.Equals(14) ? "J" : "F";
                            rClifor.Nr_cgc = eCliente.taxvat.Trim().Length.Equals(14) ? eCliente.taxvat.Trim() : string.Empty;
                            rClifor.Nr_cpf = !eCliente.taxvat.Trim().Length.Equals(14) ? eCliente.taxvat.Trim() : string.Empty;
                            rClifor.Id_categoriaclifor = rCfg.Id_categoriaclifor;
                            rClifor.Cd_condfiscal_clifor = rCfg.Cd_condfiscal_clifor;
                            TRegistro_CadEndereco rEndereco = new TRegistro_CadEndereco();
                            rEndereco.Cep = ePed.billing_address.postcode;
                            //Buscar Endereco Rest
                            TEndereco_CEPRest eRest = ServiceRest.DataService.BuscarEndCEPRest(rEndereco.Cep);
                            if (eRest != null)
                            {
                                rEndereco.Ds_endereco = eRest.logradouro;
                                rEndereco.Ds_complemento = eRest.complemento;
                                rEndereco.Bairro = eRest.bairro;
                                rEndereco.Cd_cidade = eRest.ibge;
                                string[] str = ePed.billing_address.street.Split(new char[] { '\n' });
                                if (str.Length >= 2)
                                    rEndereco.Numero = str[1];
                            }
                            else
                            {
                                string[] str = ePed.billing_address.street.Split(new char[] { '\n' });
                                if (str.Length >= 4)
                                {
                                    rEndereco.Ds_endereco = str[0];
                                    rEndereco.Bairro = str[3];
                                    rEndereco.Numero = str[1];
                                }
                            }
                            rClifor.lEndereco.Add(rEndereco);
                            using (Financeiro.Cadastros.TFCadCliforResumido fClifor = new Financeiro.Cadastros.TFCadCliforResumido())
                            {
                                fClifor.rClifor = rClifor;
                                if (fClifor.ShowDialog() == DialogResult.OK)
                                    try
                                    {
                                        TCN_CadClifor.Gravar(fClifor.rClifor, null);
                                        MessageBox.Show("Cliente cadastrado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        rPedido.CD_Clifor = fClifor.rClifor.Cd_clifor;
                                        rPedido.NM_Clifor = fClifor.rClifor.Nm_clifor;
                                        rPedido.CD_Endereco = fClifor.rClifor.lEndereco[0].Cd_endereco;
                                        rPedido.DS_Endereco = fClifor.rClifor.lEndereco[0].Ds_endereco;
                                        numero.Text = fClifor.rClifor.lEndereco[0].Numero;
                                        bairro.Text = fClifor.rClifor.lEndereco[0].Bairro;
                                        ds_cidade.Text = fClifor.rClifor.lEndereco[0].DS_Cidade;
                                        uf.Text = fClifor.rClifor.lEndereco[0].UF;
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        return;
                                    }
                                else
                                {
                                    MessageBox.Show("Obrigatório cadastrar cliente para importar pedido.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    return;
                                }
                            }
                        }
                        rPedido.cd_empresa = (cbLoja.SelectedItem as TRegistro_LojaVirtual).Cd_empresa;
                        rPedido.Nm_Empresa = (cbLoja.SelectedItem as TRegistro_LojaVirtual).Nm_empresa;
                        rPedido.Nr_PedidoOrigem = (bsPedLoja.Current as TRegistro_Pedido).Nr_PedidoOrigem;
                        rPedido.CFG_Pedido = rCfg.Cfg_pedido;
                        rPedido.TP_Movimento = "S";//Venda
                        rPedido.DT_Pedido = CamadaDados.UtilData.Data_Servidor();
                        rPedido.ST_Pedido = "F";
                        rPedido.St_registro = "F";
                        rPedido.Cd_moeda = rCfg.Cd_moeda;
                        rPedido.Tp_frete = decimal.Divide(decimal.Parse(ePed.shipping_amount.SoNumero()), 10000) > 0 ? "1" : "9";
                        rPedido.QUANTIDADENF = decimal.Divide(decimal.Parse(ePed.total_qty_ordered.SoNumero()), 10000);
                        //Endereco Entrega
                        TEndereco_CEPRest endRest = ServiceRest.DataService.BuscarEndCEPRest(ePed.shipping_address.postcode.Trim());
                        if (endRest != null)
                        {
                            rPedido.Logradouroent = endRest.logradouro;
                            rPedido.Complementoent = endRest.complemento;
                            rPedido.Bairroent = endRest.bairro;
                            rPedido.Cd_cidadeent = endRest.ibge;
                        }
                        string[] eEnt = ePed.shipping_address.street.Split(new char[] { '\n' });
                        if (eEnt.Length >= 4)
                        {
                            rPedido.Logradouroent = eEnt[0];
                            rPedido.Numeroent = eEnt[1];
                            rPedido.Complementoent = eEnt[2];
                            rPedido.Bairroent = eEnt[3];
                        }
                        //Itens do pedido
                        foreach (salesOrderItemEntity item in ePed.items)
                        {   
                            foreach(salesOrderItemEntity nitem in ePed.items)
                            {
                                if (item.sku.ToString().Equals(nitem.sku.ToString()) &&
                                    decimal.Divide(decimal.Parse(nitem.price.SoNumero()), 10000) == decimal.Zero)
                                {
                                    item.name = nitem.name;
                                    item.product_id = nitem.product_id;
                                    break;
                                }                                    
                            }                     

                            if (decimal.Divide(decimal.Parse(item.price.SoNumero()), 10000) > decimal.Zero)
                            {
                                TRegistro_LanPedido_Item rItem = new TRegistro_LanPedido_Item();
                                rItem.Cd_referencia = item.product_id;
                                //Buscar Produto
                                CamadaDados.Estoque.Cadastros.TList_CadProduto lProd =
                                new CamadaDados.Estoque.Cadastros.TCD_CadProduto().Select(
                                    new TpBusca[]
                                    {
                                    new TpBusca()
                                    {
                                        vNM_Campo = "a.codigo_alternativo",
                                        vOperador = "=",
                                        vVL_Busca = "'" + item.product_id.Trim() + "'"
                                    },
                                    new TpBusca()
                                    {
                                        vNM_Campo = "isnull(a.st_registro, 'A')",
                                        vOperador = "<>",
                                        vVL_Busca = "'C'"
                                    }
                                    }, 1, string.Empty, string.Empty, string.Empty);
                                if (lProd.Count > 0)
                                {
                                    rItem.Cd_produto = lProd[0].CD_Produto;
                                    rItem.Ds_produto = lProd[0].DS_Produto;
                                    rItem.Cd_unidade_est = lProd[0].CD_Unidade;
                                    rItem.Ds_unidade_est = lProd[0].DS_Unidade;
                                    rItem.Sg_unidade_est = lProd[0].Sigla_unidade;
                                    rItem.Cd_unidade_valor = lProd[0].CD_Unidade;
                                    rItem.Ds_unidade_valor = lProd[0].DS_Unidade;
                                    rItem.Sg_unidade_valor = lProd[0].Sigla_unidade;
                                }
                                else rItem.Ds_produto = item.name.Trim().ToUpper();
                                rItem.Quantidade = decimal.Divide(decimal.Parse(item.qty_ordered.SoNumero()), 10000);
                                rItem.Vl_unitario = decimal.Divide(decimal.Parse(item.price.SoNumero()), 10000);
                                rItem.Vl_subtotal = decimal.Divide(decimal.Parse(item.row_total.SoNumero()), 10000);
                                rItem.Vl_desc = decimal.Divide(decimal.Parse(item.discount_amount.SoNumero()), 10000);
                                rItem.Cd_local = rCfg.Cd_local;
                                rPedido.Pedido_Itens.Add(rItem);
                            }
                            //Ratear Frete
                            rPedido.Vl_frete = decimal.Divide(decimal.Parse(ePed.shipping_amount.SoNumero()), 10000);
                            if (rPedido.Vl_frete > decimal.Zero)
                                CamadaNegocio.Faturamento.Pedido.TCN_Pedido.Rateia_Frete(rPedido);
                            bsPedido.DataSource = new TList_Pedido { rPedido };
                        }
                    }
                    gPedido.Enabled = false;
                    bbImportar.Enabled = false;
                    tlpPedido.ColumnStyles[1].Width = 623;
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                finally
                { api.endSession(sessao); }
            }
        }

        //alteração do produto vinculado
        private void alterarProdutoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (bsItensPed.Current != null)
                if (!string.IsNullOrEmpty((bsItensPed.Current as TRegistro_LanPedido_Item).Cd_produto))
                {
                    DataRowView linha = FormBusca.UtilPesquisa.BTN_BuscaProduto(null, string.Empty);
                    if (linha != null)
                        try
                        {
                            new CamadaDados.TDataQuery().executarSql("update tb_est_produto set codigo_alternativo = null" +
                                " where cd_produto = '" + linha["cd_produto"].ToString() + "'", null);

                            new CamadaDados.TDataQuery().executarSql("update tb_est_produto set codigo_alternativo = '" +
                                (bsItensPed.Current as TRegistro_LanPedido_Item).Cd_referencia.Trim() + "' " +
                                "where cd_produto = '" + linha["cd_produto"].ToString() + "'", null);
                            (bsItensPed.Current as TRegistro_LanPedido_Item).Cd_produto = linha["cd_produto"].ToString();
                            (bsItensPed.Current as TRegistro_LanPedido_Item).Ds_produto = linha["ds_produto"].ToString();
                            (bsItensPed.Current as TRegistro_LanPedido_Item).Cd_unidade_est = linha["cd_unidade"].ToString();
                            (bsItensPed.Current as TRegistro_LanPedido_Item).Ds_unidade_est = linha["ds_unidade"].ToString();
                            (bsItensPed.Current as TRegistro_LanPedido_Item).Sg_unidade_est = linha["sigla_unidade"].ToString();
                            (bsItensPed.Current as TRegistro_LanPedido_Item).Cd_unidade_valor = linha["cd_unidade"].ToString();
                            (bsItensPed.Current as TRegistro_LanPedido_Item).Ds_unidade_valor = linha["ds_unidade"].ToString();
                            (bsItensPed.Current as TRegistro_LanPedido_Item).Sg_unidade_valor = linha["sigla_unidade"].ToString();
                            bsItensPed.ResetCurrentItem();
                        }
                        catch (Exception ex)
                        { MessageBox.Show("Erro gravar registro: " + ex.Message.Trim(), "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                } else
                {
                    MessageBox.Show("O Campo código produto deve disponibilizar algum valor!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
        }

        private void buscarProdutoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (bsItensPed.Current != null)
                if (string.IsNullOrEmpty((bsItensPed.Current as TRegistro_LanPedido_Item).Cd_produto))
                {
                    DataRowView linha = FormBusca.UtilPesquisa.BTN_BuscaProduto(null, string.Empty);
                    if (linha != null)
                        try
                        {
                            new CamadaDados.TDataQuery().executarSql("update tb_est_produto set codigo_alternativo = '" +
                                (bsItensPed.Current as TRegistro_LanPedido_Item).Cd_referencia.Trim() + "' " +
                                "where cd_produto = '" + linha["cd_produto"].ToString() + "'", null);
                            (bsItensPed.Current as TRegistro_LanPedido_Item).Cd_produto = linha["cd_produto"].ToString();
                            (bsItensPed.Current as TRegistro_LanPedido_Item).Ds_produto = linha["ds_produto"].ToString();
                            (bsItensPed.Current as TRegistro_LanPedido_Item).Cd_unidade_est = linha["cd_unidade"].ToString();
                            (bsItensPed.Current as TRegistro_LanPedido_Item).Ds_unidade_est = linha["ds_unidade"].ToString();
                            (bsItensPed.Current as TRegistro_LanPedido_Item).Sg_unidade_est = linha["sigla_unidade"].ToString();
                            (bsItensPed.Current as TRegistro_LanPedido_Item).Cd_unidade_valor = linha["cd_unidade"].ToString();
                            (bsItensPed.Current as TRegistro_LanPedido_Item).Ds_unidade_valor = linha["ds_unidade"].ToString();
                            (bsItensPed.Current as TRegistro_LanPedido_Item).Sg_unidade_valor = linha["sigla_unidade"].ToString();
                            bsItensPed.ResetCurrentItem();
                        }
                        catch (Exception ex)
                        { MessageBox.Show("Erro gravar registro: " + ex.Message.Trim(), "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
                else
                {
                    MessageBox.Show("O campo código produto deve ser nulo!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
        }

        private void novoProdutoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (bsItensPed.Current != null)
                if (string.IsNullOrEmpty((bsItensPed.Current as TRegistro_LanPedido_Item).Cd_produto))
                {
                    using (Proc_Commoditties.TFProdutoResumido fProduto = new Proc_Commoditties.TFProdutoResumido())
                    {
                        CamadaDados.Estoque.Cadastros.TRegistro_CadProduto rProd = new CamadaDados.Estoque.Cadastros.TRegistro_CadProduto();
                        rProd.DS_Produto = (bsItensPed.Current as TRegistro_LanPedido_Item).Ds_produto;
                        rProd.Codigo_alternativo = (bsItensPed.Current as TRegistro_LanPedido_Item).Cd_referencia;
                        fProduto.Produto = rProd;
                        if (fProduto.ShowDialog() == DialogResult.OK)
                            if (fProduto.Produto != null)
                                try
                                {
                                    (bsItensPed.Current as TRegistro_LanPedido_Item).Cd_produto =
                                    CamadaNegocio.Estoque.Cadastros.TCN_CadProduto.Gravar(fProduto.Produto, null);
                                    MessageBox.Show("Produto cadastrado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    bsItensPed.ResetCurrentItem();
                                }
                                catch (Exception ex)
                                { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    }
                } else
                {
                    MessageBox.Show("O campo código produto deve ser nulo!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                    
        }
    }
}
