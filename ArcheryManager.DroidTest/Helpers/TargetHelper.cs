using NUnit.Framework;
using System.Linq;
using static ArcheryManager.CustomControls.TargetImage;

namespace ArcheryManager.DroidTest.Helpers
{
    public static class TargetHelper
    {
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

        private static void ShouldHaveIndoorCompoundButtons()
        {
            TestSetting.App.WaitForElement(c => c.Marked("buttonGrid").Child(0).Child(1).Child().Text("6"));
            TestSetting.App.WaitForElement(c => c.Marked("buttonGrid").Child(1).Child(1).Child().Text("7"));
            TestSetting.App.WaitForElement(c => c.Marked("buttonGrid").Child(2).Child(1).Child().Text("8"));
            TestSetting.App.WaitForElement(c => c.Marked("buttonGrid").Child(3).Child(1).Child().Text("9"));
            TestSetting.App.WaitForElement(c => c.Marked("buttonGrid").Child(5).Child(1).Child().Text("10"));
            TestSetting.App.WaitForElement(c => c.Marked("buttonGrid").Child(6).Child(1).Child().Text("M"));
        }

        private static void ShouldHaveIndoorRecurveButtons()
        {
            TestSetting.App.WaitForElement(c => c.Marked("buttonGrid").Child(0).Child(1).Child().Text("6"));
            TestSetting.App.WaitForElement(c => c.Marked("buttonGrid").Child(1).Child(1).Child().Text("7"));
            TestSetting.App.WaitForElement(c => c.Marked("buttonGrid").Child(2).Child(1).Child().Text("8"));
            TestSetting.App.WaitForElement(c => c.Marked("buttonGrid").Child(3).Child(1).Child().Text("9"));
            TestSetting.App.WaitForElement(c => c.Marked("buttonGrid").Child(4).Child(1).Child().Text("10"));
            TestSetting.App.WaitForElement(c => c.Marked("buttonGrid").Child(5).Child(1).Child().Text("M"));
        }

        private static void ShouldHaveFieldButtons()
        {
            TestSetting.App.WaitForElement(c => c.Marked("buttonGrid").Child(0).Child(1).Child().Text("1"));
            TestSetting.App.WaitForElement(c => c.Marked("buttonGrid").Child(1).Child(1).Child().Text("2"));
            TestSetting.App.WaitForElement(c => c.Marked("buttonGrid").Child(2).Child(1).Child().Text("3"));
            TestSetting.App.WaitForElement(c => c.Marked("buttonGrid").Child(3).Child(1).Child().Text("4"));
            TestSetting.App.WaitForElement(c => c.Marked("buttonGrid").Child(4).Child(1).Child().Text("5"));
            TestSetting.App.WaitForElement(c => c.Marked("buttonGrid").Child(5).Child(1).Child().Text("6"));
            TestSetting.App.WaitForElement(c => c.Marked("buttonGrid").Child(6).Child(1).Child().Text("M"));
        }

        private static void ShouldHaveEnglishButtons()
        {
            TestSetting.App.WaitForElement(c => c.Marked("buttonGrid").Child(0).Child(1).Child().Text("1"));
            TestSetting.App.WaitForElement(c => c.Marked("buttonGrid").Child(1).Child(1).Child().Text("2"));
            TestSetting.App.WaitForElement(c => c.Marked("buttonGrid").Child(2).Child(1).Child().Text("3"));
            TestSetting.App.WaitForElement(c => c.Marked("buttonGrid").Child(3).Child(1).Child().Text("4"));
            TestSetting.App.WaitForElement(c => c.Marked("buttonGrid").Child(4).Child(1).Child().Text("5"));
            TestSetting.App.WaitForElement(c => c.Marked("buttonGrid").Child(5).Child(1).Child().Text("6"));
            TestSetting.App.WaitForElement(c => c.Marked("buttonGrid").Child(6).Child(1).Child().Text("7"));
            TestSetting.App.WaitForElement(c => c.Marked("buttonGrid").Child(7).Child(1).Child().Text("8"));
            TestSetting.App.WaitForElement(c => c.Marked("buttonGrid").Child(8).Child(1).Child().Text("9"));
            TestSetting.App.WaitForElement(c => c.Marked("buttonGrid").Child(9).Child(1).Child().Text("10"));
            TestSetting.App.WaitForElement(c => c.Marked("buttonGrid").Child(10).Child(1).Child().Text("X10"));
            TestSetting.App.WaitForElement(c => c.Marked("buttonGrid").Child(11).Child(1).Child().Text("M"));
        }

        public static void ShouldHaveIndoorCompoundTarget()
        {
            Assert.AreEqual(639, TestSetting.App.WaitForElement("zone1").First().Rect.Height);
            Assert.AreEqual(530, TestSetting.App.WaitForElement("zone2").First().Rect.Height);
            Assert.AreEqual(421, TestSetting.App.WaitForElement("zone3").First().Rect.Height);
            Assert.AreEqual(312, TestSetting.App.WaitForElement("zone4").First().Rect.Height);
            Assert.AreEqual(203, TestSetting.App.WaitForElement("zone5").First().Rect.Height);
            Assert.AreEqual(94, TestSetting.App.WaitForElement("zone6").First().Rect.Height);

            Assert.AreEqual(639, TestSetting.App.WaitForElement("zone1").First().Rect.Width);
            Assert.AreEqual(530, TestSetting.App.WaitForElement("zone2").First().Rect.Width);
            Assert.AreEqual(421, TestSetting.App.WaitForElement("zone3").First().Rect.Width);
            Assert.AreEqual(312, TestSetting.App.WaitForElement("zone4").First().Rect.Width);
            Assert.AreEqual(203, TestSetting.App.WaitForElement("zone5").First().Rect.Width);
            Assert.AreEqual(94, TestSetting.App.WaitForElement("zone6").First().Rect.Width);
        }

