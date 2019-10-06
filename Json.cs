using System;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace conversions
{
    public class Json : IRun
    {
        public string Name => "System.Text.Json";
        
        public async Task RunAsync<T>(T input)
        {
            var stream = new MemoryStream();
            await JsonSerializer.SerializeAsync(stream, input);
            
            // reset the stream back to 0
            stream.Position = 0;

            using var reader = new StreamReader(stream);
            
            // we reread the stream to a string
            var json = await reader.ReadToEndAsync();
            
            Console.WriteLine(json);
        }
    }
    
        public class JsonSimple : IRun
        {
            public string Name => "System.Text.Json Simple";
            
            public Task RunAsync<T>(T input)
            {
                var result = JsonSerializer.Serialize( input);
                Console.WriteLine(result);

                return Task.CompletedTask;
            }
        }
}