using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using week11.Data;
using week11.Models;
using week11.ModelView;

namespace week11.Controllers
{
    public class ManagementAccountController : Controller
    {
        private readonly ILogger<ManagementAccountController> _logger;
        private readonly ApplicationDbContext _dbcontext;
        private readonly UserManager<IdentityUser> _usermanager;
        private readonly SignInManager<IdentityUser> _siginmanager;
        private readonly RoleManager<IdentityRole> _rolemanager;
        public ManagementAccountController(ILogger<ManagementAccountController> logger, ApplicationDbContext dbcontext,
                                          UserManager<IdentityUser> usermanager, SignInManager<IdentityUser> siginmanager,
                                          RoleManager<IdentityRole> rolemanager)
        {
            _logger = logger;
            _dbcontext = dbcontext;
            _usermanager = usermanager;
            _siginmanager = siginmanager;
            _rolemanager = rolemanager;
        }
        [HttpGet]
        public IActionResult xxRegeslayout()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> xxRegeslayout(xxlogin obj)
        {
            if(ModelState.IsValid)
            {
                var ident = new IdentityUser() { Email = obj.email, UserName = obj.email,EmailConfirmed=true };
                var result = await _usermanager.CreateAsync(ident, obj.pasword);
                if (result.Succeeded)
                {
                    var xx = new x() { email = obj.email, pasword = obj.pasword, AppUserId = ident.Id };
                    _dbcontext.xx.Add(xx);
                    _dbcontext.SaveChanges();
                    await _siginmanager.SignInAsync(ident, true);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }
            
            return View(obj);
        }
        [HttpGet]
        public IActionResult xxlogin()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> xxlogin(xxlogin log)
        {
            if (ModelState.IsValid)
            {
                var res =await _siginmanager.PasswordSignInAsync(log.email, log.pasword, true, true);
                if (res.Succeeded)
                {
                    return RedirectToAction("Index","Home");
                }
                else
                {   
                    return Content("failed login");
                }
            }
            return View(log);
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult registerPage()
        {
            return View();
        }
        [HttpGet]
        public IActionResult registerStudentLayout()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> registerStudentLayout(ModelViewStudentRegister obj)
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser() { UserName = obj.UserName, Email = obj.UserEmail };
                var result=await _usermanager.CreateAsync(user, obj.UserPassword);
                if (result.Succeeded)
                {
                    var studentt = new student() { StudentAge = obj.StudentAge, StudentGender = obj.StudentGender, AppUserId = user.Id };
                    _dbcontext.students.Add(studentt);
                    _dbcontext.SaveChanges();
                    await _usermanager.AddToRoleAsync(user, "StudentRole");
                    await _siginmanager.SignInAsync(user, true);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }
            return View(obj);
        }
        [HttpGet]
        public IActionResult registerTeacherLayout()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> registerTeacherLayout(ModelViewRegisterTeacher obj)
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser() { UserName = obj.UserName + obj.teacherLastName, Email = obj.UserEmail };
                var result =await _usermanager.CreateAsync(user, obj.UserPassword);
                if (result.Succeeded)
                {
                    var teacher = new teacher()
                    {
                        AppUserId = user.Id,
                        teacherAge = obj.teacherAge,
                        teacherFirstName = obj.teacherFirstName,
                        teacherGender = obj.teacherGender,
                        teacherLastName = obj.teacherLastName
                    };
                    teacher.teacherPic =convertFromFileToByte(obj.teacherPic);
                    _dbcontext.teachers.Add(teacher);
                    _dbcontext.SaveChanges();
                    await _usermanager.AddToRoleAsync(user, "TeacherRole");
                    await _siginmanager.SignInAsync(user, true);
                   return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }

            }
            return View(obj);
        }
        //Function To Convert From IFormFile To Array Of Byte 
        private byte[] convertFromFileToByte(IFormFile teacherPic)
        {
            using (var ms=new MemoryStream())
            {
                teacherPic.CopyTo(ms);
                return ms.ToArray();
            }
        }
        public IActionResult ShowTeacherData()
        {
            var userId = _usermanager.GetUserId(User);
            var user = _dbcontext.teachers.FirstOrDefault(t => t.AppUserId == userId);
            return View(user);
        }
        [HttpGet]
        public IActionResult RegistermanagerLayout()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> RegistermanagerLayout (ModelViewManagerRegister obj)
        {
            if (ModelState.IsValid)
            {
                var manager = new IdentityUser() { UserName = (obj.managerFname + obj.managerLname), Email = obj.UserEmail };
                var result = await _usermanager.CreateAsync(manager, obj.UserPassword);
                if (result.Succeeded)
                {
                    var super = new manager() { managerLname = obj.managerLname, managerFname = obj.managerFname, managerGender = obj.managerGender, AppUserID = manager.Id };
                    _dbcontext.managers.Add(super);
                    _dbcontext.SaveChanges();
                    await _usermanager.AddToRoleAsync(manager, "ManagerRole");
                    await _siginmanager.SignInAsync(manager, true);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    //make error for general fields not specific
                    //ModelState.AddModelError("", "the password is very poor");
                    //make error for specific fields but not dynamic
                    //ModelState.AddModelError("UserPassword", "the password is very poor");

                    //make error dynamic for all fields
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("",item.Description);
                    }
                }
            }
            return View(obj);
        }
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _siginmanager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(Login userLogin)
        {
            if (ModelState.IsValid)
            {
                var result = await _usermanager.FindByEmailAsync(userLogin.Email);
                if (result!=null)
                {
                    var resultt = await _siginmanager.PasswordSignInAsync(userLogin.Email, userLogin.Password,true,false);
                    if (resultt.Succeeded)
                        return RedirectToAction("Index", "Home");
                    else
                    {
                        return Content("not allowed");
                    }
                }  
                else
                {
                    return Content("user not found");
                }
            }
            return Content("modelstate valid error");
            //IdentityUser user = new IdentityUser() { Email = userLogin.email,UserName=userLogin.email };
            //var result=await _usermanager.CreateAsync(user, userLogin.password);
            //if (result.Succeeded)
            //{
            //    await _siginmanager.SignInAsync(user, true);
            //    return RedirectToAction("Index", "Home");
            //}
            //else
            //{
            //    foreach (var item in result.Errors)
            //    {
            //        ModelState.AddModelError("", item.Description);
            //    }
            //}
            //return View(userLogin);
        }
        [HttpGet]
        public async Task<IActionResult> AddAllRoles()
        {
            //assign 3 item in role table
            IdentityRole StudentRole = new IdentityRole() { Name = "StudentRole" };
            IdentityRole TeacherRole = new IdentityRole() { Name = "TeacherRole" };
            IdentityRole ManagerRole = new IdentityRole() { Name = "ManagerRole" };

            //create 3 item in database in role table
            var result1 =await _rolemanager.CreateAsync(StudentRole);
            var result2 =await _rolemanager.CreateAsync(TeacherRole);
            var result3 =await _rolemanager.CreateAsync(ManagerRole);

            //check if this table are created
            if (result1.Succeeded&&result2.Succeeded&&result3.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }
            return Content(" error has be occured " + result1.Errors.SingleOrDefault().Description);
        }
    }
}