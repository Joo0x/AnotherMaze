using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GemInv : MonoBehaviour
{
    public int GemNum { get; private set; }
    public UnityEvent<GemInv>OnGemCollected;

    public void GemCollected()
    {
        GemNum++;
        OnGemCollected.Invoke(this);
    }
}
