using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Captura : MonoBehaviour {

    //http://feroxhora.000webhostapp.com/TimeGame.php
    // Use this for initialization
    public string url = "http://feroxhora.000webhostapp.com/TimeGame.php";
    IEnumerator Start()
    {
        using (WWW www = new WWW(url))
        {
            yield return www;
            Debug.Log(www.text);
        }
    }
}
