using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using Utils;
using System.Data;
using System.Data.SqlClient;

namespace CamadaDados.Contabil.Cadastro
{
   public class TList_CadPlanoContas : List<TRegistro_CadPlanoContas>
   { }
   
   public class TRegistro_CadPlanoContas
   {
       private decimal? cd_conta_ctb;
       public decimal? Cd_conta_ctb
       {
           get { return cd_conta_ctb; }
           set
           {
               cd_conta_ctb = value;
               cd_conta_ctbstr = value.HasValue ? value.Value.ToString() : string.Empty;
           }
       }
       private string cd_conta_ctbstr;
       public string Cd_conta_ctbstr
       {
           get { return cd_conta_ctbstr; }
           set
           {
               cd_conta_ctbstr = value;
               try
               {
                   cd_conta_ctb = Convert.ToDecimal(value);
               }
               catch
               { cd_conta_ctb = null; }
           }
       }
       public string Cd_classificacao
       { get; set; }
       public string Ds_contactb
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
           }
       }
       private string st_deducao;
       public string St_deducao
       {
           get { return st_deducao; }
           set
           {
               st_deducao = value;
               st_deducaobool = value.Trim().ToUpper().Equals("S");
           }
       }
       private bool st_deducaobool;
       public bool St_deducaobool
       {
           get { return st_deducaobool; }
           set
           {
               st_deducaobool = value;
               if (value)
                   st_deducao = "S";
               else
                   st_deducao = "N";
           }
       }
       public decimal Nivelconta
       { get; set; }
       private decimal? cd_conta_ctbpai;
       public decimal? Cd_conta_ctbpai
       {
           get { return cd_conta_ctbpai; }
           set
           {
               cd_conta_ctbpai = value;
               cd_conta_ctbpaistr = value.HasValue ? value.Value.ToString() : string.Empty;
           }
       }
       private string cd_conta_ctbpaistr;
       public string Cd_conta_ctbpaistr
       {
           get { return cd_conta_ctbpaistr; }
           set
           {
               cd_conta_ctbpaistr = value;
               try
               {
                   cd_conta_ctbpai = Convert.ToDecimal(value);
               }
               catch
               { cd_conta_ctbpai = null; }
           }
       }
       public string Ds_contactb_pai
       { get; set; }
       public string Cd_classif_pai
       { get; set; }
       public decimal Nivelconta_pai { get; set; }

       private string natureza;
       public string Natureza
       {
           get { return natureza; }
           set
           {
               natureza = value;
               if (value.Trim().ToUpper().Equals("D"))
                   nat = "DEVEDORA";
               else if (value.Trim().ToUpper().Equals("C"))
                   nat = "CREDORA";
           }
       }
       private string nat;
       public string Nat
       {
           get { return nat; }
           set
           {
               nat = value;
               if (value.Trim().ToUpper().Equals("DEVEDORA"))
                   natureza = "D";
               else if (value.Trim().ToUpper().Equals("CREDORA"))
                   natureza = "C";
           }
       }
       private string st_registro;
       public string St_registro
       {
           get { return st_registro; }
           set
           {
               st_registro = value;
               if (value.Trim().ToUpper().Equals("A"))
                   status_registro = "ATIVO";
               else if (value.Trim().ToUpper().Equals("C"))
                   status_registro = "CANCELADO";
           }
       }
       private string status_registro;
       public string Status_registro
       {
           get { return status_registro; }
           set
           {
               status_registro = value;
               if (value.Trim().ToUpper().Equals("ATIVO"))
                   st_registro = "A";
               else if (value.Trim().ToUpper().Equals("CANCELADO"))
                   st_registro = "C";
           }
       }
       private DateTime? dt_alt;
       public DateTime? Dt_alt
       {
           get { return dt_alt; }
           set
           {
               dt_alt = value;
               dt_altstr = value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty;
           }
       }
       private string dt_altstr;
       public string Dt_altstr
       {
           get
           {
               try
               {
                   return DateTime.Parse(dt_altstr).ToString("dd/MM/yyyy");
               }
               catch { return string.Empty; }
           }
           set
           {
               dt_altstr = value;
               try
               {
                   dt_alt = DateTime.Parse(value);
               }
               catch { dt_alt = null; }
           }
       }
       private string tp_contasped;
       public string Tp_contasped
       {
           get { return tp_contasped; }
           set
           {
               tp_contasped = value;
               if (value.Trim().Equals("01"))
                   tipo_contasped = "CONTAS ATIVO";
               else if (value.Trim().Equals("02"))
                   tipo_contasped = "CONTAS PASSIVO";
               else if (value.Trim().Equals("03"))
                   tipo_contasped = "PATRIMONIO LIQUIDO";
               else if (value.Trim().Equals("04"))
                   tipo_contasped = "CONTAS RESULTADO";
               else if (value.Trim().Equals("05"))
                   tipo_contasped = "CONTAS COMPENSAÇÃO";
               else if (value.Trim().Equals("09"))
                   tipo_contasped = "OUTRAS";
           }
       }
       private string tipo_contasped;
       public string Tipo_contasped
       {
           get { return tipo_contasped; }
           set
           {
               tipo_contasped = value;
               if (value.Trim().ToUpper().Equals("CONTAS ATIVO"))
                   tp_contasped = "01";
               else if (value.Trim().ToUpper().Equals("CONTAS PASSIVO"))
                   tp_contasped = "02";
               else if (value.Trim().ToUpper().Equals("PATRIMONIO LIQUIDO"))
                   tp_contasped = "03";
               else if (value.Trim().ToUpper().Equals("CONTAS RESULTADO"))
                   tp_contasped = "04";
               else if (value.Trim().ToUpper().Equals("CONTAS COMPENSAÇÃO"))
                   tp_contasped = "05";
               else if (value.Trim().ToUpper().Equals("OUTRAS"))
                   tp_contasped = "09";
           }
       }
       public string Cd_referencia
       { get; set; }
       public string Ds_referencia
       { get; set; }

       public TRegistro_CadPlanoContas()
       {
           cd_conta_ctb = null;
           cd_conta_ctbstr = string.Empty;
           Cd_classificacao = string.Empty;
           Ds_contactb = string.Empty;
           tp_conta = string.Empty;
           tipo_conta = string.Empty;
           st_deducao = "N";
           st_deducaobool = false;
           Nivelconta = decimal.Zero;
           cd_conta_ctbpai = null;
           cd_conta_ctbpaistr = string.Empty;
           Ds_contactb_pai = string.Empty;
           Cd_classif_pai = string.Empty;
           Nivelconta_pai = decimal.Zero;
           natureza = string.Empty;
           nat = string.Empty;
           st_registro = "A";
           status_registro = "ATIVO";
           dt_alt = null;
           dt_altstr = string.Empty;
           tp_contasped = string.Empty;
           tipo_contasped = string.Empty;
           Cd_referencia = string.Empty;
           Ds_referencia = string.Empty;
       }
   }

   public class TCD_CadPlanoContas : TDataQuery
   {
       public TCD_CadPlanoContas()
       { }

       public TCD_CadPlanoContas(BancoDados.TObjetoBanco banco)
       { Banco_Dados = banco; }

       private string SqlCodeBusca(TpBusca[] vBusca, Int32 vTop, string vNM_Campo, string vOrderBy)
       {
           string strTop = string.Empty;
           if (vTop > 0)
               strTop = "TOP " + Convert.ToString(vTop);
           StringBuilder sql = new StringBuilder();

           if (string.IsNullOrEmpty(vNM_Campo))
           {
               sql.AppendLine(" SELECT " + strTop + "a.cd_conta_CTB, a.cd_classificacao, a.tp_contasped, ");
               sql.AppendLine("SPACE((a.NIVELCONTA-1)*5)+a.ds_contactb as ds_contactb, a.dt_alt, ");
               sql.AppendLine("a.tp_conta, a.st_registro, a.st_deducao, a.nivelconta, a.natureza, ");
               sql.AppendLine("a.cd_conta_ctbpai as cd_conta_ctbpai, b.ds_contaCTB as ds_contactbpai, b.nivelconta as nivelconta_pai, ");
               sql.AppendLine("b.cd_classificacao as cd_classif_pai, a.cd_referencia, c.nome as ds_referencia ");
           }
           else
               sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

           sql.AppendLine("FROM  TB_CTB_PlanoContas a ");
           sql.AppendLine("left outer join TB_CTB_PlanoContas b ");
           sql.AppendLine("on b.cd_conta_CTB = a.cd_conta_ctbpai ");
           sql.AppendLine("left outer join TB_CTB_PlanoReferencial c ");
           sql.AppendLine("on a.cd_referencia = c.cd_referencia ");

           sql.AppendLine("where isnull(a.st_registro, 'A') <> 'C'");

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
           return ExecutarBusca(SqlCodeBusca(vBusca, vTop, string.Empty, string.Empty), null);
       }

       public override DataTable Buscar(TpBusca[] vBusca, short vTop, string vNM_Campo)
       {
           return ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo, string.Empty), null);
       }

       public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
       {
           return ExecutarBuscaEscalar(SqlCodeBusca(vBusca, 1, vNM_Campo, ""), null);
       }

       public TList_CadPlanoContas Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo, string vOrderBy)
       {
           TList_CadPlanoContas lista = new TList_CadPlanoContas();
           SqlDataReader reader = null;
           bool podeFecharBco = false;
           if (Banco_Dados == null)
               podeFecharBco = CriarBanco_Dados(false);

           try
           {
               reader = ExecutarBusca(SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo, vOrderBy));
               while (reader.Read())
               {
                   TRegistro_CadPlanoContas reg = new TRegistro_CadPlanoContas();

                   if (!reader.IsDBNull(reader.GetOrdinal("CD_Conta_CTB")))
                       reg.Cd_conta_ctb = reader.GetDecimal(reader.GetOrdinal("CD_Conta_CTB"));
                   if (!reader.IsDBNull(reader.GetOrdinal("CD_Classificacao")))
                       reg.Cd_classificacao = reader.GetString(reader.GetOrdinal("CD_Classificacao"));
                   if (!reader.IsDBNull(reader.GetOrdinal("DS_ContaCTB")))
                       reg.Ds_contactb = reader.GetString(reader.GetOrdinal("DS_ContaCTB"));
                   if (!reader.IsDBNull(reader.GetOrdinal("TP_Conta")))
                       reg.Tp_conta = reader.GetString(reader.GetOrdinal("TP_Conta"));
                   if (!reader.IsDBNull(reader.GetOrdinal("ST_Registro")))
                       reg.St_registro = reader.GetString(reader.GetOrdinal("ST_Registro"));
                   if (!reader.IsDBNull(reader.GetOrdinal("ST_Deducao")))
                       reg.St_deducao = reader.GetString(reader.GetOrdinal("ST_Deducao"));
                   if (!reader.IsDBNull(reader.GetOrdinal("NivelConta")))
                       reg.Nivelconta = reader.GetDecimal(reader.GetOrdinal("NivelConta"));
                   if (!reader.IsDBNull(reader.GetOrdinal("CD_Conta_CTBPai")))
                       reg.Cd_conta_ctbpai = reader.GetDecimal(reader.GetOrdinal("CD_Conta_CTBPai"));
                   if (!reader.IsDBNull(reader.GetOrdinal("DS_ContaCTBPai")))
                       reg.Ds_contactb_pai = reader.GetString(reader.GetOrdinal("DS_ContaCTBPai"));
                   if (!reader.IsDBNull(reader.GetOrdinal("CD_Classif_Pai")))
                       reg.Cd_classif_pai = reader.GetString(reader.GetOrdinal("CD_Classif_Pai"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nivelconta_pai")))
                        reg.Nivelconta_pai = reader.GetDecimal(reader.GetOrdinal("nivelconta_pai"));
                   if (!reader.IsDBNull(reader.GetOrdinal("natureza")))
                       reg.Natureza = reader.GetString(reader.GetOrdinal("natureza"));
                   if (!reader.IsDBNull(reader.GetOrdinal("dt_alt")))
                       reg.Dt_alt = reader.GetDateTime(reader.GetOrdinal("dt_alt"));
                   if (!reader.IsDBNull(reader.GetOrdinal("tp_contasped")))
                       reg.Tp_contasped = reader.GetString(reader.GetOrdinal("tp_contasped"));
                   if (!reader.IsDBNull(reader.GetOrdinal("cd_referencia")))
                       reg.Cd_referencia = reader.GetString(reader.GetOrdinal("cd_referencia"));
                   if (!reader.IsDBNull(reader.GetOrdinal("ds_referencia")))
                       reg.Ds_referencia = reader.GetString(reader.GetOrdinal("ds_referencia"));
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

       public string Grava(TRegistro_CadPlanoContas vRegistro)
       {
           Hashtable hs = new Hashtable(10);
           hs.Add("@P_CD_CONTA_CTB", vRegistro.Cd_conta_ctb);
           hs.Add("@P_DS_CONTACTB", vRegistro.Ds_contactb.Trim());
           hs.Add("@P_CD_CLASSIFICACAO", vRegistro.Cd_classificacao);
           hs.Add("@P_TP_CONTA", vRegistro.Tp_conta);
           hs.Add("@P_ST_REGISTRO", vRegistro.St_registro);
           hs.Add("@P_ST_DEDUCAO", vRegistro.St_deducao);
           hs.Add("@P_CD_CONTA_CTBPAI", vRegistro.Cd_conta_ctbpai);
           hs.Add("@P_CD_REFERENCIA", vRegistro.Cd_referencia);
           hs.Add("@P_NATUREZA", vRegistro.Natureza);
           hs.Add("@P_TP_CONTASPED", vRegistro.Tp_contasped);

           return executarProc("IA_CTB_PLANOCONTAS", hs);
       }

       public string Deleta(TRegistro_CadPlanoContas vRegistro)
       {
           Hashtable hs = new Hashtable(1);
           hs.Add("@P_CD_CONTA_CTB", vRegistro.Cd_conta_ctb);

           return executarProc("EXCLUI_CTB_PLANOCONTAS", hs);
       }
   }
}
