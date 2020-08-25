using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuCanvas : MonoBehaviour
{
    public InputField numSatellitesField;
    public InputField maxOrbitField;
    public InputField minOrbitField;

    public Text errorBox;

    public void StartButtonClicked()
    {
        try
        {
            
            if(minOrbitField.text != "" || maxOrbitField.text != "" || numSatellitesField.text != "")
            {
                float maxOrbit = float.Parse(maxOrbitField.text);
                float minOrbit = float.Parse(minOrbitField.text);

                if (minOrbit > maxOrbit)
                {
                    errorBox.text = "Error: Minimum hieght must be less than maximum hieght.";
                }
                else
                {
                    SystemModel.numSatellites = int.Parse(numSatellitesField.text);
                    SceneManager.LoadScene(sceneName: "ModelScene");
                }
            }
            else
            {
                errorBox.text = "Error: Missing input values.";
            }
        }
        catch
        {
            errorBox.text = "Error: Non-integer character detected.";
        }
    }
}
