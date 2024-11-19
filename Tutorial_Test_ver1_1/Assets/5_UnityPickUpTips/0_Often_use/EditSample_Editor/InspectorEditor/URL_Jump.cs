using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class URL_Jump : MonoBehaviour
{

    public string url = "https://drive.google.com/drive/folders/1HB7OoyzdHM3_PNg-6Q7Ln2pf44dN0e1m";

    // ƒ{ƒ^ƒ“‚ª‰Ÿ‚³‚ê‚½‚çÀs‚·‚éˆ—
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