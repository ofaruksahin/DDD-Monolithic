namespace EShop.Domain.Core.Enumerations
{
    public class EnumStatus : Enumeration
    {
        public static EnumStatus Passive = new EnumStatus(1, "Pasif");
        public static EnumStatus Active = new EnumStatus(2, "Aktif");

        public EnumStatus(int id, string name) : base(id, name)
        {
        }
    }
}