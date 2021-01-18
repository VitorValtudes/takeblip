using System;
using System.Threading;
using System.Threading.Tasks;
using Lime.Protocol;
using System.Diagnostics;
using Take.Blip.Client;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace MyBot
{
    /// <summary>
    /// Defines a class for handling messages. 
    /// This type must be registered in the application.json file in the 'messageReceivers' section.
    /// </summary>
    public class PlainTextMessageReceiver : IMessageReceiver
    {
        private readonly ISender _sender;
        private readonly Settings _settings;

        public PlainTextMessageReceiver(ISender sender, Settings settings)
        {
            _sender = sender;
            _settings = settings;
        }

        public async Task ReceiveAsync(Message message, CancellationToken cancellationToken)
        {
            Trace.TraceInformation($"From: {message.From} \tContent: {message.Content}");
            Console.WriteLine(message.Content.ToString());

            /*var repositoryList = new List<Repository>();
            CancellationToken cancellationToken2 = default;

            var client = new HttpClient { BaseAddress = new Uri("https://api.github.com") };
            client.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue("PostmanRuntime", "7.26.8")); // set your own values here


            using (var request = new HttpRequestMessage(HttpMethod.Get, "orgs/takenet/repos"))
            {
                using (var response = await client.SendAsync(request, cancellationToken2))
                {
                    var json = await response.Content.ReadAsStringAsync();
                    repositoryList = JsonConvert.DeserializeObject<List<Repository>>(json);

                    var cSharpList = repositoryList.Where(repos => repos.language == "C#").Select(_ => new { _.full_name, _.description }).ToList();

                    json = JsonConvert.SerializeObject(cSharpList);
                }
            }*/

            _sender.SendMessageAsync("Hi. I just received your message!", message.From, cancellationToken);
        }
    }
}
