using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ООП7
{
    internal class Program
    {
        private static void PrintList(LinkedList list)
        {
            if(list.head == null)
            {
                Console.WriteLine("List is empty");
                return;
            }
            Node node = list.head;
            while (node != null)
            {
                Console.Write($"{node.value:F2}");
                if (node.next != null)
                {
                    Console.Write(" -> ");
                }
                node = node.next;
            }
            Console.WriteLine();
        }
        private static void FillListRandom(LinkedList list, int size)
        {
            Random random = new Random();
            for (int i = 0; i < size; i++)
            {
                list.Add(Math.Round(random.NextDouble() * 200 - 100, 2));
            }
            
        }
        static void PrintElement(double? element)
        {
            if (element == null)
            {
                Console.WriteLine("This element doesn`t exist");
            }
            else
            {
                Console.WriteLine($"{element:F2}");
            }
        }
        static void Main()
        {
            double? element;
            LinkedList list = new LinkedList();

            Console.WriteLine("List:");
            FillListRandom(list, 10);
            PrintList(list);

            Console.WriteLine("\nElement with index 5");
            element = list[5];
            PrintElement(element);

            Console.WriteLine("\nElement with index -5");
            element = list[-5];
            PrintElement(element);

            Console.WriteLine("\nElement with index 100");
            element = list[100];
            PrintElement(element);

            Console.WriteLine("\nArithmetic mean:");
            element = list.GetArithmeticMean();
            PrintElement(element);

            Console.WriteLine("\nMax element");
            element = list.GetMaxElement();
            PrintElement(element);

            Console.WriteLine("\nIndex of first element less than arithmetic mean");
            int? n = list.FirstElementLessThanArithmeticMean();
            Console.WriteLine(n);

            Console.WriteLine("\nSum of elements after max element");
            double? sum = list.SumAfterMax();
            PrintElement(sum);

            Console.WriteLine("\nList of elements more than 40");
            LinkedList list2 = new LinkedList();
            list2 = list.GetNewList(40);
            PrintList(list2);

            Console.WriteLine("\nList with elements before max deleted");
            list.DeleteBeforeMax();
            PrintList(list);
        }
    }
}
