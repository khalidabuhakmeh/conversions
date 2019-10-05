using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using YamlDotNet.Serialization;

namespace conversions
{
    public class Yaml : IRun
    {
        public string Name => nameof(Yaml);
        public async Task RunAsync<T>(T input)
        {
            var serializer = new Serializer();
            var yaml = new StringBuilder();
            
            await using var textWriter = new StringWriter(yaml);

            serializer.Serialize(textWriter, input, typeof(T));
            
            Console.WriteLine(yaml.ToString());
        }
    }
}