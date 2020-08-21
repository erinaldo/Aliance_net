using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;
using System.Data.SqlClient;

namespace CamadaDados.Financeiro.Cadastros
{
    public class TList_CadGrupoCF : List<TRegistro_CadGrupoCF>
    { }

    
    public class TRegistro_CadGrupoCF
    {
        
        public string Cd_grupocf
        { get; set; }
        
        public string Ds_grupocf
        { get; set; }
        
        public string Cd_grupocf_pai
        { get; set; }
        
        public string Ds_grupocf_pai
        { get; set; }
        
        public decimal Nivel
        { get; set; }
        private string st_sintetico;
        
        public string St_sintetico
        {
            get { return st_sintetico; }
            set
            {
                st_sintetico = value;
                st_sinteticobool = value.Trim().ToUpper().Equals("S");
            }
        }
        private bool st_sinteticobool;
        
        public bool St_sinteticobool
        {
            get { return st_sinteticobool; }
            set
            {
                st_sinteticobool = value;
                if (value)
                    st_sintetico = "S";
                else
                    st_sintetico = "N";
            }
        }

        private string st_registro;
        public string St_registro
        {
            get { return st_registro; }
            set
            {
                st_registro = value;
                if (value.Trim().ToUpper().Equals("A"))
                    status = "ATIVO";
                else if (value.Trim().ToUpper().Equals("C"))
                    status = "CANCELADO";
            }
        }

        private string status;
        public string Status
        {
            get { return status; }
            set
            {
                status = value;
                if (value.Trim().ToUpper().Equals("ATIVO"))
                    st_registro = "A";
                else if (value.Trim().ToUpper().Equals("CANCELADO"))
                    st_registro = "C";
            }
        }
        
        public bool St_integrar
        { get; set; }

        private string tp_custo;
        public string Tp_custo
        {
            get { return tp_custo; }
            set
            {
                tp_custo = value;
                if (value.Trim().ToUpper().Equals("F"))
                    tp_custo = "F";
                else if (value.Trim().ToUpper().Equals("V"))
                    tp_custo = "V";
            }
        }

        public TList_CadHistorico lHistorico
        { get; set; }
        
        public TList_CadHistorico lHistDel
        { get; set; }

        public TRegistro_CadGrupoCF()
        {
            this.Cd_grupocf = string.Empty;
            this.Ds_grupocf = string.Empty;
            this.Cd_grupocf_pai = string.Empty;
            this.Ds_grupocf_pai = string.Empty;
            this.Nivel = 0;
            this.st_sintetico = "N";
            this.st_sinteticobool = false;
            this.st_registro = "A";
            this.status = "ATIVO";
            this.St_integrar = false;
            this.lHistorico = new TList_CadHistorico();
            this.lHistDel = new TList_CadHistorico();
        }
    }

    public class TCD_CadGrupoCF : TDataQuery
    {
        public TCD_CadGrupoCF()
        { }

        public TCD_CadGrupoCF(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, Int16 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = " TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("Select " + strTop + " a.CD_GrupoCF, Space((a.Nivel - 1)*5) + a.DS_GrupoCF as DS_GrupoCF, ");
                sql.AppendLine("a.nivel, a.st_sintetico, a.cd_grupocf_pai, b.ds_grupocf as ds_grupocf_pai, a.st_registro, a.tp_custo ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("From tb_fin_grupocf a ");
            sql.AppendLine("left outer join tb_fin_grupocf b ");
            sql.AppendLine("on a.cd_grupocf_pai = b.cd_grupocf ");
            sql.AppendLine("where isnull(a.st_registro, 'A') <> 'C' ");
            string cond = " and ";

            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                    sql.AppendLine(cond + " ( " + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");

            sql.AppendLine(" order by a.cd_grupocf, a.nivel ");
            return sql.ToString();
        }

        public override System.Data.DataTable Buscar(TpBusca[] vBusca, short vTop)
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

        public TList_CadGrupoCF Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_CadGrupoCF lista = new TList_CadGrupoCF();
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            SqlDataReader reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_CadGrupoCF reg = new TRegistro_CadGrupoCF();
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_GrupoCF"))))
                        reg.Cd_grupocf = reader.GetString(reader.GetOrdinal("CD_GrupoCF"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("DS_GrupoCF"))))
                        reg.Ds_grupocf = reader.GetString(reader.GetOrdinal("DS_GrupoCF"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_GrupoCF_Pai"))))
                        reg.Cd_grupocf_pai = reader.GetString(reader.GetOrdinal("CD_GrupoCF_Pai"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_GrupoCF_Pai")))
                        reg.Ds_grupocf_pai = reader.GetString(reader.GetOrdinal("DS_GrupoCF_Pai"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("Nivel"))))
                        reg.Nivel = reader.GetDecimal(reader.GetOrdinal("Nivel"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("ST_Sintetico"))))
                        reg.St_sintetico = reader.GetString(reader.GetOrdinal("ST_Sintetico"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ST_Registro")))
                        reg.St_registro = reader.GetString(reader.GetOrdinal("ST_Registro"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Tp_Custo")))
                        reg.Tp_custo = reader.GetString(reader.GetOrdinal("Tp_Custo"));
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

        public string Gravar(TRegistro_CadGrupoCF val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(5);
            hs.Add("@P_CD_GRUPOCF", val.Cd_grupocf);
            hs.Add("@P_DS_GRUPOCF", val.Ds_grupocf.Trim());
            hs.Add("@P_ST_SINTETICO", val.St_sintetico);
            hs.Add("@P_CD_GRUPOCF_PAI", val.Cd_grupocf_pai);
            hs.Add("@P_ST_REGISTRO", val.St_registro);
            hs.Add("@P_TP_CUSTO", val.Tp_custo);

            return this.executarProc("IA_FIN_GRUPOCF", hs);
        }

        public string Excluir(TRegistro_CadGrupoCF val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(1);
            hs.Add("@P_CD_GRUPOCF", val.Cd_grupocf);

            return this.executarProc("EXCLUI_FIN_GRUPOCF", hs);
        }
    }
}
