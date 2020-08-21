using System;
using System.Collections.Generic;
using System.Text;
using Utils;
using System.Data.SqlClient;
using System.Collections;

namespace CamadaDados.Estoque.Cadastros
{
    public class TList_CadPatrimonio : List<TRegistro_CadPatrimonio>, IComparer<TRegistro_CadPatrimonio>
    {
        #region IComparer<TRegistro_CadPatrimonio> Members
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

        public TList_CadPatrimonio()
        { }

        public TList_CadPatrimonio(System.ComponentModel.PropertyDescriptor Prop,
                                System.Windows.Forms.SortOrder Dir)
        {
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_CadPatrimonio value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_CadPatrimonio x, TRegistro_CadPatrimonio y)
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

    public class TRegistro_CadPatrimonio
    {
        public string CD_Patrimonio
        { get; set; }

        public string DS_Patrimonio
        { get; set; }

        public string Nr_patrimonio
        { get; set; }
        public string Cd_grupo { get; set; } = string.Empty;
        public string Ds_grupo { get; set; } = string.Empty;

        public string Cd_empresa
        { get; set; }

        public string Nm_empresa
        { get; set; }

        public string Nr_NFCompra
        { get; set; }

        private DateTime? dt_compra;
        public DateTime? Dt_compra
        {
            get { return dt_compra; }
            set
            {
                dt_compra = value;
                dt_comprastr = value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty;
            }
        }
        private string dt_comprastr;
        public string Dt_comprastr
        {
            get
            {
                try
                {
                    return Convert.ToDateTime(dt_comprastr).ToString("dd/MM/yyyy");
                }
                catch
                { return string.Empty; }
            }
            set
            {
                dt_comprastr = value;
                try
                {
                    dt_compra = Convert.ToDateTime(value);
                }
                catch
                { dt_compra = null; }
            }
        }
        public string Nm_fornecedor
        { get; set; }

        public decimal Vl_compra
        { get; set; }

        public decimal VidaUtil
        { get; set; }

        public string Tp_vidautil
        { get; set; }
        public string Tipo_vidautil
        {
            get
            {
                if (Tp_vidautil.Trim().Equals("0"))
                    return "HORAS";
                else if (Tp_vidautil.Trim().Equals("1"))
                    return "DIAS";
                else if (Tp_vidautil.Trim().Equals("2"))
                    return "MÊS";
                else if (Tp_vidautil.Trim().Equals("3"))
                    return "ANO";
                else return string.Empty;
            }
        }
        public int ManutDia { get; set; }
        public int ManutHora { get; set; }
        public decimal Quantidade
        { get; set; }
        public decimal Qtd_horas
        { get; set; }
        private string st_controlehora;
        public string St_controlehora
        {
            get { return st_controlehora; }
            set
            {
                st_controlehora = value;
                st_controlehorabool = value.Trim().ToUpper().Equals("S");
            }
        }
        private bool st_controlehorabool;

        public DateTime DtUltimaManut
        { get; set; }
        public double QtDiasExpirados
        {
            get
            {
                try
                {
                    return UtilData.Data_Servidor().Subtract(DtUltimaManut).TotalDays - ManutDia;
                }
                catch { return 0; }
            }
        }

