using System;
using System.Linq;
using Microsoft.Azure.Documents.Client;

namespace SQLExample
{
    public class Program
    {
        static void Main(string[] args)
        {
            var endpointUrl = "https://YOURENDPOINT.documents.azure.com:443/";
            var primaryKey = "YOURKEY";
            var databaseName = "cloudguru";
            var collectionName = "pets";

            //Note during recording partition key became mandatory so enable cross parition query for simple example
            //Dont do this in real world as it will consume more RU's and result in slower query
            var queryOptions = new FeedOptions { MaxItemCount = -1, EnableCrossPartitionQuery=true };

            using (var client = new DocumentClient(new Uri(endpointUrl), primaryKey))
            {
                var documentQueryInSql = client.CreateDocumentQuery<Owner>(
                    UriFactory.CreateDocumentCollectionUri(databaseName, collectionName),
                    "SELECT * FROM c where c.ownerName='Alex M'",
                    queryOptions);

                Console.WriteLine("SQL query...");

                foreach (Owner owner in documentQueryInSql)
                {
                    Console.WriteLine($"Id: {owner.Id}");
                }
                
                IQueryable<Owner> linqQuery = client.CreateDocumentQuery<Owner>(
                    UriFactory.CreateDocumentCollectionUri(databaseName, collectionName), queryOptions)
                   .Where(o => o.OwnerName == "Alex M");

                Console.WriteLine("LINQ query...");
                foreach (Owner owner in linqQuery)
                {
                    Console.WriteLine($"Id: {owner.Id}");
                }

                Console.WriteLine("Press any key.");
                Console.ReadKey();
            }
        }
    }
}
