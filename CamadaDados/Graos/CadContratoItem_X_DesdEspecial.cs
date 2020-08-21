using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamadaDados.Graos
{
    public class TList_Contrato_X_DesdEspecial : List<TRegistro_Contrato_X_DesdEspecial>
    { }

    
    public class TRegistro_Contrato_X_DesdEspecial
    {
        private decimal? id_tpdesdobro;
        
        public decimal? Id_tpdesdobro
        {
            get { return id_tpdesdobro; }
            set
            {
                id_tpdesdobro = value;
                id_tpdesdobrostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_tpdesdobrostr;
        
        public string Id_tpdesdobrostr
        {
            get { return id_tpdesdobrostr; }
            set
            {
                id_tpdesdobrostr = value;
                try
                {
                    id_tpdesdobro = decimal.Parse(value);
                }
                catch { id_tpdesdobro = null; }
            }
        }
        
        public string Ds_tpdesdobro
        { get; set; }
        private decimal? nr_contrato;
        
        public decimal? Nr_contrato
        {
            get { return nr_contrato; }
            set
            {
                nr_contrato = value;
                nr_contratostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string nr_contratostr;
        
        public string Nr_contratostr
        {
            get { return nr_contratostr; }
            set
            {
                nr_contratostr = value;
                try
                {
                    nr_contrato = decimal.Parse(value);
                }
                catch { nr_contrato = null; }
            }
        }
        private decimal? nr_contrato_dest;
        
        public decimal? Nr_contrato_dest
        {
            get { return nr_contrato_dest; }
            set
            {
                nr_contrato_dest = value;
                nr_contrato_deststr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string nr_contrato_deststr;
        
        public string Nr_contrato_deststr
        {
            get { return nr_contrato_deststr; }
            set
            {
                nr_contrato_deststr = value;
                try
                {
                    nr_contrato_dest = decimal.Parse(value);
                }
                catch
                { nr_contrato_dest = null; }
            }
        }
        
        public string Cd_empresa_dest
        { get; set; }
        
        public string Nm_empresa_dest
        { get; set; }
        
        public string Cd_clifor_dest
        { get; set; }
        
        public string Nm_clifor_dest
        { get; set; }
        
        public string Cd_produto_dest
        { get; set; }
        
        public string Ds_produto_dest
        { get; set; }
        
        public decimal Valor_desdobro
        { get; set; }
        
        public string Tp_pesodesdobro
        { get; set; }
        public string Tipo_pesodesdobro
        {
            get
            {
                if (Tp_pesodesdobro.Trim().ToUpper().Equals("B"))
                    return "PESO BRUTO";
                else if (Tp_pesodesdobro.Trim().ToUpper().Equals("L"))
                    return "PESO LIQUIDO";
                else return string.Empty;
            }
        }

        public TRegistro_Contrato_X_DesdEspecial()
        {
            this.id_tpdesdobro = null;
            this.id_tpdesdobrostr = string.Empty;
            this.Ds_tpdesdobro = string.Empty;
            this.nr_contrato = null;
            this.nr_contratostr = string.Empty;
            this.nr_contrato_dest = null;
            this.nr_contrato_deststr = string.Empty;
            this.Cd_empresa_dest = string.Empty;
            this.Nm_empresa_dest = string.Empty;
            this.Cd_clifor_dest = string.Empty;
            this.Nm_clifor_dest = string.Empty;
            this.Cd_produto_dest = string.Empty;
            this.Ds_produto_dest = string.Empty;
            this.Valor_desdobro = decimal.Zero;
        }
    }

    public class TCD_Contrato_X_DesdEspecial : TDataQuery
    {
        public TCD_Contrato_X_DesdEspecial()
        { }

        public TCD_Contrato_X_DesdEspecial(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("Select " + strTop + " a.id_tpdesdobro, b.ds_tpdesdobro, ");
                sql.AppendLine("a.nr_contrato, a.valor_desdobro, ");
                sql.AppendLine("a.nr_contrato_dest, c.cd_empresa as cd_empresa_dest, ");
                sql.AppendLine("d.nm_empresa as nm_empresa_dest, c.cd_clifor as cd_clifor_dest, ");
                sql.AppendLine("e.nm_clifor as nm_clifor_dest, ");
                sql.AppendLine("c.cd_produto as cd_produto_dest, ");
                sql.AppendLine("f.ds_produto as ds_produto_dest ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from TB_GRO_Contrato_X_DesdEspecial a ");
            sql.AppendLine("inner join TB_BAL_TpDesdobroEspecial b ");
            sql.AppendLine("on a.ID_TpDesdobro = b.ID_TpDesdobro ");
            sql.AppendLine("inner join vtb_gro_contrato c ");
            sql.AppendLine("on a.nr_contrato_dest = c.nr_contrato ");
            sql.AppendLine("inner join tb_div_empresa d ");
            sql.AppendLine("on c.cd_empresa = d.cd_empresa ");
            sql.AppendLine("inner join tb_fin_clifor e ");
            sql.AppendLine("on c.cd_clifor = e.cd_clifor ");
            sql.AppendLine("inner join tb_est_produto f ");
            sql.AppendLine("on c.cd_produto = f.cd_produto ");

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

        public TList_Contrato_X_DesdEspecial Select(Utils.TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            TList_Contrato_X_DesdEspecial lista = new TList_Contrato_X_DesdEspecial();
            bool podeFecharBco = false;
            if (this.Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);

            System.Data.SqlClient.SqlDataReader reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_Contrato_X_DesdEspecial reg = new TRegistro_Contrato_X_DesdEspecial();
                    if (!reader.IsDBNull(reader.GetOrdinal("id_tpdesdobro")))
                        reg.Id_tpdesdobro = reader.GetDecimal(reader.GetOrdinal("id_tpdesdobro"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_tpdesdobro")))
                        reg.Ds_tpdesdobro = reader.GetString(reader.GetOrdinal("ds_tpdesdobro"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_contrato")))
                        reg.Nr_contrato = reader.GetDecimal(reader.GetOrdinal("nr_contrato"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_contrato_dest")))
                        reg.Nr_contrato_dest = reader.GetDecimal(reader.GetOrdinal("nr_contrato_dest"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa_dest")))
                        reg.Cd_empresa_dest = reader.GetString(reader.GetOrdinal("cd_empresa_dest"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_empresa_dest")))
                        reg.Nm_empresa_dest = reader.GetString(reader.GetOrdinal("nm_empresa_dest"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_clifor_dest")))
                        reg.Cd_clifor_dest = reader.GetString(reader.GetOrdinal("cd_clifor_dest"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_clifor_dest")))
                        reg.Nm_clifor_dest = reader.GetString(reader.GetOrdinal("nm_clifor_dest"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_produto_dest")))
                        reg.Cd_produto_dest = reader.GetString(reader.GetOrdinal("cd_produto_dest"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_produto_dest")))
                        reg.Ds_produto_dest = reader.GetString(reader.GetOrdinal("ds_produto_dest"));
                    if (!reader.IsDBNull(reader.GetOrdinal("valor_desdobro")))
                        reg.Valor_desdobro = reader.GetDecimal(reader.GetOrdinal("valor_desdobro"));


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

        public string Gravar(TRegistro_Contrato_X_DesdEspecial val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(4);
            hs.Add("@P_ID_TPDESDOBRO", val.Id_tpdesdobro);
            hs.Add("@P_NR_CONTRATO", val.Nr_contrato);
            hs.Add("@P_NR_CONTRATO_DEST", val.Nr_contrato_dest);
            hs.Add("@P_VALOR_DESDOBRO", val.Valor_desdobro);

            return this.executarProc("IA_GRO_CONTRATO_X_DESDESPECIAL", hs);
        }

        public string Excluir(TRegistro_Contrato_X_DesdEspecial val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(2);
            hs.Add("@P_ID_TPDESDOBRO", val.Id_tpdesdobro);
            hs.Add("@P_NR_CONTRATO", val.Nr_contrato);

            return this.executarProc("EXCLUI_GRO_CONTRATO_X_DESDESPECIAL", hs);
        }
    }
}
