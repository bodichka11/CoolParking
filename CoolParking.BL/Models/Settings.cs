// TODO: implement class Settings.
//       Implementation details are up to you, they just have to meet the requirements of the home task.
using System;

public class Settings
{
    public static int InitialParkingBalance { get; } = 0;
    public static int ParkingCapacity { get; } = 10;
    public static int PaymentDeductionPeriodInSeconds { get; } = 5000;
    public static int LogWritePeriodInSeconds { get; } = 60000;

    public static decimal GetTarrif(VehicleType vehicleType)
    {
        
        switch (vehicleType) 
        {
            

            case VehicleType.PassengerCar:
                return  2;
            case VehicleType.Truck:
                return  5;
            case VehicleType.Bus:
                return  3.5m;
            case VehicleType.Motorcycle:
                return  1;
            default:
                return 0;// EXCEPTION...

        }
    }

     //decimal tarrif = Settings.GetTarrif(vehicleType);
    public static decimal PenaltyCoefficient { get; } = 2.5m;
    
    

    

}
