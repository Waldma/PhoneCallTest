using Android.App;
using Android.Widget;
using Android.OS;
using System;

namespace App1
{
    [Activity(Label = "App1", MainLauncher = true, Icon ="@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get  the UI controls from the loaded layout: 
            EditText phoneNumberText = FindViewById<EditText>(Resource.Id.PhoneNumberText);
            Button translateButton = FindViewById<Button>(Resource.Id.TranslateButton);
            Button callButton = FindViewById<Button>(Resource.Id.CallButton);

            //Disable the "Call" button
            callButton.Enabled = false;

            //Add code to translate number
            string translatedNumber = string.Empty;

            translateButton.Click += (object sender, EventArgs e) =>
            {
                //Translate user's alphanumeric phone number to numeric
                translatedNumber = Core.PhonewordTranslator.ToNumber(phoneNumberText.Text);
                if (String.IsNullOrWhiteSpace(translatedNumber))
                {
                    callButton.Text = "Call";
                    callButton.Enabled = false;
                }
                else
                {
                    callButton.Text = "Call" + translatedNumber;
                    callButton.Enabled = true;
                }
            };
        }
    }
}

