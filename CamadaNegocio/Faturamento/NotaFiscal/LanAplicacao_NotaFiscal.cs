using System;
using System.Collections.Generic;
using System.Text;
using Utils;
using BancoDados;
using CamadaDados.Balanca;
using CamadaDados.Faturamento.NotaFiscal;

namespace CamadaNegocio.Faturamento.NotaFiscal
{
    public class TCN_LanAplicacao_NotaFiscal
    {
        public static TList_RegLanAplicacao_NotaFiscal Buscar(string vCD_Empresa,
                                                              string vNR_LanctoFiscal,
                                                              string vID_NFItem,
                                                              string vID_Aplicacao,
                                                              bool vST_PossuiNFs,
                                                              TObjetoBanco banco)
        {
            TpBusca[] vBusca = new TpBusca[0];
            if (vCD_Empresa.Trim() != string.Empty)
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "CD_Empresa";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vCD_Empresa + "'";
                vBusca[vBusca.Length - 1].vOperador = "=";
            }
            if (vNR_LanctoFiscal.Trim() != string.Empty)
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "NR_LanctoFiscal";
                vBusca[vBusca.Length - 1].vVL_Busca = vNR_LanctoFiscal;
                vBusca[vBusca.Length - 1].vOperador = "=";
            }
            if (vID_NFItem.Trim() != string.Empty)
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "ID_NFItem";
                vBusca[vBusca.Length - 1].vVL_Busca = vID_NFItem;
                vBusca[vBusca.Length - 1].vOperador = "=";
            }
            if (vID_Aplicacao.Trim() != string.Empty)
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "ID_Aplicacao";
                vBusca[vBusca.Length - 1].vVL_Busca = vID_Aplicacao;
                vBusca[vBusca.Length - 1].vOperador = "=";
            }
            if (vST_PossuiNFs)
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "";
                vBusca[vBusca.Length - 1].vVL_Busca = "(Select 1 From TB_FAT_NotaFiscal nf " +
                                                      "Where nf.CD_Empresa = TB_FAT_Aplicacao_X_NotaFiscal.CD_Empresa " +
                                                      "and nf.NR_LanctoFiscal = TB_FAT_Aplicacao_X_NotaFiscal.NR_LanctoFiscal " +
                                                      "and isNull(nf.ST_Registro, 'A') <> 'C')";
                vBusca[vBusca.Length - 1].vOperador = "EXISTS";
            }

            TCD_LanAplicacao_NotaFiscal cd = new TCD_LanAplicacao_NotaFiscal();
            cd.Banco_Dados = banco;
            return  cd.Select(vBusca, 0, "");
        }

        public static string GravarAplicacaoXNotaFiscal(TRegistro_LanAplicacao_NotaFiscal val, TObjetoBanco banco)
        {
            bool pode_liberar = false;
            TCD_LanAplicacao_NotaFiscal qtb_aplicnf = new TCD_LanAplicacao_NotaFiscal();
            try
            {
                if (banco == null)
                {
                    qtb_aplicnf.CriarBanco_Dados(true);
                    pode_liberar = true;
                }
                else
                    qtb_aplicnf.Banco_Dados = banco;
                string retorno = qtb_aplicnf.GravarAplicacaoXNotaFiscal(val);
                if (pode_liberar)
                    qtb_aplicnf.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch
            {
                if (pode_liberar)
                    qtb_aplicnf.Banco_Dados.RollBack_Tran();
                return "";
            }
            finally
            {
                if (pode_liberar)
                    qtb_aplicnf.deletarBanco_Dados();
            }
        }

        public static string DeletarAplicacaoXNotaFiscal(TRegistro_LanAplicacao_NotaFiscal val, TObjetoBanco banco)
        {
            bool pode_liberar = false;
            TCD_LanAplicacao_NotaFiscal qtb_aplicnf = new TCD_LanAplicacao_NotaFiscal();
            try
            {
                if (banco == null)
                {
                    qtb_aplicnf.CriarBanco_Dados(true);
                    pode_liberar = true;
                }
                else
                    qtb_aplicnf.Banco_Dados = banco;
                string retorno = qtb_aplicnf.DeletarAplicacaoXNotaFiscal(val);
                if (pode_liberar)
                    qtb_aplicnf.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch
            {
                if (pode_liberar)
                    qtb_aplicnf.Banco_Dados.RollBack_Tran();
                return "";
            }
            finally
            {
                if (pode_liberar)
                    qtb_aplicnf.deletarBanco_Dados();
            }
        }
    }
}
