using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TodoApp.Models;

namespace TodoApp.Controllers
{
    [Authorize(Roles = "Administrators")]
    public class UsersController : Controller
    {
        private ToDoItemContext db = new ToDoItemContext();
        private readonly CustomMembershipProvider membershipProvider = new CustomMembershipProvider();

        // GET: Users
        public ActionResult Index()
        {
            return View(db.Users.ToList());
        }

        // GET: Users/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            this.SetRoles(Enumerable.Empty<Role>());
            return View();
        }

        // POST: Users/Create
        // 過多ポスティング攻撃を防止するには、バインド先とする特定のプロパティを有効にしてください。
        // 詳細については、https://go.microsoft.com/fwlink/?LinkId=317598 を参照してください。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,UserName,Password,RoleIds")] User user)
        {
            var roles = db.Roles.Where(role => user.RoleIds.Contains(role.Id)).ToList();

            if (ModelState.IsValid)
            {
                user.Roles = roles;

                user.Password = this.membershipProvider.GeneratePasswordHash(user.UserName, user.Password);

                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            this.SetRoles(roles); // 入力内容に誤りがある場合，復元するため
            return View();
        }

        // GET: Users/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }

            this.SetRoles(user.Roles);
            return View(user);
        }

        // POST: Users/Edit/5
        // 過多ポスティング攻撃を防止するには、バインド先とする特定のプロパティを有効にしてください。
        // 詳細については、https://go.microsoft.com/fwlink/?LinkId=317598 を参照してください。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,UserName,Password,RoleIds")] User user)
        {
            var roles = db.Roles.Where(role => user.RoleIds.Contains(role.Id)).ToList();

            if (ModelState.IsValid)
            {
                var dbUser = db.Users.Find(user.Id);
                if (dbUser == null)
                {
                    return HttpNotFound();
                }

                // DBのユーザーに変更を反映
                if (!this.EqualsPassword(dbUser, user.Password))
                {
                    // DBに保存されているパスワードと異なる場合は、ハッシュ化して更新
                    dbUser.Password = this.membershipProvider.GeneratePasswordHash(user.UserName, user.Password);
                }

                dbUser.UserName = user.UserName;
                dbUser.Roles.Clear();
                foreach(var role in roles)
                {
                    dbUser.Roles.Add(role);
                }

                db.Entry(dbUser).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            this.SetRoles(roles); // 入力内容に誤りがある場合，データを復元するため
            return View(user);
        }

        // GET: Users/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User user = db.Users.Find(id);
            db.Users.Remove(user);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Private methods

        private void SetRoles(IEnumerable<Role> userRoles)
        {
            var roleIds = userRoles.Select(x => x.Id).ToArray();

            var selectRoleItems = db.Roles.Select(item => new SelectListItem() 
                                                {
                                                    Text = item.RoleName,
                                                    Value = item.Id.ToString(),
                                                    Selected = roleIds.Contains(item.Id),
                                                }).ToList();

            ViewBag.RoleIds = selectRoleItems;
        }

        private bool EqualsPassword(User user, string password)
        {
            return user.Password == password;
        }

        #endregion
    }
}
