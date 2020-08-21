using System;
using System.Collections.Generic;
using System.Text;
using Utils;
using System.Data;
using System.Data.SqlClient;
using System.Collections;

namespace CamadaDados.Estoque.Cadastros
{
    public class TList_CadGrupoProduto : List <TRegistro_CadGrupoProduto>, IComparer<TRegistro_CadGrupoProduto>
    {
        #region IComparer<TRegistro_CadGrupoProduto> Members
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

        public TList_CadGrupoProduto()
        { }

        public TList_CadGrupoProduto(System.ComponentModel.PropertyDescriptor Prop,
                                     System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_CadGrupoProduto value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_CadGrupoProduto x, TRegistro_CadGrupoProduto y)
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
    
    public class TRegistro_CadGrupoProduto
    {
        public string status_obs { get; set; } = "N";
        public bool st_obs
        {
            get
            {
                if (status_obs.Equals("S"))
                    return true;
                else
                    return false;
            }
            set
            {
                if (value)
                    status_obs = "S";
                else
                    status_obs = "N";
            }
        }
        public string menor_idade { get; set; } = "N";
        public bool st_menor_idade
        {
            get
            {
                if (menor_idade.Equals("S"))
                    return true;
                else
                    return false;
            }
            set
            {
                if (value)
                    menor_idade = "S";
                else
                    menor_idade = "N";
            }
        }
        public string CD_Grupo { get; set; }
        public string DS_Grupo { get; set; }
        public decimal Nivel{get; set;}
        private string _Tp_Grupo;
        public string Tp_Grupo
        {
          get { return _Tp_Grupo; }
          set { 
                  _Tp_Grupo = value; 
            
                  if (_Tp_Grupo == "A")
                  {
                    _Tp_Grupo_Extendido = "A - Analítico";
                  }
                  else
                  {
                        _Tp_Grupo_Extendido = "S - Sintético";
                  }
          
              }
        }
        private string _Tp_Grupo_Extendido;
        public string Tp_Grupo_Extendido
        {
          get { return _Tp_Grupo_Extendido; }
          set { 
              _Tp_Grupo_Extendido = value; 
          
               if (_Tp_Grupo_Extendido == "A - Analítico")
                {
                    _Tp_Grupo = "A";
                }
                else
                {
                        _Tp_Grupo = "S";
                }
          }
        }

        public string ST_Registro { get; set; }
        public string CD_Grupo_Pai { get; set; }
        public string DS_Grupo_Pai{ get; set;  }
        public bool St_processar { get; set; }


        private string _QT_vl_bi;
        public string QT_vl_bi
        {
            get { return _QT_vl_bi; }
            set
            {
                _QT_vl_bi = value;

                if (_QT_vl_bi == "Q")
                {
                    _QT_vl_bi_Extendido = "Q - Quantidade";
                }
                else
                {
                    _QT_vl_bi_Extendido = "V - Valor";
                }

            }
        }
        private string _QT_vl_bi_Extendido;
        public string QT_vl_bi_Extendido
        {
            get { return _QT_vl_bi_Extendido; }
            set
            {
                _QT_vl_bi_Extendido = value;

                if (_QT_vl_bi_Extendido == "Q - Quantidade")
                {
                    _QT_vl_bi = "Q";
                }
                else if (_QT_vl_bi_Extendido == "V - Valor")
                {
                    _QT_vl_bi = "V";
                }
                else
                {
                    _QT_vl_bi = string.Empty;
                }
            }
        } 


        public TRegistro_CadGrupoProduto()
        { 
            CD_Grupo = string.Empty;
            DS_Grupo = string.Empty;
            Nivel = decimal.Zero;
            Tp_Grupo = string.Empty;
            Tp_Grupo_Extendido = string.Empty;
            QT_vl_bi = string.Empty;
            QT_vl_bi_Extendido = string.Empty;
            ST_Registro = "A";
            CD_Grupo_Pai = string.Empty;
            DS_Grupo_Pai = string.Empty;
            St_processar = false;
        }
    }

