using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LaunchProps : MonoBehaviour
{
    public float magnitude = 3;
    public GameObject PieceGroup;

    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Launch()
    {
        System.Random random = new System.Random();
        List<(Piece, bool)> pieces = new List<(Piece, bool)>();

        int i = 0;
        foreach (Piece child in PieceGroup.GetComponentsInChildren<Piece>())
        {
            bool positive = random.NextDouble() > 0.5;
            float dy = (float) Math.Round(random.NextDouble(), 3) * magnitude / 2.5f;
            bool hasDir = child.HasDirection();
            Vector3 direction = hasDir ? child.GetDirection() : Vector3.zero;

            pieces.Add((child, hasDir));
            i++;
        }

        i = 0;
        int haveDir = 0;

        foreach((Piece, bool) t in pieces)
        {
            if (t.Item2)
                haveDir++;
            i++;
        }
        
    }
}
