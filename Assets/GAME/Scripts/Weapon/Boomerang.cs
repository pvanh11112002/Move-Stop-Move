using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Boomerang : Weapon
{
    public GameObject player;       
    public bool thrown;                                 // Check vũ khí có đang bị ném đi hoặc không
    public Transform boomerang;                         // Lấy thằng con của nó làm vũ khí để ném
    public bool rotateOnOff;                            // Check xem có đang quay không
    public bool startRotationPosition;                  //Kiểm tra xem boomerang đã quay về vị trí ban đầu hay chưa
    private void Start()
    {
        OnInit();
    }
    public override void OnInit()
    {
        player = GameObject.Find("Player");
        rotateOnOff = false;                            // Không quay
        thrown = false;                                 // chưa bị ném đi
        startRotationPosition = false;                  // chưa quay trở về vị trí ban đầu
    }
    private void Update()
    {
        startPos = player.transform.position;
        // Quay đều khi true
        if(rotateOnOff == true)
        {
            boomerang.Rotate(0, 0, rotateSpeed * Time.deltaTime);
        }
        // Dừng quay khi false và nó chưa quay trở về vị trí ban đầu
        if (rotateOnOff == false && startRotationPosition == false)
        {
            boomerang.transform.rotation = Quaternion.Euler(90f, 0, 0);
            startRotationPosition = true;
        }
        // Throw = true thì move forward và quay đầu khi đến distance
        if (thrown == true && transform.position.z < startPos.z + distance)
        {
            transform.Translate(Vector3.forward * throwSpeed * Time.deltaTime);
            if (Vector3.Distance(transform.position, startPos) > distance)
            {
                boomerang.transform.rotation = Quaternion.Euler(-90f, 0,0);
                thrown = false;
            }
        }        //Dừng quay khi thrown = false và vũ khí ở vị trí bắt đầu rồi        if (thrown == false && transform.position == startPos)
        {
            rotateOnOff = false;
        }        //Khi thrown = false và vũ khí k ở vị trí bắt đầu thì đưa nó về vị trí bắt đầu        if (thrown == false && transform.position != startPos)
        {
            transform.position = Vector3.MoveTowards(transform.position, startPos,throwSpeed * Time.deltaTime);
            if (transform.position == startPos)
            {
                thrown = false;
            }
        }        if (/*Input.GetKeyDown(KeyCode.Space) && */thrown == false && transform.position == startPos)
        {
            startRotationPosition = false;
            rotateOnOff = true;
            thrown = true;
        }
    }
}
