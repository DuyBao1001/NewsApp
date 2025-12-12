using NewsApp.BLL;
using NewsApp.Data;

namespace NewsApp.UI
{
    public partial class NewArticleForm : Form
    {
        private readonly ArticleServices _articleServices;
        private readonly CategoryServices _categoryServices;
        private readonly User _currentUser;
        private byte[]? _selectedImage = null;

        public NewArticleForm(
            ArticleServices articleServices,
            CategoryServices categoryServices,
            User currentUser
        )
        {
            InitializeComponent();
            _articleServices = articleServices;
            _categoryServices = categoryServices;
            _currentUser = currentUser;

            // Wire up events
            guna2Button1.Click += BtnPost_Click;
            buttonUploadPic.Click += BtnUploadPic_Click;
            buttonDelete.Click += BtnDeletePic_Click;
            _articleServices.DataChanged += OnArticleDataChanged;
            _categoryServices.GetCategoriesResult += OnGetCategoriesResult;

            // Load categories
            _categoryServices.GetCategories();

            // Set PictureBox properties
            guna2PictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
        }

        private void OnGetCategoriesResult(System.Collections.Generic.List<Category> categories)
        {
            if (InvokeRequired)
            {
                Invoke(
                    new Action<System.Collections.Generic.List<Category>>(OnGetCategoriesResult),
                    categories
                );
                return;
            }

            guna2ComboBox1.DataSource = categories;
            guna2ComboBox1.DisplayMember = "Name";
            guna2ComboBox1.ValueMember = "CategoryID";
        }

        private void BtnUploadPic_Click(object? sender, EventArgs e)
        {
            
        }

        private void BtnDeletePic_Click(object? sender, EventArgs e)
        {
            guna2PictureBox1.Image = null;
            _selectedImage = null;
        }

        private void BtnPost_Click(object? sender, EventArgs e)
        {
            
        }

        private void OnArticleDataChanged(bool success, string message)
        {
        }
    }
}
