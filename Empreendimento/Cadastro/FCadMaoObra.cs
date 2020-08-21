using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using BancoDados;
using Utils;
using System.Collections;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;
using FormBusca;

namespace Empreendimento.Cadastro
{
    public partial class FCadMaoObra : Form
    {
        public string vCd_Empresa { get; set; }
        private decimal horas20 { get; set; }
        private decimal horas100 { get; set; }
        private decimal horas150 { get; set; }
        private decimal horas50 { get; set; }
        private decimal valormes { get; set; }
        private bool pSt_Bloquear = false;

        private CamadaDados.Empreendimento.Cadastro.TRegistro_CadMaoObra cMaoObra;
        public CamadaDados.Empreendimento.Cadastro.TRegistro_CadMaoObra rMaoObra
        {
            get
            {
                return bsMaoObra.Current as CamadaDados.Empreendimento.Cadastro.TRegistro_CadMaoObra;
            }
            set { cMaoObra = value; }
        }
        public FCadMaoObra()
        {
            InitializeComponent();
        }
        private void FCadMaoObra_Load(object sender, EventArgs e)
        {

            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;


            if (cMaoObra != null)
            {
                bsMaoObra.DataSource = new CamadaDados.Empreendimento.Cadastro.TList_CadMaoObra() { cMaoObra };
                cargo_base.Value = buscarSalario();
                calculatotal();
                valormes = cMaoObra.cargahorariaMes;
            }
            else
            {
                bsMaoObra.AddNew();
            }


        }

        private void panelDados1_Paint(object sender, PaintEventArgs e)
        {

        }


        private decimal buscarSalario()
        {
            decimal valor = decimal.Zero;

            if (!string.IsNullOrEmpty(cd_vendedor.Text))
            {
                object obj = new CamadaDados.Diversos.TCD_CargoFuncionario().BuscarEscalar(
                    new TpBusca[]
                    {
                        new TpBusca()
                        {
                            vNM_Campo = "a.id_cargo",
                            vOperador = "=",
                            vVL_Busca = cd_vendedor.Text
                        }
                    }, "a.vl_basesalario");
                if (obj != null)
                    if (!string.IsNullOrEmpty(obj.ToString()))
                        valor = Convert.ToDecimal(obj.ToString());
            }
            return valor;
        }
        private decimal buscarcargahoraria()
        {
            decimal valor = decimal.Zero;

            if (!string.IsNullOrEmpty(cd_vendedor.Text))
            {
                object obj = new CamadaDados.Diversos.TCD_CargoFuncionario().BuscarEscalar(
                    new TpBusca[]
                    {
                        new TpBusca()
                        {
                            vNM_Campo = "a.id_cargo",
                            vOperador = "=",
                            vVL_Busca = cd_vendedor.Text
                        }
                    }, "a.cargahorariames");
                if (obj != null)
                    if (!string.IsNullOrEmpty(obj.ToString()))
                        valor = Convert.ToDecimal(obj.ToString());
            }
            return valor;
        }
        private string buscarUnidadeCargo()
        {
            if (!string.IsNullOrEmpty(cd_vendedor.Text))
            {
                object obj = new CamadaDados.Empreendimento.Cadastro.TCD_CadCFGEmpreendimento().BuscarEscalar(
                    new TpBusca[]
                    {
                        new TpBusca()
                        {
                            vNM_Campo = "a.CD_EMPRESA",
                            vOperador = "=",
                            vVL_Busca = vCd_Empresa
                        }
                    }, "a.cd_unidmes");
                if (obj != null)
                    return obj.ToString();
            }
            return string.Empty;
        }

        private void bb_vendedor_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BUSCA(
                               "a.ds_cargo|Cargo Funcionario|150;" +
                               "a.id_cargo|Código|50;" +
                               "a.vl_basesalario|Salario Base|80",
                               new Componentes.EditDefault[] { cd_vendedor, nm_vendedor },
                               new CamadaDados.Diversos.TCD_CargoFuncionario(),
                               string.Empty);

            cargo_base.Value = buscarSalario();
            if (valormes <= decimal.Zero)
                cargahorariames.Value = buscarcargahoraria();
            calculatotal();
        }

