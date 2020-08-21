using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamadaDados.Faturamento.Cadastros
{
    public class TList_PontoVenda : List<TRegistro_PontoVenda>, IComparer<TRegistro_PontoVenda>
    {
        #region IComparer<TRegistro_PontoVenda> Members
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

        public TList_PontoVenda()
        { }

        public TList_PontoVenda(System.ComponentModel.PropertyDescriptor Prop,
                                System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_PontoVenda value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_PontoVenda x, TRegistro_PontoVenda y)
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
    
    public class TRegistro_PontoVenda
    {
        public string id_localimp { get; set; } = string.Empty;
        public string ds_localimp { get; set; } = string.Empty;
        public string porta_imp { get; set; } = string.Empty;
        public string tp_imp { get; set; } = string.Empty;
        private decimal? id_pdv;
        public decimal? Id_pdv
        {
            get { return id_pdv; }
            set
            {
                id_pdv = value;
                id_pdvstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_pdvstr;
        public string Id_pdvstr
        {
            get { return id_pdvstr; }
            set
            {
                id_pdvstr = value;
                try
                {
                    id_pdv = Convert.ToDecimal(value);
                }
                catch
                { id_pdv = null; }
            }
        }
        public string Ds_pdv
        { get; set; }
        public string Cd_terminal
        { get; set; }
        public string Ds_terminal
        { get; set; }
        public string Cd_empresa
        { get; set; }
        public string Nm_empresa
        { get; set; }
        public string St_registro
        { get; set; }
        private string st_vendacombustivel;
        public string St_vendacombustivel
        {
            get { return st_vendacombustivel; }
            set
            {
                st_vendacombustivel = value;
                st_vendacombustivelbool = value.Trim().ToUpper().Equals("S");
            }
        }
        private bool st_vendacombustivelbool;
        public bool St_vendacombustivelbool
        {
            get { return st_vendacombustivelbool; }
            set
            {
                st_vendacombustivelbool = value;
                st_vendacombustivel = value ? "S" : "N";
            }
        }
        public decimal Vl_maxretcaixa
        { get; set; }
        private string st_fixarvlretido;
        public string St_fixarvlretido
        {
            get { return st_fixarvlretido; }
            set
            {
                st_fixarvlretido = value;
                st_fixarvlretidobool = value.Trim().ToUpper().Equals("S");
            }
        }
        private bool st_fixarvlretidobool;
        public bool St_fixarvlretidobool
        {
            get { return st_fixarvlretidobool; }
            set
            {
                st_fixarvlretidobool = value;
                st_fixarvlretido = value ? "S" : "N";
            }
        }
        private string st_gavetadinheiro;
        public string St_gavetadinheiro
        {
            get { return st_gavetadinheiro; }
            set
            {
                st_gavetadinheiro = value;
                st_gavetadinheirobool = value.Trim().ToUpper().Equals("S");
            }
        }
        private bool st_gavetadinheirobool;
        public bool St_gavetadinheirobool
        {
            get { return st_gavetadinheirobool; }
            set
            {
                st_gavetadinheirobool = value;
                st_gavetadinheiro = value ? "S" : "N";
            }
        }
        private string tp_impnaofiscal;
        public string Tp_impnaofiscal
        {
            get { return tp_impnaofiscal; }
            set
            {
                tp_impnaofiscal = value;
                if (value.Trim().ToUpper().Equals("BT"))
                    tipo_impnaofiscal = "BEMATECH";
                else tipo_impnaofiscal = string.Empty;
            }
        }
        private string tipo_impnaofiscal;
        public string Tipo_impnaofiscal
        {
            get { return tipo_impnaofiscal; }
            set
            {
                tipo_impnaofiscal = value;
                if (value.Trim().ToUpper().Equals("BEMATECH"))
                    tp_impnaofiscal = "BT";
                else tp_impnaofiscal = string.Empty;
            }
        }
        private string st_impvendaauto;
        public string St_impvendaauto
        {
            get { return st_impvendaauto; }
            set
            {
                st_impvendaauto = value;
                st_impvendaautobool = value.Trim().ToUpper().Equals("S");
            }
        }
        private bool st_impvendaautobool;
        public bool St_impvendaautobool
        {
            get { return st_impvendaautobool; }
            set
            {
                st_impvendaautobool = value;
                st_impvendaauto = value ? "S" : "N";
            }
        }
        public string ImpressoraPadrao
        { get; set; }
        public string CMD_Abrirgaveta
        { get; set; }
        private string st_dupresumida;
        public string St_dupresumida
        {
            get { return st_dupresumida; }
            set
            {
                st_dupresumida = value;
                st_dupresumidabool = value.Trim().ToUpper().Equals("S");
            }
        }
        private bool st_dupresumidabool;
        public bool St_dupresumidabool
        {
            get { return st_dupresumidabool; }
            set
            {
                st_dupresumidabool = value;
                st_dupresumida = value ? "S" : "N";
            }
        }
        public bool St_processar
        { get; set; }
        
        public TRegistro_PontoVenda()
        {
            this.id_pdv = null;
            this.id_pdvstr = string.Empty;
            this.Ds_pdv = string.Empty;
            this.Cd_terminal = string.Empty;
            this.Ds_terminal = string.Empty;
            this.Cd_empresa = string.Empty;
            this.Nm_empresa = string.Empty;
            this.St_registro = "A";
            this.st_vendacombustivel = "N";
            this.st_vendacombustivelbool = false;
            this.Vl_maxretcaixa = decimal.Zero;
            this.st_fixarvlretido = "N";
            this.st_fixarvlretidobool = false;
            this.st_gavetadinheiro = "N";
            this.st_gavetadinheirobool = false;
            this.tp_impnaofiscal = string.Empty;
            this.tipo_impnaofiscal = string.Empty;
            this.st_impvendaauto = "N";
            this.st_impvendaautobool = false;
            this.ImpressoraPadrao = string.Empty;
            this.CMD_Abrirgaveta = string.Empty;
            this.st_dupresumida = "N";
            this.st_dupresumidabool = false;
            this.St_processar = false;
            this.id_localimp = string.Empty;
            this.ds_localimp = string.Empty;
            this.porta_imp = string.Empty;
            this.tp_imp = string.Empty;
        }
    }

    public class TCD_PontoVenda : TDataQuery
    {
        public TCD_PontoVenda()
        { }

        public TCD_PontoVenda(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + vTop.ToString();

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("select " + strTop + " a.id_localimp, d.ds_localimp,d.porta_imp,d.tp_impressora, a.id_pdv, a.ds_pdv, a.st_gavetadinheiro, ");
                sql.AppendLine("a.cd_terminal, b.ds_terminal, a.st_registro, a.st_fixarvlretido, ");
                sql.AppendLine("a.cd_empresa, c.nm_empresa, a.CMD_AbrirGaveta, ");
                sql.AppendLine("a.vl_maxretcaixa, a.st_vendacombustivel, a.st_dupresumida, ");
                sql.AppendLine("a.tp_impnaofiscal, a.st_impvendaauto, a.impressorapadrao ");
            }
            else
                sql.AppendLine(" Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from TB_PDV_PontoVenda a ");
            sql.AppendLine("inner join TB_DIV_Terminal b ");
            sql.AppendLine("on a.CD_Terminal = b.CD_Terminal ");
            sql.AppendLine("inner join TB_DIV_Empresa c ");
            sql.AppendLine("on a.CD_Empresa = c.CD_Empresa ");
            sql.AppendLine("left join tb_res_localimp d on d.id_localimp = a.id_localimp");
            sql.AppendLine("where isnull(a.st_registro, 'A') <> 'C' ");

            string cond = " and ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
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

        public TList_PontoVenda Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            bool podeFecharBco = false;
            TList_PontoVenda lista = new TList_PontoVenda();
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_PontoVenda reg = new TRegistro_PontoVenda();
                    if (!(reader.IsDBNull(reader.GetOrdinal("Id_pdv"))))
                        reg.Id_pdv = reader.GetDecimal(reader.GetOrdinal("Id_pdv"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("ds_pdv"))))
                        reg.Ds_pdv = reader.GetString(reader.GetOrdinal("ds_pdv"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("cd_terminal"))))
                        reg.Cd_terminal = reader.GetString(reader.GetOrdinal("cd_terminal"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_terminal")))
                        reg.Ds_terminal = reader.GetString(reader.GetOrdinal("ds_terminal"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_empresa")))
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("nm_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_registro")))
                        reg.St_registro = reader.GetString(reader.GetOrdinal("st_registro"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_maxretcaixa")))
                        reg.Vl_maxretcaixa = reader.GetDecimal(reader.GetOrdinal("vl_maxretcaixa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_vendacombustivel")))
                        reg.St_vendacombustivel = reader.GetString(reader.GetOrdinal("st_vendacombustivel"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_fixarvlretido")))
                        reg.St_fixarvlretido = reader.GetString(reader.GetOrdinal("st_fixarvlretido"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_gavetadinheiro")))
                        reg.St_gavetadinheiro = reader.GetString(reader.GetOrdinal("st_gavetadinheiro"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_impnaofiscal")))
                        reg.Tp_impnaofiscal = reader.GetString(reader.GetOrdinal("tp_impnaofiscal"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_impvendaauto")))
                        reg.St_impvendaauto = reader.GetString(reader.GetOrdinal("st_impvendaauto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("impressorapadrao")))
                        reg.ImpressoraPadrao = reader.GetString(reader.GetOrdinal("impressorapadrao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cmd_abrirgaveta")))
                        reg.CMD_Abrirgaveta = reader.GetString(reader.GetOrdinal("cmd_abrirgaveta"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_dupresumida")))
                        reg.St_dupresumida = reader.GetString(reader.GetOrdinal("st_dupresumida"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_localimp")))
                        reg.id_localimp = reader.GetDecimal(reader.GetOrdinal("id_localimp")).ToString();
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_localimp")))
                        reg.ds_localimp = reader.GetString(reader.GetOrdinal("ds_localimp"));
                    if (!reader.IsDBNull(reader.GetOrdinal("porta_imp")))
                        reg.porta_imp = reader.GetString(reader.GetOrdinal("porta_imp")); 
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_impressora")))
                        reg.tp_imp = reader.GetString(reader.GetOrdinal("tp_impressora")); 


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

        public string Gravar(TRegistro_PontoVenda val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(15);
            hs.Add("@P_ID_PDV", val.Id_pdv);
            hs.Add("@P_DS_PDV", val.Ds_pdv);
            hs.Add("@P_CD_TERMINAL", val.Cd_terminal);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ST_REGISTRO", val.St_registro);
            hs.Add("@P_VL_MAXRETCAIXA", val.Vl_maxretcaixa);
            hs.Add("@P_ST_VENDACOMBUSTIVEL", val.St_vendacombustivel);
            hs.Add("@P_ST_FIXARVLRETIDO", val.St_fixarvlretido);
            hs.Add("@P_ST_GAVETADINHEIRO", val.St_gavetadinheiro);
            hs.Add("@P_TP_IMPNAOFISCAL", val.Tp_impnaofiscal);
            hs.Add("@P_ST_IMPVENDAAUTO", val.St_impvendaauto);
            hs.Add("@P_IMPRESSORAPADRAO", val.ImpressoraPadrao);
            hs.Add("@P_CMD_ABRIRGAVETA", val.CMD_Abrirgaveta);
            hs.Add("@P_ST_DUPRESUMIDA", val.St_dupresumida);
            hs.Add("@P_ID_LOCALIMP", val.id_localimp);

            return this.executarProc("IA_PDV_PONTOVENDA", hs);
        }

        public string Excluir(TRegistro_PontoVenda val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(1);
            hs.Add("@P_ID_PDV", val.Id_pdv);

            return this.executarProc("EXCLUI_PDV_PONTOVENDA", hs);
        }
    }
}