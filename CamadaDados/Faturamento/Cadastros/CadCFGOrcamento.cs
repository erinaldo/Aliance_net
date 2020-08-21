using System;
using System.Collections.Generic;
using System.Text;

namespace CamadaDados.Faturamento.Cadastros
{
    public class TList_CFGOrcamento : List<TRegistro_CFGOrcamento>
    { }
    
    public class TRegistro_CFGOrcamento
    {
        public string Cd_empresa
        { get; set; }
        public string Nm_empresa
        { get; set; }
        public string Cfg_pedido
        { get; set; }
        public string Ds_tipopedido
        { get; set; }
        public string Cfg_pedservico
        { get; set; }
        public string Ds_tipopedservico
        { get; set; }
        public string Cfg_PedOrdemProd
        { get; set; }
        public string Ds_tipoPedOrdemProd
        { get; set; }
        public string Cd_local
        { get; set; }
        public string Ds_local
        { get; set; }
        public decimal Qt_diasvalidade
        { get; set; }
        private string st_geraros;
        public string St_geraros
        {
            get { return st_geraros; }
            set
            {
                st_geraros = value;
                st_gerarosbool = value.Trim().ToUpper().Equals("S");
            }
        }
        private bool st_gerarosbool;
        public bool St_gerarosbool
        {
            get { return st_gerarosbool; }
            set
            {
                st_gerarosbool = value;
                st_geraros = value ? "S" : "N";
            }
        }
        private string st_gerarprojeto;
        public string St_gerarprojeto
        {
            get { return st_gerarprojeto; }
            set
            {
                st_gerarprojeto = value;
                st_gerarprojetobool = value.Trim().ToUpper().Equals("S");
            }
        }
        private bool st_gerarprojetobool;
        public bool St_gerarprojetobool
        {
            get { return st_gerarprojetobool; }
            set
            {
                st_gerarprojetobool = value;
                st_gerarprojeto = value ? "S" : "N";
            }
        }
        private decimal? tp_ordem;
        public decimal? Tp_ordem
        {
            get { return tp_ordem; }
            set
            {
                tp_ordem = value;
                tp_ordemstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string tp_ordemstr;
        public string Tp_ordemstr
        {
            get { return tp_ordemstr; }
            set
            {
                tp_ordemstr = value;
                try
                {
                    tp_ordem = decimal.Parse(value);
                }
                catch
                { tp_ordem = null; }
            }
        }
        public string Ds_tipoordem
        { get; set; }
        public string Cd_contager { get; set; } = string.Empty;
        public string Ds_contager { get; set; } = string.Empty;
        public string Cd_portador { get; set; } = string.Empty;
        public string Ds_portador { get; set; } = string.Empty;
        public string Tp_os
        { get; set; }
        public byte[] LayoutJaquetado
        { get; set; }
        public byte[] LayoutJaquetadoRes
        { get; set; }
        public byte[] LayoutAereo
        { get; set; }
        public byte[] LayoutPerifericos
        { get; set; }
        public byte[] LayoutFlex
        { get; set; }
        public byte[] LayoutAgua
        { get; set; }
        public byte[] LayoutVertical
        { get; set; }
        private string st_aplicdescvlunit;
        public string St_aplicdescvlunit
        {
            get { return st_aplicdescvlunit; }
            set
            {
                st_aplicdescvlunit = value;
                st_aplicdescvlunitbool = value.Trim().ToUpper().Equals("S");
            }
        }
        private bool st_aplicdescvlunitbool;
        public bool St_aplicdescvlunitbool
        {
            get { return st_aplicdescvlunitbool; }
            set
            {
                st_aplicdescvlunitbool = value;
                st_aplicdescvlunit = value ? "S" : "N";
            }
        }

        public TRegistro_CFGOrcamento()
        {
            Cd_empresa = string.Empty;
            Nm_empresa = string.Empty;
            Cfg_pedido = string.Empty;
            Ds_tipopedido = string.Empty;
            Cfg_pedservico = string.Empty;
            Ds_tipopedservico = string.Empty;
            Cfg_PedOrdemProd = string.Empty;
            Ds_tipoPedOrdemProd = string.Empty;
            Cd_local = string.Empty;
            Ds_local = string.Empty;
            Qt_diasvalidade = decimal.Zero;
            st_geraros = "N";
            st_gerarosbool = false;
            st_gerarprojeto = "N";
            st_gerarprojetobool = false;
            tp_ordem = null;
            tp_ordemstr = string.Empty;
            Ds_tipoordem = string.Empty;
            Tp_os = string.Empty;
            LayoutJaquetado = null;
            LayoutJaquetadoRes = null;
            LayoutAereo = null;
            LayoutPerifericos = null;
            LayoutAgua = null;
            LayoutFlex = null;
            LayoutVertical = null;
            st_aplicdescvlunit = "N";
            st_aplicdescvlunitbool = false;
            
        }
    }

    public class TCD_CFGOrcamento : TDataQuery
    {
        public TCD_CFGOrcamento()
        { }

        public TCD_CFGOrcamento(BancoDados.TObjetoBanco banco)
        { Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();

            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine(" SELECT " + strTop + " a.cd_empresa, b.NM_Empresa, ");
                sql.AppendLine("a.cfg_pedido, c.DS_TipoPedido, a.st_geraros, a.ST_GERARPROJETO, ");
                sql.AppendLine("a.cd_local, d.DS_Local, a.qt_diasvalidade, a.ST_AplicDescVlUnit, ");
                sql.AppendLine("a.tp_ordem, e.ds_tipoordem, e.tp_os, ");
                sql.AppendLine("a.cd_contager, h.ds_contager, a.cd_portador, i.ds_portador, ");
                sql.AppendLine("a.cfg_pedservico, f.ds_tipopedido as ds_tipopedservico, ");
                sql.AppendLine("a.CFG_PEDORDEMPROD, g.ds_tipopedido as Ds_tipoPedOrdemProd, a.Layout1, a.Layout2, a.Layout3,a.Layout4,a.Layout5,a.Layout6, a.Layout7 ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from tb_fat_cfgorcamento a ");
            sql.AppendLine("inner join TB_DIV_Empresa b ");
            sql.AppendLine("on a.CD_Empresa = b.CD_Empresa ");
            sql.AppendLine("inner join TB_FAT_CFGPedido c ");
            sql.AppendLine("on a.cfg_pedido = c.CFG_Pedido ");
            sql.AppendLine("left outer join TB_EST_LocalArm d ");
            sql.AppendLine("on a.cd_local = d.CD_Local ");
            sql.AppendLine("left outer join TB_OSE_TpOrdem e ");
            sql.AppendLine("on a.tp_ordem = e.tp_ordem ");
            sql.AppendLine("left outer join TB_FAT_CFGPedido f ");
            sql.AppendLine("on a.cfg_pedservico = f.cfg_pedido ");
            sql.AppendLine("left outer join TB_FAT_CFGPedido g ");
            sql.AppendLine("on a.CFG_PEDORDEMPROD = g.cfg_pedido ");
            sql.AppendLine("left outer join TB_FIN_ContaGer h ");
            sql.AppendLine("on a.cd_contager = h.cd_contager ");
            sql.AppendLine("left outer join TB_FIN_Portador i ");
            sql.AppendLine("on a.cd_portador = i.cd_portador ");

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
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, string.Empty), null);
        }

