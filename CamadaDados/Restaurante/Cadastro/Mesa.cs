using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamadaDados.Restaurante.Cadastro
{
    public class TRegistro_Mesa
    {
        public decimal Id_Mesa { get; set; } = decimal.Zero;
        public decimal Id_Local { get; set; } = decimal.Zero;
        public decimal id_cartao { get; set; } = decimal.Zero;
        public string  nr_cartao { get; set; } = string.Empty;
        public string Ds_Mesa { get; set; } = string.Empty;
        public string Nr_Mesa { get; set; } = string.Empty;
        public string ds_local { get; set; } = string.Empty;
        public string st_registro { get; set; } = "A";
        public bool status_bool
        {
            get
            {
                return st_registro.Equals("A");
            }
            set
            {
                if (value)
                    st_registro = "A";
                else
                    st_registro = "C";
            }
        }


        public string status_balcao { get; set; } = "N";
        public bool st_balcao
        {
            get
            {
                return status_balcao.Equals("S");
            }
            set
            {
                if (value)
                    status_balcao = "S";
                else
                    status_balcao = "N";
            }
        }
    }
    public class TList_Mesa : List<TRegistro_Mesa>
    {
    }



    public class TCD_Mesa : TDataQuery
    {
        public TCD_Mesa() { }

        public TCD_Mesa(BancoDados.TObjetoBanco banco) { this.Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("select " + strTop + " a.st_balcao, a.Id_Local, a.id_mesa, a.ds_mesa,a.nr_mesa, a.st_registro, b.ds_local ");
                sql.AppendLine(",id_cartao = (select top 1 x.id_cartao from tb_res_cartao x "); 
                sql.AppendLine("             where  x.id_mesa = a.id_mesa and x.id_local = a.id_local and isnull(x.st_Registro, 'F') = 'A'), ");
                sql.AppendLine("nr_cartao = (select top 1 x.nr_cartao from tb_res_cartao x  ");
                sql.AppendLine("            where x.id_mesa = a.id_mesa and x.id_local = a.id_local and isnull(x.st_Registro, 'F') = 'A')  ");
            }
            else
                sql.AppendLine(" Select " + strTop + "   " + vNM_Campo + " ");

            sql.AppendLine("from tb_res_mesa a");
            sql.AppendLine("join tb_res_local b on a.id_local = b.id_local");



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

        public TList_Mesa Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            bool podeFecharBco = false;
            TList_Mesa listaa = new TList_Mesa();
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_Mesa rega = new TRegistro_Mesa();
                    if (!reader.IsDBNull(reader.GetOrdinal("Id_Local")))
                        rega.Id_Local = reader.GetDecimal(reader.GetOrdinal("Id_Local"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Id_Mesa")))
                        rega.Id_Mesa = reader.GetDecimal(reader.GetOrdinal("Id_Mesa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Nr_Mesa")))
                        rega.Nr_Mesa = reader.GetString(reader.GetOrdinal("Nr_Mesa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_mesa")))
                        rega.Ds_Mesa = reader.GetString(reader.GetOrdinal("ds_mesa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_registro")))
                        rega.st_registro = reader.GetString(reader.GetOrdinal("st_registro"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_local")))
                        rega.ds_local = reader.GetString(reader.GetOrdinal("ds_local"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_cartao")))
                        rega.id_cartao = reader.GetDecimal(reader.GetOrdinal("id_cartao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_cartao")))
                        rega.nr_cartao = reader.GetString(reader.GetOrdinal("nr_cartao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_balcao")))
                        rega.status_balcao = reader.GetString(reader.GetOrdinal("st_balcao"));

                    listaa.Add(rega);
                }
            }
            finally
            {
                reader.Close();
                reader.Dispose();
                if (podeFecharBco)
                    this.deletarBanco_Dados();
            }
            return listaa;
        }

        public string Gravar(TRegistro_Mesa val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(6);
            hs.Add("@P_ID_LOCAL", val.Id_Local);
            hs.Add("@P_ID_MESA", val.Id_Mesa);
            hs.Add("@P_NR_MESA", val.Nr_Mesa);
            hs.Add("@P_DS_MESA", val.Ds_Mesa);
            hs.Add("@P_ST_REGISTRO", val.st_registro);
            hs.Add("@P_ST_BALCAO", val.status_balcao);

            return this.executarProc("IA_RES_MESA", hs);
        }

        public string Excluir(TRegistro_Mesa val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(1);
            hs.Add("@P_ID_LOCAL", val.Id_Local);
            hs.Add("@P_ID_MESA", val.Id_Mesa);

            return this.executarProc("EXCLUI_RES_MESA", hs);
        }
    }


}
