using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using Newtonsoft.Json.Linq;

public class UploadGrades : MonoBehaviour
{
    public Button btn;
    public Text nicknameText;
    public Text passwordText;

    private string nickname;
    private string password;

    public GameObject uploadPanel;
    public GameObject alertPanel;
    public Text alertText;

    private void Awake()
    {
        btn.onClick.AddListener(btClick);
    }

    void btClick()
    {
        nickname = nicknameText.text;
        password = passwordText.text;

        StartCoroutine(UploadG());
    }

    private void SetChildrenActive(GameObject obj, bool active)
    {

        for (int i = 0; i < obj.transform.childCount; i++)
        {

            GameObject childObj = obj.transform.GetChild(i).gameObject;
            childObj.SetActive(active);

        }
    }

    IEnumerator UploadG()
    {
        WWWForm form = new WWWForm();
        form.AddField("nickname", nickname);
        form.AddField("password", password);
        form.AddField("score", Player.Instance.score);
        string url = "http://perci.ooo:8507/score";
        UnityWebRequest request = UnityWebRequest.Post(url, form);
        yield return request.SendWebRequest();

        string alertMsg = "";
        if (request.isNetworkError)
        {
            Debug.Log("Http 请求错误：" + request.error);
        } else
        {
            string result = request.downloadHandler.text;
            Debug.Log(result);
            JObject obj = JObject.Parse(result);

            if (obj["code"].ToString() == "-1" )
            {
                if (obj["msg"].ToString() == "uncorrect_pass")
                {
                    alertMsg = "昵称对应的密码不正确";
                } else
                {
                    alertMsg = obj["msg"].ToString();
                }
            } else
            {
                alertMsg = "上传成功";
                Player.Instance.score = 0;
            }

            uploadPanel.SetActive(false);
            SetChildrenActive(uploadPanel, false);

            alertText.text = alertMsg;
            alertPanel.SetActive(true);
            SetChildrenActive(alertPanel, true);

        }
    }
}
