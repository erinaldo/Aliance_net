using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Utils;

namespace CamadaDados.Financeiro.Cadastros
{
    public class TList_CadReferenciaCliFor : List<TRegistro_CadReferenciaCliFor>
    { }
    
    public class TRegistro_CadReferenciaCliFor
    {
        private decimal? id_referencia;
        public decimal? Id_referencia
        {
            get { return id_referencia; }
            set
            {
                id_referencia = value;
                id_referenciastr = (value.HasValue ? value.Value.ToString() : string.Empty);
            }
        }
        private string id_referenciastr;
        public string Id_referenciastr
        {
            get { return id_referenciastr; }
            set
            {
                id_referenciastr = value;
                try
                {
                    id_referencia = Convert.ToDecimal(value);
                }
                catch
                { id_referencia = null; }
            }
        }
        public string Nm_referencia
        { get; set; }
        public string Cd_CliFor
        { get; set; }
        public string Fone
        { get; set; }
        private string tp_referencia;
        public string Tp_Referencia
        {
            get { return tp_referencia; }
            set
            {
                tp_referencia = value;
                if (value.Trim().ToUpper().Equals("P"))
                    tipo_referencia = "PESSOAL";
                else if (value.Trim().ToUpper().Equals("C"))
                    tipo_referencia = "COMERCIAL";
   
            }
        }
        private string tipo_referencia;
        public string Tipo_referencia
        {
            get { return tipo_referencia; }
            set
            {
                tipo_referencia = value;
                if (value.Trim().ToUpper().Equals("PESSOAL"))
                    tp_referencia = "P";
                else if (value.Trim().ToUpper().Equals("COMERCIAL"))
                    tp_referencia = "C";
            }
        }
        private string tp_parentesco;
        public string Tp_parentesco
        {
            get { return tp_parentesco; }
            set
            {
                tp_parentesco = value;
                if (value.Trim().ToUpper().Equals("PA"))
                    tipo_parentesco = "PAI";
                else if (value.Trim().ToUpper().Equals("MA"))
                    tipo_parentesco = "MÃE";
                else if (value.Trim().ToUpper().Equals("FL"))
                    tipo_parentesco = "FILHO/FILHA";
                else if (value.Trim().ToUpper().Equals("NT"))
                    tipo_parentesco = "NETO/NETA";
                else if (value.Trim().ToUpper().Equals("AV"))
                    tipo_parentesco = "AVÔ/AVÓ";
                else if (value.Trim().ToUpper().Equals("PR"))
                    tipo_parentesco = "PRIMO/PRIMA";
                else if (value.Trim().ToUpper().Equals("SB"))
                    tipo_parentesco = "SOBRINHO/SOBRINHA";
                else if (value.Trim().ToUpper().Equals("TI"))
                    tipo_parentesco = "TIO/TIA";
                else if (value.Trim().ToUpper().Equals("SG"))
                    tipo_parentesco = "SOGRO/SOGRA";
                else if (value.Trim().ToUpper().Equals("CH"))
                    tipo_parentesco = "CUNHADO/CUNHADA";
                else if (value.Trim().ToUpper().Equals("AM"))
                    tipo_parentesco = "AMIGO/AMIGA";
                else if (value.Trim().ToUpper().Equals("VZ"))
                    tipo_parentesco = "VIZINHO/VIZINHA";
                else if (value.Trim().ToUpper().Equals("OU"))
                    tipo_parentesco = "OUTROS";
            }
        }
        private string tipo_parentesco;
        public string Tipo_parentesco
        {
            get { return tipo_parentesco; }
            set
            {
                tipo_parentesco = value;
                if (value.Trim().ToUpper().Equals("PAI"))
                    tp_parentesco = "PA";
                else if (value.Trim().ToUpper().Equals("MÃE"))
                    tp_parentesco = "MA";
                else if (value.Trim().ToUpper().Equals("FILHO/FILHA"))
                    tp_parentesco = "FL";
                else if (value.Trim().ToUpper().Equals("NETO/NETA"))
                    tp_parentesco = "NT";
                else if (value.Trim().ToUpper().Equals("AVÔ/AVÓ"))
                    tp_parentesco = "AV";
                else if (value.Trim().ToUpper().Equals("PRIMO/PRIMA"))
                    tp_parentesco = "PR";
                else if (value.Trim().ToUpper().Equals("SOBRINHO/SOBRINHA"))
                    tp_parentesco = "SB";
                else if (value.Trim().ToUpper().Equals("TIO/TIA"))
                    tp_parentesco = "TI";
                else if (value.Trim().ToUpper().Equals("SOGRO/SOGRA"))
                    tp_parentesco = "SG";
                else if (value.Trim().ToUpper().Equals("CUNHADO/CUNHADA"))
                    tp_parentesco = "CH";
                else if (value.Trim().ToUpper().Equals("AMIGO/AMIGA"))
                    tp_parentesco = "AM";
                else if (value.Trim().ToUpper().Equals("VIZINHO/VIZINHA"))
                    tp_parentesco = "VZ";
                else if (value.Trim().ToUpper().Equals("OUTROS"))
                    tp_parentesco = "OU";
            }
        }

