using BV.Library;
using System;

namespace BV {
    class Program {

        private static String errorMessage = "ERROR";
        static void Main(string[] args) {
            Console.WriteLine("SIZE xx sets the size of the cache to xx ");
            Console.WriteLine("SET xx yy sets the value at key xx as yy");
            Console.WriteLine("GET xx gets the value at key xx");
            Console.WriteLine("EXIT stops the fun =(");

            LRUCache cache = null;

            while (true) {
                var input = Console.ReadLine();
                if (input == "EXIT") {
                    break;
                }
                String[] commands = input.Split(' ');

                if (commands.Length == 0) {
                    Console.WriteLine(errorMessage);
                    continue;
                }

                if (cache == null) {
                    if (commands[0] == "SIZE") {
                        cache = new LRUCache(Convert.ToInt32(commands[1]));
                        Console.WriteLine("SIZE OK");
                        continue;
                    } else {
                        Console.WriteLine(errorMessage);
                        Console.WriteLine("NEED SIZE PLEASE");
                        continue;
                    }

                }

                if (commands[0] == "SET") {
                    if (commands.Length != 3) {
                        Console.WriteLine(errorMessage);
                        continue;
                    }
                    cache.set(commands[1], commands[2]);
                    Console.WriteLine("SET OK");
                    continue;
                }

                if (commands[0] == "GET") {
                    if (commands.Length != 2) {
                        Console.WriteLine(errorMessage);
                        continue;
                    }
                    var result = cache.get(commands[1]);
                    Console.WriteLine(result != null ? $"GOT {result}" : "NOT FOUND");
                    continue;
                }
                Console.WriteLine(errorMessage);
                continue;

            }; 
        }
    }
}
