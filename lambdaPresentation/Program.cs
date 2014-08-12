/*
 * Hi, I'm Jeremy Miranda
 * 
 *  
 * */


/*
 * Vocabulary:
 *  LINQ
 *  Extension Method
 *  Delegate
 *  Func
 *  Action
 *  Expression
 *  IEnumerable
 *  IQueryable
 * 
 * 
 * */







using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Extensions;

namespace lambdaPresentation
{
    class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<string> nerds = new[] { "Lewis", "Booger", "Gilbert", "Poindexter", "Takashi", "Lamar", "LLLLLL" };

            //Delegate Example
            //IEnumerable<string> query = nerds.Filter(NerdsThatStartWithL);   

            //Annonymous Delegate example
            //IEnumerable<string> query = nerds.Filter(delegate(string item)
            //{
            //    return item.StartsWith("L");
            //});

            //Lambda Example
            //IEnumerable<string> query = nerds.Filter((item) => item.StartsWith("L"));

            //Funky Lambda Example
            //IEnumerable<string> query = nerds.Where(nerd => nerd.StartsWith("L"))
            //                            .OrderByDescending(nerd => nerd.Length);
            //foreach (var nerd in query)
            //{
            //    Console.WriteLine(nerd);
            //}

            //Console.ReadKey();

            // WorkWithFuncs();


            //private static void WorkWithFuncs()
            //{
            //Func is a generic Type. 
            //Func encapsulates delegates
            Func<int, int> square = x => x * x;

            //#blameWill
            Console.WriteLine(square(3));

            

            //With more than 1 param, () is required
            Func<int, string, string> add = (x, y) => x + y;

            Console.WriteLine(add(1, " bob"));
            //Console.WriteLine(square(add(1, 2)));
            Console.ReadKey();
            //Action returns void, so no return type is needed
            Action<int> write = x => Console.WriteLine(x);


            //Expressions wrap Func Types
            //Expression<Func<int, int>> square = x => x * x;

            //write(square(add(1, 2)));
            // }


        }




        static bool NerdsThatStartWithL(string s)
        {
            return s.StartsWith("L");
        }
    }
}

namespace Extensions
//{
//    public static class FilterExtensions
//    {
//        public static IEnumerable<T> Filter<T> (this IEnumerable<T> input, FilterDelegate<T> predicate)
//        {
//            foreach (var item in input)
//            {
//                if (predicate(item))
//                {
//                    yield return item;
//                }
//            }
//        }
//    }
//    public delegate bool FilterDelegate<T>(T item);
//}
{
    public static class FilterExtensions
    {
        public static IEnumerable<T> Filter<T>(this IEnumerable<T> input,
                                                Func<T, bool> predicate)
        {
            foreach (var item in input)
            {
                if (predicate(item))
                {
                    yield return item;
                }
            }
        }
    }
}