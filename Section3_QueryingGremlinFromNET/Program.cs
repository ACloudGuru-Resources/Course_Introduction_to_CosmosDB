using Gremlin.Net.Driver;
using Gremlin.Net.Structure.IO.GraphSON;
using Newtonsoft.Json;
using System;

namespace GremlinExample
{
    class Program
    {
        static void Main(string[] args)
        {
            var authKey = "YOURKEYHERE";

            var gremlinServer = new GremlinServer(
                "YOURURLHERE.gremlin.cosmosdb.azure.com",
                443,
                enableSsl: true,
                username: $"/dbs/cloudguru/colls/people",
                password: authKey);

            using (var gremlinClient = new GremlinClient(gremlinServer, new GraphSON2Reader(), new GraphSON2Writer(), GremlinClient.GraphSON2MimeType))
            {
                var query = "g.V()";
                var task = gremlinClient.SubmitAsync<dynamic>(query);
                task.Wait();

                foreach (var result in task.Result)
                {
                    string output = JsonConvert.SerializeObject(result);
                    Console.WriteLine(String.Format("\tResult:\n\t{0}", output));
                }
            }

            Console.ReadKey();
        }
    }
}
