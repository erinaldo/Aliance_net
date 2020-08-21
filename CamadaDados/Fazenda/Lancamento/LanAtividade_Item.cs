using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using Utils;
using System.Data;
using System.Data.SqlClient;

namespace CamadaDados.Fazenda.Lancamento
{
    public class TList_LanAtividade_Item : List<TRegistro_LanAtividade_Item> 
    { }

    
    public class TRegistro_LanAtividade_Item
    {
        private decimal? id_lanctoativ;
        
        public decimal? Id_lanctoativ
        {
            get
            {
                return id_lanctoativ;
            }
            set
            {
                id_lanctoativ = value;
                id_lanctoativstr = value.Value.ToString();
            }
        }
        private string id_lanctoativstr;
        
        public string Id_lanctoativstr
        {
            get
            {
                return id_lanctoativstr;
            }
            set
            {
                id_lanctoativstr = value;
                try
                {
                    id_lanctoativ = Convert.ToDecimal(value);
                }
                catch
                {
                    id_lanctoativ = null;
                }
            }
        }
        
        public decimal? Id_item
        {
            get;
            set;
        }
        
        public string Cd_produto
        {
            get;
            set;
        }
        
        public string Ds_produto
        { get; set; }
        
        public string Sigla_unidade
        { get; set; }

        private decimal? id_equip;
        
        public decimal? Id_equip
        {
            get
            {
                return id_equip;
            }
            set
            {
                id_equip = value;
                Id_equipstr = (value.HasValue? value.Value.ToString():"");
            }
        }


        private decimal? id_implem;
        
        public decimal? Id_implem
        {
            get
            {
                return id_implem;
            }
            set
            {
                id_implem = value;
                Id_implemstr =(value.HasValue? value.Value.ToString():"");
            }
        }

        private string id_equistr;
        
        public string Id_equipstr
        {
            get
            {
                return id_equistr;
            }
            set
            {
                id_equistr = value;
                try
                {
                    id_equip = Convert.ToDecimal(value);
                }
                catch
                { id_equip = null; }
            }
        }

        private string id_implemstr;
         
        public string Id_implemstr
        {
            get
            {
                return id_implemstr;
            }
            set
            {
                id_implemstr = value;
                try
                {
                    id_implem = Convert.ToDecimal(value);
                }
                catch
                { id_implem = null; }
            }
        }

        
        public string Ds_equipamento { get; set; }
        
        
        public string Ds_implem { get; set; }

        private DateTime? dt_custo;
        
        public DateTime? Dt_custo
        {
            get { return dt_custo; }
            set
            {
                dt_custo = value;
                dt_custostr = value.Value.ToString("dd/MM/yyyy");

            }
        }
        private string dt_custostr;
        
        public string Dt_custostr
        {
            get
            {
                try
                {
                    return Convert.ToDateTime(dt_custostr).ToString("dd/MM/yyyy");
                }
                catch
                { return ""; }
            }
            set
            {
                dt_custostr = value;
                try
                {
                    dt_custo = Convert.ToDateTime(value);
                }
                catch
                { dt_custo = null; }
            }
        }

        private decimal vl_unitario;
        
        public decimal Vl_unitario
        {
            get
            {
                return vl_unitario;
            }
            set
            {
                vl_unitario = value;
                vl_total = quantidade * vl_unitario;

            }
        }

        private decimal quantidade;
        
        public decimal Quantidade
        {
            get
            {
                return quantidade;
            }
            set
            {
                quantidade = value;
                vl_total = quantidade * vl_unitario;
            }
        }

        private decimal vl_total;
        
        public decimal Vl_total
        {
            get
            {
                return vl_total;
            }
            set
            {
                vl_total = value;
                if (quantidade > 0)
                    vl_unitario = vl_total / quantidade;
            }
        }
        
        public string DS_ObservacaoGeral { get; set; }

        public TRegistro_LanAtividade_Item()
        {
            this.id_lanctoativ = null;
            this.Id_item = null;
            this.id_equip = null;
            this.id_implem = null;
            this.Cd_produto = string.Empty;
            this.Ds_produto = string.Empty;
            this.Sigla_unidade = string.Empty;
            this.Ds_equipamento = string.Empty;
            this.Ds_implem = string.Empty;
            this.dt_custo = DateTime.Now;
            this.dt_custostr = DateTime.Now.ToString("dd/MM/yyyy");
            this.vl_unitario = 0;
            this.quantidade = 0;
            this.vl_total = 0;
            this.DS_ObservacaoGeral = string.Empty;
        }
    }

    public class TCD_LanAtividade_Item : TDataQuery
    {
        public TCD_LanAtividade_Item()
        { }

