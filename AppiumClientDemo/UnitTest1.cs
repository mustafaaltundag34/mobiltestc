using OpenQA.Selenium.Appium;
using NUnit.Framework;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Interfaces;

namespace AppiumClientDemo
{
    public class Tests
    {
        //private AppiumDriver<AndroidElement> _driver=null;
        private AppiumDriver<AppiumWebElement> _driver = null;


        [SetUp]
        public void Setup()
        {
            //var appPath = @"D:\Mobilapk\app-debug.apk";
            //var appPath = "com.example.myapplication";

            var driverOption = new AppiumOptions();
            driverOption.AddAdditionalCapability(MobileCapabilityType.PlatformName, "Android");
            driverOption.AddAdditionalCapability(MobileCapabilityType.DeviceName, "emulator-5554");
            //driverOption.AddAdditionalCapability(MobileCapabilityType.App, appPath);
            driverOption.AddAdditionalCapability("chromedriverExecutable", @"D:\Driver\chromedriver.exe");

            driverOption.AddAdditionalCapability(MobileCapabilityType.NoReset, true);
            driverOption.AddAdditionalCapability(MobileCapabilityType.FullReset, false);
            driverOption.AddAdditionalCapability("unicodeKeyboard", false);
            driverOption.AddAdditionalCapability("resetKeyboard", false);
            
            driverOption.AddAdditionalCapability(AndroidMobileCapabilityType.AppPackage, "com.example.myapplication");
            //driverOption.AddAdditionalCapability(AndroidMobileCapabilityType.AppPackage, "com.android.chrome");
            driverOption.AddAdditionalCapability(AndroidMobileCapabilityType.AppActivity, ".MainActivity");

            //_driver = new AndroidDriver<AndroidElement>(new Uri("http://localhost:4723/wd/hub"), driverOption(true));
            _driver = new AndroidDriver<AppiumWebElement>(new Uri("http://localhost:4723/wd/hub"), driverOption);

            //var contexts = ((IContextAware)_driver).Contexts;
            //string webviewContext = null;
            //for (var i = 0; i < contexts.Count; i++)
            //{
            //    Console.WriteLine(contexts[i]);
            //    if (contexts[i].Contains("WEBVIEW"))
            //    {
            //        webviewContext = contexts[i];
            //        break;
            //    }
            //}
            //((IContextAware)_driver).Context = webviewContext;

            int i = 3000;//Bekleme Süresi
            TestContext.Progress.WriteLine("Uygulama Basladi..");
            TestContext.Progress.WriteLine(i/1000+" Saniye Bekleniyor.....");
            Thread.Sleep(i);
            _driver.FindElementById("com.example.myapplication:id/button_first").Click();
            Thread.Sleep(i);
            _driver.FindElementByXPath("//android.widget.ImageView[@content-desc='More options']").Click();
            TestContext.Progress.WriteLine("Uygulama Kapaniyor..");
            Thread.Sleep(i);
            _driver.Quit();

        }


        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}