using PP.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class App : MonoBehaviour
{
    public LoginWindow loginWindow;
    // Start is called before the first frame update
    void Start()
    {
        MessageCenter.AddListener<string>(new MyMessageKey(MyMessageEnum.LoginSuccessed), OnLoginSuccessed);
        loginWindow.Show();
    }

    private void OnLoginSuccessed(string token)
    {
        Debug.Log($"µÇÂ¼³É¹¦:{token}");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
