using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Unity.Notifications.Android;
using System;
public class EventController : MonoSingleton<EventController>
{
    public enum Mode {
        create = 0,
        reset = 1,
    }

    public Mode CurrentMode;

    public GameObject CreateUI;
    public GameObject EventsUI;
    public Button CreateEventButton;
    public Interface.Event EventTemplate;
    public Interface.Event UpdateEvent;

    AndroidNotificationChannel channel;
    AndroidNotification notify;

    void Awake() {
        CreateEventButton.onClick.AddListener(() => SetEvent(true));
        channel = new AndroidNotificationChannel() {
            Id = "local",
            Name = "1",
            Importance = Importance.High,
            Description = "Generic notifications",
        };
        AndroidNotificationCenter.RegisterNotificationChannel(channel);
        notify = new AndroidNotification();
    }

    public void SetEvent(bool create, Interface.Event currentEvent = null) {
        CurrentMode = create ? Mode.create : Mode.reset;
        UpdateEvent = currentEvent;
        CreateUI.SetActive(true);
        EventsUI.SetActive(false);
    }

    public void SaveEvent(string name, string date, Vector2 pos) {
        if (CurrentMode == Mode.create) {
            EventTemplate.Instantiate(name, date, pos);
        }
        else {
            UpdateEvent.SetParams(name, date, pos);
        }

        SendPush(name, (DateTime.Parse(date) - DateTime.Now).TotalSeconds);

        CreateUI.SetActive(false);
        EventsUI.SetActive(true);
    }

    public void SendPush(string name, double seconds) {

        notify.Title = "Событие произошло";
        notify.Text = name;
        notify.FireTime = System.DateTime.Now.AddSeconds(seconds);

        AndroidNotificationCenter.SendNotification(notify, "local");
    }

}
