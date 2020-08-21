using System;
using System.Collections.Generic;
using System.Text;
using Utils;
using BancoDados;
using CamadaDados;
using CamadaDados.Fiscal;

namespace CamadaNegocio.Fiscal
{
    public class TCN_LanFiscal
    {
        public static TList_RegLanFiscal Busca(string vCD_Empresa,
                                        string vNR_LanctoFiscal,
                                        string vNR_LanctoMovto,
                                        string vCD_CFOP,
                                        string vSG_UF,
                                        string vNR_DoctoFiscal,
                                        string vTP_Movimento,
                                        string vNR_Serie,
                                        Int32 vTop,
                                        string vNM_Campo)
        {
            TpBusca[] vBusca = new TpBusca[0];
            if (!(vCD_CFOP.Trim().Equals("")))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "b.CD_Empresa";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vCD_Empresa + "'";
                vBusca[vBusca.Length - 1].vOperador = "=";
            }
            if (!(vNR_LanctoFiscal.Trim().Equals("")))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.NR_LanctoFiscal";
                vBusca[vBusca.Length - 1].vVL_Busca = vNR_LanctoFiscal;
                vBusca[vBusca.Length - 1].vOperador = "=";
            }
            if (!(vNR_LanctoMovto.Trim().Equals("")))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "b.NR_LanctoMovto";
                vBusca[vBusca.Length - 1].vVL_Busca = vNR_LanctoMovto;
                vBusca[vBusca.Length - 1].vOperador = "=";
            }
            if (!(vCD_CFOP.Trim().Equals("")))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "b.CD_CFOP";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vCD_CFOP + "'";
                vBusca[vBusca.Length - 1].vOperador = "=";
            }
            if (!(vSG_UF.Trim().Equals("")))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "b.SG_UF";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vSG_UF + "'";
                vBusca[vBusca.Length - 1].vOperador = "=";
            }
            if (!(vNR_DoctoFiscal.Trim().Equals("")))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "b.NR_DoctoFiscal";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vNR_DoctoFiscal + "'";
                vBusca[vBusca.Length - 1].vOperador = "=";
            }
            if (!(vTP_Movimento.Trim().Equals("")))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "b.TP_Movimento";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vTP_Movimento + "'";
                vBusca[vBusca.Length - 1].vOperador = "=";
            }
            if (!(vNR_Serie.Trim().Equals("")))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "b.NR_Serie";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vNR_Serie + "'";
                vBusca[vBusca.Length - 1].vOperador = "=";
            }
            //TCD_LanFiscal qtb_fiscal = new TCD_LanFiscal();
            //return qtb_fiscal.Select(vBusca, 0, "");
            return TCN_LanFiscal.Busca(vBusca, 0, "");
        }

        public static TList_RegLanFiscal Busca(TpBusca[] vBusca, int vTop, string vNM_campo)
        {
            TCD_LanFiscal qtb_fiscal = new TCD_LanFiscal();
            return qtb_fiscal.Select(vBusca, vTop, vNM_campo);
        }

        public static string GravarFiscal(TRegistro_LanFiscal val, TObjetoBanco banco)
        {
            if(val.Cd_empresa.Trim().Equals(""))
                throw new Exception("Campo Obrigatorio !\r\n" +
                                    "Campo: CD_Empresa\r\n" +
                                    "Método: GravarFiscal\r\n" +
                                    "Classe: TCN_LanFiscal");
            if(val.Nr_lanctofiscal < 1)
                throw new Exception("Campo Obrigatorio !\r\n" +
                                    "Campo: NR_LanctoFiscal\r\n" +
                                    "Método: GravarFiscal\r\n" +
                                    "Classe: TCN_LanFiscal");
            bool pode_liberar = false;
            TCD_LanFiscal qtb_fiscal = new TCD_LanFiscal();
            try
            {
                if (banco == null)
                    pode_liberar = qtb_fiscal.CriarBanco_Dados(true);
                else
                    qtb_fiscal.Banco_Dados = banco;
                string retorno = qtb_fiscal.GravaFiscal(val);
                if (pode_liberar)
                    qtb_fiscal.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch(Exception ex)
            {
                if (pode_liberar)
                    qtb_fiscal.Banco_Dados.RollBack_Tran();
                throw new Exception("ERRO: Erro gravar Fiscal: " + ex.Message.Trim());
            }
            finally
            {
                if (pode_liberar)
                    qtb_fiscal.deletarBanco_Dados();
            }
        }
                
        public static string DeletarFiscal(TRegistro_LanFiscal val, TObjetoBanco banco)
        {
            if (val.Cd_empresa.Trim().Equals(""))
                throw new Exception("Campo Obrigatorio !\r\n" +
                                    "Campo: CD_Empresa\r\n" +
                                    "Método: DeletarFiscal\r\n" +
                                    "Classe: TCN_LanFiscal");
            if (val.Nr_lanctofiscal < 1)
                throw new Exception("Campo Obrigatorio !\r\n" +
                                    "Campo: NR_LanctoFiscal\r\n" +
                                    "Método: DeletarFiscal\r\n" +
                                    "Classe: TCN_LanFiscal");
            bool pode_liberar = false;
            TCD_LanFiscal qtb_fiscal = new TCD_LanFiscal();
            try
            {
                if (banco == null)
                    pode_liberar = qtb_fiscal.CriarBanco_Dados(true);
                else
                    qtb_fiscal.Banco_Dados = banco;
                string retorno = qtb_fiscal.DeletaFiscal(val);
                if (pode_liberar)
                    qtb_fiscal.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (pode_liberar)
                    qtb_fiscal.Banco_Dados.RollBack_Tran();
                throw new Exception("ERRO: Erro deletar Fiscal: " + ex.Message.Trim());
            }
            finally
            {
                if (pode_liberar)
                    qtb_fiscal.deletarBanco_Dados();
            }
        }
    }
}
