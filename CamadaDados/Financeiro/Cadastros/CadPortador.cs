using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Utils;
using System.Data.SqlClient;
using System.Collections;

namespace CamadaDados.Financeiro.Cadastros
{
    public class TList_CadPortador:List<TRegistro_CadPortador>, IComparer<TRegistro_CadPortador>
    {
        #region IComparer<TRegistro_CadPortador> Members
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

        public TList_CadPortador()
        { }

        public TList_CadPortador(System.ComponentModel.PropertyDescriptor Prop,
                                 System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_CadPortador value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_CadPortador x, TRegistro_CadPortador y)
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
    
    public class TRegistro_CadPortador
    {
        public string Cd_portador
        { get; set; }
        public string Ds_portador
        { get; set; }
        public decimal Qt_min_parc
        { get; set; }
        public decimal Qt_max_parc
        { get; set; }
        private string st_controletitulo;
        public string St_controletitulo
        {
            get { return st_controletitulo; }
            set
            {
                st_controletitulo = value;
                st_controletitulobool = value.Trim().ToUpper().Equals("S");
            }
        }
        private bool st_controletitulobool;
        public bool St_controletitulobool
        {
            get { return st_controletitulobool; }
            set
            {
                st_controletitulobool = value;
                if (value)
                    st_controletitulo = "S";
                else
                    st_controletitulo = "N";
            }
        }
        private string st_tituloterceiro;
        public string St_tituloterceiro
        {
            get { return st_tituloterceiro; }
            set
            {
                st_tituloterceiro = value;
                st_tituloterceirobool = value.Trim().ToUpper().Equals("S");
            }
        }
        private bool st_tituloterceirobool;
        public bool St_tituloterceirobool
        {
            get { return st_tituloterceirobool; }
            set
            {
                st_tituloterceirobool = value;
                if (value)
                    st_tituloterceiro = "S";
                else
                    st_tituloterceiro = "N";
            }
        }
        public string St_registro
        { get; set; }
        private string tp_portadorpdv;
        public string Tp_portadorpdv
        {
            get { return tp_portadorpdv; }
            set
            {
                tp_portadorpdv = value;
                if (value.Trim().ToUpper().Equals("A"))
                    tipo_portadorpdv = "A VISTA";
                else if (value.Trim().ToUpper().Equals("P"))
                    tipo_portadorpdv = "A PRAZO";
            }
        }
        private string tipo_portadorpdv;
        public string Tipo_portadorpdv
        {
            get { return tipo_portadorpdv; }
            set
            {
                tipo_portadorpdv = value;
                if (value.Trim().ToUpper().Equals("A VISTA"))
                    tp_portadorpdv = "A";
                else if (value.Trim().ToUpper().Equals("A PRAZO"))
                    tp_portadorpdv = "P";
            }
        }
        public decimal Vl_pagtoPDV
        { get; set; }
        public decimal Vl_trocoPDV
        { get; set; }
        public bool St_gerarCredito
        { get; set; }
        public decimal Vl_credTroco
        { get; set; }
        public string Ds_mensagemCredito
        { get; set; }
        private System.Drawing.Image icone_portador;
        public System.Drawing.Image Icone_portador
        {
            get { return icone_portador; }
            set
            {
                icone_portador = value;
                if (icone_portador != null)
                {
                    using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
                    {
                        icone_portador.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                        img = ms.ToArray();
                        ms.Close();
                        ms.Dispose();
                    }
                }
            }
        }
        private byte[] img;
        public byte[] Img
        {
            get{ return img; }
            set
            {
                img = value;
                if (value != null)
                {
                    using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
                    {
                        ms.Write(value, 0, value.Length);
                        icone_portador = System.Drawing.Image.FromStream(ms);
                        ms.Close();
                        ms.Dispose();
                    }
                }
            }
        }
        public decimal Ordem
        { get; set; }
        private string st_devcredito;
        public string St_devcredito
        {
            get { return st_devcredito; }
            set
            {
                st_devcredito = value;
                st_devcreditobool = value.Trim().ToUpper().Equals("S");
            }
        }
        private bool st_devcreditobool;
        public bool St_devcreditobool
        {
            get { return st_devcreditobool; }
            set
            {
                st_devcreditobool = value;
                st_devcredito = value ? "S" : "N";
            }
        }
        private string st_cartafrete;
        public string St_cartafrete
        {
            get { return st_cartafrete; }
            set
            {
                st_cartafrete = value;
                st_cartafretebool = value.Trim().ToUpper().Equals("S");
            }
        }
        private bool st_cartafretebool;
        public bool St_cartafretebool
        {
            get { return st_cartafretebool; }
            set
            {
                st_cartafretebool = value;
                st_cartafrete = value ? "S" : "N";
            }
        }
        private string st_entregafutura;
        public string St_entregafutura
        {
            get { return st_entregafutura; }
            set
            {
                st_entregafutura = value;
                st_entregafuturabool = value.Trim().ToUpper().Equals("S");
            }
        }
        private bool st_entregafuturabool;
        public bool St_entregafuturabool
        {
            get { return st_entregafuturabool; }
            set
            {
                st_entregafuturabool = value;
                st_entregafutura = value ? "S" : "N";
            }
        }
        private int st_cartaocredito;
        public int St_cartaocredito
        {
            get { return st_cartaocredito; }
            set
            {
                st_cartaocredito = value;
                st_cartaocreditobool = value.Equals(0);
            }
        }
        private bool st_cartaocreditobool;
        public bool St_cartaocreditobool
        {
            get { return st_cartaocreditobool; }
            set
            {
                st_cartaocreditobool = value;
                st_cartaocredito = value ? 0 : 1;
            }
        }
        public string Tp_cartao
        { get; set; }
        public decimal Pc_juro_fin
        { get; set; }
        public decimal Pc_txtroca
        { get; set; }
        public CamadaDados.Financeiro.Titulo.TList_RegLanTitulo lCheque
        { get; set; }
        public CamadaDados.Financeiro.Duplicata.TList_RegLanDuplicata lDup
        { get; set; }
        public CamadaDados.Financeiro.Cartao.TList_FaturaCartao lFatura
        { get; set; }
        public List<CamadaDados.Financeiro.Adiantamento.TRegistro_LanAdiantamento> lCred
        { get; set; }
        public CamadaDados.PostoCombustivel.TList_CartaFrete lCartaFrete
        { get; set; }
        public CamadaDados.Financeiro.Titulo.TList_RegLanTitulo lChTroco
        { get; set; }

