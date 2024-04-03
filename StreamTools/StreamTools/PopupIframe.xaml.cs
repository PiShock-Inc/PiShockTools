namespace StreamTools;

public partial class PopupIframe : ContentPage
{

	public PopupIframe(string source)
	{
		InitializeComponent();
		webView.Source = source;
	}
}