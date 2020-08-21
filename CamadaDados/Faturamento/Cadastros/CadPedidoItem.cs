using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using Querys;
using Utils;
using System.Data;
using System.Data.SqlClient;

namespace CamadaDados.Faturamento.Cadastros
{
    public class TList_CadPedidoItem : List<TRegistro_CadPedidoItem>
    {
    }
    public class TRegistro_CadPedidoItem
    {
       
       public decimal Nr_Pedido{set; get;}
       public string Nr_Pedido_str{
           set { try { Nr_Pedido = decimal.Parse(value); } catch { } }
           get { return Nr_Pedido + ""; }
       }

       public string CD_Produto{set; get;}
       public string CD_Local{set; get;}  
       public string CD_Variedade{set; get;}
       public string CD_Unidade  {set; get;}

       public decimal  ID_Reserva{set; get;}
       public string ID_Reserva_str{
           set { try { ID_Reserva = decimal.Parse(value); } catch { } }
           get { return ID_Reserva + ""; }
       }


        public string ds_local {set; get;}  
        public string ds_variedade{set; get;}  
        public string ds_unidade{set; get;}  
        public string ds_produto{set; get;}  
 

       public string CD_Empresa {set; get;}  

       public decimal Quantidade{set; get;}
       public string Quantidade_str{
           set { try { Quantidade = decimal.Parse(value); } catch { } }
           get { return Quantidade + ""; }
       }
   
       public decimal Pc_Desc{set; get;}
       public string Pc_Desc_str{
           set { try { Pc_Desc = decimal.Parse(value); } catch { } }
           get { return Pc_Desc + ""; }
       }
      
       public decimal VL_Unitario{set; get;}
       public string VL_Unitario_str{
           set { try { VL_Unitario = decimal.Parse(value); } catch { } }
           get { return VL_Unitario + ""; }
       }
  
       public decimal VL_Comissao{set; get;}
       public string VL_Comissao_str{
           set { try { VL_Comissao = decimal.Parse(value); } catch { } }
           get { return VL_Comissao + ""; }
       }
  
       public decimal VL_FreteItem{set; get;}
       public string VL_FreteItem_str{
           set { try { VL_FreteItem = decimal.Parse(value); } catch { } }
           get { return VL_FreteItem + ""; }
       }
          
       public decimal Vl_SubTotal{set; get;}
       public string Vl_SubTotal_str{
           set { try { Vl_SubTotal = decimal.Parse(value); } catch { } }
           get { return Vl_SubTotal+ ""; }
       }
           
       public decimal Vl_Desc{set; get;}
       public string Vl_Desc_str{
           set { try { Vl_Desc = decimal.Parse(value); } catch { } }
           get { return Vl_Desc + ""; }
       }

       public decimal Pc_Comissao { set; get; }
       public string Pc_Comissao_str
       {
           set { try { Pc_Comissao = decimal.Parse(value); } catch { } }
           get { return Pc_Comissao + ""; }
       }
  
         
       public string DS_Acondicionamento  {set; get;}
       public string DS_ObservacaoItem    {set; get;}
       public string ST_Registro          {set; get;}
       public string ds_pedidoItem        {set; get;}

