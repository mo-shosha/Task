using Task_1.Service;

namespace Task_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var detector = new FizzBuzz();

            string input =
                @"Mary had a little lamb
Little lamb, little lamb
Mary had a little lamb
It's fleece was white as snow
";
            //Console.WriteLine(input.Length);
            var result = detector.GetOverlapping(input);

            Console.WriteLine("OUTPUT:");
            Console.WriteLine(result.Result);

            Console.WriteLine("\nCOUNT:");
            Console.WriteLine(result.Count);

        }
    }
}
