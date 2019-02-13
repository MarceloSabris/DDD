using BHN.Domain.EGifts.Dtos;

namespace BHN.Domain.Shared.Extensions
{
    public static class System
    {
        public static string ObterEntityId(this string entity)
        {
            if (entity.Contains("/"))
            {
                return entity.Substring(entity.LastIndexOf("/") + 1);
            }
            return null;
        }

        public static string ObterAccountId(this string entity)
        {
            if (entity.Contains("accountId="))
            {
                entity = entity.Substring(entity.IndexOf("accountId="));
                entity = entity.Replace("accountId=", "");
                return entity;
            }
            return null;
        }
    }
}