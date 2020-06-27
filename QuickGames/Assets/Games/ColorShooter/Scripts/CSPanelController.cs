using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSPanelController : MonoBehaviour
{
    public GameObject panelL;
    public GameObject panelR;

    int prev;

    void Start(){
        prev = PlayerPrefs.GetInt("LeftHanded");

        if (prev == 0)
        {
            panelR.SetActive(true);
            panelL.SetActive(false);
        }
        else
        {
            panelR.SetActive(false);
            panelL.SetActive(true);
        }
    }

    void Update()
    {
        if(prev != PlayerPrefs.GetInt("LeftHanded"))
        {
            prev = PlayerPrefs.GetInt("LeftHanded");

            if (prev == 0)
            {
                panelR.SetActive(true);
                panelL.SetActive(false);
            }
            else
            {
                panelR.SetActive(false);
                panelL.SetActive(true);
            }
        }
    }
}
