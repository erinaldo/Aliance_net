using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamadaDados.Financeiro.Duplicata
{
    public class TList_VincularDup : List<TRegistro_VincularDup>
    { }
    
    public class TRegistro_VincularDup
    {
        private decimal? id_vincular;
        public decimal? Id_vincular
        {
            get { return id_vincular; }
            set
            {
                id_vincular = value;
                id_vincularstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_vincularstr;
        public string Id_vincularstr
        {
            get { return id_vincularstr; }
            set
            {
                id_vincularstr = value;
                try
                {
                    id_vincular = decimal.Parse(value);
                }
                catch
                { id_vincular = null; }
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
        public decimal? Nr_lanctovinculado
        { get; set; }
        public string Nr_lanctovinculadostr
        { get; set; }
        private decimal? cd_parcelavinculado;
        public decimal? Cd_parcelavinculado
        {
            get { return cd_parcelavinculado; }
            set
            {
                cd_parcelavinculado = value;
                cd_parcelavinculadostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string cd_parcelavinculadostr;
        public string Cd_parcelavinculadostr
        {
            get { return cd_parcelavinculadostr; }
            set
            {
                cd_parcelavinculadostr = value;
                try
                {
                    cd_parcelavinculado = decimal.Parse(value);
                }
                catch
                { cd_parcelavinculado = null; }
            }
        }
        public decimal Vl_parcelavinculado
        { get; set; }

        public TRegistro_VincularDup()
        {
            this.id_vincular = null;
            this.id_vincularstr = string.Empty;
            this.Cd_empresa = string.Empty;
            this.nr_lancto = null;
            this.nr_lanctostr = string.Empty;
            this.cd_parcelavinculado = null;
            this.cd_parcelavinculadostr = string.Empty;
            this.Vl_parcelavinculado = decimal.Zero;
        }
    }

    public class TCD_VincularDup : TDataQuery
    {
        public TCD_VincularDup()
        { }

        public TCD_VincularDup(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("select " + strTop + " a.id_vincular, a.CD_Empresa, a.nr_lancto, ");
                sql.AppendLine("a.nr_lanctovinculado, a.cd_parcelavinculado, a.vl_parcelavinculado ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from TB_FIN_VincularDup a ");

            string cond = " Where ";
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

        public TList_VincularDup Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            bool podeFecharBco = false;
            TList_VincularDup lista = new TList_VincularDup();
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_VincularDup reg = new TRegistro_VincularDup();
                    if (!reader.IsDBNull(reader.GetOrdinal("id_vincular")))
                        reg.Id_vincular = reader.GetDecimal(reader.GetOrdinal("id_vincular"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_Empresa"))))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("CD_Empresa"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("NR_Lancto"))))
                        reg.Nr_lancto = reader.GetDecimal(reader.GetOrdinal("NR_Lancto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NR_LanctoVinculado")))
                        reg.Nr_lanctovinculado = reader.GetDecimal(reader.GetOrdinal("NR_LanctoVinculado"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_ParcelaVinculado"))))
                        reg.Cd_parcelavinculado = reader.GetDecimal(reader.GetOrdinal("CD_ParcelaVinculado"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_ParcelaVinculado")))
                        reg.Vl_parcelavinculado = reader.GetDecimal(reader.GetOrdinal("Vl_ParcelaVinculado"));
                    
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

        public string Gravar(TRegistro_VincularDup val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(6);
            hs.Add("@P_ID_VINCULAR", val.Id_vincular);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_NR_LANCTO", val.Nr_lancto);
            hs.Add("@P_NR_LANCTOVINCULADO", val.Nr_lanctovinculado);
            hs.Add("@P_CD_PARCELAVINCULADO", val.Cd_parcelavinculado);
            hs.Add("@P_VL_PARCELAVINCULADO", val.Vl_parcelavinculado);

            return this.executarProc("IA_FIN_VINCULARDUP", hs);
        }

        public string Excluir(TRegistro_VincularDup val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(1);
            hs.Add("@P_ID_VINCULAR", val.Id_vincular);

            return this.executarProc("EXCLUI_FIN_VINCULARDUP", hs);
        }
    }
}
