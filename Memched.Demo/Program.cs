using System;
using System.Threading;
using Microsoft.Extensions.DependencyInjection;

namespace Memched.Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            var provider = ContainerConfiguration.Configure();

            Console.WriteLine("Set cache");
            var cacheRepository = provider.GetService<ICacheRepository>();
            // Set cache
            cacheRepository.Set("Key_1", "123");

            Console.WriteLine("Sleep for 2 minutes");
            // Sleep for 2 Minutes
            Thread.Sleep(1000 * 60 * 2);

            Console.WriteLine("Get cache");
            // Get cache
            var cacheProvider = provider.GetService<ICacheProvider>();
            Console.WriteLine($"Value from cache {cacheProvider.GetCache<string>("Key_1")}");
            Console.ReadLine();
        }
    }
}
