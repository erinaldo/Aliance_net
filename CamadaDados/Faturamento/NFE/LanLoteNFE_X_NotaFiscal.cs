using System;
using System.Collections.Generic;
using System.Text;
using Utils;

namespace CamadaDados.Faturamento.NFE
{
    public class TList_LanLoteNFE_X_NotaFiscal : List<TRegistro_LanLoteNFE_X_NotaFiscal>
    { }

    public class TRegistro_LanLoteNFE_X_NotaFiscal
    {
        public decimal Id_lote
        { get; set; }
        public string Cd_empresa
        { get; set; }
        public decimal Nr_lanctofiscal
        { get; set; }
        public decimal Nr_notafiscal
        { get; set; }
        public string Nr_serie
        { get; set; }
        public string Cd_clifor
        { get; set; }
        public string Nm_clifor
        { get; set; }
        public decimal Vl_totalnota
        { get; set; }
        private DateTime? dt_processamento;
        public DateTime? Dt_processamento
        {
            get { return dt_processamento; }
            set 
            { 
                dt_processamento = value;
                dt_processamentostring = (value.HasValue ? value.Value.ToString("dd/MM/yyyy HH:mm:ss") : string.Empty);
            }
        }
        private string dt_processamentostring;
        public string Dt_processamentostring
        {
            get 
            {
                try
                {
                    return Convert.ToDateTime(dt_processamentostring).ToString("dd/MM/yyyy HH:mm:ss");
                }
                catch
                { return string.Empty; }
            }
            set 
            { 
                dt_processamentostring = value;
                try
                {
                    dt_processamento = Convert.ToDateTime(value);
                }
                catch
                { dt_processamento = null; }
            }
        }
        public decimal? Nr_protocolo
        { get; set; }
        public string Digitoverificado
        { get; set; }
        public decimal? Status
        { get; set; }
        public string Ds_mensagem
        { get; set; }
        public bool St_contingencia
        { get; set; }
        public string Chave_acesso_nfe
        { get; set; }
        private string st_nfe;
        public string St_nfe
        {
            get { return st_nfe; }
            set
            {
                st_nfe = value;
                if (value.Trim().ToUpper().Equals("A"))
                    status_nfe = "ABERTO";
                else if (value.Trim().ToUpper().Equals("C"))
                    status_nfe = "CANCELADO";
            }
        }
        private string status_nfe;
        public string Status_nfe
        {
            get { return status_nfe; }
            set
            {
                status_nfe = value;
                if (value.Trim().ToUpper().Equals("ABERTO"))
                    st_nfe = "A";
                else if (value.Trim().ToUpper().Equals("CANCELADO"))
                    st_nfe = "C";
            }
        }
        public bool St_transcanc_nfe
        { get; set; }
        public string Veraplic
        { get; set; }
        public DateTime? Dt_procCanc
        { get; set; }
        public decimal? Nr_protocoloCanc
        { get; set; }
        public string Tp_ambiente
        { get; set; }

        public TRegistro_LanLoteNFE_X_NotaFiscal()
        {
            this.Id_lote = 0;
            this.Cd_empresa = string.Empty;
            this.Nr_lanctofiscal = 0;
            this.Nr_notafiscal = 0;
            this.Nr_serie = string.Empty;
            this.Cd_clifor = string.Empty;
            this.Nm_clifor = string.Empty;
            this.Vl_totalnota = decimal.Zero;
            this.dt_processamento = null;
            this.dt_processamentostring = string.Empty;
            this.Nr_protocolo = null;
            this.Digitoverificado = string.Empty;
            this.Status = null;
            this.Ds_mensagem = string.Empty;
            this.St_contingencia = false;
            this.Chave_acesso_nfe = string.Empty;
            this.st_nfe = string.Empty;
            this.status_nfe = string.Empty;
            this.St_transcanc_nfe = false;
            this.Veraplic = string.Empty;
            this.Dt_procCanc = null;
            this.Nr_protocoloCanc = null;
            this.Tp_ambiente = string.Empty;
        }
    }

    public class TCD_LanLoteNFE_X_NotaFiscal : TDataQuery
    {
        public TCD_LanLoteNFE_X_NotaFiscal()
        { }

