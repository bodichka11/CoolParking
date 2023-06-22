// TODO: implement the LogService class from the ILogService interface.
//       One explicit requirement - for the read method, if the file is not found, an InvalidOperationException should be thrown
//       Other implementation details are up to you, they just have to match the interface requirements
//       and tests, for example, in LogServiceTests you can find the necessary constructor format.
using CoolParking.BL.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection.Metadata.Ecma335;
using System.Text;

public class LogService : ILogService
{
    public string LogPath { get; }
    public void Write(string logInfo)
    {
        try
        {
            using (StreamWriter writer = new StreamWriter(LogPath, true))
            {
                writer.WriteLine(logInfo);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
    public string Read()
    {
        Console.WriteLine(File.ReadAllText(LogPath));
        return File.ReadAllText(LogPath);


    }
    public LogService(string logPath)
    {
        LogPath = logPath;
    }
    public void Dispose() 
    {

    }
    public void AddToTransactionLog(List<TransactionInfo> transactions)
    {
        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.AppendLine("VehicleId\tWritten Off Money\tTransaction Time");

        foreach (var transaction in transactions)
        {
            stringBuilder.AppendLine(transaction.VehicleId + "\t" + transaction.Amount.ToString("F") + "\t\t\t" + transaction.Time);
            stringBuilder.AppendLine();
        }

        Write(stringBuilder.ToString());
    }

}