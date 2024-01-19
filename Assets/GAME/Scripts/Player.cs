using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Player : Character
{
    public FloatingJoystick variableJoystick;
    void FixedUpdate()
    {
        Move();
        hasEnemy = DetectEnemy(transform.position, radius);
        Shoot(hasEnemy);
    }
    private void Move()
    {
        float horizon = variableJoystick.Horizontal;
        float vertical = variableJoystick.Vertical;
        dir = new Vector3(horizon * speed, 0, vertical * speed);
        transform.rotation = Quaternion.LookRotation(dir);
        Vector3 nextPoint = dir * speed * Time.deltaTime + transform.position;
        if (dir != new Vector3(0, 0, 0))
        {
            if (CanMove(nextPoint))
            {
                isMoving = true;               
                transform.position = CheckGround(nextPoint);
                amountBullet = 1;
                hP = 1;
                //Debug.Log("Amount Bullet: " + amountBullet);
            }
        }
        else
        {
            //Draft
            //amountBullet = 0;
            isMoving = false;
        }
    }

    private void Shoot(bool hasEnemy)
    {
        if (isMoving == false && amountBullet > 0 && hasEnemy == true)
        {
            //Debug.Log("Is Shooting");
            amountBullet = 0;
            //hP = 0;
            //Debug.Log("Amount Bullet: " + amountBullet);
        }
    }
    public bool DetectEnemy(Vector3 center, float radius)
    {
        Debug.DrawLine(center, new Vector3(center.x + radius, center.y, center.z), Color.blue);
        LayerMask interactiveLayerMask = LayerMask.GetMask(enemyLayer);
        Collider[] hitColliders = Physics.OverlapSphere(center, radius, interactiveLayerMask);
        if (hitColliders.Length > 0)
        {
            //Debug.Log("Have ene");
            return true;
        }
        else
        {
            return false;
        }
    }
    
}
