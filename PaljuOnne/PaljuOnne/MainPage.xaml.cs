using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Essentials;


namespace PaljuOnne
{
    public partial class MainPage : ContentPage
    {
        List<string> friends, mail, number, greets;
        // bool email, letter;
        public MainPage()
        {
            friends = new List<string>() { "Oleg", "Viktor", "Barim" };
            number = new List<string>() { "58043223", "5910203", "88005553535" };
            mail = new List<string> { "veranik03@gmail.com", "krostislav468@gmail.com", "karimbasharov@gmail.com" };
            greets = new List<string> { "С новым годом!", "Привет от деда мороза!", "Верни долг и с новым годом!", "Счастья в новом году!", "Меньше хлопот в новом году!" };
            InitializeComponent();
            friendPicker.ItemsSource = friends;
            friendPicker.SelectedIndexChanged += FriendPicker_SelectedIndexChanged;
            congrat.Clicked += Congrat_Clicked;
        }

        private async void Congrat_Clicked(object sender, EventArgs e)
        {
            Random ranGreet = new Random();
            int rand = ranGreet.Next(5);
            if(type.IsToggled == true)
            {
                await Sms.ComposeAsync(new SmsMessage { Body = greets[rand], Recipients = new List<string> {number[friendPicker.SelectedIndex]}});
            }
            else
            {
                await Email.ComposeAsync("Поздравление", greets[rand], mail[friendPicker.SelectedIndex]);
            }
            
        }
        private void FriendPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            maill.Text = mail[friendPicker.SelectedIndex];
            num.Text = number[friendPicker.SelectedIndex];
        }
    }
}
