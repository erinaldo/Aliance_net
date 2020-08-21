using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Collections;
using System.Data.SqlClient;
using Utils;

namespace CamadaDados.Contabil.Cadastro
{
    #region CTB_DRE
    public class TList_CTB_DRE : List<TRegistro_CTB_DRE>
    {}
 
    public class  TRegistro_CTB_DRE  
    {
       private decimal? id_dre;
       public decimal? Id_dre
       {
           get { return id_dre; }
           set
           {
               id_dre = value;
               id_drestr = value.HasValue ? value.Value.ToString() : string.Empty;
           }
       }
       private string id_drestr;
       public string Id_drestr
       {
           get { return id_drestr; }
           set
           {
               id_drestr = value;
               try
               {
                   id_dre = Convert.ToDecimal(value);
               }
               catch
               { id_dre = null; }
           }
       }
       public string ds_dre
       { get; set; }
       public TList_CTB_paramDRE lParamDre
       { get; set; }
       public TList_CTB_paramDRE lParamDreDel
       { get; set; }

        public TRegistro_CTB_DRE()
        {
            this.id_dre = null;
            this.ds_dre = string.Empty;
            this.lParamDre = new TList_CTB_paramDRE();
            this.lParamDreDel = new TList_CTB_paramDRE();
        }
    }
    
    public class TCD_CTD_DRE : TDataQuery
   {
        public TCD_CTD_DRE()
        { }

