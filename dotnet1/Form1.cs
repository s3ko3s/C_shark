using System;
using System.Windows.Forms;
using dotnet1.ViewModel;
using dotnet1.Model;
using System.Collections.Generic;

namespace dotnet1
{
    public partial class Form1 : Form
    {
        private MainViewModel viewModel;
        private BindingSource bindingSource;

        public Form1()
        {
            InitializeComponent();
            InitializeViewModel();
            SetupBindings();
            SubscribeToViewModel();
        }

        private void InitializeViewModel()
        {
            var testFiles = new List<FileItem>
            {
                new FileItem("document1.txt", FileCategory.File, 1024, @"C:\docs"),
                new FileItem("Photo", FileCategory.Folder, 0, @"F:\photos"),
            };
            viewModel = new MainViewModel(testFiles);
            bindingSource = new BindingSource();
        }

        private void SetupBindings()
        {
            // 1. Привязываем BindingSource к списку файлов
            bindingSource.DataSource = viewModel.Files;

            // 2. ListBox получает данные из BindingSource
            listBoxFiles.DataSource = bindingSource;
            listBoxFiles.DisplayMember = "Name";

            // 3. Связываем CurrentFile ViewModel с выбранным элементом в списке
            bindingSource.CurrentChanged += (s, e) =>
            {
                viewModel.CurrentFile = bindingSource.Current as FileItem;
            };

            // 4. Привязка текстовых полей к текущему элементу через BindingSource
            textBoxName.DataBindings.Add("Text", bindingSource, "Name", true, DataSourceUpdateMode.Never);
            textBoxCategory.DataBindings.Add("Text", bindingSource, "Category", true, DataSourceUpdateMode.Never);
            textBoxSize.DataBindings.Add("Text", bindingSource, "Size", true, DataSourceUpdateMode.Never);
            textBoxPath.DataBindings.Add("Text", bindingSource, "Location", true, DataSourceUpdateMode.Never);

            // 5. Форматирование
            textBoxSize.DataBindings[0].Format += (s, e) => e.Value = $"{e.Value} байт";
            textBoxCategory.DataBindings[0].Format += (s, e) => e.Value = ((FileCategory)e.Value).ToString();
        }

        private void SubscribeToViewModel()
        {
            viewModel.ShowMessageEvent += (text, caption) =>
                MessageBox.Show(text, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void buttonRename_Click(object sender, EventArgs e)
        {
            if (viewModel.RenameCurrent(textBoxNewName.Text.Trim()))
                textBoxNewName.Clear();
        }

        private void buttonMove_Click(object sender, EventArgs e)
        {
            if (viewModel.MoveCurrent(textBoxNewPath.Text.Trim()))
                textBoxNewPath.Clear();
        }

        private void buttonCopy_Click(object sender, EventArgs e)
        {
            viewModel.CopyCurrent(textBoxNewPath.Text.Trim());
            textBoxNewPath.Clear();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            viewModel.AddTestFile();
        }
    }
}