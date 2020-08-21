using System;
using System.Collections.Generic;
using System.Text;

namespace CamadaDados.Balanca
{
    #region Prog Desdobro
    public class TList_ItensDesdobro : List<TRegistro_ItensDesdobro>
    { }
    public class TRegistro_ItensDesdobro
    {
        public string Cd_empresa
        { get; set; }
        public string Nm_empresa
        { get; set; }
        private decimal? id_ticket;
        public decimal? Id_ticket
        {
            get { return id_ticket; }
            set
            {
                id_ticket = value;
                id_ticketstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_ticketstr;
        public string Id_ticketstr
        {
            get { return id_ticketstr; }
            set
            {
                id_ticketstr = value;
                try
                {
                    id_ticket = decimal.Parse(value);
                }
                catch { id_ticket = null; }
            }
        }
        public string Tp_pesagem { get; set; }
        public string Nm_tppesagem { get; set; }
        private decimal? id_desdobro;
        public decimal? Id_desdobro
        {
            get { return id_desdobro; }
            set
            {
                id_desdobro = value;
                id_desdobrostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_desdobrostr;
        public string Id_desdobrostr
        {
            get { return id_desdobrostr; }
            set
            {
                id_desdobrostr = value;
                try
                {
                    id_desdobro = decimal.Parse(value);
                }
                catch { id_desdobro = null; }
            }
        }
        public decimal? Nr_contrato_dest
        { get; set; }
        public string Cd_contratante_dest
        { get; set; }
        public string Nm_contratante_dest
        { get; set; }
        public string Nr_notaprodutor
        { get; set; }
        public DateTime? Dt_emissaonfprodutor
        { get; set; }
        public DateTime? Dt_venctonfprodutor
        { get; set; }
        public decimal Qt_nfprodutor
        { get; set; }
        public decimal Vl_nfprodutor
        { get; set; }
        public string Tp_pesodesdobro
        { get; set; }
        public string Tipo_pesodesdobro
        {
            get
            {
                if (Tp_pesodesdobro.Trim().ToUpper().Equals("B"))
                    return "LIQUIDO BALANÇA";
                else if (Tp_pesodesdobro.Trim().ToUpper().Equals("L"))
                    return "PESO LIQUIDO";
                else return string.Empty;
            }
        }
        public decimal Qtd_desdobro
        { get; set; }
        public string Tp_percvalor
        { get; set; }
        public string Tipo_percvalor
        {
            get
            {
                if (Tp_percvalor.Trim().ToUpper().Equals("P"))
                    return "%";
                else if (Tp_percvalor.Trim().ToUpper().Equals("Q"))
                    return "Kg";
                else return string.Empty;
            }
        }

        public TRegistro_ItensDesdobro()
        {
            Cd_empresa = string.Empty;
            Nm_empresa = string.Empty;
            id_ticket = null;
            id_ticketstr = string.Empty;
            Tp_pesagem = string.Empty;
            Nm_tppesagem = string.Empty;
            id_desdobro = null;
            id_desdobrostr = string.Empty;
            Nr_contrato_dest = null;
            Cd_contratante_dest = string.Empty;
            Nm_contratante_dest = string.Empty;
            Nr_notaprodutor = string.Empty;
            Dt_emissaonfprodutor = null;
            Qt_nfprodutor = decimal.Zero;
            Vl_nfprodutor = decimal.Zero;
            Tp_pesodesdobro = string.Empty;
            Qtd_desdobro = decimal.Zero;
            Tp_percvalor = string.Empty;
        }
    }
    public class TCD_ItensDesdobro : TDataQuery
    {
        public TCD_ItensDesdobro() { }

        public TCD_ItensDesdobro(BancoDados.TObjetoBanco banco) { Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();

            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine(" SELECT " + strTop + " a.cd_empresa, emp.nm_empresa, a.id_ticket, a.tp_pesagem, b.NM_TPPesagem, a.id_desdobro,  ");
                sql.AppendLine("a.Nr_contrato, c.cd_clifor, d.nm_clifor, a.nr_notaprodutor, a.DT_EmissaoNFProdutor, ");
                sql.AppendLine("a.DT_VenctoNFProdutor, a.QT_NFProdutor, a.VL_NfProdutor, a.TP_TicketDesdobro, a.TP_Valor, a.Valor ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine(" FROM TB_BAL_ProgDesdobro a ");
            sql.AppendLine("inner join TB_DIV_Empresa emp ");
            sql.AppendLine("on a.cd_empresa = emp.cd_empresa ");
            sql.AppendLine("inner join TB_BAL_TPPesagem  b");
            sql.AppendLine("on b.TP_Pesagem = a.TP_Pesagem ");
            sql.AppendLine("left outer join VTB_GRO_Contrato c ");
            sql.AppendLine("on c.nr_contrato = a.Nr_contrato ");
            sql.AppendLine("left outer join TB_FIN_Clifor d ");
            sql.AppendLine("on d.cd_clifor = c.cd_clifor ");


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

        public TList_ItensDesdobro Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_ItensDesdobro lista = new TList_ItensDesdobro();
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = ExecutarBusca(SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_ItensDesdobro reg = new TRegistro_ItensDesdobro();

                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_empresa")))
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("nm_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_ticket")))
                        reg.Id_ticket = reader.GetDecimal(reader.GetOrdinal("id_ticket"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Tp_pesagem")))
                        reg.Tp_pesagem = reader.GetString(reader.GetOrdinal("Tp_pesagem"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NM_TPPesagem")))
                        reg.Nm_tppesagem = reader.GetString(reader.GetOrdinal("NM_TPPesagem"));                
                    if (!reader.IsDBNull(reader.GetOrdinal("Id_desdobro")))
                        reg.Id_desdobro = reader.GetDecimal(reader.GetOrdinal("Id_desdobro"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Nr_contrato")))
                        reg.Nr_contrato_dest = reader.GetDecimal(reader.GetOrdinal("Nr_contrato"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_clifor")))
                        reg.Cd_contratante_dest = reader.GetString(reader.GetOrdinal("cd_clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_clifor")))
                        reg.Nm_contratante_dest = reader.GetString(reader.GetOrdinal("nm_clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NR_NotaProdutor")))
                        reg.Nr_notaprodutor = reader.GetString(reader.GetOrdinal("NR_NotaProdutor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DT_EmissaoNFProdutor")))
                        reg.Dt_emissaonfprodutor = reader.GetDateTime(reader.GetOrdinal("DT_EmissaoNFProdutor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DT_VenctoNFProdutor")))
                        reg.Dt_venctonfprodutor = reader.GetDateTime(reader.GetOrdinal("DT_VenctoNFProdutor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("QT_NFProdutor")))
                        reg.Qt_nfprodutor = reader.GetDecimal(reader.GetOrdinal("QT_NFProdutor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("VL_NfProdutor")))
                        reg.Vl_nfprodutor = reader.GetDecimal(reader.GetOrdinal("VL_NfProdutor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("TP_TicketDesdobro")))
                        reg.Tp_pesodesdobro = reader.GetString(reader.GetOrdinal("TP_TicketDesdobro"));
                    if (!reader.IsDBNull(reader.GetOrdinal("TP_Valor")))
                        reg.Tp_percvalor = reader.GetString(reader.GetOrdinal("TP_Valor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Valor")))
                        reg.Qtd_desdobro = reader.GetDecimal(reader.GetOrdinal("Valor"));


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

        public string Gravar(TRegistro_ItensDesdobro val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(13);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_TICKET", val.Id_ticket);
            hs.Add("@P_TP_PESAGEM", val.Tp_pesagem);
            hs.Add("@P_ID_DESDOBRO", val.Id_desdobro);
            hs.Add("@P_NR_CONTRATO", val.Nr_contrato_dest);
            hs.Add("@P_NR_NOTAPRODUTOR", val.Nr_notaprodutor);
            hs.Add("@P_DT_EMISSAONFPRODUTOR", val.Dt_emissaonfprodutor);
            hs.Add("@P_DT_VENCTONFPRODUTOR", val.Dt_venctonfprodutor);
            hs.Add("@P_QT_NFPRODUTOR", val.Qt_nfprodutor);
            hs.Add("@P_VL_NFPRODUTOR", val.Vl_nfprodutor);
            hs.Add("@P_TP_TICKETDESDOBRO", val.Tp_pesodesdobro);
            hs.Add("@P_TP_VALOR", val.Tp_percvalor);
            hs.Add("@P_VALOR", val.Qtd_desdobro);

            return executarProc("IA_BAL_PROGDESDOBRO", hs);
        }

        public string Excluir(TRegistro_ItensDesdobro val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(4);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_TICKET", val.Id_ticket);
            hs.Add("@P_TP_PESAGEM", val.Tp_pesagem);
            hs.Add("@P_ID_DESDOBRO", val.Id_desdobro);

            return executarProc("EXCLUI_BAL_PROGDESDOBRO", hs);
        }
    }
    #endregion

    #region Desdobro Pesagem
    public class TList_DesdobroPesagem : List<TRegistro_DesdobroPesagem>
    { }

    public class TRegistro_DesdobroPesagem
    {
        public string Cd_empresa_orig
        { get; set; }
        public string Tp_pesagem_orig
        { get; set; }
        private decimal? id_ticket_orig;
        public decimal? Id_ticket_orig
        {
            get { return id_ticket_orig; }
            set
            {
                id_ticket_orig = value;
                id_ticket_origstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_ticket_origstr;
        public string Id_ticket_origetr
        {
            get { return id_ticket_origstr; }
            set
            {
                id_ticket_origstr = value;
                try
                {
                    id_ticket_orig = decimal.Parse(value);
                }
                catch { id_ticket_orig = null; }
            }
        }
        public string Cd_empresa_dest
        { get; set; }
        public string Tp_pesagem_dest
        { get; set; }
        private decimal? id_ticket_dest;
        public decimal? Id_ticket_dest
        {
            get { return id_ticket_dest; }
            set
            {
                id_ticket_dest = value;
                id_ticket_deststr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_ticket_deststr;
        public string Id_ticket_deststr
        {
            get { return id_ticket_deststr; }
            set
            {
                id_ticket_deststr = value;
                try
                {
                    id_ticket_dest = decimal.Parse(value);
                }
                catch { id_ticket_dest = null; }
            }
        }

        public TRegistro_DesdobroPesagem()
        {
            Cd_empresa_orig = string.Empty;
            Tp_pesagem_orig = string.Empty;
            id_ticket_orig = null;
            id_ticket_origstr = string.Empty;
            Cd_empresa_dest = string.Empty;
            Tp_pesagem_dest = string.Empty;
            id_ticket_dest = null;
            id_ticket_deststr = string.Empty;
        }
    }

    public class TCD_DesdobroPesagem : TDataQuery
    {
        public TCD_DesdobroPesagem() { }

        public TCD_DesdobroPesagem(BancoDados.TObjetoBanco banco) { Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();

            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine(" SELECT " + strTop + " a.cd_empresa_orig, a.tp_pesagem_orig, ");
                sql.AppendLine("a.id_ticket_orig, a.cd_empresa_dest, a.tp_pesagem_dest, a.id_ticket_dest ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine(" FROM TB_BAL_DesdobroPesagem a ");

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

        public TList_DesdobroPesagem Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_DesdobroPesagem lista = new TList_DesdobroPesagem();
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = ExecutarBusca(SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_DesdobroPesagem reg = new TRegistro_DesdobroPesagem();

                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa_orig")))
                        reg.Cd_empresa_orig = reader.GetString(reader.GetOrdinal("cd_empresa_orig"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_pesagem_orig")))
                        reg.Tp_pesagem_orig = reader.GetString(reader.GetOrdinal("tp_pesagem_orig"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_ticket_orig")))
                        reg.Id_ticket_orig = reader.GetDecimal(reader.GetOrdinal("id_ticket_orig"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa_dest")))
                        reg.Cd_empresa_dest = reader.GetString(reader.GetOrdinal("cd_empresa_dest"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_pesagem_dest")))
                        reg.Tp_pesagem_dest = reader.GetString(reader.GetOrdinal("tp_pesagem_dest"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_ticket_dest")))
                        reg.Id_ticket_dest = reader.GetDecimal(reader.GetOrdinal("id_ticket_dest"));

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

        public string Gravar(TRegistro_DesdobroPesagem val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(6);
            hs.Add("@P_CD_EMPRESA_ORIG", val.Cd_empresa_orig);
            hs.Add("@P_TP_PESAGEM_ORIG", val.Tp_pesagem_orig);
            hs.Add("@P_ID_TICKET_ORIG", val.Id_ticket_orig);
            hs.Add("@P_CD_EMPRESA_DEST", val.Cd_empresa_dest);
            hs.Add("@P_TP_PESAGEM_DEST", val.Tp_pesagem_dest);
            hs.Add("@P_ID_TICKET_DEST", val.Id_ticket_dest);

            return executarProc("IA_BAL_DESDOBROPESAGEM", hs);
        }

        public string Excluir(TRegistro_DesdobroPesagem val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(6);
            hs.Add("@P_CD_EMPRESA_ORIG", val.Cd_empresa_orig);
            hs.Add("@P_TP_PESAGEM_ORIG", val.Tp_pesagem_orig);
            hs.Add("@P_ID_TICKET_ORIG", val.Id_ticket_orig);
            hs.Add("@P_CD_EMPRESA_DEST", val.Cd_empresa_dest);
            hs.Add("@P_TP_PESAGEM_DEST", val.Tp_pesagem_dest);
            hs.Add("@P_ID_TICKET_DEST", val.Id_ticket_dest);

            return executarProc("EXCLUI_BAL_DESDOBROPESAGEM", hs);
        }
    }
    #endregion
}
