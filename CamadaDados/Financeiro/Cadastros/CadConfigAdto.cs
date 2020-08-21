using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Utils;

namespace CamadaDados.Financeiro.Cadastros
{
    public class TList_ConfigAdto : List<TRegistro_CadConfigAdto>
    { }

    
    public class TRegistro_CadConfigAdto
    {
        public string Cd_empresa
        { get; set; }
        public string Nm_empresa
        { get; set; }
        public string Cd_historico_ADTO_C
        { get; set; }
        public string Ds_historico_ADTO_C
        { get; set; }
        public string Tp_mov_ADTO_C
        { get; set; }
        public string Cd_historico_ADTO_R
        { get; set; }
        public string Ds_historico_ADTO_R
        { get; set; }
        public string Tp_mov_ADTO_R
        { get; set; }
        public string CD_Portador { get; set; }
        public string DS_Portador { get; set; }
        public string Cd_historico_DEVADTO_C
        { get; set; }
        public string Ds_historico_DEVADTO_C
        { get; set; }
        public string Tp_mov_DEVADTO_C
        { get; set; }
        public string Cd_historico_DEVADTO_R
        { get; set; }
        public string Ds_historico_DEVADTO_R
        { get; set; }
        public string Tp_mov_DEVADTO_R
        { get; set; }
        public string Cd_centroresult_ADTO_C
        { get; set; }
        public string Ds_centroresult_ADTO_C
        { get; set; }
        public string Cd_centroresult_DEVADTO_C
        { get; set; }
        public string Ds_centroresult_DEVADTO_C
        { get; set; }
        public string Cd_centroresult_ADTO_R
        { get; set; }
        public string Ds_centroresult_ADTO_R
        { get; set; }
        public string Cd_centroresult_DEVADTO_R
        { get; set; }
        public string Ds_centroresult_DEVADTO_R
        { get; set; }
        public string Cd_historicoDEV_Venda
        { get; set; }
        public string Ds_historicoDEV_Venda
        { get; set; }
        public string Cd_historicoDEV_Compra
        { get; set; }
        public string Ds_historicoDEV_Compra
        { get; set; }
        public string Cd_contagerDEV_CV
        { get; set; }
        public string Ds_contagerDEV_CV
        { get; set; }
        public string CD_HistoricoVgFin
        { get; set; }
        public string DS_HistoricoVgFin
        { get; set; }


        public CamadaDados.Financeiro.CCustoLan.TList_LanCCustoLancto lResult
        { get; set; }
        
        public TRegistro_CadConfigAdto()
        {
            this.Cd_empresa = string.Empty;
            this.Nm_empresa = string.Empty;
            this.CD_Portador = string.Empty;
            this.DS_Portador = string.Empty;
            this.Cd_historico_ADTO_C = string.Empty;
            this.Cd_historico_ADTO_R = string.Empty;
            this.Cd_historico_DEVADTO_C = string.Empty;
            this.Cd_historico_DEVADTO_R = string.Empty;
            this.Ds_historico_ADTO_C = string.Empty;
            this.Ds_historico_ADTO_R = string.Empty;
            this.Ds_historico_DEVADTO_C = string.Empty;
            this.Ds_historico_DEVADTO_R = string.Empty;
            this.Tp_mov_ADTO_C = string.Empty;
            this.Tp_mov_ADTO_R = string.Empty;
            this.Tp_mov_DEVADTO_C = string.Empty;
            this.Tp_mov_DEVADTO_R = string.Empty;
            this.Cd_centroresult_ADTO_C = string.Empty;
            this.Cd_centroresult_ADTO_R = string.Empty;
            this.Cd_centroresult_DEVADTO_C = string.Empty;
            this.Cd_centroresult_DEVADTO_R = string.Empty;
            this.Ds_centroresult_ADTO_C = string.Empty;
            this.Ds_centroresult_ADTO_R = string.Empty;
            this.Ds_centroresult_DEVADTO_C = string.Empty;
            this.Ds_centroresult_DEVADTO_R = string.Empty;
            this.Cd_historicoDEV_Compra = string.Empty;
            this.Ds_historicoDEV_Compra = string.Empty;
            this.Cd_historicoDEV_Venda = string.Empty;
            this.Ds_historicoDEV_Venda = string.Empty;
            this.Cd_contagerDEV_CV = string.Empty;
            this.Ds_contagerDEV_CV = string.Empty;
            this.CD_HistoricoVgFin = string.Empty;
            this.DS_HistoricoVgFin = string.Empty;

            this.lResult = new CamadaDados.Financeiro.CCustoLan.TList_LanCCustoLancto();
        }
    }

