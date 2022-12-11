// See https://aka.ms/new-console-template for more information
using Bogus;
using Bogus.DataSets;
using Realistic.Data.Console;
using System.Text.Json;
using System.Text.Json.Serialization;

//var newCustomer = new Customer()
//{
//    FirstName = "Test",
//    LastName = "Test",
//    Address = "My Adress",
//    PostalCode = "31300",
//    City = "Toulouse",
//    Country = "France",
//    Phone = "1234567890",
//    Region = "Test"
//};

var newVehicule = new Faker<Vehicule>("fr")
    .RuleFor(vehicule => vehicule.Vin, faker => faker.Vehicle.Vin())
    .RuleFor(vehicule => vehicule.Model, faker => faker.Vehicle.Model())
    .RuleFor(vehicule => vehicule.Motor, faker => faker.Vehicle.Fuel())
    .RuleFor(vehicule => vehicule.Constructor, faker => faker.Vehicle.Manufacturer())
    .RuleFor(vehicule => vehicule.Type, faker => faker.Vehicle.Type());

var newCustomer = new Faker<Customer>("fr")
    .RuleFor(user => user.FirstName, faker => faker.Person.FirstName)
    .RuleFor(user => user.LastName, faker => faker.Person.LastName)
    .RuleFor(user => user.Address, faker => faker.Person.Address.Street)
    .RuleFor(user => user.PostalCode, faker => faker.Person.Address.ZipCode)
    .RuleFor(user => user.City, faker => faker.Person.Address.City)
    .RuleFor(user => user.Country, faker => faker.Person.Address.State)
    .RuleFor(user => user.Phone, faker => faker.Person.Phone)
    .RuleFor(user => user.Region, faker => faker.Person.Address.State)
    .RuleFor(user => user.Vehicule, faker => newVehicule.Generate(3));    

Console.WriteLine(JsonSerializer.Serialize(newCustomer.Generate(4)));
