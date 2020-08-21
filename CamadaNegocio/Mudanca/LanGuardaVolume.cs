using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Mudanca;
using Utils;

namespace CamadaNegocio.Mudanca
{
    public class TCN_GuardaVolume
    {
        public static TList_GuardaVolume Buscar(string Cd_empresa,
                                           string ID_GuardaVol,
                                           string Cd_clifor,
                                           string ID_Mudanca,
                                           string NR_GuardaVol,
                                           string vTp_data,
                                           string vDt_ini,
                                           string vDt_fin,
                                           string St_registro,
                                           BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (!string.IsNullOrEmpty(Cd_empresa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.Cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(ID_GuardaVol))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.ID_GuardaVol";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = ID_GuardaVol;
            }
            if (!string.IsNullOrEmpty(Cd_clifor))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.Cd_clifor";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_clifor.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(ID_Mudanca))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.ID_Mudanca";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = ID_Mudanca;
            }
            if (!string.IsNullOrEmpty(NR_GuardaVol))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.NR_GuardaVol";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + NR_GuardaVol.Trim() + "'";
            }
            if ((!string.IsNullOrEmpty(vDt_ini)) && (vDt_ini.Trim() != "/  /"))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), " +
                    (vTp_data.Trim().ToUpper().Equals("R") ? "a.DT_Registro" : vTp_data.Trim().ToUpper().Equals("P") ? "a.DT_PrevRetirada" : "a.dt_saient") + ")))";
                filtro[filtro.Length - 1].vVL_Busca = "'" + DateTime.Parse(vDt_ini).ToString("yyyyMMdd") + "'";
                filtro[filtro.Length - 1].vOperador = ">=";
            }
            if ((!string.IsNullOrEmpty(vDt_fin)) && (vDt_fin.Trim() != "/  /"))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), " +
                    (vTp_data.Trim().ToUpper().Equals("R") ? "a.DT_Registro" : vTp_data.Trim().ToUpper().Equals("P") ? "a.DT_PrevRetirada" : "a.dt_saient") + ")))";
                filtro[filtro.Length - 1].vVL_Busca = "'" + DateTime.Parse(vDt_fin).ToString("yyyyMMdd") + "'";
                filtro[filtro.Length - 1].vOperador = "<=";
            }
            if (!string.IsNullOrEmpty(St_registro))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.st_registro";
                filtro[filtro.Length - 1].vOperador = "in";
                filtro[filtro.Length - 1].vVL_Busca = "(" + St_registro.Trim() + ")";
            }

            return new TCD_GuardaVolume(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_GuardaVolume val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_GuardaVolume qtb_vol = new TCD_GuardaVolume();
            try
            {
                if (banco == null)
                    st_transacao = qtb_vol.CriarBanco_Dados(true);
                else
                    qtb_vol.Banco_Dados = banco;
                val.Id_guardavolstr = CamadaDados.TDataQuery.getPubVariavel(qtb_vol.Gravar(val), "@P_ID_GUARDAVOL");
                //Excluir Itens
                val.lItensGuardaVolumeDel.ForEach(p => TCN_ItensGuardaVolume.Excluir(p, qtb_vol.Banco_Dados));
                //Gravar Itens
                val.lItensGuardaVolume.ForEach(p =>
                    {
                        p.Cd_empresa = val.Cd_empresa;
                        p.Id_guardavolstr = val.Id_guardavolstr;
                        TCN_ItensGuardaVolume.Gravar(p, qtb_vol.Banco_Dados);
                    });
                if (st_transacao)
                    qtb_vol.Banco_Dados.Commit_Tran();
                return val.Id_mudancastr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_vol.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar guarda volume: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_vol.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_GuardaVolume val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_GuardaVolume qtb_vol = new TCD_GuardaVolume();
            try
            {
                if (banco == null)
                    st_transacao = qtb_vol.CriarBanco_Dados(true);
                else
                    qtb_vol.Banco_Dados = banco;
                try
                {
                    //Excluir
                    qtb_vol.Excluir(val);
                }
                catch
                {
                    //Cancelar
                    val.St_registro = "C";
                    qtb_vol.Gravar(val);
                }
                if (st_transacao)
                    qtb_vol.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_vol.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir guarda volume: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_vol.deletarBanco_Dados();
            }
        }

        public static string RetirarItens(TRegistro_GuardaVolume val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_GuardaVolume qtb_vol = new TCD_GuardaVolume();
            try
            {
                if (banco == null)
                    st_transacao = qtb_vol.CriarBanco_Dados(true);
                else
                    qtb_vol.Banco_Dados = banco;
                //Excluir Retirada
                val.lRetGuardaVolDel.ForEach(p => TCN_RetGuardaVol.Excluir(p, qtb_vol.Banco_Dados));
                //Gravar Retirada
                val.lRetGuardaVol.ForEach(p =>
                {
                    p.Cd_empresa = val.Cd_empresa;
                    p.Id_guardavolstr = val.Id_guardavolstr;
                    TCN_RetGuardaVol.Gravar(p, qtb_vol.Banco_Dados);
                });
                //Verificar se guarda volume tem saldo a retirar finalizado.
                if (new CamadaDados.Mudanca.TCD_GuardaVolume(qtb_vol.Banco_Dados).BuscarEscalar(
                        new TpBusca[]
                        {
                            new TpBusca()
                            {
                                vNM_Campo = "a.cd_empresa",
                                vOperador = "=",
                                vVL_Busca = "'" + val.Cd_empresa.Trim() + "'"
                            },
                            new TpBusca()
                            {
                                vNM_Campo = "a.id_guardavol",
                                vOperador = "=",
                                vVL_Busca = val.Id_guardavolstr
                            },
                            new TpBusca()
                            {
                                vNM_Campo = string.Empty,
                                vOperador = "not exists",
                                vVL_Busca = "(select 1 from VTB_MUD_ITENSGUARDAVOLUME x " +
                                            "where x.cd_empresa = a.cd_empresa " +
                                            "and x.id_guardavol = a.id_guardavol " +
                                            "and isnull(x.quantidade - x.qtd_retirada, 0) > 0 " +
                                            "and isnull(x.st_registro, 'A') <> 'C' )"
                            }
                        }, "1") != null)
                {
                    val.St_registro = "F";
                    qtb_vol.Gravar(val);
                }
                if (st_transacao)
                    qtb_vol.Banco_Dados.Commit_Tran();
                return val.Id_mudancastr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_vol.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro Retirar guarda volume: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_vol.deletarBanco_Dados();
            }
        }
    }

    public class TCN_ItensGuardaVolume
    {
        public static TList_ItensGuardaVolume Buscar(string Cd_empresa,
                                                     string ID_GuardaVol,
                                                     string ID_ItemGuardaVol,
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
            if (!string.IsNullOrEmpty(ID_GuardaVol))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.ID_GuardaVol";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = ID_GuardaVol;
            }
            if (!string.IsNullOrEmpty(ID_ItemGuardaVol))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.ID_ItemGuardaVol";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = ID_ItemGuardaVol;
            }
            return new TCD_ItensGuardaVolume(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_ItensGuardaVolume val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_ItensGuardaVolume qtb_itens = new TCD_ItensGuardaVolume();
            try
            {
                if (banco == null)
                    st_transacao = qtb_itens.CriarBanco_Dados(true);
                else qtb_itens.Banco_Dados = banco;
                val.Id_itemguardavolstr = CamadaDados.TDataQuery.getPubVariavel(qtb_itens.Gravar(val), "@P_ID_ITEMGUARDAVOL");
                if (st_transacao)
                    qtb_itens.Banco_Dados.Commit_Tran();
                return val.Id_itemguardavolstr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_itens.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar item: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_itens.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_ItensGuardaVolume val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_ItensGuardaVolume qtb_itens = new TCD_ItensGuardaVolume();
            try
            {
                if (banco == null)
                    st_transacao = qtb_itens.CriarBanco_Dados(true);
                else qtb_itens.Banco_Dados = banco;
                qtb_itens.Excluir(val);
                if (st_transacao)
                    qtb_itens.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_itens.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir item: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_itens.deletarBanco_Dados();
            }
        }
    }

    public class TCN_RetGuardaVol
    {
        public static TList_RetGuardaVol Buscar(string Cd_empresa,
                                                  string ID_GuardaVol,
                                                  string ID_ItemGuardaVol,
                                                  string ID_Retirada,
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
            if (!string.IsNullOrEmpty(ID_GuardaVol))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.ID_GuardaVol";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = ID_GuardaVol;
            }
            if (!string.IsNullOrEmpty(ID_ItemGuardaVol))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.ID_ItemGuardaVol";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = ID_ItemGuardaVol;
            }
            if (!string.IsNullOrEmpty(ID_Retirada))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.ID_Retirada";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = ID_Retirada;
            }
            return new TCD_RetGuardaVol(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_RetGuardaVol val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_RetGuardaVol qtb_ret = new TCD_RetGuardaVol();
            try
            {
                if (banco == null)
                    st_transacao = qtb_ret.CriarBanco_Dados(true);
                else qtb_ret.Banco_Dados = banco;
                val.Id_retiradastr = CamadaDados.TDataQuery.getPubVariavel(qtb_ret.Gravar(val), "@P_ID_RETIRADA");
                if (st_transacao)
                    qtb_ret.Banco_Dados.Commit_Tran();
                return val.Id_retiradastr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_ret.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar retirada: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_ret.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_RetGuardaVol val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_RetGuardaVol qtb_ret = new TCD_RetGuardaVol();
            try
            {
                if (banco == null)
                    st_transacao = qtb_ret.CriarBanco_Dados(true);
                else qtb_ret.Banco_Dados = banco;
                val.LoginCanc = Utils.Parametros.pubLogin;
                qtb_ret.Excluir(val);
                if (st_transacao)
                    qtb_ret.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_ret.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir retirada: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_ret.deletarBanco_Dados();
            }
        }
    }
}
