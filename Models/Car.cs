using System.ComponentModel.DataAnnotations;

namespace preislerCars.Models;

public class Car
{
    [Required, StringLength(20, MinimumLength = 2)]
    public string Brand { get; set; }

    [Required, StringLength(20, MinimumLength = 2)]
    public string Model { get; set; }

    [Required, Range(1900, 2025)]
    public int Year { get; set; }

    public Car() { 
        Brand = string.Empty;
        Model = string.Empty;
        Year = 0;
    }

    public static List<Car> LoadCars(string filePath)
    {
        List<Car> cars = new List<Car>();
        if (!File.Exists(filePath))
        {
            File.Create(filePath).Close();
            return cars;
        }

        string[] lines = File.ReadAllLines(filePath);
        foreach (string line in lines)
        {
            string[] parts = line.Split(';');
            if (parts.Length != 3)
            {
                continue;
            }
            Car car = new()
            {
                Brand = parts[0],
                Model = parts[1],
                Year = int.Parse(parts[2])
            };
            cars.Add(car);
        }

        return cars;
    }

    public static void SaveCars(string filePath, List<Car> cars)
    {
        List<string> lines = cars.Select(e => $"{e.Brand};{e.Model};{e.Year}").ToList();
        File.WriteAllLines(filePath, lines);
    }


}