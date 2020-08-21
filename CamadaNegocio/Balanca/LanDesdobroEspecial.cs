using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Balanca;

namespace CamadaNegocio.Balanca
{
    public class TCN_DesdobroEspecial
    {
        public static TList_DesdobroEspecial Buscar(string Id_desdobroespecial,
                                                    string Cd_empresa,
                                                    string Id_ticket,
                                                    string Tp_pesagem,
                                                    BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (!string.IsNullOrEmpty(Id_desdobroespecial))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_desdobroespecial";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_desdobroespecial;
            }
            if (!string.IsNullOrEmpty(Cd_empresa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Id_ticket))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_ticket";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_ticket;
            }
            if (!string.IsNullOrEmpty(Tp_pesagem))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.tp_pesagem";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Tp_pesagem.Trim() + "'";
            }

            return new TCD_DesdobroEspecial(banco).Select(filtro, 0, string.Empty);
        }

        public static void ProcessarDesdobroEspecial(TList_DesdobroEspecial val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_DesdobroEspecial qtb_desd = new TCD_DesdobroEspecial();
            try
            {
                if (banco == null)
                    st_transacao = qtb_desd.CriarBanco_Dados(true);
                else
                    qtb_desd.Banco_Dados = banco;
                val.ForEach(p =>
                    {
                        if (p.Id_transf == null)
                        {
                            //Gravar Transferencia
                            CamadaNegocio.Graos.TCN_Transferencia.Grava_Transferencia(p.rTransf, qtb_desd.Banco_Dados);
                            //Gravar Id. Transf no Desdobro Especial
                            p.Id_transf = p.rTransf.ID_Transf;
                            TCN_DesdobroEspecial.Gravar(p, qtb_desd.Banco_Dados);
                        }
                    });
                if (st_transacao)
                    qtb_desd.Banco_Dados.Commit_Tran();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_desd.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro processar desdobro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_desd.deletarBanco_Dados();
            }
        }

        public static void EstornarProcDesdobroEspecial(TList_DesdobroEspecial val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_DesdobroEspecial qtb_desd = new TCD_DesdobroEspecial();
            try
            {
                if (banco == null)
                    st_transacao = qtb_desd.CriarBanco_Dados(true);
                else
                    qtb_desd.Banco_Dados = banco;
                val.ForEach(p =>
                    {
                        if(p.Id_transf.HasValue)
                        {
                            //Cancelar transferencia
                            CamadaDados.Graos.TList_Transferencia lTransf = 
                                CamadaNegocio.Graos.TCN_Transferencia.Busca(p.Id_transf.Value.ToString(),
                                                                            string.Empty,
                                                                            string.Empty,
                                                                            string.Empty,
                                                                            string.Empty,
                                                                            string.Empty,
                                                                            string.Empty,
                                                                            string.Empty,
                                                                            string.Empty,
                                                                            string.Empty,
                                                                            qtb_desd.Banco_Dados);
                            if(lTransf.Count > 0)
                            {
                                //Buscar Pedido Origem
                                lTransf[0].Transf_X_Pedido_Origem =
                                    CamadaNegocio.Graos.TCN_Transf_X_Pedido.Busca(lTransf[0].ID_Transf.ToString(),
                                                                                  string.Empty,
                                                                                  "S",
                                                                                  string.Empty,
                                                                                  string.Empty,
                                                                                  string.Empty,
                                                                                  false,
                                                                                  qtb_desd.Banco_Dados);
                                //Buscar Pedido Destino
                                lTransf[0].Transf_X_Pedido_Destino =
                                    CamadaNegocio.Graos.TCN_Transf_X_Pedido.Busca(lTransf[0].ID_Transf.ToString(),
                                                                                  string.Empty,
                                                                                  "E",
                                                                                  string.Empty,
                                                                                  string.Empty,
                                                                                  string.Empty,
                                                                                  false,
                                                                                  null);
                                CamadaNegocio.Graos.TCN_Transferencia.Cancela_Transferencia(lTransf[0], qtb_desd.Banco_Dados);
                                //Excluir valor campo transferencia do desdobro especial
                                p.Id_transf = null;
                                Gravar(p, qtb_desd.Banco_Dados);
                            }
                        }
                    });
                if (st_transacao)
                    qtb_desd.Banco_Dados.Commit_Tran();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_desd.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro estornar processamento desdobro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_desd.deletarBanco_Dados();
            }
        }

        public static string Gravar(TRegistro_DesdobroEspecial val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_DesdobroEspecial qtb_desdobro = new TCD_DesdobroEspecial();
            try
            {
                if (banco == null)
                    st_transacao = qtb_desdobro.CriarBanco_Dados(true);
                else
                    qtb_desdobro.Banco_Dados = banco;
                val.Id_desdobroespecial = Convert.ToDecimal(CamadaDados.TDataQuery.getPubVariavel(qtb_desdobro.Gravar(val), "@P_ID_DESDOBROESPECIAL"));
                if (st_transacao)
                    qtb_desdobro.Banco_Dados.Commit_Tran();
                return val.Id_desdobroespecial.HasValue ? val.Id_desdobroespecial.Value.ToString() : string.Empty;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_desdobro.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar desdobro especial: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_desdobro.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_DesdobroEspecial val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_DesdobroEspecial qtb_desdobro = new TCD_DesdobroEspecial();
            try
            {
                if (banco == null)
                    st_transacao = qtb_desdobro.CriarBanco_Dados(true);
                else
                    qtb_desdobro.Banco_Dados = banco;
                qtb_desdobro.Excluir(val);
                if (st_transacao)
                    qtb_desdobro.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_desdobro.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir desdobro especial: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_desdobro.deletarBanco_Dados();
            }
        }
    }
}
