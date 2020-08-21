using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Utils;
using CamadaDados.Financeiro.Duplicata;

namespace CamadaDados.Faturamento.NotaFiscal
{
    public class TList_LanFat_ComplementoDevolucao : List<TRegistro_LanFat_ComplementoDevolucao>
    { }
    
    public class TRegistro_LanFat_ComplementoDevolucao
    {
        private decimal? id_compldev;
        public decimal? Id_compldev
        {
            get { return id_compldev; }
            set
            {
                id_compldev = value;
                id_compldevstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_compldevstr;
        public string Id_compldevstr
        {
            get { return id_compldevstr; }
            set
            {
                id_compldevstr = value;
                try
                {
                    id_compldev = decimal.Parse(value);
                }
                catch
                { id_compldev = null; }
            }
        }
        public string Cd_empresa
        { get; set; }
        public string Nm_empresa
        { get; set; }
        public decimal? Nr_lanctofiscal_origem
        { get; set; }
        public decimal? Id_nfitem_origem
        { get; set; }
        public decimal? Nr_notafiscal_origem
        { get; set; }
        public string Nr_serie_origem
        { get; set; }
        public decimal? Nr_lanctofiscal_destino
        { get; set; }
        public decimal? Id_nfitem_destino
        { get; set; }
        public decimal? Nr_notafiscal_destino
        { get; set; }
        public string Nr_serie_destino
        { get; set; }
        private string tp_operacao;
        public string Tp_operacao
        {
            get { return tp_operacao; }
            set 
            { 
                tp_operacao = value;
                if (value.Trim().ToUpper().Equals("D"))
                    operacao = "DEVOLUÇÃO";
                else if (value.Trim().ToUpper().Equals("C"))
                    operacao = "COMPLEMENTO";
                else if (value.Trim().ToUpper().Equals("E"))
                    operacao = "ENTREGA FUTURA";
            }
        }
        private string operacao;
        public string Operacao
        {
            get { return operacao; }
            set 
            { 
                operacao = value;
                if (value.Trim().ToUpper().Equals("DEVOLUÇÃO"))
                    tp_operacao = "D";
                else if (value.Trim().ToUpper().Equals("COMPLEMENTO"))
                    tp_operacao = "C";
                else if (value.Trim().ToUpper().Equals("ENTREGA FUTURA"))
                    tp_operacao = "E";
            }
        }
        public decimal Qtd_lancto
        { get; set; }
        public decimal Vl_lancto
        { get; set; }
        public TList_RegLanParcela Parcelas
        { get; set; }
        public Producao.Producao.TList_SerieDevolvida lSerie
        { get; set; }

        public TRegistro_LanFat_ComplementoDevolucao()
        {
            id_compldev = null;
            id_compldevstr = string.Empty;
            Cd_empresa = string.Empty;
            Nm_empresa = string.Empty;
            Nr_lanctofiscal_origem = null;
            Id_nfitem_origem = null;
            Nr_lanctofiscal_destino = null;
            Id_nfitem_destino = null;
            tp_operacao = string.Empty;
            Qtd_lancto = decimal.Zero;
            Vl_lancto = decimal.Zero;
            Parcelas = new TList_RegLanParcela();
            lSerie = new Producao.Producao.TList_SerieDevolvida();
        }
    }
    
    public class TRegistro_NFCompDev
    {
        public string Cd_empresa
        { get; set; }
        public string Nm_empresa
        { get; set; }
        public decimal? Nr_lanctofiscal
        { get; set; }
        public decimal? Nr_notafiscal
        { get; set; }
        public decimal? Id_nfitem
        { get; set; }
        public string Nr_serie
        { get; set; }
        public bool St_mestra
        { get; set; }
        public string Cd_clifor
        { get; set; }
        public string Nm_clifor
        { get; set; }
        public string Cd_endereco
        { get; set; }
        public string Cd_produto
        { get; set; }
        public string Ds_produto
        { get; set; }
        public string Cd_unidProd
        { get; set; }
        public string Ds_unidProd
        { get; set; }
        public string Cd_unidValor
        { get; set; }
        public string Ds_unidValor
        { get; set; }
        public decimal Quantidade
        { get; set; }
        public decimal Vl_unitario
        { get; set; }
        public decimal? Nr_pedido
        { get; set; }
        public string Tp_movimento
        { get; set; }
        public decimal Vl_subtotal
        { get; set; }
        public decimal Qtd_devolvido
        { get; set; }
        public decimal Qtd_fixacao
        { get; set; }
        public decimal Sd_qtddevolver
        { get { return Quantidade - Qtd_devolvido - Qtd_fixacao; } }
        public decimal Vl_devolvido
        { get; set; }
        public decimal Vl_fixacao
        { get; set; }
        public decimal Sd_vldevolver
        { get { return Vl_subtotal - Vl_devolvido - (Qtd_fixacao * Vl_unitario); } }
        public decimal Qtd_complementar
        { get; set; }
        public decimal Qtd_complemento
        { get; set; }
        public decimal Sd_qtcomplementar
        { get { return Qtd_complementar - Qtd_complemento; } }
        public decimal Vl_complementar
        { get; set; }
        public decimal Vl_complemento
        { get; set; }
        public decimal Sd_vlcomplementar
        { get { return Vl_complementar - Vl_complemento; } }
        public decimal Qtd_entregafutura
        { get; set; }
        public decimal Sd_qtentregafutura
        { get { return St_mestra ? Quantidade - Qtd_entregafutura : decimal.Zero; } }
        public decimal Vl_entregafutura
        { get; set; }
        public decimal Sd_vlentregaturura
        { get { return St_mestra ? Vl_subtotal - Vl_entregafutura : decimal.Zero; } }

        public TRegistro_NFCompDev()
        {
            Cd_empresa = string.Empty;
            Nm_empresa = string.Empty;
            Nr_lanctofiscal = null;
            Nr_notafiscal = null;
            Nr_serie = string.Empty;
            St_mestra = false;
            Cd_clifor = string.Empty;
            Nm_clifor = string.Empty;
            Cd_endereco = string.Empty;
            Id_nfitem = null;
            Cd_produto = string.Empty;
            Ds_produto = string.Empty;
            Cd_unidProd = string.Empty;
            Ds_unidProd = string.Empty;
            Cd_unidValor = string.Empty;
            Ds_unidValor = string.Empty;
            Quantidade = decimal.Zero;
            Vl_unitario = decimal.Zero;
            Nr_pedido = null;
            Tp_movimento = string.Empty;
            Vl_subtotal = decimal.Zero;
            Qtd_devolvido = decimal.Zero;
            Vl_devolvido = decimal.Zero;
            Qtd_fixacao = decimal.Zero;
            Vl_fixacao = decimal.Zero;
            Qtd_complementar = decimal.Zero;
            Qtd_complemento = decimal.Zero;
            Vl_complementar = decimal.Zero;
            Vl_complemento = decimal.Zero;
            Qtd_entregafutura = decimal.Zero;
            Vl_entregafutura = decimal.Zero;
        }
    }

    public class TCD_LanFat_ComplementoDevolucao : TDataQuery
    {
        public TCD_LanFat_ComplementoDevolucao()
        { }

        public TCD_LanFat_ComplementoDevolucao(string vNM_ProcBusca)
        {
            NM_ProcSqlBusca = vNM_ProcBusca;
        }

        public TCD_LanFat_ComplementoDevolucao(BancoDados.TObjetoBanco banco)
        { Banco_Dados = banco; }

        public TCD_LanFat_ComplementoDevolucao(string vNM_ProcBusca, BancoDados.TObjetoBanco banco)
        { NM_ProcSqlBusca = vNM_ProcBusca; Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, Int32 vTop, string vNM_Campo, string vGroup, string vOrder)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("Select " + strTop + " a.CD_Empresa, b.NM_Empresa, a.NR_LanctoFiscal_Origem, ");
                sql.AppendLine("a.ID_NFItem_Origem, a.NR_LanctoFiscal_Destino, a.ID_NFItem_Destino, ");
                sql.AppendLine("a.TP_Operacao, a.QTD_Lancto, a.Vl_Lancto ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("From TB_FAT_CompDevol_NF a ");
            sql.AppendLine("inner join TB_DIV_Empresa b ");
            sql.AppendLine("On a.CD_Empresa = b.CD_Empresa ");

            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                    cond = " and ";
                }
            if (vGroup.Trim() != "")
                sql.AppendLine(" Group By " + vGroup);
            if (vOrder.Trim() != "")
                sql.AppendLine(" Order By " + vOrder);
            return sql.ToString();
        }

        private string SqlCodeBuscaNFCompDev(TpBusca[] vBusca)
        {
            string strTop = string.Empty;
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("Select " + strTop + " a.cd_empresa, b.NM_Empresa, a.nr_lanctofiscal, ");
            sql.AppendLine("a.nr_notafiscal, a.nr_serie, a.cd_clifor, c.NM_Clifor, d.st_mestra, ");
            sql.AppendLine("a.cd_endereco, a.id_nfitem, a.cd_produto, a.ds_produto, ");
            sql.AppendLine("a.cd_unidprod, a.ds_unidprod, a.cd_unidvalor, a.ds_unidvalor, ");
            sql.AppendLine("a.quantidade, a.vl_unitario, a.nr_pedido, a.tp_movimento, a.vl_subtotal, ");
            sql.AppendLine("a.qtd_devolvido, a.vl_devolvido, a.QTD_EntregaFutura, a.Vl_EntregaFutura, ");
            sql.AppendLine("a.qtd_complementar, a.qtd_complemento, a.qtd_fixacao, a.vl_fixacao, ");
            sql.AppendLine("a.vl_complementar, a.vl_complemento ");

            sql.AppendLine("from VTB_FAT_NFCOMPDEV a ");
            sql.AppendLine("inner join tb_div_empresa b ");
            sql.AppendLine("on a.cd_empresa = b.cd_empresa ");
            sql.AppendLine("inner join vtb_fin_clifor c ");
            sql.AppendLine("on a.cd_clifor = c.cd_clifor ");
            sql.AppendLine("inner join TB_FAT_NotaFiscal_CMI d ");
            sql.AppendLine("on a.CD_Empresa = d.CD_Empresa ");
            sql.AppendLine("and a.NR_LanctoFiscal = d.Nr_LanctoFiscal ");

            string cond = " and ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
            
            return sql.ToString();
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop)
        {
            if (NM_ProcSqlBusca.Trim().Equals(string.Empty))
                return ExecutarBusca(SqlCodeBusca(vBusca, vTop, string.Empty, string.Empty, string.Empty), null);
            else
            {
                Type t = GetType();
                System.Reflection.MethodInfo m = t.GetMethod(NM_ProcSqlBusca,
                                                            System.Reflection.BindingFlags.InvokeMethod | System.Reflection.BindingFlags.NonPublic |
                                                            System.Reflection.BindingFlags.Instance);
                string sql = m.Invoke(this, new object[] { vBusca, vTop, string.Empty, string.Empty, string.Empty }).ToString();
                return ExecutarBusca(sql, null);
            }
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            if (NM_ProcSqlBusca.Trim().Equals(string.Empty))
                return ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo, string.Empty, string.Empty), null);
            else
            {
                Type t = GetType();
                System.Reflection.MethodInfo m = t.GetMethod(NM_ProcSqlBusca,
                                                            System.Reflection.BindingFlags.InvokeMethod | System.Reflection.BindingFlags.NonPublic |
                                                            System.Reflection.BindingFlags.Instance);
                string sql = m.Invoke(this, new object[] { vBusca, vTop, vNM_Campo, string.Empty, string.Empty }).ToString();
                return ExecutarBusca(sql, null);
            }
        }

