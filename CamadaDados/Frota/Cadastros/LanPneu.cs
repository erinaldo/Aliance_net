using System;
using System.Collections.Generic;
using System.Text;

namespace CamadaDados.Frota.Cadastros
{
    public class TList_LanPneu : List<TRegistro_LanPneu>, IComparer<TRegistro_LanPneu>
    {
        #region IComparer<TRegistro_LanPneu> Members
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

        public TList_LanPneu()
        { }

        public TList_LanPneu(System.ComponentModel.PropertyDescriptor Prop,
                                System.Windows.Forms.SortOrder Dir)
        {
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_LanPneu value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_LanPneu x, TRegistro_LanPneu y)
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

    public class TRegistro_LanPneu
    {
        public string Cd_empresa { get; set; } = string.Empty;
        public string Nm_empresa { get; set; } = string.Empty;

        private decimal? id_pneu = null;
        public decimal? Id_pneu
        {
            get { return id_pneu; }
            set
            {
                id_pneu = value;
                id_pneustr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_pneustr = string.Empty;
        public string Id_pneustr
        {
            get { return id_pneustr; }
            set
            {
                id_pneustr = value;
                try
                {
                    id_pneu = Convert.ToDecimal(value);
                }
                catch
                { id_pneu = null; }
            }
        }

        private decimal? id_almox = null;
        public decimal? Id_almox
        {
            get { return id_almox; }
            set
            {
                id_almox = value;
                id_almoxstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_almoxstr = string.Empty;
        public string Id_almoxstr
        {
            get { return id_almoxstr; }
            set
            {
                id_almoxstr = value;
                try
                {
                    id_almox = Convert.ToDecimal(value); 
                }
                catch
                {
                    id_almox = null;
                }
            }
        }

        public string Cd_produto { get; set; } = string.Empty;
        public string Ds_produto { get; set; } = string.Empty;
        public string Nr_serie { get; set; } = string.Empty;
        public string DS_Observacao { get; set; } = string.Empty;
        public string MotivoDesativacao { get; set; } = string.Empty;
        public int HodometroDesativacao { get; set; } = 0;
        public decimal Valor_OS { get; set; } = 0;

        private Int32? id_desenho = null;
        public Int32? Id_desenho
        {
            get
            { return id_desenho; }
            set
            {
                id_desenho = value;
                id_desenhostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_desenhostr = string.Empty;
        public string Id_desenhostr
        {
            get { return id_desenhostr; }
            set
            {
                id_desenhostr = value;
                try
                {
                    id_desenho = Convert.ToInt32(value);
                }
                catch
                { id_desenho = null; }
            }
        }
        public string Ds_desenho { get; set; } = string.Empty;

        private string tp_estado;
        public string Tp_estado
        {
            get { return tp_estado; }
            set
            {
                tp_estado = value;
                if (value.Trim().Equals("0"))
                    tipo_estado = "NOVO";
                else if (value.Trim().Equals("1"))
                    tipo_estado = "USADO";
                else if (value.Trim().Equals("2"))
                    tipo_estado = "RECAPADO NOVO";
                else if (value.Trim().Equals("3"))
                    tipo_estado = "RECAPADO USADO";
            }
        }
        private string tipo_estado;
        public string Tipo_estado
        {
            get { return tipo_estado; }
            set
            {
                tipo_estado = value;
                if (value.Trim().ToUpper().Equals("NOVO"))
                    tp_estado = "0";
                else if (value.Trim().ToUpper().Equals("USADO"))
                    tp_estado = "1";
                else if (value.Trim().ToUpper().Equals("RECAPADO NOVO"))
                    tp_estado = "2";
                else if (value.Trim().ToUpper().Equals("RECAPADO USADO"))
                    tp_estado = "3";
            }
        }

        private string st_pneunovo;
        public string St_pneunovo
        {
            get { return st_pneunovo; }
            set
            {
                st_pneunovo = value;
                st_pneunovobool = value.Trim().ToUpper().Equals("S");
            }
        }
        private bool st_pneunovobool;
        public bool St_pneunovobool
        {
            get { return st_pneunovobool; }
            set
            {
                st_pneunovobool = value;
                st_pneunovo = value ? "S" : "N";
            }
        }
        public string St_registro { get; set; } = "A";
        public string Status
        {
            get
            {
                if (St_registro.Trim().ToUpper().Equals("A"))
                    return "ALMOXARIFADO";
                else if (St_registro.Trim().ToUpper().Equals("R"))
                    return "RODANDO";
                else if (St_registro.Trim().ToUpper().Equals("M"))
                    return "MANUTENÇÃO";
                else if (St_registro.Trim().ToUpper().Equals("D"))
                    return "DESATIVADO";
                else return string.Empty;
            }
        }
        public string Id_veiculo { get; set; } = string.Empty;
        public string Ds_veiculo { get; set; } = string.Empty;
        public string Placa { get; set; } = string.Empty;
        public string Id_rodado { get; set; } = string.Empty;
        public string Ds_rodado { get; set; } = string.Empty;
        public int HodometroInicial { get; set; } = 0;
        public bool St_processar { get; set; } = false;

        public bool GerarAlmoxarifado { get; set; } = false;
        public decimal CustoPneuAlmoxarifado { get; set; } = 0;

        public decimal MediaDesgastePneu
        {
            get { return calculoDesgastePneu(); }
        }

        public TRegistro_MovPneu rMovPneu = null;

        public TList_MovPneu lMovPneu
        { get; set; } = new TList_MovPneu();

        public TRegistro_LanPneu()
        { }

        private decimal calculoDesgastePneu()
        {
            return 0;
        }
    }

    public class TCD_LanPneu : TDataQuery
    {
        public TCD_LanPneu()
        { }

        public TCD_LanPneu(BancoDados.TObjetoBanco banco)
        { Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("select " + strTop + " a.cd_empresa, emp.nm_empresa, a.ID_pneu, a.MotivoDesativacao, a.HodometroDesativacao, a.Tp_estado, ");
                sql.AppendLine("a.Cd_produto, b.Ds_produto, a.nr_serie, a.DS_Observacao, a.ST_Registro, a.St_PneuNovo, a.valor_OS, a.id_desenho, c.ds_desenho, a.id_almox, ");
                sql.AppendLine("ISNULL(dbo.[F_SPLIT](a.DadosMov, ';', 1), '') as Ds_veiculo, ");
                sql.AppendLine("ISNULL(dbo.[F_SPLIT](a.DadosMov, ';', 2), '') as Placa, ");
                sql.AppendLine("ISNULL(dbo.[F_SPLIT](a.DadosMov, ';', 3), '') as Ds_rodado, ");
                sql.AppendLine("ISNULL(dbo.[F_SPLIT](a.DadosMov, ';', 4), '') as Id_rodado, ");
                sql.AppendLine("ISNULL(dbo.[F_SPLIT](a.DadosMov, ';', 5), '') as Id_veiculo ");
            }
            else
                sql.AppendLine(" Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from VTB_FRT_Pneus a ");
            sql.AppendLine("inner join TB_DIV_Empresa emp ");
            sql.AppendLine("on a.cd_empresa = emp.cd_empresa ");
            sql.AppendLine("left outer join TB_EST_Produto b ");
            sql.AppendLine("on a.Cd_produto = b.Cd_produto ");
            sql.AppendLine("left outer join TB_FRT_DesenhoPneu c ");
            sql.AppendLine("on a.id_desenho = c.id_desenho ");
            //sql.AppendLine("left outer join TB_AMX_Almox_X_Empresa d ");
            //sql.AppendLine("on a.cd_empresa = d.cd_empresa ");
            //sql.AppendLine("left outer join TB_AMX_Almoxarifado e ");
            //sql.AppendLine("on d.Id_Almox = e.Id_Almox ");

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

        public TList_LanPneu Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNm_Campo)
        {
            TList_LanPneu lista = new TList_LanPneu();
            System.Data.SqlClient.SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            try
            {
                reader = ExecutarBusca(SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNm_Campo));
                while (reader.Read())
                {
                    TRegistro_LanPneu reg = new TRegistro_LanPneu();
                    if (!reader.IsDBNull(reader.GetOrdinal("Cd_empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("Cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_empresa")))
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("nm_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_pneu")))
                        reg.Id_pneu = reader.GetDecimal(reader.GetOrdinal("id_pneu"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Cd_produto")))
                        reg.Cd_produto = reader.GetString(reader.GetOrdinal("Cd_produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Ds_produto")))
                        reg.Ds_produto = reader.GetString(reader.GetOrdinal("Ds_produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_serie")))
                        reg.Nr_serie = reader.GetString(reader.GetOrdinal("nr_serie"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Tp_estado")))
                        reg.Tp_estado = reader.GetString(reader.GetOrdinal("Tp_estado"));
                    if (!reader.IsDBNull(reader.GetOrdinal("MotivoDesativacao")))
                        reg.MotivoDesativacao = reader.GetString(reader.GetOrdinal("MotivoDesativacao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("HodometroDesativacao")))
                        reg.HodometroDesativacao = reader.GetInt32(reader.GetOrdinal("HodometroDesativacao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Observacao")))
                        reg.DS_Observacao = reader.GetString(reader.GetOrdinal("DS_Observacao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Id_veiculo")))
                        reg.Id_veiculo = reader.GetString(reader.GetOrdinal("Id_veiculo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Ds_veiculo")))
                        reg.Ds_veiculo = reader.GetString(reader.GetOrdinal("Ds_veiculo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Placa")))
                        reg.Placa = reader.GetString(reader.GetOrdinal("Placa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Ds_rodado")))
                        reg.Ds_rodado = reader.GetString(reader.GetOrdinal("Ds_rodado"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Id_rodado")))
                        reg.Id_rodado = reader.GetString(reader.GetOrdinal("Id_rodado"));
                    if (!reader.IsDBNull(reader.GetOrdinal("St_PneuNovo")))
                        reg.St_pneunovo = reader.GetString(reader.GetOrdinal("St_PneuNovo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_registro")))
                        reg.St_registro = reader.GetString(reader.GetOrdinal("st_registro"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_desenho")))
                        reg.Id_desenho = reader.GetInt32(reader.GetOrdinal("id_desenho"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_desenho")))
                        reg.Ds_desenho = reader.GetString(reader.GetOrdinal("ds_desenho"));
                    if (!reader.IsDBNull(reader.GetOrdinal("valor_os")))
                        reg.Valor_OS = reader.GetDecimal(reader.GetOrdinal("valor_os"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_almox")))
                        reg.Id_almox = reader.GetDecimal(reader.GetOrdinal("id_almox"));

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

        public string Gravar(TRegistro_LanPneu val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(9);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_ALMOX", val.Id_almox);
            hs.Add("@P_ID_PNEU", val.Id_pneu);
            hs.Add("@P_ID_DESENHO", val.Id_desenho);
            hs.Add("@P_CD_PRODUTO", val.Cd_produto);
            hs.Add("@P_NR_SERIE", val.Nr_serie);
            hs.Add("@P_TP_ESTADO", val.Tp_estado);
            hs.Add("@P_DS_OBSERVACAO", val.DS_Observacao);
            hs.Add("@P_ST_REGISTRO", val.St_registro);
            hs.Add("@P_MOTIVODESATIVACAO", val.MotivoDesativacao);
            hs.Add("@P_HODOMETRODESATIVACAO", val.HodometroDesativacao);
            hs.Add("@P_VALOR_OS", val.Valor_OS);

            return executarProc("IA_FRT_PNEUS", hs);
        }

        public string Excluir(TRegistro_LanPneu val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(2);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_PNEU", val.Id_pneu);

            return executarProc("EXCLUI_FRT_PNEUS", hs);
        }


    }
}
