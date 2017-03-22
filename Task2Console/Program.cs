using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2Logic;

namespace Task2Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random(123);
            var ring = new RingQueue<int>(25);
            for (int i =0;i<20;i++)
            {
                ring.Enqueue(i);
                //ring.setqueue(i*rand.Next(100));
            }
            for (int i = 0; i < 40; i++)
            {
                ring.Dequeue();                
            }
            for (int i = 30; i < 70; i++)
            {
                ring.Enqueue(i);
            }
            Console.ReadKey();
        }
    }
}
