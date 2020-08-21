using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using System.Data.SqlClient;
using Utils;

namespace CamadaDados.Faturamento.NotaFiscal
{
    public class TList_RegLanFaturamento_CMI : List<TRegistro_LanFaturamento_CMI>
    { }
    
    public class TRegistro_LanFaturamento_CMI
    {
        public string Cd_empresa
        {
            get;
            set;
        }
        public decimal Nr_lanctofiscal
        {
            get;
            set;
        }
        public string St_mestra
        {
            get;
            set;
        }
        public bool St_mestrabool
        { get { return string.IsNullOrEmpty(St_mestra) ? false : St_mestra.Trim().ToUpper().Equals("S"); } }
        public string St_devolucao
        {
            get;
            set;
        }
        public bool St_devolucaobool
        { get { return string.IsNullOrEmpty(St_devolucao) ? false : St_devolucao.Trim().ToUpper().Equals("S"); } }
        public string St_complementar
        {
            get;
            set;
        }
        public bool St_complementarbool
        { get { return string.IsNullOrEmpty(St_complementar) ? false : St_complementar.Trim().ToUpper().Equals("S"); } }
        public string St_geraestoque
        {
            get;
            set;
        }
        public bool St_geraestoquebool
        { get { return string.IsNullOrEmpty(St_geraestoque) ? false : St_geraestoque.Trim().ToUpper().Equals("S"); } }
        public string St_simplesremessa
        {
            get;
            set;
        }
        public bool St_simplesremessabool
        { get { return string.IsNullOrEmpty(St_simplesremessa) ? false : St_simplesremessa.Trim().ToUpper().Equals("S"); } }
        public string St_compdevimposto
        { get; set; }
        public bool St_compdevimpostobool
        { get { return string.IsNullOrEmpty(St_compdevimposto) ? false : St_compdevimposto.Trim().ToUpper().Equals("S"); } }
        public string St_retorno
        { get; set; }
        public bool St_retornobool
        { get { return string.IsNullOrEmpty(St_retorno) ? false : St_retorno.Trim().ToUpper().Equals("S"); } }
        public string St_remessatransp
        { get; set; }
        public bool St_remessatranspbool
        { get { return St_remessatransp.Trim().ToUpper().Equals("S"); } }
        
        public TRegistro_LanFaturamento_CMI()
        {
            Cd_empresa = string.Empty;
            Nr_lanctofiscal = 0;
            St_mestra = string.Empty;
            St_devolucao = string.Empty;
            St_complementar = string.Empty;
            St_geraestoque = string.Empty;
            St_simplesremessa = string.Empty;
            St_compdevimposto = string.Empty;
            St_retorno = string.Empty;
            St_remessatransp = string.Empty;
        }
    }

    public class TCD_LanFaturamento_CMI : TDataQuery
    {
        public TCD_LanFaturamento_CMI()
        { }

        public TCD_LanFaturamento_CMI(BancoDados.TObjetoBanco banco)
        { Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("Select " + strTop + " a.CD_Empresa, a.NR_LanctoFiscal, ");
                sql.AppendLine("a.ST_Mestra, a.ST_Devolucao, a.ST_Complementar, ");
                sql.AppendLine("a.ST_GeraEstoque, a.ST_SimplesRemessa, ");
                sql.AppendLine("a.st_compdevimposto, a.ST_Retorno, a.ST_RemessaTransp ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("From TB_FAT_NotaFiscal_CMI a ");
            sql.AppendLine("inner join TB_FAT_NotaFiscal b ");
            sql.AppendLine("On b.CD_Empresa = a.CD_Empresa ");
            sql.AppendLine("and b.NR_LanctoFiscal = a.NR_LanctoFiscal ");

            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + ")");
                    cond = " and ";
                }
            return sql.ToString();
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, string.Empty), null);
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo), null);
        }

        public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
        {
            return ExecutarBuscaEscalar(SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }

        public TList_RegLanFaturamento_CMI Select(TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            SqlDataReader reader = null;
            TList_RegLanFaturamento_CMI lista = new TList_RegLanFaturamento_CMI();
            try
            {
                reader = ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo));
                while (reader.Read())
                {
                    TRegistro_LanFaturamento_CMI reg = new TRegistro_LanFaturamento_CMI();
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_Empresa"))))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("CD_Empresa"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("NR_LanctoFiscal"))))
                        reg.Nr_lanctofiscal = reader.GetDecimal(reader.GetOrdinal("NR_LanctoFiscal"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("ST_Mestra"))))
                        reg.St_mestra = reader.GetString(reader.GetOrdinal("ST_Mestra"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("ST_Devolucao"))))
                        reg.St_devolucao = reader.GetString(reader.GetOrdinal("ST_Devolucao"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("ST_Complementar"))))
                        reg.St_complementar = reader.GetString(reader.GetOrdinal("ST_Complementar"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("ST_GeraEstoque"))))
                        reg.St_geraestoque = reader.GetString(reader.GetOrdinal("ST_GeraEstoque"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("ST_SimplesRemessa"))))
                        reg.St_simplesremessa = reader.GetString(reader.GetOrdinal("ST_SimplesRemessa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ST_CompDevImposto")))
                        reg.St_compdevimposto = reader.GetString(reader.GetOrdinal("ST_CompDevImposto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ST_Retorno")))
                        reg.St_retorno = reader.GetString(reader.GetOrdinal("ST_Retorno"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ST_RemessaTransp")))
                        reg.St_remessatransp = reader.GetString(reader.GetOrdinal("ST_RemessaTransp"));

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

        public string Gravar(TRegistro_LanFaturamento_CMI val)
        {
            Hashtable hs = new Hashtable(10);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_NR_LANCTOFISCAL", val.Nr_lanctofiscal);
            hs.Add("@P_ST_MESTRA", val.St_mestra);
            hs.Add("@P_ST_DEVOLUCAO", val.St_devolucao);
            hs.Add("@P_ST_COMPLEMENTAR", val.St_complementar);
            hs.Add("@P_ST_GERAESTOQUE", val.St_geraestoque);
            hs.Add("@P_ST_SIMPLESREMESSA", val.St_simplesremessa);
            hs.Add("@P_ST_COMPDEVIMPOSTO", val.St_compdevimposto);
            hs.Add("@P_ST_RETORNO", val.St_retorno);
            hs.Add("@P_ST_REMESSATRANSP", val.St_remessatransp);

            return executarProc("IA_FAT_NOTAFISCAL_CMI", hs);
        }

        public string Excluir(TRegistro_LanFaturamento_CMI val)
        {
            Hashtable hs = new Hashtable(2);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_NR_LANCTOFISCAL", val.Nr_lanctofiscal);

            return executarProc("EXCLUI_FAT_NOTAFISCAL_CMI", hs);
        }
    }
}
