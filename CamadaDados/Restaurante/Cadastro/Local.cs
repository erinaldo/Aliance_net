using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamadaDados.Restaurante.Cadastro
{
    public class TRegistro_Local
    {
        public decimal Id_Local { get; set; } = decimal.Zero;
        public string Ds_Local { get; set; } = string.Empty;
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
        public TList_Mesa lMesa { get; set; } = new TList_Mesa();
        public TList_Mesa lDelMesa { get; set; } = new TList_Mesa();

    }

    public class TList_Local : List<TRegistro_Local>
    {
    }

    public class TCD_Local : TDataQuery
    {
        public TCD_Local() { }

        public TCD_Local(BancoDados.TObjetoBanco banco) { this.Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("select " + strTop + " a.id_local,a.ds_local, a.st_registro ");

            }
            else
                sql.AppendLine(" Select " + strTop + "   " + vNM_Campo + " ");

            sql.AppendLine("from TB_RES_local a");



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

        public TList_Local Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            bool podeFecharBco = false;
            TList_Local lista = new TList_Local();
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_Local rega = new TRegistro_Local();
                    if (!reader.IsDBNull(reader.GetOrdinal("Ds_Local")))
                        rega.Ds_Local = reader.GetString(reader.GetOrdinal("Ds_Local"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Id_Local")))
                        rega.Id_Local= reader.GetDecimal(reader.GetOrdinal("Id_Local"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_registro")))
                        rega.st_registro= reader.GetString(reader.GetOrdinal("st_registro"));
                   


                    lista.Add(rega);
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

        public string Gravar(TRegistro_Local val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(6);
            hs.Add("@P_ID_LOCAL", val.Id_Local);
            hs.Add("@P_DS_LOCAL", val.Ds_Local);
            hs.Add("@P_ST_REGISTRO", val.st_registro);


            return this.executarProc("IA_RES_LOCAL", hs);
        }

        public string Excluir(TRegistro_Local val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(1);
            hs.Add("@P_ID_LOCAL", val.Id_Local);


            return this.executarProc("EXCLUI_RES_LOCAL", hs);
        }
    }




}
