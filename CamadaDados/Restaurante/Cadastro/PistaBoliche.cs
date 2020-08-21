using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Utils;

namespace CamadaDados.Restaurante.Cadastro
{
    public class TRegistro_PistaBoliche
    {
        public decimal Id_Pista { get; set; } = decimal.Zero;
        public string Ds_Pista { get; set; } = string.Empty;
        public string st_registro { get; set; } = string.Empty;
        public string Tp_servico { get; set; } = string.Empty;
    }

    public class TList_PistaBoliche : List<TRegistro_PistaBoliche>
    {
    }

    public class TCD_PistaBoliche : TDataQuery
    {
        public TCD_PistaBoliche() { }

        public TCD_PistaBoliche(BancoDados.TObjetoBanco banco) { this.Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
                sql.AppendLine("select " + strTop + " a.id_pista, a.ds_pista, a.st_registro, a.tp_servico ");
            else
                sql.AppendLine("select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from tb_res_pistaboliche a");

            string cond = " where ";
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

        public TList_PistaBoliche Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            bool podeFecharBco = false;
            TList_PistaBoliche listaa = new TList_PistaBoliche();
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_PistaBoliche rPista = new TRegistro_PistaBoliche();
                    if (!reader.IsDBNull(reader.GetOrdinal("Id_Pista")))
                        rPista.Id_Pista = reader.GetDecimal(reader.GetOrdinal("Id_Pista"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Ds_Pista")))
                        rPista.Ds_Pista = reader.GetString(reader.GetOrdinal("Ds_Pista"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ST_Registro")))
                        rPista.st_registro = reader.GetString(reader.GetOrdinal("ST_Registro"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Tp_servico")))
                        rPista.Tp_servico = reader.GetString(reader.GetOrdinal("Tp_servico"));
                    listaa.Add(rPista);
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

        public string Gravar(TRegistro_PistaBoliche val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(3);
            hs.Add("@P_ID_PISTA", val.Id_Pista);
            hs.Add("@P_DS_PISTA", val.Ds_Pista);
            hs.Add("@P_ST_REGISTRO", val.st_registro);
            hs.Add("@P_TP_SERVICO", val.Tp_servico);
            return this.executarProc("IA_RES_PISTABOLICHE", hs);
        }

        public string Excluir(TRegistro_PistaBoliche val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(1);
            hs.Add("@P_ID_PISTA", val.Id_Pista);

            return this.executarProc("EXCLUI_RES_PISTABOLICHE", hs);
        }

    }
}
