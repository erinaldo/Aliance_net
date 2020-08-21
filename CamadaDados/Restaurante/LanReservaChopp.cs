using BancoDados;
using System;
using System.Collections.Generic;
using System.Text;

namespace CamadaDados.Restaurante
{
    #region Reserva Chopp
    public class TList_ReservaChopp:List<TRegistro_ReservaChopp>, IComparer<TRegistro_ReservaChopp>
    {
        #region IComparer<TRegistro_ReservaChopp> Members
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

        public TList_ReservaChopp()
        { }

        public TList_ReservaChopp(System.ComponentModel.PropertyDescriptor Prop,
                                  System.Windows.Forms.SortOrder Dir)
        {
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_ReservaChopp value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_ReservaChopp x, TRegistro_ReservaChopp y)
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

    public class TRegistro_ReservaChopp
    {
        public string Cd_empresa { get; set; } = string.Empty;
        public string Nm_empresa { get; set; } = string.Empty;
        public int? Id_reserva { get; set; } = null;
        public string Cd_clifor { get; set; } = string.Empty;
        public string Nm_clifor { get; set; } = string.Empty;
        public string Celular { get; set; } = string.Empty;
        public string Cd_endereco { get; set; } = string.Empty;
        public string Ds_endereco { get; set; } = string.Empty;
        public string Logradouro_ent { get; set; } = string.Empty;
        public string Numero_ent { get; set; } = string.Empty;
        public string Bairro_ent { get; set; } = string.Empty;
        public string Complemento_ent { get; set; } = string.Empty;
        public string Proximo_ent { get; set; } = string.Empty;
        private DateTime? dt_reserva = null;
        public DateTime? Dt_reserva
        {
            get { return dt_reserva; }
            set
            {
                dt_reserva = value;
                dt_reservastr = value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty;
            }
        }
        private string dt_reservastr = string.Empty;
        public string Dt_reservastr
        {
            get
            {
                try
                {
                    return DateTime.Parse(dt_reservastr).ToString("dd/MM/yyyy");
                }
                catch { return string.Empty; }
            }
            set
            {
                dt_reservastr = value;
                try
                {
                    dt_reserva = DateTime.Parse(value);
                }
                catch { dt_reserva = null; }
            }
        }
        private DateTime? dt_prevretorno = null;
        public DateTime? Dt_prevretorno
        {
            get { return dt_prevretorno; }
            set
            {
                dt_prevretorno = value;
                dt_prevretornostr = value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty;
            }
        }
        private string dt_prevretornostr = string.Empty;
        public string Dt_prevretornostr
        {
            get
            {
                try
                {
                    return DateTime.Parse(dt_prevretornostr).ToString("dd/MM/yyyy");
                }
                catch { return string.Empty; }
            }
            set
            {
                dt_prevretornostr = value;
                try
                {
                    dt_prevretorno = DateTime.Parse(value);
                }
                catch { dt_prevretorno = null;
 }
            }
        }
        public string St_registro { get; set; } = "A";
        public string Status
        {
            get
            {
                if (St_registro.Trim().ToUpper().Equals("A"))
                    return "ABERTO";
                else if (St_registro.Trim().ToUpper().Equals("E"))
                    return "ENCERRADO";
                else if (St_registro.Trim().ToUpper().Equals("C"))
                    return "CANCELADO";
                else return string.Empty;
            }
        }
        public string MotivoCanc { get; set; } = string.Empty;
        public string Obs { get; set; } = string.Empty;
        public string Tp_pagamento { get; set; } = string.Empty;
        public string Tipo_pagamento
        {
            get
            {
                if (Tp_pagamento.Trim().Equals("0"))
                    return "PAGO";
                else if (Tp_pagamento.Trim().Equals("1"))
                    return "NA ENTREGA";
                else if (Tp_pagamento.Trim().Equals("2"))
                    return "NA DEVOLUÇÃO";
                return string.Empty;
            }
        }
        public decimal Vl_reserva { get; set; } = decimal.Zero;
        public bool St_processar { get; set; } = false;

        public List<TRegistro_ItensReserva> Itens { get; set; } = new List<TRegistro_ItensReserva>();
        public TList_Expedicao lExpedicao { get; set; } = new TList_Expedicao();
    }

