using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Utils;
using System.Collections;
using System.Data.SqlClient;

namespace CamadaDados.Fazenda.Lancamento
{
    public class TList_LanAtividade : List<TRegistro_LanAtividade> { }

    
    public class TRegistro_LanAtividade
    {
        
        public decimal? Id_lanctoativ
        {
            get;
            set;
        }
      
        private decimal? cd_fazenda;
        
        public decimal? Cd_fazenda
        {
            get { return cd_fazenda; }
            set 
            {
                cd_fazenda = value;
                cd_fazendastr = value.Value.ToString();
            }
        }
        private string cd_fazendastr;
        
        public string Cd_fazendastr
        {
            get { return cd_fazendastr; }
            set 
            {
                cd_fazendastr = value;
                try
                {
                    cd_fazenda = Convert.ToDecimal(value);
                }
                catch
                { cd_fazenda = null; }
            }
        }
        
        public string Nm_fazenda{ get;set;}

        private decimal? cd_talhao;
        
        public decimal? Cd_talhao
        {
            get {
                return cd_talhao;
            }
            set 
            {
                cd_talhao = value;
                cd_talhaostr = value.Value.ToString();
            }
        }
        private string cd_talhaostr;
        
        public string Cd_talhaostr
        {
            get { 
                return cd_talhaostr;
            }
            set 
            {
                cd_talhaostr = value;
                try
                {
                    cd_talhao = Convert.ToDecimal(value);
                }
                catch
                { cd_talhao = null; }
            }
        }
        
        public string Nm_talhao {get; set;}
        
        public string AnoSafra {get;set;}
        
        public string DS_Safra {get;set;}
        
        private decimal? cd_plantio;
        
        public decimal? Cd_plantio
        {
            get { return cd_plantio; }
            set
            {
                cd_plantio = value;
                cd_plantiostr = value.Value.ToString();
            }
        
        }
        private string cd_plantiostr;
        
        public string Ds_plantio { get; set; }

        private decimal? id_atividade;
        
        public decimal? Id_atividade
        {
            get { return id_atividade; }
            set
            {
                id_atividade = value;
                id_atividadestr = value.Value.ToString();
            }
        }
        private string id_atividadestr;
        
        public string Id_atividadestr
        {
            get { return id_atividadestr; }
            set
            {
                id_atividadestr = value;
                try
                {
                    id_atividade = Convert.ToDecimal(value);
                }
                catch
                { id_atividade = null; }
            }
        }
        
        public string Ds_atividade
        { get; set; }
        
        public TList_LanAtividade_Item Litens { get; set; }
        
        public TList_LanAtividade_Item LitensDel { get; set; }
        
        public DateTime dt_ini
        { get; set;}
        
        public DateTime dt_fim
        { get; set; }



        public TRegistro_LanAtividade()
        {
            this.Id_lanctoativ = null;
            this.cd_fazenda = null;
            this.cd_fazendastr = string.Empty;
            this.Nm_fazenda = string.Empty;
            this.cd_talhao = null;
            this.cd_plantiostr = null;
            this.cd_talhaostr = string.Empty;
            this.Nm_talhao = string.Empty;
            this.AnoSafra = string.Empty;
            this.DS_Safra = string.Empty;
            this.id_atividade = null;
            this.id_atividadestr = string.Empty;
            this.Ds_atividade = string.Empty;
            this.dt_ini = DateTime.Now;
            this.dt_fim = DateTime.Now;
            this.Litens = new TList_LanAtividade_Item();
            this.LitensDel = new TList_LanAtividade_Item();
        }
    }

    public class TCD_LanAtividade : TDataQuery
    {
        public TCD_LanAtividade()
        { }

