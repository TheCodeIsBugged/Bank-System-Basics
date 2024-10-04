using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BankManager : MonoBehaviour
{
    private static BankManager instance;
    public static BankManager Instance
    {
        get { return instance; }
    }

    public Bank bank;
    public Client[] clients;

    private void Awake()
    {
        // Initialzie a singleton and avoid duplication
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        // Initialize the bank and list of client using constructor
        clients = new Client[1];
        clients[0] = new Client("Ed", 999f, 123);
        bank = new Bank("RCBC", 999999f, clients);
    }
}
