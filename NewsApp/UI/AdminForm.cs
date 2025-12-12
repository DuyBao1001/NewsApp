using NewsApp.BLL;
using NewsApp.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NewsApp.UI
{
    public partial class AdminForm : Form
    {
        private readonly AdminServices _adminServices;
        private readonly ArticleServices _articleServices;
        private readonly CategoryServices _categoryServices;
        private List<User> _users = new();
        private List<Article> _articles = new();
        private List<Category> _categories = new();

        public AdminForm(AdminServices adminServices)
        {
            InitializeComponent();
            _adminServices = adminServices;
            _articleServices = new ArticleServices();
            _categoryServices = new CategoryServices();

            InitializeEvents();
            this.Load += AdminForm_Load;
        }


        private void InitializeEvents()
        {
            _adminServices.GetAllUsersResult += OnGetAllUsersResult;
            _adminServices.DeleteUserResult += OnDeleteUserResult;
            _adminServices.DeleteArticleResult += OnDeleteArticleResult;
            _adminServices.AddCategoryResult += OnAddCategoryResult;
            _adminServices.UpdateCategoryResult += OnUpdateCategoryResult;
            _adminServices.DeleteCategoryResult += OnDeleteCategoryResult;

            _articleServices.GetLatestArticlesResult += OnGetArticlesResult;
            _categoryServices.GetCategoriesResult += OnGetCategoriesResult;

            // Wire up button events
            btnDeleteUser.Click += BtnDeleteUser_Click;
            btnRefreshUsers.Click += BtnRefreshUsers_Click;
            btnDeleteArticle.Click += BtnDeleteArticle_Click;
            btnRefreshArticles.Click += BtnRefreshArticles_Click;
            btnNewCategory.Click += BtnNewCategory_Click;
            btnSaveCategory.Click += BtnSaveCategory_Click;
            btnDeleteCategory.Click += BtnDeleteCategory_Click;
            dgvCategories.SelectionChanged += DgvCategories_SelectionChanged;
        }

        private void AdminForm_Load(object? sender, EventArgs e)
        {
            LoadUsers();
            LoadCategories();
            LoadArticles();
        }

        private void LoadUsers()
        {
            _adminServices.GetAllUsers();
        }

        private void LoadCategories()
        {
            _categoryServices.GetCategories();
        }

        private void LoadArticles()
        {
            _articleServices.GetLatestArticles();
        }

        private void OnGetAllUsersResult(List<User> users)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<List<User>>(OnGetAllUsersResult), users);
                return;
            }
            _users = users;
            dgvUsers.DataSource = null;
            dgvUsers.DataSource = _users;
        }

        private void OnDeleteUserResult(bool success, string message)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<bool, string>(OnDeleteUserResult), success, message);
                return;
            }
            MessageBox.Show(message);
            if (success) LoadUsers();
        }

        private void OnGetArticlesResult(List<Article> articles)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<List<Article>>(OnGetArticlesResult), articles);
                return;
            }
            _articles = articles;
            dgvArticles.DataSource = null;
            dgvArticles.DataSource = _articles;
        }

        private void OnDeleteArticleResult(bool success, string message)
        {
            
        }

        private void OnAddCategoryResult(bool success, string message)
        {
            
        }

        private void OnUpdateCategoryResult(bool success, string message)
        {
            
        }

        private void OnDeleteCategoryResult(bool success, string message)
        {
           
        }

        private void OnGetCategoriesResult(List<Category> categories)
        {
           
        }

        // Button event handlers
        private void BtnDeleteUser_Click(object? sender, EventArgs e)
        {
           
        }

        private void BtnRefreshUsers_Click(object? sender, EventArgs e)
        {
            LoadUsers();
        }

        private void BtnDeleteArticle_Click(object? sender, EventArgs e)
        {
           
        }

        private void BtnRefreshArticles_Click(object? sender, EventArgs e)
        {
            LoadArticles();
        }

        private void BtnNewCategory_Click(object? sender, EventArgs e)
        {
            txtCategoryName.Text = "";
            dgvCategories.ClearSelection();
        }

        private void BtnSaveCategory_Click(object? sender, EventArgs e)
        {
            
        }

        private void BtnDeleteCategory_Click(object? sender, EventArgs e)
        {
            
        }

        private void DgvCategories_SelectionChanged(object? sender, EventArgs e)
        {
            
        }
    }
}