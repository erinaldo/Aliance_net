using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamadaDados.Mudanca.Cadastros
{
    #region CFG Mudanca
    public class TList_CFGMudanca : List<TRegistro_CFGMudanca>, IComparer<TRegistro_CFGMudanca>
    {
        #region IComparer<TRegistro_CFGMudanca> Members
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

        public TList_CFGMudanca()
        { }

        public TList_CFGMudanca(System.ComponentModel.PropertyDescriptor Prop,
                              System.Windows.Forms.SortOrder Dir)
        {
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_CFGMudanca value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_CFGMudanca x, TRegistro_CFGMudanca
 y)
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


    public class TRegistro_CFGMudanca
    {

        public string Cd_empresa
        { get; set; }

        public string Nm_empresa
        { get; set; }

        public string Tp_duplicata
        { get; set; }

        public string Ds_tpduplicata
        { get; set; }

        public string Tp_movDup
        { get; set; }

        private decimal? tp_docto;

        public decimal? Tp_docto
        {
            get { return tp_docto; }
            set
            {
                tp_docto = value;
                tp_doctostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string tp_doctostr;

        public string Tp_doctostr
        {
            get { return tp_doctostr; }
            set
            {
                tp_doctostr = value;
                try
                {
                    tp_docto = decimal.Parse(value);
                }
                catch
                { tp_docto = null; }
            }
        }

        public string Ds_tpdocto
        { get; set; }
        public string CFG_PedServico
        { get; set; }
        public string DS_TipoPedido
        { get; set; }
        public string CD_ServPadrao
        { get; set; }
        public string DS_ServPadrao
        { get; set; }
        public byte[] ContratoMunicipal
        { get; set; }
        public byte[] ContratoInterMunicipal
        { get; set; }

        public TRegistro_CFGMudanca()
        {
            this.Cd_empresa = string.Empty;
            this.Nm_empresa = string.Empty;
            this.Tp_duplicata = string.Empty;
            this.Ds_tpduplicata = string.Empty;
            this.Tp_movDup = string.Empty;
            this.tp_docto = null;
            this.tp_doctostr = string.Empty;
            this.Ds_tpdocto = string.Empty;
            this.CFG_PedServico = string.Empty;
            this.DS_TipoPedido = string.Empty;
            this.CD_ServPadrao = string.Empty;
            this.DS_ServPadrao = string.Empty;
            this.ContratoMunicipal = null;
            this.ContratoInterMunicipal = null;
        }
    }

    public class TCD_CFGMudanca : TDataQuery
    {
        public TCD_CFGMudanca()
        { }

        public TCD_CFGMudanca(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNm_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = " TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNm_Campo))
            {
                sql.AppendLine("Select " + strTop + " a.cd_empresa, emp.nm_empresa, ");
                sql.AppendLine("a.TP_Duplicata, b.Ds_tpduplicata, b.TP_MOV, a.Tp_Docto, c.Ds_tpdocto, a.ContratoMunicipal, a.ContratoInterMunicipal, ");
                sql.AppendLine("a.CFG_PedServico, d.ds_tipopedido, a.CD_ServPadrao, e.ds_produto as ds_servpadrao ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNm_Campo + " ");
            sql.AppendLine("from TB_MUD_CfgMudanca a ");
            sql.AppendLine("inner join tb_div_empresa emp ");
            sql.AppendLine("on a.cd_empresa = emp.cd_empresa ");
            sql.AppendLine("left outer join TB_FIN_TPDuplicata b ");
            sql.AppendLine("on a.TP_Duplicata = b.TP_Duplicata ");
            sql.AppendLine("left outer join TB_FIN_TPDocto_Dup c ");
            sql.AppendLine("on a.Tp_Docto = c.Tp_Docto ");
            sql.AppendLine("left outer join TB_FAT_CFGPedido d ");
            sql.AppendLine("on d.CFG_Pedido = a.CFG_PedServico ");
            sql.AppendLine("left outer join TB_EST_Produto e ");
            sql.AppendLine("on e.CD_Produto = a.CD_ServPadrao ");


            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + ")");
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

        public TList_CFGMudanca Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNm_Campo)
        {
            TList_CFGMudanca lista = new TList_CFGMudanca();
            System.Data.SqlClient.SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            try
            {
                reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNm_Campo));
                while (reader.Read())
                {
                    TRegistro_CFGMudanca reg = new TRegistro_CFGMudanca();

                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_empresa")))
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("nm_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("TP_Duplicata")))
                        reg.Tp_duplicata = reader.GetString(reader.GetOrdinal("TP_Duplicata"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Ds_tpduplicata")))
                        reg.Ds_tpduplicata = reader.GetString(reader.GetOrdinal("Ds_tpduplicata"));
                    if (!reader.IsDBNull(reader.GetOrdinal("TP_MOV")))
                        reg.Tp_movDup = reader.GetString(reader.GetOrdinal("TP_MOV"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Tp_Docto")))
                        reg.Tp_docto = reader.GetDecimal(reader.GetOrdinal("Tp_Docto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Ds_tpdocto")))
                        reg.Ds_tpdocto = reader.GetString(reader.GetOrdinal("Ds_tpdocto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CFG_PedServico")))
                        reg.CFG_PedServico = reader.GetString(reader.GetOrdinal("CFG_PedServico"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_tipopedido")))
                        reg.DS_TipoPedido = reader.GetString(reader.GetOrdinal("ds_tipopedido"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_ServPadrao")))
                        reg.CD_ServPadrao = reader.GetString(reader.GetOrdinal("CD_ServPadrao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_servpadrao")))
                        reg.DS_ServPadrao = reader.GetString(reader.GetOrdinal("ds_servpadrao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ContratoMunicipal")))
                        reg.ContratoMunicipal = (byte[])reader.GetValue(reader.GetOrdinal("ContratoMunicipal"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ContratoInterMunicipal")))
                        reg.ContratoInterMunicipal = (byte[])reader.GetValue(reader.GetOrdinal("ContratoInterMunicipal"));

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

        public string Gravar(TRegistro_CFGMudanca val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(7);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_TP_DUPLICATA", val.Tp_duplicata);
            hs.Add("@P_TP_DOCTO", val.Tp_docto);
            hs.Add("@P_CFG_PEDSERVICO", val.CFG_PedServico);
            hs.Add("@P_CD_SERVPADRAO", val.CD_ServPadrao);
            hs.Add("@P_CONTRATOMUNICIPAL", val.ContratoMunicipal);
            hs.Add("@P_CONTRATOINTERMUNICIPAL", val.ContratoInterMunicipal);

            return this.executarProc("IA_MUD_CFGMUDANCA", hs);
        }

        public string Excluir(TRegistro_CFGMudanca val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(1);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);

            return this.executarProc("EXCLUI_MUD_CFGMUDANCA", hs);
        }



    }

    #endregion
}
