using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CamadaDados.Restaurante.Cadastro;
using CamadaDados.Restaurante;
using CamadaNegocio.Restaurante;
using CamadaDados.Estoque.Cadastros;
using CamadaDados.Diversos;
using CamadaDados.Faturamento.Cadastros;
using Utils;

namespace Restaurante
{
    public partial class TFResBalanca : Form
    {
        private TRegistro_Cfg _Cfg = new TRegistro_Cfg();
        private TRegistro_CadProtocolo rProtocolo = new TRegistro_CadProtocolo();
        private TRegistro_Cartao _Cartao = new TRegistro_Cartao();
        private TList_PontoVenda lPdv = new TList_PontoVenda();
        private bool gerarPed = true;


        public TFResBalanca()
        {
            InitializeComponent();
        }

        private bool abrirCartao()
        {
            if (!string.IsNullOrEmpty(_Cfg.Cd_Clifor))
            {
                _Cartao = new TRegistro_Cartao();
                _Cartao.Cd_empresa = _Cfg.cd_empresa;
                _Cartao.Cd_Clifor = _Cfg.Cd_Clifor;
                _Cartao.Nm_Clifor = _Cfg.nm_clifor;
                _Cartao.Dt_abertura = CamadaDados.UtilData.Data_Servidor();
                _Cartao.lPreVenda.Add(new TRegistro_PreVenda());
                _Cartao.lPreVenda[0].Dt_venda = CamadaDados.UtilData.Data_Servidor();
                return true;
            }

            return false;
        }

