using System.Globalization;
using System.Reflection;
using System.Resources;

namespace SemMultiLang.LanguageLib
{
    public class LanguageHelper
    {
        ResourceManager _resourceManager;

        public LanguageHelper()
        {
            _resourceManager = new ResourceManager("SemMultiLang.LanguageLib.Resources.Languages.Lang",
                                                   Assembly.GetExecutingAssembly());
        }

        public string GetLabel(string language, string labelKey)
        {

            if (string.IsNullOrWhiteSpace(language))
            {
                throw new Exception("Language is required");
            }

            string ret = "";

            try
            {
                CultureInfo culture = CultureInfo.CreateSpecificCulture(language);

                ret = _resourceManager.GetString(labelKey, culture);

                return ret;
            }
            catch
            {
                ret = labelKey;

                return ret;
            }
        }
    }
}
