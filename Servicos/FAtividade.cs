using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Servicos
{
    public partial class TFAtividade : Form
    {
        public string vId_os
        { get; set; }
        public string vId_evolucao
        { get; set; }
        public string vCd_tecnico
        { get; set; }
        public string vCd_empresa
        { get; set; }
        private CamadaDados.Servicos.TRegistro_LanAtividades ratividade;
        public CamadaDados.Servicos.TRegistro_LanAtividades rAtividade
        {
            get
            {
                if (bsAtividade.Current != null)
                    return bsAtividade.Current as CamadaDados.Servicos.TRegistro_LanAtividades;
                else
                    return null;
            }
            set { ratividade = value; }
        }
        public TFAtividade()
        {
            InitializeComponent();
        }

        private void afterGrava()
        {
            if (string.IsNullOrEmpty(DS_Funcao.Text))
            {
                MessageBox.Show("Obrigatório informar Técnico!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (string.IsNullOrEmpty(Ds_atividade.Text))
            {
                MessageBox.Show("Obrigatório informar Descrição Atividade!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            (bsAtividade.Current as CamadaDados.Servicos.TRegistro_LanAtividades).Id_evolucaostr = id_etapa.Text;
            this.DialogResult = DialogResult.OK;
        }

        private void TFAtividade_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pDados.set_FormatZero();
            bsAtividade.AddNew();
            DT_Atividade.Text = CamadaDados.UtilData.Data_Servidor().ToString("dd/MM/yyyy");
            CD_Empresa.Text = vCd_empresa;
            CD_Empresa_Leave(this, new EventArgs());
            id_projeto.Text = vId_os;
            id_projeto_Leave(this, new EventArgs());
            id_etapa.Text = vId_evolucao;
            id_etapa_Leave(this, new EventArgs());
            ID_Tecnico.Text = vCd_tecnico;
            ID_Tecnico_Leave(this, new EventArgs());
            Ds_atividade.Focus();
            if (!string.IsNullOrEmpty(ID_Tecnico.Text))
            {
                ID_Tecnico.Enabled = false;
                BB_Tecnico.Enabled = false;
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

        private void TFAtividade_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
        }

        private void id_projeto_Leave(object sender, EventArgs e)
        {
            string vParam = "a.ID_OS|=|" + id_projeto.Text +
                            ";a.ST_OS|<>|'CA'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { id_projeto, ds_projeto },
                new CamadaDados.Servicos.TCD_LanServico());
            if (!string.IsNullOrEmpty(id_etapa.Text))
                id_etapa_Leave(this, new EventArgs());

        }

        private void bb_projeto_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_servico|Descrição Projeto|200;" +
                               "a.id_os|Id.Projeto|80";
          FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] {id_projeto, ds_projeto},
                                            new CamadaDados.Servicos.TCD_LanServico(), "a.ST_OS|<>|'CA'");
          if (!string.IsNullOrEmpty(id_etapa.Text))
              id_etapa_Leave(this, new EventArgs());
        }

        private void id_etapa_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(id_projeto.Text))
            {
                string vParam = "a.id_evolucao|=|" + id_etapa.Text +
                                ";a.id_os|=|" + id_projeto.Text.Trim(); 
                FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { id_etapa, ds_etapa },
                                                new CamadaDados.Servicos.TCD_LanServicoEvolucao());
            }
        }

        private void bb_etapa_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(id_projeto.Text))
            {
                string vColunas = "a.ds_evolucao|Descrição Etapa|200;" +
                                "a.id_evolucao|Id. Etapa|80";
                string vParam = "a.id_os|=|" + id_projeto.Text.Trim(); 
                FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { id_etapa, ds_etapa },
                                                new CamadaDados.Servicos.TCD_LanServicoEvolucao(), vParam);
            }
        }

        private void ID_Tecnico_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveClifor("a.cd_clifor|=|'" + ID_Tecnico.Text.Trim() + "';isnull(a.st_tecnico, 'N')|=|'S'",
                                                  new Componentes.EditDefault[] { ID_Tecnico, DS_Funcao },
                                                  new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
        }

        private void BB_Tecnico_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { ID_Tecnico, DS_Funcao }, "isnull(a.st_tecnico, 'N')|=|'S'");
        }

        private void CD_Empresa_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveEmpresa("a.cd_empresa|=|'" + CD_Empresa.Text.Trim() + "'", new Componentes.EditDefault[] { CD_Empresa, NM_Empresa });
        }

        private void BB_Empresa_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaEmpresa(new Componentes.EditDefault[] { CD_Empresa, NM_Empresa }, string.Empty);
        }
    }
}
