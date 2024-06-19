using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject Settings;

    public void SettingsButoon()    
    {
        Settings.SetActive(true);
    }
    public void Atras()
    {
        Settings.SetActive(false);
    }
}
