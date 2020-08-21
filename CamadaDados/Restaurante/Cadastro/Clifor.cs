using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using CamadaDados.Financeiro.Cadastros;
using Utils;

namespace CamadaDados.Restaurante.Cadastro
{
    public class TList_Clifor : List<TRegistro_Clifor> { }

    public class TRegistro_Clifor : TRegistro_CadClifor
    {
        public string nr_cartao { get; set; } = string.Empty;
        public string celular { get; set; } = string.Empty;
        public string Cd_Endereco { get; set; } = string.Empty;
        public string endereco { get; set; } = string.Empty;
        public string bairro { get; set; } = string.Empty;
        public string cd_cidade { get; set; } = string.Empty;
        public string ds_cidade { get; set; } = string.Empty;
        public string cep { get; set; } = string.Empty;
        public string obs { get; set; } = string.Empty;
        public string numero { get; set; } = string.Empty;
    }

    public class TCD_Clifor : TDataQuery
    {
        public TCD_Clifor()
        { }

        public TCD_Clifor(BancoDados.TObjetoBanco banco)
        { Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("select " + strTop + " a.cartao_fidelidade, a.cd_clifor, a.Cd_Endereco, ")
                    .AppendLine("a.celular, a.nm_clifor, a.cd_Cidade, a.ds_cidade, a.ds_endereco, a.numero, ")
                    .AppendLine("a.proximo, a.bairro, a.cep, a.vl_renda, a.DT_Nascimento, a.tp_sexo ");
            }
            else
                sql.AppendLine(" Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from vtb_res_clifor a ");
            

            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                    cond = " and ";
                }
            sql.AppendLine("order by a.nm_clifor, a.cd_clifor ");

            return sql.ToString();
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, ""), null);
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo), null);
        }

        public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
        {
            return ExecutarBuscaEscalar(SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }

        public TList_Clifor Select(TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            bool podeFecharBco = false;
            TList_Clifor lista = new TList_Clifor();
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            SqlDataReader reader = ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_Clifor reg = new TRegistro_Clifor();
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_Clifor"))))
                        reg.Cd_clifor = reader.GetString(reader.GetOrdinal("CD_Clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NM_Clifor")))
                        reg.Nm_clifor = reader.GetString(reader.GetOrdinal("NM_Clifor")); 
                    if (!reader.IsDBNull(reader.GetOrdinal("Cd_Endereco")))
                        reg.Cd_Endereco = reader.GetString(reader.GetOrdinal("Cd_Endereco"));  
                    if (!reader.IsDBNull(reader.GetOrdinal("celular")))
                        reg.celular = reader.GetString(reader.GetOrdinal("celular"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_endereco")))
                        reg.endereco = reader.GetString(reader.GetOrdinal("ds_endereco"));
                    if (!reader.IsDBNull(reader.GetOrdinal("bairro")))
                        reg.bairro = reader.GetString(reader.GetOrdinal("bairro"));
                    if (!reader.IsDBNull(reader.GetOrdinal("proximo")))
                        reg.obs = reader.GetString(reader.GetOrdinal("proximo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("numero")))
                        reg.numero = reader.GetString(reader.GetOrdinal("numero"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_cidade")))
                        reg.cd_cidade = reader.GetString(reader.GetOrdinal("cd_cidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_cidade")))
                        reg.ds_cidade = reader.GetString(reader.GetOrdinal("ds_cidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cartao_fidelidade")))
                        reg.Ident_frentista = reader.GetString(reader.GetOrdinal("cartao_fidelidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cep")))
                        reg.cep = reader.GetString(reader.GetOrdinal("cep"));


                    if (!reader.IsDBNull(reader.GetOrdinal("VL_Renda")))
                        reg.Vl_renda = reader.GetDecimal(reader.GetOrdinal("VL_Renda"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DT_Nascimento")))
                        reg.Dt_nascimento = reader.GetDateTime(reader.GetOrdinal("DT_Nascimento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("TP_Sexo")))
                        reg.Tp_sexo = reader.GetString(reader.GetOrdinal("TP_Sexo"));

                    lista.Add(reg);
                }
            }
            finally
            {
                reader.Close();
                reader.Dispose();
                if (podeFecharBco)
                    deletarBanco_Dados();
            }
            return lista;
        }
    }
    }
