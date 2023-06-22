// TODO: implement struct TransactionInfo.
//       Necessarily implement the Sum property (decimal) - is used in tests.
//       Other implementation details are up to you, they just have to meet the requirements of the homework.
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.IO;
using System.Transactions;

public struct TransactionInfo
{
    
    public decimal Amount { get; set; }
    public DateTime Time { get; set; }

    public string VehicleId { get; set; }
    





    public TransactionInfo(decimal amount, string vehicleId)
    {
        Amount = amount;
        Time = DateTime.Now;
        VehicleId = vehicleId;

    }

    //public void AddToTransactionLog(TransactionInfo[] transactionInfos)
    //{
    //    try
    //    {
    //        string directory = Path.GetDirectoryName(filePath);
    //        if (!Directory.Exists(directory))
    //            Directory.CreateDirectory(directory);

    //        bool isFirstTransaction = !File.Exists(filePath);

    //        using (StreamWriter writer = new StreamWriter(filePath, true))
    //        {
    //            if (isFirstTransaction)
    //                writer.WriteLine("VehicleId\tWritten Off Money\tTransaction Time");

    //            foreach (var transaction in transactionInfos)
    //            {
    //                writer.WriteLine(transaction.VehicleId + "\t" + transaction.Amount.ToString("F") + "\t\t\t" + transaction.Time);
    //                writer.WriteLine();
    //            }
    //        }
    //    }
    //    catch (FileNotFoundException ex)
    //    {
    //        Console.WriteLine("There is no file with transactions\nContact administrator");
    //    }
    //    catch (Exception ex)
    //    {
    //        Console.WriteLine("Exception: " + ex.Message + ex.StackTrace + ex.InnerException);
    //    }
    //}
    public override string ToString()
    {
        return $"{VehicleId}\t{Amount.ToString("F")}\t\t\t{Time}";
    }

    public static void AddToTransactionLog(List<TransactionInfo> transactions)
    {
        string filePath = @"C:\Users\rosty\source\repos\bsa-dotnet-hw2-template\CoolParking\CoolParking.BL\Models\Transactions.log.txt";

        try
        {
            if (!File.Exists(filePath))
            {
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    writer.WriteLine("VehicleId\tWritten Off Money\tTransaction Time");
                }
            }

            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                foreach (var transaction in transactions)
                {
                    writer.WriteLine(transaction.ToString());
                    writer.WriteLine();
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine( ex.Message);
        }
    }
    
    //public static void AddToTransactionLog(List<TransactionInfo> transactions)
    //{

    //    try
    //    {

    //        if (isFirstTransaction)
    //        {

    //            using (StreamWriter writer = new StreamWriter(@"C:\Users\rosty\source\repos\bsa-dotnet-hw2-template\CoolParking\CoolParking.BL\Models\Transactions.log.txt"))
    //            {
    //                writer.WriteLine("VehicleId\tWritten Off Money\tTransaction Time");
    //            }
    //            isFirstTransaction = false;
    //        }

    //        using (StreamWriter writer = new StreamWriter(@"C:\Users\rosty\source\repos\bsa-dotnet-hw2-template\CoolParking\CoolParking.BL\Models\Transactions.log.txt", true))
    //        {
    //            foreach (var transaction in transactions)
    //            {
    //                writer.WriteLine(transaction.VehicleId + "\t" + transaction.Amount.ToString("F") + "\t\t\t" + transaction.Time);
    //                writer.WriteLine();
    //            }

    //        }
    //    }
    //    catch (FileNotFoundException)
    //    {
    //        Console.WriteLine("There is no file with transactions\nContact administrator");
    //    }


    //}
    //public void AddToTransactionLog1(TransactionInfo[] transactionInfos)
    //{


    //    try
    //    {
    //        if (isFirstTransaction)
    //        {
    //            using (StreamWriter writer = new StreamWriter(filePath))
    //            {
    //                writer.WriteLine("VehicleId\tWritten Off Money\tTransaction Time");
    //            }
    //            isFirstTransaction = false;
    //        }


    //        using (StreamWriter writer = new StreamWriter(filePath, true))
    //        {
    //            foreach (var transaction in transactionInfos)
    //            {
    //                writer.WriteLine(transaction.VehicleId + "\t" + transaction.Amount.ToString("F") + "\t\t\t" + transaction.Time);
    //                writer.WriteLine();
    //            }

    //        }
    //    }
    //    catch (FileNotFoundException)
    //    {
    //        Console.WriteLine("There is no file with transactions\nContact administrator");
    //    }
    //    catch (Exception ex)
    //    {
    //        Console.WriteLine("exception" + ex.Message + ex.StackTrace + ex.InnerException);
    //    }







    //}



}

