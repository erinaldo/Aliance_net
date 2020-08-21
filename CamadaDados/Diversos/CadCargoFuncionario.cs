using System;
using System.Collections.Generic;
using System.Text;

namespace CamadaDados.Diversos
{
    public class TList_CargoFuncionario : List<TRegistro_CargoFuncionario>
    { }
    public class TRegistro_CargoFuncionario
    {
        private decimal? id_cargo;
        
        public decimal? Id_cargo
        {
            get { return id_cargo; }
            set
            {
                id_cargo = value;
                id_cargostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_cargostr;
        public string Id_cargostr
        {
            get { return id_cargostr; }
            set
            {
                id_cargostr = value;
                try
                {
                    id_cargo = Convert.ToDecimal(value);
                }
                catch
                { id_cargo = null; }
            }
        }
        
        public string Ds_cargo
        { get; set; }
        public decimal vl_basesalario { get; set; }
        public decimal CargahorarioMes { get; set; }
        private string st_vendedor;
        
        public string St_vendedor
        {
            get { return st_vendedor; }
            set
            {
                st_vendedor = value;
                st_vendedorbool = value.Trim().ToUpper().Equals("S");
            }
        }
        private bool st_vendedorbool;
        
        public bool St_vendedorbool
        {
            get { return st_vendedorbool; }
            set
            {
                st_vendedorbool = value;
                st_vendedor = value ? "S" : "N";
            }
        }
        private string st_tecnico;
        
        public string St_tecnico
        {
            get { return st_tecnico; }
            set
            {
                st_tecnico = value;
                st_tecnicobool = value.Trim().ToUpper().Equals("S");
            }
        }
        private bool st_tecnicobool;
        
        public bool St_tecnicobool
        {
            get { return st_tecnicobool; }
            set
            {
                st_tecnicobool = value;
                st_tecnico = value ? "S" : "N";
            }
        }
        private string st_motorista;
        
        public string St_motorista
        {
            get { return st_motorista; }
            set
            {
                st_motorista = value;
                st_motoristabool = value.Trim().ToUpper().Equals("S");
            }
        }
        private bool st_motoristabool;
        
        public bool St_motoristabool
        {
            get { return st_motoristabool; }
            set
            {
                st_motoristabool = value;
                st_motorista = value ? "S" : "N";
            }
        }
        private string st_frentista;
        
        public string St_frentista
        {
            get { return st_frentista; }
            set
            {
                st_frentista = value;
                st_frentistabool = value.Trim().ToUpper().Equals("S");
            }
        }
        private bool st_frentistabool;
        
        public bool St_frentistabool
        {
            get { return st_frentistabool; }
            set
            {
                st_frentistabool = value;
                st_frentista = value ? "S" : "N";
            }
        }
        private string st_operadorcx;
        public string St_operadorcx
        {
            get { return st_operadorcx; }
            set
            {
                st_operadorcx = value;
                st_operadorcxbool = value.Trim().ToUpper().Equals("S");
            }
        }
        private bool st_operadorcxbool;
        public bool St_operadorcxbool
        {
            get { return st_operadorcxbool; }
            set
            {
                st_operadorcxbool = value;
                st_operadorcx = value ? "S" : "N";
            }
        }
        private string st_gervenda;
        public string St_gervenda
        {
            get { return st_gervenda; }
            set
            {
                st_gervenda = value;
                st_gervendabool = value.Trim().ToUpper().Equals("S");
            }
        }
        private bool st_gervendabool;
        public bool St_gervendabool
        {
            get { return st_gervendabool; }
            set
            {
                st_gervendabool = value;
                st_gervenda = value ? "S" : "N";
            }
        }

        public TRegistro_CargoFuncionario()
        {
            id_cargo = null;
            id_cargostr = string.Empty;
            Ds_cargo = string.Empty;
            st_vendedor = "N";
            st_vendedorbool = false;
            st_tecnico = "N";
            st_tecnicobool = false;
            st_motorista = "N";
            st_motoristabool = false;
            st_frentista = "N";
            st_frentistabool = false;
            st_operadorcx = "N";
            st_operadorcxbool = false;
            st_gervenda = "N";
            st_gervendabool = false;
            vl_basesalario = decimal.Zero;
            CargahorarioMes = decimal.Zero;
        }
    }

    public class TCD_CargoFuncionario : TDataQuery
    {
        public TCD_CargoFuncionario()
        { }

        public TCD_CargoFuncionario(BancoDados.TObjetoBanco banco)
        { Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();

            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine(" SELECT " + strTop + " a.id_cargo, a.ds_cargo, ");
                sql.AppendLine("a.st_vendedor, a.st_tecnico, a.st_motorista, ");
                sql.AppendLine("a.st_frentista, a.vl_basesalario, a.CargaHorariaMes, ");
                sql.AppendLine("a.ST_OperadorCX , a.ST_GerVenda ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine(" FROM TB_DIV_CargoFuncionario a ");

            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.Append(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                    cond = " and ";
                }
            return sql.ToString();
        }

        public override System.Data.DataTable Buscar(Utils.TpBusca[] vBusca, short vTop)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, string.Empty), null);
        }

