using System;
using System.IO;
using System.Text;

namespace FileReader
{
    public sealed class TextReader : IReader
    {
        
        public string Read(string path)
        {
            try
            {
                using (var sr = new StreamReader(this.GetLocation(path), Encoding.GetEncoding("koi8-u")))
                {
                   return sr.ReadToEnd();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private string GetLocation(string relativePath)
        {
            return Path.Combine(Directory.GetCurrentDirectory() + relativePath);
        }
    }
}
