using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;
using System.Data.SqlClient;
using System.Drawing;

namespace CamadaDados.Faturamento.Cadastros
{
    public class TList_CFGImpNF : List<TRegistro_CFGImpNF>
    { }

    
    public class TRegistro_CFGImpNF
    {
        
        public string Nr_serie
        { get; set; }
        
        public string Ds_serienf
        { get; set; }
        
        public string Cd_modelo
        { get; set; }
        
        public string Ds_modelo
        { get; set; }
        
        public string Cd_empresa
        { get; set; }
        
        public string Nm_empresa
        { get; set; }
        
        public decimal Qt_itensnota
        { get; set; }
        
        public decimal Tam_dadosadic
        { get; set; }
        
        public decimal Larguranf
        { get; set; }
        
        public decimal Alturanf
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

        public string Modelorst
        { get; set; }
        
        public decimal Qt_linha
        { get; set; }

        public TRegistro_CFGImpNF()
        {
            this.Nr_serie = string.Empty;
            this.Ds_serienf = string.Empty;
            this.Cd_modelo = string.Empty;
            this.Ds_modelo = string.Empty;
            this.Cd_empresa = string.Empty;
            this.Nm_empresa = string.Empty;
            this.Qt_itensnota = decimal.Zero;
            this.Tam_dadosadic = decimal.Zero;
            this.Larguranf = decimal.Zero;
            this.Alturanf = decimal.Zero;
            this.imagem = null;
            this.img = null;
            this.Modelorst = string.Empty;
            this.Qt_linha = decimal.Zero;
        }
    }

    public class TCD_CFGImpNF : TDataQuery
    {
        public TCD_CFGImpNF()
        { }

        public TCD_CFGImpNF(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();

            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine(" SELECT " + strTop + " a.Nr_Serie, b.DS_SerieNf, a.CD_Empresa, ");
                sql.AppendLine("a.cd_modelo, d.ds_modelo, ");
                sql.AppendLine("c.NM_Empresa, a.QT_ItensNota, a.Tam_DadosAdic, ");
                sql.AppendLine("a.LarguraNF, a.AlturaNF, a.ImagemNF, a.ModeloRST, a.QT_Linha ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from tb_fat_cfgimpnf a ");
            sql.AppendLine("inner join TB_FAT_SerieNF b ");
            sql.AppendLine("on a.nr_serie = b.Nr_Serie ");
            sql.AppendLine("and a.cd_modelo = b.cd_modelo ");
            sql.AppendLine("inner join TB_DIV_Empresa c ");
            sql.AppendLine("on a.cd_empresa = c.cd_empresa ");
            sql.AppendLine("inner join tb_fat_modelonf d ");
            sql.AppendLine("on a.cd_modelo = d.cd_modelo ");

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

        public TList_CFGImpNF Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_CFGImpNF lista = new TList_CFGImpNF();
            SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);

            try
            {
                reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
                while (reader.Read())
                {
                    TRegistro_CFGImpNF reg = new TRegistro_CFGImpNF();
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_serie")))
                        reg.Nr_serie = reader.GetString(reader.GetOrdinal("nr_serie"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_serienf")))
                        reg.Ds_serienf = reader.GetString(reader.GetOrdinal("ds_serienf"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_modelo")))
                        reg.Cd_modelo = reader.GetString(reader.GetOrdinal("cd_modelo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_modelo")))
                        reg.Ds_modelo = reader.GetString(reader.GetOrdinal("ds_modelo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_empresa")))
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("nm_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ImagemNF")))
                        reg.Img = (byte[])reader.GetValue(reader.GetOrdinal("ImagemNF"));
                    if (!reader.IsDBNull(reader.GetOrdinal("qt_itensnota")))
                        reg.Qt_itensnota = reader.GetDecimal(reader.GetOrdinal("qt_itensnota"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tam_dadosadic")))
                        reg.Tam_dadosadic = reader.GetDecimal(reader.GetOrdinal("tam_dadosadic"));
                    if (!reader.IsDBNull(reader.GetOrdinal("AlturaNF")))
                        reg.Alturanf = reader.GetDecimal(reader.GetOrdinal("AlturaNF"));
                    if (!reader.IsDBNull(reader.GetOrdinal("LarguraNF")))
                        reg.Larguranf = reader.GetDecimal(reader.GetOrdinal("LarguraNF"));
                    if (!reader.IsDBNull(reader.GetOrdinal("QT_Linha")))
                        reg.Qt_linha = reader.GetDecimal(reader.GetOrdinal("QT_Linha"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ModeloRST")))
                        reg.Modelorst = reader.GetString(reader.GetOrdinal("ModeloRST"));

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

        public string GravarCFGImpNF(TRegistro_CFGImpNF val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(10);
            hs.Add("@P_NR_SERIE", val.Nr_serie);
            hs.Add("@P_CD_MODELO", val.Cd_modelo);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_QT_ITENSNOTA", val.Qt_itensnota);
            hs.Add("@P_TAM_DADOSADIC", val.Tam_dadosadic);
            hs.Add("@P_LARGURANF", val.Larguranf);
            hs.Add("@P_ALTURANF", val.Alturanf);
            hs.Add("@P_IMAGEMNF", val.Img);
            hs.Add("@P_MODELORST", val.Modelorst);
            hs.Add("@P_QT_LINHA", val.Qt_linha);

            return this.executarProc("IA_FAT_CFGIMPNF", hs);
        }

        public string ExcluirCFGImpNF(TRegistro_CFGImpNF val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(3);
            hs.Add("@P_NR_SERIE", val.Nr_serie);
            hs.Add("@P_CD_MODELO", val.Cd_modelo);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);

            return this.executarProc("EXCLUI_FAT_CFGIMPNF", hs);
        }
    }
}
