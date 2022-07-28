
using UnityEngine;
using TMPro;

public class GemUI : MonoBehaviour
{
    public TextMeshProUGUI _coinText;

    // Start is called before the first frame update
    void Start()
    {
        _coinText = GetComponent<TextMeshProUGUI>();
    }

    public void updateGemText(GemInv _geminv)
    {
        _coinText.text = _geminv.GemNum.ToString();
    }
}