        public TRegistro_CadPedidoItem()
        {
           this.Nr_Pedido_str            = string.Empty;
           this.CD_Produto           = string.Empty;
           this.CD_Local             = string.Empty;
           this.CD_Variedade         = string.Empty;
           this.CD_Unidade           = string.Empty;
           this.ID_Reserva_str = string.Empty;
           this.CD_Empresa           = string.Empty;
           this.Quantidade_str = string.Empty;
           this.Pc_Desc_str = string.Empty;
           this.VL_Unitario_str = string.Empty;
           this.VL_Comissao_str = string.Empty;
           this.VL_FreteItem_str = string.Empty;
           this.Vl_SubTotal_str = string.Empty;
           this.Vl_Desc_str = string.Empty;
           this.Pc_Comissao_str = string.Empty;
           this.DS_Acondicionamento = string.Empty;
           this.DS_ObservacaoItem    = string.Empty;
           this.ST_Registro          = string.Empty;
        }
    }
    public class TCD_CadPedidoItem : TDataQuery
    {
        private string SqlCodeBusca(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = "";
            if (vTop > 0)
                strTop = " TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();

            if (vNM_Campo.Length == 0)
            {
                sql.AppendLine(" SELECT " + strTop );
                sql.AppendLine(" a.CD_Local,b.ds_local, a.CD_Variedade, c.ds_variedade , ");
                sql.AppendLine(" a.CD_Unidade,  d.ds_unidade ,");
                sql.AppendLine(" a.Nr_Pedido,  cast(a.Quantidade as  varchar)+''+e.ds_produto as ds_pedidoItem, ");
                sql.AppendLine(" a.CD_Produto, e.ds_produto, ");
                
                sql.AppendLine(" a.ID_Reserva,a.CD_Empresa,a.Quantidade, a.Pc_Desc,a.VL_Unitario, ");
                sql.AppendLine(" a.VL_Comissao,a.VL_FreteItem, a.Vl_SubTotal,a.Vl_Desc, ");
                sql.AppendLine(" a.Pc_Comissao,a.DS_Acondicionamento,a.DS_ObservacaoItem, ");
                sql.AppendLine(" a.ST_Registro ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine(" FROM TB_FAT_PedidoItens a ");
            sql.AppendLine(" left outer join TB_EST_LocalArm b on ( b.CD_Local = a.CD_Local)");
            sql.AppendLine(" left outer join TB_EST_Variedade c on ( c.cd_variedade = a.cd_variedade)");
            sql.AppendLine(" left outer join TB_EST_Unidade d on ( d.cd_unidade = a.cd_unidade)");
            sql.AppendLine(" left outer join TB_EST_Produto e on (e.cd_produto = a.cd_produto)");
            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.Append(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                    cond = " and ";
                }
            sql.AppendLine("Order By a.nr_serie asc");
            return sql.ToString();
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, ""), null);
        }

