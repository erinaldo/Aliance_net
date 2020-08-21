using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamadaDados.Faturamento.PDV
{
    public class TList_DevolucaoFIN : List<TRegistro_DevolucaoFIN> { }

    public class TRegistro_DevolucaoFIN
    {
        public string Cd_empresa
        { get; set; }
        private decimal? id_devolucao;
        public decimal? Id_devolucao
        {
            get { return id_devolucao; }
            set
            {
                id_devolucao = value;
                id_devolucaostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_devolucaostr;
        public string Id_devolucaostr
        {
            get { return id_devolucaostr; }
            set
            {
                id_devolucaostr = value;
                try
                {
                    id_devolucao = decimal.Parse(value);
                }
                catch { id_devolucao = null; }
            }
        }
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
                catch { nr_lancto = null; }
            }
        }
        private decimal? cd_parcela;
        public decimal? Cd_parcela
        {
            get { return cd_parcela; }
            set
            {
                cd_parcela = value;
                cd_parcelastr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string cd_parcelastr;
        public string Cd_parcelastr
        {
            get { return cd_parcelastr; }
            set
            {
                cd_parcelastr = value;
                try
                {
                    cd_parcela = decimal.Parse(value);
                }
                catch { cd_parcela = null; }
            }
        }
        public decimal Vl_devolvido
        { get; set; }
        public decimal Vl_nominal
        { get; set; }

        public TRegistro_DevolucaoFIN()
        {
            this.Cd_empresa = string.Empty;
            this.id_devolucao = null;
            this.id_devolucaostr = string.Empty;
            this.nr_lancto = null;
            this.nr_lanctostr = string.Empty;
            this.cd_parcela = null;
            this.cd_parcelastr = string.Empty;
            this.Vl_devolvido = decimal.Zero;
            this.Vl_nominal = decimal.Zero;
        }
    }

    public class TCD_DevolucaoFIN : TDataQuery
    {
        public TCD_DevolucaoFIN() { }

        public TCD_DevolucaoFIN(BancoDados.TObjetoBanco banco) { this.Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNm_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = " TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNm_Campo))
            {
                sql.AppendLine("Select " + strTop + " a.cd_empresa, a.id_devolucao, ");
                sql.AppendLine("a.nr_lancto, a.cd_parcela, a.vl_devolvido, b.vl_parcela_padrao ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNm_Campo + " ");
            sql.AppendLine("from TB_PDV_DevolucaoFIN a ");
            sql.AppendLine("inner join TB_FIN_Parcela b ");
            sql.AppendLine("on a.cd_empresa = b.cd_empresa ");
            sql.AppendLine("and a.nr_lancto = b.nr_lancto ");
            sql.AppendLine("and a.cd_parcela = b.cd_parcela ");

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

        public TList_DevolucaoFIN Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNm_Campo)
        {
            TList_DevolucaoFIN lista = new TList_DevolucaoFIN();
            System.Data.SqlClient.SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            try
            {
                reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNm_Campo));
                while (reader.Read())
                {
                    TRegistro_DevolucaoFIN reg = new TRegistro_DevolucaoFIN();

                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_devolucao")))
                        reg.Id_devolucao = reader.GetDecimal(reader.GetOrdinal("id_devolucao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_lancto")))
                        reg.Nr_lancto = reader.GetDecimal(reader.GetOrdinal("nr_lancto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_parcela")))
                        reg.Cd_parcela = reader.GetDecimal(reader.GetOrdinal("cd_parcela"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_devolvido")))
                        reg.Vl_devolvido = reader.GetDecimal(reader.GetOrdinal("vl_devolvido"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_parcela_padrao")))
                        reg.Vl_nominal = reader.GetDecimal(reader.GetOrdinal("vl_parcela_padrao"));

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

        public string Gravar(TRegistro_DevolucaoFIN val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(5);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_DEVOLUCAO", val.Id_devolucao);
            hs.Add("@P_NR_LANCTO", val.Nr_lancto);
            hs.Add("@P_CD_PARCELA", val.Cd_parcela);
            hs.Add("@P_VL_DEVOLVIDO", val.Vl_devolvido);

            return this.executarProc("IA_PDV_DEVOLUCAOFIN", hs);
        }

        public string Excluir(TRegistro_DevolucaoFIN val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(4);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_DEVOLUCAO", val.Id_devolucao);
            hs.Add("@P_NR_LANCTO", val.Nr_lancto);
            hs.Add("@P_CD_PARCELA", val.Cd_parcela);

            return this.executarProc("EXCLUI_PDV_DEVOLUCAOFIN", hs);
        }
    }
}
