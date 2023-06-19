using System;
using System.Collections.Generic;
using System.Text;

public class Fork
{
    private bool istaken;
        
    public Fork() { Istaken = false; }

    public void put() {
        Istaken = false;
    }

    public bool Istaken {
        get { return istaken; }
        set { istaken = value; }
    }
}
