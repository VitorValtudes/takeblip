using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using static WebApplication3.Model.BlipJson;

namespace WebApplication3.Controllers
{
    [ApiController]
    [Route("")]
    public class TakeBlipController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public async Task<string> GetAsync(int id)
        {
            var cSharpList = new List<Output>();
            CancellationToken cancellationToken2 = default;

            var client = new HttpClient { BaseAddress = new Uri("https://api.github.com") };
            client.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue("PostmanRuntime", "7.26.8")); 

            using (var request = new HttpRequestMessage(HttpMethod.Get, $"orgs/takenet/repos?per_page=100&access_token=30aa0ecadeffc56a08a25bf66e6b22b13e1f1bc9"))
            {
                using (var response = await client.SendAsync(request, cancellationToken2))
                {
                    var jsonAux = await response.Content.ReadAsStringAsync();
                    var repositoryList = JsonConvert.DeserializeObject<List<Repository>>(jsonAux);

                    cSharpList.AddRange(repositoryList.Where(repos => repos.language == "C#").OrderBy(repos=>repos.created_at).Select(_ => new Output(_.full_name, _.description)).ToList().Take(5));
                }
                
            }

            var json = JsonConvert.SerializeObject(cSharpList[id]);
            return json;
        }

    }
}
