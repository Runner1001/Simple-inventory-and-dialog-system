using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    public static event Action OnMoneyChange;
    public static int MoneyCount = 0;

    public static void ModifyMoney(int amount)
    {
        MoneyCount += amount;
        OnMoneyChange?.Invoke();
    }
}
