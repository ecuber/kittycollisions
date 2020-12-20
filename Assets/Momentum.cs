using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Momentum
{
    public float magnitude;
    public Vector3 direction;

    /// <summary>
    /// Creates a new Momentum object with magnitude m and direction dir.
    /// </summary>
    /// <param name="m">Magnitude of the momentum.</param>
    /// <param name="dir">Direction of the momentum.</param>
    public Momentum(float m, Vector3 dir)
    {
        magnitude = m;
        direction = dir;
    }

    /// <summary>
    /// Creates a new Momentum object with magnitude m and direction towards positive-x.
    /// </summary>
    /// <param name="m">The magnitude of the momentum.</param>
    public Momentum(float m)
    {
        magnitude = m;
        direction = new Vector3(1, 0, 0);
    }
}
