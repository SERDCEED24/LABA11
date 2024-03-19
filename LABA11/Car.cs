﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LABA11
{
    // IdNumber
    public class IdNumber
    {
        // Поля
        private int number;
        // Свойства
        public int Number
        {
            get
            {
                return number;
            }
            set
            {
                if (value < 0)
                {
                    Console.WriteLine("Number не может быть меньше 0.");
                    number = 0;
                }
                else
                {
                    number = value;
                }
            }
        }
        // Конструкторы
        public IdNumber()
        {
            Number = 0;
        }
        public IdNumber(int n)
        {
            Number = n;
        }
        public IdNumber(IdNumber other)
        {
            Number = other.Number;
        }
        // Методы
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            IdNumber other = (IdNumber)obj;
            return Number == other.Number;
        }
        public override string ToString()
        {
            return Number.ToString();
        }
    }
    // Car
    public class Car : IInit, ICloneable, IComparable
    {
        // ДСЧ
        public static Random rnd = new Random();
        // Поля
        protected string brand;
        protected int year;
        protected string color;
        protected int price;
        protected int gClearance;
        // Свойства
        public IdNumber id { get; set; }
        public string Brand { get; set; }
        public int Year
        {
            get
            {
                return year;
            }
            set
            {
                if (value >= 1885 && value <= DateTime.Now.Year)
                    year = value;
                else
                {
                    Console.WriteLine("Год выпуска должен быть в диапазоне от 1885 до текущего года.");
                    year = 1885;
                }
            }
        }
        public string Color { get; set; }
        public int Price
        {
            get
            {
                return price;
            }
            set
            {
                if (value >= 0)
                    price = value;
                else
                {
                    Console.WriteLine("Цена не может быть отрицательной.");
                    price = 0;
                }
            }
        }
        public int GClearance
        {
            get
            {
                return gClearance;
            }
            set
            {
                if (value > 0)
                    gClearance = value;
                else
                {
                    Console.WriteLine("Дорожный просвет должен быть больше нуля.");
                    gClearance = 1;
                }
            }
        }
        // Конструкторы
        public Car()
        {
            id = new IdNumber();
            Brand = "Нет бренда";
            Year = 1885;
            Color = "Нет цвета";
            Price = 0;
            GClearance = 1;
        }
        public Car(int num, string b, int y, string c, int p, int gc)
        {
            id = new IdNumber(num);
            Brand = b;
            Year = y;
            Color = c;
            Price = p;
            GClearance = gc;
        }
        public Car(Car other)
        {
            id = other.id;
            Brand = other.Brand;
            Year = other.Year;
            Color = other.Color;
            Price = other.Price;
            GClearance = other.GClearance;
        }
        // Методы
        public virtual void ShowVirt()
        {
            Console.WriteLine($"ID: {id.Number}, Бренд: {Brand}, Год выпуска: {Year}, Цвет: {Color}, Стоимость: {Price} руб., Дорожный просвет: {GClearance} мм");
        }
        public void ShowReg()
        {
            Console.WriteLine($"ID: {id.Number}, Бренд: {Brand}, Год выпуска: {Year}, Цвет: {Color}, Стоимость: {Price} руб., Дорожный просвет: {GClearance} мм");
        }
        public override string ToString()
        {
            return $"ID: {id.Number}, Бренд: {Brand}, Год выпуска: {Year}, Цвет: {Color}, Стоимость: {Price} руб., Дорожный просвет: {GClearance} мм";
        }
        public virtual void Init()
        {
            Console.WriteLine("Введите ID:");
            id.Number = VHS.Input("ID не может быть отрицательным.", 0, 100000000);

            Console.WriteLine("Введите бренд:");
            Brand = Console.ReadLine();

            Console.WriteLine("Введите год выпуска:");
            Year = VHS.Input("Год должен быть в пределах от 1885 до текущего.", 0, 100000000);

            Console.WriteLine("Введите цвет:");
            Color = Console.ReadLine();

            Console.WriteLine("Введите стоимость:");
            Price = VHS.Input("Цена не может быть отрицательной.", 0, 100000000);

            Console.WriteLine("Введите дорожный просвет:");
            GClearance = VHS.Input("Дорожный просвет может быть от 1 до 400 мм.", 1, 400);
        }
        public virtual void RandomInit()
        {
            string[] brands = { "Toyota", "Honda", "Ford", "BMW", "Mercedes-Benz", "Audi", "Volkswagen", "Chevrolet", "Hyundai", "Nissan" };
            string[] colors = { "Красный", "Синий", "Зеленый", "Желтый", "Черный", "Белый", "Оранжевый", "Фиолетовый", "Розовый", "Серый" };
            id.Number = rnd.Next(1, 100);
            Brand = brands[rnd.Next(10)];
            Year = rnd.Next(1885, DateTime.Now.Year);
            Color = colors[rnd.Next(10)];
            Price = rnd.Next(0, 10000000);
            GClearance = rnd.Next(1, 400);
        }
        public int CompareTo(object? obj)
        {
            if (obj == null) return -1;
            if (obj is not Car) return -1;
            Car other = obj as Car;
            return String.Compare(this.Brand, other.Brand);
        }
        public virtual object Clone()
        {
            return new Car(this.id.Number, this.Brand, this.Year, this.Color, this.Price, this.gClearance);
        }
        public object ShallowCopy()
        {
            return this.MemberwiseClone();
        }
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;
            Car other = (Car)obj;
            return id.Number == other.id.Number && Brand == other.Brand && Year == other.Year && Color == other.Color && Price == other.Price && GClearance == other.GClearance;
        }
        public override int GetHashCode()
        {
            return id.Number.GetHashCode() ^ Brand.GetHashCode() ^ Year.GetHashCode() ^ Color.GetHashCode() ^ Price.GetHashCode() ^ GClearance.GetHashCode();
        }
    }
}
