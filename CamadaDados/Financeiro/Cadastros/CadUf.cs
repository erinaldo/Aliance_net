using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Utils;

namespace CamadaDados.Financeiro.Cadastros
{
    public class TList_CadUf : List<TRegistro_CadUf>
    { }

    
    public class TRegistro_CadUf
    {
        
        public string Uf 
        { get; set; }
        
        public string Cd_uf 
        { get; set; }
        
        public string Ds_uf 
        { get; set; }
        
        public decimal Pc_aliquotaicms
        { get; set; }
        private string st_registro;
        
        public string St_registro 
        {
            get { return st_registro; }
            set
            {
                st_registro = value;
                if (value.Trim().ToUpper().Equals("A"))
                    status = "ATIVO";
                else if (value.Trim().ToUpper().Equals("C"))
                    status = "CANCELADO";
            }
        }
        private string status;
        
        public string Status
        {
            get { return status; }
            set 
            { 
                status = value;
                if (value.Trim().ToUpper().Equals("ATIVO"))
                    st_registro = "A";
                else if (value.Trim().ToUpper().Equals("CANCELADO"))
                    st_registro = "C";
            }
        }
        
        public bool St_agregar
        { get; set; }

        public TRegistro_CadUf()
        {
            this.Uf = string.Empty;
            this.Cd_uf = string.Empty;
            this.Ds_uf = string.Empty;
            this.Pc_aliquotaicms = decimal.Zero;
            this.st_registro = "A";
            this.St_agregar = false;
        }
    }

    public class TCD_CadUf : TDataQuery
    {
        public TCD_CadUf()
        { }

        public TCD_CadUf(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
                sql.AppendLine("select " + strTop + " a.uf, a.cd_uf, a.ds_uf, a.pc_aliquotaicms, a.st_registro ");
            else
                sql.AppendLine(" Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from tb_fin_uf a ");

            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                    cond = " and ";
                }
            sql.AppendLine("Order By a.ds_uf asc");
            return sql.ToString();
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, ""), null);
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo), null);
        }

        public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
        {
            return this.ExecutarBuscaEscalar(this.SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }

        public TList_CadUf Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            bool podeFecharBco = false;
            TList_CadUf lista = new TList_CadUf();
            if (Banco_Dados == null)
            {
                this.CriarBanco_Dados(false);
                podeFecharBco = true;
            }
            SqlDataReader reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_CadUf reg = new TRegistro_CadUf();
                    if (!(reader.IsDBNull(reader.GetOrdinal("UF"))))
                        reg.Uf = reader.GetString(reader.GetOrdinal("UF"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_UF"))))
                        reg.Cd_uf = reader.GetString(reader.GetOrdinal("CD_UF"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("DS_UF"))))
                        reg.Ds_uf = reader.GetString(reader.GetOrdinal("DS_UF"));
                    if (!reader.IsDBNull(reader.GetOrdinal("pc_aliquotaicms")))
                        reg.Pc_aliquotaicms = reader.GetDecimal(reader.GetOrdinal("pc_aliquotaicms"));
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

        public string GravarUf(TRegistro_CadUf val)
        {
            Hashtable hs = new Hashtable(5);
            hs.Add("@P_UF", val.Uf);
            hs.Add("@P_CD_UF", val.Cd_uf);
            hs.Add("@P_DS_UF", val.Ds_uf);
            hs.Add("@P_PC_ALIQUOTAICMS", val.Pc_aliquotaicms);
            hs.Add("@P_ST_REGISTRO", val.St_registro);

            return this.executarProc("IA_FIN_UF", hs);
        }

        public string DeletarUf(TRegistro_CadUf val)
        {
            Hashtable hs = new Hashtable(1);
            hs.Add("@P_UF", val.Uf);

            return this.executarProc("EXCLUI_FIN_UF", hs);
        }
    }
}
