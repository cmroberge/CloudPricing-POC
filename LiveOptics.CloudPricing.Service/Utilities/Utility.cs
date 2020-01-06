using System.IO;

namespace LiveOptics.CloudPricing.Service
{
    public static class Utility
    {
        private const string dumpDirectory = "dump";

        public static void DumpToFile(string file, string content)
        {
            System.IO.Directory.CreateDirectory(dumpDirectory);
            using (StreamWriter writer = new StreamWriter($"{dumpDirectory}\\{file}.json", false))
            {
                writer.Write(content);
            }
        }

        public static void ClearDumpFolder()
        {
            DirectoryInfo dir = new DirectoryInfo(dumpDirectory);

            foreach (FileInfo fi in dir.GetFiles())
            {
                fi.Delete();
            }
        }
    }
}