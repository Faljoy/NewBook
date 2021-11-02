using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System;
using OpenQA.Selenium.Support.UI;
using Keys = OpenQA.Selenium.Keys;
using System.Threading;
using SeleniumExtras.WaitHelpers;
using System.Collections.Generic;

namespace newbookmodel
{
    public class Tests
    {
        IWebDriver driver;
        Actions action;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            action = new Actions(driver);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://newbookmodels.com/");
        }

        [Test]
        public void Registration()
        {
            IWebElement buttonSignUp = driver.FindElement(By.CssSelector("[class='Navbar__signUp--12ZDV']"));
            buttonSignUp.Click();
            IWebElement buttonFirstName = driver.FindElement(By.CssSelector("[name = 'first_name']"));
            buttonFirstName.SendKeys("Di");
            IWebElement buttonLasttName = driver.FindElement(By.CssSelector("[name = 'last_name']"));
            buttonLasttName.SendKeys("Di");
            DateTime dataTime = new DateTime();
            dataTime = DateTime.Now;
            string name = dataTime.ToString();
            name = name.Replace(".", "");
            name = name.Replace(" ", "");
            name = name.Replace(":", "");
            name = "newMail" + name + "@test.com";
            IWebElement buttonEmail = driver.FindElement(By.CssSelector("[name='email']"));
            buttonEmail.SendKeys(name);
            IWebElement buttonPassword = driver.FindElement(By.CssSelector("[name='password']"));
            buttonPassword.SendKeys("1234567890Qe_d");
            IWebElement buttonConfirmPassword = driver.FindElement(By.CssSelector("[name='password_confirm']"));
            buttonConfirmPassword.SendKeys("1234567890Qe_d");
            IWebElement buttonPhone = driver.FindElement(By.CssSelector("[name='phone_number']"));
            buttonPhone.SendKeys("1234123123");
            IWebElement buttonNext = driver.FindElement(By.CssSelector("[type='submit']"));
            buttonNext.Click();
            IWebElement buttonCompanyName = driver.FindElement(By.CssSelector("[name='company_name']"));
            buttonCompanyName.SendKeys("MyComp");
            IWebElement buttonCompanyWedSite = driver.FindElement(By.CssSelector("[name='company_website']"));
            buttonCompanyWedSite.SendKeys("mynewcomp.com");
            IWebElement buttonAdress = driver.FindElement(By.CssSelector("[name='location']"));
            buttonAdress.SendKeys("3435 Wilshire Boulevard, Los Angeles, CA, USA");
            Thread.Sleep(1500);
            buttonAdress.SendKeys(Keys.ArrowDown);
            Thread.Sleep(500);
            buttonAdress.SendKeys(Keys.Enter);
            IWebElement buttonIndustry = driver.FindElement(By.CssSelector("[name='industry']"));
            buttonIndustry.Click();
            IWebElement buttonIndustryChose = driver.FindElement(By.XPath("/html/body/nb-app/nb-signup-company/common-react-bridge/div/div[2]/" +
                "div/section/section/div/form/section/section/div/div[2]/section/div/section/div[3]/div[1]/div/div[1]/div[2]/div[1]/span"));
            buttonIndustryChose.Click();
            driver.FindElement(By.XPath("/html/body/nb-app/nb-signup-company/common-react-bridge/div/div[2]/div/section/section/div/form/section" +
                "/section/div/div[2]/section/div/section/div[3]/div[1]/div/div[1]/div[2]/div[1]/span[text()='Advertising']"));
            buttonIndustry.SendKeys(OpenQA.Selenium.Keys.Down);
            buttonIndustry.SendKeys(OpenQA.Selenium.Keys.Return);
            IWebElement buttonFinish = driver.FindElement(By.CssSelector("[type='submit']"));
            buttonFinish.Click();
            Assert.Pass();
        }

        [Test]
        public void CheckInvalidMailInRegistration()
        {
            IWebElement buttonSignUp = driver.FindElement(By.CssSelector("[class='Navbar__signUp--12ZDV']"));
            buttonSignUp.Click();
            IWebElement buttonFirstName = driver.FindElement(By.CssSelector("[name = 'first_name']"));
            buttonFirstName.SendKeys("Di");
            IWebElement buttonLasttName = driver.FindElement(By.CssSelector("[name = 'last_name']"));
            buttonLasttName.SendKeys("Di");
            string startUrl = driver.Url;
            DateTime dataTime = new DateTime();
            dataTime = DateTime.Now;
            string name = dataTime.ToString();
            name = name.Replace(".", "");
            name = name.Replace(" ", "");
            name = name.Replace(":", "");
            name = "newMail" + name;
            IWebElement buttonEmail = driver.FindElement(By.CssSelector("[name='email']"));
            buttonEmail.SendKeys(name);
            IWebElement buttonPassword = driver.FindElement(By.CssSelector("[name='password']"));
            buttonPassword.SendKeys("1234567890Qe_d");
            IWebElement buttonConfirmPassword = driver.FindElement(By.CssSelector("[name='password_confirm']"));
            buttonConfirmPassword.SendKeys("1234567890Qe_d");
            IWebElement buttonPhone = driver.FindElement(By.CssSelector("[name='phone_number']"));
            buttonPhone.SendKeys("1234123123");
            IWebElement buttonNext = driver.FindElement(By.CssSelector("[type='submit']"));
            buttonNext.Click();
            string endtUrl = driver.Url;
            Assert.AreEqual(startUrl,endtUrl);
        }

        [Test]
        public void CheckInvalidConfirmPassInRegistration()
        {
            IWebElement buttonSignUp = driver.FindElement(By.CssSelector("[class='Navbar__signUp--12ZDV']"));
            buttonSignUp.Click();
            IWebElement buttonFirstName = driver.FindElement(By.CssSelector("[name = 'first_name']"));
            buttonFirstName.SendKeys("Di");
            IWebElement buttonLasttName = driver.FindElement(By.CssSelector("[name = 'last_name']"));
            buttonLasttName.SendKeys("Di");
            string starttUrl = driver.Url;
            DateTime dataTime = new DateTime();
            dataTime = DateTime.Now;
            string name = dataTime.ToString();
            name = name.Replace(".", "");
            name = name.Replace(" ", "");
            name = name.Replace(":", "");
            name = "newMail" + name + "@test.com";
            IWebElement buttonEmail = driver.FindElement(By.CssSelector("[name='email']"));
            buttonEmail.SendKeys(name);
            IWebElement buttonPassword = driver.FindElement(By.CssSelector("[name='password']"));
            buttonPassword.SendKeys("1234567890Qe_d");
            IWebElement buttonConfirmPassword = driver.FindElement(By.CssSelector("[name='password_confirm']"));
            buttonConfirmPassword.SendKeys("1234dff567890Qe_d");
            IWebElement buttonPhone = driver.FindElement(By.CssSelector("[name='phone_number']"));
            buttonPhone.SendKeys("1234123123");
            IWebElement buttonNext = driver.FindElement(By.CssSelector("[type='submit']"));
            buttonNext.Click();
            string endtUrl = driver.Url;
            Assert.AreEqual(starttUrl,endtUrl);
        }

