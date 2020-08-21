using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamadaDados.Financeiro.Cadastros
{
    public class TList_PracaCobranca : List<TRegistro_PracaCobranca>
    { }

    
    public class TRegistro_PracaCobranca
    {
        private decimal? cd_praca;
        
        public decimal? Cd_praca
        {
            get { return cd_praca; }
            set
            {
                cd_praca = value;
                cd_pracastr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string cd_pracastr;
        
        public string Cd_pracastr
        {
            get { return cd_pracastr; }
            set
            {
                cd_pracastr = value;
                try
                {
                    cd_praca = decimal.Parse(value);
                }
                catch
                { cd_praca = null; }
            }
        }
        
        public string Cd_cidade
        { get; set; }
        
        public string Ds_cidade
        { get; set; }
        
        public string Uf
        { get; set; }
        
        public string Cd_banco
        { get; set; }
        
        public string Ds_banco
        { get; set; }
        
        public string St_registro
        { get; set; }
        public string Status
        {
            get
            {
                if (St_registro.Trim().ToUpper().Equals("A"))
                    return "ATIVA";
                else if (St_registro.Trim().ToUpper().Equals("I"))
                    return "INATIVA";
                else return string.Empty;
            }
        }

        public TRegistro_PracaCobranca()
        {
            this.cd_praca = null;
            this.cd_pracastr = string.Empty;
            this.Cd_cidade = string.Empty;
            this.Ds_cidade = string.Empty;
            this.Uf = string.Empty;
            this.Cd_banco = string.Empty;
            this.Ds_banco = string.Empty;
            this.St_registro = "A";
        }
    }

    public class TCD_PracaCobranca : TDataQuery
    {
        public TCD_PracaCobranca()
        { }

        public TCD_PracaCobranca(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int16 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = " TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("select " + strTop + " a.cd_praca, a.cd_cidade, ");
                sql.AppendLine("b.ds_cidade, c.uf, a.st_registro, a.cd_banco, d.ds_banco ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from tb_cob_pracacobranca a ");
            sql.AppendLine("inner join tb_fin_cidade b ");
            sql.AppendLine("on a.cd_cidade = b.cd_cidade ");
            sql.AppendLine("inner join tb_fin_uf c ");
            sql.AppendLine("on b.cd_uf = c.cd_uf ");
            sql.AppendLine("inner join tb_fin_banco d ");
            sql.AppendLine("on a.cd_banco = d.cd_banco ");

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

        public TList_PracaCobranca Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_PracaCobranca lista = new TList_PracaCobranca();
            System.Data.SqlClient.SqlDataReader reader;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_PracaCobranca reg = new TRegistro_PracaCobranca();
                    if (!(reader.IsDBNull(reader.GetOrdinal("cd_praca"))))
                        reg.Cd_praca = reader.GetDecimal(reader.GetOrdinal("cd_praca"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("cd_cidade"))))
                        reg.Cd_cidade = reader.GetString(reader.GetOrdinal("cd_cidade"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("ds_cidade"))))
                        reg.Ds_cidade = reader.GetString(reader.GetOrdinal("ds_cidade"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("uf"))))
                        reg.Uf = reader.GetString(reader.GetOrdinal("uf"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_banco")))
                        reg.Cd_banco = reader.GetString(reader.GetOrdinal("cd_banco"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_banco")))
                        reg.Ds_banco = reader.GetString(reader.GetOrdinal("ds_banco"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("st_registro"))))
                        reg.St_registro = reader.GetString(reader.GetOrdinal("st_registro"));

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

        public string Gravar(TRegistro_PracaCobranca val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(4);
            hs.Add("@P_CD_PRACA", val.Cd_praca);
            hs.Add("@P_CD_CIDADE", val.Cd_cidade);
            hs.Add("@P_CD_BANCO", val.Cd_banco);
            hs.Add("@P_ST_REGISTRO", val.St_registro);

            return this.executarProc("IA_COB_PRACACOBRANCA", hs);
        }

        public string Excluir(TRegistro_PracaCobranca val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(3);
            hs.Add("@P_CD_PRACA", val.Cd_praca);
            hs.Add("@P_CD_CIDADE", val.Cd_cidade);
            hs.Add("@P_CD_BANCO", val.Cd_banco);

            return this.executarProc("EXCLUI_COB_PRACACOBRANCA", hs);
        }
    }
}