    public class TCD_CadConfigAdto : TDataQuery
    {
        public TCD_CadConfigAdto()
        { }

        public TCD_CadConfigAdto(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("select " + strTop + " a.cd_empresa, b.nm_empresa, a.cd_portador, p.ds_portador, a.cd_historico_adto_c, ");
                sql.AppendLine("c.ds_historico as ds_historico_adto_c, c.tp_mov as tp_mov_adto_c, ");
                sql.AppendLine("a.cd_historico_adto_r, d.ds_historico as ds_historico_adto_r, ");
                sql.AppendLine("d.tp_mov as tp_mov_adto_r, a.cd_historico_devadto_c, ");
                sql.AppendLine("f.ds_historico as ds_historico_devadto_c, ");
                sql.AppendLine("f.tp_mov as tp_mov_devadto_c, a.cd_historico_devadto_r, ");
                sql.AppendLine("g.ds_historico as ds_historico_devadto_r, g.tp_mov as tp_mov_devadto_r, ");
                sql.AppendLine("a.cd_centroresult_adto_c, h.ds_centroresultado as ds_centroresult_adto_c, ");
                sql.AppendLine("a.cd_centroresult_devadto_c, i.ds_centroresultado as ds_centroresult_devadto_c, ");
                sql.AppendLine("a.cd_centroresult_adto_r, j.ds_centroresultado as ds_centroresult_adto_r, ");
                sql.AppendLine("a.cd_centroresult_devadto_r, k.ds_centroresultado as ds_centroresult_devadto_r, ");
                sql.AppendLine("a.cd_historicoDEV_Venda, l.ds_historico as ds_historicoDEV_Venda, ");
                sql.AppendLine("a.cd_historicoDEV_Compra, m.ds_historico as ds_historicoDEV_Compra, ");
                sql.AppendLine("a.cd_contagerDEV_CV, n.ds_contager as ds_contagerDEV_CV, a.CD_HistoricoVgFin, o.ds_historico as DS_HistoricoVgFin ");
            }
            else
                sql.AppendLine(" Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from tb_fin_configadto a ");
            sql.AppendLine("inner join tb_div_empresa b ");
            sql.AppendLine("on a.cd_empresa = b.cd_empresa ");
            sql.AppendLine("left outer join tb_fin_historico c ");
            sql.AppendLine("on a.cd_historico_adto_c = c.cd_historico ");
            sql.AppendLine("left outer join tb_fin_historico d ");
            sql.AppendLine("on a.cd_historico_adto_r = d.cd_historico ");
            sql.AppendLine("left outer join tb_fin_historico f ");
            sql.AppendLine("on a.cd_historico_devadto_c = f.cd_historico ");
            sql.AppendLine("left outer join tb_fin_historico g ");
            sql.AppendLine("on a.cd_historico_devadto_r = g.cd_historico ");
            sql.AppendLine("left outer join tb_fin_portador p ");
            sql.AppendLine("on a.cd_portador = p.cd_portador ");
            sql.AppendLine("left outer join tb_fin_centroresultado h ");
            sql.AppendLine("on a.cd_centroresult_adto_c = h.cd_centroresult ");
            sql.AppendLine("left outer join tb_fin_centroresultado i ");
            sql.AppendLine("on a.cd_centroresult_devadto_c = i.cd_centroresult ");
            sql.AppendLine("left outer join tb_fin_centroresultado j ");
            sql.AppendLine("on a.cd_centroresult_adto_r = j.cd_centroresult ");
            sql.AppendLine("left outer join tb_fin_centroresultado k ");
            sql.AppendLine("on a.cd_centroresult_devadto_r = k.cd_centroresult ");
            sql.AppendLine("left outer join tb_fin_historico l ");
            sql.AppendLine("on a.cd_historicoDEV_Venda = l.cd_historico ");
            sql.AppendLine("left outer join tb_fin_historico m ");
            sql.AppendLine("on a.cd_historicoDEV_Compra = m.cd_historico ");
            sql.AppendLine("left outer join tb_fin_contager n ");
            sql.AppendLine("on a.cd_contagerDEV_CV = n.cd_contager ");
            sql.AppendLine("left outer join tb_fin_historico o ");
            sql.AppendLine("on a.CD_HistoricoVgFin = o.cd_historico ");

            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                    cond = " and ";
                }
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

