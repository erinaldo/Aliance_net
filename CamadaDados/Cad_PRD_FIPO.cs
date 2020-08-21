using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Utils;
using Querys;
using CamadaDados.Producao.Cadastros;

namespace CamadaDados.Producao.Cadastros
{
    public class TList_Cad_PRD_FIPO : List<TRegistro_Cad_PRD_FIPO>
    { }

    public class TRegistro_Cad_PRD_FIPO
    {
        private string cd_empresa;
        public string Cd_empresa
        {
            get { return cd_empresa; }
            set { cd_empresa = value; }
        }

        private string nm_empresa;
        public string Nm_empresa
        {
            get { return nm_empresa; }
            set { nm_empresa = value; }
        }

        private decimal id_po;
        public decimal Id_po
        {
            get { return id_po; }
            set { id_po = value; }
        }

        private string ds_postooperativo;
        public string Ds_postooperativo
        {
            get { return ds_postooperativo; }
            set { ds_postooperativo = value; }
        }

        private decimal id_ice;
        public decimal Id_ice
        {
            get { return id_ice; }
            set { id_ice = value; }
        }

        private string ds_itemcustoesforco;
        public string Ds_itemcustoesforco
        {
            get { return ds_itemcustoesforco; }
            set { ds_itemcustoesforco = value; }
        }

        private string sigla;
        public string Sigla
        {
            get { return sigla; }
            set { sigla = value; }
        }

        private decimal vl_porhora;
        public decimal Vl_porhora
        {
            get { return vl_porhora; }
            set { vl_porhora = value; }
        }

        public decimal vl_porminuto
        {
            get { return vl_porhora / 60; }
            set { vl_porhora = value * 60; }
        }

        public decimal vl_porsegundo
        {
            get { return vl_porhora / 120; }
            set { vl_porhora = value * 120; }
        }

        public TRegistro_Cad_PRD_FIPO()
        {
            this.cd_empresa = string.Empty;
            this.nm_empresa = string.Empty;
            this.id_po = 0;
            this.ds_postooperativo = string.Empty;
            this.id_ice = 0;
            this.ds_itemcustoesforco = string.Empty;
            this.sigla = string.Empty;
            this.vl_porhora = 0;
        }
    }

    public class TCD_Cad_PRD_FIPO : TDataQuery
    {
        private string Sql_CrossTable(string vCD_Empresa)
        {
            if (vCD_Empresa != "")
            {
                StringBuilder sql = new StringBuilder();

                TCD_CadItem_Custo_Esforco QTB_CustoEsforco = new TCD_CadItem_Custo_Esforco();
                DataTable tab = QTB_CustoEsforco.Buscar(null, 0);

                sql.AppendLine("Select a.id_po, a.ds_postooperativo ");
                for (int x = 0; x < tab.Rows.Count; x++)
                {
                    sql.AppendLine(", (select f.vl_porHora ");
                    sql.AppendLine("  from tb_prd_fipo f ");
                    sql.AppendLine("  where f.id_po = a.id_po ");
                    sql.AppendLine("   and f.cd_empresa = '" + vCD_Empresa + "'");
                    sql.AppendLine("   and f.id_ice = " + tab.Rows[x]["ID_ICE"].ToString() + ") as '" +
                                       tab.Rows[x]["ID_ICE"].ToString().PadLeft(5,'0') + tab.Rows[x]["Sigla"].ToString()+"'");
                };

                sql.AppendLine("From TB_PRD_PostoOperativo a ");

                return sql.ToString();
            }
            else
            {
                return "select null";
            }
        }

