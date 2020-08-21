using System;
using System.Collections.Generic;
using System.Linq;
using System.Text; 
using Utils;
using System.Data;
using System.Data.SqlClient;
using System.Collections;

namespace CamadaDados.Diversos
{
    #region layout
    public class TRegistro_CadLayoutEtiqueta
    {
        private decimal? id_layout;
        public decimal? Id_layout
        {
            get { return id_layout; }
            set
            {
                id_layout = value;
                id_layoutstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_layoutstr;
        public string Id_layoutstr
        {
            get { return id_layoutstr; }
            set
            {
                id_layoutstr = value;
                try
                {
                    id_layout = decimal.Parse(value);
                }
                catch { id_layout = null; }
            }
        }
        public decimal nr_Coluna { get; set; } = decimal.Zero;
        public string ds_layout { get; set; } = string.Empty;
        public decimal alturaetiqueta { get; set; } = decimal.Zero;
        public decimal espacoetiqueta { get; set; } = decimal.Zero;
        public decimal larguraetiqueta { get; set; } = decimal.Zero;
        public TList_CamposEtiqueta lCampos { get; set; } = new TList_CamposEtiqueta();
        public TList_CamposEtiqueta lCamposDel { get; set; } = new TList_CamposEtiqueta();

    }
    public class TList_CadLayoutEtiqueta : List<TRegistro_CadLayoutEtiqueta> { }


    public class TCD_CadLayoutEtiqueta : TDataQuery
    {





        public override DataTable Buscar(TpBusca[] vBusca, short vTop, string vNM_Campo, string vGroup, string vOrder, Hashtable vParametros)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo, vGroup, vOrder), vParametros);
        }

