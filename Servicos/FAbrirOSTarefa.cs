using System;
using System.Collections.Generic;
using System.ComponentModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Utils;
using System.IO;

namespace Servicos
{
    public partial class TFAbrirOSTarefa : Form
    {
        public CamadaDados.Servicos.TRegistro_LanServico rOS
        { get { return bsOrdemServico.Current as CamadaDados.Servicos.TRegistro_LanServico; } }
        public TFAbrirOSTarefa()
        {
            InitializeComponent();
        }

        private void afterGrava()
        {
            if (pDados.validarCampoObrigatorio())
            {
                if (string.IsNullOrEmpty(CD_Clifor.Text) &&
                    string.IsNullOrEmpty(NM_Clifor.Text))
                {
                    MessageBox.Show("Obrigatório informar cliente.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (!CD_Clifor.Focus())
                        NM_Clifor.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(ds_obsgeral.Text))
                {
                    MessageBox.Show("Obrigatório informar Descrição PROJETO!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    tcProjeto.SelectedTab = tpDS_OS;
                    ds_obsgeral.Focus();
                    return;
                }
                this.DialogResult = DialogResult.OK;
            }
        }

        private void ValidarNumeroOs()
        {
            object obj = new CamadaDados.Servicos.TCD_LanServico().BuscarEscalar(
                new Utils.TpBusca[]
                {
                    new Utils.TpBusca()
                    {
                        vNM_Campo = "a.cd_empresa",
                        vOperador = "=",
                        vVL_Busca = "'" + CD_Empresa.Text.Trim() + "'"
                    },
                    new Utils.TpBusca()
                    {
                        vNM_Campo = "a.id_os",
                        vOperador = "=",
                        vVL_Busca = id_os.Value.ToString()
                    }
                }, "1");

            if (obj != null)
            {
                MessageBox.Show("Ja existe uma ordem de serviço com este numero para a empresa " + CD_Empresa.Text.Trim() + ".",
                                "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                id_os.Value = id_os.Minimum;
                id_os.Focus();
            }
        }

        private void InfData()
        {
            try
            {
                object obj = new CamadaDados.Servicos.Cadastros.TCD_TpOrdem().BuscarEscalar(
                    new TpBusca[]
                {
                    new TpBusca()
                    {
                        vNM_Campo = "a.TP_Ordem",
                        vOperador = "=",
                        vVL_Busca = "'" + TP_Ordem.Text.Trim() + "'"  
                    }
                }, "a.ST_InfDtAbertura");

                if (obj.Equals("S"))
                    DT_Abertura.Enabled = true;
                else
                    DT_Abertura.Enabled = false;
            }
            catch { }
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
                    InputBox ibp = new InputBox();
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

        private void TFAbrirOSTarefa_Load(object sender, EventArgs e)
        {
            tlpDetalhes.ColumnStyles[1] = new ColumnStyle(SizeType.Absolute, 0);
            tlpDetalhes.ColumnStyles[2] = new ColumnStyle(SizeType.Absolute, 0);
            Utils.ShapeGrid.RestoreShape(this, gServico);
            Utils.ShapeGrid.RestoreShape(this, g_Pecas);
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pDados.set_FormatZero();
            //Adicionar nova OS
            bsOrdemServico.AddNew();
            DT_Abertura.Enabled = false;
            CD_Empresa.Focus();
            bool st_fin = CamadaNegocio.Diversos.TCN_Usuario_RegraEspecial.ValidaRegra(Utils.Parametros.pubLogin, "PERMITIR VISUALIZAR DETALHES FINANCEIRO", null);
            if (!st_fin)
            {
                tcCentral.TabPages.Remove(tpServicos);
                tcCentral.TabPages.Remove(tpPecas);
            }
        }

        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            this.afterGrava();
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void bb_inserirServicos_Click(object sender, EventArgs e)
        {
            this.afterInserirPecas(true);
        }

        private void bb_alterarServicos_Click(object sender, EventArgs e)
        {
            this.afterAlterarPecas(true);
        }

        private void bb_excluirServicos_Click(object sender, EventArgs e)
        {
            this.afterExcluirPecas(true);
        }

        private void TFAbrirOSTarefa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
            else if (tcCentral.SelectedTab.Equals(tpServicos) && e.Control && e.KeyCode.Equals(Keys.F10))
                this.afterInserirPecas(true);
            else if (tcCentral.SelectedTab.Equals(tpServicos) && e.Control && e.KeyCode.Equals(Keys.F11))
                this.afterAlterarPecas(true);
            else if (tcCentral.SelectedTab.Equals(tpServicos) && e.Control && e.KeyCode.Equals(Keys.F12))
                this.afterExcluirPecas(true);
            else if (tcCentral.SelectedTab.Equals(tpImagem) && e.KeyCode.Equals(Keys.Right))
                this.InserirPath();
            else if (tcCentral.SelectedTab.Equals(tpImagem) && e.Control && e.KeyCode.Equals(Keys.F10))
                this.InserirImagem();
            else if (tcCentral.SelectedTab.Equals(tpImagem) && e.Control && e.KeyCode.Equals(Keys.F12))
                this.ExcluirImagem();
            else if (tcCentral.SelectedTab.Equals(tpPecas) && e.Control && e.KeyCode.Equals(Keys.F10))
                this.afterInserirPecas(false);
            else if (tcCentral.SelectedTab.Equals(tpPecas) && e.Control && e.KeyCode.Equals(Keys.F11))
                this.afterAlterarPecas(false);
            else if (tcCentral.SelectedTab.Equals(tpPecas) && e.Control && e.KeyCode.Equals(Keys.F12))
                this.afterExcluirPecas(false);
        }

        private void TFAbrirOSTarefa_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, gServico);
            Utils.ShapeGrid.SaveShape(this, g_Pecas);
        }

        private void BB_Empresa_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaEmpresa(new Componentes.EditDefault[] { CD_Empresa, NM_Empresa }, string.Empty);
        }

