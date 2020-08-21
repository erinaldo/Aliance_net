using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamadaDados.Empreendimento.Cadastro
{
    public class TRegistro_CadFatDireto
    {
        public CamadaDados.Empreendimento.TList_FichaTec lFicha { get; set; }
        public string cd_empresa { get; set; }
        public string ds_empresa { get; set; }
        private decimal? id_registro;
        public decimal? Id_registro
        {
            get { return id_registro; }
            set
            {
                id_registro = value;
                id_registrostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_registrostr;
        public string id_contato { get; set; } = string.Empty;
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
        private decimal? id_orcamento;
        public decimal? Id_orcamento
        {
            get { return id_orcamento; }
            set
            {
                id_orcamento = value;
                id_orcamentostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_orcamentostr;
        public string Id_orcamentostr
        {
            get { return id_orcamentostr; }
            set
            {
                id_orcamentostr = value;
                try
                {
                    id_orcamento = decimal.Parse(value);
                }
                catch { id_orcamento = null; }
            }
        }
        private decimal? nr_versao;
        public decimal? Nr_versao
        {
            get { return nr_versao; }
            set
            {
                nr_versao = value;
                nr_versaostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string nr_versaostr;
        public string Nr_versaostr
        {
            get { return nr_versaostr; }
            set
            {
                nr_versaostr = value;
                try
                {
                    nr_versao = decimal.Parse(value);
                }
                catch { nr_versao = null; }
            }
        }
        private decimal? id_projeto;
        public decimal? Id_projeto
        {
            get { return id_projeto; }
            set
            {
                id_projeto = value;
                id_projetostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_projetostr;
        public string Id_projetostr
        {
            get { return id_projetostr; }
            set
            {
                id_projetostr = value;
                try
                {
                    id_projeto = decimal.Parse(value);
                }
                catch { id_projeto = null; }
            }
        }

        public decimal? Id_faturamento
        {
            get { return id_faturamento; }
            set
            {
                id_faturamento = value;
                id_faturamentostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_faturamentostr;
        private decimal? id_faturamento;
        public string Id_faturamentostr
        {
            get { return id_faturamentostr; }
            set
            {
                id_faturamentostr = value;
                try
                {
                    id_faturamento = decimal.Parse(value);
                }
                catch { id_faturamento = null; }
            }
        }
        public string Cd_clifor
        { get; set; }
        public string Nm_clifor
        { get; set; }
        public string Cd_endereco
        { get; set; }
        public string Ds_endereco
        { get; set; }

        public string cd_fornecedor { get; set; }
        public string cd_endereco { get; set; }
        public string nr_nota { get; set; }
        private DateTime? dt_emissao;
        public DateTime? Dt_emissao
        {
            get { return dt_emissao; }
            set
            {
                dt_emissao = value;
                dt_emissaostring = value.HasValue ? value.Value.ToString("dd/MM/yyyy HH:mm:ss") : string.Empty;
            }
        }
        private string dt_emissaostring;
        public string Dt_emissaostring
        {
            get
            {
                try
                {
                    return Convert.ToDateTime(dt_emissaostring).ToString("dd/MM/yyyy HH:mm:ss");
                }
                catch
                { return string.Empty; }
            }
            set
            {
                dt_emissaostring = value;
                try
                {
                    dt_emissao = Convert.ToDateTime(value);
                }
                catch
                {
                    dt_emissao = null;
                }
            }
        }
        public string descricao { get; set; }
        public TList_CadFatDireto_item lFatDireto_Item { get; set; }
        public TRegistro_CadFatDireto()
        {
            this.cd_empresa = string.Empty;
            this.id_orcamento = null;
            this.id_orcamentostr = string.Empty;
            this.nr_versao = null;
            this.nr_versaostr = string.Empty;
            this.id_projeto = null;
            this.id_projetostr = string.Empty;
            id_faturamento = decimal.Zero;
            id_faturamentostr = string.Empty;
            ds_empresa = string.Empty;
            id_faturamento = decimal.Zero;
            cd_fornecedor = string.Empty;
            cd_endereco = string.Empty;
            nr_nota = string.Empty;
            dt_emissao = null;
            Dt_emissao = null;
            dt_emissaostring = string.Empty;
            Dt_emissaostring = string.Empty;
            descricao = string.Empty;
            lFicha = new CamadaDados.Empreendimento.TList_FichaTec();
            Cd_clifor = string.Empty;
            id_registro = decimal.Zero;
            Nm_clifor = string.Empty;
            Cd_endereco = string.Empty;
            cd_endereco = string.Empty;
            Ds_endereco = string.Empty;
            lFatDireto_Item = new TList_CadFatDireto_item();

        }
    }
    public class TList_CadFatDireto : List<TRegistro_CadFatDireto> { }

    public class TCD_CadFatDireto : TDataQuery
    {
        public TCD_CadFatDireto() { }

        public TCD_CadFatDireto(BancoDados.TObjetoBanco banco) { this.Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("select " + strTop + " a.cd_empresa, a.id_faturamento, ");
                sql.AppendLine("ds_fornecedor = (select x.NM_Clifor from TB_FIN_Clifor x where x.cd_clifor = a.cd_clifor ), ");
                sql.AppendLine("ds_endereco = (select top 1y.DS_Endereco from TB_FIN_Endereco y ");
				sql.AppendLine("            join TB_EMP_ItensFatDireto x on x.id_faturamento = a.id_faturamento ");
				sql.AppendLine("            join TB_EMP_Orcamento p on p.ID_Orcamento = x.ID_Faturamento  ");
                sql.AppendLine("            where a.CD_Endereco = y.CD_Endereco and y.cd_clifor = p.CD_Clifor ");
                sql.AppendLine("            ),a.cd_endereco,");
                sql.AppendLine("a.cd_clifor, a.cd_endereco, a.nr_nota, a.dt_emissao , a.obs");
                }
            else
                sql.AppendLine(" Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from TB_Emp_FatDireto a ");
           // sql.AppendLine("inner join TB_FIN_Endereco b on a.cd_endereco = b.cd_endereco");
           // sql.AppendLine("inner j-oin TB_FIN_Clifor c on a.cd_clifor = c.cd_clifor");
            
            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
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

        public TList_CadFatDireto Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            bool podeFecharBco = false;
            TList_CadFatDireto lista = new TList_CadFatDireto();
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_CadFatDireto reg = new TRegistro_CadFatDireto();
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        reg.cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_endereco")))
                        reg.cd_endereco = reader.GetString(reader.GetOrdinal("cd_endereco"));
                    if (!reader.IsDBNull(reader.GetOrdinal("obs")))
                        reg.descricao = reader.GetString(reader.GetOrdinal("obs"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_nota")))
                        reg.nr_nota = reader.GetString(reader.GetOrdinal("nr_nota"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_fornecedor")))
                        reg.Nm_clifor = reader.GetString(reader.GetOrdinal("ds_fornecedor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_clifor")))
                        reg.Cd_clifor = reader.GetString(reader.GetOrdinal("cd_clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_endereco")))
                        reg.Ds_endereco = reader.GetString(reader.GetOrdinal("ds_endereco"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_endereco")))
                        reg.Cd_endereco = reader.GetString(reader.GetOrdinal("cd_endereco"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_faturamento")))
                        reg.Id_faturamento = reader.GetDecimal(reader.GetOrdinal("id_faturamento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DT_EMISSAO")))
                        reg.Dt_emissao = reader.GetDateTime(reader.GetOrdinal("DT_EMISSAO"));

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

        public string Gravar(TRegistro_CadFatDireto val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(7);
            hs.Add("@P_CD_EMPRESA", val.cd_empresa);
            hs.Add("@P_ID_FATURAMENTO", val.Id_faturamentostr);
            hs.Add("@P_CD_CLIFOR", val.Cd_clifor);
            hs.Add("@P_CD_ENDERECO", val.Cd_endereco);
            hs.Add("@P_NR_NOTA", val.nr_nota);
            //hs.Add("@P_ID_REGISTRO", val.Id_registro);
            hs.Add("@P_DT_EMISSAO", val.Dt_emissaostring);
            hs.Add("@P_OBS", val.descricao);

            return this.executarProc("IA_EMP_FATDIRETO", hs);
        }

        public string Excluir(TRegistro_OrcProjeto val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(4);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_ORCAMENTO", val.Id_orcamento);
            hs.Add("@P_NR_VERSAO", val.Nr_versao);
            hs.Add("@P_ID_PROJETO", val.Id_projeto);

            return this.executarProc("EXCLUI_EMP_ORCPROJETO", hs);
        }
    }

    public class TRegistro_CadFatDireto_Item
    {
        public string cd_empresa { get; set; }
        public string ds_empresa { get; set; }  private decimal? id_orcamento;
        public decimal? Id_orcamento
        {
            get { return id_orcamento; }
            set
            {
                id_orcamento = value;
                id_orcamentostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_orcamentostr;
        public string ds_produto { get; set; }
        public decimal cd_produto { get; set; }
        public decimal vl_unitario { get; set; }
        public decimal vl_subtotal { get; set; }
        public string Id_orcamentostr
        {
            get { return id_orcamentostr; }
            set
            {
                id_orcamentostr = value;
                try
                {
                    id_orcamento = decimal.Parse(value);
                }
                catch { id_orcamento = null; }
            }
        }
        private decimal? nr_versao;
        public decimal? Nr_versao
        {
            get { return nr_versao; }
            set
            {
                nr_versao = value;
                nr_versaostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string nr_versaostr;
        public string Nr_versaostr
        {
            get { return nr_versaostr; }
            set
            {
                nr_versaostr = value;
                try
                {
                    nr_versao = decimal.Parse(value);
                }
                catch { nr_versao = null; }
            }
        }
        private decimal? id_projeto;
        public decimal? Id_projeto
        {
            get { return id_projeto; }
            set
            {
                id_projeto = value;
                id_projetostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_projetostr;
        public string id_ficha{get;set;}
        public string Id_projetostr
        {
            get { return id_projetostr; }
            set
            {
                id_projetostr = value;
                try
                {
                    id_projeto = decimal.Parse(value);
                }
                catch { id_projeto = null; }
            }
        }
        public decimal id_faturamento { get; set; }
        private decimal? id_registro;
        public decimal? Id_registro
        {
            get { return id_registro; }
            set
            {
                id_registro = value;
                id_registrostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_registrostr;
        public string id_contato { get; set; } = string.Empty;
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
        public string cd_fornecedor { get; set; }
        public string cd_endereco { get; set; }
        public decimal quantidade { get; set; }
        public TRegistro_CadFatDireto_Item()
        {
            this.cd_empresa = string.Empty;
            this.id_orcamento = null;
            this.vl_unitario = decimal.Zero;
            this.vl_subtotal = decimal.Zero;
            this.cd_produto = decimal.Zero;
            this.ds_produto = string.Empty;
            this.id_orcamentostr = string.Empty;
            this.id_registro = decimal.Zero;
            this.nr_versao = null;
            this.nr_versaostr = string.Empty;
            this.id_projeto = null;
            this.id_projetostr = string.Empty;
            ds_empresa = string.Empty;
            id_faturamento = decimal.Zero;
            cd_fornecedor = string.Empty;
            cd_endereco = string.Empty;
            id_ficha = string.Empty;
            quantidade = decimal.Zero;
        }
    }
    public class TList_CadFatDireto_item : List<TRegistro_CadFatDireto_Item> { }

    public class TCD_CadFatDiretoItem : TDataQuery
    {
        public TCD_CadFatDiretoItem() { }

        public TCD_CadFatDiretoItem(BancoDados.TObjetoBanco banco) { this.Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("select " + strTop + " a.id_registro,a.cd_empresa, a.id_faturamento, a.id_orcamento, a.id_atividade, a.nr_versao, a.quantidade, a.id_ficha ");
                sql.AppendLine(", b.vl_unitario, ");
                sql.AppendLine(" vl_subtotal = (b.Vl_Unitario * a.Quantidade),");
                sql.AppendLine("cd_produto = (select x.cd_produto from vTB_EMP_FICHATEC x where a.id_ficha = x.id_ficha and a.id_orcamento = x.id_orcamento and a.id_atividade = x.id_atividade and a.nr_Versao = x.nr_versao ),");
                sql.AppendLine("ds_produto = (select y.ds_produto from vTB_EMP_FICHATEC x join TB_EST_Produto y on y.CD_Produto = x.CD_Produto where a.id_ficha = x.id_ficha and a.id_orcamento = x.id_orcamento and a.id_atividade = x.id_atividade and a.nr_Versao = x.nr_versao )");
            
            }
            else
                sql.AppendLine(" Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from TB_EMP_ItensFatDireto a ");
            sql.AppendLine("left join vtb_emp_fichatec b on a.id_ficha = b.id_ficha and a.id_orcamento = b.id_orcamento and a.id_atividade = b.id_atividade and a.nr_Versao = b.nr_versao ");

            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
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

        public TList_CadFatDireto_item Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            bool podeFecharBco = false;
            TList_CadFatDireto_item lista = new TList_CadFatDireto_item();
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_CadFatDireto_Item reg = new TRegistro_CadFatDireto_Item();
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        reg.cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    //if (!reader.IsDBNull(reader.GetOrdinal("cd_endereco")))
                    //    reg.cd_endereco = reader.GetString(reader.GetOrdinal("cd_endereco"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_faturamento")))
                        reg.id_faturamento = reader.GetDecimal(reader.GetOrdinal("id_faturamento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_registro")))
                        reg.Id_registro = reader.GetDecimal(reader.GetOrdinal("id_registro"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_ficha")))
                        reg.id_ficha = reader.GetDecimal(reader.GetOrdinal("id_ficha")).ToString();
                    if (!reader.IsDBNull(reader.GetOrdinal("Id_orcamento")))
                        reg.Id_orcamento = Convert.ToDecimal(reader.GetDecimal(reader.GetOrdinal("Id_orcamento")));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_atividade")))
                        reg.Id_projeto = reader.GetDecimal(reader.GetOrdinal("id_atividade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Nr_versao")))
                        reg.Nr_versao = reader.GetDecimal(reader.GetOrdinal("Nr_versao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("quantidade")))
                        reg.quantidade = reader.GetDecimal(reader.GetOrdinal("quantidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_subtotal")))
                        reg.vl_subtotal = reader.GetDecimal(reader.GetOrdinal("vl_subtotal"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_unitario")))
                        reg.vl_unitario = reader.GetDecimal(reader.GetOrdinal("vl_unitario"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_produto")))
                        reg.cd_produto = Convert.ToDecimal(reader.GetString(reader.GetOrdinal("cd_produto")));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_produto")))
                        reg.ds_produto = reader.GetString(reader.GetOrdinal("ds_produto"));


                    

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

        public string Gravar(TRegistro_CadFatDireto_Item val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(8);
            hs.Add("@P_CD_EMPRESA", val.cd_empresa);
            hs.Add("@P_ID_FATURAMENTO", val.id_faturamento);
            hs.Add("@P_ID_ORCAMENTO", val.Id_orcamentostr);
            hs.Add("@P_ID_ATIVIDADE", val.Id_projetostr);
            hs.Add("@P_ID_REGISTRO", val.Id_registro);
            hs.Add("@P_NR_VERSAO", val.Nr_versaostr);
            hs.Add("@P_ID_FICHA", val.id_ficha);
            hs.Add("@P_QUANTIDADE", val.quantidade);

            return this.executarProc("IA_EMP_ITENSFATDIRETO", hs);
        }

        public string Excluir(TRegistro_CadFatDireto_Item val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(8);
            hs.Add("@P_CD_EMPRESA", val.cd_empresa);
            hs.Add("@P_ID_FATURAMENTO", val.id_faturamento);
            hs.Add("@P_ID_ORCAMENTO", val.Id_orcamentostr);
            hs.Add("@P_ID_REGISTRO", val.Id_registro);
            hs.Add("@P_ID_ATIVIDADE", val.Id_projetostr);
            hs.Add("@P_NR_VERSAO", val.Nr_versaostr);
            hs.Add("@P_ID_FICHA", val.id_ficha);

            return this.executarProc("EXCLUI_EMP_ITENSFATDIRETO", hs);
        }
    }
}
