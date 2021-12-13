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

            if (slots[i].GetComponent<Slot>().item == null)
            {
                slots[i].GetComponent<Slot>().empty = true;
            }
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Item")
        {
            GameObject itemPickedUp = other.gameObject;

            Item item = itemPickedUp.GetComponent<Item>();

            AddItem(itemPickedUp, item.ID, item.type, item.description, item.icon);
        }
        
        void AddItem(GameObject itemObject, int itemID, string itemType, string itemDescrption, Sprite itemIcon)
        {
            for (int i = 0; i < allSlots; i++)
            {
                if (slots[i].GetComponent<Slot>().empty)
                {
                    itemObject.GetComponent<Item>().pickedUp = true;

                    slots[i].GetComponent<Slot>().item = itemObject;
                    slots[i].GetComponent<Slot>().ID = itemID;
                    slots[i].GetComponent<Slot>().type = itemType;
                    slots[i].GetComponent<Slot>().description = itemDescrption;
                    slots[i].GetComponent<Slot>().icon = itemIcon;

                    itemObject.transform.parent = slots[i].transform;
                    itemObject.SetActive(false);

                    slots[i].GetComponent<Slot>().UpdateSlot();

                    slots[i].GetComponent<Slot>().empty = false;
                }
                return;
            }
        }
    }
}