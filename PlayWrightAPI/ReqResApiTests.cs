using Microsoft.Playwright;
using System.Text.Json;

namespace PlayWrightAPI
{
    public class ReqResApiTests
    {
        IAPIRequestContext requestContext;
        [SetUp]
        public async Task Setup()
        {
            var playwright = await Playwright.CreateAsync();
            requestContext= await playwright.APIRequest.NewContextAsync(
                new APIRequestNewContextOptions
                {
                    BaseURL ="https://reqres.in/api/",
                   IgnoreHTTPSErrors = true,
                });

        }

        [Test]
        public async Task GetAllUsersTest()
        {
            var getresponse = await requestContext.GetAsync(url: "users?page=2");
            await Console.Out.WriteLineAsync("Res : \n" + getresponse.ToString());
            await Console.Out.WriteLineAsync("code : \n" + getresponse.Status);
            await Console.Out.WriteLineAsync("Text : \n" + getresponse.StatusText);


            Assert.That(getresponse.Status, Is.EqualTo(200));   
            Assert.That(getresponse,Is.Not.Null);

            JsonElement responseBody = (JsonElement) await getresponse.JsonAsync();
            await Console.Out.WriteLineAsync("Res Body: \n"+responseBody.ToString());

           

        }


        [Test]
        public async Task GetSingleUsersTest()
        {
            var getresponse = await requestContext.GetAsync(url: "users/2");
            await Console.Out.WriteLineAsync("Res : \n" + getresponse.ToString());
            await Console.Out.WriteLineAsync("code : \n" + getresponse.Status);
            await Console.Out.WriteLineAsync("Text : \n" + getresponse.StatusText);


            Assert.That(getresponse.Status, Is.EqualTo(200));
            Assert.That(getresponse, Is.Not.Null);

            JsonElement responseBody = (JsonElement)await getresponse.JsonAsync();
            await Console.Out.WriteLineAsync("Res Body: \n" + responseBody.ToString());



        }


        [Test]
        public async Task GetnonUsersTest()
        {
            var getresponse = await requestContext.GetAsync(url: "users/234");
            await Console.Out.WriteLineAsync("Res : \n" + getresponse.ToString());
            await Console.Out.WriteLineAsync("code : \n" + getresponse.Status);
            await Console.Out.WriteLineAsync("Text : \n" + getresponse.StatusText);


            Assert.That(getresponse.Status, Is.EqualTo(404));
            Assert.That(getresponse, Is.Not.Null);

            JsonElement responseBody = (JsonElement)await getresponse.JsonAsync();
            await Console.Out.WriteLineAsync("Res Body: \n" + responseBody.ToString());

            Assert.That(responseBody.ToString(), Is.EqualTo("{}"));



        }

        [Test]
        public async Task PostUser()
        {

            var postData = new
            {
                name = "John",
                job = "Engineer"
            };

            var jsonData =System.Text.Json.JsonSerializer.Serialize(postData);  

            var postresponse = await requestContext.PostAsync(url: "users",
                new APIRequestContextOptions { Data =jsonData});

            await Console.Out.WriteLineAsync("Res : \n" + postresponse.ToString());
            await Console.Out.WriteLineAsync("code : \n" + postresponse.Status);
            await Console.Out.WriteLineAsync("Text : \n" + postresponse.StatusText);


            Assert.That(postresponse.Status, Is.EqualTo(201));
            Assert.That(postresponse, Is.Not.Null);

            JsonElement responseBody = (JsonElement)await postresponse.JsonAsync();
            await Console.Out.WriteLineAsync("Res Body: \n" + responseBody.ToString());



        }


        [Test]
        public async Task PutUser()
        {

            var postData = new
            {
                name = "John",
                job = "Software Engineer"
            };

            var jsonData = System.Text.Json.JsonSerializer.Serialize(postData);

            var putresponse = await requestContext.PutAsync(url: "users/2",
                new APIRequestContextOptions { Data = jsonData });

            await Console.Out.WriteLineAsync("Res : \n" + putresponse.ToString());
            await Console.Out.WriteLineAsync("code : \n" + putresponse.Status);
            await Console.Out.WriteLineAsync("Text : \n" + putresponse.StatusText);


            Assert.That(putresponse.Status, Is.EqualTo(200));
            Assert.That(putresponse, Is.Not.Null);

            JsonElement responseBody = (JsonElement)await putresponse.JsonAsync();
            await Console.Out.WriteLineAsync("Res Body: \n" + responseBody.ToString());



        }

        [Test]
        public async Task DeleteUser()
        {





            var deleteresponse = await requestContext.DeleteAsync(url: "users/2");
               

            await Console.Out.WriteLineAsync("Res : \n" + deleteresponse.ToString());
            await Console.Out.WriteLineAsync("code : \n" + deleteresponse.Status);
            await Console.Out.WriteLineAsync("Text : \n" + deleteresponse.StatusText);


            Assert.That(deleteresponse.Status, Is.EqualTo(204));
            Assert.That(deleteresponse, Is.Not.Null);

          



        }
    }
}