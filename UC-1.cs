using Microsoft.VisualStudio.TestTools.UnitTesting;
using State_Cencus;
using System.Collections.Generic;

[TestClass]
public class StateCensusAnalyserTests
{
    [TestMethod]
    [ExpectedException(typeof(StateCensusAnalyserException))]
    public void Test_IncorrectCSVFile_RaisesException()
    {
        // Arrange
        string csvFilePath = "path_to_incorrect_csv_file.csv";
        StateCensusAnalyser analyser = new StateCensusAnalyser(csvFilePath);

        // Act
        // No explicit action required, as the exception is expected to be raised

        // Assert
        // Exception is expected to be raised due to incorrect CSV file
    }
}

public class StateCensusAnalyserException : Exception
{
    public StateCensusAnalyserException(string message) : base(message)
    {
    }
}
