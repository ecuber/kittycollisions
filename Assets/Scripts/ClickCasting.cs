using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickCasting : MonoBehaviour
{

    public Text selection;
    private Piece currentPiece = null;
    private Arrow arrow = null;
    private bool isDragDrop;
    private Vector3 dragOrigin;
    private static Vector3 placeholder = new Vector3(0, 0, 1);
    private static float speed = 0.025f;

    void Start()
    {
        isDragDrop = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isDragDrop)
        {
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit hitInfo = new RaycastHit();
                List<string> pieces = new List<string>();
                pieces.Add("Pink");
                pieces.Add("Purple");

                List<string> arrows = new List<string>();
                arrows.Add("ArrowPink");
                arrows.Add("ArrowPurp");

                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                // True if ray collides with any collider.
                // If true, hitInfo has value typed RaycastHit.
                if (Physics.Raycast(ray, out hitInfo))
                {
                    Collider hit = hitInfo.collider;
                    if (pieces.IndexOf(hit.name) != -1)
                    {
                        selection.text = "cp: " + hitInfo.collider.name;
                        currentPiece = hit.gameObject.GetComponent<Piece>();

                        if (!currentPiece.HasDirection())
                        {
                            currentPiece.revealArrow();
                            arrow = currentPiece.GetComponentInChildren<Arrow>();
                            //print("set arrow" + arrow);
                            arrow.setWidth(9.97f * 88.218f, arrow.getAngle());
                        }
                    }

                    else if (arrows.IndexOf(hit.name) != -1)
                    {
                        isDragDrop = true;
                        Transform parent = hit.transform.parent.gameObject.transform.parent.gameObject.transform.parent;
                        //print("found arrow of: " + parent);
                        //Debug.LogFormat("mouse position: x: {0}, y: {1}, z: {2}", Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z);
                        arrow = hit.gameObject.GetComponent<Arrow>();
                        //print(arrow);

                    }

                }

            }
        }

        else if(Input.GetMouseButtonUp(0))
        {
            isDragDrop = false;
            dragOrigin = placeholder;
            arrow = null;
            currentPiece = null;
        }


        //dragging now
        else
        {
            if (dragOrigin == placeholder)
            {
                dragOrigin = Input.mousePosition;
            }

            float width = arrow.getWidth();

            Vector3 dMouse = (dragOrigin - Input.mousePosition);

            int sign = dragOrigin.magnitude < Input.mousePosition.magnitude ? 1 : -1;

            if (arrow.getAngle() != Mathf.Atan(dMouse.y / dMouse.x))
                arrow.transform.Rotate(0, 0, Mathf.Atan(dMouse.y / dMouse.x), Space.Self);
            else
                arrow.setWidth(sign * dMouse.magnitude * speed + width, Mathf.Atan(dMouse.y / dMouse.x));
            

        }
    }

    private int getQuadrant(Vector3 vec)
    {
        float x = vec.x;
        float y = vec.y;
        if (x > 0 && y > 0)
            return 1;
        else if (x < 0 && y > 0)
            return 2;
        else if (x < 0 && y < 0)
            return 3;
        else if (x > 0 && y < 0)
            return 4;
        return 0;
    }

}