        [Test]
        public void CheckInvalidModileInRegistration()
        {
            IWebElement buttonSignUp = driver.FindElement(By.CssSelector("[class='Navbar__signUp--12ZDV']"));
            buttonSignUp.Click();
            IWebElement buttonFirstName = driver.FindElement(By.CssSelector("[name = 'first_name']"));
            buttonFirstName.SendKeys("Di");
            IWebElement buttonLasttName = driver.FindElement(By.CssSelector("[name = 'last_name']"));
            buttonLasttName.SendKeys("Di");
            string starttUrl = driver.Url;
            DateTime dataTime = new DateTime();
            dataTime = DateTime.Now;
            string name = dataTime.ToString();
            name = name.Replace(".", "");
            name = name.Replace(" ", "");
            name = name.Replace(":", "");
            name = "newMail" + name + "@test.com";
            IWebElement buttonEmail = driver.FindElement(By.CssSelector("[name='email']"));
            buttonEmail.SendKeys(name);
            IWebElement buttonPassword = driver.FindElement(By.CssSelector("[name='password']"));
            buttonPassword.SendKeys("1234567890Qe_d");
            IWebElement buttonConfirmPassword = driver.FindElement(By.CssSelector("[name='password_confirm']"));
            buttonConfirmPassword.SendKeys("1234567890Qe_d");
            IWebElement buttonPhone = driver.FindElement(By.CssSelector("[name='phone_number']"));
            buttonPhone.SendKeys("12341223");
            IWebElement buttonNext = driver.FindElement(By.CssSelector("[type='submit']"));
            buttonNext.Click();
            string endtUrl = driver.Url;
            Assert.AreEqual(starttUrl, endtUrl);
        }

        [Test]
        public void CheckEmptyFirstNameInRegistration()
        {
            IWebElement buttonSignUp = driver.FindElement(By.CssSelector("[class='Navbar__signUp--12ZDV']"));
            buttonSignUp.Click();
            IWebElement buttonFirstName = driver.FindElement(By.CssSelector("[name = 'first_name']"));
            buttonFirstName.SendKeys("");
            IWebElement buttonLasttName = driver.FindElement(By.CssSelector("[name = 'last_name']"));
            buttonLasttName.SendKeys("Di");
            string starttUrl = driver.Url;
            DateTime dataTime = new DateTime();
            dataTime = DateTime.Now;
            string name = dataTime.ToString();
            name = name.Replace(".", "");
            name = name.Replace(" ", "");
            name = name.Replace(":", "");
            name = "newMail" + name + "@test.com";
            IWebElement buttonEmail = driver.FindElement(By.CssSelector("[name='email']"));
            buttonEmail.SendKeys(name);
            IWebElement buttonPassword = driver.FindElement(By.CssSelector("[name='password']"));
            buttonPassword.SendKeys("1234567890Qe_d");
            IWebElement buttonConfirmPassword = driver.FindElement(By.CssSelector("[name='password_confirm']"));
            buttonConfirmPassword.SendKeys("1234567890Qe_d");
            IWebElement buttonPhone = driver.FindElement(By.CssSelector("[name='phone_number']"));
            buttonPhone.SendKeys("12341223");
            IWebElement buttonNext = driver.FindElement(By.CssSelector("[type='submit']"));
            buttonNext.Click();
            string endtUrl = driver.Url;
            Assert.AreEqual(starttUrl, endtUrl);
        }

        [Test]
        public void CheckEmptyLastNameInRegistration()
        {
            IWebElement buttonSignUp = driver.FindElement(By.CssSelector("[class='Navbar__signUp--12ZDV']"));
            buttonSignUp.Click();
            IWebElement buttonFirstName = driver.FindElement(By.CssSelector("[name = 'first_name']"));
            buttonFirstName.SendKeys("Di");
            IWebElement buttonLasttName = driver.FindElement(By.CssSelector("[name = 'last_name']"));
            buttonLasttName.SendKeys("");
            string starttUrl = driver.Url;
            DateTime dataTime = new DateTime();
            dataTime = DateTime.Now;
            string name = dataTime.ToString();
            name = name.Replace(".", "");
            name = name.Replace(" ", "");
            name = name.Replace(":", "");
            name = "newMail" + name + "@test.com";
            IWebElement buttonEmail = driver.FindElement(By.CssSelector("[name='email']"));
            buttonEmail.SendKeys(name);
            IWebElement buttonPassword = driver.FindElement(By.CssSelector("[name='password']"));
            buttonPassword.SendKeys("1234567890Qe_d");
            IWebElement buttonConfirmPassword = driver.FindElement(By.CssSelector("[name='password_confirm']"));
            buttonConfirmPassword.SendKeys("1234567890Qe_d");
            IWebElement buttonPhone = driver.FindElement(By.CssSelector("[name='phone_number']"));
            buttonPhone.SendKeys("12341223");
            IWebElement buttonNext = driver.FindElement(By.CssSelector("[type='submit']"));
            buttonNext.Click();
            string endtUrl = driver.Url;
            Assert.AreEqual(starttUrl, endtUrl);
        }

