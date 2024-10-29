using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySystem : MonoBehaviour
{
    public GameObject hand;
    public Transform itemHolder;
    private GameObject currentItem; // Þu an elde tutulan eþya
    private Rigidbody currentItemRigidbody; // Eþyanýn Rigidbody bileþeni
    private bool isItemHeld = false; // Eþya elde tutuluyor mu?

    private void Start()
    {
        currentItemRigidbody = null;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (!isItemHeld)
            {
                GameObject item = GetNearestItemWithTag("Item");
                if (item != null)
                {
                    AddItem(item);
                }
            }
            else
            {
                DropItem();
            }
        }

        if (isItemHeld)
        {
            currentItem.transform.position = itemHolder.position;
        }
    }

    public void AddItem(GameObject item)
    {
        if (!isItemHeld)
        {
            isItemHeld = true;
            currentItem = item;
            currentItem.transform.SetParent(itemHolder);
            currentItemRigidbody = currentItem.GetComponent<Rigidbody>();
            currentItemRigidbody.isKinematic = true;
            currentItem.SetActive(true);
        }
    }

    public void DropItem()
    {
        if (isItemHeld)
        {
            isItemHeld = false;
            currentItemRigidbody.isKinematic = false;
            currentItem.transform.SetParent(null);
            currentItem = null;
            currentItemRigidbody = null;
        }
    }

    private GameObject GetNearestItemWithTag(string tag)
    {
        GameObject[] items = GameObject.FindGameObjectsWithTag(tag);
        GameObject nearestItem = null;
        float minDistance = Mathf.Infinity;

        foreach (GameObject item in items)
        {
            float distance = Vector3.Distance(transform.position, item.transform.position);
            if (distance < minDistance)
            {
                minDistance = distance;
                nearestItem = item;
            }
        }

        return nearestItem;
    }
}
