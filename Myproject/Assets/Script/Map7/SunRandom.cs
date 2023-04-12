using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunRandom : MonoBehaviour
{
    public GameObject[] objectPrefabs; // 생성될 프리팹의 배열
    public float activationInterval; // 오브젝트 활성화 주기
    public float deactivateTime; // 비활성화까지 걸리는 시간

    private List<GameObject> activeObjects = new List<GameObject>(); // 활성화된 오브젝트 리스트

    void Start()
    {
        // 활성화 주기마다 랜덤한 오브젝트 활성화
        StartCoroutine(RandomActivation());
    }

    IEnumerator RandomActivation()
    {
        while (true)
        {
            // 랜덤한 오브젝트 선택
            GameObject obj = objectPrefabs[Random.Range(0, objectPrefabs.Length)];

            // 선택한 오브젝트 활성화
            GameObject newObj = Instantiate(obj, transform.position, Quaternion.identity);
            newObj.SetActive(true); // 수정된 부분
            activeObjects.Add(newObj);

            // 활성화 후 비활성화까지 대기
            yield return new WaitForSeconds(activationInterval);
            StartCoroutine(DeactivateObject(newObj));

            // 다음 활성화까지 대기
            yield return new WaitForSeconds(activationInterval);
        }
    }

    IEnumerator DeactivateObject(GameObject obj)
    {
        yield return new WaitForSeconds(deactivateTime);

        // 활성화된 오브젝트 리스트에서 제거
        activeObjects.Remove(obj);

        // 오브젝트 비활성화
        obj.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        // 충돌한 오브젝트가 활성화된 오브젝트 리스트에 있는 경우
        if (activeObjects.Contains(other.gameObject))
        {
            // "Hello" 출력
            Debug.Log("Hello");

            // 오브젝트 비활성화
            other.gameObject.SetActive(false);

            // 활성화된 오브젝트 리스트에서 제거
            activeObjects.Remove(other.gameObject);
        }
    }
}