        [Test]
        public void CheckInvalidAddressInRegistration()
        {
            IWebElement buttonSignUp = driver.FindElement(By.CssSelector("[class='Navbar__signUp--12ZDV']"));
            buttonSignUp.Click();
            IWebElement buttonFirstName = driver.FindElement(By.CssSelector("[name = 'first_name']"));
            buttonFirstName.SendKeys("Di");
            IWebElement buttonLasttName = driver.FindElement(By.CssSelector("[name = 'last_name']"));
            buttonLasttName.SendKeys("Di");
            DateTime dataTime = new DateTime();
            dataTime = DateTime.Now;
            string name = dataTime.ToString();
            name = name.Replace(".", "");
            name = name.Replace(" ", "");
            name = name.Replace(":", "");
            name = "newMail" + name + "@test.com";
            IWebElement buttonEmail = driver.FindElement(By.CssSelector("[name='email']"));
            buttonEmail.SendKeys(name);
            IWebElement buttonPassword = driver.FindElement(By.CssSelector("[name='password']"));
            buttonPassword.SendKeys("1234567890Qe_d");
            IWebElement buttonConfirmPassword = driver.FindElement(By.CssSelector("[name='password_confirm']"));
            buttonConfirmPassword.SendKeys("1234567890Qe_d");
            IWebElement buttonPhone = driver.FindElement(By.CssSelector("[name='phone_number']"));
            buttonPhone.SendKeys("1234123123");
            IWebElement buttonNext = driver.FindElement(By.CssSelector("[type='submit']"));
            buttonNext.Click();
            IWebElement buttonCompanyName = driver.FindElement(By.CssSelector("[name='company_name']"));
            buttonCompanyName.SendKeys("MyComp");
            IWebElement buttonCompanyWedSite = driver.FindElement(By.CssSelector("[name='company_website']"));
            buttonCompanyWedSite.SendKeys("mynewcomp.com");
            string startUrl = driver.Url;
            IWebElement buttonAdress = driver.FindElement(By.CssSelector("[name='location']"));
            buttonAdress.SendKeys("3435 Wilshire Boulevard, Los Angeles, CA, USA");
            IWebElement buttonIndustry = driver.FindElement(By.CssSelector("[name='industry']"));
            buttonIndustry.Click();
            IWebElement buttonIndustryChose = driver.FindElement(By.XPath("/html/body/nb-app/nb-signup-company/common-react-bridge/div/div[2]/div" +
                "/section/section/div/form/section/section/div/div[2]/section/div/section/div[3]/div[1]/div/div[1]/div[2]/div[1]/span"));
            buttonIndustryChose.Click();
            driver.FindElement(By.XPath("/html/body/nb-app/nb-signup-company/common-react-bridge/div/div[2]/div/section/section/div/form/section" +
                "/section/div/div[2]/section/div/section/div[3]/div[1]/div/div[1]/div[2]/div[1]/span[text()='Advertising']"));
            buttonIndustry.SendKeys(OpenQA.Selenium.Keys.Down);
            buttonIndustry.SendKeys(OpenQA.Selenium.Keys.Return);
            IWebElement buttonFinish = driver.FindElement(By.CssSelector("[type='submit']"));
            buttonFinish.Click();
            string endtUrl = driver.Url;
            Assert.AreEqual(startUrl,endtUrl);
        }

        [Test]
        public void CheckEmptyNameCompanyInRegistration()
        {
            IWebElement buttonSignUp = driver.FindElement(By.CssSelector("[class='Navbar__signUp--12ZDV']"));
            buttonSignUp.Click();
            IWebElement buttonFirstName = driver.FindElement(By.CssSelector("[name = 'first_name']"));
            buttonFirstName.SendKeys("Di");
            IWebElement buttonLasttName = driver.FindElement(By.CssSelector("[name = 'last_name']"));
            buttonLasttName.SendKeys("Di");
            DateTime dataTime = new DateTime();
            dataTime = DateTime.Now;
            string name = dataTime.ToString();
            name = name.Replace(".", "");
            name = name.Replace(" ", "");
            name = name.Replace(":", "");
            name = "newMail" + name + "@test.com";
            IWebElement buttonEmail = driver.FindElement(By.CssSelector("[name='email']"));
            buttonEmail.SendKeys(name);
            IWebElement buttonPassword = driver.FindElement(By.CssSelector("[name='password']"));
            buttonPassword.SendKeys("1234567890Qe_d");
            IWebElement buttonConfirmPassword = driver.FindElement(By.CssSelector("[name='password_confirm']"));
            buttonConfirmPassword.SendKeys("1234567890Qe_d");
            IWebElement buttonPhone = driver.FindElement(By.CssSelector("[name='phone_number']"));
            buttonPhone.SendKeys("1234123123");
            IWebElement buttonNext = driver.FindElement(By.CssSelector("[type='submit']"));
            buttonNext.Click();
            IWebElement buttonCompanyName = driver.FindElement(By.CssSelector("[name='company_name']"));
            buttonCompanyName.SendKeys("");
            IWebElement buttonCompanyWedSite = driver.FindElement(By.CssSelector("[name='company_website']"));
            buttonCompanyWedSite.SendKeys("mynewcomp.com");
            string startUrl = driver.Url;
            IWebElement buttonAdress = driver.FindElement(By.CssSelector("[name='location']"));
            buttonAdress.SendKeys("3435 Wilshire Boulevard, Los Angeles, CA, USA");
            Thread.Sleep(1500);
            buttonAdress.SendKeys(Keys.ArrowDown);
            Thread.Sleep(500);
            buttonAdress.SendKeys(Keys.Enter);
            IWebElement buttonIndustry = driver.FindElement(By.CssSelector("[name='industry']"));
            buttonIndustry.Click();
            IWebElement buttonIndustryChose = driver.FindElement(By.XPath("/html/body/nb-app/nb-signup-company/common-react-bridge/div/div[2]/div" +
                "/section/section/div/form/section/section/div/div[2]/section/div/section/div[3]/div[1]/div/div[1]/div[2]/div[1]/span"));
            buttonIndustryChose.Click();
            driver.FindElement(By.XPath("/html/body/nb-app/nb-signup-company/common-react-bridge/div/div[2]/div/section/section/div/form/section" +
                "/section/div/div[2]/section/div/section/div[3]/div[1]/div/div[1]/div[2]/div[1]/span[text()='Advertising']"));
            buttonIndustry.SendKeys(OpenQA.Selenium.Keys.Down);
            buttonIndustry.SendKeys(OpenQA.Selenium.Keys.Return);
            IWebElement buttonFinish = driver.FindElement(By.CssSelector("[type='submit']"));
            buttonFinish.Click();
            string endtUrl = driver.Url;
            Assert.AreEqual(startUrl, endtUrl);
        }

