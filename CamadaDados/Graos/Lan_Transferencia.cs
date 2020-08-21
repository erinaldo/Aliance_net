using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using System.Collections;

namespace CamadaDados.Graos
{
    public class TList_Transferencia : List<TRegistro_Transferencia>, IComparer<TRegistro_Transferencia>
    {
        #region IComparer<TRegistro_Transferencia> Members
        private System.ComponentModel.PropertyDescriptor Propriedade;
        private System.Windows.Forms.SortOrder Direcao;

        private int CompareAscending(object x, object y)
        {
            if (x is IComparable)
                return new CaseInsensitiveComparer().Compare(x, y);
            else
                return 0;
        }

        private int CompareDescending(object x, object y)
        {
            return -CompareAscending(x, y);
        }

        public TList_Transferencia()
        { }

        public TList_Transferencia(System.ComponentModel.PropertyDescriptor Prop,
                                   System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_Transferencia value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_Transferencia x, TRegistro_Transferencia y)
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
    
    public class TRegistro_Transferencia
    {
        public decimal ID_Transf
        { get; set; }
        private decimal? id_autoriz;
        public decimal? Id_autoriz
        {
            get { return id_autoriz; }
            set
            {
                id_autoriz = value;
                id_autorizstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_autorizstr;
        public string Id_autorizstr
        {
            get { return id_autorizstr; }
            set
            {
                id_autorizstr = value;
                try
                {
                    id_autoriz = Convert.ToDecimal(value);
                }
                catch
                { id_autoriz = null; }
            }
        }
        public string DS_Observacao
        { get; set; }
        private DateTime? dt_lancto;
        public DateTime? DT_Lancto
        {
            get { return dt_lancto; }
            set 
            {
                dt_lancto = value;
                dt_lanctostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string dt_lanctostr;
        public string DT_Lancto_String
        {
            get
            {
                try
                {
                    return Convert.ToDateTime(dt_lanctostr).ToString("dd/MM/yyyy");
                }
                catch
                { return string.Empty; }
            }
            set
            {
                dt_lanctostr = value;
                try
                {
                    dt_lancto = Convert.ToDateTime(value);
                }
                catch
                { dt_lancto = null; }
            }
        }
        public decimal QTD_Transf
        { get; set; }
        public decimal VL_Unit_Origem
        { get; set; }
        public decimal VL_Unit_Destino
        { get; set; }
        public decimal VL_Sub_Total_Origem
        { get; set; }
        public decimal VL_Sub_Total_Destino
        { get; set; }
        private string st_registro;
        public string St_registro
        {
            get { return st_registro; }
            set
            {
                st_registro = value;
                if (value.Trim().ToUpper().Equals("A"))
                    status = "ATIVO";
                else if (value.Trim().ToUpper().Equals("C"))
                    status = "CANCELADO";
            }
        }
        private string status;
        public string Status
        {
            get { return status; }
            set
            {
                status = value;
                if (value.Trim().ToUpper().Equals("ATIVO"))
                    st_registro = "A";
                else if (value.Trim().ToUpper().Equals("CANCELADO"))
                    st_registro = "C";
            }
        }
        public TList_Transf_X_Contrato Transf_X_Contrato_Origem
        { get; set; }
        public TList_Transf_X_Contrato Transf_X_Contrato_Destino
        { get; set; }
        //Objetos Necessarios Para Processar Transferencia
        public CamadaDados.Financeiro.Cadastros.TRegistro_CadClifor Reg_Clifor_Destino
        { get; set; }
        public CamadaDados.Financeiro.Cadastros.TRegistro_CadClifor Reg_Clifor_Origem
        { get; set; }
        public CamadaDados.Faturamento.NotaFiscal.TList_LanFat_ComplementoDevolucao Complemento_Devolucao
        { get; set; }
        public CamadaDados.Graos.TRegistro_CadContrato Contrato_Origem
        { get; set; }
        public CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento rNfOrigem
        { get; set; }
        public CamadaDados.Graos.TRegistro_CadContrato Contrato_Destino
        { get; set; }
        public CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento rNfDestino
        { get; set; }
        public CamadaDados.Financeiro.Duplicata.TList_RegLanDuplicata Duplicata_Origem
        { get; set; }
        public CamadaDados.Financeiro.Duplicata.TList_RegLanDuplicata Duplicata_Destino
        { get; set; }
        public CamadaDados.Estoque.Cadastros.TRegistro_CadProduto Reg_Produto_Origem
        { get; set; }
        public CamadaDados.Diversos.TRegistro_CadEmpresa Reg_Empresa_Origem
        { get; set; }
        public CamadaDados.Estoque.Cadastros.TRegistro_CadProduto Reg_Produto_Destino
        { get; set; }
        public CamadaDados.Diversos.TRegistro_CadEmpresa Reg_Empresa_Destino
        { get; set; }

        public TRegistro_Transferencia()
        {
            this.id_autoriz = null;
            this.id_autorizstr = string.Empty;
            this.DS_Observacao = string.Empty;
            this.dt_lancto = DateTime.Now;
            this.dt_lanctostr = DateTime.Now.ToString("dd/MM/yyyy");
            this.ID_Transf = decimal.Zero;
            this.QTD_Transf = decimal.Zero;
            this.Transf_X_Contrato_Destino = new TList_Transf_X_Contrato();
            this.Transf_X_Contrato_Origem = new TList_Transf_X_Contrato();
            this.VL_Sub_Total_Destino = decimal.Zero;
            this.VL_Sub_Total_Origem = decimal.Zero;
            this.VL_Unit_Destino = decimal.Zero;
            this.VL_Unit_Origem = decimal.Zero;
            this.st_registro = "A";
            this.status = "ATIVO";
            this.Reg_Clifor_Destino = null;
            this.Reg_Clifor_Origem = null;
            this.Complemento_Devolucao = new CamadaDados.Faturamento.NotaFiscal.TList_LanFat_ComplementoDevolucao();
            this.Contrato_Origem = null;
            this.rNfOrigem = null;
            this.Contrato_Destino = null;
            this.rNfDestino = null;
            this.Duplicata_Origem = new CamadaDados.Financeiro.Duplicata.TList_RegLanDuplicata();
            this.Duplicata_Destino = new CamadaDados.Financeiro.Duplicata.TList_RegLanDuplicata();
            this.Reg_Produto_Origem = null;
            this.Reg_Empresa_Origem = null;
            this.Reg_Produto_Destino = null;
            this.Reg_Empresa_Destino = null;
        }
    }

    public class TCD_Transferencia : TDataQuery
    {
        public TCD_Transferencia()
        { }
        public TCD_Transferencia(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }
        private string SqlCodeBusca(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();

            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine(" SELECT " + strTop + " a.id_transf, a.ds_observacao, a.dt_lancto, a.qtd_transf, ");
                sql.AppendLine("a.vl_unit_origem, a.vl_unit_Destino, a.id_autoriz, a.st_registro, ");
                sql.AppendLine("a.VL_Sub_total_Origem, a.VL_Sub_total_Destino "); 
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("FROM vtb_gro_transferencia a ");
           
            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.Append(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                    cond = " and ";
                }
                        
            return sql.ToString();
        }
        public override DataTable Buscar(TpBusca[] vBusca, short vTop)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, ""), null);
        }
        public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
        {
            return this.ExecutarBuscaEscalar(this.SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }
        public TList_Transferencia Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_Transferencia lista = new TList_Transferencia();
            SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);

            try
            {
                reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
                while (reader.Read())
                {
                    TRegistro_Transferencia reg = new TRegistro_Transferencia();
                    
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Transf")))
                        reg.ID_Transf = reader.GetDecimal(reader.GetOrdinal("ID_Transf"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Autoriz")))
                        reg.Id_autoriz = reader.GetDecimal(reader.GetOrdinal("ID_Autoriz"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_OBSERVACAO")))
                        reg.DS_Observacao = reader.GetString(reader.GetOrdinal("DS_OBSERVACAO"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DT_Lancto")))
                        reg.DT_Lancto = reader.GetDateTime(reader.GetOrdinal("DT_Lancto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("QTD_Transf")))
                        reg.QTD_Transf = reader.GetDecimal(reader.GetOrdinal("QTD_Transf"));
                    if (!reader.IsDBNull(reader.GetOrdinal("VL_Unit_Origem")))
                        reg.VL_Unit_Origem = reader.GetDecimal(reader.GetOrdinal("VL_Unit_Origem"));
                    if (!reader.IsDBNull(reader.GetOrdinal("VL_Unit_Destino")))
                        reg.VL_Unit_Destino = reader.GetDecimal(reader.GetOrdinal("VL_Unit_Destino"));
                    if (!reader.IsDBNull(reader.GetOrdinal("VL_SUB_TOTAL_Origem")))
                        reg.VL_Sub_Total_Origem = reader.GetDecimal(reader.GetOrdinal("VL_SUB_TOTAL_Origem"));
                    if (!reader.IsDBNull(reader.GetOrdinal("VL_SUB_TOTAL_Destino")))
                        reg.VL_Sub_Total_Destino = reader.GetDecimal(reader.GetOrdinal("VL_SUB_TOTAL_Destino"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ST_Registro")))
                        reg.St_registro = reader.GetString(reader.GetOrdinal("ST_Registro"));

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
        public string Gravar(TRegistro_Transferencia vRegistro)
        {
            Hashtable hs = new Hashtable(8);
            hs.Add("@P_ID_TRANSF", vRegistro.ID_Transf);
            hs.Add("@P_ID_AUTORIZ", vRegistro.Id_autoriz);
            hs.Add("@P_DS_OBSERVACAO", vRegistro.DS_Observacao);
            hs.Add("@P_DT_LANCTO", vRegistro.DT_Lancto);
            hs.Add("@P_QTD_TRANSF", vRegistro.QTD_Transf);
            hs.Add("@P_VL_UNIT_ORIGEM", vRegistro.VL_Unit_Origem);
            hs.Add("@P_VL_UNIT_DESTINO", vRegistro.VL_Unit_Destino);
            hs.Add("@P_ST_REGISTRO", vRegistro.St_registro);

            return this.executarProc("IA_GRO_TRANSFERENCIA", hs);
        }
        public string Excluir(TRegistro_Transferencia vRegistro)
        {
            Hashtable hs = new Hashtable(1);
            hs.Add("@P_ID_TRANSF", vRegistro.ID_Transf);
            return this.executarProc("EXCLUI_GRO_TRANSFERENCIA", hs);
        }
    }
}
