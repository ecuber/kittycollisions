using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        toggle(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void toggle(bool choice)
    {
        this.gameObject.SetActive(choice);
    }

    public bool isActive()
    {
        return this.gameObject.activeSelf;
    }
}
