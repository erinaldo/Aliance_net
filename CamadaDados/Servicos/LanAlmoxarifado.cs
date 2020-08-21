using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Utils;

namespace CamadaDados.Servicos
{
    public class TList_LanAlmoxarifado : List<TRegistro_LanAlmoxarifado>, IComparer<TRegistro_LanAlmoxarifado>
    {
        #region IComparer<TRegistro_LanAlmoxarifado> Members
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

        public TList_LanAlmoxarifado()
        { }

        public TList_LanAlmoxarifado(System.ComponentModel.PropertyDescriptor Prop,
                                      System.Windows.Forms.SortOrder Dir)
        {
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_LanAlmoxarifado value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_LanAlmoxarifado x, TRegistro_LanAlmoxarifado y)
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

    public class TRegistro_LanAlmoxarifado
    {
        private decimal? id_os;

        public decimal? Id_os
        {
            get { return id_os; }
            set
            {
                id_os = value;
                id_osstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_osstr;

        public string Id_osstr
        {
            get { return id_osstr; }
            set
            {
                id_osstr = value;
                try
                {
                    id_os = decimal.Parse(value);
                }
                catch
                { id_os = null; }
            }
        }

        public string Cd_empresa
        { get; set; }
        private decimal? id_peca;

        public decimal? Id_peca
        {
            get { return id_peca; }
            set
            {
                id_peca = value;
                id_pecastr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_pecastr;

        public string Id_pecastr
        {
            get { return id_pecastr; }
            set
            {
                id_pecastr = value;
                try
                {
                    id_peca = decimal.Parse(value);
                }
                catch
                { id_peca = null; }
            }
        }
        private decimal? id_Movimento;

        public decimal? Id_Movimento
        {
            get { return id_Movimento; }
            set
            {
                id_Movimento = value;
                id_Movimentostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_Movimentostr;

        public string Id_Movimentostr
        {
            get { return id_Movimentostr; }
            set
            {
                id_Movimentostr = value;
                try
                {
                    id_Movimento = decimal.Parse(value);
                }
                catch
                { id_Movimento = null; }
            }
        }


        public TRegistro_LanAlmoxarifado()
        {
            this.id_os = null;
            this.id_osstr = string.Empty;
            this.Cd_empresa = string.Empty;
            this.id_peca = null;
            this.id_pecastr = string.Empty;
            this.Id_Movimento = null;
            this.id_Movimentostr = string.Empty;
        }
    }

    public class TCD_LanAlmoxarifado : TDataQuery
    {
        public TCD_LanAlmoxarifado()
        { }

        public TCD_LanAlmoxarifado(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("SELECT " + strTop + " a.ID_OS, a.CD_Empresa, a.ID_peca, a.id_movimento ");
            }
            else
                sql.AppendLine(" Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from TB_OSE_Almoxarifado a ");

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

        public TList_LanAlmoxarifado Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            bool podeFecharBco = false;
            TList_LanAlmoxarifado lista = new TList_LanAlmoxarifado();

            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            SqlDataReader reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_LanAlmoxarifado reg = new TRegistro_LanAlmoxarifado();
                    if (!(reader.IsDBNull(reader.GetOrdinal("ID_OS"))))
                        reg.Id_os = reader.GetDecimal(reader.GetOrdinal("ID_OS"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_Empresa"))))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("CD_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Id_peca")))
                        reg.Id_peca = reader.GetDecimal(reader.GetOrdinal("Id_peca"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Id_Movimento")))
                        reg.Id_Movimento = reader.GetDecimal(reader.GetOrdinal("Id_Movimento"));
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

        public string Gravar(TRegistro_LanAlmoxarifado val)
        {
            Hashtable hs = new Hashtable(4);
            hs.Add("@P_ID_OS", val.Id_os);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_PECA", val.Id_peca);
            hs.Add("@P_ID_MOVIMENTO", val.Id_Movimento);

            return this.executarProc("IA_OSE_ALMOXARIFADO", hs);
        }

        public string Excluir(TRegistro_LanAlmoxarifado val)
        {
            Hashtable hs = new Hashtable(4);
            hs.Add("@P_ID_OS", val.Id_os);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_PECA", val.Id_peca);
            hs.Add("@P_ID_MOVIMENTO", val.Id_Movimento);

            return this.executarProc("EXCLUI_OSE_ALMOXARIFADO", hs);
        }
    }
}
