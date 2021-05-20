using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Interface 
{
    public class Event : MonoBehaviour {
        public string Name;
        public string Date;
        public Vector2 Coordinates;

        public Text eventName;

        void Start() {

        }

        public void Instantiate(string name, string date, Vector2 coords) {
            var newButton = Instantiate(gameObject, transform.parent);
            newButton.SetActive(true);

            var newEvent = newButton.GetComponent<Event>();
            newEvent.SetParams(name, date, coords);

            newButton.GetComponentInChildren<Button>().onClick.AddListener(() => {
                EventController.Instance.SetEvent(false, newEvent);
            });

            if(transform.parent.childCount <= 2) return;

            var rect = transform.parent.gameObject.GetComponent<RectTransform>();
            rect.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, rect.rect.height + 185f);


        }

        public void SetParams(string name, string date, Vector2 coords) {
            eventName.text = name;
            Name = name;
            Date = date;
            Coordinates = coords;
        }
    }
}
