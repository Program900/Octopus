using NUnit.Framework;
using Octopus.Enums;
using Octopus.Pages;

namespace Octopus.Tests
{
    [TestFixture, Category("InsightPage Tests")]
    public class InsightPageTests : BaseTest
    {
        [Test, Order(1)]
        public void WhenCustomerOpensHomepage_ThenHomepageIsOpenedAndPageTitleIsCorrect()
        {
            Assert.That(InsightsPage.IsInsightsPageOpened(), Is.True);
            Assert.That(InsightsPage.IsPageTitleCorrect(), Is.True);
        }
        [Test, Order(2)]
        public void WhenUserOpensInsights_ThenPageIsOpened()
        {
            HomePage = InsightsPage.ClickLink<HomePage>(LinkText.Home);
            Assert.That(HomePage.IsHomePageOpened(), Is.True);
        }
        [Test, Order(3)]
        public void WhenUserOpensBusinessPage_ThenPageIsOpened()
        {
            BusinessPage = InsightsPage.ClickLink<BusinessPage>(LinkText.Business);
            Assert.That(BusinessPage.IsBusinessPageOpened(), Is.True);
            Assert.That(BusinessPage.IsBusinessPageTitleCorrect(), Is.True);
        }
        [Test, Order(4)]
        public void WhenUserOpensContactPage_ThenPageIsOpened()
        {
            ContactPage = InsightsPage.ClickLink<ContactPage>(LinkText.Contact);
            Assert.That(ContactPage.IsContactPageOpened(), Is.True);
            Assert.That(ContactPage.IsContactPageTitleCorrect(), Is.True);
        }

    }
}
