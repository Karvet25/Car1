using System;
using System.Collections.Generic;

public class Car
{
    private string brand;
    private bool isRunning;
    private int gear;
    private int speed;

    public Car(string brand)
    {
        this.brand = brand;
        this.isRunning = false;
        this.gear = 0;
        this.speed = 0;
    }

    public void Start(string message)
    {
        isRunning = true;
        Console.WriteLine($"{message} Машина {brand} завелась.");
    }

    public void Stop(string message)
    {
        isRunning = false;
        Console.WriteLine($"{message} Машина {brand} остановилась.");
    }

    public void Accelerate(string message)
    {
        if (isRunning)
        {
            speed += 10;
            Console.WriteLine($"{message} Скорость машины {brand} увеличена до {speed} км/ч.");
        }
        else
        {
            Console.WriteLine($"{message} Машина {brand} не может двигаться, так как остановлена.");
        }
    }

    public void Brake(string message)
    {
        if (isRunning && speed > 0)
        {
            speed -= 10;
            Console.WriteLine($"{message} Скорость машины {brand} уменьшена до {speed} км/ч.");
        }
        else
        {
            Console.WriteLine($"{message} Машина {brand} не может тормозить, так как остановлена или стоит на месте.");
        }
    }

    public void ChangeGear(string message, int newGear)
    {
        if (isRunning && newGear >= 0 && newGear <= 5)
        {
            gear = newGear;
            Console.WriteLine($"{message} Передача машины {brand} изменена на {gear}-ю.");
        }
        else
        {
            Console.WriteLine($"{message} Машина {brand} не может изменить передачу.");
        }
    }

    public override string ToString()
    {
        return brand;
    }
}

class Program
{
    static void Main()
    {
        List<Car> cars = new List<Car>
        {
            new Car("ВАЗ 2101"),
            new Car("Mersedes 600"),
            new Car("Toyota Corolla")
        };

        Console.WriteLine("Выберите машину:");

        for (int i = 0; i < cars.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {cars[i]}");
        }

        int selectedCarIndex = int.Parse(Console.ReadLine()) - 1;

        Car selectedCar = cars[selectedCarIndex];

        Console.WriteLine($"Вы выбрали машину: {selectedCar}");

        while (true)
        {
            Console.WriteLine("Выберите действие:");
            Console.WriteLine("1. Завести машину");
            Console.WriteLine("2. Заглушить машину");
            Console.WriteLine("3. Газануть");
            Console.WriteLine("4. Притормозить");
            Console.WriteLine("5. Переключить передачу");
            Console.WriteLine("6. Выход");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    selectedCar.Start("Вы:");
                    break;
                case "2":
                    selectedCar.Stop("Вы:");
                    break;
                case "3":
                    selectedCar.Accelerate("Вы:");
                    break;
                case "4":
                    selectedCar.Brake("Вы:");
                    break;
                case "5":
                    Console.WriteLine("Введите номер передачи (0-5):");
                    if (int.TryParse(Console.ReadLine(), out int newGear))
                    {
                        selectedCar.ChangeGear("Вы:", newGear);
                    }
                    else
                    {
                        Console.WriteLine("Некорректный ввод передачи.");
                    }
                    break;
                case "6":
                    Console.WriteLine("Программа завершена.");
                    return;
                default:
                    Console.WriteLine("Некорректная команда.");
                    break;
            }
        }
    }
}

