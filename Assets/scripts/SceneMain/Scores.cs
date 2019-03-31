using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.SceneManagement;

public class Scores : MonoBehaviour
{
    private Button btn;
    public GameObject gameOver;
    public GameObject rankListPanel;

    private void Awake()
    {
        btn = GetComponent<Button>();
        btn.onClick.AddListener(btClick);
    }

    void btClick()
    {
        SetChildrenActive(gameOver, false);
        SetChildrenActive(rankListPanel, true);
    }

    private void SetChildrenActive(GameObject obj, bool active)
    {
        obj.SetActive(active);
        for (int i = 0; i < obj.transform.childCount; i++)
        {

            GameObject childObj = obj.transform.GetChild(i).gameObject;
            childObj.SetActive(active);

        }
    }
}
