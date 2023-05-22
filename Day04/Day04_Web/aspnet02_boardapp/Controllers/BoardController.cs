using aspnet02_boardapp.Data;
using aspnet02_boardapp.Models;
using Microsoft.AspNetCore.Mvc;

namespace aspnet02_boardapp.Controllers
{
    //h
    public class BoardController : Controller
    {
        private readonly ApplicationDBContext _db;

        public BoardController(ApplicationDBContext db)
        {
            _db = db;
        }
        public IActionResult Index()   // 게시판 최초화면 리스트 
        {
            IEnumerable<Board> objBoardList = _db.Boards.ToList();
            return View(objBoardList);
        }

        [HttpGet]
        // https://localhost:7021/Board/Create
        // Get 메서드로 화면을 url로 부를때 액션
        public IActionResult Create()  // 게시판 글쓰기 
        {
            return View();
        }

        // submit이 발생해서 내부로 데이터를 전달 액션 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Board board) 
        {
            _db.Boards.Add(board);   // Insert
            _db.SaveChanges();         // commit

            return RedirectToAction("Index", "Board");
        }
    }
}