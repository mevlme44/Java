using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class Save : MonoBehaviour
{
    public Text Name;
    public Text Date;
    public OnlineMapsMarkerManager PositionMarker;

    public void OnConfrim() {
        if(PositionMarker.Count < 1) return;
        EventController.Instance.SaveEvent(Name.text, Date.text, PositionMarker.items[PositionMarker.Count-1].position);
    }
}
