using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LABA11
{
    public class TestCollections
    {
        public LinkedList<Truck> col1 = new LinkedList<Truck>();
        public LinkedList<string> col2 = new LinkedList<string>();
        public Dictionary<Car, Truck> col3 = new Dictionary<Car, Truck>();
        public Dictionary<string, Truck> col4 = new Dictionary<string, Truck>();
        public Truck? first, middle, last;
        public TestCollections(int length)
        {
            for (int i = 0; i < length; i++)
            {
                try
                {
                    Truck t = new Truck();
                    t.RandomInit();
                    t.Brand += i.ToString();
                    Car c = t.GetBase();
                    col1.AddLast(t);
                    col2.AddLast(t.ToString());
                    col3.Add(c, t);
                    col4.Add(c.ToString(), t);
                    if (i==0)
                    {
                        first = (Truck)t.Clone();
                    }
                    if (i == length / 2)
                    {
                        middle = (Truck)t.Clone();
                    }
                    if (i == length - 1)
                    {
                        last = (Truck)t.Clone();
                    }
                }
                catch (Exception e) 
                {
                    i--;
                }
            }
        }
    }
}
