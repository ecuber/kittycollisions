using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ClickCasting : MonoBehaviour
{

    public TMP_Text selection;
    private Piece currentPiece = null;
    // Start is called before the first frame update
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
            pieces.Add("Orange");
            pieces.Add("Purple");

            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo) && pieces.IndexOf(hitInfo.collider.name) != -1)
            {
                selection.text = "cp: " + hitInfo.collider.name;
                currentPiece = hitInfo.collider.gameObject.GetComponent<Piece>();

                if (!currentPiece.HasDirection())
                {
                    // spawn arrow
                }
                
            }
        }
    }

}
