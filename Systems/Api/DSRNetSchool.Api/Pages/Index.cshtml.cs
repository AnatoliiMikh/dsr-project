namespace DSRNetSchool.Api.Pages;

//using DSRNetSchool.Api.Settings; в Workshop 1 на 1:19:20
using DSRNetSchool.Common;
//using DSRNetSchool.Services.Settings; в Workshop 1 на 1:19:20
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Reflection;

public class IndexModel : PageModel
{
    [BindProperty]
    public bool OpenApiEnabled => true; // settings.Enabled; в Workshop 1 на 1:19:20

    [BindProperty]
    public string Version => Assembly.GetExecutingAssembly().GetAssemblyVersion();

    [BindProperty]
    public string HelloMessage => null; // apiSettings.HelloMessage; в Workshop 1 на 1:19:20


    //private readonly SwaggerSettings settings; в Workshop 1 на 1:19:20
    //private readonly ApiSpecialSettings apiSettings;

    //public IndexModel(SwaggerSettings settings, ApiSpecialSettings apiSettings)
    //{
    //    this.settings = settings;
    //    this.apiSettings = apiSettings;
    //}

    public void OnGet()
    {
    }
}
