using UnityEngine;

public class HW04_ProjectileItem : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Basket"))
        {
            HW04_GameManager.Instance.putCount++;
            Destroy(gameObject);
        }
    }
}
