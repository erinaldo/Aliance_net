using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Servicos.Cadastros
{
    public partial class TFCad_CfgAgendamento : FormCadPadrao.FFormCadPadrao
    {
        public TFCad_CfgAgendamento()
        {
            InitializeComponent();
        }

        public override void habilitarControls(bool value)
        {
            pDados.HabilitarControls(value, this.vTP_Modo);
        }

        public override void formatZero()
        {
            pDados.set_FormatZero();
        }

        public override void afterNovo()
        {
            if ((vTP_Modo == Utils.TTpModo.tm_busca) || (vTP_Modo == Utils.TTpModo.tm_Standby))
                bsCfgAgendamento.AddNew();
            base.afterNovo();
            cd_empresa.Focus();

        }

        public override void afterAltera()
        {
            base.afterAltera();
            if (this.vTP_Modo.Equals(Utils.TTpModo.tm_Edit))
                bb_empresa.Enabled = false;
        }

        public override void afterCancela()
        {
            base.afterCancela();
        }

        public override string gravarRegistro()
        {
            if (pDados.validarCampoObrigatorio())
                try
                {
                    return CamadaNegocio.Servicos.Cadastros.TCN_CfgAgendamento.Gravar(bsCfgAgendamento.Current as CamadaDados.Servicos.Cadastros.TRegistro_CfgAgendamento, null);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro gravar config. " + ex.Message.Trim());
                    return string.Empty;
                }
            else
                return string.Empty;
        }

        public override void excluirRegistro()
        {
            if ((this.vTP_Modo == Utils.TTpModo.tm_Standby) || (this.vTP_Modo == Utils.TTpModo.tm_busca))
            {
                if (MessageBox.Show("Confirma Exclusão do Registro?", "Mensagem",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) ==
                System.Windows.Forms.DialogResult.Yes)
                {
                    CamadaNegocio.Servicos.Cadastros.TCN_CfgAgendamento.Excluir(bsCfgAgendamento.Current as CamadaDados.Servicos.Cadastros.TRegistro_CfgAgendamento, null);
                    bsCfgAgendamento.RemoveCurrent();
                    pDados.LimparRegistro();
                    afterBusca();
                }
            }
        }

        public override int buscarRegistros()
        {
            CamadaDados.Servicos.Cadastros.TList_CfgAgendamento lista =
                CamadaNegocio.Servicos.Cadastros.TCN_CfgAgendamento.Buscar(cd_empresa.Text, null);
            if (lista != null)
            {
                if (lista.Count > 0)
                {
                    this.Lista = lista;
                    bsCfgAgendamento.DataSource = lista;
                }
                else
                    if ((vTP_Modo == Utils.TTpModo.tm_Standby) || (vTP_Modo == Utils.TTpModo.tm_busca))
                        bsCfgAgendamento.Clear();
                return lista.Count;
            }
            else
                return 0;
        }

        private void bb_empresa_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaEmpresa(new Componentes.EditDefault[] { cd_empresa, nm_empresa }, string.Empty);
        }

        private void cd_empresa_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveEmpresa("a.cd_empresa|=|'" + cd_empresa.Text.Trim() + "'", new Componentes.EditDefault[] { cd_empresa, nm_empresa });
        }

        private void bb_tpordem_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_tipoordem|Tipo Ordem Serviço|200;" +
                              "a.tp_ordem|TP. Ordem|60";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { tp_ordem, ds_tipoordem },
                new CamadaDados.Servicos.Cadastros.TCD_TpOrdem(), string.Empty);
        }

        private void tp_ordem_Leave(object sender, EventArgs e)
        {
            string vParam = "a.tp_ordem|=|" + tp_ordem.Text;
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { tp_ordem, ds_tipoordem },
                new CamadaDados.Servicos.Cadastros.TCD_TpOrdem());
        }

        private void bb_tabpreco_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_tabelapreco|Tabela Preço|200;" +
                              "a.cd_tabelapreco|Código|60";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_tabelapreco, ds_tabelapreco },
                new CamadaDados.Diversos.TCD_CadTbPreco(), string.Empty);
        }

        private void cd_tabelapreco_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LEAVE("a.cd_tabelapreco|=|'" + cd_tabelapreco.Text.Trim() + "'",
                new Componentes.EditDefault[] { cd_tabelapreco, ds_tabelapreco },
                new CamadaDados.Diversos.TCD_CadTbPreco());
        }

        private void bb_local_Click(object sender, EventArgs e)
        {
            string vColunas = "c.ds_local|Local Armazenagem|200;" +
                              "a.cd_local|Cd. Local|60";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_local, ds_local },
                new CamadaDados.Estoque.Cadastros.TCD_CadLocalArm_X_Empresa(), "a.cd_empresa|=|'" + cd_empresa.Text.Trim() + "'");
        }

        private void cd_local_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_local|=|'" + cd_local.Text.Trim() + "';" +
                            "a.cd_empresa|=|'" + cd_empresa.Text.Trim() + "'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_local, ds_local },
                new CamadaDados.Estoque.Cadastros.TCD_CadLocalArm_X_Empresa());
        }
    }
}
