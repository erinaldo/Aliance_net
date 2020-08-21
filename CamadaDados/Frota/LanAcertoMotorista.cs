using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamadaDados.Frota
{
    #region Acerto Motorista
    public class TList_AcertoMotorista : List<TRegistro_AcertoMotorista>, IComparer<TRegistro_AcertoMotorista>
    {
        #region IComparer<TRegistro_AcertoMotorista> Members
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

        public TList_AcertoMotorista()
        { }

        public TList_AcertoMotorista(System.ComponentModel.PropertyDescriptor Prop,
                                     System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_AcertoMotorista value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_AcertoMotorista x, TRegistro_AcertoMotorista y)
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
    
    public class TRegistro_AcertoMotorista
    {
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
        public string Cd_empresa
        { get; set; }
        public string Nm_empresa
        { get; set; }
        public string Cd_motorista
        { get; set; }
        public string Nm_motorista
        { get; set; }
        public decimal? Nr_lancto
        { get; set; }
        public string Cd_contager
        { get; set; }
        private decimal? cd_lanctocaixa;
        public decimal? Cd_lanctocaixa
        {
            get { return cd_lanctocaixa; }
            set
            {
                cd_lanctocaixa = value;
                cd_lanctocaixastr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string cd_lanctocaixastr;
        public string Cd_lanctocaixastr
        {
            get { return cd_lanctocaixastr; }
            set
            {
                cd_lanctocaixastr = value;
                try
                {
                    cd_lanctocaixa = decimal.Parse(value);
                }
                catch
                { cd_lanctocaixa = null; }
            }
        }
        private decimal? cd_lanctocaixadesp;
        public decimal? Cd_lanctocaixadesp
        {
            get { return cd_lanctocaixadesp; }
            set
            {
                cd_lanctocaixadesp = value;
                cd_lanctocaixadespstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string cd_lanctocaixadespstr;
        public string Cd_lanctocaixadespstr
        {
            get { return cd_lanctocaixadespstr; }
            set
            {
                cd_lanctocaixadespstr = value;
                try
                {
                    cd_lanctocaixadesp = decimal.Parse(value);
                }
                catch
                { cd_lanctocaixadesp = null; }
            }
        }
        private decimal? id_adto;
        public decimal? Id_adto
        {
            get { return id_adto; }
            set
            {
                id_adto = value;
                id_adtostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_adtostr;
        public string Id_adtostr
        {
            get { return id_adtostr; }
            set
            {
                id_adtostr = value;
                try
                {
                    id_adto = decimal.Parse(value);
                }
                catch
                { id_adto = null; }
            }
        }
        private DateTime? dt_acerto;
        public DateTime? Dt_acerto
        {
            get { return dt_acerto; }
            set
            {
                dt_acerto = value;
                dt_acertostr = value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty;
            }
        }
        private string dt_acertostr;
        public string Dt_acertostr
        {
            get
            {
                try
                {
                    return DateTime.Parse(dt_acertostr).ToString("dd/MM/yyyy");
                }
                catch
                { return string.Empty; }
            }
            set
            {
                dt_acertostr = value;
                try
                {
                    dt_acerto = DateTime.Parse(value);
                }
                catch
                { dt_acerto = null; }
            }
        }
        public decimal Vl_adiantamentos
        { get; set; }
        public decimal Vl_outrosAdto
        { get; set; }
        public decimal Vl_cartafrete
        { get; set; }
        public decimal Vl_chtroco
        { get; set; }
        public decimal Vl_despesas
        { get; set; }
        public decimal Vl_abastecimento
        { get; set; }
        public decimal Vl_manutencao
        { get; set; }
        public decimal Vl_infracoes
        { get; set; }
        public decimal Vl_sobradinheiro
        { get; set; }
        public decimal Tot_despesas
        { get { return Vl_despesas + Vl_abastecimento + Vl_manutencao + Vl_infracoes + Vl_sobradinheiro + Vl_chtroco; } }
        public decimal Vl_resultado
        { get { return this.Vl_adiantamentos + this.Vl_outrosAdto + this.Vl_cartafrete - this.Tot_despesas; } }
        public decimal Vl_adtoDevolvidos
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
                    status = "ATIVO";
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
                status = value;
                if (value.Trim().ToUpper().Equals("ATIVO"))
                    st_registro = "A";
                else if (value.Trim().ToUpper().Equals("PROCESSADO"))
                    st_registro = "P";
            }
        }
        
        public TList_Viagem lViagem
        { get; set; }
        public TList_Viagem lViagemDel
        { get; set; }
        public TList_CartaFrete lCartaFrete
        { get; set; }
        public TList_CartaFrete lCartaFreteDel
        { get; set; }
        public CamadaDados.Financeiro.Duplicata.TRegistro_LanDuplicata rDup
        { get; set; }
        public CamadaDados.Financeiro.Caixa.TRegistro_LanCaixa rCaixa
        { get; set; }
        public CamadaDados.Financeiro.Adiantamento.TRegistro_LanAdiantamento rAdto
        { get; set; }
        public CamadaDados.Financeiro.Titulo.TList_RegLanTitulo lCheque
        { get; set; }
        public CamadaDados.Financeiro.Titulo.TList_RegLanTitulo lChequeDel
        { get; set; }
        
        public TRegistro_AcertoMotorista()
        {
            this.id_acerto = null;
            this.id_acertostr = string.Empty;
            this.Cd_empresa = string.Empty;
            this.Nm_empresa = string.Empty;
            this.Cd_motorista = string.Empty;
            this.Nm_motorista = string.Empty;
            this.Nr_lancto = null;
            this.Cd_contager = string.Empty;
            this.cd_lanctocaixa = null;
            this.cd_lanctocaixastr = string.Empty;
            this.cd_lanctocaixadesp = null;
            this.cd_lanctocaixadespstr = string.Empty;
            this.id_adto = null;
            this.id_adtostr = string.Empty;
            this.dt_acerto = DateTime.Now;
            this.dt_acertostr = DateTime.Now.ToString("dd/MM/yyyy");
            this.Vl_adiantamentos = decimal.Zero;
            this.Vl_outrosAdto = decimal.Zero;
            this.Vl_cartafrete = decimal.Zero;
            this.Vl_despesas = decimal.Zero;
            this.Vl_abastecimento = decimal.Zero;
            this.Vl_manutencao = decimal.Zero;
            this.Vl_infracoes = decimal.Zero;
            this.Vl_sobradinheiro = decimal.Zero;
            this.Vl_chtroco = decimal.Zero;
            this.Vl_adtoDevolvidos = decimal.Zero;
            this.Ds_observacao = string.Empty;
            this.st_registro = "A";
            this.status = "ATIVO";
            this.lViagem = new TList_Viagem();
            this.lViagemDel = new TList_Viagem();
            this.lCartaFrete = new TList_CartaFrete();
            this.lCartaFreteDel = new TList_CartaFrete();
            this.rDup = null;
            this.rCaixa = null;
            this.rAdto = null;
            this.lCheque = new CamadaDados.Financeiro.Titulo.TList_RegLanTitulo();
            this.lChequeDel = new CamadaDados.Financeiro.Titulo.TList_RegLanTitulo();
        }
    }

    public class TCD_AcertoMotorista : TDataQuery
    {
        public TCD_AcertoMotorista()
        { }

        public TCD_AcertoMotorista(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo, string vOrder)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("select " + strTop + " a.ID_Acerto, a.CD_Empresa, a.nr_lancto, ");
                sql.AppendLine("b.NM_Empresa, a.CD_Motorista, c.NM_Clifor as NM_Motorista, a.id_adto, ");
                sql.AppendLine("a.cd_contager, a.cd_lanctocaixa, a.DT_Acerto, a.ST_Registro, a.DS_Observacao, ");
                sql.AppendLine("a.Vl_Adiantamentos, a.vl_outrosadto, a.Vl_Despesas, a.Vl_sobradinheiro, a.vl_chtroco, a.vl_cartafrete, ");
                sql.AppendLine("a.vl_abastecimento, a.vl_manutencao, a.vl_infracoes, a.cd_lanctocaixadesp, ");
                sql.AppendLine("vl_adtodevolvidos = isnull((select sum(isnull(y.vl_receber, 0)) ");
                sql.AppendLine("                            from TB_FRT_Acerto_X_DevAdto x ");
                sql.AppendLine("                            inner join tb_fin_caixa y ");
                sql.AppendLine("                            on x.cd_contager = y.cd_contager ");
                sql.AppendLine("                            and x.cd_lanctocaixa = y.cd_lanctocaixa ");
                sql.AppendLine("                            where x.cd_empresa = a.cd_empresa ");
                sql.AppendLine("                            and x.id_acerto = a.id_acerto ");
                sql.AppendLine("                            and isnull(y.st_estorno, 'N') <> 'S'), 0)");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from TB_FRT_AcertoMotorista a ");
            sql.AppendLine("inner join TB_DIV_Empresa b ");
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
            if (!string.IsNullOrEmpty(vOrder))
                sql.AppendLine("order by " + vOrder);
            return sql.ToString();
        }

        public override System.Data.DataTable Buscar(Utils.TpBusca[] vBusca, short vTop)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, string.Empty, string.Empty), null);
        }

        public override System.Data.DataTable Buscar(Utils.TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo, string.Empty), null);
        }

        public override object BuscarEscalar(Utils.TpBusca[] vBusca, string vNM_Campo)
        {
            return this.ExecutarBuscaEscalar(this.SqlCodeBusca(vBusca, 1, vNM_Campo, string.Empty), null);
        }

        public TList_AcertoMotorista Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_AcertoMotorista lista = new TList_AcertoMotorista();
            System.Data.SqlClient.SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);

            try
            {
                reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo, string.Empty));
                while (reader.Read())
                {
                    TRegistro_AcertoMotorista reg = new TRegistro_AcertoMotorista();
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Acerto")))
                        reg.Id_acerto = reader.GetDecimal(reader.GetOrdinal("ID_Acerto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("CD_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_empresa")))
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("nm_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Motorista")))
                        reg.Cd_motorista = reader.GetString(reader.GetOrdinal("CD_Motorista"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NM_Motorista")))
                        reg.Nm_motorista = reader.GetString(reader.GetOrdinal("NM_Motorista"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_lancto")))
                        reg.Nr_lancto = reader.GetDecimal(reader.GetOrdinal("nr_lancto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_contager")))
                        reg.Cd_contager = reader.GetString(reader.GetOrdinal("cd_contager"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_lanctocaixa")))
                        reg.Cd_lanctocaixa = reader.GetDecimal(reader.GetOrdinal("cd_lanctocaixa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_lanctocaixadesp")))
                        reg.Cd_lanctocaixadesp = reader.GetDecimal(reader.GetOrdinal("cd_lanctocaixadesp"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_adto")))
                        reg.Id_adto = reader.GetDecimal(reader.GetOrdinal("id_adto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DT_Acerto")))
                        reg.Dt_acerto = reader.GetDateTime(reader.GetOrdinal("DT_Acerto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_Adiantamentos")))
                        reg.Vl_adiantamentos = reader.GetDecimal(reader.GetOrdinal("Vl_Adiantamentos"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_outrosadto")))
                        reg.Vl_outrosAdto = reader.GetDecimal(reader.GetOrdinal("vl_outrosadto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_cartafrete")))
                        reg.Vl_cartafrete = reader.GetDecimal(reader.GetOrdinal("vl_cartafrete"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_Despesas")))
                        reg.Vl_despesas = reader.GetDecimal(reader.GetOrdinal("Vl_Despesas"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_abastecimento")))
                        reg.Vl_abastecimento = reader.GetDecimal(reader.GetOrdinal("vl_abastecimento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_manutencao")))
                        reg.Vl_manutencao = reader.GetDecimal(reader.GetOrdinal("vl_manutencao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_infracoes")))
                        reg.Vl_infracoes = reader.GetDecimal(reader.GetOrdinal("vl_infracoes"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_sobradinheiro")))
                        reg.Vl_sobradinheiro = reader.GetDecimal(reader.GetOrdinal("vl_sobradinheiro"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_chtroco")))
                        reg.Vl_chtroco = reader.GetDecimal(reader.GetOrdinal("vl_chtroco"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_adtodevolvidos")))
                        reg.Vl_adtoDevolvidos = reader.GetDecimal(reader.GetOrdinal("vl_adtodevolvidos"));
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

        public string Gravar(TRegistro_AcertoMotorista val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(20);
            hs.Add("@P_ID_ACERTO", val.Id_acerto);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_CD_MOTORISTA", val.Cd_motorista);
            hs.Add("@P_NR_LANCTO", val.Nr_lancto);
            hs.Add("@P_CD_CONTAGER", val.Cd_contager);
            hs.Add("@P_CD_LANCTOCAIXA", val.Cd_lanctocaixa);
            hs.Add("@P_CD_LANCTOCAIXADESP", val.Cd_lanctocaixadesp);
            hs.Add("@P_ID_ADTO", val.Id_adto);
            hs.Add("@P_DT_ACERTO", val.Dt_acerto);
            hs.Add("@P_VL_ADIANTAMENTOS", val.Vl_adiantamentos);
            hs.Add("@P_VL_OUTROSADTO", val.Vl_outrosAdto);
            hs.Add("@P_VL_CARTAFRETE", val.Vl_cartafrete);
            hs.Add("@P_VL_DESPESAS", val.Vl_despesas);
            hs.Add("@P_VL_ABASTECIMENTO", val.Vl_abastecimento);
            hs.Add("@P_VL_MANUTENCAO", val.Vl_manutencao);
            hs.Add("@P_VL_INFRACOES", val.Vl_infracoes);
            hs.Add("@P_VL_SOBRADINHEIRO", val.Vl_sobradinheiro);
            hs.Add("@P_VL_CHTROCO", val.Vl_chtroco);
            hs.Add("@P_DS_OBSERVACAO", val.Ds_observacao);
            hs.Add("@P_ST_REGISTRO", val.St_registro);

            return this.executarProc("IA_FRT_ACERTOMOTORISTA", hs);
        }

        public string Excluir(TRegistro_AcertoMotorista val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(2);
            hs.Add("@P_ID_ACERTO", val.Id_acerto);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);

            return this.executarProc("EXCLUI_FRT_ACERTOMOTORISTA", hs);
        }
    }
    #endregion

    #region Acerto X Viagem
    public class TList_Acerto_X_Viagem : List<TRegistro_Acerto_X_Viagem>
    { }

    
    public class TRegistro_Acerto_X_Viagem
    {
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
        
        public string Cd_empresa
        { get; set; }
        private decimal? id_viagem;
        
        public decimal? Id_viagem
        {
            get { return id_viagem; }
            set
            {
                id_viagem = value;
                id_viagemstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_viagemstr;
        
        public string Id_viagemstr
        {
            get { return id_viagemstr; }
            set
            {
                id_viagemstr = value;
                try
                {
                    id_viagem = decimal.Parse(value);
                }
                catch
                { id_viagem = null; }
            }
        }

        public TRegistro_Acerto_X_Viagem()
        {
            this.id_acerto = null;
            this.id_acertostr = string.Empty;
            this.Cd_empresa = string.Empty;
            this.id_viagem = null;
            this.id_viagemstr = string.Empty;
        }
    }

    public class TCD_Acerto_X_Viagem : TDataQuery
    {
        public TCD_Acerto_X_Viagem()
        { }

        public TCD_Acerto_X_Viagem(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
                sql.AppendLine("select " + strTop + " a.ID_Acerto, a.CD_Empresa, a.ID_Viagem ");
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from TB_FRT_Acerto_X_Viagem a ");

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

        public TList_Acerto_X_Viagem Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_Acerto_X_Viagem lista = new TList_Acerto_X_Viagem();
            System.Data.SqlClient.SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);

            try
            {
                reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
                while (reader.Read())
                {
                    TRegistro_Acerto_X_Viagem reg = new TRegistro_Acerto_X_Viagem();
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Acerto")))
                        reg.Id_acerto = reader.GetDecimal(reader.GetOrdinal("ID_Acerto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("CD_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Viagem")))
                        reg.Id_viagem = reader.GetDecimal(reader.GetOrdinal("ID_Viagem"));

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

        public string Gravar(TRegistro_Acerto_X_Viagem val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(3);
            hs.Add("@P_ID_ACERTO", val.Id_acerto);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_VIAGEM", val.Id_viagem);

            return this.executarProc("IA_ACERTO_X_VIAGEM", hs);
        }

        public string Excluir(TRegistro_Acerto_X_Viagem val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(3);
            hs.Add("@P_ID_ACERTO", val.Id_acerto);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_VIAGEM", val.Id_viagem);

            return this.executarProc("EXCLUI_FRT_ACERTO_X_VIAGEM", hs);
        }
    }
    #endregion

    #region Acerto X DevAdto
    public class TList_Acerto_X_DevAdto : List<TRegistro_Acerto_X_DevAdto>
    { }

    
    public class TRegistro_Acerto_X_DevAdto
    {
        
        public decimal? Id_acerto
        { get; set; }
        
        public string Cd_empresa
        { get; set; }
        
        public decimal? Id_adto
        { get; set; }
        
        public decimal? Cd_lanctocaixa
        { get; set; }
        
        public string Cd_contager
        { get; set; }

        public TRegistro_Acerto_X_DevAdto()
        {
            this.Id_acerto = null;
            this.Cd_empresa = string.Empty;
            this.Id_adto = null;
            this.Cd_lanctocaixa = null;
            this.Cd_contager = string.Empty;
        }
    }

    public class TCD_Acerto_X_DevAdto : TDataQuery
    {
        public TCD_Acerto_X_DevAdto()
        { }

        public TCD_Acerto_X_DevAdto(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
                sql.AppendLine("select " + strTop + " a.ID_Acerto, a.CD_Empresa, a.ID_Adto, a.CD_LanctoCaixa, a.CD_ContaGer ");
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from TB_FRT_Acerto_X_DevAdto a ");

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

        public TList_Acerto_X_DevAdto Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_Acerto_X_DevAdto lista = new TList_Acerto_X_DevAdto();
            System.Data.SqlClient.SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);

            try
            {
                reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
                while (reader.Read())
                {
                    TRegistro_Acerto_X_DevAdto reg = new TRegistro_Acerto_X_DevAdto();
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Acerto")))
                        reg.Id_acerto = reader.GetDecimal(reader.GetOrdinal("ID_Acerto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("CD_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Adto")))
                        reg.Id_adto = reader.GetDecimal(reader.GetOrdinal("ID_Adto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_LanctoCaixa")))
                        reg.Cd_lanctocaixa = reader.GetDecimal(reader.GetOrdinal("CD_LanctoCaixa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_ContaGer")))
                        reg.Cd_contager = reader.GetString(reader.GetOrdinal("CD_ContaGer"));

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

        public string Gravar(TRegistro_Acerto_X_DevAdto val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(5);
            hs.Add("@P_ID_ACERTO", val.Id_acerto);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_ADTO", val.Id_adto);
            hs.Add("@P_CD_LANCTOCAIXA", val.Cd_lanctocaixa);
            hs.Add("@P_CD_CONTAGER", val.Cd_contager);

            return this.executarProc("IA_FRT_ACERTO_X_DEVADTO", hs);
        }

        public string Excluir(TRegistro_Acerto_X_DevAdto val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(5);
            hs.Add("@P_ID_ACERTO", val.Id_acerto);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_ADTO", val.Id_adto);
            hs.Add("@P_CD_LANCTOCAIXA", val.Cd_lanctocaixa);
            hs.Add("@P_CD_CONTAGER", val.Cd_contager);

            return this.executarProc("EXCLUI_FRT_ACERTO_X_DEVADTO", hs);
        }
    }
    #endregion

    #region Acerto X Titulo
    public class TList_Acerto_X_Titulo : List<TRegistro_Acerto_X_Titulo>
    { }
    
    public class TRegistro_Acerto_X_Titulo
    {
        
        public decimal? Id_acerto
        { get; set; }
        
        public string Cd_empresa
        { get; set; }
        
        public decimal? Nr_lanctocheque
        { get; set; }
        
        public string Cd_banco
        { get; set; }

        public TRegistro_Acerto_X_Titulo()
        {
            this.Id_acerto = null;
            this.Cd_empresa = string.Empty;
            this.Nr_lanctocheque = null;
            this.Cd_banco = string.Empty;
        }
    }

    public class TCD_Acerto_X_Titulo : TDataQuery
    {
        public TCD_Acerto_X_Titulo()
        { }

        public TCD_Acerto_X_Titulo(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
                sql.AppendLine("select " + strTop + " a.ID_Acerto, a.CD_Empresa, a.NR_LanctoCheque, a.CD_Banco ");
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from TB_FRT_Acerto_X_Titulo a ");

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

        public TList_Acerto_X_Titulo Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_Acerto_X_Titulo lista = new TList_Acerto_X_Titulo();
            System.Data.SqlClient.SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);

            try
            {
                reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
                while (reader.Read())
                {
                    TRegistro_Acerto_X_Titulo reg = new TRegistro_Acerto_X_Titulo();
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Acerto")))
                        reg.Id_acerto = reader.GetDecimal(reader.GetOrdinal("ID_Acerto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("CD_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NR_LanctoCheque")))
                        reg.Nr_lanctocheque = reader.GetDecimal(reader.GetOrdinal("NR_LanctoCheque"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Banco")))
                        reg.Cd_banco = reader.GetString(reader.GetOrdinal("CD_Banco"));

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

        public string Gravar(TRegistro_Acerto_X_Titulo val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(4);
            hs.Add("@P_ID_ACERTO", val.Id_acerto);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_NR_LANCTOCHEQUE", val.Nr_lanctocheque);
            hs.Add("@P_CD_BANCO", val.Cd_banco);

            return this.executarProc("IA_FRT_ACERTO_X_TITULO", hs);
        }

        public string Excluir(TRegistro_Acerto_X_Titulo val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(4);
            hs.Add("@P_ID_ACERTO", val.Id_acerto);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_NR_LANCTOCHEQUE", val.Nr_lanctocheque);
            hs.Add("@P_CD_BANCO", val.Cd_banco);

            return this.executarProc("EXCLUI_FRT_ACERTO_X_TITULO", hs);
        }
    }
    #endregion

    #region Acerto X Outras Rec.
    public class TList_Acerto_X_OutrasRec : List<TRegistro_Acerto_X_OutrasRec> { }

    public class TRegistro_Acerto_X_OutrasRec
    {
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
                catch { id_acerto = null; }
            }
        }
        public string Cd_empresa
        { get; set; }
        private decimal? id_receita;
        public decimal? Id_receita
        {
            get { return id_receita; }
            set
            {
                id_receita = value;
                id_receitastr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_receitastr;
        public string Id_receitastr
        {
            get { return id_receitastr; }
            set
            {
                id_receitastr = value;
                try
                {
                    id_receita = decimal.Parse(value);
                }
                catch { id_receita = null; }
            }
        }
        public decimal Vl_devolvido
        { get; set; }

        public TRegistro_Acerto_X_OutrasRec()
        {
            this.id_acerto = null;
            this.id_acertostr = string.Empty;
            this.Cd_empresa = string.Empty;
            this.id_receita = null;
            this.id_receitastr = string.Empty;
            this.Vl_devolvido = decimal.Zero;
        }
    }

    public class TCD_Acerto_X_OutrasRec : TDataQuery
    {
        public TCD_Acerto_X_OutrasRec() { }

        public TCD_Acerto_X_OutrasRec(BancoDados.TObjetoBanco banco) { this.Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
                sql.AppendLine("select " + strTop + " a.id_acerto, a.cd_empresa, a.id_receita, a.vl_devolvido ");
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from TB_FRT_Acerto_X_OutrasRec a ");

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

        public TList_Acerto_X_OutrasRec Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_Acerto_X_OutrasRec lista = new TList_Acerto_X_OutrasRec();
            System.Data.SqlClient.SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);

            try
            {
                reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
                while (reader.Read())
                {
                    TRegistro_Acerto_X_OutrasRec reg = new TRegistro_Acerto_X_OutrasRec();
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Acerto")))
                        reg.Id_acerto = reader.GetDecimal(reader.GetOrdinal("ID_Acerto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("CD_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Receita")))
                        reg.Id_receita = reader.GetDecimal(reader.GetOrdinal("ID_Receita"));
                    if (!reader.IsDBNull(reader.GetOrdinal("VL_Devolvido")))
                        reg.Vl_devolvido = reader.GetDecimal(reader.GetOrdinal("VL_Devolvido"));

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

        public string Gravar(TRegistro_Acerto_X_OutrasRec val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(4);
            hs.Add("@P_ID_ACERTO", val.Id_acerto);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_RECEITA", val.Id_receita);
            hs.Add("@P_VL_DEVOLVIDO", val.Vl_devolvido);

            return this.executarProc("IA_FRT_ACERTO_X_OUTRASREC", hs);
        }

        public string Excluir(TRegistro_Acerto_X_OutrasRec val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(4);
            hs.Add("@P_ID_ACERTO", val.Id_acerto);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_RECEITA", val.Id_receita);

            return this.executarProc("EXCLUI_FRT_ACERTO_X_OUTRASREC", hs);
        }
    }
    #endregion
}
