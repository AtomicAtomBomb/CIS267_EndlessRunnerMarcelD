using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class LevelGenerator : MonoBehaviour
{
    private const float playerDistanceSpawnLevelPart = 200f;
    [SerializeField] private Transform levelPart_Start;
    [SerializeField] private List<Transform> levelPartList;
    [SerializeField] private GameObject player;

    private Vector3 lastEndPosition;
    private void Start()
    {
        lastEndPosition = levelPart_Start.Find("EndPosition").position;
        int startingSpawnLevelParts = 5;
        for (int i = 0; i < startingSpawnLevelParts; i++)
        {
            spawnLevelPart();
        }
    }

    private void Update()
    {
        if (Vector3.Distance(player.transform.position, lastEndPosition) < playerDistanceSpawnLevelPart)
        {
            spawnLevelPart();
        }
    }

    private void spawnLevelPart()
    {
        Transform chosenLevelPart= levelPartList[Random.Range(0, levelPartList.Count)];
        Transform lastLevelPartTransform = spawnLevelPart(chosenLevelPart, lastEndPosition);
        lastEndPosition = lastLevelPartTransform.Find("EndPosition").position;
    }

    private Transform spawnLevelPart(Transform levelPart, Vector3 spawnPosition)
    {
        Transform levelPartTransform = Instantiate(levelPart, spawnPosition, Quaternion.identity);
        return levelPartTransform;
    }
}
