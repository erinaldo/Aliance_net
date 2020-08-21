using System;
using System.Collections.Generic;
using Utils;
using System.Text;
using CamadaDados.Diversos;
using CamadaDados.Financeiro.Cadastros;
using CamadaNegocio.Financeiro.Cadastros;

namespace CamadaNegocio.Diversos
{
    public class TCN_CadEmpresa
    {
        public static TList_CadEmpresa Busca(string vCD_Empresa, 
                                             string vNM_Empresa, 
                                             string vST_Registro, 
                                             BancoDados.TObjetoBanco banco)
        {
            TpBusca[] vBusca = new TpBusca[0];
            if (!string.IsNullOrEmpty(vCD_Empresa))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.CD_EMPRESA";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vCD_Empresa.Trim() + "'";
                vBusca[vBusca.Length - 1].vOperador = "=";
            }

            if (!string.IsNullOrEmpty(vNM_Empresa))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.NM_EMPRESA";
                vBusca[vBusca.Length - 1].vVL_Busca = "('%" + vNM_Empresa.Trim() + "%')";
                vBusca[vBusca.Length - 1].vOperador = "like";
            }

            if (!string.IsNullOrEmpty(vST_Registro))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "isnull(a.ST_REGISTRO, 'A')";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vST_Registro.Trim() + "'";
                vBusca[vBusca.Length - 1].vOperador = "=";
            }

            return new TCD_CadEmpresa(banco).Select(vBusca, 0, string.Empty);
        }

        public static string Gravar(TRegistro_CadEmpresa val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CadEmpresa qtb_emp = new TCD_CadEmpresa();
            try
            {
                if (banco == null)
                    st_transacao = qtb_emp.CriarBanco_Dados(true);
                else
                    qtb_emp.Banco_Dados = banco;
                string retorno = qtb_emp.Gravar(val);
                val.lSociosDel.ForEach(p => TCN_SociosEmpresa.Excluir(p, qtb_emp.Banco_Dados));
                val.lSocios.ForEach(p =>
                    {
                        p.Cd_empresa = val.Cd_empresa;
                        TCN_SociosEmpresa.Gravar(p, qtb_emp.Banco_Dados);
                    });
                val.lInscDel.ForEach(p => TCN_InscSubstEmpresa.Excluir(p, qtb_emp.Banco_Dados));
                val.lInsc.ForEach(p =>
                    {
                        p.Cd_empresa = val.Cd_empresa;
                        TCN_InscSubstEmpresa.Gravar(p, qtb_emp.Banco_Dados);
                    });
                if (st_transacao)
                    qtb_emp.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_emp.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar empresa: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_emp.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_CadEmpresa val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CadEmpresa qtb_emp = new TCD_CadEmpresa();
            try
            {
                if (st_transacao)
                    st_transacao = qtb_emp.CriarBanco_Dados(true);
                else
                    qtb_emp.Banco_Dados = banco;
                val.lSocios.ForEach(p => TCN_SociosEmpresa.Excluir(p, qtb_emp.Banco_Dados));
                val.lSociosDel.ForEach(p => TCN_SociosEmpresa.Excluir(p, qtb_emp.Banco_Dados));
                val.lInsc.ForEach(p => TCN_InscSubstEmpresa.Excluir(p, qtb_emp.Banco_Dados));
                val.lInscDel.ForEach(p => TCN_InscSubstEmpresa.Excluir(p, qtb_emp.Banco_Dados));
                try
                {
                    qtb_emp.Excluir(val);
                }
                catch
                {
                    //Exclusao logica
                    val.St_registro = "C";
                    qtb_emp.Gravar(val);
                }
                if (st_transacao)
                    qtb_emp.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_emp.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir empresa: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_emp.deletarBanco_Dados();
            }
        }
    }

    public class TCN_SociosEmpresa
    {
        public static TList_SociosEmpresa Buscar(string Cd_empresa,
                                                 string Cd_clifor,
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
            if (!string.IsNullOrEmpty(Cd_clifor))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_clifor";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_clifor.Trim() + "'";
            }
            return new TCD_SociosEmpresa(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_SociosEmpresa val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_SociosEmpresa qtb_socios = new TCD_SociosEmpresa();
            try
            {
                if (banco == null)
                    st_transacao = qtb_socios.CriarBanco_Dados(true);
                else
                    qtb_socios.Banco_Dados = banco;
                string retorno = qtb_socios.Gravar(val);
                if (st_transacao)
                    qtb_socios.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_socios.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar socios: " + ex.Message.Trim());
            }
            finally
            {
                if(st_transacao)
                    qtb_socios.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_SociosEmpresa val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_SociosEmpresa qtb_socios = new TCD_SociosEmpresa();
            try
            {
                if (banco == null)
                    st_transacao = qtb_socios.CriarBanco_Dados(true);
                else
                    qtb_socios.Banco_Dados = banco;
                qtb_socios.Excluir(val);
                if (st_transacao)
                    qtb_socios.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_socios.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir socios: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_socios.deletarBanco_Dados();
            }
        }
    }

    public class TCN_InscSubstEmpresa
    {
        public static TList_InscSubstEmpresa Buscar(string Cd_empresa,
                                                    string Cd_uf,
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
            if (!string.IsNullOrEmpty(Cd_uf))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_uf";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_uf.Trim() + "'";
            }
            return new TCD_InscSubstEmpresa(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_InscSubstEmpresa val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_InscSubstEmpresa qtb_insc = new TCD_InscSubstEmpresa();
            try
            {
                if (banco == null)
                    st_transacao = qtb_insc.CriarBanco_Dados(true);
                else qtb_insc.Banco_Dados = banco;
                string retorno = qtb_insc.Gravar(val);
                if (st_transacao)
                    qtb_insc.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_insc.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_insc.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_InscSubstEmpresa val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_InscSubstEmpresa qtb_insc = new TCD_InscSubstEmpresa();
            try
            {
                if (banco == null)
                    st_transacao = qtb_insc.CriarBanco_Dados(true);
                else qtb_insc.Banco_Dados = banco;
                qtb_insc.Excluir(val);
                if (st_transacao)
                    qtb_insc.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_insc.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_insc.deletarBanco_Dados();
            }
        }
    }
}