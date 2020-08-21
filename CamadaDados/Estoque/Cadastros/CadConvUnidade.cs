using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using System.Collections;
using CamadaDados.Estoque.Cadastros;

namespace CamadaDados.Estoque.Cadastros
{
    public class TList_CadConvUnidade : List<TRegistro_CadConvUnidade>, IComparer<TRegistro_CadConvUnidade>
    {
        #region IComparer<TRegistro_CadConvUnidade> Members
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

        public TList_CadConvUnidade()
        { }

        public TList_CadConvUnidade(System.ComponentModel.PropertyDescriptor Prop,
                                    System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_CadConvUnidade value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_CadConvUnidade x, TRegistro_CadConvUnidade y)
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
   
    
    public class TRegistro_CadConvUnidade
    {
        
        public string CD_Unidade_Orig { get; set; }
        
        public string DS_Unidade_Orig { get; set; }
        
        public string CD_Unidade_Dest { get; set; }
        
        public string DS_Unidade_Dest{get;  set;}
        private string _ST_Fator;
        
        public string ST_Fator
        {
        get { return _ST_Fator; }
        set { _ST_Fator = value;

             if (_ST_Fator == "*")
             {
                 _ST_Fator_Extendido = "Multiplicação";
             }
             else
             {
                     _ST_Fator_Extendido = "Divisão";
             }
           }

        }
        private string _ST_Fator_Extendido;
        
        public string ST_Fator_Extendido
        {
            get { return _ST_Fator_Extendido; }
            set { _ST_Fator_Extendido = value;

                    if (_ST_Fator_Extendido == "Multiplicação")
                    {
                        _ST_Fator = "*";
                    }
                    else
                    {
                        _ST_Fator = "/";
                    }
                }
        }
        
        public decimal VL_Indice { get; set; }
        
        public string ST_Registro { get; set;}
        
        public TRegistro_CadConvUnidade()
        {
            this.CD_Unidade_Orig = string.Empty;
            this.DS_Unidade_Orig = string.Empty;
            this.CD_Unidade_Dest = string.Empty;
            this.DS_Unidade_Dest = string.Empty;
            this.ST_Fator = string.Empty;
            this.ST_Fator_Extendido = string.Empty;
            this.VL_Indice = decimal.Zero; 
            this.ST_Registro = "A";  
        }
     }
 
    public class TCD_CadConvUnidade : TDataQuery
    {
        public TCD_CadConvUnidade()
        { }

        public TCD_CadConvUnidade(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine(" SELECT " + strTop + "a.cd_unidade_orig, b.ds_unidade as ds_unidade_orig, ");
                sql.AppendLine("a.cd_unidade_dest, c.ds_unidade as ds_unidade_dest, a.st_fator, a.vl_indice, a.st_registro");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("FROM TB_EST_Converte_Unid a ");
            sql.AppendLine("inner join TB_EST_Unidade b ");
            sql.AppendLine("on b.cd_unidade = a.cd_unidade_orig ");
            sql.AppendLine("inner join TB_EST_Unidade c ");
            sql.AppendLine("on c.cd_unidade = a.cd_unidade_dest ");

            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.Append(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                    cond = " and ";
                }
            sql.Append("Order by b.ds_unidade asc");
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

        public TList_CadConvUnidade Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_CadConvUnidade lista = new TList_CadConvUnidade();
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            SqlDataReader reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_CadConvUnidade reg = new TRegistro_CadConvUnidade();
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_unidade_orig")))
                        reg.CD_Unidade_Orig = reader.GetString(reader.GetOrdinal("cd_unidade_orig"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_unidade_dest")))
                        reg.CD_Unidade_Dest = reader.GetString(reader.GetOrdinal("cd_unidade_dest"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_fator")))
                        reg.ST_Fator = reader.GetString(reader.GetOrdinal("st_fator"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_indice")))
                        reg.VL_Indice = reader.GetDecimal(reader.GetOrdinal("vl_indice"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_registro")))
                        reg.ST_Registro = reader.GetString(reader.GetOrdinal("st_registro"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_unidade_orig")))
                        reg.DS_Unidade_Orig = reader.GetString(reader.GetOrdinal("ds_unidade_orig"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_unidade_dest")))
                        reg.DS_Unidade_Dest = reader.GetString(reader.GetOrdinal("ds_unidade_dest"));
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
    
        public string Gravar(TRegistro_CadConvUnidade vRegistro)
        {
            Hashtable hs = new Hashtable(4);
            hs.Add("@P_CD_UNIDADE_DEST", vRegistro.CD_Unidade_Dest);
            hs.Add("@P_CD_UNIDADE_ORIG", vRegistro.CD_Unidade_Orig);
            hs.Add("@P_ST_FATOR", vRegistro.ST_Fator);
            hs.Add("@P_VL_INDICE", vRegistro.VL_Indice);
            return this.executarProc("IA_EST_CONVERTE_UNID", hs);
        }

        public string Excluir(TRegistro_CadConvUnidade vRegistro)
        {
            Hashtable hs = new Hashtable(1);
            hs.Add("@P_CD_UNIDADE_ORIG", vRegistro.CD_Unidade_Orig);
            hs.Add("@P_CD_UNIDADE_DEST", vRegistro.CD_Unidade_Dest);
           return this.executarProc("EXCLUI_EST_CONVERTE_UNID", hs);
        }

        public decimal ConvertUnid(string vCD_Unid_Orig,
                                   string vCD_Unid_Dest,
                                   decimal vVl_Orig)
        {
            if (string.IsNullOrEmpty(vCD_Unid_Dest) || string.IsNullOrEmpty(vCD_Unid_Orig))
                return decimal.Zero;
            if (vCD_Unid_Orig != vCD_Unid_Dest)
            {
                TList_CadConvUnidade lConvUnid = Select(
                    new TpBusca[]
                    {
                            new TpBusca()
                            {
                                vNM_Campo = "a.cd_unidade_orig",
                                vOperador = "=",
                                vVL_Busca = "'" + vCD_Unid_Orig.Trim() + "'"
                            },
                            new TpBusca()
                            {
                                vNM_Campo = "a.cd_unidade_dest",
                                vOperador = "=",
                                vVL_Busca = "'" + vCD_Unid_Dest.Trim() + "'"
                            }
                    }, 0, string.Empty);
                if (lConvUnid.Count > 0)
                {
                    if (vCD_Unid_Dest.Trim().Equals(string.Empty))
                        throw new Exception("ERRO: Conversão de Unidade destino Inválida ou vazia !");
                    if (vCD_Unid_Orig.Trim().Equals(string.Empty))
                        throw new Exception("ERRO: Conversão de Unidade origem Inválida ou vazia !");
                    if (lConvUnid[0].ST_Fator.Trim() == "*")
                        return vVl_Orig * lConvUnid[0].VL_Indice;
                    else if (lConvUnid[0].ST_Fator.Trim() == "/")
                        return vVl_Orig / lConvUnid[0].VL_Indice;
                    else
                        throw new Exception("ERRO: Conversão de Unidades operador de conversão cadastrado para a unidade é inválido !");
                }
                else
                    throw new Exception("ERRO: Não foi encontrado nenhuma conversão de unidade para un orig: " + vCD_Unid_Orig + " e dest: " + vCD_Unid_Dest + "!");
            }
            else
                return vVl_Orig;
        }
    }
}