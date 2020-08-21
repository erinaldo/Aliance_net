using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamadaDados.Faturamento.Entrega
{
    #region Carga Avulsa
    public class TList_CargaAvulsa : List<TRegistro_CargaAvulsa>, IComparer<TRegistro_CargaAvulsa>
    {
        #region IComparer<TRegistro_CargaAvulsa> Members
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

        public TList_CargaAvulsa()
        { }

        public TList_CargaAvulsa(System.ComponentModel.PropertyDescriptor Prop,
                                  System.Windows.Forms.SortOrder Dir)
        {
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_CargaAvulsa value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_CargaAvulsa x, TRegistro_CargaAvulsa y)
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


    public class TRegistro_CargaAvulsa
    {
        public string Cd_empresa
        { get; set; }
        public string Nm_empresa
        { get; set; }
        private decimal? id_carga;

        public decimal? Id_carga
        {
            get { return id_carga; }
            set
            {
                id_carga = value;
                id_cargastr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_cargastr;

        public string Id_cargastr
        {
            get { return id_cargastr; }
            set
            {
                id_cargastr = value;
                try
                {
                    id_carga = decimal.Parse(value);
                }
                catch
                { id_carga = null; }
            }
        }

        public string Cd_motorista
        { get; set; }

        public string Nm_motorista
        { get; set; }
        private decimal? id_rota;
        public decimal? Id_rota
        {
            get { return id_rota; }
            set
            {
                id_rota = value;
                id_rotastr = value.ToString();
            }
        }
        private string id_rotastr;
        public string ID_rotaString
        {
            get { return id_rotastr; }
            set
            {
                id_rotastr = value;
                try
                {
                    id_rota = decimal.Parse(value);
                }
                catch { id_rota = null; }
            }
        }
        public string Ds_rota { get; set; }
        private decimal? id_veiculo;
        public decimal? Id_veiculo
        {
            get { return id_veiculo; }
            set
            {
                id_veiculo = value;
                id_veiculostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_veiculostr;
        public string Id_veiculostr
        {
            get { return id_veiculostr; }
            set
            {
                id_veiculostr = value;
                try
                {
                    id_veiculo = decimal.Parse(value);
                }
                catch { id_veiculo = null; }
            }
        }
        public string Ds_veiculo
        { get; set; }
        public string Placa
        { get; set; }
        private DateTime? dt_carga;

        public DateTime? Dt_carga
        {
            get { return dt_carga; }
            set
            {
                dt_carga = value;
                dt_cargastr = value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty;
            }
        }
        private string dt_cargastr;
        public string Dt_cargastr
        {
            get { return dt_cargastr; }
            set
            {
                dt_cargastr = value;
                try
                {
                    dt_carga = DateTime.Parse(value);
                }
                catch
                { dt_carga = null; }
            }
        }
        public string Obs
        { get; set; }

        public string St_registro
        { get; set; }
        public string Status
        {
            get
            {
                if (St_registro.Trim().ToUpper().Equals("A"))
                    return "ABERTA";
                else if (St_registro.Trim().ToUpper().Equals("E"))
                    return "ENCERRADA";
                else return "PROCESSADA";
            }
        }

        public TList_ItensCargaAvulsa lItens
        { get; set; }

        public TList_ItensCargaAvulsa lItensDel
        { get; set; }

        public TRegistro_CargaAvulsa()
        {
            Cd_empresa = string.Empty;
            Nm_empresa = string.Empty;
            id_carga = null;
            id_cargastr = string.Empty;
            Cd_motorista = string.Empty;
            Nm_motorista = string.Empty;
            id_rota = null;
            id_rotastr = string.Empty;
            id_veiculo = null;
            id_veiculostr = string.Empty;
            Ds_veiculo = string.Empty;
            Placa = string.Empty;
            dt_carga = UtilData.Data_Servidor();
            dt_cargastr = UtilData.Data_Servidor().ToString("dd/MM/yyyy");
            Obs = string.Empty;
            St_registro = "A";

            lItens = new TList_ItensCargaAvulsa();
            lItensDel = new TList_ItensCargaAvulsa();
        }
    }

    public class TCD_CargaAvulsa : TDataQuery
    {
        public TCD_CargaAvulsa()
        { }

        public TCD_CargaAvulsa(BancoDados.TObjetoBanco banco)
        { Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNm_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = " TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNm_Campo))
            {
                sql.AppendLine("Select " + strTop + "a.CD_Empresa, emp.nm_empresa, a.ID_Carga, a.id_rota, d.ds_rota, a.CD_Motorista, ");
                sql.AppendLine("c.nm_clifor as NM_Motorista, a.id_veiculo, b.ds_veiculo, b.Placa, a.DT_Carga,  ");
                sql.AppendLine("a.Obs, a.ST_Registro ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNm_Campo + " ");
            sql.AppendLine("from TB_FAT_CargaAvulsa a ");
            sql.AppendLine("inner join TB_DIV_Empresa emp ");
            sql.AppendLine("on a.cd_empresa = emp.cd_empresa ");
            sql.AppendLine("left outer join TB_FRT_Veiculo b ");
            sql.AppendLine("on a.id_veiculo = b.id_veiculo ");
            sql.AppendLine("left outer join TB_FIN_Clifor c ");
            sql.AppendLine("on a.cd_motorista = c.cd_clifor ");
            sql.AppendLine("left outer join TB_DIV_Rota d ");
            sql.AppendLine("on d.id_rota = a.id_rota ");

            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + ")");
                    cond = " and ";
                }
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

        public TList_CargaAvulsa Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNm_Campo)
        {
            TList_CargaAvulsa lista = new TList_CargaAvulsa();
            System.Data.SqlClient.SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            try
            {
                reader = ExecutarBusca(SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNm_Campo));
                while (reader.Read())
                {
                    TRegistro_CargaAvulsa reg = new TRegistro_CargaAvulsa();
                    if (!reader.IsDBNull(reader.GetOrdinal("Cd_empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("Cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Nm_empresa")))
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("Nm_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Carga")))
                        reg.Id_carga = reader.GetDecimal(reader.GetOrdinal("ID_Carga"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Motorista")))
                        reg.Cd_motorista = reader.GetString(reader.GetOrdinal("CD_Motorista"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NM_Motorista")))
                        reg.Nm_motorista = reader.GetString(reader.GetOrdinal("NM_Motorista"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Id_rota")))
                        reg.Id_rota = reader.GetDecimal(reader.GetOrdinal("Id_rota"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Ds_rota")))
                        reg.Ds_rota = reader.GetString(reader.GetOrdinal("Ds_rota"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Id_veiculo")))
                        reg.Id_veiculo = reader.GetDecimal(reader.GetOrdinal("Id_veiculo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Ds_veiculo")))
                        reg.Ds_veiculo = reader.GetString(reader.GetOrdinal("Ds_veiculo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Placa")))
                        reg.Placa = reader.GetString(reader.GetOrdinal("Placa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DT_Carga")))
                        reg.Dt_carga = reader.GetDateTime(reader.GetOrdinal("DT_Carga"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Obs")))
                        reg.Obs = reader.GetString(reader.GetOrdinal("Obs"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_registro")))
                        reg.St_registro = reader.GetString(reader.GetOrdinal("ST_Registro"));

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

        public string Gravar(TRegistro_CargaAvulsa val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(7);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_CARGA", val.Id_carga);
            hs.Add("@P_CD_MOTORISTA", val.Cd_motorista);
            hs.Add("@P_ID_ROTA", val.Id_rota);
            hs.Add("@P_ID_VEICULO", val.Id_veiculo);
            hs.Add("@P_DT_CARGA", val.Dt_carga);
            hs.Add("@P_OBS", val.Obs);
            hs.Add("@P_ST_REGISTRO", val.St_registro);

            return executarProc("IA_FAT_CARGAAVULSA", hs);
        }

        public string Excluir(TRegistro_CargaAvulsa val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(2);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_CARGA", val.Id_carga);

            return executarProc("EXCLUI_FAT_CARGAAVULSA", hs);
        }
    }
    #endregion

    #region Itens Carga Avulsa
    public class TList_ItensCargaAvulsa : List<TRegistro_ItensCargaAvulsa>, IComparer<TRegistro_ItensCargaAvulsa>
    {

        #region IComparer<TRegistro_ItensCargaAvulsa> Members
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

        public TList_ItensCargaAvulsa()
        { }

        public TList_ItensCargaAvulsa(System.ComponentModel.PropertyDescriptor Prop,
                                  System.Windows.Forms.SortOrder Dir)
        {
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_ItensCargaAvulsa value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_ItensCargaAvulsa x, TRegistro_ItensCargaAvulsa y)
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


    public class TRegistro_ItensCargaAvulsa
    {
        public string Cd_empresa
        { get; set; }
        public string Nm_empresa
        { get; set; }
        private decimal? id_carga;

        public decimal? Id_carga
        {
            get { return id_carga; }
            set
            {
                id_carga = value;
                id_cargastr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_cargastr;

        public string Id_cargastr
        {
            get { return id_cargastr; }
            set
            {
                id_cargastr = value;
                try
                {
                    id_carga = decimal.Parse(value);
                }
                catch
                { id_carga = null; }
            }
        }
        private decimal? id_item;

        public decimal? Id_item
        {
            get { return id_item; }
            set
            {
                id_item = value;
                id_itemstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_itemstr;

        public string Id_itemstr
        {
            get { return id_itemstr; }
            set
            {
                id_itemstr = value;
                try
                {
                    id_item = decimal.Parse(value);
                }
                catch
                { id_item = null; }
            }
        }
        public string Cd_produto
        { get; set; }
        public string Ds_produto
        { get; set; }
        public string Cd_unidade
        { get; set; }
        public string Ds_unidade
        { get; set; }
        public string Sigla
        { get; set; }
        public decimal? Id_lanctoEstoqueS
        { get; set; }
        public decimal? Nr_LanctoFiscalS
        { get; set; }
        public decimal? ID_NFItemS
        { get; set; }
        public decimal? Id_lanctoEstoqueD
        { get; set; }
        public decimal? Nr_LanctoFiscalD
        { get; set; }
        public decimal? ID_NFItemD
        { get; set; }

        public decimal Quantidade
        { get; set; }
        public decimal Vl_custoUnit
        { get; set; }
        public decimal Qtd_devolvida
        { get; set; }
        public decimal Qtd_consumida
        { get; set; }
        public decimal Saldo => Quantidade - Qtd_devolvida - Qtd_consumida;
        public CamadaDados.Locacao.TList_ItensLocTerceiro lItensLocTerceiro
        { get; set; }

        public TRegistro_ItensCargaAvulsa()
        {
            Cd_empresa = string.Empty;
            Nm_empresa = string.Empty;
            id_carga = null;
            id_cargastr = string.Empty;
            id_item = null;
            id_itemstr = string.Empty;
            Cd_produto = string.Empty;
            Ds_produto = string.Empty;
            Cd_unidade = string.Empty;
            Ds_unidade = string.Empty;
            Sigla = string.Empty;
            Id_lanctoEstoqueS = null;
            Nr_LanctoFiscalS = null;
            ID_NFItemS = null;
            Id_lanctoEstoqueD = null;
            Nr_LanctoFiscalD = null;
            ID_NFItemD = null;
            Quantidade = decimal.Zero;
            Vl_custoUnit = decimal.Zero;
            Qtd_devolvida = decimal.Zero;
            lItensLocTerceiro = new CamadaDados.Locacao.TList_ItensLocTerceiro();
        }
    }

    public class TCD_ItensCargaAvulsa : TDataQuery
    {
        public TCD_ItensCargaAvulsa()
        { }

        public TCD_ItensCargaAvulsa(BancoDados.TObjetoBanco banco)
        { Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, int vTop, string vNm_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = " TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNm_Campo))
            {
                sql.AppendLine("Select " + strTop + " a.CD_Empresa, b.NM_Empresa, a.ID_Carga, a.ID_Item, ");
                sql.AppendLine("a.CD_Produto, c.ds_produto, c.cd_unidade, d.ds_unidade, d.sigla_unidade, a.ID_lanctoEstoqueS, a.Nr_LanctoFiscalS, a.ID_NFItemS, ");
                sql.AppendLine("a.Id_LanctoEstoqueD, a.Nr_LanctoFiscalD, a.ID_NFItemD, a.Quantidade, ");
                sql.AppendLine("a.Qtd_devolvida, a.Vl_custoUnit, a.Qtd_consumida ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNm_Campo + " ");
            sql.AppendLine("from VTB_FAT_ItensCargaAvulsa a ");
            sql.AppendLine("inner join TB_DIV_Empresa b ");
            sql.AppendLine("on a.cd_empresa = b.cd_empresa ");
            sql.AppendLine("inner join TB_EST_Produto c ");
            sql.AppendLine("on a.cd_produto = c.cd_produto");
            sql.AppendLine("left outer join TB_EST_Unidade d ");
            sql.AppendLine("on c.cd_unidade = d.cd_unidade ");

            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + ")");
                    cond = " and ";
                }
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

        public TList_ItensCargaAvulsa Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNm_Campo)
        {
            TList_ItensCargaAvulsa lista = new TList_ItensCargaAvulsa();
            System.Data.SqlClient.SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            try
            {
                reader = ExecutarBusca(SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNm_Campo));
                while (reader.Read())
                {
                    TRegistro_ItensCargaAvulsa reg = new TRegistro_ItensCargaAvulsa();

                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("CD_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NM_Empresa")))
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("NM_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Carga")))
                        reg.Id_carga = reader.GetDecimal(reader.GetOrdinal("ID_Carga"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Id_item")))
                        reg.Id_item = reader.GetDecimal(reader.GetOrdinal("Id_item"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Produto")))
                        reg.Cd_produto = reader.GetString(reader.GetOrdinal("CD_Produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_produto")))
                        reg.Ds_produto = reader.GetString(reader.GetOrdinal("ds_produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Cd_unidade")))
                        reg.Cd_unidade = reader.GetString(reader.GetOrdinal("Cd_unidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Ds_unidade")))
                        reg.Ds_unidade = reader.GetString(reader.GetOrdinal("Ds_unidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Sigla_Unidade")))
                        reg.Sigla = reader.GetString(reader.GetOrdinal("Sigla_Unidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Id_lanctoEstoqueS")))
                        reg.Id_lanctoEstoqueS = reader.GetDecimal(reader.GetOrdinal("Id_lanctoEstoqueS"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Nr_LanctoFiscalS")))
                        reg.Nr_LanctoFiscalS = reader.GetDecimal(reader.GetOrdinal("Nr_LanctoFiscalS"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_NFItemS")))
                        reg.ID_NFItemS = reader.GetDecimal(reader.GetOrdinal("ID_NFItemS"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Id_LanctoEstoqueD")))
                        reg.Id_lanctoEstoqueD = reader.GetDecimal(reader.GetOrdinal("Id_LanctoEstoqueD"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Nr_LanctoFiscalD")))
                        reg.Nr_LanctoFiscalD = reader.GetDecimal(reader.GetOrdinal("Nr_LanctoFiscalD"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_NFItemD")))
                        reg.ID_NFItemD = reader.GetDecimal(reader.GetOrdinal("ID_NFItemD"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Quantidade")))
                        reg.Quantidade = reader.GetDecimal(reader.GetOrdinal("Quantidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_custoUnit")))
                        reg.Vl_custoUnit = reader.GetDecimal(reader.GetOrdinal("Vl_custoUnit"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Qtd_devolvida")))
                        reg.Qtd_devolvida = reader.GetDecimal(reader.GetOrdinal("Qtd_devolvida"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Qtd_consumida")))
                        reg.Qtd_consumida = reader.GetDecimal(reader.GetOrdinal("Qtd_consumida"));

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

        public string Gravar(TRegistro_ItensCargaAvulsa val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(11);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_CARGA", val.Id_carga);
            hs.Add("@P_ID_ITEM", val.Id_item);
            hs.Add("@P_CD_PRODUTO", val.Cd_produto);
            hs.Add("@P_ID_LANCTOESTOQUES", val.Id_lanctoEstoqueS);
            hs.Add("@P_NR_LANCTOFISCALS", val.Nr_LanctoFiscalS);
            hs.Add("@P_ID_NFITEMS", val.ID_NFItemS);
            hs.Add("@P_ID_LANCTOESTOQUED", val.Id_lanctoEstoqueD);
            hs.Add("@P_NR_LANCTOFISCALD", val.Nr_LanctoFiscalD);
            hs.Add("@P_ID_NFITEMD", val.ID_NFItemD);
            hs.Add("@P_QUANTIDADE", val.Quantidade);

            return executarProc("IA_FAT_ITENSCARGAAVULSA", hs);
        }

        public string Excluir(TRegistro_ItensCargaAvulsa val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(3);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_CARGA", val.Id_carga);
            hs.Add("@P_ID_ITEM", val.Id_item);

            return executarProc("EXCLUI_FAT_ITENSCARGAAVULSA", hs);
        }
    }
    #endregion
}
