using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System;
using System.Data.SqlClient;
using Utils;
using Querys;

namespace CamadaDados.Producao.Cadastros
{

    public class TList_FIPB : List<TRegistro_FIPB>
    { }

    public class TRegistro_FIPB
    {
        private string cd_empresa;
        public string Cd_empresa
        {
            get { return cd_empresa; }
            set { cd_empresa = value; }
        }

        private string nm_Empresa;

        public string Nm_Empresa
        {
            get { return nm_Empresa; }
            set { nm_Empresa = value; }
        }
        
        private decimal? id_po;
        public decimal? Id_po
        {
            get { 
                if (id_po == 0)
                    return null;
                else
                    return id_po;
            }
            set { id_po = value;
                  id_poString = value.ToString();
            }
        }

        private string id_poString;
        public string Id_poString
        {
            get { return id_poString; }
            set
            {
                id_poString = value;
                try
                {
                    id_po = Convert.ToDecimal(value);
                }
                catch { id_po = null; }

            }
        }

        
        private string ds_PostoOperativo;
        public string Ds_PostoOperativo
        {
            get { return ds_PostoOperativo; }
            set { ds_PostoOperativo = value; }
        }

        private decimal foto_indice;
        public decimal Foto_indice
        {
            get { return foto_indice; }
            set { foto_indice = value;
                 vl_indice_base_un = foto_indice * tempo_h;
            }
        }
        private decimal tempo_m;

        public decimal Tempo_m
        {
            get { return tempo_m; }
            set { tempo_m = value;
            tempo_h = (tempo_m / 60);
            }
        }

        private decimal tempo_h;
        public decimal Tempo_h
        {
            get {                
                return tempo_h; 
            }
            set {
                tempo_h = value; 
                vl_indice_base_un = foto_indice * tempo_h;                
                tempo_m = (tempo_h * 60);
            }
        }
        
        private decimal vl_indice_base_un;
        public decimal Vl_indice_base_un
        {
            get {
                vl_indice_base_un = foto_indice * tempo_h;
                return vl_indice_base_un;
            }
            set { vl_indice_base_un = value; }
        }

        public TRegistro_FIPB()
        { 
            cd_empresa = "";
            nm_Empresa = "";
            id_po = 0;
            ds_PostoOperativo = "";
            foto_indice = 0;
            tempo_h = 0;
            vl_indice_base_un = 0;        
        }
    }

    public class TCD_FIPB : TDataQuery
    {
        public override DataTable Buscar(TpBusca[] vBusca, short vTop)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca,vTop,"") ,null);
        }

        public string SqlCodeBusca(TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            string cond = "", strtop = "";
            if (vTop > 0)
            {
                strtop = " top " + Convert.ToString(vTop);
            }
            StringBuilder sql = new StringBuilder();
            if (vNM_Campo != "") 
            {
                sql.Append("Select "+strtop+" "+vNM_Campo);
            }
            else
            {
                sql.Append("Select " + strtop + " cd_empresa ,foto_indice ,id_po ,tempo_h ,vl_indice_base_un, ");
                sql.Append("NM_Empresa = (select nm_empresa from tb_Empresa x where a.cd_empresa = x.cd_empresa), ");
                sql.Append("DS_PostoOperativo = (select ds_postoOperativo from tb_prd_PostoOperativo x where a.id_PO = x.id_po) "); 
            }
            sql.Append(" FROM TB_PRD_FIPB a");

            cond = " where ";
            if (vBusca != null)
                if (vBusca.Length > 0)
                    for (int i = 0; i < (vBusca.Length); i++)
                    {
                        sql.Append(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                        cond = " and ";
                    }
            return sql.ToString();                   
        }

        public TList_FIPB Select(TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            TList_FIPB lista = new TList_FIPB();
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
                    TRegistro_FIPB reg = new TRegistro_FIPB();
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_Empresa"))))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("CD_Empresa"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("NM_Empresa"))))
                        reg.Nm_Empresa = reader.GetString(reader.GetOrdinal("NM_Empresa"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("ID_PO"))))
                        reg.Id_po = reader.GetDecimal(reader.GetOrdinal("ID_PO"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("DS_PostoOperativo"))))
                        reg.Ds_PostoOperativo = reader.GetString(reader.GetOrdinal("DS_PostoOperatiVo"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("Foto_Indice"))))
                        reg.Foto_indice = reader.GetDecimal(reader.GetOrdinal("Foto_Indice"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("Tempo_h"))))
                        reg.Tempo_h = reader.GetDecimal(reader.GetOrdinal("Tempo_h"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("VL_Indice_base_un"))))
                        reg.Vl_indice_base_un = reader.GetDecimal(reader.GetOrdinal("VL_Indice_base_un"));
                    lista.Add(reg);
                }
            }
            finally
            {
                if (podeFecharBco)
                    this.deletarBanco_Dados();
            }
            return lista;
        }

        public string GravarFIPB(TRegistro_FIPB val)
        {
            Hashtable hs = new Hashtable();
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_PO", val.Id_po);
            hs.Add("@P_FOTO_INDICE", val.Foto_indice);
            hs.Add("@P_TEMPO_H", val.Tempo_h);
            hs.Add("@P_VL_INDICE_BASE_UN", val.Vl_indice_base_un);
            return executarProc("IA_PRD_FIPB", hs);
        }

        public string ExcluiFIPB(TRegistro_FIPB val)
        {
            Hashtable hs = new Hashtable(2);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_PO", val.Id_po);
            return executarProc("EXCLUI_PRD_FIPB", hs);       
        }
    }


}
