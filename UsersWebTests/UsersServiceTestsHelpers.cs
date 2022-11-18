using Moq;
using UsersWeb;
using UsersWeb.Services;
using UsersWebTests;

internal static class UsersServiceTestsHelpers
{
    internal static UsersService GetUsersService(Mock<IUsersConfiguration> mockConfiguration, Mock<IWebRequest> mockIWebRequest, string response, CopyingMemoryStream stream = null)
    {
        mockConfiguration.SetupGet(configuration => configuration.APIBaseURL).Returns("https://s/");
        mockIWebRequest.SetupSet(request => request.Method = It.IsAny<string>());
        mockIWebRequest.SetupSet(request => request.ContentType = It.IsAny<string>());
        if (stream != null)
        {
            mockIWebRequest.Setup(request => request.GetRequestStream()).Returns(stream);
        }
        mockIWebRequest.Setup(request => request.GetResponse()).Returns(response);
        return new(mockConfiguration.Object, url => mockIWebRequest.Object);
    }
}
