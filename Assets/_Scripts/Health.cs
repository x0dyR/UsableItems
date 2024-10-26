using System;
using UnityEngine;

public class Health
{
    public Health(int healthAmount)
    {
        HealthAmount = healthAmount;
    }

    [SerializeField] public int HealthAmount { get; private set; }
}
