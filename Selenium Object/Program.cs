using System;
using System.IO;
using System.Reflection;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace Selenium_Object
{
    public class Program
    {
        static void Main(string[] args)
        {
            Selenium selenium = new Selenium();
            selenium.Inicio();


            Console.WriteLine();
        }
    }
}
