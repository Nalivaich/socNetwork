using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using Common.Repositories;
using EFDataProvider;
using Common.Services;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine(55);
            var tt = new PostService().GetComments(1);
            //Console.Write(tt.GetAll());
            var pp = new EFUnitOfWork();
            foreach(var item in tt)
            {
                Console.Write(item.comment);
            }
            var array = pp.Users.GetAll();
            Console.WriteLine(pp.Posts.Get(2).name);
            foreach (var item in array)
            {
                Console.WriteLine(item.name);
            }
            Console.ReadLine();

        }
    }
}
