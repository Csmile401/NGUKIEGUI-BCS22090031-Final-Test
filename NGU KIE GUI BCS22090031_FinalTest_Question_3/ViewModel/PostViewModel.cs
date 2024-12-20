using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using NGU_KIE_GUI_BCS22090031_FinalTest_Question_3.Model;
using System;
using NGU_KIE_GUI_BCS22090031_FinalTest_Question_3.Services;

namespace NGU_KIE_GUI_BCS22090031_FinalTest_Question_3.View
{
    public partial class PostViewModel : ObservableObject
    {
        private readonly ApiService _apiService;

        [ObservableProperty]
        private string title;

        [ObservableProperty]
        private string body;

        public ObservableCollection<PostRecord> Posts { get; } = new();

        public PostViewModel()
        {
            _apiService = new ApiService();
            LoadPostsCommand = new AsyncRelayCommand(LoadPostsAsync);
            AddPostCommand = new AsyncRelayCommand(AddPostAsync);
            DeletePostCommand = new AsyncRelayCommand<PostRecord>(DeletePostWithConfirmationAsync);

            // Load posts when the ViewModel is created
            LoadPostsCommand.Execute(null);
        }

        public IAsyncRelayCommand LoadPostsCommand { get; }
        public IAsyncRelayCommand AddPostCommand { get; }
        public IAsyncRelayCommand<PostRecord> DeletePostCommand { get; }

        private async Task LoadPostsAsync()
        {
            var posts = await _apiService.GetPostsAsync();
            Posts.Clear();
            foreach (var post in posts)
            {
                Posts.Add(post);
            }
        }

        private async Task AddPostAsync()
        {
            var newPost = new PostRecord { Title = Title, Body = Body, UserId = 1 };
            var addedPost = await _apiService.AddPostAsync(newPost);
            Posts.Add(addedPost);
            Title = string.Empty;
            Body = string.Empty;
        }

        private async Task DeletePostWithConfirmationAsync(PostRecord post)
        {
            // Show a confirmation dialog
            bool isConfirmed = await MainThread.InvokeOnMainThreadAsync(() =>
                Application.Current.MainPage.DisplayAlert("Delete Confirmation",
                "Are you sure you want to delete this post?", "Yes", "No"));

            if (isConfirmed)
            {
                // Proceed with deletion if confirmed
                await _apiService.DeletePostAsync(post.Id);
                Posts.Remove(post);
            }
        }
    }
}
