using System.Collections;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager instance;
    public ArrayList inventory = new ArrayList();
    
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        } 
        else if (instance != this)
        {
            Destroy(this);
        }
        DontDestroyOnLoad(this);
    }
    
    public void Acquire(GameObject g)
    {
        inventory.Add(g);
    }
}
