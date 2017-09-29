using Microsoft.AspNet.Identity;
using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using VolkerBook.Models;

namespace VolkerBook.Controllers
{
    public class MemberController : Controller

    {

        private readonly ApplicationDbContext _context;

        public MemberController()
        {
            _context = new ApplicationDbContext();
        }

        [Authorize(Users = "guns_bombs@hotmail.co.uk")]
        public ActionResult Create()
        {
            var userId = GetCurrentUserId();
            return View();

        }

        [Authorize(Users = "guns_bombs@hotmail.co.uk")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Members viewModel)
        {

            if (ModelState.IsValid)
            {
                var members = new Members()
                {
                    MemberId = new Guid(User.Identity.GetUserId()),
                    FirstName = viewModel.FirstName,
                    LastName = viewModel.LastName,
                    Role = viewModel.Role,
                    PhoneNumber = viewModel.PhoneNumber
                };
                _context.Members.Add(members);
                _context.SaveChanges();
                return RedirectToAction("Edit", "Member");
            }

            return View();


        }

        [Authorize(Users = "guns_bombs@hotmail.co.uk")]
        public ActionResult Edit()
        {

            var userId = GetCurrentUserId();
            //return View(_context.Members.Where(x => x.MemberId == userId).ToList()); // Return only results created by corresponding account GUID
            return View(_context.Members.Where(x => x.MemberId != null).ToList());
        }

        [Authorize(Users = "guns_bombs@hotmail.co.uk")]
        public ActionResult EditMember(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Members members = _context.Members.Find(id);

            if (members == null)
            {
                return HttpNotFound();
            }
            ViewBag.userId = GetCurrentUserId();
            return View(members);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Users = "guns_bombs@hotmail.co.uk")]
        public ActionResult EditMember([Bind(Include = "Id,MemberId,FirstName,LastName,Role,PhoneNumber")] Members members)
        {

            if (ModelState.IsValid)
            {
                _context.Entry(members).State = EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("Edit");
            }
            ViewBag.userId = GetCurrentUserId();

            return View(members);
        }

        [Authorize(Users = "guns_bombs@hotmail.co.uk")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Members attendee = _context.Members.Find(id);
            //if (attendee == null || !EnsureIsUserMember(attendee))
            //{
            //   return HttpNotFound();
            //}
            return View(attendee);
        }

        // POST: Members/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Users = "guns_bombs@hotmail.co.uk")]
        public ActionResult DeleteConfirmed(int id)
        {
            Members members = _context.Members.Find(id);
            if (!EnsureIsUserMember(members))
            {
                return HttpNotFound();
            }
            if (members != null) _context.Members.Remove(members);
            _context.SaveChanges();
            return RedirectToAction("Edit");
        }

        public Guid GetCurrentUserId()
        {
            return new Guid(User.Identity.GetUserId());
        }

        private bool EnsureIsUserMember(Members members)
        {
            return members.MemberId == GetCurrentUserId();
        }

        [Authorize]
        public ActionResult Search()
        {
            var userId = GetCurrentUserId();
            //return View(_context.Members.Where(x => x.MemberId == userId).ToList()); // Return only results created by corresponding account GUID
            return View(_context.Members.Where(x => x.MemberId != null).ToList());
        }
    }
}