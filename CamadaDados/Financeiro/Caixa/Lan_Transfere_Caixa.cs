using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using System.Data.SqlClient;
using System.Data.Common;
using CamadaDados;
using Utils;


namespace CamadaDados.Financeiro.Caixa
{
    public class TList_Lan_Transfere_Caixa : List<TRegistro_Lan_Transfere_Caixa>
    {
    }

    
    public class TRegistro_Lan_Transfere_Caixa
    {
        
        public string CD_LanctoCaixa
        { get; set; }
        
        public string NR_Docto
        { get; set; }
        private DateTime? dt_lancto;
        
        public DateTime? DT_Lancto
        {
            get { return dt_lancto; }
            set 
            { 
                dt_lancto = value;
                dt_lanctostr = value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty;
            }
        }
        private string dt_lanctostr;
        public string DT_Lancto_String
        {
            get 
            {
                try
                {
                    return DateTime.Parse(dt_lanctostr).ToString("dd/MM/yyyy");
                }
                catch
                { return string.Empty; }
            }
            set 
            { 
                dt_lanctostr = value;
                try
                {
                    dt_lancto = DateTime.Parse(value);
                }
                catch
                { dt_lancto = null; }
            }
        }
        
        public string CD_ContaGer_Entrada
        { get; set; }
        
        public string DS_ContaGer_Entrada
        { get; set; }
        
        public string Cd_moeda_entrada
        { get; set; }
        
        public string Ds_moeda_entrada
        { get; set; }
        
        public string Sigla_moeda_entrada
        { get; set; }
        
        public string CD_ContaGer_Saida
        { get; set; }
        
        public string DS_ContaGer_Saida
        { get; set; }
        
        public string Cd_moeda_saida
        { get; set; }
        
        public string Ds_moeda_saida
        { get; set; }
        
        public string Sigla_moeda_saida
        { get; set; }
        
        public string CD_Empresa
        { get; set; }
        
        public string NM_Empresa
        { get; set; }
        
        public string CD_Historico
        { get; set; }
        
        public string DS_Historico
        { get; set; }
        
        public decimal Valor_Transferencia
        { get; set; }
        public decimal Vl_saida_transferencia
        {
            get 
            {
                if (Cd_moeda_saida.Trim().Equals(Cd_moeda_entrada))
                    return Valor_Transferencia;
                else if ((!string.IsNullOrEmpty(Operador)) && Vl_cotacao > 0)
                    return (Operador.Trim().Equals("*") ? Valor_Transferencia * Vl_cotacao : Valor_Transferencia / Vl_cotacao);
                else
                    return Valor_Transferencia;
            }
        }
        
        public decimal Valor_Anterior_Entrada
        { get; set; }
        
        public decimal Valor_Atual_Entrada
        { get; set; }
        
        public decimal Valor_Anterior_Saida
        { get; set; }
        
        public decimal Valor_Atual_Saida
        { get; set; }
        
        public string Complemento
        { get; set; }
        
        public decimal ID_TRANSF
        { get; set; }
        
        public decimal CD_LANCTOCAIXA_ENT
        { get; set; }
        
        public decimal CD_LANCTOCAIXA_SAI
        { get; set; }
        
        public decimal Vl_cotacao
        { get; set; }
        
        public string Operador
        { get; set; }
        
        public bool St_avulso
        { get; set; }

        public TRegistro_Lan_Transfere_Caixa()
        {
            CD_LanctoCaixa = string.Empty;
            NR_Docto = string.Empty;
            dt_lancto = null;
            dt_lanctostr = string.Empty;
            CD_ContaGer_Entrada = string.Empty;
            DS_ContaGer_Entrada = string.Empty;
            CD_ContaGer_Saida = string.Empty;
            DS_ContaGer_Saida = string.Empty;
            CD_Historico = string.Empty;
            DS_Historico = string.Empty;
            CD_Empresa = string.Empty;
            NM_Empresa = string.Empty;
            Valor_Transferencia = decimal.Zero;
            Valor_Anterior_Entrada = decimal.Zero;
            Valor_Atual_Entrada = decimal.Zero;
            Valor_Anterior_Saida = decimal.Zero;
            Valor_Atual_Saida = decimal.Zero;
            ID_TRANSF = decimal.Zero;
            CD_LANCTOCAIXA_ENT = decimal.Zero;
            CD_LANCTOCAIXA_SAI = decimal.Zero;
            Cd_moeda_entrada = string.Empty;
            Ds_moeda_entrada = string.Empty;
            Sigla_moeda_entrada = string.Empty;
            Cd_moeda_saida = string.Empty;
            Ds_moeda_saida = string.Empty;
            Sigla_moeda_saida = string.Empty;
            Vl_cotacao = decimal.Zero;
            Operador = string.Empty;
            St_avulso = false;
        }
    }

    public class TCD_Lan_Transferencia_Caixa : TDataQuery
    {
        public TCD_Lan_Transferencia_Caixa()
        { }

