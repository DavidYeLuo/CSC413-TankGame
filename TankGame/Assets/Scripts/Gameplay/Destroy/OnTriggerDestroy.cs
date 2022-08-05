using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTriggerDestroy : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        Destroy(this.gameObject);
    }
}
