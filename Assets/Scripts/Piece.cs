    using System.Collections;
using System.Collections.Generic;
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
    public Slider KE;
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
    private bool hasVec;
    public Arrow arrow;

    Vector3 p; // Momentum vector
    Vector3 Vel; // Velocity vector
    float mass;
    float K; // Kinetic Energy
    float v; // Velocity magnitude
    float vx, vy, vz; // XYZ components of Vel

    void Start()
    {
        hasVec = false;
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
        this.gameObject.SetActive(false);
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
        K = 0.5f * mass * (float) (Math.Pow(v, 2));
        KE.value = (float) Math.Round(K, 2);
    }

    public void LaunchPiece()
    {
        print("attempting launch. direction vector: " + direction);
        rb.AddForce(direction, ForceMode.Impulse);
    }


    public float GetMass()
    {
        return mass;
    }

    public Vector3 GetDirection()
    {
        return direction;
    }

    public Vector3 SetDirection(Vector3 newDir)
    {
        hasVec = true;

        //Vector3 old = direction;
        direction = new Vector3(newDir.x, newDir.y, newDir.z);
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
