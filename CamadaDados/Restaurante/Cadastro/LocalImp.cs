using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamadaDados.Restaurante.Cadastro
{
    public class TRegistro_LocalImp
    {
        public decimal? ID_LocalImp { get; set; } = decimal.Zero;
        public string DS_LocalImp { get; set; } = string.Empty;
        public string Porta_Imp { get; set; } = string.Empty;

        private string st_Imp = "E";
        public string St_Imp
        {
            get { return st_Imp; }
            set
            {
                st_Imp = value;
                if (value.Trim().ToUpper().Equals("0"))
                    status = "BEMATECH";
                else
                if (value.Trim().ToUpper().Equals("1"))
                    status = "ELGIN";
                else
                if (value.Trim().ToUpper().Equals("2"))
                    status = "EPSON"; 
            }
        }
        private string status = "ELGIN";
        public string Status
        {
            get { return status; }
            set
            {
                status = value;
                if (value.Trim().ToUpper().Equals("BEMATECH"))
                    st_Imp = "0";
                if (value.Trim().ToUpper().Equals("ELGIN"))
                    st_Imp = "1";
                if (value.Trim().ToUpper().Equals("EPSON"))
                    st_Imp = "2"; 
                //if (value.Trim().ToUpper().Equals("ENTREGA"))
                //    st_Imp = "E";
            }
        }



    }
    public class TList_LocalImp : List<TRegistro_LocalImp> { }


    public class TCD_LocalImp: TDataQuery
    {
        public TCD_LocalImp() { }

        public TCD_LocalImp(BancoDados.TObjetoBanco banco) { this.Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("select " + strTop + " a.id_localimp, a.ds_localimp, a.porta_imp, a.tp_impressora  ");

            }
            else
                sql.AppendLine(" Select " + strTop + "   " + vNM_Campo + " ");

            sql.AppendLine("from tb_res_localimp a");


            string cond = " where ";
            //     sql.AppendLine("where  ");
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                    cond = " and ";
                }
            return sql.ToString();
        }

        public override System.Data.DataTable Buscar(Utils.TpBusca[] vBusca, short vTop)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, string.Empty), null);
        }

        public override System.Data.DataTable Buscar(Utils.TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo), null);
        }

        public override object BuscarEscalar(Utils.TpBusca[] vBusca, string vNM_Campo)
        {
            return this.ExecutarBuscaEscalar(this.SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }

        public TList_LocalImp Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            bool podeFecharBco = false;
            TList_LocalImp lista = new TList_LocalImp();
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_LocalImp reg = new TRegistro_LocalImp();
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_LocalImp")))
                        reg.ID_LocalImp = reader.GetDecimal(reader.GetOrdinal("ID_LocalImp"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Porta_Imp")))
                        reg.Porta_Imp = reader.GetString(reader.GetOrdinal("Porta_Imp"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_LocalImp")))
                        reg.DS_LocalImp = reader.GetString(reader.GetOrdinal("DS_LocalImp"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_impressora")))
                        reg.St_Imp = reader.GetString(reader.GetOrdinal("tp_impressora"));

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

        public string Gravar(TRegistro_LocalImp val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(4);
            hs.Add("@P_DS_LOCALIMP", val.DS_LocalImp);
            hs.Add("@P_ID_LOCALIMP", val.ID_LocalImp);
            hs.Add("@P_TP_IMPRESSORA", val.St_Imp);
            hs.Add("@P_PORTA_IMP", val.Porta_Imp);



            return this.executarProc("IA_RES_LOCALIMP", hs);
        }

        public string Excluir(TRegistro_LocalImp val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(1);
            hs.Add("@P_ID_LOCALIMP", val.ID_LocalImp);

            return this.executarProc("EXCLUI_RES_PREVENDA", hs);
        }
    }
}
