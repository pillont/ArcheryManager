using System;
using Xamarin.Forms;

namespace ArcheryManager.Utils
{
    /// <summary>
    /// watcher to change view during rotation of the device
    /// </summary>
    public class ScreenRotationWatcher
    {
        /// <summary>
        /// last width watched
        /// </summary>
        private double lastWidth;

        /// <summary>
        /// last height watched
        /// </summary>
        private double lastHeight;

        /// <summary>
        /// callback to setup view in vertical device
        /// </summary>
        private Action<Size> setupViewForVerticalDevice;

        /// <summary>
        /// callback to setup view in Horizontal device
        /// </summary>
        private Action<Size> setupViewForHorizontalDevice;

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="setupGridForVerticalDevice">callback to setup view in vertical device</param>
        /// <param name="setupGridForHorizontalDevice">callback to setup view in Horizontal device</param>
        public ScreenRotationWatcher(Action<Size> setupGridForVerticalDevice, Action<Size> setupGridForHorizontalDevice)
        {
            this.setupViewForVerticalDevice = setupGridForVerticalDevice;
            this.setupViewForHorizontalDevice = setupGridForHorizontalDevice;
        }

        /// <summary>
        /// function to call in function "OnSizeAllocated" of a page
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public void UpdateView(double width, double height)
        {
            if (width != this.lastWidth || height != this.lastHeight)
            {
                this.lastWidth = width;
                this.lastHeight = height;
                var size = new Size(width, height);
                if (width < height)
                {
                    setupViewForVerticalDevice(size);
                }
                else
                {
                    setupViewForHorizontalDevice(size);
                }
            }
        }
    }
}
