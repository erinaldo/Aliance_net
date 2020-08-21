using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Contabil.Cadastro;
using Utils;
using CamadaDados.Contabil;

namespace CamadaNegocio.Contabil
{
    public static class TCN_Lan_ProcContabil
    {
        public static TList_ProcCaixa BuscaProc_Caixa(string vCD_Empresa, 
                                                      string vCD_ContaGer,
                                                      string vCD_LanctoCaixa,
                                                      string vDT_Inicio,
                                                      string vDT_Final,
                                                      bool vST_Reprocessa,
                                                      decimal vID_LoteCTB,
                                                      string vNR_Documento,
                                                      string vCd_historico,
                                                      string vCd_contaD,
                                                      string vCd_contaC,
                                                      decimal vVl_ini,
                                                      decimal vVl_fin,
                                                      string vCd_Movimento,
                                                      BancoDados.TObjetoBanco banco)
        {
            TpBusca[] filtro = new TpBusca[0];
            if (!string.IsNullOrEmpty(vCD_Empresa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + vCD_Empresa.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(vNR_Documento.Trim()))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.nr_Docto";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + vNR_Documento.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(vCD_ContaGer))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.CD_ContaGer";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + vCD_ContaGer.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(vCD_LanctoCaixa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_lanctocaixa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = vCD_LanctoCaixa;
            }
            if (!string.IsNullOrEmpty(vDT_Inicio.SoNumero()))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.DT_Lancto)))";
                filtro[filtro.Length - 1].vOperador = ">=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + DateTime.Parse(vDT_Inicio).ToString("yyyyMMdd") + "'";
            }
            if (!string.IsNullOrEmpty(vDT_Final.SoNumero()))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.DT_Lancto)))";
                filtro[filtro.Length - 1].vOperador = "<=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + DateTime.Parse(vDT_Final).ToString("yyyyMMdd") + "'";
            }
            if (vID_LoteCTB > 0)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_lotectb";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + vID_LoteCTB.ToString() + "'";
            }
            if (vST_Reprocessa)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.ID_LoteCTB";
                filtro[filtro.Length - 1].vOperador = "is";
                filtro[filtro.Length - 1].vVL_Busca = "not null";
            }
            else
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.ID_LoteCTB";
                filtro[filtro.Length - 1].vOperador = "is";
                filtro[filtro.Length - 1].vVL_Busca = "null";
            }
            if (!string.IsNullOrEmpty(vCd_historico))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_historico";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + vCd_historico.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(vCd_contaD))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.CD_CONTACTB_DEB";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = vCd_contaD;
            }
            if (!string.IsNullOrEmpty(vCd_contaC))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.CD_CONTACTB_CRE";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = vCd_contaC;
            }
            if (vVl_ini > decimal.Zero)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.valor";
                filtro[filtro.Length - 1].vOperador = ">=";
                filtro[filtro.Length - 1].vVL_Busca = vVl_ini.ToString(new System.Globalization.CultureInfo("en-US", true));
            }
            if (vVl_fin > decimal.Zero)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.valor";
                filtro[filtro.Length - 1].vOperador = "<=";
                filtro[filtro.Length - 1].vVL_Busca = vVl_fin.ToString(new System.Globalization.CultureInfo("en-US", true));
            }
            if (!string.IsNullOrEmpty(vCd_Movimento))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.tp_mov";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = vCd_Movimento;
            }
            return new TCD_Lan_ProcCaixa(banco).Select(filtro);
        }

        public static TList_ProcAdiantamento BuscarProc_Adiantamento(string Cd_empresa,
                                                                     string Cd_contager,
                                                                     string Cd_lanctocaixa,
                                                                     string Cd_historico,
                                                                     string Cd_clifor,
                                                                     string Dt_inicio,
                                                                     string Dt_final,
                                                                     string Cd_contaD,
                                                                     string Cd_contaC,
                                                                     decimal Id_loteCTB,
                                                                     decimal Vl_ini,
                                                                     decimal Vl_fin,
                                                                     bool St_Reprocessa,
                                                                     BancoDados.TObjetoBanco banco)
        {
            TpBusca[] filtro = new TpBusca[0];
            if (!string.IsNullOrEmpty(Cd_empresa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Cd_contager))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_contager";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_contager.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Cd_lanctocaixa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_lanctocaixa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Cd_lanctocaixa;
            }
            if (!string.IsNullOrEmpty(Cd_historico))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_historico";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_historico.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Cd_clifor))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_clifor";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_clifor.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Dt_inicio.SoNumero()))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.dt_lancto)))";
                filtro[filtro.Length - 1].vOperador = ">=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + DateTime.Parse(Dt_inicio).ToString("yyyyMMdd") + "'";
            }
            if (!string.IsNullOrEmpty(Dt_final.SoNumero()))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.dt_lancto)))";
                filtro[filtro.Length - 1].vOperador = "<=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + DateTime.Parse(Dt_final).ToString("yyyyMMdd") + "'";
            }
            if (!string.IsNullOrEmpty(Cd_contaD))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_contactb_deb";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Cd_contaD;
            }
            if (!string.IsNullOrEmpty(Cd_contaC))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_contactb_cre";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Cd_contaC;
            }
            if (Id_loteCTB > decimal.Zero)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_lotectb";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_loteCTB.ToString();
            }
            if (Vl_ini > decimal.Zero)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.Vl_Lancto";
                filtro[filtro.Length - 1].vOperador = ">=";
                filtro[filtro.Length - 1].vVL_Busca = Vl_ini.ToString(new System.Globalization.CultureInfo("en-US", true));
            }
            if (Vl_fin > decimal.Zero)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.Vl_Lancto";
                filtro[filtro.Length - 1].vOperador = "<=";
                filtro[filtro.Length - 1].vVL_Busca = Vl_fin.ToString(new System.Globalization.CultureInfo("en-US", true));
            }
            if (St_Reprocessa)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.ID_LoteCTB";
                filtro[filtro.Length - 1].vOperador = "is";
                filtro[filtro.Length - 1].vVL_Busca = "not null";
            }
            else
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.ID_LoteCTB";
                filtro[filtro.Length - 1].vOperador = "is";
                filtro[filtro.Length - 1].vVL_Busca = "null";
            }
            return new TCD_ProcAdiantamento(banco).Select(filtro);
        }
    
        public static TList_ProcFaturamento BuscaProc_Faturamento(string vCD_Empresa,
                                                                  string vNr_Serie,
                                                                  string vNr_NotaFiscal,
                                                                  string vNr_LanctoFiscal,
                                                                  string vDT_Inicio,
                                                                  string vDT_Final,
                                                                  bool vST_Reprocessa,
                                                                  string vCD_LoteCTB,
                                                                  string vCD_Movimentacao,
                                                                  string vTP_Movimento,
                                                                  string vCD_Produto,
                                                                  string vCD_Clifor,
                                                                  string vCd_contaD,
                                                                  string vCd_contaC,
                                                                  decimal vVl_ini,
                                                                  decimal vVl_fin,
                                                                  BancoDados.TObjetoBanco banco)
        {
            TpBusca[] filtro = new TpBusca[0];
            if (!string.IsNullOrEmpty(vCD_Empresa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + vCD_Empresa.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(vNr_Serie))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.nr_serie";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + vNr_Serie.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(vNr_NotaFiscal))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.nr_docto";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = vNr_NotaFiscal;
            }
            if (!string.IsNullOrEmpty(vNr_LanctoFiscal))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.nr_lanctofiscal";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = vNr_LanctoFiscal;
            }
            if (!string.IsNullOrEmpty(vDT_Inicio.SoNumero()))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.data)))";
                filtro[filtro.Length - 1].vOperador = ">=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + DateTime.Parse(vDT_Inicio).ToString("yyyyMMdd") + "'";
            }
            if (!string.IsNullOrEmpty(vDT_Final.SoNumero()))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.data)))";
                filtro[filtro.Length - 1].vOperador = "<=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + DateTime.Parse(vDT_Final).ToString("yyyyMMdd") + "'";
            }
            if (!string.IsNullOrEmpty(vCD_Movimentacao))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_movimentacao";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + vCD_Movimentacao.Trim() + "'";
            }
            if (vST_Reprocessa)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.ID_LoteCTB_Fat";
                filtro[filtro.Length - 1].vOperador = "is";
                filtro[filtro.Length - 1].vVL_Busca = "not null";
            }
            else
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.ID_LoteCTB_Fat";
                filtro[filtro.Length - 1].vOperador = "is";
                filtro[filtro.Length - 1].vVL_Busca = "null";
            }
            if (!string.IsNullOrEmpty(vCD_LoteCTB))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.ID_LoteCTB_Fat";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = vCD_LoteCTB;
            }
            if (!string.IsNullOrEmpty(vCD_Produto))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_produto";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + vCD_Produto.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(vCD_Clifor))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_clifor";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + vCD_Clifor.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(vTP_Movimento))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vVL_Busca = "'" + vTP_Movimento.Trim() + "'";
                filtro[filtro.Length - 1].vNM_Campo = "a.Tp_movimento";
                filtro[filtro.Length - 1].vOperador = "=";
            }
            if (!string.IsNullOrEmpty(vCd_contaD))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vVL_Busca = vCd_contaD;
                filtro[filtro.Length - 1].vNM_Campo = "a.CD_CONTACTB_DEB";
                filtro[filtro.Length - 1].vOperador = "=";
            }
            if (!string.IsNullOrEmpty(vCd_contaC))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vVL_Busca = vCd_contaC;
                filtro[filtro.Length - 1].vNM_Campo = "a.CD_CONTACTB_CRE";
                filtro[filtro.Length - 1].vOperador = "=";
            }
            if (vVl_ini > decimal.Zero)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.valor";
                filtro[filtro.Length - 1].vOperador = ">=";
                filtro[filtro.Length - 1].vVL_Busca = vVl_ini.ToString(new System.Globalization.CultureInfo("en-US", true));
            }
            if (vVl_fin > decimal.Zero)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.valor";
                filtro[filtro.Length - 1].vOperador = "<=";
                filtro[filtro.Length - 1].vVL_Busca = vVl_fin.ToString(new System.Globalization.CultureInfo("en-US", true));
            }
            return new TCD_Lan_ProcFaturamento(banco).Select(filtro);
        }

        public static TList_ProcNFCe BuscaProc_NFCe(string vCD_Empresa,
                                                    string vId_coo_ecf,
                                                    string vId_cupom,
                                                    string vDT_Inicio,
                                                    string vDT_Final,
                                                    bool vST_Reprocessa,
                                                    string vCD_LoteCTB,
                                                    string vCD_Produto,
                                                    string vCD_CFOP,
                                                    string vCd_contaD,
                                                    string vCd_contaC,
                                                    decimal vVl_ini,
                                                    decimal vVl_fin,
                                                    BancoDados.TObjetoBanco banco)
        {
            TpBusca[] filtro = new TpBusca[0];
            if (!string.IsNullOrEmpty(vCD_Empresa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + vCD_Empresa.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(vId_coo_ecf))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.nr_docto";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = vId_coo_ecf;
            }
            if(!string.IsNullOrEmpty(vId_cupom))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_nfce";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = vId_cupom;
            }
            if (!string.IsNullOrEmpty(vDT_Inicio.SoNumero()))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.data)))";
                filtro[filtro.Length - 1].vOperador = ">=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + DateTime.Parse(vDT_Inicio).ToString("yyyyMMdd") + "'";
            }
            if (!string.IsNullOrEmpty(vDT_Final.SoNumero()))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.data)))";
                filtro[filtro.Length - 1].vOperador = "<=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + DateTime.Parse(vDT_Final).ToString("yyyyMMdd") + "'";
            }
            if (vST_Reprocessa)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.ID_LoteCTB";
                filtro[filtro.Length - 1].vOperador = "is";
                filtro[filtro.Length - 1].vVL_Busca = "not null";
            }
            else
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.ID_LoteCTB";
                filtro[filtro.Length - 1].vOperador = "is";
                filtro[filtro.Length - 1].vVL_Busca = "null";
            }
            if (!string.IsNullOrEmpty(vCD_LoteCTB))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.ID_LoteCTB";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = vCD_LoteCTB;
            }
            if (!string.IsNullOrEmpty(vCD_Produto))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_produto";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + vCD_Produto.Trim() + "'";
            }
            if(!string.IsNullOrEmpty(vCD_CFOP))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.CD_CFOP";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + vCD_CFOP.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(vCd_contaD))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vVL_Busca = vCd_contaD;
                filtro[filtro.Length - 1].vNM_Campo = "a.CD_CONTACTB_DEB";
                filtro[filtro.Length - 1].vOperador = "=";
            }
            if (!string.IsNullOrEmpty(vCd_contaC))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vVL_Busca = vCd_contaC;
                filtro[filtro.Length - 1].vNM_Campo = "a.CD_CONTACTB_CRE";
                filtro[filtro.Length - 1].vOperador = "=";
            }
            if (vVl_ini > decimal.Zero)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.valor";
                filtro[filtro.Length - 1].vOperador = ">=";
                filtro[filtro.Length - 1].vVL_Busca = vVl_ini.ToString(new System.Globalization.CultureInfo("en-US", true));
            }
            if (vVl_fin > decimal.Zero)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.valor";
                filtro[filtro.Length - 1].vOperador = "<=";
                filtro[filtro.Length - 1].vVL_Busca = vVl_fin.ToString(new System.Globalization.CultureInfo("en-US", true));
            }
            return new TCD_Lan_ProcNFCe(banco).Select(filtro);
        }

        public static TList_ProcConhecimentoFrete BuscaProc_Frete(string vCD_Empresa,
                                                                  string vCTRC,
                                                                  string vNr_lanctoCTR,
                                                                  string vCd_transportadora,
                                                                  string vDT_Inicio,
                                                                  string vDT_Final,
                                                                  bool vST_Reprocessa,
                                                                  string vCD_LoteCTB,
                                                                  string vCd_contaD,
                                                                  string vCd_contaC,
                                                                  decimal vVl_ini,
                                                                  decimal vVl_fin,
                                                                  BancoDados.TObjetoBanco banco)
        {
            TpBusca[] filtro = new TpBusca[0];
            if (!string.IsNullOrEmpty(vCD_Empresa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + vCD_Empresa.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(vCTRC))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.nr_docto";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = vCTRC;
            }
            if (!string.IsNullOrEmpty(vNr_lanctoCTR))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.nr_lanctoctr";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = vNr_lanctoCTR;
            }
            if (!string.IsNullOrEmpty(vDT_Inicio.SoNumero()))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.dt_saient)))";
                filtro[filtro.Length - 1].vOperador = ">=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + DateTime.Parse(vDT_Inicio).ToString("yyyyMMdd") + "'";
            }
            if (!string.IsNullOrEmpty(vDT_Final.SoNumero()))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.dt_saient)))";
                filtro[filtro.Length - 1].vOperador = "<=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + DateTime.Parse(vDT_Final).ToString("yyyyMMdd") + "'";
            }
            if (vST_Reprocessa)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.ID_LoteCTB";
                filtro[filtro.Length - 1].vOperador = "is";
                filtro[filtro.Length - 1].vVL_Busca = "not null";
            }
            else
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.ID_LoteCTB";
                filtro[filtro.Length - 1].vOperador = "is";
                filtro[filtro.Length - 1].vVL_Busca = "null";
            }
            if (!string.IsNullOrEmpty(vCD_LoteCTB))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.ID_LoteCTB";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = vCD_LoteCTB;
            }
            if (!string.IsNullOrEmpty(vCd_transportadora))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_transportadora";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + vCd_transportadora.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(vCd_contaD))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vVL_Busca = vCd_contaD;
                filtro[filtro.Length - 1].vNM_Campo = "a.CD_CONTACTB_DEB";
                filtro[filtro.Length - 1].vOperador = "=";
            }
            if (!string.IsNullOrEmpty(vCd_contaC))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vVL_Busca = vCd_contaC;
                filtro[filtro.Length - 1].vNM_Campo = "a.CD_CONTACTB_CRE";
                filtro[filtro.Length - 1].vOperador = "=";
            }
            if (vVl_ini > decimal.Zero)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.valor";
                filtro[filtro.Length - 1].vOperador = ">=";
                filtro[filtro.Length - 1].vVL_Busca = vVl_ini.ToString(new System.Globalization.CultureInfo("en-US", true));
            }
            if (vVl_fin > decimal.Zero)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.valor";
                filtro[filtro.Length - 1].vOperador = "<=";
                filtro[filtro.Length - 1].vVL_Busca = vVl_fin.ToString(new System.Globalization.CultureInfo("en-US", true));
            }
            return new TCD_ProcConhecimentoFrete(banco).Select(filtro);
        }

        public static TList_ProcCMV BuscaProc_CMV(string vCD_Empresa,
                                                  string vNr_Serie,
                                                  string vNr_NotaFiscal,
                                                  string vNr_LanctoFiscal,
                                                  string vDT_Inicio,
                                                  string vDT_Final,
                                                  bool vST_Reprocessa,
                                                  string vCD_LoteCTB,
                                                  string vCD_Movimentacao,
                                                  string vTP_Movimento,
                                                  string vCD_Produto,
                                                  string vCD_Clifor,
                                                  string vCd_contaD,
                                                  string vCd_contaC,
                                                  decimal vVl_ini,
                                                  decimal vVl_fin,
                                                  BancoDados.TObjetoBanco banco)
        {
            TpBusca[] filtro = new TpBusca[0];
            if (!string.IsNullOrEmpty(vCD_Empresa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + vCD_Empresa.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(vNr_Serie))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.nr_serie";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + vNr_Serie.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(vNr_NotaFiscal))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.nr_docto";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = vNr_NotaFiscal;
            }
            if (!string.IsNullOrEmpty(vNr_LanctoFiscal))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.nr_lanctofiscal";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = vNr_LanctoFiscal;
            }
            if (!string.IsNullOrEmpty(vDT_Inicio.SoNumero()))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.data)))";
                filtro[filtro.Length - 1].vOperador = ">=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + DateTime.Parse(vDT_Inicio).ToString("yyyyMMdd") + "'";
            }
            if (!string.IsNullOrEmpty(vDT_Final.SoNumero()))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.data)))";
                filtro[filtro.Length - 1].vOperador = "<=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + DateTime.Parse(vDT_Final).ToString("yyyyMMdd") + "'";
            }
            if (!string.IsNullOrEmpty(vCD_Movimentacao))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_movimentacao";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + vCD_Movimentacao.Trim() + "'";
            }
            if (vST_Reprocessa)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.ID_LoteCTB_CMV";
                filtro[filtro.Length - 1].vOperador = "is";
                filtro[filtro.Length - 1].vVL_Busca = "not null";
            }
            else
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.ID_LoteCTB_CMV";
                filtro[filtro.Length - 1].vOperador = "is";
                filtro[filtro.Length - 1].vVL_Busca = "null";
            }
            if (!string.IsNullOrEmpty(vCD_LoteCTB))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_produto";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + vCD_Produto.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(vCD_Produto))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_produto";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + vCD_Produto.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(vCD_Clifor))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_clifor";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + vCD_Clifor.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(vTP_Movimento))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vVL_Busca = "'" + vTP_Movimento.Trim() + "'";
                filtro[filtro.Length - 1].vNM_Campo = "a.Tp_movimento";
                filtro[filtro.Length - 1].vOperador = "=";
            }
            if (!string.IsNullOrEmpty(vCd_contaD))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.CD_CONTACTB_DEB";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = vCd_contaD;
            }
            if (!string.IsNullOrEmpty(vCd_contaC))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.CD_CONTACTB_CRE";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = vCd_contaC;
            }
            if (vVl_ini > decimal.Zero)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.valor";
                filtro[filtro.Length - 1].vOperador = ">=";
                filtro[filtro.Length - 1].vVL_Busca = vVl_ini.ToString(new System.Globalization.CultureInfo("en-US", true));
            }
            if (vVl_fin > decimal.Zero)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.valor";
                filtro[filtro.Length - 1].vOperador = "<=";
                filtro[filtro.Length - 1].vVL_Busca = vVl_fin.ToString(new System.Globalization.CultureInfo("en-US", true));
            }
            return new TCD_Lan_ProcCMV(banco).Select(filtro);
        }

        public static TList_ProcCompFixar BuscarProc_CompFixar(string vCd_empresa,
                                                               string vId_atualiza,
                                                               string vDt_ini,
                                                               string vDt_fin,
                                                               string vTp_registro,
                                                               string vTp_movimento,
                                                               string vCd_produto,
                                                               string vId_loteCTB,
                                                               string vCd_contaD,
                                                               string vCd_contaC,
                                                               decimal vVl_ini,
                                                               decimal vVl_fin,
                                                               bool vSt_reprocessa,
                                                               BancoDados.TObjetoBanco banco)
        {
            TpBusca[] filtro = new TpBusca[0];
            if (!string.IsNullOrEmpty(vCd_empresa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + vCd_empresa.Trim() + "'";
            }
            if(!string.IsNullOrEmpty(vId_atualiza))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_atualiza";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = vId_atualiza;
            }
            if (!string.IsNullOrEmpty(vDt_ini.SoNumero()))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.data)))";
                filtro[filtro.Length - 1].vOperador = ">=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + DateTime.Parse(vDt_ini).ToString("yyyyMMdd") + "'";
            }
            if (!string.IsNullOrEmpty(vDt_fin.SoNumero()))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.data)))";
                filtro[filtro.Length - 1].vOperador = "<=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + DateTime.Parse(vDt_fin).ToString("yyyyMMdd") + "'";
            }
            
            if (!string.IsNullOrEmpty(vTp_registro))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.tp_registro";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + vTp_registro.Trim() + "'";
            }
            if(!string.IsNullOrEmpty(vTp_movimento))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.tp_movimento";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + vTp_movimento.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(vCd_produto))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_produto";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + vCd_produto.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(vId_loteCTB))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_lotectb";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = vId_loteCTB;
            }
            if (!string.IsNullOrEmpty(vCd_contaD))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.CD_CONTACTB_DEB";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = vCd_contaD;
            }
            if (!string.IsNullOrEmpty(vCd_contaC))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.CD_CONTACTB_CRE";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = vCd_contaC;
            }
            if (vVl_ini > decimal.Zero)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.Vl_Subtotal";
                filtro[filtro.Length - 1].vOperador = ">=";
                filtro[filtro.Length - 1].vVL_Busca = vVl_ini.ToString(new System.Globalization.CultureInfo("en-US", true));
            }
            if (vVl_fin > decimal.Zero)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.Vl_Subtotal";
                filtro[filtro.Length - 1].vOperador = "<=";
                filtro[filtro.Length - 1].vVL_Busca = vVl_fin.ToString(new System.Globalization.CultureInfo("en-US", true));
            }
            if (vSt_reprocessa)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_lotectb";
                filtro[filtro.Length - 1].vOperador = "is";
                filtro[filtro.Length - 1].vVL_Busca = "not null";
            }
            else
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_lotectb";
                filtro[filtro.Length - 1].vOperador = "is";
                filtro[filtro.Length - 1].vVL_Busca = "null";
            }
            return new TCD_Lan_ProcCompFixar(banco).Select(filtro);
        }

        public static TList_ProcImpostos BuscarProc_Impostos(string Cd_empresa,
                                                             string Nr_lanctofiscal,
                                                             string Nr_notafiscal,
                                                             string Cd_movimentacao,
                                                             string Cd_imposto,
                                                             string Cd_clifor,
                                                             string Cd_produto,
                                                             string Tp_movimento,
                                                             string Dt_inicio,
                                                             string Dt_final,
                                                             string Cd_contaD,
                                                             string Cd_contaC,
                                                             decimal Vl_ini,
                                                             decimal Vl_fin,
                                                             bool St_reprocessa,
                                                             BancoDados.TObjetoBanco banco)
        {
            TpBusca[] filtro = new TpBusca[0];
            if (!string.IsNullOrEmpty(Cd_empresa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Nr_lanctofiscal))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.nr_lanctofiscal";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Nr_lanctofiscal;
            }
            if (!string.IsNullOrEmpty(Nr_notafiscal))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.nr_notafiscal";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Nr_notafiscal;
            }
            if (!string.IsNullOrEmpty(Cd_movimentacao))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_movimentacao";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Cd_movimentacao;
            }
            if (!string.IsNullOrEmpty(Cd_imposto))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_imposto";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Cd_imposto;
            }
            if (!string.IsNullOrEmpty(Cd_clifor))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_clifor";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_clifor.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Cd_produto))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_produto";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_produto.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Tp_movimento))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.tp_movimento";
                filtro[filtro.Length - 1].vOperador = "in";
                filtro[filtro.Length - 1].vVL_Busca = "(" + Tp_movimento.Trim() + ")";
            }
            if (!string.IsNullOrEmpty(Dt_inicio.SoNumero()))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.data)))";
                filtro[filtro.Length - 1].vOperador = ">=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + DateTime.Parse(Dt_inicio).ToString("yyyyMMdd") + "'";
            }
            if (!string.IsNullOrEmpty(Dt_final.SoNumero()))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.data)))";
                filtro[filtro.Length - 1].vOperador = "<=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + DateTime.Parse(Dt_final).ToString("yyyyMMdd") + "'";
            }
            if (St_reprocessa)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = string.Empty;
                filtro[filtro.Length - 1].vOperador = string.Empty;
                filtro[filtro.Length - 1].vVL_Busca = "a.Id_LoteCTB_Calculado is not null or a.Id_LoteCTB_Retido is not null";
            }
            else
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = string.Empty;
                filtro[filtro.Length - 1].vOperador = string.Empty;
                filtro[filtro.Length - 1].vVL_Busca = "a.Id_LoteCTB_Calculado is null and a.Id_LoteCTB_Retido is null";
            }
            if (!string.IsNullOrEmpty(Cd_contaD))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.CD_ContaCTB_Deb";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Cd_contaD;
            }
            if (!string.IsNullOrEmpty(Cd_contaC))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.CD_ContaCTB_Cred";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Cd_contaC;
            }
            if (Vl_ini > decimal.Zero)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = string.Empty;
                filtro[filtro.Length - 1].vOperador = string.Empty;
                filtro[filtro.Length - 1].vVL_Busca = "a.Vl_ImpostoCalc >= " + Vl_ini.ToString(new System.Globalization.CultureInfo("en-US", true)) + " or a.Vl_ImpostoRetido >= " + Vl_ini.ToString(new System.Globalization.CultureInfo("en-US", true));
            }
            if (Vl_fin > decimal.Zero)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = string.Empty;
                filtro[filtro.Length - 1].vOperador = string.Empty;
                filtro[filtro.Length - 1].vVL_Busca = "a.Vl_ImpostoCalc <= " + Vl_ini.ToString(new System.Globalization.CultureInfo("en-US", true)) + " or a.Vl_ImpostoRetido <= " + Vl_ini.ToString(new System.Globalization.CultureInfo("en-US", true));
            }
            return new TCD_ProcImpostos(banco).Select(filtro);
        }

        public static TList_ProcChequeCompensado BuscaProc_ChequeCompensado(string vCD_Empresa,
                                                                            string vDT_Inicio,
                                                                            string vDT_Final,
                                                                            bool vST_Reprocessa,
                                                                            decimal vCD_LoteCTB,
                                                                            string vCD_ContaOrig,
                                                                            string vCD_ContaDest,
                                                                            string vCD_LanctoCaixa,
                                                                            decimal vNr_Docto,
                                                                            string vNr_Cheque,
                                                                            string vCd_contaD,
                                                                            string vCd_contaC,
                                                                            decimal vVl_ini,
                                                                            decimal vVl_fin,
                                                                            BancoDados.TObjetoBanco banco)
        {
            TpBusca[] filtro = new TpBusca[0];
            if (!string.IsNullOrEmpty(vCD_Empresa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + vCD_Empresa.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(vCD_ContaOrig))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.CD_ContaGer";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + vCD_ContaOrig.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(vCD_ContaDest))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.CD_ContaDest";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + vCD_ContaDest.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(vCD_LanctoCaixa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_lanctocaixa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = vCD_LanctoCaixa;
            }
            if (!string.IsNullOrEmpty(vDT_Inicio.SoNumero()))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.DT_Lancto)))";
                filtro[filtro.Length - 1].vOperador = ">=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + DateTime.Parse(vDT_Inicio).ToString("yyyyMMdd") + "'";
            }
            if (!string.IsNullOrEmpty(vDT_Final.SoNumero())) 
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.DT_Lancto)))";
                filtro[filtro.Length - 1].vOperador = "<=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + DateTime.Parse(vDT_Final).ToString("yyyyMMdd") + "'";
            }
            if (vCD_LoteCTB > 0)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.ID_LoteCTB";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = vCD_LoteCTB.ToString();
            }
            if (vST_Reprocessa)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.ID_LoteCTB";
                filtro[filtro.Length - 1].vOperador = "is";
                filtro[filtro.Length - 1].vVL_Busca = "not null";
            }
            else
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.ID_LoteCTB";
                filtro[filtro.Length - 1].vOperador = "is";
                filtro[filtro.Length - 1].vVL_Busca = "null";
            }
            if (vNr_Docto > 0)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.nr_docto";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = vNr_Docto.ToString();
            }
            if (!string.IsNullOrEmpty(vNr_Cheque))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vVL_Busca = vNr_Cheque.Trim();
                filtro[filtro.Length - 1].vNM_Campo = "t.nr_cheque";
                filtro[filtro.Length - 1].vOperador = "=";
            }
            if (!string.IsNullOrEmpty(vCd_contaD))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.CD_CONTACTB_DEB";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = vCd_contaD;
            }
            if (!string.IsNullOrEmpty(vCd_contaC))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.CD_CONTACTB_CRE";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = vCd_contaC;
            }
            if (vVl_ini > decimal.Zero)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.Valor";
                filtro[filtro.Length - 1].vOperador = ">=";
                filtro[filtro.Length - 1].vVL_Busca = vVl_ini.ToString(new System.Globalization.CultureInfo("en-US", true));
            }
            if (vVl_fin > decimal.Zero)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.Valor";
                filtro[filtro.Length - 1].vOperador = "<=";
                filtro[filtro.Length - 1].vVL_Busca = vVl_fin.ToString(new System.Globalization.CultureInfo("en-US", true));
            }
            
            return new TCD_Lan_ProcChequeCompensado(banco).Select(filtro);
        }

        public static TList_ProcCartao_DC BuscaProc_CartaoDC(string vCD_Empresa,
                                                             string vDT_Inicio,
                                                             string vDT_Final,
                                                             bool vST_Reprocessa,
                                                             decimal vCD_LoteCTB,
                                                             string vCD_ContaOrig,
                                                             string vCD_ContaDest,
                                                             string vId_fatura,
                                                             string vCd_contaD,
                                                             string vCd_contaC,
                                                             string vTp_cartao,
                                                             string vId_bandeira,
                                                             decimal vVl_ini,
                                                             decimal vVl_fin,
                                                             BancoDados.TObjetoBanco banco)
        {
            TpBusca[] filtro = new TpBusca[0];
            if (!string.IsNullOrEmpty(vCD_Empresa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + vCD_Empresa.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(vCD_ContaOrig))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.CD_ContaGer";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + vCD_ContaOrig.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(vCD_ContaDest))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.CD_ContaGerQuit";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + vCD_ContaDest.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(vDT_Inicio.SoNumero()))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.DT_Lancto)))";
                filtro[filtro.Length - 1].vOperador = ">=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + DateTime.Parse(vDT_Inicio).ToString("yyyyMMdd") + "'";
            }
            if (!string.IsNullOrEmpty(vDT_Final.SoNumero()))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.DT_Lancto)))";
                filtro[filtro.Length - 1].vOperador = "<=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + DateTime.Parse(vDT_Final).ToString("yyyyMMdd") + "'";
            }
            if (vCD_LoteCTB > 0)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.ID_LoteCTB";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = vCD_LoteCTB.ToString();
            }
            if (vST_Reprocessa)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.ID_LoteCTB";
                filtro[filtro.Length - 1].vOperador = "is";
                filtro[filtro.Length - 1].vVL_Busca = "not null";
            }
            else
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.ID_LoteCTB";
                filtro[filtro.Length - 1].vOperador = "is";
                filtro[filtro.Length - 1].vVL_Busca = "null";
            }
            if (!string.IsNullOrEmpty(vId_fatura))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vVL_Busca = vId_fatura.Trim();
                filtro[filtro.Length - 1].vNM_Campo = "a.id_fatura";
                filtro[filtro.Length - 1].vOperador = "=";
            }
            if (!string.IsNullOrEmpty(vCd_contaD))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.CD_CONTACTB_DEB";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = vCd_contaD;
            }
            if (!string.IsNullOrEmpty(vCd_contaC))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.CD_CONTACTB_CRE";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = vCd_contaC;
            }
            if(!string.IsNullOrEmpty(vTp_cartao))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "e.TP_Cartao";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + vTp_cartao.Trim() + "'";
            }
            if(!string.IsNullOrEmpty(vId_bandeira))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_bandeira";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = vId_bandeira;
            }
            if (vVl_ini > decimal.Zero)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.Valor";
                filtro[filtro.Length - 1].vOperador = ">=";
                filtro[filtro.Length - 1].vVL_Busca = vVl_ini.ToString(new System.Globalization.CultureInfo("en-US", true));
            }
            if (vVl_fin > decimal.Zero)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.Valor";
                filtro[filtro.Length - 1].vOperador = "<=";
                filtro[filtro.Length - 1].vVL_Busca = vVl_fin.ToString(new System.Globalization.CultureInfo("en-US", true));
            }

            return new TCD_ProcCartao_DC(banco).Select(filtro);
        }

        public static TList_ProcFinanceiro BuscaProc_Financeiro(string vCD_Empresa,
                                                                string vNR_Lancto,
                                                                string vDT_Inicio,
                                                                string vDT_Final,
                                                                string vNR_Docto,
                                                                string vCD_Clifor,
                                                                string vCD_Historico,
                                                                decimal vCD_LoteCTB,
                                                                bool vST_Reprocessa,
                                                                string vTp_duplicata,
                                                                string vCd_contaD,
                                                                string vCd_contaC,
                                                                decimal vVl_ini,
                                                                decimal vVl_fin,
                                                                BancoDados.TObjetoBanco banco)
        {
            TpBusca[] filtro = new TpBusca[0];
            if (!string.IsNullOrEmpty(vCD_Empresa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + vCD_Empresa.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(vNR_Lancto))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.nr_lancto";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = vNR_Lancto;
            }
            if (!string.IsNullOrEmpty(vDT_Inicio.SoNumero()))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.DT_Emissao)))";
                filtro[filtro.Length - 1].vOperador = ">=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + DateTime.Parse(vDT_Inicio).ToString("yyyyMMdd") + "'";
            }
            if (!string.IsNullOrEmpty(vDT_Final.SoNumero()))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.DT_Emissao)))";
                filtro[filtro.Length - 1].vOperador = "<=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + DateTime.Parse(vDT_Final).ToString("yyyyMMdd") + "'";
            }
            if (vCD_LoteCTB > 0)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.ID_LoteCTB";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = vCD_LoteCTB.ToString();
            }
            if (vST_Reprocessa)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.ID_LoteCTB";
                filtro[filtro.Length - 1].vOperador = "is";
                filtro[filtro.Length - 1].vVL_Busca = "not null";
            }
            else
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.ID_LoteCTB";
                filtro[filtro.Length - 1].vOperador = "is";
                filtro[filtro.Length - 1].vVL_Busca = "null";
            }
            if (!string.IsNullOrEmpty(vNR_Docto))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.nr_docto";
                filtro[filtro.Length - 1].vOperador = "LIKE";
                filtro[filtro.Length - 1].vVL_Busca = "'%" + vNR_Docto.ToString() + "%'";
            }
            if (!string.IsNullOrEmpty(vCD_Clifor))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vVL_Busca = "'" + vCD_Clifor.Trim() + "'";
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_clifor";
                filtro[filtro.Length - 1].vOperador = "=";
            }
            if (!string.IsNullOrEmpty(vCD_Historico))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vVL_Busca = "'" + vCD_Historico.Trim() + "'";
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_historico";
                filtro[filtro.Length - 1].vOperador = "=";
            }
            if (!string.IsNullOrEmpty(vTp_duplicata))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.tp_duplicata";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + vTp_duplicata.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(vCd_contaD))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.CD_CONTACTB_DEB";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = vCd_contaD;
            }
            if (!string.IsNullOrEmpty(vCd_contaC))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.CD_CONTACTB_CRE";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = vCd_contaC;
            }
            if (vVl_ini > decimal.Zero)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.VL_Documento";
                filtro[filtro.Length - 1].vOperador = ">=";
                filtro[filtro.Length - 1].vVL_Busca = vVl_ini.ToString(new System.Globalization.CultureInfo("en-US", true));
            }
            if (vVl_fin > decimal.Zero)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.VL_Documento";
                filtro[filtro.Length - 1].vOperador = "<=";
                filtro[filtro.Length - 1].vVL_Busca = vVl_fin.ToString(new System.Globalization.CultureInfo("en-US", true));
            }
            
            return new TCD_Lan_ProcFinanceiro(banco).Select(filtro);
        }

        public static TList_ProcProvEstoque BuscaProc_ProvEstoque(string vCD_Empresa,
                                                                  string vID_Provisao,
                                                                  string vDT_Inicio,
                                                                  string vDT_Final,
                                                                  decimal vCD_LoteCTB,
                                                                  string vCd_produto,
                                                                  string vCd_contaD,
                                                                  string vCd_contaC,
                                                                  decimal vVl_ini,
                                                                  decimal vVl_fin,
                                                                  bool vST_Reprocessa,
                                                                  BancoDados.TObjetoBanco banco)
        {
            TpBusca[] filtro = new TpBusca[0];
            if (!string.IsNullOrEmpty(vCD_Empresa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + vCD_Empresa.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(vID_Provisao))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_provisao";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = vID_Provisao;
            }
            if (!string.IsNullOrEmpty(vDT_Inicio.SoNumero()))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.DT_Lancto)))";
                filtro[filtro.Length - 1].vOperador = ">=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + DateTime.Parse(vDT_Inicio).ToString("yyyyMMdd") + "'";
            }
            if (!string.IsNullOrEmpty(vDT_Final.SoNumero()))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.DT_Lancto)))";
                filtro[filtro.Length - 1].vOperador = "<=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + DateTime.Parse(vDT_Final).ToString("yyyyMMdd") + "'";
            }
            if (vCD_LoteCTB > 0)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.ID_LoteCTB";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = vCD_LoteCTB.ToString();
            }
            if (vST_Reprocessa)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.ID_LoteCTB";
                filtro[filtro.Length - 1].vOperador = "is";
                filtro[filtro.Length - 1].vVL_Busca = "not null";
            }
            else
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.ID_LoteCTB";
                filtro[filtro.Length - 1].vOperador = "is";
                filtro[filtro.Length - 1].vVL_Busca = "null";
            }
            if (!string.IsNullOrEmpty(vCd_produto))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_produto";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + vCd_produto.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(vCd_contaD))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.CD_CONTACTB_DEB";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = vCd_contaD;
            }
            if (!string.IsNullOrEmpty(vCd_contaC))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.CD_CONTACTB_CRE";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = vCd_contaC;
            }
            if (vVl_ini > decimal.Zero)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.Valor";
                filtro[filtro.Length - 1].vOperador = ">=";
                filtro[filtro.Length - 1].vVL_Busca = vVl_ini.ToString(new System.Globalization.CultureInfo("en-US", true));
            }
            if (vVl_fin > decimal.Zero)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.Valor";
                filtro[filtro.Length - 1].vOperador = "<=";
                filtro[filtro.Length - 1].vVL_Busca = vVl_fin.ToString(new System.Globalization.CultureInfo("en-US", true));
            }
            return new TCD_Lan_ProcProvEstoque(banco).Select(filtro);
        }
    }
}
