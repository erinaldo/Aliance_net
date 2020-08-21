using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;
using CamadaDados.Faturamento.LoteAnvisa;

namespace CamadaNegocio.Faturamento.LoteAnvisa
{
    public class TCN_LoteAnvisa
    {
        public static TList_LoteAnvisa Buscar(string Cd_empresa,
                                              string Cd_fornecedor,
                                              string Cd_produto,
                                              string Nr_lote,
                                              string Tp_data,
                                              string Dt_ini,
                                              string Dt_fin,
                                              string St_registro,
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
            if (!string.IsNullOrEmpty(Cd_fornecedor))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_fornecedor";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_fornecedor.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Cd_produto))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_produto";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_produto.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Nr_lote))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.nr_lote";
                filtro[filtro.Length - 1].vOperador = "like";
                filtro[filtro.Length - 1].vVL_Busca = "'%" + Nr_lote.Trim() + "%'";
            }
            if (!string.IsNullOrEmpty(Dt_ini.SoNumero()))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), " + (Tp_data.Trim().ToUpper().Equals("F") ? "a.dt_fabric" : "a.dt_validade") + ")))";
                filtro[filtro.Length - 1].vOperador = ">=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + DateTime.Parse(Dt_ini).ToString("yyyyMMdd") + "'";
            }
            if (!string.IsNullOrEmpty(Dt_fin.SoNumero()))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), " + (Tp_data.Trim().ToUpper().Equals("F") ? "a.dt_fabric" : "a.dt_validade") + ")))";
                filtro[filtro.Length - 1].vOperador = "<=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + DateTime.Parse(Dt_fin).ToString("yyyyMMdd") + "'";
            }
            if (!string.IsNullOrEmpty(St_registro))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.Qtd_entrada - a.Qtd_saida";
                filtro[filtro.Length - 1].vOperador = St_registro.Trim().ToUpper().Equals("A") ? ">" : "=";
                filtro[filtro.Length - 1].vVL_Busca = "0";
            }
            return new TCD_LoteAnvisa(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_LoteAnvisa val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_LoteAnvisa qtb_lote = new TCD_LoteAnvisa();
            try
            {
                if (banco == null)
                    st_transacao = qtb_lote.CriarBanco_Dados(true);
                else qtb_lote.Banco_Dados = banco;
                val.Id_lotestr = CamadaDados.TDataQuery.getPubVariavel(qtb_lote.Gravar(val), "@P_ID_LOTE");
                if (st_transacao)
                    qtb_lote.Banco_Dados.Commit_Tran();
                return val.Id_lotestr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_lote.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar lote: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_lote.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_LoteAnvisa val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_LoteAnvisa qtb_lote = new TCD_LoteAnvisa();
            try
            {
                if (banco == null)
                    st_transacao = qtb_lote.CriarBanco_Dados(true);
                else qtb_lote.Banco_Dados = banco;
                qtb_lote.Excluir(val);
                if (st_transacao)
                    qtb_lote.Banco_Dados.Commit_Tran();
                return val.Id_lotestr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_lote.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir lote: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_lote.deletarBanco_Dados();
            }
        }
    }

    public class TCN_MovLoteAnvisa
    {
        public static TList_MovLoteAnvisa Buscar(string Cd_empresa,
                                                 string Id_lote,
                                                 string Id_cupom,
                                                 string Id_lancto,
                                                 string Nr_lanctofiscal,
                                                 string Id_nfitem,
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
            if (!string.IsNullOrEmpty(Id_lote))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_lote";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_lote;
            }
            if (!string.IsNullOrEmpty(Id_cupom))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_cupom";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_cupom;
            }
            if (!string.IsNullOrEmpty(Id_lancto))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_lancto";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_lancto;
            }
            if (!string.IsNullOrEmpty(Nr_lanctofiscal))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.nr_lanctofiscal";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Nr_lanctofiscal;
            }
            if (!string.IsNullOrEmpty(Id_nfitem))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_nfitem";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_nfitem;
            }
            return new TCD_MovLoteAnvisa(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_MovLoteAnvisa val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_MovLoteAnvisa qtb_mov = new TCD_MovLoteAnvisa();
            try
            {
                if (banco == null)
                    st_transacao = qtb_mov.CriarBanco_Dados(true);
                else qtb_mov.Banco_Dados = banco;
                val.Id_movstr = CamadaDados.TDataQuery.getPubVariavel(qtb_mov.Gravar(val), "@P_ID_MOV");
                if (st_transacao)
                    qtb_mov.Banco_Dados.Commit_Tran();
                return val.Id_movstr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_mov.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar movimento: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_mov.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_MovLoteAnvisa val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_MovLoteAnvisa qtb_mov = new TCD_MovLoteAnvisa();
            try
            {
                if (banco == null)
                    st_transacao = qtb_mov.CriarBanco_Dados(true);
                else qtb_mov.Banco_Dados = banco;
                qtb_mov.Excluir(val);
                if (st_transacao)
                    qtb_mov.Banco_Dados.Commit_Tran();
                return val.Id_movstr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_mov.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir movimento: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_mov.deletarBanco_Dados();
            }
        }
    }
}
