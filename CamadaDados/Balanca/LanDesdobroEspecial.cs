using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace CamadaDados.Balanca
{
    public class TList_DesdobroEspecial : List<TRegistro_DesdobroEspecial>, IComparer<TRegistro_DesdobroEspecial>
    {
        #region IComparer<TRegistro_DesdobroEspecial> Members
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

        public TList_DesdobroEspecial()
        { }

        public TList_DesdobroEspecial(System.ComponentModel.PropertyDescriptor Prop,
                                      System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_DesdobroEspecial value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_DesdobroEspecial x, TRegistro_DesdobroEspecial y)
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

    [DataContract]
    public class TRegistro_DesdobroEspecial
    {
        [DataMember]
        public decimal? Id_desdobroespecial
        { get; set; }
        [DataMember]
        public string Cd_empresa
        { get; set; }
        [DataMember]
        public decimal? Id_ticket
        { get; set; }
        [DataMember]
        public string Tp_pesagem
        { get; set; }
        private decimal? id_tpdesdobro;
        [DataMember]
        public decimal? Id_tpdesdobro
        {
            get { return id_tpdesdobro; }
            set
            {
                id_tpdesdobro = value;
                id_tpdesdobrostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_tpdesdobrostr;
        [DataMember]
        public string Id_tpdesdobrostr
        {
            get { return id_tpdesdobrostr; }
            set
            {
                id_tpdesdobrostr = value;
                try
                {
                    id_tpdesdobro = Convert.ToDecimal(value);
                }
                catch { id_tpdesdobro = null; }
            }
        }
        [DataMember]
        public string Ds_tpdesdobro
        { get; set; }
        [DataMember]
        public string Tp_calcpeso
        { get; set; }
        public string Tipo_calcpeso
        {
            get
            {
                if (!string.IsNullOrEmpty(Tp_calcpeso))
                {
                    if (Tp_calcpeso.Trim().ToUpper().Equals("B"))
                        return "PESO BRUTO";
                    else if (Tp_calcpeso.Trim().ToUpper().Equals("L"))
                        return "PESO LIQUIDO";
                    else return string.Empty;
                }
                else
                    return string.Empty;
            }
        }
        [DataMember]
        public string Tp_landesdobro
        { get; set; }
        public string Tipo_landesdobro
        {
            get
            {
                if (!string.IsNullOrEmpty(Tp_landesdobro))
                {
                    if (Tp_landesdobro.Trim().ToUpper().Equals("P"))
                        return "PERCENTUAL";
                    else if (Tp_landesdobro.Trim().ToUpper().Equals("S"))
                        return "PESO";
                    else return string.Empty;
                }
                else
                    return string.Empty;
            }
        }
        [DataMember]
        public decimal? Nr_contratodest
        { get; set; }
        private decimal? nr_pedidodest;
        [DataMember]
        public decimal? Nr_pedidodest
        {
            get { return nr_pedidodest; }
            set
            {
                nr_pedidodest = value;
                nr_pedidodeststr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string nr_pedidodeststr;
        [DataMember]
        public string Nr_pedidodeststr
        {
            get { return nr_pedidodeststr; }
            set
            {
                nr_pedidodeststr = value;
                try
                {
                    nr_pedidodest = Convert.ToDecimal(value);
                }
                catch
                { nr_pedidodest = null; }
            }
        }
        [DataMember]
        public string Cd_produtodest
        { get; set; }
        [DataMember]
        public string Ds_produtodest
        { get; set; }
        private decimal? id_pedidoitemdest;
        [DataMember]
        public decimal? Id_pedidoitemdest
        {
            get { return id_pedidoitemdest; }
            set
            {
                id_pedidoitemdest = value;
                id_pedidoitemdeststr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_pedidoitemdeststr;
        [DataMember]
        public string Id_pedidoitemdeststr
        {
            get { return id_pedidoitemdeststr; }
            set
            {
                id_pedidoitemdeststr = value;
                try
                {
                    id_pedidoitemdest = Convert.ToDecimal(value);
                }
                catch
                { id_pedidoitemdest = null; }
            }
        }
        [DataMember]
        public decimal? Id_transf
        { get; set; }
        [DataMember]
        public string Cd_clifordest
        { get; set; }
        [DataMember]
        public string Nm_clifordest
        { get; set; }
        [DataMember]
        public string Cd_empresadest
        { get; set; }
        [DataMember]
        public string Nm_empresadest
        { get; set; }
        [DataMember]
        public decimal Peso_basecalc
        { get; set; }
        [DataMember]
        public decimal Pc_desdobro
        { get; set; }
        [DataMember]
        public decimal Peso_desdobro
        { get; set; }
        [DataMember]
        public CamadaDados.Graos.TRegistro_Transferencia rTransf
        { get; set; }

        public TRegistro_DesdobroEspecial()
        {
            this.Id_desdobroespecial = null;
            this.Cd_empresa = string.Empty;
            this.Id_ticket = null;
            this.Tp_pesagem = string.Empty;
            this.id_tpdesdobro = null;
            this.id_tpdesdobrostr = string.Empty;
            this.Ds_tpdesdobro = string.Empty;
            this.Tp_calcpeso = string.Empty;
            this.Tp_landesdobro = string.Empty;
            this.Nr_contratodest = null;
            this.nr_pedidodest = null;
            this.nr_pedidodeststr = string.Empty;
            this.Cd_produtodest = string.Empty;
            this.Ds_produtodest = string.Empty;
            this.id_pedidoitemdest = null;
            this.id_pedidoitemdeststr = string.Empty;
            this.Cd_clifordest = string.Empty;
            this.Nm_clifordest = string.Empty;
            this.Cd_empresadest = string.Empty;
            this.Nm_empresadest = string.Empty;
            this.Peso_basecalc = decimal.Zero;
            this.Id_transf = null;
            this.Pc_desdobro = decimal.Zero;
            this.Peso_desdobro = decimal.Zero;
            this.rTransf = null;
        }

        public TRegistro_DesdobroEspecial Copy()
        {
            TRegistro_DesdobroEspecial retorno = new TRegistro_DesdobroEspecial();
            retorno.Cd_clifordest = this.Cd_clifordest;
            retorno.Cd_empresa = this.Cd_empresa;
            retorno.Cd_empresadest = this.Cd_empresadest;
            retorno.Cd_produtodest = this.Cd_produtodest;
            retorno.Ds_produtodest = this.Ds_produtodest;
            retorno.Ds_tpdesdobro = this.Ds_tpdesdobro;
            retorno.Id_desdobroespecial = this.Id_desdobroespecial;
            retorno.id_pedidoitemdest = this.id_pedidoitemdest;
            retorno.id_pedidoitemdeststr = this.id_pedidoitemdeststr;
            retorno.Id_ticket = this.Id_ticket;
            retorno.id_tpdesdobro = this.id_tpdesdobro;
            retorno.id_tpdesdobrostr = this.id_tpdesdobrostr;
            retorno.Id_transf = this.Id_transf;
            retorno.Nm_clifordest = this.Nm_clifordest;
            retorno.Nm_empresadest = this.Nm_empresadest;
            retorno.Nr_contratodest = this.Nr_contratodest;
            retorno.nr_pedidodest = this.nr_pedidodest;
            retorno.nr_pedidodeststr = this.nr_pedidodeststr;
            retorno.Pc_desdobro = this.Pc_desdobro;
            retorno.Peso_basecalc = this.Peso_basecalc;
            retorno.Peso_desdobro = this.Peso_desdobro;
            retorno.Tp_calcpeso = this.Tp_calcpeso;
            retorno.Tp_landesdobro = this.Tp_landesdobro;
            retorno.Tp_pesagem = this.Tp_pesagem;

            return retorno;
        }
    }

    public class TCD_DesdobroEspecial : TDataQuery
    {
        public TCD_DesdobroEspecial()
        { }

        public TCD_DesdobroEspecial(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = " ";
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (vNM_Campo.Length == 0)
            {
                sql.AppendLine("select " + strTop + " a.ID_DesdobroEspecial, a.CD_Empresa, ");
                sql.AppendLine("a.ID_Ticket, a.Tp_Pesagem, a.ID_TpDesdobro, ");
                sql.AppendLine("b.DS_TpDesdobro, a.Nr_PedidoDest, a.CD_ProdutoDest, ");
                sql.AppendLine("a.ID_PedidoItemDest, a.ID_Transf, a.PC_Desdobro, a.Peso_Desdobro, ");
                sql.AppendLine("b.TP_CalcPeso, b.TP_LanDesdobro, ");
                sql.AppendLine("c.Nr_Contrato as Nr_ContratoDest, d.CD_Empresa as Cd_EmpresaDest, ");
                sql.AppendLine("e.NM_Empresa as NM_EmpresaDest, d.CD_Clifor as Cd_CliforDest, f.NM_Clifor as NM_CliforDest ");
            }
            else
                sql.AppendLine(" Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from TB_BAL_DesdobroEspecial a ");
            sql.AppendLine("inner join TB_BAL_TpDesdobroEspecial b ");
            sql.AppendLine("on a.ID_TpDesdobro = b.ID_TpDesdobro ");
            sql.AppendLine("inner join TB_GRO_Contrato_X_PedidoItem c ");
            sql.AppendLine("on a.Nr_PedidoDest = c.Nr_Pedido ");
            sql.AppendLine("and a.CD_ProdutoDest = c.CD_Produto ");
            sql.AppendLine("and a.ID_PedidoItemDest = c.ID_PedidoItem ");
            sql.AppendLine("inner join TB_GRO_Contrato d ");
            sql.AppendLine("on c.Nr_Contrato = d.Nr_Contrato ");
            sql.AppendLine("inner join TB_DIV_Empresa e ");
            sql.AppendLine("on a.CD_Empresa = e.CD_Empresa ");
            sql.AppendLine("inner join TB_FIN_Clifor f ");
            sql.AppendLine("on d.CD_Clifor = f.CD_Clifor ");

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

        public TList_DesdobroEspecial Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            bool podeFecharBco = false;
            TList_DesdobroEspecial lista = new TList_DesdobroEspecial();
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_DesdobroEspecial reg = new TRegistro_DesdobroEspecial();
                    if (!(reader.IsDBNull(reader.GetOrdinal("ID_DesdobroEspecial"))))
                        reg.Id_desdobroespecial = reader.GetDecimal(reader.GetOrdinal("ID_DesdobroEspecial"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_Empresa"))))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("CD_Empresa"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("ID_Ticket"))))
                        reg.Id_ticket = reader.GetDecimal(reader.GetOrdinal("ID_Ticket"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("Tp_Pesagem"))))
                        reg.Tp_pesagem = reader.GetString(reader.GetOrdinal("Tp_Pesagem"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("ID_TpDesdobro"))))
                        reg.Id_tpdesdobro = reader.GetDecimal(reader.GetOrdinal("ID_TpDesdobro"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("DS_TpDesdobro"))))
                        reg.Ds_tpdesdobro = reader.GetString(reader.GetOrdinal("DS_TpDesdobro"));
                    if (!reader.IsDBNull(reader.GetOrdinal("TP_CalcPeso")))
                        reg.Tp_calcpeso = reader.GetString(reader.GetOrdinal("TP_CalcPeso"));
                    if (!reader.IsDBNull(reader.GetOrdinal("TP_LanDesdobro")))
                        reg.Tp_landesdobro = reader.GetString(reader.GetOrdinal("TP_LanDesdobro"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Nr_ContratoDest")))
                        reg.Nr_contratodest = reader.GetDecimal(reader.GetOrdinal("Nr_ContratoDest"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("Nr_PedidoDest"))))
                        reg.Nr_pedidodest = reader.GetDecimal(reader.GetOrdinal("Nr_PedidoDest"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_ProdutoDest"))))
                        reg.Cd_produtodest = reader.GetString(reader.GetOrdinal("CD_ProdutoDest"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_PedidoItemDest")))
                        reg.Id_pedidoitemdest = reader.GetDecimal(reader.GetOrdinal("ID_PedidoItemDest"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Cd_CliforDest")))
                        reg.Cd_clifordest = reader.GetString(reader.GetOrdinal("Cd_CliforDest"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NM_CliforDest")))
                        reg.Nm_clifordest = reader.GetString(reader.GetOrdinal("NM_CliforDest"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_EmpresaDest")))
                        reg.Cd_empresadest = reader.GetString(reader.GetOrdinal("CD_EmpresaDest"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NM_EmpresaDest")))
                        reg.Nm_empresadest = reader.GetString(reader.GetOrdinal("NM_EmpresaDest"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Transf")))
                        reg.Id_transf = reader.GetDecimal(reader.GetOrdinal("ID_Transf"));
                    if (!reader.IsDBNull(reader.GetOrdinal("PC_Desdobro")))
                        reg.Pc_desdobro = reader.GetDecimal(reader.GetOrdinal("PC_Desdobro"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Peso_Desdobro")))
                        reg.Peso_desdobro = reader.GetDecimal(reader.GetOrdinal("Peso_Desdobro"));

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

        public string Gravar(TRegistro_DesdobroEspecial val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(11);
            hs.Add("@P_ID_DESDOBROESPECIAL", val.Id_desdobroespecial);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_TICKET", val.Id_ticket);
            hs.Add("@P_TP_PESAGEM", val.Tp_pesagem);
            hs.Add("@P_ID_TPDESDOBRO", val.Id_tpdesdobro);
            hs.Add("@P_NR_PEDIDODEST", val.Nr_pedidodest);
            hs.Add("@P_CD_PRODUTODEST", val.Cd_produtodest);
            hs.Add("@P_ID_PEDIDOITEMDEST", val.Id_pedidoitemdest);
            hs.Add("@P_ID_TRANSF", val.Id_transf);
            hs.Add("@P_PC_DESDOBRO", val.Pc_desdobro);
            hs.Add("@P_PESO_DESDOBRO", val.Peso_desdobro);

            return this.executarProc("IA_BAL_DESDOBROESPECIAL", hs);
        }

        public string Excluir(TRegistro_DesdobroEspecial val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(1);
            hs.Add("@P_ID_DESDOBROESPECIAL", val.Id_desdobroespecial);

            return this.executarProc("EXCLUI_BAL_DESDOBROESPECIAL", hs);
        }
    }
}
