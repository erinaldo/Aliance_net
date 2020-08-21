using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Utils;

namespace Servicos
{
    public partial class TFLan_Lista_Acessorios : Form
    {
        public string Cd_produto
        { get; set; }

        public List<CamadaDados.Estoque.Cadastros.TRegistro_CadAcessoriosProduto> lAcessoriosSelecionados
        {
            get
            {
                if (bsListaAcessorios.DataSource != null)
                    return (bsListaAcessorios.DataSource as CamadaDados.Estoque.Cadastros.TList_CadAcessoriosProduto).FindAll(p => p.St_adicionar);
                else
                    return new List<CamadaDados.Estoque.Cadastros.TRegistro_CadAcessoriosProduto>();
            }
        }

        public TFLan_Lista_Acessorios()
        {
            InitializeComponent();
            this.Icon = ResourcesUtils.TecnoAliance_ICO;
        }

        private void BuscarListaAcessorios()
        {
            bsListaAcessorios.DataSource = CamadaNegocio.Estoque.Cadastros.TCN_CadAcessoriosProduto.Busca(0,
                                                                                                          string.Empty,
                                                                                                          Cd_produto);
        }

        private void TFLan_Lista_Acessorios_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case (Keys.F6):
                    {
                        this.DialogResult = DialogResult.Cancel; break;
                    }
                case (Keys.F4):
                    {
                        this.DialogResult = DialogResult.OK; break;
                    };
            }
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void TFLan_Lista_Acessorios_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Utils.Parametros.pubCultura))
                Idioma.TIdioma.AjustaCultura(this);
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            this.BuscarListaAcessorios();
        }
        
        private void gAcessorios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                (bsListaAcessorios.Current as CamadaDados.Estoque.Cadastros.TRegistro_CadAcessoriosProduto).St_adicionar =
                    !(bsListaAcessorios.Current as CamadaDados.Estoque.Cadastros.TRegistro_CadAcessoriosProduto).St_adicionar;
                bsListaAcessorios.ResetBindings(true);
            }
        }
    }
}
