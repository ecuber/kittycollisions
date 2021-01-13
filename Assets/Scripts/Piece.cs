    using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
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
    public TMP_Text PLabel;
    public float massMultiplier = 2;

    // Stored vector planned course
    [SerializeField]
    private float dx = 1;
    [SerializeField]
    private float dy = 0;
    [SerializeField]
    private float dz = 0;
    private Vector3 direction;

    // Do we have a user-set direction?
    private bool hasVec = false;
    public Arrow arrow;

    Vector3 p; // Momentum vector
    Vector3 Vel; // Velocity vector
    float mass;
    float K; // Kinetic Energy
    float v; // Velocity magnitude
    float vx, vy, vz; // XYZ components of Vel

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        mass = rb.mass * massMultiplier;
        direction = new Vector3(dx, dy, dz);
    }

    public void revealArrow()
    {
        this.arrow.toggle(true);
    }

    public void hideArrow()
    {
        this.arrow.toggle(false);
    }

    Vector3 FreezeMotion()
    {
        Destroy(rb);
        return new Vector3(0, 0, 0);
    }

    void Update()
    {
        if (rb != null)
        {
            Vel = rb.position.y < -3.5 ? FreezeMotion() : rb.velocity;
            v = Vel.magnitude;
            vx = Vel.x;
            vy = Vel.y;
            vz = Vel.z;
        }
        K = 0.5f * mass * (float)(Math.Pow(v, 2));
        p = new Vector3(vx, vy, vz) * mass;
        PLabel.SetText(Math.Round(p.magnitude, 2) + " kg*m/s");
    }

    public void LaunchPiece(float magnitude)
    {
        rb.AddForce(direction * magnitude, ForceMode.Impulse);
    }


    public float GetMass()
    {
        return mass;
    }

    public Vector3 GetDirection()
    {
        return direction;
    }

    public Vector3 SetDirection(Vector3 NewDir)
    {
        hasVec = hasVec ? hasVec : !hasVec;

        Vector3 old = direction;
        direction = NewDir;
        dx = direction.x;
        dy = direction.y;
        dz = direction.z;
        return direction;
    }

    public bool HasDirection()
    {
        return hasVec;
    }
}
