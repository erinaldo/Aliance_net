using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.IO.Compression; 

namespace Utils
{
    public static class Compact_Data
    {
        public static Stream Compactar(string ArquivoOrigem, string ArquivoDestino)
        {
            //Cria uma entrada stream do arquivo de origem para compactação
            FileStream Origem = new FileStream(ArquivoOrigem, FileMode.Open, FileAccess.Read);

            //Cria a saida do arquivo stream, sendo criado um arquivo “.gz”, por exemplo
            FileStream ArquivoCompactado = new FileStream(ArquivoDestino, FileMode.Create, FileAccess.Write);
            
            //Os bytes serão processados por um compressor de streams(GZipStream)
            GZipStream Compactado = new GZipStream(ArquivoCompactado, CompressionMode.Compress);
            //efetua a leitura dos bytes de um arquivo para o outro.
            const int tamanhoBloco = 4096;
            byte[] buffer = new byte[tamanhoBloco];
            int bytesLidos;

            do
            {
                bytesLidos = Origem.Read(buffer, 0, tamanhoBloco);

                if ((bytesLidos == 0))
                    break;

                Compactado.Write(buffer, 0, bytesLidos);
            }
            while (true);

            //Fecha todos os streams
            Origem.Close();
            Compactado.Close();
            ArquivoCompactado.Close();

            return ArquivoCompactado;
        }

        public static void Descompactar(string ArquivoOrigem, string ArquivoDestino)
        {
            //Cria uma entrada stream do arquivo de origem para descompactação
            FileStream Origem = new FileStream(ArquivoOrigem, FileMode.Open, FileAccess.Read);

            //Cria a saida do arquivo stream, aqui é o arquivo de destino
            FileStream Destino = new FileStream(ArquivoDestino, FileMode.Create, FileAccess.Write);

            //Os bytes serão processados através de um decompressor de stream(GZipStream)
            GZipStream Descompactado = new GZipStream(Origem, CompressionMode.Decompress, true);

            //efetua a leitura dos bytes de um arquivo para o outro.
            const int tamanhoBloco = 4096;
            byte[] buffer = new byte[tamanhoBloco];
            int bytesLidos;
            do
            {
                bytesLidos = Descompactado.Read(buffer, 0, tamanhoBloco);

                if ((bytesLidos == 0))
                    break;

                Destino.Write(buffer, 0, bytesLidos);
            }
            while (true);

            //Fecha todos os streams
            Origem.Close();
            Descompactado.Close();
            Destino.Close();
        }

        public static byte[] Compactar(byte[] buffer)
        {
            MemoryStream ms = new MemoryStream();
            GZipStream zip = new GZipStream(ms, CompressionMode.Compress, true);
            zip.Write(buffer, 0, buffer.Length);
            zip.Close();
            ms.Position = 0;

            MemoryStream outStream = new MemoryStream();

            byte[] compressed = new byte[ms.Length];
            ms.Read(compressed, 0, compressed.Length);

            byte[] gzBuffer = new byte[compressed.Length + 4];
            Buffer.BlockCopy(compressed, 0, gzBuffer, 4, compressed.Length);
            Buffer.BlockCopy(BitConverter.GetBytes(buffer.Length), 0, gzBuffer, 0, 4);
            return gzBuffer;
        }

        public static string CompactarBase64(string texto)
        {
            byte[] buffer = Encoding.UTF8.GetBytes(texto);
            MemoryStream ms = new MemoryStream();
            using (GZipStream zip = new GZipStream(ms, CompressionMode.Compress, true))
            {
                zip.Write(buffer, 0, buffer.Length);
            }
            ms.Position = 0;
            MemoryStream outStream = new MemoryStream();
            byte[] compac = new byte[ms.Length];
            ms.Read(compac, 0, compac.Length);
            byte[] gzbuffer = new byte[compac.Length + 4];
            System.Buffer.BlockCopy(compac, 0, gzbuffer, 4, compac.Length);
            System.Buffer.BlockCopy(BitConverter.GetBytes(buffer.Length), 0, gzbuffer, 0, 4);
            return Convert.ToBase64String(gzbuffer);
        }

        public static byte[] Descompactar(byte[] gzBuffer, string ArquivoDestino)
        {
            MemoryStream ms = new MemoryStream();
            int msgLength = BitConverter.ToInt32(gzBuffer, 0);
            ms.Write(gzBuffer, 4, gzBuffer.Length - 4);

            byte[] buffer = new byte[msgLength];

            ms.Position = 0;
            GZipStream zip = new GZipStream(ms, CompressionMode.Decompress);
            zip.Read(buffer, 0, buffer.Length);
            if (!string.IsNullOrEmpty(ArquivoDestino))
            {
                FileStream Destino = new FileStream(ArquivoDestino, FileMode.Create, FileAccess.Write);
                Destino.Write(buffer, 0, buffer.Length);
                Destino.Close();
            }
            return buffer;
        }

        public static string Descompactar(byte[] gzBuffer)
        {
            using (GZipStream stream = new GZipStream(new MemoryStream(gzBuffer), CompressionMode.Decompress))
            {
                const int size = 4096;
                byte[] buffer = new byte[size];
                using (MemoryStream memory = new MemoryStream())
                {
                    int count = 0;
                    do
                    {
                        count = stream.Read(buffer, 0, size);
                        if (count > 0)
                            memory.Write(buffer, 0, count);
                    }
                    while (count > 0);
                    byte[] b = memory.ToArray();
                    return Encoding.UTF8.GetString(b);
                }
            }
        }

        public static string DescompactarBase64(byte[] zipData)
        {
            using (MemoryStream ms = new MemoryStream(zipData))
            {
                using (GZipStream gzs = new GZipStream(ms, CompressionMode.Decompress))
                {
                    using (StreamReader sr = new StreamReader(gzs))
                    {
                        return System.Text.Encoding.UTF8.GetString(Convert.FromBase64String(sr.ReadToEnd()));
                    }
                }
            }
        }
    }
}
