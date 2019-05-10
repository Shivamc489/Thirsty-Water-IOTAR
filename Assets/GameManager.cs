using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Globalization;


public class GameManager : MonoBehaviour
{
    public GameObject Cube;
    public string webAddress="http://192.168.43.44:8000/Music/CoolTerm.txt";
    public float read;
    public GameObject dry;
    public GameObject fresh;
    public Text height;
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
            read =17- float.Parse(r.Substring(r.Length - 4));
            height.text = "Height of water is "+read.ToString()+"cm";
            Debug.Log(read);
            if (read < 7)
            {
                dry.SetActive(true);
                fresh.SetActive(false);
            }
            else
            {
                dry.SetActive(false);
                fresh.SetActive(true);
            }
            Vector3 newScale = new Vector3(0.05f * read, 1.0f, 1.0f);
            Cube.transform.localScale = Vector3.Lerp(Cube.transform.localScale, newScale, 2.0f*Time.deltaTime);
        }
    }
}
