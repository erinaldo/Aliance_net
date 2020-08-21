using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace CamadaDados.Mudanca
{
    #region Itens Mudança
    public class TList_LanItensMud : List<TRegistro_LanItensMud>, IComparer<TRegistro_LanItensMud>
    {
        #region IComparer<TRegistro_LanItensMud> Members
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

        public TList_LanItensMud()
        { }

        public TList_LanItensMud(System.ComponentModel.PropertyDescriptor Prop,
                                System.Windows.Forms.SortOrder Dir)
        {
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_LanItensMud value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_LanItensMud x, TRegistro_LanItensMud y)
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

    public class TRegistro_LanItensMud
    {
        public string Cd_empresa
        { get; set; }
        private decimal? id_mudanca;
        public decimal? Id_mudanca
        {
            get { return id_mudanca; }
            set
            {
                id_mudanca = value;
                id_mudancastr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_mudancastr;
        public string Id_mudancastr
        {
            get { return id_mudancastr; }
            set
            {
                id_mudancastr = value;
                try
                {
                    id_mudanca = Convert.ToDecimal(value);
                }
                catch
                { id_mudanca = null; }
            }
        }
        private decimal? id_item;
        public decimal? Id_item
        {
            get { return id_item; }
            set
            {
                id_item = value;
                id_itemstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_itemstr;
        public string Id_itemstr
        {
            get { return id_itemstr; }
            set
            {
                id_itemstr = value;
                try
                {
                    id_item = decimal.Parse(value);
                }
                catch { id_item = null; }
            }
        }
        public string Ds_item
        { get; set; }
        private decimal? id_itempai;
        public decimal? Id_itempai
        {
            get { return id_itempai; }
            set
            {
                id_itempai = value;
                id_itempaistr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_itempaistr;
        public string Id_itempaistr
        {
            get { return id_itempaistr; }
            set
            {
                id_itempaistr = value;
                try
                {
                    id_itempai = decimal.Parse(value);
                }
                catch { id_itempai = null; }
            }
        }
        public string Ds_itempai
        { get; set; }
        public string Classificacao
        { get; set; }
        public string Cd_itemweb
        { get; set; }
        public string Ds_itemweb
        { get; set; }
        public decimal Quantidade
        { get; set; }
        public decimal MetragemCub
        { get; set; }
        public decimal Tot_metragemCub
        { get { return Math.Round(this.Quantidade * this.MetragemCub, 2); } }
        public decimal Vl_seguro
        { get; set; }
        public decimal Tot_seguro
        { get { return Quantidade * Vl_seguro; } }
        public TList_LanFotosItensMud lFotosItensMud
        { get; set; }
        public TList_LanFotosItensMud lFotosItensMudDel
        { get; set; }
        public bool St_sintetico
        { get; set; }
        public bool St_processar
        { get; set; }

        public TRegistro_LanItensMud()
        {
            this.Cd_empresa = string.Empty;
            this.id_mudanca = null;
            this.id_mudancastr = string.Empty;
            this.id_item = null;
            this.id_itemstr = string.Empty;
            this.Ds_item = string.Empty;
            this.Classificacao = string.Empty;
            this.id_itempai = null;
            this.id_itempaistr = string.Empty;
            this.Ds_itempai = string.Empty;
            this.Cd_itemweb = string.Empty;
            this.Ds_itemweb = string.Empty;
            this.Quantidade = decimal.Zero;
            this.MetragemCub = decimal.Zero;
            this.Vl_seguro = decimal.Zero;
            this.St_processar = false;
            this.St_sintetico = false;

            this.lFotosItensMud = new TList_LanFotosItensMud();
            this.lFotosItensMudDel = new TList_LanFotosItensMud();
        }
    }

    public class TCD_LanItensMud : TDataQuery
    {
        public TCD_LanItensMud()
        { }

        public TCD_LanItensMud(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("select " + strTop + " a.CD_Empresa, a.ID_Mudanca, b.classificacao, ");
                sql.AppendLine("a.ID_Item, b.ds_item, b.ID_ItemPai, b.cd_itemweb, a.Quantidade, b.metragemCub, a.Vl_Seguro, ");
                sql.AppendLine("ds_itempai = ISNULL((select top 1 x.DS_Item from tb_mud_itens x ");
				sql.AppendLine("	                 where SUBSTRING(b.classificacao, 0, 3) = x.Classificacao ");
				sql.AppendLine("	                 and x.ST_Sintetico = 'S'), ''), ");
                sql.AppendLine("DS_ItemWeb = isnull((select top 1 DS_ItemWeb from TB_MUD_Orcamento_X_Itens x ");
                sql.AppendLine("	                 where x.CD_ItemWeb = b.cd_itemweb ), '') ");

            }
            else
                sql.AppendLine(" Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from TB_MUD_ItensMud a ");
            sql.AppendLine("inner join TB_MUD_Itens b ");
            sql.AppendLine("on a.id_item = b.id_item ");

            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
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

        public TList_LanItensMud Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNm_Campo)
        {
            TList_LanItensMud lista = new TList_LanItensMud();
            System.Data.SqlClient.SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            try
            {
                reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNm_Campo));
                while (reader.Read())
                {
                    TRegistro_LanItensMud reg = new TRegistro_LanItensMud();
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("CD_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Mudanca")))
                        reg.Id_mudanca = reader.GetDecimal(reader.GetOrdinal("ID_Mudanca"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Item")))
                        reg.Id_item = reader.GetDecimal(reader.GetOrdinal("ID_Item"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Ds_item")))
                        reg.Ds_item = reader.GetString(reader.GetOrdinal("Ds_item"));
                    if (!reader.IsDBNull(reader.GetOrdinal("classificacao")))
                        reg.Classificacao = reader.GetString(reader.GetOrdinal("classificacao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Itempai")))
                        reg.Id_itempai = reader.GetDecimal(reader.GetOrdinal("ID_Itempai"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Ds_itempai")))
                        reg.Ds_itempai = reader.GetString(reader.GetOrdinal("Ds_itempai"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Quantidade")))
                        reg.Quantidade = reader.GetDecimal(reader.GetOrdinal("Quantidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("metragemCub")))
                        reg.MetragemCub = reader.GetDecimal(reader.GetOrdinal("metragemCub"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_Seguro")))
                        reg.Vl_seguro = reader.GetDecimal(reader.GetOrdinal("Vl_Seguro"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_itemweb")))
                        reg.Cd_itemweb = reader.GetString(reader.GetOrdinal("cd_itemweb"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_ItemWeb")))
                        reg.Ds_itemweb = reader.GetString(reader.GetOrdinal("DS_ItemWeb"));


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

        public string Gravar(TRegistro_LanItensMud val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(5);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_MUDANCA", val.Id_mudanca);
            hs.Add("@P_ID_ITEM", val.Id_item);
            hs.Add("@P_QUANTIDADE", val.Quantidade);
            hs.Add("@P_VL_SEGURO", val.Vl_seguro);

            return this.executarProc("IA_MUD_ITENSMUD", hs);
        }

        public string Excluir(TRegistro_LanItensMud val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(3);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_MUDANCA", val.Id_mudanca);
            hs.Add("@P_ID_ITEM", val.Id_item);

            return this.executarProc("EXCLUI_MUD_ITENSMUD", hs);
        }


    }


    #endregion

    #region Itens Foto Mudança
    public class TList_LanFotosItensMud : List<TRegistro_LanFotosItensMud>, IComparer<TRegistro_LanFotosItensMud>
    {
        #region IComparer<TRegistro_LanFotosItensMud> Members
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

        public TList_LanFotosItensMud()
        { }

        public TList_LanFotosItensMud(System.ComponentModel.PropertyDescriptor Prop,
                                System.Windows.Forms.SortOrder Dir)
        {
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_LanFotosItensMud value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_LanFotosItensMud x, TRegistro_LanFotosItensMud y)
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

    public class TRegistro_LanFotosItensMud
    {
        public string Cd_empresa
        { get; set; }
        private decimal? id_mudanca;
        public decimal? Id_mudanca
        {
            get { return id_mudanca; }
            set
            {
                id_mudanca = value;
                id_mudancastr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_mudancastr;
        public string Id_mudancastr
        {
            get { return id_mudancastr; }
            set
            {
                id_mudancastr = value;
                try
                {
                    id_mudanca = Convert.ToDecimal(value);
                }
                catch
                { id_mudanca = null; }
            }
        }
        private decimal? id_item;
        public decimal? Id_item
        {
            get { return id_item; }
            set
            {
                id_item = value;
                id_itemstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_itemstr;
        public string Id_itemstr
        {
            get { return id_itemstr; }
            set
            {
                id_itemstr = value;
                try
                {
                    id_item = Convert.ToDecimal(value);
                }
                catch
                { id_item = null; }
            }
        }
        private decimal? id_foto;
        public decimal? Id_foto
        {
            get { return id_foto; }
            set
            {
                id_foto = value;
                id_fotostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_fotostr;
        public string Id_fotostr
        {
            get { return id_fotostr; }
            set
            {
                id_fotostr = value;
                try
                {
                    id_foto = Convert.ToDecimal(value);
                }
                catch
                { id_foto = null; }
            }
        }
        public string Ds_foto
        { get; set; }
        private Image foto;
        public Image Foto
        {
            get { return foto; }
            set
            {
                foto = value;
                if (foto != null)
                {
                    using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
                    {
                        foto.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                        img = ms.ToArray();
                        ms.Close();
                        ms.Dispose();
                    }
                }
            }
        }
        private byte[] img;
        public byte[] Img
        {
            get{ return img; }
            set
            {
                img = value;
                if (value != null)
                {
                    using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
                    {
                        ms.Write(value, 0, value.Length);
                        foto = Image.FromStream(ms);
                        ms.Close();
                        ms.Dispose();
                    }
                }
            }
        }

        public TRegistro_LanFotosItensMud()
        {
            this.Cd_empresa = string.Empty;
            this.id_mudanca = null;
            this.id_mudancastr = string.Empty;
            this.id_item = null;
            this.id_itemstr = string.Empty;
            this.id_foto = null;
            this.id_fotostr = string.Empty;
            this.Ds_foto = string.Empty;
            this.foto = null;
            this.img = null;
        }
    }

    public class TCD_LanFotosItensMud : TDataQuery
    {
        public TCD_LanFotosItensMud()
        { }

        public TCD_LanFotosItensMud(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("select " + strTop + " a.CD_Empresa, a.ID_Mudanca, ");
                sql.AppendLine("a.ID_Item, a.id_foto, a.ds_foto, a.foto ");

            }
            else
                sql.AppendLine(" Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from TB_MUD_FotosItensMud a ");

            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
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

        public TList_LanFotosItensMud Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNm_Campo)
        {
            TList_LanFotosItensMud lista = new TList_LanFotosItensMud();
            System.Data.SqlClient.SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            try
            {
                reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNm_Campo));
                while (reader.Read())
                {
                    TRegistro_LanFotosItensMud reg = new TRegistro_LanFotosItensMud();
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("CD_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Mudanca")))
                        reg.Id_mudanca = reader.GetDecimal(reader.GetOrdinal("ID_Mudanca"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Item")))
                        reg.Id_item = reader.GetDecimal(reader.GetOrdinal("ID_Item"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_foto")))
                        reg.Id_foto = reader.GetDecimal(reader.GetOrdinal("id_foto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Ds_foto")))
                        reg.Ds_foto = reader.GetString(reader.GetOrdinal("Ds_foto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("foto")))
                        reg.Img = (byte[])reader.GetValue(reader.GetOrdinal("foto"));


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

        public string Gravar(TRegistro_LanFotosItensMud val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(6);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_MUDANCA", val.Id_mudanca);
            hs.Add("@P_ID_ITEM", val.Id_item);
            hs.Add("@P_ID_FOTO", val.Id_foto);
            hs.Add("@P_DS_FOTO", val.Ds_foto);
            hs.Add("@P_FOTO", val.Img);

            return this.executarProc("IA_MUD_FOTOSITENSMUD", hs);
        }

        public string Excluir(TRegistro_LanFotosItensMud val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(4);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_MUDANCA", val.Id_mudanca);
            hs.Add("@P_ID_ITEM", val.Id_item);
            hs.Add("@P_ID_FOTO", val.Id_foto);

            return this.executarProc("EXCLUI_MUD_FOTOSITENSMUD", hs);
        }


    }


    #endregion
}
