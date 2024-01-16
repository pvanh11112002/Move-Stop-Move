using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plane : MonoBehaviour
{
    private float rangeX;
    private float rangeZ;
    // Start is called before the first frame update
    void Start()
    {
        GameObject planeObject = GameObject.Find("Plane");
        MeshRenderer meshRenderer = planeObject.GetComponent<MeshRenderer>();
        Vector3 size = meshRenderer.bounds.size;
        // Tính range trục x và trục z
        rangeX = size.x * 0.5f; // Đối với plane, kích thước x sẽ là chiều rộng
        rangeZ = size.z * 0.5f; // Đối với plane, kích thước z sẽ là chiều dài
        // Hiển thị thông tin
        Debug.Log("Range trục x: " + rangeX);
        Debug.Log("Range trục z: " + rangeZ);


    }
}