        public override DataTable Buscar(Utils.TpBusca[] vBusca, short vTop, string vNM_Campo, string vGroup, string vOrder, System.Collections.Hashtable vParametros)
        {
            if (NM_ProcSqlBusca.Trim().Equals(string.Empty))
                return ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo, vGroup, vOrder), vParametros);
            else
            {
                Type t = GetType();
                System.Reflection.MethodInfo m = t.GetMethod(NM_ProcSqlBusca,
                                                            System.Reflection.BindingFlags.InvokeMethod | System.Reflection.BindingFlags.NonPublic |
                                                            System.Reflection.BindingFlags.Instance);
                string sql = m.Invoke(this, new object[] { vBusca, vTop, vNM_Campo, vGroup, vOrder }).ToString();
                return ExecutarBusca(sql, vParametros);
            }
        }

        public override object BuscarEscalar(Utils.TpBusca[] vBusca, string vNM_Campo)
        {
            if (NM_ProcSqlBusca.Trim().Equals(string.Empty))
                return ExecutarBuscaEscalar(SqlCodeBusca(vBusca, 1, vNM_Campo, string.Empty, string.Empty), null);
            else
            {
                Type t = GetType();
                System.Reflection.MethodInfo m = t.GetMethod(NM_ProcSqlBusca,
                                                            System.Reflection.BindingFlags.InvokeMethod | System.Reflection.BindingFlags.NonPublic |
                                                            System.Reflection.BindingFlags.Instance);
                string sql = m.Invoke(this, new object[] { vBusca, 1, vNM_Campo, string.Empty, string.Empty }).ToString();
                return ExecutarBuscaEscalar(sql, null);
            }
        }

        public override object BuscarEscalar(Utils.TpBusca[] vBusca, string vNM_Campo, string vGroup, string vOrder, System.Collections.Hashtable vParametros)
        {
            if (NM_ProcSqlBusca.Trim().Equals(string.Empty))
                return ExecutarBuscaEscalar(SqlCodeBusca(vBusca, 1, vNM_Campo, vGroup, vOrder), vParametros);
            else
            {
                Type t = GetType();
                System.Reflection.MethodInfo m = t.GetMethod(NM_ProcSqlBusca,
                                                            System.Reflection.BindingFlags.InvokeMethod | System.Reflection.BindingFlags.NonPublic |
                                                            System.Reflection.BindingFlags.Instance);
                string sql = m.Invoke(this, new object[] { vBusca, 1, vNM_Campo, vGroup, vOrder }).ToString();
                return ExecutarBuscaEscalar(sql, vParametros);
            }
        }

        public TList_LanFat_ComplementoDevolucao Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            bool st_transacao = false;
            if (Banco_Dados == null)
                st_transacao = CriarBanco_Dados(true);

            SqlDataReader reader = ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo, string.Empty, string.Empty));
            TList_LanFat_ComplementoDevolucao lista = new TList_LanFat_ComplementoDevolucao();
            try
            {
                while (reader.Read())
                {
                    TRegistro_LanFat_ComplementoDevolucao reg = new TRegistro_LanFat_ComplementoDevolucao();
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_Empresa"))))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("CD_Empresa"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("NM_Empresa"))))
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("NM_Empresa"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("NR_LanctoFiscal_Origem"))))
                        reg.Nr_lanctofiscal_origem = reader.GetDecimal(reader.GetOrdinal("NR_LanctoFiscal_Origem"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("ID_NFItem_Origem"))))
                        reg.Id_nfitem_origem = reader.GetDecimal(reader.GetOrdinal("ID_NFItem_Origem"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("NR_LanctoFiscal_Destino"))))
                        reg.Nr_lanctofiscal_destino = reader.GetDecimal(reader.GetOrdinal("NR_LanctoFiscal_Destino"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("ID_NFItem_Destino"))))
                        reg.Id_nfitem_destino = reader.GetDecimal(reader.GetOrdinal("ID_NFItem_Destino"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("TP_Operacao"))))
                        reg.Tp_operacao = reader.GetString(reader.GetOrdinal("TP_Operacao"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("QTD_Lancto"))))
                        reg.Qtd_lancto = reader.GetDecimal(reader.GetOrdinal("QTD_Lancto"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("VL_Lancto"))))
                        reg.Vl_lancto = reader.GetDecimal(reader.GetOrdinal("VL_Lancto"));
                    lista.Add(reg);
                }
            }
            finally
            {
                reader.Close();
                reader.Dispose();
                if (st_transacao)
                    deletarBanco_Dados();
            }
            return lista;
        }

        public List<TRegistro_NFCompDev> SelectNFCompDev(TpBusca[] filtro)
        {
            bool st_transacao = false;
            if (Banco_Dados == null)
                st_transacao = CriarBanco_Dados(true);

            SqlDataReader reader = ExecutarBusca(SqlCodeBuscaNFCompDev(filtro));
            List<TRegistro_NFCompDev> lista = new List<TRegistro_NFCompDev>();
            try
            {
                while (reader.Read())
                {
                    TRegistro_NFCompDev reg = new TRegistro_NFCompDev();
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("CD_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_lanctofiscal")))
                        reg.Nr_lanctofiscal = reader.GetDecimal(reader.GetOrdinal("nr_lanctofiscal"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_notafiscal")))
                        reg.Nr_notafiscal = reader.GetDecimal(reader.GetOrdinal("nr_notafiscal"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_serie")))
                        reg.Nr_serie = reader.GetString(reader.GetOrdinal("nr_serie"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_mestra")))
                        reg.St_mestra = reader.GetString(reader.GetOrdinal("st_mestra")).Trim().ToUpper().Equals("S");
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_clifor")))
                        reg.Cd_clifor = reader.GetString(reader.GetOrdinal("cd_clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_endereco")))
                        reg.Cd_endereco = reader.GetString(reader.GetOrdinal("cd_endereco"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_nfitem")))
                        reg.Id_nfitem = reader.GetDecimal(reader.GetOrdinal("id_nfitem"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_produto")))
                        reg.Cd_produto = reader.GetString(reader.GetOrdinal("cd_produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_produto")))
                        reg.Ds_produto = reader.GetString(reader.GetOrdinal("ds_produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_unidProd")))
                        reg.Cd_unidProd = reader.GetString(reader.GetOrdinal("cd_unidProd"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_unidProd")))
                        reg.Ds_unidProd = reader.GetString(reader.GetOrdinal("ds_unidProd"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_unidValor")))
                        reg.Cd_unidValor = reader.GetString(reader.GetOrdinal("cd_unidValor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_unidValor")))
                        reg.Ds_unidValor = reader.GetString(reader.GetOrdinal("ds_unidValor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("quantidade")))
                        reg.Quantidade = reader.GetDecimal(reader.GetOrdinal("quantidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_unitario")))
                        reg.Vl_unitario = reader.GetDecimal(reader.GetOrdinal("vl_unitario"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_pedido")))
                        reg.Nr_pedido = reader.GetDecimal(reader.GetOrdinal("nr_pedido"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_movimento")))
                        reg.Tp_movimento = reader.GetString(reader.GetOrdinal("tp_movimento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_subtotal")))
                        reg.Vl_subtotal = reader.GetDecimal(reader.GetOrdinal("vl_subtotal"));
                    if (!reader.IsDBNull(reader.GetOrdinal("qtd_devolvido")))
                        reg.Qtd_devolvido = reader.GetDecimal(reader.GetOrdinal("qtd_devolvido"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_devolvido")))
                        reg.Vl_devolvido = reader.GetDecimal(reader.GetOrdinal("vl_devolvido"));
                    if (!reader.IsDBNull(reader.GetOrdinal("qtd_complementar")))
                        reg.Qtd_complementar = reader.GetDecimal(reader.GetOrdinal("qtd_complementar"));
                    if (!reader.IsDBNull(reader.GetOrdinal("qtd_complemento")))
                        reg.Qtd_complemento = reader.GetDecimal(reader.GetOrdinal("qtd_complemento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_complementar")))
                        reg.Vl_complementar = reader.GetDecimal(reader.GetOrdinal("vl_complementar"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_complemento")))
                        reg.Vl_complemento = reader.GetDecimal(reader.GetOrdinal("vl_complemento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("qtd_entregafutura")))
                        reg.Qtd_entregafutura = reader.GetDecimal(reader.GetOrdinal("qtd_entregafutura"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_entregafutura")))
                        reg.Vl_entregafutura = reader.GetDecimal(reader.GetOrdinal("vl_entregafutura"));
                    if (!reader.IsDBNull(reader.GetOrdinal("qtd_fixacao")))
                        reg.Qtd_fixacao = reader.GetDecimal(reader.GetOrdinal("qtd_fixacao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_fixacao")))
                        reg.Vl_fixacao = reader.GetDecimal(reader.GetOrdinal("vl_fixacao"));
                    
                    lista.Add(reg);
                }
                return lista;
            }
            finally
            {
                reader.Close();
                reader.Dispose();
                if (st_transacao)
                    deletarBanco_Dados();
            }
        }

        public string Gravar(TRegistro_LanFat_ComplementoDevolucao val)
        {
            Hashtable hs = new Hashtable(8);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_NR_LANCTOFISCAL_ORIGEM", val.Nr_lanctofiscal_origem);
            hs.Add("@P_ID_NFITEM_ORIGEM", val.Id_nfitem_origem);
            hs.Add("@P_NR_LANCTOFISCAL_DESTINO", val.Nr_lanctofiscal_destino);
            hs.Add("@P_ID_NFITEM_DESTINO", val.Id_nfitem_destino);
            hs.Add("@P_TP_OPERACAO", val.Tp_operacao);
            hs.Add("@P_QTD_LANCTO", val.Qtd_lancto);
            hs.Add("@P_VL_LANCTO", val.Vl_lancto);

            return executarProc("IA_FAT_COMPDEVOL_NF", hs);
        }

        public string Excluir(TRegistro_LanFat_ComplementoDevolucao val)
        {
            Hashtable hs = new Hashtable(1);
            hs.Add("@P_ID_COMPLDEV", val.Id_compldev);

            return executarProc("EXCLUI_FAT_COMPDEVOL_NF", hs);
        }
    }
}