        [Test]
        public void CheckEmptyLinkCompanyInRegistration()
        {
            IWebElement buttonSignUp = driver.FindElement(By.CssSelector("[class='Navbar__signUp--12ZDV']"));
            buttonSignUp.Click();
            IWebElement buttonFirstName = driver.FindElement(By.CssSelector("[name = 'first_name']"));
            buttonFirstName.SendKeys("Di");
            IWebElement buttonLasttName = driver.FindElement(By.CssSelector("[name = 'last_name']"));
            buttonLasttName.SendKeys("Di");
            DateTime dataTime = new DateTime();
            dataTime = DateTime.Now;
            string name = dataTime.ToString();
            name = name.Replace(".", "");
            name = name.Replace(" ", "");
            name = name.Replace(":", "");
            name = "newMail" + name + "@test.com";
            IWebElement buttonEmail = driver.FindElement(By.CssSelector("[name='email']"));
            buttonEmail.SendKeys(name);
            IWebElement buttonPassword = driver.FindElement(By.CssSelector("[name='password']"));
            buttonPassword.SendKeys("1234567890Qe_d");
            IWebElement buttonConfirmPassword = driver.FindElement(By.CssSelector("[name='password_confirm']"));
            buttonConfirmPassword.SendKeys("1234567890Qe_d");
            IWebElement buttonPhone = driver.FindElement(By.CssSelector("[name='phone_number']"));
            buttonPhone.SendKeys("1234123123");
            IWebElement buttonNext = driver.FindElement(By.CssSelector("[type='submit']"));
            buttonNext.Click();
            IWebElement buttonCompanyName = driver.FindElement(By.CssSelector("[name='company_name']"));
            buttonCompanyName.SendKeys("mycomp");
            IWebElement buttonCompanyWedSite = driver.FindElement(By.CssSelector("[name='company_website']"));
            buttonCompanyWedSite.SendKeys("");
            string startUrl = driver.Url;
            IWebElement buttonAdress = driver.FindElement(By.CssSelector("[name='location']"));
            buttonAdress.SendKeys("3435 Wilshire Boulevard, Los Angeles, CA, USA");
            Thread.Sleep(1500);
            buttonAdress.SendKeys(Keys.ArrowDown);
            Thread.Sleep(500);
            buttonAdress.SendKeys(Keys.Enter);
            IWebElement buttonIndustry = driver.FindElement(By.CssSelector("[name='industry']"));
            buttonIndustry.Click();
            IWebElement buttonIndustryChose = driver.FindElement(By.XPath("/html/body/nb-app/nb-signup-company/common-react-bridge/div/div[2]/div/" +
                "section/section/div/form/section/section/div/div[2]/section/div/section/div[3]/div[1]/div/div[1]/div[2]/div[1]/span"));
            buttonIndustryChose.Click();
            driver.FindElement(By.XPath("/html/body/nb-app/nb-signup-company/common-react-bridge/div/div[2]/div/section/section/div/form/section/" +
                "section/div/div[2]/section/div/section/div[3]/div[1]/div/div[1]/div[2]/div[1]/span[text()='Advertising']"));
            buttonIndustry.SendKeys(OpenQA.Selenium.Keys.Down);
            buttonIndustry.SendKeys(OpenQA.Selenium.Keys.Return);
            IWebElement buttonFinish = driver.FindElement(By.CssSelector("[type='submit']"));
            buttonFinish.Click();
            string endtUrl = driver.Url;
            Assert.AreEqual(startUrl, endtUrl);
        }

        [Test]
        public void CheckEmptyIndustryCompanyInRegistration()
        {
            IWebElement buttonSignUp = driver.FindElement(By.CssSelector("[class='Navbar__signUp--12ZDV']"));
            buttonSignUp.Click();
            IWebElement buttonFirstName = driver.FindElement(By.CssSelector("[name = 'first_name']"));
            buttonFirstName.SendKeys("Di");
            IWebElement buttonLasttName = driver.FindElement(By.CssSelector("[name = 'last_name']"));
            buttonLasttName.SendKeys("Di");
            DateTime dataTime = new DateTime();
            dataTime = DateTime.Now;
            string name = dataTime.ToString();
            name = name.Replace(".", "");
            name = name.Replace(" ", "");
            name = name.Replace(":", "");
            name = "newMail" + name + "@test.com";
            IWebElement buttonEmail = driver.FindElement(By.CssSelector("[name='email']"));
            buttonEmail.SendKeys(name);
            IWebElement buttonPassword = driver.FindElement(By.CssSelector("[name='password']"));
            buttonPassword.SendKeys("1234567890Qe_d");
            IWebElement buttonConfirmPassword = driver.FindElement(By.CssSelector("[name='password_confirm']"));
            buttonConfirmPassword.SendKeys("1234567890Qe_d");
            IWebElement buttonPhone = driver.FindElement(By.CssSelector("[name='phone_number']"));
            buttonPhone.SendKeys("1234123123");
            IWebElement buttonNext = driver.FindElement(By.CssSelector("[type='submit']"));
            buttonNext.Click();
            IWebElement buttonCompanyName = driver.FindElement(By.CssSelector("[name='company_name']"));
            buttonCompanyName.SendKeys("mycomp");
            IWebElement buttonCompanyWedSite = driver.FindElement(By.CssSelector("[name='company_website']"));
            buttonCompanyWedSite.SendKeys("mycomp.com");
            string startUrl = driver.Url;
            IWebElement buttonAdress = driver.FindElement(By.CssSelector("[name='location']"));
            buttonAdress.SendKeys("3435 Wilshire Boulevard, Los Angeles, CA, USA");
            Thread.Sleep(1500);
            buttonAdress.SendKeys(Keys.ArrowDown);
            Thread.Sleep(500);
            buttonAdress.SendKeys(Keys.Enter);
            IWebElement buttonIndustry = driver.FindElement(By.CssSelector("[name='industry']"));
            buttonIndustry.Click();
            IWebElement buttonIndustryChose = driver.FindElement(By.XPath("/html/body/nb-app/nb-signup-company/common-react-bridge/div/div[2]/div" +
                "/section/section/div/form/section/section/div/div[2]/section/div/section/div[3]/div[1]/div/div[1]/div[2]/div[1]/span"));
            buttonIndustryChose.Click();
            IWebElement buttonFinish = driver.FindElement(By.CssSelector("[type='submit']"));
            buttonFinish.Click();
            string endtUrl = driver.Url;
            Assert.AreEqual(startUrl, endtUrl);
        }

        [Test]
        public void Autorisation()
        {
            IWebElement start = driver.FindElement(By.CssSelector("[class='Navbar__navLink--3lL7S Navbar__navLinkSingle--3x6Lx Navbar__login--28b35 ']"));
            start.Click();
            IWebElement buttonSignUp = driver.FindElement(By.CssSelector("[class='Input__input--_88SI Input__themeNewbook--1IRjd Input__fontRegular--2SStp']"));
            buttonSignUp.SendKeys("newMail02112021132503@test.com");
            IWebElement buttonPasword = driver.FindElement(By.CssSelector("[name = 'password']"));
            buttonPasword.SendKeys("1234567890Qe_d");
            IWebElement buttonSignIn = driver.FindElement(By.CssSelector("[class = 'SignInForm__submitButton--cUdOV Button__button---rQSB Button__" +
                "themeSealBrown--3arN6 Button__sizeMedium--uLCYD Button__fontSmall--1EPi5 Button__withTranslate--1qGAH']"));
            buttonSignIn.Click();
            Assert.Pass();
        }

