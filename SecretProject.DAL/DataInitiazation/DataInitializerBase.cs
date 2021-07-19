using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace SecretProject.DAL.DataInitiazation
{
    public abstract class DataInitializerBase
    {
        protected string GenRandomString(int Length, string Alphabet = "ЙЦУКЕНГШЩЗХЪФЫВАПРОЛДЖЭЯЧСМИТТЬБЮБййцукенгшщзхъфывапролджэячсмитьбю")
        {
            Random rnd = new Random();
            int length = rnd.Next(0, 50);
            StringBuilder sb = new StringBuilder(Length - 1);
            int Position = 0;

            for (int i = 0; i < length; i++)
            {
                Position = rnd.Next(0, Alphabet.Length - 1);
                //добавляем выбранный символ в объект
                //StringBuilder
                sb.Append(Alphabet[Position]);
            }

            return sb.ToString();
        }

        public abstract void InitializeData(DbContext context);
        public virtual void RecreateDatabase(DbContext context, bool isNeedToInitializeData = false)
        {
            context.Database.EnsureDeleted();
            context.Database.Migrate();
            if(isNeedToInitializeData)
                InitializeData(context);
        }
    }
}
