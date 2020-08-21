using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamadaDados.Empreendimento
{
    public class TList_FichaItens : List<TRegistro_FichaItens> { } 
    public class TRegistro_FichaItens : ICloneable
    {

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
        public decimal vl_faturar { get; set; }
        private decimal? cd_item;
        public decimal? Cd_item
        {
            get { return cd_item; }
            set
            {
                cd_item = value;
                cd_itemstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string cd_itemstr;
        public string Cd_itemstr
        {
            get { return cd_itemstr; }
            set
            {
                cd_itemstr = value;
                try
                {
                    cd_item = decimal.Parse(value);
                }
                catch { cd_item = null; }
            }
        }
        public string ds_item { get; set; }

        public string Cd_empresa
        { get; set; }
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
                }
                catch { id_projeto = null; }
            }
        }
        private decimal? id_ficha;
        public decimal? Id_ficha
        {
            get { return id_ficha; }
            set
            {
                id_ficha = value;
                id_fichastr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_fichastr;
        public string Id_fichastr
        {
            get { return id_fichastr; }
            set
            {
                id_fichastr = value;
                try
                {
                    id_ficha = decimal.Parse(value);
                }
                catch { id_ficha = null; }
            }
        }
        public decimal quantidade { get; set; }
        public decimal vl_unitario { get; set; }
        public decimal vl_subtotal{ get; set; }

        public TRegistro_FichaItens()
        {
            this.cd_item = decimal.Zero;
            this.Cd_empresa = string.Empty;
            this.ds_item = string.Empty;
            this.id_orcamento = null;
            this.id_orcamentostr = string.Empty;
            this.nr_versao = null;
            this.nr_versaostr = string.Empty;
            this.id_projeto = null;
            this.id_projetostr = string.Empty;
            this.id_ficha = null;
            this.id_fichastr = string.Empty;
            this.quantidade = decimal.Zero;
            this.vl_unitario = decimal.Zero;
            this.vl_subtotal = decimal.Zero;
        }

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
    
    public class TCD_FichaItens : TDataQuery
    {
        public TCD_FichaItens() { }

        public TCD_FichaItens(BancoDados.TObjetoBanco banco) { this.Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("select " + strTop + " a.id_registro, a.cd_empresa, a.id_orcamento, ");
                sql.AppendLine("a.nr_versao, a.id_atividade, a.id_ficha, ");
                sql.AppendLine("a.cd_item, a.quantidade, a.vl_unitcusto ");
                sql.AppendLine(" ");
            }
            else
                sql.AppendLine(" Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from TB_EMP_FichaItensComp a ");
            sql.AppendLine("inner join vTB_EMP_FichaTec b ");
            sql.AppendLine("on a.cd_empresa = b.cd_empresa and a.id_ficha = b.id_ficha  and a.id_orcamento = b.id_orcamento and a.nr_versao = b.nr_versao and a.id_atividade = b.id_atividade ");


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

        public TList_FichaItens Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            bool podeFecharBco = false;
            TList_FichaItens lista = new TList_FichaItens();
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_FichaItens reg = new TRegistro_FichaItens();
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_orcamento")))
                        reg.Id_orcamento = reader.GetDecimal(reader.GetOrdinal("id_orcamento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_registro")))
                        reg.Id_registro = reader.GetDecimal(reader.GetOrdinal("id_registro"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_item")))
                        reg.Cd_itemstr = (reader.GetString(reader.GetOrdinal("cd_item")));
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_versao")))
                        reg.Nr_versao = reader.GetDecimal(reader.GetOrdinal("nr_versao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_atividade")))
                        reg.Id_projeto = reader.GetDecimal(reader.GetOrdinal("id_atividade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_ficha")))
                        reg.Id_ficha = reader.GetDecimal(reader.GetOrdinal("id_ficha"));
                    if (!reader.IsDBNull(reader.GetOrdinal("quantidade")))
                        reg.quantidade = reader.GetDecimal(reader.GetOrdinal("quantidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_unitcusto")))
                        reg.vl_unitario = reader.GetDecimal(reader.GetOrdinal("vl_unitcusto"));

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

        public string Gravar(TRegistro_FichaItens val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(9);
            hs.Add("@P_CD_ITEM", val.Cd_itemstr);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_ORCAMENTO", val.Id_orcamento);
            hs.Add("@P_ID_REGISTRO", val.Id_registro);
            hs.Add("@P_NR_VERSAO", val.Nr_versao);
            hs.Add("@P_ID_ATIVIDADE", val.Id_projeto);
            hs.Add("@P_ID_FICHA", val.Id_ficha);
            hs.Add("@P_QUANTIDADE", val.quantidade);
            hs.Add("@P_VL_UNITCUSTO", val.vl_unitario);

            return this.executarProc("IA_EMP_FICHAITENSCOMP", hs);
        }

        public string Excluir(TRegistro_FichaItens val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(7);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_ORCAMENTO", val.Id_orcamento);
            hs.Add("@P_ID_REGISTRO", val.Id_registro);
            hs.Add("@P_NR_VERSAO", val.Nr_versao);
            hs.Add("@P_ID_ATIVIDADE", val.Id_projeto);
            hs.Add("@P_ID_FICHA", val.Id_ficha);
            hs.Add("@P_CD_ITEM", val.Cd_itemstr);

            return this.executarProc("EXCLUI_EMP_FICHAITENSCOMP", hs);
        }
    }
}
