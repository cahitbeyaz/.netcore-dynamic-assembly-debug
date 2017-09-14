using System;
using System.IO;
using System.Reflection;

namespace NetCoreSample
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Assembly.LoadFile debug comment below region to debug this way
            //var assemlies = Assembly.GetEntryAssembly().GetReferencedAssemblies();
            //var assemblyName = "";
            //foreach (var item in assemlies)
            //{
            //    if (item.Name == "RefProj")
            //        assemblyName = item.Name;

            //}
            //var a = Assembly.Load(assemblyName);
            //var t = a.GetType("RefProj.Class1");
            //var i = (RefProj.Class1)Activator.CreateInstance(t);
            //i.get1();//press f11

            #endregion



            #region Assembly.LoadWay comment above and uncommet below

            var assemlies = Assembly.GetEntryAssembly().GetReferencedAssemblies();
            var assemblyName = "";
            foreach (var item in assemlies)
            {
                if (item.Name == "RefProj")
                    assemblyName = item.Name;

            }
            var path = new FileInfo(Assembly.GetExecutingAssembly().Location);
            var a = Assembly.LoadFile(Path.Combine($@"{path}\..\..\..\..\..\RefProj\bin\Debug\netstandard2.0", "RefProj.dll"));
            var t = a.GetType("RefProj.Class1");

            var i = Activator.CreateInstance(t);
            MethodInfo mi = t.GetMethod("get1");
            mi.Invoke(i, null);

            #endregion

        }
    }
}
