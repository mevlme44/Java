using UnityEngine;

public class MapControler : MonoBehaviour
{
    public GameObject Map;

    void Update()
    {
        if (Input.touchCount > 0) {
            Touch t = Input.GetTouch(0);
            if (t.phase == TouchPhase.Stationary) {
                OnlineMapsMarkerManager.CreateItem(OnlineMapsControlBase.instance.GetCoords());
            }
        }
        if(Input.GetKeyDown(KeyCode.Escape)) {
            Map.SetActive(false);
        }
    }
}