        public bool St_controlehorabool
        {
            get { return st_controlehorabool; }
            set
            {
                st_controlehorabool = value;
                st_controlehora = value ? "S" : "N";
            }
        }
        public decimal Vl_atual { get; set; } = decimal.Zero;
        public decimal cVl_atual
        {
            get
            {
                if (Vl_compra > decimal.Zero && Vl_atual > decimal.Zero)
                {
                    if (Math.Round(decimal.Multiply(decimal.Divide(Vl_atual, Vl_compra), 100), 0, MidpointRounding.AwayFromZero) > 40)
                        return Math.Round(decimal.Multiply(decimal.Divide(60, 100), Vl_compra), 2, MidpointRounding.AwayFromZero);
                    else return Vl_atual;
                }
                else return decimal.Zero;
            }
        }
        public decimal Vl_depreciacao => cVl_atual.Equals(decimal.Zero) ? decimal.Zero : Vl_compra - cVl_atual;
        public decimal Vl_receitas { get; set; } = decimal.Zero;
        public decimal Vl_despesas { get; set; } = decimal.Zero;
        public decimal Vl_combustivel { get; set; } = decimal.Zero;
        public decimal PC_ROI => Vl_compra > decimal.Zero ? decimal.Multiply(decimal.Divide(Vl_receitas - Vl_despesas - Vl_combustivel - Vl_depreciacao - Vl_compra, Vl_compra), 100) : decimal.Zero;
        public TRegistro_CadPatrimonio()
        {
            CD_Patrimonio = string.Empty;
            DS_Patrimonio = string.Empty;
            Nr_patrimonio = string.Empty;
            Cd_empresa = string.Empty;
            Nm_empresa = string.Empty;
            Nr_NFCompra = string.Empty;
            dt_compra = null;
            dt_comprastr = string.Empty;
            Nm_fornecedor = string.Empty;
            Vl_compra = decimal.Zero;
            VidaUtil = decimal.Zero;
            Tp_vidautil = string.Empty;
            Quantidade = decimal.Zero;
            Qtd_horas = decimal.Zero;
            st_controlehora = "N";
            st_controlehorabool = false;
        }
    }

    public class TCD_CadPatrimonio : TDataQuery
    {
        public TCD_CadPatrimonio()
        { }

        public TCD_CadPatrimonio(BancoDados.TObjetoBanco banco)
        { Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();

            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine(" SELECT " + strTop + "a.CD_Patrimonio, b.DS_Produto as DS_Patrimonio, a.TP_VidaUtil, a.Quantidade, a.qtd_horas, a.st_controlehora, ");
                sql.AppendLine("a.NR_Patrimonio, a.CD_Empresa, c.nm_empresa, a.Nr_NFCompra, a.DT_Compra, a.NM_Fornecedor, a.Vl_Compra, a.VidaUtil, a.ManutDia, a.ManutHora, a.dt_cad ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("FROM TB_EST_Patrimonio a ");
            sql.AppendLine("inner join tb_est_produto b ");
            sql.AppendLine("on a.CD_Patrimonio = b.cd_produto ");
            sql.AppendLine("left outer join TB_DIV_EMPRESA c ");
            sql.AppendLine("on a.CD_EMPRESA = c.CD_EMPRESA ");

            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.Append(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                    cond = " and ";
                }

            return sql.ToString();
        }

        private string SqlCodeBuscaView(TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();

            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine(" SELECT " + strTop + "a.CD_Patrimonio, b.ds_produto as Ds_Patrimonio, a.TP_VidaUtil, a.Quantidade, a.qtd_horas, ");
                sql.AppendLine("a.st_controlehora, a.NR_Patrimonio, a.CD_Empresa, a.Nr_NFCompra, ");
                sql.AppendLine("a.DT_Compra, a.NM_Fornecedor, a.Vl_Compra, a.VidaUtil, a.ManutDia, a.ManutHora, " +
                    "DtUltimaManut  = isnull((select top 1 x.DT_Encerramento " +
                                               "from TB_OSE_Servico x " +
                                              "where x.CD_ProdutoOS = a.CD_Patrimonio " +
                                                "and x.ST_OS in('FE', 'PR') " +
                                              "order by x.DT_Encerramento desc), a.DT_Cad) ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("FROM TB_EST_Patrimonio a ");
            sql.AppendLine("inner join TB_EST_Produto b ");
            sql.AppendLine("on a.CD_Patrimonio = b.CD_Produto ");
            sql.AppendLine("and ISNULL(b.ST_Registro, 'A') <> 'C' ");
            sql.AppendLine("and DATEDIFF(day, isnull((select top 1 x.DT_Encerramento " +
                                                       "from TB_OSE_Servico x " +
                                                      "where x.CD_ProdutoOS = a.CD_Patrimonio " +
                                                        "and x.ST_OS in('FE', 'PR') " +
                                                      "order by x.DT_Encerramento desc), a.DT_Cad)" +
                                 ", getdate()) > a.manutdia");
            sql.AppendLine("and not exists (select 1 " +
                                            "from tb_ose_servico ose " +
                                            "where ose.cd_produtoos = a.cd_patrimonio " +
                                            "and ose.st_os = 'AB') ");

            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.Append(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                    cond = " and ";
                }

            return sql.ToString();
        }

        public override System.Data.DataTable Buscar(TpBusca[] vBusca, short vTop)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, string.Empty), null);
        }

