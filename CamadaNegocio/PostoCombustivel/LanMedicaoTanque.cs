using System;
using CamadaDados.PostoCombustivel;

namespace CamadaNegocio.PostoCombustivel
{
    public class TCN_MedicaoTanque
    {
        public static TList_MedicaoTanque Buscar(string Id_medicao,
                                                 string Id_tanque,
                                                 string Cd_empresa,
                                                 string Cd_funcionario,
                                                 string Dt_ini,
                                                 string Dt_fin,
                                                 BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (!string.IsNullOrEmpty(Id_medicao))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_medicao";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_medicao;
            }
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
            if (!string.IsNullOrEmpty(Cd_funcionario))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.funcionario";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_funcionario.Trim() + "'";
            }
            if ((!string.IsNullOrEmpty(Dt_ini)) && (Dt_ini.Trim() != "/  /"))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.dt_medicao";
                filtro[filtro.Length - 1].vOperador = ">=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + string.Format(new System.Globalization.CultureInfo("en-US", true), Convert.ToDateTime(Dt_ini).ToString("yyyyMMdd")) + " 00:00:00'";
            }
            if ((!string.IsNullOrEmpty(Dt_fin)) && (Dt_fin.Trim() != "/  /"))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.dt_medicao";
                filtro[filtro.Length - 1].vOperador = "<=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + string.Format(new System.Globalization.CultureInfo("en-US", true), Convert.ToDateTime(Dt_fin).ToString("yyyyMMdd")) + " 23:59:59'";
            }

            return new TCD_MedicaoTanque(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_MedicaoTanque val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_MedicaoTanque qtb_med = new TCD_MedicaoTanque();
            try
            {
                if(banco == null)
                    st_transacao = qtb_med.CriarBanco_Dados(true);
                else
                    qtb_med.Banco_Dados = banco;
                if (val.rEstoque != null)
                {
                    Estoque.TCN_LanEstoque.GravarEstoque(val.rEstoque, qtb_med.Banco_Dados);
                    val.Id_lanctoestoque = val.rEstoque.Id_lanctoestoque;
                    val.Cd_combustivel = val.rEstoque.Cd_produto;
                }
                val.Id_medicaostr = CamadaDados.TDataQuery.getPubVariavel(qtb_med.Gravar(val), "@P_ID_MEDICAO");
                if(st_transacao)
                    qtb_med.Banco_Dados.Commit_Tran();
                return val.Id_medicaostr;
            }
            catch(Exception ex)
            {
                if(st_transacao)
                    qtb_med.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar medição: "+ ex.Message.Trim());
            }
            finally
            {
                if(st_transacao)
                    qtb_med.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_MedicaoTanque val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_MedicaoTanque qtb_med = new TCD_MedicaoTanque();
            try
            {
                if (banco == null)
                    st_transacao = qtb_med.CriarBanco_Dados(true);
                else
                    qtb_med.Banco_Dados = banco;
                qtb_med.Excluir(val);
                if (st_transacao)
                    qtb_med.Banco_Dados.Commit_Tran();
                return val.Id_medicaostr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_med.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir medição: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_med.deletarBanco_Dados();
            }
        }
    }
}
