namespace CoreSystem.IdentitySystem
{
    public interface IProperty
    {
        void SetOwner(Owner owner);
        Owner GetOwner();
    }
}