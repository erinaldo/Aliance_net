using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Utils;

namespace Locacao
{
    public partial class TFPainelMotorista : Form
    {
        public TFPainelMotorista()
        {
            InitializeComponent();
        }

        private void afterBuscar()
        {
            bsLocacao.DataSource = CamadaNegocio.Locacao.TCN_Locacao.buscar(string.Empty,
                                                                            Id_locacao.Text,
                                                                            string.Empty,
                                                                            string.Empty,
                                                                            string.Empty,
                                                                            string.Empty,
                                                                            string.Empty,
                                                                            string.Empty,
                                                                            string.Empty,
                                                                            string.Empty,
                                                                            string.Empty,
                                                                            string.Empty,
                                                                            string.Empty,
                                                                            "'0'",
                                                                            string.Empty,
                                                                            null,
                                                                            cd_motorista: cd_motorista.Text);//Aguardando entrega
            pnFiltro.LimparRegistro();
            if (bsLocacao.Count > 0)
                (bsLocacao.DataSource as CamadaDados.Locacao.TList_Locacao).ForEach(l =>
                {
                    l.lColetaEntrega = new CamadaDados.Locacao.TCD_ColetaEntrega().Select(
                                            new TpBusca[]
                                            {
                                                new TpBusca()
                                                {
                                                    vNM_Campo = string.Empty,
                                                    vOperador = "exists",
                                                    vVL_Busca = "(select 1 from TB_LOC_Vistoria_X_ColEnt x " +
                                                                "where a.cd_empresa = x.cd_empresa " +
                                                                "and a.ID_Coleta = x.ID_Coleta " +
                                                                "and x.cd_empresa = '" + l.Cd_empresa.Trim() + "'" +
                                                                "and x.id_locacao = " + l.Id_locacaostr + ") "
                                                    }
                                            }, 0, string.Empty);
                    if (l.lColetaEntrega.Count > 0)
                    {
                        l.lColetaEntrega.ForEach(c =>
                        {
                            c.lVistoria = new CamadaDados.Locacao.TCD_Vistoria().Select(
                                new TpBusca[]
                                {
                                    new TpBusca()
                                    {
                                        vNM_Campo = string.Empty,
                                        vOperador = "exists",
                                        vVL_Busca = "(select 1 from TB_LOC_Vistoria_X_ColEnt x " +
                                                    "where x.cd_empresa =  a.cd_empresa " +
                                                    "and a.ID_Vistoria = x.ID_Vistoria " +
                                                    "and a.ID_ItemLoc = x.ID_ItemLoc " +
                                                    "and a.ID_Locacao = x.ID_Locacao " +
                                                    "and x.cd_empresa = '" + c.Cd_empresa.Trim() + "'" +
                                                    "and x.ID_Coleta = " + c.Id_coletastr + ")"
                                    }
                                }, 0, string.Empty);
                        });
                    }
                });
            bsLocacao.ResetBindings(true);
        }

        private void emEntrega()
        {
            if (bsLocacao.Current == null)
            {
                MessageBox.Show("Necessário selecionar alguma locação para entregar.", "Informativo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (bsColetaEntrega.Current == null)
            {
                MessageBox.Show("Necessário que locação selecionada tenha coleta/entrega.", "Informativo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (Parametros.Diversos.TFRegraUsuario fUsuario = new Parametros.Diversos.TFRegraUsuario())
            {
                fUsuario.Ds_regraespecial = "PERMITIR EVOLUIR ENTREGA";
                if (fUsuario.ShowDialog() == DialogResult.OK)
                {
                    //Buscar código do usuário informado
                    object obj = new CamadaDados.Financeiro.Cadastros.TCD_CadClifor().BuscarEscalar(
                        new Utils.TpBusca[]
                        {
                            new Utils.TpBusca()
                            {
                                vNM_Campo = "a.loginvendedor",
                                vOperador = "=",
                                vVL_Busca = "'"+fUsuario.Login.Trim()+"'"
                            }
                        }, "a.cd_clifor");
                    if (obj == null || string.IsNullOrEmpty(obj.ToString()))
                    {
                        MessageBox.Show("Não foi possível obter o login de vendedor, certifique-se que o motorista tenha pré-cadastrado.");
                        return;
                    }

                    if (obj.ToString().Equals((bsColetaEntrega.Current as CamadaDados.Locacao.TRegistro_ColetaEntrega).Cd_motorista))
                    {
                        if (MessageBox.Show("Confirma evolução da locação? \nDe: Aguardando Entrega.\nPara: Em entrega. ", "Mensagem", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1).Equals(DialogResult.Yes))
                        {
                            (bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).St_registro = "E";
                            CamadaNegocio.Locacao.TCN_Locacao.Gravar((bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao), null);
                            afterBuscar();
                        }
                    }
                    else
                    {
                        MessageBox.Show("O motorista informado não condiz com o explícito na locação.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
            }
        }

        private void TFPainelMotorista_Load(object sender, EventArgs e)
        {
            pnFiltro.set_FormatZero();
            afterBuscar();
        }

        private void BB_Fechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BB_Entrega_Click(object sender, EventArgs e)
        {
            emEntrega();
        }

        private void TFPainelMotorista_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F5))
                emEntrega();
        }

        private void BB_Buscar_Click(object sender, EventArgs e)
        {
            afterBuscar();
        }

        private void cd_motorista_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_clifor|=|'" + cd_motorista.Text.Trim() + "';" +
                            "isnull(a.st_motorista, 'N')|=|'S';" +
                            "isnull(a.st_ativomot, 'N')|=|'S'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_motorista, nmmotorista },
                                                                new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
        }

        private void bb_motorista_Click(object sender, EventArgs e)
        {
            string vColunas = "a.nm_clifor|Motorista|200;" +
                              "a.cd_clifor|Codigo|80;" +
                              "a.id_veiculo|Id. Veiculo|80;" +
                              "d.ds_veiculo|Veiculo|100;" +
                              "d.placa|Placa|80;" +
                              "a.categoria_cnh|Categoria CNH|80;" +
                              "a.dt_vencimento_cnh|Vencimento CNH|100";
            string vParam = "isnull(a.st_motorista, 'N')|=|'S';" +
                            "isnull(a.st_ativomot, 'N')|=|'S'";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_motorista, nmmotorista },
                                                                new CamadaDados.Financeiro.Cadastros.TCD_CadClifor(), vParam);
        }
    }
}
