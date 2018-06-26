# RxUIOnPropertyChangedRepro

A sample app reproducing the bug that occurs in RxUI when ViewModel properties are not updated on the Main Thread.

In this example, a background Task is invoked in the `ViewModel` via button `Command`. If `ConfigureAwait(false)` is used, the background thread continues to update the `string` property and the following `UIKit.UIKitThreadAccessException` is thrown:
>UIKit Consistency error: you are calling a UIKit method that can only be invoked from the UI thread.

![](https://github.com/brminnick/Videos/blob/master/RxUIOnPropertyChangedRepro/RxUIOnPropertyChangedRepro.gif)
