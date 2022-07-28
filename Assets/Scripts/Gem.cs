
using UnityEngine;


public class Gem : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        GemInv gemcounter = other.GetComponent<GemInv>();
        if (gemcounter != null)
        {
            gemcounter.GemCollected();
            gameObject.SetActive(false);
        }

    }
}
