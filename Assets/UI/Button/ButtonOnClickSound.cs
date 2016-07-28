using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

[RequireComponent(typeof(Button))]
public class ButtonOnClickSound : PlayOnEvent {

    protected override UnityEventBase playEvent
    {
        get
        {
            return GetComponent<Button>().onClick;
        }
    }
}
