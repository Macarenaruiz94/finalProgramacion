using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventario : MonoBehaviour
{
    private bool InventoryEnabled;
    public GameObject Inventory;
    private int allSlots;
    private int enabledSolts;
    private GameObject[] slots;
    public GameObject slotContenedor;

    void Start()
    {
        allSlots = slotContenedor.transform.childCount;

        slots = new GameObject[allSlots];

        for (int i = 0; i < allSlots; i++)
        {
            slots[i] = slotContenedor.transform.GetChild(i).gameObject;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            InventoryEnabled = !InventoryEnabled;
        }
        if (InventoryEnabled == true)
        {
            Inventory.SetActive(true);
        } else
        {
            Inventory.SetActive(false);
        }
    }
}