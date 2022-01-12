using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : GridObject
{
    public float Speed = 100;
    private float ry = 0;

    void Start()
    {

    }

    void Update()
    {
        // 持續旋轉
        ry += Speed * Time.deltaTime;
        transform.rotation = Quaternion.Euler(0, ry, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        // 碰撞到玩家，消失
        if (other.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
