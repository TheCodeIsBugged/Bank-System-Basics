using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Clients has name, account, balance, and security pin.
[System.Serializable]
public class Client
{
    public string clientName;
    public float clientBalance;
    public int clientPin;

    public Client(string name, float balance, int pin)
    {
        this.clientName = name;
        this.clientBalance = balance;
        this.clientPin = pin;
    }
}
