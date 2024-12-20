using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class URL_Jump : MonoBehaviour
{

    public string url = "https://drive.google.com/drive/folders/1HB7OoyzdHM3_PNg-6Q7Ln2pf44dN0e1m";

    // ボタンが押されたら実行する処理
    public void OpenURL()
    {
        if (string.IsNullOrEmpty(url))
        {
            Debug.LogError("URL is empty.");
            return;
        }

        Application.OpenURL(url);
    }

}