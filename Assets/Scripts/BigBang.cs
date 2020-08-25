using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BigBang : MonoBehaviour
{
    public Transform satellite;
    public Transform parentPlanet;
    public int satelliteCounter = 0;

    public Camera orbitCamera;
    public Camera surfaceCamera;

    Vector3 spawnLocation = new Vector3(0, 0, 0);

    // Start is called before the first frame update
    void Start()
    {
        if(SystemModel.numSatellites != 0)
        {
            StartCoroutine("GenerateSatellites");
        }

        orbitCamera.enabled = true;
        surfaceCamera.enabled = false;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.C))
        {
            orbitCamera.enabled = !orbitCamera.enabled;
            surfaceCamera.enabled = !surfaceCamera.enabled;
        }
    }

    IEnumerator GenerateSatellites()
    {
        for (int i = 1; i < SystemModel.numSatellites; i++)
        {
            Instantiate(satellite, spawnLocation, Quaternion.identity, parentPlanet);
            yield return null;
        }
    }
}