        public TCD_Lan_Transferencia_Caixa(BancoDados.TObjetoBanco banco)
        { Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("select " + strTop + " a.id_transf, a.cd_conta_ent, b.DS_ContaGer as conta_ent, ");
                sql.AppendLine("a.cd_lanctocaixa_ent, a.cd_conta_sai, d.DS_ContaGer as conta_sai, ");
                sql.AppendLine("a.cd_lanctocaixa_sai, c.cd_moeda as cd_moeda_ent, ");
                sql.AppendLine("c.ds_moeda_singular as ds_moeda_ent, ");
                sql.AppendLine("c.sigla as sigla_moeda_ent, ");
                sql.AppendLine("e.cd_moeda as cd_moeda_sai, ");
                sql.AppendLine("e.ds_moeda_singular as ds_moeda_sai, ");
                sql.AppendLine("e.sigla as sigla_moeda_sai ");
            }
            else
                sql.AppendLine(" Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from tb_fin_transfcaixa a ");
            sql.AppendLine("inner join tb_fin_contager b ");
            sql.AppendLine("on a.cd_conta_ent = b.cd_contager ");
            sql.AppendLine("inner join tb_fin_moeda c ");
            sql.AppendLine("on b.cd_moeda = c.cd_moeda ");
            sql.AppendLine("inner join tb_fin_contager d ");
            sql.AppendLine("on a.cd_conta_sai = d.cd_contager ");
            sql.AppendLine("inner join tb_fin_moeda e ");
            sql.AppendLine("on d.cd_moeda = e.cd_moeda ");

            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                    cond = " and ";
                }
            return sql.ToString();
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, string.Empty), null);
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo), null);
        }

        public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
        {
            return ExecutarBuscaEscalar(SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }

        public TList_Lan_Transfere_Caixa Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            bool podeFecharBco = false;
            TList_Lan_Transfere_Caixa lista = new TList_Lan_Transfere_Caixa();
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(true);
            SqlDataReader reader = ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_Lan_Transfere_Caixa reg = new TRegistro_Lan_Transfere_Caixa();
                    if (!(reader.IsDBNull(reader.GetOrdinal("ID_Transf"))))
                        reg.ID_TRANSF = reader.GetDecimal(reader.GetOrdinal("ID_Transf"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_Conta_Ent"))))
                        reg.CD_ContaGer_Entrada = reader.GetString(reader.GetOrdinal("CD_Conta_Ent"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_Lanctocaixa_Ent"))))
                        reg.CD_LANCTOCAIXA_ENT = reader.GetDecimal(reader.GetOrdinal("CD_Lanctocaixa_Ent"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_Conta_Sai"))))
                        reg.CD_ContaGer_Saida = reader.GetString(reader.GetOrdinal("CD_Conta_Sai"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Lanctocaixa_Sai")))
                        reg.CD_LANCTOCAIXA_SAI = reader.GetDecimal(reader.GetOrdinal("CD_Lanctocaixa_Sai"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Cd_Moeda_ent")))
                        reg.Cd_moeda_entrada = reader.GetString(reader.GetOrdinal("CD_Moeda_Ent"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Moeda_Ent")))
                        reg.Ds_moeda_entrada = reader.GetString(reader.GetOrdinal("DS_Moeda_Ent"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Sigla_Moeda_Ent")))
                        reg.Sigla_moeda_entrada = reader.GetString(reader.GetOrdinal("Sigla_Moeda_ent"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Moeda_Sai")))
                        reg.Cd_moeda_saida = reader.GetString(reader.GetOrdinal("CD_Moeda_Sai"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Moeda_Sai")))
                        reg.Ds_moeda_saida = reader.GetString(reader.GetOrdinal("DS_Moeda_Sai"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Sigla_Moeda_Sai")))
                        reg.Sigla_moeda_saida = reader.GetString(reader.GetOrdinal("Sigla_moeda_sai"));
                    if (!reader.IsDBNull(reader.GetOrdinal("conta_ent")))
                        reg.DS_ContaGer_Entrada = reader.GetString(reader.GetOrdinal("conta_ent"));
                    if (!reader.IsDBNull(reader.GetOrdinal("conta_sai")))
                        reg.DS_ContaGer_Saida = reader.GetString(reader.GetOrdinal("conta_sai"));

                    lista.Add(reg);
                }
            }
            finally
            {
                reader.Close();
                reader.Dispose();
                if (podeFecharBco)
                    deletarBanco_Dados();
            }
            return lista;
        }

        public string Grava_Transferencia(TRegistro_Lan_Transfere_Caixa val)
        {
            Hashtable hs = new Hashtable(5);
            hs.Add("@P_ID_TRANSF", val.ID_TRANSF);
            hs.Add("@P_CD_CONTA_ENT", val.CD_ContaGer_Entrada);
            hs.Add("@P_CD_LANCTOCAIXA_ENT", val.CD_LANCTOCAIXA_ENT);
            hs.Add("@P_CD_CONTA_SAI", val.CD_ContaGer_Saida);
            hs.Add("@P_CD_LANCTOCAIXA_SAI", val.CD_LANCTOCAIXA_SAI);

            return executarProc("IA_FIN_TRANSFERE_CAIXA", hs);           
        }
    }
}
