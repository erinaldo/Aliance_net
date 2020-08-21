using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamadaDados.Graos
{
    public class TList_CFGTaxa : List<TRegistro_CFGTaxa>
    { }

    
    public class TRegistro_CFGTaxa
    {
        private string tp_taxa;
        
        public string Tp_taxa
        {
            get { return tp_taxa; }
            set
            {
                tp_taxa = value;
                if (value.Trim().ToUpper().Equals("P"))
                    tipo_taxa = "P - % SOBRE SALDO PRODUTO";
                else if (value.Trim().ToUpper().Equals("V"))
                    tipo_taxa = "V - VALOR MONETARIO";
            }
        }
        private string tipo_taxa;
        
        public string Tipo_taxa
        {
            get { return tipo_taxa; }
            set
            {
                tipo_taxa = value;
                if (value.Trim().ToUpper().Equals("P - % SOBRE SALDO PRODUTO"))
                    tp_taxa = "P";
                else if (value.Trim().ToUpper().Equals("V - VALOR MONETARIO"))
                    tp_taxa = "V";
            }
        }
        private string tp_fiscal;
        
        public string Tp_fiscal 
        {
            get { return tp_fiscal; }
            set
            {
                tp_fiscal = value;
                switch (value.Trim().ToUpper())
                {
                    case "NO":
                        {
                            Tipo_fiscal = "LANÇAMENTO NORMAL";
                            break;
                        }
                    case "CP":
                        {
                            Tipo_fiscal = "LANÇAMENTO DE COMPLEMENTO";
                            break;
                        }
                    case "DV":
                        {
                            Tipo_fiscal = "LANÇAMENTO DE DEVOLUÇÃO";
                            break;
                        }
                    case "FT":
                        {
                            Tipo_fiscal = "LANÇAMENTO DE ENTREGA FUTURA";
                            break;
                        }
                    case "TF":
                        {
                            Tipo_fiscal = "TRANSFERENCIA ENTRE CONTRATOS";
                            break;
                        }
                    case "DF":
                        {
                            Tipo_fiscal = "DEVOLUÇÃO FISCAL";
                            break;
                        }
                    case "CF":
                        {
                            Tipo_fiscal = "COMPLEMENTO FISCAL";
                            break;
                        }
                }
            }
        }
        private string tipo_fiscal;
        
        public string Tipo_fiscal
        {
            get{return tipo_fiscal;}
            set
            {
                tipo_fiscal = value;
                switch (value.Trim().ToUpper())
                {
                    case "LANÇAMENTO NORMAL":
                        {
                            tp_fiscal = "NO";
                            break;
                        }
                    case "LANÇAMENTO DE COMPLEMENTO":
                        {
                            tp_fiscal = "CP";
                            break;
                        }
                    case "LANÇAMENTO DE DEVOLUÇÃO":
                        {
                            tp_fiscal = "DV";
                            break;
                        }
                    case "LANÇAMENTO DE ENTREGA FUTURA":
                        {
                            tp_fiscal = "FT";
                            break;
                        }
                    case "TRANSFERENCIA ENTRE CONTRATOS":
                        {
                            tp_fiscal = "TF";
                            break;
                        }
                    case "DEVOLUÇÃO FISCAL":
                        {
                            tp_fiscal = "DF";
                            break;
                        }
                    case "COMPLEMENTO FISCAL":
                        {
                            tp_fiscal = "CF";
                            break;
                        }
                }
            }
        }
        
        public string Cfg_pedido
        { get; set; }
        
        public string Ds_tipopedido
        { get; set; }
        
        public string Cd_produto
        { get; set; }
        
        public string Ds_produto
        { get; set; }
        
        public string Cd_unidproduto
        { get; set; }
        
        public string Cd_moeda
        { get; set; }
        
        public string Ds_moeda
        { get; set; }
        
        public string Sigla
        { get; set; }

        public TRegistro_CFGTaxa()
        {
            this.tp_taxa = string.Empty;
            this.tipo_taxa = string.Empty;
            this.Cfg_pedido = string.Empty;
            this.Ds_tipopedido = string.Empty;
            this.Cd_produto = string.Empty;
            this.Ds_produto = string.Empty;
            this.Cd_unidproduto = string.Empty;
            this.Cd_moeda = string.Empty;
            this.Ds_moeda = string.Empty;
            this.Sigla = string.Empty;
            this.tp_fiscal = string.Empty;
            this.tipo_fiscal = string.Empty;
        }
    }

    public class TCD_CFGTaxa : TDataQuery
    {
        public TCD_CFGTaxa()
        { }

        public TCD_CFGTaxa(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = "";
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();

            if (vNM_Campo.Length == 0)
            {
                sql.AppendLine(" SELECT " + strTop + " a.tp_taxa, a.cfg_pedido, ");
                sql.AppendLine("b.ds_tipopedido, a.cd_produto, c.ds_produto, c.cd_unidade, ");
                sql.AppendLine("a.cd_moeda, d.ds_moeda_singular, d.sigla, a.tp_fiscal ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine(" FROM tb_gro_cfgtaxa a ");
            sql.AppendLine("left outer join tb_fat_cfgpedido b ");
            sql.AppendLine("on a.cfg_pedido = b.cfg_pedido ");
            sql.AppendLine("left outer join tb_est_produto c ");
            sql.AppendLine("on a.cd_produto = c.cd_produto ");
            sql.AppendLine("left outer join tb_fin_moeda d ");
            sql.AppendLine("on a.cd_moeda = d.cd_moeda ");
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

        public TList_CFGTaxa Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_CFGTaxa lista = new TList_CFGTaxa();
            System.Data.SqlClient.SqlDataReader reader = null;
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
                    TRegistro_CFGTaxa reg = new TRegistro_CFGTaxa();
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_taxa")))
                        reg.Tp_taxa = reader.GetString(reader.GetOrdinal("tp_taxa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cfg_pedido")))
                        reg.Cfg_pedido = reader.GetString(reader.GetOrdinal("cfg_pedido"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_tipopedido")))
                        reg.Ds_tipopedido = reader.GetString(reader.GetOrdinal("ds_tipopedido"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_produto")))
                        reg.Cd_produto = reader.GetString(reader.GetOrdinal("cd_produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_produto")))
                        reg.Ds_produto = reader.GetString(reader.GetOrdinal("ds_produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Unidade")))
                        reg.Cd_unidproduto = reader.GetString(reader.GetOrdinal("CD_Unidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Moeda")))
                        reg.Cd_moeda = reader.GetString(reader.GetOrdinal("CD_Moeda"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Moeda_Singular")))
                        reg.Ds_moeda = reader.GetString(reader.GetOrdinal("DS_Moeda_Singular"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Sigla")))
                        reg.Sigla = reader.GetString(reader.GetOrdinal("Sigla"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_fiscal")))
                        reg.Tp_fiscal = reader.GetString(reader.GetOrdinal("tp_fiscal"));

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

        public string Gravar(TRegistro_CFGTaxa val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(5);
            hs.Add("@P_TP_TAXA", val.Tp_taxa);
            hs.Add("@P_CFG_PEDIDO", val.Cfg_pedido);
            hs.Add("@P_CD_PRODUTO", val.Cd_produto);
            hs.Add("@P_CD_MOEDA", val.Cd_moeda);
            hs.Add("@P_TP_FISCAL", val.Tp_fiscal);

            return this.executarProc("IA_GRO_CFGTAXA", hs);
        }

        public string Excluir(TRegistro_CFGTaxa val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(1);
            hs.Add("@P_TP_TAXA", val.Tp_taxa);

            return this.executarProc("EXCLUI_GRO_CFGTAXA", hs);
        }
    }
}