        private void CD_Empresa_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveEmpresa("a.cd_empresa|=|'" + CD_Empresa.Text.Trim() + "'", new Componentes.EditDefault[] { CD_Empresa, NM_Empresa });
        }

        private void TP_Ordem_Leave(object sender, EventArgs e)
        {
            string vParam = "a.tp_ordem|=|" + TP_Ordem.Text + ";" +
                            "||(a.tp_os = 'S') or (a.tp_os = 'I');" +
                            "|exists|(select 1 from tb_ose_paramos x " +
                            "           where x.tp_ordem = a.tp_ordem)";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { TP_Ordem, DS_TPOrdem, CD_TabelaPreco, NM_TabelaPreco },
                                            new CamadaDados.Servicos.Cadastros.TCD_TpOrdem());
            if (!string.IsNullOrEmpty(TP_Ordem.Text))
            {
                id_os.Enabled = CamadaNegocio.Servicos.TCN_LanServico.SequenciaManual(bsOrdemServico.Current as CamadaDados.Servicos.TRegistro_LanServico, null);
                if (!id_os.Enabled)
                    id_os.Value = id_os.Minimum;
            }
            this.InfData();
        }

        private void BB_TPOrdem_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_tipoordem|Tipo Ordem|200;" +
                              "a.tp_ordem|TP. Ordem|80;" +
                              "b.cd_tabelapreco|Cd. Tabela|80;" +
                              "c.ds_tabelapreco|Tabela Preço|200";
            string vParam = "||(a.tp_os = 'S') or (a.tp_os = 'I');" +
                            "|exists|(select 1 from tb_ose_paramos x " +
                            "           where x.tp_ordem = a.tp_ordem)";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { TP_Ordem, DS_TPOrdem, CD_TabelaPreco, NM_TabelaPreco },
                                            new CamadaDados.Servicos.Cadastros.TCD_TpOrdem(), vParam);
            if (!string.IsNullOrEmpty(TP_Ordem.Text))
            {
                id_os.Enabled = CamadaNegocio.Servicos.TCN_LanServico.SequenciaManual(bsOrdemServico.Current as CamadaDados.Servicos.TRegistro_LanServico, null);
                if (!id_os.Enabled)
                    id_os.Value = id_os.Minimum;
            }
            this.InfData();
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
            if (!string.IsNullOrEmpty(CD_Clifor.Text))
            {
                //Buscar endereco
                this.BuscarEndereco();
                NM_Clifor.Enabled = false;
            }
            else
            {
                NM_Clifor.Enabled = true;
                CD_Endereco.Clear();
                DS_Endereco.Clear();
                DS_Cidade.Clear();
                UF.Clear();
            }
        }

        private void BB_Clifor_Click(object sender, EventArgs e)
        {
            string vParam = "isnull(a.st_fornecedor, 'N')|<>|'S';" +
                           "isnull(a.ST_Funcionarios, 'N')|<>|'S';" +
                           "isnull(a.st_representante, 'N')|<>|'S';" +
                           "isnull(a.st_transportadora, 'N')|<>|'S'";
            FormBusca.UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { CD_Clifor, NM_Clifor }, vParam);
            if (!string.IsNullOrEmpty(CD_Clifor.Text))
            {
                //Buscar endereco
                this.BuscarEndereco();
                NM_Clifor.Enabled = false;
            }
            else
            {
                NM_Clifor.Enabled = true;
                CD_Endereco.Clear();
                DS_Endereco.Clear();
                DS_Cidade.Clear();
                UF.Clear();
            }
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

        private void CD_TabelaPreco_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LEAVE("a.cd_tabelapreco|=|'" + CD_TabelaPreco.Text.Trim() + "'",
                                                new Componentes.EditDefault[] { CD_TabelaPreco, NM_TabelaPreco },
                                                new CamadaDados.Diversos.TCD_CadTbPreco());
        }

        private void BB_TabelaPreco_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_tabelapreco|Tabela Preço|200;" +
                              "a.cd_tabelapreco|Cd. Tabela|80";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { CD_TabelaPreco, NM_TabelaPreco },
                                            new CamadaDados.Diversos.TCD_CadTbPreco(), string.Empty);
        }

        private void id_os_Leave(object sender, EventArgs e)
        {
            this.ValidarNumeroOs();
        }

        private void DT_Prevista_Leave(object sender, EventArgs e)
        {
            if (DT_Abertura.Data > DT_Prevista.Data)
            {
                MessageBox.Show("Dt.Prevista menor do que a Dt.Abertura!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DT_Prevista.Clear();
                DT_Prevista.Focus();
            }
        }

        private void btn_inserirImagem_Click(object sender, EventArgs e)
        {
            this.InserirImagem();
        }

        private void btn_excluirImagem_Click(object sender, EventArgs e)
        {
            this.ExcluirImagem();
        }

        private void gImagem_DoubleClick(object sender, EventArgs e)
        {
            this.ImageShow();
        }

        private void ptbImagem_DoubleClick(object sender, EventArgs e)
        {
            this.ImageShow();
        }

        private void bb_inserirPath_Click(object sender, EventArgs e)
        {
            this.InserirPath();
        }

        private void bsImagens_PositionChanged(object sender, EventArgs e)
        {
            if (bsImagens.Current != null)
            {
                if ((bsImagens.Current as CamadaDados.Servicos.Cadastros.TRegistro_Imagens).Foto_imagem != null)
                {
                    tlpDetalhes.ColumnStyles[2] = new ColumnStyle(SizeType.Absolute, 460);
                    tlpDetalhes.ColumnStyles[1] = new ColumnStyle(SizeType.Absolute, 0);
                }
                else
                {
                    tlpDetalhes.ColumnStyles[2] = new ColumnStyle(SizeType.Absolute, 0);
                    tlpDetalhes.ColumnStyles[1] = new ColumnStyle(SizeType.Absolute, 460);
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
                tlpDetalhes.ColumnStyles[2] = new ColumnStyle(SizeType.Absolute, 0);
                tlpDetalhes.ColumnStyles[1] = new ColumnStyle(SizeType.Absolute, 0);
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
    }
}
