using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ООП7
{
    class Node
    {
        public double value;
        public Node previous;
        public Node next;
        public Node(double val)
        {
            value = val;
            previous = null;
            next = null;
        }
    }
    class LinkedList
    {
        public Node head;
        public Node tail;
        public LinkedList()
        {
            head = null;
            tail = null;
        }
        public void Add(double value)
        {
            Node node = new Node(value);
            if (head == null)
            {
                head = node;
                tail = node;
            }
            else
            {
                head.previous = node;
                node.next = head;
                head = node;
            }
        }
        public void DeleteByIndex(int index)
        {
            if (this.head == null || index < 0)
            {
                return;
            }
            else if (index == 0)
            {
                if (this.head.next != null)
                {
                    this.head = this.head.next;
                    this.head.previous = null;
                }
                else
                {
                    this.head = null;
                    this.tail = null;
                }
                return;
            }
            else
            {
 
                Node node = this.head;
                int i = 0;
                
                while (node != null)
                {
                    if (i == index)
                    {
                        if(node.next != null)
                        {
                            node.previous.next = node.next;
                            node.next.previous = node.previous;
                        }
                        else
                        {
                            node.previous.next = null;
                        }
                        node = null;
                        return;
                    }
                    i++;
                    node = node.next;
                }
                return;
            }
        }
        public double? GetElement(int index)
        {
            if(index < 0 || this.head == null)
            {
                return null;
            }
            Node node = this.head;
            int i = 0;
            while (node != null)
            {
                if (i == index)
                {
                    return node.value;
                }
                i++;
                node = node.next;
            }
            return null;
        }
        public double? this[int index]
        {
            get { return GetElement(index); }
        }

        public double? GetArithmeticMean()
        {
            if(this.head == null)
            {
                return null;
            }
            else
            {
                Node node = this.head;
                double sum = 0;
                int n = 0;
                while (node!=null)
                {
                    sum += node.value;
                    n++;
                    node= node.next;
                }
                return sum / n;
            }
        }
        public double? GetMaxElement()
        {
            if (this.head == null)
            {
                return null;
            }
            else
            {
                Node node = this.head;
                double max = node.value;
                node = node.next;
                while (node != null)
                {
                    if (node.value > max)
                    {
                        max = node.value;
                    }
                    node = node.next;
                }
                return max;
            }
        }

        public int? FirstElementLessThanArithmeticMean()
        {
            if (this.head == null || this.head.next == null)
            {
                return null;
            }
            else
            {
                double? arithmeticmean = this.GetArithmeticMean();
                Node node = this.head;
                int n = 0;
                while (node != null)
                {
                    if (node.value < arithmeticmean)
                    {
                        return n;
                    }
                    node = node.next;
                    n++;
                }
                return null;
            }
        }
        public double? SumAfterMax()
        {
            if (this.head == null || this.head.next == null)
            {
                return null;
            }
            else
            {
                double? max = this.GetMaxElement();
                double sum=0;
                Node node = this.head;
                while (node.value!=max)
                {
                    node = node.next;
                }
                node= node.next;
                while(node != null)
                {
                    sum+= node.value;
                    node = node.next;
                }
                return sum;
            }
        }
        public LinkedList GetNewList(double value)
        {
            LinkedList list = new LinkedList();
            if (this.head == null)
            {
                return list;
            }
            Node node = this.head;
            while (node != null)
            {
                if(node.value > value)
                {
                    list.Add(node.value);
                }
                node= node.next;
            }
            return list;
        }
        public void DeleteBeforeMax()
        {
            if (this.head == null || this.head.next==null)
            {
                return;
            }
            double? max = this.GetMaxElement();
            Node node = this.head;
            while (node.value != max)
            {
                node= node.next;
                this.DeleteByIndex(0);
            }
        }
    }
}
