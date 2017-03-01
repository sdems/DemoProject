namespace PlugWine.Pricer
{
    public class Pricer:IPricer
    {
        public int Price(int superficie)
        {
            return superficie * 2;
        }
    }
}