    public class TCD_CadGrupoProduto : TDataQuery
    {
        public TCD_CadGrupoProduto()
        { }

        public TCD_CadGrupoProduto(BancoDados.TObjetoBanco banco)
        { Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();

            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("SELECT " + strTop + "  a.ST_ProibidoMenores,a.ST_OBSITEM, a.cd_grupo, rtrim(a.ds_grupo) as ds_grupo, ");
                sql.AppendLine("a.nivel, a.tp_grupo, a.qt_vl_bi, a.st_registro, a.cd_grupo_pai, ");
                sql.AppendLine("rtrim(b.ds_grupo) as ds_grupo_pai, a.ST_OBSITEM ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("FROM TB_EST_GrupoProduto a ");
            sql.AppendLine("left outer join TB_EST_GrupoProduto b ");
            sql.AppendLine("on b.cd_grupo = a.cd_grupo_pai");

            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.Append(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                    cond = " and ";
                }
            sql.Append("Order by a.cd_grupo asc");
            return sql.ToString();
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, ""), null);
        }

        public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
        {
            return executarEscalar(SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }

        public TList_CadGrupoProduto Select(TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            TList_CadGrupoProduto lista = new TList_CadGrupoProduto();
            SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);

            try
            {
                reader = ExecutarBusca(SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
                while (reader.Read())
                {
                    TRegistro_CadGrupoProduto reg = new TRegistro_CadGrupoProduto();
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_grupo")))
                        reg.CD_Grupo = reader.GetString(reader.GetOrdinal("cd_grupo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_grupo")))
                        reg.DS_Grupo = reader.GetString(reader.GetOrdinal("ds_grupo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nivel")))
                        reg.Nivel = reader.GetDecimal(reader.GetOrdinal("nivel"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_grupo")))
                        reg.Tp_Grupo = reader.GetString(reader.GetOrdinal("tp_grupo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("qt_vl_bi")))
                        reg.QT_vl_bi = reader.GetString(reader.GetOrdinal("qt_vl_bi"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_grupo_pai")))
                        reg.CD_Grupo_Pai = reader.GetString(reader.GetOrdinal("cd_grupo_pai"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_grupo_pai")))
                        reg.DS_Grupo_Pai = reader.GetString(reader.GetOrdinal("ds_grupo_pai"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_registro")))
                        reg.ST_Registro = reader.GetString(reader.GetOrdinal("st_registro"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ST_ProibidoMenores")))
                        reg.menor_idade = reader.GetString(reader.GetOrdinal("ST_ProibidoMenores"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ST_ObsItem")))
                        reg.status_obs = reader.GetString(reader.GetOrdinal("ST_ObsItem"));


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

        public string Grava(TRegistro_CadGrupoProduto vRegistro)
        {
            Hashtable hs = new Hashtable(6);
            hs.Add("@P_CD_GRUPO", vRegistro.CD_Grupo);
            hs.Add("@P_DS_GRUPO", vRegistro.DS_Grupo.ToString().Trim());
            hs.Add("@P_NIVEL", vRegistro.Nivel);
            hs.Add("@P_TP_GRUPO", vRegistro.Tp_Grupo);
            hs.Add("@P_CD_GRUPO_PAI", vRegistro.CD_Grupo_Pai);
            hs.Add("@P_ST_REGISTRO", vRegistro.ST_Registro);
            hs.Add("@P_QT_VL_BI", vRegistro.QT_vl_bi);
            hs.Add("@P_ST_PROIBIDOMENORES", vRegistro.menor_idade); 
            hs.Add("@P_ST_OBSITEM", vRegistro.status_obs); 
            return executarProc("IA_EST_GRUPOPRODUTO", hs);
        }

        public string Deleta(TRegistro_CadGrupoProduto vRegistro)
        {
            Hashtable hs = new Hashtable(1);
            hs.Add("@P_CD_GRUPO", vRegistro.CD_Grupo);
            return executarProc("EXCLUI_EST_GrupoProduto", hs);
        }

    }
}