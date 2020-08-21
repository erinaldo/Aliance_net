using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Utils;

namespace CamadaDados.Contabil.Cadastro
{
    public class TList_PlanoReferencial : List<TRegistro_PlanoReferencial> { }

    public class TRegistro_PlanoReferencial
    {
        public string Cd_referencia
        { get; set; }
        public string Nome
        { get; set; }
        public string Cd_referenciapai
        { get; set; }
        public string Nomepai
        { get; set; }
        private DateTime? dt_ini;
        public DateTime? Dt_ini
        {
            get { return dt_ini; }
            set
            {
                dt_ini = value;
                dt_inistr = value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty;
            }
        }
        private string dt_inistr;
        public string Dt_inistr
        {
            get
            {
                try
                {
                    return DateTime.Parse(dt_inistr).ToString("dd/MM/yyyy");
                }
                catch { return string.Empty; }
            }
            set
            {
                dt_inistr = value;
                try
                {
                    dt_ini = DateTime.Parse(value);
                }
                catch { dt_ini = null; }
            }
        }
        private DateTime? dt_fin;
        public DateTime? Dt_fin
        {
            get { return dt_fin; }
            set
            {
                dt_fin = value;
                dt_finstr = value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty;
            }
        }
        private string dt_finstr;
        public string Dt_finstr
        {
            get
            {
                try
                {
                    return DateTime.Parse(dt_finstr).ToString("dd/MM/yyyy");
                }
                catch { return string.Empty; }
            }
            set
            {
                dt_finstr = value;
                try
                {
                    dt_fin = DateTime.Parse(value);
                }
                catch { dt_fin = null; }
            }
        }
        private string tp_conta;
        public string Tp_conta
        {
            get { return tp_conta; }
            set
            {
                tp_conta = value;
                if (value.Trim().ToUpper().Equals("A"))
                    tipo_conta = "ANALITICA";
                else if (value.Trim().ToUpper().Equals("S"))
                    tipo_conta = "SINTETICA";
            }
        }
        private string tipo_conta;
        public string Tipo_conta
        {
            get { return tipo_conta; }
            set
            {
                tipo_conta = value;
                if (value.Trim().ToUpper().Equals("ANALITICA"))
                    tp_conta = "A";
                else if (value.Trim().ToUpper().Equals("SINTETICA"))
                    tp_conta = "S";
            }
        }
        public decimal Nivel
        { get; set; }
        public string Natureza
        { get; set; }
        public string Naturezastr
        {
            get
            {
                if (this.Natureza.Trim().Equals("1"))
                    return "CONTA ATIVO";
                else if (this.Natureza.Trim().Equals("2"))
                    return "CONTA PASSIVO";
                else if (this.Natureza.Trim().Equals("3"))
                    return "PATRIMONIO LIQUIDO";
                else if (this.Natureza.Trim().Equals("4"))
                    return "CONTA RESULTADO";
                else if (this.Natureza.Trim().Equals("5"))
                    return "CONTA COMPENSAÇÃO";
                else if (this.Natureza.Trim().Equals("9"))
                    return "OUTRAS";
                else return string.Empty;
            }
        }

        private string nat;
        public string Nat
        {
            get { return nat; }
            set
            {
                nat = value;
                if (value.Trim().ToUpper().Equals("CONTA ATIVO"))
                    Natureza = "1";
                else if (value.Trim().ToUpper().Equals("CONTA PASSIVO"))
                    Natureza = "2";
                else if (value.Trim().ToUpper().Equals("PATRIMONIO LIQUIDO"))
                    Natureza = "3";
                else if (value.Trim().ToUpper().Equals("CONTA RESULTADO"))
                    Natureza = "4";
                else if (value.Trim().ToUpper().Equals("CONTA COMPENSAÇÃO"))
                    Natureza = "5";
                else if (value.Trim().ToUpper().Equals("OUTRAS"))
                    Natureza = "9";
            }
        }

