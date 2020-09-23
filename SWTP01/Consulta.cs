using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWTP01
{
    class Consulta
    {
        static string path = "C:";
        static string arquivo = "\\livros.csv";

        private static readonly string nomeArquivoCSV = path+arquivo;


        public Consulta()
        {

        }


        public List<Book> buscaArquivo()
        {
            using (var file = File.OpenText(Consulta.nomeArquivoCSV))
            {
                var books = new List<Book>();
                Author[] autores = new Author[2];

                while (!file.EndOfStream)
                {
                    var textoLivro = file.ReadLine();

                    if (string.IsNullOrEmpty(textoLivro))
                    {
                        continue;
                    }

                    var infoLivro = textoLivro.Split(';');


                    var autor1 = new Author();
                    autor1.Name = infoLivro[4];

                    autores.SetValue(autor1, 0);

                    if (infoLivro.Length == 6)
                    {
                        var autor2 = new Author();
                        autor1.Name = infoLivro[5];
                    }

                    
                    var livro = new Book(infoLivro[0], autores, double.Parse(infoLivro[2]), int.Parse(infoLivro[3]));


                    books.Add(livro);


                }

                return books;

            }
        }

       

    }
}