    public class TCD_ReservaChopp:TDataQuery
    {
        public TCD_ReservaChopp() { }

        public TCD_ReservaChopp(TObjetoBanco banco) { Banco_Dados = banco; }

        public string SqlCodeBusca(Utils.TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            string strtop = string.Empty;
            if (vTop > 0)
                strtop = " top " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("select " + strtop + " a.cd_empresa, b.nm_empresa, ");
                sql.AppendLine("a.id_reserva, a.cd_clifor, c.nm_clifor, c.celular, ");
                sql.AppendLine("a.cd_endereco, c.ds_endereco, a.logradouro_ent, a.obs, ");
                sql.AppendLine("a.numero_ent, a.bairro_ent, a.complemento_ent, a.proximo_ent, ");
                sql.AppendLine("a.dt_reserva, a.dt_prevretorno, a.st_registro, a.motivocanc, a.tp_pagamento, ");
                sql.AppendLine("Vl_reserva = isnull((select sum(isnull(x.vl_liquido, 0)) ");
                sql.AppendLine("                from vtb_res_itensreserva x ");
                sql.AppendLine("                where x.cd_empresa = a.cd_empresa ");
                sql.AppendLine("                and x.id_reserva = a.id_reserva ");
                sql.AppendLine("                and isnull(x.st_registro, '0') <> '5'), 0)");
            }
            else
                sql.AppendLine("Select " + strtop + " " + vNM_Campo);

            sql.AppendLine("from TB_RES_ReservaChopp a ");
            sql.AppendLine("inner join TB_DIV_Empresa b ");
            sql.AppendLine("on a.cd_empresa = b.cd_empresa ");
            sql.AppendLine("inner join VTB_RES_Clifor c ");
            sql.AppendLine("on a.cd_clifor = c.cd_clifor ");
            sql.AppendLine("and a.cd_endereco = c.cd_endereco ");

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

