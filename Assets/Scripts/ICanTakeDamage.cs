namespace Assets.Scripts
{
    internal interface ICanTakeDamage
    {
        public int Health { get; set; }
        public void GetDamage(int damage);
    }
}