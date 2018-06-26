// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace RxUIOnPropertyChangedRepro
{
    [Register ("ViewController")]
    partial class ViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIActivityIndicatorView ActivityIndicator { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton DontInvokeExceptionButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel GoLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton InvokeExceptionButton { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (ActivityIndicator != null) {
                ActivityIndicator.Dispose ();
                ActivityIndicator = null;
            }

            if (DontInvokeExceptionButton != null) {
                DontInvokeExceptionButton.Dispose ();
                DontInvokeExceptionButton = null;
            }

            if (GoLabel != null) {
                GoLabel.Dispose ();
                GoLabel = null;
            }

            if (InvokeExceptionButton != null) {
                InvokeExceptionButton.Dispose ();
                InvokeExceptionButton = null;
            }
        }
    }
}