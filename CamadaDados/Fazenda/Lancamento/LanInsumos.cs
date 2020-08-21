using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Collections;
using Utils;
using System.Data;

namespace CamadaDados.Fazenda.Lancamento
{
    public class TList_LanInsumos : List<TRegistro_LanInsumos> { }

    public class TRegistro_LanInsumos
    {
        private decimal? _ID_LanctoAtiv;
        public decimal? ID_LanctoAtiv
        {
            get
            {
                if (_ID_LanctoAtiv == 0)
                {
                    return (null);
                }
                else
                {
                    return _ID_LanctoAtiv;
                }
            }
            set
            {
                if (value > 0)
                {
                    _ID_LanctoAtiv = value;
                    _IDLanctoAtivString = value.ToString();
                }
                else
                {
                    _ID_LanctoAtiv = null;
                    _IDLanctoAtivString = "";
                }

            }
        }
        private string _IDLanctoAtivString;
        public string IDLanctoAtivString
        {
            get
            {
                return _IDLanctoAtivString;
            }
            set
            {
                _IDLanctoAtivString = value;
                try
                {
                    if (value != "")
                        _ID_LanctoAtiv = Convert.ToDecimal(value);
                    else
                        _IDLanctoAtivString = "";

                }
                catch
                {
                    _ID_LanctoAtiv = null;
                }
            }
        }

        private decimal? _ID_Lancto;
        public decimal? ID_Lancto
        {
            get
            {
                if (_ID_Lancto == 0)
                {
                    return (null);
                }
                else
                {
                    return _ID_Lancto;
                }
            }
            set
            {
                _ID_Lancto = value;
                _IDLanctoString = value.ToString();
            }
        }
        private string _IDLanctoString;
        public string IDLanctoString
        {
            get
            {
                return _IDLanctoString;
            }
            set
            {
                _IDLanctoString = value;
                try
                {
                    _ID_Lancto = Convert.ToDecimal(value);
                }
                catch
                {
                    _ID_Lancto = null;
                }
            }
        }

        public string CD_Local { get; set; }
        public string NM_Local { get; set; }

        public string CD_Produto { get; set; }
        public string DS_Produto { get; set; }

        public string CD_Empresa { get; set; }
        public string DS_Empresa { get; set; }

        public string CD_Unidade { get; set; }
        public string DS_Unidade { get; set; }

        private DateTime? dt_Custo;
        public DateTime? Dt_Custo
        {
            get { return dt_Custo; }
            set
            {
                dt_Custo = value;
                _dt_Custo_string = value.ToString();

            }
        }
        private string _dt_Custo_string;
        public string Dt_Custo_string
        {
            get
            {
                try
                {
                    return Convert.ToDateTime(_dt_Custo_string).ToString("dd/MM/yyyy");
                }
                catch
                { return ""; }
            }
            set
            {
                _dt_Custo_string = value;
                try
                {
                    dt_Custo = Convert.ToDateTime(value);
                }
                catch
                { dt_Custo = null; }
            }
        }

        private decimal _VL_Unitario;
        public decimal VL_Unitario
        {
            get
            {
                return _VL_Unitario;
            }
            set
            {
                _VL_Unitario = value;
                _VL_Total = _Quantidade * _VL_Unitario;

            }
        }

        private decimal _Quantidade;
        public decimal Quantidade
        {
            get
            {
                return _Quantidade;
            }
            set
            {
                _Quantidade = value;
                _VL_Total = _Quantidade * _VL_Unitario;
            }
        }

        private decimal _VL_Total;
        public decimal VL_Total
        {
            get
            {
                return _VL_Total;
            }
            set
            {
                _VL_Total = value;
                if (_Quantidade > 0)
                    _VL_Unitario = _VL_Total / _Quantidade;
            }
        }

        private decimal? _ID_Requisicao;
        public decimal? ID_Requisicao
        {
            get
            {
                if (_ID_Requisicao == 0)
                {
                    return (null);
                }
                else
                {
                    return _ID_Requisicao;
                }
            }
            set
            {
                _ID_Requisicao = value;
                _ID_RequisicaoString = value.ToString();
            }
        }
        private string _ID_RequisicaoString;
        public string ID_RequisicaoString
        {
            get
            {
                return _ID_RequisicaoString;
            }
            set
            {
                _ID_RequisicaoString = value;
                try
                {
                    _ID_Requisicao = Convert.ToDecimal(value);
                }
                catch
                {
                    _ID_Requisicao = null;
                }
            }
        }

      public TRegistro_LanInsumos()
        {
            this.ID_LanctoAtiv = 0;
            this.ID_Lancto = 0;
            this.ID_Requisicao = 0;
            this.ID_RequisicaoString = string.Empty;
            this.CD_Produto = string.Empty;
            this.DS_Produto = string.Empty;
            this.CD_Unidade = string.Empty;
            this.DS_Unidade = string.Empty;
            this.Dt_Custo = DateTime.Now;
            this.Dt_Custo_string = Dt_Custo_string.ToString();
            this.VL_Unitario = 0;
            this.VL_Total = 0;
            this.Quantidade = 0;
            this.ID_Requisicao = 0;
            this.ID_RequisicaoString = string.Empty;
        }
    }

