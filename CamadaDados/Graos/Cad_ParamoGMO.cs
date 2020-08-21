using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;

namespace CamadaDados.Graos
{
    public class TList_Cad_ParamGMO : List<TRegistro_Cad_ParamGMO>
    {
    }

  public class TRegistro_Cad_ParamGMO
  {
      
      public string Cd_empresa
      { get; set; }
      
      public string Nm_empresa
      { get; set; }
      
      public string Cd_historico_pgto
      { get; set; }
      
      public string Ds_historico_pgto
      { get; set; }
      
      public string Cd_historico_retencao
      { get; set; }
      
      public string Ds_historico_retencao
      { get; set; }
      
      public string Cd_contager
      { get; set; }
      
      public string Ds_contager
      { get; set; }
      
      public string Cd_portador
      { get; set; }
      
      public string Ds_portador
      { get; set; }

      public TRegistro_Cad_ParamGMO()
      {
          this.Cd_empresa = string.Empty;
          this.Nm_empresa = string.Empty;
          this.Cd_historico_pgto = string.Empty;
          this.Cd_historico_pgto = string.Empty;
          this.Cd_historico_retencao = string.Empty;
          this.Ds_historico_retencao = string.Empty;
          this.Cd_contager = string.Empty;
          this.Ds_contager = string.Empty;
          this.Cd_portador = string.Empty;
          this.Ds_portador = string.Empty;
      }
  }

  public class TCD_Cad_ParamGMO : TDataQuery
  {
      public TCD_Cad_ParamGMO()
      { }

      public TCD_Cad_ParamGMO(BancoDados.TObjetoBanco banco)
      { this.Banco_Dados = banco; }

      private string SqlCodeBusca(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
      {
          string strTop = string.Empty;
          if (vTop > 0)
              strTop = "TOP " + Convert.ToString(vTop);
          StringBuilder sql = new StringBuilder();

          if (string.IsNullOrEmpty(vNM_Campo))
          {
              sql.AppendLine("select " + strTop + " a.CD_Empresa, b.NM_Empresa, ");
              sql.AppendLine("a.CD_Historico_Pgto, c.DS_Historico as ds_historico_pgto, ");
              sql.AppendLine("a.CD_Historico_Retencao, d.DS_Historico as ds_historico_retencao, ");
              sql.AppendLine("a.CD_ContaGer, e.DS_ContaGer, ");
              sql.AppendLine("a.CD_Portador, f.DS_Portador ");
          }
          else
              sql.AppendLine("SELECT " + strTop + " " + vNM_Campo + " ");

          sql.AppendLine("from TB_GRO_ParamGMO a ");
          sql.AppendLine("inner join TB_DIV_Empresa b ");
          sql.AppendLine("on a.CD_Empresa = b.CD_Empresa ");
          sql.AppendLine("inner join TB_FIN_Historico c ");
          sql.AppendLine("on a.CD_Historico_Pgto = c.CD_Historico ");
          sql.AppendLine("inner join TB_FIN_Historico d ");
          sql.AppendLine("on a.CD_Historico_Retencao = d.CD_Historico ");
          sql.AppendLine("inner join TB_FIN_ContaGer e ");
          sql.AppendLine("on a.CD_ContaGer = e.CD_ContaGer ");
          sql.AppendLine("inner join TB_FIN_Portador f ");
          sql.AppendLine("on a.CD_Portador = f.CD_Portador ");

          string cond = " and ";
          if (vBusca != null)
              for (int i = 0; i < (vBusca.Length); i++)
              {
                  sql.Append(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                  cond = " and ";
              }
          
          return sql.ToString();
      }

      public override System.Data.DataTable Buscar(TpBusca[] vBusca, short vTop)
      {
          return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, ""), null);
      }

      public override System.Data.DataTable Buscar(TpBusca[] vBusca, short vTop, string vNM_Campo)
      {
          return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo), null);
      }

      public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
      {
          return this.ExecutarBuscaEscalar(this.SqlCodeBusca(vBusca, 1, vNM_Campo), null);
      }

      public TList_Cad_ParamGMO Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
      {
          TList_Cad_ParamGMO lista = new TList_Cad_ParamGMO();
          bool podeFecharBco = false;
          if (Banco_Dados == null)
              podeFecharBco = this.CriarBanco_Dados(false);
          System.Data.SqlClient.SqlDataReader reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
          try
          {
              while (reader.Read())
              {
                  TRegistro_Cad_ParamGMO reg = new TRegistro_Cad_ParamGMO();
                  if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                      reg.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                  if (!reader.IsDBNull(reader.GetOrdinal("nm_empresa")))
                      reg.Nm_empresa = reader.GetString(reader.GetOrdinal("nm_empresa"));
                  if (!reader.IsDBNull(reader.GetOrdinal("cd_Historico_Pgto")))
                      reg.Cd_historico_pgto = reader.GetString(reader.GetOrdinal("cd_Historico_Pgto"));
                  if (!reader.IsDBNull(reader.GetOrdinal("ds_Historico_Pgto")))
                      reg.Ds_historico_pgto = reader.GetString(reader.GetOrdinal("ds_Historico_Pgto"));
                  if (!reader.IsDBNull(reader.GetOrdinal("cd_Historico_Retencao")))
                      reg.Cd_historico_retencao = reader.GetString(reader.GetOrdinal("cd_Historico_Retencao"));
                  if (!reader.IsDBNull(reader.GetOrdinal("ds_Historico_Retencao")))
                      reg.Ds_historico_retencao = reader.GetString(reader.GetOrdinal("ds_Historico_Retencao"));
                  if (!reader.IsDBNull(reader.GetOrdinal("cd_Contager")))
                      reg.Cd_contager = reader.GetString(reader.GetOrdinal("cd_Contager"));
                  if (!reader.IsDBNull(reader.GetOrdinal("ds_Contager")))
                      reg.Ds_contager = reader.GetString(reader.GetOrdinal("ds_Contager"));
                  if (!reader.IsDBNull(reader.GetOrdinal("cd_Portador")))
                      reg.Cd_portador = reader.GetString(reader.GetOrdinal("cd_Portador"));
                  if (!reader.IsDBNull(reader.GetOrdinal("ds_portador")))
                      reg.Ds_portador = reader.GetString(reader.GetOrdinal("ds_portador"));

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

      public string GravaParamGMO(TRegistro_Cad_ParamGMO vRegistro)
      {
          System.Collections.Hashtable hs = new System.Collections.Hashtable(5);
          hs.Add("@P_CD_EMPRESA", vRegistro.Cd_empresa);
          hs.Add("@P_CD_HISTORICO_PGTO", vRegistro.Cd_historico_pgto);
          hs.Add("@P_CD_HISTORICO_RETENCAO", vRegistro.Cd_historico_retencao);
          hs.Add("@P_CD_CONTAGER", vRegistro.Cd_contager);
          hs.Add("@P_CD_PORTADOR", vRegistro.Cd_portador);

          return this.executarProc("IA_GRO_PARAMGMO", hs);
      }

      public string DeletaParamGMO(TRegistro_Cad_ParamGMO vRegistro)
      {
          System.Collections.Hashtable hs = new System.Collections.Hashtable(4);
          hs.Add("@P_CD_EMPRESA", vRegistro.Cd_empresa);

          return this.executarProc("EXCLUI_GRO_PARAMGMO", hs);
      }
  }
}
