using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Reflection;

public class ShopItem : MonoBehaviour {

    public string itemName;
    public int itemPrice;
    bool bought;
    public Text priceText;
    public Image soldImage;

    public void Buy()
    {
        if (!bought)
        {
            if (PlayerPrefs.GetInt("Points") > itemPrice || PlayerPrefs.GetInt("Points") == itemPrice)
            {
                bought = true;
                GameManager.instance.GetType().GetField("has" + itemName).SetValue(GameManager.instance, true);

                int previousPoints = PlayerPrefs.GetInt("Points");
                PlayerPrefs.SetInt("Points", previousPoints - itemPrice);
                soldImage.enabled = true;
            }
        }
    }

    private void Start()
    {
        priceText = GetComponentInChildren<Text>();
        priceText.text = "x" + itemPrice.ToString();
        if ((bool)GameManager.instance.GetType().GetField("has" + itemName).GetValue(GameManager.instance) == true)
        {
            bought = true;
            soldImage.enabled = true;
        }
        else
        {
            soldImage.enabled = false;
        }

    }

}