using System;
using Android.App;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using Com.Symbol.Zebrahud;

namespace HUD_XAM_CLOCK
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity,  Com.Symbol.Zebrahud.Hud.IListener
    {
        private ZebraHud hud;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            Android.Support.V7.Widget.Toolbar toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);

            FloatingActionButton fab = FindViewById<FloatingActionButton>(Resource.Id.fab);
            fab.Click += FabOnClick;

            hud = new ZebraHud();
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_main, menu);
            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            int id = item.ItemId;
            if (id == Resource.Id.action_settings)
            {
                return true;
            }

            return base.OnOptionsItemSelected(item);
        }

        private void FabOnClick(object sender, EventArgs eventArgs)
        {
            View view = (View) sender;
            Snackbar.Make(view, "Replace with your own action", Snackbar.LengthLong)
                .SetAction("Action", (Android.Views.View.IOnClickListener)null).Show();
        }

        protected override void OnStart()
        {
            base.OnStart();
            this.hud.OnStart(this);

        }

        protected override void OnStop()
        {
            base.OnStop();
            this.hud.OnStop(this, Java.Lang.Boolean.True);
        }

        protected override void OnPause()
        {
            base.OnPause();
            hud.OnPause(this);
        }

        protected override void OnResume()
        {
            base.OnResume();
            //hud.OnResume(this, this);
        }


        public void OnCameraCapture(Bitmap p0)
        {
        }

        public void OnConnected(bool connected)
        {
            //if (connected) 
              //  hud.ShowMessage("HUD XAMARIN by N.DZL", "Hello from Milan Red-Zone");
        }

        public void OnImageUpdated(byte[] p0)
        {
        }
    }
}

