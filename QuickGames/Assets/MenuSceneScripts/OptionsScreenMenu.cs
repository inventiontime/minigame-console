using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsScreenMenu : MonoBehaviour
{
    public GameObject soundsToggle;
    public GameObject musicToggle;
    public GameObject handOption;

    void Start()
    {
        if(PlayerPrefs.GetInt("SFXoff") == 0)
            soundsToggle.GetComponent<ToggleScript>().setState(true);
        else
            soundsToggle.GetComponent<ToggleScript>().setState(false);

        if (PlayerPrefs.GetInt("BGMoff") == 0)
            musicToggle.GetComponent<ToggleScript>().setState(true);
        else
            musicToggle.GetComponent<ToggleScript>().setState(false);

        if (PlayerPrefs.GetInt("LeftHanded") == 0)
            handOption.GetComponent<HandOptionScript>().setState(true);
        else
            handOption.GetComponent<HandOptionScript>().setState(false);
    }

    public void ChangeStateSFX(bool on)
    {
        if (on)
            PlayerPrefs.SetInt("SFXoff", 0);
        else
            PlayerPrefs.SetInt("SFXoff", 1);
    }

    public void ChangeStateBGM(bool on)
    {
        if (on)
            PlayerPrefs.SetInt("BGMoff", 0);
        else
            PlayerPrefs.SetInt("BGMoff", 1);
    }

    public void ChangeToRightHanded() => PlayerPrefs.SetInt("LeftHanded", 0);

    public void ChangeToLeftHanded() => PlayerPrefs.SetInt("LeftHanded", 1);
}
