using System;
using System.Windows.Forms;
using Utils;
using CamadaDados.Faturamento.NotaFiscal;

namespace Sementes
{
    public partial class TFSaldoLoteSemente : Form
    {
        public string Cd_empresa
        { get; set; }
        public string Nm_empresa
        { get; set; }
        public string Cd_produto
        { get; set; }
        public string Ds_produto
        { get; set; }
        public string Tp_mov
        { get; set; }
        public decimal Qtd_nota
        { get; set; }
        public bool St_devolucao
        { get; set; }
        public CamadaDados.Sementes.TList_LoteSemente_X_NFItem lLoteNf
        {
            get
            {
                if (bsLoteNf.Count > 0)
                {
                    CamadaDados.Sementes.TList_LoteSemente_X_NFItem aux = new CamadaDados.Sementes.TList_LoteSemente_X_NFItem();
                    for (int i = 0; i < bsLoteNf.Count; i++)
                        aux.Add(bsLoteNf[i] as CamadaDados.Sementes.TRegistro_LoteSemente_X_NFItem);
                    return aux;
                }
                else
                    return null;
            }
        }

        public CamadaDados.Sementes.TList_LoteSemente_X_NFItem lLoteNfOrigem
        { get; set; }

        public CamadaDados.Graos.TRegistro_DevAquisicao rDevAquisicao
        { get; set; }

        public TFSaldoLoteSemente()
        {
            InitializeComponent();
            Cd_empresa = string.Empty;
            Nm_empresa = string.Empty;
            Cd_produto = string.Empty;
            Ds_produto = string.Empty;
            Tp_mov = string.Empty;
            Qtd_nota = decimal.Zero;
            lLoteNfOrigem = new CamadaDados.Sementes.TList_LoteSemente_X_NFItem();
        }

