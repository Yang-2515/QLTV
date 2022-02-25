using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace QLTV.Pages
{
    public class Index_Tests : QLTVWebTestBase
    {
        [Fact]
        public async Task Welcome_Page()
        {
            var response = await GetResponseAsStringAsync("/");
            response.ShouldNotBeNull();
        }
    }
}
