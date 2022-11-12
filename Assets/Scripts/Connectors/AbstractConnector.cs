using UnityEngine;

public class AbstractConnector : MonoBehaviour, IConnector
{
    public virtual void Connect()
    {
        Debug.Log("Abstract class passage.");
    }
}
