using System.Threading;

namespace ETModel
{
    public sealed class TestRoom : Entity
    {
        public CancellationTokenSource waitCts;
    }
}