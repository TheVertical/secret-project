using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace SecretProject.Web.Services
{
    public class SessionHelper
    {
        private readonly ILogger logger;
        private ISession session;

        public SessionHelper(ILogger logger, IServiceProvider services)
        {
            if (services is null)
            {
                throw new ArgumentNullException(nameof(services));
            }
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
        }

        public static SessionHelper GetHelper(IServiceProvider services)
        {
            return new SessionHelper((services.GetService(typeof(ILogger<SessionHelper>)) as ILogger), services);
        }

        private byte[] ObjectToByteArray(object obj)
        {
            BinaryFormatter bf = new BinaryFormatter();
            using (var ms = new MemoryStream())
            {
                bf.Serialize(ms, obj);
                return ms.ToArray();
            }
        }
        private object ByteArrayToObject(byte[] arrBytes)
        {
            using (var memStream = new MemoryStream())
            {
                var binForm = new BinaryFormatter();
                memStream.Write(arrBytes, 0, arrBytes.Length);
                memStream.Seek(0, SeekOrigin.Begin);
                var obj = binForm.Deserialize(memStream);
                return obj;
            }
        }
        public object Get(string sessionVariable)
        {
            byte[] bytes = default;
            if (session.TryGetValue(sessionVariable, out bytes))
            {
                ByteArrayToObject(bytes);
            }
            return null;
        }
        public int? GetInt(string sessionVariable)=> session.GetInt32(sessionVariable);

        public DataType Get<DataType>(string sessionVariable = nameof(DataType))
            where DataType : class
        {
            byte[] bytes = default;
            if (session.TryGetValue(sessionVariable, out bytes))
            {
                return ByteArrayToObject(bytes) as DataType;
            }
            return null;
        }
        public void Remove(string sessionVariable)
        {
            session.Remove(sessionVariable);
        }
        public void Remove<DataType>(string sessionVariable = nameof(DataType))
            where DataType : class
        {
            session.Remove(sessionVariable);
        }

        public void IncreaseSessionNumber(int value,string sessionVariable)
        {
            object variable = Get(sessionVariable);
            int i = 0;
            if (variable is int)
            {
                i = Convert.ToInt32(variable) + value;
                Save(i, sessionVariable);
            }
        }

        public bool Save<DataType>(DataType serializingObj, string sessionVariable = nameof(DataType))
            where DataType : class
        {
            try
            {
                byte[] bytes = ObjectToByteArray(serializingObj);
                session.Set(sessionVariable, bytes);
            }
            catch (Exception ex)
            {
                logger.LogError($"Error by trying to save {sessionVariable.GetType().Name} in session with variable name {sessionVariable}\nInner Exception:{ex.Message}");
                return false;
            }
            return true;
        }
        public bool Save(int number, string sessionVariable)
        {
            try
            {
                session.SetInt32(sessionVariable, number);
            }
            catch (Exception ex)
            {
                logger.LogError($"Error by trying to save {sessionVariable.GetType().Name} in session with variable name {sessionVariable}\nInner Exception:{ex.Message}");
                return false;
            }
            return true;
        }
        public bool Save(string value, string sessionVariable)
        {
            try
            {
                session.SetString(sessionVariable, value);
            }
            catch (Exception ex)
            {
                logger.LogError($"Error by trying to save {sessionVariable.GetType().Name} in session with variable name {sessionVariable}\nInner Exception:{ex.Message}");
                return false;
            }
            return true;
        }
    }
}
