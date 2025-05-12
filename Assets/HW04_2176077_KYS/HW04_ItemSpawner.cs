using UnityEngine;
using Vuforia;

public class HW04_ItemSpawner : MonoBehaviour
{
    public GameObject itemPrefab;
    public Transform spawnArea;

    private ObserverBehaviour observerBehaviour;
    private bool itemsSpawned = false;

    void Start()
    {
        observerBehaviour = GetComponent<ObserverBehaviour>();
        if (observerBehaviour != null)
        {
            observerBehaviour.OnTargetStatusChanged += OnTargetStatusChanged;
        }
    }

    void OnDestroy()
    {
        if (observerBehaviour != null)
        {
            observerBehaviour.OnTargetStatusChanged -= OnTargetStatusChanged;
        }
    }

    private void OnTargetStatusChanged(ObserverBehaviour behaviour, TargetStatus status)
    {
        if (!itemsSpawned && (status.Status == Status.TRACKED || status.Status == Status.EXTENDED_TRACKED))
        {
            SpawnItems();
            itemsSpawned = true;
        }
    }

    void SpawnItems()
    {
        int count = HW04_GameManager.Instance.remainingItems;

        for (int i = 0; i < count; i++)
        {
            Vector3 randomPos = spawnArea.position + new Vector3(
                Random.Range(-0.1f, 0.1f),
                0f,
                Random.Range(-0.1f, 0.1f)
            );

            Instantiate(itemPrefab, randomPos, Quaternion.identity);
        }
    }
}
