using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWTP01
{
    class Book
    {

        public string name;
        public Author[] authors;
        public double price;
        public int qty = 0;

        public Book() { }
        public Book(string name, Author[] authors, double price)
        {
            this.name = name;
            this.authors = authors;
            this.price = price;
        }

        public Book(string name, Author[] authors, double price, int qty)
        {
            this.name = name;
            this.authors = authors;
            this.price = price;
            this.qty = qty;

        }

        public string getName()
        {
            return this.name;
        }
        public Author[] getauthors()
        {
            return this.authors;
        }
        public double getPrice()
        {
            return this.price;
        }
        public void setPrice(double price)
        {
            this.price = price;
        }
        public double getQty()
        {
            return this.qty;
        }
        public void setQty(int qty)
        {
            this.qty = qty;
        }

        public override string ToString()
        {

            var stringBuilder = new StringBuilder();

            stringBuilder.AppendLine($"     Nome = {name}");
            stringBuilder.AppendLine($"     Autores");

            foreach (var author in authors)
            {
                if (author != null)
                {
                stringBuilder.AppendLine($"      Autor {author.Name}, Email {author.Email} , Genero {author.Gender.ToString()}");
                }
            }
            

            stringBuilder.AppendLine($"     Preço = {price}");
            stringBuilder.AppendLine($"     Quantidade = {qty}");


            return stringBuilder.ToString();


        }

        public string getAuthorNames()
        {
            string resultado = "";

            foreach (var author in authors.Select((value, i) => new { i, value }))
            {
                if (author.value != null)
                {
                    if (author.i == (authors.Length - 1))
                    {
                        resultado += ", " + author.value.Name;
                    }
                    else
                    {
                        resultado += author.value.Name ;

                    }
                }
                
            }

            return resultado;
        }


    }
}
