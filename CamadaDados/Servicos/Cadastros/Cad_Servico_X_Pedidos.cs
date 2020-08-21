using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Collections;
using System.Data.SqlClient;
using Utils;
using BancoDados;
using Querys;


namespace CamadaDados.Servicos.Cadastros
{
    public class TList_Servico_X_Pedidos : List<TRegistro_Servico_X_Pedidos>
    { }

    public class TRegistro_Servico_X_Pedidos
    {
        private decimal _ID_OS;
        public decimal ID_OS
        {
            get { return _ID_OS; }
            set { _ID_OS = value; }
        }

        private string _CD_Empresa;
        public string CD_Empresa
        {
            get { return _CD_Empresa; }
            set { _CD_Empresa = value; }
        }

        private decimal _NR_Pedido;
        public decimal NR_Pedido
        {
            get { return _NR_Pedido; }
            set { _NR_Pedido = value; }
        }

        private string _TP_Pedido;
        public string TP_Pedido
        {
            get { return _TP_Pedido; }
            set { _TP_Pedido = value; }
        }


        public TRegistro_Servico_X_Pedidos()
        {
            _ID_OS = decimal.Zero;
            _CD_Empresa = string.Empty;
            _NR_Pedido = decimal.Zero;
            _TP_Pedido = string.Empty;
        }

    }

    public class TCD_Servico_X_Pedidos : TDataQuery
    {
        private string SqlCodeBusca(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = "";
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();

            if (vNM_Campo.Trim().Equals(string.Empty))
            {
                sql.AppendLine(" SELECT " + strTop  );
                sql.AppendLine(" a.ID_OS, a.CD_Empresa, a.NR_Pedido, a.TP_Pedido ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine(" From  ");
            sql.AppendLine(" TB_OSE_SERVICO_X_PEDIDOS A ");
            
            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.Append(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
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

        public TList_Servico_X_Pedidos Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_Servico_X_Pedidos lista = new TList_Servico_X_Pedidos();
            bool podeFecharBco = false;
            if (Banco_Dados == null)
            {
                this.CriarBanco_Dados(false);
                podeFecharBco = true;
            }

            SqlDataReader reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_Servico_X_Pedidos reg = new TRegistro_Servico_X_Pedidos();
                    if (!(reader.IsDBNull(reader.GetOrdinal("ID_OS"))))
                        reg.ID_OS = reader.GetDecimal(reader.GetOrdinal("ID_OS"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_EMPRESA"))))
                        reg.CD_Empresa = reader.GetString(reader.GetOrdinal("CD_EMPRESA"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("NR_PEDIDO"))))
                        reg.NR_Pedido = reader.GetDecimal(reader.GetOrdinal("NR_PEDIDO"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("TP_PEDIDO"))))
                        reg.TP_Pedido = reader.GetString(reader.GetOrdinal("TP_PEDIDO"));

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

        public string Gravar_Servico_X_Pedido(TRegistro_Servico_X_Pedidos val)
        {
            Hashtable hs = new Hashtable(3);
            hs.Add("@P_ID_OS", val.ID_OS);
            hs.Add("@P_CD_EMPRESA", val.CD_Empresa);
            hs.Add("@P_NR_PEDIDO", val.NR_Pedido);
            hs.Add("@P_TP_PEDIDO", val.TP_Pedido);  
            return this.executarProc("IA_OSE_SERVICO_X_PEDIDOS", hs);
        }

        public string Delerar_Servico_X_Pedido(TRegistro_Servico_X_Pedidos val)
        {
            Hashtable hs = new Hashtable(3);
            hs.Add("@P_ID_OS", val.ID_OS);
            hs.Add("@P_CD_EMPRESA", val.CD_Empresa);
            hs.Add("@P_NR_PEDIDO", val.NR_Pedido);
            return this.executarProc("EXCLUI_IA_OSE_SERVICO_X_PEDIDOS", hs);
        }
    }
}
