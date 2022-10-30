using System;
//using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unit4;

namespace stackPractice
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        static Stack<int> Copy(Stack<int> s)// FROM HIRE!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        {
            Stack<int> copy = new Stack<int>();
            Stack<int> r = new Stack<int>();

            while (!s.IsEmpty())
                copy.Push(s.Pop());

            while (!copy.IsEmpty())
            {
                s.Push(copy.Top());
                r.Push(copy.Pop());
            }

            return r;
        }
        static void Spill(Stack<int> destination, Stack<int> source)
        {
            // take all elements in source and transfering to destination
            Stack<int> copy = new Stack<int>();
            while (!source.IsEmpty())
                copy.Push(source.Pop());

            while (!copy.IsEmpty())
                destination.Push(copy.Pop());
        }
        static void Print (Stack<int> s)
        {
            // prints the stack without changing its build
            Stack<int> copy = Copy(s);
            while (!copy.IsEmpty())
                Console.WriteLine(copy.Pop());
        }
        static bool Exists(Stack<int> stack, int x)
        {
            Stack<int> copy = Copy(stack);
            while(!copy.IsEmpty())
                if(copy.Pop() == x)
                    return true;

            return false;
        }
        static int CountAndRemove (Stack<int> stack, int x)
        {
            //input => a stack and a number
            //output=> counts how many time x appears in stack  and removes them
            if (!Exists(stack, x))
                return 0;
// חוזר המון על פעולות
            int count = 0;
            Stack<int> copy = new Stack<int>();
            while (!stack.IsEmpty())
            {
                if(stack.Top() == x)
                    count++;
                copy.Push(stack.Pop());
            }

            while (!copy.IsEmpty())
            {
                if(copy.Top() == x)
                {
                    copy.Pop();
                    continue;
                }
                stack.Push(copy.Pop());
            }

            return count;
        }
        static int Count (Stack<int> stack, int x)
        {
            //input => a stack and a number
            //output => counts how many times x exists in the stack
            Stack<int> copy = Copy(stack);
            return CountAndRemove(copy, x);
        }
        static void AddSorted (Stack<int> s, int x)
        {
            // Add individual number to stack
            s.Push(x);
            SortAll(s);
        }
        static Stack<int> SortAll (Stack<int> s)
        {
            int count = 0;
            Stack<int> copy = new Stack<int>();
            while (!s.IsEmpty())
            {
                count++;
                copy.Push(s.Pop());
            }
            int[] sorted = new int[count];

            for (int i = 0; i < count; i++)
                sorted[i] = copy.Pop();
            Array.Sort(sorted);

            for (int i = 0; i < count; i++)
            {
                s.Push(sorted[i]);
                copy.Push(sorted[i]);
            }
            return copy;
        }
        static bool aXbXa (string s)
        {
            // check whether the string is arranged as string until X from then on b is the oposite order than a, and the last thrird is the same as the original
            // stack/
            Stack<char> firstPart = new Stack<char>();
            Stack<char> secondPart = new Stack<char>();
            int len = s.Length / 2;

            for (int i = 0; i < len; i++)
                firstPart.Push(s[i]);

            for (int i = len; i < s.Length; i++)
                secondPart.Push(s[i]);

            while (!firstPart.IsEmpty())
                if(firstPart.Pop() != secondPart.Pop())
                    return false;

            return true;
        }
        static int RemoveBiggest (Stack<int> s)
        {
            Stack<int> copy = new Stack<int>();
            int biggest = s.Top();
            while (!s.IsEmpty())
            {
                if(biggest < s.Top())
                    biggest = s.Top();

                copy.Push(s.Pop());
            }

            while (!copy.IsEmpty())
            {
                if (biggest == copy.Top())
                {
                    copy.Pop();
                    continue;
                }
                //לדעתי יותר נכון אחרת
                s.Push(copy.Pop());
                
            }

            return biggest;
        }
      
        static bool AllDifferent(Stack<int> s)//TO HIRE!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        {
            // checks and returns true if all the numbers are different
            Stack<int> copy1 = Copy(s);
            int index = 0;
            while (!copy1.IsEmpty())
            {
                s.Push(copy1.Pop());
                index++;
            }

            int[] ar = new int[index];
            for (int i = 0; i < index; i++)
            {
                ar[i] = s.Top();
                copy1.Push(s.Pop());
            }

            for (int i = 0; i < index; i++)
                if(Count(s, i) > 1)
                    return false;

            return true;
            // אני מעדיפה לא לעבוד עם מערך!
        }
        static Stack<int> Merge(Stack<int> s1, Stack<int> s2)
        {
            // merge two ordered stacks 
            throw new NotImplementedException();
        }
        static Stack<int> Gather(Stack<int> s)
        {
            //gathers same numbers and adds them and saves in new stack. if has only one, doesn't add the value to stack
            // example [3,3,3,4,5,5,1,1,1,1] => [9, 10,4]
            throw new NotImplementedException();
        }
    }
}
