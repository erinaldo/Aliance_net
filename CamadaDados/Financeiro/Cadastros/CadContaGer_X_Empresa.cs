using System;
using System.Collections.Generic;
using System.Text;
using Utils;
using CamadaDados;
using System.Collections;
using System.Data.SqlClient;
using System.Data;

namespace CamadaDados.Financeiro.Cadastros
{
    public class TList_CadContaGer_X_Empresa : List<TRegistro_CadContaGer_X_Empresa>
    { }

    
    public class TRegistro_CadContaGer_X_Empresa
    {
        
        public string CD_Contager
        { get; set; }
        
        public string DS_Contager
        { get; set; }
        
        public string CD_empresa
        { get; set; }
        
        public string NM_empresa
        { get; set; }
        
        public TRegistro_CadContaGer_X_Empresa()
        {
            this.CD_Contager = string.Empty;
            this.DS_Contager = string.Empty;
            this.CD_empresa = string.Empty;
            this.NM_empresa = string.Empty;
        }


    }

    public class TCD_CadContaGer_X_Empresa : TDataQuery
    {
        public TCD_CadContaGer_X_Empresa()
        { }

        public TCD_CadContaGer_X_Empresa(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }
      
        private string SqlCodeBusca(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
          {
              string strTop = string.Empty;

              if (vTop > 0)
                  strTop = "TOP " + Convert.ToString(vTop);

              StringBuilder sql = new StringBuilder();
              if (string.IsNullOrEmpty(vNM_Campo))
                  sql.AppendLine("Select " + strTop + " a.CD_ContaGer, b.DS_ContaGer, a.Cd_Empresa, c.NM_Empresa ");
              else
                  sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

              sql.AppendLine("from tb_fin_ContaGer_X_Empresa a");
              sql.AppendLine("left outer join TB_FIN_ContaGer b ");
            sql.AppendLine("on a.CD_ContaGer = b.CD_ContaGer ");
              sql.AppendLine("left outer join TB_DIV_Empresa c ");
            sql.AppendLine("on a.CD_Empresa = c.CD_Empresa ");

              string cond = " where ";
              if (vBusca != null)
                  for (int i = 0; i < (vBusca.Length); i++)
                  {
                      sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + ")");
                      cond = " and ";
                  }
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

        public TList_CadContaGer_X_Empresa Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
          {
              TList_CadContaGer_X_Empresa lista = new TList_CadContaGer_X_Empresa();
              SqlDataReader reader = null;
              bool podeFecharBco = false;

              if (Banco_Dados == null)
                  podeFecharBco = this.CriarBanco_Dados(false);

              try
              {
                    reader = ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo));
                  while (reader.Read())
                  {
                      TRegistro_CadContaGer_X_Empresa CadContaGer_X_Empresa = new TRegistro_CadContaGer_X_Empresa();

                      if (!reader.IsDBNull(reader.GetOrdinal("CD_CONTAGER")))
                          CadContaGer_X_Empresa.CD_Contager = reader.GetString(reader.GetOrdinal("CD_CONTAGER"));
                      if (!reader.IsDBNull(reader.GetOrdinal("DS_CONTAGER")))
                          CadContaGer_X_Empresa.DS_Contager = reader.GetString(reader.GetOrdinal("DS_CONTAGER"));
                      if (!reader.IsDBNull(reader.GetOrdinal("CD_EMPRESA")))
                          CadContaGer_X_Empresa.CD_empresa = reader.GetString(reader.GetOrdinal("CD_EMPRESA"));
                      if (!reader.IsDBNull(reader.GetOrdinal("NM_Empresa")))
                          CadContaGer_X_Empresa.NM_empresa = reader.GetString(reader.GetOrdinal("NM_EMPRESA"));

                      lista.Add(CadContaGer_X_Empresa);
                  }
                  return lista;
              }
              finally
              {
                  reader.Close();
                  reader.Dispose();
                  if (podeFecharBco)
                      this.deletarBanco_Dados();
              }
          }
      
        public string GravaContaGer_X_Empresa(TRegistro_CadContaGer_X_Empresa val)
          {
              Hashtable hs = new Hashtable();
              hs.Add("@P_CD_CONTAGER", val.CD_Contager);
              hs.Add("@P_CD_EMPRESA", val.CD_empresa);
              return executarProc("IA_FIN_CONTAGER_X_EMPRESA", hs);
          }
      
        public string DeletaContaGer_X_Empresa(TRegistro_CadContaGer_X_Empresa val)
          {
              Hashtable hs = new Hashtable();
              hs.Add("@P_CD_CONTAGER", val.CD_Contager);
              hs.Add("@P_CD_EMPRESA", val.CD_empresa);
              return executarProc("EXCLUI_FIN_CONTAGER_X_EMPRESA", hs);        

          }
    }
}
