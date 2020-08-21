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
    public class TEndereco_CEPRest
    {
        public string cep { get; set; } = string.Empty;
        public string logradouro { get; set; } = string.Empty;
        public string complemento { get; set; } = string.Empty;
        public string bairro { get; set; } = string.Empty;
        public string localidade { get; set; } = string.Empty;
        public string uf { get; set; } = string.Empty;
        public string unidade { get; set; } = string.Empty;
        public string ibge { get; set; } = string.Empty;
        public string gia { get; set; } = string.Empty;
    }

    public class TList_CadEndereco : List<TRegistro_CadEndereco>, IComparer<TRegistro_CadEndereco>
    {
        #region IComparer<TRegistro_CadEndereco> Members
        private System.ComponentModel.PropertyDescriptor Propriedade;
        private System.Windows.Forms.SortOrder Direcao;

        private int CompareAscending(object x, object y)
        {
            if (x is IComparable)
                return new System.Collections.CaseInsensitiveComparer().Compare(x, y);
            else
                return 0;
        }

        private int CompareDescending(object x, object y)
        {
            return -CompareAscending(x, y);
        }

        public TList_CadEndereco()
        { }

        public TList_CadEndereco(System.ComponentModel.PropertyDescriptor Prop,
                                 System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_CadEndereco value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_CadEndereco x, TRegistro_CadEndereco y)
        {
            object col1 = GetPropertyValue(x, Propriedade.Name);
            object col2 = GetPropertyValue(y, Propriedade.Name);
            if (Direcao == System.Windows.Forms.SortOrder.Ascending)
                return CompareAscending(col1, col2);
            else
                return CompareDescending(col1, col2);
        }
        #endregion
    }
    
    public class TRegistro_CadEndereco
    {
        public string Cd_clifor 
        { get; set; }
        public string Nm_clifor 
        { get; set; }
        public string Cd_endereco 
        { get; set; }
        public string Ds_endereco 
        { get; set; }
        public string Cd_cidade
        { get; set; }
        public string Numero 
        { get; set; }
        public string Bairro 
        { get; set; }
        public string Proximo 
        { get; set; }
        public string Cep 
        { get; set; }
        public string Cp
        { get; set; }
        public string cpf
        { get; set; }
        public string rg
        { get; set; }
        public string Fone 
        { get; set; }
        public string Fone_comercial
        { get; set; }
        public string Celular
        { get; set; }
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
        private string st_enderecoentrega;
        public string St_enderecoentrega 
        {
            get { return st_enderecoentrega; }
            set 
            {
                st_enderecoentrega = value;
                st_enderecoentregabool = value.Trim().ToUpper().Equals("S");
            }
        }
        private bool st_enderecoentregabool;
        public bool St_enderecoentregabool
        {
            get { return st_enderecoentregabool; }
            set 
            { 
                st_enderecoentregabool = value;
                if (value)
                    st_enderecoentrega = "S";
                else
                    st_enderecoentrega = "N";
            }
        }
        private string st_endcobranca;
        public string St_endcobranca
        {
            get { return st_endcobranca; }
            set
            {
                st_endcobranca = value;
                st_endcobrancabool = value.Trim().ToUpper().Equals("S");
            }
        }
        private bool st_endcobrancabool;
        public bool St_endcobrancabool
        {
            get { return st_endcobrancabool; }
            set
            {
                st_endcobrancabool = value;
                st_endcobranca = value ? "S" : "N";
            }
        }
        public string Insc_estadual 
        { get; set; }
        private string st_naocontribuinte;
        public string St_naocontribuinte
        {
            get { return st_naocontribuinte; }
            set
            {
                st_naocontribuinte = value;
                st_naocontribuintebool = value.Trim().ToUpper().Equals("S");
            }
        }
        private bool st_naocontribuintebool;
        public bool St_naocontribuintebool
        {
            get { return st_naocontribuintebool; }
            set
            {
                st_naocontribuintebool = value;
                st_naocontribuinte = value ? "S" : "N";
            }
        }
        public string Ds_complemento 
        { get; set; }
        public TRegistro_CadCidade rCidade
        { get; set; }
        public string CD_Pais
        { get; set; }
        public string NM_Pais
        { get; set; }
        public string DS_Cidade
        { get; set; }
        public string DS_Estado
        { get; set; }
        public string UF
        { get; set; }
        public string Cd_uf
        { get; set; }
        public string Latitude
        { get; set; }
        public string Longitude
        { get; set; }
        public string Cd_integracao { get; set; } = string.Empty;
                
        public TRegistro_CadEndereco()
        {
            Cd_clifor = string.Empty;
            Nm_clifor = string.Empty;
            Cd_endereco = string.Empty;
            Cd_cidade = string.Empty;
            rCidade = new TRegistro_CadCidade();
            Ds_endereco = string.Empty;
            Numero = string.Empty;
            cpf = string.Empty;
            rg = string.Empty;
            Bairro = string.Empty;
            Proximo = string.Empty;
            Cep = string.Empty;
            Cp = string.Empty;
            Fone = string.Empty;
            Fone_comercial = string.Empty;
            Celular = string.Empty;
            st_registro = "A";
            st_enderecoentrega = "N";
            st_enderecoentregabool = false;
            st_endcobranca = "N";
            st_endcobrancabool = false;
            Insc_estadual = string.Empty;
            Ds_complemento = string.Empty;
            CD_Pais = string.Empty;
            NM_Pais = string.Empty;
            DS_Cidade = string.Empty;
            DS_Estado = string.Empty;
            UF = string.Empty;
            Cd_uf = string.Empty;
            Latitude = string.Empty;
            Longitude = string.Empty;
            st_naocontribuinte = "N";
            st_naocontribuintebool = false;
        }
    }

    public class TCD_CadEndereco : TDataQuery
    {
        public TCD_CadEndereco()
        { }

        public TCD_CadEndereco(BancoDados.TObjetoBanco banco)
        { Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("select " + strTop + " a.cd_clifor, b.nm_clifor, a.cd_endereco, a.cd_cidade, a.ds_endereco, ");
                sql.AppendLine("a.numero, a.bairro, a.proximo , a.cep, a.cp, a.st_registro, a.st_endentrega, a.st_endcobranca, ");
                sql.AppendLine("a.insc_estadual, a.st_naocontribuinte, a.ds_complemento, a.cd_pais, a.NM_pais, a.ds_cidade, a.UF, ");
                sql.AppendLine("a.fone, a.fone_comercial, a.celular, a.cd_uf, a.ds_uf, a.latitude, a.longitude ");
            }
            else
                sql.AppendLine(" Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from vtb_fin_endereco a ");
            sql.AppendLine("inner join tb_fin_clifor b ");
            sql.AppendLine("on a.cd_clifor = b.cd_clifor ");

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

        public TList_CadEndereco Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            bool podeFecharBco = false;
            TList_CadEndereco lista = new TList_CadEndereco();
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            SqlDataReader reader = ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_CadEndereco reg = new TRegistro_CadEndereco();
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_Clifor"))))
                        reg.Cd_clifor = reader.GetString(reader.GetOrdinal("CD_Clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NM_Clifor")))
                        reg.Nm_clifor = reader.GetString(reader.GetOrdinal("NM_Clifor"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_Endereco"))))
                        reg.Cd_endereco = reader.GetString(reader.GetOrdinal("CD_Endereco"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("DS_Endereco"))))
                        reg.Ds_endereco = reader.GetString(reader.GetOrdinal("DS_Endereco"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("Numero"))))
                        reg.Numero = reader.GetString(reader.GetOrdinal("Numero"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("Bairro"))))
                        reg.Bairro = reader.GetString(reader.GetOrdinal("Bairro"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("Proximo"))))
                        reg.Proximo = reader.GetString(reader.GetOrdinal("Proximo"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("Cep"))))
                        reg.Cep = reader.GetString(reader.GetOrdinal("Cep"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("CP"))))
                        reg.Cp = reader.GetString(reader.GetOrdinal("CP"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("Fone"))))
                        reg.Fone = reader.GetString(reader.GetOrdinal("Fone"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Fone_comercial")))
                        reg.Fone_comercial = reader.GetString(reader.GetOrdinal("Fone_comercial"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Celular")))
                        reg.Celular = reader.GetString(reader.GetOrdinal("Celular"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("ST_Registro"))))
                        reg.St_registro = reader.GetString(reader.GetOrdinal("ST_Registro"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("ST_EndEntrega"))))
                        reg.St_enderecoentrega = reader.GetString(reader.GetOrdinal("ST_EndEntrega"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ST_EndCobranca")))
                        reg.St_endcobranca = reader.GetString(reader.GetOrdinal("ST_EndCobranca"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("Insc_Estadual"))))
                        reg.Insc_estadual = reader.GetString(reader.GetOrdinal("Insc_Estadual"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ST_NaoContribuinte")))
                        reg.St_naocontribuinte = reader.GetString(reader.GetOrdinal("ST_NaoContribuinte"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("DS_Complemento"))))
                        reg.Ds_complemento = reader.GetString(reader.GetOrdinal("DS_Complemento"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_Pais"))))
                        reg.CD_Pais = reader.GetString(reader.GetOrdinal("CD_Pais"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("NM_Pais"))))
                        reg.NM_Pais = reader.GetString(reader.GetOrdinal("NM_Pais"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Cidade")))
                    {
                        reg.Cd_cidade = reader.GetString(reader.GetOrdinal("CD_Cidade"));
                        reg.rCidade.Cd_cidade = reg.Cd_cidade;
                    }
                    if (!(reader.IsDBNull(reader.GetOrdinal("DS_Cidade"))))
                    {
                        reg.DS_Cidade = reader.GetString(reader.GetOrdinal("DS_Cidade"));
                        reg.rCidade.Ds_cidade = reg.DS_Cidade;
                    }
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_UF")))
                    {
                        reg.Cd_uf = reader.GetString(reader.GetOrdinal("CD_UF"));
                        reg.rCidade.rUf.Cd_uf = reg.Cd_uf;
                    }
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_UF")))
                    {
                        reg.DS_Estado = reader.GetString(reader.GetOrdinal("DS_UF"));
                        reg.rCidade.Ds_uf = reg.DS_Estado;
                        reg.rCidade.rUf.Ds_uf = reg.DS_Estado;
                    }
                    if (!(reader.IsDBNull(reader.GetOrdinal("UF"))))
                    {
                        reg.UF = reader.GetString(reader.GetOrdinal("UF"));
                        reg.rCidade.rUf.Uf = reg.UF;
                    }
                    if (!(reader.IsDBNull(reader.GetOrdinal("latitude"))))
                        reg.Latitude = reader.GetString(reader.GetOrdinal("latitude"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("longitude"))))
                        reg.Longitude = reader.GetString(reader.GetOrdinal("longitude"));
                    //if (!reader.IsDBNull(reader.GetOrdinal("cd_integracao")))
                    //    reg.Cd_integracao = reader.GetString(reader.GetOrdinal("cd_integracao"));
                    
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

        public string Gravar(TRegistro_CadEndereco val)
        {
            Hashtable hs = new Hashtable(22);
            hs.Add("@P_CD_CLIFOR", val.Cd_clifor);
            hs.Add("@P_CD_ENDERECO", val.Cd_endereco);
            hs.Add("@P_CD_CIDADE", val.Cd_cidade);
            hs.Add("@P_DS_ENDERECO", val.Ds_endereco);
            hs.Add("@P_NUMERO", val.Numero);
            hs.Add("@P_BAIRRO", val.Bairro);
            hs.Add("@P_PROXIMO", val.Proximo);
            hs.Add("@P_CEP", val.Cep);
            hs.Add("@P_CP", val.Cp);
            hs.Add("@P_FONE", val.Fone);
            hs.Add("@P_FONE_COMERCIAL", val.Fone_comercial);
            hs.Add("@P_CELULAR", val.Celular);
            hs.Add("@P_ST_REGISTRO", val.St_registro);
            hs.Add("@P_ST_ENDENTREGA", val.St_enderecoentrega);
            hs.Add("@P_ST_ENDCOBRANCA", val.St_endcobranca);
            hs.Add("@P_INSC_ESTADUAL", val.Insc_estadual);
            hs.Add("@P_ST_NAOCONTRIBUINTE", val.St_naocontribuinte);
            hs.Add("@P_DS_COMPLEMENTO", val.Ds_complemento);
            hs.Add("@P_CD_PAIS", val.CD_Pais);
            hs.Add("@P_LATITUDE", val.Latitude);
            hs.Add("@P_LONGITUDE", val.Longitude);
            hs.Add("@P_CD_INTEGRACAO", val.Cd_integracao);

            return executarProc("IA_FIN_ENDERECO", hs);
        }

        public string Excluir(TRegistro_CadEndereco val)
        {
            Hashtable hs = new Hashtable(2);
            hs.Add("@P_CD_CLIFOR", val.Cd_clifor);
            hs.Add("@P_CD_ENDERECO", val.Cd_endereco);

            return executarProc("EXCLUI_FIN_ENDERECO", hs);
        }
    }
}
