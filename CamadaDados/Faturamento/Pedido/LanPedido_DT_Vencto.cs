using System;
using System.Collections.Generic;
using System.Text;
using BancoDados;
using Utils;
using System.Data;
using System.Collections;
using System.Data.SqlClient;

namespace CamadaDados.Faturamento.Pedido
{
    public class TList_Pedido_DT_Vencto : List<TRegistro_Pedido_DT_Vencto>
    { }
    
    public class TRegistro_Pedido_DT_Vencto
    {
        public decimal Nr_Pedido
        { get; set; }
        private decimal? id_vencto;
        public decimal? Id_vencto
        {
            get { return id_vencto; }
            set
            {
                id_vencto = value;
                id_venctostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_venctostr;
        public string Id_venctostr
        {
            get { return id_venctostr; }
            set
            {
                id_venctostr = value;
                try
                {
                    id_vencto = decimal.Parse(value);
                }
                catch { id_vencto = null; }
            }
        }
        public decimal VL_Parcela
        { get; set; }
        public decimal VL_Entrada
        { get; set; }
        public decimal Vl_juro_fin
        { get; set; }
        private DateTime? dt_vencto;
        public DateTime? Dt_vencto
        {
            get{ return dt_vencto; }
            set
            {
                dt_vencto = value;
                dt_venctostr = value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty;
            }
        }
        private string dt_venctostr;
        public string Dt_venctostr
        {
            get
            {
                try
                {
                    return DateTime.Parse(dt_venctostr).ToString("dd/MM/yyyy");
                }catch { return string.Empty; }
            }
            set
            {
                dt_venctostr = value;
                try
                {
                    dt_vencto = DateTime.Parse(value);
                }catch { dt_vencto = null; }
            }
        }
   
        public TRegistro_Pedido_DT_Vencto()
        {
            Nr_Pedido = decimal.Zero;
            id_vencto = null;
            id_venctostr = string.Empty;
            dt_vencto = null;
            dt_venctostr = string.Empty;
            VL_Parcela = decimal.Zero;
            VL_Entrada = decimal.Zero;
            Vl_juro_fin = decimal.Zero;
        }
    }

    public class TCD_Pedido_DT_Vencto : TDataQuery
    {
        public TCD_Pedido_DT_Vencto()
        { }

        public TCD_Pedido_DT_Vencto(TObjetoBanco banco)
        { Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();

            if (string.IsNullOrEmpty(vNM_Campo))
                sql.AppendLine(" SELECT " + strTop + " a.nr_pedido, a.id_vencto, a.dt_vencto, a.vl_parcela "); 
            else
                sql.Append("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine(" FROM TB_FAT_Pedido_DTVencto a ");
            

            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.Append(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                    cond = " and ";
                }

            sql.AppendLine("order by a.dt_vencto asc ");

            return sql.ToString();
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, string.Empty), null);
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo), null);
        }

        public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
        {
            return ExecutarBuscaEscalar(SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }

        public TList_Pedido_DT_Vencto Select(TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            TList_Pedido_DT_Vencto lista = new TList_Pedido_DT_Vencto();
            SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);

            try
            {
                reader = ExecutarBusca(SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
                while (reader.Read())
                {
                    TRegistro_Pedido_DT_Vencto reg = new TRegistro_Pedido_DT_Vencto();
                    if (!reader.IsDBNull(reader.GetOrdinal("NR_Pedido")))
                        reg.Nr_Pedido = reader.GetDecimal(reader.GetOrdinal("NR_Pedido"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_vencto")))
                        reg.Id_vencto = reader.GetDecimal(reader.GetOrdinal("id_vencto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DT_Vencto")))
                        reg.Dt_vencto = reader.GetDateTime(reader.GetOrdinal("DT_Vencto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("VL_Parcela")))
                        reg.VL_Parcela = reader.GetDecimal(reader.GetOrdinal("VL_Parcela"));
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

        public string Gravar(TRegistro_Pedido_DT_Vencto val)
        {
            Hashtable hs = new Hashtable(4);
            hs.Add("@P_NR_PEDIDO", val.Nr_Pedido);
            hs.Add("@P_ID_VENCTO", val.Id_vencto);
            hs.Add("@P_DT_VENCTO", val.Dt_vencto);
            hs.Add("@P_VL_PARCELA", val.VL_Parcela);

            return executarProc("IA_FAT_PEDIDO_DTVENCTO", hs);
        }

        public string Excluir(TRegistro_Pedido_DT_Vencto val)
        {
            Hashtable hs = new Hashtable(1);
            hs.Add("@P_NR_PEDIDO", val.Nr_Pedido);

            return executarProc("EXCLUI_FAT_PEDIDO_DTVENCTO", hs);
        }
    }
}
