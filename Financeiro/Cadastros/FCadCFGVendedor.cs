using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Financeiro.Cadastros
{
    public partial class TFCadCFGVendedor : Form
    {
        public string Cd_vendedor
        { get; set; }
        public string Nm_vendedor
        { get; set; }

        public TFCadCFGVendedor()
        {
            InitializeComponent();
            Cd_vendedor = string.Empty;
            Nm_vendedor = string.Empty;
        }

        private void BuscarVendEmpresa()
        {
            bsVendEmpresa.DataSource = CamadaNegocio.Faturamento.Cadastros.TCN_Vendedor_X_Empresa.Buscar(cd_vendedor.Text,
                                                                                                         string.Empty,
                                                                                                         null);
        }

        private void BuscarVendCondPgto()
        {
            bsVendCondPgto.DataSource = CamadaNegocio.Faturamento.Cadastros.TCN_Vendedor_X_CondPgto.Buscar(cd_vendedor.Text,
                                                                                                           string.Empty,
                                                                                                           null);
        }

        private void BuscarVendTabPreco()
        {
            bsVendTabPreco.DataSource = CamadaNegocio.Faturamento.Cadastros.TCN_Vendedor_X_TabelaPreco.Buscar(cd_vendedor.Text,
                                                                                                              string.Empty,
                                                                                                              null);
        }

        private void BuscarVendRegVenda()
        {
            bsVendRegVenda.DataSource = CamadaNegocio.Faturamento.Cadastros.TCN_Vendedor_X_RegiaoVenda.Buscar(cd_vendedor.Text,
                                                                                                              string.Empty,
                                                                                                              null);
        }

        private void BuscarVendGrupoProd()
        {
            bsVendGrupoProd.DataSource = CamadaNegocio.Faturamento.Cadastros.TCN_Vendedor_X_GrupoProd.Buscar(cd_vendedor.Text,
                                                                                                             string.Empty,
                                                                                                             null);
        }

        private void BuscarDescontoVend()
        {
            bsDescontoVendedor.DataSource = CamadaNegocio.Faturamento.Cadastros.TCN_DescontoVendedor.Buscar(cd_vendedor.Text,
                                                                                                            string.Empty,
                                                                                                            string.Empty,
                                                                                                            string.Empty,
                                                                                                            null);
        }
        private void BuscarGerenteVend()
        {
            bsGerenteVend.DataSource = CamadaNegocio.Faturamento.Cadastros.TCN_Gerente_X_Vendedor.Buscar(cd_vendedor.Text,
                                                                                                         string.Empty,
                                                                                                         string.Empty,
                                                                                                         null);
        }

        private void TFCadCFGVendedor_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, gCondPgto);
            Utils.ShapeGrid.RestoreShape(this, gRegiaoVenda);
            Utils.ShapeGrid.RestoreShape(this, gTabPreco);
            Utils.ShapeGrid.RestoreShape(this, gVendCondPgto);
            Utils.ShapeGrid.RestoreShape(this, gVendCondPgtoAux);
            Utils.ShapeGrid.RestoreShape(this, gVendRegVenda);
            Utils.ShapeGrid.RestoreShape(this, gVendRegVendaAux);
            Utils.ShapeGrid.RestoreShape(this, gVendTabPreco);
            Utils.ShapeGrid.RestoreShape(this, gVendTabPrecoAux);
            Utils.ShapeGrid.RestoreShape(this, gVendGrupoProd);
            Utils.ShapeGrid.RestoreShape(this, gGerenteVend);
            Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            cd_vendedor.Text = Cd_vendedor;
            nm_vendedor.Text = Nm_vendedor;
            tcCentral_SelectedIndexChanged(this, new EventArgs());
        }

        private void tcCentral_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tcCentral.SelectedTab.Equals(tpVendEmpresa))
                BuscarVendEmpresa();
            else if (tcCentral.SelectedTab.Equals(tpVendCondPgto))
                BuscarVendCondPgto();
            else if (tcCentral.SelectedTab.Equals(tpVendTabPreco))
                BuscarVendTabPreco();
            else if (tcCentral.SelectedTab.Equals(tpVendRegVenda))
                BuscarVendRegVenda();
            else if (tcCentral.SelectedTab.Equals(tpVendGrupoProd))
                BuscarVendGrupoProd();
            else if (tcCentral.SelectedTab.Equals(tpDescontoVend))
                BuscarDescontoVend();
            else if (tcCentral.SelectedTab.Equals(tpGerenteVend))
                BuscarGerenteVend();
        }

        private void BB_Fechar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void TFCadCFGVendedor_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, gCondPgto);
            Utils.ShapeGrid.SaveShape(this, gRegiaoVenda);
            Utils.ShapeGrid.SaveShape(this, gTabPreco);
            Utils.ShapeGrid.SaveShape(this, gVendCondPgto);
            Utils.ShapeGrid.SaveShape(this, gVendCondPgtoAux);
            Utils.ShapeGrid.SaveShape(this, gVendRegVenda);
            Utils.ShapeGrid.SaveShape(this, gVendRegVendaAux);
            Utils.ShapeGrid.SaveShape(this, gVendTabPreco);
            Utils.ShapeGrid.SaveShape(this, gVendTabPrecoAux);
            Utils.ShapeGrid.SaveShape(this, gVendGrupoProd);
            Utils.ShapeGrid.SaveShape(this, gGerenteVend);
        }

        private void bb_novoEmp_Click(object sender, EventArgs e)
        {
            using (TFVendedorEmpresa fVend = new TFVendedorEmpresa())
            {
                fVend.Cd_vendedor = cd_vendedor.Text;
                if(fVend.ShowDialog() == DialogResult.OK)
                    if(fVend.rVend != null)
                        try
                        {
                            CamadaNegocio.Faturamento.Cadastros.TCN_Vendedor_X_Empresa.Gravar(fVend.rVend, null);
                            MessageBox.Show("Configuração gravada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            BuscarVendEmpresa();
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim()); }
            }
        }

        private void ts_btn_Alterar_Endereco_Click(object sender, EventArgs e)
        {
            if(bsVendEmpresa.Current != null)
                using (TFVendedorEmpresa fVend = new TFVendedorEmpresa())
                {
                    fVend.rVend = bsVendEmpresa.Current as CamadaDados.Faturamento.Cadastros.TRegistro_Vendedor_X_Empresa;
                    if(fVend.ShowDialog() == DialogResult.OK)
                        try
                        {
                            CamadaNegocio.Faturamento.Cadastros.TCN_Vendedor_X_Empresa.Gravar(fVend.rVend, null);
                            MessageBox.Show("Configuração alterada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            BuscarVendEmpresa();
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim()); }
                }
        }

        private void ts_btn_Deletar_Endereco_Click(object sender, EventArgs e)
        {
            if(bsVendEmpresa.Current != null)
                if(MessageBox.Show("Confirma exclusão da configuração?", "Pergunta", MessageBoxButtons.YesNo,
                     MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    try
                    {
                        CamadaNegocio.Faturamento.Cadastros.TCN_Vendedor_X_Empresa.Excluir(bsVendEmpresa.Current as CamadaDados.Faturamento.Cadastros.TRegistro_Vendedor_X_Empresa, null);
                        MessageBox.Show("Configuração excluida com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        bsVendEmpresa.RemoveCurrent();
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim()); }
        }

        private void bb_novoCond_Click(object sender, EventArgs e)
        {
            using (TFCadVendedorCondPgto fVend = new TFCadVendedorCondPgto())
            {
                fVend.Cd_vendedor = cd_vendedor.Text;
                if(fVend.ShowDialog() == DialogResult.OK)
                    if(fVend.rVend != null)
                        try
                        {
                            CamadaNegocio.Faturamento.Cadastros.TCN_Vendedor_X_CondPgto.Gravar(fVend.rVend, null);
                            MessageBox.Show("Registro gravado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            BuscarVendCondPgto();
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void bb_alterarCond_Click(object sender, EventArgs e)
        {
            if(bsVendCondPgto.Current != null)
                using (TFCadVendedorCondPgto fVend = new TFCadVendedorCondPgto())
                {
                    fVend.rVend = bsVendCondPgto.Current as CamadaDados.Faturamento.Cadastros.TRegistro_Vendedor_X_CondPgto;
                    if(fVend.ShowDialog() == DialogResult.OK)
                        try
                        {
                            CamadaNegocio.Faturamento.Cadastros.TCN_Vendedor_X_CondPgto.Gravar(fVend.rVend, null);
                            MessageBox.Show("Registro alterado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            BuscarVendCondPgto();
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
        }

        private void bb_excluiCond_Click(object sender, EventArgs e)
        {
            if(bsVendCondPgto.Current !=null)
                if (MessageBox.Show("Confirma exclusão do registro selecionado?", "Mensagem", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                         MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    try
                    {
                        CamadaNegocio.Faturamento.Cadastros.TCN_Vendedor_X_CondPgto.Excluir(bsVendCondPgto.Current as CamadaDados.Faturamento.Cadastros.TRegistro_Vendedor_X_CondPgto, null);
                        MessageBox.Show("Registro excluido com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        BuscarVendCondPgto();
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void bb_novoTab_Click(object sender, EventArgs e)
        {
            using (TFVendedorTabPreco fVend = new TFVendedorTabPreco())
            {
                fVend.Cd_vendedor = cd_vendedor.Text;
                if(fVend.ShowDialog() == DialogResult.OK)
                    if(fVend.rVend != null)
                        try
                        {
                            CamadaNegocio.Faturamento.Cadastros.TCN_Vendedor_X_TabelaPreco.Gravar(fVend.rVend, null);
                            MessageBox.Show("Registro gravado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            BuscarVendTabPreco();
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void bb_alterarTab_Click(object sender, EventArgs e)
        {
            if(bsVendTabPreco.Current !=null)
                using (TFVendedorTabPreco fVend = new TFVendedorTabPreco())
                {
                    fVend.rVend = bsVendTabPreco.Current as CamadaDados.Faturamento.Cadastros.TRegistro_Vendedor_X_TabelaPreco;
                    if(fVend.ShowDialog() == DialogResult.OK)
                        try
                        {
                            CamadaNegocio.Faturamento.Cadastros.TCN_Vendedor_X_TabelaPreco.Gravar(fVend.rVend, null);
                            MessageBox.Show("Registro alterado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            BuscarVendTabPreco();
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
        }

        private void bb_excluiTab_Click(object sender, EventArgs e)
        {
            if(bsVendTabPreco.Current != null)
                if (MessageBox.Show("Confirma exclusão do registro selecionado?", "Mensagem", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                         MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    try
                    {
                        CamadaNegocio.Faturamento.Cadastros.TCN_Vendedor_X_TabelaPreco.Excluir(bsVendTabPreco.Current as CamadaDados.Faturamento.Cadastros.TRegistro_Vendedor_X_TabelaPreco, null);
                        MessageBox.Show("Registro excluido com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        BuscarVendTabPreco();
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void bb_novoReg_Click(object sender, EventArgs e)
        {
            using (TFVendedorRegVenda fVend = new TFVendedorRegVenda())
            {
                if(fVend.ShowDialog() == DialogResult.OK)
                    if(fVend.lReg != null)
                        try
                        {
                            List<CamadaDados.Faturamento.Cadastros.TRegistro_Vendedor_X_RegiaoVenda> lReg =
                                new List<CamadaDados.Faturamento.Cadastros.TRegistro_Vendedor_X_RegiaoVenda>();
                            fVend.lReg.ForEach(p=> lReg.Add(new CamadaDados.Faturamento.Cadastros.TRegistro_Vendedor_X_RegiaoVenda()
                            {
                                Cd_vendedor = cd_vendedor.Text,
                                Id_regiao = p.Id_Regiao
                            }));
                            CamadaNegocio.Faturamento.Cadastros.TCN_Vendedor_X_RegiaoVenda.Gravar(lReg, null);
                            MessageBox.Show("Registros gravados com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            BuscarVendRegVenda();
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void bb_excluiReg_Click(object sender, EventArgs e)
        {
            if(bsVendRegVenda != null)
                if (MessageBox.Show("Confirma exclusão do registro selecionado?", "Mensagem", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                         MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    try
                    {
                        CamadaNegocio.Faturamento.Cadastros.TCN_Vendedor_X_RegiaoVenda.Excluir(bsVendRegVenda.Current as CamadaDados.Faturamento.Cadastros.TRegistro_Vendedor_X_RegiaoVenda, null);
                        MessageBox.Show("Registro excluido com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        BuscarVendRegVenda();
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void bb_incluiGrupoProd_Click(object sender, EventArgs e)
        {
            using (TFVendedorGrupoProd fVend = new TFVendedorGrupoProd())
            {
                fVend.pCd_vendedor = cd_vendedor.Text;
                if (fVend.ShowDialog() == DialogResult.OK)
                    if (fVend.rVend != null)
                        try
                        {
                            CamadaNegocio.Faturamento.Cadastros.TCN_Vendedor_X_GrupoProd.Gravar(fVend.rVend, null);
                            MessageBox.Show("Registro gravado com sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            BuscarVendGrupoProd();
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void bb_alterarGrupoProd_Click(object sender, EventArgs e)
        {
            if (bsVendGrupoProd.Current != null)
                using (TFVendedorGrupoProd fVend = new TFVendedorGrupoProd())
                {
                    fVend.rVend = bsVendGrupoProd.Current as CamadaDados.Faturamento.Cadastros.TRegistro_Vendedor_X_GrupoProd;
                    if (fVend.ShowDialog() == DialogResult.OK)
                        if (fVend.rVend != null)
                            try
                            {
                                CamadaNegocio.Faturamento.Cadastros.TCN_Vendedor_X_GrupoProd.Gravar(fVend.rVend, null);
                                MessageBox.Show("Registro alterado com sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                BuscarVendGrupoProd();
                            }
                            catch (Exception ex)
                            { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
        }

        private void bb_excluirGrupoProd_Click(object sender, EventArgs e)
        {
            if (bsVendGrupoProd.Current != null)
                if (MessageBox.Show("Confirma exclusão do registro selecionado?", "Mensagem", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                         MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    try
                    {
                        CamadaNegocio.Faturamento.Cadastros.TCN_Vendedor_X_GrupoProd.Excluir(bsVendGrupoProd.Current as CamadaDados.Faturamento.Cadastros.TRegistro_Vendedor_X_GrupoProd, null);
                        MessageBox.Show("Registro excluido com sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        BuscarVendGrupoProd();
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void bb_copiar_Click(object sender, EventArgs e)
        {
            using (TFCopiarConfigVend fCopiar = new TFCopiarConfigVend())
            {
                fCopiar.pCd_vendedor = cd_vendedor.Text;
                if (fCopiar.ShowDialog() == DialogResult.OK)
                    try
                    {
                        if (fCopiar.lCarteiraVend != null)
                            fCopiar.lCarteiraVend.ForEach(p=>
                                {
                                    CamadaNegocio.Faturamento.Cadastros.TCN_Vendedor_X_RegiaoVenda.Gravar(
                                        new CamadaDados.Faturamento.Cadastros.TRegistro_Vendedor_X_RegiaoVenda()
                                        {
                                            Cd_vendedor = cd_vendedor.Text,
                                            Id_regiao = p.Id_regiao
                                        }, null);
                                });
                        if (fCopiar.lCondPagtoVend != null)
                            fCopiar.lCondPagtoVend.ForEach(p =>
                                {
                                    CamadaNegocio.Faturamento.Cadastros.TCN_Vendedor_X_CondPgto.Gravar(
                                        new CamadaDados.Faturamento.Cadastros.TRegistro_Vendedor_X_CondPgto()
                                        {
                                            Cd_vendedor = cd_vendedor.Text,
                                            Cd_condpgto = p.Cd_condpgto,
                                            Pc_basecalc_comissao = p.Pc_basecalc_comissao
                                        }, null);
                                });
                        if (fCopiar.lEmpresaVend != null)
                            fCopiar.lEmpresaVend.ForEach(p =>
                                {
                                    CamadaNegocio.Faturamento.Cadastros.TCN_Vendedor_X_Empresa.Gravar(
                                        new CamadaDados.Faturamento.Cadastros.TRegistro_Vendedor_X_Empresa()
                                        {
                                            Cd_vendedor = cd_vendedor.Text,
                                            Cd_empresa = p.Cd_empresa,
                                            Pc_fixocomissao = p.Pc_fixocomissao,
                                            Tp_comissao = p.Tp_comissao,
                                            St_comservico = p.St_comservico
                                        }, null);
                                });
                        if (fCopiar.lGrupoProdVend != null)
                            fCopiar.lGrupoProdVend.ForEach(p =>
                                {
                                    CamadaNegocio.Faturamento.Cadastros.TCN_Vendedor_X_GrupoProd.Gravar(
                                        new CamadaDados.Faturamento.Cadastros.TRegistro_Vendedor_X_GrupoProd()
                                        {
                                            Cd_vendedor = cd_vendedor.Text,
                                            Cd_grupo = p.Cd_grupo,
                                            Pc_Comissao = p.Pc_Comissao,
                                        }, null);
                                });
                        if (fCopiar.lTabPrecoVend != null)
                            fCopiar.lTabPrecoVend.ForEach(p =>
                                {
                                    CamadaNegocio.Faturamento.Cadastros.TCN_Vendedor_X_TabelaPreco.Gravar(
                                        new CamadaDados.Faturamento.Cadastros.TRegistro_Vendedor_X_TabelaPreco()
                                        {
                                            Cd_vendedor = cd_vendedor.Text,
                                            Cd_tabelapreco = p.Cd_tabelapreco,
                                            Pc_comissao = p.Pc_comissao
                                        }, null);
                                });
                        if (fCopiar.lDescontovend != null)
                            fCopiar.lDescontovend.ForEach(p =>
                                {
                                    CamadaNegocio.Faturamento.Cadastros.TCN_DescontoVendedor.Gravar(
                                        new CamadaDados.Faturamento.Cadastros.TRegistro_DescontoVendedor()
                                        {
                                            Cd_vendedor = cd_vendedor.Text,
                                            Cd_empresa = p.Cd_empresa,
                                            Cd_grupo = p.Cd_grupo,
                                            Cd_tabelapreco = p.Cd_tabelapreco,
                                            Pc_max_desconto = p.Pc_max_desconto
                                        }, null);
                                });
                        if (!string.IsNullOrEmpty(fCopiar.Msg))
                            MessageBox.Show(fCopiar.Msg, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        tcCentral.SelectedTab = tpVendEmpresa;
                        BuscarVendEmpresa();
                    }
                    catch (Exception ex)
                    {MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);}
            }
        }

        private void bb_novoDesconto_Click(object sender, EventArgs e)
        {
            using (TFDescontoVendedor fDesc = new TFDescontoVendedor())
            {
                fDesc.Cd_vendedor = cd_vendedor.Text;
                if (fDesc.ShowDialog() == DialogResult.OK)
                    if (fDesc.rDesc != null)
                        try
                        {
                            fDesc.rDesc.Cd_vendedor = cd_vendedor.Text;
                            CamadaNegocio.Faturamento.Cadastros.TCN_DescontoVendedor.Gravar(fDesc.rDesc, null);
                            MessageBox.Show("Registro gravado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            BuscarDescontoVend();
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void bb_excluiDesconto_Click(object sender, EventArgs e)
        {
            if (bsDescontoVendedor.Current != null)
                if (MessageBox.Show("Confirma exclusão do registro selecionado?", "Mensagem", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                         MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    try
                    {
                        CamadaNegocio.Faturamento.Cadastros.TCN_DescontoVendedor.Excluir(bsDescontoVendedor.Current as CamadaDados.Faturamento.Cadastros.TRegistro_DescontoVendedor, null);
                        MessageBox.Show("Registro excluido com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        BuscarDescontoVend();
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void bb_NovoGerente_Click(object sender, EventArgs e)
        {
            using (TFGerenteVendedor fGerente = new TFGerenteVendedor())
            {
                fGerente.Cd_gerente = cd_vendedor.Text;
                if (fGerente.ShowDialog() == DialogResult.OK)
                    if (fGerente.lGerente != null)
                        if (fGerente.lGerente.Count > 0)
                            try
                            {
                                fGerente.lGerente.ForEach(p=> 
                                    CamadaNegocio.Faturamento.Cadastros.TCN_Gerente_X_Vendedor.Gravar(p, null));
                                MessageBox.Show("Gerente configurado com sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                BuscarGerenteVend();
                            }
                            catch (Exception ex)
                            { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void bb_ExcluirGerente_Click(object sender, EventArgs e)
        {
            if (bsGerenteVend.Current != null)
                if (MessageBox.Show("Confirma exclusão do registro selecionado?", "Mensagem", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                         MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    try
                    {
                        CamadaNegocio.Faturamento.Cadastros.TCN_Gerente_X_Vendedor.Excluir(bsGerenteVend.Current as CamadaDados.Faturamento.Cadastros.TRegistro_Gerente_X_Vendedor, null);
                        MessageBox.Show("Registro excluido com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        BuscarGerenteVend();
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
    }
}
