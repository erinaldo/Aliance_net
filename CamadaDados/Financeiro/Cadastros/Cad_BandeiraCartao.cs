using System;
using System.Collections.Generic;
using System.Text;
using Utils;
using System.Data.SqlClient;
using System.Collections;
using System.Data;

namespace CamadaDados.Financeiro.Cadastros
{
    public class TList_Cad_BandeiraCartao : List<TRegistro_Cad_BandeiraCartao>, IComparer<TRegistro_Cad_BandeiraCartao>
    {
        #region IComparer<TRegistro_Cad_BandeiraCartao> Members
        private System.ComponentModel.PropertyDescriptor Propriedade;
        private System.Windows.Forms.SortOrder Direcao;

        private int CompareAscending(object x, object y)
        {
            if (x is IComparable)
                return new CaseInsensitiveComparer().Compare(x, y);
            else
                return 0;
        }

        private int CompareDescending(object x, object y)
        {
            return -CompareAscending(x, y);
        }

        public TList_Cad_BandeiraCartao()
        { }

        public TList_Cad_BandeiraCartao(System.ComponentModel.PropertyDescriptor Prop,
                                        System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_Cad_BandeiraCartao value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_Cad_BandeiraCartao x, TRegistro_Cad_BandeiraCartao y)
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
    
    public class TRegistro_Cad_BandeiraCartao
    {
        private decimal? id_bandeira;
        public decimal? ID_Bandeira
        {
            get { return id_bandeira; }
            set
            {
                id_bandeira = value;
                id_bandeirastr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_bandeirastr;
        public string Id_bandeirastr
        {
            get { return id_bandeirastr; }
            set
            {
                id_bandeirastr = value;
                try
                {
                    id_bandeira = Convert.ToDecimal(value);
                }
                catch
                { id_bandeira = null; }
            }
        }
        public string DS_Bandeira
        { get; set; }
        private System.Drawing.Image imagem;
        public System.Drawing.Image Imagem
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
                    imagem = (System.Drawing.Image)new System.Drawing.ImageConverter().ConvertFrom(value);
            }
        }
        private string tp_cartao;
        public string Tp_cartao
        {
            get { return tp_cartao; }
            set
            {
                tp_cartao = value;
                tipo_cartao = value.Trim().ToUpper().Equals("D") ? "DEBITO" : value.Trim().ToUpper().Equals("C") ? "CREDITO" : value.Trim().ToUpper().Equals("ROTATIVO") ? "R" : string.Empty;
            }
        }
        private string tipo_cartao;
        public string Tipo_cartao
        {
            get { return tipo_cartao; }
            set
            {
                tipo_cartao = value;
                tp_cartao = value.Trim().ToUpper().Equals("DEBITO") ? "D" : value.Trim().ToUpper().Equals("CREDITO") ? "C" : value.Trim().ToUpper().Equals("ROTATIVO") ? "R" : string.Empty;
            }
        }
        public string St_registro
        { get; set; }
        public bool St_processar { get; set; } = false;
        public TRegistro_Cad_BandeiraCartao()
        {
            ID_Bandeira = null;
            id_bandeirastr = string.Empty;
            DS_Bandeira = string.Empty;
            Imagem = null;
            tp_cartao = string.Empty;
            tipo_cartao = string.Empty;
            St_registro = "A";
        }
    }

    public class TCD_Cad_BandeiraCartao : TDataQuery
    {
        public TCD_Cad_BandeiraCartao()
        {}

        public TCD_Cad_BandeiraCartao(BancoDados.TObjetoBanco banco)
        {Banco_Dados = banco;}

        private string SqlCodeBusca(TpBusca[] vBusca, Int16 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;

            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("select " + strTop + " a.ID_Bandeira, a.DS_Bandeira, ");
                sql.AppendLine("a.Imagem, a.tp_cartao, a.ST_Registro ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from tb_fin_bandeiracartao a ");
            sql.AppendLine("where isnull(a.st_registro, 'A') <> 'C'");
            
            string cond = " and ";

            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + ")");
            return sql.ToString();
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, string.Empty), null);
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo), null);
        }

        public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
        {
            return ExecutarBuscaEscalar(SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }

        public TList_Cad_BandeiraCartao Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_Cad_BandeiraCartao lista = new TList_Cad_BandeiraCartao();
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            SqlDataReader reader = ExecutarBusca(SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_Cad_BandeiraCartao reg = new TRegistro_Cad_BandeiraCartao();
                    if (!(reader.IsDBNull(reader.GetOrdinal("ID_Bandeira"))))
                        reg.ID_Bandeira = reader.GetDecimal(reader.GetOrdinal("ID_Bandeira"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("DS_Bandeira"))))
                        reg.DS_Bandeira = reader.GetString(reader.GetOrdinal("DS_Bandeira"));
                    if (!reader.IsDBNull(reader.GetOrdinal("imagem")))
                        reg.Img = (byte[])reader.GetValue(reader.GetOrdinal("imagem"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_cartao")))
                        reg.Tp_cartao = reader.GetString(reader.GetOrdinal("tp_cartao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_registro")))
                        reg.St_registro = reader.GetString(reader.GetOrdinal("st_registro"));
                    lista.Add(reg);
                }
            }
            finally
            {
                reader.Close();
                reader.Dispose();
                if (podeFecharBco)
                    deletarBanco_Dados();
            }
            return lista;
        }

        public string Gravar(TRegistro_Cad_BandeiraCartao val)
        {
            Hashtable hs = new Hashtable(5);
            hs.Add("@P_ID_BANDEIRA", val.ID_Bandeira);
            hs.Add("@P_DS_BANDEIRA", val.DS_Bandeira);
            hs.Add("@P_IMAGEM", val.Img);
            hs.Add("@P_TP_CARTAO", val.Tp_cartao);
            hs.Add("@P_ST_REGISTRO", val.St_registro);
            
            return executarProc("IA_FIN_BANDEIRACARTAO", hs);
        }

        public string Excluir(TRegistro_Cad_BandeiraCartao val)
        {
            Hashtable hs = new Hashtable(1);
            hs.Add("@P_ID_BANDEIRA", val.ID_Bandeira);

            return executarProc("EXCLUI_FIN_BANDEIRACARTAO", hs);
        }
    }
}
