using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace CamadaDados.Financeiro.Cadastros
{
    public class TList_CadMotorista : List<TRegistro_CadMotorista>
    { }
    

    [DataContract]
    public class TRegistro_CadMotorista
    {

        [DataMember]
        public string Cd_motorista
        { get; set; }
        [DataMember]
        public string Nm_motorista
        { get; set; }
        [DataMember]
        public decimal Id_veiculo
        { get; set; }
        [DataMember]
        public string Ds_veiculo
        { get; set; }
        [DataMember]
        public string CNH
        { get; set; }
        [DataMember]
        public string categoria_CNH
        { get; set; }
        private DateTime? dt_vencimento_CNH;
        [DataMember]
        public DateTime? Dt_vencimento_CNH
        {
            get { return dt_vencimento_CNH; }
            set
            {
                dt_vencimento_CNH = value;
                dt_vencimento_CNHstr = value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty;
            }
        }
        private string dt_vencimento_CNHstr;
        public string Dt_vencimento_CNHstr
        {
            get
            {
                try
                {
                    return Convert.ToDateTime(dt_vencimento_CNH).ToString("dd/MM/yyyy");
                }
                catch
                { return string.Empty; }
            }
            set
            {
                dt_vencimento_CNHstr = value;
                try
                {
                    dt_vencimento_CNH = Convert.ToDateTime(value);
                }
                catch
                { dt_vencimento_CNH = null; }
            }
        }


        public TRegistro_CadMotorista()
        {
            this.Cd_motorista = string.Empty;
            this.Nm_motorista = string.Empty;
            this.Id_veiculo = decimal.Zero;
            this.Ds_veiculo = string.Empty;
            this.CNH = string.Empty;
            this.categoria_CNH = string.Empty;
            this.dt_vencimento_CNH = null;



        }
    }

    public class TCD_CadMotorista : TDataQuery
    {
        public TCD_CadMotorista()
        { }

        public TCD_CadMotorista(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("select " + strTop + " a.cd_motorista, b.nm_clifor as nm_motorista  ");
                sql.AppendLine("a.id_veiculo, c.ds_veiculo, a.cnh, a.categoria_cnh, a.dt_vencimento_cnh ");


            }
            else
                sql.AppendLine(" Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from TB_FRT_motorista a ");
            sql.AppendLine("inner join TB_FIN_Clifor b ");
            sql.AppendLine("on a.cd_motorista = b.cd_clifor");
            sql.AppendLine("inner join TB_FRT_veiculo c ");
            sql.AppendLine("on a.id_veiculo = c.id_veiculo ");


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

        public TList_CadMotorista Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNm_Campo)
        {
            TList_CadMotorista lista = new TList_CadMotorista();
            System.Data.SqlClient.SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            try
            {
                reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNm_Campo));
                while (reader.Read())
                {
                    TRegistro_CadMotorista reg = new TRegistro_CadMotorista();

                    if (!reader.IsDBNull(reader.GetOrdinal("cd_motorista")))
                        reg.Cd_motorista = reader.GetString(reader.GetOrdinal("cd_motorista"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_motorista")))
                        reg.Nm_motorista = reader.GetString(reader.GetOrdinal("nm_motorista"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_veiculo")))
                        reg.Id_veiculo = reader.GetDecimal(reader.GetOrdinal("id_veiculo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_veiculo")))
                        reg.Ds_veiculo = reader.GetString(reader.GetOrdinal("ds_veiculo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cnh")))
                        reg.CNH = reader.GetString(reader.GetOrdinal("cnh"));
                    if (!reader.IsDBNull(reader.GetOrdinal("categoria_cnh")))
                        reg.categoria_CNH = reader.GetString(reader.GetOrdinal("categoria_cnh"));
                    if (!reader.IsDBNull(reader.GetOrdinal("dt_vencimento_cnh")))
                        reg.Dt_vencimento_CNH = reader.GetDateTime(reader.GetOrdinal("dt_vencimento_cnh"));


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

        public string Gravar(TRegistro_CadMotorista val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(5);
            hs.Add("@P_CD_MOTORISTA", val.Cd_motorista);
            hs.Add("@P_ID_VEICULO", val.Id_veiculo);
            hs.Add("@P_CNH", val.CNH);
            hs.Add("@P_CATEGORIA_CNH", val.categoria_CNH);
            hs.Add("@P_DT_VENCIMENTO_CNH", val.Dt_vencimento_CNH);


            return this.executarProc("IA_FRT_MOTORISTA", hs);
        }

        public string Excluir(TRegistro_CadMotorista val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(1);
            hs.Add("@P_CD_MOTORISTA", val.Cd_motorista);

            return this.executarProc("EXCLUI_FRT_MOTORISTA", hs);
        }


    }

    
}
