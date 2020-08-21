using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamadaDados.Frota
{
    #region Viagem
    public class TList_Viagem : List<TRegistro_Viagem>, IComparer<TRegistro_Viagem>
    {
        #region IComparer<TRegistro_Viagem> Members
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

        public TList_Viagem()
        { }

        public TList_Viagem(System.ComponentModel.PropertyDescriptor Prop,
                                     System.Windows.Forms.SortOrder Dir)
        {
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_Viagem value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_Viagem x, TRegistro_Viagem y)
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
    
    public class TRegistro_Viagem
    {
        private decimal? id_viagem;
        public decimal? Id_viagem
        {
            get { return id_viagem; }
            set
            {
                id_viagem = value;
                id_viagemstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_viagemstr;
        public string Id_viagemstr
        {
            get { return id_viagemstr; }
            set
            {
                id_viagemstr = value;
                try
                {
                    id_viagem = decimal.Parse(value);
                }
                catch
                { id_viagem = null; }

            }
        }
        public string Ds_viagem
        { get; set; }
        public string Cd_empresa
        { get; set; }
        public string Nm_empresa
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
                catch
                { id_veiculo = null; }

            }
        }
        public string Ds_veiculo
        { get; set; }
        public string Placa
        { get; set; }
        public string Cd_motorista
        { get; set; }
        public string Nm_motorista
        { get; set; }
        public string Categoria_CNH
        { get; set; }
        public DateTime? Dt_vencimento_CNH
        { get; set; }
        private DateTime? dt_viagem;
        public DateTime? Dt_viagem
        {
            get { return dt_viagem; }
            set
            {
                dt_viagem = value;
                dt_viagemstr = value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty;
            }
        }
        private string dt_viagemstr;
        public string Dt_viagemstr
        {
            get
            {
                try
                {
                    return DateTime.Parse(dt_viagemstr).ToString("dd/MM/yyyy");
                }
                catch
                { return string.Empty; }
            }
            set
            {
                dt_viagemstr = value;
                try
                {
                    dt_viagem = DateTime.Parse(value);
                }
                catch
                { dt_viagem = null; }
            }
        }
        public DateTime? Dt_prevRetorno
        {
            get 
            {
                if (dt_viagem.HasValue)
                    return dt_viagem.Value.AddDays(Convert.ToDouble(lRota.Sum(p => p.Qt_diasrota)));
                else return null;
            }
        }
        private DateTime? dt_retorno;
        public DateTime? Dt_retorno
        {
            get { return dt_retorno; }
            set
            {
                dt_retorno = value;
                dt_retornostr = value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty;
            }
        }
        private string dt_retornostr;
        public string Dt_retornostr
        {
            get
            {
                try
                {
                    return DateTime.Parse(dt_retornostr).ToString("dd/MM/yyyy");
                }
                catch
                { return string.Empty; }
            }
            set
            {
                dt_retornostr = value;
                try
                {
                    dt_retorno = DateTime.Parse(value);
                }
                catch
                { dt_retorno = null; }
            }
        }
        public decimal KM_inicial
        { get; set; }
        public decimal KM_PrevFinal
        {
            get
            {
                if (KM_inicial > decimal.Zero)
                    return KM_inicial + lRota.Sum(p => p.Distancia_KM);
                else return decimal.Zero;
            }
        }
        public decimal KM_final
        { get; set; }
        public string Ds_observacao
        { get; set; }
        public string St_viagem
        { get; set; }
        public string Status
        {
            get
            {
                if (St_viagem.Trim().ToUpper().Equals("P"))
                    return "PROGRAMADA";
                else if (St_viagem.Trim().ToUpper().Equals("E"))
                    return "EXECUTANDO";
                else if (St_viagem.Trim().ToUpper().Equals("F"))
                    return "FINALIZADA";
                else if (St_viagem.Trim().ToUpper().Equals("C"))
                    return "CANCELADA";
                else return string.Empty;
            }
        }
        public decimal Vl_despM
        { get; set; }
        public decimal Vl_despE
        { get; set; }
        public decimal Vl_manut
        { get; set; }
        public decimal Vl_infracoes
        { get; set; }
        public decimal Vl_abastM
        { get; set; }
        public decimal Vl_abastE
        { get; set; }
        public decimal Vl_adto
        { get; set; }
        public decimal Vl_adtomot
        { get; set; }
        public decimal Vl_outrosAdto
        { get; set; }
        public decimal Vl_outrosAdtoMot
        { get; set; }
        public bool St_processar
        { get; set; }
        public TList_DespesasViagem lDespesas
        { get; set; }
        public TList_DespesasViagem lDespesasDel
        { get; set; }
        public TList_AbastVeiculo lAbastecimentos
        { get; set; }
        public CamadaDados.Frota.Cadastros.TList_ManutencaoVeiculo lManutencao
        { get; set; }
        public CamadaDados.Frota.Cadastros.TList_RotaFrete lRota
        { get; set; }
        public CamadaDados.Frota.Cadastros.TList_RotaFrete lRotaDel
        { get; set; }
        public CamadaDados.Faturamento.CTRC.TList_ConhecimentoFrete lFrete
        { get; set; }
        public CamadaDados.Faturamento.CTRC.TList_ConhecimentoFrete lFreteDel
        { get; set; }
        public CamadaDados.Financeiro.Adiantamento.TList_LanAdiantamento lAdto
        { get; set; }
        
        public TRegistro_Viagem()
        {
            this.id_viagem = null;
            this.id_viagemstr = string.Empty;
            this.Ds_viagem = string.Empty;
            this.Cd_empresa = string.Empty;
            this.Nm_empresa = string.Empty;
            this.id_veiculo = null;
            this.id_veiculostr = string.Empty;
            this.Ds_veiculo = string.Empty;
            this.Placa = string.Empty;
            this.Cd_motorista = string.Empty;
            this.Nm_motorista = string.Empty;
            this.Categoria_CNH = string.Empty;
            this.Dt_vencimento_CNH = null;
            this.dt_viagem = null;
            this.dt_viagemstr = string.Empty;
            this.dt_retorno = null;
            this.dt_retornostr = string.Empty;
            this.KM_inicial = decimal.Zero;
            this.KM_final = decimal.Zero;
            this.Ds_observacao = string.Empty;
            this.St_viagem = "P";
            this.Vl_despM = decimal.Zero;
            this.Vl_despE = decimal.Zero;
            this.Vl_manut = decimal.Zero;
            this.Vl_infracoes = decimal.Zero;
            this.Vl_abastM = decimal.Zero;
            this.Vl_abastE = decimal.Zero;
            this.Vl_adto = decimal.Zero;
            this.Vl_adtomot = decimal.Zero;
            this.Vl_outrosAdto = decimal.Zero;
            this.Vl_outrosAdtoMot = decimal.Zero;
            this.St_processar = false;

            this.lDespesas = new TList_DespesasViagem();
            this.lDespesasDel = new TList_DespesasViagem();
            this.lAbastecimentos = new TList_AbastVeiculo();
            this.lManutencao = new CamadaDados.Frota.Cadastros.TList_ManutencaoVeiculo();
            this.lRota = new CamadaDados.Frota.Cadastros.TList_RotaFrete();
            this.lRotaDel = new CamadaDados.Frota.Cadastros.TList_RotaFrete();
            this.lFrete = new CamadaDados.Faturamento.CTRC.TList_ConhecimentoFrete();
            this.lFreteDel = new CamadaDados.Faturamento.CTRC.TList_ConhecimentoFrete();
            this.lAdto = new CamadaDados.Financeiro.Adiantamento.TList_LanAdiantamento();
        }
    }

    public class TCD_Viagem : TDataQuery
    {
        public TCD_Viagem()
        { }

        public TCD_Viagem(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + vTop.ToString();

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("select " + strTop + " a.id_viagem, a.ds_viagem, ");
                sql.AppendLine("b.NM_Empresa, a.id_veiculo, c.ds_veiculo, c.placa, ");
                sql.AppendLine("a.cd_motorista, d.nm_clifor as nm_motorista, a.dt_viagem, ");
                sql.AppendLine("a.dt_retorno, a.km_inicial, a.cd_empresa, ");
                sql.AppendLine("a.km_final, a.ds_observacao, a.st_viagem, ");
                sql.AppendLine("d.categoria_cnh, d.dt_vencimento_cnh, ");
                sql.AppendLine("a.vl_despM, a.vl_despE, a.vl_manut, ");
                sql.AppendLine("a.vl_infracoes, a.vl_abastM, a.vl_abastE, ");
                sql.AppendLine("a.vl_adto, a.Vl_adtoMot, a.Vl_OutrosAdto, a.Vl_OutrosAdtoMot ");
            }
            else
                sql.AppendLine(" Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from vtb_frt_viagem a ");
            sql.AppendLine("inner join TB_DIV_Empresa b ");
            sql.AppendLine("on a.cd_empresa = b.CD_Empresa ");
            sql.AppendLine("inner join TB_FRT_veiculo c ");
            sql.AppendLine("on a.id_veiculo = c.id_veiculo ");
            sql.AppendLine("inner join VTB_FIN_Clifor d ");
            sql.AppendLine("on a.cd_motorista = d.cd_clifor ");

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

        public TList_Viagem Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            bool podeFecharBco = false;
            TList_Viagem lista = new TList_Viagem();
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_Viagem reg = new TRegistro_Viagem();
                    if (!reader.IsDBNull(reader.GetOrdinal("id_viagem")))
                        reg.Id_viagem = reader.GetDecimal(reader.GetOrdinal("id_viagem"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_viagem")))
                        reg.Ds_viagem = reader.GetString(reader.GetOrdinal("ds_viagem"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NM_Empresa")))
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("NM_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_veiculo")))
                        reg.Id_veiculo = reader.GetDecimal(reader.GetOrdinal("id_veiculo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_veiculo")))
                        reg.Ds_veiculo = reader.GetString(reader.GetOrdinal("ds_veiculo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("placa")))
                        reg.Placa = reader.GetString(reader.GetOrdinal("placa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_motorista")))
                        reg.Cd_motorista = reader.GetString(reader.GetOrdinal("cd_motorista"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_motorista")))
                        reg.Nm_motorista = reader.GetString(reader.GetOrdinal("nm_motorista"));
                    if (!reader.IsDBNull(reader.GetOrdinal("categoria_cnh")))
                        reg.Categoria_CNH = reader.GetString(reader.GetOrdinal("categoria_cnh"));
                    if (!reader.IsDBNull(reader.GetOrdinal("dt_vencimento_cnh")))
                        reg.Dt_vencimento_CNH = reader.GetDateTime(reader.GetOrdinal("dt_vencimento_cnh"));
                    if (!reader.IsDBNull(reader.GetOrdinal("dt_viagem")))
                        reg.Dt_viagem = reader.GetDateTime(reader.GetOrdinal("dt_viagem"));
                    if (!reader.IsDBNull(reader.GetOrdinal("dt_retorno")))
                        reg.Dt_retorno = reader.GetDateTime(reader.GetOrdinal("dt_retorno"));
                    if (!reader.IsDBNull(reader.GetOrdinal("km_inicial")))
                        reg.KM_inicial = reader.GetDecimal(reader.GetOrdinal("km_inicial"));
                    if (!reader.IsDBNull(reader.GetOrdinal("km_final")))
                        reg.KM_final = reader.GetDecimal(reader.GetOrdinal("km_final"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_observacao")))
                        reg.Ds_observacao = reader.GetString(reader.GetOrdinal("ds_observacao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_viagem")))
                        reg.St_viagem = reader.GetString(reader.GetOrdinal("st_viagem"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_despM")))
                        reg.Vl_despM = reader.GetDecimal(reader.GetOrdinal("vl_despM"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_despE")))
                        reg.Vl_despE = reader.GetDecimal(reader.GetOrdinal("vl_despE"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_manut")))
                        reg.Vl_manut = reader.GetDecimal(reader.GetOrdinal("vl_manut"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_infracoes")))
                        reg.Vl_infracoes = reader.GetDecimal(reader.GetOrdinal("vl_infracoes"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_abastM")))
                        reg.Vl_abastM = reader.GetDecimal(reader.GetOrdinal("vl_abastM"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_abastE")))
                        reg.Vl_abastE = reader.GetDecimal(reader.GetOrdinal("vl_abastE"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_adto")))
                        reg.Vl_adto = reader.GetDecimal(reader.GetOrdinal("vl_adto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_adtoMot")))
                        reg.Vl_adtomot = reader.GetDecimal(reader.GetOrdinal("Vl_adtoMot"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_OutrosAdto")))
                        reg.Vl_outrosAdto = reader.GetDecimal(reader.GetOrdinal("Vl_OutrosAdto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_OutrosAdtoMot")))
                        reg.Vl_outrosAdtoMot = reader.GetDecimal(reader.GetOrdinal("Vl_outrosAdtoMot"));

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

        public string Gravar(TRegistro_Viagem val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(11);
            hs.Add("@P_ID_VIAGEM", val.Id_viagem);
            hs.Add("@P_DS_VIAGEM", val.Ds_viagem);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_VEICULO", val.Id_veiculo);
            hs.Add("@P_CD_MOTORISTA", val.Cd_motorista);
            hs.Add("@P_DT_VIAGEM", val.Dt_viagem);
            hs.Add("@P_DT_RETORNO", val.Dt_retorno);
            hs.Add("@P_KM_INICIAL", val.KM_inicial);
            hs.Add("@P_KM_FINAL", val.KM_final);
            hs.Add("@P_DS_OBSERVACAO", val.Ds_observacao);
            hs.Add("@P_ST_VIAGEM", val.St_viagem);

            return this.executarProc("IA_FRT_VIAGEM", hs);
        }

        public string Excluir(TRegistro_Viagem val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(2);
            hs.Add("@P_ID_VIAGEM", val.Id_viagem);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);

            return this.executarProc("EXCLUI_FRT_VIAGEM", hs);
        }
    }
    #endregion

    #region Despesas Viagem
    public class TList_DespesasViagem : List<TRegistro_DespesasViagem>, IComparer<TRegistro_DespesasViagem>
    {
        #region IComparer<TRegistro_DespesasViagem> Members
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

            public TList_DespesasViagem()
            { }

            public TList_DespesasViagem(System.ComponentModel.PropertyDescriptor Prop,
                                        System.Windows.Forms.SortOrder Dir)
            {
                Propriedade = Prop;
                Direcao = Dir;
            }

            private object GetPropertyValue(TRegistro_DespesasViagem value,
                                            string Propriedade)
            {
                System.Reflection.PropertyInfo pInfo =
                    value.GetType().GetProperty(Propriedade);
                return pInfo.GetValue(value, null);
            }

            public int Compare(TRegistro_DespesasViagem x, TRegistro_DespesasViagem y)
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
    
    public class TRegistro_DespesasViagem
    {
        private decimal? id_landespesa;
        public decimal? Id_landespesa
        {
            get { return id_landespesa; }
            set
            {
                id_landespesa = value;
                id_landespesastr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_landespesastr;
        public string Id_landespesastr
        {
            get { return id_landespesastr; }
            set
            {
                id_landespesastr = value;
                try
                {
                    id_landespesa = decimal.Parse(value);
                }
                catch
                { id_landespesa = null; }
            }
        }
        private decimal? id_viagem;
        public decimal? Id_viagem
        {
            get { return id_viagem; }
            set
            {
                id_viagem = value;
                id_viagemstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_viagemstr;
        public string Id_viagemstr
        {
            get { return id_viagemstr; }
            set
            {
                id_viagemstr = value;
                try
                {
                    id_viagem = decimal.Parse(value);
                }
                catch
                { id_viagem = null; }
            }
        }
        public string Ds_viagem
        { get; set; }
        public string Cd_empresa
        { get; set; }
        public string Nm_empresa
        { get; set; }
        private decimal? id_despesa;
        public decimal? Id_despesa
        {
            get { return id_despesa; }
            set
            {
                id_despesa = value;
                id_despesastr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_despesastr;
        public string Id_despesastr
        {
            get { return id_despesastr; }
            set
            {
                id_despesastr = value;
                try
                {
                    id_despesa = decimal.Parse(value);
                }
                catch
                { id_despesa = null; }
            }
        }
        public string Ds_despesa
        { get; set; }
        private DateTime? dt_despesa;
        public DateTime? Dt_despesa
        {
            get { return dt_despesa; }
            set
            {
                dt_despesa = value;
                dt_despesastr = value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty;
            }
        }
        private string dt_despesastr;
        public string Dt_despesastr
        {
            get
            {
                try
                {
                    return DateTime.Parse(dt_despesastr).ToString("dd/MM/yyyy");
                }
                catch
                { return string.Empty; }
            }
            set
            {
                dt_despesastr = value;
                try
                {
                    dt_despesa = DateTime.Parse(value);
                }
                catch
                { dt_despesa = null; }
            }
        }
        public string Nr_notafiscal
        { get; set; }
        public string Nm_fornecedor
        { get; set; }
        public decimal Quantidade
        { get; set; }
        public decimal Vl_unitario
        { get; set; }
        public decimal Vl_subtotal
        { get; set; }
        private string tp_pagamento;
        public string Tp_pagamento
        {
            get { return tp_pagamento; }
            set
            {
                tp_pagamento = value;
                if (value.Trim().ToUpper().Equals("M"))
                    tipo_pagamento = "MOTORISTA";
                else if (value.Trim().ToUpper().Equals("E"))
                    tipo_pagamento = "EMPRESA";
            }
        }
        private string tipo_pagamento;
        public string Tipo_pagamento
        {
            get { return tipo_pagamento; }
            set
            {
                tipo_pagamento = value;
                if (value.Trim().ToUpper().Equals("MOTORISTA"))
                    tp_pagamento = "M";
                else if (value.Trim().ToUpper().Equals("EMPRESA"))
                    tp_pagamento = "E";
            }
        }
        public string Ds_observacao
        { get; set; }
        public CamadaDados.Financeiro.Duplicata.TRegistro_LanDuplicata rDup
        { get; set; }
        public CamadaDados.Financeiro.Duplicata.TList_RegLanDuplicata lDup
        { get; set; }
        public CamadaDados.Financeiro.CCustoLan.TList_LanCCustoLancto lCCusto
        { get; set; }
        public bool St_processar
        { get; set; }

        public TRegistro_DespesasViagem()
        {
            this.id_landespesa = null;
            this.id_landespesastr = string.Empty;
            this.id_viagem = null;
            this.id_viagemstr = string.Empty;
            this.Ds_viagem = string.Empty;
            this.Cd_empresa = string.Empty;
            this.Nm_empresa = string.Empty;
            this.id_despesa = null;
            this.id_despesastr = string.Empty;
            this.Ds_despesa = string.Empty;
            this.dt_despesa = null;
            this.dt_despesastr = string.Empty;
            this.Nr_notafiscal = string.Empty;
            this.Nm_fornecedor = string.Empty;
            this.Quantidade = decimal.Zero;
            this.Vl_unitario = decimal.Zero;
            this.Vl_subtotal = decimal.Zero;
            this.tp_pagamento = string.Empty;
            this.tipo_pagamento = string.Empty;
            this.Ds_observacao = string.Empty;
            this.St_processar = false;
            this.rDup = null;
            this.lDup = new CamadaDados.Financeiro.Duplicata.TList_RegLanDuplicata();
            this.lCCusto = new CamadaDados.Financeiro.CCustoLan.TList_LanCCustoLancto();
        }
    }

    public class TCD_DespesasViagem : TDataQuery
    {
        public TCD_DespesasViagem()
        { }

        public TCD_DespesasViagem(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + vTop.ToString();

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("select " + strTop + " a.ID_LanDespesa, a.ID_Viagem, ");
                sql.AppendLine("b.DS_Viagem, a.CD_Empresa, c.NM_Empresa, ");
                sql.AppendLine("a.ID_Despesa, d.DS_Despesa, a.DT_Despesa, ");
                sql.AppendLine("a.Nr_NotaFiscal, a.NM_Fornecedor, a.Quantidade, ");
                sql.AppendLine("a.VL_Unitario, a.Quantidade * a.VL_Unitario as Vl_subtotal, ");
                sql.AppendLine("a.TP_Pagamento, a.DS_Observacao ");
            }
            else
                sql.AppendLine(" Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from TB_FRT_DespesasViagem a ");
            sql.AppendLine("inner join TB_FRT_Viagem b ");
            sql.AppendLine("on a.cd_empresa = b.cd_empresa ");
            sql.AppendLine("and a.id_viagem = b.ID_Viagem ");
            sql.AppendLine("inner join TB_DIV_Empresa c ");
            sql.AppendLine("on a.CD_Empresa = c.CD_Empresa ");
            sql.AppendLine("inner join TB_FRT_Despesa d ");
            sql.AppendLine("on a.ID_Despesa = d.ID_Despesa ");

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

        public TList_DespesasViagem Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            bool podeFecharBco = false;
            TList_DespesasViagem lista = new TList_DespesasViagem();
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_DespesasViagem reg = new TRegistro_DespesasViagem();
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_LanDespesa")))
                        reg.Id_landespesa = reader.GetDecimal(reader.GetOrdinal("ID_LanDespesa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_viagem")))
                        reg.Id_viagem = reader.GetDecimal(reader.GetOrdinal("id_viagem"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Viagem")))
                        reg.Ds_viagem = reader.GetString(reader.GetOrdinal("DS_Viagem"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NM_Empresa")))
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("NM_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Despesa")))
                        reg.Id_despesa = reader.GetDecimal(reader.GetOrdinal("ID_Despesa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Despesa")))
                        reg.Ds_despesa = reader.GetString(reader.GetOrdinal("DS_Despesa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DT_Despesa")))
                        reg.Dt_despesa = reader.GetDateTime(reader.GetOrdinal("DT_Despesa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Nr_NotaFiscal")))
                        reg.Nr_notafiscal = reader.GetString(reader.GetOrdinal("Nr_NotaFiscal"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NM_Fornecedor")))
                        reg.Nm_fornecedor = reader.GetString(reader.GetOrdinal("NM_Fornecedor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Quantidade")))
                        reg.Quantidade = reader.GetDecimal(reader.GetOrdinal("Quantidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("VL_Unitario")))
                        reg.Vl_unitario = reader.GetDecimal(reader.GetOrdinal("VL_Unitario"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_subtotal")))
                        reg.Vl_subtotal = reader.GetDecimal(reader.GetOrdinal("Vl_subtotal"));
                    if (!reader.IsDBNull(reader.GetOrdinal("TP_Pagamento")))
                        reg.Tp_pagamento = reader.GetString(reader.GetOrdinal("TP_Pagamento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Observacao")))
                        reg.Ds_observacao = reader.GetString(reader.GetOrdinal("DS_Observacao"));

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

        public string Gravar(TRegistro_DespesasViagem val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(11);
            hs.Add("@P_ID_LANDESPESA", val.Id_landespesa);
            hs.Add("@P_ID_DESPESA", val.Id_despesa);
            hs.Add("@P_ID_VIAGEM", val.Id_viagem);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_DT_DESPESA", val.Dt_despesa);
            hs.Add("@P_NR_NOTAFISCAL", val.Nr_notafiscal);
            hs.Add("@P_NM_FORNECEDOR", val.Nm_fornecedor);
            hs.Add("@P_QUANTIDADE", val.Quantidade);
            hs.Add("@P_VL_UNITARIO", val.Vl_unitario);
            hs.Add("@P_TP_PAGAMENTO", val.Tp_pagamento);
            hs.Add("@P_DS_OBSERVACAO", val.Ds_observacao);

            return this.executarProc("IA_FRT_DESPESASVIAGEM", hs);
        }

        public string Excluir(TRegistro_DespesasViagem val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(3);
            hs.Add("@P_ID_LANDESPESA", val.Id_landespesa);
            hs.Add("@P_ID_VIAGEM", val.Id_viagem);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);

            return this.executarProc("EXCLUI_FRT_DESPESASVIAGEM", hs);
        }
    }
    #endregion

    #region Despesa X Duplicata
    public class TList_Despesa_X_Duplicata : List<TRegistro_Despesa_X_Duplicata>
    { }

    
    public class TRegistro_Despesa_X_Duplicata
    {
        private decimal? id_landespesa;
        
        public decimal? Id_landespesa
        {
            get { return id_landespesa; }
            set
            {
                id_landespesa = value;
                id_landespesastr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_landespesastr;
        
        public string Id_landespesastr
        {
            get { return id_landespesastr; }
            set
            {
                id_landespesastr = value;
                try
                {
                    id_landespesa = decimal.Parse(value);
                }
                catch
                { id_landespesa = null; }
            }
        }
        private decimal? id_viagem;
        
        public decimal? Id_viagem
        {
            get { return id_viagem; }
            set
            {
                id_viagem = value;
                id_viagemstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_viagemstr;
        
        public string Id_viagemstr
        {
            get { return id_viagemstr; }
            set
            {
                id_viagemstr = value;
                try
                {
                    id_viagem = decimal.Parse(value);
                }
                catch
                { id_viagem = null; }
            }
        }
        
        public string Cd_empresa
        { get; set; }
        private decimal? nr_lancto;
        
        public decimal? Nr_lancto
        {
            get { return nr_lancto; }
            set
            {
                nr_lancto = value;
                nr_lanctostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string nr_lanctostr;
        
        public string Nr_lanctostr
        {
            get { return nr_lanctostr; }
            set
            {
                nr_lanctostr = value;
                try
                {
                    nr_lancto = decimal.Parse(value);
                }
                catch
                { nr_lancto = null; }
            }
        }

        public TRegistro_Despesa_X_Duplicata()
        {
            this.id_landespesa = null;
            this.id_landespesastr = string.Empty;
            this.id_viagem = null;
            this.id_viagemstr = string.Empty;
            this.Cd_empresa = string.Empty;
            this.nr_lancto = null;
            this.nr_lanctostr = string.Empty;
        }
    }

    public class TCD_Despesa_X_Duplicata : TDataQuery
    {
        public TCD_Despesa_X_Duplicata()
        { }

        public TCD_Despesa_X_Duplicata(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + vTop.ToString();

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("select " + strTop + " a.id_landespesa, a.id_viagem, ");
                sql.AppendLine("a.cd_empresa, a.nr_lancto ");


            }
            else
                sql.AppendLine(" Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from tb_frt_despesa_x_duplicata a ");

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

        public TList_Despesa_X_Duplicata Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            bool podeFecharBco = false;
            TList_Despesa_X_Duplicata lista = new TList_Despesa_X_Duplicata();
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_Despesa_X_Duplicata reg = new TRegistro_Despesa_X_Duplicata();
                    if (!reader.IsDBNull(reader.GetOrdinal("id_landespesa")))
                        reg.Id_landespesa = reader.GetDecimal(reader.GetOrdinal("id_landespesa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_viagem")))
                        reg.Id_viagem = reader.GetDecimal(reader.GetOrdinal("id_viagem"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_lancto")))
                        reg.Nr_lancto = reader.GetDecimal(reader.GetOrdinal("nr_lancto"));

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

        public string Gravar(TRegistro_Despesa_X_Duplicata val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(4);
            hs.Add("@P_ID_LANDESPESA", val.Id_landespesa);
            hs.Add("@P_ID_VIAGEM", val.Id_viagem);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_NR_LANCTO", val.Nr_lancto);

            return this.executarProc("IA_FRT_DESPESA_X_DUPLICATA", hs);
        }

        public string Excluir(TRegistro_Despesa_X_Duplicata val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(4);
            hs.Add("@P_ID_LANDESPESA", val.Id_landespesa);
            hs.Add("@P_ID_VIAGEM", val.Id_viagem);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_NR_LANCTO", val.Nr_lancto);

            return this.executarProc("EXCLUI_FRT_DESPESA_X_DUPLICATA", hs);
        }
    }
    #endregion

    #region Despesa X Centro Resultado
    public class TList_DespViagem_X_CCusto : List<TRegistro_DespViagem_X_CCusto>
    { }

    public class TRegistro_DespViagem_X_CCusto
    {
        private decimal? id_landespesa;
        public decimal? Id_landespesa
        {
            get { return id_landespesa; }
            set
            {
                id_landespesa = value;
                id_landespesastr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_landespesastr;
        public string Id_landespesastr
        {
            get { return id_landespesastr; }
            set
            {
                id_landespesastr = value;
                try
                {
                    id_landespesa = decimal.Parse(value);
                }
                catch { id_landespesa = null; }
            }
        }
        private decimal? id_viagem;
        public decimal? Id_viagem
        {
            get { return id_viagem; }
            set
            {
                id_viagem = value;
                id_viagemstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_viagemstr;
        public string Id_viagemstr
        {
            get { return id_viagemstr; }
            set
            {
                id_viagemstr = value;
                try
                {
                    id_viagem = decimal.Parse(value);
                }
                catch { id_viagem = null; }
            }
        }
        public string Cd_empresa
        { get; set; }
        private decimal? id_ccustolan;
        public decimal? Id_ccustolan
        {
            get { return id_ccustolan; }
            set
            {
                id_ccustolan = value;
                id_ccustolanstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_ccustolanstr;
        public string Id_ccustolanstr
        {
            get { return id_ccustolanstr; }
            set
            {
                id_ccustolanstr = value;
                try
                {
                    id_ccustolan = decimal.Parse(value);
                }
                catch { id_ccustolan = null; }
            }
        }

        public TRegistro_DespViagem_X_CCusto()
        {
            this.id_landespesa = null;
            this.id_landespesastr = string.Empty;
            this.id_viagem = null;
            this.id_viagemstr = string.Empty;
            this.Cd_empresa = string.Empty;
            this.id_ccustolan = null;
            this.id_ccustolanstr = string.Empty;
        }
    }

    public class TCD_DespViagem_X_CCusto : TDataQuery
    {
        public TCD_DespViagem_X_CCusto() { }

        public TCD_DespViagem_X_CCusto(BancoDados.TObjetoBanco banco) { this.Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + vTop.ToString();

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
                sql.AppendLine("select " + strTop + " a.id_landespesa, a.id_viagem, a.cd_empresa, a.id_ccustolan ");
            else
                sql.AppendLine(" Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from TB_FIN_DespViagem_X_CCusto a ");

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

        public TList_DespViagem_X_CCusto Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            bool podeFecharBco = false;
            TList_DespViagem_X_CCusto lista = new TList_DespViagem_X_CCusto();
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_DespViagem_X_CCusto reg = new TRegistro_DespViagem_X_CCusto();
                    if (!reader.IsDBNull(reader.GetOrdinal("id_landespesa")))
                        reg.Id_landespesa = reader.GetDecimal(reader.GetOrdinal("id_landespesa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_viagem")))
                        reg.Id_viagem = reader.GetDecimal(reader.GetOrdinal("id_viagem"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_ccustolan")))
                        reg.Id_ccustolan = reader.GetDecimal(reader.GetOrdinal("id_ccustolan"));

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

        public string Gravar(TRegistro_DespViagem_X_CCusto val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(4);
            hs.Add("@P_ID_LANDESPESA", val.Id_landespesa);
            hs.Add("@P_ID_VIAGEM", val.Id_viagem);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_CCUSTOLAN", val.Id_ccustolan);

            return this.executarProc("IA_FIN_DESPVIAGEM_X_CCUSTO", hs);
        }

        public string Excluir(TRegistro_DespViagem_X_CCusto val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(4);
            hs.Add("@P_ID_LANDESPESA", val.Id_landespesa);
            hs.Add("@P_ID_VIAGEM", val.Id_viagem);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_CCUSTOLAN", val.Id_ccustolan);

            return this.executarProc("EXCLUI_FIN_DESPVIAGEM_X_CCUSTO", hs);
        }
    }
    #endregion

    #region Viagem_X_Frete
    public class TList_Viagem_X_Frete : List<TRegistro_Viagem_X_Frete>, IComparer<TRegistro_Viagem_X_Frete>
        {
            #region IComparer<TRegistro_Viagem_X_Frete> Members
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

            public TList_Viagem_X_Frete()
            { }

            public TList_Viagem_X_Frete(System.ComponentModel.PropertyDescriptor Prop,
                                         System.Windows.Forms.SortOrder Dir)
            {
                Propriedade = Prop;
                Direcao = Dir;
            }

            private object GetPropertyValue(TRegistro_Viagem_X_Frete value,
                                            string Propriedade)
            {
                System.Reflection.PropertyInfo pInfo =
                    value.GetType().GetProperty(Propriedade);
                return pInfo.GetValue(value, null);
            }

            public int Compare(TRegistro_Viagem_X_Frete x, TRegistro_Viagem_X_Frete y)
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

    
    public class TRegistro_Viagem_X_Frete
        {
            private decimal? id_viagem;
            
            public decimal? Id_viagem
            {
                get { return id_viagem; }
                set
                {
                    id_viagem = value;
                    id_viagemstr = value.HasValue ? value.Value.ToString() : string.Empty;
                }
            }
            private string id_viagemstr;
            
            public string Id_viagemstr
            {
                get { return id_viagemstr; }
                set
                {
                    id_viagemstr = value;
                    try
                    {
                        id_viagem = decimal.Parse(value);
                    }
                    catch
                    { id_viagem = null; }

                }
            }
            
            public string Cd_empresa
            { get; set; }
            
            public string Nm_empresa
            { get; set; }
            
            public decimal? Nr_lanctoCTRC
            { get; set; }


            public TRegistro_Viagem_X_Frete()
            {
                this.id_viagem = null;
                this.id_viagemstr = string.Empty;
                this.Cd_empresa = string.Empty;
                this.Nm_empresa = string.Empty;
                this.Nr_lanctoCTRC = null;

            }
        }

    public class TCD_Viagem_X_Frete : TDataQuery
    {
        public TCD_Viagem_X_Frete()
        { }

        public TCD_Viagem_X_Frete(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + vTop.ToString();

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("select " + strTop + " a.id_viagem, a.cd_empresa, ");
                sql.AppendLine("b.NM_Empresa, a.nr_lanctoctr ");
                

            }
            else
                sql.AppendLine(" Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from tb_frt_viagem_x_frete a ");
            sql.AppendLine("inner join TB_DIV_Empresa b ");
            sql.AppendLine("on a.cd_empresa = b.CD_Empresa ");
           

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

        public TList_Viagem_X_Frete Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            bool podeFecharBco = false;
            TList_Viagem_X_Frete lista = new TList_Viagem_X_Frete();
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_Viagem_X_Frete reg = new TRegistro_Viagem_X_Frete();
                    if (!reader.IsDBNull(reader.GetOrdinal("id_viagem")))
                        reg.Id_viagem = reader.GetDecimal(reader.GetOrdinal("id_viagem"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa"))) 
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NM_Empresa")))
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("NM_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_lanctoctr")))
                        reg.Nr_lanctoCTRC = reader.GetDecimal(reader.GetOrdinal("nr_lanctoctr"));
                     
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

        public string Gravar(TRegistro_Viagem_X_Frete val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(3);
            hs.Add("@P_ID_VIAGEM", val.Id_viagem);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_NR_LANCTOCTR", val.Nr_lanctoCTRC);


            return this.executarProc("IA_FRT_VIAGEM_X_FRETE", hs);
        }

        public string Excluir(TRegistro_Viagem_X_Frete val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(3);
            hs.Add("@P_ID_VIAGEM", val.Id_viagem);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_NR_LANCTOCTR", val.Nr_lanctoCTRC);

            return this.executarProc("EXCLUI_FRT_VIAGEM_X_FRETE", hs);
        }
    }
    #endregion

    #region Viagem_X_Rota
    public class TList_Viagem_X_Rota : List<TRegistro_Viagem_X_Rota>, IComparer<TRegistro_Viagem_X_Rota>
    {
        #region IComparer<TRegistro_Viagem_X_Rota> Members
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

        public TList_Viagem_X_Rota()
        { }

        public TList_Viagem_X_Rota(System.ComponentModel.PropertyDescriptor Prop,
                                     System.Windows.Forms.SortOrder Dir)
        {
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_Viagem_X_Rota value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_Viagem_X_Rota x, TRegistro_Viagem_X_Rota y)
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

    
    public class TRegistro_Viagem_X_Rota
    {
        private decimal? id_viagem;
        
        public decimal? Id_viagem
        {
            get { return id_viagem; }
            set
            {
                id_viagem = value;
                id_viagemstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_viagemstr;
        
        public string Id_viagemstr
        {
            get { return id_viagemstr; }
            set
            {
                id_viagemstr = value;
                try
                {
                    id_viagem = decimal.Parse(value);
                }
                catch
                { id_viagem = null; }

            }
        }
        
        public string Cd_empresa
        { get; set; }
        public string Nm_empresa
        { get; set; }
        private decimal? id_rota;
        
        public decimal? Id_rota
        {
            get { return id_rota; }
            set
            {
                id_rota = value;
                id_rotastr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_rotastr;
        
        public string Id_rotastr
        {
            get { return id_rotastr; }
            set
            {
                id_rotastr = value;
                try
                {
                    id_rota = decimal.Parse(value);
                }
                catch
                { id_rota = null; }

            }
        }
        
        public string Ds_rota
        { get; set; }
        
        public decimal ordem
        { get; set; }

        public TRegistro_Viagem_X_Rota()
        {
            this.id_viagem = null;
            this.id_viagemstr = string.Empty;
            this.Cd_empresa = string.Empty;
            this.Nm_empresa = string.Empty;
            this.id_rota = null;
            this.id_rotastr = string.Empty;
            this.Ds_rota = string.Empty;
            this.ordem = decimal.Zero;

        }
    }

    public class TCD_Viagem_X_Rota : TDataQuery
    {
        public TCD_Viagem_X_Rota()
        { }

        public TCD_Viagem_X_Rota(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + vTop.ToString();

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("select " + strTop + " a.id_viagem, a.cd_empresa, ");
                sql.AppendLine("b.NM_Empresa, a.id_rota, c.ds_rota, a.ordem ");


            }
            else
                sql.AppendLine(" Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from tb_frt_viagem_x_rota a ");
            sql.AppendLine("inner join TB_DIV_Empresa b ");
            sql.AppendLine("on a.cd_empresa = b.CD_Empresa ");
            sql.AppendLine("inner join TB_FRT_Rotafrete c ");
            sql.AppendLine("on a.id_rota = c.id_rota ");


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

        public TList_Viagem_X_Rota Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            bool podeFecharBco = false;
            TList_Viagem_X_Rota lista = new TList_Viagem_X_Rota();
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_Viagem_X_Rota reg = new TRegistro_Viagem_X_Rota();
                    if (!reader.IsDBNull(reader.GetOrdinal("id_viagem")))
                        reg.Id_viagem = reader.GetDecimal(reader.GetOrdinal("id_viagem"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NM_Empresa")))
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("NM_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_rota")))
                        reg.Id_rota = reader.GetDecimal(reader.GetOrdinal("id_rota"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_rota")))
                        reg.Ds_rota = reader.GetString(reader.GetOrdinal("ds_rota"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ordem")))
                        reg.ordem = reader.GetDecimal(reader.GetOrdinal("ordem"));

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

        public string Gravar(TRegistro_Viagem_X_Rota val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(4);
            hs.Add("@P_ID_VIAGEM", val.Id_viagem);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_ROTA", val.Id_rota);
            hs.Add("@P_ORDEM", val.ordem);


            return this.executarProc("IA_FRT_VIAGEM_X_ROTA", hs);
        }

        public string Excluir(TRegistro_Viagem_X_Rota val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(3);
            hs.Add("@P_ID_VIAGEM", val.Id_viagem);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_ROTA", val.Id_rota);

            return this.executarProc("EXCLUI_FRT_VIAGEM_X_ROTA", hs);
        }
    }
    #endregion

    #region Viagem X Adiantamento
    public class TList_AdtoViagem : List<TRegistro_AdtoViagem>, IComparer<TRegistro_AdtoViagem>
    {
        #region IComparer<TRegistro_AdtoViagem> Members
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

        public TList_AdtoViagem()
        { }

        public TList_AdtoViagem(System.ComponentModel.PropertyDescriptor Prop,
                                System.Windows.Forms.SortOrder Dir)
        {
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_AdtoViagem value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_AdtoViagem x, TRegistro_AdtoViagem y)
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

    
    public class TRegistro_AdtoViagem
    {
        private decimal? id_adto;
        
        public decimal? Id_adto
        {
            get { return id_adto; }
            set
            {
                id_adto = value;
                id_adtostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_adtostr;
        
        public string Id_adtostr
        {
            get { return id_adtostr; }
            set
            {
                id_adtostr = value;
                try
                {
                    id_adto = decimal.Parse(value);
                }
                catch
                { id_adto = null; }
            }
        }
        private decimal? id_viagem;
        
        public decimal? Id_viagem
        {
            get { return id_viagem; }
            set
            {
                id_viagem = value;
                id_viagemstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_viagemstr;
        
        public string Id_viagemstr
        {
            get { return id_viagemstr; }
            set
            {
                id_viagemstr = value;
                try
                {
                    id_viagem = decimal.Parse(value);
                }
                catch
                {id_viagem = null;}
            }
        }
        
        public string Cd_empresa
        { get; set; }

        public TRegistro_AdtoViagem()
        {
            this.id_adto = null;
            this.id_adtostr = string.Empty;
            this.id_viagem = null;
            this.id_viagemstr = string.Empty;
            this.Cd_empresa = string.Empty;
        }
    }

    public class TCD_AdtoViagem : TDataQuery
    {
        public TCD_AdtoViagem()
        { }

        public TCD_AdtoViagem(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + vTop.ToString();

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
                sql.AppendLine("select " + strTop + " a.id_adto, a.id_viagem, a.cd_empresa ");
            else
                sql.AppendLine(" Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from tb_frt_adtoviagem a ");

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

        public TList_AdtoViagem Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            bool podeFecharBco = false;
            TList_AdtoViagem lista = new TList_AdtoViagem();
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_AdtoViagem reg = new TRegistro_AdtoViagem();
                    if (!reader.IsDBNull(reader.GetOrdinal("id_viagem")))
                        reg.Id_viagem = reader.GetDecimal(reader.GetOrdinal("id_viagem"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_adto")))
                        reg.Id_adto = reader.GetDecimal(reader.GetOrdinal("id_adto"));

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

        public string Gravar(TRegistro_AdtoViagem val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(3);
            hs.Add("@P_ID_ADTO", val.Id_adto);
            hs.Add("@P_ID_VIAGEM", val.Id_viagem);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);

            return this.executarProc("IA_FRT_ADTOVIAGEM", hs);
        }

        public string Excluir(TRegistro_AdtoViagem val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(3);
            hs.Add("@P_ID_ADTO", val.Id_adto);
            hs.Add("@P_ID_VIAGEM", val.Id_viagem);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);

            return this.executarProc("EXCLUI_FRT_ADTOVIAGEM", hs);
        }
    }
    #endregion
}

 

