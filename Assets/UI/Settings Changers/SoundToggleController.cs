using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(Toggle))]
public class SoundToggleController : MonoBehaviour {

    private Toggle toggle;

    void Start()
    {
        toggle = GetComponent<Toggle>();
        toggle.isOn = GameSettings.soundOn;
        toggle.onValueChanged.AddListener(ToggleSound);
    }

    void ToggleSound(bool isOn)
    {
        GameSettings.soundOn = isOn;
    }
}
