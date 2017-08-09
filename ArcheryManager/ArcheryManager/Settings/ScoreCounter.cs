using Xamarin.Forms;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using ArcheryManager.Interfaces;
using ArcheryManager.Utils;
using System.ComponentModel;
using System;
using ArcheryManager.Helpers;
using ArcheryManager.Models;

namespace ArcheryManager.Settings
{
    public class ScoreCounter : BindableObject
    {
        private const string NewFlightText = "New Flight";
        private const string ScoreFormat = "{0}/{1}";
        private const int BaseFlightNumber = 1;
        private readonly CounterMessageManager GeneralCounterManager;

        #region properties

        public string TotalScoreString
        {
            get
            {
                return ScoreString(Result.TotalScore, Result.AllArrows);
            }
        }

        private string ScoreString(int score, ObservableCollection<Arrow> arrows)
        {
            int maxScore = arrows.Count * ArrowSetting.MaxScore;
            return string.Format(ScoreFormat, score, maxScore);
        }

        public int FlightNumber
        {
            get
            {
                return Result.FlightsSaved.Count + BaseFlightNumber;
            }
        }

        #endregion properties

        private IArrowSetting ArrowSetting
        {
            get
            {
                return GeneralCounterSetting.ArrowSetting;
            }
        }

        private ScoreResult Result
        {
            get
            {
                return GeneralCounterSetting.ScoreResult;
            }
        }

        private CountSetting CountSetting
        {
            get
            {
                return GeneralCounterSetting.CountSetting;
            }
        }

        private readonly IGeneralCounterSetting GeneralCounterSetting;

        /// <summary>
        /// NOTE : mst have not null value in generalCounterSetting.ScoreResult
        /// else exception not understandable on the ctor :
        /// StackTrace	" ArcheryManager.Settings.ScoreCounter..ctor(IGeneralCounterSetting generalCounterSetting)
        /// TODO : understand why !
        /// </summary>
        /// <param name="generalCounterSetting"></param>
        public ScoreCounter(IGeneralCounterSetting generalCounterSetting)
        {
            GeneralCounterSetting = generalCounterSetting;
            Result.PropertyChanged += Result_PropertyChanged;
            Result.CurrentArrows.Clear();
            Result.AllArrows.Clear();
            Result.PreviousArrows.Clear();

            CountSetting.PropertyChanged += CountSetting_PropertyChanged;

            GeneralCounterManager = new CounterMessageManager(Result, CountSetting, App.NavigationPage);

            Result.FlightsSaved.CollectionChanged += FlightsSaved_CollectionChanged;
        }

        private void FlightsSaved_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            OnPropertyChanged(nameof(FlightNumber));
        }

        public ObservableCollection<Arrow> ArrowsShowed
        {
            get
            {
                if (CountSetting.ShowAllArrows)
                {
                    return Result.AllArrows;
                }
                else
                {
                    return Result.CurrentArrows;
                }
            }
        }

        public string FlightScoreString
        {
            get
            {
                return ScoreString(Result.FlightScore, Result.CurrentArrows);
            }
        }

        private void Result_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case nameof(ScoreResult.FlightScore):
                    OnPropertyChanged(nameof(FlightScoreString));
                    break;

                case nameof(ScoreResult.TotalScore):
                    OnPropertyChanged(nameof(TotalScoreString));
                    break;

                case nameof(ScoreResult.FlightsSaved):
                    OnPropertyChanged(nameof(FlightNumber));
                    break;
            }
        }

        private void CountSetting_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(CountSetting.IsDecreasingOrder))
            {
                UpdateOrder();
            }
        }

        #region update when arrows change

        public void UpdateOrder()
        {
            IEnumerable<Arrow> orderedList;
            if (CountSetting.IsDecreasingOrder)
            {
                orderedList = Result.CurrentArrows.OrderByDescending(a => a.Index).ToList();
            }
            else
            {
                orderedList = Result.CurrentArrows.OrderBy(a => a.NumberInFlight).ToList();
            }

            Result.CurrentArrows.Clear();
            foreach (var a in orderedList)
            {
                Result.CurrentArrows.Add(a);
            }
        }

        private void UpdatePreviousArrow()
        {
            var all = GetArrows(getCurrent: false);

            Result.PreviousArrows.Clear();

            foreach (var a in all)
            {
                Result.PreviousArrows.Add(a);
            }
        }

        private void UpdateTotal()
        {
            Result.FlightScore = 0;
            foreach (var a in Result.CurrentArrows)
            {
                Result.FlightScore += ValueOf(a);
            }

            Result.TotalScore = Result.LastTotal;
            Result.TotalScore += Result.FlightScore;
        }

        #endregion update when arrows change

        #region AllArrow

        private void UpdateAllArrow()
        {
            var all = GetArrows(getCurrent: true);

            Result.AllArrows.Clear();

            foreach (var a in all)
            {
                Result.AllArrows.Add(a);
            }
        }

        private List<Arrow> GetArrows(bool getCurrent)
        {
            List<Arrow> all;
            if (getCurrent)
            {
                all = new List<Arrow>(Result.CurrentArrows);
            }
            else
            {
                all = new List<Arrow>();
            }

            foreach (var f in Result.FlightsSaved)
            {
                all.AddRange(f);
            }

            return all;
        }

        #endregion AllArrow

        #region interaction

        public void RestartCount()
        {
            Result.LastTotal = 0;
            Result.FlightsSaved.Clear();
            Result.CurrentArrows.Clear();
            UpdatePreviousArrow();
            UpdateAllArrow();
            UpdateTotal();
            Result.OnArrowsChanged();
        }

        public void NewFlight()
        {
            Result.FlightsSaved.Add(new Flight(Result.CurrentArrows) { Number = Result.FlightsSaved.Count + 1 });

            Result.LastTotal += Result.FlightScore;
            Result.CurrentArrows.Clear();

            Result.FlightScore = 0;

            UpdateAllArrow();
            UpdatePreviousArrow();
            UpdateTotal();

            Result.OnArrowsChanged();
        }

        public void AddArrowIfPossible(Arrow arrow)
        {
            Action addArrow = () => AddArrow(arrow);
            GeneralCounterManager.AddArrowOrShowError(addArrow);
        }

        private void AddArrow(Arrow arrow)
        {
            bool canAddArrow = (!CountSetting.HaveMaxArrowsCount) ||
                                Result.CurrentArrows.Count < CountSetting.ArrowsCount;
            if (canAddArrow)
            {
                Result.CurrentArrows?.Add(arrow);
                UpdateOrder();

                UpdateAllArrow();
                UpdateTotal();

                Result.OnArrowsChanged();
            }
        }

        public void ClearArrows()
        {
            Result.CurrentArrows?.Clear();

            UpdateAllArrow();
            UpdateTotal();

            Result.OnArrowsChanged();
        }

        public void RemoveLastArrow()
        {
            if (Result.CurrentArrows.Count > 0)
            {
                Result.CurrentArrows.RemoveAt(Result.CurrentArrows.Count - 1);

                UpdateAllArrow();
                UpdateTotal();
                Result.OnArrowsChanged();
            }
        }

        #endregion interaction

        private string ScoreOf(Arrow a)
        {
            return ArrowSetting.ScoreByIndex(a.Index);
        }

        private int ValueOf(Arrow a)
        {
            return ArrowSetting.ValueByScore(ScoreOf(a));
        }

        private Color ColorOf(Arrow a)
        {
            return ArrowSetting.ColorOf(ScoreOf(a));
        }
    }
}
