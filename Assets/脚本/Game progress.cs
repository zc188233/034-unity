using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gameprogress : MonoBehaviour

{
    public static int i = 1;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Gameprogress.i==4)
        {
            Debug.Log("游戏结束");
            Gameprogress.i=5;
        }
    }
}