        public TList_CadPedidoItem Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_CadPedidoItem lista = new TList_CadPedidoItem();
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
                    TRegistro_CadPedidoItem reg = new TRegistro_CadPedidoItem();
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Local")))
                        reg.CD_Local= reader.GetString(reader.GetOrdinal("CD_Local"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_local")))
                        reg.ds_local = reader.GetString(reader.GetOrdinal("ds_local"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Variedade")))
                        reg.CD_Variedade = reader.GetString(reader.GetOrdinal("CD_Variedade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_variedade")))
                       reg.ds_variedade = reader.GetString(reader.GetOrdinal("ds_variedade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Unidade")))
                        reg.CD_Unidade= reader.GetString(reader.GetOrdinal("CD_Unidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_unidade")))
                        reg.ds_unidade = reader.GetString(reader.GetOrdinal("ds_unidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Nr_Pedido")))
                       reg.Nr_Pedido= reader.GetDecimal(reader.GetOrdinal("Nr_Pedido"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Produto")))
                       reg.CD_Produto= reader.GetString(reader.GetOrdinal("CD_Produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_produto")))
                       reg.ds_produto= reader.GetString(reader.GetOrdinal("ds_produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Reserva")))
                       reg.ID_Reserva= reader.GetDecimal(reader.GetOrdinal("ID_Reserva"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Empresa")))
                       reg.CD_Empresa= reader.GetString(reader.GetOrdinal("CD_Empresa"));

                    if (!reader.IsDBNull(reader.GetOrdinal("Quantidade")))
                       reg.Quantidade= reader.GetDecimal(reader.GetOrdinal("Quantidade"));
                    
                    if (!reader.IsDBNull(reader.GetOrdinal("Pc_Desc")))
                       reg.Pc_Desc= reader.GetDecimal(reader.GetOrdinal("Pc_Desc"));
                    if (!reader.IsDBNull(reader.GetOrdinal("VL_Unitario")))
                       reg.VL_Unitario= reader.GetDecimal(reader.GetOrdinal("VL_Unitario"));
                    if (!reader.IsDBNull(reader.GetOrdinal("VL_Comissao")))
                       reg.VL_Comissao= reader.GetDecimal(reader.GetOrdinal("VL_Comissao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("VL_FreteItem")))
                       reg.VL_FreteItem= reader.GetDecimal(reader.GetOrdinal("VL_FreteItem"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_SubTotal")))
                       reg.Vl_SubTotal= reader.GetDecimal(reader.GetOrdinal("Vl_SubTotal"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_Desc")))
                       reg.Vl_Desc= reader.GetDecimal(reader.GetOrdinal("Vl_Desc"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Pc_Comissao")))
                       reg.Pc_Comissao= reader.GetDecimal(reader.GetOrdinal("Pc_Comissao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Acondicionamento")))
                       reg.DS_Acondicionamento= reader.GetString(reader.GetOrdinal("DS_Acondicionamento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_ObservacaoItem")))
                       reg.DS_ObservacaoItem= reader.GetString(reader.GetOrdinal("DS_ObservacaoItem"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ST_Registro")))
                       reg.ST_Registro= reader.GetString(reader.GetOrdinal("ST_Registro"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_pedidoItem")))
                        reg.ds_pedidoItem = reader.GetString(reader.GetOrdinal("ds_pedidoItem"));
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

        public string Grava(TRegistro_CadPedidoItem vRegistro)
        {
            Hashtable hs = new Hashtable(18);
            hs.Add("@P_NR_PEDIDO",vRegistro.Nr_Pedido);       
            hs.Add("@P_CD_PRODUTO",vRegistro.CD_Produto);             
            hs.Add("@P_CD_LOCAL",vRegistro.CD_Local);     
              
            hs.Add("@P_CD_VARIEDADE",vRegistro.CD_Variedade);               
            hs.Add("@P_CD_UNIDADE",vRegistro.CD_Unidade);                 
            hs.Add("@P_ID_RESERVA",vRegistro.ID_Reserva);                 

            hs.Add("@P_CD_EMPRESA",vRegistro.CD_Empresa);                 
            hs.Add("@P_QUANTIDADE",vRegistro.Quantidade);                 
            hs.Add("@P_PC_DESC",vRegistro.Pc_Desc);                    
            
            hs.Add("@P_VL_UNITARIO",vRegistro.VL_Unitario);                
            hs.Add("@P_VL_COMISSAO",vRegistro.VL_Comissao);                
            hs.Add("@P_VL_FRETEITEM",vRegistro.VL_FreteItem);               

            hs.Add("@P_VL_SUBTOTAL",vRegistro.Vl_SubTotal);                
            hs.Add("@P_VL_DESC",vRegistro.Vl_Desc);                    
            hs.Add("@P_PC_COMISSAO",vRegistro.Pc_Comissao);                
            
            hs.Add("@P_DS_ACONDICIONAMENTO",vRegistro.DS_Acondicionamento);        
            hs.Add("@P_DS_OBSERVACAOITEM",vRegistro.DS_ObservacaoItem);
            hs.Add("@P_ST_REGISTRO", vRegistro.ST_Registro);         

            return this.executarProc("IA_FAT_PEDIDO_ITENS", hs);
        }

        public string Deleta(TRegistro_CadPedidoItem vRegistro)
        {
            Hashtable hs = new Hashtable(2);
            hs.Add("@P_NR_PEDIDO", vRegistro.Nr_Pedido);
            hs.Add("@P_CD_PRODUTO", vRegistro.CD_Produto);             
            return this.executarProc("EXCLUI_PEDIDO_ITENS", hs);
        }
    }
}