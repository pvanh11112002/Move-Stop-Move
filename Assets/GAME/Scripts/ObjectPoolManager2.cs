//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.Pool;

//public class ObjectPoolManager2 : MonoBehaviour
//{
//    public ObjectPool<Bullet> _pool; // sửa thành weapon
//    private Player playerAimAndShoot;
//    private void Start()
//    {
//        playerAimAndShoot = GetComponent<Player>();
//        //_pool = new ObjectPool<Bullet>();
//    }
//    private Bullet CreateBullet()
//    {
//        Bullet bullet = Instantiate(playerAimAndShoot.weaponPrefabs, playerAimAndShoot.throwPoint.transform.position, playerAimAndShoot.transform.rotation);
//    }    
//}
