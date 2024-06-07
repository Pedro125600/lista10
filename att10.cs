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
                string outputFilePath = "MediasMaior60.txt";
                string outputFilePath2 = "MediasMenor60.txt";
                string outputFilePath3 = "OrdemDes.txt";
                string outputFilePath4 = "Maior.txt";


                int totalLinhas = ContarLinhas(arq);

                arq.BaseStream.Seek(0, SeekOrigin.Begin);
                arq.DiscardBufferedData();
                string[] nomes = ObterNomesEstudantes(arq, totalLinhas);
                arq.BaseStream.Seek(0, SeekOrigin.Begin);
                arq.DiscardBufferedData();

                double[] medias = ObterMedia(arq, totalLinhas);
                EscreverAprovados(outputFilePath, nomes, medias);
                EscreverReprovados(outputFilePath2, nomes, medias);
                EscreverMediasOrdenadas(outputFilePath3, nomes, medias);
                EscreverMaior(outputFilePath4, nomes, medias);


                Console.WriteLine($"Número total de linhas: {totalLinhas}");

                Imprimir(nomes, medias);


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
                string[] nome = linha.Split(' ', ' ');
                if (nome.Length > 1)
                {
                    nomes[index] = nome[1];
                    index++;
                }
            }

            return nomes;
        }

        static double[] ObterMedia(StreamReader arq, int linhaCount)
        {
            double[] media = new double[linhaCount];
            string linha;
            int index = 0;




            while ((linha = arq.ReadLine()) != null)
            {
                string[] partes = linha.Split(' ', ' ');

                for (int i = 2; i < partes.Length; i++)
                {
                    media[index] += double.Parse(partes[i]);

                }
                media[index] /= 3;
                index++;
            }
 static void Main(string[] args)
        {
            try
            {
                string filePath = "lista_atp_10_arquivos.txt";
                StreamReader arq = new StreamReader(filePath, Encoding.UTF8);
                string outputFilePath = "MediasMaior60.txt";
                string outputFilePath2 = "MediasMenor60.txt";
                string outputFilePath3 = "OrdemDes.txt";
                string outputFilePath4 = "Maior.txt";


                int totalLinhas = ContarLinhas(arq);

                arq.BaseStream.Seek(0, SeekOrigin.Begin);
                arq.DiscardBufferedData();

                string[] nomes = ObterNomesEstudantes(arq, totalLinhas);

                arq.BaseStream.Seek(0, SeekOrigin.Begin);
                arq.DiscardBufferedData();

                double[] medias = ObterMedia(arq, totalLinhas);


                EscreverAprovados(outputFilePath, nomes, medias);
                EscreverReprovados(outputFilePath2, nomes, medias);
                EscreverMediasOrdenadas(outputFilePath3, nomes, medias);
                EscreverMaior(outputFilePath4, nomes, medias);


                Console.WriteLine($"Número total de linhas: {totalLinhas}");

                Imprimir(nomes, medias);
                Console.ReadLine();

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
                string[] nome = linha.Split(' ', ' ');
                if (nome.Length > 1)
                {
                    nomes[index] = nome[1];
                    index++;
                }
            }

            return nomes;
        }

        static double[] ObterMedia(StreamReader arq, int linhaCount)
        {
            double[] media = new double[linhaCount];
            string linha;
            int index = 0;




            while ((linha = arq.ReadLine()) != null)
            {
                string[] partes = linha.Split(' ', ' ');

                for (int i = 2; i < partes.Length; i++)
                {
                    media[index] += double.Parse(partes[i]);

                }
                media[index] /= 30;
                index++;
            }

            return media;
        }

        static void EscreverAprovados(string outputFilePath, string[] nomes, double[] medias)
        {

            StreamWriter arq = new StreamWriter(outputFilePath, false, Encoding.UTF8);

            for (int i = 0; i < medias.Length; i++)
            {
                if (medias[i] >= 6.0)
                {
                    arq.WriteLine($"{nomes[i]} {medias[i]}");
                }
            }

            arq.Close();
            Console.WriteLine("Arquivo de aprovados gravado com sucesso.");
        }


        static void EscreverReprovados(string outputFilePath2, string[] nomes, double[] medias)
        {

            StreamWriter arq = new StreamWriter(outputFilePath2, false, Encoding.UTF8);

            for (int i = 0; i < medias.Length; i++)
            {
                if (medias[i] < 6.0)
                {
                    arq.WriteLine($"{nomes[i]} {medias[i]:F1}");
                }
            }

            arq.Close();


        }

        static void EscreverMediasOrdenadas(string outputFilePath3, string[] nomes, double[] medias)
        {
            double[] medias2 = medias;
            string[] nomes2 = nomes;
           Array.Sort(medias);
            Array.Reverse(medias);


            int cont = 0;
              for(int i = 0; i < medias.Length;i++)
              {
                for (int j = 0 + cont; j < medias.Length; j++)
                {
                    if(medias[i] == medias[j])
                    {
                        nomes[i] = nomes2[j];
                        cont++;
                        break;
                    }


                }

              }


            StreamWriter arq = new StreamWriter(outputFilePath3, false, Encoding.UTF8);

            for (int i = 0; i < medias.Length; i++)
            {

                arq.WriteLine($"{nomes[i]} {medias[i]}");

            }

            arq.Close();


        }


        static void EscreverMaior(string outputFilePath4, string[] nomes, double[] medias)
        {
            string Mnome = nomes[0];
            double maior = medias[0];


            for (int i = 0; i < medias.Length - 1; i++)
            {
                if (medias[i] > maior)
                {
                    Mnome = nomes[i];
                    maior = medias[i];

                }


            }

            StreamWriter arq = new StreamWriter(outputFilePath4, false, Encoding.UTF8);

            arq.Write($"{Mnome} {maior}");



            arq.Close();


        }

        static void Imprimir(string[] nomes, double[] medias)
        {
            Console.WriteLine("Nomes dos estudantes e media:");
            for (int i = 0; i < nomes.Length; i++)
            {
                Console.WriteLine($"{nomes[i]}" + " - " + $"{medias[i]:F1}");
            }
        }


    }
}



