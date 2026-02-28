using TMPro;
using UnityEngine;

public class DisplayScript : MonoBehaviour
{
    public GameObject inventoryManager;
    private InventoryManager im;
    private TextMeshProUGUI tmp;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        inventoryManager = GameObject.Find("Inventory Manager");
        im = inventoryManager.GetComponent<InventoryManager>();
        tmp = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        tmp.text = "";
        foreach (GameObject g in im.inventory)
        {
            tmp.text += g.name + "\n";
        }
    }
}
