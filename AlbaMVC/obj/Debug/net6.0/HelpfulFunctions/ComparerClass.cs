using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics.CodeAnalysis;

namespace AlbaMVC.HelpfulFunctions
{
    public class ComparerClass : IEqualityComparer<SelectListItem>
    {
        public bool Equals(SelectListItem? x, SelectListItem? y)
        {
            return x.Value == y.Value && x.Text == y.Text;
        }

        public int GetHashCode([DisallowNull] SelectListItem obj)
        {
            return obj.Value.GetHashCode() ^ obj.Text.GetHashCode();
        }

        
    }
}
