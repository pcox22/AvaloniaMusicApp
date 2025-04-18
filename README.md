# AvaloniaMusicApp
A demonstration of the Avalonia Framework. This is my completed rendition of the Music Store sample provided as a learning tool for the framework. The tutorial can be found at the [Avalonia UI Website](https://docs.avaloniaui.net).

# Components
**C#**
  * Coded in standard C#

**AXAML**
  * Utilizes XAML to create a native Desktop Application

**Reactive UI**
  * Many of the functions used to connect backend and frontend are built into the Reactive UI toolkit. This made creating Reactive Commands a breeze so they could be bound to UI elements later.

**Avalonia**
   * As made clear by the title, this project was made using the Avalonia framework. It was created on JetBrains: Rider, and combined all of the above elements. The solution was built using Model View View Model (MVVM) software architecture: much of the backend was established in ViewModel files in C#, and their properties were connected properly to View files built in XAML.

## Functionalities
* NuGet Package Management: Aside from the standard Avalonia NuGet packages, I installed the ITunesSearch package to read data from an online API for retrieving titles, artists, and cover art for various albums.
* Data Persistence: Upon adding a mock album to the user's selection, the album's data will be written to the disk. Upon closing and reopening the app, preivously aquired albums will still appear in the user's collection. *Note: As of this moment, there is a "Remove Album" button on the main window. This is half-functional; it will remove the selected Album from the collection, but it does not remove the data from the disk. As such, reopening the app will cause the album data on the disk to be re-entered into the collection.*
* Styling and Windows: Multiple windows are used, and both are styled in a manner that avoids appearing boring or obselete. In this instance, the windows are given semi-transparency and blurred. Using AXAML panels and docks, all contents are ordered neatly and are wrapped in such a way that prevents appearing disorganized.
