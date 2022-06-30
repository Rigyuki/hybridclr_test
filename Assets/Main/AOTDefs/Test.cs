using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


public class TestAotRef
{
    public void CallRef(ref int a)
    {
        a = 5;
    }

    public void CallIn(in int b)
    {

    }

    public void CallOut(out int b)
    {
        b = 15;
    }
}

public class MainT
{
    public virtual void Log()
    {

    }
}

