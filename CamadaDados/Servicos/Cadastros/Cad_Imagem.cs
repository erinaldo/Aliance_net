using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamadaDados.Servicos.Cadastros
{
    public class TList_Imagens : List<TRegistro_Imagens>, IComparer<TRegistro_Imagens>
    {
        #region IComparer<TRegistro_OSE_Imagens> Members
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

        public TList_Imagens()
        { }

        public TList_Imagens(System.ComponentModel.PropertyDescriptor Prop,
                             System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_Imagens value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_Imagens x, TRegistro_Imagens y)
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

    
    public class TRegistro_Imagens
    {
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
        
        public string Cd_empresa
        { get; set; }
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
                    id_imagem = decimal.Parse(value);
                }
                catch
                { id_imagem = null; }
            }
        }
        
        public string Ds_imagem
        { get; set; }
        private System.Drawing.Image foto_imagem;
        
        public System.Drawing.Image Foto_imagem
        {
            get { return foto_imagem; }
            set
            {
                foto_imagem = value;
                if (value != null)
                {
                    using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
                    {
                        foto_imagem.Save(ms, foto_imagem.RawFormat);
                        foto_byte = ms.ToArray();
                    }
                }
            }
        }
        private byte[] foto_byte;
        
        public byte[] Foto_byte
        {
            get{ return foto_byte; }
            set
            {
                foto_byte = value;
                if (value != null)
                    foto_imagem = (System.Drawing.Image)new System.Drawing.ImageConverter().ConvertFrom(value);
            }
        }

        public TRegistro_Imagens()
        {
            this.id_os = null;
            this.id_osstr = string.Empty;
            this.Cd_empresa = string.Empty;
            this.id_imagem = null;
            this.id_imagemstr = string.Empty;
            this.Ds_imagem = string.Empty;
            this.foto_imagem = null;
            this.foto_byte = null;
        }
    }
    
    public class TCD_Imagens : TDataQuery
    {
        public TCD_Imagens()
        {}

        public TCD_Imagens(BancoDados.TObjetoBanco banco)
        {this.Banco_Dados = banco;}

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();

            if (string.IsNullOrEmpty(vNM_Campo))
                sql.AppendLine(" SELECT " + strTop + " a.id_os, a.CD_Empresa, a.ID_Imagem, a.DS_Imagem, a.Foto_Imagem ");
  
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine(" FROM TB_OSE_Imagens a");

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

        public TList_Imagens Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_Imagens lista = new TList_Imagens();
            System.Data.SqlClient.SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);

            try
            {
                reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
                while (reader.Read())
                {
                    TRegistro_Imagens reg = new TRegistro_Imagens();

                    if (!reader.IsDBNull(reader.GetOrdinal("ID_OS")))
                        reg.Id_os = reader.GetDecimal(reader.GetOrdinal("ID_OS"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("CD_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Imagem")))
                        reg.Id_imagem = reader.GetDecimal(reader.GetOrdinal("ID_Imagem"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Imagem")))
                        reg.Ds_imagem = reader.GetString(reader.GetOrdinal("DS_Imagem"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Foto_Imagem")))
                        reg.Foto_byte = (byte[])reader.GetValue(reader.GetOrdinal("Foto_Imagem"));
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

        public string Grava(TRegistro_Imagens vRegistro)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(4);
            hs.Add("@P_ID_OS", vRegistro.Id_os); 
            hs.Add("@P_CD_EMPRESA", vRegistro.Cd_empresa);
            hs.Add("@P_ID_IMAGEM", vRegistro.Id_imagem); 
            hs.Add("@P_DS_IMAGEM", vRegistro.Ds_imagem);
            hs.Add("@P_FOTO_IMAGEM", vRegistro.Foto_byte);

            return this.executarProc("IA_OSE_IMAGENS", hs);
        }

        public string Deleta(TRegistro_Imagens vRegistro)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(3);
            hs.Add("@P_ID_OS", vRegistro.Id_os); 
            hs.Add("@P_CD_EMPRESA", vRegistro.Cd_empresa);
            hs.Add("@P_ID_IMAGEM", vRegistro.Id_imagem); 

            return this.executarProc("EXCLUI_OSE_IMAGENS", hs);
        }
    }
}

