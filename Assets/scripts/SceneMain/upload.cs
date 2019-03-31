using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class upload : MonoBehaviour
{
    public Button btn;

    public GameObject gameOver;
    public GameObject uploadPanel;

    private void Awake()
    {
        btn.onClick.AddListener(btClick);
    }

    void btClick()
    {
        gameOver.SetActive(false);
        SetChildrenActive(gameOver, false);

        uploadPanel.SetActive(true);
        SetChildrenActive(uploadPanel, true);
        
        
    }

    private void SetChildrenActive(GameObject obj, bool active)
    {

        for (int i = 0; i < obj.transform.childCount; i++)
        {

            GameObject childObj = obj.transform.GetChild(i).gameObject;
            childObj.SetActive(active);

        }
    }


}
