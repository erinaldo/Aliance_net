using System;
using System.Collections.Generic;
using System.Linq;
using BancoDados;
using Utils;
using System.Text;
using System.Collections;
using System.Data.SqlClient;
using System.Data;

namespace CamadaDados.Faturamento.Cadastros
{
    #region Etapa

    public class TList_CadEtapa : List<TRegistro_CadEtapa>, IComparer<TRegistro_CadEtapa>
    {
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

        public TList_CadEtapa()
        { }

        public TList_CadEtapa(System.ComponentModel.PropertyDescriptor Prop,
                                System.Windows.Forms.SortOrder Dir)
        {
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_CadEtapa value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_CadEtapa x, TRegistro_CadEtapa y)
        {
            object col1 = GetPropertyValue(x, Propriedade.Name);
            object col2 = GetPropertyValue(y, Propriedade.Name);
            if (Direcao == System.Windows.Forms.SortOrder.Ascending)
                return CompareAscending(col1, col2);
            else
                return CompareDescending(col1, col2);
        }
    }

    public class TRegistro_CadEtapa
    {
        private decimal? id_etapa;

        public decimal? Id_etapa
        {
            get { return id_etapa; }
            set
            {
                id_etapa = value;
                id_etapastr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_etapastr;

        public string Id_etapastr
        {
            get { return id_etapastr; }
            set
            {
                id_etapastr = value;
                try
                {
                    id_etapa = decimal.Parse(value);
                }
                catch
                { id_etapa = null; }
            }
        }
        public string DS_Etapa { get; set; }
        public decimal Ordem { get; set; }
        public string stRegistro {get;set;}
        public bool St_processar { get; set; }
        private string st_FecharPed;
        public string Login { get; set; }
        public string ST_FecharPed
        {
            get { return st_FecharPed; }
            set
            {
                st_FecharPed = value;
                st_FecharPedbool = value.Trim().ToUpper().Equals("S");
            }
        }
        private bool st_FecharPedbool;
        public bool ST_FecharPedBool
        {
            get { return st_FecharPedbool; }
            set
            {
                st_FecharPedbool = value;
                st_FecharPed = value ? "S" : "N";
            }
        }
        private string st_LiberarExped;
        public string ST_LiberarExped
        {
            get { return st_LiberarExped; }
            set
            {
                st_LiberarExped = value;
                st_LiberarExpedbool = value.Trim().ToUpper().Equals("S");
            }
        }
        private bool st_LiberarExpedbool;
        public bool ST_LiberarExpedBool
        {
            get { return st_LiberarExpedbool; }
            set
            {
                st_LiberarExpedbool = value;
                st_LiberarExped = value ? "S" : "N";
            }
        }

        public TList_ProcessoEtapa lprocesso
        { get; set; }
            
        public TRegistro_CadEtapa()
        {
            this.id_etapa = null;
            this.id_etapastr = string.Empty;
            this.DS_Etapa = string.Empty;
            this.Ordem = decimal.Zero;
            this.ST_FecharPed = string.Empty;
            this.ST_LiberarExped = string.Empty;
            this.st_LiberarExpedbool = false;   
            this.lprocesso = new TList_ProcessoEtapa();
            this.St_processar = false;
            this.stRegistro = string.Empty;
            this.Login = string.Empty;
        }
    }

    public class TCD_CadEtapa : TDataQuery
    {
        public TCD_CadEtapa()
        { }

        public TCD_CadEtapa(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, Int32 vTop, string vNM_Campo, string vOrder)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();

            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine(" SELECT " + strTop + " a.id_etapa, a.DS_Etapa, a.Ordem, a.st_fecharped, a.ST_LiberarExped ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("FROM  TB_FAT_etapaped a ");
            sql.Append("WHERE (isnull(A.ST_REGISTRO,'A')<> 'C' ) ");
                        
            string cond = " and ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.Append(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                    cond = "  and ";
                }
            if (!string.IsNullOrEmpty(vOrder))
                sql.AppendLine("Order By " + vOrder);
            else
                sql.AppendLine("order by a.ordem ");
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

        public TList_CadEtapa Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_CadEtapa lista = new TList_CadEtapa();
            SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);

            try
            {
                reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo, string.Empty));
                while (reader.Read())
                {
                    TRegistro_CadEtapa reg = new TRegistro_CadEtapa();
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Etapa")))
                        reg.Id_etapa = reader.GetDecimal(reader.GetOrdinal("ID_Etapa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Etapa")))
                        reg.DS_Etapa = reader.GetString(reader.GetOrdinal("DS_Etapa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Ordem")))
                        reg.Ordem = reader.GetDecimal(reader.GetOrdinal("Ordem"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ST_FecharPed")))
                        reg.ST_FecharPed = reader.GetString(reader.GetOrdinal("ST_FecharPed"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ST_LiberarExped")))
                        reg.ST_LiberarExped = reader.GetString(reader.GetOrdinal("ST_LiberarExped"));

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

        public string Grava(TRegistro_CadEtapa vRegistro)
        {
            Hashtable hs = new Hashtable(6);
            hs.Add("@P_ID_ETAPA", vRegistro.Id_etapa);
            hs.Add("@P_DS_ETAPA", vRegistro.DS_Etapa);
            hs.Add("@P_ST_FECHARPED", vRegistro.ST_FecharPed);
            hs.Add("@P_ORDEM", vRegistro.Ordem);
            hs.Add("@P_ST_LIBERAREXPED", vRegistro.ST_LiberarExped);
            hs.Add("@P_ST_REGISTRO", vRegistro.stRegistro);

            return this.executarProc("IA_FAT_ETAPAPED", hs);
        }

        public string Deleta(TRegistro_CadEtapa vRegistro)
        {
            Hashtable hs = new Hashtable(1);
            hs.Add("@P_ID_ETAPA", vRegistro.Id_etapa);

            return this.executarProc("EXCLUI_FAT_ETAPAPED", hs);
        }
    }
    
#endregion 

    #region ProcessoEtapa
        public class TList_ProcessoEtapa : List<TRegistro_ProcessoEtapa>, IComparer<TRegistro_ProcessoEtapa>
        {
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

            public TList_ProcessoEtapa()
            { }

            public TList_ProcessoEtapa(System.ComponentModel.PropertyDescriptor Prop,
                                    System.Windows.Forms.SortOrder Dir)
            {
                Propriedade = Prop;
                Direcao = Dir;
            }

            private object GetPropertyValue(TRegistro_ProcessoEtapa value,
                                            string Propriedade)
            {
                System.Reflection.PropertyInfo pInfo =
                    value.GetType().GetProperty(Propriedade);
                return pInfo.GetValue(value, null);
            }

            public int Compare(TRegistro_ProcessoEtapa x, TRegistro_ProcessoEtapa y)
            {
                object col1 = GetPropertyValue(x, Propriedade.Name);
                object col2 = GetPropertyValue(y, Propriedade.Name);
                if (Direcao == System.Windows.Forms.SortOrder.Ascending)
                    return CompareAscending(col1, col2);
                else
                    return CompareDescending(col1, col2);
            }
        }

        public class TRegistro_ProcessoEtapa
        {
            private decimal? id_etapa;

            public decimal? Id_etapa
            {
                get { return id_etapa; }
                set
                {
                    id_etapa = value;
                    id_etapastr = value.HasValue ? value.Value.ToString() : string.Empty;
                }
            }
            private string id_etapastr;

            public string Id_etapastr
            {
                get { return id_etapastr; }
                set
                {
                    id_etapastr = value;
                    try
                    {
                        id_etapa = decimal.Parse(value);
                    }
                    catch
                    { id_etapa = null; }
                }
            }
            public string ID_Processostr 
            { get; set; }
            public decimal ID_Processo 
            { get; set; }
            public string DS_Processo 
            { get; set; }
            public string stRegistro { get; set; }

            public TRegistro_ProcessoEtapa()
            {
                this.id_etapa = null;
                this.id_etapastr = string.Empty;
                this.ID_Processo = decimal.Zero;
                this.ID_Processostr = string.Empty;
                this.DS_Processo = string.Empty;
                this.stRegistro = string.Empty;
            }
        }

        public class TCD_ProcessoEtapa : TDataQuery
        {
            public TCD_ProcessoEtapa()
            { }

            public TCD_ProcessoEtapa(BancoDados.TObjetoBanco banco)
            { this.Banco_Dados = banco; }

            private string SqlCodeBusca(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
            {
                string strTop = string.Empty;
                if (vTop > 0)
                    strTop = "TOP " + Convert.ToString(vTop);
                StringBuilder sql = new StringBuilder();

                if (string.IsNullOrEmpty(vNM_Campo))
                {
                    sql.AppendLine(" SELECT " + strTop + "a.id_processo, a.DS_Processo, a.id_etapa ");
                }
                else
                    sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

                sql.AppendLine("FROM tb_fat_processoetapa a ");
                sql.AppendLine(" where ( isnull(a.st_registro,'A') <> 'C' )  " );

                string cond = " and ";
                if (vBusca != null)
                    for (int i = 0; i < (vBusca.Length); i++)
                    {
                        sql.Append(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                        cond = " and ";
                    }
                sql.AppendLine("Order By a.id_processo asc");
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

            public TList_ProcessoEtapa Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
            {
                TList_ProcessoEtapa lista = new TList_ProcessoEtapa();
                SqlDataReader reader = null;
                bool podeFecharBco = false;
                if (Banco_Dados == null)
                    podeFecharBco = this.CriarBanco_Dados(false);

                try
                {
                    reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
                    while (reader.Read())
                    {
                        TRegistro_ProcessoEtapa reg = new TRegistro_ProcessoEtapa();
                        if (!reader.IsDBNull(reader.GetOrdinal("ID_Processo")))
                            reg.ID_Processo = reader.GetDecimal(reader.GetOrdinal("ID_Processo"));
                        if (!reader.IsDBNull(reader.GetOrdinal("ID_Etapa")))
                            reg.Id_etapa = reader.GetDecimal(reader.GetOrdinal("ID_Etapa"));
                        if (!reader.IsDBNull(reader.GetOrdinal("DS_Processo")))
                            reg.DS_Processo = reader.GetString(reader.GetOrdinal("DS_Processo"));

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

            public string Grava(TRegistro_ProcessoEtapa vRegistro)
            {
                Hashtable hs = new Hashtable(3);
                hs.Add("@P_ID_ETAPA", vRegistro.Id_etapa);
                hs.Add("@P_ID_PROCESSO", vRegistro.ID_Processo);
                hs.Add("@P_DS_PROCESSO", vRegistro.DS_Processo);
                hs.Add("@P_ST_REGISTRO", vRegistro.stRegistro);

                return this.executarProc("IA_FAT_PROCESSOETAPA", hs);
            }

            public string Deleta(TRegistro_ProcessoEtapa vRegistro)
            {
                Hashtable hs = new Hashtable(2);
                hs.Add("@P_ID_PROCESSO", vRegistro.ID_Processo);
                hs.Add("@P_ID_ETAPA", vRegistro.Id_etapa);

                return this.executarProc("EXCLUI_FAT_PROCESSOETAPA", hs);
            }
        }
    


    #endregion
}
