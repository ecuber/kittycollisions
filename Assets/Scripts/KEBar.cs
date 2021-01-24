using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteAlways]
public class KEBar : MonoBehaviour
{

    public Piece target;
    public RectTransform canvasRect;
    public Image fill;

    // Start is called before the first frame update
    void Start()
    {
        Color p = target.color;
        fill.color = new Color(p.r, p.g, p.b);
    }

    // Update is called once per frame
    void Update()
    {
        // Offset position above object bbox (in world space)
        float offsetPosY = target.transform.position.z + 0.65f;

        // Final position of marker above GO in world space
        Vector3 offsetPos = new Vector3(target.transform.position.x, target.transform.position.y, offsetPosY);

        // Calculate *screen* position (note, not a canvas/recttransform position)
        Vector2 canvasPos;
        Vector2 screenPoint = Camera.main.WorldToScreenPoint(offsetPos);

        // Convert screen position to Canvas / RectTransform space <- leave camera null if Screen Space Overlay
        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRect, screenPoint, null, out canvasPos);

        // Set
        transform.localPosition = canvasPos;

    }
}
