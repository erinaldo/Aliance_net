using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Utils;

namespace PostoCombustivel
{
    public partial class TFReceberConvenio : Form
    {
        public List<CamadaDados.PostoCombustivel.TRegistro_VendaCombustivel> lVenda
        { get; set; }
        public CamadaDados.PostoCombustivel.TList_Convenio lConv
        { get; set; }
        public CamadaDados.PostoCombustivel.TRegistro_Convenio rConvenio
        {
            get
            {
                if (bsConvenio.Current != null)
                    return bsConvenio.Current as CamadaDados.PostoCombustivel.TRegistro_Convenio;
                else
                    return null;
            }
        }
        public List<CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item> lItemVenda
        { get; set; }
        public List<CamadaDados.Financeiro.Adiantamento.TRegistro_LanAdiantamento> lCred;
        public bool St_placacadastrada { get; set; }
        private string pplaca;
        public string Placa
        { get { return placa.Text; } set { pplaca = value; } }
        public decimal Km_atual
        { get { return km.Value; } }
        public decimal Km_maximo
        { get; set; }
        public string Nm_motorista
        { get { return nm_motorista.Text; } }
        public string Cpf_motorista
        { get { return cpf_motorista.Text; } }
        public string Nr_frota
        { get { return nr_frota.Text; } }
        public string Nr_requisicao
        { get { return nr_requisicao.Text; } }
        public string Cd_clifor
        { get; set; }
        public string Nm_clifor
        { get; set; }
        public string Cd_endereco
        { get; set; }
        public string condProd
        { get; set; }

        private bool St_MotValidado = false;
        
        public TFReceberConvenio()
        {
            InitializeComponent();
            lItemVenda = new CamadaDados.Faturamento.PDV.TList_VendaRapida_Item();
            lCred = null;
        }

        private bool ValidarKm(ref decimal Km_atual)
        {
            bool retorno = true;
            Km_maximo = decimal.Zero;
            //Validar KM Atual
            if ((!string.IsNullOrEmpty(placa.Text)) &&
                (placa.Text.Trim() != "-") &&
                (km.Value > decimal.Zero))
            {

                //Buscar ultimo KM Informado para a placa
                object obj = new CamadaDados.PostoCombustivel.TCD_VendaCombustivel().BuscarEscalar(
                                    new TpBusca[]
                                    {
                                        new TpBusca()
                                        {
                                            vNM_Campo = "replace(a.placaveiculo, '-', '')",
                                            vOperador = "=",
                                            vVL_Busca = "'" + placa.Text.Trim().Replace("-", "") + "'"
                                        }
                                    }, "isnull(a.km_atual, 0)", string.Empty, "a.dt_abastecimento desc", null);
                if (obj != null)
                {
                    Km_atual = decimal.Parse(obj.ToString());
                    if (Km_atual > km.Value)
                        retorno = false;
                }
            }
            return retorno;
        }

