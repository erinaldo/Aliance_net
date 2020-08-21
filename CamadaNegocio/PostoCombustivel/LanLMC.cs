using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;
using CamadaDados.PostoCombustivel;

namespace CamadaNegocio.PostoCombustivel
{
    public class TCN_LMC
    {
        public static TList_LMC Buscar(string Cd_empresa,
                                       string Cd_produto,
                                       string Id_lmc,
                                       string Dt_ini,
                                       string Dt_fin,
                                       string St_registro,
                                       BancoDados.TObjetoBanco banco)
        {
            TpBusca[] filtro = new TpBusca[0];
            if (!string.IsNullOrEmpty(Cd_empresa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Cd_produto))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = string.Empty;
                filtro[filtro.Length - 1].vOperador = "exists";
                filtro[filtro.Length - 1].vVL_Busca = "(select 1 from tb_pdc_movlmc x " +
                                                      "where x.cd_empresa = a.cd_empresa " +
                                                      "and x.id_lmc = a.id_lmc " +
                                                      "and x.cd_produto = '" + Cd_produto.Trim() + "')";
            }
            if (!string.IsNullOrEmpty(Id_lmc))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_lmc";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_lmc;
            }
            if (!string.IsNullOrEmpty(Dt_ini.SoNumero()))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.dt_emissao)))";
                filtro[filtro.Length - 1].vOperador = ">=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + DateTime.Parse(Dt_ini).ToString("yyyyMMdd") + "'";
            }
            if (!string.IsNullOrEmpty(Dt_fin.SoNumero()))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.dt_emissao)))";
                filtro[filtro.Length - 1].vOperador = "<=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + DateTime.Parse(Dt_fin).ToString("yyyyMMdd") + "'";
            }
            if (!string.IsNullOrEmpty(St_registro))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "isnull(a.st_registro, '0')";
                filtro[filtro.Length - 1].vOperador = "in";
                filtro[filtro.Length - 1].vVL_Busca = "(" + St_registro.Trim() + ")";
            }

            return new TCD_LMC(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_LMC val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_LMC qtb_lmc = new TCD_LMC();
            try
            {
                if (banco == null)
                    st_transacao = qtb_lmc.CriarBanco_Dados(true);
                else qtb_lmc.Banco_Dados = banco;
                val.Id_lmcstr = CamadaDados.TDataQuery.getPubVariavel(qtb_lmc.Gravar(val), "@P_ID_LMC");
                //Gravar Movimento
                val.lMov.ForEach(p =>
                    {
                        p.Cd_empresa = val.Cd_empresa;
                        p.Id_lmc = val.Id_lmc;
                        TCN_MovLMC.Gravar(p, qtb_lmc.Banco_Dados);
                    });
                if (st_transacao)
                    qtb_lmc.Banco_Dados.Commit_Tran();
                return val.Id_lmcstr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_lmc.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar LMC: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_lmc.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_LMC val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_LMC qtb_lmc = new TCD_LMC();
            try
            {
                if (banco == null)
                    st_transacao = qtb_lmc.CriarBanco_Dados(true);
                else qtb_lmc.Banco_Dados = banco;
                //Excluir Movimento
                val.lMov.ForEach(p => TCN_MovLMC.Excluir(p, qtb_lmc.Banco_Dados));
                //Excluir LMC
                qtb_lmc.Excluir(val);
                if (st_transacao)
                    qtb_lmc.Banco_Dados.Commit_Tran();
                return val.Id_lmcstr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_lmc.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir LMC: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_lmc.deletarBanco_Dados();
            }
        }

        public static string GerarChaveLMC(TRegistro_LMC val)
        {
            return val.Dt_emissao.Value.ToString("yyyyMMdd") +
                    val.Cnpj_empresa.SoNumero() +
                    val.Id_lmc.Value.ToString().FormatStringEsquerda(5, '0') +
                    Utils.Estruturas.Mod11(val.Dt_emissao.Value.ToString("yyyyMMdd") +
                                            val.Cnpj_empresa.SoNumero() +
                                            val.Id_lmc.Value.ToString().FormatStringEsquerda(5, '0'), 9, false, 0);
        }
    }

    public class TCN_MovLMC
    {
        public static TList_MovLMC Buscar(string Cd_empresa,
                                          string Id_lmc,
                                          string Cd_produto,
                                          BancoDados.TObjetoBanco banco)
        {
            TpBusca[] filtro = new TpBusca[0];
            if (!string.IsNullOrEmpty(Cd_empresa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Id_lmc))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_lmc";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_lmc;
            }
            if (!string.IsNullOrEmpty(Cd_produto))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_produto";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_produto.Trim() + "'";
            }
            return new TCD_MovLMC(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_MovLMC val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_MovLMC qtb_mov = new TCD_MovLMC();
            try
            {
                if (banco == null)
                    st_transacao = qtb_mov.CriarBanco_Dados(true);
                else qtb_mov.Banco_Dados = banco;
                val.Id_movtostr = CamadaDados.TDataQuery.getPubVariavel(qtb_mov.Gravar(val), "@P_ID_MOVTO");
                //Gravar Rec
                val.lRec.ForEach(p =>
                    {
                        p.Cd_empresa = val.Cd_empresa;
                        p.Id_lmc = val.Id_lmc;
                        p.Id_movto = val.Id_movto;
                        TCN_MovRec.Gravar(p, qtb_mov.Banco_Dados);
                    });
                //Gravar Vendas 
                val.lVend.ForEach(p =>
                    {
                        p.Cd_empresa = val.Cd_empresa;
                        p.Id_lmc = val.Id_lmc;
                        p.Id_movto = val.Id_movto;
                        TCN_MovVend.Gravar(p, qtb_mov.Banco_Dados);
                    });
                if (st_transacao)
                    qtb_mov.Banco_Dados.Commit_Tran();
                return val.Id_movtostr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_mov.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar movimento: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_mov.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_MovLMC val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_MovLMC qtb_mov = new TCD_MovLMC();
            try
            {
                if (banco == null)
                    st_transacao = qtb_mov.CriarBanco_Dados(true);
                else qtb_mov.Banco_Dados = banco;
                //Excluir Vendas
                val.lVend.ForEach(p => TCN_MovVend.Excluir(p, qtb_mov.Banco_Dados));
                //Excluir Rec
                val.lRec.ForEach(p => TCN_MovRec.Excluir(p, qtb_mov.Banco_Dados));
                qtb_mov.Excluir(val);
                if (st_transacao)
                    qtb_mov.Banco_Dados.Commit_Tran();
                return val.Id_movtostr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_mov.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir movimento: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_mov.deletarBanco_Dados();
            }
        }
    }

    public class TCN_MovRec
    {
        public static TList_MovRec Buscar(string Cd_empresa,
                                          string Id_lmc,
                                          string Id_movto,
                                          BancoDados.TObjetoBanco banco)
        {
            TpBusca[] filtro = new TpBusca[0];
            if (!string.IsNullOrEmpty(Cd_empresa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Id_lmc))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_lmc";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_lmc;
            }
            if (!string.IsNullOrEmpty(Id_movto))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_movto";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_movto;
            }
            return new TCD_MovRec(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_MovRec val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_MovRec qtb_mov = new TCD_MovRec();
            try
            {
                if (banco == null)
                    st_transacao = qtb_mov.CriarBanco_Dados(true);
                else qtb_mov.Banco_Dados = banco;
                qtb_mov.Gravar(val);
                if (st_transacao)
                    qtb_mov.Banco_Dados.Commit_Tran();
                return val.Id_lmcstr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_mov.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar Recebimento: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_mov.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_MovRec val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_MovRec qtb_mov = new TCD_MovRec();
            try
            {
                if (banco == null)
                    st_transacao = qtb_mov.CriarBanco_Dados(true);
                else qtb_mov.Banco_Dados = banco;
                qtb_mov.Excluir(val);
                if (st_transacao)
                    qtb_mov.Banco_Dados.Commit_Tran();
                return val.Id_lmcstr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_mov.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir Recebimento: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_mov.deletarBanco_Dados();
            }
        }
    }

    public class TCN_MovVend
    {
        public static TList_MovVend Buscar(string Cd_empresa,
                                          string Id_lmc,
                                          string Id_movto,
                                          BancoDados.TObjetoBanco banco)
        {
            TpBusca[] filtro = new TpBusca[0];
            if (!string.IsNullOrEmpty(Cd_empresa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Id_lmc))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_lmc";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_lmc;
            }
            if (!string.IsNullOrEmpty(Id_movto))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_movto";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_movto;
            }
            return new TCD_MovVend(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_MovVend val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_MovVend qtb_mov = new TCD_MovVend();
            try
            {
                if (banco == null)
                    st_transacao = qtb_mov.CriarBanco_Dados(true);
                else qtb_mov.Banco_Dados = banco;
                qtb_mov.Gravar(val);
                if (st_transacao)
                    qtb_mov.Banco_Dados.Commit_Tran();
                return val.Id_lmcstr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_mov.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar Venda: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_mov.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_MovVend val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_MovVend qtb_mov = new TCD_MovVend();
            try
            {
                if (banco == null)
                    st_transacao = qtb_mov.CriarBanco_Dados(true);
                else qtb_mov.Banco_Dados = banco;
                qtb_mov.Excluir(val);
                if (st_transacao)
                    qtb_mov.Banco_Dados.Commit_Tran();
                return val.Id_lmcstr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_mov.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir Venda: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_mov.deletarBanco_Dados();
            }
        }
    }
}
