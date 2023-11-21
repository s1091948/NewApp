using NewsApp.Models;

namespace NewsApp.Pages;

public partial class NewDetailPage : ContentPage
{
	public NewDetailPage(Article article)
	{
		InitializeComponent();
		ImgNews.Source = article.Image;
		LblTitle.Text = article.Title;
		LblContent.Text = article.Content;
	}
}
