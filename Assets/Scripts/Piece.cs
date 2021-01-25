using UnityEngine;
using UnityEngine.UI;
using System;

public class Piece : MonoBehaviour
{

    // Constants for vector component methods
    public static int X = 0;
    public static int Y = 1;
    public static int Z = 2;

    // Fundamental constants
    public static float g = -9.81f;

    // Piece components
    public Rigidbody rb;
    public float massMultiplier = 2;

    // Stored vector planned course
    private Vector3 direction = Vector3.right;

    private bool hasVec;
    public Arrow arrow;
    GameObject sliders;

    // KE Reading
    public Color color;
    public Slider KE;

    Vector3 Vel; // Velocity vector
    float mass;
    float K; // Kinetic Energy
    float v; // Velocity magnitude

    void Start()
    {
        hasVec = false;
        rb = GetComponent<Rigidbody>();
        mass = rb.mass * massMultiplier;
        sliders = transform.Find("Sliders").Find("Settings").gameObject;
        showSliders(false);
    }

    void FixedUpdate()
    {
        if (hasVec)
        {
            arrow.setAngle(arrow.getAngle() - transform.eulerAngles.z % 360 / 360);
        }
        
    }

    public bool revealArrow()
    {
        arrow.setWidth(6.5f);
        return true;
    }

    public void showSliders(bool show)
    {
        sliders.SetActive(show);
    }

    Vector3 FreezeMotion()
    {
        Destroy(rb);
        gameObject.SetActive(false);
        return new Vector3(0, 0, 0);
    }

    void Update()
    {
        if (rb != null)
        {
            Vel = rb.position.y < -3.5 ? FreezeMotion() : rb.velocity;
            v = Vel.magnitude;
        }
        K = 0.5f * mass * (float) (Math.Pow(v, 2));
        KE.value = (float) Math.Round(K + 2, 2);
    }

    public void LaunchPiece()
    {
        rb.AddForce(arrow.getWidth() / 6.25f * direction, ForceMode.Impulse);
    }


    public float GetMass()
    {
        return mass;
    }

    public Vector3 GetDirection()
    {
        hasVec = true;
        return direction;
    }

    public void SetDirection(Vector3 newDir)
    {
        hasVec = hasVec && newDir != Vector3.zero ? hasVec : revealArrow();
        direction = newDir;
    }

    public bool HasDirection()
    {
        return hasVec;
    }
}
