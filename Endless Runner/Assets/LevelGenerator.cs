using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private Transform[] levelPart;
    [SerializeField] private Vector3 nextPartPosition;

    [SerializeField] private float distanceToSpawn;
    [SerializeField] private float distanceToDelet;
    [SerializeField] private Transform player;


    void Update()
    {
        DeletPlatform();
        GeneratePlatform();
    }

    private void GeneratePlatform()
    {
        while ((Vector2.Distance(player.transform.position, nextPartPosition) < distanceToSpawn))
        {
            Transform part = levelPart[Random.Range(0, levelPart.Length)];

            Vector2 newPosition = new Vector2(nextPartPosition.x - part.Find("StartPoint").position.x, 0);

            Transform newPart = Instantiate(part, newPosition, transform.rotation, transform);

            nextPartPosition = newPart.Find("EndPoint").position;
        }
    }

    private void DeletPlatform()
    {
        if(transform.childCount > 0)
        {
            Transform partToDelet = transform.GetChild(0);

            if(Vector2.Distance(player.transform.position, partToDelet.transform.position) > distanceToDelet)
            {
                Destroy(partToDelet.gameObject);
            }
        }
    }
}
