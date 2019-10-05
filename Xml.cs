using System;
using System.IO;
using System.Text;
using System.Text.Unicode;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace conversions
{
    public class Xml : IRun
    {
        public string Name => nameof(Xml);

        public async Task RunAsync<T>(T input)
        {
            // if you can, only create one serializer
            // creating serializers is an expensive 
            // operation and can be slow
            var serializer 
                = new XmlSerializer(typeof(T));

            // we will write the our result to memory
            await using var stream = new MemoryStream();
            // the string will be utf8 encoded
            await using var writer = new StreamWriter(stream, Encoding.UTF8);

            // here we go!
            serializer.Serialize(writer, input);
            
            // flush our write to make sure its all there
            await writer.FlushAsync();
            
            // reset the stream back to 0
            stream.Position = 0;

            using var reader = new StreamReader(stream);
            
            // we reread the stream to a string
            var xml = await reader.ReadToEndAsync();
            
            Console.Write($"{xml}\n");
        }
    }
}