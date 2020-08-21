using System;
using Utils;
using CamadaDados.Faturamento.NFE;

namespace CamadaNegocio.Faturamento.NFE
{
    public class TCN_ConsultaDest
    {
        public static TList_ConsultaDest Buscar(string Cd_empresa,
                                                string Id_consulta,
                                                string Chave_acesso,
                                                string Emitente,
                                                string Dt_ini,
                                                string Dt_fin,
                                                bool St_nfe,
                                                string TpXMLBaixado,
                                                string TpXMLImportado,
                                                string TpOpConfirmada,
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
            if (!string.IsNullOrEmpty(Id_consulta))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_consulta";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_consulta;
            }
            if (!string.IsNullOrEmpty(Chave_acesso))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.chave_acesso";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Chave_acesso.Trim() + "'";
            }
            if(!string.IsNullOrEmpty(Emitente))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.nm_emitente";
                filtro[filtro.Length - 1].vOperador = "like";
                filtro[filtro.Length - 1].vVL_Busca = "'%" + Emitente.Trim() + "%'";
            }
            if (!string.IsNullOrEmpty(Dt_ini.SoNumero()))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.dt_consulta)))";
                filtro[filtro.Length - 1].vOperador = ">=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + DateTime.Parse(Dt_ini).ToString("yyyyMMdd") + "'";
            }
            if (!string.IsNullOrEmpty(Dt_fin.SoNumero()))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.dt_consulta)))";
                filtro[filtro.Length - 1].vOperador = "<=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + DateTime.Parse(Dt_fin).ToString("yyyyMMdd") + "'";
            }
            if(St_nfe)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "isnull(a.st_nfe, '')";
                filtro[filtro.Length - 1].vOperador = "<>";
                filtro[filtro.Length - 1].vVL_Busca = "''";
            }
            if(!string.IsNullOrWhiteSpace(TpXMLBaixado))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.xml_nfe";
                filtro[filtro.Length - 1].vOperador = TpXMLBaixado.Trim().ToUpper().Equals("S") ? "is not" : "is";
                filtro[filtro.Length - 1].vVL_Busca = "null";
            }
            if (!string.IsNullOrWhiteSpace(TpXMLImportado))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "isnull(c.nr_lanctofiscal, 0)";
                filtro[filtro.Length - 1].vOperador = TpXMLImportado.Trim().ToUpper().Equals("S") ? "<>" : "=";
                filtro[filtro.Length - 1].vVL_Busca = "0";
            }
            if(!string.IsNullOrWhiteSpace(TpOpConfirmada))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = string.Empty;
                filtro[filtro.Length - 1].vOperador = TpOpConfirmada.Trim().ToUpper().Equals("S") ? "exists" : "not exists";
                filtro[filtro.Length - 1].vVL_Busca = "(select 1 from tb_fat_eventonfe x " +
                                                      "where x.cd_empresa = a.cd_empresa " +
                                                      "and x.chave_acesso = a.chave_acesso " +
                                                      "and x.cd_evento = '210200')";
            }
            return new TCD_ConsultaDest(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_ConsultaDest val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_ConsultaDest qtb_con = new TCD_ConsultaDest();
            try
            {
                if (banco == null)
                    st_transacao = qtb_con.CriarBanco_Dados(true);
                else qtb_con.Banco_Dados = banco;
                val.Id_consultastr = CamadaDados.TDataQuery.getPubVariavel(qtb_con.Gravar(val), "@P_ID_CONSULTA");
                if (st_transacao)
                    qtb_con.Banco_Dados.Commit_Tran();
                return val.Id_consultastr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_con.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar consulta: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_con.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_ConsultaDest val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_ConsultaDest qtb_con = new TCD_ConsultaDest();
            try
            {
                if (banco == null)
                    st_transacao = qtb_con.CriarBanco_Dados(true);
                else qtb_con.Banco_Dados = banco;
                qtb_con.Excluir(val);
                if (st_transacao)
                    qtb_con.Banco_Dados.Commit_Tran();
                return val.Id_consultastr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_con.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir consulta: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_con.deletarBanco_Dados();
            }
        }
    }
}