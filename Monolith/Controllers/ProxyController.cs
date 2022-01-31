using Microsoft.AspNetCore.Mvc;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Monolith.Controllers
{
    [Route("action")]
    [ApiController]
    public class ProxyController : ControllerBase

    {
        private readonly HttpClient _httpClient;

        public ProxyController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
        }
        private async Task<ContentResult> ProxyTo(string url)
            => Content(await _httpClient.GetStringAsync(url));

        [HttpGet]
        public async Task<IActionResult> Books()
            => await ProxyTo("https://localhost:44339/books");

        [HttpGet]
        public async Task<IActionResult> Authors()
        => await ProxyTo("https://localhost:44382/authors");



    }
}
