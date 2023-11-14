namespace Bud_7
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }

        private void SetReminderButton_Clicked(object sender, EventArgs e)
        {
            DateTime selectedDateTime = datePicker.Date + timePicker.Time;

            if (selectedDateTime < DateTime.Now)
            {
                DisplayAlert("Ошибка", "Выбранная дата и время уже прошли", "ОК");
                return;
            }

            string message = messageEntry.Text;

            Device.StartTimer(selectedDateTime - DateTime.Now, () =>
            {
                DisplayAlert("Напоминание", message, "ОК");
                return false;
            });

            DisplayAlert("Успех", "Напоминание установлено!", "ОК");
        }

        private void ClearButton_Clicked(object sender, EventArgs e)
        {
            datePicker.Date = DateTime.Today;
            timePicker.Time = new TimeSpan(DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
            messageEntry.Text = string.Empty;
        }
    }
}