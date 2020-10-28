using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace FastJSONExperiment
{
    class Program
    {
        static List<Sample> samples = new List<Sample>();
        static int number = 1000000;
        static string jsonText;
        static Stopwatch stopwatch = new Stopwatch();


        static void Main(string[] args)
        {
            GenerateData();

            Serialize();

            Deserialize();
        }

        static List<Sample> GenerateData()
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j <= number; j++)
                {
                    Sample sample = new Sample();
                    sample.Id = i;
                    sample.Name = "Name " + i;
                    sample.Address = "Address " + i;
                    sample.Phone = "Phone " + i;
                    samples.Add(sample);
                }
            }

            return samples;
        }

        static void Serialize()
        {
            stopwatch.Reset();
            stopwatch.Start();
            Console.WriteLine("Start Serialize : {0}", DateTime.Now);

            jsonText = fastJSON.JSON.ToJSON(samples);

            stopwatch.Stop();
            Console.WriteLine("Stop Serialize : {0} ms", stopwatch.Elapsed.Milliseconds);
        }

        static void Deserialize()
        {
            stopwatch.Reset();
            stopwatch.Start();
            Console.WriteLine("Start Deserialize : {0}", DateTime.Now);

            var newobj = fastJSON.JSON.ToObject(jsonText);

            stopwatch.Stop();
            Console.WriteLine("Stop Deserialize : {0} ms", stopwatch.Elapsed.Milliseconds);
        }
    }

    class Sample
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
    }
}
