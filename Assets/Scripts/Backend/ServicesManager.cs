public static class ServicesManager
{
    private static readonly IAuthenticationManager m_AuthManager = new AuthenticationManager();
    private static readonly IDataAccessLayer m_DAL = new DataAccessLayer();

    public static IAuthenticationManager GetAuthManager()
    {
        return m_AuthManager;
    }

    public static IDataAccessLayer GetDataAccessLayer()
    {
        return m_DAL;
    }
}
