using TMPro;
using UnityEngine;

public class FireCharges : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public TMP_Text textoUI;

    public void UpdateScore(int charges)
    {
        textoUI.text = "x" + charges;
    }
}
