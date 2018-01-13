using ArcheryManager.Entities;
using ArcheryManager.Factories;
using ArcheryManager.Helpers;
using ArcheryManager.Interfaces;
using ArcheryManager.Pages;
using ArcheryManager.Resources;
using ArcheryManager.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using Xamarin.Forms;
using XLabs.Forms.Mvvm;

namespace ArcheryManager.Utils
{
    public class ScoreCounter : ViewModel
    {
        private const int BaseFlightNumber = 1;
        private const string DefaultScore = "0/0";
        private const string NewFlightText = "New Flight";
        private const string ScoreFormat = "{0}/{1}";
        private readonly CountedShoot CountedShoot;
        private readonly MessageManager MessageManager;
        private readonly ISQLiteConnectionManager SQLiteConnectionManager;

        public IEnumerable<Arrow> ArrowsShowed
        {
            get
            {
                if (CountedShoot.ShowAllArrows)
                {
                    return CountedShoot.Flights.SelectMany(f => f.Arrows);
                }
                else
                {
                    return CountedShoot.CurrentArrows;
                }
            }
        }

        public IEnumerable<Arrow> CurrentArrows
        {
            get
            {
                return CountedShoot.CurrentArrows;
            }
        }

        public string FlightScoreString
        {
            get
            {
                return ScoreString(CountedShoot.CurrentArrows);
            }
        }

        public IEnumerable<Arrow> PreviousArrow
        {
            get
            {
                return CountedShoot.Flights.Where(f => f.IsValidated).SelectMany(f => f.Arrows);
            }
        }

        #region properties

        public IEnumerable<Arrow> ArrowsSelected
        {
            get
            {
                return CountedShoot.CurrentArrows.Where(a => a.IsSelected);
            }
        }

        public int FlightNumber
        {
            get
            {
                return CountedShoot.Flights.Count - 1 + BaseFlightNumber;
            }
        }

        public string TotalScoreString
        {
            get
            {
                var arrows = CountedShoot.Flights.SelectMany(f => f.Arrows);
                return ScoreString(arrows);
            }
        }

        public void RemoveSelection()
        {
            var list = ArrowsSelected;
            RemoveArrows(list);
        }

        private string ScoreString(IEnumerable<Arrow> arrows)
        {
            if (arrows == null)
                return DefaultScore;

            int score = arrows.Select(a => ArrowSetting.ValueByScore(ArrowSetting.ScoreByIndex(a.Index))).Sum();
            int maxScore = arrows.Count() * ArrowSetting.MaxScore;
            return string.Format(ScoreFormat, score, maxScore);
        }

        #endregion properties

        private IArrowSetting ArrowSetting { get; set; }

        public ScoreCounter(CountedShoot shoot, ISQLiteConnectionManager dbSaver, MessageManager messageManager)
        {
            MessageManager = messageManager;
            SQLiteConnectionManager = dbSaver;

            CountedShoot = shoot;
            CountedShoot.PropertyChanged += CountedShoot_PropertyChanged;
            UpdateArrowSetting();

            shoot.Flights.CollectionChanged += FlightsSaved_CollectionChanged;
            PropertyChanged += ScoreCounter_PropertyChanged;
            OnPropertyChanged(new PropertyChangedEventArgs(nameof(CurrentArrows)));
        }

        public void FinishShoot()
        {
            bool haveMultiArrows = CountedShoot.CurrentArrows != null ? CountedShoot.CurrentArrows.Count > 0 : false;
            bool haveMultiFlights = CountedShoot.Flights.Count > 1;
            bool shootContainArrows = haveMultiArrows || haveMultiFlights;
            if (shootContainArrows)
            {
                CountedShoot.IsFinished = true;
                SQLiteConnectionManager.UpdateWithChildrenAsync(CountedShoot);

                var page = ResultPageFactory.Create(CountedShoot);
                MessagingCenterHelper.PopToRootAndPushPage(this, page);
            }
            else
            {
                MessagingCenterHelper.SendToast(this, ErrorResources.Error, ErrorResources.CantFinishEmptyCount, AppResources.OK);
            }
        }

        public void UpdateOrder()
        {
            IEnumerable<Arrow> orderedList;
            if (CountedShoot.IsDecreasingOrder)
            {
                orderedList = CountedShoot.CurrentArrows.OrderByDescending(a => a.Index).ToList();
            }
            else
            {
                orderedList = CountedShoot.CurrentArrows.OrderBy(a => a.NumberInFlight).ToList();
            }

            var arrows = CountedShoot.CurrentArrows;
            arrows.Clear();
            foreach (var a in orderedList)
            {
                arrows.Add(a);
            }
        }

        private Color ColorOf(Arrow a)
        {
            return ArrowSetting.ColorOf(ScoreOf(a));
        }

