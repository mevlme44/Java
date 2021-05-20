using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventController : MonoBehaviour
{
    public static EventController Instance => ;

    public enum Mode {
        create = 0,
        reset = 1,
    }

    public Mode CurrentMode;

    public GameObject CreateUI;
    public GameObject EventsUI;
    public Interface.Event EventTemplate;
    public Interface.Event UpdateEvent;

    public void SetEvent(bool create) {
        CurrentMode = create ? Mode.create : Mode.reset;
        CreateUI.SetActive(true);
        EventsUI.SetActive(false);
    }

    public void SaveEvent(string name, string date, Vector2 pos) {
        if (CurrentMode == Mode.create) {
            EventTemplate.Instantiate(name, date, pos);
        }
        else {
            UpdateEvent.Name = name;
            UpdateEvent.Date = date;
            UpdateEvent.Coordinates = pos;
        }

        CreateUI.SetActive(false);
        EventsUI.SetActive(true);
    }
}
