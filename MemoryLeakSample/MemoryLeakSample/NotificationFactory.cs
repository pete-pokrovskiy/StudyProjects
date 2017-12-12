using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using RazorEngine;
using RazorEngine.Templating;

namespace MemoryLeakSample
{
    public static class NotificationFactory
    {
        public static string ParseTemplate<T>(T model)
        {
            //TODO: вероятно стоит вынести папку с шаблонами в отдельную директорию, общую для всех приложений
            string templatePath = Path.Combine(Path.GetDirectoryName(new Uri(Assembly.GetExecutingAssembly().CodeBase).LocalPath),
                "NotificationTemplates\\SMActTaskClosed.cshtml");
            var emailHtmlBody = Engine.Razor.RunCompile("SMActTaskClosed", File.ReadAllText(templatePath), null, model);


            //var templateService = new TemplateService();
            //string emailHtmlBody =
            //    templateService.Parse(
            //        File.ReadAllText(templatePath), model, null, "SMActTaskClosed");


            return emailHtmlBody;
        }
    }
}