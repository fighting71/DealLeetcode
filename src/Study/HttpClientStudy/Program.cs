using HttpClientStudy.Demo;
using System;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace HttpClientStudy
{
    class Program
    {
        static void Main(string[] args)
        {

            HttpClientDemo.Study().ContinueWith(u =>
            {

                if (u.IsFaulted)
                {
                    throw u.Exception;
                }
                Console.WriteLine("over");

            });

            Console.ReadKey(true);

        }

    }
}
