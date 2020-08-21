using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using System.Data.SqlClient;
using Utils;


namespace CamadaDados.Faturamento.Pedido
{
    public class TList_RegLanPedido_GRO : List<TRegistro_LanPedido_GRO>
    { }
    
    public class TRegistro_LanPedido_GRO
    {
        private decimal vNR_Pedido;
        
        public decimal NR_Pedido
        {
            get { return vNR_Pedido; }
            set { vNR_Pedido = value; }
        }        
        private string vAnoSafra;
        
        public string AnoSafra
        {
            get { return vAnoSafra; }
            set { vAnoSafra = value; }
        }        
        private string vDS_AnoSafra;
        
        public string DS_AnoSafra
        {
            get { return vDS_AnoSafra; }
            set { vDS_AnoSafra = value; }
        }
        private string vCD_TabelaDesconto;
        
        public string CD_TabelaDesconto
        {
            get { return vCD_TabelaDesconto; }
            set { vCD_TabelaDesconto = value; }
        }
        private string vDS_TabelaDesconto;
        
        public string DS_TabelaDesconto
        {
            get { return vDS_TabelaDesconto; }
            set { vDS_TabelaDesconto = value; }
        }
        private DateTime vDT_PrazoAtendimento;
        
        public DateTime DT_PrazoAtendimento
        {
            get { return vDT_PrazoAtendimento; }
            set { vDT_PrazoAtendimento = value; }
        }
        private string vTp_Natureza;
        
        public string Tp_Natureza
        {
            get
            {
                return vTp_Natureza;
            }
            set
            {
                vTp_Natureza = value;
            }
        }
        private bool vST_Pag_frete;
        
        public bool ST_Pag_Frete
        {
            get
            {
                return vST_Pag_frete;                
            }
            set
            {
                vST_Pag_frete = value;
            }
        }
        private string vDS_ObsGRO;
        
        public string DS_ObsGRO
        {
            get { return vDS_ObsGRO; }
            set { vDS_ObsGRO = value; }
        }
        private DateTime vDT_Calculo_Taxas = DateTime.Now;
        
        public DateTime DT_Calculo_Taxas
        {
            get { return vDT_Calculo_Taxas; }
            set { vDT_Calculo_Taxas = value; }
        }
        private bool vST_GMO;
        
        public bool ST_GMO
        {
            get
            {
                return vST_GMO;
            }
            set
            {
                vST_GMO = value;
            }
        }
        private string vst_valunitmedio;
        
        public string St_ValunitMedio
        {
            get { return vst_valunitmedio; }
            set { vst_valunitmedio = value; }
        }
        private decimal vpc_pesodesc_deposito;
        
        public decimal PC_PesoDesc_Deposito
        {
            get { return vpc_pesodesc_deposito; }
            set { vpc_pesodesc_deposito = value; }
        }
        private decimal vvl_tx_recepcao;
        
        public decimal VL_TX_recepcao
        {
            get { return vvl_tx_recepcao; }
            set { vvl_tx_recepcao = value; }
        }
        private decimal vvl_tx_expedicao;
        
        public decimal VL_TX_expedicao
        {
            get { return vvl_tx_expedicao; }
            set { vvl_tx_expedicao = value; }
        }
        private decimal vvl_tx_armazenagem;
        
        public decimal VL_TX_armazenagem
        {
            get { return vvl_tx_armazenagem; }
            set { vvl_tx_armazenagem = value; }
        }
        private decimal vPeriodoCarencia_TXArm;
        
        public decimal PeriodoCarencia_TXArm
        {
            get { return vPeriodoCarencia_TXArm; }
            set { vPeriodoCarencia_TXArm = value; }
        }
        private decimal vFrequencia_TXArm;
        
        public decimal Frequencia_TXArm
        {
            get { return vFrequencia_TXArm; }
            set { vFrequencia_TXArm = value; }
        }
        private decimal vVl_Quebra_Tecnica;
        
        public decimal Vl_Quebra_Tecnica
        {
            get { return vVl_Quebra_Tecnica; }
            set { vVl_Quebra_Tecnica = value; }
        }
        private decimal vPeriodoCarencia_QuebraTec;
        
        public decimal PeriodoCarencia_QuebraTec
        {
            get { return vPeriodoCarencia_QuebraTec; }
            set { vPeriodoCarencia_QuebraTec = value; }
        }
        private decimal vFrequencia_QuebraTec;
        
        public decimal Frequencia_QuebraTec
        {
            get { return vFrequencia_QuebraTec; }
            set { vFrequencia_QuebraTec = value; }
        }
        private string vST_TxArm_Tabelada;
        
        public string ST_TxArm_Tabelada
        {
            get { return vST_TxArm_Tabelada; }
            set { vST_TxArm_Tabelada = value; }
        }
        private string vST_CalcularTXSecagem;
        
