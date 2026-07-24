namespace CollectionTask4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SmartStack<int> stack1 = new SmartStack<int>(new List<int>(){1,2,3,4});
            
            stack1.Push(1);

            foreach (int i in stack1)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();

            stack1.Pop();

            foreach (int i in stack1)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();

            List<int> numbers = new List<int>() { 10, 20, 30, 40 };
            stack1.PushRange(numbers);

            foreach (int i in stack1)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();

            SmartStack<int> stack2 = new SmartStack<int>(numbers);

            foreach (int i in stack2)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();

            var stack3 = new SmartStack<int>();
            stack2.Peek();

        }
    }

    
}