        public TCD_LanAtividade_Item(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = "";
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();

            if (vNM_Campo.Length == 0)
            {
                sql.AppendLine("SELECT " + strTop + " a.id_lanctoativ, a.id_item, a.ds_observacao, ");
                sql.AppendLine("a.id_equip, b.ds_equipamento,a.id_implem, i.ds_equipamento as ds_implem, a.cd_produto, c.ds_produto, ");
                sql.AppendLine("d.sigla_unidade, a.vl_unitario, a.quantidade, a.vl_total, a.dt_custo ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("FROM TB_FAZ_LanAtividade_Item a ");
            sql.AppendLine("left outer join tb_faz_cadequipamento b ");
            sql.AppendLine("on a.id_equip = b.id_equip ");
            sql.AppendLine("left outer join tb_faz_cadequipamento i ");
            sql.AppendLine("on a.id_implem = i.id_equip ");
            sql.AppendLine("inner join tb_est_produto c ");
            sql.AppendLine("on a.cd_produto = c.cd_produto ");
            sql.AppendLine("inner join tb_est_unidade d ");
            sql.AppendLine("on c.cd_unidade = d.cd_unidade ");

          

            
            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.Append(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                    cond = " and ";
                }
            sql.Append(" ORDER BY a.id_atividade ASC ");
            return sql.ToString();
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, ""), null);
        }

        public TList_LanAtividade_Item Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_LanAtividade_Item lista = new TList_LanAtividade_Item();
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
                    TRegistro_LanAtividade_Item reg = new TRegistro_LanAtividade_Item();
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_LanctoAtiv")))
                        reg.Id_lanctoativ = reader.GetDecimal(reader.GetOrdinal("ID_LanctoAtiv"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_item")))
                        reg.Id_item = reader.GetDecimal(reader.GetOrdinal("id_item"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Equip")))
                        reg.Id_equip = reader.GetDecimal(reader.GetOrdinal("ID_Equip"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Equipamento")))
                        reg.Ds_equipamento = reader.GetString(reader.GetOrdinal("DS_Equipamento"));

                    if (!reader.IsDBNull(reader.GetOrdinal("ID_implem")))
                        reg.Id_implem = reader.GetDecimal(reader.GetOrdinal("ID_implem"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_implem")))
                        reg.Ds_implem = reader.GetString(reader.GetOrdinal("ds_implem"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Produto")))
                        reg.Cd_produto = reader.GetString(reader.GetOrdinal("CD_Produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Produto")))
                        reg.Ds_produto = reader.GetString(reader.GetOrdinal("DS_Produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Sigla_Unidade")))
                        reg.Sigla_unidade = reader.GetString(reader.GetOrdinal("Sigla_Unidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DT_Custo")))
                        reg.Dt_custo = reader.GetDateTime(reader.GetOrdinal("DT_Custo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("VL_Unitario")))
                        reg.Vl_unitario = reader.GetDecimal(reader.GetOrdinal("VL_Unitario"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Quantidade")))
                        reg.Quantidade = reader.GetDecimal(reader.GetOrdinal("Quantidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("VL_Total")))
                        reg.Vl_total = reader.GetDecimal(reader.GetOrdinal("VL_Total"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Observacao")))
                        reg.DS_ObservacaoGeral = reader.GetString(reader.GetOrdinal("DS_Observacao"));

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

        public string GravaLanAtividadeItem(TRegistro_LanAtividade_Item vRegistro)
        {
            Hashtable hs = new Hashtable(10);
            hs.Add("@P_ID_LANCTOATIV", vRegistro.Id_lanctoativ);
            hs.Add("@P_ID_ITEM", vRegistro.Id_item);
            hs.Add("@P_ID_EQUIP", vRegistro.Id_equip);
            hs.Add("@P_ID_IMPLEM", vRegistro.Id_implem);
            hs.Add("@P_CD_PRODUTO", vRegistro.Cd_produto);
            hs.Add("@P_VL_UNITARIO", vRegistro.Vl_unitario);
            hs.Add("@P_QUANTIDADE", vRegistro.Quantidade);
            hs.Add("@P_VL_TOTAL", vRegistro.Vl_total);
            hs.Add("@P_DT_CUSTO", vRegistro.Dt_custo);
            hs.Add("@P_DS_OBSERVACAO", vRegistro.DS_ObservacaoGeral);
            
           return this.executarProc("IA_FAZ_LANATIVIDADE_ITEM", hs);
        }

        public string DeletaLanAtividadeItem(TRegistro_LanAtividade_Item vRegistro)
        {
            Hashtable hs = new Hashtable(2);
            hs.Add("@P_ID_LANCTOATIV", vRegistro.Id_lanctoativ);
            hs.Add("@P_ID_ITEM", vRegistro.Id_item);

            return this.executarProc("EXCLUI_FAZ_LANATIVIDADE_ITEM", hs);
        }
    }
}
