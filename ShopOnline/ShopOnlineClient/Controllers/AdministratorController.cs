using Newtonsoft.Json;
using ShopOnlineClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ShopOnlineClient.Controllers
{
    public class AdministratorController : Controller
    {
        // GET: Administrator
        string Baseurl = "http://localhost:53148";
        public async Task<ActionResult> Index()
        {
            List<AdministratorModels> admin = new List<AdministratorModels>();

            using (var client = new HttpClient())
            {
                //Passing service base url  
                client.BaseAddress = new Uri(Baseurl);

                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                HttpResponseMessage Res = await client.GetAsync("api/Administrators/GetAdministrators");

                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api and storing into the Employee list  
                    admin = JsonConvert.DeserializeObject<List<AdministratorModels>>(EmpResponse);

                }
                //returning the employee list to view  
                return View(admin);
            }
        }
        [HttpPost]
        public ActionResult Create(AdministratorModels admin)
        {
            if (ModelState.IsValid)
            {
                HttpClient client = new HttpClient();
                var result = client.PostAsJsonAsync("http://localhost:53148/api/Administrator", admin).Result;
                if (result.IsSuccessStatusCode)
                {
                    admin = result.Content.ReadAsAsync<AdministratorModels>().Result;
                    ViewBag.Result = "Data Is Successfully Saved!";
                    List<AdministratorModels> list = new List<AdministratorModels>();
                    HttpClient client1 = new HttpClient();
                    var result1 = client1.GetAsync("http://localhost:53148/api/Administrator").Result;
                    if (result1.IsSuccessStatusCode)
                    {
                        list = result1.Content.ReadAsAsync<List<AdministratorModels>>().Result;
                        ViewBag.userdetails = list;
                    }
                    ModelState.Clear();
                    return View(new AdministratorModels());
                }
                else
                {
                    ViewBag.Result = "Error! Please try with valid data.";
                }
            }
            return View(admin);
        }

    }
}