    public class TCD_LanInsumos : TDataQuery
    {
        private string SqlCodeBusca(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = "";
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();

            if (vNM_Campo.Length == 0)
            {
                sql.AppendLine(" SELECT " + strTop + "a.id_lanctoAtiv,a.id_lancto,a.id_requisicao, a.cd_produto,a.cd_unidade,a.dt_custo,  ");
                sql.AppendLine(" a.CD_Local,vl_unitario,a.quantidade,a.vl_total, e.ds_produto,f.ds_unidade,i.DS_Local, h.CD_Empresa ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine(" from tb_faz_lanInsumos a");
            sql.AppendLine("join tb_est_produto e on a.cd_produto = e.cd_produto");
            sql.AppendLine("left outer join tb_est_unidade f on a.cd_unidade = f.cd_unidade");
            sql.AppendLine("left outer join tb_cmp_requisicao g on a.id_requisicao = g. id_requisicao");
            sql.AppendLine("join tb_est_localarm i on i.cd_local = a.cd_local");
            sql.AppendLine("join tb_faz_lanatividade j on j.id_lanctoAtiv = a.id_lanctoAtiv");
            sql.AppendLine("join TB_FAZ_FAZENDA h on h.CD_Fazenda = j.CD_Fazenda");

            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.Append(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                    cond = " and ";
                }
            sql.Append(" Order by a.id_lancto asc ");
            return sql.ToString();
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, ""), null);
        }

        public TList_LanInsumos Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_LanInsumos lista = new TList_LanInsumos();
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
                    TRegistro_LanInsumos reg = new TRegistro_LanInsumos();
                    if (!reader.IsDBNull(reader.GetOrdinal("id_lanctoAtiv")))
                        reg.ID_LanctoAtiv = reader.GetDecimal(reader.GetOrdinal("id_lanctoAtiv"));
                     if (!reader.IsDBNull(reader.GetOrdinal("id_lancto")))
                        reg.ID_Lancto = reader.GetDecimal(reader.GetOrdinal("id_lancto"));
                     if (!reader.IsDBNull(reader.GetOrdinal("id_requisicao")))
                        reg.ID_Requisicao = reader.GetDecimal(reader.GetOrdinal("id_requisicao"));
                     if (!reader.IsDBNull(reader.GetOrdinal("cd_produto")))
                        reg.CD_Produto = reader.GetString(reader.GetOrdinal("cd_produto"));
                     if (!reader.IsDBNull(reader.GetOrdinal("cd_unidade")))
                        reg.CD_Unidade = reader.GetString(reader.GetOrdinal("cd_unidade"));
                     if (!reader.IsDBNull(reader.GetOrdinal("dt_custo")))
                        reg.Dt_Custo = reader.GetDateTime(reader.GetOrdinal("dt_custo"));
                     if (!reader.IsDBNull(reader.GetOrdinal("vl_unitario")))
                        reg.VL_Unitario = reader.GetDecimal(reader.GetOrdinal("vl_unitario"));
                     if (!reader.IsDBNull(reader.GetOrdinal("quantidade")))
                        reg.Quantidade = reader.GetDecimal(reader.GetOrdinal("quantidade"));
                     if (!reader.IsDBNull(reader.GetOrdinal("vl_total")))
                        reg.VL_Total = reader.GetDecimal(reader.GetOrdinal("vl_total"));
                     if (!reader.IsDBNull(reader.GetOrdinal("ds_produto")))
                        reg.DS_Produto = reader.GetString(reader.GetOrdinal("ds_produto"));
                     if (!reader.IsDBNull(reader.GetOrdinal("ds_unidade")))
                        reg.DS_Unidade = reader.GetString(reader.GetOrdinal("ds_unidade"));
                     if (!reader.IsDBNull(reader.GetOrdinal("CD_Local")))
                         reg.CD_Local = reader.GetString(reader.GetOrdinal("CD_Local"));
                     if (!reader.IsDBNull(reader.GetOrdinal("DS_Local")))
                         reg.NM_Local = reader.GetString(reader.GetOrdinal("DS_Local"));
                     if (!reader.IsDBNull(reader.GetOrdinal("CD_Empresa")))
                         reg.CD_Empresa = reader.GetString(reader.GetOrdinal("CD_Empresa"));
                    
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

        public string GravaLanInsumos(TRegistro_LanInsumos vRegistro)
        {
            Hashtable hs = new Hashtable(10);
            hs.Add("@P_ID_LANCTOATIV", vRegistro.ID_LanctoAtiv);
            hs.Add("@P_ID_LANCTO", vRegistro.ID_Lancto);
            hs.Add("@P_ID_REQUISICAO", vRegistro.ID_Requisicao);
            hs.Add("@P_CD_PRODUTO", vRegistro.CD_Produto);
            hs.Add("@P_CD_UNIDADE", vRegistro.CD_Unidade);
            hs.Add("@P_DT_CUSTO", vRegistro.Dt_Custo);
            hs.Add("@P_VL_UNITARIO", vRegistro.VL_Unitario);
            hs.Add("@P_QUANTIDADE", vRegistro.Quantidade);
            hs.Add("@P_VL_TOTAL", vRegistro.VL_Total);
            hs.Add("@P_CD_LOCAL", vRegistro.CD_Local);

            return this.executarProc("IA_FAZ_LANINSUMOS", hs);
        }

        public string DeletaLanInsumos(TRegistro_LanInsumos vRegistro)
        {
            Hashtable hs = new Hashtable(2);
            hs.Add("@P_ID_LANCTOATIV", vRegistro.ID_LanctoAtiv);
            hs.Add("@P_ID_LANCTO", vRegistro.ID_Lancto);

            return this.executarProc("EXCLUI_FAZ_LANINSUMOS", hs);
        }
    }
}
