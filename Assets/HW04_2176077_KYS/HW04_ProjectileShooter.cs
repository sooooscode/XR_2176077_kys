using UnityEngine;
using UnityEngine.UI;

public class HW04_ProjectileShooter : MonoBehaviour
{
    public GameObject itemPrefab;
    public Transform firePoint;
    public Transform targetPoint;
    public Button fireButton;

    void Start()
    {
        fireButton.onClick.AddListener(Fire);
    }

    public void Fire()
    {
        if (HW04_GameManager.Instance.pickCount <= 0) return;

        GameObject projectile = Instantiate(itemPrefab, firePoint.position, Quaternion.identity);
        projectile.GetComponent<Rigidbody>().velocity = (targetPoint.position - firePoint.position).normalized * 2f;

        HW04_GameManager.Instance.pickCount--;
    }
}