        public static void ShouldHaveIndoorRecurveTarget()
        {
            Assert.AreEqual(621, TestSetting.App.WaitForElement("zone1").First().Rect.Height);
            Assert.AreEqual(494, TestSetting.App.WaitForElement("zone2").First().Rect.Height);
            Assert.AreEqual(367, TestSetting.App.WaitForElement("zone3").First().Rect.Height);
            Assert.AreEqual(239, TestSetting.App.WaitForElement("zone4").First().Rect.Height);
            Assert.AreEqual(112, TestSetting.App.WaitForElement("zone5").First().Rect.Height);

            Assert.AreEqual(621, TestSetting.App.WaitForElement("zone1").First().Rect.Width);
            Assert.AreEqual(494, TestSetting.App.WaitForElement("zone2").First().Rect.Width);
            Assert.AreEqual(367, TestSetting.App.WaitForElement("zone3").First().Rect.Width);
            Assert.AreEqual(239, TestSetting.App.WaitForElement("zone4").First().Rect.Width);
            Assert.AreEqual(112, TestSetting.App.WaitForElement("zone5").First().Rect.Width);
        }

        public static void ShouldHaveFieldTarget()
        {
            Assert.AreEqual(639, TestSetting.App.WaitForElement("zone1").First().Rect.Height);
            Assert.AreEqual(530, TestSetting.App.WaitForElement("zone2").First().Rect.Height);
            Assert.AreEqual(421, TestSetting.App.WaitForElement("zone3").First().Rect.Height);
            Assert.AreEqual(312, TestSetting.App.WaitForElement("zone4").First().Rect.Height);
            Assert.AreEqual(203, TestSetting.App.WaitForElement("zone5").First().Rect.Height);
            Assert.AreEqual(94, TestSetting.App.WaitForElement("zone6").First().Rect.Height);

            Assert.AreEqual(639, TestSetting.App.WaitForElement("zone1").First().Rect.Width);
            Assert.AreEqual(530, TestSetting.App.WaitForElement("zone2").First().Rect.Width);
            Assert.AreEqual(421, TestSetting.App.WaitForElement("zone3").First().Rect.Width);
            Assert.AreEqual(312, TestSetting.App.WaitForElement("zone4").First().Rect.Width);
            Assert.AreEqual(203, TestSetting.App.WaitForElement("zone5").First().Rect.Width);
            Assert.AreEqual(94, TestSetting.App.WaitForElement("zone6").First().Rect.Width);
        }

        public static void ShouldHaveEnglishTarget()
        {
            Assert.AreEqual(684, TestSetting.App.WaitForElement("zone1").First().Rect.Height);
            Assert.AreEqual(621, TestSetting.App.WaitForElement("zone2").First().Rect.Height);
            Assert.AreEqual(557, TestSetting.App.WaitForElement("zone3").First().Rect.Height);
            Assert.AreEqual(494, TestSetting.App.WaitForElement("zone4").First().Rect.Height);
            Assert.AreEqual(430, TestSetting.App.WaitForElement("zone5").First().Rect.Height);
            Assert.AreEqual(367, TestSetting.App.WaitForElement("zone6").First().Rect.Height);
            Assert.AreEqual(303, TestSetting.App.WaitForElement("zone7").First().Rect.Height);
            Assert.AreEqual(239, TestSetting.App.WaitForElement("zone8").First().Rect.Height);
            Assert.AreEqual(176, TestSetting.App.WaitForElement("zone9").First().Rect.Height);
            Assert.AreEqual(112, TestSetting.App.WaitForElement("zone10").First().Rect.Height);
            Assert.AreEqual(49, TestSetting.App.WaitForElement("zone11").First().Rect.Height);
            Assert.AreEqual(4, TestSetting.App.WaitForElement("center").First().Rect.Height);

            Assert.AreEqual(684, TestSetting.App.WaitForElement("zone1").First().Rect.Width);
            Assert.AreEqual(621, TestSetting.App.WaitForElement("zone2").First().Rect.Width);
            Assert.AreEqual(557, TestSetting.App.WaitForElement("zone3").First().Rect.Width);
            Assert.AreEqual(494, TestSetting.App.WaitForElement("zone4").First().Rect.Width);
            Assert.AreEqual(430, TestSetting.App.WaitForElement("zone5").First().Rect.Width);
            Assert.AreEqual(367, TestSetting.App.WaitForElement("zone6").First().Rect.Width);
            Assert.AreEqual(303, TestSetting.App.WaitForElement("zone7").First().Rect.Width);
            Assert.AreEqual(239, TestSetting.App.WaitForElement("zone8").First().Rect.Width);
            Assert.AreEqual(176, TestSetting.App.WaitForElement("zone9").First().Rect.Width);
            Assert.AreEqual(112, TestSetting.App.WaitForElement("zone10").First().Rect.Width);
            Assert.AreEqual(49, TestSetting.App.WaitForElement("zone11").First().Rect.Width);
            Assert.AreEqual(4, TestSetting.App.WaitForElement("center").First().Rect.Width);
        }
    }
}
