using PhysikeffirebaseBE.Interfaces;

namespace PhysikeffirebaseBE
{
    public static class ServicesManager
    {
        private static readonly  AuthenticationManager m_AuthManager = new AuthenticationManager();
        private static readonly IDataAccessLayer m_DAL = new DataAccessLayer();

        public static AuthenticationManager GetAuthManager()
        {
            return m_AuthManager;
        }

        public static IDataAccessLayer GetDataAccessLayer()
        {
            return m_DAL;
        }
    }
}
