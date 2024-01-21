using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Unity.VisualScripting;

public class ObjectPoolManager : MonoBehaviour
{
    public static List<PoolObjectInfo> ObjectPools = new List<PoolObjectInfo>();
    public static GameObject SpawnObject(GameObject objToSpawn, Vector3 spawnPos, Quaternion spawnRotation)
    {
        PoolObjectInfo pool = ObjectPools.Find(p => p.LookupString == objToSpawn.name);
        //PoolObjectInfo pool = null;
        //foreach(PoolObjectInfo p in ObjectPools)
        //{
        //    if(p.LookupString == objToSpawn.name)
        //    {
        //        pool = p;
        //        break;
        //    }
        //}

        // Neu pool chua duoc tao thi tao no
        if (pool == null) 
        {
            pool = new PoolObjectInfo() { LookupString = objToSpawn.name };
            ObjectPools.Add(pool);
        }
        // Tim xem co obj nao inactive khong
        GameObject spawnableObj = pool.InactiveObjects.FirstOrDefault();
        if (spawnableObj == null)
        {
            // Neu khong co object nao inactive, thi tao 1 object moi
            spawnableObj = Instantiate(spawnableObj, spawnPos, spawnRotation);
        }
        else
        {
            // Neu co object inactive, active no
            spawnableObj.transform.position = spawnPos;
            spawnableObj.transform.rotation = spawnRotation;
            pool.InactiveObjects.Remove(spawnableObj);
            spawnableObj.SetActive(true);
        }
        return spawnableObj;
    }
    public static void ReturnObjToPool(GameObject obj)
    {
        string goName = obj.name.Substring(0, obj.name.Length - 7);
        PoolObjectInfo pool = ObjectPools.Find(p => p.LookupString == goName);
        if (pool == null)
        {
            Debug.Log("Obj chua duoc pool: " + obj.name);
        }    
        else
        {
            obj.SetActive(false);
            pool.InactiveObjects.Add(obj);
        }
    }
}
public class PoolObjectInfo
{
    public string LookupString;
    public List<GameObject> InactiveObjects = new List<GameObject>();   
}