        [Test]
        public void TestUnValidationLogoAutorisation()
        {
            IWebElement start = driver.FindElement(By.CssSelector("[class='Navbar__navLink--3lL7S Navbar__navLinkSingle--3x6Lx Navbar__login--28b35 ']"));
            start.Click();            
            IWebElement buttonSignUp = driver.FindElement(By.CssSelector("[class='Input__input--_88SI Input__themeNewbook--1IRjd Input__fontRegular--2SStp']"));
            buttonSignUp.SendKeys("newMailsdsdsdsd02112021132503@test.com");
            IWebElement buttonPasword = driver.FindElement(By.CssSelector("[name = 'password']"));
            buttonPasword.SendKeys("1234567890Qe_d");
            string startUrl = driver.Url;
            IWebElement buttonSignIn = driver.FindElement(By.CssSelector("[class = 'SignInForm__submitButton--cUdOV Button__button---rQSB Button__" +
                "themeSealBrown--3arN6 Button__sizeMedium--uLCYD Button__fontSmall--1EPi5 Button__withTranslate--1qGAH']"));
            buttonSignIn.Click();
            string endtUrl = driver.Url;
            Assert.AreEqual(startUrl, endtUrl);
        }

        [Test]
        public void TestUnValidationPasswordAutorisation()
        {
            IWebElement start = driver.FindElement(By.CssSelector("[class='Navbar__navLink--3lL7S Navbar__navLinkSingle--3x6Lx Navbar__login--28b35 ']"));
            start.Click();
            IWebElement buttonSignUp = driver.FindElement(By.CssSelector("[class='Input__input--_88SI Input__themeNewbook--1IRjd Input__fontRegular--2SStp']"));
            buttonSignUp.SendKeys("newMail02112021132503@test.com");
            IWebElement buttonPasword = driver.FindElement(By.CssSelector("[name = 'password']"));
            buttonPasword.SendKeys("12345678sdsd90Qe_d");
            string startUrl = driver.Url;
            IWebElement buttonSignIn = driver.FindElement(By.CssSelector("[class = 'SignInForm__submitButton--cUdOV Button__button---rQSB Button__" +
                "themeSealBrown--3arN6 Button__sizeMedium--uLCYD Button__fontSmall--1EPi5 Button__withTranslate--1qGAH']"));
            buttonSignIn.Click();
            string endtUrl = driver.Url;
            Assert.AreEqual(startUrl, endtUrl);
        }

        [Test]
        public void LogOut()
        {
            IWebElement start = driver.FindElement(By.CssSelector("[class='Navbar__navLink--3lL7S Navbar__navLinkSingle--3x6Lx Navbar__login--28b35 ']"));
            start.Click();
            IWebElement buttonSignUp = driver.FindElement(By.CssSelector("[class='Input__input--_88SI Input__themeNewbook--1IRjd Input__fontRegular--2SStp']"));
            buttonSignUp.SendKeys("newMail02112021132503@test.com");
            IWebElement buttonPasword = driver.FindElement(By.CssSelector("[name = 'password']"));
            buttonPasword.SendKeys("1234567890Qe_d");
            IWebElement buttonSignIn = driver.FindElement(By.CssSelector("[class = 'SignInForm__submitButton--cUdOV Button__button---rQSB Button__" +
                "themeSealBrown--3arN6 Button__sizeMedium--uLCYD Button__fontSmall--1EPi5 Button__withTranslate--1qGAH']"));
            buttonSignIn.Click();
            IWebElement buttonAcaunt = driver.FindElement(By.CssSelector("[class='MainHeader__staticItemAvatar--3LwWp MainHeader__staticItem--2UY1x ']"));
            buttonAcaunt.Click();
            IWebElement buttonLogOut = driver.FindElement(By.CssSelector("[class='link link_type_logout link_active']"));
            buttonLogOut.Click();
            Assert.Pass();
        }

        [Test]
        public void AddAFavorit()
        {
            IWebElement start = driver.FindElement(By.CssSelector("[class='Navbar__navLink--3lL7S Navbar__navLinkSingle--3x6Lx Navbar__login--28b35 ']"));
            start.Click();
            IWebElement buttonSignUp = driver.FindElement(By.CssSelector("[class='Input__input--_88SI Input__themeNewbook--1IRjd Input__fontRegular--2SStp']"));
            buttonSignUp.SendKeys("596af73a33@emailnax.com");
            IWebElement buttonPasword = driver.FindElement(By.CssSelector("[name ='password']"));
            buttonPasword.SendKeys("1234567890Qe_d");
            IWebElement buttonSignIn = driver.FindElement(By.CssSelector("[class ='SignInForm__submitButton--cUdOV Button__button---rQSB Button__themeSealBrown-" +
                "-3arN6 Button__sizeMedium--uLCYD Button__fontSmall--1EPi5 Button__withTranslate--1qGAH']"));
            buttonSignIn.Click();
            IWebElement buttonFavorites = driver.FindElement(By.CssSelector("[data-qa='header-menu-favorites']"));
            buttonFavorites.Click();
            System.Collections.ObjectModel.ReadOnlyCollection<IWebElement> startWebElements = driver.FindElements(By.CssSelector("[class='FoldersPage__" +
                "card--319fj']"));
            //IWebElement FavoritesCounter = webElements;
            int startCount = 0;

            foreach (var item in startWebElements)
            {
                startCount++;
            }

            IWebElement buttonAddFavorites = driver.FindElement(By.CssSelector("[class = 'CreateFolderCard__icon--1Yr13']"));
            buttonAddFavorites.Click();
            DateTime dataTime = new DateTime();
            dataTime = DateTime.Now;
            string name = dataTime.ToString();
            name = name.Replace(".", "");
            name = name.Replace(" ", "");
            name = name.Replace(":", "");
            name = "Di" + name;
            IWebElement buttonAddFavoritesName = driver.FindElement(By.CssSelector("[class ='Input__input--_88SI Input__themePrimary--2KH0g Input__" +
                "fontNormal--3K4pv']"));
            buttonAddFavoritesName.SendKeys(name);
            IWebElement buttonAddFavoritesDesc = driver.FindElement(By.CssSelector("[class = 'TextArea__textarea--1MBxY']"));
            buttonAddFavoritesDesc.SendKeys("Text");
            IWebElement buttonCreateAndSave = driver.FindElement(By.CssSelector("[class ='FolderForm__submitButton--mkTZU Button__button---rQSB Button__" +
                "themePrimary--E5ESP Button__sizeMedium--uLCYD Button__fontSmall--1EPi5 Button__withTranslate--1qGAH']"));
            buttonCreateAndSave.Click();
            //List<IWebElement> EndFavoritesCounter = new List<IWebElement>();
            System.Collections.ObjectModel.ReadOnlyCollection<IWebElement> webElements = driver.FindElements(By.CssSelector("[class='FoldersPage__card--319fj']"));
            //IWebElement FavoritesCounter = webElements;
            int count = 0;
            foreach (var item in webElements)
            {
                count++;
            }
            IWebElement buttonClickFavorite = driver.FindElement(By.CssSelector($"[title ='{name}']"));
            buttonClickFavorite.Click();
            IWebElement buttonClickEdit = driver.FindElement(By.XPath($"html/body/nb-app/ng-component/common-react-bridge/div/div[2]/div/" +
                $"section/header/section[2]/div[2]/button"));
            buttonClickEdit.Click();
            IWebElement buttonDeleteList = driver.FindElement(By.CssSelector("[title ='Delete list']"));
            buttonDeleteList.Click();
            IWebElement buttonTryDeleteList = driver.FindElement(By.CssSelector("[class ='DeleteFolder__deleteButton--3iYyL " +
                "Button__button---rQSB Button__themePrimary--E5ESP Button__sizeMedium--uLCYD Button__fontSmall--1EPi5 Button__withTranslate--1qGAH']"));
            buttonTryDeleteList.Click();
            Assert.AreEqual(startCount, count);
        }

