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
        csvFilePath = filePath;
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

public class CSVStates
{
    public static void Main(string[] args)
    {
        string csvFilePath = "path_to_your_csv_file.csv";

        StateCensusAnalyser censusAnalyser = new StateCensusAnalyser(csvFilePath);

        int stateCensusRecordCount = GetRecordCount(censusAnalyser);

        Console.WriteLine("Number of records in State Census: " + stateCensusRecordCount);

        // Additional code to load Indian States Code Information
        string statesCodeCsvFilePath = "path_to_states_code_csv_file.csv";

        StateCensusAnalyser statesCodeAnalyser = new StateCensusAnalyser(statesCodeCsvFilePath);

        int statesCodeRecordCount = GetRecordCount(statesCodeAnalyser);

        Console.WriteLine("Number of records in Indian States Code: " + statesCodeRecordCount);

        // Check if the number of records matches
        if (stateCensusRecordCount == statesCodeRecordCount)
        {
            Console.WriteLine("Number of records matches between State Census and Indian States Code");
        }
        else
        {
            Console.WriteLine("Number of records does not match between State Census and Indian States Code");
        }
    }

    public static int GetRecordCount(StateCensusAnalyser analyser)
    {
        int recordCount = 0;
        foreach (string[] dataRow in analyser)
        {
            recordCount++;
        }
        return recordCount;
    }
}      
}


