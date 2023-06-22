// TODO: implement class Settings.
//       Implementation details are up to you, they just have to meet the requirements of the home task.
using System;
using System.Collections.Generic;

public class Settings
{
    public static readonly int InitialParkingBalance = 0;
    public static readonly int ParkingCapacity  = 10;
    public static readonly int PaymentDeductionPeriodInSeconds = 5000;
    public static readonly int LogWritePeriodInSeconds = 60000;

    public static Dictionary<VehicleType, decimal> Price => new Dictionary<VehicleType, decimal>()
    {
        {VehicleType.PassengerCar, 2},
        {VehicleType.Truck, 5},
        {VehicleType.Bus, 3.5m },
        {VehicleType.Motorcycle, 1 }
    };

    //public static decimal GetTarrif(VehicleType vehicleType)
    //{

    //    switch (vehicleType) 
    //    {


    //        case VehicleType.PassengerCar:
    //            return  2;
    //        case VehicleType.Truck:
    //            return  5;
    //        case VehicleType.Bus:
    //            return  3.5m;
    //        case VehicleType.Motorcycle:
    //            return  1;
    //        default:
    //            return 0;// EXCEPTION...

    //    }
    //}

    //decimal tarrif = Settings.GetTarrif(vehicleType);
    public static readonly decimal PenaltyCoefficient = 2.5m;
    
    

    

}
