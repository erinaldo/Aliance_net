using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CamadaDados.Diversos;
using CamadaNegocio.Diversos;

namespace FormCadPadrao
{

    public partial class FFormCadPadrao : FormPadrao.FFormPadrao
    {
        public Componentes.PanelDados[] vPanel;
        public int vIndexPanel = 0;
           
        public FFormCadPadrao()
        {
            InitializeComponent();
            vPanel = new Componentes.PanelDados[0];           
            vIndexPanel = 0;
            Array.Resize(ref vPanel, tcCentral.TabCount);
            vPanel[0] = pDados;
        }

        public override void DetalhesAcesso()
        {
            //Buscar config de acesso do usuario
            TRegistro_CadAcesso Acesso = TCN_CadAcesso.BuscarDetalhesAcesso(Utils.Parametros.pubLogin.Trim(), this.GetType().FullName.Trim().ToUpper());
            //TRegistro_CadAcesso Acesso = null;
            if (Acesso != null)
            {
                BB_Novo.Enabled = Acesso.Incluibool;
                if (!BB_Novo.Enabled)
                    BB_Novo.ToolTipText = "Usuario sem permissão para realizar operação.";
                BB_Alterar.Enabled = Acesso.Alterabool;
                if (!BB_Alterar.Enabled)
                    BB_Alterar.ToolTipText = "Usuario sem permissão para realizar operação.";
                BB_Excluir.Enabled = Acesso.Excluibool;
                if (!BB_Excluir.Enabled)
                    BB_Excluir.ToolTipText = "Usuario sem permissão para realizar operação.";
            }
        }
                
        public override void habilitarControls(bool value)
        {
            this.vPanel[vIndexPanel].HabilitarControls(value, this.vTP_Modo);
        }

        public override void limparControls()
        {
            this.vPanel[vIndexPanel].LimparRegistro();
        }

        private void tcCentral_SelectedIndexChanged(object sender, EventArgs e)
        {
            vIndexPanel = tcCentral.SelectedIndex;
        }
    }

}

