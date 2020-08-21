using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;
using CamadaDados.Financeiro.Cadastros;

namespace CamadaNegocio.Financeiro.Cadastros
{
    public class TCN_CadPortador
    {
        public static TList_CadPortador Buscar(string vCd_portador,
                                               string vDs_portador,
                                               decimal vQt_min_parc,
                                               decimal vQt_max_parc,
                                               bool vSt_controletitulo,
                                               bool vSt_tituloterceiro,
                                               string Tp_portadorPDV,
                                               int vTop,
                                               string vNm_campo,
                                               string vOrder,
                                               BancoDados.TObjetoBanco banco)
        {
            TpBusca[] filtro = new TpBusca[0];
            if (!string.IsNullOrEmpty(vCd_portador))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "cd_portador";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + vCd_portador.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(vDs_portador))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "ds_portador";
                filtro[filtro.Length - 1].vOperador = "like";
                filtro[filtro.Length - 1].vVL_Busca = "('%" + vDs_portador.Trim() + "%')";
            }
            if (vQt_min_parc > 0)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "qt_min_parc";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = vQt_min_parc.ToString();
            }
            if (vQt_max_parc > 0)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "qt_max_parc";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = vQt_max_parc.ToString();
            }
            if (vSt_controletitulo)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "st_controletitulo";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'S'";
            }
            if (vSt_tituloterceiro)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "st_tituloterceiro";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'S'";
            }
            if (!string.IsNullOrEmpty(Tp_portadorPDV))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "tp_portadorPDV";
                filtro[filtro.Length - 1].vOperador = "in";
                filtro[filtro.Length - 1].vVL_Busca = "(" + Tp_portadorPDV.Trim() + ")";
            }

            return new TCD_CadPortador(banco).Select(filtro, vTop, vNm_campo, vOrder);
        }

        public static string Gravar(TRegistro_CadPortador val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CadPortador qtb_portador = new TCD_CadPortador();
            try
            {
                if (banco == null)
                    st_transacao = qtb_portador.CriarBanco_Dados(true);
                else
                    qtb_portador.Banco_Dados = banco;
                //Gravar registro
                string retorno = qtb_portador.Gravar(val);
                if (st_transacao)
                    qtb_portador.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_portador.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar portador: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_portador.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_CadPortador val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CadPortador qtb_portador = new TCD_CadPortador();
            try
            {
                if (banco == null)
                    st_transacao = qtb_portador.CriarBanco_Dados(true);
                else
                    qtb_portador.Banco_Dados = banco;
                //Deletar registro
                try
                {
                    qtb_portador.Excluir(val);
                }
                catch
                {
                    //Exclusao logica
                    val.St_registro = "C";
                    qtb_portador.Gravar(val);
                }
                if (st_transacao)
                    qtb_portador.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_portador.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir portador: "+ ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_portador.deletarBanco_Dados();
            }
        }

        public static decimal CalcularValorJuroFin(decimal Percentual,
                                                   decimal valor)
        {
            if (Percentual.Equals(decimal.Zero))
                return decimal.Zero;
            else return Math.Round(decimal.Divide(decimal.Multiply(valor, Percentual), 100), 2, MidpointRounding.AwayFromZero);
        }
    }
}
