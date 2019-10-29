using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;

namespace FourConnectCore
{
    public class JsonDatabase<T>
    {
        public JsonDatabase(string fileName)
        {
            using StreamWriter writer = System.IO.File.AppendText("/home/pearu/Desktop/"+typeof(T).ToString()+fileName+".db");
            writer.WriteLine($"{typeof(T)} {fileName} database lies here!");
        }
    }
}