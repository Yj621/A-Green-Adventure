using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunRandom : MonoBehaviour
{
    public GameObject[] objectPrefabs; // 생성될 프리팹의 배열
    public float activationInterval; // 오브젝트 활성화 주기
    public float deactivateTime; // 비활성화까지 걸리는 시간

    public List<GameObject> activeObjects = new List<GameObject>(); // 활성화할 오브젝트 리스트
        
    void Start()
    {
        StartCoroutine(RandomActivation());
        List<GameObject> activeObjectsList = new List<GameObject>();
        foreach(GameObject obj in activeObjects)
        {
            if(obj.activeSelf)
            {
                activeObjectsList.Add(obj);
            }
        }
    }

    IEnumerator RandomActivation()
    {
        while (true)
        {
            // 랜덤한 인덱스를 생성하여 프리팹 선택
            int randomIndex = Random.Range(0, objectPrefabs.Length);
            GameObject prefabToActivate = objectPrefabs[randomIndex];

            // 선택한 프리팹을 활성화하고 리스트에 추가
            GameObject newObject = Instantiate(prefabToActivate, transform.position, Quaternion.identity);
            newObject.SetActive(true);
            activeObjects.Add(newObject);

            // 비활성화까지 대기 후 DeactivateObject() 코루틴 실행
            yield return new WaitForSeconds(deactivateTime);
            StartCoroutine(DeactivateObject(newObject));

            // 활성화 주기까지 대기
            yield return new WaitForSeconds(activationInterval);
        }
    }

    IEnumerator DeactivateObject(GameObject obj)
    {
        yield return new WaitForSeconds(deactivateTime);

        // activeObjects 리스트에서 제거하고 비활성화
        activeObjects.Remove(obj);
        obj.SetActive(false);
    }
}

