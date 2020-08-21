using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using FormBusca;
using CamadaDados.Almoxarifado;
using Utils;
using Componentes;

namespace Estoque.Cadastros
{
    public partial class TFProduto : Form
    {
        private bool Altera_Relatorio = false;

        private CamadaDados.Estoque.Cadastros.TRegistro_CadProduto rprod;
        public CamadaDados.Estoque.Cadastros.TRegistro_CadProduto rProd
        {
            get
            {
                if (bsProduto.Current != null)
                    return bsProduto.Current as CamadaDados.Estoque.Cadastros.TRegistro_CadProduto;
                else
                    return null;
            }
            set { rprod = value; }
        }
        public string vDS_produto = string.Empty;
        public string vProduto = string.Empty;
        public string vCd_unidade = string.Empty;
        public string vDS_unidade = string.Empty;
        public string vCd_grupo = string.Empty;
        public string vDS_grupo = string.Empty;
        public string vCd_marca = string.Empty;
        public string vDS_marca = string.Empty;
        public string vTp_produto = string.Empty;
        public string vDS_tpproduto = string.Empty;
        public string vCd_CondFiscal_Produto = string.Empty;
        public string vDS_CondFiscal_Produto = string.Empty;
        public string vId_tpservico = string.Empty;
        public string vDS_tpservico = string.Empty;
        public string vId_genero = string.Empty;
        public string vDS_genero = string.Empty;
        public string vCd_anp = string.Empty;
        public string vDS_anp = string.Empty;
        public string vSigla = string.Empty;
        public string vSigla_unidade = string.Empty;
        public string vTp_item = string.Empty;
        public bool vSt_servico = false;
        public bool vSt_composto = false;
        public bool vSt_materia = false;
        public bool vSt_embalagem = false;
        public string vNrNcm = string.Empty;
        public string vDsNcm = string.Empty;
        public bool St_copiar = false;
        public CamadaDados.Estoque.Cadastros.TList_FichaTecProduto lFicha
        { get; set; }

        public TFProduto()
        {
            InitializeComponent();

            System.Collections.ArrayList cbx = new System.Collections.ArrayList();
            cbx.Add(new TDataCombo("MERCADORIA PARA REVENDA", "00"));
            cbx.Add(new TDataCombo("MATERIA-PRIMA", "01"));
            cbx.Add(new TDataCombo("EMBALAGEM", "02"));
            cbx.Add(new TDataCombo("PRODUTO EM PROCESSO", "03"));
            cbx.Add(new TDataCombo("PRODUTO ACABADO", "04"));
            cbx.Add(new TDataCombo("SUBPRODUTO", "05"));
            cbx.Add(new TDataCombo("PRODUTO INTERMEDIARIO", "06"));
            cbx.Add(new TDataCombo("MATERIAL DE USO E CONSUMO", "07"));
            cbx.Add(new TDataCombo("ATIVO IMOBILIZADO", "08"));
            cbx.Add(new TDataCombo("SERVICOS", "09"));
            cbx.Add(new TDataCombo("OUTROS INSUMOS", "10"));
            cbx.Add(new TDataCombo("OUTRAS", "99"));
            tp_item.DataSource = cbx;
            tp_item.ValueMember = "Value";
            tp_item.DisplayMember = "Display";

            System.Collections.ArrayList cbx1 = new System.Collections.ArrayList();
            cbx1.Add(new TDataCombo("PERCENTUAL", "P"));
            cbx1.Add(new TDataCombo("VALOR", "V"));
            tp_comissao.DataSource = cbx1;
            tp_comissao.ValueMember = "Value";
            tp_comissao.DisplayMember = "Display";

            System.Collections.ArrayList cbx2 = new System.Collections.ArrayList();
            cbx2.Add(new TDataCombo("HORAS", "0"));
            cbx2.Add(new TDataCombo("DIAS", "1"));
            cbx2.Add(new TDataCombo("MÊS", "2"));
            cbx2.Add(new TDataCombo("ANO", "3"));
            TP_VidaUtil.DataSource = cbx2;
            TP_VidaUtil.ValueMember = "Value";
            TP_VidaUtil.DisplayMember = "Display";

            System.Collections.ArrayList cbx3 = new System.Collections.ArrayList();
            cbx3.Add(new TDataCombo("Etanol Hidratado Aditivado", "1"));
            cbx3.Add(new TDataCombo("Etanol Hidratado Comum", "2"));
            cbx3.Add(new TDataCombo("Gasolina C Aditivada", "3"));
            cbx3.Add(new TDataCombo("Gasolina C Comum", "4"));
            cbx3.Add(new TDataCombo("Gasolina C Premium", "5"));
            cbx3.Add(new TDataCombo("Óleo Diesel A Maritimo", "6"));
            cbx3.Add(new TDataCombo("Óleo Diesel B", "7"));
            cbx3.Add(new TDataCombo("Óleo Diesel B Aditivado", "8"));
            cbx3.Add(new TDataCombo("Óleo Diesel B S10", "9"));
            cbx3.Add(new TDataCombo("Óleo Diesel B S10 Aditivado", "10"));
            cbx3.Add(new TDataCombo("Querosene Iluminante", "11"));
            tp_combustivel.DataSource = cbx3;
            tp_combustivel.DisplayMember = "Display";
            tp_combustivel.ValueMember = "Value";
        }

