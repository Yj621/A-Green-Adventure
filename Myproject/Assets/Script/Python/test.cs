using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class test : MonoBehaviour
{
    IEnumerator Start()
    {
        string url = "http://api.openweathermap.org/data/2.5/weather?q=Seoul&appid=6CBIQSoVwWEm3zFy39Yxc0NSJOo25d7C%2FQ7pCU5Hgq8iVjZmqRc2g2RyOJEcxZ%2FmiOz7x6N0RHYfkuvDh4LgVA%3D%3D";

        using (UnityWebRequest www = UnityWebRequest.Get(url))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                string jsonResult = www.downloadHandler.text;
                WeatherInfo weatherInfo = JsonUtility.FromJson<WeatherInfo>(jsonResult);

                Debug.Log("City: " + weatherInfo.name);
                Debug.Log("Temperature: " + weatherInfo.main.temp);
                Debug.Log("Description: " + weatherInfo.weather[0].description);
            }
        }
    }

    [System.Serializable]
    private class WeatherInfo
    {
        public string name;
        public MainInfo main;
        public Weather[] weather;
    }

    [System.Serializable]
    private class MainInfo
    {
        public float temp;
    }

    [System.Serializable]
    private class Weather
    {
        public string description;
    }
}
