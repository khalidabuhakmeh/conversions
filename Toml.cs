using System;
using System.Threading.Tasks;
using Nett;

namespace conversions
{
    public class Toml : IRun
    {
        public string Name => nameof(Toml);
        public Task RunAsync<T>(T input)
        {
            var settings = TomlSettings.Create(cfg => cfg
                    .ConfigureType<decimal>(ct => ct
                        .WithConversionFor<TomlString>(conv => conv
                            .ToToml(s => s.ToString("C")))));
            
            Console.WriteLine(Nett.Toml.WriteString(input, settings));

            return Task.CompletedTask;
        }
    }
}