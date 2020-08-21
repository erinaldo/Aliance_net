using System;
using System.Collections;
using System.Collections.Generic;
using Utils;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace CamadaDados.Fiscal
{
    
    public class TRegistro_CadObservacaoFiscal
    {
        
        public string Cd_observacaofiscal { get; set; }
        
        public string Ds_observacaofiscal { get; set; }
        
        public string Ds_sobre { get; set; }
        
        public string St_registro { get; set; }

        public TRegistro_CadObservacaoFiscal()
        {
            this.Cd_observacaofiscal = string.Empty;
            this.Ds_observacaofiscal = string.Empty;
            this.Ds_sobre = string.Empty;
            this.St_registro = "A";
        }
    }
    
    public class TCD_CadObservacaoFiscal : TDataQuery
    {
        private string SqlCodeBusca(TpBusca[] vBusca, Int16 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;

            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
                sql.AppendLine("Select " + strTop + " a.CD_ObservacaoFiscal, a.DS_ObservacaoFiscal, a.DS_Sobre, a.ST_Registro");
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("From TB_FIS_ObservacaoFiscal a ");
            sql.AppendLine("Where isNull(ST_Registro, 'A') <> 'C'");
            string cond = " and ";

            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
            return sql.ToString();
        }

        public override DataTable Buscar(TpBusca[] vBusca, Int16 vTop)
        {
            return this.ExecutarBusca(SqlCodeBusca(vBusca, vTop, ""), null);
        }

        public override Object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
        {
            return this.ExecutarBuscaEscalar(SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }

        public TList_CadObservacaoFiscal Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_CadObservacaoFiscal lista = new TList_CadObservacaoFiscal();
            SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);

            try
            {
                reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
                while (reader.Read())
                {
                    TRegistro_CadObservacaoFiscal reg = new TRegistro_CadObservacaoFiscal();
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_ObservacaoFiscal"))))
                        reg.Cd_observacaofiscal = reader.GetString(reader.GetOrdinal("CD_ObservacaoFiscal"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("DS_ObservacaoFiscal"))))
                        reg.Ds_observacaofiscal = reader.GetString(reader.GetOrdinal("DS_ObservacaoFiscal"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("DS_Sobre"))))
                        reg.Ds_sobre = reader.GetString(reader.GetOrdinal("DS_Sobre"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("ST_Registro"))))
                        reg.St_registro = reader.GetString(reader.GetOrdinal("ST_Registro"));

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

        public string gravarObFiscal(TRegistro_CadObservacaoFiscal val)
        {
            Hashtable hs = new Hashtable(4);
            hs.Add("@P_CD_OBSERVACAOFISCAL", val.Cd_observacaofiscal);
            hs.Add("@P_DS_OBSERVACAOFISCAL", val.Ds_observacaofiscal);
            hs.Add("@P_DS_SOBRE", val.Ds_sobre);
            hs.Add("@P_ST_REGISTRO", val.St_registro);
            return executarProc("IA_FIS_OBSERVACAOFISCAL", hs);

        }

        public string deletarObFiscal(TRegistro_CadObservacaoFiscal val)
        {
            Hashtable hs = new Hashtable(1);
            hs.Add("@P_CD_OBSERVACAOFISCAL", val.Cd_observacaofiscal);
            return executarProc("EXCLUI_FIS_OBSERVACAOFISCAL", hs);
        }
    }
    
    public class TList_CadObservacaoFiscal : List<TRegistro_CadObservacaoFiscal>
    { }


}