        private string SqlCodeBusca(TpBusca[] vBusca, Int16 vTop, string vNM_Campo)
        {
           
            string strTop = "";
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();

            if (vNM_Campo.Length == 0)
            {
                sql.AppendLine("Select " + strTop + " a.cd_empresa, b.nm_empresa, a.id_po, c.ds_postooperativo, ");
                sql.AppendLine("a.id_ice, d.ds_itemcustoesforco, d.sigla, a.vl_porhora ");
            }
            else
            {
                sql.Append("Select " + strTop + " " + vNM_Campo + " ");
            };

            sql.AppendLine("From TB_PRD_FIPO a ");
            sql.AppendLine("inner join TB_Empresa b ");
            sql.AppendLine("on a.cd_empresa = b.cd_empresa ");
            sql.AppendLine("inner join TB_PRD_PostoOperativo c ");
            sql.AppendLine("on a.id_po = c.id_po ");
            sql.AppendLine("inner join TB_PRD_Item_CustoEsforco d ");
            sql.AppendLine("on a.id_ice = d.id_ice ");
            
            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                    cond = " and ";
                }
            return sql.ToString();
        }

        private string SQL_FotoIndice(string vCD_Empresa, decimal vId_PO)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("select Vl_FotoIndice ");
            sql.AppendLine("from VTB_PRD_FotoIndice_PO");
            sql.AppendLine("where CD_Empresa = '" + vCD_Empresa + "'");
            sql.AppendLine("  and Id_PO = " + vId_PO.ToString());
            return sql.ToString();
        }

        public DataTable CrossTable(string vCD_Empresa)
        {
            
            return this.ExecutarBusca(this.Sql_CrossTable(vCD_Empresa),null);
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, ""),null);
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop, string vNM_Campo)
        {            
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo),null);
        }

        public string Buscar_FotoIndice(string vCD_Empresa, decimal vID_PO)
        {
            DataTable tab = ExecutarBusca(SQL_FotoIndice(vCD_Empresa, vID_PO) , null);
            if (tab.Rows.Count > 0)
            {
                return tab.Rows[0]["Vl_FotoIndice"].ToString();
            }
            else return "";        
        }

        public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
        {
            return this.ExecutarBuscaEscalar(this.SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }

        public TList_Cad_PRD_FIPO Select(TpBusca[] vBusca, Int16 vTop, string vNM_Campo)
        {
            TList_Cad_PRD_FIPO lista = new TList_Cad_PRD_FIPO();
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
                    reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, ""));
                else
                    reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo));

                while (reader.Read())
                {
                    TRegistro_Cad_PRD_FIPO reg = new TRegistro_Cad_PRD_FIPO();
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("CD_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NM_Empresa")))
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("NM_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_PO")))
                        reg.Id_po = reader.GetDecimal(reader.GetOrdinal("ID_PO"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_PostoOperativo")))
                        reg.Ds_postooperativo = reader.GetString(reader.GetOrdinal("DS_PostoOperativo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_ICE")))
                        reg.Id_ice = reader.GetDecimal(reader.GetOrdinal("ID_ICE"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_ItemCustoEsforco")))
                        reg.Ds_itemcustoesforco = reader.GetString(reader.GetOrdinal("DS_ItemCustoEsforco"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_porhora")))
                        reg.Vl_porhora = reader.GetDecimal(reader.GetOrdinal("Vl_PorHora"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Sigla")))
                        reg.Sigla = reader.GetString(reader.GetOrdinal("Sigla"));
                    lista.Add(reg);
                }
                return lista;
            }
            finally
            {
                if (podeFecharBco)
                    this.deletarBanco_Dados();
            }
        }


        public string Gravar_PRD_FIPO(TRegistro_Cad_PRD_FIPO val)
        {
            Hashtable hs = new Hashtable();
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_PO", val.Id_po);
            hs.Add("@P_ID_ICE", val.Id_ice);
            hs.Add("@P_VL_PORHORA", val.Vl_porhora);
            return executarProc("IA_PRD_FIPO", hs);

        }

        public string Deletar_PRD_FIPO(TRegistro_Cad_PRD_FIPO val)
        {
            Hashtable hs = new Hashtable();
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_PO", val.Id_po);
            hs.Add("@P_ID_ICE", val.Id_ice);
            return this.executarProc("EXCLUI_PRD_FIPO", hs);
        }

        

    }
}
