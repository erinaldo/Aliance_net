using CamadaDados.Faturamento.AgendaVendedor;
using System;
using System.Linq;
using Utils;

namespace CamadaNegocio.Faturamento.AgendaVendedor
{
    public class TCN_AgendaVendedor
    {
        public static TList_AgendaVendedor Buscar(string Cd_clifor,
                                                  string Login,
                                                  string Tp_data,
                                                  string Dt_ini,
                                                  string Dt_fin,
                                                  string St_registro,
                                                  BancoDados.TObjetoBanco banco)
        {
            TpBusca[] filtro = new TpBusca[0];
            Estruturas.CriarParametro(ref filtro, "a.cd_clifor", "'" + Cd_clifor.Trim() + "'");
            Estruturas.CriarParametro(ref filtro, "a.login", "'" + Login.Trim() + "'");
            Estruturas.CriarParametro(ref filtro, "convert(datetime, floor(convert(decimal(30,10), " + (Tp_data.Trim().ToUpper().Equals("C") ? "a.dt_contato" : "a.dt_agendamento") + ")))",
                                      string.IsNullOrEmpty(Dt_ini.SoNumero()) ? string.Empty : "'" + DateTime.Parse(Dt_ini).ToString("yyyyMMdd") + "'", ">=");
            Estruturas.CriarParametro(ref filtro, "convert(datetime, floor(convert(decimal(30,10), " + (Tp_data.Trim().ToUpper().Equals("C") ? "a.dt_contato" : "a.dt_agendamento") + ")))",
                                      string.IsNullOrEmpty(Dt_fin.SoNumero()) ? string.Empty : "'" + DateTime.Parse(Dt_fin).ToString("yyyyMMdd") + "'", "<=");
            Estruturas.CriarParametro(ref filtro, "isnull(a.st_registro, '0')", "(" + St_registro + ")", "in");
            return new TCD_AgendaVendedor(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_AgendaVendedor val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_AgendaVendedor qtb_crm = new TCD_AgendaVendedor();
            try
            {
                if (banco == null)
                    st_transacao = qtb_crm.CriarBanco_Dados(true);
                else qtb_crm.Banco_Dados = banco;
                val.Id_registrostr = CamadaDados.TDataQuery.getPubVariavel(qtb_crm.Gravar(val), "@P_ID_REGISTRO");
                if (st_transacao)
                    qtb_crm.Banco_Dados.Commit_Tran();
                return val.Id_registrostr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_crm.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_crm.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_AgendaVendedor val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_AgendaVendedor qtb_crm = new TCD_AgendaVendedor();
            try
            {
                if (banco == null)
                    st_transacao = qtb_crm.CriarBanco_Dados(true);
                else qtb_crm.Banco_Dados = banco;
                val.St_registro = "C";
                qtb_crm.Gravar(val);
                if (st_transacao)
                    qtb_crm.Banco_Dados.Commit_Tran();
                return val.Id_registrostr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_crm.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_crm.deletarBanco_Dados();
            }
        }
    }
}
