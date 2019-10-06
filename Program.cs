using System;
using System.Threading.Tasks;

namespace conversions
{
    class Program
    {
        static async Task Main()
        {
            var samples = new IRun[]
            {
                new Xml(),
                new Json(),
                new JsonSimple(),
                new JsonNet(),
                new Csv(),
                new Yaml(),
                new Toml()
            };
            
            Console.WriteLine("Conversion Extravaganza!");

            var friend = new Friend
            {
                Id = 1,
                Debt = 10m,
                Met = DateTime.Now,
                Name = "Khalid Abuhakmeh"
            };

            foreach (var sample in samples)
            {
                Console.WriteLine($"--- Running {sample.Name} ---\n");
                await sample.RunAsync(friend);
                Console.WriteLine();
            }
            
        }
    }
    
    public class Friend
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Met { get; set; }
        public decimal Debt { get; set; }
    }
}
