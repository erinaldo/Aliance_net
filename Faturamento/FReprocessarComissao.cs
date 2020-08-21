using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Faturamento
{
    public partial class TFReprocessarComissao : Form
    {
        public List<CamadaDados.Faturamento.Pedido.TRegistro_LanPedido_Item> lItemPed
        {
            get
            {
                if (bsPedidoItens.Count > 0)
                    return (bsPedidoItens.List as CamadaDados.Faturamento.Pedido.TList_RegLanPedido_Item).FindAll(p => p.St_processar);
                else
                    return null;
            }
        }
        public List<CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento_Item> lItemNf
        {
            get
            {
                if (bsItensNf.Count > 0)
                    return (bsItensNf.List as CamadaDados.Faturamento.NotaFiscal.TList_RegLanFaturamento_Item).FindAll(p => p.St_processar);
                else
                    return null;
            }
        }
        public List<CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item> lItemVenda
        {
            get
            {
                if (bsItensVenda.Count > 0)
                    return (bsItensVenda.List as CamadaDados.Faturamento.PDV.TList_VendaRapida_Item).FindAll(p => p.St_processar);
                else
                    return null;
            }
        }
        public List<CamadaDados.Servicos.TRegistro_LanServicosPecas> lPecasOS
        {
            get
            {
                if (bsPecasOS.Count > 0)
                    return (bsPecasOS.List as CamadaDados.Servicos.TList_LanServicosPecas).FindAll(p => p.St_processar);
                else
                    return null;
            }
        }
        public List<CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete> lCte
        {
            get
            {
                if (bsCte.Count > 0)
                    return (bsCte.List as CamadaDados.Faturamento.CTRC.TList_ConhecimentoFrete).FindAll(p => p.St_processar);
                else return null;
            }
        }
        public List<CamadaDados.Frota.TRegistro_OutrasReceitas> lReceita
        {
            get
            {
                if (bsReceitas.Count > 0)
                    return (bsReceitas.List as CamadaDados.Frota.TList_OutrasReceitas).FindAll(p => p.St_processar);
                else return null;
            }
        }
        public List<CamadaDados.Locacao.TRegistro_ItensLocacao> lItensLocacao
        {
            get
            {
                if (bsItens.Count > 0)
                    return (bsItens.List as CamadaDados.Locacao.TList_ItensLocacao).FindAll(p => p.St_processar);
                else return null;
            }
        }

        public TFReprocessarComissao()
        {
            InitializeComponent();
        }

        private void afterBusca()
        {
            if(string.IsNullOrEmpty(CD_Empresa.Text))
            {
                MessageBox.Show("Obrigatorio informar empresa.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CD_Empresa.Focus();
                return;
            }
            if(string.IsNullOrEmpty(CD_CompVend.Text))
            {
                MessageBox.Show("Obrigatorio informar vendedor.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CD_CompVend.Focus();
                return;
            }
            if (tcCentral.SelectedTab.Equals(tpPedido))
            {
                //Buscar Pedido
                Utils.TpBusca[] filtro = new Utils.TpBusca[5];
                //Empresa
                filtro[0].vNM_Campo = "n.cd_empresa";
                filtro[0].vOperador = "=";
                filtro[0].vVL_Busca = "'" + CD_Empresa.Text.Trim() + "'";
                //Vendedor
                filtro[1].vNM_Campo = "a.cd_vendedor";
                filtro[1].vOperador = "=";
                filtro[1].vVL_Busca = "'" + CD_CompVend.Text.Trim() + "'";
                //Pedido Ativo
                filtro[2].vNM_Campo = "isnull(n.st_pedido, 'F')";
                filtro[2].vOperador = "<>";
                filtro[2].vVL_Busca = "'C'";
                //Item Pedido
                filtro[3].vNM_Campo = "isnull(a.st_registro, 'A')";
                filtro[3].vOperador = "<>";
                filtro[3].vVL_Busca = "'C'";
                //Pedido configurado para processar comissao
                filtro[4].vNM_Campo = string.Empty;
                filtro[4].vOperador = "exists";
                filtro[4].vVL_Busca = "(select 1 from tb_fat_cfgpedido x " +
                                      "where x.cfg_pedido = n.cfg_pedido " +
                                      "and isnull(x.st_comissaoPed, 'N') = 'S')";
                if (!string.IsNullOrEmpty(nr_pedido.Text))
                {
                    Array.Resize(ref filtro, filtro.Length + 1);
                    filtro[filtro.Length - 1].vNM_Campo = "a.nr_pedido";
                    filtro[filtro.Length - 1].vOperador = "=";
                    filtro[filtro.Length - 1].vVL_Busca = nr_pedido.Text;
                }
                if (!string.IsNullOrEmpty(dt_ini.Text.Trim().Replace("/", "").Trim()))
                {
                    Array.Resize(ref filtro, filtro.Length + 1);
                    filtro[filtro.Length - 1].vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), n.dt_pedido)))";
                    filtro[filtro.Length - 1].vOperador = ">=";
                    filtro[filtro.Length - 1].vVL_Busca = "'" + DateTime.Parse(dt_ini.Text).ToString("yyyyMMdd") + "'";
                }
                if (!string.IsNullOrEmpty(dt_fin.Text.Replace("/", "").Trim()))
                {
                    Array.Resize(ref filtro, filtro.Length + 1);
                    filtro[filtro.Length - 1].vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), n.dt_pedido)))";
                    filtro[filtro.Length - 1].vOperador = "<=";
                    filtro[filtro.Length - 1].vVL_Busca = "'" + DateTime.Parse(dt_fin.Text).ToString("yyyyMMdd") + "'";
                }
                bsPedidoItens.DataSource = new CamadaDados.Faturamento.Pedido.TCD_LanPedido_Item().Select(filtro, 0, string.Empty, string.Empty, "n.nr_pedido, n.dt_pedido");
                tot_pedido.Value = (bsPedidoItens.List as CamadaDados.Faturamento.Pedido.TList_RegLanPedido_Item).Sum(p => p.Vl_subtotal);
            }
            else if (tcCentral.SelectedTab.Equals(tpNf))
            {
                //Buscar Nota Fiscal
                Utils.TpBusca[] filtro = new Utils.TpBusca[4];
                //Empresa
                filtro[0].vNM_Campo = "a.cd_empresa";
                filtro[0].vOperador = "=";
                filtro[0].vVL_Busca = "'" + CD_Empresa.Text.Trim() + "'";
                //Vendedor
                filtro[1].vNM_Campo = "ped.cd_vendedor";
                filtro[1].vOperador = "=";
                filtro[1].vVL_Busca = "'" + CD_CompVend.Text.Trim() + "'";
                //Nota Ativa
                filtro[2].vNM_Campo = "isnull(nf.st_registro, 'A')";
                filtro[2].vOperador = "<>";
                filtro[2].vVL_Busca = "'C'";
                //Pedido configurado para processar comissao
                filtro[3].vNM_Campo = string.Empty;
                filtro[3].vOperador = "exists";
                filtro[3].vVL_Busca = "(select 1 from TB_FAT_CFGPedido x " +
                                      "inner join tb_fat_pedido y " +
                                      "on x.CFG_Pedido = y.CFG_Pedido " +
                                      "where y.Nr_Pedido = ped.Nr_Pedido " +
                                      "and isnull(x.ST_ComissaoFat, 'N') = 'S')";
                if (!string.IsNullOrEmpty(nr_notafiscal.Text))
                {
                    Array.Resize(ref filtro, filtro.Length + 1);
                    filtro[filtro.Length - 1].vNM_Campo = "nf.nr_notafiscal";
                    filtro[filtro.Length - 1].vOperador = "=";
                    filtro[filtro.Length - 1].vVL_Busca = nr_notafiscal.Text;
                }
                if (!string.IsNullOrEmpty(dt_ini.Text.Trim().Replace("/", "").Trim()))
                {
                    Array.Resize(ref filtro, filtro.Length + 1);
                    filtro[filtro.Length - 1].vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), nf.dt_emissao)))";
                    filtro[filtro.Length - 1].vOperador = ">=";
                    filtro[filtro.Length - 1].vVL_Busca = "'" + DateTime.Parse(dt_ini.Text).ToString("yyyyMMdd") + "'";
                }
                if (!string.IsNullOrEmpty(dt_fin.Text.Replace("/", "").Trim()))
                {
                    Array.Resize(ref filtro, filtro.Length + 1);
                    filtro[filtro.Length - 1].vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), nf.dt_emissao)))";
                    filtro[filtro.Length - 1].vOperador = "<=";
                    filtro[filtro.Length - 1].vVL_Busca = "'" + DateTime.Parse(dt_fin.Text).ToString("yyyyMMdd") + "'";
                }
                bsItensNf.DataSource = new CamadaDados.Faturamento.NotaFiscal.TCD_LanFaturamento_Item().Select(filtro, 0, string.Empty, string.Empty, "a.id_nfitem");
                tot_nota.Value = (bsItensNf.List as CamadaDados.Faturamento.NotaFiscal.TList_RegLanFaturamento_Item).Sum(p => p.Vl_subtotal);
            }
            else if (tcCentral.SelectedTab.Equals(tpVendaBalcao))
            {
                //Buscar Venda Rapida
                Utils.TpBusca[] filtro = new Utils.TpBusca[3];
                //Empresa
                filtro[0].vNM_Campo = "a.cd_empresa";
                filtro[0].vOperador = "=";
                filtro[0].vVL_Busca = "'" + CD_Empresa.Text.Trim() + "'";
                //Vendedor
                filtro[1].vNM_Campo = "a.cd_vendedor";
                filtro[1].vOperador = "=";
                filtro[1].vVL_Busca = "'" + CD_CompVend.Text.Trim() + "'";
                //Venda Ativa
                filtro[2].vNM_Campo = "isnull(vr.st_registro, 'A')";
                filtro[2].vOperador = "<>";
                filtro[2].vVL_Busca = "'C'";
                if (!string.IsNullOrEmpty(id_cupom.Text))
                {
                    Array.Resize(ref filtro, filtro.Length + 1);
                    filtro[filtro.Length - 1].vNM_Campo = "a.id_cupom";
                    filtro[filtro.Length - 1].vOperador = "=";
                    filtro[filtro.Length - 1].vVL_Busca = id_cupom.Text;
                }
                if (!string.IsNullOrEmpty(dt_ini.Text.Replace("/", "").Trim()))
                {
                    Array.Resize(ref filtro, filtro.Length + 1);
                    filtro[filtro.Length - 1].vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), cf.dt_emissao)))";
                    filtro[filtro.Length - 1].vOperador = ">=";
                    filtro[filtro.Length - 1].vVL_Busca = "'" + DateTime.Parse(dt_ini.Text).ToString("yyyyMMdd") + "'";
                }
                if (!string.IsNullOrEmpty(dt_fin.Text.Replace("/", "").Trim()))
                {
                    Array.Resize(ref filtro, filtro.Length + 1);
                    filtro[filtro.Length - 1].vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), cf.dt_emissao)))";
                    filtro[filtro.Length - 1].vOperador = "<=";
                    filtro[filtro.Length - 1].vVL_Busca = "'" + DateTime.Parse(dt_fin.Text).ToString("yyyyMMdd") + "'";
                }
                bsItensVenda.DataSource = new CamadaDados.Faturamento.PDV.TCD_VendaRapida_Item().Select(filtro, 0, string.Empty, string.Empty);
                tot_venda.Value = (bsItensVenda.List as CamadaDados.Faturamento.PDV.TList_VendaRapida_Item).Sum(p => p.Vl_subtotalliquido);
            }
            else if (tcCentral.SelectedTab.Equals(tpOs))
            {
                //Buscar Ordem Servico
                Utils.TpBusca[] filtro = new Utils.TpBusca[2];
                //Empresa
                filtro[0].vNM_Campo = "a.cd_empresa";
                filtro[0].vOperador = "=";
                filtro[0].vVL_Busca = "'" + CD_Empresa.Text.Trim() + "'";
                //Vendedor
                filtro[1].vNM_Campo = "a.CD_Tecnico";
                filtro[1].vOperador = "=";
                filtro[1].vVL_Busca = "'" + CD_CompVend.Text.Trim() + "'";
                if (!string.IsNullOrEmpty(id_cupom.Text))
                {
                    Array.Resize(ref filtro, filtro.Length + 1);
                    filtro[filtro.Length - 1].vNM_Campo = "a.id_os";
                    filtro[filtro.Length - 1].vOperador = "=";
                    filtro[filtro.Length - 1].vVL_Busca = id_os.Text;
                }
                if (!string.IsNullOrEmpty(dt_ini.Text.Replace("/", "").Trim()))
                {
                    Array.Resize(ref filtro, filtro.Length + 1);
                    filtro[filtro.Length - 1].vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), os.DT_Finalizada)))";
                    filtro[filtro.Length - 1].vOperador = ">=";
                    filtro[filtro.Length - 1].vVL_Busca = "'" + DateTime.Parse(dt_ini.Text).ToString("yyyyMMdd") + "'";
                }
                if (!string.IsNullOrEmpty(dt_fin.Text.Replace("/", "").Trim()))
                {
                    Array.Resize(ref filtro, filtro.Length + 1);
                    filtro[filtro.Length - 1].vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), os.DT_Finalizada)))";
                    filtro[filtro.Length - 1].vOperador = "<=";
                    filtro[filtro.Length - 1].vVL_Busca = "'" + DateTime.Parse(dt_fin.Text).ToString("yyyyMMdd") + "'";
                }
                bsPecasOS.DataSource = new CamadaDados.Servicos.TCD_LanServicosPecas().Select(filtro, 0, string.Empty, string.Empty);
                total_os.Value = (bsPecasOS.List as CamadaDados.Servicos.TList_LanServicosPecas).Sum(p => p.Vl_SubTotalLiq);
            }
            else if (tcCentral.SelectedTab.Equals(tpConhecimentoFrete))
            {
                //Buscar CTe
                Utils.TpBusca[] filtro = new Utils.TpBusca[3];
                //Empresa
                filtro[0].vNM_Campo = "a.cd_empresa";
                filtro[0].vOperador = "=";
                filtro[0].vVL_Busca = "'" + CD_Empresa.Text.Trim() + "'";
                //Vendedor
                filtro[1].vNM_Campo = "a.CD_Motorista";
                filtro[1].vOperador = "=";
                filtro[1].vVL_Busca = "'" + CD_CompVend.Text.Trim() + "'";
                //Status
                filtro[2].vNM_Campo = "isnull(a.st_registro, 'A')";
                filtro[2].vOperador = "<>";
                filtro[2].vVL_Busca = "'C'";
                if (!string.IsNullOrEmpty(nr_cte.Text))
                {
                    Array.Resize(ref filtro, filtro.Length + 1);
                    filtro[filtro.Length - 1].vNM_Campo = "a.nr_ctrc";
                    filtro[filtro.Length - 1].vOperador = "=";
                    filtro[filtro.Length - 1].vVL_Busca = nr_cte.Text;
                }
                if (!string.IsNullOrEmpty(dt_ini.Text.Replace("/", "").Trim()))
                {
                    Array.Resize(ref filtro, filtro.Length + 1);
                    filtro[filtro.Length - 1].vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.dt_emissao)))";
                    filtro[filtro.Length - 1].vOperador = ">=";
                    filtro[filtro.Length - 1].vVL_Busca = "'" + DateTime.Parse(dt_ini.Text).ToString("yyyyMMdd") + "'";
                }
                if (!string.IsNullOrEmpty(dt_fin.Text.Replace("/", "").Trim()))
                {
                    Array.Resize(ref filtro, filtro.Length + 1);
                    filtro[filtro.Length - 1].vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.dt_emissao)))";
                    filtro[filtro.Length - 1].vOperador = "<=";
                    filtro[filtro.Length - 1].vVL_Busca = "'" + DateTime.Parse(dt_fin.Text).ToString("yyyyMMdd") + "'";
                }
                bsCte.DataSource = new CamadaDados.Faturamento.CTRC.TCD_ConhecimentoFrete().Select(filtro, 0, string.Empty);
                total_cte.Value = (bsCte.List as CamadaDados.Faturamento.CTRC.TList_ConhecimentoFrete).Sum(p => p.Vl_frete);
            }
            else if (tcCentral.SelectedTab.Equals(tpReceitas))
            {
                //Buscar Outras Receitas
                Utils.TpBusca[] filtro = new Utils.TpBusca[2];
                //Empresa
                filtro[0].vNM_Campo = "a.cd_empresa";
                filtro[0].vOperador = "=";
                filtro[0].vVL_Busca = "'" + CD_Empresa.Text.Trim() + "'";
                //Vendedor
                filtro[1].vNM_Campo = "a.CD_Motorista";
                filtro[1].vOperador = "=";
                filtro[1].vVL_Busca = "'" + CD_CompVend.Text.Trim() + "'";
                if (!string.IsNullOrEmpty(id_receita.Text))
                {
                    Array.Resize(ref filtro, filtro.Length + 1);
                    filtro[filtro.Length - 1].vNM_Campo = "a.id_receita";
                    filtro[filtro.Length - 1].vOperador = "=";
                    filtro[filtro.Length - 1].vVL_Busca = id_receita.Text;
                }
                if (!string.IsNullOrEmpty(dt_ini.Text.Replace("/", "").Trim()))
                {
                    Array.Resize(ref filtro, filtro.Length + 1);
                    filtro[filtro.Length - 1].vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), os.DT_Finalizada)))";
                    filtro[filtro.Length - 1].vOperador = ">=";
                    filtro[filtro.Length - 1].vVL_Busca = "'" + DateTime.Parse(dt_ini.Text).ToString("yyyyMMdd") + "'";
                }
                if (!string.IsNullOrEmpty(dt_fin.Text.Replace("/", "").Trim()))
                {
                    Array.Resize(ref filtro, filtro.Length + 1);
                    filtro[filtro.Length - 1].vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), os.DT_Finalizada)))";
                    filtro[filtro.Length - 1].vOperador = "<=";
                    filtro[filtro.Length - 1].vVL_Busca = "'" + DateTime.Parse(dt_fin.Text).ToString("yyyyMMdd") + "'";
                }
                bsReceitas.DataSource = new CamadaDados.Frota.TCD_OutrasReceitas().Select(filtro, 0, string.Empty);
                tot_receita.Value = (bsReceitas.List as CamadaDados.Frota.TList_OutrasReceitas).Sum(p => p.Vl_receita);
            }
            else if (tcCentral.SelectedTab.Equals(tpLocacao))
            {
                //Buscar Locacao
                Utils.TpBusca[] filtro = new Utils.TpBusca[2];
                //Empresa
                filtro[0].vNM_Campo = "a.cd_empresa";
                filtro[0].vOperador = "=";
                filtro[0].vVL_Busca = "'" + CD_Empresa.Text.Trim() + "'";
                //Vendedor
                filtro[1].vNM_Campo = string.Empty;
                filtro[1].vOperador = "exists";
                filtro[1].vVL_Busca = "(select 1 from TB_LOC_Locacao x " +
                                      "where x.cd_empresa = a.cd_empresa " +
                                      "and x.id_locacao = a.id_locacao " +
                                      "and x.cd_vendedor = '" + CD_CompVend.Text.Trim() + "') ";
                if (!string.IsNullOrEmpty(id_locacao.Text))
                {
                    Array.Resize(ref filtro, filtro.Length + 1);
                    filtro[filtro.Length - 1].vNM_Campo = "a.id_locacao";
                    filtro[filtro.Length - 1].vOperador = "=";
                    filtro[filtro.Length - 1].vVL_Busca = id_locacao.Text;
                }
                if (!string.IsNullOrEmpty(dt_ini.Text.Replace("/", "").Trim()))
                {
                    Array.Resize(ref filtro, filtro.Length + 1);
                    filtro[filtro.Length - 1].vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), os.DT_Finalizada)))";
                    filtro[filtro.Length - 1].vOperador = ">=";
                    filtro[filtro.Length - 1].vVL_Busca = "'" + DateTime.Parse(dt_ini.Text).ToString("yyyyMMdd") + "'";
                }
                if (!string.IsNullOrEmpty(dt_fin.Text.Replace("/", "").Trim()))
                {
                    Array.Resize(ref filtro, filtro.Length + 1);
                    filtro[filtro.Length - 1].vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), os.DT_Finalizada)))";
                    filtro[filtro.Length - 1].vOperador = "<=";
                    filtro[filtro.Length - 1].vVL_Busca = "'" + DateTime.Parse(dt_fin.Text).ToString("yyyyMMdd") + "'";
                }
                bsItens.DataSource = new CamadaDados.Locacao.TCD_ItensLocacao().Select(filtro, 0, string.Empty, false);
                tot_locacao.Value = (bsItens.List as CamadaDados.Locacao.TList_ItensLocacao).Sum(p => p.Vl_locacao - p.Vl_frete - p.Vl_Baixa);
            }
        }

        private void TFReprocessarComissao_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, gItensNf);
            Utils.ShapeGrid.RestoreShape(this, gItensVenda);
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pFiltro.set_FormatZero();
        }

        private void BB_Empresa_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaEmpresa(new Componentes.EditDefault[] { CD_Empresa }, string.Empty);
        }

        private void CD_Empresa_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveEmpresa("a.cd_empresa|=|'" + CD_Empresa.Text.Trim() + "'", new Componentes.EditDefault[] { CD_Empresa });
        }

        private void BB_CompVend_Click(object sender, EventArgs e)
        {
            string vColunas = "a.nm_clifor|Nome Vendedor|200;" +
                              "a.cd_clifor|Cd. Vendedor|80";
            string vParam = "||(isnull(a.st_vendedor, 'N') = 'S') or (isnull(a.st_tecnico, 'N') = 'S') or (isnull(a.st_motorista, 'N') = 'S');" +
                            "isnull(a.st_funcativo, 'N')|=|'S'";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { CD_CompVend },
                new CamadaDados.Financeiro.Cadastros.TCD_CadClifor(),
               vParam);
        }

        private void CD_CompVend_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_clifor|=|'" + CD_CompVend.Text.Trim() + "';" +
                            "||(isnull(a.st_vendedor, 'N') = 'S') or (isnull(a.st_tecnico, 'N') = 'S') or (isnull(a.st_motorista, 'N') = 'S');" +
                            "isnull(a.st_funcativo, 'N')|=|'S'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { CD_CompVend },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
        }

        private void BB_Buscar_Click(object sender, EventArgs e)
        {
            this.afterBusca();
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void TFReprocessarComissao_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.DialogResult = DialogResult.OK;
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
            else if (e.KeyCode.Equals(Keys.F7))
                this.afterBusca();
        }

        private void gItensNf_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                (bsItensNf.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento_Item).St_processar =
                    !(bsItensNf.Current as CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento_Item).St_processar;
                bsItensNf.ResetCurrentItem();
                tot_nfprocessar.Value = (bsItensNf.List as CamadaDados.Faturamento.NotaFiscal.TList_RegLanFaturamento_Item).Where(p => p.St_processar).Sum(p => p.Vl_subtotal);
            }
        }

        private void gItensNf_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (gItensNf.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.NotSortable)
                return;
            if (bsItensNf.Count < 1)
                return;
            PropertyDescriptorCollection lP = TypeDescriptor.GetProperties(new CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento_Item());
            CamadaDados.Faturamento.NotaFiscal.TList_RegLanFaturamento_Item lComparer;
            SortOrder direcao = SortOrder.None;
            if ((gItensNf.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None) ||
                (gItensNf.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending))
            {
                lComparer = new CamadaDados.Faturamento.NotaFiscal.TList_RegLanFaturamento_Item(lP.Find(gItensNf.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Ascending);
                foreach (DataGridViewColumn c in gItensNf.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Ascending;
            }
            else
            {
                lComparer = new CamadaDados.Faturamento.NotaFiscal.TList_RegLanFaturamento_Item(lP.Find(gItensNf.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Descending);
                foreach (DataGridViewColumn c in gItensNf.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Descending;
            }
            (bsItensNf.List as CamadaDados.Faturamento.NotaFiscal.TList_RegLanFaturamento_Item).Sort(lComparer);
            bsItensNf.ResetBindings(false);
            gItensNf.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = direcao;
        }

        private void cbProcessar_Click(object sender, EventArgs e)
        {
            if (bsItensNf.Count > 0)
            {
                (bsItensNf.List as CamadaDados.Faturamento.NotaFiscal.TList_RegLanFaturamento_Item).ForEach(p => p.St_processar = cbProcessar.Checked);
                bsItensNf.ResetBindings(true);
                tot_nfprocessar.Value = (bsItensNf.List as CamadaDados.Faturamento.NotaFiscal.TList_RegLanFaturamento_Item).Where(p => p.St_processar).Sum(p => p.Vl_subtotal);
            }
        }

        private void gItensVenda_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                (bsItensVenda.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item).St_processar =
                    !(bsItensVenda.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item).St_processar;
                bsItensVenda.ResetCurrentItem();
                tot_vendaprocessar.Value = (bsItensVenda.List as CamadaDados.Faturamento.PDV.TList_VendaRapida_Item).Where(p => p.St_processar).Sum(p => p.Vl_subtotalliquido);
            }
        }

        private void gItensVenda_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (gItensVenda.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.NotSortable)
                return;
            if (bsItensVenda.Count < 1)
                return;
            PropertyDescriptorCollection lP = TypeDescriptor.GetProperties(new CamadaDados.Faturamento.PDV.TRegistro_VendaRapida_Item());
            CamadaDados.Faturamento.PDV.TList_VendaRapida_Item lComparer;
            SortOrder direcao = SortOrder.None;
            if ((gItensVenda.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None) ||
                (gItensVenda.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending))
            {
                lComparer = new CamadaDados.Faturamento.PDV.TList_VendaRapida_Item(lP.Find(gItensVenda.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Ascending);
                foreach (DataGridViewColumn c in gItensVenda.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Ascending;
            }
            else
            {
                lComparer = new CamadaDados.Faturamento.PDV.TList_VendaRapida_Item(lP.Find(gItensVenda.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Descending);
                foreach (DataGridViewColumn c in gItensVenda.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Descending;
            }
            (bsItensVenda.List as CamadaDados.Faturamento.PDV.TList_VendaRapida_Item).Sort(lComparer);
            bsItensVenda.ResetBindings(false);
            gItensVenda.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = direcao;
        }

        private void stProcessar_Click(object sender, EventArgs e)
        {
            if (bsItensVenda.Count > 0)
            {
                (bsItensVenda.List as CamadaDados.Faturamento.PDV.TList_VendaRapida_Item).ForEach(p => p.St_processar = stProcessar.Checked);
                bsItensVenda.ResetBindings(true);
                tot_vendaprocessar.Value = (bsItensVenda.List as CamadaDados.Faturamento.PDV.TList_VendaRapida_Item).Where(p => p.St_processar).Sum(p => p.Vl_subtotalliquido);
            }
        }

        private void TFReprocessarComissao_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, gItensNf);
            Utils.ShapeGrid.SaveShape(this, gItensVenda);
        }

        private void gPecasOS_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                (bsPecasOS.Current as CamadaDados.Servicos.TRegistro_LanServicosPecas).St_processar =
                    !(bsPecasOS.Current as CamadaDados.Servicos.TRegistro_LanServicosPecas).St_processar;
                bsPecasOS.ResetCurrentItem();
                total_osProc.Value = (bsPecasOS.List as CamadaDados.Servicos.TList_LanServicosPecas).Where(p => p.St_processar).Sum(p => p.Vl_SubTotalLiq);
            }
        }

        private void st_processarOS_Click(object sender, EventArgs e)
        {
            if (bsPecasOS.Count > 0)
            {
                (bsPecasOS.List as CamadaDados.Servicos.TList_LanServicosPecas).ForEach(p => p.St_processar = st_processarOS.Checked);
                bsPecasOS.ResetBindings(true);
                total_osProc.Value = (bsPecasOS.List as CamadaDados.Servicos.TList_LanServicosPecas).Where(p => p.St_processar).Sum(p => p.Vl_SubTotalLiq);
            }
        }

        private void gPedidoItens_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                (bsPedidoItens.Current as CamadaDados.Faturamento.Pedido.TRegistro_LanPedido_Item).St_processar =
                    !(bsPedidoItens.Current as CamadaDados.Faturamento.Pedido.TRegistro_LanPedido_Item).St_processar;
                bsPedidoItens.ResetCurrentItem();
                tot_pedprocessar.Value = (bsPedidoItens.List as CamadaDados.Faturamento.Pedido.TList_RegLanPedido_Item).Where(p => p.St_processar).Sum(p => p.VL_Total_Item);
            }
        }

        private void gPedidoItens_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (gPedidoItens.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.NotSortable)
                return;
            if (bsPedidoItens.Count < 1)
                return;
            PropertyDescriptorCollection lP = TypeDescriptor.GetProperties(new CamadaDados.Faturamento.Pedido.TRegistro_LanPedido_Item());
            CamadaDados.Faturamento.Pedido.TList_RegLanPedido_Item lComparer;
            SortOrder direcao = SortOrder.None;
            if ((gPedidoItens.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None) ||
                (gPedidoItens.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending))
            {
                lComparer = new CamadaDados.Faturamento.Pedido.TList_RegLanPedido_Item(lP.Find(gItensVenda.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Ascending);
                foreach (DataGridViewColumn c in gPedidoItens.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Ascending;
            }
            else
            {
                lComparer = new CamadaDados.Faturamento.Pedido.TList_RegLanPedido_Item(lP.Find(gItensVenda.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Descending);
                foreach (DataGridViewColumn c in gPedidoItens.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Descending;
            }
            (bsPedidoItens.List as CamadaDados.Faturamento.Pedido.TList_RegLanPedido_Item).Sort(lComparer);
            bsPedidoItens.ResetBindings(false);
            gPedidoItens.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = direcao;
        }

        private void cbProcessarPed_Click(object sender, EventArgs e)
        {
            if (bsPedidoItens.Count > 0)
            {
                (bsPedidoItens.List as CamadaDados.Faturamento.Pedido.TList_RegLanPedido_Item).ForEach(p => p.St_processar = cbProcessarPed.Checked);
                bsPedidoItens.ResetBindings(true);
                tot_pedprocessar.Value = (bsPedidoItens.List as CamadaDados.Faturamento.Pedido.TList_RegLanPedido_Item).Where(p => p.St_processar).Sum(p => p.VL_Total_Item);
            }
        }

        private void gCte_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                (bsCte.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).St_processar =
                    !(bsCte.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete).St_processar;
                bsCte.ResetCurrentItem();
                total_cteProc.Value = (bsCte.List as CamadaDados.Faturamento.CTRC.TList_ConhecimentoFrete).Where(p => p.St_processar).Sum(p => p.Vl_frete);
            }
        }

        private void st_processarCTe_Click(object sender, EventArgs e)
        {
            if (bsCte.Count > 0)
            {
                (bsCte.List as CamadaDados.Faturamento.CTRC.TList_ConhecimentoFrete).ForEach(p => p.St_processar = st_processarCTe.Checked);
                bsCte.ResetBindings(true);
                total_cteProc.Value = (bsCte.List as CamadaDados.Faturamento.CTRC.TList_ConhecimentoFrete).Where(p => p.St_processar).Sum(p => p.Vl_frete);
            }
        }

        private void gReceitas_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (gReceitas.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.NotSortable)
                return;
            if (bsReceitas.Count < 1)
                return;
            PropertyDescriptorCollection lP = TypeDescriptor.GetProperties(new CamadaDados.Frota.TRegistro_OutrasReceitas());
            CamadaDados.Frota.TList_OutrasReceitas lComparer;
            SortOrder direcao = SortOrder.None;
            if ((gReceitas.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None) ||
                (gReceitas.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending))
            {
                lComparer = new CamadaDados.Frota.TList_OutrasReceitas(lP.Find(gReceitas.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Ascending);
                foreach (DataGridViewColumn c in gReceitas.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Ascending;
            }
            else
            {
                lComparer = new CamadaDados.Frota.TList_OutrasReceitas(lP.Find(gReceitas.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Descending);
                foreach (DataGridViewColumn c in gReceitas.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Descending;
            }
            (bsReceitas.List as CamadaDados.Frota.TList_OutrasReceitas).Sort(lComparer);
            bsReceitas.ResetBindings(false);
            gReceitas.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = direcao;
        }

        private void gReceitas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                (bsReceitas.Current as CamadaDados.Frota.TRegistro_OutrasReceitas).St_processar =
                    !(bsReceitas.Current as CamadaDados.Frota.TRegistro_OutrasReceitas).St_processar;
                bsReceitas.ResetCurrentItem();
                tot_recProc.Value = (bsReceitas.List as CamadaDados.Frota.TList_OutrasReceitas).Where(p => p.St_processar).Sum(p => p.Vl_receita);
            }
        }

        private void st_receitas_Click(object sender, EventArgs e)
        {
            if (bsReceitas.Count > 0)
            {
                (bsReceitas.List as CamadaDados.Frota.TList_OutrasReceitas).ForEach(p => p.St_processar = st_receitas.Checked);
                bsReceitas.ResetBindings(true);
                tot_recProc.Value = (bsReceitas.List as CamadaDados.Frota.TList_OutrasReceitas).Where(p => p.St_processar).Sum(p => p.Vl_receita);
            }
        }

        private void gItens_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                (bsItens.Current as CamadaDados.Locacao.TRegistro_ItensLocacao).St_processar =
                    !(bsItens.Current as CamadaDados.Locacao.TRegistro_ItensLocacao).St_processar;
                bsItens.ResetCurrentItem();
                tot_locProc.Value = (bsItens.List as CamadaDados.Locacao.TList_ItensLocacao).Where(p => p.St_processar).Sum(p => p.Vl_locacao - p.Vl_frete - p.Vl_Baixa);
            }
        }

        private void st_locacao_Click(object sender, EventArgs e)
        {
            if (bsItens.Count > 0)
            {
                (bsItens.List as CamadaDados.Locacao.TList_ItensLocacao).ForEach(p => p.St_processar = st_locacao.Checked);
                bsItens.ResetBindings(true);
                tot_locProc.Value = (bsItens.List as CamadaDados.Locacao.TList_ItensLocacao).Where(p => p.St_processar).Sum(p => p.Vl_locacao - p.Vl_frete - p.Vl_Baixa);
            }
        }

        private void gItens_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (gItens.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.NotSortable)
                return;
            if (bsItens.Count < 1)
                return;
            PropertyDescriptorCollection lP = TypeDescriptor.GetProperties(new CamadaDados.Locacao.TList_ItensLocacao());
            CamadaDados.Locacao.TList_ItensLocacao lComparer;
            SortOrder direcao = SortOrder.None;
            if ((gItens.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None) ||
                (gItens.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending))
            {
                lComparer = new CamadaDados.Locacao.TList_ItensLocacao(lP.Find(gItens.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Ascending);
                foreach (DataGridViewColumn c in gItens.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Ascending;
            }
            else
            {
                lComparer = new CamadaDados.Locacao.TList_ItensLocacao(lP.Find(gItens.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Descending);
                foreach (DataGridViewColumn c in gItens.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Descending;
            }
            (bsItens.List as CamadaDados.Locacao.TList_ItensLocacao).Sort(lComparer);
            bsItens.ResetBindings(false);
            gItens.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = direcao;
        }
    }
}
