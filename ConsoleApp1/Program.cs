//string randomPlateNumber = Vehicle.GenerateRandomRegistrationPlateNumber();

//Vehicle vehicle1 = new Vehicle(randomPlateNumber, VehicleType.PassengerCar, 100);
//Vehicle vehicle2 = new Vehicle(randomPlateNumber, VehicleType.PassengerCar, 100);
//Vehicle vehicle3 = new Vehicle(randomPlateNumber, VehicleType.PassengerCar, 100);
//Vehicle vehicle4 = new Vehicle(randomPlateNumber, VehicleType.PassengerCar, 100);

//string id = vehicle3.Id;
//Console.WriteLine(id);

//List<Vehicle> vehicles = new List<Vehicle>();
//vehicles.Add(vehicle1);
//vehicles.Add(vehicle2);
//vehicles.Add(vehicle3);
//vehicles.Add(vehicle4);



//Parking parking = Parking.Instance;
//parking.ShowParkingMenu();

//parking.AddVehicle(vehicle1);
//parking.AddVehicle(vehicle2);
//parking.AddVehicle(vehicle3);
//parking.AddVehicle(vehicle4);
//parking.GetCapacity();
//parking.GetBalance();
//parking.GetFreePlaces();
//parking.GetVehicles();


//parking.CloseParking();
ParkingService service = new ParkingService();
service.ShowParkingMenu1();

