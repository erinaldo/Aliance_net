using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using BancoDados;
using Utils;
using System.Data;
using System.Collections;
using System.Data.SqlClient;
using CamadaDados.Diversos;
using CamadaDados.Financeiro.Cadastros;
using CamadaDados.Graos;
using CamadaDados.Faturamento.Cadastros;

namespace CamadaDados.Faturamento.Pedido
{
    #region LanPedido X Duplicata
    public class TList_LanPedido_X_Duplicata : List<TRegistro_LanPedido_X_Duplicata>
    { }

    
    public class TRegistro_LanPedido_X_Duplicata
    {
        
        public decimal?  Nr_pedido
        { get; set; }
        
        public string Cd_empresa
        { get; set; }
        
        public decimal Nr_lancto
        { get; set; }

        public TRegistro_LanPedido_X_Duplicata()
        {
            this.Nr_pedido = decimal.Zero;
            this.Cd_empresa = string.Empty;
            this.Nr_lancto = decimal.Zero;
        }
    }

    public class TCD_LanPedido_X_Duplicata : TDataQuery
    {
        public TCD_LanPedido_X_Duplicata()
        { }

        public TCD_LanPedido_X_Duplicata(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + vTop.ToString();

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("select " + strTop + " a.nr_pedido, ");
                sql.AppendLine("a.cd_empresa, a.nr_lancto, ");
            }
            else
                sql.AppendLine(" Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from tb_fat_Pedido_x_duplicata a ");

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

        public TList_LanPedido_X_Duplicata Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            bool podeFecharBco = false;
            TList_LanPedido_X_Duplicata lista = new TList_LanPedido_X_Duplicata();
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_LanPedido_X_Duplicata reg = new TRegistro_LanPedido_X_Duplicata();
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_pedido")))
                        reg.Nr_pedido = reader.GetDecimal(reader.GetOrdinal("nr_pedido"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_lancto")))
                        reg.Nr_lancto = reader.GetDecimal(reader.GetOrdinal("nr_lancto"));

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

        public string Gravar(TRegistro_LanPedido_X_Duplicata val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(3);
            hs.Add("@P_NR_PEDIDO", val.Nr_pedido);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_NR_LANCTO", val.Nr_lancto);

            return this.executarProc("IA_FAT_PEDIDO_X_DUPLICATA", hs);
        }

        public string Excluir(TRegistro_LanPedido_X_Duplicata val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(3);
            hs.Add("@P_NR_PEDIDO", val.Nr_pedido);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_NR_LANCTO", val.Nr_lancto);

            return this.executarProc("EXCLUI_FAT_PEDIDO_X_DUPLICATA", hs);
        }
    }
    #endregion
}
