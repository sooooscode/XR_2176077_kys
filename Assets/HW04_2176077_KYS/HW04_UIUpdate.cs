using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HW04_UIUpdate : MonoBehaviour
{
    public TextMeshProUGUI pickCountText;
    public TextMeshProUGUI putCountText;

    void Update()
    {
        pickCountText.text = "Pick Count: " + HW04_GameManager.Instance.pickCount;
        putCountText.text = "Put Count: " + HW04_GameManager.Instance.putCount;

    }

}
