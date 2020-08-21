using System;
using System.Collections.Generic;
using System.Text;

namespace CamadaDados.PostoCombustivel
{
    #region Convenio
    public class TList_Convenio : List<TRegistro_Convenio>, IComparer<TRegistro_Convenio>
    {
        #region IComparer<TRegistro_Convenio> Members
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

        public TList_Convenio()
        { }

        public TList_Convenio(System.ComponentModel.PropertyDescriptor Prop,
                              System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_Convenio value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_Convenio x, TRegistro_Convenio y)
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
    
    public class TRegistro_Convenio
    {
        private decimal? id_convenio;
        public decimal? Id_convenio
        {
            get { return id_convenio; }
            set
            {
                id_convenio = value;
                id_conveniostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_conveniostr;
        public string Id_conveniostr
        {
            get { return id_conveniostr; }
            set
            {
                id_conveniostr = value;
                try
                {
                    id_convenio = decimal.Parse(value);
                }
                catch
                { id_convenio = null; }
            }
        }
        public string DS_convenio
        { get; set; }
        public string Cd_empresa
        { get; set; }
        public string Nm_empresa
        { get; set; }
        public string Cd_condpgto
        { get; set; }
        public string Ds_condpgto
        { get; set; }
        public decimal Qt_parcelas
        { get; set; }
        public decimal Qt_diasdesdobro
        { get; set; }
        public string Tp_duplicata
        { get; set; }
        public string Ds_tpduplicata
        { get; set; }
        public string Tp_movduplicata
        { get; set; }
        public string Cd_historicodup
        { get; set; }
        public string Ds_historicodup
        { get; set; }
        private decimal? id_config_boleto;
        public decimal? Id_config_boleto
        {
            get { return id_config_boleto; }
            set
            {
                id_config_boleto = value;
                id_config_boletostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_config_boletostr;
        public string Id_config_boletostr
        {
            get { return id_config_boletostr; }
            set
            {
                id_config_boletostr = value;
                try
                {
                    id_config_boleto = decimal.Parse(value);
                }
                catch { id_config_boleto = null; }
            }
        }
        public string Ds_config_boleto
        { get; set; }
        private decimal? tp_docto;
        public decimal? Tp_docto
        {
            get { return tp_docto; }
            set
            {
                tp_docto = value;
                tp_doctostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string tp_doctostr;
        public string Tp_doctostr
        {
            get { return tp_doctostr; }
            set
            {
                tp_doctostr = value;
                try
                {
                    tp_docto = decimal.Parse(value);
                }
                catch
                { tp_docto = null; }
            }
        }
        public string Ds_tpdocto
        { get; set; }
        public string Cd_portador
        { get; set; }
        public string Ds_portador
        { get; set; }
        private DateTime? dt_convenio;
        public DateTime? Dt_convenio
        {
            get { return dt_convenio; }
            set
            {
                dt_convenio = value;
                dt_conveniostr = value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty;
            }
        }
        private string dt_conveniostr;
        public string Dt_conveniostr
        {
            get
            {
                try
                {
                    return DateTime.Parse(dt_conveniostr).ToString("dd/MM/yyyy");
                }
                catch
                { return string.Empty; }
            }
            set
            {
                dt_conveniostr = value;
                try
                {
                    dt_convenio = DateTime.Parse(value);
                }
                catch
                { dt_convenio = null; }
            }
        }
        public decimal Diasvalidade
        { get; set; }
        private string tp_acresdesc;
        public string Tp_acresdesc
        {
            get { return tp_acresdesc; }
            set
            {
                tp_acresdesc = value;
                if (value.Trim().ToUpper().Equals("A"))
                    tipo_acresdesc = "ACRESCIMO";
                else if (value.Trim().ToUpper().Equals("D"))
                    tipo_acresdesc = "DESCONTO";
            }
        }
        private string tipo_acresdesc;
        public string Tipo_acresdesc
        {
            get { return tipo_acresdesc; }
            set
            {
                tipo_acresdesc = value;
                if (value.Trim().ToUpper().Equals("ACRESCIMO"))
                    tp_acresdesc = "A";
                else if (value.Trim().ToUpper().Equals("DESCONTO"))
                    tp_acresdesc = "D";
            }
        }
        private string tp_desconto;
        public string Tp_desconto
        {
            get { return tp_desconto; }
            set
            {
                tp_desconto = value;
                if (value.Trim().ToUpper().Equals("P"))
                    tipo_desconto = "PERCENTUAL";
                else if (value.Trim().ToUpper().Equals("V"))
                    tipo_desconto = "VALOR";
            }
        }
        private string tipo_desconto;
        public string Tipo_desconto
        {
            get { return tipo_desconto; }
            set
            {
                tipo_desconto = value;
                if (value.Trim().ToUpper().Equals("PERCENTUAL"))
                    tp_desconto = "P";
                else if (value.Trim().ToUpper().Equals("VALOR"))
                    tp_desconto = "V";
            }
        }
        private string st_descvlunit;
        public string St_descvlunit
        {
            get { return st_descvlunit; }
            set
            {
                st_descvlunit = value;
                st_descvlunitbool = value.Trim().ToUpper().Equals("S");
            }
        }
        private bool st_descvlunitbool;
        public bool St_descvlunitbool
        {
            get { return st_descvlunitbool; }
            set
            {
                st_descvlunitbool = value;
                st_descvlunit = value ? "S" : "N";
            }
        }
        public decimal Desconto
        { get; set; }
        public decimal Diavencto
        { get; set; }
        public decimal DiaFechamentoFat
        { get; set; }
        public decimal Qtd_duppendente
        { get; set; }
        private string periodofatura;
        public string Periodofatura
        {
            get { return periodofatura; }
            set
            {
                periodofatura = value;
                if (value.Trim().ToUpper().Equals("D"))
                    periodofaturastr = "DIARIO";
                if (value.Trim().ToUpper().Equals("S"))
                    periodofaturastr = "SEMANAL";
                else if (value.Trim().ToUpper().Equals("Q"))
                    periodofaturastr = "QUINZENAL";
                else if (value.Trim().ToUpper().Equals("M"))
                    periodofaturastr = "MENSAL";
            }
        }
        private string periodofaturastr;
        public string Periodofaturastr
        {
            get { return periodofaturastr; }
            set
            {
                periodofaturastr = value;
                if (value.Trim().ToUpper().Equals("DIARIO"))
                    periodofatura = "D";
                if (value.Trim().ToUpper().Equals("SEMANAL"))
                    periodofatura = "S";
                else if (value.Trim().ToUpper().Equals("QUINZENAL"))
                    periodofatura = "Q";
                else if (value.Trim().ToUpper().Equals("MENSAL"))
                    periodofatura = "M";
            }
        }
        public decimal Diasemana
        { get; set; }
        public string Diasemanastr
        {
            get { return Diasemana.ToString(); }
            set { Diasemana = string.IsNullOrEmpty(value) ? decimal.Zero : decimal.Parse(value); }
        }
        public string Dia_semana
        {
            get
            {
                if (Diasemana.Equals(0))
                    return "SEGUNDA-FEIRA";
                if(Diasemana.Equals(1))
                    return "TERÇA-FEIRA";
                else if(Diasemana.Equals(2))
                    return "QUARTA-FEIRA";
                else if(Diasemana.Equals(3))
                    return "QUINTA-FEIRA";
                else if(Diasemana.Equals(4))
                    return "SEXTA-FEIRA";
                else if(Diasemana.Equals(5))
                    return "SABADO";
                else if(Diasemana.Equals(6))
                    return "DOMINGO";
                else return string.Empty;
            }
        }
        private string st_utilizardiascondpgto;
        public string St_utilizardiascondpgto
        {
            get { return st_utilizardiascondpgto; }
            set
            {
                st_utilizardiascondpgto = value;
                st_utilizardiascondpgtobool = value.Trim().ToUpper().Equals("S");
            }
        }
        private bool st_utilizardiascondpgtobool;
        public bool St_utilizardiascondpgtobool
        {
            get { return st_utilizardiascondpgtobool; }
            set
            {
                st_utilizardiascondpgtobool = value;
                st_utilizardiascondpgto = value ? "S" : "N";
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
                if (St_registro.Trim().ToUpper().Equals("A") &&
                    (Diasvalidade > decimal.Zero) &&
                    (dt_convenio.HasValue ? dt_convenio.Value.AddDays(Convert.ToDouble(Diasvalidade)) < DateTime.Parse(DateTime.Now.ToString("dd/MM/yyyy")) : false))
                    return "EXPIRADO";
                if (St_registro.Trim().ToUpper().Equals("A"))
                    return "ATIVO";
                else if (St_registro.Trim().ToUpper().Equals("E"))
                    return "ENCERRADO";
                else return string.Empty;
            }
        }
        public TList_Convenio_Clifor lClifor
        { get; set; }
        public TList_Convenio_Clifor lCliforDel
        { get; set; }

        public TRegistro_Convenio()
        {
            DS_convenio = string.Empty;
            id_convenio = null;
            id_conveniostr = string.Empty;
            Cd_empresa = string.Empty;
            Nm_empresa = string.Empty;
            Cd_condpgto = string.Empty;
            Ds_condpgto = string.Empty;
            Qt_parcelas = decimal.Zero;
            Qt_diasdesdobro = decimal.Zero;
            Tp_duplicata = string.Empty;
            Ds_tpduplicata = string.Empty;
            Tp_movduplicata = string.Empty;
            Cd_historicodup = string.Empty;
            Ds_historicodup = string.Empty;
            id_config_boleto = null;
            id_config_boletostr = string.Empty;
            Ds_config_boleto = string.Empty;
            tp_docto = null;
            tp_doctostr = string.Empty;
            Ds_tpdocto = string.Empty;
            Cd_portador = string.Empty;
            Ds_portador = string.Empty;
            dt_convenio = DateTime.Now;
            dt_conveniostr = DateTime.Now.ToString("dd/MM/yyyy");
            Diasvalidade = decimal.Zero;
            tp_acresdesc = string.Empty;
            tipo_acresdesc = string.Empty;
            tp_desconto = string.Empty;
            tipo_desconto = string.Empty;
            Desconto = decimal.Zero;
            st_descvlunit = "N";
            st_descvlunitbool = false;
            Diavencto = decimal.Zero;
            DiaFechamentoFat = decimal.Zero;
            Qtd_duppendente = decimal.Zero;
            periodofatura = string.Empty;
            periodofaturastr = string.Empty;
            Diasemana = decimal.Zero;
            st_utilizardiascondpgto = "N";
            st_utilizardiascondpgtobool = false;
            Ds_observacao = string.Empty;
            St_registro = "A";

            lClifor = new TList_Convenio_Clifor();
            lCliforDel = new TList_Convenio_Clifor();
        }
    }

    public class TCD_Convenio : TDataQuery
    {
        public TCD_Convenio()
        { }

        public TCD_Convenio(BancoDados.TObjetoBanco banco)
        { Banco_Dados = banco; }

        private string SqlCodeBuscaConv(string Cd_empresa,
                                        string Cd_clifor,
                                        string Cd_endereco,
                                        bool St_entregafutura,
                                        List<string> lProduto)
        {
            StringBuilder sql = new StringBuilder();
            string operador = string.Empty;
            lProduto.ForEach(p =>
                {
                    if(!string.IsNullOrEmpty(operador))
                        sql.AppendLine(operador);
                    sql.AppendLine(SqlCodeBusca(
                        new Utils.TpBusca[]
                        {
                            new Utils.TpBusca()
                            {
                                vNM_Campo = "a.cd_empresa",
                                vOperador = "=",
                                vVL_Busca = "'" + Cd_empresa.Trim() + "'"
                            },
                            new Utils.TpBusca()
                            {
                                vNM_Campo = "isnull(a.st_registro, 'A')",
                                vOperador = "=",
                                vVL_Busca = "'A'"
                            },
                            new Utils.TpBusca()
                            {
                                vNM_Campo = "CONVERT(datetime, floor(convert(decimal(30,10), case when DiasValidade = 0 then getdate() else DATEADD(DAY, DiasValidade, DT_Convenio) end)))",
                                vOperador = ">=",
                                vVL_Busca = "CONVERT(datetime, floor(convert(decimal(30,10), getdate())))"
                            },
                            new Utils.TpBusca()
                            {
                                vNM_Campo = "isnull(f.st_entregafutura, 'N')",
                                vOperador = St_entregafutura ? "=" : "<>",
                                vVL_Busca = "'S'"
                            }
                        }, 0, string.Empty));
                    sql.AppendLine("and exists(select 1 from VTB_PDC_Convenio_X_Clifor x ");
                    sql.AppendLine("            where x.CD_Empresa = a.CD_Empresa ");
                    sql.AppendLine("            and x.ID_Convenio = a.ID_Convenio ");
                    sql.AppendLine("            and ISNULL(x.ST_Registro, 'A') <> 'C' ");
                    sql.AppendLine("            and (case when x.qtd_convenio > 0 then x.qtd_convenio - x.qtd_vendida else 1 end > 0) ");
                    sql.AppendLine("            and x.CD_Clifor = '" + Cd_clifor.Trim() + "'");
                    sql.AppendLine("            and x.CD_Endereco = '" + Cd_endereco.Trim() + "'");
                    sql.AppendLine("            and x.CD_Produto = '" + p.Trim() + "')");

                    operador = "intersect";
                });
            sql.AppendLine("order by f.ds_portador ");
            return sql.ToString();
        }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + vTop.ToString();

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("select " + strTop + " a.id_convenio, a.cd_empresa, ");
                sql.AppendLine("b.NM_Empresa, a.cd_condpgto, c.ds_condpgto, ");
                sql.AppendLine("c.Qt_parcelas, c.Qt_diasdesdobro, ");
                sql.AppendLine("a.dt_convenio, a.diasvalidade, a.st_descvlunit, ");
                sql.AppendLine("a.ds_observacao, a.st_registro, ");
                sql.AppendLine("a.tp_duplicata, d.ds_tpduplicata, d.tp_mov, a.qtd_duppendente, ");
                sql.AppendLine("a.tp_docto, e.ds_tpdocto, a.diafechamentofat, ");
                sql.AppendLine("a.cd_portador, f.ds_portador, a.tp_acresdesc, ");
                sql.AppendLine("a.tp_desconto, a.desconto, a.diavencto, a.ds_convenio, ");
                sql.AppendLine("a.periodofatura, a.diasemana, a.st_utilizardiascondpgto, ");
                sql.AppendLine("d.id_config, h.ds_config, d.cd_historico_dup, g.ds_historico ");
            }
            else
                sql.AppendLine(" Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from tb_pdc_convenio a ");
            sql.AppendLine("inner join TB_DIV_Empresa b ");
            sql.AppendLine("on a.cd_empresa = b.CD_Empresa ");
            sql.AppendLine("left outer join TB_FIN_CondPgto c ");
            sql.AppendLine("on a.cd_condpgto = c.cd_condpgto ");
            sql.AppendLine("left outer join TB_FIN_TpDuplicata d ");
            sql.AppendLine("on a.tp_duplicata = d.tp_duplicata ");
            sql.AppendLine("left outer join TB_FIN_TpDocto_dup e ");
            sql.AppendLine("on a.tp_docto = e.tp_docto ");
            sql.AppendLine("left outer join TB_FIN_Portador f ");
            sql.AppendLine("on a.cd_portador = f.cd_portador ");
            sql.AppendLine("left outer join TB_FIN_Historico g ");
            sql.AppendLine("on d.cd_historico_dup = g.cd_historico ");
            sql.AppendLine("left outer join TB_COB_CfgBanco h ");
            sql.AppendLine("on d.id_config = h.id_config ");

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

        public TList_Convenio Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            bool podeFecharBco = false;
            TList_Convenio lista = new TList_Convenio();
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_Convenio reg = new TRegistro_Convenio();
                    if (!(reader.IsDBNull(reader.GetOrdinal("ds_convenio"))))
                        reg.DS_convenio = reader.GetString(reader.GetOrdinal("ds_convenio"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("id_convenio"))))
                        reg.Id_convenio = reader.GetDecimal(reader.GetOrdinal("id_convenio"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("cd_empresa"))))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("NM_Empresa"))))
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("NM_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_condpgto")))
                        reg.Cd_condpgto = reader.GetString(reader.GetOrdinal("cd_condpgto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_condpgto")))
                        reg.Ds_condpgto = reader.GetString(reader.GetOrdinal("ds_condpgto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("qt_parcelas")))
                        reg.Qt_parcelas = reader.GetDecimal(reader.GetOrdinal("qt_parcelas"));
                    if (!reader.IsDBNull(reader.GetOrdinal("qt_diasdesdobro")))
                        reg.Qt_diasdesdobro = reader.GetDecimal(reader.GetOrdinal("qt_diasdesdobro"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_duplicata")))
                        reg.Tp_duplicata = reader.GetString(reader.GetOrdinal("tp_duplicata"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_tpduplicata")))
                        reg.Ds_tpduplicata = reader.GetString(reader.GetOrdinal("ds_tpduplicata"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_mov")))
                        reg.Tp_movduplicata = reader.GetString(reader.GetOrdinal("tp_mov"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_historico_dup")))
                        reg.Cd_historicodup = reader.GetString(reader.GetOrdinal("cd_historico_dup"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_historico")))
                        reg.Ds_historicodup = reader.GetString(reader.GetOrdinal("ds_historico"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_config")))
                        reg.Id_config_boleto = reader.GetDecimal(reader.GetOrdinal("id_config"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_config")))
                        reg.Ds_config_boleto = reader.GetString(reader.GetOrdinal("ds_config"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_docto")))
                        reg.Tp_docto = reader.GetDecimal(reader.GetOrdinal("tp_docto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_tpdocto")))
                        reg.Ds_tpdocto = reader.GetString(reader.GetOrdinal("ds_tpdocto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_portador")))
                        reg.Cd_portador = reader.GetString(reader.GetOrdinal("cd_portador"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_portador")))
                        reg.Ds_portador = reader.GetString(reader.GetOrdinal("ds_portador"));
                    if (!reader.IsDBNull(reader.GetOrdinal("dt_convenio")))
                        reg.Dt_convenio = reader.GetDateTime(reader.GetOrdinal("dt_convenio"));
                    if (!reader.IsDBNull(reader.GetOrdinal("diasvalidade")))
                        reg.Diasvalidade = reader.GetDecimal(reader.GetOrdinal("diasvalidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_acresdesc")))
                        reg.Tp_acresdesc = reader.GetString(reader.GetOrdinal("tp_acresdesc"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_desconto")))
                        reg.Tp_desconto = reader.GetString(reader.GetOrdinal("tp_desconto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("desconto")))
                        reg.Desconto = reader.GetDecimal(reader.GetOrdinal("desconto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_descvlunit")))
                        reg.St_descvlunit = reader.GetString(reader.GetOrdinal("st_descvlunit"));
                    if (!reader.IsDBNull(reader.GetOrdinal("diavencto")))
                        reg.Diavencto = reader.GetDecimal(reader.GetOrdinal("diavencto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("diafechamentoFAT")))
                        reg.DiaFechamentoFat = reader.GetDecimal(reader.GetOrdinal("diafechamentoFAT"));
                    if (!reader.IsDBNull(reader.GetOrdinal("qtd_duppendente")))
                        reg.Qtd_duppendente = reader.GetDecimal(reader.GetOrdinal("qtd_duppendente"));
                    if (!reader.IsDBNull(reader.GetOrdinal("periodofatura")))
                        reg.Periodofatura = reader.GetString(reader.GetOrdinal("periodofatura"));
                    if (!reader.IsDBNull(reader.GetOrdinal("diasemana")))
                        reg.Diasemana = reader.GetDecimal(reader.GetOrdinal("diasemana"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_utilizardiascondpgto")))
                        reg.St_utilizardiascondpgto = reader.GetString(reader.GetOrdinal("st_utilizardiascondpgto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_observacao")))
                        reg.Ds_observacao = reader.GetString(reader.GetOrdinal("ds_observacao"));
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

        public TList_Convenio Select(string Cd_empresa,
                                     string Cd_clifor,
                                     string Cd_endereco,
                                     bool St_entregafutura,
                                     List<string> lProduto)
        {
            bool podeFecharBco = false;
            TList_Convenio lista = new TList_Convenio();
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = ExecutarBusca(SqlCodeBuscaConv(Cd_empresa, Cd_clifor, Cd_endereco, St_entregafutura, lProduto));
            try
            {
                while (reader.Read())
                {
                    TRegistro_Convenio reg = new TRegistro_Convenio();
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_convenio")))
                        reg.DS_convenio = reader.GetString(reader.GetOrdinal("ds_convenio"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("id_convenio"))))
                        reg.Id_convenio = reader.GetDecimal(reader.GetOrdinal("id_convenio"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("cd_empresa"))))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("NM_Empresa"))))
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("NM_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_condpgto")))
                        reg.Cd_condpgto = reader.GetString(reader.GetOrdinal("cd_condpgto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_condpgto")))
                        reg.Ds_condpgto = reader.GetString(reader.GetOrdinal("ds_condpgto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_duplicata")))
                        reg.Tp_duplicata = reader.GetString(reader.GetOrdinal("tp_duplicata"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_tpduplicata")))
                        reg.Ds_tpduplicata = reader.GetString(reader.GetOrdinal("ds_tpduplicata"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_config")))
                        reg.Id_config_boleto = reader.GetDecimal(reader.GetOrdinal("id_config"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_docto")))
                        reg.Tp_docto = reader.GetDecimal(reader.GetOrdinal("tp_docto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_tpdocto")))
                        reg.Ds_tpdocto = reader.GetString(reader.GetOrdinal("ds_tpdocto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_portador")))
                        reg.Cd_portador = reader.GetString(reader.GetOrdinal("cd_portador"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_portador")))
                        reg.Ds_portador = reader.GetString(reader.GetOrdinal("ds_portador"));
                    if (!reader.IsDBNull(reader.GetOrdinal("dt_convenio")))
                        reg.Dt_convenio = reader.GetDateTime(reader.GetOrdinal("dt_convenio"));
                    if (!reader.IsDBNull(reader.GetOrdinal("diasvalidade")))
                        reg.Diasvalidade = reader.GetDecimal(reader.GetOrdinal("diasvalidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_acresdesc")))
                        reg.Tp_acresdesc = reader.GetString(reader.GetOrdinal("tp_acresdesc"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_desconto")))
                        reg.Tp_desconto = reader.GetString(reader.GetOrdinal("tp_desconto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("desconto")))
                        reg.Desconto = reader.GetDecimal(reader.GetOrdinal("desconto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_descvlunit")))
                        reg.St_descvlunit = reader.GetString(reader.GetOrdinal("st_descvlunit"));
                    if (!reader.IsDBNull(reader.GetOrdinal("diavencto")))
                        reg.Diavencto = reader.GetDecimal(reader.GetOrdinal("diavencto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("diafechamentoFAT")))
                        reg.DiaFechamentoFat = reader.GetDecimal(reader.GetOrdinal("diafechamentoFAT"));
                    if (!reader.IsDBNull(reader.GetOrdinal("qtd_duppendente")))
                        reg.Qtd_duppendente = reader.GetDecimal(reader.GetOrdinal("qtd_duppendente"));
                    if (!reader.IsDBNull(reader.GetOrdinal("periodofatura")))
                        reg.Periodofatura = reader.GetString(reader.GetOrdinal("periodofatura"));
                    if (!reader.IsDBNull(reader.GetOrdinal("diasemana")))
                        reg.Diasemana = reader.GetDecimal(reader.GetOrdinal("diasemana"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_utilizardiascondpgto")))
                        reg.St_utilizardiascondpgto = reader.GetString(reader.GetOrdinal("st_utilizardiascondpgto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_observacao")))
                        reg.Ds_observacao = reader.GetString(reader.GetOrdinal("ds_observacao"));
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

        public string Gravar(TRegistro_Convenio val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(21);
            hs.Add("@P_ID_CONVENIO", val.Id_convenio);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_CD_CONDPGTO", val.Cd_condpgto);
            hs.Add("@P_TP_DUPLICATA", val.Tp_duplicata);
            hs.Add("@P_TP_DOCTO", val.Tp_docto);
            hs.Add("@P_CD_PORTADOR", val.Cd_portador);
            hs.Add("@P_DT_CONVENIO", val.Dt_convenio);
            hs.Add("@P_DIASVALIDADE", val.Diasvalidade);
            hs.Add("@P_TP_ACRESDESC", val.Tp_acresdesc);
            hs.Add("@P_TP_DESCONTO", val.Tp_desconto);
            hs.Add("@P_DESCONTO", val.Desconto);
            hs.Add("@P_ST_DESCVLUNIT", val.St_descvlunit);
            hs.Add("@P_DIAVENCTO", val.Diavencto);
            hs.Add("@P_DIAFECHAMENTOFAT", val.DiaFechamentoFat);
            hs.Add("@P_QTD_DUPPENDENTE", val.Qtd_duppendente);
            hs.Add("@P_PERIODOFATURA", val.Periodofatura);
            hs.Add("@P_DIASEMANA", val.Diasemana);
            hs.Add("@P_ST_UTILIZARDIASCONDPGTO", val.St_utilizardiascondpgto);
            hs.Add("@P_DS_OBSERVACAO", val.Ds_observacao);
            hs.Add("@P_ST_REGISTRO", val.St_registro);
            hs.Add("@P_DS_CONVENIO", val.DS_convenio);

            return executarProc("IA_PDC_CONVENIO", hs);
        }

        public string Excluir(TRegistro_Convenio val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(2);
            hs.Add("@P_ID_CONVENIO", val.Id_convenio);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);

            return executarProc("EXCLUI_PDC_CONVENIO", hs);
        }
    }
    #endregion

    #region Clifor Convenio
    public class TList_Convenio_Clifor : List<TRegistro_Convenio_Clifor>, IComparer<TRegistro_Convenio_Clifor>
    {
        #region IComparer<TRegistro_Convenio_Clifor> Members
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

        public TList_Convenio_Clifor()
        { }

        public TList_Convenio_Clifor(System.ComponentModel.PropertyDescriptor Prop,
                                     System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_Convenio_Clifor value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_Convenio_Clifor x, TRegistro_Convenio_Clifor y)
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
    
    public class TRegistro_Convenio_Clifor
    {
        private decimal? id_convenio;
        public decimal? Id_convenio
        {
            get { return id_convenio; }
            set
            {
                id_convenio = value;
                id_conveniostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_conveniostr;
        public string Id_conveniostr
        {
            get { return id_conveniostr; }
            set
            {
                id_conveniostr = value;
                try
                {
                    id_convenio = decimal.Parse(value);
                }
                catch
                { id_convenio = null; }

            }
        }
        public string Ds_convenio
        { get; set; }
        public string Cd_empresa
        { get; set; }
        public string Nm_empresa
        { get; set; }
        public string Cd_clifor
        { get; set; }
        public string Nm_clifor
        { get; set; }
        public string Nr_cgc_cpf
        { get; set; }
        public string Cd_endereco
        { get; set; }
        public string Ds_endereco
        { get; set; }
        public string Ds_cidade
        { get; set; }
        public string Insc_estadual
        { get; set; }
        public string Cd_produto
        { get; set; }
        public string Ds_produto
        { get; set; }
        private string st_placaconveniada;
        public string St_placaconveniada
        {
            get { return st_placaconveniada; }
            set
            {
                st_placaconveniada = value;
                st_placaconveniadabool = value.Trim().ToUpper().Equals("S");
            }
        }
        private bool st_placaconveniadabool;
        public bool St_placaconveniadabool
        {
            get { return st_placaconveniadabool; }
            set
            {
                st_placaconveniadabool = value;
                st_placaconveniada = value ? "S" : "N";
            }
        }
        private string st_motconveniado;
        public string St_motconveniado
        {
            get { return st_motconveniado; }
            set
            {
                st_motconveniado = value;
                st_motconveniadobool = value.Trim().ToUpper().Equals("S");
            }
        }
        private bool st_motconveniadobool;
        public bool St_motconveniadobool
        {
            get { return st_motconveniadobool; }
            set
            {
                st_motconveniadobool = value;
                st_motconveniado = value ? "S" : "N";
            }
        }
        private string st_faturardireto;
        public string St_faturardireto
        {
            get { return st_faturardireto; }
            set
            {
                st_faturardireto = value;
                st_faturardiretobool = value.Trim().ToUpper().Equals("S");
            }
        }
        private bool st_faturardiretobool;
        public bool St_faturardiretobool
        {
            get { return st_faturardiretobool; }
            set
            {
                st_faturardiretobool = value;
                st_faturardireto = value ? "S" : "N";
            }
        }
        public decimal Vl_unitario { get; set; }
        private string tp_acresdesc = string.Empty;
        public string Tp_acresdesc
        {
            get { return tp_acresdesc; }
            set
            {
                tp_acresdesc = value;
                if (value.Trim().ToUpper().Equals("A"))
                    tipo_acresdesc = "ACRESCIMO";
                else if (value.Trim().ToUpper().Equals("D"))
                    tipo_acresdesc = "DESCONTO";
            }
        }
        private string tipo_acresdesc = string.Empty;
        public string Tipo_acresdesc
        {
            get { return tipo_acresdesc; }
            set
            {
                tipo_acresdesc = value;
                if (value.Trim().ToUpper().Equals("ACRESCIMO"))
                    tp_acresdesc = "A";
                else if (value.Trim().ToUpper().Equals("DESCONTO"))
                    tp_acresdesc = "D";
            }
        }
        private string tp_desconto = string.Empty;
        public string Tp_desconto
        {
            get { return tp_desconto; }
            set
            {
                tp_desconto = value;
                if (value.Trim().ToUpper().Equals("P"))
                    tipo_desconto = "PERCENTUAL";
                else if (value.Trim().ToUpper().Equals("V"))
                    tipo_desconto = "VALOR";
            }
        }
        private string tipo_desconto = string.Empty;
        public string Tipo_desconto
        {
            get { return tipo_desconto; }
            set
            {
                tipo_desconto = value;
                if (value.Trim().ToUpper().Equals("PERCENTUAL"))
                    tp_desconto = "P";
                else if (value.Trim().ToUpper().Equals("VALOR"))
                    tp_desconto = "V";
            }
        }
        public decimal Desconto { get; set; } = decimal.Zero;
        private string tp_preco;
        public string Tp_preco
        {
            get { return tp_preco; }
            set
            {
                tp_preco = value;
                if (value.Trim().ToUpper().Equals("N"))
                    tipo_preco = "NORMAL";
                else if (value.Trim().ToUpper().Equals("A"))
                    tipo_preco = "ANP";
                else if (value.Trim().ToUpper().Equals("C"))
                    tipo_preco = "CUSTO";
            }
        }
        private string tipo_preco;
        public string Tipo_preco
        {
            get { return tipo_preco; }
            set
            {
                tipo_preco = value;
                if (value.Trim().ToUpper().Equals("NORMAL"))
                    tp_preco = "N";
                else if (value.Trim().ToUpper().Equals("ANP"))
                    tp_preco = "A";
                else if (value.Trim().ToUpper().Equals("CUSTO"))
                    tp_preco = "C";
            }
        }
        private string tp_faturamento;
        public string Tp_faturamento
        {
            get { return tp_faturamento; }
            set
            {
                tp_faturamento = value;
                if (value.Trim().ToUpper().Equals("CF"))
                    tipo_faturamento = "CUPOM FISCAL";
                else if (value.Trim().ToUpper().Equals("NF"))
                    tipo_faturamento = "NOTA FISCAL";
            }
        }
        private string tipo_faturamento;
        public string Tipo_faturamento
        {
            get { return tipo_faturamento; }
            set
            {
                tipo_faturamento = value;
                if (value.Trim().ToUpper().Equals("CUPOM FISCAL"))
                    tp_faturamento = "CF";
                else if (value.Trim().ToUpper().Equals("NOTA FISCAL"))
                    tp_faturamento = "NF";
            }
        }
        public decimal Qtd_convenio
        { get; set; }
        public string CD_vendedor
        { get; set; }
        public string Nm_vendedor
        { get; set; }
        private decimal? id_config;
        public decimal? Id_config
        {
            get { return id_config; }
            set
            {
                id_config = value;
                id_configstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_configstr;
        public string Id_configstr
        {
            get { return id_configstr; }
            set
            {
                id_configstr = value;
                try
                {
                    id_config = decimal.Parse(value);
                }
                catch { id_config = null; }
            }
        }
        public string Ds_config
        { get; set; }
        public string Cd_portador
        { get; set; }
        public string Ds_portador
        { get; set; }
        public decimal Qtd_vendida
        { get; set; }
        public decimal Qtd_saldo
        { get { return Qtd_convenio > decimal.Zero ? Qtd_convenio - Qtd_vendida : decimal.Zero; } }
        private string st_exigirrequisicao;
        public string St_exigirrequisicao
        {
            get { return st_exigirrequisicao; }
            set
            {
                st_exigirrequisicao = value;
                st_exigirrequisicaobool = value.Trim().ToUpper().Equals("S");
            }
        }
        private bool st_exigirrequisicaobool;
        public bool St_exigirrequisicaobool
        {
            get { return st_exigirrequisicaobool; }
            set
            {
                st_exigirrequisicaobool = value;
                st_exigirrequisicao = value ? "S" : "N";
            }
        }
        private string st_exigirnomemot;
        public string St_exigirnomemot
        {
            get { return st_exigirnomemot; }
            set
            {
                st_exigirnomemot = value;
                st_exigirnomemotbool = value.Trim().ToUpper().Equals("S");
            }
        }
        private bool st_exigirnomemotbool;
        public bool St_exigirnomemotbool
        {
            get { return st_exigirnomemotbool; }
            set
            {
                st_exigirnomemotbool = value;
                st_exigirnomemot = value ? "S" : "N";
            }
        }
        private string tp_qt_vl;
        public string Tp_qt_vl
        {
            get { return tp_qt_vl; }
            set
            {
                tp_qt_vl = value;
                if (value.Trim().Equals("Q"))
                    tipo_qt_vl = "UN";
                else if (value.Trim().Equals("V"))
                    tipo_qt_vl = "R$";
                else if (value.Trim().Equals("P"))
                    tipo_qt_vl = "%";
            }
        }
        private string tipo_qt_vl;
        public string Tipo_qt_vl
        {
            get { return tipo_qt_vl; }
            set
            {
                tipo_qt_vl = value;
                if (value.Trim().Equals("UN"))
                    tp_qt_vl = "Q";
                else if (value.Trim().Equals("R$"))
                    tp_qt_vl = "V";
                else if (value.Trim().Equals("%"))
                    tp_qt_vl = "P";
            }
        }
        public decimal Base_calc_fid
        { get; set; }
        public decimal Qt_pontos_fid
        { get; set; }
        public decimal Nr_diasvalidade_fid
        { get; set; }
        private string tp_pontos_fid;
        public string Tp_pontos_fid
        {
            get { return tp_pontos_fid; }
            set
            {
                tp_pontos_fid = value;
                if (value.Trim().ToUpper().Equals("C"))
                    tipo_pontos_fid = "CLIENTE";
                else if (value.Trim().ToUpper().Equals("P"))
                    tipo_pontos_fid = "PLACA";
                else if (value.Trim().ToUpper().Equals("M"))
                    tipo_pontos_fid = "MOTORISTA";
            }
        }
        private string tipo_pontos_fid;
        public string Tipo_pontos_fid
        {
            get { return tipo_pontos_fid; }
            set
            {
                tipo_pontos_fid = value;
                if (value.Trim().ToUpper().Equals("CLIENTE"))
                    tp_pontos_fid = "C";
                else if (value.Trim().ToUpper().Equals("PLACA"))
                    tp_pontos_fid = "P";
                else if (value.Trim().ToUpper().Equals("MOTORISTA"))
                    tp_pontos_fid = "M";
            }
        }
        public string Ds_msgVale
        { get; set; }
        public string St_registro
        { get; set; } 
        public bool St_processar
        { get; set; }
        public TList_Convenio_Placa lPlaca
        { get; set; }
        public TList_Convenio_Placa lPlacaDel
        { get; set; }
        public TList_convenio_Motorista lMotorista
        { get; set; }
        public TList_convenio_Motorista lMotDel
        { get; set; }

        public TRegistro_Convenio_Clifor()
        {
            id_convenio = null;
            id_conveniostr = string.Empty;
            Ds_convenio = string.Empty;
            Cd_empresa = string.Empty;
            CD_vendedor = string.Empty;
            Nm_vendedor = string.Empty;
            Nm_empresa = string.Empty;
            Cd_clifor = string.Empty;
            Nm_clifor = string.Empty;
            Nr_cgc_cpf = string.Empty;
            Cd_endereco = string.Empty;
            Ds_endereco = string.Empty;
            Ds_cidade = string.Empty;
            Insc_estadual = string.Empty;
            Cd_produto = string.Empty;
            Ds_produto = string.Empty;
            id_config = null;
            id_configstr = string.Empty;
            Ds_config = string.Empty;
            st_faturardireto = "N";
            st_faturardiretobool = false;
            st_motconveniado = "N";
            st_motconveniadobool = false;
            st_placaconveniada = "N";
            st_placaconveniadabool = false;
            Ds_msgVale = string.Empty;
            St_registro = "A";
            Vl_unitario = decimal.Zero;
            tp_preco = "N";
            tipo_preco = "NORMAL";
            tp_faturamento = string.Empty;
            tipo_faturamento = string.Empty;
            Qtd_convenio = decimal.Zero;
            Qtd_vendida = decimal.Zero;
            Cd_portador = string.Empty;
            Ds_portador = string.Empty;
            st_exigirrequisicao = "N";
            st_exigirrequisicaobool = false;
            st_exigirnomemot = "N";
            st_exigirnomemotbool = false;
            tp_qt_vl = string.Empty;
            tipo_qt_vl = string.Empty;
            Base_calc_fid = decimal.Zero;
            Qt_pontos_fid = decimal.Zero;
            Nr_diasvalidade_fid = 60;
            tp_pontos_fid = string.Empty;
            tipo_pontos_fid = string.Empty;
            St_processar = false;

            lPlaca = new TList_Convenio_Placa();
            lPlacaDel = new TList_Convenio_Placa();
            lMotorista = new TList_convenio_Motorista();
            lMotDel = new TList_convenio_Motorista();
        }
    }

    public class TCD_Convenio_Clifor : TDataQuery
    {
        public TCD_Convenio_Clifor()
        { }

        public TCD_Convenio_Clifor(BancoDados.TObjetoBanco banco)
        { Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + vTop.ToString();

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("select " + strTop + " a.id_convenio, a.cd_empresa, a.st_exigirrequisicao, ");
                sql.AppendLine("b.NM_Empresa, a.cd_clifor, c.nm_clifor, a.qtd_convenio, a.ds_msgvale, ");
                sql.AppendLine("case when c.tp_pessoa = 'J' then c.nr_cgc else c.nr_cpf end as nr_cgc_cpf, ");
                sql.AppendLine("a.cd_produto, d.ds_produto, conv.cd_portador, a.vl_unitario, a.st_exigirnomemot, ");
                sql.AppendLine("port.ds_portador, conv.desconto, conv.tp_desconto, conv.ds_convenio, a.id_config, ");
                sql.AppendLine("a.st_placaconveniada, a.st_motconveniado, a.st_faturardireto, a.tp_faturamento, ");
                sql.AppendLine("a.qtd_vendida, a.TP_Preco, a.cd_vendedor, g.nm_clifor as nm_vendedor, h.ds_config, ");
                sql.AppendLine("a.cd_endereco, endereco.ds_endereco, endereco.ds_cidade, endereco.insc_estadual, ");
                sql.AppendLine("a.tp_qt_vl, a.base_calc_fid, a.qt_pontos_fid, a.nr_diasvalidade_fid, a.tp_pontos_fid, ");
                sql.AppendLine("a.TP_AcresDesc, a.TP_Desconto, a.Desconto ");
            }
            else
                sql.AppendLine(" Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from VTB_PDC_CONVENIO_X_CLIFOR a ");
            sql.AppendLine("inner join tb_pdc_convenio conv ");
            sql.AppendLine("on a.cd_empresa = conv.cd_empresa ");
            sql.AppendLine("and a.id_convenio = conv.id_convenio ");
            sql.AppendLine("left outer join tb_fin_portador port ");
            sql.AppendLine("on conv.cd_portador = port.cd_portador ");
            sql.AppendLine("inner join TB_DIV_Empresa b ");
            sql.AppendLine("on a.cd_empresa = b.CD_Empresa ");
            sql.AppendLine("inner join VTB_FIN_Clifor c ");
            sql.AppendLine("on a.cd_clifor = c.cd_clifor ");
            sql.AppendLine("inner join VTB_FIN_Endereco endereco ");
            sql.AppendLine("on a.cd_clifor = endereco.cd_clifor ");
            sql.AppendLine("and a.cd_endereco = endereco.cd_endereco ");
            sql.AppendLine("inner join TB_EST_Produto d ");
            sql.AppendLine("on a.cd_produto = d.cd_produto ");
            sql.AppendLine("left outer join tb_fin_Clifor g ");
            sql.AppendLine("on a.cd_vendedor = g.cd_clifor ");
            sql.AppendLine("left outer join TB_COB_CfgBanco h ");
            sql.AppendLine("on a.id_config = h.id_config ");

            sql.AppendLine("where isnull(a.st_registro, 'A') <> 'C' ");

            string cond = " and ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
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

        public TList_Convenio_Clifor Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            bool podeFecharBco = false;
            TList_Convenio_Clifor lista = new TList_Convenio_Clifor();
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_Convenio_Clifor reg = new TRegistro_Convenio_Clifor();
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_portador")))
                        reg.Cd_portador = reader.GetString(reader.GetOrdinal("cd_portador"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_portador")))
                        reg.Ds_portador = reader.GetString(reader.GetOrdinal("ds_portador"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_vendedor")))
                        reg.Nm_vendedor = reader.GetString(reader.GetOrdinal("nm_vendedor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_vendedor")))
                        reg.CD_vendedor = reader.GetString(reader.GetOrdinal("cd_vendedor"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("id_convenio"))))
                        reg.Id_convenio = reader.GetDecimal(reader.GetOrdinal("id_convenio"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_convenio")))
                        reg.Ds_convenio = reader.GetString(reader.GetOrdinal("ds_convenio"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("cd_empresa"))))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("NM_Empresa"))))
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("NM_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_clifor")))
                        reg.Cd_clifor = reader.GetString(reader.GetOrdinal("cd_clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_clifor")))
                        reg.Nm_clifor = reader.GetString(reader.GetOrdinal("nm_clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_cgc_cpf")))
                        reg.Nr_cgc_cpf = reader.GetString(reader.GetOrdinal("nr_cgc_cpf"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_endereco")))
                        reg.Cd_endereco = reader.GetString(reader.GetOrdinal("cd_endereco"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_endereco")))
                        reg.Ds_endereco = reader.GetString(reader.GetOrdinal("ds_endereco"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_cidade")))
                        reg.Ds_cidade = reader.GetString(reader.GetOrdinal("ds_cidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("insc_estadual")))
                        reg.Insc_estadual = reader.GetString(reader.GetOrdinal("insc_estadual"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_produto")))
                        reg.Cd_produto = reader.GetString(reader.GetOrdinal("cd_produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_produto")))
                        reg.Ds_produto = reader.GetString(reader.GetOrdinal("ds_produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_placaconveniada")))
                        reg.St_placaconveniada = reader.GetString(reader.GetOrdinal("st_placaconveniada"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_motconveniado")))
                        reg.St_motconveniado = reader.GetString(reader.GetOrdinal("st_motconveniado"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_faturardireto")))
                        reg.St_faturardireto = reader.GetString(reader.GetOrdinal("st_faturardireto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_unitario")))
                        reg.Vl_unitario = reader.GetDecimal(reader.GetOrdinal("vl_unitario"));
                    if (!reader.IsDBNull(reader.GetOrdinal("TP_AcresDesc")))
                        reg.Tp_acresdesc = reader.GetString(reader.GetOrdinal("TP_AcresDesc"));
                    if (!reader.IsDBNull(reader.GetOrdinal("TP_Desconto")))
                        reg.Tp_desconto = reader.GetString(reader.GetOrdinal("TP_Desconto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Desconto")))
                        reg.Desconto = reader.GetDecimal(reader.GetOrdinal("Desconto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("qtd_convenio")))
                        reg.Qtd_convenio = reader.GetDecimal(reader.GetOrdinal("qtd_convenio"));
                    if (!reader.IsDBNull(reader.GetOrdinal("qtd_vendida")))
                        reg.Qtd_vendida = reader.GetDecimal(reader.GetOrdinal("qtd_vendida"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_preco")))
                        reg.Tp_preco = reader.GetString(reader.GetOrdinal("tp_preco"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_faturamento")))
                        reg.Tp_faturamento = reader.GetString(reader.GetOrdinal("tp_faturamento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_exigirrequisicao")))
                        reg.St_exigirrequisicao = reader.GetString(reader.GetOrdinal("st_exigirrequisicao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_exigirnomemot")))
                        reg.St_exigirnomemot = reader.GetString(reader.GetOrdinal("st_exigirnomemot"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_config")))
                        reg.Id_config = reader.GetDecimal(reader.GetOrdinal("id_config"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_config")))
                        reg.Ds_config = reader.GetString(reader.GetOrdinal("ds_config"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_qt_vl")))
                        reg.Tp_qt_vl = reader.GetString(reader.GetOrdinal("tp_qt_vl"));
                    if (!reader.IsDBNull(reader.GetOrdinal("base_calc_fid")))
                        reg.Base_calc_fid = reader.GetDecimal(reader.GetOrdinal("base_calc_fid"));
                    if (!reader.IsDBNull(reader.GetOrdinal("qt_pontos_fid")))
                        reg.Qt_pontos_fid = reader.GetDecimal(reader.GetOrdinal("qt_pontos_fid"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_diasvalidade_fid")))
                        reg.Nr_diasvalidade_fid = reader.GetDecimal(reader.GetOrdinal("nr_diasvalidade_fid"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_pontos_fid")))
                        reg.Tp_pontos_fid = reader.GetString(reader.GetOrdinal("tp_pontos_fid"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_msgvale")))
                        reg.Ds_msgVale = reader.GetString(reader.GetOrdinal("ds_msgvale"));

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

        public string Gravar(TRegistro_Convenio_Clifor val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(26);
            hs.Add("@P_ID_CONVENIO", val.Id_convenio);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_CD_CLIFOR", val.Cd_clifor);
            hs.Add("@P_CD_ENDERECO", val.Cd_endereco);
            hs.Add("@P_CD_PRODUTO", val.Cd_produto);
            hs.Add("@P_ST_PLACACONVENIADA", val.St_placaconveniada);
            hs.Add("@P_ST_MOTCONVENIADO", val.St_motconveniado);
            hs.Add("@P_ST_FATURARDIRETO", val.St_faturardireto);
            hs.Add("@P_ST_REGISTRO", val.St_registro);
            hs.Add("@P_VL_UNITARIO", val.Vl_unitario);
            hs.Add("@P_TP_ACRESDESC", val.Tp_acresdesc);
            hs.Add("@P_TP_DESCONTO", val.Tp_desconto);
            hs.Add("@P_DESCONTO", val.Desconto);
            hs.Add("@P_TP_PRECO", val.Tp_preco);
            hs.Add("@P_TP_FATURAMENTO", val.Tp_faturamento);
            hs.Add("@P_QTD_CONVENIO", val.Qtd_convenio);
            hs.Add("@P_CD_VENDEDOR", val.CD_vendedor);
            hs.Add("@P_ST_EXIGIRREQUISICAO", val.St_exigirrequisicao);
            hs.Add("@P_ST_EXIGIRNOMEMOT", val.St_exigirnomemot);
            hs.Add("@P_ID_CONFIG", val.Id_config);
            hs.Add("@P_TP_QT_VL", val.Tp_qt_vl);
            hs.Add("@P_BASE_CALC_FID", val.Base_calc_fid);
            hs.Add("@P_QT_PONTOS_FID", val.Qt_pontos_fid);
            hs.Add("@P_NR_DIASVALIDADE_FID", val.Nr_diasvalidade_fid);
            hs.Add("@P_TP_PONTOS_FID", val.Tp_pontos_fid);
            hs.Add("@P_DS_MSGVALE", val.Ds_msgVale);

            
            return executarProc("IA_PDC_CONVENIO_X_CLIFOR", hs);
        }

        public string Excluir(TRegistro_Convenio_Clifor val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(4);
            hs.Add("@P_ID_CONVENIO", val.Id_convenio);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_CD_CLIFOR", val.Cd_clifor);
            hs.Add("@P_CD_PRODUTO", val.Cd_produto);

            return executarProc("EXCLUI_PDC_CONVENIO_X_CLIFOR", hs);
        }
    }
    #endregion

    #region Placa Convenio
    public class TList_Convenio_Placa : List<TRegistro_Convenio_Placa>, IComparer<TRegistro_Convenio_Placa>
    {
        #region IComparer<TRegistro_Convenio_Placa> Members
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

        public TList_Convenio_Placa()
        { }

        public TList_Convenio_Placa(System.ComponentModel.PropertyDescriptor Prop,
                                    System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_Convenio_Placa value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_Convenio_Placa x, TRegistro_Convenio_Placa y)
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

    
    public class TRegistro_Convenio_Placa
    {
        private decimal? id_convenio;
        
        public decimal? Id_convenio
        {
            get { return id_convenio; }
            set
            {
                id_convenio = value;
                id_conveniostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_conveniostr;
        
        public string Id_conveniostr
        {
            get { return id_conveniostr; }
            set
            {
                id_conveniostr = value;
                try
                {
                    id_convenio = decimal.Parse(value);
                }
                catch
                { id_convenio = null; }
            }
        }
        
        public string Cd_empresa
        { get; set; }
        
        public string Cd_clifor
        { get; set; }
        
        public string Cd_endereco
        { get; set; }
        
        public string Cd_produto
        { get; set; }
        
        public string Placa
        { get; set; }
        
        public string Ds_veiculo
        { get; set; }
        
        public string Nr_frota
        { get; set; }
        private string st_km;
        
        public string St_km
        {
            get { return st_km; }
            set
            {
                st_km = value;
                st_kmbool = value.Trim().ToUpper().Equals("S");
            }
        }
        private bool st_kmbool;
        
        public bool St_kmbool
        {
            get { return st_kmbool; }
            set
            {
                st_kmbool = value;
                st_km = value ? "S" : "N";
            }
        }
        private string st_diasuteis;
        
        public string St_diasuteis
        {
            get { return st_diasuteis; }
            set
            {
                st_diasuteis = value;
                st_diasuteisbool = value.Trim().ToUpper().Equals("S");
            }
        }
        private bool st_diasuteisbool;
        
        public bool St_diasuteisbool
        {
            get { return st_diasuteisbool; }
            set
            {
                st_diasuteisbool = value;
                st_diasuteis = value ? "S" : "N";
            }
        }
        
        public string Ds_observacao
        { get; set; }
        
        public bool St_processar
        { get; set; }

        public TRegistro_Convenio_Placa()
        {
            id_convenio = null;
            id_conveniostr = string.Empty;
            Cd_empresa = string.Empty;
            Cd_clifor = string.Empty;
            Cd_endereco = string.Empty;
            Cd_produto = string.Empty;
            Placa = string.Empty;
            Ds_veiculo = string.Empty;
            Nr_frota = string.Empty;
            st_km = "N";
            st_kmbool = false;
            st_diasuteis = "N";
            st_diasuteisbool = false;
            Ds_observacao = string.Empty;
            St_processar = false;
        }
    }

    public class TCD_Convenio_Placa : TDataQuery
    {
        public TCD_Convenio_Placa()
        { }

        public TCD_Convenio_Placa(BancoDados.TObjetoBanco banco)
        { Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + vTop.ToString();

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("select " + strTop + " a.id_convenio, a.cd_empresa, ");
                sql.AppendLine("a.cd_clifor, a.cd_endereco, a.cd_produto, a.placa, a.ds_veiculo, ");
                sql.AppendLine("a.st_km, a.st_diasuteis, a.ds_observacao, a.nr_frota ");
            }
            else
                sql.AppendLine(" Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from tb_pdc_convenio_x_placa a ");
            sql.AppendLine("inner join vtb_pdc_convenio_x_clifor b ");
            sql.AppendLine("on a.id_convenio = b.id_convenio ");
            sql.AppendLine("and a.cd_empresa = b.cd_empresa ");
            sql.AppendLine("and a.cd_clifor = b.cd_clifor ");
            sql.AppendLine("and a.cd_endereco = b.cd_endereco ");
            sql.AppendLine("and a.cd_produto = b.cd_produto ");
            sql.AppendLine("inner join tb_pdc_convenio c ");
            sql.AppendLine("on b.id_convenio = c.id_convenio ");
            sql.AppendLine("and b.cd_empresa = c.cd_empresa ");

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

        public TList_Convenio_Placa Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            bool podeFecharBco = false;
            TList_Convenio_Placa lista = new TList_Convenio_Placa();
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_Convenio_Placa reg = new TRegistro_Convenio_Placa();
                    if (!(reader.IsDBNull(reader.GetOrdinal("id_convenio"))))
                        reg.Id_convenio = reader.GetDecimal(reader.GetOrdinal("id_convenio"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("cd_empresa"))))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_clifor")))
                        reg.Cd_clifor = reader.GetString(reader.GetOrdinal("cd_clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_endereco")))
                        reg.Cd_endereco = reader.GetString(reader.GetOrdinal("cd_endereco"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_produto")))
                        reg.Cd_produto = reader.GetString(reader.GetOrdinal("cd_produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("placa")))
                        reg.Placa = reader.GetString(reader.GetOrdinal("placa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_veiculo")))
                        reg.Ds_veiculo = reader.GetString(reader.GetOrdinal("ds_veiculo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_frota")))
                        reg.Nr_frota = reader.GetString(reader.GetOrdinal("nr_frota"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_km")))
                        reg.St_km = reader.GetString(reader.GetOrdinal("st_km"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_diasuteis")))
                        reg.St_diasuteis = reader.GetString(reader.GetOrdinal("st_diasuteis"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_observacao")))
                        reg.Ds_observacao = reader.GetString(reader.GetOrdinal("ds_observacao"));

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

        public TList_Convenio_Placa SelectImport(string Cd_empresa, string Cd_clifor)
        {
            bool podeFecharBco = false;
            TList_Convenio_Placa lista = new TList_Convenio_Placa();
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = ExecutarBusca(SqlCodeBusca(new Utils.TpBusca[]
                {
                    new Utils.TpBusca()
                    {
                        vNM_Campo = "a.cd_empresa",
                        vOperador = "=",
                        vVL_Busca = "'" + Cd_empresa.Trim() + "'"
                    },
                    new Utils.TpBusca()
                    {
                        vNM_Campo = "a.cd_clifor",
                        vOperador = "=",
                        vVL_Busca = "'" + Cd_clifor.Trim() + "'"
                    }
                }, 0, "distinct a.placa, a.ds_veiculo"));
            try
            {
                while (reader.Read())
                {
                    TRegistro_Convenio_Placa reg = new TRegistro_Convenio_Placa();
                    if (!reader.IsDBNull(reader.GetOrdinal("placa")))
                        reg.Placa = reader.GetString(reader.GetOrdinal("placa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_veiculo")))
                        reg.Ds_veiculo = reader.GetString(reader.GetOrdinal("ds_veiculo"));

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

        public string Gravar(TRegistro_Convenio_Placa val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(11);
            hs.Add("@P_ID_CONVENIO", val.Id_convenio);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_CD_CLIFOR", val.Cd_clifor);
            hs.Add("@P_CD_ENDERECO", val.Cd_endereco);
            hs.Add("@P_CD_PRODUTO", val.Cd_produto);
            hs.Add("@P_PLACA", val.Placa);
            hs.Add("@P_DS_VEICULO", val.Ds_veiculo);
            hs.Add("@P_NR_FROTA", val.Nr_frota);
            hs.Add("@P_ST_KM", val.St_km);
            hs.Add("@P_ST_DIASUTEIS", val.St_diasuteis);
            hs.Add("@P_DS_OBSERVACAO", val.Ds_observacao);

            return executarProc("IA_PDC_CONVENIO_X_PLACA", hs);
        }

        public string Excluir(TRegistro_Convenio_Placa val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(6);
            hs.Add("@P_ID_CONVENIO", val.Id_convenio);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_CD_CLIFOR", val.Cd_clifor);
            hs.Add("@P_CD_ENDERECO", val.Cd_endereco);
            hs.Add("@P_CD_PRODUTO", val.Cd_produto);
            hs.Add("@P_PLACA", val.Placa);

            return executarProc("EXCLUI_PDC_CONVENIO_X_PLACA", hs);
        }
    }
    #endregion

    #region Motorista Convenio
    public class TList_convenio_Motorista : List<TRegistro_Convenio_Motorista>, IComparer<TRegistro_Convenio_Motorista>
    {
        #region IComparer<TRegistro_Convenio_Motorista> Members
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

        public TList_convenio_Motorista()
        { }

        public TList_convenio_Motorista(System.ComponentModel.PropertyDescriptor Prop,
                                        System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_Convenio_Motorista value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_Convenio_Motorista x, TRegistro_Convenio_Motorista y)
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

    
    public class TRegistro_Convenio_Motorista
    {
        private decimal? id_convenio;
        
        public decimal? Id_convenio
        {
            get { return id_convenio; }
            set
            {
                id_convenio = value;
                id_conveniostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_conveniostr;
        
        public string Id_conveniostr
        {
            get { return id_conveniostr; }
            set
            {
                id_conveniostr = value;
                try
                {
                    id_convenio = decimal.Parse(value);
                }
                catch
                { id_convenio = null; }
            }
        }
        
        public string Cd_empresa
        { get; set; }
        
        public string Cd_clifor
        { get; set; }
        
        public string Cd_endereco
        { get; set; }
        
        public string Cd_produto
        { get; set; }
        private decimal? id_motorista;
        
        public decimal? Id_motorista
        {
            get { return id_motorista; }
            set
            {
                id_motorista = value;
                id_motoristastr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_motoristastr;
        
        public string Id_motoristastr
        {
            get { return id_motoristastr; }
            set
            {
                id_motoristastr = value;
                try
                {
                    id_motorista = decimal.Parse(value);
                }
                catch
                { id_motorista = null; }
            }
        }
        
        public string Nm_motorista
        { get; set; }
        
        public string CPF_motorista
        { get; set; }
        
        public bool St_processar
        { get; set; }

        public TRegistro_Convenio_Motorista()
        {
            id_convenio = null;
            id_conveniostr = string.Empty;
            Cd_empresa = string.Empty;
            Cd_clifor = string.Empty;
            Cd_endereco = string.Empty;
            Cd_produto = string.Empty;
            id_motorista = null;
            id_motoristastr = string.Empty;
            Nm_motorista = string.Empty;
            CPF_motorista = string.Empty;
            St_processar = false;
        }
    }

    public class TCD_Convenio_Motorista : TDataQuery
    {
        public TCD_Convenio_Motorista()
        { }

        public TCD_Convenio_Motorista(BancoDados.TObjetoBanco banco)
        { Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + vTop.ToString();

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("select " + strTop + " a.id_convenio, a.cd_empresa, a.cd_clifor, ");
                sql.AppendLine("a.cd_endereco, a.cd_produto, a.id_motorista, a.nm_motorista, a.cpf_motorista ");
            }
            else
                sql.AppendLine(" Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from tb_pdc_convenio_x_motorista a ");

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

        public TList_convenio_Motorista Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            bool podeFecharBco = false;
            TList_convenio_Motorista lista = new TList_convenio_Motorista();
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_Convenio_Motorista reg = new TRegistro_Convenio_Motorista();
                    if (!(reader.IsDBNull(reader.GetOrdinal("id_convenio"))))
                        reg.Id_convenio = reader.GetDecimal(reader.GetOrdinal("id_convenio"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("cd_empresa"))))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_clifor")))
                        reg.Cd_clifor = reader.GetString(reader.GetOrdinal("cd_clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_endereco")))
                        reg.Cd_endereco = reader.GetString(reader.GetOrdinal("cd_endereco"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_produto")))
                        reg.Cd_produto = reader.GetString(reader.GetOrdinal("cd_produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_motorista")))
                        reg.Id_motorista = reader.GetDecimal(reader.GetOrdinal("id_motorista"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_motorista")))
                        reg.Nm_motorista = reader.GetString(reader.GetOrdinal("nm_motorista"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cpf_motorista")))
                        reg.CPF_motorista = reader.GetString(reader.GetOrdinal("cpf_motorista"));

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

        public string Gravar(TRegistro_Convenio_Motorista val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(8);
            hs.Add("@P_ID_CONVENIO", val.Id_convenio);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_CD_CLIFOR", val.Cd_clifor);
            hs.Add("@P_CD_ENDERECO", val.Cd_endereco);
            hs.Add("@P_CD_PRODUTO", val.Cd_produto);
            hs.Add("@P_ID_MOTORISTA", val.Id_motorista);
            hs.Add("@P_NM_MOTORISTA", val.Nm_motorista);
            hs.Add("@P_CPF_MOTORISTA", val.CPF_motorista);

            return executarProc("IA_PDC_CONVENIO_X_MOTORISTA", hs);
        }

        public string Excluir(TRegistro_Convenio_Motorista val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(6);
            hs.Add("@P_ID_CONVENIO", val.Id_convenio);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_CD_CLIFOR", val.Cd_clifor);
            hs.Add("@P_CD_ENDERECO", val.Cd_endereco);
            hs.Add("@P_CD_PRODUTO", val.Cd_produto);
            hs.Add("@P_ID_MOTORISTA", val.Id_motorista);

            return executarProc("EXCLUI_PDC_CONVENIO_X_MOTORISTA", hs);
        }
    }
    #endregion

    #region Placas Bloqueadas Gerar Pontos
    public class TList_PlacaBloqPontos : List<TRegistro_PlacaBloqPontos> { }
    public class TRegistro_PlacaBloqPontos
    {
        public string Placa { get; set; } = string.Empty;
    }
    public class TCD_PlacaBloqPontos:TDataQuery
    {
        public TCD_PlacaBloqPontos() { }
        public TCD_PlacaBloqPontos(BancoDados.TObjetoBanco banco) { Banco_Dados = banco; }
        private string SqlCodeBusca(Utils.TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + vTop.ToString();

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
                sql.AppendLine("select " + strTop + " a.placa ");
            else
                sql.AppendLine(" Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from TB_PDC_PlacaBloqPontos a ");

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

        public TList_PlacaBloqPontos Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            bool podeFecharBco = false;
            TList_PlacaBloqPontos lista = new TList_PlacaBloqPontos();
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_PlacaBloqPontos reg = new TRegistro_PlacaBloqPontos();
                    if (!(reader.IsDBNull(reader.GetOrdinal("placa"))))
                        reg.Placa = reader.GetString(reader.GetOrdinal("placa"));
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

        public string Gravar(TRegistro_PlacaBloqPontos val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(1);
            hs.Add("@P_PLACA", val.Placa);
            return executarProc("IA_PDC_PLACABLOQPONTOS", hs);
        }

        public string Excluir(TRegistro_PlacaBloqPontos val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(1);
            hs.Add("@P_PLACA", val.Placa);

            return executarProc("EXCLUI_PDC_PLACABLOQPONTOS", hs);
        }
    }
    #endregion

    #region Convenio - Painel Gerencial

    public class TRegistro_ConvPainel
    {
        
        public string Cd_clifor
        { get; set; }
        
        public string Nm_clifor
        { get; set; }
        
        public string Cd_combustivel
        { get; set; }
        
        public string Ds_combustivel
        { get; set; }
        
        public decimal VolumeAtual
        { get; set; }
        
        public decimal VolumeAnt
        { get; set; }
        
        public decimal VolumeAntt
        { get; set; }

        public TRegistro_ConvPainel()
        {
            Cd_clifor = string.Empty;
            Nm_clifor = string.Empty;
            Cd_combustivel = string.Empty;
            Ds_combustivel = string.Empty;
            VolumeAtual = decimal.Zero;
            VolumeAnt = decimal.Zero;
            VolumeAntt = decimal.Zero;
        }
    }

    public class TCD_ConvPainel : TDataQuery
    {
        public TCD_ConvPainel()
        { }

        public TCD_ConvPainel(BancoDados.TObjetoBanco banco)
        { Banco_Dados = banco; }

        private string SqlCodeBusca(string Cd_empresa, DateTime Dt_atual)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("select a.CD_Clifor, b.NM_Clifor, a.cd_produto, c.ds_produto, ");
            sql.AppendLine("VolumeAtual = ISNULL((select SUM(ISNULL(x.VolumeAbastecido, 0)) ");
            sql.AppendLine("				from TB_PDC_VendaCombustivel x ");
            sql.AppendLine("				where x.CD_Empresa = a.CD_Empresa ");
            sql.AppendLine("				and x.ID_Convenio = a.ID_Convenio ");
            sql.AppendLine("				and x.CD_Clifor = a.CD_Clifor ");
            sql.AppendLine("				and x.CD_Produto = a.CD_Produto ");
            sql.AppendLine("				and MONTH(x.DT_Abastecimento) = " + Dt_atual.Month.ToString());
            sql.AppendLine("				and YEAR(x.DT_Abastecimento) = " + Dt_atual.Year.ToString() + "), 0),");
            sql.AppendLine("VolumeAnt = ISNULL((select SUM(ISNULL(x.VolumeAbastecido, 0)) ");
            sql.AppendLine("				from TB_PDC_VendaCombustivel x ");
            sql.AppendLine("				where x.CD_Empresa = a.CD_Empresa ");
            sql.AppendLine("				and x.ID_Convenio = a.ID_Convenio ");
            sql.AppendLine("				and x.CD_Clifor = a.CD_Clifor ");
            sql.AppendLine("				and x.CD_Produto = a.CD_Produto ");
            sql.AppendLine("				and MONTH(x.DT_Abastecimento) = " + Dt_atual.AddMonths(-1).Month.ToString());
            sql.AppendLine("				and YEAR(x.DT_Abastecimento) = " + Dt_atual.AddMonths(-1).Year.ToString() + "), 0), ");
            sql.AppendLine("VolumeAntt = ISNULL((select SUM(ISNULL(x.VolumeAbastecido, 0)) ");
            sql.AppendLine("				from TB_PDC_VendaCombustivel x ");
            sql.AppendLine("				where x.CD_Empresa = a.CD_Empresa ");
            sql.AppendLine("				and x.ID_Convenio = a.ID_Convenio ");
            sql.AppendLine("				and x.CD_Clifor = a.CD_Clifor ");
            sql.AppendLine("				and x.CD_Produto = a.CD_Produto ");
            sql.AppendLine("				and MONTH(x.DT_Abastecimento) = " + Dt_atual.AddMonths(-2).Month.ToString());
            sql.AppendLine("				and YEAR(x.DT_Abastecimento) = " + Dt_atual.AddMonths(-2).Year.ToString() + "), 0)");

            sql.AppendLine("from TB_PDC_Convenio_X_Clifor a ");
            sql.AppendLine("inner join tb_fin_clifor b ");
            sql.AppendLine("on a.CD_Clifor = b.CD_Clifor ");
            sql.AppendLine("inner join TB_EST_Produto c ");
            sql.AppendLine("on a.cd_produto = c.cd_produto ");
            sql.AppendLine("where ISNULL(a.ST_Registro, 'A') <> 'C' ");
            sql.AppendLine("and a.cd_empresa = '" + Cd_empresa.Trim() + "'");

            sql.AppendLine("order by a.CD_Produto asc, VolumeAtual desc");

            return sql.ToString();
        }

        private string SqlCodeBuscaConvCli(string Cd_empresa, DateTime Dt_atual)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("select a.CD_Clifor, b.NM_Clifor, ");
            sql.AppendLine("VolumeAtual = ISNULL((select SUM(ISNULL(x.VolumeAbastecido, 0)) ");
            sql.AppendLine("				from TB_PDC_VendaCombustivel x ");
            sql.AppendLine("				where x.CD_Empresa = a.CD_Empresa ");
            sql.AppendLine("				and x.ID_Convenio = a.ID_Convenio ");
            sql.AppendLine("				and x.CD_Clifor = a.CD_Clifor ");
            sql.AppendLine("				and x.CD_Produto = a.CD_Produto ");
            sql.AppendLine("				and MONTH(x.DT_Abastecimento) = " + Dt_atual.Month.ToString());
            sql.AppendLine("				and YEAR(x.DT_Abastecimento) = " + Dt_atual.Year.ToString() + "), 0),");
            sql.AppendLine("VolumeAnt = ISNULL((select SUM(ISNULL(x.VolumeAbastecido, 0)) ");
            sql.AppendLine("				from TB_PDC_VendaCombustivel x ");
            sql.AppendLine("				where x.CD_Empresa = a.CD_Empresa ");
            sql.AppendLine("				and x.ID_Convenio = a.ID_Convenio ");
            sql.AppendLine("				and x.CD_Clifor = a.CD_Clifor ");
            sql.AppendLine("				and x.CD_Produto = a.CD_Produto ");
            sql.AppendLine("				and MONTH(x.DT_Abastecimento) = " + Dt_atual.AddMonths(-1).Month.ToString());
            sql.AppendLine("				and YEAR(x.DT_Abastecimento) = " + Dt_atual.AddMonths(-1).Year.ToString() + "), 0), ");
            sql.AppendLine("VolumeAntt = ISNULL((select SUM(ISNULL(x.VolumeAbastecido, 0)) ");
            sql.AppendLine("				from TB_PDC_VendaCombustivel x ");
            sql.AppendLine("				where x.CD_Empresa = a.CD_Empresa ");
            sql.AppendLine("				and x.ID_Convenio = a.ID_Convenio ");
            sql.AppendLine("				and x.CD_Clifor = a.CD_Clifor ");
            sql.AppendLine("				and x.CD_Produto = a.CD_Produto ");
            sql.AppendLine("				and MONTH(x.DT_Abastecimento) = " + Dt_atual.AddMonths(-2).Month.ToString());
            sql.AppendLine("				and YEAR(x.DT_Abastecimento) = " + Dt_atual.AddMonths(-2).Year.ToString() + "), 0)");

            sql.AppendLine("from TB_PDC_Convenio_X_Clifor a ");
            sql.AppendLine("inner join tb_fin_clifor b ");
            sql.AppendLine("on a.CD_Clifor = b.CD_Clifor ");
            sql.AppendLine("inner join TB_EST_Produto c ");
            sql.AppendLine("on a.cd_produto = c.cd_produto ");
            sql.AppendLine("where ISNULL(a.ST_Registro, 'A') <> 'C' ");
            sql.AppendLine("and a.cd_empresa = '" + Cd_empresa.Trim() + "'");

            sql.AppendLine("order by a.CD_Produto asc, VolumeAtual desc");

            return sql.ToString();
        }

        public List<TRegistro_ConvPainel> Select(string Cd_empresa, DateTime Dt_atual)
        {
            bool podeFecharBco = false;
            List<TRegistro_ConvPainel> lista = new List<TRegistro_ConvPainel>();
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = ExecutarBusca(SqlCodeBusca(Cd_empresa, Dt_atual));
            try
            {
                while (reader.Read())
                {
                    TRegistro_ConvPainel reg = new TRegistro_ConvPainel();
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_clifor")))
                        reg.Cd_clifor = reader.GetString(reader.GetOrdinal("cd_clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_clifor")))
                        reg.Nm_clifor = reader.GetString(reader.GetOrdinal("nm_clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_produto")))
                        reg.Cd_combustivel = reader.GetString(reader.GetOrdinal("cd_produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_produto")))
                        reg.Ds_combustivel = reader.GetString(reader.GetOrdinal("ds_produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("VolumeAtual")))
                        reg.VolumeAtual = reader.GetDecimal(reader.GetOrdinal("VolumeAtual"));
                    if (!reader.IsDBNull(reader.GetOrdinal("VolumeAnt")))
                        reg.VolumeAnt = reader.GetDecimal(reader.GetOrdinal("VolumeAnt"));
                    if (!reader.IsDBNull(reader.GetOrdinal("VolumeAntt")))
                        reg.VolumeAntt = reader.GetDecimal(reader.GetOrdinal("VolumeAntt"));

                    lista.Add(reg);
                }
                return lista;
            }
            finally
            {
                reader.Close();
                reader.Dispose();
                if (podeFecharBco)
                    deletarBanco_Dados();
            }
        }
    }
    #endregion
}
