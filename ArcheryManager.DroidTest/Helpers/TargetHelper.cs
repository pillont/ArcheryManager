using NUnit.Framework;
using System.Linq;
using static ArcheryManager.CustomControls.TargetImage;

namespace ArcheryManager.DroidTest.Helpers
{
    public static class TargetHelper
    {
        #region target

        public static void ShouldHaveEnglishTarget()
        {
            Assert.AreEqual(961, TestSetting.App.WaitForElement("zone1").First().Rect.Height);
            Assert.AreEqual(872, TestSetting.App.WaitForElement("zone2").First().Rect.Height);
            Assert.AreEqual(782, TestSetting.App.WaitForElement("zone3").First().Rect.Height);
            Assert.AreEqual(693, TestSetting.App.WaitForElement("zone4").First().Rect.Height);
            Assert.AreEqual(604, TestSetting.App.WaitForElement("zone5").First().Rect.Height);
            Assert.AreEqual(514, TestSetting.App.WaitForElement("zone6").First().Rect.Height);
            Assert.AreEqual(425, TestSetting.App.WaitForElement("zone7").First().Rect.Height);
            Assert.AreEqual(336, TestSetting.App.WaitForElement("zone8").First().Rect.Height);
            Assert.AreEqual(247, TestSetting.App.WaitForElement("zone9").First().Rect.Height);
            Assert.AreEqual(158, TestSetting.App.WaitForElement("zone10").First().Rect.Height);
            Assert.AreEqual(68, TestSetting.App.WaitForElement("zone11").First().Rect.Height);
            Assert.AreEqual(6, TestSetting.App.WaitForElement("center").First().Rect.Height);

            Assert.AreEqual(961, TestSetting.App.WaitForElement("zone1").First().Rect.Width);
            Assert.AreEqual(872, TestSetting.App.WaitForElement("zone2").First().Rect.Width);
            Assert.AreEqual(782, TestSetting.App.WaitForElement("zone3").First().Rect.Width);
            Assert.AreEqual(693, TestSetting.App.WaitForElement("zone4").First().Rect.Width);
            Assert.AreEqual(604, TestSetting.App.WaitForElement("zone5").First().Rect.Width);
            Assert.AreEqual(514, TestSetting.App.WaitForElement("zone6").First().Rect.Width);
            Assert.AreEqual(425, TestSetting.App.WaitForElement("zone7").First().Rect.Width);
            Assert.AreEqual(336, TestSetting.App.WaitForElement("zone8").First().Rect.Width);
            Assert.AreEqual(247, TestSetting.App.WaitForElement("zone9").First().Rect.Width);
            Assert.AreEqual(158, TestSetting.App.WaitForElement("zone10").First().Rect.Width);
            Assert.AreEqual(68, TestSetting.App.WaitForElement("zone11").First().Rect.Width);
            Assert.AreEqual(6, TestSetting.App.WaitForElement("center").First().Rect.Width);
        }

        public static void ShouldHaveFieldTarget()
        {
            Assert.AreEqual(897, TestSetting.App.WaitForElement("zone1").First().Rect.Height);
            Assert.AreEqual(744, TestSetting.App.WaitForElement("zone2").First().Rect.Height);
            Assert.AreEqual(591, TestSetting.App.WaitForElement("zone3").First().Rect.Height);
            Assert.AreEqual(438, TestSetting.App.WaitForElement("zone4").First().Rect.Height);
            Assert.AreEqual(285, TestSetting.App.WaitForElement("zone5").First().Rect.Height);
            Assert.AreEqual(132, TestSetting.App.WaitForElement("zone6").First().Rect.Height);

            Assert.AreEqual(897, TestSetting.App.WaitForElement("zone1").First().Rect.Width);
            Assert.AreEqual(744, TestSetting.App.WaitForElement("zone2").First().Rect.Width);
            Assert.AreEqual(591, TestSetting.App.WaitForElement("zone3").First().Rect.Width);
            Assert.AreEqual(438, TestSetting.App.WaitForElement("zone4").First().Rect.Width);
            Assert.AreEqual(285, TestSetting.App.WaitForElement("zone5").First().Rect.Width);
            Assert.AreEqual(132, TestSetting.App.WaitForElement("zone6").First().Rect.Width);
        }

