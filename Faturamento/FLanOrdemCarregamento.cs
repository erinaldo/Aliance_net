using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using CamadaDados.Diversos;
using FormBusca;
using CamadaDados.Financeiro.Cadastros;
using CamadaDados.Faturamento.Pedido;
using CamadaNegocio.Financeiro.Cadastros;
using Utils;
using CamadaDados.Faturamento.NotaFiscal;
using CamadaNegocio.Faturamento.NotaFiscal;
using FormRelPadrao;
using CamadaNegocio.Financeiro.Bloqueto;
using CamadaDados.Financeiro.Duplicata;
using CamadaNegocio.Faturamento.Pedido;
using CamadaDados.Faturamento.Cadastros;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faturamento
{
    public partial class TFLanOrdemCarregamento : Form
    {
        private bool Altera_Relatorio = false;
        public TFLanOrdemCarregamento()
        {
            InitializeComponent();
        }

        private void afterNovo()
        {
            if (BS_Pedido.Current != null)
                using (TFGerarOrdemCarregamento fOrdem = new TFGerarOrdemCarregamento())
                {
                    fOrdem.rPedido = BS_Pedido.Current as TRegistro_Pedido;
                    if (fOrdem.ShowDialog() == DialogResult.OK)
                        if (fOrdem.rOrdem != null)
                            try
                            {
                                TCN_OrdemCarregamento.Gravar(fOrdem.rOrdem, null);
                                MessageBox.Show("Ordem de carregamento gravada com sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                afterBusca();
                            }
                            catch (Exception ex)
                            { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
        }

        private void afterExclui()
        {
            if (bsOrdemCarregamento.Current != null)
            {
                if ((bsOrdemCarregamento.Current as TRegistro_OrdemCarregamento).lExp.Exists(p => p.Nr_lanctoFiscal != null))
                {
                    MessageBox.Show("Ordem de Carregamento possui pedido faturado!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (MessageBox.Show("Confirma o cancelamento da Ordem de Carregamento!", "Pergunta",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                    == DialogResult.Yes)
                    try
                    {
                        TCN_OrdemCarregamento.Excluir(bsOrdemCarregamento.Current as TRegistro_OrdemCarregamento, null);
                        MessageBox.Show("Ordem de Carregamento cancelada com sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        afterBusca();
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void afterBusca()
        {
            TpBusca[] filtro = new TpBusca[3];
            //Pedidos Encerrados e fechados
            filtro[0].vNM_Campo = "a.ST_Pedido";
            filtro[0].vOperador = "in";
            filtro[0].vVL_Busca = "('F', 'P')";
            //Buscar somente pedidos de saida
            filtro[1].vNM_Campo = "a.TP_Movimento";
            filtro[1].vOperador = "=";
            filtro[1].vVL_Busca = "'S'";
            //Buscar somente pedidos que estao alocados na Expedição
            filtro[2].vNM_Campo = string.Empty;
            filtro[2].vOperador = "EXISTS";
            filtro[2].vVL_Busca = "(select 1 from TB_FAT_ItensExpedicao x " +
                            "         where a.nr_pedido = x.nr_pedido )";
            if (!string.IsNullOrEmpty(CD_Empresa.Text))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.CD_Empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + CD_Empresa.Text.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(NR_Pedido_Busca.Text))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.Nr_Pedido";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = NR_Pedido_Busca.Text;
            }
            if (!string.IsNullOrEmpty(Nr_orcamento.Text))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = string.Empty;
                filtro[filtro.Length - 1].vOperador = string.Empty;
                filtro[filtro.Length - 1].vVL_Busca = "(exists( select 1 from tb_fat_pedido_itens x" +
                                                        " where x.nr_pedido = a.nr_pedido" +
                                                        " and x.nr_orcamento = '" + Nr_orcamento.Text.Trim() + "'))";
            }
            if (!string.IsNullOrEmpty(CD_Clifor.Text))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.CD_Clifor";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + CD_Clifor.Text.Trim() + "'";
            }
            if (cck_Encerrado.Checked ||
                cck_Fechado.Checked ||
                cck_Parcial.Checked)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.ST_Pedido";
                filtro[filtro.Length - 1].vOperador = "IN";

                string Virgula = "";
                string IN = "( ";

                if (cck_Fechado.Checked || cck_Parcial.Checked)
                {
                    IN += Virgula + "'F'";
                    Virgula = ",";
                }

                if (cck_Encerrado.Checked)
                {
                    IN += Virgula + "'P'";
                    Virgula = ",";
                }
                filtro[filtro.Length - 1].vVL_Busca = IN + ")";
            }
            if (cck_Parcial.Checked)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = string.Empty;
                filtro[filtro.Length - 1].vOperador = string.Empty;
                filtro[filtro.Length - 1].vVL_Busca = "a.vl_totalpedido - (case when a.tp_movimento = 'E' then " +
                                                      "vl_totalfat_entrada - vl_totalfat_saida else " +
                                                      "vl_totalfat_saida - vl_totalfat_entrada end) > 0 and " +
                                                      "a.vl_totalpedido - (case when a.tp_movimento = 'E' then " +
                                                      "vl_totalfat_entrada - vl_totalfat_saida else " +
                                                      "vl_totalfat_saida - vl_totalfat_entrada end) < a.vl_totalpedido";
            }
            if ((dt_ini.Text.Trim() != string.Empty) && (dt_ini.Text.Trim() != "/  /"))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.dt_pedido";
                filtro[filtro.Length - 1].vOperador = ">=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + string.Format(new System.Globalization.CultureInfo("en-US", true), Convert.ToDateTime(dt_ini.Text).ToString("yyyyMMdd")) + " 00:00:00'";
            }
            if ((dt_fin.Text.Trim() != string.Empty) && (dt_fin.Text.Trim() != "/  /"))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.dt_pedido";
                filtro[filtro.Length - 1].vOperador = "<=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + string.Format(new System.Globalization.CultureInfo("en-US", true), Convert.ToDateTime(dt_fin.Text).ToString("yyyyMMdd")) + " 23:59:59'";
            }

            BS_Pedido.DataSource = new TCD_Pedido().Select(filtro, 0, string.Empty);
            BS_Pedido_PositionChanged(this, new EventArgs());   
        }

        private void faturarPedido()
        {
            if (BS_Pedido.Current != null)
            {
                if (!bloqueioCredito())
                {
                    MessageBox.Show("Cliente possui restrição de crédito.\r\n" +
                                   "Financeiro não poderá ser gravado.", "Mensagem", MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                    return;
                }
                //Verificar se pedido é de entrega futura e se já possui nota mestra
                if (new CamadaDados.Faturamento.Cadastros.TCD_CadCFGPedidoFiscal().BuscarEscalar(
                        new TpBusca[]
                        {
                        new TpBusca()
                        {
                            vNM_Campo = "a.cfg_pedido",
                            vOperador = "=",
                            vVL_Busca = "'" + (BS_Pedido.Current as TRegistro_Pedido).CFG_Pedido.Trim() + "'"
                        },
                        new TpBusca()
                        {
                            vNM_Campo = "a.tp_fiscal",
                            vOperador = "=",
                            vVL_Busca = "'FT'"
                        }
                        }, "1") != null &&
                    new CamadaDados.Faturamento.NotaFiscal.TCD_LanFat_ComplementoDevolucao().SelectNFCompDev(
                        new TpBusca[]
                        {
                        new TpBusca()
                        {
                            vNM_Campo = "a.cd_empresa",
                            vOperador = "=",
                            vVL_Busca = "'" + (BS_Pedido.Current as TRegistro_Pedido).CD_Empresa.Trim() + "'"
                        },
                        new TpBusca()
                        {
                            vNM_Campo = "a.Nr_pedido",
                            vOperador = "=",
                            vVL_Busca = (BS_Pedido.Current as TRegistro_Pedido).Nr_pedido.ToString()
                        },
                        new TpBusca()
                        {
                            vNM_Campo = "a.TP_Movimento",
                            vOperador = "=",
                            vVL_Busca = "'S'"
                        },
                        new TpBusca()
                        {
                            vNM_Campo = "isnull(d.ST_Mestra, 'N')",
                            vOperador = "=",
                            vVL_Busca = "'S'"
                        }
                        }).Count.Equals(0))
                {
                    MessageBox.Show("Pedido da Ordem de Carregamento é de entrega futura!\r\n" +
                                    "Primeiro faturamento deve ser gerado a NF Mestra!\r\n" +
                                    "Em Faturamento NF Mestra, selecione a opção NF Entrega Futura.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            if (bsOrdemCarregamento.Current != null)
            {
                if ((BS_Pedido.Current as TRegistro_Pedido).ST_Pedido.Trim().ToUpper().Equals("P"))
                {
                    (BS_Pedido.Current as TRegistro_Pedido).ST_Pedido = "F";
                    (BS_Pedido.Current as TRegistro_Pedido).St_registro = "F";
                    TCN_Pedido.Grava_Pedido(BS_Pedido.Current as TRegistro_Pedido, null);
                }
                //Montar Itens do Pedido para Faturar
                TList_RegLanPedido_Item lItemPed = new TList_RegLanPedido_Item();
                new TCD_ItensExpedicao().Select(
                    new TpBusca[]
                    {
                            new TpBusca()
                            {
                                vNM_Campo = string.Empty,
                                vOperador = "exists",
                                vVL_Busca = "(select 1 from TB_FAT_Ordem_X_Expedicao x " +
                                            "where x.nr_lanctofiscal is null " +
                                            "and x.cd_empresa = a.cd_empresa " +
                                            "and x.id_expedicao = a.id_expedicao " +
                                            "and x.cd_empresa = '" + (bsOrdemCarregamento.Current as TRegistro_OrdemCarregamento).Cd_empresa.Trim() + "' " +
                                            "and x.id_ordem = " + (bsOrdemCarregamento.Current as TRegistro_OrdemCarregamento).Id_ordemstr + ")"
                            },
                            new TpBusca()
                            {
                                vNM_Campo = string.Empty,
                                vOperador = "exists",
                                vVL_Busca = "(select 1 from tb_fat_pedido_itens x " +
                                            "where x.nr_pedido = a.nr_pedido " +
                                            "and x.cd_produto = a.cd_produto " +
                                            "and x.id_pedidoitem = a.id_pedidoitem) "
                            }
                    }, 0, string.Empty).ForEach(p =>
                    {
                        TRegistro_LanPedido_Item rItem = TCN_LanPedido_Item.Busca(p.Cd_empresa,
                                                                                  string.Empty,
                                                                                  p.Cd_produto,
                                                                                  p.Nr_PedidoString,
                                                                                  p.Id_pedidoitemstr,
                                                                                  string.Empty,
                                                                                  string.Empty,
                                                                                  false,
                                                                                  null)[0];
                        rItem.Quantidade = p.Quantidade;
                        if (lItemPed.Exists(v => v.Nr_pedido.Equals(rItem.Nr_pedido) &&
                                                     v.Cd_produto.Equals(rItem.Cd_produto) &&
                                                     v.Id_pedidoitem.Equals(rItem.Id_pedidoitem)))
                        {
                                //Adicionar Quantidade de Item existente ao Pedido
                                lItemPed.Find(v => v.Nr_pedido.Equals(rItem.Nr_pedido) &&
                                                   v.Cd_produto.Equals(rItem.Cd_produto) &&
                                                   v.Id_pedidoitem.Equals(rItem.Id_pedidoitem)).Quantidade += p.Quantidade;
                                //Concatenar Nº Série a Obs Item
                                if (!string.IsNullOrEmpty(p.Nr_serie))
                            {
                                lItemPed.Find(v => v.Nr_pedido.Equals(rItem.Nr_pedido) &&
                                                       v.Cd_produto.Equals(rItem.Cd_produto) &&
                                                       v.Id_pedidoitem.Equals(rItem.Id_pedidoitem)).Ds_observacaoitem +=
                                        (string.IsNullOrEmpty(lItemPed.Find(v => v.Nr_pedido.Equals(rItem.Nr_pedido) &&
                                                                                 v.Cd_produto.Equals(rItem.Cd_produto) &&
                                                                                 v.Id_pedidoitem.Equals(rItem.Id_pedidoitem)).Ds_observacaoitem) ? " Nº Série:" : ", Nº Série:") + p.Nr_serie;
                            }
                        }
                        else
                        {
                                //Concatenar Nº Série a Obs Item
                                if (!string.IsNullOrEmpty(p.Nr_serie))
                                rItem.Ds_observacaoitem += (string.IsNullOrEmpty(rItem.Ds_observacaoitem) ? " Nº Série:" : ", Nº Série:") + p.Nr_serie;
                                //Adicionar Item da Ordem de Expedição ao Pedido
                                lItemPed.Add(rItem);
                        }
                    });
                if (lItemPed.Count.Equals(0))
                {
                    MessageBox.Show("Todos os itens já foram faturados!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                //Verificar se o pedido tem configuracao fiscal para emitir nota
                if (new CamadaDados.Faturamento.Cadastros.TCD_CadCFGPedidoFiscal().BuscarEscalar(
                        new TpBusca[]
                        {
                                new TpBusca()
                                {
                                    vNM_Campo = "a.cfg_pedido",
                                    vOperador = "=",
                                    vVL_Busca = "'" + (BS_Pedido.Current as TRegistro_Pedido).CFG_Pedido.Trim() + "'"
                                },
                                new TpBusca()
                                {
                                    vNM_Campo = "a.tp_fiscal",
                                    vOperador = "=",
                                    vVL_Busca = "'NO'"
                                }
                        }, "1") == null)
                {
                    MessageBox.Show("Não existe configuração fiscal para o tipo de pedido " + (BS_Pedido.Current as TRegistro_Pedido).CFG_Pedido.Trim() + ".",
                                    "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                try
                {
                    if (!string.IsNullOrEmpty((BS_Pedido.Current as TRegistro_Pedido).Cd_cliforent))
                    {
                        //Verificar se Pedido possui nota mestra para emitir as remessas de transporte
                        if (new CamadaDados.Faturamento.NotaFiscal.TCD_LanFaturamento().BuscarEscalar(
                                new TpBusca[]
                                {
                                    new TpBusca()
                                    {
                                        vNM_Campo = "a.nr_pedido",
                                        vOperador = "=",
                                        vVL_Busca = (BS_Pedido.Current as TRegistro_Pedido).Nr_pedido.ToString()
                                    },
                                    new TpBusca()
                                    {
                                        vNM_Campo = string.Empty,
                                        vOperador = "exists",
                                        vVL_Busca = "(select 1 from TB_FAT_CFG_PedFiscal x " +
                                                    "where x.CFG_Pedido = g.CFG_Pedido " +
                                                    "and x.TP_Fiscal = 'NO') "
                                    }
                                }, "1") == null)
                        {
                            MessageBox.Show("Obrigatório gerar NF Mestra para emitir remessa de transporte!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        using (TFTrocaClienteEnt fEnt = new TFTrocaClienteEnt())
                        {
                            fEnt.pCd_cliforEnt = (BS_Pedido.Current as TRegistro_Pedido).Cd_cliforent;
                            fEnt.pNm_cliforEnt = (BS_Pedido.Current as TRegistro_Pedido).Nm_cliforent;
                            fEnt.pCd_enderecoent = (BS_Pedido.Current as TRegistro_Pedido).Cd_enderecoent;
                            fEnt.pLogradouroent = (BS_Pedido.Current as TRegistro_Pedido).Logradouroent;
                            fEnt.pNumeroent = (BS_Pedido.Current as TRegistro_Pedido).Numeroent;
                            fEnt.pComplementoent = (BS_Pedido.Current as TRegistro_Pedido).Complementoent;
                            fEnt.pBairroent = (BS_Pedido.Current as TRegistro_Pedido).Bairroent;
                            fEnt.pCondFiscalent = (BS_Pedido.Current as TRegistro_Pedido).Cd_condfiscalent;
                            fEnt.pTp_pessoaent = (BS_Pedido.Current as TRegistro_Pedido).Tp_pessoaent;
                            fEnt.pCd_cidadeent = (BS_Pedido.Current as TRegistro_Pedido).Cd_cidadeent;
                            fEnt.pDs_cidadeent = (BS_Pedido.Current as TRegistro_Pedido).Ds_cidadeent;
                            fEnt.pUf_ent = (BS_Pedido.Current as TRegistro_Pedido).Uf_ent;
                            fEnt.pCd_ufent = (BS_Pedido.Current as TRegistro_Pedido).Cd_uf_ent;
                            if (fEnt.ShowDialog() == DialogResult.OK)
                            {
                                (BS_Pedido.Current as TRegistro_Pedido).Cd_cliforent = fEnt.pCd_cliforEnt;
                                (BS_Pedido.Current as TRegistro_Pedido).Nm_cliforent = fEnt.pNm_cliforEnt;
                                (BS_Pedido.Current as TRegistro_Pedido).Cd_enderecoent = fEnt.pCd_enderecoent;
                                (BS_Pedido.Current as TRegistro_Pedido).Logradouroent = fEnt.pLogradouroent;
                                (BS_Pedido.Current as TRegistro_Pedido).Numeroent = fEnt.pNumeroent;
                                (BS_Pedido.Current as TRegistro_Pedido).Complementoent = fEnt.pComplementoent;
                                (BS_Pedido.Current as TRegistro_Pedido).Bairroent = fEnt.pBairroent;
                                (BS_Pedido.Current as TRegistro_Pedido).Cd_condfiscalent = fEnt.pCondFiscalent;
                                (BS_Pedido.Current as TRegistro_Pedido).Tp_pessoaent = fEnt.pTp_pessoaent;
                                (BS_Pedido.Current as TRegistro_Pedido).Cd_cidadeent = fEnt.pCd_cidadeent;
                                (BS_Pedido.Current as TRegistro_Pedido).Ds_cidadeent = fEnt.pDs_cidadeent;
                                (BS_Pedido.Current as TRegistro_Pedido).Uf_ent = fEnt.pUf_ent;
                                (BS_Pedido.Current as TRegistro_Pedido).Cd_uf_ent = fEnt.pCd_ufent;
                            }
                            else
                            {
                                MessageBox.Show("Obrigatório informar Cliente entrega para gerar a nota fiscal!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                        }
                    }
                    //Buscar itens Ordem
                    TList_Ordem_X_Expedicao lOrdem =
                        TCN_Ordem_X_Expedicao.Busca((bsOrdemCarregamento.Current as TRegistro_OrdemCarregamento).Cd_empresa,
                                                                                     (bsOrdemCarregamento.Current as TRegistro_OrdemCarregamento).Id_ordemstr,
                                                                                     string.Empty,
                                                                                     null);
                    (BS_Pedido.Current as TRegistro_Pedido).Pedido_Itens.Clear();
                    lItemPed.ForEach(p => (BS_Pedido.Current as TRegistro_Pedido).Pedido_Itens.Add(p));
                    //Adicionar quantidade nf e peso
                    (BS_Pedido.Current as TRegistro_Pedido).QUANTIDADENF = (bsOrdemCarregamento.Current as TRegistro_OrdemCarregamento).lExp.Count();
                    (BS_Pedido.Current as TRegistro_Pedido).PesoLiquido = (bsOrdemCarregamento.Current as TRegistro_OrdemCarregamento).lExp.Sum(p => p.Peso);
                    CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento rFat =
                        Proc_Commoditties.TProcessaPedFaturar.ProcessaPedFaturar(BS_Pedido.Current as TRegistro_Pedido, false, decimal.Zero);
                    //Limpar lista de 
                    if (lOrdem.Count > 0)
                        lOrdem.ForEach(p => rFat.lOrdem.Add(p));
                    TList_ItensExpedicao lItensExpedicao =
                        new TCD_ItensExpedicao().Select(
                            new TpBusca[]
                            {
                                    new TpBusca()
                                    {
                                        vNM_Campo = "a.nr_pedido",
                                        vOperador = "=",
                                        vVL_Busca = (BS_Pedido.Current as TRegistro_Pedido).Nr_pedido.ToString()
                                    },
                                    new TpBusca()
                                    {
                                        vNM_Campo = "a.ID_PedidoItem",
                                        vOperador = "is",
                                        vVL_Busca = "null"
                                    },
                                    new TpBusca()
                                    {
                                        vNM_Campo = string.Empty,
                                        vOperador = "exists",
                                        vVL_Busca = "(select 1 from TB_FAT_Ordem_X_Expedicao x " +
                                                    "where a.cd_empresa = x.cd_empresa " +
                                                    "and a.id_expedicao = x.id_expedicao " +
                                                    "and x.nr_lanctofiscal is null " +
                                                    "and x.cd_empresa = '" + (bsOrdemCarregamento.Current as TRegistro_OrdemCarregamento).Cd_empresa.Trim() + "' " +
                                                    "and x.id_ordem = " + (bsOrdemCarregamento.Current as TRegistro_OrdemCarregamento).Id_ordemstr + ")"
                                    }
                            }, 0, string.Empty);
                    lItensExpedicao.ForEach(p =>
                    {
                        rFat.lNfAcessorios_X_Estoque.Add(new TRegistro_NFAcessorios_X_Estoque()
                        {
                            Cd_empresa = p.Cd_empresa,
                            Cd_produto = p.Cd_produto,
                            Cd_local = p.Cd_local,
                            Quantidade = p.Quantidade
                        });
                    });
                    TCN_LanFaturamento.GravarFaturamento(rFat, null, null);
                    //Se for nota propria e NF-e
                    if (rFat.Tp_nota.Trim().ToUpper().Equals("P") && rFat.Cd_modelo.Trim().Equals("55"))
                        if (MessageBox.Show("Deseja enviar NF-e para a receita agora?", "Pergunta", MessageBoxButtons.YesNo,
                             MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                        {
                            //Verificar se é nota de produto ou mista
                            object obj = new CamadaDados.Faturamento.Cadastros.TCD_CadSerieNF().BuscarEscalar(
                                            new TpBusca[]
                                            {
                                                    new TpBusca()
                                                    {
                                                        vNM_Campo = "a.nr_serie",
                                                        vOperador = "=",
                                                        vVL_Busca = "'" + rFat.Nr_serie + "'"
                                                    }
                                            }, "a.tp_serie");
                            if (obj != null)
                                if (obj.ToString().Trim().ToUpper().Equals("P") ||
                                    obj.ToString().Trim().ToUpper().Equals("M"))
                                {
                                    try
                                    {
                                        using (srvNFE.TFGerenciarNFe fGerNfe = new srvNFE.TFGerenciarNFe())
                                        {
                                            fGerNfe.rNfe = TCN_LanFaturamento.BuscarNF(rFat.Cd_empresa,
                                                                                       rFat.Nr_lanctofiscalstr,
                                                                                       null);
                                            fGerNfe.ShowDialog();
                                        }
                                    }
                                    catch (Exception ex)
                                    { MessageBox.Show("Erro enviar NF-e: " + ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                                }
                                else if (obj.ToString().Trim().ToUpper().Equals("S"))
                                {
                                    try
                                    {
                                        CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento rNfs =
                                            TCN_LanFaturamento.BuscarNF(rFat.Cd_empresa,
                                                                        rFat.Nr_lanctofiscalstr,
                                                                        null);
                                        NFES.TGerarRPS.CriarArquivoRPS(rNfs.rCfgNfe, new List<CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento>() { rNfs });
                                        MessageBox.Show("NFS-e enviada com sucesso. Aguarde alguns segundos e consulte o status do lote.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                    catch (Exception ex)
                                    { MessageBox.Show("Erro enviar NFS-e: " + ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                                }
                        }
                    //Encerrar Pedido
                    if ((BS_Pedido.Current as TRegistro_Pedido).Vl_saldopedido < decimal.Zero)
                    {
                        System.Collections.Hashtable hs = new System.Collections.Hashtable();
                        hs.Add("@ST_PEDIDO", "P");
                        hs.Add("@ST_REGISTRO", "P");
                        hs.Add("@NR_PEDIDO", (BS_Pedido.Current as TRegistro_Pedido).Nr_pedido);
                        new CamadaDados.TDataQuery().executarSql("update TB_FAT_Pedido set ST_PEDIDO = @ST_PEDIDO, ST_REGISTRO = @ST_REGISTRO" +
                                                                 "where NR_PEDIDO = @NR_PEDIDO ", hs);
                    }
                    afterBusca();
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
            else
                MessageBox.Show("Ordem de carregamento não possui itens a serem faturados!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void faturarPedidoOrdem(string Tp_nf)
        {
            if (BS_Pedido.Current != null)
            {
                if (Tp_nf.ToUpper().Equals("'NO'") ||
                    Tp_nf.ToUpper().Equals("'FT'"))
                    if (!bloqueioCredito())
                    {
                        MessageBox.Show("Cliente possui restrição de crédito.\r\n" +
                                       "Financeiro não poderá ser gravado.", "Mensagem", MessageBoxButtons.OK,
                                        MessageBoxIcon.Information);
                        return;
                    }
                //Se o pedido for normal gerar NF Mestra de transporte alterando o CFG.Pedido para Venda referente
                if (Tp_nf.ToUpper().Equals("'NO'"))
                {
                    if (TCN_Pedido.Verifica_Disponibilidade_Pedido((BS_Pedido.Current as CamadaDados.Faturamento.Pedido.TRegistro_Pedido).Nr_pedido.ToString()))
                    {
                        MessageBox.Show("Pedido já possui faturamento!\r\n" +
                                        "Não é possível gerar NF Mestra p/ remessa de transporte!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    object objCFG =
                        new CamadaDados.Faturamento.Cadastros.TCD_CadCFGPedidoFiscal().BuscarEscalar(
                            new TpBusca[]
                            {
                                new TpBusca()
                                {
                                    vNM_Campo = "a.TP_Fiscal",
                                    vOperador = "=",
                                    vVL_Busca = "'RT'"
                                }
                            }, "a.CFG_Pedido");
                    if (objCFG == null ? false : !string.IsNullOrEmpty(objCFG.ToString()))
                    {
                        new CamadaDados.TDataQuery().executarSql("update TB_FAT_Pedido set CFG_Pedido = '" + objCFG.ToString().Trim() + "'" +
                                                                 "where Nr_pedido = " + (BS_Pedido.Current as TRegistro_Pedido).Nr_pedido.ToString(), null);
                    }
                    else
                    {
                        MessageBox.Show("Não existe CFG.Pedido para remessa para transporte!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                }
                if (Tp_nf.ToUpper().Equals("'FT'"))
                {
                    if (TCN_Pedido.Verifica_Disponibilidade_Pedido((BS_Pedido.Current as CamadaDados.Faturamento.Pedido.TRegistro_Pedido).Nr_pedido.ToString()))
                    {
                        MessageBox.Show("Pedido já possui faturamento!\r\n" +
                                        "Não é possível gerar NF Mestra p/ entrega futura!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    object objCFG =
                        new CamadaDados.Faturamento.Cadastros.TCD_CadCFGPedidoFiscal().BuscarEscalar(
                            new TpBusca[]
                            {
                                new TpBusca()
                                {
                                    vNM_Campo = "a.TP_Fiscal",
                                    vOperador = "=",
                                    vVL_Busca = "'FT'"
                                }
                            }, "a.CFG_Pedido");
                    if (objCFG == null ? false : !string.IsNullOrEmpty(objCFG.ToString()))
                    {
                        new CamadaDados.TDataQuery().executarSql("update TB_FAT_Pedido set CFG_Pedido = '" + objCFG.ToString().Trim() + "'" +
                                                                 "where Nr_pedido = " + (BS_Pedido.Current as TRegistro_Pedido).Nr_pedido.ToString(), null);
                        (BS_Pedido.Current as TRegistro_Pedido).CFG_Pedido = objCFG.ToString();
                    }
                    else
                    {
                        MessageBox.Show("Não existe CFG.Pedido para entrega futura!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                }
                if ((BS_Pedido.Current as TRegistro_Pedido).ST_Pedido.Trim().ToUpper().Equals("P"))
                {
                    (BS_Pedido.Current as TRegistro_Pedido).ST_Pedido = "F";
                    (BS_Pedido.Current as TRegistro_Pedido).St_registro = "F";
                    TRegistro_Pedido rPed = (BS_Pedido.Current as TRegistro_Pedido);
                    TCN_Pedido.Grava_Pedido(rPed, null);
                }
                if ((BS_Pedido.Current as TRegistro_Pedido).ST_Pedido.Trim().ToUpper().Equals("F"))
                {
                    //Verificar se o pedido tem configuracao fiscal para emitir nota
                   object obj = new TCD_CadCFGPedidoFiscal().BuscarEscalar(
                            new TpBusca[]
                            {
                                new TpBusca()
                                {
                                    vNM_Campo = "a.cfg_pedido",
                                    vOperador = "=",
                                    vVL_Busca = "'" + (BS_Pedido.Current as TRegistro_Pedido).CFG_Pedido.Trim() + "'"
                                },
                                new TpBusca()
                                {
                                    vNM_Campo = "a.tp_fiscal",
                                    vOperador = "in",
                                    vVL_Busca = "(" + Tp_nf + ")"
                                }
                            }, "1");
                    if (obj == null ? true : obj.ToString().Trim() != "1")
                    {
                        MessageBox.Show("Não existe configuração fiscal para o tipo de pedido " + (BS_Pedido.Current as TRegistro_Pedido).CFG_Pedido.Trim() + ".",
                                        "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    //Verificar se o pedido tem valor fixo e se nao aceita faturar parcial
                    if (TCN_Pedido.FaturarPedidoDireto((BS_Pedido.Current as TRegistro_Pedido).Nr_pedido.ToString()))
                    {
                        try
                        {
                            TRegistro_LanFaturamento rFat =
                                Proc_Commoditties.TProcessaPedFaturar.ProcessaPedFaturar(BS_Pedido.Current as TRegistro_Pedido, false, decimal.Zero);
                            TCN_LanFaturamento.GravarFaturamento(rFat, null, null);
                            if (MessageBox.Show("Pedido Faturado com Sucesso.\r\nDeseja imprimir as notas fiscais?\r\n" +
                                    "Obs.: Somente serão impressas as notas fiscais proprias e que não sejam NF-e.", "Pergunta",
                                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                                    == DialogResult.Yes)
                            {
                                rFat = TCN_LanFaturamento.Busca(rFat.Cd_empresa,
                                                                rFat.Nr_notafiscalstr,
                                                                rFat.Nr_serie,
                                                                rFat.Nr_lanctofiscalstr,
                                                                string.Empty,
                                                                string.Empty,
                                                                decimal.Zero,
                                                                string.Empty,
                                                                string.Empty,
                                                                string.Empty,
                                                                string.Empty,
                                                                string.Empty,
                                                                string.Empty,
                                                                string.Empty,
                                                                string.Empty,
                                                                false,
                                                                string.Empty,
                                                                string.Empty,
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
                                                                false,
                                                                string.Empty,
                                                                string.Empty,
                                                                string.Empty,
                                                                1,
                                                                string.Empty,
                                                                null)[0];
                                if (rFat.Tp_nota.Trim().ToUpper().Equals("P") && (!rFat.Cd_modelo.Trim().Equals("55")))
                                    //Chamar tela de impressao para a nota fiscal
                                    //somente se for nota propria
                                    using (TFGerenciadorImpressao fImp = new TFGerenciadorImpressao())
                                    {
                                        fImp.St_enabled_enviaremail = true;
                                        fImp.pCd_clifor = rFat.Cd_clifor;
                                        fImp.pMensagem = "NOTA FISCAL Nº" + rFat.Nr_notafiscal.ToString();
                                        if ((fImp.ShowDialog() == DialogResult.OK) || (fImp.pSt_enviaremail))
                                            new LayoutNotaFiscal().Imprime_NF(rFat,
                                                                                            fImp.pSt_imprimir,
                                                                                            fImp.pSt_visualizar,
                                                                                            fImp.pSt_enviaremail,
                                                                                            fImp.pDestinatarios,
                                                                                            "NOTA FISCAL Nº " + rFat.Nr_notafiscal.ToString(),
                                                                                            fImp.pDs_mensagem);
                                    }
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        using (TFLanFaturamento fFaturamento = new TFLanFaturamento())
                        {
                            if (Tp_nf.ToUpper().Equals("'NO'") ||
                            Tp_nf.ToUpper().Equals("'CP', 'CF'") ||
                            Tp_nf.ToUpper().Equals("'FT'"))
                                fFaturamento.vTp_movimento = (BS_Pedido.Current as TRegistro_Pedido).TP_Movimento;
                            else if ((BS_Pedido.Current as TRegistro_Pedido).TP_Movimento.Trim().ToUpper().Equals("E"))
                                fFaturamento.vTp_movimento = "S";
                            else
                                fFaturamento.vTp_movimento = "E";
                            fFaturamento.Nr_pedidoFaturar = (BS_Pedido.Current as TRegistro_Pedido).Nr_pedido.ToString();
                            fFaturamento.vTp_NFFiscal = Tp_nf;
                            fFaturamento.ShowDialog();
                        }
                    }
                }
            }
        }

        private bool bloqueioCredito()
        {
            if ((!string.IsNullOrEmpty((BS_Pedido.Current as CamadaDados.Faturamento.Pedido.TRegistro_Pedido).CD_Clifor)))
            {
                CamadaDados.Financeiro.Duplicata.TRegistro_DadosBloqueio rDados = new CamadaDados.Financeiro.Duplicata.TRegistro_DadosBloqueio();
                if (CamadaNegocio.Financeiro.Duplicata.TCN_DadosBloqueio.VerificarBloqueioCredito((BS_Pedido.Current as CamadaDados.Faturamento.Pedido.TRegistro_Pedido).CD_Clifor,
                                                               decimal.Zero,
                                                               true,
                                                               ref rDados,
                                                               null))
                    using (Financeiro.TFLan_BloqueioCredito fBloq = new Financeiro.TFLan_BloqueioCredito())
                    {
                        fBloq.rDados = rDados;
                        fBloq.Vl_fatura = decimal.Zero;
                        fBloq.ShowDialog();
                        return fBloq.St_desbloqueado;
                    }
                else
                    return true;
            }
            else
                return true;
        }

        private void afterPrint()
        {
            if (bsOrdemCarregamento.Current != null)
            {
                BindingSource BinClifor = new BindingSource();
                BinClifor.DataSource = TCN_CadClifor.Busca_Clifor((BS_Pedido.Current as TRegistro_Pedido).CD_Clifor,
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
                                                                  string.Empty,
                                                                  string.Empty,
                                                                  string.Empty,
                                                                  string.Empty,
                                                                  string.Empty,
                                                                  string.Empty,
                                                                  1,
                                                                  null);

                BindingSource BinEndereco = new BindingSource();
                BinEndereco.DataSource = TCN_CadEndereco.Buscar((BS_Pedido.Current as TRegistro_Pedido).CD_Clifor,
                                                                (BS_Pedido.Current as TRegistro_Pedido).CD_Endereco,
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
                



                FormRelPadrao.Relatorio Relatorio = new FormRelPadrao.Relatorio();
                Relatorio.Altera_Relatorio = Altera_Relatorio;

                //DADOS PERTINENTES PARA A GERAÇÂO DO RELATORIO
                Relatorio.Nome_Relatorio = "FLan_OrdemCarregamento";
                Relatorio.NM_Classe = "TFLan_Pedido";
                Relatorio.Modulo = Tag.ToString().Substring(0, 3);

                Relatorio.Adiciona_DataSource("CLIFOR", BinClifor);
                Relatorio.Adiciona_DataSource("ENDERECO_CLIFOR", BinEndereco); 
                //Buscar Itens Expedição
                (bsOrdemCarregamento.Current as TRegistro_OrdemCarregamento).lExp.ForEach(p =>
                    p.lItens = TCN_ItensExpedicao.Busca(p.Cd_empresa,
                                                                                         p.Id_expedicaostr,
                                                                                         string.Empty,
                                                                                         null));
                (bsOrdemCarregamento.Current as TRegistro_OrdemCarregamento).dt_embarque =
                   (BS_Pedido.Current as TRegistro_Pedido).Dt_entregapedido;
                BindingSource bs = new BindingSource();
                bs.DataSource = new TList_OrdemCarregamento() { bsOrdemCarregamento.Current as TRegistro_OrdemCarregamento };
                Relatorio.DTS_Relatorio = bs;

                Relatorio.Ident = "FLan_OrdemCarregamento";
                if (!Altera_Relatorio)
                {
                    //Chamar tela de gerenciamento de impressao
                    using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
                    {
                        fImp.St_enabled_enviaremail = true;
                        fImp.pCd_clifor = (BS_Pedido.Current as TRegistro_Pedido).CD_Clifor;
                        fImp.pMensagem = "ORDEM DE CARREGAMENTO";
                        if ((fImp.ShowDialog() == DialogResult.OK) || (fImp.pSt_enviaremail))
                            Relatorio.Gera_Relatorio(string.Empty,
                                                     fImp.pSt_imprimir,
                                                     fImp.pSt_visualizar,
                                                     fImp.pSt_enviaremail,
                                                     fImp.pSt_exportPdf,
                                                     fImp.Path_exportPdf,
                                                     fImp.pDestinatarios,
                                                     null,
                                                     "ORDEM DE CARREGAMENTO",
                                                     fImp.pDs_mensagem);
                    }
                }
                else
                {
                    Relatorio.Gera_Relatorio();
                    Altera_Relatorio = false;
                }
            }
        }

        private void Imprime_Danfe()
        {
            FormRelPadrao.Relatorio Danfe = new FormRelPadrao.Relatorio();
            Danfe.Altera_Relatorio = Altera_Relatorio;
            //Buscar NFe
            TRegistro_LanFaturamento rNfe = TCN_LanFaturamento.BuscarNF((bs_NotaFiscal.Current as TRegistro_LanFaturamento).Cd_empresa,
                                                                        (bs_NotaFiscal.Current as TRegistro_LanFaturamento).Nr_lanctofiscalstr,
                                                                        null);
            //Buscar Itens NFe
            rNfe.ItensNota = TCN_LanFaturamento_Item.Busca(rNfe.Cd_empresa,
                                                           rNfe.Nr_lanctofiscalstr,
                                                           string.Empty,
                                                           null);
            Danfe.Parametros_Relatorio.Add("VL_IPI", rNfe.ItensNota.Sum(v=> v.Vl_ipi));
            Danfe.Parametros_Relatorio.Add("VL_ICMS", rNfe.ItensNota.Sum(v=> v.Vl_icms + v.Vl_FCP));
            Danfe.Parametros_Relatorio.Add("VL_BASEICMS", rNfe.ItensNota.Sum(v=> v.Vl_basecalcICMS));
            Danfe.Parametros_Relatorio.Add("VL_BASEICMSSUBST", rNfe.ItensNota.Sum(v=> v.Vl_basecalcSTICMS));
            Danfe.Parametros_Relatorio.Add("VL_ICMSSUBST", rNfe.ItensNota.Sum(v=> v.Vl_ICMSST + v.Vl_FCPST));

            BindingSource Bin = new BindingSource();
            Bin.DataSource = new TList_RegLanFaturamento() { rNfe };
            Danfe.Nome_Relatorio = "TFLanFaturamento_Danfe";
            Danfe.NM_Classe = "TFLanConsultaNFe";
            Danfe.Modulo = "FAT";
            Danfe.Ident = "TFLanFaturamento_Danfe";
            Danfe.DTS_Relatorio = Bin;
            //Buscar financeiro da DANFE
            TList_RegLanParcela lParc =
                new TCD_LanParcela().Select(
                                new TpBusca[]
                                    {
                                        new TpBusca()
                                        {
                                            vNM_Campo = "isnull(a.st_registro, 'A')",
                                            vOperador = "<>",
                                            vVL_Busca = "'L'"
                                        },
                                        new TpBusca()
                                        {
                                            vNM_Campo = string.Empty,
                                            vOperador = "exists",
                                            vVL_Busca = "(select 1 from tb_fin_duplicata x " +
                                                        "inner join tb_fat_notafiscal_x_duplicata y " +
                                                        "on x.cd_empresa = y.cd_empresa " +
                                                        "and x.nr_lancto = y.nr_lanctoduplicata " +
                                                        "where isnull(x.st_registro, 'A') <> 'C' " +
                                                        "and x.cd_empresa = a.cd_empresa " +
                                                        "and x.nr_lancto = a.nr_lancto " +
                                                        "and y.cd_empresa = '" + (bs_NotaFiscal.Current as TRegistro_LanFaturamento).Cd_empresa.Trim() + "' " +
                                                        "and y.nr_lanctofiscal = " + (bs_NotaFiscal.Current as TRegistro_LanFaturamento).Nr_lanctofiscal + ")"
                                        }
                                    }, 0, string.Empty, "a.dt_vencto, c.nm_clifor", string.Empty);
            if (lParc.Count == 0)
                if(new TCD_LanFaturamento_CMI().BuscarEscalar(
                    new TpBusca[]
                    {
                        new TpBusca{ vNM_Campo = "a.cd_empresa", vOperador = "=", vVL_Busca = "'" + rNfe.Cd_empresa.Trim() + "'" },
                        new TpBusca{ vNM_Campo = "a.nr_lanctofiscal", vOperador = "=", vVL_Busca = rNfe.Nr_lanctofiscalstr },
                        new TpBusca{ vNM_Campo = "isnull(a.st_devolucao, 'N')", vOperador = "<>", vVL_Busca = "'S'" },
                        new TpBusca{ vNM_Campo = "isnull(a.st_complementar, 'N')", vOperador = "<>", vVL_Busca = "'S'" },
                        new TpBusca{ vNM_Campo = "isnull(a.st_simplesremessa, 'N')", vOperador = "<>", vVL_Busca = "'S'" },
                        new TpBusca{ vNM_Campo = "isnull(a.st_compdevimposto, 'N')", vOperador = "<>", vVL_Busca = "'S'" },
                        new TpBusca{ vNM_Campo = "isnull(a.st_remessatransp, 'N')", vOperador = "<>", vVL_Busca = "'S'" },
                        new TpBusca{ vNM_Campo = "isnull(a.st_retorno, 'N')", vOperador = "<>", vVL_Busca = "'S'" }

                    }, "1") != null)
                    //Verificar se pedido de origem gerou financeiro
                    lParc = new TCD_LanParcela().Select(
                        new TpBusca[]
                        {
                            new TpBusca{ vNM_Campo = "isnull(a.st_registro, 'A')", vOperador = "<>", vVL_Busca = "'L'" },
                            new TpBusca
                            {
                                vNM_Campo = string.Empty,
                                vOperador = "exists",
                                vVL_Busca = "(select 1 from tb_fat_pedido_x_duplicata x " +
                                            "where x.cd_empresa = a.cd_empresa " +
                                            "and x.nr_lancto = a.nr_lancto " +
                                            "and x.nr_pedido = " + rNfe.Nr_pedidostring + ")"
                            }
                        }, 0, string.Empty, "a.dt_vencto, c.nm_clifor", string.Empty);
            if (lParc.Count > 0)
            {
                for (int i = 0; i < lParc.Count; i++)
                {
                    if (i < 12)
                    {
                        Danfe.Parametros_Relatorio.Add("DT_VENCTO" + i.ToString(), lParc[i].Dt_venctostring);
                        Danfe.Parametros_Relatorio.Add("VL_DUP" + i.ToString(), lParc[i].Vl_parcela_padrao);
                    }
                    else
                        break;
                }
            }
            //Verificar se existe logo configurada para a empresa
            object log = new TCD_CadEmpresa().BuscarEscalar(
                            new TpBusca[]
                            {
                                new TpBusca()
                                {
                                    vNM_Campo = "a.cd_empresa",
                                    vOperador = "=",
                                    vVL_Busca = "'" + (bs_NotaFiscal.Current as TRegistro_LanFaturamento).Cd_empresa.Trim() + "'"
                                }
                            }, "a.logoEmpresa");
            if (log != null)
                Danfe.Parametros_Relatorio.Add("IMAGEM_RELATORIO", log);
            Danfe.Gera_Relatorio();
        }

        private void Imprime_NotaFiscal(TRegistro_LanFaturamento rNf,
                                      bool St_imprimir,
                                      bool St_visualizar,
                                      bool St_enviaremail,
                                      List<string> Destinatarios,
                                      string Titulo,
                                      string Mensagem)
        {
            LayoutNotaFiscal Relatorio = new LayoutNotaFiscal();
            Relatorio.Imprime_NF(rNf,
                                St_imprimir,
                                St_visualizar,
                                St_enviaremail,
                                Destinatarios,
                                Titulo,
                                Mensagem);
        }

        private void TFLanOrdemCarregamento_Load(object sender, EventArgs e)
        {
            Icon = ResourcesUtils.TecnoAliance_ICO;
            pConsulta.set_FormatZero();
        }

        private void BB_Novo_Click(object sender, EventArgs e)
        {
            afterNovo();
        }

        private void BB_Excluir_Click(object sender, EventArgs e)
        {
            afterExclui();
        }

        private void BB_Buscar_Click(object sender, EventArgs e)
        {
            afterBusca();
        }

        private void BB_Fechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void TFLanOrdemCarregamento_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F7))
                afterBusca();
            else if (e.KeyCode.Equals(Keys.F8))
                afterPrint();
            else if (e.KeyCode.Equals(Keys.F9))
                faturarPedido();
            else if ((e.Control) && (e.KeyCode == Keys.P))
            {
                Altera_Relatorio = true;
                MessageBox.Show("Execute o relatório que deseja alterar!", "Mensagem");
            }
        }

        private void CD_Empresa_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("a.cd_empresa|=|'" + CD_Empresa.Text + "';" +
                                  "|EXISTS|(select 1 from Tb_div_usuario_X_empresa  x where x.cd_empresa = A.cd_empresa " +
                                  "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                                  "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                  "         where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))"
              , new Componentes.EditDefault[] { CD_Empresa }, new TCD_CadEmpresa());
        }

        private void bb_Empresa_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BUSCA("a.NM_empresa|Nome Empresa|300;a.CD_Empresa|Cód Empresa|100"
                          , new Componentes.EditDefault[] { CD_Empresa }
                          , new TCD_CadEmpresa(),
                          "|EXISTS|(select 1 from Tb_div_usuario_X_empresa  x where x.cd_empresa = A.cd_empresa " +
                          "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                          "(exists(select 1 from tb_div_usuario_x_grupos y " +
                          "         where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))");
        }

        private void CD_Clifor_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("a.cd_clifor|=|'" + CD_Clifor.Text + "';isnull(a.st_registro, 'A')|<>|'C'"
               , new Componentes.EditDefault[] { CD_Clifor }, new TCD_CadClifor());
        }

        private void btn_Clifor_Busca_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { CD_Clifor }, "isnull(a.st_registro, 'A')|<>|'C'");
        }

        private void bsOrdemCarregamento_PositionChanged(object sender, EventArgs e)
        {
            if (bsOrdemCarregamento.Current != null)
            {
                //Buscar expedições
                (bsOrdemCarregamento.Current as TRegistro_OrdemCarregamento).lExp =
                    new TCD_Expedicao().Select(
                        new TpBusca[]
                        {
                            new TpBusca()
                            {
                                vNM_Campo = string.Empty,
                                vOperador = "exists",
                                vVL_Busca = "(select 1 from TB_FAT_Ordem_X_Expedicao x " +
                                            "where a.cd_empresa = x.cd_empresa " +
                                            "and a.id_expedicao = x.id_expedicao " +
                                            "and x.cd_empresa = '" + (bsOrdemCarregamento.Current as TRegistro_OrdemCarregamento).Cd_empresa.Trim() + "'" +
                                            "and x.id_ordem = " + (bsOrdemCarregamento.Current as TRegistro_OrdemCarregamento).Id_ordemstr + ") "
                            }
                        }, 0, string.Empty);
                //Buscar Ordem X Expedição
                (bsOrdemCarregamento.Current as TRegistro_OrdemCarregamento).lItens =
                    TCN_Ordem_X_Expedicao.Busca((bsOrdemCarregamento.Current as TRegistro_OrdemCarregamento).Cd_empresa,
                                                                                  (bsOrdemCarregamento.Current as TRegistro_OrdemCarregamento).Id_ordemstr,
                                                                                  string.Empty,
                                                                                  null);
                //Buscar Itens Expedicao
                (bsOrdemCarregamento.Current as TRegistro_OrdemCarregamento).lExp.ForEach(p =>
                    {
                        p.lItens = TCN_ItensExpedicao.Busca(p.Cd_empresa,
                                                                              p.Id_expedicaostr,
                                                                              string.Empty,
                                                                              null);
                    });

                bsOrdemCarregamento.ResetCurrentItem();
            }
        }

        private void bb_imprimirNota_Click(object sender, EventArgs e)
        {
            if (bs_NotaFiscal.Current != null)
                if ((bs_NotaFiscal.Current as TRegistro_LanFaturamento).Cd_modelo.Trim().Equals("55"))
                {
                    //Verificar o status de retorno da NF-e
                    object obj = new CamadaDados.Faturamento.NFE.TCD_LanLoteNFE_X_NotaFiscal().BuscarEscalar(
                                    new TpBusca[]
                                    {
                                        new TpBusca()
                                        {
                                            vNM_Campo = "a.cd_empresa",
                                            vOperador = "=",
                                            vVL_Busca = "'" + (bs_NotaFiscal.Current as TRegistro_LanFaturamento).Cd_empresa.Trim() + "'"
                                        },
                                        new TpBusca()
                                        {
                                            vNM_Campo = "a.nr_lanctofiscal",
                                            vOperador = "=",
                                            vVL_Busca = (bs_NotaFiscal.Current as TRegistro_LanFaturamento).Nr_lanctofiscal.ToString()
                                        },
                                        new TpBusca()
                                        {
                                            vNM_Campo = "a.Status",
                                            vOperador = "=",
                                            vVL_Busca = "'100'"
                                        }
                                    }, "1");
                    if (obj != null)
                    {
                        using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
                        {
                            fImp.St_enabled_enviaremail = true;
                            fImp.pCd_clifor = (bs_NotaFiscal.Current as TRegistro_LanFaturamento).Cd_clifor;
                            fImp.pMensagem = "NF-e Nº " + (bs_NotaFiscal.Current as TRegistro_LanFaturamento).Nr_notafiscal.ToString();
                            if ((fImp.ShowDialog() == DialogResult.OK) || (fImp.pSt_enviaremail))
                                Imprime_Danfe();
                        }
                    }
                    else
                        MessageBox.Show("Permitido imprimir DANFE somente de NF-e aceita pela receita.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if ((bs_NotaFiscal.Current as TRegistro_LanFaturamento).St_registro.Trim().ToUpper().Equals("C"))
                    {
                        MessageBox.Show("Não é permitido imprimir nota fiscal cancelada.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    if ((bs_NotaFiscal.Current as TRegistro_LanFaturamento).Tp_nota.Trim().ToUpper().Equals("T"))
                    {
                        MessageBox.Show("Não é permitido imprimir nota fiscal de terceiro.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
                    {
                        fImp.St_enabled_enviaremail = true;
                        fImp.pCd_clifor = (bs_NotaFiscal.Current as TRegistro_LanFaturamento).Cd_clifor;
                        fImp.pMensagem = "NOTA FISCAL Nº " + (bs_NotaFiscal.Current as TRegistro_LanFaturamento).Nr_notafiscal.ToString();
                        if ((fImp.ShowDialog() == DialogResult.OK) || (fImp.pSt_enviaremail))
                            Imprime_NotaFiscal(TCN_LanFaturamento.BuscarNF((bs_NotaFiscal.Current as TRegistro_LanFaturamento).Cd_empresa,
                                                                           (bs_NotaFiscal.Current as TRegistro_LanFaturamento).Nr_lanctofiscalstr,
                                                                           null),
                                               fImp.pSt_imprimir,
                                               fImp.pSt_visualizar,
                                               fImp.pSt_enviaremail,
                                               fImp.pDestinatarios,
                                               "NOTA FISCAL Nº " + (bs_NotaFiscal.Current as TRegistro_LanFaturamento).Nr_notafiscal.ToString(),
                                               fImp.pDs_mensagem);
                    }
                }
        }

        private void bb_visualizar_Click(object sender, EventArgs e)
        {
            if (bsAnexo.Current as TRegistro_AnexoPedido != null)
            {
                string ae;
                byte[] arquivoBuffer = (bsAnexo.Current as TRegistro_AnexoPedido).Anexo;
                string extensao = (bsAnexo.Current as TRegistro_AnexoPedido).Ext_Anexo; // retornar do banco tbm
                ae = System.IO.Path.ChangeExtension(System.IO.Path.GetTempFileName(), extensao);

                System.IO.File.WriteAllBytes(
                    ae,
                    arquivoBuffer);

                // para abrir o arquivo para o usuario
                System.Diagnostics.Process.Start(ae);
            }
        }

        private void bb_visualizar_dup_Click(object sender, EventArgs e)
        {
            if (bsParcelas.Current != null)
            {
                CamadaDados.Financeiro.Bloqueto.blListaTitulo lista = TCN_Titulo.Buscar(string.Empty,
                                                   decimal.Parse((bsParcelas.Current as TRegistro_LanParcela).Nr_lanctostr),
                                                   decimal.Zero,
                                                   decimal.Zero,
                                                   string.Empty,
                                                   string.Empty,
                                                   string.Empty, string.Empty,
                                                   string.Empty,
                                                   decimal.Zero,
                                                   decimal.Zero,
                                                   string.Empty,
                                                   string.Empty,
                                                   string.Empty,
                                                   string.Empty,
                                                   string.Empty,
                                                   string.Empty,
                                                   string.Empty, string.Empty,
                                                   string.Empty, string.Empty,
                                                   string.Empty, string.Empty, 
                                                   false, 1, null);


                dsBloqueto.DataSource = lista;
            }
            else
            {
                return;
            }



            if (dsBloqueto.Current != null)
            {
                if ((dsBloqueto.Current as CamadaDados.Financeiro.Bloqueto.blTitulo).St_registro.Trim().ToUpper().Equals("C"))
                {
                    MessageBox.Show("Bloqueto encontra-se cancelado. Não sera possivel realizar a compensação do mesmo!", "Mensagem", MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                    return;
                }
                if ((dsBloqueto.Current as CamadaDados.Financeiro.Bloqueto.blTitulo).St_registro.Trim().ToUpper().Equals("P"))
                {
                    MessageBox.Show("Não é permitido reimprimir bloqueto COMPENSADO.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (!Altera_Relatorio)
                {
                    //Chamar tela de impressao para o bloqueto
                    using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
                    {
                        fImp.St_enabled_enviaremail = true;
                        fImp.pCd_clifor = (dsBloqueto.Current as CamadaDados.Financeiro.Bloqueto.blTitulo).Cd_sacado;
                        fImp.pMensagem = "BLOQUETO Nº" + (dsBloqueto.Current as CamadaDados.Financeiro.Bloqueto.blTitulo).Nosso_numero.Trim();
                        if ((fImp.ShowDialog() == DialogResult.OK) || (fImp.pSt_enviaremail))
                            TCN_LayoutBloqueto.Imprime_Bloqueto(Altera_Relatorio,
                                                                new CamadaDados.Financeiro.Bloqueto.blListaTitulo() { dsBloqueto.Current as CamadaDados.Financeiro.Bloqueto.blTitulo },
                                                                fImp.pSt_imprimir,
                                                                fImp.pSt_visualizar,
                                                                fImp.pSt_enviaremail,
                                                                fImp.pSt_exportPdf,
                                                                fImp.Path_exportPdf,
                                                                fImp.pDestinatarios,
                                                                "BLOQUETO Nº " + (dsBloqueto.Current as CamadaDados.Financeiro.Bloqueto.blTitulo).Nosso_numero.Trim(),
                                                                fImp.pDs_mensagem,
                                                                false);
                    }
                }
                else
                    TCN_LayoutBloqueto.Imprime_Bloqueto(Altera_Relatorio,
                                                        new CamadaDados.Financeiro.Bloqueto.blListaTitulo() { (dsBloqueto.Current as CamadaDados.Financeiro.Bloqueto.blTitulo) },
                                                        false,
                                                        false,
                                                        false,
                                                        false,
                                                        string.Empty,
                                                        null,
                                                        string.Empty,
                                                        string.Empty,
                                                        false);

                Altera_Relatorio = false;
            }
            else
            {

                MessageBox.Show("Não existe boleto desta duplicata", "Mensagem", MessageBoxButtons.OK,
                                  MessageBoxIcon.Information);
                return;

            }
        }

        private void tcItens_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (BS_Pedido.Current != null)
            {
                //Buscar NF
                if (tcItens.SelectedTab.Equals(tpNf))
                    (BS_Pedido.Current as TRegistro_Pedido).lNotaFiscal =
                        new CamadaDados.Faturamento.NotaFiscal.TCD_LanFaturamento().Select(
                            new TpBusca[]
                            { 
                                new TpBusca()
                                {
                                    vNM_Campo = string.Empty,
                                    vOperador = "exists",
                                    vVL_Busca = "(select 1 from tb_fat_pedido x "+
                                                "where x.Nr_Pedido = a.nr_pedido "+
                                                "and x.nr_pedido = " + (BS_Pedido.Current as TRegistro_Pedido).Nr_pedido.ToString() + ")"
                                },
                                new TpBusca()
                                {
                                    vNM_Campo = "isnull(a.st_registro, 'A')",
                                    vOperador = "<>",
                                    vVL_Busca = "'C'"
                                }
                            }, 0, string.Empty);

                //Buscar Parcelas Pedido
                if (tcItens.SelectedTab.Equals(tpFinanceiro))
                    (BS_Pedido.Current as TRegistro_Pedido).lParc =
                       new TCD_LanParcela().Select(
                            new TpBusca[]
                            {
                                new TpBusca()
                                {
                                    vNM_Campo = string.Empty,
                                    vOperador = "exists",
                                    vVL_Busca = "(select 1 from tb_fat_pedido_x_duplicata x " +
                                                "where x.cd_empresa = a.cd_empresa " +
                                                "and x.nr_lancto = a.nr_lancto " +
                                                "and x.cd_empresa = '" + (BS_Pedido.Current as TRegistro_Pedido).CD_Empresa.Trim() + "' " +
                                                "and x.nr_pedido = '" + (BS_Pedido.Current as TRegistro_Pedido).Nr_pedido.ToString() + "')"
                                },
                                new TpBusca()
                                {
                                    vNM_Campo = "isnull(dup.st_registro, 'A')",
                                    vOperador = "<>",
                                    vVL_Busca = "'C'"
                                }
                            }, 0, string.Empty, string.Empty, string.Empty);

                //Buscar Etapas
                if (tcItens.SelectedTab.Equals(tpEtapas))
                {
                    (BS_Pedido.Current as TRegistro_Pedido).lEtapa =
                           TCN_EtapaPedido.Busca(string.Empty,
                                                 (BS_Pedido.Current as TRegistro_Pedido).Nr_pedido.ToString(),
                                                 null);
                    bsProcessos_PositionChanged(this, new EventArgs());
                }

                BS_Pedido.ResetCurrentItem();
            }
        }

        private void bsEtapa_PositionChanged(object sender, EventArgs e)
        {
            if (bsEtapa.Current != null)
            {
                (bsEtapa.Current as TRegistro_EtapaPedido).lProcEtapa =
                    TCN_ProcEtapa.Busca(
                    (bsEtapa.Current as TRegistro_EtapaPedido).Id_etapastr,
                    (bsEtapa.Current as TRegistro_EtapaPedido).Nr_pedidostr,
                    string.Empty,
                    null
                    );
                bsEtapa.ResetCurrentItem();

                bsProcessos_PositionChanged(this, new EventArgs());
            }
        }

        private void bsProcessos_PositionChanged(object sender, EventArgs e)
        {
            if (bsProcessos.Current != null)
            {
                (bsProcessos.Current as TRegistro_ProcEtapa).lAnexo =
                    TCN_AnexoPedido.Buscar(
                                            (bsProcessos.Current as TRegistro_ProcEtapa).Nr_pedidostr,
                                            (bsProcessos.Current as TRegistro_ProcEtapa).Id_etapastr,
                                            (bsProcessos.Current as TRegistro_ProcEtapa).Id_processostr,
                                            (bsProcessos.Current as TRegistro_ProcEtapa).Id_Anexo,
                                            null);
                bsProcessos.ResetCurrentItem();
            }
        }

        private void gOrdemCarregamento_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null)
                if (e.ColumnIndex.Equals(0))
                    if (e.Value.ToString().Trim().ToUpper().Equals("FATURADO"))
                        gOrdemCarregamento.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Green;
                    else if (e.Value.ToString().Trim().ToUpper().Equals("PARCIAL"))
                        gOrdemCarregamento.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Blue;
                    else
                        gOrdemCarregamento.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
        }

        private void BS_Pedido_PositionChanged(object sender, EventArgs e)
        {
            if (BS_Pedido.Current != null)
            {
                //Buscar Ordem de Carregamento
                (BS_Pedido.Current as TRegistro_Pedido).lOrdem =
                    TCN_OrdemCarregamento.Busca((BS_Pedido.Current as TRegistro_Pedido).CD_Empresa,
                                                                                 string.Empty,
                                                                                 (BS_Pedido.Current as TRegistro_Pedido).Nr_pedido.ToString(),
                                                                                 string.Empty,
                                                                                 string.Empty,
                                                                                 string.Empty,
                                                                                 string.Empty,
                                                                                 null);

                //Buscar Expedição
                (BS_Pedido.Current as TRegistro_Pedido).lExpedicao =
                    new TCD_Expedicao().Select(
                        new TpBusca[]
                        {
                            new TpBusca()
                            {
                                vNM_Campo = string.Empty,
                                vOperador = "exists",
                                vVL_Busca = "(select 1 from TB_FAT_ItensExpedicao x " +
                                            "where a.cd_empresa = x.cd_empresa " +
                                            "and a.id_expedicao = x.id_expedicao " +
                                            "and x.nr_pedido = " + (BS_Pedido.Current as TRegistro_Pedido).Nr_pedido + ") "
                            }
                        }, 0, string.Empty);

                //Buscar Financeiro/Etapas/NF
                tcItens_SelectedIndexChanged(this, new EventArgs());
                BS_Pedido.ResetCurrentItem();
                bsExpedicao_PositionChanged(this, new EventArgs());
                bsOrdemCarregamento_PositionChanged(this, new EventArgs());
            }
        }

        private void bsExpedicao_PositionChanged(object sender, EventArgs e)
        {
            if (bsExpedicao.Current != null)
            {
                (bsExpedicao.Current as TRegistro_Expedicao).lItens =
                    TCN_ItensExpedicao.Busca((bsExpedicao.Current as TRegistro_Expedicao).Cd_empresa,
                                                                              (bsExpedicao.Current as TRegistro_Expedicao).Id_expedicaostr,
                                                                              string.Empty,
                                                                              null);
                bsExpedicao.ResetCurrentItem();
            }
        }

        private void bb_novaOrdem_Click(object sender, EventArgs e)
        {
            afterNovo();
        }

        private void bb_excluirOrdem_Click(object sender, EventArgs e)
        {
            afterExclui();
        }

        private void bb_faturarOrdem_Click(object sender, EventArgs e)
        {
            faturarPedido();
        }

        private void bb_imprimirOrdem_Click(object sender, EventArgs e)
        {
            afterPrint();
        }

        private void g_Consulta_Pedido_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (g_Consulta_Pedido.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.NotSortable)
                return;
            if (BS_Pedido.Count < 1)
                return;
            PropertyDescriptorCollection lP = TypeDescriptor.GetProperties(new TRegistro_Pedido());
            TList_Pedido lComparer;
            SortOrder direcao = SortOrder.None;
            if ((g_Consulta_Pedido.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None) ||
                (g_Consulta_Pedido.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending))
            {
                lComparer = new TList_Pedido(lP.Find(g_Consulta_Pedido.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Ascending);
                foreach (DataGridViewColumn c in g_Consulta_Pedido.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Ascending;
            }
            else
            {
                lComparer = new TList_Pedido(lP.Find(g_Consulta_Pedido.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Descending);
                foreach (DataGridViewColumn c in g_Consulta_Pedido.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Descending;
            }
            (BS_Pedido.List as TList_Pedido).Sort(lComparer);
            BS_Pedido.ResetBindings(false);
            g_Consulta_Pedido.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = direcao;
        }

        private void miNfNormal_Click(object sender, EventArgs e)
        {
            faturarPedidoOrdem("'NO'");
        }

        private void nFEntregaFuturaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            faturarPedidoOrdem("'FT'");
        }

        private void nFDevoluçãoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            faturarPedidoOrdem("'DV','DF'");
        }

        private void toolStripButton18_Click(object sender, EventArgs e)
        {
            if (BS_Pedido.Count > 0)
            {
                if (!string.IsNullOrEmpty((bsItensExpOrdem.Current as TRegistro_ItensExpedicao).Nr_serie))
                {
                    object obj2 = new TCD_CadClifor().BuscarEscalar(
                            new TpBusca[]
                            {
                            new TpBusca()
                            {
                                vNM_Campo = "a.nm_clifor",
                                vOperador = "=",
                                vVL_Busca = "'" + (BS_Pedido.Current as TRegistro_Pedido).NM_Clifor.Trim() + "'"
                            }
                            }, "isnull(a.nr_cgc, a.nr_cpf) as NR_CGC_CPF");
                    if (obj2 != null)
                        (BS_Pedido.Current as TRegistro_Pedido).nr_cgc_cpf = obj2.ToString();
                    TList_Pedido a = new TList_Pedido();
                    a.Add((BS_Pedido.Current as TRegistro_Pedido));
                    BindingSource ae = new BindingSource();
                    ae.DataSource = a;

                    TList_OrdemCarregamento cc = new TList_OrdemCarregamento();
                    cc.Add((bsOrdemCarregamento.Current as TRegistro_OrdemCarregamento));
                    BindingSource ca = new BindingSource();
                    ca.DataSource = cc;
                    using (TFGerenciadorImpressao fImp = new TFGerenciadorImpressao())
                    {
                        Relatorio Rel = new Relatorio();
                        Rel.Altera_Relatorio = Altera_Relatorio;
                        Rel.Adiciona_DataSource("BS_Pedido", ae);
                        Rel.Adiciona_DataSource("BS_carregamento", ca);
                        Rel.Nome_Relatorio = "TFFichaAcompanhamento";
                        Rel.Ident = "TFFichaAcompanhamento";
                        Rel.NM_Classe = Name;
                        Rel.Modulo = Tag.ToString().Substring(0, 3);

                        fImp.St_enabled_enviaremail = true;
                        fImp.pCd_clifor = string.Empty;
                        fImp.pMensagem = "FICHA DE ACOMPANHAMENTO DO TANQUE";

                        if (Altera_Relatorio)
                        {
                            Rel.Gera_Relatorio(string.Empty,
                                               fImp.pSt_imprimir,
                                               fImp.pSt_visualizar,
                                               fImp.pSt_enviaremail,
                                               fImp.pSt_exportPdf,
                                               fImp.Path_exportPdf,
                                               fImp.pDestinatarios,
                                               null,
                                               "RELATORIO " + Text.Trim(),
                                               fImp.pDs_mensagem);

                            Altera_Relatorio = false;
                        }
                        else
                            if ((fImp.ShowDialog() == DialogResult.OK) || (fImp.pSt_enviaremail))
                            Rel.Gera_Relatorio(string.Empty,
                                               fImp.pSt_imprimir,
                                               fImp.pSt_visualizar,
                                               fImp.pSt_enviaremail,
                                               fImp.pSt_exportPdf,
                                               fImp.Path_exportPdf,
                                               fImp.pDestinatarios,
                                               null,
                                               "RELATORIO " + Text.Trim(),
                                               fImp.pDs_mensagem);
                    }
                }
            }
            else
                MessageBox.Show("Não existe Registros Para Imprimir o Relatório!");
            
        }

        private void toolStripButton17_Click(object sender, EventArgs e) 
        {
            if (bsItensExpOrdem.Current != null)
            {
                using (FImp_OrdemCarregamento imp = new FImp_OrdemCarregamento())
                {
                    if(imp.ShowDialog() == DialogResult.OK)
                    {
                        Proc_Commoditties.ThreadLoadWordPrint espera = new Proc_Commoditties.ThreadLoadWordPrint("GERANDO RELATORIO");
                        #region doc1
                        //Abre a aplicação Word e faz uma cópia do documento mapeado
                        Microsoft.Office.Interop.Word.Application aplication1 = new Microsoft.Office.Interop.Word.Application();
                        Microsoft.Office.Interop.Word.Document doc1 = new Microsoft.Office.Interop.Word.Document();
                        //Objeto a ser usado nos parâmetros opcionais
                        object missing1 = System.Reflection.Missing.Value;

                        //Buscar layout
                        byte[] arquivoBuffer1 = File.ReadAllBytes("C:\\Aliance.NET\\Imp_petroaco\\" + imp.item + "\\Doc1.docx");
                        string nameTemp1 = Path.ChangeExtension(Path.GetTempFileName(), ".docx");
                        File.WriteAllBytes(
                            nameTemp1,
                            arquivoBuffer1);
                        object Template1 = nameTemp1;

                        //   aplication = new Microsoft.Office.Interop.Word.ApplicationClass();//
                        doc1 = aplication1.Documents.Add(ref Template1, ref missing1, ref missing1, ref missing1);

                        aplication1.Visible = false;
                        doc1.Activate();
                        FileInfo wordFile1 = new FileInfo(Template1.ToString());
                        object outputFileName1 = wordFile1.FullName.Replace(".docx", ".pdf");
                        object fileFormat1 = Microsoft.Office.Interop.Word.WdSaveFormat.wdFormatPDF;
                        doc1.SaveAs(ref outputFileName1, ref fileFormat1, ref missing1, ref missing1, ref missing1, ref missing1, ref missing1,
                            ref missing1, ref missing1, ref missing1, ref missing1, ref missing1, ref missing1, ref missing1, ref missing1, ref missing1);
                        Process.Start(outputFileName1.ToString());
                        //aplication1.ActiveDocument.PrintOut(true, false, Microsoft.Office.Interop.Word.WdPrintOutRange.wdPrintAllDocument,
                        //                                    Item: Microsoft.Office.Interop.Word.WdPrintOutItem.wdPrintDocumentContent, Copies: "1", Pages: "",
                        //                                    PageType: Microsoft.Office.Interop.Word.WdPrintOutPages.wdPrintAllPages, PrintToFile: false, Collate: true,
                        //                                    ManualDuplexPrint: false);
                        doc1 = null;
                        //Retirando Word da memória
                        aplication1.Quit(Microsoft.Office.Interop.Word.WdSaveOptions.wdDoNotSaveChanges);
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(aplication1);
                        aplication1 = null;
                        GC.Collect();
                        #endregion
                        TList_CadClifor clifor = TCN_CadClifor.Busca_Clifor(((BS_Pedido.Current as TRegistro_Pedido).CD_Clifor), 
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
                                                                            string.Empty, 
                                                                            string.Empty, 
                                                                            string.Empty, 
                                                                            string.Empty, 
                                                                            string.Empty, 
                                                                            string.Empty, 
                                                                            1, 
                                                                            null);
                        TList_CadEndereco endereco = TCN_CadEndereco.Buscar((BS_Pedido.Current as TRegistro_Pedido).CD_Clifor, 
                                                                            (BS_Pedido.Current as TRegistro_Pedido).CD_Endereco, 
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
                        object fabricacao = new CamadaDados.Producao.Producao.TCD_SerieProduto().BuscarEscalar(
                            new TpBusca[]
                            {
                                new TpBusca { vNM_Campo = "a.nr_serie", vOperador = "=", vVL_Busca = "'" + (bsItensExpOrdem.Current as TRegistro_ItensExpedicao).Nr_serie.Trim() + "'" },
                                new TpBusca { vNM_Campo = "a.cd_empresa", vOperador = "=", vVL_Busca = "'" + (bsItensExpOrdem.Current as TRegistro_ItensExpedicao).Cd_empresa.Trim() + "'" },
                                new TpBusca { vNM_Campo = "a.cd_produto", vOperador = "=", vVL_Busca = "'" + (bsItensExpOrdem.Current as TRegistro_ItensExpedicao).Cd_produto.Trim() + "'" }
                            }, "a.dt_cad");


                        TRegistro_LanFaturamento a = TCN_LanFaturamento.BuscarNF((bsExpOrdem.Current as TRegistro_Expedicao).Cd_empresa,
                                                                                 (bsExpOrdem.Current as TRegistro_Expedicao).Nr_lanctoFiscal.ToString(), null);

                        #region doc2

                        //Abre a aplicação Word e faz uma cópia do documento mapeado
                        Microsoft.Office.Interop.Word.Application aplication = new Microsoft.Office.Interop.Word.Application();
                        Microsoft.Office.Interop.Word.Document doc = new Microsoft.Office.Interop.Word.Document();
                        //Objeto a ser usado nos parâmetros opcionais
                        object missing = System.Reflection.Missing.Value;

                        //Buscar layout
                        byte[] arquivoBuffer = File.ReadAllBytes("C:\\Aliance.NET\\Imp_petroaco\\" + imp.item + "\\doc2.doc");
                        string nameTemp = Path.ChangeExtension(Path.GetTempFileName(), ".doc");
                        File.WriteAllBytes(
                            nameTemp,
                            arquivoBuffer);
                        object Template = nameTemp;

                        doc = aplication.Documents.Add(ref Template, ref missing, ref missing, ref missing);


                        #region foreach
                        foreach (Microsoft.Office.Interop.Word.Field field in doc.Fields)
                        {
                            if (field.Code.Text.Contains("razaosocial"))
                            {
                                field.Select();
                                aplication.Selection.Font.Size = 10;
                                aplication.Selection.TypeText(clifor[0].Nm_clifor);
                            }
                            else
                            if (field.Code.Text.Contains("endereco"))
                            {
                                field.Select();
                                aplication.Selection.Font.Size = 10;
                                aplication.Selection.TypeText(endereco[0].Ds_endereco);
                            }
                            else
                                if (field.Code.Text.Contains("bairro"))
                            {
                                field.Select();
                                aplication.Selection.Font.Size = 10;
                                aplication.Selection.TypeText(endereco[0].Bairro);
                            }
                            else if (field.Code.Text.Contains("cep"))
                            {
                                field.Select();
                                aplication.Selection.Font.Size = 10;
                                aplication.Selection.TypeText(endereco[0].Cep);
                            }
                            else if (field.Code.Text.Contains("cidade"))
                            {
                                field.Select();
                                aplication.Selection.Font.Size = 10;
                                aplication.Selection.TypeText(endereco[0].DS_Cidade);
                            }
                            //Endereco entrega
                            else if (field.Code.Text.Contains("cnpj"))
                            {
                                field.Select();
                                aplication.Selection.TypeText(clifor[0].Nr_cgc);
                            }
                            else if (field.Code.Text.Contains("incs"))
                            {
                                field.Select();
                                aplication.Selection.TypeText(endereco[0].Insc_estadual);
                            }
                            else if (field.Code.Text.Contains("serie"))
                            {
                                field.Select();
                                aplication.Selection.TypeText((bsItensExpOrdem.Current as TRegistro_ItensExpedicao).Nr_serie);
                            }
                            else if (field.Code.Text.Contains("notafiscal"))
                            {
                                field.Select();
                                aplication.Selection.TypeText(a.Nr_notafiscalstr);
                            }
                            else if (field.Code.Text.Contains("dt_nf"))
                            {
                                field.Select();
                                aplication.Selection.TypeText(a.Dt_emissaostring);
                            }
                            else if (field.Code.Text.Contains("fabricacao"))
                            {
                                field.Select();
                                aplication.Selection.TypeText(fabricacao.ToString());
                            }
                        }
                        #endregion
                        aplication.Visible = false;
                        doc.Activate();
                        FileInfo wordFile = new FileInfo(Template.ToString());
                        object outputFileName = wordFile.FullName.Replace(".doc", ".pdf");
                        object fileFormat = Microsoft.Office.Interop.Word.WdSaveFormat.wdFormatPDF;
                        doc.SaveAs(ref outputFileName, ref fileFormat, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing);
                        Process.Start(outputFileName.ToString());
                        //aplication.ActiveDocument.PrintOut(true, false, Microsoft.Office.Interop.Word.WdPrintOutRange.wdPrintAllDocument,
                        //                                   Item: Microsoft.Office.Interop.Word.WdPrintOutItem.wdPrintDocumentContent, Copies: "1", Pages: "",
                        //                                   PageType: Microsoft.Office.Interop.Word.WdPrintOutPages.wdPrintAllPages, PrintToFile: false, Collate: true,
                        //                                   ManualDuplexPrint: false);

                        doc = null;
                        //Retirando Word da memória
                        aplication.Quit(Microsoft.Office.Interop.Word.WdSaveOptions.wdDoNotSaveChanges);
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(aplication);
                        aplication = null;
                        GC.Collect();

                        #endregion
                        toolStripButton18_Click(this, new EventArgs());
                        espera.Fechar();
                        espera = null;
                    }
                }
            }
        }
    }
}
