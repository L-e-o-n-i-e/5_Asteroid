using UnityEngine;

public class ShipManager : IFlow
{
    #region Singleton
    private static ShipManager instance;
    public static ShipManager Instance
    {
        get
        {
            if (instance == null)
                instance = new ShipManager();

            return instance;
        }

    }
    private ShipManager() { }
    #endregion

    public GameObject shipPrefab;
    IFlow interfShip;

    public void PreInitialize()
    {
        Debug.Log("Je suis ship manager! HI! :" + shipPrefab);
        GameObject ship = GameObject.Instantiate(shipPrefab);
        interfShip = ship.GetComponent<IFlow>();
        interfShip.PreInitialize();


        ship.transform.position = Vector2.zero;
    }

    public void Initialize()
    {
        interfShip.Initialize();
    }

    public void Refresh()
    {
        interfShip.Refresh();
    }

    public void PhysicsRefresh()
    {
        interfShip.PhysicsRefresh();
    }

    public void EndGame()
    {
        interfShip.EndGame();
    }
}