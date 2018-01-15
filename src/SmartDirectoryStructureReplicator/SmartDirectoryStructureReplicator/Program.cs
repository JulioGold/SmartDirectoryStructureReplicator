using System.IO;
using System.Linq;

namespace SmartDirectoryStructureReplicator
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = @"C:\Projetos";

            DirectoryInfo directoryInfo = new DirectoryInfo(path);

            // Get all directories, except that contains those specific words.
            DirectoryInfo[] directoryList = directoryInfo.GetDirectories("*", SearchOption.AllDirectories).Where(w =>
                    !w.FullName.Contains("node_modules") &&
                    !w.FullName.Contains("NugetPackages")
                ).ToArray();

            // Path where the directories will be replicated
            string rootPath = @"C:\Projetos\temp\Backup";

            foreach (var item in directoryList)
            {
                Directory.CreateDirectory(item.FullName.Replace(path, rootPath));
            }

            //Console.ReadKey();
        }
    }
}
