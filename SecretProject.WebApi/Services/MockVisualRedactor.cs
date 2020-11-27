using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SecretProject.VisualElements;
using SecretProject.VisualElements.Elements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using System.Threading.Tasks;

namespace SecretProject.WebApi.Services
{
    public class MockJsonVisualRedactor : IVisualRedactor
    {

        #region Model
        private readonly ILogger<MockJsonVisualRedactor> logger;
        private readonly JsonSerializerOptions serializeOptions;

        #endregion

        #region Realization
        public MockJsonVisualRedactor(ILogger<MockJsonVisualRedactor> logger, JsonSerializerOptions serializeOptions)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.serializeOptions = serializeOptions ?? throw new ArgumentNullException(nameof(serializeOptions));
        }
        #endregion

        #region Interface's Methods
        public object GetAllVisualElements()
        {
            Dictionary<string, object> backbone = new Dictionary<string, object>();
            Block elements = new Block();
            backbone.Add("Elements", elements);

            Assembly visualAssembly = Assembly.GetAssembly(typeof(Block));

            foreach (Type type in visualAssembly.GetTypes())
            {
                if (!type.IsInterface && !type.IsAbstract && type.GetInterface("IVisualElement") != null)
                {
                    try
                    {
                        var elem = visualAssembly.CreateInstance(type.FullName);
                        if (elem != null)
                        {
                            logger.Log(LogLevel.Debug, $"Visual element of {type.Name} type.");
                            foreach (PropertyInfo prop in type.GetProperties())
                            {
                                logger.Log(LogLevel.Debug, $"It is setted default value to property {prop.Name}");
                                var setMethod = prop.GetSetMethod(false);
                                if (setMethod == null)
                                    continue;
                            }
                            elements.AddVisualElement(elem);
                        }
                    }
                    catch (Exception ex) { logger.Log(LogLevel.Debug, ex.Message); }

                }
            }
            return new JsonResult(backbone, serializeOptions);
        }

        public object GetBackbone()
        {
            Dictionary<string, object> backbone = new Dictionary<string, object>();

            Block header = new Block();

            ImageBlock logo = new ImageBlock { Id = 0, Alt = "Логотип компании", Source = "#" };
            header.AddVisualElement(logo);
            LinksMenu linksMenu = new LinksMenu
            {
                Id = 0,
                Links = new List<LinkItem>{
                new LinkItem (0,"#","Доставка и оплата_1 " ), new LinkItem(0, "#", "Доставка и оплата_2") }
            };
            header.AddVisualElement(linksMenu);
            ContactBlock contactblock = new ContactBlock() { Id = 0, OpeningHours = "openingHours", Phone = "8 (812) 388-4538" };
            header.AddVisualElement(contactblock);

            backbone.Add("Header", header);
            Block grayLine = new Block();
            backbone.Add("GrayLine", grayLine);
            Block content = new Block();
            backbone.Add("Content", content);
            Block footer = new Block();
            backbone.Add("Footer", footer);

            return new JsonResult(backbone, serializeOptions);
        }
        public object GetBackbone(bool expl)
        {
            Dictionary<string, object> backbone = new Dictionary<string, object>();

            Block header = new Block();

            ImageBlock logo = new ImageBlock { Id = 0, Alt = "Логотип компании", Source = "#" };
            header.AddVisualElement(logo);
            LinksMenu linksMenu = new LinksMenu
            {
                Id = 0,
                Links = new List<LinkItem>{
                new LinkItem (0,"#","Доставка и оплата_1 " ), new LinkItem(0, "#", "Доставка и оплата_2") }
            };
            header.AddVisualElement(linksMenu);
            ContactBlock contactblock = new ContactBlock() { Id = 0, OpeningHours = "openingHours", Phone = "8 (812) 388-4538" };
            header.AddVisualElement(contactblock);

            backbone.Add("Header", header);
            Block grayLine = new Block();
            backbone.Add("GrayLine", grayLine);
            Block content = new Block();
            backbone.Add("Content", content);
            Block footer = new Block();
            backbone.Add("Footer", footer);
            return new JsonResult(backbone, serializeOptions);
        }
        public object GetFormattedVisualElement(object element)
        {
            throw new NotImplementedException();
        }

        public object GetFormattedVisualElement(IEnumerable<object> element)
        {
            throw new NotImplementedException();
        }
        #endregion

    }
}
