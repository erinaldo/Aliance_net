using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamadaDados.Mudanca
{
    #region Guarda Volume
    public class TList_GuardaVolume : List<TRegistro_GuardaVolume>, IComparer<TRegistro_GuardaVolume>
    {
        #region IComparer<TRegistro_GuardaVolume> Members
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

        public TList_GuardaVolume()
        { }

        public TList_GuardaVolume(System.ComponentModel.PropertyDescriptor Prop,
                               System.Windows.Forms.SortOrder Dir)
        {
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_GuardaVolume value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_GuardaVolume x, TRegistro_GuardaVolume y)
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

    public class TRegistro_GuardaVolume
    {
        public string Cd_empresa
        { get; set; }
        public string Nm_empresa
        { get; set; }
        private decimal? id_guardavol;
        public decimal? Id_guardavol
        {
            get { return id_guardavol; }
            set
            {
                id_guardavol = value;
                id_guardavolstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_guardavolstr;
        public string Id_guardavolstr
        {
            get { return id_guardavolstr; }
            set
            {
                id_guardavolstr = value;
                try
                {
                    id_guardavol = decimal.Parse(value);
                }
                catch { id_guardavol = null; }
            }
        }
        public string Cd_clifor
        { get; set; }
        public string Nm_clifor
        { get; set; }
        public string Cd_endereco
        { get; set; }
        public string Ds_endereco
        { get; set; }
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
        public string Ds_cidade_orig
        { get; set; }
        public string Uf_orig
        { get; set; }
        public string Ds_cidade_dest
        { get; set; }
        public string Uf_dest
        { get; set; }
        public string Cd_motorista
        { get; set; }
        public string Nm_motorista
        { get; set; }
        public string Ds_veiculo
        { get; set; }
        public string Placa
        { get; set; }
        public string NR_GuardaVol
        { get; set; }
        private DateTime? dt_registro;
        public DateTime? Dt_registro
        {
            get { return dt_registro; }
            set
            {
                dt_registro = value;
                dt_registrostr = value.HasValue ? value.Value.ToString("dd/MM/yyyy HH:mm:ss") : string.Empty;
            }
        }
        private string dt_registrostr;
        public string Dt_registrostr
        {
            get
            {
                try
                {
                    return DateTime.Parse(dt_registrostr).ToString("dd/MM/yyyy HH:mm:ss");
                }
                catch { return string.Empty; }
            }
            set
            {
                dt_registrostr = value;
                try
                {
                    dt_registro = DateTime.Parse(value);
                }
                catch { dt_registro = null; }
            }
        }
        private DateTime? dt_prevretirada;
        public DateTime? Dt_prevretirada
        {
            get { return dt_prevretirada; }
            set
            {
                dt_prevretirada = value;
                dt_prevretiradastr = value.HasValue ? value.Value.ToString("dd/MM/yyyy HH:mm:ss") : string.Empty;
            }
        }
        private string dt_prevretiradastr;
        public string Dt_prevretiradastr
        {
            get
            {
                try
                {
                    return DateTime.Parse(dt_prevretiradastr).ToString("dd/MM/yyyy HH:mm:ss");
                }
                catch { return string.Empty; }
            }
            set
            {
                dt_prevretiradastr = value;
                try
                {
                    dt_prevretirada = DateTime.Parse(value);
                }
                catch { dt_prevretirada = null; }
            }
        }
        public string Ds_observacao
        { get; set; }
        public string St_registro
        { get; set; }
        public string Status
        {
            get
            {
                if (St_registro.Trim().Equals("F"))
                    return "FINALIZADO";
                else if (St_registro.Trim().Equals("A"))
                    return "ABERTO";
                else if (St_registro.Trim().Equals("C"))
                    return "CANCELADO";
                else return string.Empty;
            }
        }
        public TList_ItensGuardaVolume lItensGuardaVolume
        { get; set; }
        public TList_ItensGuardaVolume lItensGuardaVolumeDel
        { get; set; }
        public TList_RetGuardaVol lRetGuardaVol
        { get; set; }
        public TList_RetGuardaVol lRetGuardaVolDel
        { get; set; }

        public TRegistro_GuardaVolume()
        {
            this.Cd_empresa = string.Empty;
            this.Nm_empresa = string.Empty;
            this.id_guardavol = null;
            this.id_guardavolstr = string.Empty;
            this.Cd_clifor = string.Empty;
            this.Nm_clifor = string.Empty;
            this.Cd_endereco = string.Empty;
            this.Ds_endereco = string.Empty;
            this.id_mudanca = null;
            this.id_mudancastr = string.Empty;
            this.Ds_cidade_orig = string.Empty;
            this.Uf_orig = string.Empty;
            this.Ds_cidade_dest = string.Empty;
            this.Uf_dest = string.Empty;
            this.Cd_motorista = string.Empty;
            this.Nm_motorista = string.Empty;
            this.Ds_veiculo = string.Empty;
            this.Placa = string.Empty;
            this.NR_GuardaVol = string.Empty;
            this.dt_registro = CamadaDados.UtilData.Data_Servidor();
            this.dt_registrostr = CamadaDados.UtilData.Data_Servidor().ToString();
            this.dt_prevretirada = null;
            this.dt_prevretiradastr = string.Empty;
            this.Ds_observacao = string.Empty;
            this.St_registro = "A";
            this.lItensGuardaVolume = new TList_ItensGuardaVolume();
            this.lItensGuardaVolumeDel = new TList_ItensGuardaVolume();
            this.lRetGuardaVol = new TList_RetGuardaVol();
            this.lRetGuardaVolDel = new TList_RetGuardaVol();
        }
    }

    public class TCD_GuardaVolume : TDataQuery
    {
        public TCD_GuardaVolume() { }

        public TCD_GuardaVolume(BancoDados.TObjetoBanco banco) { this.Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("select " + strTop + "a.CD_Empresa, b.NM_Empresa, ");
                sql.AppendLine("a.ID_GuardaVol, a.ID_Mudanca, e.DS_Cidade_Orig, e.ufOrig, ");
                sql.AppendLine("e.DS_Cidade_Dest, e.UfDest, e.Cd_Motorista, ");
                sql.AppendLine("e.NM_Motorista, e.DS_Veiculo, e.Placa, ");
                sql.AppendLine("a.CD_Clifor, c.nm_clifor, a.cd_endereco, ");
                sql.AppendLine("d.ds_endereco, a.NR_GuardaVol, a.DT_Registro, ");
                sql.AppendLine("a.DT_PrevRetirada, a.DS_Observacao, a.ST_Registro ");
            }
            else
                sql.AppendLine(" Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from TB_MUD_GuardaVolume a ");
            sql.AppendLine("inner join TB_DIV_Empresa b ");
            sql.AppendLine("on a.CD_Empresa = b.CD_Empresa ");
            sql.AppendLine("inner join TB_FIN_Clifor c ");
            sql.AppendLine("on a.cd_clifor = c.cd_clifor ");
            sql.AppendLine("inner join VTB_FIN_Endereco d ");
            sql.AppendLine("on a.cd_clifor = d.cd_clifor ");
            sql.AppendLine("and a.cd_endereco = d.cd_endereco ");
            sql.AppendLine("left outer join VTB_MUD_Mudanca e ");
            sql.AppendLine("on e.id_mudanca = a.id_mudanca ");

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

        public TList_GuardaVolume Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNm_Campo)
        {
            TList_GuardaVolume lista = new TList_GuardaVolume();
            System.Data.SqlClient.SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            try
            {
                reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNm_Campo));
                while (reader.Read())
                {
                    TRegistro_GuardaVolume reg = new TRegistro_GuardaVolume();
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Nm_empresa")))
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("Nm_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Id_guardavol")))
                        reg.Id_guardavol = reader.GetDecimal(reader.GetOrdinal("Id_guardavol"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Mudanca")))
                        reg.Id_mudanca = reader.GetDecimal(reader.GetOrdinal("ID_Mudanca"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Cidade_orig")))
                        reg.Ds_cidade_orig = reader.GetString(reader.GetOrdinal("DS_Cidade_orig"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ufOrig")))
                        reg.Uf_orig = reader.GetString(reader.GetOrdinal("ufOrig"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Cidade_dest")))
                        reg.Ds_cidade_dest = reader.GetString(reader.GetOrdinal("DS_Cidade_dest"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ufDest")))
                        reg.Uf_dest = reader.GetString(reader.GetOrdinal("ufDest"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Cd_Motorista")))
                        reg.Cd_motorista = reader.GetString(reader.GetOrdinal("Cd_Motorista"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NM_Motorista")))
                        reg.Nm_motorista = reader.GetString(reader.GetOrdinal("NM_Motorista"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Veiculo")))
                        reg.Ds_veiculo = reader.GetString(reader.GetOrdinal("DS_Veiculo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Placa")))
                        reg.Placa = reader.GetString(reader.GetOrdinal("Placa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Clifor")))
                        reg.Cd_clifor = reader.GetString(reader.GetOrdinal("CD_Clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_clifor")))
                        reg.Nm_clifor = reader.GetString(reader.GetOrdinal("nm_clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_endereco")))
                        reg.Cd_endereco = reader.GetString(reader.GetOrdinal("cd_endereco"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_endereco")))
                        reg.Ds_endereco = reader.GetString(reader.GetOrdinal("ds_endereco"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NR_GuardaVol")))
                        reg.NR_GuardaVol = reader.GetString(reader.GetOrdinal("NR_GuardaVol"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DT_Registro")))
                        reg.Dt_registro = reader.GetDateTime(reader.GetOrdinal("DT_Registro"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DT_PrevRetirada")))
                        reg.Dt_prevretirada = reader.GetDateTime(reader.GetOrdinal("DT_PrevRetirada"));
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

        public string Gravar(TRegistro_GuardaVolume val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(10);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_GUARDAVOL", val.Id_guardavol);
            hs.Add("@P_CD_CLIFOR", val.Cd_clifor);
            hs.Add("@P_CD_ENDERECO", val.Cd_endereco);
            hs.Add("@P_ID_MUDANCA", val.Id_mudanca);
            hs.Add("@P_NR_GUARDAVOL", val.NR_GuardaVol);
            hs.Add("@P_DT_REGISTRO", val.Dt_registro);
            hs.Add("@P_DT_PREVRETIRADA", val.Dt_prevretirada);
            hs.Add("@P_DS_OBSERVACAO", val.Ds_observacao);
            hs.Add("@P_ST_REGISTRO", val.St_registro);

            return this.executarProc("IA_MUD_GUARDAVOLUME", hs);
        }

        public string Excluir(TRegistro_GuardaVolume val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(2);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_GUARDAVOL", val.Id_guardavol);

            return this.executarProc("EXCLUI_MUD_GUARDAVOLUME", hs);
        }
    }
    #endregion

    #region Itens Guarda Volume
    public class TList_ItensGuardaVolume : List<TRegistro_ItensGuardaVolume>, IComparer<TRegistro_ItensGuardaVolume>
    {
        #region IComparer<TRegistro_ItensGuardaVolume> Members
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

        public TList_ItensGuardaVolume()
        { }

        public TList_ItensGuardaVolume(System.ComponentModel.PropertyDescriptor Prop,
                                       System.Windows.Forms.SortOrder Dir)
        {
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_ItensGuardaVolume value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_ItensGuardaVolume x, TRegistro_ItensGuardaVolume y)
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

    public class TRegistro_ItensGuardaVolume
    {
        public string Cd_empresa
        { get; set; }
        private decimal? id_guardavol;
        public decimal? Id_guardavol
        {
            get { return id_guardavol; }
            set
            {
                id_guardavol = value;
                id_guardavolstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_guardavolstr;
        public string Id_guardavolstr
        {
            get { return id_guardavolstr; }
            set
            {
                id_guardavolstr = value;
                try
                {
                    id_guardavol = decimal.Parse(value);
                }
                catch { id_guardavol = null; }
            }
        }
        private decimal? id_itemguardavol;
        public decimal? Id_itemguardavol
        {
            get { return id_itemguardavol; }
            set
            {
                id_itemguardavol = value;
                id_itemguardavolstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_itemguardavolstr;
        public string Id_itemguardavolstr
        {
            get { return id_itemguardavolstr; }
            set
            {
                id_itemguardavolstr = value;
                try
                {
                    id_itemguardavol = decimal.Parse(value);
                }
                catch { id_itemguardavol = null; }
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
        private DateTime? dt_locacao;
        public DateTime? Dt_locacao
        {
            get { return dt_locacao; }
            set
            {
                dt_locacao = value;
                dt_locacaostr = value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty;
            }
        }
        private string dt_locacaostr;
        public string Dt_locacaostr
        {
            get
            {
                try
                {
                    return DateTime.Parse(dt_locacaostr).ToString("dd/MM/yyyy");
                }
                catch
                { return string.Empty; }
            }
            set
            {
                dt_locacaostr = value;
                try
                {
                    dt_locacao = DateTime.Parse(value);
                }
                catch
                { dt_locacao = null; }
            }
        }
        public decimal Quantidade
        { get; set; }
        public string Ds_observacao
        { get; set; }
        public string St_registro
        { get; set; }
        public string Status
        {
            get
            {
                if (SaldoRetirar.Equals(decimal.Zero) && !St_registro.Trim().ToUpper().Equals("C"))
                    return "RETIRADO";
                else if (St_registro.Trim().Equals("A"))
                    return "ATIVO";
                else return "CANCELADO";
            }
        }
        public decimal QTD_RETIRADA
        { get; set; }
        public decimal SaldoRetirar
        { get { return this.Quantidade - this.QTD_RETIRADA; } }
        public decimal Qtd_retirar
        { get; set; }
        public bool St_processar
        { get; set; }

        public TRegistro_ItensGuardaVolume()
        {
            this.Cd_empresa = string.Empty;
            this.id_guardavol = null;
            this.id_guardavolstr = string.Empty;
            this.id_itemguardavol = null;
            this.id_itemguardavolstr = string.Empty;
            this.id_item = null;
            this.id_itemstr = string.Empty;
            this.Ds_item = string.Empty;
            this.dt_locacao = CamadaDados.UtilData.Data_Servidor();
            this.dt_locacaostr = CamadaDados.UtilData.Data_Servidor().ToString(); ;
            this.Quantidade = decimal.Zero;
            this.QTD_RETIRADA = decimal.Zero;
            this.Qtd_retirar = decimal.Zero;
            this.Ds_observacao = string.Empty;
            this.St_registro = "A";
            this.St_processar = false;
        }
    }

    public class TCD_ItensGuardaVolume : TDataQuery
    {
        public TCD_ItensGuardaVolume() { }

        public TCD_ItensGuardaVolume(BancoDados.TObjetoBanco banco) { this.Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("select " + strTop + "a.CD_Empresa, a.ID_GuardaVol, a.ID_ItemGuardaVol, ");
                sql.AppendLine("a.ID_Item, b.ds_item, a.DT_Locacao, a.Quantidade, a.DS_Observacao, a.ST_Registro, a.QTD_RETIRADA ");
            }
            else
                sql.AppendLine(" Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from VTB_MUD_ItensGuardaVolume a ");
            sql.AppendLine("left outer join TB_MUD_Itens b ");
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

        public TList_ItensGuardaVolume Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNm_Campo)
        {
            TList_ItensGuardaVolume lista = new TList_ItensGuardaVolume();
            System.Data.SqlClient.SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            try
            {
                reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNm_Campo));
                while (reader.Read())
                {
                    TRegistro_ItensGuardaVolume reg = new TRegistro_ItensGuardaVolume();
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_GuardaVol")))
                        reg.Id_guardavol = reader.GetDecimal(reader.GetOrdinal("ID_GuardaVol"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_ItemGuardaVol")))
                        reg.Id_itemguardavol = reader.GetDecimal(reader.GetOrdinal("ID_ItemGuardaVol"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Item")))
                        reg.Id_item = reader.GetDecimal(reader.GetOrdinal("ID_Item"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Ds_item")))
                        reg.Ds_item = reader.GetString(reader.GetOrdinal("Ds_item"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DT_Locacao")))
                        reg.Dt_locacao = reader.GetDateTime(reader.GetOrdinal("DT_Locacao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Quantidade")))
                        reg.Quantidade = reader.GetDecimal(reader.GetOrdinal("Quantidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("QTD_RETIRADA")))
                        reg.QTD_RETIRADA = reader.GetDecimal(reader.GetOrdinal("QTD_RETIRADA"));
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

        public string Gravar(TRegistro_ItensGuardaVolume val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(8);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_GUARDAVOL", val.Id_guardavol);
            hs.Add("@P_ID_ITEMGUARDAVOL", val.Id_itemguardavol);
            hs.Add("@P_ID_ITEM", val.Id_item);
            hs.Add("@P_DT_LOCACAO", val.Dt_locacao);
            hs.Add("@P_QUANTIDADE", val.Quantidade);
            hs.Add("@P_DS_OBSERVACAO", val.Ds_observacao);
            hs.Add("@P_ST_REGISTRO", val.St_registro);

            return this.executarProc("IA_MUD_ITENSGUARDAVOLUME", hs);
        }

        public string Excluir(TRegistro_ItensGuardaVolume val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(3);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_GUARDAVOL", val.Id_guardavol);
            hs.Add("@P_ID_ITEMGUARDAVOL", val.Id_itemguardavol);

            return this.executarProc("EXCLUI_MUD_ITENSGUARDAVOLUME", hs);
        }
    }
    #endregion

    #region Retirada Guarda Volume
    public class TList_RetGuardaVol : List<TRegistro_RetGuardaVol>, IComparer<TRegistro_RetGuardaVol>
    {
        #region IComparer<TRegistro_RetGuardaVol> Members
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

        public TList_RetGuardaVol()
        { }

        public TList_RetGuardaVol(System.ComponentModel.PropertyDescriptor Prop,
                                    System.Windows.Forms.SortOrder Dir)
        {
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_RetGuardaVol value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_RetGuardaVol x, TRegistro_RetGuardaVol y)
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

    public class TRegistro_RetGuardaVol
    {
        public string Cd_empresa
        { get; set; }
        private decimal? id_guardavol;
        public decimal? Id_guardavol
        {
            get { return id_guardavol; }
            set
            {
                id_guardavol = value;
                id_guardavolstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_guardavolstr;
        public string Id_guardavolstr
        {
            get { return id_guardavolstr; }
            set
            {
                id_guardavolstr = value;
                try
                {
                    id_guardavol = decimal.Parse(value);
                }
                catch { id_guardavol = null; }
            }
        }
        private decimal? id_itemguardavol;
        public decimal? Id_itemguardavol
        {
            get { return id_itemguardavol; }
            set
            {
                id_itemguardavol = value;
                id_itemguardavolstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_itemguardavolstr;
        public string Id_itemguardavolstr
        {
            get { return id_itemguardavolstr; }
            set
            {
                id_itemguardavolstr = value;
                try
                {
                    id_itemguardavol = decimal.Parse(value);
                }
                catch { id_itemguardavol = null; }
            }
        }
        private decimal? id_retirada;
        public decimal? Id_retirada
        {
            get { return id_retirada; }
            set
            {
                id_retirada = value;
                id_retiradastr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_retiradastr;
        public string Id_retiradastr
        {
            get { return id_retiradastr; }
            set
            {
                id_retiradastr = value;
                try
                {
                    id_retirada = decimal.Parse(value);
                }
                catch { id_retirada = null; }
            }
        }
        public string Login
        { get; set; }
        public string LoginCanc
        { get; set; }
        private DateTime? dt_retirada;

        public DateTime? Dt_retirada
        {
            get { return dt_retirada; }
            set
            {
                dt_retirada = value;
                dt_retiradastr = value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty;
            }
        }
        private string dt_retiradastr;
        public string Dt_retiradastr
        {
            get
            {
                try
                {
                    return DateTime.Parse(dt_retiradastr).ToString("dd/MM/yyyy");
                }
                catch
                { return string.Empty; }
            }
            set
            {
                dt_retiradastr = value;
                try
                {
                    dt_retirada = DateTime.Parse(value);
                }
                catch
                { dt_retirada = null; }
            }
        }
        private DateTime? dt_cancelamento;

        public DateTime? Dt_cancelamento
        {
            get { return dt_cancelamento; }
            set
            {
                dt_cancelamento = value;
                dt_cancelamentostr = value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty;
            }
        }
        private string dt_cancelamentostr;
        public string Dt_cancelamentostr
        {
            get
            {
                try
                {
                    return DateTime.Parse(dt_cancelamentostr).ToString("dd/MM/yyyy");
                }
                catch
                { return string.Empty; }
            }
            set
            {
                dt_cancelamentostr = value;
                try
                {
                    dt_cancelamento = DateTime.Parse(value);
                }
                catch
                { dt_cancelamento = null; }
            }
        }
        public decimal Quantidade
        { get; set; }
        public string Ds_observacao
        { get; set; }
        public string St_registro
        { get; set; }
        public string Status
        {
            get
            {
                if (St_registro.Trim().Equals("A"))
                    return "ATIVO";
                else return "CANCELADO";
            }
        }


        public TRegistro_RetGuardaVol()
        {
            this.Cd_empresa = string.Empty;
            this.id_guardavol = null;
            this.id_guardavolstr = string.Empty;
            this.id_itemguardavol = null;
            this.id_itemguardavolstr = string.Empty;
            this.id_retirada = null;
            this.id_retiradastr = string.Empty;
            this.Login = string.Empty;
            this.LoginCanc = string.Empty;
            this.dt_retirada = CamadaDados.UtilData.Data_Servidor();
            this.dt_retiradastr = CamadaDados.UtilData.Data_Servidor().ToString();
            this.dt_cancelamento = null;
            this.dt_cancelamentostr = string.Empty;
            this.Quantidade = decimal.Zero;
            this.Ds_observacao = string.Empty;
            this.St_registro = "A";
        }
    }

    public class TCD_RetGuardaVol : TDataQuery
    {
        public TCD_RetGuardaVol() { }

        public TCD_RetGuardaVol(BancoDados.TObjetoBanco banco) { this.Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("select " + strTop + "a.CD_Empresa, a.ID_GuardaVol, ");
                sql.AppendLine("a.ID_ItemGuardaVol, a.ID_Retirada, a.Login, a.LoginCanc, a.DT_Retirada, a.DT_Cancelamento, a.Quantidade, ");
                sql.AppendLine("a.DS_Observacao, a.ST_Registro ");
            }
            else
                sql.AppendLine(" Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from TB_MUD_RetGuardaVol a ");

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

        public TList_RetGuardaVol Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNm_Campo)
        {
            TList_RetGuardaVol lista = new TList_RetGuardaVol();
            System.Data.SqlClient.SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            try
            {
                reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNm_Campo));
                while (reader.Read())
                {
                    TRegistro_RetGuardaVol reg = new TRegistro_RetGuardaVol();
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_GuardaVol")))
                        reg.Id_guardavol = reader.GetDecimal(reader.GetOrdinal("ID_GuardaVol"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_ItemGuardaVol")))
                        reg.Id_itemguardavol = reader.GetDecimal(reader.GetOrdinal("ID_ItemGuardaVol"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Retirada")))
                        reg.Id_retirada = reader.GetDecimal(reader.GetOrdinal("ID_Retirada"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Login")))
                        reg.Login = reader.GetString(reader.GetOrdinal("Login"));
                    if (!reader.IsDBNull(reader.GetOrdinal("LoginCanc")))
                        reg.LoginCanc = reader.GetString(reader.GetOrdinal("LoginCanc"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DT_Retirada")))
                        reg.Dt_retirada = reader.GetDateTime(reader.GetOrdinal("DT_Retirada"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DT_Cancelamento")))
                        reg.Dt_cancelamento = reader.GetDateTime(reader.GetOrdinal("DT_Cancelamento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Quantidade")))
                        reg.Quantidade = reader.GetDecimal(reader.GetOrdinal("Quantidade"));
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

        public string Gravar(TRegistro_RetGuardaVol val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(11);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_GUARDAVOL", val.Id_guardavol);
            hs.Add("@P_ID_ITEMGUARDAVOL", val.Id_itemguardavol);
            hs.Add("@P_ID_RETIRADA", val.Id_retirada);
            hs.Add("@P_LOGIN", val.Login);
            hs.Add("@P_LOGINCANC", val.LoginCanc);
            hs.Add("@P_DT_RETIRADA", val.Dt_retirada);
            hs.Add("@P_DT_CANCELAMENTO", val.Dt_cancelamento);
            hs.Add("@P_QUANTIDADE", val.Quantidade);
            hs.Add("@P_DS_OBSERVACAO", val.Ds_observacao);
            hs.Add("@P_ST_REGISTRO", val.St_registro);

            return this.executarProc("IA_MUD_RETGUARDAVOL", hs);
        }

        public string Excluir(TRegistro_RetGuardaVol val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(5);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_GUARDAVOL", val.Id_guardavol);
            hs.Add("@P_ID_ITEMGUARDAVOL", val.Id_itemguardavol);
            hs.Add("@P_ID_RETIRADA", val.Id_retirada);
            hs.Add("@P_LOGINCANC", val.LoginCanc);

            return this.executarProc("EXCLUI_MUD_RETGUARDAVOL", hs);
        }
    }
    #endregion
}
