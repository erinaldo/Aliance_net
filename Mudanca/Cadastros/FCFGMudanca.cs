using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CamadaDados.Mudanca.Cadastros;
using CamadaNegocio.Mudanca.Cadastros;
using CamadaDados.Faturamento.Cadastros;
using FormBusca;

namespace Mudanca.Cadastros
{
    public partial class TFCFGMudanca : FormCadPadrao.FFormCadPadrao
    {
        private string nameTempMun = string.Empty;
        private string nameTempInterMun = string.Empty;
        public TFCFGMudanca()
        {
            InitializeComponent();
        }

        public override string gravarRegistro()
        {
            if (!string.IsNullOrEmpty(nameTempMun))
            {
                if (ArquivoEmUso(nameTempMun))
                {
                    MessageBox.Show("Arquivo Mudança Municipal em uso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return string.Empty;
                }
                else
                {
                    (bsCFGMudanca.Current as TRegistro_CFGMudanca).ContratoMunicipal =
                    System.IO.File.ReadAllBytes(nameTempMun);
                }
            }
            if (!string.IsNullOrEmpty(nameTempInterMun))
            {
                if (ArquivoEmUso(nameTempInterMun))
                {
                    MessageBox.Show("Arquivo Mudança InterMunicipal em uso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return string.Empty;
                }
                else
                {
                    (bsCFGMudanca.Current as TRegistro_CFGMudanca).ContratoInterMunicipal =
                    System.IO.File.ReadAllBytes(nameTempInterMun);
                }
            }
            if (pDados.validarCampoObrigatorio())
            {
                nameTempMun = string.Empty;
                nameTempInterMun = string.Empty;
                return TCN_CFGMudanca.Gravar(bsCFGMudanca.Current as TRegistro_CFGMudanca, null);
            }
            else
                return string.Empty;
        }

        public override int buscarRegistros()
        {
            TList_CFGMudanca lista = TCN_CFGMudanca.buscar(cd_empresa.Text,
                                                           tp_duplicata.Text,
                                                           tp_docto.Text,
                                                           Cd_PedidoServico.Text,
                                                           cd_servicopadrao.Text,
                                                           null);
            if (lista != null)
            {
                if (lista.Count > 0)
                {
                    this.Lista = lista;
                    bsCFGMudanca.DataSource = lista;
                }
                else
                    if ((vTP_Modo == Utils.TTpModo.tm_Standby) || (vTP_Modo == Utils.TTpModo.tm_busca))
                        bsCFGMudanca.Clear();
                return lista.Count;
            }
            else
                return 0;
        }

        public override void formatZero()
        {
            this.pDados.set_FormatZero();
        }

        public override void afterNovo()
        {
            if ((vTP_Modo == Utils.TTpModo.tm_Standby) || (vTP_Modo == Utils.TTpModo.tm_busca))
                bsCFGMudanca.AddNew();
            base.afterNovo();
            if (!cd_empresa.Focus())
                tp_duplicata.Focus();
        }

        public override void afterAltera()
        {
            base.afterAltera();
            tp_duplicata.Focus();
        }

        public override void habilitarControls(bool value)
        {
            pDados.HabilitarControls(value, this.vTP_Modo);
        }

        public override void afterCancela()
        {
            nameTempMun = string.Empty;
            nameTempInterMun = string.Empty;
            base.afterCancela();
            if (vTP_Modo == Utils.TTpModo.tm_Insert)
                bsCFGMudanca.RemoveCurrent();
        }

        public override void excluirRegistro()
        {
            if ((this.vTP_Modo == Utils.TTpModo.tm_Standby) || (this.vTP_Modo == Utils.TTpModo.tm_busca))
            {
                if (MessageBox.Show("Confirma Exclusão do Registro?", "Mensagem",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) ==
                System.Windows.Forms.DialogResult.Yes)
                {
                    TCN_CFGMudanca.Excluir(bsCFGMudanca.Current as TRegistro_CFGMudanca, null);
                    bsCFGMudanca.RemoveCurrent();
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

        private void cd_empresa_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LeaveEmpresa("a.cd_empresa|=|'" + cd_empresa.Text.Trim() + "'", new Componentes.EditDefault[] { cd_empresa, nm_empresa });
        }

        private void bb_empresa_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BuscaEmpresa(new Componentes.EditDefault[] { cd_empresa, nm_empresa }, string.Empty);
        }

        private void tp_duplicata_Leave(object sender, EventArgs e)
        {
            string vParam = "a.tp_duplicata|=|'" + tp_duplicata.Text.Trim() + "';" +
                            "a.tp_mov|=|'R'";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { tp_duplicata, ds_tpduplicata, tp_movDup },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadTpDuplicata());
        }

        private void bb_tpduplicata_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_tpduplicata|Tipo Duplicata|200;" +
                              "a.tp_duplicata|TP. Duplicata|80;" +
                              "a.tp_mov|Tipo Movimento|80";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { tp_duplicata, ds_tpduplicata, tp_movDup },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadTpDuplicata(), "a.tp_mov|=|'R'");
        }

