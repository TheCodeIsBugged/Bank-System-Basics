using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

// Bank has a name, vault, and a list of client.
[System.Serializable]
public class Bank
{
    public string bankName;
    public float bankVault;
    public Client[] bankClients;

    // Constructor
    public Bank(string name, float vault, Client[] clients)
    {
        this.bankName = name;
        this.bankVault = vault;
        this.bankClients = clients;
    }

    // Bank transactions: CheckBalance, Deposit, and Withdraw
    // Return the clientBalance
    public float CheckBalance(Client client)
    {
        return client.clientBalance;
    }

    // Increase the cash in bankVault and clientBalance, Reduce the player cashOnHand
    public void Deposit(Bank bank, Client client, Player player)
    {
        bank.bankVault += player.cashToDeposit;
        client.clientBalance += player.cashToDeposit;
        player.cashOnPlayer -= player.cashToDeposit;
    }

    // Reduce the cash in bankVault and clientBalance, Increase the player cashOnHand
    public void Withdraw(Bank bank, Client client, Player player)
    {
        bank.bankVault -= player.cashToWithdraw;
        client.clientBalance -= player.cashToWithdraw;
        player.cashOnPlayer += player.cashToWithdraw;
    }
}
