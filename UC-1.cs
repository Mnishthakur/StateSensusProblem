using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace State_Cencus
{
    public class StateCensusAnalyser : IEnumerable<string[]>
    {
        private readonly string csvFilePath;

        public StateCensusAnalyser(string filePath)
        {
            csvFilePath = "/Users/apple/Downloads/IndiaStateCode.csv";
        }

        public IEnumerator<string[]> GetEnumerator()
        {
            using (StreamReader reader = new StreamReader(csvFilePath))
            {
                // Skip the header row
                reader.ReadLine();

                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    yield return line.Split(',');
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    public class CSVStateCensus
    {
        public static void Main(string[] args)
        {
            string csvFilePath = "/Users/apple/Downloads/IndiaStateCode.csv";

            StateCensusAnalyser analyser = new StateCensusAnalyser(csvFilePath);

            foreach (string[] dataRow in analyser)
            {
                // Process the data row
                Console.WriteLine(string.Join(", ", dataRow));
            }
        }
    }

}

