using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Utils;
using System.Drawing;

namespace CamadaDados.ConfigGer
{
    public class TList_RegParamGer : List<TRegistro_ParamGer>
    { }

    
    public class TRegistro_ParamGer
    {
        private int id_parametro;
        
        public int Id_parametro
        {
            get { return id_parametro; }
            set { id_parametro = value; }
        }

        private string ds_parametro;
        
        public string Ds_parametro
        {
            get { return ds_parametro; }
            set { ds_parametro = value; }
        }

        private string ds_finalidade;
        
        public string Ds_finalidade
        {
            get { return ds_finalidade; }
            set { ds_finalidade = value; }
        }

        private string tp_dado;
        
        public string Tp_dado
        {
            get { return tp_dado; }
            set { tp_dado = value; }
        }


        private string _VL_Bool_String;
        
        public string VL_Bool_String
        {
            get { return _VL_Bool_String; }
            set { _VL_Bool_String = value;
            if (value == "S")
            {
                _VL_Booleano = true;
            }
            else
            {
                if (value == "N")
                {
                  _VL_Booleano = false;
                }
            }
            }
        }

        private bool _VL_Booleano;
        
        public bool VL_Booleano
        {
            get { return _VL_Booleano; }
            set { _VL_Booleano = value;
                  if (value == true)
                  {
                       _VL_Bool_String = "S";
                  }
                  else
                  {
                      _VL_Bool_String = "N";
                  }
            }

        }


        //private bool vl_bool;

        private decimal vl_numerico;
        
        public decimal Vl_numerico
        {
            get { return vl_numerico; }
            set { vl_numerico = value; }
        }

        private string vl_string;
        
        public string Vl_string
        {
            get { return vl_string; }
            set { vl_string = value; }
        }

        private DateTime? vl_data;
        
        public DateTime? Vl_data
        {
            get { return vl_data; }
            set { vl_data = value; }
        }

        private Image imagem;
        public Image Imagem
        {
            get { return imagem; }
            set
            {
                imagem = value;
                if (imagem != null)
                {
                    using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
                    {
                        imagem.Save(ms, imagem.RawFormat);
                        img = ms.ToArray();
                    }
                }
            }
        }
        private byte[] img;
        public byte[] Img
        {
            get { return img; }
            set
            {
                img = value;
                if (value != null)
                    imagem = (Image)new ImageConverter().ConvertFrom(value);
            }
        }


        public TRegistro_ParamGer()
        {
            this.id_parametro = 0;
            this.ds_parametro = string.Empty;
            this.ds_finalidade = string.Empty;
            this.tp_dado = string.Empty;
            this.vl_numerico = decimal.Zero;
            this.vl_string = string.Empty;
            this.vl_data = null;
            this._VL_Bool_String = "N";
            this._VL_Booleano = false;
        }
    }

    public class TCD_ParamGer : TDataQuery
    {
        public TCD_ParamGer()
        { }

        public TCD_ParamGer(BancoDados.TObjetoBanco banco)
        {
            this.Banco_Dados = banco;
        }

        public override DataTable Buscar(TpBusca[] vBusca, Int16 vTop)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, ""), null);
        }

        public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
        {
            return ExecutarBuscaEscalar(SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }

        private string SqlCodeBusca(TpBusca[] vBusca, Int16 vTop, string vNM_Campo)
        {
            StringBuilder sql;
            string cond, strTop;
            Int16 i;
            strTop = "";
            if (vTop > 0)
                strTop = "   TOP   " + Convert.ToString(vTop);
            sql = new StringBuilder();
            if (vNM_Campo.Length == 0)
            {
                sql.AppendLine("  Select " + strTop + "    a.ID_Parametro, a.DS_Parametro, a.DS_Finalidade, ");
                sql.AppendLine("a.TP_Dado, isNull(a.Vl_Bool,'N') as Vl_Bool, a.Vl_Numerico, a.Vl_String, a.Vl_Data, a.DT_Cad, a.DT_Alt, a.VL_Imagem ");
            }
            else
                sql.AppendLine("  Select   " + strTop + "    " + vNM_Campo + " ");
            sql.AppendLine("   From TB_CFG_ParamGer a ");
            cond = " where ";
            if (vBusca != null)
                for (i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                    cond = " and ";
                }
            return sql.ToString();
        }

        public TList_RegParamGer Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_RegParamGer lista = new TList_RegParamGer();
            SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
            {
                this.CriarBanco_Dados(false);
                podeFecharBco = true;
            }

            try
            {
                if (string.IsNullOrEmpty(vNM_Campo))
                    reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), ""));
                else
                    reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));

                while (reader.Read())
                {
                    TRegistro_ParamGer CadParam = new TRegistro_ParamGer();
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Parametro")))
                        CadParam.Id_parametro = reader.GetInt32(reader.GetOrdinal("ID_Parametro"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Parametro")))
                        CadParam.Ds_parametro = reader.GetString(reader.GetOrdinal("DS_Parametro"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Finalidade")))
                        CadParam.Ds_finalidade = reader.GetString(reader.GetOrdinal("DS_Finalidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("TP_Dado")))
                        CadParam.Tp_dado = reader.GetString(reader.GetOrdinal("TP_Dado"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_Bool")))
                        CadParam.VL_Bool_String = reader.GetString(reader.GetOrdinal("Vl_Bool"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("Vl_Numerico"))))
                        CadParam.Vl_numerico = reader.GetDecimal(reader.GetOrdinal("Vl_Numerico"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("Vl_String"))))
                        CadParam.Vl_string = reader.GetString(reader.GetOrdinal("Vl_String"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("Vl_Data"))))
                        CadParam.Vl_data = reader.GetDateTime(reader.GetOrdinal("Vl_Data"));
                    if (!reader.IsDBNull(reader.GetOrdinal("VL_Imagem")))
                        CadParam.Img = (byte[])reader.GetValue(reader.GetOrdinal("VL_Imagem"));
                    lista.Add(CadParam);
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

        public string GravarParamGer(TRegistro_ParamGer val)
        {
            Hashtable hs = new Hashtable(9);

            hs.Add("@P_ID_PARAMETRO", val.Id_parametro);
            hs.Add("@P_DS_PARAMETRO", val.Ds_parametro);
            hs.Add("@P_DS_FINALIDADE", val.Ds_finalidade);
            
            hs.Add("@P_TP_DADO", val.Tp_dado);
            hs.Add("@P_VL_BOOL", val.VL_Bool_String);
            hs.Add("@P_VL_NUMERICO", val.Vl_numerico);
            
            hs.Add("@P_VL_STRING", val.Vl_string);
            hs.Add("@P_VL_DATA", val.Vl_data);
            hs.Add("@P_VL_IMAGEM", val.Img);

            return executarProc("IA_CFG_PARAMGER", hs);
        }

        public string DeletarParamGer(TRegistro_ParamGer val)
        {
            Hashtable hs = new Hashtable(1);
            hs.Add("@P_ID_PARAMETRO", val.Id_parametro);

            return this.executarProc("EXCLUI_CFG_PARAMGER", hs);
        }
    }
}
