using System;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace ParkwaylabsExercise2_Test
{
    public class DevTeamInfoTest
    {
        [Fact]
        public async Task GetDeveloperByTechnology()
        {
            using (var client = new TestClientProvider().Client)
            {
                var response = await client.GetAsync("/devteaminfo/GetDeveloperByTechnology/React");
                response.EnsureSuccessStatusCode();
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            }
        }

        [Fact]
        public async Task GetExperiencedTechLeadByTechnology()
        {
            using (var client = new TestClientProvider().Client)
            {
                var response = await client.GetAsync("/devteaminfo/GetExperiencedTechLeadByTechnology/React");
                response.EnsureSuccessStatusCode();
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            }
        }

        [Fact]
        public async Task GetExperiencedTechLeadByDeveloperTechnology()
        {
            using (var client = new TestClientProvider().Client)
            {
                var response = await client.GetAsync("/devteaminfo/GetExperiencedTechLeadByDeveloperTechnology/1/1");
                response.EnsureSuccessStatusCode();
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            }
        }
    }
}
