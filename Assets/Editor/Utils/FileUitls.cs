using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;


namespace ZEditor
{
    public class FileUitls
    {
        public static string Import(string path)
        {
            FileStream stream = new FileStream(path, FileMode.Open);
            int len = (int)stream.Length;
            byte[] bytes = new byte[len];
            stream.Read(bytes, 0, len);
            string data = System.Text.Encoding.UTF8.GetString(bytes);
            stream.Close();
            return data;
        }

        public static void Export(string data, string path)
        {
            FileStream stream = new FileStream(path, FileMode.Create);
            stream.Write(System.Text.Encoding.Default.GetBytes(data), 0, data.Length);
            stream.Flush();
            stream.Close();
        }
    }
}

