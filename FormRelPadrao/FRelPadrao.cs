using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Utils;
using Componentes;

namespace FormRelPadrao
{
    public partial class FRelPadrao : Form
    {
        protected TpBusca[] vBusca;
        public FRelPadrao()
        {
            InitializeComponent();
        }

        public virtual void afterNovo()
        {
            pFiltro.LimparRegistro();
        }
        
        private void BB_Fechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BB_Novo_Click(object sender, EventArgs e)
        {
            afterNovo();
        }

        private void FRelPadrao_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Utils.Parametros.pubCultura))
                Idioma.TIdioma.AjustaCultura(this);
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
        }

    }
}