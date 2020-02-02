using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using TestLoggerMicroservice.Enums;
using TestLoggerMicroservice.Models;

namespace TestLoggerMicroservice
{

    class Program
    {
        static readonly string baseUrl = "http://localhost:5001";
        static HttpClient client = new HttpClient();

        static async Task<string> Log(LogModel logModel)
        {
            var response = await client.PostAsJsonAsync($"api/Logging", new
                {
                    Id = logModel.Id,
                    Message = logModel.Message,
                    DateTimestamp = logModel.DateTimestamp,
                    Target = logModel.Target
                });
            var responseMessage = await response.Content.ReadAsStringAsync();
            return responseMessage;
        }


        static void Main(string[] args)
        {
            RunAsync().Wait();
        }


        static async Task RunAsync()
        {
            Console.WriteLine("\n");
            Console.WriteLine("Sample Logger Processing");

            client.BaseAddress = new Uri(baseUrl);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            try
            {
                //255 characters in the log message
                LogModel logEntry = new LogModel { Id = 12345678, Message = RandomString(255), DateTimestamp = DateTime.Now, Target = LogTarget.File };
                await SendPost(logEntry);

                //over 255 characters in the log message
                LogModel logEntry2 = new LogModel {Id = 87654321, Message = RandomString(260), DateTimestamp = DateTime.Now, Target = LogTarget.File };
                await SendPost(logEntry2);
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("App interrupted.");
            }
            finally
            {
                Console.WriteLine();
                Console.WriteLine("App closed.");
            }

            Console.ReadLine();
        }

        private static async Task SendPost(LogModel logEntry)
        {
            Console.WriteLine("\n");
            Console.WriteLine(@"" +
                              string.Format(
                                  "Post started to logger microservice with \n id: {0},\n datetime: {1},\n message: {2},\n target: {3} \n",
                                  logEntry.Id, logEntry.DateTimestamp, logEntry.Message, logEntry.Target));
            var postMessage = await Log(logEntry);

            Console.WriteLine("Post response from microservice: " + postMessage);

            Console.WriteLine("Post Complete.");
        }

        private static string RandomString(int length)
        {
            Random random = new Random();
            const string pool = "abcdefghijklmnopqrstuvwxyz0123456789";
            var builder = new StringBuilder();

            for (var i = 0; i < length; i++)
            {
                var c = pool[random.Next(0, pool.Length)];
                builder.Append(c);
            }

            return builder.ToString();
        }
    }
}
