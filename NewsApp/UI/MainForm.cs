using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Windows.Forms;
using NewsApp.BLL;
using NewsApp.Data;
using NewsApp.Network;

namespace NewsApp.UI
{
    public partial class MainForm : Form
    {
        private User user;
        private readonly ArticleServices _articleServices;
        private readonly CategoryServices _categoryServices;
        private readonly CommentServices _commentServices;

        public MainForm(
            User user,
            ArticleServices articleServices,
            CategoryServices categoryServices,
            CommentServices commentServices
        )
        {
            InitializeComponent();
            this.user = user;
            this._articleServices = articleServices;
            this._categoryServices = categoryServices;
            this._commentServices = commentServices;
            this.Text = $"NewsApp - Xin chào {user.FullName}";

            if (user.Role == "Admin")
            {
                btnAdminPanel.Visible = true;
            }

            if (user.Role != "Writer")
            {
                btnPostArticle.Visible = false;
            }

            _categoryServices.GetCategoriesResult += (categories) =>
            {
                // Add "All" option
                categories.Insert(0, new Category { CategoryID = -1, Name = "Tất cả" });

                if (this.InvokeRequired)
                {
                    this.Invoke(
                        new Action(() =>
                        {
                            cbCategories.DisplayMember = "Name";
                            cbCategories.ValueMember = "CategoryID";
                            cbCategories.DataSource = categories;
                            cbCategories.SelectedIndex = 0; // Default to "All"
                        })
                    );
                }
                else
                {
                    cbCategories.DisplayMember = "Name";
                    cbCategories.ValueMember = "CategoryID";
                    cbCategories.DataSource = categories;
                    cbCategories.SelectedIndex = 0;
                }
            };

            _articleServices.GetLatestArticlesResult += UpdateArticleList;

            // Custom handler for Category result
            _articleServices.GetArticlesByCategoryResult += (articles) =>
            {
                if (articles == null || articles.Count == 0)
                {
                    if (this.InvokeRequired)
                    {
                        this.Invoke(
                            new Action(() =>
                            {
                                MessageBox.Show(
                                    "Danh mục này chưa có bài viết nào. Đang hiển thị các bài viết mới nhất.",
                                    "Thông báo",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information
                                );
                                cbCategories.SelectedIndex = 0; // Switch back to "All"
                            })
                        );
                    }
                    else
                    {
                        MessageBox.Show(
                            "Danh mục này chưa có bài viết nào. Đang hiển thị các bài viết mới nhất.",
                            "Thông báo",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information
                        );
                        cbCategories.SelectedIndex = 0;
                    }
                }
                else
                {
                    UpdateArticleList(articles);
                }
            };

            _articleServices.SearchArticlesResult += UpdateArticleList;

            // Load categories and articles immediately
            _categoryServices.GetCategories();
            _articleServices.GetLatestArticles();

            // Wire up events
            cbCategories.SelectedIndexChanged += CbCategories_SelectedIndexChanged;
            btnSearch.Click += BtnSearch_Click;
        }

        private void UpdateArticleList(List<Article> articles)
        {
           
        }

        private void CbCategories_SelectedIndexChanged(object? sender, EventArgs e)
        {
           
        }

        private void BtnSearch_Click(object? sender, EventArgs e)
        {
         
        }

        private void btnAdminPanel_Click(object sender, EventArgs e)
        {
            
        }

        private void btnProfile_Click(object sender, EventArgs e)
        {
        }

        private void btnPostArticle_Click(object sender, EventArgs e)
        {
            
        }
    }
}