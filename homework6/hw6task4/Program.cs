using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//4. ** Считайте файл различными способами.Смотрите “Пример записи файла различными
//способами”. Создайте методы, которые возвращают массив byte (FileStream, BufferedStream),
//строку для StreamReader и массив int для BinaryReader.
//Рощупкин
namespace hw6task4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("FileStream. Milliseconds:{0}", 
                FileStreamSample("Example.txt", out byte[] bytesFS));
            foreach (byte b in bytesFS)
                Console.Write(b + " ");
            Console.WriteLine("\nBinaryStream. Milliseconds:{0}",
                BinaryStreamSample("Example.txt", out int[] bytesBinS));
            foreach (int i in bytesBinS)
                Console.Write(i + " ");
            Console.WriteLine("\nStreamWriter. Milliseconds:{0}", 
                StreamReaderSample("Example.txt", out string lines));
            Console.WriteLine(lines);
            Console.WriteLine("\nBufferedStream. Milliseconds:{0}",
                BufferedStreamSample("Example.txt", out byte[] bytesBufS));
            foreach (byte b in bytesBufS)
                Console.Write(b + " ");
            Console.ReadKey();
        }

        static long FileStreamSample(string filename, out byte[] bytesFS)
        {
            List<byte> bytes = new List<byte>();
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            FileStream fs = new FileStream(filename, FileMode.Open,FileAccess.Read);
            while (fs.ReadByte() != -1)
                bytes.Add((byte)fs.ReadByte());
            fs.Close();
            stopwatch.Stop();
            bytesFS = bytes.ToArray();
            return stopwatch.ElapsedMilliseconds;
        }

        static long BinaryStreamSample(string filename, out int[] bytesBinS)
        {
            List<int> bytes = new List<int>();
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            FileStream fs = new FileStream(filename, FileMode.Open,
            FileAccess.Read);
            BinaryReader bw = new BinaryReader(fs);
            for(int i = 0; i < fs.Length/4;i++)           
                bytes.Add(bw.ReadInt32());
            fs.Close();
            stopwatch.Stop();
            bytesBinS = bytes.ToArray();
            return stopwatch.ElapsedMilliseconds;
        }
        static long StreamReaderSample(string filename, out string lines)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            lines = String.Empty;
            FileStream fs = new FileStream(filename, FileMode.Open,
            FileAccess.Read);
            StreamReader sw = new StreamReader(fs);
            for (int i = 0; i < fs.Length; i++)
                lines += sw.Read().ToString();
            fs.Close();
            stopwatch.Stop();
            return stopwatch.ElapsedMilliseconds;
        }
        static long BufferedStreamSample(string filename,out byte[] bytesBufS)
        {
            List<byte> bytes = new List<byte>();
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            FileStream fs = new FileStream(filename, FileMode.Open,
            FileAccess.Read);
            BufferedStream bs = new BufferedStream(fs);
            for (int i = 0; i < fs.Length; i++)
                bytes.Add((byte)bs.ReadByte());
            fs.Close();
            stopwatch.Stop();
            bytesBufS = bytes.ToArray();
            return stopwatch.ElapsedMilliseconds;
        }
    }
}
