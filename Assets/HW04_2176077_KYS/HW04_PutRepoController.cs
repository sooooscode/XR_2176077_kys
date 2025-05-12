using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HW04_PutRepoController : MonoBehaviour
{
    public Transform centerPoint;
    public float moveRadius = 0.1f;

    void Start()
    {
        StartCoroutine(MoveRoutine());
    }

    IEnumerator MoveRoutine()
    {
        while (true)
        {
            Vector3 newPos = centerPoint.position + new Vector3(
                Random.Range(-moveRadius, moveRadius),
                0,
                Random.Range(-moveRadius, moveRadius)
            );
            transform.position = newPos;
            yield return new WaitForSeconds(Random.Range(0.5f, 1f));
        }
    }
}
