using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Data;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Threading;
using System.Web;
using System.Windows.Forms;
using twoCaptcha;
using Excel = Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop.Excel;
using Point = System.Drawing.Point;
using Application = System.Windows.Forms.Application;
using SpreadsheetLight;
using System.Collections.Generic;
using DataTable = System.Data.DataTable;
using System.Threading.Tasks;
using ConsultaSalud.Logica;
using WebDriverManager.DriverConfigs.Impl;
using System.Text;
using MySql.Data.MySqlClient;
using System.Linq;

using OpenQA.Selenium.Interactions;

namespace ConsultaSalud
{
    public partial class Padre : System.Windows.Forms.Form
    {
        DataSet ds = new DataSet();
        DataSet DSProcesado = new DataSet();
        List<PersonaViewModel> lst = new List<PersonaViewModel>();
        PersonaViewModel Persona = new PersonaViewModel();
        List<ModelIgss> ListResult = new List<ModelIgss>();
        List<ModelIgss> ListResulta = new List<ModelIgss>();
        BdComun conexion = new BdComun();
        String _dpi;
        DateTime _fecha;
        loading load;
        string sql = "";
        int año;
        int _mes;
        int no_patrono;
        string patrono;
        string razon;
        string aporto;
        

        public Padre()
        {
            InitializeComponent();
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            string id = "", answer = "";
            var url = "https://registrovacunacovid.mspas.gob.gt/mspas/citas/consulta";
            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl(url);

            var dpi = driver.FindElement(By.XPath("/html/body/app-root/div/app-consulta-cita/body/div[2]/div/div/div[2]/div[1]/div/input"));
            dpi.SendKeys("1577");
            //   Thread.Sleep(10000);
            dpi.SendKeys("05013");
            //    Thread.Sleep(10000);
            dpi.SendKeys("2107");
            //Thread.Sleep(10000);

            var fecha = driver.FindElement(By.XPath("/html/body/app-root/div/app-consulta-cita/body/div[2]/div/div/div[2]/div[2]/div/input"));
            fecha.SendKeys("13/04/1988");

            //String keygoogle = driver.FindElement(By.ClassName("g-recaptcha")).GetAttribute("data-sitekey");
            var keygoogle = driver.FindElement(By.XPath("/html/body/app-root/div/app-consulta-cita/body/div[2]/div/div/div[3]/div/re-captcha/div/div/iframe"));

            var key = keygoogle.GetAttribute("src");
            Uri keys = new Uri(key);
            string google = HttpUtility.ParseQueryString(keys.Query).Get("k");

            Solver solver = new Solver();
            id = solver.post(google);

            ((IJavaScriptExecutor)driver).ExecuteScript("document.getElementById(\"g-recaptcha-response\").style.display = \"inline\";");


            while (true)
            {
                answer = solver.get(id.Substring(3));
                if (answer == "CAPCHA_NOT_READY")
                {
                    Thread.Sleep(2500);
                }
                else { break; }
            }
            if (answer.StartsWith("ERROR_"))
            {

                driver.Close();
                driver.Quit();
                //return answer;
            }
            else
            {
                IWebElement TOKEN = driver.FindElement(By.Id("g-recaptcha-response"));
                TOKEN.SendKeys(answer.Substring(3));

                ((IJavaScriptExecutor)driver).ExecuteScript("___grecaptcha_cfg.clients['0']['G']['G']['callback']('" + answer.Substring(3) + "')");

                IWebElement boton = driver.FindElement(By.XPath("/html/body/app-root/div/app-consulta-cita/body/div[2]/div/div/div[4]/div[1]/button"));
                boton.Submit();


                string wtel = driver.FindElement(By.XPath("/html/body/app-root/div/app-consulta-cita/body/div[2]/div/div/div[1]/div[1]/h6[2]")).Text;
                Match m = Regex.Match(wtel, "(\\d+)");
                string num = string.Empty;
                if (m.Success)
                {
                    num = m.Value;
                }
            }

            driver.Close();
            driver.Quit();
        }

