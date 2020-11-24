using Microsoft.AspNetCore.Mvc;
using SecretProject.VisualElements.Elements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace SecretProject.Services
{
    public class VisualRedactor
    {
        private JsonSerializerOptions serializeOptions;

        public VisualRedactor(JsonSerializerOptions serializeOptions)
        {
            this.serializeOptions = serializeOptions ?? throw new ArgumentNullException(nameof(serializeOptions));
        }
        public JsonResult GetBackbone()
        {
            /////Header
            //    //ImageBlock - Логотип
            //    //LinksMenu
            //    //ContactBlock
            /////GrayBar
            //    //ComboBox - Каталог
            //    //SearchBar
            //    //Button - Корзина
            //    //Button - Страница пользователя
            /////Body
            //    //Banner
            //    //Slider - Спецпредложения
            //    //Slider - Хиты продаж
            //    //Button - Перейти к каталогу
            //    //InfoBlock - ...
            /////Footer
            //    //StayWithUsBlock
            Dictionary<string, object> backbone = new Dictionary<string, object>();
            Block header = new Block();
            backbone.Add("Header", header);
            Block grayLine = new Block();
            backbone.Add("GrayLine", grayLine);
            Block content= new Block();
            backbone.Add("Content", content);
            Block footer = new Block();
            backbone.Add("Footer", footer);
            return new JsonResult(backbone);
        }

        public JsonResult GetExplicitMockBackgone()
        {
            Dictionary<string, object> backbone = new Dictionary<string, object>();

            Block header = new Block();

            ImageBlock logo = new ImageBlock { Id = Guid.Empty, Alt = "Логотип компании", Source = "#" };
            header.AddVisualElement(logo);
            LinksMenu linksMenu = new LinksMenu { Id = Guid.Empty, Links = new List<LinkItem>{
                new LinkItem (Guid.Empty,"#","Доставка и оплата_1 " ), new LinkItem(Guid.Empty, "#", "Доставка и оплата_2") } 
            };
            header.AddVisualElement(linksMenu);
            ContactBlock contactblock = new ContactBlock() { Id = Guid.Empty, OpeningHours = "openingHours", Phone = "8 (812) 388-4538" };
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
        
    }
}
