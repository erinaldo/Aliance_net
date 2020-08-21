using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Faturamento.PDV;

namespace CamadaNegocio.Faturamento.PDV
{
    public class TCN_DevolucaoCF
    {
        public static TList_DevolucaoCF Buscar(string Cd_empresa,
                                               string Id_cupom,
                                               string Nr_lanctofiscal,
                                               BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (!string.IsNullOrEmpty(Cd_empresa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Id_cupom))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_cupom";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_cupom;
            }
            if (!string.IsNullOrEmpty(Nr_lanctofiscal))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.nr_lanctofiscal";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Nr_lanctofiscal;
            }
            return new TCD_DevolucaoCF(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_DevolucaoCF val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_DevolucaoCF qtb_dev = new TCD_DevolucaoCF();
            try
            {
                if (banco == null)
                    st_transacao = qtb_dev.CriarBanco_Dados(true);
                else qtb_dev.Banco_Dados = banco;
                string retorno = qtb_dev.Gravar(val);
                if (st_transacao)
                    qtb_dev.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_dev.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar devolução: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_dev.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_DevolucaoCF val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_DevolucaoCF qtb_dev = new TCD_DevolucaoCF();
            try
            {
                if (banco == null)
                    st_transacao = qtb_dev.CriarBanco_Dados(true);
                else qtb_dev.Banco_Dados = banco;
                qtb_dev.Excluir(val);
                if (st_transacao)
                    qtb_dev.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_dev.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir devolução: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_dev.deletarBanco_Dados();
            }
        }

        public static void ProcessarNFDevolucao(CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento rNf, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Condicional qtb_cond = new TCD_Condicional();
            try
            {
                if (banco == null)
                    st_transacao = qtb_cond.CriarBanco_Dados(true);
                //Buscar moeda padrao
                string moeda = CamadaNegocio.ConfigGer.TCN_CadParamGer.BuscaVL_String_Empresa("CD_MOEDA_PADRAO", rNf.Cd_empresa, qtb_cond.Banco_Dados);
                if (string.IsNullOrEmpty(moeda))
                    throw new Exception("Não existe moeda padrão configurada para a empresa " + rNf.Cd_empresa);
                //Gravar Pedido
                CamadaDados.Faturamento.Pedido.TRegistro_Pedido rPed = new CamadaDados.Faturamento.Pedido.TRegistro_Pedido();
                rPed.CD_Empresa = rNf.Cd_empresa;
                rPed.CD_Clifor = rNf.Cd_clifor;
                rPed.CD_Endereco = rNf.Cd_endereco;
                rPed.Cd_moeda = moeda;
                rPed.Cd_moeda = moeda;
                rPed.CFG_Pedido = rNf.lCFGFiscal[0].Cfg_pedido;
                rPed.DT_Pedido = rNf.Dt_emissao;
                rPed.TP_Movimento = rNf.Tp_movimento; //Pedido de saida
                rPed.ST_Pedido = "F"; //Pedido fechado
                rPed.ST_Registro = "F"; //Pedido fechado
                //Montar itens do pedido
                rNf.ItensNota.ForEach(p =>
                {
                    rPed.Pedido_Itens.Add(new CamadaDados.Faturamento.Pedido.TRegistro_LanPedido_Item()
                    {
                        Cd_Empresa = p.Cd_empresa,
                        Cd_local = p.Cd_local,
                        Cd_produto = p.Cd_produto,
                        Cd_condfiscal_produto = p.Cd_condfiscal_produto,
                        Cd_unidade_est = p.Cd_unidade,
                        Cd_unidade_valor = p.Cd_unidade,
                        Quantidade = p.Quantidade,
                        Vl_unitario = p.Vl_unitario,
                        Vl_subtotal = p.Vl_subtotal
                    });
                });
                CamadaNegocio.Faturamento.Pedido.TCN_Pedido.Grava_Pedido(rPed, qtb_cond.Banco_Dados);
                //Gravar Nota Fiscal
                rNf.Nr_pedido = rPed.Nr_pedido;
                for (int i = 0; i < rPed.Pedido_Itens.Count; i++)
                {
                    rNf.ItensNota[i].Nr_pedido = rPed.Pedido_Itens[i].Nr_pedido.Value;
                    rNf.ItensNota[i].Id_pedidoitem = rPed.Pedido_Itens[i].Id_pedidoitem;
                }
                NotaFiscal.TCN_LanFaturamento.GravarFaturamento(rNf, null, qtb_cond.Banco_Dados);
                //Amarrar Itens NF a Itens Condicional
                rNf.ItensNota.ForEach(p =>
                    Gravar(new TRegistro_DevolucaoCF()
                    {
                        Cd_empresa = p.Cd_empresa,
                        Id_cupom = p.rItemCF.ID_NFCe,
                        Id_lancto = p.rItemCF.Id_lancto,
                        Nr_lanctofiscal = p.Nr_lanctofiscal,
                        Id_nfitem = p.Id_nfitem
                    }, qtb_cond.Banco_Dados));
                if (st_transacao)
                    qtb_cond.Banco_Dados.Commit_Tran();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_cond.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro processar NF Condicional: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_cond.deletarBanco_Dados();
            }
        }
    }
}
