using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SecretProject.Web.Services;

namespace SecretProject.Web.Controllers
{
    [ApiController]
    [Authorize(AuthenticationSchemes = "Basic")]
    [Route("1c/")]
    public class OneCController : ControllerBase
    {
        private readonly ILogger<OneCController> logger;
        private SessionHelper sessionHelper;
        private readonly IWebHostEnvironment environment;

        public OneCController(ILogger<OneCController> logger, SessionHelper sessionHelper, IWebHostEnvironment environment)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.sessionHelper = sessionHelper ?? throw new ArgumentNullException(nameof(sessionHelper));
            this.environment = environment ?? throw new ArgumentNullException(nameof(environment));
        }

        private bool isAdmin()
        {
            return HttpContext.User.HasClaim(c => c.Value == "Admin");
        }

        [HttpGet]
        [Route("env")]
        public IActionResult Enviroment()
        {
            if (!isAdmin())
                return new UnauthorizedResult();
            return new ObjectResult(environment.ContentRootPath);
        }

        public string? CheckNeededCookie()
        {
            string cookieValue = "";
            //if (!HttpContext.Request.Cookies.ContainsKey("SECRET_ONEC_EXCHANGE"))
            //{
            //    Guid cookie = Guid.NewGuid();
            //    logger.LogInformation(cookie.ToString());
            //    cookieValue = cookie.ToString();
            //    HttpContext.Response.Cookies.Append("SECRET_ONEC_EXCHANGE", cookieValue);
            //}
            //else
                if (!HttpContext.Request.Cookies.TryGetValue("SECRET_ONEC_EXCHANGE", out cookieValue))
                return null;

            return cookieValue;
        }
        [HttpGet]
        [Route("exchange")]
        public async Task<IActionResult> Exchange(string type, string mode)
        {

            if (String.IsNullOrEmpty(type) && String.IsNullOrEmpty(mode))
                return StatusCode(206);

            string cookieValue = CheckNeededCookie();
            if (cookieValue == null)
                return StatusCode(206);

            if (mode == "checkauth")
            {
                logger.LogInformation("Auth 1c user");
                string responce = "success\n" + "SECRET_ONEC_EXCHANGE" + "\n" + cookieValue;
                return new ObjectResult(responce);
            }
            else if (mode == "init")
            {
                logger.LogInformation("Set settings of exchange 1c user");
                string zipUse = false ? "yes" : "no";
                // максимальное число файла в байтах
                int fileSizeLimit = 2 * 1024 * 1024;
                string settings = "zip=" + zipUse + "\n" + "file_limit=" + fileSizeLimit;

                //sessionHelper.Save(0, "OneCExchangeTryCount");
                return new ObjectResult(settings);
            }
            else
            {
                return StatusCode(206);
            }
        }

        [HttpPost]
        [Route("exchange")]
        public async Task<IActionResult> Exchange(string type, string mode, string filename)
        {
            string responce = "failure";

            if (String.IsNullOrEmpty(type) && String.IsNullOrEmpty(mode))
                return StatusCode(206);

            string cookieValue = "";
            if (!HttpContext.Request.Cookies.TryGetValue("SECRET_ONEC_EXCHANGE", out cookieValue))
                return BadRequest();

            HttpContext.Response.Cookies.Append("SECRET_ONEC_EXCHANGE", cookieValue);

            filename = String.IsNullOrEmpty(filename) ? "1C_upload_" + type + "_" + DateTime.Now.Day + "_" + DateTime.Now.Month + "_" + DateTime.Now.Year
                : "1C_upload_" + type + "_" + filename + "_" + DateTime.Now.Day + "_" + DateTime.Now.Month + "_" + DateTime.Now.Year;
            if (mode == "file" || mode == "import")
            {
                logger.LogInformation("Try to exchange for 1c!");

                string directoryPath = environment.ContentRootPath + "/Files/1C/";
                DirectoryInfo directory = new DirectoryInfo(directoryPath);
                if (!directory.Exists)
                    directory.Create();
                //sessionHelper.IncreaseSessionNumber(1, "OneCExchangeTryCount");
#if DEBUG
                FileInfo format = new FileInfo(directoryPath + "/format.txt");
                using (var stream = new StreamWriter(format.Open(FileMode.Create)))
                {
                    stream.Write(HttpContext.Request.ContentType);
                    stream.Close();
                }
#endif

                FileInfo file = new FileInfo(directoryPath + "/" + filename + ".xml");
                try
                {
                    using (var stream = new StreamReader(HttpContext.Request.Body))
                    {
                        using (var fileStream = new StreamWriter(file.Open(FileMode.Create)))
                        {

                            string line;
                            while ((line = stream.ReadLine()) != null)
                            {
                                fileStream.Write(line);
                            }
                            fileStream.Close();
                            stream.Close();
                        }
                    }
                    logger.LogInformation("Data from 1C was received succesfully!\n" +
                        "Date of receive:" + DateTime.Now.Date.ToString() +
                        "Time of receive:" + DateTime.Now.ToShortTimeString() + "\n" +
                        $"File:{filename}.xml");
                    responce = "success";
                }
                catch (Exception ex)
                {


                    logger.LogError("By exchanging with 1C !\n" + ex.Message);
                    //int? tryCount = sessionHelper.GetInt("OneCExchangeTryCount");
                    //if (tryCount == null)
                    //    responce = "failure\n" + ex.Message;
                    //else if (tryCount.Value < 3 && tryCount.Value > 0)
                    //    responce = "progress";
                    //else
                        responce = "failure\n" + ex.Message;
                }
            }
            else
                return StatusCode(400);
            return new ObjectResult(responce);
        }
    }
}
