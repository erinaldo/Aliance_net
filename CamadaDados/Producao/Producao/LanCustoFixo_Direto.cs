using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;
using System.Data.SqlClient;

namespace CamadaDados.Producao.Producao
{
    public class TList_CustoFixo_Direto : List<TRegistro_CustoFixo_Direto>
    { }

    public class TRegistro_CustoFixo_Direto
    {
        public string Cd_empresa
        { get; set; }
        public string Nm_empresa
        { get; set; }
        public decimal? Id_formulacao
        { get; set; }
        private decimal? id_custo;
        public decimal? Id_custo
        {
            get { return id_custo; }
            set
            {
                id_custo = value;
                id_custostr = value.Value.ToString();
            }
        }
        private string id_custostr;
        public string Id_custostr
        {
            get { return id_custostr; }
            set
            {
                id_custostr = value;
                try
                {
                    id_custo = Convert.ToDecimal(value);
                }
                catch
                { id_custo = null; }
            }
        }
        public string Ds_custo
        {get;set;}
        public string Tp_custo
        {get;set;}
        public string Cd_moeda
        { get; set; }
        public string Ds_moeda
        { get; set; }
        public string Sigla
        { get; set; }
        public string Cd_unidade
        { get; set; }
        public string Ds_unidade
        { get; set; }
        public string Sigla_unidade
        { get; set; }
        public decimal Vl_custo
        { get; set; }
        public decimal Pc_custo
        { get; set; }
        public decimal Vl_custo_calculado
        { get; set; }
        public decimal Indice_monetario
        { get; set; }

        public TRegistro_CustoFixo_Direto()
        {
            this.Cd_empresa = string.Empty;
            this.Nm_empresa = string.Empty;
            this.Id_formulacao = null;
            this.id_custo = null;
            this.id_custostr = string.Empty;
            this.Ds_custo = string.Empty;
            this.Tp_custo = string.Empty;
            this.Cd_moeda = string.Empty;
            this.Ds_moeda = string.Empty;
            this.Sigla = string.Empty;
            this.Cd_unidade = string.Empty;
            this.Ds_unidade = string.Empty;
            this.Sigla_unidade = string.Empty;
            this.Vl_custo = decimal.Zero;
            this.Pc_custo = decimal.Zero;
            this.Vl_custo_calculado = decimal.Zero;
            this.Indice_monetario = decimal.Zero;
        }
    }

    public class TCD_CustoFixo_Direto : TDataQuery
    {
        public TCD_CustoFixo_Direto()
        { }

        public TCD_CustoFixo_Direto(BancoDados.TObjetoBanco banco)
        {
            this.Banco_Dados = banco;
        }

        public string SqlCodeBusca(TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            string strtop = string.Empty;
            if (vTop > 0)
                strtop = " top " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();
            if (vNM_Campo.Trim().Equals(string.Empty))
            {
                sql.AppendLine("select " + strtop + " a.cd_empresa, b.nm_empresa, ");
                sql.AppendLine("a.id_formulacao, a.id_custo, c.ds_custo, c.tp_custo, ");
                sql.AppendLine("a.cd_moeda, d.ds_moeda_singular, d.sigla, a.cd_unidade, ");
                sql.AppendLine("e.ds_unidade, e.sigla_unidade, a.vl_custo, a.pc_custo ");
            }
            else
                sql.AppendLine("Select " + strtop + " " + vNM_Campo);

            sql.AppendLine("from tb_prd_custofixo_direto a ");
            sql.AppendLine("inner join tb_div_empresa b ");
            sql.AppendLine("on a.cd_empresa = b.cd_empresa ");
            sql.AppendLine("inner join tb_prd_custos c ");
            sql.AppendLine("on a.id_custo = c.id_custo ");
            sql.AppendLine("inner join tb_fin_moeda d ");
            sql.AppendLine("on a.cd_moeda = d.cd_moeda ");
            sql.AppendLine("inner join tb_est_unidade e ");
            sql.AppendLine("on a.cd_unidade = e.cd_unidade ");
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
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, string.Empty), null);
        }

        public override System.Data.DataTable Buscar(TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo), null);
        }

        public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
        {
            return this.executarEscalar(this.SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }

        public TList_CustoFixo_Direto Select(TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            TList_CustoFixo_Direto lista = new TList_CustoFixo_Direto();
            bool podeFecharBco = false;
            if (Banco_Dados == null)
            {
                this.CriarBanco_Dados(false);
                podeFecharBco = true;
            }
            SqlDataReader reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_CustoFixo_Direto reg = new TRegistro_CustoFixo_Direto();
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("CD_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NM_Empresa")))
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("NM_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Formulacao")))
                        reg.Id_formulacao = reader.GetDecimal(reader.GetOrdinal("ID_Formulacao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Custo")))
                        reg.Id_custo = reader.GetDecimal(reader.GetOrdinal("ID_Custo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Custo")))
                        reg.Ds_custo = reader.GetString(reader.GetOrdinal("DS_Custo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("TP_Custo")))
                        reg.Tp_custo = reader.GetString(reader.GetOrdinal("TP_Custo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Moeda")))
                        reg.Cd_moeda = reader.GetString(reader.GetOrdinal("CD_Moeda"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Moeda_Singular")))
                        reg.Ds_moeda = reader.GetString(reader.GetOrdinal("DS_Moeda_Singular"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Sigla")))
                        reg.Sigla = reader.GetString(reader.GetOrdinal("Sigla"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Unidade")))
                        reg.Cd_unidade = reader.GetString(reader.GetOrdinal("CD_Unidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Unidade")))
                        reg.Ds_unidade = reader.GetString(reader.GetOrdinal("DS_Unidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Sigla_unidade")))
                        reg.Sigla_unidade = reader.GetString(reader.GetOrdinal("Sigla_unidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_Custo")))
                        reg.Vl_custo = reader.GetDecimal(reader.GetOrdinal("Vl_Custo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("PC_custo")))
                        reg.Pc_custo = reader.GetDecimal(reader.GetOrdinal("PC_custo"));

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

        public string GravarCustoFixoDireto(TRegistro_CustoFixo_Direto val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(7);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_FORMULACAO", val.Id_formulacao);
            hs.Add("@P_ID_CUSTO", val.Id_custo);
            hs.Add("@P_CD_MOEDA", val.Cd_moeda);
            hs.Add("@P_CD_UNIDADE", val.Cd_unidade);
            hs.Add("@P_VL_CUSTO", val.Vl_custo);
            hs.Add("@P_PC_CUSTO", val.Pc_custo);

            return this.executarProc("IA_PRD_CUSTOFIXO_DIRETO", hs);
        }

        public string DeletarCustoFixoDireto(TRegistro_CustoFixo_Direto val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(3);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_FORMULACAO", val.Id_formulacao);
            hs.Add("@P_ID_CUSTO", val.Id_custo);

            return this.executarProc("EXCLUI_PRD_CUSTOFIXO_DIRETO", hs);
        }
    }
}
