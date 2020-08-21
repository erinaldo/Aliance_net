using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FormBusca;
using CamadaDados.Financeiro.Cadastros;
using Componentes;
using Utils;

namespace Servicos
{
    public partial class TFLan_Lote : Form
    {
        private bool Altera_Relatorio = false;

        Utils.TTpModo vModo;

        public TFLan_Lote()
        {
            InitializeComponent();
            this.vModo = Utils.TTpModo.tm_Standby;
        }

        private void HabilitarCampos(bool value)
        {
            pLote.HabilitarControls(value, this.vModo);
            cd_empresa.Enabled = value && this.vModo.Equals(Utils.TTpModo.tm_Insert);
            bb_empresa.Enabled = value && this.vModo.Equals(Utils.TTpModo.tm_Insert);
        }

        private void HabilitarPages()
        {
            if (vModo.Equals(Utils.TTpModo.tm_Standby) || vModo.Equals(Utils.TTpModo.tm_busca))
            {
                if (!tcCentral.TabPages.Contains(tpNavegador))
                    tcCentral.TabPages.Add(tpNavegador);
                if (tcCentral.TabPages.Contains(tpLote))
                    tcCentral.TabPages.Remove(tpLote);
            }
            else
            {
                if (tcCentral.TabPages.Contains(tpNavegador))
                    tcCentral.TabPages.Remove(tpNavegador);
                if (!tcCentral.TabPages.Contains(tpLote))
                    tcCentral.TabPages.Add(tpLote);
            }
        }

        private void afterNovo()
        {
            if (vModo.Equals(Utils.TTpModo.tm_Standby) || vModo.Equals(Utils.TTpModo.tm_busca))
            {
                vModo = Utils.TTpModo.tm_Insert;
                bsLote.AddNew();
                this.HabilitarPages();
                this.HabilitarCampos(true);
                cd_empresa.Focus();
            }
        }

