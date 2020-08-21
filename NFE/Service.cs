using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;

namespace srvNFE
{
    public partial class ServicoNFE : ServiceBase
    {
        private System.Timers.Timer tempo = null;
        private string path_nfe_assinar = string.Empty;
        private string path_nfe_assinada = string.Empty;
        private string nm_certificado = string.Empty;
        private string nr_certificado = string.Empty;

        public ServicoNFE()
        {
            InitializeComponent();
            tempo = new System.Timers.Timer(1000);
            tempo.Enabled = false;
            tempo.Elapsed += new System.Timers.ElapsedEventHandler(tempo_Elapsed);
        }

        private void BuscarPath_nfe_assinar()
        {
            path_nfe_assinar = srvNFE.SettingsNFE.Default.PATH_NFE_ASSINAR.Trim(); 
        }

        private void BuscarPath_nfe_assinada()
        {
            path_nfe_assinada = srvNFE.SettingsNFE.Default.PATH_NFE_ASSINADA.Trim();
        }

        private void BuscarNm_certificado()
        {
            nm_certificado = srvNFE.SettingsNFE.Default.PATH_NFE_SCHEMAS.Trim();
        }

        private void BuscarNR_certificado()
        {
            nr_certificado = srvNFE.SettingsNFE.Default.NR_CERTIFICADO_NFE.Trim();
        }

        void tempo_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            tempo.Enabled = false;
            //Gerar Arquivos XML de notas fiscais eletronicas
            if (path_nfe_assinar.Trim() != string.Empty)
            {
                //Verificar se o diretorio existe
                if (!System.IO.Directory.Exists(path_nfe_assinar))
                    //se não existir, criar o diretorio
                    try
                    {
                        System.IO.Directory.CreateDirectory(path_nfe_assinar);
                    }
                    catch (System.IO.IOException ex)
                    { 
                        EventLog.WriteEntry("Erro NFE: " + ex.Message, EventLogEntryType.Error);
                        return;
                    }
                //Criar o arquivo xml
                try
                {
                    GerarArq.GerarArq.GerarArqXML(path_nfe_assinar);
                }
                catch(Exception ex)
                { EventLog.WriteEntry("Erro NFE: " + ex.Message, EventLogEntryType.Error); }
            }
            //Assinar Arquivos XML
            if (path_nfe_assinada.Trim() != string.Empty)
            {
                //Verificar se o diretorio existe
                if(!System.IO.Directory.Exists(path_nfe_assinada))
                    //se não existir, criar o diretorio
                    try
                    {
                        System.IO.Directory.CreateDirectory(path_nfe_assinada);
                    }
                    catch(System.IO.IOException ex)
                    {
                        EventLog.WriteEntry("Erro NFE: " + ex.Message, EventLogEntryType.Error);
                        return;
                    }
                //Assinar os arquivos
                Assinatura.TAssinatura ass = new Assinatura.TAssinatura();
                try
                {
                    ass.Path_arquivo_assinar = path_nfe_assinar;
                    ass.Path_arquivo_assinado = path_nfe_assinada;
                    ass.Nr_certificado = nr_certificado;
                    ass.Tipo_Arq = Assinatura.TAssinatura.TTpArq.tpEnviaNFE;
                    ass.Le_Arquivo();
                }
                catch (Exception ex)
                {
                    EventLog.WriteEntry("Erro Assinatura NFE: " + ex.Message, EventLogEntryType.Error);
                }
                //Enviar arquivos XML assinados
                srvNFE.EnviaArq.EnviaArq.EnviarLoteNfe(path_nfe_assinada.Trim());
            }
            
            tempo.Enabled = true;
        }

        protected override void OnStart(string[] args)
        {
            //Buscar configurações de Paths das pastas
            BuscarPath_nfe_assinar();
            BuscarPath_nfe_assinada();
            BuscarNm_certificado();
            BuscarNR_certificado();
            tempo.Enabled = true;
        }

        protected override void OnStop()
        {
            tempo.Enabled = false;
            EventLog.WriteEntry("Serviço NFE - Nota Fiscal eletronica parado", EventLogEntryType.Information);
        }

        protected override void OnContinue()
        {
            base.OnContinue();
            tempo.Enabled = true;
        }

        protected override void OnPause()
        {
            base.OnPause();
            tempo.Enabled = false;
        }

        protected override void OnShutdown()
        {
            base.OnShutdown();
            tempo.Enabled = false;
        }
    }
}
