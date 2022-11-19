using System.Collections.Generic;

public class Flow
{
    #region Singleton
    private static Flow instance;
    public static Flow Instance
    {
        get
        {
            if (instance == null)
                instance = new Flow();

            return instance;
        }

    }
    private Flow() { }
    #endregion

    List<IFlow> listManagers = new List<IFlow>();

    //List de Iflow et les managers s'inscrivent
    //Les singleton doivent etre reveilles par qlqun.
    public void PreInitialize()
    {
        //populer la liste des managers qui implementent IFlow
        listManagers.Add(ShipManager.Instance);
        listManagers.Add(BulletManager.Instance);
        listManagers.Add(EnemyManager.Instance);
        listManagers.Add(UIManager.Instance);

        
        foreach (var manager in listManagers)
        {
            manager.PreInitialize();
        }
    }

    public void Initialize()
    {
        //for loop qui appelle initialize sur tous les managers
        foreach (var manager in listManagers)
        {
            manager.Initialize();
        }
    }

    public void Refresh()
    {
        foreach (var manager in listManagers)
        {
            manager.Refresh();
        }
    }

    public void PhysicsRefresh()
    {
        foreach (var manager in listManagers)
        {
            manager.PhysicsRefresh();
        }
    }
}
