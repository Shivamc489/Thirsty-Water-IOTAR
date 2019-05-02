using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.Globalization;


public class GameManager : MonoBehaviour
{
    public GameObject Cube;
    public string webAddress="http://192.168.43.44:8000/Music/CoolTerm.txt";
    public float read;
    int i = 0;
        
    public void FixedUpdate()
    {
        StartCoroutine(userEnable());
    }

    IEnumerator userEnable()
    {
        UnityWebRequest www = UnityWebRequest.Get(webAddress);
        yield return www.SendWebRequest();
        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {
            string r = www.downloadHandler.text;
            Debug.Log(r.Substring(r.Length-4));
            read = float.Parse(r.Substring(r.Length - 4));
            Debug.Log(read);
            Cube.transform.localScale = new Vector3(0.01f*read, 1.0f, 1.0f);
        }
    }
}
