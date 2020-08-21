using System;
using System.Collections.Generic;
using System.Text;
using Utils;
using System.Data;
using System.Data.SqlClient;
using System.Collections;

namespace CamadaDados.Estoque.Cadastros
{
    public class TList_CadTpProduto : List<TRegistro_CadTpProduto>, IComparer<TRegistro_CadTpProduto>
    {
        #region IComparer<TRegistro_CadTpProduto> Members
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

        public TList_CadTpProduto()
        { }

        public TList_CadTpProduto(System.ComponentModel.PropertyDescriptor Prop,
                                  System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_CadTpProduto value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_CadTpProduto x, TRegistro_CadTpProduto y)
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

    public class TRegistro_CadTpProduto
    {
        public string TP_Produto { get; set; }
        public string DS_TpProduto { get; set; }
        private string st_Servico;
        public string ST_servico
        {
            get { return st_Servico; }
            set
            {
                st_Servico = value;
                st_servicobool = value.Trim().ToUpper().Equals("S");
            }
        }
        private bool st_servicobool;
        public bool St_servicobool
        {
            get { return st_servicobool; }
            set
            {
                st_servicobool = value;
                st_Servico = value ? "S" : "N";
            }
        }
        private string st_semente;
        public string St_semente
        {
            get { return st_semente; }
            set
            {
                st_semente = value;
                st_sementebool = value.ToUpper().Trim().Equals("S");
            }
        }
        private bool st_sementebool;
        public bool St_sementebool
        {
            get { return st_sementebool; }
            set
            {
                st_sementebool = value;
                st_semente = value ? "S" : "N";
            }
        }
        private string st_consumointerno;
        public string St_consumointerno
        {
            get { return st_consumointerno; }
            set
            {
                st_consumointerno = value;
                st_consumointernobool = value.ToUpper().Trim().Equals("S");
            }
        }
        private bool st_consumointernobool;
        public bool St_consumointernobool
        {
            get { return st_consumointernobool; }
            set
            {
                st_consumointernobool = value;
                st_consumointerno = value ? "S" : "N";
            }
        }
        private string st_patrimonio;
        public string St_patrimonio
        {
            get { return st_patrimonio; }
            set
            {
                st_patrimonio = value;
                st_patrimoniobool = value.Trim().ToUpper().Equals("S");
            }
        }
        private bool st_patrimoniobool;
        public bool St_patrimoniobool
        {
            get { return st_patrimoniobool; }
            set
            {
                st_patrimoniobool = value;
                st_patrimonio = value ? "S" : "N";
            }
        }
        private string st_composto;
        public string ST_Composto
        {
            get { return st_composto; }
            set
            {
                st_composto = value;
                st_compostobool = value.Trim().ToUpper().Equals("S");
            }
        }
        private bool st_compostobool;
        public bool St_compostobool
        {
            get { return st_compostobool; }
            set
            {
                st_compostobool = value;
                st_composto = value ? "S" : "N";
            }
        }
        private string st_MPrima;
        public string St_MPrima
        {
            get { return st_MPrima; }

            set
            {
                st_MPrima = value;
                st_MPrimabool = value.Trim().ToUpper().Equals("S");
            }
        }
        private bool st_MPrimabool;
        public bool St_MPrimabool
        {
            get { return st_MPrimabool; }

            set
            {
                st_MPrimabool = value;
                st_MPrima = value ? "S" : "N";
            }
        }
        private string st_industrializado;
        public string St_industrializado
        {
            get { return st_industrializado; }
            set
            {
                st_industrializado = value;
                st_industrializadobool = value.Trim().ToUpper().Equals("S");
            }
        }
        private bool st_industrializadobool;
        public bool St_industrializadobool
        {
            get { return st_industrializadobool; }
            set
            {
                st_industrializadobool = value;
                st_industrializado = value ? "S" : "N";
            }
        }
        private string st_embalagem;
        public string St_embalagem
        {
            get { return st_embalagem; }
            set
            {
                st_embalagem = value;
                st_embalagembool = value.Trim().ToUpper().Equals("S");
            }
        }
        private bool st_embalagembool;
        public bool St_embalagembool
        {
            get { return st_embalagembool; }
            set
            {
                st_embalagembool = value;
                if (value)
                    st_embalagem = "S";
                else
                    st_embalagem = "N";
            }
        }
        private string st_mprimasemente;
        public string St_mprimasemente
        {
            get { return st_mprimasemente; }
            set
            {
                st_mprimasemente = value;
                st_mprimasementebool = value.Trim().ToUpper().Equals("S");
            }
        }
        private bool st_mprimasementebool;
        public bool St_mprimasementebool
        {
            get { return st_mprimasementebool; }
            set
            {
                st_mprimasementebool = value;
                st_mprimasemente = value ? "S" : "N";
            }
        }
        private string st_combustivel;
        public string St_combustivel
        {
            get { return st_combustivel; }
            set
            {
                st_combustivel = value;
                st_combustivelbool = value.Trim().ToUpper().Equals("S");
            }
        }
        private bool st_combustivelbool;
        public bool St_combustivelbool
        {
            get { return st_combustivelbool; }
            set
            {
                st_combustivelbool = value;
                st_combustivel = value ? "S" : "N";
            }
        }
        private string st_lubrificante;
        public string St_lubrificante
        {
            get { return st_lubrificante; }
            set
            {
                st_lubrificante = value;
                st_lubrificantebool = value.Trim().ToUpper().Equals("S");
            }
        }
        private bool st_lubrificantebool;
        public bool St_lubrificantebool
        {
            get { return st_lubrificantebool; }
            set
            {
                st_lubrificantebool = value;
                st_lubrificante = value ? "S" : "N";
            }
        }
        private string st_pneu;
        public string St_pneu
        {
            get { return st_pneu; }
            set
            {
                st_pneu = value;
                st_pneubool = value.ToUpper().Trim().Equals("S");
            }
        }
        private bool st_pneubool;
        public bool St_pneubool
        {
            get { return st_pneubool; }
            set
            {
                st_pneubool = value;
                st_pneu = value ? "S" : "N";
            }
        }
        private string st_reganvisa;
        public string St_reganvisa
        {
            get { return st_reganvisa; }
            set
            {
                st_reganvisa = value;
                st_reganvisabool = value.Trim().ToUpper().Equals("S");
            }
        }
        private bool st_reganvisabool;
        public bool St_reganvisabool
        {
            get { return st_reganvisabool; }
            set
            {
                st_reganvisabool = value;
                st_reganvisa = value ? "S" : "N";
            }
        }
        private string st_folhar;
        public string St_folhar
        {
            get { return st_folhar; }
            set
            {
                st_folhar = value;
                st_folharbool = value.Trim().ToUpper().Equals("S");
            }
        }
        private bool st_folharbool;
        public bool St_folharbool
        {
            get { return st_folharbool; }
            set
            {
                st_folharbool = value;
                st_folhar = value ? "S" : "N";
            }
        }
        private string st_tanquecombustivel;
        public string St_tanquecombustivel
        {
            get { return st_tanquecombustivel; }
            set
            {
                st_tanquecombustivel = value;
                st_tanquecombustivelbool = value.Trim().ToUpper().Equals("S");
            }
        }
        private bool st_tanquecombustivelbool;
        public bool St_tanquecombustivelbool
        {
            get { return st_tanquecombustivelbool; }
            set
            {
                st_tanquecombustivelbool = value;
                st_tanquecombustivel = value ? "S" : "N";
            }
        }
        private string st_commodities;

