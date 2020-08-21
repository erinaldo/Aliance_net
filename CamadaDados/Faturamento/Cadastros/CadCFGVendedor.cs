using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamadaDados.Faturamento.Cadastros
{
    #region Vendedor X Empresa
    public class TList_Vendedor_X_Empresa : List<TRegistro_Vendedor_X_Empresa>
    { }
    
    public class TRegistro_Vendedor_X_Empresa
    {
        public string Cd_empresa
        { get; set; }
        public string Nm_empresa
        { get; set; }
        public string Cd_vendedor
        { get; set; }
        public string Nm_vendedor
        { get; set; }
        public decimal Pc_fixocomissao
        { get; set; }
        private string tp_comissao;
        public string Tp_comissao
        {
            get { return tp_comissao; }
            set
            {
                tp_comissao = value;
                if (value.Trim().ToUpper().Equals("F"))
                    tipo_comissao = "FIXO VENDEDOR";
                else if (value.Trim().ToUpper().Equals("T"))
                    tipo_comissao = "TABELA PREÇO";
                else if (value.Trim().ToUpper().Equals("P"))
                    tipo_comissao = "FIXO PRODUTO";
            }
        }
        private string tipo_comissao;
        public string Tipo_comissao
        {
            get { return tipo_comissao; }
            set
            {
                tipo_comissao = value;
                if (value.Trim().ToUpper().Equals("FIXO VENDEDOR"))
                    tp_comissao = "F";
                else if (value.Trim().ToUpper().Equals("TABELA PREÇO"))
                    tp_comissao = "T";
                else if (value.Trim().ToUpper().Equals("FIXO PRODUTO"))
                    tp_comissao = "P";
            }
        }
        private string st_comservico;
        public string St_comservico
        {
            get { return st_comservico; }
            set
            {
                st_comservico = value;
                st_comservicobool = value.Trim().ToUpper().Equals("S");
            }
        }
        private bool st_comservicobool;
        public bool St_comservicobool
        {
            get { return st_comservicobool; }
            set
            {
                st_comservicobool = value;
                st_comservico = value ? "S" : "N";
            }
        }
        public string status_recebimento { get; set; } = "N";
        public bool St_recebimento
        {
            get
            {
                if (status_recebimento.Equals("S"))
                    return true;
                else
                    return false;
            }
            set
            {
                if (value)
                    status_recebimento = "S";
                else
                    status_recebimento = "N";
            }
        }

        public TRegistro_Vendedor_X_Empresa()
        {
            this.Cd_empresa = string.Empty;
            this.status_recebimento = "N";
            this.St_recebimento = false;
            this.Nm_empresa = string.Empty;
            this.Cd_vendedor = string.Empty;
            this.Nm_vendedor = string.Empty;
            this.Pc_fixocomissao = decimal.Zero;
            this.tp_comissao = string.Empty;
            this.tipo_comissao = string.Empty;
            this.st_comservico = "N";
            this.st_comservicobool = false;
        }
    }

    public class TCD_Vendedor_X_Empresa : TDataQuery
    {
        public TCD_Vendedor_X_Empresa()
        { }

        public TCD_Vendedor_X_Empresa(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();

            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine(" SELECT " + strTop + " a.cd_vendedor, b.NM_Clifor, ");
                sql.AppendLine("a.cd_empresa, c.NM_Empresa, a.pc_fixocomissao, ");
                sql.AppendLine("a.tp_comissao,a.st_comservico, a.st_comrecebimento ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from tb_fat_vendedor_x_empresa a ");
            sql.AppendLine("inner join TB_FIN_Clifor b ");
            sql.AppendLine("on a.cd_vendedor = b.CD_Clifor ");
            sql.AppendLine("inner join TB_DIV_Empresa c ");
            sql.AppendLine("on a.cd_empresa = c.CD_Empresa ");

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

        public TList_Vendedor_X_Empresa Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_Vendedor_X_Empresa lista = new TList_Vendedor_X_Empresa();
            System.Data.SqlClient.SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);

            try
            {
                reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
                while (reader.Read())
                {
                    TRegistro_Vendedor_X_Empresa reg = new TRegistro_Vendedor_X_Empresa();
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_vendedor")))
                        reg.Cd_vendedor = reader.GetString(reader.GetOrdinal("cd_vendedor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_clifor")))
                        reg.Nm_vendedor = reader.GetString(reader.GetOrdinal("nm_clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_empresa")))
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("nm_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("pc_fixocomissao")))
                        reg.Pc_fixocomissao = reader.GetDecimal(reader.GetOrdinal("pc_fixocomissao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_comissao")))
                        reg.Tp_comissao = reader.GetString(reader.GetOrdinal("tp_comissao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_comservico")))
                        reg.St_comservico = reader.GetString(reader.GetOrdinal("st_comservico"));
                    if (!reader.IsDBNull(reader.GetOrdinal("St_comrecebimento")))
                        reg.status_recebimento = reader.GetString(reader.GetOrdinal("St_comrecebimento"));

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

        public string Gravar(TRegistro_Vendedor_X_Empresa val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(5);
            hs.Add("@P_CD_VENDEDOR", val.Cd_vendedor);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_PC_FIXOCOMISSAO", val.Pc_fixocomissao);
            hs.Add("@P_TP_COMISSAO", val.Tp_comissao);
            hs.Add("@P_ST_COMSERVICO", val.St_comservico);
            hs.Add("@P_ST_COMRECEBIMENTO", val.status_recebimento);

            return this.executarProc("IA_FAT_VENDEDOR_X_EMPRESA", hs);
        }

        public string Excluir(TRegistro_Vendedor_X_Empresa val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(2);
            hs.Add("@P_CD_VENDEDOR", val.Cd_vendedor);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);

            return this.executarProc("EXCLUI_FAT_VENDEDOR_X_EMPRESA", hs);
        }
    }
    #endregion

    #region Vendedor X Condicao Pagamento
    public class TList_Vendedor_X_CondPgto : List<TRegistro_Vendedor_X_CondPgto>
    { }
    
    public class TRegistro_Vendedor_X_CondPgto
    {
        public string Cd_vendedor
        { get; set; }
        public string Nm_vendedor
        { get; set; }
        public string Cd_condpgto
        { get; set; }
        public string Ds_condpgto
        { get; set; }
        public decimal Pc_basecalc_comissao
        { get; set; }

        public TRegistro_Vendedor_X_CondPgto()
        {
            this.Cd_vendedor = string.Empty;
            this.Nm_vendedor = string.Empty;
            this.Cd_condpgto = string.Empty;
            this.Ds_condpgto = string.Empty;
            this.Pc_basecalc_comissao = 100;
        }
    }

    public class TCD_Vendedor_X_CondPgto : TDataQuery
    {
        public TCD_Vendedor_X_CondPgto()
        { }

        public TCD_Vendedor_X_CondPgto(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();

            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine(" SELECT " + strTop + " a.cd_vendedor, b.nm_clifor, ");
                sql.AppendLine("a.cd_condpgto, c.DS_CondPGTO, a.pc_basecalc_comissao ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from tb_fat_vendedor_x_condpgto a ");
            sql.AppendLine("inner join tb_fin_clifor b ");
            sql.AppendLine("on a.cd_vendedor = b.cd_clifor ");
            sql.AppendLine("inner join TB_FIN_CondPGTO c ");
            sql.AppendLine("on a.cd_condpgto = c.CD_CondPGTO ");

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

        public TList_Vendedor_X_CondPgto Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_Vendedor_X_CondPgto lista = new TList_Vendedor_X_CondPgto();
            System.Data.SqlClient.SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);

            try
            {
                reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
                while (reader.Read())
                {
                    TRegistro_Vendedor_X_CondPgto reg = new TRegistro_Vendedor_X_CondPgto();
                    if(!reader.IsDBNull(reader.GetOrdinal("cd_vendedor")))
                        reg.Cd_vendedor = reader.GetString(reader.GetOrdinal("cd_vendedor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_clifor")))
                        reg.Nm_vendedor = reader.GetString(reader.GetOrdinal("nm_clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_condpgto")))
                        reg.Cd_condpgto = reader.GetString(reader.GetOrdinal("cd_condpgto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_CondPGTO")))
                        reg.Ds_condpgto = reader.GetString(reader.GetOrdinal("DS_CondPGTO"));
                    if (!reader.IsDBNull(reader.GetOrdinal("pc_basecalc_comissao")))
                        reg.Pc_basecalc_comissao = reader.GetDecimal(reader.GetOrdinal("pc_basecalc_comissao"));

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

        public string Gravar(TRegistro_Vendedor_X_CondPgto val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(3);
            hs.Add("@P_CD_VENDEDOR", val.Cd_vendedor);
            hs.Add("@P_CD_CONDPGTO", val.Cd_condpgto);
            hs.Add("@P_PC_BASECALC_COMISSAO", val.Pc_basecalc_comissao);

            return this.executarProc("IA_FAT_VENDEDOR_X_CONDPGTO", hs);
        }

        public string Excluir(TRegistro_Vendedor_X_CondPgto val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(2);
            hs.Add("@P_CD_VENDEDOR", val.Cd_vendedor);
            hs.Add("@P_CD_CONDPGTO", val.Cd_condpgto);

            return this.executarProc("EXCLUI_FAT_VENDEDOR_X_CONDPGTO", hs);
        }
    }
    #endregion

    #region Vendedor X Tabela Preco
    public class TList_Vendedor_X_TabelaPreco : List<TRegistro_Vendedor_X_TabelaPreco>
    { }
    
    public class TRegistro_Vendedor_X_TabelaPreco
    {
        public string Cd_vendedor
        { get; set; }
        public string Nm_vendedor
        { get; set; }
        public string Cd_tabelapreco
        { get; set; }
        public string Ds_tabelapreco
        { get; set; }
        public decimal Pc_comissao
        { get; set; }

        public TRegistro_Vendedor_X_TabelaPreco()
        {
            this.Cd_vendedor = string.Empty;
            this.Nm_vendedor = string.Empty;
            this.Cd_tabelapreco = string.Empty;
            this.Ds_tabelapreco = string.Empty;
            this.Pc_comissao = decimal.Zero;
        }
    }

    public class TCD_Vendedor_X_TabelaPreco : TDataQuery
    {
        public TCD_Vendedor_X_TabelaPreco()
        { }

        public TCD_Vendedor_X_TabelaPreco(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();

            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine(" SELECT " + strTop + " a.cd_vendedor, b.nm_clifor, ");
                sql.AppendLine("a.cd_tabelapreco, c.ds_tabelapreco, a.pc_comissao ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from TB_FAT_Vendedor_X_TabPreco a ");
            sql.AppendLine("inner join tb_fin_clifor b ");
            sql.AppendLine("on a.cd_vendedor = b.cd_clifor ");
            sql.AppendLine("inner join TB_DIV_TabelaPreco c ");
            sql.AppendLine("on a.cd_tabelapreco = c.CD_TabelaPreco ");

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

        public TList_Vendedor_X_TabelaPreco Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_Vendedor_X_TabelaPreco lista = new TList_Vendedor_X_TabelaPreco();
            System.Data.SqlClient.SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);

            try
            {
                reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
                while (reader.Read())
                {
                    TRegistro_Vendedor_X_TabelaPreco reg = new TRegistro_Vendedor_X_TabelaPreco();
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_vendedor")))
                        reg.Cd_vendedor = reader.GetString(reader.GetOrdinal("cd_vendedor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_clifor")))
                        reg.Nm_vendedor = reader.GetString(reader.GetOrdinal("nm_clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_tabelapreco")))
                        reg.Cd_tabelapreco = reader.GetString(reader.GetOrdinal("cd_tabelapreco"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_tabelapreco")))
                        reg.Ds_tabelapreco = reader.GetString(reader.GetOrdinal("ds_tabelapreco"));
                    if (!reader.IsDBNull(reader.GetOrdinal("pc_comissao")))
                        reg.Pc_comissao = reader.GetDecimal(reader.GetOrdinal("pc_comissao"));

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

        public string Gravar(TRegistro_Vendedor_X_TabelaPreco val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(3);
            hs.Add("@P_CD_VENDEDOR", val.Cd_vendedor);
            hs.Add("@P_CD_TABELAPRECO", val.Cd_tabelapreco);
            hs.Add("@P_PC_COMISSAO", val.Pc_comissao);

            return this.executarProc("IA_FAT_VENDEDOR_X_TABPRECO", hs);
        }

        public string Excluir(TRegistro_Vendedor_X_TabelaPreco val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(2);
            hs.Add("@P_CD_VENDEDOR", val.Cd_vendedor);
            hs.Add("@P_CD_TABELAPRECO", val.Cd_tabelapreco);

            return this.executarProc("EXCLUI_FAT_VENDEDOR_X_TABPRECO", hs);
        }
    }
    #endregion

    #region Vendedor X Regiao Venda
    public class TList_Vendedor_X_RegiaoVenda : List<TRegistro_Vendedor_X_RegiaoVenda>
    { }
    
    public class TRegistro_Vendedor_X_RegiaoVenda
    {
        public string Cd_vendedor
        { get; set; }
        public string Nm_vendedor
        { get; set; }
        private decimal? id_regiao;
        public decimal? Id_regiao
        {
            get { return id_regiao; }
            set
            {
                id_regiao = value;
                id_regiaostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_regiaostr;
        public string Id_regiaostr
        {
            get { return id_regiaostr; }
            set
            {
                id_regiaostr = value;
                try
                {
                    id_regiao = Convert.ToDecimal(value);
                }
                catch
                { id_regiao = null; }
            }
        }
        public string Nm_regiao
        { get; set; }

        public TRegistro_Vendedor_X_RegiaoVenda()
        {
            this.Cd_vendedor = string.Empty;
            this.Nm_vendedor = string.Empty;
            this.id_regiao = null;
            this.id_regiaostr = string.Empty;
            this.Nm_regiao = string.Empty;
        }
    }

    public class TCD_Vendedor_X_RegiaoVenda : TDataQuery
    {
        public TCD_Vendedor_X_RegiaoVenda()
        { }

        public TCD_Vendedor_X_RegiaoVenda(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();

            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine(" SELECT " + strTop + " a.cd_vendedor, b.nm_clifor, ");
                sql.AppendLine("a.Id_Regiao, c.NM_Regiao ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from tb_fat_vendedor_x_regiaovenda a ");
            sql.AppendLine("inner join vtb_fin_clifor b ");
            sql.AppendLine("on a.cd_vendedor = b.cd_clifor ");
            sql.AppendLine("inner join TB_DIV_RegiaoVenda c ");
            sql.AppendLine("on a.ID_Regiao = c.ID_Regiao ");

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

        public TList_Vendedor_X_RegiaoVenda Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_Vendedor_X_RegiaoVenda lista = new TList_Vendedor_X_RegiaoVenda();
            System.Data.SqlClient.SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);

            try
            {
                reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
                while (reader.Read())
                {
                    TRegistro_Vendedor_X_RegiaoVenda reg = new TRegistro_Vendedor_X_RegiaoVenda();
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_vendedor")))
                        reg.Cd_vendedor = reader.GetString(reader.GetOrdinal("cd_vendedor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_clifor")))
                        reg.Nm_vendedor = reader.GetString(reader.GetOrdinal("nm_clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_regiao")))
                        reg.Id_regiao = reader.GetDecimal(reader.GetOrdinal("id_regiao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_regiao")))
                        reg.Nm_regiao = reader.GetString(reader.GetOrdinal("nm_regiao"));

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

        public string Gravar(TRegistro_Vendedor_X_RegiaoVenda val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(2);
            hs.Add("@P_CD_VENDEDOR", val.Cd_vendedor);
            hs.Add("@P_ID_REGIAO", val.Id_regiao);

            return this.executarProc("IA_FAT_VENDEDOR_X_REGIAOVENDA", hs);
        }

        public string Excluir(TRegistro_Vendedor_X_RegiaoVenda val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(2);
            hs.Add("@P_CD_VENDEDOR", val.Cd_vendedor);
            hs.Add("@P_ID_REGIAO", val.Id_regiao);

            return this.executarProc("EXCLUI_FAT_VENDEDOR_X_REGIAOVENDA", hs);
        }
    }
    #endregion

    #region Vendedor X Grupo Produto
    public class TList_Vendedor_X_GrupoProd : List<TRegistro_Vendedor_X_GrupoProd>
    { }

    public class TRegistro_Vendedor_X_GrupoProd
    {
        public string Cd_grupo
        { get; set; }
        public string Ds_grupo
        { get; set; }
        public string Cd_vendedor
        { get; set; }
        public string Nm_vendedor
        { get; set; }
        public decimal Pc_Comissao
        { get; set; }

        public TRegistro_Vendedor_X_GrupoProd()
        {
            this.Cd_grupo = string.Empty;
            this.Ds_grupo = string.Empty;
            this.Cd_vendedor = string.Empty;
            this.Nm_vendedor = string.Empty;
            this.Pc_Comissao = decimal.Zero;
        }
    }

    public class TCD_Vendedor_X_GrupoProd : TDataQuery
    {
        public TCD_Vendedor_X_GrupoProd()
        { }

        public TCD_Vendedor_X_GrupoProd(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();

            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine(" SELECT " + strTop + " a.cd_vendedor, b.NM_Clifor, ");
                sql.AppendLine("a.cd_grupo, rtrim(c.DS_Grupo) as DS_Grupo, a.pc_comissao ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from TB_FAT_Vendedor_X_GrupoProd a ");
            sql.AppendLine("inner join TB_FIN_Clifor b ");
            sql.AppendLine("on a.cd_vendedor = b.CD_Clifor ");
            sql.AppendLine("inner join TB_EST_GrupoProduto c ");
            sql.AppendLine("on a.cd_grupo = c.cd_grupo ");

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

        public TList_Vendedor_X_GrupoProd Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_Vendedor_X_GrupoProd lista = new TList_Vendedor_X_GrupoProd();
            System.Data.SqlClient.SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);

            try
            {
                reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
                while (reader.Read())
                {
                    TRegistro_Vendedor_X_GrupoProd reg = new TRegistro_Vendedor_X_GrupoProd();
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_vendedor")))
                        reg.Cd_vendedor = reader.GetString(reader.GetOrdinal("cd_vendedor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_clifor")))
                        reg.Nm_vendedor = reader.GetString(reader.GetOrdinal("nm_clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_grupo")))
                        reg.Cd_grupo = reader.GetString(reader.GetOrdinal("cd_grupo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Grupo")))
                        reg.Ds_grupo = reader.GetString(reader.GetOrdinal("DS_Grupo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("pc_comissao")))
                        reg.Pc_Comissao = reader.GetDecimal(reader.GetOrdinal("pc_comissao"));

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

        public string Gravar(TRegistro_Vendedor_X_GrupoProd val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(3);
            hs.Add("@P_CD_VENDEDOR", val.Cd_vendedor);
            hs.Add("@P_CD_GRUPO", val.Cd_grupo);
            hs.Add("@P_PC_COMISSAO", val.Pc_Comissao);

            return this.executarProc("IA_FAT_VENDEDOR_X_GRUPOPROD", hs);
        }

        public string Excluir(TRegistro_Vendedor_X_GrupoProd val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(2);
            hs.Add("@P_CD_VENDEDOR", val.Cd_vendedor);
            hs.Add("@P_CD_GRUPO", val.Cd_grupo);

            return this.executarProc("EXCLUI_FAT_VENDEDOR_X_GRUPOPROD", hs);
        }
    }
    #endregion

    #region Gerente X Vendedor
    public class TList_Gerente_X_Vendedor : List<TRegistro_Gerente_X_Vendedor>
    { }

    public class TRegistro_Gerente_X_Vendedor
    {
        public string Cd_empresa
        { get; set; }
        public string Nm_empresa
        { get; set; }
        public string Cd_gerente
        { get; set; }
        public string Nm_gerente
        { get; set; }
        public string Cd_vendedor
        { get; set; }
        public string Nm_vendedor
        { get; set; }
        public decimal Pc_comissao
        { get; set; }

        public TRegistro_Gerente_X_Vendedor()
        {
            this.Cd_empresa = string.Empty;
            this.Nm_empresa = string.Empty;
            this.Cd_gerente = string.Empty;
            this.Nm_gerente = string.Empty;
            this.Cd_vendedor = string.Empty;
            this.Nm_vendedor = string.Empty;
            this.Pc_comissao = decimal.Zero;
        }
    }

    public class TCD_Gerente_X_Vendedor : TDataQuery
    {
        public TCD_Gerente_X_Vendedor()
        { }

        public TCD_Gerente_X_Vendedor(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();

            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine(" SELECT " + strTop + " a.cd_gerente, d.NM_Clifor as nm_gerente, a.cd_vendedor, b.NM_Clifor as nm_vendedor, ");
                sql.AppendLine("a.cd_empresa, c.NM_Empresa, a.pc_comissao ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from tb_fat_Gerente_X_Vendedor a ");
            sql.AppendLine("inner join TB_FIN_Clifor b ");
            sql.AppendLine("on a.cd_vendedor = b.CD_Clifor ");
            sql.AppendLine("inner join TB_DIV_Empresa c ");
            sql.AppendLine("on a.cd_empresa = c.CD_Empresa ");
            sql.AppendLine("inner join TB_FIN_Clifor d ");
            sql.AppendLine("on a.cd_gerente = d.CD_Clifor ");

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

        public TList_Gerente_X_Vendedor Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_Gerente_X_Vendedor lista = new TList_Gerente_X_Vendedor();
            System.Data.SqlClient.SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);

            try
            {
                reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
                while (reader.Read())
                {
                    TRegistro_Gerente_X_Vendedor reg = new TRegistro_Gerente_X_Vendedor();
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_gerente")))
                        reg.Cd_gerente = reader.GetString(reader.GetOrdinal("cd_gerente"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_gerente")))
                        reg.Nm_gerente = reader.GetString(reader.GetOrdinal("nm_gerente"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_vendedor")))
                        reg.Cd_vendedor = reader.GetString(reader.GetOrdinal("cd_vendedor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_vendedor")))
                        reg.Nm_vendedor = reader.GetString(reader.GetOrdinal("nm_vendedor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_empresa")))
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("nm_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("pc_comissao")))
                        reg.Pc_comissao = reader.GetDecimal(reader.GetOrdinal("pc_comissao"));

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

        public string Gravar(TRegistro_Gerente_X_Vendedor val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(4);
            hs.Add("@P_CD_GERENTE", val.Cd_gerente);
            hs.Add("@P_CD_VENDEDOR", val.Cd_vendedor);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_PC_COMISSAO", val.Pc_comissao);

            return this.executarProc("IA_FAT_GERENTE_X_VENDEDOR", hs);
        }

        public string Excluir(TRegistro_Gerente_X_Vendedor val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(3);
            hs.Add("@P_CD_GERENTE", val.Cd_gerente);
            hs.Add("@P_CD_VENDEDOR", val.Cd_vendedor);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);

            return this.executarProc("EXCLUI_FAT_GERENTE_X_VENDEDOR", hs);
        }
    }
    #endregion

    #region Desconto Vendedor
    public class TList_DescontoVendedor : List<TRegistro_DescontoVendedor>
    { }

    public class TRegistro_DescontoVendedor
    {
        private decimal? id_desconto;
        public decimal? Id_desconto
        {
            get { return id_desconto; }
            set
            {
                id_desconto = value;
                id_descontostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_descontostr;
        public string Id_descontostr
        {
            get { return id_descontostr; }
            set
            {
                id_descontostr = value;
                try
                {
                    id_desconto = decimal.Parse(value);
                }
                catch { id_desconto = null; }
            }
        }
        public string Cd_vendedor
        { get; set; }
        public string Nm_vendedor
        { get; set; }
        public string Cd_empresa
        { get; set; }
        public string Nm_empresa
        { get; set; }
        public string Cd_grupo
        { get; set; }
        public string Ds_grupo
        { get; set; }
        public string Cd_tabelapreco
        { get; set; }
        public string Ds_tabelapreco
        { get; set; }
        private string tp_desconto;
        public string Tp_desconto
        {
            get { return tp_desconto; }
            set
            {
                tp_desconto = value;
                if (value.Trim().ToUpper().Equals("P"))
                    tipo_desconto = "PERCENTUAL";
                else if (value.Trim().ToUpper().Equals("V"))
                    tipo_desconto = "VALOR";
            }
        }
        private string tipo_desconto;
        public string Tipo_desconto
        {
            get { return tipo_desconto; }
            set
            {
                tipo_desconto = value;
                if (value.Trim().ToUpper().Equals("PERCENTUAL"))
                    tp_desconto = "P";
                else if (value.Trim().ToUpper().Equals("VALOR"))
                    tp_desconto = "V";
            }
        }
        public decimal Pc_max_desconto
        { get; set; }

        public TRegistro_DescontoVendedor()
        {
            this.id_desconto = null;
            this.id_descontostr = string.Empty;
            this.Cd_vendedor = string.Empty;
            this.Nm_vendedor = string.Empty;
            this.Cd_empresa = string.Empty;
            this.Nm_empresa = string.Empty;
            this.Cd_grupo = string.Empty;
            this.Ds_grupo = string.Empty;
            this.Cd_tabelapreco = string.Empty;
            this.Ds_tabelapreco = string.Empty;
            this.tp_desconto = string.Empty;
            this.tipo_desconto = string.Empty;
            this.Pc_max_desconto = decimal.Zero;
        }
    }

    public class TCD_DescontoVendedor : TDataQuery
    {
        public TCD_DescontoVendedor() { }

        public TCD_DescontoVendedor(BancoDados.TObjetoBanco banco) { this.Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();

            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine(" SELECT " + strTop + " a.id_desconto, a.cd_vendedor, b.NM_Clifor, ");
                sql.AppendLine("a.cd_empresa, e.nm_empresa, a.cd_grupo, rtrim(c.DS_Grupo) as DS_Grupo, ");
                sql.AppendLine("a.cd_tabelapreco, d.ds_tabelapreco, a.tp_desconto, a.pc_max_desconto ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from TB_FAT_DescontoVendedor a ");
            sql.AppendLine("inner join TB_FIN_Clifor b ");
            sql.AppendLine("on a.cd_vendedor = b.CD_Clifor ");
            sql.AppendLine("inner join TB_DIV_Empresa e ");
            sql.AppendLine("on a.cd_empresa = e.cd_empresa ");
            sql.AppendLine("left outer join TB_EST_GrupoProduto c ");
            sql.AppendLine("on a.cd_grupo = c.cd_grupo ");
            sql.AppendLine("left outer join TB_DIV_TabelaPreco d ");
            sql.AppendLine("on a.cd_tabelapreco = d.cd_tabelapreco ");

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

        public TList_DescontoVendedor Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_DescontoVendedor lista = new TList_DescontoVendedor();
            System.Data.SqlClient.SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);

            try
            {
                reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
                while (reader.Read())
                {
                    TRegistro_DescontoVendedor reg = new TRegistro_DescontoVendedor();
                    if (!reader.IsDBNull(reader.GetOrdinal("id_desconto")))
                        reg.Id_desconto = reader.GetDecimal(reader.GetOrdinal("id_desconto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_vendedor")))
                        reg.Cd_vendedor = reader.GetString(reader.GetOrdinal("cd_vendedor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_clifor")))
                        reg.Nm_vendedor = reader.GetString(reader.GetOrdinal("nm_clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_empresa")))
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("nm_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_grupo")))
                        reg.Cd_grupo = reader.GetString(reader.GetOrdinal("cd_grupo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Grupo")))
                        reg.Ds_grupo = reader.GetString(reader.GetOrdinal("DS_Grupo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_tabelapreco")))
                        reg.Cd_tabelapreco = reader.GetString(reader.GetOrdinal("cd_tabelapreco"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_tabelapreco")))
                        reg.Ds_tabelapreco = reader.GetString(reader.GetOrdinal("ds_tabelapreco"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_desconto")))
                        reg.Tp_desconto = reader.GetString(reader.GetOrdinal("tp_desconto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("pc_max_desconto")))
                        reg.Pc_max_desconto = reader.GetDecimal(reader.GetOrdinal("pc_max_desconto"));

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

        public string Gravar(TRegistro_DescontoVendedor val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(7);
            hs.Add("@P_ID_DESCONTO", val.Id_desconto);
            hs.Add("@P_CD_VENDEDOR", val.Cd_vendedor);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_CD_GRUPO", val.Cd_grupo);
            hs.Add("@P_CD_TABELAPRECO", val.Cd_tabelapreco);
            hs.Add("@P_TP_DESCONTO", val.Tp_desconto);
            hs.Add("@P_PC_MAX_DESCONTO", val.Pc_max_desconto);

            return this.executarProc("IA_FAT_DESCONTOVENDEDOR", hs);
        }

        public string Excluir(TRegistro_DescontoVendedor val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(3);
            hs.Add("@P_CD_VENDEDOR", val.Cd_vendedor);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_DESCONTO", val.Id_desconto);

            return this.executarProc("EXCLUI_FAT_DESCONTOVENDEDOR", hs);
        }
    }
    #endregion

    #region Meta Vendedor
    public class TList_MetaVendedor : List<TRegistro_MetaVendedor>, IComparer<TRegistro_MetaVendedor>
    {
        #region IComparer<TRegistro_MetaVendedor> Members

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

        public TList_MetaVendedor()
        { }

        public TList_MetaVendedor(System.ComponentModel.PropertyDescriptor Prop,
                                  System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_MetaVendedor value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_MetaVendedor x, TRegistro_MetaVendedor y)
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

    public class TRegistro_MetaVendedor
    {
        public string Cd_empresa
        { get; set; }
        public string Nm_empresa
        { get; set; }
        private decimal? id_meta;
        public decimal? Id_meta
        {
            get { return id_meta; }
            set
            {
                id_meta = value;
                id_metastr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_metastr;
        public string Id_metastr
        {
            get { return id_metastr; }
            set
            {
                id_metastr = value;
                try
                {
                    id_meta = decimal.Parse(value);
                }
                catch { id_meta = null; }
            }
        }
        public string Cd_vendedor
        { get; set; }
        public string Nm_vendedor
        { get; set; }
        public decimal Mesvig
        { get; set; }
        public decimal Anovig
        { get; set; }
        public decimal Vl_meta
        { get; set; }
        public decimal Pc_comissao
        { get; set; }

        public TRegistro_MetaVendedor()
        {
            this.Cd_empresa = string.Empty;
            this.Nm_empresa = string.Empty;
            this.id_meta = null;
            this.id_metastr = string.Empty;
            this.Cd_vendedor = string.Empty;
            this.Nm_vendedor = string.Empty;
            this.Mesvig = decimal.Zero;
            this.Anovig = decimal.Zero;
            this.Vl_meta = decimal.Zero;
            this.Pc_comissao = decimal.Zero;
        }
    }

    public class TCD_MetaVendedor : TDataQuery
    {
        public TCD_MetaVendedor() { }

        public TCD_MetaVendedor(BancoDados.TObjetoBanco banco) { this.Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo, string vGroup, string vOrder)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();

            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine(" SELECT " + strTop + " a.ID_Meta, a.cd_vendedor, b.NM_Clifor as Nm_vendedor , ");
                sql.AppendLine("a.cd_empresa, e.nm_empresa, a.MesVig, a.AnoVig, a.Vl_meta, a.Pc_comissao ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from TB_FAT_MetaVendedor a ");
            sql.AppendLine("inner join TB_FIN_Clifor b ");
            sql.AppendLine("on a.cd_vendedor = b.CD_Clifor ");
            sql.AppendLine("inner join TB_DIV_Empresa e ");
            sql.AppendLine("on a.cd_empresa = e.cd_empresa ");

            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.Append(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                    cond = " and ";
                }
            if (!string.IsNullOrEmpty(vGroup))
                sql.AppendLine("group by " + vGroup);
            if (!string.IsNullOrEmpty(vOrder))
                sql.AppendLine("order by " + vOrder);
            else
                sql.AppendLine("order by a.vl_meta ");

            return sql.ToString();
        }

        public override System.Data.DataTable Buscar(Utils.TpBusca[] vBusca, short vTop)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, string.Empty, string.Empty, string.Empty), null);
        }

        public override System.Data.DataTable Buscar(Utils.TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo, string.Empty, string.Empty), null);
        }

        public override object BuscarEscalar(Utils.TpBusca[] vBusca, string vNM_Campo, string vGroup, string vOrder, System.Collections.Hashtable vParametros)
        {
            return this.ExecutarBuscaEscalar(this.SqlCodeBusca(vBusca, 1, vNM_Campo, vGroup, vOrder), vParametros);
        }

        public TList_MetaVendedor Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo, string vGroup)
        {
            TList_MetaVendedor lista = new TList_MetaVendedor();
            System.Data.SqlClient.SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);

            try
            {
                reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo, vGroup, string.Empty));
                while (reader.Read())
                {
                    TRegistro_MetaVendedor reg = new TRegistro_MetaVendedor();
                    if (!reader.IsDBNull(reader.GetOrdinal("Id_meta")))
                        reg.Id_meta = reader.GetDecimal(reader.GetOrdinal("Id_meta"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_vendedor")))
                        reg.Cd_vendedor = reader.GetString(reader.GetOrdinal("cd_vendedor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Nm_vendedor")))
                        reg.Nm_vendedor = reader.GetString(reader.GetOrdinal("Nm_vendedor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_empresa")))
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("nm_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("MesVig")))
                        reg.Mesvig = reader.GetDecimal(reader.GetOrdinal("MesVig"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Anovig")))
                        reg.Anovig = reader.GetDecimal(reader.GetOrdinal("Anovig"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_meta")))
                        reg.Vl_meta = reader.GetDecimal(reader.GetOrdinal("Vl_meta"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Pc_comissao")))
                        reg.Pc_comissao = reader.GetDecimal(reader.GetOrdinal("Pc_comissao"));

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

        public string Gravar(TRegistro_MetaVendedor val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(7);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_META", val.Id_meta);
            hs.Add("@P_CD_VENDEDOR", val.Cd_vendedor);
            hs.Add("@P_MESVIG", val.Mesvig);
            hs.Add("@P_ANOVIG", val.Anovig);
            hs.Add("@P_VL_META", val.Vl_meta);
            hs.Add("@P_PC_COMISSAO", val.Pc_comissao);

            return this.executarProc("IA_FAT_METAVENDEDOR", hs);
        }

        public string Excluir(TRegistro_MetaVendedor val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(2);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_META", val.Id_meta);

            return this.executarProc("EXCLUI_FAT_METAVENDEDOR", hs);
        }

    }
    #endregion

    #region Desconto X Comissão
    public class TList_PercComissao_X_Desconto:List<TRegistro_PercComissao_X_Desconto>,IComparer<TRegistro_PercComissao_X_Desconto>
    {
        #region IComparer<TRegistro_MetaVendedor> Members

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

        public TList_PercComissao_X_Desconto()
        { }

        public TList_PercComissao_X_Desconto(System.ComponentModel.PropertyDescriptor Prop,
                                             System.Windows.Forms.SortOrder Dir)
        {
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_PercComissao_X_Desconto value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_PercComissao_X_Desconto x, TRegistro_PercComissao_X_Desconto y)
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
    public class TRegistro_PercComissao_X_Desconto
    {
        public string Cd_empresa { get; set; }
        public string Nm_empresa { get; set; }
        public string Cd_vendedor { get; set; }
        public string Nm_vendedor { get; set; }
        private decimal? id_config;
        public decimal? Id_config
        {
            get { return id_config; }
            set { id_config = value; id_configstr = value.HasValue ? value.Value.ToString() : string.Empty; }
        }
        private string id_configstr;
        public string Id_configstr
        {
            get { return id_configstr; }
            set
            {
                id_configstr = value;
                try
                {
                    id_config = decimal.Parse(value);
                }catch { id_config = null; }
            }
        }
        public decimal Pc_base { get; set; }
        public decimal Pc_reducaoAliq { get; set; }
        public TRegistro_PercComissao_X_Desconto()
        {
            Cd_empresa = string.Empty;
            Nm_empresa = string.Empty;
            Cd_vendedor = string.Empty;
            Nm_vendedor = string.Empty;
            id_config = null;
            id_configstr = string.Empty;
            Pc_base = decimal.Zero;
            Pc_reducaoAliq = decimal.Zero;
        }
    }
    public class TCD_PercComissao_X_Desconto:TDataQuery
    {
        public TCD_PercComissao_X_Desconto() { }
        public TCD_PercComissao_X_Desconto(BancoDados.TObjetoBanco banco) { Banco_Dados = banco; }
        private string SqlCodeBusca(Utils.TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();

            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine(" SELECT " + strTop + " a.ID_Config, a.CD_Empresa, b.NM_Empresa, ");
                sql.AppendLine("a.Cd_Vendedor, c.NM_Clifor as NM_Vendedor, a.PC_Base, a.PC_ReducaoAliq ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from TB_FAT_PercComissao_X_Desconto a ");
            sql.AppendLine("inner join TB_DIV_Empresa b ");
            sql.AppendLine("on a.cd_empresa = b.cd_empresa ");
            sql.AppendLine("inner join TB_FIN_Clifor c ");
            sql.AppendLine("on a.cd_vendedor = c.cd_clifor ");

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
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, string.Empty), null);
        }

        public override System.Data.DataTable Buscar(Utils.TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo), null);
        }

        public override object BuscarEscalar(Utils.TpBusca[] vBusca, string vNM_Campo, string vGroup, string vOrder, System.Collections.Hashtable vParametros)
        {
            return ExecutarBuscaEscalar(SqlCodeBusca(vBusca, 1, vNM_Campo), vParametros);
        }

        public TList_PercComissao_X_Desconto Select(Utils.TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            TList_PercComissao_X_Desconto lista = new TList_PercComissao_X_Desconto();
            System.Data.SqlClient.SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);

            try
            {
                reader = ExecutarBusca(SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
                while (reader.Read())
                {
                    TRegistro_PercComissao_X_Desconto reg = new TRegistro_PercComissao_X_Desconto();
                    if (!reader.IsDBNull(reader.GetOrdinal("id_config")))
                        reg.Id_config = reader.GetDecimal(reader.GetOrdinal("id_config"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_vendedor")))
                        reg.Cd_vendedor = reader.GetString(reader.GetOrdinal("cd_vendedor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Nm_vendedor")))
                        reg.Nm_vendedor = reader.GetString(reader.GetOrdinal("Nm_vendedor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_empresa")))
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("nm_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("pc_base")))
                        reg.Pc_base = reader.GetDecimal(reader.GetOrdinal("pc_base"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Pc_reducaoAliq")))
                        reg.Pc_reducaoAliq = reader.GetDecimal(reader.GetOrdinal("Pc_reducaoAliq"));

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

        public string Gravar(TRegistro_PercComissao_X_Desconto val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(5);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_CD_VENDEDOR", val.Cd_vendedor);
            hs.Add("@P_ID_CONFIG", val.Id_config);
            hs.Add("@P_PC_BASE", val.Pc_base);
            hs.Add("@P_PC_REDUCAOALIQ", val.Pc_reducaoAliq);

            return executarProc("IA_FAT_PERCCOMISSAO_X_DESCONTO", hs);
        }

        public string Excluir(TRegistro_PercComissao_X_Desconto val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(3);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_CD_VENDEDOR", val.Cd_vendedor);
            hs.Add("@P_ID_CONFIG", val.Id_config);

            return executarProc("EXCLUI_FAT_PERCCOMISSAO_X_DESCONTO", hs);
        }
    }
    #endregion
}
