using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using PropertyChanged;
using SQLiteCar.MVVM.Models;

namespace SQLiteCar.MVVM.ViewModels;

[AddINotifyPropertyChangedInterface]
public class CarPageViewModel
{
    public ObservableCollection<Car> Cars { get; set; } = new ObservableCollection<Car>();
    public Car CurrentCar { get; set; }
    public ICommand AddOrUpdateCommand { get; set; }
    public ICommand DeleteCommand { get; set; }

    public CarPageViewModel()
    {
        this.Refresh();

        AddOrUpdateCommand = new Command(async () =>
        {
            App._carRepo.AddOrUpdate(CurrentCar);
            Console.WriteLine(App._carRepo.StatusMessage);
            this.Refresh();
        });

        DeleteCommand = new Command(async () =>
        {
            if (CurrentCar != null) // Ensure a car is selected
            {
                App._carRepo.Delete(CurrentCar.ID); // Delete the car from the repository
                this.Refresh(); // Refresh the list after deletion
            }
        });
    }

    private void Refresh()
    {
        CurrentCar = new Car();
        Cars.Clear(); // Clear the current list
        var allCars = App._carRepo.GetAll();
        foreach (var car in allCars)
        {
            Cars.Add(car); // Add each car to the ObservableCollection
        }
    }
}
