using System;

namespace Boyd_LinkedListSearch
{
    class Program
    {
        static void Main(string[] args)
        {
            stopwatch sw = new stopwatch();

            LinkedList list = new LinkedList(sw);
            sw.startTimer();
            Console.WriteLine(list.search("aza"));
            sw.stopTimer();
            Console.WriteLine(sw.outputTime());
            sw.startTimer();
            Console.WriteLine(list.search("amy"));
            sw.stopTimer();
            Console.WriteLine(sw.outputTime());
            sw.startTimer();
            Console.WriteLine(list.search("aaaa"));
            sw.stopTimer();
            Console.WriteLine(sw.outputTime());

        }
    }
}
