using BSRVemcoCS.iApp_Identity;
using BSRVemcoCS2024.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;

namespace BSRVemcoCS2024.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly BSRDBContext _dbContext;


        private readonly Microsoft.AspNetCore.Identity.UserManager<AppCore_IdentityUser> iUserManager;
        private readonly SignInManager<AppCore_IdentityUser> iSignManager;

        public HomeController(
                    ILogger<HomeController> logger,
                    BSRDBContext dbContext,
           Microsoft.AspNetCore.Identity.UserManager<AppCore_IdentityUser> iUserManager,
                        SignInManager<AppCore_IdentityUser> iSignManager)
        {
            _dbContext = dbContext;
            this.iUserManager = iUserManager;
            this.iSignManager = iSignManager;
            _logger = logger;
        }

        ////////virtual

        ////////    public HomeController(ILogger<HomeController> logger)
        ////////{
        ////////    _logger = logger;
        ////////}

        public async Task<IActionResult> Index()
        {

            try
            {

                var iResult = await iSignManager.PasswordSignInAsync(
                    "test1@me.com", "123456",  true, false);

                if (iResult.Succeeded)
                {

                    string? _iUserEmail = User.Identity!.Name;

                    ////////var _iUserOwnerModel = _dbContext.BsrvemcoUserLists
                    ////////        .Where(u => u.Email == iLoginModel.Email!.ToLower().ToString())
                    ////////        //.Select ( u => u.RoleName )
                    ////////        .SingleOrDefault(); // This is what actually executes the request and return a response

                    ////////if (_iUserOwnerModel != null)
                    ////////{


                    ////////    _iOwnerModel = new AppUserOwnerModelManager
                    ////////    {
                    ////////        OwnerUserTokenID = _iUserOwnerModel!.OwnerUserTokenId,
                    ////////        FirstName = _iUserOwnerModel!.FirstName,
                    ////////        LastName = _iUserOwnerModel!.LastName,
                    ////////        FullName = _iUserOwnerModel!.FirstName + " " + _iUserOwnerModel!.LastName,
                    ////////        EmailAddress = iLoginModel.Email!.ToLower().ToString(),
                    ////////        CompanyTokenID = _iUserOwnerModel!.CompanyTokenId,
                    ////////        CompanyName = _iUserOwnerModel!.CompanyName,
                    ////////        RoleTokenID = _iUserOwnerModel!.AppRoleTokenId,
                    ////////        RoleCode = _iUserOwnerModel!.AppRoleCode,
                    ////////        RoleName = _iUserOwnerModel!.AppRoleName,
                    ////////        ProfileImageServerURL = _iUserOwnerModel!.ProfileImageServerUrl

                    ////////    };






                    ////////    Program.iOwnerModel = _iOwnerModel;
                    ////////    Program.iRolePermissionModel = _iRolePermissionModel;

                    ////////    TempData["iOwnerModel"] = JsonConvert.SerializeObject(_iOwnerModel);
                    ////////    TempData["iRolePermissionModel"] = JsonConvert.SerializeObject(_iRolePermissionModel);





                    ////////    Tuple<AppUserOwnerModelManager, AppUserRolePermissionModelManager> myTuple
                    ////////    = new Tuple<AppUserOwnerModelManager, AppUserRolePermissionModelManager>(_iOwnerModel, _iRolePermissionModel);


                    ////////    if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                    ////////    {
                    ////////        return LocalRedirect(returnUrl);
                    ////////    }
                    ////////    else
                    ////////    {


                    ////////        return RedirectToAction(
                    ////////            "Index",
                    ////////            "Dashboard",
                    ////////            new { area = "iWebMember" });

                    ////////    }


                    ////////////////}

                    //ModelState.AddModelError("iErrorKey", "Invalid Login Attempt");

                    return View( );

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("***BSRVemcoCS***\n\t\t" + ex.Message);

            }

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
