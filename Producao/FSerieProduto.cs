using System;
using System.Windows.Forms;

namespace Producao
{
    public partial class TFSerieProduto : Form
    {
        public string pCd_empresa { get; set; }
        public string pCd_produto { get; set; }
        public string pDs_produto { get; set; }
        public bool st_cadastroavulso { get; set; } = false;
        public CamadaDados.Producao.Producao.TList_SerieProduto lSerie
        { get; set; }        
        public TFSerieProduto()
        {
            InitializeComponent();
            lSerie = new CamadaDados.Producao.Producao.TList_SerieProduto();
        }

        private void afterGrava()
        {
            if (bsSerie.Current != null)
                if ((bsSerie.DataSource as CamadaDados.Producao.Producao.TList_SerieProduto).Exists(p=> !string.IsNullOrEmpty(p.Nr_serie)))
                    DialogResult = DialogResult.OK;

        }

        private void InserirSerie()
        {
            if (st_cadastroavulso)
            {
                (bsSerie.DataSource as CamadaDados.Producao.Producao.TList_SerieProduto).Add(
                    new CamadaDados.Producao.Producao.TRegistro_SerieProduto
                    {
                        Cd_empresa = pCd_empresa,
                        Cd_produto = pCd_produto,
                        Ds_produto = pDs_produto
                    });
                bsSerie.Position = bsSerie.Count;
                bsSerie.ResetBindings(true);
            }
            if (bsSerie.Current != null)
            {
                Utils.InputBox ipb = new Utils.InputBox();
                string Nr_serie = ipb.ShowDialog();
                if (!string.IsNullOrEmpty(Nr_serie))
                {
                    string and = string.Empty;
                    //Verificar se já existe Nº Série cadastrado
                    if (!(bsSerie.DataSource as CamadaDados.Producao.Producao.TList_SerieProduto).Exists(p => p.Nr_serie == Nr_serie) &&
                        new CamadaDados.Producao.Producao.TCD_SerieProduto().BuscarEscalar(
                            new Utils.TpBusca[]
                            {
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "a.Nr_serie",
                                    vOperador = "=",
                                    vVL_Busca = "'" + Nr_serie.Trim() + "'"
                                },
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "isnull(a.st_registro, 'A')",
                                    vOperador = "<>",
                                    vVL_Busca = "'C'"
                                }
                            }, "1") == null)
                    {
                        (bsSerie.Current as CamadaDados.Producao.Producao.TRegistro_SerieProduto).Nr_serie = Nr_serie;
                        bsSerie.ResetCurrentItem();
                    }
                    else
                    {
                        MessageBox.Show("Já existe Nº Série cadastrado!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        bsSerie.RemoveCurrent();
                    }
                }
                else
                    bsSerie.RemoveCurrent();
            }
        }

        private void TFSerieProduto_Load(object sender, EventArgs e)
        {
            Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            bsSerie.DataSource = lSerie;
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            afterGrava();
        }

        private void TFSerieProduto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                DialogResult = DialogResult.Cancel;
            else if (e.KeyCode.Equals(Keys.Enter))
                InserirSerie();
        }

        private void bb_inserirserie_Click(object sender, EventArgs e)
        {
            InserirSerie();
        }

        private void gSerie_DoubleClick(object sender, EventArgs e)
        {
            InserirSerie();
        }
    }
}
