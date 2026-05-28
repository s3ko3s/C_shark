using System;
using System.Windows.Forms;
using dotnet2.ViewModel;

namespace dotnet2
{
    public partial class Form1 : Form
    {
        private MainViewModel viewModel;

        public Form1()
        {
            InitializeComponent();
            InitializeViewModel();
            SetupBindings();
            LoadTypes();
        }

        private void InitializeViewModel()
        {
            viewModel = new MainViewModel();
        }

        private void LoadTypes()
        {
            comboBoxTypeFlyingMachine.Items.Clear();
            comboBoxTypeFlyingMachine.Items.AddRange(viewModel.AircraftTypes);
            comboBoxTypeFlyingMachine.SelectedIndex = 0;
            // Подписка на изменение выбора в комбобоксе
            comboBoxTypeFlyingMachine.SelectedIndexChanged += (s, e) =>
                viewModel.SelectedType = comboBoxTypeFlyingMachine.SelectedItem.ToString();
        }

        private void SetupBindings()
        {
            // Длина ВПП
            textBoxRunwayLength.DataBindings.Add("Text", viewModel, "RunwayLength", true, DataSourceUpdateMode.OnPropertyChanged);
            // Статус
            textBoxStatus.DataBindings.Add("Text", viewModel, "LogMessages", true, DataSourceUpdateMode.OnPropertyChanged);
            // Доступность кнопок
            buttonFly.DataBindings.Add("Enabled", viewModel, "CanTakeOff", true);
            buttonLand.DataBindings.Add("Enabled", viewModel, "CanLand", true);
        }

        // Обработчики событий кнопок (они уже подписаны в дизайнере)
        private void buttonCreate_Click(object sender, EventArgs e)
        {
            viewModel.CreateAircraft();
        }

        private void buttonFly_Click(object sender, EventArgs e)
        {
            viewModel.TakeOff();
        }

        private void buttonLane_Click(object sender, EventArgs e)  // Посадка
        {
            viewModel.Land();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Можно оставить пустым или сделать начальную инициализацию
        }
    }
}