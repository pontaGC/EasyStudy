using CtorArgumentChecker.Implementations;
using CtorArgumentChecker.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CtorArgumentChecker
{
    internal class Program
    {
        private static IComputer MyDesktopPC;
        private static IComputer MyNotePC;
        private static ISmartPhone MySmartPhone;
        private static ICar MyCar;

        static void Main(string[] args)
        {
            MyDesktopPC = new MyDesktopPC();
            MyNotePC = new MyNotePC();
            MySmartPhone = new MySmartPhone();
            MyCar = new MyCar();

            // Expection: Throws no execption
            CreateBelongings();
        }

        private static void CreateBelongings()
        {
            try
            {
                var x = new Belongings(
                    MyDesktopPC,
                    MyNotePC,
                    MySmartPhone,
                    MyCar);
            }
            catch
            {
                Debug.WriteLine($"{nameof(Belongings)} is wrong.");
                throw;
            }
        }

        //internal static T CreateInstanceWithArgumentNullException<T>(ConstructorInfo ctorInfo, IEnumerable<object> arguments)
        //    where T : class
        //{
        //    var parameterExpresssion = new List<Expression>(arguments.Count());
        //    foreach (var argumet in arguments)
        //    {

        //    }

        //    var newExpression = Expression.New(ctorInfo, arguments);
        //    var instantinator = Expression.Lambda<Func<T>>(newExpression).Compile();

        //    return instantinator.Invoke();
        //}
    }
}
