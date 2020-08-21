using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Utils;

namespace CamadaDados.Faturamento.Cadastros
{
    public class TList_CadCFGPedido : List<TRegistro_CadCFGPedido>
    { }

    public class TRegistro_CadCFGPedido
    {
        public string Cfg_pedido { get; set; }
        public string Ds_tipopedido { get; set; }
        private string tp_movimento;
        public string Tp_movimento
        {
            get { return tp_movimento; }
            set
            {
                tp_movimento = value;
                if (value.Trim().ToUpper().Equals("E"))
                    tipo_movimento = "ENTRADA";
                else if (value.Trim().ToUpper().Equals("S"))
                    tipo_movimento = "SAIDA";
            }
        }
        private string tipo_movimento;
        public string Tipo_movimento
        {
            get { return tipo_movimento; }
            set
            {
                tipo_movimento = value;
                if (value.Trim().ToUpper().Equals("ENTRADA"))
                    tp_movimento = "E";
                else if (value.Trim().ToUpper().Equals("SAIDA"))
                    tp_movimento = "S";
            }
        }
        private string st_deposito;
        public string St_deposito
        {
            get { return st_deposito; }
            set
            {
                st_deposito = value;
                st_depositobool = value.Trim().ToUpper().Equals("S");
            }
        }
        private bool st_depositobool;
        public bool St_depositobool
        {
            get { return st_depositobool; }
            set
            {
                st_depositobool = value;
                if (value)
                    st_deposito = "S";
                else
                    st_deposito = "N";
            }
        }
        private string st_confere_saldo;
        public string St_confere_saldo
        {
            get { return st_confere_saldo; }
            set
            {
                st_confere_saldo = value;
                st_confere_saldobool = value.Trim().ToUpper().Equals("S");
            }
        }
        private bool st_confere_saldobool;
        public bool St_confere_saldobool
        {
            get { return st_confere_saldobool; }
            set
            {
                st_confere_saldobool = value;
                if (value)
                    st_confere_saldo = "S";
                else
                    st_confere_saldo = "N";
            }
        }
        private string st_valoresfixos;
        public string St_valoresfixos
        {
            get { return st_valoresfixos; }
            set
            {
                st_valoresfixos = value;
                st_valoresfixosbool = value.Trim().ToUpper().Equals("S");
            }
        }
        private bool st_valoresfixosbool;
        public bool St_valoresfixosbool
        {
            get { return st_valoresfixosbool; }
            set
            {
                st_valoresfixosbool = value;
                if (value)
                    st_valoresfixos = "S";
                else
                    st_valoresfixos = "N";
            }
        }
        private string st_permite_pedidoparcial;
        public string St_permite_pedidoparcial
        {
            get { return st_permite_pedidoparcial; }
            set
            {
                st_permite_pedidoparcial = value;
                st_permite_pedidoparcialbool = value.Trim().ToUpper().Equals("S");
            }
        }
        private bool st_permite_pedidoparcialbool;
        public bool St_permite_pedidoparcialbool
        {
            get { return st_permite_pedidoparcialbool; }
            set
            {
                st_permite_pedidoparcialbool = value;
                if (value)
                    st_permite_pedidoparcial = "S";
                else
                    st_permite_pedidoparcial = "N";
            }
        }
        private string st_permitetransf;
        public string St_permitetransf
        {
            get { return st_permitetransf; }
            set
            {
                st_permitetransf = value;
                st_permitetransfbool = value.Trim().ToUpper().Equals("S");
            }
        }
        private bool st_permitetransfbool;
        public bool St_permitetransfbool
        {
            get { return st_permitetransfbool; }
            set
            {
                st_permitetransfbool = value;
                if (value)
                    st_permitetransf = "S";
                else
                    st_permitetransf = "N";
            }
        }
        private string st_comissaoped;
        public string St_comissaoped
        {
            get { return st_comissaoped; }
            set
            {
                st_comissaoped = value;
                st_comissaopedbool = value.Trim().ToUpper().Equals("S");
            }
        }
        private bool st_comissaopedbool;
        public bool St_comissaopedbool
        {
            get { return st_comissaopedbool; }
            set
            {
                st_comissaopedbool = value;
                st_comissaoped = value ? "S" : "N";
            }
        }
        private string st_comissaofat;
        public string St_comissaofat
        {
            get { return st_comissaofat; }
            set
            {
                st_comissaofat = value;
                st_comissaofatbool = value.Trim().ToUpper().Equals("S");
            }
        }
        private bool st_comissaofatbool;
        public bool St_comissaofatbool
        {
            get { return st_comissaofatbool; }
            set
            {
                st_comissaofatbool = value;
                st_comissaofat = value ? "S" : "N";
            }
        }
        private string st_servico;
        public string St_servico
        {
            get { return st_servico; }
            set
            {
                st_servico = value;
                st_servicobool = value.Trim().ToUpper().Equals("S");
            }
        }
        private bool st_servicobool;
        public bool St_servicobool
        {
            get { return st_servicobool; }
            set
            {
                st_servicobool = value;
                if (value)
                    st_servico = "S";
                else
                    st_servico = "N";
            }
        }
        private string st_commoditties;
        public string St_commoditties
        {
            get { return st_commoditties; }
            set
            {
                st_commoditties = value;
                st_commodittiesbool = value.Trim().ToUpper().Equals("S");
            }
        }
        private bool st_commodittiesbool;
        public bool St_commodittiesbool
        {
            get { return st_commodittiesbool; }
            set
            {
                st_commodittiesbool = value;
                if (value)
                    st_commoditties = "S";
                else
                    st_commoditties = "N";
            }
        }
        private string st_registro;
        public string St_registro
        {
            get { return st_registro; }
            set
            {
                st_registro = value;
                status = value.Trim().ToUpper().Equals("A");
            }
        }
        private bool status;
        public bool Status
        {
            get { return status; }
            set
            {
                status = value;
                if (value)
                    st_registro = "A";
                else
                    st_registro = "C";
            }
        }
        private string st_ExigirConferenciaEntrega;
        public string St_ExigirConferenciaEntrega
        {
            get { return st_ExigirConferenciaEntrega; }
            set
            {
                st_ExigirConferenciaEntrega = value;
                st_ExigirConferenciaEntregaBool = value.Trim().ToUpper().Equals("S");
            }
        }
        private bool st_ExigirConferenciaEntregaBool;
        public bool St_ExigirConferenciaEntregaBool
        {
            get { return st_ExigirConferenciaEntregaBool; }
            set
            {
                st_ExigirConferenciaEntregaBool = value;
                if (value)
                    st_ExigirConferenciaEntrega = "S";
                else
                    st_ExigirConferenciaEntrega = "N";
            }
        }
        private string st_Rastrear_NFOrig;
        public string St_Rastrear_NFOrig
        {
            get { return st_Rastrear_NFOrig; }
            set
            {
                st_Rastrear_NFOrig = value;
                st_Rastrear_NFOrigBool = value.Trim().ToUpper().Equals("S");
            }
        }
        private bool st_Rastrear_NFOrigBool;
        public bool St_Rastrear_NFOrigBool
        {
            get { return st_Rastrear_NFOrigBool; }
            set
            {
                st_Rastrear_NFOrigBool = value;
                if (value)
                    st_Rastrear_NFOrig = "S";
                else
                    st_Rastrear_NFOrig = "N";
            }
        }
        private string st_integraralmox;
        public string St_integraralmox
        {
            get { return st_integraralmox; }
            set
            {
                st_integraralmox = value;
                st_integraralmoxbool = value.ToUpper().Trim().Equals("S");
            }
        }
        private bool st_integraralmoxbool;
        public bool St_integraralmoxbool
        {
            get { return st_integraralmoxbool; }
            set
            {
                st_integraralmoxbool = value;
                st_integraralmox = value ? "S" : "N";
            }
        }
        private string st_gerarreservaestoque;
        public string St_gerarreservaestoque
        {
            get { return st_gerarreservaestoque; }
            set
            {
                st_gerarreservaestoque = value;
                st_gerarreservaestoquebool = value.Trim().ToUpper().Equals("S");
            }
        }
        private bool st_gerarreservaestoquebool;
        public bool St_gerarreservaestoquebool
        {
            get { return st_gerarreservaestoquebool; }
            set
            {
                st_gerarreservaestoquebool = value;
                if (value)
                    st_gerarreservaestoque = "S";
                else
                    st_gerarreservaestoque = "N";
            }
        }
        private string st_permitelanpedido;
        public string St_permitelanpedido
        {
            get { return st_permitelanpedido; }
            set
            {
                st_permitelanpedido = value;
                st_permitelanpedidobool = value.Trim().ToUpper().Equals("S");
            }
        }
        private bool st_permitelanpedidobool;
        public bool St_permitelanpedidobool
        {
            get { return st_permitelanpedidobool; }
            set
            {
                st_permitelanpedidobool = value;
                if (value)
                    st_permitelanpedido = "S";
                else
                    st_permitelanpedido = "N";
            }
        }
        private string st_atualizaprecovenda;
        public string St_atualizaprecovenda
        {
            get { return st_atualizaprecovenda; }
            set
            {
                st_atualizaprecovenda = value;
                st_atualizaprecovendabool = value.Trim().ToUpper().Equals("S");
            }
        }
        private bool st_atualizaprecovendabool;
        public bool St_atualizaprecovendabool
        {
            get { return st_atualizaprecovendabool; }
            set
            {
                st_atualizaprecovendabool = value;
                if (value)
                    st_atualizaprecovenda = "S";
                else
                    st_atualizaprecovenda = "N";
            }
        }
        private string st_gerarOP;
        public string St_gerarOP
        {
            get { return st_gerarOP; }
            set
            {
                st_gerarOP = value;
                st_gerarOPbool = value.Trim().ToUpper().Equals("S");
            }
        }
        private bool st_gerarOPbool;
        public bool St_gerarOPbool
        {
            get { return st_gerarOPbool; }
            set
            {
                st_gerarOPbool = value;
                st_gerarOP = value ? "S" : "N";
            }
        }
        private string st_vincularcf;
        public string St_vincularcf
        {
            get { return st_vincularcf; }
            set
            {
                st_vincularcf = value;
                st_vincularcfbool = value.Trim().ToUpper().Equals("S");
            }
        }
        private bool st_vincularcfbool;
        public bool St_vincularcfbool
        {
            get { return st_vincularcfbool; }
            set
            {
                st_vincularcfbool = value;
                st_vincularcf = value ? "S" : "N";
            }
        }
        private string st_gerarfin;
        public string St_gerarfin
        {
            get { return st_gerarfin; }
            set
            {
                st_gerarfin = value;
                st_gerarfinbool = value.Trim().ToUpper().Equals("S");
            }
        }
        private bool st_gerarfinbool;
        public bool St_gerarfinbool
        {
            get { return st_gerarfinbool; }
            set
            {
                st_gerarfinbool = value;
                st_gerarfin = value ? "S" : "N";
            }
        }
        private string st_despfrota;
        public string St_despfrota
        {
            get { return st_despfrota; }
            set
            {
                st_despfrota = value;
                st_despfrotabool = value.Trim().ToUpper().Equals("S");
            }
        }
        private bool st_despfrotabool;
        public bool St_despfrotabool
        {
            get { return st_despfrotabool; }
            set
            {
                st_despfrotabool = value;
                st_despfrota = value ? "S" : "N";
            }
        }
        private string st_geraretiqueta;
        public string St_geraretiqueta
        {
            get { return st_geraretiqueta; }
            set
            {
                st_geraretiqueta = value;
                st_geraretiquetabool = value.Trim().ToUpper().Equals("S");
            }
        }
        private bool st_geraretiquetabool;
        public bool St_geraretiquetabool
        {
            get { return st_geraretiquetabool; }
            set
            {
                st_geraretiquetabool = value;
                st_geraretiqueta = value ? "S" : "N";
            }
        }
        private string st_exigeetapa;
        public string St_exigeetapa
        {
            get { return st_exigeetapa; }
            set
            {
                st_exigeetapa = value;
                st_exigeetapabool = value.Trim().ToUpper().Equals("S");
            }
        }
        private bool st_exigeetapabool;
        public bool St_exigeetapabool
        {
            get { return st_exigeetapabool; }
            set
            {
                st_exigeetapabool = value;
                st_exigeetapa = value ? "S" : "N";
            }
        }
        private string st_reqauto;

