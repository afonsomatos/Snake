using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using UnityEngine.Events;

[RequireComponent(typeof(Dropdown))]
public class DifficultyDropdownController : MonoBehaviour {

    private Dropdown dropdown;

    void Start()
    {
        dropdown = GetComponent<Dropdown>();
        dropdown.value = (int) GameSettings.difficulty;
        dropdown.onValueChanged.AddListener(SetDifficulty);
    }

    void SetDifficulty(int value)
    {
        GameSettings.difficulty = (Difficulty)value;
    }
}
