using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CamadaDados.Frota.Cadastros;

namespace Frota
{
    public partial class TFMovimentarVeiculo : Form
    {
        private TRegistro_CadVeiculo _CadCavaloOrigem = null;
        private TRegistro_CadVeiculo _CadCavaloDestino = null;
        private TRegistro_CadVeiculo _CadCarreta = null;
        public TFMovimentarVeiculo()
        {
            InitializeComponent();
        }

        private bool buscarCarretaOrigem()
        {
            try
            {
                Utils.TpBusca[] tpBuscas = new Utils.TpBusca[0];
                Utils.Estruturas.CriarParametro(ref tpBuscas, "REPLACE(a.placa, '-', '')", "'" + Ed_NrPlacaOrigem.Text.Replace("-", string.Empty).Trim() + "'");
                Utils.Estruturas.CriarParametro(ref tpBuscas, "isnull(a.st_registro, 'A')", "'A'");
                string obj = new TCD_CadVeiculo().BuscarEscalar(tpBuscas, "a.id_veiculo").ToString();
                tpBuscas = new Utils.TpBusca[0];
                Utils.Estruturas.CriarParametro(ref tpBuscas, "a.id_veiculo_principal", obj);
                _CadCarreta = new TCD_CadVeiculo().Select(tpBuscas, 1, string.Empty)[0];
                Ed_CarretaOrigem.Text = _CadCarreta.placa;
                return true;
            }
            catch
            {
                MessageBox.Show("Erro ao localizar carreta para o cavalo origem informado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private bool validarExistenciaVeiculo()
        {
            if (!pnEntradaDados.validarCampoObrigatorio())
                return false;

            Utils.TpBusca[] tpBuscas = new Utils.TpBusca[0];
            Utils.Estruturas.CriarParametro(ref tpBuscas, "REPLACE(a.placa, '-', '')", "'" + Ed_NrPlacaOrigem.Text.Replace("-", string.Empty).Trim() + "'");
            Utils.Estruturas.CriarParametro(ref tpBuscas, "isnull(a.st_registro, 'A')", "'A'");
            _CadCavaloOrigem = new TCD_CadVeiculo().Select(tpBuscas, 1, string.Empty)[0];
            if (_CadCavaloOrigem == null)
            {
                MessageBox.Show("Placa de origem informada não existe cadastrada.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            tpBuscas = new Utils.TpBusca[0];
            Utils.Estruturas.CriarParametro(ref tpBuscas, "REPLACE(a.placa, '-', '')", "'" + Ed_NrPlacaDestino.Text.Replace("-", string.Empty).Trim() + "'");
            Utils.Estruturas.CriarParametro(ref tpBuscas, "isnull(a.st_registro, 'A')", "'A'");
            _CadCavaloDestino = new TCD_CadVeiculo().Select(tpBuscas, 1, string.Empty)[0];
            if (_CadCavaloDestino == null)
            {
                MessageBox.Show("Placa de destino informada não existe cadastrada.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private bool validarExistenciaMovimentacao()
        {
            if (Ed_HodometroFinal.Value < 1)
            {
                MessageBox.Show("Não é permitido hodometro menor que zero.", "Informativo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            CamadaDados.Frota.TList_MovPneu _MovPneus = CamadaNegocio.Frota.TCN_MovPneu.Buscar(string.Empty,
                                                                                               string.Empty,
                                                                                               _CadCarreta.Id_veiculostr,
                                                                                               string.Empty,
                                                                                               null,
                                                                                               "S");
            //Atualização da movimentação origem da carreta
            _MovPneus.ForEach(p =>
            {
                p.HodometroFinal = Convert.ToInt32(Ed_HodometroFinal.Value);
                p.St_rodando = "N";
                CamadaNegocio.Frota.TCN_MovPneu.Gravar(p, null);
            });

            //Gerar nova movimentação com carreta origem
            _MovPneus.ForEach(p =>
            {
                p.HodometroInicial = Convert.ToInt32(Ed_HodometroInicial.Value);
                p.HodometroFinal = 0;
                p.St_rodando = "S";
                p.Id_mov = null;
                CamadaNegocio.Frota.TCN_MovPneu.Gravar(p, null);
            });
            
            return true;
        }

        private void trocarCarreta()
        {
            try
            {
                _CadCarreta.Id_veiculo_principalstr = _CadCavaloDestino.Id_veiculostr;
                CamadaNegocio.Frota.Cadastros.TCN_CadVeiculo.Gravar(_CadCarreta, null);
                MessageBox.Show("Movimentação realizada com sucesso.", "Informativo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                pnEntradaDados.LimparRegistro();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void FMovimentarVeiculo_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void FMovimentarVeiculo_Load(object sender, EventArgs e)
        {

        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            //Validar existencia de placas informadas em veiculos carrocerias
            if (!validarExistenciaVeiculo()) return;

            //Buscar carreta para cavalo origem informado
            if (!buscarCarretaOrigem()) return;

            //Validar existencia de movimentacao pneu em aberto para veiculos informados
            if (!validarExistenciaMovimentacao()) return;

            trocarCarreta();
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void BB_Veiculo_Click(object sender, EventArgs e)
        {
            string vParam = "isnull(a.st_registro, 'A')|<>|'I'";
            string vColunas = "a.ds_veiculo|Veiculo|200;" +
                              "a.id_veiculo|Codigo|80;" +
                              "a.placa|Placa|80";

            Componentes.EditDefault placaOrigem = new Componentes.EditDefault();
            placaOrigem.NM_Campo = "placa origem";
            placaOrigem.NM_CampoBusca = "placa";
            placaOrigem.NM_Param = "@P_PLACA";

            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { id_veiculo, placaOrigem },
                new TCD_CadVeiculo(),
               vParam);

            if (!string.IsNullOrEmpty(placaOrigem.Text.Trim()))
            {
                Ed_NrPlacaOrigem.Text = placaOrigem.Text.Trim();
                buscarCarretaOrigem();
            }
        }

        private void BB_VeiculoDestino_Click(object sender, EventArgs e)
        {
            string vParam = "isnull(a.st_registro, 'A')|<>|'I'";
            string vColunas = "a.ds_veiculo|Veiculo|200;" +
                              "a.id_veiculo|Codigo|80;" +
                              "a.placa|Placa|80";

            Componentes.EditDefault placaDestino = new Componentes.EditDefault();
            placaDestino.NM_Campo = "placa destino";
            placaDestino.NM_CampoBusca = "placa";
            placaDestino.NM_Param = "@P_PLACA";

            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { id_veiculoDestino, placaDestino },
                new TCD_CadVeiculo(),
               vParam);

            if (!string.IsNullOrEmpty(placaDestino.Text.Trim()))
                Ed_NrPlacaDestino.Text = placaDestino.Text.Trim();
        }

        private void Ed_NrPlacaOrigem_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = Convert.ToChar(e.KeyChar.ToString().ToUpper());
        }

        private void id_veiculo_Leave(object sender, EventArgs e)
        {
            string vParam = "a.id_veiculo|=|'" + id_veiculo.Text.Trim() + "';" +
                                "isnull(a.st_registro, 'A')|<>|'I'";

            Componentes.EditDefault placaOrigem = new Componentes.EditDefault();
            placaOrigem.NM_Campo = "placa origem";
            placaOrigem.NM_CampoBusca = "placa";
            placaOrigem.NM_Param = "@P_PLACA";

            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { id_veiculo, placaOrigem },
                                            new TCD_CadVeiculo());

            if (!string.IsNullOrEmpty(placaOrigem.Text.Trim()))
            {
                Ed_NrPlacaOrigem.Text = placaOrigem.Text.Trim();
                buscarCarretaOrigem();
            }
        }

        private void id_veiculoDestino_Leave(object sender, EventArgs e)
        {
            string vParam = "a.id_veiculo|=|'" + id_veiculoDestino.Text.Trim() + "';" +
                                "isnull(a.st_registro, 'A')|<>|'I'";

            Componentes.EditDefault placaDestino = new Componentes.EditDefault();
            placaDestino.NM_Campo = "placa destino";
            placaDestino.NM_CampoBusca = "placa";
            placaDestino.NM_Param = "@P_PLACA";

            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { id_veiculoDestino, placaDestino },
                                            new TCD_CadVeiculo());

            if (!string.IsNullOrEmpty(placaDestino.Text.Trim()))
                Ed_NrPlacaDestino.Text = placaDestino.Text.Trim();
        }

        private void Ed_NrPlacaOrigem_Leave(object sender, EventArgs e)
        {
            buscarCarretaOrigem();
        }

    }
}