        public string St_commodities
        {
            get { return st_commodities; }
            set
            {
                st_commodities = value;
                St_commoditiesbool = value.Trim().ToUpper().Equals("S");
            }
        }
        private bool st_commoditesbool;

        public bool St_commoditiesbool
        {
            get { return st_commoditesbool; }
            set
            {
                st_commoditesbool = value;
                st_commodities = value ? "S" : "N";
            }
        }

        public bool St_processar { get; set; }

        public TRegistro_CadTpProduto()
        {
            TP_Produto = string.Empty;
            DS_TpProduto = string.Empty;
            st_Servico = "N";
            st_servicobool = false;
            st_composto = "N";
            st_compostobool = false; 
            st_MPrima = "N";
            st_MPrimabool = false;
            st_embalagem = "N";
            st_embalagembool = false;
            st_mprimasemente = "N";
            st_mprimasementebool = false;
            st_consumointerno = "N";
            st_consumointernobool = false;
            st_industrializado = "N";
            st_industrializadobool = false;
            st_semente = "N";
            st_sementebool = false;
            st_combustivel = "N";
            st_combustivelbool = false;
            st_lubrificante = "N";
            st_lubrificantebool = false;
            st_patrimonio = "N";
            st_patrimoniobool = false;
            st_pneu = "N";
            st_pneubool = false;
            st_reganvisa = "N";
            st_reganvisabool = false;
            st_folhar = "N";
            st_folharbool = false;
            st_tanquecombustivel = "N";
            st_tanquecombustivelbool = false;
            st_commodities = "N";
            st_commoditesbool = false;
        }
    }

