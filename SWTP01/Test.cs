using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWTP01
{
    public class Test
    {
        static Book livro;
        static Author eu = new Author();
        static Author voce = new Author();
        static Author[] autores = { eu, voce };

        public Test()
        {
            Console.WriteLine("---Tests---");
            this.readBookCsv();
            this.createAuthor();
            this.viewAuthors();
            this.createBook();
            this.viewBooks();
        }

        public void readBookCsv()
        {
            try
            {
                Consulta ler = new Consulta();
                var Books = ler.buscaArquivo();
                Console.WriteLine("-----readBookCsv - OK-----");
            }
            catch (IOException e)
            {
                Console.WriteLine("-----readBookCsv - ERROR-----");
                throw;
            }            

        }

        public void createAuthor()
        {
            try
            {
                eu.Name = "Rodrigo Santos";
                eu.Email = "test@teste.com.br";
                eu.Gender = 'M';

                voce.Name = "Fabiano Dias";
                voce.Email = "test@teste.com.br";
                voce.Gender = 'M';

                Console.WriteLine("-----createAuthor - OK-----");
            }
            catch (IOException e)
            {
                Console.WriteLine("-----createAuthor - ERROR-----");
                throw;
            }
        }

        public void createBook()
        {           
            try
            {
                livro = new Book("TP01 de Sistemas Web II", autores, 20.00, 5);

                Console.WriteLine("-----createBook - OK-----\n");

                Console.WriteLine(livro.ToString());

            }
            catch (IOException e)
            {
                Console.WriteLine("-----createBook - ERROR-----");
                throw;
            }
        }

        public void viewBooks()
        {
            try
            {
                Console.WriteLine("-----viewBooks - OK-----");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("");

                Consulta ler = new Consulta();
                var Books = ler.buscaArquivo();


                foreach (var book in Books)
                {                   
                    Console.WriteLine(book.ToString());
                }


                
            }
            catch (IOException e)
            {
                Console.WriteLine("-----viewBooks - ERROR-----");
                throw;
            }
        }

        public void viewAuthors()
        {
            
            try
            {
                Console.WriteLine("-----viewAuthors - OK-----");

                foreach (var author in autores)
                {
                    if (author != null)
                    {
                        Console.WriteLine($"      Autor {author.Name}, Email {author.Email} , Genero {author.Gender.ToString()}");
                    }
                }          
            }
            catch (IOException e)
            {
                Console.WriteLine("-----viewAuthors - ERROR-----");
                throw;
            }
        }

    }
}
