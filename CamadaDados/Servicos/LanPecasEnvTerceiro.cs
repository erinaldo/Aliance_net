using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Utils;

namespace CamadaDados.Servicos
{
    public class TList_LanPecasEnvTerceiro : List<TRegistro_LanPecasEnvTerceiro>, IComparer<TRegistro_LanPecasEnvTerceiro>
    {
        #region IComparer<TRegistro_LanPecasEnvTerceiro> Members
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

        public TList_LanPecasEnvTerceiro()
        { }

        public TList_LanPecasEnvTerceiro(System.ComponentModel.PropertyDescriptor Prop,
                                      System.Windows.Forms.SortOrder Dir)
        {
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_LanPecasEnvTerceiro value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_LanPecasEnvTerceiro x, TRegistro_LanPecasEnvTerceiro y)
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

    public class TRegistro_LanPecasEnvTerceiro
    {
        private decimal? id_os;

        public decimal? Id_os
        {
            get { return id_os; }
            set
            {
                id_os = value;
                id_osstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_osstr;

        public string Id_osstr
        {
            get { return id_osstr; }
            set
            {
                id_osstr = value;
                try
                {
                    id_os = decimal.Parse(value);
                }
                catch
                { id_os = null; }
            }
        }

        public string Cd_empresa
        { get; set; }
        private decimal? id_evolucao;

        public decimal? Id_evolucao
        {
            get { return id_evolucao; }
            set
            {
                id_evolucao = value;
                id_evolucaostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_evolucaostr;

        public string Id_evolucaostr
        {
            get { return id_evolucaostr; }
            set
            {
                id_evolucaostr = value;
                try
                {
                    id_evolucao = decimal.Parse(value);
                }
                catch
                { id_evolucao = null; }
            }
        }
        public string Cd_produto
        { get; set; }
        private decimal? id_MovAmxE;

        public decimal? Id_MovAmxE
        {
            get { return id_MovAmxE; }
            set
            {
                id_MovAmxE = value;
                id_MovAmxEstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_MovAmxEstr;

        public string Id_MovAmxEstr
        {
            get { return id_MovAmxEstr; }
            set
            {
                id_MovAmxEstr = value;
                try
                {
                    id_MovAmxE = decimal.Parse(value);
                }
                catch
                { id_MovAmxE = null; }
            }
        }
        private decimal? id_MovAmxS;

        public decimal? Id_MovAmxS
        {
            get { return id_MovAmxS; }
            set
            {
                id_MovAmxS = value;
                id_MovAmxSstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_MovAmxSstr;

        public string Id_MovAmxSstr
        {
            get { return id_MovAmxSstr; }
            set
            {
                id_MovAmxSstr = value;
                try
                {
                    id_MovAmxS = decimal.Parse(value);
                }
                catch
                { id_MovAmxS = null; }
            }
        }
        public decimal Quantidade
        { get; set; }



        public TRegistro_LanPecasEnvTerceiro()
        {
            this.id_os = null;
            this.id_osstr = string.Empty;
            this.Cd_empresa = string.Empty;
            this.id_evolucao = null;
            this.id_evolucaostr = string.Empty;
            this.Cd_produto = string.Empty;
            this.Id_MovAmxE = null;
            this.id_MovAmxEstr = string.Empty;
            this.id_MovAmxS = null;
            this.id_MovAmxSstr = string.Empty;
            this.Quantidade = decimal.Zero;
        }
    }

    public class TCD_LanPecasEnvTerceiro : TDataQuery
    {
        public TCD_LanPecasEnvTerceiro()
        { }

        public TCD_LanPecasEnvTerceiro(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("SELECT " + strTop + " a.ID_OS, a.CD_Empresa, a.ID_Evolucao, a.cd_produto, ");
                sql.AppendLine("a.ID_MovAmxE, a.ID_MovAmxS, a.Quantidade ");
            }
            else
                sql.AppendLine(" Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from TB_OSE_PecasEnvTerceiro a ");

            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                    cond = " and ";
                }

            return sql.ToString();
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, ""), null);
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo), null);
        }

        public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
        {
            return this.ExecutarBuscaEscalar(this.SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }

        public TList_LanPecasEnvTerceiro Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            bool podeFecharBco = false;
            TList_LanPecasEnvTerceiro lista = new TList_LanPecasEnvTerceiro();

            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            SqlDataReader reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_LanPecasEnvTerceiro reg = new TRegistro_LanPecasEnvTerceiro();
                    if (!(reader.IsDBNull(reader.GetOrdinal("ID_OS"))))
                        reg.Id_os = reader.GetDecimal(reader.GetOrdinal("ID_OS"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_Empresa"))))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("CD_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Evolucao")))
                        reg.Id_evolucao = reader.GetDecimal(reader.GetOrdinal("ID_Evolucao"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("Cd_produto"))))
                        reg.Cd_produto = reader.GetString(reader.GetOrdinal("Cd_produto"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("Id_MovAmxE"))))
                        reg.Id_MovAmxE = reader.GetDecimal(reader.GetOrdinal("Id_MovAmxE"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Id_MovAmxS")))
                        reg.Id_MovAmxS = reader.GetDecimal(reader.GetOrdinal("Id_MovAmxS"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("Quantidade"))))
                        reg.Quantidade = reader.GetDecimal(reader.GetOrdinal("Quantidade"));
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

        public string Gravar(TRegistro_LanPecasEnvTerceiro val)
        {
            Hashtable hs = new Hashtable(7);
            hs.Add("@P_ID_OS", val.Id_os);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_EVOLUCAO", val.Id_evolucao);
            hs.Add("@P_CD_PRODUTO", val.Cd_produto);
            hs.Add("@P_ID_MOVAMXE", val.Id_MovAmxE);
            hs.Add("@P_ID_MOVAMXS", val.Id_MovAmxS);
            hs.Add("@P_QUANTIDADE", val.Quantidade);

            return this.executarProc("IA_OSE_PECASENVTERCEIRO", hs);
        }

        public string Excluir(TRegistro_LanPecasEnvTerceiro val)
        {
            Hashtable hs = new Hashtable(4);
            hs.Add("@P_ID_OS", val.Id_os);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_EVOLUCAO", val.Id_evolucao);
            hs.Add("@P_CD_PRODUTO", val.Cd_produto);

            return this.executarProc("EXCLUI_OSE_PECASENVTERCEIRO", hs);
        }
    }
}
