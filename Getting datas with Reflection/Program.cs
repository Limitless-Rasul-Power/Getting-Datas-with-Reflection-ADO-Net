using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace Getting_datas_with_Reflection
{    
    class Program
    {        
        static void Main(string[] args)
        {
            using (SqlConnection connection = new SqlConnection { ConnectionString = ConfigurationManager.ConnectionStrings["Books"].ConnectionString })
            {
                connection.Open();

                SqlCommand command = new SqlCommand
                {
                    Connection = connection,
                    CommandText = "SELECT * FROM Books;"
                };

                SqlDataReader reader = command.ExecuteReader();

                Type bookType = new Book().GetType();

                List<Book> books = new List<Book>(501);

                while (reader.Read())
                {                                    
                    books.Add
                        (
                            new Book
                            {
                                ID = (int)reader[bookType.GetProperty("ID").Name],
                                Title = reader[bookType.GetProperty("Title").Name] as string,
                                Author = reader[bookType.GetProperty("Author").Name] as string,
                                Publisher = reader[bookType.GetProperty("Publisher").Name] as string,
                                Genre = reader[bookType.GetProperty("Genre").Name] as string,
                                Price = Convert.ToDouble(reader[bookType.GetProperty("Price").Name]),
                                PageCount = (int)reader[bookType.GetProperty("PageCount").Name]
                            }
                        );
                }

                int count = books.Count;
                for (int i = 0; i < count; i++)
                {
                    Console.WriteLine(books[i]);
                }

                connection.Close();
            }
        }
    }
}