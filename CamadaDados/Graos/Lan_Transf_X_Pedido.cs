using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using System.Collections;

namespace CamadaDados.Graos
{
    public class TList_Transf_X_Contrato : List<TRegistro_Transf_X_Contrato>
    { }
    
    public class TRegistro_Transf_X_Contrato
    {
        public decimal ID_Transf
        { get; set; }
        public string CD_Empresa
        { get; set; }
        public string TP_Movimento
        { get; set; }
        public decimal NR_LanctoFiscal
        { get; set; }
        public decimal Nr_notafiscal
        { get; set; }
        public decimal ID_NFItem
        { get; set; }
        private decimal? nr_contrato;
        public decimal? NR_Contrato
        {
            get { return nr_contrato; }
            set
            {
                nr_contrato = value;
                nr_contratostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string nr_contratostr;
        public string Nr_contratostr
        {
            get { return nr_contratostr; }
            set
            {
                nr_contratostr = value;
                try
                {
                    nr_contrato = decimal.Parse(value);
                }
                catch { nr_contrato = null; }
            }
        }
        public decimal Nr_pedido
        { get; set; }
        public decimal Id_pedidoitem
        { get; set; }
        public string NM_Empresa
        { get; set; }
        public string Cd_produto
        {get;set;}
        public string DS_Produto
        { get; set; }
        public string Cd_condfiscal_produto
        { get; set; }
        public string CD_Local
        { get; set; }
        public string DS_Local
        { get; set; }
        public DateTime? DT_Contrato
        { get; set; }
        public string CD_Clifor
        { get; set; }
        public string NM_Clifor
        { get; set; }
        public string CPF
        { get; set; }
        public string DS_Endereco
        { get; set; }
        public string DS_Cidade
        { get; set; }
        public string UF
        { get; set; }
        public decimal VL_Unitario
        { get; set; }
        public decimal Saldo_Local
        { get; set; }
        public decimal Saldo_Contrato
        { get; set; }
        public decimal QTD_Pedido
        { get; set; }
        public string CD_Unidade_VL
        { get; set; }
        public string Sigla_Unidade_VL
        { get; set; }
        public string CD_Unidade_Est
        { get; set; }
        public string Sigla_Unidade_Est
        { get; set; }
        public string TP_Movimento_contrato
        { get; set; }
        public decimal Quantidade_Transferida
        { get; set; }
        public decimal VL_Unitario_Transferido
        { get; set; }
        public decimal VL_SubTotal_Transferido
        { get; set; }
        private string st_registro;
        public string St_registro
        {
            get { return st_registro; }
            set
            {
                st_registro = value;
                if (value.Trim().ToUpper().Equals("A"))
                    status = "ABERTO";
                else if (value.Trim().ToUpper().Equals("C"))
                    status = "CANCELADO";
            }
        }
        private string status;
        public string Status
        {
            get { return status; }
            set
            {
                status = value;
                if (value.Trim().ToUpper().Equals("ABERTO"))
                    st_registro = "A";
                else if (value.Trim().ToUpper().Equals("CANCELADO"))
                    st_registro = "C";
            }
        }

        public TRegistro_Transf_X_Contrato()
        {
            this.CD_Clifor = string.Empty;
            this.CD_Empresa = string.Empty;
            this.CD_Local = string.Empty;
            this.Cd_produto = string.Empty;
            this.Cd_condfiscal_produto = string.Empty;
            this.CD_Unidade_Est = string.Empty;
            this.CD_Unidade_VL = string.Empty;
            this.CPF = string.Empty;
            this.DS_Cidade = string.Empty;
            this.DS_Endereco = string.Empty;
            this.DS_Local = string.Empty;
            this.DS_Produto = string.Empty;
            this.DT_Contrato = null;
            this.ID_NFItem = decimal.Zero;
            this.ID_Transf = decimal.Zero;
            this.NM_Clifor = string.Empty;
            this.NM_Empresa = string.Empty;
            this.nr_contrato = null;
            this.nr_contratostr = string.Empty;
            this.Nr_pedido = decimal.Zero;
            this.Id_pedidoitem = decimal.Zero;
            this.NR_LanctoFiscal = decimal.Zero;
            this.Nr_notafiscal = decimal.Zero;
            this.QTD_Pedido = decimal.Zero;
            this.Quantidade_Transferida = decimal.Zero;
            this.Saldo_Contrato = decimal.Zero;
            this.Saldo_Local = decimal.Zero;
            this.Sigla_Unidade_Est = string.Empty;
            this.Sigla_Unidade_VL = string.Empty;
            this.TP_Movimento = string.Empty;
            this.TP_Movimento_contrato = string.Empty;
            this.UF = string.Empty;
            this.VL_SubTotal_Transferido = decimal.Zero;
            this.VL_Unitario = decimal.Zero;
            this.VL_Unitario_Transferido = decimal.Zero;
            this.st_registro = string.Empty;
            this.status = string.Empty;
        }
    }

    public class TCD_Transf_X_Contrato : TDataQuery
    {
        public TCD_Transf_X_Contrato()
        { }

        public TCD_Transf_X_Contrato(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();

            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("SELECT " + strTop + " a.cd_empresa, a.id_transf, a.Tp_movimento, ");
                sql.AppendLine("b.CD_Produto, a.NR_LanctoFiscal, a.id_nfitem, c.NM_Empresa, b.Quantidade, ");
                sql.AppendLine("b.VL_Unitario, nf.nr_notafiscal, e.cd_local, f.ds_local, g.ds_produto, nf.st_registro, ");
                sql.AppendLine("a.nr_contrato, b.DT_Abertura, b.Tp_Movimento as TP_Movimento_Contrato, j.cd_clifor, j.nm_clifor, ");
                sql.AppendLine("case when j.tp_pessoa = 'J' then j.nr_cgc else j.nr_cpf end as nr_cgc_cpf, ");
                sql.AppendLine("k.ds_endereco, k.ds_Cidade, k.uf, g.cd_condfiscal_produto, ");
                sql.AppendLine("b.CD_Unidade as CD_Unidade_Vl, b.nr_pedido, b.id_pedidoitem, ");
                sql.AppendLine("g.cd_Unidade as CD_Unidade_Est, ");
                sql.AppendLine("l.Sigla_unidade as Sigla_Unidade_Vl, ");
                sql.AppendLine("m.Sigla_Unidade as Sigla_Unidade_Est, ");
                sql.AppendLine("e.quantidade as Quantidade_Transferida, ");
                sql.AppendLine("e.VL_unitario as VL_Unitario_Transferido, e.VL_SubTotal as VL_SubTotal_Transferido ");
             }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("FROM tb_gro_transf_X_Contrato a ");
            sql.AppendLine("inner join VTB_GRO_CONTRATO b ");
            sql.AppendLine("on a.nr_contrato = b.nr_contrato ");
            sql.AppendLine("inner join tb_div_Empresa c ");
            sql.AppendLine("on c.cd_empresa = a.cd_empresa ");
            sql.AppendLine("inner join tb_fat_notafiscal_item e ");
            sql.AppendLine("on e.CD_Empresa = a.cd_empresa ");
            sql.AppendLine("and e.nr_lanctofiscal = a.nr_lanctofiscal ");
            sql.AppendLine("and e.ID_NFItem = a.id_nfItem ");
            sql.AppendLine("inner join tb_fat_notafiscal nf ");
            sql.AppendLine("on a.cd_empresa = nf.cd_empresa ");
            sql.AppendLine("and a.nr_lanctofiscal = nf.nr_lanctofiscal ");
            sql.AppendLine("inner join tb_est_localarm f ");
            sql.AppendLine("on f.cd_local = e.cd_local ");
            sql.AppendLine("inner join tb_est_produto g ");
            sql.AppendLine("on g.cd_produto = b.CD_Produto ");
            sql.AppendLine("inner join Vtb_fin_Clifor j ");
            sql.AppendLine("on j.cd_clifor = b.CD_Clifor ");
            sql.AppendLine("inner join vtb_fin_endereco k ");
            sql.AppendLine("on k.cd_clifor = b.CD_Clifor ");
            sql.AppendLine("and k.cd_endereco = b.CD_Endereco ");
            sql.AppendLine("left outer join tb_est_unidade l ");
            sql.AppendLine("on l.cd_unidade = g.CD_Unidade ");
            sql.AppendLine("left outer join tb_est_Unidade m ");
            sql.AppendLine("on m.cd_unidade = g.cd_unidade ");
            
            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.Append(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                    cond = " and ";
                }

            return sql.ToString();
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, ""), null);
        }

