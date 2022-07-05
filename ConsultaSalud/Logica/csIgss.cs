using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;

namespace ConsultaSalud.Logica
{
    public class csIgss
    {
        BdComun conexion = new BdComun();
        int año;
        int _mes;
        int no_patrono;
        string patrono;
        string razon;
        string aporto;
        public void procesar()
        {

        }
        public void RealizarConsulta(string _dpi, DateTime _nacimiento)
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("no-sandbox");

            options.AddArguments("--disable-extensions"); // to disable extension
            options.AddArguments("--disable-notifications"); // to disable notification
            options.AddArguments("--disable-application-cache"); // to disable cache
                                                                 // options.AddArgument("headless");
            ChromeDriverService service = ChromeDriverService.CreateDefaultService();
            service.HideCommandPromptWindow = false;
            // string workingDirectory = Environment.CurrentDirectory;
            //string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            IWebDriver driver = new ChromeDriver(service, options, TimeSpan.FromMinutes(5));

            try
            {

            string id = "", answer = "";
           
            // driver.Manage().Timeouts().PageLoad.Add(TimeSpan.FromSeconds(190));
            driver.Navigate().GoToUrl("https://www.igssgt.org/cuotas/");
            Thread.Sleep(2000);
            ANUNCIO(driver);

            string script = "document.getElementsByClassName('g-recaptcha')[0].remove();";
            ((IJavaScriptExecutor)driver).ExecuteScript(script);


            IWebElement DPI = driver.FindElement(By.Name("txtNumAfiliado"));
            DPI.Clear();
            DPI.SendKeys(_dpi.Trim());

            IWebElement dia = driver.FindElement(By.Name("nacimiento-dia"));
            dia.SendKeys(_nacimiento.Day.ToString("00"));

            IWebElement mes = driver.FindElement(By.Name("nacimiento-mes"));
            mes.SendKeys(_nacimiento.Month.ToString("00"));

            IWebElement year = driver.FindElement(By.Name("nacimiento-anio"));
            year.SendKeys(_nacimiento.Year.ToString());


            IWebElement boton = driver.FindElement(By.Id("btnConsultar"));
            boton.Submit();
            Boolean bandera = true;
            while (bandera)
            {
                IList<IWebElement> hijos = driver.FindElements(By.XPath("//table[@id='zero_config']/tbody/tr/th"));
                int i2 = 0;
                if (hijos.Count > 0)
                {
                    foreach (IWebElement celdashijas in hijos)
                    {
                        string cellhijo = celdashijas.Text.Replace(",", "");

                        if (i2 == 0)
                        {
                            año = Convert.ToInt32(cellhijo.Substring(0,4));
                            _mes = Convert.ToInt32(cellhijo.Substring(5,2));
                            i2++;
                        }
                        else if (i2 == 1)
                        {
                            no_patrono = Convert.ToInt32(cellhijo);
                            i2++;
                        }
                        else if (i2 == 2)
                        {
                            patrono = cellhijo;
                            i2++;
                        }
                        else if (i2 == 3)
                        {
                            razon = cellhijo;
                            i2++;
                        }
                        else if (i2 == 4)
                        {
                            aporto = cellhijo;
                            PatronModel patron = new PatronModel();
                            patron.codigo_patron = no_patrono;
                            patron.nombre = patrono;
                            ControbucionesModel detalle = new ControbucionesModel();
                            detalle.dpi = Convert.ToInt64(_dpi);
                            detalle.codigo_patron = no_patrono;
                            detalle.año = año;
                            detalle.mes = _mes;
                            detalle.razon = razon;
                            if(aporto.ToString().ToUpper() == "SI")
                            {
                                detalle.aporte = "S";
                            } else { detalle.aporte = "N"; }
                            

                            if (conexion.agregar_patrono(patron) == 1)
                            {
                                    conexion.agregar_detalle(detalle);
                                ModelIgss result = new ModelIgss();
                            }

                            i2 = 0;
                        }
                    }
                     ((IJavaScriptExecutor)driver).ExecuteScript("window.Next = function next(){		var link = document.getElementById('zero_config_next');		link.click();	}");
                    ((IJavaScriptExecutor)driver).ExecuteScript("Next()");

                    IWebElement siguiente = driver.FindElement(By.Id("zero_config_next"));
                    if (siguiente.GetAttribute("class").Contains("disabled"))
                    {
                        bandera = false;
                    }
                }
                else {bandera = false;}               
            }

            driver.Close();
            driver.Quit();

            }
            catch (Exception)
            {
                driver.Close();
                driver.Quit();

            }
        }
        public void ANUNCIO(IWebDriver driver)
        {
            try
            {
                if (driver.PageSource.Contains("IDCOVID19"))
                {
                    IWebElement covid = driver.FindElement(By.Id("IDCOVID19"));
                    covid.SendKeys(Keys.Escape);
                }
            }
            catch (Exception)
            {
             
            }

        }
    }
}
