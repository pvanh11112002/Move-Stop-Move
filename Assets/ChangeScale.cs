using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeScale : Character
{

    // Update is called once per frame
    void Update()
    {
        if (killCount == 0)
        {
            transform.localScale = Vector3.one;
        }
        float size = killCount * 0.5f;
        transform.localScale = new Vector3(size, size, size);
    }
}
