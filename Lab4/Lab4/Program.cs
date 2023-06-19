using System;
using System.Threading;

public class Program
{
    static object locker = new object();

    static Fork fork1 = new Fork();
    static Fork fork2 = new Fork();
    static Fork fork3 = new Fork();
    static Fork fork4 = new Fork();
    static Fork fork5 = new Fork();

    static void Main(string[] args) {
        Philosopher Aristotel = new Philosopher("Aristotel", fork1, fork5);
        Philosopher Socrat = new Philosopher("Socrat", fork2, fork1);
        Philosopher Platon = new Philosopher("Platon", fork3, fork2);
        Philosopher Confucius = new Philosopher("Confucius", fork4, fork3);
        Philosopher Diogen = new Philosopher("Diogen", fork5, fork4);

        Thread thread1 = new Thread(new ParameterizedThreadStart(Phil));
        Thread thread2 = new Thread(new ParameterizedThreadStart(Phil));
        Thread thread3 = new Thread(new ParameterizedThreadStart(Phil));
        Thread thread4 = new Thread(new ParameterizedThreadStart(Phil));
        Thread thread5 = new Thread(new ParameterizedThreadStart(Phil));

        thread1.Start(Aristotel);
        thread2.Start(Socrat);
        thread3.Start(Platon);
        thread4.Start(Confucius);
        thread5.Start(Diogen);
    }

    static public void Phil(object philosoph) {
        Philosopher phil = (Philosopher)philosoph;
        Random rand = new Random();
        while (!Console.KeyAvailable) {
            if (!phil.right.Istaken) {
                lock (locker)
                    phil.right.Istaken = true;

                if (!phil.left.Istaken) {
                    lock (locker)
                        phil.left.Istaken = true;

                    phil.eat();

                    Thread.Sleep(rand.Next(1000, 5000));

                    phil.put_right();
                    phil.put_left();

                    phil.think();

                    Thread.Sleep(rand.Next(10000, 15000));
                } else {
                    phil.put_right();
                    phil.think();

                    Thread.Sleep(rand.Next(7000, 10000));
                }
            }

        }
        Environment.Exit(0);
    }
}
