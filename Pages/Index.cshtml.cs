using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using preislerCars.Models;

namespace preislerCars.Pages;

public class IndexModel : PageModel
{
    public List<Car> cars = new List<Car>();
    [BindProperty]
    public Car car { get; set; } = new();

    public void OnGet()
    {
        cars = Car.LoadCars("data/cars.csv");
    }

    public IActionResult OnPost()
    {
        cars = Car.LoadCars("data/cars.csv");
        if (!ModelState.IsValid)
        {
            return Page();
        }
        cars.Add(car);
        Car.SaveCars("data/cars.csv", cars);

        return RedirectToPage("/Index");
    }
}
