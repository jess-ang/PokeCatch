using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    static protected Inventory s_InventoryInstance;
    static public Inventory InventoryInstance { get { return s_InventoryInstance; } }

    public delegate void OnChange();
    public OnChange onChange;
    public int space = 10;
    public List<Item> items = new List<Item>();
    
    void Awake()
    {
        s_InventoryInstance = this;
    }
    public void Add(Item item)
    {
        if(items.Count < space)
        {
            items.Add(item);
            if(onChange != null)
            {
                onChange.Invoke();
            }
        }
        else
        {
            Debug.LogWarning("Espacio insuficiente!");
        }

    }

    public void Remove(Item item)
    {
        if(items.Contains(item))
        {
            items.Remove(item);
            if(onChange != null)
            {
                onChange.Invoke();
            }
        }
        else
        {
            Debug.LogWarning("Item no está en el invetario");
        }
    }

}
