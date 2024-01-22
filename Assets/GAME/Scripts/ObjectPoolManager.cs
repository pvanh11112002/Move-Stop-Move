using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolManager : MonoBehaviour
{
    public static ObjectPoolManager instance;

    // Pool game object
    private List<GameObject> pooledObjects = new List<GameObject>();
    public GameObject[] bulletPrefabs;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }    
    }
    private void Start()
    {
        // T&ạo ra và add nó vào bể
        for(int i = 0; i < bulletPrefabs.Length; i ++)
        {
            GameObject obj = Instantiate(bulletPrefabs[i]);
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
}
