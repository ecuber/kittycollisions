using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LaunchProps : MonoBehaviour
{
    public float magnitude = 3;
    public List<GameObject> PieceGroups;

    public void Launch()
    {
        List<Piece> pieces = new List<Piece>();

        int i = 0;
        foreach (GameObject group in PieceGroups)
        {
            foreach (Piece child in group.GetComponentsInChildren<Piece>())
            {
                if (!child.HasDirection())
                {
                    child.SetDirection(Vector3.zero);
                }

                pieces.Add(child);
                i++;
            }

            foreach (Piece piece in pieces)
            {
                print("launching piece: " + piece + " with direction " + piece.GetDirection());
                piece.LaunchPiece();
            }
        }
    }
}
