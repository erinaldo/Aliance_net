using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamadaDados.Fiscal.IDominio
{
    public class TRegistro_IDominioClifor
    {
        public string Tipo
        { get; set; }
        public string Cd_empresa
        { get; set; }
        public string Sg_uf
        { get; set; }
        public decimal Cd_conta
        { get; set; }
        public string Cd_cidade
        { get; set; }
        public string Nm_cliforreduzido
        { get; set; }
        public string Nm_clifor
        { get; set; }
        public string Ds_endereco
        { get; set; }
        public string Numero
        { get; set; }
        public string Cep
        { get; set; }
        public string Cnpj
        { get; set; }
        public string Cpf
        { get; set; }
        public string Insc_estadual
        { get; set; }
        public string Fone
        { get; set; }
        public string St_agropecuaria
        { get; set; }
        public string St_icms
        { get; set; }
        public string Insc_municipal
        { get; set; }
        public string Bairro
        { get; set; }
        public string Cd_pais
        { get; set; }

        public TRegistro_IDominioClifor()
        {
            this.Tipo = string.Empty;
            this.Cd_empresa = string.Empty;
            this.Sg_uf = string.Empty;
            this.Cd_conta = decimal.Zero;
            this.Cd_cidade = string.Empty;
            this.Nm_cliforreduzido = string.Empty;
            this.Nm_clifor = string.Empty;
            this.Ds_endereco = string.Empty;
            this.Numero = string.Empty;
            this.Cep = string.Empty;
            this.Cnpj = string.Empty;
            this.Cpf = string.Empty;
            this.Insc_estadual = string.Empty;
            this.Fone = string.Empty;
            this.St_agropecuaria = string.Empty;
            this.St_icms = string.Empty;
            this.Insc_estadual = string.Empty;
            this.Bairro = string.Empty;
            this.Cd_pais = string.Empty;
        }
    }

    public class TCD_IDominioClifor : TDataQuery
    {
        public TCD_IDominioClifor()
        { }

        public TCD_IDominioClifor(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBuscaClifor(Utils.TpBusca[] vBusca)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("Select distinct e.CD_Empresa_Dominio, d.UF, d.CD_Cidade, ");
            sql.AppendLine("c.NM_Fantasia, c.NM_Clifor, d.DS_Endereco, ");
            sql.AppendLine("d.Numero, d.Cep, c.NR_CGC, c.NR_CPF, ");
            sql.AppendLine("d.Insc_Estadual, d.Fone, b.tp_movimento, ");
            sql.AppendLine("c.ST_Agropecuaria, d.Bairro, d.CD_PAIS ");

            sql.AppendLine("from VTB_FIS_REG50 a ");
            sql.AppendLine("inner join TB_FAT_NotaFiscal b ");
            sql.AppendLine("on a.CD_Empresa = b.CD_Empresa ");
            sql.AppendLine("and a.Nr_lanctofiscal = b.Nr_LanctoFiscal ");
            sql.AppendLine("inner join VTB_FIN_CLIFOR c ");
            sql.AppendLine("on b.CD_Clifor = c.CD_Clifor ");
            sql.AppendLine("inner join VTB_FIN_ENDERECO d ");
            sql.AppendLine("on b.CD_Clifor = d.CD_Clifor ");
            sql.AppendLine("and b.CD_Endereco = d.CD_Endereco ");
            sql.AppendLine("inner join TB_DIV_Empresa e ");
            sql.AppendLine("on a.cd_empresa = e.cd_empresa ");

            string cond = " where ";

            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + ")");
                    cond = " and ";
                }
            return sql.ToString();
        }

        public string SqlCodeBuscaRemetenteDest(Utils.TpBusca[] filtro)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("select distinct e.cd_empresa_dominio, d.UF, d.CD_Cidade, ");
            sql.AppendLine("c.NM_Clifor, d.DS_Endereco, d.Insc_Estadual, ");
            sql.AppendLine("c.NR_CGC, c.NR_CPF ");

            sql.AppendLine("from VTB_FIS_REG70 a ");
            sql.AppendLine("inner join TB_CTR_ConhecimentoFrete b ");
            sql.AppendLine("on a.cd_empresa = b.CD_Empresa ");
            sql.AppendLine("and a.nr_lanctoctr = b.NR_LanctoCTR ");
            sql.AppendLine("inner join VTB_FIN_CLIFOR c ");
            sql.AppendLine("on b.Cd_Remetente = c.CD_Clifor ");
            sql.AppendLine("inner join VTB_FIN_ENDERECO d ");
            sql.AppendLine("on b.Cd_Remetente = d.CD_Clifor ");
            sql.AppendLine("and b.Cd_EndRemetente = d.CD_Endereco ");
            sql.AppendLine("inner join tb_div_empresa e ");
            sql.AppendLine("on a.cd_empresa = e.cd_empresa ");

            string cond = " where ";

            if(filtro != null)
                for (int i = 0; i < filtro.Length; i++)
                {
                    sql.AppendLine(cond + "(" + filtro[i].vNM_Campo + " " + filtro[i].vOperador + " " + filtro[i].vVL_Busca + ")");
                    cond = " and ";
                }

            sql.AppendLine("union ");

            sql.AppendLine("select distinct e.CD_Empresa_Dominio, d.UF, d.CD_Cidade, ");
            sql.AppendLine("c.NM_Clifor, d.DS_Endereco, d.Insc_Estadual, ");
            sql.AppendLine("c.NR_CGC, c.NR_CPF ");

            sql.AppendLine("from VTB_FIS_REG70 a ");
            sql.AppendLine("inner join TB_CTR_ConhecimentoFrete b ");
            sql.AppendLine("on a.cd_empresa = b.CD_Empresa ");
            sql.AppendLine("and a.nr_lanctoctr = b.NR_LanctoCTR ");
            sql.AppendLine("inner join VTB_FIN_CLIFOR c ");
            sql.AppendLine("on b.Cd_Destinatario = c.CD_Clifor ");
            sql.AppendLine("inner join VTB_FIN_ENDERECO d ");
            sql.AppendLine("on b.Cd_Destinatario = d.CD_Clifor ");
            sql.AppendLine("and b.Cd_EndDestinatario = d.CD_Endereco ");
            sql.AppendLine("inner join TB_DIV_Empresa e ");
            sql.AppendLine("on a.cd_empresa = e.cd_empresa ");

            cond = " where ";

            if (filtro != null)
                for (int i = 0; i < filtro.Length; i++)
                {
                    sql.AppendLine(cond + "(" + filtro[i].vNM_Campo + " " + filtro[i].vOperador + " " + filtro[i].vVL_Busca + ")");
                    cond = " and ";
                }
            return sql.ToString();
        }

        public List<TRegistro_IDominioClifor> SelectClifor(Utils.TpBusca[] vBusca)
        {
            List<TRegistro_IDominioClifor> retorno = new List<TRegistro_IDominioClifor>();
            bool st_transacao = false;
            if (Banco_Dados == null)
                st_transacao = this.CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = this.ExecutarBusca(this.SqlCodeBuscaClifor(vBusca));
            try
            {
                while (reader.Read())
                {
                    TRegistro_IDominioClifor reg = new TRegistro_IDominioClifor();
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_movimento")))
                        reg.Tipo = reader.GetString(reader.GetOrdinal("tp_movimento")).Trim().ToUpper().Equals("E") ? "11" : "22";
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa_dominio")))
                        reg.Cd_empresa = reader.GetDecimal(reader.GetOrdinal("cd_empresa_dominio")).ToString();
                    if (!reader.IsDBNull(reader.GetOrdinal("uf")))
                        reg.Sg_uf = reader.GetString(reader.GetOrdinal("uf"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_cidade")))
                        reg.Cd_cidade = reader.GetString(reader.GetOrdinal("cd_cidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NM_Fantasia")))
                        reg.Nm_cliforreduzido = reader.GetString(reader.GetOrdinal("NM_Fantasia"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NM_Clifor")))
                        reg.Nm_clifor = reader.GetString(reader.GetOrdinal("NM_Clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Endereco")))
                        reg.Ds_endereco = reader.GetString(reader.GetOrdinal("DS_Endereco"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Numero")))
                        reg.Numero = reader.GetString(reader.GetOrdinal("Numero"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Cep")))
                        reg.Cep = reader.GetString(reader.GetOrdinal("Cep"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NR_CGC")))
                        reg.Cnpj = reader.GetString(reader.GetOrdinal("NR_CGC"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NR_CPF")))
                        reg.Cpf = reader.GetString(reader.GetOrdinal("NR_CPF"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Insc_Estadual")))
                        reg.Insc_estadual = reader.GetString(reader.GetOrdinal("Insc_Estadual"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Fone")))
                        reg.Fone = reader.GetString(reader.GetOrdinal("Fone"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ST_Agropecuaria")))
                        reg.St_agropecuaria = reader.GetString(reader.GetOrdinal("ST_Agropecuaria"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Bairro")))
                        reg.Bairro = reader.GetString(reader.GetOrdinal("Bairro"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_PAIS")))
                        reg.Cd_pais = reader.GetString(reader.GetOrdinal("CD_PAIS"));

                    retorno.Add(reg);
                }
                return retorno;
            }
            finally
            {
                reader.Close();
                reader.Dispose();
                if (st_transacao)
                    this.deletarBanco_Dados();
            }
        }

        public List<TRegistro_IDominioClifor> SelectRemetenteDest(Utils.TpBusca[] filtro)
        {
            List<TRegistro_IDominioClifor> retorno = new List<TRegistro_IDominioClifor>();
            bool st_transacao = false;
            if (this.Banco_Dados == null)
                st_transacao = this.CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = this.ExecutarBusca(this.SqlCodeBuscaRemetenteDest(filtro));
            try
            {
                while (reader.Read())
                {
                    TRegistro_IDominioClifor reg = new TRegistro_IDominioClifor();
                    reg.Tipo = "33";
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa_dominio")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa_dominio"));
                    if (!reader.IsDBNull(reader.GetOrdinal("uf")))
                        reg.Sg_uf = reader.GetString(reader.GetOrdinal("uf"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_cidade")))
                        reg.Cd_cidade = reader.GetString(reader.GetOrdinal("cd_cidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NM_Clifor")))
                        reg.Nm_clifor = reader.GetString(reader.GetOrdinal("NM_Clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Endereco")))
                        reg.Ds_endereco = reader.GetString(reader.GetOrdinal("DS_Endereco"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NR_CGC")))
                        reg.Cnpj = reader.GetString(reader.GetOrdinal("NR_CGC"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NR_CPF")))
                        reg.Cpf = reader.GetString(reader.GetOrdinal("NR_CPF"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Insc_Estadual")))
                        reg.Insc_estadual = reader.GetString(reader.GetOrdinal("Insc_Estadual"));

                    retorno.Add(reg);
                }
                return retorno;
            }
            finally
            {
                reader.Close();
                reader.Dispose();
                if (st_transacao)
                    this.deletarBanco_Dados();
            }
        }
    }
}
