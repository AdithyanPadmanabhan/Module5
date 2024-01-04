using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayWrightPOM.PWTests.Pages
{
    internal class LoginPage
    {
        private IPage? _page;
        private ILocator? _linkLogin;
        private ILocator? _inpusername;
        private ILocator? _inppassword;

        private ILocator? _btnLogin;
        private ILocator? _linkWelMess;

        public LoginPage(IPage? page)
        {
            _page = page;
            _linkLogin = _page?.Locator(selector: "text=Login");
            _inpusername = _page?.Locator(selector: "#UserName");

            _inppassword = _page?.Locator(selector: "#Password");
            _btnLogin = _page?.Locator(selector: "input", new PageLocatorOptions  {  HasTextString = "Log in"  });
            _linkWelMess = _page?.Locator(selector: "text='Hello admin!'");
        }

        public async Task ClickLoginLink()
        {
            await _linkLogin.ClickAsync();

        }
        public async Task Login(string username,string password)
        {
            await _inpusername.FillAsync(username);
            await _inppassword.FillAsync(password);

            await _btnLogin.ClickAsync();
        }

        public async Task<bool> CheckWelcomeMssage()
        {
            bool IsWelMessVisible = await _linkWelMess.IsVisibleAsync();
            return IsWelMessVisible;
        }
    }
}
