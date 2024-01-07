using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Chess.Classes
{
    public class FileManager
    {
        private string _file;
        public FileManager(string path)
        {
            _file = path;
        }


        public void ReadFile()
        {
            string line;
            try
            {
                //Pass the file path and file name to the StreamReader constructor
                StreamReader sr = new StreamReader(@"../../../Logs/" + _file);
                //Read the first line of text
                line = sr.ReadLine();
                //Continue to read until you reach end of file
                while (line != null)
                {
                    //write the line to console window
                    
                }
                //close the file
                sr.Close();
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                Console.WriteLine("Executing finally block.");
            }
        }

        public void WriteFile(Node node)
        {
            try
            {
                //Pass the filepath and filename to the StreamWriter Constructor
                /*  StreamWriter sw = new StreamWriter( @"Logs/" + _file);

                  sw.WriteLine(Setups.ConvertToString(node));*/

                // Adding the text to the madrid.txt file
                File.AppendAllText(@"../../../Logs/" + _file,Setups.ConvertToString(node) + Environment.NewLine);

            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
        }
    }
}
