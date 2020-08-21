using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using System.Collections;
using Utils;

namespace CamadaDados.Graos
{
    public class TList_MovDeposito : List<TRegistro_MovDeposito>
    {
    }

    public class TRegistro_MovDeposito
    {
        public decimal Id_Movto { get; set; }
        public decimal Nr_Pedido { get; set; }
        public string CD_Produto { get; set; }
        public string DS_Produto { get; set; }
        public string CD_Empresa { get; set; }
        public string NM_Empresa { get; set; }
        public decimal Id_LanctoEstoque { get; set; }
        public decimal Id_pedidoitem { get; set; }
    }

    public class TRegistro_EstDeposito
    {
        public string CD_Empresa { get; set; }
        public decimal Id_LanctoEstoque { get; set; }
        public decimal Nr_Contrato { get; set; }
        public string  CD_Produto { get; set; }
        public string DS_Produto { get; set; }
        public string CD_Unidade { get; set; }
        public decimal QTD_Entrada { get; set; }
        public decimal QTD_Saida { get; set; }
        public string Tp_Movimento { get; set; }
        public DateTime DT_Lancto { get; set; }
        public decimal ID_Ticket { get; set; }
        public string Tp_Pesagem { get; set; }
        private CamadaDados.Balanca.TList_RegLanClassificacao _Classif;
        public CamadaDados.Balanca.TList_RegLanClassificacao Classif
        {
            set { _Classif = value; } 
            get 
            {
                    return _Classif;
            }
        }
    }

    public class TCD_MovDeposito : TDataQuery
    {
        public TCD_MovDeposito()
        { }

