using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using CamadaDados.Servicos;
using CamadaNegocio.Servicos;
using System.Text;
using System.Windows.Forms;
using FormBusca;
using Utils;
using CamadaDados.Diversos;

namespace Servicos
{
    public partial class TFLan_Fecha_Ordem_Servico : Form
    {
        public string pCd_empresa
        { get; set; }
        public string pTp_ordem
        { get; set; }
        public string pCd_clifor
        { get; set; }
        public List<CamadaDados.Servicos.TRegistro_LanServico> lOs
        {
            get
            {
                if (bsOS.Count > 0)
                    return (bsOS.List as CamadaDados.Servicos.TList_LanServico).FindAll(p => p.St_processarOS);
                else
                    return null;
            }
        }
        public CamadaDados.Servicos.TList_LanServicosPecas lItens
        {
            get
            {
                if (BS_Pecas.Count > 0)
                    return (BS_Pecas.List as CamadaDados.Servicos.TList_LanServicosPecas);
                else
                    return null;
            }
        }

        private bool St_osinterna
        { get; set; }

        public TFLan_Fecha_Ordem_Servico()
        {
            InitializeComponent();
        }

        private void afterGrava()
        {
            if (bsOS.Count > 0)
            {
                if (vl_minimopedido.Value > 0)
                    if (st_gerarpedidoservicoseparado.Checked)
                    {
                        if (vl_totalpecas.Value < vl_minimopedido.Value)
                        {
                            MessageBox.Show("Valor total das peças a ser faturado é menor que o valor minimo configurado para gerar pedido.",
                                            "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        if (vl_totalservicos.Value < vl_minimopedido.Value)
                        {
                            MessageBox.Show("Valor total dos serviços a ser faturado é menor que o valor minimo configurado para gerar pedido.",
                                            "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    }
                    else if ((vl_totalservicos.Value + vl_totalpecas.Value) < vl_minimopedido.Value)
                    {
                        MessageBox.Show("Valor total das peças e/ou serviços é menor que o valor minimo configurado para gerar pedido.",
                                        "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                if (BS_Pecas.Count < 1)
                    if (!(MessageBox.Show("Não existe peças/serviços para processar Ordem(s) de Serviço(s).\r\n" +
                                    "Confirma processamento mesmo assim?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                                    MessageBoxDefaultButton.Button1) == DialogResult.Yes))
                        return;
                try
                {
                    //Buscar evoluções
                    (bsOS.Current as TRegistro_LanServico).lEvolucao  = 
                        new CamadaDados.Servicos.TCD_LanServicoEvolucao().Select(
                            new Utils.TpBusca[]
                            {
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "a.id_os",
                                    vOperador = "=",
                                    vVL_Busca = (bsOS.Current as CamadaDados.Servicos.TRegistro_LanServico).Id_osstr
                                },
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "a.cd_empresa",
                                    vOperador = "=",
                                    vVL_Busca = "'" + (bsOS.Current as CamadaDados.Servicos.TRegistro_LanServico).Cd_empresa.Trim() + "'"
                                }
                            }, 0, string.Empty, "a.dt_inicio");
                    object obj = new CamadaDados.Servicos.Cadastros.TCD_TpOrdem().BuscarEscalar(
                               new Utils.TpBusca[]
                                {
                                    new Utils.TpBusca()
                                    {
                                        vNM_Campo = "a.tp_ordem",
                                        vOperador = "=",
                                        vVL_Busca = (bsOS.Current as TRegistro_LanServico).Tp_ordemstr

                                    }
                                }, "a.tp_faturamento");
                    if (obj == null ? false : obj.ToString().ToString().Equals("V"))
                    {
                        if(BS_Pecas.Current != null)
                            (bsOS.Current as TRegistro_LanServico).lPecas = (BS_Pecas.List as CamadaDados.Servicos.TList_LanServicosPecas);

                        CamadaDados.Faturamento.Pedido.TRegistro_Pedido rPedGarantia = null;
                        CamadaDados.Faturamento.PDV.TRegistro_PreVenda rPreVenda =
                            Proc_Commoditties.TProcessarOS.ProcessarOSPeca(bsOS.Current as TRegistro_LanServico, ref rPedGarantia);
                        CamadaNegocio.Servicos.TCN_LanServico.ProcessarOSPreVenda(bsOS.Current as TRegistro_LanServico, rPreVenda, rPedGarantia, null);
                        MessageBox.Show("Ordem serviço processada com sucesso.", "Pergunta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (rPedGarantia != null)
                        {
                            //Buscar pedido
                            rPedGarantia = CamadaNegocio.Faturamento.Pedido.TCN_Pedido.Busca_Registro_Pedido(rPedGarantia.Nr_pedido.ToString(), null);
                            //Buscar itens pedido
                            CamadaNegocio.Faturamento.Pedido.TCN_Pedido.Busca_Pedido_Itens(rPedGarantia, false, null);
                            //Gerar Nota Fiscal
                            CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento rFat =
                                Proc_Commoditties.TProcessaPedFaturar.ProcessaPedFaturar(rPedGarantia, false, decimal.Zero);
                            //Gravar Nota Fiscal
                            CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento.GravarFaturamento(rFat, null, null);
                            if (rFat.Cd_modelo.Trim().Equals("55"))
                            {
                                if (MessageBox.Show("Deseja enviar NF-e para a receita agora?", "Pergunta", MessageBoxButtons.YesNo,
                                     MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                                {
                                    try
                                    {
                                        using (srvNFE.TFGerenciarNFe fGerNfe = new srvNFE.TFGerenciarNFe())
                                        {
                                            fGerNfe.rNfe = CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento.BuscarNF(rFat.Cd_empresa,
                                                                                                                            rFat.Nr_lanctofiscalstr,
                                                                                                                            null);
                                            fGerNfe.ShowDialog();
                                        }
                                    }
                                    catch (Exception ex)
                                    { MessageBox.Show("Erro enviar NF-e: " + ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                                }
                            }
                        }
                    }
                    else
                    {
                        CamadaNegocio.Servicos.TCN_LanServico.ProcessarServico((bsOS.List as CamadaDados.Servicos.TList_LanServico).FindAll(p => p.St_processarOS),
                                                                               St_osinterna ? null : Proc_Commoditties.TProcessaPedidoOS.ProcessarOS((bsOS.List as CamadaDados.Servicos.TList_LanServico).FindAll(p => p.St_processarOS)),
                                                                               null);
                        MessageBox.Show("Ordem(s) de Serviço(s) processada(s) com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }


                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.Trim());
                }
            }
            else
                MessageBox.Show("Não existe ordem de serviço marcada para processar.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void afterBusca()
        {
            if (CD_Empresa.Text.Trim().Equals(string.Empty))
            {
                MessageBox.Show("Obrigatorio informar empresa.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CD_Empresa.Focus();
                return;
            }
            if (TP_Ordem.Text.Trim().Equals(string.Empty))
            {
                MessageBox.Show("Obrigatorio informar tipo de ordem.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TP_Ordem.Focus();
                return;
            }
            if (CD_Clifor.Text.Trim().Equals(string.Empty))
            {
                MessageBox.Show("Obrigatorio informar cliente.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CD_Clifor.Focus();
                return;
            }
            bsOS.DataSource = CamadaNegocio.Servicos.TCN_LanServico.Buscar(string.Empty,
                                                                           CD_Empresa.Text,
                                                                           CD_Clifor.Text,
                                                                           string.Empty,
                                                                           CD_Produto.Text,
                                                                           string.Empty,
                                                                           string.Empty,
                                                                           string.Empty,
                                                                           string.Empty,
                                                                           string.Empty,
                                                                           string.Empty,
                                                                           string.Empty,
                                                                           string.Empty,
                                                                           string.Empty,
                                                                           "A",
                                                                           DT_Inic.Text,
                                                                           DT_Final.Text,
                                                                           "'FE'",
                                                                           string.Empty,
                                                                           false,
                                                                           string.Empty,
                                                                           string.Empty,
                                                                           string.Empty,
                                                                           false,
                                                                           false,
                                                                           false,
                                                                           false,
                                                                           false,
                                                                           0,
                                                                           string.Empty,
                                                                           string.Empty,
                                                                           null);
        }

        private void afterBuscaItens()
        {
            if (bsOS.Count > 0)
            {
                string vid_os = string.Empty;
                string virg = string.Empty;
                (bsOS.List as CamadaDados.Servicos.TList_LanServico).ForEach(p =>
                    {
                        if (p.St_processarOS)
                        {
                            vid_os += virg + p.Id_os.ToString();
                            virg = ",";
                        }
                    });
                BS_Pecas.Clear();
                if(vid_os.Trim() != string.Empty)
                    BS_Pecas.DataSource = new CamadaDados.Servicos.TCD_LanServicosPecas().Select(
                        new TpBusca[]
                        {
                            new TpBusca()
                            {
                                vNM_Campo = "a.cd_empresa",
                                vOperador = "=",
                                vVL_Busca = "'" + CD_Empresa.Text.Trim() + "'"
                            },
                            new TpBusca()
                            {
                                vNM_Campo = "a.id_os",
                                vOperador = "in",
                                vVL_Busca = "(" + vid_os + ")"
                            }
                        }, 0, string.Empty, string.Empty);
                this.CalcularTotais();
            }
        }

        private void CalcularTotais()
        {
            if (BS_Pecas.DataSource != null)
            {
                vl_totalpecas.Value = (BS_Pecas.List as CamadaDados.Servicos.TList_LanServicosPecas).Where(p => (!p.St_atendimentogarantiabool) && (!p.St_servicobool)).Sum(p => p.Vl_SubTotalLiq);
                vl_totalpecasgarantia.Value = (BS_Pecas.List as CamadaDados.Servicos.TList_LanServicosPecas).Where(p => p.St_atendimentogarantiabool && (!p.St_servicobool)).Sum(p => p.Vl_SubTotalLiq);
                vl_totalservicos.Value = (BS_Pecas.List as CamadaDados.Servicos.TList_LanServicosPecas).Where(p => (!p.St_atendimentogarantiabool) && p.St_servicobool).Sum(p => p.Vl_SubTotalLiq);
                vl_totalservicosgarantia.Value = (BS_Pecas.List as CamadaDados.Servicos.TList_LanServicosPecas).Where(p => p.St_atendimentogarantiabool && p.St_servicobool).Sum(p => p.Vl_SubTotalLiq);
                vl_totalgeral.Value = vl_totalpecas.Value + vl_totalpecasgarantia.Value + vl_totalservicos.Value + vl_totalservicosgarantia.Value;
            }
        }

        private void BuscarCfgParam()
        {
            if (TP_Ordem.Text.Trim() != string.Empty)
            {
                CamadaDados.Servicos.Cadastros.TList_OSE_ParamOS lParam =
                    CamadaNegocio.Servicos.Cadastros.TCN_OSE_ParamOS.Buscar(TP_Ordem.Text,
                                                                            string.Empty,
                                                                            string.Empty,
                                                                            string.Empty,
                                                                            string.Empty,
                                                                            string.Empty,
                                                                            string.Empty,
                                                                            string.Empty,
                                                                            string.Empty,
                                                                            0,
                                                                            string.Empty,
                                                                            null);
                if (lParam.Count > 0)
                {
                    st_gerarpedidoservicoseparado.Checked = lParam[0].St_gerarpedidoservicoseparadobool;
                    vl_minimopedido.Value = lParam[0].Vl_minimopedido;
                }
            }
        }

        private void FLan_Fecha_Ordem_Servico_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, g_Pecas);
            Utils.ShapeGrid.RestoreShape(this, gOS);
            if (!string.IsNullOrEmpty(Utils.Parametros.pubCultura))
                Idioma.TIdioma.AjustaCultura(this);
            this.Icon = ResourcesUtils.TecnoAliance_ICO;
            this.pFiltros.set_FormatZero();
            CD_Empresa.Text = pCd_empresa;
            TP_Ordem.Text = pTp_ordem;
            CD_Clifor.Text = pCd_clifor;
            if (!string.IsNullOrEmpty(pCd_empresa) &&
                !string.IsNullOrEmpty(pTp_ordem) &&
                !string.IsNullOrEmpty(pCd_clifor))
                this.afterBusca();
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            this.afterGrava();
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void FLan_Fecha_Ordem_Servico_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.afterGrava();
            else if (e.KeyCode.Equals(Keys.F7))
                this.afterBusca();
        }

        private void BB_Empresa_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BUSCA("a.NM_empresa|Nome Empresa|300;a.CD_Empresa|Cód Empresa|100"
              , new Componentes.EditDefault[] { CD_Empresa, NM_Empresa }
              , new CamadaDados.Diversos.TCD_CadEmpresa(),
              "|EXISTS|(select 1 from Tb_div_usuario_X_empresa  x where x.login = '" + CamadaDados.TDataQuery.getPubVariavel(TInfo.pub, "LOGIN") + "' and x.cd_empresa = A.cd_empresa)");
        }

        private void CD_Empresa_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("a.cd_empresa|=|'" + CD_Empresa.Text + "';" +
                                  "|EXISTS|(select 1 from Tb_div_usuario_X_empresa  x where x.login = '" + CamadaDados.TDataQuery.getPubVariavel(TInfo.pub, "LOGIN") + "' and x.cd_empresa = A.cd_empresa)"
              , new Componentes.EditDefault[] { CD_Empresa, NM_Empresa }, new CamadaDados.Diversos.TCD_CadEmpresa());
        }

        private void BB_TPOrdem_Click(object sender, EventArgs e)
        {
            DataRowView linha = UtilPesquisa.BTN_BUSCA("a.DS_TipoOrdem|Tipo Ordem|300;a.tp_Ordem|Código|90;a.tp_os|Tipo Ordem|80", 
                                new Componentes.EditDefault[] { TP_Ordem, DS_TPOrdem }, new CamadaDados.Servicos.Cadastros.TCD_TpOrdem(), string.Empty);
            if (linha != null)
                St_osinterna = linha["tp_os"].ToString().Trim().ToUpper().Equals("I");
            this.BuscarCfgParam();
        }

        private void TP_Ordem_Leave(object sender, EventArgs e)
        {
            DataRow linha = UtilPesquisa.EDIT_LEAVE("a.tp_Ordem|=|" + TP_Ordem.Text, new Componentes.EditDefault[] { TP_Ordem, DS_TPOrdem }, 
                                                    new CamadaDados.Servicos.Cadastros.TCD_TpOrdem());
            if (linha != null)
                St_osinterna = linha["tp_os"].ToString().Trim().ToUpper().Equals("I");
            this.BuscarCfgParam();
        }

        private void BB_Produto_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BUSCA("a.DS_Produto|Produto|300;a.cd_Produto|Código Produto|90"
                          , new Componentes.EditDefault[] { CD_Produto }, new CamadaDados.Estoque.Cadastros.TCD_CadProduto(), string.Empty);
        }

        private void CD_Produto_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("a.cd_produto|=|'" + CD_Produto.Text + "'"
               , new Componentes.EditDefault[] { CD_Produto }, new CamadaDados.Estoque.Cadastros.TCD_CadProduto());
        }

        private void BB_Clifor_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { CD_Clifor }, string.Empty);
        }

        private void CD_Clifor_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("a.cd_clifor|=|'" + CD_Clifor.Text + "'"
               , new Componentes.EditDefault[] { CD_Clifor }, new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
        }

        private void BB_Fechar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void BB_Buscar_Click(object sender, EventArgs e)
        {
            this.afterBusca();
        }

        private void gOrdemServico_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                (bsOS.Current as CamadaDados.Servicos.TRegistro_LanServico).St_processarOS = !(bsOS.Current as CamadaDados.Servicos.TRegistro_LanServico).St_processarOS;
                this.afterBuscaItens();
            }
        }

        private void TFLan_Fecha_Ordem_Servico_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, g_Pecas);
            Utils.ShapeGrid.SaveShape(this, gOS);
        }
    }
}
