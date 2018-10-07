using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenUpgradeMenu : MonoBehaviour {

    public Text text;
    public List<Button> upgrades;

    public void OUM()
    {
        if (text.text == "Upgrades")
        {
            text.text = "Back";
            foreach(var item in upgrades)
            {
                item.gameObject.SetActive(true);
            }
        }
        else if (text.text == "Back")
        {
            text.text = "Upgrades";
            foreach (var item in upgrades)
            {
                item.gameObject.SetActive(false);
            }
        }
    }
}
