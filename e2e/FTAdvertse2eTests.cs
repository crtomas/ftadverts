using System;
using Xunit;
using FluentAssertions;
using FluentAssertions.Json;
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
                var actual = JToken.Parse(content);
                var expected = JToken.Parse(@"{ ""api"" : ""ftadvertsv13"" }");                
				Console.WriteLine($"Actual API Response: {actual}");                
                Console.WriteLine($"Expected API Response: {expected}");

                actual.Should().BeEquivalentTo(expected);                
            }                     
            
        }
   }
}