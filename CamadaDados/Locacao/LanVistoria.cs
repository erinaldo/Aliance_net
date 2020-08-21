using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Drawing;
using System.Data.SqlClient;
using Utils;
using System.Data;

namespace CamadaDados.Locacao
{
    #region Vistoria
    public class TList_Vistoria : List<TRegistro_Vistoria>, IComparer<TRegistro_Vistoria>
    {

        #region IComparer<TRegistro_Vistoria> Members
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

        public TList_Vistoria()
        { }

        public TList_Vistoria(System.ComponentModel.PropertyDescriptor Prop,
                                   System.Windows.Forms.SortOrder Dir)
        {
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_Vistoria value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_Vistoria x, TRegistro_Vistoria y)
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


    public class TRegistro_Vistoria
    {

        public string Cd_empresa
        { get; set; }
        private decimal? id_locacao;

        public decimal? Id_locacao
        {
            get { return id_locacao; }
            set
            {
                id_locacao = value;
                id_locacaostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_locacaostr;

        public string Id_locacaostr
        {
            get { return id_locacaostr; }
            set
            {
                id_locacaostr = value;
                try
                {
                    id_locacao = Convert.ToDecimal(value);
                }
                catch
                { id_locacao = null; }
            }
        }
        private decimal? id_itemloc;

        public decimal? Id_itemloc
        {
            get { return id_itemloc; }
            set
            {
                id_itemloc = value;
                id_itemlocstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_itemlocstr;

        public string Id_itemlocstr
        {
            get { return id_itemlocstr; }
            set
            {
                id_itemlocstr = value;
                try
                {
                    id_itemloc = Convert.ToDecimal(value);
                }
                catch
                { id_itemloc = null; }
            }
        }
        public string Login
        { get; set; }
        private decimal? id_vistoria;

        public decimal? Id_vistoria
        {
            get { return id_vistoria; }
            set
            {
                id_vistoria = value;
                id_vistoriastr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_vistoriastr;

        public string Id_vistoriastr
        {
            get { return id_vistoriastr; }
            set
            {
                id_vistoriastr = value;
                try
                {
                    id_vistoria = decimal.Parse(value);
                }
                catch
                { id_vistoria = null; }
            }
        }
        private decimal? id_os;
        public decimal? Id_os
        {
            get { return id_os; }
            set
            {
                id_os = value;
                id_osstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_osstr;
        public string Id_osstr
        {
            get { return id_osstr; }
            set
            {
                id_osstr = value;
                try
                {
                    id_os = decimal.Parse(value);
                }
                catch
                { id_os = null; }
            }
        }
        private string tp_mov;
        public string Tp_mov
        {
            get { return tp_mov; }
            set
            {
                tp_mov = value;
                if (value.ToUpper().Trim().Equals("E"))
                    tipo_mov = "ENTRADA";
                else if (value.ToUpper().Trim().Equals("S"))
                    tipo_mov = "SAIDA";
            }
        }
        private string tipo_mov;
        public string Tipo_mov
        {
            get { return tipo_mov; }
            set
            {
                tipo_mov = value;
                if (value.ToUpper().Trim().Equals("ENTRADA"))
                    tp_mov = "E";
                else if (value.ToUpper().Trim().Equals("SAIDA"))
                    tp_mov = "S";
            }
        }
        private DateTime? dt_vistoria;

        public DateTime? Dt_vistoria
        {
            get { return dt_vistoria; }
            set
            {
                dt_vistoria = value;
                dt_vistoriastr = value.HasValue ? value.Value.ToString("dd/MM/yyyy HH:mm:ss") : string.Empty;
            }
        }
        private string dt_vistoriastr;
        public string Dt_vistoriastr
        {
            get
            {
                try
                {
                    return Convert.ToDateTime(dt_vistoriastr).ToString("dd/MM/yyyy HH:mm:ss");
                }
                catch
                { return string.Empty; }
            }
            set
            {
                dt_vistoriastr = value;
                try
                {
                    dt_vistoria = Convert.ToDateTime(value);
                }
                catch
                { dt_vistoria = null; }
            }
        }
        public string Ds_obs
        { get; set; }
        public string St_registro
        { get; set; }
        public string Status
        {
            get
            {
                if (St_registro.Trim().ToUpper().Equals("M"))
                    return "MANUTENÇÃO";
                else if (St_registro.Trim().ToUpper().Equals("F"))
                    return "FECHADO";
                else return "COLETA";
            }
        }
        public string Id_coleta
        { get; set; }
        public TList_ImagensVistoria lImagens
        { get; set; }
        public TList_ImagensVistoria lImagensDel
        { get; set; }

        public TRegistro_Vistoria()
        {
            this.Cd_empresa = string.Empty;
            this.id_locacao = null;
            this.id_locacaostr = string.Empty;
            this.id_itemloc = null;
            this.id_itemlocstr = string.Empty;
            this.Login = string.Empty;
            this.id_vistoria = null;
            this.id_vistoriastr = string.Empty;
            this.id_os = null;
            this.id_osstr = string.Empty;
            this.tp_mov = string.Empty;
            this.tipo_mov = string.Empty;
            this.dt_vistoria = null;
            this.dt_vistoriastr = string.Empty;
            this.Ds_obs = string.Empty;
            this.St_registro = string.Empty;
            this.Id_coleta = string.Empty;

            this.lImagens = new TList_ImagensVistoria();
            this.lImagensDel = new TList_ImagensVistoria();
        }
    }

    public class TCD_Vistoria : TDataQuery
    {
        public TCD_Vistoria()
        { }

        public TCD_Vistoria(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNm_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = " TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNm_Campo))
            {
                sql.AppendLine("Select " + strTop + " a.CD_Empresa, a.ID_Locacao, a.ID_ItemLoc, a.Login, ");
                sql.AppendLine("a.ID_Vistoria, a.ID_OS, a.TP_Mov, a.DT_Vistoria, a.DS_Obs, a.ST_Registro ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNm_Campo + " ");
            sql.AppendLine("from TB_LOC_Vistoria a ");


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

        public TList_Vistoria Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNm_Campo)
        {
            TList_Vistoria lista = new TList_Vistoria();
            System.Data.SqlClient.SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            try
            {
                reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNm_Campo));
                while (reader.Read())
                {
                    TRegistro_Vistoria reg = new TRegistro_Vistoria();

                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_locacao")))
                        reg.Id_locacao = reader.GetDecimal(reader.GetOrdinal("id_locacao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_itemloc")))
                        reg.Id_itemloc = reader.GetDecimal(reader.GetOrdinal("id_itemloc"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Login")))
                        reg.Login = reader.GetString(reader.GetOrdinal("Login"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Vistoria")))
                        reg.Id_vistoria = reader.GetDecimal(reader.GetOrdinal("ID_Vistoria"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_OS")))
                        reg.Id_os = reader.GetDecimal(reader.GetOrdinal("ID_OS"));
                    if (!reader.IsDBNull(reader.GetOrdinal("TP_Mov")))
                        reg.Tp_mov = reader.GetString(reader.GetOrdinal("TP_Mov"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DT_Vistoria")))
                        reg.Dt_vistoria = reader.GetDateTime(reader.GetOrdinal("DT_Vistoria"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Obs")))
                        reg.Ds_obs = reader.GetString(reader.GetOrdinal("DS_Obs"));
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

        public string Gravar(TRegistro_Vistoria val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(10);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_LOCACAO", val.Id_locacao);
            hs.Add("@P_ID_ITEMLOC", val.Id_itemloc);
            hs.Add("@P_ID_VISTORIA", val.Id_vistoria);
            hs.Add("@P_LOGIN", val.Login);
            hs.Add("@P_ID_OS", val.Id_os);
            hs.Add("@P_TP_MOV", val.Tp_mov);
            hs.Add("@P_DT_VISTORIA", val.Dt_vistoria);
            hs.Add("@P_DS_OBS", val.Ds_obs);
            hs.Add("@P_ST_REGISTRO", val.St_registro);

            return this.executarProc("IA_LOC_VISTORIA", hs);
        }

        public string Excluir(TRegistro_Vistoria val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(4);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_LOCACAO", val.Id_locacao);
            hs.Add("@P_ID_ITEMLOC", val.Id_itemloc);
            hs.Add("@P_ID_VISTORIA", val.Id_vistoria);

            return this.executarProc("EXCLUI_LOC_VISTORIA", hs);
        }

    }
    #endregion

    #region Imagens Vistoria
    public class TList_ImagensVistoria : List<TRegistro_ImagensVistoria>, IComparer<TRegistro_ImagensVistoria>
    {
        #region IComparer<TRegistro_ImagensVistoria> Members
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

        public TList_ImagensVistoria()
        { }

        public TList_ImagensVistoria(System.ComponentModel.PropertyDescriptor Prop,
                                        System.Windows.Forms.SortOrder Dir)
        {
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_ImagensVistoria value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_ImagensVistoria x, TRegistro_ImagensVistoria y)
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

    public class TRegistro_ImagensVistoria
    {
        public string Cd_empresa
        { get; set; }
        private decimal? id_locacao;

        public decimal? Id_locacao
        {
            get { return id_locacao; }
            set
            {
                id_locacao = value;
                id_locacaostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_locacaostr;

        public string Id_locacaostr
        {
            get { return id_locacaostr; }
            set
            {
                id_locacaostr = value;
                try
                {
                    id_locacao = Convert.ToDecimal(value);
                }
                catch
                { id_locacao = null; }
            }
        }
        private decimal? id_itemloc;

        public decimal? Id_itemloc
        {
            get { return id_itemloc; }
            set
            {
                id_itemloc = value;
                id_itemlocstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_itemlocstr;

        public string Id_itemlocstr
        {
            get { return id_itemlocstr; }
            set
            {
                id_itemlocstr = value;
                try
                {
                    id_itemloc = Convert.ToDecimal(value);
                }
                catch
                { id_itemloc = null; }
            }
        }

        private decimal? id_vistoria;

        public decimal? Id_vistoria
        {
            get { return id_vistoria; }
            set
            {
                id_vistoria = value;
                id_vistoriastr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_vistoriastr;

        public string Id_vistoriastr
        {
            get { return id_vistoriastr; }
            set
            {
                id_vistoriastr = value;
                try
                {
                    id_vistoria = decimal.Parse(value);
                }
                catch
                { id_vistoria = null; }
            }
        }
        private decimal? id_imagem;

        public decimal? Id_imagem
        {
            get { return id_imagem; }
            set
            {
                id_imagem = value;
                id_imagemstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_imagemstr;

        public string Id_imagemstr
        {
            get { return id_imagemstr; }
            set
            {
                id_imagemstr = value;
                try
                {
                    id_imagem = Convert.ToDecimal(value);
                }
                catch
                { id_imagem = null; }
            }
        }
        private Image imagem;
        public Image Imagem
        {
            get { return imagem; }
            set
            {
                imagem = value;
                if (imagem != null)
                {
                    using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
                    {
                        imagem.Save(ms, imagem.RawFormat);
                        img = ms.ToArray();
                    }
                }
            }
        }
        private byte[] img;
        public byte[] Img
        {
            get { return img; }
            set
            {
                img = value;
                if (value != null)
                    imagem = (Image)new ImageConverter().ConvertFrom(value);
            }
        }
        public string Ds_obs
        { get; set; }

        public TRegistro_ImagensVistoria()
        {
            this.Cd_empresa = string.Empty;
            this.id_locacao = null;
            this.id_locacaostr = string.Empty;
            this.id_itemloc = null;
            this.id_itemlocstr = string.Empty;
            this.id_vistoria = null;
            this.id_vistoriastr = string.Empty;
            this.id_imagem = null;
            this.id_imagemstr = string.Empty;
            this.imagem = null;
            this.img = null;
            this.Ds_obs = string.Empty;
        }
    }

    public class TCD_ImagensVistoria : TDataQuery
    {
        public TCD_ImagensVistoria()
        { }

        public TCD_ImagensVistoria(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();

            if (vNM_Campo.Length == 0)
            {
                sql.AppendLine(" SELECT " + strTop + " a.CD_Empresa, a.ID_Locacao, a.ID_ItemLoc, a.ID_Vistoria, ");
                sql.AppendLine("a.ID_Imagem, a.Imagem, a.Obs ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine(" FROM TB_LOC_ImagensVistoria a ");

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

        public override DataTable Buscar(TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo), null);
        }

        public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
        {
            return this.ExecutarBuscaEscalar(this.SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }

        public TList_ImagensVistoria Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_ImagensVistoria lista = new TList_ImagensVistoria();
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            SqlDataReader reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_ImagensVistoria reg = new TRegistro_ImagensVistoria();

                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_locacao")))
                        reg.Id_locacao = reader.GetDecimal(reader.GetOrdinal("id_locacao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_itemloc")))
                        reg.Id_itemloc = reader.GetDecimal(reader.GetOrdinal("id_itemloc"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Vistoria")))
                        reg.Id_vistoria = reader.GetDecimal(reader.GetOrdinal("ID_Vistoria"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Imagem")))
                        reg.Id_imagem = reader.GetDecimal(reader.GetOrdinal("ID_Imagem"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Imagem")))
                        reg.Img = (byte[])reader.GetValue(reader.GetOrdinal("Imagem"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Obs")))
                        reg.Ds_obs = reader.GetString(reader.GetOrdinal("Obs"));

                    lista.Add(reg);
                }
            }
            finally
            {
                if (podeFecharBco)
                    this.deletarBanco_Dados();
            }
            return lista;
        }

        public string Grava(TRegistro_ImagensVistoria val)
        {
            Hashtable hs = new Hashtable(7);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_LOCACAO", val.Id_locacao);
            hs.Add("@P_ID_ITEMLOC", val.Id_itemloc);
            hs.Add("@P_ID_VISTORIA", val.Id_vistoria);
            hs.Add("@P_ID_IMAGEM", val.Id_imagem);
            hs.Add("@P_IMAGEM", val.Img);
            hs.Add("@P_OBS", val.Ds_obs);

            return this.executarProc("IA_LOC_IMAGENSVISTORIA", hs);
        }

        public string Deleta(TRegistro_ImagensVistoria val)
        {
            Hashtable hs = new Hashtable(5);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_LOCACAO", val.Id_locacao);
            hs.Add("@P_ID_ITEMLOC", val.Id_itemloc);
            hs.Add("@P_ID_VISTORIA", val.Id_vistoria);
            hs.Add("@P_ID_IMAGEM", val.Id_imagem);

            return this.executarProc("EXCLUI_LOC_IMAGENSVISTORIA", hs);
        }
    }
    #endregion

    #region Vistoria_X_ColEnt
    public class TList_Vistoria_X_ColEnt : List<TRegistro_Vistoria_X_ColEnt>, IComparer<TRegistro_Vistoria_X_ColEnt>
    {

        #region IComparer<TRegistro_Vistoria_X_ColEnt> Members
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

        public TList_Vistoria_X_ColEnt()
        { }

        public TList_Vistoria_X_ColEnt(System.ComponentModel.PropertyDescriptor Prop,
                                   System.Windows.Forms.SortOrder Dir)
        {
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_Vistoria_X_ColEnt value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_Vistoria_X_ColEnt x, TRegistro_Vistoria_X_ColEnt y)
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


    public class TRegistro_Vistoria_X_ColEnt
    {

        public string Cd_empresa
        { get; set; }
        private decimal? id_locacao;

        public decimal? Id_locacao
        {
            get { return id_locacao; }
            set
            {
                id_locacao = value;
                id_locacaostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_locacaostr;

        public string Id_locacaostr
        {
            get { return id_locacaostr; }
            set
            {
                id_locacaostr = value;
                try
                {
                    id_locacao = Convert.ToDecimal(value);
                }
                catch
                { id_locacao = null; }
            }
        }
        private decimal? id_itemloc;

        public decimal? Id_itemloc
        {
            get { return id_itemloc; }
            set
            {
                id_itemloc = value;
                id_itemlocstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_itemlocstr;

        public string Id_itemlocstr
        {
            get { return id_itemlocstr; }
            set
            {
                id_itemlocstr = value;
                try
                {
                    id_itemloc = Convert.ToDecimal(value);
                }
                catch
                { id_itemloc = null; }
            }
        }

        private decimal? id_vistoria;

        public decimal? Id_vistoria
        {
            get { return id_vistoria; }
            set
            {
                id_vistoria = value;
                id_vistoriastr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_vistoriastr;

        public string Id_vistoriastr
        {
            get { return id_vistoriastr; }
            set
            {
                id_vistoriastr = value;
                try
                {
                    id_vistoria = decimal.Parse(value);
                }
                catch
                { id_vistoria = null; }
            }
        }

        private decimal? id_coleta;

        public decimal? Id_coleta
        {
            get { return id_coleta; }
            set
            {
                id_coleta = value;
                id_coletastr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_coletastr;

        public string Id_coletastr
        {
            get { return id_coletastr; }
            set
            {
                id_coletastr = value;
                try
                {
                    id_coleta = Convert.ToDecimal(value);
                }
                catch
                { id_coleta = null; }
            }
        }

        public TRegistro_Vistoria_X_ColEnt()
        {
            this.Cd_empresa = string.Empty;
            this.id_locacao = null;
            this.id_locacaostr = string.Empty;
            this.id_itemloc = null;
            this.id_itemlocstr = string.Empty;
            this.id_vistoria = null;
            this.id_vistoriastr = string.Empty;
            this.id_coleta = null;
            this.id_coletastr = string.Empty;
        }
    }

    public class TCD_Vistoria_X_ColEnt : TDataQuery
    {
        public TCD_Vistoria_X_ColEnt()
        { }

        public TCD_Vistoria_X_ColEnt(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNm_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = " TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNm_Campo))
                sql.AppendLine("Select " + strTop + " a.CD_Empresa, a.ID_Locacao, a.ID_ItemLoc, a.ID_Vistoria, a.ID_Coleta ");
            else
                sql.AppendLine("Select " + strTop + " " + vNm_Campo + " ");
            sql.AppendLine("from TB_LOC_Vistoria_X_ColEnt a ");


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

        public TList_Vistoria_X_ColEnt Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNm_Campo)
        {
            TList_Vistoria_X_ColEnt lista = new TList_Vistoria_X_ColEnt();
            System.Data.SqlClient.SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            try
            {
                reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNm_Campo));
                while (reader.Read())
                {
                    TRegistro_Vistoria_X_ColEnt reg = new TRegistro_Vistoria_X_ColEnt();

                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_locacao")))
                        reg.Id_locacao = reader.GetDecimal(reader.GetOrdinal("id_locacao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_itemloc")))
                        reg.Id_itemloc = reader.GetDecimal(reader.GetOrdinal("id_itemloc"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Vistoria")))
                        reg.Id_vistoria = reader.GetDecimal(reader.GetOrdinal("ID_Vistoria"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Coleta")))
                        reg.Id_coleta = reader.GetDecimal(reader.GetOrdinal("ID_Coleta"));
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

        public string Gravar(TRegistro_Vistoria_X_ColEnt val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(5);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_COLETA", val.Id_coleta);
            hs.Add("@P_ID_LOCACAO", val.Id_locacao);
            hs.Add("@P_ID_ITEMLOC", val.Id_itemloc);
            hs.Add("@P_ID_VISTORIA", val.Id_vistoria);

            return this.executarProc("IA_LOC_VISTORIA_X_COLENT", hs);
        }

        public string Excluir(TRegistro_Vistoria_X_ColEnt val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(5);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_COLETA", val.Id_coleta);
            hs.Add("@P_ID_LOCACAO", val.Id_locacao);
            hs.Add("@P_ID_ITEMLOC", val.Id_itemloc);
            hs.Add("@P_ID_VISTORIA", val.Id_vistoria);

            return this.executarProc("EXCLUI_LOC_VISTORIA_X_COLENT", hs);
        }

    }
    #endregion

    #region Coleta Entrega
    public class TList_ColetaEntrega : List<TRegistro_ColetaEntrega>, IComparer<TRegistro_ColetaEntrega>
    {

        #region IComparer<TRegistro_ColetaEntrega> Members
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

        public TList_ColetaEntrega()
        { }

        public TList_ColetaEntrega(System.ComponentModel.PropertyDescriptor Prop,
                                   System.Windows.Forms.SortOrder Dir)
        {
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_ColetaEntrega value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_ColetaEntrega x, TRegistro_ColetaEntrega y)
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


    public class TRegistro_ColetaEntrega
    {

        public string Cd_empresa
        { get; set; }
        public string Nm_empresa
        { get; set; }
        private decimal? id_coleta;

        public decimal? Id_coleta
        {
            get { return id_coleta; }
            set
            {
                id_coleta = value;
                id_coletastr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_coletastr;

        public string Id_coletastr
        {
            get { return id_coletastr; }
            set
            {
                id_coletastr = value;
                try
                {
                    id_coleta = Convert.ToDecimal(value);
                }
                catch
                { id_coleta = null; }
            }
        }
        private decimal? id_veiculo;

        public decimal? Id_veiculo
        {
            get { return id_veiculo; }
            set
            {
                id_veiculo = value;
                id_veiculostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_veiculostr;

        public string Id_veiculostr
        {
            get { return id_veiculostr; }
            set
            {
                id_veiculostr = value;
                try
                {
                    id_veiculo = Convert.ToDecimal(value);
                }
                catch
                { id_veiculo = null; }
            }
        }
        public string Ds_veiculo
        { get; set; }
        public string Placa
        { get; set; }
        public string Cd_motorista
        { get; set; }
        public string Nm_motorista
        { get; set; }

        private string tp_mov;
        public string Tp_mov
        {
            get { return tp_mov; }
            set
            {
                tp_mov = value;
                if (value.ToUpper().Trim().Equals("C"))
                    tipo_mov = "COLETA";
                else if (value.ToUpper().Trim().Equals("E"))
                    tipo_mov = "ENTREGA";
            }
        }
        private string tipo_mov;
        public string Tipo_mov
        {
            get { return tipo_mov; }
            set
            {
                tipo_mov = value;
                if (value.ToUpper().Trim().Equals("COLETA"))
                    tp_mov = "C";
                else if (value.ToUpper().Trim().Equals("ENTREGA"))
                    tp_mov = "E";
            }
        }
        private DateTime? dt_colent;

        public DateTime? Dt_colent
        {
            get { return dt_colent; }
            set
            {
                dt_colent = value;
                dt_colentstr = value.HasValue ? value.Value.ToString("dd/MM/yyyy HH:mm:ss") : string.Empty;
            }
        }
        private string dt_colentstr;
        public string Dt_colentstr
        {
            get
            {
                try
                {
                    return Convert.ToDateTime(dt_colentstr).ToString("dd/MM/yyyy HH:mm:ss");
                }
                catch
                { return string.Empty; }
            }
            set
            {
                dt_colentstr = value;
                try
                {
                    dt_colent = Convert.ToDateTime(value);
                }
                catch
                { dt_colent = null; }
            }
        }
        private DateTime? dt_retorno;

        public DateTime? Dt_retorno
        {
            get { return dt_retorno; }
            set
            {
                dt_retorno = value;
                dt_retornostr = value.HasValue ? value.Value.ToString("dd/MM/yyyy HH:mm:ss") : string.Empty;
            }
        }
        private string dt_retornostr;
        public string Dt_retornostr
        {
            get
            {
                try
                {
                    return Convert.ToDateTime(dt_retornostr).ToString("dd/MM/yyyy HH:mm:ss");
                }
                catch
                { return string.Empty; }
            }
            set
            {
                dt_retornostr = value;
                try
                {
                    dt_retorno = Convert.ToDateTime(value);
                }
                catch
                { dt_retorno = null; }
            }
        }
        public decimal Vl_frete
        { get; set; }
        public string Ds_obs
        { get; set; }
        public TList_Vistoria lVistoria
        { get; set; }

        public TRegistro_ColetaEntrega()
        {
            this.Cd_empresa = string.Empty;
            this.Nm_empresa = string.Empty;
            this.id_coleta = null;
            this.id_coletastr = string.Empty;
            this.id_veiculo = null;
            this.id_veiculostr = string.Empty;
            this.Ds_veiculo = string.Empty;
            this.Cd_motorista = string.Empty;
            this.Nm_motorista = string.Empty;
            this.tp_mov = string.Empty;
            this.tipo_mov = string.Empty;
            this.Vl_frete = decimal.Zero;
            this.dt_colent = null;
            this.dt_colentstr = string.Empty;
            this.dt_retorno = null;
            this.dt_retornostr = string.Empty;
            this.Ds_obs = string.Empty;
            this.lVistoria = new TList_Vistoria();
        }
    }

    public class TCD_ColetaEntrega : TDataQuery
    {
        public TCD_ColetaEntrega()
        { }

        public TCD_ColetaEntrega(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNm_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = " TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNm_Campo))
            {
                sql.AppendLine("Select " + strTop + " a.CD_Empresa, emp.Nm_empresa, a.ID_Coleta, a.Id_Veiculo, b.ds_veiculo, b.Placa, ");
                sql.AppendLine("a.CD_Motorista, c.nm_clifor as nm_motorista, a.tp_mov, a.dt_colent, a.dt_retorno, a.vl_frete, a.obs ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNm_Campo + " ");
            sql.AppendLine("from TB_LOC_ColetaEntrega a ");
            sql.AppendLine("inner join TB_DIV_Empresa emp ");
            sql.AppendLine("on emp.cd_empresa = a.cd_empresa ");
            sql.AppendLine("left outer join TB_FRT_Veiculo b ");
            sql.AppendLine("on b.id_veiculo = a.id_veiculo ");
            sql.AppendLine("left outer join TB_FIN_Clifor c ");
            sql.AppendLine("on c.cd_clifor = a.cd_motorista ");


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

        public TList_ColetaEntrega Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNm_Campo)
        {
            TList_ColetaEntrega lista = new TList_ColetaEntrega();
            System.Data.SqlClient.SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            try
            {
                reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNm_Campo));
                while (reader.Read())
                {
                    TRegistro_ColetaEntrega reg = new TRegistro_ColetaEntrega();

                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Nm_empresa")))
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("Nm_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Coleta")))
                        reg.Id_coleta = reader.GetDecimal(reader.GetOrdinal("ID_Coleta"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Id_Veiculo")))
                        reg.Id_veiculo = reader.GetDecimal(reader.GetOrdinal("Id_Veiculo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_veiculo")))
                        reg.Ds_veiculo = reader.GetString(reader.GetOrdinal("ds_veiculo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Placa")))
                        reg.Placa = reader.GetString(reader.GetOrdinal("Placa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Motorista")))
                        reg.Cd_motorista = reader.GetString(reader.GetOrdinal("CD_Motorista"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Nm_motorista")))
                        reg.Nm_motorista = reader.GetString(reader.GetOrdinal("Nm_motorista"));
                    if (!reader.IsDBNull(reader.GetOrdinal("TP_Mov")))
                        reg.Tp_mov = reader.GetString(reader.GetOrdinal("TP_Mov"));
                    if (!reader.IsDBNull(reader.GetOrdinal("dt_colent")))
                        reg.Dt_colent = reader.GetDateTime(reader.GetOrdinal("dt_colent"));
                    if (!reader.IsDBNull(reader.GetOrdinal("dt_retorno")))
                        reg.Dt_retorno = reader.GetDateTime(reader.GetOrdinal("dt_retorno"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_frete")))
                        reg.Vl_frete = reader.GetDecimal(reader.GetOrdinal("Vl_frete"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Obs")))
                        reg.Ds_obs = reader.GetString(reader.GetOrdinal("Obs"));
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

        public string Gravar(TRegistro_ColetaEntrega val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(10);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_COLETA", val.Id_coleta);
            hs.Add("@P_ID_VEICULO", val.Id_veiculo);
            hs.Add("@P_CD_MOTORISTA", val.Cd_motorista);
            hs.Add("@P_TP_MOV", val.Tp_mov);
            hs.Add("@P_DT_COLENT", val.Dt_colent);
            hs.Add("@P_DT_RETORNO", val.Dt_retorno);
            hs.Add("@P_VL_FRETE", val.Vl_frete);
            hs.Add("@P_OBS", val.Ds_obs);

            return this.executarProc("IA_LOC_COLETAENTREGA", hs);
        }

        public string Excluir(TRegistro_ColetaEntrega val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(2);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_COLETA", val.Id_coleta);

            return this.executarProc("EXCLUI_LOC_COLETAENTREGA", hs);
        }

    }
    #endregion
}
