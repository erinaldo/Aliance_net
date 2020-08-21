using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using FormBusca;
using Componentes;
using FormRelPadrao;
using Utils;

namespace Estoque.Cadastros
{
    public partial class TFCad_Produto : Form
    {
        private bool Altera_Relatorio = false;
        private CamadaDados.Diversos.TRegistro_CadTerminal rTerminal;

        public TFCad_Produto()
        {
            InitializeComponent();
        }

        private void LimparFiltros()
        {
            cd_produto.Clear();
            ds_produto.Clear();
            CD_Grupo.Clear();
            TP_Produto.Clear();
            CD_Unidade.Clear();
            CD_CondFiscal_Produto.Clear();
            st_inativo.Checked = false;
        }

        private void afterNovo()
        {
            using (TFProduto fProd = new TFProduto())
            {  
                if(fProd.ShowDialog() == DialogResult.OK)
                    if(fProd.rProd != null)
                        try
                        {
                            CamadaNegocio.Estoque.Cadastros.TCN_CadProduto.Gravar(fProd.rProd, null);
                            MessageBox.Show("Produto cadastrado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            bsProduto.Add(fProd.rProd);
                            bsProduto.MoveLast();
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void afterBusca()
        {
            bsProduto.DataSource = CamadaNegocio.Estoque.Cadastros.TCN_CadProduto.Busca(cd_produto.Text,
                                                                                        CD_Unidade.Text,
                                                                                        CD_Grupo.Text,
                                                                                        ds_produto.Text,
                                                                                        CD_CondFiscal_Produto.Text,
                                                                                        string.Empty,
                                                                                        string.Empty,
                                                                                        st_inativo.Checked ? string.Empty : "A",
                                                                                        cd_referencia.Text,
                                                                                        Nr_ncm.Text,
                                                                                        TP_Produto.Text,
                                                                                        cod_barra.Text,
                                                                                        cd_marca.Text,
                                                                                        Nr_patrimonio.Text,
                                                                                        0,
                                                                                        string.Empty,
                                                                                        string.Empty,
                                                                                        null);
            bsProduto_PositionChanged(this, new EventArgs());
        }

        private void afterAltera()
        {
            if(bsProduto.Current != null)
                using (TFProduto fProd = new TFProduto())
                {
                    fProd.rProd = bsProduto.Current as CamadaDados.Estoque.Cadastros.TRegistro_CadProduto;
                    if (fProd.ShowDialog() == DialogResult.OK)
                        if (fProd.rProd != null)
                            try
                            {
                                CamadaNegocio.Estoque.Cadastros.TCN_CadProduto.Gravar(fProd.rProd, null);
                                bsProduto_PositionChanged(this, new EventArgs());
                                MessageBox.Show("Produto Alterado com Sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);                            
                            }
                            catch (Exception ex)
                            { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                        else
                            afterBusca();
                    else
                        afterBusca();
                }
        }

        private void afterExclui()
        {
            if(bsProduto.Current != null)
                if(MessageBox.Show("Confirma exclusão do produto selecionado?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                    == DialogResult.Yes)
                    try
                    {
                        CamadaNegocio.Estoque.Cadastros.TCN_CadProduto.Excluir(bsProduto.Current as CamadaDados.Estoque.Cadastros.TRegistro_CadProduto, null);
                        MessageBox.Show("Produto excluido com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LimparFiltros();
                        cd_produto.Text = (bsProduto.Current as CamadaDados.Estoque.Cadastros.TRegistro_CadProduto).CD_Produto;
                        afterBusca();
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        public void afterPrint()
        {
            using (TFGerenciadorImpressao fImp = new TFGerenciadorImpressao())
            {
                Relatorio Rel = new Relatorio();
                Rel.Altera_Relatorio = Altera_Relatorio;
                Rel.DTS_Relatorio = bsProduto;
                Rel.Nome_Relatorio = "TFCadProduto";
                Rel.NM_Classe = "TFCadProduto";
                Rel.Modulo = (Tag == null ? string.Empty : Tag.ToString().Substring(0, 3));
                fImp.St_enabled_enviaremail = true;
                fImp.pCd_clifor = string.Empty;
                fImp.pMensagem = "RELATORIO " + Text.Trim();

                if (Altera_Relatorio)
                {
                    Rel.Gera_Relatorio(string.Empty,
                                       fImp.pSt_imprimir,
                                       fImp.pSt_visualizar,
                                       fImp.pSt_enviaremail,
                                       fImp.pSt_exportPdf,
                                       fImp.Path_exportPdf,
                                       fImp.pDestinatarios,
                                       null,
                                       "RELATORIO " + Text.Trim(),
                                       fImp.pDs_mensagem);
                    Altera_Relatorio = false;
                }
                else
                    if ((fImp.ShowDialog() == DialogResult.OK) || (fImp.pSt_enviaremail))
                        Rel.Gera_Relatorio(string.Empty,
                                           fImp.pSt_imprimir,
                                           fImp.pSt_visualizar,
                                           fImp.pSt_enviaremail,
                                           fImp.pSt_exportPdf,
                                           fImp.Path_exportPdf,
                                           null,
                                           fImp.pDestinatarios,
                                           "RELATORIO " + Text.Trim(),
                                           fImp.pDs_mensagem);
            }
        }

        private void CopiarProduto()
        {
            if (bsProduto.Current != null)
                using (TFProduto fProd = new TFProduto())
                {
                    fProd.St_copiar = true;
                    fProd.vProduto = (bsProduto.Current as CamadaDados.Estoque.Cadastros.TRegistro_CadProduto).DS_Produto;
                    fProd.vCd_unidade = (bsProduto.Current as CamadaDados.Estoque.Cadastros.TRegistro_CadProduto).CD_Unidade;
                    fProd.vDS_unidade = (bsProduto.Current as CamadaDados.Estoque.Cadastros.TRegistro_CadProduto).DS_Unidade;
                    fProd.vCd_grupo = (bsProduto.Current as CamadaDados.Estoque.Cadastros.TRegistro_CadProduto).CD_Grupo;
                    fProd.vDS_grupo = (bsProduto.Current as CamadaDados.Estoque.Cadastros.TRegistro_CadProduto).DS_Grupo;
                    fProd.vCd_marca = (bsProduto.Current as CamadaDados.Estoque.Cadastros.TRegistro_CadProduto).Cd_marcastr;
                    fProd.vDS_marca = (bsProduto.Current as CamadaDados.Estoque.Cadastros.TRegistro_CadProduto).DS_Marca;
                    fProd.vTp_produto = (bsProduto.Current as CamadaDados.Estoque.Cadastros.TRegistro_CadProduto).TP_Produto;
                    fProd.vDS_tpproduto = (bsProduto.Current as CamadaDados.Estoque.Cadastros.TRegistro_CadProduto).DS_TpProduto;
                    fProd.vCd_CondFiscal_Produto = (bsProduto.Current as CamadaDados.Estoque.Cadastros.TRegistro_CadProduto).CD_CondFiscal_Produto;
                    fProd.vDS_CondFiscal_Produto = (bsProduto.Current as CamadaDados.Estoque.Cadastros.TRegistro_CadProduto).DS_CondFiscal_Produto;
                    fProd.vId_tpservico = (bsProduto.Current as CamadaDados.Estoque.Cadastros.TRegistro_CadProduto).Id_tpservico;
                    fProd.vDS_tpservico = (bsProduto.Current as CamadaDados.Estoque.Cadastros.TRegistro_CadProduto).Ds_tpservico;
                    fProd.vId_tpservico = (bsProduto.Current as CamadaDados.Estoque.Cadastros.TRegistro_CadProduto).Id_tpservico;
                    fProd.vId_genero = (bsProduto.Current as CamadaDados.Estoque.Cadastros.TRegistro_CadProduto).Id_generostr;
                    fProd.vDS_genero = (bsProduto.Current as CamadaDados.Estoque.Cadastros.TRegistro_CadProduto).Ds_genero;
                    fProd.vCd_anp = (bsProduto.Current as CamadaDados.Estoque.Cadastros.TRegistro_CadProduto).Cd_anp;
                    fProd.vDS_anp = (bsProduto.Current as CamadaDados.Estoque.Cadastros.TRegistro_CadProduto).Ds_anp;
                    fProd.vSigla = (bsProduto.Current as CamadaDados.Estoque.Cadastros.TRegistro_CadProduto).Sigla;
                    fProd.vSigla_unidade = (bsProduto.Current as CamadaDados.Estoque.Cadastros.TRegistro_CadProduto).Sigla_unidade;
                    fProd.vTp_item = (bsProduto.Current as CamadaDados.Estoque.Cadastros.TRegistro_CadProduto).Tp_item;
                    fProd.vSt_servico = (bsProduto.Current as CamadaDados.Estoque.Cadastros.TRegistro_CadProduto).St_servico;
                    fProd.vSt_composto = (bsProduto.Current as CamadaDados.Estoque.Cadastros.TRegistro_CadProduto).St_composto;
                    fProd.vSt_materia = (bsProduto.Current as CamadaDados.Estoque.Cadastros.TRegistro_CadProduto).St_mprima;
                    fProd.vSt_embalagem = (bsProduto.Current as CamadaDados.Estoque.Cadastros.TRegistro_CadProduto).St_embalagem;
                    fProd.vNrNcm = (bsProduto.Current as CamadaDados.Estoque.Cadastros.TRegistro_CadProduto).Ncm;
                    fProd.vDsNcm = (bsProduto.Current as CamadaDados.Estoque.Cadastros.TRegistro_CadProduto).Ds_ncm;
                    fProd.lFicha = (bsProduto.Current as CamadaDados.Estoque.Cadastros.TRegistro_CadProduto).lFicha;
                    if (fProd.ShowDialog() == DialogResult.OK)
                        if (fProd.rProd != null)
                            try
                            {
                                CamadaNegocio.Estoque.Cadastros.TCN_CadProduto.Gravar(fProd.rProd, null);
                                MessageBox.Show("Produto Copiado com Sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                bsProduto_PositionChanged(this, new EventArgs());
                                afterBusca();
                            }
                            catch (Exception ex)
                            { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                        else
                            afterBusca();
                    else
                        afterBusca();
                }
        }

        private void AssistenteVenda()
        {
            if (bsProduto.Current != null)
                using (TFCadAssistenteVenda fCadAssistente = new TFCadAssistenteVenda())
                {
                    fCadAssistente.Cd_produto = (bsProduto.Current as CamadaDados.Estoque.Cadastros.TRegistro_CadProduto).CD_Produto;
                    fCadAssistente.Ds_produto = (bsProduto.Current as CamadaDados.Estoque.Cadastros.TRegistro_CadProduto).DS_Produto;
                    fCadAssistente.ShowDialog();
                }
        }

        private void afterAtualizar()
        {
            using (TFAtualizaPrecoSaldo fPrecoSaldo = new TFAtualizaPrecoSaldo())
            {
                fPrecoSaldo.ShowDialog();
            }
        }

        private void InserirItemFicha()
        {
            if (bsProduto.Current != null)
                using (TFItensFichaTec fItem = new TFItensFichaTec())
                {
                    fItem.pCd_produto = (bsProduto.Current as CamadaDados.Estoque.Cadastros.TRegistro_CadProduto).CD_Produto;
                    if (fItem.ShowDialog() == DialogResult.OK)
                        if (fItem.rFicha != null)
                            try
                            {
                                fItem.rFicha.Cd_produto = (bsProduto.Current as CamadaDados.Estoque.Cadastros.TRegistro_CadProduto).CD_Produto;
                                CamadaNegocio.Estoque.Cadastros.TCN_FichaTecProduto.Gravar(fItem.rFicha, null);
                                MessageBox.Show("Item cadastrado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                (bsProduto.Current as CamadaDados.Estoque.Cadastros.TRegistro_CadProduto).lFicha.Add(fItem.rFicha);
                                bsProduto.ResetCurrentItem();
                            }
                            catch(Exception ex)
                            { MessageBox.Show("Erro: " + ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
        }

        private void AlterarItemFicha()
        {
            if (bsFichaTec.Current != null)
            {
                CamadaDados.Estoque.Cadastros.TRegistro_FichaTecProduto rAux = new CamadaDados.Estoque.Cadastros.TRegistro_FichaTecProduto();
                rAux.Cd_produto = (bsFichaTec.Current as CamadaDados.Estoque.Cadastros.TRegistro_FichaTecProduto).Cd_produto;
                rAux.Cd_item = (bsFichaTec.Current as CamadaDados.Estoque.Cadastros.TRegistro_FichaTecProduto).Cd_item;
                rAux.Cd_unditem = (bsFichaTec.Current as CamadaDados.Estoque.Cadastros.TRegistro_FichaTecProduto).Cd_unditem;
                rAux.Ds_item = (bsFichaTec.Current as CamadaDados.Estoque.Cadastros.TRegistro_FichaTecProduto).Ds_item;
                rAux.Ds_produto = (bsFichaTec.Current as CamadaDados.Estoque.Cadastros.TRegistro_FichaTecProduto).Ds_produto;
                rAux.Ds_unditem = (bsFichaTec.Current as CamadaDados.Estoque.Cadastros.TRegistro_FichaTecProduto).Ds_unditem;
                rAux.Quantidade = (bsFichaTec.Current as CamadaDados.Estoque.Cadastros.TRegistro_FichaTecProduto).Quantidade;
                rAux.Sg_unditem = (bsFichaTec.Current as CamadaDados.Estoque.Cadastros.TRegistro_FichaTecProduto).Sg_unditem;
                rAux.Vl_precovenda = (bsFichaTec.Current as CamadaDados.Estoque.Cadastros.TRegistro_FichaTecProduto).Vl_precovenda;
                using (TFItensFichaTec fItem = new TFItensFichaTec())
                {
                    fItem.pCd_produto = (bsProduto.Current as CamadaDados.Estoque.Cadastros.TRegistro_CadProduto).CD_Produto;
                    fItem.rFicha = bsFichaTec.Current as CamadaDados.Estoque.Cadastros.TRegistro_FichaTecProduto;
                    if (fItem.ShowDialog() != DialogResult.OK)
                    {
                        (bsFichaTec.Current as CamadaDados.Estoque.Cadastros.TRegistro_FichaTecProduto).Cd_produto = rAux.Cd_produto;
                        (bsFichaTec.Current as CamadaDados.Estoque.Cadastros.TRegistro_FichaTecProduto).Cd_item = rAux.Cd_item;
                        (bsFichaTec.Current as CamadaDados.Estoque.Cadastros.TRegistro_FichaTecProduto).Cd_unditem = rAux.Cd_unditem;
                        (bsFichaTec.Current as CamadaDados.Estoque.Cadastros.TRegistro_FichaTecProduto).Ds_item = rAux.Ds_item;
                        (bsFichaTec.Current as CamadaDados.Estoque.Cadastros.TRegistro_FichaTecProduto).Ds_produto = rAux.Ds_produto;
                        (bsFichaTec.Current as CamadaDados.Estoque.Cadastros.TRegistro_FichaTecProduto).Ds_unditem = rAux.Ds_unditem;
                        (bsFichaTec.Current as CamadaDados.Estoque.Cadastros.TRegistro_FichaTecProduto).Quantidade = rAux.Quantidade;
                        (bsFichaTec.Current as CamadaDados.Estoque.Cadastros.TRegistro_FichaTecProduto).Sg_unditem = rAux.Sg_unditem;
                        (bsFichaTec.Current as CamadaDados.Estoque.Cadastros.TRegistro_FichaTecProduto).Vl_precovenda = rAux.Vl_precovenda;
                        bsProduto.ResetCurrentItem();
                    }
                    else 
                        try
                        {
                            CamadaNegocio.Estoque.Cadastros.TCN_FichaTecProduto.Gravar(fItem.rFicha, null);
                            MessageBox.Show("Item alterado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            int position = bsFichaTec.Position;
                            bsFichaTec.RemoveCurrent();
                            (bsFichaTec.List as CamadaDados.Estoque.Cadastros.TList_FichaTecProduto).Insert(position, fItem.rFicha);
                            bsFichaTec.ResetBindings(true);
                        }
                        catch(Exception ex)
                        { MessageBox.Show("Erro: " + ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
            }
            else
                MessageBox.Show("Obrigatorio selecionar item ficha tecnica para alterar.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ExcluirItemFicha()
        {
            if (bsFichaTec.Current != null)
            {
                if (MessageBox.Show("Confirma exclusão do item selecionado?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                     MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    try
                    {
                        CamadaNegocio.Estoque.Cadastros.TCN_FichaTecProduto.Excluir(bsFichaTec.Current as CamadaDados.Estoque.Cadastros.TRegistro_FichaTecProduto, null);
                        MessageBox.Show("Item excluido com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        bsFichaTec.RemoveCurrent();
                    }
                    catch (Exception ex)
                    { MessageBox.Show("Erro: " + ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
            else
                MessageBox.Show("Obrigatorio selecionar item ficha tecnica para excluir.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void PrintFichaTec()
        {
            if (bsFichaTec.Count > 0)
            {
                Relatorio Relatorio = new Relatorio();
                Relatorio.Altera_Relatorio = Altera_Relatorio;
                //DADOS PERTINENTES PARA A GERAÇÂO DO RELATORIO
                Relatorio.Nome_Relatorio = "REL_EST_FICHATECNICA";
                Relatorio.NM_Classe = "REL_EST_FICHATECNICA";
                Relatorio.Modulo = "EST";
                Relatorio.Ident = "REL_EST_FICHATECNICA";

                //Buscar ficha tecnica produto
                CamadaDados.Estoque.Cadastros.TList_FichaTecProduto lFicha =
                    CamadaNegocio.Estoque.Cadastros.TCN_FichaTecProduto.Buscar((bsProduto.Current as CamadaDados.Estoque.Cadastros.TRegistro_CadProduto).CD_Produto,
                                                                               string.Empty,
                                                                               null);
                CamadaNegocio.Estoque.Cadastros.TCN_FichaTecProduto.MontarFichaTec(string.Empty, string.Empty, lFicha, null);
                BindingSource bsFicha = new BindingSource();
                bsFicha.DataSource = lFicha;
                Relatorio.DTS_Relatorio = bsFicha;

                if (!Altera_Relatorio)
                {
                    //Chamar tela de gerenciamento de impressao
                    using (TFGerenciadorImpressao fImp = new TFGerenciadorImpressao())
                    {
                        fImp.St_enabled_enviaremail = true;
                        fImp.pCd_clifor = string.Empty;
                        fImp.pMensagem = "FICHA TECNICA DO PRODUTO " + (bsProduto.Current as CamadaDados.Estoque.Cadastros.TRegistro_CadProduto).CD_Produto.Trim();
                        if ((fImp.ShowDialog() == DialogResult.OK) || (fImp.pSt_enviaremail))
                            Relatorio.Gera_Relatorio((bsProduto.Current as CamadaDados.Estoque.Cadastros.TRegistro_CadProduto).CD_Produto.Trim(),
                                                     fImp.pSt_imprimir,
                                                     fImp.pSt_visualizar,
                                                     fImp.pSt_enviaremail,
                                                     fImp.pSt_exportPdf,
                                                     fImp.Path_exportPdf,
                                                     fImp.pDestinatarios,
                                                     null,
                                                     "FICHA TECNICA DO PRODUTO " + (bsProduto.Current as CamadaDados.Estoque.Cadastros.TRegistro_CadProduto).CD_Produto.Trim(),
                                                     fImp.pDs_mensagem);
                    }
                }
                else
                {
                    Relatorio.Gera_Relatorio();
                    Altera_Relatorio = false;
                }
            }
        }

        private void TFCad_Produto_Load(object sender, EventArgs e)
        {
            lblCustoProduto.Enabled = CamadaNegocio.Diversos.TCN_Usuario_RegraEspecial.ValidaRegra(Parametros.pubLogin, "PERMITIR VISUALIZAR CUSTO VENDA", null);
            ShapeGrid.RestoreShape(this, gProduto);
            Icon = ResourcesUtils.TecnoAliance_ICO;
            pFiltro.set_FormatZero();
            ShapeGrid.RestoreShape(this, gProduto);
            //Verificar se terminal possui configuracao para emitir etiqueta
            rTerminal = CamadaNegocio.Diversos.TCN_CadTerminal.Busca(Parametros.pubTerminal, string.Empty, null)[0];
        }

        private void CD_Grupo_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.CD_Grupo|=|'" + CD_Grupo.Text + "';" +
                              "a.TP_Grupo|=|'A'";
            UtilPesquisa.EDIT_LEAVE(vColunas, new EditDefault[] { CD_Grupo },
                                    new CamadaDados.Estoque.Cadastros.TCD_CadGrupoProduto());
        }

        private void BB_GrupoProduto_Click(object sender, EventArgs e)
        {
            string vColunas = "a.DS_Grupo|Descrição Grupo Produto|350;" +
                              "a.CD_Grupo|Cód. Grupo|100";
            string vParamFixo = "a.TP_Grupo|=|'A'";
            UtilPesquisa.BTN_BUSCA(vColunas, new EditDefault[] { CD_Grupo },
                                    new CamadaDados.Estoque.Cadastros.TCD_CadGrupoProduto(), vParamFixo);
        }

        private void CD_CondFiscal_Produto_Leave(object sender, EventArgs e)
        {
            string vColunas = "CD_CondFiscal_Produto|=|'" + CD_CondFiscal_Produto.Text + "'";
            UtilPesquisa.EDIT_LEAVE(vColunas, new EditDefault[] { CD_CondFiscal_Produto },
                                    new CamadaDados.Fiscal.TCD_CadCondFiscalProduto());
        }

        private void BB_CondFiscalProduto_Click(object sender, EventArgs e)
        {
            string vColunas = "DS_CondFiscal_Produto|Condição Fiscal|350;" +
                              "CD_CondFiscal_Produto|Cód. Cond. Fiscal|100";
            UtilPesquisa.BTN_BUSCA(vColunas, new EditDefault[] { CD_CondFiscal_Produto },
                                    new CamadaDados.Fiscal.TCD_CadCondFiscalProduto(), string.Empty);
        }

        private void TP_Produto_Leave(object sender, EventArgs e)
        {
            string vColunas = "TP_Produto|=|'" + TP_Produto.Text + "'";
            UtilPesquisa.EDIT_LEAVE(vColunas, new EditDefault[] { TP_Produto },
                                    new CamadaDados.Estoque.Cadastros.TCD_CadTpProduto());
        }

        private void BB_TpProduto_Click(object sender, EventArgs e)
        {
            string vColunas = "DS_TPProduto|Tipo Produto|350;" +
                              "TP_Produto|Cód. TPProduto|100;" +
                              "ST_Servico|Servico|80;" +
                              "ST_Composto|Composto|80;" +
                              "ST_MPrima|Materia Prima|80;" +
                              "ST_Embalagem|Embalagem|80";
            UtilPesquisa.BTN_BUSCA(vColunas, new EditDefault[] { TP_Produto },
                                    new CamadaDados.Estoque.Cadastros.TCD_CadTpProduto(), string.Empty);
        }

        private void CD_Unidade_Leave(object sender, EventArgs e)
        {
            string vColunas = "CD_Unidade|=|'" + CD_Unidade.Text + "'";
            UtilPesquisa.EDIT_LEAVE(vColunas, new EditDefault[] { CD_Unidade },
                                    new CamadaDados.Estoque.Cadastros.TCD_CadUnidade());
        }

        private void BB_Unidade_Click(object sender, EventArgs e)
        {
            string vColunas = "DS_Unidade|Descrição Unidade|350;" +
                              "CD_Unidade|Cód. Unidade|100;" +
                              "Sigla_Unidade|Sigla|80";
            UtilPesquisa.BTN_BUSCA(vColunas, new EditDefault[] { CD_Unidade },
                                    new CamadaDados.Estoque.Cadastros.TCD_CadUnidade(), string.Empty);
        }

        private void bsProduto_PositionChanged(object sender, EventArgs e)
        {
            if (bsProduto.Current != null)
            {
                //Buscar imagens produto
                (bsProduto.Current as CamadaDados.Estoque.Cadastros.TRegistro_CadProduto).LImagens =
                    CamadaNegocio.Estoque.Cadastros.TCN_CadProduto_Imagens.Buscar(decimal.Zero,
                                                                                  (bsProduto.Current as CamadaDados.Estoque.Cadastros.TRegistro_CadProduto).CD_Produto);
                //Buscar Acessorios produto
                (bsProduto.Current as CamadaDados.Estoque.Cadastros.TRegistro_CadProduto).Acessorios =
                    CamadaNegocio.Estoque.Cadastros.TCN_CadAcessoriosProduto.Busca(decimal.Zero,
                                                                                   string.Empty,
                                                                                   (bsProduto.Current as CamadaDados.Estoque.Cadastros.TRegistro_CadProduto).CD_Produto);
                //Buscar ficha tecnica
                (bsProduto.Current as CamadaDados.Estoque.Cadastros.TRegistro_CadProduto).lFicha =
                    CamadaNegocio.Estoque.Cadastros.TCN_FichaTecProduto.Buscar((bsProduto.Current as CamadaDados.Estoque.Cadastros.TRegistro_CadProduto).CD_Produto,
                                                                               string.Empty,
                                                                               null);
                //Quantidade Estoque
                (bsProduto.Current as CamadaDados.Estoque.Cadastros.TRegistro_CadProduto).lQtdEstoque =
                    CamadaNegocio.Estoque.Cadastros.TCN_Produto_QtdEstoque.Buscar((bsProduto.Current as CamadaDados.Estoque.Cadastros.TRegistro_CadProduto).CD_Produto,
                                                                                  string.Empty,
                                                                                  null);
                //Codigo Barra
                (bsProduto.Current as CamadaDados.Estoque.Cadastros.TRegistro_CadProduto).lCodBarra =
                    CamadaNegocio.Estoque.Cadastros.TCN_CodBarra.Buscar((bsProduto.Current as CamadaDados.Estoque.Cadastros.TRegistro_CadProduto).CD_Produto,
                                                                        string.Empty,
                                                                        null);
                //Preco Venda
                (bsProduto.Current as CamadaDados.Estoque.Cadastros.TRegistro_CadProduto).lTabPrecoVenda =
                    CamadaNegocio.Estoque.Cadastros.TCN_LanPrecoItem.Busca(string.Empty,
                                                                           (bsProduto.Current as CamadaDados.Estoque.Cadastros.TRegistro_CadProduto).CD_Produto,
                                                                           string.Empty,
                                                                           string.Empty,
                                                                           string.Empty,
                                                                           string.Empty,
                                                                           string.Empty,
                                                                           string.Empty,
                                                                           "A",
                                                                           null);
                //Saldo Estoque
                (bsProduto.Current as CamadaDados.Estoque.Cadastros.TRegistro_CadProduto).lSaldoEst =
                    new CamadaDados.Estoque.TCD_LanEstoque().SelectSaldoEstoque(new TpBusca[] { new TpBusca { vNM_Campo = "a.cd_produto", vOperador = "=", vVL_Busca = "'" + (bsProduto.Current as CamadaDados.Estoque.Cadastros.TRegistro_CadProduto).CD_Produto.Trim() + "'" } });
                //Buscar assistente venda
                (bsProduto.Current as CamadaDados.Estoque.Cadastros.TRegistro_CadProduto).lAssistVenda =
                    CamadaNegocio.Estoque.Cadastros.TCN_CadAssistenteVenda.Busca((bsProduto.Current as CamadaDados.Estoque.Cadastros.TRegistro_CadProduto).CD_Produto,
                                                                                 string.Empty,
                                                                                 null);

                //Buscar Fornecedor
                (bsProduto.Current as CamadaDados.Estoque.Cadastros.TRegistro_CadProduto).lFornec =
                    CamadaNegocio.Estoque.Cadastros.TCN_Produto_X_Fornecedor.Buscar((bsProduto.Current as CamadaDados.Estoque.Cadastros.TRegistro_CadProduto).CD_Produto,
                                                                                    string.Empty,
                                                                                    string.Empty,
                                                                                    null);
                //Buscar Patrimonio
                (bsProduto.Current as CamadaDados.Estoque.Cadastros.TRegistro_CadProduto).lPatrimonio =
                    CamadaNegocio.Estoque.Cadastros.TCN_CadPatrimonio.Busca((bsProduto.Current as CamadaDados.Estoque.Cadastros.TRegistro_CadProduto).CD_Produto,
                                                                                 string.Empty,
                                                                                 string.Empty,
                                                                                 null);
                //Buscar Variedade
                (bsProduto.Current as CamadaDados.Estoque.Cadastros.TRegistro_CadProduto).lVariedade =
                    CamadaNegocio.Estoque.Cadastros.TCN_Variedade.Buscar((bsProduto.Current as CamadaDados.Estoque.Cadastros.TRegistro_CadProduto).CD_Produto,
                                                                         string.Empty,
                                                                         null);
                //Buscar Ficha OP
                (bsProduto.Current as CamadaDados.Estoque.Cadastros.TRegistro_CadProduto).lFichaOP =
                    CamadaNegocio.Estoque.Cadastros.TCN_FichaOP.Buscar((bsProduto.Current as CamadaDados.Estoque.Cadastros.TRegistro_CadProduto).CD_Produto,
                                                                       string.Empty,
                                                                       string.Empty,
                                                                       string.Empty,
                                                                       null);
                bsProduto.ResetCurrentItem();
            }
        }

        private void BB_Novo_Click(object sender, EventArgs e)
        {
            afterNovo();
        }

        private void BB_Buscar_Click(object sender, EventArgs e)
        {
            afterBusca();
        }

        private void BB_Alterar_Click(object sender, EventArgs e)
        {
            afterAltera();
        }

        private void BB_Excluir_Click(object sender, EventArgs e)
        {
            afterExclui();
        }

        private void BB_Imprimir_Click(object sender, EventArgs e)
        {
            afterPrint();
        }

        private void TFCad_Produto_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode.Equals(Keys.F2))
                afterNovo();
            else if (e.KeyCode.Equals(Keys.F3))
                afterAltera();
            else if (e.KeyCode.Equals(Keys.F5))
                afterExclui();
            else if (e.KeyCode.Equals(Keys.F7))
                afterBusca();
            else if (e.KeyCode.Equals(Keys.F8))
                afterPrint();
            else if (e.KeyCode.Equals(Keys.F9))
                CopiarProduto();
            else if (e.KeyCode.Equals(Keys.F10))
                AssistenteVenda();
            else if (e.KeyCode.Equals(Keys.F11))
                afterAtualizar();
            else if (tcDetalhes.SelectedTab.Equals(tpFichaTec) && e.Control && e.KeyCode.Equals(Keys.F10))
                InserirItemFicha();
            else if (tcDetalhes.SelectedTab.Equals(tpFichaTec) && e.Control && e.KeyCode.Equals(Keys.F11))
                AlterarItemFicha();
            else if (tcDetalhes.SelectedTab.Equals(tpFichaTec) && e.Control && e.KeyCode.Equals(Keys.F12))
                ExcluirItemFicha();
            else if (e.Control && e.KeyCode.Equals(Keys.P))
            {
                Altera_Relatorio = true;
                MessageBox.Show("Execute o relatorio que deseja alterar.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BB_Fechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void bb_impcodbarra_Click(object sender, EventArgs e)
        {
            if (bsCodBarra.Current != null)
            {
                using (TFGerenciadorImpressao fImp = new TFGerenciadorImpressao())
                {
                    Relatorio Rel = new Relatorio();
                    Rel.Altera_Relatorio = Altera_Relatorio;
                    Rel.Nome_Relatorio = "TFProduto";
                    Rel.NM_Classe = "TFProduto";
                    Rel.Ident = "REL_CODBARRA";
                    Rel.Modulo = "EST";
                    if (MessageBox.Show("Imprimir somente codigo barra corrente?", "Pergunta", MessageBoxButtons.YesNo,
                         MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) != DialogResult.Yes)
                        Rel.DTS_Relatorio = bsCodBarra;
                    else
                    {
                        //Numero de copias
                        InputBox inp = new InputBox(string.Empty, "Quantidade Copias.");
                        string ret = inp.Show();
                        int copias = 1;
                        try
                        {
                            copias = int.Parse(ret);
                        }
                        catch { }
                        CamadaDados.Estoque.Cadastros.TList_CodBarra lCod = new CamadaDados.Estoque.Cadastros.TList_CodBarra();
                        for (int i = 0; i < copias; i++)
                            lCod.Add(new CamadaDados.Estoque.Cadastros.TRegistro_CodBarra() { Cd_codbarra = (bsCodBarra.Current as CamadaDados.Estoque.Cadastros.TRegistro_CodBarra).Cd_codbarra,
                                                                                              Ds_produto = (bsProduto.Current as CamadaDados.Estoque.Cadastros.TRegistro_CadProduto).DS_Produto});
                        BindingSource bs = new BindingSource();
                        bs.DataSource = lCod;
                        Rel.DTS_Relatorio = bs;
                    }
                    fImp.St_enabled_enviaremail = true;
                    fImp.pCd_clifor = string.Empty;
                    fImp.pMensagem = "IMPRESSÃO CODIGO BARRA";

                    if (Altera_Relatorio)
                    {
                        Rel.Gera_Relatorio(string.Empty,
                                           fImp.pSt_imprimir,
                                           fImp.pSt_visualizar,
                                           fImp.pSt_enviaremail,
                                           fImp.pSt_exportPdf,
                                           fImp.Path_exportPdf,
                                           fImp.pDestinatarios,
                                           null,
                                           "IMPRESSÃO CODIGO BARRA",
                                           fImp.pDs_mensagem);
                        Altera_Relatorio = false;
                    }
                    else
                        if ((fImp.ShowDialog() == DialogResult.OK) || (fImp.pSt_enviaremail))
                            Rel.Gera_Relatorio(string.Empty,
                                               fImp.pSt_imprimir,
                                               fImp.pSt_visualizar,
                                               fImp.pSt_enviaremail,
                                               fImp.pSt_exportPdf,
                                               fImp.Path_exportPdf,
                                               null,
                                               fImp.pDestinatarios,
                                               "IMPRESSÃO CODIGO BARRA",
                                               fImp.pDs_mensagem);
                }
            }
            else
                MessageBox.Show("Obrigatorio selecionar codigo de barra para impressão.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void bb_custoprod_Click(object sender, EventArgs e)
        {
            if (bsProduto.Current != null)
                using (Proc_Commoditties.TFCustoProdComposto fCusto = new Proc_Commoditties.TFCustoProdComposto())
                {
                    fCusto.Cd_produto = (bsProduto.Current as CamadaDados.Estoque.Cadastros.TRegistro_CadProduto).CD_Produto;
                    fCusto.Ds_produto = (bsProduto.Current as CamadaDados.Estoque.Cadastros.TRegistro_CadProduto).DS_Produto;
                    fCusto.ShowDialog();
                }
        }

        private void TFCad_Produto_FormClosing(object sender, FormClosingEventArgs e)
        {
            ShapeGrid.SaveShape(this, gProduto);
        }

        private void bb_marca_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_marca|Marca|200;" +
                              "a.cd_marca|Id. Marca|80";
            UtilPesquisa.BTN_BUSCA(vColunas, new EditDefault[] { cd_marca },
                                    new CamadaDados.Estoque.Cadastros.TCD_CadMarca(),
                                    string.Empty);
        }

        private void cd_marca_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("a.cd_marca|=|" + cd_marca.Text,
                                    new EditDefault[] { cd_marca },
                                    new CamadaDados.Estoque.Cadastros.TCD_CadMarca());
        }

        private void bb_copiarProduto_Click(object sender, EventArgs e)
        {
            CopiarProduto();
        }

        private void bb_assistenteVenda_Click(object sender, EventArgs e)
        {
            AssistenteVenda();
        }

        private void lblCustoProduto_Click(object sender, EventArgs e)
        {
            if (bsProduto.Current != null)
                using (TFCustoProduto fCusto = new TFCustoProduto())
                {
                    fCusto.pCd_produto = (bsProduto.Current as CamadaDados.Estoque.Cadastros.TRegistro_CadProduto).CD_Produto;
                    fCusto.pDs_produto = (bsProduto.Current as CamadaDados.Estoque.Cadastros.TRegistro_CadProduto).DS_Produto;
                    fCusto.pUnd = (bsProduto.Current as CamadaDados.Estoque.Cadastros.TRegistro_CadProduto).Sigla_unidade;
                    fCusto.ShowDialog();
                }
            else
                MessageBox.Show("Necessario selecionar produto para visualizar custo.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void gProduto_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null)
                if (e.ColumnIndex.Equals(0))
                    if (e.Value.ToString().Trim().ToUpper().Equals("TRUE"))
                        gProduto.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Red;
                    else
                        gProduto.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
        }

        private void bb_atualizar_Click(object sender, EventArgs e)
        {
            afterAtualizar();
        }

        private void gProduto_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (gProduto.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.NotSortable)
                return;
            if (bsProduto.Count < 1)
                return;
            PropertyDescriptorCollection lP = TypeDescriptor.GetProperties(new CamadaDados.Estoque.Cadastros.TRegistro_CadProduto());
            CamadaDados.Estoque.Cadastros.TList_CadProduto lComparer;
            SortOrder direcao = SortOrder.None;
            if ((gProduto.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None) ||
                (gProduto.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending))
            {
                lComparer = new CamadaDados.Estoque.Cadastros.TList_CadProduto(lP.Find(gProduto.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Ascending);
                foreach (DataGridViewColumn c in gProduto.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Ascending;
            }
            else
            {
                lComparer = new CamadaDados.Estoque.Cadastros.TList_CadProduto(lP.Find(gProduto.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Descending);
                foreach (DataGridViewColumn c in gProduto.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Descending;
            }
            (bsProduto.List as CamadaDados.Estoque.Cadastros.TList_CadProduto).Sort(lComparer);
            bsProduto.ResetBindings(false);
            gProduto.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = direcao;
        }

        private void bb_impetiqueta_Click(object sender, EventArgs e)
        {
            if (bsProduto.Current != null)
            {
                if (bsCodBarra.Current == null)
                {
                    MessageBox.Show("Necessário cadastrar código de barra para imprimir etiqueta!", "Mernsagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (rTerminal.Tp_impetiqueta.Trim().ToUpper().Equals("Z"))
                {
                    if (string.IsNullOrEmpty(rTerminal.Porta_imptick))
                    {
                        MessageBox.Show("Não existe porta configurada no cadastro do terminal <" + rTerminal.Cd_Terminal.Trim() + "-" + rTerminal.Ds_Terminal.Trim() + "> para imprimir etiqueta.",
                            "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    try
                    {
                        string CD_TabelaPreco = string.Empty;
                        //Buscar tabela de preco frente caixa
                        if (Convert.ToDecimal(new CamadaDados.Diversos.TCD_CadTbPreco().BuscarEscalar(null, "COUNT(*)").ToString()) > 1)
                        {
                            EditDefault CD = new EditDefault();
                            CD.NM_Campo = "Cd_tabelaPreco";
                            CD.NM_CampoBusca = "Cd_tabelaPreco";
                            UtilPesquisa.BTN_BUSCA("DS_TabelaPreco|Descrição da Tabela de Preço|300;CD_TabelaPreco|Cd. Tab.Preço|80"
                                                 , new EditDefault[] { CD },
                                                 new CamadaDados.Diversos.TCD_CadTbPreco(),
                                                 string.Empty);
                            if (!string.IsNullOrEmpty(CD.Text))
                                CD_TabelaPreco = CD.Text;
                            else
                            {
                                MessageBox.Show("Selecione a tabela preço para imprimir etiqueta!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                        }
                        else
                        {
                            object obj_tab = new CamadaDados.Faturamento.Cadastros.TCD_CFGCupomFiscal().BuscarEscalar(null, "a.cd_tabelapreco");
                            CD_TabelaPreco = obj_tab.ToString();
                        }
                       
                        TpBusca[] filtro = new TpBusca[1];
                        filtro[0].vNM_Campo = "a.cd_produto";
                        filtro[0].vOperador = "=";
                        filtro[0].vVL_Busca = "'" + (bsProduto.Current as CamadaDados.Estoque.Cadastros.TRegistro_CadProduto).CD_Produto.Trim() + "'";
                        if (!string.IsNullOrEmpty(CD_TabelaPreco))
                        {
                            Array.Resize(ref filtro, filtro.Length + 1);
                            filtro[filtro.Length - 1].vNM_Campo = "a.cd_tabelapreco";
                            filtro[filtro.Length - 1].vOperador = "=";
                            filtro[filtro.Length - 1].vVL_Busca = "'" + CD_TabelaPreco.Trim() + "'";
                        }
                        object obj = new CamadaDados.Estoque.TCD_LanPrecoItem().BuscarEscalar(filtro, "a.vl_precovenda");


                        if (!rTerminal.Id_layout.HasValue ? false : rTerminal.Id_layout != decimal.Zero)
                        {
                            int qtd_etiquetas = 1;
                            using (TFQuantidade fQtd = new TFQuantidade())
                            {
                                fQtd.Casas_decimais = 0;
                                fQtd.Vl_default = 1;
                                fQtd.Vl_Minimo = 1;
                                fQtd.St_permitirValorZero = false;
                                if (fQtd.ShowDialog() == DialogResult.OK)
                                    qtd_etiquetas = Convert.ToInt32(fQtd.Quantidade);
                            }
                            CamadaNegocio.Diversos.TCN_CadLayoutEtiqueta.ImpEtiquetaLayout(decimal.Parse((bsProduto.Current as CamadaDados.Estoque.Cadastros.TRegistro_CadProduto).CD_Produto.SoNumero()),
                                                                (bsProduto.Current as CamadaDados.Estoque.Cadastros.TRegistro_CadProduto).DS_Produto.Trim(),
                                                                (bsProduto.Current as CamadaDados.Estoque.Cadastros.TRegistro_CadProduto).lCodBarra.Count > 0 ?
                                                                (bsProduto.Current as CamadaDados.Estoque.Cadastros.TRegistro_CadProduto).lCodBarra[0].Cd_codbarra : string.Empty,
                                                                obj == null ? decimal.Zero : decimal.Parse(obj.ToString()),
                                                                qtd_etiquetas,
                                                                rTerminal.Porta_imptick, rTerminal);
                        }
                        else if (rTerminal.Layoutetiqueta.Trim().Equals("1"))
                            TEtiquetaZebra.ImpEtiquetaL1((bsProduto.Current as CamadaDados.Estoque.Cadastros.TRegistro_CadProduto).Codigo_alternativo,
                                                               (bsProduto.Current as CamadaDados.Estoque.Cadastros.TRegistro_CadProduto).DS_Produto,
                                                               (bsProduto.Current as CamadaDados.Estoque.Cadastros.TRegistro_CadProduto).lCodBarra.Count > 0 ?
                                                               (bsProduto.Current as CamadaDados.Estoque.Cadastros.TRegistro_CadProduto).lCodBarra[0].Cd_codbarra : string.Empty,
                                                               obj == null ? decimal.Zero : decimal.Parse(obj.ToString()),
                                                               rTerminal.Porta_imptick);
                        else if (rTerminal.Layoutetiqueta.Trim().Equals("2"))
                            TEtiquetaZebra.ImpEtiquetaL2((bsProduto.Current as CamadaDados.Estoque.Cadastros.TRegistro_CadProduto).CD_Produto,
                                                               (bsProduto.Current as CamadaDados.Estoque.Cadastros.TRegistro_CadProduto).DS_Produto,
                                                               obj == null ? decimal.Zero : decimal.Parse(obj.ToString()),
                                                               rTerminal.Porta_imptick);
                        else if (rTerminal.Layoutetiqueta.Trim().Equals("3"))
                            TEtiquetaZebra.ImpEtiquetaL3((bsProduto.Current as CamadaDados.Estoque.Cadastros.TRegistro_CadProduto).CD_Produto,
                                                               (bsProduto.Current as CamadaDados.Estoque.Cadastros.TRegistro_CadProduto).DS_Produto,
                                                               (bsProduto.Current as CamadaDados.Estoque.Cadastros.TRegistro_CadProduto).lCodBarra.Count > 0 ?
                                                               (bsProduto.Current as CamadaDados.Estoque.Cadastros.TRegistro_CadProduto).lCodBarra[0].Cd_codbarra : string.Empty,
                                                               obj == null ? decimal.Zero : decimal.Parse(obj.ToString()),
                                                               rTerminal.Porta_imptick);
                        else if (rTerminal.Layoutetiqueta.Trim().Equals("4"))
                        {
                            int qtd_etiquetas = 1;
                            using (TFQuantidade fQtd = new TFQuantidade())
                            {
                                fQtd.Casas_decimais = 0;
                                fQtd.Vl_default = 1;
                                fQtd.Vl_Minimo = 1;
                                fQtd.St_permitirValorZero = false;
                                if (fQtd.ShowDialog() == DialogResult.OK)
                                    qtd_etiquetas = Convert.ToInt32(fQtd.Quantidade);
                            }
                            TEtiquetaZebra.ImpEtiquetaL4((bsProduto.Current as CamadaDados.Estoque.Cadastros.TRegistro_CadProduto).CD_Produto.Trim() +
                                                                (bsProduto.Current as CamadaDados.Estoque.Cadastros.TRegistro_CadProduto).DS_Produto.Trim(),
                                                                (bsProduto.Current as CamadaDados.Estoque.Cadastros.TRegistro_CadProduto).lCodBarra.Count > 0 ?
                                                                (bsProduto.Current as CamadaDados.Estoque.Cadastros.TRegistro_CadProduto).lCodBarra[0].Cd_codbarra : string.Empty,
                                                                qtd_etiquetas,
                                                                rTerminal.Porta_imptick);
                        }
                        else if (rTerminal.Layoutetiqueta.Trim().Equals("5"))
                        {
                            int qtd_etiquetas = 1;
                            using (TFQuantidade fQtd = new TFQuantidade())
                            {
                                fQtd.Casas_decimais = 0;
                                fQtd.Vl_default = 1;
                                fQtd.Vl_Minimo = 1;
                                fQtd.St_permitirValorZero = false;
                                if (fQtd.ShowDialog() == DialogResult.OK)
                                    qtd_etiquetas = Convert.ToInt32(fQtd.Quantidade);
                            }
                            TEtiquetaZebra.ImpEtiquetaL5((bsProduto.Current as CamadaDados.Estoque.Cadastros.TRegistro_CadProduto).CD_Produto.Trim() + "-" +
                                                                (bsProduto.Current as CamadaDados.Estoque.Cadastros.TRegistro_CadProduto).DS_Produto.Trim(),
                                                                (bsProduto.Current as CamadaDados.Estoque.Cadastros.TRegistro_CadProduto).lCodBarra.Count > 0 ?
                                                                (bsProduto.Current as CamadaDados.Estoque.Cadastros.TRegistro_CadProduto).lCodBarra[0].Cd_codbarra : string.Empty,
                                                                obj == null ? decimal.Zero : decimal.Parse(obj.ToString()),
                                                                qtd_etiquetas,
                                                                rTerminal.Porta_imptick);
                        }
                        else if (rTerminal.Layoutetiqueta.Trim().Equals("6"))
                        {
                            int qtd_etiquetas = 1;
                            using (TFQuantidade fQtd = new TFQuantidade())
                            {
                                fQtd.Casas_decimais = 0;
                                fQtd.Vl_default = 1;
                                fQtd.Vl_Minimo = 1;
                                fQtd.St_permitirValorZero = false;
                                if (fQtd.ShowDialog() == DialogResult.OK)
                                    qtd_etiquetas = Convert.ToInt32(fQtd.Quantidade);
                            }

                            Utils.TEtiquetaZebra.ImpEtiquetaL6(decimal.Parse((bsProduto.Current as CamadaDados.Estoque.Cadastros.TRegistro_CadProduto).CD_Produto.SoNumero()),
                                                                (bsProduto.Current as CamadaDados.Estoque.Cadastros.TRegistro_CadProduto).DS_Produto.Trim(),
                                                                (bsProduto.Current as CamadaDados.Estoque.Cadastros.TRegistro_CadProduto).lCodBarra.Count > 0 ?
                                                                (bsProduto.Current as CamadaDados.Estoque.Cadastros.TRegistro_CadProduto).lCodBarra[0].Cd_codbarra : string.Empty,
                                                                obj == null ? decimal.Zero : decimal.Parse(obj.ToString()),
                                                                qtd_etiquetas,
                                                                rTerminal.Porta_imptick);
                        }
                    }
                    catch (Exception ex)
                    { MessageBox.Show("Erro imprimir etiqueta: " + ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }else
                if (rTerminal.Tp_impetiqueta.Trim().ToUpper().Equals("A"))
                {
                    string CD_TabelaPreco = string.Empty;
                    //Buscar tabela de preco frente caixa
                    if (Convert.ToDecimal(new CamadaDados.Diversos.TCD_CadTbPreco().BuscarEscalar(null, "COUNT(*)").ToString()) > 1)
                    {
                        EditDefault CD = new EditDefault();
                        CD.NM_Campo = "Cd_tabelaPreco";
                        CD.NM_CampoBusca = "Cd_tabelaPreco";
                        UtilPesquisa.BTN_BUSCA("DS_TabelaPreco|Descrição da Tabela de Preço|300;CD_TabelaPreco|Cd. Tab.Preço|80"
                                             , new EditDefault[] { CD },
                                             new CamadaDados.Diversos.TCD_CadTbPreco(),
                                             string.Empty);
                        if (!string.IsNullOrEmpty(CD.Text))
                            CD_TabelaPreco = CD.Text;
                        else
                        {
                            MessageBox.Show("Selecione a tabela preço para imprimir etiqueta!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    }
                    else
                    {
                        object obj_tab = new CamadaDados.Faturamento.Cadastros.TCD_CFGCupomFiscal().BuscarEscalar(null, "a.cd_tabelapreco");
                        CD_TabelaPreco = obj_tab.ToString();
                    }

                    InputBox inp = new InputBox(string.Empty, "Quantidade Copias.");
                    string ret = inp.Show();
                    int copias = 1;
                    try
                    {
                        copias = int.Parse(ret);
                    }
                    catch { }
                    TpBusca[] filtro = new TpBusca[1];
                    filtro[0].vNM_Campo = "a.cd_produto";
                    filtro[0].vOperador = "=";
                    filtro[0].vVL_Busca = "'" + (bsProduto.Current as CamadaDados.Estoque.Cadastros.TRegistro_CadProduto).CD_Produto.Trim() + "'";
                    if (!string.IsNullOrEmpty(CD_TabelaPreco))
                    {
                        Array.Resize(ref filtro, filtro.Length + 1);
                        filtro[filtro.Length - 1].vNM_Campo = "a.cd_tabelapreco";
                        filtro[filtro.Length - 1].vOperador = "=";
                        filtro[filtro.Length - 1].vVL_Busca = "'" + CD_TabelaPreco.Trim() + "'";
                    }
                    object obj = new CamadaDados.Estoque.TCD_LanPrecoItem().BuscarEscalar(filtro, "a.vl_precovenda");
                    CamadaDados.Estoque.Cadastros.TList_CodBarra lCod = new CamadaDados.Estoque.Cadastros.TList_CodBarra();
                    for (int i = 0; i < copias; i++)
                        lCod.Add(new CamadaDados.Estoque.Cadastros.TRegistro_CodBarra()
                        {
                            Cd_codbarra = (bsCodBarra.Current as CamadaDados.Estoque.Cadastros.TRegistro_CodBarra).Cd_codbarra,
                            Cd_produto = (bsProduto.Current as CamadaDados.Estoque.Cadastros.TRegistro_CadProduto).CD_Produto,
                            Ds_produto = (bsProduto.Current as CamadaDados.Estoque.Cadastros.TRegistro_CadProduto).DS_Produto,
                            cd_unidade = (bsProduto.Current as CamadaDados.Estoque.Cadastros.TRegistro_CadProduto).CD_Unidade,
                            ds_unidade = (bsProduto.Current as CamadaDados.Estoque.Cadastros.TRegistro_CadProduto).DS_Unidade,
                            uni = (bsProduto.Current as CamadaDados.Estoque.Cadastros.TRegistro_CadProduto).Sigla_unidade,
                            Vl_venda = obj == null ? decimal.Zero : decimal.Parse(obj.ToString())
                        });
                    Relatorio Relatorio = new Relatorio();
                    Relatorio.Altera_Relatorio = Altera_Relatorio;

                    //DADOS PERTINENTES PARA A GERAÇÂO DO RELATORIO
                    Relatorio.Nome_Relatorio = Name;
                    Relatorio.NM_Classe = Name;
                    Relatorio.Modulo = Tag.ToString().Substring(0, 3); 

                    BindingSource bs = new BindingSource();
                    bs.DataSource = lCod;
                    Relatorio.DTS_Relatorio = bs;
                    Relatorio.Nome_Relatorio = "FLanEtiqueta";
                    Relatorio.NM_Classe = "FLanEtiqueta";
                    Relatorio.Ident = "FLanEtiqueta";
                    Relatorio.Modulo = "EST";
                    
                    if (!Altera_Relatorio)
                    {
                        //Chamar tela de gerenciamento de impressao
                        using (TFGerenciadorImpressao fImp = new TFGerenciadorImpressao())
                        {
                            fImp.St_enabled_enviaremail = true;  
                            fImp.pMensagem = ("PRODUTO Nº " + (bsProduto.Current as CamadaDados.Estoque.Cadastros.TRegistro_CadProduto).CD_Produto
                                + " VERSÃO Nº " + (bsProduto.Current as CamadaDados.Estoque.Cadastros.TRegistro_CadProduto).DS_Produto);
                            if ((fImp.ShowDialog() == DialogResult.OK) || (fImp.pSt_enviaremail))
                                Relatorio.Gera_Relatorio("Etiqueta",
                                                         fImp.pSt_imprimir,
                                                         fImp.pSt_visualizar,
                                                         fImp.pSt_enviaremail,
                                                         fImp.pSt_exportPdf,
                                                         fImp.Path_exportPdf,
                                                         fImp.pDestinatarios,
                                                         null,
                                                         ("PRODUTO Nº " + (bsProduto.Current as CamadaDados.Estoque.Cadastros.TRegistro_CadProduto).CD_Produto
                                                            + " VERSÃO Nº " + (bsProduto.Current as CamadaDados.Estoque.Cadastros.TRegistro_CadProduto).DS_Produto),
                                                         fImp.pDs_mensagem);
                        }
                    }
                    else
                    {
                        Relatorio.Gera_Relatorio();
                        Altera_Relatorio = false;
                    }


                }
                else
                    using (TFGerenciadorImpressao fImp = new TFGerenciadorImpressao())
                    {
                        Relatorio Rel = new Relatorio();
                        Rel.Altera_Relatorio = Altera_Relatorio;
                        Rel.Nome_Relatorio = "TFProduto";
                        Rel.NM_Classe = "TFProduto";
                        Rel.Ident = "REL_CODBARRA_CADPRODUTO";
                        Rel.Modulo = "EST";
                        //Numero de copias
                        InputBox inp = new InputBox(string.Empty, "Quantidade Copias.");
                        string ret = inp.Show();
                        int copias = 1;
                        try
                        {
                            copias = int.Parse(ret);
                        }
                        catch { }
                        string CD_TabelaPreco = string.Empty;
                        //Buscar tabela de preco frente caixa
                        if (Convert.ToDecimal(new CamadaDados.Diversos.TCD_CadTbPreco().BuscarEscalar(null, "COUNT(*)").ToString()) > 1)
                        {
                            EditDefault CD = new EditDefault();
                            CD.NM_Campo = "Cd_tabelaPreco";
                            CD.NM_CampoBusca = "Cd_tabelaPreco";
                            UtilPesquisa.BTN_BUSCA("DS_TabelaPreco|Descrição da Tabela de Preço|300;CD_TabelaPreco|Cd. Tab.Preço|80"
                                                 , new EditDefault[] { CD },
                                                 new CamadaDados.Diversos.TCD_CadTbPreco(),
                                                 string.Empty);
                            if (!string.IsNullOrEmpty(CD.Text))
                                CD_TabelaPreco = CD.Text;
                            else
                            {
                                MessageBox.Show("Selecione a tabela preço para imprimir etiqueta!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                        }
                        else
                        {
                            object obj_tab = new CamadaDados.Faturamento.Cadastros.TCD_CFGCupomFiscal().BuscarEscalar(null, "a.cd_tabelapreco");
                            CD_TabelaPreco = obj_tab.ToString();
                        }

                        TpBusca[] filtro = new TpBusca[1];
                        filtro[0].vNM_Campo = "a.cd_produto";
                        filtro[0].vOperador = "=";
                        filtro[0].vVL_Busca = "'" + (bsProduto.Current as CamadaDados.Estoque.Cadastros.TRegistro_CadProduto).CD_Produto.Trim() + "'";
                        if (!string.IsNullOrEmpty(CD_TabelaPreco))
                        {
                            Array.Resize(ref filtro, filtro.Length + 1);
                            filtro[filtro.Length - 1].vNM_Campo = "a.cd_tabelapreco";
                            filtro[filtro.Length - 1].vOperador = "=";
                            filtro[filtro.Length - 1].vVL_Busca = "'" + CD_TabelaPreco.Trim() + "'";
                        }
                        object obj = new CamadaDados.Estoque.TCD_LanPrecoItem().BuscarEscalar(filtro, "a.vl_precovenda");
                        CamadaDados.Estoque.Cadastros.TList_CodBarra lCod = new CamadaDados.Estoque.Cadastros.TList_CodBarra();
                        for (int i = 0; i < copias; i++)
                            lCod.Add(new CamadaDados.Estoque.Cadastros.TRegistro_CodBarra()
                            {
                                Cd_codbarra = (bsCodBarra.Current as CamadaDados.Estoque.Cadastros.TRegistro_CodBarra).Cd_codbarra,
                                Cd_produto = (bsProduto.Current as CamadaDados.Estoque.Cadastros.TRegistro_CadProduto).CD_Produto,
                                Ds_produto = (bsProduto.Current as CamadaDados.Estoque.Cadastros.TRegistro_CadProduto).DS_Produto,
                                cd_unidade = (bsProduto.Current as CamadaDados.Estoque.Cadastros.TRegistro_CadProduto).CD_Unidade,
                                ds_unidade = (bsProduto.Current as CamadaDados.Estoque.Cadastros.TRegistro_CadProduto).DS_Unidade,
                                uni = (bsProduto.Current as CamadaDados.Estoque.Cadastros.TRegistro_CadProduto).Sigla_unidade,
                                Vl_venda = obj == null ? decimal.Zero : decimal.Parse(obj.ToString())
                            });
                        BindingSource bs = new BindingSource();
                        bs.DataSource = lCod;
                        Rel.DTS_Relatorio = bs;
                        fImp.St_enabled_enviaremail = true;
                        fImp.pCd_clifor = string.Empty;
                        fImp.pMensagem = "IMPRESSÃO CODIGO BARRA";

                        if (Altera_Relatorio)
                        {
                            Rel.Gera_Relatorio(string.Empty,
                                               fImp.pSt_imprimir,
                                               fImp.pSt_visualizar,
                                               fImp.pSt_enviaremail,
                                               fImp.pSt_exportPdf,
                                               fImp.Path_exportPdf,
                                               fImp.pDestinatarios,
                                               null,
                                               "IMPRESSÃO CODIGO BARRA",
                                               fImp.pDs_mensagem);
                            Altera_Relatorio = false;
                           // Rel.Gera_Relatorio();
                        }
                        else
                            if ((fImp.ShowDialog() == DialogResult.OK) || (fImp.pSt_enviaremail))
                                Rel.Gera_Relatorio(string.Empty,
                                                   fImp.pSt_imprimir,
                                                   fImp.pSt_visualizar,
                                                   fImp.pSt_enviaremail,
                                                   fImp.pSt_exportPdf,
                                                   fImp.Path_exportPdf,
                                                   null,
                                                   fImp.pDestinatarios,
                                                   "IMPRESSÃO CODIGO BARRA",
                                                   fImp.pDs_mensagem);
                    }
            }
            else MessageBox.Show("Obrigatorio selecionar produto para imprimir etiqueta.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        public static DialogResult InputBox(string title, string promptText)
        {
            Form form = new Form();
            Label label = new Label();
            Button buttonIncluir = new Button();
            Button buttonRelacionar = new Button();

            form.Text = title;
            label.Text = promptText;

            buttonIncluir.Text = "TOLEDO";
            buttonRelacionar.Text = "FILISOLA";
            buttonIncluir.DialogResult = DialogResult.Yes;
            buttonRelacionar.DialogResult = DialogResult.No;

            label.SetBounds(9, 20, 372, 13);
            buttonIncluir.SetBounds(228, 72, 75, 23);
            buttonRelacionar.SetBounds(309, 72, 75, 23);

            label.AutoSize = true;
            buttonIncluir.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonRelacionar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

            form.ClientSize = new Size(396, 107);
            form.Controls.AddRange(new Control[] { label, buttonIncluir, buttonRelacionar });
            form.ClientSize = new Size(Math.Max(300, label.Right + 10), form.ClientSize.Height);
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.MinimizeBox = false;
            form.MaximizeBox = false;
            form.CancelButton = buttonIncluir;
            form.CancelButton = buttonRelacionar;

            DialogResult dialogResult = form.ShowDialog();
            return dialogResult;
        }

        private void bb_gerarTxt_Click(object sender, EventArgs e)
        {

            CamadaDados.Faturamento.Cadastros.TList_CFGCupomFiscal lCfg =
                CamadaNegocio.Faturamento.Cadastros.TCN_CFGCupomFiscal.Buscar(string.Empty,
                                                                              null);

            if (lCfg.Count > 0)
            {
                //Buscar Produtos com seus devidos precos
                CamadaDados.Estoque.TList_LanPrecoItem lItens =
                    new CamadaDados.Estoque.TCD_LanPrecoItem().Select(
                        new TpBusca[]
                        {
                            new TpBusca()
                            {
                                vNM_Campo = "isnull(b.ST_ExpBalanca, 'N')",
                                vOperador = "=",
                                vVL_Busca = "'S'"
                            },
                            new TpBusca()
                            {
                                vNM_Campo = "isnull(b.ST_Registro, 'C')",
                                vOperador = "=",
                                vVL_Busca = "'A'"
                            },
                            new TpBusca()
                            {
                                vNM_Campo = "a.cd_empresa",
                                vOperador = "=",
                                vVL_Busca = "'" + lCfg[0].Cd_empresa.Trim() + "'"
                            },
                            new TpBusca()
                            {
                                vNM_Campo = "a.CD_TabelaPreco",
                                vOperador = "=",
                                vVL_Busca = "'" + lCfg[0].Cd_tabelapreco.Trim() + "'"
                            }
                        }, 0, string.Empty);


                if (lItens.Count > 0)
                    using (TFItensBalanca fItens = new TFItensBalanca())
                    {
                        fItens.Itens = lItens;
                        fItens.ShowDialog();
                    }
                else
                    MessageBox.Show("Não existem produtos configurados para exportar para balança!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Não existe configuração frente de caixa.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void bb_imfichatec_Click(object sender, EventArgs e)
        {
            PrintFichaTec();
        }

        private void Nr_ncm_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.ncm|=|'" + Nr_ncm.Text.Trim() + "'";
            UtilPesquisa.EDIT_LEAVE(vColunas, new EditDefault[] { Nr_ncm },
                                    new CamadaDados.Fiscal.TCD_CadNCM());
        }

        private void bb_ncm_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_ncm|Descrição NCM|250;" +
                             "a.ncm|NCM|80";
            UtilPesquisa.BTN_BUSCA(vColunas, new EditDefault[] { Nr_ncm },
                                    new CamadaDados.Fiscal.TCD_CadNCM(), string.Empty );
        }

        private void bb_inserirficha_Click(object sender, EventArgs e)
        {
            InserirItemFicha();
        }

        private void bb_alterarficha_Click(object sender, EventArgs e)
        {
            AlterarItemFicha();
        }

        private void bb_excluirficha_Click(object sender, EventArgs e)
        {
            ExcluirItemFicha();
        }
    }
}
