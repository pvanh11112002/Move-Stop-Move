﻿using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ThrowWeapon : Weapon
{
    public GameObject player;
    // Vị trí khởi đầu của boomerang    
    // Check vũ khí có đang bị ném đi hoặc không
    public bool thrown;

    // Lấy thằng con của nó làm vũ khí để ném
    public Transform boomerang;


    // Check xem có đang quay không
    public bool rotateOnOff;
    //Kiểm tra xem boomerang đã quay về vị trí ban đầu hay chưa
    public bool startRotationPosition;
    private void Start()
    {
        rotateOnOff = false;
        thrown = false;        
        startRotationPosition = false;
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
        }
        {
            rotateOnOff = false;
        }
        {
            transform.position = Vector3.MoveTowards(transform.position, startPos,throwSpeed * Time.deltaTime);
            if (transform.position == startPos)
            {
                thrown = false;
            }
        }
        {
            startRotationPosition = false;
            rotateOnOff = true;
            thrown = true;
        }
    }
}