        public string St_reqauto
        {
            get { return st_reqauto; }
            set
            {
                st_reqauto = value;
                st_reqautobool = value.Trim().ToUpper().Equals("S");
            }
        }
        private bool st_reqautobool;

        public bool St_reqautobool
        {
            get { return st_reqautobool; }
            set
            {
                st_reqautobool = value;
                st_reqauto = value ? "S" : "N";
            }
        }

        public bool St_processar
        { get; set; }
        
        public TRegistro_CadCFGPedido()
        {
            Cfg_pedido = string.Empty;
            Ds_tipopedido = string.Empty;
            st_comissaoped = "N";
            st_comissaopedbool = false;
            st_confere_saldo = "N";
            st_confere_saldobool = false;
            st_valoresfixos = "N";
            st_valoresfixosbool = false;
            st_permite_pedidoparcial = "N";
            st_permite_pedidoparcialbool = false;
            st_permitetransf = "N";
            st_permitetransfbool = false;
            st_comissaofat = "N";
            st_comissaofatbool = false;
            st_servico = "N";
            st_servicobool = false;
            st_ExigirConferenciaEntrega = "N";
            st_ExigirConferenciaEntregaBool = false;
            st_deposito = "N";
            st_depositobool = false;
            st_commoditties = "N";
            st_commodittiesbool = false;
            st_Rastrear_NFOrig = "N";
            st_Rastrear_NFOrigBool = false;
            st_integraralmox = "N";
            st_integraralmoxbool = false;
            st_gerarreservaestoque = "N";
            st_gerarreservaestoquebool = false;
            st_permitelanpedido = "N";
            st_permitelanpedidobool = false;
            st_atualizaprecovenda = "N";
            st_atualizaprecovendabool = false;
            st_gerarOP = "N";
            st_gerarOPbool = false;
            st_vincularcf = "N";
            st_vincularcfbool = false;
            St_processar = false;
            st_gerarfin = "N";
            st_gerarfinbool = false;
            st_despfrota = "N";
            st_despfrotabool = false;
            st_geraretiqueta = "N";
            st_geraretiquetabool = false;
            st_exigeetapa = "N";
            st_exigeetapabool = false;
            st_reqauto = "N";
            st_reqautobool = false;
        }
    }      

