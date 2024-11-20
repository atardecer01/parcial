using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeGenerator2 : MonoBehaviour
{
    public GameObject diamante;

    public float MinSpeed;
    public float MaxSpeed;
    public float currentSpeed;
    
    public float SpeedMultiplier;
    

    void Awake()
    {
        currentSpeed = MinSpeed;

        generateDiamante();
    }

    public void GenerateNextSpikeWihtGap2()
    {
        float randomWait = Random.Range(1f, 5f);
        Invoke("generateDiamante", randomWait);
    }

    void generateDiamante()
    {
        
        GameObject SpikeIns = Instantiate(diamante, transform.position, transform.rotation);
        SpikeIns.GetComponent<SpikeScript2>().spikeGenerator2 = this;
    }

    // Update is called once per frame
    void Update()
    {
        if(currentSpeed < MaxSpeed)
        {
            currentSpeed += SpeedMultiplier;
        }
    }
}
