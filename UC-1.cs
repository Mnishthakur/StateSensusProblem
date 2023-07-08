using Microsoft.VisualStudio.TestTools.UnitTesting;
using State_Cencus;
using System.Collections.Generic;

[TestClass]
public class StateCensusAnalyserTests
{
    [TestMethod]
    public void Test_NumberOfRecords_Matches()
    {
        // Arrange
        string csvFilePath = "/Users/apple/Downloads/IndiaStateCode.csv";
        StateCensusAnalyser analyser = new StateCensusAnalyser(csvFilePath);

        // Act
        List<string[]> records = new List<string[]>();
        foreach (string[] dataRow in analyser)
        {
            records.Add(dataRow);
        }

        // Assert
        int expectedRecordCount = 10; // Provide the expected number of records here
        int actualRecordCount = records.Count;

        Assert.AreEqual(expectedRecordCount, actualRecordCount, "Number of records does not match");
    }
}
