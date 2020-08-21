using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Utils;
using CamadaDados.Financeiro.Cadastros;



namespace CamadaDados.Fazenda.Cadastros
{
    public class TList_CadAtividadeCCusto : List<TRegistro_CadAtividadeCCusto>
    { }
    public class TRegistro_CadAtividadeCCusto
    {
        private decimal? id_atividade;
        public decimal? Id_atividade
        {
            get { return id_atividade; }
            set
            {
                id_atividade = value;
                id_atiString = value.ToString();
            }
        }
        
        private string id_atiString;
        public string Id_atiString
        {
            get{ return id_atiString; }
            set
            {
                id_atiString = value;
                try
                {
                    id_atividade = Convert.ToDecimal(value);
                }
                catch
                {
                    id_atividade = null;
                }
            }
        }
        
        public string ds_atividade { get; set; }
        
        private string cd_ccusto;
        public string Cd_ccusto
        {
            get { return cd_ccusto; }
            set { cd_ccusto = value; }
        }
        
        private string _ds_ccusto;
        public string Ds_ccusto
        {
            get { return _ds_ccusto; }
            set { _ds_ccusto = value; }
        }


        public TRegistro_CadAtividadeCCusto()
        {
            this.id_atividade = 0;
            this.id_atiString = "";
            this.cd_ccusto = "";
            this.ds_atividade = "";            
        }
    }
    public class TCD_CadAtividadeCCusto : TDataQuery
    {
        private string SqlCodeBusca(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = "";
            if (vTop > 0)
                strTop = " TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();
            if (vNM_Campo.Length == 0)
                sql.AppendLine(" select " + strTop + "a.id_atividade, a.cd_ccusto, C.ds_ccusto ");
            
            else
                sql.AppendLine(" select " + strTop + " " + vNM_Campo + " ");
            sql.AppendLine(" from TB_FAZ_ATIV_X_CCUSTO a ");
            sql.AppendLine(" inner join TB_FAZ_ATIVIDADE b ");
            sql.AppendLine(" on b.id_atividade = a.id_atividade ");
            sql.AppendLine(" right join TB_FIN_CENTROCUSTO c ");
            sql.AppendLine(" on c.cd_ccusto = a.cd_ccusto ");

            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < vBusca.Length; i++)
                {
                    sql.Append(cond + "( " + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                    cond = " AND ";
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
        
        public TList_CadAtividadeCCusto Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_CadAtividadeCCusto lista = new TList_CadAtividadeCCusto();

            SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
            {
                this.CriarBanco_Dados(false);
                podeFecharBco = true;
            }
            try
            {
                reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
                while (reader.Read())
                {
                    TRegistro_CadAtividadeCCusto reg = new TRegistro_CadAtividadeCCusto();
                    if (!(reader.IsDBNull(reader.GetOrdinal("ID_Atividade"))))
                        reg.Id_atividade = reader.GetDecimal(reader.GetOrdinal("ID_Atividade"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_CCusto"))))
                        reg.Cd_ccusto = reader.GetString(reader.GetOrdinal("CD_CCusto"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("ds_ccusto"))))
                        reg.Ds_ccusto = reader.GetString(reader.GetOrdinal("ds_ccusto"));

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
        
        public string gravarAtividade(TRegistro_CadAtividadeCCusto val)
        {
            Hashtable hs = new Hashtable(2);
            hs.Add("@P_ID_ATIVIDADE", val.Id_atividade);
            hs.Add("@P_CD_CCUSTO", val.Cd_ccusto);
            return executarProc("IA_FAZ_ATIV_X_CCUSTO", hs);
        }
        
        public string deletarAtividade(TRegistro_CadAtividadeCCusto val)
        {
            Hashtable hs = new Hashtable(1);
            hs.Add("@P_ID_ATIVIDADE", val.Id_atividade);
            hs.Add("@P_CD_CCUSTO", val.Cd_ccusto);
            return executarProc("EXCLUI_FAZ_ATIV_X_CCUSTO", hs);
        }
    }
}
