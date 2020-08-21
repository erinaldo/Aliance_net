using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;
using System.Data.SqlClient;
using System.Collections;
using System.Data;

namespace CamadaDados.Financeiro.Cadastros
{
    public class TList_CadMotivoInativo : List<TRegistro_CadMotivoInativo>
    { }

    
    public class TRegistro_CadMotivoInativo
    {
        private decimal? id_motivo;
        
        public decimal? ID_Motivo
        {
            get { return id_motivo; }
            set
            {
                id_motivo = value;
                id_motivostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_motivostr;
        
        public string Id_motivostr
        {
            get { return id_motivostr; }
            set
            {
                id_motivostr = value;
                try
                {
                    id_motivo = Convert.ToDecimal(value);
                }
                catch
                { id_motivo = null; }
            }
        }
        
        public string DS_Motivo
        { get; set; }
        

        public TRegistro_CadMotivoInativo()
        {
            this.ID_Motivo = null;
            this.id_motivostr = string.Empty;
            this.DS_Motivo = string.Empty;
        }
    }

    public class TCD_CadMotivoInativo : TDataQuery
    {
        public TCD_CadMotivoInativo()
        { }

        public TCD_CadMotivoInativo(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, Int16 vTop, string vNM_Campo)
        {
            string cond = " "; string strTop;
            int i;
            strTop = " ";

            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (vNM_Campo.Trim().Equals(""))
            {

                sql.AppendLine("select " + strTop + " a.ID_Motivo, a.DS_Motivo,");
                sql.AppendLine("a.DT_Cad, a.DT_Alt");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from tb_fin_motivoinativo a");

            cond = " where ";

            if (vBusca != null)
                for (i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + ")");
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

        public TList_CadMotivoInativo Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_CadMotivoInativo lista = new TList_CadMotivoInativo();
            SqlDataReader reader;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
            {
                this.CriarBanco_Dados(false);
                podeFecharBco = true;
            }
            reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_CadMotivoInativo reg = new TRegistro_CadMotivoInativo();
                    if (!(reader.IsDBNull(reader.GetOrdinal("ID_Motivo"))))
                        reg.ID_Motivo = reader.GetDecimal(reader.GetOrdinal("ID_Motivo"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("DS_Motivo"))))
                        reg.DS_Motivo = reader.GetString(reader.GetOrdinal("DS_Motivo"));
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

        public string GravarMotivoInativo(TRegistro_CadMotivoInativo val)
        {
            Hashtable hs = new Hashtable(2);
            hs.Add("@P_ID_MOTIVO", val.ID_Motivo);
            hs.Add("@P_DS_MOTIVO", val.DS_Motivo);

            return this.executarProc("IA_FIN_MOTIVOINATIVO", hs);
        }

        public string DeletarMotivoInativo(TRegistro_CadMotivoInativo val)
        {
            Hashtable hs = new Hashtable(1);
            hs.Add("@P_ID_MOTIVO", val.ID_Motivo);

            return this.executarProc("EXCLUI_FIN_MOTIVOINATIVO", hs);
        }
    }
}
