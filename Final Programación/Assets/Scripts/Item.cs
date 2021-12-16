using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public int ID;
    public string type;
    public string description;
    public Sprite icon;

    [HideInInspector]
    public bool pickedUp;

    [HideInInspector]
    public bool equiped;

    [HideInInspector]
    public GameObject itemManager;

    [HideInInspector]
    public GameObject manager;

    public bool playerArma;

    private void Start()
    {
        itemManager = GameObject.FindWithTag("itemManager");

        if (playerArma)
        {
            int allarma = itemManager.transform.childCount;
            for (int i = 0; i < allarma; i++)
            {
                if (itemManager.transform.GetChild(i).gameObject.GetComponent<Item>().ID == ID)
                {
                    manager = itemManager.transform.GetChild(i).gameObject;
                }
            }
        }
    }


    private void Update()
    {
        if (equiped)
        {
            if (Input.GetKeyDown(KeyCode.U))
            {
                equiped = false;
            }
            if (equiped == false)
            {
                gameObject.SetActive(false);
            }
        }
    }

    public void ItemUsage()
    {
        if (type == "Info")
        {
            manager.SetActive(true);
            manager.GetComponent<Item>().equiped = true;
        }
    }
}
