using UIKit;
using Foundation;

namespace RxUIOnPropertyChangedRepro
{
    [Register(nameof(AppDelegate))]
    public class AppDelegate : UIApplicationDelegate
    {
        public override UIWindow Window { get; set; }
    }
}

