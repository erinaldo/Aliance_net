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
    public class TList_CadCategoriaCliFor : List<TRegistro_CadCategoriaCliFor>
    { }

    
    public class TRegistro_CadCategoriaCliFor
    {
        
        public decimal Id_CategoriaCliFor 
        { get; set; }
        
        public string Ds_CategoriaCliFor 
        { get; set; }
        private string st_transportadora;
        
        public string St_transportadora
        {
            get { return st_transportadora; }
            set
            {
                st_transportadora = value;
                st_transportadorabool = value.Trim().ToUpper().Equals("S");
            }
        }
        private bool st_transportadorabool;
        
        public bool St_transportadorabool
        {
            get { return st_transportadorabool; }
            set
            {
                st_transportadorabool = value;
                st_transportadora = value ? "S" : "N";
            }
        }
        private string st_fornecedor;
        
        public string St_fornecedor
        {
            get { return st_fornecedor; }
            set
            {
                st_fornecedor = value;
                st_fornecedorbool = value.Trim().ToUpper().Equals("S");
            }
        }
        private bool st_fornecedorbool;
        
        public bool St_fornecedorbool
        {
            get { return st_fornecedorbool; }
            set
            {
                st_fornecedorbool = value;
                st_fornecedor = value ? "S" : "N";
            }
        }
        private string st_funcionarios;
        
        public string St_funcionarios
        {
            get { return st_funcionarios; }
            set
            {
                st_funcionarios = value;
                st_funcionariosbool = value.Trim().ToUpper().Equals("S");
            }
        }
        private bool st_funcionariosbool;
        
        public bool St_funcionariosbool
        {
            get { return st_funcionariosbool; }
            set
            {
                st_funcionariosbool = value;
                st_funcionarios = value ? "S" : "N";
            }
        }
        private string st_representante;
        
        public string St_representante
        {
            get { return st_representante; }
            set
            {
                st_representante = value;
                st_representantebool = value.Trim().ToUpper().Equals("S");
            }
        }
        private bool st_representantebool;
        
        public bool St_representantebool
        {
            get { return st_representantebool; }
            set
            {
                st_representantebool = value;
                st_representante = value ? "S" : "N";
            }
        }

        public TRegistro_CadCategoriaCliFor()
        {
            this.Id_CategoriaCliFor = decimal.Zero;
            this.Ds_CategoriaCliFor = string.Empty;
            this.st_transportadora = "N";
            this.st_transportadorabool = false;
            this.st_fornecedor = "N";
            this.st_fornecedorbool = false;
            this.st_funcionarios = "N";
            this.st_funcionariosbool = false;
            this.st_representante = "N";
            this.st_representantebool = false;
        }
    }

    public class TCD_CadCategoriaCliFor : TDataQuery
    {
        public TCD_CadCategoriaCliFor()
        { }

        public TCD_CadCategoriaCliFor(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = " TOP " + vTop.ToString();

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("select " + strTop + " a.Id_CategoriaCliFor, a.Ds_CategoriaCliFor, ");
                sql.AppendLine("a.st_transportadora, a.st_fornecedor, a.st_funcionarios, a.st_representante ");
            }
            else
                sql.AppendLine(" Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("  from TB_FIN_CATEGORIACLIFOR a ");

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

        public TList_CadCategoriaCliFor Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            bool podeFecharBco = false;
            TList_CadCategoriaCliFor lista = new TList_CadCategoriaCliFor();
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            SqlDataReader reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_CadCategoriaCliFor reg = new TRegistro_CadCategoriaCliFor();
                    if (!(reader.IsDBNull(reader.GetOrdinal("Id_CategoriaCliFor"))))
                        reg.Id_CategoriaCliFor = reader.GetDecimal(reader.GetOrdinal("Id_CategoriaCliFor"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("Ds_CategoriaCliFor"))))
                        reg.Ds_CategoriaCliFor = reader.GetString(reader.GetOrdinal("Ds_CategoriaCliFor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ST_Transportadora")))
                        reg.St_transportadora = reader.GetString(reader.GetOrdinal("ST_Transportadora"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ST_Fornecedor")))
                        reg.St_fornecedor = reader.GetString(reader.GetOrdinal("ST_Fornecedor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ST_Funcionarios")))
                        reg.St_funcionarios = reader.GetString(reader.GetOrdinal("ST_Funcionarios"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_representante")))
                        reg.St_representante = reader.GetString(reader.GetOrdinal("st_representante"));

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

        public string Gravar(TRegistro_CadCategoriaCliFor val)
        {
            Hashtable hs = new Hashtable(6);
            hs.Add("@P_ID_CATEGORIACLIFOR", val.Id_CategoriaCliFor);
            hs.Add("@P_DS_CATEGORIACLIFOR", val.Ds_CategoriaCliFor);
            hs.Add("@P_ST_TRANSPORTADORA", val.St_transportadora);
            hs.Add("@P_ST_FORNECEDOR", val.St_fornecedor);
            hs.Add("@P_ST_FUNCIONARIOS", val.St_funcionarios);
            hs.Add("@P_ST_REPRESENTANTE", val.St_representante);

            return this.executarProc("IA_FIN_CATEGORIACLIFOR", hs);
        }

        public string Excluir(TRegistro_CadCategoriaCliFor val)
        {
            Hashtable hs = new Hashtable(1);
            hs.Add("@P_ID_CATEGORIACLIFOR", val.Id_CategoriaCliFor);

            return this.executarProc("EXCLUI_FIN_CATEGORIACLIFOR", hs);
        }
    }
}