        public TList_ConfigAdto Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            bool podeFecharBco = false;
            TList_ConfigAdto lista = new TList_ConfigAdto();
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            SqlDataReader reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_CadConfigAdto reg = new TRegistro_CadConfigAdto();
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_Empresa"))))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("CD_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NM_Empresa")))
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("NM_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Historico_ADTO_C")))
                        reg.Cd_historico_ADTO_C = reader.GetString(reader.GetOrdinal("CD_Historico_ADTO_C"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("DS_Historico_ADTO_C"))))
                        reg.Ds_historico_ADTO_C = reader.GetString(reader.GetOrdinal("DS_Historico_ADTO_C"));
                    if (!reader.IsDBNull(reader.GetOrdinal("TP_Mov_ADTO_C")))
                        reg.Tp_mov_ADTO_C = reader.GetString(reader.GetOrdinal("TP_Mov_ADTO_C"));

                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_Portador"))))
                        reg.CD_Portador = reader.GetString(reader.GetOrdinal("CD_Portador"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_portador")))
                        reg.DS_Portador = reader.GetString(reader.GetOrdinal("ds_portador"));
                    
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Historico_ADTO_R")))
                        reg.Cd_historico_ADTO_R = reader.GetString(reader.GetOrdinal("CD_Historico_ADTO_R"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Historico_ADTO_R")))
                        reg.Ds_historico_ADTO_R = reader.GetString(reader.GetOrdinal("DS_Historico_ADTO_R"));
                    if (!reader.IsDBNull(reader.GetOrdinal("TP_Mov_ADTO_R")))
                        reg.Tp_mov_ADTO_R = reader.GetString(reader.GetOrdinal("TP_Mov_ADTO_R"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Historico_DEVADTO_C")))
                        reg.Cd_historico_DEVADTO_C = reader.GetString(reader.GetOrdinal("CD_Historico_DEVADTO_C"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Historico_DEVADTO_C")))
                        reg.Ds_historico_DEVADTO_C = reader.GetString(reader.GetOrdinal("DS_Historico_DEVADTO_C"));
                    if (!reader.IsDBNull(reader.GetOrdinal("TP_Mov_DEVADTO_C")))
                        reg.Tp_mov_DEVADTO_C = reader.GetString(reader.GetOrdinal("TP_Mov_DEVADTO_C"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Historico_DEVADTO_R")))
                        reg.Cd_historico_DEVADTO_R = reader.GetString(reader.GetOrdinal("CD_Historico_DEVADTO_R"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Historico_DEVADTO_R")))
                        reg.Ds_historico_DEVADTO_R = reader.GetString(reader.GetOrdinal("DS_Historico_DEVADTO_R"));
                    if (!reader.IsDBNull(reader.GetOrdinal("TP_Mov_DEVADTO_R")))
                        reg.Tp_mov_DEVADTO_R = reader.GetString(reader.GetOrdinal("TP_Mov_DEVADTO_R"));

                    if (!reader.IsDBNull(reader.GetOrdinal("cd_centroresult_adto_c")))
                        reg.Cd_centroresult_ADTO_C = reader.GetString(reader.GetOrdinal("cd_centroresult_adto_c"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_centroresult_adto_c")))
                        reg.Ds_centroresult_ADTO_C = reader.GetString(reader.GetOrdinal("ds_centroresult_adto_c"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_centroresult_devadto_c")))
                        reg.Cd_centroresult_DEVADTO_C = reader.GetString(reader.GetOrdinal("cd_centroresult_devadto_c"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_centroresult_devadto_c")))
                        reg.Ds_centroresult_DEVADTO_C = reader.GetString(reader.GetOrdinal("ds_centroresult_devadto_c"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_centroresult_adto_r")))
                        reg.Cd_centroresult_ADTO_R = reader.GetString(reader.GetOrdinal("cd_centroresult_adto_r"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_centroresult_adto_r")))
                        reg.Ds_centroresult_ADTO_R = reader.GetString(reader.GetOrdinal("ds_centroresult_adto_r"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_centroresult_devadto_r")))
                        reg.Cd_centroresult_DEVADTO_R = reader.GetString(reader.GetOrdinal("cd_centroresult_devadto_r"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_centroresult_devadto_r")))
                        reg.Ds_centroresult_DEVADTO_R = reader.GetString(reader.GetOrdinal("ds_centroresult_devadto_r"));

                    if (!reader.IsDBNull(reader.GetOrdinal("cd_historicoDEV_Venda")))
                        reg.Cd_historicoDEV_Venda = reader.GetString(reader.GetOrdinal("cd_historicoDEV_Venda"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_historicoDEV_Venda")))
                        reg.Ds_historicoDEV_Venda = reader.GetString(reader.GetOrdinal("ds_historicoDEV_Venda"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_historicoDEV_Compra")))
                        reg.Cd_historicoDEV_Compra = reader.GetString(reader.GetOrdinal("cd_historicoDEV_Compra"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_historicoDEV_Compra")))
                        reg.Ds_historicoDEV_Compra = reader.GetString(reader.GetOrdinal("ds_historicoDEV_Compra"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_contagerDEV_CV")))
                        reg.Cd_contagerDEV_CV = reader.GetString(reader.GetOrdinal("cd_contagerDEV_CV"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_contagerDEV_CV")))
                        reg.Ds_contagerDEV_CV = reader.GetString(reader.GetOrdinal("ds_contagerDEV_CV"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_HistoricoVgFin")))
                        reg.CD_HistoricoVgFin = reader.GetString(reader.GetOrdinal("CD_HistoricoVgFin"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_HistoricoVgFin")))
                        reg.DS_HistoricoVgFin = reader.GetString(reader.GetOrdinal("DS_HistoricoVgFin"));

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

        public string GravarConfigAdto(TRegistro_CadConfigAdto val)
        {
            Hashtable hs = new Hashtable(14);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_CD_PORTADOR", val.CD_Portador);
            hs.Add("@P_CD_HISTORICO_ADTO_C", val.Cd_historico_ADTO_C);
            hs.Add("@P_CD_HISTORICO_ADTO_R", val.Cd_historico_ADTO_R);
            hs.Add("@P_CD_HISTORICO_DEVADTO_C", val.Cd_historico_DEVADTO_C);
            hs.Add("@P_CD_HISTORICO_DEVADTO_R", val.Cd_historico_DEVADTO_R);
            hs.Add("@P_CD_CENTRORESULT_ADTO_C", val.Cd_centroresult_ADTO_C);
            hs.Add("@P_CD_CENTRORESULT_ADTO_R", val.Cd_centroresult_ADTO_R);
            hs.Add("@P_CD_CENTRORESULT_DEVADTO_C", val.Cd_centroresult_DEVADTO_C);
            hs.Add("@P_CD_CENTRORESULT_DEVADTO_R", val.Cd_centroresult_DEVADTO_R);
            hs.Add("@P_CD_HISTORICODEV_VENDA", val.Cd_historicoDEV_Venda);
            hs.Add("@P_CD_HISTORICODEV_COMPRA", val.Cd_historicoDEV_Compra);
            hs.Add("@P_CD_CONTAGERDEV_CV", val.Cd_contagerDEV_CV);
            hs.Add("@P_CD_HISTORICOVGFIN", val.CD_HistoricoVgFin);

            return this.executarProc("IA_FIN_CONFIGADTO", hs);
        }

        public string DeletarConfigAdto(TRegistro_CadConfigAdto val)
        {
            Hashtable hs = new Hashtable(1);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);

            return this.executarProc("EXCLUI_FIN_CONFIGADTO", hs);
        }
    }
}
