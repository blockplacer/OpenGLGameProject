using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brickon
{
    public static class Files
    {
        public static string BinaryString(string stringdata)
        {
            //byte[] stringbinaryconv = Encoding.Unicode.GetBytes(stringdata);

            string rt = "";
            foreach (char ch in stringdata)
            {
                rt += Convert.ToString(ch, 2).PadLeft(8, '0');

            }

            return rt;//BitConverter.ToString(stringbinaryconv).Replace("-","");
        }
        
        public static void Binary(string data,string file)
        {
            using (BinaryWriter binary = new BinaryWriter(File.Open(file, FileMode.Create)))
            {

                List<float> binry=new List<float>();

                  char[] binarystring = data.ToArray();

                //binary.Write("Size^" + data.Length);
                binary.Write("[VERTEX SHADER]");
               
                for (int x = 0; x < binarystring.Length; x++)
                  {
                      binry.Add(binarystring[x]);

                   // Console.WriteLine(binarystring[x] + " " + binarystring[x]);


                }
                  for (int x = 0; x < binry.Count; x++)
                  {
                      binary.Write(Convert.ToByte(binry[x]));
                   
                }/**/
                //long vl = 8888888888;


                //binary.Write(hex);
                //binary.Write(888811118181);
                
            }
        }

        public static string FileToString(string file)
        {
            string rturn = "string";

            List<Byte> buffer = new List<Byte>();
            string bufferstring;
            using (BinaryReader binaryReader = new BinaryReader(File.OpenRead(file)))
            {
               
                for (int x = 0; x < binaryReader.BaseStream.Length; x++)
                {
                    buffer.Add(binaryReader.ReadByte());
                    
                 }
                rturn = Encoding.ASCII.GetString(buffer.ToArray());

            }
            string chr = System.Text.RegularExpressions.Regex.Replace(rturn, "[^01]", "");
            byte[] bytes = new byte[(chr.Length / 8) - 1 + 1];
            for (int x = 0; x < bytes.Length; x++)
            {
                bytes[x] = Convert.ToByte(chr.Substring(x * 8, 8), 2);
            }
            bufferstring = (string)(ASCIIEncoding.ASCII.GetString(bytes));
            rturn = bufferstring;
           /* List<byte> bytes = new List<byte>();
            for (int x = 0; x < buffer.Length; x++)
            {
                bytes.Add(Convert.ToByte(buffer.Substring(x, 8)));
            }
            rturn = Encoding.ASCII.GetString(bytes.ToArray());*/
            return rturn;
        }
    }
}
