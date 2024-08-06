namespace _2048WinFormsApp
{
    internal class FileProvider
    {
        public static void Replace(string fileName, string value)
        {
            using (StreamWriter sw = new StreamWriter(fileName, false))
            {
                sw.WriteLine(value);
            }
        }
        public static string GetValue(string filename)
        {
            using (StreamReader sr = new StreamReader(filename))
            {
                var value = sr.ReadToEnd();
                return value;
            }
        }

        public static bool Exists(string fileName)
        {
            return File.Exists(fileName);
        }
    }
}