        public override System.Data.DataTable Buscar(Utils.TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo), null);
        }

        public override object BuscarEscalar(Utils.TpBusca[] vBusca, string vNM_Campo)
        {
            return ExecutarBuscaEscalar(SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }

        public TList_CargoFuncionario Select(Utils.TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            TList_CargoFuncionario lista = new TList_CargoFuncionario();
            System.Data.SqlClient.SqlDataReader reader = null;
            bool podeFecharBco = false;

            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);

            try
            {
                reader = ExecutarBusca(SqlCodeBusca(vBusca, Convert.ToInt16(vTop), string.Empty));
                while (reader.Read())
                {
                    TRegistro_CargoFuncionario reg = new TRegistro_CargoFuncionario();
                    if (!reader.IsDBNull(reader.GetOrdinal("id_cargo")))
                        reg.Id_cargo = reader.GetDecimal(reader.GetOrdinal("id_cargo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_cargo")))
                        reg.Ds_cargo = reader.GetString(reader.GetOrdinal("ds_cargo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_vendedor")))
                        reg.St_vendedor = reader.GetString(reader.GetOrdinal("st_vendedor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_tecnico")))
                        reg.St_tecnico = reader.GetString(reader.GetOrdinal("st_tecnico"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_motorista")))
                        reg.St_motorista = reader.GetString(reader.GetOrdinal("st_motorista"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_frentista")))
                        reg.St_frentista = reader.GetString(reader.GetOrdinal("st_frentista"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ST_OperadorCX")))
                        reg.St_operadorcx = reader.GetString(reader.GetOrdinal("ST_OperadorCX"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ST_GerVenda")))
                        reg.St_gervenda = reader.GetString(reader.GetOrdinal("ST_GerVenda"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_basesalario")))
                        reg.vl_basesalario = reader.GetDecimal(reader.GetOrdinal("vl_basesalario"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CargaHorariaMes")))
                        reg.CargahorarioMes = reader.GetDecimal(reader.GetOrdinal("CargaHorariaMes")); 

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

        public string Gravar(TRegistro_CargoFuncionario val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(10);
            hs.Add("@P_ID_CARGO", val.Id_cargo);
            hs.Add("@P_DS_CARGO", val.Ds_cargo);
            hs.Add("@P_ST_VENDEDOR", val.St_vendedor);
            hs.Add("@P_ST_TECNICO", val.St_tecnico);
            hs.Add("@P_ST_MOTORISTA", val.St_motorista);
            hs.Add("@P_ST_FRENTISTA", val.St_frentista);
            hs.Add("@P_ST_OPERADORCX", val.St_operadorcx);
            hs.Add("@P_ST_GERVENDA", val.St_gervenda);
            hs.Add("@P_VL_BASESALARIO", val.vl_basesalario);
            hs.Add("@P_CARGAHORARIAMES", val.CargahorarioMes);

            return executarProc("IA_DIV_CARGOFUNCIONARIO", hs);
        }

        public string Excluir(TRegistro_CargoFuncionario val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(1);
            hs.Add("@P_ID_CARGO", val.Id_cargo);

            return executarProc("EXCLUI_DIV_CARGOFUNCIONARIO", hs);
        }
    }
}
