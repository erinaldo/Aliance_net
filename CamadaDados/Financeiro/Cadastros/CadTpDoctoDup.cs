using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using Utils;
using System.Data.SqlClient;
using System.Data;

namespace CamadaDados.Financeiro.Cadastros
{
    public class TList_CadTpDoctoDup : List<TRegistro_CadTpDoctoDup>
    { }

    
    public class TRegistro_CadTpDoctoDup
    {
        private decimal? tp_docto;
        
        public decimal? Tp_docto
        {
            get { return tp_docto; }
            set
            {
                tp_docto = value;
                tp_doctoString = (value.HasValue ? value.ToString() : string.Empty);
            }
        }

        private string tp_doctoString;
        
        public string Tp_doctoString
        {
            get { return tp_doctoString; }
            set
            {
                tp_doctoString = value;
                try
                {
                    tp_docto = Convert.ToDecimal(value);
                }
                catch
                { tp_docto = null; }
            }
        }
        
        public string Ds_tpdocto { get; set; }
        private string st_duplicata;
        
        public string St_duplicata
        {
            get { return st_duplicata; }
            set
            {
                st_duplicata = value;
                st_duplicatabool = value.Trim().ToUpper().Equals("S");
            }
        }
        private bool st_duplicatabool;
        
        public bool St_duplicatabool
        {
            get { return st_duplicatabool; }
            set
            {
                st_duplicatabool = value;
                st_duplicata = value ? "S" : "N";
            }
        }
        
        public string St_registro { get; set; }

        public TRegistro_CadTpDoctoDup()
        {
            this.tp_docto = 0;
            this.tp_doctoString = string.Empty;
            this.Ds_tpdocto = string.Empty;
            this.st_duplicata = "N";
            this.st_duplicatabool = false;
            this.St_registro = "A";
        }
    }

    public class TCD_CadTpDoctoDup : TDataQuery
    {
        public TCD_CadTpDoctoDup() { }

        public TCD_CadTpDoctoDup(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop)
        {

            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, ""), null);
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }

        public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
        {
            return this.ExecutarBuscaEscalar(this.SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }

        private string SqlCodeBusca(TpBusca[] vBusca, Int16 vTop, string vNM_Campo)
        {
            StringBuilder sql;
            string cond = " "; string strTop;
            int i;
            strTop = "";

            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            sql = new StringBuilder();
            if (vNM_Campo.Length == 0)
            {
                sql.AppendLine("Select " + strTop + " a.TP_Docto, a.DS_TpDocto, ");
                sql.AppendLine("a.ST_Duplicata, a.St_registro ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("From TB_FIN_TpDocto_Dup a");
            sql.AppendLine("Where isNull(a.ST_Registro, 'A') <> 'C'");
            cond = " and ";

            if (vBusca != null)
                for (i = 0; i < (vBusca.Length); i++)
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
            return sql.ToString();
        }

        public TList_CadTpDoctoDup Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_CadTpDoctoDup lista = new TList_CadTpDoctoDup();
            SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);

            try
            {
                reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
                while (reader.Read())
                {
                    TRegistro_CadTpDoctoDup reg = new TRegistro_CadTpDoctoDup();
                    if (!(reader.IsDBNull(reader.GetOrdinal("Tp_Docto"))))
                        reg.Tp_docto = reader.GetDecimal(reader.GetOrdinal("Tp_Docto"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("DS_TpDocto"))))
                        reg.Ds_tpdocto = reader.GetString(reader.GetOrdinal("DS_TpDocto"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("ST_Duplicata"))))
                        reg.St_duplicata = reader.GetString(reader.GetOrdinal("ST_Duplicata"));
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

        public string gravarDocto(TRegistro_CadTpDoctoDup val)
        {
            Hashtable hs = new Hashtable(4);
            hs.Add("@P_TP_DOCTO", val.Tp_docto);
            hs.Add("@P_DS_TPDOCTO", val.Ds_tpdocto);
            hs.Add("@P_ST_DUPLICATA", val.St_duplicata);
            hs.Add("@P_ST_REGISTRO", val.St_registro);

            return executarProc("IA_FIN_TPDOCTO_DUP", hs);
        }

        public string deletarDocto(TRegistro_CadTpDoctoDup val)
        {
            Hashtable hs = new Hashtable(1);
            hs.Add("@P_TP_DOCTO", val.Tp_docto);
            return executarProc("EXCLUI_FIN_TPDOCTO_DUP", hs);
        }
    }
}
