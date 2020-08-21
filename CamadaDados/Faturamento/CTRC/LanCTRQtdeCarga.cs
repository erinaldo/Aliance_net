using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamadaDados.Faturamento.CTRC
{
    public class TList_CTRQtdeCarga : List<TRegistro_CTRQtdeCarga> { }

    public class TRegistro_CTRQtdeCarga
    {
        public string Cd_empresa
        { get; set; }
        private decimal? nr_lanctoCTR;
        public decimal? Nr_lanctoCTR
        {
            get { return nr_lanctoCTR; }
            set
            {
                nr_lanctoCTR = value;
                nr_lanctoCTRstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string nr_lanctoCTRstr;
        public string Nr_lanctoCTRstr
        {
            get { return nr_lanctoCTRstr; }
            set
            {
                nr_lanctoCTRstr = value;
                try
                {
                    nr_lanctoCTR = decimal.Parse(value);
                }
                catch { nr_lanctoCTR = null; }
            }
        }
        private decimal? id_qtde;
        public decimal? Id_qtde
        {
            get { return id_qtde; }
            set
            {
                id_qtde = value;
                id_qtdestr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_qtdestr;
        public string Id_qtdestr
        {
            get { return id_qtdestr; }
            set
            {
                id_qtdestr = value;
                try
                {
                    id_qtde = decimal.Parse(value);
                }
                catch { id_qtde = null; }
            }
        }
        private string cunid;
        public string cUnid
        {
            get { return cunid; }
            set
            {
                cunid = value;
                if (value.Trim().Equals("00"))
                    cunidade = "METROS CUBICOS";
                else if (value.Trim().Equals("01"))
                    cunidade = "QUILOGRAMA";
                else if (value.Trim().Equals("02"))
                    cunidade = "TONELADA";
                else if (value.Trim().Equals("03"))
                    cunidade = "UNIDADE";
                else if (value.Trim().Equals("04"))
                    cunidade = "LITROS";
                else if (value.Trim().Equals("05"))
                    cunidade = "MMBTU";
            }
        }
        private string cunidade;
        public string cUnidade
        {
            get { return cunidade; }
            set
            {
                cunidade = value;
                if (value.Trim().ToUpper().Equals("METROS CUBICOS"))
                    cunid = "00";
                else if (value.Trim().ToUpper().Equals("KILOS"))
                    cunid = "01";
                else if (value.Trim().ToUpper().Equals("TONELADA"))
                    cunid = "02";
                else if (value.Trim().ToUpper().Equals("UNIDADE"))
                    cunid = "03";
                else if (value.Trim().ToUpper().Equals("LITROS"))
                    cunid = "04";
                else if (value.Trim().ToUpper().Equals("MMBTU"))
                    cunid = "05";
            }
        }
        public string Tp_medida
        { get; set; }
        public decimal Qt_carga
        { get; set; }

        public TRegistro_CTRQtdeCarga()
        {
            this.Cd_empresa = string.Empty;
            this.nr_lanctoCTR = null;
            this.nr_lanctoCTRstr = string.Empty;
            this.id_qtde = null;
            this.id_qtdestr = string.Empty;
            this.cunid = string.Empty;
            this.cunidade = string.Empty;
            this.Tp_medida = string.Empty;
            this.Qt_carga = decimal.Zero;
        }
    }

    public class TCD_CTRQtdeCarga : TDataQuery
    {
        public TCD_CTRQtdeCarga() { }

        public TCD_CTRQtdeCarga(BancoDados.TObjetoBanco banco) { this.Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("select " + strTop + " a.cd_empresa, a.nr_lanctoctr, ");
                sql.AppendLine("a.id_qtde, a.cunid, a.tp_medida, a.qt_carga ");
            }
            else
                sql.AppendLine(" Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from tb_ctr_qtdecarga a ");

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

        public TList_CTRQtdeCarga Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNm_Campo)
        {
            TList_CTRQtdeCarga lista = new TList_CTRQtdeCarga();
            System.Data.SqlClient.SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            try
            {
                reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNm_Campo));
                while (reader.Read())
                {
                    TRegistro_CTRQtdeCarga reg = new TRegistro_CTRQtdeCarga();

                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_lanctoctr")))
                        reg.Nr_lanctoCTR = reader.GetDecimal(reader.GetOrdinal("nr_lanctoctr"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_qtde")))
                        reg.Id_qtde = reader.GetDecimal(reader.GetOrdinal("id_qtde"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cUnid")))
                        reg.cUnid = reader.GetString(reader.GetOrdinal("cUnid"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_medida")))
                        reg.Tp_medida = reader.GetString(reader.GetOrdinal("tp_medida"));
                    if (!reader.IsDBNull(reader.GetOrdinal("qt_carga")))
                        reg.Qt_carga = reader.GetDecimal(reader.GetOrdinal("qt_carga"));

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

        public string Gravar(TRegistro_CTRQtdeCarga val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(6);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_NR_LANCTOCTR", val.Nr_lanctoCTR);
            hs.Add("@P_ID_QTDE", val.Id_qtde);
            hs.Add("@P_CUNID", val.cUnid);
            hs.Add("@P_TP_MEDIDA", val.Tp_medida);
            hs.Add("@P_QT_CARGA", val.Qt_carga);

            return this.executarProc("IA_CTR_QTDECARGA", hs);
        }

        public string Excluir(TRegistro_CTRQtdeCarga val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(3);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_NR_LANCTOCTR", val.Nr_lanctoCTR);
            hs.Add("@P_ID_QTDE", val.Id_qtde);

            return this.executarProc("EXCLUI_CTR_QTDECARGA", hs);
        }
    }
}
