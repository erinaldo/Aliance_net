using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamadaDados.Mudanca
{
    #region Orcamento Web
    public class TList_Orcamento : List<TRegistro_Orcamento>, IComparer<TRegistro_Orcamento>
    {
        #region IComparer<TRegistro_OrcamentoWeb> Members
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

        public TList_Orcamento()
        { }

        public TList_Orcamento(System.ComponentModel.PropertyDescriptor Prop,
                               System.Windows.Forms.SortOrder Dir)
        {
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_Orcamento value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_Orcamento x, TRegistro_Orcamento y)
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

    public class TRegistro_Orcamento
    {
        public string Cd_empresa
        { get; set; }
        public string Nm_empresa
        { get; set; }
        private decimal? id_orcamento;
        public decimal? Id_orcamento
        {
            get { return id_orcamento; }
            set
            {
                id_orcamento = value;
                id_orcamentostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_orcamentostr;
        public string Id_orcamentostr
        {
            get { return id_orcamentostr; }
            set
            {
                id_orcamentostr = value;
                try
                {
                    id_orcamento = decimal.Parse(value);
                }
                catch { id_orcamento = null; }
            }
        }
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
        public string cd_clifor { get; set; }
        private DateTime? dt_orcamento;
        public DateTime? Dt_orcamento
        {
            get { return dt_orcamento; }
            set
            {
                dt_orcamento = value;
                dt_orcamentostr = value.HasValue ? value.Value.ToString("dd/MM/yyyy HH:mm:ss") : string.Empty;
            }
        }
        private string dt_orcamentostr;
        public string Dt_orcamentostr
        {
            get
            {
                try
                {
                    return DateTime.Parse(dt_orcamentostr).ToString("dd/MM/yyyy HH:mm:ss");
                }
                catch { return string.Empty; }
            }
            set
            {
                dt_orcamentostr = value;
                try
                {
                    dt_orcamento = DateTime.Parse(value);
                }
                catch { dt_orcamento = null; }
            }
        }
        public string Nm_cliente
        { get; set; }
        public string NR_CNPJ
        { get; set; }
        public string NR_CPF
        { get; set; }
        public string NR_RG { get; set; }
        public string Empresa
        { get; set; }
        public string Email
        { get; set; }
        public string Fone_comercial
        { get; set; }
        public string Fone_residencial
        { get; set; }
        public string Celular
        { get; set; }
        public string St_guardamoveis
        { get; set; }
        public bool St_guardamoveisbool
        { get { return St_guardamoveis.Trim().ToUpper().Equals("S"); } }
        public decimal Nr_diasguardamoveis
        { get; set; }
        public string Cidade_origem
        { get; set; }
        public string Uf_origem
        { get; set; }
        public string Cep_origem
        { get; set; }
        public string Endereco_origem
        { get; set; }
        public string Numero_origem
        { get; set; }
        public string Bairro_origem
        { get; set; }
        public string Complemento_origem { get; set; }
        public string Cidade_destino
        { get; set; }
        public string Uf_destino
        { get; set; }
        public string Cep_destino
        { get; set; }
        public string Endereco_destino
        { get; set; }
        public string Numero_destino
        { get; set; }
        public string Bairro_destino
        { get; set; }
        public string Complemento_destino { get; set; }
        private DateTime? dt_coleta;
        public DateTime? Dt_coleta
        {
            get { return dt_coleta; }
            set
            {
                dt_coleta = value;
                dt_coletastr = value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty;
            }
        }
        private string dt_coletastr;
        public string Dt_coletastr
        {
            get
            {
                try
                {
                    return DateTime.Parse(dt_coletastr).ToString("dd/MM/yyyy");
                }
                catch { return string.Empty; }
            }
            set
            {
                dt_coletastr = value;
                try
                {
                    dt_coleta = DateTime.Parse(value);
                }
                catch { dt_coleta = null; }
            }
        }
        public string Elevador_coleta
        { get; set; }
        public bool Elevador_coletabool
        { get { return Elevador_coleta.Trim().ToUpper().Equals("S"); } }
        public string Escada_coleta
        { get; set; }
        public bool Escada_coletabool
        { get { return Escada_coleta.Trim().ToUpper().Equals("S"); } }
        private DateTime? dt_entrega;
        public DateTime? Dt_entrega
        {
            get { return dt_entrega; }
            set
            {
                dt_entrega = value;
                dt_entregastr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string dt_entregastr;
        public string Dt_entregastr
        {
            get
            {
                try
                {
                    return DateTime.Parse(dt_entregastr).ToString("dd/MM/yyyy");
                }
                catch { return string.Empty; }
            }
            set
            {
                dt_entregastr = value;
                try
                {
                    dt_entrega = DateTime.Parse(value);
                }
                catch { dt_entrega = null; }
            }
        }
        public string Elevador_entrega
        { get; set; }
        public bool Elevador_entregabool
        { get { return Elevador_entrega.Trim().ToUpper().Equals("S"); } }
        public string Escada_entrega
        { get; set; }
        public bool Escada_entregabool
        { get { return Escada_entrega.Trim().ToUpper().Equals("S"); } }
        public decimal Vl_seguromudanca
        { get; set; }
        public decimal Vl_segurocarro
        { get; set; }
        public decimal Vl_seguromoto
        { get; set; }
        public string Obsseguro
        { get; set; }
        public string Obsencaixotamento
        { get; set; }
        public string Ds_motivoreprovado
        { get; set; }
        public string St_registro
        { get; set; }
        public string Status
        {
            get
            {
                if (St_registro.Trim().Equals("0"))
                    return "ORÇAMENTO";
                else if (St_registro.Trim().Equals("1"))
                    return "APROVADO";
                else if (St_registro.Trim().Equals("2"))
                    return "REPROVADO";
                else return string.Empty;
            }
        }

        public TList_Orcamento_X_Itens lItens
        { get; set; }
        public TList_Orcamento_X_Itens lItensDel
        { get; set; }
        public TList_Encaixotamento lEnc
        { get; set; }
        public TList_Encaixotamento lEncDel
        { get; set; }
        public TList_ServicoOrc lSer
        { get; set; }
        public TList_ServicoOrc lSerDel
        { get; set; }

        public TRegistro_Orcamento()
        {
            Cd_empresa = string.Empty;
            Nm_empresa = string.Empty;
            cd_clifor = string.Empty;
            id_orcamento = null;
            id_orcamentostr = string.Empty;
            id_mudanca = null;
            id_mudancastr = string.Empty;
            dt_orcamento = null;
            dt_orcamentostr = string.Empty;
            Nm_cliente = string.Empty;
            NR_CNPJ = string.Empty;
            NR_CPF = string.Empty;
            NR_RG = string.Empty;
            Empresa = string.Empty;
            Email = string.Empty;
            Fone_comercial = string.Empty;
            Fone_residencial = string.Empty;
            Celular = string.Empty;
            St_guardamoveis = string.Empty;
            Nr_diasguardamoveis = decimal.Zero;
            Cidade_origem = string.Empty;
            Uf_origem = string.Empty;
            Cep_origem = string.Empty;
            Endereco_origem = string.Empty;
            Numero_origem = string.Empty;
            Bairro_origem = string.Empty;
            Complemento_origem = string.Empty;
            Cidade_destino = string.Empty;
            Uf_destino = string.Empty;
            Cep_destino = string.Empty;
            Endereco_destino = string.Empty;
            Numero_destino = string.Empty;
            Bairro_destino = string.Empty;
            Complemento_destino = string.Empty;
            dt_coleta = null;
            dt_coletastr = string.Empty;
            Elevador_coleta = string.Empty;
            Escada_coleta = string.Empty;
            dt_entrega = null;
            Elevador_entrega = string.Empty;
            Escada_entrega = string.Empty;
            Vl_seguromudanca = decimal.Zero;
            Vl_segurocarro = decimal.Zero;
            Vl_seguromoto = decimal.Zero;
            Obsseguro = string.Empty;
            Obsencaixotamento = string.Empty;
            Ds_motivoreprovado = string.Empty;
            St_registro = string.Empty;

            lItens = new TList_Orcamento_X_Itens();
            lItensDel = new TList_Orcamento_X_Itens();
            lEnc = new TList_Encaixotamento();
            lEncDel = new TList_Encaixotamento();
        }
    }

    public class TCD_Orcamento : TDataQuery
    {
        public TCD_Orcamento() { }

        public TCD_Orcamento(BancoDados.TObjetoBanco banco) { Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("select " + strTop + "a.CD_Empresa,a.cd_clifor, b.NM_Empresa, a.ID_Orcamento, a.ID_Mudanca, ");
                sql.AppendLine("a.DT_Orcamento, a.NM_Cliente, a.NR_CNPJ, a.NR_CPF, a.Empresa, a.Email, a.Fone_Comercial, ");
                sql.AppendLine("a.Fone_Residencial, a.Celular, a.ST_GuardaMoveis, a.NR_RG, ");
                sql.AppendLine("a.NR_DiasGuardaMoveis, a.Cidade_Origem, a.UF_Origem, a.CEP_Origem, a.Complemento_Origem, ");
                sql.AppendLine("a.Endereco_Origem, a.Numero_Origem, a.Bairro_Origem, a.Cidade_Destino, a.Complemento_destino, ");
                sql.AppendLine("a.UF_Destino, a.CEP_Destino, a.Endereco_Destino, a.Numero_Destino, a.Bairro_Destino, ");
                sql.AppendLine("a.DT_Coleta, a.Elevador_Coleta, a.Escada_Coleta, ");
                sql.AppendLine("a.DT_Entrega, a.Elevador_Entrega, a.Escada_Entrega, ");
                sql.AppendLine("a.Vl_SeguroMudanca, a.Vl_SeguroCarro, a.Vl_SeguroMoto, ");
                sql.AppendLine("a.ObsSeguro, a.ObsEncaixotamento, a.DS_MotivoReprovado, a.ST_Registro ");
            }
            else
                sql.AppendLine(" Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from TB_MUD_Orcamento a ");
            sql.AppendLine("inner join TB_DIV_Empresa b ");
            sql.AppendLine("on a.CD_Empresa = b.CD_Empresa ");

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
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, string.Empty), null);
        }

        public override System.Data.DataTable Buscar(Utils.TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo), null);
        }

        public override object BuscarEscalar(Utils.TpBusca[] vBusca, string vNM_Campo)
        {
            return ExecutarBuscaEscalar(SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }

        public TList_Orcamento Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNm_Campo)
        {
            TList_Orcamento lista = new TList_Orcamento();
            System.Data.SqlClient.SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            try
            {
                reader = ExecutarBusca(SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNm_Campo));
                while (reader.Read())
                {
                    TRegistro_Orcamento reg = new TRegistro_Orcamento();
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Nm_empresa")))
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("Nm_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Orcamento")))
                        reg.Id_orcamento = reader.GetDecimal(reader.GetOrdinal("ID_Orcamento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Mudanca")))
                        reg.Id_mudanca = reader.GetDecimal(reader.GetOrdinal("ID_Mudanca"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DT_Orcamento")))
                        reg.Dt_orcamento = reader.GetDateTime(reader.GetOrdinal("dt_orcamento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_clifor")))
                        reg.cd_clifor = reader.GetString(reader.GetOrdinal("cd_clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NM_Cliente")))
                        reg.Nm_cliente = reader.GetString(reader.GetOrdinal("NM_Cliente"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NR_CNPJ")))
                        reg.NR_CNPJ = reader.GetString(reader.GetOrdinal("NR_CNPJ"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NR_CPF")))
                        reg.NR_CPF = reader.GetString(reader.GetOrdinal("NR_CPF"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NR_RG")))
                        reg.NR_RG = reader.GetString(reader.GetOrdinal("NR_RG"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Empresa")))
                        reg.Empresa = reader.GetString(reader.GetOrdinal("Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Email")))
                        reg.Email = reader.GetString(reader.GetOrdinal("Email"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Fone_Comercial")))
                        reg.Fone_comercial = reader.GetString(reader.GetOrdinal("Fone_Comercial"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Fone_Residencial")))
                        reg.Fone_residencial = reader.GetString(reader.GetOrdinal("Fone_Residencial"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Celular")))
                        reg.Celular = reader.GetString(reader.GetOrdinal("Celular"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ST_GuardaMoveis")))
                        reg.St_guardamoveis = reader.GetString(reader.GetOrdinal("ST_GuardaMoveis"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NR_DiasGuardaMoveis")))
                        reg.Nr_diasguardamoveis = reader.GetDecimal(reader.GetOrdinal("NR_DiasGuardaMoveis"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Cidade_Origem")))
                        reg.Cidade_origem = reader.GetString(reader.GetOrdinal("Cidade_Origem"));
                    if (!reader.IsDBNull(reader.GetOrdinal("UF_Origem")))
                        reg.Uf_origem = reader.GetString(reader.GetOrdinal("UF_Origem"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CEP_Origem")))
                        reg.Cep_origem = reader.GetString(reader.GetOrdinal("CEP_Origem"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Endereco_Origem")))
                        reg.Endereco_origem = reader.GetString(reader.GetOrdinal("Endereco_Origem"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Numero_Origem")))
                        reg.Numero_origem = reader.GetString(reader.GetOrdinal("Numero_Origem"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Bairro_Origem")))
                        reg.Bairro_origem = reader.GetString(reader.GetOrdinal("Bairro_Origem"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Complemento_Origem")))
                        reg.Complemento_origem = reader.GetString(reader.GetOrdinal("Complemento_Origem"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Cidade_Destino")))
                        reg.Cidade_destino = reader.GetString(reader.GetOrdinal("Cidade_Destino"));
                    if (!reader.IsDBNull(reader.GetOrdinal("UF_Destino")))
                        reg.Uf_destino = reader.GetString(reader.GetOrdinal("UF_Destino"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CEP_Destino")))
                        reg.Cep_destino = reader.GetString(reader.GetOrdinal("CEP_Destino"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Endereco_Destino")))
                        reg.Endereco_destino = reader.GetString(reader.GetOrdinal("Endereco_Destino"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Numero_Destino")))
                        reg.Numero_destino = reader.GetString(reader.GetOrdinal("Numero_Destino"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Bairro_Destino")))
                        reg.Bairro_destino = reader.GetString(reader.GetOrdinal("Bairro_Destino"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Complemento_Destino")))
                        reg.Complemento_destino = reader.GetString(reader.GetOrdinal("Complemento_Destino"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DT_Coleta")))
                        reg.Dt_coleta = reader.GetDateTime(reader.GetOrdinal("DT_Coleta"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Elevador_Coleta")))
                        reg.Elevador_coleta = reader.GetString(reader.GetOrdinal("Elevador_Coleta"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Escada_Coleta")))
                        reg.Escada_coleta = reader.GetString(reader.GetOrdinal("Escada_Coleta"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DT_Entrega")))
                        reg.Dt_entrega = reader.GetDateTime(reader.GetOrdinal("DT_Entrega"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Elevador_Entrega")))
                        reg.Elevador_entrega = reader.GetString(reader.GetOrdinal("Elevador_Entrega"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Escada_Entrega")))
                        reg.Escada_entrega = reader.GetString(reader.GetOrdinal("Escada_Entrega"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_SeguroMudanca")))
                        reg.Vl_seguromudanca = reader.GetDecimal(reader.GetOrdinal("Vl_SeguroMudanca"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_SeguroCarro")))
                        reg.Vl_segurocarro = reader.GetDecimal(reader.GetOrdinal("Vl_SeguroCarro"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_SeguroMoto")))
                        reg.Vl_seguromoto = reader.GetDecimal(reader.GetOrdinal("Vl_SeguroMoto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ObsSeguro")))
                        reg.Obsseguro = reader.GetString(reader.GetOrdinal("ObsSeguro"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ObsEncaixotamento")))
                        reg.Obsencaixotamento = reader.GetString(reader.GetOrdinal("ObsEncaixotamento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_MotivoReprovado")))
                        reg.Ds_motivoreprovado = reader.GetString(reader.GetOrdinal("DS_MotivoReprovado"));
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
                    deletarBanco_Dados();
            }
            return lista;
        }

        public string Gravar(TRegistro_Orcamento val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(43);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_ORCAMENTO", val.Id_orcamento);
            hs.Add("@P_ID_MUDANCA", val.Id_mudanca);
            hs.Add("@P_DT_ORCAMENTO", val.Dt_orcamento);
            hs.Add("@P_CD_CLIENTE", val.cd_clifor);
            hs.Add("@P_NM_CLIENTE", val.Nm_cliente);
            hs.Add("@P_NR_CNPJ", val.NR_CNPJ);
            hs.Add("@P_NR_CPF", val.NR_CPF);
            hs.Add("@P_NR_RG", val.NR_RG);
            hs.Add("@P_EMPRESA", val.Empresa);
            hs.Add("@P_EMAIL", val.Email);
            hs.Add("@P_FONE_COMERCIAL", val.Fone_comercial);
            hs.Add("@P_FONE_RESIDENCIAL", val.Fone_residencial);
            hs.Add("@P_CELULAR", val.Celular);
            hs.Add("@P_ST_GUARDAMOVEIS", val.St_guardamoveis);
            hs.Add("@P_NR_DIASGUARDAMOVEIS", val.Nr_diasguardamoveis);
            hs.Add("@P_CIDADE_ORIGEM", val.Cidade_origem);
            hs.Add("@P_UF_ORIGEM", val.Uf_origem);
            hs.Add("@P_CEP_ORIGEM", val.Cep_origem);
            hs.Add("@P_ENDERECO_ORIGEM", val.Endereco_origem);
            hs.Add("@P_NUMERO_ORIGEM", val.Numero_origem);
            hs.Add("@P_BAIRRO_ORIGEM", val.Bairro_origem);
            hs.Add("@P_COMPLEMENTO_ORIGEM", val.Complemento_origem);
            hs.Add("@P_CIDADE_DESTINO", val.Cidade_destino);
            hs.Add("@P_UF_DESTINO", val.Uf_destino);
            hs.Add("@P_CEP_DESTINO", val.Cep_destino);
            hs.Add("@P_ENDERECO_DESTINO", val.Endereco_destino);
            hs.Add("@P_NUMERO_DESTINO", val.Numero_destino);
            hs.Add("@P_BAIRRO_DESTINO", val.Bairro_destino);
            hs.Add("@P_COMPLEMENTO_DESTINO", val.Complemento_destino);
            hs.Add("@P_DT_COLETA", val.Dt_coleta);
            hs.Add("@P_ELEVADOR_COLETA", val.Elevador_coleta);
            hs.Add("@P_ESCADA_COLETA", val.Escada_coleta);
            hs.Add("@P_DT_ENTREGA", val.Dt_entrega);
            hs.Add("@P_ELEVADOR_ENTREGA", val.Elevador_entrega);
            hs.Add("@P_ESCADA_ENTREGA", val.Escada_entrega);
            hs.Add("@P_VL_SEGUROMUDANCA", val.Vl_seguromudanca);
            hs.Add("@P_VL_SEGUROCARRO", val.Vl_segurocarro);
            hs.Add("@P_VL_SEGUROMOTO", val.Vl_seguromoto);
            hs.Add("@P_OBSSEGURO", val.Obsseguro);
            hs.Add("@P_OBSENCAIXOTAMENTO", val.Obsencaixotamento);
            hs.Add("@P_DS_MOTIVOREPROVADO", val.Ds_motivoreprovado);
            hs.Add("@P_ST_REGISTRO", val.St_registro);

            return executarProc("IA_MUD_ORCAMENTO", hs);
        }

        public string Excluir(TRegistro_Orcamento val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(2);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_ORCAMENTO", val.Id_orcamento);

            return executarProc("EXCLUI_MUD_ORCAMENTO", hs);
        }
    }
    #endregion

    #region Itens Orcamento
    public class TList_Orcamento_X_Itens : List<TRegistro_Orcamento_X_Itens>, IComparer<TRegistro_Orcamento_X_Itens>
    {
        #region IComparer<TRegistro_Orcamento_X_Itens> Members
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

        public TList_Orcamento_X_Itens()
        { }

        public TList_Orcamento_X_Itens(System.ComponentModel.PropertyDescriptor Prop,
                                       System.Windows.Forms.SortOrder Dir)
        {
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_Orcamento_X_Itens value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_Orcamento_X_Itens x, TRegistro_Orcamento_X_Itens y)
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

    public class TRegistro_Orcamento_X_Itens
    {
        public string Cd_empresa
        { get; set; }
        private decimal? id_orcamento;
        public decimal? Id_orcamento
        {
            get { return id_orcamento; }
            set
            {
                id_orcamento = value;
                id_orcamentostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_orcamentostr;
        public string Id_orcamentostr
        {
            get { return id_orcamentostr; }
            set
            {
                id_orcamentostr = value;
                try
                {
                    id_orcamento = decimal.Parse(value);
                }
                catch { id_orcamento = null; }
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
        public string Cd_itemWeb
        { get; set; }
        public string Ds_itemWeb
        { get; set; }
        public decimal Quantidade
        { get; set; }
        public decimal TotalMTCubico
        { get; set; }
        public decimal Vl_TotSeguro
        { get; set; }

        public TRegistro_Orcamento_X_Itens()
        {
            Cd_empresa = string.Empty;
            id_orcamento = null;
            id_orcamentostr = string.Empty;
            id_item = null;
            id_itemstr = string.Empty;
            Ds_item = string.Empty;
            Cd_itemWeb = string.Empty;
            Ds_itemWeb = string.Empty;
            Quantidade = decimal.Zero;
            TotalMTCubico = decimal.Zero;
            Vl_TotSeguro = decimal.Zero;
        }
    }

    public class TCD_Orcamento_X_Itens : TDataQuery
    {
        public TCD_Orcamento_X_Itens() { }

        public TCD_Orcamento_X_Itens(BancoDados.TObjetoBanco banco) { Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("select " + strTop + "a.CD_Empresa, a.ID_Orcamento, a.ID_Item, b.ds_item, ");
                sql.AppendLine("a.CD_ItemWeb, a.DS_ItemWeb, a.Quantidade, a.TotalMTCubico, a.Vl_TotSeguro ");
            }
            else
                sql.AppendLine(" Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from TB_MUD_Orcamento_X_Itens a ");
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
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, string.Empty), null);
        }

        public override System.Data.DataTable Buscar(Utils.TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo), null);
        }

        public override object BuscarEscalar(Utils.TpBusca[] vBusca, string vNM_Campo)
        {
            return ExecutarBuscaEscalar(SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }

        public TList_Orcamento_X_Itens Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNm_Campo)
        {
            TList_Orcamento_X_Itens lista = new TList_Orcamento_X_Itens();
            System.Data.SqlClient.SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            try
            {
                reader = ExecutarBusca(SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNm_Campo));
                while (reader.Read())
                {
                    TRegistro_Orcamento_X_Itens reg = new TRegistro_Orcamento_X_Itens();
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Orcamento")))
                        reg.Id_orcamento = reader.GetDecimal(reader.GetOrdinal("ID_Orcamento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Item")))
                        reg.Id_item = reader.GetDecimal(reader.GetOrdinal("ID_Item"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_item")))
                        reg.Ds_item = reader.GetString(reader.GetOrdinal("ds_item"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_ItemWeb")))
                        reg.Cd_itemWeb = reader.GetString(reader.GetOrdinal("CD_ItemWeb"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_ItemWeb")))
                        reg.Ds_itemWeb = reader.GetString(reader.GetOrdinal("DS_ItemWeb"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Quantidade")))
                        reg.Quantidade = reader.GetDecimal(reader.GetOrdinal("Quantidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("TotalMTCubico")))
                        reg.TotalMTCubico = reader.GetDecimal(reader.GetOrdinal("TotalMTCubico"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_TotSeguro")))
                        reg.Vl_TotSeguro = reader.GetDecimal(reader.GetOrdinal("Vl_TotSeguro"));

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

        public string Gravar(TRegistro_Orcamento_X_Itens val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(8);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_ORCAMENTO", val.Id_orcamento);
            hs.Add("@P_ID_ITEM", val.Id_item);
            hs.Add("@P_CD_ITEMWEB", val.Cd_itemWeb);
            hs.Add("@P_DS_ITEMWEB", val.Ds_itemWeb);
            hs.Add("@P_QUANTIDADE", val.Quantidade);
            hs.Add("@P_TOTALMTCUBICO", val.TotalMTCubico);
            hs.Add("@P_VL_TOTSEGURO", val.Vl_TotSeguro);

            return executarProc("IA_MUD_ORCAMENTO_X_ITENS", hs);
        }

        public string Excluir(TRegistro_Orcamento_X_Itens val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(3);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_ORCAMENTO", val.Id_orcamento);
            hs.Add("@P_ID_ITEM", val.Id_item);

            return executarProc("EXCLUI_MUD_ORCAMENTO_X_ITENS", hs);
        }
    }
    #endregion

    #region Encaixotamento
    public class TList_Encaixotamento : List<TRegistro_Encaixotamento>, IComparer<TRegistro_Encaixotamento>
    {
        #region IComparer<TRegistro_Encaixotamento> Members
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

        public TList_Encaixotamento()
        { }

        public TList_Encaixotamento(System.ComponentModel.PropertyDescriptor Prop,
                                    System.Windows.Forms.SortOrder Dir)
        {
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_Encaixotamento value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_Encaixotamento x, TRegistro_Encaixotamento y)
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

    public class TRegistro_Encaixotamento
    {
        public string Cd_empresa
        { get; set; }
        private decimal? id_orcamento;
        public decimal? Id_orcamento
        {
            get { return id_orcamento; }
            set
            {
                id_orcamento = value;
                id_orcamentostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_orcamentostr;
        public string Id_orcamentostr
        {
            get { return id_orcamentostr; }
            set
            {
                id_orcamentostr = value;
                try
                {
                    id_orcamento = decimal.Parse(value);
                }
                catch { id_orcamento = null; }
            }
        }
        private decimal? id_encaixotamento;
        public decimal? Id_encaixotamento
        {
            get { return id_encaixotamento; }
            set
            {
                id_encaixotamento = value;
                id_encaixotamentostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_encaixotamentostr;
        public string Id_encaixotamentostr
        {
            get { return id_encaixotamentostr; }
            set
            {
                id_encaixotamentostr = value;
                try
                {
                    id_encaixotamento = decimal.Parse(value);
                }
                catch { id_encaixotamento = null; }
            }
        }
        public string Ds_itensencaixotar
        { get; set; }

        public TRegistro_Encaixotamento()
        {
            Cd_empresa = string.Empty;
            id_orcamento = null;
            id_orcamentostr = string.Empty;
            id_encaixotamento = null;
            id_encaixotamentostr = string.Empty;
            Ds_itensencaixotar = string.Empty;
        }
    }

    public class TCD_Encaixotamento : TDataQuery
    {
        public TCD_Encaixotamento() { }

        public TCD_Encaixotamento(BancoDados.TObjetoBanco banco) { Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("select " + strTop + "a.CD_Empresa, a.ID_Orcamento, ");
                sql.AppendLine("a.ID_Encaixotamento, a.DS_ItensEncaixotar ");
            }
            else
                sql.AppendLine(" Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from TB_MUD_Encaixotamento a ");

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
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, string.Empty), null);
        }

        public override System.Data.DataTable Buscar(Utils.TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo), null);
        }

        public override object BuscarEscalar(Utils.TpBusca[] vBusca, string vNM_Campo)
        {
            return ExecutarBuscaEscalar(SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }

        public TList_Encaixotamento Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNm_Campo)
        {
            TList_Encaixotamento lista = new TList_Encaixotamento();
            System.Data.SqlClient.SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            try
            {
                reader = ExecutarBusca(SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNm_Campo));
                while (reader.Read())
                {
                    TRegistro_Encaixotamento reg = new TRegistro_Encaixotamento();
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Orcamento")))
                        reg.Id_orcamento = reader.GetDecimal(reader.GetOrdinal("ID_Orcamento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Encaixotamento")))
                        reg.Id_encaixotamento = reader.GetDecimal(reader.GetOrdinal("ID_Encaixotamento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_ItensEncaixotar")))
                        reg.Ds_itensencaixotar = reader.GetString(reader.GetOrdinal("DS_ItensEncaixotar"));

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

        public string Gravar(TRegistro_Encaixotamento val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(4);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_ORCAMENTO", val.Id_orcamento);
            hs.Add("@P_ID_ENCAIXOTAMENTO", val.Id_encaixotamento);
            hs.Add("@P_DS_ITENSENCAIXOTAR", val.Ds_itensencaixotar);

            return executarProc("IA_MUD_ENCAIXOTAMENTO", hs);
        }

        public string Excluir(TRegistro_Encaixotamento val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(3);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_ORCAMENTO", val.Id_orcamento);
            hs.Add("@P_ID_ENCAIXOTAMENTO", val.Id_encaixotamento);

            return executarProc("EXCLUI_MUD_ENCAIXOTAMENTO", hs);
        }
    }
    #endregion

    #region Servicos
    public class TRegistro_ServicoOrc
    {
        public string Cd_empresa { get; set; }
        private decimal? id_orcamento;

        public decimal? Id_orcamento
        {
            get { return id_orcamento; }
            set
            {
                id_orcamento = value;
                id_orcamentostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_orcamentostr;

        public string Id_orcamentostr
        {
            get { return id_orcamentostr; }
            set
            {
                id_orcamentostr = value;
                try
                {
                    id_orcamento = decimal.Parse(value);
                }
                catch { id_orcamento = null; }
            }
        }
        private decimal? id_servico;

        public decimal? Id_servico
        {
            get { return id_servico; }
            set
            {
                id_servico = value;
                id_servicostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_servicostr;

        public string Id_servicostr
        {
            get { return id_servicostr; }
            set
            {
                id_servicostr = value;
                try
                {
                    id_servico = decimal.Parse(value);
                }
                catch { id_servico = null; }
            }
        }
        public string Ds_servico { get; set; }
        public decimal Vl_servico { get; set; }
        public TRegistro_ServicoOrc()
        {
            Cd_empresa = string.Empty;
            id_orcamento = null;
            id_orcamentostr = string.Empty;
            id_servico = null;
            id_servicostr = string.Empty;
            Ds_servico = string.Empty;
            Vl_servico = decimal.Zero;
        }

    }
    public class TList_ServicoOrc : List<TRegistro_ServicoOrc> { }

    public class TCD_ServicoOrc : TDataQuery
    {
        public TCD_ServicoOrc() { }

        public TCD_ServicoOrc(BancoDados.TObjetoBanco banco) { Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("select " + strTop + "a.CD_Empresa, a.ID_Orcamento, ");
                sql.AppendLine("a.id_servico, b.DS_Servico, a.vl_servico ");
            }
            else
                sql.AppendLine(" Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from TB_MUD_ServicoOrc a ");
            sql.AppendLine("inner join TB_MUD_Servicos b ");
            sql.AppendLine("on a.ID_Servico = b.ID_Servico ");

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
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, string.Empty), null);
        }

        public override System.Data.DataTable Buscar(Utils.TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo), null);
        }

        public override object BuscarEscalar(Utils.TpBusca[] vBusca, string vNM_Campo)
        {
            return ExecutarBuscaEscalar(SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }

        public TList_ServicoOrc Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNm_Campo)
        {
            TList_ServicoOrc lista = new TList_ServicoOrc();
            System.Data.SqlClient.SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            try
            {
                reader = ExecutarBusca(SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNm_Campo));
                while (reader.Read())
                {
                    TRegistro_ServicoOrc reg = new TRegistro_ServicoOrc();
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Orcamento")))
                        reg.Id_orcamento = reader.GetDecimal(reader.GetOrdinal("ID_Orcamento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_servico")))
                        reg.Id_servico = reader.GetDecimal(reader.GetOrdinal("id_servico"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_servico")))
                        reg.Ds_servico = reader.GetString(reader.GetOrdinal("ds_servico"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_servico")))
                        reg.Vl_servico = reader.GetDecimal(reader.GetOrdinal("vl_servico"));

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

        public string Gravar(TRegistro_ServicoOrc val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(4);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_ORCAMENTO", val.Id_orcamento);
            hs.Add("@P_ID_SERVICO", val.Id_servico);
            hs.Add("@P_VL_SERVICO", val.Vl_servico);

            return executarProc("IA_MUD_SERVICOORC", hs);
        }

        public string Excluir(TRegistro_ServicoOrc val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(3);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_ORCAMENTO", val.Id_orcamento);
            hs.Add("@P_ID_SERVICO", val.Id_servico);

            return executarProc("EXCLUI_MUD_SERVICOORC", hs);
        }
    }
    #endregion
}
