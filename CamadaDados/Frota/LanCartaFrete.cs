using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamadaDados.Frota
{
    public class TList_CartaFrete : List<TRegistro_CartaFrete>, IComparer<TRegistro_CartaFrete>
    {
        #region IComparer<TRegistro_CartaFrete> Members
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

        public TList_CartaFrete()
        { }

        public TList_CartaFrete(System.ComponentModel.PropertyDescriptor Prop,
                                System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_CartaFrete value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_CartaFrete x, TRegistro_CartaFrete y)
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
    
    public class TRegistro_CartaFrete
    {
        private decimal? nr_cartafrete;
        
        public decimal? Nr_cartafrete
        {
            get { return nr_cartafrete; }
            set
            {
                nr_cartafrete = value;
                nr_cartafretestr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string nr_cartafretestr;
        
        public string Nr_cartafretestr
        {
            get { return nr_cartafretestr; }
            set
            {
                nr_cartafretestr = value;
                try
                {
                    nr_cartafrete = decimal.Parse(value);
                }
                catch
                { nr_cartafrete = null; }
            }
        }
        
        public string Cd_empresa
        { get; set; }
        
        public string Nm_empresa
        { get; set; }
        private decimal? nr_lancto;
        
        public decimal? Nr_lancto
        {
            get { return nr_lancto; }
            set
            {
                nr_lancto = value;
                nr_lanctostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string nr_lanctostr;
        
        public string Nr_lanctostr
        {
            get { return nr_lanctostr; }
            set
            {
                nr_lanctostr = value;
                try
                {
                    nr_lancto = decimal.Parse(value);
                }
                catch
                { nr_lancto = null; }
            }
        }
        
        public string Cd_motorista
        { get; set; }
        
        public string Nm_motorista
        { get; set; }
        
        private decimal? id_acerto;
        
        public decimal? Id_acerto
        {
            get { return id_acerto; }
            set
            {
                id_acerto = value;
                id_acertostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_acertostr;
        
        public string Id_acertostr
        {
            get { return id_acertostr; }
            set
            {
                id_acertostr = value;
                try
                {
                    id_acerto = decimal.Parse(value);
                }
                catch
                { id_acerto = null; }
            }
        }
        private DateTime? dt_emissao;
        
        public DateTime? Dt_emissao
        {
            get { return dt_emissao; }
            set
            {
                dt_emissao = value;
                dt_emissaostr = value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty;
            }
        }
        private string dt_emissaostr;
        public string Dt_emissaostr
        {
            get
            {
                try
                {
                    return DateTime.Parse(dt_emissaostr).ToString("dd/MM/yyyy");
                }
                catch
                { return string.Empty; }
            }
            set
            {
                dt_emissaostr = value;
                try
                {
                    dt_emissao = DateTime.Parse(value);
                }
                catch
                { dt_emissao = null; }
            }
        }
        
        public decimal Vl_documento
        { get; set; }
        
        public string Ds_observacao
        { get; set; }
        private string st_registro;
        
        public string St_registro
        {
            get { return st_registro; }
            set
            {
                st_registro = value;
                if (value.Trim().ToUpper().Equals("A"))
                    status = "ABERTO";
                else if (value.Trim().ToUpper().Equals("P"))
                    status = "PROCESSADO";
            }
        }
        private string status;
        
        public string Status
        {
            get { return status; }
            set
            {
                if (value.Trim().ToUpper().Equals("ABERTO"))
                    st_registro = "A";
                else if (value.Trim().ToUpper().Equals("PROCESSADO"))
                    st_registro = "P";
            }
        }

        
        public CamadaDados.Financeiro.Duplicata.TRegistro_LanDuplicata rDup
        { get; set; }
        
        public bool St_processar
        { get; set; }

        public TRegistro_CartaFrete()
        {
            this.nr_cartafrete = null;
            this.nr_cartafretestr = string.Empty;
            this.Cd_empresa = string.Empty;
            this.Nm_empresa = string.Empty;
            this.nr_lancto = null;
            this.nr_lanctostr = string.Empty;
            this.Cd_motorista = string.Empty;
            this.Nm_motorista = string.Empty;
            this.id_acerto = null;
            this.id_acertostr = string.Empty;
            this.dt_emissao = DateTime.Now;
            this.dt_emissaostr = DateTime.Now.ToString("dd/MM/yyyy");
            this.Vl_documento = decimal.Zero;
            this.Ds_observacao = string.Empty;
            this.rDup = null;
            this.St_processar = false;
            this.st_registro = "A";
            this.status = "ABERTO";
        }
    }

    public class TCD_CartaFrete : TDataQuery
    {
        public TCD_CartaFrete()
        { }

        public TCD_CartaFrete(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("select " + strTop + " a.NR_CartaFrete, a.CD_Empresa, ");
                sql.AppendLine("b.NM_Empresa, a.CD_Motorista, c.NM_Clifor as NM_Motorista, ");
                sql.AppendLine("a.ID_Acerto, a.DT_Emissao, a.DS_Observacao, ");
                sql.AppendLine("a.Vl_Documento, a.NR_Lancto, a.ST_Registro ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from tb_frt_cartafrete a ");
            sql.AppendLine("inner join tb_div_empresa b ");
            sql.AppendLine("on a.CD_Empresa = b.CD_Empresa ");
            sql.AppendLine("inner join TB_FIN_Clifor c ");
            sql.AppendLine("on a.CD_Motorista = c.CD_Clifor ");

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

        public TList_CartaFrete Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_CartaFrete lista = new TList_CartaFrete();
            System.Data.SqlClient.SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);

            try
            {
                reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
                while (reader.Read())
                {
                    TRegistro_CartaFrete reg = new TRegistro_CartaFrete();
                    if (!reader.IsDBNull(reader.GetOrdinal("NR_CartaFrete")))
                        reg.Nr_cartafrete = reader.GetDecimal(reader.GetOrdinal("NR_CartaFrete"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("CD_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_empresa")))
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("nm_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_lancto")))
                        reg.Nr_lancto = reader.GetDecimal(reader.GetOrdinal("nr_lancto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Motorista")))
                        reg.Cd_motorista = reader.GetString(reader.GetOrdinal("CD_Motorista"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NM_Motorista")))
                        reg.Nm_motorista = reader.GetString(reader.GetOrdinal("NM_Motorista"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Acerto")))
                        reg.Id_acerto = reader.GetDecimal(reader.GetOrdinal("ID_Acerto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DT_Emissao")))
                        reg.Dt_emissao = reader.GetDateTime(reader.GetOrdinal("DT_Emissao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_Documento")))
                        reg.Vl_documento = reader.GetDecimal(reader.GetOrdinal("Vl_Documento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Observacao")))
                        reg.Ds_observacao = reader.GetString(reader.GetOrdinal("DS_Observacao"));
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

        public string Gravar(TRegistro_CartaFrete val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(9);
            hs.Add("@P_NR_CARTAFRETE", val.Nr_cartafrete);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_NR_LANCTO", val.Nr_lancto);
            hs.Add("@P_CD_MOTORISTA", val.Cd_motorista);
            hs.Add("@P_ID_ACERTO", val.Id_acerto);
            hs.Add("@P_DT_EMISSAO", val.Dt_emissao);
            hs.Add("@P_VL_DOCUMENTO", val.Vl_documento);
            hs.Add("@P_DS_OBSERVACAO", val.Ds_observacao);
            hs.Add("@P_ST_REGISTRO", val.St_registro);

            return this.executarProc("IA_FRT_CARTAFRETE", hs);
        }

        public string Excluir(TRegistro_CartaFrete val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(2);
            hs.Add("@P_NR_CARTAFRETE", val.Nr_cartafrete);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);

            return this.executarProc("EXCLUI_FRT_CARTAFRETE", hs);
        }
    }
}