        public TRegistro_PlanoReferencial()
        {
            this.Cd_referencia = string.Empty;
            this.Nome = string.Empty;
            this.Cd_referenciapai = string.Empty;
            this.Nomepai = string.Empty;
            this.dt_ini = null;
            this.dt_inistr = string.Empty;
            this.dt_fin = null;
            this.dt_finstr = string.Empty;
            this.tp_conta = string.Empty;
            this.tipo_conta = string.Empty;
            this.Nivel = decimal.Zero;
            this.Natureza = string.Empty;
            this.nat = string.Empty;
        }
    }

    public class TCD_PlanoReferencial : TDataQuery
    {
        public TCD_PlanoReferencial() { }

        public TCD_PlanoReferencial(BancoDados.TObjetoBanco banco) { this.Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();

            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine(" SELECT " + strTop + " a.CD_Referencia, SPACE((a.nivel-1)*5) + a.nome as Nome, ");
                sql.AppendLine("a.cd_referenciapai, b.nome as nomepai, a.dt_ini, a.dt_fin, a.tp_conta, a.nivel, a.natureza ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("FROM  TB_CTB_PlanoReferencial a ");
            sql.AppendLine("left outer join TB_CTB_PlanoReferencial b ");
            sql.AppendLine("on b.cd_referencia = a.cd_referenciapai ");
                        
            string cond = " and ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                    sql.Append(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
            sql.AppendLine("order by a.cd_referencia ");
            return sql.ToString();
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, string.Empty), null);
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo), null);
        }

        public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
        {
            return this.ExecutarBuscaEscalar(this.SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }

        public TList_PlanoReferencial Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_PlanoReferencial lista = new TList_PlanoReferencial();
            System.Data.SqlClient.SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);

            try
            {
                reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
                while (reader.Read())
                {
                    TRegistro_PlanoReferencial reg = new TRegistro_PlanoReferencial();
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_referencia")))
                        reg.Cd_referencia = reader.GetString(reader.GetOrdinal("cd_referencia"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nome")))
                        reg.Nome = reader.GetString(reader.GetOrdinal("nome"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_referenciapai")))
                        reg.Cd_referenciapai = reader.GetString(reader.GetOrdinal("cd_referenciapai"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nomepai")))
                        reg.Nomepai = reader.GetString(reader.GetOrdinal("nomepai"));
                    if (!reader.IsDBNull(reader.GetOrdinal("dt_ini")))
                        reg.Dt_ini = reader.GetDateTime(reader.GetOrdinal("dt_ini"));
                    if (!reader.IsDBNull(reader.GetOrdinal("dt_fin")))
                        reg.Dt_fin = reader.GetDateTime(reader.GetOrdinal("dt_fin"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_conta")))
                        reg.Tp_conta = reader.GetString(reader.GetOrdinal("tp_conta"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nivel")))
                        reg.Nivel = reader.GetDecimal(reader.GetOrdinal("nivel"));
                    if (!reader.IsDBNull(reader.GetOrdinal("natureza")))
                        reg.Natureza = reader.GetString(reader.GetOrdinal("natureza"));

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

        public string Gravar(TRegistro_PlanoReferencial val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(8);
            hs.Add("@P_CD_REFERENCIA", val.Cd_referencia);
            hs.Add("@P_CD_REFERENCIAPAI", val.Cd_referenciapai);
            hs.Add("@P_NOME", val.Nome);
            hs.Add("@P_DT_INI", val.Dt_ini);
            hs.Add("@P_DT_FIN", val.Dt_fin);
            hs.Add("@P_TP_CONTA", val.Tp_conta);
            hs.Add("@P_NIVEL", val.Nivel);
            hs.Add("@P_NATUREZA", val.Natureza);

            return this.executarProc("IA_CTB_PLANOREFERENCIAL", hs);
        }

        public string Excluir(TRegistro_PlanoReferencial val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(1);
            hs.Add("@P_CD_REFERENCIA", val.Cd_referencia);

            return this.executarProc("EXCLUI_CTB_PLANOREFERENCIAL", hs);
        }
    }
}
