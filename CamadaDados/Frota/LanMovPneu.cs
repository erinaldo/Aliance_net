using CamadaDados.Financeiro.Duplicata;
using CamadaDados.Frota.Cadastros;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Utils;

namespace CamadaDados.Frota
{
    public class TList_MovPneu : List<TRegistro_MovPneu>, IComparer<TRegistro_MovPneu>
    {
        #region IComparer<TRegistro_MovPneu> Members
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

        public TList_MovPneu()
        { }

        public TList_MovPneu(System.ComponentModel.PropertyDescriptor Prop,
                                System.Windows.Forms.SortOrder Dir)
        {
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_MovPneu value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_MovPneu x, TRegistro_MovPneu y)
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

    public class TRegistro_MovPneu
    {
        public string Cd_empresa { get; set; } = string.Empty;
        public string Nm_empresa { get; set; } = string.Empty;

        private decimal? id_pneu = null;
        public decimal? Id_pneu
        {
            get { return id_pneu; }
            set
            {
                id_pneu = value;
                id_pneustr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_pneustr = string.Empty;
        public string Id_pneustr
        {
            get { return id_pneustr; }
            set
            {
                id_pneustr = value;
                try
                {
                    id_pneu = decimal.Parse(value);
                }
                catch { id_pneu = null; }
            }
        }

        public string Nr_serie { get; set; } = string.Empty;
        public string Cd_produto { get; set; } = string.Empty;

        private decimal? id_mov = null;
        public decimal? Id_mov
        {
            get { return id_mov; }
            set
            {
                id_mov = value;
                id_movstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_movstr = string.Empty;
        public string Id_movstr
        {
            get { return id_movstr; }
            set
            {
                id_movstr = value;
                try
                {
                    id_mov = decimal.Parse(value);
                }
                catch { id_mov = null; }
            }
        }

        private decimal? id_veiculo = null;
        public decimal? Id_veiculo
        {
            get { return id_veiculo; }
            set
            {
                id_veiculo = value;
                id_veiculostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_veiculostr = string.Empty;
        public string Id_veiculostr
        {
            get { return id_veiculostr; }
            set
            {
                id_veiculostr = value;
                try
                {
                    id_veiculo = Convert.ToDecimal(value);
                }
                catch
                { id_veiculo = null; }
            }
        }
        public string Ds_veiculo { get; set; } = string.Empty;

        public string LocalPneu => !string.IsNullOrEmpty(Ds_veiculo) ? Ds_veiculo : "ALMOXARIFADO";

        public string Placa { get; set; } = string.Empty;

        private decimal? id_rodado = null;
        public decimal? Id_rodado
        {
            get { return id_rodado; }
            set
            {
                id_rodado = value;
                id_rodadostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_rodadostr = string.Empty;
        public string Id_rodadostr
        {
            get { return id_rodadostr; }
            set
            {
                id_rodadostr = value;
                try
                {
                    id_rodado = Convert.ToDecimal(value);
                }
                catch
                { id_rodado = null; }
            }
        }

        public string Ds_rodado { get; set; } = string.Empty;

        private decimal? id_movimento = null;
        public decimal? Id_movimento
        {
            get { return id_movimento; }
            set
            {
                id_movimento = value;
                id_movimentostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_movimentostr = string.Empty;
        public string Id_movimentostr
        {
            get { return id_movimentostr; }
            set
            {
                id_movimentostr = value;
                try
                {
                    id_movimento = Convert.ToDecimal(value);
                }
                catch
                { id_movimento = null; }
            }
        }

        private DateTime? dt_movimento = null;
        public DateTime? Dt_movimento
        {
            get { return dt_movimento; }
            set
            {
                dt_movimento = value;
                dt_movimentostr = value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty;
            }
        }
        private string dt_movimentostr = string.Empty;
        public string Dt_movimentostr
        {
            get
            {
                try
                {
                    return Convert.ToDateTime(dt_movimentostr).ToString("dd/MM/yyyy");
                }
                catch
                { return string.Empty; }
            }
            set
            {
                dt_movimentostr = value;
                try
                {
                    dt_movimento = Convert.ToDateTime(value);
                }
                catch
                { dt_movimento = null; }
            }
        }

        private DateTime? dt_movimentofinal = null;
        public DateTime? Dt_movimentofinal
        {
            get { return dt_movimentofinal; }
            set
            {
                dt_movimentofinal = value;
                dt_movimentofinalstr = value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty;
            }
        }
        private string dt_movimentofinalstr = string.Empty;
        public string Dt_movimentofinalstr
        {
            get
            {
                try
                {
                    return Convert.ToDateTime(dt_movimentofinalstr).ToString("dd/MM/yyyy");
                }
                catch
                { return string.Empty; }
            }
            set
            {
                dt_movimentofinalstr = value;
                try
                {
                    dt_movimentofinal = Convert.ToDateTime(value);
                }
                catch
                { dt_movimentofinal = null; }
            }
        }

        public int HodometroInicial { get; set; } = 0;
        public int HodometroFinal { get; set; } = 0;

        public int KmTotal => HodometroFinal > 0 ? HodometroFinal - HodometroInicial : 0;

        public string NM_recapador { get; set; } = string.Empty;

        private DateTime? dt_preventrega = null;
        public DateTime? Dt_preventrega
        {
            get { return dt_preventrega; }
            set
            {
                dt_preventrega = value;
                dt_preventregastr = value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty;
            }
        }
        private string dt_preventregastr = string.Empty;
        public string Dt_preventregastr
        {
            get
            {
                try
                {
                    return Convert.ToDateTime(dt_preventregastr).ToString("dd/MM/yyyy");
                }
                catch
                { return string.Empty; }
            }
            set
            {
                dt_preventregastr = value;
                try
                {
                    dt_preventrega = Convert.ToDateTime(value);
                }
                catch
                { dt_preventrega = null; }
            }
        }

        public string Nr_OS { get; set; } = string.Empty;
        public string Obs { get; set; } = string.Empty;

        private string tp_movimentacao;
        public string Tp_movimentacao
        {
            get { return tp_movimentacao; }
            set
            {
                tp_movimentacao = value;
                if (value.Trim().Equals("0"))
                    tipo_movimentacao = "RECAP";
                else if (value.Trim().Equals("1"))
                    tipo_movimentacao = "RODIZIO";
                else if (value.Trim().Equals("2"))
                    tipo_movimentacao = "REPARO";
                else if (value.Trim().Equals("3"))
                    tipo_movimentacao = "DESATIVAÇÃO";
            }
        }
        private string tipo_movimentacao;
        public string Tipo_movimentacao
        {
            get { return tipo_movimentacao; }
            set
            {
                tipo_movimentacao = value;
                if (value.Trim().ToUpper().Equals("RECAP"))
                    tp_movimentacao = "0";
                else if (value.Trim().ToUpper().Equals("RODIZIO"))
                    tp_movimentacao = "1";
                else if (value.Trim().ToUpper().Equals("REPARO"))
                    tp_movimentacao = "2";
                else if (value.Trim().ToUpper().Equals("DESATIVAÇÃO"))
                    tp_movimentacao = "3";
            }
        }

        private string tp_recap;
        public string Tp_recap
        {
            get { return tp_recap; }
            set
            {
                tp_recap = value;
                if (value.Trim().Equals("0"))
                    tipo_recap = "LISO";
                else if (value.Trim().Equals("1"))
                    tipo_recap = "BORRACHUDO";
            }
        }
        private string tipo_recap;
        public string Tipo_recap
        {
            get { return tipo_recap; }
            set
            {
                tipo_recap = value;
                if (value.Trim().ToUpper().Equals("LISO"))
                    tp_recap = "0";
                else if (value.Trim().ToUpper().Equals("BORRACHUDO"))
                    tp_recap = "1";
            }
        }

        public decimal? Nr_lancto { get; set; } = null;
        public decimal Valor_OS { get; set; } = decimal.Zero;
        public string St_rodando { get; set; } = string.Empty;

        public decimal? EspessuraBorracha { get; set; } = null;

        private decimal? id_movalmox = null;
        public decimal? Id_movalmox
        {
            get { return id_movalmox; }
            set
            {
                id_movalmox = value;
                id_movalmoxstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_movalmoxstr = string.Empty;
        public string Id_movalmoxstr
        {
            get { return id_movalmoxstr; }
            set
            {
                id_movalmoxstr = value;
                try
                {
                    id_movalmox = Convert.ToDecimal(value);
                }
                catch
                {
                    id_movalmox = null;
                }
            }
        }


        public TRegistro_LanDuplicata rDup = null;
    }
    
    public class TCD_MovPneu : TDataQuery
    {
        public TCD_MovPneu()
        { }

        public TCD_MovPneu(BancoDados.TObjetoBanco banco)
        { Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo, string vOrder)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("select " + strTop + " a.cd_empresa, emp.nm_empresa, a.ID_pneu, pneu.cd_produto, pneu.Nr_serie, a.tp_movimentacao, a.tp_recap, a.Valor_Os, ");
                sql.AppendLine("a.Id_mov, a.id_veiculo, b.ds_veiculo, b.placa, a.Id_rodado, c.Ds_rodado, a.Id_movimento, a.Dt_Movimento, a.Nr_lancto, a.Dt_alt as Dt_movimentofinal, ");
                sql.AppendLine("a.Hodometro, a.HodometroFinal, a.Nm_recapador, a.Dt_preventrega, a.Nr_Os, a.Obs, a.St_rodando, a.espessuraborracha ");
            }
            else
                sql.AppendLine(" Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from TB_FRT_MovPneu a ");
            sql.AppendLine("inner join TB_DIV_Empresa emp ");
            sql.AppendLine("on a.cd_empresa = emp.cd_empresa ");
            sql.AppendLine("inner join TB_FRT_Pneus pneu ");
            sql.AppendLine("on a.cd_empresa = pneu.cd_empresa ");
            sql.AppendLine("and a.id_pneu = pneu.id_pneu ");
            sql.AppendLine("left outer join TB_FRT_Veiculo b ");
            sql.AppendLine("on a.Id_veiculo = b.Id_veiculo ");
            sql.AppendLine("left outer join TB_FRT_Rodado c ");
            sql.AppendLine("on a.id_rodado = c.id_rodado ");

            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                    cond = " and ";
                }

            if (!string.IsNullOrEmpty(vOrder.Trim()))
                sql.AppendLine("order by " + vOrder.Trim());

            return sql.ToString();
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, string.Empty, string.Empty), null);
        }
        public override DataTable Buscar(TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo, string.Empty), null);
        }
        public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
        {
            return ExecutarBuscaEscalar(SqlCodeBusca(vBusca, 1, vNM_Campo, string.Empty), null);
        }

        public object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo, string vOrder)
        {
            return ExecutarBuscaEscalar(SqlCodeBusca(vBusca, 1, vNM_Campo, vOrder), null);
        }

        public TList_MovPneu Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNm_Campo = "", string vOrder = "")
        {
            TList_MovPneu lista = new TList_MovPneu();
            System.Data.SqlClient.SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            try
            {
                reader = ExecutarBusca(SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNm_Campo, vOrder));
                while (reader.Read())
                {
                    TRegistro_MovPneu reg = new TRegistro_MovPneu();
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_empresa")))
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("nm_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_pneu")))
                        reg.Id_pneu = reader.GetDecimal(reader.GetOrdinal("id_pneu"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Cd_produto")))
                        reg.Cd_produto = reader.GetString(reader.GetOrdinal("Cd_produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Nr_serie")))
                        reg.Nr_serie = reader.GetString(reader.GetOrdinal("Nr_serie"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Id_mov")))
                        reg.Id_mov = reader.GetDecimal(reader.GetOrdinal("Id_mov"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Id_veiculo")))
                        reg.Id_veiculo = reader.GetDecimal(reader.GetOrdinal("Id_veiculo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Ds_veiculo")))
                        reg.Ds_veiculo = reader.GetString(reader.GetOrdinal("Ds_veiculo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Placa")))
                        reg.Placa = reader.GetString(reader.GetOrdinal("Placa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Id_rodado")))
                        reg.Id_rodado = reader.GetDecimal(reader.GetOrdinal("Id_rodado"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Ds_rodado")))
                        reg.Ds_rodado = reader.GetString(reader.GetOrdinal("Ds_rodado"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Id_movimento")))
                        reg.Id_movimento = reader.GetDecimal(reader.GetOrdinal("Id_movimento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Dt_movimento")))
                        reg.Dt_movimento = reader.GetDateTime(reader.GetOrdinal("Dt_movimento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Dt_movimentofinal")))
                        reg.Dt_movimentofinal = reader.GetDateTime(reader.GetOrdinal("Dt_movimentofinal"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Tp_movimentacao")))
                        reg.Tp_movimentacao = reader.GetString(reader.GetOrdinal("Tp_movimentacao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Tp_recap")))
                        reg.Tp_recap = reader.GetString(reader.GetOrdinal("Tp_recap"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Hodometro")))
                        reg.HodometroInicial = reader.GetInt32(reader.GetOrdinal("Hodometro"));
                    if (!reader.IsDBNull(reader.GetOrdinal("HodometroFinal")))
                        reg.HodometroFinal = reader.GetInt32(reader.GetOrdinal("HodometroFinal"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NM_recapador")))
                        reg.NM_recapador = reader.GetString(reader.GetOrdinal("NM_recapador"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Dt_preventrega")))
                        reg.Dt_preventrega = reader.GetDateTime(reader.GetOrdinal("Dt_preventrega"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Nr_OS")))
                        reg.Nr_OS = reader.GetString(reader.GetOrdinal("Nr_OS"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Nr_lancto")))
                        reg.Nr_lancto = reader.GetDecimal(reader.GetOrdinal("Nr_lancto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Valor_OS")))
                        reg.Valor_OS = reader.GetDecimal(reader.GetOrdinal("Valor_OS"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Obs")))
                        reg.Obs = reader.GetString(reader.GetOrdinal("Obs"));
                    if (!reader.IsDBNull(reader.GetOrdinal("St_rodando")))
                        reg.St_rodando = reader.GetString(reader.GetOrdinal("St_rodando"));
                    if (!reader.IsDBNull(reader.GetOrdinal("espessuraborracha")))
                        reg.EspessuraBorracha = reader.GetDecimal(reader.GetOrdinal("espessuraborracha"));

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

        public string Gravar(TRegistro_MovPneu val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(19);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_PNEU", val.Id_pneu);
            hs.Add("@P_ID_MOV", val.Id_mov);
            hs.Add("@P_ID_VEICULO", val.Id_veiculo);
            hs.Add("@P_ID_RODADO", val.Id_rodado);
            hs.Add("@P_ID_MOVIMENTO", val.Id_movimento);
            hs.Add("@P_DT_MOVIMENTO", val.Dt_movimento);
            hs.Add("@P_TP_MOVIMENTACAO", val.Tp_movimentacao);
            hs.Add("@P_TP_RECAP", val.Tp_recap);
            hs.Add("@P_HODOMETRO", val.HodometroInicial);
            hs.Add("@P_HODOMETROFINAL", val.HodometroFinal);
            hs.Add("@P_NM_RECAPADOR", val.NM_recapador);
            hs.Add("@P_DT_PREVENTREGA", val.Dt_preventrega);
            hs.Add("@P_NR_OS", val.Nr_OS);
            hs.Add("@P_NR_LANCTO", val.Nr_lancto);
            hs.Add("@P_VALOR_OS", val.Valor_OS);
            hs.Add("@P_OBS", val.Obs);
            hs.Add("@P_ST_RODANDO", val.St_rodando);
            hs.Add("@P_ESPESSURABORRACHA", val.EspessuraBorracha);

            return executarProc("IA_FRT_MOVPNEU", hs);
        }

        public string Excluir(TRegistro_MovPneu val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(3);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_PNEU", val.Id_pneu);
            hs.Add("@P_ID_MOV", val.Id_mov);

            return executarProc("EXCLUI_FRT_MOVPNEU", hs);
        }


    }

}