        public string ST_CalcularTXSecagem
        {
            get { return vST_CalcularTXSecagem; }
            set { vST_CalcularTXSecagem = value; }
        }
        private char vST_Registro;
        
        public char ST_Registro
        {
            get
            {
                return vST_Registro;
            }
            set
            {
                value = vST_Registro;
            }
        }

        public TRegistro_LanPedido_GRO()
        {
            this.vAnoSafra = string.Empty;
            this.vCD_TabelaDesconto = string.Empty;
            this.vDS_AnoSafra = string.Empty;
            this.vDS_ObsGRO = string.Empty;
            this.vDS_TabelaDesconto = string.Empty;
            this.vDT_Calculo_Taxas = DateTime.Now;
            this.vDT_PrazoAtendimento = DateTime.Now;
            this.vFrequencia_QuebraTec = decimal.Zero;
            this.vFrequencia_TXArm = decimal.Zero;
            this.vNR_Pedido = decimal.Zero;
            this.vpc_pesodesc_deposito = decimal.Zero;
            this.vPeriodoCarencia_QuebraTec = decimal.Zero;
            this.vPeriodoCarencia_TXArm = decimal.Zero;
            this.vST_CalcularTXSecagem = string.Empty;
            this.vST_GMO = false;
            this.vST_Pag_frete = false;
            this.vST_Registro = 'A';
            this.vST_TxArm_Tabelada = string.Empty;
            this.vst_valunitmedio = string.Empty;
            this.vTp_Natureza = string.Empty;
            this.vVl_Quebra_Tecnica = decimal.Zero;
            this.vvl_tx_armazenagem = decimal.Zero;
            this.vvl_tx_expedicao = decimal.Zero;
            this.vvl_tx_recepcao = decimal.Zero;
        }
    }

