using System;
using System.Linq;
using System.Reflection.Metadata;
using TimeChecker.Domain.Models;
using TimeChecker.Domain.Services;
using TimeChecker.EntityFramework;
using TimeChecker.EntityFramework.Services;

namespace QuickTester
{
    class Program
    {
        static void Main(string[] args)
        {
            IDataService<User> userService = new GenericDataService<User>(new TimeCheckerDbContextFactory());
            Console.WriteLine(userService.Delete(1).Result);


            //Delete


            //Update
            //Console.WriteLine(userService.Update(1, new User() {Username = "TestUser"}).Result);

            //Get
            //Console.WriteLine(userService.Get(1).Result);

            //GetAll
            //Console.WriteLine(userService.GetAll().Result.Count());

            //Create
            //Console.WriteLine(userService.Create(new User() {Username = "Test"}).Result);
        }
    }
}
