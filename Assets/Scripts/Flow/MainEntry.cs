using System.Collections.Generic;
using UnityEngine;

public class MainEntry : MonoBehaviour
{
    public List<AbstractConnector> connectors = new List<AbstractConnector>();

    private Flow flow; 
    
    private void Awake()
    {
        foreach (var connector in connectors)
        {
            connector.Connect();
        }

        flow = Flow.Instance;
        flow.PreInitialize();

    }

    private void Start()
    {
        flow.Initialize();
    }


    private void Update()
    {
        flow.Refresh();
    }

    private void FixedUpdate()
    {
        flow.PhysicsRefresh();
    }
}