        private void afterGrava()
        {
            if (pDadosProd.validarCampoObrigatorio())
            {
                if (!string.IsNullOrEmpty(id_caracteristicaH.Text) &&
                    (bsProduto.Current as CamadaDados.Estoque.Cadastros.TRegistro_CadProduto).rSaldoEst != null)
                    using (Proc_Commoditties.TFGradeProduto fGrade = new Proc_Commoditties.TFGradeProduto())
                    {
                        fGrade.pId_caracteristica = id_caracteristicaH.Text;
                        fGrade.pCd_empresa = CD_Empresa.Text;
                        fGrade.pCd_produto = CD_Produto.Text;
                        fGrade.pDs_produto = DS_Produto.Text;
                        fGrade.pTp_movimento = "E";
                        fGrade.pQuantidade = (bsProduto.Current as CamadaDados.Estoque.Cadastros.TRegistro_CadProduto).rSaldoEst.Qtd_entrada;
                        if (fGrade.ShowDialog() == DialogResult.OK)
                            fGrade.lGrade.ForEach(p => (bsProduto.Current as CamadaDados.Estoque.Cadastros.TRegistro_CadProduto).rSaldoEst.lGrade.Add(p));
                        else
                        {
                            MessageBox.Show("Obrigatório informar grade.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    }
                if (!string.IsNullOrEmpty(Nr_patrimonio.Text))
                    (bsProduto.Current as CamadaDados.Estoque.Cadastros.TRegistro_CadProduto).lPatrimonio.Add(
                        bsPatrimonio.Current as CamadaDados.Estoque.Cadastros.TRegistro_CadPatrimonio);
                DialogResult = DialogResult.OK;
            }
        }

        private void preencherCampos()
        {
            DS_Produto.Text = vProduto;
            CD_Unidade.Text = vCd_unidade;
            ds_unidade.Text = vDS_unidade;
            CD_Grupo.Text = vCd_grupo;
            DS_Grupo.Text = vDS_grupo;
            CD_Marca.Text = vCd_marca;
            DS_Marca.Text = vDS_marca;
            TP_Produto.Text = vTp_produto;
            ds_tpproduto.Text = vDS_tpproduto;
            CD_CondFiscal_Produto.Text = vCd_CondFiscal_Produto;
            ds_condfiscal_produto.Text = vDS_CondFiscal_Produto;
            id_tpservico.Text = vId_tpservico;
            ds_tpservico.Text = vDS_tpservico;
            id_genero.Text = vId_genero;
            ds_genero.Text = vDS_genero;
            cd_anp.Text = vCd_anp;
            ds_anp.Text = vDS_anp;
            Sigla.Text = vSigla;
            sigla_unidade.Text = vSigla_unidade;
            tp_item.Text = vTp_item;
            st_servico.Checked = vSt_servico;
            st_industrializado.Checked = vSt_composto;
            st_mprima.Checked = vSt_materia;
            st_embalagem.Checked = vSt_embalagem;
            ncm.Text = vNrNcm;
            ds_ncm.Text = vDsNcm;
            (bsProduto.Current as CamadaDados.Estoque.Cadastros.TRegistro_CadProduto).lFicha = lFicha;

        }

        private void capturarImagem()
        {
            using (WebCamLibrary.TFCapturaVideo fCap = new WebCamLibrary.TFCapturaVideo())
            {
                if (fCap.ShowDialog() == DialogResult.OK)
                {

                    pImagens.Image = fCap.Img;
                    pImagens.SizeMode = PictureBoxSizeMode.StretchImage;
                    (bsProduto.Current as CamadaDados.Estoque.Cadastros.TRegistro_CadProduto).LImagens.Add(new CamadaDados.Estoque.Cadastros.TRegistro_CadProduto_Imagens()
                    {
                        Cd_produto = CD_Produto.Text,
                        Img = Convercao_imagem.imageToByteArray(fCap.Img)
                    });
                    bsProduto.ResetCurrentItem();
                }
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
                        {
                            if ((bsProduto.Current as CamadaDados.Estoque.Cadastros.TRegistro_CadProduto).lFicha.Exists(p => p.Cd_item.Trim().Equals(fItem.rFicha.Cd_item)))
                                (bsProduto.Current as CamadaDados.Estoque.Cadastros.TRegistro_CadProduto).lFicha.Find(p => p.Cd_item.Trim().Equals(fItem.rFicha.Cd_item)).Quantidade = fItem.rFicha.Quantidade;
                            else
                                (bsProduto.Current as CamadaDados.Estoque.Cadastros.TRegistro_CadProduto).lFicha.Add(fItem.rFicha);
                            bsProduto.ResetCurrentItem();
                        }
                }
        }

        private void AlterarItemFicha()
        {
            if (bsFicha.Current != null)
            {
                CamadaDados.Estoque.Cadastros.TRegistro_FichaTecProduto rAux = new CamadaDados.Estoque.Cadastros.TRegistro_FichaTecProduto();
                rAux.Cd_produto = (bsFicha.Current as CamadaDados.Estoque.Cadastros.TRegistro_FichaTecProduto).Cd_produto;
                rAux.Cd_item = (bsFicha.Current as CamadaDados.Estoque.Cadastros.TRegistro_FichaTecProduto).Cd_item;
                rAux.Cd_unditem = (bsFicha.Current as CamadaDados.Estoque.Cadastros.TRegistro_FichaTecProduto).Cd_unditem;
                rAux.Ds_item = (bsFicha.Current as CamadaDados.Estoque.Cadastros.TRegistro_FichaTecProduto).Ds_item;
                rAux.Ds_produto = (bsFicha.Current as CamadaDados.Estoque.Cadastros.TRegistro_FichaTecProduto).Ds_produto;
                rAux.Ds_unditem = (bsFicha.Current as CamadaDados.Estoque.Cadastros.TRegistro_FichaTecProduto).Ds_unditem;
                rAux.Quantidade = (bsFicha.Current as CamadaDados.Estoque.Cadastros.TRegistro_FichaTecProduto).Quantidade;
                rAux.Sg_unditem = (bsFicha.Current as CamadaDados.Estoque.Cadastros.TRegistro_FichaTecProduto).Sg_unditem;
                rAux.Vl_precovenda = (bsFicha.Current as CamadaDados.Estoque.Cadastros.TRegistro_FichaTecProduto).Vl_precovenda;
                using (TFItensFichaTec fItem = new TFItensFichaTec())
                {
                    fItem.pCd_produto = (bsProduto.Current as CamadaDados.Estoque.Cadastros.TRegistro_CadProduto).CD_Produto;
                    fItem.rFicha = bsFicha.Current as CamadaDados.Estoque.Cadastros.TRegistro_FichaTecProduto;
                    if (fItem.ShowDialog() != DialogResult.OK)
                    {
                        (bsFicha.Current as CamadaDados.Estoque.Cadastros.TRegistro_FichaTecProduto).Cd_produto = rAux.Cd_produto;
                        (bsFicha.Current as CamadaDados.Estoque.Cadastros.TRegistro_FichaTecProduto).Cd_item = rAux.Cd_item;
                        (bsFicha.Current as CamadaDados.Estoque.Cadastros.TRegistro_FichaTecProduto).Cd_unditem = rAux.Cd_unditem;
                        (bsFicha.Current as CamadaDados.Estoque.Cadastros.TRegistro_FichaTecProduto).Ds_item = rAux.Ds_item;
                        (bsFicha.Current as CamadaDados.Estoque.Cadastros.TRegistro_FichaTecProduto).Ds_produto = rAux.Ds_produto;
                        (bsFicha.Current as CamadaDados.Estoque.Cadastros.TRegistro_FichaTecProduto).Ds_unditem = rAux.Ds_unditem;
                        (bsFicha.Current as CamadaDados.Estoque.Cadastros.TRegistro_FichaTecProduto).Quantidade = rAux.Quantidade;
                        (bsFicha.Current as CamadaDados.Estoque.Cadastros.TRegistro_FichaTecProduto).Sg_unditem = rAux.Sg_unditem;
                        (bsFicha.Current as CamadaDados.Estoque.Cadastros.TRegistro_FichaTecProduto).Vl_precovenda = rAux.Vl_precovenda;
                    }
                    bsProduto.ResetCurrentItem();
                }
            }
            else
                MessageBox.Show("Obrigatorio selecionar item ficha tecnica para alterar.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ExcluirItemFicha()
        {
            if (bsFicha.Current != null)
            {
                if (MessageBox.Show("Confirma exclusão do item selecionado?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                     MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    (bsProduto.Current as CamadaDados.Estoque.Cadastros.TRegistro_CadProduto).lFichaApagar.Add(bsFicha.Current as CamadaDados.Estoque.Cadastros.TRegistro_FichaTecProduto);
                    bsFicha.RemoveCurrent();
                }
            }
            else
                MessageBox.Show("Obrigatorio selecionar item ficha tecnica para excluir.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void InserirQtdEstoque()
        {
            if (bsProduto.Current != null)
                using (TFCadQtdEstoque fQtd = new TFCadQtdEstoque())
                {
                    fQtd.Sigla_unidade = sigla_unidade.Text;
                    if (fQtd.ShowDialog() == DialogResult.OK)
                        if (fQtd.rQtdEstoque != null)
                        {
                            if ((bsProduto.Current as CamadaDados.Estoque.Cadastros.TRegistro_CadProduto).lQtdEstoque.Exists(p => p.Cd_empresa.Trim().Equals(fQtd.rQtdEstoque.Cd_empresa)))
                            {
                                (bsProduto.Current as CamadaDados.Estoque.Cadastros.TRegistro_CadProduto).lQtdEstoque.Find(p => p.Cd_empresa.Trim().Equals(fQtd.rQtdEstoque.Cd_empresa)).Qt_max_estoque = fQtd.rQtdEstoque.Qt_max_estoque;
                                (bsProduto.Current as CamadaDados.Estoque.Cadastros.TRegistro_CadProduto).lQtdEstoque.Find(p => p.Cd_empresa.Trim().Equals(fQtd.rQtdEstoque.Cd_empresa)).Qt_min_estoque = fQtd.rQtdEstoque.Qt_min_estoque;
                            }
                            else
                                (bsProduto.Current as CamadaDados.Estoque.Cadastros.TRegistro_CadProduto).lQtdEstoque.Add(fQtd.rQtdEstoque);
                            bsProduto.ResetCurrentItem();
                        }
                }
        }

        private void AlterarQtdEstoque()
        {
            if (bsQtdEstoque.Current != null)
            {
                CamadaDados.Estoque.Cadastros.TRegistro_Produto_QtdEstoque rAux = new CamadaDados.Estoque.Cadastros.TRegistro_Produto_QtdEstoque();
                rAux.Cd_empresa = (bsQtdEstoque.Current as CamadaDados.Estoque.Cadastros.TRegistro_Produto_QtdEstoque).Cd_empresa;
                rAux.Nm_empresa = (bsQtdEstoque.Current as CamadaDados.Estoque.Cadastros.TRegistro_Produto_QtdEstoque).Nm_empresa;
                rAux.Cd_produto = (bsQtdEstoque.Current as CamadaDados.Estoque.Cadastros.TRegistro_Produto_QtdEstoque).Cd_produto;
                rAux.Ds_produto = (bsQtdEstoque.Current as CamadaDados.Estoque.Cadastros.TRegistro_Produto_QtdEstoque).Ds_produto;
                rAux.Sigla_unidade = (bsQtdEstoque.Current as CamadaDados.Estoque.Cadastros.TRegistro_Produto_QtdEstoque).Sigla_unidade;
                rAux.Qt_min_estoque = (bsQtdEstoque.Current as CamadaDados.Estoque.Cadastros.TRegistro_Produto_QtdEstoque).Qt_min_estoque;
                rAux.Qt_max_estoque = (bsQtdEstoque.Current as CamadaDados.Estoque.Cadastros.TRegistro_Produto_QtdEstoque).Qt_max_estoque;
                using (TFCadQtdEstoque fItem = new TFCadQtdEstoque())
                {
                    fItem.rQtdEstoque = bsQtdEstoque.Current as CamadaDados.Estoque.Cadastros.TRegistro_Produto_QtdEstoque;
                    if (fItem.ShowDialog() != DialogResult.OK)
                    {
                        (bsQtdEstoque.Current as CamadaDados.Estoque.Cadastros.TRegistro_Produto_QtdEstoque).Cd_empresa = rAux.Cd_empresa;
                        (bsQtdEstoque.Current as CamadaDados.Estoque.Cadastros.TRegistro_Produto_QtdEstoque).Nm_empresa = rAux.Nm_empresa;
                        (bsQtdEstoque.Current as CamadaDados.Estoque.Cadastros.TRegistro_Produto_QtdEstoque).Cd_produto = rAux.Cd_produto;
                        (bsQtdEstoque.Current as CamadaDados.Estoque.Cadastros.TRegistro_Produto_QtdEstoque).Ds_produto = rAux.Ds_produto;
                        (bsQtdEstoque.Current as CamadaDados.Estoque.Cadastros.TRegistro_Produto_QtdEstoque).Sigla_unidade = rAux.Sigla_unidade;
                        (bsQtdEstoque.Current as CamadaDados.Estoque.Cadastros.TRegistro_Produto_QtdEstoque).Qt_min_estoque = rAux.Qt_min_estoque;
                        (bsQtdEstoque.Current as CamadaDados.Estoque.Cadastros.TRegistro_Produto_QtdEstoque).Qt_max_estoque = rAux.Qt_max_estoque;
                    }
                    bsProduto.ResetCurrentItem();
                }
            }
            else
                MessageBox.Show("Obrigatorio selecionar item para alterar.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ExcluirQtdEstoque()
        {
            if (bsQtdEstoque.Current != null)
            {
                if (MessageBox.Show("Confirma exclusão do item selecionado?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                     MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    (bsProduto.Current as CamadaDados.Estoque.Cadastros.TRegistro_CadProduto).lQtdEstoqueDel.Add(bsQtdEstoque.Current as CamadaDados.Estoque.Cadastros.TRegistro_Produto_QtdEstoque);
                    bsQtdEstoque.RemoveCurrent();
                }
            }
            else
                MessageBox.Show("Obrigatorio selecionar item para excluir.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void InserirCodBarra()
        {
            if (bsProduto.Current != null)
                using (TFCodBarra fCod = new TFCodBarra())
                {
                    if (fCod.ShowDialog() == DialogResult.OK)
                        if (!string.IsNullOrEmpty(fCod.pCd_codbarra))
                        {
                            if (!(bsProduto.Current as CamadaDados.Estoque.Cadastros.TRegistro_CadProduto).lCodBarra.Exists(p => p.Cd_codbarra.Trim().Equals(fCod.pCd_codbarra.Trim())))
                            {
                                (bsProduto.Current as CamadaDados.Estoque.Cadastros.TRegistro_CadProduto).lCodBarra.Add(new CamadaDados.Estoque.Cadastros.TRegistro_CodBarra()
                                {
                                    Cd_codbarra = fCod.pCd_codbarra
                                });
                                bsProduto.ResetCurrentItem();
                            }
                        }
                }
        }

        private void ExcluirCodBarra()
        {
            if (bsCodBarra.Current != null)
            {
                if (MessageBox.Show("Confirma exclusão do item selecionado?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                     MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    (bsProduto.Current as CamadaDados.Estoque.Cadastros.TRegistro_CadProduto).lCodBarraDel.Add(bsCodBarra.Current as CamadaDados.Estoque.Cadastros.TRegistro_CodBarra);
                    bsCodBarra.RemoveCurrent();
                }
            }
            else
                MessageBox.Show("Obrigatorio selecionar item para excluir.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ExcluirFornecedor()
        {
            if (bsFornecedor.Current != null)
            {
                if (MessageBox.Show("Confirma exclusão do item selecionado?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                     MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    (bsProduto.Current as CamadaDados.Estoque.Cadastros.TRegistro_CadProduto).lFornecDel.Add(bsFornecedor.Current as CamadaDados.Estoque.Cadastros.TRegistro_Produto_X_Fornecedor);
                    bsFornecedor.RemoveCurrent();
                }
            }
            else
                MessageBox.Show("Obrigatorio selecionar item para excluir.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void PrintFichaTec()
        {
            if (bsFicha.Count > 0)
            {
                FormRelPadrao.Relatorio Relatorio = new FormRelPadrao.Relatorio();
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
                    using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
                    {
                        fImp.St_enabled_enviaremail = true;
                        fImp.pCd_clifor = string.Empty;
                        fImp.pMensagem = "FICHA TECNICA DO PRODUTO " + DS_Produto.Text.Trim();
                        if ((fImp.ShowDialog() == DialogResult.OK) || (fImp.pSt_enviaremail))
                            Relatorio.Gera_Relatorio(CD_Produto.Text,
                                                     fImp.pSt_imprimir,
                                                     fImp.pSt_visualizar,
                                                     fImp.pSt_enviaremail,
                                                     fImp.pSt_exportPdf,
                                                     fImp.Path_exportPdf,
                                                     fImp.pDestinatarios,
                                                     null,
                                                     "FICHA TECNICA DO PRODUTO " + DS_Produto.Text.Trim(),
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

        private void InserirVariedade()
        {
            if (bsProduto.Current != null)
            {
                InputBox inp = new InputBox(string.Empty, "Variedade Produto");
                string ret = inp.Show();
                if (string.IsNullOrEmpty(ret))
                {
                    MessageBox.Show("Obrigatório informar descrição variedade.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                (bsProduto.Current as CamadaDados.Estoque.Cadastros.TRegistro_CadProduto).lVariedade.Add(
                    new CamadaDados.Estoque.Cadastros.TRegistro_Variedade() { Ds_variedade = ret });
                bsProduto.ResetCurrentItem();
            }
        }

        private void AlterarVariedade()
        {
            if (bsVariedade.Current != null)
            {
                InputBox inp = new InputBox(string.Empty, "Variedade Produto");
                string ret = inp.Show((bsVariedade.Current as CamadaDados.Estoque.Cadastros.TRegistro_Variedade).Ds_variedade);
                (bsVariedade.Current as CamadaDados.Estoque.Cadastros.TRegistro_Variedade).Ds_variedade = ret;
                bsVariedade.ResetCurrentItem();
            }
        }

        private void ExcluirVariedade()
        {
            if (bsVariedade.Current != null)
                if (MessageBox.Show("Confirma exclusão variedade?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                     MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    (bsProduto.Current as CamadaDados.Estoque.Cadastros.TRegistro_CadProduto).lVariedadeDel.Add(
                        bsVariedade.Current as CamadaDados.Estoque.Cadastros.TRegistro_Variedade);
                    bsVariedade.RemoveCurrent();
                }
        }

        private void InserirFichaOP()
        {
            if (bsProduto.Current != null)
                using (TFFichaOP fItem = new TFFichaOP())
                {
                    if (fItem.ShowDialog() == DialogResult.OK)
                        if (fItem.rFicha != null)
                        {
                            (bsProduto.Current as CamadaDados.Estoque.Cadastros.TRegistro_CadProduto).lFichaOP.Add(fItem.rFicha);
                            bsProduto.ResetCurrentItem();
                        }
                }
        }

        private void AlterarFichaOP()
        {
            if (bsFichaOP.Current != null)
            {
                CamadaDados.Estoque.Cadastros.TRegistro_FichaOP rAux = new CamadaDados.Estoque.Cadastros.TRegistro_FichaOP();
                rAux.Cd_produto = (bsFichaOP.Current as CamadaDados.Estoque.Cadastros.TRegistro_FichaOP).Cd_produto;
                rAux.Id_item = (bsFichaOP.Current as CamadaDados.Estoque.Cadastros.TRegistro_FichaOP).Id_item;
                rAux.Ds_item = (bsFichaOP.Current as CamadaDados.Estoque.Cadastros.TRegistro_FichaOP).Ds_item;
                rAux.Quantidade = (bsFichaOP.Current as CamadaDados.Estoque.Cadastros.TRegistro_FichaOP).Quantidade;
                rAux.DiasPrevisao = (bsFichaOP.Current as CamadaDados.Estoque.Cadastros.TRegistro_FichaOP).DiasPrevisao;
                rAux.Tp_item = (bsFichaOP.Current as CamadaDados.Estoque.Cadastros.TRegistro_FichaOP).Tp_item;
                using (TFFichaOP fItem = new TFFichaOP())
                {
                    fItem.rFicha = bsFichaOP.Current as CamadaDados.Estoque.Cadastros.TRegistro_FichaOP;
                    if (fItem.ShowDialog() != DialogResult.OK)
                    {
                        (bsFichaOP.Current as CamadaDados.Estoque.Cadastros.TRegistro_FichaOP).Cd_produto = rAux.Cd_produto;
                        (bsFichaOP.Current as CamadaDados.Estoque.Cadastros.TRegistro_FichaOP).Id_item = rAux.Id_item;
                        (bsFichaOP.Current as CamadaDados.Estoque.Cadastros.TRegistro_FichaOP).Ds_item = rAux.Ds_item;
                        (bsFichaOP.Current as CamadaDados.Estoque.Cadastros.TRegistro_FichaOP).Quantidade = rAux.Quantidade;
                        (bsFichaOP.Current as CamadaDados.Estoque.Cadastros.TRegistro_FichaOP).DiasPrevisao = rAux.DiasPrevisao;
                        (bsFichaOP.Current as CamadaDados.Estoque.Cadastros.TRegistro_FichaOP).Tp_item = rAux.Tp_item;
                    }
                    bsProduto.ResetCurrentItem();
                }
            }
            else
                MessageBox.Show("Obrigatorio selecionar item ficha tecnica para alterar.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ExcluirFichaOP()
        {
            if (bsFichaOP.Current != null)
                if (MessageBox.Show("Confirma exclusão ficha OP?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                     MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    (bsProduto.Current as CamadaDados.Estoque.Cadastros.TRegistro_CadProduto).lFichaOPDel.Add(
                        bsFichaOP.Current as CamadaDados.Estoque.Cadastros.TRegistro_FichaOP);
                    bsFichaOP.RemoveCurrent();
                }
        }

        private void TFProduto_Load(object sender, EventArgs e)
        {
            ShapeGrid.RestoreShape(this, dataGridDefault1);
            ShapeGrid.RestoreShape(this, dataGridDefault3);
            ShapeGrid.RestoreShape(this, gFicha);
            ShapeGrid.RestoreShape(this, acessoriosDataGridDefault);
            ShapeGrid.RestoreShape(this, gQuantEstoque);
            Icon = ResourcesUtils.TecnoAliance_ICO;
            pDadosProd.set_FormatZero();
            pConfGeral.set_FormatZero();
            bb_saldoest.Visible = rprod == null;
            if (rprod != null)
            {
                lblRegAnvisa.Visible = rprod.St_reganvisa;
                reg_anvisa.Visible = rprod.St_reganvisa;
                if (rprod.lPatrimonio.Count > 0)
                    bsPatrimonio.DataSource = new CamadaDados.Estoque.Cadastros.TList_CadPatrimonio() { rprod.lPatrimonio[0] };
                bsProduto.DataSource = new CamadaDados.Estoque.Cadastros.TList_CadProduto() { rprod };
                CD_Produto.Enabled = false;
                DS_Produto.Focus();
            }
            else
            {
                CD_Produto.Enabled = !CamadaNegocio.Diversos.TCN_CadParamSys.St_AutoInc("CD_Produto");
                bsProduto.AddNew();
                if (St_copiar)
                    preencherCampos();
                if (!CD_Produto.Focus())
                    DS_Produto.Focus();
            }
            if (!string.IsNullOrEmpty(vDS_produto))
                DS_Produto.Text = vDS_produto;
        }

        private void CD_Grupo_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.CD_Grupo|=|'" + CD_Grupo.Text + "';" +
                              "a.TP_Grupo|=|'A'";
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { CD_Grupo, DS_Grupo },
                                    new CamadaDados.Estoque.Cadastros.TCD_CadGrupoProduto());
        }

        private void BB_GrupoProduto_Click(object sender, EventArgs e)
        {
            string vColunas = "a.DS_Grupo|Descrição Grupo Produto|350;" +
                              "a.CD_Grupo|Cód. Grupo|100";
            string vParamFixo = "a.TP_Grupo|=|'A'";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { CD_Grupo, DS_Grupo },
                                    new CamadaDados.Estoque.Cadastros.TCD_CadGrupoProduto(), vParamFixo);
        }

        private void CD_CondFiscal_Produto_Leave(object sender, EventArgs e)
        {
            string vColunas = "CD_CondFiscal_Produto|=|'" + CD_CondFiscal_Produto.Text + "'";
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { CD_CondFiscal_Produto, ds_condfiscal_produto },
                                    new CamadaDados.Fiscal.TCD_CadCondFiscalProduto());
        }

        private void BB_CondFiscalProduto_Click(object sender, EventArgs e)
        {
            string vColunas = "DS_CondFiscal_Produto|Condição Fiscal|350;" +
                              "CD_CondFiscal_Produto|Cód. Cond. Fiscal|100";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { CD_CondFiscal_Produto, ds_condfiscal_produto },
                                    new CamadaDados.Fiscal.TCD_CadCondFiscalProduto(), "");
        }

        private void TP_Produto_Leave(object sender, EventArgs e)
        {
            string vColunas = "TP_Produto|=|'" + TP_Produto.Text + "'";
            DataRow linha = UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { TP_Produto, ds_tpproduto },
                                    new CamadaDados.Estoque.Cadastros.TCD_CadTpProduto());

            //Validar se usuário possui permissão para tipo de produto informado
            TpBusca[] tps = new TpBusca[0];
            Estruturas.CriarParametro(ref tps, "a.login", "'" + Parametros.pubLogin + "'");
            object countTpProduto = new CamadaDados.Diversos.TCD_CadUsuario_TpProduto().BuscarEscalar(tps, "count(*)");

            if (countTpProduto != null 
                && !string.IsNullOrEmpty(countTpProduto.ToString()) 
                && !countTpProduto.ToString().Equals("0")
                && !string.IsNullOrEmpty(TP_Produto.Text))
            {
                tps = new TpBusca[0];
                Estruturas.CriarParametro(ref tps, "a.login", "'" + Parametros.pubLogin + "'");
                Estruturas.CriarParametro(ref tps, "a.tp_produto", "'" + TP_Produto.Text + "'");
                object existTpProduto = new CamadaDados.Diversos.TCD_CadUsuario_TpProduto().BuscarEscalar(tps, "1");
                if (existTpProduto == null)
                {
                    MessageBox.Show("Usuário não possui permissão para utilizar o tipo de produto informado.",
                        "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    linha = null;
                }
            }

            if (linha != null)
            {
                st_servico.Checked = linha["ST_Servico"].ToString().Trim().ToUpper().Equals("S");
                st_industrializado.Checked = linha["ST_Composto"].ToString().Trim().ToUpper().Equals("S");
                st_mprima.Checked = linha["ST_MPrima"].ToString().Trim().ToUpper().Equals("S");
                st_embalagem.Checked = linha["ST_Embalagem"].ToString().Trim().ToUpper().Equals("S");
                st_consumointerno.Checked = linha["ST_ConsumoInterno"].ToString().Trim().ToUpper().Equals("S");
                lblRegAnvisa.Visible = linha["ST_RegAnvisa"].ToString().Trim().ToUpper().Equals("S");
                reg_anvisa.Visible = linha["ST_RegAnvisa"].ToString().Trim().ToUpper().Equals("S");
            }
            else
            {
                TP_Produto.Text = "";
                ds_tpproduto.Text = "";
                st_embalagem.Checked = false;
                st_servico.Checked = false;
                st_mprima.Checked = false;
                st_industrializado.Checked = false;
                lblRegAnvisa.Visible = false;
                reg_anvisa.Visible = false;
            }
        }

        private void BB_TpProduto_Click(object sender, EventArgs e)
        {
            string vColunas = "DS_TPProduto|Tipo Produto|350;" +
                              "TP_Produto|Cód. TPProduto|100;" +
                              "ST_Servico|Servico|80;" +
                              "ST_Composto|Composto|80;" +
                              "ST_MPrima|Materia Prima|80;" +
                              "ST_Embalagem|Embalagem|80;" +
                              "ST_RegAnvisa|Farmacêutico|80";
            DataRowView linha = UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { TP_Produto, ds_tpproduto },
                                    new CamadaDados.Estoque.Cadastros.TCD_CadTpProduto(), string.Empty);

            //Validar se usuário possui permissão para tipo de produto informado
            TpBusca[] tps = new TpBusca[0];
            Estruturas.CriarParametro(ref tps, "a.login", "'" + Parametros.pubLogin + "'");
            object countTpProduto = new CamadaDados.Diversos.TCD_CadUsuario_TpProduto().BuscarEscalar(tps, "count(*)");

            if (countTpProduto != null
                && !string.IsNullOrEmpty(countTpProduto.ToString())
                && !countTpProduto.ToString().Equals("0")
                && !string.IsNullOrEmpty(TP_Produto.Text))
            {
                tps = new TpBusca[0];
                Estruturas.CriarParametro(ref tps, "a.login", "'" + Parametros.pubLogin + "'");
                Estruturas.CriarParametro(ref tps, "a.tp_produto", "'" + TP_Produto.Text + "'");
                object existTpProduto = new CamadaDados.Diversos.TCD_CadUsuario_TpProduto().BuscarEscalar(tps, "1");
                if (existTpProduto == null)
                {
                    MessageBox.Show("Usuário não possui permissão para utilizar o tipo de produto informado.",
                        "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    linha = null;
                }
            }


            if (linha != null)
            {
                st_servico.Checked = linha["ST_Servico"].ToString().Trim().ToUpper().Equals("S");
                st_industrializado.Checked = linha["ST_Composto"].ToString().Trim().ToUpper().Equals("S");
                st_mprima.Checked = linha["ST_MPrima"].ToString().Trim().ToUpper().Equals("S");
                st_embalagem.Checked = linha["ST_Embalagem"].ToString().Trim().ToUpper().Equals("S");
                st_consumointerno.Checked = linha["ST_ConsumoInterno"].ToString().Trim().ToUpper().Equals("S");
                lblRegAnvisa.Visible = linha["ST_RegAnvisa"].ToString().Trim().ToUpper().Equals("S");
                reg_anvisa.Visible = linha["ST_RegAnvisa"].ToString().Trim().ToUpper().Equals("S");
            }
            else
            {
                TP_Produto.Text = "";
                ds_tpproduto.Text = "";
                st_embalagem.Checked = false;
                st_servico.Checked = false;
                st_mprima.Checked = false;
                st_industrializado.Checked = false;
                lblRegAnvisa.Visible = false;
                reg_anvisa.Visible = false;
            }
        }

        private void CD_Unidade_Leave(object sender, EventArgs e)
        {
            string vColunas = "CD_Unidade|=|'" + CD_Unidade.Text + "'";
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { CD_Unidade, ds_unidade, sigla_unidade },
                                    new CamadaDados.Estoque.Cadastros.TCD_CadUnidade());
        }

        private void BB_Unidade_Click(object sender, EventArgs e)
        {
            string vColunas = "DS_Unidade|Descrição Unidade|350;" +
                              "CD_Unidade|Cód. Unidade|100;" +
                              "Sigla_Unidade|Sigla|80";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { CD_Unidade, ds_unidade, sigla_unidade },
                                    new CamadaDados.Estoque.Cadastros.TCD_CadUnidade(), "");
        }

        private void ncm_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(ncm.Text))
            {
                EditDefault cadNcm = new EditDefault();
                cadNcm.Text = ncm.Text;
                string vColunas = "a.ncm|=|'" + ncm.Text.Trim() + "'";
                DataRow linha = UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { ncm, ds_ncm },
                                        new CamadaDados.Fiscal.TCD_CadNCM());
                if (linha == null)
                {
                    if (cadNcm.Text.SoNumero().Trim().Length != 8)
                    {
                        MessageBox.Show("NCM incorreto!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    InputBox ibp = new InputBox();
                    ibp.Text = "NCM";
                    string ds = ibp.ShowDialog();
                    if (string.IsNullOrEmpty(ds))
                    {
                        MessageBox.Show("Obrigatorio informar descrição NCM.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    try
                    {
                        CamadaNegocio.Fiscal.TCN_CadNCM.GravarNCM(
                            new CamadaDados.Fiscal.TRegistro_CadNCM()
                            {
                                NCM = cadNcm.Text,
                                Ds_NCM = ds
                            });
                        MessageBox.Show("NCM gravado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ncm.Text = cadNcm.Text;
                        ds_ncm.Text = ds;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
        }

        private void bb_ncm_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_ncm|Descrição NCM|250;" +
                              "a.ncm|NCM|80";
            UtilPesquisa.BTN_BUSCA(vColunas, new EditDefault[] { ncm, ds_ncm },
                                    new CamadaDados.Fiscal.TCD_CadNCM(), String.Empty);

        }

        private void CD_Marca_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.CD_Marca|=|'" + CD_Marca.Text + "'";
            UtilPesquisa.EDIT_LEAVE(vColunas, new EditDefault[] { CD_Marca, DS_Marca },
                                    new CamadaDados.Estoque.Cadastros.TCD_CadMarca());
        }

        private void btn_Marca_Click(object sender, EventArgs e)
        {
            string vColunas = "a.DS_Marca|Descrição Marca|350;" +
                              "a.CD_Marca|Cód. Marca|100";
            string vParamFixo = "";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { CD_Marca, DS_Marca },
                                    new CamadaDados.Estoque.Cadastros.TCD_CadMarca(), vParamFixo);
        }

        private void id_genero_Leave(object sender, EventArgs e)
        {
            string vParam = "a.id_genero|=|" + id_genero.Text;
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { id_genero, ds_genero },
                                    new CamadaDados.Estoque.Cadastros.TCD_Cad_Genero());
        }

        private void bb_genero_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_genero|Genero|200;" +
                              "a.id_genero|Id. Genero|80";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { id_genero, ds_genero },
                                    new CamadaDados.Estoque.Cadastros.TCD_Cad_Genero(), string.Empty);
        }

        private void id_tpservico_Leave(object sender, EventArgs e)
        {
            string vParam = "a.id_tpservico|=|'" + id_tpservico.Text + "'";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { id_tpservico, ds_tpservico },
                new CamadaDados.Estoque.Cadastros.TCD_CadTipoServico());
        }

        private void bb_tpservico_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_tpservico|Tipo Servico|200;" +
                              "a.id_tpservico|Id. Servico|80";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { id_tpservico, ds_tpservico },
                                    new CamadaDados.Estoque.Cadastros.TCD_CadTipoServico(), string.Empty);
        }

        private void cd_anp_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_anp|=|'" + cd_anp.Text.Trim() + "'";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_anp, ds_anp },
                                    new CamadaDados.Estoque.Cadastros.TCD_CodANP());
        }

        private void bb_anp_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_anp|Descrição|200;" +
                              "a.cd_anp|Cd. ANP|80";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_anp, ds_anp },
                                    new CamadaDados.Estoque.Cadastros.TCD_CodANP(), string.Empty);
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            if ((bsProduto.Current != null) && (bsImagensProduto.Current != null))
            {
                (bsProduto.Current as CamadaDados.Estoque.Cadastros.TRegistro_CadProduto).lImagensApagar.Add(
                    bsImagensProduto.Current as CamadaDados.Estoque.Cadastros.TRegistro_CadProduto_Imagens);
                bsImagensProduto.RemoveCurrent();
            }
        }

        private void bb_capturar_Click(object sender, EventArgs e)
        {
            capturarImagem();
        }

        private void bb_localizar_Click(object sender, EventArgs e)
        {
            try
            {
                if (bsProduto.Current != null)
                {
                    OpenFileDialog ofd = new OpenFileDialog();
                    ofd.Filter = "IMAGENS|*.jpg";
                    if (ofd.ShowDialog() == DialogResult.OK)
                        if (System.IO.File.Exists(ofd.FileName))
                        {
                            (bsProduto.Current as CamadaDados.Estoque.Cadastros.TRegistro_CadProduto).LImagens.Add(new CamadaDados.Estoque.Cadastros.TRegistro_CadProduto_Imagens()
                            {
                                Cd_produto = CD_Produto.Text,
                                Imagem = Image.FromFile(ofd.FileName)
                            });
                            bsProduto.ResetCurrentItem();
                        }
                }
            }
            catch (Exception ex)
            { MessageBox.Show("Erro localizar imagem: " + ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void bb_adicionaracessorios_Click(object sender, EventArgs e)
        {
            bsAcessorios.AddNew();
            ds_acessorio.Focus();
        }

        private void bb_excluiracessorios_Click(object sender, EventArgs e)
        {
            if (bsAcessorios.Current != null)
                if ((bsAcessorios.Current as CamadaDados.Estoque.Cadastros.TRegistro_CadAcessoriosProduto).Id_Acessorio > 0)
                    (bsProduto.Current as CamadaDados.Estoque.Cadastros.TRegistro_CadProduto).AcessoriosApagar.Add(
                        bsAcessorios.Current as CamadaDados.Estoque.Cadastros.TRegistro_CadAcessoriosProduto);
            bsAcessorios.RemoveCurrent();
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

        private void bb_imfichatec_Click(object sender, EventArgs e)
        {
            PrintFichaTec();
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

        private void tsbInserirEstoque_Click(object sender, EventArgs e)
        {
            InserirQtdEstoque();
        }

        private void tsbAlterarEstoque_Click(object sender, EventArgs e)
        {
            AlterarQtdEstoque();
        }

        private void tsbExcluirEstoque_Click(object sender, EventArgs e)
        {
            ExcluirQtdEstoque();
        }

        private void tsbInserirCodBarra_Click(object sender, EventArgs e)
        {
            InserirCodBarra();
        }

        private void tsbExcluirCodBarra_Click(object sender, EventArgs e)
        {
            ExcluirCodBarra();
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            afterGrava();
        }

        private void grupoProdutoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (TFCadGrupoProduto fGrupo = new TFCadGrupoProduto())
            {
                fGrupo.St_janelaNormal = true;
                fGrupo.ShowDialog();
            }
        }

        private void condiçãoFiscalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (Fiscal.Cadastros.TFCadCondFiscalProduto fCond = new Fiscal.Cadastros.TFCadCondFiscalProduto())
            {
                fCond.St_janelaNormal = true;
                fCond.ShowDialog();
            }
        }

        private void tipoProdutoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (TFCad_TpProduto fTp = new TFCad_TpProduto())
            {
                fTp.St_janelaNormal = true;
                fTp.ShowDialog();
            }
        }

        private void unidadeMedidaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (TFCad_Unidade fUnd = new TFCad_Unidade())
            {
                fUnd.St_janelaNormal = true;
                fUnd.ShowDialog();
            }
        }

        private void nCMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (Fiscal.Cadastros.TFCadNCM fNcm = new Fiscal.Cadastros.TFCadNCM())
            {
                fNcm.St_janelaNormal = true;
                fNcm.ShowDialog();
            }
        }

        private void marcaProdutoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (TFCadMarca fMarca = new TFCadMarca())
            {
                fMarca.St_janelaNormal = true;
                fMarca.ShowDialog();
            }
        }

        private void generoProdutoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (TFCad_Genero fGenero = new TFCad_Genero())
            {
                fGenero.St_janelaNormal = true;
                fGenero.ShowDialog();
            }
        }

        private void tipoServiçoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (TFCad_TipoServico fTip = new TFCad_TipoServico())
            {
                fTip.St_janelaNormal = true;
                fTip.ShowDialog();
            }
        }

        private void codigoANPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (TFCadCodANP fAnp = new TFCadCodANP())
            {
                fAnp.St_janelaNormal = true;
                fAnp.ShowDialog();
            }
        }

        private void TFProduto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                DialogResult = DialogResult.Cancel;
            if (e.Control && e.KeyCode.Equals(Keys.F10) && tcDetalhes.SelectedTab.Equals(tpFichaTec))
                InserirItemFicha();
            else if (e.Control && e.KeyCode.Equals(Keys.F11) && tcDetalhes.SelectedTab.Equals(tpFichaTec))
                AlterarItemFicha();
            else if (e.Control && e.KeyCode.Equals(Keys.F12) && tcDetalhes.SelectedTab.Equals(tpFichaTec))
                ExcluirItemFicha();
            else if (e.Control && e.KeyCode.Equals(Keys.F10) && tcDetalhes.SelectedTab.Equals(tpQtdEstoque))
                InserirQtdEstoque();
            else if (e.Control && e.KeyCode.Equals(Keys.F11) && tcDetalhes.SelectedTab.Equals(tpQtdEstoque))
                AlterarQtdEstoque();
            else if (e.Control && e.KeyCode.Equals(Keys.F12) && tcDetalhes.SelectedTab.Equals(tpQtdEstoque))
                ExcluirQtdEstoque();
            else if (e.Control && e.KeyCode.Equals(Keys.F10) && tcDetalhes.SelectedTab.Equals(tpCodBarra))
                InserirCodBarra();
            else if (e.Control && e.KeyCode.Equals(Keys.F12) && tcDetalhes.SelectedTab.Equals(tpCodBarra))
                ExcluirCodBarra();
            else if (e.Control && e.KeyCode.Equals(Keys.F10) && tcDetalhes.SelectedTab.Equals(tpVariedade))
                InserirVariedade();
            else if (e.Control && e.KeyCode.Equals(Keys.F11) && tcDetalhes.SelectedTab.Equals(tpVariedade))
                AlterarVariedade();
            else if (e.Control && e.KeyCode.Equals(Keys.F12) && tcDetalhes.SelectedTab.Equals(tpVariedade))
                ExcluirVariedade();
            else if (e.Control && e.KeyCode.Equals(Keys.F12) && tcDetalhes.SelectedTab.Equals(tpFornecedor))
                bb_excluirfornec_Click(this, new EventArgs());
            else if (e.Control && e.KeyCode.Equals(Keys.F10) && tcDetalhes.SelectedTab.Equals(tpFichaOP))
                InserirFichaOP();
            else if (e.Control && e.KeyCode.Equals(Keys.F11) && tcDetalhes.SelectedTab.Equals(tpFichaOP))
                AlterarFichaOP();
            else if (e.Control && e.KeyCode.Equals(Keys.F12) && tcDetalhes.SelectedTab.Equals(tpFichaOP))
                ExcluirFichaOP();
            else if (e.Control && e.KeyCode.Equals(Keys.P))
            {
                Altera_Relatorio = true;
                MessageBox.Show("Execute o relatorio que deseja alterar.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void CD_Produto_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(CD_Produto.Text))
            {
                //Verificar se o produto ja existe
                CamadaDados.Estoque.Cadastros.TList_CadProduto lProd =
                    CamadaNegocio.Estoque.Cadastros.TCN_CadProduto.Busca(CD_Produto.Text,
                                                                         string.Empty,
                                                                         string.Empty,
                                                                         string.Empty,
                                                                         string.Empty,
                                                                         string.Empty,
                                                                         string.Empty,
                                                                         string.Empty,
                                                                         string.Empty,
                                                                         string.Empty,
                                                                         string.Empty,
                                                                         string.Empty,
                                                                         string.Empty,
                                                                         string.Empty,
                                                                         1,
                                                                         string.Empty,
                                                                         string.Empty,
                                                                         null);
                if (lProd.Count > 0)
                {
                    bsProduto.DataSource = lProd;
                    CD_Produto.Enabled = false;
                }
            }
        }

        private void bb_saldoest_Click(object sender, EventArgs e)
        {
            if (!st_consumointerno.Checked)
            {
                using (Proc_Commoditties.TFSaldoEstPrecoVenda fSaldo = new Proc_Commoditties.TFSaldoEstPrecoVenda())
                {
                    fSaldo.pSt_servico = st_servico.Checked;
                    if (fSaldo.ShowDialog() == DialogResult.OK)
                    {
                        if (!string.IsNullOrEmpty(fSaldo.Cd_local))
                        {
                            CamadaDados.Estoque.TRegistro_LanEstoque rEstoque = new CamadaDados.Estoque.TRegistro_LanEstoque();
                            rEstoque.Cd_empresa = fSaldo.Cd_empresa;
                            rEstoque.Cd_local = fSaldo.Cd_local;
                            rEstoque.Dt_lancto = CamadaDados.UtilData.Data_Servidor();
                            rEstoque.Tp_movimento = "E";
                            rEstoque.Qtd_entrada = fSaldo.Quantidade;
                            rEstoque.Qtd_saida = decimal.Zero;
                            rEstoque.Vl_unitario = fSaldo.Vl_unitario;
                            rEstoque.Vl_subtotal = fSaldo.Quantidade * fSaldo.Vl_unitario;
                            rEstoque.Tp_lancto = "M";
                            rEstoque.St_registro = "A";
                            (bsProduto.Current as CamadaDados.Estoque.Cadastros.TRegistro_CadProduto).rSaldoEst = rEstoque;
                        }
                        if (!string.IsNullOrEmpty(fSaldo.Cd_tabelapreco))
                        {
                            string[] tabela = fSaldo.Cd_tabelapreco.Split(new char[] { ';' });
                            for (int i = 0; tabela.Count() > i; i++)
                            {
                                CamadaDados.Estoque.TRegistro_LanPrecoItem rPreco = new CamadaDados.Estoque.TRegistro_LanPrecoItem();
                                rPreco.CD_Empresa = fSaldo.Cd_empresa;
                                rPreco.CD_TabelaPreco = tabela[i];
                                rPreco.Dt_preco = CamadaDados.UtilData.Data_Servidor();
                                rPreco.VL_PrecoVenda = fSaldo.Vl_precovenda;
                                (bsProduto.Current as CamadaDados.Estoque.Cadastros.TRegistro_CadProduto).lPrecoItem.Add(rPreco);
                            }
                        }
                    }
                }
            }
            else
            {
                using (Almoxarifado.TFSaldoAlmoxCusto fSaldo = new Almoxarifado.TFSaldoAlmoxCusto())
                {
                    if (fSaldo.ShowDialog() == DialogResult.OK)
                    {
                        if (!string.IsNullOrEmpty(fSaldo.Id_almox))
                        {
                            TRegistro_Movimentacao rAlmox = new TRegistro_Movimentacao();
                            rAlmox.Cd_empresa = fSaldo.Cd_empresa;
                            rAlmox.Id_almoxstr = fSaldo.Id_almox;
                            rAlmox.Dt_movimento = CamadaDados.UtilData.Data_Servidor();
                            rAlmox.Tp_movimento = "E";
                            rAlmox.Quantidade = fSaldo.Quantidade;
                            rAlmox.Vl_unitario = fSaldo.Vl_unitario;
                            rAlmox.Vl_subtotal = fSaldo.Quantidade * fSaldo.Vl_unitario;
                            rAlmox.St_registro = "A";
                            rAlmox.Ds_observacao = "ENTRADA REALIZADA EFETUADA PELO CADASTRO DE PRODUTOS";
                            (bsProduto.Current as CamadaDados.Estoque.Cadastros.TRegistro_CadProduto).rSaldoAlmox = rAlmox;
                        }
                    }
                }
            }
        }

        private void bb_gerarcodbarra_Click(object sender, EventArgs e)
        {
            if (bsProduto.Current != null)
            {
                if (!string.IsNullOrEmpty(CD_Produto.Text))
                {
                    if (!(bsProduto.Current as CamadaDados.Estoque.Cadastros.TRegistro_CadProduto).lCodBarra.Exists(p =>
                        p.Cd_codbarra.Trim().Equals((bsProduto.Current as CamadaDados.Estoque.Cadastros.TRegistro_CadProduto).CD_Produto.PadLeft(13, '9'))))
                    {
                        (bsProduto.Current as CamadaDados.Estoque.Cadastros.TRegistro_CadProduto).lCodBarra.Add(new CamadaDados.Estoque.Cadastros.TRegistro_CodBarra()
                        {
                            Cd_codbarra = (bsProduto.Current as CamadaDados.Estoque.Cadastros.TRegistro_CadProduto).CD_Produto.PadLeft(12, '9') +
                            Estruturas.DigitoEAN13((bsProduto.Current as CamadaDados.Estoque.Cadastros.TRegistro_CadProduto).CD_Produto.PadLeft(12, '9'))
                        });
                        bsProduto.ResetCurrentItem();
                    }
                }
                else
                    MessageBox.Show("Cod.Barras só pode ser gerado após o produto ser gravado,\r\n" +
                                    "ou configure para gerar automático após a gravação pelo MENU:\r\n" +
                                    "PARÂMETROS>>CONFIGURAÇÕES>>CONFIGURAÇÕES GERAIS", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void bb_impcodbarra_Click(object sender, EventArgs e)
        {
            if (bsCodBarra.Current != null)
            {
                CamadaDados.Diversos.TRegistro_CadTerminal rTerminal =
                    CamadaNegocio.Diversos.TCN_CadTerminal.Busca(Parametros.pubTerminal, string.Empty, null)[0];
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
                        object obj = new CamadaDados.Estoque.TCD_LanPrecoItem().BuscarEscalar(
                                    new TpBusca[]
                                    {
                                        new TpBusca()
                                        {
                                            vNM_Campo = "a.cd_produto",
                                            vOperador= "=",
                                            vVL_Busca = "'" + (bsProduto.Current as CamadaDados.Estoque.Cadastros.TRegistro_CadProduto).CD_Produto.Trim() + "'"
                                        }
                                    }, "a.vl_precovenda");
                        if (rTerminal.Layoutetiqueta.Trim().Equals("1"))
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
                            TEtiquetaZebra.ImpEtiquetaL5((bsProduto.Current as CamadaDados.Estoque.Cadastros.TRegistro_CadProduto).CD_Produto.Trim() +
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
                }
                else
                    using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
                    {
                        FormRelPadrao.Relatorio Rel = new FormRelPadrao.Relatorio();
                        Rel.Altera_Relatorio = Altera_Relatorio;
                        Rel.Nome_Relatorio = Name;
                        Rel.NM_Classe = Name;
                        Rel.Ident = "REL_CODBARRA";
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
                        //Valor Venda
                        object obj = new CamadaDados.Estoque.TCD_LanPrecoItem().BuscarEscalar(
                                    new TpBusca[]
                                    {
                                        new TpBusca()
                                        {
                                            vNM_Campo = "a.cd_produto",
                                            vOperador= "=",
                                            vVL_Busca = "'" + (bsProduto.Current as CamadaDados.Estoque.Cadastros.TRegistro_CadProduto).CD_Produto.Trim() + "'"
                                        }
                                    }, "a.vl_precovenda");
                        CamadaDados.Estoque.Cadastros.TList_CodBarra lCod = new CamadaDados.Estoque.Cadastros.TList_CodBarra();
                        for (int i = 0; i < copias; i++)
                            lCod.Add(new CamadaDados.Estoque.Cadastros.TRegistro_CodBarra()
                            {
                                Cd_codbarra = (bsCodBarra.Current as CamadaDados.Estoque.Cadastros.TRegistro_CodBarra).Cd_codbarra,
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

        private void TFProduto_FormClosing(object sender, FormClosingEventArgs e)
        {
            ShapeGrid.SaveShape(this, dataGridDefault1);
            ShapeGrid.SaveShape(this, dataGridDefault3);
            ShapeGrid.SaveShape(this, gFicha);
            ShapeGrid.SaveShape(this, acessoriosDataGridDefault);
            ShapeGrid.SaveShape(this, gQuantEstoque);
        }

        private void CD_Empresa_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("a.cd_empresa|=|'" + CD_Empresa.Text.Trim() + "';" +
                                   "|EXISTS|(select 1 from Tb_div_usuario_X_empresa  x where x.cd_empresa = A.cd_empresa " +
                                   "and((x.login = '" + Parametros.pubLogin.Trim() + "') or " +
                                   "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                   "        where y.logingrp = x.login " +
                                   "        and y.loginusr = '" + Parametros.pubLogin.Trim() + "'))))"
               , new Componentes.EditDefault[] { CD_Empresa, NM_Empresa }, new CamadaDados.Diversos.TCD_CadEmpresa());
        }

        private void BB_Empresa_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BUSCA("a.NM_empresa|Nome Empresa|300;a.CD_Empresa|Cód Empresa|100"
                          , new Componentes.EditDefault[] { CD_Empresa, NM_Empresa }
                          , new CamadaDados.Diversos.TCD_CadEmpresa(),
                          "|EXISTS|(select 1 from Tb_div_usuario_X_empresa  x where x.cd_empresa = A.cd_empresa " +
                          "and ((x.login = '" + Parametros.pubLogin.Trim() + "') or " +
                          "(exists(select 1 from tb_div_usuario_x_grupos y " +
                          "         where y.logingrp = x.login and y.loginusr = '" + Parametros.pubLogin.Trim() + "'))))");
        }

        private void tcDetalhes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tcDetalhes.SelectedTab.Equals(tpPatrimonio))
                if (bsPatrimonio.Current == null)
                    bsPatrimonio.AddNew();

        }

        private void st_controlehora_CheckedChanged(object sender, EventArgs e)
        {
            qtd_horas.Enabled = st_controlehora.Checked;
        }

        private void bbAddVariedade_Click(object sender, EventArgs e)
        {
            InserirVariedade();
        }

        private void bbAltVariedade_Click(object sender, EventArgs e)
        {
            AlterarVariedade();
        }

        private void bbDelVariedade_Click(object sender, EventArgs e)
        {
            ExcluirVariedade();
        }

        private void bbCopiarFicha_Click(object sender, EventArgs e)
        {
            using (TFFichaTecnica ficha = new TFFichaTecnica())
            {

                if (ficha.ShowDialog() == DialogResult.OK)
                {
                    (bsProduto.Current as CamadaDados.Estoque.Cadastros.TRegistro_CadProduto).lFicha = ficha.lFicha;
                    bsFicha.DataSource = ficha.lFicha;
                }
            }
        }

        private void bb_rua_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_rua|Rua|150;" +
                              "a.id_rua|Id. Rua|80";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { id_rua, ds_rua },
                                    new TCD_CadRua(), string.Empty);
        }

        private void id_rua_Leave(object sender, EventArgs e)
        {
            string vParam = "a.id_rua|=|" + id_rua.Text;
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { id_rua, ds_rua },
                                    new TCD_CadRua());
        }

        private void bb_secao_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_secao|Seção|150;" +
                              "a.id_secao|Id. Seção|80";
            string vParam = "a.id_rua|=|" + (string.IsNullOrEmpty(id_rua.Text) ? "null" : id_rua.Text);
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { id_secao, ds_secao },
                                    new TCD_CadSecao(), vParam);
        }

        private void id_secao_Leave(object sender, EventArgs e)
        {
            string vParam = "a.id_secao|=|" + id_secao.Text + ";" +
                "a.id_rua|=|" + (string.IsNullOrEmpty(id_rua.Text) ? "null" : id_rua.Text);
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { id_secao, ds_secao },
                                    new TCD_CadSecao());
        }

        private void bb_celula_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_celula|Celula|150;" +
                              "a.id_celula|Id. Celula|80";
            string vParam = "a.id_rua|=|" + (string.IsNullOrEmpty(id_rua.Text) ? "null" : id_rua.Text) + ";" +
                "a.id_secao|=|" + (string.IsNullOrEmpty(id_secao.Text) ? "null" : id_secao.Text);
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { id_celula, ds_celula },
                                    new TCD_CadCelulaArm(), vParam);
        }

        private void id_celula_Leave(object sender, EventArgs e)
        {
            string vParam = "a.id_celula|=|" + id_celula.Text + ";" +
                "a.id_rua|=|" + (string.IsNullOrEmpty(id_rua.Text) ? "null" : id_rua.Text) + ";" +
                "a.id_secao|=|" + (string.IsNullOrEmpty(id_secao.Text) ? "null" : id_secao.Text);
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { id_celula, ds_celula },
                                    new TCD_CadCelulaArm());
        }

        private void bb_caracteristicaH_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BUSCA("a.ds_caracteristica|Caracteristica|150;a.id_caracteristica|Código|50",
                new EditDefault[] { id_caracteristicaH, ds_caracteristicaH },
                new CamadaDados.Estoque.Cadastros.TCD_Caracteristica(),
                string.Empty);
        }

        private void id_caracteristicaH_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("a.id_caracteristica|=|" + id_caracteristicaH.Text,
                new EditDefault[] { id_caracteristicaH, ds_caracteristicaH },
                new CamadaDados.Estoque.Cadastros.TCD_Caracteristica());
        }

