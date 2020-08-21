using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using System.Collections;
using System.Drawing;

namespace CamadaDados.Servicos.Cadastros
{
    public class TList_OSE_SerialClifor : List<TRegistro_OSE_SerialClifor>
    { }
    
    
    public class TRegistro_OSE_SerialClifor
    {
        private decimal? id_serial;
        
        public decimal? Id_serial
        {
            get { return id_serial; }
            set { id_serial = value; }
        }

        private string _CD_Clifor;
        
        public string CD_Clifor
        {
            get { return _CD_Clifor; }
            set { _CD_Clifor = value; }
        }

        private string _CD_Produto;
        
        public string CD_Produto
        {
            get { return _CD_Produto; }
            set { _CD_Produto = value; }
        }

        private string _NM_Clifor;
        
        public string NM_Clifor
        {
            get { return _NM_Clifor; }
            set { _NM_Clifor = value; }
        }

        private string _DS_PRODUTO;
        
        public string DS_PRODUTO
        {
            get { return _DS_PRODUTO; }
            set { _DS_PRODUTO = value; }
        }

        private string _NR_Serial;
        
        public string NR_Serial
        {
            get { return _NR_Serial; }
            set { _NR_Serial = value; }
        }

        private string _DS_Observacao;
        
        public string DS_Observacao
        {
            get { return _DS_Observacao; }
            set { _DS_Observacao = value; }
        }
        
        public string St_registro
        { get; set; }

        private DateTime? dt_inigarantia;
        
        public DateTime? Dt_inigarantia
        {
            get { return dt_inigarantia; }
            set
            {
                dt_inigarantia = value;
                dt_inigarantiastring = (value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty);
            }
        }

        private string dt_inigarantiastring;
        public string Dt_inigarantiastring
        {
            get 
            {
                try
                {
                    return Convert.ToDateTime(dt_inigarantiastring).ToString("dd/MM/yyyy");
                }
                catch
                { return string.Empty; }
            }
            set
            {
                dt_inigarantiastring = value;
                try
                {
                    dt_inigarantia = Convert.ToDateTime(value);
                }
                catch
                { dt_inigarantia = null; }
            }
        }

       public TRegistro_OSE_SerialClifor()
       {
           this.id_serial = 0;
           _CD_Clifor = string.Empty;
           _NM_Clifor = string.Empty;
           _NR_Serial = string.Empty;
           _DS_Observacao = string.Empty;
           dt_inigarantia = null;
           dt_inigarantiastring = string.Empty;
           this.St_registro = "A";
       }
    }

    public class TCD_OSE_SerialClifor : TDataQuery
    {
        private string SqlCodeBusca(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = "";
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();

            if (vNM_Campo.Length == 0)
            {
                sql.AppendLine(" SELECT " + strTop + " a.id_serial, a.CD_Clifor, b.nm_Clifor, a.NR_Serial, ");
                sql.AppendLine("c.CD_Produto,c.DS_Produto, a.ds_Observacao, a.st_registro, a.dt_inigarantia ");
            }

            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine(" FROM TB_OSE_SerialClifor a");
            sql.AppendLine(" left outer join TB_fin_clifor b on b.cd_clifor = a.cd_clifor");
            sql.AppendLine(" left outer join TB_EST_Produto c on c.cd_Produto = a.cd_Produto");


            
            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.Append(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                    cond = " and ";
                }
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

        public TList_OSE_SerialClifor Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_OSE_SerialClifor lista = new TList_OSE_SerialClifor();
            bool podeFecharBco = false;
            if (Banco_Dados == null)
            {
                this.CriarBanco_Dados(true);
                podeFecharBco = true;
            }
            SqlDataReader reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_OSE_SerialClifor reg = new TRegistro_OSE_SerialClifor();

                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Serial")))
                        reg.Id_serial = reader.GetDecimal(reader.GetOrdinal("ID_Serial"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NR_Serial")))
                        reg.NR_Serial = reader.GetString(reader.GetOrdinal("NR_Serial"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_CLIFOR")))
                        reg.CD_Clifor = reader.GetString(reader.GetOrdinal("CD_CLIFOR"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NM_CLIFOR")))
                        reg.NM_Clifor = reader.GetString(reader.GetOrdinal("NM_CLIFOR"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_PRODUTO")))
                        reg.CD_Produto = reader.GetString(reader.GetOrdinal("CD_PRODUTO"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_PRODUTO")))
                        reg.DS_PRODUTO = reader.GetString(reader.GetOrdinal("DS_PRODUTO"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Observacao")))
                        reg.DS_Observacao = reader.GetString(reader.GetOrdinal("DS_Observacao"));
                    if(!reader.IsDBNull(reader.GetOrdinal("ST_Registro")))
                        reg.St_registro = reader.GetString(reader.GetOrdinal("ST_registro"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DT_IniGarantia")))
                        reg.Dt_inigarantia = reader.GetDateTime(reader.GetOrdinal("DT_IniGarantia"));
                    
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

        public string Grava(TRegistro_OSE_SerialClifor vRegistro)
        {
            Hashtable hs = new Hashtable(7);
            hs.Add("@P_ID_SERIAL", vRegistro.Id_serial);
            hs.Add("@P_NR_SERIAL", vRegistro.NR_Serial);
            hs.Add("@P_CD_CLIFOR", vRegistro.CD_Clifor); 
            hs.Add("@P_CD_PRODUTO", vRegistro.CD_Produto);
            hs.Add("@P_DS_OBSERVACAO", vRegistro.DS_Observacao);
            hs.Add("@P_ST_REGISTRO", vRegistro.St_registro);
            hs.Add("@P_DT_INIGARANTIA", vRegistro.Dt_inigarantia);

            return this.executarProc("IA_OSE_SERIALCLIFOR", hs);
        }

        public string Deleta(TRegistro_OSE_SerialClifor vRegistro) 
        {
            Hashtable hs = new Hashtable(1);
            hs.Add("@P_ID_SERIAL", vRegistro.Id_serial);

            return this.executarProc("EXCLUI_OSE_SERIALCLIFOR", hs);
        }
    }
    
}
