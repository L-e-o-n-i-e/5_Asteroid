using UnityEngine;

public class ShipConnector : AbstractConnector
{
    //connecte les gameObjects(prefabs) avec les managers
    public GameObject shipPrefab;

    public override void Connect()
    {
        ShipManager.Instance.shipPrefab = shipPrefab;
    }
}