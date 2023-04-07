using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class coinhud : MonoBehaviour
{
    public int coinscol;
    public int coinsinscrene;
    public TMP_Text coindisplay;
    public raycastscript it;
    // Start is called before the first frame update
    void Start()
    {
        coindisplay.text = $"Coins {coinscol}/{coinsinscrene}";
    }

    public void coincollected()
    {
        coinscol++;
        coindisplay.text = $"Coins {coinscol}/{coinsinscrene}";

        if(coinscol == coinsinscrene)
        {
            it.opendoor = true;
        }
       
    }
}
