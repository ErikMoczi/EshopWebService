using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Newtonsoft.Json.Linq;

namespace EshopWebService.IntegrationTests.Common.Extensions
{
    public static class JsonExtensions
    {
        public static T FilterData<T>(this JContainer jContainer, Regex regex = null)
        {
            if (regex != null)
            {
                var query = jContainer.DescendantsAndSelf()
                    .OfType<JProperty>()
                    .Where(p => regex.IsMatch(p.Path));

                query.RemoveFromLowestPossibleParents();
            }

            return jContainer.ToObject<T>();
        }

        private static TJToken RemoveFromLowestPossibleParent<TJToken>(this TJToken node) where TJToken : JToken
        {
            if (node == null)
            {
                return null;
            }

            JToken toRemove;
            if (node.Parent is JProperty property)
            {
                toRemove = property;
                property.Value = null;
            }
            else
            {
                toRemove = node;
            }

            if (toRemove.Parent != null)
            {
                toRemove.Remove();
            }

            return node;
        }

        private static IEnumerable<TJToken> RemoveFromLowestPossibleParents<TJToken>(this IEnumerable<TJToken> nodes) where TJToken : JToken
        {
            var list = nodes.ToList();
            foreach (var node in list)
            {
                node.RemoveFromLowestPossibleParent();
            }

            return list;
        }
    }
}