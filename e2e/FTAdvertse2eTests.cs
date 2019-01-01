using System;
using Xunit;
using FluentAssertions;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json.Linq;

namespace e2e
{
    public class FTadvertse2eTests
    {
        public const string FTAdvertsApiRoot = "http://ftadvertsapi";        

        [Fact]
        public async Task IsHomeUp()
        {
            var client = new HttpClient();

            var CheckApi = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"{FTAdvertsApiRoot}")
            };
            Console.WriteLine($"Checking ftadverts.api: {CheckApi.RequestUri}");
            using (var response = await client.SendAsync(CheckApi))
            {
                response.EnsureSuccessStatusCode();
                var content = await response.Content.ReadAsStringAsync();
                var actual = JObject.Parse(content);
				Console.WriteLine($"API Response: {actual}");
                var expected = JObject.Parse("{\"api\": \"ftadverts\"}");

                actual.Should().BeEquivalentTo(expected);

            }                     
            
        }
   }
}