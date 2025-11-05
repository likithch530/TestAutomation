//using System;
//using NUnit.Framework;
//using OpenQA.Selenium.Appium;
//using OpenQA.Selenium.Appium.Windows;

//namespace MyAutomationPractice.Tests.WindowsTests
//{
//        public class NotepadTests
//        {
//            private const string WinAppDriverUrl = "http://127.0.0.1:4723";
//            private const string NotepadAppId = "notepad.exe";
//            private WindowsDriver driver;

//            [SetUp]
//            public void Setup()
//            {
//                var options = new AppiumOptions();
//                options.AddAdditionalOption("app", NotepadAppId);
//                driver = new WindowsDriver(new Uri(WinAppDriverUrl), options);
//            }

//            [Test]
//            public void TypeTextInNotepad()
//            {
//                var editor = driver.FindElement("Edit");
//                editor.SendKeys("Hello WinAppDriver!");
//                Assert.That(editor.Text, Does.Contain("Hello"));
//            }

//            [TearDown]
//            public void Cleanup()
//            {
//                driver.Quit();
//            }
//        }
//    }