        private void KillAllTasksByName(string taskName)
        {
            try
            {
                foreach (Process proceso in Process.GetProcessesByName(taskName))
                {
                    proceso.Kill();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        private void dataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        public void procesar()
        {
            try
            {

                string call;
                //KillAllTasksByName("chromedriver");
                //KillAllTasksByName("conhost");
                foreach (var persona in lst)
                {
                    PersonaViewModel person = new PersonaViewModel();
                    person = conexion.BuscarP(persona.dpi);

                    if (Convert.ToInt32(person.telefono) > 0)
                    {
                        persona.telefono = person.telefono;
                    }
                    else
                    {
                        string id = "", answer = "";
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
                        driver.Navigate().GoToUrl("https://registrovacunacovid.mspas.gob.gt/mspas/citas/consulta");
                        Thread.Sleep(2000);

                        if (driver.PageSource.Contains("CUI (DPI) / Pasaporte"))
                        {
                            string funcion = "function findRecaptchaClients() {";
                            //funcion = funcion + " // eslint-disable-next-line camelcase ";
                            funcion = funcion + " if (typeof(___grecaptcha_cfg) !== 'undefined') { ";
                            //funcion = funcion + " // eslint-disable-next-line camelcase, no-undef ";
                            funcion = funcion + " return Object.entries(___grecaptcha_cfg.clients).map(([cid, client]) => {";
                            funcion = funcion + " const data = { id: cid, version: cid >= 10000 ? 'V3' : 'V2' };";
                            funcion = funcion + " const objects = Object.entries(client).filter(([_, value]) => value && typeof value === 'object'); ";
                            funcion = funcion + " objects.forEach(([toplevelKey, toplevel]) => { ";
                            funcion = funcion + " const found = Object.entries(toplevel).find(([_, value]) => ( ";
                            funcion = funcion + " value && typeof value === 'object' && 'sitekey' in value && 'size' in value)); ";
                            funcion = funcion + " if (typeof toplevel === 'object' && toplevel instanceof HTMLElement && toplevel['tagName'] === 'DIV'){ ";
                            funcion = funcion + " data.pageurl = toplevel.baseURI; } ";

                            funcion = funcion + " if (found) { const [sublevelKey, sublevel] = found; ";
                            funcion = funcion + " data.sitekey = sublevel.sitekey; ";
                            funcion = funcion + " const callbackKey = data.version === 'V2' ? 'callback' : 'promise-callback'; ";
                            funcion = funcion + " const callback = sublevel[callbackKey]; ";
                            funcion = funcion + " if (!callback)  {  data.callback = null;  data.function = null; } ";
                            funcion = funcion + " else { data.function = callback; const keys = [cid, toplevelKey, sublevelKey, callbackKey].map((key) => `['${key}']`).join(''); ";
                            funcion = funcion + " data.callback = `___grecaptcha_cfg.clients${ keys}`; } } }); return data; }); } return []; } ";

                            ((IJavaScriptExecutor)driver).ExecuteScript("document.getElementById(\"g-recaptcha-response\").style.display = \"inline\";");
                            IWebElement TOKEN = driver.FindElement(By.Id("g-recaptcha-response"));

                            ((IJavaScriptExecutor)driver).ExecuteScript("window.getVoteX1 =" + funcion);
                            ((IJavaScriptExecutor)driver).ExecuteScript("window.Token1 = function token(){ let respuesta = getVoteX1(); return respuesta[0].callback;}");
                            ((IJavaScriptExecutor)driver).ExecuteScript("document.getElementById('g-recaptcha-response').value = Token1()");
                            call = TOKEN.GetAttribute("value");
                            TOKEN.Clear();


                            var dpi = driver.FindElement(By.XPath("/html/body/app-root/div/app-consulta-cita/body/div[2]/div/div/div[2]/div[1]/div/input"));
                            dpi.SendKeys(persona.dpi.ToString());
                            if (driver.PageSource.Contains("Fecha de Nacimiento DD/MM/YYYY"))
                            {
                                var fecha = driver.FindElement(By.XPath("/html/body/app-root/div/app-consulta-cita/body/div[2]/div/div/div[2]/div[2]/div/input"));
                                fecha.SendKeys(persona.fecha.ToString("dd/MM/yyyy"));
                                if (driver.PageSource.Contains("re-captcha"))
                                {

                                    var keygoogle = driver.FindElement(By.XPath("/html/body/app-root/div/app-consulta-cita/body/div[2]/div/div/div[3]/div/re-captcha/div/div/iframe"));

                                    Uri keys = new Uri(keygoogle.GetAttribute("src"));
                                    string google = HttpUtility.ParseQueryString(keys.Query).Get("k");

                                    Solver solver = new Solver();
                                    id = solver.post(google);

                                    ((IJavaScriptExecutor)driver).ExecuteScript("document.getElementById(\"g-recaptcha-response\").style.display = \"inline\";");

                                    while (true)
                                    {
                                        answer = solver.get(id.Substring(3));
                                        if (answer == "CAPCHA_NOT_READY")
                                        {
                                            Thread.Sleep(1500);
                                        }
                                        else { break; }
                                    }
                                    if (answer.StartsWith("ERROR_"))
                                    {

                                        driver.Close();
                                        driver.Quit();
                                    }
                                    else
                                    {

                                        TOKEN.SendKeys(answer.Substring(3));

                                        ((IJavaScriptExecutor)driver).ExecuteScript(call + "('0')");

                                        IWebElement boton = driver.FindElement(By.XPath("/html/body/app-root/div/app-consulta-cita/body/div[2]/div/div/div[4]/div[1]/button"));
                                        boton.Submit();
                                        Thread.Sleep(1500);
                                        if (driver.PageSource.Contains("No se encontraron datos de la persona")) { }
                                        else if (driver.PageSource.Contains("Fecha Inválida.")) { }
                                        else
                                        {
                                            Boolean bandera = true;
                                            int contador = 0;
                                            while (bandera)
                                            {
                                                contador++;
                                                if (driver.PageSource.Contains("Teléfono Registrado"))
                                                {
                                                    bandera = false;
                                                    string wtel = driver.FindElement(By.XPath("/html/body/app-root/div/app-consulta-cita/body/div[2]/div/div/div[1]/div[1]/h6[2]")).Text;
                                                    Match m = Regex.Match(wtel, "(\\d+)");
                                                    string num = string.Empty;
                                                    if (m.Success)
                                                    {
                                                        persona.telefono = int.Parse(m.Value).ToString();
                                                    }
                                                    conexion.Agregar(persona);
                                                }
                                                else
                                                {
                                                    if (contador == 4)
                                                    {
                                                        bandera = false;
                                                    }
                                                    else
                                                    {
                                                        Thread.Sleep(500);
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        driver.Close();
                        driver.Quit();
                    }
                }

            }
            catch (Exception ex)
            {

            }
        }

        public void procesarnew(PersonaViewModel persona)
        {
            PersonaViewModel person = new PersonaViewModel();
            ModelIgss rpersona = new ModelIgss();

            try
            {
                Boolean bandera2 = true;
                string call;
                //  KillAllTasksByName("chromedriver");
                //KillAllTasksByName("conhost");

                person = conexion.BuscarP(persona.dpi);

                if (Convert.ToInt32(person.telefono) > 0)
                {
                    persona.telefono = person.telefono;
                    rpersona.dpi = person.dpi;
                    rpersona.nombre = person.nombre;
                    rpersona.fecha = person.fecha;
                    rpersona.Telefono = person.telefono.ToString();
                    ListResult.Add(rpersona);
                }
                else
                {
                    string id = "", answer = "";
                    ChromeOptions options = new ChromeOptions();
                    options.AddArgument("no-sandbox");

                    options.AddArguments("--disable-extensions"); // to disable extension
                    options.AddArguments("--disable-notifications"); // to disable notification
                    options.AddArguments("--disable-application-cache"); // to disable cache
                    /*options.AddArgument("headless");
                    options.AddArgument("--incognito");
                    options.AddExcludedArgument("enable-automation");
                    options.AddAdditionalCapability("useAutomationExtension", false);*/
                    ChromeDriverService service = ChromeDriverService.CreateDefaultService();
                    service.HideCommandPromptWindow = false;
                    // string workingDirectory = Environment.CurrentDirectory;
                    //string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
                    new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
                    IWebDriver driver = new ChromeDriver(service, options, TimeSpan.FromMinutes(5));
                    driver.Navigate().GoToUrl("https://registrovacunacovid.mspas.gob.gt/mspas/citas/consulta");
                    Thread.Sleep(500);

                    if (driver.PageSource.Contains("CUI (DPI) / Pasaporte"))
                    {
                        string funcion = "function findRecaptchaClients() {";
                        //funcion = funcion + " // eslint-disable-next-line camelcase ";
                        funcion = funcion + " if (typeof(___grecaptcha_cfg) !== 'undefined') { ";
                        //funcion = funcion + " // eslint-disable-next-line camelcase, no-undef ";
                        funcion = funcion + " return Object.entries(___grecaptcha_cfg.clients).map(([cid, client]) => {";
                        funcion = funcion + " const data = { id: cid, version: cid >= 10000 ? 'V3' : 'V2' };";
                        funcion = funcion + " const objects = Object.entries(client).filter(([_, value]) => value && typeof value === 'object'); ";
                        funcion = funcion + " objects.forEach(([toplevelKey, toplevel]) => { ";
                        funcion = funcion + " const found = Object.entries(toplevel).find(([_, value]) => ( ";
                        funcion = funcion + " value && typeof value === 'object' && 'sitekey' in value && 'size' in value)); ";
                        funcion = funcion + " if (typeof toplevel === 'object' && toplevel instanceof HTMLElement && toplevel['tagName'] === 'DIV'){ ";
                        funcion = funcion + " data.pageurl = toplevel.baseURI; } ";

                        funcion = funcion + " if (found) { const [sublevelKey, sublevel] = found; ";
                        funcion = funcion + " data.sitekey = sublevel.sitekey; ";
                        funcion = funcion + " const callbackKey = data.version === 'V2' ? 'callback' : 'promise-callback'; ";
                        funcion = funcion + " const callback = sublevel[callbackKey]; ";
                        funcion = funcion + " if (!callback)  {  data.callback = null;  data.function = null; } ";
                        funcion = funcion + " else { data.function = callback; const keys = [cid, toplevelKey, sublevelKey, callbackKey].map((key) => `['${key}']`).join(''); ";
                        funcion = funcion + " data.callback = `___grecaptcha_cfg.clients${ keys}`; } } }); return data; }); } return []; } ";

                        ((IJavaScriptExecutor)driver).ExecuteScript("document.getElementById(\"g-recaptcha-response\").style.display = \"inline\";");
                        IWebElement TOKEN = driver.FindElement(By.Id("g-recaptcha-response"));

                        ((IJavaScriptExecutor)driver).ExecuteScript("window.getVoteX1 =" + funcion);
                        ((IJavaScriptExecutor)driver).ExecuteScript("window.Token1 = function token(){ let respuesta = getVoteX1(); return respuesta[0].callback;}");
                        ((IJavaScriptExecutor)driver).ExecuteScript("document.getElementById('g-recaptcha-response').value = Token1()");
                        call = TOKEN.GetAttribute("value");
                        TOKEN.Clear();

                        string script = "document.getElementsByName('captcha')[0].remove();";
                        ((IJavaScriptExecutor)driver).ExecuteScript(script);

                        var dpi = driver.FindElement(By.XPath("/html/body/app-root/div/app-consulta-cita/body/div[2]/div/div/div[2]/div[1]/div/input"));
                        dpi.SendKeys(persona.dpi.ToString());
                        if (driver.PageSource.Contains("Fecha de Nacimiento DD/MM/YYYY"))
                        {
                            var fecha = driver.FindElement(By.XPath("/html/body/app-root/div/app-consulta-cita/body/div[2]/div/div/div[2]/div[2]/div/input"));
                            fecha.SendKeys(persona.fecha.ToString("dd/MM/yyyy"));

                            ((IJavaScriptExecutor)driver).ExecuteScript(call + "('0')");

                            IWebElement boton = driver.FindElement(By.XPath("/html/body/app-root/div/app-consulta-cita/body/div[2]/div/div/div[4]/div[1]/button"));
                            boton.Submit();
                            int i = 0;
                            Boolean noentro = false;
                            while (bandera2)
                            {
                                i++;
                                Thread.Sleep(1000);
                                if (driver.PageSource.Contains("No se encontraron datos de la persona"))
                                {
                                    // BdComun.Agregar(persona);
                                    rpersona.dpi = persona.dpi;
                                    rpersona.nombre = persona.nombre;
                                    rpersona.fecha = persona.fecha;
                                    rpersona.Telefono = "No Existe Persona en Salud";
                                    ListResult.Add(rpersona);
                                    bandera2 = false;
                                }
                                else if (driver.PageSource.Contains("Fecha Inválida."))
                                {
                                    rpersona.dpi = persona.dpi;
                                    rpersona.nombre = persona.nombre;
                                    rpersona.fecha = persona.fecha;
                                    rpersona.Telefono = "Fecha Invalida Salud";
                                    ListResult.Add(rpersona);
                                    bandera2 = false;
                                }
                                else
                                {
                                    Boolean bandera = true;
                                    int contador = 0;
                                    while (bandera)
                                    {
                                        contador++;
                                        if (driver.PageSource.Contains("Teléfono Registrado"))
                                        {
                                            bandera = false;
                                            string wtel = driver.FindElement(By.XPath("/html/body/app-root/div/app-consulta-cita/body/div[2]/div/div/div[1]/div[1]/h6[2]")).Text;
                                            Match m = Regex.Match(wtel, "(\\d+)");
                                            string num = string.Empty;
                                            if (m.Success)
                                            {
                                                persona.telefono = int.Parse(m.Value).ToString();
                                            }
                                            //    BdComun.Agregar(persona);
                                            rpersona.dpi = persona.dpi;
                                            rpersona.nombre = persona.nombre;
                                            rpersona.fecha = persona.fecha;
                                            rpersona.Telefono = persona.telefono.ToString();
                                            ListResult.Add(rpersona);
                                            bandera2 = false;
                                        }
                                        else
                                        {
                                            if (contador == 8)
                                            {
                                                bandera = false;
                                                bandera2 = false;
                                                noentro = true;
                                            }
                                            else
                                            {
                                                Thread.Sleep(500);
                                            }
                                        }
                                    }
                                }
                                if (i == 15)
                                {
                                    bandera2 = false;
                                    noentro = true;
                                }
                            }
                            if (noentro)
                            {
                                rpersona.dpi = persona.dpi;
                                rpersona.nombre = persona.nombre;
                                rpersona.fecha = persona.fecha;
                                rpersona.Telefono = "No se Recupero Informacion";
                                ListResult.Add(rpersona);
                            }
                        }
                        else
                        {
                            rpersona.dpi = persona.dpi;
                            rpersona.nombre = persona.nombre;
                            rpersona.fecha = persona.fecha;
                            rpersona.Telefono = "No Cargo Pagina";
                            ListResult.Add(rpersona);
                        }
                    }
                    else
                    {
                        rpersona.dpi = persona.dpi;
                        rpersona.nombre = persona.nombre;
                        rpersona.fecha = persona.fecha;
                        rpersona.Telefono = "No Cargo Pagina";
                        ListResult.Add(rpersona);
                    }
                    driver.Close();
                    driver.Quit();
                }

            }
            catch (Exception ex)
            {
                rpersona.dpi = persona.dpi;
                rpersona.nombre = persona.nombre;
                rpersona.fecha = persona.fecha;
                rpersona.Telefono = "No Existe Persona";
                ListResult.Add(rpersona);
            }
        }

        private void Exit_Click_1(object sender, EventArgs e)
        {
            //KillAllTasksByName("chromedriver");
            //KillAllTasksByName("conhost");

            Application.Exit();
        }

        private void Buscar_Click(object sender, EventArgs e)
        {
            load = new loading();
            load.ShowDialog();
            List<PersonaViewModel> persona = load.Person;
            if (persona.Count > 0)
            {
                lst.Clear();
                lst = persona;
                dataGrid.DataSource = null;
                dataGrid.DataSource = lst;
            }

        }

        private async void ProcessIGSS_Click(object sender, EventArgs e)
        {
            try
            {
                ListResult.Clear();
                if (lst.Count > 0)
                {

                    Mensaje.Text = "Procesando Archivo";

                    ChromeOptions options = new ChromeOptions();
                    ModelIgss rpersona = new ModelIgss();
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

                    foreach (var persona in lst)
                    {
                        ModelIgss person = new ModelIgss();
                        person.dpi = persona.dpi;
                        person.fecha = persona.fecha;
                        person.nombre = persona.nombre;
                        if (persona.telefono != null)
                        {
                            if (persona.telefono.All(char.IsDigit))
                            { person.Telefono = persona.telefono; }
                            else { person.Telefono = "0"; }
                        }
                        else { person.Telefono = "0"; }
                        if (conexion.Agregarnew(person) == 1)
                        {
                            
                            RealizarConsulta(persona,driver);

                        }
                    }

                    driver.Close();
                    driver.Quit();

                    //foreach (var persona in lst)
                    //{
                    //    PersonaViewModel person = new PersonaViewModel();
                    //    person.dpi = persona.dpi;
                    //    person.fecha = persona.fecha;
                    //    person.nombre = persona.nombre;
                    //    if (persona.telefono != null)
                    //    {
                    //        if (persona.telefono.All(char.IsDigit))
                    //        { person.telefono = persona.telefono; }
                    //       else { person.telefono = "0"; }
                    //   }
                    //   else { person.telefono = "0"; }
                    //    if (BdComun.Agregar(person)==1)
                    //    {
                    //        RealizarConsulta(person);
                    //    }
                    //}


                    //Task task = new Task(() =>
                    //{
                    //    Parallel.ForEach(lst,
                    //         new ParallelOptions { MaxDegreeOfParallelism = 3 },
                    //         persona =>
                    //         {
                    //                 RealizarConsulta(persona);
                    //         });
                    //});
                    //task.Start();

                    //await task;
                    Mensaje.Text = "Archivo Procesado";
                    //List<ModelIgss> results =

                    sql = "";
                    int conta = 1;
                    foreach (var persona in lst)
                    {
                        if (conta == lst.Count) { sql = sql + persona.dpi; }
                        else { sql = sql + persona.dpi + ","; }
                        conta++;
                    }
                    List<ModelIgss> result = new List<ModelIgss>();
                    result = conexion.Buscarnew(sql);
                    // frmExito.ErrorMensaje("Archivo Procesado");
                    frmSalud frm = new frmSalud();
                    frm.result = result;
                    frm.label1.Text = "Resultado de Busqueda en IGSS";
                    frm.ShowDialog();
                }
                else
                { alerta.ErrorMensaje("Debe de Cargar un Archivo"); }
            }
            catch (Exception ex)
            {
                alerta.ErrorMensaje("Error al procesar IGSS " + ex.ToString());
                
               
            }
            
        }


        public void ConsultaIgss()
        {
            //KillAllTasksByName("chromedriver");
            //KillAllTasksByName("conhost");
            csIgss igss = new csIgss();
            igss.RealizarConsulta(_dpi.ToString(), _fecha);
        }

        private async void process_igss_salud_Click(object sender, EventArgs e)
        {
            ListResult.Clear();
            ListResulta.Clear();
            if (lst.Count > 0)
            {

                
                Mensaje.Text = "Procesando Archivo";
               

                Task task = new Task(() =>
                {
                    Parallel.ForEach(lst,
                         new ParallelOptions { MaxDegreeOfParallelism = 5 },
                         persona =>
                         {
                             procesarnew(persona);
                         });
                });
                task.Start();
                await task;

                foreach (var persona in ListResult)
                {
                    ModelIgss person = new ModelIgss();
                    person.dpi = persona.dpi;
                    person.fecha = persona.fecha;
                    person.nombre = persona.nombre;
                    if (persona.Telefono != null)
                    {
                        if (persona.Telefono.All(char.IsDigit))
                        { person.Telefono = persona.Telefono; }
                        else { person.Telefono = "0"; }
                    }
                    else { person.Telefono = "0"; }
                    if (conexion.Agregarnew(person) == 1)
                    {
                        RealizarConsulta2(persona);
                    }
                }
                Mensaje.Text = "Archivo Procesado";
                frmSalud frm = new frmSalud();
                frm.result = ListResulta;
                frm.label1.Text = "Resultado de Busqueda en Salud e IGSS";
                frm.ShowDialog();
            }
            else { alerta.ErrorMensaje("Debe de Cargar un Archivo"); }
        }

        private async void process_Click(object sender, EventArgs e)
        {
            ListResult.Clear();
            if (lst.Count > 0)
            {
                // KillAllTasksByName("chromedriver");
                //KillAllTasksByName("conhost");

                Mensaje.Text = "Procesando Archivo";
                Task task = new Task(() =>
                   {
                       Parallel.ForEach(lst,
                            new ParallelOptions { MaxDegreeOfParallelism = 5 },
                            persona =>
                        {
                            procesarnew(persona);
                        });
                   });
                task.Start();
                await task;

                //foreach (var persona in lst)
                //{
                //    procesarnew(persona);
                //}

                foreach (var per in ListResult)
                {
                    PersonaViewModel person = new PersonaViewModel();
                    person.dpi = per.dpi;
                    person.nombre = per.nombre;
                    person.telefono = per.Telefono;
                    person.fecha = per.fecha;
                    if (per.Telefono.All(char.IsDigit))
                    {
                        conexion.Agregar(person);
                    }
                }
                Mensaje.Text = "Archivo Procesado";
                // frmExito.ErrorMensaje("Archivo Procesado");
                frmSalud frm = new frmSalud();
                frm.result = ListResult;
                frm.label1.Text = "Resultado de Busqueda en Salud";
                frm.ShowDialog();

            }
            else { alerta.ErrorMensaje("Debe de Cargar un Archivo"); }
        }

        private void Excel_Click(object sender, EventArgs e)
        {
            try
            {
                lst.Clear();
                dataGrid.DataSource = null;
                Mensaje.Text = "Cargando Archivo";
                ds.Clear();

                OpenFileDialog abrir = new OpenFileDialog();
                abrir.Filter = "Excel Files |*.xlsx";
                abrir.Title = "Seleccione el archivo de Excel";
                if (abrir.ShowDialog() == DialogResult.OK)
                {

                    if (abrir.FileName.Equals("") == false)
                    {


                        SLDocument sl = new SLDocument(abrir.FileName);
                        int celda = 2;

                        while (!string.IsNullOrEmpty(sl.GetCellValueAsString(celda, 1)))
                        {
                            PersonaViewModel persona = new PersonaViewModel();
                            persona.codigo = sl.GetCellValueAsString(celda, 1);
                            persona.nombre = sl.GetCellValueAsString(celda, 2);
                            persona.dpi = sl.GetCellValueAsInt64(celda, 3);
                            persona.fecha = sl.GetCellValueAsDateTime(celda, 4);
                            lst.Add(persona);
                            celda++;
                        }
                        dataGrid.DataSource = lst;


                    }
                }
                Mensaje.Text = "Archivo Cargando";
            }
            catch (Exception ex)
            {
                alerta.ErrorMensaje("Existe un problema con el Archivo. Favor de Verificar");
            }
        }

        private void showsubmenu(Panel submenu)
        {
            if (submenu.Visible == false)
            {
                hideSubMenu();
                submenu.Visible = true;
            }
            else
            {
                submenu.Visible = false;
            }
        }
        private void showsubmenudescarga(Panel submenu)
        {
            if (submenu.Visible == false)
            {
                hideSubdescarga();
                submenu.Visible = true;
            }
            else
            {
                submenu.Visible = false;
            }
        }
        private void process_Click_1(object sender, EventArgs e)
        {
            showsubmenu(submenu);
        }

        private void hideSubMenu()
        {
            submenu.Visible = false;
        }
        private void hideSubdescarga()
        {
            submenudescarga.Visible = false;
        }
        private void download_Click(object sender, EventArgs e)
        {
            if (lst.Count > 0)
            {
                sql = "";
                int conta = 1;
                foreach (var persona in lst)
                {
                    if (conta == lst.Count) { sql = sql + persona.dpi; }
                    else { sql = sql + persona.dpi + ","; }
                    conta++;
                }
                Mensaje.Text = "Iniciando Descargar";
                List<PersonaViewModel> result = new List<PersonaViewModel>();
                SaveFileDialog csv = new SaveFileDialog();
                // saveFileDialog1.Filter = "Excel Files |*.xlsx";
                csv.Filter = "Excel Files |*.xlsx";
                csv.Title = "Seleccione en donde quiere guardar su archivo";
                if (csv.ShowDialog() == DialogResult.OK)
                {
                    SLDocument sl = new SLDocument();
                    DataTable dt = new DataTable();
                    dt.Columns.Add("Codigo");
                    dt.Columns.Add("Nombre");
                    dt.Columns.Add("DPI");
                    dt.Columns.Add("FechaNacimeinto");
                    dt.Columns.Add("NoTelefono");
                    result = conexion.BuscarTelefono(sql);
                    foreach (var dato in result)
                    {
                        DataRow dr = dt.NewRow();
                        dr["Codigo"] = dato.codigo;
                        dr["Nombre"] = dato.nombre;
                        dr["DPI"] = dato.dpi;
                        dr["FechaNacimeinto"] = dato.fecha.ToString("dd/MM/yyyy");
                        dr["NoTelefono"] = dato.telefono;
                        dt.Rows.Add(dr);
                    }

                    sl.ImportDataTable(1, 1, dt, true);
                    sl.SaveAs(csv.FileName);
                }
                Mensaje.Text = "Descarga Finalizada";
                frmExito.ErrorMensaje("Archivo Descargado");
            }
        }
        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {
            try
            {

                if (lst.Count > 0)
                {
                    sql = "";
                    int conta = 1;
                    foreach (var persona in lst)
                    {
                        if (conta == lst.Count) { sql = sql + persona.dpi; }
                        else { sql = sql + persona.dpi + ","; }
                        conta++;
                    }
                    Mensaje.Text = "Iniciando Descargar";
                    SaveFileDialog csv = new SaveFileDialog();
                    // saveFileDialog1.Filter = "Excel Files |*.xlsx";
                    csv.Filter = "Excel Files |*.xlsx";
                    csv.Title = "Seleccione en donde quiere guardar su archivo";
                    if (csv.ShowDialog() == DialogResult.OK)
                    {
                        SLDocument sl = new SLDocument();
                        DataTable dt = new DataTable();
                        dt.Columns.Add("DPI");
                        dt.Columns.Add("Nombre");
                        dt.Columns.Add("FechaNacimeinto");
                        dt.Columns.Add("Telefono");
                        dt.Columns.Add("CodigoPatrono");
                        dt.Columns.Add("NombrePatrono");
                        dt.Columns.Add("RazonSocial");
                        dt.Columns.Add("MES");
                        dt.Columns.Add("AÑO");
                        dt.Columns.Add("Aporte");
                        List<ModelIgss> result = new List<ModelIgss>();
                        result = conexion.BuscarM(sql);
                        foreach (var dato in result)
                        {
                            DataRow dr = dt.NewRow();
                            dr["DPI"] = dato.dpi;
                            dr["Nombre"] = dato.nombre;
                            dr["FechaNacimeinto"] = dato.fecha.ToString("dd/MM/yyyy");
                            dr["Telefono"] = dato.Telefono;
                            dr["CodigoPatrono"] = dato.codigo_patron;
                            dr["NombrePatrono"] = dato.nombre_patrono;
                            dr["AÑO"] = dato.año;
                            dr["MES"] = dato.mes;
                            dr["RazonSocial"] = dato.razon;
                            dr["Aporte"] = dato.aporte;
                            dt.Rows.Add(dr);
                        }

                        sl.ImportDataTable(1, 1, dt, true);
                        sl.SaveAs(csv.FileName);

                        //csv.DefaultExt = ".csv";
                        //EscribirCsv(dt, csv.FileName.Replace(".xlsx", ".csv"));
                    }
                    Mensaje.Text = "Descarga Finalizada";
                    frmExito.ErrorMensaje("Archivo Descargado");
                }

            }
            catch (Exception ex)
            {

                alerta.ErrorMensaje("Hay un error, " + ex.ToString());
            }
        }

        //public void EscribirCsv(DataTable dataTable, string filePath)
        //{

        //    StringBuilder fileContent = new StringBuilder();

        //    foreach (var col in dataTable.Columns)
        //    {
        //        fileContent.Append(col.ToString() + ",");
        //    }

        //    fileContent.Replace(",", System.Environment.NewLine, fileContent.Length - 1, 1);

        //    foreach (DataRow dr in dataTable.Rows)
        //    {
        //        foreach (var column in dr.ItemArray)
        //        {
        //            fileContent.Append(column.ToString() + ",");
        //        }

        //        fileContent.Replace(",", System.Environment.NewLine, fileContent.Length - 1, 1);
        //    }

        //    System.IO.File.WriteAllText(filePath, fileContent.ToString());
        //}

        private void Padre_Load(object sender, EventArgs e)
        {
            try
            {

                //MySqlConnection conexion = BdComun.ObtenerConexion();
                //String sql;
                //sql = "SELECT COUNT(1) CANTIDAD FROM PERSONAS  WHERE TELEFONO > 0; ";
                //MySqlCommand command = new MySqlCommand(string.Format(sql), conexion);
                //MySqlDataReader reader = command.ExecuteReader();
                //while (reader.Read())
                //{
                //    lbcantidad.Text = reader.GetInt32(0).ToString();
                //}
                
                    hideSubMenu();
                hideSubdescarga();
                //conexion.Close();

            }
            catch (Exception ex)
            {
                alerta.ErrorMensaje("No es Posible conectarse a la base de datos " + ex.ToString());
            }
        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            showsubmenudescarga(submenudescarga);
        }
        public async void RealizarConsulta(PersonaViewModel persona, IWebDriver driver)
         {
            ModelIgss rpersona = new ModelIgss();

            /*ChromeOptions options = new ChromeOptions();
            
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
            IWebDriver driver = new ChromeDriver(service, options, TimeSpan.FromMinutes(5));*/
           

            try
            {

                // driver.Manage().Timeouts().PageLoad.Add(TimeSpan.FromSeconds(190));


                driver.Navigate().GoToUrl("https://www.igssgt.org/cuotas/");
                Thread.Sleep(1500);
                ANUNCIO(driver);
                bool nuevoAnuncio;

                string script = "document.getElementsByClassName('g-recaptcha')[0].remove();";
                ((IJavaScriptExecutor)driver).ExecuteScript(script);


                IWebElement DPI = driver.FindElement(By.Name("txtNumAfiliado"));
                DPI.Clear();
                DPI.SendKeys(persona.dpi.ToString().Trim());

                IWebElement dia = driver.FindElement(By.Name("nacimiento-dia"));
                if (persona.fecha.Day.ToString("00") == "22")
                {
                    dia.SendKeys("222");

                }
                else
                {
                    dia.SendKeys(persona.fecha.Day.ToString("00"));
                }

                IWebElement mes = driver.FindElement(By.Name("nacimiento-mes"));
                mes.SendKeys(persona.fecha.Month.ToString("00"));

                IWebElement year = driver.FindElement(By.Name("nacimiento-anio"));
                year.SendKeys(persona.fecha.Year.ToString());

                try
                {
                    driver.FindElement(By.Id("contenedor-imagen"));
                    nuevoAnuncio = true;
                }
                catch
                {
                    nuevoAnuncio = false;
                }

                if (nuevoAnuncio)
                {

                    string quitarAnuncio = "ocultarImagen();";
                    ((IJavaScriptExecutor)driver).ExecuteScript(quitarAnuncio);

                }

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
                                año = Convert.ToInt32(cellhijo.Substring(0, 4));
                                _mes = Convert.ToInt32(cellhijo.Substring(5, 2));
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
                                detalle.dpi = persona.dpi;
                                detalle.codigo_patron = no_patrono;
                                detalle.año = año;
                                detalle.mes = _mes;
                                detalle.razon = razon;
                                string _aporto;
                                if (aporto.ToString().ToUpper() == "SI")
                                {
                                    _aporto = "S";
                                    detalle.aporte = "S";
                                }
                                else
                                {
                                    _aporto = "N";
                                    detalle.aporte = "N";
                                }

                                if (conexion.agregar_patrono(patron) == 1)
                                {

                                    conexion.agregar_detalle(no_patrono, Convert.ToDecimal(persona.dpi), _mes, año, razon, _aporto, patrono);

                                    rpersona.dpi = persona.dpi;
                                    rpersona.nombre = persona.nombre;
                                    rpersona.fecha = persona.fecha;
                                    if (persona.telefono == null)
                                    {
                                        rpersona.Telefono = "0";
                                    }
                                    else
                                    {
                                        rpersona.Telefono = persona.telefono.ToString();
                                    }
                                    rpersona.codigo_patron = patron.codigo_patron;
                                    rpersona.nombre_patrono = patron.nombre;
                                    rpersona.año = detalle.año;
                                    rpersona.mes = detalle.mes;
                                    rpersona.razon = detalle.razon;
                                    rpersona.aporte = detalle.aporte;
                                    ListResult.Add(rpersona);
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
                    else
                    {

                        rpersona.dpi = persona.dpi;
                        rpersona.nombre = persona.nombre;
                        rpersona.fecha = persona.fecha;
                        if (persona.telefono == null)
                        {
                            rpersona.Telefono = "0";
                        }
                        else
                        {
                            rpersona.Telefono = persona.telefono.ToString();
                        }
                        rpersona.nombre_patrono = "No Existen Datos IGSS";
                        ListResult.Add(rpersona);
                        bandera = false;
                    }
                } //While bandera
                //driver.Navigate().GoToUrl("https://www.igssgt.org/cuotas/");
               /* driver.Close();
                driver.Quit();*/

            }
            catch (Exception EX)
            {
                rpersona.dpi = persona.dpi;
                rpersona.nombre = persona.nombre;
                rpersona.fecha = persona.fecha;
                if (persona.telefono == null)
                {
                    rpersona.Telefono = "0";
                }
                else
                {
                    rpersona.Telefono = persona.telefono.ToString();
                }
                rpersona.nombre_patrono = "No Existen Datos IGSS";
                ListResult.Add(rpersona);
                RealizarConsulta(persona, driver);
                
            }
        }
        public async void RealizarConsulta3(ModelIgss persona)
        {
            ChromeOptions options = new ChromeOptions();
            ModelIgss rpersona = new ModelIgss();
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

                // driver.Manage().Timeouts().PageLoad.Add(TimeSpan.FromSeconds(190));
                driver.Navigate().GoToUrl("https://www.igssgt.org/cuotas/");
                Thread.Sleep(2000);
                ANUNCIO(driver);

                string script = "document.getElementsByClassName('g-recaptcha')[0].remove();";
                ((IJavaScriptExecutor)driver).ExecuteScript(script);


                IWebElement DPI = driver.FindElement(By.Name("txtNumAfiliado"));
                DPI.Clear();
                DPI.SendKeys(persona.dpi.ToString().Trim());

                IWebElement dia = driver.FindElement(By.Name("nacimiento-dia"));
                dia.SendKeys(persona.fecha.Day.ToString("00"));

                IWebElement mes = driver.FindElement(By.Name("nacimiento-mes"));
                mes.SendKeys(persona.fecha.Month.ToString("00"));

                IWebElement year = driver.FindElement(By.Name("nacimiento-anio"));
                year.SendKeys(persona.fecha.Year.ToString());


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
                                año = Convert.ToInt32(cellhijo.Substring(0, 4));
                                _mes = Convert.ToInt32(cellhijo.Substring(5, 2));
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
                                detalle.dpi = persona.dpi;
                                detalle.codigo_patron = no_patrono;
                                detalle.año = año;
                                detalle.mes = _mes;
                                detalle.razon = razon;
                                string _aporto;
                                if (aporto.ToString().ToUpper() == "SI")
                                {
                                    _aporto = "S";
                                    detalle.aporte = "S";
                                }
                                else { _aporto = "N"; 
                                    detalle.aporte = "N"; }

                                if (conexion.agregar_patrono(patron) == 1)
                                {
                                    
                                        conexion.agregar_detalle(no_patrono,Convert.ToDecimal(persona.dpi),_mes, año,razon,_aporto, patrono);
                                    
                                    rpersona.dpi = persona.dpi;
                                    rpersona.nombre = persona.nombre;
                                    rpersona.fecha = persona.fecha;
                                    if (persona.Telefono == null)
                                    {
                                        rpersona.Telefono = "0";
                                    }           else
                                    {
                                        rpersona.Telefono = persona.Telefono.ToString();
                                    }
                                    rpersona.codigo_patron = patron.codigo_patron;
                                    rpersona.nombre_patrono = patron.nombre;
                                    rpersona.año = detalle.año;
                                    rpersona.mes = detalle.mes;
                                    rpersona.razon = detalle.razon;
                                    rpersona.aporte = detalle.aporte;
                                    ListResult.Add(rpersona);
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
                    else
                    {

                        rpersona.dpi = persona.dpi;
                        rpersona.nombre = persona.nombre;
                        rpersona.fecha = persona.fecha;
                        if (persona.Telefono == null)
                        {
                            rpersona.Telefono = "0";
                        }
                        else
                        {
                            rpersona.Telefono = persona.Telefono.ToString();
                        }
                        rpersona.nombre_patrono = "No Existen Datos IGSS";
                        ListResult.Add(rpersona);
                        bandera = false;
                    }
                }

                driver.Close();
                driver.Quit();

            }
            catch (Exception)
            {
                rpersona.dpi = persona.dpi;
                rpersona.nombre = persona.nombre;
                rpersona.fecha = persona.fecha;
                if (persona.Telefono == null)
                {
                    rpersona.Telefono = "0";
                }
                else
                {
                    rpersona.Telefono = persona.Telefono.ToString();
                }
                rpersona.nombre_patrono = "No Existen Datos IGSS";
                ListResult.Add(rpersona);
                driver.Close();
                driver.Quit();

            }
        }
        public void RealizarConsulta2(ModelIgss persona)
        {
            ChromeOptions options = new ChromeOptions();
            ModelIgss rpersona = new ModelIgss();
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

                // driver.Manage().Timeouts().PageLoad.Add(TimeSpan.FromSeconds(190));
                driver.Navigate().GoToUrl("https://www.igssgt.org/cuotas/");
                Thread.Sleep(2000);
                ANUNCIO(driver);

                string script = "document.getElementsByClassName('g-recaptcha')[0].remove();";
                ((IJavaScriptExecutor)driver).ExecuteScript(script);


                IWebElement DPI = driver.FindElement(By.Name("txtNumAfiliado"));
                DPI.Clear();
                DPI.SendKeys(persona.dpi.ToString().Trim());

                IWebElement dia = driver.FindElement(By.Name("nacimiento-dia"));
                dia.SendKeys(persona.fecha.Day.ToString("00"));

                IWebElement mes = driver.FindElement(By.Name("nacimiento-mes"));
                mes.SendKeys(persona.fecha.Month.ToString("00"));

                IWebElement year = driver.FindElement(By.Name("nacimiento-anio"));
                year.SendKeys(persona.fecha.Year.ToString());


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
                                año = Convert.ToInt32(cellhijo.Substring(0, 4));
                                _mes = Convert.ToInt32(cellhijo.Substring(5, 2));
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
                                detalle.dpi = persona.dpi;
                                detalle.codigo_patron = no_patrono;
                                detalle.año = año;
                                detalle.mes = _mes;
                                detalle.razon = razon;
                                if (aporto.ToString().ToUpper() == "SI")
                                {
                                    detalle.aporte = "S";
                                }
                                else { detalle.aporte = "N"; }


                                if (conexion.agregar_patrono(patron) == 1)
                                {
                                    conexion.agregar_detalle(detalle);

                                    rpersona.dpi = persona.dpi;
                                    rpersona.nombre = persona.nombre;
                                    rpersona.fecha = persona.fecha;
                                    if (persona.Telefono == null)
                                    {
                                        rpersona.Telefono = "0";
                                    }
                                    else
                                    {
                                        rpersona.Telefono = persona.Telefono.ToString();
                                    }
                                    rpersona.codigo_patron = patron.codigo_patron;
                                    rpersona.nombre_patrono = patron.nombre;
                                    rpersona.año = detalle.año;
                                    rpersona.mes = detalle.mes;
                                    rpersona.razon = detalle.razon;
                                    rpersona.aporte = detalle.aporte;
                                    ListResulta.Add(rpersona);
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
                    else
                    {
                        rpersona.dpi = persona.dpi;
                        rpersona.nombre = persona.nombre;
                        rpersona.fecha = persona.fecha;
                        if (persona.Telefono == null)
                        {
                            rpersona.Telefono = "0";
                        }
                        else
                        {
                            rpersona.Telefono = persona.Telefono.ToString();
                        }
                        rpersona.nombre_patrono = "No Existen Datos IGSS";
                        ListResulta.Add(rpersona);
                        bandera = false;
                    }
                }

                driver.Close();
                driver.Quit();

            }
            catch (Exception)
            {
                rpersona.dpi = persona.dpi;
                rpersona.nombre = persona.nombre;
                rpersona.fecha = persona.fecha;
                if (persona.Telefono == null)
                {
                    rpersona.Telefono = "0";
                }
                else
                {
                    rpersona.Telefono = persona.Telefono.ToString();
                }
                rpersona.nombre_patrono = "No Existen Datos IGSS";
                ListResulta.Add(rpersona);
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
                    covid.SendKeys(OpenQA.Selenium.Keys.Escape);
                }
            }
            catch (Exception)
            {

            }

        }

        private void ProcessSAt_Click(object sender, EventArgs e)
        {
            if (lst.Count > 0)
            {
                // KillAllTasksByName("chromedriver");
                //KillAllTasksByName("conhost");

                //Mensaje.Text = "Procesando Archivo";
                //Task task = new Task(() =>
                //{
                //    Parallel.ForEach(lst,
                //         new ParallelOptions { MaxDegreeOfParallelism = 5 },
                //         persona =>
                //         {
                //             procesarnew(persona);
                //         });
                //});
                //task.Start();
                //await task;

                foreach (var persona in lst)
                {
                    procesarSAT(persona);
                }
                                
            }
            else { alerta.ErrorMensaje("Debe de Cargar un Archivo"); }
        }
        public void procesarSAT(PersonaViewModel persona)
        {

            ChromeOptions options = new ChromeOptions();
            ModelIgss rpersona = new ModelIgss();
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

                // driver.Manage().Timeouts().PageLoad.Add(TimeSpan.FromSeconds(190));
                driver.Navigate().GoToUrl("https://cdn.c.sat.gob.gt/rtu/constancia-rtu-portal");
                Thread.Sleep(750);
                ((IJavaScriptExecutor)driver).ExecuteScript("document.getElementsByName(\"g-recaptcha-response\")[0].style = \"inline\"");
                ((IJavaScriptExecutor)driver).ExecuteScript("document.getElementsByName(\"h-captcha-response\")[0].style = \"inline\"");




                driver.Close();
                driver.Quit();
            }
            catch (Exception ex)
            {
                driver.Close();
                driver.Quit();
            }

        }

        private void bunifuFlatButton1_Click_1(object sender, EventArgs e)
        {
            /*BdComun.borrarDatos();
            frmExito.ErrorMensaje("Se Borraron los Datos");*/
            try
            {
                lst.Clear();
                dataGrid.DataSource = null;
                Mensaje.Text = "Cargando Archivo";
                ds.Clear();

                OpenFileDialog abrir = new OpenFileDialog();
                abrir.Filter = "Excel Files |*.xlsx";
                abrir.Title = "Seleccione el archivo de Excel";
                if (abrir.ShowDialog() == DialogResult.OK)
                {

                    if (abrir.FileName.Equals("") == false)
                    {


                        SLDocument sl = new SLDocument(abrir.FileName);
                        int celda = 2;

                        while (!string.IsNullOrEmpty(sl.GetCellValueAsString(celda, 1)))
                        {
                            PersonaViewModel persona = new PersonaViewModel();
                            persona.codigo = sl.GetCellValueAsString(celda, 1);
                            persona.nombre = sl.GetCellValueAsString(celda, 2);
                            persona.dpi = sl.GetCellValueAsInt64(celda, 3);
                            persona.fecha = sl.GetCellValueAsDateTime(celda, 4);
                            persona.telefono = sl.GetCellValueAsString(celda, 5);
                            lst.Add(persona);
                            conexion.AgregarTelefono(persona);
                            celda++;
                        }
                        dataGrid.DataSource = lst;


                    }
                }
                Mensaje.Text = "Archivo Cargando";
            }
            catch (Exception ex)
            {
                alerta.ErrorMensaje("Existe un problema con el Archivo. Favor de Verificar");
            }
        }
    }
}