    public class TCD_LanPedido_GRO : TDataQuery
    {
        private string SqlCodeBusca(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            StringBuilder sql;
            string cond = " ";
            string strTop;
            int i;
            strTop = " ";

            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            sql = new StringBuilder();
            if (vNM_Campo.Length == 0)
            {
                sql.AppendLine("Select a.NR_Pedido, a.TP_Modalidade, a.NR_PedidoOrigem,  "); // c.Tp_Natureza, c.DT_PrazoAtendimento,
                sql.AppendLine("a.CD_Empresa, e.NM_Empresa, a.CFG_Pedido, a.CD_Clifor, f.NM_Clifor, a.CD_endereco, ");
                sql.AppendLine("h.DS_TipoPedido, a.CD_clifor_Entrega, a.CD_Endereco_Entrega, ");
                sql.AppendLine("fe.NM_clifor as NM_clifor_Entrega, ge.DS_Endereco as DS_Endereco_Entrega, ");
                sql.AppendLine("f.TP_Pessoa, f.NR_CGC, f.NR_CPF, g.DS_Endereco, g.CD_Cidade, ");
                sql.AppendLine("g.DS_Cidade, g.UF, g.DS_UF, a.TP_Movimento, a.DS_Observacao, h.ST_Deposito, a.DT_Pedido, a.ST_pedido, a.ST_Registro ");
            //    sql.AppendLine("c.AnoSafra, i.DS_Safra, c.CD_TabelaDesconto, j.DS_TabelaDesconto, c.DS_ObsGRO, c.DT_Calculo_Taxas, ");
             //   sql.AppendLine("c.ST_GMO, a.TP_Movimento, c.ST_Pag_Frete, C.ST_ValUnitMedio, C.PC_PesoDesc_Deposito, ");
             //   sql.AppendLine("c.Vl_TX_Recepcao, c.Vl_TX_Expedicao, c.Vl_TX_Armazenagem, c.PeriodoCarencia_TXArm, ");
             //   sql.AppendLine("c.Frequencia_TXArm, c.Vl_QuebraTecnica, c.PeriodoCarencia_QuebraTec, c.Frequencia_QuebraTec, ");
              //  sql.AppendLine("c.ST_TXArm_Tabelada, c.ST_CalcularTXSecagem, c.ST_GMO ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("From TB_FAT_Pedido a  ");           
            sql.AppendLine("left outer join TB_DIV_Empresa e On e.CD_Empresa = a.CD_Empresa ");
            sql.AppendLine("left outer join VTB_FIN_Clifor f On f.CD_Clifor = a.CD_Clifor ");
            sql.AppendLine("left outer join VTB_FIN_Endereco g On g.CD_Clifor = a.CD_Clifor and g.CD_Endereco = a.CD_Endereco ");
            sql.AppendLine("left outer join VTB_FIN_Clifor fe On fe.CD_Clifor = a.CD_Clifor ");
            sql.AppendLine("left outer join VTB_FIN_Endereco ge On ge.CD_Clifor = a.CD_Clifor and ge.CD_Endereco = a.CD_Endereco ");
            sql.AppendLine("left outer join TB_FAT_CFGPedido h On h.CFG_Pedido = a.CFG_Pedido ");
            sql.AppendLine("left outer join TB_GRO_Safra i On i.AnoSafra = c.AnoSafra ");
            sql.AppendLine("left outer join TB_GRO_TabelaDesconto j On j.CD_TabelaDesconto = c.CD_TabelaDesconto ");
            sql.AppendLine("Where isNull(a.ST_Registro, 'A') <> 'C' ");

            cond = " and ";
            if (vBusca != null)
                if (vBusca.Length > 0)
                {
                    for (i = 0; i < (vBusca.Length); i++)
                    {
                        if ((vBusca[i].vOperador.ToUpper() == "IN") ||
                            (vBusca[i].vOperador.ToUpper() == "NOT IN") ||
                            (vBusca[i].vOperador.ToUpper() == "EXISTS") ||
                            (vBusca[i].vOperador.ToUpper() == "NOT EXISTS"))
                        {
                            sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + ")");
                        }
                        else
                        {
                            sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                        }
                    }
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

        public TList_RegLanPedido_GRO Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_RegLanPedido_GRO lista = new TList_RegLanPedido_GRO();
            SqlDataReader reader = null;
            bool podeFecharBco = false;
                       
            if (Banco_Dados == null)
            {
                this.CriarBanco_Dados(false);
                podeFecharBco = true;
            }

            try
            {

                if (vNM_Campo == "")
                    reader = ExecutarBusca(SqlCodeBusca(vBusca, vTop, ""));
                else
                    reader = ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo));

                while (reader.Read())
                {
                    TRegistro_LanPedido_GRO LanPedido_GRO = new TRegistro_LanPedido_GRO();

                      if (!reader.IsDBNull(reader.GetOrdinal("Nr_Pedido")))
                         LanPedido_GRO.NR_Pedido = reader.GetDecimal(reader.GetOrdinal("Nr_Pedido"));
                      if (!reader.IsDBNull(reader.GetOrdinal("CD_TabelaDesconto")))
                         LanPedido_GRO.CD_TabelaDesconto = reader.GetString(reader.GetOrdinal("CD_TabelaDesconto"));
                      if (!reader.IsDBNull(reader.GetOrdinal("DS_TabelaDesconto")))
                         LanPedido_GRO.DS_TabelaDesconto = reader.GetString(reader.GetOrdinal("DS_TabelaDesconto"));
                      if (!reader.IsDBNull(reader.GetOrdinal("AnoSafra")))
                         LanPedido_GRO.AnoSafra = reader.GetString(reader.GetOrdinal("AnoSafra"));
                      if (!reader.IsDBNull(reader.GetOrdinal("DS_Safra")))
                         LanPedido_GRO.DS_AnoSafra = reader.GetString(reader.GetOrdinal("DS_Safra"));
                      if (!reader.IsDBNull(reader.GetOrdinal("DT_PrazoAtendimento")))
                         LanPedido_GRO.DT_PrazoAtendimento = reader.GetDateTime(reader.GetOrdinal("DT_PrazoAtendimento"));
                      if (!reader.IsDBNull(reader.GetOrdinal("Tp_Natureza")))
                        if (reader.GetString(reader.GetOrdinal("Tp_Natureza")) == "D")
                         LanPedido_GRO.Tp_Natureza =  "DESTINO";
                        else
                         LanPedido_GRO.Tp_Natureza = "ORIGEM";
                      if (!reader.IsDBNull(reader.GetOrdinal("ST_Pag_Frete")))
                        if (reader.GetString(reader.GetOrdinal("ST_Pag_Frete")) == "S")
                         LanPedido_GRO.ST_Pag_Frete = true;
                        else
                         LanPedido_GRO.ST_Pag_Frete = false;
                      if (!reader.IsDBNull(reader.GetOrdinal("DS_OBSGRO")))
                        LanPedido_GRO.DS_ObsGRO = reader.GetString(reader.GetOrdinal("DS_OBSGRO"));
                      if (!reader.IsDBNull(reader.GetOrdinal("DT_Calculo_Taxas")))
                        LanPedido_GRO.DT_Calculo_Taxas = reader.GetDateTime(reader.GetOrdinal("DT_Calculo_Taxas"));

                      if (!reader.IsDBNull(reader.GetOrdinal("ST_ValUnitMedio")))
                          LanPedido_GRO.St_ValunitMedio = (reader.GetString(reader.GetOrdinal("ST_ValUnitMedio")));
                      if (!reader.IsDBNull(reader.GetOrdinal("PC_PesoDesc_Deposito")))
                          LanPedido_GRO.PC_PesoDesc_Deposito = (reader.GetDecimal(reader.GetOrdinal("PC_PesoDesc_Deposito")));
                      if (!reader.IsDBNull(reader.GetOrdinal("Vl_TX_Recepcao")))
                          LanPedido_GRO.VL_TX_recepcao = (reader.GetDecimal(reader.GetOrdinal("Vl_TX_Recepcao")));
                      if (!reader.IsDBNull(reader.GetOrdinal("Vl_TX_Expedicao")))
                          LanPedido_GRO.VL_TX_expedicao = (reader.GetDecimal(reader.GetOrdinal("Vl_TX_Expedicao")));
                      if (!reader.IsDBNull(reader.GetOrdinal("Vl_TX_Armazenagem")))
                          LanPedido_GRO.VL_TX_armazenagem = (reader.GetDecimal(reader.GetOrdinal("Vl_TX_Armazenagem")));
                      if (!reader.IsDBNull(reader.GetOrdinal("PeriodoCarencia_TXArm")))
                          LanPedido_GRO.PeriodoCarencia_TXArm = (reader.GetDecimal(reader.GetOrdinal("PeriodoCarencia_TXArm")));
                      if (!reader.IsDBNull(reader.GetOrdinal("Frequencia_TXArm")))
                          LanPedido_GRO.Frequencia_TXArm = (reader.GetDecimal(reader.GetOrdinal("Frequencia_TXArm")));
                      if (!reader.IsDBNull(reader.GetOrdinal("Vl_QuebraTecnica")))
                          LanPedido_GRO.Vl_Quebra_Tecnica = (reader.GetDecimal(reader.GetOrdinal("Vl_QuebraTecnica")));
                      if (!reader.IsDBNull(reader.GetOrdinal("PeriodoCarencia_QuebraTec")))
                          LanPedido_GRO.PeriodoCarencia_QuebraTec = (reader.GetDecimal(reader.GetOrdinal("PeriodoCarencia_QuebraTec")));
                      if (!reader.IsDBNull(reader.GetOrdinal("Frequencia_QuebraTec")))
                          LanPedido_GRO.Frequencia_QuebraTec = (reader.GetDecimal(reader.GetOrdinal("Frequencia_QuebraTec")));
                      if (!reader.IsDBNull(reader.GetOrdinal("ST_TXArm_Tabelada")))
                          LanPedido_GRO.ST_TxArm_Tabelada = (reader.GetString(reader.GetOrdinal("ST_TXArm_Tabelada")));
                      if (!reader.IsDBNull(reader.GetOrdinal("ST_CalcularTXSecagem")))
                          LanPedido_GRO.ST_CalcularTXSecagem = (reader.GetString(reader.GetOrdinal("ST_CalcularTXSecagem")));
                      if (!reader.IsDBNull(reader.GetOrdinal("ST_GMO")))
                        if (reader.GetString(reader.GetOrdinal("ST_GMO")) == "S")
                          LanPedido_GRO.ST_GMO = true;
                      else
                        LanPedido_GRO.ST_GMO = false;
                      if (!reader.IsDBNull(reader.GetOrdinal("ST_Registro")))
                        LanPedido_GRO.ST_Registro = reader.GetString(reader.GetOrdinal("ST_Registro"))[0];

                    lista.Add(LanPedido_GRO);
                }
            }
            finally
            {
                reader.Close();
                reader.Dispose();
                if (podeFecharBco)
                    this.deletarBanco_Dados();
            };
            return lista;
        }

