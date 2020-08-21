using System;
using System.Collections.Generic;
using Utils;
using System.Text;
using System.Collections;
using System.Data.SqlClient;
using System.Data;
using CamadaDados.Fiscal;

namespace CamadaDados.Fiscal
{
    public class TList_CadMov_x_CMI : List<TRegistro_CadMov_x_CMI>
    {
    }

    
    public class TRegistro_CadMov_x_CMI
    {
        private decimal? _CD_Movimentacao;
        
        public decimal? CD_Movimentacao
        {
            get {
                if (_CD_Movimentacao == 0)
                    return null;
                else
                    return _CD_Movimentacao;
            }
            set { 
                _CD_Movimentacao = value;
                _CD_MovimentacaoString = (value.HasValue ? value.Value.ToString() : string.Empty);
            }
        }
        private string _CD_MovimentacaoString;
        
        public string CD_MovimentacaoString
        {
            get { return _CD_MovimentacaoString; }
            set { _CD_MovimentacaoString = value;
                try {
                    _CD_Movimentacao = Convert.ToDecimal(value);
                    }
                catch {
                    _CD_Movimentacao = null;  
                }
            }
        }
        
        public string ds_movimentacao { get; set; }

        private decimal? _CD_CMI;
        
        public decimal? CD_CMI
        {
            get
            {
                if (_CD_CMI == 0)
                    return null;
                else
                return _CD_CMI; 
            }
            set { 
                _CD_CMI = value;
                _CD_CMIString = (value.HasValue ? value.Value.ToString() : string.Empty);
            }
        }

        private string _CD_CMIString;
        
        public string CD_CMIString
        {
            get { return _CD_CMIString; }
            set {
                _CD_CMIString = value;
                try {
                    _CD_CMI = Convert.ToDecimal(value);
                }
                catch{
                    _CD_CMI = null;
                }
            }
        }
        
        public string ds_cmi { get; set; }
        
        public string st_registro { get; set; }
        
        public string Tp_MovCMI { get; set; }
        
        public string Tp_Mov_Movimentacao { get; set; }

        public TRegistro_CadMov_x_CMI()
        {
            this.CD_Movimentacao = decimal.Zero;
            this.ds_movimentacao = string.Empty;
            this.Tp_Mov_Movimentacao = string.Empty;
            this.CD_CMI = decimal.Zero;
            this.ds_cmi = string.Empty;
            this.Tp_MovCMI = string.Empty;
            this.st_registro = "A";
        }
    }
     

    public class TCD_CadMov_x_CMI : TDataQuery
    {
        private string SqlCodeBusca(TpBusca[] vBusca, Int16 vTop, string vNM_Campo)
        {
            string strTop = "";
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();

            if (vNM_Campo.Length == 0)
            {
                sql.AppendLine(" SELECT " + strTop + " a.CD_Movimentacao, b.DS_Movimentacao, b.TP_Movimento as tp_movMovimento,");
                sql.AppendLine("a.CD_CMI, c.DS_CMI, c.TP_Movimento as tp_movcmi, a.st_registro ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine(" From TB_FIS_Mov_X_CMI a ");
            sql.AppendLine(" inner join TB_FIS_Movimentacao b On (b.CD_Movimentacao = a.CD_Movimentacao) ");
            sql.AppendLine(" inner join TB_FIS_CMI c On (c.CD_CMI = a.CD_CMI) ");

            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.Append(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                    cond = " and ";
                }
            sql.Append("Order by a.CD_Movimentacao asc");
            return sql.ToString();
        }
        
        public TList_CadMov_x_CMI Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_CadMov_x_CMI lista = new TList_CadMov_x_CMI();
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
                    TRegistro_CadMov_x_CMI reg = new TRegistro_CadMov_x_CMI();
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_MOVIMENTACAO"))))
                        reg.CD_Movimentacao = reader.GetDecimal(reader.GetOrdinal("CD_MOVIMENTACAO"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("DS_MOVIMENTACAO"))))
                        reg.ds_movimentacao = reader.GetString(reader.GetOrdinal("DS_MOVIMENTACAO"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("tp_movMovimento"))))
                        reg.Tp_Mov_Movimentacao = reader.GetString(reader.GetOrdinal("tp_movMovimento"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_CMI"))))
                        reg.CD_CMI = reader.GetDecimal(reader.GetOrdinal("CD_CMI"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("DS_CMI"))))
                        reg.ds_cmi = reader.GetString(reader.GetOrdinal("DS_CMI"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("tp_movcmi"))))
                        reg.Tp_MovCMI = reader.GetString(reader.GetOrdinal("tp_movcmi"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("st_registro"))))
                        reg.st_registro = reader.GetString(reader.GetOrdinal("st_registro"));


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

        public override DataTable Buscar(TpBusca[] vBusca, Int16 vTop)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, ""), null);
        }

        public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
        {
            return ExecutarBuscaEscalar(SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }
        
        public string GravarMovCMI(TRegistro_CadMov_x_CMI val)
        {
            Hashtable hs = new Hashtable(3);
            hs.Add("@P_CD_MOVIMENTACAO", val.CD_Movimentacao);
            hs.Add("@P_CD_CMI", val.CD_CMI);
            hs.Add("@P_ST_REGISTRO", val.st_registro);
            return executarProc("IA_FIS_MOV_X_CMI", hs);

        }
        
        public string DeletarMovCMI(TRegistro_CadMov_x_CMI val)
        {
            Hashtable hs = new Hashtable(2);
            hs.Add("@P_CD_MOVIMENTACAO", val.CD_Movimentacao);
            hs.Add("@P_CD_CMI", val.CD_CMI);
            return executarProc("EXCLUI_FIS_MOV_X_CMI", hs);
        }

    }
}
