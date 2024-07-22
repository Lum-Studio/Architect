using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace Architect.Components
{
    public partial class ItemGrid 
    {
        [Parameter] public IEnumerable<dynamic> Items { get; set; }
        [Parameter] public Action<object> OnListItemClicked { get; set; }
        [Parameter] public string MessageIfItemsEmpty { get; set; } = "You have no items";
        
        void OnClickHandler(object clickedElement)
        {
            OnListItemClicked.Invoke(clickedElement);
        }
    }
}
