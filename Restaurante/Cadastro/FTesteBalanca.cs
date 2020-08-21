using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Utils;

namespace Restaurante.Cadastro
{
    public partial class FTesteBalanca : Form
    {
        public decimal vl_unit { get; set; } = decimal.Zero;

        public CamadaDados.Diversos.TRegistro_CadProtocolo rProt { get; set; }
            = new CamadaDados.Diversos.TRegistro_CadProtocolo();

        public decimal vl_peso
        {
            get { return pesocapturado.Value; }
        }

        public decimal vl_tot
        {
            get { return vl_total.Value; } 
        }  

        public FTesteBalanca()
        {
            InitializeComponent();
        }

        private void FTesteBalanca_Load(object sender, EventArgs e)
        {

            Icon = ResourcesUtils.TecnoAliance_ICO;
            vl_unitario.Value = vl_unit;
            //Porta de comunicacao
            serial.PortName = rProt.Ds_porta;
            //Velocidade de Leitura
            serial.BaudRate = rProt.Baudrate;
            //Bit de Dados
            serial.DataBits = rProt.Databits;
            serial.DiscardNull = rProt.St_discartarnullbool;
            serial.DtrEnable = rProt.Dtrenabledbool;
            serial.Handshake = rProt.Handshake.Trim().Equals("1") ? System.IO.Ports.Handshake.RequestToSend :
                rProt.Handshake.Trim().Equals("2") ? System.IO.Ports.Handshake.RequestToSendXOnXOff :
                rProt.Handshake.Trim().Equals("3") ? System.IO.Ports.Handshake.XOnXOff : System.IO.Ports.Handshake.None;
            //Paridade
            serial.Parity = rProt.Parity.Trim().Equals("1") ? System.IO.Ports.Parity.Mark :
                rProt.Parity.Trim().Equals("2") ? System.IO.Ports.Parity.Even :
                rProt.Parity.Trim().Equals("3") ? System.IO.Ports.Parity.Odd :
                rProt.Parity.Trim().Equals("4") ? System.IO.Ports.Parity.Space : System.IO.Ports.Parity.None;
            serial.ReceivedBytesThreshold = rProt.ReceivedBytes.Equals(0) ? 1 : rProt.ReceivedBytes;
            serial.ReadBufferSize = rProt.Tam_bufferread.Equals(0) ? 4096 : rProt.Tam_bufferread;
            //Bit de Parada
            serial.StopBits = rProt.Stopbits.Trim().ToUpper().Equals("1") ?
                System.IO.Ports.StopBits.One : rProt.Stopbits.Trim().ToUpper().Equals("1.5") ?
                System.IO.Ports.StopBits.OnePointFive : rProt.Stopbits.Trim().ToUpper().Equals("2") ?
                System.IO.Ports.StopBits.Two : System.IO.Ports.StopBits.None;
            serial.ReadTimeout = 500;
            serial.WriteTimeout = 500;
            try
            {
                serial.Open();
                serial.WriteLine("ENQ");
                string a = serial.ReadExisting(); 

            }
            catch
            {
                MessageBox.Show("Erro de leitura na porta serial. Tente novamente.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.Cancel;
            }
        }

        private void tmpPeso_Tick(object sender, EventArgs e)
        {
            tmpPeso.Stop();
            try
            {

                if (!serial.IsOpen)
                    serial.Open();
                serial.Write(((char)5).ToString());
                System.Threading.Thread.Sleep(500);

            }
            catch { }
            finally
            { tmpPeso.Start(); }
        }

        private void serial_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            string peso = serial.ReadExisting();
            if (!string.IsNullOrEmpty(peso))
            {
                string vl = string.Empty;
                var vetor = peso.ToArray();
                peso = string.Empty;
                foreach (char c in vetor)
                    if (char.IsNumber(c) || c.Equals('.'))
                        peso += c.ToString();
                label1.Invoke(new MethodInvoker(delegate { vl = peso; }));
                if (!string.IsNullOrEmpty(vl))
                {
                    pesocapturado.Value = Convert.ToDecimal(vl);

                    decimal total = decimal.Multiply(pesocapturado.Value, vl_unitario.Value);
                    vl_total.Value = total;
                }
            }
        }

        private void BB_Captura_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void FTesteBalanca_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode.Equals(Keys.F4))
                this.DialogResult = DialogResult.OK;
            else if (e.KeyCode.Equals(Keys.Escape))
                this.DialogResult = DialogResult.Cancel;
        }
    }
}
