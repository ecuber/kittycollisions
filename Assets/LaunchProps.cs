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

        int i = 0;
        foreach (Piece child in PieceGroup.GetComponentsInChildren<Piece>())
        {
            bool positive = random.NextDouble() > 0.5;
            float dy = (float) Math.Round(random.NextDouble(), 3) * magnitude / 2.5f;
            child.SetDirection(i % 2 == 0 ? new Vector3(-1, 0, positive ? dy : -dy) : Vector3.right);
            i++;
            child.LaunchPiece(magnitude);
        }
            
            
        //Piece.SetDirection(new Vector3(-1, 0, 0));
        //Piece.LaunchPiece(magnitude);
    }
}
