using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepController : MonoBehaviour
{
    [SerializeField] private Material[] standingColor;

    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<MeshRenderer>().material.color = standingColor[0].color;
    }

    public void ChangeColorFalse()
    {
        this.GetComponent<MeshRenderer>().material.color = standingColor[2].color;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "Bot")
        {
            this.GetComponent<MeshRenderer>().material.color = standingColor[1].color;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "Bot")
        {
            this.GetComponent<MeshRenderer>().material.color = standingColor[0].color;
        }
    }
}
