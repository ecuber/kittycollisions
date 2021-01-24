using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public static void set(Piece target, Vector3 direction)
    {
        target.SetDirection(direction);
    }
}
