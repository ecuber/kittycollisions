using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class CanvasMotion : MonoBehaviour
{

    private RectTransform rect;
    private Quaternion fixedRotation;
    // Start is called before the first frame update
    void Start()
    {
        rect = GetComponent<RectTransform>();
        fixedRotation = rect.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        rect.rotation = fixedRotation;
    }
}
