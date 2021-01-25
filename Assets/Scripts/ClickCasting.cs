using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

class NameList
{
    public List<string> names = new List<string>();
}

public class ClickCasting : MonoBehaviour
{

    public Text selection;
    private Piece currentPiece = null;
    private Arrow arrow = null;
    private System.Random random = new System.Random();
    private string[] pieces;
    private (string id, string name)[] pairs;
    void Start()
    {
        pieces = new string[] { "Pink1", "Pink2", "Pink3",
                "Purple1", "Purple2", "Purple3" };


        List<string> nameList = new NameList
        {
            names = { "Swirly", "Bump", "Snoozy",
                "Prissy", "Swirly", "Frisky", "Julio", "Julius", "George",
                "Peewee", "9lives", "BigDawg", "Leo", "Toe", "Claw", "Taco",
                "Muffin", "Q-Tip", "Methane"  }
        }.names;

        pairs = new (string, string)[pieces.Length];

        for (var i = 0; i < pairs.Length; i++)
        {
            string name = nameList[random.Next(0, nameList.Count - 1)];
            nameList.Remove(name);
            pairs[i] = (pieces[i], name);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hitInfo = new RaycastHit();

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            // True if ray collides with any collider.
            // If true, hitInfo is initialized with a value
            if (Physics.Raycast(ray, out hitInfo))
            {
                Collider hit = hitInfo.collider;
                if (System.Array.IndexOf(pieces, hit.name) != -1)
                {
                    string name = hit.name;
                    foreach ((string id, string name) pair in pairs)
                        if (pair.id.Equals(hit.name))
                            name = pair.name;

                    selection.text = "Selected: " + name;

                    if (currentPiece)
                        currentPiece.showSliders(false);

                    currentPiece = hit.gameObject.GetComponent<Piece>();
                    currentPiece.showSliders(true);

                    if (!currentPiece.HasDirection())
                    {
                        arrow = currentPiece.GetComponentInChildren<Arrow>();
                        currentPiece.revealArrow();
                    }
                }

            }

        }
    }
      

}