        public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
        {
            return this.ExecutarBuscaEscalar(this.SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }
        
        public TList_Transf_X_Contrato Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_Transf_X_Contrato lista = new TList_Transf_X_Contrato();
            SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);

            try
            {
                reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
                while (reader.Read())
                {
                    TRegistro_Transf_X_Contrato reg = new TRegistro_Transf_X_Contrato();
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Transf")))
                        reg.ID_Transf = reader.GetDecimal(reader.GetOrdinal("ID_Transf"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Empresa")))
                        reg.CD_Empresa = reader.GetString(reader.GetOrdinal("CD_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("TP_Movimento")))
                        reg.TP_Movimento = reader.GetString(reader.GetOrdinal("TP_Movimento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Produto")))
                        reg.Cd_produto = reader.GetString(reader.GetOrdinal("CD_Produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_condfiscal_produto")))
                        reg.Cd_condfiscal_produto = reader.GetString(reader.GetOrdinal("cd_condfiscal_produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NR_LanctoFiscal")))
                        reg.NR_LanctoFiscal = reader.GetDecimal(reader.GetOrdinal("NR_LanctoFiscal"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_NFItem")))
                        reg.ID_NFItem = reader.GetDecimal(reader.GetOrdinal("ID_NFItem"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NR_NotaFiscal")))
                        reg.Nr_notafiscal = reader.GetDecimal(reader.GetOrdinal("NR_NotaFiscal"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NR_Contrato")))
                        reg.NR_Contrato = reader.GetDecimal(reader.GetOrdinal("NR_Contrato"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_pedido")))
                        reg.Nr_pedido = reader.GetDecimal(reader.GetOrdinal("nr_pedido"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_pedidoitem")))
                        reg.Id_pedidoitem = reader.GetDecimal(reader.GetOrdinal("id_pedidoitem"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NM_Empresa")))
                        reg.NM_Empresa = reader.GetString(reader.GetOrdinal("NM_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NM_Empresa")))
                        reg.NM_Empresa = reader.GetString(reader.GetOrdinal("NM_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Produto")))
                        reg.DS_Produto = reader.GetString(reader.GetOrdinal("DS_Produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Local")))
                        reg.CD_Local = reader.GetString(reader.GetOrdinal("CD_Local"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Local")))
                        reg.DS_Local = reader.GetString(reader.GetOrdinal("DS_Local"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Quantidade")))
                        reg.QTD_Pedido = reader.GetDecimal(reader.GetOrdinal("Quantidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DT_Abertura")))
                        reg.DT_Contrato = reader.GetDateTime(reader.GetOrdinal("DT_Abertura"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Clifor")))
                        reg.CD_Clifor = reader.GetString(reader.GetOrdinal("CD_Clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NM_Clifor")))
                        reg.NM_Clifor = reader.GetString(reader.GetOrdinal("NM_Clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_cgc_cpf")))
                        reg.CPF = reader.GetString(reader.GetOrdinal("nr_cgc_cpf"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Endereco")))
                        reg.DS_Endereco = reader.GetString(reader.GetOrdinal("DS_Endereco"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Cidade")))
                        reg.DS_Cidade = reader.GetString(reader.GetOrdinal("DS_Cidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("UF")))
                        reg.UF = reader.GetString(reader.GetOrdinal("UF"));
                    if (!reader.IsDBNull(reader.GetOrdinal("VL_Unitario")))
                        reg.VL_Unitario = reader.GetDecimal(reader.GetOrdinal("VL_Unitario"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Unidade_Vl")))
                        reg.CD_Unidade_VL = reader.GetString(reader.GetOrdinal("CD_Unidade_Vl"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Unidade_Est")))
                        reg.CD_Unidade_Est = reader.GetString(reader.GetOrdinal("CD_Unidade_Est"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Sigla_Unidade_Est")))
                        reg.Sigla_Unidade_Est = reader.GetString(reader.GetOrdinal("Sigla_Unidade_Est"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Sigla_Unidade_Vl")))
                        reg.Sigla_Unidade_VL = reader.GetString(reader.GetOrdinal("Sigla_Unidade_Vl"));
                    if (!reader.IsDBNull(reader.GetOrdinal("TP_Movimento_Contrato")))
                        reg.TP_Movimento_contrato = reader.GetString(reader.GetOrdinal("TP_Movimento_Contrato"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Quantidade_Transferida")))
                        reg.Quantidade_Transferida = reader.GetDecimal(reader.GetOrdinal("Quantidade_Transferida"));
                    if (!reader.IsDBNull(reader.GetOrdinal("VL_Unitario_transferido")))
                        reg.VL_Unitario_Transferido = reader.GetDecimal(reader.GetOrdinal("VL_Unitario_transferido"));
                    if (!reader.IsDBNull(reader.GetOrdinal("VL_SubTotal_Transferido")))
                        reg.VL_SubTotal_Transferido = reader.GetDecimal(reader.GetOrdinal("VL_SubTotal_Transferido"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ST_Registro")))
                        reg.St_registro = reader.GetString(reader.GetOrdinal("ST_Registro"));
                    
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

        public string Gravar(TRegistro_Transf_X_Contrato vRegistro)
        {
            Hashtable hs = new Hashtable(6);
            hs.Add("@P_ID_TRANSF", vRegistro.ID_Transf);
            hs.Add("@P_CD_EMPRESA", vRegistro.CD_Empresa);
            hs.Add("@P_TP_MOVIMENTO", vRegistro.TP_Movimento);
            hs.Add("@P_NR_CONTRATO", vRegistro.NR_Contrato);
            hs.Add("@P_NR_LANCTOFISCAL", vRegistro.NR_LanctoFiscal);
            hs.Add("@P_ID_NFITEM", vRegistro.ID_NFItem);

            return this.executarProc("IA_GRO_TRANSF_X_CONTRATO", hs);
        }

        public string Excluir(TRegistro_Transf_X_Contrato vRegistro)
        {
            Hashtable hs = new Hashtable(3);
            hs.Add("@P_ID_TRANSF", vRegistro.ID_Transf);
            hs.Add("@P_CD_EMPRESA", vRegistro.CD_Empresa);
            hs.Add("@P_TP_MOVIMENTO", vRegistro.TP_Movimento);

            return this.executarProc("EXCLUI_GRO_TRANSF_X_CONTRATO", hs);
        }
    }
}
