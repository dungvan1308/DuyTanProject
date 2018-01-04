using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Reflection;
using System.Resources;
using GYM.Common;

namespace GYM.Common
{
    class ResourceHelper
    {
        private static object lockObject = new object();
        private static string resourceNamespace = "GYM";
        private static Assembly resourceAsm;
        private static string resourceAsmName = "GYM";
        private static Dictionary<ResourceCategory, ResourceManager> _resource = new Dictionary<ResourceCategory, ResourceManager>();

        #region Public Methods
        public static string GetGlossary(string resKey)
        {
            return GetString(ResourceCategory.Glossary, resKey);
        }

        public static string GetError(string resKey)
        {
            return GetString(ResourceCategory.Errors, resKey);
        }

        public static string GetMessage(string resKey)
        {
            return GetString(ResourceCategory.Messages, resKey);
        }

        public static string GetCompanyInfo(string resKey)
        {
            return GetString(ResourceCategory.CompanyInfo, resKey);
        }

        #endregion

        #region Private Methods

        private static string GetString(ResourceCategory resCategory, string resKey)
        {
            EnsureResourceAssembly();

            ResourceManager resource = null;
            if (_resource.TryGetValue(resCategory, out resource) == false || resource == null)
                resource = _resource[resCategory] = InitializeResourceManager(resCategory);

            return resource.GetString(resKey);
        }

        private static void EnsureResourceAssembly()
        {
            if (object.ReferenceEquals(resourceAsm, null))
            {
                lock (lockObject)
                {
                    resourceAsm = Assembly.Load(resourceAsmName);
                }
            }
        }
        //Initialize Resource Manager
        private static ResourceManager InitializeResourceManager(ResourceCategory resCategory)
        {
            lock (lockObject)
            {
                return new ResourceManager(
                    string.Format("{0}.{1}", resourceNamespace, resCategory.ToString()),
                    resourceAsm);
            }
        }
        #endregion
    }
}
