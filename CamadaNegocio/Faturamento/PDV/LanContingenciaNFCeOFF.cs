using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Faturamento.PDV;

namespace CamadaNegocio.Faturamento.PDV
{
    public class TCN_ContingenciaNFCeOFF
    {
        public static TList_ContingenciaNFCeOFF Buscar(string Cd_empresa,
                                                       string Id_pdv,
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
            if (!string.IsNullOrEmpty(Id_pdv))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_pdv";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_pdv;
            }
            if (!string.IsNullOrEmpty(St_registro))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "isnull(a.st_registro, 'A')";
                filtro[filtro.Length - 1].vOperador = "in";
                filtro[filtro.Length - 1].vVL_Busca = "(" + St_registro.Trim() + ")";
            }

            return new TCD_ContingenciaNFCeOFF(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_ContingenciaNFCeOFF val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_ContingenciaNFCeOFF qtb_cont = new TCD_ContingenciaNFCeOFF();
            try
            {
                if (banco == null)
                    st_transacao = qtb_cont.CriarBanco_Dados(true);
                else qtb_cont.Banco_Dados = banco;
                val.Id_contingenciastr = CamadaDados.TDataQuery.getPubVariavel(qtb_cont.Gravar(val), "@P_ID_CONTINGENCIA");
                if (st_transacao)
                    qtb_cont.Banco_Dados.Commit_Tran();
                return val.Id_contingenciastr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_cont.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_cont.deletarBanco_Dados();
            }
        }

        public static void Gravar(List<CamadaDados.Faturamento.Cadastros.TRegistro_PontoVenda> lPDV,
                                  string Cd_empresa,
                                  string Justificativa,
                                  BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_ContingenciaNFCeOFF qtb_cont = new TCD_ContingenciaNFCeOFF();
            try
            {
                if (banco == null)
                    st_transacao = qtb_cont.CriarBanco_Dados(true);
                else qtb_cont.Banco_Dados = banco;
                lPDV.ForEach(p => Gravar(new TRegistro_ContingenciaNFCeOFF()
                {
                    Cd_empresa = Cd_empresa,
                    Id_pdv = p.Id_pdv,
                    Login_E = Utils.Parametros.pubLogin,
                    Dt_entrada = CamadaDados.UtilData.Data_Servidor(),
                    Justificativa = Justificativa,
                    St_registro = "A"
                }, qtb_cont.Banco_Dados));
                if (st_transacao)
                    qtb_cont.Banco_Dados.Commit_Tran();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_cont.Banco_Dados.RollBack_Tran();
                throw new Exception(ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_cont.deletarBanco_Dados();
            }
        }

        public static void SairContingencia(List<CamadaDados.Faturamento.PDV.TRegistro_ContingenciaNFCeOFF> lCont,
                                            BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_ContingenciaNFCeOFF qtb_cont = new TCD_ContingenciaNFCeOFF();
            try
            {
                if (banco == null)
                    st_transacao = qtb_cont.CriarBanco_Dados(true);
                else qtb_cont.Banco_Dados = banco;
                lCont.ForEach(p =>
                    {
                        p.Login_S = Utils.Parametros.pubLogin;
                        p.Dt_saida = CamadaDados.UtilData.Data_Servidor();
                        p.St_registro = "F";
                        qtb_cont.Gravar(p);
                    });
                if (st_transacao)
                    qtb_cont.Banco_Dados.Commit_Tran();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_cont.Banco_Dados.RollBack_Tran();
                throw new Exception(ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_cont.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_ContingenciaNFCeOFF val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_ContingenciaNFCeOFF qtb_cont = new TCD_ContingenciaNFCeOFF();
            try
            {
                if (banco == null)
                    st_transacao = qtb_cont.CriarBanco_Dados(true);
                else qtb_cont.Banco_Dados = banco;
                qtb_cont.Excluir(val);
                if (st_transacao)
                    qtb_cont.Banco_Dados.Commit_Tran();
                return val.Id_contingenciastr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_cont.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_cont.deletarBanco_Dados();
            }
        }
    }
}