        private void tp_docto_Leave(object sender, EventArgs e)
        {
            string vParam = "a.tp_docto|=|'" + tp_docto.Text.Trim() + "'";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { tp_docto, ds_tpdocto },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadTpDoctoDup());
        }

        private void bb_tpdocto_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_tpdocto|Tipo Documento|200;" +
                              "a.tp_docto|TP. Docto|80";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { tp_docto, ds_tpdocto },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadTpDoctoDup(), string.Empty);
        }

        private void Cd_PedidoServico_Leave(object sender, EventArgs e)
        {
            string vParam = "a.CFG_Pedido|=|'" + Cd_PedidoServico.Text.Trim() + "';" +
                            "||((b.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                            "(EXISTS(select 1 from tb_div_usuario_x_grupos x   " +
                            "       where x.logingrp = b.login and x.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "')))";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { Cd_PedidoServico, Ds_PedidoServico },
                                    new TCD_CadCFGPedido("SqlCodeBuscaXUsuario"));
        }

        private void bb_PedidoServico_Click(object sender, EventArgs e)
        {
            string vColunas = "ds_TipoPedido|Tipo Pedido|350;" +
                        "a.CFG_Pedido|Cód. CFG Pedido|100";
            string vParam = "||((b.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                            "(EXISTS(select 1 from tb_div_usuario_x_grupos x   " +
                            "       where x.logingrp = b.login and x.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "')))";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { Cd_PedidoServico, Ds_PedidoServico },
                                    new TCD_CadCFGPedido("SqlCodeBuscaXUsuario"), vParam);
        }

        private void cd_servicopadrao_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVEProduto("a.cd_produto|=|'" + cd_servicopadrao.Text.Trim() + "';" +
                                           "isnull(e.st_servico, 'N')|=|'S'",
                                           new Componentes.EditDefault[] { cd_servicopadrao },
                                           new CamadaDados.Estoque.Cadastros.TCD_CadProduto());
        }

        private void bb_servicopadrao_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BuscaProduto(new Componentes.EditDefault[] { cd_servicopadrao }, "isnull(e.st_servico, 'N')|=|'S'");
        }

        private void bb_loadMunicipal_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
                if (System.IO.File.Exists(ofd.FileName))
                {
                    (bsCFGMudanca.Current as TRegistro_CFGMudanca).ContratoMunicipal =
                        System.IO.File.ReadAllBytes(ofd.FileName);
                }
        }

        private void bb_visualizarMun_Click(object sender, EventArgs e)
        {
            byte[] arquivoBuffer = (bsCFGMudanca.Current as TRegistro_CFGMudanca).ContratoMunicipal;
            string extensao = ".docx"; // retornar do banco tbm
            nameTempMun = System.IO.Path.ChangeExtension(System.IO.Path.GetTempFileName(), extensao);

            System.IO.File.WriteAllBytes(
                nameTempMun,
                arquivoBuffer);

            // para abrir o arquivo para o usuario
            System.Diagnostics.Process.Start(nameTempMun);      
        }

        private void bb_loadInterMunicipal_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
                if (System.IO.File.Exists(ofd.FileName))
                {
                    (bsCFGMudanca.Current as TRegistro_CFGMudanca).ContratoInterMunicipal =
                        System.IO.File.ReadAllBytes(ofd.FileName);
                }
        }

        private void bb_visualizarInterMun_Click(object sender, EventArgs e)
        {
            byte[] arquivoBuffer = (bsCFGMudanca.Current as TRegistro_CFGMudanca).ContratoInterMunicipal;
            string extensao = ".docx"; // retornar do banco tbm

            nameTempInterMun = System.IO.Path.ChangeExtension(System.IO.Path.GetTempFileName(), extensao);

            System.IO.File.WriteAllBytes(
                nameTempInterMun,
                arquivoBuffer);

            // para abrir o arquivo para o usuario
            System.Diagnostics.Process.Start(nameTempInterMun);
        }
    }
}
