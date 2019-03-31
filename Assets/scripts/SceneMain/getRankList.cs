using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using Newtonsoft.Json.Linq;

public class getRankList : MonoBehaviour
{
    public int page = 1;
    public int size = 10;


    public GameObject gameOver;
    public GameObject rankListPanel;

    public Button disRankListPanelBtn;
    public Button prePageBtn;
    public Button nexPageBtn;
    public Button returnListBtn;

    public GameObject texts;

    public Text pageText;

    private string[] rankList = new string[10];


    public IEnumerator GetPage()
    {

        string url = "http://perci.ooo:8507/rank?size=" + size + "&&page=" + page;
        UnityWebRequest request = UnityWebRequest.Get(url);
        yield return request.SendWebRequest();

        if (!request.isNetworkError)
        {
            string result = request.downloadHandler.text;
            JObject obj = JObject.Parse(result);
            Debug.Log(obj);
            if (obj["code"].ToString() == "-1")
            {
                
            }
            else
            {
                string s_data = obj["data"].ToString();
                JArray ja = JArray.Parse(s_data);

                for (int i=0; i<size; i++)
                {
                    string t_text = "";
                    Text t = texts.transform.GetChild(i).gameObject.GetComponent<Text>();
                    if (i < ja.Count)
                    { 
                        JObject o = (JObject)ja[i];
                        t_text = o["nickname"].ToString() + " : " + o["score"].ToString();
                    } else
                    {
                        t_text = "暂无";
                    }
                    t.text = t_text; 
                }
            }
        }

        pageText.text = page.ToString();
    }
     
    public void prePage()
    {
        if (page > 1)
        {
            page -= 1;
            StartCoroutine(GetPage());

        }
    }

    public void DisRankList()
    {
        StartCoroutine(GetPage()); 
    }

    public void nexPage()
    {
        page += 1;
        StartCoroutine(GetPage());
    }

    public void returnList()
    {
        SetChildrenActive(gameOver, true);
        SetChildrenActive(rankListPanel, false);
    }

    private void Awake()
    {

        disRankListPanelBtn.onClick.AddListener(DisRankList);
        prePageBtn.onClick.AddListener(prePage);
        nexPageBtn.onClick.AddListener(nexPage);
        returnListBtn.onClick.AddListener(returnList);

        StartCoroutine(GetPage());

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
