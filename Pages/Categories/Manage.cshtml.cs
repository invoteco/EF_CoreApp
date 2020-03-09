using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EF_CoreApp.Data;
using EF_CoreApp.Models;
using Microsoft.AspNetCore.Identity;

namespace EF_CoreApp
{
    public class ManageModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        //Раскомментируйте строку ниже, если Ваше приложение использует роли
        //private readonly RoleManager<AppRole> _roleManager;
        private readonly ApplicationDbContext _context;

        //Раскомментируйте строку ниже, если Ваше приложение использует роли
        //public ManageModel(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, RoleManager<AppRole> roleManager, ApplicationDbContext conText)
        public ManageModel(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            //Раскомментируйте строку ниже, если Ваше приложение использует роли
            //_roleManager = roleManager;
            _context = context;
        }
        public List<Category> Categories { get; set; }

        public void OnGet()
        {
            Categories = _context.Categories.ToList();
        }

        //Это упрощенная версия метода для добавления Category в БД. В ней не производится проверка наличия в БД категории с таким же именем.
        public async Task<IActionResult> OnPostCreateAsync(string categoryname)
        {
            var category = new Category();
            category.CategoryName = categoryname;
            if (await TryUpdateModelAsync<Category>(
                category,
                "category",
                c => c.CategoryName
                ))
            {
                _context.Categories.Add(category);
                await _context.SaveChangesAsync();
                return RedirectToPage();

            }
            return Page();
        }

        public async Task<IActionResult> OnPostDeleteAsync(int categoryid, string categoryname)
        {
            var category = new Category();
            category.CategoryId = categoryid;
            category.CategoryName = categoryname;
            if (await TryUpdateModelAsync<Category>(
               category,
               "category",
               category => category.CategoryName,
               category => category.CategoryId
               ))
            {
                _context.Categories.Remove(category);
                await _context.SaveChangesAsync();
                return RedirectToPage();
            }
            return Page();
        }

    }
}