using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePlay : UICanvas
{
    public ChangeMatertial changeMatertial;
    public ChooseWeapon chooseWeapon;
    public int gamePlayWeaponSkinData;
    public int gamePlayWeaponIndexData = 0;
    public int gamePlaySkinData;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnPlay()
    {
        Debug.Log("On press Play");
        Debug.Log("Quần số: ");
        Debug.Log(changeMatertial.matIndexOfPants);
        gamePlaySkinData = changeMatertial.matIndexOfPants;
        Debug.Log("Vũ khí số: ");
        Debug.Log(chooseWeapon.indexOfWeaponBeenChoose);
        gamePlayWeaponIndexData = chooseWeapon.indexOfWeaponBeenChoose;
        Debug.Log("Skin của vũ khí");
        Debug.Log(changeMatertial.matIndexOfWeapon);
        gamePlayWeaponSkinData = changeMatertial.matIndexOfWeapon;
        DontDestroyOnLoad(this.gameObject);
        SceneManager.LoadSceneAsync(1);
    }
}