        public TRegistro_CadPortador()
        {
            Cd_portador = string.Empty;
            Ds_portador = string.Empty;
            Qt_min_parc = decimal.Zero;
            Qt_max_parc = decimal.Zero;
            st_controletitulo = "N";
            st_controletitulobool = false;
            st_tituloterceiro = "N";
            st_tituloterceirobool = false;
            St_registro = "A";
            tp_portadorpdv = string.Empty;
            tipo_portadorpdv = string.Empty;
            Vl_pagtoPDV = decimal.Zero;
            Vl_trocoPDV = decimal.Zero;
            Vl_credTroco = decimal.Zero;
            St_gerarCredito = false;
            Ds_mensagemCredito = string.Empty;
            icone_portador = null;
            img = null;
            Ordem = decimal.Zero;
            st_devcredito = "N";
            st_devcreditobool = false;
            st_cartafrete = "N";
            st_cartafretebool = false;
            st_entregafutura = "N";
            st_entregafuturabool = false;
            st_cartaocredito = 1;
            st_cartaocreditobool = false;
            Tp_cartao = string.Empty;
            Pc_juro_fin = decimal.Zero;
            Pc_txtroca = decimal.Zero;
            lCheque = new CamadaDados.Financeiro.Titulo.TList_RegLanTitulo();
            lDup = new CamadaDados.Financeiro.Duplicata.TList_RegLanDuplicata();
            lFatura = new CamadaDados.Financeiro.Cartao.TList_FaturaCartao();
            lCred = new List<CamadaDados.Financeiro.Adiantamento.TRegistro_LanAdiantamento>();
            lCartaFrete = new CamadaDados.PostoCombustivel.TList_CartaFrete();
            lChTroco = new CamadaDados.Financeiro.Titulo.TList_RegLanTitulo();
        }
    }

    public class TCD_CadPortador : TDataQuery
    {
        public TCD_CadPortador()
        { }

        public TCD_CadPortador(BancoDados.TObjetoBanco banco)
        { Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, Int16 vTop, string vNM_Campo, string vOrder)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("select " + strTop + " cd_portador, ds_portador, a.ordem, a.st_entregafutura, ");
                sql.AppendLine("isnull(a.pc_juro_fin, 0) as pc_juro_fin, isnull(a.pc_txtroca, 0) as pc_txtroca, ");
                sql.AppendLine("tp_portadorpdv, qt_min_parc, qt_max_parc, a.st_cartafrete, isnull(a.st_cartaocredito, 1) as st_cartaocredito, ");
                sql.AppendLine("st_controletitulo, st_tituloterceiro, st_registro, icone_portador, a.st_devcredito ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from tb_fin_portador a ");
            sql.AppendLine("where isnull(st_registro, 'A') <> 'C' ");
            string cond = " and ";

            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + ")");
            if (!string.IsNullOrEmpty(vOrder))
                sql.AppendLine("order by " + vOrder);
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

