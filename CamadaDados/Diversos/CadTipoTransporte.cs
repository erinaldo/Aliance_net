using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;
using System.Collections;
using System.Data.SqlClient;
using System.Data;



namespace CamadaDados.Diversos
{
    public class TList_CadTipoTransporte : List<TRegistro_CadTipoTransporte>
    {
    }
    public class TRegistro_CadTipoTransporte
    {
        private decimal? _Id_TpTransp;
        public decimal? Id_TpTransp
        {
            get { return _Id_TpTransp; }
            set { 
                _Id_TpTransp = value;
                _Id_TpTranspString = value.ToString();
            }
        }
        private string _Id_TpTranspString;
        public string Id_TpTranspString
        {
            get { return _Id_TpTranspString; }
            set { 
                _Id_TpTranspString = value;
                try 
                {
                    Id_TpTransp = Convert.ToDecimal(value);
                
                }
                catch { _Id_TpTransp = null;}
            }
        }
        public string Ds_tptransp { get; set; }
        public string Cd_transportadora
        { get; set; }
        public string Ds_transportadora
        { get; set; }

        public TRegistro_CadTipoTransporte()
        {
            this.Id_TpTransp = null;
            this.Id_TpTranspString = string.Empty;
            this.Ds_tptransp = string.Empty;
            this.Cd_transportadora = string.Empty;
            this.Ds_transportadora = string.Empty;
        }
    }
    public class TCD_CadTipoTransporte : TDataQuery
    {
        private string SqlCodeBusca(TpBusca[] vBusca, Int32 vTop, string vNm_Campo)
        {
            string strTop = "";
            if (vTop > 0)
                strTop = " TOP" + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();
            if (vNm_Campo.Length == 0)
            {
                sql.AppendLine(" Select " + strTop + " a.id_tptransp,a.ds_tptransp, ");
                sql.AppendLine("a.cd_transportadora, b.nm_clifor as ds_transportadora ");
            }
            else
                sql.AppendLine(" Select " + strTop + " " + vNm_Campo + " ");
            sql.AppendLine("From tb_div_tptransporte a ");
            sql.AppendLine("left outer join tb_fin_clifor b ");
            sql.AppendLine("on a.cd_transportadora = b.cd_clifor ");
            string cond = "where";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + ") ");
                    cond = "and";
                }
            sql.AppendLine("Order By ds_tptransp");
            return sql.ToString();

        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, 0, ""), null);
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo), null);
        }

        public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
        {
            return this.ExecutarBuscaEscalar(this.SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }

        public TList_CadTipoTransporte Select(TpBusca[] vBusca, Int32 vTop, string vNm_Campo)
        {
            TList_CadTipoTransporte lista = new TList_CadTipoTransporte();
            SqlDataReader reader;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
            {
                this.CriarBanco_Dados(false);
                podeFecharBco = true;
            }
            try
            {
                reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNm_Campo));
                while (reader.Read())
                {
                    TRegistro_CadTipoTransporte reg = new TRegistro_CadTipoTransporte();
                    if (!(reader.IsDBNull(reader.GetOrdinal("ID_TpTransp"))))
                        reg.Id_TpTransp = reader.GetDecimal(reader.GetOrdinal("ID_TpTransp"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("DS_TpTransp"))))
                        reg.Ds_tptransp = reader.GetString(reader.GetOrdinal("DS_TpTransp"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Transportadora")))
                        reg.Cd_transportadora = reader.GetString(reader.GetOrdinal("CD_Transportadora"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Transportadora")))
                        reg.Ds_transportadora = reader.GetString(reader.GetOrdinal("DS_Transportadora"));
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

        public string GravaCadTipoTranporte(TRegistro_CadTipoTransporte val)
        {
            Hashtable hs = new Hashtable(3);
            hs.Add("@P_ID_TPTRANSP", val.Id_TpTransp);
            hs.Add("@P_DS_TPTRANSP", val.Ds_tptransp);
            hs.Add("@P_CD_TRANSPORTADORA", val.Cd_transportadora);

            return this.executarProc("IA_DIV_TPTRANSPORTE", hs);
        }

        public string DeletaCadTipoTransporte(TRegistro_CadTipoTransporte val)
        {
            Hashtable hs = new Hashtable(1);
            hs.Add("@P_ID_TPTRANSP", val.Id_TpTransp);
            return this.executarProc("EXCLUI_DIV_TPTRANSPORTE", hs);
        }
    }
}

  
    