      public class TCD_CadTpProduto : TDataQuery
     {
          public TCD_CadTpProduto()
          { }

          public TCD_CadTpProduto(BancoDados.TObjetoBanco banco)
          { Banco_Dados = banco; }

         private string SqlCodeBusca(TpBusca[] vBusca, int vTop, string vNM_Campo)
         {
             string strTop = string.Empty;
             if (vTop > 0)
                 strTop = "TOP " + Convert.ToString(vTop);
             StringBuilder sql = new StringBuilder();

             if (string.IsNullOrEmpty(vNM_Campo))
             {
                 sql.AppendLine(" SELECT " + strTop + " a.st_folhares, a.tp_produto, a.ds_tpproduto, a.st_semente, ");
                 sql.AppendLine("a.st_servico, a.st_composto, a.st_mprima, a.st_embalagem, a.st_reganvisa, ");
                 sql.AppendLine("a.st_industrializado, a.st_mprimasemente, a.st_consumointerno, a.st_tanquecombustivel, ");
                 sql.AppendLine("a.st_combustivel, a.st_lubrificante, a.st_patrimonio, a.st_pneu, a.st_commodities ");
             }
             else
                 sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

             sql.AppendLine(" FROM tb_est_TpProduto a ");             
             string cond = " where ";
             if (vBusca != null)
                 for (int i = 0; i < (vBusca.Length); i++)
                 {
                     sql.Append(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                     cond = " and ";
                 }
             sql.Append("Order by a.ds_tpproduto asc");
             return sql.ToString();
         }

         public override DataTable Buscar(TpBusca[] vBusca, short vTop)
         {
               return ExecutarBusca(SqlCodeBusca(vBusca, vTop, string.Empty), null);
         }

         public override DataTable Buscar(TpBusca[] vBusca, short vTop, string vNM_Campo)
         {
             return ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo), null);
         }

         public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
         {
             return ExecutarBuscaEscalar(SqlCodeBusca(vBusca, 1, vNM_Campo), null);
         }

