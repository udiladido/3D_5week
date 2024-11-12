using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UI : MonoBehaviour
{
    public virtual void Close()
    {
        this.gameObject.SetActive(false);
    }
}