        public TRegistro_CadReferenciaCliFor()
        {
            this.id_referencia = null;
            this.id_referenciastr = string.Empty;
            this.Nm_referencia = string.Empty;
            this.Cd_CliFor = string.Empty;
            this.Fone = string.Empty;
            this.tp_referencia = string.Empty;
            this.tipo_referencia = string.Empty;
            this.tp_parentesco = string.Empty;
            this.tipo_parentesco = string.Empty;
        }
    }

    public class TCD_CadReferenciaCliFor : TDataQuery
    {
        public TCD_CadReferenciaCliFor()
        { }

        public TCD_CadReferenciaCliFor(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "  TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("select " + strTop + "  a.Id_Referencia, a.CD_Clifor, ");
                sql.AppendLine("a.TP_Referencia, a.NM_Referencia, a.Fone, a.TP_Parentesco ");
            }
            else
                sql.AppendLine(" Select " + strTop + "   " + vNM_Campo + " ");

            sql.AppendLine("from TB_FIN_Referencias_Clifor a ");

            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                    cond = " and ";
                }
            return sql.ToString();
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, ""), null);
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo), null);
        }

        public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
        {
            return this.ExecutarBuscaEscalar(this.SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }

        public TList_CadReferenciaCliFor Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            bool podeFecharBco = false;
            TList_CadReferenciaCliFor lista = new TList_CadReferenciaCliFor();
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            SqlDataReader reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo));
            try
            {

                while (reader.Read())
                {
                    TRegistro_CadReferenciaCliFor reg = new TRegistro_CadReferenciaCliFor();
                    if (!(reader.IsDBNull(reader.GetOrdinal("Id_referencia"))))
                        reg.Id_referencia = reader.GetDecimal(reader.GetOrdinal("Id_referencia"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("Cd_CliFor"))))
                        reg.Cd_CliFor = reader.GetString(reader.GetOrdinal("Cd_CliFor"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("Tp_Referencia"))))
                        reg.Tp_Referencia = reader.GetString(reader.GetOrdinal("Tp_Referencia"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("Nm_referencia"))))
                        reg.Nm_referencia = reader.GetString(reader.GetOrdinal("Nm_referencia"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("Fone"))))
                        reg.Fone = reader.GetString(reader.GetOrdinal("Fone"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("TP_Parentesco"))))
                        reg.Tp_parentesco = reader.GetString(reader.GetOrdinal("TP_Parentesco"));
                    lista.Add(reg);
                }
            }
            catch
            {
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

        public string Gravar(TRegistro_CadReferenciaCliFor val)
        {
            Hashtable hs = new Hashtable(6);
            hs.Add("@P_ID_REFERENCIA", val.Id_referencia);
            hs.Add("@P_CD_CLIFOR", val.Cd_CliFor);
            hs.Add("@P_TP_REFERENCIA", val.Tp_Referencia);
            hs.Add("@P_NM_REFERENCIA", val.Nm_referencia);
            hs.Add("@P_FONE", val.Fone);
            hs.Add("@P_TP_PARENTESCO", val.Tp_parentesco);

            return this.executarProc("IA_FIN_REFERENCIAS_CLIFOR", hs);
        }

        public string Excluir(TRegistro_CadReferenciaCliFor val)
        {
            Hashtable hs = new Hashtable(2);
            hs.Add("@P_ID_REFERENCIA", val.Id_referencia);
            hs.Add("@P_CD_CLIFOR", val.Cd_CliFor);

            return this.executarProc("EXCLUI_FIN_REFERENCIAS_CLIFOR", hs);
        }
    }
}
