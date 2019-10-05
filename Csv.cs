using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;

namespace conversions
{
    public class Csv : IRun
    {
        public string Name => "Csv";
        public async Task RunAsync<T>(T input)
        {
            var csv = new StringBuilder();
            
            await using var textWriter = new StringWriter(csv);
            using var csvWriter = new CsvWriter(textWriter);
            
            // automatically map the properties of T
            csvWriter.Configuration.AutoMap<T>();
            
            // we want to have a header row (optional)
            csvWriter.WriteHeader<T>();
            await csvWriter.NextRecordAsync();
            
            // write our record
            csvWriter.WriteRecord(input);
            
            // make sure all records are flushed to stream
            await csvWriter.FlushAsync();
            
            Console.WriteLine(csv.ToString());
        }
    }
}