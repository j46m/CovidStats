using System.Collections.Generic;
using System.Net.Http;
using CovidStats.data.DTO;
using Newtonsoft.Json;

namespace CovidStats.Tests.Mocks
{
    public static class ResponseBuilder
    {
        public static StringContent BuildOkResponse()
        {
            var response = new ApiReportResponse
            {
                data = new List<Datum>
                {
                    new Datum
                    {
                        date = "2021-03-18",
                        confirmed = 119528,
                        deaths = 2462,
                        recovered = 49664,
                        confirmed_diff = 28,
                        deaths_diff = 2,
                        recovered_diff = 128,
                        last_update = "2021-03-19 05:26:09",
                        active = 3918,
                        active_diff = -102,
                        fatality_rate = 0.0439d,
                        region = new Region
                        {
                            cities = null,
                            name = "Afghanistan",
                            province = "",
                            iso = "AFG",
                            lat = "33.9391",
                            @long = "67.7100"
                        }
                    },
                    new Datum
                    {
                        date = "2021-03-18",
                        confirmed = 1008,
                        deaths = 27,
                        recovered = 598,
                        confirmed_diff = 16,
                        deaths_diff = 0,
                        recovered_diff = 0,
                        last_update = "2021-03-19 05:26:09",
                        active = 383,
                        active_diff = 16,
                        fatality_rate = 0.0268d,
                        region = new Region
                        {
                            cities = null,
                            name = "Antigua and Barbuda",
                            iso = "ATG",
                            lat = "17.0608",
                            @long = "-61.7964"
                        }
                    },
                    new Datum
                    {
                        date = "2021-03-18",
                        confirmed = 56044,
                        deaths = 2106,
                        recovered = 83264,
                        confirmed_diff = 590,
                        deaths_diff = 14,
                        recovered_diff = 710,
                        last_update = "2021-03-19 05:26:09",
                        active = 34158,
                        active_diff = -134,
                        fatality_rate = 0.0176d,
                        region = new Region
                        {
                            cities = null,
                            name = "Albania",
                            iso = "ALB",
                            lat = "41.1533",
                            @long = "20.1683"
                        }
                    },
                }
            };

            var json = JsonConvert.SerializeObject(response);

            return new StringContent(json);
        }

        public static StringContent BuildInternalErrorResponse()
        {
            var json = JsonConvert.SerializeObject(new { Cod = 500, Message = "Internal Error." });
            return new StringContent(json);
        }

        //TODO: Add more HTTP responses to mock
    }
}