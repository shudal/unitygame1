using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class alertPanelReturn : MonoBehaviour
{
    public Button btn;

    public GameObject gameOver;
    public GameObject alertPanel;

    private void Awake()
    {
        btn.onClick.AddListener(btClick);
    }

    void btClick()
    { 
        alertPanel.SetActive(false);
        SetChildrenActive(alertPanel, false);

        gameOver.SetActive(true);
        SetChildrenActive(gameOver, true);
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
