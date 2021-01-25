
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LaunchProps : MonoBehaviour
{
    public List<GameObject> PieceGroups;
    public Button launchButton;

    public void Launch()
    {
        launchButton.interactable = false;
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
                //print("launching piece: " + piece + " with direction " + piece.GetDirection());
                piece.showSliders(false);
                piece.LaunchPiece();
            }
        }
    }
}