        public TList_ReservaChopp Select(Utils.TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            TList_ReservaChopp lista = new TList_ReservaChopp();
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = ExecutarBusca(SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_ReservaChopp reg = new TRegistro_ReservaChopp();
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_empresa")))
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("nm_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_reserva")))
                        reg.Id_reserva = reader.GetInt32(reader.GetOrdinal("id_reserva"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_clifor")))
                        reg.Cd_clifor = reader.GetString(reader.GetOrdinal("cd_clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_clifor")))
                        reg.Nm_clifor = reader.GetString(reader.GetOrdinal("nm_clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("celular")))
                        reg.Celular = reader.GetString(reader.GetOrdinal("celular"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_endereco")))
                        reg.Cd_endereco = reader.GetString(reader.GetOrdinal("cd_endereco"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_endereco")))
                        reg.Ds_endereco = reader.GetString(reader.GetOrdinal("ds_endereco"));
                    if (!reader.IsDBNull(reader.GetOrdinal("logradouro_ent")))
                        reg.Logradouro_ent = reader.GetString(reader.GetOrdinal("logradouro_ent"));
                    if (!reader.IsDBNull(reader.GetOrdinal("numero_ent")))
                        reg.Numero_ent = reader.GetString(reader.GetOrdinal("numero_ent"));
                    if (!reader.IsDBNull(reader.GetOrdinal("bairro_ent")))
                        reg.Bairro_ent = reader.GetString(reader.GetOrdinal("bairro_ent"));
                    if (!reader.IsDBNull(reader.GetOrdinal("complemento_ent")))
                        reg.Complemento_ent = reader.GetString(reader.GetOrdinal("complemento_ent"));
                    if (!reader.IsDBNull(reader.GetOrdinal("proximo_ent")))
                        reg.Proximo_ent = reader.GetString(reader.GetOrdinal("proximo_ent"));
                    if (!reader.IsDBNull(reader.GetOrdinal("dt_reserva")))
                        reg.Dt_reserva = reader.GetDateTime(reader.GetOrdinal("dt_reserva"));
                    if (!reader.IsDBNull(reader.GetOrdinal("dt_prevretorno")))
                        reg.Dt_prevretorno = reader.GetDateTime(reader.GetOrdinal("dt_prevretorno"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_registro")))
                        reg.St_registro = reader.GetString(reader.GetOrdinal("st_registro"));
                    if (!reader.IsDBNull(reader.GetOrdinal("motivocanc")))
                        reg.MotivoCanc = reader.GetString(reader.GetOrdinal("motivocanc"));
                    if (!reader.IsDBNull(reader.GetOrdinal("obs")))
                        reg.Obs = reader.GetString(reader.GetOrdinal("obs"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_pagamento")))
                        reg.Tp_pagamento = reader.GetString(reader.GetOrdinal("tp_pagamento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_reserva")))
                        reg.Vl_reserva = reader.GetDecimal(reader.GetOrdinal("Vl_reserva"));

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

        public string Gravar(TRegistro_ReservaChopp val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(15);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_RESERVA", val.Id_reserva);
            hs.Add("@P_CD_CLIFOR", val.Cd_clifor);
            hs.Add("@P_CD_ENDERECO", val.Cd_endereco);
            hs.Add("@P_LOGRADOURO_ENT", val.Logradouro_ent);
            hs.Add("@P_NUMERO_ENT", val.Numero_ent);
            hs.Add("@P_BAIRRO_ENT", val.Bairro_ent);
            hs.Add("@P_COMPLEMENTO_ENT", val.Complemento_ent);
            hs.Add("@P_PROXIMO_ENT", val.Proximo_ent);
            hs.Add("@P_DT_RESERVA", val.Dt_reserva);
            hs.Add("@P_DT_PREVRETORNO", val.Dt_prevretorno);
            hs.Add("@P_ST_REGISTRO", val.St_registro);
            hs.Add("@P_MOTIVOCANC", val.MotivoCanc);
            hs.Add("@P_OBS", val.Obs);
            hs.Add("@P_TP_PAGAMENTO", val.Tp_pagamento);

            return executarProc("IA_RES_RESERVACHOPP", hs);
        }

        public string Excluir(TRegistro_ReservaChopp val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(2);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_RESERVA", val.Id_reserva);

            return executarProc("EXCLUI_RES_RESERVACHOPP", hs);
        }
    }
    #endregion

    #region Item Reserva
    public class TList_ItensReserva:List<TRegistro_ItensReserva>, IComparer<TRegistro_ItensReserva>
    {
        #region IComparer<TRegistro_ItensReserva> Members
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

        public TList_ItensReserva()
        { }

        public TList_ItensReserva(System.ComponentModel.PropertyDescriptor Prop,
                                  System.Windows.Forms.SortOrder Dir)
        {
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_ItensReserva value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_ItensReserva x, TRegistro_ItensReserva y)
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

    public class TRegistro_ItensReserva
    {
        public string Cd_empresa { get; set; } = string.Empty;
        public int? Id_reserva { get; set; } = null;
        public int? Id_item { get; set; } = null;
        public string Cd_produto { get; set; } = string.Empty;
        public string Ds_produto { get; set; } = string.Empty;
        public int Quantidade { get; set; } = 0;
        public decimal Vl_unitario { get; set; } = decimal.Zero;
        public decimal Vl_desconto { get; set; } = decimal.Zero;
        public decimal VolumeTotal => decimal.Multiply(Quantidade, Volume);
        public decimal Vl_subtotal => decimal.Multiply(VolumeTotal, Vl_unitario);
        public decimal Vl_liquido => decimal.Subtract(Vl_subtotal, Vl_desconto);
        public string Voltagem { get; set; } = string.Empty;
        public string Voltagemstr
        {
            get
            {
                if (Voltagem.Trim().Equals("0"))
                    return "110";
                else if (Voltagem.Trim().Equals("1"))
                    return "220";
                else return string.Empty;
            }
        }
        public string Qt_torneiras { get; set; } = string.Empty;
        public int Volume { get; set; } = 0;
        public bool St_kitextrator { get; set; } = false;
        public string MotivoCanc { get; set; } = string.Empty;
        public string St_registro { get; set; } = "0";
        public string Status
        {
            get
            {
                if (St_registro.Trim().Equals("0"))
                    return "AGUARDANDO";
                else if (St_registro.Trim().Equals("1"))
                    return "ENTREGUE PARCIAL";
                else if (St_registro.Trim().Equals("2"))
                    return "ENTREGUE";
                else if (St_registro.Trim().Equals("3"))
                    return "DEVOLVIDO PARCIAL";
                else if (St_registro.Trim().Equals("4"))
                    return "DEVOLVIDO";
                else if (St_registro.Trim().ToUpper().Equals("5"))
                    return "CANCELADO";
                else return string.Empty;
            }
        }
        public int Qtd_entregue { get; set; }
        public int Saldo_entregar => Quantidade - Qtd_entregue;
        public int Qtd_devolvida { get; set; }
        public int Saldo_devolver => Qtd_entregue - Qtd_devolvida;

        public TList_Expedicao lExpedicao { get; set; } = new TList_Expedicao();
    }

    public class TCD_ItensReserva:TDataQuery
    {
        public TCD_ItensReserva() { }
        public TCD_ItensReserva(TObjetoBanco banco) { Banco_Dados = banco; }
        public string SqlCodeBusca(Utils.TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            string strtop = string.Empty;
            if (vTop > 0)
                strtop = " top " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("select " + strtop + " a.cd_empresa, a.id_reserva, a.id_item, ");
                sql.AppendLine("a.cd_produto, c.ds_produto, a.quantidade, ");
                sql.AppendLine("a.voltagem, a.vl_unitario, a.st_kitextrator, ");
                sql.AppendLine("a.vl_desconto, a.qt_torneiras, a.volume, a.motivocanc, ");
                sql.AppendLine("a.qtd_entregue, a.qtd_devolvida, a.st_registro ");
            }
            else
                sql.AppendLine("Select " + strtop + " " + vNM_Campo);

            sql.AppendLine("from VTB_RES_ItensReserva a ");
            sql.AppendLine("left outer join TB_EST_Produto c ");
            sql.AppendLine("on a.cd_produto = c.cd_produto ");

            string cond = "where ";
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

        public TList_ItensReserva Select(Utils.TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            TList_ItensReserva lista = new TList_ItensReserva();
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = ExecutarBusca(SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_ItensReserva reg = new TRegistro_ItensReserva();
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_reserva")))
                        reg.Id_reserva = reader.GetInt32(reader.GetOrdinal("id_reserva"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_item")))
                        reg.Id_item = reader.GetInt32(reader.GetOrdinal("id_item"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_produto")))
                        reg.Cd_produto = reader.GetString(reader.GetOrdinal("cd_produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_produto")))
                        reg.Ds_produto = reader.GetString(reader.GetOrdinal("ds_produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("quantidade")))
                        reg.Quantidade = reader.GetInt32(reader.GetOrdinal("quantidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_unitario")))
                        reg.Vl_unitario = reader.GetDecimal(reader.GetOrdinal("vl_unitario"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_desconto")))
                        reg.Vl_desconto = reader.GetDecimal(reader.GetOrdinal("vl_desconto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("voltagem")))
                        reg.Voltagem = reader.GetString(reader.GetOrdinal("voltagem"));
                    if (!reader.IsDBNull(reader.GetOrdinal("voltagem")))
                        reg.Voltagem = reader.GetString(reader.GetOrdinal("voltagem"));
                    if (!reader.IsDBNull(reader.GetOrdinal("qt_torneiras")))
                        reg.Qt_torneiras = reader.GetString(reader.GetOrdinal("qt_torneiras"));
                    if (!reader.IsDBNull(reader.GetOrdinal("volume")))
                        reg.Volume = reader.GetInt32(reader.GetOrdinal("volume"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_kitextrator")))
                        reg.St_kitextrator = reader.GetBoolean(reader.GetOrdinal("st_kitextrator"));
                    if (!reader.IsDBNull(reader.GetOrdinal("motivocanc")))
                        reg.MotivoCanc = reader.GetString(reader.GetOrdinal("motivocanc"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_registro")))
                        reg.St_registro = reader.GetString(reader.GetOrdinal("st_registro"));
                    if (!reader.IsDBNull(reader.GetOrdinal("qtd_entregue")))
                        reg.Qtd_entregue = reader.GetInt32(reader.GetOrdinal("qtd_entregue"));
                    if (!reader.IsDBNull(reader.GetOrdinal("qtd_devolvida")))
                        reg.Qtd_devolvida = reader.GetInt32(reader.GetOrdinal("qtd_devolvida"));

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

        public string Gravar(TRegistro_ItensReserva val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(13);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_RESERVA", val.Id_reserva);
            hs.Add("@P_ID_ITEM", val.Id_item);
            hs.Add("@P_CD_PRODUTO", val.Cd_produto);
            hs.Add("@P_QUANTIDADE", val.Quantidade);
            hs.Add("@P_VL_UNITARIO", val.Vl_unitario);
            hs.Add("@P_VL_DESCONTO", val.Vl_desconto);
            hs.Add("@P_VOLTAGEM", val.Voltagem);
            hs.Add("@P_QT_TORNEIRAS", val.Qt_torneiras);
            hs.Add("@P_VOLUME", val.Volume);
            hs.Add("@P_ST_KITEXTRATOR", val.St_kitextrator);
            hs.Add("@P_MOTIVOCANC", val.MotivoCanc);
            hs.Add("@P_ST_REGISTRO", val.St_registro);

            return executarProc("IA_RES_ITENSRESERVA", hs);
        }

        public string Excluir(TRegistro_ItensReserva val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(3);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_RESERVA", val.Id_reserva);
            hs.Add("@P_ID_ITEM", val.Id_item);

            return executarProc("EXCLUI_RES_ITENSRESERVA", hs);
        }
    }
    #endregion

    #region Reserva X VR
    public class TList_Reserva_X_PreVenda : List<TRegistro_Reserva_X_PreVenda> { }

    public class TRegistro_Reserva_X_PreVenda
    {
        public string Cd_empresa { get; set; } = string.Empty;
        public int Id_reserva { get; set; }
        public int Id_item { get; set; }
        public decimal Id_prevenda { get; set; }
        public decimal Id_itemprevenda { get; set; }
    }

    public class TCD_Reserva_X_PreVenda:TDataQuery
    {
        public TCD_Reserva_X_PreVenda() { }
        
        public TCD_Reserva_X_PreVenda(TObjetoBanco banco) { Banco_Dados = banco; }

        public string SqlCodeBusca(Utils.TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            string strtop = string.Empty;
            if (vTop > 0)
                strtop = " top " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("select " + strtop + " a.cd_empresa, a.id_reserva, ");
                sql.AppendLine("a.id_item, a.id_prevenda, a.id_itemprevenda ");
            }
            else
                sql.AppendLine("Select " + strtop + " " + vNM_Campo);

            sql.AppendLine("from TB_RES_Reserva_X_PreVenda a ");

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

        public TList_Reserva_X_PreVenda Select(Utils.TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            TList_Reserva_X_PreVenda lista = new TList_Reserva_X_PreVenda();
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = ExecutarBusca(SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_Reserva_X_PreVenda reg = new TRegistro_Reserva_X_PreVenda();
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_reserva")))
                        reg.Id_reserva = reader.GetInt32(reader.GetOrdinal("id_reserva"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_item")))
                        reg.Id_item = reader.GetInt32(reader.GetOrdinal("id_item"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_prevenda")))
                        reg.Id_prevenda = reader.GetDecimal(reader.GetOrdinal("id_prevenda"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_itemprevenda")))
                        reg.Id_itemprevenda = reader.GetDecimal(reader.GetOrdinal("id_itemprevenda"));
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

        public string Gravar(TRegistro_Reserva_X_PreVenda val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(5);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_RESERVA", val.Id_reserva);
            hs.Add("@P_ID_ITEM", val.Id_item);
            hs.Add("@P_ID_PREVENDA", val.Id_prevenda);
            hs.Add("@P_ID_ITEMPREVENDA", val.Id_itemprevenda);

            return executarProc("IA_RES_RESERVA_X_PREVENDA", hs);
        }

        public string Excluir(TRegistro_Reserva_X_PreVenda val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(5);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_RESERVA", val.Id_reserva);
            hs.Add("@P_ID_ITEM", val.Id_item);
            hs.Add("@P_ID_PREVENDA", val.Id_prevenda);
            hs.Add("@P_ID_ITEMPREVENDA", val.Id_itemprevenda);

            return executarProc("EXCLUI_RES_RESERVA_X_PREVENDA", hs);
        }
    }
    #endregion

    #region Expedicao
    public class TList_Expedicao : List<TRegistro_Expedicao> { }

    public class TRegistro_Expedicao
    {
        public string Cd_empresa { get; set; } = string.Empty;
        public int Id_reserva { get; set; }
        public int Id_item { get; set; }
        public int? Id_expedicao { get; set; } = null;
        public string LoginRetCheio { get; set; } = string.Empty;
        public int? Id_barril { get; set; } = null;
        public string Nr_barril { get; set; } = string.Empty;
        public string Cd_produto { get; set; } = string.Empty;
        public string Ds_produto { get; set; } = string.Empty;
        public int? Id_chopeira { get; set; } = null;
        public string Nr_chopeira { get; set; } = string.Empty;
        public int? Id_kit { get; set; } = null;
        public string Nr_kit { get; set; } = string.Empty;
        private DateTime? dt_lancto = null;
        public DateTime? Dt_lancto
        {
            get { return dt_lancto; }
            set
            {
                dt_lancto = value;
                dt_lanctostr = value.HasValue ? value.Value.ToString("dd/MM/yyyy HH:mm:ss") : string.Empty;
            }
        }
        private string dt_lanctostr = string.Empty;
        public string Dt_lanctostr
        {
            get
            {
                try
                {
                    return DateTime.Parse(dt_lanctostr).ToString("dd/MM/yyyy HH:mm:ss");
                }
                catch { return string.Empty; }
            }
            set
            {
                dt_lanctostr= value;
                try
                {
                    dt_lancto = DateTime.Parse(value);
                }
                catch { dt_lancto = null; }
            }
        }
        public string Tp_lancto { get; set; } = string.Empty;
        public string Tipo_lancto
        {
            get
            {
                if (Tp_lancto.Trim().ToUpper().Equals("E"))
                    return "ENTREGA";
                else if (Tp_lancto.Trim().ToUpper().Equals("D"))
                    return "DEVOLUÇÃO";
                else return string.Empty;
            }
        }
        public bool RetornouCheio { get; set; } = false;
        public string MotivoCanc { get; set; } = string.Empty;
        public string St_registro { get; set; } = "A";
        public string Status
        {
            get
            {
                if (St_registro.Trim().ToUpper().Equals("A"))
                    return "ATIVO";
                else if (St_registro.Trim().ToUpper().Equals("C"))
                    return "CANCELADO";
                else return string.Empty;
            }
        }
        public bool St_processar { get; set; } = false;
    }

    public class TCD_Expedicao:TDataQuery
    {
        public TCD_Expedicao() { }
        
        public TCD_Expedicao(TObjetoBanco banco) { Banco_Dados = banco; }

        public string SqlCodeBusca(Utils.TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            string strtop = string.Empty;
            if (vTop > 0)
                strtop = " top " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("select " + strtop + " a.cd_empresa, a.id_reserva, ");
                sql.AppendLine("a.id_item, a.id_expedicao, a.loginretcheio, a.id_kit, ");
                sql.AppendLine("a.dt_lancto, a.tp_lancto, a.retornoucheio, d.nr_kit, ");
                sql.AppendLine("a.id_barril, b.nr_barril, a.id_chopeira, c.nr_chopeira, ");
                sql.AppendLine("r.cd_produto, p.ds_produto, a.motivocanc, a.st_registro ");
            }
            else
                sql.AppendLine("Select " + strtop + " " + vNM_Campo);

            sql.AppendLine("from TB_RES_Expedicao a ");
            sql.AppendLine("inner join TB_RES_ItensReserva r ");
            sql.AppendLine("on a.cd_empresa = r.cd_empresa ");
            sql.AppendLine("and a.id_reserva = r.id_reserva ");
            sql.AppendLine("and a.id_item = r.id_item ");
            sql.AppendLine("left outer join TB_EST_Produto p ");
            sql.AppendLine("on r.cd_produto = p.cd_produto ");
            sql.AppendLine("left outer join TB_RES_Barril b ");
            sql.AppendLine("on a.id_barril = b.id_barril ");
            sql.AppendLine("left outer join TB_RES_Chopeira c ");
            sql.AppendLine("on a.id_chopeira = c.id_chopeira ");
            sql.AppendLine("left outer join TB_RES_KitExtrator d ");
            sql.AppendLine("on a.id_kit = d.id_kit ");

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

        public TList_Expedicao Select(Utils.TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            TList_Expedicao lista = new TList_Expedicao();
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = ExecutarBusca(SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_Expedicao reg = new TRegistro_Expedicao();
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_reserva")))
                        reg.Id_reserva = reader.GetInt32(reader.GetOrdinal("id_reserva"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_item")))
                        reg.Id_item = reader.GetInt32(reader.GetOrdinal("id_item"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_expedicao")))
                        reg.Id_expedicao = reader.GetInt32(reader.GetOrdinal("id_expedicao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("loginretcheio")))
                        reg.LoginRetCheio = reader.GetString(reader.GetOrdinal("loginretcheio"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_barril")))
                        reg.Id_barril = reader.GetInt32(reader.GetOrdinal("id_barril"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_barril")))
                        reg.Nr_barril = reader.GetString(reader.GetOrdinal("nr_barril"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_produto")))
                        reg.Cd_produto = reader.GetString(reader.GetOrdinal("cd_produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_produto")))
                        reg.Ds_produto = reader.GetString(reader.GetOrdinal("ds_produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_chopeira")))
                        reg.Id_chopeira = reader.GetInt32(reader.GetOrdinal("id_chopeira"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_chopeira")))
                        reg.Nr_chopeira = reader.GetString(reader.GetOrdinal("nr_chopeira"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_kit")))
                        reg.Id_kit = reader.GetInt32(reader.GetOrdinal("id_kit"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_kit")))
                        reg.Nr_kit = reader.GetString(reader.GetOrdinal("nr_kit"));
                    if (!reader.IsDBNull(reader.GetOrdinal("dt_lancto")))
                        reg.Dt_lancto = reader.GetDateTime(reader.GetOrdinal("dt_lancto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_lancto")))
                        reg.Tp_lancto = reader.GetString(reader.GetOrdinal("tp_lancto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("retornoucheio")))
                        reg.RetornouCheio = reader.GetBoolean(reader.GetOrdinal("retornoucheio"));
                    if (!reader.IsDBNull(reader.GetOrdinal("motivocanc")))
                        reg.MotivoCanc = reader.GetString(reader.GetOrdinal("motivocanc"));
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

        public string Gravar(TRegistro_Expedicao val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(13);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_RESERVA", val.Id_reserva);
            hs.Add("@P_ID_ITEM", val.Id_item);
            hs.Add("@P_ID_EXPEDICAO", val.Id_expedicao);
            hs.Add("@P_LOGINRETCHEIO", val.LoginRetCheio);
            hs.Add("@P_ID_BARRIL", val.Id_barril);
            hs.Add("@P_ID_CHOPEIRA", val.Id_chopeira);
            hs.Add("@P_ID_KIT", val.Id_kit);
            hs.Add("@P_DT_LANCTO", val.Dt_lancto);
            hs.Add("@P_TP_LANCTO", val.Tp_lancto);
            hs.Add("P_RETORNOUCHEIO", val.RetornouCheio);
            hs.Add("@P_MOTIVOCANC", val.MotivoCanc);
            hs.Add("@P_ST_REGISTRO", val.St_registro);

            return executarProc("IA_RES_EXPEDICAO", hs);
        }

        public string Excluir(TRegistro_Expedicao val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(4);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_RESERVA", val.Id_reserva);
            hs.Add("@P_ID_ITEM", val.Id_item);
            hs.Add("@P_ID_EXPEDICAO", val.Id_expedicao);

            return executarProc("EXCLUI_RES_EXPEDICAO", hs);
        }
    }
    #endregion
}
