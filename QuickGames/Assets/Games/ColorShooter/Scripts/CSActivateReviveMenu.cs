using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSActivateReviveMenu : MonoBehaviour
{
    public CSGameManager gameManager;
    public GameObject reviveMenu;

    void Update()
    {
        if (gameManager.reviveMenu)
        {
            reviveMenu.SetActive(true);
            gameManager.reviveMenu = false;
        }
    }
}
