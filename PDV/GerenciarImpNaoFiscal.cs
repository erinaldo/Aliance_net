namespace PDV
{
    public class TGerenciarImpNaoFiscal
    {
        public static int IniciarPorta(string Porta)
        {
            if (Utils.TVersaoOS.Is64Bit())
            {
                int i = TBemaMp2064.IniciarPorta(Porta);
                return i;
            }
            else return TBemaMp2032.IniciarPorta(Porta);
        }

        public static int Texto(string Texto)
        {
            if (Utils.TVersaoOS.Is64Bit())
                return TBemaMp2064.Texto(Texto);
            else return TBemaMp2032.Texto(Texto);
        }

        public static int Guilhotina()
        {
            if (Utils.TVersaoOS.Is64Bit())
                return TBemaMp2064.Guilhotina();
            else return TBemaMp2032.Guilhotina();
        }

        public static int FecharPorta()
        {
            if (Utils.TVersaoOS.Is64Bit())
                return TBemaMp2064.FechaPorta();
            else return TBemaMp2032.FechaPorta();
        }

        public static int LerStatus()
        {
            if (Utils.TVersaoOS.Is64Bit())
                return TBemaMp2064.LerStatus();
            else return TBemaMp2032.LerStatus();
        }
    }
}
