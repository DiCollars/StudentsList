using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudentsList.Models;

namespace StudentsList.Controllers
{
    public class HomeController : Controller
    {
        StudentGroupContext _db;

        public HomeController(StudentGroupContext db)
        {
            _db = db;
        }

        public IActionResult Home()
        {
            var d = _db.Students.Where(s => s.GroupId == 1).ToList();

            var StudentGroup = _db.Groups.Include(p => p.Students);
            return View(StudentGroup.ToList());
        }

        public IActionResult AddOrEdit(int id = 0)
        {
            SelectList groups = new SelectList(_db.Groups, "Id", "GroupName");
            ViewBag.Groups = groups;

            if (id == 0)
            {
                return View(new Student());
            }

            else
            {
                return View(_db.Students.Find(id));
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddOrEdit([Bind("FullName,GroupId,Id")]Student student)
        {
            if (ModelState.IsValid)
            {
                if (student.Id == 0)
                {
                    _db.Add(student);
                }

                else
                {
                    _db.Update(student);
                }

                await _db.SaveChangesAsync();
                return RedirectToRoute(new { controller = "Home", action = "Home" });
            }
            return View(student);
        }

        public IActionResult Delete(int? id)
        {
            _db.Students.Remove(_db.Students.FirstOrDefault(c => c.Id == id));
            _db.SaveChanges();
            return RedirectToRoute(new { controller = "Home", action = "Home" }); ;
        }
    }
}
