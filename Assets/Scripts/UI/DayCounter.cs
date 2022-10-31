using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DayCounter : MonoBehaviour
{
    private TMP_Text dayCounterText;
    private int dayCounterNumber = 1;

    void Start()
    {
        dayCounterText = GetComponent<TMP_Text>();
        Bed_OnTimeChange();
        Bed.OnTimeChange += Bed_OnTimeChange;
    }

    void OnDisable()
    {
        Bed.OnTimeChange -= Bed_OnTimeChange;
    }

    private void Bed_OnTimeChange()
    {
        dayCounterText.SetText($"Day {dayCounterNumber++}");
    }
}
