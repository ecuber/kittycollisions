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
    float angle = 0;
    // Start is called before the first frame update
    void Start()
    {
        toggle(false);
        parent = this.transform.parent.transform.parent.GetComponentInParent<Piece>();
        //print("parent: " + parent);
    }

    public void setWidth(float len, float angle)
    {
        this.angle = angle;
        width = len / 88.218f;

        if (width > 25)
            width = 25f;
        Vector2 current = spriteRenderer.size;
        spriteRenderer.size = new Vector2(width, current.y);
        updateDirection(width, angle);

    }

    public float getWidth()
    {
        return width * 88.218f;
    }

    public float getAngle()
    {
        return angle;
    }

    public void toggle(bool choice)
    {
        this.gameObject.SetActive(choice);
    }

    public bool isActive()
    {
        return this.gameObject.activeSelf;
    }

    public void updateDirection(float len, float angle)
    {
        print("angle: " + angle);
        BoxCollider old = boxCollider;
        Debug.LogFormat("x: {0}, y: {1}", old.center.x, old.center.z);
        boxCollider.size = new Vector3(len, old.size.y, old.size.z);

        int signX = old.size.x > len ? -1 : 1;
        int signY = old.size.z > len ? -1 : 1;

        float centerDx = signX * len / 2 * Mathf.Cos(angle);
        float centerDy = signY * len / 2 * Mathf.Sin(angle);

        Vector3 parentPos = parent.transform.position;

        boxCollider.center = new Vector3(parentPos.x + centerDx, old.center.y, parentPos.z + centerDy);

        float dx = len * Mathf.Cos(angle);
        float dy = len * Mathf.Sin(angle);

        Vector3 direction = new Vector3(dx / 25f, 0, dy / 25f);
        parent.SetDirection(len / 8f * direction);
    }

    private float UnwrapAngle(float angle)
    {
        if (angle >= 0)
            return angle;

        angle = -angle % 360;

        return 360 - angle;
    }
}