        public TCD_LanAtividade(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = "";
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();

            if (vNM_Campo.Length == 0)
            {
                sql.AppendLine(" SELECT " + strTop + "a.id_lanctoativ, a.cd_fazenda, b.nm_fazenda, ");
                sql.AppendLine("a.cd_talhao, c.nm_talhao, a.anosafra,a.cd_plantio,p.ds_produto as ds_plantio, d.ds_safra, a.id_atividade, e.ds_atividade, a.dt_ini, a.dt_fim");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("FROM tb_faz_lanatividade a ");
            sql.AppendLine("inner join TB_FAZ_FAZENDA b ");
            sql.AppendLine("on a.cd_fazenda = b.cd_fazenda ");
            sql.AppendLine("inner join tb_faz_talhoes c ");
            sql.AppendLine("on a.cd_fazenda = c.cd_fazenda ");
            sql.AppendLine("and a.cd_talhao = c.cd_talhao ");
            sql.AppendLine("inner join tb_gro_safra d ");
            sql.AppendLine("on a.anosafra = d.anosafra ");
            sql.AppendLine("inner join tb_faz_atividade e ");
            sql.AppendLine("on a.id_atividade = e.id_atividade ");
            sql.AppendLine("inner join tb_est_produto p ");
            sql.AppendLine("on a.cd_plantio = p.cd_produto");
            
            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.Append(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                    cond = " and ";
                }
            sql.Append(" Order by a.id_lanctoativ asc ");
            return sql.ToString();
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, ""), null);
        }

        public TList_LanAtividade Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_LanAtividade lista = new TList_LanAtividade();
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
                    TRegistro_LanAtividade reg = new TRegistro_LanAtividade();
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_LanctoAtiv")))
                        reg.Id_lanctoativ = reader.GetDecimal(reader.GetOrdinal("ID_LanctoAtiv"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Fazenda")))
                        reg.Cd_fazenda = reader.GetDecimal(reader.GetOrdinal("CD_Fazenda"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NM_Fazenda")))
                        reg.Nm_fazenda = reader.GetString(reader.GetOrdinal("NM_Fazenda"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Talhao")))
                        reg.Cd_talhao = reader.GetDecimal(reader.GetOrdinal("CD_Talhao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NM_Talhao")))
                        reg.Nm_talhao = reader.GetString(reader.GetOrdinal("NM_Talhao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("AnoSafra")))
                        reg.AnoSafra = reader.GetString(reader.GetOrdinal("AnoSafra"));

                    if (!reader.IsDBNull(reader.GetOrdinal("Cd_plantio")))
                        reg.Cd_plantio = reader.GetDecimal(reader.GetOrdinal("Cd_plantio"));

                    if (!reader.IsDBNull(reader.GetOrdinal("DS_plantio")))
                        reg.Ds_plantio = reader.GetString(reader.GetOrdinal("DS_plantio"));

                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Safra")))
                        reg.DS_Safra = reader.GetString(reader.GetOrdinal("DS_Safra"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Atividade")))
                        reg.Id_atividade = reader.GetDecimal(reader.GetOrdinal("ID_Atividade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Atividade")))
                        reg.Ds_atividade = reader.GetString(reader.GetOrdinal("DS_Atividade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("dt_ini")))
                        reg.dt_ini = reader.GetDateTime(reader.GetOrdinal("dt_ini"));
                    if (!reader.IsDBNull(reader.GetOrdinal("dt_fim")))
                        reg.dt_fim = reader.GetDateTime(reader.GetOrdinal("dt_fim"));
                    
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

        public string GravaLanAtividade(TRegistro_LanAtividade vRegistro)
        {
            Hashtable hs = new Hashtable(8);
            hs.Add("@P_ID_LANCTOATIV", vRegistro.Id_lanctoativ);
            hs.Add("@P_CD_FAZENDA", vRegistro.Cd_fazenda);
            hs.Add("@P_CD_TALHAO", vRegistro.Cd_talhao);
            hs.Add("@P_CD_PLANTIO", vRegistro.Cd_plantio);
            hs.Add("@P_ANOSAFRA", vRegistro.AnoSafra);
            hs.Add("@P_ID_ATIVIDADE", vRegistro.Id_atividade);
            hs.Add("@P_DT_INI", vRegistro.dt_ini);
            hs.Add("@P_DT_FIM", vRegistro.dt_fim);

            
            return this.executarProc("IA_FAZ_LANATIVIDADE", hs);
        }

        public string DeletaLanAtividade(TRegistro_LanAtividade vRegistro)
        {
            Hashtable hs = new Hashtable(1);
            hs.Add("@P_ID_LANCTOATIV", vRegistro.Id_lanctoativ);
            return this.executarProc("EXCLUI_FAZ_LANATIVIDADE", hs);
        }
    }
}
