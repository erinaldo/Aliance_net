using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;
using CamadaDados.Servicos;

namespace CamadaNegocio.Servicos
{
    public class TCN_Agendamento
    {
        public static TList_Agendamento Buscar(string Cd_empresa,
                                               string Id_agenda,
                                               string Cd_clifor,
                                               string Cd_tecnico,
                                               string Cd_servico,
                                               string Dt_ini,
                                               string Dt_fin,
                                               string Status,
                                               string vOrder,
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
            if (!string.IsNullOrEmpty(Id_agenda))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_agenda";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_agenda;
            }
            if (!string.IsNullOrEmpty(Cd_clifor))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_clifor";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_clifor.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Cd_tecnico))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_tecnico";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_tecnico.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Cd_servico))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_servico";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_servico.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Dt_ini.SoNumero()))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.dt_agendamento)))";
                filtro[filtro.Length - 1].vOperador = ">=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + DateTime.Parse(Dt_ini).ToString("yyyyMMdd") + "'";
            }
            if (!string.IsNullOrEmpty(Dt_fin.SoNumero()))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.dt_agendamento)))";
                filtro[filtro.Length - 1].vOperador = "<=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + DateTime.Parse(Dt_fin).ToString("yyyyMMdd") + "'";
            }
            if (!string.IsNullOrEmpty(Status))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "isnull(a.st_registro, 'A')";
                filtro[filtro.Length - 1].vOperador = "in";
                filtro[filtro.Length - 1].vVL_Busca = "(" + Status.Trim() + ")";
            }
            return new TCD_Agendamento(banco).Select(filtro, 0, string.Empty, vOrder);
        }

        public static string Gravar(TRegistro_Agendamento val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Agendamento qtb_agenda = new TCD_Agendamento();
            try
            {
                if (banco == null)
                    st_transacao = qtb_agenda.CriarBanco_Dados(true);
                else qtb_agenda.Banco_Dados = banco;
                val.Id_agendastr = CamadaDados.TDataQuery.getPubVariavel(qtb_agenda.Gravar(val), "@P_ID_AGENDA");
                if (st_transacao)
                    qtb_agenda.Banco_Dados.Commit_Tran();
                return val.Id_agendastr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_agenda.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar agendamento: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_agenda.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_Agendamento val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Agendamento qtb_agenda = new TCD_Agendamento();
            try
            {
                if (banco == null)
                    st_transacao = qtb_agenda.CriarBanco_Dados(true);
                else qtb_agenda.Banco_Dados = banco;
                qtb_agenda.Excluir(val);
                if (st_transacao)
                    qtb_agenda.Banco_Dados.Commit_Tran();
                return val.Id_agendastr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_agenda.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir agendamento: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_agenda.deletarBanco_Dados();
            }
        }

        public static void ExecutarServico(TRegistro_Agendamento val,
                                           CamadaDados.Servicos.TRegistro_LanServico rOs,
                                           BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Agendamento qtb_agenda = new TCD_Agendamento();
            try
            {
                if (banco == null)
                    st_transacao = qtb_agenda.CriarBanco_Dados(true);
                else qtb_agenda.Banco_Dados = banco;
                //Gravar OS
                CamadaNegocio.Servicos.TCN_LanServico.Gravar(rOs, qtb_agenda.Banco_Dados);
                //Alterar agendamento
                val.Id_os = rOs.Id_os;
                val.St_registro = "E";
                qtb_agenda.Gravar(val);
                if (st_transacao)
                    qtb_agenda.Banco_Dados.Commit_Tran();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_agenda.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro executar serviço: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_agenda.deletarBanco_Dados();
            }
        }
    }
}
