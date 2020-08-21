using System;
using System.Data;
using System.Drawing;
using System.Text;
using System.Collections;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace CamadaDados.Frota.Cadastros
{
    #region Cadastro Veiculo

    public class TList_CadVeiculo : List<TRegistro_CadVeiculo>, IComparer<TRegistro_CadVeiculo>
    {
        #region IComparer<TRegistro_CadVeiculo> Members
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

        public TList_CadVeiculo()
        { }

        public TList_CadVeiculo(System.ComponentModel.PropertyDescriptor Prop,
                                System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_CadVeiculo value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_CadVeiculo x, TRegistro_CadVeiculo y)
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
    
    public class TRegistro_CadVeiculo
    {
        private decimal? id_veiculo;
        public decimal? Id_veiculo
        {
            get { return id_veiculo; }
            set
            {
                id_veiculo = value;
                id_veiculostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_veiculostr;
        public string Id_veiculostr
        {
            get { return id_veiculostr; }
            set
            {
                id_veiculostr = value;
                try
                {
                    id_veiculo = Convert.ToDecimal(value);
                }
                catch
                { id_veiculo = null; }
            }
        }
        public string Cd_cidade
        { get; set; }
        public string Ds_cidade
        { get; set; }
        public string Uf_veiculo
        { get; set; }
        private decimal? id_veiculo_principal;
        public decimal? Id_veiculo_principal
        {
            get { return id_veiculo_principal; }
            set
            {
                id_veiculo_principal = value;
                id_veiculo_principalstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_veiculo_principalstr;
        public string Id_veiculo_principalstr
        {
            get { return id_veiculo_principalstr; }
            set
            {
                id_veiculo_principalstr = value;
                try
                {
                    id_veiculo_principal = Convert.ToDecimal(value);
                }
                catch
                { id_veiculo_principal = null; }
            }
        }
        public string Ds_veiculo_principal
        { get; set; }
        public string Cd_tpveiculo
        { get; set; }
        public string Ds_tpveiculo
        { get; set; }
        public string Tp_veiculo
        { get; set; }
        public string Tp_rodado
        { get; set; }
        public string Ds_veiculo
        { get; set; }
        public string placa
        { get; set; }
        public string cor
        { get; set; }
        public string modelo
        { get; set; }
        public string chassi
        { get; set; }
        public string renavan
        { get; set; }
        public decimal Hodometro
        { get; set; }
        private DateTime? dt_aquisicao;
        public DateTime? Dt_aquisicao
        {
            get { return dt_aquisicao; }
            set
            {
                dt_aquisicao = value;
                dt_aquisicaostr = value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty;
            }
        }
        private string dt_aquisicaostr;
        public string Dt_aquisicaostr
        {
            get
            {
                try
                {
                    return Convert.ToDateTime(dt_aquisicaostr).ToString("dd/MM/yyyy");
                }
                catch
                { return string.Empty; }
            }
            set
            {
                dt_aquisicaostr = value;
                try
                {
                    dt_aquisicao = Convert.ToDateTime(value);
                }
                catch
                { dt_aquisicao = null; }
            }
        }
        private DateTime? dt_vencdoc;
        public DateTime? Dt_vencdoc
        {
            get { return dt_vencdoc; }
            set
            {
                dt_vencdoc = value;
                dt_vencdocstr = value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty;
            }
        }
        private string dt_vencdocstr;
        public string Dt_vencdocstr
        {
            get
            {
                try
                {
                    return Convert.ToDateTime(dt_vencdocstr).ToString("dd/MM/yyyy");
                }
                catch
                { return string.Empty; }
            }
            set
            {
                dt_vencdocstr = value;
                try
                {
                    dt_vencdoc = Convert.ToDateTime(value);
                }
                catch
                { dt_vencdoc = null; }
            }
        }
        public string Ds_observacao
        { get; set; }
        public string St_registro
        { get; set; }
        public string Status
        {
            get
            {
                if (St_registro.Trim().ToUpper().Equals("A"))
                    return "ATIVO";
                else if (St_registro.Trim().ToUpper().Equals("I"))
                    return "INATIVO";
                else return string.Empty;
            }
        }
        private decimal? id_marca;
        public decimal? Id_marca
        {
            get { return id_marca; }
            set
            {
                id_marca = value;
                id_marcastr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_marcastr;
        public string Id_marcastr
        {
            get { return id_marcastr; }
            set
            {
                id_marcastr = value;
                try
                {
                    id_marca = Convert.ToDecimal(value);
                }
                catch
                { id_marca = null; }
            }
        }
        public string Ds_marca
        { get; set; }
        public string Ano_modelo
        { get; set; }
        public string Ano_fabric
        { get; set; }
        public string Tp_combustivel
        { get; set; }
        public string Tipo_combustivel
        {
            get
            {
                if (Tp_combustivel.Trim().ToUpper().Equals("ET"))
                    return "ETANOL";
                else if (Tp_combustivel.Trim().ToUpper().Equals("GC"))
                    return "GASOLINA";
                else if (Tp_combustivel.Trim().ToUpper().Equals("OD"))
                    return "OLEO DIESEL";
                else if (Tp_combustivel.Trim().ToUpper().Equals("FL"))
                    return "FLEX-BICOMBUSTIVEL";
                else return string.Empty;
               
                
            }
        }
        public decimal capacidade_Tanque
        { get; set; }
        public decimal Vl_aquisicao
        { get; set; }
        public string Nr_frota
        { get; set; }
        private string tp_carroceria;
        public string Tp_carroceria
        {
            get { return tp_carroceria; }
            set
            {
                tp_carroceria = value;
                if (value.Trim().Equals("00"))
                    tipo_carroceria = "NÃO APLICAVEL";
                else if (value.Trim().Equals("01"))
                    tipo_carroceria = "ABERTA";
                else if (value.Trim().Equals("02"))
                    tipo_carroceria = "FECHADA/BAU";
                else if (value.Trim().Equals("03"))
                    tipo_carroceria = "GRANELERA";
                else if (value.Trim().Equals("04"))
                    tipo_carroceria = "PORTA CONTAINER";
                else if (value.Trim().Equals("05"))
                    tipo_carroceria = "SIDER";
            }
        }
        private string tipo_carroceria;
        public string Tipo_carroceria
        {
            get { return tipo_carroceria; }
            set
            {
                tipo_carroceria = value;
                if (value.Trim().ToUpper().Equals("NÃO APLICAVEL"))
                    tp_carroceria = "00";
                else if (value.Trim().ToUpper().Equals("ABERTA"))
                    tp_carroceria = "01";
                else if (value.Trim().ToUpper().Equals("FECHADA/BAU"))
                    tp_carroceria = "02";
                else if (value.Trim().ToUpper().Equals("GRANELERA"))
                    tp_carroceria = "03";
                else if (value.Trim().ToUpper().Equals("PORTA CONTAINER"))
                    tp_carroceria = "04";
                else if (value.Trim().ToUpper().Equals("SIDER"))
                    tp_carroceria = "05";
            }
        }
        public decimal Ps_tara_kg
        { get; set; }
        public decimal Capacidade_kg
        { get; set; }
        public decimal Capacidade_m3
        { get; set; }
        private string tp_propriedade;
        public string Tp_propriedade
        {
            get { return tp_propriedade; }
            set
            {
                tp_propriedade = value;
                if (value.Trim().ToUpper().Equals("P"))
                    tipo_propriedade = "PRÓPRIO";
                else if (value.Trim().ToUpper().Equals("T"))
                    tipo_propriedade = "TERCEIRO";
            }
        }
        private string tipo_propriedade;
        public string Tipo_propriedade
        {
            get { return tipo_propriedade; }
            set
            {
                tipo_propriedade = value;
                if (value.Trim().ToUpper().Equals("PRÓPRIO"))
                    tp_propriedade = "P";
                else if (value.Trim().ToUpper().Equals("TERCEIRO"))
                    tp_propriedade = "T";
            }
        }
        public string Cd_proprietario
        { get; set; }
        public string Nm_proprietario
        { get; set; }
        public string Cnpj_cpf_prop
        { get; set; }
        public string Cd_endproprietario
        { get; set; }
        public string Ds_endproprietario
        { get; set; }
        public string Uf_proprietario
        { get; set; }
        public string Insc_estadual_prop
        { get; set; }
        public string Rntrc_prop
        { get; set; }
        private string tp_proprietario;
        public string Tp_proprietario
        {
            get { return tp_proprietario; }
            set
            {
                tp_proprietario = value;
                if (value.Trim().Equals("0"))
                    tipo_proprietario = "TAC-AGREGADO";
                else if (value.Trim().Equals("1"))
                    tipo_proprietario = "TAC-INDEPENDENTE";
                else if (value.Trim().Equals("2"))
                    tipo_proprietario = "OUTROS";
            }
        }
        private string tipo_proprietario;
        public string Tipo_proprietario
        {
            get { return tipo_proprietario; }
            set
            {
                tipo_proprietario = value;
                if (value.Trim().ToUpper().Equals("TAC-AGREGADO"))
                    tp_proprietario = "0";
                else if (value.Trim().ToUpper().Equals("TAC-INDEPENDENTE"))
                    tp_proprietario = "1";
                else if (value.Trim().ToUpper().Equals("OUTROS"))
                    tp_proprietario = "2";
            }
        }
        public bool St_processar
        { get; set; }

        private Image imagem;
        public Image Imagem
        {
            get { return imagem; }
            set
            {
                imagem = value;
                if (imagem != null)
                {
                    using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
                    {
                        imagem.Save(ms, imagem.RawFormat);
                        img = ms.ToArray();
                    }
                }
            }
        }
        private byte[] img;
        public byte[] Img
        {
            get { return img; }
            set
            {
                img = value;
                if (value != null)
                    imagem = (Image)new ImageConverter().ConvertFrom(value);
            }
        }

        public TRegistro_CadVeiculo()
        {
            Id_veiculo = null;
            Id_veiculostr = string.Empty;
            Cd_cidade = string.Empty;
            Ds_cidade = string.Empty;
            Uf_veiculo = string.Empty;
            Id_veiculo_principal = null;
            id_veiculo_principalstr = string.Empty;
            Ds_veiculo_principal = string.Empty;
            Cd_tpveiculo = string.Empty;
            Ds_tpveiculo = string.Empty;
            Tp_veiculo = string.Empty;
            Tp_rodado = string.Empty;
            Ds_veiculo = string.Empty;
            placa = string.Empty;
            cor = string.Empty;
            modelo = string.Empty;
            chassi = string.Empty;
            renavan = string.Empty;
            Hodometro = decimal.Zero;
            dt_aquisicao = null;
            dt_aquisicaostr = string.Empty;
            dt_vencdoc = null;
            dt_vencdocstr = string.Empty;
            Ds_observacao = string.Empty;
            St_registro = "A";
            id_marca = null;
            id_marcastr = string.Empty;
            Ds_marca = string.Empty;
            Ano_modelo = string.Empty;
            Ano_fabric = string.Empty;
            Tp_combustivel = string.Empty;
            capacidade_Tanque = decimal.Zero;
            Vl_aquisicao = decimal.Zero;
            Nr_frota = string.Empty;
            tp_carroceria = string.Empty;
            tipo_carroceria = string.Empty;
            Ps_tara_kg = decimal.Zero;
            Capacidade_kg = decimal.Zero;
            Capacidade_m3 = decimal.Zero;
            tp_propriedade = "P";
            tipo_propriedade = "PRÓPRIO";
            Cd_proprietario = string.Empty;
            Nm_proprietario = string.Empty;
            Cnpj_cpf_prop = string.Empty;
            Cd_endproprietario = string.Empty;
            Ds_endproprietario = string.Empty;
            Uf_proprietario = string.Empty;
            Insc_estadual_prop = string.Empty;
            Rntrc_prop = string.Empty;
            tp_proprietario = string.Empty;
            tipo_proprietario = string.Empty;
            St_processar = false;
            Img = null;
            Imagem = null;
        }
    }

    public class TCD_CadVeiculo : TDataQuery
    {
        public TCD_CadVeiculo()
        { }

        public TCD_CadVeiculo(BancoDados.TObjetoBanco banco)
        { Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("select " + strTop + " a.foto, a.ID_veiculo, c.tp_veiculo, c.tp_rodado, ");
                sql.AppendLine("a.cd_cidade, b.ds_cidade, f.ds_veiculo as ds_veiculo_principal, ");
                sql.AppendLine("a.id_veiculo_principal, a.cd_tpveiculo, a.nr_frota, a.tp_carroceria, ");
                sql.AppendLine("c.ds_tpveiculo, a.ds_veiculo, a.id_marca, e.ds_marca, a.placa, a.cor, ");
                sql.AppendLine("a.modelo, a.chassi, a.renavan, a.hodometro, a.dt_aquisicao, uf.uf, ");
                sql.AppendLine("a.vl_aquisicao, a.dt_vencdoc, a.st_registro, a.ds_observacao, ");
                sql.AppendLine("a.ano_modelo, a.ano_fabric, a.tp_combustivel, a.capacidade_tanque, ");
                sql.AppendLine("a.ps_tara_kg, a.capacidade_kg, a.capacidade_m3, a.tp_propriedade, ");
                sql.AppendLine("a.cd_proprietario, g.nm_clifor as nm_proprietario, ");
                sql.AppendLine("case when g.tp_pessoa = 'J' then g.nr_cgc else g.nr_cpf end as cnpj_cpf_prop, ");
                sql.AppendLine("a.cd_endproprietario, h.ds_endereco as ds_endproprietario, h.insc_estadual, ");
                sql.AppendLine("a.rntrc_prop, a.tp_proprietario ");
            }
            else
                sql.AppendLine(" Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from TB_FRT_veiculo a ");
            sql.AppendLine("left outer join TB_fin_cidade b ");
            sql.AppendLine("on a.cd_cidade = b.cd_cidade ");
            sql.AppendLine("left outer join TB_FIN_UF uf ");
            sql.AppendLine("on b.cd_uf = uf.cd_uf ");
            sql.AppendLine("inner join TB_div_tpveiculo c ");
            sql.AppendLine("on a.cd_tpveiculo = c.cd_tpveiculo ");
            sql.AppendLine("left outer join TB_FRT_MarcaVeiculo e ");
            sql.AppendLine("on a.id_marca = e.id_marca ");
            sql.AppendLine("left outer join TB_FRT_Veiculo f ");
            sql.AppendLine("on a.id_veiculo_principal = f.id_veiculo ");
            sql.AppendLine("left outer join VTB_FIN_Clifor g ");
            sql.AppendLine("on a.cd_proprietario = g.cd_clifor ");
            sql.AppendLine("left outer join VTB_FIN_Endereco h ");
            sql.AppendLine("on a.cd_proprietario = h.cd_clifor ");
            sql.AppendLine("and a.cd_endproprietario = h.cd_endereco ");
           

            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                    cond = " and ";
                }

            return sql.ToString();
        }

        public override DataTable Buscar(Utils.TpBusca[] vBusca, short vTop)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, string.Empty), null);
        }

        private string SqlCodeBuscaFoto(Utils.TpBusca[] vBusca)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine(" Select top 1 a.foto");
            sql.AppendLine("from TB_FRT_veiculo a ");

            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                    cond = " and ";
                }

            return sql.ToString();
        }

        public DataTable BuscarFoto(Utils.TpBusca[] vBusca, Hashtable vParametros)
        {
            return ExecutarBusca(SqlCodeBuscaFoto(vBusca), vParametros);
        }

        public override DataTable Buscar(Utils.TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo), null);
        }

        public override object BuscarEscalar(Utils.TpBusca[] vBusca, string vNM_Campo)
        {
            return ExecutarBuscaEscalar(SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }

        public TList_CadVeiculo Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNm_Campo)
        {
            TList_CadVeiculo lista = new TList_CadVeiculo();
            SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            try
            {
                reader = ExecutarBusca(SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNm_Campo));
                while (reader.Read())
                {
                    TRegistro_CadVeiculo reg = new TRegistro_CadVeiculo();

                    if (!reader.IsDBNull(reader.GetOrdinal("id_veiculo")))
                        reg.Id_veiculo = reader.GetDecimal(reader.GetOrdinal("id_veiculo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_cidade")))
                        reg.Cd_cidade = reader.GetString(reader.GetOrdinal("cd_cidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_cidade")))
                        reg.Ds_cidade = reader.GetString(reader.GetOrdinal("ds_cidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("uf")))
                        reg.Uf_veiculo = reader.GetString(reader.GetOrdinal("uf"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_veiculo_principal")))
                        reg.Id_veiculo_principal = reader.GetDecimal(reader.GetOrdinal("id_veiculo_principal"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_veiculo_principal")))
                        reg.Ds_veiculo_principal = reader.GetString(reader.GetOrdinal("ds_veiculo_principal"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_tpveiculo")))
                        reg.Cd_tpveiculo = reader.GetString(reader.GetOrdinal("cd_tpveiculo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_tpveiculo")))
                        reg.Ds_tpveiculo = reader.GetString(reader.GetOrdinal("ds_tpveiculo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_veiculo")))
                        reg.Tp_veiculo = reader.GetString(reader.GetOrdinal("tp_veiculo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_rodado")))
                        reg.Tp_rodado = reader.GetString(reader.GetOrdinal("tp_rodado"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_veiculo")))
                        reg.Ds_veiculo = reader.GetString(reader.GetOrdinal("ds_veiculo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("placa")))
                        reg.placa = reader.GetString(reader.GetOrdinal("placa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cor")))
                        reg.cor = reader.GetString(reader.GetOrdinal("cor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("modelo")))
                        reg.modelo = reader.GetString(reader.GetOrdinal("modelo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("chassi")))
                        reg.chassi = reader.GetString(reader.GetOrdinal("chassi"));
                    if (!reader.IsDBNull(reader.GetOrdinal("renavan")))
                        reg.renavan = reader.GetString(reader.GetOrdinal("renavan"));
                    if (!reader.IsDBNull(reader.GetOrdinal("hodometro")))
                        reg.Hodometro = reader.GetDecimal(reader.GetOrdinal("hodometro"));
                    if (!reader.IsDBNull(reader.GetOrdinal("dt_aquisicao")))
                        reg.Dt_aquisicao = reader.GetDateTime(reader.GetOrdinal("dt_aquisicao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_aquisicao")))
                        reg.Vl_aquisicao = reader.GetDecimal(reader.GetOrdinal("vl_aquisicao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("dt_vencdoc")))
                        reg.Dt_vencdoc = reader.GetDateTime(reader.GetOrdinal("dt_vencdoc"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_observacao")))
                        reg.Ds_observacao = reader.GetString(reader.GetOrdinal("ds_observacao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_registro")))
                        reg.St_registro = reader.GetString(reader.GetOrdinal("st_registro"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_marca")))
                        reg.Id_marca = reader.GetDecimal(reader.GetOrdinal("id_marca"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_marca")))
                        reg.Ds_marca = reader.GetString(reader.GetOrdinal("ds_marca"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ano_modelo")))
                        reg.Ano_modelo = reader.GetString(reader.GetOrdinal("ano_modelo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ano_fabric")))
                        reg.Ano_fabric = reader.GetString(reader.GetOrdinal("ano_fabric"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_combustivel")))
                        reg.Tp_combustivel = reader.GetString(reader.GetOrdinal("tp_combustivel"));
                    if (!reader.IsDBNull(reader.GetOrdinal("capacidade_tanque")))
                        reg.capacidade_Tanque = reader.GetDecimal(reader.GetOrdinal("capacidade_tanque"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_frota")))
                        reg.Nr_frota = reader.GetString(reader.GetOrdinal("nr_frota"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_carroceria")))
                        reg.Tp_carroceria = reader.GetString(reader.GetOrdinal("tp_carroceria"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ps_tara_kg")))
                        reg.Ps_tara_kg = reader.GetDecimal(reader.GetOrdinal("ps_tara_kg"));
                    if (!reader.IsDBNull(reader.GetOrdinal("capacidade_kg")))
                        reg.Capacidade_kg = reader.GetDecimal(reader.GetOrdinal("capacidade_kg"));
                    if (!reader.IsDBNull(reader.GetOrdinal("capacidade_m3")))
                        reg.Capacidade_m3 = reader.GetDecimal(reader.GetOrdinal("capacidade_m3"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_propriedade")))
                        reg.Tp_propriedade = reader.GetString(reader.GetOrdinal("tp_propriedade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_proprietario")))
                        reg.Cd_proprietario = reader.GetString(reader.GetOrdinal("cd_proprietario"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_proprietario")))
                        reg.Nm_proprietario = reader.GetString(reader.GetOrdinal("nm_proprietario"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cnpj_cpf_prop")))
                        reg.Cnpj_cpf_prop = reader.GetString(reader.GetOrdinal("cnpj_cpf_prop"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_endproprietario")))
                        reg.Cd_endproprietario = reader.GetString(reader.GetOrdinal("cd_endproprietario"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_endproprietario")))
                        reg.Ds_endproprietario = reader.GetString(reader.GetOrdinal("ds_endproprietario"));
                    if (!reader.IsDBNull(reader.GetOrdinal("insc_estadual")))
                        reg.Insc_estadual_prop = reader.GetString(reader.GetOrdinal("insc_estadual"));
                    if (!reader.IsDBNull(reader.GetOrdinal("rntrc_prop")))
                        reg.Rntrc_prop = reader.GetString(reader.GetOrdinal("rntrc_prop"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_proprietario")))
                        reg.Tp_proprietario = reader.GetString(reader.GetOrdinal("tp_proprietario"));
                    if (!reader.IsDBNull(reader.GetOrdinal("foto")))
                        reg.Img = (byte[])reader.GetValue(reader.GetOrdinal("foto"));

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

        public string Gravar(TRegistro_CadVeiculo val)
        {
            Hashtable hs = new Hashtable(31);
            hs.Add("@P_ID_VEICULO", val.Id_veiculo);
            hs.Add("@P_CD_CIDADE", val.Cd_cidade);
            hs.Add("@P_ID_VEICULO_PRINCIPAL", val.Id_veiculo_principal);
            hs.Add("@P_CD_TPVEICULO", val.Cd_tpveiculo);
            hs.Add("@P_ID_MARCA", val.Id_marca);
            hs.Add("@P_DS_VEICULO", val.Ds_veiculo);
            hs.Add("@P_PLACA", val.placa);
            hs.Add("@P_COR", val.cor);
            hs.Add("@P_MODELO", val.modelo);
            hs.Add("@P_CHASSI", val.chassi);
            hs.Add("@P_RENAVAN", val.renavan);
            hs.Add("@P_HODOMETRO", val.Hodometro);
            hs.Add("@P_DT_AQUISICAO", val.Dt_aquisicao);
            hs.Add("@P_VL_AQUISICAO", val.Vl_aquisicao);
            hs.Add("@P_DT_VENCDOC", val.Dt_vencdoc);
            hs.Add("@P_DS_OBSERVACAO", val.Ds_observacao);
            hs.Add("@P_ANO_MODELO", val.Ano_modelo);
            hs.Add("@P_ANO_FABRIC", val.Ano_fabric);
            hs.Add("@P_ST_REGISTRO", val.St_registro);
            hs.Add("@P_TP_COMBUSTIVEL", val.Tp_combustivel);
            hs.Add("@P_CAPACIDADE_TANQUE", val.capacidade_Tanque);
            hs.Add("@P_NR_FROTA", val.Nr_frota);
            hs.Add("@P_TP_CARROCERIA", val.Tp_carroceria);
            hs.Add("@P_PS_TARA_KG", val.Ps_tara_kg);
            hs.Add("@P_CAPACIDADE_KG", val.Capacidade_kg);
            hs.Add("@P_CAPACIDADE_M3", val.Capacidade_m3);
            hs.Add("@P_CD_PROPRIETARIO", val.Cd_proprietario);
            hs.Add("@P_CD_ENDPROPRIETARIO", val.Cd_endproprietario);
            hs.Add("@P_TP_PROPRIEDADE", val.Tp_propriedade);
            hs.Add("@P_RNTRC_PROP", val.Rntrc_prop);
            hs.Add("@P_TP_PROPRIETARIO", val.Tp_proprietario);
            hs.Add("@P_FOTO", val.Img);

            return executarProc("IA_FRT_VEICULO", hs);
        }

        public string Excluir(TRegistro_CadVeiculo val)
        {
            Hashtable hs = new Hashtable(1);
            hs.Add("@P_ID_VEICULO", val.Id_veiculo);

            return executarProc("EXCLUI_FRT_VEICULO", hs);
        }

    }

    #endregion

    #region Cadastro Seguro Veiculo

    public class TList_CadSeguroVeiculo : List<TRegistro_CadSeguroVeiculo>, IComparer<TRegistro_CadSeguroVeiculo>
    {

        #region IComparer<TRegistro_CadSeguroVeiculo> Members
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

        public TList_CadSeguroVeiculo()
        { }

        public TList_CadSeguroVeiculo(System.ComponentModel.PropertyDescriptor Prop,
                                System.Windows.Forms.SortOrder Dir)
        {
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_CadSeguroVeiculo value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_CadSeguroVeiculo x, TRegistro_CadSeguroVeiculo y)
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

    
    public class TRegistro_CadSeguroVeiculo
    {
        private decimal? id_apolice;
        
        public decimal? Id_apolice
        {
            get { return id_apolice; }
            set
            {
                id_apolice = value;
                id_apolicestr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_apolicestr;
        
        public string Id_apolicestr
        {
            get { return id_apolicestr; }
            set
            {
                id_apolicestr = value;
                try
                {
                    id_apolice = Convert.ToDecimal(value);
                }
                catch
                { id_apolice = null; }
            }
        }
        private decimal? id_veiculo;
        
        public decimal? Id_veiculo
        {
            get { return id_veiculo; }
            set
            {
                id_veiculo = value;
                id_veiculostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_veiculostr;
        
        public string Id_veiculostr
        {
            get { return id_veiculostr; }
            set
            {
                id_veiculostr = value;
                try
                {
                    id_veiculo = Convert.ToDecimal(value);
                }
                catch
                { id_veiculo = null; }
            }
        }
        
        public string Ds_veiculo
        { get; set; }
        
        public string Placa
        { get; set; }
        
        public string Cd_seguradora
        { get; set; }
        
        public string Nm_seguradora
        { get; set; }
        
        public string Cd_corretora
        { get; set; }
        
        public string Nm_corretora
        { get; set; }
        
        public string Cd_apolice
        { get; set; }
        
        public string Cd_ci
        { get; set; }
        private DateTime? dt_ini_vigencia;
        
        public DateTime? Dt_ini_vigencia
        {
            get { return dt_ini_vigencia; }
            set
            {
                dt_ini_vigencia = value;
                dt_ini_vigenciastr = value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty;
            }
        }
        private string dt_ini_vigenciastr;
        public string Dt_ini_vigenciastr
        {
            get
            {
                try
                {
                    return Convert.ToDateTime(dt_ini_vigenciastr).ToString("dd/MM/yyyy");
                }
                catch
                { return string.Empty; }
            }
            set
            {
                dt_ini_vigenciastr = value;
                try
                {
                    dt_ini_vigencia = Convert.ToDateTime(value);
                }
                catch
                { dt_ini_vigencia = null; }
            }
        }
        private DateTime? dt_fin_vigencia;
        
        public DateTime? Dt_fin_vigencia
        {
            get { return dt_fin_vigencia; }
            set
            {
                dt_fin_vigencia = value;
                dt_fin_vigenciastr = value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty;
            }
        }
        private string dt_fin_vigenciastr;
        public string Dt_fin_vigenciastr
        {
            get
            {
                try
                {
                    return Convert.ToDateTime(dt_fin_vigenciastr).ToString("dd/MM/yyyy");
                }
                catch
                { return string.Empty; }
            }
            set
            {
                dt_fin_vigenciastr = value;
                try
                {
                    dt_fin_vigencia = Convert.ToDateTime(value);
                }
                catch
                { dt_fin_vigencia = null; }
            }
        }
        
        public decimal Vl_seguro
        { get; set; }
        
        public decimal Vl_franquia
        { get; set; }
        
        public TList_CadSeguroPremios lPremios
        { get; set; }
        
        public TList_CadSeguroPremios lPremiosDel
        { get; set; }
        
        public TRegistro_CadSeguroVeiculo()
        {
            Id_apolice = null;
            Id_apolicestr = string.Empty;
            Id_veiculo = null;
            Id_veiculostr = string.Empty;
            Ds_veiculo = string.Empty;
            Placa = string.Empty;
            Cd_seguradora = string.Empty;
            Cd_corretora = string.Empty;
            Cd_apolice = string.Empty;
            Cd_ci = string.Empty;
            dt_ini_vigencia = null;
            dt_ini_vigenciastr = string.Empty;
            dt_fin_vigencia = null;
            dt_fin_vigenciastr = string.Empty;
            Vl_seguro = decimal.Zero;
            Vl_franquia = decimal.Zero;
            lPremios = new TList_CadSeguroPremios();
            lPremiosDel = new TList_CadSeguroPremios();
        }
    }

    public class TCD_CadSeguroVeiculo : TDataQuery
    {
        public TCD_CadSeguroVeiculo()
        { }

        public TCD_CadSeguroVeiculo(BancoDados.TObjetoBanco banco)
        { Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("select " + strTop + " a.ID_apolice, a.vl_franquia, b.placa, ");
                sql.AppendLine("a.id_veiculo, b.ds_veiculo, a.cd_seguradora, c.nm_clifor as nm_seguradora, ");
                sql.AppendLine("a.cd_corretora, d.nm_clifor as nm_corretora, a.cd_apolice, ");
                sql.AppendLine("a.cd_ci, a.dt_ini_vigencia, a.dt_fin_vigencia, a.vl_seguro ");
            }
            else
                sql.AppendLine(" Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from TB_FRT_seguroveiculo a ");
            sql.AppendLine("inner join tb_frt_veiculo b ");
            sql.AppendLine("on a.id_veiculo = b.id_veiculo ");
            sql.AppendLine("left outer join tb_fin_clifor c ");
            sql.AppendLine("on a.cd_seguradora = c.cd_clifor ");
            sql.AppendLine("left outer join tb_fin_clifor d ");
            sql.AppendLine("on a.cd_corretora = d.cd_clifor ");


            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                    cond = " and ";
                }

            return sql.ToString();
        }

        public override DataTable Buscar(Utils.TpBusca[] vBusca, short vTop)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, string.Empty), null);
        }

        public override DataTable Buscar(Utils.TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo), null);
        }

        public override object BuscarEscalar(Utils.TpBusca[] vBusca, string vNM_Campo)
        {
            return ExecutarBuscaEscalar(SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }

        public TList_CadSeguroVeiculo Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNm_Campo)
        {
            TList_CadSeguroVeiculo lista = new TList_CadSeguroVeiculo();
            SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            try
            {
                reader = ExecutarBusca(SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNm_Campo));
                while (reader.Read())
                {
                    TRegistro_CadSeguroVeiculo reg = new TRegistro_CadSeguroVeiculo();

                    if (!reader.IsDBNull(reader.GetOrdinal("id_apolice")))
                        reg.Id_apolice = reader.GetDecimal(reader.GetOrdinal("id_apolice"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_veiculo")))
                        reg.Id_veiculo = reader.GetDecimal(reader.GetOrdinal("id_veiculo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_veiculo")))
                        reg.Ds_veiculo = reader.GetString(reader.GetOrdinal("ds_veiculo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("placa")))
                        reg.Placa = reader.GetString(reader.GetOrdinal("placa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_seguradora")))
                        reg.Cd_seguradora = reader.GetString(reader.GetOrdinal("cd_seguradora"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_seguradora")))
                        reg.Nm_seguradora = reader.GetString(reader.GetOrdinal("nm_seguradora"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_corretora")))
                        reg.Cd_corretora = reader.GetString(reader.GetOrdinal("cd_corretora"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_corretora")))
                        reg.Nm_corretora = reader.GetString(reader.GetOrdinal("nm_corretora"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_apolice")))
                        reg.Cd_apolice = reader.GetString(reader.GetOrdinal("cd_apolice"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_ci")))
                        reg.Cd_ci = reader.GetString(reader.GetOrdinal("cd_ci"));
                    if (!reader.IsDBNull(reader.GetOrdinal("dt_ini_vigencia")))
                        reg.Dt_ini_vigencia = reader.GetDateTime(reader.GetOrdinal("dt_ini_vigencia"));
                    if (!reader.IsDBNull(reader.GetOrdinal("dt_fin_vigencia")))
                        reg.Dt_fin_vigencia = reader.GetDateTime(reader.GetOrdinal("dt_fin_vigencia"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_seguro")))
                        reg.Vl_seguro = reader.GetDecimal(reader.GetOrdinal("vl_seguro"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_franquia")))
                        reg.Vl_franquia = reader.GetDecimal(reader.GetOrdinal("vl_franquia"));
                    

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

        public string Gravar(TRegistro_CadSeguroVeiculo val)
        {
            Hashtable hs = new Hashtable(10);
            hs.Add("@P_ID_APOLICE", val.Id_apolice);
            hs.Add("@P_ID_VEICULO", val.Id_veiculo);
            hs.Add("@P_CD_SEGURADORA", val.Cd_seguradora);
            hs.Add("@P_CD_CORRETORA", val.Cd_corretora);
            hs.Add("@P_CD_APOLICE", val.Cd_apolice);
            hs.Add("@P_CD_CI", val.Cd_ci);
            hs.Add("@P_DT_INI_VIGENCIA", val.Dt_ini_vigencia);
            hs.Add("@P_DT_FIN_VIGENCIA", val.Dt_fin_vigencia);
            hs.Add("@P_VL_SEGURO", val.Vl_seguro);
            hs.Add("@P_VL_FRANQUIA", val.Vl_franquia);

            return executarProc("IA_FRT_SEGUROVEICULO", hs);
        }

        public string Excluir(TRegistro_CadSeguroVeiculo val)
        {
            Hashtable hs = new Hashtable(2);
            hs.Add("@P_ID_APOLICE", val.Id_apolice);
            hs.Add("@P_ID_VEICULO", val.Id_veiculo);

            return executarProc("EXCLUI_FRT_SEGUROVEICULO", hs);
        }
    }

    #endregion

    #region Cadastro Seguro Premios

    public class TList_CadSeguroPremios : List<TRegistro_CadSeguroPremios>, IComparer<TRegistro_CadSeguroPremios>
    {

        #region IComparer<TRegistro_CadSeguroPremios> Members
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

        public TList_CadSeguroPremios()
        { }

        public TList_CadSeguroPremios(System.ComponentModel.PropertyDescriptor Prop,
                                System.Windows.Forms.SortOrder Dir)
        {
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_CadSeguroPremios value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_CadSeguroPremios x, TRegistro_CadSeguroPremios y)
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

    
    public class TRegistro_CadSeguroPremios
    {
        private decimal? id_premio;
        
        public decimal? Id_premio
        {
            get { return id_premio; }
            set
            {
                id_premio = value;
                id_premiostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_premiostr;
        
        public string Id_premiostr
        {
            get { return id_premiostr; }
            set
            {
                id_premiostr = value;
                try
                {
                    id_premio = Convert.ToDecimal(value);
                }
                catch
                { id_premio = null; }
            }
        }
        private decimal? id_apolice;
        
        public decimal? Id_apolice
        {
            get { return id_apolice; }
            set
            {
                id_apolice = value;
                id_apolicestr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_apolicestr;
        
        public string Id_apolicestr
        {
            get { return id_apolicestr; }
            set
            {
                id_apolicestr = value;
                try
                {
                    id_apolice = Convert.ToDecimal(value);
                }
                catch
                { id_apolice = null; }
            }
        }
        private decimal? id_veiculo;
        
        public decimal? Id_veiculo
        {
            get { return id_veiculo; }
            set
            {
                id_veiculo = value;
                id_veiculostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_veiculostr;
        
        public string Id_veiculostr
        {
            get { return id_veiculostr; }
            set
            {
                id_veiculostr = value;
                try
                {
                    id_veiculo = Convert.ToDecimal(value);
                }
                catch
                { id_veiculo = null; }
            }
        }
        
        public string Ds_premio
        { get; set; }
        
        public decimal Vl_premio
        { get; set; }
       
        public TRegistro_CadSeguroPremios()
        {   
            Id_premio = null;
            Id_premiostr = string.Empty;
            Id_apolice = null;
            Id_apolicestr = string.Empty;
            Id_veiculo = null;
            Id_veiculostr = string.Empty;
            Ds_premio= string.Empty;
            Vl_premio = decimal.Zero;
            


        }
    }

    public class TCD_CadSeguroPremios : TDataQuery
    {
        public TCD_CadSeguroPremios()
        { }

        public TCD_CadSeguroPremios(BancoDados.TObjetoBanco banco)
        { Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("select " + strTop + " a.id_premio, ");
                sql.AppendLine("a.ID_apolice, a.id_veiculo, a.ds_premio, a.vl_premio ");
                

            }
            else
                sql.AppendLine(" Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from TB_FRT_premios_seguro a ");
            sql.AppendLine("inner join tb_frt_seguroveiculo c ");
            sql.AppendLine("on a.id_apolice = c.id_apolice ");
            sql.AppendLine("and a.id_veiculo = c.id_veiculo ");


            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                    cond = " and ";
                }

            return sql.ToString();
        }

        public override DataTable Buscar(Utils.TpBusca[] vBusca, short vTop)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, string.Empty), null);
        }

        public override DataTable Buscar(Utils.TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo), null);
        }

        public override object BuscarEscalar(Utils.TpBusca[] vBusca, string vNM_Campo)
        {
            return ExecutarBuscaEscalar(SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }

        public TList_CadSeguroPremios Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNm_Campo)
        {
            TList_CadSeguroPremios lista = new TList_CadSeguroPremios();
            SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            try
            {
                reader = ExecutarBusca(SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNm_Campo));
                while (reader.Read())
                {
                    TRegistro_CadSeguroPremios reg = new TRegistro_CadSeguroPremios();

                    if (!reader.IsDBNull(reader.GetOrdinal("id_premio")))
                        reg.Id_premio = reader.GetDecimal(reader.GetOrdinal("id_premio"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_apolice")))
                        reg.Id_apolice = reader.GetDecimal(reader.GetOrdinal("id_apolice"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_veiculo")))
                        reg.Id_veiculo = reader.GetDecimal(reader.GetOrdinal("id_veiculo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_premio")))
                        reg.Ds_premio = reader.GetString(reader.GetOrdinal("ds_premio"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_premio")))
                        reg.Vl_premio = reader.GetDecimal(reader.GetOrdinal("vl_premio"));


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

        public string Gravar(TRegistro_CadSeguroPremios val)
        {
            Hashtable hs = new Hashtable(5);
            hs.Add("@P_ID_PREMIO", val.Id_premio);
            hs.Add("@P_ID_APOLICE", val.Id_apolice);
            hs.Add("@P_ID_VEICULO", val.Id_veiculo);
            hs.Add("@P_DS_PREMIO", val.Ds_premio);
            hs.Add("@P_VL_PREMIO", val.Vl_premio);


            return executarProc("IA_FRT_PREMIOS_SEGURO", hs);
        }

        public string Excluir(TRegistro_CadSeguroPremios val)
        {
            Hashtable hs = new Hashtable(3);
            hs.Add("@P_ID_PREMIO", val.Id_premio);
            hs.Add("@P_ID_APOLICE", val.Id_apolice);
            hs.Add("@P_ID_VEICULO", val.Id_veiculo);

            return executarProc("EXCLUI_FRT_PREMIOS_SEGURO", hs);
        }


    }

    #endregion

    #region Manutencao Veiculo

    public class TList_ManutencaoVeiculo : List<TRegistro_ManutencaoVeiculo>, IComparer<TRegistro_ManutencaoVeiculo>
    {
        #region IComparer<TRegistro_ManutencaoVeiculo> Members
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

        public TList_ManutencaoVeiculo()
        { }

        public TList_ManutencaoVeiculo(System.ComponentModel.PropertyDescriptor Prop,
                                System.Windows.Forms.SortOrder Dir)
        {
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_ManutencaoVeiculo value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_ManutencaoVeiculo x, TRegistro_ManutencaoVeiculo y)
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
    
    public class TRegistro_ManutencaoVeiculo
    {
        private decimal? id_manutencao;
        public decimal? Id_manutencao
        {
            get { return id_manutencao; }
            set
            {
                id_manutencao = value;
                id_manutencaostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_manutencaostr;
        public string Id_manutencaostr
        {
            get { return id_manutencaostr; }
            set
            {
                id_manutencaostr = value;
                try
                {
                    id_manutencao = Convert.ToDecimal(value);
                }
                catch
                { id_manutencao = null; }
            }
        }
        private decimal? id_veiculo;
        public decimal? Id_veiculo
        {
            get { return id_veiculo; }
            set
            {
                id_veiculo = value;
                id_veiculostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_veiculostr;
        public string Id_veiculostr
        {
            get { return id_veiculostr; }
            set
            {
                id_veiculostr = value;
                try
                {
                    id_veiculo = Convert.ToDecimal(value);
                }
                catch
                { id_veiculo = null; }
            }
        }
        public string Ds_veiculo
        { get; set; }
        public string Placa
        { get; set; }
        private decimal? id_despesa;
        public decimal? Id_despesa
        {
            get { return id_despesa; }
            set
            {
                id_despesa = value;
                id_despesastr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_despesastr;
        public string Id_despesastr
        {
            get { return id_despesastr; }
            set
            {
                id_despesastr = value;
                try
                {
                    id_despesa = Convert.ToDecimal(value);
                }
                catch
                { id_despesa = null; }
            }
        }
        public string Ds_despesa
        { get; set; }
        private decimal? id_viagem;
        public decimal? Id_viagem
        {
            get { return id_viagem; }
            set
            {
                id_viagem = value;
                id_viagemstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_viagemstr;
        public string Id_viagemstr
        {
            get { return id_viagemstr; }
            set
            {
                id_viagemstr = value;
                try
                {
                    id_viagem = Convert.ToDecimal(value);
                }
                catch
                { id_viagem = null; }
            }
        }
        public string Ds_viagem
        { get; set; }
        public string Cd_empresa
        { get; set; }
        public string Nm_empresa
        { get; set; }
        public string Cd_cliforResponsavel
        { get; set; }
        public string Nm_cliforresponsavel
        { get; set; }
        public string Cd_cliforOficina
        { get; set; }
        public string Nm_cliforOficina
        { get; set; }
        public string Cpnj_cliforOficina
        { get; set; }
        private decimal? nr_lancto;
        public decimal? Nr_lancto
        {
            get { return nr_lancto; }
            set
            {
                nr_lancto = value;
                nr_lanctostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string nr_lanctostr;
        public string Nr_lanctostr
        {
            get { return nr_lanctostr; }
            set
            {
                nr_lanctostr = value;
                try
                {
                    nr_lancto = decimal.Parse(value);

                }
                catch { nr_lancto = null; }
            }
        }
        private string tp_pagamento;
        public string Tp_pagamento
        {
            get { return tp_pagamento; }
            set
            {
                tp_pagamento = value;
                if (value.Trim().ToUpper().Equals("E"))
                    tipo_pagamento = "EMPRESA";
                else if (value.Trim().ToUpper().Equals("M"))
                    tipo_pagamento = "MOTORISTA";
            }
        }
        private string tipo_pagamento;
        public string Tipo_pagamento
        {
            get { return tipo_pagamento; }
            set
            {
                tipo_pagamento = value;
                if (value.Trim().ToUpper().Equals("EMPRESA"))
                    tp_pagamento = "E";
                else if (value.Trim().ToUpper().Equals("MOTORISTA"))
                    tp_pagamento = "M";
            }
        }
        public string Nr_notafiscal
        { get; set; }
        private DateTime? dt_realizada;
        public DateTime? Dt_realizada
        {
            get { return dt_realizada; }
            set
            {
                dt_realizada = value;
                dt_realizadastr = value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty;
            }
        }
        private string dt_realizadastr;
        public string Dt_realizadastr
        {
            get
            {
                try
                {
                    return Convert.ToDateTime(dt_realizadastr).ToString("dd/MM/yyyy");
                }
                catch
                { return string.Empty; }
            }
            set
            {
                dt_realizadastr = value;
                try
                {
                    dt_realizada = Convert.ToDateTime(value);
                }
                catch
                { dt_realizada = null; }
            }
        }
        public decimal KM_realizada
        { get; set; }
        public decimal Vl_realizada
        {get; set; }
        public string Ds_observacao
        { get; set; }
        public bool St_processar
        { get; set; }
        public CamadaDados.Financeiro.Duplicata.TRegistro_LanDuplicata rDup
        { get; set; }
        public CamadaDados.Financeiro.Duplicata.TList_RegLanDuplicata lDup
        { get; set; }
        public CamadaDados.Almoxarifado.TList_Movimentacao lMov
        { get; set; }
        public CamadaDados.Almoxarifado.TList_Movimentacao lMovDel
        { get; set; }
        public CamadaDados.Financeiro.CCustoLan.TList_LanCCustoLancto lCCusto
        { get; set; }

        public TRegistro_ManutencaoVeiculo()
        {
            id_manutencao = null;
            id_manutencaostr = string.Empty;
            Id_veiculo = null;
            Id_veiculostr = string.Empty;
            Ds_veiculo = string.Empty;
            Placa = string.Empty;
            id_despesa = null;
            id_despesastr = string.Empty;
            Ds_despesa = string.Empty;
            id_viagem = null;
            id_viagemstr = string.Empty;
            Ds_viagem = string.Empty;
            Cd_empresa = string.Empty;
            Nm_empresa = string.Empty;
            Cd_cliforResponsavel = string.Empty;
            Nm_cliforresponsavel = string.Empty;
            Cd_cliforOficina = string.Empty;
            Nm_cliforOficina = string.Empty;
            Cpnj_cliforOficina = string.Empty;
            nr_lancto = null;
            nr_lanctostr = string.Empty;
            tp_pagamento = "E";
            tipo_pagamento = "EMPRESA";
            Nr_notafiscal = string.Empty;
            dt_realizada = null;
            dt_realizadastr = string.Empty;
            KM_realizada = decimal.Zero;
            Vl_realizada = decimal.Zero;
            Ds_observacao = string.Empty;
            St_processar = false;
            rDup = null;
            lMov = new CamadaDados.Almoxarifado.TList_Movimentacao();
            lMovDel = new CamadaDados.Almoxarifado.TList_Movimentacao();
            lCCusto = new CamadaDados.Financeiro.CCustoLan.TList_LanCCustoLancto();
            lDup = new CamadaDados.Financeiro.Duplicata.TList_RegLanDuplicata();
        }
    }

    public class TCD_ManutencaoVeiculo : TDataQuery
    {
        public TCD_ManutencaoVeiculo()
        { }

        public TCD_ManutencaoVeiculo(BancoDados.TObjetoBanco banco)
        { Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("select " + strTop + " a.id_manutencao, b.placa, a.nr_notafiscal, a.TP_Pagamento, ");
                sql.AppendLine("a.id_veiculo, b.ds_veiculo, a.id_despesa, c.ds_despesa, a.id_viagem, ");
                sql.AppendLine("d.ds_viagem, a.cd_empresa, e.nm_empresa, ");
                sql.AppendLine("a.cd_cliforResponsavel, f.nm_clifor as nm_cliforResponsavel, a.cd_cliforOficina, ");
                sql.AppendLine("g.nm_clifor as nm_cliforOficina, h.nr_cgc as cnpj_cliforOficina, a.nr_lancto, a.dt_realizada, a.km_realizada, ");
                sql.AppendLine("a.vl_realizada, a.ds_observacao ");


            }
            else
                sql.AppendLine(" Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from TB_FRT_manutencaoveiculo a ");
            sql.AppendLine("inner join tb_frt_veiculo b ");
            sql.AppendLine("on a.id_veiculo = b.id_veiculo ");
            sql.AppendLine("inner join tb_frt_despesa c ");
            sql.AppendLine("on a.id_despesa = c.id_despesa ");
            sql.AppendLine("left outer join tb_frt_viagem d ");
            sql.AppendLine("on a.id_viagem = d.id_viagem ");
            sql.AppendLine("inner join tb_div_empresa e ");
            sql.AppendLine("on a.cd_empresa = e.cd_empresa ");
            sql.AppendLine("left outer join tb_fin_clifor f ");
            sql.AppendLine("on a.cd_cliforResponsavel = f.cd_clifor ");
            sql.AppendLine("left outer join tb_fin_clifor g ");
            sql.AppendLine("on a.cd_cliforOficina = g.cd_clifor ");
            sql.AppendLine("left outer join tb_fin_clifor_pj h");
            sql.AppendLine("on g.cd_clifor = h.cd_clifor");

            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                    cond = " and ";
                }

            return sql.ToString();
        }

        public override DataTable Buscar(Utils.TpBusca[] vBusca, short vTop)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, string.Empty), null);
        }

        public override DataTable Buscar(Utils.TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo), null);
        }

        public override object BuscarEscalar(Utils.TpBusca[] vBusca, string vNM_Campo)
        {
            return ExecutarBuscaEscalar(SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }

        public TList_ManutencaoVeiculo Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNm_Campo)
        {
            TList_ManutencaoVeiculo lista = new TList_ManutencaoVeiculo();
            SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            try
            {
                reader = ExecutarBusca(SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNm_Campo));
                while (reader.Read())
                {
                    TRegistro_ManutencaoVeiculo reg = new TRegistro_ManutencaoVeiculo();

                    if (!reader.IsDBNull(reader.GetOrdinal("id_manutencao")))
                        reg.Id_manutencao = reader.GetDecimal(reader.GetOrdinal("id_manutencao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_veiculo")))
                        reg.Id_veiculo = reader.GetDecimal(reader.GetOrdinal("id_veiculo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_veiculo")))
                        reg.Ds_veiculo = reader.GetString(reader.GetOrdinal("ds_veiculo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("placa")))
                        reg.Placa = reader.GetString(reader.GetOrdinal("placa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_despesa")))
                        reg.Id_despesa = reader.GetDecimal(reader.GetOrdinal("id_despesa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_despesa")))
                        reg.Ds_despesa = reader.GetString(reader.GetOrdinal("ds_despesa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_viagem")))
                        reg.Id_viagem = reader.GetDecimal(reader.GetOrdinal("id_viagem"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_viagem")))
                        reg.Ds_viagem = reader.GetString(reader.GetOrdinal("ds_viagem"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_empresa")))
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("nm_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_cliforResponsavel")))
                        reg.Cd_cliforResponsavel = reader.GetString(reader.GetOrdinal("cd_cliforResponsavel"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_cliforResponsavel")))
                        reg.Nm_cliforresponsavel = reader.GetString(reader.GetOrdinal("nm_cliforResponsavel"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_cliforOficina")))
                        reg.Cd_cliforOficina = reader.GetString(reader.GetOrdinal("cd_cliforOficina"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_cliforOficina")))
                        reg.Nm_cliforOficina = reader.GetString(reader.GetOrdinal("nm_cliforOficina"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_lancto")))
                        reg.Nr_lancto = reader.GetDecimal(reader.GetOrdinal("nr_lancto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("TP_Pagamento")))
                        reg.Tp_pagamento = reader.GetString(reader.GetOrdinal("TP_Pagamento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_notafiscal")))
                        reg.Nr_notafiscal = reader.GetString(reader.GetOrdinal("nr_notafiscal"));
                    if (!reader.IsDBNull(reader.GetOrdinal("dt_realizada")))
                        reg.Dt_realizada = reader.GetDateTime(reader.GetOrdinal("dt_realizada"));
                    if (!reader.IsDBNull(reader.GetOrdinal("km_realizada")))
                        reg.KM_realizada = reader.GetDecimal(reader.GetOrdinal("km_realizada"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_realizada")))
                        reg.Vl_realizada = reader.GetDecimal(reader.GetOrdinal("vl_realizada"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_observacao")))
                        reg.Ds_observacao = reader.GetString(reader.GetOrdinal("ds_observacao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cnpj_cliforOficina")))
                        reg.Cpnj_cliforOficina = reader.GetString(reader.GetOrdinal("cnpj_cliforOficina"));

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

        public string Gravar(TRegistro_ManutencaoVeiculo val)
        {
            Hashtable hs = new Hashtable(14);

            hs.Add("@P_ID_MANUTENCAO", val.Id_manutencao);
            hs.Add("@P_ID_VEICULO", val.Id_veiculo);
            hs.Add("@P_ID_DESPESA", val.Id_despesa);
            hs.Add("@P_ID_VIAGEM", val.Id_viagem);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_CD_CLIFORRESPONSAVEL", val.Cd_cliforResponsavel);
            hs.Add("@P_CD_CLIFOROFICINA", val.Cd_cliforOficina);
            hs.Add("@P_NR_LANCTO", val.Nr_lancto);
            hs.Add("@P_TP_PAGAMENTO", val.Tp_pagamento);
            hs.Add("@P_NR_NOTAFISCAL", val.Nr_notafiscal);
            hs.Add("@P_DT_REALIZADA", val.Dt_realizada);
            hs.Add("@P_KM_REALIZADA", val.KM_realizada);
            hs.Add("@P_VL_REALIZADA", val.Vl_realizada);
            hs.Add("@P_DS_OBSERVACAO", val.Ds_observacao);

            return executarProc("IA_FRT_MANUTENCAOVEICULO", hs);
        }

        public string Excluir(TRegistro_ManutencaoVeiculo val)
        {
            Hashtable hs = new Hashtable(2);
            hs.Add("@P_ID_MANUTENCAO", val.Id_manutencao);
            hs.Add("@P_ID_VEICULO", val.Id_veiculo);

            return executarProc("EXCLUI_FRT_MANUTENCAOVEICULO", hs);
        }
    }

    #endregion

    #region Manutencao X CCusto
    public class TList_ManutFrota_X_CCusto : List<TRegistro_ManutFrota_X_CCusto> { }

    public class TRegistro_ManutFrota_X_CCusto
    {
        private decimal? id_manutencao;
        public decimal? Id_manutencao
        {
            get { return id_manutencao; }
            set
            {
                id_manutencao = value;
                id_manutencaostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_manutencaostr;
        public string Id_manutencaostr
        {
            get { return id_manutencaostr; }
            set
            {
                id_manutencaostr = value;
                try
                {
                    id_manutencao = decimal.Parse(value);
                }
                catch { id_manutencao = null; }
            }
        }
        private decimal? id_veiculo;
        public decimal? Id_veiculo
        {
            get { return id_veiculo; }
            set
            {
                id_veiculo = value;
                id_veiculostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_veiculostr;
        public string Id_veiculostr
        {
            get { return id_veiculostr; }
            set
            {
                id_veiculostr = value;
                try
                {
                    id_veiculo = decimal.Parse(value);
                }
                catch { id_veiculo = null; }
            }
        }
        private decimal? id_ccustolan;
        public decimal? Id_ccustolan
        {
            get { return id_ccustolan; }
            set
            {
                id_ccustolan = value;
                id_ccustolanstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_ccustolanstr;
        public string Id_ccustolanstr
        {
            get { return id_ccustolanstr; }
            set
            {
                id_ccustolanstr = value;
                try
                {
                    id_ccustolan = decimal.Parse(value);
                }
                catch { id_ccustolan = null; }
            }
        }

        public TRegistro_ManutFrota_X_CCusto()
        {
            id_manutencao = null;
            id_manutencaostr = string.Empty;
            id_veiculo = null;
            id_veiculostr = string.Empty;
            id_ccustolan = null;
            id_ccustolanstr = string.Empty;
        }
    }

    public class TCD_ManutFrota_X_CCusto : TDataQuery
    {
        public TCD_ManutFrota_X_CCusto() { }

        public TCD_ManutFrota_X_CCusto(BancoDados.TObjetoBanco banco) { Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
                sql.AppendLine("select " + strTop + " a.id_manutencao, a.id_veiculo, a.id_ccustolan ");
            else
                sql.AppendLine(" Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from TB_FIN_ManutFrota_X_CCusto a ");

            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                    cond = " and ";
                }

            return sql.ToString();
        }

        public override DataTable Buscar(Utils.TpBusca[] vBusca, short vTop)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, string.Empty), null);
        }

        public override DataTable Buscar(Utils.TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo), null);
        }

        public override object BuscarEscalar(Utils.TpBusca[] vBusca, string vNM_Campo)
        {
            return ExecutarBuscaEscalar(SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }

        public TList_ManutFrota_X_CCusto Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNm_Campo)
        {
            TList_ManutFrota_X_CCusto lista = new TList_ManutFrota_X_CCusto();
            SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            try
            {
                reader = ExecutarBusca(SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNm_Campo));
                while (reader.Read())
                {
                    TRegistro_ManutFrota_X_CCusto reg = new TRegistro_ManutFrota_X_CCusto();
                    if (!reader.IsDBNull(reader.GetOrdinal("id_manutencao")))
                        reg.Id_manutencao = reader.GetDecimal(reader.GetOrdinal("id_manutencao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_veiculo")))
                        reg.Id_veiculo = reader.GetDecimal(reader.GetOrdinal("id_veiculo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_ccustolan")))
                        reg.Id_ccustolan = reader.GetDecimal(reader.GetOrdinal("id_ccustolan"));
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

        public string Gravar(TRegistro_ManutFrota_X_CCusto val)
        {
            Hashtable hs = new Hashtable(3);
            hs.Add("@P_ID_MANUTENCAO", val.Id_manutencao);
            hs.Add("@P_ID_VEICULO", val.Id_veiculo);
            hs.Add("@P_ID_CCUSTOLAN", val.Id_ccustolan);

            return executarProc("IA_FIN_MANUTFROTA_X_CCUSTO", hs);
        }

        public string Excluir(TRegistro_ManutFrota_X_CCusto val)
        {
            Hashtable hs = new Hashtable(3);
            hs.Add("@P_ID_MANUTENCAO", val.Id_manutencao);
            hs.Add("@P_ID_VEICULO", val.Id_veiculo);
            hs.Add("@P_ID_CCUSTOLAN", val.Id_ccustolan);

            return executarProc("EXCLUI_FIN_MANUTFROTA_X_CCUSTO", hs);
        }
    }
    #endregion

    #region Infracoes

    public class TList_Infracoes : List<TRegistro_Infracoes>, IComparer<TRegistro_Infracoes>
    {
        #region IComparer<TRegistro_Infracoes> Members
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

        public TList_Infracoes()
        { }

        public TList_Infracoes(System.ComponentModel.PropertyDescriptor Prop,
                                System.Windows.Forms.SortOrder Dir)
        {
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_Infracoes value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_Infracoes x, TRegistro_Infracoes y)
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
    
    public class TRegistro_Infracoes
    {
        private decimal? id_infracao;
        public decimal? Id_infracao
        {
            get { return id_infracao; }
            set
            {
                id_infracao = value;
                id_infracaostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_infracaostr;
        public string Id_infracaostr
        {
            get { return id_infracaostr; }
            set
            {
                id_infracaostr = value;
                try
                {
                    id_infracao = Convert.ToDecimal(value);
                }
                catch
                { id_infracao = null; }
            }
        }
        private decimal? id_veiculo;
        public decimal? Id_veiculo
        {
            get { return id_veiculo; }
            set
            {
                id_veiculo = value;
                id_veiculostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_veiculostr;
        public string Id_veiculostr
        {
            get { return id_veiculostr; }
            set
            {
                id_veiculostr = value;
                try
                {
                    id_veiculo = Convert.ToDecimal(value);
                }
                catch
                { id_veiculo = null; }
            }
        }
        public string Ds_veiculo
        { get; set; }
        public string Placa
        { get; set; }
        public string Cd_motorista
        { get; set; }
        public string Nm_motorista
        { get; set; }
        private decimal? id_viagem;
        public decimal? Id_viagem
        {
            get { return id_viagem; }
            set
            {
                id_viagem = value;
                id_viagemstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_viagemstr;
        public string Id_viagemstr
        {
            get { return id_viagemstr; }
            set
            {
                id_viagemstr = value;
                try
                {
                    id_viagem = Convert.ToDecimal(value);
                }
                catch
                { id_viagem = null; }
            }
        }
        public string Ds_viagem
        { get; set; }
        public string Cd_empresa
        { get; set; }
        public string Nm_empresa
        { get; set; }
        private decimal? id_despesa;
        public decimal? Id_despesa
        {
            get { return id_despesa; }
            set
            {
                id_despesa = value;
                id_despesastr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_despesastr;
        public string Id_despesastr
        {
            get { return id_despesastr; }
            set
            {
                id_despesastr = value;
                try
                {
                    id_despesa = decimal.Parse(value);
                }
                catch
                { id_despesa = null; }
            }
        }
        public string Ds_despesa
        { get; set; }
        private decimal? nr_lancto;
        public decimal? Nr_lancto
        {
            get { return nr_lancto; }
            set
            {
                nr_lancto = value;
                nr_lanctostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string nr_lanctostr;
        public string Nr_lanctostr
        {
            get { return nr_lanctostr; }
            set
            {
                nr_lanctostr = value;
                try
                {
                    nr_lancto = decimal.Parse(value);
                }
                catch { nr_lancto = null; }
            }
        }
        public string Cd_infracao
        { get; set; }
        public string Ds_infracao
        { get; set; }
        public string Tp_gravidade
        { get; set; }
        public string Gravidade
        {
            get
            {
                if (Tp_gravidade.Trim().ToUpper().Equals("L"))
                    return "LEVE";
                else if (Tp_gravidade.Trim().ToUpper().Equals("M"))
                    return "MEDIA";
                else if (Tp_gravidade.Trim().ToUpper().Equals("G"))
                    return "GRAVE";
                else if (Tp_gravidade.Trim().ToUpper().Equals("V"))
                    return "GRAVISSIMA";
                else return string.Empty;
            }
        }
        private DateTime? dt_infracao;
        public DateTime? Dt_infracao
        {
            get { return dt_infracao; }
            set
            {
                dt_infracao = value;
                dt_infracaostr = value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty;
            }
        }
        private string dt_infracaostr;
        public string Dt_infracaostr
        {
            get
            {
                try
                {
                    return Convert.ToDateTime(dt_infracaostr).ToString("dd/MM/yyyy");
                }
                catch
                { return string.Empty; }
            }
            set
            {
                dt_infracaostr = value;
                try
                {
                    dt_infracao = Convert.ToDateTime(value);
                }
                catch
                { dt_infracao = null; }
            }
        }
        private DateTime? dt_vencimento;
        public DateTime? Dt_vencimento
        {
            get { return dt_vencimento; }
            set
            {
                dt_vencimento = value;
                dt_vencimentostr = value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty;
            }
        }
        private string dt_vencimentostr;
        public string Dt_vencimentostr
        {
            get
            {
                try
                {
                    return Convert.ToDateTime(dt_vencimentostr).ToString("dd/MM/yyyy");
                }
                catch
                { return string.Empty; }
            }
            set
            {
                dt_vencimentostr = value;
                try
                {
                    dt_vencimento = Convert.ToDateTime(value);
                }
                catch
                { dt_vencimento= null; }
            }
        }
        public decimal Vl_infracao
        { get; set; }
        public string Ds_observacao
        { get; set; }
        public CamadaDados.Financeiro.Duplicata.TRegistro_LanDuplicata rDup
        { get; set; }

        public TRegistro_Infracoes()
        {
            id_infracao = null;
            id_infracaostr = string.Empty;
            Id_veiculo = null;
            Id_veiculostr = string.Empty;
            Ds_veiculo = string.Empty;
            Placa = string.Empty;
            id_viagem = null;
            id_viagemstr = string.Empty;
            Ds_viagem = string.Empty;
            Cd_empresa = string.Empty;
            Nm_empresa = string.Empty;
            id_despesa = null;
            id_despesastr = string.Empty;
            Ds_despesa = string.Empty;
            nr_lancto = null;
            nr_lanctostr = string.Empty;
            Cd_infracao = string.Empty;
            Ds_infracao = string.Empty;
            Tp_gravidade = null;
            dt_infracao = null;
            dt_infracaostr = string.Empty;
            dt_vencimento = null;
            dt_vencimentostr = string.Empty;
            Vl_infracao = decimal.Zero;
            Ds_observacao = string.Empty;
            rDup = null;
        }
    }

    public class TCD_Infracoes : TDataQuery
    {
        public TCD_Infracoes()
        { }

        public TCD_Infracoes(BancoDados.TObjetoBanco banco)
        { Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("select " + strTop + " a.id_infracao, ");
                sql.AppendLine("a.id_veiculo, b.ds_veiculo, b.placa, a.cd_motorista, c.nm_clifor as nm_motorista, a.id_viagem, d.ds_viagem, a.cd_empresa, e.nm_empresa, ");
                sql.AppendLine("a.cd_infracao, a.ds_infracao, a.tp_gravidade, a.dt_infracao, a.dt_vencimento, ");
                sql.AppendLine("a.vl_infracao, a.ds_observacao, ");
                sql.AppendLine("a.id_despesa, f.ds_despesa, a.nr_lancto ");
            }
            else
                sql.AppendLine(" Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from TB_FRT_infracoes a ");
            sql.AppendLine("inner join tb_frt_veiculo b ");
            sql.AppendLine("on a.id_veiculo = b.id_veiculo ");
            sql.AppendLine("left outer join vtb_fin_clifor c ");
            sql.AppendLine("on a.cd_motorista = c.cd_clifor ");
            sql.AppendLine("left outer join tb_frt_viagem d ");
            sql.AppendLine("on a.id_viagem = d.id_viagem ");
            sql.AppendLine("inner join tb_div_empresa e ");
            sql.AppendLine("on a.cd_empresa = e.cd_empresa ");
            sql.AppendLine("inner join tb_frt_despesa f ");
            sql.AppendLine("on a.id_despesa = f.id_despesa ");

            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                    cond = " and ";
                }

            return sql.ToString();
        }

        public override DataTable Buscar(Utils.TpBusca[] vBusca, short vTop)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, string.Empty), null);
        }

        public override DataTable Buscar(Utils.TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo), null);
        }

        public override object BuscarEscalar(Utils.TpBusca[] vBusca, string vNM_Campo)
        {
            return ExecutarBuscaEscalar(SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }

        public TList_Infracoes Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNm_Campo)
        {
            TList_Infracoes lista = new TList_Infracoes();
            SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            try
            {
                reader = ExecutarBusca(SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNm_Campo));
                while (reader.Read())
                {
                    TRegistro_Infracoes reg = new TRegistro_Infracoes();

                    if (!reader.IsDBNull(reader.GetOrdinal("id_infracao")))
                        reg.Id_infracao = reader.GetDecimal(reader.GetOrdinal("id_infracao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_veiculo")))
                        reg.Id_veiculo = reader.GetDecimal(reader.GetOrdinal("id_veiculo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_veiculo")))
                        reg.Ds_veiculo = reader.GetString(reader.GetOrdinal("ds_veiculo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("placa")))
                        reg.Placa = reader.GetString(reader.GetOrdinal("placa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_motorista")))
                        reg.Cd_motorista = reader.GetString(reader.GetOrdinal("cd_motorista"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_motorista")))
                        reg.Nm_motorista = reader.GetString(reader.GetOrdinal("nm_motorista"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_viagem")))
                        reg.Id_viagem = reader.GetDecimal(reader.GetOrdinal("id_viagem"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_viagem")))
                        reg.Ds_viagem = reader.GetString(reader.GetOrdinal("ds_viagem"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_empresa")))
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("nm_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_despesa")))
                        reg.Id_despesa = reader.GetDecimal(reader.GetOrdinal("id_despesa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_despesa")))
                        reg.Ds_despesa = reader.GetString(reader.GetOrdinal("ds_despesa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_lancto")))
                        reg.Nr_lancto = reader.GetDecimal(reader.GetOrdinal("nr_lancto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_infracao")))
                        reg.Cd_infracao = reader.GetString(reader.GetOrdinal("cd_infracao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_infracao")))
                        reg.Ds_infracao = reader.GetString(reader.GetOrdinal("ds_infracao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_gravidade")))
                        reg.Tp_gravidade = reader.GetString(reader.GetOrdinal("tp_gravidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("dt_infracao")))
                        reg.Dt_infracao = reader.GetDateTime(reader.GetOrdinal("dt_infracao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("dt_vencimento")))
                        reg.Dt_vencimento = reader.GetDateTime(reader.GetOrdinal("dt_vencimento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_infracao")))
                        reg.Vl_infracao = reader.GetDecimal(reader.GetOrdinal("vl_infracao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_observacao")))
                        reg.Ds_observacao = reader.GetString(reader.GetOrdinal("ds_observacao"));

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

        public string Gravar(TRegistro_Infracoes val)
        {
            Hashtable hs = new Hashtable(14);

            hs.Add("@P_ID_INFRACAO", val.Id_infracao);
            hs.Add("@P_ID_VEICULO", val.Id_veiculo);
            hs.Add("@P_CD_MOTORISTA", val.Cd_motorista);
            hs.Add("@P_ID_VIAGEM", val.Id_viagem);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_DESPESA", val.Id_despesa);
            hs.Add("@P_NR_LANCTO", val.Nr_lancto);
            hs.Add("@P_CD_INFRACAO", val.Cd_infracao);
            hs.Add("@P_DS_INFRACAO", val.Ds_infracao);
            hs.Add("@P_TP_GRAVIDADE", val.Tp_gravidade);
            hs.Add("@P_DT_INFRACAO", val.Dt_infracao);
            hs.Add("@P_DT_VENCIMENTO", val.Dt_vencimento);
            hs.Add("@P_VL_INFRACAO", val.Vl_infracao);
            hs.Add("@P_DS_OBSERVACAO", val.Ds_observacao);

            return executarProc("IA_FRT_INFRACOES", hs);
        }

        public string Excluir(TRegistro_Infracoes val)
        {
            Hashtable hs = new Hashtable(2);
            hs.Add("@P_ID_INFRACAO", val.Id_infracao);
            hs.Add("@P_ID_VEICULO", val.Id_veiculo);

            return executarProc("EXCLUI_FRT_INFRACOES", hs);
        }
    }

    #endregion

    #region Despesas Veiculo

    public class TList_DespesasVeiculo : List<TRegistro_DespesasVeiculo>, IComparer<TRegistro_DespesasVeiculo>
    {

        #region IComparer<TRegistro_DespesasVeiculo> Members
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

        public TList_DespesasVeiculo()
        { }

        public TList_DespesasVeiculo(System.ComponentModel.PropertyDescriptor Prop,
                                System.Windows.Forms.SortOrder Dir)
        {
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_DespesasVeiculo value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_DespesasVeiculo x, TRegistro_DespesasVeiculo y)
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

    public class TRegistro_DespesasVeiculo
    {
        private decimal? id_despveiculo
        { get; set; }

        public decimal? Id_despveiculo
        {
            get { return id_despveiculo; }
            set
            {
                id_despveiculo = value;
                id_despveiculostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_despveiculostr;

        public string Id_despveiculostr
        {
            get { return id_despveiculostr; }
            set
            {
                id_despveiculostr = value;
                try
                {
                    id_despveiculo = Convert.ToDecimal(value);
                }
                catch
                { id_despveiculo = null; }
            }
        }
        public string Cd_empresa
        { get; set; }
        public string Nm_empresa
        { get; set; }
        private decimal? id_viagem;

        public decimal? Id_viagem
        {
            get { return id_viagem; }
            set
            {
                id_viagem = value;
                id_viagemstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_viagemstr;

        public string Id_viagemstr
        {
            get { return id_viagemstr; }
            set
            {
                id_viagemstr = value;
                try
                {
                    id_viagem = Convert.ToDecimal(value);
                }
                catch
                { id_viagem = null; }
            }
        }
        public string Cd_clifor
        { get; set; }
        public string Nm_clifor
        { get; set; }
        private decimal? id_veiculo;

        public decimal? Id_veiculo
        {
            get { return id_veiculo; }
            set
            {
                id_veiculo = value;
                id_veiculostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_veiculostr;

        public string Id_veiculostr
        {
            get { return id_veiculostr; }
            set
            {
                id_veiculostr = value;
                try
                {
                    id_veiculo = Convert.ToDecimal(value);
                }
                catch
                { id_veiculo = null; }
            }
        }

        public string Ds_veiculo
        { get; set; }

        public string Placa
        { get; set; }
        private decimal? id_despesa;

        public decimal? Id_despesa
        {
            get { return id_despesa; }
            set
            {
                id_despesa = value;
                id_despesastr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_despesastr;

        public string Id_despesastr
        {
            get { return id_despesastr; }
            set
            {
                id_despesastr = value;
                try
                {
                    id_despesa = Convert.ToDecimal(value);
                }
                catch
                { id_despesa = null; }
            }
        }

        public string Ds_despesa
        { get; set; }
        private DateTime? dt_despesa;

        public DateTime? Dt_despesa
        {
            get { return dt_despesa; }
            set
            {
                dt_despesa = value;
                dt_despesastr = value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty;
            }
        }
        private string dt_despesastr;
        public string Dt_despesastr
        {
            get
            {
                try
                {
                    return Convert.ToDateTime(dt_despesastr).ToString("dd/MM/yyyy");
                }
                catch
                { return string.Empty; }
            }
            set
            {
                dt_despesastr = value;
                try
                {
                    dt_despesa = Convert.ToDateTime(value);
                }
                catch
                { dt_despesa = null; }
            }
        }       
        public decimal Vl_despesas
        { get; set; }


        public TRegistro_DespesasVeiculo()
        {
            id_despveiculo = null;
            id_despesastr = string.Empty;
            Cd_empresa = string.Empty;
            Nm_empresa = string.Empty;
            id_viagem = null;
            id_viagemstr = string.Empty;
            Cd_clifor = string.Empty;
            Nm_clifor = string.Empty;
            Id_veiculo = null;
            Id_veiculostr = string.Empty;
            Ds_veiculo = string.Empty;
            Placa = string.Empty;
            id_despesa = null;
            id_despesastr = string.Empty;
            Ds_despesa = string.Empty;
            dt_despesa = DateTime.Now;
            dt_despesastr = DateTime.Now.ToString("dd/MM/yyyy");
            Vl_despesas = decimal.Zero;
        }
    }

    public class TCD_DespesasVeiculo : TDataQuery
    {
        public TCD_DespesasVeiculo()
        { }

        public TCD_DespesasVeiculo(BancoDados.TObjetoBanco banco)
        { Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("select " + strTop + " a.ID_DESPVEICULO, a.CD_EMPRESA, a.NM_EMPRESA, a.id_viagem, ");
                sql.AppendLine("a.CD_CLIFOR, a.NM_CLIFOR, a.ID_VEICULO, a.DS_VEICULO, a.PLACA, a.ID_DESPESA, ");
                sql.AppendLine("a.DS_DESPESA, a.DT_DESPESA, a.VL_DESPESAS ");
            }
            else
                sql.AppendLine(" Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from VTB_FRT_DESPESASVEICULO a ");


            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                    cond = " and ";
                }

            return sql.ToString();
        }

        public override DataTable Buscar(Utils.TpBusca[] vBusca, short vTop)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, string.Empty), null);
        }

        public override DataTable Buscar(Utils.TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo), null);
        }

        public override object BuscarEscalar(Utils.TpBusca[] vBusca, string vNM_Campo)
        {
            return ExecutarBuscaEscalar(SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }

        public TList_DespesasVeiculo Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNm_Campo)
        {
            TList_DespesasVeiculo lista = new TList_DespesasVeiculo();
            SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            try
            {
                reader = ExecutarBusca(SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNm_Campo));
                while (reader.Read())
                {
                    TRegistro_DespesasVeiculo reg = new TRegistro_DespesasVeiculo();

                    if (!reader.IsDBNull(reader.GetOrdinal("ID_DESPVEICULO")))
                        reg.Id_despveiculo = reader.GetDecimal(reader.GetOrdinal("ID_DESPVEICULO"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_empresa")))
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("nm_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_viagem")))
                        reg.Id_viagem = reader.GetDecimal(reader.GetOrdinal("id_viagem"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_clifor")))
                        reg.Cd_clifor = reader.GetString(reader.GetOrdinal("cd_clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_clifor")))
                        reg.Nm_clifor = reader.GetString(reader.GetOrdinal("nm_clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_veiculo")))
                        reg.Id_veiculo = reader.GetDecimal(reader.GetOrdinal("id_veiculo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_veiculo")))
                        reg.Ds_veiculo = reader.GetString(reader.GetOrdinal("ds_veiculo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("placa")))
                        reg.Placa = reader.GetString(reader.GetOrdinal("placa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_despesa")))
                        reg.Id_despesa = reader.GetDecimal(reader.GetOrdinal("id_despesa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_despesa")))
                        reg.Ds_despesa = reader.GetString(reader.GetOrdinal("ds_despesa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DT_DESPESA")))
                        reg.Dt_despesa = reader.GetDateTime(reader.GetOrdinal("DT_DESPESA"));
                    if (!reader.IsDBNull(reader.GetOrdinal("VL_DESPESAS")))
                        reg.Vl_despesas = reader.GetDecimal(reader.GetOrdinal("VL_DESPESAS"));


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
    }

    #endregion
}

   

