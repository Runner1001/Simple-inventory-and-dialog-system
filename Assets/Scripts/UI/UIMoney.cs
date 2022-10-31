using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIMoney : MonoBehaviour
{
    [SerializeField] private TMP_Text moneyCounter;

    void Start()
    {
        MoneyManager.OnMoneyChange += UpdateMoney;
        UpdateMoney();
    }

    void OnDestroy()
    {
        MoneyManager.OnMoneyChange -= UpdateMoney;
    }

    private void UpdateMoney()
    {
        moneyCounter.SetText(MoneyManager.MoneyCount.ToString());
    }
}