        private void CountedShoot_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(CountedShoot.IsDecreasingOrder))
            {
                UpdateOrder();
            }
            else if (e.PropertyName == nameof(CountedShoot.TargetStyle))
            {
                UpdateArrowSetting();
            }
        }

        private void CreateNewFlight()
        {
            var flight = CountedShoot.CreateNewFlight();
            OnPropertyChanged(new PropertyChangedEventArgs(nameof(CurrentArrows)));
            SaveInDBRecursively(flight);
        }

        private void FlightsSaved_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            var arg = new PropertyChangedEventArgs(nameof(FlightNumber));
            OnPropertyChanged(arg);
        }

        private void RemoveArrow(Arrow arrow)
        {
            CountedShoot.CurrentArrows.Remove(arrow);
            OnPropertyChanged(new PropertyChangedEventArgs(nameof(CurrentArrows)));
            RemoveInDBRecursively(arrow);
        }

        private void RemoveArrows(IEnumerable<Arrow> list)
        {
            //NOTE : toList to allow removed during browse by foreach
            var toRemove = list.ToList();
            foreach (var a in toRemove)
            {
                CountedShoot.CurrentArrows.Remove(a);
                RemoveInDBRecursively(a);
            }
            //NOTE : not use RemoveArrow to have only one call of PropertyChanged
            OnPropertyChanged(new PropertyChangedEventArgs(nameof(CurrentArrows)));
        }

        private void RemoveInDBRecursively(BaseEntity entity)
        {
            SQLiteConnectionManager?.DeleteRecursivelyAsync(entity);
        }

        private void SaveArrow(Arrow arrow)
        {
            CountedShoot.CurrentArrows.Add(arrow);
            OnPropertyChanged(new PropertyChangedEventArgs(nameof(CurrentArrows)));
            SaveInDBRecursively(arrow);
        }

        private void SaveInDBRecursively(BaseEntity entity)
        {
            SQLiteConnectionManager?.InsertOrReplaceWithChildrenRecursivelyAsync(entity);
        }

        private void ScoreCounter_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(CurrentArrows)
                || e.PropertyName == nameof(PreviousArrow))
            {
                var arg = new PropertyChangedEventArgs(nameof(TotalScoreString));
                OnPropertyChanged(arg);

                arg = new PropertyChangedEventArgs(nameof(FlightScoreString));
                OnPropertyChanged(arg);
            }
        }

        private string ScoreOf(Arrow a)
        {
            return ArrowSetting.ScoreByIndex(a.Index);
        }

        private void UpdateArrowSetting()
        {
            ArrowSetting = ArrowSettingFactory.Create(CountedShoot.TargetStyle);

            var arg = new PropertyChangedEventArgs(nameof(TotalScoreString));
            OnPropertyChanged(arg);

            arg = new PropertyChangedEventArgs(nameof(FlightScoreString));
            OnPropertyChanged(arg);
        }

        #region interaction

        public void AddArrowIfPossible(Arrow arrow)
        {
            if (MessageManager != null)
            {
                Action addArrow = () => AddArrow(arrow);
                MessageManager.AddArrowOrShowError(addArrow);
            }
            else
            {
                AddArrow(arrow);
            }
        }

        public void ClearArrows()
        {
            RemoveArrows(CountedShoot.CurrentArrows);
        }

        public void NewFlight()
        {
            var current = CountedShoot.CurrentFlight;
            if (current != null)
            {
                current.IsValidated = true;
                OnPropertyChanged(new PropertyChangedEventArgs(nameof(PreviousArrow)));
                UpdateInDB(current);
            }

            CreateNewFlight();
        }

        public void RemoveLastArrow()
        {
            if (CountedShoot.CurrentArrows.Count > 0)
            {
                var last = CountedShoot.CurrentArrows.LastOrDefault();
                if (last != null)
                {
                    RemoveArrow(last);
                }
            }
        }

        public void RestartCount()
        {
            RemoveInDBRecursively(CountedShoot);

            CountedShoot.Flights.Clear();
            NewFlight();
            OnPropertyChanged(new PropertyChangedEventArgs(nameof(CurrentArrows)));
            OnPropertyChanged(new PropertyChangedEventArgs(nameof(PreviousArrow)));

            SaveInDBRecursively(CountedShoot);
        }

        private void AddArrow(Arrow arrow)
        {
            bool canAddArrow = (!CountedShoot.HaveMaxArrowsCount) ||
                                CountedShoot.CurrentArrows.Count < CountedShoot.ArrowsCount;
            if (canAddArrow)
            {
                SaveArrow(arrow);

                UpdateOrder();
            }
        }

        #endregion interaction

        private void UpdateInDB(BaseEntity entity)
        {
            SQLiteConnectionManager?.UpdateWithChildrenAsync(entity);
        }

        private int ValueOf(Arrow a)
        {
            return ArrowSetting.ValueByScore(ScoreOf(a));
        }
    }
}
