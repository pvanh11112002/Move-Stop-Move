using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelManager : Singleton<LevelManager>
{
    public GameObject botPrefabs;
    public float rangeX;
    public float rangeZ;
    void Start()
    {
        
        //Time.timeScale = 0;
        OnInit();
        
    }
    public void OnInit()
    {
        GetSizeOfPlane();
        MakeRandomSizeToCreateBot();
    }
    public void GetSizeOfPlane()
    {
        GameObject planeObject = GameObject.Find("Plane");
        MeshRenderer meshRenderer = planeObject.GetComponent<MeshRenderer>();
        Vector3 size = meshRenderer.bounds.size;
        // Tính range trục x và trục z
        rangeX = size.x * 0.5f; // Đối với plane, kích thước x sẽ là chiều rộng
        rangeZ = size.z * 0.5f; // Đối với plane, kích thước z sẽ là chiều dài
    } 
    public void MakeRandomSizeToCreateBot()
    {
        List<Vector3> ListOfPos = new List<Vector3>();
        for(int i = 0; i < ObjectPoolManager.Instance.numberOfBot; i++)
        {
            ListOfPos.Add(new Vector3(Random.Range(-LevelManager.Instance.rangeX, LevelManager.Instance.rangeX), 1, Random.Range(-LevelManager.Instance.rangeZ, LevelManager.Instance.rangeZ)));
        }
        for(int i = 0; i < ListOfPos.Count; i++)
        {
            GameObject newbot = Instantiate(botPrefabs, ListOfPos[i], Quaternion.identity);
            newbot.GetComponent<Bot>().tagNum = i;
        }    
    }
    public void OnStartGame()
    {
        GameManager.Instance.ChangeState(GameState.GamePlay);
    }
    public void OnFinishGame()
    {

    }
    public void OnReset()
    {

    }
}
