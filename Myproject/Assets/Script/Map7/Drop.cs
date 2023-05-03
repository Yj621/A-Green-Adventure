using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drop : MonoBehaviour
{
    public GameObject[] objectPrefabs; //생성될 프리팹의 배열
    public int numObjectsPerPrefab = 10; 
    public float gameTime = 30.0f; // 게임 시간
    public float spawnInterval = 1.0f; // 오브젝트 생성 주기

IEnumerator SpawnObjects()
{
    float timer = 0.0f;

    while (timer < gameTime)
    {
        // 랜덤한 위치와 프리팹 선택해서 오브젝트 생성
        int randomPrefabIndex = Random.Range(0, objectPrefabs.Length); // 프리팹 배열에서 랜덤한 인덱스 선택
        Vector2 randomPosition = new Vector2(Random.Range(-16.0f, 16.0f), Random.Range(2.46f, 2.46f));
        GameObject newObj = Instantiate(objectPrefabs[randomPrefabIndex], randomPosition, Quaternion.identity);

        // Floor 태그와 충돌하면 오브젝트 삭제
        newObj.AddComponent<DestroyOnFloorCollision>();

        // 생성 주기만큼 대기
        yield return new WaitForSeconds(spawnInterval);

        // 경과 시간 측정
        timer += spawnInterval;
    }
}


    void Start()
    {
        StartCoroutine(SpawnObjects());
    }
}


