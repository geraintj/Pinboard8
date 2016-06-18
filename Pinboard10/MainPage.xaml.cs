using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using PinboardDomain.Model;
using PinboardDomain.Repository;
using PinboardDomain.ViewModels;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Pinboard10
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            BottomBar.Closed += BottomBarClosed;
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.  The Parameter
        /// property is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var api = new PinboardApiWrapper();
            this.DataContext = new MainPageViewModel(api);
        }

        public void ButtonClick(object sender, RoutedEventArgs e)
        {
            var button = sender as HyperlinkButton;
            var thing = button.Content;
            this.Frame.Navigate(typeof(TagPosts), thing);
        }

        private void TagSelected(object sender, SelectionChangedEventArgs e)
        {
            if (TagListView.SelectedItem != null)
            {
                BottomBar.IsOpen = true;
            }
        }

        private void BottomBarClosed(object sender, object e)
        {
            TagListView.SelectedItem = null;
        }

        private void AppBar_RenameButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedTag = TagListView.SelectedItem as Tag;
            TagName.Text = selectedTag.Name;
        }

        private void RenameButton_Click(object sender, RoutedEventArgs e)
        {

        }
        
    }
}