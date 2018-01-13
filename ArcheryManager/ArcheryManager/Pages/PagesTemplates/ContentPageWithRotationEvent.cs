using System;
using Xamarin.Forms;

namespace ArcheryManager.Pages.PagesTemplates
{
    public class ContentPageWithRotationEvent : ContentPage
    {
        /// <summary>
        /// callback to setup view in Horizontal device
        /// </summary>
        public event Action<Size> HorizontalScreenRotation;

        public event Action<double, double> ScreenRotate;

        /// <summary>
        /// callback to setup view in vertical device
        /// </summary>
        public event Action<Size> VerticalScreenRotation;

        /// <summary>
        /// last height watched
        /// </summary>
        private double lastHeight;

        /// <summary>
        /// last width watched
        /// </summary>
        private double lastWidth;

        /// <summary>
        /// event when device rotate
        /// </summary>
        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);
            UpdateView(width, height);
        }

        /// <summary>
        /// function to call in function "OnSizeAllocated" of a page
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        private void UpdateView(double width, double height)
        {
            if (width != this.lastWidth || height != this.lastHeight)
            {
                this.lastWidth = width;
                this.lastHeight = height;
                var size = new Size(width, height);
                if (width < height)
                {
                    VerticalScreenRotation?.Invoke(size);
                }
                else
                {
                    HorizontalScreenRotation?.Invoke(size);
                }

                ScreenRotate?.Invoke(width, height);
            }
        }
    }
}
