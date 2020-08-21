using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Utils;
using FormBusca;
using CamadaDados.Faturamento.ProgEspecialVenda;
using System.Collections.Generic;
using CamadaNegocio.Servicos;
using CamadaDados.Locacao.Cadastros;

namespace Locacao
{
    public partial class TFLanLocacao : Form
    {
        public bool Altera_Relatorio = false;
        private bool st_locacao
        { get; set; }
        private bool st_cancelar
        { get; set; }
        private bool st_imprimir
        { get; set; }
        private bool st_contrato
        { get; set; }
        private bool st_entregar
        { get; set; }
        private bool st_devolver
        { get; set; }
        private bool st_faturar
        { get; set; }
        private bool st_finalizar
        { get; set; }
        private string CodBarras
        { get; set; }
        private bool m_BackSpace = false;
        private TRegistro_CFGLocacao rCfg;

        private CamadaDados.Faturamento.Cadastros.TList_CFGCupomFiscal lCfg
        { get; set; }
        public TFLanLocacao()
        {
            InitializeComponent();
            //FRETE
            System.Collections.ArrayList cbx = new System.Collections.ArrayList();
            cbx.Add(new TDataCombo("TODOS", string.Empty));
            cbx.Add(new TDataCombo("EMPRESA", "E"));
            cbx.Add(new TDataCombo("CLIENTE", "C"));

            tp_frete.DataSource = cbx;
            tp_frete.ValueMember = "Value";
            tp_frete.DisplayMember = "Display";
        }

        private void LimparCampos()
        {
            Cd_empresa.Text = string.Empty;
            cd_vendedor.Text = string.Empty;
            Cd_clifor.Text = string.Empty;
            Id_locacao.Text = string.Empty;
            id_tabela.Text = string.Empty;
            CD_Grupo.Text = string.Empty;
            dt_ini.Text = string.Empty;
            dt_fin.Text = string.Empty;
            Nr_patrimonio.Text = string.Empty;
            Nr_contrato.Text = string.Empty;
            tp_frete.SelectedIndex = 0;
            cbAguardandoEntrega.Checked = false;
            cbAguardandoFat.Checked = false;
            cbCancelado.Checked = false;
            cbDevolvido.Checked = false;
            cbDevParcial.Checked = false;
            cbDisponivelColeta.Checked = false;
            cbEmColeta.Checked = false;
            cbEmEntrega.Checked = false;
            cbEntregue.Checked = false;
            cbFechamentoParcial.Checked = false;
        }

        private void afterBusca()
        {
            int position = bsLocacao.Position;
            string status = string.Empty;
            string virg = string.Empty;
            if (cbAguardandoEntrega.Checked)
            {
                status = "'0'";
                virg = ",";
            }
            if (cbEmEntrega.Checked)
            {
                status += virg + "'1'";
                virg = ",";
            }
            if (cbEntregue.Checked)
            {
                status += virg + "'2'";
                virg = ",";
            }
            if (cbDisponivelColeta.Checked)
            {
                status += virg + "'3'";
                virg = ",";
            }
            if (cbEmColeta.Checked)
            {
                status += virg + "'4'";
                virg = ",";
            }
            if (cbFechamentoParcial.Checked)
            {
                status += virg + "'6'";
                virg = ",";
            }
            if (cbDevolvido.Checked)
            {
                status += virg + "'7'";
                virg = ",";
            }
            if (cbCancelado.Checked)
            {
                status += virg + "'8'";
                virg = ",";
            }
            if (cbAguardandoFat.Checked)
            {
                status += virg + "'9'";
                virg = ",";
            }
            if (cbDevParcial.Checked)
            {
                status += virg + "'10'";
                virg = ",";
            }
            bsLocacao.DataSource = CamadaNegocio.Locacao.TCN_Locacao.buscar(Cd_empresa.Text,
                                                                            Id_locacao.Text,
                                                                            Nr_contrato.Text,
                                                                            Cd_clifor.Text,
                                                                            cd_vendedor.Text,
                                                                            Nr_patrimonio.Text,
                                                                            id_tabela.Text,
                                                                            CD_Grupo.Text,
                                                                            id_venda.Text,
                                                                            tp_frete.SelectedValue.ToString(),
                                                                            rbDtLocacao.Checked ? "L" : rdDtRetirada.Checked ? "R" :
                                                                            rbDtPrevDev.Checked ? "P" : rbDevolucao.Checked ? "D" : string.Empty,
                                                                            dt_ini.Text,
                                                                            dt_fin.Text,
                                                                            status,
                                                                            "a.dt_prevdev",
                                                                            null);

            bsLocacao_PositionChanged(this, new EventArgs());
            bsLocacao.Position = position;
        }

        private void afterNovo()
        {
            using (TFLocacao fLocacao = new TFLocacao())
            {
                fLocacao.ShowDialog();
            }
        }

