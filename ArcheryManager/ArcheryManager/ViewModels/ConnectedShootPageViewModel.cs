using ArcheryManager.Controllers;
using ArcheryManager.Utils;
using System.Windows.Input;
using Xamarin.Forms;
using XLabs.Forms.Mvvm;
using ArcheryManager.Upjv;
using System.Linq;
using ArcheryGlobalResult.Upjv;
using System.Collections.Generic;
using System.Threading.Tasks;
using ArcheryManager.Entities;

namespace ArcheryManager.ViewModels
{
    public enum Letter { A, B, C, D }

    public class ConnectedShootPageViewModel : ViewModel
    {
        private readonly IUpjvScore Api;
        private readonly CounterManager CounterManager;
        private readonly TargetStarterController TargetStarterController;
        private List<JsonRegistered> _registereds;
        private JsonRegistered _selectedA;
        private JsonRegistered _selectedB;
        private JsonRegistered _selectedC;
        private JsonRegistered _selectedD;
        public ICommand ConnectCommand => new Command(Connect);

        public List<JsonRegistered> Registereds
        {
            get { return _registereds; }

            set
            {
                _registereds = value;
                NotifyPropertyChanged(nameof(Registereds));
            }
        }

        public JsonRegistered SelectedA
        {
            get { return _selectedA; }
            set
            {
                RemoveSameSelection(value);
                _selectedA = value;
                NotifyPropertyChanged(nameof(SelectedA));
            }
        }

        public JsonRegistered SelectedB
        {
            get { return _selectedB; }
            set
            {
                RemoveSameSelection(value);
                _selectedB = value;
                NotifyPropertyChanged(nameof(SelectedB));
            }
        }

        public JsonRegistered SelectedC
        {
            get { return _selectedC; }
            set
            {
                RemoveSameSelection(value);
                _selectedC = value;
                NotifyPropertyChanged(nameof(SelectedC));
            }
        }

        public JsonRegistered SelectedD
        {
            get { return _selectedD; }
            set
            {
                RemoveSameSelection(value);
                _selectedD = value;
                NotifyPropertyChanged(nameof(SelectedD));
            }
        }

        public Dictionary<Letter, JsonRegistered> SelectedsWithName => new Dictionary<Letter, JsonRegistered>()
        {
            {Letter.A, SelectedA },
            {Letter.B, SelectedB },
            {Letter.C, SelectedC },
            {Letter.D, SelectedD },
        };

        private IEnumerable<JsonRegistered> Selecteds => SelectedsWithName?.Values;

        public ConnectedShootPageViewModel(CounterManager counterManager, TargetStarterController starter, IUpjvScore api)
        {
            Api = api;
            TargetStarterController = starter;
            CounterManager = counterManager;

            InitRegistereds();
        }

        public virtual async Task<JsonShoot> ApiStartShootCall(string mail)
        {
            return await Api.StartShoot(mail);
        }

        public async void Connect()
        {
            var res = new Dictionary<string, CountedShoot>();
            foreach (var r in SelectedsWithName)
            {
                if (r.Value == null)
                    continue;

                var jsonShoot = await ApiStartShootCall(r.Value.Email);
                var shoot = ParseShoot(jsonShoot);

                res.Add(r.Key.ToString(), shoot);
            }

            var p = TargetStarterController.CreateMultiTargetPage(res);
            Navigation.PushAsync(p);
        }

        private void InitRegistereds()
        {
            Api.GetAll().ContinueWith(async t =>
            {
                var value = await t;
                value = value.OrderBy(r => r.ToString());
                Registereds = value.ToList();
            });
        }

        private CountedShoot ParseShoot(JsonShoot res)
        {
            var shoot = new CountedShoot()
            {
                ServerId = res.Id,
                HaveTarget = true,
                ArrowsCount = 3,
                TargetStyle = res.TargetStyle
            };
            return shoot;
        }

        private void RemoveSameSelection(JsonRegistered value)
        {
            if (SelectedA == value)
                SelectedA = null;
            if (SelectedB == value)
                SelectedB = null;
            if (SelectedC == value)
                SelectedC = null;
            if (SelectedD == value)
                SelectedD = null;
        }
    }
}
