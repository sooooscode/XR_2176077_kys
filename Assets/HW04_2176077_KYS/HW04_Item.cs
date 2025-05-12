using UnityEngine;

public class HW04_Item : MonoBehaviour
{
    void OnMouseDown()
    {
        HW04_GameManager.Instance.OnItemPicked();
        Destroy(gameObject);
    }
}