        private void afterGrava()
        {
            if (vModo.Equals(Utils.TTpModo.tm_Insert) || vModo.Equals(Utils.TTpModo.tm_Edit))
            {
                if (ds_lote.Text.Trim().Equals(string.Empty))
                {
                    MessageBox.Show("Obrigatorio informar descrição lote.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ds_lote.Focus();
                    return;
                }
                if (cd_fornecedor.Text.Trim().Equals(string.Empty))
                {
                    MessageBox.Show("Obrigatorio informar fornecedor.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cd_fornecedor.Focus();
                    return;
                }
                if (cd_endfornecedor.Text.Trim().Equals(string.Empty))
                {
                    MessageBox.Show("Obrigatorio informar endereço fornecedor.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cd_endfornecedor.Focus();
                    return;
                }
                if (dt_enviolote.Text.Trim().Equals(string.Empty) || dt_enviolote.Text.Trim().Equals("/  /"))
                {
                    MessageBox.Show("Obrigatorio informar data envio do lote.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dt_enviolote.Focus();
                    return;
                }
                try
                {
                    CamadaNegocio.Servicos.TCN_LoteOS.GravarLoteOS(bsLote.Current as CamadaDados.Servicos.TRegistro_LoteOS, null);
                    MessageBox.Show("Lote gravado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    vModo = Utils.TTpModo.tm_Standby;
                    this.afterBusca();
                    this.HabilitarCampos(false);
                    this.HabilitarPages();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro gravar lote: " + ex.Message);
                }
            }
        }

        private void afterAltera()
        {
            if (vModo.Equals(Utils.TTpModo.tm_Standby))
                if (bsLote.Current != null)
                {
                    if ((bsLote.Current as CamadaDados.Servicos.TRegistro_LoteOS).St_registro.Trim().ToUpper().Equals("A"))
                    {
                        vModo = Utils.TTpModo.tm_Edit;
                        this.HabilitarCampos(true);
                        this.HabilitarPages();
                        ds_lote.Focus();
                    }
                    else
                        MessageBox.Show("Não é permitido alterar lote processado.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
        }

        private void afterBusca()
        {
            if (vModo.Equals(Utils.TTpModo.tm_Standby))
            {
                string st_reg = string.Empty;
                string virg = string.Empty;
                if (cbAtivo.Checked)
                {
                    st_reg = virg + "'A'";
                    virg = ",";
                }
                if (cbProcessado.Checked)
                {
                    st_reg = virg + "'P'";
                    virg = ",";
                }
                bsLote.DataSource = CamadaNegocio.Servicos.TCN_LoteOS.Buscar(id_lotebusca.Text,
                                                                             cd_fornecedorbusca.Text,
                                                                             cd_endfornecedorbusca.Text,
                                                                             ds_lotebusca.Text,
                                                                             string.Empty,
                                                                             st_reg,
                                                                             cd_cliforos.Text,
                                                                             cd_produtoos.Text,
                                                                             nr_nfremessa.Text,
                                                                             nr_nfretorno.Text,
                                                                             0,
                                                                             string.Empty,
                                                                             null);
                bsLote_PositionChanged(this, new EventArgs());
            }
        }

        private void afterExclui()
        {
            if (vModo.Equals(Utils.TTpModo.tm_Standby))
            {
                if (bsLote.Current != null)
                {
                    if ((bsLote.Current as CamadaDados.Servicos.TRegistro_LoteOS).St_registro.Trim().ToUpper().Equals("C"))
                    {
                        MessageBox.Show("Lote ja se encontra cancelado.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    if (MessageBox.Show("Confirma exclusão do registro?", "Confirma", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                        == DialogResult.Yes)
                    {
                        try
                        {
                            CamadaNegocio.Servicos.TCN_LoteOS.DeletarLoteOS(bsLote.Current as CamadaDados.Servicos.TRegistro_LoteOS, null);
                            this.afterBusca();
                            MessageBox.Show("Lote excluido com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                }
            }
        }

        private void afterCancela()
        {
            if (vModo.Equals(Utils.TTpModo.tm_Insert) || vModo.Equals(Utils.TTpModo.tm_Edit))
            {
                if (vModo.Equals(Utils.TTpModo.tm_Insert))
                    bsLote.RemoveCurrent();
                vModo = Utils.TTpModo.tm_Standby;
                this.HabilitarCampos(false);
                this.HabilitarPages();
            }
        }

        private void afterPrint()
        {
            if (bsLote.Count > 0)
            {
                (bsLote.DataSource as CamadaDados.Servicos.TList_LoteOS).ForEach(p =>
                        p.lOs = CamadaNegocio.Servicos.TCN_Lote_X_Servicos.BuscarOsLote(p.Id_lotestr,
                                                                                0,
                                                                                string.Empty,
                                                                                null));
                using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
                {
                    FormRelPadrao.Relatorio Rel = new FormRelPadrao.Relatorio();
                    Rel.Altera_Relatorio = Altera_Relatorio;
                    Rel.DTS_Relatorio = bsLote;
                    Rel.Nome_Relatorio = "TFLoteOsFornecedor";
                    Rel.NM_Classe = this.Name;
                    Rel.Modulo = string.Empty;
                    Rel.Ident = "TFLoteOsFornecedor";
                    fImp.St_enabled_enviaremail = true;
                    fImp.pCd_clifor = string.Empty;
                    fImp.pMensagem = "RELATORIO LOTE OS FORNECEDOR";

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
                                           "RELATORIO LOTE OS FORNECEDOR",
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
                                               fImp.pDestinatarios,
                                               null,
                                               "RELATORIO LOTE OS FORNECEDOR",
                                               fImp.pDs_mensagem);
                }
            }
            else
                MessageBox.Show("Não existe Registros Para Imprimir o Relatório!");
        }

        private void LocalizarOs()
        {
            if (this.vModo.Equals(Utils.TTpModo.tm_Insert) || this.vModo.Equals(Utils.TTpModo.tm_Edit))
            {
                if (bsLote.Current != null)
                    using (FLocalizarOsLote fLocalizar = new FLocalizarOsLote())
                    {
                        fLocalizar.Cd_empresa = cd_empresa.Text;
                        fLocalizar.Nm_empresa = nm_empresa.Text;
                        if (fLocalizar.ShowDialog() == DialogResult.OK)
                        {
                            fLocalizar.lOs.ForEach(p =>
                            {
                                //Verificar se a os ja existe na lista
                                if (!(bsLote.Current as CamadaDados.Servicos.TRegistro_LoteOS).lOs.Exists(v => v.Cd_empresa.Trim().Equals(p.Cd_empresa.Trim())
                                    && v.Id_os.Equals(p.Id_os)))
                                    (bsLote.Current as CamadaDados.Servicos.TRegistro_LoteOS).lOs.Add(p);
                            });
                            bsLote.ResetCurrentItem();
                        }
                    }
                else
                    MessageBox.Show("Não existe lote para amarrar ordem serviço.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Só é permitido inserir ordem serviço \r\n" +
                                "na inclusão de um novo lote ou na alteração de um lote existente.",
                                "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ExcluirOs()
        {
            if (this.vModo.Equals(Utils.TTpModo.tm_Insert) || this.vModo.Equals(Utils.TTpModo.tm_Edit))
            {
                if (bsLote.Current != null)
                {
                    if (!(bsLote.Current as CamadaDados.Servicos.TRegistro_LoteOS).St_registro.Trim().ToUpper().Equals("A"))
                    {
                        MessageBox.Show("Não é permitido excluir ordem serviço de um lote com status diferente de <ABERTO>.",
                                        "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    if (bsOs.Current == null)
                    {
                        MessageBox.Show("Obrigatorio selecionar ordem serviço para excluir.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    if (MessageBox.Show("Ordem Serviço selecionada: " + (bsOs.Current as CamadaDados.Servicos.TRegistro_LanServico).Id_os.ToString().Trim() +
                                        "\r\n\r\nConfirma exclusão?", "Pergunta", MessageBoxButtons.YesNo,
                                        MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    {
                        //Adicionar item na lista a ser excluido
                        (bsLote.Current as CamadaDados.Servicos.TRegistro_LoteOS).lOsDel.Add(
                            bsOs.Current as CamadaDados.Servicos.TRegistro_LanServico);
                        //Excluir item do grid
                        (bsLote.Current as CamadaDados.Servicos.TRegistro_LoteOS).lOs.Remove(
                            bsOs.Current as CamadaDados.Servicos.TRegistro_LanServico);
                        bsLote.ResetCurrentItem();
                    }
                }
                else
                    MessageBox.Show("Não existe ordem serviço selecionada.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Só é permitido excluir ordem serviço \r\n" +
                                "na inclusão de um novo lote ou na alteração de um lote existente.",
                                "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ProcessarLote()
        {
            if (vModo.Equals(Utils.TTpModo.tm_Standby))
            {
                if (bsLote.Current != null)
                    if ((bsLote.Current as CamadaDados.Servicos.TRegistro_LoteOS).St_registro.Trim().ToUpper().Equals("A"))
                    {
                        if ((bsLote.Current as CamadaDados.Servicos.TRegistro_LoteOS).lOs.Count.Equals(0))
                        {
                            MessageBox.Show("Não é permitido processar lote sem ordem de serviço.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        using (TFLanProcessarLote fProcessar = new TFLanProcessarLote())
                        {
                            fProcessar.Id_lote = (bsLote.Current as CamadaDados.Servicos.TRegistro_LoteOS).Id_lotestr;
                            fProcessar.Ds_lote = (bsLote.Current as CamadaDados.Servicos.TRegistro_LoteOS).Ds_lote;
                            if (fProcessar.ShowDialog() == DialogResult.OK)
                            {
                                (bsLote.Current as CamadaDados.Servicos.TRegistro_LoteOS).Dt_enviolote = fProcessar.Dt_enviolote;
                                (bsLote.Current as CamadaDados.Servicos.TRegistro_LoteOS).St_gerarpedidoremessa = fProcessar.St_gerarpedido;
                                if (fProcessar.St_gerarpedido)
                                {
                                    //Montar itens do pedido remessa
                                    (bsLote.Current as CamadaDados.Servicos.TRegistro_LoteOS).lOs.ForEach(p =>
                                        {
                                            if ((bsLote.Current as CamadaDados.Servicos.TRegistro_LoteOS).lItensPedido.Exists(v => v.Cd_produto.Trim().Equals(p.CD_ProdutoOS.Trim())))
                                            {
                                                CamadaDados.Faturamento.Pedido.TRegistro_LanPedido_Item rPed = (bsLote.Current as CamadaDados.Servicos.TRegistro_LoteOS).lItensPedido.Find(v => v.Cd_produto.Trim().Equals(p.CD_ProdutoOS.Trim()));
                                                rPed.Quantidade++;
                                                rPed.Vl_subtotal = rPed.Quantidade * rPed.Vl_unitario;
                                            }
                                            else
                                            {
                                                decimal vl_unitario = decimal.Zero;
                                                //Buscar valor medio do estoque
                                                CamadaNegocio.Estoque.TCN_LanEstoque.VlMedioEstoque(p.Cd_empresa, p.CD_ProdutoOS, ref vl_unitario, null);
                                                //Buscar valor da ultima compra
                                                if (vl_unitario.Equals(decimal.Zero))
                                                {
                                                    CamadaDados.Faturamento.NotaFiscal.TListUltimasCompras lUltimaCompra =
                                                        new CamadaDados.Faturamento.NotaFiscal.TCD_LanFaturamento_Item().Select(
                                                                    new TpBusca[]
                                                                    {
                                                                        new TpBusca()
                                                                        {
                                                                            vNM_Campo = "a.tp_movimento",
                                                                            vOperador = "=",
                                                                            vVL_Busca = "'E'"
                                                                        },
                                                                        new TpBusca()
                                                                        {
                                                                            vNM_Campo = "b.cd_produto",
                                                                            vOperador = "=",
                                                                            vVL_Busca = "'" + p.CD_ProdutoOS.Trim() + "'"
                                                                        },
                                                                        new TpBusca()
                                                                        {
                                                                            vNM_Campo = "ISNULL(e.ST_Complementar, 'N')",
                                                                            vOperador = "=",
                                                                            vVL_Busca = "'N'"
                                                                        },
                                                                        new TpBusca()
                                                                        {
                                                                            vNM_Campo = "ISNULL(e.ST_Devolucao, 'N')",
                                                                            vOperador = "=",
                                                                            vVL_Busca = "'N'"
                                                                        },
                                                                        new TpBusca()
                                                                        {
                                                                            vNM_Campo = "ISNULL(e.ST_GeraEstoque, 'N')",
                                                                            vOperador = "=",
                                                                            vVL_Busca = "'S'"
                                                                        },
                                                                        new TpBusca()
                                                                        {
                                                                            vNM_Campo = "ISNULL(a.ST_Registro, 'A')",
                                                                            vOperador = "<>",
                                                                            vVL_Busca = "'C'"
                                                                        },
                                                                    }, 1);
                                                    if (lUltimaCompra.Count > 0)
                                                        vl_unitario = lUltimaCompra[0].Vl_unitario;
                                                }
                                                
                                                (bsLote.Current as CamadaDados.Servicos.TRegistro_LoteOS).lItensPedido.Add(new CamadaDados.Faturamento.Pedido.TRegistro_LanPedido_Item()
                                                {
                                                    Cd_Empresa = p.Cd_empresa,
                                                    Cd_local = string.Empty,
                                                    Cd_produto = p.CD_ProdutoOS,
                                                    Ds_produto = p.DS_ProdutoOS,
                                                    Cd_unidade_est = p.Cd_unidOS,
                                                    Cd_unidade_valor = p.Cd_unidOS,
                                                    Quantidade = 1,
                                                    Vl_unitario = vl_unitario,
                                                    Vl_subtotal = vl_unitario
                                                });
                                            }
                                        });
                                    if((bsLote.Current as CamadaDados.Servicos.TRegistro_LoteOS).lItensPedido.Exists(p=> p.Vl_unitario.Equals(decimal.Zero)))
                                        using (TFLanItensNota fItens = new TFLanItensNota())
                                        {
                                            fItens.lItens = (bsLote.Current as CamadaDados.Servicos.TRegistro_LoteOS).lItensPedido;
                                            if (fItens.ShowDialog() != DialogResult.OK)
                                            {
                                                MessageBox.Show("Não é permitido processar lote com item do pedido com valor zero.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                return;
                                            }
                                        }
                                }
                                try
                                {
                                    CamadaNegocio.Servicos.TCN_LoteOS.ProcessarLoteOS(bsLote.Current as CamadaDados.Servicos.TRegistro_LoteOS, null);
                                    MessageBox.Show("Lote processado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    this.afterBusca();
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message.Trim());
                                }
                            }
                        }
                    }
                    else
                        MessageBox.Show("Lote ja se encontra processado.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void EstornarProcessamentoLote()
        {
            if (this.vModo.Equals(Utils.TTpModo.tm_Standby))
                if (bsLote.Current != null)
                {
                    if ((bsLote.Current as CamadaDados.Servicos.TRegistro_LoteOS).St_registro.Trim().ToUpper() != "P")
                    {
                        MessageBox.Show("Lote selecionado não se encontra processado.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    try
                    {
                        CamadaNegocio.Servicos.TCN_LoteOS.EstornarProcessamentoLoteOS(bsLote.Current as CamadaDados.Servicos.TRegistro_LoteOS, null);
                        MessageBox.Show("Processamento do lote estornado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.afterBusca();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.Trim());
                    }
                }
        }

        private void ProcessarRetornoLote()
        {
            using (TFDevolucaoOSFornec fDev = new TFDevolucaoOSFornec())
            {
                fDev.ShowDialog();
            }
        }

        private void TFLan_Lote_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, gOs);
            Utils.ShapeGrid.RestoreShape(this, gLote);
            Utils.ShapeGrid.RestoreShape(this, dataGridDefault3);
            if (!string.IsNullOrEmpty(Utils.Parametros.pubCultura))
                Idioma.TIdioma.AjustaCultura(this);
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pLote.set_FormatZero();
            pFiltro.set_FormatZero();
        }

        private void bb_fornecedor_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BUSCA(
                "a.nm_clifor|Nome Clifor|300;a.cd_clifor|Código Clifor|90;" +
                "tp_pessoa|Tipo Pessoa|80;" +
                "nr_cgc|C.N.P.J|80;" +
                "nr_cpf|C.P.F|80;" +
                "nr_rg|R.G|80;" +
                "nm_razaosocial|Razão Social|100;" +
                "nm_fantasia|Fantasia|100;" +
                "EMAILPF|E-Mail P.F|100;" +
                "EMAILPJ|E-Mail P.J|100"
              , new Componentes.EditDefault[] { cd_fornecedor, nm_fornecedor }, new TCD_CadClifor(), "isnull(a.st_fornecedor, 'N')|=|'S'");
        }

        private void cd_fornecedor_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("a.cd_clifor|=|'" + cd_fornecedor.Text.Trim() + "';isnull(a.st_fornecedor, 'N')|=|'S'"
                , new Componentes.EditDefault[] { cd_fornecedor, nm_fornecedor }, new TCD_CadClifor());
        }

        private void bb_endfornecedor_Click(object sender, EventArgs e)
        {
            string vColunas = "a.DS_Endereco|Endereço|200;" +
                              "a.cd_endereco|Cd. Endereço|80";
            string vParam = "a.cd_clifor|=|'" + cd_fornecedor.Text.Trim() + "'";
            UtilPesquisa.BTN_BUSCA(vColunas, new EditDefault[] { cd_endfornecedor, ds_endfornecedor }, new TCD_CadEndereco(), vParam);
        }

        private void cd_endfornecedor_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_endereco|=|'" + cd_endfornecedor.Text.Trim() + "';" +
                            "a.cd_clifor|=|'" + cd_fornecedor.Text.Trim() + "'";
            UtilPesquisa.EDIT_LEAVE(vParam, new EditDefault[] { cd_endfornecedor, ds_endfornecedor }, new TCD_CadEndereco());
        }

        private void BB_Novo_Click(object sender, EventArgs e)
        {
            this.afterNovo();
        }

        private void BB_Alterar_Click(object sender, EventArgs e)
        {
            this.afterAltera();
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            this.afterGrava();
        }

        private void BB_Excluir_Click(object sender, EventArgs e)
        {
            this.afterExclui();
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            this.afterCancela();
        }

        private void BB_Buscar_Click(object sender, EventArgs e)
        {
            this.afterBusca();
        }

        private void TFLan_Lote_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F2))
                this.afterNovo();
            else if (e.KeyCode.Equals(Keys.F3))
                this.afterAltera();
            else if (e.KeyCode.Equals(Keys.F4))
                this.afterGrava();
            else if (e.KeyCode.Equals(Keys.F5))
                this.afterExclui();
            else if (e.KeyCode.Equals(Keys.F6))
                this.afterCancela();
            else if (e.KeyCode.Equals(Keys.F7))
                this.afterBusca();
            else if (e.KeyCode.Equals(Keys.F9))
                this.ProcessarLote();
            else if (e.KeyCode.Equals(Keys.F10))
                this.EstornarProcessamentoLote();
            else if (e.KeyCode.Equals(Keys.F11))
                this.ProcessarRetornoLote();
            else if (e.Control && e.KeyCode.Equals(Keys.F11) && btn_Inserir_Item.Enabled)
                this.LocalizarOs();
            else if (e.Control && e.KeyCode.Equals(Keys.F12) && btn_Deleta_Item.Enabled)
                this.ExcluirOs();
            else if (e.Control && e.KeyCode.Equals(Keys.P))
            {
                this.Altera_Relatorio = true;
                MessageBox.Show("Selecione o relatorio para alterar.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BB_Fechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bb_fornecedorbusca_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { cd_fornecedorbusca }, "isnull(a.st_fornecedor, 'N')|=|'S'");
        }

        private void cd_fornecedorbusca_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("a.cd_clifor|=|'" + cd_fornecedorbusca.Text.Trim() + "';isnull(a.st_fornecedor, 'N')|=|'S'"
                , new Componentes.EditDefault[] { cd_fornecedorbusca }, new TCD_CadClifor());
        }

        private void bb_endfornecedorbusca_Click(object sender, EventArgs e)
        {
            string vColunas = "a.DS_Endereco|Endereço|200;" +
                              "a.cd_endereco|Cd. Endereço|80";
            string vParam = "a.cd_clifor|=|'" + cd_fornecedorbusca.Text.Trim() + "'";
            UtilPesquisa.BTN_BUSCA(vColunas, new EditDefault[] { cd_endfornecedorbusca }, new TCD_CadEndereco(), vParam);
        }

        private void cd_endfornecedorbusca_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_endereco|=|'" + cd_endfornecedorbusca.Text.Trim() + "';" +
                            "a.cd_clifor|=|'" + cd_fornecedorbusca.Text.Trim() + "'";
            UtilPesquisa.EDIT_LEAVE(vParam, new EditDefault[] { cd_endfornecedorbusca }, new TCD_CadEndereco());
        }

        private void BB_ProcessarLote_Click(object sender, EventArgs e)
        {
            this.ProcessarLote();
        }

        private void bb_empresa_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BUSCA("a.NM_empresa|Nome Empresa|300;a.CD_Empresa|Cód Empresa|100"
                          , new Componentes.EditDefault[] { cd_empresa, nm_empresa }
                          , new CamadaDados.Diversos.TCD_CadEmpresa(),
                          "|EXISTS|(select 1 from Tb_div_usuario_X_empresa  x where x.cd_empresa = A.cd_empresa " +
                          "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                          "(exists(select 1 from tb_div_usuario_x_grupos y " +
                          "         where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))");
        }

        private void cd_empresa_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("a.cd_empresa|=|'" + cd_empresa.Text.Trim() + "';" +
                                  "|EXISTS|(select 1 from Tb_div_usuario_X_empresa  x where x.cd_empresa = A.cd_empresa " +
                                  "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                                  "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                  "         where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))"
              , new Componentes.EditDefault[] { cd_empresa, nm_empresa }, new CamadaDados.Diversos.TCD_CadEmpresa());
        }

        private void gLote_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null)
                if (e.ColumnIndex == 0)
                {
                    if (e.Value.ToString().Trim().ToUpper().Equals("PROCESSADO"))
                    {
                        DataGridViewRow linha = gLote.Rows[e.RowIndex];
                        linha.DefaultCellStyle.ForeColor = Color.Blue;
                    }
                    else if (e.Value.ToString().Trim().ToUpper().Equals("CANCELADO"))
                    {
                        DataGridViewRow linha = gLote.Rows[e.RowIndex];
                        linha.DefaultCellStyle.ForeColor = Color.Red;
                    }
                    else
                    {
                        DataGridViewRow linha = gLote.Rows[e.RowIndex];
                        linha.DefaultCellStyle.ForeColor = Color.Black;
                    }
                }
        }

        private void btn_Inserir_Item_Click(object sender, EventArgs e)
        {
            this.LocalizarOs();
        }

        private void btn_Deleta_Item_Click(object sender, EventArgs e)
        {
            this.ExcluirOs();
        }

        private void bb_cliforos_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BUSCA(
                "a.nm_clifor|Nome Clifor|300;a.cd_clifor|Código Clifor|90;" +
                "tp_pessoa|Tipo Pessoa|80;" +
                "nr_cgc|C.N.P.J|80;" +
                "nr_cpf|C.P.F|80;" +
                "nr_rg|R.G|80;" +
                "nm_razaosocial|Razão Social|100;" +
                "nm_fantasia|Fantasia|100;" +
                "EMAILPF|E-Mail P.F|100;" +
                "EMAILPJ|E-Mail P.J|100"
              , new Componentes.EditDefault[] { cd_cliforos }, new TCD_CadClifor(), string.Empty);
        }

        private void cd_cliforos_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("a.cd_clifor|=|'" + cd_cliforos.Text.Trim() + "'"
                , new Componentes.EditDefault[] { cd_cliforos }, new TCD_CadClifor());
        }

        private void bb_produtoos_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BUSCA("a.DS_Produto|Produto|300;a.cd_Produto|Código Produto|90"
                          , new Componentes.EditDefault[] { cd_produtoos }, new CamadaDados.Estoque.Cadastros.TCD_CadProduto(), string.Empty);
        }

        private void cd_produtoos_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("a.cd_produto|=|'" + cd_produtoos.Text + "'"
               , new Componentes.EditDefault[] { cd_produtoos }, new CamadaDados.Estoque.Cadastros.TCD_CadProduto());
        }

        private void bsLote_PositionChanged(object sender, EventArgs e)
        {
            if(bsLote.Current != null)
                if ((bsLote.Current as CamadaDados.Servicos.TRegistro_LoteOS).Id_lotestr != string.Empty)
                {
                    //Buscar OS do lote
                    (bsLote.Current as CamadaDados.Servicos.TRegistro_LoteOS).lOs =
                        CamadaNegocio.Servicos.TCN_Lote_X_Servicos.BuscarOsLote((bsLote.Current as CamadaDados.Servicos.TRegistro_LoteOS).Id_lotestr,
                                                                                0,
                                                                                string.Empty,
                                                                                null);
                    if((bsLote.Current as CamadaDados.Servicos.TRegistro_LoteOS).Nr_pedido != null)
                        //Buscar Nfs do lote
                        (bsLote.Current as CamadaDados.Servicos.TRegistro_LoteOS).lNf =
                            new CamadaDados.Faturamento.NotaFiscal.TCD_LanFaturamento().Select(
                            new Utils.TpBusca[]
                            {
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = string.Empty,
                                    vOperador = "exists",
                                    vVL_Busca = "(select 1 from tb_fat_notafiscal_item x "+
                                                "where x.cd_empresa = a.cd_empresa "+
                                                "and x.nr_lanctofiscal = a.nr_lanctofiscal "+
                                                "and x.nr_pedido = "+(bsLote.Current as CamadaDados.Servicos.TRegistro_LoteOS).Nr_pedido.Value.ToString()+")"
                                }
                            }, 0, string.Empty);
                    bsLote.ResetCurrentItem();
                }
        }

        private void BB_EstornarEnvio_Click(object sender, EventArgs e)
        {
            this.EstornarProcessamentoLote();
        }

        private void BB_ProcessarRetorno_Click(object sender, EventArgs e)
        {
            this.ProcessarRetornoLote();
        }

        private void BB_Imprimir_Click(object sender, EventArgs e)
        {
            this.afterPrint();
        }

        private void TFLan_Lote_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, gOs);
            Utils.ShapeGrid.SaveShape(this, gLote);
            Utils.ShapeGrid.SaveShape(this, dataGridDefault3);
        }
    }
}
