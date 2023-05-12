using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour {
    public GameObject[] spawnObjects;
    public float spawnTime = 10f;
    public string lastSpawnedObjectTag; // 마지막에 생성된 오브젝트의 태그값을 저장할 변수

    void Start () {
        // spawnTime마다 SpawnObject() 함수를 호출
        InvokeRepeating("SpawnObject", 0, spawnTime);
    }

    void SpawnObject () {
        // 랜덤하게 4개의 spawnObjects 중 하나를 선택
        int randomIndex = Random.Range(0, spawnObjects.Length);
        // 선택된 오브젝트를 생성하고 활성화
        GameObject obj = Instantiate(spawnObjects[randomIndex], transform.position, Quaternion.identity);
        // 태그 저장
        lastSpawnedObjectTag = obj.tag;
        obj.SetActive(true);
        // 10초 후에 생성된 오브젝트를 비활성화
        StartCoroutine(DeactivateObject(obj, 10f));
    }

    IEnumerator DeactivateObject(GameObject obj, float delayTime) {
        yield return new WaitForSeconds(delayTime);
        obj.SetActive(false);
    }
}
