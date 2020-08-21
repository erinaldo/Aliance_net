using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamadaDados.Faturamento.Promocao
{
    #region Promocao Venda
    public class TList_PromocaoVenda : List<TRegistro_PromocaoVenda>, IComparer<TRegistro_PromocaoVenda>
    {
        #region IComparer<TRegistro_PromocaoVenda> Members
        private System.ComponentModel.PropertyDescriptor Propriedade;
        private System.Windows.Forms.SortOrder Direcao;

        private int CompareAscending(object x, object y)
        {
            if (x is IComparable)
                return new System.Collections.CaseInsensitiveComparer().Compare(x, y);
            else
                return 0;
        }

        private int CompareDescending(object x, object y)
        {
            return -CompareAscending(x, y);
        }

        public TList_PromocaoVenda()
        { }

        public TList_PromocaoVenda(System.ComponentModel.PropertyDescriptor Prop,
                                   System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_PromocaoVenda value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_PromocaoVenda x, TRegistro_PromocaoVenda y)
        {
            object col1 = GetPropertyValue(x, Propriedade.Name);
            object col2 = GetPropertyValue(y, Propriedade.Name);
            if (Direcao == System.Windows.Forms.SortOrder.Ascending)
                return CompareAscending(col1, col2);
            else
                return CompareDescending(col1, col2);
        }
        #endregion
    }

    
    public class TRegistro_PromocaoVenda
    {
        private decimal? id_promocao;
        
        public decimal? Id_promocao
        {
            get { return id_promocao; }
            set
            {
                id_promocao = value;
                id_promocaostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_promocaostr;
        
        public string Id_promocaostr
        {
            get { return id_promocaostr; }
            set
            {
                id_promocaostr = value;
                try
                {
                    id_promocao = Convert.ToDecimal(value);
                }
                catch
                { id_promocao = null; }
            }
        }
        
        public string Cd_empresa
        { get; set; }
        
        public string Nm_empresa
        { get; set; }
        
        public string Ds_promocao
        { get; set; }
        private DateTime? dt_ini;
        
        public DateTime? Dt_ini
        {
            get { return dt_ini; }
            set
            {
                dt_ini = value;
                dt_inistr = value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty;
            }
        }
        private string dt_inistr;
        public string Dt_inistr
        {
            get
            {
                try
                {
                    return Convert.ToDateTime(dt_inistr).ToString("dd/MM/yyyy");
                }
                catch
                { return string.Empty; }
            }
            set
            {
                dt_inistr = value;
                try
                {
                    dt_ini = Convert.ToDateTime(value);
                }
                catch
                { dt_ini = null; }
            }
        }
        private DateTime? dt_fin;
        
        public DateTime? Dt_fin
        {
            get { return dt_fin; }
            set
            {
                dt_fin = value;
                dt_finstr = value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty;
            }
        }
        private string dt_finstr;
        public string Dt_finstr
        {
            get
            {
                try
                {
                    return Convert.ToDateTime(dt_finstr).ToString("dd/MM/yyyy");
                }
                catch
                { return string.Empty; }
            }
            set
            {
                dt_finstr = value;
                try
                {
                    dt_fin = Convert.ToDateTime(value);
                }
                catch
                { dt_fin = null; }
            }
        }
        
        public DateTime Dt_servidor
        { get; set; }
        
        public string Ds_observacao
        { get; set; }
        
        public string St_registro
        { get; set; }
        public string Status
        {
            get
            {
                if (St_registro.Trim().ToUpper().Equals("A"))
                    if (dt_fin.HasValue ? dt_fin.Value.Date < Dt_servidor.Date : false)
                        return "EXPIRADA";
                    else return "ATIVA";
                else if (St_registro.Trim().ToUpper().Equals("F"))
                    return "FINALIZADA";
                else return string.Empty;
            }
        }

        
        public TList_Promocao_X_Grupo lGrupo
        { get; set; }
        
        public TList_Promocao_X_Grupo lGrupoDel
        { get; set; }

        public TRegistro_PromocaoVenda()
        {
            id_promocao = null;
            id_promocaostr = string.Empty;
            Cd_empresa = string.Empty;
            Nm_empresa = string.Empty;
            Ds_promocao = string.Empty;
            dt_ini = null;
            dt_inistr = string.Empty;
            dt_fin = null;
            dt_finstr = string.Empty;
            Dt_servidor = DateTime.Now;
            Ds_observacao = string.Empty;
            St_registro = "A";

            lGrupo = new TList_Promocao_X_Grupo();
            lGrupoDel = new TList_Promocao_X_Grupo();
        }
    }

    public class TCD_PromocaoVenda : TDataQuery
    {
        public TCD_PromocaoVenda()
        { }

        public TCD_PromocaoVenda(BancoDados.TObjetoBanco banco)
        { Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + vTop.ToString();

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("select " + strTop + " a.id_promocao, a.cd_empresa, ");
                sql.AppendLine("b.nm_empresa, a.ds_promocao, a.dt_ini, getdate() as dt_servidor, ");
                sql.AppendLine("a.dt_fin, a.ds_observacao, a.st_registro ");
            }
            else
                sql.AppendLine(" Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from TB_FAT_PromocaoVenda a ");
            sql.AppendLine("inner join TB_DIV_Empresa b ");
            sql.AppendLine("on a.cd_empresa = b.cd_empresa ");

            string cond = " and ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
            return sql.ToString();
        }

        public override System.Data.DataTable Buscar(Utils.TpBusca[] vBusca, short vTop)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, string.Empty), null);
        }

        public override System.Data.DataTable Buscar(Utils.TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo), null);
        }

        public override object BuscarEscalar(Utils.TpBusca[] vBusca, string vNM_Campo)
        {
            return ExecutarBuscaEscalar(SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }

        public TList_PromocaoVenda Select(Utils.TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            bool podeFecharBco = false;
            TList_PromocaoVenda lista = new TList_PromocaoVenda();
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_PromocaoVenda reg = new TRegistro_PromocaoVenda();
                    if (!(reader.IsDBNull(reader.GetOrdinal("id_promocao"))))
                        reg.Id_promocao = reader.GetDecimal(reader.GetOrdinal("id_promocao"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("cd_empresa"))))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("nm_empresa"))))
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("nm_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_promocao")))
                        reg.Ds_promocao = reader.GetString(reader.GetOrdinal("ds_promocao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("dt_ini")))
                        reg.Dt_ini = reader.GetDateTime(reader.GetOrdinal("dt_ini"));
                    if (!reader.IsDBNull(reader.GetOrdinal("dt_fin")))
                        reg.Dt_fin = reader.GetDateTime(reader.GetOrdinal("dt_fin"));
                    if (!reader.IsDBNull(reader.GetOrdinal("dt_servidor")))
                        reg.Dt_servidor = reader.GetDateTime(reader.GetOrdinal("dt_servidor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_observacao")))
                        reg.Ds_observacao = reader.GetString(reader.GetOrdinal("ds_observacao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_registro")))
                        reg.St_registro = reader.GetString(reader.GetOrdinal("st_registro"));

                    lista.Add(reg);
                }
            }
            finally
            {
                reader.Close();
                reader.Dispose();
                if (podeFecharBco)
                    deletarBanco_Dados();
            }
            return lista;
        }

        public string Gravar(TRegistro_PromocaoVenda val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(7);
            hs.Add("@P_ID_PROMOCAO", val.Id_promocao);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_DS_PROMOCAO", val.Ds_promocao);
            hs.Add("@P_DT_INI", val.Dt_ini);
            hs.Add("@P_DT_FIN", val.Dt_fin);
            hs.Add("@P_DS_OBSERVACAO", val.Ds_observacao);
            hs.Add("@P_ST_REGISTRO", val.St_registro);

            return executarProc("IA_FAT_PROMOCAOVENDA", hs);
        }

        public string Excluir(TRegistro_PromocaoVenda val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(1);
            hs.Add("@P_ID_PROMOCAO", val.Id_promocao);

            return executarProc("EXCLUI_FAT_PROMOCAOVENDA", hs);
        }
    }
    #endregion

    #region Promocao X Grupo
    public class TList_Promocao_X_Grupo : List<TRegistro_Promocao_X_Grupo>
    { }

    
    public class TRegistro_Promocao_X_Grupo
    {
        private decimal? id_promocao;
        public decimal? Id_promocao
        {
            get { return id_promocao; }
            set
            {
                id_promocao = value;
                id_promocaostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_promocaostr;
        public string Id_promocaostr
        {
            get { return id_promocaostr; }
            set
            {
                id_promocaostr = value;
                try
                {
                    id_promocao = Convert.ToDecimal(value);
                }
                catch
                { id_promocao = null; }
            }
        }
        private decimal? id_registro = null;
        public decimal? Id_registro
        {
            get { return id_registro; }
            set
            {
                id_registro = value;
                id_registrostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_registrostr = string.Empty;
        public string Id_registrostr
        {
            get { return id_registrostr; }
            set
            {
                id_registrostr = value;
                try
                {
                    id_registro = decimal.Parse(value);
                }
                catch { id_registro = null; }
            }
        }
        public string Ds_promocao
        { get; set; }

        public string Cd_produto { get; set; } = string.Empty;
        public string Ds_produto { get; set; } = string.Empty;
        public string Cd_grupo
        { get; set; }
        
        public string Ds_grupo
        { get; set; }
        private string tp_promocao;
        
        public string Tp_promocao
        {
            get { return tp_promocao; }
            set
            {
                tp_promocao = value;
                if (value.Trim().ToUpper().Equals("V"))
                    tipo_promocao = "VALOR";
                else if (value.Trim().ToUpper().Equals("P"))
                    tipo_promocao = "PERCENTUAL";
            }
        }
        private string tipo_promocao;
        
        public string Tipo_promocao
        {
            get { return tipo_promocao; }
            set
            {
                tipo_promocao = value;
                if (value.Trim().ToUpper().Equals("VALOR"))
                    tp_promocao = "V";
                else if (value.Trim().ToUpper().Equals("PERCENTUAL"))
                    tp_promocao = "P";
            }
        }
        
        public decimal Vl_promocao
        { get; set; }
        
        public decimal Qtd_minimavenda
        { get; set; }

        public TRegistro_Promocao_X_Grupo()
        {
            id_promocao = null;
            id_promocaostr = string.Empty;
            Cd_grupo = string.Empty;
            Ds_grupo = string.Empty;
            tp_promocao = string.Empty;
            tipo_promocao = string.Empty;
            Vl_promocao = decimal.Zero;
            Qtd_minimavenda = decimal.Zero;
        }
    }

    public class TCD_Promocao_X_Grupo : TDataQuery
    {
        public TCD_Promocao_X_Grupo()
        { }

        public TCD_Promocao_X_Grupo(BancoDados.TObjetoBanco banco)
        { Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, int vTop, string vNM_Campo, string vOrder)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + vTop.ToString();

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("select " + strTop + " a.id_promocao, a.id_registro, ");
                sql.AppendLine("b.ds_promocao, a.cd_grupo, c.ds_grupo, a.tp_promocao, ");
                sql.AppendLine("a.cd_produto, d.ds_produto, a.vl_promocao, a.qtd_minimavenda ");
            }
            else
                sql.AppendLine(" Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from TB_FAT_Promocao_X_Grupo a ");
            sql.AppendLine("inner join TB_FAT_PromocaoVenda b ");
            sql.AppendLine("on a.id_promocao = b.id_promocao ");
            sql.AppendLine("left outer join TB_EST_GrupoProduto c ");
            sql.AppendLine("on a.cd_grupo = c.cd_grupo ");
            sql.AppendLine("left outer join tb_est_produto d ");
            sql.AppendLine("on a.cd_produto = d.cd_produto ");

            string cond = " where ";

            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                    cond = " and ";
                }
            if (!string.IsNullOrEmpty(vOrder))
                sql.AppendLine("order by " + vOrder.Trim());
            return sql.ToString();
        }

        public override System.Data.DataTable Buscar(Utils.TpBusca[] vBusca, short vTop)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, string.Empty, string.Empty), null);
        }

        public override System.Data.DataTable Buscar(Utils.TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo, string.Empty), null);
        }

        public override object BuscarEscalar(Utils.TpBusca[] vBusca, string vNM_Campo)
        {
            return ExecutarBuscaEscalar(SqlCodeBusca(vBusca, 1, vNM_Campo, string.Empty), null);
        }

        public TList_Promocao_X_Grupo Select(Utils.TpBusca[] vBusca, int vTop, string vNM_Campo, string vOrder)
        {
            bool podeFecharBco = false;
            TList_Promocao_X_Grupo lista = new TList_Promocao_X_Grupo();
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo, vOrder));
            try
            {
                while (reader.Read())
                {
                    TRegistro_Promocao_X_Grupo reg = new TRegistro_Promocao_X_Grupo();
                    if (!(reader.IsDBNull(reader.GetOrdinal("id_promocao"))))
                        reg.Id_promocao = reader.GetDecimal(reader.GetOrdinal("id_promocao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_registro")))
                        reg.Id_registro = reader.GetDecimal(reader.GetOrdinal("id_registro"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("ds_promocao"))))
                        reg.Ds_promocao = reader.GetString(reader.GetOrdinal("ds_promocao"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("cd_grupo"))))
                        reg.Cd_grupo = reader.GetString(reader.GetOrdinal("cd_grupo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_grupo")))
                        reg.Ds_grupo = reader.GetString(reader.GetOrdinal("ds_grupo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_produto")))
                        reg.Cd_produto = reader.GetString(reader.GetOrdinal("cd_produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_produto")))
                        reg.Ds_produto = reader.GetString(reader.GetOrdinal("ds_produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_promocao")))
                        reg.Tp_promocao = reader.GetString(reader.GetOrdinal("tp_promocao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_promocao")))
                        reg.Vl_promocao = reader.GetDecimal(reader.GetOrdinal("vl_promocao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("qtd_minimavenda")))
                        reg.Qtd_minimavenda = reader.GetDecimal(reader.GetOrdinal("qtd_minimavenda"));

                    lista.Add(reg);
                }
            }
            finally
            {
                reader.Close();
                reader.Dispose();
                if (podeFecharBco)
                    deletarBanco_Dados();
            }
            return lista;
        }

        public string Gravar(TRegistro_Promocao_X_Grupo val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(7);
            hs.Add("@P_ID_PROMOCAO", val.Id_promocao);
            hs.Add("@P_ID_REGISTRO", val.Id_registro);
            hs.Add("@P_CD_GRUPO", val.Cd_grupo);
            hs.Add("@P_CD_PRODUTO", val.Cd_produto);
            hs.Add("@P_TP_PROMOCAO", val.Tp_promocao);
            hs.Add("@P_VL_PROMOCAO", val.Vl_promocao);
            hs.Add("@P_QTD_MINIMAVENDA", val.Qtd_minimavenda);

            return executarProc("IA_FAT_PROMOCAO_X_GRUPO", hs);
        }

        public string Excluir(TRegistro_Promocao_X_Grupo val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(2);
            hs.Add("@P_ID_PROMOCAO", val.Id_promocao);
            hs.Add("@P_ID_REGISTRO", val.Id_registro);

            return executarProc("EXCLUI_FAT_PROMOCAO_X_GRUPO", hs);
        }
    }
    #endregion
}
