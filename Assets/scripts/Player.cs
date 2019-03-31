using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public static Player Instance;

    public Transform player;

    private Rigidbody2D playerR;
    private Transform bottom_gravity;
    public Animator anim;

    [Header("侦测地板的射线起点")]
    private Transform groundCheck;
    private Transform groundCheck2;

    public bool isgroud;
    [Header("地面图册")]
    public LayerMask groundLayer;
    [Header("感应地板的距离")]
    [Range(0, 5)]
    public float distance;

    private int m_times = 6;
    public int direction = 0;
    public int player_hor_face = 0;
    
    public static bool lay = false;

    public int yForce = 700;

    public string[] directions;

    public bool isGameOver = false;
    public Text scoreText;
    public int score = 0;

    public GameObject gameOver;
    

    private void IsGround()
    {
        bool grounded;
        bool grounded2;

        Vector2 start = groundCheck.position;
        Vector2 end = new Vector2(start.x, start.y - distance);

        grounded = Physics2D.Linecast(start, end, groundLayer);

        start = groundCheck2.position;
        end = new Vector2(start.x, start.y - distance);

        grounded2 = Physics2D.Linecast(start, end, groundLayer);

        if (grounded || grounded2)
        {
            isgroud = true;
        }
        else
        {
            isgroud = false;
        }
    }

    private void Daimao()
    {
        if (isgroud)
        {
            if (anim.GetBool("jump"))
            {
                anim.SetBool("jump", false);
            }
        } else
        {
            if (!anim.GetBool("jump"))
            {
                anim.SetBool("jump", true);
            }
        }
    }

    public void Lay(bool lay2)
    {
        lay = lay2;

        Debug.Log(lay);
        if (lay)
        {
            anim.SetBool("lay", true);
        } else
        {
            anim.SetBool("lay", false);
        }
    }

    public void Jump()
    {
        playerR.velocity = Vector2.zero;
        playerR.AddForce(Vector2.up * yForce);
        /*
        if (isgroud)
        {
            playerR.AddForce(Vector2.up * yForce); 
        }
        */
    } 

    public void MoveHor(int direction2)
    {
        direction = direction2;

        if (direction != 0)
        {
            player_hor_face = direction;
        }
    }

    private void MoveControoll()
    {
        // 人物向右
        if (player_hor_face > 0)
        {
            if (lay) // 人物躺下
            {
                if (player.localScale.x < 0)
                {
                    player.localScale += new Vector3(-2 * player.localScale.x, 0, 0);
                }
            } else // 人物站立
            {
                if (player.localScale.x > 0)
                {
                    player.localScale += new Vector3(-2 * player.localScale.x, 0, 0);
                }
            }
        } // 人物向左
        else
        {
            if (lay) // 人物躺下
            {
                if (player.localScale.x > 0)
                {
                    player.localScale += new Vector3(-2 * player.localScale.x, 0, 0);
                }
            } else // 人物战力
            {
                if(player.localScale.x < 0)
                {
                    player.localScale += new Vector3(-2 * player.localScale.x, 0, 0);
                }
            }
        }
    }

    public void Score()
    {
        if (!isGameOver)
        {
            score++;
            scoreText.text = "分数：" + score;
        }
    }

    void Die()
    {
        Instance.isGameOver = true;
        gameOver.SetActive(true);
    }

    void OnCollisionEnter2D(Collision2D collision)
    { 
        if (collision.collider.tag == "death")
        {
            Player.Instance.isGameOver = true;
        }
    }

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        player_hor_face = 1;
    }

    void Start()
    {
        groundCheck = player.Find("detect_ground_1");
        groundCheck2 = player.Find("detect_ground_2");

        playerR = player.GetComponent<Rigidbody2D>();

        bottom_gravity = player.Find("bottom_gravity");

        anim = player.GetComponent<Animator>();

        directions = new string[4] {"u", "d", "l", "r"};
         
    }

    // Update is called once per frame
    void Update()
    {
        IsGround();

        // 控制呆毛
        Daimao();

        // 防止摔倒
        playerR.centerOfMass = bottom_gravity.localPosition;

        // 人物朝向控制
        MoveControoll();

        // 移动
        if (direction != 0)
        {
            player.transform.Translate(direction * m_times * Time.deltaTime, 0, 0); ;

        }

        if (isGameOver)
        {
            Die();
        }
    }
}
