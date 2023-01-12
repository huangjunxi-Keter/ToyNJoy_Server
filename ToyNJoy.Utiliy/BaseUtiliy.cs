using System.Reflection;

namespace ToyNJoy.Utiliy
{
    public static class BaseUtiliy
    {
        public static object GetPropertyValue(object obj, string property)
        {
            PropertyInfo propertyInfo = obj.GetType().GetProperty(property);
            return propertyInfo.GetValue(obj, null);
        }
    }
}