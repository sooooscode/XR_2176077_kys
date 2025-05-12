using UnityEngine;
using TMPro;

public class HW04_UIUpdater : MonoBehaviour
{
    public TextMeshProUGUI pickCountText;
    public TextMeshProUGUI putCountText;

    void Update()
    {
        pickCountText.text = "Pick Count: " + HW04_GameManager.Instance.pickCount;
        putCountText.text = "Put Count: " + HW04_GameManager.Instance.putCount;

    }
}