        public TCD_CTD_DRE(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, Int32 vTop, string vNM_Campo, string vOrderBy)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();

            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine(" SELECT " + strTop + " a.ID_DRE, a.DS_DRE ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from TB_CTB_DRE a ");

            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                    sql.Append(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
            if (!string.IsNullOrEmpty(vOrderBy))
                sql.Append("Order by " + vOrderBy);

            return sql.ToString();
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, string.Empty, string.Empty), null);
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo, string.Empty), null);
        }

        public TList_CTB_DRE Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo, string vOrderBy)
        {
            TList_CTB_DRE lista = new TList_CTB_DRE();
            SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);

            try
            {
                reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo, vOrderBy));
                while (reader.Read())
                {
                    TRegistro_CTB_DRE reg = new TRegistro_CTB_DRE();

                    if (!reader.IsDBNull(reader.GetOrdinal("ID_DRE")))
                        reg.Id_dre = reader.GetDecimal(reader.GetOrdinal("ID_DRE"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_DRE")))
                        reg.ds_dre = reader.GetString(reader.GetOrdinal("DS_DRE"));
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

        public string Grava(TRegistro_CTB_DRE vRegistro)
        {
            Hashtable hs = new Hashtable(2);
            hs.Add("@P_ID_DRE", vRegistro.Id_dre);
            hs.Add("@P_DS_DRE", vRegistro.ds_dre.Trim());

            return this.executarProc("IA_CTB_DRE", hs);
        }

        public string Deleta(TRegistro_CTB_DRE vRegistro)
        {
            Hashtable hs = new Hashtable(1);
            hs.Add("@P_ID_DRE", vRegistro.Id_dre);

            return this.executarProc("EXCLUI_CTB_DRE", hs);
        }

        public DataTable RelDRE(string Id_dre)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("select a.id_dre, a.ds_dre, ");
            sql.AppendLine("SPACE((b.NIVEL-1)*5) + b.ds_param as ds_param, ");
            sql.AppendLine("c.cd_conta_ctb, d.ds_contactb, d.cd_classificacao ");

            sql.AppendLine("from tb_ctb_dre a ");
            sql.AppendLine("inner join tb_ctb_paramdre b ");
            sql.AppendLine("on a.id_dre = b.id_dre ");
            sql.AppendLine("left outer join TB_CTB_Param_X_ContaCTB c ");
            sql.AppendLine("on b.id_dre = c.id_dre ");
            sql.AppendLine("and b.id_param = c.id_param ");
            sql.AppendLine("left outer join TB_CTB_PlanoContas d ");
            sql.AppendLine("on c.cd_conta_ctb = d.cd_conta_ctb ");

            sql.AppendLine("where a.id_dre = " + Id_dre);

            sql.AppendLine("order by a.id_dre, b.classificacao ");

            return this.ExecutarBusca(sql.ToString(), null);
        }
   }
    #endregion 

    #region CTB_DRE_PARAMDRE
    public class TList_CTB_paramDRE : List<TRegistro_CTB_paramDRE>
    { }

    public class TRegistro_CTB_paramDRE
    {
        private decimal? id_dre;
        public decimal? Id_dre
       {
           get { return id_dre; }
           set
           {
               id_dre = value;
               id_drestr = value.HasValue ? value.Value.ToString() : string.Empty;
           }
       }
        private string id_drestr;
        public string Id_drestr
       {
           get { return id_drestr; }
           set
           {
               id_drestr = value;
               try
               {
                   id_dre = Convert.ToDecimal(value);
               }
               catch
               { id_dre = null; }
           }
       }
        private decimal? id_param;
        public decimal? Id_param
       {
           get { return id_param; }
           set
           {
               id_param = value;
               id_paramstr = value.HasValue ? value.Value.ToString() : string.Empty;
           }
       }
        private string id_paramstr;
        public string Id_paramstr
       {
           get { return id_paramstr; }
           set
           {
               id_paramstr = value;
               try
               {
                   id_param = Convert.ToDecimal(value);
               }
               catch
               { id_param = null; }
           }
       }
        public string ds_param
       { get; set; }
        private decimal? id_parampai;
        public decimal? Id_parampai
        {
            get { return id_parampai; }
            set
            {
                id_parampai = value;
                id_parampaistr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_parampaistr;
        public string Id_parampaistr
        {
            get { return id_parampaistr; }
            set
            {
                id_parampaistr = value;
                try
                {
                    id_parampai = decimal.Parse(value);
                }
                catch { id_parampai = null; }
            }
        }
        public string Ds_parampai
        { get; set; }
        private string tp_conta;
        public string Tp_conta
        {
            get { return tp_conta; }
            set
            {
                tp_conta = value;
                if (value.Trim().ToUpper().Equals("A"))
                    tipo_conta = "ANALITICA";
                else if (value.Trim().ToUpper().Equals("S"))
                    tipo_conta = "SINTETICA";
                else if (value.Trim().ToUpper().Equals("R"))
                    tipo_conta = "RESULTADO";
            }
        }
        private string tipo_conta;
        public string Tipo_conta
        {
            get { return tipo_conta; }
            set
            {
                tipo_conta = value;
                if (value.Trim().ToUpper().Equals("ANALITICA"))
                    tp_conta = "A";
                else if (value.Trim().ToUpper().Equals("SINTETICA"))
                    tp_conta = "S";
                else if (value.Trim().ToUpper().Equals("RESULTADO"))
                    tp_conta = "R";
            }
        }
        public string Classificacao
        { get; set; }
        private string operador;
        public string Operador
        {
            get { return operador; }
            set
            {
                operador = value;
                if (value.Trim().ToUpper().Equals("S"))
                    oper = "SOMAR";
                else if (value.Trim().ToUpper().Equals("D"))
                    oper = "DIMINUIR";
            }
        }
        private string oper;
        public string Oper
        {
            get { return oper; }
            set
            {
                oper = value;
                if (value.Trim().ToUpper().Equals("SOMAR"))
                    operador = "S";
                else if (value.Trim().ToUpper().Equals("DIMINUIR"))
                    operador = "D";
            }
        }
        public decimal Nivel
        { get; set; }
        public TList_CTB_param_x_contaCTB lparamConta
        {get;set;}
        public TList_CTB_param_x_contaCTB lparamContaDel
        { get; set; }

       public TRegistro_CTB_paramDRE()
       {
           this.id_param = null;
           this.id_dre = null;
           this.ds_param = string.Empty;
           this.id_parampai = null;
           this.id_parampaistr = string.Empty;
           this.Ds_parampai = string.Empty;
           this.tp_conta = string.Empty;
           this.tipo_conta = string.Empty;
           this.Classificacao = string.Empty;
           this.operador = string.Empty;
           this.oper = string.Empty;
           this.Nivel = decimal.Zero;
           lparamConta = new TList_CTB_param_x_contaCTB();
           lparamContaDel = new TList_CTB_param_x_contaCTB();
       }
    }

    public class TCD_CTD_paramDRE : TDataQuery
    {

        public TCD_CTD_paramDRE()
        { }

        public TCD_CTD_paramDRE(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, Int32 vTop, string vNM_Campo, string vOrderBy)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();

            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine(" SELECT " + strTop + " a.id_dre, a.id_param, a.id_parampai, ");
                sql.AppendLine("SPACE((a.NIVEL-1)*5) + a.ds_param as ds_param, ");
                sql.AppendLine("b.ds_param as ds_parampai, a.tp_conta, a.classificacao, a.operador, a.nivel ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("FROM  TB_CTB_ParamDRE a ");
            sql.AppendLine("left outer join TB_CTB_ParamDRE b ");
            sql.AppendLine("on a.id_dre = b.id_dre ");
            sql.AppendLine("and a.id_parampai = b.id_param ");

            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.Append(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                    cond = "and";
                }
            if (!string.IsNullOrEmpty(vOrderBy))
                sql.Append("Order by " + vOrderBy);

            return sql.ToString();
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, string.Empty, string.Empty), null);
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo, string.Empty), null);
        }

        public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
        {
            return this.ExecutarBuscaEscalar(this.SqlCodeBusca(vBusca, 1, vNM_Campo, string.Empty), null);
        }

        public TList_CTB_paramDRE Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo, string vOrderBy)
        {
            TList_CTB_paramDRE lista = new TList_CTB_paramDRE();
            SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);

            try
            {
                reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo, vOrderBy));
                while (reader.Read())
                {
                    TRegistro_CTB_paramDRE reg = new TRegistro_CTB_paramDRE();

                    if (!reader.IsDBNull(reader.GetOrdinal("ID_DRE")))
                        reg.Id_dre = reader.GetDecimal(reader.GetOrdinal("ID_DRE"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_param")))
                        reg.Id_param = reader.GetDecimal(reader.GetOrdinal("id_param"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_param")))
                        reg.ds_param = reader.GetString(reader.GetOrdinal("ds_param"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_parampai")))
                        reg.Id_parampai = reader.GetDecimal(reader.GetOrdinal("id_parampai"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_parampai")))
                        reg.Ds_parampai = reader.GetString(reader.GetOrdinal("ds_parampai"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_conta")))
                        reg.Tp_conta = reader.GetString(reader.GetOrdinal("tp_conta"));
                    if (!reader.IsDBNull(reader.GetOrdinal("classificacao")))
                        reg.Classificacao = reader.GetString(reader.GetOrdinal("classificacao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("operador")))
                        reg.Operador = reader.GetString(reader.GetOrdinal("operador"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nivel")))
                        reg.Nivel = reader.GetDecimal(reader.GetOrdinal("nivel"));
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

        public string Grava(TRegistro_CTB_paramDRE vRegistro)
        {
            Hashtable hs = new Hashtable(6);
            hs.Add("@P_ID_DRE", vRegistro.Id_dre);
            hs.Add("@P_ID_PARAM", vRegistro.Id_param);
            hs.Add("@P_DS_PARAM", vRegistro.ds_param.Trim());
            hs.Add("@P_ID_PARAMPAI", vRegistro.Id_parampai);
            hs.Add("@P_TP_CONTA", vRegistro.Tp_conta);
            hs.Add("@P_OPERADOR", vRegistro.Operador);

            return this.executarProc("IA_CTB_PARAMDRE", hs);
        }

        public string Deleta(TRegistro_CTB_paramDRE vRegistro)
        {
            Hashtable hs = new Hashtable(2);
            hs.Add("@P_ID_PARAM", vRegistro.Id_param);
            hs.Add("@P_ID_DRE", vRegistro.Id_dre);

            return this.executarProc("EXCLUI_CTB_PARAMDRE", hs);
        }
    }
    #endregion

    #region CTB_PARAM_X_CONTACTB
    public class TList_CTB_param_x_contaCTB : List<TRegistro_CTB_param_x_contaCTB>
   { }

    public class TRegistro_CTB_param_x_contaCTB
    {
        private decimal? id_dre;
        public decimal? Id_dre
       {
           get { return id_dre; }
           set
           {
               id_dre = value;
               id_drestr = value.HasValue ? value.Value.ToString() : string.Empty;
           }
       }
        private string id_drestr;
        public string Id_drestr
       {
           get { return id_drestr; }
           set
           {
               id_drestr = value;
               try
               {
                   id_dre = Convert.ToDecimal(value);
               }
               catch
               { id_dre = null; }
           }
       }
        private decimal? id_param;
        public decimal? Id_param
       {
           get { return id_param; }
           set
           {
               id_param = value;
               id_paramstr = value.HasValue ? value.Value.ToString() : string.Empty;
           }
       }
        private string id_paramstr;
        public string Id_paramstr
       {
           get { return id_paramstr; }
           set
           {
               id_paramstr = value;
               try
               {
                   id_param = Convert.ToDecimal(value);
               }
               catch
               { id_param = null; }
           }
       }
        private decimal? cd_conta_CTB;
        public decimal? Cd_conta_CTB
       {
           get { return cd_conta_CTB; }
           set
           {
               cd_conta_CTB = value;
               cd_conta_CTBstr = value.HasValue ? value.Value.ToString() : string.Empty;
           }
       }
        private string cd_conta_CTBstr;
        public string Cd_conta_CTBstr
       {
           get { return cd_conta_CTBstr; }
           set
           {
               cd_conta_CTBstr = value;
               try
               {
                   cd_conta_CTB = Convert.ToDecimal(value);
               }
               catch
               { cd_conta_CTB = null; }
           }
       }
        public string DS_Conta
       { get; set; }
        public string Cd_classificacao
        { get; set; }

        public TRegistro_CTB_param_x_contaCTB()
       {
           this.id_param = null;
           this.id_dre = null;
           this.cd_conta_CTB = null;
           this.DS_Conta = string.Empty;
           this.Cd_classificacao = string.Empty;
       }
   }

    public class TCD_CTB_param_x_contaCTB : TDataQuery
   {
        
        public TCD_CTB_param_x_contaCTB()
        { }

        public TCD_CTB_param_x_contaCTB(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, Int32 vTop, string vNM_Campo, string vOrderBy)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();

            if (string.IsNullOrEmpty(vNM_Campo))
                sql.AppendLine(" select a.ID_DRE,a.ID_Param, a.CD_Conta_CTB, b.ds_contactb, b.cd_classificacao ");
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from TB_CTB_Param_X_ContaCTB a ");
            sql.AppendLine("join TB_CTB_PlanoContas b ");
            sql.AppendLine("on b.CD_Conta_CTB = a.CD_Conta_CTB ");
            sql.AppendLine("inner join TB_CTB_ParamDRE c ");
            sql.AppendLine("on a.id_dre = c.id_dre ");
            sql.AppendLine("and a.id_param = c.id_param ");

            sql.AppendLine("where isnull(b.st_registro, 'A') <> 'C'");

            string cond = " and ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                    sql.Append(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
            if (!string.IsNullOrEmpty(vOrderBy))
                sql.Append("Order by " + vOrderBy);

            return sql.ToString();
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, string.Empty, string.Empty), null);
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo, string.Empty), null);
        }

        public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
        {
            return this.ExecutarBuscaEscalar(this.SqlCodeBusca(vBusca, 1, vNM_Campo, string.Empty), null);
        }

        public TList_CTB_param_x_contaCTB Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo, string vOrderBy)
        {
            TList_CTB_param_x_contaCTB lista = new TList_CTB_param_x_contaCTB();
            SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);

            try
            {
                reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo, vOrderBy));
                while (reader.Read())
                {
                    TRegistro_CTB_param_x_contaCTB reg = new TRegistro_CTB_param_x_contaCTB();

                    if (!reader.IsDBNull(reader.GetOrdinal("ID_DRE")))
                        reg.Id_dre = reader.GetDecimal(reader.GetOrdinal("ID_DRE"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_param")))
                        reg.Id_param = reader.GetDecimal(reader.GetOrdinal("id_param"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_conta_ctb")))
                        reg.Cd_conta_CTB = reader.GetDecimal(reader.GetOrdinal("cd_conta_ctb"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_contactb")))
                        reg.DS_Conta = reader.GetString(reader.GetOrdinal("ds_contactb"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_classificacao")))
                        reg.Cd_classificacao = reader.GetString(reader.GetOrdinal("cd_classificacao"));
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

        public string Grava(TRegistro_CTB_param_x_contaCTB vRegistro)
        {
            Hashtable hs = new Hashtable(3);
            hs.Add("@P_ID_DRE", vRegistro.Id_dre);
            hs.Add("@P_ID_PARAM", vRegistro.Id_param);
            hs.Add("@P_CD_CONTA_CTB", vRegistro.Cd_conta_CTB);

            return this.executarProc("IA_CTB_PARAM_X_CONTACTB", hs);
        }

        public string Deleta(TRegistro_CTB_param_x_contaCTB vRegistro)
        {
            Hashtable hs = new Hashtable(3);
            hs.Add("@P_ID_PARAM", vRegistro.Id_param);
            hs.Add("@P_ID_DRE", vRegistro.Id_dre);
            hs.Add("@P_CD_CONTA_CTB", vRegistro.Cd_conta_CTB);

            return this.executarProc("EXCLUI_CTB_PARAM_X_CONTACTB", hs);
        }
   }
      #endregion 
}