         public TList_CadTpProduto Select(TpBusca[] vBusca, int vTop, string vNM_Campo)
         {
             TList_CadTpProduto lista = new TList_CadTpProduto();
             SqlDataReader reader = null;
             bool podeFecharBco = false;
             if (Banco_Dados == null)
                 podeFecharBco = CriarBanco_Dados(false);

             try
             {
                 reader = ExecutarBusca(SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
                 while (reader.Read())
                 {
                     TRegistro_CadTpProduto reg = new TRegistro_CadTpProduto();
                     if (!reader.IsDBNull(reader.GetOrdinal("ds_tpproduto")))
                         reg.DS_TpProduto = reader.GetString(reader.GetOrdinal("ds_tpproduto"));
                     if (!reader.IsDBNull(reader.GetOrdinal("tp_produto")))
                         reg.TP_Produto = reader.GetString(reader.GetOrdinal("tp_produto"));
                     if (!reader.IsDBNull(reader.GetOrdinal("st_servico")))
                         reg.ST_servico = reader.GetString(reader.GetOrdinal("st_servico"));
                     if (!reader.IsDBNull(reader.GetOrdinal("st_composto")))
                         reg.ST_Composto = reader.GetString(reader.GetOrdinal("st_composto"));
                     if (!reader.IsDBNull(reader.GetOrdinal("st_mprima")))
                         reg.St_MPrima = reader.GetString(reader.GetOrdinal("st_mprima"));
                     if (!reader.IsDBNull(reader.GetOrdinal("ST_Embalagem")))
                         reg.St_embalagem = reader.GetString(reader.GetOrdinal("ST_Embalagem"));
                     if (!reader.IsDBNull(reader.GetOrdinal("ST_Semente")))
                         reg.St_semente = reader.GetString(reader.GetOrdinal("ST_Semente"));
                     if (!reader.IsDBNull(reader.GetOrdinal("st_mprimasemente")))
                         reg.St_mprimasemente = reader.GetString(reader.GetOrdinal("st_mprimasemente"));
                     if (!reader.IsDBNull(reader.GetOrdinal("ST_ConsumoInterno")))
                         reg.St_consumointerno = reader.GetString(reader.GetOrdinal("ST_ConsumoInterno"));
                     if (!reader.IsDBNull(reader.GetOrdinal("ST_Industrializado")))
                         reg.St_industrializado = reader.GetString(reader.GetOrdinal("ST_Industrializado"));
                     if (!reader.IsDBNull(reader.GetOrdinal("st_combustivel")))
                         reg.St_combustivel = reader.GetString(reader.GetOrdinal("st_combustivel"));
                     if (!reader.IsDBNull(reader.GetOrdinal("st_lubrificante")))
                         reg.St_lubrificante = reader.GetString(reader.GetOrdinal("st_lubrificante"));
                     if (!reader.IsDBNull(reader.GetOrdinal("st_patrimonio")))
                         reg.St_patrimonio = reader.GetString(reader.GetOrdinal("st_patrimonio"));
                     if (!reader.IsDBNull(reader.GetOrdinal("st_pneu")))
                         reg.St_pneu = reader.GetString(reader.GetOrdinal("st_pneu"));
                     if (!reader.IsDBNull(reader.GetOrdinal("st_reganvisa")))
                         reg.St_reganvisa = reader.GetString(reader.GetOrdinal("st_reganvisa"));
                     if (!reader.IsDBNull(reader.GetOrdinal("st_folhares")))
                         reg.St_folhar = reader.GetString(reader.GetOrdinal("st_folhares"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_tanquecombustivel")))
                        reg.St_tanquecombustivel = reader.GetString(reader.GetOrdinal("st_tanquecombustivel"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_commodities")))
                        reg.St_commodities = reader.GetString(reader.GetOrdinal("st_commodities"));
                    
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

         public string Grava(TRegistro_CadTpProduto vRegistro)
         {
            Hashtable hs = new Hashtable(18);
            hs.Add("@P_TP_PRODUTO", vRegistro.TP_Produto);
            hs.Add("@P_DS_TPPRODUTO", vRegistro.DS_TpProduto);
            hs.Add("@P_ST_SERVICO", vRegistro.ST_servico);
            hs.Add("@P_ST_COMPOSTO", vRegistro.ST_Composto);
            hs.Add("@P_ST_MPRIMA", vRegistro.St_MPrima);
            hs.Add("@P_ST_EMBALAGEM", vRegistro.St_embalagem);
            hs.Add("@P_ST_SEMENTE", vRegistro.St_semente);
            hs.Add("@P_ST_MPRIMASEMENTE", vRegistro.St_mprimasemente);
            hs.Add("@P_ST_CONSUMOINTERNO", vRegistro.St_consumointerno);
            hs.Add("@P_ST_INDUSTRIALIZADO", vRegistro.St_industrializado);
            hs.Add("@P_ST_COMBUSTIVEL", vRegistro.St_combustivel);
            hs.Add("@P_ST_LUBRIFICANTE", vRegistro.St_lubrificante);
            hs.Add("@P_ST_PATRIMONIO", vRegistro.St_patrimonio);
            hs.Add("@P_ST_PNEU", vRegistro.St_pneu);
            hs.Add("@P_ST_REGANVISA", vRegistro.St_reganvisa);
            hs.Add("@P_ST_FOLHARES", vRegistro.St_folhar);
            hs.Add("@P_ST_TANQUECOMBUSTIVEL", vRegistro.St_tanquecombustivel);
            hs.Add("@P_ST_COMMODITIES", vRegistro.St_commodities);   


             return executarProc("IA_EST_TPPRODUTO", hs); 
         }

         public string Deleta(TRegistro_CadTpProduto vRegistro)
         {
             Hashtable hs = new Hashtable(1);
             hs.Add("@P_TP_PRODUTO", vRegistro.TP_Produto);

             return executarProc("EXCLUI_EST_TPPRODUTO", hs);
         }
     }
}