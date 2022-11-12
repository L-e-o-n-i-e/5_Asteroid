public class BulletManager : IFlow
{
    #region Singleton
    //SINGLETON! REMOVE MONOBEHAVIOR
    private static BulletManager instance;
    public static BulletManager Instance
    {
        get
        {
            if (instance == null)
                instance = new BulletManager();

            return instance;
        }

    }
    private BulletManager() { }
    #endregion

    public void PreInitialize()
    {
    }

    public void Initialize()
    {

    }
    
    public void PhysicsRefresh()
    {
    }

    public void EndGame()
    {
    }

    public void Refresh()
    {
    }
}