        private void afterGrava()
        {
            if (qtd_saldo.Value > 0)
            {
                if (MessageBox.Show("Ainda existe saldo para informar lote.\r\n" +
                                "Item da Nota Fiscal não será gravado.\r\n" +
                                "Deseja continuar?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                    == DialogResult.Yes)
                    DialogResult = DialogResult.Cancel;
            }
            else
                DialogResult = DialogResult.OK;
        }

        private void InserirLote()
        {
            if (bsLoteSemente.Current != null)
            {
                if (quantidade.Value > 0)
                {
                    //Montar observacao
                    string obs = string.Empty;
                    bool st_folhar = new CamadaDados.Estoque.Cadastros.TCD_CadProduto().ProdutoFolhares((bsLoteSemente.Current as CamadaDados.Sementes.TRegistro_LoteSemente).Cd_produto);                 
                    if (!string.IsNullOrEmpty((bsLoteSemente.Current as CamadaDados.Sementes.TRegistro_LoteSemente).Renasem))
                        obs += (st_folhar ? "Registro: " : "Renasem:") + (bsLoteSemente.Current as CamadaDados.Sementes.TRegistro_LoteSemente).Renasem.Trim() + " ";
                    //Formulação
                    if (!string.IsNullOrEmpty((bsLoteSemente.Current as CamadaDados.Sementes.TRegistro_LoteSemente).Ds_formulacao))
                        obs += "Formulação: " + (bsLoteSemente.Current as CamadaDados.Sementes.TRegistro_LoteSemente).Ds_formulacao.Trim() + " ";
                    //Lote
                    if(!string.IsNullOrEmpty((bsLoteSemente.Current as CamadaDados.Sementes.TRegistro_LoteSemente).Nr_lote))
                        obs += "Lote:" + (bsLoteSemente.Current as CamadaDados.Sementes.TRegistro_LoteSemente).Nr_lote.Trim() + " ";
                    //Atestado
                    if(!string.IsNullOrEmpty((bsLoteSemente.Current as CamadaDados.Sementes.TRegistro_LoteSemente).Cd_atestado))
                        obs += "Atest.:" + (bsLoteSemente.Current as CamadaDados.Sementes.TRegistro_LoteSemente).Cd_atestado.Trim() + " ";
                    //Certificado
                    if (!string.IsNullOrEmpty((bsLoteSemente.Current as CamadaDados.Sementes.TRegistro_LoteSemente).Cd_certificado))
                        obs += "Cert.:" + (bsLoteSemente.Current as CamadaDados.Sementes.TRegistro_LoteSemente).Cd_certificado.Trim() + " ";
                    //% Germinação
                    if ((bsLoteSemente.Current as CamadaDados.Sementes.TRegistro_LoteSemente).Pc_germinacao > decimal.Zero)
                        obs += "%Germ.:" + (bsLoteSemente.Current as CamadaDados.Sementes.TRegistro_LoteSemente).Pc_germinacao.ToString("N2", new System.Globalization.CultureInfo("pt-BR", true));
                    //% Pureza
                    if ((bsLoteSemente.Current as CamadaDados.Sementes.TRegistro_LoteSemente).Pc_pureza > decimal.Zero)
                        obs += "%Pureza:" + (bsLoteSemente.Current as CamadaDados.Sementes.TRegistro_LoteSemente).Pc_pureza.ToString("N2", new System.Globalization.CultureInfo("pt-BR", true));
                    //Nº Conformidade
                    if (!string.IsNullOrEmpty((bsLoteSemente.Current as CamadaDados.Sementes.TRegistro_LoteSemente).Conformidade))
                        obs += "Conformidade:" + (bsLoteSemente.Current as CamadaDados.Sementes.TRegistro_LoteSemente).Conformidade.Trim() + " ";
                    //Val.Germ
                    if ((bsLoteSemente.Current as CamadaDados.Sementes.TRegistro_LoteSemente).Dt_valgerminacao.HasValue)
                        obs += "Val.Germ:" + (bsLoteSemente.Current as CamadaDados.Sementes.TRegistro_LoteSemente).Dt_valgerminacaostr + " ";
                    //Quantidade
                    obs += "Qtde " + (bsLoteSemente.Current as CamadaDados.Sementes.TRegistro_LoteSemente).Sigla_unidade.Trim() + ":" + quantidade.Value.ToString("N0", new System.Globalization.CultureInfo("pt-BR", true));
                    
                    //Verificar se o item ja existe na lista
                    int index = ItenExiste();
                    if (index >= 0)
                        //Excluir registro atual
                        bsLoteNf.RemoveAt(index);
                    decimal? id_formula = null;
                    if ((bsLoteSemente.Current as CamadaDados.Sementes.TRegistro_LoteSemente).Tp_lote.Trim().ToUpper().Equals("P"))
                    {
                        if (CamadaNegocio.ConfigGer.TCN_CadParamGer.BuscaVL_Bool("APONT_PRODUCAO_SEMENTE", Cd_empresa.Trim(), null).Trim().ToUpper().Equals("S"))
                            if (Tp_mov.Trim().ToUpper().Equals("E"))
                            {
                                using (TFFormulaEstornoSemente fFormula = new TFFormulaEstornoSemente())
                                {
                                    fFormula.rSemente = (bsLoteSemente.Current as CamadaDados.Sementes.TRegistro_LoteSemente);
                                    if (fFormula.ShowDialog() == DialogResult.OK)
                                        id_formula = fFormula.rSemente.Id_formestorno;
                                }
                            }
                        if (!BuscarNfOrigemLote())
                        {
                            MessageBox.Show("Obrigatorio informar origem do produto.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    }
                    bsLoteNf.Add(
                    new CamadaDados.Sementes.TRegistro_LoteSemente_X_NFItem()
                    {
                        Cd_empresa = Cd_empresa,
                        Cd_produto = Cd_produto,
                        Ds_produto = Ds_produto,
                        Id_lote = (bsLoteSemente.Current as CamadaDados.Sementes.TRegistro_LoteSemente).Id_lote,
                        Quantidade = quantidade.Value,
                        Sigla_unidade = (bsLoteSemente.Current as CamadaDados.Sementes.TRegistro_LoteSemente).Sigla_unidade,
                        Tp_movimento = St_devolucao ?  "D" : "V",
                        Ds_obsNfItem = obs,
                        Id_formestorno = id_formula
                    });
                    qtd_totallote.Value = SomarLote();
                }
                else
                    MessageBox.Show("Necessario informar quantidade para adicionar a lista.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Necessario selecionar lote para adicionar a lista.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            qtd_totallote.Value = SomarLote();
            bsLoteSemente.MoveNext();
        }

        private void ExcluirLote()
        {
            if (bsLoteNf.Current != null)
                if (MessageBox.Show("Confirma exclusão do item?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                    == DialogResult.Yes)
                {
                    //Remover registros de origem do lote
                    lLoteNfOrigem.RemoveAll(p => p.Id_lote.Equals((bsLoteSemente.Current as CamadaDados.Sementes.TRegistro_LoteSemente).Id_lote));
                    //Remover o lote
                    bsLoteNf.RemoveCurrent();
                    qtd_totallote.Value = SomarLote();
                }
        }

        private decimal SomarLote()
        {
            if (bsLoteNf.Count > 0)
            {
                decimal total = decimal.Zero;
                for (int i = 0; i < bsLoteNf.Count; i++)
                    total += (bsLoteNf[i] as CamadaDados.Sementes.TRegistro_LoteSemente_X_NFItem).Quantidade;
                return total;
            }
            else
                return decimal.Zero;
        }

        private int ItenExiste()
        {
            if (bsLoteNf.Count > 0)
            {
                for (int i = 0; i < bsLoteNf.Count; i++)
                    if ((bsLoteNf[i] as CamadaDados.Sementes.TRegistro_LoteSemente_X_NFItem).Id_lote.Equals((bsLoteSemente.Current as CamadaDados.Sementes.TRegistro_LoteSemente).Id_lote))
                        return i;
                return -1;
            }
            else
                return -1;
        }

        private bool BuscarNfOrigemLote()
        {
            //Verificar se ja nao foi amarrado a origem do lote
            if (CamadaNegocio.ConfigGer.TCN_CadParamGer.BuscaVL_Bool("APONT_PRODUCAO_SEMENTE", Cd_empresa.Trim(), null).Trim().ToUpper().Equals("S")
                && Tp_mov.Trim().ToUpper().Equals("S"))
                using (TFPedidoItemSemente fNfOrigem = new TFPedidoItemSemente())
                {
                    fNfOrigem.Cd_empresa = (bsLoteSemente.Current as CamadaDados.Sementes.TRegistro_LoteSemente).Cd_empresa;
                    fNfOrigem.Cd_amostra = (bsLoteSemente.Current as CamadaDados.Sementes.TRegistro_LoteSemente).Cd_amostra;
                    fNfOrigem.Qtd_lote = CamadaNegocio.Estoque.Cadastros.TCN_CadConvUnidade.ConvertUnid(
                        (bsLoteSemente.Current as CamadaDados.Sementes.TRegistro_LoteSemente).Cd_unidade,
                        (bsLoteSemente.Current as CamadaDados.Sementes.TRegistro_LoteSemente).Cd_unidamostra,
                        quantidade.Value,
                        3,
                        null);
                    if (fNfOrigem.ShowDialog() == DialogResult.OK)
                    {
                        if (fNfOrigem.lNfItem != null)
                        {
                            fNfOrigem.lNfItem.ForEach(p =>
                                {
                                    p.Id_lote = (bsLoteSemente.Current as CamadaDados.Sementes.TRegistro_LoteSemente).Id_lote;
                                    lLoteNfOrigem.Add(p);
                                });
                            return true;
                        }
                        else
                            return false;
                    }
                    else
                        return false;
                }
            else
                return true;
        }

        private void ProcDevAquisicao()
        {
            if (bsLoteSemente.Current != null)
            {
                try
                {
                    //Processar objeto devolucao/aquisicao
                    CamadaDados.Graos.TRegistro_DevAquisicao rDevAquisicao =
                        Proc_Commoditties.TProcessaDevAquisicao.ProcessarDevAquisicao(Cd_empresa,
                                                                                      (bsLoteSemente.Current as CamadaDados.Sementes.TRegistro_LoteSemente).Cd_amostra,
                                                                                      CamadaNegocio.Estoque.Cadastros.TCN_CadConvUnidade.ConvertUnid(
                                                                                        (bsLoteSemente.Current as CamadaDados.Sementes.TRegistro_LoteSemente).Cd_unidade,
                                                                                        (bsLoteSemente.Current as CamadaDados.Sementes.TRegistro_LoteSemente).Cd_unidamostra,
                                                                                        Qtd_nota, 3, null));
                    if (rDevAquisicao != null)
                    {
                        CamadaNegocio.Graos.TCN_DevAquisicao.GravarDevAquisicao(rDevAquisicao, null);
                        if (MessageBox.Show("Devolução/Aquisição realizada com sucesso.\r\nDeseja imprimir as notas fiscais?\r\n" +
                                                                    "Obs.: Somente serão impressas as notas fiscais proprias e não NF-e.", "Pergunta",
                                                                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                                                    == DialogResult.Yes)
                        {
                            //Buscar nota de origem
                            TRegistro_LanFaturamento rNf =
                                CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento.BuscarNF(rDevAquisicao.rNfOrigem.Cd_empresa,
                                                                                                 rDevAquisicao.rNfOrigem.Nr_lanctofiscalstr,
                                                                                                 null);
                            if (rNf.Tp_nota.Trim().ToUpper().Equals("P") && (!rNf.Cd_modelo.Trim().Equals("55")))
                                //Chamar tela de impressao para a nota fiscal
                                //somente se for nota propria
                                using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
                                {
                                    fImp.St_enabled_enviaremail = true;
                                    fImp.pCd_clifor = rNf.Cd_clifor;
                                    fImp.pMensagem = "NOTA FISCAL DEVOLUÇÃO Nº" + rNf.Nr_notafiscal.ToString();
                                    if ((fImp.ShowDialog() == DialogResult.OK) || (fImp.pSt_enviaremail))
                                        new FormRelPadrao.LayoutNotaFiscal().Imprime_NF(rNf,
                                                                                        fImp.pSt_imprimir,
                                                                                        fImp.pSt_visualizar,
                                                                                        fImp.pSt_enviaremail,
                                                                                        fImp.pDestinatarios,
                                                                                        "NOTA FISCAL DEVOLUÇÃO Nº " + rNf.Nr_notafiscal.ToString(),
                                                                                        fImp.pDs_mensagem);
                                }
                            //Buscar nota fiscal de destino
                            rNf = CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento.BuscarNF(rDevAquisicao.rNfDestino.Cd_empresa,
                                                                                                   rDevAquisicao.rNfDestino.Nr_lanctofiscalstr,
                                                                                                   null);
                            if (rNf.Tp_nota.Trim().ToUpper().Equals("P") && (!rNf.Cd_modelo.Trim().Equals("55")))
                                //Chamar tela de impressao para a nota fiscal
                                //somente se for nota propria
                                using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
                                {
                                    fImp.St_enabled_enviaremail = true;
                                    fImp.pCd_clifor = rNf.Cd_clifor;
                                    fImp.pMensagem = "NOTA FISCAL AQUISIÇÃO Nº" + rNf.Nr_notafiscal.ToString();
                                    if ((fImp.ShowDialog() == DialogResult.OK) || (fImp.pSt_enviaremail))
                                        new FormRelPadrao.LayoutNotaFiscal().Imprime_NF(rNf,
                                                                                        fImp.pSt_imprimir,
                                                                                        fImp.pSt_visualizar,
                                                                                        fImp.pSt_enviaremail,
                                                                                        fImp.pDestinatarios,
                                                                                        "NOTA FISCAL AQUISIÇÃO Nº " + rNf.Nr_notafiscal.ToString(),
                                                                                        fImp.pDs_mensagem);
                                }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void TFSaldoLoteSemente_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, gLoteSemente);
            Utils.ShapeGrid.RestoreShape(this, gGridNf);
            if (!string.IsNullOrEmpty(Utils.Parametros.pubCultura))
                Idioma.TIdioma.AjustaCultura(this);
            Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pDadosLote.set_FormatZero();
            qtd_totalnf.Value = Qtd_nota;
            rbVenda.Checked = !St_devolucao;
            rbDevVenda.Checked = St_devolucao;
            rbDevVenda.Text = St_devolucao ? Tp_mov.Trim().ToUpper().Equals("E") ? "Devolução Venda" : "Devolução Compra" : "Devolução";
            //Buscar lista de lotes disponiveis
            //Empresa
            TpBusca[] filtro = new TpBusca[3];
            filtro[0].vNM_Campo = "a.cd_empresa";
            filtro[0].vOperador = "=";
            filtro[0].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
            //Produto
            filtro[1].vNM_Campo = "a.cd_produto";
            filtro[1].vOperador = "=";
            filtro[1].vVL_Busca = "'" + Cd_produto.Trim() + "'";
            //Lote Aprovado
            filtro[2].vNM_Campo = "isnull(a.st_registro, 'A')";
            filtro[2].vOperador = "=";
            filtro[2].vVL_Busca = "'P'";
            if (St_devolucao && Tp_mov.Trim().ToUpper().Equals("S"))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.tp_lote";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'T'";
            }
            if (Tp_mov.Trim().ToUpper().Equals("S") && !St_devolucao)
            {
                Array.Resize(ref filtro, filtro.Length + 2);
                //Lote a vencer
                filtro[filtro.Length - 2].vNM_Campo = "CONVERT(DATETIME,FLOOR(CONVERT(NUMERIC(30,10),a.dt_valgerminacao)))";
                filtro[filtro.Length - 2].vOperador = ">=";
                filtro[filtro.Length - 2].vVL_Busca = "CONVERT(DATETIME,FLOOR(CONVERT(NUMERIC(30,10),getdate())))";
                //Lote com saldo
                filtro[filtro.Length - 1].vNM_Campo = "((isnull(dbo.F_CONVERTE_UNID(f.cd_unidade, d.cd_unidade, a.qtd_lote), a.qtd_lote) - " +
                                                      //Notas Vendas
                                                      "isnull((select sum(isnull(x.quantidade, 0)) " +                  
				                                      "                 from tb_sem_lotesemente_x_nfitem x " +                 
				                                      "                 inner join tb_fat_notafiscal_item y " +                  
				                                      "                 on x.cd_empresa = y.cd_empresa " +                  
				                                      "                 and x.nr_lanctofiscal = y.nr_lanctofiscal " +                  
				                                      "                 and x.id_nfitem = y.id_nfitem " +                  
				                                      "                 inner join tb_fat_notafiscal z " +                  
				                                      "                 on y.cd_empresa = z.cd_empresa " +                  
				                                      "                 and y.nr_lanctofiscal = z.nr_lanctofiscal " +                  
				                                      "                 inner join tb_fat_notafiscal_cmi cmi " +                  
				                                      "                 on z.cd_empresa = cmi.cd_empresa " +                  
				                                      "                 and z.nr_lanctofiscal = cmi.nr_lanctofiscal " +                  
				                                      "                 where z.tp_movimento = 'S' " +                  
				                                      "                 and x.tp_movimento = 'D' " +                  
				                                      "                 and isnull(cmi.st_devolucao, 'N') = 'S' " +                  
				                                      "                 and isnull(z.st_registro, 'A') <> 'C' " +
                                                      "                 and x.id_lote = a.id_lote), 0)) - " +  
                                                      //Devolucao Compra
                                                      "(isnull((select sum(isnull(x.quantidade, 0)) " +                   
		                                              "                 from tb_sem_lotesemente_x_nfitem x " +                 
		                                              "                 inner join tb_fat_notafiscal_item y " +                  
		                                              "                 on x.cd_empresa = y.cd_empresa " +                  
		                                              "                 and x.nr_lanctofiscal = y.nr_lanctofiscal " +                  
		                                              "                 and x.id_nfitem = y.id_nfitem " +                  
		                                              "                 inner join tb_fat_notafiscal z " +                  
		                                              "                 on y.cd_empresa = z.cd_empresa " +                  
		                                              "                 and y.nr_lanctofiscal = z.nr_lanctofiscal " +                  
		                                              "                 inner join tb_fat_notafiscal_cmi cmi " +                  
		                                              "                 on z.cd_empresa = cmi.cd_empresa " +                  
		                                              "                 and z.nr_lanctofiscal = cmi.nr_lanctofiscal " +                  
		                                              "                 where z.tp_movimento = 'S' " +                 
		                                              "                 and isnull(z.st_registro, 'A') <> 'C' " +                  
		                                              "                 and x.tp_movimento = 'V' " +                  
		                                              "                 and isnull(cmi.st_devolucao, 'N') <> 'S' " +
                                                      "                 and x.id_lote = a.id_lote ), 0) - " +   
                                                      //Devolucao Venda
                                                      "isnull((select sum(isnull(x.quantidade, 0)) " +                   
				                                      "                 from tb_sem_lotesemente_x_nfitem x " +                   
				                                      "                 inner join tb_fat_notafiscal_item y " +                  
				                                      "                 on x.cd_empresa = y.cd_empresa " +                   
				                                      "                 and x.nr_lanctofiscal = y.nr_lanctofiscal " +                   
				                                      "                 and x.id_nfitem = y.id_nfitem " +                   
				                                      "                 inner join tb_fat_notafiscal z " +                   
				                                      "                 on y.cd_empresa = z.cd_empresa " +                   
				                                      "                 and y.nr_lanctofiscal = z.nr_lanctofiscal " +                   
				                                      "                 inner join tb_fat_notafiscal_cmi cmi " +                   
				                                      "                 on z.cd_empresa = cmi.cd_empresa " +                   
				                                      "                 and z.nr_lanctofiscal = cmi.nr_lanctofiscal " +                   
				                                      "                 where z.tp_movimento = 'E' " +                   
				                                      "                 and x.tp_movimento = 'D' " +                   
				                                      "                 and isnull(cmi.st_devolucao, 'N') = 'S' " +                   
				                                      "                 and isnull(z.st_registro, 'A') <> 'C' " +                   
				                                      "                 and x.id_lote = a.id_lote), 0))) ";
                filtro[filtro.Length - 1].vOperador = ">";
                filtro[filtro.Length - 1].vVL_Busca = "0";
            }
            bsLoteSemente.DataSource = new CamadaDados.Sementes.TCD_LoteSemente().Select(filtro, 0, string.Empty);
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            afterGrava();
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void bb_deletar_Click(object sender, EventArgs e)
        {
            ExcluirLote();
        }

        private void bb_inserir_Click(object sender, EventArgs e)
        {
            InserirLote();
        }

        private void TFSaldoLoteSemente_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                DialogResult = DialogResult.Cancel;
            else if (e.KeyCode.Equals(Keys.F9))
                ProcDevAquisicao();
            else if (e.KeyCode.Equals(Keys.F10))
                InserirLote();
            else if (e.KeyCode.Equals(Keys.F11))
                ExcluirLote();
        }

        private void qtd_totalnf_ValueChanged(object sender, EventArgs e)
        {
            qtd_saldo.Value = qtd_totalnf.Value - qtd_totallote.Value;
        }

        private void qtd_totallote_ValueChanged(object sender, EventArgs e)
        {
            qtd_saldo.Value = qtd_totalnf.Value - qtd_totallote.Value;
        }

        private void quantidade_ValueChanged(object sender, EventArgs e)
        {
            if (quantidade.Value > 0)
            {
                if (bsLoteSemente.Current != null)
                {
                    if ((Tp_mov.Trim().ToUpper().Equals("S") ?
                        (bsLoteSemente.Current as CamadaDados.Sementes.TRegistro_LoteSemente).Qtd_saldo :
                        ((bsLoteSemente.Current as CamadaDados.Sementes.TRegistro_LoteSemente).Qtd_vendida -
                        (bsLoteSemente.Current as CamadaDados.Sementes.TRegistro_LoteSemente).Qtd_DevVenda)) < quantidade.Value)
                        quantidade.Value = (Tp_mov.Trim().ToUpper().Equals("S") ? 
                                            (bsLoteSemente.Current as CamadaDados.Sementes.TRegistro_LoteSemente).Qtd_saldo:
                                            ((bsLoteSemente.Current as CamadaDados.Sementes.TRegistro_LoteSemente).Qtd_vendida -
                                            (bsLoteSemente.Current as CamadaDados.Sementes.TRegistro_LoteSemente).Qtd_DevVenda));
                    if (quantidade.Value > qtd_saldo.Value)
                        quantidade.Value = qtd_saldo.Value;
                }
                else
                    quantidade.Value = quantidade.Minimum;
            }
        }

        private void bsLoteSemente_PositionChanged(object sender, EventArgs e)
        {
            quantidade.Value = (Tp_mov.Trim().ToUpper().Equals("S") ?
                                (bsLoteSemente.Current as CamadaDados.Sementes.TRegistro_LoteSemente).Qtd_saldo :
                                ((bsLoteSemente.Current as CamadaDados.Sementes.TRegistro_LoteSemente).Qtd_vendida -
                                (bsLoteSemente.Current as CamadaDados.Sementes.TRegistro_LoteSemente).Qtd_DevVenda));
        }

        private void BB_DevAquisicao_Click(object sender, EventArgs e)
        {
            ProcDevAquisicao();
        }

        private void TFSaldoLoteSemente_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, gLoteSemente);
            Utils.ShapeGrid.SaveShape(this, gGridNf);
        }
    }
}
