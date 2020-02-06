using System;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using NUnit.Framework;


namespace ParallelSpecFlowPlusRunner
{
    [Binding]
    public class FeatureSteps
    {

        public string username = "nathaniel.stokes@smartbear.com";
        RemoteWebDriver driverChrome;
        RemoteWebDriver driverFirefox;
        public string authkey = "u3c89dcfa8345a28";


        [Given(@"I navigate to the page ""(.*)""")]
        public void GivenINavigateToThePage(string p0)
        {
            var caps = new OpenQA.Selenium.RemoteSessionSettings();

            caps.AddMetadataSetting("name", "Parallel Chrome Test Example");
            caps.AddMetadataSetting("build", "1.0");
            caps.AddMetadataSetting("browserName", "Chrome");
            caps.AddMetadataSetting("version", "78x64");
            caps.AddMetadataSetting("platform", "Windows 10");
            caps.AddMetadataSetting("screenResolution", "1366x768");
            caps.AddMetadataSetting("record_video", "true");
            caps.AddMetadataSetting("username", username);
            caps.AddMetadataSetting("password", authkey);


            // Start the remote webdriver
            driverChrome = new RemoteWebDriver(new Uri("http://hub.crossbrowsertesting.com:80/wd/hub"), caps, TimeSpan.FromSeconds(180));

            // Navigate to site
            driverChrome.Manage().Window.Maximize();
            driverChrome.Navigate().GoToUrl(p0);
        }



        [Given(@"I see the page is loaded")]
        public void GivenISeeThePageIsLoaded()
        {
            Assert.AreEqual("Google", driverChrome.Title);
        }

        [When(@"I enter Search Keyword in the Search Text box")]
        public void WhenIEnterSearchKeywordInTheSearchTextBox()
        {
            string searchText = "Specflow";
            driverChrome.FindElement(By.Name("q")).SendKeys(searchText);
        }

        [When(@"I click on Search Button")]
        public void WhenIClickOnSearchButton()
        {

            driverChrome.FindElement(By.Name("btnK")).Click();
        }

        [Then(@"Search items shows the items related to SpecFlow")]
        public void ThenSearchItemsShowsTheItemsRelatedToSpecFlow()
        {

            Assert.AreEqual("SpecFlow - Binding Business Requirements to .NET Code", driverChrome.FindElement(By.XPath("//a/h3")).Text);
            driverChrome.Quit();
        }
        [Given(@"I navigate to the page ""(.*)"" with Firefox")]
        public void GivenINavigateToThePageWithFirefox(string p0)
        {
            var caps = new OpenQA.Selenium.RemoteSessionSettings();

            caps.AddMetadataSetting("name", "Parallel Firefox Test Example");
            caps.AddMetadataSetting("build", "1.0");
            caps.AddMetadataSetting("browserName", "Firefox");
            caps.AddMetadataSetting("version", "72x64");
            caps.AddMetadataSetting("platform", "Windows 10");
            caps.AddMetadataSetting("screenResolution", "1366x768");
            caps.AddMetadataSetting("record_video", "true");
            caps.AddMetadataSetting("username", username);
            caps.AddMetadataSetting("password", authkey);


            // Start the remote webdriver
            driverFirefox = new RemoteWebDriver(new Uri("http://hub.crossbrowsertesting.com:80/wd/hub"), caps, TimeSpan.FromSeconds(180));

            // Navigate to site
            driverFirefox.Manage().Window.Maximize();
            driverFirefox.Navigate().GoToUrl(p0);
        }

        [Given(@"I see the page is loaded with Firefox")]
        public void GivenISeeThePageIsLoadedWithFirefox()
        {
            Assert.AreEqual("Google", driverFirefox.Title);
        }

        [When(@"I enter Search Keyword in the Search Text box with Firefox")]
        public void WhenIEnterSearchKeywordInTheSearchTextBoxWithFirefox()
        {
            string searchText = "Specflow";
            driverFirefox.FindElement(By.Name("q")).SendKeys(searchText);
        }

        [When(@"I click on Search Button with Firefox")]
        public void WhenIClickOnSearchButtonWithFirefox()
        {
            driverFirefox.FindElement(By.Name("btnK")).Click();
        }

        [Then(@"Search items shows the items related to SpecFlow with Firefox")]
        public void ThenSearchItemsShowsTheItemsRelatedToSpecFlowWithFirefox()
        {

            Assert.AreEqual("SpecFlow - Binding Business Requirements to .NET Code", driverFirefox.FindElement(By.XPath("//a/h3")).Text);
            driverFirefox.Quit();
        }
    }
}
