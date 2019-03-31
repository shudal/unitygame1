using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public Button btn;

    private void Awake()
    {
        btn.onClick.AddListener(btClick);
    }

    void btClick()
    {
        SceneManager.LoadScene("Main");
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }
         
    // Update is called once per frame
    void Update()
    {
        
    }
}
