// TODO: implement class Parking.
//       Implementation details are up to you, they just have to meet the requirements 
//       of the home task and be consistent with other classes and tests.
using CoolParking.BL.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Timers;
using System.Transactions;
using System.Windows.Markup;

public class Parking
{
    

    
    private static readonly Lazy<Parking> lazyInstance = new Lazy<Parking>(() => new Parking());
    public static Parking Instance { get { return lazyInstance.Value; } }

    //private ITimerService _timerServiceFee;
    //private ITimerService _timerServiceLog;
    private decimal balance;
    public List<Vehicle> vehicles;
    public List<TransactionInfo> transactions;
    //public List<TransactionInfo> LastMinuteTransactions { get; set; } = new List<TransactionInfo>();
    


    

    private Parking()
    {

        //_timerServiceLog = new TimerService(Settings.LogWritePeriodInSeconds);
        //_timerServiceFee = new TimerService(Settings.PaymentDeductionPeriodInSeconds);


        //_timerServiceLog.Elapsed += Timer_ElapsedLog;
        //_timerServiceFee.Elapsed += Timer_ElapsedFee;
        transactions = new List<TransactionInfo>();
        vehicles = new List<Vehicle>();

        //_timerServiceLog.Start();
        //_timerServiceFee.Start();



    }
    //private void Timer_ElapsedFee(object sender, ElapsedEventArgs e)
    //{

    //    foreach (Vehicle vehicle in vehicles)
    //    {
    //        ChargeFees(vehicle);
            


    //    }
    //}
    //private void Timer_ElapsedLog(object sender, ElapsedEventArgs e)
    //{
    //    LogTransactions(transactions);
    //}




    //public static Parking Instance
    //{
    //    get
    //    {
    //        if (instance is null)
    //        {
    //            instance = new Parking();
    //        }
    //        return instance;
    //    }
    //}

    public decimal Balance
    {
        get { return balance; }
    }





    public decimal GetBalance()
    {

        Console.WriteLine(balance);
        return balance;

    }


    //public void WriteLog(TransactionInfo transactionInfo, string fileName)
    //{
    //    try
    //    {
    //        fileName = "Transactions.log";

    //        using (StreamWriter writer = new StreamWriter(fileName, true))
    //        {
    //            writer.WriteLine(transactionInfo.ToString());
    //        }
    //        Console.WriteLine("Дані успішно записані у файл ");


    //    }
    //    catch(IOException e)
    //    {
    //        Console.WriteLine(e.ToString(), "Помилка запису у файл");
    //    }

    //}


    public int GetCapacity()
    {
        Console.WriteLine(Settings.ParkingCapacity);
        return Settings.ParkingCapacity;
    }

    public int GetFreePlaces()
    {
        int occupiedSpots = vehicles.Count;
        int availableSpots = Settings.ParkingCapacity - occupiedSpots;

        Console.WriteLine($"Free - ({availableSpots}) of ({Settings.ParkingCapacity}) places on the parking");

        return availableSpots;

    }
    public ReadOnlyCollection<Vehicle> GetVehicles()
    {

        
        foreach (var vehicle in vehicles)
        {
            Console.WriteLine(vehicle.Display());
            

        }
        return vehicles.AsReadOnly();
    }
    

    

    public void AddVehicle(Vehicle vehicle)
    {
        

        if (vehicles.Count < Settings.ParkingCapacity)
        {
            vehicles.Add(vehicle);

            Console.WriteLine($"Vehicle  added to te parking");

        }
        else
        {
            Console.WriteLine("Parking is full. Cant add the vehicle");
        }

    }
    

    

    public void ChargeFees(Vehicle vehicle)
    {
        foreach (Vehicle veh in vehicles)
        {
            decimal payment = Settings.Price[veh.VehicleType];
            if (veh.Balance < payment)
            {
                decimal penalty = payment - veh.Balance;
                payment += penalty * Settings.PenaltyCoefficient;
            }

            
            
            veh.Balance -= payment;
            balance += payment;

            

            var transaction = new TransactionInfo(payment, veh.Id);
            transactions.Add(transaction);
            //LastMinuteTransactions.Add(transaction);
        }
    }

    //!!! todo add logic with minus balance!!!

    //var transaction = new TransactionInfo(payment, vehicle.Id);
    //TransactionInfo[] transactioninfos = { transaction };
    //WriteLog(transactioninfos);