    public class TCD_CadCFGPedido : TDataQuery
    {
        public TCD_CadCFGPedido()
        { }

        public TCD_CadCFGPedido(BancoDados.TObjetoBanco banco)
        {
            Banco_Dados = banco;
        }

        public TCD_CadCFGPedido(string vNM_ProcSqlBusca)
        {
            NM_ProcSqlBusca = vNM_ProcSqlBusca;
        }
        
        private string SqlCodeBusca(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("Select " + strTop + " a.cfg_pedido, a.ds_tipopedido, a.tp_movimento, a.st_deposito, a.st_atualizaprecovenda, ");
                sql.AppendLine("a.st_confere_saldo, a.st_valoresfixos, a.st_permite_pedidoparcial, a.st_permitetransf, a.st_gerarOP, a.st_despfrota, ");
                sql.AppendLine("a.st_comissaoped, a.st_comissaofat, a.st_servico, a.st_commoditties, a.st_integrarAlmox, a.st_permitelanpedido, a.st_gerarfin, a.st_reqauto,  ");
                sql.AppendLine("a.st_registro, a.st_ExigirConferenciaEntrega, a.st_Rastrear_NFOrig, a.st_gerarreservaestoque, a.st_vincularcf, a.st_geraretiqueta, a.St_exigeetapa ");
            }
            else
            {
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");
            }

