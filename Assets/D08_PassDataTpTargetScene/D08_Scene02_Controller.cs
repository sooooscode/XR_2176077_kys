using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class D08_Scene02_Controller : MonoBehaviour
{
    string UserInput;
    public TMP_Text Message;
    void Start()
    {
        UserInput = PlayerPrefs.GetString("Input");
        if (string.IsNullOrEmpty(UserInput))
        {
            Message.text = "PlayerPrefs �� ������ �����Ͱ� �����ϴ�.";
        }
        else
        {
            Message.text = UserInput;
        }
    }
    public void OnClick_LoadScene(Object SceneObject)
    {
        SceneManager.LoadScene(SceneObject.name);
    }
}