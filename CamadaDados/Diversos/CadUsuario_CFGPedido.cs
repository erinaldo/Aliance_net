using System;
using System.Collections.Generic;
using Utils;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.SqlClient;

namespace CamadaDados.Diversos
{
    public class TList_CadUsuario_CFGPedido : List<TRegistro_CadUsuario_CFGPedido>
    { }

    
    public class TRegistro_CadUsuario_CFGPedido
    {
        
        public string Login { get; set; }
        
        public string Nome_usuario { get; set; }
        
        public string Cfg_pedido { get; set; }
        public string DS_Cfg_pedido { get; set; }

        public TRegistro_CadUsuario_CFGPedido()
        {
            this.Login = string.Empty;
            this.Nome_usuario = string.Empty;
            this.Cfg_pedido = string.Empty;
            this.DS_Cfg_pedido = string.Empty;
        }
    }
    public class TCD_CadUsuario_CFGPedido : TDataQuery
    {
        public TCD_CadUsuario_CFGPedido()
        { }

        public TCD_CadUsuario_CFGPedido(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        public override DataTable Buscar(TpBusca[] vBusca, Int16 vTop)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, ""), null);
        }

        public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
        {
            return ExecutarBuscaEscalar(SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }

        private string SqlCodeBusca(TpBusca[] vBusca, Int16 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
                sql.AppendLine("Select " + strTop + " a.Login, b.Nome_usuario, a.CFG_Pedido, c.DS_TipoPedido ");
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("From TB_DIV_Usuario_X_CFGPedido a ");
            sql.AppendLine("inner join TB_DIV_Usuario b ");
            sql.AppendLine("On b.login = a.login ");
            sql.AppendLine("inner join TB_FAT_CFGPedido c ");
            sql.AppendLine("On c.CFG_Pedido = a.CFG_Pedido ");
            sql.AppendLine(" join TB_DIV_Usuario_X_Empresa d on a.login = d.login");

            string cond = " Where ";
            if (vBusca != null)
                for (Int16 i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + ")");
                    cond = " and ";
                }
            return sql.ToString();
        }

        public TList_CadUsuario_CFGPedido Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_CadUsuario_CFGPedido lista = new TList_CadUsuario_CFGPedido();
            SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);

            try
            {
                if (string.IsNullOrEmpty(vNM_Campo))
                    reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), ""));
                else
                    reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
                while (reader.Read())
                {
                    TRegistro_CadUsuario_CFGPedido reg = new TRegistro_CadUsuario_CFGPedido();
                    if (!(reader.IsDBNull(reader.GetOrdinal("Login"))))
                       reg.Login = reader.GetString(reader.GetOrdinal("Login"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nome_usuario")))
                        reg.Nome_usuario = reader.GetString(reader.GetOrdinal("nome_usuario"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("CFG_Pedido"))))
                       reg.Cfg_pedido = reader.GetString(reader.GetOrdinal("CFG_Pedido"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("DS_TipoPedido"))))
                        reg.DS_Cfg_pedido = reader.GetString(reader.GetOrdinal("DS_TipoPedido"));
                    
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
        public string GravarUsuarioCFGPedido(TRegistro_CadUsuario_CFGPedido val)
        {
            Hashtable hs = new Hashtable(2);
            hs.Add("@P_LOGIN", val.Login);
            hs.Add("@P_CFG_PEDIDO", val.Cfg_pedido);
            return executarProc("IA_DIV_USUARIO_X_CFGPEDIDO", hs);
        }
        public string DeletarUsuarioCFGPedido(TRegistro_CadUsuario_CFGPedido val)
        {
            Hashtable hs = new Hashtable(2);
            hs.Add("@P_LOGIN", val.Login);
            hs.Add("@P_CFG_PEDIDO", val.Cfg_pedido);

            return executarProc("EXCLUI_DIV_USUARIO_X_CFGPEDIDO", hs);
 
        }
    }
}
