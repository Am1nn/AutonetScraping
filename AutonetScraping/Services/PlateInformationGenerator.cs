using AutonetScraping.Models;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace AutonetScraping.Services;

public class PlateInformationGenerator
{
    public ICollection<string>? PageLinks { get; set; }=new List<string>();
    public ICollection<NumberPlate>? NumberPlates { get; set; }
    public int? PlateCount { get; set; }


    public ChromeDriverService chromeDriverService = ChromeDriverService.CreateDefaultService();
    public ChromeOptions chromeOptions = new ChromeOptions();

    public PlateInformationGenerator()
    {
        PlateCount = 0;
    }
    public void AddPageLinks(ICollection<string> links)
    {
        PageLinks = links;
    }
    public ICollection<NumberPlate>? GeneratePlates(int plateCount)
    {
        // PLateCount yaradilmasini Istediyimiz Masinlarin Sayini gosterir Maksimum 350 eded olar!
        if (plateCount < 0 && plateCount > 350)
        { plateCount = 100; }

        int plateCountChecker = 0;

        foreach (string link in PageLinks)
        {
            if(plateCountChecker >=plateCount)
            {
                break;
            }


            NumberPlate NewPlate = new();

            using (var driver = new ChromeDriver(chromeDriverService, chromeOptions))
            {
                driver.Navigate().GoToUrl(link);

                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                try
                {
                    // Qeydiyyat Nishanini Bize verir
                    var PlateDiv = driver.FindElement(By.ClassName("plate_v_big"));
                    Console.WriteLine("Qeydiyyat Nisani: " + PlateDiv.Text);


                    //Qiymetini Bize verir
                    var PriceDiv = driver.FindElement(By.ClassName("price"));
                    Console.WriteLine("Qiymet: " + PriceDiv.Text);   //Replace(" ", "");

                    //Descriptionu Bize verir
                    var DescriptionDiv = driver.FindElement(By.ClassName("license-plate__seller-information-text"));
                    Console.WriteLine("Description: " + DescriptionDiv.Text);

                    //Istifadeci Adini Bize verir
                    var UsernameDiv = driver.FindElement(By.ClassName("license-plate__seller-name"));
                    Console.WriteLine("Istifadeci: " + UsernameDiv.Text);

                    //Telefon Nomresini Bize verir
                    var PhoneDiv = driver.FindElement(By.ClassName("license-plate__seller-phone-number"));
                    string phone = PhoneDiv.Text;
                    if (phone.Length > 15)
                    {
                        Console.WriteLine("Elaqe Nomresi: " + phone.Substring(0, 15));

                    }
                    else
                    {
                        Console.WriteLine("Elaqe Nomresi: " + phone);
                    }
                    // Seheri Bize Verir
                    var PlaceDiv = driver.FindElement(By.ClassName("location"));
                    Console.WriteLine("Mekan: " + PlaceDiv.Text);

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
            plateCountChecker++;
        }
        return NumberPlates;
    }
}