        public TCD_LanLoteNFE_X_NotaFiscal(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();

            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine(" SELECT " + strTop + " a.ID_Lote, a.CD_Empresa, a.Nr_LanctoFiscal, ");
                sql.AppendLine("a.DT_Processamento, a.Nr_Protocolo, d.tp_ambiente, ");
                sql.AppendLine("a.DigitoVerificado, a.DS_Mensagem, a.Status, ");
                sql.AppendLine("b.nr_notafiscal, b.nr_serie, b.chave_acesso_nfe, ");
                sql.AppendLine("b.st_registro, b.st_transcanc_nfe, a.veraplic, ");
                sql.AppendLine("b.cd_clifor, c.nm_clifor, b.vl_totalnota, ");
                sql.AppendLine("dt_procCanc = (select top 1 x.dt_evento ");
                sql.AppendLine("                from tb_fat_eventonfe x ");
                sql.AppendLine("                inner join tb_fat_evento y ");
                sql.AppendLine("                on x.cd_evento = y.cd_evento ");
                sql.AppendLine("                where x.cd_empresa = a.cd_empresa ");
                sql.AppendLine("                and x.nr_lanctofiscal = a.nr_lanctofiscal ");
                sql.AppendLine("                and y.tp_evento = 'CA'");
                sql.AppendLine("                and isnull(x.st_registro, 'A') = 'T'),");
                sql.AppendLine("nr_protocoloCanc = (select top 1 x.nr_protocolo ");
                sql.AppendLine("                    from tb_fat_eventonfe x ");
                sql.AppendLine("                    inner join tb_fat_evento y ");
                sql.AppendLine("                    on x.cd_evento = y.cd_evento ");
                sql.AppendLine("                    where x.cd_empresa = a.cd_empresa ");
                sql.AppendLine("                    and x.nr_lanctofiscal = a.nr_lanctofiscal ");
                sql.AppendLine("                    and y.tp_evento = 'CA'");
                sql.AppendLine("                    and isnull(x.st_registro, 'A') = 'T')");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from TB_FAT_LoteNFE_X_NotaFiscal a ");
            sql.AppendLine("inner join VTB_FAT_NotaFiscal b ");
            sql.AppendLine("on a.cd_empresa = b.cd_empresa ");
            sql.AppendLine("and a.nr_lanctofiscal = b.nr_lanctofiscal ");
            sql.AppendLine("inner join VTB_FIN_Clifor c ");
            sql.AppendLine("on b.cd_clifor = c.cd_clifor ");
            sql.AppendLine("inner join TB_FAT_LoteNFE d ");
            sql.AppendLine("on a.id_lote = d.id_lote ");

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

        public TList_LanLoteNFE_X_NotaFiscal Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_LanLoteNFE_X_NotaFiscal lista = new TList_LanLoteNFE_X_NotaFiscal();
            System.Data.SqlClient.SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);

            try
            {
                reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
                while (reader.Read())
                {
                    TRegistro_LanLoteNFE_X_NotaFiscal reg = new TRegistro_LanLoteNFE_X_NotaFiscal();
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Lote")))
                        reg.Id_lote = reader.GetDecimal(reader.GetOrdinal("ID_Lote"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("CD_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Nr_LanctoFiscal")))
                        reg.Nr_lanctofiscal = reader.GetDecimal(reader.GetOrdinal("Nr_LanctoFiscal"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NR_NotaFiscal")))
                        reg.Nr_notafiscal = reader.GetDecimal(reader.GetOrdinal("NR_NotaFiscal"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NR_Serie")))
                        reg.Nr_serie = reader.GetString(reader.GetOrdinal("NR_Serie"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DT_Processamento")))
                        reg.Dt_processamento = reader.GetDateTime(reader.GetOrdinal("DT_Processamento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Nr_Protocolo")))
                        reg.Nr_protocolo = reader.GetDecimal(reader.GetOrdinal("Nr_Protocolo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DigitoVerificado")))
                        reg.Digitoverificado = reader.GetString(reader.GetOrdinal("DigitoVerificado"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Mensagem")))
                        reg.Ds_mensagem = reader.GetString(reader.GetOrdinal("DS_Mensagem"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Status")))
                        reg.Status = reader.GetDecimal(reader.GetOrdinal("status"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Chave_Acesso_Nfe")))
                        reg.Chave_acesso_nfe = reader.GetString(reader.GetOrdinal("Chave_Acesso_NFE"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ST_Registro")))
                        reg.St_nfe = reader.GetString(reader.GetOrdinal("ST_Registro"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ST_Transcanc_nfe")))
                        reg.St_transcanc_nfe = reader.GetString(reader.GetOrdinal("ST_TransCanc_nfe")).Trim().ToUpper().Equals("S");
                    if (!reader.IsDBNull(reader.GetOrdinal("veraplic")))
                        reg.Veraplic = reader.GetString(reader.GetOrdinal("veraplic"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_clifor")))
                        reg.Cd_clifor = reader.GetString(reader.GetOrdinal("cd_clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_clifor")))
                        reg.Nm_clifor = reader.GetString(reader.GetOrdinal("nm_clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_totalnota")))
                        reg.Vl_totalnota = reader.GetDecimal(reader.GetOrdinal("vl_totalnota"));
                    if (!reader.IsDBNull(reader.GetOrdinal("dt_proccanc")))
                        reg.Dt_procCanc = reader.GetDateTime(reader.GetOrdinal("dt_proccanc"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_protocolocanc")))
                        reg.Nr_protocoloCanc = reader.GetDecimal(reader.GetOrdinal("nr_protocolocanc"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_ambiente")))
                        reg.Tp_ambiente = reader.GetString(reader.GetOrdinal("tp_ambiente"));

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

        public string Gravar(TRegistro_LanLoteNFE_X_NotaFiscal val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(9);
            hs.Add("@P_ID_LOTE", val.Id_lote);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_NR_LANCTOFISCAL", val.Nr_lanctofiscal);
            hs.Add("@P_DT_PROCESSAMENTO", val.Dt_processamento);
            hs.Add("@P_NR_PROTOCOLO", val.Nr_protocolo);
            hs.Add("@P_DIGITOVERIFICADO", val.Digitoverificado);
            hs.Add("@P_STATUS", val.Status);
            hs.Add("@P_DS_MENSAGEM", val.Ds_mensagem);
            hs.Add("@P_VERAPLIC", val.Veraplic);

            return this.executarProc("IA_FAT_LOTENFE_X_NOTAFISCAL", hs);
        }

        public string Excluir(TRegistro_LanLoteNFE_X_NotaFiscal val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(3);
            hs.Add("@P_ID_LOTE", val.Id_lote);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_NR_LANCTOFISCAL", val.Nr_lanctofiscal);

            return this.executarProc("EXCLUI_FAT_LOTENFE_X_NOTAFISCAL", hs);
        }
    }
}
