using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data.SqlClient;
using Utils;
using System.Data;
namespace CamadaDados.Fazenda.Lancamento
{
    public class TlistLanInsumos_X_Estoque : List<TRegistro_LanInsumos_X_Estoque>
    {
    }
    public class TRegistro_LanInsumos_X_Estoque
    {
        private string cd_Empresa;
        public string Cd_Empresa
        {
            get { return cd_Empresa; }
            set { cd_Empresa = value; }
        }

        private string cd_Produto;
        public string Cd_Produto
        {
            get { return cd_Produto; }
            set { cd_Produto = value; }
        }

        private decimal id_LanctoEstoque;
        public decimal Id_LanctoEstoque
        {
            get { return id_LanctoEstoque; }
            set { id_LanctoEstoque = value; }
        }

        private decimal id_Lancto;
        public decimal Id_Lancto
        {
            get { return id_Lancto; }
            set { id_Lancto = value; }
        }

        private decimal? id_Entrega;
        public decimal? Id_Entrega
        {
            get { return id_Entrega; }
            set { id_Entrega = value; }
        }
        public decimal ID_LanctoAtiv { get; set; }

        public TRegistro_LanInsumos_X_Estoque()
        {
            this.cd_Empresa = "";
            this.cd_Produto = "";
            this.id_LanctoEstoque = 0;
            this.id_Lancto = 0;
            this.id_Entrega = null;
        }

    }
    public class TCD_LanInsumos_X_Estoque : TDataQuery
    {
        private string SqlCodeBusca(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = "";
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();

            if (vNM_Campo.Length == 0)
            {
                sql.AppendLine("SELECT " + strTop + " c.CD_Empresa, a.ID_lancto, b.ID_LanctoAtiv, a.CD_Produto, d.Id_LanctoEstoque, d.ID_Entrega, b.ID_LanctoAtiv  ");
            }
            else
                sql.AppendLine("SELECT " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("FROM TB_FAZ_LanInsumos a ");
            sql.AppendLine("INNER JOIN TB_FAZ_LanAtividade b ON a.ID_LanctoAtiv = b.ID_LanctoAtiv ");
            sql.AppendLine("INNER JOIN TB_FAZ_FAZENDA c ON b.CD_Fazenda = c.CD_Fazenda ");
            sql.AppendLine("LEFT OUTER JOIN TB_FAZ_LanInsumos_X_Estoque d ON d.CD_Empresa = c.CD_Empresa  ");
            sql.AppendLine("											  AND d.ID_lancto = a.id_lancto  ");
            sql.AppendLine("											  AND d.ID_lanctoativ = b.id_lanctoativ  ");
            sql.AppendLine("											  AND d.CD_Produto = a.CD_Produto ");

            string cond = " WHERE ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.Append(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                    cond = " AND ";
                }
            sql.Append("  ");
            return sql.ToString();
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, ""), null);
        }

        public TlistLanInsumos_X_Estoque Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TlistLanInsumos_X_Estoque lista = new TlistLanInsumos_X_Estoque();
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
                    TRegistro_LanInsumos_X_Estoque reg = new TRegistro_LanInsumos_X_Estoque();
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        reg.Cd_Empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_Produto")))
                        reg.Cd_Produto = reader.GetString(reader.GetOrdinal("cd_Produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Id_LanctoEstoque")))
                        reg.Id_LanctoEstoque = reader.GetDecimal(reader.GetOrdinal("Id_LanctoEstoque"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Id_Lancto")))
                        reg.Id_Lancto = reader.GetDecimal(reader.GetOrdinal("Id_Lancto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_LanctoAtiv")))
                        reg.ID_LanctoAtiv = reader.GetDecimal(reader.GetOrdinal("ID_LanctoAtiv"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Id_Entrega")))
                        reg.Id_Entrega = reader.GetDecimal(reader.GetOrdinal("Id_Entrega"));


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

        public string GravaLanInsumos_X_Estoque(TRegistro_LanInsumos_X_Estoque vRegistro)
        {
            Hashtable hs = new Hashtable(6);
            hs.Add("@P_CD_EMPRESA", vRegistro.Cd_Empresa);
            hs.Add("@P_CD_PRODUTO", vRegistro.Cd_Produto);
            hs.Add("@P_ID_LANCTOESTOQUE", vRegistro.Id_LanctoEstoque);
            hs.Add("@P_ID_LANCTO", vRegistro.Id_Lancto);
            hs.Add("@P_ID_ENTREGA", vRegistro.Id_Entrega);
            hs.Add("@P_ID_LANCTOATIV", vRegistro.ID_LanctoAtiv);

            return this.executarProc("IA_FAZ_LANINSUMOS_X_ESTOQUE", hs);
        }

        public string DeletaLanInsumos_X_Estoque(TRegistro_LanInsumos_X_Estoque vRegistro)
        {
            Hashtable hs = new Hashtable(6);
            hs.Add("@P_CD_EMPRESA", vRegistro.Cd_Empresa);
            hs.Add("@P_CD_PRODUTO", vRegistro.Cd_Produto);
            hs.Add("@P_ID_LANCTOESTOQUE", vRegistro.Id_LanctoEstoque);
            hs.Add("@P_ID_LANCTO", vRegistro.Id_Lancto);
            hs.Add("@P_ID_ENTREGA", vRegistro.Id_Entrega);
            hs.Add("@P_ID_LANCTOATIV", vRegistro.ID_LanctoAtiv);

            return this.executarProc("EXCLUI_FAZ_LANINSUMOS_X_ESTOQUE", hs);
        }
    }
}
