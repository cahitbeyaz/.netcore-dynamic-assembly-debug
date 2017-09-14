using System;
using System.IO;
using System.Reflection;

namespace NetCoreSample
{
    class Program
    {
        static void Main(string[] args)
        {
            var assemlies = Assembly.GetEntryAssembly().GetReferencedAssemblies();
            var assemblyName = "";
            foreach (var item in assemlies)
            {
                if (item.Name == "RefProj")
                    assemblyName = item.Name;

            }
            //var a = Assembly.Load(assemblyName);
            var path = new FileInfo(Assembly.GetExecutingAssembly().Location);
            var a = Assembly.LoadFile(Path.Combine($@"{path}\..\..\..\..\..\RefProj\bin\Debug\netstandard2.0", "RefProj.dll"));

            var t = a.GetType("RefProj.Class1");
            var i = Activator.CreateInstance(t);
            MethodInfo mi = t.GetMethod("get1");
            mi.Invoke(i, null);



            // Assuming the method returns a boolean and accepts a single string parameter
            //bool rc = Convert.ToBoolean(mi.Invoke(moduleInstance.Unwrap(), new object[] { "MyParamValue" }));

            //var resp = i.get1();

        }
    }
}
