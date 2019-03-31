using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Repeat : MonoBehaviour
{
    private BoxCollider2D bx2D;
    private float groundHorLength;
    
    // Start is called before the first frame update
    void Start()
    {
        bx2D = GetComponent<BoxCollider2D>();
        groundHorLength = bx2D.size.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < -groundHorLength)
        {
            RepositionBackground();
        }
    }

    void  RepositionBackground()
    {
        Vector2 groundOffset = new Vector2(groundHorLength * 2, 0);
        transform.position = (Vector2)transform.position + groundOffset;
    }
}
