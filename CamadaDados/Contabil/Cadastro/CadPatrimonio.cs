using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using Utils;
using System.Data;
using System.Collections;

namespace CamadaDados.Contabil.Cadastro
{
    public class TList_CadPatrimonio : List<TRegistro_CadPatrimonio>
    { }

    public class TRegistro_CadPatrimonio
    {
        private decimal? _ID_Patrimonio;
        public decimal? ID_Patrimonio
        {
            get
            {
                if (_ID_Patrimonio == 0)
                    return null;
                else
                    return _ID_Patrimonio;
            }
            set
            {
                _ID_Patrimonio = value;
                _ID_Patrimonio_String = value.ToString();
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

        private string _CD_Empresa;
        public string CD_Empresa
        {
            get { return _CD_Empresa; }
            set { _CD_Empresa = value; }
        }

        private string _NM_Empresa;
        public string NM_Empresa
        {
            get { return _NM_Empresa; }
            set { _NM_Empresa = value; }
        }


        private decimal? _ID_GrupoPatrim;
        public decimal? ID_GrupoPatrim
        {
            get
            {
                if (_ID_GrupoPatrim == 0)
                    return null;
                else
                    return _ID_GrupoPatrim;
            }
            set
            {
                _ID_GrupoPatrim = value;
                _ID_GrupoPatrim_String = value.ToString();
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

        private string _DS_GrupoPatrim;
        public string DS_GrupoPatrim
        {
            get { return _DS_GrupoPatrim; }
            set
            {_DS_GrupoPatrim = value;}
        }

        private decimal _NR_Docto;
        public decimal NR_Docto
        {
            get { return _NR_Docto; }
            set { _NR_Docto = value; }
        }

        private DateTime? _DT_Docto;
        public DateTime? DT_Docto
        {
            get { return _DT_Docto; }
            set { _DT_Docto = value;
                  _DT_Docto_String = value.ToString();
            }
        }

        private string _DT_Docto_String;
        public string DT_Docto_String
        {
            get { 
                try
                {
                    return Convert.ToDateTime(_DT_Docto_String).ToString("dd/MM/yyyy");
                }
                catch
                { return ""; }
            
            }
            set { _DT_Docto_String = value;
                try
                {
                    _DT_Docto = Convert.ToDateTime(value);
                }
                catch
                { _DT_Docto = null; }
            
            }
        }

        private string _NM_Fornecedor;
        public string NM_Fornecedor
        {
            get { return _NM_Fornecedor; }
            set { _NM_Fornecedor = value; }
        }

        private string _DS_Setor;
        public string DS_Setor
        {
            get { return _DS_Setor; }
            set { _DS_Setor = value; }
        }

        private string _DS_Patrimonio;
        public string DS_Patrimonio
        {
            get { return _DS_Patrimonio; }
            set { _DS_Patrimonio = value; }
        }

        private decimal _VL_Reposicao;
        public decimal VL_Reposicao
        {
            get { return _VL_Reposicao; }
            set { _VL_Reposicao = value; }
        }

        private decimal _VL_Mercado;
        public decimal VL_Mercado
        {
            get { return _VL_Mercado; }
            set { _VL_Mercado = value; }
        }

        private decimal _Tempo_VidaUtil;
        public decimal Tempo_VidaUtil
        {
            get { return _Tempo_VidaUtil; }
            set { _Tempo_VidaUtil = value; }
        }

        private decimal _Tempo_Saldo;
        public decimal Tempo_Saldo
        {
            get { return _Tempo_Saldo; }
            set { _Tempo_Saldo = value; }
        }        

        private DateTime? _DT_Lancto;
        public DateTime? DT_Lancto
        {
            get { return _DT_Lancto; }
            set { _DT_Lancto = value;
            _DT_Lancto_String = value.ToString();
            }
        }
        
        private string _DT_Lancto_String;
        public string DT_Lancto_String
        {
            get {
                try
                {
                    return Convert.ToDateTime(_DT_Lancto_String).ToString("dd/MM/yyyy");
                }
                catch
                { return ""; }
            
            }
            set { _DT_Lancto_String = value;
                    try
                    {
                        _DT_Lancto = Convert.ToDateTime(value);
                    }
                    catch
                    { _DT_Lancto = null; }
            }
        }        

        private string _ST_Imobilizado;
        public string ST_Imobilizado
        {
            get { return _ST_Imobilizado; }
            set { _ST_Imobilizado = value;
                if (_ST_Imobilizado == "S")
                {
                    _ST_Imobilizado_Bool = true;
                }
                else
                {
                    _ST_Imobilizado_Bool = false;
                }
            }
        }

        private bool _ST_Imobilizado_Bool;
        public bool ST_Imobilizado_Bool
        {
            get { return _ST_Imobilizado_Bool; }
            set { _ST_Imobilizado_Bool = value;
                if (_ST_Imobilizado_Bool == true)
                {
                    _ST_Imobilizado = "S";
                }
                else
                {
                    _ST_Imobilizado = "N";
                }
            
            }
        }

        public TRegistro_CadPatrimonio()
        {
            _ID_Patrimonio = null;
            _ID_Patrimonio_String = string.Empty;
            _CD_Empresa = string.Empty;
            _ID_GrupoPatrim = null; 
            _ID_GrupoPatrim_String = string.Empty;
            _DS_GrupoPatrim = string.Empty;
            _NR_Docto = decimal.Zero;
            _DT_Docto = null; 
            _DT_Docto_String = string.Empty;
            _NM_Fornecedor = string.Empty;
            _DS_Setor = string.Empty;
            _DS_Patrimonio = string.Empty;
            _VL_Reposicao = decimal.Zero;
            _VL_Mercado = decimal.Zero;
            _Tempo_VidaUtil = decimal.Zero;
            _Tempo_Saldo = decimal.Zero;
            _DT_Lancto = DateTime.Now;
            _DT_Lancto_String = DateTime.Now.ToString();
            _ST_Imobilizado = string.Empty;
        }
    }

    public class TCD_CadPatrimonio : TDataQuery
    {
        private string SqlCodeBusca(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = "";
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();

            if (vNM_Campo.Length == 0)
            {
                sql.AppendLine(" SELECT " + strTop);
                sql.AppendLine(" a.id_Patrimonio, a.CD_Empresa, b.NM_Empresa, a.ID_GrupoPatrim, c.ds_grupopatrim, a.NR_Docto, a.DT_Docto,");
                sql.AppendLine(" a.NM_Fornecedor, a.DS_Setor, a.DS_Patrimonio, a.VL_Reposicao, ");
                sql.AppendLine(" a.VL_Mercado, a.Tempo_VidaUtil, a.Tempo_Saldo, a.DT_Lancto,  ");
                sql.AppendLine(" a.ST_Imobilizado ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine(" FROM ");
            sql.AppendLine(" TB_CTB_Patrimonio a ");
            sql.AppendLine(" left outer join TB_DIV_Empresa b on (b.cd_empresa = a.cd_empresa)");
            sql.AppendLine(" left outer join TB_CTB_GrupoPatrimonio c on (c.id_Grupopatrim = a.id_grupopatrim)");

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

        public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
        {
            return this.ExecutarBuscaEscalar(this.SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }
        
        public TList_CadPatrimonio Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_CadPatrimonio lista = new TList_CadPatrimonio();
            SqlDataReader reader = null;
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
                    TRegistro_CadPatrimonio reg = new TRegistro_CadPatrimonio();
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Patrimonio")))
                        reg.ID_Patrimonio = reader.GetDecimal(reader.GetOrdinal("ID_Patrimonio"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Empresa")))
                        reg.CD_Empresa = reader.GetString(reader.GetOrdinal("CD_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NM_Empresa")))
                        reg.NM_Empresa = reader.GetString(reader.GetOrdinal("NM_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_GrupoPatrim")))
                        reg.ID_GrupoPatrim = reader.GetDecimal(reader.GetOrdinal("ID_GrupoPatrim"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_GrupoPatrim")))
                        reg.DS_GrupoPatrim = reader.GetString(reader.GetOrdinal("DS_GrupoPatrim"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NR_Docto")))
                        reg.NR_Docto = reader.GetDecimal(reader.GetOrdinal("NR_Docto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DT_Docto")))
                        reg.DT_Docto = reader.GetDateTime(reader.GetOrdinal("DT_Docto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NM_Fornecedor")))
                        reg.NM_Fornecedor = reader.GetString(reader.GetOrdinal("NM_Fornecedor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Setor")))
                        reg.DS_Setor = reader.GetString(reader.GetOrdinal("DS_Setor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Patrimonio")))
                        reg.DS_Patrimonio = reader.GetString(reader.GetOrdinal("DS_Patrimonio"));
                    if (!reader.IsDBNull(reader.GetOrdinal("VL_Reposicao")))
                        reg.VL_Reposicao = reader.GetDecimal(reader.GetOrdinal("VL_Reposicao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("VL_Mercado")))
                        reg.VL_Mercado = reader.GetDecimal(reader.GetOrdinal("VL_Mercado"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Tempo_VidaUtil")))
                        reg.Tempo_VidaUtil = reader.GetDecimal(reader.GetOrdinal("Tempo_VidaUtil"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Tempo_Saldo")))
                        reg.Tempo_Saldo = reader.GetDecimal(reader.GetOrdinal("Tempo_Saldo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DT_Lancto")))
                        reg.DT_Lancto = reader.GetDateTime(reader.GetOrdinal("DT_Lancto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ST_Imobilizado")))
                        reg.ST_Imobilizado = reader.GetString(reader.GetOrdinal("ST_Imobilizado"));
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

        public string Grava(TRegistro_CadPatrimonio vRegistro)
        {
            Hashtable hs = new Hashtable(13);
            hs.Add("@P_ID_PATRIMONIO", vRegistro.ID_Patrimonio);
            hs.Add("@P_CD_EMPRESA", vRegistro.CD_Empresa);
            hs.Add("@P_ID_GRUPOPATRIM", vRegistro.ID_GrupoPatrim);
            hs.Add("@P_NR_DOCTO", vRegistro.NR_Docto);
            hs.Add("@P_NM_FORNECEDOR", vRegistro.NM_Fornecedor);
            hs.Add("@P_DS_SETOR", vRegistro.DS_Setor);
            hs.Add("@P_DS_PATRIMONIO", vRegistro.DS_Patrimonio);
            hs.Add("@P_VL_REPOSICAO", vRegistro.VL_Reposicao); 
            hs.Add("@P_VL_MERCADO", vRegistro.VL_Mercado);
            hs.Add("@P_TEMPO_VIDAUTIL", vRegistro.Tempo_VidaUtil);
            hs.Add("@P_TEMPO_SALDO", vRegistro.Tempo_Saldo);
            hs.Add("@P_DT_LANCTO", vRegistro.DT_Lancto);
            hs.Add("@P_ST_IMOBILIZADO", vRegistro.ST_Imobilizado);
            return this.executarProc("IA_CTB_PATRIMONIO", hs);            
        }

        public string Deleta(TRegistro_CadPatrimonio vRegistro)
        {
            Hashtable hs = new Hashtable(1);
            hs.Add("@P_ID_PATRIMONIO", vRegistro.ID_Patrimonio);
            return this.executarProc("EXCLUI_CTB_PATRIMONIO", hs);
        }

    }

}
