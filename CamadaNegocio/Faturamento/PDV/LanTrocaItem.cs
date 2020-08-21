using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Faturamento.PDV;

namespace CamadaNegocio.Faturamento.PDV
{
    public class TCN_TrocaItem
    {
        public static TList_TrocaItem Buscar(string Cd_empresa,
                                                string Id_Cupom,
                                                string Id_lanctoOrig,
                                                string Id_lanctoDest,
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
            if (!string.IsNullOrEmpty(Id_Cupom))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.Id_Cupom";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_Cupom;
            }
            if (!string.IsNullOrEmpty(Id_lanctoOrig))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.Id_lanctoOrig";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_lanctoOrig;
            }
            if (!string.IsNullOrEmpty(Id_lanctoDest))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.Id_lanctoDest";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_lanctoDest;
            }
            return new TCD_TrocaItem(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_TrocaItem val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_TrocaItem qtb_troca = new TCD_TrocaItem();
            try
            {
                if (banco == null)
                    st_transacao = qtb_troca.CriarBanco_Dados(true);
                else
                    qtb_troca.Banco_Dados = banco;
                //Cancelar estoque
                CamadaDados.Estoque.TList_RegLanEstoque lEstoque =
                    new CamadaDados.Estoque.TCD_LanEstoque(qtb_troca.Banco_Dados).Select(
                    new Utils.TpBusca[]
                    {
                        new Utils.TpBusca()
                        {
                            vNM_Campo = string.Empty,
                            vOperador = "exists",
                            vVL_Busca = "(select 1 from tb_pdv_cupomfiscal_item_x_estoque x " +
                                        "where x.cd_empresa = a.cd_empresa " +
                                        "and x.cd_produto = a.cd_produto " +
                                        "and x.id_lanctoestoque = a.id_lanctoestoque " +
                                        "and x.id_cupom = " + val.Id_cupom.Value.ToString() + " " +
                                        "and x.cd_empresa = '" + val.Cd_empresa.Trim() + "' " +
                                        "and x.id_lancto = " + val.Id_lanctoOrig.Value.ToString() + ")"
                        }
                    }, 0, string.Empty, string.Empty, string.Empty);
                lEstoque.ForEach(p =>
                {
                    p.St_registro = "C";
                    CamadaNegocio.Estoque.TCN_LanEstoque.CancelarEstoque(p, qtb_troca.Banco_Dados);
                });
                string retorno = qtb_troca.Gravar(val);
                if (st_transacao)
                    qtb_troca.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_troca.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar troca: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_troca.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_TrocaItem val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_TrocaItem qtb_troca = new TCD_TrocaItem();
            try
            {
                if (banco == null)
                    st_transacao = qtb_troca.CriarBanco_Dados(true);
                else qtb_troca.Banco_Dados = banco;
                qtb_troca.Excluir(val);
                if (st_transacao)
                    qtb_troca.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_troca.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir troca: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_troca.deletarBanco_Dados();
            }
        }
    }
}
