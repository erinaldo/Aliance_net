using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamadaDados.Graos
{
    public class TList_ImpostosReterFixacao : List<TRegistro_ImpostosReterFixacao>
    { }
    
    public class TRegistro_ImpostosReterFixacao
    {
        private decimal? nr_contrato;
        public decimal? Nr_contrato
        {
            get { return nr_contrato; }
            set
            {
                nr_contrato = value;
                nr_contratostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string nr_contratostr;
        public string Nr_contratostr
        {
            get { return nr_contratostr; }
            set
            {
                nr_contratostr = value;
                try
                {
                    nr_contrato = Convert.ToDecimal(value);
                }
                catch
                { nr_contrato = null; }
            }
        }
        private decimal? cd_imposto;
        public decimal? Cd_imposto
        {
            get { return cd_imposto; }
            set
            {
                cd_imposto = value;
                cd_impostostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string cd_impostostr;
        public string Cd_impostostr
        {
            get { return cd_impostostr; }
            set
            {
                cd_impostostr = value;
                try
                {
                    cd_imposto = Convert.ToDecimal(value);
                }
                catch
                { cd_imposto = null; }
            }
        }
        public string Ds_imposto
        { get; set; }
        public decimal Pc_aliquota
        { get; set; }
        public decimal Pc_reducaobasecalc
        { get; set; }
        public decimal Vl_basecalc
        { get; set; }
        public decimal Vl_imposto
        { get; set; }

        public TRegistro_ImpostosReterFixacao()
        {
            this.nr_contrato = null;
            this.nr_contratostr = string.Empty;
            this.cd_imposto = null;
            this.cd_impostostr = string.Empty;
            this.Ds_imposto = string.Empty;
            this.Pc_aliquota = decimal.Zero;
            this.Pc_reducaobasecalc = decimal.Zero;
            this.Vl_basecalc = decimal.Zero;
            this.Vl_imposto = decimal.Zero;
        }
    }

    public class TCD_ImpostosReterFixacao : TDataQuery
    {
        public TCD_ImpostosReterFixacao()
        { }

        public TCD_ImpostosReterFixacao(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("select " + strTop + " a.Nr_Contrato, a.PC_Aliquota, ");
                sql.AppendLine("a.CD_Imposto, b.ds_imposto, a.PC_ReducaoBaseCalc ");
            }
            else
                sql.AppendLine(" Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from TB_GRO_ImpostosReterFixacao a ");
            sql.AppendLine("inner join TB_FIS_Imposto b ");
            sql.AppendLine("on a.cd_imposto = b.cd_imposto ");

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

        public TList_ImpostosReterFixacao Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            bool podeFecharBco = false;
            TList_ImpostosReterFixacao lista = new TList_ImpostosReterFixacao();
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_ImpostosReterFixacao reg = new TRegistro_ImpostosReterFixacao();

                    if (!reader.IsDBNull(reader.GetOrdinal("Nr_Contrato")))
                        reg.Nr_contrato = reader.GetDecimal(reader.GetOrdinal("Nr_Contrato"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Imposto")))
                        reg.Cd_imposto = reader.GetDecimal(reader.GetOrdinal("CD_Imposto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_imposto")))
                        reg.Ds_imposto = reader.GetString(reader.GetOrdinal("ds_imposto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("PC_Aliquota")))
                        reg.Pc_aliquota = reader.GetDecimal(reader.GetOrdinal("PC_Aliquota"));
                    if (!reader.IsDBNull(reader.GetOrdinal("PC_ReducaoBaseCalc")))
                        reg.Pc_reducaobasecalc = reader.GetDecimal(reader.GetOrdinal("PC_ReducaoBaseCalc"));

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

        public string Gravar(TRegistro_ImpostosReterFixacao val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(4);
            hs.Add("@P_NR_CONTRATO", val.Nr_contrato);
            hs.Add("@P_CD_IMPOSTO", val.Cd_imposto);
            hs.Add("@P_PC_ALIQUOTA", val.Pc_aliquota);
            hs.Add("@P_PC_REDUCAOBASECALC", val.Pc_reducaobasecalc);

            return this.executarProc("IA_GRO_IMPOSTOSRETERFIXACAO", hs);
        }

        public string Excluir(TRegistro_ImpostosReterFixacao val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(2);
            hs.Add("@P_NR_CONTRATO", val.Nr_contrato);
            hs.Add("@P_CD_IMPOSTO", val.Cd_imposto);

            return this.executarProc("EXCLUI_GRO_IMPOSTOSRETERFIXACAO", hs);
        }
    }
}