        public override System.Data.DataTable Buscar(TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo), null);
        }

        public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
        {
            return ExecutarBuscaEscalar(SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }

        public TList_CadPatrimonio CalcularROI(TpBusca[] filtro)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("select a.CD_Patrimonio, b.DS_Produto as DS_Patrimonio, ");
            sql.AppendLine("a.TP_VidaUtil, a.Quantidade, a.qtd_horas, a.st_controlehora, ");
            sql.AppendLine("a.NR_Patrimonio, a.CD_Empresa, c.nm_empresa, a.nr_nfcompra, ");
            sql.AppendLine("a.dt_compra, a.nm_fornecedor, a.vl_compra, a.vidautil, a.ManutDia, a.ManutHora, ");
            sql.AppendLine("b.cd_grupo, LTrim(RTrim(d.ds_grupo)) as ds_grupo, ");
            sql.AppendLine("a.vl_atual, a.vl_receitas, a.vl_despesas, a.Vl_Combustivel ");

            sql.AppendLine("from vtb_est_patrimonio a ");
            sql.AppendLine("inner join TB_EST_Produto b ");
            sql.AppendLine("on a.CD_Patrimonio = b.CD_Produto ");
            sql.AppendLine("inner join TB_EST_GrupoProduto d ");
            sql.AppendLine("on b.cd_grupo = d.cd_grupo ");
            sql.AppendLine("left outer join TB_DIV_EMPRESA c ");
            sql.AppendLine("on a.CD_EMPRESA = c.CD_EMPRESA ");

            string cond = " where ";
            if (filtro != null)
                for (int i = 0; i < (filtro.Length); i++)
                {
                    sql.Append(cond + "(" + filtro[i].vNM_Campo + " " + filtro[i].vOperador + " " + filtro[i].vVL_Busca + " )");
                    cond = " and ";
                }

            TList_CadPatrimonio lista = new TList_CadPatrimonio();
            SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);

            try
            {
                reader = ExecutarBusca(sql.ToString());
                while (reader.Read())
                {
                    TRegistro_CadPatrimonio reg = new TRegistro_CadPatrimonio();
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Patrimonio")))
                        reg.CD_Patrimonio = reader.GetString(reader.GetOrdinal("CD_Patrimonio"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Patrimonio")))
                        reg.DS_Patrimonio = reader.GetString(reader.GetOrdinal("DS_Patrimonio"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Nr_patrimonio")))
                        reg.Nr_patrimonio = reader.GetString(reader.GetOrdinal("Nr_patrimonio"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Cd_grupo")))
                        reg.Cd_grupo = reader.GetString(reader.GetOrdinal("Cd_grupo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Ds_grupo")))
                        reg.Ds_grupo = reader.GetString(reader.GetOrdinal("Ds_grupo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Cd_empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("Cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Nm_empresa")))
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("Nm_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Nr_NFCompra")))
                        reg.Nr_NFCompra = reader.GetString(reader.GetOrdinal("Nr_NFCompra"));
                    if (!reader.IsDBNull(reader.GetOrdinal("dt_compra")))
                        reg.Dt_compra = reader.GetDateTime(reader.GetOrdinal("dt_compra"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Nm_fornecedor")))
                        reg.Nm_fornecedor = reader.GetString(reader.GetOrdinal("Nm_fornecedor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_compra")))
                        reg.Vl_compra = reader.GetDecimal(reader.GetOrdinal("Vl_compra"));
                    if (!reader.IsDBNull(reader.GetOrdinal("VidaUtil")))
                        reg.VidaUtil = reader.GetDecimal(reader.GetOrdinal("VidaUtil"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Tp_vidautil")))
                        reg.Tp_vidautil = reader.GetString(reader.GetOrdinal("Tp_vidautil"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ManutDia")))
                        reg.ManutDia = reader.GetInt32(reader.GetOrdinal("ManutDia"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ManutHora")))
                        reg.ManutHora = reader.GetInt32(reader.GetOrdinal("ManutHora"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Quantidade")))
                        reg.Quantidade = reader.GetDecimal(reader.GetOrdinal("Quantidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("qtd_horas")))
                        reg.Qtd_horas = reader.GetDecimal(reader.GetOrdinal("qtd_horas"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_controlehora")))
                        reg.St_controlehora = reader.GetString(reader.GetOrdinal("st_controlehora"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_Atual")))
                        reg.Vl_atual = reader.GetDecimal(reader.GetOrdinal("Vl_Atual"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_receitas")))
                        reg.Vl_receitas = reader.GetDecimal(reader.GetOrdinal("vl_receitas"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_despesas")))
                        reg.Vl_despesas = reader.GetDecimal(reader.GetOrdinal("vl_despesas"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_Combustivel")))
                        reg.Vl_combustivel = reader.GetDecimal(reader.GetOrdinal("Vl_Combustivel"));

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

        public TList_CadPatrimonio Select(TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            TList_CadPatrimonio lista = new TList_CadPatrimonio();
            SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);

            try
            {
                reader = ExecutarBusca(SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
                while (reader.Read())
                {
                    TRegistro_CadPatrimonio reg = new TRegistro_CadPatrimonio();
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Patrimonio")))
                        reg.CD_Patrimonio = reader.GetString(reader.GetOrdinal("CD_Patrimonio"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Patrimonio")))
                        reg.DS_Patrimonio = reader.GetString(reader.GetOrdinal("DS_Patrimonio"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Nr_patrimonio")))
                        reg.Nr_patrimonio = reader.GetString(reader.GetOrdinal("Nr_patrimonio"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Cd_empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("Cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Nm_empresa")))
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("Nm_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Nr_NFCompra")))
                        reg.Nr_NFCompra = reader.GetString(reader.GetOrdinal("Nr_NFCompra"));
                    if (!reader.IsDBNull(reader.GetOrdinal("dt_compra")))
                        reg.Dt_compra = reader.GetDateTime(reader.GetOrdinal("dt_compra"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Nm_fornecedor")))
                        reg.Nm_fornecedor = reader.GetString(reader.GetOrdinal("Nm_fornecedor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_compra")))
                        reg.Vl_compra = reader.GetDecimal(reader.GetOrdinal("Vl_compra"));
                    if (!reader.IsDBNull(reader.GetOrdinal("VidaUtil")))
                        reg.VidaUtil = reader.GetDecimal(reader.GetOrdinal("VidaUtil"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Tp_vidautil")))
                        reg.Tp_vidautil = reader.GetString(reader.GetOrdinal("Tp_vidautil"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Quantidade")))
                        reg.Quantidade = reader.GetDecimal(reader.GetOrdinal("Quantidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("qtd_horas")))
                        reg.Qtd_horas = reader.GetDecimal(reader.GetOrdinal("qtd_horas"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_controlehora")))
                        reg.St_controlehora = reader.GetString(reader.GetOrdinal("st_controlehora"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ManutDia")))
                        reg.ManutDia = reader.GetInt32(reader.GetOrdinal("ManutDia"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ManutHora")))
                        reg.ManutHora = reader.GetInt32(reader.GetOrdinal("ManutHora"));

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

        public TList_CadPatrimonio SelectView(TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            TList_CadPatrimonio lista = new TList_CadPatrimonio();
            SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);

            try
            {
                reader = ExecutarBusca(SqlCodeBuscaView(vBusca, Convert.ToInt16(vTop), vNM_Campo));
                while (reader.Read())
                {
                    TRegistro_CadPatrimonio reg = new TRegistro_CadPatrimonio();
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Patrimonio")))
                        reg.CD_Patrimonio = reader.GetString(reader.GetOrdinal("CD_Patrimonio"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Patrimonio")))
                        reg.DS_Patrimonio = reader.GetString(reader.GetOrdinal("DS_Patrimonio"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Nr_patrimonio")))
                        reg.Nr_patrimonio = reader.GetString(reader.GetOrdinal("Nr_patrimonio"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Cd_empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("Cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Nr_NFCompra")))
                        reg.Nr_NFCompra = reader.GetString(reader.GetOrdinal("Nr_NFCompra"));
                    if (!reader.IsDBNull(reader.GetOrdinal("dt_compra")))
                        reg.Dt_compra = reader.GetDateTime(reader.GetOrdinal("dt_compra"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Nm_fornecedor")))
                        reg.Nm_fornecedor = reader.GetString(reader.GetOrdinal("Nm_fornecedor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_compra")))
                        reg.Vl_compra = reader.GetDecimal(reader.GetOrdinal("Vl_compra"));
                    if (!reader.IsDBNull(reader.GetOrdinal("VidaUtil")))
                        reg.VidaUtil = reader.GetDecimal(reader.GetOrdinal("VidaUtil"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Tp_vidautil")))
                        reg.Tp_vidautil = reader.GetString(reader.GetOrdinal("Tp_vidautil"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Quantidade")))
                        reg.Quantidade = reader.GetDecimal(reader.GetOrdinal("Quantidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("qtd_horas")))
                        reg.Qtd_horas = reader.GetDecimal(reader.GetOrdinal("qtd_horas"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_controlehora")))
                        reg.St_controlehora = reader.GetString(reader.GetOrdinal("st_controlehora"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ManutDia")))
                        reg.ManutDia = reader.GetInt32(reader.GetOrdinal("ManutDia"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ManutHora")))
                        reg.ManutHora = reader.GetInt32(reader.GetOrdinal("ManutHora"));

                    if (!reader.IsDBNull(reader.GetOrdinal("DtUltimaManut")))
                        reg.DtUltimaManut = reader.GetDateTime(reader.GetOrdinal("DtUltimaManut"));
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

        public string Grava(TRegistro_CadPatrimonio vRegistro)
        {
            Hashtable hs = new Hashtable(14);
            hs.Add("@P_CD_PATRIMONIO", vRegistro.CD_Patrimonio);
            hs.Add("@P_NR_PATRIMONIO", vRegistro.Nr_patrimonio);
            hs.Add("@P_CD_EMPRESA", vRegistro.Cd_empresa);
            hs.Add("@P_NR_NFCOMPRA", vRegistro.Nr_NFCompra);
            hs.Add("@P_DT_COMPRA", vRegistro.Dt_compra);
            hs.Add("@P_NM_FORNECEDOR", vRegistro.Nm_fornecedor);
            hs.Add("@P_VL_COMPRA", vRegistro.Vl_compra);
            hs.Add("@P_VIDAUTIL", vRegistro.VidaUtil);
            hs.Add("@P_TP_VIDAUTIL", vRegistro.Tp_vidautil);
            hs.Add("@P_QUANTIDADE", vRegistro.Quantidade);
            hs.Add("@P_QTD_HORAS", vRegistro.Qtd_horas);
            hs.Add("@P_ST_CONTROLEHORA", vRegistro.St_controlehora);
            hs.Add("@P_MANUTDIA", vRegistro.ManutDia);
            hs.Add("@P_MANUTHORA", vRegistro.ManutHora);

            return executarProc("IA_EST_PATRIMONIO", hs);
        }

        public string Deleta(TRegistro_CadPatrimonio vRegistro)
        {
            Hashtable hs = new Hashtable(1);
            hs.Add("@P_CD_PATRIMONIO", vRegistro.CD_Patrimonio);

            return executarProc("EXCLUI_EST_PATRIMONIO", hs);
        }

    }
}