        public TCD_MovDeposito(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = "";
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();

            if (vNM_Campo.Length == 0)
            {
                sql.AppendLine(" SELECT " + strTop + " a.Id_Movto, a.Nr_Pedido, a.CD_Produto, p.DS_Produto, ");
                sql.AppendLine(" a.CD_Empresa, e.NM_Empresa, a.Id_LanctoEstoque, a.Id_pedidoitem ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine(" FROM TB_GRO_MovDeposito a ");
            sql.AppendLine(" join TB_EST_Produto p on a.cd_produto = p.cd_produto ");
            sql.AppendLine(" join TB_DIV_Empresa e on a.cd_empresa = e.cd_empresa ");

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

        public TList_MovDeposito Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_MovDeposito lista = new TList_MovDeposito();
            SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
            {
                this.CriarBanco_Dados(false);
                podeFecharBco = true;
            }

            try
            {
                reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
                while (reader.Read())
                {
                    TRegistro_MovDeposito reg = new TRegistro_MovDeposito();
                    if (!reader.IsDBNull(reader.GetOrdinal("Id_Movto")))
                        reg.Id_Movto = reader.GetDecimal(reader.GetOrdinal("Id_Movto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Nr_Pedido")))
                        reg.Nr_Pedido = reader.GetDecimal(reader.GetOrdinal("Nr_Pedido"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Produto")))
                        reg.CD_Produto = reader.GetString(reader.GetOrdinal("CD_Produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Produto")))
                        reg.DS_Produto = reader.GetString(reader.GetOrdinal("DS_Produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Empresa")))
                        reg.CD_Empresa = reader.GetString(reader.GetOrdinal("CD_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NM_Empresa")))
                        reg.NM_Empresa = reader.GetString(reader.GetOrdinal("NM_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Id_LanctoEstoque")))
                        reg.Id_LanctoEstoque = reader.GetDecimal(reader.GetOrdinal("Id_LanctoEstoque"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Id_pedidoitem")))
                        reg.Id_pedidoitem = reader.GetDecimal(reader.GetOrdinal("Id_pedidoitem"));
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

        public List<TRegistro_EstDeposito> Buscar_EstDeposito(string vCD_Empresa, string vCD_Produto, decimal vID_LanctoEstoque)
        {
            StringBuilder vSQL = new StringBuilder();
            vSQL.AppendLine("select e.cd_Empresa, e.id_lanctoEstoque, cp.nr_contrato, e.cd_produto, p.ds_produto, u.cd_unidade, ");
            vSQL.AppendLine("isnull(case when e.tp_movimento = 'E' then isnull( ap.qtd_aplicado ,e.qtd_entrada) else 0 end ,0) as qtd_entrada, ");
            vSQL.AppendLine("isnull( case when e.tp_movimento = 'S' then isnull( ap.qtd_aplicado , e.qtd_saida) else 0 end,0) as qtd_saida , e.tp_movimento, e.dt_lancto, ap.id_ticket, ap.tp_pesagem ");
            vSQL.AppendLine("from  tb_est_estoque e ");
            vSQL.AppendLine("inner join tb_est_produto p ");
            vSQL.AppendLine("on e.cd_produto = p.cd_produto ");
            vSQL.AppendLine("inner join tb_est_unidade u ");
            vSQL.AppendLine("on p.cd_unidade = u.cd_unidade ");
            vSQL.AppendLine("inner join tb_fat_pedido_X_estoque pe ");
            vSQL.AppendLine("on pe.cd_empresa = e.cd_empresa ");
            vSQL.AppendLine("and pe.cd_produto = e.cd_produto ");
            vSQL.AppendLine("and pe.id_lanctoestoque = e.id_lanctoestoque ");
            vSQL.AppendLine("inner join VTB_gro_contrato cp ");
            vSQL.AppendLine("on cp.nr_pedido = pe.nr_pedido ");
            vSQL.AppendLine("and cp.cd_produto = pe.cd_produto ");
            vSQL.AppendLine("and cp.id_pedidoitem = pe.id_pedidoitem ");
            vSQL.AppendLine(" left outer join tb_bal_aplicacao_pedido ap ");
            vSQL.AppendLine("on ap.cd_empresa = e.cd_empresa ");
            vSQL.AppendLine("and ap.cd_produto = e.cd_produto ");
            vSQL.AppendLine("and ap.id_lanctoestoque = e.id_lanctoestoque");
            
            vSQL.AppendLine("where E.CD_Empresa = '"+vCD_Empresa+"'");
            vSQL.AppendLine("  and e.cd_produto = '" + vCD_Produto + "'");
            vSQL.AppendLine("  and e.Id_lanctoEstoque = " + vID_LanctoEstoque.ToString());

            bool podeFecharBco = false;
            if (Banco_Dados == null)
            {
                this.CriarBanco_Dados(false);
                podeFecharBco = true;
            }

            List<TRegistro_EstDeposito> lreg = new List<TRegistro_EstDeposito>();            
            SqlDataReader reader = this.ExecutarBusca(vSQL.ToString());            
            try
            {
                try
                {                    
                    while (reader.Read())
                    {
                        TRegistro_EstDeposito reg = new TRegistro_EstDeposito();                        
                        if (!reader.IsDBNull(reader.GetOrdinal("CD_Empresa")))
                            reg.CD_Empresa = reader.GetString(reader.GetOrdinal("CD_Empresa"));
                        if (!reader.IsDBNull(reader.GetOrdinal("Id_LanctoEstoque")))
                            reg.Id_LanctoEstoque = reader.GetDecimal(reader.GetOrdinal("Id_LanctoEstoque"));
                        if (!reader.IsDBNull(reader.GetOrdinal("NR_Contrato")))
                            reg.Nr_Contrato = reader.GetDecimal(reader.GetOrdinal("NR_Contrato"));
                        if (!reader.IsDBNull(reader.GetOrdinal("CD_Produto")))
                            reg.CD_Produto = reader.GetString(reader.GetOrdinal("CD_Produto"));
                        if (!reader.IsDBNull(reader.GetOrdinal("DS_Produto")))
                            reg.DS_Produto = reader.GetString(reader.GetOrdinal("DS_Produto"));
                        if (!reader.IsDBNull(reader.GetOrdinal("CD_Unidade")))
                            reg.CD_Unidade = reader.GetString(reader.GetOrdinal("CD_Unidade"));
                        if (!reader.IsDBNull(reader.GetOrdinal("qtd_entrada")))
                            reg.QTD_Entrada = reader.GetDecimal(reader.GetOrdinal("qtd_entrada"));
                        if (!reader.IsDBNull(reader.GetOrdinal("qtd_saida")))
                            reg.QTD_Saida = reader.GetDecimal(reader.GetOrdinal("qtd_saida"));
                        if (!reader.IsDBNull(reader.GetOrdinal("tp_movimento")))
                            reg.Tp_Movimento = reader.GetString(reader.GetOrdinal("tp_movimento"));
                        if (!reader.IsDBNull(reader.GetOrdinal("dt_lancto")))
                            reg.DT_Lancto = reader.GetDateTime(reader.GetOrdinal("dt_lancto"));
                        if (!reader.IsDBNull(reader.GetOrdinal("id_ticket")))
                            reg.ID_Ticket = reader.GetDecimal(reader.GetOrdinal("id_ticket"));
                        if (!reader.IsDBNull(reader.GetOrdinal("tp_pesagem")))
                            reg.Tp_Pesagem = reader.GetString(reader.GetOrdinal("tp_pesagem"));

                        lreg.Add(reg);
                    }
                }
                finally
                {
                    reader.Close();
                    reader.Dispose();
                }

                lreg.ForEach(p =>
                {
                    if ((p.ID_Ticket > 0) && (p.CD_Empresa.Trim() != string.Empty))
                    {
                        CamadaDados.Balanca.TCD_LanClassificacao cla = new CamadaDados.Balanca.TCD_LanClassificacao();
                        cla.Banco_Dados = this.Banco_Dados;
                        p.Classif = cla.Select(new TpBusca[]
                                                { 
                                                    new TpBusca()
                                                    {
                                                        vNM_Campo = "a.CD_Empresa",
                                                        vOperador = "=",
                                                        vVL_Busca = "'"+p.CD_Empresa+"'"
                                                    },
                                                    new TpBusca()
                                                    {
                                                        vNM_Campo = "a.Tp_Pesagem",
                                                        vOperador = "=",
                                                        vVL_Busca = "'"+p.Tp_Pesagem+"'"                                                                            
                                                    },
                                                    new TpBusca()
                                                    {
                                                        vNM_Campo = "a.ID_Ticket",
                                                        vOperador = "=",
                                                        vVL_Busca = "'"+p.ID_Ticket.ToString()+"'"
                                                    }                                                                            
                                                }, 0, string.Empty);

                    }
                });
               
            }
            finally
            {
                if (podeFecharBco)
                    this.deletarBanco_Dados();
            }
            return lreg;
        }

        public string Grava(TRegistro_MovDeposito vRegistro)
        {
            Hashtable hs = new Hashtable(4);
            hs.Add("@P_NR_PEDIDO", vRegistro.Nr_Pedido);
            hs.Add("@P_CD_PRODUTO", vRegistro.CD_Produto);
            hs.Add("@P_CD_EMPRESA", vRegistro.CD_Empresa);
            hs.Add("@P_ID_LANCTOESTOQUE", vRegistro.Id_LanctoEstoque);
            hs.Add("@P_ID_PEDIDOITEM", vRegistro.Id_pedidoitem);
            
            return this.executarProc("IA_GRO_MOVDEPOSITO", hs);
        }

        public string Deleta(TRegistro_MovDeposito vRegistro)
        {
            Hashtable hs = new Hashtable(1);
            hs.Add("@P_ID_MOVTO", vRegistro.Id_Movto);

            return this.executarProc("EXCLUI_GRO_MOVDEPOSITO", hs);
        }
    }
}
