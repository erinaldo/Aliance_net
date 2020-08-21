using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;
using System.Data;
using System.Data.SqlClient;
using System.Collections;

namespace CamadaDados.Graos
{
    public class TList_TaxaDeposito : List<TRegistro_TaxaDeposito>, IComparer<TRegistro_TaxaDeposito>
    {
        #region IComparer<TRegistro_TaxaDeposito> Members

        public int Compare(TRegistro_TaxaDeposito x, TRegistro_TaxaDeposito y)
        {
            throw new NotImplementedException();
        }

        #endregion
    }

    public class TRegistro_TaxaDeposito
    {        
        public decimal Id_LanTaxa { get; set; }
        public decimal Nr_Contrato { get; set; }
        public string Cd_produto { get; set; }
        public string Ds_produto { get; set; }
        public string Sigla_produto { get; set; }
        private decimal? id_reg;
        public decimal? Id_Reg 
        {
            get { return id_reg; }
            set
            {
                id_reg = value;
                id_regstr = value.ToString();
            }
        }
        private string id_regstr;
        public string Id_regstr
        {
            get { return id_regstr; }
            set
            {
                id_regstr = value;
                try
                {
                    id_reg = Convert.ToDecimal(value);
                }
                catch
                { id_reg = null; }
            }
        }
        private decimal? id_taxa;
        public decimal? Id_Taxa 
        {
            get { return id_taxa; }
            set
            {
                id_taxa = value;
                id_taxastr = value.ToString();
            }
        }
        private string id_taxastr;
        public string Id_taxastr
        {
            get { return id_taxastr; }
            set
            {
                id_taxastr = value;
                try
                {
                    id_taxa = Convert.ToDecimal(value);
                }
                catch
                { id_taxa = null; }
            }
        }
        public string Ds_taxa { get; set; }
        private DateTime? dt_lancto;
        public DateTime? DT_Lancto 
        {
            get { return dt_lancto; }
            set
            {
                dt_lancto = value;
                dt_lanctostr = value.ToString();
            }
        }
        private string dt_lanctostr;
        public string Dt_lanctostr
        {
            get
            {
                try
                {
                    return Convert.ToDateTime(dt_lanctostr).ToString("dd/MM/yyyy");
                }
                catch
                { return string.Empty; }
            }
            set
            {
                dt_lanctostr = value;
                try
                {
                    dt_lancto = Convert.ToDateTime(value);
                }
                catch
                { dt_lancto = null; }
            }
        }
        public decimal Ps_Taxa { get; set; }
        public decimal Vl_Taxa { get; set; }
        private string tp_lancto;
        public string Tp_Lancto 
        {
            get { return tp_lancto; }
            set
            {
                tp_lancto = value;
                if (value.Trim().ToUpper().Equals("A"))
                    tipo_lancto = "AUTOMATICO";
                else if (value.Trim().ToUpper().Equals("P"))
                    tipo_lancto = "PROVISAO";
                else if (value.Trim().ToUpper().Equals("M"))
                    tipo_lancto = "MANUAL";
            }
        }
        private string tipo_lancto;
        public string Tipo_lancto
        {
            get { return tipo_lancto; }
            set
            {
                tipo_lancto = value;
                if (value.Trim().ToUpper().Equals("AUTOMATICO"))
                    tp_lancto = "A";
                else if (value.Trim().ToUpper().Equals("PROVISAO"))
                    tp_lancto = "P";
                else if (value.Trim().ToUpper().Equals("MANUAL"))
                    tp_lancto = "M";
            }
        }
        private string d_c;
        public string D_c
        {
            get { return d_c; }
            set
            {
                d_c = value;
                if (value.Trim().ToUpper().Equals("D"))
                    debito_credito = "DEBITO";
                else if (value.Trim().ToUpper().Equals("C"))
                    debito_credito = "CREDITO";
            }
        }
        private string debito_credito;
        public string Debito_credito
        {
            get { return debito_credito; }
            set
            {
                if (value.Trim().ToUpper().Equals("DEBITO"))
                    d_c = "D";
                else if (value.Trim().ToUpper().Equals("CREDITO"))
                    d_c = "C";
            }
        }
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
                status = value;
                if (value.Trim().ToUpper().Equals("ABERTO"))
                    st_registro = "A";
                else if (value.Trim().ToUpper().Equals("PROCESSADO"))
                    st_registro = "P";
            }
        }
        public bool St_faturar
        { get; set; }
        public decimal? Nr_pedidoFat
        { get; set; }
        public string Cd_empresa
        { get; set; }
        public decimal? Id_ticket
        { get; set; }
        public string Tp_pesagem
        { get; set; }

        public TRegistro_TaxaDeposito()
        {
            this.Id_LanTaxa = decimal.Zero;
            this.Nr_Contrato = decimal.Zero;
            this.Cd_produto = string.Empty;
            this.Ds_produto = string.Empty;
            this.Sigla_produto = string.Empty;
            this.id_reg = null;
            this.id_regstr = string.Empty;
            this.id_taxa = null;
            this.id_taxastr = string.Empty;
            this.Ds_taxa = string.Empty;
            this.DT_Lancto = null;
            this.dt_lanctostr = string.Empty;
            this.Ps_Taxa = decimal.Zero;
            this.Vl_Taxa = decimal.Zero;
            this.Tp_Lancto = string.Empty;
            this.tipo_lancto = string.Empty;
            this.d_c = "D";
            this.debito_credito = "DEBITO";
            this.st_registro = "A";
            this.status = "ABERTO";
            this.St_faturar = false;
            this.Nr_pedidoFat = null;
            this.Cd_empresa = string.Empty;
            this.Id_ticket = null;
            this.Tp_pesagem = string.Empty;
        }
    }

    public class TCD_LanTaxaDeposito : TDataQuery
    {
        public TCD_LanTaxaDeposito()
        { }

        public TCD_LanTaxaDeposito(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();

            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine(" SELECT " + strTop + " a.Id_LanTaxa, a.Nr_Contrato, ");
                sql.AppendLine("a.Id_Reg, a.Id_taxa, b.ds_taxa, a.DT_Lancto, a.Ps_Taxa, ");
                sql.AppendLine("a.Vl_Taxa, a.Tp_Lancto, a.d_c, ");
                sql.AppendLine("con.cd_produto, c.ds_produto, d.sigla_unidade, a.st_registro, ");
                sql.AppendLine("a.nr_pedidofat, a.cd_empresa, a.id_ticket, a.tp_pesagem ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("FROM VTB_GRO_LANCTO_TAXADEPOSITO a ");
            sql.AppendLine("inner join tb_gro_taxadeposito b ");
            sql.AppendLine("on a.id_taxa = b.id_taxa ");
            sql.AppendLine("inner join VTB_GRO_CONTRATO con ");
            sql.AppendLine("on a.Nr_Contrato = con.Nr_Contrato ");
            sql.AppendLine("inner join tb_est_produto c ");
            sql.AppendLine("on con.cd_produto = c.cd_produto ");
            sql.AppendLine("inner join tb_est_unidade d ");
            sql.AppendLine("on c.cd_unidade = d.cd_unidade ");
            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.Append(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                    cond = " and ";
                }
            sql.AppendLine("order by a.id_taxa, a.dt_lancto ");
            return sql.ToString();
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, ""), null);
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo), null);
        }

        public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
        {
            return this.ExecutarBuscaEscalar(this.SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }

        public TList_TaxaDeposito Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_TaxaDeposito lista = new TList_TaxaDeposito();
            bool podeFecharBco = false;
            if (Banco_Dados == null)
            {
                this.CriarBanco_Dados(false);
                podeFecharBco = true;
            }
            SqlDataReader reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_TaxaDeposito reg = new TRegistro_TaxaDeposito();
                    
                    if (!reader.IsDBNull(reader.GetOrdinal("Id_LanTaxa")))
                        reg.Id_LanTaxa = reader.GetDecimal(reader.GetOrdinal("Id_LanTaxa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Nr_Contrato")))
                        reg.Nr_Contrato = reader.GetDecimal(reader.GetOrdinal("Nr_Contrato"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Id_Reg")))
                        reg.Id_Reg = reader.GetDecimal(reader.GetOrdinal("Id_Reg"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Id_taxa")))
                        reg.Id_Taxa = reader.GetDecimal(reader.GetOrdinal("Id_taxa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_taxa")))
                        reg.Ds_taxa = reader.GetString(reader.GetOrdinal("ds_taxa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Id_Reg")))
                        reg.Id_Reg = reader.GetDecimal(reader.GetOrdinal("Id_Reg"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DT_Lancto")))
                        reg.DT_Lancto = reader.GetDateTime(reader.GetOrdinal("DT_Lancto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Ps_Taxa")))
                        reg.Ps_Taxa = reader.GetDecimal(reader.GetOrdinal("Ps_Taxa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_Taxa")))
                        reg.Vl_Taxa = reader.GetDecimal(reader.GetOrdinal("Vl_Taxa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Tp_Lancto")))
                        reg.Tp_Lancto = reader.GetString(reader.GetOrdinal("Tp_Lancto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("D_C")))
                        reg.D_c = reader.GetString(reader.GetOrdinal("D_C"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Produto")))
                        reg.Cd_produto = reader.GetString(reader.GetOrdinal("CD_Produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Produto")))
                        reg.Ds_produto = reader.GetString(reader.GetOrdinal("DS_Produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Sigla_unidade")))
                        reg.Sigla_produto = reader.GetString(reader.GetOrdinal("Sigla_Unidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ST_Registro")))
                        reg.St_registro = reader.GetString(reader.GetOrdinal("ST_Registro"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NR_PedidoFat")))
                        reg.Nr_pedidoFat = reader.GetDecimal(reader.GetOrdinal("NR_PedidoFat"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_ticket")))
                        reg.Id_ticket = reader.GetDecimal(reader.GetOrdinal("id_ticket"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_pesagem")))
                        reg.Tp_pesagem = reader.GetString(reader.GetOrdinal("tp_pesagem"));

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

        public string Gravar(TRegistro_TaxaDeposito val)
        {
            Hashtable hs = new Hashtable(13);
            hs.Add("@P_ID_LANTAXA", val.Id_LanTaxa);
            hs.Add("@P_NR_CONTRATO", val.Nr_Contrato);
            hs.Add("@P_ID_REG", val.Id_Reg);
            hs.Add("@P_ID_TAXA", val.Id_Taxa);
            hs.Add("@P_DT_LANCTO", val.DT_Lancto);
            hs.Add("@P_PS_TAXA", val.Ps_Taxa);
            hs.Add("@P_VL_TAXA", val.Vl_Taxa);
            hs.Add("@P_TP_LANCTO", val.Tp_Lancto);
            hs.Add("@P_D_C", val.D_c);
            hs.Add("@P_ST_REGISTRO", val.St_registro);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_TICKET", val.Id_ticket);
            hs.Add("@P_TP_PESAGEM", val.Tp_pesagem);

            return this.executarProc("IA_GRO_LANCTO_TAXADEPOSITO", hs);
        }

        public string Excluir(TRegistro_TaxaDeposito vRegistro)
        {
            Hashtable hs = new Hashtable(1);
            hs.Add("@P_ID_LANTAXA", vRegistro.Id_LanTaxa);

            return this.executarProc("EXCLUI_GRO_LANCTO_TAXADEPOSITO", hs);
        }
    }
}
