using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HW04_GameManager : MonoBehaviour
{
    public static HW04_GameManager Instance;

    public int pickCount = 0;
    public int putCount = 0;
    public int remainingItems = 10;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);  // 씬 전환해도 유지
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // 아이템 하나 주웠을 때 호출
    public void OnItemPicked()
    {
        pickCount++;
        remainingItems = Mathf.Max(remainingItems - 1, 0);
    }

    // 아이템 하나 넣었을 때 호출
    public void OnItemPut()
    {
        putCount++;
        pickCount = Mathf.Max(pickCount - 1, 0);
    }
}
