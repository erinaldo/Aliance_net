using BancoDados;
using CamadaDados;
using CamadaDados.Restaurante;
using System;
using Utils;

namespace CamadaNegocio.Restaurante
{
    public static class TCN_MovBarril
    {
        public static TList_MovBarril Buscar(string Cd_empresa,
                                             string Id_barril,
                                             string Nr_barril,
                                             string Cd_produto,
                                             string TP_Data,
                                             string Dt_ini,
                                             string Dt_fin,
                                             string St_registro,
                                             TObjetoBanco banco)
        {
            TpBusca[] filtro = new TpBusca[0];
            if (!string.IsNullOrEmpty(Cd_empresa))
                Estruturas.CriarParametro(ref filtro, "a.cd_empresa", "'" + Cd_empresa.Trim() + "'");
            if (!string.IsNullOrEmpty(Id_barril))
                Estruturas.CriarParametro(ref filtro, "a.id_barril", Id_barril);
            if (!string.IsNullOrEmpty(Nr_barril))
                Estruturas.CriarParametro(ref filtro, "b.nr_barril", "'" + Nr_barril.Trim() + "'");
            if (!string.IsNullOrEmpty(Cd_produto))
                Estruturas.CriarParametro(ref filtro, "a.cd_produto", "'" + Cd_produto.Trim() + "'");
            if (Dt_ini.IsDateTime())
                Estruturas.CriarParametro(ref filtro, "convert(datetime, floor(convert(decimal(30,10), " + (TP_Data.Trim().ToUpper().Equals("C") ? "a.dt_carga" : "a.dt_descarga") + ")))", "'" + Convert.ToDateTime(Dt_ini).ToString("yyyyMMdd") + "'", ">=");
            if(Dt_fin.IsDateTime())
                Estruturas.CriarParametro(ref filtro, "convert(datetime, floor(convert(decimal(30,10), " + (TP_Data.Trim().ToUpper().Equals("C") ? "a.dt_carga" : "a.dt_descarga") + ")))", "'" + Convert.ToDateTime(Dt_fin).ToString("yyyyMMdd") + "'", "<=");
            if (!string.IsNullOrEmpty(St_registro))
                Estruturas.CriarParametro(ref filtro, "a.st_registro", "'" + St_registro.Trim() + "'");
            return new TCD_MovBarril(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_MovBarril val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_MovBarril qtb_mov = new TCD_MovBarril();
            try
            {
                if (banco == null)
                    st_transacao = qtb_mov.CriarBanco_Dados(true);
                else qtb_mov.Banco_Dados = banco;
                val.Id_mov = Convert.ToInt32(TDataQuery.getPubVariavel(qtb_mov.Gravar(val), "@P_ID_MOV"));
                if (st_transacao)
                    qtb_mov.Banco_Dados.Commit_Tran();
                return val.Id_mov.ToString();
            }
            catch(Exception ex)
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

        public static string Excluir(TRegistro_MovBarril val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_MovBarril qtb_mov = new TCD_MovBarril();
            try
            {
                if (banco == null)
                    st_transacao = qtb_mov.CriarBanco_Dados(true);
                else qtb_mov.Banco_Dados = banco;
                qtb_mov.Excluir(val);
                if (st_transacao)
                    qtb_mov.Banco_Dados.Commit_Tran();
                return val.Id_mov.ToString();
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
