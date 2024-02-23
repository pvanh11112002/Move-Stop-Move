using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolManager : Singleton<ObjectPoolManager>
{
    // Pool game object
    [SerializeField] MeshRenderer weaponMeshRendererToUse;
    public Material[] materialToUse;
    private List<GameObject> pooledObjects = new List<GameObject>();
    private List<GameObject> pooledObjectsOfBot = new List<GameObject>();
    public GameObject[] bulletPrefabs;
    public GameObject bulletPrefabsOfBot;
    public int numberOfBot;
    public GamePlay gamePlay;
    private void Awake()
    {
        gamePlay = GameObject.FindGameObjectWithTag("FromGamePlay").GetComponent<GamePlay>();
    }
    private void Start()
    {
        //if(PlayerPrefs.HasKey("HighScore"))
        //{
        //    Debug.Log("Có HighScore nè");
        //}    
        // T&ạo ra và add nó vào bể

        ////Code chuẩn
        //for (int i = 0; i < bulletPrefabs.Length; i++)
        //{
        //    GameObject obj = Instantiate(bulletPrefabs[i]);
        //    obj.SetActive(false);
        //    pooledObjects.Add(obj);
        //}
        for (int j = 0; j < numberOfBot; j++)
        {
            GameObject objBot = Instantiate(bulletPrefabsOfBot);            
            objBot.SetActive(false);
            pooledObjectsOfBot.Add(objBot);
        }
        for (int i = 0; i < 10; i++)
        {
            GameObject obj = Instantiate(bulletPrefabs[gamePlay.gamePlayWeaponIndexData]);
            //weaponMeshRendererToUse.material = materialToUse[gamePlay.gamePlayWeaponSkinData];
            obj.SetActive(false);
            pooledObjects.Add(obj);
        }

    }
    public GameObject GetPooledObject(int a)
    {
        //for(int i = 0; i < pooledObjects.Count; i++)
        //{
        //    if (!pooledObjects[i].activeInHierarchy)
        //    {
        //        return pooledObjects[i];
        //    }    
        //}
        if (!pooledObjects[a].activeInHierarchy)
        {
            return pooledObjects[a];
        }
        return null;
    }
    public GameObject GetPooledObjectOfBot(int a)
    {
        if (!pooledObjectsOfBot[a].activeInHierarchy)
        {
            return pooledObjectsOfBot[a];
        }
        return null;
    }
    private void Update()
    {
        int score = PlayerPrefs.GetInt("Player Score", 0);
        //Debug.Log("Score: " + score);
    }
}
