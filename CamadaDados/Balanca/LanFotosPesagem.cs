using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Utils;
using System.Data.SqlClient;

namespace CamadaDados.Balanca
{
    public class TList_FotosPesagem : List<TRegistro_FotosPesagem>, IComparer<TRegistro_FotosPesagem>
    {
        #region IComparer<TRegistro_FotosPesagem> Members
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

        public TList_FotosPesagem()
        { }

        public TList_FotosPesagem(System.ComponentModel.PropertyDescriptor Prop,
                                  System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_FotosPesagem value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_FotosPesagem x, TRegistro_FotosPesagem y)
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

    
    public class TRegistro_FotosPesagem
    {
        
        public string Cd_empresa
        { get; set; }
        
        public decimal? Id_ticket
        { get; set; }
        
        public string Tp_pesagem
        { get; set; }
        
        public decimal? Id_imagem
        { get; set; }
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

        public TRegistro_FotosPesagem()
        {
            this.Cd_empresa = string.Empty;
            this.Id_imagem = null;
            this.Tp_pesagem = string.Empty;
            this.Id_imagem = null;
            this.imagem = null;
            this.img = null;
        }
    }

    public class TCD_FotosPesagem : TDataQuery
    {
        public TCD_FotosPesagem()
        { }

        public TCD_FotosPesagem(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();

            if (string.IsNullOrEmpty(vNM_Campo))
                sql.AppendLine(" SELECT " + strTop + " a.cd_empresa, a.id_ticket, a.tp_pesagem, a.id_imagem, a.imagem ");
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine(" FROM TB_BAL_FotosPesagem a ");

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

        public override System.Data.DataTable Buscar(TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo), null);
        }

        public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
        {
            return this.ExecutarBuscaEscalar(this.SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }

        public TList_FotosPesagem Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_FotosPesagem lista = new TList_FotosPesagem();
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            SqlDataReader reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_FotosPesagem reg = new TRegistro_FotosPesagem();

                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_ticket")))
                        reg.Id_ticket = reader.GetDecimal(reader.GetOrdinal("id_ticket"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_pesagem")))
                        reg.Tp_pesagem = reader.GetString(reader.GetOrdinal("tp_pesagem"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Imagem")))
                        reg.Id_imagem = reader.GetDecimal(reader.GetOrdinal("ID_Imagem"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Imagem")))
                        reg.Img = (byte[])reader.GetValue(reader.GetOrdinal("Imagem"));

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

        public string Gravar(TRegistro_FotosPesagem val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(5);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_TICKET", val.Id_ticket);
            hs.Add("@P_TP_PESAGEM", val.Tp_pesagem);
            hs.Add("@P_ID_IMAGEM", val.Id_imagem);
            hs.Add("@P_IMAGEM", val.Img);

            return this.executarProc("IA_BAL_FOTOSPESAGEM", hs);
        }

        public string Excluir(TRegistro_FotosPesagem val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(4);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_TICKET", val.Id_ticket);
            hs.Add("@P_TP_PESAGEM", val.Tp_pesagem);
            hs.Add("@P_ID_IMAGEM", val.Id_imagem);

            return this.executarProc("EXCLUI_BAL_FOTOSPESAGEM", hs);
        }
    }
}
