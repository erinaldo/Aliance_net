using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;
using System.Data;
using System.Data.SqlClient;
using System.Collections;

namespace CamadaDados.Diversos
{
   public class TList_CadTerminal :List<TRegistro_CadTerminal>, IComparer<TRegistro_CadTerminal>
   {
       #region IComparer<TRegistro_CadTerminal> Members
        private System.ComponentModel.PropertyDescriptor Propriedade;
        private System.Windows.Forms.SortOrder Direcao;

        private int CompareAscending(object x, object y)
        {
            if (x is IComparable)
                return new System.Collections.CaseInsensitiveComparer().Compare(x, y);
            else
                return 0;
        }

        private int CompareDescending(object x, object y)
        {
            return -CompareAscending(x, y);
        }

        public TList_CadTerminal()
        { }

        public TList_CadTerminal(System.ComponentModel.PropertyDescriptor Prop,
                                 System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_CadTerminal value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_CadTerminal x, TRegistro_CadTerminal y)
        {
            object col1 = GetPropertyValue(x, Propriedade.Name);
            object col2 = GetPropertyValue(y, Propriedade.Name);
            if (Direcao == System.Windows.Forms.SortOrder.Ascending)
                return CompareAscending(col1, col2);
            else
                return CompareDescending(col1, col2);
        }
       #endregion
   }

