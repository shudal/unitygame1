using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scrolling : MonoBehaviour
{
    public float scrollSpeed = -1.5f;
    private Rigidbody2D rigi2D;

    // Start is called before the first frame update
    void Start()
    {
        rigi2D = GetComponent<Rigidbody2D>();
        rigi2D.velocity = new Vector2(scrollSpeed, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Player.Instance.isGameOver)
        {
            rigi2D.velocity = Vector2.zero;
        }
    }
}
