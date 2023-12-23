using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger_Area : MonoBehaviour
{
    [SerializeField] GameObject _nftparent2;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _nftparent2.SetActive(true);
        }
    }
}