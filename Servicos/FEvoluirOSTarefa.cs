using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Servicos
{
    public partial class TFEvoluirOSTarefa : Form
    {
        public CamadaDados.Servicos.TRegistro_LanServico rOS
        { get; set; }

        public TFEvoluirOSTarefa()
        {
            InitializeComponent();
        }

        private void BuscarEndereco()
        {
            if (!string.IsNullOrEmpty(CD_Clifor.Text))
            {
                CamadaDados.Financeiro.Cadastros.TList_CadEndereco lEnd =
                    CamadaNegocio.Financeiro.Cadastros.TCN_CadEndereco.Buscar(CD_Clifor.Text,
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
                                                                              null);
                if (lEnd.Count > 0)
                {
                    CD_Endereco.Text = lEnd[0].Cd_endereco;
                    DS_Endereco.Text = lEnd[0].Ds_endereco;
                    DS_Cidade.Text = lEnd[0].DS_Cidade;
                    UF.Text = lEnd[0].UF;
                }
            }
        }

        private void afterInserirEvolucao()
        {
            if (bsOrdemServico.Current != null)
            {
                using (TFListEtapa fEtapa = new TFListEtapa())
                {
                    fEtapa.Id_os = (bsOrdemServico.Current as CamadaDados.Servicos.TRegistro_LanServico).Id_osstr;
                    fEtapa.TP_Ordem = (bsOrdemServico.Current as CamadaDados.Servicos.TRegistro_LanServico).Tp_ordemstr;
                    if (fEtapa.ShowDialog() == DialogResult.OK)
                        if (fEtapa.lEtapa.Count > 0)
                        {
                            fEtapa.lEtapa.ForEach(p =>
                                (bsOrdemServico.Current as CamadaDados.Servicos.TRegistro_LanServico).lEvolucao.Add(
                                new CamadaDados.Servicos.TRegistro_LanServicoEvolucao()
                                {
                                    Dt_inicio = CamadaDados.UtilData.Data_Servidor(),
                                    Id_etapa = p.Id_etapa,
                                    Ds_evolucao = p.Ds_etapa,
                                    Ds_etapa = p.Ds_etapa,
                                    Ordem = bsEvolucao.Count + 1,
                                    St_envterceiro = p.St_envterceirobool,
                                    St_finalizarOS = p.St_finalizarOSbool,
                                    St_iniciarOS = p.St_iniciarOSbool
                                }));
                            bsOrdemServico.ResetCurrentItem();
                        }
                }
            }
        }

        private void afterExcluirEvolucao()
        {
            if (bsEvolucao.Current != null)
            {
                if (MessageBox.Show("Etapa selecionada: Nº " + (bsEvolucao.Current as CamadaDados.Servicos.TRegistro_LanServicoEvolucao).Id_etapastr.Trim() +
                                                        "-" + (bsEvolucao.Current as CamadaDados.Servicos.TRegistro_LanServicoEvolucao).Ds_etapa.Trim() + 
                                                        "\r\n\r\nConfirma exclusão? ", "Pergunta", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    (bsOrdemServico.Current as CamadaDados.Servicos.TRegistro_LanServico).lEvolucaoDel.Add(
                        bsEvolucao.Current as CamadaDados.Servicos.TRegistro_LanServicoEvolucao);
                    //Excluir item do grid
                    bsEvolucao.RemoveCurrent();
                }
                        
            }
        }

        private void afterInserirPecas(bool st_servico)
        {
            if (bsOrdemServico.Current != null)
            {
                using (TFLan_Pecas_Ordem_Servico fPecas = new TFLan_Pecas_Ordem_Servico())
                {
                    fPecas.CD_Empresa = CD_Empresa.Text;
                    fPecas.Nm_empresa = NM_Empresa.Text;
                    fPecas.CD_TabelaPreco = CD_TabelaPreco.Text;
                    fPecas.St_garantia = false;
                    fPecas.pSt_servico = st_servico;
                    if (st_servico && (bsOrdemServico.Current as CamadaDados.Servicos.TRegistro_LanServico).lPecas.Exists(p => !string.IsNullOrEmpty(p.Cd_tecnico) && p.St_servicobool))
                    {
                        fPecas.Cd_tecnico = (bsOrdemServico.Current as CamadaDados.Servicos.TRegistro_LanServico).lPecas.LastOrDefault(p => !string.IsNullOrEmpty(p.Cd_tecnico) && p.St_servicobool).Cd_tecnico;
                        fPecas.Nm_tecnico = (bsOrdemServico.Current as CamadaDados.Servicos.TRegistro_LanServico).lPecas.LastOrDefault(p => !string.IsNullOrEmpty(p.Cd_tecnico) && p.St_servicobool).Nm_tecnico;
                    }
                    else if (!st_servico && (bsOrdemServico.Current as CamadaDados.Servicos.TRegistro_LanServico).lPecas.Exists(p => !string.IsNullOrEmpty(p.Cd_tecnico) && p.St_servicobool == false))
                    {
                        fPecas.Cd_tecnico = (bsOrdemServico.Current as CamadaDados.Servicos.TRegistro_LanServico).lPecas.LastOrDefault(p => !string.IsNullOrEmpty(p.Cd_tecnico) && p.St_servicobool == false).Cd_tecnico;
                        fPecas.Nm_tecnico = (bsOrdemServico.Current as CamadaDados.Servicos.TRegistro_LanServico).lPecas.LastOrDefault(p => !string.IsNullOrEmpty(p.Cd_tecnico) && p.St_servicobool == false).Nm_tecnico;
                    }
                    if (fPecas.ShowDialog() == DialogResult.OK)
                    {
                        //Inserir novo registro
                        (bsOrdemServico.Current as CamadaDados.Servicos.TRegistro_LanServico).lPecas.Add(fPecas.rPeca);
                        this.BuscaPecasServicos();
                        bsOrdemServico.ResetCurrentItem();
                        bsServico.ResetCurrentItem();
                    }
                }
            }
            else
                MessageBox.Show("Não existe ordem de serviço selecionada.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void afterAlterarPecas(bool st_servico)
        {
            if (bsOrdemServico.Current != null)
            {
                if (!st_servico && BS_Pecas.Current == null)
                {
                    MessageBox.Show("Obrigatorio selecionar peça para alterar.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (st_servico && bsServico.Current == null)
                {
                    MessageBox.Show("Obrigatorio selecionar Serviço para alterar.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                using (TFLan_Pecas_Ordem_Servico fPeca = new TFLan_Pecas_Ordem_Servico())
                {
                    fPeca.CD_Empresa = CD_Empresa.Text;
                    fPeca.Nm_empresa = NM_Empresa.Text;
                    fPeca.CD_TabelaPreco = CD_TabelaPreco.Text;
                    fPeca.St_alterar = true;
                    fPeca.pSt_servico = st_servico;
                    CamadaDados.Servicos.TRegistro_LanServicosPecas rPeca = new CamadaDados.Servicos.TRegistro_LanServicosPecas();
                    if (!st_servico)
                    {
                        fPeca.rPeca = BS_Pecas.Current as CamadaDados.Servicos.TRegistro_LanServicosPecas;
                        rPeca.Cd_produto = (BS_Pecas.Current as CamadaDados.Servicos.TRegistro_LanServicosPecas).Cd_produto;
                        rPeca.Ds_produto = (BS_Pecas.Current as CamadaDados.Servicos.TRegistro_LanServicosPecas).Ds_produto;
                        rPeca.Ds_unidproduto = (BS_Pecas.Current as CamadaDados.Servicos.TRegistro_LanServicosPecas).Ds_unidproduto;
                        rPeca.Sigla_unidproduto = (BS_Pecas.Current as CamadaDados.Servicos.TRegistro_LanServicosPecas).Sigla_unidproduto;
                        rPeca.Cd_local = (BS_Pecas.Current as CamadaDados.Servicos.TRegistro_LanServicosPecas).Cd_local;
                        rPeca.Ds_local = (BS_Pecas.Current as CamadaDados.Servicos.TRegistro_LanServicosPecas).Ds_local;
                        rPeca.Id_evolucao = (BS_Pecas.Current as CamadaDados.Servicos.TRegistro_LanServicosPecas).Id_evolucao;
                        rPeca.Ds_observacao = (BS_Pecas.Current as CamadaDados.Servicos.TRegistro_LanServicosPecas).Ds_observacao;
                        rPeca.Quantidade = (BS_Pecas.Current as CamadaDados.Servicos.TRegistro_LanServicosPecas).Quantidade;
                        rPeca.Vl_desconto = (BS_Pecas.Current as CamadaDados.Servicos.TRegistro_LanServicosPecas).Vl_desconto;
                        rPeca.Vl_acrescimo = (BS_Pecas.Current as CamadaDados.Servicos.TRegistro_LanServicosPecas).Vl_acrescimo;
                        rPeca.Vl_subtotal = (BS_Pecas.Current as CamadaDados.Servicos.TRegistro_LanServicosPecas).Vl_subtotal;
                        rPeca.Vl_SubTotalLiq = (BS_Pecas.Current as CamadaDados.Servicos.TRegistro_LanServicosPecas).Vl_SubTotalLiq;
                        rPeca.Vl_unitario = (BS_Pecas.Current as CamadaDados.Servicos.TRegistro_LanServicosPecas).Vl_unitario;
                        rPeca.St_atendimentogarantiabool = (BS_Pecas.Current as CamadaDados.Servicos.TRegistro_LanServicosPecas).St_atendimentogarantiabool;
                    }
                    else
                    {
                        fPeca.rPeca = (bsServico.Current as CamadaDados.Servicos.TRegistro_LanServicosPecas);
                        rPeca.Cd_produto = (bsServico.Current as CamadaDados.Servicos.TRegistro_LanServicosPecas).Cd_produto;
                        rPeca.Ds_produto = (bsServico.Current as CamadaDados.Servicos.TRegistro_LanServicosPecas).Ds_produto;
                        rPeca.Ds_unidproduto = (bsServico.Current as CamadaDados.Servicos.TRegistro_LanServicosPecas).Ds_unidproduto;
                        rPeca.Sigla_unidproduto = (bsServico.Current as CamadaDados.Servicos.TRegistro_LanServicosPecas).Sigla_unidproduto;
                        rPeca.Cd_local = (bsServico.Current as CamadaDados.Servicos.TRegistro_LanServicosPecas).Cd_local;
                        rPeca.Ds_local = (bsServico.Current as CamadaDados.Servicos.TRegistro_LanServicosPecas).Ds_local;
                        rPeca.Id_evolucao = (bsServico.Current as CamadaDados.Servicos.TRegistro_LanServicosPecas).Id_evolucao;
                        rPeca.Ds_observacao = (bsServico.Current as CamadaDados.Servicos.TRegistro_LanServicosPecas).Ds_observacao;
                        rPeca.Quantidade = (bsServico.Current as CamadaDados.Servicos.TRegistro_LanServicosPecas).Quantidade;
                        rPeca.Vl_desconto = (bsServico.Current as CamadaDados.Servicos.TRegistro_LanServicosPecas).Vl_desconto;
                        rPeca.Vl_acrescimo = (bsServico.Current as CamadaDados.Servicos.TRegistro_LanServicosPecas).Vl_acrescimo;
                        rPeca.Vl_subtotal = (bsServico.Current as CamadaDados.Servicos.TRegistro_LanServicosPecas).Vl_subtotal;
                        rPeca.Vl_SubTotalLiq = (bsServico.Current as CamadaDados.Servicos.TRegistro_LanServicosPecas).Vl_SubTotalLiq;
                        rPeca.Vl_unitario = (bsServico.Current as CamadaDados.Servicos.TRegistro_LanServicosPecas).Vl_unitario;
                        rPeca.St_atendimentogarantiabool = (bsServico.Current as CamadaDados.Servicos.TRegistro_LanServicosPecas).St_atendimentogarantiabool;
                    }
                    if (fPeca.ShowDialog() != DialogResult.OK)
                    {
                        if (!st_servico)
                        {
                            (BS_Pecas.Current as CamadaDados.Servicos.TRegistro_LanServicosPecas).Cd_produto = rPeca.Cd_produto;
                            (BS_Pecas.Current as CamadaDados.Servicos.TRegistro_LanServicosPecas).Ds_produto = rPeca.Ds_produto;
                            (BS_Pecas.Current as CamadaDados.Servicos.TRegistro_LanServicosPecas).Ds_unidproduto = rPeca.Ds_unidproduto;
                            (BS_Pecas.Current as CamadaDados.Servicos.TRegistro_LanServicosPecas).Sigla_unidproduto = rPeca.Sigla_unidproduto;
                            (BS_Pecas.Current as CamadaDados.Servicos.TRegistro_LanServicosPecas).Cd_local = rPeca.Cd_local;
                            (BS_Pecas.Current as CamadaDados.Servicos.TRegistro_LanServicosPecas).Ds_local = rPeca.Ds_local;
                            (BS_Pecas.Current as CamadaDados.Servicos.TRegistro_LanServicosPecas).Id_evolucao = rPeca.Id_evolucao;
                            (BS_Pecas.Current as CamadaDados.Servicos.TRegistro_LanServicosPecas).Ds_observacao = rPeca.Ds_observacao;
                            (BS_Pecas.Current as CamadaDados.Servicos.TRegistro_LanServicosPecas).Quantidade = rPeca.Quantidade;
                            (BS_Pecas.Current as CamadaDados.Servicos.TRegistro_LanServicosPecas).Vl_desconto = rPeca.Vl_desconto;
                            (BS_Pecas.Current as CamadaDados.Servicos.TRegistro_LanServicosPecas).Vl_acrescimo = rPeca.Vl_acrescimo;
                            (BS_Pecas.Current as CamadaDados.Servicos.TRegistro_LanServicosPecas).Vl_subtotal = rPeca.Vl_subtotal;
                            (BS_Pecas.Current as CamadaDados.Servicos.TRegistro_LanServicosPecas).Vl_SubTotalLiq = rPeca.Vl_SubTotalLiq;
                            (BS_Pecas.Current as CamadaDados.Servicos.TRegistro_LanServicosPecas).Vl_unitario = rPeca.Vl_unitario;
                            (BS_Pecas.Current as CamadaDados.Servicos.TRegistro_LanServicosPecas).St_atendimentogarantiabool = rPeca.St_atendimentogarantiabool;
                        }
                        else
                        {
                            (bsServico.Current as CamadaDados.Servicos.TRegistro_LanServicosPecas).Cd_produto = rPeca.Cd_produto;
                            (bsServico.Current as CamadaDados.Servicos.TRegistro_LanServicosPecas).Ds_produto = rPeca.Ds_produto;
                            (bsServico.Current as CamadaDados.Servicos.TRegistro_LanServicosPecas).Ds_unidproduto = rPeca.Ds_unidproduto;
                            (bsServico.Current as CamadaDados.Servicos.TRegistro_LanServicosPecas).Sigla_unidproduto = rPeca.Sigla_unidproduto;
                            (bsServico.Current as CamadaDados.Servicos.TRegistro_LanServicosPecas).Cd_local = rPeca.Cd_local;
                            (bsServico.Current as CamadaDados.Servicos.TRegistro_LanServicosPecas).Ds_local = rPeca.Ds_local;
                            (bsServico.Current as CamadaDados.Servicos.TRegistro_LanServicosPecas).Id_evolucao = rPeca.Id_evolucao;
                            (bsServico.Current as CamadaDados.Servicos.TRegistro_LanServicosPecas).Ds_observacao = rPeca.Ds_observacao;
                            (bsServico.Current as CamadaDados.Servicos.TRegistro_LanServicosPecas).Quantidade = rPeca.Quantidade;
                            (bsServico.Current as CamadaDados.Servicos.TRegistro_LanServicosPecas).Vl_desconto = rPeca.Vl_desconto;
                            (bsServico.Current as CamadaDados.Servicos.TRegistro_LanServicosPecas).Vl_acrescimo = rPeca.Vl_acrescimo;
                            (bsServico.Current as CamadaDados.Servicos.TRegistro_LanServicosPecas).Vl_subtotal = rPeca.Vl_subtotal;
                            (bsServico.Current as CamadaDados.Servicos.TRegistro_LanServicosPecas).Vl_SubTotalLiq = rPeca.Vl_SubTotalLiq;
                            (bsServico.Current as CamadaDados.Servicos.TRegistro_LanServicosPecas).Vl_unitario = rPeca.Vl_unitario;
                            (bsServico.Current as CamadaDados.Servicos.TRegistro_LanServicosPecas).St_atendimentogarantiabool = rPeca.St_atendimentogarantiabool;
                        }
                    }
                    if (!st_servico)
                        BS_Pecas.ResetCurrentItem();
                    else bsServico.ResetCurrentItem();
                }
            }
            else
                MessageBox.Show("Não existe peça(serviço) selecionado.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void afterExcluirPecas(bool st_servico)
        {
            if (bsOrdemServico.Current != null)
            {
                if (!st_servico)
                {
                    if (BS_Pecas.Current == null)
                    {
                        MessageBox.Show("Obrigatorio selecionar peça para excluir.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    if (MessageBox.Show("Peça/serviço selecionado: " + (BS_Pecas.Current as CamadaDados.Servicos.TRegistro_LanServicosPecas).Cd_produto.Trim() + "-" +
                                                                    (BS_Pecas.Current as CamadaDados.Servicos.TRegistro_LanServicosPecas).Ds_produto.Trim() +
                                        "\r\n\r\nConfirma exclusão?", "Pergunta", MessageBoxButtons.YesNo,
                                        MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    {
                        //Adicionar item na lista a ser excluido
                        (bsOrdemServico.Current as CamadaDados.Servicos.TRegistro_LanServico).Deleta_lPecas.Add(
                            BS_Pecas.Current as CamadaDados.Servicos.TRegistro_LanServicosPecas);
                        //Excluir item do grid
                        (bsOrdemServico.Current as CamadaDados.Servicos.TRegistro_LanServico).lPecas.Remove(
                            BS_Pecas.Current as CamadaDados.Servicos.TRegistro_LanServicosPecas);
                        bsOrdemServico.ResetCurrentItem();
                        this.BuscaPecasServicos();
                    }
                }
                else
                {
                    if (bsServico.Current == null)
                    {
                        MessageBox.Show("Obrigatorio selecionar serviço para excluir.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    if (MessageBox.Show("Peça/serviço selecionado: " + (bsServico.Current as CamadaDados.Servicos.TRegistro_LanServicosPecas).Cd_produto.Trim() + "-" +
                                                                    (bsServico.Current as CamadaDados.Servicos.TRegistro_LanServicosPecas).Ds_produto.Trim() +
                                        "\r\n\r\nConfirma exclusão?", "Pergunta", MessageBoxButtons.YesNo,
                                        MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    {
                        //Adicionar item na lista a ser excluido
                        (bsOrdemServico.Current as CamadaDados.Servicos.TRegistro_LanServico).Deleta_lServico.Add(
                            bsServico.Current as CamadaDados.Servicos.TRegistro_LanServicosPecas);
                        //Excluir item do grid
                        (bsOrdemServico.Current as CamadaDados.Servicos.TRegistro_LanServico).lPecas.Remove(
                            bsServico.Current as CamadaDados.Servicos.TRegistro_LanServicosPecas);
                        bsOrdemServico.ResetCurrentItem();
                        this.BuscaPecasServicos();
                    }
                }
            }
            else
                MessageBox.Show("Não existe ordem Peça/Serviço selecionado.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BuscaPecasServicos()
        {
            //Buscar Pecas 
            BS_Pecas.DataSource = (bsOrdemServico.Current as CamadaDados.Servicos.TRegistro_LanServico).lPecas.FindAll(p => p.St_servicobool == false);

            //Buscar Servicos
            bsServico.DataSource = (bsOrdemServico.Current as CamadaDados.Servicos.TRegistro_LanServico).lPecas.FindAll(p => p.St_servicobool);

        }

        private void ImageShow()
        {
            if (bsImagens.Current != null)
            {
                if ((bsImagens.Current as CamadaDados.Servicos.Cadastros.TRegistro_Imagens).Foto_imagem != null)
                {
                    //Criar Form
                    Form fImagem = new Form();
                    fImagem.Size = new Size(1040, 720);
                    fImagem.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
                    fImagem.ShowInTaskbar = false;
                    fImagem.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
                    fImagem.MinimizeBox = false;
                    fImagem.FormBorderStyle = FormBorderStyle.Fixed3D;
                    fImagem.Text = "Visualizador de IMAGENS -  Aliance.Net";

                    //Criar Panel
                    Panel panel = new Panel();
                    panel.Dock = DockStyle.Fill;
                    //Criar PictureBox
                    PictureBox img = new PictureBox();
                    this.bindingNavigator3.Dock = System.Windows.Forms.DockStyle.Bottom;
                    bindingNavigator3.BindingSource = this.bsImagens;
                    fImagem.Controls.Add(panel);
                    panel.Controls.Add(img);
                    panel.Controls.Add(this.bindingNavigator3);
                    img.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                    img.Dock = DockStyle.Fill;
                    img.SizeMode = PictureBoxSizeMode.StretchImage;
                    img.DataBindings.Add(new System.Windows.Forms.Binding("Image", this.bsImagens, "Foto_imagem", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
                    fImagem.ShowDialog();
                }
                else
                    try { System.Diagnostics.Process.Start((bsImagens.Current as CamadaDados.Servicos.Cadastros.TRegistro_Imagens).Ds_imagem.Trim()); }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
            }
        }

        private void InserirImagem()
        {
            try
            {
                if (bsOrdemServico.Current != null)
                {
                    Utils.InputBox ibp = new Utils.InputBox();
                    ibp.Text = "Descrição Imagem";
                    string ds = ibp.ShowDialog();
                    if (string.IsNullOrEmpty(ds))
                    {
                        MessageBox.Show("Obrigatório informar Descrição da imagem!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    OpenFileDialog ofd = new OpenFileDialog();
                    ofd.Filter = "IMAGENS|*.jpg";
                    if (ofd.ShowDialog() == DialogResult.OK)
                        if (System.IO.File.Exists(ofd.FileName))
                        {
                            (bsOrdemServico.Current as CamadaDados.Servicos.TRegistro_LanServico).lImagens.Add(new CamadaDados.Servicos.Cadastros.TRegistro_Imagens()
                            {
                                Id_osstr = (bsOrdemServico.Current as CamadaDados.Servicos.TRegistro_LanServico).Id_osstr,
                                Cd_empresa = (bsOrdemServico.Current as CamadaDados.Servicos.TRegistro_LanServico).Cd_empresa,
                                Ds_imagem = ds,
                                Foto_imagem = Image.FromFile(ofd.FileName)
                            });
                            bsOrdemServico.ResetCurrentItem();
                        }
                }
            }
            catch (Exception ex)
            { MessageBox.Show("Erro localizar imagem: " + ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void ExcluirImagem()
        {
            if (bsOrdemServico.Current != null)
            {
                if (bsImagens.Current == null)
                {
                    MessageBox.Show("Obrigatorio selecionar imagem para excluir!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (MessageBox.Show("Imagem selecionada: " + (bsImagens.Current as CamadaDados.Servicos.Cadastros.TRegistro_Imagens).Id_imagemstr.Trim() + "-" +
                                                                (bsImagens.Current as CamadaDados.Servicos.Cadastros.TRegistro_Imagens).Ds_imagem.Trim() +
                                    "\r\n\r\nConfirma exclusão?", "Pergunta", MessageBoxButtons.YesNo,
                                    MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    //Adicionar item na lista a ser excluido
                    (bsOrdemServico.Current as CamadaDados.Servicos.TRegistro_LanServico).lImagensDel.Add(
                        bsImagens.Current as CamadaDados.Servicos.Cadastros.TRegistro_Imagens);
                    //Excluir item do grid
                    (bsOrdemServico.Current as CamadaDados.Servicos.TRegistro_LanServico).lImagens.Remove(
                        bsImagens.Current as CamadaDados.Servicos.Cadastros.TRegistro_Imagens);
                    bsOrdemServico.ResetCurrentItem();
                }
            }
        }

        private void InserirPath()
        {
            try
            {
                using (FolderBrowserDialog fFile = new FolderBrowserDialog())
                {
                    if (fFile.ShowDialog() == DialogResult.OK)
                        if (!string.IsNullOrEmpty(fFile.SelectedPath))
                        {
                            (bsOrdemServico.Current as CamadaDados.Servicos.TRegistro_LanServico).lImagens.Add(new CamadaDados.Servicos.Cadastros.TRegistro_Imagens()
                            {
                                Id_osstr = (bsOrdemServico.Current as CamadaDados.Servicos.TRegistro_LanServico).Id_osstr,
                                Cd_empresa = (bsOrdemServico.Current as CamadaDados.Servicos.TRegistro_LanServico).Cd_empresa,
                                Ds_imagem = fFile.SelectedPath.Trim()
                            });
                            bsOrdemServico.ResetCurrentItem();
                        }
                }
            }
            catch (Exception ex)
            { MessageBox.Show("Erro localizar anexo: " + ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void TFEvoluirOSTarefa_Load(object sender, EventArgs e)
        {
            tlpAnexo.ColumnStyles[2] = new ColumnStyle(SizeType.Absolute, 0);
            tlpAnexo.ColumnStyles[1] = new ColumnStyle(SizeType.Absolute, 0);
            Utils.ShapeGrid.RestoreShape(this, g_Pecas);
            Utils.ShapeGrid.RestoreShape(this, gServico);
            Utils.ShapeGrid.RestoreShape(this, gEvolucao);
            pOS.set_FormatZero();
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            bsOrdemServico.DataSource = new CamadaDados.Servicos.TList_LanServico() { rOS };
            this.BuscaPecasServicos();
            bool st_fin = CamadaNegocio.Diversos.TCN_Usuario_RegraEspecial.ValidaRegra(Utils.Parametros.pubLogin, "PERMITIR VISUALIZAR DETALHES FINANCEIRO", null);
            if (!st_fin)
            {
                tcProjeto.TabPages.Remove(tpServico);
                tcProjeto.TabPages.Remove(tpPecas);
            }
            //Verificar se etapas possuem ordenação
            if ((bsOrdemServico.Current as CamadaDados.Servicos.TRegistro_LanServico).lEvolucao.Exists(p => p.Ordem == decimal.Zero))
            {
                for (int i = 0; bsEvolucao.Count > 0; i++)
                    (bsEvolucao[i] as CamadaDados.Servicos.TRegistro_LanServicoEvolucao).Ordem = i + 1;
            }
        }

        private void CD_Clifor_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveClifor("a.cd_clifor|=|'" + CD_Clifor.Text.Trim() + "';" +
                                                    "isnull(a.st_fornecedor, 'N')|<>|'S';" +
                                                    "isnull(a.ST_Funcionarios, 'N')|<>|'S';" +
                                                    "isnull(a.st_representante, 'N')|<>|'S';" +
                                                    "isnull(a.st_transportadora, 'N')|<>|'S'",
                                                    new Componentes.EditDefault[] { CD_Clifor, NM_Clifor },
                                                    new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
            //Buscar endereco
            this.BuscarEndereco();
        }

        private void BB_Clifor_Click(object sender, EventArgs e)
        {
            string vParam = "isnull(a.st_fornecedor, 'N')|<>|'S';" +
                          "isnull(a.ST_Funcionarios, 'N')|<>|'S';" +
                          "isnull(a.st_representante, 'N')|<>|'S';" +
                          "isnull(a.st_transportadora, 'N')|<>|'S'";
            FormBusca.UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { CD_Clifor, NM_Clifor }, vParam);
            //Buscar endereco
            this.BuscarEndereco();
        }

        private void bb_cadclifor_Click(object sender, EventArgs e)
        {
            using (Financeiro.Cadastros.TFCadCliforResumido fClifor = new Financeiro.Cadastros.TFCadCliforResumido())
            {
                if (fClifor.ShowDialog() == DialogResult.OK)
                    try
                    {
                        CamadaNegocio.Financeiro.Cadastros.TCN_CadClifor.Gravar(fClifor.rClifor, null);
                        MessageBox.Show("Cliente cadastrado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CD_Clifor.Text = fClifor.rClifor.Cd_clifor;
                        NM_Clifor.Text = fClifor.rClifor.Nm_clifor;
                        CD_Endereco.Text = fClifor.rClifor.lEndereco[0].Cd_endereco;
                        DS_Endereco.Text = fClifor.rClifor.lEndereco[0].Ds_endereco;
                        DS_Cidade.Text = fClifor.rClifor.lEndereco[0].DS_Cidade;
                        UF.Text = fClifor.rClifor.lEndereco[0].UF;
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void CD_Endereco_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_clifor|=|'" + CD_Clifor.Text.Trim() + "';" +
                            "a.cd_endereco|=|'" + CD_Endereco.Text.Trim() + "'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { CD_Endereco, DS_Endereco, DS_Cidade, UF },
                                                new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco());
        }

        private void BB_Endereco_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_endereco|Endereco|150;" +
                              "a.cd_endereco|Código Endereço|80;" +
                              "b.DS_Cidade|Cidade|250;" +
                              "UF|Estado|150";
            string vParam = "a.cd_clifor|=|'" + CD_Clifor.Text.Trim() + "'";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { CD_Endereco, DS_Endereco, DS_Cidade, UF },
                                                new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco(), vParam);
        }

        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btn_Inserir_Item_Click(object sender, EventArgs e)
        {
            this.afterInserirEvolucao();
        }

        private void btn_deletar_item_Click(object sender, EventArgs e)
        {
            this.afterExcluirEvolucao();
        }

        private void InserirServicos_Click(object sender, EventArgs e)
        {
            this.afterInserirPecas(true);
        }

        private void AlterarServicos_Click(object sender, EventArgs e)
        {
            this.afterAlterarPecas(true);
        }

        private void excluirServicos_Click(object sender, EventArgs e)
        {
            this.afterExcluirPecas(true);
        }

        private void btn_inserirImagem_Click(object sender, EventArgs e)
        {
            this.InserirImagem();
        }

        private void btn_excluirImagem_Click(object sender, EventArgs e)
        {
            this.ExcluirImagem();
        }

        private void bb_inserirPath_Click(object sender, EventArgs e)
        {
            this.InserirPath();
        }

        private void TFEvoluirOSTarefa_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, g_Pecas);
            Utils.ShapeGrid.SaveShape(this, gServico);
            Utils.ShapeGrid.SaveShape(this, gEvolucao);
        }

        private void TFEvoluirOSTarefa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.DialogResult = DialogResult.OK;
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
            else if (tcProjeto.SelectedTab.Equals(tpEtapa) && e.Control && e.KeyCode.Equals(Keys.F10))
                this.afterInserirEvolucao();
            else if (tcProjeto.SelectedTab.Equals(tpEtapa) && e.Control && e.KeyCode.Equals(Keys.F12))
                this.afterExcluirEvolucao();
            else if (tcProjeto.SelectedTab.Equals(tpServico) && e.Control && e.KeyCode.Equals(Keys.F10))
                this.afterInserirPecas(true);
            else if (tcProjeto.SelectedTab.Equals(tpServico) && e.Control && e.KeyCode.Equals(Keys.F11))
                this.afterAlterarPecas(true);
            else if (tcProjeto.SelectedTab.Equals(tpServico) && e.Control && e.KeyCode.Equals(Keys.F12))
                this.afterExcluirPecas(true);
            else if (tcProjeto.SelectedTab.Equals(tpImagem) && e.KeyCode.Equals(Keys.Right))
                this.InserirPath();
            else if (tcProjeto.SelectedTab.Equals(tpImagem) && e.Control && e.KeyCode.Equals(Keys.F10))
                this.InserirImagem();
            else if (tcProjeto.SelectedTab.Equals(tpImagem) && e.Control && e.KeyCode.Equals(Keys.F12))
                this.ExcluirImagem();
            else if (tcProjeto.SelectedTab.Equals(tpPecas) && e.Control && e.KeyCode.Equals(Keys.F10))
                this.afterInserirPecas(false);
            else if (tcProjeto.SelectedTab.Equals(tpPecas) && e.Control && e.KeyCode.Equals(Keys.F11))
                this.afterAlterarPecas(false);
            else if (tcProjeto.SelectedTab.Equals(tpPecas) && e.Control && e.KeyCode.Equals(Keys.F12))
                this.afterExcluirPecas(false);
        }

        private void gImagem_DoubleClick(object sender, EventArgs e)
        {
            this.ImageShow();
        }

        private void ptbImagem_DoubleClick(object sender, EventArgs e)
        {
            this.ImageShow();
        }

        private void bsImagens_PositionChanged(object sender, EventArgs e)
        {
            if (bsImagens.Current != null)
            {
                if ((bsImagens.Current as CamadaDados.Servicos.Cadastros.TRegistro_Imagens).Foto_imagem != null)
                {
                    tlpAnexo.ColumnStyles[2] = new ColumnStyle(SizeType.Absolute, 460);
                    tlpAnexo.ColumnStyles[1] = new ColumnStyle(SizeType.Absolute, 0);
                }
                else
                {
                    tlpAnexo.ColumnStyles[2] = new ColumnStyle(SizeType.Absolute, 0);
                    tlpAnexo.ColumnStyles[1] = new ColumnStyle(SizeType.Absolute, 460);
                    lView.Clear();
                    //Marca o diretório a ser listado
                    DirectoryInfo diretorio = new DirectoryInfo((bsImagens.Current as CamadaDados.Servicos.Cadastros.TRegistro_Imagens).Ds_imagem.Trim());
                    //Executa função GetFile(Lista os arquivos desejados de acordo com o parametro)
                    FileInfo[] Arquivos = diretorio.GetFiles("*.*");

                    //Começamos a listar os arquivos
                    foreach (FileInfo fileinfo in Arquivos)
                    {
                        lView.Items.Add(fileinfo.ToString());
                    }
                }

                bsImagens.ResetCurrentItem();
            }
            else
            {
                tlpAnexo.ColumnStyles[2] = new ColumnStyle(SizeType.Absolute, 0);
                tlpAnexo.ColumnStyles[1] = new ColumnStyle(SizeType.Absolute, 0);
            }
        }

        private void lView_DoubleClick(object sender, EventArgs e)
        {
            if (bsImagens.Current != null && lView.Items.Count > 0)
            {
                try
                {
                    System.Diagnostics.Process.Start((bsImagens.Current as CamadaDados.Servicos.Cadastros.TRegistro_Imagens).Ds_imagem.Trim() + "\\" +
                        lView.FocusedItem.Text);
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void btn_inserirPecas_Click(object sender, EventArgs e)
        {
            this.afterInserirPecas(false);
        }

        private void btn_alterarPecas_Click(object sender, EventArgs e)
        {
            this.afterAlterarPecas(false);
        }

        private void btn_deletarPecas_Click(object sender, EventArgs e)
        {
            this.afterExcluirPecas(false);
        }

        private void BB_TabelaPreco_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_tabelapreco|Tabela Preço|200;" +
                             "a.cd_tabelapreco|Cd. Tabela|80";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { CD_TabelaPreco, NM_TabelaPreco },
                                            new CamadaDados.Diversos.TCD_CadTbPreco(), string.Empty);
        }

        private void CD_TabelaPreco_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LEAVE("a.cd_tabelapreco|=|'" + CD_TabelaPreco.Text.Trim() + "'",
                                               new Componentes.EditDefault[] { CD_TabelaPreco, NM_TabelaPreco },
                                               new CamadaDados.Diversos.TCD_CadTbPreco());
        }
    }
}
