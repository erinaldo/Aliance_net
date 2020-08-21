using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PostoCombustivel
{
    public partial class TFEncerranteManual : Form
    {
        private string Tp_encerrante
        { get; set; }

        public TFEncerranteManual()
        {
            InitializeComponent();
        }

        private void BuscarVolumeVendido()
        {
            if ((!string.IsNullOrEmpty(CD_Empresa.Text)) &&
                (!string.IsNullOrEmpty(id_bico.Text)) &&
                (dt_encerrante.Text.Trim() != "/  /"))
            {
                object obj_volume =
                new CamadaDados.PostoCombustivel.TCD_VendaCombustivel().BuscarEscalar(
                    new Utils.TpBusca[]
                    {
                        new Utils.TpBusca()
                        {
                            vNM_Campo = "a.cd_empresa",
                            vOperador = "=",
                            vVL_Busca = "'" + CD_Empresa.Text.Trim() + "'"
                        },
                        new Utils.TpBusca()
                        {
                            vNM_Campo = "a.id_bico",
                            vOperador = "=",
                            vVL_Busca = id_bico.Text
                        },
                        new Utils.TpBusca()
                        {
                            vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.dt_abastecimento)))",
                            vOperador = "=",
                            vVL_Busca = "'" + dt_encerrante.Data.ToString("yyyyMMdd") + "'"
                        }
                    }, "isnull(sum(isnull(a.volumeabastecido, 0)), 0)");
                volumevendido.Value = obj_volume != null ? decimal.Parse(obj_volume.ToString()) : decimal.Zero;
                volumediferenca.Value = encerranteabertura.Value + volumevendido.Value - encerrantefechamento.Value;
            }
        }

        private void BuscarEncerranteAbertura()
        {
            if ((!string.IsNullOrEmpty(CD_Empresa.Text)) &&
                (!string.IsNullOrEmpty(id_bico.Text)) &&
                (dt_encerrante.Text.Trim() != "/  /"))
            {
                object obj_enc = new CamadaDados.PostoCombustivel.TCD_EncerranteBico().BuscarEscalar(
                                    new Utils.TpBusca[]
                                    {
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "a.id_bico",
                                            vOperador = "=",
                                            vVL_Busca = id_bico.Text
                                        },
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = string.Empty,
                                            vOperador = string.Empty,
                                            vVL_Busca = "((a.tp_encerrante = 'A' and " +
                                                        "convert(datetime, floor(convert(numeric(30,10), a.dt_encerrante))) = '" + dt_encerrante.Data.ToString("yyyyMMdd") + "') or " +
                                                        "(a.tp_encerrante = 'F' and " +
                                                        "convert(datetime, floor(convert(numeric(30,10), a.dt_encerrante))) = '" + dt_encerrante.Data.AddDays(-1).ToString("yyyyMMdd") + "'))"
                                        }
                                    }, "isnull(a.qtd_encerrante, 0)");
                encerranteabertura.Value = obj_enc != null ? decimal.Parse(obj_enc.ToString()) : decimal.Zero;
                volumediferenca.Value = encerranteabertura.Value + volumevendido.Value - encerrantefechamento.Value;
            }
        }

        private void BuscarEncerranteFechamento()
        {
            if ((!string.IsNullOrEmpty(CD_Empresa.Text)) &&
                (!string.IsNullOrEmpty(id_bico.Text)) &&
                (dt_encerrante.Text.Trim() != "/  /"))
            {
                object obj_enc = new CamadaDados.PostoCombustivel.TCD_EncerranteBico().BuscarEscalar(
                                    new Utils.TpBusca[]
                                    {
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = "a.id_bico",
                                            vOperador = "=",
                                            vVL_Busca = id_bico.Text
                                        },
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = string.Empty,
                                            vOperador = string.Empty,
                                            vVL_Busca = "((a.tp_encerrante = 'F' and " +
                                                        "convert(datetime, floor(convert(numeric(30,10), a.dt_encerrante))) = '" + dt_encerrante.Data.ToString("yyyyMMdd") + "') or " +
                                                        "(a.tp_encerrante = 'A' and " +
                                                        "convert(datetime, floor(convert(numeric(30,10), a.dt_encerrante))) = '" + dt_encerrante.Data.AddDays(1).ToString("yyyyMMdd") + "'))"
                                        }
                                    }, "isnull(a.qtd_encerrante, 0)");
                encerrantefechamento.Value = obj_enc != null ? decimal.Parse(obj_enc.ToString()) : decimal.Zero;
                volumediferenca.Value = encerranteabertura.Value + volumevendido.Value - encerrantefechamento.Value;
            }
        }

        private void TFEncerranteManual_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pDados.set_FormatZero();
        }

        private void BB_Empresa_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaEmpresa(new Componentes.EditDefault[] { CD_Empresa, nm_empresa }, string.Empty);
            this.BuscarVolumeVendido();
            this.BuscarEncerranteAbertura();
            this.BuscarEncerranteFechamento();
            object obj = new CamadaDados.PostoCombustivel.Cadastros.TCD_CfgPosto().BuscarEscalar(
                            new Utils.TpBusca[]
                            {
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "a.cd_empresa",
                                    vOperador = "=",
                                    vVL_Busca = "'" + CD_Empresa.Text.Trim() + "'"
                                }
                            }, "a.tp_leituraencerrantebico");
            if (obj != null)
                Tp_encerrante = obj.ToString();
        }

        private void CD_Empresa_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveEmpresa("a.cd_empresa|=|'" + CD_Empresa.Text.Trim() + "'",
                                                    new Componentes.EditDefault[] { CD_Empresa, nm_empresa });
            this.BuscarVolumeVendido();
            this.BuscarEncerranteAbertura();
            this.BuscarEncerranteFechamento();
            object obj = new CamadaDados.PostoCombustivel.Cadastros.TCD_CfgPosto().BuscarEscalar(
                            new Utils.TpBusca[]
                            {
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "a.cd_empresa",
                                    vOperador = "=",
                                    vVL_Busca = "'" + CD_Empresa.Text.Trim() + "'"
                                }
                            }, "a.tp_leituraencerrantebico");
            if (obj != null)
                Tp_encerrante = obj.ToString();
        }

        private void bb_bico_Click(object sender, EventArgs e)
        {
            string vColunas = "a.id_bico|Id. Bico|60;" +
                              "a.ds_label|Label Bico|80;" +
                              "c.ds_produto|Combustivel|200";
            string vParam = "a.cd_empresa|=|'" + CD_Empresa.Text.Trim() + "';" +
                            "isnull(a.st_registro, 'A')|<>|'C'";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas,
                                            new Componentes.EditDefault[] { id_bico },
                                            new CamadaDados.PostoCombustivel.Cadastros.TCD_BicoBomba(),
                                            vParam);
            this.BuscarVolumeVendido();
            this.BuscarEncerranteAbertura();
            this.BuscarEncerranteFechamento();
        }

        private void id_bico_Leave(object sender, EventArgs e)
        {
            string vParam = "a.id_bico|=|" + id_bico.Text.Trim() + ";" +
                            "a.cd_empresa|=|'" + CD_Empresa.Text.Trim() + "';" +
                            "isnull(a.st_registro, 'A')|<>|'C'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { id_bico },
                                            new CamadaDados.PostoCombustivel.Cadastros.TCD_BicoBomba());
            this.BuscarVolumeVendido();
            this.BuscarEncerranteAbertura();
            this.BuscarEncerranteFechamento();
        }

        private void dt_encerrante_Leave(object sender, EventArgs e)
        {
            this.BuscarVolumeVendido();
            this.BuscarEncerranteAbertura();
            this.BuscarEncerranteFechamento();
        }

        private void bb_calcfechamento_Click(object sender, EventArgs e)
        {
            if (encerranteabertura.Value > decimal.Zero)
            {
                encerrantefechamento.Value = encerranteabertura.Value + volumevendido.Value;
                volumediferenca.Value = encerranteabertura.Value + volumevendido.Value - encerrantefechamento.Value;
            }
        }

        private void bb_calcabertura_Click(object sender, EventArgs e)
        {
            if (encerrantefechamento.Value > decimal.Zero)
            {
                encerranteabertura.Value = encerrantefechamento.Value - volumevendido.Value;
                volumediferenca.Value = encerranteabertura.Value + volumevendido.Value - encerrantefechamento.Value;
            }
        }

        private void bb_fechamento_Click(object sender, EventArgs e)
        {
            if ((!string.IsNullOrEmpty(CD_Empresa.Text)) &&
                (!string.IsNullOrEmpty(id_bico.Text)) &&
                (dt_encerrante.Text.Trim() != "/  /"))
            {
                //Buscar encerrante de fechamento
                CamadaDados.PostoCombustivel.TList_EncerranteBico lEnc =
                    new CamadaDados.PostoCombustivel.TCD_EncerranteBico().Select(
                        new Utils.TpBusca[]
                        {
                            new Utils.TpBusca()
                            {
                                vNM_Campo = "a.id_bico",
                                vOperador = "=",
                                vVL_Busca = id_bico.Text
                            },
                            new Utils.TpBusca()
                            {
                                vNM_Campo = string.Empty,
                                vOperador = string.Empty,
                                vVL_Busca = "((a.tp_encerrante = 'F' and " +
                                            "convert(datetime, floor(convert(numeric(30,10), a.dt_encerrante))) = '" + dt_encerrante.Data.ToString("yyyyMMdd") + "') or " +
                                            "(a.tp_encerrante = 'A' and " +
                                            "convert(datetime, floor(convert(numeric(30,10), a.dt_encerrante))) = '" + dt_encerrante.Data.AddDays(1).ToString("yyyyMMdd") + "'))"
                            }
                        }, 1, string.Empty);
                string msg = string.Empty;
                if (lEnc.Count > 0)
                {
                    lEnc[0].Qtd_encerrante = encerrantefechamento.Value;
                    msg = "alterado";
                }
                else
                {
                    lEnc.Add(new CamadaDados.PostoCombustivel.TRegistro_EncerranteBico()
                    {
                        Id_bicostr = id_bico.Text,
                        Dt_encerrante = Tp_encerrante.Trim().ToUpper().Equals("A") ? dt_encerrante.Data.AddDays(1) : dt_encerrante.Data,
                        Tp_encerrante = Tp_encerrante.Trim().ToUpper().Equals("A") ? "A" : "F",
                        Qtd_encerrante = encerrantefechamento.Value
                    });
                    msg = "incluido";
                }
                try
                {
                    CamadaNegocio.PostoCombustivel.TCN_EncerranteBico.Gravar(lEnc[0], null);
                    MessageBox.Show("Encerrante " + msg.Trim() + " com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            }
        }

        private void bb_abertura_Click(object sender, EventArgs e)
        {
            if ((!string.IsNullOrEmpty(CD_Empresa.Text)) &&
                (!string.IsNullOrEmpty(id_bico.Text)) &&
                (dt_encerrante.Text.Trim() != "/  /"))
            {
                //Buscar encerrante de fechamento
                CamadaDados.PostoCombustivel.TList_EncerranteBico lEnc =
                    new CamadaDados.PostoCombustivel.TCD_EncerranteBico().Select(
                        new Utils.TpBusca[]
                        {
                            new Utils.TpBusca()
                            {
                                vNM_Campo = "a.id_bico",
                                vOperador = "=",
                                vVL_Busca = id_bico.Text
                            },
                            new Utils.TpBusca()
                            {
                                vNM_Campo = string.Empty,
                                vOperador = string.Empty,
                                vVL_Busca = "((a.tp_encerrante = 'A' and " +
                                            "convert(datetime, floor(convert(numeric(30,10), a.dt_encerrante))) = '" + dt_encerrante.Data.ToString("yyyyMMdd") + "') or " +
                                            "(a.tp_encerrante = 'F' and " +
                                            "convert(datetime, floor(convert(numeric(30,10), a.dt_encerrante))) = '" + dt_encerrante.Data.AddDays(-1).ToString("yyyyMMdd") + "'))"
                            }
                        }, 1, string.Empty);
                string msg = string.Empty;
                if (lEnc.Count > 0)
                {
                    lEnc[0].Qtd_encerrante = encerrantefechamento.Value;
                    msg = "alterado";
                }
                else
                {
                    lEnc.Add(new CamadaDados.PostoCombustivel.TRegistro_EncerranteBico()
                    {
                        Id_bicostr = id_bico.Text,
                        Dt_encerrante = Tp_encerrante.Trim().ToUpper().Equals("F") ? dt_encerrante.Data.AddDays(-1) : dt_encerrante.Data,
                        Tp_encerrante = Tp_encerrante.Trim().ToUpper().Equals("F") ? "F" : "A",
                        Qtd_encerrante = encerrantefechamento.Value
                    });
                    msg = "incluido";
                }
                try
                {
                    CamadaNegocio.PostoCombustivel.TCN_EncerranteBico.Gravar(lEnc[0], null);
                    MessageBox.Show("Encerrante " + msg.Trim() + " com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            }
        }

        private void bb_processarDiferenca_Click(object sender, EventArgs e)
        {
            if ((!string.IsNullOrEmpty(CD_Empresa.Text)) &&
                (!string.IsNullOrEmpty(id_bico.Text)) &&
                (dt_encerrante.Text.Trim() != "/  /"))
            {
                if (volumediferenca.Value.Equals(decimal.Zero))
                {
                    MessageBox.Show("Não existe diferença para processar.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if(volumediferenca.Value > decimal.Zero)
                {
                    MessageBox.Show("Para acertar diferença positiva deve se recalcular o encerrante de abertura ou de encerramento.", 
                                    "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (MessageBox.Show("Confirma lancamento de abastecida com o valor da diferença?",
                    "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                    == DialogResult.Yes)
                    try
                    {
                        //Buscar valor unitario
                        object obj_unit = new CamadaDados.PostoCombustivel.TCD_VendaCombustivel().BuscarEscalar(
                                            new Utils.TpBusca[]
                                            {
                                                new Utils.TpBusca()
                                                {
                                                    vNM_Campo = "a.cd_empresa",
                                                    vOperador = "=",
                                                    vVL_Busca = "'" + CD_Empresa.Text.Trim() + "'"
                                                },
                                                new Utils.TpBusca()
                                                {
                                                    vNM_Campo = "a.id_bico",
                                                    vOperador = "=",
                                                    vVL_Busca = id_bico.Text
                                                }
                                            }, "a.vl_unitario", string.Empty, "a.dt_abastecimento desc", null);
                        CamadaNegocio.PostoCombustivel.TCN_VendaCombustivel.Gravar(
                            new CamadaDados.PostoCombustivel.TRegistro_VendaCombustivel()
                            {
                                Cd_empresa = CD_Empresa.Text,
                                Id_bicostr = id_bico.Text,
                                Volumeabastecido = Math.Abs(volumediferenca.Value),
                                Vl_unitario = decimal.Parse(obj_unit.ToString()),
                                Vl_subtotal = volumediferenca.Value * decimal.Parse(obj_unit.ToString()),
                                Dt_abastecimento = dt_encerrante.Data,
                                St_afericao = "N",
                                Tp_registro = "M",
                                St_registro = "A"
                            }, null);
                        MessageBox.Show("Venda combustivel gravada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }
    }
}
