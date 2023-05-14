using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour {
    public GameObject[] spawnObjects;
    public float spawnTime = 10f;
    public string lastSpawnedObjectTag; // 마지막에 생성된 오브젝트의 태그값을 저장할 변수

    int randomIndex=0;
    void Start () {
        // spawnTime마다 SpawnObject() 함수를 호출
        InvokeRepeating("SpawnObject", 0, spawnTime);
    }

    void SpawnObject () {
        //기존이미지 비활성화
        spawnObjects[randomIndex].gameObject.SetActive(false);
        // 랜덤하게 4개의 spawnObjects 중 하나를 선택
        randomIndex = Random.Range(0, spawnObjects.Length);
        // 선택된 오브젝트를 새로 활성화
        spawnObjects[randomIndex].gameObject.SetActive(true);
        // 태그 저장
        lastSpawnedObjectTag = spawnObjects[randomIndex].gameObject.tag;
    }

}
