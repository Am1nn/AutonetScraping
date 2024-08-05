using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace AutonetScraping.Services;

public class PlatePagesGenerator
{
    public ICollection<string>? PageLinks { get; set; }
    public int? PageCount { get; set; }

    public ChromeDriverService chromeDriverService = ChromeDriverService.CreateDefaultService();
    public ChromeOptions chromeOptions = new ChromeOptions();

    public PlatePagesGenerator()
    {
        PageLinks=new List<string>();
        PageCount = 0;
    }

    public ICollection<string>? GeneratePages(int counter = 0)
    {
        // Counter Her Defesinde Bir reqem Artirildigi zaman 32 elan daha cox generate edilir!
        if (counter < 0 && counter > 10)
        {
            counter = 0;
        }

        using (var driver = new ChromeDriver(chromeDriverService, chromeOptions))
        {
            driver.Navigate().GoToUrl("https://www.autonet.az/licenseplates");

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            try
            {
                // Altda Olan Load More Buttonunu Tapir
                var loadMoreButton = driver.FindElement(By.CssSelector(".load-more-button.material-button"));

                // Butona Bizim Yerimize Avtomatik Click Edir
                for (int i = 0; i < counter; i++)
                {
                    loadMoreButton.Click();
                }

                //  Seyfenin Tam YUklenmesi Ucun Biraz Gozledirik
                Thread.Sleep(2000);

                // registiration-mark class adli div icerisindeki butun html kodlarini list seklinde yigir
                var platesBoxList = driver.FindElements(By.ClassName("registration-mark"));
                //Foreach ile her elanin icerisindeki kodlari bir bir gezir
                foreach (var platesBox in platesBoxList)
                {
                    // Her elanin a tagini tapir
                    var platesBoxTag = platesBox.FindElement(By.TagName("a"));
                    // a taginin icerisindeki elanin linkini fitib bize verir
                    string link = platesBoxTag.GetAttribute("href");
                    PageLinks?.Add(link);
                    PageCount += 1;
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
        return PageLinks;
    }


    public int? GetResults()
    {
        return PageCount;
    }






}
