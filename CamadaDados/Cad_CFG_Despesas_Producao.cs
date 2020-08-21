using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Utils;
using Querys;

namespace CamadaDados.Producao.Cadastros
{
    public class TList_CadCFG_Despesas_Producao : List<TRegistro_CadCFG_Despesas_Producao>
    { }
    
    public class TRegistro_CadCFG_Despesas_Producao
    {
        private decimal? CD_ContaCTB;

        public decimal? cd_ContaCTB
        {
            get { 
                if (CD_ContaCTB == 0)
                    return null;
                else
                    return CD_ContaCTB; 
            }
            set { CD_ContaCTB = value;
                  CD_ContaCTBstring = value.ToString();
            }
        }

        private string CD_ContaCTBstring;

        public string cd_ContaCTBstring
        {
            get { return CD_ContaCTBstring; }
            set { CD_ContaCTBstring = value;
                  try
                   {
                        cd_ContaCTB = Convert.ToDecimal(value);
                   }
                         catch { cd_ContaCTB = null; }
                   }
        }

        
        private string DS_ContaCTB;
        public string ds_contaCTB
        {
            get { return DS_ContaCTB; }
            set { DS_ContaCTB = value; }
        }

 
        private string TP_Config;
        public string tp_Config
        {
            get { return TP_Config; }
            set { TP_Config = value;
            if (value == "CP")
            { ds_TP_Config = "Custos Produção"; }
            else
                if (value == "FI")
                { ds_TP_Config = "Faturamento de Industrializados"; }
                else
                    if (value == "SE")
                    { ds_TP_Config = "Saldo de Estoque dos Produtos Industrializados"; }
            }
        }

        private string ds_TP_Config;
        public string Ds_TP_Config
        {
            get { return ds_TP_Config; }
            set { 
                ds_TP_Config = value;
                if (value == "CP")
                { ds_TP_Config = "Custos Produção";}
                else
                    if (value == "FI")
                    { ds_TP_Config = "Faturamento de Industrializados";}
                    else
                        if (value == "SE")
                        { ds_TP_Config = "Saldo de Estoque dos Produtos Industrializados"; }
            }
        }

        private decimal vl_UP_Provisao;

        public decimal Vl_UP_Provisao
        {
            get { return vl_UP_Provisao; }
            set { vl_UP_Provisao = value; }
        }

        private string cd_Empresa;

        public string Cd_Empresa
        {
            get { return cd_Empresa; }
            set { cd_Empresa = value; }
        }
        private string nm_Empresa;

        public string Nm_Empresa
        {
            get { return nm_Empresa; }
            set { nm_Empresa = value; }
        }

        public TRegistro_CadCFG_Despesas_Producao()
        {
            cd_ContaCTB = 0;
            ds_contaCTB = "";
            cd_Empresa = "";
            nm_Empresa = "";
            vl_UP_Provisao = 0;
            tp_Config = "CP";
        }
    }

    public class TCD_CadCFG_Despesas_Producao : TDataQuery
    {
        public override DataTable Buscar(TpBusca[] vBusca, Int16 vTop)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, ""), null);
        }
         
        public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
        {
            return ExecutarBuscaEscalar(SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }
         
        private string SqlCodeBusca(TpBusca[] vBusca, Int16 vTop, string vNM_Campo)
        {
            StringBuilder sql;
            string cond, strTop;
            Int16 i;
            strTop = "";
            if (vTop > 0)
            {
                strTop = "TOP " + Convert.ToString(vTop);
            }
            sql = new StringBuilder();
            if (vNM_Campo.Length == 0)
            {
                sql.Append(" Select " + strTop + " a.cd_contactb,  b.ds_ContaCTB, ");
                sql.Append(" a.cd_empresa, c.NM_Empresa, a.TP_Config, a.VL_UP_Provisao ");
            }
            else
            {
                sql.Append("Select " + strTop + " " + vNM_Campo + " ");
            }

            sql.Append(" from tb_PRD_CFG_DespesasProducao a " );
            sql.Append(" left outer join TB_PlanoContas b on (a.cd_ContaCTB = b.cd_Conta) ");
            sql.Append(" left outer join TB_Empresa c on (a.cd_empresa = c.cd_empresa) ");
            cond = " where ";
            if (vBusca != null)
                if (vBusca.Length > 0)
                    for (i = 0; i < (vBusca.Length); i++)
                    {
                        sql.Append(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                        cond = " and ";
                    }
            return sql.ToString();
        }
        
        public TList_CadCFG_Despesas_Producao Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_CadCFG_Despesas_Producao lista = new TList_CadCFG_Despesas_Producao();
            SqlDataReader reader;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
            {
                this.CriarBanco_Dados(false);
                podeFecharBco = true;
            }

            try
            {
                if (vNM_Campo == "")
                    reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), ""));
                else
                    reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));

                while (reader.Read())
                {
                    TRegistro_CadCFG_Despesas_Producao CadCFG_Despesas_Producao = new TRegistro_CadCFG_Despesas_Producao();
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_CONTACTB")))
                        CadCFG_Despesas_Producao.cd_ContaCTB = reader.GetDecimal(reader.GetOrdinal("CD_CONTACTB"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_CONTACTB")))
                        CadCFG_Despesas_Producao.ds_contaCTB = reader.GetString(reader.GetOrdinal("DS_CONTACTB"));
                    if (!reader.IsDBNull(reader.GetOrdinal("TP_Config")))
                        CadCFG_Despesas_Producao.tp_Config = reader.GetString(reader.GetOrdinal("TP_CONFIG"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Empresa")))
                        CadCFG_Despesas_Producao.Cd_Empresa = reader.GetString(reader.GetOrdinal("CD_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NM_Empresa")))
                        CadCFG_Despesas_Producao.Nm_Empresa = reader.GetString(reader.GetOrdinal("NM_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("VL_UP_PROVISAO")))
                        CadCFG_Despesas_Producao.Vl_UP_Provisao = reader.GetDecimal(reader.GetOrdinal("VL_UP_PROVISAO"));
                    lista.Add(CadCFG_Despesas_Producao);
                }
            }
            finally
            {
                if (podeFecharBco)
                    this.deletarBanco_Dados();
            }
            return lista;

        }
        
        public string GravarCFG_Despesas_Producao(TRegistro_CadCFG_Despesas_Producao val)
        {
            Hashtable hs = new Hashtable();
            hs.Add("@P_CD_EMPRESA", val.Cd_Empresa);
            hs.Add("@P_TP_CONFIG", val.tp_Config);
            hs.Add("@P_CD_CONTACTB", val.cd_ContaCTB);
            hs.Add("@P_VL_UP_PROVISAO", val.Vl_UP_Provisao);
            return executarProc("IA_PRD_CFG_DESPESASPRODUCAO", hs);
        }

        public string DeletarCFG_Despesas_Producao(TRegistro_CadCFG_Despesas_Producao val)
        {
            Hashtable hs = new Hashtable();
            hs.Add("@P_CD_EMPRESA", val.Cd_Empresa);
            hs.Add("@P_TP_CONFIG", val.tp_Config);
            return this.executarProc("EXCLUI_PRD_CFG_DESPESASPRODUCAO", hs);
        }
                   
    }
}