    //foreach (Vehicle vehicle in vehicles)
    //{
    //    decimal payment = Settings.GetTarrif(vehicleType);
    //    if (vehicle.Balance < payment)
    //    {
    //        decimal penalty = payment - vehicle.Balance;
    //        payment += penalty * Settings.PenaltyCoefficient;
    //    }
    //    else
    //    {
    //        vehicle.Balance -= payment;
    //        balance += payment;
    //    }
    //    TransactionInfo transaction = new TransactionInfo(payment, vehicle.Id);
    //    TransactionInfo[] transactions = { transaction };
    //    WriteLog(transactions);





    //}




    //public void WriteLog(TransactionInfo[] transactions)
    //{
    //    foreach (TransactionInfo transaction in transactions)
    //    {
    //        transaction.AddToTransactionLog(transactions);
    //    }


    //}
    public void LogTransactions(object stateInfo)
    {
        TransactionInfo.AddToTransactionLog(transactions);
        transactions.Clear();
    }



    public void ShowAddVehicleMenu()
    {
        
        Console.WriteLine("Enter the platenumber(Id) of the vehicle which u want to add to the parking");
        string vehicleId = Console.ReadLine();

        Console.WriteLine("Enter the type of vehicle which u want to add to the parking");
        VehicleType vehicletype = (VehicleType)Enum.Parse(typeof(VehicleType), Console.ReadLine() ?? "PassengerCar");

        Console.WriteLine("Enter the balance of vehicle which  u want to add to the parking");
        decimal balance = decimal.Parse(Console.ReadLine());

        Vehicle vehicle = new Vehicle(vehicleId, vehicletype, balance);
        AddVehicle(vehicle);
       
        
        
        
        


    }


    public string ReadFromLog()
    {
        Console.WriteLine(File.ReadAllText(@"C:\Users\rosty\source\repos\bsa-dotnet-hw2-template\CoolParking\CoolParking.BL\Models\Transactions.log.txt"));
        return File.ReadAllText(@"C:\Users\rosty\source\repos\bsa-dotnet-hw2-template\CoolParking\CoolParking.BL\Models\Transactions.log.txt");


    }


    public void RemoveVehicle(string vehicleId)
    {
        
        Vehicle selectedVehicle = vehicles.FirstOrDefault(v => v.Id == vehicleId);
        if (selectedVehicle.Balance < 0)
        {
            
            Console.WriteLine("Sorry you cant remove this vehicle because it has debt ");

        }
        else
        {
            if (selectedVehicle != null)
            {
                vehicles.Remove(selectedVehicle);
                Console.WriteLine("Vehicle removed successfully");
            }
            else
            {
                Console.WriteLine("Vehicle not found in the parking");
            }
        }
    }
    public void ShowRemoveVehicleMenu()
    {
        Console.WriteLine("Enter the platenumber of the vehicle which u want to remove");
        string vehicleIdToRemove = Console.ReadLine();
        RemoveVehicle(vehicleIdToRemove);
    }
    public TransactionInfo[] GetLastParkingTransactions()
    {
        List<TransactionInfo> lastTransactions = new List<TransactionInfo>();
        Console.WriteLine("VehicleId\tWritten Off Money\tTransaction Time");
        foreach (var transaction in Parking.Instance.transactions)
        {
            

            lastTransactions.Add(transaction);
            Console.WriteLine(transaction.VehicleId +  "\t\t" + transaction.Amount.ToString() +  "\t\t\t" + transaction.Time);
        }
        
        return lastTransactions.ToArray();
        
    }
        
    //public static void GetLastMinuteTransactions()
    //{
    //    Console.WriteLine("VehicleId\tWritten Off Money\tTransaction Time");
    //    foreach(var transaction in Parking.Instance.LastMinuteTransactions)
    //    {
    //        Console.WriteLine(transaction.VehicleId + "\t" + transaction.Amount.ToString() + "\t" + transaction.Time);
    //    }
    //}

    
    public void TopUpVehicle(string vehicleId, decimal sum)
    {
        Vehicle selectedVehicle = vehicles.FirstOrDefault(v => v.Id == vehicleId);
        if (selectedVehicle != null)
        {
            selectedVehicle.Balance += sum;
            Console.WriteLine("Balance topped up successfully");
        }
        else
        {
            Console.WriteLine("Vehicle not found in the parking");
        }
    }
    public void ShowTopUpVehicleMenu()
    {
        Console.WriteLine("Enter the platenumber of the vehicle which u want to top up:");

        string vehicleIdToTopUp = Console.ReadLine();

        Console.WriteLine("Enter the amount to top up: ");

        decimal topUpAmount = decimal.Parse(Console.ReadLine());

        TopUpVehicle(vehicleIdToTopUp, topUpAmount);
    }

    //public void CloseParking()
    //{
    //    _timerService.Stop();
    //    _timerService.Dispose();
    //}

    




}
