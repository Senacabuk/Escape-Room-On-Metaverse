using UnityEngine;
using UnityEngine.Playables;

public class TimelineController : MonoBehaviour
{
    public PlayableDirector timeline;
 
    private void Start()
    {
        DoorController.OnDoorOpen += StartTimeline;
    }

    private void StartTimeline()
    {
        timeline.Play();
    }
}
