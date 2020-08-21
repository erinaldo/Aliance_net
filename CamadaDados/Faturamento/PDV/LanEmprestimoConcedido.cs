using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamadaDados.Faturamento.PDV
{
    public class TList_EmprestimoConcedido : List<TRegistro_EmprestimoConcedido>, IComparer<TRegistro_EmprestimoConcedido>
    {
        #region IComparer<TRegistro_EmprestimoConcedido> Members
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

        public TList_EmprestimoConcedido()
        { }

        public TList_EmprestimoConcedido(System.ComponentModel.PropertyDescriptor Prop,
                                         System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_EmprestimoConcedido value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_EmprestimoConcedido x, TRegistro_EmprestimoConcedido y)
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

    
    public class TRegistro_EmprestimoConcedido
    {
        private decimal? id_emprestimo;
        
        public decimal? Id_emprestimo
        {
            get { return id_emprestimo; }
            set
            {
                id_emprestimo = value;
                id_emprestimostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_emprestimostr;
        
        public string Id_emprestimostr
        {
            get { return id_emprestimostr; }
            set
            {
                id_emprestimostr = value;
                try
                {
                    id_emprestimo = decimal.Parse(value);
                }
                catch { id_emprestimo = null; }
            }
        }
        
        public string Cd_empresa
        { get; set; }
        
        public string Nm_empresa
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
                catch { nr_lancto = null; }
            }
        }
        
        public string Cd_clifor
        { get; set; }
        
        public string Nm_clifor
        { get; set; }
        private decimal? id_retirada;
        
        public decimal? Id_retirada
        {
            get { return id_retirada; }
            set
            {
                id_retirada = value;
                id_retiradastr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_retiradastr;
        
        public string Id_retiradastr
        {
            get { return id_retiradastr; }
            set
            {
                id_retiradastr = value;
                try
                {
                    id_retirada = decimal.Parse(value);
                }
                catch { id_retirada = null; }
            }
        }
        private decimal? id_caixa;
        
        public decimal? Id_caixa
        {
            get { return id_caixa; }
            set
            {
                id_caixa = value;
                id_caixastr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_caixastr;
        
        public string Id_caixastr
        {
            get { return id_caixastr; }
            set
            {
                id_caixastr = value;
                try
                {
                    id_caixa = decimal.Parse(value);
                }
                catch { id_caixa = null; }
            }
        }
        
        public decimal Vl_emprestimo
        { get; set; }
        
        public string Placa
        { get; set; }
        
        public string Nm_motorista
        { get; set; }
        
        public string St_registro
        { get; set; }
        public string Status
        {
            get
            {
                if (this.St_registro.Trim().ToUpper().Equals("A"))
                    return "ATIVO";
                else if (this.St_registro.Trim().ToUpper().Equals("C"))
                    return "CANCELADO";
                else return string.Empty;
            }
        }
        
        public CamadaDados.Financeiro.Duplicata.TRegistro_LanDuplicata rDup
        { get; set; }
        
        public TRegistro_RetiradaCaixa rRetirada
        { get; set; }

        public TRegistro_EmprestimoConcedido()
        {
            this.id_emprestimo = null;
            this.id_emprestimostr = string.Empty;
            this.Cd_empresa = string.Empty;
            this.Nm_empresa = string.Empty;
            this.nr_lancto = null;
            this.nr_lanctostr = string.Empty;
            this.Cd_clifor = string.Empty;
            this.Nm_clifor = string.Empty;
            this.id_retirada = null;
            this.id_retiradastr = string.Empty;
            this.id_caixa = null;
            this.id_caixastr = string.Empty;
            this.Vl_emprestimo = decimal.Zero;
            this.Placa = string.Empty;
            this.Nm_motorista = string.Empty;
            this.St_registro = "A";
            this.rDup = null;
            this.rRetirada = null;
        }
    }

    public class TCD_EmprestimoConcedido : TDataQuery
    {
        public TCD_EmprestimoConcedido() { }

        public TCD_EmprestimoConcedido(BancoDados.TObjetoBanco banco) { this.Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + vTop.ToString();

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("select " + strTop + " a.ID_Emprestimo, a.CD_Empresa, ");
                sql.AppendLine("d.NM_Empresa, a.Nr_Lancto, a.ID_Retirada, b.ID_Caixa, a.st_registro, ");
                sql.AppendLine("a.Placa, a.NM_Motorista, c.CD_Clifor, e.NM_Clifor, b.Vl_Retirada ");
            }
            else
                sql.AppendLine(" Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from tb_pdv_emprestimoconcedido a ");
            sql.AppendLine("inner join TB_PDV_RetiradaCaixa b ");
            sql.AppendLine("on a.ID_Retirada = b.ID_Retirada ");
            sql.AppendLine("inner join TB_FIN_Duplicata c ");
            sql.AppendLine("on a.CD_Empresa = c.CD_Empresa ");
            sql.AppendLine("and a.Nr_Lancto = c.Nr_Lancto ");
            sql.AppendLine("inner join TB_DIV_Empresa d ");
            sql.AppendLine("on a.CD_Empresa = d.CD_Empresa ");
            sql.AppendLine("inner join TB_FIN_Clifor e ");
            sql.AppendLine("on c.CD_Clifor = e.CD_Clifor ");

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

        public TList_EmprestimoConcedido Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            bool podeFecharBco = false;
            TList_EmprestimoConcedido lista = new TList_EmprestimoConcedido();
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_EmprestimoConcedido reg = new TRegistro_EmprestimoConcedido();
                    if (!(reader.IsDBNull(reader.GetOrdinal("ID_Emprestimo"))))
                        reg.Id_emprestimo = reader.GetDecimal(reader.GetOrdinal("ID_Emprestimo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_empresa")))
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("nm_empresa"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("Nr_Lancto"))))
                        reg.Nr_lancto = reader.GetDecimal(reader.GetOrdinal("Nr_Lancto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Retirada")))
                        reg.Id_retirada = reader.GetDecimal(reader.GetOrdinal("ID_Retirada"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Caixa")))
                        reg.Id_caixa = reader.GetDecimal(reader.GetOrdinal("ID_Caixa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Placa")))
                        reg.Placa = reader.GetString(reader.GetOrdinal("Placa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NM_Motorista")))
                        reg.Nm_motorista = reader.GetString(reader.GetOrdinal("NM_Motorista"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_Retirada")))
                        reg.Vl_emprestimo = reader.GetDecimal(reader.GetOrdinal("Vl_Retirada"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_registro")))
                        reg.St_registro = reader.GetString(reader.GetOrdinal("st_registro"));

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

        public string Gravar(TRegistro_EmprestimoConcedido val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(7);
            hs.Add("@P_ID_EMPRESTIMO", val.Id_emprestimo);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_NR_LANCTO", val.Nr_lancto);
            hs.Add("@P_ID_RETIRADA", val.Id_retirada);
            hs.Add("@P_PLACA", val.Placa);
            hs.Add("@P_NM_MOTORISTA", val.Nm_motorista);
            hs.Add("@P_ST_REGISTRO", val.St_registro);

            return this.executarProc("IA_PDV_EMPRESTIMOCONCEDIDO", hs);
        }

        public string Excluir(TRegistro_EmprestimoConcedido val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(2);
            hs.Add("@P_ID_EMPRESTIMO", val.Id_emprestimo);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);

            return this.executarProc("EXCLUI_PDV_EMPRESTIMOCONCEDIDO", hs);
        }
    }
}
