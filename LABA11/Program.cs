using System.Collections;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Collections.Generic;
namespace LABA11
{
    public class Program
    {
        public static void PrintArrayList(ArrayList arr)
        {
            for (int i = 0; i < arr.Count; i++)
            {
                Console.WriteLine(arr[i]);
            }
        }
        public static void PrintStack(Stack<Car> arr)
        {
            foreach (Car car in arr)
            {
                Console.WriteLine(car);
            }
        }
        public static void Task1()
        {
            // Создаём коллекцию и заполняем её элементами
            ArrayList Cars = new ArrayList(20);
            for (int i = 0; i < 5; i++)
            {
                Car car = new Car();
                car.RandomInit();
                Cars.Add(car);
            }
            for (int i = 5; i < 10; i++)
            {
                Car car = new PassengerCar();
                car.RandomInit();
                Cars.Add(car);
            }
            for (int i = 10; i < 15; i++)
            {
                Car car = new SUV();
                car.RandomInit();
                Cars.Add(car);
            }
            for (int i = 15; i < 20; i++)
            {
                Car car = new Truck();
                car.RandomInit();
                Cars.Add(car);
            }

            // Выводим коллекцию на экран
            Console.WriteLine("Изначальная коллекция:");
            PrintArrayList(Cars);
            Console.WriteLine();

            // Добавляем элемент
            Cars.Add(new Car());
            Console.WriteLine("Элемент добавлен\n");

            // Снова выводим на экран
            PrintArrayList(Cars);
            Console.WriteLine();

            // Удаляем элемент
            Cars.Remove(new Car());
            Console.WriteLine("Элемент удалён\n");

            // И опять выводим на экран
            PrintArrayList(Cars);
            Console.WriteLine();

            // Запросы

            // Самый дорогой внедорожник
            Console.WriteLine("Самый дорогой внедорожник:");
            SUV mostExpensive = new SUV();
            foreach (Car car in Cars)
            {
                if (car is SUV)
                {
                    if (car.Price > mostExpensive.Price)
                    {
                        mostExpensive = (SUV)car;
                    }
                }
            }
            Console.WriteLine(mostExpensive);
            Console.WriteLine();

            // Средняя скорость среди пассажирских автомобилей
            int k = 0;
            int s = 0;
            foreach (Car car in Cars)
            {
                PassengerCar pc = car as PassengerCar;
                if (pc != null)
                {
                    k++;
                    s += pc.MaxSpeed;
                }
            }
            Console.WriteLine($"Средняя скорость среди пассажирских автомобилей: {(double)s / k}");
            Console.WriteLine();

            // Грузовик с максимальной грузоподъёмностью
            Console.WriteLine("Грузовик с максимальной грузоподъёмностью");
            Truck maxtruck = new Truck();
            foreach (Car car in Cars)
            {
                if (car.GetType() == typeof(Truck))
                {
                    Truck currTruck = (Truck)car;
                    if (currTruck.LoadCapacity > maxtruck.LoadCapacity)
                    {
                        maxtruck = currTruck;
                    }
                }
            }
            Console.WriteLine(maxtruck);
            Console.WriteLine();

            // Клонирование коллекции
            ArrayList CarsClone = new ArrayList(20);
            foreach (Car car in Cars)
            {
                CarsClone.Add(car.Clone());
            }

            // Вывод клона
            Console.WriteLine("Клон коллекции:");
            PrintArrayList(CarsClone);
            Console.WriteLine();

            // Сортировка коллекции
            Cars.Sort();
            Console.WriteLine("Отсортированная коллекция:");
            PrintArrayList(Cars);
            Console.WriteLine();

            // Поиск элемента
            Car Hyundaicar = new Car();
            Hyundaicar.Brand = "Hyundai";
            int index = Cars.BinarySearch(Hyundaicar);
            Console.WriteLine($"Первая Hyundai была найдена под номером: {index + 1}");

        }
        public static void Task2()
        {
            // Создаём коллекцию и заполняем её элементами
            Stack<Car> Cars = new Stack<Car>();
            for (int i = 0; i < 5; i++)
            {
                Car car = new Car();
                car.RandomInit();
                Cars.Push(car);
            }
            for (int i = 5; i < 10; i++)
            {
                Car car = new PassengerCar();
                car.RandomInit();
                Cars.Push(car);
            }
            for (int i = 10; i < 15; i++)
            {
                Car car = new SUV();
                car.RandomInit();
                Cars.Push(car);
            }
            for (int i = 15; i < 20; i++)
            {
                Car car = new Truck();
                car.RandomInit();
                Cars.Push(car);
            }

            // Выводим коллекцию на экран
            Console.WriteLine("Изначальная коллекция:");
            PrintStack(Cars);
            Console.WriteLine();

            // Добавляем элемент
            Cars.Push(new Car());
            Console.WriteLine("Элемент добавлен\n");

            // Снова выводим на экран
            PrintStack(Cars);
            Console.WriteLine();

            // Удаляем элемент
            Cars.Pop();
            Console.WriteLine("Элемент удалён\n");

            // И опять выводим на экран
            PrintStack(Cars);
            Console.WriteLine();

            // Запросы

            // Самый дорогой внедорожник
            Console.WriteLine("Самый дорогой внедорожник:");
            SUV mostExpensive = new SUV();
            foreach (Car car in Cars)
            {
                if (car is SUV)
                {
                    if (car.Price > mostExpensive.Price)
                    {
                        mostExpensive = (SUV)car;
                    }
                }
            }
            Console.WriteLine(mostExpensive);
            Console.WriteLine();

            // Средняя скорость среди пассажирских автомобилей
            int k = 0;
            int s = 0;
            foreach (Car car in Cars)
            {
                PassengerCar pc = car as PassengerCar;
                if (pc != null)
                {
                    k++;
                    s += pc.MaxSpeed;
                }
            }
            Console.WriteLine($"Средняя скорость среди пассажирских автомобилей: {(double)s / k}");
            Console.WriteLine();

            // Грузовик с максимальной грузоподъёмностью
            Console.WriteLine("Грузовик с максимальной грузоподъёмностью");
            Truck maxtruck = new Truck();
            foreach (Car car in Cars)
            {
                if (car.GetType() == typeof(Truck))
                {
                    Truck currTruck = (Truck)car;
                    if (currTruck.LoadCapacity > maxtruck.LoadCapacity)
                    {
                        maxtruck = currTruck;
                    }
                }
            }
            Console.WriteLine(maxtruck);
            Console.WriteLine();

            // Клонирование коллекции
            Stack<Car> CarsClone = new Stack<Car>(Cars);
            Console.WriteLine("Клон:");
            PrintStack(CarsClone);
            Console.WriteLine();

            // Перебор с foreach
            bool okOrNot = false;
            foreach (Car car in Cars)
            {
                okOrNot = true;
            }
            Console.WriteLine(okOrNot);

            // Сортировка коллекции
            List<Car> list = Cars.ToList();
            list.Sort((a, b) => b.CompareTo(a));
            Cars.Clear();
            foreach (Car car in list)
            {
                Cars.Push(car);
            }
            Console.WriteLine("Отсортированная коллекция:");
            PrintStack(Cars);
            Console.WriteLine();

            // Поиск элемента
            Car Hyundaicar = new Car();
            Hyundaicar.Brand = "Hyundai";
            int index = list.BinarySearch(Hyundaicar);
            Console.WriteLine($"Первая Hyundai была найдена под номером: {index + 1}");
        }
        public static void Task3()
        {
            // Генерируем коллекции
            TestCollections TC = new TestCollections(1000);

            // Подготовка к поиску элементов
            Stopwatch sw = Stopwatch.StartNew();

            // Ищем элемент
            Truck? elem = TC.last; // Выбор елемента (первый, средний, последний)

            // В LinkedList<Truck>
            sw.Restart();
            bool wasFound = TC.col1.Contains(elem);
            sw.Stop();
            if (wasFound)
            {
                Console.WriteLine($"Элемент был найден в LinkedList<Truck> за {sw.ElapsedTicks} тиков.");
            }
            else
            {
                Console.WriteLine($"Элемент не был найден в LinkedList<Truck> найден за {sw.ElapsedTicks} тиков.");
            }

            // В LinkedList<string>
            sw.Restart();
            wasFound = TC.col2.Contains(elem.ToString());
            sw.Stop();
            if (wasFound)
            {
                Console.WriteLine($"Элемент был найден в LinkedList<string> за {sw.ElapsedTicks} тиков.");
            }
            else
            {
                Console.WriteLine($"Элемент не был найден в LinkedList<string> найден за {sw.ElapsedTicks} тиков.");
            }

            // В Dictionary<Car, Truck> по ключу
            sw.Restart();
            wasFound = TC.col3.ContainsKey(elem.GetBase());
            sw.Stop();
            if (wasFound)
            {
                Console.WriteLine($"Элемент был найден в Dictionary<Car, Truck> по ключу за {sw.ElapsedTicks} тиков.");
            }
            else
            {
                Console.WriteLine($"Элемент не был найден в Dictionary<Car, Truck> по ключу найден за {sw.ElapsedTicks} тиков.");
            }

            // В Dictionary<string, Truck> по ключу
            sw.Restart();
            wasFound = TC.col4.ContainsKey(elem.GetBase().ToString());
            sw.Stop();
            if (wasFound)
            {
                Console.WriteLine($"Элемент был найден в Dictionary<string, Truck> по ключу за {sw.ElapsedTicks} тиков.");
            }
            else
            {
                Console.WriteLine($"Элемент не был найден в Dictionary<string, Truck> по ключу найден за {sw.ElapsedTicks} тиков.");
            }
        }
        static void Main(string[] args)
        {
            UI.Menu();
        }
    }
}
