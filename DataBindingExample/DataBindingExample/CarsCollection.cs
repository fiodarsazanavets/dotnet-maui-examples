using DataBindingExample.Models;

namespace DataBindingExample;

public static class CarsCollection
{
    public static List<Car> Data => new()
    {
        new Car
        {
            Make = "BMW",
            Model = "X6"
        },
        new Car
        {
            Make = "Toyota",
            Model = "Rav4"
        },
        new Car
        {
            Make = "Tesla",
            Model = "Cybertruck"
        },
        new Car
        {
            Make = "Toyota",
            Model = "CH-R"
        },
        new Car
        {
            Make = "Hyundai",
            Model = "Elantra"
        },
        new Car
        {
            Make = "Dacia",
            Model = "Duster"
        },
        new Car
        {
            Make = "Opel",
            Model = "Insignia"
        },
        new Car
        {
            Make = "Mercedes",
            Model = "GLC"
        },
        new Car
        {
            Make = "Land Rover",
            Model = "Evoque"
        }
    };
}
