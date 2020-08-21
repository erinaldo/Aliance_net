using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;
using CamadaDados.Producao.Cadastros;

namespace CamadaNegocio.Producao.Cadastros
{
    public class TCN_Cad_PRD_Custos
    {
        public static TList_Cad_PRD_Custos Buscar(string vId_custo,
                                                  string vDs_custo,
                                                  BancoDados.TObjetoBanco banco)
        {
            TpBusca[] vBusca = new TpBusca[0];
            if (!string.IsNullOrEmpty(vId_custo))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "ID_Custo";
                vBusca[vBusca.Length - 1].vVL_Busca = vId_custo;
                vBusca[vBusca.Length - 1].vOperador = "=";
            }
            if (!string.IsNullOrEmpty(vDs_custo))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "DS_Custo";
                vBusca[vBusca.Length - 1].vVL_Busca = "('%" + vDs_custo + "%')";
                vBusca[vBusca.Length - 1].vOperador = "like";
            }
            return new TCD_Cad_PRD_Custos(banco).Select(vBusca, 0, string.Empty);
        }

        public static string Gravar(TRegistro_Cad_PRD_Custos val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Cad_PRD_Custos qtb_custo = new TCD_Cad_PRD_Custos();
            try
            {
                if (banco == null)
                    st_transacao = qtb_custo.CriarBanco_Dados(true);
                else
                    qtb_custo.Banco_Dados = banco;
                val.Id_custostr = CamadaDados.TDataQuery.getPubVariavel(qtb_custo.Gravar(val), "@P_ID_CUSTO");
                if (st_transacao)
                    qtb_custo.Banco_Dados.Commit_Tran();
                return val.Id_custostr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_custo.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar custo: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_custo.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_Cad_PRD_Custos val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Cad_PRD_Custos qtb_custo = new TCD_Cad_PRD_Custos();
            try
            {
                if (banco == null)
                    st_transacao = qtb_custo.CriarBanco_Dados(true);
                else
                    qtb_custo.Banco_Dados = banco;
                qtb_custo.Excluir(val);
                if (st_transacao)
                    qtb_custo.Banco_Dados.Commit_Tran();
                return val.Id_custostr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_custo.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir custo: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_custo.deletarBanco_Dados();
            }
        }
    }
}