        private void cd_vendedor_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LEAVE(
                "a.id_cargo|=|" + cd_vendedor.Text,
                new Componentes.EditDefault[] { cd_vendedor, nm_vendedor },
                new CamadaDados.Diversos.TCD_CargoFuncionario());
            cargo_base.Value = buscarSalario();
            if (valormes <= decimal.Zero)
                cargahorariames.Value = buscarcargahoraria();
            calculatotal();

        }

        private void PESSOAS_Leave(object sender, EventArgs e)
        {
            calculatotal();
        }

        private void Quantidade_Leave(object sender, EventArgs e)
        {
            calculatotal();
        }

        private void calculatotal()
        {
            if (cargahorariames.Value > decimal.Zero && cargo_base.Value > decimal.Zero)
                vlhora.Value = Math.Round(decimal.Divide(Math.Round(cargo_base.Value, 2, MidpointRounding.AwayFromZero), Math.Round(cargahorariames.Value, 2, MidpointRounding.AwayFromZero)), 2, MidpointRounding.AwayFromZero);
            try
            {
                pSt_Bloquear = false;
                if (Math.Round(cargo_base.Value, 2, MidpointRounding.AwayFromZero) > decimal.Zero && !string.IsNullOrEmpty(cd_unidade.Text))
                {
                    vl_unitario.Value = CamadaNegocio.Estoque.Cadastros.TCN_CadConvUnidade.ConvertUnid(buscarUnidadeCargo(), cd_unidade.Text, Math.Round(cargo_base.Value, 2, MidpointRounding.AwayFromZero), 2, null);
                    vl_unitario.Enabled = false;
                }
                else
                    vl_unitario.Enabled = true;
            }
            catch (Exception ex)
            {
                pSt_Bloquear = true;
                MessageBox.Show(ex.Message.Trim(), "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


            if (PESSOAS.Value != decimal.Zero || Quantidade.Value != decimal.Zero || vl_unitario.Value != decimal.Zero)
            {
                if (editFloat5.Value >= decimal.Zero)
                {
                    hora100.Value = decimal.Multiply(decimal.Multiply(PESSOAS.Value, Math.Round(horas100, 2, MidpointRounding.AwayFromZero)), Math.Round(editFloat5.Value, 2, MidpointRounding.AwayFromZero));
                }
                if (editFloat6.Value >= decimal.Zero)
                {
                    hora50.Value = decimal.Multiply(decimal.Multiply(PESSOAS.Value, Math.Round(horas50, 2, MidpointRounding.AwayFromZero)), Math.Round(editFloat6.Value, 2, MidpointRounding.AwayFromZero));
                }
                if (editFloat7.Value >= decimal.Zero)
                {
                    hora20.Value = decimal.Multiply(decimal.Multiply(PESSOAS.Value, Math.Round(horas20, 2, MidpointRounding.AwayFromZero)), Math.Round(editFloat7.Value, 2, MidpointRounding.AwayFromZero));
                }
                if (editFloat9.Value >= decimal.Zero)
                {
                    decimal h150 = decimal.Multiply( horas150, editFloat9.Value);
                    hora150.Value = decimal.Multiply(PESSOAS.Value, Math.Round(h150 , 2, MidpointRounding.AwayFromZero));
                }
                total.Value = decimal.Multiply(PESSOAS.Value, decimal.Multiply(Math.Round(Quantidade.Value, 2, MidpointRounding.AwayFromZero), Math.Round(vl_unitario.Value, 2, MidpointRounding.AwayFromZero)))
                +
                (hora150.Value)
                +
                (hora100.Value)
                + 
                (hora50.Value)
                + 
                (hora20.Value);
            }
        }
        private void vl_unitario_Leave(object sender, EventArgs e)
        {
            calculatotal();
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            calculatotal();
            if (!pSt_Bloquear)
                this.DialogResult = DialogResult.OK;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BUSCA(
                               "a.ds_unidade|Unidade|150;" +
                               "a.cd_unidade|Código|50",
                               new Componentes.EditDefault[] { cd_unidade, editDefault4 },
                               new CamadaDados.Estoque.Cadastros.TCD_CadUnidade(),
                               string.Empty);
            calculatotal();
            // vl_unitario.Value = buscarSalario();
        }

        private void editDefault3_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LEAVE(
               "a.cd_unidade|=|" + cd_unidade.Text + "",
               new Componentes.EditDefault[] { cd_unidade, editDefault4 },
               new CamadaDados.Estoque.Cadastros.TCD_CadUnidade());
            calculatotal();
        }

        private void cargo_base_Leave(object sender, EventArgs e)
        {
            calculatotal();
        }

        private void editFloat5_Leave(object sender, EventArgs e)
        {

            calculatotal();
        }

        private void editFloat6_Leave(object sender, EventArgs e)
        {

            calculatotal();
        }

        private void editFloat7_Leave(object sender, EventArgs e)
        {


            calculatotal();
        }

        private void vlhora_ValueChanged(object sender, EventArgs e)
        {
            if (vlhora.Value != decimal.Zero)
            {
                horas50 = decimal.Multiply(vlhora.Value, decimal.Divide(150, 100));
                horas100 = decimal.Multiply(vlhora.Value, 2);
                horas150 = decimal.Multiply(vlhora.Value, Convert.ToDecimal("2,5"));
                horas20 = decimal.Multiply(vlhora.Value, decimal.Divide(120, 100));
            }
        }

        private void FCadMaoObra_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
            {
                bb_inutilizar_Click(this, new EventArgs());
            }
            if (e.KeyCode.Equals(Keys.F6))
            {
                bb_cancelar_Click(this, new EventArgs());
            }
        }

        private void editFloat9_Leave(object sender, EventArgs e)
        {
            calculatotal();
        }
    }
}
