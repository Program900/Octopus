using NUnit.Framework;
using NUnit.Framework.Constraints;
using Octopus.Enums;
using Octopus.Pages;

namespace Octopus.Tests
{
    [TestFixture, Category("InsightPage Tests")]
    public class InsightPageTests : BaseTest
    {
        [Test, Order(1)]
        public void VerifyUserCanNavigateToInsightPage()
        {
            Assert.That(InsightsPage.IsInsightsPageOpened(), Is.True);
            Assert.That(InsightsPage.IsPageTitleCorrect(), Is.True);
        }
        [Test, Order(2)]
        public void VerifyUserCanNavigateToHomePage()
        {
            HomePage = InsightsPage.ClickLink<HomePage>(LinkText.Home);
            Assert.That(HomePage.IsHomePageOpened(), Is.True);
        }
        [Test, Order(3)]
        public void VerifyUserCanNavigateToBusinessPage()
        {
            BusinessPage = InsightsPage.ClickLink<BusinessPage>(LinkText.Business);
            Assert.That(BusinessPage.IsBusinessPageOpened(), Is.True);
            Assert.That(BusinessPage.IsBusinessPageTitleCorrect(), Is.True);
        }
        [Test, Order(4)]
        public void VerifyUserCanNavigateToContactPage()
        {
            ContactPage = InsightsPage.ClickLink<ContactPage>(LinkText.Contact);
            Assert.That(ContactPage.IsContactPageOpened(), Is.True);
            Assert.That(ContactPage.IsContactPageTitleCorrect(), Is.True);
        }
        [Test, Order(5)]
        public void VerifyUserCanFilterByBusiness()
        {
           
            Assert.That(InsightsPage.IsInsightsPageOpened(), Is.True);
            Assert.That(InsightsPage.FilterByBusinessValues(), Is.True);
            
        }
        [Test, Order(5)]
        public void VerifyUserCanSearchbyKeyword()
        {
            
            Assert.That(InsightsPage.IsInsightsPageOpened(), Is.True);
            Assert.That(InsightsPage.SearchByText(),Is.True);
           
        }
       

    }
}
