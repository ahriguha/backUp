using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using Telegram.Bot;
using Telegram.Bot.Args;

using System.Diagnostics;
using Telegram.Bot.Types;
using System.Security.Cryptography;
using System.Threading;
using System.Runtime.InteropServices;
using Telegram.Bot.Requests;


namespace LeetCodeTest
{

    class Program
    {



        static void Main(string[] args)
        {
            Stopwatch s1 = new Stopwatch(), s2 = new Stopwatch();
            Random rand = new Random();
            int[] arr = new int[10000];
            for(int i = 0; i < arr.Length; i++)
                arr[i] = i;
            s1.Start();
            Console.WriteLine(MultiplyByLength(arr));
            s1.Stop();
            Console.WriteLine(s1.ElapsedMilliseconds);
           
            Console.WriteLine();
            s2.Start();
            Console.WriteLine(MultiplyByLength1(arr));
            s2.Stop();
            Console.WriteLine(s2.ElapsedMilliseconds);
            Console.ReadLine();
        }

        public static int[] MultiplyByLength(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] += arr.Length;
            }
            return arr;
        }
        public static int[] MultiplyByLength1(int[] arr)
        {
            //var multiplier = arr.Length;
            return arr.Select(x => x + arr.Length).ToArray();
        }
    }
    
}





//Random rand = new Random();
//            int[] arr = new int[10];
//            for(int i = 0; i<100000; i++)
//            {
//                arr[rand.Next(0, 10)]++;
//            }
//            foreach (int a in arr)
//                Console.WriteLine(a);
//            Console.ReadLine();


/*using System;
using System.IO;
using System.Threading.Tasks;
using System.Linq;


namespace ConsoleApplication1
{



    class Program
    { 
        static void Main()
        {
            string word;
            string line;
            bool isexist = false;
            Random random = new Random();
            word = Console.ReadLine();
            int n = word.Length;
            int nfact = 1;
            for(int i = 1; i < n + 1; i++) { nfact *= i; }
            string writePath = @"C:\Users\Root\source\repos\cSharptest\cSharptest\bin\Debug\text.txt";
            char[] slovo = word.ToCharArray();
            StreamWriter sww = new StreamWriter(writePath, true, System.Text.Encoding.Default);
            sww.WriteLine(slovo);
            sww.Close();
            for (int g = 0; g < nfact; g++)
            {
                StreamReader sr = new StreamReader(writePath, System.Text.Encoding.Default);
            MARK:
                isexist = false;
                for (int i = slovo.Length - 1; i >= 0; i--)
                {
                    int j = random.Next(i + 1);
                    var temp = slovo[j];
                    slovo[j] = slovo[i];
                    slovo[i] = temp;
                }
                 while ((line = sr.ReadLine()) != null)
                {
                    if (slovo.SequenceEqual(line)) { isexist = true; }
                }
                if (isexist) { goto MARK; }
                else { 
                    sr.Close();
                    StreamWriter sw = new StreamWriter(writePath, true, System.Text.Encoding.Default); 
                    sw.WriteLine(slovo);
                    sw.Close();
                    Console.WriteLine($"Writed {g} combination;");
                }
                

            }
         //   Console.WriteLine(nfact);
            Console.ReadLine();
        }
    
    
    }
}

/* class Program
{
static void Main() {
int[,] chbrd = new int[8, 8];
int[,] rookspos = new int[2, 8];
Random rand = new Random();
//rookspos[0,0] = rand.Next(0,7);
// rookspos[1,0] = rand.Next(0, 7);
int rook = 1;
//chbrd[rookspos[0,0], rookspos[1,0]] = rook;
int posrows;
int poscols;
bool checkrows, checkcols, writed;
for (int a=0; a<8; a++)
{
 writed = true;


 while(writed)
 { 
     posrows = rand.Next(8);
     poscols = rand.Next(8);
     checkrows = false;
     checkcols = false;
     for (int g = 0; g < 8; g++)
     {
         if (chbrd[posrows, g] == 1) { checkcols = true; break; }
     }
     for(int h = 0; h<8; h++)
     {
         if (chbrd[h, poscols] == 1) { checkrows = true; break; }
     }
     if (!checkrows && !checkcols)
     { chbrd[posrows, poscols] = rook; rookspos[0, a] = posrows; rookspos[1, a] = poscols; writed = false; }
     else { continue; }

 }


}
for (int i=0;i<8;i++)
{
 for(int j=0;j<8;j++)
 {
     Console.Write(chbrd[i, j]+" " );
 }
 Console.WriteLine();
}
Console.WriteLine("\n");
for (int i = 0; i < 2; i++)
{
 for (int j = 0; j < 8; j++)
 {
     Console.Write((rookspos[i,j]+1) + " ");
 }
 Console.WriteLine();
}
Console.ReadLine();
}

}
}*/
