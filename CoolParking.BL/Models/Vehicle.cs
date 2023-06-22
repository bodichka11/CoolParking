// TODO: implement class Vehicle.
//       Properties: Id (string), VehicleType (VehicleType), Balance (decimal).
//       The format of the identifier is explained in the description of the home task.
//       Id and VehicleType should not be able for changing.
//       The Balance should be able to change only in the CoolParking.BL project.
//       The type of constructor is shown in the tests and the constructor should have a validation, which also is clear from the tests.
//       Static method GenerateRandomRegistrationPlateNumber should return a randomly generated unique identifier.
using System;
using System.Linq;

public class Vehicle
{
    public string Id { get;  }
    public VehicleType VehicleType { get;  }
    public decimal Balance { get; set; }

    
   
    public Vehicle(string id, VehicleType vehicleType, decimal balance ) 
    {
        Id = id;    
        VehicleType = vehicleType;  
        Balance = balance;  

    }

    public string Display()
    {
        return $"{Id} {VehicleType} {Balance} ";
    }

    //public static string GenerateRandomRegistrationPlateNumber()
    //{
    //    Random random = new Random();
    //    const string letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    //    const string digits = "0123456789";

    //    string registrationPlateNumber;

    //    while (true) 
    //    {
    //        // Генеруємо випадкову комбінацію літер та цифр
    //        string randomLetters = new string(Enumerable.Range(0, 2).Select(_ => letters[random.Next(letters.Length)]).ToArray());
    //        string randomDigits = new string(Enumerable.Range(0, 4).Select(_ => digits[random.Next(digits.Length)]).ToArray());

    //        // Формуємо номер реєстраційної плитки
    //        registrationPlateNumber = $"{randomLetters}-{randomDigits}-{randomLetters}";
    //        return registrationPlateNumber;
    //    }
        
       





    //} 


}
