using System;
using System.IO;

namespace Module_8_HW_2
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.Write("Enter path to directory ");
            long Size = 0;
            bool Existence = false;
            string PathToDir = Console.ReadLine();
            Program.ShowDirVolume(PathToDir, ref Size, ref Existence);

            if (Existence)
            {
                Console.WriteLine($"Size of directory with included files: {Size} bytes");
            }

            Console.ReadKey();
        }


        public static void ShowDirVolume(string path, ref long size, ref bool Existence)
        {
            DirectoryInfo dr = new DirectoryInfo(path);
            try
            {
                if (dr.Exists)
                {

                    FileInfo[] files = dr.GetFiles();
                    foreach (FileInfo file in files)
                    {
                        FileInfo f = new FileInfo(file.FullName);
                        size += f.Length;
                    }

                    DirectoryInfo[] direc = dr.GetDirectories();
                    foreach (DirectoryInfo dir in direc)
                    {

                        Program.ShowDirVolume(dir.FullName, ref size, ref Existence);
                    }

                    Existence = true;
                }
                else
                {
                    Console.WriteLine("User, this directory does not exist");
                    Existence =  false;
                }
            }
            catch(Exception message)
            {
                Console.WriteLine(message);
            }
        }



    }
}
