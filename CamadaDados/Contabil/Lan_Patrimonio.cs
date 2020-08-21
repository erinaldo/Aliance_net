using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;
using System.Data.SqlClient;
using System.Data;
using System.Collections;

namespace CamadaDados.Contabil
{
    public class TList_LanPatrimonio : List<TRegistro_LanPatrimonio> { }

    
    public class TRegistro_LanPatrimonio
    {
        private decimal? _ID_Patrimonio;
        
        public decimal? ID_Patrimonio
        {
            get { return _ID_Patrimonio; }
            set
            {
                _ID_Patrimonio = value;
                _ID_Patrimonio_String = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }

        private string _ID_Patrimonio_String;
        
        public string ID_Patrimonio_String
        {
            get { return _ID_Patrimonio_String; }
            set
            {
                _ID_Patrimonio_String = value;
                try
                {
                    _ID_Patrimonio = Convert.ToDecimal(value);
                }
                catch { _ID_Patrimonio = null; }

            }
        }
        
        public decimal ID_Lancto
        {
            get;
            set;
        }
        
        private decimal? _ID_LoteCTB;
        
        public decimal? ID_LoteCTB
        {
            get { return _ID_LoteCTB; }
            set
            {
                _ID_LoteCTB = value;
                _ID_LoteCTB_String = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }

        private string _ID_LoteCTB_String;
        
        public string ID_LoteCTB_String
        {
            get { return _ID_LoteCTB_String; }
            set
            {
                _ID_LoteCTB_String = value;
                try
                {
                    _ID_LoteCTB = Convert.ToDecimal(value);
                }
                catch { _ID_LoteCTB = null; }
            }
        }

        private DateTime? _DT_Lancto;
        
        public DateTime? DT_Lancto
        {
            get { return _DT_Lancto; }
            set
            {
                _DT_Lancto = value;
                _DT_Lancto_String = value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty;
            }
        }
      
        private string _DT_Lancto_String;
        public string DT_Lancto_String
        {
            get
            {
                try
                {
                    return Convert.ToDateTime(_DT_Lancto_String).ToString("dd/MM/yyyy");
                }
                catch
                { return string.Empty; }
            }
            set
            {
                _DT_Lancto_String = value;
                try
                {
                    _DT_Lancto = Convert.ToDateTime(value);
                }
                catch
                { _DT_Lancto = null; }
            }
        }
        
        public string CD_Empresa { get; set; }
        private decimal? cd_contacre;
        
        public decimal? CD_ContaCre 
        {
            get { return cd_contacre; }
            set
            {
                cd_contacre = value;
                cd_contacrestr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string cd_contacrestr;
        
        public string Cd_contacrestr
        {
            get 
            {
                if (cd_contacrestr.Trim().Equals("0"))
                    return string.Empty;
                else
                    return cd_contacrestr; 
            }
            set
            {
                cd_contacrestr = value;
                try
                {
                    cd_contacre = Convert.ToDecimal(value);
                }
                catch
                { cd_contacre = null; }
            }
        }
        private decimal? cd_contadeb;
        public decimal? CD_ContaDeb 
        {
            get { return cd_contadeb; }
            set
            {
                cd_contadeb = value;
                cd_contadebstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string cd_contadebstr;
        
        public string Cd_contadebstr
        {
            get 
            {
                if (cd_contadebstr.Trim().Equals("0"))
                    return string.Empty;
                else
                    return cd_contadebstr; 
            }
            set
            {
                cd_contadebstr = value;
                try
                {
                    cd_contadeb = Convert.ToDecimal(value);
                }
                catch
                { cd_contadeb = null; }
            }
        }
        
        public decimal VL_Lancto
        {
            get;
            set;
        }

        private string _TP_Lancto;
        
        public string TP_Lancto
        {
            get { return _TP_Lancto; }
            set
            {
                _TP_Lancto = value;
                if (value == "D")
                {
                    _TP_Lancto_Ext = "(D) - Deteriorização";
                }
                else
                {
                    if (value == "P")
                    {
                        _TP_Lancto_Ext = "(P) - Perca/Depreciação";
                    }
                    else
                    {
                        if (value == "V")
                        {
                            _TP_Lancto_Ext = "(V) - Venda";
                        }
                        else
                        {
                            if (value == "R")
                            {
                                _TP_Lancto_Ext = "(R) - Reavaliação";
                            }
                        }

                    }
                }
            }
        }

        private string _TP_Lancto_Ext;
        
        public string TP_Lancto_Ext
        {
            get { return _TP_Lancto_Ext; }
            set
            {
                _TP_Lancto_Ext = value;
                if (value == "(D) - Deteriorização")
                {
                    _TP_Lancto_Ext = "D";
                }
                else
                {
                    if (value == "(P) - Perca")
                    {
                        _TP_Lancto_Ext = "P";
                    }
                    else
                    {
                        if (value == "(V) - Venda")
                        {
                            _TP_Lancto_Ext = "V";
                        }
                        else
                        {
                            if (value == "(R) - Reavaliação")
                            {
                                _TP_Lancto_Ext = "R";
                            }
                        }

                    }
                }

            }
        }
        
        public string DS_Patrimonio { get; set; }

        private decimal? _ID_GrupoPatrim;
        
        public decimal? ID_GrupoPatrim
        {
            get { return _ID_GrupoPatrim; }
            set
            {
                _ID_GrupoPatrim = value;
                _ID_GrupoPatrim_String = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }

        private string _ID_GrupoPatrim_String;
        
        public string ID_GrupoPatrim_String
        {
            get { return _ID_GrupoPatrim_String; }
            set
            {
                _ID_GrupoPatrim_String = value;
                try
                {
                    _ID_GrupoPatrim = Convert.ToDecimal(value);
                }
                catch { _ID_GrupoPatrim = null; }

            }
        }
        
        public string DS_GrupoPatrim { get; set; }
        
        public decimal Nr_Docto { get; set; }
        
        public bool St_processar
        { get; set; }

        public TRegistro_LanPatrimonio()
        {
            _ID_Patrimonio = null;
            _ID_Patrimonio_String = string.Empty;
            ID_Lancto = decimal.Zero;
            _DT_Lancto = null;
            _DT_Lancto_String = string.Empty; 
            VL_Lancto = decimal.Zero;
            _TP_Lancto = "P";
            DS_Patrimonio = string.Empty;
            ID_GrupoPatrim = null;
            ID_GrupoPatrim_String = string.Empty;
            DS_GrupoPatrim = string.Empty;
            Nr_Docto = decimal.Zero;
            cd_contacre = null;
            cd_contacrestr = string.Empty;
            cd_contadeb = null;
            cd_contadebstr = string.Empty;
            this._ID_LoteCTB = null;
            this._ID_LoteCTB_String = string.Empty;
            TP_Lancto = "P";
            TP_Lancto_Ext = "(P) - Perca/Depreciação";
            this.St_processar = false;
        }
    }

    public class TCD_LanPatrimonio : TDataQuery
    {
        public TCD_LanPatrimonio()
        { }

        public TCD_LanPatrimonio(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = "";
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();

            if (vNM_Campo.Length == 0)
            {
                sql.AppendLine("SELECT " + strTop + " a.id_Patrimonio, a.ID_Lancto, a.id_LoteCTB, a.DT_Lancto, a.VL_Lancto, a.TP_Lancto, ");
                sql.AppendLine("b.DS_Patrimonio, c.ID_GrupoPatrim, c.DS_GrupoPatrim, b.Nr_Docto, b.CD_Empresa, ");
                sql.AppendLine("dbo.F_CTB_PATRIMONIO('C',b.CD_Empresa, a.TP_Lancto, c.ID_GrupoPatrim, a.id_Patrimonio) AS CD_CONTACTB_CRE, ");
                sql.AppendLine("dbo.F_CTB_PATRIMONIO('D',b.CD_Empresa, a.TP_Lancto, c.ID_GrupoPatrim, a.id_Patrimonio) AS CD_CONTACTB_DEB ");
            }
            else
                sql.AppendLine("SELECT " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("FROM TB_CTB_Lancto_Patrimonio a ");
            sql.AppendLine("INNER JOIN TB_CTB_Patrimonio b ");
            sql.AppendLine("ON a.id_Patrimonio = b.id_Patrimonio ");
            sql.AppendLine("LEFT OUTER JOIN TB_CTB_GrupoPatrimonio c ");
            sql.AppendLine("ON b.ID_GrupoPatrim = c.ID_GrupoPatrim ");

            string cond = " WHERE ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.Append(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                    cond = " AND ";
                }

            return sql.ToString();
        }
        
        public DataTable SqlCodeBusca_LanTodosPatrimonios(TpBusca[] vBusca, string DT_Lancto, Int32 vTop, string vNM_Campo)
        {
            DataTable DT = new DataTable(); 
            
            bool podeFecharBco = false;
            if (Banco_Dados == null)
            {
                this.CriarBanco_Dados(false);
                podeFecharBco = true;
            }

            try
            {

                string strTop = "";
                if (vTop > 0)
                    strTop = "TOP " + Convert.ToString(vTop);
                StringBuilder sql = new StringBuilder();

                if (vNM_Campo.Length == 0)
                {
                    sql.AppendLine(" SELECT " + strTop);
                    sql.AppendLine(" a.id_patrimonio, a.ds_patrimonio, a.vl_reposicao, sum(isnull(b.vl_lancto,0)) as Vl_Depreciado, ");
                    sql.AppendLine(" (a.vl_reposicao - sum(isnull(b.vl_lancto,0))) as Vl_Mercado, a.DT_Lancto, ");
                    sql.AppendLine(" ROUND( (a.vl_reposicao * (convert(numeric(10),( ");
                    sql.AppendLine( DT_Lancto + " - a.DT_lancto))  ");
                    sql.AppendLine(" / (a.Tempo_VidaUtil * 365))) ,2) - sum(isnull(b.vl_lancto,0)) as Vl_Lancto ");
                 }
                else
                    sql.AppendLine("SELECT " + strTop + " " + vNM_Campo + " ");
                 
                sql.AppendLine(" FROM ");
                sql.AppendLine(" tb_ctb_patrimonio a ");
                sql.AppendLine(" left outer join tb_ctb_lancto_patrimonio b on a.id_patrimonio = b.id_patrimonio ");
                

                string cond = " WHERE ";
                if (vBusca != null)
                    for (int i = 0; i < (vBusca.Length); i++)
                    {
                        sql.Append(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                        cond = " AND ";
                    }

                sql.AppendLine(" group by a.id_patrimonio, a.ds_patrimonio, a.vl_reposicao, a.Tempo_VidaUtil, a.dt_lancto ");

                DT = this.ExecutarBusca(sql.ToString(), null); ;
            }
            finally
            {
                if (podeFecharBco)
                    this.deletarBanco_Dados();
            }

            return DT;
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, ""), null);
        }

        public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
        {
            return this.ExecutarBuscaEscalar(this.SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }

        public TList_LanPatrimonio Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_LanPatrimonio lista = new TList_LanPatrimonio();
            SqlDataReader reader;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
            {
                this.CriarBanco_Dados(false);
                podeFecharBco = true;
            }

            try
            {
                reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
                while (reader.Read())
                {
                    TRegistro_LanPatrimonio reg = new TRegistro_LanPatrimonio();
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Patrimonio")))
                        reg.ID_Patrimonio = reader.GetDecimal(reader.GetOrdinal("ID_Patrimonio"));                    
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Lancto")))
                        reg.ID_Lancto = reader.GetDecimal(reader.GetOrdinal("ID_Lancto"));                    
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_LoteCTB")))
                        reg.ID_LoteCTB = reader.GetDecimal(reader.GetOrdinal("ID_LoteCTB"));       
                    if (!reader.IsDBNull(reader.GetOrdinal("DT_Lancto")))
                        reg.DT_Lancto = reader.GetDateTime(reader.GetOrdinal("DT_Lancto"));  
                    if (!reader.IsDBNull(reader.GetOrdinal("VL_Lancto")))
                        reg.VL_Lancto = reader.GetDecimal(reader.GetOrdinal("VL_Lancto"));  
                    if (!reader.IsDBNull(reader.GetOrdinal("TP_Lancto")))
                        reg.TP_Lancto = reader.GetString(reader.GetOrdinal("TP_Lancto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Patrimonio")))
                        reg.DS_Patrimonio = reader.GetString(reader.GetOrdinal("DS_Patrimonio"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_GrupoPatrim")))
                        reg.ID_GrupoPatrim = reader.GetDecimal(reader.GetOrdinal("ID_GrupoPatrim"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_GrupoPatrim")))
                        reg.DS_GrupoPatrim = reader.GetString(reader.GetOrdinal("DS_GrupoPatrim"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Nr_Docto")))
                        reg.Nr_Docto = reader.GetDecimal(reader.GetOrdinal("Nr_Docto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_CONTACTB_CRE")))
                        reg.CD_ContaCre = reader.GetDecimal(reader.GetOrdinal("CD_CONTACTB_CRE"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_CONTACTB_DEB")))
                        reg.CD_ContaDeb = reader.GetDecimal(reader.GetOrdinal("CD_CONTACTB_DEB"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Empresa")))
                        reg.CD_Empresa = reader.GetString(reader.GetOrdinal("CD_Empresa"));
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

        public string Grava(TRegistro_LanPatrimonio vRegistro)
        {
            Hashtable hs = new Hashtable(6);
            
            hs.Add("@P_ID_PATRIMONIO", vRegistro.ID_Patrimonio);
            hs.Add("@P_ID_LANCTO", vRegistro.ID_Lancto);
            hs.Add("@P_ID_LOTECTB", vRegistro.ID_LoteCTB);
            hs.Add("@P_DT_LANCTO", vRegistro.DT_Lancto);
            hs.Add("@P_VL_LANCTO", vRegistro.VL_Lancto);
            hs.Add("@P_TP_LANCTO", vRegistro.TP_Lancto);
            
            return this.executarProc("IA_CTB_LANCTO_PATRIMONIO", hs);
        }

        public string AtualizaLotePatrimonio(TRegistro_LanPatrimonio vRegistro)
        {
            Hashtable hs = new Hashtable(2);

            hs.Add("@P_ID_PATRIMONIO", vRegistro.ID_Patrimonio);
            hs.Add("@P_ID_LOTECTB", vRegistro.ID_LoteCTB);
            
            return this.executarProc("ATUALIZA_LOTE_LANCTO_PATRIMONIO", hs);
        }

        public string Deleta(TRegistro_LanPatrimonio vRegistro)
        {
            Hashtable hs = new Hashtable(2);
            hs.Add("@P_ID_PATRIMONIO", vRegistro.ID_Patrimonio);
            hs.Add("@P_ID_LANCTO", vRegistro.ID_Lancto);
            return this.executarProc("EXCLUI_CTB_LANCTOPATRIMONIO", hs);
        }
    }
}
