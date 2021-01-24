using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public BoxCollider boxCollider;
    private Piece parent;
    public float width;
    // angle is stored as a percentage of 360 degrees because it works
    float angle = 0;

    void Start()
    {
        parent = transform.parent.transform.parent.gameObject.GetComponentInParent<Piece>();
    }

    public void setWidth(float len)
    {
        width = len;
        spriteRenderer.size = new Vector2(width, spriteRenderer.size.y);
        boxCollider.center = width / 2 * new Vector3(Mathf.Cos(angle), 0, Mathf.Sin(angle));
        boxCollider.size = new Vector2(width, boxCollider.size.y);
        updateDirection(parent.GetDirection());
    }

    public void setAngle(float angle)
    {
        float delta = angle - this.angle;
        transform.Rotate(Vector3.forward * delta * 360);
        this.angle = angle;
        float inRad = angle * 360 * Mathf.PI / 180;
        print("angle: " + inRad + "rad");
        updateDirection(new Vector3(Mathf.Cos(inRad), 0, Mathf.Sin(inRad)));
    }

    public float getWidth()
    {
        return width;
    }

    public float getAngle()
    {
        return angle;
    }

    public void toggle(bool choice)
    {
        gameObject.SetActive(choice);
    }

    public bool isActive()
    {
        return gameObject.activeSelf;
    }

    public void updateDirection(Vector3 direction)
    {
        print("direction: " + direction);
        parent.SetDirection(direction);
    }

}
