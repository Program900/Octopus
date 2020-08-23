using NUnit.Framework;
using Octopus.Enums;
using Octopus.Pages;

namespace Octopus.Tests
{
    [TestFixture, Category("HomepageTests")]
    public class HomepageTests : BaseTest
    {
        [Test, Order(1)]
        public void WhenCustomerOpensHomepage_ThenHomepageIsOpenedAndPageTitleIsCorrect()
        {
            Assert.That(HomePage.IsPageOpened(), Is.True);
            Assert.That(HomePage.IsPageTitleCorrect(), Is.True);
        }

        [Test, Order(2)]
        public void WhenUserOpensInsights_ThenPageIsOpened()
        {
            InsightsPage = HomePage.ClickLink<InsightsPage>(LinkText.Insights);
            Assert.That(InsightsPage.IsInsightsPageOpened(), Is.True);
        }
        [Test, Order(3)]
        public void WhenUserOpensBusinessPage_ThenPageIsOpened()
        {
            BusinessPage = HomePage.ClickLink<BusinessPage>(LinkText.Business);
            Assert.That(BusinessPage.IsBusinessPageOpened(), Is.True);
            Assert.That(BusinessPage.IsBusinessPageTitleCorrect(), Is.True);
        }

        [Test, Order(4)]
        public void WhenUserOpensContactPage_ThenPageIsOpened()
        {
            ContactPage = HomePage.ClickLink<ContactPage>(LinkText.Contact);
            Assert.That(ContactPage.IsContactPageOpened(), Is.True);
            Assert.That(ContactPage.IsContactPageTitleCorrect(), Is.True);
        }

    }
}