        public static void ShouldHaveIndoorCompoundTarget()
        {
            Assert.AreEqual(897, TestSetting.App.WaitForElement("zone1").First().Rect.Height);
            Assert.AreEqual(744, TestSetting.App.WaitForElement("zone2").First().Rect.Height);
            Assert.AreEqual(591, TestSetting.App.WaitForElement("zone3").First().Rect.Height);
            Assert.AreEqual(438, TestSetting.App.WaitForElement("zone4").First().Rect.Height);
            Assert.AreEqual(285, TestSetting.App.WaitForElement("zone5").First().Rect.Height);
            Assert.AreEqual(132, TestSetting.App.WaitForElement("zone6").First().Rect.Height);

            Assert.AreEqual(897, TestSetting.App.WaitForElement("zone1").First().Rect.Width);
            Assert.AreEqual(744, TestSetting.App.WaitForElement("zone2").First().Rect.Width);
            Assert.AreEqual(591, TestSetting.App.WaitForElement("zone3").First().Rect.Width);
            Assert.AreEqual(438, TestSetting.App.WaitForElement("zone4").First().Rect.Width);
            Assert.AreEqual(285, TestSetting.App.WaitForElement("zone5").First().Rect.Width);
            Assert.AreEqual(132, TestSetting.App.WaitForElement("zone6").First().Rect.Width);
        }

        public static void ShouldHaveIndoorRecurveTarget()
        {
            Assert.AreEqual(872, TestSetting.App.WaitForElement("zone1").First().Rect.Height);
            Assert.AreEqual(693, TestSetting.App.WaitForElement("zone2").First().Rect.Height);
            Assert.AreEqual(514, TestSetting.App.WaitForElement("zone3").First().Rect.Height);
            Assert.AreEqual(336, TestSetting.App.WaitForElement("zone4").First().Rect.Height);
            Assert.AreEqual(158, TestSetting.App.WaitForElement("zone5").First().Rect.Height);

            Assert.AreEqual(872, TestSetting.App.WaitForElement("zone1").First().Rect.Width);
            Assert.AreEqual(693, TestSetting.App.WaitForElement("zone2").First().Rect.Width);
            Assert.AreEqual(514, TestSetting.App.WaitForElement("zone3").First().Rect.Width);
            Assert.AreEqual(336, TestSetting.App.WaitForElement("zone4").First().Rect.Width);
            Assert.AreEqual(158, TestSetting.App.WaitForElement("zone5").First().Rect.Width);
        }

        public static void ShouldHaveTarget(TargetStyle enumeration)
        {
            switch (enumeration)
            {
                case TargetStyle.EnglishTarget:
                    ShouldHaveEnglishTarget();
                    break;

                case TargetStyle.FieldTarget:
                    ShouldHaveFieldTarget();
                    break;

                case TargetStyle.IndoorRecurveTarget:
                    ShouldHaveIndoorRecurveTarget();
                    break;

                case TargetStyle.IndoorCompoundTarget:
                    ShouldHaveIndoorCompoundTarget();
                    break;

                default:
                    goto case TargetStyle.EnglishTarget;
            }
        }

        #endregion target

        #region buttons

        public static void ShouldHaveButton(TargetStyle enumeration)
        {
            switch (enumeration)
            {
                case TargetStyle.EnglishTarget:
                    ShouldHaveEnglishButtons();
                    break;

                case TargetStyle.FieldTarget:
                    ShouldHaveFieldButtons();
                    break;

                case TargetStyle.IndoorRecurveTarget:
                    ShouldHaveIndoorRecurveButtons();
                    break;

                case TargetStyle.IndoorCompoundTarget:
                    ShouldHaveIndoorCompoundButtons();
                    break;

                default:
                    goto case TargetStyle.EnglishTarget;
            }
        }