        public TList_CadPortador Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo, string vOrder)
        {
            TList_CadPortador lista = new TList_CadPortador();
            SqlDataReader reader;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            reader = ExecutarBusca(SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo, vOrder));
            try
            {
                while (reader.Read())
                {
                    TRegistro_CadPortador reg = new TRegistro_CadPortador();
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_Portador"))))
                        reg.Cd_portador = reader.GetString(reader.GetOrdinal("CD_Portador"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("DS_Portador"))))
                        reg.Ds_portador = reader.GetString(reader.GetOrdinal("DS_Portador"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("QT_Min_Parc"))))
                        reg.Qt_min_parc = reader.GetDecimal(reader.GetOrdinal("QT_Min_Parc"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("QT_Max_Parc"))))
                        reg.Qt_max_parc = reader.GetDecimal(reader.GetOrdinal("QT_Max_Parc"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("ST_Controletitulo"))))
                        reg.St_controletitulo = reader.GetString(reader.GetOrdinal("ST_Controletitulo"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("ST_Tituloterceiro"))))
                        reg.St_tituloterceiro = reader.GetString(reader.GetOrdinal("ST_Tituloterceiro"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("ST_Registro"))))
                        reg.St_registro = reader.GetString(reader.GetOrdinal("ST_Registro"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_portadorpdv")))
                        reg.Tp_portadorpdv = reader.GetString(reader.GetOrdinal("tp_portadorpdv"));
                    if(!reader.IsDBNull(reader.GetOrdinal("icone_portador")))
                        reg.Img = (byte[])reader.GetValue(reader.GetOrdinal("icone_portador"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ordem")))
                        reg.Ordem = reader.GetDecimal(reader.GetOrdinal("ordem"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_devcredito")))
                        reg.St_devcredito = reader.GetString(reader.GetOrdinal("st_devcredito"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_cartafrete")))
                        reg.St_cartafrete = reader.GetString(reader.GetOrdinal("st_cartafrete"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_entregafutura")))
                        reg.St_entregafutura = reader.GetString(reader.GetOrdinal("st_entregafutura"));
                    if (!reader.IsDBNull(reader.GetOrdinal("pc_juro_fin")))
                        reg.Pc_juro_fin = reader.GetDecimal(reader.GetOrdinal("pc_juro_fin"));
                    if (!reader.IsDBNull(reader.GetOrdinal("pc_txtroca")))
                        reg.Pc_txtroca = reader.GetDecimal(reader.GetOrdinal("pc_txtroca"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_cartaocredito")))
                        reg.St_cartaocredito = Convert.ToInt16(reader.GetValue(reader.GetOrdinal("st_cartaocredito")));

                    lista.Add(reg);
                }
            }
            finally
            {
                reader.Close();
                reader.Dispose();
                if (podeFecharBco)
                    deletarBanco_Dados();
            }
            return lista;
        }

        public string Gravar(TRegistro_CadPortador val)
        {
            Hashtable hs = new Hashtable(16);
            hs.Add("@P_CD_PORTADOR", val.Cd_portador);
            hs.Add("@P_DS_PORTADOR", val.Ds_portador);
            hs.Add("@P_QT_MIN_PARC", val.Qt_min_parc);
            hs.Add("@P_QT_MAX_PARC", val.Qt_max_parc);
            hs.Add("@P_ST_TITULOTERCEIRO", val.St_tituloterceiro);
            hs.Add("@P_ST_CONTROLETITULO", val.St_controletitulo);
            hs.Add("@P_ST_REGISTRO", val.St_registro);
            hs.Add("@P_TP_PORTADORPDV", val.Tp_portadorpdv);
            hs.Add("@P_ICONE_PORTADOR", val.Img);
            hs.Add("@P_ORDEM", val.Ordem);
            hs.Add("@P_ST_DEVCREDITO", val.St_devcredito);
            hs.Add("@P_ST_CARTAFRETE", val.St_cartafrete);
            hs.Add("@P_ST_ENTREGAFUTURA", val.St_entregafutura);
            hs.Add("@P_ST_CARTAOCREDITO", val.St_cartaocredito);
            hs.Add("@P_PC_JURO_FIN", val.Pc_juro_fin);
            hs.Add("@P_PC_TXTROCA", val.Pc_txtroca);

            return executarProc("IA_FIN_PORTADOR", hs);
        }

        public string Excluir(TRegistro_CadPortador val)
        {
            Hashtable hs = new Hashtable(1);
            hs.Add("@P_CD_PORTADOR", val.Cd_portador);

            return executarProc("EXCLUI_FIN_PORTADOR", hs);
        }
    }
}