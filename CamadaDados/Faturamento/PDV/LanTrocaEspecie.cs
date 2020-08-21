using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamadaDados.Faturamento.PDV
{
    public class TList_TrocaEspecie : List<TRegistro_TrocaEspecie>
    { }
    
    public class TRegistro_TrocaEspecie
    {
        private decimal? id_troca;
        public decimal? Id_troca
        {
            get { return id_troca; }
            set
            {
                id_troca = value;
                id_trocastr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_trocastr;
        public string Id_trocastr
        {
            get { return id_trocastr; }
            set
            {
                id_trocastr = value;
                try
                {
                    id_troca = decimal.Parse(value);
                }
                catch { id_troca = null; }
            }
        }
        public string Cd_empresa
        { get; set; }
        public string Nm_empresa
        { get; set; }
        private decimal? id_fatura;
        public decimal? Id_fatura
        {
            get { return id_fatura; }
            set
            {
                id_fatura = value;
                id_faturastr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_faturastr;
        public string Id_faturastr
        {
            get { return id_faturastr; }
            set
            {
                id_faturastr = value;
                try
                {
                    id_fatura = decimal.Parse(value);
                }
                catch { id_fatura = null; }
            }
        }
        private decimal? nr_lanctocheque;
        public decimal? Nr_lanctocheque
        {
            get { return nr_lanctocheque; }
            set
            {
                nr_lanctocheque = value;
                nr_lanctochequestr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string nr_lanctochequestr;
        public string Nr_lanctochequestr
        {
            get { return nr_lanctochequestr; }
            set
            {
                nr_lanctochequestr = value;
                try
                {
                    nr_lanctocheque = decimal.Parse(value);
                }
                catch { nr_lanctocheque = null; }
            }
        }
        public string Cd_banco
        { get; set; }
        public string Ds_banco
        { get; set; }
        public string Cd_contager_trocoD
        { get; set; }
        private decimal? cd_lanctocaixa_trocoD;
        public decimal? Cd_lanctocaixa_trocoD
        {
            get { return cd_lanctocaixa_trocoD; }
            set
            {
                cd_lanctocaixa_trocoD = value;
                cd_lanctocaixa_trocoDstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string cd_lanctocaixa_trocoDstr;
        public string Cd_lanctocaixa_trocoDstr
        {
            get { return cd_lanctocaixa_trocoDstr; }
            set
            {
                cd_lanctocaixa_trocoDstr = value;
                try
                {
                    cd_lanctocaixa_trocoD = decimal.Parse(value);
                }
                catch { cd_lanctocaixa_trocoD = null; }
            }
        }
        private decimal? id_caixa;
        public decimal? Id_caixa
        {
            get { return id_caixa; }
            set
            {
                id_caixa = value;
                id_caixastr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_caixastr;
        public string Id_caixastr
        {
            get { return id_caixastr; }
            set
            {
                id_caixastr = value;
                try
                {
                    id_caixa = decimal.Parse(value);
                }
                catch { id_caixa = null; }
            }
        }
        private decimal? id_cartafrete;
        public decimal? Id_cartafrete
        {
            get { return id_cartafrete; }
            set
            {
                id_cartafrete = value;
                id_cartafretestr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_cartafretestr;
        public string Id_cartafretestr
        {
            get { return id_cartafretestr; }
            set
            {
                id_cartafretestr = value;
                try
                {
                    id_cartafrete = decimal.Parse(value);
                }
                catch { id_cartafrete = null; }
            }
        }
        public string Ds_observacao
        { get; set; }
        private DateTime? dt_troca;
        public DateTime? Dt_troca
        {
            get { return dt_troca; }
            set
            {
                dt_troca = value;
                dt_trocastr = value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty;
            }
        }
        private string dt_trocastr;
        public string Dt_trocastr
        {
            get 
            {
                try
                {
                    return DateTime.Parse(dt_trocastr).ToString("dd/MM/yyyy");
                }
                catch { return string.Empty; }
            }
            set
            {
                dt_trocastr = value;
                try
                {
                    dt_troca = DateTime.Parse(value);
                }
                catch { dt_troca = null; }
            }
        }
        public decimal Vl_especie
        { get; set; }
        public decimal Vl_TaxaFin
        { get; set; }
        public decimal Vl_trocoD
        { get; set; }
        public decimal Vl_trocoCHP
        { get; set; }
        public decimal Vl_trocoCHT
        { get; set; }
        public string Cd_contager
        { get; set; }
        public string Cd_historico
        { get; set; }
        public string Cd_portador
        { get; set; }
        public string Ds_portador
        { get; set; }
        public CamadaDados.Financeiro.Cartao.TRegistro_FaturaCartao rFatura
        { get; set; }
        public CamadaDados.Financeiro.Titulo.TRegistro_LanTitulo rCheque
        { get; set; }
        public CamadaDados.PostoCombustivel.TRegistro_CartaFrete rCartaFrete
        { get; set; }
        public List<CamadaDados.Financeiro.Titulo.TRegistro_LanTitulo> lTrocoCHP
        { get; set; }
        public List<CamadaDados.Financeiro.Titulo.TRegistro_LanTitulo> lTrocoCHT
        { get; set; }

        public TRegistro_TrocaEspecie()
        {
            this.Cd_empresa = string.Empty;
            this.Nm_empresa = string.Empty;
            this.id_troca = null;
            this.id_trocastr = string.Empty;
            this.id_fatura = null;
            this.id_faturastr = string.Empty;
            this.nr_lanctocheque = null;
            this.nr_lanctochequestr = string.Empty;
            this.Cd_banco = string.Empty;
            this.Ds_banco = string.Empty;
            this.Cd_contager_trocoD = string.Empty;
            this.cd_lanctocaixa_trocoD = null;
            this.cd_lanctocaixa_trocoDstr = string.Empty;
            this.id_caixa = null;
            this.id_caixastr = string.Empty;
            this.id_cartafrete = null;
            this.id_cartafretestr = string.Empty;
            this.Ds_observacao = string.Empty;
            this.dt_troca = null;
            this.dt_trocastr = string.Empty;
            this.Vl_especie = decimal.Zero;
            this.Vl_TaxaFin = decimal.Zero;
            this.Vl_trocoD = decimal.Zero;
            this.Vl_trocoCHP = decimal.Zero;
            this.Vl_trocoCHT = decimal.Zero;
            this.Cd_contager = string.Empty;
            this.Cd_historico = string.Empty;
            this.Cd_portador = string.Empty;
            this.Ds_portador = string.Empty;
            this.rFatura = null;
            this.rCheque = null;
            this.rCartaFrete = null;
            this.lTrocoCHP = new List<CamadaDados.Financeiro.Titulo.TRegistro_LanTitulo>();
            this.lTrocoCHT = new List<CamadaDados.Financeiro.Titulo.TRegistro_LanTitulo>();
        }
    }

    public class TCD_TrocaEspecie : TDataQuery
    {
        public TCD_TrocaEspecie() { }

        public TCD_TrocaEspecie(BancoDados.TObjetoBanco banco) { this.Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + vTop.ToString();

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("select " + strTop + " a.ID_Troca, a.CD_Empresa, b.NM_Empresa, ");
                sql.AppendLine("a.cd_portador, a.ds_portador, a.vl_taxafin, ");
                sql.AppendLine("a.ID_Fatura, a.Nr_LanctoCheque, a.CD_Banco, c.DS_Banco, a.dt_troca, ");
                sql.AppendLine("a.CD_ContaGer_TrocoD, a.CD_LanctoCaixa_TrocoD, a.ID_Caixa, a.ID_CartaFrete,  ");
                sql.AppendLine("a.DS_Observacao, a.Vl_Especie, a.Vl_TrocoD, a.Vl_TrocoCHP, a.Vl_TrocoCHT ");
            }
            else
                sql.AppendLine(" Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from VTB_PDV_TROCAESPECIE a ");
            sql.AppendLine("inner join TB_DIV_Empresa b ");
            sql.AppendLine("on a.CD_Empresa = b.CD_Empresa ");
            sql.AppendLine("left outer join TB_FIN_Banco c ");
            sql.AppendLine("on a.CD_Banco = c.CD_Banco ");

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

        public TList_TrocaEspecie Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            bool podeFecharBco = false;
            TList_TrocaEspecie lista = new TList_TrocaEspecie();
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_TrocaEspecie reg = new TRegistro_TrocaEspecie();
                    if (!(reader.IsDBNull(reader.GetOrdinal("ID_Troca"))))
                        reg.Id_troca = reader.GetDecimal(reader.GetOrdinal("ID_Troca"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_Empresa"))))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("CD_Empresa"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("NM_Empresa"))))
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("NM_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Fatura")))
                        reg.Id_fatura = reader.GetDecimal(reader.GetOrdinal("ID_Fatura"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Nr_LanctoCheque")))
                        reg.Nr_lanctocheque = reader.GetDecimal(reader.GetOrdinal("Nr_LanctoCheque"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Banco")))
                        reg.Cd_banco = reader.GetString(reader.GetOrdinal("CD_Banco"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Banco")))
                        reg.Ds_banco = reader.GetString(reader.GetOrdinal("DS_Banco"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_ContaGer_TrocoD")))
                        reg.Cd_contager_trocoD = reader.GetString(reader.GetOrdinal("CD_ContaGer_TrocoD"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_LanctoCaixa_TrocoD")))
                        reg.Cd_lanctocaixa_trocoD = reader.GetDecimal(reader.GetOrdinal("CD_LanctoCaixa_TrocoD"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Caixa")))
                        reg.Id_caixa = reader.GetDecimal(reader.GetOrdinal("ID_Caixa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_CartaFrete")))
                        reg.Id_cartafrete = reader.GetDecimal(reader.GetOrdinal("ID_CartaFrete"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Observacao")))
                        reg.Ds_observacao = reader.GetString(reader.GetOrdinal("DS_Observacao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("dt_troca")))
                        reg.Dt_troca = reader.GetDateTime(reader.GetOrdinal("dt_troca"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_Especie")))
                        reg.Vl_especie = reader.GetDecimal(reader.GetOrdinal("Vl_Especie"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_TrocoD")))
                        reg.Vl_trocoD = reader.GetDecimal(reader.GetOrdinal("Vl_TrocoD"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_TrocoCHP")))
                        reg.Vl_trocoCHP = reader.GetDecimal(reader.GetOrdinal("Vl_TrocoCHP"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_TrocoCHT")))
                        reg.Vl_trocoCHT = reader.GetDecimal(reader.GetOrdinal("Vl_TrocoCHT"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_portador")))
                        reg.Cd_portador = reader.GetString(reader.GetOrdinal("cd_portador"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_portador")))
                        reg.Ds_portador = reader.GetString(reader.GetOrdinal("ds_portador"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_taxafin")))
                        reg.Vl_TaxaFin = reader.GetDecimal(reader.GetOrdinal("vl_taxafin"));

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

        public string Gravar(TRegistro_TrocaEspecie val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(11);
            hs.Add("@P_ID_TROCA", val.Id_troca);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_FATURA", val.Id_fatura);
            hs.Add("@P_NR_LANCTOCHEQUE", val.Nr_lanctocheque);
            hs.Add("@P_CD_BANCO", val.Cd_banco);
            hs.Add("@P_CD_CONTAGER_TROCOD", val.Cd_contager_trocoD);
            hs.Add("@P_CD_LANCTOCAIXA_TROCOD", val.Cd_lanctocaixa_trocoD);
            hs.Add("@P_ID_CAIXA", val.Id_caixa);
            hs.Add("@P_ID_CARTAFRETE", val.Id_cartafrete);
            hs.Add("@P_VL_TAXAFIN", val.Vl_TaxaFin);
            hs.Add("@P_DS_OBSERVACAO", val.Ds_observacao);

            return this.executarProc("IA_PDV_TROCAESPECIE", hs);
        }

        public string Excluir(TRegistro_TrocaEspecie val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(2);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_TROCA", val.Id_troca);

            return this.executarProc("EXCLUI_PDV_TROCAESPECIE", hs);
        }
    }
}
