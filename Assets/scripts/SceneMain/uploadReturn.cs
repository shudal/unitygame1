using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class uploadReturn : MonoBehaviour
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
        gameOver.SetActive(true);
        SetChildrenActive(gameOver, true);

        uploadPanel.SetActive(false);
        SetChildrenActive(uploadPanel, false);
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