        private void afterEntrega()
        {
            if (bsLocacao.Current == null)
                return;

            LimparCampos();
            Id_locacao.Text = (bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).Id_locacaostr;
            afterBusca();
            if ((bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).St_registro.Trim().ToUpper().Equals("8"))//Cancelada
            {
                MessageBox.Show("Não é possivel entregar locação CANCELADA!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            //Verificar se existe VL.Entrada em Aberto
            if (new CamadaDados.Financeiro.Adiantamento.TCD_LanAdiantamento().BuscarEscalar(
                    new TpBusca[]
                    {
                            new TpBusca()
                            {
                                vNM_Campo = string.Empty,
                                vOperador = "exists",
                                vVL_Busca = "(select 1 from TB_LOC_AdtoLocacao x " +
                                            "where a.id_adto = x.id_adto " +
                                            "and x.id_locacao = " + (bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).Id_locacaostr + ") "
                            },
                            new TpBusca()
                            {
                                vNM_Campo = string.Empty,
                                vOperador = string.Empty,
                                vVL_Busca = "(a.vl_adto > (select case when a.tp_movimento = 'C' then isNull(sum(isNull(y.vl_pagar,0)),0)" +
                                                      " else isNull(sum(isNull(y.vl_receber,0)),0) end " +
                                                      " from tb_fin_adiantamento_x_caixa x " +
                                                      "	inner join tb_fin_caixa y " +
                                                      " on x.cd_lanctocaixa = y.cd_lanctocaixa " +
                                                      " and x.cd_contager = y.cd_contager " +
                                                      " where (a.id_adto = x.id_adto) " +
                                                      " and (isNull(y.st_estorno, 'N') = 'N'))) "
                            }
                    }, "1") != null)
            {
                MessageBox.Show("Existe VL.Entrada em ABERTO!\r\n" +
                               "Entre em contato com o financeiro para regularizar a situação!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if ((bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).St_registro.Equals("0"))//Aguardando Entrega
            {
                if ((bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).Tp_frete.Trim().ToUpper().Equals("E"))//Empresa
                {
                    if (new CamadaDados.Locacao.TCD_ItensLocacao().BuscarEscalar(
                        new TpBusca[]
                        {
                                new TpBusca()
                                {
                                    vNM_Campo = "a.cd_empresa",
                                    vOperador = "=",
                                    vVL_Busca = "'" + (bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).Cd_empresa.Trim() + "'"
                                },
                                new TpBusca()
                                {
                                    vNM_Campo = "a.id_locacao",
                                    vOperador = "=",
                                    vVL_Busca = (bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).Id_locacaostr
                                },
                                new TpBusca()
                                {
                                    vNM_Campo = "a.dt_retirada",
                                    vOperador = "is",
                                    vVL_Busca = "null"
                                }
                        }, "1") != null)
                    {
                        using (TFExpedicao fExpedicao = new TFExpedicao())
                        {
                            fExpedicao.pTp_Mov = "E";
                            fExpedicao.rLoc = bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao;
                            if (fExpedicao.ShowDialog() == DialogResult.Cancel)
                            {
                                return;
                            }
                            LimparCampos();
                            Id_locacao.Text = (bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).Id_locacaostr;
                            (bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).St_registro = "1";//Em Entrega
                            CamadaNegocio.Locacao.TCN_Locacao.Gravar((bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao), null);
                            afterBusca();
                        }
                    }
                    else
                        MessageBox.Show("Todos os itens da locação já foram entregues!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else//Cliente
                {
                    //Validar se existe itens para expedir
                    if (new CamadaDados.Locacao.TCD_ItensLocacao().BuscarEscalar(
                        new TpBusca[]
                        {
                            new TpBusca()
                            {
                                vNM_Campo = "a.cd_empresa",
                                vOperador = "=",
                                vVL_Busca = "'" + (bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).Cd_empresa.Trim() + "'"
                            },
                            new TpBusca()
                            {
                                vNM_Campo = "a.id_locacao",
                                vOperador = "=",
                                vVL_Busca = (bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).Id_locacaostr
                            },
                            new TpBusca()
                            {
                                vNM_Campo = "a.dt_retirada",
                                vOperador = "is",
                                vVL_Busca = "null"
                            }
                        }, "1") != null)
                    {
                        using (TFExpedicao fExpedicao = new TFExpedicao())
                        {
                            fExpedicao.pTp_Mov = "E";
                            fExpedicao.rLoc = bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao;
                            if (fExpedicao.ShowDialog() == DialogResult.Cancel)
                            {
                                return;
                            }
                            (bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).St_registro = "2";//Entregue
                            CamadaNegocio.Locacao.TCN_Locacao.Gravar(bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao, null);
                            LimparCampos();
                            Id_locacao.Text = (bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).Id_locacaostr;
                            afterBusca();
                        }
                    }
                    else
                        MessageBox.Show("Todos os itens da locação já foram entregues!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else if ((bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).St_registro.Equals("1"))//Em entrega
            {
                CamadaDados.Locacao.TList_ColetaEntrega lColEnt =
                    new CamadaDados.Locacao.TCD_ColetaEntrega().Select(
                        new TpBusca[]
                        {
                                new TpBusca()
                                {
                                    vNM_Campo = string.Empty,
                                    vOperador = "exists",
                                    vVL_Busca = "(SELECT 1 from TB_LOC_Vistoria_X_ColEnt x " +
                                                "where x.CD_Empresa = a.CD_Empresa " +
                                                "and x.ID_Coleta = a.ID_Coleta " +
                                                "and x.CD_Empresa = '" + (bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).Cd_empresa.Trim() + "' " +
                                                "and x.ID_Locacao = " + (bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).Id_locacaostr + " " +
                                                "and a.TP_Mov = 'E' " +
                                                "and a.DT_RETORNO is null) "
                                }
                        }, 1, string.Empty);
                if (lColEnt.Count > 0)
                {
                    //Validar motorista por cracha
                    using (Proc_Commoditties.TFLeitorCodBarras fCodBarras = new Proc_Commoditties.TFLeitorCodBarras())
                    {
                        object cdMotorista = null;
                        TpBusca[] tpBuscas = new TpBusca[0];
                        Estruturas.CriarParametro(ref tpBuscas, string.Empty, "(select 1 from TB_LOC_Vistoria_X_ColEnt x " +
                                                                                       "where a.cd_empresa = x.cd_empresa " +
                                                                                         "and a.ID_Coleta = x.ID_Coleta " +
                                                                                         "and x.cd_empresa = '" + (bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).Cd_empresa.Trim() + "'" +
                                                                                         "and x.id_locacao = " + (bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).Id_locacaostr + ") ", Operador: "exists");
                        Estruturas.CriarParametro(ref tpBuscas, "a.tp_mov", "'E'");
                        cdMotorista = new CamadaDados.Locacao.TCD_ColetaEntrega().BuscarEscalar(tpBuscas, "a.cd_motorista");
                        if (cdMotorista == null || string.IsNullOrEmpty(cdMotorista.ToString()))
                        {
                            MessageBox.Show("Não foi localizado o motorista para a locação selecionada.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        if (fCodBarras.ShowDialog() == DialogResult.OK)
                        {

                            if (fCodBarras.Leitura.Trim().Equals(cdMotorista.ToString()))
                            {
                                lColEnt[0].Dt_retorno = CamadaDados.UtilData.Data_Servidor();
                                CamadaNegocio.Locacao.TCN_Locacao.ConfirmarEntrega(bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao, lColEnt[0], null);
                                LimparCampos();
                                Id_locacao.Text = (bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).Id_locacaostr;
                                afterBusca();
                            }
                        }
                        else
                        {
                            using (Parametros.Diversos.TFUsuarioSistema fUsuMotorista = new Parametros.Diversos.TFUsuarioSistema())
                            {
                                fUsuMotorista.Titulo = "LOGIN DO MOTORISTA";
                                if (fUsuMotorista.ShowDialog() == DialogResult.OK)
                                {
                                    //Buscar código do usuário informado
                                    object obj = new CamadaDados.Financeiro.Cadastros.TCD_CadClifor().BuscarEscalar(
                                        new TpBusca[]
                                        {
                                                new TpBusca()
                                                {
                                                    vNM_Campo = "a.loginvendedor",
                                                    vOperador = "=",
                                                    vVL_Busca = "'" + fUsuMotorista.Login.Trim() + "'"
                                                }
                                        }, "a.cd_clifor");
                                    if (obj == null || string.IsNullOrEmpty(obj.ToString()))
                                    {
                                        MessageBox.Show("Não foi possível obter o login de vendedor, certifique-se que o motorista tenha pré-cadastrado.");
                                        return;
                                    }

                                    if (obj.ToString().Equals(cdMotorista.ToString()))
                                    {
                                        lColEnt[0].Dt_retorno = CamadaDados.UtilData.Data_Servidor();
                                        CamadaNegocio.Locacao.TCN_Locacao.ConfirmarEntrega(bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao, lColEnt[0], null);
                                        LimparCampos();
                                        Id_locacao.Text = (bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).Id_locacaostr;
                                        afterBusca();
                                    }
                                    else
                                    {
                                        MessageBox.Show("O motorista informado não condiz com o explícito anteriormente.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        return;
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Obrigatório informar login/senha do motorista.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    return;
                                }
                            }
                        }
                    }
                }
            }
        }

        private void afterDevolucao()
        {
            if (bsLocacao.Current != null)
            {
                LimparCampos();
                Id_locacao.Text = (bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).Id_locacaostr;
                afterBusca();

                if (!(bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).St_registro.Equals("2") &&
                    !(bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).St_registro.Equals("3") &&
                    !(bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).St_registro.Equals("4") &&
                    !(bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).St_registro.Equals("6") &&
                    !(bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).St_registro.Equals("10"))
                {
                    MessageBox.Show("Permitido devolver somente locação com status ENTREGUE, DISPONIVEL PARA COLETA ou EM COLETA!",
                        "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if ((bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).Dt_locacao > CamadaDados.UtilData.Data_Servidor())
                {
                    MessageBox.Show("Data devolução não pode ser menor que data de locação!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if ((bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).St_registro.Trim().ToUpper().Equals("3"))//Disponivel para coletar
                {
                    if (MessageBox.Show("Confirma a DEVOLUÇÃO da locação Nº" + (bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).Id_locacaostr + "?",
                            "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                        using (TFInformarVeiculo fInforme = new TFInformarVeiculo())
                        {
                            CamadaDados.Locacao.TRegistro_ColetaEntrega val = new CamadaDados.Locacao.TRegistro_ColetaEntrega();
                            val.Cd_empresa = (bsItens.Current as CamadaDados.Locacao.TRegistro_ItensLocacao).Cd_empresa;
                            val.Tp_mov = "C";
                            val.Ds_obs = fInforme.pObs;
                            val.Dt_colent = CamadaDados.UtilData.Data_Servidor();
                            (bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).lItens.ForEach(p =>
                            val.lVistoria.Add(new CamadaDados.Locacao.TRegistro_Vistoria()
                            {
                                Cd_empresa = p.Cd_empresa,
                                Id_locacao = p.Id_locacao,
                                Id_itemloc = p.Id_itemloc,
                                Login = Utils.Parametros.pubLogin,
                                Id_osstr = p.Id_os,
                                Tp_mov = "E",
                                Dt_vistoria = CamadaDados.UtilData.Data_Servidor(),
                                St_registro = "F"
                            }));
                            fInforme.Cd_empresa = (bsItens.Current as CamadaDados.Locacao.TRegistro_ItensLocacao).Cd_empresa;
                            fInforme.IdLocacao = (bsItens.Current as CamadaDados.Locacao.TRegistro_ItensLocacao).Id_locacaostr;
                            //Se a empresa for devolver
                            if (fInforme.ShowDialog() == DialogResult.OK)
                            {
                                val.Id_veiculostr = fInforme.pId_veiculo;
                                val.Cd_motorista = fInforme.pCd_motorista;
                                (bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).St_registro = "4";//Em coleta
                                CamadaNegocio.Locacao.TCN_Locacao.Gravar((bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao), null);
                            }
                            else
                            {
                                MessageBox.Show("Obrigatório informar veículo e entregador!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                            try
                            {
                                CamadaNegocio.Locacao.TCN_ColetaEntrega.GravarColEnt(val, null);
                                LimparCampos();
                                Id_locacao.Text = (bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).Id_locacaostr;
                                afterBusca();
                            }
                            catch (Exception ex)
                            { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                        }
                }
                else if ((bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).St_registro.Equals("4"))//Em Coleta
                {
                    //Validar motorista por cracha 
                    TpBusca[] tpBuscas = new TpBusca[0];
                    Estruturas.CriarParametro(ref tpBuscas, "", "(select 1 " +
                        "from TB_LOC_Vistoria b " +
                        "where a.CD_Empresa = b.CD_Empresa " +
                        "and a.ID_Locacao = b.ID_Locacao " +
                        "and a.id_itemloc = b.id_itemloc " +
                        "and a.ID_Vistoria = b.ID_Vistoria " +
                        "and b.tp_mov = 'E') ", "exists");
                    Estruturas.CriarParametro(ref tpBuscas, "a.id_locacao", (bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).Id_locacaostr);
                    Estruturas.CriarParametro(ref tpBuscas, "a.cd_empresa", (bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).Cd_empresa);
                    object vId_coleta = new CamadaDados.Locacao.TCD_Vistoria_X_ColEnt().BuscarEscalar(tpBuscas, "max(a.id_coleta)");
                    if (vId_coleta == null || string.IsNullOrEmpty(vId_coleta.ToString()))
                    {
                        MessageBox.Show("Erro ao localizar a vistoria com status de coleta. Não será possível finalizar a operação.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    tpBuscas = new TpBusca[0];
                    Estruturas.CriarParametro(ref tpBuscas, "a.cd_empresa", (bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).Cd_empresa);
                    Estruturas.CriarParametro(ref tpBuscas, "a.id_coleta", vId_coleta.ToString());
                    object vCd_motorista = new CamadaDados.Locacao.TCD_ColetaEntrega().BuscarEscalar(tpBuscas, "a.cd_motorista");
                    if (vCd_motorista == null || string.IsNullOrEmpty(vCd_motorista.ToString()))
                    {
                        MessageBox.Show("Erro ao localizar o motorista da coleta "+ vId_coleta.ToString() + ". Não será possível finalizar a operação.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    string x = vCd_motorista.ToString();

                    using (Proc_Commoditties.TFLeitorCodBarras fCodBarras = new Proc_Commoditties.TFLeitorCodBarras())
                    {
                        if (fCodBarras.ShowDialog() == DialogResult.OK)
                        {

                            if (fCodBarras.Leitura.Trim().Equals(x))
                                ConfirmarDev();
                        }
                        else
                        {
                            using (Parametros.Diversos.TFUsuarioSistema fUsuMotorista = new Parametros.Diversos.TFUsuarioSistema())
                            {
                                fUsuMotorista.Titulo = "LOGIN DO MOTORISTA";
                                if (fUsuMotorista.ShowDialog() == DialogResult.OK)
                                {
                                    //Buscar código do usuário informado
                                    object obj = new CamadaDados.Financeiro.Cadastros.TCD_CadClifor().BuscarEscalar(
                                        new Utils.TpBusca[]
                                        {
                                                new Utils.TpBusca()
                                                {
                                                    vNM_Campo = "a.loginvendedor",
                                                    vOperador = "=",
                                                    vVL_Busca = "'" + fUsuMotorista.Login.Trim() + "'"
                                                }
                                        }, "a.cd_clifor");
                                    if (obj == null || string.IsNullOrEmpty(obj.ToString()))
                                    {
                                        MessageBox.Show("Não foi possível obter o login de vendedor, certifique-se que o motorista tenha pré-cadastrado.");
                                        return;
                                    }

                                    if (obj.ToString().Equals(x))
                                        ConfirmarDev();
                                    else
                                    {
                                        MessageBox.Show("O motorista informado não condiz com o explícito anteriormente.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        return;
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Obrigatório informar login/senha do motorista.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    return;
                                }
                            }
                        }
                    }
                }
                else
                    ConfirmarDev();
            }
        }

        private void ConfirmarDev()
        {
            if (bsLocacao.Current != null)
            {
                if (new CamadaDados.Locacao.TCD_ItensLocacao().BuscarEscalar(
                       new TpBusca[]
                    {
                        new TpBusca()
                        {
                            vNM_Campo = "a.cd_empresa",
                            vOperador = "=",
                            vVL_Busca = "'" + (bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).Cd_empresa.Trim() + "'"
                        },
                        new TpBusca()
                        {
                            vNM_Campo = "a.id_locacao",
                            vOperador = "=",
                            vVL_Busca = (bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).Id_locacaostr
                        },
                        new TpBusca()
                        {
                            vNM_Campo = "a.dt_devolucao",
                            vOperador = "is",
                            vVL_Busca = "null or ((isnull(a.qtditem - a.Qtd_devolvida, 0) > 0)) "
                        }
                    }, "1") != null)
                {
                    using (TFExpedicao fExpedicao = new TFExpedicao())
                    {
                        CamadaDados.Locacao.TList_ColetaEntrega lColEnt =
                                        new CamadaDados.Locacao.TCD_ColetaEntrega().Select(
                                            new TpBusca[]
                                            {
                                                new TpBusca()
                                                {
                                                    vNM_Campo = string.Empty,
                                                    vOperador = "exists",
                                                    vVL_Busca = "(SELECT 1 from TB_LOC_Vistoria_X_ColEnt x " +
                                                                "where x.CD_Empresa = a.CD_Empresa " +
                                                                "and x.ID_Coleta = a.ID_Coleta " +
                                                                "and x.CD_Empresa = '" + (bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).Cd_empresa.Trim() + "' " +
                                                                "and x.ID_Locacao = " + (bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).Id_locacaostr + " " +
                                                                "and a.TP_Mov = 'C' " +
                                                                "and a.DT_RETORNO is null) "
                                                }
                                            }, 1, string.Empty);
                        if (lColEnt.Count > 0)
                        {
                            fExpedicao.rColEnt = lColEnt[0];
                            fExpedicao.rColEnt.Dt_retorno = CamadaDados.UtilData.Data_Servidor();
                            fExpedicao.rColEnt.lVistoria =
                                new CamadaDados.Locacao.TCD_Vistoria().Select(
                                    new TpBusca[]
                                        {
                                            new TpBusca()
                                            {
                                                vNM_Campo = "a.cd_empresa",
                                                vOperador = "=",
                                                vVL_Busca = "'" + (bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).Cd_empresa.Trim() + "'"
                                            },
                                            new TpBusca()
                                            {
                                                vNM_Campo = "a.id_locacao",
                                                vOperador = "=",
                                                vVL_Busca = (bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).Id_locacaostr
                                            }
                                        }, 0, string.Empty);
                        }
                        fExpedicao.pTp_Mov = "C";
                        fExpedicao.rLoc = bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao;
                        fExpedicao.ShowDialog();
                        bsLocacao.ResetCurrentItem();
                        LimparCampos();
                        Id_locacao.Text = (bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).Id_locacaostr;
                        afterBusca();
                    }
                }
                else
                    MessageBox.Show("Todos os itens da locação já foram devolvidos!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void afterCancela()
        {
            if (bsLocacao.Current != null)
            {
                if (!st_cancelar)
                    using (Parametros.Diversos.TFRegraUsuario fRegra = new Parametros.Diversos.TFRegraUsuario())
                    {
                        fRegra.Ds_regraespecial = "PERMITIR CANCELAR LOCAÇÃO";
                        fRegra.Login = Utils.Parametros.pubLogin;
                        if (fRegra.ShowDialog() != DialogResult.OK)
                            return;
                    }
                if ((bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).St_registro.ToUpper().Equals("7"))
                {
                    MessageBox.Show("Não é possivel cancelar locação com itens devolvidos!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if ((bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).Vl_faturado > 0)
                {
                    MessageBox.Show("Não é possivel cancelar locação faturada!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (MessageBox.Show("Confirma exclusão da Locacao selecionada?", "Pergunta", MessageBoxButtons.YesNo,
                     MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    try
                    {
                        InputBox ibp = new InputBox();
                        ibp.Text = "Motivo Cancelamento Locação";
                        string motivo = ibp.ShowDialog();
                        if (string.IsNullOrEmpty(motivo))
                        {
                            MessageBox.Show("Obrigatorio informar motivo de cancelamento da locação!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        if (motivo.Trim().Length < 10)
                        {
                            MessageBox.Show("Motivo de cancelamento deve ter mais que 10 caracteres!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        (bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).MotivoCancelamento = motivo;
                        CamadaNegocio.Locacao.TCN_Locacao.Excluir(bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao, null);
                        MessageBox.Show("Locação CANCELADA com sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        afterBusca();
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void BuscarProduto(CamadaDados.Servicos.TRegistro_LanServico rOs)
        {
            TpBusca[] filtro = new TpBusca[1];
            filtro[0].vNM_Campo = "a.cd_grupo";
            filtro[0].vOperador = "=";
            filtro[0].vVL_Busca = "'" + (bsItens.Current as CamadaDados.Locacao.TRegistro_ItensLocacao).Cd_grupo.Trim() + "'";
            //Verificar se item controla quantidade
            List<CamadaDados.Estoque.Cadastros.TRegistro_ProdutoLocacao> lProd =
            CamadaNegocio.Estoque.Cadastros.TCN_CadProduto.BuscarProdutoLocacao((bsItens.Current as CamadaDados.Locacao.TRegistro_ItensLocacao).Cd_produto,
                                                                                string.Empty,
                                                                                (bsItens.Current as CamadaDados.Locacao.TRegistro_ItensLocacao).Cd_empresa,
                                                                                true,
                                                                                string.Empty,
                                                                                null);
            if (lProd.Count.Equals(0) ? true : lProd[0].Quantidade.Equals(decimal.Zero))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = string.Empty;
                filtro[filtro.Length - 1].vOperador = "not exists";
                filtro[filtro.Length - 1].vVL_Busca = "(SELECT 1 FROM VTB_LOC_ItensLocacao x " +
                                       "inner join TB_LOC_Locacao loc " +
                                       "on x.cd_empresa = loc.cd_empresa " +
                                       "and x.id_locacao = loc.id_locacao " +
                                       "and isnull(x.st_registro, 'A') <> 'C' " +
                                       "and (isnull(loc.st_registro, '0') not in('7', '8')) " +//Diferente de devolvido e cancelado
                                       "where a.cd_produto = x.cd_produto " +
                                       "and isnull(x.DT_Retirada, loc.DT_Locacao) <= '" + (bsItens.Current as CamadaDados.Locacao.TRegistro_ItensLocacao).Dt_prevdev.Value.ToString("yyyyMMdd HH:mm:ss") +
                                       "' and isnull(x.dt_prevdev, x.dt_devolucao) >= '" + ((bsItens.Current as CamadaDados.Locacao.TRegistro_ItensLocacao).Dt_retirada.HasValue ?
                                       (bsItens.Current as CamadaDados.Locacao.TRegistro_ItensLocacao).Dt_retirada.Value.ToString("yyyyMMdd HH:mm:ss") :
                                       (bsItens.Current as CamadaDados.Locacao.TRegistro_ItensLocacao).Dt_locacao.Value.ToString("yyyyMMdd HH:mm:ss")) + "')" +
                                       "and not exists(SELECT 1 FROM VTB_OSE_SERVICO y " +
                                       "           where a.cd_produto = y.CD_ProdutoOS " +
                                       "           and(y.DT_Abertura >= GETDATE() " +
                                       "           or ISNULL(y.DT_Finalizada, case when y.dt_previsao < GETDATE() OR y.dt_previsao is null then GETDATE() ELSE y.dt_previsao end) >= GETDATE()) " +
                                       "           and (y.DT_Abertura <= " +
                                       "           case when GETDATE() >= '" +
                                                            Convert.ToDateTime((bsItens.Current as CamadaDados.Locacao.TRegistro_ItensLocacao).Dt_prevdevstr).ToString("yyyyMMdd HH:mm:ss") + "' " +
                                       "                    then GETDATE() ELSE '" + Convert.ToDateTime((bsItens.Current as CamadaDados.Locacao.TRegistro_ItensLocacao).Dt_prevdevstr).ToString("yyyyMMdd HH:mm:ss") + "' end " +
                                       "           or ISNULL(y.DT_Finalizada, case when y.dt_previsao < GETDATE() then GETDATE() ELSE y.dt_previsao end) <= " +
                                       "                    case when GETDATE() >= '" +
                                                            Convert.ToDateTime((bsItens.Current as CamadaDados.Locacao.TRegistro_ItensLocacao).Dt_prevdevstr).ToString("yyyyMMdd HH:mm:ss") + "' " +
                                       "                    then GETDATE() else '" +
                                                            Convert.ToDateTime((bsItens.Current as CamadaDados.Locacao.TRegistro_ItensLocacao).Dt_prevdevstr).ToString("yyyyMMdd HH:mm: ss") + "' end) " +
                                       "and (isnull(y.ST_OS, 'AB') <> 'CA')) ";
            }
            CamadaDados.Estoque.Cadastros.TRegistro_CadProduto rProd = null;
            rProd = UtilPesquisa.BuscarProduto(string.Empty,
                                               string.Empty,
                                               string.Empty,
                                               string.Empty,
                                               null,
                                               filtro);

            if (rProd != null)
            {
                if (lProd.Count.Equals(0) ? false : lProd[0].Quantidade > decimal.Zero)
                {
                    //Buscar Locações em execução no Periodo
                    CamadaDados.Locacao.TList_ItensLocacao lItens =
                    new CamadaDados.Locacao.TCD_ItensLocacao().Select(
                        new TpBusca[]
                        {
                            new TpBusca()
                            {
                                vNM_Campo = "loc.dt_locacao",
                                vOperador = ">=",
                                vVL_Busca = "'" + Convert.ToDateTime((bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).Dt_locacaostr).ToString("yyyyMMdd HH:mm:ss") + "' or " +
                                            "a.DT_PrevDev >= '" + Convert.ToDateTime((bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).Dt_locacaostr).ToString("yyyyMMdd HH:mm:ss") + "' or " +
                                            "a.DT_Retirada >= '" + Convert.ToDateTime((bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).Dt_locacaostr).ToString("yyyyMMdd HH:mm:ss") + "'"
                            },
                            new TpBusca()
                            {
                                vNM_Campo = "loc.dt_locacao",
                                vOperador = "<=",
                                vVL_Busca = "'" + Convert.ToDateTime((bsItens.Current as CamadaDados.Locacao.TRegistro_ItensLocacao).Dt_prevdevstr).ToString("yyyyMMdd HH:mm:ss") + "' or " +
                                            "a.DT_PrevDev <= '" + Convert.ToDateTime((bsItens.Current as CamadaDados.Locacao.TRegistro_ItensLocacao).Dt_prevdevstr).ToString("yyyyMMdd HH:mm:ss") + "' or " +
                                            "a.DT_Retirada <= '" + Convert.ToDateTime((bsItens.Current as CamadaDados.Locacao.TRegistro_ItensLocacao).Dt_prevdevstr).ToString("yyyyMMdd HH:mm:ss") + "'"
                            },
                            new TpBusca()
                            {
                                vNM_Campo = "isnull(loc.st_registro, '0')",
                                vOperador = "<>",
                                vVL_Busca = "'8'"
                            },
                            new TpBusca()
                            {
                                vNM_Campo = "a.cd_produto",
                                vOperador = "=",
                                vVL_Busca = "'" + rProd.CD_Produto.Trim() + "'"
                            }
                        }, 0, string.Empty, false);
                    if (lItens.Count > 0)
                    {
                        foreach (CamadaDados.Locacao.TRegistro_ItensLocacao item in lItens)
                        {
                            //Buscar QTD de Itens Locação em cada devolução
                            if (Convert.ToDateTime((bsItens.Current as CamadaDados.Locacao.TRegistro_ItensLocacao).Dt_prevdevstr) >= item.Dt_prevdev)
                            {
                                object objsaldo =
                                new CamadaDados.Locacao.TCD_ItensLocacao().BuscarEscalar(
                                    new TpBusca[]
                                {
                                        new TpBusca()
                                        {
                                            vNM_Campo = "loc.dt_locacao",
                                            vOperador = "<=",
                                            vVL_Busca = "'" + Convert.ToDateTime(item.Dt_prevdevstr).ToString("yyyyMMdd HH:mm:ss") + "'"
                                        },
                                        new TpBusca()
                                        {
                                            vNM_Campo = "isnull(loc.st_registro, '0')",
                                            vOperador = "<>",
                                            vVL_Busca = "'8'"
                                        },
                                        new TpBusca()
                                        {
                                            vNM_Campo = "a.cd_produto",
                                            vOperador = "=",
                                            vVL_Busca = "'" + rProd.CD_Produto.Trim() + "'"
                                        },
                                         new TpBusca()
                                        {
                                            vNM_Campo = "a.dt_prevdev",
                                            vOperador = ">=",
                                            vVL_Busca = "'" + Convert.ToDateTime(item.Dt_prevdevstr).ToString("yyyyMMdd HH:mm:ss") + "' or a.DT_PrevDev < getdate()"
                                        }
                                }, "isnull(SUM(A.qtditem), 0) ");

                                if (objsaldo != null)
                                {
                                    //Buscar saldo Minimo Periodo
                                    decimal qtd_prod =
                                    CamadaNegocio.Estoque.Cadastros.TCN_CadProduto.BuscarProdutoLocacao(rProd.CD_Produto,
                                                                                                        string.Empty,
                                                                                                        (bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).Cd_empresa,
                                                                                                        true,
                                                                                                        (bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).Dt_locacao.Value.ToString("yyyyMMdd HH:mm:ss"),
                                                                                                        null).FirstOrDefault().Quantidade;
                                    decimal qtd = qtd_prod - decimal.Parse(objsaldo.ToString());
                                    if (qtd < (bsItens.Current as CamadaDados.Locacao.TRegistro_ItensLocacao).QTDItem)
                                    {
                                        MessageBox.Show("Saldo disponivel do patrimonio <" + qtd.ToString("N3", new System.Globalization.CultureInfo("pt-BR", true)) + "> menor que quantidade do item locado.");
                                        return;
                                    }
                                }
                            }
                            else
                            {
                                //se no periodo não existir nenhuma dt_prev de locação calcular saldo pelo dt.prev da locação corrente
                                object objsaldo =
                                new CamadaDados.Locacao.TCD_ItensLocacao().BuscarEscalar(
                                    new TpBusca[]
                                    {
                                            new TpBusca()
                                            {
                                                vNM_Campo = "loc.dt_locacao",
                                                vOperador = "<=",
                                                vVL_Busca = "'" + Convert.ToDateTime((bsItens.Current as CamadaDados.Locacao.TRegistro_ItensLocacao).Dt_prevdevstr).ToString("yyyyMMdd HH:mm:ss") + "'"
                                            },
                                            new TpBusca()
                                            {
                                                vNM_Campo = "isnull(loc.st_registro, '0')",
                                                vOperador = "<>",
                                                vVL_Busca = "'8'"
                                            },
                                            new TpBusca()
                                            {
                                                vNM_Campo = "a.cd_produto",
                                                vOperador = "=",
                                                vVL_Busca = "'" + rProd.CD_Produto.Trim() + "'"
                                            },
                                             new TpBusca()
                                            {
                                                vNM_Campo = "a.dt_prevdev",
                                                vOperador = ">=",
                                                vVL_Busca = "'" + Convert.ToDateTime((bsItens.Current as CamadaDados.Locacao.TRegistro_ItensLocacao).Dt_prevdevstr).ToString("yyyyMMdd HH:mm:ss") + "' or a.DT_PrevDev < getdate()"
                                            }
                                    }, "isnull(SUM(A.qtditem), 0) ");
                                if (objsaldo != null)
                                {
                                    //Buscar saldo Minimo Periodo
                                    decimal qtd_prod =
                                    CamadaNegocio.Estoque.Cadastros.TCN_CadProduto.BuscarProdutoLocacao(rProd.CD_Produto,
                                                                                                        string.Empty,
                                                                                                        (bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).Cd_empresa,
                                                                                                        true,
                                                                                                        (bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).Dt_locacao.Value.ToString("yyyyMMdd HH:mm:ss"),
                                                                                                        null).FirstOrDefault().Quantidade;
                                    decimal qtd = qtd_prod - decimal.Parse(objsaldo.ToString());
                                    if (qtd < (bsItens.Current as CamadaDados.Locacao.TRegistro_ItensLocacao).QTDItem)
                                    {
                                        MessageBox.Show("Saldo disponivel do patrimonio <" + qtd.ToString("N3", new System.Globalization.CultureInfo("pt-BR", true)) + "> menor que quantidade do item locado.");
                                        return;
                                    }
                                }
                            }
                        }
                    }
                }
                //Buscar Preço
                object preco =
                new TCD_CadPrecoItens().BuscarEscalar(
                    new TpBusca[]
                    {
                        new TpBusca()
                        {
                            vNM_Campo = "a.cd_produto",
                            vOperador = "=",
                            vVL_Busca = "'" + rProd.CD_Produto.Trim() + "'"
                        },
                        new TpBusca()
                        {
                            vNM_Campo = "a.ID_Tabela",
                            vOperador = "=",
                            vVL_Busca = (bsItens.Current as CamadaDados.Locacao.TRegistro_ItensLocacao).Id_tabelastr
                        }
                    }, "a.Vl_preco");
                (bsItens.Current as CamadaDados.Locacao.TRegistro_ItensLocacao).rOs = rOs != null ? rOs : null;
                CamadaDados.Locacao.TRegistro_ItensLocacao rItem = new CamadaDados.Locacao.TRegistro_ItensLocacao();
                rItem.Cd_empresa = (bsItens.Current as CamadaDados.Locacao.TRegistro_ItensLocacao).Cd_empresa;
                rItem.Id_locacao = (bsItens.Current as CamadaDados.Locacao.TRegistro_ItensLocacao).Id_locacao;
                rItem.Cd_produto = rProd.CD_Produto;
                rItem.Id_tabela = (bsItens.Current as CamadaDados.Locacao.TRegistro_ItensLocacao).Id_tabela;
                rItem.Quantidade = (bsItens.Current as CamadaDados.Locacao.TRegistro_ItensLocacao).Quantidade;
                rItem.QTDItem = (bsItens.Current as CamadaDados.Locacao.TRegistro_ItensLocacao).QTDItem;
                rItem.Vl_unitario = preco == null || string.IsNullOrEmpty(preco.ToString()) ? (bsItens.Current as CamadaDados.Locacao.TRegistro_ItensLocacao).Vl_unitario : Convert.ToDecimal(preco.ToString());
                rItem.Vl_desconto = (bsItens.Current as CamadaDados.Locacao.TRegistro_ItensLocacao).Vl_desconto;
                rItem.Vl_frete = (bsItens.Current as CamadaDados.Locacao.TRegistro_ItensLocacao).Vl_frete;
                rItem.Dt_retirada = (bsItens.Current as CamadaDados.Locacao.TRegistro_ItensLocacao).Dt_retirada;
                rItem.Dt_prevdev = (bsItens.Current as CamadaDados.Locacao.TRegistro_ItensLocacao).Dt_prevdev;
                rItem.Dt_devolucao = (bsItens.Current as CamadaDados.Locacao.TRegistro_ItensLocacao).Dt_devolucao;
                rItem.Dt_fechamento = (bsItens.Current as CamadaDados.Locacao.TRegistro_ItensLocacao).Dt_fechamento;
                rItem.St_registro = "A";
                //Verificar se patrimonio possui controle de horas
                object obj = new CamadaDados.Estoque.Cadastros.TCD_CadPatrimonio().BuscarEscalar(
                    new TpBusca[]
                    {
                        new TpBusca()
                        {
                            vNM_Campo = "isnull(a.st_controlehora, 'N')",
                            vOperador = "=",
                            vVL_Busca = "'S'"
                        },
                        new TpBusca()
                        {
                             vNM_Campo = "a.CD_Patrimonio",
                            vOperador = "=",
                            vVL_Busca = "'" + rProd.CD_Produto.Trim() + "'"
                        }
                    }, "isnull(a.qtd_horas, 0)");
                if (obj != null)
                {
                    //Informar Quantidade
                    using (Componentes.TFQuantidade fQtde = new Componentes.TFQuantidade())
                    {
                        fQtde.Ds_label = "QTD.Horas";
                        fQtde.Vl_default = Convert.ToDecimal(obj.ToString());
                        if (fQtde.ShowDialog() == DialogResult.OK)
                        {
                            if (fQtde.Quantidade > decimal.Zero)
                            {
                                rItem.St_controlehorabool = true;
                                rItem.Qtd_horasAtual = fQtde.Quantidade;
                                rItem.Qtd_horasRetirada = fQtde.Quantidade;

                                //Informar se item necessita de manutenção preventiva
                                //Buscar ultima data de encerramento ordem de serviço para patrimonio informado
                                TpBusca[] tpBuscas = new TpBusca[0];
                                Estruturas.CriarParametro(ref tpBuscas, "a.CD_ProdutoOS", "'" + (bsItens.Current as CamadaDados.Locacao.TRegistro_ItensLocacao).Cd_produto + "'");
                                Estruturas.CriarParametro(ref tpBuscas, "a.ST_OS", "('FE', 'PR')", "in");
                                object dtEncerramento = new CamadaDados.Servicos.TCD_LanServico().BuscarEscalar(tpBuscas, "MAX(a.DT_Finalizada)");
                                if (dtEncerramento != null && !string.IsNullOrEmpty(dtEncerramento.ToString()))
                                {
                                    tpBuscas = new TpBusca[0];
                                    Estruturas.CriarParametro(ref tpBuscas, "a.NR_Patrimonio", "'" + (bsItens.Current as CamadaDados.Locacao.TRegistro_ItensLocacao).Nr_Patrimonio + "'");
                                    object vl_manuPorHoras = new CamadaDados.Estoque.Cadastros.TCD_CadPatrimonio().BuscarEscalar(tpBuscas, "a.ManutHora");
                                    object vl_manuPorDia = new CamadaDados.Estoque.Cadastros.TCD_CadPatrimonio().BuscarEscalar(tpBuscas, "a.ManutDia");
                                    TimeSpan intervalo = CamadaDados.UtilData.Data_Servidor().Subtract(Convert.ToDateTime(dtEncerramento.ToString()));

                                    bool messege = false;
                                    if (vl_manuPorHoras != null && intervalo.TotalHours > Convert.ToDouble(vl_manuPorHoras))
                                        messege = true;
                                    else if (vl_manuPorDia != null && intervalo.TotalDays > Convert.ToDouble(vl_manuPorDia))
                                        messege = true;

                                    if (messege)
                                    {
                                        MessageBox.Show("O produto de código: " + (bsItens.Current as CamadaDados.Locacao.TRegistro_ItensLocacao).Cd_produto + " \n" +
                                            "Descrição: " + (bsItens.Current as CamadaDados.Locacao.TRegistro_ItensLocacao).Ds_produto + " \n" +
                                            "Necessita de manutenção preventiva.", "Informativo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                        //Validar se patrimônio possui tabela de preço mensal
                                        if ((bsItens.Current as CamadaDados.Locacao.TRegistro_ItensLocacao).Tp_tabela.Equals("4"))
                                        {
                                            using (FLocOrdemServico fNovaOrdem = new FLocOrdemServico())
                                            {
                                                CamadaDados.Servicos.TRegistro_LanServico _LanServico = new CamadaDados.Servicos.TRegistro_LanServico();
                                                _LanServico.Cd_empresa = rCfg.Cd_empresa;
                                                _LanServico.Nm_empresa = rCfg.Nm_empresa;
                                                _LanServico.Tp_ordem = rCfg.Tp_ordemp;
                                                _LanServico.Ds_tipoordem = rCfg.Ds_tipoordem;
                                                _LanServico.CD_ProdutoOS = (bsItens.Current as CamadaDados.Locacao.TRegistro_ItensLocacao).Cd_produto;
                                                _LanServico.DS_ProdutoOS = (bsItens.Current as CamadaDados.Locacao.TRegistro_ItensLocacao).Ds_produto;
                                                _LanServico.Nr_patrimonio = (bsItens.Current as CamadaDados.Locacao.TRegistro_ItensLocacao).Nr_Patrimonio;
                                                _LanServico.Dt_abertura = CamadaDados.UtilData.Data_Servidor();
                                                _LanServico.St_prioridade = "1";
                                                _LanServico.Ds_observacoesgerais = "MANUTENÇÃO PREVENTIVA ITEM PATRIMÔNNIO " + (bsItens.Current as CamadaDados.Locacao.TRegistro_ItensLocacao).Nr_Patrimonio;
                                                _LanServico.St_os = "AB";

                                                //Etapa de abertura
                                                CamadaDados.Servicos.Cadastros.TList_EtapaOrdem lEtapa =
                                                            new CamadaDados.Servicos.Cadastros.TCD_EtapaOrdem().Select(
                                                                new TpBusca[]
                                                                {
                                                                    new TpBusca()
                                                                    {
                                                                        vNM_Campo = "isnull(a.st_iniciarOS, 'N')",
                                                                        vOperador = "=",
                                                                        vVL_Busca = "'S'"
                                                                    },
                                                                    new TpBusca()
                                                                    {
                                                                        vNM_Campo = string.Empty,
                                                                        vOperador = "exists",
                                                                        vVL_Busca = "(select 1 from tb_ose_tpordem_x_etapa x "+
                                                                                    "where x.id_etapa = a.id_etapa "+
                                                                                    "and x.tp_ordem = " + rCfg.Tp_ordemstr + ")"
                                                                    }
                                                                }, 1, string.Empty);
                                                if (lEtapa.Count > 0)
                                                    _LanServico.lEvolucao.Add(
                                                        new CamadaDados.Servicos.TRegistro_LanServicoEvolucao()
                                                        {
                                                            Dt_inicio = _LanServico.Dt_abertura,
                                                            Id_etapa = lEtapa[0].Id_etapa,
                                                            Ds_evolucao = "ETAPA ABERTURA DA OS",
                                                            St_envterceiro = lEtapa[0].St_envterceirobool,
                                                            St_finalizarOS = lEtapa[0].St_finalizarOSbool,
                                                            St_iniciarOS = lEtapa[0].St_iniciarOSbool
                                                        });
                                                else
                                                    throw new Exception("Não existe etapa de ABERTURA configurada para o tipo de ordem " + rCfg.Tp_ordemstr);

                                                fNovaOrdem.lanServico = _LanServico;
                                                if (fNovaOrdem.ShowDialog() == DialogResult.OK)
                                                {
                                                    if (fNovaOrdem.lanServico != null)
                                                    {
                                                        TCN_LanServico.Gravar(fNovaOrdem.lanServico, null);
                                                        MessageBox.Show("Ordem de serviço gerada com sucesso.", "Informativo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                    }
                                                }
                                                else
                                                {
                                                    MessageBox.Show("O produto de código: " + (bsItens.Current as CamadaDados.Locacao.TRegistro_ItensLocacao).Cd_produto + " \n" +
                                                            "Descrição: " + (bsItens.Current as CamadaDados.Locacao.TRegistro_ItensLocacao).Ds_produto + " \n" +
                                                            "O produto possui tabela de preço com cobrança mensal. \n" +
                                                            "É obrigatório gerar manutenção preventiva.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                    return;
                                                }
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    tpBuscas = new TpBusca[0];
                                    Estruturas.CriarParametro(ref tpBuscas, "d.NR_Patrimonio", "'" + (bsItens.Current as CamadaDados.Locacao.TRegistro_ItensLocacao).Nr_Patrimonio + "'");
                                    object qtdHoras = new CamadaDados.Estoque.Cadastros.TCD_CadProduto().BuscarEscalar(tpBuscas, "d.Qtd_horas");
                                    if (qtdHoras != null && !string.IsNullOrEmpty(qtdHoras.ToString()))
                                    {
                                        object vl_manuPorHoras = new CamadaDados.Estoque.Cadastros.TCD_CadPatrimonio().BuscarEscalar(tpBuscas, "a.ManutHora");
                                        object vl_manuPorDia = new CamadaDados.Estoque.Cadastros.TCD_CadPatrimonio().BuscarEscalar(tpBuscas, "a.ManutDia");
                                        decimal intervalo = (bsItens.Current as CamadaDados.Locacao.TRegistro_ItensLocacao).Qtd_horasAtual - Convert.ToDecimal(qtdHoras);

                                        bool messege = false;
                                        if (vl_manuPorHoras != null && intervalo > Convert.ToDecimal(vl_manuPorHoras))
                                            messege = true;
                                        else if (vl_manuPorDia != null && (intervalo / 24) > Convert.ToDecimal(vl_manuPorDia))
                                            messege = true;

                                        if (messege)
                                        {
                                            MessageBox.Show("O produto de código: " + (bsItens.Current as CamadaDados.Locacao.TRegistro_ItensLocacao).Cd_produto + " \n" +
                                                "Descrição: " + (bsItens.Current as CamadaDados.Locacao.TRegistro_ItensLocacao).Ds_produto + " \n" +
                                                "Necessita de manutenção preventiva.", "Informativo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                            //Validar se patrimônio possui tabela de preço mensal
                                            if ((bsItens.Current as CamadaDados.Locacao.TRegistro_ItensLocacao).Tp_tabela.Equals("4"))
                                            {
                                                using (FLocOrdemServico fNovaOrdem = new FLocOrdemServico())
                                                {
                                                    CamadaDados.Servicos.TRegistro_LanServico _LanServico = new CamadaDados.Servicos.TRegistro_LanServico();
                                                    _LanServico.Cd_empresa = rCfg.Cd_empresa;
                                                    _LanServico.Nm_empresa = rCfg.Nm_empresa;
                                                    _LanServico.Tp_ordem = rCfg.Tp_ordemp;
                                                    _LanServico.Ds_tipoordem = rCfg.Ds_tipoordem;
                                                    _LanServico.CD_ProdutoOS = (bsItens.Current as CamadaDados.Locacao.TRegistro_ItensLocacao).Cd_produto;
                                                    _LanServico.DS_ProdutoOS = (bsItens.Current as CamadaDados.Locacao.TRegistro_ItensLocacao).Ds_produto;
                                                    _LanServico.Nr_patrimonio = (bsItens.Current as CamadaDados.Locacao.TRegistro_ItensLocacao).Nr_Patrimonio;
                                                    _LanServico.Dt_abertura = CamadaDados.UtilData.Data_Servidor();
                                                    _LanServico.St_prioridade = "1";
                                                    _LanServico.Ds_observacoesgerais = "MANUTENÇÃO PREVENTIVA ITEM PATRIMÔNNIO " + (bsItens.Current as CamadaDados.Locacao.TRegistro_ItensLocacao).Nr_Patrimonio;
                                                    _LanServico.St_os = "AB";

                                                    //Etapa de abertura
                                                    CamadaDados.Servicos.Cadastros.TList_EtapaOrdem lEtapa =
                                                                new CamadaDados.Servicos.Cadastros.TCD_EtapaOrdem().Select(
                                                                    new TpBusca[]
                                                                    {
                                                                        new TpBusca()
                                                                        {
                                                                            vNM_Campo = "isnull(a.st_iniciarOS, 'N')",
                                                                            vOperador = "=",
                                                                            vVL_Busca = "'S'"
                                                                        },
                                                                        new TpBusca()
                                                                        {
                                                                            vNM_Campo = string.Empty,
                                                                            vOperador = "exists",
                                                                            vVL_Busca = "(select 1 from tb_ose_tpordem_x_etapa x "+
                                                                                        "where x.id_etapa = a.id_etapa "+
                                                                                        "and x.tp_ordem = " + rCfg.Tp_ordemstr + ")"
                                                                        }
                                                            }, 1, string.Empty);
                                                    if (lEtapa.Count > 0)
                                                        _LanServico.lEvolucao.Add(
                                                            new CamadaDados.Servicos.TRegistro_LanServicoEvolucao()
                                                            {
                                                                Dt_inicio = rOs.Dt_abertura,
                                                                Id_etapa = lEtapa[0].Id_etapa,
                                                                Ds_evolucao = "ETAPA ABERTURA DA OS",
                                                                St_envterceiro = lEtapa[0].St_envterceirobool,
                                                                St_finalizarOS = lEtapa[0].St_finalizarOSbool,
                                                                St_iniciarOS = lEtapa[0].St_iniciarOSbool
                                                            });
                                                    else
                                                        throw new Exception("Não existe etapa de ABERTURA configurada para o tipo de ordem " + rCfg.Tp_ordemstr);

                                                    fNovaOrdem.lanServico = _LanServico;
                                                    if (fNovaOrdem.ShowDialog() == DialogResult.OK)
                                                    {
                                                        if (fNovaOrdem.lanServico != null)
                                                        {
                                                            TCN_LanServico.Gravar(fNovaOrdem.lanServico, null);
                                                            MessageBox.Show("Ordem de serviço gerada com sucesso.", "Informativo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                        }
                                                    }
                                                    else
                                                    {
                                                        MessageBox.Show("O produto de código: " + (bsItens.Current as CamadaDados.Locacao.TRegistro_ItensLocacao).Cd_produto + " \n" +
                                                                "Descrição: " + (bsItens.Current as CamadaDados.Locacao.TRegistro_ItensLocacao).Ds_produto + " \n" +
                                                                "O produto possui tabela de preço com cobrança mensal. \n" +
                                                                "É obrigatório gerar manutenção preventiva.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                        return;
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                            else
                            {
                                MessageBox.Show("Obrigatório informar quantidade de horas para patrimônio!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Obrigatório informar quantidade de horas para patrimônio!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }

                    }
                }

                //Excluir acessórios do item trocado
                CamadaDados.Locacao.TList_AcessoriosItem _AcessoriosItems = CamadaNegocio.Locacao.TCN_AcessoriosItem.buscar(
                        (bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).Cd_empresa,
                        (bsItens.Current as CamadaDados.Locacao.TRegistro_ItensLocacao).Id_locacaostr,
                        (bsItens.Current as CamadaDados.Locacao.TRegistro_ItensLocacao).Id_itemlocstr,
                        string.Empty,
                        null);

                //Realizar troca de item
                CamadaNegocio.Locacao.TCN_ItensLocacao.TrocaItem(bsItens.Current as CamadaDados.Locacao.TRegistro_ItensLocacao, rItem, null);
                afterBusca(); //Necessário para atualizar bs com item trocado                             

                //Buscar Produtos no Cadastro Assistente de Venda
                CamadaDados.Estoque.Cadastros.TList_CadAssistenteVenda lAssistente = CamadaNegocio.Estoque.Cadastros.TCN_CadAssistenteVenda.Busca(
                        (bsItens.Current as CamadaDados.Locacao.TRegistro_ItensLocacao).Cd_produto,
                        string.Empty,
                        null);

                string msg = "A troca de item foi efetuada com sucesso! ";
                if (_AcessoriosItems.Count > 0)
                {
                    msg += "O item possui acessórios deseja excluir/ alterar?";
                    if (MessageBox.Show(msg, "Mensagem", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    {
                        if (lAssistente.Count > 0)
                        {
                            using (Faturamento.TFAssistenteVenda fAssistente = new Faturamento.TFAssistenteVenda())
                            {
                                fAssistente.Cd_empresa = (bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).Cd_empresa;
                                fAssistente.Nm_empresa = (bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).Nm_empresa;
                                fAssistente.lAssistente = lAssistente;
                                if (fAssistente.ShowDialog() == DialogResult.OK)
                                {
                                    if (fAssistente.lAssistente.Count > 0)
                                    {
                                        (bsItens.Current as CamadaDados.Locacao.TRegistro_ItensLocacao).lAcessorio.Clear();
                                        _AcessoriosItems.ForEach(r =>
                                        {
                                            CamadaNegocio.Locacao.TCN_AcessoriosItem.Excluir(r, null);
                                        });
                                        fAssistente.lAssistente.ForEach(p =>
                                        {
                                            CamadaDados.Locacao.TRegistro_AcessoriosItem rAcessorios = new CamadaDados.Locacao.TRegistro_AcessoriosItem();
                                            rAcessorios.Cd_produto = p.CD_ProdVenda;
                                            rAcessorios.Ds_produto = p.DS_ProdVenda;
                                            rAcessorios.Quantidade = p.Quantidade;
                                            rAcessorios.Cd_empresa = (bsItens.Current as CamadaDados.Locacao.TRegistro_ItensLocacao).Cd_empresa;
                                            rAcessorios.Id_locacaostr = (bsItens.Current as CamadaDados.Locacao.TRegistro_ItensLocacao).Id_locacaostr;
                                            rAcessorios.Id_itemlocstr = (bsItens.Current as CamadaDados.Locacao.TRegistro_ItensLocacao).Id_itemlocstr;
                                            object objCupom = new CamadaDados.Faturamento.Cadastros.TCD_CFGCupomFiscal().BuscarEscalar(
                                                            new TpBusca[]
                                                            {
                                                                new TpBusca()
                                                                {
                                                                    vNM_Campo = "a.cd_empresa",
                                                                    vOperador = "=",
                                                                    vVL_Busca = "'" + (bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).Cd_empresa.Trim() + "'"
                                                                }
                                                            }, "a.cd_tabelapreco");
                                            if (objCupom != null)
                                            {
                                                //Buscar Vl.Unitário
                                                object vl_precoacessorio = new CamadaDados.Estoque.TCD_LanPrecoItem().BuscarEscalar(
                                                                             new TpBusca[]
                                                                             {
                                                                    new TpBusca()
                                                                    {
                                                                        vNM_Campo = "a.cd_empresa",
                                                                        vOperador = "=",
                                                                        vVL_Busca = "'" + (bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).Cd_empresa.Trim() + "'"
                                                                    },
                                                                    new TpBusca()
                                                                    {
                                                                        vNM_Campo = "a.cd_produto",
                                                                        vOperador = "=",
                                                                        vVL_Busca = "'" + p.CD_ProdVenda.Trim() + "'"
                                                                    },
                                                                    new TpBusca()
                                                                    {
                                                                        vNM_Campo = "a.cd_tabelapreco",
                                                                        vOperador = "=",
                                                                        vVL_Busca = "'" + objCupom.ToString() + "'"
                                                                    }
                                                                             }, "a.Vl_PrecoVenda");
                                                rAcessorios.Vl_unitario = vl_precoacessorio == null || string.IsNullOrEmpty(vl_precoacessorio.ToString()) ? decimal.Zero : decimal.Parse(vl_precoacessorio.ToString());
                                            }
                                            (bsItens.Current as CamadaDados.Locacao.TRegistro_ItensLocacao).lAcessorio.Add(rAcessorios);
                                        });
                                        try
                                        {
                                            CamadaNegocio.Locacao.TCN_ItensLocacao.Gravar(bsItens.Current as CamadaDados.Locacao.TRegistro_ItensLocacao, null);
                                            MessageBox.Show("Acessórios adicionados com sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        }
                                        catch (Exception ex)
                                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show(msg, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                afterBusca();
            }
        }

        private void PrintContrato(bool St_contrato)
        {
            if (bsLocacao.Current != null)
            {
                if ((bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).St_registro.Trim().Equals("8"))
                {
                    MessageBox.Show("Não é permitido Imprimir contrato de locação CANCELADA.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
                {
                    FormRelPadrao.Relatorio Rel = new FormRelPadrao.Relatorio();
                    Rel.Altera_Relatorio = Altera_Relatorio;
                    //Buscar Outras Despesas
                    (bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).lOutrasDesp =
                        CamadaNegocio.Locacao.TCN_OutrasDesp.buscar((bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).Cd_empresa,
                                                                   (bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).Id_locacaostr,
                                                                   string.Empty,
                                                                   null);
                    BindingSource bs_valor = new BindingSource();
                    bs_valor.DataSource = new CamadaDados.Locacao.TList_Locacao() { bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao };
                    Rel.DTS_Relatorio = bs_valor;
                    if (!St_contrato)
                    {
                        Rel.Ident = Name;
                        Rel.NM_Classe = Name;
                        Rel.Modulo = "LOC";
                    }
                    else
                    {
                        Rel.Ident = "TFLanLocacao_Contrato";
                        Rel.NM_Classe = "TFLanLocacao_Contrato";
                        Rel.Modulo = "LOC";
                    }
                    fImp.St_enabled_enviaremail = true;
                    fImp.pCd_clifor = (bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).Cd_clifor;
                    fImp.pMensagem = "Contrato de Locação";
                    //Comentado devido ao ticket 7923
                    ////Valor extenso VL.Patrimonio
                    //decimal vl_despesas = decimal.Zero;
                    //(bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).lItens.ForEach(p =>
                    //    vl_despesas += p.lAcessorio.Sum(x => x.Quantidade * CamadaNegocio.Estoque.TCN_LanEstoque.BuscarVlEstoqueUltimaCompra(p.Cd_empresa, x.Cd_produto, null)));
                    //string vl_patrimonio =
                    //    new Extenso().ValorExtenso((bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).lItens.Sum(p => p.Vl_patrimonio * p.QTDItem) + vl_despesas, "Real", "Reais");
                    //decimal tot_patrimonio = (bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).lItens.Sum(p => p.Vl_patrimonio * p.QTDItem) + vl_despesas;
                    //Rel.Parametros_Relatorio.Add("VL_PATRIMONIO", vl_patrimonio);
                    //Rel.Parametros_Relatorio.Add("TOT_PATRIMONIO", tot_patrimonio.ToString("N2", new System.Globalization.CultureInfo("pt-BR")));

                    string vl_patrimonio =
                        new Extenso().ValorExtenso((bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).lItens.Sum(p => p.Vl_patrimonio * p.QTDItem), "Real", "Reais");
                    decimal tot_patrimonio = (bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).lItens.Sum(p => p.Vl_patrimonio * p.QTDItem);
                    Rel.Parametros_Relatorio.Add("VL_PATRIMONIO", vl_patrimonio);
                    Rel.Parametros_Relatorio.Add("TOT_PATRIMONIO", tot_patrimonio.ToString("N2", new System.Globalization.CultureInfo("pt-BR")));
                    if (St_contrato)
                    {
                        (bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).Nr_contrato = (bsContrato.Current as CamadaDados.Locacao.TRegistro_Contrato).Nr_contrato;
                        (bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).ObsContrato = (bsContrato.Current as CamadaDados.Locacao.TRegistro_Contrato).Obs;
                    }

                    //Chave Acesso
                    (bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).ChaveAcesso = (bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).Id_locacaostr.FormatStringEsquerda(44, '0');
                    //Buscar clifor da empresa
                    BindingSource bs_cliforemp = new BindingSource();
                    bs_cliforemp.DataSource = new CamadaDados.Financeiro.Cadastros.TCD_CadClifor().Select(
                        new TpBusca[]
                            {
                                new TpBusca()
                                {
                                    vNM_Campo = string.Empty,
                                    vOperador = "exists",
                                    vVL_Busca = "(select 1 from tb_div_empresa x "+
                                                "where x.cd_clifor = a.cd_clifor "+
                                                "and x.cd_empresa = '" + (bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).Cd_empresa.Trim() + "')"
                                }
                            }, 0, string.Empty);
                    Rel.Adiciona_DataSource("DTS_CliforEmp", bs_cliforemp);
                    //Buscar Endereco Empresa
                    BindingSource bs_endemp = new BindingSource();
                    bs_endemp.DataSource = new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco().Select(
                        new TpBusca[]
                            {
                                new TpBusca()
                                {
                                    vNM_Campo = string.Empty,
                                    vOperador = "exists",
                                    vVL_Busca = "(select 1 from tb_div_empresa x " +
                                                "where x.cd_clifor = a.cd_clifor "+
                                                "and x.cd_endereco = a.cd_endereco "+
                                                "and x.cd_empresa = '" + (bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).Cd_empresa.Trim() + "')"
                                }
                            }, 0, string.Empty);
                    Rel.Adiciona_DataSource("DTS_EndEmp", bs_endemp);
                    //Buscar Cliente da Locacao
                    BindingSource bs_CliforLocacao = new BindingSource();
                    bs_CliforLocacao.DataSource = CamadaNegocio.Financeiro.Cadastros.TCN_CadClifor.Busca_Clifor((bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).Cd_clifor,
                                                                                                                string.Empty,
                                                                                                                string.Empty,
                                                                                                                string.Empty,
                                                                                                                string.Empty,
                                                                                                                string.Empty,
                                                                                                                string.Empty,
                                                                                                                string.Empty,
                                                                                                                string.Empty,
                                                                                                                string.Empty,
                                                                                                                false,
                                                                                                                string.Empty,
                                                                                                                string.Empty,
                                                                                                                string.Empty,
                                                                                                                string.Empty,
                                                                                                                string.Empty,
                                                                                                                string.Empty,
                                                                                                                0,
                                                                                                                null);
                    Rel.Adiciona_DataSource("DTS_CliforLocacao", bs_CliforLocacao);
                    //Buscar Endereco do Clifor
                    BindingSource bs_endClifor = new BindingSource();
                    bs_endClifor.DataSource = CamadaNegocio.Financeiro.Cadastros.TCN_CadEndereco.Buscar((bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).Cd_clifor,
                                                                                                         (bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).Cd_endereco,
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
                                                                                                                                                    string.Empty,
                                                                                                                                                    0,
                                                                                                                                                    null);
                    Rel.Adiciona_DataSource("DTS_endClifor", bs_endClifor);
                    //Buscar dados Empresa
                    CamadaDados.Diversos.TList_CadEmpresa lEmpresa =
                        CamadaNegocio.Diversos.TCN_CadEmpresa.Busca((bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).Cd_empresa,
                                                                    string.Empty,
                                                                    string.Empty,
                                                                    null);
                    if (lEmpresa.Count > 0)
                        if (lEmpresa[0].Img != null)
                            Rel.Parametros_Relatorio.Add("IMAGEM_RELATORIO", lEmpresa[0].Img);

                    if (Altera_Relatorio)
                    {
                        Rel.Gera_Relatorio(string.Empty,
                                           fImp.pSt_imprimir,
                                           fImp.pSt_visualizar,
                                           fImp.pSt_enviaremail,
                                           fImp.pSt_exportPdf,
                                           fImp.Path_exportPdf,
                                           fImp.pDestinatarios,
                                           null,
                                           "Contrato de Locação",
                                           fImp.pDs_mensagem);
                        Altera_Relatorio = false;
                    }
                    else
                        if ((fImp.ShowDialog() == DialogResult.OK) || (fImp.pSt_enviaremail))
                        Rel.Gera_Relatorio(string.Empty,
                                           fImp.pSt_imprimir,
                                           fImp.pSt_visualizar,
                                           fImp.pSt_enviaremail,
                                           fImp.pSt_exportPdf,
                                           fImp.Path_exportPdf,
                                           fImp.pDestinatarios,
                                           null,
                                           "Contrato de Locação",
                                           fImp.pDs_mensagem);
                }


            }
            else
                MessageBox.Show("Obrigatório selecionar locação para imprimir contrato.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void PrintOrdemLocacao()
        {
            if (bsLocacao.Current != null)
            {
                if ((bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).St_registro.Trim().Equals("8"))
                {
                    MessageBox.Show("Não é permitido Imprimir contrato de locação CANCELADA.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
                {
                    FormRelPadrao.Relatorio Rel = new FormRelPadrao.Relatorio();
                    Rel.Altera_Relatorio = Altera_Relatorio;
                    //Buscar Outras Despesas
                    (bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).lOutrasDesp =
                        CamadaNegocio.Locacao.TCN_OutrasDesp.buscar((bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).Cd_empresa,
                                                                   (bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).Id_locacaostr,
                                                                   string.Empty,
                                                                   null);
                    BindingSource bs_valor = new BindingSource();
                    bs_valor.DataSource = new CamadaDados.Locacao.TList_Locacao() { bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao };
                    Rel.DTS_Relatorio = bs_valor;
                    Rel.Ident = "TFLanLocacao_OrdemLoc";
                    Rel.NM_Classe = "TFLanLocacao_OrdemLoc";
                    Rel.Modulo = "LOC";
                    fImp.St_enabled_enviaremail = true;
                    fImp.pCd_clifor = (bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).Cd_clifor;
                    fImp.pMensagem = "ORDEM LOCAÇÃO";
                    //Valor extenso VL.Patrimonio
                    string vl_patrimonio =
                        new Extenso().ValorExtenso((bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).lItens.Sum(p => p.Vl_patrimonio), "Real", "Reais");
                    decimal tot_patrimonio = (bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).lItens.Sum(p => p.Vl_patrimonio);
                    Rel.Parametros_Relatorio.Add("VL_PATRIMONIO", vl_patrimonio);
                    Rel.Parametros_Relatorio.Add("TOT_PATRIMONIO", tot_patrimonio.ToString("N2", new System.Globalization.CultureInfo("pt-BR")));

                    //Valor total dos acessorios
                    decimal tot_vlAcessorios = 0;
                    (bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).lItens.ForEach(p => p.lAcessorio.ForEach(a =>
                    {
                        tot_vlAcessorios += a.Vl_unitario * a.Qtd_saldo;
                    }));
                    Rel.Parametros_Relatorio.Add("TOT_VL_ACESSORIOS", tot_vlAcessorios.ToString("N2", new System.Globalization.CultureInfo("pt-BR")));

                    //Chave Acesso
                    (bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).ChaveAcesso = (bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).Id_locacaostr.FormatStringEsquerda(44, '0');
                    //Buscar clifor da empresa
                    BindingSource bs_cliforemp = new BindingSource();
                    bs_cliforemp.DataSource = new CamadaDados.Financeiro.Cadastros.TCD_CadClifor().Select(
                        new TpBusca[]
                            {
                                new TpBusca()
                                {
                                    vNM_Campo = string.Empty,
                                    vOperador = "exists",
                                    vVL_Busca = "(select 1 from tb_div_empresa x "+
                                                "where x.cd_clifor = a.cd_clifor "+
                                                "and x.cd_empresa = '" + (bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).Cd_empresa.Trim() + "')"
                                }
                            }, 0, string.Empty);
                    Rel.Adiciona_DataSource("DTS_CliforEmp", bs_cliforemp);
                    //Buscar Endereco Empresa
                    BindingSource bs_endemp = new BindingSource();
                    bs_endemp.DataSource = new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco().Select(
                        new TpBusca[]
                            {
                                new TpBusca()
                                {
                                    vNM_Campo = string.Empty,
                                    vOperador = "exists",
                                    vVL_Busca = "(select 1 from tb_div_empresa x " +
                                                "where x.cd_clifor = a.cd_clifor "+
                                                "and x.cd_endereco = a.cd_endereco "+
                                                "and x.cd_empresa = '" + (bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).Cd_empresa.Trim() + "')"
                                }
                            }, 0, string.Empty);
                    Rel.Adiciona_DataSource("DTS_EndEmp", bs_endemp);
                    //Buscar Cliente da Locacao
                    BindingSource bs_CliforLocacao = new BindingSource();
                    bs_CliforLocacao.DataSource = CamadaNegocio.Financeiro.Cadastros.TCN_CadClifor.Busca_Clifor((bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).Cd_clifor,
                                                                                                                string.Empty,
                                                                                                                string.Empty,
                                                                                                                string.Empty,
                                                                                                                string.Empty,
                                                                                                                string.Empty,
                                                                                                                string.Empty,
                                                                                                                string.Empty,
                                                                                                                string.Empty,
                                                                                                                string.Empty,
                                                                                                                false,
                                                                                                                string.Empty,
                                                                                                                string.Empty,
                                                                                                                string.Empty,
                                                                                                                string.Empty,
                                                                                                                string.Empty,
                                                                                                                string.Empty,
                                                                                                                0,
                                                                                                                null);
                    Rel.Adiciona_DataSource("DTS_CliforLocacao", bs_CliforLocacao);
                    //Buscar Endereco do Clifor
                    BindingSource bs_endClifor = new BindingSource();
                    bs_endClifor.DataSource = CamadaNegocio.Financeiro.Cadastros.TCN_CadEndereco.Buscar((bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).Cd_clifor,
                                                                                                         (bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).Cd_endereco,
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
                                                                                                                                                    string.Empty,
                                                                                                                                                    0,
                                                                                                                                                    null);
                    Rel.Adiciona_DataSource("DTS_endClifor", bs_endClifor);

                    //Buscar Baixa Acessórios e patrimônio Pré-Venda
                    (bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).lBaixa =
                        new CamadaDados.Faturamento.PDV.TCD_PreVenda().Select(
                            new TpBusca[]
                            {
                                new TpBusca()
                                {
                                    vNM_Campo = string.Empty,
                                    vOperador = "exists",
                                    vVL_Busca = "(select 1 from TB_LOC_Itens_X_PreVenda x " +
                                                "inner join TB_PDV_ItensPreVenda y " +
                                                "on x.cd_empresa =  y.cd_empresa " +
                                                "and x.ID_PreVenda = y.ID_PreVenda " +
                                                "and x.ID_ItemPreVenda = y.ID_ItemPreVenda " +
                                                "where a.cd_empresa = x.cd_empresa " +
                                                "and a.ID_PreVenda = x.ID_PreVenda " +
                                                "and isnull(y.ST_BaixaPatrimonio, 'N') = 'S' " +
                                                "and x.cd_empresa = '" + (bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).Cd_empresa.Trim() + "' " +
                                                "and x.id_locacao = " + (bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).Id_locacaostr + ") "
                                },
                                new TpBusca()
                                {
                                    vNM_Campo = "isnull(a.st_registro, 'A')",
                                    vOperador = "<>",
                                    vVL_Busca = "'C'"
                                }
                            }, 1, string.Empty, string.Empty);

                    (bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).lBaixa.ForEach(p =>
                            {
                                p.lItens = new CamadaDados.Faturamento.PDV.TCD_ItensPreVenda().Select(
                                    new TpBusca[]
                                    {
                                        new TpBusca()
                                        {
                                            vNM_Campo = "a.cd_empresa",
                                            vOperador = "=",
                                            vVL_Busca = "'" + (bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).Cd_empresa.Trim() + "'"
                                        },
                                        new TpBusca()
                                        {
                                            vNM_Campo = "a.id_prevenda",
                                            vOperador = "=",
                                            vVL_Busca = p.Id_prevendastr
                                        },
                                        new TpBusca()
                                        {
                                            vNM_Campo = "isnull(a.ST_BaixaPatrimonio, 'N')",
                                            vOperador = "=",
                                            vVL_Busca = "'S'"
                                        }
                                    }, 0, string.Empty);
                            });
                    //Buscar dados Empresa
                    CamadaDados.Diversos.TList_CadEmpresa lEmpresa =
                        CamadaNegocio.Diversos.TCN_CadEmpresa.Busca((bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).Cd_empresa,
                                                                    string.Empty,
                                                                    string.Empty,
                                                                    null);

                    //Entrega/Coleta
                    string entregacoleta = string.Empty;
                    (bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).lColetaEntrega.ForEach(p =>
                    {
                        if (!string.IsNullOrEmpty(p.Ds_veiculo) || !string.IsNullOrEmpty(p.Nm_motorista))
                            entregacoleta += p.Tipo_mov.Trim() + " - Motorista: " + p.Nm_motorista.Trim() + " -  Veiculo: " + p.Ds_veiculo.Trim() + "-" + p.Placa.Trim() + "\r\n";
                    });
                    Rel.Parametros_Relatorio.Add("ENTREGACOLETA", entregacoleta);
                    if (lEmpresa.Count > 0)
                        if (lEmpresa[0].Img != null)
                            Rel.Parametros_Relatorio.Add("IMAGEM_RELATORIO", lEmpresa[0].Img);

                    if (Altera_Relatorio)
                    {
                        Rel.Gera_Relatorio(string.Empty,
                                           fImp.pSt_imprimir,
                                           fImp.pSt_visualizar,
                                           fImp.pSt_enviaremail,
                                           fImp.pSt_exportPdf,
                                           fImp.Path_exportPdf,
                                           fImp.pDestinatarios,
                                           null,
                                           "ORDEM LOCAÇÃO",
                                           fImp.pDs_mensagem);
                        Altera_Relatorio = false;
                    }
                    else
                        if ((fImp.ShowDialog() == DialogResult.OK) || (fImp.pSt_enviaremail))
                        Rel.Gera_Relatorio(string.Empty,
                                           fImp.pSt_imprimir,
                                           fImp.pSt_visualizar,
                                           fImp.pSt_enviaremail,
                                           fImp.pSt_exportPdf,
                                           fImp.Path_exportPdf,
                                           fImp.pDestinatarios,
                                           null,
                                           "ORDEM LOCAÇÃO",
                                           fImp.pDs_mensagem);
                }


            }
            else
                MessageBox.Show("Obrigatório selecionar locação para imprimir contrato.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void PrintCheckList()
        {
            if (bsLocacao.Current != null)
            {
                if ((bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).St_registro.Trim().Equals("8"))
                {
                    MessageBox.Show("Não é permitido Imprimir CheckList de locação CANCELADA.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
                {
                    FormRelPadrao.Relatorio Rel = new FormRelPadrao.Relatorio();
                    Rel.Altera_Relatorio = Altera_Relatorio;
                    //Buscar Outras Despesas
                    BindingSource bs_valor = new BindingSource();
                    bs_valor.DataSource = new CamadaDados.Locacao.TList_Locacao() { bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao };
                    Rel.DTS_Relatorio = bs_valor;
                    Rel.Ident = "CheckList_Locacao";
                    Rel.NM_Classe = "TFLanLocacao_Contrato";
                    Rel.Modulo = "LOC";
                    fImp.St_enabled_enviaremail = true;
                    fImp.pCd_clifor = (bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).Cd_clifor;
                    fImp.pMensagem = "CheckList Locação";
                    //Buscar clifor da empresa
                    BindingSource bs_cliforemp = new BindingSource();
                    bs_cliforemp.DataSource = new CamadaDados.Financeiro.Cadastros.TCD_CadClifor().Select(
                        new TpBusca[]
                            {
                                new TpBusca()
                                {
                                    vNM_Campo = string.Empty,
                                    vOperador = "exists",
                                    vVL_Busca = "(select 1 from tb_div_empresa x "+
                                                "where x.cd_clifor = a.cd_clifor "+
                                                "and x.cd_empresa = '" + (bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).Cd_empresa.Trim() + "')"
                                }
                            }, 0, string.Empty);
                    Rel.Adiciona_DataSource("DTS_CliforEmp", bs_cliforemp);
                    //Buscar Endereco Empresa
                    BindingSource bs_endemp = new BindingSource();
                    bs_endemp.DataSource = new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco().Select(
                        new TpBusca[]
                            {
                                new TpBusca()
                                {
                                    vNM_Campo = string.Empty,
                                    vOperador = "exists",
                                    vVL_Busca = "(select 1 from tb_div_empresa x " +
                                                "where x.cd_clifor = a.cd_clifor "+
                                                "and x.cd_endereco = a.cd_endereco "+
                                                "and x.cd_empresa = '" + (bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).Cd_empresa.Trim() + "')"
                                }
                            }, 0, string.Empty);
                    Rel.Adiciona_DataSource("DTS_EndEmp", bs_endemp);
                    //Buscar Cliente da Locacao
                    BindingSource bs_CliforLocacao = new BindingSource();
                    bs_CliforLocacao.DataSource = CamadaNegocio.Financeiro.Cadastros.TCN_CadClifor.Busca_Clifor((bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).Cd_clifor,
                                                                                                                string.Empty,
                                                                                                                string.Empty,
                                                                                                                string.Empty,
                                                                                                                string.Empty,
                                                                                                                string.Empty,
                                                                                                                string.Empty,
                                                                                                                string.Empty,
                                                                                                                string.Empty,
                                                                                                                string.Empty,
                                                                                                                false,
                                                                                                                string.Empty,
                                                                                                                string.Empty,
                                                                                                                string.Empty,
                                                                                                                string.Empty,
                                                                                                                string.Empty,
                                                                                                                string.Empty,
                                                                                                                0,
                                                                                                                null);
                    Rel.Adiciona_DataSource("DTS_CliforLocacao", bs_CliforLocacao);
                    //Buscar Endereco do Clifor
                    BindingSource bs_endClifor = new BindingSource();
                    bs_endClifor.DataSource = CamadaNegocio.Financeiro.Cadastros.TCN_CadEndereco.Buscar((bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).Cd_clifor,
                                                                                                         (bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).Cd_endereco,
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
                                                                                                                                                    string.Empty,
                                                                                                                                                    0,
                                                                                                                                                    null);
                    Rel.Adiciona_DataSource("DTS_endClifor", bs_endClifor);
                    //Buscar dados Empresa
                    CamadaDados.Diversos.TList_CadEmpresa lEmpresa =
                        CamadaNegocio.Diversos.TCN_CadEmpresa.Busca((bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).Cd_empresa,
                                                                    string.Empty,
                                                                    string.Empty,
                                                                    null);
                    if (lEmpresa.Count > 0)
                        if (lEmpresa[0].Img != null)
                            Rel.Parametros_Relatorio.Add("IMAGEM_RELATORIO", lEmpresa[0].Img);

                    if (Altera_Relatorio)
                    {
                        Rel.Gera_Relatorio(string.Empty,
                                           fImp.pSt_imprimir,
                                           fImp.pSt_visualizar,
                                           fImp.pSt_enviaremail,
                                           fImp.pSt_exportPdf,
                                           fImp.Path_exportPdf,
                                           fImp.pDestinatarios,
                                           null,
                                           "CheckList Locação",
                                           fImp.pDs_mensagem);
                        Altera_Relatorio = false;
                    }
                    else
                        if ((fImp.ShowDialog() == DialogResult.OK) || (fImp.pSt_enviaremail))
                        Rel.Gera_Relatorio(string.Empty,
                                           fImp.pSt_imprimir,
                                           fImp.pSt_visualizar,
                                           fImp.pSt_enviaremail,
                                           fImp.pSt_exportPdf,
                                           fImp.Path_exportPdf,
                                           fImp.pDestinatarios,
                                           null,
                                           "CheckList Locação",
                                           fImp.pDs_mensagem);
                }
            }
            else
                MessageBox.Show("Obrigatório selecionar locação para imprimir CheckList.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void afterFaturar()
        {
            using (TFItensFaturar fFaturar = new TFItensFaturar())
            {
                fFaturar.ShowDialog();
            }
        }

        private decimal CalcularDescEspecial(decimal Vl_unit,
                                           string Cd_produto,
                                           string Cd_tabelapreco)
        {
            CamadaDados.Faturamento.ProgEspecialVenda.TRegistro_ProgEspecialVenda rProg = null;
            //Verificar se existe programacao especial de venda 
            TList_ProgEspecialVenda lProg = new TList_ProgEspecialVenda();
            if (!string.IsNullOrEmpty(Cd_tabelapreco))
            {
                lProg = new CamadaDados.Faturamento.ProgEspecialVenda.TCD_ProgEspecialVenda().Select(
                            new Utils.TpBusca[]
                            {
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "a.cd_empresa",
                                    vOperador = "=",
                                    vVL_Busca = "'" + (bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).Cd_empresa.Trim() + "'"
                                },
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = string.Empty,
                                    vOperador = string.Empty,
                                    vVL_Busca = "(a.cd_produto = '" + Cd_produto.Trim() + "') or " +
                                                "(exists(select 1 from tb_est_produto x " +
                                                "where x.cd_grupo = a.cd_grupo " +
                                                "and x.cd_produto = '" + Cd_produto.Trim() + "'))"
                                },
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = string.Empty,
                                    vOperador = string.Empty,
                                    vVL_Busca = "(a.cd_clifor = '" + (bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).Cd_clifor.Trim() + "') or " +
                                                "(exists(select 1 from tb_fin_clifor x " +
                                                "where x.id_categoriaclifor = a.id_categoriaclifor " +
                                                "and x.cd_clifor = '" + (bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).Cd_clifor.Trim() + "'))"
                                },
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = string.Empty,
                                    vOperador = string.Empty,
                                    vVL_Busca = "a.ID_TabelaLocacao = " + Cd_tabelapreco.Trim() + ""
                                }
                            }, 1, string.Empty);
            }
            if (lProg.Count > 0)
                rProg = lProg[0];
            else
            {
                lProg = new CamadaDados.Faturamento.ProgEspecialVenda.TCD_ProgEspecialVenda().Select(
                            new Utils.TpBusca[]
                            {
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "a.cd_empresa",
                                    vOperador = "=",
                                    vVL_Busca = "'" + (bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).Cd_empresa.Trim() + "'"
                                },
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = string.Empty,
                                    vOperador = string.Empty,
                                    vVL_Busca = "(a.cd_produto = '" + Cd_produto.Trim() + "') or " +
                                                "(exists(select 1 from tb_est_produto x " +
                                                "where x.cd_grupo = a.cd_grupo " +
                                                "and x.cd_produto = '" + Cd_produto.Trim() + "'))"
                                },
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = string.Empty,
                                    vOperador = string.Empty,
                                    vVL_Busca = "(a.cd_clifor = '" + (bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).Cd_clifor.Trim() + "') or " +
                                                "(exists(select 1 from tb_fin_clifor x " +
                                                "where x.id_categoriaclifor = a.id_categoriaclifor " +
                                                "and x.cd_clifor = '" + (bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).Cd_clifor.Trim() + "'))"
                                },
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "a.ID_TabelaLocacao",
                                    vOperador = "is",
                                    vVL_Busca = "null"
                                }
                            }, 1, string.Empty);
                if (lProg.Count > 0)
                    rProg = lProg[0];
                else rProg = null;
            }
            if (rProg != null)
                if (rProg.Valor > decimal.Zero)
                {
                    if (rProg.Tp_valor.Trim().ToUpper().Equals("V"))
                        return rProg.Valor;
                    else
                        return Vl_unit * rProg.Valor / 100;
                }
                else return decimal.Zero;
            else return decimal.Zero;
        }
        private void VisualizarHist()
        {
            using (TFHistorico fHist = new TFHistorico())
            {
                fHist.pDs_mensagem = (bsHistorico.Current as CamadaDados.Locacao.TRegistro_Historico).Ds_historico;
                fHist.St_visualizar = true;
                fHist.ShowDialog();
            }
        }

        private void TFLanLocacao_Load(object sender, EventArgs e)
        {
            Icon = ResourcesUtils.TecnoAliance_ICO;
            TS_ItensAcessorios.Visible = true;
            ShapeGrid.RestoreShape(this, gLocacao);
            ShapeGrid.RestoreShape(this, gItens);
            pConsulta.set_FormatZero();
            tp_frete.SelectedIndex = 0;

            st_locacao = CamadaNegocio.Diversos.TCN_CadAcesso.BuscarDetalhesAcesso(Utils.Parametros.pubLogin, "Locacao.TFLocacao") != null ||
                         Utils.Parametros.pubLogin.Trim().ToUpper().Equals("MASTER") ||
                         Utils.Parametros.pubLogin.Trim().ToUpper().Equals("DESENV");
            BB_Novo.Visible = st_locacao;
            st_cancelar = CamadaNegocio.Diversos.TCN_Usuario_RegraEspecial.ValidaRegra(Utils.Parametros.pubLogin, "PERMITIR CANCELAR LOCAÇÃO", null);
            st_faturar = CamadaNegocio.Diversos.TCN_Usuario_RegraEspecial.ValidaRegra(Utils.Parametros.pubLogin, "PERMITIR FATURAR LOCAÇÃO", null);
            BB_Faturar.Visible = st_faturar;
            st_entregar = CamadaNegocio.Diversos.TCN_Usuario_RegraEspecial.ValidaRegra(Utils.Parametros.pubLogin, "PERMITIR ENTREGAR LOCAÇÃO", null);
            BB_Entrega.Visible = st_entregar;
            st_devolver = CamadaNegocio.Diversos.TCN_Usuario_RegraEspecial.ValidaRegra(Utils.Parametros.pubLogin, "PERMITIR DEVOLVER LOCAÇÃO", null);
            BB_Devolucao.Visible = st_devolver;
            st_imprimir = CamadaNegocio.Diversos.TCN_Usuario_RegraEspecial.ValidaRegra(Utils.Parametros.pubLogin, "PERMITIR IMPRIMIR CONTRATO", null);
            st_contrato = CamadaNegocio.Diversos.TCN_Usuario_RegraEspecial.ValidaRegra(Utils.Parametros.pubLogin, "PERMITIR GERAR CONTRATO", null);
            BB_Imprimir.Visible = st_imprimir;
            st_finalizar = CamadaNegocio.Diversos.TCN_Usuario_RegraEspecial.ValidaRegra(Utils.Parametros.pubLogin, "PERMITIR FINALIZAR LOCAÇÃO", null);
            bb_finalizar.Visible = st_finalizar;
            btn_Altera_TabPreco.Visible = st_finalizar;
            btn_estornarFin.Visible = false;
            btn_alterar_dt_prevdev.Visible = CamadaNegocio.Diversos.TCN_Usuario_RegraEspecial.ValidaRegra(Utils.Parametros.pubLogin, "PERMITIR ALTERAR DT.PREV.DEVOLUÇÃO", null);
            bb_alteraLocacao.Visible = CamadaNegocio.Diversos.TCN_Usuario_RegraEspecial.ValidaRegra(Utils.Parametros.pubLogin, "PERMITIR ALTERAR DT.PREV.DEVOLUÇÃO", null);
            btn_Alterar_Frete.Visible = CamadaNegocio.Diversos.TCN_Usuario_RegraEspecial.ValidaRegra(Utils.Parametros.pubLogin, "PERMITIR ALTERAR VALOR DESPESAS", null);
            mANUTENÇÃOToolStripMenuItem.Visible = CamadaNegocio.Diversos.TCN_Usuario_RegraEspecial.ValidaRegra(Utils.Parametros.pubLogin, "PERMITIR ENVIAR ITEM PARA MANUTENÇÃO", null);
            aLTERARITEMLOCAÇÃOToolStripMenuItem.Visible = CamadaNegocio.Diversos.TCN_Usuario_RegraEspecial.ValidaRegra(Utils.Parametros.pubLogin, "PERMITIR TROCA DE ITENS LOCAÇÃO", null);

            TList_CFGLocacao lCfg = CamadaNegocio.Locacao.Cadastros.TCN_CFGLocacao.buscar(string.Empty, string.Empty, null);
            if (lCfg == null || lCfg.Count.Equals(0))
            {
                MessageBox.Show("Não existe CFG.Locação para empresa Nº" + (bsItens.Current as CamadaDados.Locacao.TRegistro_ItensLocacao).Cd_empresa.Trim(), "Mensagem",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                rCfg = lCfg[0];
            }
        }

        private void BB_Buscar_Click(object sender, EventArgs e)
        {
            afterBusca();
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            afterCancela();
        }

        private void BB_Fechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Cd_empresa_Click(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LeaveEmpresa("a.cd_empresa|=|'" + Cd_empresa.Text.Trim() + "'", new Componentes.EditDefault[] { Cd_empresa });
        }

        private void bb_empresa_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BuscaEmpresa(new Componentes.EditDefault[] { Cd_empresa }, string.Empty);
        }

        private void Cd_clifor_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LeaveClifor("a.cd_clifor|=|'" + Cd_clifor.Text.Trim() + "'",
                                                    new Componentes.EditDefault[] { Cd_clifor },
                                                    new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
        }

        private void bb_clifor_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { Cd_clifor }, string.Empty);
        }

        private void CD_Grupo_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.CD_Grupo|=|'" + CD_Grupo.Text + "';" +
                             "a.TP_Grupo|=|'A'";
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { CD_Grupo },
                                    new CamadaDados.Estoque.Cadastros.TCD_CadGrupoProduto());
        }

        private void BB_GrupoProduto_Click(object sender, EventArgs e)
        {
            string vColunas = "a.DS_Grupo|Descrição Grupo Produto|350;" +
                             "a.CD_Grupo|Cód. Grupo|100";
            string vParamFixo = "a.TP_Grupo|=|'A'";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { CD_Grupo },
                                    new CamadaDados.Estoque.Cadastros.TCD_CadGrupoProduto(), vParamFixo);
        }

        private void bb_vendedor_Click(object sender, EventArgs e)
        {
            string vColunas = "a.nm_clifor|Nome Vendedor|200;" +
                              "a.cd_clifor|Cd. Vendedor|80";
            string vParam = "isnull(a.st_vendedor, 'N')|=|'S';" +
                            "isnull(a.st_funcativo, 'N')|=|'S'";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_vendedor },
                new CamadaDados.Financeiro.Cadastros.TCD_CadClifor(),
               vParam);
        }

        private void cd_vendedor_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_clifor|=|'" + cd_vendedor.Text.Trim() + "';" +
                            "isnull(a.st_vendedor, 'N')|=|'S';" +
                            "isnull(a.st_funcativo, 'N')|=|'S'";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_vendedor },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
        }

        private void bsLocacao_PositionChanged(object sender, EventArgs e)
        {
            if (bsLocacao.Current != null)
            {
                if (((bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).St_registro.Trim().Equals("1")))
                    BB_Entrega.Text = "(F10)\r\nConfirmar Entrega";
                else
                    BB_Entrega.Text = "(F10)\r\nENTREGA";
                if (((bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).St_registro.Trim().Equals("4")))
                    BB_Devolucao.Text = "(F12)\r\nConfirmar DEV.";
                else
                    BB_Devolucao.Text = "(F12)\r\nDEVOLUÇÃO";
                TS_ItensLocacao.Visible = st_finalizar || st_entregar || st_devolver;

                //Buscar Itens
                (bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).lItens =
                    CamadaNegocio.Locacao.TCN_ItensLocacao.buscar((bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).Cd_empresa,
                                                                  (bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).Id_locacaostr,
                                                                  "A",
                                                                   null);

                //Validar se item está em manutencao e atualizar status
                if ((bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).lItens.Count > 0)
                {
                    (bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).lItens.ForEach(p =>
                    {
                        TpBusca[] tpBusca = new TpBusca[0];
                        Estruturas.CriarParametro(ref tpBusca, "a.st_os", "'AB'");
                        Estruturas.CriarParametro(ref tpBusca, "j.cd_produto", p.Cd_produto);
                        Estruturas.CriarParametro(ref tpBusca, "pat.NR_Patrimonio", "'" + p.Nr_Patrimonio + "'");

                        if (new CamadaDados.Servicos.TCD_LanServico().BuscarEscalar(tpBusca, "1") != null)
                            p.St_ItemLocado = "MANUTENÇÃO";
                        else
                            p.St_ItemLocado = "LOCADO";
                    });
                }

                btn_estornarFin.Visible = (bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).lItens.Exists(p => !string.IsNullOrEmpty(p.Dt_fechamentostr)) && st_finalizar;

                //Buscar Coleta/Entrega
                (bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).lColetaEntrega =
                    new CamadaDados.Locacao.TCD_ColetaEntrega().Select(
                        new TpBusca[]
                        {
                            new TpBusca()
                            {
                                vNM_Campo = string.Empty,
                                vOperador = "exists",
                                vVL_Busca = "(select 1 from TB_LOC_Vistoria_X_ColEnt x " +
                                            "inner join TB_LOC_Vistoria y " +
                                                "on x.cd_empresa = y.cd_empresa " +
                                                "and x.id_locacao = y.id_locacao " +
                                                "and x.id_itemloc = y.id_itemloc " +
                                                "and x.id_vistoria = y.id_vistoria " +
                                            "where a.cd_empresa = x.cd_empresa " +
                                            "and a.ID_Coleta = x.ID_Coleta " +
                                            "and x.cd_empresa = '" + (bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).Cd_empresa.Trim() + "'" +
                                            "and x.id_locacao = " + (bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).Id_locacaostr + " " +
                                            "and isnull(y.st_registro, 'A') <> 'H')"
                            }
                        }, 0, string.Empty);

                //Buscar Acessorios
                (bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).lItens.ForEach(p =>
                    p.lAcessorio = CamadaNegocio.Locacao.TCN_AcessoriosItem.buscar(p.Cd_empresa,
                                                                                   p.Id_locacaostr,
                                                                                   p.Id_itemlocstr,
                                                                                   string.Empty,
                                                                                   null));

                //Buscar Parcelas Locação
                (bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).lParc =
                    CamadaNegocio.Locacao.TCN_ParcelaLocacao.Buscar((bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).Id_locacaostr,
                                                                    (bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).Cd_empresa,
                                                                    null);

                //Buscar Duplicatas
                (bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).lDup =
                    new CamadaDados.Financeiro.Duplicata.TCD_LanDuplicata().Select(
                        new TpBusca[]
                        {
                            new TpBusca()
                            {
                                vNM_Campo = string.Empty,
                                vOperador = "exists",
                                vVL_Busca = "(select 1 from TB_LOC_Locacao_X_Duplicata x " +
                                            "where x.cd_empresa = a.cd_empresa " +
                                            "and x.nr_lancto = a.nr_lancto " +
                                            "and x.cd_empresa = '" + (bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).Cd_empresa.Trim() + "' " +
                                            "and x.id_locacao = '" + (bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).Id_locacaostr + "')"
                            }
                        }, 0, string.Empty);

                //Buscar Contratos
                (bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).lContrato =
                    CamadaNegocio.Locacao.TCN_Contrato.Buscar((bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).Id_locacaostr,
                                                              (bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).Cd_empresa,
                                                              string.Empty,
                                                              null);
                //Buscar Outras Despesas
                (bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).lOutrasDesp =
                        CamadaNegocio.Locacao.TCN_OutrasDesp.buscar((bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).Cd_empresa,
                                                                   (bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).Id_locacaostr,
                                                                   string.Empty,
                                                                   null);
                tcDetalhes_SelectedIndexChanged(this, new EventArgs());

                bsLocacao.ResetCurrentItem();

                bsColetaEntrega_PositionChanged(this, new EventArgs());
            }
        }

        private void BB_Entrega_Click(object sender, EventArgs e)
        {
            afterEntrega();
        }

        private void BB_Devolucao_Click(object sender, EventArgs e)
        {
            afterDevolucao();
        }

        private void BB_Faturar_Click(object sender, EventArgs e)
        {
            afterFaturar();
        }

        private void TFLanLocacao_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F2) && st_locacao)
                afterNovo();
            else if (e.KeyCode.Equals(Keys.F5) && st_cancelar)
                afterCancela();
            else if (e.KeyCode.Equals(Keys.F7))
                afterBusca();
            else if (e.KeyCode.Equals(Keys.F8) && st_imprimir)
                PrintContrato(false);
            else if (e.KeyCode.Equals(Keys.F9))
                PrintOrdemLocacao();
            else if (e.KeyCode.Equals(Keys.F10) && st_entregar)
                afterEntrega();
            else if (e.KeyCode.Equals(Keys.F11) && st_finalizar)
                bb_finalizar_Click(this, new EventArgs());
            else if (e.KeyCode.Equals(Keys.F12) && st_devolver)
                afterDevolucao();
            else if (e.KeyCode.Equals(Keys.F6) && st_faturar)
                afterFaturar();
            else if (e.KeyCode.Equals(Keys.Enter))
            {
                LimparCampos();
                if (CodBarras.SoNumero().Length.Equals(44))
                    Id_locacao.Text = CodBarras;
                CodBarras = string.Empty;
                if (!string.IsNullOrEmpty(Id_locacao.Text))
                {
                    afterBusca();
                    Id_locacao.Text = (bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).Id_locacaostr;
                }
            }
            else if (e.Control && e.KeyCode.Equals(Keys.P))
            {
                Altera_Relatorio = true;
                MessageBox.Show("Execute o relatorio que deseja alterar.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            m_BackSpace = e.KeyCode.Equals(Keys.Back);
        }

        private void gLocacao_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null)
            {
                if (e.ColumnIndex.Equals(0))
                {
                    if (e.Value.ToString().Trim().ToUpper().Equals("AGUARDANDO ENTREGA") &&
                        (((sender as Componentes.DataGridDefault).DataSource as BindingSource).List[e.RowIndex] as CamadaDados.Locacao.TRegistro_Locacao).St_entexp)
                        gLocacao.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Red;
                    else if (e.Value.ToString().Trim().ToUpper().Equals("ENTREGUE"))
                    {
                        if ((((sender as Componentes.DataGridDefault).DataSource as BindingSource).List[e.RowIndex] as CamadaDados.Locacao.TRegistro_Locacao).St_devexp)
                            gLocacao.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Red;
                        else gLocacao.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Green;
                    }
                    else if (e.Value.ToString().Trim().ToUpper().Equals("CANCELADO"))
                        gLocacao.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Red;
                    else if (e.Value.ToString().Trim().ToUpper().Equals("DEVOLVIDO"))
                        gLocacao.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Blue;
                    else
                        gLocacao.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
                }
            }
        }

        private void BB_Imprimir_Click(object sender, EventArgs e)
        {
            PrintContrato(false);
        }

        private void bsColetaEntrega_PositionChanged(object sender, EventArgs e)
        {
            if (bsColetaEntrega.Current != null)
            {
                (bsColetaEntrega.Current as CamadaDados.Locacao.TRegistro_ColetaEntrega).lVistoria =
                    new CamadaDados.Locacao.TCD_Vistoria().Select(
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
                                            "and x.cd_empresa = '" + (bsColetaEntrega.Current as CamadaDados.Locacao.TRegistro_ColetaEntrega).Cd_empresa.Trim() + "'" +
                                            "and x.ID_Coleta = " + (bsColetaEntrega.Current as CamadaDados.Locacao.TRegistro_ColetaEntrega).Id_coletastr + ")"
                            }
                        }, 0, string.Empty);
                //bsColetaEntrega.ResetCurrentItem();
            }
        }

        private void bb_impOrdemLoc_Click(object sender, EventArgs e)
        {
            PrintOrdemLocacao();
        }

        private void TFLanLocacao_KeyPress(object sender, KeyPressEventArgs e)
        {
            CodBarras += e.KeyChar.ToString();
        }

        private void btn_Altera_TabPreco_Click(object sender, EventArgs e)
        {
            if (bsLocacao.Current != null)
            {
                if ((bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).St_registro.Trim().ToUpper().Equals("8"))
                {
                    MessageBox.Show("Não é possível alterar tabela de preço de locação CANCELADA!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if ((bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).lItens.Exists(p => p.Dt_fechamento.HasValue))
                {
                    MessageBox.Show("Não é possível alterar tabela de preço de locação com item FINALIZADO!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                using (TFAlterarTabPreco fAlterar = new TFAlterarTabPreco())
                {
                    fAlterar.rLoc = bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao;
                    if (fAlterar.ShowDialog() == DialogResult.OK)
                    {
                        if (!string.IsNullOrEmpty(fAlterar.pId_tabelaPreco))
                        {
                            try
                            {
                                CamadaNegocio.Locacao.TCN_ItensLocacao.TrocarTabelaPreco(bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao, fAlterar.pId_tabelaPreco, null);
                                MessageBox.Show("Tabela de Preço alterada com sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                afterBusca();
                            }
                            catch (Exception ex)
                            { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }

                        }
                        else
                            afterBusca();
                    }
                    else
                        afterBusca();
                }
            }
        }

        private void bb_finalizar_Click(object sender, EventArgs e)
        {
            if (bsLocacao.Current != null)
            {
                LimparCampos();
                Id_locacao.Text = (bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).Id_locacaostr;
                afterBusca();
                if (!(bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).St_registro.Equals("2") &&
                    !(bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).St_registro.Equals("6") &&
                    !(bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).St_registro.Equals("9") &&
                    !(bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).St_registro.Equals("10"))//Entregue e Fechamento Parcial e Aguardando Faturamento
                {
                    MessageBox.Show("Permitido finalizar locação somente com status de ENTREGUE ou FECHAMENTO PARCIAL!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (new CamadaDados.Locacao.TCD_ItensLocacao().BuscarEscalar(
                       new TpBusca[]
                       {
                            new TpBusca()
                            {
                                vNM_Campo = "a.cd_empresa",
                                vOperador = "=",
                                vVL_Busca = "'" + (bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).Cd_empresa.Trim() + "'"
                            },
                            new TpBusca()
                            {
                                vNM_Campo = "a.id_locacao",
                                vOperador = "=",
                                vVL_Busca = (bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).Id_locacaostr
                            },
                            new TpBusca()
                            {
                                vNM_Campo = "a.dt_fechamento",
                                vOperador = "is",
                                vVL_Busca = "null"
                            }
                       }, "1") != null)
                {
                    using (TFFinalizar fFinalizar = new TFFinalizar())
                    {
                        fFinalizar.rLoc = bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao;
                        if (fFinalizar.ShowDialog() == DialogResult.OK)
                            if (fFinalizar.rLoc != null)
                                try
                                {
                                    fFinalizar.rLoc.lItens.FindAll(p => p.St_processar).ForEach(p =>
                                    {
                                        if (p.Quantidade.Equals(decimal.Zero) && !p.Tp_tabela.Trim().Equals("4"))
                                        {
                                            TimeSpan total = CamadaDados.UtilData.Data_Servidor().Subtract(p.Dt_retirada.Value);
                                            p.Quantidade = p.Tp_tabela.Equals("2") ?
                                            Math.Round(decimal.Parse(total.TotalHours.ToString()), 2) : p.Tp_tabela.Equals("3") ?
                                            Math.Round(decimal.Parse(total.TotalDays.ToString()), 2) : p.Tp_tabela.Equals("4") ?
                                            Math.Round(decimal.Parse(total.TotalDays.ToString()), 2) / 30 : p.Tp_tabela.Equals("5") ?
                                            Math.Round(decimal.Parse(total.TotalDays.ToString()), 2) / 7 : p.Tp_tabela.Equals("6") ?
                                            Math.Round(decimal.Parse(total.TotalDays.ToString()), 2) / 15 : 0;
                                        }
                                        if (p.Quantidade > 0)
                                            p.BaseCalc = p.Quantidade;
                                        p.Dt_fechamento = CamadaDados.UtilData.Data_Servidor();
                                        p.Vl_desconto = p.Vl_desconto.Equals(decimal.Zero) ? CalcularDescEspecial(p.Vl_unitario, p.Cd_produto, p.Id_tabelastr) : p.Vl_desconto;
                                    });
                                    CamadaNegocio.Locacao.TCN_Locacao.FinalizarLocacao(fFinalizar.rLoc, null);
                                    LimparCampos();
                                    Id_locacao.Text = (bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).Id_locacaostr;
                                    afterBusca();
                                }
                                catch (Exception ex)
                                { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }

                    }
                }
                else
                    MessageBox.Show("Todos os itens da locação já foram finalizados!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BB_Novo_Click(object sender, EventArgs e)
        {
            afterNovo();
        }

        private void bb_tabela_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_tabela|Tabela|200;" +
                              "a.id_tabela|Id.Tabela|80";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { id_tabela },
                new CamadaDados.Locacao.Cadastros.TCD_CadTabPreco(),
               string.Empty);
        }

        private void id_tabela_Leave(object sender, EventArgs e)
        {
            string vParam = "a.id_tabela|=|'" + id_tabela.Text.Trim() + "'";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { id_tabela },
                                    new CamadaDados.Locacao.Cadastros.TCD_CadTabPreco());
        }

        private void gLocacao_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (gLocacao.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.NotSortable)
                return;
            if (bsLocacao.Count < 1)
                return;
            PropertyDescriptorCollection lP = TypeDescriptor.GetProperties(new CamadaDados.Locacao.TRegistro_Locacao());
            CamadaDados.Locacao.TList_Locacao lComparer;
            SortOrder direcao = SortOrder.None;
            if ((gLocacao.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None) ||
                (gLocacao.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending))
            {
                lComparer = new CamadaDados.Locacao.TList_Locacao(lP.Find(gLocacao.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Ascending);
                foreach (DataGridViewColumn c in gLocacao.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Ascending;
            }
            else
            {
                lComparer = new CamadaDados.Locacao.TList_Locacao(lP.Find(gLocacao.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Descending);
                foreach (DataGridViewColumn c in gLocacao.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Descending;
            }
            (bsLocacao.List as CamadaDados.Locacao.TList_Locacao).Sort(lComparer);
            bsLocacao.ResetBindings(false);
            gLocacao.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = direcao;
        }

        private void TFLanLocacao_FormClosing(object sender, FormClosingEventArgs e)
        {
            ShapeGrid.SaveShape(this, gLocacao);
            ShapeGrid.SaveShape(this, gItens);
        }

        private void btn_estornarFin_Click(object sender, EventArgs e)
        {
            if (bsLocacao.Current != null)
            {
                if (MessageBox.Show("Confirma o estorno da Finalização da Locação?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                    == DialogResult.Yes)
                    try
                    {
                        CamadaNegocio.Locacao.TCN_Locacao.EstornarFinalizacao(bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao, null);
                        MessageBox.Show("Locação estornada com sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        afterBusca();

                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            }
        }

        private void bb_alteraParcelas_Click(object sender, EventArgs e)
        {
            if (bsLocacao.Current != null)
            {
                if ((bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).SaldoFaturar.Equals(decimal.Zero))
                {
                    MessageBox.Show("Locação possui saldo zero a faturar!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if ((bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).lItens.Exists(p => p.Tp_tabela.Equals("4")))
                {
                    using (TFParcelas fParc = new TFParcelas())
                    {
                        (bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).lParcDel =
                                        (bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).lParc;
                        (bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).lItens.ForEach(p =>
                            p.Vl_desconto = p.Vl_desconto.Equals(decimal.Zero) ? CalcularDescEspecial(p.Vl_unitario, p.Cd_produto, p.Id_tabelastr) : p.Vl_desconto);
                        fParc.Vl_locacao = (bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).lItens.FindAll(p =>
                            p.Tp_tabela.Equals("4")).Sum(p => (p.QTDItem * (p.Vl_unitario - p.Vl_desconto))) +
                            (bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).lOutrasDesp.Sum(p => p.Vl_despesa);
                        fParc.St_bloquearValor = true;
                        fParc.rLocacao = bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao;
                        if (fParc.ShowDialog() == DialogResult.OK)
                            if (fParc.rLocacao.lParc.Count > 0)
                                try
                                {
                                    (bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).lParc = fParc.rLocacao.lParc;
                                    CamadaNegocio.Locacao.TCN_Locacao.Gravar(bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao, null);
                                    MessageBox.Show("Parcelas alteradas com sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    afterBusca();
                                }
                                catch (Exception ex)
                                { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                    }
                }
            }
        }

        private void btn_alterar_dt_prevdev_Click(object sender, EventArgs e)
        {
            if (bsItens.Current != null)
            {
                if (!string.IsNullOrEmpty((bsItens.Current as CamadaDados.Locacao.TRegistro_ItensLocacao).Dt_devolucaostr))
                {
                    MessageBox.Show("Não é possivel alterar data de previsão de devolução de item devolvido!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                using (TFAlterarData fAlterar = new TFAlterarData())
                {
                    fAlterar.pId_locacao = (bsItens.Current as CamadaDados.Locacao.TRegistro_ItensLocacao).Id_locacaostr;
                    fAlterar.pCd_produto = (bsItens.Current as CamadaDados.Locacao.TRegistro_ItensLocacao).Cd_produto;
                    fAlterar.pDs_produto = (bsItens.Current as CamadaDados.Locacao.TRegistro_ItensLocacao).Ds_produto;
                    fAlterar.pDt_locacaostr = (bsItens.Current as CamadaDados.Locacao.TRegistro_ItensLocacao).Dt_locacaostr;
                    fAlterar.pDt_prevdevstr = (bsItens.Current as CamadaDados.Locacao.TRegistro_ItensLocacao).Dt_prevdevstr;
                    fAlterar.pNr_Patrimonio = (bsItens.Current as CamadaDados.Locacao.TRegistro_ItensLocacao).Nr_Patrimonio;
                    fAlterar.pQuantidade = (bsItens.Current as CamadaDados.Locacao.TRegistro_ItensLocacao).Qtd_Patrimonio;
                    fAlterar.pQtd_Item = (bsItens.Current as CamadaDados.Locacao.TRegistro_ItensLocacao).QTDItem;
                    if (fAlterar.ShowDialog() == DialogResult.OK)
                        if (!string.IsNullOrEmpty(fAlterar.pDt_prevdevstr))
                            try
                            {
                                (bsItens.Current as CamadaDados.Locacao.TRegistro_ItensLocacao).Dt_prevdevstr = fAlterar.pDt_prevdevstr;
                                CamadaNegocio.Locacao.TCN_ItensLocacao.Gravar(bsItens.Current as CamadaDados.Locacao.TRegistro_ItensLocacao, null);
                                MessageBox.Show("Dt.Prev.Devolução alterada com sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                afterBusca();
                            }
                            catch (Exception ex)
                            { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
            }
        }

        private void btn_Inserir_ItemAcessorio_Click(object sender, EventArgs e)
        {
            if (bsItens.Current != null)
            {
                if (!string.IsNullOrEmpty((bsItens.Current as CamadaDados.Locacao.TRegistro_ItensLocacao).Dt_fechamentostr))
                {
                    MessageBox.Show("Não é possível adicionar acessórios em item finalizado!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                //Buscar Produtos no Cadastro Assistente de Venda
                CamadaDados.Estoque.Cadastros.TList_CadAssistenteVenda
                    lAssistente = CamadaNegocio.Estoque.Cadastros.TCN_CadAssistenteVenda.Busca((bsItens.Current as CamadaDados.Locacao.TRegistro_ItensLocacao).Cd_produto,
                                                                                                string.Empty,
                                                                                                null);
                if (lAssistente.Count > 0)
                {
                    using (Faturamento.TFAssistenteVenda fAssistente = new Faturamento.TFAssistenteVenda())
                    {
                        fAssistente.lAssistente = lAssistente;
                        fAssistente.Cd_empresa = (bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).Cd_empresa;
                        fAssistente.Nm_empresa = (bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).Nm_empresa;
                        if (fAssistente.ShowDialog() == DialogResult.OK)
                            if (fAssistente.lAssistente.Count > 0)
                            {
                                fAssistente.lAssistente.ForEach(p =>
                                {
                                    CamadaDados.Locacao.TRegistro_AcessoriosItem rAcessorios = new CamadaDados.Locacao.TRegistro_AcessoriosItem();
                                    rAcessorios.Cd_produto = p.CD_ProdVenda;
                                    rAcessorios.Ds_produto = p.DS_ProdVenda;
                                    rAcessorios.Quantidade = p.Quantidade;
                                    object obj = new CamadaDados.Faturamento.Cadastros.TCD_CFGCupomFiscal().BuscarEscalar(
                                                    new TpBusca[]
                                                    {
                                                        new TpBusca()
                                                        {
                                                            vNM_Campo = "a.cd_empresa",
                                                            vOperador = "=",
                                                            vVL_Busca = "'" + (bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).Cd_empresa.Trim() + "'"
                                                        }
                                                    }, "a.cd_tabelapreco");
                                    if (obj != null)
                                    {
                                        //Buscar Vl.Unitário
                                        object vl_precoacessorio = new CamadaDados.Estoque.TCD_LanPrecoItem().BuscarEscalar(
                                                                     new TpBusca[]
                                                                     {
                                                                    new TpBusca()
                                                                    {
                                                                        vNM_Campo = "a.cd_empresa",
                                                                        vOperador = "=",
                                                                        vVL_Busca = "'" + (bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).Cd_empresa.Trim() + "'"
                                                                    },
                                                                    new TpBusca()
                                                                    {
                                                                        vNM_Campo = "a.cd_produto",
                                                                        vOperador = "=",
                                                                        vVL_Busca = "'" + p.CD_ProdVenda.Trim() + "'"
                                                                    },
                                                                    new TpBusca()
                                                                    {
                                                                        vNM_Campo = "a.cd_tabelapreco",
                                                                        vOperador = "=",
                                                                        vVL_Busca = "'" + obj.ToString() + "'"
                                                                    }
                                                                     }, "a.Vl_PrecoVenda");
                                        rAcessorios.Vl_unitario = vl_precoacessorio == null || string.IsNullOrEmpty(vl_precoacessorio.ToString()) ? decimal.Zero : decimal.Parse(vl_precoacessorio.ToString());
                                    }
                                    (bsItens.Current as CamadaDados.Locacao.TRegistro_ItensLocacao).lAcessorio.Add(rAcessorios);
                                });
                                try
                                {

                                    CamadaNegocio.Locacao.TCN_ItensLocacao.Gravar(bsItens.Current as CamadaDados.Locacao.TRegistro_ItensLocacao, null);
                                    MessageBox.Show("Acessórios adicionados com sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    afterBusca();
                                }
                                catch (Exception ex)
                                { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                            }
                    }
                }
            }
        }

        private void BB_TrocaItemAcessorios_Click(object sender, EventArgs e)
        {
            if (bsAcessorios.Current != null)
            {
                if (!string.IsNullOrEmpty((bsItens.Current as CamadaDados.Locacao.TRegistro_ItensLocacao).Dt_devolucaostr))
                {
                    MessageBox.Show("Não é possível baixar acessório em item devolvido!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if ((bsAcessorios.Current as CamadaDados.Locacao.TRegistro_AcessoriosItem).Qtd_saldo.Equals(decimal.Zero))
                {
                    MessageBox.Show("Acessório sem saldo para baixar!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                try
                {
                    using (Componentes.TFQuantidade fQtd = new Componentes.TFQuantidade())
                    {
                        fQtd.Text = "QTD. Baixa";
                        fQtd.Vl_default = (bsAcessorios.Current as CamadaDados.Locacao.TRegistro_AcessoriosItem).Qtd_saldo;
                        if (fQtd.ShowDialog() == DialogResult.OK)
                            if (fQtd.Quantidade > decimal.Zero)
                                (bsAcessorios.Current as CamadaDados.Locacao.TRegistro_AcessoriosItem).Qtd_baixa =
                                    fQtd.Quantidade;
                            else
                            {
                                MessageBox.Show("Obrigatório informar QTD.Baixa!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                        else
                        {
                            MessageBox.Show("Obrigatório informar QTD.Baixa!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    }
                    InputBox ibp = new InputBox();
                    ibp.Text = "Motivo Baixa";
                    string motivo = ibp.ShowDialog();
                    if (string.IsNullOrEmpty(motivo))
                    {
                        MessageBox.Show("Obrigatório informar motivo!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    (bsAcessorios.Current as CamadaDados.Locacao.TRegistro_AcessoriosItem).Obs = motivo;
                    CamadaNegocio.Locacao.TCN_AcessoriosItem.BaixarAcessorios(bsAcessorios.Current as CamadaDados.Locacao.TRegistro_AcessoriosItem, null);
                    MessageBox.Show("Acessório baixado com sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    afterBusca();
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void bb_imprimirParcela_Click(object sender, EventArgs e)
        {
            if (bsLocacao.Current != null)
            {
                //recalcular parcelas 
                if ((bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).lItens.Exists(p => p.Tp_tabela.Equals("4")))
                {
                    if ((bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).St_registro.Trim().Equals("8"))
                    {
                        MessageBox.Show("Não é permitido imprimir parcelas de locação CANCELADA.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
                    {
                        FormRelPadrao.Relatorio Rel = new FormRelPadrao.Relatorio();
                        Rel.Altera_Relatorio = Altera_Relatorio;
                        BindingSource bs_valor = new BindingSource();
                        bs_valor.DataSource = new CamadaDados.Locacao.TList_Locacao() { bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao };
                        Rel.DTS_Relatorio = bs_valor;
                        Rel.Ident = "TFLanLocacao_Parcelas";
                        Rel.NM_Classe = "TFLanLocacao_Parcelas";
                        Rel.Modulo = "LOC";
                        fImp.St_enabled_enviaremail = true;
                        fImp.pCd_clifor = (bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).Cd_clifor;
                        fImp.pMensagem = "PARCELAS LOCAÇÃO";

                        //Buscar dados Empresa
                        CamadaDados.Diversos.TList_CadEmpresa lEmpresa =
                            CamadaNegocio.Diversos.TCN_CadEmpresa.Busca((bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).Cd_empresa,
                                                                        string.Empty,
                                                                        string.Empty,
                                                                        null);
                        //Duplicata Locacao
                        BindingSource BinDup = new BindingSource();
                        BinDup.DataSource = new CamadaDados.Financeiro.Duplicata.TCD_LanParcela().Select(
                                                new TpBusca[]
                                                    {
                                                        new TpBusca()
                                                        {
                                                            vNM_Campo = "isnull(dup.st_registro, 'A')",
                                                            vOperador = "<>",
                                                            vVL_Busca = "'C'"
                                                        },
                                                        new TpBusca()
                                                        {
                                                            vNM_Campo = string.Empty,
                                                            vOperador = "exists",
                                                            vVL_Busca = "(select 1 from TB_LOC_Locacao_X_Duplicata x " +
                                                                        "where x.cd_empresa = a.cd_empresa "+
                                                                        "and x.nr_lancto = a.nr_lancto " +
                                                                        "and x.cd_empresa = '" + (bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).Cd_empresa.Trim() + "' " +
                                                                        "and x.id_locacao = " + (bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).Id_locacaostr + ")"
                                                        }
                                                    }, 0, string.Empty, string.Empty, string.Empty);
                        Rel.Adiciona_DataSource("FINDUP", BinDup);
                        if (lEmpresa.Count > 0)
                            if (lEmpresa[0].Img != null)
                                Rel.Parametros_Relatorio.Add("IMAGEM_RELATORIO", lEmpresa[0].Img);

                        if (Altera_Relatorio)
                        {
                            Rel.Gera_Relatorio(string.Empty,
                                               fImp.pSt_imprimir,
                                               fImp.pSt_visualizar,
                                               fImp.pSt_enviaremail,
                                               fImp.pSt_exportPdf,
                                               fImp.Path_exportPdf,
                                               fImp.pDestinatarios,
                                               null,
                                               "PARCELAS LOCAÇÃO",
                                               fImp.pDs_mensagem);
                            Altera_Relatorio = false;
                        }
                        else
                            if ((fImp.ShowDialog() == DialogResult.OK) || (fImp.pSt_enviaremail))
                            Rel.Gera_Relatorio(string.Empty,
                                               fImp.pSt_imprimir,
                                               fImp.pSt_visualizar,
                                               fImp.pSt_enviaremail,
                                               fImp.pSt_exportPdf,
                                               fImp.Path_exportPdf,
                                               fImp.pDestinatarios,
                                               null,
                                               "PARCELAS LOCAÇÃO",
                                               fImp.pDs_mensagem);
                    }
                }
            }
        }

        private void gAcessorios_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null)
                if (e.ColumnIndex.Equals(0))
                {
                    if (e.Value.ToString().Trim().ToUpper().Equals("BAIXADO"))
                        gAcessorios.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Blue;
                    else
                        gAcessorios.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
                }
        }

        private void btn_Alterar_Frete_Click(object sender, EventArgs e)
        {
            if (bsItens.Count > 0)
            {
                if ((bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).lItens.Exists(p => !string.IsNullOrEmpty(p.Dt_devolucaostr) && !string.IsNullOrEmpty(p.Dt_fechamentostr)))
                {
                    MessageBox.Show("Não é possivel alterar valor despesas de locação com itens devolvidos!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if ((bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).St_registro.ToUpper().Equals("8"))
                {
                    MessageBox.Show("Não é possivel alterar valor despesas de locação CANCELADA!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                using (Componentes.TFQuantidade fQtd = new Componentes.TFQuantidade())
                {
                    fQtd.Vl_default = (bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).lItens.Sum(P => P.Vl_frete);
                    fQtd.Ds_label = "Vl.Despesas";
                    if (fQtd.ShowDialog() == DialogResult.OK)
                        if (fQtd.Quantidade > decimal.Zero)
                            try
                            {
                                //Ratear Frete
                                CamadaNegocio.Locacao.TCN_Locacao.RatearFrete(bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao, fQtd.Quantidade);
                                bsLocacao.ResetBindings(true);
                                //Gravar valor frete
                                (bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).lItens.ForEach(p => CamadaNegocio.Locacao.TCN_ItensLocacao.Gravar(p, null));
                                afterBusca();
                            }
                            catch (Exception ex)
                            { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
            }
        }

        private void bb_alteraLocacao_Click(object sender, EventArgs e)
        {
            if (bsLocacao.Current != null)
            {
                if (txtAlteraDtlocacao.Visible == false)
                {
                    if (!(bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).St_registro.ToUpper().Equals("0"))
                    {
                        MessageBox.Show("Somente é possivel alterar Dt.Locação AGUARDANDO ENTREGA e ENTREGA EXPIRADA!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    txtAlteraDtlocacao.Visible = true;
                    bb_alteraLocacao.Text = "CLIQUE AQUI PARA CONFIRMAR";
                    txtAlteraDtlocacao.Focus();
                }
                else
                {
                    //Testar se Data informada é válida
                    DateTime resultado = DateTime.MinValue;
                    if (DateTime.TryParse(txtAlteraDtlocacao.Text.Trim(), out resultado))
                    {
                        if ((bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).Dt_locacao >= Convert.ToDateTime(txtAlteraDtlocacao.Text))
                        {
                            MessageBox.Show("Data não pode ser menor que Dt.locação atual!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        if ((bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).lItens.Max(p => p.Dt_prevdev) <= Convert.ToDateTime(txtAlteraDtlocacao.Text))
                        {
                            MessageBox.Show("Data não pode ser maior que Dt.Previsão de Devolução!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        try
                        {
                            (bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).Dt_locacaostr = txtAlteraDtlocacao.Text;
                            CamadaNegocio.Locacao.TCN_Locacao.Gravar(bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao, null);
                            afterBusca();
                            txtAlteraDtlocacao.Visible = false;
                            bb_alteraLocacao.Text = "ALTERAR DT.LOCAÇÃO";
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                    }
                    else
                    {
                        MessageBox.Show("Data inválida!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtAlteraDtlocacao.Visible = false;
                        txtAlteraDtlocacao.Text = string.Empty;
                        bb_alteraLocacao.Text = "ALTERAR DT.LOCAÇÃO";
                    }
                }
            }
        }

        private void txtAlteraDtlocacao_TextChanged(object sender, EventArgs e)
        {
            if (!m_BackSpace)
            {
                if (txtAlteraDtlocacao.Text.Length == 2)
                {
                    txtAlteraDtlocacao.Text += "/";
                    txtAlteraDtlocacao.SelectionStart = 3;
                }
                else if (txtAlteraDtlocacao.Text.Length == 5)
                {
                    txtAlteraDtlocacao.Text += "/";
                    txtAlteraDtlocacao.SelectionStart = 6;
                }
                else if (txtAlteraDtlocacao.Text.Length == 10)
                {
                    txtAlteraDtlocacao.Text += " ";
                    txtAlteraDtlocacao.SelectionStart = 11;
                }
                else if (txtAlteraDtlocacao.Text.Length == 13)
                {
                    txtAlteraDtlocacao.Text += ":";
                    txtAlteraDtlocacao.SelectionStart = 14;
                }
            }
        }

        private void bb_gerarContrato_Click(object sender, EventArgs e)
        {
            if (bsLocacao.Current != null)
            {
                if (!st_contrato)
                {
                    MessageBox.Show("Usuário não tem permissão para gerar contrato!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if ((bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).lContrato.Count > 0 &&
                    (bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).lItens.Exists(p => p.Tp_tabela != "4"))
                {
                    MessageBox.Show("Somente pode ser gerada mais de um contrato se a locação for mensal!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if ((bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).St_registro.ToUpper().Equals("0"))
                {
                    MessageBox.Show("Não é permitido gerar contrato de locação AG.ENTREGA!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (MessageBox.Show("Confirma a geração do contrato?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                   == DialogResult.Yes)
                    try
                    {
                        InputBox ibp = new InputBox();
                        ibp.Text = "Obs Contrato";
                        string motivo = ibp.ShowDialog();
                        CamadaNegocio.Locacao.TCN_Locacao.GerarContrato(bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao, motivo, null);
                        MessageBox.Show("Contrato gerado com sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        bsLocacao_PositionChanged(this, new EventArgs());
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            }
        }

        private void bb_cancelarContrato_Click(object sender, EventArgs e)
        {
            if (bsContrato.Current != null)
            {
                if (!st_contrato)
                {
                    MessageBox.Show("Usuário não tem permissão cancelar contrato!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (MessageBox.Show("Confirma o cancelamento do contrato selecionado?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                    == DialogResult.Yes)
                    try
                    {
                        InputBox ibp = new InputBox();
                        ibp.Text = "Motivo Cancelamento Contrato";
                        string motivo = ibp.ShowDialog();
                        if (string.IsNullOrEmpty(motivo))
                        {
                            MessageBox.Show("Obrigatorio informar motivo de cancelamento!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        if (motivo.Trim().Length < 10)
                        {
                            MessageBox.Show("Motivo de cancelamento deve ter mais que 10 caracteres!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        (bsContrato.Current as CamadaDados.Locacao.TRegistro_Contrato).MotivoCanc = motivo;
                        (bsContrato.Current as CamadaDados.Locacao.TRegistro_Contrato).St_registro = "C";
                        (bsContrato.Current as CamadaDados.Locacao.TRegistro_Contrato).Logincanc = Utils.Parametros.pubLogin;
                        (bsContrato.Current as CamadaDados.Locacao.TRegistro_Contrato).Dt_cancelamento = CamadaDados.UtilData.Data_Servidor();
                        CamadaNegocio.Locacao.TCN_Contrato.Gravar(bsContrato.Current as CamadaDados.Locacao.TRegistro_Contrato, null);
                        MessageBox.Show("Contrato cancelado com sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        bsLocacao_PositionChanged(this, new EventArgs());
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            }
        }

        private void bb_imprimirContrato_Click(object sender, EventArgs e)
        {
            if (!st_contrato)
            {
                MessageBox.Show("Usuário não tem permissão para imprimir contrato!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if ((bsContrato.Current as CamadaDados.Locacao.TRegistro_Contrato).St_registro.ToUpper().Equals("C"))
            {
                MessageBox.Show("Não é permitido imprimir contrato CANCELADO!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            PrintContrato(true);
        }

        private void bb_excluirContrato_Click(object sender, EventArgs e)
        {
            if (bsContrato.Current != null)
            {
                if (!st_contrato)
                {
                    MessageBox.Show("Usuário não tem permissão excluir contrato!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (MessageBox.Show("Confirma o exclusão do contrato selecionado?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                    == DialogResult.Yes)
                    try
                    {
                        CamadaNegocio.Locacao.TCN_Contrato.Excluir(bsContrato.Current as CamadaDados.Locacao.TRegistro_Contrato, null);
                        MessageBox.Show("Contrato excluído com sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        bsLocacao_PositionChanged(this, new EventArgs());
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            }
        }

        private void bb_alterarObs_Click(object sender, EventArgs e)
        {
            if (bsContrato.Current != null)
            {
                if (!st_contrato)
                {
                    MessageBox.Show("Usuário não tem permissão para alterar contrato!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                try
                {
                    InputBox ibp = new InputBox();
                    ibp.Text = "Alterar Obs Contrato";
                    string motivo = ibp.ShowDialog();
                    (bsContrato.Current as CamadaDados.Locacao.TRegistro_Contrato).Obs = motivo;
                    CamadaNegocio.Locacao.TCN_Contrato.Gravar(bsContrato.Current as CamadaDados.Locacao.TRegistro_Contrato, null);
                    MessageBox.Show("Obs alterada com sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    bsLocacao_PositionChanged(this, new EventArgs());
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information); }

            }
        }

        private void mANUTENÇÃOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (bsItens.Current != null)
            {
                if ((bsItens.Current as CamadaDados.Locacao.TRegistro_ItensLocacao).St_ItemLocado.Equals("MANUTENÇÃO"))
                {
                    MessageBox.Show("Patrimonio já se encontra em manutenção. Possui ordem de serviço em aberto.", "Informativo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (new CamadaDados.Servicos.TCD_LanServico().BuscarEscalar(
                        new TpBusca[]
                        {
                            new TpBusca()
                            {
                                vNM_Campo = "a.CD_ProdutoOS",
                                vOperador = "=",
                                vVL_Busca = "'" + (bsItens.Current as CamadaDados.Locacao.TRegistro_ItensLocacao).Cd_produto.Trim() + "'"
                            },
                            new TpBusca()
                            {
                                vNM_Campo = "a.dt_finalizada",
                                vOperador = "is",
                                vVL_Busca = "null"
                            },
                            new TpBusca()
                            {
                                vNM_Campo = "isnull(a.st_os, 'AB')",
                                vOperador = "=",
                                vVL_Busca = "'AB'"
                            },
                            new TpBusca()
                            {
                                vNM_Campo = string.Empty,
                                vOperador = "not exists",
                                vVL_Busca = "(select 1 from TB_EST_Patrimonio x " +
                                            "where x.cd_patrimonio = a.CD_ProdutoOS " +
                                            "and x.quantidade > 1 ) "
                            }
                        }, "1") != null)
                {
                    MessageBox.Show("Existem manutenções não finalizadas para este Patrimônio!\r\n" +
                                    "Consulte a tela de Ordem de serviço e verifique para continuar!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (!string.IsNullOrEmpty((bsItens.Current as CamadaDados.Locacao.TRegistro_ItensLocacao).Dt_fechamentostr))
                {
                    MessageBox.Show("Não é possivel sustituir item com locação finalizada!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (!string.IsNullOrEmpty((bsItens.Current as CamadaDados.Locacao.TRegistro_ItensLocacao).Dt_devolucaostr))
                {
                    MessageBox.Show("Não é possivel sustituir item com locação devolvida!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                CamadaDados.Locacao.Cadastros.TRegistro_CFGLocacao rCfg = new CamadaDados.Locacao.Cadastros.TRegistro_CFGLocacao();
                rCfg = CamadaNegocio.Locacao.Cadastros.TCN_CFGLocacao.buscar((bsItens.Current as CamadaDados.Locacao.TRegistro_ItensLocacao).Cd_empresa, string.Empty, null)[0];
                if (rCfg == null)
                {
                    MessageBox.Show("Não existe CFG.Locação para empresa Nº" + (bsItens.Current as CamadaDados.Locacao.TRegistro_ItensLocacao).Cd_empresa.Trim(), "Mensagem",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                using (FLocOrdemServico fNovaOrdem = new FLocOrdemServico())
                {
                    CamadaDados.Servicos.TRegistro_LanServico rOs = new CamadaDados.Servicos.TRegistro_LanServico();
                    rOs.Cd_empresa = rCfg.Cd_empresa;
                    rOs.Nm_empresa = rCfg.Nm_empresa;
                    rOs.Tp_ordem = rCfg.Tp_ordem;
                    rOs.Ds_tipoordem = rCfg.Ds_tipoordem;
                    rOs.CD_ProdutoOS = (bsItens.Current as CamadaDados.Locacao.TRegistro_ItensLocacao).Cd_produto;
                    rOs.DS_ProdutoOS = (bsItens.Current as CamadaDados.Locacao.TRegistro_ItensLocacao).Ds_produto;
                    rOs.Nr_patrimonio = (bsItens.Current as CamadaDados.Locacao.TRegistro_ItensLocacao).Nr_Patrimonio;
                    rOs.Dt_abertura = CamadaDados.UtilData.Data_Servidor();
                    rOs.St_prioridade = "1";
                    rOs.Ds_observacoesgerais = "MANUTENÇÃO ITEM PATRIMÔNNIO " + (bsItens.Current as CamadaDados.Locacao.TRegistro_ItensLocacao).Nr_Patrimonio;
                    rOs.St_os = "AB";

                    //Etapa de abertura
                    CamadaDados.Servicos.Cadastros.TList_EtapaOrdem lEtapa =
                                new CamadaDados.Servicos.Cadastros.TCD_EtapaOrdem().Select(
                                    new TpBusca[]
                            {
                                new TpBusca()
                                {
                                    vNM_Campo = "isnull(a.st_iniciarOS, 'N')",
                                    vOperador = "=",
                                    vVL_Busca = "'S'"
                                },
                                new TpBusca()
                                {
                                    vNM_Campo = string.Empty,
                                    vOperador = "exists",
                                    vVL_Busca = "(select 1 from tb_ose_tpordem_x_etapa x "+
                                                "where x.id_etapa = a.id_etapa "+
                                                "and x.tp_ordem = " + rCfg.Tp_ordemstr + ")"
                                }
                            }, 1, string.Empty);
                    if (lEtapa.Count > 0)
                        rOs.lEvolucao.Add(
                            new CamadaDados.Servicos.TRegistro_LanServicoEvolucao()
                            {
                                Dt_inicio = rOs.Dt_abertura,
                                Id_etapa = lEtapa[0].Id_etapa,
                                Ds_evolucao = "ETAPA ABERTURA DA OS",
                                St_envterceiro = lEtapa[0].St_envterceirobool,
                                St_finalizarOS = lEtapa[0].St_finalizarOSbool,
                                St_iniciarOS = lEtapa[0].St_iniciarOSbool
                            });
                    else
                        throw new Exception("Não existe etapa de ABERTURA configurada para o tipo de ordem " + rCfg.Tp_ordemstr);

                    fNovaOrdem.lanServico = rOs;
                    if (fNovaOrdem.ShowDialog() == DialogResult.OK)
                    {
                        if (fNovaOrdem.lanServico != null)
                        {
                            TCN_LanServico.Gravar(fNovaOrdem.lanServico, null);
                            MessageBox.Show("Ordem de serviço gerada com sucesso.", "Informativo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            afterBusca();
                        }
                    }
                }
            }
        }

        private void aLTERARITEMLOCAÇÃOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (bsItens.Current != null)
            {
                if (!string.IsNullOrEmpty((bsItens.Current as CamadaDados.Locacao.TRegistro_ItensLocacao).Dt_fechamentostr))
                {
                    MessageBox.Show("Não é possivel sustituir item com locação finalizada!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (!string.IsNullOrEmpty((bsItens.Current as CamadaDados.Locacao.TRegistro_ItensLocacao).Dt_devolucaostr))
                {
                    MessageBox.Show("Não é possivel sustituir item com locação devolvida!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (MessageBox.Show("Deseja substituir o item desta Locação?", "Mensagem", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                       == DialogResult.Yes)
                {
                    try
                    {
                        BuscarProduto(null);
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
            }
        }

        private void bbExcluirAcessorio_Click(object sender, EventArgs e)
        {
            if (bsAcessorios.Current != null)
            {
                if (!string.IsNullOrEmpty((bsItens.Current as CamadaDados.Locacao.TRegistro_ItensLocacao).Dt_fechamentostr))
                {
                    MessageBox.Show("Não é possível excluir acessório de item finalizado!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if ((bsAcessorios.Current as CamadaDados.Locacao.TRegistro_AcessoriosItem).Qtd_baixa > decimal.Zero)
                {
                    MessageBox.Show("Não é permitido excluir acessório BAIXADO.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (MessageBox.Show("Confirma exclusão do acessório selecionado?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                    == DialogResult.Yes)
                {
                    if (!CamadaNegocio.Diversos.TCN_Usuario_RegraEspecial.ValidaRegra(Utils.Parametros.pubLogin, "PERMITIR EXCLUIR ACESSÓRIO", null))
                    {
                        using (Parametros.Diversos.TFRegraUsuario fValida = new Parametros.Diversos.TFRegraUsuario())
                        {
                            fValida.Ds_regraespecial = "PERMITIR EXCLUIR ACESSÓRIO";
                            if (fValida.ShowDialog() != DialogResult.OK)
                                return;
                        }
                    }
                    try
                    {
                        CamadaNegocio.Locacao.TCN_AcessoriosItem.Excluir(bsAcessorios.Current as CamadaDados.Locacao.TRegistro_AcessoriosItem, null);
                        MessageBox.Show("Acessório excluido com sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        afterBusca();
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
            }
        }

        private void btn_Inserir_Item_Click(object sender, EventArgs e)
        {
            if (bsLocacao.Current != null)
                using (TFHistorico fHist = new TFHistorico())
                {
                    if (fHist.ShowDialog() == DialogResult.OK)
                        if (!string.IsNullOrEmpty(fHist.pDs_mensagem))
                            try
                            {
                                CamadaDados.Locacao.TRegistro_Historico rHist =
                                    new CamadaDados.Locacao.TRegistro_Historico();
                                rHist.Cd_empresa = (bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).Cd_empresa;
                                rHist.Id_locacao = (bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).Id_locacao;
                                rHist.Login = Utils.Parametros.pubLogin;
                                rHist.Dt_historico = CamadaDados.UtilData.Data_Servidor();
                                rHist.Ds_historico = fHist.pDs_mensagem;
                                CamadaNegocio.Locacao.TCN_Historico.Gravar(rHist, null);
                                MessageBox.Show("Histórico gravado com sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                tcDetalhes_SelectedIndexChanged(this, new EventArgs());
                            }
                            catch (Exception ex)
                            { MessageBox.Show(ex.Message.Trim(), "erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
        }

        private void tcDetalhes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (bsLocacao.Current != null)
            {
                if (tcDetalhes.SelectedTab.Equals(tpHist))
                {
                    (bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).lHist =
                        CamadaNegocio.Locacao.TCN_Historico.buscar((bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).Cd_empresa,
                                                                   (bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).Id_locacaostr,
                                                                   string.Empty,
                                                                   null);
                    bsLocacao.ResetCurrentItem();
                }
            }

        }

        private void gHist_DoubleClick(object sender, EventArgs e)
        {
            VisualizarHist();
        }

        private void bb_visualizar_Click(object sender, EventArgs e)
        {
            VisualizarHist();
        }

        private void bb_inserirDespesa_Click(object sender, EventArgs e)
        {
            if (bsLocacao.Current != null)
                using (TFOutrasDesp fDesp = new TFOutrasDesp())
                {
                    if (fDesp.ShowDialog() == DialogResult.OK)
                        if (fDesp.rDesp != null)
                            try
                            {
                                fDesp.rDesp.Cd_empresa = (bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).Cd_empresa;
                                fDesp.rDesp.Id_locacao = (bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).Id_locacao;
                                fDesp.rDesp.Login = Utils.Parametros.pubLogin;
                                CamadaNegocio.Locacao.TCN_OutrasDesp.Gravar(fDesp.rDesp, null);
                                MessageBox.Show("Despesa gravada com sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                bsLocacao_PositionChanged(this, new EventArgs());
                            }
                            catch (Exception ex)
                            { MessageBox.Show(ex.Message.Trim(), "erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
        }

        private void bb_excluirDespesa_Click(object sender, EventArgs e)
        {
            if (bsOutrasDesp.Current != null)
                if (MessageBox.Show("Confirma a exclusão da despesa selecionada?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                    == DialogResult.Yes)
                    try
                    {
                        CamadaNegocio.Locacao.TCN_OutrasDesp.Excluir(bsOutrasDesp.Current as CamadaDados.Locacao.TRegistro_OutrasDesp, null);
                        MessageBox.Show("Despesa excluída com sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        bsLocacao_PositionChanged(this, new EventArgs());
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void bbImpRecibo_Click(object sender, EventArgs e)
        {
            if (BS_Duplicata.Current != null)
            {
                if ((BS_Duplicata.Current as CamadaDados.Financeiro.Duplicata.TRegistro_LanDuplicata).St_registro.Trim().ToUpper().Equals("C"))
                {
                    MessageBox.Show("Não é permitido imprimir recibo duplicata CANCELADA.",
                                    "Mensagem",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                    return;
                }
                using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
                {
                    FormRelPadrao.Relatorio Rel = new FormRelPadrao.Relatorio();
                    Rel.Altera_Relatorio = Altera_Relatorio;
                    BindingSource bs_valor = new BindingSource();
                    bs_valor.DataSource = new CamadaDados.Financeiro.Duplicata.TList_RegLanDuplicata { BS_Duplicata.Current as CamadaDados.Financeiro.Duplicata.TRegistro_LanDuplicata };
                    Rel.DTS_Relatorio = bs_valor;
                    Rel.Ident = "RECIBO_LOCACAO";
                    Rel.NM_Classe = "TFLanLocacao_Parcelas";
                    Rel.Modulo = "LOC";
                    fImp.St_enabled_enviaremail = true;
                    fImp.pCd_clifor = (bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).Cd_clifor;
                    fImp.pMensagem = "RECIBO LOCAÇÃO";

                    //Buscar dados Empresa
                    BindingSource bsEmp = new BindingSource();
                    bsEmp.DataSource =
                        CamadaNegocio.Diversos.TCN_CadEmpresa.Busca((bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).Cd_empresa,
                                                                    string.Empty,
                                                                    string.Empty,
                                                                    null);
                    Rel.Adiciona_DataSource("EMPRESA", bsEmp);
                    if (bsEmp.Current != null)
                        if ((bsEmp.Current as CamadaDados.Diversos.TRegistro_CadEmpresa).Img != null)
                            Rel.Parametros_Relatorio.Add("IMAGEM_RELATORIO", (bsEmp.Current as CamadaDados.Diversos.TRegistro_CadEmpresa).Img);
                    //Buscar dados do cliente
                    BindingSource bsClifor = new BindingSource();
                    bsClifor.DataSource = CamadaNegocio.Financeiro.Cadastros.TCN_CadClifor.Busca_Clifor((BS_Duplicata.Current as CamadaDados.Financeiro.Duplicata.TRegistro_LanDuplicata).Cd_clifor,
                                                                                                        string.Empty,
                                                                                                        string.Empty,
                                                                                                        string.Empty,
                                                                                                        string.Empty,
                                                                                                        string.Empty,
                                                                                                        string.Empty,
                                                                                                        string.Empty,
                                                                                                        string.Empty,
                                                                                                        string.Empty,
                                                                                                        false,
                                                                                                        string.Empty,
                                                                                                        string.Empty,
                                                                                                        string.Empty,
                                                                                                        string.Empty,
                                                                                                        string.Empty,
                                                                                                        string.Empty,
                                                                                                        1,
                                                                                                        null);
                    Rel.Adiciona_DataSource("BSCLIFOR", bsClifor);
                    //Endereco Cliente
                    BindingSource bsEnd = new BindingSource();
                    bsEnd.DataSource = CamadaNegocio.Financeiro.Cadastros.TCN_CadEndereco.Buscar((BS_Duplicata.Current as CamadaDados.Financeiro.Duplicata.TRegistro_LanDuplicata).Cd_clifor,
                                                                                                 (BS_Duplicata.Current as CamadaDados.Financeiro.Duplicata.TRegistro_LanDuplicata).Cd_endereco,
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
                                                                                                 string.Empty,
                                                                                                 1,
                                                                                                 null);
                    Rel.Adiciona_DataSource("BSEND", bsEnd);
                    //Buscar Data Vencimento
                    object obj = new CamadaDados.Financeiro.Duplicata.TCD_LanParcela().BuscarEscalar(
                                    new TpBusca[]
                                    {
                                        new TpBusca { vNM_Campo = "a.cd_empresa", vOperador = "=", vVL_Busca = "'" + (BS_Duplicata.Current as CamadaDados.Financeiro.Duplicata.TRegistro_LanDuplicata).Cd_empresa.Trim() + "'" },
                                        new TpBusca { vNM_Campo = "a.nr_lancto", vOperador = "=", vVL_Busca = (BS_Duplicata.Current as CamadaDados.Financeiro.Duplicata.TRegistro_LanDuplicata).Nr_lancto.ToString() }
                                    }, "a.dt_vencto");
                    Rel.Parametros_Relatorio.Add("DT_VENCIMENTO", DateTime.Parse(obj.ToString()).ToString("dd/MM/yyyy"));
                    //Buscar Boleto
                    obj = new CamadaDados.Financeiro.Bloqueto.TCD_Titulo().BuscarEscalar(
                            new TpBusca[]
                            {
                                new TpBusca { vNM_Campo = "a.cd_empresa", vOperador = "=", vVL_Busca = "'" + (BS_Duplicata.Current as CamadaDados.Financeiro.Duplicata.TRegistro_LanDuplicata).Cd_empresa.Trim() + "'" },
                                new TpBusca { vNM_Campo = "a.nr_lancto", vOperador = "=", vVL_Busca = (BS_Duplicata.Current as CamadaDados.Financeiro.Duplicata.TRegistro_LanDuplicata).Nr_lancto.ToString() }
                            }, "a.nossonumero");
                    Rel.Parametros_Relatorio.Add("NOSSO_NUMERO", obj == null ? string.Empty : obj.ToString());
                    //Buscar Nr Recibo
                    obj = new CamadaDados.Locacao.TCD_Locacao_X_Duplicata().BuscarEscalar(
                            new TpBusca[]
                            {
                                new TpBusca { vNM_Campo = "a.cd_empresa", vOperador = "=", vVL_Busca = "'" + (BS_Duplicata.Current as CamadaDados.Financeiro.Duplicata.TRegistro_LanDuplicata).Cd_empresa.Trim() + "'" },
                                new TpBusca { vNM_Campo = "a.nr_lancto", vOperador = "=", vVL_Busca = (BS_Duplicata.Current as CamadaDados.Financeiro.Duplicata.TRegistro_LanDuplicata).Nr_lancto.ToString() },
                                new TpBusca { vNM_Campo = "a.id_locacao", vOperador = "=", vVL_Busca = (bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).Id_locacaostr }
                            }, "a.nr_recibo");
                    Rel.Parametros_Relatorio.Add("NR_RECIBO", obj.ToString());
                    if (Altera_Relatorio)
                    {
                        Rel.Gera_Relatorio(string.Empty,
                                            fImp.pSt_imprimir,
                                            fImp.pSt_visualizar,
                                            fImp.pSt_enviaremail,
                                            fImp.pSt_exportPdf,
                                            fImp.Path_exportPdf,
                                            fImp.pDestinatarios,
                                            null,
                                            "RECIBO LOCAÇÃO",
                                            fImp.pDs_mensagem);
                        Altera_Relatorio = false;
                    }
                    else
                        if ((fImp.ShowDialog() == DialogResult.OK) || (fImp.pSt_enviaremail))
                        Rel.Gera_Relatorio(string.Empty,
                                            fImp.pSt_imprimir,
                                            fImp.pSt_visualizar,
                                            fImp.pSt_enviaremail,
                                            fImp.pSt_exportPdf,
                                            fImp.Path_exportPdf,
                                            fImp.pDestinatarios,
                                            null,
                                            "RECIBO LOCAÇÃO",
                                            fImp.pDs_mensagem);
                }
            }
        }

        private void bb_alterarVeiculoMotorista_Click(object sender, EventArgs e)
        {
            if (bsColetaEntrega.Current == null)
                return;
            else if (string.IsNullOrEmpty((bsColetaEntrega.Current as CamadaDados.Locacao.TRegistro_ColetaEntrega).Id_veiculostr) ||
                     string.IsNullOrEmpty((bsColetaEntrega.Current as CamadaDados.Locacao.TRegistro_ColetaEntrega).Cd_motorista))
            {
                MessageBox.Show("Para alterar veículo/ motorista é necessário que tenha sido informado no lançamento da locação.", "Informativo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (bsLocacao.Current == null) return;
            else if (!(bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).St_registro.Equals("1") &&
                     !(bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).St_registro.Equals("4"))//Em Entrega/Em Coleta
            {
                MessageBox.Show("É possível alterar veículo/ motorista apenas de locações com status: EM ENTREGA ou EM COLETA", "Informativo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (TFInformarVeiculo fInforme = new TFInformarVeiculo())
            {
                fInforme.Cd_empresa = (bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).Cd_empresa;
                fInforme.IdLocacao = (bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).Id_locacaostr;
                if (fInforme.ShowDialog() == DialogResult.OK)
                {
                    if (!string.IsNullOrEmpty(fInforme.pCd_motorista) &&
                        !string.IsNullOrEmpty(fInforme.pId_veiculo))
                    {
                        (bsColetaEntrega.Current as CamadaDados.Locacao.TRegistro_ColetaEntrega).Id_veiculostr = fInforme.pId_veiculo;
                        (bsColetaEntrega.Current as CamadaDados.Locacao.TRegistro_ColetaEntrega).Cd_motorista = fInforme.pCd_motorista;
                        (bsColetaEntrega.Current as CamadaDados.Locacao.TRegistro_ColetaEntrega).Ds_obs = fInforme.pObs;
                        CamadaNegocio.Locacao.TCN_ColetaEntrega.GravarColEnt((bsColetaEntrega.Current as CamadaDados.Locacao.TRegistro_ColetaEntrega), null);
                        afterBusca();
                    }
                }
            }
        }

        private void BB_AlterarFrete_Click(object sender, EventArgs e)
        {
            if (bsLocacao.Current == null)
                return;
            else if (!(bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).St_registro.Equals("0"))
            {
                MessageBox.Show("Apenas é permitido alterar frete para locações que estão com status AGUARDANDO ENTREGA.", "Informativo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if ((bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).lItens.Count.Equals(0))
            {
                MessageBox.Show("A locação não possui itens, não será possição alterar a forma de frete, pois é obrigatório itens para ratear o valor.", "Informativo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (MessageBox.Show("Confirma alteração da forma de frete para a locação selecionada?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                return;

            if ((bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).Tp_frete.Equals("C"))
            {
                using (Componentes.TFQuantidade fValorFrete = new Componentes.TFQuantidade())
                {
                    fValorFrete.Casas_decimais = 0;
                    fValorFrete.St_permitirValorZero = false;
                    fValorFrete.Ds_label = "Valor frete";
                    fValorFrete.Vl_default = fValorFrete.Vl_Minimo = 0;
                    if (fValorFrete.ShowDialog() == DialogResult.OK)
                    {
                        //Rateio do valor frete informado como vl.despesa para os itens
                        decimal vlRateado = fValorFrete.Quantidade / (bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).lItens.Count;
                        (bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).lItens.ForEach(p => p.Vl_frete = vlRateado);
                        (bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).Tp_frete = "E";
                        try
                        {
                            CamadaNegocio.Locacao.TCN_Locacao.Gravar((bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao), null);
                            MessageBox.Show("Forma de frete alterada com sucesso.", "Informativo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex) { MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    }
                }
            }
            else if ((bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).Tp_frete.Equals("E"))
            {
                (bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).lItens.ForEach(p => p.Vl_frete = 0);
                (bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).Tp_frete = "C";
                try
                {
                    CamadaNegocio.Locacao.TCN_Locacao.Gravar((bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao), null);
                    MessageBox.Show("Forma de frete alterada com sucesso.", "Informativo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex) { MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
            }

            afterBusca();
        }

        private void bbCheckList_Click(object sender, EventArgs e)
        {
            PrintCheckList();
        }

        private void bbAltEndEntrega_Click(object sender, EventArgs e)
        {
            if (bsLocacao.Current != null)
            {
                if ((bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).St_registro.Equals("7"))
                {
                    MessageBox.Show("Não é permitido alterar endereço de entrega de locação com status DEVOLVIDO.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if ((bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).St_registro.Equals("8"))
                {
                    MessageBox.Show("Não é permitido alterar endereço de entrega de locação com status CANCELADO.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                using (TFAltEndEntrega fAlt = new TFAltEndEntrega())
                {
                    fAlt.Locacao = bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao;
                    if (fAlt.ShowDialog() == DialogResult.OK)
                        try
                        {
                            fAlt.Locacao.Loginaltend = Utils.Parametros.pubLogin;
                            new CamadaDados.Locacao.TCD_Locacao().Gravar(fAlt.Locacao);
                            MessageBox.Show("Endereço entrega alterado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LimparCampos();
                            Id_locacao.Text = fAlt.Locacao.Id_locacaostr;
                            afterBusca();
                        }
                        catch (Exception ex)
                        { MessageBox.Show("Erro alterar endereço entrega: " + ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
            }
        }
    }
}
