using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;
using System.Data.SqlClient;

namespace CamadaDados.Compra.Lancamento
{
    public class TList_PrazoEntrega : List<TRegistro_PrazoEntrega>
    { }

    
    public class TRegistro_PrazoEntrega
    {
        
        public decimal? Id_negociacao
        { get; set; }
        
        public decimal? Id_item
        { get; set; }
        
        public string Cd_empresa
        { get; set; }
        
        public string Nm_empresa
        { get; set; }
        
        public decimal Prazo_entrega
        { get; set; }
        
        public string Cd_transportadora
        { get; set; }
        
        public string Nm_transportadora
        { get; set; }
        
        public string Cd_endtransportadora
        { get; set; }
        
        public string Ds_endtransportadora
        { get; set; }
        private string tp_frete;
        
        public string Tp_frete
        {
            get { return tp_frete; }
            set
            {
                tp_frete = value;
                if (value.Trim().ToUpper().Equals("1"))
                    tipo_frete = "EMITENTE";
                else if (value.Trim().ToUpper().Equals("2"))
                    tipo_frete = "DESTINATARIO";
            }
        }
        private string tipo_frete;
        
        public string Tipo_frete
        {
            get { return tipo_frete; }
            set
            {
                tipo_frete = value;
                if (value.Trim().ToUpper().Equals("EMITENTE"))
                    tp_frete = "1";
                else if (value.Trim().ToUpper().Equals("DESTINATARIO"))
                    tp_frete = "2";
            }
        }

        public TRegistro_PrazoEntrega()
        {
            this.Id_negociacao = null;
            this.Id_item = null;
            this.Cd_empresa = string.Empty;
            this.Nm_empresa = string.Empty;
            this.Prazo_entrega = decimal.Zero;
            this.Cd_transportadora = string.Empty;
            this.Nm_transportadora = string.Empty;
            this.Cd_endtransportadora = string.Empty;
            this.Ds_endtransportadora = string.Empty;
            this.tp_frete = "1";
            this.tipo_frete = "EMITENTE";
        }
    }

    public class TCD_PrazoEntrega : TDataQuery
    {
        public TCD_PrazoEntrega()
        { }

        public TCD_PrazoEntrega(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, Int16 vTop, string vNM_Campo)
        {
            string cond = " "; string strTop;
            int i;
            strTop = " ";

            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (vNM_Campo.Trim().Equals(""))
            {

                sql.AppendLine("select " + strTop + " a.id_negociacao, a.id_item, ");
                sql.AppendLine("a.cd_empresa, b.nm_empresa, a.prazo_entrega, a.tp_frete, ");
                sql.AppendLine("a.cd_transportadora, c.nm_clifor as nm_transportadora, ");
                sql.AppendLine("a.cd_endtransportadora, d.ds_endereco as ds_endtransportadora ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from tb_cmp_prazoentrega a ");
            sql.AppendLine("inner join tb_div_empresa b ");
            sql.AppendLine("on a.cd_empresa = b.cd_empresa ");
            sql.AppendLine("left outer join vtb_fin_clifor c ");
            sql.AppendLine("on a.cd_transportadora = c.cd_clifor ");
            sql.AppendLine("left outer join vtb_fin_endereco d ");
            sql.AppendLine("on a.cd_transportadora = d.cd_clifor ");
            sql.AppendLine("and a.cd_endtransportadora = d.cd_endereco ");
            cond = " where ";

            if (vBusca != null)
                for (i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + ")");
                    cond = " and ";
                }
            return sql.ToString();
        }

        public override System.Data.DataTable Buscar(TpBusca[] vBusca, short vTop)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, string.Empty), null);
        }

        public override System.Data.DataTable Buscar(TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo), null);
        }

        public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
        {
            return this.ExecutarBuscaEscalar(this.SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }

        public TList_PrazoEntrega Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_PrazoEntrega lista = new TList_PrazoEntrega();
            SqlDataReader reader;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
            {
                this.CriarBanco_Dados(false);
                podeFecharBco = true;
            }
            reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_PrazoEntrega reg = new TRegistro_PrazoEntrega();
                    if (!(reader.IsDBNull(reader.GetOrdinal("ID_Negociacao"))))
                        reg.Id_negociacao = reader.GetDecimal(reader.GetOrdinal("ID_Negociacao"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("ID_Item"))))
                        reg.Id_item = reader.GetDecimal(reader.GetOrdinal("ID_Item"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_Empresa"))))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("CD_Empresa"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("NM_Empresa"))))
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("NM_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Prazo_entrega")))
                        reg.Prazo_entrega = reader.GetDecimal(reader.GetOrdinal("Prazo_entrega"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Transportadora")))
                        reg.Cd_transportadora = reader.GetString(reader.GetOrdinal("CD_Transportadora"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NM_Transportadora")))
                        reg.Nm_transportadora = reader.GetString(reader.GetOrdinal("NM_Transportadora"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_EndTransportadora")))
                        reg.Cd_endtransportadora = reader.GetString(reader.GetOrdinal("CD_EndTransportadora"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_EndTransportadora")))
                        reg.Ds_endtransportadora = reader.GetString(reader.GetOrdinal("DS_EndTransportadora"));
                    if (!reader.IsDBNull(reader.GetOrdinal("TP_Frete")))
                        reg.Tp_frete = reader.GetString(reader.GetOrdinal("TP_Frete"));

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

        public string GravarPrazoEntrega(TRegistro_PrazoEntrega val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(7);
            hs.Add("@P_ID_NEGOCIACAO", val.Id_negociacao);
            hs.Add("@P_ID_ITEM", val.Id_item);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_PRAZO_ENTREGA", val.Prazo_entrega);
            hs.Add("@P_CD_TRANSPORTADORA", val.Cd_transportadora);
            hs.Add("@P_CD_ENDTRANSPORTADORA", val.Cd_endtransportadora);
            hs.Add("@P_TP_FRETE", val.Tp_frete);

            return this.executarProc("IA_CMP_PRAZOENTREGA", hs);
        }

        public string DeletarPrazoEntrega(TRegistro_PrazoEntrega val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(3);
            hs.Add("@P_ID_NEGOCIACAO", val.Id_negociacao);
            hs.Add("@P_ID_ITEM", val.Id_item);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);

            return this.executarProc("EXCLUI_CMP_PRAZOENTREGA", hs);
        }
    }
}
