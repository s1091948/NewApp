using NewsApp.Models;
using NewsApp.Services;


namespace NewsApp.Pages;

public partial class NewHomePage : ContentPage
{
	public List<Article> ArticlesList;
    public List<Category> CategoryList = new List<Category>()
    {
        new Category(){Name="World", ImageUrl = "world.png"},
        new Category(){Name = "Nation" , ImageUrl="nation.png"},
        new Category(){Name = "Business" , ImageUrl="business.png"},
        new Category(){Name = "Technology" , ImageUrl="technology.png"},
        new Category(){Name = "Entertainment", ImageUrl = "entertainment.png"},
        new Category(){Name = "Sports" , ImageUrl="sports.png"},
        new Category(){Name = "Science", ImageUrl= "science.png"},
        new Category(){Name = "Health", ImageUrl="health.png"},
    };
    public NewHomePage()
	{
		InitializeComponent();
		GetBreakingNews();
		ArticlesList = new List<Article>();
		CvCategories.ItemsSource = CategoryList;
	}


	private async void GetBreakingNews()
	{
		var apiService = new ApiService();
		var newResult = await apiService.GetNews("general");
		foreach (var item in newResult.Articles) 
		{
			ArticlesList.Add(item);
		}
		CvNews.ItemsSource = ArticlesList;
	}
	private void CvCategories_SelectionChanged(object sender, SelectionChangedEventArgs e)
	{
		var selectedItem = e.CurrentSelection.FirstOrDefault() as Category;
		if (selectedItem == null) return;
		Navigation.PushAsync(new NewListPage(selectedItem.Name));
		((CollectionView)sender).SelectedItem = null;
	}
}
