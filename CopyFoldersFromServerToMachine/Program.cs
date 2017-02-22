using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CopyFoldersFromServerToMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            string SystemReflectionAssemblyGetExecutingAssemblyLocation = System.Reflection.Assembly.GetExecutingAssembly().Location;
            Console.WriteLine("SystemReflectionAssemblyGetExecutingAssemblyLocation: \n" + SystemReflectionAssemblyGetExecutingAssemblyLocation);
            Console.WriteLine();

            string SystemReflectionAssemblyGetExecutingAssemblyCodeBase = System.Reflection.Assembly.GetExecutingAssembly().CodeBase;
            Console.WriteLine("SystemReflectionAssemblyGetExecutingAssemblyCodeBase: \n" + SystemReflectionAssemblyGetExecutingAssemblyCodeBase);
            Console.WriteLine();

            string PathGetDirectoryNameSystemReflectionAssemblyGetExecutingAssemblyLocation = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            Console.WriteLine("PathGetDirectoryNameSystemReflectionAssemblyGetExecutingAssemblyLocation: \n" + PathGetDirectoryNameSystemReflectionAssemblyGetExecutingAssemblyLocation);
            Console.WriteLine();

            string AppdomainCurrentDomainBaseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            Console.WriteLine("AppdomainCurrentDomainBaseDirectory: \n" + AppdomainCurrentDomainBaseDirectory);
            Console.WriteLine();

            string DirectoryGetCurrentDirectory = Directory.GetCurrentDirectory();
            Console.WriteLine("DirectoryGetCurrentDirectory: \n" + DirectoryGetCurrentDirectory);
            Console.WriteLine();

            string EnviromentCurrentDirectory = Environment.CurrentDirectory;
            Console.WriteLine("DirectoryGetCurrentDirectory: \n" + EnviromentCurrentDirectory);
            Console.WriteLine();

            string PathGetDirectoryNameSystemReflectionAssemblyGetExecutingAssemblyGetNameCodeBase = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);
            Console.WriteLine("PathGetDirectoryNameSystemReflectionAssemblyGetExecutingAssemblyGetNameCodeBase: \n" + PathGetDirectoryNameSystemReflectionAssemblyGetExecutingAssemblyGetNameCodeBase);
            Console.WriteLine();


            Console.ReadLine();
            //string fileName = "TestDataToCopy.txt";
            //string sourceFolder = @"\\lp7aps15.calcomp.co.th\public\Milinda\CopyDatatest";
            //string sourceLocation = AppDomain.CurrentDomain.BaseDirectory;
            //string sourcePath = sourceLocation + sourceFolder;
            //string targetPath = @"C:\TargetFolder";

            //DirectoryCopy(sourcePath, targetPath, true);
        }

        private static void DirectoryCopy(string sourceDirName, string destDirName, bool copySubDirs)
        {
            // Get the subdirectories for the specified directory.
            DirectoryInfo dir = new DirectoryInfo(sourceDirName);

            if (!dir.Exists)
            {
                throw new DirectoryNotFoundException(
                    "Source directory does not exist or could not be found: "
                    + sourceDirName);
            }

            DirectoryInfo[] dirs = dir.GetDirectories();
            // If the destination directory doesn't exist, create it.
            if (!Directory.Exists(destDirName))
            {
                Directory.CreateDirectory(destDirName);
            }

            // Get the files in the directory and copy them to the new location.
            FileInfo[] files = dir.GetFiles();
            foreach (FileInfo file in files)
            {
                string temppath = Path.Combine(destDirName, file.Name);
                file.CopyTo(temppath, true);
            }

            // If copying subdirectories, copy them and their contents to new location.
            if (copySubDirs)
            {
                foreach (DirectoryInfo subdir in dirs)
                {
                    string temppath = Path.Combine(destDirName, subdir.Name);
                    DirectoryCopy(subdir.FullName, temppath, copySubDirs);
                }
            }
        }
    }
}
