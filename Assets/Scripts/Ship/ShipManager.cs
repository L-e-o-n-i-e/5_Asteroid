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
    GameObject ship;
    IFlow iflow;
    private int currentShipHp;
    private int STARTING_SHIP_HP = 3;

    public void PreInitialize()
    {
        currentShipHp = STARTING_SHIP_HP;
        SpawnShip();

        ship.transform.position = Vector2.zero;
    }

    public void Initialize()
    {
        iflow.Initialize();
    }

    public void Refresh()
    {
        iflow.Refresh();
    }

    public void PhysicsRefresh()
    {
        iflow.PhysicsRefresh();
    }

    public void EndGame()
    {
        iflow.EndGame();
    }

    public void SpawnShip()
    {
        ship = GameObject.Instantiate(shipPrefab);
        iflow = ship.GetComponent<IFlow>();
        iflow.PreInitialize();
    }

    public void ShipDied()
    {
        GameObject.Destroy(ship);
        
        currentShipHp--;
        UIManager.Instance.LoseOneLifeUnit(currentShipHp);

        if (currentShipHp > 0)
        {
            LevelManager.Instance.ResetSameLevel();
        }
        else
        {          
            currentShipHp = STARTING_SHIP_HP;
            LevelManager.Instance.startLevelEntry();
        }
    }

    public int getShipHp()
    {
        return currentShipHp;
    }
}