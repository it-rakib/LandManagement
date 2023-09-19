namespace Common.Service.CommonEntities
{
    public static class ErrorLevelExtensions
    {
        public static string GetString(this ConStrManager me)
        {
            switch (me)
            {
                case ConStrManager.Merchant:
                    return "merchConnectionString";
                case ConStrManager.HRM:
                    return "hrmsConnectionsString";
                case ConStrManager.Land:
                    return "landConnectionString";
                case ConStrManager.Auth:
                    return "authConnectionsString";
                default:
                    return "merchConnectionString";
            }
        }
    }
    public enum ConStrManager
    {
        Merchant,
        Land,
        HRM,
        Auth

    }
}
