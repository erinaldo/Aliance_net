using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace NFCe
{
    public partial class TFGerenciarNFCe : Form
    {
        public CamadaDados.Faturamento.PDV.TRegistro_NFCe rNFCe
        { get; set; }
        private decimal tot;
        private bool Altera_Relatorio;

        public TFGerenciarNFCe()
        {
            InitializeComponent();
        }

        private void ConsultarLote()
        {
            lblStatus.Text = "Consulta Status Lote 1..10";
            System.Threading.Thread.Sleep(1000);
            tot = 1;
            //Consultar status lote NFe
            do
            {
                try
                {
                    if (rNFCe != null)
                    {
                        RetAutoriza.TRetAutoriza.ConsultaNFERecepcao(rNFCe.rCfgNFCe);
                        ImprimirDanfe();
                    }
                    break;
                }
                catch
                { lblStatus.Text = "Consulta Status Lote " + (++tot).ToString() + "..10"; }
            } while (tot <= 10);
            if (tot > 10)
            {
                lblStatus.Text = "Lote não processado.";
                Close();
            }
            else
                Close();
        }

        private void ImprimirDanfe()
        {
            //Verificar status NFe
            object obj = new CamadaDados.Faturamento.NFCe.TCD_Lote_X_NFCe().BuscarEscalar(
                            new Utils.TpBusca[]
                            {
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "a.cd_empresa",
                                    vOperador = "=",
                                    vVL_Busca = "'" + rNFCe.Cd_empresa.Trim() + "'"
                                },
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "a.id_cupom",
                                    vOperador = "=",
                                    vVL_Busca = rNFCe.Id_nfcestr
                                },
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = string.Empty,
                                    vOperador = "exists",
                                    vVL_Busca = "(select 1 from TB_FAT_LoteNFCe x " +
                                                "where x.id_lote = a.id_lote " +
                                                "and x.cd_empresa = a.cd_empresa " +
                                                "and x.st_registro = 'P' " +
                                                "and x.status = '104')"
                                }
                            }, "a.status");
            if (obj != null)
                if (obj.ToString().Trim().Equals("100"))
                    try
                    {
                        FormRelPadrao.Relatorio Rel = new FormRelPadrao.Relatorio();
                        Rel.Altera_Relatorio = Altera_Relatorio;
                        BindingSource dts = new BindingSource();
                        dts.DataSource = new CamadaDados.Faturamento.PDV.TList_NFCe_Item();
                        Rel.DTS_Relatorio = dts;// bsItens;
                        //DTS Cupom
                        BindingSource bsNFCe = new BindingSource();
                        bsNFCe.DataSource = new CamadaDados.Faturamento.PDV.TList_NFCe() { rNFCe };
                        TGerarQRCode.GerarQRCode2(rNFCe);
                        Rel.Adiciona_DataSource("DTS_NFCE", bsNFCe);
                        //Buscar Empresa
                        BindingSource bsEmpresa = new BindingSource();
                        bsEmpresa.DataSource = CamadaNegocio.Diversos.TCN_CadEmpresa.Busca(rNFCe.Cd_empresa,
                                                                                            string.Empty,
                                                                                            string.Empty,
                                                                                            null);
                        Rel.Adiciona_DataSource("DTS_EMP", bsEmpresa);
                        //Forma Pagamento
                        BindingSource bsPagto = new BindingSource();
                        if (rNFCe.lDup.Count > 0)
                            rNFCe.lPagto.Add(new CamadaDados.Faturamento.PDV.TRegistro_MovCaixa()
                            {
                                Tp_portador = "05",
                                Vl_recebido = rNFCe.lDup[0].Vl_documento
                            });

                        //Ocorre quando cupom emitido pelo delivery
                        //logo não informando condição de pagamento
                        if (rNFCe.lPagto.Count.Equals(0))
                        {
                            rNFCe.lPagto.Add(new CamadaDados.Faturamento.PDV.TRegistro_MovCaixa()
                            {
                                Tp_portador = "01",
                                Vl_recebido = rNFCe.lItem.Sum(p => p.Vl_subtotal)
                            });
                        }
                        
                        bsPagto.DataSource = rNFCe.lPagto;
                        Rel.Adiciona_DataSource("DTS_PAGTO", bsPagto);
                        //Parametros
                        Rel.Parametros_Relatorio.Add("TOT_IMP_APROX", rNFCe.lItem.Sum(p => p.Vl_imposto_Aprox));
                        Rel.Parametros_Relatorio.Add("QTD_ITENS", rNFCe.lItem.Count);
                        Rel.Parametros_Relatorio.Add("TOT_SUBTOTAL", rNFCe.lItem.Sum(p => p.Vl_subtotal));
                        Rel.Parametros_Relatorio.Add("TOT_ACRESCIMO", rNFCe.lItem.Sum(p => p.Vl_acrescimo));
                        Rel.Parametros_Relatorio.Add("TOT_DESCONTO", rNFCe.lItem.Sum(p => p.Vl_desconto));
                        Rel.Parametros_Relatorio.Add("ST_VIAEMPRESA", "N");
                        obj = new CamadaDados.Faturamento.NFCe.TCD_LoteNFCe().BuscarEscalar(
                                    new Utils.TpBusca[]
                                        {
                                            new Utils.TpBusca()
                                            {
                                                vNM_Campo = string.Empty,
                                                vOperador = "exists",
                                                vVL_Busca = "(select 1 from TB_FAT_Lote_X_NFCe x " +
                                                            "where x.cd_empresa = a.cd_empresa " +
                                                            "and x.id_lote = a.id_lote " +
                                                            "and x.status = '100')"
                                            }
                                        }, "a.tp_ambiente");
                        Rel.Parametros_Relatorio.Add("TP_AMBIENTE", obj == null ? string.Empty : obj.ToString());
                        string dadoscf = CamadaNegocio.Faturamento.PDV.TCN_NFCe.BuscarPlacaKM(rNFCe.Cd_empresa,
                                                                                              rNFCe.Id_nfcestr,
                                                                                              null);
                        if (!string.IsNullOrEmpty(dadoscf))
                        {
                            string[] linhas = dadoscf.Split(new char[] { ':' });
                            string placa = string.Empty;
                            string km = string.Empty;
                            string frota = string.Empty;
                            string requisicao = string.Empty;
                            string nm_motorista = string.Empty;
                            string cpf_motorista = string.Empty;
                            string media = string.Empty;
                            string virg = string.Empty;
                            foreach (string s in linhas)
                            {
                                string[] colunas = s.Split(new char[] { '/' });
                                placa += virg + colunas[0];
                                km += virg + colunas[1];
                                frota += virg + colunas[2];
                                requisicao += virg + colunas[3];
                                nm_motorista += virg + colunas[4];
                                cpf_motorista += virg + colunas[5];
                                media += virg + colunas[6];
                                virg = ",";
                            }
                            if (!string.IsNullOrEmpty(placa))
                                Rel.Parametros_Relatorio.Add("PLACA", placa);
                            if (!string.IsNullOrEmpty(km))
                                Rel.Parametros_Relatorio.Add("KM", km);
                            if (!string.IsNullOrEmpty(media))
                                Rel.Parametros_Relatorio.Add("MEDIA", media + " KM/LT");
                            if (!string.IsNullOrEmpty(frota))
                                Rel.Parametros_Relatorio.Add("FROTA", frota);
                            if (!string.IsNullOrEmpty(requisicao))
                                Rel.Parametros_Relatorio.Add("REQUISICAO", requisicao);
                            if (!string.IsNullOrEmpty(nm_motorista))
                                Rel.Parametros_Relatorio.Add("NM_MOTORISTA", nm_motorista);
                            if (!string.IsNullOrEmpty(cpf_motorista))
                                Rel.Parametros_Relatorio.Add("CPF_MOTORISTA", cpf_motorista);
                        }
                        Rel.Nome_Relatorio = "DANFE_NFCE";
                        Rel.NM_Classe = "TFConsultaFrenteCaixa";
                        Rel.Modulo = "FAT";
                        Rel.Ident = "DANFE_NFCE";
                        if (CamadaNegocio.ConfigGer.TCN_CadParamGer.BuscaVlBool("ST_IMP_DANFE_NFCE_DETALHADA", null))
                        {
                            BindingSource bsItens = new BindingSource();
                            bsItens.DataSource = CamadaNegocio.Faturamento.PDV.TCN_NFCe_Item.Buscar(rNFCe.Id_nfcestr,
                                                                                                    rNFCe.Cd_empresa,
                                                                                                    string.Empty,
                                                                                                    null);
                            //Buscar Encerrantes das Abastecidas
                            (bsItens.List as CamadaDados.Faturamento.PDV.TList_NFCe_Item).Where(p=> p.St_combustivel).ToList().ForEach(p =>
                                {
                                    CamadaDados.PostoCombustivel.TList_VendaCombustivel lVComp =
                                        new CamadaDados.PostoCombustivel.TCD_VendaCombustivel().Select(
                                            new Utils.TpBusca[]
                                            {
                                                new Utils.TpBusca()
                                                {
                                                    vNM_Campo = string.Empty,
                                                    vOperador = "exists",
                                                    vVL_Busca = "(select 1 from tb_pdv_cupom_x_vendarapida x " +
                                                                "where x.cd_empresa = a.cd_empresa " +
                                                                "and x.id_vendarapida = a.id_cupom " +
                                                                "and x.id_lanctovenda = a.id_lancto " +
                                                                "and x.cd_empresa = '" + p.Cd_empresa.Trim() + "' " +
                                                                "and x.id_cupom = " + p.ID_NFCe.Value.ToString() + " " +
                                                                "and x.id_lancto = " + p.Id_lancto.Value.ToString() + ")"
                                                }
                                            }, 0, string.Empty, string.Empty);
                                    if (lVComp.Count > 0)
                                    {
                                        p.NR_Bico = lVComp[0].Id_bicostr;
                                        p.EncerranteFin = lVComp[0].Encerrantebico;
                                    }
                                });
                            Rel.DTS_Relatorio = bsItens;
                        }
                        if (rNFCe.Id_contingencia.HasValue)
                            if (Rel.Parametros_Relatorio.ContainsKey("ST_VIAEMPRESA"))
                                Rel.Parametros_Relatorio["ST_VIAEMPRESA"] = "S";
                            else
                                Rel.Parametros_Relatorio.Add("ST_VIAEMPRESA", "S");

                        //Verificar se existe Impressora padrão para o PDV
                        obj = new CamadaDados.Faturamento.Cadastros.TCD_PontoVenda().BuscarEscalar(
                                new Utils.TpBusca[]
                                    {
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "a.cd_terminal",
                                            vOperador = "=",
                                            vVL_Busca = "'" + Utils.Parametros.pubTerminal.Trim() + "'"
                                        }
                                    }, "a.impressorapadrao");
                        string print = obj == null ? string.Empty : obj.ToString();
                        if (string.IsNullOrEmpty(print))
                            using (Parametros.Diversos.TFListaImpressoras fLista = new Parametros.Diversos.TFListaImpressoras())
                            {
                                if (fLista.ShowDialog() == DialogResult.OK)
                                    if (!string.IsNullOrEmpty(fLista.Impressora))
                                        print = fLista.Impressora;

                            }
                        //Verificar se cliente possui email
                        obj = new CamadaDados.Financeiro.Cadastros.TCD_CadClifor().BuscarEscalar(
                                new Utils.TpBusca[] { new Utils.TpBusca { vNM_Campo = "a.cd_clifor", vOperador = "=", vVL_Busca = "'" + rNFCe.Cd_clifor.Trim() + "'" } }, "a.email");
                        //Imprimir
                        if (!string.IsNullOrEmpty(print) || obj != null)
                        {
                            
                            Rel.ImprimiGraficoReduzida(print,
                                                       !string.IsNullOrEmpty(print),
                                                       false,
                                                       obj == null ? null : string.IsNullOrEmpty(obj.ToString()) ? null : new List<string> { obj.ToString() },
                                                       "NFC-e " + rNFCe.Nm_empresa.Trim(),
                                                       "Segue em anexo arquivo da NFC-e no formato .PDF",
                                                       1);
                            if (rNFCe.Id_contingencia.HasValue && rNFCe.rCfgNFCe.Tp_ambiente_nfce.Equals(1) && !string.IsNullOrEmpty(print))
                                Rel.ImprimiGraficoReduzida(print,
                                                           true,
                                                           false,
                                                           null,
                                                           string.Empty,
                                                           string.Empty,
							                               1);
                        }
                    }
                    catch { }
                else
                    MessageBox.Show("Lote Processado com Sucesso.\r\nNFCe não foi aceita pela receita.\r\n" +
                    "Verifique o erro na tela de controle de NFCe.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Erro ao processar Lote NFCe.\r\n" +
                    "Verifique o erro na tela de controle de NFCe.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void TFGerenciarNFe_Load(object sender, EventArgs e)
        {
            Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
        }

        private void TFGerenciarNFe_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode.Equals(Keys.P))
                Altera_Relatorio = true;
        }

        private void tempo_Tick(object sender, EventArgs e)
        {
            tempo.Enabled = false;
            bool st_loteproc = false;
            try
            {
                if (string.IsNullOrEmpty(rNFCe.rCfgNFCe.Nr_certificado_nfe))
                    throw new Exception("Não existe configuração para envio de NFC-e para a empresa " + rNFCe.rCfgNFCe.Cd_empresa.Trim() + ".");
                //Enviar NFe
                st_loteproc = EnviaArq.TEnviaArq.EnviarLote(null, new List<CamadaDados.Faturamento.PDV.TRegistro_NFCe>() { rNFCe });
            }
            catch (Exception ex)
            { 
                MessageBox.Show("Erro enviar NFCe: " + ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
                return;
            }
            if (st_loteproc)
            {
                ImprimirDanfe();
                Close();
            }
            else
                try
                {
                    ConsultarLote();
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
    }
}
