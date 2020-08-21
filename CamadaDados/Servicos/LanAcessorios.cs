using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;
using System.Data.SqlClient;

namespace CamadaDados.Servicos
{
    public class TList_Acessorios : List<TRegistro_Acessorios>
    { }

    
    public class TRegistro_Acessorios
    {
        
        public decimal? Id_os
        { get; set; }
        
        public string Cd_empresa
        { get; set; }
        
        public decimal? Id_acessorio
        { get; set; }
        
        public string Ds_acessorio
        { get; set; }
        private string st_devolvido;
        
        public string St_devolvido
        {
            get { return st_devolvido; }
            set
            {
                st_devolvido = value;
                st_devolvidobool = value.Trim().ToUpper().Equals("S");
            }
        }
        private bool st_devolvidobool;
        
        public bool St_devolvidobool
        {
            get { return st_devolvidobool; }
            set
            {
                st_devolvidobool = value;
                if (value)
                    st_devolvido = "S";
                else
                    st_devolvido = "N";
            }
        }

        public TRegistro_Acessorios()
        {
            this.Id_os = null;
            this.Cd_empresa = string.Empty;
            this.Id_acessorio = null;
            this.Ds_acessorio = string.Empty;
            this.st_devolvido = "N";
            this.st_devolvidobool = false;
        }
    }

    public class TCD_Acessorios : TDataQuery
    {
        public TCD_Acessorios()
        { }

        public TCD_Acessorios(BancoDados.TObjetoBanco banco)
        {
            this.Banco_Dados = banco;
        }

        public string SqlCodeBusca(TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            string strtop = string.Empty;
            if (vTop > 0)
                strtop = " top " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();
            if (vNM_Campo.Trim().Equals(string.Empty))
                sql.AppendLine("select " + strtop + " a.id_os, a.cd_empresa, a.id_acessorio, a.ds_acessorio, a.st_devolvido ");
            else
                sql.AppendLine("Select " + strtop + " " + vNM_Campo);

            sql.AppendLine("from tb_ose_acessorios a ");
            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.Append(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                    cond = " and ";
                }
            return sql.ToString();
        }

        public override System.Data.DataTable Buscar(TpBusca[] vBusca, short vTop)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, string.Empty), null);
        }

        public override System.Data.DataTable Buscar(TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo), null);
        }

        public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
        {
            return this.executarEscalar(this.SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }

        public TList_Acessorios Select(TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            TList_Acessorios lista = new TList_Acessorios();
            bool podeFecharBco = false;
            if (Banco_Dados == null)
            {
                this.CriarBanco_Dados(false);
                podeFecharBco = true;
            }
            SqlDataReader reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_Acessorios reg = new TRegistro_Acessorios();
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_OS")))
                        reg.Id_os = reader.GetDecimal(reader.GetOrdinal("ID_OS"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("CD_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Acessorio")))
                        reg.Id_acessorio = reader.GetDecimal(reader.GetOrdinal("ID_Acessorio"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Acessorio")))
                        reg.Ds_acessorio = reader.GetString(reader.GetOrdinal("DS_Acessorio"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ST_Devolvido")))
                        reg.St_devolvido = reader.GetString(reader.GetOrdinal("ST_Devolvido"));

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

        public string GravarAcessorios(TRegistro_Acessorios val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(55);
            hs.Add("@P_ID_OS", val.Id_os);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_ACESSORIO", val.Id_acessorio);
            hs.Add("@P_DS_ACESSORIO", val.Ds_acessorio);
            hs.Add("@P_ST_DEVOLVIDO", val.St_devolvido);

            return this.executarProc("IA_OSE_ACESSORIOS", hs);
        }

        public string DeletarAcessorios(TRegistro_Acessorios val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(3);
            hs.Add("@P_ID_OS", val.Id_os);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_ACESSORIO", val.Id_acessorio);

            return this.executarProc("EXCLUI_OSE_ACESSORIOS", hs);
        }
    }
}