        private void DevolverCredito()
        {
            using (Financeiro.TFSaldoCreditos fSaldo = new Financeiro.TFSaldoCreditos())
            {
                fSaldo.Cd_empresa = rConvenio.lClifor[0].Cd_empresa;
                fSaldo.Cd_clifor = rConvenio.lClifor[0].Cd_clifor;
                fSaldo.Vl_financeiro = total_receber.Value;
                fSaldo.Tp_mov = "'R'";
                if (fSaldo.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    if (fSaldo.lSaldo != null)
                    {
                        lCred = fSaldo.lSaldo;
                        tot_credito.Value = fSaldo.lSaldo.Sum(p => p.Vl_processar);
                    }
                    else
                    {
                        lCred = null;
                        tot_credito.Value = decimal.Zero;
                    }
                else
                {
                    lCred = null;
                    tot_credito.Value = decimal.Zero;
                }
            }
        }

        private void afterGrava()
        {
            if (pDados.validarCampoObrigatorio())
            {
                if(bsConvenio.Current == null)
                {
                    MessageBox.Show("Não existe portador selecionado para receber convenio.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (cpf_motorista.Focused)
                {
                    cpf_motorista_Leave(cpf_motorista.Text, new EventArgs());
                    return;
                }
                if (st_exigirrequisicao.Checked && string.IsNullOrEmpty(nr_requisicao.Text))
                {
                    MessageBox.Show("Convênio exige REQUISIÇÃO para abastecimento.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    nr_requisicao.Focus();
                    return;
                }
                if (st_exigirnomemot.Checked && string.IsNullOrEmpty(nm_motorista.Text))
                {
                    MessageBox.Show("Convênio exige NOME DO MOTORISTA.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    nm_motorista.Focus();
                    return;
                }
                if ((bsConvenio.Current as CamadaDados.PostoCombustivel.TRegistro_Convenio).lClifor.Find(p => p.Cd_produto.Equals(lVenda[0].Cd_produto)).Tp_pontos_fid.Trim().ToUpper().Equals("P") &&
                    (placa.Text.Trim().Length < 8))
                {
                    MessageBox.Show("Convenio exige PLACA para gerar pontuação.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    placa.Focus();
                    return;
                }
                if ((bsConvenio.Current as CamadaDados.PostoCombustivel.TRegistro_Convenio).lClifor.Find(p => p.Cd_produto.Equals(lVenda[0].Cd_produto)).Tp_pontos_fid.Trim().ToUpper().Equals("M") &&
                    string.IsNullOrEmpty(cpf_motorista.Text.SoNumero()))
                {
                    MessageBox.Show("Convenio exige CPF MOTORISTA para gerar pontuação.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cpf_motorista.Focus();
                    return;
                }
                decimal KM = decimal.Zero;
                if (!this.ValidarKm(ref KM))
                {
                    if (MessageBox.Show("KM Atual não pode ser menor ou igual ao ultimo KM informado para a placa (Ultimo KM: " + KM.ToString("N0", new System.Globalization.CultureInfo("pt-BR")) + ").\r\n" +
                                    "Deseja corrigir ultimo KM informado?", "Pergunta",
                                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    {
                        //Buscar abastecida do ultimo KM
                        CamadaDados.PostoCombustivel.TList_VendaCombustivel lVendaUltimoKM =
                            new CamadaDados.PostoCombustivel.TCD_VendaCombustivel().Select(
                            new TpBusca[]
                            {
                                new TpBusca()
                                {
                                    vNM_Campo = "replace(a.placaveiculo, '-', '')",
                                    vOperador = "=",
                                    vVL_Busca = "'" + placa.Text.Trim().Replace("-", "") + "'"
                                }
                            }, 1, string.Empty, "a.dt_abastecimento desc");
                        if (lVendaUltimoKM.Count > 0)
                            using (PDV.TFCorrigirKM fKM = new PDV.TFCorrigirKM())
                            {
                                fKM.Ultimo_km = lVendaUltimoKM[0].Km_atual;
                                fKM.Km_atual = km.Value;
                                if (fKM.ShowDialog() == DialogResult.OK)
                                    try
                                    {
                                        lVendaUltimoKM[0].Km_atual = fKM.Km_corrigido;
                                        CamadaNegocio.PostoCombustivel.TCN_VendaCombustivel.Gravar(lVendaUltimoKM[0], null);
                                        MessageBox.Show("Ultimo KM corrigido com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                    catch (Exception ex)
                                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                            }
                    }
                    else
                    {
                        if (MessageBox.Show("Deseja informar KM maximo do hodometro?", "Pergunta", MessageBoxButtons.YesNo,
                             MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                        {
                            using (Componentes.TFQuantidade fQtd = new Componentes.TFQuantidade())
                            {
                                fQtd.Ds_label = "KM Maximo Hodometro";
                                fQtd.ShowDialog();
                                if (fQtd.Quantidade >= KM)
                                    Km_maximo = fQtd.Quantidade;
                                else
                                {
                                    km.Focus();
                                    return;
                                }
                            }
                        }
                        else
                        {
                            km.Focus();
                            return;
                        }
                    }
                }
                object obj_km = new CamadaDados.PostoCombustivel.TCD_Convenio_Placa().BuscarEscalar(
                                new TpBusca[]
                                {
                                    new TpBusca()
                                    {
                                        vNM_Campo = "a.cd_empresa",
                                        vOperador = "=",
                                        vVL_Busca = "'" + (bsConvenio.Current as CamadaDados.PostoCombustivel.TRegistro_Convenio).Cd_empresa.Trim() + "'"
                                    },
                                    new TpBusca()
                                    {
                                        vNM_Campo = "a.id_convenio",
                                        vOperador = "=",
                                        vVL_Busca = (bsConvenio.Current as CamadaDados.PostoCombustivel.TRegistro_Convenio).Id_conveniostr
                                    },
                                    new TpBusca()
                                    {
                                        vNM_Campo = "a.cd_clifor",
                                        vOperador = "=",
                                        vVL_Busca = "'" + cd_clifor.Text.Trim() + "'"
                                    },
                                    new TpBusca()
                                    {
                                        vNM_Campo = "a.cd_endereco",
                                        vOperador = "=",
                                        vVL_Busca = "'" + cd_endereco.Text.Trim() + "'"
                                    },
                                    new TpBusca()
                                    {
                                        vNM_Campo = "a.cd_produto",
                                        vOperador = "=",
                                        vVL_Busca = "'" + lVenda[0].Cd_produto.Trim() + "'"
                                    },
                                    new TpBusca()
                                    {
                                        vNM_Campo = "a.placa",
                                        vOperador = "=",
                                        vVL_Busca = "'" + placa.Text.Trim() + "'"
                                    }
                                }, "a.st_km");
                if((bsConvenio.Current as CamadaDados.PostoCombustivel.TRegistro_Convenio).lClifor.Find(p=> p.Cd_produto.Equals(lVenda[0].Cd_produto)).St_placaconveniadabool && (obj_km == null))
                {
                    MessageBox.Show("Convenio permite abastecer somente placa cadastrada.\r\n" +
                                    "A placa " + placa.Text + " não consta na lista permitida pelo convenio " + (bsConvenio.Current as CamadaDados.PostoCombustivel.TRegistro_Convenio).Id_conveniostr,
                                    "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    placa.Focus();
                    return;
                }
                if ((obj_km == null ? false : obj_km.ToString().Trim().ToUpper().Equals("S")) && km.Value.Equals(decimal.Zero))
                {
                    MessageBox.Show("Convenio exige KM atual para a placa informada.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    km.Focus();
                    return;
                }
                if((bsConvenio.Current as CamadaDados.PostoCombustivel.TRegistro_Convenio).lClifor.Find(p=> p.Cd_produto.Equals(lVenda[0].Cd_produto)).St_motconveniadobool)
                    if (new CamadaDados.PostoCombustivel.TCD_Convenio_Motorista().BuscarEscalar(
                        new TpBusca[]
                        {
                            new TpBusca()
                            {
                                vNM_Campo = "a.cd_empresa",
                                vOperador = "=",
                                vVL_Busca = "'" + (bsConvenio.Current as CamadaDados.PostoCombustivel.TRegistro_Convenio).Cd_empresa.Trim() + "'"
                            },
                            new TpBusca()
                            {
                                vNM_Campo = "a.id_convenio",
                                vOperador = "=",
                                vVL_Busca = (bsConvenio.Current as CamadaDados.PostoCombustivel.TRegistro_Convenio).Id_conveniostr
                            },
                            new TpBusca()
                            {
                                vNM_Campo = "a.cd_clifor",
                                vOperador = "=",
                                vVL_Busca = "'" + cd_clifor.Text.Trim() + "'"
                            },
                            new TpBusca()
                            {
                                vNM_Campo = "a.cd_endereco",
                                vOperador = "=",
                                vVL_Busca = "'" + cd_endereco.Text.Trim() + "'"
                            },
                            new TpBusca()
                            {
                                vNM_Campo = "a.cd_produto",
                                vOperador = "=",
                                vVL_Busca = "'" + lVenda[0].Cd_produto.Trim() + "'"
                            },
                            new TpBusca()
                            {
                                vNM_Campo = "a.cpf_motorista",
                                vOperador = "=",
                                vVL_Busca = "'" + cpf_motorista.Text.Trim() + "'"
                            }
                        }, "1") == null)
                    {
                        MessageBox.Show("Convenio permite abastecer somente motorista cadastrado.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cpf_motorista.Focus();
                        return;
                    }
                if(lCred == null)
                    if (CamadaNegocio.ConfigGer.TCN_CadParamGer.BuscaVL_Bool("ST_IDENT_CLIFOR_CRED", (bsConvenio.Current as CamadaDados.PostoCombustivel.TRegistro_Convenio).Cd_empresa, null).Trim().ToUpper().Equals("S"))
                        if (CamadaNegocio.Financeiro.Adiantamento.TCN_LanAdiantamento.Buscar(string.Empty,
                                                                                             (bsConvenio.Current as CamadaDados.PostoCombustivel.TRegistro_Convenio).Cd_empresa,
                                                                                             cd_clifor.Text,
                                                                                             string.Empty,
                                                                                             "'R'",
                                                                                             string.Empty,
                                                                                             decimal.Zero,
                                                                                             string.Empty,
                                                                                             string.Empty,
                                                                                             decimal.Zero,
                                                                                             decimal.Zero,
                                                                                             false,
                                                                                             false,
                                                                                             true,
                                                                                             string.Empty,
                                                                                             false,
                                                                                             true,
                                                                                             string.Empty,
                                                                                             string.Empty,
                                                                                             0,
                                                                                             string.Empty,
                                                                                             null).Count > 0)
                            this.DevolverCredito();
                if (vl_dupvencidas.Value > decimal.Zero)
                    MessageBox.Show("Cliente possui duplicata vencida.", "Lembrete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
            }
        }

        private void CalcularValorProdConvenio()
        {
            if ((bsConvenio.Current != null) && (lVenda.Count > 0))
            {
                decimal vl_liquido = decimal.Zero;
                decimal vl_bruto = decimal.Zero;
                decimal volume = decimal.Zero;
                lVenda.GroupBy(p => p.Cd_produto,
                    (aux, venda) =>
                        new
                        {
                            produto = aux,
                            volume = venda.Sum(v => v.Volumeabastecido),
                            vl_unitario = venda.Average(v => v.Vl_unitario),
                            vl_subtotal = venda.Sum(v => v.Vl_subtotal)
                        }).ToList().ForEach(p =>
                            {
                                //Buscar convenio x clifor x produto

                                //Verificar se o produto tem convenio valor unitario
                                CamadaDados.PostoCombustivel.TList_Convenio_Clifor lConvClifor =
                                    new CamadaDados.PostoCombustivel.TCD_Convenio_Clifor().Select(
                                                new TpBusca[]
                                                {
                                                    new TpBusca()
                                                    {
                                                        vNM_Campo = "a.cd_empresa",
                                                        vOperador = "=",
                                                        vVL_Busca = "'" + lVenda[0].Cd_empresa.Trim() + "'"
                                                    },
                                                    new TpBusca()
                                                    {
                                                        vNM_Campo = "a.id_convenio",
                                                        vOperador = "=",
                                                        vVL_Busca = (bsConvenio.Current as CamadaDados.PostoCombustivel.TRegistro_Convenio).Id_conveniostr
                                                    },
                                                    new TpBusca()
                                                    {
                                                        vNM_Campo = "a.cd_clifor",
                                                        vOperador = "=",
                                                        vVL_Busca = "'" + cd_clifor.Text.Trim() + "'"
                                                    },
                                                    new TpBusca()
                                                    {
                                                        vNM_Campo = "a.cd_endereco",
                                                        vOperador = "=",
                                                        vVL_Busca = "'" + cd_endereco.Text.Trim() + "'"
                                                    },
                                                    new TpBusca()
                                                    {
                                                        vNM_Campo = "a.cd_produto",
                                                        vOperador = "=",
                                                        vVL_Busca = "'" + p.produto.Trim() + "'"
                                                    }
                                                }, 1, string.Empty);
                                if (lConvClifor[0].Vl_unitario > decimal.Zero)
                                    vl_liquido += p.volume * lConvClifor[0].Vl_unitario;
                                else
                                {
                                    string tp_acresdesc = !string.IsNullOrWhiteSpace(lConvClifor[0].Tp_acresdesc) ? lConvClifor[0].Tp_acresdesc : (bsConvenio.Current as CamadaDados.PostoCombustivel.TRegistro_Convenio).Tp_acresdesc;
                                    string tp_desconto = !string.IsNullOrWhiteSpace(lConvClifor[0].Tp_desconto) ? lConvClifor[0].Tp_desconto : (bsConvenio.Current as CamadaDados.PostoCombustivel.TRegistro_Convenio).Tp_desconto;
                                    decimal vl_desc = lConvClifor[0].Desconto > decimal.Zero ? lConvClifor[0].Desconto : (bsConvenio.Current as CamadaDados.PostoCombustivel.TRegistro_Convenio).Desconto;
                                    
                                    if(lConvClifor[0].Tp_preco.Trim().ToUpper() != "N")
                                    {
                                        if (lConvClifor[0].Tp_preco.Trim().ToUpper().Equals("A"))
                                        {
                                            //Buscar Preço ANP do combustivel
                                            decimal vl_precoANP = CamadaNegocio.PostoCombustivel.Cadastros.TCN_PrecoANP.BuscarPrecoANP(p.produto, null);
                                            if (vl_precoANP > decimal.Zero)
                                            {
                                                //Verificar se o convenio tem desconto/acrescimo valor unitario
                                                if (vl_desc > decimal.Zero)
                                                    if (tp_acresdesc.Trim().ToUpper().Equals("A"))
                                                        vl_liquido += tp_desconto.Trim().ToUpper().Equals("V") ?
                                                            (p.volume * vl_precoANP) + (vl_desc * p.volume) :
                                                            (p.volume * vl_precoANP) + Math.Round((p.volume * vl_precoANP) * (vl_desc / 100), 2);
                                                    else
                                                        vl_liquido += tp_desconto.Trim().ToUpper().Equals("V") ?
                                                            (p.volume * vl_precoANP) - (vl_desc * p.volume) :
                                                            (p.volume * vl_precoANP) - Math.Round((p.volume * vl_precoANP) * (vl_desc / 100), 2);
                                                else
                                                    vl_liquido += p.volume * vl_precoANP;
                                            }
                                        }
                                        else if (lConvClifor[0].Tp_preco.Trim().ToUpper().Equals("C"))
                                        {
                                            //Buscar preco Custo
                                            decimal vl_precoCusto = CamadaNegocio.Estoque.TCN_LanEstoque.Valor_Medio_Est_Produto(lVenda[0].Cd_empresa, p.produto, null);
                                            if (vl_precoCusto > decimal.Zero)
                                            {
                                                //Verificar se o convenio tem desconto/acrescimo valor unitario
                                                if (vl_desc > decimal.Zero)
                                                    if (tp_acresdesc.Trim().ToUpper().Equals("A"))
                                                        vl_liquido += tp_desconto.Trim().ToUpper().Equals("V") ?
                                                            (p.volume * vl_precoCusto) + (vl_desc * p.volume) :
                                                            (p.volume * vl_precoCusto) + Math.Round((p.volume * vl_precoCusto) * (vl_desc / 100), 2);
                                                    else
                                                        vl_liquido += tp_desconto.Trim().ToUpper().Equals("V") ?
                                                            (p.volume * vl_precoCusto) - (vl_desc * p.volume) :
                                                            (p.volume * vl_precoCusto) - Math.Round((p.volume * vl_precoCusto) * (vl_desc / 100), 2);
                                                else
                                                    vl_liquido += p.volume * vl_precoCusto;
                                            }
                                        }
                                        else
                                        {
                                            //Verificar se o convenio tem desconto/acrescimo valor unitario
                                            if (vl_desc > decimal.Zero)
                                                if (tp_acresdesc.Trim().ToUpper().Equals("A"))
                                                    vl_liquido += tp_desconto.Trim().ToUpper().Equals("V") ?
                                                        p.vl_subtotal + (vl_desc * p.volume) :
                                                        p.vl_subtotal + Math.Round(p.vl_subtotal * (vl_desc / 100), 2);
                                                else
                                                    vl_liquido += tp_desconto.Trim().ToUpper().Equals("V") ?
                                                        p.vl_subtotal - (vl_desc * p.volume) :
                                                        p.vl_subtotal - Math.Round(p.vl_subtotal * (vl_desc / 100), 2);
                                            else
                                                vl_liquido += p.vl_subtotal;
                                        }
                                    }
                                    else
                                    {
                                        //Verificar se o convenio tem desconto/acrescimo valor unitario
                                        if (vl_desc > decimal.Zero)
                                            if (tp_acresdesc.Trim().ToUpper().Equals("A"))
                                                vl_liquido += tp_desconto.Trim().ToUpper().Equals("V") ?
                                                    p.vl_subtotal + (vl_desc * p.volume) :
                                                    p.vl_subtotal + Math.Round(p.vl_subtotal * (vl_desc / 100), 2);
                                            else
                                                vl_liquido += tp_desconto.Trim().ToUpper().Equals("V") ?
                                                    p.vl_subtotal - (vl_desc * p.volume) :
                                                    p.vl_subtotal - Math.Round(p.vl_subtotal * (vl_desc / 100), 2);
                                        else
                                            vl_liquido += p.vl_subtotal;
                                    }
                                }
                                vl_bruto += p.vl_subtotal;
                                volume += p.volume;
                            });
                tot_volume.Value = volume;
                tot_bruto.Value = vl_bruto;
                tot_liquido.Value = vl_liquido;
                total_receber.Value = tot_liquido.Value + tot_outrasvenda.Value;
            }
        }
            
        private void TFReceberConvenio_Load(object sender, EventArgs e)
        {
            ShapeGrid.RestoreShape(this, dataGridDefault1);
            ShapeGrid.RestoreShape(this, dataGridDefault2);
            ShapeGrid.RestoreShape(this, gPortador);
            this.Icon = ResourcesUtils.TecnoAliance_ICO;
            this.pDados.set_FormatZero();
            cd_clifor.Text = Cd_clifor;
            nm_clifor.Text = Nm_clifor;
            cd_endereco.Text = Cd_endereco;
            object obj = new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco().BuscarEscalar(
                            new TpBusca[]
                            {
                                new TpBusca()
                                {
                                    vNM_Campo = "a.cd_clifor",
                                    vOperador = "=",
                                    vVL_Busca = "'" + cd_clifor.Text.Trim() + "'"
                                },
                                new TpBusca()
                                {
                                    vNM_Campo = "a.cd_endereco",
                                    vOperador = "=",
                                    vVL_Busca = "'" + cd_endereco.Text.Trim() + "'"
                                }
                            }, "a.ds_endereco");
            if (obj != null)
                ds_endereco.Text = obj.ToString();

            //Buscar listagem de convenios do cliente
            bsConvenio.DataSource = lConv;
            bsVenda.DataSource = lItemVenda;
            bsCombustivel.DataSource = lVenda;
            tot_outrasvenda.Value = lItemVenda.Sum(p => p.Vl_subtotalliquido);
            total_receber.Value = tot_liquido.Value + tot_outrasvenda.Value;
            //Buscar duplicatas vencidas
            obj = new CamadaDados.Financeiro.Duplicata.TCD_LanParcela().BuscarEscalar(
                    new TpBusca[]
                    {
                        new TpBusca()
                        {
                            vNM_Campo = "a.cd_empresa",
                            vOperador = "=",
                            vVL_Busca = "'" + lConv[0].Cd_empresa.Trim() + "'"
                        },
                        new TpBusca()
                        {
                            vNM_Campo = "a.cd_clifor",
                            vOperador = "=",
                            vVL_Busca = "'" + cd_clifor.Text.Trim() + "'"
                        },
                        new TpBusca()
                        {
                            vNM_Campo = "a.tp_mov",
                            vOperador = "=",
                            vVL_Busca = "'R'"
                        },
                        new TpBusca()
                        {
                            vNM_Campo = "isnull(dup.st_registro, 'A')",
                            vOperador = "<>",
                            vVL_Busca = "'C'"
                        },
                        new TpBusca()
                        {
                            vNM_Campo = "CONVERT(datetime, floor(convert(decimal(30,10), DATEADD(day, isnull(c.diascarenciadebvencto, 0), a.DT_Vencto))))",
                            vOperador = "<",
                            vVL_Busca = "convert(datetime, floor(convert(decimal(30,10), getdate())))"
                        }
                    }, "isnull(sum(a.Vl_Atual), 0)");
            if (obj != null)
                vl_dupvencidas.Value = decimal.Parse(obj.ToString());
            if ((!string.IsNullOrEmpty(this.pplaca)) && (this.pplaca.Trim() != "-"))
            {
                placa.Text = this.pplaca;
                placa.Enabled = !this.St_placacadastrada;
                bb_placa.Enabled = !this.St_placacadastrada;
            }
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            this.afterGrava();
        }

        private void TFReceberConvenio_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
        }

        private void bb_motorista_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { nm_motorista }, string.Empty);
        }

        private void placa_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = Convert.ToChar(e.KeyChar.ToString().ToUpper());
        }

        private void bb_placa_Click(object sender, EventArgs e)
        {
            if(bsConvClifor.Current != null)
                using (TFListaPlacas fLista = new TFListaPlacas())
                {
                    fLista.rConvCli = bsConvClifor.Current as CamadaDados.PostoCombustivel.TRegistro_Convenio_Clifor;
                    if (fLista.ShowDialog() == DialogResult.OK)
                        placa.Text = fLista.Placa;
                }
        }

        private void bsConvenio_PositionChanged(object sender, EventArgs e)
        {
            if (bsConvenio.Current != null)
            {
                (bsConvenio.Current as CamadaDados.PostoCombustivel.TRegistro_Convenio).lClifor =
                    new CamadaDados.PostoCombustivel.TCD_Convenio_Clifor().Select(
                    new TpBusca[]
                    {
                        new TpBusca()
                        {
                            vNM_Campo = "a.id_convenio",
                            vOperador = "=",
                            vVL_Busca = (bsConvenio.Current as CamadaDados.PostoCombustivel.TRegistro_Convenio).Id_conveniostr
                        },
                        new TpBusca()
                        {
                            vNM_Campo = "a.cd_empresa",
                            vOperador = "=",
                            vVL_Busca = "'" + (bsConvenio.Current as CamadaDados.PostoCombustivel.TRegistro_Convenio).Cd_empresa.Trim() + "'"
                        },
                        new TpBusca()
                        {
                            vNM_Campo = "a.cd_clifor",
                            vOperador = "=",
                            vVL_Busca = "'" + cd_clifor.Text.Trim() + "'"
                        },
                        new TpBusca()
                        {
                            vNM_Campo = "a.cd_endereco",
                            vOperador = "=",
                            vVL_Busca = "'" + cd_endereco.Text.Trim() + "'"
                        },
                        new TpBusca()
                        {
                            vNM_Campo = "a.cd_produto",
                            vOperador = "in",
                            vVL_Busca = "(" + condProd.Trim() + ")"
                        }
                    }, 0, string.Empty);
                CalcularValorProdConvenio();
                bsConvenio.ResetCurrentItem();
            }
        }

        private void TFReceberConvenio_FormClosing(object sender, FormClosingEventArgs e)
        {
            ShapeGrid.SaveShape(this, dataGridDefault1);
            ShapeGrid.SaveShape(this, dataGridDefault2);
            ShapeGrid.SaveShape(this, gPortador);
        }

        private void bb_devcredito_Click(object sender, EventArgs e)
        {
            this.DevolverCredito();
        }

        private void cpf_motorista_TextChanged(object sender, EventArgs e)
        {
            if (cpf_motorista.Text.Trim().Length.Equals(3) ||
                cpf_motorista.Text.Trim().Length.Equals(7))
            {
                cpf_motorista.Text = cpf_motorista.Text + ".";
                cpf_motorista.SelectionStart = cpf_motorista.Text.Trim().Length;
            }
            if (cpf_motorista.Text.Trim().Length.Equals(11))
            {
                cpf_motorista.Text = cpf_motorista.Text + "-";
                cpf_motorista.SelectionStart = cpf_motorista.Text.Trim().Length;
            }
        }

        private void cpf_motorista_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(cpf_motorista.Text.SoNumero()))
            {
                Utils.CPF_Valido.nr_CPF = cpf_motorista.Text;
                if (string.IsNullOrEmpty(Utils.CPF_Valido.nr_CPF))
                {
                    MessageBox.Show("Por Favor! Entre com um CPF Válido!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    cpf_motorista.Clear();
                    cpf_motorista.Focus();
                    return;
                }
                object obj = new CamadaDados.PostoCombustivel.TCD_Convenio_Motorista().BuscarEscalar(
                                new TpBusca[]
                                {
                                    new TpBusca()
                                    {
                                        vNM_Campo = "a.id_convenio",
                                        vOperador = "=",
                                        vVL_Busca = (bsConvClifor.Current as CamadaDados.PostoCombustivel.TRegistro_Convenio_Clifor).Id_conveniostr
                                    },
                                    new TpBusca()
                                    {
                                        vNM_Campo = "a.cd_empresa",
                                        vOperador = "=",
                                        vVL_Busca = "'" + (bsConvClifor.Current as CamadaDados.PostoCombustivel.TRegistro_Convenio_Clifor).Cd_empresa.Trim() + "'"
                                    },
                                    new TpBusca()
                                    {
                                        vNM_Campo = "a.cd_clifor",
                                        vOperador = "=",
                                        vVL_Busca = "'" + (bsConvClifor.Current as CamadaDados.PostoCombustivel.TRegistro_Convenio_Clifor).Cd_clifor.Trim() + "'"
                                    },
                                    new TpBusca()
                                    {
                                        vNM_Campo = "a.cd_endereco",
                                        vOperador = "=",
                                        vVL_Busca = "'" + (bsConvClifor.Current as CamadaDados.PostoCombustivel.TRegistro_Convenio_Clifor).Cd_endereco.Trim() + "'"
                                    },
                                    new TpBusca()
                                    {
                                        vNM_Campo = "a.cd_produto",
                                        vOperador = "=",
                                        vVL_Busca = "'" + (bsConvClifor.Current as CamadaDados.PostoCombustivel.TRegistro_Convenio_Clifor).Cd_produto.Trim() + "'"
                                    },
                                    new TpBusca()
                                    {
                                        vNM_Campo = "a.cpf_motorista",
                                        vOperador = "=",
                                        vVL_Busca = "'" + cpf_motorista.Text.Trim() + "'"
                                    }
                                }, "a.nm_motorista");
                if (obj != null)
                {
                    nm_motorista.Text = obj.ToString();
                    this.St_MotValidado = true;
                }
                else this.St_MotValidado = false;
            }
        }

        private void bb_motconvenio_Click(object sender, EventArgs e)
        {
            if (bsConvClifor.Current != null)
                using (TFListaMotorista fLista = new TFListaMotorista())
                {
                    fLista.rConvCli = bsConvClifor.Current as CamadaDados.PostoCombustivel.TRegistro_Convenio_Clifor;
                    if (fLista.ShowDialog() == DialogResult.OK)
                        if(fLista.rConvMot != null)
                        {
                            cpf_motorista.Text = fLista.rConvMot.CPF_motorista;
                            nm_motorista.Text = fLista.rConvMot.Nm_motorista;
                            this.St_MotValidado = true;
                        }
                }
        }
    }
}
