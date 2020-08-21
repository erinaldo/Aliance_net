using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Faturamento.CTRC;

namespace CamadaNegocio.Faturamento.CTRC
{
    public class TCN_EventoCTe
    {
        public static TList_EventoCTe Buscar(string Cd_empresa,
                                             string Nr_lanctoctr,
                                             string Id_evento,
                                             string Cd_evento,
                                             string St_registro,
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
            if (!string.IsNullOrEmpty(Nr_lanctoctr))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.NR_LanctoCTR";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Nr_lanctoctr;
            }
            if (!string.IsNullOrEmpty(Id_evento))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_evento";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_evento;
            }
            if (!string.IsNullOrEmpty(Cd_evento))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_evento";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Cd_evento;
            }
            if (!string.IsNullOrEmpty(St_registro))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "isnull(a.st_registro, 'A')";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + St_registro.Trim() + "'";
            }
            return new TCD_EventoCTe(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_EventoCTe val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_EventoCTe qtb_evento = new TCD_EventoCTe();
            try
            {
                if (banco == null)
                    st_transacao = qtb_evento.CriarBanco_Dados(true);
                else
                    qtb_evento.Banco_Dados = banco;
                val.Id_eventostr = CamadaDados.TDataQuery.getPubVariavel(qtb_evento.Gravar(val), "@P_ID_EVENTO");
                //Gravar Campos se evento CC
                val.lCamposCC.ForEach(p =>
                    {
                        p.Cd_empresa = val.Cd_empresa;
                        p.Nr_lanctoCTR = val.Nr_lanctoctr;
                        p.Id_evento = val.Id_evento;
                        TCN_CamposCC.Gravar(p, qtb_evento.Banco_Dados);
                    });
                if (st_transacao)
                    qtb_evento.Banco_Dados.Commit_Tran();
                return val.Id_eventostr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_evento.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar evento: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_evento.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_EventoCTe val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_EventoCTe qtb_evento = new TCD_EventoCTe();
            try
            {
                if (banco == null)
                    st_transacao = qtb_evento.CriarBanco_Dados(true);
                else qtb_evento.Banco_Dados = banco;
                val.lCamposCC.ForEach(p => TCN_CamposCC.Excluir(p, qtb_evento.Banco_Dados));
                qtb_evento.Excluir(val);
                if (st_transacao)
                    qtb_evento.Banco_Dados.Commit_Tran();
                return val.Id_eventostr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_evento.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir evento: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_evento.deletarBanco_Dados();
            }
        }
    }

    public class TCN_CamposCC
    {
        public static TList_CamposCC Buscar(string Cd_empresa,
                                            string Nr_lanctoctr,
                                            string Id_evento,
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
            if (!string.IsNullOrEmpty(Nr_lanctoctr))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.NR_LanctoCTR";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Nr_lanctoctr;
            }
            if (!string.IsNullOrEmpty(Id_evento))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_evento";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_evento;
            }
            return new TCD_CamposCC(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_CamposCC val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CamposCC qtb_campo = new TCD_CamposCC();
            try
            {
                if (banco == null)
                    st_transacao = qtb_campo.CriarBanco_Dados(true);
                else qtb_campo.Banco_Dados = banco;
                val.Id_campo = decimal.Parse(CamadaDados.TDataQuery.getPubVariavel(qtb_campo.Gravar(val), "@P_ID_CAMPO"));
                if (st_transacao)
                    qtb_campo.Banco_Dados.Commit_Tran();
                return val.Id_campo.Value.ToString();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_campo.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_campo.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_CamposCC val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CamposCC qtb_campo = new TCD_CamposCC();
            try
            {
                if (banco == null)
                    st_transacao = qtb_campo.CriarBanco_Dados(true);
                else qtb_campo.Banco_Dados = banco;
                qtb_campo.Excluir(val);
                if (st_transacao)
                    qtb_campo.Banco_Dados.Commit_Tran();
                return val.Id_campo.Value.ToString();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_campo.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_campo.deletarBanco_Dados();
            }
        }
    }
}
