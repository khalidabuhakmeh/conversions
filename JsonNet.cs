using System;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace conversions
{
    public class JsonNet : IRun
    {
        public string Name => "Json.NET";
        public Task RunAsync<T>(T input)
        {
            var result = JsonConvert.SerializeObject(input);
            Console.WriteLine(result);

            return Task.CompletedTask;
        }
    }
}