using aspnet02_boardapp.Data;
using aspnet03_portfoiloWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace aspnet03_portfoiloWebApp.Controllers
{
    public class PortfolioController : Controller
    {
        private readonly ApplicationDbContext _db;

        // 파일 업로드 웹환경 객체 (필수 - 웹을 통해서 파일을 업로드)
        private readonly IWebHostEnvironment _environment;

        public PortfolioController(ApplicationDbContext db, IWebHostEnvironment environment)
        {
            _db = db;
            _environment = environment;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var list = _db.Portfolios.ToList(); //SELECT *
            return View(list);
        }

        [HttpGet]
        public IActionResult Create()
        {
            // 포폴 모델 말고 템프 포폴 모델
            return View();
        }

        [HttpPost]
        public IActionResult Create(TemPortfolioModel temp) 
        {
            // 파일 업로드 , Temp -> Model db 저장
            if (ModelState.IsValid) 
            {
                // 파일 업로드되면 새로운 이미지 파일명을 받음 
                string upFileName = UploadImageFile(temp);

                // TemPortfolioModel -> PortfolioModel 변경
                var portfolio = new PortfolioModel()
                {
                    Division = temp.Division,
                    Title = temp.Title,
                    Description = temp.Description,
                    Url = temp.Url,
                    FileName = upFileName       // 핵심 -> 파일을 그대로 안쓰고 업로드 되는 파일 이름을 쓰기 때문에 
                };

                _db.Portfolios.Add(portfolio);
                _db.SaveChanges();

                TempData["succeed"] = "포트폴리오 저장 완료"; 
                return RedirectToAction("Index", "Portfolio");
            }
            return View(temp);
        }

        // 내부 메서드 -> 라우팅이나 GET/POST 관계없음 
        private string UploadImageFile(TemPortfolioModel temp)
        {
            var resultFileName = "";

            try
            { 
                if (temp.PortfolioImage != null) 
                {
                    string uploadFolder = Path.Combine(_environment.WebRootPath, "uploads");      // wwwroot 밑에 upload라는 폴더 존재    
                    resultFileName = Guid.NewGuid() + temp.PortfolioImage.FileName;     // 중복된 이미지 파일명 제거 
                    string filePath = Path.Combine(uploadFolder, resultFileName);

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        temp.PortfolioImage.CopyTo(fileStream);
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
          

            return resultFileName;
        }
    }
}
