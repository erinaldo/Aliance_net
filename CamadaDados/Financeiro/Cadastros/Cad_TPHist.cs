using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Utils;

namespace CamadaDados.Financeiro.Cadastros
{
    public class TList_TPHist : List<TRegistro_TPHist>
    { }

    
    public class TRegistro_TPHist
    {
        
        public string Tp_hist
        { get; set; }
        
        public string Ds_tphist
        { get; set; }

        private string st_caixagerencial;
        
        public string St_caixagerencial
        {
            get { return st_caixagerencial; }
            set
            {
                st_caixagerencial = value;
                st_caixagerencialbool = value.ToUpper().Trim().Equals("S");
            }
        }
        private bool st_caixagerencialbool;
        
        public bool St_caixagerencialbool
        {
            get { return st_caixagerencialbool; }
            set
            {
                st_caixagerencialbool = value;
                if (value)
                    st_caixagerencial = "S";
                else
                    st_caixagerencial = "N";
            }
        }
        private string st_financeiro;
        
        public string St_financeiro
        {
            get { return st_financeiro; }
            set
            {
                st_financeiro = value;
                st_financeirobool = value.Trim().ToUpper().Equals("S");
            }
        }
        private bool st_financeirobool;
        
        public bool St_financeirobool
        {
            get { return st_financeirobool; }
            set
            {
                st_financeirobool = value;
                if (value)
                    st_financeiro = "S";
                else
                    st_financeiro = "N";
            }
        }
        private string st_quitacoes;
        
        public string St_quitacoes
        {
            get { return st_quitacoes; }
            set
            {
                st_quitacoes = value;
                st_quitacoesbool = value.ToUpper().Trim().Equals("S");
            }
        }
        private bool st_quitacoesbool;
        
        public bool St_quitacoesbool
        {
            get { return st_quitacoesbool; }
            set
            {
                st_quitacoesbool = value;
                if (value)
                    st_quitacoes = "S";
                else
                    st_quitacoes = "N";
            }
        }
        private string st_faturamento;
        
        public string St_faturamento
        {
            get { return st_faturamento; }
            set
            {
                st_faturamento = value;
                st_faturamentobool = value.Trim().ToUpper().Equals("S");
            }
        }
        private bool st_faturamentobool;
        
        public bool St_faturamentobool
        {
            get { return st_faturamentobool; }
            set
            {
                st_faturamentobool = value;
                if (value)
                    st_faturamento = "S";
                else
                    st_faturamento = "N";
            }
        }
        
        public string St_registro
        { get; set; }
        
        public TRegistro_TPHist()
        {
            this.Tp_hist = string.Empty;
            this.Ds_tphist = string.Empty;
            this.st_caixagerencial = "N";
            this.st_caixagerencialbool = false;
            this.st_financeiro = "N";
            this.st_financeirobool = false;
            this.st_quitacoes = "N";
            this.st_quitacoesbool = false;
            this.st_faturamento = "N";
            this.st_faturamentobool = false;
            this.St_registro = "A";
        }
    }

    public class TCD_TPHist : TDataQuery
    {
        public TCD_TPHist()
        { }

        public TCD_TPHist(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, Int16 vTop, string vNM_Campo)
        {
            string cond = " "; string strTop;
            int i;
            strTop = " ";

            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (vNM_Campo.Trim().Equals(""))
            {

                sql.AppendLine("select "+strTop+" tp_hist, ds_tphist, st_caixagerencial, ");
                sql.AppendLine("st_financeiro, st_quitacoes, st_faturamento, st_registro ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from tb_fin_tphist ");
            cond = " where ";

            if (vBusca != null)
                for (i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + ")");
                    cond = " and ";
                }
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

        public TList_TPHist Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_TPHist lista = new TList_TPHist();
            SqlDataReader reader;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
            {
                this.CriarBanco_Dados(false);
                podeFecharBco = true;
            }
            reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_TPHist reg = new TRegistro_TPHist();
                    if (!(reader.IsDBNull(reader.GetOrdinal("TP_Hist"))))
                        reg.Tp_hist = reader.GetString(reader.GetOrdinal("TP_Hist"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("DS_TPHist"))))
                        reg.Ds_tphist = reader.GetString(reader.GetOrdinal("DS_TPHist"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("ST_CaixaGerencial"))))
                        reg.St_caixagerencial = reader.GetString(reader.GetOrdinal("ST_CaixaGerencial"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("ST_Financeiro"))))
                        reg.St_financeiro = reader.GetString(reader.GetOrdinal("ST_Financeiro"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("ST_Quitacoes"))))
                        reg.St_quitacoes = reader.GetString(reader.GetOrdinal("ST_Quitacoes"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("ST_Faturamento"))))
                        reg.St_faturamento = reader.GetString(reader.GetOrdinal("ST_Faturamento"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("ST_Registro"))))
                        reg.St_registro = reader.GetString(reader.GetOrdinal("ST_Registro"));

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

        public string GravarTPHist(TRegistro_TPHist val)
        {
            Hashtable hs = new Hashtable(7);
            hs.Add("@P_TP_HIST", val.Tp_hist);
            hs.Add("@P_DS_TPHIST", val.Ds_tphist);
            hs.Add("@P_ST_CAIXAGERENCIAL", val.St_caixagerencial);
            hs.Add("@P_ST_FINANCEIRO", val.St_financeiro);
            hs.Add("@P_ST_QUITACOES", val.St_quitacoes);
            hs.Add("@P_ST_FATURAMENTO", val.St_faturamento);
            hs.Add("@P_ST_REGISTRO", val.St_registro);

            return this.executarProc("IA_FIN_TPHIST", hs);
        }

        public string DeletarTPHist(TRegistro_TPHist val)
        {
            Hashtable hs = new Hashtable(1);
            hs.Add("@P_TP_HIST", val.Tp_hist);

            return this.executarProc("EXCLUI_FIN_TPHIST", hs);
        }
    }
}
