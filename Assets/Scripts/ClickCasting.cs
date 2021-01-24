using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickCasting : MonoBehaviour
{

    public Text selection;
    private Piece currentPiece = null;
    private Arrow arrow = null;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hitInfo = new RaycastHit();
            List<string> pieces = new List<string>();
            pieces.Add("Pink1");
            pieces.Add("Pink2");
            pieces.Add("Pink3");
            pieces.Add("Purple1");
            pieces.Add("Purple2");
            pieces.Add("Purple3");

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            // True if ray collides with any collider.
            // If true, hitInfo has value typed RaycastHit.
            if (Physics.Raycast(ray, out hitInfo))
            {
                print(hitInfo.collider);
                Collider hit = hitInfo.collider;
                if (pieces.IndexOf(hit.name) != -1)
                {
                    selection.text = "Selected: " + hitInfo.collider.name;

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
