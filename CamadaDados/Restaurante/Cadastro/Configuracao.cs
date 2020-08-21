using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamadaDados.Restaurante.Cadastro
{
    public class TRegistro_Cfg
    {
        public string cd_empresa { get; set; } = string.Empty;
        public string cd_tabelapreco { get; set; } = string.Empty;
        public string CD_CondFiscal { get; set; } = string.Empty;
        public string DS_CondFiscal { get; set; } = string.Empty;
        public string cd_local { get; set; } = string.Empty;
        public string ds_local { get; set; } = string.Empty;
        public string ds_tabelapreco { get; set; } = string.Empty;
        public string nm_clifor { get; set; } = string.Empty;
        public string ds_empresa { get; set; } = string.Empty;
        public decimal? id_cargo { get; set; } = null;
        public string id_cargostr
        {
            get
            {
                return id_cargo.ToString();
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                    id_cargo = Convert.ToDecimal(value);
                else
                    id_cargo = null;
            }
        }
        public string ds_cargo { get; set; } = string.Empty; 
        public string Cd_Clifor { get; set; } = string.Empty;
        public string Cd_horaboliche { get; set; } = string.Empty;
        public string ds_horaboliche { get; set; } = string.Empty;
        public string Cd_horasinuca { get; set; } = string.Empty;
        public string ds_horasinuca { get; set; } = string.Empty;
        public string ST_imp_end_cozinha
        {
            get
            {
                if (Bool_imp_end_cozinha)
                    return "S";
                else
                    return "N";
            }
            set
            {
                if (value.Trim().Equals("S"))
                    Bool_imp_end_cozinha = true;
                else
                    Bool_imp_end_cozinha = false;
            }
        }
        public bool Bool_imp_end_cozinha { get; set; } = false;
        public decimal nr_cartaorotini { get; set; } = decimal.Zero;
        public decimal nr_cartaorotfin { get; set; } = decimal.Zero;
        private string tp_cartao = string.Empty;
        public string Tp_cartao
        {
            get { return tp_cartao; }
            set
            {
                tp_cartao = value;
                if (value.Trim().ToUpper().Equals("0"))
                    tipo_cartao = "ROTATIVO";
                else if (value.Trim().ToUpper().Equals("1"))
                    tipo_cartao = "MESA";
                else if (value.Trim().ToUpper().Equals("2"))
                    tipo_cartao = "SEQUENCIAL";
            }
        }
        private string tipo_cartao = string.Empty;
        public string Tipo_cartao
        {
            get { return tipo_cartao; }
            set
            {
                tipo_cartao = value;
                if (value.Trim().ToUpper().Equals("ROTATIVO"))
                    tp_cartao = "0";
                else if (value.Trim().ToUpper().Equals("MESA"))
                    tp_cartao = "1";
                else if (value.Trim().ToUpper().Equals("SEQUENCIAL"))
                    tp_cartao = "2";
            }
        }
        public string st_mesacartao { get; set; } = string.Empty;
        public bool bool_mesacartao
        {
            get
            {
                return st_mesacartao.Equals("S");
            }
            set
            {
                if (value)
                    st_mesacartao = "S";
                else
                    st_mesacartao = "N";
            }
        }
        public string st_abrircartao { get; set; } = string.Empty;
        public bool bool_abrircartao
        {
            get
            {
                return st_abrircartao.Equals("S");
            }
            set
            {
                if (value)
                    st_abrircartao = "S";
                else
                    st_abrircartao = "N";
            }
        }
        public string PathBdTorneira { get; set; }
        public bool st_imprimirextratoposvenda { get; set; }
        public bool st_mantercartaoaberto { get; set; }
        public bool ST_ObrigarMesaProdPed { get; set; } = false;

    }
    public class TList_CFG : List<TRegistro_Cfg> { }

    public class TCD_CFG : TDataQuery
    {
        public TCD_CFG() { }

        public TCD_CFG(BancoDados.TObjetoBanco banco) { this.Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("select " + strTop + " a.cd_local,g.ds_local, a.id_cargo, f.ds_cargo, ");
                sql.AppendLine("a.cd_empresa,a.cd_clifor, a.ST_imp_end_cozinha, a.cd_tabelapreco, a.nr_cartaorotini, a.nr_cartaorotfin,a.cd_condfiscal_clifor, ");
                sql.AppendLine("c.ds_condfiscal, d.ds_tabelapreco,E.nm_empresa, b.nm_clifor, a.Tp_cartao , a.st_mesacartao, a.st_abrircartao, a.cd_horaboliche, ");
                sql.AppendLine("h.ds_produto, a.cd_horasinuca, i.ds_produto as dsproduto, a.pathbdtorneira, ");
                sql.AppendLine("a.st_imprimirextratoposvenda, a.st_mantercartaoaberto, a.ST_ObrigarMesaProdPed ");
            }
            else
                sql.AppendLine(" Select " + strTop + "   " + vNM_Campo + " ");

            sql.AppendLine("from TB_RES_Config a");
            sql.AppendLine("left join tb_fin_clifor b on a.cd_clifor = b.cd_clifor");
            sql.AppendLine("left join TB_FIS_CondFiscal_Clifor c on c.cd_condfiscal_clifor = a.cd_condfiscal_clifor ");
            sql.AppendLine("left join TB_DIV_TabelaPreco d on d.cd_tabelapreco = a.cd_tabelapreco ");
            sql.AppendLine("left join tb_div_empresa e on e.cd_empresa = a.cd_empresa ");
            sql.AppendLine("left join tb_div_cargofuncionario f on f.id_cargo = a.id_cargo "); 
            sql.AppendLine("left join TB_EST_LocalArm g on g.cd_local = a.cd_local ");
            sql.AppendLine("left join TB_EST_PRODUTO h on h.cd_produto = a.cd_horaboliche ");
            sql.AppendLine("left join TB_EST_PRODUTO i on i.cd_produto = a.cd_horasinuca ");

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

        public TList_CFG Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            bool podeFecharBco = false;
            TList_CFG lista = new TList_CFG();
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_Cfg reg = new TRegistro_Cfg();
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        reg.cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Cd_Clifor")))
                        reg.Cd_Clifor = reader.GetString(reader.GetOrdinal("Cd_Clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_tabelapreco")))
                        reg.cd_tabelapreco = reader.GetString(reader.GetOrdinal("cd_tabelapreco"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Tp_cartao")))
                        reg.Tp_cartao = reader.GetString(reader.GetOrdinal("Tp_cartao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_mesacartao")))
                        reg.st_mesacartao = reader.GetString(reader.GetOrdinal("st_mesacartao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_abrircartao")))
                        reg.st_abrircartao = reader.GetString(reader.GetOrdinal("st_abrircartao"));
                    //if (!reader.IsDBNull(reader.GetOrdinal("ST_VendaFastFood"))) 
                    //    reg.ST_VendaFastFood = reader.GetString(reader.GetOrdinal("ST_VendaFastFood"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_cartaorotfin")))
                        reg.nr_cartaorotfin = reader.GetDecimal(reader.GetOrdinal("nr_cartaorotfin"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_cartaorotini")))
                        reg.nr_cartaorotini = reader.GetDecimal(reader.GetOrdinal("nr_cartaorotini"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_condfiscal_clifor")))
                        reg.CD_CondFiscal = reader.GetString(reader.GetOrdinal("cd_condfiscal_clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_CondFiscal")))
                        reg.DS_CondFiscal = reader.GetString(reader.GetOrdinal("DS_CondFiscal"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_tabelapreco")))
                        reg.ds_tabelapreco = reader.GetString(reader.GetOrdinal("ds_tabelapreco"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_clifor")))
                        reg.nm_clifor = reader.GetString(reader.GetOrdinal("nm_clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_empresa")))
                        reg.ds_empresa = reader.GetString(reader.GetOrdinal("nm_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_local")))
                        reg.cd_local = reader.GetString(reader.GetOrdinal("cd_local"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_local")))
                        reg.ds_local = reader.GetString(reader.GetOrdinal("ds_local"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ST_imp_end_cozinha")))
                        reg.ST_imp_end_cozinha = reader.GetString(reader.GetOrdinal("ST_imp_end_cozinha"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_cargo")))
                        reg.id_cargo = reader.GetDecimal(reader.GetOrdinal("id_cargo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_cargo")))
                        reg.ds_cargo = reader.GetString(reader.GetOrdinal("ds_cargo"));
                    //Para boliche
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_horaboliche")))
                        reg.Cd_horaboliche = reader.GetString(reader.GetOrdinal("cd_horaboliche"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_produto")))
                        reg.ds_horaboliche = reader.GetString(reader.GetOrdinal("ds_produto"));
                    //Para sinuca
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_horasinuca")))
                        reg.Cd_horasinuca = reader.GetString(reader.GetOrdinal("cd_horasinuca"));
                    if (!reader.IsDBNull(reader.GetOrdinal("dsproduto")))
                        reg.ds_horasinuca = reader.GetString(reader.GetOrdinal("dsproduto"));
                    //Para integração de torneiras
                    if (!reader.IsDBNull(reader.GetOrdinal("pathbdtorneira")))
                        reg.PathBdTorneira = reader.GetString(reader.GetOrdinal("pathbdtorneira"));

                    //Extrato pósvenda
                    if (!reader.IsDBNull(reader.GetOrdinal("st_imprimirextratoposvenda")))
                        reg.st_imprimirextratoposvenda = reader.GetBoolean(reader.GetOrdinal("st_imprimirextratoposvenda"));

                    //Abrir cartão pósvenda
                    if (!reader.IsDBNull(reader.GetOrdinal("st_mantercartaoaberto")))
                        reg.st_mantercartaoaberto = reader.GetBoolean(reader.GetOrdinal("st_mantercartaoaberto"));

                    if (!reader.IsDBNull(reader.GetOrdinal("ST_ObrigarMesaProdPed")))
                        reg.ST_ObrigarMesaProdPed = reader.GetBoolean(reader.GetOrdinal("ST_ObrigarMesaProdPed"));

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

        public string Gravar(TRegistro_Cfg val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(13);
            hs.Add("@P_CD_EMPRESA", val.cd_empresa);
            hs.Add("@P_CD_TABELAPRECO", val.cd_tabelapreco);
            hs.Add("@P_NR_CARTAOROTFIN", val.nr_cartaorotfin);
            hs.Add("@P_NR_CARTAOROTINI", val.nr_cartaorotini);
            hs.Add("@P_CD_LOCAL", val.cd_local);
            hs.Add("@P_ST_ABRIRCARTAO", val.st_abrircartao);
            hs.Add("@P_ST_MESACARTAO", val.st_mesacartao); 
            hs.Add("@P_TP_CARTAO", val.Tp_cartao);
            hs.Add("@P_ST_IMP_END_COZINHA", val.ST_imp_end_cozinha);
            hs.Add("@P_CD_CONDFISCAL_CLIFOR", val.CD_CondFiscal);
            hs.Add("@P_ID_CARGO", val.id_cargo);
            hs.Add("@P_CD_CLIFOR", val.Cd_Clifor);
            hs.Add("@P_CD_HORABOLICHE", val.Cd_horaboliche);
            hs.Add("@P_CD_HORASINUCA", val.Cd_horasinuca);
            hs.Add("@P_PATHBDTORNEIRA", val.PathBdTorneira);
            hs.Add("@P_ST_IMPRIMIREXTRATOPOSVENDA", val.st_imprimirextratoposvenda);
            hs.Add("@P_ST_MANTERCARTAOABERTO", val.st_mantercartaoaberto);
            hs.Add("@P_ST_OBRIGARMESAPRODPED", val.ST_ObrigarMesaProdPed);

            return this.executarProc("IA_RES_CONFIG", hs);
        }

        public string Excluir(TRegistro_Cfg val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(1);
            hs.Add("@P_CD_EMPRESA", val.cd_empresa);

            return this.executarProc("EXCLUI_RES_PREVENDA", hs);
        }
    }


}
