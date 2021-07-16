using RazorEngineCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Templates;

namespace WebApplication1.Helpers
{
    public static class TemplateHelper
    {
        public static async Task<string> ProcessTemplate()
        {
            string template = await GetTemplate("Index");
            string compiledTemplate = string.Empty;
            try
            {
                IRazorEngine razorEngine = new RazorEngine();

                IRazorEngineCompiledTemplate<RazorEngineTemplateBase<IndexModel>> temp = razorEngine.Compile<RazorEngineTemplateBase<IndexModel>>(template);

                string res = temp.Run(instance =>
                {
                    instance.Model = new IndexModel()
                    {
                        Name = "JAck",
                    };
                });

            }
            catch (Exception e)
            {
                // Something went wrong
                var p = "test";
            }


            return compiledTemplate;
        }

        private static async Task<string> GetTemplate(string templateName)
        {
            var template = string.Empty;
            FileStream fileStream = new FileStream($"Templates/{templateName}.cshtml", FileMode.Open);
            using (StreamReader reader = new StreamReader(fileStream))
            {
                template = await reader.ReadToEndAsync();
            }

            return template;
        }
    }
}
