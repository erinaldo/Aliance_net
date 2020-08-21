using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Utils;

namespace CamadaDados.Contabil
{
    public class TList_AtualizaEstFixar : List<TRegistro_AtualizaEstFixar> { }
    public class TRegistro_AtualizaEstFixar
    {
        public string Cd_empresa { get; set; }
        public string Nm_empresa { get; set; }
        public string Cd_produto { get; set; }
        public string Ds_produto { get; set; }
        private decimal? id_atualiza;

        public decimal? Id_atualiza
        {
            get { return id_atualiza; }
            set
            {
                id_atualiza = value;
                id_atualizastr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_atualizastr;

        public string Id_atualizastr
        {
            get { return id_atualizastr; }
            set
            {
                id_atualizastr = value;
                try
                {
                    id_atualiza = decimal.Parse(value);
                }catch { id_atualiza = null; }
            }
        }
        private decimal? id_loteCTB;

        public decimal? Id_loteCTB
        {
            get { return id_loteCTB; }
            set
            {
                id_loteCTB = value;
                id_loteCTBstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_loteCTBstr;

        public string Id_loteCTBstr
        {
            get { return id_loteCTBstr; }
            set
            {
                id_loteCTBstr = value;
                try
                {
                    id_loteCTB = decimal.Parse(value);
                }catch { id_loteCTB = null; }
            }
        }
        private DateTime? dt_lancto;

        public DateTime? Dt_lancto
        {
            get { return dt_lancto; }
            set
            {
                dt_lancto = value;
                dt_lanctostr = value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty;
            }
        }
        private string dt_lanctostr;

        public string Dt_lanctostr
        {
            get { return dt_lanctostr; }
            set
            {
                dt_lanctostr = value;
                try
                {
                    dt_lancto = DateTime.Parse(value);
                }catch { dt_lancto = null; }
            }
        }
        public string Tp_registro { get; set; }
        public string Tipo_registro
        {
            get
            {
                if (Tp_registro.Trim().ToUpper().Equals("E"))
                    return "ESTORNO";
                else if (Tp_registro.Trim().ToUpper().Equals("A"))
                    return "ATUALIZAÇÃO";
                else return string.Empty;
            }
        }
        private string tp_movimento;

        public string Tp_movimento
        {
            get { return tp_movimento; }
            set
            {
                tp_movimento = value;
                if (value.Trim().ToUpper().Equals("C"))
                    tipo_movimento = "COMPRA";
                else if (value.Trim().ToUpper().Equals("V"))
                    tipo_movimento = "VENDA";
            }
        }
        private string tipo_movimento;

        public string Tipo_movimento
        {
            get { return tipo_movimento; }
            set
            {
                tipo_movimento = value;
                if (value.Trim().ToUpper().Equals("COMPRA"))
                    tp_movimento = "C";
                else if (value.Trim().ToUpper().Equals("VENDA"))
                    tp_movimento = "V";
            }
        }

        public decimal Valor { get; set; }
        public TRegistro_AtualizaEstFixar()
        {
            Cd_empresa = string.Empty;
            Nm_empresa = string.Empty;
            Cd_produto = string.Empty;
            Ds_produto = string.Empty;
            id_atualiza = null;
            id_atualizastr = string.Empty;
            id_loteCTB = null;
            id_loteCTBstr = string.Empty;
            dt_lancto = null;
            dt_lanctostr = string.Empty;
            Tp_registro = string.Empty;
            tp_movimento = string.Empty;
            tipo_movimento = string.Empty;
            Valor = decimal.Zero;
        }
    }
    public class TCD_AtualizaEstFixar:TDataQuery
    {
        public TCD_AtualizaEstFixar() { }
        public TCD_AtualizaEstFixar(BancoDados.TObjetoBanco banco) { Banco_Dados = banco; }
        private string SqlCodeBusca(TpBusca[] vBusca, int vTop, string vNM_Campo, string vOrder)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();

            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine(" SELECT " + strTop);
                sql.AppendLine("a.cd_empresa, b.nm_empresa, a.cd_produto, c.ds_produto, a.tp_movimento, ");
                sql.AppendLine("a.id_atualiza, a.id_loteCTB, a.dt_lancto, a.tp_registro, a.valor ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("FROM TB_CTB_AtualizaEstFixar a ");
            sql.AppendLine("inner join TB_DIV_Empresa b ");
            sql.AppendLine("on a.cd_empresa = b.cd_empresa ");
            sql.AppendLine("inner join TB_EST_Produto c ");
            sql.AppendLine("on a.cd_produto = c.cd_produto ");

            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.Append(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                    cond = " and ";
                }
            if (!string.IsNullOrEmpty(vOrder))
                sql.AppendLine("order by " + vOrder);
            else sql.AppendLine("order by a.cd_empresa, a.cd_produto, a.dt_lancto ");
            return sql.ToString();
        }
        public override DataTable Buscar(TpBusca[] vBusca, short vTop)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, string.Empty, string.Empty), null);
        }
        public override DataTable Buscar(TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo, string.Empty), null);
        }
        public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
        {
            return ExecutarBuscaEscalar(SqlCodeBusca(vBusca, 1, vNM_Campo, string.Empty), null);
        }
        public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo, string vGroup, string vOrder, Hashtable vParametros)
        {
            return ExecutarBuscaEscalar(SqlCodeBusca(vBusca, 1, vNM_Campo, vOrder), vParametros);
        }
        public TList_AtualizaEstFixar Select(TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            TList_AtualizaEstFixar lista = new TList_AtualizaEstFixar();
            SqlDataReader reader;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);

            try
            {
                reader = ExecutarBusca(SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo, string.Empty));
                while (reader.Read())
                {
                    TRegistro_AtualizaEstFixar reg = new TRegistro_AtualizaEstFixar();
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_empresa")))
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("nm_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_produto")))
                        reg.Cd_produto = reader.GetString(reader.GetOrdinal("cd_produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_produto")))
                        reg.Ds_produto = reader.GetString(reader.GetOrdinal("ds_produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_atualiza")))
                        reg.Id_atualiza = reader.GetDecimal(reader.GetOrdinal("id_atualiza"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_loteCTB")))
                        reg.Id_loteCTB = reader.GetDecimal(reader.GetOrdinal("id_loteCTB"));
                    if (!reader.IsDBNull(reader.GetOrdinal("dt_lancto")))
                        reg.Dt_lancto = reader.GetDateTime(reader.GetOrdinal("dt_lancto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_registro")))
                        reg.Tp_registro = reader.GetString(reader.GetOrdinal("tp_registro"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_movimento")))
                        reg.Tp_movimento = reader.GetString(reader.GetOrdinal("tp_movimento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("valor")))
                        reg.Valor = reader.GetDecimal(reader.GetOrdinal("valor"));
                    lista.Add(reg);
                }
            }
            finally
            {
                if (podeFecharBco)
                    deletarBanco_Dados();
            }
            return lista;
        }
        public string Gravar(TRegistro_AtualizaEstFixar val)
        {
            Hashtable hs = new Hashtable(8);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_CD_PRODUTO", val.Cd_produto);
            hs.Add("@P_ID_ATUALIZA", val.Id_atualiza);
            hs.Add("@P_ID_LOTECTB", val.Id_loteCTB);
            hs.Add("@P_DT_LANCTO", val.Dt_lancto);
            hs.Add("@P_TP_REGISTRO", val.Tp_registro);
            hs.Add("@P_TP_MOVIMENTO", val.Tp_movimento);
            hs.Add("@P_VALOR", val.Valor);
            return executarProc("IA_CTB_ATUALIZAESTFIXAR", hs);
        }
        public string Excluir(TRegistro_AtualizaEstFixar val)
        {
            Hashtable hs = new Hashtable(3);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_CD_PRODUTO", val.Cd_produto);
            hs.Add("@P_ID_ATUALIZA", val.Id_atualiza);
            return executarProc("EXCLUI_CTB_ATUALIZAESTFIXAR", hs);
        }
    }
}
