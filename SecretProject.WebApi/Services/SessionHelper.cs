using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;

namespace SecretProject.WebApi.Services
{
    public class SessionHelper
    {
        private readonly ILogger logger;
        private ISession session;

        public SessionHelper(ILogger logger, ISession session)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.session = session ?? throw new ArgumentNullException(nameof(session));
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

        public bool Save<DataType>(DataType serializingObj,string sessionVariable = nameof(DataType))
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
    }
}
