using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FormBusca;

namespace Faturamento.Cadastros
{
    public partial class TFCadCFGOrcamento : FormCadPadrao.FFormCadPadrao
    {
        private string nameTempJaquetado = string.Empty;
        private string nameTempJaquetadoRes = string.Empty;
        private string nameTempAereo = string.Empty;
        private string nameTempPerifericos = string.Empty;
        private string nameTempFlex = string.Empty;
        private string nameTempAgua = string.Empty;
        private string nameTempVertical = string.Empty;
        public TFCadCFGOrcamento()
        {
            InitializeComponent();
        }

        public override void habilitarControls(bool value)
        {
            pDados.HabilitarControls(value, this.vTP_Modo);
        }

        public override string gravarRegistro()
        {
            if (!string.IsNullOrEmpty(nameTempJaquetado))
            {
                if (ArquivoEmUso(nameTempJaquetado))
                {
                    MessageBox.Show("Arquivo Layout Jaquetado em uso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return string.Empty;
                }
                else
                {
                    (bsCfgOrcamento.Current as CamadaDados.Faturamento.Cadastros.TRegistro_CFGOrcamento).LayoutJaquetado =
                    System.IO.File.ReadAllBytes(nameTempJaquetado);
                }
            }
            if (!string.IsNullOrEmpty(nameTempJaquetadoRes))
            {
                if (ArquivoEmUso(nameTempJaquetadoRes))
                {
                    MessageBox.Show("Arquivo Layout Jaquetado Resumido em uso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return string.Empty;
                }
                else
                {
                    (bsCfgOrcamento.Current as CamadaDados.Faturamento.Cadastros.TRegistro_CFGOrcamento).LayoutJaquetadoRes =
                    System.IO.File.ReadAllBytes(nameTempJaquetadoRes);
                }
            }
            if (!string.IsNullOrEmpty(nameTempAereo))
            {
                if (ArquivoEmUso(nameTempAereo))
                {
                    MessageBox.Show("Arquivo Layout Aéreo em uso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return string.Empty;
                }
                else
                {
                    (bsCfgOrcamento.Current as CamadaDados.Faturamento.Cadastros.TRegistro_CFGOrcamento).LayoutAereo =
                    System.IO.File.ReadAllBytes(nameTempAereo);
                }
            }
            if (!string.IsNullOrEmpty(nameTempPerifericos))
            {
                if (ArquivoEmUso(nameTempPerifericos))
                {
                    MessageBox.Show("Arquivo Layout Periféricos em uso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return string.Empty;
                }
                else
                {
                    (bsCfgOrcamento.Current as CamadaDados.Faturamento.Cadastros.TRegistro_CFGOrcamento).LayoutPerifericos =
                    System.IO.File.ReadAllBytes(nameTempPerifericos);
                }
            }
            if (!string.IsNullOrEmpty(nameTempFlex))
            {
                if (ArquivoEmUso(nameTempFlex))
                {
                    MessageBox.Show("Arquivo Layout Flex em uso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return string.Empty;
                }
                else
                {
                    (bsCfgOrcamento.Current as CamadaDados.Faturamento.Cadastros.TRegistro_CFGOrcamento).LayoutFlex =
                    System.IO.File.ReadAllBytes(nameTempFlex);
                }
            }
            if (!string.IsNullOrEmpty(nameTempAgua))
            {
                if (ArquivoEmUso(nameTempAgua))
                {
                    MessageBox.Show("Arquivo Layout Água em uso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return string.Empty;
                }
                else
                {
                    (bsCfgOrcamento.Current as CamadaDados.Faturamento.Cadastros.TRegistro_CFGOrcamento).LayoutAgua =
                    System.IO.File.ReadAllBytes(nameTempAgua);
                }
            }
            if (!string.IsNullOrEmpty(nameTempVertical))
            {
                if (ArquivoEmUso(nameTempVertical))
                {
                    MessageBox.Show("Arquivo Layout Vertical em uso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return string.Empty;
                }
                else
                {
                    (bsCfgOrcamento.Current as CamadaDados.Faturamento.Cadastros.TRegistro_CFGOrcamento).LayoutVertical =
                    System.IO.File.ReadAllBytes(nameTempVertical);
                }
            }
            if (pDados.validarCampoObrigatorio())
            {
                nameTempJaquetado = string.Empty;
                nameTempJaquetadoRes = string.Empty;
                nameTempAereo = string.Empty;
                nameTempPerifericos = string.Empty;
                nameTempFlex = string.Empty;
                nameTempAgua = string.Empty;
                nameTempVertical = string.Empty;
                if (qt_diasdesdobro.Focused)
                    (bsCfgOrcamento.Current as CamadaDados.Faturamento.Cadastros.TRegistro_CFGOrcamento).Qt_diasvalidade = qt_diasdesdobro.Value;
                return CamadaNegocio.Faturamento.Cadastros.TCN_CFGOrcamento.Gravar(
                    bsCfgOrcamento.Current as CamadaDados.Faturamento.Cadastros.TRegistro_CFGOrcamento, null);
            }
            else
                return string.Empty;
        }

        public override int buscarRegistros()
        {
            CamadaDados.Faturamento.Cadastros.TList_CFGOrcamento lista =
                CamadaNegocio.Faturamento.Cadastros.TCN_CFGOrcamento.Buscar(cd_empresa.Text,
                                                                            cfg_pedido.Text,
                                                                            cd_local.Text,
                                                                            null);

            if (lista != null)
            {
                if (lista.Count > 0)
                {
                    this.Lista = lista;
                    bsCfgOrcamento.DataSource = lista;
                }
                else
                    if ((vTP_Modo == Utils.TTpModo.tm_Standby) || (vTP_Modo == Utils.TTpModo.tm_busca))
                        bsCfgOrcamento.Clear();
                return lista.Count;
            }
            else
                return 0;
        }

        public override void afterNovo()
        {
            if ((vTP_Modo == Utils.TTpModo.tm_busca) || (vTP_Modo == Utils.TTpModo.tm_Standby))
            {
                bsCfgOrcamento.AddNew();
                base.afterNovo();
                cd_empresa.Focus();
            }
        }

        public override void afterCancela()
        {
            nameTempJaquetado = string.Empty;
            nameTempJaquetadoRes = string.Empty;
            nameTempAereo = string.Empty;
            nameTempPerifericos = string.Empty;
            nameTempFlex = string.Empty;
            nameTempAgua = string.Empty;
            nameTempVertical = string.Empty;
            base.afterCancela();
            if (vTP_Modo == Utils.TTpModo.tm_Insert)
                bsCfgOrcamento.RemoveCurrent();
        }

        public override void afterAltera()
        {
            base.afterAltera();
            bb_empresa.Enabled = false;
            if (vTP_Modo == Utils.TTpModo.tm_Edit)
                cfg_pedido.Focus();
        }

        public override void excluirRegistro()
        {
            if ((this.vTP_Modo == Utils.TTpModo.tm_Standby) || (this.vTP_Modo == Utils.TTpModo.tm_busca))
            {
                if (MessageBox.Show("Confirma Exclusão do Registro?", "Mensagem",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) ==
                System.Windows.Forms.DialogResult.Yes)
                {
                    CamadaNegocio.Faturamento.Cadastros.TCN_CFGOrcamento.Excluir(
                        bsCfgOrcamento.Current as CamadaDados.Faturamento.Cadastros.TRegistro_CFGOrcamento, null);
                    bsCfgOrcamento.RemoveCurrent();
                    pDados.LimparRegistro();
                    afterBusca();
                }
            }
        }

        public bool ArquivoEmUso(string caminhoArquivo)
        {
            try
            {
                System.IO.FileStream fs = System.IO.File.OpenWrite(caminhoArquivo);
                fs.Close();
                return false;
            }
            catch (System.IO.IOException ex)
            {
                return true;
            }
        }

        private void bb_empresa_Click(object sender, EventArgs e)
        {
            string vParam = "|EXISTS|(select 1 from tb_div_usuario_x_empresa x " +
                            "where x.cd_empresa = a.cd_empresa " +
                            "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                            "(exists(select 1 from tb_div_usuario_x_grupos y " +
                            "       where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))";
            if (!string.IsNullOrEmpty(cd_local.Text))
                vParam += ";|exists|(select 1 from TB_EST_Empresa_X_LocalArm x " +
                         "          where x.cd_empresa = a.cd_empresa " +
                         "          and x.cd_local = '" + cd_local.Text.Trim() + "')";
            UtilPesquisa.BTN_BUSCA("a.NM_empresa|Nome Empresa|300;a.CD_Empresa|Cd.Empresa|80;UF|UF|80"
                , new Componentes.EditDefault[] { cd_empresa, nm_empresa }, new CamadaDados.Diversos.TCD_CadEmpresa(), vParam);
        }

        private void cd_empresa_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.cd_empresa|=|'" + cd_empresa.Text.Trim() + "';" +
                              "|EXISTS|(select 1 from tb_div_usuario_x_empresa x " +
                              "where x.cd_empresa = a.cd_empresa " +
                              "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                              "(exists(select 1 from tb_div_usuario_x_grupos y " +
                              "         where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))";
            if (!string.IsNullOrEmpty(cd_local.Text))
                vColunas += ";|exists|(select 1 from TB_EST_Empresa_X_LocalArm x " +
                            "          where x.cd_empresa = a.cd_empresa " +
                            "          and x.cd_local = '" + cd_local.Text.Trim() + "')";
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { cd_empresa, nm_empresa }, new CamadaDados.Diversos.TCD_CadEmpresa());
        }

        private void bb_cfgpedido_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_tipopedido|Tipo Pedido|200;" +
                              "a.cfg_pedido|TP. Pedido|80";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cfg_pedido, ds_tipopedido },
                                    new CamadaDados.Faturamento.Cadastros.TCD_CadCFGPedido(), "a.tp_movimento|=|'S';isnull(a.st_servico, 'N')|<>|'S'");
        }

        private void cfg_pedido_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.cfg_pedido|=|'" + cfg_pedido.Text.Trim() + "';" +
                              "a.tp_movimento|=|'S';" +
                              "isnull(a.st_servico, 'N')|<>|'S'";
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { cfg_pedido, ds_tipopedido },
                                    new CamadaDados.Faturamento.Cadastros.TCD_CadCFGPedido());
        }

        private void bb_local_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_local|Local Armazenagem|200;" +
                              "a.cd_local|Cd. Local|80";
            string vParam = "|exists|(select 1 from tb_est_empresa_x_localarm x " +
                            "           where x.cd_local = a.cd_local " +
                            "           and x.cd_empresa = '" + cd_empresa.Text.Trim() + "');" +
                            "isnull(a.st_registro, 'A')|<>|'C'";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_local, ds_local },
                                    new CamadaDados.Estoque.Cadastros.TCD_CadLocalArm(), vParam);
        }

        private void cd_local_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_local|=|'" + cd_local.Text.Trim() + "';" +
                            "|exists|(select 1 from tb_est_empresa_x_localarm x " +
                            "           where x.cd_local = a.cd_local " +
                            "           and x.cd_empresa = '" + cd_empresa.Text.Trim() + "');" +
                            "isnull(a.st_registro, 'A')|<>|'C'";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_local, ds_local },
                                    new CamadaDados.Estoque.Cadastros.TCD_CadLocalArm());
        }

        private void TFCadCFGOrcamento_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, dataGridDefault1);
            pDados.set_FormatZero();
        }

        private void TFCadCFGOrcamento_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, dataGridDefault1);
        }

        private void bb_tpordem_Click(object sender, EventArgs e)
        {
            string vParam = "a.ds_tipoordem|Tipo Ordem|200;" +
                            "a.tp_ordem|Codigo|80";
            UtilPesquisa.BTN_BUSCA(vParam, new Componentes.EditDefault[] { tp_ordem, ds_tipoordem },
                new CamadaDados.Servicos.Cadastros.TCD_TpOrdem(), "||(a.tp_os = 'S') or (a.tp_os = 'I')");
        }

        private void tp_ordem_Leave(object sender, EventArgs e)
        {
            string vParam = "a.tp_ordem|=|" + tp_ordem.Text + ";" +
                            "||(a.tp_os = 'S') or (a.tp_os = 'I')";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { tp_ordem, ds_tipoordem },
                new CamadaDados.Servicos.Cadastros.TCD_TpOrdem());
        }

        private void bb_cfgpedservico_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_tipopedido|Tipo Pedido|200;" +
                              "a.cfg_pedido|TP. Pedido|80";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cfg_pedservico, ds_tipopedservico },
                                    new CamadaDados.Faturamento.Cadastros.TCD_CadCFGPedido(), "a.tp_movimento|=|'S';isnull(a.st_servico, 'N')|=|'S'");
        }

        private void cfg_pedservico_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.cfg_pedido|=|'" + cfg_pedservico.Text.Trim() + "';" +
                              "a.tp_movimento|=|'S';" +
                              "isnull(a.st_servico, 'N')|=|'S'";
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { cfg_pedservico, ds_tipopedservico },
                                    new CamadaDados.Faturamento.Cadastros.TCD_CadCFGPedido());
        }

        private void Cfg_PedOrdemProd_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.cfg_pedido|=|'" + cfg_pedservico.Text.Trim() + "';" +
                             "a.tp_movimento|=|'S';" +
                             "isnull(a.ST_GerarOP, 'N')|=|'S'";
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { Cfg_PedOrdemProd, ds_tipoOrdemProd },
                                    new CamadaDados.Faturamento.Cadastros.TCD_CadCFGPedido());
        }

        private void bb_cfg_PedOrdemProd_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_tipopedido|Tipo Pedido|200;" +
                              "a.cfg_pedido|TP. Pedido|80";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { Cfg_PedOrdemProd, ds_tipoOrdemProd },
                                    new CamadaDados.Faturamento.Cadastros.TCD_CadCFGPedido(), "a.tp_movimento|=|'S';isnull(a.ST_GerarOP, 'N')|=|'S'");
        }

        private void bb_loadJaquetado_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
                if (System.IO.File.Exists(ofd.FileName))
                {
                    (bsCfgOrcamento.Current as CamadaDados.Faturamento.Cadastros.TRegistro_CFGOrcamento).LayoutJaquetado =
                        System.IO.File.ReadAllBytes(ofd.FileName);
                }
        }

        private void bb_visualizarJaquetado_Click(object sender, EventArgs e)
        {
            if ((bsCfgOrcamento.Current as CamadaDados.Faturamento.Cadastros.TRegistro_CFGOrcamento).LayoutJaquetado != null)
            {
                byte[] arquivoBuffer = (bsCfgOrcamento.Current as CamadaDados.Faturamento.Cadastros.TRegistro_CFGOrcamento).LayoutJaquetado;
                string extensao = ".docx"; // retornar do banco tbm
                nameTempJaquetado = System.IO.Path.ChangeExtension(System.IO.Path.GetTempFileName(), extensao);

                System.IO.File.WriteAllBytes(
                    nameTempJaquetado,
                    arquivoBuffer);

                // para abrir o arquivo para o usuario
                System.Diagnostics.Process.Start(nameTempJaquetado);
            }
        }

        private void bb_loadAereo_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
                if (System.IO.File.Exists(ofd.FileName))
                {
                    (bsCfgOrcamento.Current as CamadaDados.Faturamento.Cadastros.TRegistro_CFGOrcamento).LayoutAereo =
                        System.IO.File.ReadAllBytes(ofd.FileName);
                }
        }

        private void bb_visualizarAereo_Click(object sender, EventArgs e)
        {
            if ((bsCfgOrcamento.Current as CamadaDados.Faturamento.Cadastros.TRegistro_CFGOrcamento).LayoutAereo != null)
            {
                byte[] arquivoBuffer = (bsCfgOrcamento.Current as CamadaDados.Faturamento.Cadastros.TRegistro_CFGOrcamento).LayoutAereo;
                string extensao = ".docx"; // retornar do banco tbm
                nameTempAereo = System.IO.Path.ChangeExtension(System.IO.Path.GetTempFileName(), extensao);

                System.IO.File.WriteAllBytes(
                    nameTempAereo,
                    arquivoBuffer);

                // para abrir o arquivo para o usuario
                System.Diagnostics.Process.Start(nameTempAereo);
            }
        }

        private void bb_loadPerificos_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
                if (System.IO.File.Exists(ofd.FileName))
                {
                    (bsCfgOrcamento.Current as CamadaDados.Faturamento.Cadastros.TRegistro_CFGOrcamento).LayoutPerifericos =
                        System.IO.File.ReadAllBytes(ofd.FileName);
                }
        }

        private void bb_visualizarPerifericos_Click(object sender, EventArgs e)
        {
            if ((bsCfgOrcamento.Current as CamadaDados.Faturamento.Cadastros.TRegistro_CFGOrcamento).LayoutPerifericos != null)
            {
                byte[] arquivoBuffer = (bsCfgOrcamento.Current as CamadaDados.Faturamento.Cadastros.TRegistro_CFGOrcamento).LayoutPerifericos;
                string extensao = ".docx"; // retornar do banco tbm
                nameTempPerifericos = System.IO.Path.ChangeExtension(System.IO.Path.GetTempFileName(), extensao);

                System.IO.File.WriteAllBytes(
                    nameTempPerifericos,
                    arquivoBuffer);

                // para abrir o arquivo para o usuario
                System.Diagnostics.Process.Start(nameTempPerifericos);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
                if (System.IO.File.Exists(ofd.FileName))
                {
                    (bsCfgOrcamento.Current as CamadaDados.Faturamento.Cadastros.TRegistro_CFGOrcamento).LayoutFlex =
                        System.IO.File.ReadAllBytes(ofd.FileName);
                }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
                if (System.IO.File.Exists(ofd.FileName))
                {
                    (bsCfgOrcamento.Current as CamadaDados.Faturamento.Cadastros.TRegistro_CFGOrcamento).LayoutAgua =
                        System.IO.File.ReadAllBytes(ofd.FileName);
                }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
                if (System.IO.File.Exists(ofd.FileName))
                {
                    (bsCfgOrcamento.Current as CamadaDados.Faturamento.Cadastros.TRegistro_CFGOrcamento).LayoutVertical =
                        System.IO.File.ReadAllBytes(ofd.FileName);
                }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if ((bsCfgOrcamento.Current as CamadaDados.Faturamento.Cadastros.TRegistro_CFGOrcamento).LayoutFlex != null)
            {
                byte[] arquivoBuffer = (bsCfgOrcamento.Current as CamadaDados.Faturamento.Cadastros.TRegistro_CFGOrcamento).LayoutFlex;
                string extensao = ".docx"; // retornar do banco tbm
                nameTempFlex = System.IO.Path.ChangeExtension(System.IO.Path.GetTempFileName(), extensao);

                System.IO.File.WriteAllBytes(
                    nameTempFlex,
                    arquivoBuffer);

                // para abrir o arquivo para o usuario
                System.Diagnostics.Process.Start(nameTempFlex);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if ((bsCfgOrcamento.Current as CamadaDados.Faturamento.Cadastros.TRegistro_CFGOrcamento).LayoutAgua != null)
            {
                byte[] arquivoBuffer = (bsCfgOrcamento.Current as CamadaDados.Faturamento.Cadastros.TRegistro_CFGOrcamento).LayoutAgua;
                string extensao = ".docx"; // retornar do banco tbm
                nameTempAgua = System.IO.Path.ChangeExtension(System.IO.Path.GetTempFileName(), extensao);

                System.IO.File.WriteAllBytes(
                    nameTempAgua,
                    arquivoBuffer);

                // para abrir o arquivo para o usuario
                System.Diagnostics.Process.Start(nameTempAgua);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ((bsCfgOrcamento.Current as CamadaDados.Faturamento.Cadastros.TRegistro_CFGOrcamento).LayoutVertical != null)
            {
                byte[] arquivoBuffer = (bsCfgOrcamento.Current as CamadaDados.Faturamento.Cadastros.TRegistro_CFGOrcamento).LayoutVertical;
                string extensao = ".docx"; // retornar do banco tbm
                nameTempVertical = System.IO.Path.ChangeExtension(System.IO.Path.GetTempFileName(), extensao);

                System.IO.File.WriteAllBytes(
                    nameTempVertical,
                    arquivoBuffer);

                // para abrir o arquivo para o usuario
                System.Diagnostics.Process.Start(nameTempVertical);
            }
        }

        private void bb_loadJaquetadoRes_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
                if (System.IO.File.Exists(ofd.FileName))
                {
                    (bsCfgOrcamento.Current as CamadaDados.Faturamento.Cadastros.TRegistro_CFGOrcamento).LayoutJaquetadoRes =
                        System.IO.File.ReadAllBytes(ofd.FileName);
                }
        }

        private void bb_visualizarJaquetadoRes_Click(object sender, EventArgs e)
        {
            if ((bsCfgOrcamento.Current as CamadaDados.Faturamento.Cadastros.TRegistro_CFGOrcamento).LayoutJaquetadoRes != null)
            {
                byte[] arquivoBuffer = (bsCfgOrcamento.Current as CamadaDados.Faturamento.Cadastros.TRegistro_CFGOrcamento).LayoutJaquetadoRes;
                string extensao = ".docx"; // retornar do banco tbm
                nameTempJaquetadoRes = System.IO.Path.ChangeExtension(System.IO.Path.GetTempFileName(), extensao);

                System.IO.File.WriteAllBytes(
                    nameTempJaquetadoRes,
                    arquivoBuffer);

                // para abrir o arquivo para o usuario
                System.Diagnostics.Process.Start(nameTempJaquetadoRes);
            }
        }

        private void bbContager_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BUSCA("a.ds_contager|Conta Gerencial|150;a.cd_contager|Cd. Conta|60",
                new Componentes.EditDefault[] { cd_contager, ds_contager },
                new CamadaDados.Financeiro.Cadastros.TCD_CadContaGer(),
                "|exists|(select 1 from tb_fin_contager_x_empresa x where x.cd_contager = a.cd_contager and x.cd_empresa = '" + cd_empresa.Text.Trim() + "')");
        }

        private void cd_contager_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("a.cd_contager|=|'" + cd_contager.Text.Trim() + "';|exists|(select 1 from tb_fin_contager_x_empresa x where x.cd_contager = a.cd_contager and x.cd_empresa = '" + cd_empresa.Text.Trim() + "')",
                new Componentes.EditDefault[] { cd_contager, ds_contager }, new CamadaDados.Financeiro.Cadastros.TCD_CadContaGer());
        }

        private void bbPortador_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BUSCA("a.ds_portador|Portador|80;a.cd_portador|Cd. Portador|60",
                new Componentes.EditDefault[] { cd_portador, ds_portador },
                new CamadaDados.Financeiro.Cadastros.TCD_CadPortador(), string.Empty);
        }

        private void cd_portador_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("a.cd_portador|=|'" + cd_portador.Text.Trim() + "'",
                new Componentes.EditDefault[] { cd_portador, ds_portador },
                new CamadaDados.Financeiro.Cadastros.TCD_CadPortador());
        }
    }
}
