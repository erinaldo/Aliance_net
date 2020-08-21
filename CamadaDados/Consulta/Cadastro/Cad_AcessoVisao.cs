using System;
using System.Collections.Generic;
using System.Text;
using Utils;
using System.Collections;
using System.Data.SqlClient;
using System.Data;

namespace CamadaDados.Consulta.Cadastro
{

    #region acessovisao
    public class TRegistro_AcessoVisao
    {
        public string Login { get; set; }
        public decimal id_Visao { get; set; }
        public string ds_visao { get; set; }
        public TRegistro_AcessoVisao()
        {

            Login = string.Empty;
            id_Visao = decimal.Zero;
            ds_visao = string.Empty;

        }


    }
    public class TList_AcessoVisao : List<TRegistro_AcessoVisao> { }


    public class TCD_AcessoVisao : TDataQuery
    {
        public TCD_AcessoVisao()
        { }

        public TCD_AcessoVisao(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, Int32 vTop, string vNM_Campo, string vOrder)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();

            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine(" SELECT " + strTop + " a.Login, a.id_visao, b.ds_visao  ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("FROM  tb_con_acessovisao a ");
            sql.AppendLine("join tb_con_visaobi b on a.id_visao = b.id_visao ");

            string cond = " WHERE ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.Append(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                    cond = "  and ";
                }
            if (!string.IsNullOrEmpty(vOrder))
                sql.AppendLine("Order By " + vOrder);
            return sql.ToString();
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, "", string.Empty), null);
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo, string.Empty), null);
        }

        public override object BuscarEscalar(Utils.TpBusca[] vBusca, string vNM_Campo, string vGroup, string vOrder, System.Collections.Hashtable vParametros)
        {
            return this.ExecutarBuscaEscalar(this.SqlCodeBusca(vBusca, 1, vNM_Campo, vOrder), vParametros);
        }

        public TList_AcessoVisao Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_AcessoVisao lista = new TList_AcessoVisao();
            SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);

            try
            {
                reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo, string.Empty));
                while (reader.Read())
                {
                    TRegistro_AcessoVisao reg = new TRegistro_AcessoVisao();
                    if (!reader.IsDBNull(reader.GetOrdinal("id_visao")))
                        reg.id_Visao = reader.GetDecimal(reader.GetOrdinal("id_visao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_visao")))
                        reg.ds_visao = reader.GetString(reader.GetOrdinal("ds_visao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("login")))
                        reg.Login = reader.GetString(reader.GetOrdinal("login"));

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

        public string Grava(TRegistro_AcessoVisao vRegistro)
        {
            Hashtable hs = new Hashtable(2);
            hs.Add("@P_LOGIN", vRegistro.Login);
            hs.Add("@P_ID_VISAO", vRegistro.id_Visao);

            return this.executarProc("IA_CON_ACESSOVISAO", hs);
        }

        public string Deleta(TRegistro_AcessoVisao vRegistro)
        {
            Hashtable hs = new Hashtable(1);
            hs.Add("@P_ID_VISAO", vRegistro.id_Visao);

            return this.executarProc("EXCLUI_CON_ACESSOVISAO", hs);
        }
    }
    #endregion


    #region acessobi
    public class TRegistro_VisaoBI
    {
        public decimal id_Visao { get; set; }
        public string ds_visao { get; set; }
        public string nm_classe { get; set; }

        private string tp_classe;
        public string Tp_classe
        {
            get { return tp_classe; }
            set
            {
                tp_classe = value;
                if (value.Trim().ToUpper().Equals("TFBI"))
                    tipo_classe = "BI Vendas UF";
                else if (value.Trim().ToUpper().Equals("TFBIOS"))
                    tipo_classe = "BI Orderm Serviço";
                else if (value.Trim().ToUpper().Equals("TFBIDia"))
                    tipo_classe = "BI Vendas Dia";
                else if (value.Trim().ToUpper().Equals("TFBICentroResultado"))
                    tipo_classe = "BI CENTRO RESULTADO";
                else if (value.Trim().ToUpper().Equals("TFBICentroResultViagem"))
                    tipo_classe = "BI - Centro Resultado Viagem";
            }
        }
        private string tipo_classe;

        public string Tipo_classe
        {
            get { return tipo_classe; }
            set
            {
                tipo_classe = value;
                if (value.Trim().ToUpper().Equals("BI VENDAS UF"))
                    tp_classe = "TFBI";
                else if (value.Trim().ToUpper().Equals("BI ORDEM SERVICO"))
                    tp_classe = "TFBIOS";
                else if (value.Trim().ToUpper().Equals("BI VENDAS DIA"))
                    tp_classe = "TFBIDia";
                else if (value.Trim().ToUpper().Equals("BI CENTRO RESULTADO"))
                    tp_classe = "TFBICentroResultado";
                else if (value.Trim().ToUpper().Equals("BI - Centro Resultado Viagem"))
                    tp_classe = "TFBICentroResultViagem";
            }
        }



        public TRegistro_VisaoBI()
        {

            id_Visao = decimal.Zero;
            ds_visao = string.Empty;
            nm_classe = string.Empty;
            tp_classe = string.Empty;
            tipo_classe = string.Empty;

        }


    }
    public class TList_VisaoBI : List<TRegistro_VisaoBI> { }


    public class TCD_VisaoBI : TDataQuery
    {
        public TCD_VisaoBI()
        { }

        public TCD_VisaoBI(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, Int32 vTop, string vNM_Campo, string vOrder)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();

            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine(" SELECT " + strTop + " a.id_visao, a.ds_visao, a.nm_classe  ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("FROM  tb_con_visaobi a ");

            string cond = " WHERE ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.Append(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                    cond = "  and ";
                }
            if (!string.IsNullOrEmpty(vOrder))
                sql.AppendLine("Order By " + vOrder);
            return sql.ToString();
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, "", string.Empty), null);
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo, string.Empty), null);
        }

        public override object BuscarEscalar(Utils.TpBusca[] vBusca, string vNM_Campo, string vGroup, string vOrder, System.Collections.Hashtable vParametros)
        {
            return this.ExecutarBuscaEscalar(this.SqlCodeBusca(vBusca, 1, vNM_Campo, vOrder), vParametros);
        }

        public TList_VisaoBI Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_VisaoBI lista = new TList_VisaoBI();
            SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);

            try
            {
                reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo, string.Empty));
                while (reader.Read())
                {
                    TRegistro_VisaoBI reg = new TRegistro_VisaoBI();
                    if (!reader.IsDBNull(reader.GetOrdinal("id_visao")))
                        reg.id_Visao = reader.GetDecimal(reader.GetOrdinal("id_visao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_visao")))
                        reg.ds_visao = reader.GetString(reader.GetOrdinal("ds_visao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_classe")))
                        reg.nm_classe = reader.GetString(reader.GetOrdinal("nm_classe"));

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

        public string Grava(TRegistro_VisaoBI vRegistro)
        {
            Hashtable hs = new Hashtable(3);
            hs.Add("@P_ID_VISAO", vRegistro.id_Visao);
            hs.Add("@P_DS_VISAO", vRegistro.Tipo_classe);
            hs.Add("@P_NM_CLASSE", vRegistro.Tp_classe);

            return this.executarProc("IA_CON_VISAOBI", hs);
        }

        public string Deleta(TRegistro_AcessoVisao vRegistro)
        {
            Hashtable hs = new Hashtable(1);
            hs.Add("@P_ID_VISAO", vRegistro.id_Visao);

            return this.executarProc("EXCLUI_CON_VISAOBI", hs);
        }
    }
    #endregion

    #region CfgVendasUF
    public class TList_CfgVendasUF : List<TRegistro_CfgVendasUF>
    { }
    public class TRegistro_CfgVendasUF
    {
        public string Cd_grupo
        { get; set; }
        public string Ds_grupo
        { get; set; }

        private string tp_visao;
        public string Tp_visao
        {
            get { return tp_visao; }
            set
            {
                tp_visao = value;
                if (value.Trim().ToUpper().Equals("T"))
                    tipo_visao = "TANQUE";
                else if (value.Trim().ToUpper().Equals("P"))
                    tipo_visao = "PERIFERICOS";
            }
        }
        private string tipo_visao;

        public string Tipo_visao
        {
            get { return tipo_visao; }
            set
            {
                tipo_visao = value;
                if (value.Trim().ToUpper().Equals("TANQUE"))
                    tp_visao = "T";
                else if (value.Trim().ToUpper().Equals("PERIFERICOS"))
                    tp_visao = "P";
            }
        }



        public TRegistro_CfgVendasUF()
        {
            Cd_grupo = string.Empty;
            Ds_grupo = string.Empty;
            tp_visao = string.Empty;
            tipo_visao = string.Empty;
        }


    }


    public class TCD_CfgVendasUF : TDataQuery
    {
        public TCD_CfgVendasUF()
        { }

        public TCD_CfgVendasUF(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, Int32 vTop, string vNM_Campo, string vOrder)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();

            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine(" SELECT " + strTop + " a.cd_grupo, b.ds_grupo, a.tp_visao  ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("FROM TB_CON_CfgVendasUF a ");
            sql.AppendLine("inner join TB_EST_GrupoProduto b ");
            sql.AppendLine("on a.cd_grupo = b.cd_grupo ");

            string cond = " WHERE ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.Append(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                    cond = "  and ";
                }
            if (!string.IsNullOrEmpty(vOrder))
                sql.AppendLine("Order By " + vOrder);
            return sql.ToString();
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, "", string.Empty), null);
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo, string.Empty), null);
        }

        public override object BuscarEscalar(Utils.TpBusca[] vBusca, string vNM_Campo, string vGroup, string vOrder, System.Collections.Hashtable vParametros)
        {
            return this.ExecutarBuscaEscalar(this.SqlCodeBusca(vBusca, 1, vNM_Campo, vOrder), vParametros);
        }

        public TList_CfgVendasUF Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_CfgVendasUF lista = new TList_CfgVendasUF();
            SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);

            try
            {
                reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo, string.Empty));
                while (reader.Read())
                {
                    TRegistro_CfgVendasUF reg = new TRegistro_CfgVendasUF();
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_grupo")))
                        reg.Cd_grupo = reader.GetString(reader.GetOrdinal("cd_grupo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_grupo")))
                        reg.Ds_grupo = reader.GetString(reader.GetOrdinal("ds_grupo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Tp_visao")))
                        reg.Tp_visao = reader.GetString(reader.GetOrdinal("Tp_visao"));

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

        public string Grava(TRegistro_CfgVendasUF vRegistro)
        {
            Hashtable hs = new Hashtable(2);
            hs.Add("@P_CD_GRUPO", vRegistro.Cd_grupo);
            hs.Add("@P_TP_VISAO", vRegistro.Tp_visao);

            return this.executarProc("IA_CON_CFGVENDASUF", hs);
        }

        public string Deleta(TRegistro_CfgVendasUF vRegistro)
        {
            Hashtable hs = new Hashtable(1);
            hs.Add("@P_CD_GRUPO", vRegistro.Cd_grupo);

            return this.executarProc("EXCLUI_CON_CFGVENDASUF", hs);
        }
    }
    #endregion








}