        public  string Grava(TRegistro_LanPedido_GRO vRegistro)
        {
            Hashtable hs = new Hashtable();
            hs.Add("@P_NR_PEDIDO", vRegistro.NR_Pedido);
            hs.Add("@P_ANOSAFRA", vRegistro.AnoSafra);
            hs.Add("@P_CD_TABELADESCONTO", vRegistro.CD_TabelaDesconto);
            hs.Add("@P_DT_PRAZOATENDIMENTO", vRegistro.DT_PrazoAtendimento);
            hs.Add("@P_TP_NATUREZA", vRegistro.Tp_Natureza);
            hs.Add("@P_ST_PAG_FRETE", vRegistro.ST_Pag_Frete);
            hs.Add("@P_DS_OBSGRO", vRegistro.DS_ObsGRO);
            hs.Add("@P_DT_CALCULO_TAXAS", vRegistro.DT_Calculo_Taxas);
            hs.Add("@P_ST_GMO", vRegistro.ST_GMO);
            hs.Add("@P_ST_REGISTRO", vRegistro.ST_Registro.ToString());

            return executarProc("IA_GRO_PEDIDO", hs);
        }

        public void Deleta(TRegistro_LanPedido_GRO vRegistro)
        {
            Hashtable hs = new Hashtable();
            hs.Add("@P_NR_PEDIDO", vRegistro.NR_Pedido);

            executarProc("EXCLUI_GRO_PEDIDO", hs);
        }
    }
}
