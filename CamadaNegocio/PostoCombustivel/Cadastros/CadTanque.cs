using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.PostoCombustivel.Cadastros;

namespace CamadaNegocio.PostoCombustivel.Cadastros
{
    public class TCN_TanqueCombustivel
    {
        public static TList_TanqueCombustivel Buscar(string Id_tanque,
                                                     string Cd_empresa,
                                                     string Cd_local,
                                                     string Cd_produto,
                                                     string St_registro,
                                                     BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (!string.IsNullOrEmpty(Id_tanque))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_tanque";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_tanque;
            }
            if (!string.IsNullOrEmpty(Cd_empresa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Cd_local))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_local";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_local.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Cd_produto))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_produto";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_produto.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(St_registro))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "isnull(a.st_registro, 'A')";
                filtro[filtro.Length - 1].vOperador = "in";
                filtro[filtro.Length - 1].vVL_Busca = "(" + St_registro.Trim() + ")";
            }

            return new TCD_TanqueCombustivel(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_TanqueCombustivel val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_TanqueCombustivel qtb_tanque = new TCD_TanqueCombustivel();
            try
            {
                if (banco == null)
                    st_transacao = qtb_tanque.CriarBanco_Dados(true);
                else
                    qtb_tanque.Banco_Dados = banco;
                val.Id_tanquestr = CamadaDados.TDataQuery.getPubVariavel(qtb_tanque.Gravar(val), "@P_ID_TANQUE");
                if(val.St_registro.Trim().ToUpper().Equals("C"))
                    //Cancelar todos os bicos amarrados ao tanque
                    TCN_BicoBomba.Buscar(string.Empty,
                                         string.Empty,
                                         val.Cd_empresa,
                                         val.Id_tanquestr,
                                         "'A'",
                                         qtb_tanque.Banco_Dados).ForEach(p =>
                                         {
                                             p.St_registro = "C";
                                             TCN_BicoBomba.Gravar(p, qtb_tanque.Banco_Dados);
                                         });
                if (st_transacao)
                    qtb_tanque.Banco_Dados.Commit_Tran();
                return val.Id_tanquestr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_tanque.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar tanque: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_tanque.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_TanqueCombustivel val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_TanqueCombustivel qtb_tanque = new TCD_TanqueCombustivel();
            try
            {
                if (banco == null)
                    st_transacao = qtb_tanque.CriarBanco_Dados(true);
                else
                    qtb_tanque.Banco_Dados = banco;
                if (new TCD_BicoBomba(qtb_tanque.Banco_Dados).BuscarEscalar(
                    new Utils.TpBusca[]
                    {
                        new Utils.TpBusca()
                        {
                            vNM_Campo = "a.id_tanque",
                            vOperador = "=",
                            vVL_Busca = val.Id_tanquestr
                        }
                    }, "1") != null)
                {
                    val.St_registro = "C";
                    qtb_tanque.Gravar(val);
                    //Cancelar todos os bicos amarrados ao tanque
                    TCN_BicoBomba.Buscar(string.Empty,
                                         string.Empty,
                                         val.Cd_empresa,
                                         val.Id_tanquestr,
                                         "'A'",
                                         qtb_tanque.Banco_Dados).ForEach(p =>
                                             {
                                                 p.St_registro = "C";
                                                 TCN_BicoBomba.Gravar(p, qtb_tanque.Banco_Dados);
                                             });
                }
                else
                    qtb_tanque.Excluir(val);
                if (st_transacao)
                    qtb_tanque.Banco_Dados.Commit_Tran();
                return val.Id_tanquestr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_tanque.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir tanque: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_tanque.deletarBanco_Dados();
            }
        }

    }
}
