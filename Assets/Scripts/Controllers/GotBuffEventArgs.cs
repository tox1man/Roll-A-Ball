namespace RollABall
{
    public class GotBuffEventArgs
    {
        public int buffDuration { get; }

        public GotBuffEventArgs(int buffDuration)
        {
            this.buffDuration = buffDuration;
        }
    }
}