        public override System.Data.DataTable Buscar(Utils.TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo), null);
        }

        public override object BuscarEscalar(Utils.TpBusca[] vBusca, string vNM_Campo)
        {
            return ExecutarBuscaEscalar(SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }

        public TList_CFGOrcamento Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_CFGOrcamento lista = new TList_CFGOrcamento();
            System.Data.SqlClient.SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);

            try
            {
                reader = ExecutarBusca(SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
                while (reader.Read())
                {
                    TRegistro_CFGOrcamento reg = new TRegistro_CFGOrcamento();
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_empresa")))
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("nm_empresa")).Trim();
                    if (!reader.IsDBNull(reader.GetOrdinal("cfg_pedido")))
                        reg.Cfg_pedido = reader.GetString(reader.GetOrdinal("cfg_pedido"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_tipopedido")))
                        reg.Ds_tipopedido = reader.GetString(reader.GetOrdinal("ds_tipopedido"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_local")))
                        reg.Cd_local = reader.GetString(reader.GetOrdinal("cd_local"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_local")))
                        reg.Ds_local = reader.GetString(reader.GetOrdinal("ds_local"));
                    if (!reader.IsDBNull(reader.GetOrdinal("qt_diasvalidade")))
                        reg.Qt_diasvalidade = reader.GetDecimal(reader.GetOrdinal("qt_diasvalidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_gerarOS")))
                        reg.St_geraros = reader.GetString(reader.GetOrdinal("st_gerarOS"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_ordem")))
                        reg.Tp_ordem = reader.GetDecimal(reader.GetOrdinal("tp_ordem"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_tipoordem")))
                        reg.Ds_tipoordem = reader.GetString(reader.GetOrdinal("ds_tipoordem"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_os")))
                        reg.Tp_os = reader.GetString(reader.GetOrdinal("tp_os"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cfg_pedservico")))
                        reg.Cfg_pedservico = reader.GetString(reader.GetOrdinal("cfg_pedservico"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_tipopedservico")))
                        reg.Ds_tipopedservico = reader.GetString(reader.GetOrdinal("ds_tipopedservico"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CFG_PEDORDEMPROD")))
                        reg.Cfg_PedOrdemProd = reader.GetString(reader.GetOrdinal("CFG_PEDORDEMPROD"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Ds_tipoPedOrdemProd")))
                        reg.Ds_tipoPedOrdemProd = reader.GetString(reader.GetOrdinal("Ds_tipoPedOrdemProd"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ST_GERARPROJETO")))
                        reg.St_gerarprojeto = reader.GetString(reader.GetOrdinal("ST_GERARPROJETO"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Layout1")))
                        reg.LayoutJaquetado = (byte[])reader.GetValue(reader.GetOrdinal("Layout1"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Layout2")))
                        reg.LayoutAereo = (byte[])reader.GetValue(reader.GetOrdinal("Layout2"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Layout3")))
                        reg.LayoutPerifericos = (byte[])reader.GetValue(reader.GetOrdinal("Layout3"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Layout4")))
                        reg.LayoutFlex = (byte[])reader.GetValue(reader.GetOrdinal("Layout4"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Layout5")))
                        reg.LayoutAgua = (byte[])reader.GetValue(reader.GetOrdinal("Layout5"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Layout6")))
                        reg.LayoutVertical= (byte[])reader.GetValue(reader.GetOrdinal("Layout6"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Layout7")))
                        reg.LayoutJaquetadoRes = (byte[])reader.GetValue(reader.GetOrdinal("Layout7"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_aplicdescvlunit")))
                        reg.St_aplicdescvlunit = reader.GetString(reader.GetOrdinal("st_aplicdescvlunit"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_contager")))
                        reg.Cd_contager = reader.GetString(reader.GetOrdinal("cd_contager"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_contager")))
                        reg.Ds_contager = reader.GetString(reader.GetOrdinal("ds_contager"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_portador")))
                        reg.Cd_portador = reader.GetString(reader.GetOrdinal("cd_portador"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_portador")))
                        reg.Ds_portador = reader.GetString(reader.GetOrdinal("ds_portador"));


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

        public string Gravar(TRegistro_CFGOrcamento val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(19);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_CFG_PEDIDO", val.Cfg_pedido);
            hs.Add("@P_CFG_PEDSERVICO", val.Cfg_pedservico);
            hs.Add("@P_CFG_PEDORDEMPROD", val.Cfg_PedOrdemProd);
            hs.Add("@P_CD_LOCAL", val.Cd_local);
            hs.Add("@P_QT_DIASVALIDADE", val.Qt_diasvalidade);
            hs.Add("@P_ST_GERAROS", val.St_geraros);
            hs.Add("@P_ST_GERARPROJETO", val.St_gerarprojeto);
            hs.Add("@P_TP_ORDEM", val.Tp_ordem);
            hs.Add("@P_LAYOUT1", val.LayoutJaquetado);
            hs.Add("@P_LAYOUT2", val.LayoutAereo);
            hs.Add("@P_LAYOUT3", val.LayoutPerifericos);
            hs.Add("@P_LAYOUT4", val.LayoutFlex);
            hs.Add("@P_LAYOUT5", val.LayoutAgua);
            hs.Add("@P_LAYOUT6", val.LayoutVertical);
            hs.Add("@P_LAYOUT7", val.LayoutJaquetadoRes);
            hs.Add("@P_ST_APLICDESCVLUNIT", val.St_aplicdescvlunit);
            hs.Add("@P_CD_CONTAGER", val.Cd_contager);
            hs.Add("@P_CD_PORTADOR", val.Cd_portador);

            return executarProc("IA_FAT_CFGORCAMENTO", hs);
        }

        public string Excluir(TRegistro_CFGOrcamento val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(1);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);

            return executarProc("EXCLUI_FAT_CFGORCAMENTO", hs);
        }
    }
}
