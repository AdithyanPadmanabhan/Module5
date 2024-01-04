using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayWrightPOM.PWTests.Pages
{
    internal class NewLoginPage
    {
        private IPage? _page;
        private ILocator? LinkLogin => _page?.Locator(selector: "text=Login");
        private ILocator? Inpusername => _page?.Locator(selector: "#UserName");
        private ILocator? Inppassword => _page?.Locator(selector: "#Password");

        private ILocator? BtnLogin => _page?.Locator(selector: "input", new PageLocatorOptions { HasTextString = "Log in" });
        private ILocator? LinkWelMess => _page?.Locator(selector: "text='Hello admin!'");

        public NewLoginPage(IPage? page) =>_page = page;
       
        public async Task ClickLoginLink() => await LinkLogin.ClickAsync();

        public async Task Login(string username,string password)
        {
            await Inpusername.FillAsync(username);
            await Inppassword.FillAsync(password);

            await BtnLogin.ClickAsync();
        }

        public async Task<bool> CheckWelcomeMssage()=> await LinkWelMess.IsVisibleAsync();

    }
}
