using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CollectibleManager : MonoBehaviour
{
    public static CollectibleManager Instance;

    [System.Serializable]
    public class CollectibleUI
    {
        public string itemID;
        public Image iconImage;
        public TextMeshProUGUI countText;
        public int count = 0;
    }

    public List<CollectibleUI> collectiblesUI = new List<CollectibleUI>();

    private void Awake()
    {
        if (Instance == null) Instance = this;
        gameObject.SetActive(false);
    }

    public void CollectItem(string itemID, Sprite icon)
    {
        foreach (var c in collectiblesUI)
        {
            if (c.itemID == itemID)
            {
                c.count++;
                c.countText.text = c.count.ToString();
                return;
            }
        }

        Debug.LogWarning("Nie znaleziono UI dla itemID: " + itemID);
    }
    public bool UseItem(string itemID)
    {
        foreach (var c in collectiblesUI)
        {
            if (c.itemID == itemID && c.count > 0)
            {
                c.count--;
                c.countText.text = c.count.ToString();
                return true; // zu¿yto
            }
        }

        return false; // brak przedmiotu
    }
}
