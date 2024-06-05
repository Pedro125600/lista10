using System.Text;
using System.IO;
using System;

namespace lista10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string filePath = "lista_atp_10_arquivos.txt";
                StreamReader arq = new StreamReader(filePath, Encoding.UTF8);

                int totalLinhas = ContarLinhas(arq);

                arq.BaseStream.Seek(0, SeekOrigin.Begin);
                arq.DiscardBufferedData();

                string[] nomes = ObterNomesEstudantes(arq, totalLinhas);

                Console.WriteLine($"Número total de linhas: {totalLinhas}");

                Console.WriteLine("Nomes dos estudantes:");
                for(int i = 0; i < nomes.Length; i++) 
                {
                    Console.WriteLine(nomes[i] + ' ');
                }

                arq.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }

            Console.ReadLine();
        }

        static int ContarLinhas(StreamReader arq)
        {
            int count = 0;
            string linha;

            while ((linha = arq.ReadLine()) != null)
            {
                count++;
            }

            return count;
        }

        static string[] ObterNomesEstudantes(StreamReader arq, int linhaCount)
        {
            string[] nomes = new string[linhaCount];
            string linha;
            int index = 0;



            while ((linha = arq.ReadLine()) != null)
            {
                string[] nome = linha.Split( ' ', ' ');
                if (nome.Length > 1)
                {
                    nomes[index] = nome[1];
                    index++;
                }
            }

            return nomes;
        }
    }
}
