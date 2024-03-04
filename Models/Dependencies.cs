using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json.Linq;
using System.IO;

namespace Psychosis.Models
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }

    [ApiController]
    [Route("invocations")]
    public class InvocationsController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post()
        {
            using (StreamReader reader = new StreamReader(Request.Body))
            {
                string requestBody = reader.ReadToEnd();

                JObject reqData = JObject.Parse(requestBody);

                // Handle different types of input data formats

                // Serialized pandas DataFrame format
                if (reqData.ContainsKey("dataframe_records"))
                {
                    JArray data = (JArray)reqData["dataframe_records"];
                    // Process data
                    System.Console.WriteLine(data);
                    return Ok(data); // Sending back processed data as response (dummy response)
                }
                // Split serialized pandas DataFrame format
                else if (reqData.ContainsKey("dataframe_split"))
                {
                    JObject dataframeSplit = (JObject)reqData["dataframe_split"];
                    JArray columns = (JArray)dataframeSplit["columns"];
                    JArray index = (JArray)dataframeSplit["index"];
                    JArray data = (JArray)dataframeSplit["data"];
                    // Process data
                    System.Console.WriteLine(columns);
                    System.Console.WriteLine(index);
                    System.Console.WriteLine(data);
                    return Ok(data); // Sending back processed data as response (dummy response)
                }
                // List format for processing
                else if (reqData.ContainsKey("inputs"))
                {
                    JArray inputs = (JArray)reqData["inputs"];
                    // Process data
                    System.Console.WriteLine(inputs);
                    return Ok(inputs); // Sending back processed data as response (dummy response)
                }
                // Tensor data instances for processing
                else if (reqData.ContainsKey("instances"))
                {
                    JArray instances = (JArray)reqData["instances"];
                    // Process data
                    System.Console.WriteLine(instances);
                    return Ok(instances); // Sending back processed data as response (dummy response)
                }
                else
                {
                    return BadRequest("Invalid request");
                }
            }
        }
    }
}
