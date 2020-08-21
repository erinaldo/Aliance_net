using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;
using System.Data.SqlClient;

namespace CamadaDados.Fiscal.Sintegra
{
    public class Tipo10_11
    {
        public int Count
        { get; set; }
        public Finalidades Finalidade
        { get; set; }
        public string Cnpj
        { get; set; }
        public DateTime? Data_inicial
        { get; set; }
        public DateTime? Data_final
        { get; set; }
        public IdentificacaoEstruturas Codigo_convenio
        { get; set; }
        public IdentificacaoNaturezaOperacoes Codigo_identificacao
        { get; set; }
        private string insc_estadual;
        public string Insc_estadual
        {
            get
            {
                if (insc_estadual.Trim().ToUpper() != "ISENTO")
                    return insc_estadual.Trim().SoNumero();
                else
                    return insc_estadual;
            }
            set
            {
                insc_estadual = value;
            }
        }
        public string Nome_contribuinte
        { get; set; }
        public string Municipio_contribuinte
        { get; set; }
        public string Uf
        { get; set; }

        public string Logradouro
        { get; set; }
        public string Numero
        { get; set; }
        public string Complemento
        { get; set; }
        public string Bairro
        { get; set; }
        public string Cep
        { get; set; }
        public string Contato
        { get; set; }
        public string Fone
        { get; set; }

        public Tipo10_11()
        {
            this.Count = 0;
            this.Finalidade = Finalidades.NORMAL;
            this.Cnpj = string.Empty;
            this.Data_inicial = null;
            this.Data_final = null;
            this.Codigo_convenio = IdentificacaoEstruturas.ICMS_CONVENIO_5795_76_03;
            this.Codigo_identificacao = IdentificacaoNaturezaOperacoes.TOTALIDADE_OPERACOES;
            this.insc_estadual = string.Empty;
            this.Nome_contribuinte = string.Empty;
            this.Municipio_contribuinte = string.Empty;
            this.Uf = string.Empty;
            this.Logradouro = string.Empty;
            this.Numero = string.Empty;
            this.Complemento = string.Empty;
            this.Bairro = string.Empty;
            this.Cep = string.Empty;
            this.Contato = string.Empty;
            this.Fone = string.Empty;
        }
    }

    public class TCD_Tipo10_11 : TDataQuery
    {
        public TCD_Tipo10_11() { }

        public TCD_Tipo10_11(BancoDados.TObjetoBanco banco) { this.Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, Int16 vTop, string vNM_Campo)
        {
            string strTop = " ";
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (vNM_Campo.Trim().Equals(string.Empty))
            {
                sql.AppendLine("Select " + strTop + " a.nm_empresa, a.cnpj, a.insc_estadual, ");
                sql.AppendLine("a.ds_cidade, a.uf, a.ds_endereco, ");
                sql.AppendLine("a.numero, a.ds_complemento, a.bairro, ");
                sql.AppendLine("a.cep, a.nm_contato, a.fone ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from VTB_FIS_REG10_11 a ");
            string cond = " where ";

            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + ")");
            return sql.ToString();
        }

        public Tipo10_11 Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            Tipo10_11 retorno = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
            {
                this.CriarBanco_Dados(false);
                podeFecharBco = true;
            }
            SqlDataReader reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    retorno = new Tipo10_11();
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_empresa")))
                        retorno.Nome_contribuinte = reader.GetString(reader.GetOrdinal("nm_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cnpj")))
                        retorno.Cnpj = reader.GetString(reader.GetOrdinal("cnpj"));
                    if (!reader.IsDBNull(reader.GetOrdinal("insc_estadual")))
                        retorno.Insc_estadual = reader.GetString(reader.GetOrdinal("insc_estadual"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_cidade")))
                        retorno.Municipio_contribuinte = reader.GetString(reader.GetOrdinal("ds_cidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("uf")))
                        retorno.Uf = reader.GetString(reader.GetOrdinal("uf"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_endereco")))
                        retorno.Logradouro = reader.GetString(reader.GetOrdinal("ds_endereco"));
                    if (!reader.IsDBNull(reader.GetOrdinal("numero")))
                        retorno.Numero = reader.GetString(reader.GetOrdinal("numero"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_complemento")))
                        retorno.Complemento = reader.GetString(reader.GetOrdinal("ds_complemento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("bairro")))
                        retorno.Bairro = reader.GetString(reader.GetOrdinal("bairro"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cep")))
                        retorno.Cep = reader.GetString(reader.GetOrdinal("cep"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_contato")))
                        retorno.Contato = reader.GetString(reader.GetOrdinal("nm_contato"));
                    if (!reader.IsDBNull(reader.GetOrdinal("fone")))
                        retorno.Fone = reader.GetString(reader.GetOrdinal("fone"));
                }
                return retorno;
            }
            finally
            {
                reader.Close();
                reader.Dispose();
                if (podeFecharBco)
                    this.deletarBanco_Dados();
            }
        }
    }
}