        public override DataTable Buscar(TpBusca[] vBusca, Int16 vTop)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, "", "", ""), null);
        }

        public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
        {
            return ExecutarBuscaEscalar(SqlCodeBusca(vBusca, 1, vNM_Campo, "", ""), null);
        }

        private string SqlCodeBusca(TpBusca[] vBusca, Int16 vTop, string vNM_Campo, string vGroup, string vOrder)
        {
            string strTop = "";
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();

            if (vNM_Campo.Trim().Equals(string.Empty))
            {
                sql.AppendLine("Select " + strTop + "a.ID_LAYOUT, A.DS_LAYOUT, A.ALTURAETIQUETA, A.ESPACOETIQUETA, A.LARGURAETIQUETA,a.nr_coluna ");
            }
            else
                sql.AppendLine("Select " + strTop + "" + vNM_Campo + "");

            sql.AppendLine("FROM TB_DIV_LayoutEtiqueta a "); 

            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < vBusca.Length; i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + ")");
                    cond = " and ";
                }
            if (vGroup.Trim() != string.Empty)
                sql.AppendLine("group by " + vGroup.Trim());
            if (vOrder.Trim() != string.Empty)
                sql.AppendLine("order by " + vOrder.Trim());
            return sql.ToString();
        }

        public TList_CadLayoutEtiqueta Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo, string vOrder)
        {
            TList_CadLayoutEtiqueta lista = new TList_CadLayoutEtiqueta();
            SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
            {
                this.CriarBanco_Dados(false);
                podeFecharBco = true;
            }
            reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), "", "", vOrder));
            try
            {
                while (reader.Read())
                {
                    TRegistro_CadLayoutEtiqueta cadMenu = new TRegistro_CadLayoutEtiqueta();
                    if (!reader.IsDBNull(reader.GetOrdinal("id_layout")))
                        cadMenu.Id_layout = reader.GetDecimal(reader.GetOrdinal("id_layout"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_layout")))
                        cadMenu.ds_layout = reader.GetString(reader.GetOrdinal("ds_layout")).Trim();
                    if (!reader.IsDBNull(reader.GetOrdinal("larguraetiqueta")))
                        cadMenu.larguraetiqueta = reader.GetDecimal(reader.GetOrdinal("larguraetiqueta"));
                    if (!reader.IsDBNull(reader.GetOrdinal("espacoetiqueta")))
                        cadMenu.espacoetiqueta = reader.GetDecimal(reader.GetOrdinal("espacoetiqueta"));
                    if (!reader.IsDBNull(reader.GetOrdinal("alturaetiqueta")))
                        cadMenu.alturaetiqueta = reader.GetDecimal(reader.GetOrdinal("alturaetiqueta"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_Coluna")))
                        cadMenu.nr_Coluna = reader.GetDecimal(reader.GetOrdinal("nr_Coluna"));

                    lista.Add(cadMenu);
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

        public string GravarMenu(TRegistro_CadLayoutEtiqueta val)
        {
            Hashtable hs = new Hashtable(7);
            hs.Add("@P_ID_LAYOUT", val.Id_layout);
            hs.Add("@P_DS_LAYOUT", val.ds_layout); 
            hs.Add("@P_LARGURAETIQUETA", val.larguraetiqueta);
            hs.Add("@P_ALTURAETIQUETA", val.alturaetiqueta);
            hs.Add("@P_ESPACOETIQUETA", val.espacoetiqueta);
            hs.Add("@P_NR_COLUNA", val.nr_Coluna.ToString("N0", new System.Globalization.CultureInfo("en-US")));

            return executarProc("IA_DIV_LAYOUTETIQUETA", hs);
        }

        public string DeletarMenu(TRegistro_CadLayoutEtiqueta val)
        {
            Hashtable hs = new Hashtable(1);
            hs.Add("@P_ID_LAYOUT", val.Id_layout);
            return this.executarProc("EXCLUI_DIV_LAYOUTETIQUETA", hs);
        }
         
         
    }
    #endregion
    #region camposetiqueta
    public class TRegistro_CamposEtiqueta
    {

        private decimal? id_layout;
        public decimal? Id_layout
        {
            get { return id_layout; }
            set
            {
                id_layout = value;
                id_layoutstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_layoutstr;
        public string Id_layoutstr
        {
            get { return id_layoutstr; }
            set
            {
                id_layoutstr = value;
                try
                {
                    id_layout = decimal.Parse(value);
                }
                catch { id_layout = null; }
            }
        }

        private decimal? id_campo;
        public decimal? Id_campo
        {
            get { return id_campo; }
            set
            {
                id_campo = value;
                id_campostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_campostr;
        public string Id_campostr
        {
            get { return id_campostr; }
            set
            {
                id_campostr = value;
                try
                {
                    id_campo = decimal.Parse(value);
                }
                catch { id_campo = null; }
            }
        }
        public string ds_campo { get; set; } = string.Empty;
        public decimal posx { get; set; } = decimal.Zero;
        public decimal posy { get; set; } = decimal.Zero;
        private string st_campo = "";
        public string St_campo
        {
            get { return st_campo; }
            set
            {
                st_campo = value;
                if (value.Trim().ToUpper().Equals("0"))
                    status = "CAMPO";
                else if (value.Trim().ToUpper().Equals("1"))
                    status = "CODIGO BARRA";
                else
                    status = string.Empty;
            }
        }
        private string status = "CAMPO";
        public string Status
        {
            get { return status; }
            set
            {
                status = value;
                if (value.Trim().ToUpper().Equals("CAMPO"))
                    st_campo = "0";
                else if (value.Trim().ToUpper().Equals("CODIGO BARRA"))
                    st_campo = "1";
                else
                    st_campo = string.Empty;
            }
        }
        public string Tp_Fonte { get; set; } = string.Empty;
        public decimal coluna { get; set; } = decimal.Zero;
        public string tipo_fonte
        {
            get
            {
                if (Tp_Fonte.Equals("0"))
                    return ""; 
                else
                    return string.Empty;
            }
            set
            {
                if (value.Equals(""))
                    Tp_Fonte = "0"; 
                else
                    Tp_Fonte = string.Empty;
            }
        }


    }

    public class TList_CamposEtiqueta : List<TRegistro_CamposEtiqueta> { }

    public class TCD_CamposEtiqueta : TDataQuery
    {
        public override DataTable Buscar(TpBusca[] vBusca, short vTop, string vNM_Campo, string vGroup, string vOrder, Hashtable vParametros)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo, vGroup, vOrder), vParametros);
        }

        public override DataTable Buscar(TpBusca[] vBusca, Int16 vTop)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, "", "", ""), null);
        }

        public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
        {
            return ExecutarBuscaEscalar(SqlCodeBusca(vBusca, 1, vNM_Campo, "", ""), null);
        }

        private string SqlCodeBusca(TpBusca[] vBusca, Int16 vTop, string vNM_Campo, string vGroup, string vOrder)
        {
            string strTop = "";
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();

            if (vNM_Campo.Trim().Equals(string.Empty))
            {
                sql.AppendLine("Select " + strTop + "a.id_layout, a.id_campo, a.ds_campo, a.posx, a.posy, a.tp_fonte, a.tp_campo ,a.coluna");
            }
            else
                sql.AppendLine("Select " + strTop + "" + vNM_Campo + "");

            sql.AppendLine("FROM TB_DIV_CamposEtiqueta a "); 

            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < vBusca.Length; i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + ")");
                    cond = " and ";
                }
            if (vGroup.Trim() != string.Empty)
                sql.AppendLine("group by " + vGroup.Trim());
            if (vOrder.Trim() != string.Empty)
                sql.AppendLine("order by " + vOrder.Trim());
            return sql.ToString();
        }

        public TList_CamposEtiqueta Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo, string vOrder)
        {
            TList_CamposEtiqueta lista = new TList_CamposEtiqueta();
            SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
            {
                this.CriarBanco_Dados(false);
                podeFecharBco = true;
            }
            reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), "", "", vOrder));
            try
            {
                while (reader.Read())
                {
                    TRegistro_CamposEtiqueta cadMenu = new TRegistro_CamposEtiqueta();
                    if (!reader.IsDBNull(reader.GetOrdinal("id_layout")))
                        cadMenu.Id_layout = reader.GetDecimal(reader.GetOrdinal("id_layout"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_campo")))
                        cadMenu.Id_campo = reader.GetDecimal(reader.GetOrdinal("id_campo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_campo")))
                        cadMenu.ds_campo = reader.GetString(reader.GetOrdinal("ds_campo")).Trim();
                    if (!reader.IsDBNull(reader.GetOrdinal("posx")))
                        cadMenu.posx= reader.GetDecimal(reader.GetOrdinal("posx"));
                    if (!reader.IsDBNull(reader.GetOrdinal("posy")))
                        cadMenu.posy = reader.GetDecimal(reader.GetOrdinal("posy"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_campo")))
                        cadMenu.St_campo = reader.GetString(reader.GetOrdinal("tp_campo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Tp_Fonte")))
                        cadMenu.Tp_Fonte = reader.GetString(reader.GetOrdinal("Tp_Fonte"));
                    if (!reader.IsDBNull(reader.GetOrdinal("coluna")))
                        cadMenu.coluna = reader.GetDecimal(reader.GetOrdinal("coluna"));

                    lista.Add(cadMenu);
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

        public string GravarMenu(TRegistro_CamposEtiqueta val)
        {
            Hashtable hs = new Hashtable(7);
            hs.Add("@P_ID_LAYOUT", val.Id_layout);
            hs.Add("@P_DS_CAMPO", val.ds_campo);
            hs.Add("@P_ID_CAMPO", val.Id_campo);
            hs.Add("@P_POSY", val.posy);
            hs.Add("@P_POSX", val.posx);
            hs.Add("@P_TP_CAMPO", val.St_campo);
            hs.Add("@P_TP_FONTE", val.Tp_Fonte);
            hs.Add("@P_COLUNA", val.coluna.ToString("N0", new System.Globalization.CultureInfo("en-US")));

            return executarProc("IA_DIV_CAMPOSETIQUETA", hs);
        }

        public string DeletarMenu(TRegistro_CamposEtiqueta val)
        {
            Hashtable hs = new Hashtable(1);
            hs.Add("@P_ID_LAYOUT", val.Id_layout);
            hs.Add("@P_ID_CAMPO", val.Id_campostr);
            return this.executarProc("EXCLUI_DIV_CAMPOSETIQUETA", hs);
        }


    }
#endregion
}
