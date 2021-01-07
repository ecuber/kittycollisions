using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ClickCasting : MonoBehaviour
{

    public TMP_Text selection;
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
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo) )
            {
                selection.text = "cp: " + hitInfo.collider.name;
            }
        }
    }

}
