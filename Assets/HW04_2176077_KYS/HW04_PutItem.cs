using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HW04_PutItem : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Basket"))
        {
            HW04_GameManager.Instance.OnItemPut();
            Destroy(gameObject);
        }
    }
}
