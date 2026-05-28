using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using dotnet2.ViewModel;

namespace dotnet2
{
    public partial class Form1 : Form
    {
        private const int ParameterRowHeight = 28;
        private const int ParameterPanelPadding = 10;

        private readonly MainViewModel _viewModel = new MainViewModel();
        private readonly FlowLayoutPanel _constructorParametersPanel = new FlowLayoutPanel();
        private readonly FlowLayoutPanel _objectPropertiesPanel = new FlowLayoutPanel();
        private bool _suppressSelectionEvents;

        public Form1()
        {
            InitializeComponent();
            InitializeReflectionUi();
            SetupBindings();
            SubscribeViewModelEvents();
        }

        private void InitializeReflectionUi()
        {
            string defaultLibraryPath = Path.Combine(
                Application.StartupPath,
                "FlyingMachine.Library.dll");

            _viewModel.LibraryPath = defaultLibraryPath;
            textBoxLibraryPath.Text = defaultLibraryPath;

            ConfigureParameterPanel(_constructorParametersPanel, panelConstructorParameters);
            ConfigureParameterPanel(_objectPropertiesPanel, panelObjectProperties);
        }

        private static void ConfigureParameterPanel(FlowLayoutPanel flowPanel, Panel hostPanel)
        {
            flowPanel.FlowDirection = FlowDirection.TopDown;
            flowPanel.AutoScroll = false;
            flowPanel.WrapContents = false;
            flowPanel.Dock = DockStyle.Fill;
            hostPanel.Controls.Add(flowPanel);
        }

        private void SetupBindings()
        {
            textBoxLibraryPath.DataBindings.Add(
                "Text",
                _viewModel,
                nameof(MainViewModel.LibraryPath),
                true,
                DataSourceUpdateMode.OnPropertyChanged);

            textBoxStatus.DataBindings.Add(
                "Text",
                _viewModel,
                nameof(MainViewModel.StatusMessage),
                true,
                DataSourceUpdateMode.OnPropertyChanged);

            textBoxResult.DataBindings.Add(
                "Text",
                _viewModel,
                nameof(MainViewModel.ExecutionResult),
                true,
                DataSourceUpdateMode.OnPropertyChanged);

            buttonExecute.DataBindings.Add(
                "Enabled",
                _viewModel,
                nameof(MainViewModel.CanExecute),
                true,
                DataSourceUpdateMode.OnPropertyChanged);
        }

        private void SubscribeViewModelEvents()
        {
            _viewModel.ConstructorParameters.CollectionChanged += (sender, args) =>
                RebuildParameterPanel(
                    _constructorParametersPanel,
                    panelConstructorParameters,
                    _viewModel.ConstructorParameters,
                    null);

            _viewModel.ObjectProperties.CollectionChanged += (sender, args) =>
                RebuildParameterPanel(
                    _objectPropertiesPanel,
                    panelObjectProperties,
                    _viewModel.ObjectProperties,
                    "У выбранного класса нет дополнительных свойств для настройки.");
        }

        private void RebuildParameterPanel(
            FlowLayoutPanel flowPanel,
            Panel hostPanel,
            System.Collections.ObjectModel.ObservableCollection<ParameterViewModel> parameters,
            string emptyMessage)
        {
            flowPanel.SuspendLayout();
            flowPanel.Controls.Clear();

            int rowCount = 0;

            if (parameters.Count == 0 && !string.IsNullOrEmpty(emptyMessage))
            {
                flowPanel.Controls.Add(new Label
                {
                    AutoSize = true,
                    ForeColor = SystemColors.GrayText,
                    Text = emptyMessage,
                    MaximumSize = new Size(Math.Max(hostPanel.ClientSize.Width - 20, 400), 0)
                });
                rowCount = 1;
            }

            int labelWidth = 210;
            int inputLeft = labelWidth + 15;

            foreach (ParameterViewModel parameter in parameters)
            {
                var rowPanel = new Panel
                {
                    Width = Math.Max(hostPanel.ClientSize.Width - 20, 500),
                    Height = ParameterRowHeight
                };

                var label = new Label
                {
                    AutoSize = false,
                    Width = labelWidth,
                    Text = $"{parameter.DisplayName} ({parameter.TypeDisplayName}):",
                    Location = new Point(0, 6),
                    TextAlign = ContentAlignment.MiddleLeft
                };

                var textBox = new TextBox
                {
                    Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right,
                    Location = new Point(inputLeft, 3),
                    Width = Math.Max(rowPanel.Width - inputLeft - 5, 120)
                };

                textBox.DataBindings.Add(
                    "Text",
                    parameter,
                    nameof(ParameterViewModel.Value),
                    true,
                    DataSourceUpdateMode.OnPropertyChanged);

                rowPanel.Controls.Add(label);
                rowPanel.Controls.Add(textBox);
                flowPanel.Controls.Add(rowPanel);
                rowCount++;
            }

            int contentHeight = rowCount * ParameterRowHeight + ParameterPanelPadding;
            hostPanel.Height = Math.Max(40, contentHeight);
            flowPanel.ResumeLayout(true);
            UpdateLayoutPositions();
        }

