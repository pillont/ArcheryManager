using ArcheryManager.Entities;
using ArcheryManager.Services;

using Xamarin.Forms;

namespace ArcheryManager.Utils
{
    public class CounterManager
    {
        private CountedShoot _current;

        public ScoreCounter Counter { get; private set; }

        public CountedShoot CurrentShoot
        {
            get
            {
                return _current;
            }
            set
            {
                _current = value;
                MessageManager = new MessageManager(value);
                Counter = new ScoreCounter(value, DBSaver, MessageManager);
            }
        }

        public ISQLiteConnectionManager DBSaver { get; }
        public MessageManager MessageManager { get; private set; }

        public CounterManager(ISQLiteConnectionManager connection)
        {
            DBSaver = connection;
        }

        public CounterManager()
            : this(DependencyService.Get<ISqliteService>()?.GetAsyncConnection())
        {
        }
    }
}
