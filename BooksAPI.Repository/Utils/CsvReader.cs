using BooksAPI.Domain;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace BooksAPI.Repository.Utils
{
    class CsvReader
    {
        private List<string> readLinesFromCsv()
        {
            try
            {
                string csvPath = @"..\BooksAPI.Repository\Utils\dataBase.csv";
                string content = "";
                using (Stream stream = new FileStream(csvPath, FileMode.Open, FileAccess.Read))
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        content = reader.ReadToEnd();
                    }
                }
                
                var result = content.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None).Skip(1).ToList();
                
                return result;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        internal List<Book> readBooksFromCsv()
        {
            List<string> lines = readLinesFromCsv();
            List<Book> books = new List<Book>();
            Book book;
            int counter = 0;
            if(lines != null)
            {
                foreach(string line in lines)
                {
                    List<string> lineElements = line.Split("|").ToList();
                    if(lineElements.Count == 5)
                    {
                        counter++;
                        book = new Book
                        {
                            BookId = counter,
                            Title = lineElements[4],
                            Author = lineElements[1],
                            ImageUrl =lineElements[2],
                            Description = lineElements[0],
                            EditionYear = 2000,
                            Publisher = ""
                        };
                        books.Add(book);
                    }
                }
            }

            return books;
        }
    }
}
