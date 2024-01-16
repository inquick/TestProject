using PP.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoginWindow : MonoBehaviour
{
    public Button SubmitBtn;
    // Start is called before the first frame update
    void Start()
    {
        SubmitBtn = transform.Find("Button_Login").GetComponent<Button>();
        SubmitBtn.onClick.AddListener(OnSubmitBtnClicked);
    }

    private void OnSubmitBtnClicked()
    {
        MessageCenter.Invoke<string>(new MyMessageKey(MyMessageEnum.LoginSuccessed), "Okendhuekng283y*kjkhfskhdsdf1221");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }
}
