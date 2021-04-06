using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("Digite a Palavra");
                    Console.WriteLine("{0} é um Palíndromo", IsPalindromo(Console.ReadLine()) ? "Sim" : "Não");
                    Console.WriteLine("");
                } 
                catch(Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(ex.Message);
                    Console.ResetColor();
                }
            }
        }

        /// <summary>
        /// Função para identificar um palíndromo.
        /// </summary>
        /// <param name="sPalavra">Palava</param>
        /// <returns>Booleano</returns>
        private static bool IsPalindromo(string sPalavra)
        {

            if ( sPalavra.Length < 3 )
            {
                throw new Exception("Parâmetro Inválido!\n\rInforme uma palavra!");
            }

            //Converte a acentuação para não atrapalhar o processo.
            sPalavra = RemoveAcentuacao(sPalavra);

            //Remove os espaços.
            sPalavra = sPalavra.Replace(" ", "");

            //reverte o texto.
            string sPalavraReversa = new string(sPalavra.Reverse().ToArray());

            //Remove os espaços e faz a comparação.
            return ( sPalavraReversa.ToLower() == sPalavra.ToLower() );
        }

        /// <summary>
        /// Função para remover os caracteres especiais.
        /// </summary>
        /// <param name="sPalava">Palavar para sanitização</param>
        /// <returns>Palavra Sanitizada</returns>
        private static string RemoveAcentuacao(string sPalava)
        {
            //Mapa das letras.
            //Fiz o relacionametno assim, pois, demoraria muito pegar os códigos do Ascii fim.
            //Dava para usar Dictionary, mas, ia ficar "feio" e na hora de usar no linq ia ser mais chato.
            List<MapaCaracteres> mapaCaracteres = new List<MapaCaracteres>
            {
                new MapaCaracteres { Acento = 'Ä', Letra = 'A' },
                new MapaCaracteres { Acento = 'Å', Letra = 'A' },
                new MapaCaracteres { Acento = 'Á', Letra = 'A' },
                new MapaCaracteres { Acento = 'Â', Letra = 'A' },
                new MapaCaracteres { Acento = 'À', Letra = 'A' },
                new MapaCaracteres { Acento = 'Ã', Letra = 'A' },
                new MapaCaracteres { Acento = 'ä', Letra = 'a' },
                new MapaCaracteres { Acento = 'á', Letra = 'a' },
                new MapaCaracteres { Acento = 'â', Letra = 'a' },
                new MapaCaracteres { Acento = 'à', Letra = 'a' },
                new MapaCaracteres { Acento = 'ã', Letra = 'a' },
                new MapaCaracteres { Acento = 'É', Letra = 'E' },
                new MapaCaracteres { Acento = 'Ê', Letra = 'E' },
                new MapaCaracteres { Acento = 'Ë', Letra = 'E' },
                new MapaCaracteres { Acento = 'È', Letra = 'E' },
                new MapaCaracteres { Acento = 'é', Letra = 'e' },
                new MapaCaracteres { Acento = 'ê', Letra = 'e' },
                new MapaCaracteres { Acento = 'ë', Letra = 'e' },
                new MapaCaracteres { Acento = 'è', Letra = 'e' },
                new MapaCaracteres { Acento = 'Í', Letra = 'I' },
                new MapaCaracteres { Acento = 'Î', Letra = 'I' },
                new MapaCaracteres { Acento = 'Ï', Letra = 'I' },
                new MapaCaracteres { Acento = 'Ì', Letra = 'I' },
                new MapaCaracteres { Acento = 'í', Letra = 'i' },
                new MapaCaracteres { Acento = 'î', Letra = 'i' },
                new MapaCaracteres { Acento = 'ï', Letra = 'i' },
                new MapaCaracteres { Acento = 'ì', Letra = 'i' },
                new MapaCaracteres { Acento = 'Ö', Letra = 'O' },
                new MapaCaracteres { Acento = 'Ó', Letra = 'O' },
                new MapaCaracteres { Acento = 'Ô', Letra = 'O' },
                new MapaCaracteres { Acento = 'Ò', Letra = 'O' },
                new MapaCaracteres { Acento = 'Õ', Letra = 'O' },
                new MapaCaracteres { Acento = 'ö', Letra = 'o' },
                new MapaCaracteres { Acento = 'ó', Letra = 'o' },
                new MapaCaracteres { Acento = 'ô', Letra = 'o' },
                new MapaCaracteres { Acento = 'ò', Letra = 'o' },
                new MapaCaracteres { Acento = 'õ', Letra = 'o' },
                new MapaCaracteres { Acento = 'Ü', Letra = 'U' },
                new MapaCaracteres { Acento = 'Ú', Letra = 'U' },
                new MapaCaracteres { Acento = 'Û', Letra = 'U' },
                new MapaCaracteres { Acento = 'ü', Letra = 'u' },
                new MapaCaracteres { Acento = 'ú', Letra = 'u' },
                new MapaCaracteres { Acento = 'û', Letra = 'u' },
                new MapaCaracteres { Acento = 'ù', Letra = 'u' },
                new MapaCaracteres { Acento = 'Ç', Letra = 'C' },
                new MapaCaracteres { Acento = 'ç', Letra = 'c' }
            };

            foreach(MapaCaracteres sLetra in mapaCaracteres.Where(x => sPalava.ToArray().Contains( x.Acento )).ToList())
            {
                sPalava = sPalava.Replace(sLetra.Acento, sLetra.Letra);
            }

            return sPalava;
        }
    }
}