        private void bb_caracteristicaV_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BUSCA("a.ds_caracteristica|Caracteristica|150;a.id_caracteristica|Código|50",
                new EditDefault[] { id_caracteristicaV, ds_caracteristicaV },
                new CamadaDados.Estoque.Cadastros.TCD_Caracteristica(),
                string.Empty);
        }

        private void id_caracteristicaV_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("a.id_caracteristica|=|" + id_caracteristicaV.Text,
                new EditDefault[] { id_caracteristicaV, ds_caracteristicaV },
                new CamadaDados.Estoque.Cadastros.TCD_Caracteristica());
        }

        private void bb_excluirfornec_Click(object sender, EventArgs e)
        {
            if (bsFornecedor.Current != null)
            {
                if (MessageBox.Show("Deseja excluir fornecedor?", "Pergunta!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    (bsProduto.Current as CamadaDados.Estoque.Cadastros.TRegistro_CadProduto).lFornecDel.Add(bsFornecedor.Current as CamadaDados.Estoque.Cadastros.TRegistro_Produto_X_Fornecedor);
                    bsFornecedor.RemoveCurrent();
                }

            }
        }

        private void bb_inserirPreco_Click(object sender, EventArgs e)
        {
            if (bsFicha.Current != null)
            {
                DataRowView linha = UtilPesquisa.BTN_BUSCA("DS_TabelaPreco|Descrição da Tabela de Preço|300;CD_TabelaPreco|Cd. Tab.Preço|80", null,
                             new CamadaDados.Diversos.TCD_CadTbPreco(), string.Empty);
                if (linha != null)
                    using (TFAlterarPrecoFichaTec fAltera = new TFAlterarPrecoFichaTec())
                    {
                        (bsProduto.Current as CamadaDados.Estoque.Cadastros.TRegistro_CadProduto).lFicha.ForEach(p =>
                        {
                            CamadaDados.Estoque.Cadastros.TRegistro_PrecoItemFicha item = new CamadaDados.Estoque.Cadastros.TRegistro_PrecoItemFicha();
                            item.Cd_item = p.Cd_item;
                            item.Ds_item = p.Ds_item;
                            item.Cd_tabelapreco = linha["cd_tabelapreco"].ToString();
                            item.Ds_tabelapreco = linha["ds_tabelapreco"].ToString();
                            fAltera.lficha.Add(item);
                        });
                        fAltera.pCd_tabelapreco = linha["cd_tabelapreco"].ToString();
                        fAltera.pDs_tabelapreco = linha["ds_tabelapreco"].ToString();
                        if (fAltera.ShowDialog() == DialogResult.OK)
                            if (fAltera.lFicha.Count > 0)
                                (bsProduto.Current as CamadaDados.Estoque.Cadastros.TRegistro_CadProduto).lPreco = fAltera.lFicha;
                    }
            }
        }

        private void bb_atualizarPreco_Click(object sender, EventArgs e)
        {
            if (bsFicha.Current != null)
            {
                if (string.IsNullOrEmpty((bsProduto.Current as CamadaDados.Estoque.Cadastros.TRegistro_CadProduto).CD_Produto))
                {
                    MessageBox.Show("Não existem preços gravados para os itens!\r\n" +
                                    "Insira os preços e finalize o cadastro do produto.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                using (TFAlterarPrecoFichaTec fAltera = new TFAlterarPrecoFichaTec())
                {
                    fAltera.pCd_produto = (bsProduto.Current as CamadaDados.Estoque.Cadastros.TRegistro_CadProduto).CD_Produto;
                    fAltera.lficha = (bsProduto.Current as CamadaDados.Estoque.Cadastros.TRegistro_CadProduto).lPreco.FindAll(p => p.Vl_venda > 0);
                    fAltera.St_atualizar = true;
                    if (fAltera.ShowDialog() == DialogResult.OK)
                        if (fAltera.lFicha.Count > 0)
                            (bsProduto.Current as CamadaDados.Estoque.Cadastros.TRegistro_CadProduto).lPreco = fAltera.lFicha;
                }
            }
        }

        private void bbAddFichaOP_Click(object sender, EventArgs e)
        {
            InserirFichaOP();
        }

        private void bbAltFichaOP_Click(object sender, EventArgs e)
        {
            AlterarFichaOP();
        }

        private void bbDelFichaOP_Click(object sender, EventArgs e)
        {
            ExcluirFichaOP();
        }
    }
}