        private void buttonBrowseLibrary_Click(object sender, EventArgs e)
        {
            using (var dialog = new OpenFileDialog())
            {
                dialog.Filter = "Библиотеки .NET|*.dll";
                dialog.Title = "Выберите библиотеку классов";
                dialog.FileName = Path.GetFileName(_viewModel.LibraryPath);
                dialog.InitialDirectory = GetInitialDirectory(_viewModel.LibraryPath);

                if (dialog.ShowDialog(this) == DialogResult.OK)
                {
                    _viewModel.LibraryPath = dialog.FileName;
                }
            }
        }

        private void buttonLoadLibrary_Click(object sender, EventArgs e)
        {
            _viewModel.LoadLibrary();
            RefreshClassList();

            if (listBoxClasses.Items.Count > 0)
            {
                SelectListItem(listBoxClasses, 0);
            }
            else
            {
                ClearConstructorAndMethodLists();
            }
        }

        private void RefreshClassList()
        {
            _suppressSelectionEvents = true;
            try
            {
                listBoxClasses.BeginUpdate();
                listBoxClasses.Items.Clear();
                foreach (string className in _viewModel.ClassNames)
                {
                    listBoxClasses.Items.Add(className);
                }
            }
            finally
            {
                listBoxClasses.EndUpdate();
                _suppressSelectionEvents = false;
            }
        }

        private void RefreshConstructorList()
        {
            _suppressSelectionEvents = true;
            try
            {
                comboBoxConstructors.BeginUpdate();
                comboBoxConstructors.Items.Clear();
                foreach (string signature in _viewModel.ConstructorSignatures)
                {
                    comboBoxConstructors.Items.Add(signature);
                }
            }
            finally
            {
                comboBoxConstructors.EndUpdate();
                _suppressSelectionEvents = false;
            }
        }

        private void RefreshMethodList()
        {
            _suppressSelectionEvents = true;
            try
            {
                comboBoxMethods.BeginUpdate();
                comboBoxMethods.Items.Clear();
                foreach (string methodSignature in _viewModel.MethodSignatures)
                {
                    comboBoxMethods.Items.Add(methodSignature);
                }
            }
            finally
            {
                comboBoxMethods.EndUpdate();
                _suppressSelectionEvents = false;
            }
        }

        private void ClearConstructorAndMethodLists()
        {
            _suppressSelectionEvents = true;
            try
            {
                comboBoxConstructors.Items.Clear();
                comboBoxMethods.Items.Clear();
                _constructorParametersPanel.Controls.Clear();
                _objectPropertiesPanel.Controls.Clear();
            }
            finally
            {
                _suppressSelectionEvents = false;
            }
        }

        private void listBoxClasses_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_suppressSelectionEvents || listBoxClasses.SelectedItem == null)
            {
                return;
            }

            _viewModel.SelectedClassName = listBoxClasses.SelectedItem.ToString();
            RefreshConstructorList();
            RefreshMethodList();

            SelectComboItem(comboBoxConstructors, 0);
            SelectComboItem(comboBoxMethods, 0);
            UpdateLayoutPositions();
        }

        private void comboBoxConstructors_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_suppressSelectionEvents || comboBoxConstructors.SelectedItem == null)
            {
                return;
            }

            _viewModel.SelectedConstructorSignature = comboBoxConstructors.SelectedItem.ToString();
        }

        private void comboBoxMethods_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_suppressSelectionEvents || comboBoxMethods.SelectedItem == null)
            {
                return;
            }

            _viewModel.SelectedMethodSignature = comboBoxMethods.SelectedItem.ToString();
        }

        private void UpdateLayoutPositions()
        {
            int objectPropertiesTop = comboBoxMethods.Bottom + 12;
            labelObjectProperties.Top = objectPropertiesTop;
            panelObjectProperties.Top = labelObjectProperties.Bottom + 4;
            panelObjectProperties.Left = comboBoxMethods.Left;
            panelObjectProperties.Width = comboBoxMethods.Width;

            int executeTop = panelObjectProperties.Bottom + 12;
            buttonExecute.Top = executeTop;
            buttonExecute.Left = panelObjectProperties.Right - buttonExecute.Width;
        }

        private static void SelectListItem(ListBox listBox, int index)
        {
            if (index >= 0 && index < listBox.Items.Count)
            {
                listBox.SelectedIndex = index;
            }
        }

        private void SelectComboItem(ComboBox comboBox, int index)
        {
            if (index >= 0 && index < comboBox.Items.Count)
            {
                _suppressSelectionEvents = true;
                try
                {
                    comboBox.SelectedIndex = index;
                }
                finally
                {
                    _suppressSelectionEvents = false;
                }

                if (comboBox == comboBoxConstructors)
                {
                    _viewModel.SelectedConstructorSignature = comboBox.SelectedItem?.ToString();
                }
                else if (comboBox == comboBoxMethods)
                {
                    _viewModel.SelectedMethodSignature = comboBox.SelectedItem?.ToString();
                }
            }

            UpdateLayoutPositions();
        }

        private void buttonExecute_Click(object sender, EventArgs e)
        {
            _viewModel.ExecuteSelectedMethod();
        }

        private static string GetInitialDirectory(string path)
        {
            string directory = Path.GetDirectoryName(path);
            return string.IsNullOrEmpty(directory) ? Application.StartupPath : directory;
        }
    }
}
