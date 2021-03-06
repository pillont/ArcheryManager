﻿using ArcheryManager.CustomControls;
using ArcheryManager.Entities;
using ArcheryManager.Helpers;
using ArcheryManager.Utils;
using System;
using System.Linq;
using Xamarin.Forms;

namespace ArcheryManager.Interactions.Behaviors
{
    public class MovableTargetBehavior : CustomBehavior<Target>
    {
        /// <summary>
        /// scale of the target during manipulation to set arrow
        /// </summary>
        public const double TargetScale = 1.35;

        /// <summary>
        /// rate of the target translation during manipulation to set arrow
        /// </summary>
        public const double TargetTranslationRate = -0.5;

        /// <summary>
        /// score counter where add new arrows
        /// </summary>
        private readonly ScoreCounter Counter;

        private readonly View GestureTarget;
        private readonly MessageManager MessageManager;
        private readonly CountedShoot Shoot;

        /// <summary>
        /// behavior to add interaction of pan on movable target
        /// </summary>
        /// <param name="counter">score counter where add new arrows</param>
        public MovableTargetBehavior(View gestureTarget, CounterManager manager, MessageManager messageManager)
        {
            MessageManager = messageManager;
            Counter = manager.Counter;
            GestureTarget = gestureTarget;

            Shoot = manager.CurrentShoot;
        }

        protected override void OnAttachedTo(Target bindable)
        {
            base.OnAttachedTo(bindable);
            GestureHelper.AddPanGestureOn(GestureTarget, OnPanUpdated);
        }

        private static void CancelInteraction(object sender)
        {
            var v = sender as View;
            var recognizer = v.GestureRecognizers.OfType<CustomPanGestureReconizer>().First();
            recognizer.CancelGesture();
        }

        private void CleanTranslation()
        {
            AssociatedObject.TargetGrid.TranslationX = 0;
            AssociatedObject.TargetGrid.TranslationY = 0;

            AssociatedObject.ArrowSetter.TranslationX = 0;
            AssociatedObject.ArrowSetter.TranslationY = 0;
        }

        /// <summary>
        /// function during end of the pan manipulations
        /// scale and translation reset / arrow setter not visible
        /// </summary>
        private void EndPanGesture(object sender, CustomPanUpdatedEventArgs e)
        {
            AssociatedObject.TargetGrid.Scale = 1;

            var position = new Point(AssociatedObject.ArrowSetter.TranslationX,
                                        AssociatedObject.ArrowSetter.TranslationY);

            var numberInFlight = Shoot.CurrentArrows.Count;
            var arrow = AssociatedObject.Factory.Create(position, numberInFlight, AssociatedObject.TargetSize);
            Counter.AddArrowIfPossible(arrow);

            AssociatedObject.TargetGrid.TranslationX = 0;
            AssociatedObject.TargetGrid.TranslationY = 0;

            AssociatedObject.ArrowSetter.TranslationX = 0;
            AssociatedObject.ArrowSetter.TranslationY = 0;

            AssociatedObject.ArrowSetter.IsVisible = false;
        }

        /// <summary>
        /// logic of the pan gesture
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnPanUpdated(object sender, CustomPanUpdatedEventArgs e)
        {
            switch (e.StatusType)
            {
                case GestureStatus.Started:
                    StartPanGesture(sender, e);
                    break;

                case GestureStatus.Running:
                    UpdatePanGesture(sender, e);
                    break;

                case GestureStatus.Canceled:
                case GestureStatus.Completed:
                    EndPanGesture(sender, e);
                    break;
            }
        }

        private void StartInteraction()
        {
            AssociatedObject.ArrowSetter.IsVisible = true;
            AssociatedObject.TargetGrid.Scale = TargetScale;
        }

        /// <summary>
        /// function during start of the pan munipulations
        /// scale on the target / arrow setter visible
        /// </summary>
        private void StartPanGesture(object sender, CustomPanUpdatedEventArgs e)
        {
            CleanTranslation();

            Action cancel = () => CancelInteraction(sender);
            MessageManager.AddArrowOrShowError(StartInteraction, cancel);
        }

        /// <summary>
        /// function during update of the pan munipulations
        /// translation update
        /// </summary>
        private void UpdatePanGesture(object sender, CustomPanUpdatedEventArgs e)
        {
            AssociatedObject.TargetGrid.TranslationX = e.TotalX * TargetTranslationRate;
            AssociatedObject.TargetGrid.TranslationY = e.TotalY * TargetTranslationRate;

            AssociatedObject.ArrowSetter.TranslationX = e.TotalX;
            AssociatedObject.ArrowSetter.TranslationY = e.TotalY;
        }
    }
}
