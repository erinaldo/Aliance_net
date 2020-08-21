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
    public partial class TFLanLoteAberto : Form
    {
        public string Cd_empresa
        { get; set; }
        public CamadaDados.Servicos.TRegistro_LoteOS rLote
        {
            get
            {
                if (bsLote.Current != null)
                    return (bsLote.Current as CamadaDados.Servicos.TRegistro_LoteOS);
                else
                    return null;
            }
        }

        public TFLanLoteAberto()
        {
            InitializeComponent();
            this.Cd_empresa = string.Empty;
        }

        private void TFLanLoteAberto_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, dataGridDefault2);
            if (!string.IsNullOrEmpty(Utils.Parametros.pubCultura))
                Idioma.TIdioma.AjustaCultura(this);
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            //Buscar lotes em aberto para a empresa
            bsLote.DataSource = new CamadaDados.Servicos.TCD_LoteOS().Select(
                                new Utils.TpBusca[]
                                {
                                    new Utils.TpBusca()
                                    {
                                        vNM_Campo = "a.cd_empresa",
                                        vOperador = "=",
                                        vVL_Busca = "'" + this.Cd_empresa.Trim() + "'"
                                    },
                                    new Utils.TpBusca()
                                    {
                                        vNM_Campo = "isnull(a.st_registro, 'A')",
                                        vOperador = "=",
                                        vVL_Busca = "'A'"
                                    }
                                }, 0, string.Empty);
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void TFLanLoteAberto_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, dataGridDefault2);
        }
    }
}
