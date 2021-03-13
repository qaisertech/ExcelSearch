using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Text.Json;

namespace ExcelSemanticSearch
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the search term");
            var term = Console.ReadLine();
            var context = new ExcelContext();
            var result = context.Documents.FromSqlRaw($@"SELECT Person_TBL.BusinessEntityID, Person_TBL.FirstName, Person_TBL.LastName,  Person_TBL.MiddleName  
                        FROM Person.Person AS Person_TBL  
                            INNER JOIN SEMANTICKEYPHRASETABLE  
                            (  
                            Person.Person,  
                            (FirstName,LastName, MiddleName)
                            ) AS KEYP_TBL  
                        ON Person_TBL.BusinessEntityID = KEYP_TBL.document_key  
                        WHERE KEYP_TBL.keyphrase = '{term}'  
                        ORDER BY KEYP_TBL.Score DESC;").ToList();
            var json = JsonSerializer.Serialize(result);
            Console.WriteLine(json);
            Console.ReadKey();
        }
    }
}