        [Test]
        public void DeleteAFavorit()
        {
            IWebElement start = driver.FindElement(By.CssSelector("[class='Navbar__navLink--3lL7S Navbar__navLinkSingle--3x6Lx Navbar__login--28b35 ']"));
            start.Click();
            IWebElement buttonSignUp = driver.FindElement(By.CssSelector("[class='Input__input--_88SI Input__themeNewbook--1IRjd " +
                "Input__fontRegular--2SStp']"));
            buttonSignUp.SendKeys("596af73a33@emailnax.com");
            IWebElement buttonPasword = driver.FindElement(By.CssSelector("[name ='password']"));
            buttonPasword.SendKeys("1234567890Qe_d");
            IWebElement buttonSignIn = driver.FindElement(By.CssSelector("[class ='SignInForm__submitButton--cUdOV Button__button---rQSB " +
                "Button__themeSealBrown--3arN6 Button__sizeMedium--uLCYD Button__fontSmall--1EPi5 Button__withTranslate--1qGAH']"));
            buttonSignIn.Click();
            IWebElement buttonFavorites = driver.FindElement(By.CssSelector("[data-qa='header-menu-favorites']"));
            buttonFavorites.Click();
            IWebElement buttonAddFavorites = driver.FindElement(By.CssSelector("[class = 'CreateFolderCard__icon--1Yr13']"));
            buttonAddFavorites.Click();
            DateTime dataTime = new DateTime();
            dataTime = DateTime.Now;
            string name = dataTime.ToString();
            name = name.Replace(".", "");
            name = name.Replace(" ", "");
            name = name.Replace(":", "");
            name = "Di" + name;
            IWebElement buttonAddFavoritesName = driver.FindElement(By.CssSelector("[class ='Input__input--_88SI Input__themePrimary--2KH0g Input__" +
                "fontNormal--3K4pv']"));
            buttonAddFavoritesName.SendKeys(name);
            IWebElement buttonAddFavoritesDesc = driver.FindElement(By.CssSelector("[class = 'TextArea__textarea--1MBxY']"));
            buttonAddFavoritesDesc.SendKeys("Text");
            IWebElement buttonCreateAndSave = driver.FindElement(By.CssSelector("[class ='FolderForm__submitButton--mkTZU Button__button---rQSB Button__" +
                "themePrimary--E5ESP Button__sizeMedium--uLCYD Button__fontSmall--1EPi5 Button__withTranslate--1qGAH']"));
            buttonCreateAndSave.Click();
            System.Collections.ObjectModel.ReadOnlyCollection<IWebElement> webElements = driver.FindElements(By.CssSelector("[class='FoldersPage__card--319fj']"));
            int count = 0;
            foreach (var item in webElements)
            {
                count++;
            }
            IWebElement buttonClickFavorite = driver.FindElement(By.CssSelector($"[title ='{name}']"));
            buttonClickFavorite.Click();
            IWebElement buttonClickEdit = driver.FindElement(By.XPath($"html/body/nb-app/ng-component/common-react-bridge/div" +
                $"/div[2]/div/section/header/section[2]/div[2]/button"));
            buttonClickEdit.Click();
            IWebElement buttonDeleteList = driver.FindElement(By.CssSelector("[title ='Delete list']"));
            buttonDeleteList.Click();
            IWebElement buttonTryDeleteList = driver.FindElement(By.CssSelector("[class ='DeleteFolder__deleteButton--3iYyL" +
                " Button__button---rQSB Button__themePrimary--E5ESP Button__sizeMedium--uLCYD Button__fontSmall--1EPi5 Button__withTranslate--1qGAH']"));
            buttonTryDeleteList.Click();
            System.Collections.ObjectModel.ReadOnlyCollection<IWebElement> endWebElements = driver.FindElements(By.CssSelector("[class='FoldersPage__card--319fj']"));
            int endCount = 0;
            foreach (var item in endWebElements)
            {
                endCount++;
            }
            Assert.AreEqual(endCount, count);
        }


