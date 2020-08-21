using System;
using System.Collections.Generic;
using System.Text;

namespace CamadaDados.PostoCombustivel
{
    public class TList_CartaFrete : List<TRegistro_CartaFrete>, IComparer<TRegistro_CartaFrete>
    {
        #region IComparer<TRegistro_CartaFrete> Members
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

        public TList_CartaFrete()
        { }

        public TList_CartaFrete(System.ComponentModel.PropertyDescriptor Prop,
                                System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_CartaFrete value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_CartaFrete x, TRegistro_CartaFrete y)
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

    public class TRegistro_CartaFrete
    {
        public string Cd_empresa
        { get; set; }
        public string Nm_empresa
        { get; set; }
        private decimal? id_cartafrete;
        public decimal? Id_cartafrete
        {
            get { return id_cartafrete; }
            set
            {
                id_cartafrete = value;
                id_cartafretestr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_cartafretestr;
        public string Id_cartafretestr
        {
            get { return id_cartafretestr; }
            set
            {
                id_cartafretestr = value;
                try
                {
                    id_cartafrete = decimal.Parse(value);
                }
                catch
                { id_cartafrete = null; }
            }
        }
        public string Cd_transportadora
        { get; set; }
        public string Nm_transportadora
        { get; set; }
        public string Cd_enderecotransp
        { get; set; }
        public string Ds_enderecotransp
        { get; set; }
        public string Cd_unidpagadora
        { get; set; }
        public string Nm_unidpagadora
        { get; set; }
        public string Cd_endunidpagadora
        { get; set; }
        public string Ds_endunidpagadora
        { get; set; }
        private decimal? nr_lancto;
        public decimal? Nr_lancto
        {
            get { return nr_lancto; }
            set
            {
                nr_lancto = value;
                nr_lanctostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string nr_lanctostr;
        public string Nr_lanctostr
        {
            get { return nr_lanctostr; }
            set
            {
                nr_lanctostr = value;
                try
                {
                    nr_lancto = decimal.Parse(value);
                }
                catch
                { nr_lancto = null; }
            }
        }
        public string Nr_cartafrete
        { get; set; }
        public DateTime? Dt_entrada
        { get; set; }
        private DateTime? dt_emissao;
        public DateTime? Dt_emissao
        {
            get { return dt_emissao; }
            set
            {
                dt_emissao = value;
                dt_emissaostr = value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty;
            }
        }
        private string dt_emissaostr;
        public string Dt_emissaostr
        {
            get
            {
                try
                {
                    return DateTime.Parse(dt_emissaostr).ToString("dd/MM/yyyy");
                }
                catch
                { return string.Empty; }
            }
            set
            {
                dt_emissaostr = value;
                try
                {
                    dt_emissao = DateTime.Parse(value);
                }
                catch
                { dt_emissao = null; }
            }
        }
        private DateTime? dt_vencimento;
        public DateTime? Dt_vencimento
        {
            get { return dt_vencimento; }
            set
            {
                dt_vencimento = value;
                dt_vencimentostr = value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty;
            }
        }
        private string dt_vencimentostr;
        public string Dt_vencimentostr
        {
            get
            {
                try
                {
                    return DateTime.Parse(dt_vencimentostr).ToString("dd/MM/yyyy");
                }
                catch
                { return string.Empty; }
            }
            set
            {
                dt_vencimentostr = value;
                try
                {
                    dt_vencimento = DateTime.Parse(value);
                }
                catch
                { dt_vencimento = null; }
            }
        }
        public decimal Vl_documento
        { get; set; }
        public string Nm_motorista
        { get; set; }
        public string Placaveiculo
        { get; set; }
        public string Nr_frota
        { get; set; }
        public decimal Kilometragem
        { get; set; }
        public string St_registro { get; set; } = "A";
        public string Status => St_registro.Trim().ToUpper().Equals("C") ? "CANCELADO" : "ATIVO";
        public decimal? Id_cupom
        { get; set; }

        public TRegistro_CartaFrete()
        {
            Cd_empresa = string.Empty;
            Nm_empresa = string.Empty;
            id_cartafrete = null;
            id_cartafretestr = string.Empty;
            Cd_transportadora = string.Empty;
            Nm_transportadora = string.Empty;
            Cd_enderecotransp = string.Empty;
            Ds_enderecotransp = string.Empty;
            Cd_unidpagadora = string.Empty;
            Nm_unidpagadora = string.Empty;
            Cd_endunidpagadora = string.Empty;
            Ds_endunidpagadora = string.Empty;
            nr_lancto = null;
            nr_lanctostr = string.Empty;
            Nr_cartafrete = string.Empty;
            Dt_entrada = null;
            dt_emissao = null;
            dt_emissaostr = string.Empty;
            dt_vencimento = null;
            dt_vencimentostr = string.Empty;
            Vl_documento = decimal.Zero;
            Nm_motorista = string.Empty;
            Placaveiculo = string.Empty;
            Nr_frota = string.Empty;
            Kilometragem = decimal.Zero;
            Id_cupom = null;
        }
    }

    public class TCD_CartaFrete : TDataQuery
    {
        public TCD_CartaFrete()
        { }

        public TCD_CartaFrete(BancoDados.TObjetoBanco banco)
        { Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + vTop.ToString();

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("select " + strTop + " a.CD_Empresa, b.NM_Empresa, a.ID_CartaFrete, ");
                sql.AppendLine("a.CD_Transportadora, isnull(a.nm_transportadora, c.NM_Clifor) as NM_Transportadora, ");
                sql.AppendLine("a.CD_EnderecoTransp, d.DS_Endereco as DS_EnderecoTransp, a.dt_cad as dt_entrada, ");
                sql.AppendLine("a.CD_UnidPagadora, e.NM_Clifor as NM_UnidPagadora, ");
                sql.AppendLine("a.CD_EndUnidPagadora, f.DS_Endereco as DS_EndUnidPagadora, ");
                sql.AppendLine("a.Nr_Lancto, a.NR_CartaFrete, a.DT_Emissao, ");
                sql.AppendLine("a.DT_Vencimento, a.Vl_Documento, a.NM_Motorista, ");
                sql.AppendLine("a.PlacaVeiculo, a.NR_Frota, a.Kilometragem, ISNULL(a.st_registro, 'A') as ST_Registro, g.id_cupom ");
            }
            else
                sql.AppendLine(" Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from TB_PDC_CartaFrete a ");
            sql.AppendLine("inner join TB_DIV_Empresa b ");
            sql.AppendLine("on a.CD_Empresa = b.CD_Empresa ");
            sql.AppendLine("left outer join VTB_FIN_CLIFOR c ");
            sql.AppendLine("on a.CD_Transportadora = c.CD_Clifor ");
            sql.AppendLine("left outer join VTB_FIN_ENDERECO d ");
            sql.AppendLine("on a.CD_Transportadora = d.CD_Clifor ");
            sql.AppendLine("and a.CD_EnderecoTransp = d.CD_Endereco ");
            sql.AppendLine("left outer join VTB_FIN_CLIFOR e ");
            sql.AppendLine("on a.CD_UnidPagadora = e.CD_Clifor ");
            sql.AppendLine("left outer join VTB_FIN_ENDERECO f ");
            sql.AppendLine("on a.CD_UnidPagadora = f.CD_Clifor ");
            sql.AppendLine("and a.CD_EndUnidPagadora = f.CD_Endereco ");
            sql.AppendLine("left outer join tb_pdv_cupom_x_movcaixa g ");
            sql.AppendLine("on g.cd_empresa = a.cd_empresa ");
            sql.AppendLine("and g.id_cartafrete = a.id_cartafrete ");

            sql.AppendLine("where isnull(a.st_registro, 'A') <> 'C' ");

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

        public TList_CartaFrete Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            bool podeFecharBco = false;
            TList_CartaFrete lista = new TList_CartaFrete();
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_CartaFrete reg = new TRegistro_CartaFrete();
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_Empresa"))))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("CD_Empresa"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("NM_Empresa"))))
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("NM_Empresa"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("ID_CartaFrete"))))
                        reg.Id_cartafrete = reader.GetDecimal(reader.GetOrdinal("ID_CartaFrete"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_Transportadora"))))
                        reg.Cd_transportadora = reader.GetString(reader.GetOrdinal("CD_Transportadora"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NM_Transportadora")))
                        reg.Nm_transportadora = reader.GetString(reader.GetOrdinal("NM_Transportadora"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_EnderecoTransp")))
                        reg.Cd_enderecotransp = reader.GetString(reader.GetOrdinal("CD_EnderecoTransp"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_EnderecoTransp")))
                        reg.Ds_enderecotransp = reader.GetString(reader.GetOrdinal("DS_EnderecoTransp"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_UnidPagadora")))
                        reg.Cd_unidpagadora = reader.GetString(reader.GetOrdinal("CD_UnidPagadora"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NM_UnidPagadora")))
                        reg.Nm_unidpagadora = reader.GetString(reader.GetOrdinal("NM_UnidPagadora"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_EndUnidPagadora")))
                        reg.Cd_endunidpagadora = reader.GetString(reader.GetOrdinal("CD_EndUnidPagadora"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_EndUnidPagadora")))
                        reg.Ds_endunidpagadora = reader.GetString(reader.GetOrdinal("DS_EndUnidPagadora"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Nr_Lancto")))
                        reg.Nr_lancto = reader.GetDecimal(reader.GetOrdinal("Nr_Lancto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NR_CartaFrete")))
                        reg.Nr_cartafrete = reader.GetString(reader.GetOrdinal("NR_CartaFrete"));
                    if (!reader.IsDBNull(reader.GetOrdinal("dt_entrada")))
                        reg.Dt_entrada = reader.GetDateTime(reader.GetOrdinal("dt_entrada"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DT_Emissao")))
                        reg.Dt_emissao = reader.GetDateTime(reader.GetOrdinal("DT_Emissao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DT_Vencimento")))
                        reg.Dt_vencimento = reader.GetDateTime(reader.GetOrdinal("DT_Vencimento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_Documento")))
                        reg.Vl_documento = reader.GetDecimal(reader.GetOrdinal("Vl_Documento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NM_Motorista")))
                        reg.Nm_motorista = reader.GetString(reader.GetOrdinal("NM_Motorista"));
                    if (!reader.IsDBNull(reader.GetOrdinal("PlacaVeiculo")))
                        reg.Placaveiculo = reader.GetString(reader.GetOrdinal("PlacaVeiculo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NR_Frota")))
                        reg.Nr_frota = reader.GetString(reader.GetOrdinal("NR_Frota"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Kilometragem")))
                        reg.Kilometragem = reader.GetDecimal(reader.GetOrdinal("Kilometragem"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ST_Registro")))
                        reg.St_registro = reader.GetString(reader.GetOrdinal("ST_Registro"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_cupom")))
                        reg.Id_cupom = reader.GetDecimal(reader.GetOrdinal("id_cupom"));

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

        public string Gravar(TRegistro_CartaFrete val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(17);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_CARTAFRETE", val.Id_cartafrete);
            hs.Add("@P_CD_TRANSPORTADORA", val.Cd_transportadora);
            hs.Add("@P_NM_TRANSPORTADORA", val.Nm_transportadora);
            hs.Add("@P_CD_ENDERECOTRANSP", val.Cd_enderecotransp);
            hs.Add("@P_CD_UNIDPAGADORA", val.Cd_unidpagadora);
            hs.Add("@P_CD_ENDUNIDPAGADORA", val.Cd_endunidpagadora);
            hs.Add("@P_NR_LANCTO", val.Nr_lancto);
            hs.Add("@P_NR_CARTAFRETE", val.Nr_cartafrete);
            hs.Add("@P_DT_EMISSAO", val.Dt_emissao);
            hs.Add("@P_DT_VENCIMENTO", val.Dt_vencimento);
            hs.Add("@P_VL_DOCUMENTO", val.Vl_documento);
            hs.Add("@P_NM_MOTORISTA", val.Nm_motorista);
            hs.Add("@P_PLACAVEICULO", val.Placaveiculo);
            hs.Add("@P_NR_FROTA", val.Nr_frota);
            hs.Add("@P_KILOMETRAGEM", val.Kilometragem);
            hs.Add("@P_ST_REGISTRO", val.St_registro);

            return executarProc("IA_PDC_CARTAFRETE", hs);
        }

        public string Excluir(TRegistro_CartaFrete val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(2);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_CARTAFRETE", val.Id_cartafrete);

            return executarProc("EXCLUI_PDC_CARTAFRETE", hs);
        }
    }
}
