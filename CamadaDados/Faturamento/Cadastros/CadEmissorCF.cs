using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamadaDados.Faturamento.Cadastros
{
    public class TList_EmissorCF : List<TRegistro_EmissorCF>, IComparer<TRegistro_EmissorCF>
    {
        #region IComparer<TRegistro_EmissorCF> Members
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

        public TList_EmissorCF()
        { }

        public TList_EmissorCF(System.ComponentModel.PropertyDescriptor Prop,
                               System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_EmissorCF value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_EmissorCF x, TRegistro_EmissorCF y)
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
    
    public class TRegistro_EmissorCF
    {
        private decimal? id_equipamento;
        public decimal? Id_equipamento
        {
            get { return id_equipamento; }
            set
            {
                id_equipamento = value;
                id_equipamentostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_equipamentostr;
        public string Id_equipamentostr
        {
            get { return id_equipamentostr; }
            set
            {
                id_equipamentostr = value;
                try
                {
                    id_equipamento = decimal.Parse(value);
                }
                catch
                { id_equipamento = null; }
            }
        }
        public string Ds_equipamento
        { get; set; }
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
                    id_pdv = decimal.Parse(value);
                }
                catch
                { id_pdv = null; }
            }
        }
        public string Ds_pdv
        { get; set; }
        public string Nr_serie
        { get; set; }
        private string tp_marca;
        public string Tp_marca
        {
            get { return tp_marca; }
            set
            {
                tp_marca = value;
                if (value.Trim().ToUpper().Equals("BT"))
                    tipo_marca = "BEMATECH";
                else if (value.Trim().ToUpper().Equals("DR"))
                    tipo_marca = "DARUMA";
                else if (value.Trim().ToUpper().Equals("SW"))
                    tipo_marca = "SWEDA";
                else if (value.Trim().ToUpper().Equals("EG"))
                    tipo_marca = "ELGIN";
            }
        }
        private string tipo_marca;
        public string Tipo_marca
        {
            get { return tipo_marca; }
            set
            {
                tipo_marca = value;
                if (value.Trim().ToUpper().Equals("BEMATECH"))
                    tp_marca = "BT";
                else if (value.Trim().ToUpper().Equals("DARUMA"))
                    tp_marca = "DR";
                else if (value.Trim().ToUpper().Equals("SWEDA"))
                    tp_marca = "SW";
                else if (value.Trim().ToUpper().Equals("ELGIN"))
                    tp_marca = "EG";
            }
        }
        public string Ds_modelo
        { get; set; }
        public decimal PortaImp
        { get; set; }
        public string Porta_impressao
        {
            get
            {
                if (PortaImp > 0)
                    return "COM" + PortaImp.ToString();
                else return string.Empty;
            }
        }
        private string st_portausb;
        public string St_portausb
        {
            get { return st_portausb; }
            set
            {
                st_portausb = value;
                st_portausbbool = value.Trim().ToUpper().Equals("S");
            }
        }
        private bool st_portausbbool;
        public bool St_portausbbool
        {
            get { return st_portausbbool; }
            set
            {
                st_portausbbool = value;
                st_portausb = value ? "S" : "N";
            }
        }
        private string st_default;
        public string St_default
        {
            get { return st_default; }
            set
            {
                st_default = value;
                st_defaultbool = value.Trim().ToUpper().Equals("S");
            }
        }
        private bool st_defaultbool;
        public bool St_defaultbool
        {
            get { return st_defaultbool; }
            set
            {
                st_defaultbool = value;
                st_default = value ? "S" : "N";
            }
        }
        private string st_truncar;
        public string St_truncar
        {
            get { return st_truncar; }
            set
            {
                st_truncar = value;
                st_truncarbool = value.Trim().ToUpper().Equals("S");
            }
        }
        private bool st_truncarbool;
        public bool St_truncarbool
        {
            get { return st_truncarbool; }
            set
            {
                st_truncarbool = value;
                st_truncar = value ? "S" : "N";
            }
        }
        private string tp_confdivida;
        public string Tp_confdivida
        {
            get { return tp_confdivida; }
            set
            {
                tp_confdivida = value;
                if (value.Trim().ToUpper().Equals("DV"))
                    tipo_confdivida = "DOCUMENTO VINCULADO";
                else if (value.Trim().ToUpper().Equals("RG"))
                    tipo_confdivida = "RELATORIO GERENCIAL";
            }
        }
        private string tipo_confdivida;
        public string Tipo_confdivida
        {
            get { return tipo_confdivida; }
            set
            {
                tipo_confdivida = value;
                if (value.Trim().ToUpper().Equals("DOCUMENTO VINCULADO"))
                    tp_confdivida = "DV";
                else if (value.Trim().ToUpper().Equals("RELATORIO GERENCIAl"))
                    tp_confdivida = "RG";
            }
        }
        private string st_calccooinifin;
        public string St_calccooinifin
        {
            get { return st_calccooinifin; }
            set
            {
                st_calccooinifin = value;
                st_calccooinifinbool = value.Trim().ToUpper().Equals("S");
            }
        }
        private bool st_calccooinifinbool;
        public bool St_calccooinifinbool
        {
            get { return st_calccooinifinbool; }
            set
            {
                st_calccooinifinbool = value;
                st_calccooinifin = value ? "S" : "N";
            }
        }
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

        public TRegistro_EmissorCF()
        {
            this.id_equipamento = null;
            this.id_equipamentostr = string.Empty;
            this.Ds_equipamento = string.Empty;
            this.id_pdv = null;
            this.id_pdvstr = string.Empty;
            this.Ds_pdv = string.Empty;
            this.Nr_serie = string.Empty;
            this.tp_marca = string.Empty;
            this.tipo_marca = string.Empty;
            this.Ds_modelo = string.Empty;
            this.PortaImp = 1;
            this.st_default = "N";
            this.st_defaultbool = false;
            this.st_portausb = "N";
            this.st_portausbbool = false;
            this.st_truncar = "N";
            this.st_truncarbool = false;
            this.tp_confdivida = string.Empty;
            this.tipo_confdivida = string.Empty;
            this.st_calccooinifin = "N";
            this.st_calccooinifinbool = false;
            this.St_registro = "A";
        }
    }

    public class TCD_EmissorCF : TDataQuery
    {
        public TCD_EmissorCF()
        { }

        public TCD_EmissorCF(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + vTop.ToString();

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("select " + strTop + " a.id_equipamento, a.st_truncar, ");
                sql.AppendLine("a.ds_equipamento, a.nr_serie, a.tp_marca, ");
                sql.AppendLine("a.portaimp, a.ds_modelo, a.st_registro, ");
                sql.AppendLine("a.id_pdv, c.ds_pdv, a.st_default, ");
                sql.AppendLine("a.st_portausb, a.tp_confdivida, a.st_calccooinifin ");
            }
            else
                sql.AppendLine(" Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from TB_PDV_EmissorCF a ");
            sql.AppendLine("inner join TB_PDV_PontoVenda c ");
            sql.AppendLine("on a.id_pdv = c.id_pdv ");

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

        public TList_EmissorCF Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            bool podeFecharBco = false;
            TList_EmissorCF lista = new TList_EmissorCF();
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_EmissorCF reg = new TRegistro_EmissorCF();
                    if (!(reader.IsDBNull(reader.GetOrdinal("id_equipamento"))))
                        reg.Id_equipamento = reader.GetDecimal(reader.GetOrdinal("id_equipamento"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("ds_equipamento"))))
                        reg.Ds_equipamento = reader.GetString(reader.GetOrdinal("ds_equipamento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_pdv")))
                        reg.Id_pdv = reader.GetDecimal(reader.GetOrdinal("id_pdv"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_pdv")))
                        reg.Ds_pdv = reader.GetString(reader.GetOrdinal("ds_pdv"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("nr_serie"))))
                        reg.Nr_serie = reader.GetString(reader.GetOrdinal("nr_serie"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_marca")))
                        reg.Tp_marca = reader.GetString(reader.GetOrdinal("tp_marca"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_modelo")))
                        reg.Ds_modelo = reader.GetString(reader.GetOrdinal("ds_modelo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("portaimp")))
                        reg.PortaImp = reader.GetDecimal(reader.GetOrdinal("portaimp"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_default")))
                        reg.St_default = reader.GetString(reader.GetOrdinal("st_default"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_portausb")))
                        reg.St_portausb = reader.GetString(reader.GetOrdinal("st_portausb"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_truncar")))
                        reg.St_truncar = reader.GetString(reader.GetOrdinal("st_truncar"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_confdivida")))
                        reg.Tp_confdivida = reader.GetString(reader.GetOrdinal("tp_confdivida"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_calccooinifin")))
                        reg.St_calccooinifin = reader.GetString(reader.GetOrdinal("st_calccooinifin"));
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

        public string Gravar(TRegistro_EmissorCF val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(13);
            hs.Add("@P_ID_EQUIPAMENTO", val.Id_equipamento);
            hs.Add("@P_DS_EQUIPAMENTO", val.Ds_equipamento);
            hs.Add("@P_ID_PDV", val.Id_pdv);
            hs.Add("@P_NR_SERIE", val.Nr_serie);
            hs.Add("@P_TP_MARCA", val.Tp_marca);
            hs.Add("@P_DS_MODELO", val.Ds_modelo);
            hs.Add("@P_PORTAIMP", val.PortaImp);
            hs.Add("@P_ST_DEFAULT", val.St_default);
            hs.Add("@P_ST_PORTAUSB", val.St_portausb);
            hs.Add("@P_ST_TRUNCAR", val.St_truncar);
            hs.Add("@P_TP_CONFDIVIDA", val.Tp_confdivida);
            hs.Add("@P_ST_CALCCOOINIFIN", val.St_calccooinifin);
            hs.Add("@P_ST_REGISTRO", val.St_registro);

            return this.executarProc("IA_PDV_EMISSORCF", hs);
        }

        public string Excluir(TRegistro_EmissorCF val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(1);
            hs.Add("@P_ID_EQUIPAMENTO", val.Id_equipamento);

            return this.executarProc("EXCLUI_PDV_EMISSORCF", hs);
        }
    }
}