        [Test]
        public void ChangeNameOfUser()
        {
            IWebElement start = driver.FindElement(By.CssSelector("[class='Navbar__navLink--3lL7S Navbar__navLinkSingle--3x6Lx Navbar__login--28b35 ']"));
            start.Click();
            IWebElement buttonSignUp = driver.FindElement(By.CssSelector("[class='Input__input--_88SI Input__themeNewbook--1IRjd Input__fontRegular--2SStp']"));
            buttonSignUp.SendKeys("596af73a33@emailnax.com");
            IWebElement buttonPasword = driver.FindElement(By.CssSelector("[name = 'password']"));
            buttonPasword.SendKeys("1234567890Qe_d");
            IWebElement buttonSignIn = driver.FindElement(By.CssSelector("[class = 'SignInForm__submitButton--cUdOV Button__button---rQSB " +
                "Button__themeSealBrown--3arN6 Button__sizeMedium--uLCYD Button__fontSmall--1EPi5 Button__withTranslate--1qGAH']"));
            buttonSignIn.Click();
            IWebElement buttonAcaunt = driver.FindElement(By.CssSelector("[class='MainHeader__staticItemAvatar--3LwWp MainHeader__staticItem--2UY1x ']"));
            buttonAcaunt.Click();
            IWebElement buttonChange = driver.FindElement(By.XPath("/html/body/nb-app/ng-component/nb-internal-layout/common-layout/section/d" +
                "iv/ng-component/nb-account-info-edit/common-border/div[1]/div/nb-account-info-general-information/form/div[1]/div/nb-edit-switcher/div/div"));
            string NameWithOutChanches = buttonChange.Text;
            buttonChange.Click();
            IWebElement buttonName = driver.FindElement(By.XPath("/html/body/nb-app/ng-component/nb-internal-layout/common-layout/section/di" +
                "v/ng-component/nb-account-info-edit/common-border/div[1]/div/nb-account-info-general-information/form/div[2]/div/common-input[1]/label/input"));
            buttonName.Clear();
            Random rnd = new Random();
            int number = rnd.Next(0, 100);
            string nameDi = "Di" + number.ToString();
            buttonName.SendKeys(nameDi);            
            IWebElement buttonSaveChange = driver.FindElement(By.XPath("/html/body/nb-app/ng-component/nb-internal-layout/common-layout/secti" +
                "on/div/ng-component/nb-account-info-edit/common-border/div[1]/div/nb-account-info-general-information/form/div[2]/div/common-" +
                "button-deprecated/button"));
            buttonSaveChange.Click();
            IWebElement buttonCheckChangeName = driver.FindElement(By.XPath("/html/body/nb-app/ng-component/nb-internal-layout/common-layout/" +
                "section/div/ng-component/nb-account-info-edit/common-border/div[1]/div/nb-account-info-general-information/form/div[2]/div/nb-paragraph[2]/div"));
            string name = buttonCheckChangeName.Text;
            Assert.AreEqual(nameDi+" Di", name);
        }

        [Test]
        public void ChangeCompanyAdress()
        {
            IWebElement start = driver.FindElement(By.CssSelector("[class='Navbar__navLink--3lL7S Navbar__navLinkSingle--3x6Lx Navbar__login--28b35 ']"));
            start.Click();
            IWebElement buttonSignUp = driver.FindElement(By.CssSelector("[class='Input__input--_88SI Input__themeNewbook--1IRjd Input__fontRegular--2SStp']"));
            buttonSignUp.SendKeys("596af73a33@emailnax.com");
            IWebElement buttonPasword = driver.FindElement(By.CssSelector("[name = 'password']"));
            buttonPasword.SendKeys("1234567890Qe_d");
            IWebElement buttonSignIn = driver.FindElement(By.CssSelector("[class = 'SignInForm__submitButton--cUdOV Button__button---rQSB" +
                " Button__themeSealBrown--3arN6 Button__sizeMedium--uLCYD Button__fontSmall--1EPi5 Button__withTranslate--1qGAH']"));
            buttonSignIn.Click();
            IWebElement buttonAcaunt = driver.FindElement(By.CssSelector("[class='MainHeader__staticItemAvatar--3LwWp MainHeader__staticItem--2UY1x ']"));
            buttonAcaunt.Click();
            IWebElement buttonChange = driver.FindElement(By.XPath("/html/body/nb-app/ng-component/nb-internal-layout/common-" +
                "layout/section/div/ng-component/nb-account-info-edit/common-border/div[1]/div/nb-account-info-general-information/form/div[1]/" +
                "div/nb-edit-switcher/div/div"));
            buttonChange.Click();
            IWebElement buttonAddress = driver.FindElement(By.CssSelector("input[placeholder=\"Enter Company Location\"]"));
            buttonAddress.Click();
            Random rnd = new Random();
            string num = rnd.Next(1, 21).ToString();
            buttonAddress.SendKeys($"{num}");
            Thread.Sleep(1500);
            buttonAddress.SendKeys(Keys.ArrowDown);
            Thread.Sleep(500);
            buttonAddress.SendKeys(Keys.Enter);
            IWebElement buttonSaveChange = driver.FindElement(By.XPath("/html/body/nb-app/ng-component/nb-internal-layout/common-layout/section/div/ng-" +
                "component/nb-account-info-edit/common-border/div[1]/div/nb-account-info-general-information/form/div[2]/div/common-button-deprecated/button"));
            buttonSaveChange.Click();
            Assert.Pass();
        }

        [Test]
        public void ChangeCompanyIndustry()
        {
            DateTime dataTime = new DateTime();
            dataTime = DateTime.Now;
            string name = dataTime.ToString();
            name = name.Replace(".", "");
            name = name.Replace(" ", "");
            name = name.Replace(":", "");
            name = "ind" + name;
            IWebElement start = driver.FindElement(By.CssSelector("[class='Navbar__navLink--3lL7S Navbar__navLinkSingle--3x6Lx Navbar__login--28b35 ']"));
            start.Click();
            IWebElement buttonSignUp = driver.FindElement(By.CssSelector("[class='Input__input--_88SI Input__themeNewbook--1IRjd Input__fontRegular--2SStp']"));
            buttonSignUp.SendKeys("596af73a33@emailnax.com");
            IWebElement buttonPasword = driver.FindElement(By.CssSelector("[name = 'password']"));
            buttonPasword.SendKeys("1234567890Qe_d");
            IWebElement buttonSignIn = driver.FindElement(By.CssSelector("[class = 'SignInForm__submitButton--cUdOV Button__button---rQSB Button__themeSealBrown--" +
                "3arN6 Button__sizeMedium--uLCYD Button__fontSmall--1EPi5 Button__withTranslate--1qGAH']"));
            buttonSignIn.Click();
            IWebElement buttonAcaunt = driver.FindElement(By.CssSelector("[class='MainHeader__staticItemAvatar--3LwWp MainHeader__staticItem--2UY1x ']"));
            buttonAcaunt.Click();
            IWebElement buttonChange = driver.FindElement(By.XPath("/html/body/nb-app/ng-component/nb-internal-layout/common-layout/section/div/ng-component/nb-" +
                "account-info-edit/common-border/div[1]/div/nb-account-info-general-information/form/div[1]/div/nb-edit-switcher/div/div"));
            buttonChange.Click();
            IWebElement buttonIndustry = driver.FindElement(By.CssSelector("input[placeholder=\"Enter Industry\"]"));
            buttonIndustry.Clear();
            buttonIndustry.SendKeys(name);
            IWebElement buttonSaveChange = driver.FindElement(By.XPath("/html/body/nb-app/ng-component/nb-internal-layout/common-layout/section/div/ng-" +
                "component/nb-account-info-edit/common-border/div[1]/div/nb-account-info-general-information/form/div[2]/div/common-button-deprecated/button"));
            buttonSaveChange.Click();
            IWebElement buttonCheckChangeIndustry = driver.FindElement(By.XPath("/html/body/nb-app/ng-component/nb-internal-layout/common-layout/section/div/" +
                "ng-component/nb-account-info-edit/common-border/div[1]/div/nb-account-info-general-information/form/div[2]/div/nb-paragraph[4]"));
            string nameIndustry = buttonCheckChangeIndustry.Text;
            Assert.AreEqual(name, nameIndustry);
        }

