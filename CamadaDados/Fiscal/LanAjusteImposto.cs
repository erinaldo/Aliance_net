using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamadaDados.Fiscal
{
    public class TList_AjusteImposto : List<TRegistro_AjusteImposto>
    { }

    
    public class TRegistro_AjusteImposto
    {
        private decimal? id_lancto;
        
        public decimal? Id_lancto
        {
            get { return id_lancto; }
            set
            {
                id_lancto = value;
                id_lanctostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_lanctostr;
        
        public string Id_lanctostr
        {
            get { return id_lanctostr; }
            set
            {
                id_lanctostr = value;
                try
                {
                    id_lancto = decimal.Parse(value);
                }
                catch
                { id_lancto = null; }
            }
        }
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
                catch
                { id_registro = null; }
            }
        }
        
        public string Nr_docarrecadacao
        { get; set; }
        
        public string Nr_procajuste
        { get; set; }
        
        public string Tp_origemicms
        { get; set; }
        public string Tipo_origemicms
        {
            get
            {
                if (Tp_origemicms.Trim().Equals("0"))
                    return "SEFAZ";
                else if (Tp_origemicms.Trim().Equals("1"))
                    return "JUSTIÇA FEDERAL";
                else if (Tp_origemicms.Trim().Equals("2"))
                    return "JUSTIÇA ESTADUAL";
                else if (Tp_origemicms.Trim().Equals("9"))
                    return "OUTROS";
                else return string.Empty;
            }
        }
        
        public string Ds_processo
        { get; set; }
        
        public string Ds_complementar
        { get; set; }

        public TRegistro_AjusteImposto()
        {
            this.id_lancto = null;
            this.id_lanctostr = string.Empty;
            this.id_registro = null;
            this.id_registrostr = string.Empty;
            this.Nr_docarrecadacao = string.Empty;
            this.Nr_procajuste = string.Empty;
            this.Tp_origemicms = string.Empty;
            this.Ds_processo = string.Empty;
            this.Ds_complementar = string.Empty;
        }
    }

    public class TCD_AjusteImposto : TDataQuery
    {
        public TCD_AjusteImposto()
        { }

        public TCD_AjusteImposto(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int16 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("Select " + strTop + " a.id_lancto, a.id_registro, ");
                sql.AppendLine("a.nr_docarrecadacao, a.nr_procajuste, ");
                sql.AppendLine("a.tp_origemicms, a.ds_processo, a.ds_complementar ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("From TB_FIS_ProcAjusteImposto A ");
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

        public TList_AjusteImposto Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_AjusteImposto lista = new TList_AjusteImposto();
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_AjusteImposto reg = new TRegistro_AjusteImposto();
                    if (!(reader.IsDBNull(reader.GetOrdinal("id_registro"))))
                        reg.Id_registro = reader.GetDecimal(reader.GetOrdinal("id_registro"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("id_lancto"))))
                        reg.Id_lancto = reader.GetDecimal(reader.GetOrdinal("id_lancto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_docarrecadacao")))
                        reg.Nr_docarrecadacao = reader.GetString(reader.GetOrdinal("nr_docarrecadacao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_procajuste")))
                        reg.Nr_procajuste = reader.GetString(reader.GetOrdinal("nr_procajuste"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_origemicms")))
                        reg.Tp_origemicms = reader.GetString(reader.GetOrdinal("tp_origemicms"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_processo")))
                        reg.Ds_processo = reader.GetString(reader.GetOrdinal("ds_processo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_complementar")))
                        reg.Ds_complementar = reader.GetString(reader.GetOrdinal("ds_complementar"));

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

        public string Gravar(TRegistro_AjusteImposto val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(7);
            hs.Add("@P_ID_REGISTRO", val.Id_registro);
            hs.Add("@P_ID_LANCTO", val.Id_lancto);
            hs.Add("@P_NR_DOCARRECADACAO", val.Nr_docarrecadacao);
            hs.Add("@P_NR_PROCAJUSTE", val.Nr_procajuste);
            hs.Add("@P_TP_ORIGEMICMS", val.Tp_origemicms);
            hs.Add("@P_DS_PROCESSO", val.Ds_processo);
            hs.Add("@P_DS_COMPLEMENTAR", val.Ds_complementar);

            return this.executarProc("IA_FIS_PROCAJUSTEIMPOSTO", hs);
        }

        public string Excluir(TRegistro_AjusteImposto val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(2);
            hs.Add("@P_ID_REGISTRO", val.Id_registro);
            hs.Add("@P_ID_LANCTO", val.Id_lancto);

            return this.executarProc("EXCLUI_FIS_PROCAJUSTEIMPOSTO", hs);
        }
    }
}
