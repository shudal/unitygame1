using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class goHome : MonoBehaviour
{

    public Button btn;

    private void Awake()
    {
        btn.onClick.AddListener(btClick);
    }

    void btClick()
    {
        SceneManager.LoadScene("MainMenu");
    } 
}
