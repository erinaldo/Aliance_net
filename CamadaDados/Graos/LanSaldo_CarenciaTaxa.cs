using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using System.Collections;
using Utils;

namespace CamadaDados.Graos
{
    public class TList_SaldoCarenciaTaxa : List<TRegistro_SaldoCarenciaTaxa>
    {
    }

    public class TRegistro_SaldoCarenciaTaxa
    {
        public decimal Id_Taxa { get; set; }
        public decimal Id_Movto { get; set; }
        public decimal Id_saldo { get; set; }
        public decimal? Id_LanTaxa { get; set; }
        public DateTime DT_Saldo { get; set; }
        public decimal  QTD_Lancto { get; set; }
        public string   ST_Carencia { get; set; }

    }

    public class TRegistro_ViewSaldoCarencia
    { 
        public string CD_Empresa {get; set;}
        public decimal ID_Taxa {get; set;}
        public decimal NR_Contrato {get; set;}
        public string CD_Produto {get; set;}
        public DateTime DT_Saldo { get; set; }
        public decimal Tot_Saldo { get; set; }
    
    }


    public class TCD_SaldoCarenciaTaxa : TDataQuery
    {
        public TCD_SaldoCarenciaTaxa()
        { }

        public TCD_SaldoCarenciaTaxa(BancoDados.TObjetoBanco vBanco)
        {
            this.Banco_Dados = vBanco;
        }

        private string SqlCodeBusca(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();

            if (vNM_Campo.Length == 0)
            {
                sql.AppendLine(" SELECT " + strTop + " a.ID_LanTaxa, a.Id_Taxa, a.Id_Movto, a.DT_Saldo, a.QTD_Lancto, a.ST_Carencia, a.id_saldo ");                
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine(" FROM TB_GRO_SaldoCarenciaTaxa a ");

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
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, string.Empty), null);
        }

        public List<TRegistro_ViewSaldoCarencia> BuscarSaldoCarencia(string vCD_Empresa, 
                                                                     string vID_Taxa, 
                                                                     string vNR_Contrato, 
                                                                     string vCD_Produto)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("select CD_Empresa, ID_Taxa, Nr_Contrato, dt_saldo, cd_produto, Tot_Saldo");
            sql.AppendLine("from VTB_GRO_SaldoCarencia");
            sql.AppendLine("where CD_Empresa = '" + vCD_Empresa + "'");
            if (!string.IsNullOrEmpty(vID_Taxa))
                sql.AppendLine("  and ID_Taxa = " + vID_Taxa);
            if (!string.IsNullOrEmpty(vNR_Contrato))
                sql.AppendLine("  and Nr_Contrato = " + vNR_Contrato);
            if (vCD_Produto != "")
                sql.AppendLine(" and CD_Produto = '" + vCD_Produto + "'");

            sql.AppendLine(" Order by DT_Saldo ");
            
            bool podeFecharBco = false;
            if (Banco_Dados == null)
            {
                this.CriarBanco_Dados(false);
                podeFecharBco = true;
            }
            List<TRegistro_ViewSaldoCarencia> lista = new List<TRegistro_ViewSaldoCarencia>();
            SqlDataReader reader = this.ExecutarBusca(sql.ToString());
            try            
            {
                while (reader.Read())
                {
                    lista.Add(new TRegistro_ViewSaldoCarencia()
                    {
                        CD_Empresa = reader.GetString(reader.GetOrdinal("CD_Empresa")),
                        CD_Produto = reader.GetString(reader.GetOrdinal("CD_Produto")),
                        DT_Saldo = reader.GetDateTime(reader.GetOrdinal("DT_Saldo")),
                        ID_Taxa = reader.GetDecimal(reader.GetOrdinal("ID_Taxa")),
                        NR_Contrato = reader.GetDecimal(reader.GetOrdinal("NR_Contrato")),
                        Tot_Saldo = reader.GetDecimal(reader.GetOrdinal("TOT_SALDO"))
                    });
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

        public TList_SaldoCarenciaTaxa Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_SaldoCarenciaTaxa lista = new TList_SaldoCarenciaTaxa();
            SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
            {
                this.CriarBanco_Dados(false);
                podeFecharBco = true;
            }

            try
            {
                reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
                while (reader.Read())
                {
                    TRegistro_SaldoCarenciaTaxa reg = new TRegistro_SaldoCarenciaTaxa();
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Saldo")))
                        reg.Id_saldo = reader.GetDecimal(reader.GetOrdinal("ID_Saldo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Id_Taxa")))
                        reg.Id_Taxa = reader.GetDecimal(reader.GetOrdinal("Id_Taxa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Id_LanTaxa")))
                        reg.Id_LanTaxa = reader.GetDecimal(reader.GetOrdinal("Id_LanTaxa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Movto")))
                        reg.Id_Movto = reader.GetDecimal(reader.GetOrdinal("ID_Movto"));                    
                    if (!reader.IsDBNull(reader.GetOrdinal("DT_Saldo")))
                        reg.DT_Saldo = reader.GetDateTime(reader.GetOrdinal("DT_Saldo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ST_Carencia")))
                        reg.ST_Carencia = reader.GetString(reader.GetOrdinal("ST_Carencia"));

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

        public string Grava(TRegistro_SaldoCarenciaTaxa vRegistro)
        {
            Hashtable hs = new Hashtable(5);
            hs.Add("@P_ID_SALDO", vRegistro.Id_saldo);
            hs.Add("@P_ID_TAXA", vRegistro.Id_Taxa); 
            hs.Add("@P_ID_LANTAXA", vRegistro.Id_LanTaxa);
            hs.Add("@P_ID_MOVTO", vRegistro.Id_Movto);
            hs.Add("@P_DT_SALDO", vRegistro.DT_Saldo);
            hs.Add("@P_QTD_LANCTO", vRegistro.QTD_Lancto);
            hs.Add("@P_ST_CARENCIA", vRegistro.ST_Carencia);

            return this.executarProc("IA_GRO_SALDOCARENCIATAXA", hs);
        }

        public string Deleta(TRegistro_SaldoCarenciaTaxa vRegistro)
        {
            Hashtable hs = new Hashtable(3);
            hs.Add("@P_ID_TAXA", vRegistro.Id_Taxa);
            hs.Add("@P_ID_MOVTO", vRegistro.Id_Movto);
            hs.Add("@P_ID_SALDO", vRegistro.Id_saldo);

            return this.executarProc("EXCLUI_GRO_SALDOCARENCIATAXA", hs);
        }
    }



}
