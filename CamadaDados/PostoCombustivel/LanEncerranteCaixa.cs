using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamadaDados.PostoCombustivel
{
    public class TList_EncerranteCaixa : List<TRegistro_EncerranteCaixa>
    { }

    public class TRegistro_EncerranteCaixa
    {
        private decimal? id_bico;
        public decimal? Id_bico
        {
            get { return id_bico; }
            set
            {
                id_bico = value;
                Id_bicostr = value.HasValue ? value.Value.ToString() : string.Empty;
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
                catch { id_bico = null; }
            }
        }
        public string Ds_label
        { get; set; }
        private decimal? id_caixa;
        public decimal? Id_caixa
        {
            get { return id_caixa; }
            set
            {
                id_caixa = value;
                id_caixastr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_caixastr;
        public string Id_caixastr
        {
            get { return id_caixastr; }
            set
            {
                id_caixastr = value;
                try
                {
                    id_caixa = decimal.Parse(value);
                }
                catch { id_caixa = null; }
            }
        }
        public decimal Encerrante
        { get; set; }

        public TRegistro_EncerranteCaixa()
        {
            this.id_bico = null;
            this.id_bicostr = string.Empty;
            this.Ds_label = string.Empty;
            this.id_caixa = null;
            this.id_caixastr = string.Empty;
            this.Encerrante = decimal.Zero;
        }
    }

    public class TCD_EncerranteCaixa : TDataQuery
    {
        public TCD_EncerranteCaixa() { }

        public TCD_EncerranteCaixa(BancoDados.TObjetoBanco banco) { this.Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + vTop.ToString();

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("select " + strTop + " a.id_bico, ");
                sql.AppendLine("a.id_caixa, b.ds_label, a.encerrante ");
            }
            else
                sql.AppendLine(" Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from tb_pdc_encerrantecaixa a ");
            sql.AppendLine("inner join tb_pdc_bicobomba b ");
            sql.AppendLine("on a.id_bico = b.id_bico ");

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

        public TList_EncerranteCaixa Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            bool podeFecharBco = false;
            TList_EncerranteCaixa lista = new TList_EncerranteCaixa();
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_EncerranteCaixa reg = new TRegistro_EncerranteCaixa();
                    if (!reader.IsDBNull(reader.GetOrdinal("id_bico")))
                        reg.Id_bico = reader.GetDecimal(reader.GetOrdinal("id_bico"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_label")))
                        reg.Ds_label = reader.GetString(reader.GetOrdinal("ds_label"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_caixa")))
                        reg.Id_caixa = reader.GetDecimal(reader.GetOrdinal("id_caixa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("encerrante")))
                        reg.Encerrante = reader.GetDecimal(reader.GetOrdinal("encerrante"));

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

        public string Gravar(TRegistro_EncerranteCaixa val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(3);
            hs.Add("@P_ID_BICO", val.Id_bico);
            hs.Add("@P_ID_CAIXA", val.Id_caixa);
            hs.Add("@P_ENCERRANTE", val.Encerrante);

            return this.executarProc("IA_PDC_ENCERRANTECAIXA", hs);
        }

        public string Excluir(TRegistro_EncerranteCaixa val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(2);
            hs.Add("@P_ID_BICO", val.Id_bico);
            hs.Add("@P_ID_CAIXA", val.Id_caixa);

            return this.executarProc("EXCLUI_PDC_ENCERRANTECAIXA", hs);
        }
    }
}
