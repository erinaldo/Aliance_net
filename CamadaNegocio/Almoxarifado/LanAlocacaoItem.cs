using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Almoxarifado;

namespace CamadaNegocio.Almoxarifado
{
    public class TCN_AlocacaoItem
    {
        public static TList_AlocacaoItem Buscar(string Id_entrega,
                                                string Id_almox,
                                                BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (!string.IsNullOrEmpty(Id_entrega))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_entrega";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_entrega;
            }
            if (!string.IsNullOrEmpty(Id_almox))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_almox";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_almox;
            }
            return new TCD_AlocacaoItem(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_AlocacaoItem val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_AlocacaoItem qtb_aloc = new TCD_AlocacaoItem();
            try
            {
                if (banco == null)
                    st_transacao = qtb_aloc.CriarBanco_Dados(true);
                else
                    qtb_aloc.Banco_Dados = banco;
                string retorno = qtb_aloc.Gravar(val);
                if (st_transacao)
                    qtb_aloc.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_aloc.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_aloc.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_AlocacaoItem val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_AlocacaoItem qtb_aloc = new TCD_AlocacaoItem();
            try
            {
                if (banco == null)
                    st_transacao = qtb_aloc.CriarBanco_Dados(true);
                else
                    qtb_aloc.Banco_Dados = banco;
                //Verificar se a entrega ja nao esta faturada
                object obj = new CamadaDados.Faturamento.NotaFiscal.TCD_LanFaturamento(qtb_aloc.Banco_Dados).BuscarEscalar(
                                new Utils.TpBusca[]
                                {
                                    new Utils.TpBusca()
                                    {
                                        vNM_Campo = "isnull(a.st_registro, 'A')",
                                        vOperador = "<>",
                                        vVL_Busca = "'C'"
                                    },
                                    new Utils.TpBusca()
                                    {
                                        vNM_Campo = string.Empty,
                                        vOperador = "exists",
                                        vVL_Busca = "(select 1 from tb_fat_notafiscal_item_x_estoque x "+
                                                    "where x.cd_empresa = a.cd_empresa "+
                                                    "and x.nr_lanctofiscal = a.nr_lanctofiscal "+
                                                    "and x.id_entrega = " + val.Id_entregastr + ")"
                                    }
                                }, "a.nr_notafiscal");
                if (obj != null)
                    throw new Exception("Entrega: " + val.Id_entregastr + " ja se encontra faturada.\r\n" +
                                        "Nota Fiscal: " + obj.ToString().Trim() + ".");
                qtb_aloc.Excluir(val);
                //Excluir entrega do pedido
                CamadaNegocio.Faturamento.Pedido.TCN_LanEntregaPedido.Excluir(
                    CamadaNegocio.Faturamento.Pedido.TCN_LanEntregaPedido.Busca(val.Id_entregastr,
                                                                                string.Empty,
                                                                                string.Empty,
                                                                                string.Empty,
                                                                                false,
                                                                                string.Empty,
                                                                                qtb_aloc.Banco_Dados)[0], qtb_aloc.Banco_Dados);
                if (st_transacao)
                    qtb_aloc.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_aloc.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_aloc.deletarBanco_Dados();
            }
        }

        public static void AlocarItem(CamadaDados.Faturamento.Pedido.TRegistro_EntregaPedido val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_AlocacaoItem qtb_aloc = new TCD_AlocacaoItem();
            try
            {
                if (banco == null)
                    st_transacao = qtb_aloc.CriarBanco_Dados(true);
                else
                    qtb_aloc.Banco_Dados = banco;
                //Gravar entrega pedido
                CamadaNegocio.Faturamento.Pedido.TCN_LanEntregaPedido.Gravar(val, qtb_aloc.Banco_Dados);
                //Gravar alocacao item
                Gravar(new TRegistro_AlocacaoItem()
                {
                    Id_almox = val.Id_almox,
                    Id_entrega = val.Id_entrega
                }, qtb_aloc.Banco_Dados);
                if (st_transacao)
                    qtb_aloc.Banco_Dados.Commit_Tran();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_aloc.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro alocar item: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_aloc.deletarBanco_Dados();
            }
        }
    }
}
