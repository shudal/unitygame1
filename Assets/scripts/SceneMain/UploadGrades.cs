using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class UploadGrades : MonoBehaviour
{
    public Button btn;
    public Text nicknameText;
    public Text passwordText;

    private string nickname;
    private string password;

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

    IEnumerator UploadG()
    {
        WWWForm form = new WWWForm();
        form.AddField("nickname", nickname);
        form.AddField("password", password);
        string url = "http://132.232.57.130:8507/grade";
        UnityWebRequest request = UnityWebRequest.Post(url, form);
        yield return request.SendWebRequest();
        
        if (request.isNetworkError)
        {
            Debug.Log("Http 请求错误：" + request.error);
        } else
        {
            string result = request.downloadHandler.text;
            Debug.Log(result);

        }
    }
}
