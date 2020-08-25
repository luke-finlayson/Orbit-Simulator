using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraOrbit : MonoBehaviour
{
    public Transform targetPlanet;

    public int orbitSpeed;

    // Update is called once per frame
    void FixedUpdate()
    {
        // Rotate around the planet
        transform.RotateAround(targetPlanet.position, new Vector3(0, 1, 0), orbitSpeed * Time.deltaTime);
    }
}
