using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;
using System.Data.SqlClient;

namespace CamadaDados.Diversos
{
    public class TList_Licenca : List<TRegistro_Licenca>
    { }
    
    public class TRegistro_Licenca
    {
        public decimal Cd_licenca
        { get; set; }
        private DateTime? dt_ativacao;
        public DateTime? Dt_ativacao
        {
            get { return dt_ativacao; }
            set
            {
                dt_ativacao = value;
                dt_ativacaostr = value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty;
            }
        }
        private string dt_ativacaostr;
        public string Dt_ativacaostr
        {
            get
            {
                try
                {
                    return Convert.ToDateTime(dt_ativacaostr).ToString("dd/MM/yyyy");
                }
                catch
                { return string.Empty; }
            }
            set
            {
                dt_ativacaostr = value;
                try
                {
                    dt_ativacao = Convert.ToDateTime(value);
                }
                catch
                { dt_ativacao = null; }
            }
        }
        private DateTime? dt_ultimoacesso;
        public DateTime? Dt_ultimoacesso
        {
            get { return dt_ultimoacesso; }
            set
            {
                dt_ultimoacesso = value;
                dt_ultimoacessostr = value.HasValue ? value.Value.ToString("dd/MM/yyyy HH:mm:ss") : string.Empty;
            }
        }
        private string dt_ultimoacessostr;
        public string Dt_ultimoacessostr
        {
            get
            {
                try
                {
                    return Convert.ToDateTime(dt_ultimoacessostr).ToString("dd/MM/yyyy HH:mm:ss");
                }
                catch
                { return string.Empty; }
            }
            set
            {
                dt_ultimoacessostr = value;
                try
                {
                    dt_ultimoacesso = Convert.ToDateTime(value);
                }
                catch
                { dt_ultimoacesso = null; }
            }
        }
        public decimal Qt_diasvalidade
        { get; set; }
        public decimal Qt_diasavisobloqueio
        { get; set; }
        public string Chave_validade
        { get; set; }
        public string Hash_chave
        { get; set; }
        public int Nr_sequencial
        { get; set; }

        public TRegistro_Licenca()
        {
            this.Cd_licenca = decimal.Zero;
            this.dt_ativacao = null;
            this.dt_ativacaostr = string.Empty;
            this.dt_ultimoacesso = null;
            this.dt_ultimoacessostr = string.Empty;
            this.Qt_diasvalidade = decimal.Zero;
            this.Qt_diasavisobloqueio = decimal.Zero;
            this.Chave_validade = string.Empty;
            this.Hash_chave = string.Empty;
            this.Nr_sequencial = int.MinValue;
        }
    }

    public class TCD_Licenca : TDataQuery
    {
        public TCD_Licenca() { }

        public TCD_Licenca(BancoDados.TObjetoBanco banco) { this.Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, Int16 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();

            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine(" SELECT " + strTop + " a.cd_licenca, a.dt_ativacao, ");
                sql.AppendLine("a.dt_ultimoacesso, a.qt_diasvalidade, a.qt_diasavisobloqueio, ");
                sql.AppendLine("a.chave_validade, a.hash_chave, a.nr_sequencial ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine(" FROM TB_DIV_Licenca a ");

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

        public override System.Data.DataTable Buscar(TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo), null);
        }

        public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
        {
            return this.ExecutarBuscaEscalar(this.SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }

        public TList_Licenca Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_Licenca lista = new TList_Licenca();
            SqlDataReader reader = null;
            bool podeFecharBco = false;

            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);

            try
            {
                reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), string.Empty));
                while (reader.Read())
                {
                    TRegistro_Licenca reg = new TRegistro_Licenca();
                    if (!(reader.IsDBNull(reader.GetOrdinal("cd_licenca"))))
                        reg.Cd_licenca = reader.GetDecimal(reader.GetOrdinal("cd_licenca"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("dt_ativacao"))))
                        reg.Dt_ativacao = reader.GetDateTime(reader.GetOrdinal("dt_ativacao"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("dt_ultimoacesso"))))
                        reg.Dt_ultimoacesso = reader.GetDateTime(reader.GetOrdinal("dt_ultimoacesso"));
                    if (!reader.IsDBNull(reader.GetOrdinal("qt_diasvalidade")))
                        reg.Qt_diasvalidade = reader.GetDecimal(reader.GetOrdinal("qt_diasvalidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("qt_diasavisobloqueio")))
                        reg.Qt_diasavisobloqueio = reader.GetDecimal(reader.GetOrdinal("qt_diasavisobloqueio"));
                    if (!reader.IsDBNull(reader.GetOrdinal("chave_validade")))
                        reg.Chave_validade = reader.GetString(reader.GetOrdinal("chave_validade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("hash_chave")))
                        reg.Hash_chave = reader.GetString(reader.GetOrdinal("hash_chave"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_sequencial")))
                        reg.Nr_sequencial = reader.GetInt32(reader.GetOrdinal("nr_sequencial"));

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

        public string Gravar(TRegistro_Licenca val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(8);
            hs.Add("@P_CD_LICENCA", val.Cd_licenca);
            hs.Add("@P_DT_ATIVACAO", val.Dt_ativacao);
            hs.Add("@P_DT_ULTIMOACESSO", val.Dt_ultimoacesso);
            hs.Add("@P_QT_DIASVALIDADE", val.Qt_diasvalidade);
            hs.Add("@P_QT_DIASAVISOBLOQUEIO", val.Qt_diasavisobloqueio);
            hs.Add("@P_CHAVE_VALIDADE", val.Chave_validade);
            hs.Add("@P_HASH_CHAVE", val.Hash_chave);
            hs.Add("@P_NR_SEQUENCIAL", val.Nr_sequencial);

            return this.executarProc("IA_DIV_LICENCA", hs);
        }

        public string Excluir(TRegistro_Licenca val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(1);
            hs.Add("@P_CD_LICENCA", val.Cd_licenca);

            return this.executarProc("EXCLUI_DIV_LICENCA", hs);
        }
    }
}
