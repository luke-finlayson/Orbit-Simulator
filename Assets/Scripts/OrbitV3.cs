using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitV3 : MonoBehaviour
{
    public Transform centerPoint;
    public BigBang universe;
    public Vector3 startPos;
    
    public float startRot;
    public float rotateSpeed;

    public float x, y, z;
    public Vector3 rotVector;

    public System.Random rand = new System.Random();

    void Start()
    {
        int i = rand.Next(100);
        int j = rand.Next(100);

        // Check if current satellite is even or odd
        if(j < 50)
        {
            x = 0;

            y = Random.Range(0.0f, 1.0f);
            z = 1 - y;

            if(i < 50)
            {
                z = z * -1;
            }

            transform.position = new Vector3(6.92f, 0, 0);
        }
        else
        {
            z = 0;

            y = Random.Range(0.0f, 1.0f);
            x = 1 - y;

            if(i < 50)
            {
                x = x * -1;
            }

            transform.position = new Vector3(0, 0, 6.92f);
        }

        // Set rotation axis vector
        rotVector = new Vector3(x, y, z);

        startRot = Random.Range(0.0f, 360f);
        // Set initial rotation
        //RotateSatellite(startRot);
    }

    private void FixedUpdate()
    {
        RotateSatellite(rotateSpeed * Time.deltaTime);
    }

    void RotateSatellite(float rotateAmount)
    {
        transform.RotateAround(centerPoint.position, rotVector, rotateAmount);
        transform.LookAt(centerPoint);
    }
}