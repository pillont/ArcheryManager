using ArcheryManager.Entities;
using ArcheryManager.Factories;
using ArcheryManager.Resources;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ArcheryManager.ModelViews
{
    public class ShootInList : BindableObject
    {
        public readonly CountedShoot Model;
        private const string ScoreSeparator = "/";

        private bool _isSelected;

        public string GroupName => CreationDate.ToString("dd MMMM yyyy");

        public bool IsSelected
        {
            get { return _isSelected; }
            set
            {
                _isSelected = value;
                OnPropertyChanged(nameof(IsSelected));
            }
        }

        public string ScoreString { get; private set; }
        public string ShootType => TranslateExtension.GetTextResource(Model.TargetStyle.ToString());
        public DateTime CreationDate => Model.CreationDate;
        public bool IsFinished => Model.IsFinished;
        public DateTime LastChangeDate => Model.LastChangeDate;

        public ShootInList(CountedShoot count)
        {
            Model = count;
            Task.Run(() => UpdateScore());
        }

        private void UpdateScore()
        {
            int max = 0;
            int total = 0;
            var arrowSetting = ArrowSettingFactory.Create(Model.TargetStyle);
            foreach (var a in Model.Flights.SelectMany(f => f.Arrows))
            {
                string score = arrowSetting.ScoreByIndex(a.Index);

                int value = arrowSetting.ValueByScore(score);
                total += value;
                max += arrowSetting.MaxScore;
            }

            ScoreString = total + ScoreSeparator + max;
            OnPropertyChanged(nameof(ScoreString));
        }
    }
}
