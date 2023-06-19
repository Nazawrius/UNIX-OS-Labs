using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

public class Philosopher
{
    public Fork left = new Fork();
    public Fork right = new Fork();
    public string Name;

    public Philosopher(string name, Fork leftfork, Fork rightfork) {
        Name = name;
        left = leftfork;
        right = rightfork;
    }

    public void put_left() {
        left.put();
    }

    public void put_right() {
        right.put();
    }

    public void eat() {
        Console.WriteLine("{0} eating!", Name);
    }

    public void think() {
        Console.WriteLine("{0} thinking!", Name);
    }
}

