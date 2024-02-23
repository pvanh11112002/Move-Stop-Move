using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseWeapon : MonoBehaviour
{
    public GameObject axe;
    public GameObject boomerang;
    string currentWeapon = "Axe";
    public int indexOfWeaponBeenChoose = 0;
    private void Awake()
    {
        axe.SetActive(true);
        boomerang.SetActive(false);
    }
    public void ChangeToBoomerang()
    {
        axe.SetActive(false);
        boomerang.SetActive(true);
        currentWeapon = boomerang.name;
        indexOfWeaponBeenChoose = 2;
        Debug.Log(currentWeapon);
    }
    public void ChangeToAxe()
    {
        axe.SetActive(true);
        boomerang.SetActive(false);
        currentWeapon = axe.name;
        indexOfWeaponBeenChoose = 1;
        Debug.Log(currentWeapon);
    }

}