   public class TRegistro_CadTerminal
    {
        private decimal? id_layout;
        public decimal? Id_layout
        {
            get { return id_layout; }
            set
            {
                id_layout = value;
                id_layoutstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_layoutstr;
        public string id_contato { get; set; } = string.Empty;
        public string Nm_contato { get; set; } = string.Empty;
        public string Fone_contato { get; set; } = string.Empty;
        public string Email_contato { get; set; } = string.Empty;
        public string Id_layoutstr
        {
            get { return id_layoutstr; }
            set
            {
                id_layoutstr = value;
                try
                {
                    id_layout = decimal.Parse(value);
                }
                catch { id_layout = null; }
            }
        }
        public string Cd_Terminal{ get;set;}
        public string Ds_Terminal{get;set; }
        private string tp_imptick;
        public string Tp_imptick
        {
            get { return tp_imptick; }
            set
            {
                tp_imptick = value;
                if (value.Trim().ToUpper().Equals("G"))
                    tipo_imptick = "GRAFICA";
                else if (value.Trim().ToUpper().Equals("T"))
                    tipo_imptick = "TEXTO";
                else if (value.Trim().ToUpper().Equals("R"))
                    tipo_imptick = "REDUZIDA";
            }
        }
        private string tipo_imptick;
        public string Tipo_imptick
        {
            get { return tipo_imptick; }
            set
            {
                tipo_imptick = value;
                if (value.Trim().ToUpper().Equals("GRAFICA"))
                    tp_imptick = "G";
                else if (value.Trim().ToUpper().Equals("TEXTO"))
                    tp_imptick = "T";
                else if (value.Trim().ToUpper().Equals("REDUZIDA"))
                    tp_imptick = "R";
            }
        }
        private string tp_imptickavulso;
        public string Tp_imptickavulso
        {
            get { return tp_imptickavulso; }
            set
            {
                tp_imptickavulso = value;
                if (value.Trim().ToUpper().Equals("G"))
                    tipo_imptickavulso = "GRAFICA";
                else if (value.Trim().ToUpper().Equals("T"))
                    tipo_imptickavulso = "TEXTO";
            }
        }
        private string tipo_imptickavulso;
        public string Tipo_imptickavulso
        {
            get { return tipo_imptickavulso; }
            set
            {
                tipo_imptickavulso = value;
                if (value.Trim().ToUpper().Equals("GRAFICA"))
                    tp_imptickavulso = "G";
                else if (value.Trim().ToUpper().Equals("TEXTO"))
                    tp_imptickavulso = "T";
            }
        }
        private string tp_imppedido;
        public string Tp_imppedido
        {
            get { return tp_imppedido; }
            set
            {
                tp_imppedido = value;
                if (value.Trim().ToUpper().Equals("G"))
                    tipo_imppedido = "GRAFICA";
                else if (value.Trim().ToUpper().Equals("T"))
                    tipo_imppedido = "TEXTO";
            }
        }
        private string tipo_imppedido;
        public string Tipo_imppedido
        {
            get { return tipo_imppedido; }
            set
            {
                tipo_imppedido = value;
                if (value.Trim().ToUpper().Equals("GRAFICA"))
                    tp_imppedido = "G";
                else if (value.Trim().ToUpper().Equals("TEXTO"))
                    tp_imppedido = "T";
            }
        }
        private string tp_imporcamento;
        public string Tp_imporcamento
        {
            get { return tp_imporcamento; }
            set
            {
                tp_imporcamento = value;
                if (value.Trim().ToUpper().Equals("G"))
                    tipo_imporcamento = "GRAFICA";
                else if (value.Trim().ToUpper().Equals("T"))
                    tipo_imporcamento = "TEXTO";
                else if (value.Trim().ToUpper().Equals("R"))
                    tipo_imporcamento = "REDUZIDA";
                else if (value.Trim().ToUpper().Equals("F"))
                    tipo_imporcamento = "GRAFICA REDUZIDA";
            }
        }
        private string tipo_imporcamento;
        public string Tipo_imporcamento
        {
            get { return tipo_imporcamento; }
            set
            {
                tipo_imporcamento = value;
                if (value.Trim().ToUpper().Equals("GRAFICA"))
                    tp_imporcamento = "G";
                else if (value.Trim().ToUpper().Equals("TEXTO"))
                    tp_imporcamento = "T";
                else if (value.Trim().ToUpper().Equals("REDUZIDA"))
                    tp_imporcamento = "R";
                else if (value.Trim().ToUpper().Equals("GRAFICA REDUZIDA"))
                    tp_imporcamento = "F";
            }
        }
        private string tp_imprecibo;
        public string Tp_imprecibo
        {
            get { return tp_imprecibo; }
            set
            {
                tp_imprecibo = value;
                if (value.Trim().ToUpper().Equals("G"))
                    tipo_imprecibo = "GRAFICA";
                else if (value.Trim().ToUpper().Equals("T"))
                    tipo_imprecibo = "TEXTO";
                else if (value.Trim().ToUpper().Equals("R"))
                    tipo_imprecibo = "REDUZIDA";
                else if (value.Trim().ToUpper().Equals("F"))
                    tipo_imprecibo = "GRAFICA REDUZIDA";
            }
        }
        private string tipo_imprecibo;
        public string Tipo_imprecibo
        {
            get { return tipo_imprecibo; }
            set
            {
                tipo_imprecibo = value;
                if (value.Trim().ToUpper().Equals("GRAFICA"))
                    tp_imprecibo = "G";
                else if (value.Trim().ToUpper().Equals("TEXTO"))
                    tp_imprecibo = "T";
                else if (value.Trim().ToUpper().Equals("REDUZIDA"))
                    tp_imprecibo = "R";
                else if (value.Trim().ToUpper().Equals("GRAFICA REDUZIDA"))
                    tp_imprecibo = "F";
            }
        }
        private string tp_impcheque;
        public string Tp_impcheque
        {
            get { return tp_impcheque; }
            set
            {
                tp_impcheque = value;
                if (value.Trim().ToUpper().Equals("G"))
                    tipo_impcheque = "GRAFICA";
                else if (value.Trim().ToUpper().Equals("T"))
                    tipo_impcheque = "TEXTO";
            }
        }
        private string tipo_impcheque;
        public string Tipo_impcheque
        {
            get { return tipo_impcheque; }
            set
            {
                tipo_impcheque = value;
                if (value.Trim().ToUpper().Equals("GRAFICA"))
                    tp_impcheque = "G";
                else if (value.Trim().ToUpper().Equals("TEXTO"))
                    tp_impcheque = "T";
            }
        }
        private string tp_impos;
        public string Tp_impos
        {
            get { return tp_impos; }
            set
            {
                tp_impos = value;
                tipo_impos = value.Trim().ToUpper().Equals("T") ? "TEXTO" : value.Trim().ToUpper().Equals("G") ? "GRAFICA" : value.Trim().ToUpper().Equals("R") ? "REDUZIDA" : string.Empty;
            }
        }
        private string tipo_impos;
        public string Tipo_impos
        {
            get { return tipo_impos; }
            set
            {
                tipo_impos = value;
                tp_impos = value.Trim().ToUpper().Equals("TEXTO") ? "T" : value.Trim().ToUpper().Equals("GRAFICA") ? "G" : value.Trim().ToUpper().Equals("REDUZIDA") ? "R" : string.Empty;
            }
        }
        private string tp_impetiqueta;
        public string Tp_impetiqueta
        {
            get { return tp_impetiqueta; }
            set
            {
                tp_impetiqueta = value;
                tipo_impetiqueta = value.Trim().ToUpper().Equals("N") ? "NORMAL" : value.Trim().ToUpper().Equals("Z") ? "ZEBRA" : string.Empty;
            }
        }
        private string tipo_impetiqueta;
        public string Tipo_impetiqueta
        {
            get { return tipo_impetiqueta; }
            set
            {
                tipo_impetiqueta = value;
                tp_impetiqueta = value.Trim().ToUpper().Equals("NORMAL") ? "N" : value.Trim().ToUpper().Equals("ZEBRA") ? "Z" : string.Empty;
            }
        }
        private string layoutetiqueta;
        public string Layoutetiqueta
        {
            get { return layoutetiqueta; }
            set
            {
                layoutetiqueta = value;
                if (value.Trim().Equals("1"))
                    layoutetiquetastr = "LAYOUT 1";
                else if (value.Trim().Equals("2"))
                    layoutetiquetastr = "LAYOUT 2";
                else if (value.Trim().Equals("3"))
                    layoutetiquetastr = "LAYOUT 3";
                else if (value.Trim().Equals("4"))
                    layoutetiquetastr = "ELGIN 1<PRODUTO;COD BARRA>";
                else if (value.Trim().Equals("5"))
                    layoutetiquetastr = "ELGIN 2<PRODUTO;COD BARRA;PREÇO>";
            }
        }
        private string layoutetiquetastr;
        public string Layoutetiquetastr
        {
            get { return layoutetiquetastr; }
            set
            {
                layoutetiquetastr = value;
                if (value.Trim().ToUpper().Equals("LAYOUT 1"))
                    layoutetiqueta = "1";
                else if (value.Trim().ToUpper().Equals("LAYOUT 2"))
                    layoutetiqueta = "2";
                else if (value.Trim().ToUpper().Equals("LAYOUT 3"))
                    layoutetiqueta = "3";
                else if (value.Trim().ToUpper().Equals("ELGIN 1<PRODUTO;COD BARRA>"))
                    layoutetiqueta = "4";
                else if (value.Trim().ToUpper().Equals("ELGIN 2<PRODUTO;COD BARRA;PREÇO>"))
                    layoutetiqueta = "5";
            }
        }
        public string Porta_imptick
        { get; set; }
        public string Mapearportatick
        { get; set; }
        public string St_Registro{get; set ;}
        public string Nr_serial
        { get; set; }
        public string Chave_acesso
        { get; set; }
        public string ImpressoraPadrao
        { get; set; }
        public bool St_processar
        { get; set; }

       public TRegistro_CadTerminal()
       {
           this.Cd_Terminal = string.Empty;
           this.id_layout = decimal.Zero;
           this.Id_layoutstr = string.Empty;
           this.Ds_Terminal = string.Empty;
           this.Porta_imptick = string.Empty;
           this.Mapearportatick = string.Empty;
           this.tp_imptick = string.Empty;
           this.tipo_imptick = string.Empty;
           this.tp_imptickavulso = string.Empty;
           this.tipo_imptickavulso = string.Empty;
           this.tp_imppedido = string.Empty;
           this.tipo_imppedido = string.Empty;
           this.tp_imporcamento = string.Empty;
           this.tipo_imporcamento = string.Empty;
           this.tp_imprecibo = string.Empty;
           this.tipo_imprecibo = string.Empty;
           this.tp_impcheque = string.Empty;
           this.tipo_impcheque = string.Empty;
           this.tp_impos = string.Empty;
           this.tipo_impos = string.Empty;
           this.tp_impetiqueta = string.Empty;
           this.tipo_impetiqueta = string.Empty;
           this.layoutetiqueta = string.Empty;
           this.layoutetiquetastr = string.Empty;
           this.St_Registro = "A";
           this.Nr_serial = string.Empty;
           this.Chave_acesso = string.Empty;
           this.ImpressoraPadrao = string.Empty;
           this.St_processar = false;
       }
   }

   public class TCD_CadTerminal : TDataQuery
   {
       public TCD_CadTerminal()
       { }

       public TCD_CadTerminal(BancoDados.TObjetoBanco banco)
       { this.Banco_Dados = banco; }

       private string SqlCodeBusca(TpBusca[] vBusca, Int32 vTop , string vNM_Campo)
       {
           string strTop = string.Empty;
           if (vTop > 0)
               strTop = " TOP " + Convert.ToString(vTop);
           StringBuilder sql = new StringBuilder();

           if (string.IsNullOrEmpty(vNM_Campo))
           {
               sql.AppendLine("SELECT " + strTop + " a.id_layout ,a.cd_terminal, a.ds_terminal, a.impressorapadrao, ");
               sql.AppendLine("a.porta_imptick, a.tp_imptick, a.st_registro, a.mapearportatick, ");
               sql.AppendLine("a.nr_serial, a.chave_acesso, a.tp_imptickavulso, a.tp_impcheque, ");
               sql.AppendLine("a.tp_imppedido, a.tp_imporcamento, a.tp_imprecibo, a.tp_impos, ");
               sql.AppendLine("a.tp_impetiqueta, a.layoutetiqueta ");
           }
           else
               sql.AppendLine(" SELECT " + strTop + " " + vNM_Campo + " ");
               
           sql.AppendLine(" FROM tb_div_terminal a ");
           

           string cond = " where ";
           if(vBusca!=null)
             for (int i = 0; i < (vBusca.Length); i++)
             {
                   sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                   cond = "and";
             }
           sql.AppendLine("Order By a.cd_terminal asc");
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

       public TList_CadTerminal Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
       {
           TList_CadTerminal lista = new TList_CadTerminal();
           SqlDataReader reader = null;
           bool podeFecharBco = false;
           if (Banco_Dados == null)
               podeFecharBco = this.CriarBanco_Dados(false);
           try
           {
               reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
               while (reader.Read())
               {
                    TRegistro_CadTerminal reg = new TRegistro_CadTerminal();
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_Terminal"))) 
                        reg.Cd_Terminal = reader.GetString(reader.GetOrdinal("cd_Terminal"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_terminal"))) 
                        reg.Ds_Terminal = reader.GetString(reader.GetOrdinal("ds_terminal"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Porta_imptick")))
                       reg.Porta_imptick = reader.GetString(reader.GetOrdinal("Porta_imptick"));
                    if (!reader.IsDBNull(reader.GetOrdinal("MapearPortaTick")))
                        reg.Mapearportatick = reader.GetString(reader.GetOrdinal("MapearPortaTick"));
                   if (!reader.IsDBNull(reader.GetOrdinal("TP_ImpTick")))
                       reg.Tp_imptick = reader.GetString(reader.GetOrdinal("TP_ImpTick"));
                   if (!reader.IsDBNull(reader.GetOrdinal("TP_ImpTickAvulso")))
                       reg.Tp_imptickavulso = reader.GetString(reader.GetOrdinal("TP_ImpTickAvulso"));
                   if (!reader.IsDBNull(reader.GetOrdinal("TP_ImpPedido")))
                       reg.Tp_imppedido = reader.GetString(reader.GetOrdinal("TP_ImpPedido"));
                   if (!reader.IsDBNull(reader.GetOrdinal("TP_ImpOrcamento")))
                       reg.Tp_imporcamento = reader.GetString(reader.GetOrdinal("TP_ImpOrcamento"));
                   if (!reader.IsDBNull(reader.GetOrdinal("TP_ImpRecibo")))
                       reg.Tp_imprecibo = reader.GetString(reader.GetOrdinal("TP_ImpRecibo"));
                   if (!reader.IsDBNull(reader.GetOrdinal("tp_impcheque")))
                       reg.Tp_impcheque = reader.GetString(reader.GetOrdinal("tp_impcheque"));
                   if (!reader.IsDBNull(reader.GetOrdinal("st_Registro"))) 
                        reg.St_Registro = reader.GetString(reader.GetOrdinal("st_Registro"));
                   if (!reader.IsDBNull(reader.GetOrdinal("NR_Serial")))
                       reg.Nr_serial = reader.GetString(reader.GetOrdinal("NR_Serial"));
                   if (!reader.IsDBNull(reader.GetOrdinal("Chave_Acesso")))
                       reg.Chave_acesso = reader.GetString(reader.GetOrdinal("Chave_Acesso"));
                   if (!reader.IsDBNull(reader.GetOrdinal("tp_impos")))
                       reg.Tp_impos = reader.GetString(reader.GetOrdinal("tp_impos"));
                   if (!reader.IsDBNull(reader.GetOrdinal("tp_impetiqueta")))
                       reg.Tp_impetiqueta = reader.GetString(reader.GetOrdinal("tp_impetiqueta"));
                   if (!reader.IsDBNull(reader.GetOrdinal("layoutetiqueta")))
                       reg.Layoutetiqueta = reader.GetString(reader.GetOrdinal("layoutetiqueta"));
                    if (!reader.IsDBNull(reader.GetOrdinal("impressorapadrao")))
                        reg.ImpressoraPadrao = reader.GetString(reader.GetOrdinal("impressorapadrao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_layout")))
                        reg.Id_layout = reader.GetDecimal(reader.GetOrdinal("id_layout"));

                    lista.Add(reg);
               };
           }
            finally
           {
               reader.Close();
               reader.Dispose();
               if(podeFecharBco)
                   this.deletarBanco_Dados();
           }
           return lista;
           }

       public string Grava(TRegistro_CadTerminal vRegistro)
       {
           Hashtable hs = new Hashtable(17);
           hs.Add("@P_CD_TERMINAL", vRegistro.Cd_Terminal);
           hs.Add("@P_DS_TERMINAL", vRegistro.Ds_Terminal);
           hs.Add("@P_PORTA_IMPTICK", vRegistro.Porta_imptick);
           hs.Add("@P_MAPEARPORTATICK", vRegistro.Mapearportatick);
           hs.Add("@P_TP_IMPTICK", vRegistro.Tp_imptick);
           hs.Add("@P_ST_REGISTRO", vRegistro.St_Registro);
           hs.Add("@P_NR_SERIAL", vRegistro.Nr_serial);
           hs.Add("@P_CHAVE_ACESSO", vRegistro.Chave_acesso);
           hs.Add("@P_TP_IMPTICKAVULSO", vRegistro.Tp_imptickavulso);
           hs.Add("@P_TP_IMPPEDIDO", vRegistro.Tp_imppedido);
           hs.Add("@P_TP_IMPORCAMENTO", vRegistro.Tp_imporcamento);
           hs.Add("@P_TP_IMPRECIBO", vRegistro.Tp_imprecibo);
           hs.Add("@P_TP_IMPCHEQUE", vRegistro.Tp_impcheque);
           hs.Add("@P_TP_IMPOS", vRegistro.Tp_impos);
           hs.Add("@P_TP_IMPETIQUETA", vRegistro.Tp_impetiqueta);
           hs.Add("@P_LAYOUTETIQUETA", vRegistro.Layoutetiqueta);
            hs.Add("@P_IMPRESSORAPADRAO", vRegistro.ImpressoraPadrao);
            hs.Add("@P_ID_LAYOUT", vRegistro.Id_layout);

            return this.executarProc("IA_DIV_TERMINAL", hs);
       }
       
       public string Deleta(TRegistro_CadTerminal vRegistro)
       {
           Hashtable hs = new Hashtable(1);
           hs.Add("@P_CD_TERMINAL", vRegistro.Cd_Terminal);

           return this.executarProc("EXCLUI_DIV_TERMINAL", hs);
       }
       }
   }
    