            sql.AppendLine("from TB_FAT_CFGPedido a");
            sql.AppendLine("where isNull(a.st_registro, 'A') = 'A'");
            string cond = " and ";
            if (vBusca != null)
                foreach(TpBusca filtro in vBusca)
                    sql.AppendLine(cond + "(" + filtro.vNM_Campo + " " + filtro.vOperador + " " + filtro.vVL_Busca + ")");

            sql.Append("Order by a.ds_tipopedido asc");
            return sql.ToString();
        }

        public string SqlCodeBuscaXUsuario(TpBusca[] vBusca, Int16 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("Select " + strTop + " A.CFG_Pedido, A.DS_TipoPedido, A.TP_Movimento, A.ST_Deposito, a.st_integraralmox, a.st_gerarfin, a.st_reqauto, ");
                sql.AppendLine(" A.st_Confere_Saldo, A.st_ValoresFixos, A.st_permite_pedidoParcial,  A.ST_permitetransf, a.st_gerarreservaestoque, a.st_despfrota, ");
                sql.AppendLine(" A.ST_Comissaoped, a.st_comissaofat, a.st_servico, A.ST_Registro, a.st_commoditties, a.st_Rastrear_NFOrig, a.st_gerarOP, a.st_geraretiqueta ");

                sql.AppendLine("From TB_FAT_CFGPedido A ");
                sql.AppendLine("inner join TB_DIV_Usuario_X_CFGPedido B ");
                sql.AppendLine("on a.cfg_Pedido = b.cfg_pedido ");
                sql.AppendLine("Where isNull(A.ST_Registro, 'A') <> 'C'");
                string cond = " and ";

                if (vBusca != null)
                    for (int i = 0; i < (vBusca.Length); i++)
                        sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + ")");
            }
            return sql.ToString();

        }

        public string SqlCodeBuscaXPedido(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("Select " + strTop + " a.cfg_pedido, a.ds_tipopedido, a.tp_movimento, a.st_deposito, a.st_reqauto, ");
                sql.AppendLine("a.st_confere_saldo, a.st_valoresfixos, a.st_permite_pedidoparcial, a.st_permitetransf, a.st_despfrota, ");
                sql.AppendLine("a.st_comissaoped, a.st_comissaofat, a.st_servico, a.st_commoditties, a.st_gerarreservaestoque, a.st_gerarfin, ");
                sql.AppendLine("a.st_registro,a.st_ExigirConferenciaEntrega, a.st_Rastrear_NFOrig, a.st_integraralmox, a.st_gerarOP, a.st_geraretiqueta ");
            }
            else
            {
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");
            }

            sql.AppendLine("FROM TB_FAT_CFGPedido a");
            sql.AppendLine("INNER JOIN TB_FAT_Pedido b ");
            sql.AppendLine("ON a.cfg_pedido = b.cfg_pedido ");
            sql.AppendLine("where isNull(a.st_registro, 'A') = 'A'");
            string cond = " and ";
            if (vBusca != null)
                foreach (TpBusca filtro in vBusca)
                    sql.AppendLine(cond + "(" + filtro.vNM_Campo + " " + filtro.vOperador + " " + filtro.vVL_Busca + ")");

            sql.Append("Order by a.ds_tipopedido asc");
            return sql.ToString();
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop)
        {
            if (string.IsNullOrEmpty(NM_ProcSqlBusca))
                return ExecutarBusca(SqlCodeBusca(vBusca, vTop, string.Empty), null);
            else
            {
                string sql = GetType().GetMethod(NM_ProcSqlBusca).Invoke(this, new object[] { vBusca, vTop, string.Empty }).ToString();
                return ExecutarBusca(sql, null);
            }            
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo), null);
        }

        public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
        {
            if (string.IsNullOrEmpty(NM_ProcSqlBusca))
                return ExecutarBuscaEscalar(SqlCodeBusca(vBusca, 1, vNM_Campo), null);
            else
            {
                string sql = GetType().GetMethod(NM_ProcSqlBusca).Invoke(this, new object[] { vBusca, 1, vNM_Campo }).ToString();
                return ExecutarBuscaEscalar(sql, null);
            }     
        }

        public TList_CadCFGPedido Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_CadCFGPedido lista = new TList_CadCFGPedido();
            bool podeFecharBco = false;

            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            SqlDataReader reader = ExecutarBusca(SqlCodeBusca(vBusca, vTop, string.Empty));
            try
            {
                while (reader.Read())
                {
                    TRegistro_CadCFGPedido reg = new TRegistro_CadCFGPedido();

                    if (!reader.IsDBNull(reader.GetOrdinal("CFG_Pedido")))
                        reg.Cfg_pedido = reader.GetString(reader.GetOrdinal("CFG_Pedido"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_TipoPedido")))
                        reg.Ds_tipopedido = reader.GetString(reader.GetOrdinal("DS_TipoPedido"));
                    if (!reader.IsDBNull(reader.GetOrdinal("TP_Movimento")))
                        reg.Tp_movimento = reader.GetString(reader.GetOrdinal("TP_Movimento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ST_Deposito")))
                        reg.St_deposito = reader.GetString(reader.GetOrdinal("ST_Deposito"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ST_Confere_Saldo")))
                        reg.St_confere_saldo = reader.GetString(reader.GetOrdinal("ST_Confere_Saldo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ST_ValoresFixos")))
                        reg.St_valoresfixos = reader.GetString(reader.GetOrdinal("ST_ValoresFixos"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ST_Permite_PedidoParcial")))
                        reg.St_permite_pedidoparcial = reader.GetString(reader.GetOrdinal("ST_Permite_PedidoParcial"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ST_PermiteTransf")))
                        reg.St_permitetransf = reader.GetString(reader.GetOrdinal("ST_PermiteTransf"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ST_Comissaoped")))
                        reg.St_comissaoped = reader.GetString(reader.GetOrdinal("ST_Comissaoped"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ST_ComissaoFat")))
                        reg.St_comissaofat = reader.GetString(reader.GetOrdinal("ST_ComissaoFat"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ST_Servico")))
                        reg.St_servico = reader.GetString(reader.GetOrdinal("ST_Servico"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ST_Registro")))
                        reg.St_registro = reader.GetString(reader.GetOrdinal("ST_Registro"));
                    if(!(reader.IsDBNull(reader.GetOrdinal("st_ExigirConferenciaEntrega"))))
                        reg.St_ExigirConferenciaEntrega=reader.GetString(reader.GetOrdinal("st_ExigirConferenciaEntrega"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("st_Commoditties"))))
                        reg.St_commoditties = reader.GetString(reader.GetOrdinal("st_Commoditties"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("st_Rastrear_NFOrig"))))
                        reg.St_Rastrear_NFOrig = reader.GetString(reader.GetOrdinal("st_Rastrear_NFOrig"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ST_IntegrarAlmox")))
                        reg.St_integraralmox = reader.GetString(reader.GetOrdinal("ST_IntegrarAlmox"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ST_GerarReservaEstoque")))
                        reg.St_gerarreservaestoque = reader.GetString(reader.GetOrdinal("ST_GerarReservaEstoque"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ST_PermiteLanPedido")))
                        reg.St_permitelanpedido = reader.GetString(reader.GetOrdinal("ST_PermiteLanPedido"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ST_AtualizaPrecoVenda")))
                        reg.St_atualizaprecovenda = reader.GetString(reader.GetOrdinal("ST_AtualizaPrecoVenda"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ST_GerarOP")))
                        reg.St_gerarOP = reader.GetString(reader.GetOrdinal("ST_GerarOP"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ST_VincularCF")))
                        reg.St_vincularcf = reader.GetString(reader.GetOrdinal("ST_VincularCF"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_gerarfin")))
                        reg.St_gerarfin = reader.GetString(reader.GetOrdinal("st_gerarfin"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_despfrota")))
                        reg.St_despfrota = reader.GetString(reader.GetOrdinal("st_despfrota"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_geraretiqueta")))
                        reg.St_geraretiqueta = reader.GetString(reader.GetOrdinal("st_geraretiqueta"));
                    if (!reader.IsDBNull(reader.GetOrdinal("St_exigeetapa")))
                        reg.St_exigeetapa = reader.GetString(reader.GetOrdinal("St_exigeetapa"));
                    if(!reader.IsDBNull(reader.GetOrdinal("st_reqauto")))
                        reg.St_reqauto = reader.GetString(reader.GetOrdinal("st_reqauto"));
                    
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

        public string Gravar(TRegistro_CadCFGPedido val)
        {
            Hashtable hs = new Hashtable(26);
            hs.Add("@P_CFG_PEDIDO", val.Cfg_pedido);
            hs.Add("@P_DS_TIPOPEDIDO", val.Ds_tipopedido);
            hs.Add("@P_TP_MOVIMENTO", val.Tp_movimento);
            hs.Add("@P_ST_DEPOSITO", val.St_deposito);
            hs.Add("@P_ST_CONFERE_SALDO", val.St_confere_saldo);
            hs.Add("@P_ST_PERMITETRANSF", val.St_permitetransf);
            hs.Add("@P_ST_VALORESFIXOS", val.St_valoresfixos);
            hs.Add("@P_ST_COMISSAOPED", val.St_comissaoped);
            hs.Add("@P_ST_COMISSAOFAT", val.St_comissaofat);
            hs.Add("@P_ST_SERVICO", val.St_servico);
            hs.Add("@P_ST_PERMITE_PEDIDOPARCIAL", val.St_permite_pedidoparcial);
            hs.Add("@P_ST_EXIGIRCONFERENCIAENTREGA", val.St_ExigirConferenciaEntrega);
            hs.Add("@P_ST_REGISTRO", val.St_registro);
            hs.Add("@P_ST_COMMODITTIES", val.St_commoditties);
            hs.Add("@P_ST_RASTREAR_NFORIG", val.St_Rastrear_NFOrig);
            hs.Add("@P_ST_INTEGRARALMOX", val.St_integraralmox);
            hs.Add("@P_ST_GERARRESERVAESTOQUE", val.St_gerarreservaestoque);
            hs.Add("@P_ST_PERMITELANPEDIDO", val.St_permitelanpedido);
            hs.Add("@P_ST_ATUALIZAPRECOVENDA", val.St_atualizaprecovenda);
            hs.Add("@P_ST_GERAROP", val.St_gerarOP);
            hs.Add("@P_ST_VINCULARCF", val.St_vincularcf);
            hs.Add("@P_ST_GERARFIN", val.St_gerarfin);
            hs.Add("@P_ST_DESPFROTA", val.St_despfrota);
            hs.Add("@P_ST_GERARETIQUETA", val.St_geraretiqueta);
            hs.Add("@P_ST_EXIGEETAPA", val.St_exigeetapa);
            hs.Add("@P_ST_REQAUTO", val.St_reqauto);

            return executarProc("IA_FAT_CFGPEDIDO", hs);
        }

        public string Excluir(TRegistro_CadCFGPedido val)
        {
            Hashtable hs = new Hashtable(1);
            hs.Add("@P_CFG_PEDIDO", val.Cfg_pedido);

            return executarProc("EXCLUI_FAT_CFGPEDIDO", hs);
        }
    }
}
