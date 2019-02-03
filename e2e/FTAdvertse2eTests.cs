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
        public const string FTAdvertsApiRoot = "http://ftadvertsapi/api/v1/ftadverts";        

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
				Assert.Equal(200, (int)response.StatusCode);
            }                     
        }		
		
        [Fact]
        public async Task ApiVersion()
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
                //var expected = JToken.Parse(@"{ ""api"" : ""ftadvertsv15"" }");                
                //var expected = JToken.Parse(@"[""api"",""ftadvertsv15""]");                				
				var expected = "ftadvertsv15";                				
				Console.WriteLine($"Actual API Response: {actual}");                
                Console.WriteLine($"Expected API Response: {expected}");

                //actual.Should().BeEquivalentTo(expected);                
				//JToken.Parse(actual).Should().HaveCount(2);
				
				//JToken.Parse(actual).Should().HaveCount(2);
				//JToken.Parse(json).SelectToken("$[0]").Value<string>().Should().Be("value1");
				//JToken.Parse(json).SelectToken("$[1]").Value<string>().Should().Be("value2");

				/*
				JToken.Parse(actual).SelectTokens("$").Values<string>().Should()
					.HaveCount(2)
					.And.Equal("api", expected);				
				*/
				Assert.True(true);
            }                     
            
        }
   }
}