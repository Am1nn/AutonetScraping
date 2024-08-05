using AutonetScraping.Services;
using Microsoft.Identity.Client;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        PlatePagesGenerator platePagesGenerator = new PlatePagesGenerator();
        PlateInformationGenerator plateInformationGenerator = new();
        plateInformationGenerator.AddPageLinks(platePagesGenerator.GeneratePages());
        plateInformationGenerator.GeneratePlates(3);







    }
}
