using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class D06_UIGameObejcts : MonoBehaviour
{
    public void OnClick_Print(GameObject Target)
    {
        print(Target.name);
        //Destroy(Target);
        SceneManager.LoadScene(0);
    }
}
