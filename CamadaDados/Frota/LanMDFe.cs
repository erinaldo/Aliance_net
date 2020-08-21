using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamadaDados.Frota
{
    #region MDFe
    public class TList_MDFe : List<TRegistro_MDFe>, IComparer<TRegistro_MDFe>
    {
        #region IComparer<TRegistro_MDFe> Members
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

        public TList_MDFe()
        { }

        public TList_MDFe(System.ComponentModel.PropertyDescriptor Prop,
                          System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_MDFe value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_MDFe x, TRegistro_MDFe y)
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

    public class TRegistro_MDFe
    {
        public string Cd_empresa
        { get; set; }
        public string Nm_empresa
        { get; set; }
        private decimal? id_mdfe;
        public decimal? Id_mdfe
        {
            get { return id_mdfe; }
            set
            {
                id_mdfe = value;
                id_mdfestr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_mdfestr;
        public string Id_mdfestr
        {
            get { return id_mdfestr; }
            set
            {
                id_mdfestr = value;
                try
                {
                    id_mdfe = decimal.Parse(value);
                }
                catch { id_mdfe = null; }
            }
        }
        public string Nr_serie
        { get; set; }
        public string Ds_serie
        { get; set; }
        public string Cd_modelo
        { get; set; }
        public string Cd_ufcarrega
        { get; set; }
        public string Ds_ufcarrega
        { get; set; }
        public string Sg_ufcarrega
        { get; set; }
        public string Cd_ufdescarrega
        { get; set; }
        public string Ds_ufdescarrega
        { get; set; }
        public string Sg_ufdescarrega
        { get; set; }
        private decimal? nr_mdfe;
        public decimal? Nr_mdfe
        {
            get { return nr_mdfe; }
            set
            {
                nr_mdfe = value;
                nr_mdfestr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string nr_mdfestr;
        public string Nr_mdfestr
        {
            get { return nr_mdfestr; }
            set
            {
                nr_mdfestr = value;
                try
                {
                    nr_mdfe = decimal.Parse(value);
                }
                catch
                { nr_mdfe = null; }
            }
        }
        public string Chaveacesso
        { get; set; }
        private string tp_emitente;
        public string Tp_emitente
        {
            get { return tp_emitente; }
            set
            {
                tp_emitente = value;
                if (value.Trim().Equals("1"))
                    tipo_emitente = "PRESTADOR SERVIÇO";
                else if (value.Trim().Equals("2"))
                    tipo_emitente = "CARGA PROPRIA";
            }
        }
        private string tipo_emitente;
        public string Tipo_emitente
        {
            get { return tipo_emitente; }
            set
            {
                tipo_emitente = value;
                if (value.Trim().ToUpper().Equals("PRESTADOR SERVIÇO"))
                    tp_emitente = "1";
                else if (value.Trim().ToUpper().Equals("CARGA PROPRIA"))
                    tp_emitente = "2";
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
            get { return dt_emissaostr; }
            set
            {
                dt_emissaostr = value;
                try
                {
                    dt_emissao = DateTime.Parse(value);
                }
                catch { dt_emissao = null; }
            }
        }
        private DateTime? dt_iniviagem;
        public DateTime? Dt_iniviagem
        {
            get { return dt_iniviagem; }
            set
            {
                dt_iniviagem = value;
                dt_iniviagemstr = value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty;
            }
        }
        private string dt_iniviagemstr;
        public string Dt_iniviagemstr
        {
            get { return dt_iniviagemstr; }
            set
            {
                dt_iniviagemstr = value;
                try
                {
                    dt_iniviagem = DateTime.Parse(value);
                }
                catch { dt_iniviagem = null; }
            }
        }
        private string tp_modalidade;
        public string Tp_modalidade
        {
            get { return tp_modalidade; }
            set
            {
                tp_modalidade = value;
                if (value.Trim().Equals("1"))
                    tipo_emitente = "RODOVIARIO";
                else if (value.Trim().Equals("2"))
                    tipo_emitente = "AEREO";
                else if (value.Trim().Equals("3"))
                    tipo_emitente = "AQUAVIARIO";
                else if (value.Trim().Equals("4"))
                    tipo_emitente = "FERROVIARIO";
            }
        }
        private string tipo_modalidade;
        public string Tipo_modalidade
        {
            get { return tipo_modalidade; }
            set
            {
                tipo_modalidade = value;
                if (value.Trim().ToUpper().Equals("RODOVIARIO"))
                    tp_modalidade = "1";
                else if (value.Trim().ToUpper().Equals("AEREO"))
                    tp_modalidade = "2";
                else if (value.Trim().ToUpper().Equals("AQUAVIARIO"))
                    tp_modalidade = "3";
                else if (value.Trim().ToUpper().Equals("FERROVIARIO"))
                    tp_modalidade = "4";
            }
        }
        private string tp_transportador;
        public string Tp_transportador
        {
            get { return tp_transportador; }
            set
            {
                tp_transportador = value;
                if (value.Trim().Equals("1"))
                    tipo_transportador = "ETC";
                else if (value.Trim().Equals("2"))
                    tipo_transportador = "TAC";
                else if (value.Trim().Equals("3"))
                    tipo_transportador = "CTC";
            }
        }
        private string tipo_transportador;
        public string Tipo_transportador
        {
            get { return tipo_transportador; }
            set
            {
                tipo_transportador = value;
                if (value.Trim().ToUpper().Equals("ETC"))
                    tp_transportador = "1";
                else if (value.Trim().ToUpper().Equals("TAC"))
                    tp_transportador = "2";
                else if (value.Trim().ToUpper().Equals("CTC"))
                    tp_transportador = "3";
            }
        }
        public string infAdFisco
        { get; set; }
        public string infCpl
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
                else if (value.Trim().ToUpper().Equals("C"))
                    status = "CANCELADO";
                else if (value.Trim().ToUpper().Equals("E"))
                    status = "ENCERRADO";
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
                else if (value.Trim().ToUpper().Equals("CANCELADO"))
                    st_registro = "C";
                else if (value.Trim().ToUpper().Equals("ENCERRADO"))
                    st_registro = "E";
            }
        }
        public string Nr_protocolo
        { get; set; }
        public string St_transmitido
        { get; set; }
        public bool St_transmitidobool
        { get { return St_transmitido.Trim().ToUpper().Equals("S"); } }
        public DateTime? dhRecbto
        { get; set; }
        public string Xml_mdfe
        { get; set; }
        public string Xml_lote
        { get; set; }
        public bool St_processar
        { get; set; }

        public TList_MDFe_Veiculo lVeic
        { get; set; }
        public TList_MDFe_Veiculo lVeicDel
        { get; set; }
        public TList_MDFe_Motorista lMot
        { get; set; }
        public TList_MDFe_Motorista lMotDel
        { get; set; }
        public TList_MDFe_MunCarrega lMunCar
        { get; set; }
        public TList_MDFe_MunCarrega lMunCarDel
        { get; set; }
        public TList_MDFe_UfPercurso lUfPerc
        { get; set; }
        public TList_MDFe_UfPercurso lUfPercDel
        { get; set; }
        public TList_MDFe_Documentos lDoc
        { get; set; }
        public TList_MDFe_Documentos lDocDel
        { get; set; }
        public TList_MDFe_Evento lEventos
        { get; set; }
        public TList_MDFe_Seguro lSeguro { get; set; } = new TList_MDFe_Seguro();
        public TList_MDFe_Seguro lSeguroDel { get; set; } = new TList_MDFe_Seguro();

        public TRegistro_MDFe()
        {
            Cd_empresa = string.Empty;
            Nm_empresa = string.Empty;
            id_mdfe = null;
            id_mdfestr = string.Empty;
            Nr_serie = string.Empty;
            Ds_serie = string.Empty;
            Cd_modelo = string.Empty;
            Cd_ufcarrega = string.Empty;
            Ds_ufcarrega = string.Empty;
            Sg_ufcarrega = string.Empty;
            Cd_ufdescarrega = string.Empty;
            Ds_ufdescarrega = string.Empty;
            Sg_ufdescarrega = string.Empty;
            nr_mdfe = null;
            nr_mdfestr = string.Empty;
            Chaveacesso = string.Empty;
            tp_emitente = string.Empty;
            tipo_emitente = string.Empty;
            dt_emissao = null;
            dt_emissaostr = string.Empty;
            dt_iniviagem = null;
            dt_iniviagemstr = string.Empty;
            tp_modalidade = string.Empty;
            tipo_modalidade = string.Empty;
            tp_transportador = string.Empty;
            tipo_transportador = string.Empty;
            st_registro = "A";
            status = "ATIVO";
            Nr_protocolo = string.Empty;
            St_transmitido = string.Empty;
            dhRecbto = null;
            Xml_mdfe = string.Empty;
            Xml_lote = string.Empty;
            infAdFisco = string.Empty;
            infCpl = string.Empty;
            St_processar = false;

            lVeic = new TList_MDFe_Veiculo();
            lVeicDel = new TList_MDFe_Veiculo();
            lMot = new TList_MDFe_Motorista();
            lMotDel = new TList_MDFe_Motorista();
            lMunCar = new TList_MDFe_MunCarrega();
            lMunCarDel = new TList_MDFe_MunCarrega();
            lUfPerc = new TList_MDFe_UfPercurso();
            lUfPercDel = new TList_MDFe_UfPercurso();
            lDoc = new TList_MDFe_Documentos();
            lDocDel = new TList_MDFe_Documentos();
            lEventos = new TList_MDFe_Evento();
        }
    }

    public class TCD_MDFe : TDataQuery
    {
        public TCD_MDFe() { }

        public TCD_MDFe(BancoDados.TObjetoBanco banco) { Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("select " + strTop + " a.CD_Empresa, b.NM_Empresa, a.ID_MDFe, ");
                sql.AppendLine("a.Nr_Serie, c.DS_SerieNf, a.CD_Modelo, a.CD_UFCarrega, a.dhRecbto, ");
                sql.AppendLine("d.DS_UF as ds_ufcarrega, d.UF as sg_ufcarrega, a.NR_Protocolo, ");
                sql.AppendLine("a.CD_UFDescarrega, e.DS_UF as ds_ufdescarrega, a.st_transmitido, ");
                sql.AppendLine("e.UF as sg_ufdescarrega, a.NR_MDFe, a.ChaveAcesso, a.xml_mdfe, ");
                sql.AppendLine("a.TP_Emitente, a.DT_Emissao, a.DT_IniViagem, a.TP_Modalidade, ");
                sql.AppendLine("a.TP_Transportador, a.xml_lote, a.infAdFisco, a.infCpl, a.ST_Registro ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from VTB_CTR_MDFE a ");
            sql.AppendLine("inner join TB_DIV_Empresa b ");
            sql.AppendLine("on a.CD_Empresa = b.CD_Empresa ");
            sql.AppendLine("inner join TB_FAT_SerieNF c ");
            sql.AppendLine("on a.Nr_Serie = c.Nr_Serie ");
            sql.AppendLine("and a.CD_Modelo = c.CD_Modelo ");
            sql.AppendLine("inner join TB_FIN_UF d ");
            sql.AppendLine("on a.CD_UFCarrega = d.CD_UF ");
            sql.AppendLine("inner join TB_FIN_UF e ");
            sql.AppendLine("on a.CD_UFDescarrega = e.CD_UF ");

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

        public TList_MDFe Select(Utils.TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            TList_MDFe lista = new TList_MDFe();
            System.Data.SqlClient.SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);

            try
            {
                reader = ExecutarBusca(SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
                while (reader.Read())
                {
                    TRegistro_MDFe reg = new TRegistro_MDFe();
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("CD_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_empresa")))
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("nm_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_MDFe")))
                        reg.Id_mdfe = reader.GetDecimal(reader.GetOrdinal("ID_MDFe"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Nr_Serie")))
                        reg.Nr_serie = reader.GetString(reader.GetOrdinal("Nr_Serie"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_SerieNf")))
                        reg.Ds_serie = reader.GetString(reader.GetOrdinal("DS_SerieNf"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Modelo")))
                        reg.Cd_modelo = reader.GetString(reader.GetOrdinal("CD_Modelo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_UFCarrega")))
                        reg.Cd_ufcarrega = reader.GetString(reader.GetOrdinal("CD_UFCarrega"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_ufcarrega")))
                        reg.Ds_ufcarrega = reader.GetString(reader.GetOrdinal("ds_ufcarrega"));
                    if (!reader.IsDBNull(reader.GetOrdinal("sg_ufcarrega")))
                        reg.Sg_ufcarrega = reader.GetString(reader.GetOrdinal("sg_ufcarrega"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_UFDescarrega")))
                        reg.Cd_ufdescarrega = reader.GetString(reader.GetOrdinal("CD_UFDescarrega"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_ufdescarrega")))
                        reg.Ds_ufdescarrega = reader.GetString(reader.GetOrdinal("ds_ufdescarrega"));
                    if (!reader.IsDBNull(reader.GetOrdinal("sg_ufdescarrega")))
                        reg.Sg_ufdescarrega = reader.GetString(reader.GetOrdinal("sg_ufdescarrega"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NR_MDFe")))
                        reg.Nr_mdfe = reader.GetDecimal(reader.GetOrdinal("NR_MDFe"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ChaveAcesso")))
                        reg.Chaveacesso = reader.GetString(reader.GetOrdinal("ChaveAcesso"));
                    if (!reader.IsDBNull(reader.GetOrdinal("TP_Emitente")))
                        reg.Tp_emitente = reader.GetString(reader.GetOrdinal("TP_Emitente"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DT_Emissao")))
                        reg.Dt_emissao = reader.GetDateTime(reader.GetOrdinal("DT_Emissao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DT_IniViagem")))
                        reg.Dt_iniviagem = reader.GetDateTime(reader.GetOrdinal("DT_IniViagem"));
                    if (!reader.IsDBNull(reader.GetOrdinal("TP_Modalidade")))
                        reg.Tp_modalidade = reader.GetString(reader.GetOrdinal("TP_Modalidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("TP_Transportador")))
                        reg.Tp_transportador = reader.GetString(reader.GetOrdinal("TP_Transportador"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ST_Registro")))
                        reg.St_registro = reader.GetString(reader.GetOrdinal("ST_Registro"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NR_Protocolo")))
                        reg.Nr_protocolo = reader.GetString(reader.GetOrdinal("NR_Protocolo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_transmitido")))
                        reg.St_transmitido = reader.GetString(reader.GetOrdinal("st_transmitido"));
                    if (!reader.IsDBNull(reader.GetOrdinal("dhRecbto")))
                        reg.dhRecbto = reader.GetDateTime(reader.GetOrdinal("dhRecbto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("xml_mdfe")))
                        reg.Xml_mdfe = reader.GetString(reader.GetOrdinal("xml_mdfe"));
                    if (!reader.IsDBNull(reader.GetOrdinal("infAdFisco")))
                        reg.infAdFisco = reader.GetString(reader.GetOrdinal("infAdFisco"));
                    if (!reader.IsDBNull(reader.GetOrdinal("infCpl")))
                        reg.infCpl = reader.GetString(reader.GetOrdinal("infCpl"));
                    if (!reader.IsDBNull(reader.GetOrdinal("xml_lote")))
                        reg.Xml_lote = reader.GetString(reader.GetOrdinal("xml_lote"));

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

        public string Gravar(TRegistro_MDFe val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(17);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_MDFE", val.Id_mdfe);
            hs.Add("@P_NR_SERIE", val.Nr_serie);
            hs.Add("@P_CD_MODELO", val.Cd_modelo);
            hs.Add("@P_CD_UFCARREGA", val.Cd_ufcarrega);
            hs.Add("@P_CD_UFDESCARREGA", val.Cd_ufdescarrega);
            hs.Add("@P_NR_MDFE", val.Nr_mdfe);
            hs.Add("@P_CHAVEACESSO", val.Chaveacesso);
            hs.Add("@P_TP_EMITENTE", val.Tp_emitente);
            hs.Add("@P_DT_EMISSAO", val.Dt_emissao);
            hs.Add("@P_DT_INIVIAGEM", val.Dt_iniviagem);
            hs.Add("@P_TP_MODALIDADE", val.Tp_modalidade);
            hs.Add("@P_TP_TRANSPORTADOR", val.Tp_transportador);
            hs.Add("@P_XML_MDFE", val.Xml_mdfe);
            hs.Add("@P_INFADFISCO", val.infAdFisco);
            hs.Add("@P_INFCPL", val.infCpl);
            hs.Add("@P_ST_REGISTRO", val.St_registro);

            return executarProc("IA_CTR_MDFE", hs);
        }

        public string Excluir(TRegistro_MDFe val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(2);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_MDFE", val.Id_mdfe);

            return executarProc("EXCLUI_CTR_MDFE", hs);
        }
    }
    #endregion
    #region MDFe Veiculo
    public class TList_MDFe_Veiculo : List<TRegistro_MDFe_Veiculo>, IComparer<TRegistro_MDFe_Veiculo>
    {
        #region IComparer<TRegistro_MDFe_Veiculo> Members
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

        public TList_MDFe_Veiculo()
        { }

        public TList_MDFe_Veiculo(System.ComponentModel.PropertyDescriptor Prop,
                                  System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_MDFe_Veiculo value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_MDFe_Veiculo x, TRegistro_MDFe_Veiculo y)
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

    public class TRegistro_MDFe_Veiculo
    {
        public string Cd_empresa
        { get; set; }
        public decimal? Id_mdfe
        { get; set; }
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
                    id_veiculo = decimal.Parse(value);
                }
                catch { id_veiculo = null; }
            }
        }
        public string Ds_veiculo
        { get; set; }
        public string Placa
        { get; set; }
        public Cadastros.TRegistro_CadVeiculo rVeic
        { get; set; }

        public TRegistro_MDFe_Veiculo()
        {
            Cd_empresa = string.Empty;
            Id_mdfe = null;
            id_veiculo = null;
            id_veiculostr = string.Empty;
            Ds_veiculo = string.Empty;
            Placa = string.Empty;
            rVeic = new Cadastros.TRegistro_CadVeiculo();
        }
    }

    public class TCD_MDFe_Veiculo : TDataQuery
    {
        public TCD_MDFe_Veiculo() { }

        public TCD_MDFe_Veiculo(BancoDados.TObjetoBanco banco) { Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("select " + strTop + " a.CD_Empresa, a.ID_MDFe, ");
                sql.AppendLine("a.ID_Veiculo, b.DS_Veiculo, b.Placa, b.renavan, ");
                sql.AppendLine("b.ps_tara_kg, b.capacidade_kg, b.capacidade_m3, ");
                sql.AppendLine("c.nm_clifor, b.rntrc_prop, d.insc_estadual, d.uf as uf_prop, b.tp_proprietario, ");
                sql.AppendLine("case when c.tp_pessoa = 'J' then c.nr_cgc else c.nr_cpf end as cnpj_cpf, ");
                sql.AppendLine("b.tp_carroceria, tp.tp_veiculo, tp.tp_rodado, f.uf as uf_veic ");

            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from TB_CTR_MDFe_X_Veiculo a ");
            sql.AppendLine("inner join TB_FRT_Veiculo b ");
            sql.AppendLine("on a.ID_Veiculo = b.ID_Veiculo ");
            sql.AppendLine("inner join TB_DIV_TPVeiculo tp ");
            sql.AppendLine("on b.cd_tpveiculo = tp.cd_tpveiculo ");
            sql.AppendLine("left outer join VTB_FIN_Clifor c ");
            sql.AppendLine("on b.cd_proprietario = c.cd_clifor ");
            sql.AppendLine("left outer join VTB_FIN_Endereco d ");
            sql.AppendLine("on b.cd_proprietario = d.cd_clifor ");
            sql.AppendLine("and b.cd_endproprietario = d.cd_endereco ");
            sql.AppendLine("left outer join TB_FIN_Cidade e ");
            sql.AppendLine("on b.cd_cidade = e.cd_cidade ");
            sql.AppendLine("left outer join TB_FIN_UF f ");
            sql.AppendLine("on e.cd_uf = f.cd_uf ");

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

        public TList_MDFe_Veiculo Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_MDFe_Veiculo lista = new TList_MDFe_Veiculo();
            System.Data.SqlClient.SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);

            try
            {
                reader = ExecutarBusca(SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
                while (reader.Read())
                {
                    TRegistro_MDFe_Veiculo reg = new TRegistro_MDFe_Veiculo();
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("CD_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_MDFe")))
                        reg.Id_mdfe = reader.GetDecimal(reader.GetOrdinal("ID_MDFe"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Veiculo")))
                    {
                        reg.Id_veiculo = reader.GetDecimal(reader.GetOrdinal("ID_Veiculo"));
                        reg.rVeic.Id_veiculo = reader.GetDecimal(reader.GetOrdinal("ID_Veiculo"));
                    }
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Veiculo")))
                    {
                        reg.Ds_veiculo = reader.GetString(reader.GetOrdinal("DS_Veiculo"));
                        reg.rVeic.Ds_veiculo = reader.GetString(reader.GetOrdinal("DS_Veiculo"));
                    }
                    if (!reader.IsDBNull(reader.GetOrdinal("Placa")))
                    {
                        reg.Placa = reader.GetString(reader.GetOrdinal("Placa"));
                        reg.rVeic.placa = reader.GetString(reader.GetOrdinal("Placa"));
                    }
                    if (!reader.IsDBNull(reader.GetOrdinal("renavan")))
                        reg.rVeic.renavan = reader.GetString(reader.GetOrdinal("renavan"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ps_tara_kg")))
                        reg.rVeic.Ps_tara_kg = reader.GetDecimal(reader.GetOrdinal("ps_tara_kg"));
                    if (!reader.IsDBNull(reader.GetOrdinal("capacidade_kg")))
                        reg.rVeic.Capacidade_kg = reader.GetDecimal(reader.GetOrdinal("capacidade_kg"));
                    if (!reader.IsDBNull(reader.GetOrdinal("capacidade_m3")))
                        reg.rVeic.Capacidade_m3 = reader.GetDecimal(reader.GetOrdinal("capacidade_m3"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_clifor")))
                        reg.rVeic.Nm_proprietario = reader.GetString(reader.GetOrdinal("nm_clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("rntrc_prop")))
                        reg.rVeic.Rntrc_prop = reader.GetString(reader.GetOrdinal("rntrc_prop"));
                    if (!reader.IsDBNull(reader.GetOrdinal("insc_estadual")))
                        reg.rVeic.Insc_estadual_prop = reader.GetString(reader.GetOrdinal("insc_estadual"));
                    if (!reader.IsDBNull(reader.GetOrdinal("uf_prop")))
                        reg.rVeic.Uf_proprietario = reader.GetString(reader.GetOrdinal("uf_prop"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_proprietario")))
                        reg.rVeic.Tp_proprietario = reader.GetString(reader.GetOrdinal("tp_proprietario"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cnpj_cpf")))
                        reg.rVeic.Cnpj_cpf_prop = reader.GetString(reader.GetOrdinal("cnpj_cpf"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_carroceria")))
                        reg.rVeic.Tp_carroceria = reader.GetString(reader.GetOrdinal("tp_carroceria"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_veiculo")))
                        reg.rVeic.Tp_veiculo = reader.GetString(reader.GetOrdinal("tp_veiculo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_rodado")))
                        reg.rVeic.Tp_rodado = reader.GetString(reader.GetOrdinal("tp_rodado"));
                    if (!reader.IsDBNull(reader.GetOrdinal("uf_veic")))
                        reg.rVeic.Uf_veiculo = reader.GetString(reader.GetOrdinal("uf_veic"));

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

        public string Gravar(TRegistro_MDFe_Veiculo val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(3);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_MDFE", val.Id_mdfe);
            hs.Add("@P_ID_VEICULO", val.Id_veiculo);

            return executarProc("IA_CTR_MDFE_X_VEICULO", hs);
        }

        public string Excluir(TRegistro_MDFe_Veiculo val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(3);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_MDFE", val.Id_mdfe);
            hs.Add("@P_ID_VEICULO", val.Id_veiculo);

            return executarProc("EXCLUI_CTR_MDFE_X_VEICULO", hs);
        }
    }
    #endregion
    #region MDFe Motorista
    public class TList_MDFe_Motorista : List<TRegistro_MDFe_Motorista>, IComparer<TRegistro_MDFe_Motorista>
    {
        #region IComparer<TRegistro_MDFe_Motorista> Members
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

        public TList_MDFe_Motorista()
        { }

        public TList_MDFe_Motorista(System.ComponentModel.PropertyDescriptor Prop,
                                    System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_MDFe_Motorista value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_MDFe_Motorista x, TRegistro_MDFe_Motorista y)
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

    public class TRegistro_MDFe_Motorista
    {
        public string Cd_empresa
        { get; set; }
        public decimal? Id_mdfe
        { get; set; }
        public string Cd_motorista
        { get; set; }
        public string Nm_motorista
        { get; set; }
        public string Cpf_motorista
        { get; set; }

        public TRegistro_MDFe_Motorista()
        {
            Cd_empresa = string.Empty;
            Id_mdfe = null;
            Cd_motorista = string.Empty;
            Nm_motorista = string.Empty;
            Cpf_motorista = string.Empty;
        }
    }

    public class TCD_MDFe_Motorista : TDataQuery
    {
        public TCD_MDFe_Motorista() { }

        public TCD_MDFe_Motorista(BancoDados.TObjetoBanco banco) { Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("select " + strTop + " a.CD_Empresa, a.ID_MDFe, ");
                sql.AppendLine("a.CD_Motorista, b.NM_Clifor as NM_Motorista, b.NR_CPF as CPF_Motorista ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from TB_CTR_MDFe_X_Motorista a ");
            sql.AppendLine("inner join VTB_FIN_Clifor b ");
            sql.AppendLine("on a.CD_Motorista = b.CD_Clifor ");

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

        public TList_MDFe_Motorista Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_MDFe_Motorista lista = new TList_MDFe_Motorista();
            System.Data.SqlClient.SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);

            try
            {
                reader = ExecutarBusca(SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
                while (reader.Read())
                {
                    TRegistro_MDFe_Motorista reg = new TRegistro_MDFe_Motorista();
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("CD_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_MDFe")))
                        reg.Id_mdfe = reader.GetDecimal(reader.GetOrdinal("ID_MDFe"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Motorista")))
                        reg.Cd_motorista = reader.GetString(reader.GetOrdinal("CD_Motorista"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NM_Motorista")))
                        reg.Nm_motorista = reader.GetString(reader.GetOrdinal("NM_Motorista"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CPF_Motorista")))
                        reg.Cpf_motorista = reader.GetString(reader.GetOrdinal("CPF_Motorista"));

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

        public string Gravar(TRegistro_MDFe_Motorista val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(3);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_MDFE", val.Id_mdfe);
            hs.Add("@P_CD_MOTORISTA", val.Cd_motorista);

            return executarProc("IA_CTR_MDFE_X_MOTORISTA", hs);
        }

        public string Excluir(TRegistro_MDFe_Motorista val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(3);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_MDFE", val.Id_mdfe);
            hs.Add("@P_CD_MOTORISTA", val.Cd_motorista);

            return executarProc("EXCLUI_CTR_MDFE_X_MOTORISTA", hs);
        }
    }
    #endregion
    #region MDFe MunCarrega
    public class TList_MDFe_MunCarrega : List<TRegistro_MDFe_MunCarrega>, IComparer<TRegistro_MDFe_MunCarrega>
    {
        #region IComparer<TRegistro_MDFe_MunCarrega> Members
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

        public TList_MDFe_MunCarrega()
        { }

        public TList_MDFe_MunCarrega(System.ComponentModel.PropertyDescriptor Prop,
                                     System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_MDFe_MunCarrega value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_MDFe_MunCarrega x, TRegistro_MDFe_MunCarrega y)
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

    public class TRegistro_MDFe_MunCarrega
    {
        public string Cd_empresa
        { get; set; }
        public decimal? Id_mdfe
        { get; set; }
        public string Cd_cidade
        { get; set; }
        public string Ds_cidade
        { get; set; }

        public TRegistro_MDFe_MunCarrega()
        {
            Cd_empresa = string.Empty;
            Id_mdfe = null;
            Cd_cidade = string.Empty;
            Ds_cidade = string.Empty;
        }
    }

    public class TCD_MDFe_MunCarrega : TDataQuery
    {
        public TCD_MDFe_MunCarrega() { }

        public TCD_MDFe_MunCarrega(BancoDados.TObjetoBanco banco) { Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("select " + strTop + " a.CD_Empresa, a.ID_MDFe, ");
                sql.AppendLine("a.CD_Cidade, b.DS_Cidade ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from TB_CTR_MDFe_MunCarrega a ");
            sql.AppendLine("inner join TB_FIN_Cidade b ");
            sql.AppendLine("on a.CD_Cidade = b.CD_Cidade ");

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

        public TList_MDFe_MunCarrega Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_MDFe_MunCarrega lista = new TList_MDFe_MunCarrega();
            System.Data.SqlClient.SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);

            try
            {
                reader = ExecutarBusca(SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
                while (reader.Read())
                {
                    TRegistro_MDFe_MunCarrega reg = new TRegistro_MDFe_MunCarrega();
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("CD_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_MDFe")))
                        reg.Id_mdfe = reader.GetDecimal(reader.GetOrdinal("ID_MDFe"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Cidade")))
                        reg.Cd_cidade = reader.GetString(reader.GetOrdinal("CD_Cidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Cidade")))
                        reg.Ds_cidade = reader.GetString(reader.GetOrdinal("DS_Cidade"));

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

        public string Gravar(TRegistro_MDFe_MunCarrega val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(3);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_MDFE", val.Id_mdfe);
            hs.Add("@P_CD_CIDADE", val.Cd_cidade);

            return executarProc("IA_CTR_MDFE_MUNCARREGA", hs);
        }

        public string Excluir(TRegistro_MDFe_MunCarrega val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(3);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_MDFE", val.Id_mdfe);
            hs.Add("@P_CD_CIDADE", val.Cd_cidade);

            return executarProc("EXCLUI_CTR_MDFE_MUNCARREGA", hs);
        }
    }
    #endregion
    #region MDFe UFPercurso
    public class TList_MDFe_UfPercurso : List<TRegistro_MDFe_UfPercurso>, IComparer<TRegistro_MDFe_UfPercurso>
    {
        #region IComparer<TRegistro_MDFe_UfPercurso> Members
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

        public TList_MDFe_UfPercurso()
        { }

        public TList_MDFe_UfPercurso(System.ComponentModel.PropertyDescriptor Prop,
                                     System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_MDFe_UfPercurso value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_MDFe_UfPercurso x, TRegistro_MDFe_UfPercurso y)
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

    public class TRegistro_MDFe_UfPercurso
    {
        public string Cd_empresa
        { get; set; }
        public decimal? Id_mdfe
        { get; set; }
        public string Cd_uf
        { get; set; }
        public string Ds_uf
        { get; set; }
        public string Sg_uf
        { get; set; }
        public decimal Ordem
        { get; set; }

        public TRegistro_MDFe_UfPercurso()
        {
            Cd_empresa = string.Empty;
            Id_mdfe = null;
            Cd_uf = string.Empty;
            Ds_uf = string.Empty;
            Sg_uf = string.Empty;
            Ordem = decimal.Zero;
        }
    }

    public class TCD_MDFe_UfPercurso : TDataQuery
    {
        public TCD_MDFe_UfPercurso() { }

        public TCD_MDFe_UfPercurso(BancoDados.TObjetoBanco banco) { Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("select " + strTop + " a.CD_Empresa, a.ID_MDFe, ");
                sql.AppendLine("a.CD_UF, b.DS_UF, b.UF, a.Ordem ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from TB_CTR_MDFe_UFPercurso a ");
            sql.AppendLine("inner join TB_FIN_UF b ");
            sql.AppendLine("on a.cd_uf = b.cd_uf ");

            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.Append(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                    cond = " and ";
                }
            sql.AppendLine("order by ordem ");
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

        public TList_MDFe_UfPercurso Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_MDFe_UfPercurso lista = new TList_MDFe_UfPercurso();
            System.Data.SqlClient.SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);

            try
            {
                reader = ExecutarBusca(SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
                while (reader.Read())
                {
                    TRegistro_MDFe_UfPercurso reg = new TRegistro_MDFe_UfPercurso();
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("CD_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_MDFe")))
                        reg.Id_mdfe = reader.GetDecimal(reader.GetOrdinal("ID_MDFe"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_UF")))
                        reg.Cd_uf = reader.GetString(reader.GetOrdinal("CD_UF"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_UF")))
                        reg.Ds_uf = reader.GetString(reader.GetOrdinal("DS_UF"));
                    if (!reader.IsDBNull(reader.GetOrdinal("UF")))
                        reg.Sg_uf = reader.GetString(reader.GetOrdinal("UF"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Ordem")))
                        reg.Ordem = reader.GetDecimal(reader.GetOrdinal("Ordem"));

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

        public string Gravar(TRegistro_MDFe_UfPercurso val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(4);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_MDFE", val.Id_mdfe);
            hs.Add("@P_CD_UF", val.Cd_uf);
            hs.Add("@P_ORDEM", val.Ordem);

            return executarProc("IA_CTR_MDFE_UFPERCURSO", hs);
        }

        public string Excluir(TRegistro_MDFe_UfPercurso val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(3);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_MDFE", val.Id_mdfe);
            hs.Add("@P_CD_UF", val.Cd_uf);

            return executarProc("EXCLUI_CTR_MDFE_UFPERCURSO", hs);
        }
    }
    #endregion
    #region MDFe Documentos
    public class TList_MDFe_Documentos : List<TRegistro_MDFe_Documentos>, IComparer<TRegistro_MDFe_Documentos>
    {
        #region IComparer<TRegistro_MDFe_Documentos> Members
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

        public TList_MDFe_Documentos()
        { }

        public TList_MDFe_Documentos(System.ComponentModel.PropertyDescriptor Prop,
                                     System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_MDFe_Documentos value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_MDFe_Documentos x, TRegistro_MDFe_Documentos y)
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

    public class TRegistro_MDFe_Documentos
    {
        public string Cd_empresa
        { get; set; }
        public decimal? Id_mdfe
        { get; set; }
        public decimal? Id_documento
        { get; set; }
        public decimal? Nr_lanctofiscal
        { get; set; }
        public decimal? Nr_notafiscal
        { get; set; }
        public string ChaveNFe
        { get; set; }
        public DateTime? Dt_emissaoNFe
        { get; set; }
        public string Nm_cliforNFe
        { get; set; }
        public string Cd_cidadeNFe
        { get; set; }
        public string Ds_cidadeNFe
        { get; set; }
        public decimal Vl_NFe
        { get; set; }
        public decimal PesoBrutoNFe
        { get; set; }
        public decimal? Nr_lanctoctr
        { get; set; }
        public decimal? Nr_CTe
        { get; set; }
        public string ChaveCTe
        { get; set; }
        public DateTime? Dt_emissaoCTe
        { get; set; }
        public string Nm_remetenteCTe
        { get; set; }
        public string Nm_destinatarioCTe
        { get; set; }
        public string Cd_cidadeCTe
        { get; set; }
        public string Ds_cidadeCTe
        { get; set; }
        public decimal Vl_CargaCTe
        { get; set; }
        public string Cnpj_contratante
        { get; set; }
        public CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento rFat
        { get; set; }
        public CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete rCte
        { get; set; }

        public TRegistro_MDFe_Documentos()
        {
            Cd_empresa = string.Empty;
            Id_mdfe = null;
            Id_documento = null;
            Nr_lanctofiscal = null;
            Nr_notafiscal = null;
            ChaveNFe = string.Empty;
            Dt_emissaoNFe = null;
            Nm_cliforNFe = string.Empty;
            Cd_cidadeNFe = string.Empty;
            Ds_cidadeNFe = string.Empty;
            PesoBrutoNFe = decimal.Zero;
            Nr_lanctoctr = null;
            Nr_CTe = null;
            ChaveCTe = string.Empty;
            Dt_emissaoCTe = null;
            Nm_remetenteCTe = string.Empty;
            Nm_destinatarioCTe = string.Empty;
            Cd_cidadeCTe = string.Empty;
            Ds_cidadeCTe = string.Empty;
            Cnpj_contratante = string.Empty;
            rFat = null;
            rCte = null;
        }
    }

    public class TCD_MDFe_Documentos : TDataQuery
    {
        public TCD_MDFe_Documentos() { }

        public TCD_MDFe_Documentos(BancoDados.TObjetoBanco banco) { Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("select " + strTop + " a.CD_Empresa, a.ID_MDFe, ");
                sql.AppendLine("a.ID_Documento, a.NR_LanctoFiscal, a.NR_LanctoCTR, ");
                sql.AppendLine("b.nr_notafiscal, b.chave_acesso_nfe, b.dt_emissao as dt_emissaoNFe, ");
                sql.AppendLine("c.nm_clifor as nm_cliforNFe, d.nr_ctrc, d.chaveacesso, ");
                sql.AppendLine("d.dt_emissao as dt_emissaoCte, e.nm_clifor as nm_remetenteCTe, ");
                sql.AppendLine("f.nm_clifor as nm_destinatarioCTe,  ");
                sql.AppendLine("case when cmi.st_retorno = 'S' or b.tp_nota = 'T' then endEmitNFe.cd_cidade else endNFe.cd_cidade end as cd_cidadeNFe, ");
                sql.AppendLine("case when cmi.st_retorno = 'S' or b.tp_nota = 'T' then endEmitNFe.ds_cidade else endNFe.ds_cidade end as ds_cidadeNFe,");
                sql.AppendLine("g.cd_cidade as cd_cidadeCTe, ");
                sql.AppendLine("g.ds_cidade as ds_cidadeCTe, b.Vl_totalnota, d.vl_carga, b.PesoBruto, ");
                sql.AppendLine("Cnpj_contratante = case when isnull(b.chave_acesso_nfe, '') <> '' then c.NR_CGC else ");
                sql.AppendLine("					case when d.tp_tomador = '0' then e.NR_CGC else ");
                sql.AppendLine("					case when d.tp_tomador = '1' then ");
                sql.AppendLine("                    (select top 1 x.nr_cgc from VTB_FIN_CLIFOR x ");
                sql.AppendLine("                    where x.CD_Clifor = d.cd_expedidor) else ");
                sql.AppendLine("					case when d.tp_tomador = '2' then ");
                sql.AppendLine("                    (select top 1 x.nr_cgc from VTB_FIN_CLIFOR x ");
                sql.AppendLine("                    where x.CD_Clifor = d.cd_recebedor) else ");
                sql.AppendLine("					case when d.tp_tomador = '3' then f.NR_CGC else ");
                sql.AppendLine("                    (select top 1 x.nr_cgc from VTB_FIN_CLIFOR x ");
                sql.AppendLine("                    where x.CD_Clifor = d.CD_Tomador) end end end end end ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from TB_CTR_MDFe_Documentos a ");
            //NFe
            sql.AppendLine("left outer join VTB_FAT_NotaFiscal b ");
            sql.AppendLine("on a.cd_empresa = b.cd_empresa ");
            sql.AppendLine("and a.nr_lanctofiscal = b.nr_lanctofiscal ");
            sql.AppendLine("left outer join TB_DIV_Empresa emp ");
            sql.AppendLine("on emp.cd_empresa = b.cd_empresa ");
            sql.AppendLine("left outer join VTB_FIN_Clifor c ");
            sql.AppendLine("on b.cd_clifor = c.cd_clifor ");
            sql.AppendLine("left outer join VTB_FIN_Endereco endEmitNFe ");
            sql.AppendLine("on emp.cd_clifor = endEmitNFe.cd_clifor ");
            sql.AppendLine("and emp.CD_Endereco = endEmitNFe.CD_Endereco ");
            sql.AppendLine("left outer join VTB_FIN_Endereco endNFe ");
            sql.AppendLine("on b.cd_clifor = endNFe.cd_clifor ");
            sql.AppendLine("and b.cd_endereco = endNFe.cd_endereco ");
            sql.AppendLine("left outer join TB_FAT_NotaFiscal_CMI cmi ");
            sql.AppendLine("on cmi.cd_empresa = b.cd_empresa ");
            sql.AppendLine("and cmi.nr_lanctofiscal = b.nr_lanctofiscal ");
            //CTe
            sql.AppendLine("left outer join TB_CTR_ConhecimentoFrete d ");
            sql.AppendLine("on a.cd_empresa = d.cd_empresa ");
            sql.AppendLine("and a.nr_lanctoctr = d.nr_lanctoctr ");
            sql.AppendLine("left outer join VTB_FIN_Clifor e ");
            sql.AppendLine("on d.cd_remetente = e.cd_clifor ");
            sql.AppendLine("left outer join VTB_FIN_Clifor f ");
            sql.AppendLine("on d.cd_destinatario = f.cd_clifor ");
            sql.AppendLine("left outer join TB_FIN_Cidade g ");
            sql.AppendLine("on d.cd_cidade_fin = g.cd_cidade ");

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

        public TList_MDFe_Documentos Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_MDFe_Documentos lista = new TList_MDFe_Documentos();
            System.Data.SqlClient.SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);

            try
            {
                reader = ExecutarBusca(SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
                while (reader.Read())
                {
                    TRegistro_MDFe_Documentos reg = new TRegistro_MDFe_Documentos();
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("CD_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_MDFe")))
                        reg.Id_mdfe = reader.GetDecimal(reader.GetOrdinal("ID_MDFe"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Documento")))
                        reg.Id_documento = reader.GetDecimal(reader.GetOrdinal("ID_Documento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NR_LanctoFiscal")))
                        reg.Nr_lanctofiscal = reader.GetDecimal(reader.GetOrdinal("NR_LanctoFiscal"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NR_NotaFiscal")))
                        reg.Nr_notafiscal = reader.GetDecimal(reader.GetOrdinal("NR_NotaFiscal"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Chave_Acesso_NFe")))
                        reg.ChaveNFe = reader.GetString(reader.GetOrdinal("Chave_Acesso_NFe"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Dt_EmissaoNFe")))
                        reg.Dt_emissaoNFe = reader.GetDateTime(reader.GetOrdinal("DT_EmissaoNFe"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NM_CliforNFe")))
                        reg.Nm_cliforNFe = reader.GetString(reader.GetOrdinal("NM_CliforNFe"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_cidadeNFe")))
                        reg.Cd_cidadeNFe = reader.GetString(reader.GetOrdinal("cd_cidadeNFe"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_cidadeNFe")))
                        reg.Ds_cidadeNFe = reader.GetString(reader.GetOrdinal("ds_cidadeNFe"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_totalnota")))
                        reg.Vl_NFe = reader.GetDecimal(reader.GetOrdinal("vl_totalnota"));
                    if (!reader.IsDBNull(reader.GetOrdinal("pesobruto")))
                        reg.PesoBrutoNFe = reader.GetDecimal(reader.GetOrdinal("pesobruto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NR_LanctoCTR")))
                        reg.Nr_lanctoctr = reader.GetDecimal(reader.GetOrdinal("NR_LanctoCTR"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NR_CTRC")))
                        reg.Nr_CTe = reader.GetDecimal(reader.GetOrdinal("NR_CTRC"));
                    if (!reader.IsDBNull(reader.GetOrdinal("chaveacesso")))
                        reg.ChaveCTe = reader.GetString(reader.GetOrdinal("chaveacesso"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DT_EmissaoCTe")))
                        reg.Dt_emissaoCTe = reader.GetDateTime(reader.GetOrdinal("DT_EmissaoCTe"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_remetenteCTe")))
                        reg.Nm_remetenteCTe = reader.GetString(reader.GetOrdinal("nm_remetenteCTe"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_destinatarioCTe")))
                        reg.Nm_destinatarioCTe = reader.GetString(reader.GetOrdinal("nm_destinatarioCTe"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_cidadeCTe")))
                        reg.Cd_cidadeCTe = reader.GetString(reader.GetOrdinal("cd_cidadeCTe"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_cidadeCTe")))
                        reg.Ds_cidadeCTe = reader.GetString(reader.GetOrdinal("ds_cidadeCTe"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_carga")))
                        reg.Vl_CargaCTe = reader.GetDecimal(reader.GetOrdinal("vl_carga"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Cnpj_contratante")))
                        reg.Cnpj_contratante = reader.GetString(reader.GetOrdinal("Cnpj_contratante"));

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

        public string Gravar(TRegistro_MDFe_Documentos val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(5);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_MDFE", val.Id_mdfe);
            hs.Add("@P_ID_DOCUMENTO", val.Id_documento);
            hs.Add("@P_NR_LANCTOFISCAL", val.Nr_lanctofiscal);
            hs.Add("@P_NR_LANCTOCTR", val.Nr_lanctoctr);

            return executarProc("IA_CTR_MDFE_DOCUMENTOS", hs);
        }

        public string Excluir(TRegistro_MDFe_Documentos val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(3);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_MDFE", val.Id_mdfe);
            hs.Add("@P_ID_DOCUMENTO", val.Id_documento);

            return executarProc("EXCLUI_CTR_MDFE_DOCUMENTOS", hs);
        }
    }
    #endregion
    #region MDFe Eventos
    public class TList_MDFe_Evento : List<TRegistro_MDFe_Evento> { }

    public class TRegistro_MDFe_Evento
    {
        public string Cd_empresa
        { get; set; }
        public decimal? Id_mdfe
        { get; set; }
        public decimal? Id_evento
        { get; set; }
        private decimal? cd_evento;
        public decimal? Cd_evento
        {
            get { return cd_evento; }
            set
            {
                cd_evento = value;
                cd_eventostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string cd_eventostr;
        public string Cd_eventostr
        {
            get { return cd_eventostr; }
            set
            {
                cd_eventostr = value;
                try
                {
                    cd_evento = decimal.Parse(value);
                }
                catch { cd_evento = null; }
            }
        }
        public string Ds_evento
        { get; set; }
        public string Tp_evento
        { get; set; }
        public string Tipo_evento
        {
            get
            {
                if (Tp_evento.Trim().ToUpper().Equals("CC"))
                    return "CARTA CORREÇÃO";
                else if (Tp_evento.Trim().ToUpper().Equals("CA"))
                    return "CANCELAMENTO";
                else if (Tp_evento.Trim().ToUpper().Equals("MF"))
                    return "MANIFESTO";
                else if (Tp_evento.Trim().ToUpper().Equals("EC"))
                    return "ENCERRAMENTO";
                else if (Tp_evento.Trim().ToUpper().Equals("IC"))
                    return "INCLUSÃO CONDUTOR";
                else return string.Empty;
            }
        }
        public string Cd_motorista
        { get; set; }
        public string Nm_motorista
        { get; set; }
        public string Cpf_motorista
        { get; set; }
        private DateTime? dt_evento;
        public DateTime? Dt_evento
        {
            get { return dt_evento; }
            set
            {
                dt_evento = value;
                dt_eventostr = value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty;
            }
        }
        private string dt_eventostr;
        public string Dt_eventostr
        {
            get
            {
                try
                {
                    return DateTime.Parse(dt_eventostr).ToString("dd/MM/yyyy");
                }
                catch { return string.Empty; }
            }
            set
            {
                dt_eventostr = value;
                try
                {
                    dt_evento = DateTime.Parse(value);
                }
                catch { dt_evento = null; }
            }
        }
        public string Justificativa
        { get; set; }
        public string Nr_protocolo
        { get; set; }
        public string Xml_evento
        { get; set; }
        public string Xml_retevent
        { get; set; }
        public string St_registro
        { get; set; }
        public string Status
        {
            get
            {
                if (St_registro.Trim().ToUpper().Equals("A"))
                    return "ABERTO";
                else if (St_registro.Trim().ToUpper().Equals("T"))
                    return "TRANSMITIDO";
                else return string.Empty;
            }
        }
        public string Chaveacesso
        { get; set; }
        public string Nr_protocoloMDFe
        { get; set; }
        public string Cd_cidadeEnc
        { get; set; }
        public string Ds_cidadeEnc
        { get; set; }
        public string Cd_ufEnc
        { get; set; }
        public string Uf_enc
        { get; set; }

        public TRegistro_MDFe_Evento()
        {
            Cd_empresa = string.Empty;
            Id_mdfe = null;
            Id_evento = null;
            Cd_evento = null;
            cd_eventostr = string.Empty;
            Ds_evento = string.Empty;
            Tp_evento = string.Empty;
            Cd_motorista = string.Empty;
            Nm_motorista = string.Empty;
            Cpf_motorista = string.Empty;
            dt_evento = null;
            dt_eventostr = string.Empty;
            Justificativa = string.Empty;
            Nr_protocolo = string.Empty;
            Xml_evento = string.Empty;
            Xml_retevent = string.Empty;
            St_registro = "A";
            Chaveacesso = string.Empty;
            Nr_protocoloMDFe = string.Empty;
            Cd_cidadeEnc = string.Empty;
            Ds_cidadeEnc = string.Empty;
            Cd_ufEnc = string.Empty;
            Uf_enc = string.Empty;
        }
    }

    public class TCD_MDFe_Evento : TDataQuery
    {
        public TCD_MDFe_Evento() { }

        public TCD_MDFe_Evento(BancoDados.TObjetoBanco banco) { Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("select " + strTop + " a.CD_Empresa, a.ID_MDFe, ");
                sql.AppendLine("a.ID_Evento, a.CD_Evento, b.DS_Evento, b.TP_Evento, ");
                sql.AppendLine("a.DT_Evento, a.Justificativa, a.NR_Protocolo, ");
                sql.AppendLine("a.XML_Evento, a.XML_RetEvent, a.ST_Registro, ");
                sql.AppendLine("c.chaveacesso, c.nr_protocolo as nr_protocoloMDFe, ");
                sql.AppendLine("a.cd_cidadeenc, d.ds_cidade as ds_cidadeenc, ");
                sql.AppendLine("d.cd_uf as cd_ufenc, e.uf as uf_enc, a.cd_motorista, ");
                sql.AppendLine("f.nm_clifor as nm_motorista, f.nr_cpf as cpf_motorista ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from TB_CTR_MDFe_Evento a ");
            sql.AppendLine("inner join TB_FAT_Evento b ");
            sql.AppendLine("on a.cd_evento = b.cd_evento ");
            sql.AppendLine("inner join VTB_CTR_MDFe c ");
            sql.AppendLine("on a.cd_empresa = c.cd_empresa ");
            sql.AppendLine("and a.id_mdfe = c.id_mdfe ");
            sql.AppendLine("left outer join TB_FIN_Cidade d ");
            sql.AppendLine("on a.cd_cidadeenc = d.cd_cidade ");
            sql.AppendLine("left outer join TB_FIN_UF e ");
            sql.AppendLine("on d.cd_uf = e.cd_uf ");
            sql.AppendLine("left outer join VTB_FIN_Clifor f ");
            sql.AppendLine("on a.cd_motorista = f.cd_clifor ");

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

        public TList_MDFe_Evento Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_MDFe_Evento lista = new TList_MDFe_Evento();
            System.Data.SqlClient.SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);

            try
            {
                reader = ExecutarBusca(SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
                while (reader.Read())
                {
                    TRegistro_MDFe_Evento reg = new TRegistro_MDFe_Evento();
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("CD_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_MDFe")))
                        reg.Id_mdfe = reader.GetDecimal(reader.GetOrdinal("ID_MDFe"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Evento")))
                        reg.Id_evento = reader.GetDecimal(reader.GetOrdinal("ID_Evento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Evento")))
                        reg.Cd_evento = reader.GetDecimal(reader.GetOrdinal("CD_Evento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Evento")))
                        reg.Ds_evento = reader.GetString(reader.GetOrdinal("DS_Evento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("TP_Evento")))
                        reg.Tp_evento = reader.GetString(reader.GetOrdinal("TP_Evento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Motorista")))
                        reg.Cd_motorista = reader.GetString(reader.GetOrdinal("CD_Motorista"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NM_Motorista")))
                        reg.Nm_motorista = reader.GetString(reader.GetOrdinal("NM_Motorista"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CPF_Motorista")))
                        reg.Cpf_motorista = reader.GetString(reader.GetOrdinal("CPF_Motorista"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DT_Evento")))
                        reg.Dt_evento = reader.GetDateTime(reader.GetOrdinal("DT_Evento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Justificativa")))
                        reg.Justificativa = reader.GetString(reader.GetOrdinal("Justificativa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NR_Protocolo")))
                        reg.Nr_protocolo = reader.GetString(reader.GetOrdinal("NR_Protocolo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("XML_Evento")))
                        reg.Xml_evento = reader.GetString(reader.GetOrdinal("XML_Evento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("XML_RetEvent")))
                        reg.Xml_retevent = reader.GetString(reader.GetOrdinal("XML_RetEvent"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ST_Registro")))
                        reg.St_registro = reader.GetString(reader.GetOrdinal("ST_Registro"));
                    if (!reader.IsDBNull(reader.GetOrdinal("chaveacesso")))
                        reg.Chaveacesso = reader.GetString(reader.GetOrdinal("chaveacesso"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_protocoloMDFe")))
                        reg.Nr_protocoloMDFe = reader.GetString(reader.GetOrdinal("nr_protocoloMDFe"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_cidadeenc")))
                        reg.Cd_cidadeEnc = reader.GetString(reader.GetOrdinal("cd_cidadeenc"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_cidadeenc")))
                        reg.Ds_cidadeEnc = reader.GetString(reader.GetOrdinal("ds_cidadeenc"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_ufenc")))
                        reg.Cd_ufEnc = reader.GetString(reader.GetOrdinal("cd_ufenc"));
                    if (!reader.IsDBNull(reader.GetOrdinal("uf_enc")))
                        reg.Uf_enc = reader.GetString(reader.GetOrdinal("uf_enc"));

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

        public string Gravar(TRegistro_MDFe_Evento val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(12);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_MDFE", val.Id_mdfe);
            hs.Add("@P_ID_EVENTO", val.Id_evento);
            hs.Add("@P_CD_EVENTO", val.Cd_evento);
            hs.Add("@P_CD_MOTORISTA", val.Cd_motorista);
            hs.Add("@P_CD_CIDADEENC", val.Cd_cidadeEnc);
            hs.Add("@P_DT_EVENTO", val.Dt_evento);
            hs.Add("@P_JUSTIFICATIVA", val.Justificativa);
            hs.Add("@P_NR_PROTOCOLO", val.Nr_protocolo);
            hs.Add("@P_XML_EVENTO", val.Xml_evento);
            hs.Add("@P_XML_RETEVENT", val.Xml_retevent);
            hs.Add("@P_ST_REGISTRO", val.St_registro);

            return executarProc("IA_CTR_MDFE_EVENTO", hs);
        }

        public string Excluir(TRegistro_MDFe_Evento val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(3);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_MDFE", val.Id_mdfe);
            hs.Add("@P_ID_EVENTO", val.Id_evento);

            return executarProc("EXCLUI_CTR_MDFE_EVENTO", hs);
        }
    }
    #endregion
    #region MDFe Seguro
    public class TList_MDFe_Seguro : List<TRegistro_MDFe_Seguro> { }
    public class TRegistro_MDFe_Seguro
    {
        public string Cd_empresa { get; set; } = string.Empty;
        private decimal? id_mdfe = null;
        public decimal? Id_mdfe
        {
            get { return id_mdfe; }
            set
            {
                id_mdfe = value;
                id_mdfestr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_mdfestr = string.Empty;
        public string Id_mdfestr
        {
            get { return id_mdfestr; }
            set
            {
                id_mdfestr = value;
                try
                {
                    id_mdfe = decimal.Parse(value);
                }catch { id_mdfe = null; }
            }
        }
        private decimal? id_seguro = null;
        public decimal? Id_seguro
        {
            get { return id_seguro; }
            set
            {
                id_seguro = value;
                id_segurostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_segurostr = string.Empty;
        public string Id_segurostr
        {
            get { return id_segurostr; }
            set
            {
                id_segurostr = value;
                try
                {
                    id_seguro = decimal.Parse(value);
                }catch { id_seguro = null; }
            }
        }
        public string Cd_responsavel { get; set; } = string.Empty;
        public string Nm_responsavel { get; set; } = string.Empty;
        public string CnpjCpf_responsavel { get; set; } = string.Empty;
        public string Cd_seguradora { get; set; } = string.Empty;
        public string Nm_seguradora { get; set; } = string.Empty;
        public string Cnpj_seguradora { get; set; } = string.Empty;
        private string tp_responsavel = string.Empty;
        public string Tp_responsavel
        {
            get { return tp_responsavel; }
            set
            {
                tp_responsavel = value;
                if (value.Trim().Equals("1"))
                    tipo_responsavel = "EMITENTE MDF-E";
                else if (value.Trim().Equals("2"))
                    tipo_responsavel = "CONTRATANTE MDF-E";
            }
        }
        private string tipo_responsavel = string.Empty;
        public string Tipo_responsavel
        {
            get { return tipo_responsavel; }
            set
            {
                tipo_responsavel = value;
                if (value.Trim().ToUpper().Equals("EMITENTE MDF-E"))
                    tp_responsavel = "1";
                else if (value.Trim().ToUpper().Equals("CONTRATANTE MDF-E"))
                    tp_responsavel = "2";
            }
        }
        public string Nr_apolice { get; set; } = string.Empty;
        public string Nr_averbacao { get; set; } = string.Empty;
    }
    public class TCD_MDFe_Seguro:TDataQuery
    {
        public TCD_MDFe_Seguro() { }
        public TCD_MDFe_Seguro(BancoDados.TObjetoBanco banco) { Banco_Dados = banco; }
        private string SqlCodeBusca(Utils.TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("select " + strTop + " a.CD_Empresa, a.ID_MDFe, ");
                sql.AppendLine("a.ID_Seguro, a.CD_Responsavel, b.NM_Clifor as NM_Responsavel, ");
                sql.AppendLine("case when b.tp_pessoa = 'J' then b.NR_CGC else b.NR_CPF end as CNPJCPF_Responsavel, ");
                sql.AppendLine("a.CD_Seguradora, c.NM_Clifor as NM_Seguradora, c.NR_CGC as CNPJ_Seguradora, ");
                sql.AppendLine("a.TP_Responsavel, a.NR_Apolice, a.NR_Averbacao ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from TB_CTR_MDFe_Seguro a ");
            sql.AppendLine("left outer join VTB_FIN_Clifor b ");
            sql.AppendLine("on a.CD_Responsavel = b.CD_Clifor ");
            sql.AppendLine("left outer join VTB_FIN_Clifor c ");
            sql.AppendLine("on a.CD_Seguradora = c.CD_Clifor ");

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
        public TList_MDFe_Seguro Select(Utils.TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            TList_MDFe_Seguro lista = new TList_MDFe_Seguro();
            System.Data.SqlClient.SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);

            try
            {
                reader = ExecutarBusca(SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
                while (reader.Read())
                {
                    TRegistro_MDFe_Seguro reg = new TRegistro_MDFe_Seguro();
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("CD_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_MDFe")))
                        reg.Id_mdfe = reader.GetDecimal(reader.GetOrdinal("ID_MDFe"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Seguro")))
                        reg.Id_seguro = reader.GetDecimal(reader.GetOrdinal("ID_Seguro"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Responsavel")))
                        reg.Cd_responsavel = reader.GetString(reader.GetOrdinal("CD_Responsavel"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NM_Responsavel")))
                        reg.Nm_responsavel = reader.GetString(reader.GetOrdinal("NM_Responsavel"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CNPJCPF_Responsavel")))
                        reg.CnpjCpf_responsavel = reader.GetString(reader.GetOrdinal("CNPJCPF_Responsavel"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Seguradora")))
                        reg.Cd_seguradora = reader.GetString(reader.GetOrdinal("CD_Seguradora"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NM_Seguradora")))
                        reg.Nm_seguradora = reader.GetString(reader.GetOrdinal("NM_Seguradora"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CNPJ_Seguradora")))
                        reg.Cnpj_seguradora = reader.GetString(reader.GetOrdinal("CNPJ_Seguradora"));
                    if (!reader.IsDBNull(reader.GetOrdinal("TP_Responsavel")))
                        reg.Tp_responsavel = reader.GetString(reader.GetOrdinal("TP_Responsavel"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NR_Apolice")))
                        reg.Nr_apolice = reader.GetString(reader.GetOrdinal("NR_Apolice"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NR_Averbacao")))
                        reg.Nr_averbacao = reader.GetString(reader.GetOrdinal("NR_Averbacao"));

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

        public string Gravar(TRegistro_MDFe_Seguro val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(8);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_MDFE", val.Id_mdfe);
            hs.Add("@P_ID_SEGURO", val.Id_seguro);
            hs.Add("@P_CD_RESPONSAVEL", val.Cd_responsavel);
            hs.Add("@P_CD_SEGURADORA", val.Cd_seguradora);
            hs.Add("@P_TP_RESPONSAVEL", val.Tp_responsavel);
            hs.Add("@P_NR_APOLICE", val.Nr_apolice);
            hs.Add("@P_NR_AVERBACAO", val.Nr_averbacao);

            return executarProc("IA_CTR_MDFE_SEGURO", hs);
        }

        public string Excluir(TRegistro_MDFe_Seguro val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(3);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_MDFE", val.Id_mdfe);
            hs.Add("@P_ID_SEGURO", val.Id_seguro);

            return executarProc("EXCLUI_CTR_MDFE_SEGURO", hs);
        }
    }
    #endregion
}
