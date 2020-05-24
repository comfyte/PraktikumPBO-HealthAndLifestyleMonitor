using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace HLWebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            if (File.Exists("HLDatabase.db"))
            {
                Console.WriteLine("Menggunakan file database yang telah ada:");
            }
            else
            {
                Console.WriteLine("File \"HLDatabase.db\" tidak ditemukan!");
                Console.WriteLine("Program akan membuat file database kosong baru di:");
            }
            Console.WriteLine(Directory.GetCurrentDirectory() + "\\HLDatabase.db");

            Console.WriteLine("\nMemulai web server lokal...");
            Console.WriteLine("(Tekan Ctrl+C untuk berhenti)\n");
            CreateHostBuilder(args).Build().Run();

            Console.WriteLine("\nWeb server lokal telah berhenti.\n");
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
