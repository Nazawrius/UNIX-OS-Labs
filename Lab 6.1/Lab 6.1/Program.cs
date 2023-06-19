using System;
using System.Threading;

class Program
{
    static Random rand = new Random();
    static int[,] A;
    static int[,] B;
    static int[,] C;
    static int m, n, k;

    static void Main(string[] args) {
        Console.WriteLine("Enter n:");
        n = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Enter m:");
        m = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Enter k:");
        k = Convert.ToInt32(Console.ReadLine());
        
        Thread[] threads = new Thread[n * k];
        Position pos;
        A = new int[n, m];
        B = new int[m, k];
        C = new int[n, k];
        Rand(A, n, m);
        Rand(B, m, k);

        Console.WriteLine("A:");
        Out(A, n, m);
        Console.WriteLine();
        Console.WriteLine("B:");
        Out(B, m, k);
        Console.WriteLine();

        int p = 0;
        for (int i = 0; i < n * k; i++) {
            threads[i] = new Thread(new ParameterizedThreadStart(Mult));
        }
        
        for (int i = 0; i < n; i++) {
            for (int j = 0; j < k; j++) {
                pos = new Position(i, j);
                threads[p].Start(pos);
                p++;
            }
        }

        Thread.Sleep(200);
        Console.WriteLine("C:");
        Out(C, n, k);
        Console.WriteLine();
    }

    public static void Mult(object p) {
        int res = 0;
        Position pos = (Position)p;
        int r = pos.N;
        int c = pos.K;
        for (int i = 0; i < m; i++) {
            res += A[r, i] * B[i, c];
        }
        C[r, c] = res;
        Console.WriteLine("[" + r + ", " + c + "] = " + res);
    }

    public static void Out(int[,] C, int a, int b) {
        for (int i = 0; i < a; i++) {
            for (int j = 0; j < b; j++) {
                Console.Write(C[i, j] + "  ");
            }
            Console.WriteLine();
        }
    }

    public static int[,] Rand(int[,] C, int a, int b) {
        for (int i = 0; i < a; i++) {
            for (int j = 0; j < b; j++) {
                C[i, j] = rand.Next(100);
            }
        }
        return C;
    }
}
