using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StacksAndQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            MyQueue myq = new MyQueue();
            myq.Enqueue(1);
            myq.Enqueue(2);
            myq.Enqueue(3);
            myq.Enqueue(4);
            myq.Enqueue(5);
            myq.Enqueue(6);

            Console.WriteLine("\n first in line: {0}", myq.Peek());

            int x = (int)myq.Dequeue();
            Console.WriteLine("\n remove first item: {0} and count is: {1}", x,  myq.Count);

            object[] ar = myq.ToArray();
            Console.WriteLine("\n\n Displaying toArray()}");

            foreach (object obj in ar)
                Console.Write("{0}", obj);

            Console.ReadLine();

            /************************************************/

            


        }


        //Class for QUEUE
        public class MyQueue
        {
            private object[] array;
            private int front;
            private int tail;
            private int count;


            //Contructor
            public MyQueue(): this(8)
            {
                
            }

            public MyQueue(int capacity)
            {
                array = new object[capacity];
                count = 0;
                front = -1;
                tail = -1;

            }

            public int Count { get { return this.count; } }

            //
            public void Enqueue(object item)
            {
                //Adds to the last of the Queue
                if(count == 0) // check if queue is empty
                {
                    front = tail = 0;

                    // add items to the tail
                    array[tail] = item;
                }
                else if(count < array.Length)
                {
                    //Thre is at least one space left
                    tail++;
                    tail = tail % array.Length; // If tail has exceede teh last index 
                                                // it will be set to 0 (Zero)

                    array[tail] = item;
                }
                else
                {
                    //array is full
                    //create a new temp array twice as big 
                    object[] temp = new object[array.Length * 2];
                    
                    //copy array to temp

                    for(int i=0; i<array.Length; i++)
                    {
                        temp[i] = array[front];
                        //front++;
                        front = (front + 1) % array.Length;
                    }

                    ////reset array to refer to temp
                    array = temp;
                    front = 0;
                    tail = count;
                    array[tail] = item;
                }

                count++;
            }

            public object Dequeue()
            {
                //Removes the first element of the queue
                array[front] = 0;
                //If empty throw an ArgumentException
                if(count == 0)
                {
                    throw new ArgumentException("Queue is empty. Count == 0 Zero");
                }
                else if(count == 1)
                {
                    //cache teh value to return
                    object item = array[front];
                    //reset front and tail to -1
                    front = tail = -1;
                    count = 0;
                    return item;
                }
                else
                {
                    object item = array[front];
                    //increment the front
                    front = (front + 1) % array.Length;
                    count--;
                    return item;
                }



                

            }

            public object Peek()
            {
                //Returns the first element of the queue, but does not remove the first item.
                if (count == 0)
                {
                    throw new ArgumentException("Queue is empty. Count == 0 Zero");
                }
                else
                {
                    object item = array[front];
                    return item;

                }

            }

            public object[] ToArray()
            {
                //Copies the queue to an Array then return the array
                object[] temp = new object[count];
                for(int i = 0; i < count; i++)
                {
                    temp[i] = array[front];
                    front = (front + 1) % array.Length;

                }
                return temp;

            }
        }


        public class MyStack
        {
            private object[] array;
            private int top;
            private int count;


            public MyStack():this(8)
            {

            }



            public MyStack(int capacity)
            {
                top = -1;
                count = 0;
                array = new object[capacity];
            }
            //Push
            public void Push(object item)
            {
                if(count < array.Length)
                {
                    array[top] = item;
                }
                else
                {
                    //create a temp array twice as large
                    object[] temp = new object[array.Length * 2];

                    //copy array to temp
                    for(int i= 0; i < array.Length; i++)
                    {
                        temp[i] = array[i];
                    }

                    //reset array to poin to temp
                    array = temp;
                    array[top] = item;
                    count++;
                }
          
    

            }




            //Pop 
            public object Pop()
            {
                if (count == 0)
                    throw new ArgumentException("stack empty");

                object item = array[top];
                top--;
                count--;
                return item;

            }

            //Peek
            public object Peek()
            {
                if (count == 0)
                    throw new ArgumentException("stack empty");

                object item = array[top];
                return item;


            }

            //ToArray
            public object[] ToArray()
            {
                object[] temp = new object[count];
                for (int i = 0; i < count; i++)
                {
                    temp[i] = array[top];
                    top = (top + 1) % array.Length;

                }
                return temp;

            }
        }


       
    }

    //Linkedlist single or double
}
