using System.Runtime.InteropServices;

namespace PDV
{
    public class TBemaMp2032
    {
        #region Chamadas Externas Dll
        [DllImport("MP2032.dll", EntryPoint = "IniciaPorta")]
        private static extern int Bematech_IniciarPorta(string porta);
        [DllImport("MP2032.dll", EntryPoint = "BematechTX")]
        private static extern int Bematech_Texto(string texto);
        [DllImport("MP2032.dll", EntryPoint = "FechaPorta")]
        private static extern int Bematech_FechaPorta();
        [DllImport("MP2032.dll", EntryPoint = "VerificaPapelPresenter")]
        private static extern int VerificaPapelPresenter();
        [DllImport("MP2032.dll", EntryPoint = "AcionaGuilhotina")]
        private static extern int AcionaGuilhotina(int cut);
        [DllImport("MP2032.dll", EntryPoint = "ImprimeBitmap")]
        private static extern int ImprimeBitmap(string arquivo, int imode);
        [DllImport("MP2032.dll", EntryPoint = "ImprimeBmpEspecial")]
        private static extern int ImprimeBmpEspecial(string arquivo, int xScale, int yScale, int iAngle);
        [DllImport("MP2032.dll", EntryPoint = "FormataTX")]
        private static extern int FormataTX(string texto, int tipoletra, int italico, int sublinhado, int expandido, int enfatizado);
        [DllImport("MP2032.dll", EntryPoint = "AjustaLarguraPapel")]
        private static extern int AjustaLarguraPapel(int largura);
        [DllImport("MP2032.dll", EntryPoint = "PrinterReset")]
        private static extern int PrinterReset();
        [DllImport("MP2032.dll", EntryPoint = "ComandoTX")]
        private static extern int ComandoTX(string comando, int tamanho);
        [DllImport("MP2032.dll", EntryPoint = "Le_Status")]
        private static extern int Le_Status();
        #endregion

        #region Métodos da classe

        public static int IniciarPorta(string porta)
        {
            if (Utils.Estruturas.BaixarDll("mp2032.dll") &&
                Utils.Estruturas.BaixarDll("SiUSBXp.dll"))
                return Bematech_IniciarPorta(porta);
            else
                return 0;
        }

        public static int Texto(string texto)
        {
            if (Utils.Estruturas.BaixarDll("mp2032.dll") &&
                Utils.Estruturas.BaixarDll("SiUSBXp.dll"))
                return Bematech_Texto(texto);
            else
                return 0;
        }

        public static int FechaPorta()
        {
            if (Utils.Estruturas.BaixarDll("mp2032.dll") &&
                Utils.Estruturas.BaixarDll("SiUSBXp.dll"))
                return Bematech_FechaPorta();
            else
                return 0;
        }

        public static int VerificaPapel()
        {
            if (Utils.Estruturas.BaixarDll("mp2032.dll") &&
                Utils.Estruturas.BaixarDll("SiUSBXp.dll"))
                return VerificaPapelPresenter();
            else
                return 0;
        }

        public static int Guilhotina()
        {
            if (Utils.Estruturas.BaixarDll("mp2032.dll") &&
                Utils.Estruturas.BaixarDll("SiUSBXp.dll"))
                return AcionaGuilhotina(0);
            else
                return 0;
        }

        public static int Bitmap(string arquivo)
        {
            if (Utils.Estruturas.BaixarDll("mp2032.dll") &&
                Utils.Estruturas.BaixarDll("SiUSBXp.dll"))
                return ImprimeBitmap(arquivo, 0);
            else
                return 0;
        }

        public static int BmpEspecial(string arquivo)
        {
            if (Utils.Estruturas.BaixarDll("mp2032.dll") &&
                Utils.Estruturas.BaixarDll("SiUSBXp.dll"))
                return ImprimeBmpEspecial(arquivo, -1, -1, 0);
            else
                return 0;
        }

        public static int FormataTexto(string texto)
        {
            if (Utils.Estruturas.BaixarDll("mp2032.dll") &&
                Utils.Estruturas.BaixarDll("SiUSBXp.dll"))
                return FormataTX(texto, 2, 0, 0, 1, 0);
            else
                return 0;
        }

        public static int LarguraPapel()
        {
            if (Utils.Estruturas.BaixarDll("mp2032.dll") &&
                Utils.Estruturas.BaixarDll("SiUSBXp.dll"))
                return AjustaLarguraPapel(58);
            else
                return 0;
        }

        public static int Reset()
        {
            if (Utils.Estruturas.BaixarDll("mp2032.dll") &&
                Utils.Estruturas.BaixarDll("SiUSBXp.dll"))
                return PrinterReset();
            else
                return 0;
        }

        public static int Comando(string comando)
        {
            if (Utils.Estruturas.BaixarDll("mp2032.dll") &&
                Utils.Estruturas.BaixarDll("SiUSBXp.dll"))
                return ComandoTX(comando, comando.Length);
            else return 0;
        }

        public static int LerStatus()
        {
            if (Utils.Estruturas.BaixarDll("mp2032.dll") &&
                Utils.Estruturas.BaixarDll("SiUSBXp.dll"))
                return Le_Status();
            else
                return 0;
        }
        #endregion
    }
}
