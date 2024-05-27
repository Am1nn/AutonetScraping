using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        var chromeDriverService = ChromeDriverService.CreateDefaultService();
        var chromeOptions = new ChromeOptions();

        using (var driver = new ChromeDriver(chromeDriverService, chromeOptions))
        {
            driver.Navigate().GoToUrl("https://www.autonet.az/licenseplates");

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            try
            {

                // Altda Olan Load More Buttonunu Tapir
                var loadMoreButton = driver.FindElement(By.CssSelector(".load-more-button.material-button"));

                // Butona Bizim Yerimize Avtomatik Click Edir
                loadMoreButton.Click();

                //  Seyfenin Tam YUklenmesi Ucun Biraz Gozledirik
                System.Threading.Thread.Sleep(2000);

                // Qeyd:
                // Daha Cox Qeydiyyat Elan Linkleri Getirmek Isdedikde  loadMoreButton.Click() Hissesini For icerisinde yaza bilerik.))


                List<string> links = new();

                // registiration-mark class adli div icerisindeki butun html kodlarini list seklinde yigir
                var platesBoxList = driver.FindElements(By.ClassName("registration-mark"));
                //Foreach ile her elanin icerisindeki kodlari bir bir gezir
                foreach (var platesBox in platesBoxList)
                {
                    // Her elanin a tagini tapir
                    var platesBoxTag = platesBox.FindElement(By.TagName("a"));
                    // a taginin icerisindeki elanin linkini fitib bize verir
                    string link = platesBoxTag.GetAttribute("href");
                    links.Add(link);
                    Console.WriteLine(link);
                }
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Wrong Link Or Empty Elements!!!");
            }
            finally
            {
                driver.Quit();
            }
        }
    }
}
