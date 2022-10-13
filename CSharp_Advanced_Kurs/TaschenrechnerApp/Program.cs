using System.Reflection;

namespace TaschenrechnerApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Laden Dll
            Assembly geladeneDll = Assembly.LoadFrom("Taschenrechner.dll");


            //selektieren Typ
            Type type = geladeneDll.GetType("Taschenrechner.MyCalc");

            
            //Adresse wird von myCalc hintelegt
            object tr = Activator.CreateInstance(type);


            //C#       |     Nativer .NET Type
            //int      |     Int32
            //string   |     String
            //bool     |     Boolean
            MethodInfo methodInfo = type.GetMethod("Add", new Type[] { typeof(Int32), typeof(Int32) });

            object result = methodInfo.Invoke(tr, new object[] { 11, 33 });

            Console.WriteLine(result);

            Console.ReadLine();


        }
    }
}