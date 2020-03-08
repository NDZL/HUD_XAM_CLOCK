using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Android.Views;
using Android.Content;

namespace HUD_XAM_JSBLIB
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        Button b;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            b = (Button)FindViewById(Resource.Id.button1);
            b.Click+= delegate {
                Button1OnClick();
            };

        }

        public void Button1OnClick()
        {
            Toast.MakeText(this, "Hello cxnt48", ToastLength.Short).Show();

            Intent Newintent = new Intent("com.zebra.hudinterface.DISPLAY_TEXT_SINGLE_STRING");
            Newintent.PutExtra("single_string.data", "NIK.DZL~END~CYAN~8");
            SendBroadcast(Newintent);

        }
    }
}