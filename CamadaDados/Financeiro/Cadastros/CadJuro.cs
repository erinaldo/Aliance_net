using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;
using System.Data.SqlClient;
using System.Collections;
using System.Data;

namespace CamadaDados.Financeiro.Cadastros
{
    public class TList_CadJuro : List<TRegistro_CadJuro>
    { }

    
    public class TRegistro_CadJuro
    {
        
        public string Cd_juro
        { get; set; }
        
        public string Ds_juro
        { get; set; }
        private string tp_juro;
        
        public string Tp_juro
        {
            get { return tp_juro; }
            set
            {
                tp_juro = value;
                if (value.Trim().ToUpper().Equals("S"))
                    tipo_juro = "SIMPLES";
                else if (value.Trim().ToUpper().Equals("C"))
                    tipo_juro = "COMPOSTO";
            }
        }
        private string tipo_juro;
        
        public string Tipo_juro
        {
            get { return tipo_juro; }
            set
            {
                tipo_juro = value;
                if (value.Trim().ToUpper().Equals("SIMPLES"))
                    tp_juro = "S";
                else if (value.Trim().ToUpper().Equals("COMPOSTO"))
                    tp_juro = "C";
            }
        }
        
        public decimal Pc_jurodiario_atrazo
        { get; set; }
        
        public decimal Diascarencia
        { get; set; }
        
        public string St_registro
        { get; set; }

        public TRegistro_CadJuro()
        {
            this.Cd_juro = string.Empty;
            this.Ds_juro = string.Empty;
            this.tp_juro = string.Empty;
            this.tipo_juro = string.Empty;
            this.Pc_jurodiario_atrazo = 0;
            this.Diascarencia = 0;
            this.St_registro = "A";
        }
    }

    public class TCD_CadJuro : TDataQuery
    {
        public TCD_CadJuro()
        { }

        public TCD_CadJuro(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, Int16 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("select " + strTop + " cd_juro, ds_juro, tp_juro, ");
                sql.AppendLine("pc_jurodiario_atrazo, diascarencia, st_registro ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from tb_fin_juro a ");
            sql.AppendLine("where isnull(st_registro, 'A') <> 'C' ");
            string cond = " and ";

            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + ")");
            return sql.ToString();
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, string.Empty), null);
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo), null);
        }

        public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
        {
            return this.ExecutarBuscaEscalar(this.SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }

        public TList_CadJuro Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_CadJuro lista = new TList_CadJuro();
            SqlDataReader reader;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_CadJuro reg = new TRegistro_CadJuro();
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_Juro"))))
                        reg.Cd_juro = reader.GetString(reader.GetOrdinal("CD_Juro"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("DS_Juro"))))
                        reg.Ds_juro = reader.GetString(reader.GetOrdinal("DS_Juro"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("TP_Juro"))))
                        reg.Tp_juro = reader.GetString(reader.GetOrdinal("TP_Juro"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("PC_JuroDiario_Atrazo"))))
                        reg.Pc_jurodiario_atrazo = reader.GetDecimal(reader.GetOrdinal("PC_JuroDiario_Atrazo"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("DiasCarencia"))))
                        reg.Diascarencia = reader.GetDecimal(reader.GetOrdinal("DiasCarencia"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("ST_Registro"))))
                        reg.St_registro = reader.GetString(reader.GetOrdinal("ST_Registro"));

                    lista.Add(reg);
                }
            }
            finally
            {
                reader.Close();
                reader.Dispose();
                if (podeFecharBco)
                    this.deletarBanco_Dados();
            }
            return lista;
        }

        public string GravarJuro(TRegistro_CadJuro val)
        {
            Hashtable hs = new Hashtable(6);
            hs.Add("@P_CD_JURO", val.Cd_juro);
            hs.Add("@P_DS_JURO", val.Ds_juro);
            hs.Add("@P_TP_JURO", val.Tp_juro);
            hs.Add("@P_PC_JURODIARIO_ATRAZO", val.Pc_jurodiario_atrazo);
            hs.Add("@P_DIASCARENCIA", val.Diascarencia);
            hs.Add("@P_ST_REGISTRO", val.St_registro);

            return this.executarProc("IA_FIN_JURO", hs);
        }

        public string DeletarJuro(TRegistro_CadJuro val)
        {
            Hashtable hs = new Hashtable(1);
            hs.Add("@P_CD_JURO", val.Cd_juro);

            return this.executarProc("EXCLUI_FIN_JURO", hs);
        }
    }
}
