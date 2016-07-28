using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Events;

[RequireComponent(typeof(Dropdown))]
public class DropdownOnClickSound : PlayOnEvent
{
    private UnityEvent valueChanged = new UnityEvent();

    void Awake()
    {
        GetComponent<Dropdown>().onValueChanged.AddListener(x => valueChanged.Invoke());
    }

    protected override UnityEventBase playEvent
    {
        get
        {
            return valueChanged;
        }
    }
}