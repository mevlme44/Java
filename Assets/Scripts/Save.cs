using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Save : MonoBehaviour
{
    public Text Name;
    public Text Date;
    public Interface.Event ButtonTemplate;

    void Awake() {

    }

    public void OnConfrim() {
        ButtonTemplate.Instantiate(Name.text, Date.text, Vector2.one);
        //PlayerPrefs.SetString(Name.text, Date.text);
    }
}
