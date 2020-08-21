using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamadaDados.PostoCombustivel.Cadastros
{
    public class TList_BicoBomba : List<TRegistro_BicoBomba>, IComparer<TRegistro_BicoBomba>
    {
        #region IComparer<TRegistro_BicoBomba> Members
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

        public TList_BicoBomba()
        { }

        public TList_BicoBomba(System.ComponentModel.PropertyDescriptor Prop,
                               System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_BicoBomba value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_BicoBomba x, TRegistro_BicoBomba y)
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
    
    public class TRegistro_BicoBomba
    {
        private decimal? id_bico;
        public decimal? Id_bico
        {
            get { return id_bico; }
            set
            {
                id_bico = value;
                id_bicostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_bicostr;
        public string Id_bicostr
        {
            get { return id_bicostr; }
            set
            {
                id_bicostr = value;
                try
                {
                    id_bico = decimal.Parse(value);
                }
                catch
                { id_bico = null; }
            }
        }
        public string Enderecofisicobico
        { get; set; }
        public string Ds_label
        { get; set; }
        private decimal? id_bomba;
        public decimal? Id_bomba
        {
            get { return id_bomba; }
            set
            {
                id_bomba = value;
                id_bombastr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_bombastr;
        public string Id_bombastr
        {
            get { return id_bombastr; }
            set
            {
                id_bombastr = value;
                try
                {
                    id_bomba = decimal.Parse(value);
                }
                catch
                { id_bomba = null; }
            }
        }
        private decimal? id_tanque;
        public decimal? Id_tanque
        {
            get { return id_tanque; }
            set
            {
                id_tanque = value;
                id_tanquestr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_tanquestr;
        public string Id_tanquestr
        {
            get { return id_tanquestr; }
            set
            {
                id_tanquestr = value;
                try
                {
                    id_tanque = decimal.Parse(value);
                }
                catch
                { id_tanque = null; }
            }
        }
        public string Cd_empresa
        { get; set; }
        public string Nm_empresa
        { get; set; }
        public string Cd_produto
        { get; set; }
        public string Ds_produto
        { get; set; }
        public string Sigla_unidade
        { get; set; }
        public decimal Qtd_encerrante
        { get; set; }
        public string St_registro
        { get; set; }
        public string Status
        {
            get
            {
                if (this.St_registro.Trim().ToUpper().Equals("A"))
                    return "ATIVO";
                else if (this.St_registro.Trim().ToUpper().Equals("C"))
                    return "CANCELADO";
                else return string.Empty;
            }
        }
        private DateTime? dt_desativacao;
        public DateTime? Dt_desativacao
        {
            get { return dt_desativacao; }
            set
            {
                dt_desativacao = value;
                dt_desativacaostr = value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty;
            }
        }
        private string dt_desativacaostr;
        public string Dt_desativacaostr
        {
            get
            {
                try
                {
                    return DateTime.Parse(dt_desativacaostr).ToString("dd/MM/yyyy");
                }
                catch
                { return string.Empty; }
            }
            set
            {
                dt_desativacaostr = value;
                try
                {
                    dt_desativacao = DateTime.Parse(value);
                }
                catch
                { dt_desativacao = null; }
            }
        }
        private DateTime? dt_ativacao;
        public DateTime? Dt_ativacao
        {
            get { return dt_ativacao; }
            set
            {
                dt_ativacao = value;
                dt_ativacaostr = value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty;
            }
        }
        private string dt_ativacaostr;
        public string Dt_ativacaostr
        {
            get
            {
                try
                {
                    return DateTime.Parse(dt_ativacaostr).ToString("dd/MM/yyyy");
                }
                catch
                { return string.Empty; }
            }
            set
            {
                dt_ativacaostr = value;
                try
                {
                    dt_ativacao = DateTime.Parse(value);
                }
                catch
                { dt_ativacao = null; }
            }
        }
        public decimal Encerrante_abertura
        { get; set; }
        public decimal Vendas_calculada
        { get { return this.Qtd_encerrante - this.Encerrante_abertura; } }
        public decimal Volume_vendido
        { get; set; }
        public decimal Volume_afericao
        { get; set; }
        public decimal Diferenca_venda
        { get { return this.Vendas_calculada - (this.Volume_vendido + this.Volume_afericao); } }
        public bool St_processar
        { get; set; }
        
        public TRegistro_BicoBomba()
        {
            this.id_bico = null;
            this.id_bicostr = string.Empty;
            this.Enderecofisicobico = string.Empty;
            this.Ds_label = string.Empty;
            this.id_bomba = null;
            this.id_bombastr = string.Empty;
            this.id_tanque = null;
            this.id_tanquestr = string.Empty;
            this.Cd_produto = string.Empty;
            this.Ds_produto = string.Empty;
            this.Sigla_unidade = string.Empty;
            this.Cd_empresa = string.Empty;
            this.Nm_empresa = string.Empty;
            this.Qtd_encerrante = decimal.Zero;
            this.St_registro = "A";
            this.St_processar = false;
            this.dt_desativacao = null;
            this.dt_desativacaostr = string.Empty;
            this.dt_ativacao = null;
            this.dt_ativacaostr = string.Empty;
            this.Encerrante_abertura = decimal.Zero;
            this.Volume_vendido = decimal.Zero;
            this.Volume_afericao = decimal.Zero;
        }
    }

    public class TCD_BicoBomba : TDataQuery
    {
        public TCD_BicoBomba()
        { }

        public TCD_BicoBomba(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        public string SqlCodeBusca(Utils.TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            string strtop = string.Empty;
            if (vTop > 0)
                strtop = " top " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("select " + strtop + " a.id_bico, a.id_bomba, a.id_tanque, a.dt_desativacao, ");
                sql.AppendLine("b.cd_produto, c.ds_produto, e.sigla_unidade, a.st_registro, a.dt_ativacao, ");
                sql.AppendLine("a.enderecofisicobico, a.cd_empresa, d.nm_empresa, a.ds_label ");
            }
            else
                sql.AppendLine("Select " + strtop + " " + vNM_Campo);

            sql.AppendLine("from TB_PDC_BicoBomba a ");
            sql.AppendLine("inner join TB_PDC_Tanque b ");
            sql.AppendLine("on a.id_tanque = b.id_tanque ");
            sql.AppendLine("inner join TB_EST_Produto c ");
            sql.AppendLine("on b.cd_produto = c.cd_produto ");
            sql.AppendLine("inner join TB_DIV_Empresa d ");
            sql.AppendLine("on a.cd_empresa = d.cd_empresa ");
            sql.AppendLine("inner join TB_EST_Unidade e ");
            sql.AppendLine("on c.cd_unidade = e.cd_unidade ");
            sql.AppendLine("inner join TB_EST_TpProduto f ");
            sql.AppendLine("on c.tp_produto = f.tp_produto ");
            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.Append(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                    cond = " and ";
                }
            return sql.ToString();
        }

        public override System.Data.DataTable Buscar(Utils.TpBusca[] vBusca, short vTop)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, string.Empty), null);
        }

        public override System.Data.DataTable Buscar(Utils.TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo), null);
        }

        public override object BuscarEscalar(Utils.TpBusca[] vBusca, string vNM_Campo)
        {
            return this.ExecutarBuscaEscalar(this.SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }

        public TList_BicoBomba Select(Utils.TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            TList_BicoBomba lista = new TList_BicoBomba();
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_BicoBomba reg = new TRegistro_BicoBomba();
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Bomba")))
                        reg.Id_bomba = reader.GetDecimal(reader.GetOrdinal("ID_Bomba"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_tanque")))
                        reg.Id_tanque = reader.GetDecimal(reader.GetOrdinal("id_tanque"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_bico")))
                        reg.Id_bico = reader.GetDecimal(reader.GetOrdinal("id_bico"));
                    if (!reader.IsDBNull(reader.GetOrdinal("enderecofisicobico")))
                        reg.Enderecofisicobico = reader.GetString(reader.GetOrdinal("enderecofisicobico"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_label")))
                        reg.Ds_label = reader.GetString(reader.GetOrdinal("ds_label"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_produto")))
                        reg.Cd_produto = reader.GetString(reader.GetOrdinal("cd_produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_produto")))
                        reg.Ds_produto = reader.GetString(reader.GetOrdinal("ds_produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("sigla_unidade")))
                        reg.Sigla_unidade = reader.GetString(reader.GetOrdinal("sigla_unidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_empresa")))
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("nm_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_registro")))
                        reg.St_registro = reader.GetString(reader.GetOrdinal("st_registro"));
                    if (!reader.IsDBNull(reader.GetOrdinal("dt_desativacao")))
                        reg.Dt_desativacao = reader.GetDateTime(reader.GetOrdinal("dt_desativacao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("dt_ativacao")))
                        reg.Dt_ativacao = reader.GetDateTime(reader.GetOrdinal("dt_ativacao"));
                    
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

        public TList_BicoBomba SelectEncerrante(string Cd_empresa,
                                                string Id_caixa)
        {
            TList_BicoBomba lista = new TList_BicoBomba();
            bool podeFecharBco = false;
            //Montar string de busca
            StringBuilder sql = new StringBuilder();
            sql.Append("select a.id_bico, a.id_bomba, a.id_tanque, a.dt_desativacao, ");
            sql.AppendLine("b.cd_produto, c.ds_produto, e.sigla_unidade, a.st_registro, a.dt_ativacao, ");
            sql.AppendLine("a.enderecofisicobico, a.cd_empresa, d.nm_empresa, a.ds_label, ");
            sql.AppendLine("Encerrante_Abertura = ISNULL((select top 1 x.encerrante ");
            sql.AppendLine("                                from tb_pdc_encerrantecaixa x ");
            sql.AppendLine("                                inner join TB_PDV_Caixa y ");
            sql.AppendLine("                                on x.id_caixa = y.ID_Caixa ");
            sql.AppendLine("                                where x.id_bico = a.ID_Bico ");
            sql.AppendLine("                                and y.CD_Empresa = a.CD_Empresa ");
            sql.AppendLine("                                and y.ID_Caixa < " + Id_caixa);
            sql.AppendLine("                                order by y.ID_Caixa desc), 0), ");
            sql.AppendLine("Volume_Vendido = ISNULL((select SUM(ISNULL(x.VolumeAbastecido, 0)) ");
            sql.AppendLine("                            from TB_PDC_VendaCombustivel x ");
            sql.AppendLine("                            where x.ID_Bico = a.ID_Bico ");
            sql.AppendLine("                            and ISNULL(x.ST_Registro, 'A') = 'F' ");
            sql.AppendLine("                            and (exists(select 1 from TB_PDV_Cupom_X_MovCaixa y ");
            sql.AppendLine("                                        where y.CD_Empresa = x.CD_Empresa ");
            sql.AppendLine("                                        and y.Id_Cupom = x.Id_Cupom ");
            sql.AppendLine("                                        and y.ID_Caixa = " + Id_caixa + ") or ");
            sql.AppendLine("                                exists(select 1 from TB_PDV_CupomFiscal_X_Duplicata y ");
            sql.AppendLine("                                        where y.CD_Empresa = x.CD_Empresa ");
            sql.AppendLine("                                        and y.Id_Cupom = x.Id_Cupom ");
            sql.AppendLine("                                        and y.ID_Caixa = " + Id_caixa + "))), 0), ");
            sql.AppendLine("volume_afericao = ISNULL((select SUM(ISNULL(x.VolumeAbastecido, 0)) ");
            sql.AppendLine("                            from TB_PDC_VendaCombustivel x ");
            sql.AppendLine("                            where x.ID_Bico = a.ID_Bico ");
            sql.AppendLine("                            and ISNULL(x.ST_Registro, 'A') <> 'C' ");
            sql.AppendLine("                            and ISNULL(x.ST_Afericao, 'N') = 'S' ");
            sql.AppendLine("                            and x.id_caixa = " + Id_caixa + "), 0) ");

            sql.AppendLine("from TB_PDC_BicoBomba a ");
            sql.AppendLine("inner join TB_PDC_Tanque b ");
            sql.AppendLine("on a.id_tanque = b.id_tanque ");
            sql.AppendLine("inner join TB_EST_Produto c ");
            sql.AppendLine("on b.cd_produto = c.cd_produto ");
            sql.AppendLine("inner join TB_DIV_Empresa d ");
            sql.AppendLine("on a.cd_empresa = d.cd_empresa ");
            sql.AppendLine("inner join TB_EST_Unidade e ");
            sql.AppendLine("on c.cd_unidade = e.cd_unidade ");

            sql.AppendLine("where a.cd_empresa = '" + Cd_empresa.Trim() + "'");
            sql.AppendLine("and isnull(a.st_registro, 'A') <> 'C'");

            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = this.ExecutarBusca(sql.ToString());
            try
            {
                while (reader.Read())
                {
                    TRegistro_BicoBomba reg = new TRegistro_BicoBomba();
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Bomba")))
                        reg.Id_bomba = reader.GetDecimal(reader.GetOrdinal("ID_Bomba"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_tanque")))
                        reg.Id_tanque = reader.GetDecimal(reader.GetOrdinal("id_tanque"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_bico")))
                        reg.Id_bico = reader.GetDecimal(reader.GetOrdinal("id_bico"));
                    if (!reader.IsDBNull(reader.GetOrdinal("enderecofisicobico")))
                        reg.Enderecofisicobico = reader.GetString(reader.GetOrdinal("enderecofisicobico"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_label")))
                        reg.Ds_label = reader.GetString(reader.GetOrdinal("ds_label"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_produto")))
                        reg.Cd_produto = reader.GetString(reader.GetOrdinal("cd_produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_produto")))
                        reg.Ds_produto = reader.GetString(reader.GetOrdinal("ds_produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("sigla_unidade")))
                        reg.Sigla_unidade = reader.GetString(reader.GetOrdinal("sigla_unidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_empresa")))
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("nm_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_registro")))
                        reg.St_registro = reader.GetString(reader.GetOrdinal("st_registro"));
                    if (!reader.IsDBNull(reader.GetOrdinal("dt_desativacao")))
                        reg.Dt_desativacao = reader.GetDateTime(reader.GetOrdinal("dt_desativacao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("dt_ativacao")))
                        reg.Dt_ativacao = reader.GetDateTime(reader.GetOrdinal("dt_ativacao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Encerrante_Abertura")))
                        reg.Encerrante_abertura = reader.GetDecimal(reader.GetOrdinal("Encerrante_Abertura"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Volume_Vendido")))
                        reg.Volume_vendido = reader.GetDecimal(reader.GetOrdinal("Volume_Vendido"));
                    if (!reader.IsDBNull(reader.GetOrdinal("volume_afericao")))
                        reg.Volume_afericao = reader.GetDecimal(reader.GetOrdinal("volume_afericao"));

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

        public string Gravar(TRegistro_BicoBomba val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(9);
            hs.Add("@P_ID_BICO", val.Id_bico);
            hs.Add("@P_ID_BOMBA", val.Id_bomba);
            hs.Add("@P_ID_TANQUE", val.Id_tanque);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ENDERECOFISICOBICO", val.Enderecofisicobico);
            hs.Add("@P_DS_LABEL", val.Ds_label);
            hs.Add("@P_DT_ATIVACAO", val.Dt_ativacao);
            hs.Add("@P_DT_DESATIVACAO", val.Dt_desativacao);
            hs.Add("@P_ST_REGISTRO", val.St_registro);

            return this.executarProc("IA_PDC_BICOBOMBA", hs);
        }

        public string Excluir(TRegistro_BicoBomba val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(1);
            hs.Add("@P_ID_BICO", val.Id_bico);

            return this.executarProc("EXCLUI_PDC_BICOBOMBA", hs);
        }
    }
}
