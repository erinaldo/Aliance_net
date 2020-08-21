using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Faturamento.NotaFiscal;

namespace CamadaNegocio.Faturamento.NotaFiscal
{
    public class TCN_CartaCorrecao
    {
        public static TList_CartaCorrecao Buscar(string Id_carta,
                                                 string Cd_empresa,
                                                 string Nr_lanctofiscal,
                                                 string Dt_ini,
                                                 string Dt_fin,
                                                 string St_registro,
                                                 BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (!string.IsNullOrEmpty(Id_carta))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_carta";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_carta;
            }
            if (!string.IsNullOrEmpty(Cd_empresa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Nr_lanctofiscal))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.nr_lanctofiscal";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Nr_lanctofiscal;
            }
            if ((!string.IsNullOrEmpty(Dt_ini)) && (Dt_ini.Trim() != "/  /"))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.dt_evento)))";
                filtro[filtro.Length - 1].vOperador = ">=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + DateTime.Parse(Dt_ini).ToString("yyyyMMdd") + "'";
            }
            if ((!string.IsNullOrEmpty(Dt_fin)) && (Dt_fin.Trim() != "/  /"))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.dt_evento)))";
                filtro[filtro.Length - 1].vOperador = "<=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + DateTime.Parse(Dt_fin).ToString("yyyyMMdd") + "'";
            }
            if (!string.IsNullOrEmpty(St_registro))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "isnull(a.st_registro, 'A')";
                filtro[filtro.Length - 1].vOperador = "in";
                filtro[filtro.Length - 1].vVL_Busca = "(" + St_registro.Trim() + ")";
            }
            return new TCD_CartaCorrecao(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_CartaCorrecao val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CartaCorrecao qtb_cc = new TCD_CartaCorrecao();
            try
            {
                if (banco == null)
                    st_transacao = qtb_cc.CriarBanco_Dados(true);
                else
                    qtb_cc.Banco_Dados = banco;
                val.Id_cartastr = CamadaDados.TDataQuery.getPubVariavel(qtb_cc.Gravar(val), "@P_ID_CARTA");
                if (st_transacao)
                    qtb_cc.Banco_Dados.Commit_Tran();
                return val.Id_cartastr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_cc.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar carta correção: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_cc.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_CartaCorrecao val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CartaCorrecao qtb_cc = new TCD_CartaCorrecao();
            try
            {
                if (banco == null)
                    st_transacao = qtb_cc.CriarBanco_Dados(true);
                else
                    qtb_cc.Banco_Dados = banco;
                qtb_cc.Excluir(val);
                if (st_transacao)
                    qtb_cc.Banco_Dados.Commit_Tran();
                return val.Id_cartastr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_cc.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir carta correção: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_cc.deletarBanco_Dados();
            }
        }
    }
}
