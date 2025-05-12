using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HW04_PutShooter : MonoBehaviour
{
    public GameObject itemPrefab;
    public Transform firePoint;
    public Transform target;

    public float shootForce = 500f;

    public void Fire()
    {
        if (HW04_GameManager.Instance.pickCount <= 0)
        {
            Debug.Log("No picked items left.");
            return;
        }

        // 아이템 생성
        GameObject item = Instantiate(itemPrefab, firePoint.position, Quaternion.identity);
        Rigidbody rb = item.GetComponent<Rigidbody>();

        // 방향 설정 후 힘 가함
        Vector3 dir = (target.position - firePoint.position).normalized;
        rb.AddForce(dir * shootForce);

        // PickCount 감소
        HW04_GameManager.Instance.pickCount--;
    }
}