        private static void ShouldHaveEnglishButtons()
        {
            TestSetting.App.WaitForElement(c => c.Marked("buttonGrid").Child(11).Child().Child().Text("M"));
            TestSetting.App.WaitForElement(c => c.Marked("buttonGrid").Child(10).Child().Child().Text("1"));
            TestSetting.App.WaitForElement(c => c.Marked("buttonGrid").Child(9).Child().Child().Text("2"));
            TestSetting.App.WaitForElement(c => c.Marked("buttonGrid").Child(8).Child().Child().Text("3"));
            TestSetting.App.WaitForElement(c => c.Marked("buttonGrid").Child(7).Child().Child().Text("4"));
            TestSetting.App.WaitForElement(c => c.Marked("buttonGrid").Child(6).Child().Child().Text("5"));
            TestSetting.App.WaitForElement(c => c.Marked("buttonGrid").Child(5).Child().Child().Text("6"));
            TestSetting.App.WaitForElement(c => c.Marked("buttonGrid").Child(4).Child().Child().Text("7"));
            TestSetting.App.WaitForElement(c => c.Marked("buttonGrid").Child(3).Child().Child().Text("8"));
            TestSetting.App.WaitForElement(c => c.Marked("buttonGrid").Child(2).Child().Child().Text("9"));
            TestSetting.App.WaitForElement(c => c.Marked("buttonGrid").Child(1).Child().Child().Text("10"));
            TestSetting.App.WaitForElement(c => c.Marked("buttonGrid").Child(0).Child().Child().Text("X10"));
        }

        private static void ShouldHaveFieldButtons()
        {
            TestSetting.App.WaitForElement(c => c.Marked("buttonGrid").Child(6).Child().Child().Text("M"));
            TestSetting.App.WaitForElement(c => c.Marked("buttonGrid").Child(5).Child().Child().Text("1"));
            TestSetting.App.WaitForElement(c => c.Marked("buttonGrid").Child(4).Child().Child().Text("2"));
            TestSetting.App.WaitForElement(c => c.Marked("buttonGrid").Child(3).Child().Child().Text("3"));
            TestSetting.App.WaitForElement(c => c.Marked("buttonGrid").Child(2).Child().Child().Text("4"));
            TestSetting.App.WaitForElement(c => c.Marked("buttonGrid").Child(1).Child().Child().Text("5"));
            TestSetting.App.WaitForElement(c => c.Marked("buttonGrid").Child(0).Child().Child().Text("6"));
        }

        private static void ShouldHaveIndoorCompoundButtons()
        {
            TestSetting.App.WaitForElement(c => c.Marked("buttonGrid").Child(5).Child().Child().Text("M"));
            TestSetting.App.WaitForElement(c => c.Marked("buttonGrid").Child(4).Child().Child().Text("6"));
            TestSetting.App.WaitForElement(c => c.Marked("buttonGrid").Child(3).Child().Child().Text("7"));
            TestSetting.App.WaitForElement(c => c.Marked("buttonGrid").Child(2).Child().Child().Text("8"));
            TestSetting.App.WaitForElement(c => c.Marked("buttonGrid").Child(1).Child().Child().Text("9"));
            TestSetting.App.WaitForElement(c => c.Marked("buttonGrid").Child(0).Child().Child().Text("10"));
        }

        private static void ShouldHaveIndoorRecurveButtons()
        {
            TestSetting.App.WaitForElement(c => c.Marked("buttonGrid").Child(5).Child().Child().Text("M"));
            TestSetting.App.WaitForElement(c => c.Marked("buttonGrid").Child(4).Child().Child().Text("6"));
            TestSetting.App.WaitForElement(c => c.Marked("buttonGrid").Child(3).Child().Child().Text("7"));
            TestSetting.App.WaitForElement(c => c.Marked("buttonGrid").Child(2).Child().Child().Text("8"));
            TestSetting.App.WaitForElement(c => c.Marked("buttonGrid").Child(1).Child().Child().Text("9"));
            TestSetting.App.WaitForElement(c => c.Marked("buttonGrid").Child(0).Child().Child().Text("10"));
        }

        #endregion buttons
    }
}
