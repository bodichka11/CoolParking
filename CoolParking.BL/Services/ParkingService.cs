// TODO: implement the ParkingService class from the IParkingService interface.
//       For try to add a vehicle on full parking InvalidOperationException should be thrown.
//       For try to remove vehicle with a negative balance (debt) InvalidOperationException should be thrown.
//       Other validation rules and constructor format went from tests.
//       Other implementation details are up to you, they just have to match the interface requirements
//       and tests, for example, in ParkingServiceTests you can find the necessary constructor format and validation rules.
using CoolParking.BL.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Timers;
using System.Transactions;

public class ParkingService: IParkingService
{
    public readonly Parking parking;
    private ITimerService _timerServiceFee;
    private ITimerService _timerServiceLog;
    private ITimerService _timerServiceWithdaraw;
    private List<Vehicle> vehicles;
    private List<TransactionInfo> transactions;

    public ParkingService()
    {
        parking = Parking.Instance;
        _timerServiceLog = new TimerService(Settings.LogWritePeriodInSeconds);
        _timerServiceFee = new TimerService(Settings.PaymentDeductionPeriodInSeconds);
        _timerServiceWithdaraw = new TimerService(60000);

        
        _timerServiceLog.Elapsed += Timer_ElapsedLog;
        _timerServiceFee.Elapsed += Timer_ElapsedFee;
        //transactions = new List<TransactionInfo>();
        //vehicles = new List<Vehicle>();
        parking.transactions = new List<TransactionInfo>();
        parking.vehicles = new List<Vehicle>();

        _timerServiceLog.Start();
        _timerServiceFee.Start();

    }
    private void Timer_ElapsedFee(object sender, ElapsedEventArgs e)
    {

        foreach (Vehicle vehicle in parking.vehicles)
        {
            parking.ChargeFees(vehicle);


        }
    }
    private void Timer_ElapsedLog(object sender, ElapsedEventArgs e)
    {
        parking.LogTransactions(parking.transactions);
    }

    public void AddVehicle(Vehicle vehicle)
    {
        try
        {
            parking.AddVehicle(vehicle);
        }
        catch ( InvalidOperationException e)
        {
            Console.WriteLine(e.Message);
        }
    }

    public void Dispose()
    {
        throw new NotImplementedException();
    }

    public decimal GetBalance()
    {

        return parking.GetBalance();

    }

    public int GetCapacity()
    {
        return parking.GetCapacity();
    }

    public int GetFreePlaces()
    {
        return parking.GetFreePlaces();
    }

    public TransactionInfo[] GetLastParkingTransactions()
    {
        return parking.GetLastParkingTransactions();
    }

    public ReadOnlyCollection<Vehicle> GetVehicles()
    {
        return parking.GetVehicles();
    }

    public string ReadFromLog()
    {
        return parking.ReadFromLog();
    }

    public void RemoveVehicle(string vehicleId)
    {
        parking.RemoveVehicle(vehicleId);   
    }

    public void TopUpVehicle(string vehicleId, decimal sum)
    {
       parking.TopUpVehicle(vehicleId, sum);    
    }

    public void ShowParkingMenu1()
    {

        string? userSelection;

        do
        {
            Console.ResetColor();
            //Console.Clear();
            Console.WriteLine("************************");
            Console.WriteLine("* CoolParking *");
            Console.WriteLine("************************");



            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("What do you want to do?");
            Console.ResetColor();

            Console.WriteLine("1: Display the current Parking balance on the screen");
            Console.WriteLine("2: Display the amount of money earned for the current period");
            Console.WriteLine("3: Display the number of free parking spaces (free X of Y) ");
            Console.WriteLine("4: Display all Parking Transactions for the current period (before logging).");
            Console.WriteLine("5: Display the history of Transactions on the screen (after reading the data from the Transactions.log file).");
            Console.WriteLine("6: Display the list of Tr. means located in the Parking lot. ");
            Console.WriteLine("7: Park the Vehicle.");
            Console.WriteLine("8: Pick up the Vehicle from the Parking lot.");
            Console.WriteLine("9: Top up the balance of a particular Tr. tool");
            Console.WriteLine("0: Exit");
            Console.Write("Your selection: ");

            userSelection = Console.ReadLine();

            switch (userSelection)
            {
                case "1":
                    GetBalance();
                    break;

                case "2":


                    break;

                case "3":
                    GetFreePlaces();
                    break;

                case "4":
                    GetLastParkingTransactions();

                    break;
                case "5":
                    ReadFromLog();

                    break;
                case "6":
                    GetVehicles();
                    break;
                case "7":
                    parking.ShowAddVehicleMenu();
                    break;
                case "8":
                    parking.ShowRemoveVehicleMenu();
                    break;
                case "9":
                    parking.ShowTopUpVehicleMenu();
                    break;


                default:
                    Console.WriteLine("Invalid selection. Please try again.");
                    break;
            }
        }
        while (userSelection != "0");
    }
}