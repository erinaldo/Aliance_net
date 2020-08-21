using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamadaDados.Frota.Cadastros
{
    public class TList_RotaFrete : List<TRegistro_RotaFrete>, IComparer<TRegistro_RotaFrete>
    {
        #region IComparer<TRegistro_RotaFrete> Members
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

        public TList_RotaFrete()
        { }

        public TList_RotaFrete(System.ComponentModel.PropertyDescriptor Prop,
                                     System.Windows.Forms.SortOrder Dir)
        {
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_RotaFrete value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_RotaFrete x, TRegistro_RotaFrete y)
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

    
    public class TRegistro_RotaFrete
    {
        private decimal? id_rota;
        
        public decimal? Id_rota
        {
            get { return id_rota; }
            set
            {
                id_rota = value;
                id_rotastr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_rotastr;
        
        public string Id_rotastr
        {
            get { return id_rotastr; }
            set
            {
                id_rotastr = value;
                try
                {
                    id_rota = decimal.Parse(value);
                }
                catch
                { id_rota = null; }

            }
        }
        
        public string Cd_cidade_origem
        { get; set; }
        
        public string Ds_cidade_origem
        { get; set; }
        
        public string Cd_uf_origem
        { get; set; }
        
        public string Uf_origem
        { get; set; }
        
        public string Cd_cidade_destino
        { get; set; }
        
        public string Ds_cidade_destino
        { get; set; }
        
        public string Cd_uf_destino
        { get; set; }
        
        public string Uf_destino
        { get; set; }
        
        public string Cd_unidade_frete
        { get; set; }
        
        public string Ds_unidade_frete
        { get; set; }
        
        public string Sigla_unidade
        { get; set; }
        
        public string Ds_rota
        { get; set; }
        
        public decimal Vl_freteFixo
        { get; set; }
        
        public decimal Vl_freteUnidade
        { get; set; }
        
        public decimal Distancia_KM
        { get; set; }
        
        public decimal Qt_diasrota
        { get; set; }
        
        public decimal Vl_pedagios
        { get; set; }
        
        public string Ds_observacao
        { get; set; }
        
        public string St_registro
        { get; set; }
        
        public bool St_processar
        { get; set; }

        public TRegistro_RotaFrete()
        {
            this.id_rota = null;
            this.id_rotastr = string.Empty;
            this.Cd_cidade_origem = string.Empty;
            this.Ds_cidade_origem = string.Empty;
            this.Cd_uf_origem = string.Empty;
            this.Uf_origem = string.Empty;
            this.Cd_cidade_destino = string.Empty;
            this.Ds_cidade_destino = string.Empty;
            this.Cd_uf_destino = string.Empty;
            this.Uf_destino = string.Empty;
            this.Cd_unidade_frete = string.Empty;
            this.Ds_unidade_frete = string.Empty;
            this.Sigla_unidade = string.Empty;
            this.Ds_rota = string.Empty;
            this.Vl_freteFixo = decimal.Zero;
            this.Vl_freteUnidade = decimal.Zero;
            this.Distancia_KM = decimal.Zero;
            this.Qt_diasrota = decimal.Zero;
            this.Vl_pedagios = decimal.Zero;
            this.Ds_observacao = string.Empty;
            this.St_registro = "A";
            this.St_processar = false;
        }
    }

    public class TCD_RotaFrete : TDataQuery
    {
        public TCD_RotaFrete()
        { }

        public TCD_RotaFrete(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + vTop.ToString();

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("select " + strTop + " a.id_rota, a.cd_cidade_origem, ");
                sql.AppendLine("b.ds_cidade as ds_cidade_origem, a.cd_cidade_destino, ");
                sql.AppendLine("c.ds_cidade as ds_cidade_destino, a.cd_unidfrete, d.ds_unidade, ");
                sql.AppendLine("a.ds_rota, a.vl_fretefixo, a.vl_freteunidade, a.distancia_km, ");
                sql.AppendLine("uf_o.cd_uf as cd_uf_origem, uf_o.uf as uf_origem, ");
                sql.AppendLine("uf_d.cd_uf as cd_uf_destino, uf_d.uf as uf_destino, d.sigla_unidade, ");
                sql.AppendLine("a.vl_pedagios, a.ds_observacao, a.st_registro, a.qt_diasrota ");

            }
            else
                sql.AppendLine(" Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from tb_frt_RotaFrete a ");
            sql.AppendLine("inner join TB_fin_cidade b ");
            sql.AppendLine("on a.cd_cidade_origem = b.cd_cidade ");
            sql.AppendLine("inner join tb_fin_uf uf_o ");
            sql.AppendLine("on b.cd_uf = uf_o.cd_uf ");
            sql.AppendLine("inner join tb_fin_cidade c ");
            sql.AppendLine("on a.cd_cidade_destino = c.cd_cidade ");
            sql.AppendLine("inner join tb_fin_uf uf_d ");
            sql.AppendLine("on c.cd_uf = uf_d.cd_uf ");
            sql.AppendLine("left outer join TB_EST_Unidade d ");
            sql.AppendLine("on a.cd_unidfrete = d.cd_unidade ");

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

        public TList_RotaFrete Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            bool podeFecharBco = false;
            TList_RotaFrete lista = new TList_RotaFrete();
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_RotaFrete reg = new TRegistro_RotaFrete();
                    if (!reader.IsDBNull(reader.GetOrdinal("id_rota")))
                        reg.Id_rota = reader.GetDecimal(reader.GetOrdinal("id_rota"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_cidade_origem")))
                        reg.Cd_cidade_origem = reader.GetString(reader.GetOrdinal("cd_cidade_origem"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_cidade_origem")))
                        reg.Ds_cidade_origem = reader.GetString(reader.GetOrdinal("ds_cidade_origem"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_uf_origem")))
                        reg.Cd_uf_origem = reader.GetString(reader.GetOrdinal("cd_uf_origem"));
                    if (!reader.IsDBNull(reader.GetOrdinal("uf_origem")))
                        reg.Uf_origem = reader.GetString(reader.GetOrdinal("uf_origem"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_cidade_destino")))
                        reg.Cd_cidade_destino = reader.GetString(reader.GetOrdinal("cd_cidade_destino"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_cidade_destino")))
                        reg.Ds_cidade_destino = reader.GetString(reader.GetOrdinal("ds_cidade_destino"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_uf_destino")))
                        reg.Cd_uf_destino = reader.GetString(reader.GetOrdinal("cd_uf_destino"));
                    if (!reader.IsDBNull(reader.GetOrdinal("uf_destino")))
                        reg.Uf_destino = reader.GetString(reader.GetOrdinal("uf_destino"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_unidfrete")))
                        reg.Cd_unidade_frete = reader.GetString(reader.GetOrdinal("cd_unidfrete"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_unidade")))
                        reg.Ds_unidade_frete = reader.GetString(reader.GetOrdinal("ds_unidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("sigla_unidade")))
                        reg.Sigla_unidade = reader.GetString(reader.GetOrdinal("sigla_unidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_rota")))
                        reg.Ds_rota = reader.GetString(reader.GetOrdinal("ds_rota"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_fretefixo")))
                        reg.Vl_freteFixo = reader.GetDecimal(reader.GetOrdinal("vl_fretefixo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_freteunidade")))
                        reg.Vl_freteUnidade = reader.GetDecimal(reader.GetOrdinal("vl_freteunidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("distancia_km")))
                        reg.Distancia_KM = reader.GetDecimal(reader.GetOrdinal("distancia_km"));
                    if (!reader.IsDBNull(reader.GetOrdinal("qt_diasrota")))
                        reg.Qt_diasrota = reader.GetDecimal(reader.GetOrdinal("qt_diasrota"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_pedagios")))
                        reg.Vl_pedagios = reader.GetDecimal(reader.GetOrdinal("vl_pedagios"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_observacao")))
                        reg.Ds_observacao = reader.GetString(reader.GetOrdinal("ds_observacao"));
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

        public string Gravar(TRegistro_RotaFrete val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(12);
            hs.Add("@P_ID_ROTA", val.Id_rota);
            hs.Add("@P_CD_CIDADE_ORIGEM", val.Cd_cidade_origem);
            hs.Add("@P_CD_CIDADE_DESTINO", val.Cd_cidade_destino);
            hs.Add("@P_CD_UNIDFRETE", val.Cd_unidade_frete);
            hs.Add("@P_DS_ROTA", val.Ds_rota);
            hs.Add("@P_VL_FRETEFIXO", val.Vl_freteFixo);
            hs.Add("@P_VL_FRETEUNIDADE", val.Vl_freteUnidade);
            hs.Add("@P_DISTANCIA_KM", val.Distancia_KM);
            hs.Add("@P_QT_DIASROTA", val.Qt_diasrota);
            hs.Add("@P_VL_PEDAGIOS", val.Vl_pedagios);
            hs.Add("@P_DS_OBSERVACAO", val.Ds_observacao);
            hs.Add("@P_ST_REGISTRO", val.St_registro);

            return this.executarProc("IA_FRT_ROTAFRETE", hs);
        }

        public string Excluir(TRegistro_RotaFrete val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(1);
            hs.Add("@P_ID_ROTA", val.Id_rota);

            return this.executarProc("EXCLUI_FRT_ROTAFRETE", hs);
        }
    }
}
