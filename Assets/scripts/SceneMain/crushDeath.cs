using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crushDeath : MonoBehaviour
{
    // 碰撞开始
    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("crash");
        Player.Instance.isGameOver = true ;
    } 
}
