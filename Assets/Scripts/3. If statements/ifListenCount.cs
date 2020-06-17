using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ifListenCount : ifListener
{
    public int count;

    

    public override void trueStatement()
    {
        count++;
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
