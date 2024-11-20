using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeScript2 : MonoBehaviour
{
    public SpikeGenerator2 spikeGenerator2;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * spikeGenerator2.currentSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("nextLine"))
        {
            spikeGenerator2.GenerateNextSpikeWihtGap2();
        }
        if(collision.gameObject.CompareTag("Finish"))
        {
            Destroy(this.gameObject);
        }
        if(collision.gameObject.CompareTag("Player"))
        {
            Destroy(this.gameObject);
        }
    }
}
