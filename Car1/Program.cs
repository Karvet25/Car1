using System;

public class Car
{
    private string brand;
    private string model;
    private string licensePlate;
    private string color;
    private bool isRunning;
    private int gear;
    private int speed;

    public Car(string brand, string model, string licensePlate, string color)
    {
        this.brand = brand;
        this.model = model;
        this.licensePlate = licensePlate;
        this.color = color;
        this.isRunning = false;
        this.gear = 0;
        this.speed = 0;
    }

    public void Start()
    {
        if (gear == 0 || gear == 1)
        {
            isRunning = true;
            Console.WriteLine("Машина заведена.");
        }
        else
        {
            isRunning = false;
            Console.WriteLine("Машина заглохла.");
        }
    }

    public void Stop()
    {
        isRunning = false;
        Console.WriteLine("Машина заглушена.");
    }

    public void Accelerate()
    {
        if (isRunning && gear > 0)
        {
            if (speed <= GetMaxSpeedForGear(gear))
            {
                speed += 10;
                Console.WriteLine($"Скорость увеличена до {speed} км/ч.");
            }
            else
            {
                Console.WriteLine("Достигнута максимальная скорость для текущей передачи.");
            }
        }
        else
        {
            Console.WriteLine("Нельзя увеличить скорость.");
        }
    }

    public void Brake()
    {
        if (isRunning && speed > 0)
        {
            speed -= 10;
            Console.WriteLine($"Скорость уменьшена до {speed} км/ч.");
        }
        else
        {
            Console.WriteLine("Нельзя притормозить.");
        }
    }

    public void ChangeGear(int newGear)
    {
        if (isRunning && newGear >= 0 && newGear <= 5)
        {
            if (speed >= GetMinSpeedForGear(newGear) && speed <= GetMaxSpeedForGear(newGear))
            {
                gear = newGear;
                Console.WriteLine($"Передача изменена на {gear}-ю.");
            }
            else
            {
                Console.WriteLine("Скорость не соответствует передаче.");
                Stop();
            }
        }
        else
        {
            Console.WriteLine("Нельзя изменить передачу.");
        }
    }

    private int GetMinSpeedForGear(int gear)
    {
        switch (gear)
        {
            case 0: return 0;
            case 1: return 0;
            case 2: return 20;
            case 3: return 40;
            case 4: return 60;
            case 5: return 80;
            default: return 0;
        }
    }

    private int GetMaxSpeedForGear(int gear)
    {
        switch (gear)
        {
            case 0: return 0;
            case 1: return 30;
            case 2: return 50;
            case 3: return 70;
            case 4: return 90;
            case 5: return 120;
            default: return 0;
        }
    }

    public void Run()
    {
        while (true)
        {
            Console.WriteLine("Выберите действие:");
            Console.WriteLine("1. Завести машину");
            Console.WriteLine("2. Заглушить машину");
            Console.WriteLine("3. Нажать на газ (разогнаться)");
            Console.WriteLine("4. Нажать на тормоз (притормозить)");
            Console.WriteLine("5. Поменять передачу");
            Console.WriteLine("6. Выход");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Start();
                    break;
                case "2":
                    Stop();
                    break;
                case "3":
                    Accelerate();
                    break;
                case "4":
                    Brake();
                    break;
                case "5":
                    Console.WriteLine("Введите номер передачи (0-5):");
                    if (int.TryParse(Console.ReadLine(), out int newGear))
                    {
                        ChangeGear(newGear);
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

class Program
{
    static void Main()
    {
        Car myCar = new Car("Toyota", "Camry", "ABC123", "Blue");
        myCar.Run();
    }
}