        private bool validarCartao()
        {
            edt_cartao.Text = edt_cartao.Text.SoNumero().Trim();
            if (string.IsNullOrEmpty(edt_cartao.Text.SoNumero().Trim()))
                return false;
            else if (_Cfg.bool_abrircartao && (_Cfg.Tp_cartao.Equals("0") || (_Cfg.bool_mesacartao && _Cfg.Tp_cartao.Equals("0"))) && _Cfg.nr_cartaorotini > Convert.ToDecimal(edt_cartao.Text))
            {
                MessageBox.Show("N° Cartão (" + _Cfg.nr_cartaorotini + ") é o mínimo da faixa de cartão rotativo!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                return false;
            }
            else if (_Cfg.bool_abrircartao && (_Cfg.Tp_cartao.Equals("0") || (_Cfg.bool_mesacartao && _Cfg.Tp_cartao.Equals("0"))) && _Cfg.nr_cartaorotfin < Convert.ToDecimal(edt_cartao.Text))
            {
                MessageBox.Show("N° Cartão (" + _Cfg.nr_cartaorotfin + ") é o máximo da faixa de cartão rotativo!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                return false;
            }

            TList_Cartao cartao = new TCD_Cartao().Select(new TpBusca[]
            {
                new TpBusca()
                {
                    vNM_Campo = "a.nr_cartao",
                    vOperador = "=",
                    vVL_Busca =  "'" + edt_cartao.Text + "'"
                },
                new TpBusca()
                {
                    vNM_Campo = "a.st_registro",
                    vOperador = "=",
                    vVL_Busca = "'A'"
                }
            }, 1, string.Empty, string.Empty);

            if (cartao.Count > 0)
            {
                _Cartao = cartao[0];

                //Buscar prevenda
                _Cartao.lPreVenda = TCN_PreVenda.Buscar(_Cartao.Cd_empresa, _Cartao.id_cartao.ToString(), string.Empty, string.Empty, string.Empty, "A", null);

                //Buscar itens da prevenda
                _Cartao.lPreVenda.ForEach(p =>
                {
                    p.lItens = TCN_PreVenda_Item.Buscar(p.Cd_empresa, p.id_prevenda.ToString(), string.Empty, string.Empty, null);
                });

                return true;
            }
            else if (abrirCartao())
                return true;
            else
                return false;
        }

        private void AlterarQuantidade()
        {
            using (Componentes.TFQuantidade fQtde = new Componentes.TFQuantidade())
            {
                fQtde.Ds_label = "Peso em KG";
                if (fQtde.ShowDialog() == DialogResult.OK)
                {
                    if (fQtde.Quantidade > decimal.Zero)
                    {
                        edt_peso.Text = fQtde.Quantidade.ToString("N3", new System.Globalization.CultureInfo("pt-BR"));
                        edt_peso.Enabled = true;
                        gerarPed = true;
                    }
                    else
                    {
                        gerarPed = false;
                        limparCampos();
                    }
                }
                else
                {
                    gerarPed = false;
                    limparCampos();
                }
            }
        }

        private void novoPedido()
        {
            if (bsProduto.Current == null)
                return;
            else if (!validarCartao())
            {
                edt_cartao.Clear();
                edt_cartao.Focus();
                return;
            }
            if (rProtocolo == null)
                AlterarQuantidade();
            else
            {
                using (Proc_Commoditties.TFBalancaProc fPeso = new Proc_Commoditties.TFBalancaProc())
                {
                    fPeso.rProtocolo = rProtocolo;
                    if (fPeso.ShowDialog() == DialogResult.OK)
                    {
                        if (fPeso.Peso > decimal.Zero)
                            edt_peso.Text = fPeso.Peso.ToString("N3", new System.Globalization.CultureInfo("pt-BR", true));
                        else
                            AlterarQuantidade();

                        gerarPed = true;
                    }
                    else
                    {
                        AlterarQuantidade();
                    }
                }
            }

            calcularTotal();
        }

        private void calcularTotal()
        {
            if (bsProduto.Current == null)
                return;
            else if (!((bsProduto.Current as TRegistro_CadProduto).Vl_precovenda > 0))
            {
                MessageBox.Show("Valor preço de venda do produto selecionado é menor/ igual a zero.", "Informativo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (string.IsNullOrEmpty(edt_peso.Text.Trim()))
            {
                MessageBox.Show("Pedido cancelado.", "Informativo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (!gerarPed)
            {
                MessageBox.Show("Pedido cancelado.", "Informativo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            object a = Convert.ToDecimal(edt_peso.Text.Trim());
            if (a == null || a.Equals(0))
                return;

            edt_total.Text = (Convert.ToDecimal(a) * (bsProduto.Current as TRegistro_CadProduto).Vl_precovenda).ToString("N2", new System.Globalization.CultureInfo("pt-BR"));

            gerarPedido();
        }

        private void gerarPedido()
        {
            TRegistro_PreVenda_Item _Item = new TRegistro_PreVenda_Item();
            _Item.Cd_empresa = _Cfg.cd_empresa;
            _Item.cd_produto = (bsProduto.Current as TRegistro_CadProduto).CD_Produto;
            _Item.ds_produto = (bsProduto.Current as TRegistro_CadProduto).DS_Produto;
            _Item.quantidade = Convert.ToDecimal(edt_peso.Text.Trim());
            _Item.vl_unitario = (bsProduto.Current as TRegistro_CadProduto).Vl_precovenda;

            _Cartao.lPreVenda[0].lItens.Add(_Item);
            _Cartao.nr_cartao = edt_cartao.Text.Trim();
            TCN_Cartao.Gravar(_Cartao, null);
            gerarPed = true;
            limparCampos();
        }

        private void limparCampos()
        {
            edt_cartao.Clear();
            edt_cartao.Focus();
            edt_peso.Enabled = false;
        }

        private void Produtos()
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[1];
            filtro[0].vNM_Campo = "isnull(a.st_registro, 'A')";
            filtro[0].vOperador = "<>";
            filtro[0].vVL_Busca = "'C'";
            if (!string.IsNullOrEmpty(edt_produto.Text))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = string.Empty;
                filtro[filtro.Length - 1].vOperador = string.Empty;
                filtro[filtro.Length - 1].vVL_Busca = "(a.cd_produto like '%" + edt_produto.Text.Trim() + "') or " +
                                                      "(a.ds_produto like " + (Utils.Parametros.ST_UtilizarCoringaEsq ? "'%" : "'") + edt_produto.Text.Trim() + "%') or " +
                                                      "(a.codigo_alternativo like '%" + edt_produto.Text.Trim() + "%') or " +
                                                      "(exists(select 1 from tb_est_codbarra x " +
                                                      "           where x.cd_produto = a.cd_produto " +
                                                      "           and x.cd_codbarra = '" + edt_produto.Text.Trim() + "')) or " +
                                                      "(exists(select 1 from tb_est_patrimonio x " +
                                                      "           where x.CD_Patrimonio = a.cd_produto " +
                                                      "           and x.NR_Patrimonio = '" + edt_produto.Text.Trim() + "'))";
            }
            System.Collections.Hashtable vParametros = new System.Collections.Hashtable();
            vParametros.Add("@CD_TABELAPRECO", _Cfg.cd_tabelapreco);
            vParametros.Add("@CD_EMPRESA", _Cfg.cd_empresa);
            bsProduto.DataSource = new TCD_CadProduto().Select(filtro, 100, string.Empty, string.Empty, "a.ds_produto", vParametros);
            bsProduto_PositionChanged(this, new EventArgs());
        }

        private void TFResBalanca_Load(object sender, EventArgs e)
        {
            TList_CFG _Cfgs = new TCD_CFG().Select(null, 0, string.Empty);
            if (_Cfgs.Count.Equals(0))
            {
                MessageBox.Show("Necessário ter configuração Restaurante para finalizar processo.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                BeginInvoke(new MethodInvoker(Close));
                return;
            }
            _Cfg = _Cfgs[0];

            //Protocolo por terminal para pesagem
            TList_RegCadProtocolo lProt = CamadaNegocio.Diversos.TCN_CadProtocolo.Busca(string.Empty, string.Empty, Utils.Parametros.pubTerminal, null);
            if (lProt.Count > 0)
                rProtocolo = lProt[0];

            //Buscar dados PDV
            lPdv = CamadaNegocio.Faturamento.Cadastros.TCN_PontoVenda.Buscar(string.Empty,
                                                                             string.Empty,
                                                                             Utils.Parametros.pubTerminal,
                                                                             string.Empty,
                                                                             null);
            if (lPdv.Count.Equals(0))
            {
                MessageBox.Show("Não existe PDV cadastrado para o terminal " + Utils.Parametros.pubTerminal,
                                "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                BeginInvoke(new MethodInvoker(Close));
                return;
            }
            lblOperador.Text = Utils.Parametros.pubLogin;
            lblPdv.Text = lPdv[0].Ds_pdv;

            panelDados2.set_FormatZero();
            edt_produto.Focus();
        }

        private void edt_produto_TextChanged(object sender, EventArgs e)
        {
            Produtos();
        }

        private void edt_cartao_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
                label1.Focus();
        }

        private void edt_produto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
                edt_cartao.Focus();
        }

        private void bsProduto_PositionChanged(object sender, EventArgs e)
        {
            if (bsProduto.Current != null)
            {
                edt_nmproduto.Text = (bsProduto.Current as TRegistro_CadProduto).DS_Produto;
                edt_valor.Text = (bsProduto.Current as TRegistro_CadProduto).Vl_precovenda.ToString("N3", new System.Globalization.CultureInfo("pt-BR"));
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lbhora.Text = CamadaDados.UtilData.Data_Servidor().ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void edt_cartao_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(edt_cartao.Text.Trim()))
                return;
            novoPedido();
        }
    }
}
