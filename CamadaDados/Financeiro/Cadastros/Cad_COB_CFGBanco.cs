using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Utils;
using Querys;

namespace CamadaDados.Financeiro.Cadastros
{
    public class TList_Cad_COB_CFGBanco : List<TRegistro_Cad_COB_CFGBanco>
    { }

    public class TRegistro_Cad_COB_CFGBanco
    {
        public string Cd_banco
        { get; set; }
        public string Ds_banco
        { get; set; }
        public string Cd_empresa
        { get; set; }
        public string Nm_empresa
        { get; set; }
        public string Cd_clifor_empresa
        { get; set; }
        public string Nm_clifor_empresa
        { get; set; }
        public string Codigo_cedente
        { get; set; }
        public string Digito_cedente
        { get; set; }
        public string Ano
        { get; set; }
        public decimal Nossonumero
        { get; set; }
        public string Ds_localpagamento
        { get; set; }
        public string Carteira
        { get; set; }
        public string Postocedente
        { get; set; }

        public TRegistro_Cad_COB_CFGBanco()
        {
            this.Cd_banco = string.Empty;
            this.Ds_banco = string.Empty;
            this.Cd_empresa = string.Empty;
            this.Nm_empresa = string.Empty;
            this.Cd_clifor_empresa = string.Empty;
            this.Nm_clifor_empresa = string.Empty;
            this.Codigo_cedente = string.Empty;
            this.Digito_cedente = string.Empty;
            this.Ano = string.Empty;
            this.Nossonumero = 0;
            this.Ds_localpagamento = string.Empty;
            this.Carteira = string.Empty;
            this.Postocedente = string.Empty;
        }
    }

    public class TCD_Cad_COB_CFGBanco : TDataQuery
    {
        private string SqlCodeBusca(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = " ";
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (vNM_Campo.Length == 0)
            {
                sql.AppendLine("select " + strTop + " a.cd_banco, b.ds_banco, a.cd_empresa, ");
                sql.AppendLine("c.nm_empresa, c.cd_clifor, d.nm_clifor, a.codigocedente, ");
                sql.AppendLine("a.digitocedente, a.ano, a.nossonumero, a.ds_localpagamento, ");
                sql.AppendLine("a.carteira, a.postocedente ");
            }
            else
                sql.AppendLine(" Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from tb_cob_cfgbanco a ");
            sql.AppendLine("inner join tb_fin_banco b ");
            sql.AppendLine("on a.cd_banco = b.cd_banco ");
            sql.AppendLine("inner join tb_div_empresa c ");
            sql.AppendLine("on a.cd_empresa = c.cd_empresa ");
            sql.AppendLine("inner join tb_fin_clifor d ");
            sql.AppendLine("on c.cd_clifor = d.cd_clifor ");

            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                    cond = " and ";
                }
            return sql.ToString();
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, ""), null);
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo), null);
        }

        public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
        {
            return this.ExecutarBuscaEscalar(this.SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }

        public TList_Cad_COB_CFGBanco Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            bool podeFecharBco = false;
            TList_Cad_COB_CFGBanco lista = new TList_Cad_COB_CFGBanco();
            if (Banco_Dados == null)
            {
                this.CriarBanco_Dados(false);
                podeFecharBco = true;
            }
            SqlDataReader reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_Cad_COB_CFGBanco reg = new TRegistro_Cad_COB_CFGBanco();
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_Banco"))))
                        reg.Cd_banco = reader.GetString(reader.GetOrdinal("CD_Banco"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("DS_Banco"))))
                        reg.Ds_banco = reader.GetString(reader.GetOrdinal("DS_Banco"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_Empresa"))))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("CD_Empresa"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("NM_Empresa"))))
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("NM_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Clifor")))
                        reg.Cd_clifor_empresa = reader.GetString(reader.GetOrdinal("CD_Clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NM_Clifor")))
                        reg.Nm_clifor_empresa = reader.GetString(reader.GetOrdinal("NM_Clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CodigoCedente")))
                        reg.Codigo_cedente = reader.GetString(reader.GetOrdinal("CodigoCedente"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DigitoCedente")))
                        reg.Digito_cedente = reader.GetString(reader.GetOrdinal("DigitoCedente"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Ano")))
                        reg.Ano = reader.GetString(reader.GetOrdinal("Ano"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NossoNumero")))
                        reg.Nossonumero = reader.GetDecimal(reader.GetOrdinal("NossoNumero"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_LocalPagamento")))
                        reg.Ds_localpagamento = reader.GetString(reader.GetOrdinal("DS_LocalPagamento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Carteira")))
                        reg.Carteira = reader.GetString(reader.GetOrdinal("Carteira"));
                    if (!reader.IsDBNull(reader.GetOrdinal("PostoCedente")))
                        reg.Postocedente = reader.GetString(reader.GetOrdinal("PostoCedente"));

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

        public string GravarCFGBanco(TRegistro_Cad_COB_CFGBanco val)
        {
            Hashtable hs = new Hashtable(9);
            hs.Add("@P_CD_BANCO", val.Cd_banco);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_CODIGOCEDENTE", val.Codigo_cedente);
            hs.Add("@P_DIGITOCEDENTE", val.Digito_cedente);
            hs.Add("@P_ANO", val.Ano);
            hs.Add("@P_NOSSONUMERO", val.Nossonumero);
            hs.Add("@P_DS_LOCALPAGAMENTO", val.Ds_localpagamento);
            hs.Add("@P_CARTEIRA", val.Carteira);
            hs.Add("@P_POSTOCEDENTE", val.Postocedente);

            return this.executarProc("IA_COB_CFGBANCO", hs);
        }

        public string DeletarCFGBanco(TRegistro_Cad_COB_CFGBanco val)
        {
            Hashtable hs = new Hashtable(3);
            hs.Add("@P_CD_BANCO", val.Cd_banco);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_CODIGOCEDENTE", val.Codigo_cedente);

            return this.executarProc("EXCLUI_COB_CFGBANCO", hs);
        }
    }
}
