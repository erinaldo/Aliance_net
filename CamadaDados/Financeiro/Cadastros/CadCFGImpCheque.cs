using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamadaDados.Financeiro.Cadastros
{
    public class TList_CFGImpCheque : List<TRegistro_CFGImpCheque>
    { }

    
    public class TRegistro_CFGImpCheque
    {
        
        public string Cd_banco
        { get; set; }
        
        public string Ds_banco
        { get; set; }
        private decimal? id_campo;
        
        public decimal? Id_campo
        {
            get { return id_campo; }
            set
            {
                id_campo = value;
                id_campostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_campostr;
        
        public string Id_campostr
        {
            get { return id_campostr; }
            set
            {
                id_campostr = value;
                try
                {
                    id_campo = decimal.Parse(value);
                }
                catch
                { id_campo = null; }
            }
        }
        
        public string Nm_campo
        { get; set; }
        public string Nome_campo
        {
            get
            {
                if (Nm_campo.Trim().ToUpper().Equals("VL_TITULO"))
                    return "VALOR CHEQUE";
                else if (Nm_campo.Trim().ToUpper().Equals("VL_EXTENSO"))
                    return "VALOR EXTENSO";
                else if (Nm_campo.Trim().ToUpper().Equals("VL_EXTENSO1"))
                    return "VALOR EXTENSO 1";
                else if (Nm_campo.Trim().ToUpper().Equals("DS_CIDADE"))
                    return "CIDADE";
                else if (Nm_campo.Trim().ToUpper().Equals("DIA"))
                    return "DIA";
                else if (Nm_campo.Trim().ToUpper().Equals("MES"))
                    return "MES";
                else if (Nm_campo.Trim().ToUpper().Equals("ANO"))
                    return "ANO";
                else if (Nm_campo.Trim().ToUpper().Equals("DT_PARA"))
                    return "DATA VENCIMENTO";
                else if (Nm_campo.Trim().ToUpper().Equals("NOMINAL"))
                    return "NOMINAL";
                else if (Nm_campo.Trim().ToUpper().Equals("NR_CHEQUE"))
                    return "Nº CHEQUE";
                else return string.Empty;
            }
        }
        
        public decimal Linha
        { get; set; }
        
        public decimal Coluna
        { get; set; }
        
        public decimal Tamanho
        { get; set; }
        private string tp_alinhamento;
        
        public string Tp_alinhamento
        {
            get { return tp_alinhamento; }
            set
            {
                tp_alinhamento = value;
                if (value.Trim().ToUpper().Equals("E"))
                    tipo_alinhamento = "ESQUERDA";
                else if(value.Trim().ToUpper().Equals("D"))
                    tipo_alinhamento = "DIREITA";
            }
        }
        private string tipo_alinhamento;
        
        public string Tipo_alinhamento
        {
            get { return tipo_alinhamento; }
            set
            {
                tipo_alinhamento = value;
                if (value.Trim().ToUpper().Equals("ESQUERDA"))
                    tp_alinhamento = "E";
                else if (value.Trim().ToUpper().Equals("DIREITA"))
                    tp_alinhamento = "D";
            }
        }
        private string tp_fonte;
        
        public string Tp_fonte
        {
            get { return tp_fonte; }
            set
            {
                tp_fonte = value;
                if (value.Trim().ToUpper().Equals("N"))
                    tipo_fonte = "NORMAL";
                else if (value.Trim().ToUpper().Equals("E"))
                    tipo_fonte = "EXPANDIDO";
                else if (value.Trim().ToUpper().Equals("C"))
                    tipo_fonte = "COMPRIMIDO";
            }
        }
        private string tipo_fonte;
        
        public string Tipo_fonte
        {
            get { return tipo_fonte; }
            set
            {
                tipo_fonte = value;
                if (value.Trim().ToUpper().Equals("NORMAL"))
                    tp_fonte = "N";
                else if (value.Trim().ToUpper().Equals("EXPANDIDO"))
                    tp_fonte = "E";
                else if (value.Trim().ToUpper().Equals("COMPRIMIDO"))
                    tp_fonte = "C";
            }
        }
        private string st_negrito;
        
        public string St_negrito
        {
            get { return st_negrito; }
            set
            {
                st_negrito = value;
                st_negritobool = value.Trim().ToUpper().Equals("S");
            }
        }
        private bool st_negritobool;
        
        public bool St_negritobool
        {
            get { return st_negritobool; }
            set
            {
                st_negritobool = value;
                st_negrito = value ? "S" : "N";
            }
        }

        public TRegistro_CFGImpCheque()
        {
            this.Cd_banco = string.Empty;
            this.Ds_banco = string.Empty;
            this.id_campo = null;
            this.id_campostr = string.Empty;
            this.Nm_campo = string.Empty;
            this.Linha = decimal.Zero;
            this.Coluna = decimal.Zero;
            this.Tamanho = decimal.Zero;
            this.tp_alinhamento = string.Empty;
            this.tipo_alinhamento = string.Empty;
            this.tp_fonte = "N";
            this.tipo_fonte = "NORMAL";
            this.st_negrito = "N";
            this.st_negritobool = false;
        }
    }

    public class TCD_CFGImpCheque : TDataQuery
    {
        public TCD_CFGImpCheque()
        { }

        public TCD_CFGImpCheque(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("select " + strTop + " a.cd_banco, b.ds_banco, a.id_campo, ");
                sql.AppendLine("a.nm_campo, a.linha, a.coluna, a.tamanho, a.tp_alinhamento, ");
                sql.AppendLine("a.tp_fonte, a.st_negrito ");
            }
            else
                sql.AppendLine(" Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from tb_fin_cfgimpcheque a ");
            sql.AppendLine("inner join tb_fin_banco b ");
            sql.AppendLine("on a.cd_banco = b.cd_banco ");

            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                    cond = " and ";
                }
            sql.AppendLine("order by a.cd_banco, a.linha, a.coluna ");
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

        public TList_CFGImpCheque Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            bool podeFecharBco = false;
            TList_CFGImpCheque lista = new TList_CFGImpCheque();
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_CFGImpCheque reg = new TRegistro_CFGImpCheque();
                    if (!(reader.IsDBNull(reader.GetOrdinal("cd_banco"))))
                        reg.Cd_banco = reader.GetString(reader.GetOrdinal("cd_banco"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("DS_Banco"))))
                        reg.Ds_banco = reader.GetString(reader.GetOrdinal("DS_Banco"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("ID_Campo"))))
                        reg.Id_campo = reader.GetDecimal(reader.GetOrdinal("ID_Campo"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("NM_Campo"))))
                        reg.Nm_campo = reader.GetString(reader.GetOrdinal("NM_Campo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Linha")))
                        reg.Linha = reader.GetDecimal(reader.GetOrdinal("Linha"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Coluna")))
                        reg.Coluna = reader.GetDecimal(reader.GetOrdinal("Coluna"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Tamanho")))
                        reg.Tamanho = reader.GetDecimal(reader.GetOrdinal("Tamanho"));
                    if (!reader.IsDBNull(reader.GetOrdinal("TP_Alinhamento")))
                        reg.Tp_alinhamento = reader.GetString(reader.GetOrdinal("TP_Alinhamento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_fonte")))
                        reg.Tp_fonte = reader.GetString(reader.GetOrdinal("tp_fonte"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_negrito")))
                        reg.St_negrito = reader.GetString(reader.GetOrdinal("st_negrito"));

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

        public string Gravar(TRegistro_CFGImpCheque val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(9);
            hs.Add("@P_CD_BANCO", val.Cd_banco);
            hs.Add("@P_ID_CAMPO", val.Id_campo);
            hs.Add("@P_NM_CAMPO", val.Nm_campo);
            hs.Add("@P_LINHA", val.Linha);
            hs.Add("@P_COLUNA", val.Coluna);
            hs.Add("@P_TAMANHO", val.Tamanho);
            hs.Add("@P_TP_ALINHAMENTO", val.Tp_alinhamento);
            hs.Add("@P_TP_FONTE", val.Tp_fonte);
            hs.Add("@P_ST_NEGRITO", val.St_negrito);

            return this.executarProc("IA_FIN_CFGIMPCHEQUE", hs);
        }

        public string Excluir(TRegistro_CFGImpCheque val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(2);
            hs.Add("@P_CD_BANCO", val.Cd_banco);
            hs.Add("@P_ID_CAMPO", val.Id_campo);

            return this.executarProc("EXCLUI_FIN_CFGIMPCHEQUE", hs);
        }
    }
}
