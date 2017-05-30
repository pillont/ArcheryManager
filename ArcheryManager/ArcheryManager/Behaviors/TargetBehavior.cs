﻿using ArcheryManager.CustomControls;
using Xamarin.Forms;

namespace ArcheryManager.Behaviors
{
    public class TargetBehavior : CustomBehavior<CustomTarget>
    {
        /// <summary>
        /// scale of the target during manipulation to set arrow
        /// </summary>
        private const double TargetScale = 1.35;

        /// <summary>
        /// rate of the target translation during manipulation to set arrow
        /// </summary>
        private const double TargetTranslationRate = -0.3;

        protected override void OnAttachedTo(CustomTarget bindable)
        {
            base.OnAttachedTo(bindable);

            ApplyPanGesture(associatedObject.TargetGrid);
        }

        /// <summary>
        /// apply pan gesture on view to set new arrow
        /// </summary>
        /// <param name="v"></param>
        private void ApplyPanGesture(View v)
        {
            var panGesture = new PanGestureRecognizer();
            panGesture.PanUpdated += OnPanUpdated;
            v.GestureRecognizers.Add(panGesture);
        }

        /// <summary>
        /// logic of the pan gesture
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnPanUpdated(object sender, PanUpdatedEventArgs e)
        {
            switch (e.StatusType)
            {
                case GestureStatus.Started:
                    StartPanGesture();
                    break;

                case GestureStatus.Running:
                    UpdatePanGesture(e);
                    break;

                case GestureStatus.Canceled:
                case GestureStatus.Completed:

                    EndPanGesture();
                    break;
            }
        }

        /// <summary>
        /// function during end of the pan manipulations
        /// scale and translation reset / arrow setter not visible
        /// </summary>
        private void EndPanGesture()
        {
            associatedObject.TargetGrid.Scale = 1;

            var position = new Point(associatedObject.ArrowSetter.TranslationX,
                                        associatedObject.ArrowSetter.TranslationY);
            associatedObject.SetArrow(position);

            associatedObject.TargetGrid.TranslationX = 0;
            associatedObject.TargetGrid.TranslationY = 0;

            associatedObject.ArrowSetter.TranslationX = 0;
            associatedObject.ArrowSetter.TranslationY = 0;

            associatedObject.ArrowSetter.IsVisible = false;
        }

        /// <summary>
        /// function during update of the pan munipulations
        /// translation update
        /// </summary>
        private void UpdatePanGesture(PanUpdatedEventArgs e)
        {
            associatedObject.TargetGrid.TranslationX = e.TotalX * TargetTranslationRate;
            associatedObject.TargetGrid.TranslationY = e.TotalY * TargetTranslationRate;

            associatedObject.ArrowSetter.TranslationX = e.TotalX;
            associatedObject.ArrowSetter.TranslationY = e.TotalY;
        }

        /// <summary>
        /// function during start of the pan munipulations
        /// scale on the target / arrow setter visible
        /// </summary>
        private void StartPanGesture()
        {
            associatedObject.ArrowSetter.IsVisible = true;

            associatedObject.TargetGrid.Scale = TargetScale;
        }
    }
}
