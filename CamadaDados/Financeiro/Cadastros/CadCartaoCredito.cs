using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;
using System.Data.SqlClient;
using System.Collections;
using System.Data;

namespace CamadaDados.Financeiro.Cadastros
{
    public class TList_CadCartaoCredito : List<TRegistro_CadCartaoCredito>
    { }

    public class TRegistro_CadCartaoCredito
    {
        private decimal? id_cartao;

        public decimal? ID_Cartao
        {
            get { return id_cartao; }
            set
            {
                id_cartao = value;
                id_cartaostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_cartaostr;

        public string Id_cartaostr
        {
            get { return id_cartaostr; }
            set
            {
                id_cartaostr = value;
                try
                {
                    id_cartao = Convert.ToDecimal(value);
                }
                catch
                { id_cartao = null; }
            }
        }

        public string Ds_cartao
        { get; set; }
        private decimal? id_bandeira;

        public decimal? ID_Bandeira
        {
            get { return id_bandeira; }
            set
            {
                id_bandeira = value;
                id_bandeirastr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_bandeirastr;

        public string Id_bandeirastr
        {
            get
            {
                return id_bandeirastr;
            }
            set
            {
                id_bandeirastr = value;
                try
                {
                    id_bandeira = Convert.ToDecimal(value);
                }
                catch
                {
                    id_bandeira = null;
                }
            }
        }

        public string Ds_bandeira
        { get; set; }

        public string NR_Cartao
        { get; set; }
        private DateTime? dt_validade;

        public DateTime? DT_Validade
        {
            get { return dt_validade; }
            set
            {
                dt_validade = value;
                dt_validadestr = value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty;
            }
        }
        private string dt_validadestr;

        public string Dt_validadestr
        {
            get
            {
                try
                {
                    return Convert.ToDateTime(dt_validadestr).ToString("dd/MM/yyyy");
                }
                catch
                { return string.Empty; }
            }
            set
            {
                dt_validadestr = value;
                try
                {
                    dt_validade = Convert.ToDateTime(value);
                }
                catch
                { dt_validade = null; }
            }
        }

        public string NomeUsuario
        { get; set; }

        public decimal PC_JuroCompras
        { get; set; }

        public decimal PC_JuroSaques
        { get; set; }

        public string DS_Observacao
        { get; set; }
        private string st_registro;

        public string ST_Registro
        {
            get { return st_registro; }
            set
            {
                st_registro = value;
                st_registrobool = value.Trim().ToUpper().Equals("A");
            }
        }
        private bool st_registrobool;

        public bool ST_Registrobool
        {
            get { return st_registrobool; }
            set
            {
                st_registrobool = value;
                st_registro = value ? "A" : "C";

            }
        }
        private string st_prepago;

        public string ST_prepago
        {
            get { return st_prepago; }
            set
            {
                st_prepago = value;
                st_prepagobool = value.Trim().ToUpper().Equals("S");
            }
        }
        private bool st_prepagobool;

        public bool ST_prepagobool
        {
            get { return st_prepagobool; }
            set
            {
                st_prepagobool = value;
                st_prepago = value ? "S" : "N";

            }
        }
        public TRegistro_CadCartaoCredito()
        {
            this.ID_Cartao = null;
            this.id_cartaostr = string.Empty;
            this.Ds_cartao = string.Empty;
            this.id_bandeira = null;
            this.id_bandeirastr = string.Empty;
            this.Ds_bandeira = string.Empty;
            this.NR_Cartao = string.Empty;
            this.dt_validade = null;
            this.dt_validadestr = string.Empty;
            this.NomeUsuario = string.Empty;
            this.PC_JuroCompras = decimal.Zero;
            this.PC_JuroSaques = decimal.Zero;
            this.DS_Observacao = string.Empty;
            this.st_prepago = "N";
            this.st_prepagobool = false;
            this.st_registro = "A";
            this.st_registrobool = true;
        }
    }

    public class TCD_CadCartaoCredito : TDataQuery
        {
            public TCD_CadCartaoCredito()
            { }

            public TCD_CadCartaoCredito(BancoDados.TObjetoBanco banco)
            { this.Banco_Dados = banco; }

            private string SqlCodeBusca(TpBusca[] vBusca, Int16 vTop, string vNM_Campo)
            {
                string strTop = string.Empty;

                if (vTop > 0)
                    strTop = "TOP " + Convert.ToString(vTop);

                StringBuilder sql = new StringBuilder();
                if (string.IsNullOrEmpty(vNM_Campo))
                {
                    sql.AppendLine("SELECT " + strTop + " a.ID_Cartao, a.ID_Bandeira , a.NR_Cartao, a.ds_cartao, ");
                    sql.AppendLine("a.DT_Validade, a.NomeUsuario, b.ds_bandeira, ");
                    sql.AppendLine("a.PC_JuroCompras, a.PC_JuroSaques, a.DS_Observacao, a.ST_PrePago, a.ST_Registro ");                 
                }
                else
                    sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

                sql.AppendLine("FROM TB_FIN_CartaoCredito a ");
                sql.AppendLine("INNER JOIN TB_FIN_BandeiraCartao b ");
                sql.AppendLine("ON a.ID_Bandeira = b.ID_Bandeira ");
                
                string cond = " where ";

                if (vBusca != null)
                    for (int i = 0; i < (vBusca.Length); i++)
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

            public TList_CadCartaoCredito Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
            {
                TList_CadCartaoCredito lista = new TList_CadCartaoCredito();
                bool podeFecharBco = false;
                if (Banco_Dados == null)
                    podeFecharBco = this.CriarBanco_Dados(false);
                SqlDataReader reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
                try
                {
                    while (reader.Read())
                    {
                        TRegistro_CadCartaoCredito reg = new TRegistro_CadCartaoCredito();
                        if (!(reader.IsDBNull(reader.GetOrdinal("ID_Cartao"))))
                            reg.ID_Cartao = reader.GetDecimal(reader.GetOrdinal("ID_Cartao"));
                        if (!reader.IsDBNull(reader.GetOrdinal("ds_cartao")))
                            reg.Ds_cartao = reader.GetString(reader.GetOrdinal("ds_cartao"));
                        if (!(reader.IsDBNull(reader.GetOrdinal("ID_Bandeira"))))
                            reg.ID_Bandeira = reader.GetDecimal(reader.GetOrdinal("ID_Bandeira"));
                        if (!reader.IsDBNull(reader.GetOrdinal("DS_Bandeira")))
                            reg.Ds_bandeira = reader.GetString(reader.GetOrdinal("DS_Bandeira"));
                        if (!(reader.IsDBNull(reader.GetOrdinal("NR_Cartao"))))
                            reg.NR_Cartao = reader.GetString(reader.GetOrdinal("NR_Cartao"));
                        if (!(reader.IsDBNull(reader.GetOrdinal("DT_Validade"))))
                            reg.DT_Validade = reader.GetDateTime(reader.GetOrdinal("DT_Validade"));
                        if (!(reader.IsDBNull(reader.GetOrdinal("NomeUsuario"))))
                            reg.NomeUsuario = reader.GetString(reader.GetOrdinal("NomeUsuario"));
                        if (!(reader.IsDBNull(reader.GetOrdinal("PC_JuroCompras"))))
                            reg.PC_JuroCompras = reader.GetDecimal(reader.GetOrdinal("PC_JuroCompras"));
                        if (!(reader.IsDBNull(reader.GetOrdinal("PC_JuroSaques"))))
                            reg.PC_JuroSaques = reader.GetDecimal(reader.GetOrdinal("PC_JuroSaques"));
                        if (!(reader.IsDBNull(reader.GetOrdinal("DS_Observacao"))))
                            reg.DS_Observacao = reader.GetString(reader.GetOrdinal("DS_Observacao"));
                        if (!(reader.IsDBNull(reader.GetOrdinal("ST_PrePago"))))
                            reg.ST_prepago = reader.GetString(reader.GetOrdinal("ST_PrePago"));
                        if (!(reader.IsDBNull(reader.GetOrdinal("ST_Registro"))))
                            reg.ST_Registro = reader.GetString(reader.GetOrdinal("ST_Registro"));

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

            public string GravarCartaoCredito(TRegistro_CadCartaoCredito val)
            {
                Hashtable hs = new Hashtable(11);
                hs.Add("@P_ID_CARTAO", val.ID_Cartao);
                hs.Add("@P_DS_CARTAO", val.Ds_cartao);
                hs.Add("@P_ID_BANDEIRA", val.ID_Bandeira);
                hs.Add("@P_NR_CARTAO", val.NR_Cartao);
                hs.Add("@P_DT_VALIDADE", val.DT_Validade);
                hs.Add("@P_NOMEUSUARIO", val.NomeUsuario);
                hs.Add("@P_PC_JUROCOMPRAS", val.PC_JuroCompras);
                hs.Add("@P_PC_JUROSAQUES", val.PC_JuroSaques);
                hs.Add("@P_DS_OBSERVACAO", val.DS_Observacao);
                hs.Add("@P_ST_PREPAGO", val.ST_prepago);
                hs.Add("@P_ST_REGISTRO", val.ST_Registro);

                return this.executarProc("IA_FIN_CARTAOCREDITO", hs);
            }

            public string DeletarCartaoCredito(TRegistro_CadCartaoCredito val)
            {
                Hashtable hs = new Hashtable(1);
                hs.Add("@P_ID_CARTAO", val.ID_Cartao);

                return this.executarProc("EXCLUI_FIN_CARTAOCREDITO", hs);
            }
        }
}
