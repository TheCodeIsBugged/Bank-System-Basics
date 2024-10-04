using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BankTransaction : MonoBehaviour
{
    private Bank currentBank;
    private Player currentClient;
    private Client currentClientAccount;
    private bool inBank = false;
    private bool isClient = false;
    private bool isCorrectPin = false;

    private void Update()
    {
        // Check if the player is in range of the bankTransaction trigger
        if (inBank)
        {
            // Check if the playerPin matched the clientPin
            if (Input.GetKeyDown(KeyCode.Space))
            {
                VerifyCurrentClientPin();
            }

            // Verify that the player is a client and has a correct pin
            if (isClient && isCorrectPin)
            {
                // Call the CheckBalance method
                if (Input.GetKeyDown(KeyCode.C))
                {
                    CallCheckBalanceMethod();
                }
                // Call the Deposit method
                if (Input.GetKeyDown(KeyCode.X))
                {
                    CallDepositMethod();
                }
                // Call the Withdraw method
                if (Input.GetKeyDown(KeyCode.Z))
                {
                    CallWithdrawMethod();
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Set the currentBank
        currentBank = BankManager.Instance.bank;

        // Get the PlayerScript and set inBank to true
        if (other.CompareTag("Player"))
        {
            inBank = true;
            currentClient = other.GetComponent<Player>();
        }        

        // Check if the player has an existing account in the bank
        for (int i = 0; i < currentBank.bankClients.Length; i++)
        {
            if (currentClient.playerName == currentBank.bankClients[i].clientName)
            {
                isClient = true;
                currentClientAccount = currentBank.bankClients[i];
                Debug.Log("Client: True");
            }
            else
            {
                isClient = false;
                currentClientAccount = null;
                Debug.Log("Client: False");
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Set all the bank transactions to null upon exit
        currentBank = null;
        currentClient = null;
        currentClientAccount = null;
        inBank = false;
        isClient = false;
        isCorrectPin = false;
        Debug.Log("Transaction End.");
    }

    private void VerifyCurrentClientPin()
    {
        if (currentClient.playerPin == currentClientAccount.clientPin)
        {
            isCorrectPin = true;
            Debug.Log("Pin: Correct");
        }
        else
        {
            isCorrectPin = false;
            Debug.Log("Pin: Incorrect");
        }
    }

    private void CallCheckBalanceMethod()
    {
        // Return the clientBalance
        Debug.Log(currentBank.CheckBalance(currentClientAccount));
    }

    private void CallDepositMethod()
    {
        // Check if the player has enough cash
        if (currentClient.cashOnPlayer >= currentClient.cashToDeposit)
        {
            currentBank.Deposit(currentBank, currentClientAccount, currentClient);
        }
        else
        {
            Debug.Log("Insuficient Cash on Hand!");
        }
    }

    private void CallWithdrawMethod()
    {
        // Check if the bankVault or clientBalance has enough cash
        if (currentBank.bankVault >= currentClient.cashToWithdraw && currentClientAccount.clientBalance >= currentClient.cashToWithdraw)
        {
            currentBank.Withdraw(currentBank, currentClientAccount, currentClient);
        }
        else
        {
            Debug.Log("Insuficient Balance or Fund!");
        }
    }
}