        [Test]
        public void ChangeUserPasword()
        {
            IWebElement buttonSignUp = driver.FindElement(By.CssSelector("[class='Navbar__signUp--12ZDV']"));
            buttonSignUp.Click();
            IWebElement buttonFirstName = driver.FindElement(By.CssSelector("[name = 'first_name']"));
            buttonFirstName.SendKeys("Di");
            IWebElement buttonLasttName = driver.FindElement(By.CssSelector("[name = 'last_name']"));
            buttonLasttName.SendKeys("Di");
            DateTime dataTime = new DateTime();
            dataTime = DateTime.Now;
            string name = dataTime.ToString();
            name = name.Replace(".", "");
            name = name.Replace(" ", "");
            name = name.Replace(":", "");
            name = "newMail" + name + "@test.com";
            IWebElement buttonEmail = driver.FindElement(By.CssSelector("[name='email']"));
            buttonEmail.SendKeys(name);
            IWebElement buttonPassword = driver.FindElement(By.CssSelector("[name='password']"));
            buttonPassword.SendKeys("1234567890Qe_d");
            IWebElement buttonConfirmPassword = driver.FindElement(By.CssSelector("[name='password_confirm']"));
            buttonConfirmPassword.SendKeys("1234567890Qe_d");
            IWebElement buttonPhone = driver.FindElement(By.CssSelector("[name='phone_number']"));
            buttonPhone.SendKeys("1234123123");
            IWebElement buttonNext = driver.FindElement(By.CssSelector("[type='submit']"));
            buttonNext.Click();
            IWebElement buttonCompanyName = driver.FindElement(By.CssSelector("[name='company_name']"));
            buttonCompanyName.SendKeys("MyComp");
            IWebElement buttonCompanyWedSite = driver.FindElement(By.CssSelector("[name='company_website']"));
            buttonCompanyWedSite.SendKeys("mynewcomp.com");
            IWebElement buttonAdress = driver.FindElement(By.CssSelector("[name='location']"));
            buttonAdress.SendKeys("3435 Wilshire Boulevard, Los Angeles, CA, USA");
            Thread.Sleep(1500);
            buttonAdress.SendKeys(Keys.ArrowDown);
            Thread.Sleep(500);
            buttonAdress.SendKeys(Keys.Enter);
            IWebElement buttonIndustry = driver.FindElement(By.CssSelector("[name='industry']"));
            buttonIndustry.Click();
            IWebElement buttonIndustryChose = driver.FindElement(By.XPath("/html/body/nb-app/nb-signup-company/common-react-bridge/div/div[2]/" +
                "div/section/section/div/form/section/section/div/div[2]/section/div/section/div[3]/div[1]/div/div[1]/div[2]/div[1]/span"));
            buttonIndustryChose.Click();
            driver.FindElement(By.XPath("/html/body/nb-app/nb-signup-company/common-react-bridge/div/div[2]/div/section/section/div/form/section" +
                "/section/div/div[2]/section/div/section/div[3]/div[1]/div/div[1]/div[2]/div[1]/span[text()='Advertising']"));
            buttonIndustry.SendKeys(OpenQA.Selenium.Keys.Down);
            buttonIndustry.SendKeys(OpenQA.Selenium.Keys.Return);
            IWebElement buttonFinish = driver.FindElement(By.CssSelector("[type='submit']"));
            buttonFinish.Click();
            Thread.Sleep(1000);
            IWebElement buttonAcaunt = driver.FindElement(By.CssSelector("[class='MainHeader__staticItemAvatar--3LwWp MainHeader__staticItem--2UY1x ']"));
            buttonAcaunt.Click();
            IWebElement buttonChange = driver.FindElement(By.XPath("/html/body/nb-app/ng-component/nb-internal-layout/common-layout/section/div/ng-component" +
                "/nb-account-info-edit/common-border/div[3]/div/nb-account-info-password/form/div[1]/div/nb-edit-switcher/div/div"));
            buttonChange.Click();
            IWebElement buttonConfPass = driver.FindElement(By.CssSelector("input[placeholder=\"Enter Current Password\"]"));
            buttonConfPass.SendKeys("1234567890Qe_d");
            IWebElement buttonNewPass = driver.FindElement(By.XPath("/html/body/nb-app/ng-component/nb-internal-layout/common-layout/section/div/ng-component" +
                "/nb-account-info-edit/common-border/div[3]/div/nb-account-info-password/form/div[2]/div/common-input[2]/label/input"));
            buttonNewPass.SendKeys("1234567890Qe_d1");
            IWebElement buttonConfirmNewPass = driver.FindElement(By.XPath("/html/body/nb-app/ng-component/nb-internal-layout/common-layout/section/div/ng-component" +
                "/nb-account-info-edit/common-border/div[3]/div/nb-account-info-password/form/div[2]/div/common-input[3]/label/input"));
            buttonConfirmNewPass.SendKeys("1234567890Qe_d1");
            IWebElement buttonSaveChange = driver.FindElement(By.XPath("/html/body/nb-app/ng-component/nb-internal-layout/common-layout/section/div/ng-component/" +
                "nb-account-info-edit/common-border/div[3]/div/nb-account-info-password/form/div[2]/div/common-button-deprecated/button"));
            Thread.Sleep(1000);
            buttonSaveChange.Click();
            Thread.Sleep(1000);
            IWebElement buttonLogOut = driver.FindElement(By.CssSelector("[class='link link_type_logout link_active']"));
            buttonLogOut.Click();
            IWebElement buttonSign = driver.FindElement(By.CssSelector("[class='Input__input--_88SI Input__themeNewbook--1IRjd Input__fontRegular--2SStp']"));
            buttonSign.SendKeys(name);
            IWebElement buttonPasword = driver.FindElement(By.CssSelector("[name = 'password']"));
            buttonPasword.SendKeys("1234567890Qe_d1");
            IWebElement buttonSignIn = driver.FindElement(By.CssSelector("[class = 'SignInForm__submitButton--cUdOV Button__button---rQSB Button__" +
                "themeSealBrown--3arN6 Button__sizeMedium--uLCYD Button__fontSmall--1EPi5 Button__withTranslate--1qGAH']"));
            buttonSignIn.Click();

            Assert.Pass();
        }

        [TearDown]
        public void After()
        {
           driver.Quit();
        }
    }
}